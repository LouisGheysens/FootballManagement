using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface ITrui
    {
        Club Club { get; }
        Clubset ClubSet { get; }
        int Id { get; }
        Maat Kledingmaat { get; set; }
        double Prijs { get; }
        string Seizoen { get; }

        void ZetClub(Club club);
        void ZetClubSet(Clubset clubSet);
        void ZetId(int id);
        void ZetPrijs(double prijs);
        void ZetSeizoen(string seizoen);
    }
}
