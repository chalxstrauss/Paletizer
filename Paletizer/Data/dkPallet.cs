using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace Paletizer
{
    public class dkPallet
    {
        public DateTime dateTime = DateTime.Now;
        public string barcode = "";
        public string item_code = "";
        public string jm = "";
        public string kolicina = "";
        public string masina = "";
        public string broj_kutija = "";

        public int pallet_status = 0;// 0 - ok, 1 - NOK

        public static string getPaleteFile()
        {
            string filePath =
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                + "\\palleteList.txt";

            filePath = filePath.Replace("file://", "");
            filePath = filePath.Replace("file:\\", "");
            return filePath;
        }

        public static string getWarehouseFile()
        {
            string filePath =
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                + "\\storageList.txt";

            filePath = filePath.Replace("file://", "");
            filePath = filePath.Replace("file:\\", "");
            return filePath;
        }

        public static string getProbatFile()
        {
            string epath = "";
            try
            {
                epath = ConfigurationManager.AppSettings["exchange_path"];
            }
            catch
            {
            }
            return epath;
        }

        public static bool probatCanUserLogin()
        {
            try
            {
                if (ConfigurationManager.AppSettings["proizvodnja"] == "true" && 
                    ConfigurationManager.AppSettings["probat_test"] != "true")
                {
                    string p_path = dkPallet.getProbatFile();
                    if (File.Exists(p_path))
                    {
                        MessageBox.Show("Упозорење:\r\nПробатов фајл још није преузет, покушајте поново по завршетку преузимања!");
                        return false;
                    }
                }
            }
            catch
            {
                //
            }
            return true;
        }

        public static string getProbatFileTemp()
        {
            string filePath =
                Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
                + "\\probat_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";

            filePath = filePath.Replace("file://", "");
            filePath = filePath.Replace("file:\\", "");
            return filePath;
        }

        public static bool removePalletFile()
        {
            string epath = dkPallet.getPaleteFile();
            try
            {
                if (File.Exists(epath))
                {
                    File.Delete(epath);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool MoveProbatFile()
        {
            string w_path = dkPallet.getWarehouseFile();
            string p_path = "";

            if (ConfigurationManager.AppSettings["probat_test"] == "true")
            {
                p_path = dkPallet.getProbatFileTemp();
            } 
            else
            {
                p_path = dkPallet.getProbatFile();
            }
            
            if (!File.Exists(w_path))
            {
                // nema fajla za prenos
                MessageBox.Show("Инфо: Нема података за пренос у ПРОБАТ, можете наставите са радом.");
                return false;
            }
            
            if (File.Exists(p_path))
            {
                MessageBox.Show("Није могуће направити пренос, пробатов претходни фајл још увек није преузет!");
                // nedozvoljeno je pregaziti prethodni probatov fajl
                return false;
            }

            try
            {
                File.Move(w_path, p_path);
            }
            catch
            {
                MessageBox.Show("Грешка приликом преноса фајла, покушајте поново!");
                return false;
            }

            try
            {
                File.Delete(w_path);
            }
            catch
            {
                MessageBox.Show("Упозорење - пријавите администратору:\r\nније могуће избрисати фајл: " + w_path);
                // ignore ?
                //return false;
            }

            return true;
        }


        // datetime | barcode | item_code | pallet_status
        public bool Parse(string line)
        {
            int index = 0;
            foreach (string str_read in line.Split('|'))
            {
                string str = str_read.Trim();
                switch (index)
                {
                    case 0:
                        try
                        {
                            dateTime = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", null);
                        }
                        catch
                        {
                        }
                        break;

                    case 1:
                        barcode = str;
                        break;

                    case 2:
                        item_code = str;
                        break;

                    case 3:
                        jm = str;
                        break;

                    case 4:
                        kolicina = str;
                        break;

                    case 5:
                        masina = str;
                        break;

                    case 6:
                        broj_kutija = str;
                        break;

                    case 7:
                        try
                        {
                            pallet_status = int.Parse(str);
                        }
                        catch
                        {
                            pallet_status = 0;
                        }
                        break;

                    default:
                        break;
                }
                ++index;
            }

            return (index > 5);
        }

        // datetime | barcode | item_code | pallet_status
        public static bool SaveLine(DateTime dt, string bcode, string icode, string sjm, string skolicina, string smasina,
                                    string sbroj_kutija, int status )
        {

            string filePath = dkPallet.getPaleteFile();

            StreamWriter sw = null;
            try
            {
                if (File.Exists(filePath))
                {
                    sw = File.AppendText(filePath);
                }
                else
                {
                    sw = File.CreateText(filePath);
                }
            }
            catch
            {
                return false;
            }

            string line = dt.ToString("yyyy-MM-dd HH:mm:ss") + "|" +
                          bcode.Trim() + "|" +
                          icode.Trim() + "|" +
                          sjm.Trim() + "|" +
                          skolicina.Trim() + "|" +
                          smasina.Trim() + "|" +
                          sbroj_kutija.Trim() + "|" +
                          status + "";

            try
            {
                sw.WriteLine(line);
            }
            catch
            {
                return false;
            }

            try
            {
                if (sw != null) sw.Close();
            }
            finally
            {
                sw = null;
            }

            return true;
        }

        // datetime | barcode | item_code | pallet_status
        public bool saveToLocalProbat()
        {

            string filePath = dkPallet.getWarehouseFile();

            StreamWriter sw = null;
            try
            {
                if (File.Exists(filePath))
                {
                    sw = File.AppendText(filePath);
                }
                else
                {
                    sw = File.CreateText(filePath);
                }
            }
            catch
            {
                return false;
            }

            string line = dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "," +
                          barcode.Trim() + "," +
                          item_code.Trim() + "," +
                          jm.Trim() + "," +
                          kolicina.Trim().Replace(",", ".") + "," +
                          masina.Trim() + "";

            try
            {
                sw.WriteLine(line);
            }
            catch
            {
                return false;
            }

            try
            {
                if (sw != null) sw.Close();
            }
            finally
            {
                sw = null;
            }

            return true;
        }

        // datetime | barcode | item_code | pallet_status
        public override string ToString()
        {
            string line = dateTime.ToString("yyyy-MM-dd HH:mm:ss") + "|" +
                          barcode.Trim() + "|" +
                          item_code.Trim() + "|" +
                          jm.Trim() + "|" +
                          kolicina.Trim() + "|" +
                          masina.Trim() + "|" +
                          broj_kutija.Trim() + "|" +
                          pallet_status + "";
            return line;
        }

    }
}
