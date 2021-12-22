using System;
using System.Collections.Generic;

namespace BusinessLogic
{
    public interface IBestelling
    {
        int BestelNummer { get; }
        bool Betaald { get; }
        Klant Klant { get; }
        DateTime OrderDatum { get; }
        double Prijs { get; set; }

        IReadOnlyDictionary<Trui, int> GeefAantalProducten();
        IReadOnlyDictionary<Trui, int> GeefProducten();
        double KostPrijs();
        string ToString();
        void VerwijderKlant();
        void VerwijderTruitje(Trui trui, int aantal);
        void VoegTruitjeToe(Trui trui, int aantal);
        bool ZetBetaald(bool betaald);
        void ZetKlant(Klant newKlant);
    }
}