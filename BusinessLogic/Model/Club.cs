using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Model
{
    public class Club
    {
        public string Competitie { get; private set; }

        public string PloegNaam { get; private set; }

        public Club(string competitie, string ploegnaam)
        {
            if (string.IsNullOrEmpty(competitie.Trim()) ||
                (string.IsNullOrWhiteSpace(ploegnaam.Trim())))
            {
                throw new ClubException("Club naam/competitie is niet leeg!");
            }

            Competitie = competitie;
            PloegNaam = ploegnaam;
        }

        public override bool Equals(object obj)
        {
            return obj is Club club &&
                   Competitie == club.Competitie &&
                   PloegNaam == club.PloegNaam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Competitie, PloegNaam);
        }
    }
}
