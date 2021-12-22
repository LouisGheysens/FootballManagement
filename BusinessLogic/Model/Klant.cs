using System;
using System.Collections.Generic;
using BusinessLogic.Exceptions;
using System.Linq;
using BusinessLogic.Interface;

namespace BusinessLogic
{
    public class Klant : IKlant
    {
        public int KlantenNummer { get; private set; }

        public string Naam { get; private set; }

        public string Adres { get; private set; }

        private List<Bestelling> _bestellingen = new List<Bestelling>();

        public Klant(int klantid, string naam, string adres, List<Bestelling> _bestellingen)
        {
            this.KlantenNummer = klantid;
            this.Naam = naam;
            this.Adres = adres;
            this._bestellingen = _bestellingen;
        }

        public Klant(int nummer, string naam, string adres) : this(naam, adres)
        {
            ZetKlantId(nummer);
            ZetNaam(naam);
            ZetAdres(adres);
        }


        public Klant(string naam, string adres)
        {
            ZetNaam(naam);
            ZetAdres(adres);
        }

        public Klant(string naam) {
            ZetNaam(naam);
        }

        public int GeefKorting()
        {
            switch (_bestellingen.Count) {
                case < 5:
                    return 0;
                case < 10:
                    return 10;
                default:
                    return 20;
            }
        }

        public void ZetKlantId(int id)
        {
            if (id <= 0) throw new KlantException("Klant: KlantId is onder 1");
            this.KlantenNummer = id;
        }

        public void ZetAdres(string adres)
        {
            if (string.IsNullOrWhiteSpace(adres)) throw new KlantException("Klant: Adres is leeg!");
            this.Adres = adres;
        }

        public void ZetNaam(string naam)
        {
            if (string.IsNullOrWhiteSpace(naam)) throw new KlantException("Klant: Naam moet langer dan 1 letter zijn!");
            Naam = naam;
        }

        public IReadOnlyList<Bestelling> ToonBestelling()
        {
            return _bestellingen;
        }

        public bool HeeftBestelling(Bestelling bestelling) {
            switch (_bestellingen.Count) {
                case > 1:
                    return true;
                default:
                    return false;
            }
        }

        public void VerwijderBestelling(Bestelling bestelling) {
            if (_bestellingen.Count <= 0) throw new KlantException("Klant: VerwijderBestelling - bestelling is leeg!");
            _bestellingen.Remove(bestelling);
        }

        public void VoegBestellingToe(Bestelling bestelling) {
            _bestellingen.Add(bestelling);
        }

        public string ToText(bool kort = true) {
            if (kort)
                return $"[Klant] {KlantenNummer}\n{Naam}\n{Adres}\n{_bestellingen.Count}";
            else {
                string prbr = $"[Klant] {KlantenNummer}\n{Naam}\n{Adres}\n{_bestellingen.Count}";
                foreach (var r in _bestellingen) {
                    prbr += $"\n{r}";
                }
                return prbr;
            }
        }

        public override string ToString()
        {
            return $"KlantenNummer: {KlantenNummer}\nNaam: {Naam}\nAdres: {Adres}";
        }

        public override bool Equals(object obj)
        {
            return obj is Klant klant &&
                   KlantenNummer == klant.KlantenNummer &&
                   Naam == klant.Naam &&
                   Adres == klant.Adres &&
                   EqualityComparer<List<Bestelling>>.Default.Equals(_bestellingen, klant._bestellingen);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(KlantenNummer, Naam, Adres, _bestellingen);
        }
    }
}
