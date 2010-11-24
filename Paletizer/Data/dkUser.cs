using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    public class dkUser
    {

        public int id = 0;
        public string ime_prezime = "";
        public string username = "";
        public string password = "";
        public int grupa_id = 0;

        public dkUser()
        {
        }

        public override string ToString() 
        {
            return ime_prezime; 
        }
    }
}
