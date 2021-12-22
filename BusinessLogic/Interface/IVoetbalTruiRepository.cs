using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IVoetbalTruiRepository
    {
        Trui VoegTruitjeToe(Trui truitje);
        bool BestaatTruitje(int id);
        bool BestaatTruitje(Trui truitje);
        void UpdateTruitje(Trui truitje);
        IReadOnlyList<Trui> GeefVoetbalTruitjesViaCompetitie(string competitie);
        public IReadOnlyList<Trui> ZoekVoetbaltruitjes(int id, string competitie, string ploeg, string seizoen,
     double? prijs, bool? thuis, int versie, string maat);
            Trui GeefVoetbalTruitje(int id);
        void VerwijderTruitje(Trui trui);
    }
}
