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

namespace UserInterfaceWPF.Trui {
    /// <summary>
    /// Interaction logic for TruitjeUpdateWindow.xaml
    /// </summary>
    public partial class TruitjeUpdateWindow : Window {
        #region Private properties
        public BusinessLogic.Trui Trui { get; set; }
        private TruiManager tm = new TruiManager(new TruiRepository());
        private List<BusinessLogic.Trui> truitjes = new List<BusinessLogic.Trui>();
        private ObservableCollection<string> _competities = new ObservableCollection<string>();
        private ObservableCollection<string> _clubs = new ObservableCollection<string>();
        private ObservableCollection<BusinessLogic.Trui> gevondenTruitjes = new ObservableCollection<BusinessLogic.Trui>();
        private ClubManager _clubmg = new ClubManager(new ClubRepository());
        #endregion

        #region Constructor
        public TruitjeUpdateWindow(BusinessLogic.Trui t) {
            this.Trui = t;
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            reset();
        }
        #endregion

        #region Methods
        private void cmbx_Competitie_Loaded(object sender, RoutedEventArgs e) {
            ObservableCollection<string> competities = new(_clubmg.geefCompetities());
            competities.Insert(0, "<geen competitie>");
            cmbx_Competitie.SelectedIndex = 0;
            cmbx_Competitie.ItemsSource = competities;
            cmbx_Competitie.SelectedValue = Trui.Club.Competitie;
        }

        private void cmbx_Competitie_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (cmbx_Competitie.SelectedIndex != 0) {
                ObservableCollection<string> ploegen = new(_clubmg.geefClub(cmbx_Competitie.SelectedItem.ToString()));
                ploegen.Insert(0, "<geen club>");
                cmbx_Club.ItemsSource = ploegen;
                cmbx_Club.SelectedIndex = 0;
            }
            else {
                cmbx_Club.ItemsSource = null;
            }
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void reset() {
            txtbx_Id.Text = "";
            cmbx_Competitie.SelectedIndex = 0;
            txtbx_seizoenNieuw.Text = "";
            cmbx_Club.SelectedIndex = 0;
            txtbx_PrijsNieuw.Text = "";
            cmbbx_maatNieuw.SelectedIndex = 0;
            txtbx_Versie.Text = "";
            chckbx_thuisNieuw.IsChecked = false;
            chckbx_uitNieuw.IsChecked = false;
            txtbx_IdOud.Text = Trui.Id.ToString();
            txtbx_competitieOud.Text = Trui.Club.Competitie.ToString();
            txtbx_seizoenOud.Text = Trui.Seizoen;
            txtbx_clubOud.Text = Trui.Club.PloegNaam.ToString();
            txtbx_prijsOud.Text = Trui.Prijs.ToString();
            txtbx_MaatOud.Text = Trui.Kledingmaat.ToString();
            txtbx_VersieOud.Text = Trui.ClubSet.Versie.ToString();
            chckbx_thuisOud.IsChecked = Trui.ClubSet.Thuis;

        }

        private void btn_Update_Click(object sender, RoutedEventArgs e) {

            try {
                string competitie = cmbx_Competitie.SelectedItem.ToString();
                string ploeg = cmbx_Club.SelectedItem.ToString();
                string seizoen = txtbx_seizoenNieuw.Text;
                bool thuis = Trui.ClubSet.Thuis;
                Maat kledingmaat;
                if (cmbx_Competitie.SelectedIndex == 0) {
                    competitie = Trui.Club.Competitie;
                }
                if (cmbx_Club.SelectedIndex == 0) {
                    ploeg = Trui.Club.PloegNaam;
                }
                if (!double.TryParse(txtbx_PrijsNieuw.Text, out double prijs)) {
                    prijs = Trui.Prijs;
                }
                if (cmbbx_maatNieuw.SelectedIndex != 0) {
                    kledingmaat = (Maat)Enum.Parse(typeof(Maat), cmbbx_maatNieuw.SelectedItem.ToString());
                }
                else {
                    kledingmaat = Trui.Kledingmaat;
                }
                if (!int.TryParse(txtbx_Versie.Text, out int versie)) {
                    versie = Trui.ClubSet.Versie;
                }
                if (string.IsNullOrWhiteSpace(txtbx_seizoenNieuw.Text)) {
                    seizoen = Trui.Seizoen;
                }
                if (chckbx_thuisNieuw.IsChecked == false) {
                    thuis = false;
                }
                Club club = new(competitie, ploeg);
                Clubset clubSet = new(thuis, versie);
                BusinessLogic.Trui voetbaltruitje = new(Trui.Id, club, seizoen, prijs, kledingmaat, clubSet);
                tm.UpdateTruitje(voetbaltruitje);
                MessageBox.Show("Voetbaltruitje is bijgewerkt", Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cmbbx_maatNieuw_Loaded(object sender, RoutedEventArgs e) {
            List<string> maten = Enum.GetNames(typeof(Maat)).ToList();
            maten.Insert(0, "<alles>");
            cmbbx_maatNieuw.ItemsSource = maten;
            cmbbx_maatNieuw.SelectedIndex = 0;
        }
        #endregion
    }
}
