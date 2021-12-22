using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic
{
    public class Clubset
    {
        public Clubset(bool thuis, int versie)
        {
            this.Thuis = thuis;
            this.Versie = versie;
        }

        public Boolean Thuis { get; private set; }
        public int Versie { get; private set; }

        public override bool Equals(object obj)
        {
            return obj is Clubset clubset &&
                   Thuis == clubset.Thuis &&
                   Versie == clubset.Versie;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Thuis, Versie);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
