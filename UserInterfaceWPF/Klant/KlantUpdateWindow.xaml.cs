using BusinessLogic;
using BusinessLogic.Manager;
using DataLaag;
using DataLaag.Repos;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace UserInterfaceWPF {
    /// <summary>
    /// Interaction logic for KlantUpdateWindow.xaml
    /// </summary>
    public partial class KlantUpdateWindow : Window {

        #region Private properties
        private Klant Klantje { get; set; }
        private KlantManager km = new KlantManager(new KlantRepository());
        #endregion

        #region Constructor
        public KlantUpdateWindow(Klant klr) {

            this.Klantje = klr;
            InitializeComponent();
            reset();
            ResizeMode = ResizeMode.NoResize;
           
        }
        #endregion

        #region Methods
        private void txt_Adres_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                if (txt_Adres.Text == null) MessageBox.Show("TextBox adres is leeg");
                Regex reg = new Regex("/^[a-zA-Z]{0,10}$/");
                e.Handled = reg.IsMatch(txt_Adres.Text);
                if (txt_Adres.Text.Length < 10)
                    MessageBox.Show("Adres is geen 10 karakters lang!", "Fout - adres", MessageBoxButton.OK);
            }
        }

        private string oldText = "";
        private void txt_Naam_TextChanged(object sender, TextChangedEventArgs e) {
            if ((txt_Naam.SelectionStart <= txt_Naam.Text.Length - oldText.Length || txt_Naam.SelectionStart == 0) 
                && char.IsLower(txt_Naam.Text.FirstOrDefault())) {
                var selectionStart = txt_Naam.SelectionStart;
                var selectionLength = txt_Naam.SelectionLength;
                txt_Naam.TextChanged -= txt_Naam_TextChanged;
                txt_Naam.Text = $"{Char.ToUpper(txt_Naam.Text.First())}{(txt_Naam.Text.Length > 1 ? txt_Naam.Text.Substring(1) : "")}";
                txt_Naam.Select(selectionStart, selectionLength);
                txt_Naam.TextChanged += txt_Naam_TextChanged;
            }
            oldText = txt_Naam.Text;
        }

        private void reset() {
            try {
                txt_Adres.Text = "";
                txt_Naam.Text = "";
                txt_NaamHuidig.Text = string.IsNullOrWhiteSpace(Klantje.Naam) ? "Geen naam" : Klantje.Naam;
                txt_AdresHuidig.Text = string.IsNullOrWhiteSpace(Klantje.Adres) ? "Geen Adres" : Klantje.Adres;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void button_reset_Click(object sender, RoutedEventArgs e) {
            reset();
        }

        private void UpdateWindow_Click_1(object sender, RoutedEventArgs e) {
            try {
                Klant k = Klantje;
                k.ZetNaam(txt_Naam.Text);
                k.ZetAdres(txt_Adres.Text);
                km.updateKlant(k);
                DialogResult = true;
                Close();
                MessageBox.Show("Update!", "Klant werd zonet aangepast!", MessageBoxButton.OK);
                MessageBox.Show(k.ToString(), Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
