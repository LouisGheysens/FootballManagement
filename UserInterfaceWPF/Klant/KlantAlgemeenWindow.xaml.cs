using BusinessLogic;
using BusinessLogic.Manager;
using DataLaag.Repos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserInterfaceWPF;
using UserInterfaceWPF.Bestelling;

namespace UserInterfaceWPF {
    /// <summary>
    /// Interaction logic for KlantAlgemeenWindow.xaml
    /// </summary>
    public partial class KlantAlgemeenWindow : Window {
        #region Private properties
        private KlantManager km = new KlantManager(new KlantRepository());
        private Klant klant = null;
        private List<Klant> klanten = new List<Klant>();
        private ObservableCollection<Klant> gevondenKlanten = new ObservableCollection<Klant>();
        #endregion

        #region Constructor
        public KlantAlgemeenWindow() {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Methods
        private void btn_Update_Click(object sender, RoutedEventArgs e) {
            KlantUpdateWindow kuw = new KlantUpdateWindow(klant);
            kuw.Show();
            this.Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e) {
            try {
                Klant kl = (Klant)lstVw_Klanten.SelectedItem;
                MessageBoxResult result = MessageBox.Show($"Wenst u {kl.Naam} uit {kl.Adres} te verwijderen?", 
                    "Verwijder klant", MessageBoxButton.YesNoCancel);
                switch (result) {
                    case MessageBoxResult.Yes:
                        km.verwijderKlant(kl);
                        btn_KlantZoeken_Click(sender, e);
                        MessageBox.Show($"{kl.Naam} uit {kl.Adres} werd zonet verwijderd!");
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show($"{kl.Naam} uit {kl.Adres} werd niet verwijderd!", 
                            "Verwijderen", MessageBoxButton.OK);
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Actie wordt gecanceld....", "Verwijderen", MessageBoxButton.OK);
                        break;
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void btn_KlantToevoegen_Click(object sender, RoutedEventArgs e) {
            string naam = txtbw_Naam.Text;
            string adres = txtbw_Adres.Text;

            if (string.IsNullOrWhiteSpace(naam)) MessageBox.Show("Naam is leeg!", "ERROR", MessageBoxButton.OK);
            if (string.IsNullOrWhiteSpace(naam)) MessageBox.Show("Adres is leeg!", "ERROR", MessageBoxButton.OK);

            try {
                Klant k = new Klant(naam, adres);
                Klant klant = km.voegKlantToe(k);
                klanten.Add(klant);
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }

            lstVw_Klanten.ItemsSource = klanten;
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

                gevondenKlanten = new ObservableCollection<Klant>(km.KlantWeergeven(id, txtbw_Naam.Text, txtbw_Adres.Text));
                if (gevondenKlanten.Count < 1) MessageBox.Show("Er werden geen zoekresultaten gevonden!", "Zoekresultaten", MessageBoxButton.OK);
                lstVw_Klanten.ItemsSource = gevondenKlanten;

            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void btn_HomeNav_Click(object sender, RoutedEventArgs e) {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btn_TruiNavigatie_Click(object sender, RoutedEventArgs e) {
            TruiAlgemeenWindow taw = new TruiAlgemeenWindow();
            taw.Show();
            this.Close();
        }

        private void btn_Bestelling_Click(object sender, RoutedEventArgs e) {
            BestellingWindow baw = new BestellingWindow();
            baw.Show();
            this.Close();
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void reset() {
            this.txtbw_id.Text = "";
            this.txtbw_Adres.Text = "";
            this.txtbw_Naam.Text = "";
        }

        private void txtbw_Naam_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            if (!Regex.IsMatch(e.Text, @"^[a-zA-Z]+$")) {
                e.Handled = (true);
            }
        }

        private void txtbw_Adres_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                if (txtbw_Adres.Text == null) MessageBox.Show("TextBox adres is leeg");
                Regex reg = new Regex("/^[a-zA-Z]{0,10}$/");
                e.Handled = reg.IsMatch(txtbw_Adres.Text);
                if (txtbw_Adres.Text.Length < 10)
                    MessageBox.Show("Adres is geen 10 karakters lang!", "Fout - adres", MessageBoxButton.OK);
            }
        }

        private void txtbw_id_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            e.Handled = !isIdValid(((TextBox)sender).Text + e.Text);
        }

        public static bool isIdValid(string s) {
            int i;
            return int.TryParse(s, out i) && i >= 0 && i <= int.MaxValue;
        }

        private void btn_Update_Click_1(object sender, RoutedEventArgs e) {
            try {
                Klant k = (Klant)lstVw_Klanten.SelectedItem;
                KlantUpdateWindow w = new KlantUpdateWindow(k);
                if(w.ShowDialog() == true) {
                    btn_KlantZoeken_Click(sender, e);
                }
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void lstVw_Klanten_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (lstVw_Klanten.SelectedItem != null) {
                Klant geselecteerdeKlant = (Klant)this.lstVw_Klanten.SelectedItem;
                MessageBox.Show(string.Format(geselecteerdeKlant.ToString()), 
                    Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
