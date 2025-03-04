using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using Paletizer.rs.esteh;

using System.Configuration;

namespace Paletizer
{
    public partial class MainForm : Form
    {
        public const char FNC1 = (char)183;

        DataSet dsItems = new DataSet();
        DataModule db_conn = DataModule.Instance();
        dkPaletaInfo pInfo = new dkPaletaInfo();
        NumberFormatInfo provider = new NumberFormatInfo();

        bool fake_mode = true;

        EstorageWebServiceBeanService estehWSService = new EstorageWebServiceBeanService(); 
        
        int broj_listova = 0;
        bool proizvodnja = false;
        string filter_sifara = "";
        string[] FilterListSifara = null;
        string barcode_prefix = "";
        bool barcode_extended = true;

        public MainForm()
        {

            InitializeComponent();

            provider.NumberDecimalSeparator = ".";
            provider.NumberGroupSeparator = "";

            DataModule.dk_masina.loadDefault();
            // mashine
            db_conn.LoadMasine();
            foreach (dkMasina item in (db_conn.dkMasine_list))
            {
                cmbMasine.Items.Add(item);
                if (DataModule.dk_masina.id == item.id)
                {
                    cmbMasine.SelectedItem = item;
                }
            }

            setDatumInfo(DateTime.Now.ToString(AppFormats.dateFormat));

            try
            {
                this.broj_listova = int.Parse(ConfigurationManager.AppSettings["broj_listova"]);
            }
            catch
            {
                this.broj_listova = 2;
            }

            if (this.broj_listova <= 0)
            {
                this.broj_listova = 2;
            }

            try
            {
                this.proizvodnja = (ConfigurationManager.AppSettings["proizvodnja"] == "true");
            }
            catch
            {
                this.proizvodnja = false; 
            }

            try
            {
                this.filter_sifara = ConfigurationManager.AppSettings["filter_sifara"];
                this.filter_sifara = this.filter_sifara.Trim().ToUpper();
                if (filter_sifara.Length != 0)
                {
                    FilterListSifara = this.filter_sifara.Split(';');
                }
            }
            catch
            {
                this.filter_sifara = ""; 
            }

            try
            {
                this.barcode_prefix = ConfigurationManager.AppSettings["barcode_prefix"];
            }
            catch
            {
                this.barcode_prefix = ""; 
            }

            buttonShiftOver.Visible = proizvodnja;
            dateTimePicker1.Visible = !proizvodnja;

            LoadItems();
            
            //CenterToScreen();
        }

        private void LoadItems()
        {
            lstProizvodi.Items.Clear();

            pInfo.reset();

            dkAltSifra.Text = "";
            txtNazivProizvoda.Text = "";
            BrojKutija.Text = "";
            textKomadi.Text = "0";

            string sifra = fndCode.Text.Trim().ToUpper();
            string naziv = fndNaziv.Text.Trim().ToUpper();

            string comment = "";
            dkComment comm = null;
            if (fndComment.SelectedIndex != -1)
            {
                comm = (dkComment)fndComment.SelectedItem;
                comment = comm.comment;
            }


            // items 
            db_conn.LoadItems();
            if (db_conn.dkItem_list == null)
            {
                return;
            }

            string [] str = new string[3];
            foreach (wsItem item in (db_conn.dkItem_list))
            {
                itemWrap wrap = new itemWrap(item);
                //int item_nr = lstProizvodi1.Items.Add(wrap);
                
                
                str[0] = wrap.item.code.Trim();
                if (wrap.item.comment != null)
                {
                    str[1] = wrap.item.comment.Trim();
                }
                else
                {
                    str[1] = "";
                }
                str[2] = wrap.item.name.Trim();
                
                if (sifra != "")
                {
                    if (!str[0].ToUpper().StartsWith(sifra))
                    {
                        continue;
                    }
                }

                if (FilterListSifara != null)
                {
                    bool good_to_go = false;
                    foreach (string filter_sifra in FilterListSifara)
                    {
                        if (filter_sifra != "")
                        {
                            if (str[0].ToUpper().StartsWith(filter_sifra))
                            {
                                good_to_go = true;
                                break;
                            }
                        }
                    }
                    if (!good_to_go)
                    {
                        continue;
                    }
                }

                if (comm != null)
                {
                    if (str[1].ToUpper() != comment.ToUpper())
                    {
                        continue;
                    }
                }

                if (naziv != "")
                {
                    if (!str[2].ToUpper().Contains(naziv))
                    {
                        continue;
                    }
                }


                ListViewItem itm = new ListViewItem(str);
                itm.Tag = (itemWrap)wrap;

                lstProizvodi.Items.Add(itm);

            }

            fndComment.Items.Clear();
            foreach (dkComment cmm in db_conn.dkComment_list.Values)
            {
                fndComment.Items.Add(cmm);
            }

            
            fndComment.SelectedItem = (dkComment)comm;
            if (comm != null) fndComment.Text = comm.label;

        }

        private void setDatumInfo(string datum_text)
        {
            datumLabel.Text = "Датум: " + datum_text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            daReport.DaPrintDocument daPrintDocument = new daReport.DaPrintDocument();

            if (pInfo.kartona <= 0 && pInfo.masa_na_paleti == 0)
            {
                MessageBox.Show("Неисправан број кутија унесен!", "ДОНКАФЕ - Палетизер", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                setStatus("Морате унети количину");
                return;
            }


            bool jm_komad = (pInfo.jm.ToUpper() == "KOM") || (pInfo.jm.ToUpper() == "PAK") || (pInfo.jm.ToUpper() == "KUT");
            int faktor = 1;
            /*if (!jm_komad)
            {
                faktor = 1000;
            }*/

            
            if (pInfo.Status == 0)
            {
                // paleta nije stampana
                // uzmi novi broj od Dekija

                // TO DO Sloba
                //if (fake_mode)
                //{
                if (!proizvodnja)
                {
                    // ako si u magacinu uzmi izabrani datum iz pikera
                    pInfo.datum = dateTimePicker1.Value;
                }
                else
                {
                    // ako si u proizvodnji uzmi stvarno vreme
                    pInfo.datum = DateTime.Now;
                }

                wsPalletBarCode new_pallete_info = new wsPalletBarCode();
                new_pallete_info.itemCode = pInfo.proizvod_sifra.Trim();
                new_pallete_info.packageCount = pInfo.kartona;
                new_pallete_info.packageWeight = (int)(pInfo.masa_u_kartonu * faktor);
                new_pallete_info.palletWeight = (int)(pInfo.masa_na_paleti * faktor);
                new_pallete_info.productionDate = pInfo.datum;
                new_pallete_info.productionDateSpecified = true;
                new_pallete_info.shiftCode = (DataModule.smena + 1) + "";
                new_pallete_info.workerCode = DataModule.dk_user.id + "";

                // ako je proizvodnja - stavi pocetni status, ako je iz lagera stavi prihvacen status
                new_pallete_info.status = proizvodnja ? 1 : 2;
                new_pallete_info.statusSpecified = true;

                if (!jm_komad)
                {
                    new_pallete_info.itemWeight = Math.Max(pInfo.masa, 1);
                }
                else
                {
                    new_pallete_info.itemWeight = 1;
                }
                new_pallete_info.itemWeightSpecified = true;

                if (!jm_komad)
                {
                    new_pallete_info.itemPackageCount = (int)(new_pallete_info.packageWeight / new_pallete_info.itemWeight);
                }
                else
                {
                    new_pallete_info.itemPackageCount = (int)pInfo.masa_u_kartonu;
                }
                new_pallete_info.itemPackageCountSpecified = true;

                if (!jm_komad)
                {
                    new_pallete_info.itemPalletCount = (int)(new_pallete_info.palletWeight / new_pallete_info.itemWeight);
                }
                else
                {
                    new_pallete_info.itemPalletCount = (int)pInfo.masa_na_paleti;
                }
                new_pallete_info.itemPalletCountSpecified = true;

                new_pallete_info.engine1 = "PALETIZACIJA";
                new_pallete_info.engine2 = "";

                new_pallete_info.prefix = barcode_prefix;

                try
                {
                    palletBarCodeWsWrapper _result = estehWSService.newPalletBarCode(new_pallete_info);
                    if (_result.resultStatus.returnCode != wsReturnCode.OK)
                    {
                        MessageBox.Show("Грешка у комуникацији, покушајте поново!");
                        return;
                    }
                    
                    pInfo.barkod_palete = _result.palletBarCode.barCode;
                }
                catch
                {
                    MessageBox.Show("Грешка у комуникацији, покушајте поново!");
                    return;
                }

                if (proizvodnja)
                {
                    //"{0:0.000}"
                    dkPallet.SaveLine(pInfo.datum, pInfo.barkod_palete, pInfo.proizvod_sifra.Trim(), pInfo.jm,
                                (jm_komad ? ((int)pInfo.masa_na_paleti + "") : Convert.ToString((double)(pInfo.masa_na_paleti / 1000.0), provider)),
                                DataModule.dk_masina.NazivMasine, pInfo.kartona + "", 0);
                }
            }
            
            //pInfo.barkod_palete = "D00001860";

            // TO DO Sloba 
            if (fake_mode)
            {
                pInfo.Status = dkConstants.SP_STAMPANO;
            }
            else
            {

                // snimi paletu u bazu podataka
                if (!db_conn.SnimiPaletu(pInfo))
                {
                    MessageBox.Show("Снимање палете није успело");
                    return;
                }

            }

            // fill in parameters
            // (parameter names are case sensitive)
            Hashtable parameters = new Hashtable();
            parameters.Add("parameter1", pInfo.proizvod_naziv.Trim());
            parameters.Add("parameter2", pInfo.proizvod_sifra.Trim() + " / " + pInfo.barkod_palete.Trim());

            if (pInfo.ItemPackageCount != 1)
            {
                parameters.Add("parameter3", pInfo.kartona + "");
            }

            if (!jm_komad)
            {
                parameters.Add("parameter4", String.Format("{0:0.000}", pInfo.masa_na_paleti/1000));
                if (pInfo.ItemPackageCount != 1)
                {
                    parameters.Add("parameter7", String.Format("{0:0.000}", pInfo.masa_u_kartonu / 1000));
                }
            }
            else
            {
                parameters.Add("parameter4", (int)pInfo.masa_na_paleti + "");
                if (pInfo.ItemPackageCount != 1)
                {
                    parameters.Add("parameter7", (int)pInfo.masa_u_kartonu + "");
                }
            }



            //TO DO SLoba
            //parameters.Add("parameter8", pInfo.broj_palete + "");

            //parameters.Add("parameter5", pInfo.datum.ToString(AppFormats.dateFormat));
            parameters.Add("parameter9", pInfo.datum.ToString(AppFormats.dateTimeFormat));

            parameters.Add("parameter23", pInfo.datum.ToString(AppFormats.dateFormat));


            // jedinica mere
            parameters.Add("parameter10", pInfo.jm);

            parameters.Add("parameter6", "*" + pInfo.barkod_palete + "*");

            string kolicina_na_paleti =
                (jm_komad ? pInfo.masa_na_paleti * 1000 : pInfo.masa_na_paleti) + "";

            kolicina_na_paleti = populateWithExtraZeroStr(kolicina_na_paleti, 7);

            //if (barcode_extended)
            {
                parameters.Add(
                    "parameter11", "*" + pInfo.barkod_palete +
                    "A" + populateWithExtraZeroStr(pInfo.proizvod_sifra.Trim(), 9) +
                    "Q" + kolicina_na_paleti + "*");
            }

            string doncafePrefix = "86050069";
            string barcodePackage = pInfo.proizvod_barkod_pak.Trim();
            if (barcodePackage == null)
            {
                barcodePackage = "9999999999999";
            }
            string SSCC = "0" + doncafePrefix + populateWithExtraZeroStr(pInfo.barkod_palete.Trim().Replace("D",""), 8);
            SSCC += CalculateChecksumDigit(SSCC);
            SSCC = "(00)" + SSCC;

            string lot = pInfo.datum.ToString(AppFormats.dateTimeFormat_lot);
            //lot = populateWithExtraZeroStr(lot, 9);
            parameters.Add("parameter19", lot);

            //barkod artikla
            parameters.Add("parameter12", barcodePackage);

            //SSCC
            parameters.Add("parameter13", SSCC);

            //SIFRA ARTIKLA
            parameters.Add("parameter14", pInfo.proizvod_sifra.Trim());

            //BARKOD1



            string code1 = "(02)0" + barcodePackage + "(11)" + pInfo.datum.ToString(AppFormats.dateTimeFormat_dayYear2) + "(37)" + pInfo.kartona;
            parameters.Add("parameter15", code1);
            parameters.Add("parameter22", BarCode.BarcodeConverter128.StringToBarcode(code1.Replace("(", "").Replace(")", "")));
            /*
            AeromiumBarcodes abarcode1 = new AeromiumBarcodes();
            abarcode1.BarcodeSymbology = AeromiumBarcodes.BarcodeEnum.UCCEAN;
            abarcode1.InputText = code1;
            abarcode1.generate();

            parameters.Add("parameter15", code1);
            parameters.Add("parameter22", abarcode1.EncodedOuput);*/


            //BROJ TP
            parameters.Add("parameter16", pInfo.kartona);

            //BARKOD2
            string masaNaPaleti = "";
            if (!jm_komad)
            {
                masaNaPaleti = "" + (pInfo.masa_na_paleti / 10);
            } else {
                masaNaPaleti = "" + pInfo.masa_na_paleti;
            }
            string code2 = "(3102)" + populateWithExtraZeroStr(masaNaPaleti, 6) + "(10)" + lot;
            parameters.Add("parameter17", code2);
            parameters.Add("parameter21", BarCode.BarcodeConverter128.StringToBarcode(code2.Replace("(", "").Replace(")", "")));
            /*
            AeromiumBarcodes abarcode2 = new AeromiumBarcodes();
            abarcode2.BarcodeSymbology = AeromiumBarcodes.BarcodeEnum.UCCEAN;
            abarcode2.InputText = code2;
            abarcode2.generate();
            parameters.Add("parameter17", code2);
            parameters.Add("parameter21", abarcode2.EncodedOuput);
            */


            //BARKOD3
            parameters.Add("parameter18", SSCC);
            parameters.Add("parameter20", BarCode.BarcodeConverter128.StringToBarcode(SSCC.Replace("(", "").Replace(")", "")));
            /*
            AeromiumBarcodes abarcode3 = new AeromiumBarcodes();
            abarcode3.BarcodeSymbology = AeromiumBarcodes.BarcodeEnum.UCCEAN;
            abarcode3.InputText = SSCC;
            abarcode3.generate();

            parameters.Add("parameter18", SSCC);
            parameters.Add("parameter20", abarcode3.EncodedOuput);
            */
            daPrintDocument.setXML("PaletaLabelItm.xml");

            /*
            // set .xml file for printing
            if (kolicina_na_paleti.Length <= 7)
            {
                daPrintDocument.setXML("PaletaLabel.xml");
            }
            else
            {
                daPrintDocument.setXML("PaletaLabelS.xml");
            }*/

            daPrintDocument.SetParameters(parameters);

            // print preview
            /*
            printPreviewDialog1.Document = daPrintDocument;
            printPreviewDialog1.PrintPreviewControl.Zoom = 1.0;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog(this);
            */

            daPrintDocument.PrinterSettings.Copies = (short)broj_listova;
            daPrintDocument.Print();

            BrojKutija.ReadOnly = true;
            btnGotovo.Visible = true;
        }

        public string populateWithExtraZeroStr(string snum, int numOfZeros)
        {
            string br = snum;
            if (numOfZeros > br.Length)
            {
                int extra = numOfZeros - br.Length;
                for (int i = 0; i < extra; i++)
                {
                    br = "0" + br;
                }
            }
            return br;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter && (fndCode.Focused || fndComment.Focused || fndNaziv.Focused))
            {
                if (pInfo.Status == 0)
                {
                    LoadItems();
                }
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!LoginTo())
            {
                return;
            }

            setDatumInfo(DateTime.Now.ToString(AppFormats.dateFormat));
            // to do sloba
            //dateTimePicker1.Visible = fake_mode;
        }
        
        bool LoginTo()
        {
            LoginForm login = new LoginForm();
            if (login.ShowDialog(this) != DialogResult.OK)
            {
                //Close();
                Application.Exit();
                return false;
            }

            login.Dispose();

            userLabel.Text = "Оператер: " + DataModule.dk_user.ime_prezime.Trim() +
                            ",  Смена: " + (DataModule.smena + 1);

            cmbSmena.SelectedIndex = DataModule.smena;

            foreach (dkMasina item in (db_conn.dkMasine_list))
            {
                if (DataModule.dk_masina.id == item.id)
                {
                    cmbMasine.SelectedItem = item;
                }
            }

            return true;
        }


        private bool popuniPaletaInfo(wsItem item)
        {
            
            //int SpakovanoKutija = 0;
            //int SpakovanoProizvoda = 0;
            
            /*
            int NUSifraReceptaZaPakovanje = db_conn.UzmiReceptZaPakovanjeSirovine(item.id);
            int sifra_recepta_cele_palete = 0;

            if (NUSifraReceptaZaPakovanje > 0)
            {
                int sifra_pakovanja = db_conn.UzmiSifruProizvodaRecepta(NUSifraReceptaZaPakovanje);

                sifra_recepta_cele_palete = db_conn.UzmiReceptZaPakovanjeSirovine(sifra_pakovanja);
                if (sifra_recepta_cele_palete > 0)
                {
                    SpakovanoKutija = db_conn.IzracunajSpakovanuKolicinuUnazad(sifra_recepta_cele_palete, sifra_pakovanja, 1);
                    SpakovanoProizvoda = db_conn.IzracunajSpakovanuKolicinuUnazad(NUSifraReceptaZaPakovanje, item.id, SpakovanoKutija);
                }
            }
            */

            // pocisti prethodne vrednosti 
            pInfo.reset();

            /*
            pInfo.SifraReceptaZaPakovanje = NUSifraReceptaZaPakovanje;
            pInfo.SifraReceptaZaPaletu = sifra_recepta_cele_palete;
            */

            pInfo.item_id = item.id;

            pInfo.proizvod_barkod = item.sku;
            pInfo.proizvod_barkod_pak = item.skuPack;

            // TO DO Sloba
            if (!fake_mode)
            {
                pInfo.broj_palete = db_conn.UzmiNoviBrojPalete();
            }

            pInfo.masa_na_paleti = (double)Math.Max(1, item.itemWeight) * item.itemPalletCount;
            pInfo.masa_u_kartonu = (double)Math.Max(1, item.itemWeight) * item.itemPackageCount;
            pInfo.ItemPackageCount = (int)Math.Max(1, item.itemPackageCount);

            if (item.itemPackageCount > 0)
            {
                pInfo.kartona = item.itemPalletCount / item.itemPackageCount;
            }

            pInfo.datum_vreme = "";
            pInfo.barkod_palete = "";

            if (item.comment != null)
                pInfo.proizvod_naziv = item.comment.Trim().ToUpper() + " " + item.name;
            else
                pInfo.proizvod_naziv =  item.name;
            pInfo.proizvod_sifra = item.code;

            pInfo.jm = item.unit;
            pInfo.masa = item.itemWeight;

            //bool jm_komad = (pInfo.jm.ToUpper() == "KOM") || (pInfo.jm.ToUpper() == "PAK") || (pInfo.jm.ToUpper() == "KUT");
            bool jm_komad = (pInfo.jm.ToUpper() == "KOM") || (pInfo.jm.ToUpper() == "PAK") || (pInfo.jm.ToUpper() == "KUT");

            if (Math.Max(item.itemPackageCount, 1) == 1)
            {
                labelKomada.Visible = false;
                textKomadi.Visible = false;
                textKomadi.Text = "0";
                if (Math.Max(1, item.itemWeight) != 1)
                {
                    // BOLE FOLIJE SPEC!!!!
                    //labelKartonaInfo.Text = "Број комада (" + item.unit + ")";
                    labelKartonaInfo.Text = "Број комада";
                }
                else
                {
                    labelKartonaInfo.Text = "Количина (" + item.unit + ")";
                }
            }
            else
            {
                labelKartonaInfo.Text = "Број кутија";
                
                labelKomada.Visible = true;
                textKomadi.Visible = true;
                textKomadi.Text = "0";
            }

            /*
            try
            {
                pInfo.kartona = int.Parse(BrojKutija.Text);
            }
            catch
            {
                pInfo.kartona = 0;
            }
             * 
             */

            BrojKutija.Text = pInfo.kartona + "";

            pInfo.datum = DateTime.Now;
            dateTimePicker1.Value = pInfo.datum;

            // to do sloba
            /*
            if (fake_mode)
            {
                pInfo.datum = dateTimePicker1.Value;
            }
            */

            //pInfo.create_barcode();

            setDatumInfo(pInfo.datum.ToString(AppFormats.dateFormat));

            return true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataModule.dk_user.id = 0;
            if (!LoginTo())
            {
                return;
            }
            /*
            LoginForm login = new LoginForm();
            if (login.ShowDialog(this) == DialogResult.OK)
            {
                userLabel.Text = "Оператер: " + DataModule.dk_user.ime_prezime.Trim() +
                                ",  Смена: " + (DataModule.smena + 1);

                cmbSmena.SelectedIndex = DataModule.smena;

            }
            login.Dispose();

            foreach (dkMasina item in (db_conn.dkMasine_list))
            {
                if (DataModule.dk_masina.id == item.id)
                {
                    cmbMasine.SelectedItem = item;
                }
            }
            */
            setDatumInfo(DateTime.Now.ToString(AppFormats.dateFormat));
            
        }

        private void btnGotovo_Click(object sender, EventArgs e)
        {
            /*TO DO Sloba*/
            if (!fake_mode)
            {
                if (!ZavrsiPaletu())
                {
                    return;
                }
            }

            setStatus("Палета " + pInfo.proizvod_naziv.Trim() + " број " 
                    + pInfo.broj_palete + " је успешно снимљена! Можете наставити са палетизацијом.");

            pInfo.reset();

            dkAltSifra.Text = "";
            txtNazivProizvoda.Text = "";
            BrojKutija.Text = "";

            //lstProizvodi1.SelectedItem = -1;
            //lstProizvodi1.SelectedItem = null;


            lstProizvodi.SelectedIndices.Clear();
            lstProizvodi.SelectedItems.Clear();


            btnGotovo.Visible = false;
            btnPreview.Enabled = false;

            LoadItems();

        }

        bool ZavrsiPaletu()
        {
            bool _result = true;

            
            int SpakovanoKutija = 0;
            int SpakovanoProizvoda = 0;
            int sifra_pakovanja = 0;
            int sifra_palete = 0 ;
            int sifra_cele_palete = 0;

            int NUSifraReceptaZaPakovanje = db_conn.UzmiReceptZaPakovanjeSirovine(pInfo.item_id);

            if (NUSifraReceptaZaPakovanje > 0)
            {
                sifra_pakovanja = db_conn.UzmiSifruProizvodaRecepta(NUSifraReceptaZaPakovanje);

                sifra_cele_palete = db_conn.UzmiReceptZaPakovanjeSirovine(sifra_pakovanja);
                if (sifra_cele_palete > 0)
                {
                    sifra_palete = db_conn.UzmiSifruProizvodaRecepta(sifra_cele_palete);
                    SpakovanoKutija = db_conn.IzracunajSpakovanuKolicinuUnazad(sifra_cele_palete, sifra_pakovanja, 1);
                    SpakovanoProizvoda = db_conn.IzracunajSpakovanuKolicinuUnazad(NUSifraReceptaZaPakovanje, pInfo.item_id, SpakovanoKutija);
                }

            }

            dkOperacija sOperacija = new dkOperacija();
            DateTime truncated = new DateTime(pInfo.datum.Year, pInfo.datum.Month, pInfo.datum.Day);

            // snimanje Pakovanja
            if (NUSifraReceptaZaPakovanje > 0)
            {
                
                sOperacija.Datum = truncated;
                sOperacija.Smena = DataModule.smena+1;
                sOperacija.SifraMasine = DataModule.dk_masina.id;
                sOperacija.SifraRadnika = DataModule.dk_user.id;
                sOperacija.SifraRecepta = NUSifraReceptaZaPakovanje;
                sOperacija.SifraSirovine = sifra_pakovanja;
                sOperacija.Primedba = "Paletizacija";


                db_conn.UcitajPodatkeOperacije(ref sOperacija);

                if (sOperacija.SifraOperacije > 0)
                {
                    db_conn.ObrisiSastojkeOperacije (sOperacija.SifraOperacije);
                    sOperacija.KolicinaProizvoda = sOperacija.KolicinaProizvoda + SpakovanoKutija;
                    sOperacija.Proizvedeno = sOperacija.Proizvedeno + SpakovanoKutija;
                }
                else
                {
                    sOperacija.SifraOperacije = -1;
                    sOperacija.KolicinaProizvoda = SpakovanoKutija;
                    sOperacija.Proizvedeno = SpakovanoKutija;
                }

                db_conn.SnimiOperaciju(ref sOperacija);

                db_conn.KreirajSastojke(sOperacija.SifraOperacije/*, NUSifraReceptaZaPakovanje*/);
                pInfo.SifraOperacijePakovanje = sOperacija.SifraOperacije;
            }


            sOperacija = new dkOperacija();
            //
            if (sifra_cele_palete > 0)
            {

                sOperacija.Datum = truncated;
                sOperacija.Smena = DataModule.smena+1;
                sOperacija.SifraMasine = DataModule.dk_masina.id;
                sOperacija.SifraRadnika = DataModule.dk_user.id;
                sOperacija.SifraRecepta = sifra_cele_palete;
                sOperacija.SifraSirovine = sifra_palete;
                sOperacija.Primedba = "Paletizacija";

                db_conn.UcitajPodatkeOperacije(ref sOperacija);

                if (sOperacija.SifraOperacije > 0)
                {
                    db_conn.ObrisiSastojkeOperacije(sOperacija.SifraOperacije);
                    sOperacija.KolicinaProizvoda = sOperacija.KolicinaProizvoda + 1;
                    sOperacija.Proizvedeno = sOperacija.Proizvedeno + 1;
                }
                else
                {
                    sOperacija.SifraOperacije = -1;
                    sOperacija.KolicinaProizvoda = 1;
                    sOperacija.Proizvedeno = 1;
                }

                db_conn.SnimiOperaciju(ref sOperacija);
                db_conn.KreirajSastojke (sOperacija.SifraOperacije);

                pInfo.SifraOperacijePaleta = sOperacija.SifraOperacije;
                pInfo.Status = dkConstants.SP_GOTOVO;
                db_conn.DopuniPaletu(pInfo);
            
            }
            
            return _result;
        }

        void setStatus(string status_text)
        {
            labelPorukaPaletizacije.Text = status_text;
        }

        private void BrojKutija_TextChanged(object sender, EventArgs e)
        {
            /*
            if (pInfo.broj_palete < 0)
            {
                return;
            }
            */

            int broj_kartona = 0;
            int brok_komada_vankutije = 0;
            try
            {
                broj_kartona = int.Parse(BrojKutija.Text);
            }
            catch
            {
                //MessageBox.Show("Neispravan broj kutija unesen!");
                broj_kartona = 0;
                //return;
            }

            try
            {
                brok_komada_vankutije = int.Parse(textKomadi.Text);
            }
            catch
            {
                //MessageBox.Show("Neispravan broj kutija unesen!");
                brok_komada_vankutije = 0;
                //return;
            }

            pInfo.masa_na_paleti = brok_komada_vankutije * pInfo.masa + pInfo.masa_u_kartonu * Math.Max(0, broj_kartona);
            pInfo.kartona = broj_kartona;

            //pInfo.create_barcode();
        }

        private void btnIzbor_Click(object sender, EventArgs e)
        {
            if (pInfo.Status != 0)
            {
                return;
            }

            if (lstProizvodi.SelectedIndices.Count == 0)
            {
                return;
            }
            /*
            if (lstProizvodi1.SelectedIndex < 0)
            {
                return;
            }
             * */

            itemWrap wrap = (itemWrap)lstProizvodi.SelectedItems[0].Tag;
            wsItem item = (wsItem)wrap.item;
            if (item != null)
            {
                dkAltSifra.Text = item.code;

                if (item.comment != null)
                    txtNazivProizvoda.Text = item.comment.Trim().ToUpper() + " " + item.name;
                else
                    txtNazivProizvoda.Text = item.name;

                // uzima parametre za pakovanje kartona i palete 
                popuniPaletaInfo(item);

                btnPreview.Enabled = true;
                btnGotovo.Visible = false;
            }
            else
            {
                dkAltSifra.Text = "";
                //dkBarkodProizvoda.Text = "";
                txtNazivProizvoda.Text = "";
                btnPreview.Enabled = false;
                btnGotovo.Visible = false;
            }

            // omoguci unos broja kutija na paleti
            BrojKutija.ReadOnly = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DataModule.dk_user.id <= 0)
            {
                // ako nismo ni ulogovani onda nema potreb ni za pitanjem
                return;
            }

            // pitamo samo ulogovanog radnika da li zaista zeli da izadje
            if (MessageBox.Show("Да ли сте сигурни да желите угасити програм?",
                        "ДОНКАФЕ - Палетизер", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void cmbSmena_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataModule.smena = cmbSmena.SelectedIndex;
            userLabel.Text = "Оператер: " + DataModule.dk_user.ime_prezime.Trim() +
                            ",  Смена: " + (DataModule.smena + 1);
            DataModule.saveSmena(cmbSmena.SelectedIndex);
        }

        private void cmbMasine_SelectedIndexChanged(object sender, EventArgs e)
        {
            dkMasina dk_masina = (dkMasina)cmbMasine.SelectedItem;
            if (dk_masina.id != DataModule.dk_masina.id)
            {
                DataModule.dk_masina = dk_masina;
                DataModule.dk_masina.saveAsDefault();
            }
        }

        private void lstProizvodi_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (lstProizvodi1.SelectedIndex >= 0)
            {
                // izaberi artikal
                btnIzbor_Click(sender, e);
            }
             * */
        }

        private void textKomadi_TextChanged(object sender, EventArgs e)
        {
            int broj_kartona = 0;
            int brok_komada_vankutije = 0;
            try
            {
                broj_kartona = int.Parse(BrojKutija.Text);
            }
            catch
            {
                //MessageBox.Show("Neispravan broj kutija unesen!");
                broj_kartona = 0;
                //return;
            }

            try
            {
                brok_komada_vankutije = int.Parse(textKomadi.Text);
            }
            catch
            {
                //MessageBox.Show("Neispravan broj kutija unesen!");
                brok_komada_vankutije = 0;
                //return;
            }

            pInfo.masa_na_paleti = brok_komada_vankutije*pInfo.masa + pInfo.masa_u_kartonu * Math.Max(0, broj_kartona);
            pInfo.kartona = broj_kartona;
        }

        private void lstProizvodi_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
            if (lstProizvodi.SelectedIndices.Count > 0)
            {
                // izaberi artikal
                btnIzbor_Click(sender, e);
            }
             
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (pInfo.Status == 0)
            {
                LoadItems();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            fndCode.Text = "";
            fndComment.SelectedItem = null;
            fndComment.Text = "";
            fndNaziv.Text = "";

            btnFind_Click(sender, e);

        }

        private void buttonShiftOver_Click(object sender, EventArgs e)
        {
            PalleteList palleteListDlg = new PalleteList();
            if (palleteListDlg.ShowDialog() != DialogResult.Cancel)
            {
                //MessageBox.Show("sad se on izloguje");
                DataModule.dk_user.id = 0;
                LoginTo();
            }
        }
        /*
          Dim checksum&, i%
  For i% = Len(COvaleur) To 1 Step -2
    checksum& = checksum& + Val(Mid$(COvaleur, i%, 1))
  Next
  checksum& = checksum& * 3
  For i% = Len(COvaleur) - 1 To 1 Step -2
    checksum& = checksum& + Val(Mid$(COvaleur, i%, 1))
  Next
  COvaleur = COvaleur & (10 - checksum& Mod 10) Mod 10
        */
        public static string aCalculateChecksumDigit(string sTemp)
        {
            int iSum = 0;
            int iDigit = 0;

            // Calculate the checksum digit here.
            for (int i = sTemp.Length; i >= 1; i--)
            {
                iDigit = Convert.ToInt32(sTemp.Substring(i - 1, 1));
                if (i % 2 == 0)
                {	// odd
                    iSum += iDigit * 3;
                }
                else
                {	// even
                    iSum += iDigit * 1;
                }
            }

            int iCheckSum = (10 - (iSum % 10)) % 10;
            return iCheckSum.ToString();

        }

        public static  string CalculateChecksumDigit(String pgtin)
        {
            Int32 glength = 0;
            Int32 total = 0;
            Int32 cSum = 0;
            Int32[] mutiply = { 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3 };
            glength = 17 - pgtin.Length;
            for (int i = 0; i < pgtin.Length; i++)
            {
                total = total + (Int32.Parse(pgtin[i].ToString()) * mutiply[i + glength]);
            }
            cSum = 10 - (total % 10);
            return cSum.ToString();

        }
    }
}