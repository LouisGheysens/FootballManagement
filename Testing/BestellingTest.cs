using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Model;

namespace Testing
{
    public class BestellingTest
    {

        private readonly Klant _klant;
        private readonly Trui _voetbaltruitje;
        private readonly Dictionary<Trui, int> _voetbaltruitjeKeys = new();
        private readonly Bestelling _bestelling;
        private List<Trui> truitjes = new List<Trui>();

        public BestellingTest() {
            _klant = new(1, "Louis Gheysens", "Brouwershoek-1-9870-Olsene");
            _voetbaltruitje = new(1, new("Jupiler-pro-leauge", "KvvZingem"), "Zomer", 44, BusinessLogic.Maat.M, new(true, 1));
            _voetbaltruitjeKeys.Add(_voetbaltruitje, 1);
            _bestelling = new(1, _klant, DateTime.Now, 40, true, _voetbaltruitjeKeys);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void Test_ctor_noId_InValid(int id)
        {
            Assert.Throws<BestellingException>(() => new Bestelling(id, new Klant(1, "ahmed", "Ronse"), DateTime.Today, new Dictionary<Trui, int>()));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-11)]
        public void Test_ctor_noKlantId_InValid(int klantid)
        {
            Assert.Throws<KlantException>(() => new Bestelling(1, new Klant(klantid, "Louis", "Gheysens"), DateTime.Today, new Dictionary<Trui, int>()));
        }

        [Fact]
        public void Test_ctor_noKlantNaam_InValid()
        {
            Assert.Throws<KlantException>(() => new Bestelling(1, new Klant(1, null, "Olsene"), DateTime.Today, new Dictionary<Trui, int>()));
        }

        [Fact]
        public void Test_ctor_noKlantAdres_InValid()
        {
            Assert.Throws<KlantException>(() => new Bestelling(1, new Klant(1, "Louis", null), DateTime.Today, new Dictionary<Trui, int>()));
        }

        [Theory]
        [InlineData(-0.25)]
        [InlineData(-11)]
        [InlineData(-11.25)]
        public void Test_ctor_noPrijs_InValid(double prijs)
        {
            Assert.Throws<BestellingException>(() => new Bestelling(1, new Klant(1, "Gheysens", "Olsene"), DateTime.Today, prijs, true, new Dictionary<Trui, int>()));
        }

        [Fact]
        public void Test_ZetKlant_Valid()
        {
            Bestelling bestelling = new Bestelling(1, new Klant(1, "Gheysens", "Zingem"), DateTime.Today, 22.5, true, new Dictionary<Trui, int>());
            bestelling.ZetKlant(new Klant("Gheysens", "Zingem"));
            Assert.Equal("Gheysens", bestelling.Klant.Naam);
            Assert.Equal("Zingem", bestelling.Klant.Adres);
        }

        [Fact]
        public void Test_ZetPrijs_Valid()
        {
            Bestelling bestelling = new Bestelling(1, new Klant(1, "Gheysens", "Zingem"), DateTime.Today, 22.5, true, new Dictionary<Trui, int>());
            bestelling.ZetPrijs(22.5);
            Assert.Equal(22.5, bestelling.Prijs);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_ZetId_InValid(int id)
        {
            Bestelling bestelling = new Bestelling(1, new Klant(1, "Louis", "Zulte"), DateTime.Today, 22.5, true, new Dictionary<Trui, int>());
            var ex = Assert.Throws<BestellingException>(() => bestelling.ZetBestellingId(id));
            Assert.Equal("Bestelling: Id klopt niet!", ex.Message);
        }

        [Fact]
        public void Test_ZetKlant_InValid()
        {
            Bestelling bestelling = new Bestelling(1, new Klant(1, "Louis", "Zulte"), DateTime.Today, 22.5, true, new Dictionary<Trui, int>());
            var ex = Assert.Throws<BestellingException>(() => bestelling.ZetKlant(null));
            Assert.Equal("Bestelling - invalid klant", ex.Message);
        }

        [Theory]
        [InlineData(-0.25)]
        [InlineData(-11)]
        [InlineData(-11.25)]
        public void Test_ZetPrijs_InValid(double prijs)
        {
            Bestelling bestelling = new Bestelling(1, new Klant(1, "Gheysens", "Zulte"), DateTime.Today, 22.5, true, new Dictionary<Trui, int>());
            var ex = Assert.Throws<BestellingException>(() => bestelling.ZetPrijs(prijs));
            Assert.Equal("Bestelling - Prijs mag niet kleiner zijn dan 0", ex.Message);
        }

        [Fact]
        public void Test_VoegTruitjeToe_Valid()
        {
            Bestelling b = new Bestelling(DateTime.Now);
            Trui tr = new Trui(12, new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));

            b.VoegTruitjeToe(tr, 1);
            Assert.True(b.GeefProducten().ContainsKey(tr));
        }

        [Theory()]
        [InlineData(null, 0)]
        public void VerwijderProductTest(Trui voetbaltruitje, int aantal) {
            Assert.Throws<BestellingException>(() => _bestelling.VerwijderTruitje(voetbaltruitje, aantal));
        }
    }
}
