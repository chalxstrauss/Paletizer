using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Paletizer.rs.esteh;
using System.Windows.Forms;

namespace Paletizer
{

    /// Creates and returns SqlConnection, SqlCommand
    /// and SqlDataReader
    public class DataModule : IDisposable
    {

        private static DataModule aDataModule = null;
        public static DataModule Instance()
        {
            if (aDataModule == null)
            {
                aDataModule = new DataModule();
            }
            return aDataModule;
        }

        #region Public_Members

        public SqlConnection connection = null;
        public SqlCommand command = null;
        public static string connectionString = "";

        public static dkUser dk_user = new dkUser();
        public static dkMasina dk_masina = new dkMasina();
        public static int smena = -1;

        //public ArrayList dkItem_list = new ArrayList();

        private wsItem[] _dkItem_list = null;
        public wsItem[] dkItem_list
        {
            get
            {
                return _dkItem_list;
            }
            set
            {
                _dkItem_list = value;
            }
        }

        public ArrayList dkMasine_list = new ArrayList();
        public Hashtable dkComment_list = new Hashtable();

        EstorageWebServiceBeanService estehWSService = new EstorageWebServiceBeanService(); 

        #endregion
        

        #region Constuctors
        public DataModule()
        {
            /*
            // DEBUG DEBUG DEBUG
            return;
            */

            //dkHashProizvodi.A
            if (connectionString == "")
            {
                connectionString = ConfigurationManager.AppSettings["connectionString"];
            }
            connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch
            {
                MessageBox.Show("Грешка: Сервер базе података није доступан, покушајте поново!");
                //Application.Exit();
                return;
            }

            command = new SqlCommand();
            
        }

        public bool PrihvatiPaleteUMagacin(wsPalletBarCode[] pallet_list)
        {
            try
            {
                palletBarCodeWsWrapper barcodeWsWrapper = estehWSService.acceptBarCode(pallet_list);
                if (barcodeWsWrapper.resultStatus.returnCode == wsReturnCode.OK)
                {
                    //dkItem_list = itemWsWrapper.items;
                    //itemWsWrapper = EsCache.Instance.estehWSService.getItemWithCode(userInfo, itemWsWrapper.items[0].code);
                }
            }
            catch
            {

                MessageBox.Show("Грешка у комуникацији, покушајте поново!");
                return false;
            }
            return true;
        }

        public DataModule(string conn_string)
        {
            string local_connectionString = conn_string;
            connection = new SqlConnection(local_connectionString);
            command = new SqlCommand();
        }

        public DataModule(string host, string userId, string password)
        {
            string local_connectionString = "Data Source=" + host + 
                ";Network Library=DBMSSOCN;Initial Catalog=DonKafa_Proizvodnja;User ID=" 
                + userId + ";Password=" + password;

            connection = new SqlConnection(local_connectionString);
            command = new SqlCommand();
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (command != null)
            {
                command.Cancel();
                command.Dispose();
            }
            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
            }
        }
        #endregion

        #region Published_Members
        public SqlCommand getCommand(string sqlString)
        {
            command.Connection = connection;
            command.CommandText = sqlString;
            return command;
        }

        public SqlDataReader getReader(SqlCommand command)
        {
            return command.ExecuteReader();
        }
        #endregion

        public int UzmiNoviBrojPalete()
        {
            int _result = 0;
            SqlCommand read_command = getCommand("select Max (BrojPalete) as Broj from Paletizacija");
            SqlDataReader reader = read_command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    _result = (int)reader["Broj"];

                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

            ++_result;
            return _result;
        }

        public static void saveSmena(int smena)
        {

            // Open App.Config of executable
            System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings["smena"].Value = smena + "";

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");

            DataModule.smena = smena;
        }

        public static int readSmena()
        {
            try
            {
                DataModule.smena = int.Parse(ConfigurationManager.AppSettings["smena"]);
            }
            catch
            {
                DataModule.smena = 0;
            }
            if (DataModule.smena < 0)
            {
                DataModule.smena = 0;
            }
            return DataModule.smena;
        }

        public int UzmiReceptZaPakovanjeSirovine( int SifraSirovine )
        {
            int _result = 0;
            SqlCommand read_command = getCommand("select SifraRecepta from ReceptSastojak where SifraSirovine = " 
                  + SifraSirovine + " and SifraRecepta in "
                  + "(select SifraRecepta from Recept where Aktivan = 1 and ProizvodRecepta in "            
                  + "(select SifraSirovine from Sirovina where TipSirovine = " + dkConstants.TS_PAKOVANJE + "))");

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    _result = (int)reader["SifraRecepta"];

                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            
            }

            return _result;
        }

        public int UzmiSifruProizvodaRecepta(int SifraRecepta)
        {
            int _result = 0;
            
            SqlCommand read_command = getCommand("select * from Recept where SifraRecepta = " + SifraRecepta);
            SqlDataReader reader = read_command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    _result = (int)reader["ProizvodRecepta"];
                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            
            }

            return _result;
        }

        public double UcitajReceptKolicinu(int SifraRecepta)
        {
            double _result = 0;

            SqlCommand read_command = getCommand("select * from Recept where SifraRecepta = " + SifraRecepta);
            SqlDataReader reader = read_command.ExecuteReader();

            try
            {

                if (reader.Read())
                {
                    _result = (double)reader["KolicinaProizvoda"];
                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            
            }
            return _result;
        }

        public double UcitajReceptSastojakKolicinu(int SifraRecepta, int SifraSirovine)
        {
            double _result = 0;

            SqlCommand read_command = getCommand("select * from ReceptSastojak where SifraRecepta = "
                                        + SifraRecepta + " and SifraSirovine = " + SifraSirovine);

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    _result = (double)reader["Kolicina"];
                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            
            }
            return _result;
        }

        public int IzracunajSpakovanuKolicinuUnazad (int nSifraRecepta, int nSifraSirovine, double  KolicinaSirovine)
        {
            int _result = 0;
            double recept_kolicina = UcitajReceptKolicinu(nSifraRecepta);
            double recept_sastojak_kolicina = UcitajReceptSastojakKolicinu(nSifraRecepta, nSifraSirovine);
            
            if (recept_sastojak_kolicina == 0) 
            {
                return 0;
            }

            _result = (int)(KolicinaSirovine * recept_sastojak_kolicina / recept_kolicina);

            return _result;
        }

        public bool UcitajPodatkeOperacije(ref dkOperacija Operacija)
        {
           // DateTime Datum, int Smena, int SifraMasine, int SifraRadnika, int SifraRecepta, 

            SqlCommand read_command = new SqlCommand(            
                "select * from Operacija where Datum = @p1 and Smena = @p2 and SifraMasine = @p3 and "
                + "SifraRadnika = @p4 and SifraRecepta = @p5 and Komitovano = 0", connection);

            read_command.Parameters.Add("@p1", SqlDbType.DateTime).Value = Operacija.Datum;
            read_command.Parameters.Add("@p2", SqlDbType.Int).Value = Operacija.Smena;
            read_command.Parameters.Add("@p3", SqlDbType.Int).Value = Operacija.SifraMasine;
            read_command.Parameters.Add("@p4", SqlDbType.Int).Value = Operacija.SifraRadnika;
            read_command.Parameters.Add("@p5", SqlDbType.Int).Value = Operacija.SifraRecepta;

            read_command.Prepare();

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    Operacija.SifraOperacije = (int)reader["SifraOperacije"];
                    Operacija.SifraRecepta = (int)reader["SifraRecepta"];
                    Operacija.SifraMasine = (int)reader["SifraMasine"];
                    Operacija.SifraRadnika = (int)reader["SifraRadnika"];
                    Operacija.Smena = (int)reader["Smena"];
                    Operacija.Datum = (DateTime)reader["Datum"];
                    Operacija.SifraSirovine = (int)reader["SifraSirovine"];
                    Operacija.KolicinaProizvoda = (double)reader["KolicinaProizvoda"];
                    Operacija.ProcenatNorme = (int)reader["ProcenatNorme"];
                    Operacija.Proizvedeno = (double)reader["Proizvedeno"];
                    Operacija.Primedba = ((string)reader["Primedba"]).Trim();
                    Operacija.Komitovano = 0;// (int)((double)reader["Komitovano"]);

                    return true;
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

            return false;
        }

        public bool UcitajPodatkeOperacije(ref dkOperacija Operacija, int SifraOperacije)
        {
            // DateTime Datum, int Smena, int SifraMasine, int SifraRadnika, int SifraRecepta, 

            SqlCommand read_command = getCommand(
                "select * from Operacija where SifraOperacije = " + SifraOperacije);

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    Operacija.SifraOperacije = (int)reader["SifraOperacije"];
                    Operacija.SifraRecepta = (int)reader["SifraRecepta"];
                    Operacija.SifraMasine = (int)reader["SifraMasine"];
                    Operacija.SifraRadnika = (int)reader["SifraRadnika"];
                    Operacija.Smena = (int)reader["Smena"];
                    Operacija.Datum = (DateTime)reader["Datum"];
                    Operacija.SifraSirovine = (int)reader["SifraSirovine"];
                    Operacija.KolicinaProizvoda = (double)reader["KolicinaProizvoda"];
                    Operacija.ProcenatNorme = (int)reader["ProcenatNorme"];
                    Operacija.Proizvedeno = (double)reader["Proizvedeno"];
                    Operacija.Primedba = ((string)reader["Primedba"]).Trim();
                    Operacija.Komitovano = 0;// (int)((double)reader["Komitovano"]);

                    return true;
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

            return false;
        }

        public int UzmiNoviBrojOperacije(int SifraRecepta)
        {
            int _result = 0;
            SqlCommand read_command = getCommand("select Max(SifraOperacije) as Broj from Operacija where SifraRecepta = " + SifraRecepta);
            SqlDataReader reader = read_command.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    _result = (int)reader["Broj"];

                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
            }

            return _result;
        }

        public bool ObrisiSastojkeOperacije (int SifraOperacije)
        {
            bool _result = false;
            SqlCommand exe_command = getCommand("delete from OperacijaSastojak where SifraOperacije = " + SifraOperacije);

            try
            {
                exe_command.ExecuteNonQuery();
                _result = true;
            }
            catch
            {
                _result = false;
            }


            return _result;
        }


        public bool KreirajSastojke(int SifraOperacije/*, int SifraRecepta*/)
        {
            bool _result = true;

            dkOperacija sOperacija = new dkOperacija();
            sOperacija.SifraOperacije = SifraOperacije;

            UcitajPodatkeOperacije(ref sOperacija, SifraOperacije);
            double KolicinaProizvoda = UcitajReceptKolicinu(sOperacija.SifraRecepta);


            SqlCommand read_command = new SqlCommand(
                   "select rs.SifraSirovine, rs.Kolicina, IsNull (os.SifraOS, -1) as SifraOS, IsNull (os.PotrosenoSirovine, -1) as PotrosenoSirovine "
                 + "from ReceptSastojak rs left join OperacijaSastojak os "
                 + "on rs.SifraSirovine = os.SifraSirovine and os.SifraOperacije = " + SifraOperacije
                 + " where rs.SifraRecepta = " + sOperacija.SifraRecepta + " order by SifraRD", connection);

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {

                dkOperacijaSastojak sOperacijaSastojak = new dkOperacijaSastojak();
                while (reader.Read())
                {
                    sOperacijaSastojak.SifraOS = (int)reader["SifraOS"];
                    sOperacijaSastojak.SifraOperacije = SifraOperacije;
                    sOperacijaSastojak.SifraSirovine = (int)reader["SifraSirovine"];
                    if (sOperacija.Proizvedeno == 0) 
                        sOperacijaSastojak.KolicinaSirovine = 0;
                    else
                        sOperacijaSastojak.KolicinaSirovine = sOperacija.Proizvedeno * (double) reader["Kolicina"] / KolicinaProizvoda;

                    sOperacijaSastojak.PotrosenoSirovine = sOperacijaSastojak.KolicinaSirovine;

                    SnimiOperacijaSastojak (sOperacijaSastojak);

                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
                read_command.Dispose();

            }
            
            return _result;
        }

        public bool SnimiOperacijaSastojak (dkOperacijaSastojak sOperacijaSastojak)
        {

            SqlConnection conn = new SqlConnection(DataModule.connectionString);
            conn.Open();

            string str_sql = "";
            if (sOperacijaSastojak.SifraOS > 0)
            {
                 str_sql = "update OperacijaSastojak set SifraOperacije = " + sOperacijaSastojak.SifraOperacije + ", "
                 + "  SifraSirovine = " + sOperacijaSastojak.SifraSirovine + ", "
                 + "  KolicinaSirovine = " + String.Format("{0:0.000000}",  sOperacijaSastojak.KolicinaSirovine) + 
                 ", PotrosenoSirovine = " + String.Format("{0:0.000000}", sOperacijaSastojak.PotrosenoSirovine)
                 + "  where SifraOS = " + sOperacijaSastojak.SifraOS;

            }
            else
            {

                 str_sql =  "insert into OperacijaSastojak (SifraOperacije, SifraSirovine, KolicinaSirovine, PotrosenoSirovine) values ("
                 +    sOperacijaSastojak.SifraOperacije + ", " + sOperacijaSastojak.SifraSirovine + ", "
                 +    String.Format("{0:0.000000}", sOperacijaSastojak.KolicinaSirovine) + ", " 
                 +  String.Format("{0:0.000000}",  sOperacijaSastojak.PotrosenoSirovine) + ") ";

            }

            SqlCommand exe_command = new SqlCommand(str_sql, conn);
            

            try
            {
                exe_command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                string str = e.ToString();
                exe_command.Dispose();
                conn.Close();
                return false;
            }

            exe_command.Dispose();
            conn.Close();
            return true;
        }


        public bool SnimiOperaciju (ref dkOperacija Operacija)
        {
            
            string str_sql = "";

            if (Operacija.SifraOperacije > 0)
            {
                str_sql = "update Operacija set SifraRecepta = @p1, SifraMasine = @p2, SifraRadnika = @p3, Smena = @p4, " 
                        + "SifraSirovine = @p5, Datum = @p6, KolicinaProizvoda = @p7, ProcenatNorme =  @p8, "
                        + "Proizvedeno = @p9, Primedba = @p10 where SifraOperacije = " + Operacija.SifraOperacije;
            }
            else
            {
                str_sql = 
                    "Insert into Operacija (SifraRecepta, SifraMasine, SifraRadnika, Smena, SifraSirovine, Datum, KolicinaProizvoda, ProcenatNorme, Proizvedeno, Primedba, Komitovano ) "
                    + "values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, 0)";
            }


            SqlCommand exe_command = new SqlCommand(str_sql, connection);



            try
            {

                SqlParameter p1 = new SqlParameter("@p1", SqlDbType.Int); 
                p1.Value = Operacija.SifraRecepta;
                SqlParameter p2 = new SqlParameter("@p2", SqlDbType.Int);
                p2.Value = Operacija.SifraMasine;
                SqlParameter p3 = new SqlParameter("@p3", SqlDbType.Int);
                p3.Value = Operacija.SifraRadnika;
                SqlParameter p4 = new SqlParameter("@p4", SqlDbType.Int);
                p4.Value = Operacija.Smena;
                SqlParameter p5 = new SqlParameter("@p5", SqlDbType.Int);
                p5.Value = Operacija.SifraSirovine;
                SqlParameter p6 = new SqlParameter("@p6", SqlDbType.DateTime);
                p6.Value = Operacija.Datum;
                SqlParameter p7 = new SqlParameter("@p7", SqlDbType.Float);
                p7.Value = Operacija.KolicinaProizvoda;
                SqlParameter p8 = new SqlParameter("@p8", SqlDbType.Int);
                p8.Value = Operacija.ProcenatNorme;
                SqlParameter p9 = new SqlParameter("@p9", SqlDbType.Float);
                p9.Value = Operacija.Proizvedeno;
                SqlParameter p10 = new SqlParameter("@p10", SqlDbType.Char, 255);
                p10.Value = Operacija.Primedba;

                exe_command.Parameters.Add(p1);
                exe_command.Parameters.Add(p2);
                exe_command.Parameters.Add(p3);
                exe_command.Parameters.Add(p4);
                exe_command.Parameters.Add(p5);
                exe_command.Parameters.Add(p6);
                exe_command.Parameters.Add(p7);
                exe_command.Parameters.Add(p8);
                exe_command.Parameters.Add(p9);
                exe_command.Parameters.Add(p10);

                exe_command.Prepare();
                exe_command.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                string st = e.ToString();
                return false;
            }
            
            exe_command.Dispose();

            if (Operacija.SifraOperacije <= 0)
            {
                Operacija.SifraOperacije = UzmiNoviBrojOperacije(Operacija.SifraRecepta); 
            }

            return true;
        }

        public bool login(string username, string password)
        {
            /*
            // DEBUG DEBUG DEBUG
            DataModule.dk_user.id = 11;
            DataModule.dk_user.ime_prezime = "xxx yyy";
            return true;
             * */

            SqlCommand read_command = getCommand("select * from Radnik where Username = '"
                                                + username + "' and Lozinka = '" + password + "'");

            SqlDataReader reader = read_command.ExecuteReader();

            try
            {

                if (reader.Read())
                {
                    DataModule.dk_user.id = (int)reader["SifraRadnika"];
                    DataModule.dk_user.grupa_id = (int)reader["KorisnickaGrupa"];
                    DataModule.dk_user.ime_prezime = (string)reader["ImePrezime"];
                    DataModule.dk_user.username = (string)reader["Username"];
                    DataModule.dk_user.password = (string)reader["Lozinka"];
                    
                    return true;
                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            
            }
            return false;
        }

        public bool SnimiPaletu(dkPaletaInfo paleta)
        {
            bool _result = true;
            if (paleta.Status == 0)
            {
                paleta.Status = dkConstants.SP_STAMPANO;

                SqlCommand exec_command = getCommand(
                    "insert into Paletizacija (BrojPalete, SifraSirovine, MasaNaPaleti, MasaUKartonu, BrojKartonaNaPaleti, "
                    + "SifraOperacijePakovanje, SifraOperacijePaleta, Status) values ("
                    + paleta.broj_palete + ", " + paleta.item_id + ", "
                    + String.Format("{0:0.000}", paleta.masa_na_paleti) + ", " + String.Format("{0:0.000}", paleta.masa_u_kartonu)
                    + ", " + String.Format("{0:0.000}", paleta.kartona) + ", null, null, " + dkConstants.SP_STAMPANO + ")");

                try
                {
                    exec_command.ExecuteNonQuery();
                }
                catch
                {
                    paleta.Status = 0;
                    _result = false;
                }
            }

            return _result;
        }

        public bool DopuniPaletu(dkPaletaInfo paleta)
        {
            SqlCommand exe_command = getCommand( 
                    "update Paletizacija set Status = " + paleta.Status + ", "
                    + " SifraOperacijePakovanje = " + paleta.SifraOperacijePakovanje + ", "
                    + " SifraOperacijePaleta = " + paleta.SifraOperacijePaleta
                    + " where BrojPalete = " + paleta.broj_palete);

            try
            {
                exe_command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void LoadMasine()
        {
            /*
            // DEBUG DEBUG DEBUG
            dkMasina itemx = new dkMasina();
            itemx.id = 1;
            itemx.NazivMasine = "XXx";
            dkMasine_list.Add(itemx);
            return;
             * */

            dkMasine_list.Clear();

            SqlCommand read_command = getCommand("select * from Masina");
            SqlDataReader reader = read_command.ExecuteReader();

            try
            {

                while (reader.Read())
                {

                    dkMasina item = new dkMasina();
                    try
                    {
                        item.id = (int)reader["SifraMasine"];
                    }
                    catch
                    {
                        item.id = -1;
                    }

                    try
                    {
                        item.NazivMasine = ((string)reader["NazivMasine"]).Trim();
                    }
                    catch
                    {
                        item.NazivMasine = "";
                    }
                    try
                    {
                        item.TipProizvodnje = (int)reader["TipProizvodnje"];
                    }
                    catch
                    {
                        item.TipProizvodnje = 0;
                    }

                    try
                    {
                        item.Primedba = ((string)reader["Primedba"]).Trim();
                    }
                    catch
                    {
                        item.Primedba = "";
                    }

                    dkMasine_list.Add(item);
                }
            }
            finally
            {

                reader.Close();
                reader.Dispose();
            }
        }

        public void LoadItems()
        {

            MessageBox.Show("LOADING ITEMS");
            //dkItem_list.Clear();

            /*
            SqlCommand read_command = getCommand("select * from Sirovina where (AltSifraSirovine like 'P%' or AltSifraSirovine like 'R%') and NazivSirovine not like '%- OLD%' and TipSirovine = " 
                + dkConstants.TS_PROIZVOD + " order by NazivSirovine");
            SqlDataReader reader = read_command.ExecuteReader();

            try
            {

                while (reader.Read())
                {

                    dkItems item = new dkItems();
                    try
                    {
                        item.id = (int)reader["SifraSirovine"];
                    }
                    catch
                    {
                        item.id = -1;
                    }

                    try
                    {
                        item.naziv = ((string)reader["NazivSirovine"]).Trim();
                    }
                    catch
                    {
                        item.naziv = "";
                    }

                    try
                    {
                        item.sifra = ((string)reader["AltSifraSirovine"]).Trim();
                    }
                    catch
                    {
                        item.sifra = "";
                    }

                    try
                    {
                        item.jm = ((string)reader["JM"]).Trim();
                    }
                    catch
                    {
                        item.jm = "";
                    }

                    try
                    {
                        item.barkod = (string)reader["BarCodeProizvoda"];
                    }
                    catch
                    {
                        item.barkod = "";
                    }

                    try
                    {
                        item.masa = (int)(1000 * (double)reader["TezinaPoJM"]);
                    }
                    catch
                    {
                        item.masa = 0;
                    }

                    dkItem_list.Add(item);
                }

            }
            finally
            {

                reader.Close();
                reader.Dispose();

            }
            */

            //wsUserInfo userInfo = EsCommand.getCurrentUser();
            try
            {
                itemWsWrapper itemWsWrapper = estehWSService.getListOfItems(/*userInfo*/);
                if (itemWsWrapper.resultStatus.returnCode == wsReturnCode.OK)
                {
                    dkItem_list = itemWsWrapper.items;
                    //itemWsWrapper = EsCache.Instance.estehWSService.getItemWithCode(userInfo, itemWsWrapper.items[0].code);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Грешка у комуникацији, покушајте поново!");
                return;
            }

            dkComment_list.Clear();

            dkComment cmm_std = new dkComment();
            cmm_std.label = "Стандард";
            cmm_std.comment = "";

            dkComment_list.Add("", cmm_std);


            MessageBox.Show("LOADED: "  + dkItem_list.Length);
            
            foreach (wsItem item in (dkItem_list))
            {
                string item_comment = "";
                if (item.comment != null)
                {
                    item_comment = item.comment.Trim();
                }

                if (!dkComment_list.ContainsKey(item_comment))
                {
                    dkComment cmm = new dkComment();
                    cmm.comment = item_comment;

                    if (item_comment != "")
                    {
                        cmm.label = item_comment;
                        dkComment_list.Add(item_comment, cmm);
                    }
                }

            }

        }

    }

}
