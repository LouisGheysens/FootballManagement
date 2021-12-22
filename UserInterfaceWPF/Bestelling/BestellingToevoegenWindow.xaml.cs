using BusinessLogic;
using BusinessLogic.Manager;
using BusinessLogic.Model;
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

namespace UserInterfaceWPF.Bestelling {
    /// <summary>
    /// Interaction logic for BestellingToevoegenWindow.xaml
    /// </summary>
    public partial class BestellingToevoegenWindow : Window {

        #region Private properties
        private List<BestellingTrui> _truitjes = (List<BestellingTrui>)Application.Current.Properties["Truitjes"];
        private Klant _klant = (Klant)Application.Current.Properties["Klant"];
        private Klant _klantSave = (Klant)Application.Current.Properties["Klant"];
        private BestellingsManager bm = new BestellingsManager(new BestellingRepository());
        #endregion

        #region Constructor
        public BestellingToevoegenWindow() {
            this.ResizeMode = ResizeMode.NoResize;
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void btn_selecteerKlant_Click(object sender, RoutedEventArgs e) {
            BestellingKlantSelecterenWindow kl = new BestellingKlantSelecterenWindow();
            kl.Show();
            this.Close();
        }

        private void txtPrijs_Loaded(object sender, RoutedEventArgs e) {
            PrijsLaden();
        }
        

        private void btn_SelecteerTruitje_Click(object sender, RoutedEventArgs e) {
            BestellingSelecteerTruitjeWindow btw = new();
            btw.Show();
            this.Close();
        }

        private void dtgrid_Truitjes_Loaded(object sender, RoutedEventArgs e) {
            ObservableCollection<BestellingTrui> oc = new();
            if (_truitjes != null && _truitjes.Count != 0) {
                foreach (var truitje in _truitjes) {
                    BestellingTrui voetbaltruitjesAantal = new(truitje.Truitje, truitje.Aantal);
                    oc.Add(voetbaltruitjesAantal);
                }
                dtgrid_Truitjes.ItemsSource = oc;
                txtPrijs_Loaded(sender, e);
            }
            else {
                oc.Clear();
                dtgrid_Truitjes.ItemsSource = oc;
            }
        }

        private void mnuit_Click(object sender, RoutedEventArgs e) {

            try {
                BestellingTrui x = (BestellingTrui)dtgrid_Truitjes.CurrentItem;
                foreach (var item in _truitjes) {
                    if (item.Truitje.Equals(x.Truitje) && item.Aantal.Equals(x.Aantal)) {
                        _truitjes.Remove(item);
                        break;
                    }
                }
                Application.Current.Properties["Truitjes"] = _truitjes;
                MessageBox.Show("Truitje is verwijderd uit de bestelling", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                dtgrid_Truitjes_Loaded(sender, e);
                txtPrijs_Loaded(sender, e);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_CreateOrder_Click(object sender, RoutedEventArgs e) {
            try {
                List<BestellingTrui> voetbaltruitjes = dtgrid_Truitjes.Items.OfType<BestellingTrui>().ToList();
                bool betaald = false;
                if (chkbx_Betaald.IsChecked != false) {
                    betaald = true;
                }
                _ = double.TryParse(txtPrijs.Text, out double prijs);
                if (txtbx_Klant.Text != null && _truitjes != null && _truitjes.Count != 0 && _klantSave != null) {
                    Dictionary<BusinessLogic.Trui, int> truitjes = new();
                    foreach (var item in voetbaltruitjes) {
                        truitjes.Add(item.Truitje, item.Aantal);
                    }
                    BusinessLogic.Bestelling bestelling = new(_klantSave, DateTime.Now, prijs, betaald, truitjes);
                    bm.VoegBestellingToe(bestelling);
                    if (bestelling == null) MessageBox.Show("Bestelling is leeg!");
                    Application.Current.Properties["Truitjes"] = null;
                    txtbx_Klant.Text = null;
                    txtPrijs.Text = null;
                    chkbx_Betaald.IsChecked = false;
                    _truitjes.Clear();
                    dtgrid_Truitjes_Loaded(sender, e);
                    MessageBox.Show("Bestelling geplaatst", Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    throw new Exception();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgrid_Truitjes_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) {
            BestellingTrui v = (BestellingTrui)dtgrid_Truitjes.SelectedItem;
            var truitje = _truitjes.Where(y => y.Truitje == v.Truitje).ToList()[0];
            var element = (TextBox)e.EditingElement;
            truitje.Aantal = int.Parse(element.Text);
            PrijsLaden();
        }

        private void PrijsLaden() {
            if (_truitjes != null) {
                double price = 0;
                foreach (var item in _truitjes) {
                    price += item.Truitje.Prijs * item.Aantal;
                }
                txtPrijs.Text = price.ToString("F2");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (_klant != null) {
                txtbx_Klant.Text = _klant.ToText(true);
                Application.Current.Properties["Klant"] = _klant;
                _klantSave = _klant;
                txtbx_Klant.Text = _klantSave.ToString();
            }
        }

        #endregion
    }
}
