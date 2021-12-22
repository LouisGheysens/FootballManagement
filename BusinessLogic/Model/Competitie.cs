using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Competitie
    {
        public Competitie(string ploeg)
        {
            Ploeg = ploeg;
        }

        public string Ploeg { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Competitie competitie &&
                   Ploeg == competitie.Ploeg;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Ploeg);
        }
    }
}
