using System;
using System.Text;
using BusinessLogic;
using BusinessLogic.Manager;
using DataLaag.Repos;

namespace Console {
    class Program {
        static void Main(string[] args) {

            KlantManager km = new KlantManager(new KlantRepository());

            Klant k = new Klant("NonkelLoewis", "Loewislaan-90-2221-Oorden");

            km.voegKlantToe(k);
            km.updateKlant(k);

        }
    }
}
