using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Paletizer
{
    public class dkMasina
    {
        public int id = -1;
        public string NazivMasine = "";
        public int TipProizvodnje = 0;
        public string Primedba = "";

        public dkMasina()
        {
            id = 27;
            NazivMasine = "PALETIZACIJA";
            TipProizvodnje = 2;
        }

        public override string ToString() 
        {
            return NazivMasine; 
        }

        public void loadDefault()
        {
            try
            {
                this.id = int.Parse(ConfigurationManager.AppSettings["MasinaPaletizacije"]);
            }
            catch
            {
                this.id = -1;
            }
            if (this.id < 0)
            {
                // nece da skodi 
                id = 27;
                NazivMasine = "PALETIZACIJA";
                TipProizvodnje = 2;
            }
        }

        public void saveAsDefault()
        {
            
            // Open App.Config of executable
            System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            // Add an Application Setting.
            config.AppSettings.Settings["MasinaPaletizacije"].Value = this.id + "";

            // Save the changes in App.config file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of a changed section.
            ConfigurationManager.RefreshSection("appSettings");


        }

    }
}
