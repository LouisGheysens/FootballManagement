using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface {
    public interface IKlantRepository {
        bool bestaatKlant(Klant Klant);
        bool bestaatKlant(int id);
        Klant voegKlantToe(Klant klant);
        void verwijderKlant(Klant klant);
        void updateKlant(Klant klant);
        List<Klant> KlantWeergeven(int id, string naam, string adres);
    }
}
