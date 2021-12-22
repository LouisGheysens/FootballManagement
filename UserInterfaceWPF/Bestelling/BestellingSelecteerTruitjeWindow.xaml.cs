using BusinessLogic;
using BusinessLogic.Model;
using BusinessLogic.Manager;
using UserInterfaceWPF.Tools;
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

namespace UserInterfaceWPF.Bestelling {
    /// <summary>
    /// Interaction logic for BestellingSelecteerTruitjeWindow.xaml
    /// </summary>
    public partial class BestellingSelecteerTruitjeWindow : Window {

        #region Private properties
        private List<BusinessLogic.Trui> _Truitjes = new();
        private List<BestellingTrui> _bestellingTruiList = new();
        private BusinessLogic.Bestelling _bestellingen = (BusinessLogic.Bestelling)Application.Current.Properties["bestellingen"];
        private Queue<string> _wachtlijst = new();
        private TruiManager _tm = new TruiManager(new TruiRepository());
        private ClubManager _bm = new ClubManager(new ClubRepository());
        #endregion

        #region Constructor
        public BestellingSelecteerTruitjeWindow() {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;

        }
        #endregion

        #region Methods
        private void btn_TruiZoeken_Click(object sender, RoutedEventArgs e) {
            try {
                string competitie = "";
                string ploeg = "";
                double? prijs = null;
                bool? thuis = null;
                string maat = "";
                if (!int.TryParse(txtbw_Id.Text, out int id)) {
                    id = 0;
                }
                if (combobx_Competitie.SelectedIndex != 0 && combobx_Competitie != null) {
                    competitie = combobx_Competitie.SelectedItem.ToString();
                }
                if (combobx_Club.SelectedIndex != 0 && combobx_Club != null && combobx_Club.Items.Count != 0) {
                    ploeg = combobx_Club.SelectedItem.ToString();
                }
                if (double.TryParse(txtbw_Prijs.Text, out double prijs2)) {
                    prijs = prijs2;
                }
                if (!int.TryParse(txtbw_Versie.Text, out int versie)) {
                    versie = 0;
                }
                if (rdio_Thuis.IsChecked == true) {
                    thuis = true;
                }
                if (rdio_UIT.IsChecked == true) {
                    thuis = false;
                }
                if (rdio_Thuis.IsChecked == rdio_UIT.IsChecked) {
                    thuis = null;
                }
                if (combobx_Maat.SelectedIndex != 0 && combobx_Maat != null) {
                    maat = combobx_Maat.SelectedItem.ToString();
                }
                IReadOnlyList<BusinessLogic.Trui> voetbaltruitjes = _tm.ZoekVoetbaltruitjes(id, competitie, ploeg, txtbw_Seizoen.Text, prijs, thuis, versie, maat);
                ObservableCollection<BusinessLogic.Trui> ts = new();
                foreach (var voetbaltruitje in voetbaltruitjes) {
                    ts.Add(voetbaltruitje);
                }
                lstVw_Trui.ItemsSource = ts;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void combobx_Competitie_Loaded(object sender, RoutedEventArgs e) {
            ObservableCollection<string> competities = new(_bm.geefCompetities());
            competities.Insert(0, "<Geen competitie>");
            combobx_Competitie.SelectedIndex = 0;
            combobx_Competitie.ItemsSource = competities;
        }

        private void combobx_Competitie_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (combobx_Competitie.SelectedIndex != 0) {
                ObservableCollection<string> ploegen = new(_bm.geefClub(combobx_Competitie.SelectedItem.ToString()));
                ploegen.Insert(0, "<geen club>");
                combobx_Club.ItemsSource = ploegen;
                combobx_Club.SelectedIndex = 0;
            }
            else {
                combobx_Club.ItemsSource = null;
            }
        }

        private void combobx_Maat_Loaded(object sender, RoutedEventArgs e) {
            List<string> maten = Enum.GetNames(typeof(Maat)).ToList();
            maten.Insert(0, "<alles>");
            combobx_Maat.ItemsSource = maten;
            combobx_Maat.SelectedIndex = 0;
        }

        private void reset() {
            this.txtbw_Id.Text = "";
            this.combobx_Competitie.SelectedIndex = 0;
            this.txtbw_Seizoen.Text = "";
            this.combobx_Club.SelectedIndex = 0;
            this.txtbw_Prijs.Text = "";
            this.combobx_Maat.SelectedIndex = 0;
            this.txtbw_Versie.Text = "";
            this.rdio_Thuis.IsChecked = false;
            this.rdio_UIT.IsChecked = false;
            lstVw_Trui.ItemsSource = null;
        }

        private void btn_wachttlijst_Click(object sender, RoutedEventArgs e) {
            if (txtbw_Id.Text.Length < 1 && combobx_Competitie.SelectedIndex == -1
                && txtbw_Seizoen.Text.Length < 1 && combobx_Club.SelectedIndex == 1
                && txtbw_Prijs.Text.Length < 1 && combobx_Maat.SelectedIndex == -1 &&
                txtbw_Versie.Text.Length < 1 && !rdio_Thuis.IsChecked.HasValue
                || !rdio_UIT.IsChecked.HasValue) {
                MessageBox.Show("Alle waarden moeten ingevuld zijn om een wachtlijstverzoek te doen!", "Wachtlijst",
                    MessageBoxButton.OK);
            }
            else {
                _wachtlijst.Enqueue(combobx_Competitie.Text);
                _wachtlijst.Enqueue(txtbw_Seizoen.Text);
                _wachtlijst.Enqueue(combobx_Club.Text);
                _wachtlijst.Enqueue(txtbw_Prijs.Text);
                _wachtlijst.Enqueue(combobx_Maat.Text);
                _wachtlijst.Enqueue(txtbw_Versie.Text);
                _wachtlijst.Enqueue(rdio_Thuis.IsChecked.ToString());
                _wachtlijst.Enqueue(rdio_UIT.IsChecked.ToString());
                MessageBox.Show("Uw verzoek werd aan de wachtlijst toegevoegd!",
                    "Aanvraag succes", MessageBoxButton.OK);

                MessageBoxResult result = MessageBox.Show($"Wenst u de wachtrij te bekijken?",
                   "Wachtrij", MessageBoxButton.YesNoCancel);
                switch (result) {
                    case MessageBoxResult.Yes:
                        foreach(var item in _wachtlijst) {
                            lstVw_Trui.Items.Add(item.ToString());
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Actie wordt gecanceld....", "Wachtrij", MessageBoxButton.OK);
                        break;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (Application.Current.Properties["Truitjes"] != null) {
                _bestellingTruiList = (List<BestellingTrui>)Application.Current.Properties["Truitjes"];
            }
        }

        private void btn_Selecteer_Click(object sender, RoutedEventArgs e) {
            try {
                if (_bestellingen == null) {
                    if (lstVw_Trui.SelectedItem != null) {
                        BusinessLogic.Trui voetbaltruitje = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                        bool Bezet = false;
                        foreach (var item in _bestellingTruiList) {
                            if (item.Truitje.Equals(voetbaltruitje)) {
                                Bezet = true;
                            }
                        }
                        if (!Bezet) {
                            _bestellingTruiList.Add(new BestellingTrui(voetbaltruitje, 1));
                            Application.Current.Properties["Truitjes"] = _bestellingTruiList;
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingToevoegenWindow());
                        }
                        else {
                            foreach (var item in _bestellingTruiList) {
                                if (item.Truitje.Equals(voetbaltruitje)) {
                                    item.Aantal++;
                                }
                            }
                            Application.Current.Properties["Truitjes"] = _bestellingTruiList;
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingToevoegenWindow());
                        }
                    }
                    else {
                        MessageBox.Show("Er is geen truitje geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else {
                    Dictionary<BusinessLogic.Trui, int> truitjes = (Dictionary<BusinessLogic.Trui, int>)_bestellingen.GeefProducten();
                    if (lstVw_Trui.SelectedItem != null) {
                        BusinessLogic.Trui voetbaltruitje = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                        if (!truitjes.ContainsKey(voetbaltruitje)) {
                            truitjes.Add(voetbaltruitje, 1);
                            _bestellingen.VoegProductenToe(truitjes);
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingToevoegenWindow());
                        }
                        else {
                            truitjes.TryGetValue(voetbaltruitje, out int value);
                            truitjes[voetbaltruitje] = value + 1;
                            _bestellingen.VoegProductenToe(truitjes);
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingToevoegenWindow());
                        }
                    }
                    else {
                        MessageBox.Show("Er is geen truitje geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e) {
            try {
                if (_bestellingen == null) {
                    if (lstVw_Trui.SelectedItem != null) {
                        BusinessLogic.Trui voetbaltruitje = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                        bool Bezet = false;
                        foreach (var item in _bestellingTruiList) {
                            if (item.Truitje.Equals(voetbaltruitje)) {
                                Bezet = true;
                            }
                        }
                        if (!Bezet) {
                            _bestellingTruiList.Add(new BestellingTrui(voetbaltruitje, 1));
                            Application.Current.Properties["Truitjes"] = _bestellingTruiList;
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingToevoegenWindow());
                        }
                        else {
                            foreach (var item in _bestellingTruiList) {
                                if (item.Truitje.Equals(voetbaltruitje)) {
                                    item.Aantal++;
                                }
                            }
                            Application.Current.Properties["Truitjes"] = _bestellingTruiList;
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingUpdateWindow());
                        }
                    }
                    else {
                        MessageBox.Show("Er is geen truitje geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else {
                    Dictionary<BusinessLogic.Trui, int> truitjes = (Dictionary<BusinessLogic.Trui, int>)_bestellingen.GeefProducten();
                    if (lstVw_Trui.SelectedItem != null) {
                        BusinessLogic.Trui voetbaltruitje = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                        if (!truitjes.ContainsKey(voetbaltruitje)) {
                            truitjes.Add(voetbaltruitje, 1);
                            _bestellingen.VoegProductenToe(truitjes);
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingUpdateWindow());
                        }
                        else {
                            truitjes.TryGetValue(voetbaltruitje, out int value);
                            truitjes[voetbaltruitje] = value + 1;
                            _bestellingen.VoegProductenToe(truitjes);
                            Application.Current.Properties["bestellingen"] = _bestellingen;
                            StackService.NavigateTo(new BestellingUpdateWindow());
                        }
                    }
                    else {
                        MessageBox.Show("Er is geen truitje geselecteerd", Title, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}