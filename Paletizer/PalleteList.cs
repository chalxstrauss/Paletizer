using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Paletizer.rs.esteh;

namespace Paletizer
{
    public partial class PalleteList : Form
    {
        string appPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);

        public PalleteList()
        {
            InitializeComponent();
            appPath = appPath.Replace("file://", "");
            appPath = appPath.Replace("file:\\", "");
        }

        private void PalleteList_Load(object sender, EventArgs e)
        {
            CenterToParent();

            LoadPallets();
        }

        void LoadPallets()
        {
            string sourceFile = dkPallet.getPaleteFile();
            if (!File.Exists(sourceFile))
            {
                return;
            }

            StreamReader file_data = new StreamReader(sourceFile, Encoding.GetEncoding("windows-1250"));

            string line = "";
            while ((line = file_data.ReadLine()) != null)
            {
                dkPallet pallet = new dkPallet();
                line = line.Trim();
                if (!pallet.Parse(line))
                {
                    continue;
                }
                string[] str = new string[6];
                str[0] = pallet.dateTime.ToString("dd.MM.yyyy. HH:mm:ss");
                str[1] = pallet.barcode;
                str[2] = pallet.item_code;
                str[3] = pallet.kolicina + " " + pallet.jm;
                str[4] = pallet.masina;
                str[5] = pallet.broj_kutija;

                ListViewItem itm = new ListViewItem(str);
                itm.Tag = (dkPallet)pallet;

                if (pallet.pallet_status != 0)
                {
                    itm.ForeColor = Color.DarkSalmon;
                }
                lstPallet.Items.Add(itm);

            }// while

            try
            {
                if (file_data != null) file_data.Close();
            }
            finally
            {
                file_data = null;
            }
        }

        private void btnPrenosMagacin_Click(object sender, EventArgs e)
        {
            PrenosUMagacin(false);
        }

        bool PrenosUMagacin(bool silent)
        {
            if (lstPallet.Items.Count == 0)
            {
                return true;
            }

            // ukloni sve neispravne palete
            for (int ii = lstPallet.Items.Count - 1; ii >= 0; ii--)
            {
                if (((dkPallet)lstPallet.Items[ii].Tag).pallet_status == 0)
                {
                    continue;
                }
                lstPallet.Items.RemoveAt(ii);
            }

            // 1
            // pozovi Dekijev servis i posalji mu listu svih paleta 
            // da bi ih oznacio 
            wsPalletBarCode[] pallet_list = new wsPalletBarCode[lstPallet.Items.Count];
            for (int ii = 0; ii < lstPallet.Items.Count; ii++)
            {
                wsPalletBarCode palletBC = new wsPalletBarCode();
                palletBC.barCode = ((dkPallet)lstPallet.Items[ii].Tag).barcode;
                pallet_list[ii] = palletBC;
            }

            // web servis poziv 
            if (!DataModule.Instance().PrihvatiPaleteUMagacin(pallet_list))
            {
                return false;
            }


            // 2 
            // prebaci sve iz liste u probatov lokalni fajl 
            while (lstPallet.Items.Count > 0)
            {
                wsPalletBarCode palletBC = new wsPalletBarCode();
                dkPallet palletItem = (dkPallet)lstPallet.Items[0].Tag;
                if (!palletItem.saveToLocalProbat())
                {
                    MessageBox.Show("Дошло је до грешке приликом преноса података, покушајте поново");
                    SaveData();
                    return false;
                }
                lstPallet.Items.RemoveAt(0);
            }


            // 3.
            // obrisi lokalni falj za magacin
            dkPallet.removePalletFile();

            // 4.
            // ocisiti listu i izadji sa maske 
            if (!silent)
            {
                MessageBox.Show("Пренос успешно извршен!");
            }

            return true;
        }

        private void btnDelPallet_Click(object sender, EventArgs e)
        {
            if (lstPallet.SelectedIndices.Count == 0)
            {
                return;
            }

            dkPallet pallet = (dkPallet)lstPallet.SelectedItems[0].Tag;
            if (pallet != null)
            {
                if (pallet.pallet_status == 1)
                {
                    pallet.pallet_status = 0;
                    lstPallet.SelectedItems[0].ForeColor = Color.Black;
                }
                else
                {
                    pallet.pallet_status = 1;
                    lstPallet.SelectedItems[0].ForeColor = Color.DarkSalmon;
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
            StreamWriter sw = null;

            string sourceFile = dkPallet.getPaleteFile();
            if (File.Exists(sourceFile))
            {
                File.Delete(sourceFile);
            }

            sw = File.CreateText(sourceFile);

            int count = lstPallet.Items.Count;
            for (int ii = 0 ; ii < count; ii++)
            {
                dkPallet pallet = (dkPallet)lstPallet.Items[ii].Tag;
                if (pallet != null)
                {
                    sw.WriteLine(pallet.ToString());
                }
            }

            try
            {
                if (sw != null) sw.Close();
            }
            finally
            {
                sw = null;
            }*/
            SaveData();
        }

        void SaveData()
        {
            StreamWriter sw = null;

            string sourceFile = dkPallet.getPaleteFile();
            if (File.Exists(sourceFile))
            {
                File.Delete(sourceFile);
            }

            sw = File.CreateText(sourceFile);

            int count = lstPallet.Items.Count;
            for (int ii = 0 ; ii < count; ii++)
            {
                dkPallet pallet = (dkPallet)lstPallet.Items[ii].Tag;
                if (pallet != null)
                {
                    sw.WriteLine(pallet.ToString());
                }
            }

            try
            {
                if (sw != null) sw.Close();
            }
            finally
            {
                sw = null;
            }
        }

        private void btnPrenosProbat_Click(object sender, EventArgs e)
        {
            ProbatPasswordForm probatForm = new ProbatPasswordForm();

            if (probatForm.ShowDialog() != DialogResult.OK )
            {
                if (probatForm.PasswordMessage)
                {
                    MessageBox.Show("Унета шифра није исправна!");
                }
                DialogResult = DialogResult.None;
                return;
            }

            // 1.
            // prebaci sve iz liste u probatov lokalni fajl 
            // izvrsi prenos u magacin ako ima artikala koji nisu jos uvek preneseni
            if (!PrenosUMagacin(true))
            {
                DialogResult = DialogResult.None;
                return;
            }

            // 2.
            // Prebaci probatov fajl na mesto za preuzimanje 
            // i obrisi lokalni štek
            if (!dkPallet.MoveProbatFile())
            {
                DialogResult = DialogResult.None;
                return;
            }

            MessageBox.Show("Пренос у ПРОБАТ успешно извршен!");

            // 4.
            // ocisiti listu i izadji sa maske , izloguj usera 
            // 
            
        }
    }
}