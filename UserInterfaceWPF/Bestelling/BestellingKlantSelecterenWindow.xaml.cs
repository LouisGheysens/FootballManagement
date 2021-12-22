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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserInterfaceWPF.Tools;

namespace UserInterfaceWPF.Bestelling {
    /// <summary>
    /// Interaction logic for BestellingKlantSelecterenWindow.xaml
    /// </summary>
    public partial class BestellingKlantSelecterenWindow : Window {

        #region Properties
        private BusinessLogic.Bestelling _bestellingen = null;
        private BusinessLogic.Bestelling _updateView = (BusinessLogic.Bestelling) Application.Current.Properties["updateView"];
        private KlantManager _bm = new KlantManager(new KlantRepository());
        private  BestellingToevoegenWindow btw;
        #endregion

        #region Constructor
        public BestellingKlantSelecterenWindow() {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Methods
        private void lstVw_Klanten_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                if (lstVw_Klanten.SelectedItem != null) {
                    Klant klant = (Klant)lstVw_Klanten.SelectedItem;
                    Application.Current.Properties["Klant"] = klant;
                    if (_bestellingen != null) {
                        _bestellingen.ZetKlant(klant);
                        Application.Current.Properties["updateView"] = _bestellingen;
                    }
                    StackService.NavigateTo(new BestellingZoekWindow());
                    this.Close();
                }
                else {
                    MessageBox.Show("Er is geen klant geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void btn_KlantZoeken_Click(object sender, RoutedEventArgs e) {
            try {
                int id;
                if (string.IsNullOrWhiteSpace(txtbw_id.Text)) {
                    id = 0;
                }
                else {
                    id = int.Parse(txtbw_id.Text);
                }
                List<Klant> klanten = _bm.KlantWeergeven(id, txtbw_Naam.Text, txtbw_Adres.Text);
                ObservableCollection<Klant> ts = new();
                foreach (Klant klant in klanten) {
                    ts.Add(klant);
                }
                lstVw_Klanten.ItemsSource = ts;
            }catch(Exception x) {

                MessageBox.Show(x.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void reset() {
            this.txtbw_id.Text = "";
            this.txtbw_Adres.Text = "";
            this.txtbw_Naam.Text = "";
            lstVw_Klanten.ItemsSource = null;
        }

        private void btn_Selecteer_Click(object sender, RoutedEventArgs e) {
            try {
                if (lstVw_Klanten.SelectedItem != null) {
                    Klant klant = (Klant)lstVw_Klanten.SelectedItem;
                    Application.Current.Properties["Klant"] = klant;
                    if (_bestellingen != null) {
                        _bestellingen.ZetKlant(klant);
                        Application.Current.Properties["updateView"] = _bestellingen;
                    }
                    StackService.NavigateTo(new BestellingToevoegenWindow());
                    this.Close();
                }
                else {
                    MessageBox.Show("Er is geen klant geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e) {
            try {
                if (lstVw_Klanten.SelectedItem != null) {
                    Klant klant = (Klant)lstVw_Klanten.SelectedItem;
                    Application.Current.Properties["Klant"] = klant;
                    if (_bestellingen != null) {
                        _bestellingen.ZetKlant(klant);
                        Application.Current.Properties["updateView"] = _bestellingen;
                    }
                    StackService.NavigateTo(new BestellingUpdateWindow());
                    this.Close();
                }
                else {
                    MessageBox.Show("Er is geen klant geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}

