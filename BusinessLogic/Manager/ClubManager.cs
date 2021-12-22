using BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Manager
{
    public class ClubManager
    {
        private IClubRepository repo;
        public ClubManager(IClubRepository repo) {
            this.repo = repo;
        }

        public bool bestaatCompetitie(string competitie) {
            return repo.bestaatCompetitie(competitie);
        }

        public IReadOnlyList<string> geefClub(string competitie) {
            return repo.geefClub(competitie);
        }

        public IReadOnlyList<string> geefCompetities() {
            return repo.geefCompetities();
        }
    }
}
