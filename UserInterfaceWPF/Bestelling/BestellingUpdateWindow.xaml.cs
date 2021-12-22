using BusinessLogic;
using BusinessLogic.Manager;
using DataLaag.Repos;
using System;
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
using System.Windows.Navigation;
using BusinessLogic.Model;
using UserInterfaceWPF.Tools;

namespace UserInterfaceWPF.Bestelling {
    /// <summary>
    /// Interaction logic for BestellingUpdateWindow.xaml
    /// </summary>
    public partial class BestellingUpdateWindow : Window {
        #region Private properties
        BusinessLogic.Bestelling _bestellingen = 
            (BusinessLogic.Bestelling)Application.Current.Properties["bestellingen"];
        BusinessLogic.Klant _klant = (BusinessLogic.Klant)Application.Current.Properties["Klant"];
        private BestellingsManager _bm = new BestellingsManager(new BestellingRepository());
        #endregion

        #region Constructor
        public BestellingUpdateWindow() {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;

        }
        #endregion

        #region Methods
        private void btn_SelecteerKlant_Click(object sender, RoutedEventArgs e) {
            BestellingKlantSelecterenWindow bksl = new BestellingKlantSelecterenWindow();
            bksl.Show();
            this.Close();
        }

        private void btn_SelecteerTruitje_Click(object sender, RoutedEventArgs e) {
            BestellingSelecteerTruitjeWindow bstw = new BestellingSelecteerTruitjeWindow();
            bstw.Show();
            this.Close();
        }


        private void txt_Prijs_Loaded(object sender, RoutedEventArgs e) {
            Dictionary<BusinessLogic.Trui, int> truitjes = new Dictionary<BusinessLogic.Trui, int>();

            truitjes = (Dictionary<BusinessLogic.Trui, int>)_bestellingen.GeefProducten();
            if (truitjes != null) {
                double price = 0;
                foreach (var i in truitjes.Keys) {
                    price += i.Prijs * truitjes[i];
                }
                txt_Prijs.Text = price.ToString("F2");
            }
        }

        private void UpdateBestellingTruitjes(List<BestellingTrui> truitjes) {
            Dictionary <BusinessLogic.Trui, int> keyValuePairs = new();
            foreach (var item in truitjes) {
                keyValuePairs.Add(item.Truitje, item.Aantal);
            }
            _bestellingen.VoegProductenToe(keyValuePairs);
            Application.Current.Properties["bestellingen"] = _bestellingen;
        }

        private void PrijsLaden(List<BestellingTrui> truitjes) {
            if (truitjes != null) {
                double price = 0;
                foreach (var item in truitjes) {
                    price += item.Truitje.Prijs * item.Aantal;
                }
                txt_Prijs.Text = price.ToString("F2");
            }
        }

        private List<BestellingTrui> DictionaryConverter() {
            Dictionary<BusinessLogic.Trui, int> truitjes = new();
            truitjes = (Dictionary<BusinessLogic.Trui, int>)_bestellingen.GeefProducten();
            List<BestellingTrui> voetbaltruitjesAantals = new();
            foreach (var truitje in truitjes) {
                voetbaltruitjesAantals.Add(new BestellingTrui(truitje.Key, truitje.Value));
            }
            return voetbaltruitjesAantals;
        }

        private void DataGridTruitjes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            BestellingTrui tussenTaabelTrui = (BestellingTrui)DataGridTruitjes.SelectedItem;
            List<BestellingTrui> truitjes = DictionaryConverter();
            var truitje = truitjes.Where(y => y.Truitje == tussenTaabelTrui.Truitje).ToList()[0];
            var element = (TextBox)e.EditingElement;
            truitje.Aantal = int.Parse(element.Text);
            UpdateBestellingTruitjes(truitjes);
            PrijsLaden(DictionaryConverter());
        }

        private void DataGridTruitjes_Loaded_1(object sender, RoutedEventArgs e) {
            ObservableCollection<BestellingTrui> trp = new();
            if (_bestellingen.GeefProducten() != null && _bestellingen.GeefProducten().Count != 0) {
                foreach (var truitje in _bestellingen.GeefProducten()) {
                    trp.Add(new BestellingTrui(truitje.Key, truitje.Value));
                }
                DataGridTruitjes.ItemsSource = trp;
                txt_Prijs_Loaded(sender, e);
            }
            else {
                trp.Clear();
                DataGridTruitjes.ItemsSource = trp;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if(_klant == null) {
                txt_klant.Text = _bestellingen.Klant.ToText(true);
            }
            else {
                txt_klant.Text = _klant.ToString();
            }
            chkbx_betaald.IsChecked = _bestellingen.Betaald;
            txt_Prijs.Text = _bestellingen.Prijs.ToString();
        }

        private void DeleteVoetbaltruitje_Click(object sender, RoutedEventArgs e) {
            try {
                List<BestellingTrui> truitjes = new();
                foreach (var item in _bestellingen.GeefProducten()) {
                    truitjes.Add(new BestellingTrui(item.Key, item.Value));
                }
                BestellingTrui x = (BestellingTrui)DataGridTruitjes.CurrentItem;
                foreach (var item in truitjes) {
                    if (item.Truitje.Equals(x.Truitje) && item.Aantal.Equals(x.Aantal)) {
                        truitjes.Remove(item);
                        _bestellingen.VerwijderTruitje(item.Truitje, item.Aantal);
                        break;
                    }
                }
                Application.Current.Properties["bestellingen"] = _bestellingen;
                MessageBox.Show("Truitje is verwijderd uit de bestelling", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                DataGridTruitjes_Loaded_1(sender, e);
                txt_Prijs_Loaded(sender, e);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btn_updateOrder_Click_1(object sender, RoutedEventArgs e) {
            try {
                if(_klant != null) {
                    _bestellingen.ZetKlant(_klant);
                }
                _bestellingen.ZetPrijs(double.Parse(txt_Prijs.Text));
                _bm.UpdateBestelling(_bestellingen);
                Application.Current.Properties["bestellingen"] = null;
                Application.Current.Properties["Klant"] = null;
                MessageBox.Show("Bestelling is updated!", Title,
                    MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
                StackService.NavigateTo(new BestellingZoekWindow());
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }
        #endregion

    }
}
