using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IKlant
    {
        string Adres { get; }
        int KlantenNummer { get; }
        string Naam { get; }

        bool Equals(object obj);
        int GeefKorting();
        int GetHashCode();
        string ToString();
        void ZetAdres(string adres);
        void ZetKlantId(int id);
        void ZetNaam(string naam);
    }
}