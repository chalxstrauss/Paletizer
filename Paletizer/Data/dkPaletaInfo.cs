using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    public class dkPaletaInfo
    {
        public int item_id = 0;
        public int broj_palete = -1;
        public double masa_na_paleti = 0;
        public double masa_u_kartonu = 0;
        public int kartona = 0;

        public string proizvod_naziv = "";
        public string proizvod_sifra = "";

        public string datum_vreme = "";
        public string jm = "";
        public int masa = 0;

        public string barkod_palete = "";
        public DateTime datum = DateTime.Now;

        public int SifraOperacijePakovanje = -1;
        public int SifraOperacijePaleta = -1;

        public int SifraReceptaZaPakovanje = -1;
        public int SifraReceptaZaPaletu = -1;
        public int ItemPackageCount = 1;

        public string proizvod_barkod = "";
        public string proizvod_barkod_pak = "";

        public int Status = 0;

        public void reset()
        {
            item_id = 0;
            broj_palete = -1;
            masa_na_paleti = 0;
            masa_u_kartonu = 0;
            kartona = 0;

            proizvod_naziv = "";
            proizvod_sifra = "";

            datum_vreme = "";

            barkod_palete = "";
            datum = DateTime.Now;

            SifraOperacijePakovanje = -1;
            SifraOperacijePaleta = -1;

            SifraReceptaZaPakovanje = -1;
            SifraReceptaZaPaletu = -1;

            ItemPackageCount = 1;

            Status = 0;

            jm = "";
            masa = 0;

        }

        public void create_barcode()
        {
            string item_code = proizvod_sifra.Trim();
            item_code = item_code.Replace(" ", "");
            long box_count = kartona;

            string enc_date = Base36.encodeBase36(long.Parse(datum.ToString(AppFormats.dateTimeFormat_code)));
            string enc_box_count = Base36.encodeBase36(box_count);

            barkod_palete = enc_date + "-" + item_code + "-" + enc_box_count;
        }


    }
}
