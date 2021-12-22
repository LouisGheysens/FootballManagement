using BusinessLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Model {
    public class BestellingTrui {
        public Trui Truitje { get; set; }
        public int Aantal { get; set; }


        public BestellingTrui(Trui tl, int aantal) : this(tl) {
            this.Aantal = aantal;
        }

        public BestellingTrui(Trui tk) {
            this.Truitje = tk;
        }

        public void ZetVoetbaltruitje(Trui voetbaltruitje) {
            if (Truitje == null) {
                throw new TruiException("Het kan niet leeg zijn.");
            }
            Truitje = voetbaltruitje;
        }

        public void ZetAantal(int aantal) {
            if (aantal >= 0) {
                throw new TruiException("Het kan niet 0 of kleiner zijn.");
            }
            Aantal = aantal;
        }
    }
}
