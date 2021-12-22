using BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Manager
{
    public class BestellingsManager
    {
        private IBestellingRepository repo;

        public BestellingsManager(IBestellingRepository Repo)
        {
            this.repo = Repo;
        }

        public bool BestaatBestelling(Bestelling bestelling)
        {
            try {
                return repo.BestaatBestelling(bestelling);
            }
            catch(Exception ex) {
                throw new BestellingException("BestellingManager - BestaatBestelling  gefaald", ex);
            }

        }

        public bool BestaatBestelling(int id) {
            try {
                return repo.BestaatBestelling(id);
            }
            catch (Exception ex) {
                throw new BestellingException("BestellingManager - BestaatBestelling(id) gefaald", ex);
            }
        }

        public Bestelling GeefBestelling(int id) {
            return repo.GeefBestelling(id);
        }

        public void UpdateBestelling(Bestelling bestelling)
        {
            try
            {
                repo.UpdateBestelling(bestelling);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void VerwijderBestelling(Bestelling bestelling)
        {
            try
            {
                if (!repo.BestaatBestelling(bestelling)) throw new BestellingException("Bestelling - BestellingVerwijderen - Bestelling bestaat niet!");
                else
                    repo.VerwijderBestelling(bestelling);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void VoegBestellingToe(Bestelling bestelling)
        {
            try
            {
                repo.VoegBestellingToe(bestelling);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IReadOnlyList<Bestelling> ZoekBestellingen(int? bestellingid, DateTime? startDatum, DateTime? einddatum, Klant k) {
            try {
                return repo.ZoekBestellingen(bestellingid, startDatum, einddatum, k);
            }
            catch(Exception ex) {
                throw new BestellingException("Bestelling - ZoekBestellingen - Bestelling werd niet gevonden!");
            }
        }

        public Dictionary<Trui, int> GetInhoudBestelling(int id) {
           return repo.GetInhoudBestelling(id);
        }
    }
}
