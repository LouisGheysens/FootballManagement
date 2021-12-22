using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface {
    public interface IClubRepository {
        IReadOnlyList<string> geefCompetities();
        IReadOnlyList<string> geefClub(string competitie);
        bool bestaatCompetitie(string competitie);
    }
}
