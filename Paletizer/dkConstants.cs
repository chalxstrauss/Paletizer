using System;
using System.Collections.Generic;
using System.Text;

namespace Paletizer
{
    class dkConstants
    {
        // Tipovi sirovina
        public static int TS_SVE = 0;
        public static int TS_SIROVINA = 1;
        public static int TS_POLUPROIZVOD = 2;
        public static int TS_PROIZVOD = 3;
        public static int TS_PAKOVANJE = 4;
        public static int TS_POLUPROIZVOD_I_PROIZVOD = 5;
        public static int TS_POLUPROIZVOD_I_PROIZVOD_I_PAKOVANJE = 6;
        public static int TS_SIROVINA_I_POLUPROIZVOD_I_PROIZVOD = 7;
        

        // Magacini
        public static int MAGACIN_PROIZVODNJE = 0;
        public static int MAGACIN_PROIZVODA = 1;

        // Tipovi proizvodnje
        public static int TP_PRZENJE = 0;
        public static int TP_MLEVENJE = 1;
        public static int TP_PAKOVANJE = 2;
        public static int TP_SVE = 4;

        // Smene
        public static int SM_SMENA1 = 1;
        public static int SM_SMENA2 = 2;
        public static int SM_SMENA3 = 3;

        public static int BROJ_SMENA = 3;

        // Tipovi dokumenata
        //TipDokumentaNaziv: Array[0..4] of String = ('Ulaz u magacin', 'Prenos izmeðu magacina', 'Unos poèetnog stanja', 'Zatvaranje stanja smene', 'Unos prodaje');
        public static int TD_ULAZ_U_MAGACIN = 0;
        public static int TD_PRENOS_IZ_MAGACINA = 1;
        public static int TD_POCETNO_STANJE = 2;
        public static int TD_ZATVARANJE_SMENE = 3;
        public static int TD_PRODAJA = 4;


        // Statusi narudzbina
        public static int SN_PLANIRANO = 0;
        public static int SN_NARUCENO = 1;
        public static int SN_ZATVORENO = 2;

        // Grupe korisnika - privremeno do uvodjenja dinamicke evidencije grupa
        public static int GK_ADMIN = 0;
        public static int GK_PALETIZACIJA = 1;
        public static int GK_OSTALI = 2;

        // Privilegije
        public static int PR_PALETIZACIJA = 1;
        public static int PR_MAGACINI = 2;
        public static int PR_MASINE = 3;
        public static int PR_SIROVINE = 4;
        public static int PR_DOBAVLJACI = 5;
        public static int PR_RADNICI = 6;
        public static int PR_GRUPE = 7;
        public static int PR_SIFARNICI = 8;
        public static int PR_DOK_ULAZ_U_MAGACIN = 9;
        public static int PR_DOK_PRENOS_IZ_MAGACINA = 10;
        public static int PR_DOK_POCETNO_STANJE = 11;
        public static int PR_DOK_ZATVARANJE_SMENE = 12;
        public static int PR_DOK_UNOS_PRODAJE = 13;
        public static int PR_DOK_BRISANJE = 14;
        public static int PR_DOKUMENTI = 15;
        public static int PR_RECEPTI = 16;
        public static int PR_PRO_UNOS = 17;
        public static int PR_PRO_ZATVARANJE_SMENE = 18;
        public static int PR_PRO_BRISANJE = 19;
        public static int PR_PROIZVODNJA = 20;
        public static int PR_IZVESTAJI = 21;
        public static int PR_PLAN_UNOS_PROIZVODNJE = 22;
        public static int PR_PLAN_UNOS_NABAVKE = 23;
        public static int PR_PLAN_PROMENA_PORUDZBINE = 24;
        public static int PR_PLAN_BRISANJE_PORUDZBINE = 25;
        public static int PR_PLANIRANJE = 26;
        
        // Paletizacija
        public static int SP_STAMPANO = 1;
        public static int SP_GOTOVO = 2;


    }
}
