using System;
using System.Collections.Generic;
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
    /// Interaction logic for BestellingWindow.xaml
    /// </summary>
    public partial class BestellingWindow : Window {

        #region Constructor
        public BestellingWindow() {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Methods
        private void Button_Click_3(object sender, RoutedEventArgs e) {
            MessageBox.Show("Neem contact op met de klantendienst", "Help", MessageBoxButton.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            BestellingToevoegenWindow BTW = new BestellingToevoegenWindow();
            BTW.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            BestellingZoekWindow bzr = new BestellingZoekWindow();
            bzr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            BestellingToevoegenWindow btk = new BestellingToevoegenWindow();
            btk.Show();
            this.Close();
        }
        #endregion
    }
}
