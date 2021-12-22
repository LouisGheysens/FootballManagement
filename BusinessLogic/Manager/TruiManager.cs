using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Manager
{
    public class TruiManager
    {
        private IVoetbalTruiRepository _repo;

        public TruiManager(IVoetbalTruiRepository repo)
        {
            this._repo = repo;
        }

        public Trui VoegTruitjeToe(Trui trui)
        {
            if (trui == null) throw new TruiManagerException("TruiManager: VoegTruitjeToe - trui is null");
            if (_repo.BestaatTruitje(trui)) throw new TruiManagerException("TruiManager: VoegTruitjeToe - truitje bestaat al");
            try {
                return _repo.VoegTruitjeToe(trui);
            }catch(Exception ex) {
                throw new TruiManagerException("TruiManager: VoegTruitjeToe - gefaald", ex);
            }
        }

        public void VerwijderTruitje(Trui id)
        {
            try {
                if (!_repo.BestaatTruitje(id.Id)) {

                    throw new TruiManagerException("Voetbaltruitje bestaat niet.");
                }
                _repo.VerwijderTruitje(id);
            }
            catch (Exception ex) {
                throw new TruiManagerException(ex.Message);
            }
        }

        public void UpdateTruitje(Trui trui)
        {
            try {
                if (!_repo.BestaatTruitje(trui.Id)) {
                    throw new TruiRepositoryADOException("Voetbaltruitje bestaat niet.");
                }
                _repo.UpdateTruitje(trui);
            }
            catch (Exception ex) {
                throw new TruiRepositoryADOException(ex.Message);
            }
        }

        public bool BestaatTruitje(int id) {
            try {
                return _repo.BestaatTruitje(id);
            }catch(Exception ex) {
                throw new TruiManagerException("TruiManager: BestaatTtruitje - niet gevonden!");
            }
        }

        public IReadOnlyList<Trui> GeefVoetbalTruitjesViaCompetitie(string competitie) {
            return _repo.GeefVoetbalTruitjesViaCompetitie(competitie);
        }

        public Trui GeefVoetbalTruitje(int id) {
            return _repo.GeefVoetbalTruitje(id);
        }

        public IReadOnlyList<Trui> ZoekVoetbaltruitjes(int id, string competitie, string ploeg, string seizoen,
            double? prijs, bool? thuis, int versie, string maat) {
            return _repo.ZoekVoetbaltruitjes(id, competitie, ploeg, seizoen, prijs, thuis, versie, maat);
        }

        public bool BestaatTruitje(Trui truitje) {
            return _repo.BestaatTruitje(truitje);
        }
    }
}
