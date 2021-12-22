using BusinessLogic;
using BusinessLogic.Manager;
using DataLaag.Repos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserInterfaceWPF.Tools;

namespace UserInterfaceWPF.Bestelling {
    /// <summary>
    /// Interaction logic for BestellingZoekWindow.xaml
    /// </summary>
    public partial class BestellingZoekWindow : Window {

        #region Private properties
        private Klant _Klant = (Klant)Application.Current.Properties["Klant"];
        private Klant _klantSave;
        private Klant _KlantUpdated;
        private BestellingsManager _bm = new BestellingsManager(new BestellingRepository());
        #endregion


        #region Constructor
        public BestellingZoekWindow() {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Methods
        private void btn_zoekBestelling_Click(object sender, RoutedEventArgs e) {
            try {
                int id = 0;
                DateTime? start = null;
                DateTime? end = null;
                if (!string.IsNullOrWhiteSpace(txt_id.Text)) {
                    id = int.Parse(txt_id.Text);
                }
                if(dtpickr_startdatum.SelectedDate != null) {
                    start = dtpickr_startdatum.SelectedDate;
                }
                if(dtpickr_einddatum.SelectedDate != null) {
                    end = dtpickr_einddatum.SelectedDate;
                }

                List<BusinessLogic.Bestelling> bestellingen = (List<BusinessLogic.Bestelling>)_bm.ZoekBestellingen(id, start, end, _KlantUpdated);
                List<BusinessLogic.Bestelling> tr = new();
                foreach(var l in bestellingen) {
                    tr.Add(l);
                }
                lstvw_Bestellingen.ItemsSource = tr;
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void txtbx_Klant_Loaded(object sender, RoutedEventArgs e) {
            if(_Klant != null) {
                if(_KlantUpdated != _Klant && _KlantUpdated != null) {
                    _KlantUpdated = _Klant;
                    txtbx_Klant.Text = _KlantUpdated.ToString();
                }
                else {
                    _KlantUpdated = _Klant;
                    txtbx_Klant.Text = _Klant.ToString();
                }
            }
        }

        private void btn_selectKlant_Click(object sender, RoutedEventArgs e) {
            BestellingKlantSelecterenWindow bt = new BestellingKlantSelecterenWindow();
            bt.Show();
            this.Close();

        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void reset() {
            txt_id.Text = "";
            txtbx_Klant.Text = null;
            dtpickr_startdatum.SelectedDate = null;
            dtpickr_einddatum.SelectedDate = null;
            lstvw_Bestellingen.ItemsSource = null;
        }
        

        private void lstvw_Bestellingen_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            Application.Current.Properties["bestellingen"] = (BusinessLogic.Bestelling)lstvw_Bestellingen.SelectedItem;
            StackService.NavigateTo(new BestellingUpdateWindow());
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e) {
            try {
                BusinessLogic.Bestelling bestelling = (BusinessLogic.Bestelling)lstvw_Bestellingen.SelectedItem;
                MessageBoxResult result = MessageBox.Show($"Wenst u {bestelling.BestelNummer} te verwijderen?",
                 "Verwijder klant", MessageBoxButton.YesNoCancel);
                switch (result) {
                    case MessageBoxResult.Yes:
                        _bm.VerwijderBestelling(bestelling);
                        MessageBox.Show($"Bestelling met bestelnummer: {bestelling.BestelNummer} werd zonet verwijderd",
                            "Verwijder bestelling", MessageBoxButton.OK);
                        btn_zoekBestelling_Click(sender, e);
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show($"Bestelling met {bestelling.BestelNummer}werd niet verwijderd!?",
                            "Verwijderen", MessageBoxButton.OK);
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Actie wordt gecanceld....", "Verwijderen", MessageBoxButton.OK);
                        break;

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }
        #endregion
    }
}
