using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    public class dkItems
    {
        public int id = 0;
        public string naziv = "";
        public string sifra = "";
        public string jm = "";
        public string barkod = "";
        public int masa = 0;

        public dkItems()
        {
        }

        public override string ToString() 
        {
            return naziv; 
        }

    }
}
