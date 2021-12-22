using BusinessLogic;
using BusinessLogic.Manager;
using BusinessLogic.Model;
using DataLaag.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserInterfaceWPF.Bestelling;
using UserInterfaceWPF.Trui;

namespace UserInterfaceWPF {
    /// <summary>
    /// Interaction logic for TruiAlgemeenWindow.xaml
    /// </summary>
    public partial class TruiAlgemeenWindow : Window {

        #region Private properties
        private TruiManager  tm = new TruiManager(new TruiRepository());
        private BusinessLogic.Trui truitje = null;
        private List<BusinessLogic.Trui> truitjes = new List<BusinessLogic.Trui>();
        private ObservableCollection<string> _competities = new ObservableCollection<string>();
        private ObservableCollection<string> _clubs = new ObservableCollection<string>();
        private ObservableCollection<BusinessLogic.Trui> gevondenTruitjes = new ObservableCollection<BusinessLogic.Trui>();
        private ClubManager _clubmg = new ClubManager(new ClubRepository());
        #endregion

        #region Constructor
        public TruiAlgemeenWindow() {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
            reset();
        }
        #endregion


        #region Methods
        private void btn_HomeNav_Click(object sender, RoutedEventArgs e) {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_KlantNavigatie_Click(object sender, RoutedEventArgs e) {
            KlantAlgemeenWindow kaw = new KlantAlgemeenWindow();
            kaw.Show();
            this.Close();
        }

        private void btn_Bestelling_Click(object sender, RoutedEventArgs e) {
            BestellingWindow baw = new BestellingWindow();
            baw.Show();
            this.Close();
        }

        private void btn_Update_Click(object sender, RoutedEventArgs e) {
            try {
                BusinessLogic.Trui truitje = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                TruitjeUpdateWindow tw = new TruitjeUpdateWindow(truitje);
                if(tw.ShowDialog() == true) {
                    btn_TruiZoeken_Click(sender, e);
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }


        private void btn_TruiToevoegen_Click(object sender, RoutedEventArgs e) {
            try {
                bool thuis = true;
                bool isOk = true;
                if(rdio_Thuis.IsChecked == null || rdio_UIT.IsChecked == false) {
                    thuis = false;
                }
                if (combobx_Competitie.SelectedIndex == 0 || combobx_Maat.SelectedIndex == 0 || combobx_Club.SelectedIndex == 0 ||
                    string.IsNullOrWhiteSpace(txtbw_Seizoen.Text)) {
                    isOk = false;
                }
                if (isOk) {
                    Club club = new(combobx_Competitie.SelectedItem.ToString(), combobx_Club.SelectedItem.ToString());
                    Clubset clubset = new(thuis, int.Parse(txtbw_Versie.Text));
                    BusinessLogic.Trui truitje = new(club, txtbw_Seizoen.Text, double.Parse(txtbw_Prijs.Text), (Maat)Enum.Parse(typeof(Maat),
                        combobx_Maat.SelectedItem.ToString()), clubset);
                    tm.VoegTruitjeToe(truitje);
                    MessageBox.Show($"truitje voor {truitje.Club.PloegNaam} uit competitie: {truitje.Club.Competitie} werd zonet aangemaakt!",
                        Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    MessageBox.Show("Niet alle waarden werden correct ingevuld", "ERROR", MessageBoxButton.OK);
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

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
                IReadOnlyList<BusinessLogic.Trui> voetbaltruitjes = tm.ZoekVoetbaltruitjes(id, competitie, 
                    ploeg, txtbw_Seizoen.Text, prijs, thuis, versie, maat);
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

        private void txtbw_Prijs_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Regex.IsMatch(e.Text, @"^[\.0-9]*$")) {
                e.Handled = (true);
            }

        }

        private void txtbw_Versie_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Regex.IsMatch(e.Text, @"^\d$")) {
                e.Handled = (true);
            }
        }

        private void txtbw_Id_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Regex.IsMatch(e.Text, @"^\d$")) {
                e.Handled = (true);
            }
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

        private void nullRadioButtonCheck() {
            if (rdio_Thuis.IsChecked == false || rdio_UIT.IsChecked == false) MessageBox.Show("Duidt thuis of uit aan", "Error",
            MessageBoxButton.OK);
        }

        private void nullComboBoxCheck() {
            if (combobx_Club.SelectedIndex != 0) MessageBox.Show("Competitie heeft geen waarden", "Error", MessageBoxButton.OK);
            if (combobx_Club.SelectedIndex != 0) MessageBox.Show("Club heeft geen waarden", "ERROR", MessageBoxButton.OK);
            if (combobx_Maat.SelectedIndex != 0) MessageBox.Show("Maat heeft geen waarde", "Error", MessageBoxButton.OK);
        }

        private void combobx_Competitie_Loaded(object sender, RoutedEventArgs e) {
            ObservableCollection<string> competities = new(_clubmg.geefCompetities());
            competities.Insert(0, "<Geen competitie>");
            combobx_Competitie.SelectedIndex = 0;
            combobx_Competitie.ItemsSource = competities;
        }

        private void combobx_Maat_Loaded(object sender, RoutedEventArgs e) {
            List<string> maten = Enum.GetNames(typeof(Maat)).ToList();
            maten.Insert(0, "<alles>");
            combobx_Maat.ItemsSource = maten;
            combobx_Maat.SelectedIndex = 0;
        }

        private void btn_Delete_Click_1(object sender, RoutedEventArgs e) {
              try {
                BusinessLogic.Trui tr = (BusinessLogic.Trui)lstVw_Trui.SelectedItem;
                MessageBoxResult result = MessageBox.Show($"Wenst u {tr.Club.PloegNaam} uit competitie {tr.Club.Competitie} te verwijderen?",
                    "Verwijder truitje", MessageBoxButton.YesNoCancel);
                switch (result) {
                    case MessageBoxResult.Yes:
                        tm.VerwijderTruitje(tr);
                        btn_TruiZoeken_Click(sender, e);
                        MessageBox.Show($"{tr.Club.PloegNaam} uit competitie {tr.Club.Competitie} werd zonet verwijderd!");
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show($"{tr.Club.PloegNaam} uit competitie {tr.Club.Competitie} werd niet verwijderd!",
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

        private void combobx_Competitie_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (combobx_Competitie.SelectedIndex != 0) {
                ObservableCollection<string> ploegen = new(_clubmg.geefClub(combobx_Competitie.SelectedItem.ToString()));
                ploegen.Insert(0, "<geen club>");
                combobx_Club.ItemsSource = ploegen;
                combobx_Club.SelectedIndex = 0;
            }
            else {
                combobx_Club.ItemsSource = null;
            }
        }

        private void lstVw_Trui_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if(this.lstVw_Trui.SelectedItem != null) {
                BusinessLogic.Trui geselecteerdTruitje = (BusinessLogic.Trui)this.lstVw_Trui.SelectedItem;
                MessageBox.Show(string.Format(geselecteerdTruitje.ToString()), Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
