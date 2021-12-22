using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;
using BusinessLogic.Interface;
using BusinessLogic.Model;

namespace BusinessLogic
{
    public class Trui: ITrui
    {
        public Trui(int id, Club club, string seizoen, double prijs, Maat kledingmaat, Clubset clubset)
        {
            ZetId(id);
            ZetClub(club);
            ZetPrijs(prijs);
            Seizoen = seizoen;
            Kledingmaat = kledingmaat;
            ZetClubSet(clubset);
        }
        public Trui(Club club, string seizoen, double prijs, Maat kledingmaat, Clubset clubset)
        {
            ZetClub(club);
            ZetPrijs(prijs);
            Seizoen = seizoen;
            Kledingmaat = kledingmaat;
            ZetClubSet(clubset);
        }

        public Trui() {
        }

        public int Id { get; private set; }

        public Club Club { get; private set; }

        public string Seizoen { get; private set; }

        public double Prijs { get; private set; }

        public Maat Kledingmaat { get; set; }

        public Clubset ClubSet { get; private set; }

        public void ZetId(int id)
        {
            if (id <= 0) throw new TruiException("Id is lager dan 0");
            this.Id = id;
        }

        public void ZetPrijs(double prijs)
        {
            if (prijs <= 0) throw new TruiException("Prijs is lager dan 0");
            this.Prijs = prijs;
        }

        public void ZetSeizoen(string seizoen)
        {
            if (seizoen == null) throw new TruiException("Seizoen klopt niet");
            this.Seizoen = seizoen;
        }

        public void ZetClub(Club club)
        {
            if (club == null) throw new TruiException("ZetClub = null");
            this.Club = club;
        }

        public void ZetClubSet(Clubset clubset)
        {
            if (clubset == null) throw new TruiException("ZetClub = null");
            this.ClubSet = clubset;
        }

        public override string ToString() {
            return $"{Id} - {Club.PloegNaam} - {Club.Competitie} - {Seizoen} - {Kledingmaat} - {Prijs} - {ClubSet.Versie} - {ClubSet.Thuis}";
        }
    }
}
