using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IBestellingRepository
    {
        void VoegBestellingToe(Bestelling bestelling);
        bool BestaatBestelling(Bestelling bestelling);
        bool BestaatBestelling(int id);
        void UpdateBestelling(Bestelling bestelling);
        void VerwijderBestelling(Bestelling bestelling);
        Bestelling GeefBestelling(int id);
        IReadOnlyList<Bestelling> ZoekBestellingen(int? bestellingid, DateTime? startDatum, DateTime? einddatum, Klant k);
        Dictionary<Trui, int> GetInhoudBestelling(int id);



    }
}
