using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    public class dkOperacija
    {
        public int SifraOperacije = -1;
        public int SifraRecepta = 0;
        public int SifraMasine = 0;
        public int SifraRadnika = 0;
        public int Smena = 0;

        public DateTime Datum = new DateTime();

        public int SifraSirovine = 0;
        public double KolicinaProizvoda = 0;
        public int ProcenatNorme = 100;
        public double Proizvedeno = 0;
        public string Primedba  = "";
        public int Komitovano = 0; // 0, 1

    }
}
