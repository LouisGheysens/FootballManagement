using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BusinessLogic.Model;
using BusinessLogic;
using BusinessLogic.Exceptions;

namespace Testing
{
    public class KlantTest
    {

        private readonly List<Bestelling> _bestellingnPersoon = new();
        private readonly Dictionary<Trui, int> _voetblatruitjeKeys = new();
        private readonly Trui _voetbaltruitje;
        private readonly Club _club;
        private readonly Clubset _clubSet;
        private readonly Klant _klant;
        private readonly Bestelling _bestelling;

        #region KlantConfiguratie
        public KlantTest() {
            _club = new("Jupiler-pro-leauge", "KOS-Olsene");
            _clubSet = new(true, 1);
            _voetbaltruitje = new(1, _club, "Winter", 30, BusinessLogic.Maat.M, _clubSet);
            _voetblatruitjeKeys.Add(_voetbaltruitje, 1);
            _klant = new(1, "Louis Gheysens", "Brouwershoek-1-9870-Olsene", _bestellingnPersoon);
            _bestelling = new(1, _klant, DateTime.Now, 50, false, _voetblatruitjeKeys);
            _bestellingnPersoon.Add(_bestelling);
        }
        #endregion


        [Fact]
        public void Test_ctor_NoId_Valid()
        {
            Klant klantje = new Klant("Louis", "Brouwershoek");

            Assert.Equal("Louis", klantje.Naam);
            Assert.Equal("Brouwershoek", klantje.Adres);
        }

        [Fact]
        public void Test_ctor_Id_Valid()
        {
            Klant klantje = new Klant(1, "Louis", "Brouwershoek");
            Assert.Equal(1, klantje.KlantenNummer);
            Assert.Equal("Louis", klantje.Naam);
            Assert.Equal("Brouwershoek", klantje.Adres);
        }

        [Fact]
        public void Test_ctor_Id_InValid()
        {
            Assert.Throws<KlantException>(() => new Klant(-10, "Louis", "Brouwershoek"));
        }


        [Fact]
        public void Test_ZetId_Valid()
        {
            Klant klantje = (new Klant(1, "Louis", "Brouwershoek"));
            klantje.ZetKlantId(1);
            Assert.Equal(1, klantje.KlantenNummer);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Test_ZetId_InValid(int id)
        {
            Klant klant = new Klant("Louis", "Brouwershoek");
            var ex = Assert.Throws<KlantException>(() => klant.ZetKlantId(id));
            Assert.Equal("Klant: KlantId is onder 1", ex.Message);
        }


        [Fact]
        public void Test_ZetNaam_Valid()
        {
            Klant klantje = (new Klant(1, "Louis", "Brouwershoek"));
            klantje.ZetNaam("Louis");
            Assert.Equal("Louis", klantje.Naam);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_ZetNaam_InValid(string naam)
        {
            Klant klant = new Klant("Louis", "Brouwershoek");
            var ex = Assert.Throws<KlantException>(() => klant.ZetNaam(naam));
            Assert.Equal("Klant: Naam moet langer dan 1 letter zijn!", ex.Message);
        }

        [Fact]
        public void Test_ZetAdres_Valid()
        {
            Klant klantje = (new Klant(1, "Louis", "Brouwershoek"));
            klantje.ZetAdres("Brouwershoek");
            Assert.Equal("Brouwershoek", klantje.Adres);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Test_ZetAdres_InValid(string adres)
        {
            Assert.Throws<KlantException>(() => _klant.ZetAdres(adres));
        }

        [Fact]
        public void Test_HeeftBestelling() {
            Assert.True(_klant.HeeftBestelling(_bestelling));
        }

        [Fact]
        public void Test_VerwijderBestelling() {
            Bestelling bestelling = null;
            Assert.Throws<KlantException>(() => _klant.VerwijderBestelling(bestelling));
        }
    }
}
