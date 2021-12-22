using BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Manager
{
    public class KlantManager {

        private IKlantRepository repo;

        public KlantManager(IKlantRepository repo) {
            this.repo = repo;
        }
        public bool bestaatKlant(Klant Klant) {
            try {
                return repo.bestaatKlant(Klant.KlantenNummer);
            }
            catch (Exception ex) {
                throw new KlantException("Klant - BestaatlKlant - Klant bestaat niet!");
            }
        }
        public bool bestaatKlant(int id) {
            try {
                return repo.bestaatKlant(id);
            }
            catch (Exception ex) {
                throw new KlantException("Klant - BestaatlKlant - Klant bestaat niet!");
            }
        }

        public List<Klant> GeefKlant(int id, string naam, string adres) {
            try {
                return repo.KlantWeergeven(id, naam, adres);
            }catch(Exception ex) {
                throw new KlantException("Klant: GeefKlant(id, naam, adres), gefaald!");
            }
        }

        public void updateKlant(Klant klant) {
            try {
                if (klant == null) throw new KlantException("Klant - updateKlant - Klant is null");
                if (!repo.bestaatKlant(klant)) throw new KlantException("Klant - updateKlant - Klant bestaat niet");
                else
                    repo.updateKlant(klant);
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public void verwijderKlant(Klant klant) {
            try {
                if (klant.KlantenNummer== 0) throw new KlantException("Klant - verwijderKlant - Klant is null!");
                if (!repo.bestaatKlant(klant.KlantenNummer)) throw new KlantException("Klant - verwijderKlant - Klant bestaat niet!");
                else
                    repo.verwijderKlant(klant);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
        public Klant voegKlantToe(Klant klant) {
            try {
                if (klant == null) throw new KlantException("Klant: voegKlantToe - klant is null!");
                return repo.voegKlantToe(klant);
            }catch(Exception ex) {
                throw new KlantException("Klant: voegKlantToe - gefaald", ex);
            }

        }

        public List<Klant> KlantWeergeven(int id, string naam, string adres) {
            return repo.KlantWeergeven(id, naam, adres);
        }
    }
}
