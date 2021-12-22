using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Model;
using System;
using Xunit;

namespace Testing
{
    public class TruiTest
    {
        private readonly Trui _voetbaltruitje = new(1, new("Competitie", "Ploeg"), "Winter", 60, Maat.L, new(true, 1));

        [Fact]
        public void Test_ctor_NoId_Valid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.PloegNaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Maat.M, truitje.Kledingmaat);
            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);
        }

        [Fact]
        public void Test_ctor_Id_Valid()
        {
            Trui truitje = new Trui(10, new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Assert.Equal(10, truitje.Id);
            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("city", truitje.Club.PloegNaam);
            Assert.Equal("2021-2022", truitje.Seizoen);
            Assert.Equal(87, truitje.Prijs);
            Assert.Equal(Maat.M, truitje.Kledingmaat);
            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);
        }

        [Fact]
        public void Test_ctor_Id_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(-10, new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClub_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(null, "2021-2022", 87, Maat.M, new Clubset(true, 1)));
        }
        [Fact]
        public void Test_ctor_Id_noClubSet_InValid()
        {
            Assert.Throws<TruiException>(() => new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, null));
        }

         [Fact]
         public void Test_ZetId_Valid()
         {
            Trui trui = new Trui(new Club("Premier Leauge", "city" ),
                "2021-2022", 87, Maat.M, new Clubset(true, 1));
            trui.ZetId(1);
            Assert.Equal(1, trui.Id);
         }   

        [Fact]
        public void Test_ZetPrijs_Valid()
        {
            Trui truitje = new Trui(new Club("Premier leauge", "city"), "2021_2022", 87, Maat.M, new Clubset(true, 1));
            truitje.ZetPrijs(10.5);
            Assert.Equal(10.5, truitje.Prijs);
        }

        [Theory]
        [InlineData(-10.5)]
        [InlineData(-0.5)]
        [InlineData(0)]
        public void Test_ZetPrijs_InValid(double prijs)
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            var ex = Assert.Throws<TruiException>(() => truitje.ZetPrijs(prijs));
            Assert.Equal("Prijs is lager dan 0", ex.Message);

        }

        [Fact]
        public void Test_ZetClub_ValidReference()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);
            Assert.Equal(club, truitje.Club);
        }


        [Fact]
        public void Test_ZetClub_ValidValue()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Club club = new Club("premier league", "Leicester");
            truitje.ZetClub(club);

            Assert.Equal("premier league", truitje.Club.Competitie);
            Assert.Equal("Leicester", truitje.Club.PloegNaam);
        }

        [Fact]
        public void Test_ZetClub_INvalid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Assert.Throws<TruiException>(() => truitje.ZetClub(null));
        }

        [Fact]
        public void Test_ZetClubSet_ValidReference()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Clubset clubset = new Clubset(true, 1);
            truitje.ZetClubSet(clubset);
            Assert.Equal(clubset, truitje.ClubSet);
        }


        [Fact]
        public void Test_ZetClubSet_ValidValue()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Clubset clubset = new Clubset(true, 1);
            truitje.ZetClubSet(clubset);

            Assert.True(truitje.ClubSet.Thuis);
            Assert.Equal(1, truitje.ClubSet.Versie);

        }


        [Fact]
        public void Test_ZetClubSet_InValid()
        {
            Trui truitje = new Trui(new Club("premier league", "city"), "2021-2022", 87, Maat.M, new Clubset(true, 1));
            Assert.Throws<TruiException>(() => truitje.ZetClubSet(null));
        }


    }
}
