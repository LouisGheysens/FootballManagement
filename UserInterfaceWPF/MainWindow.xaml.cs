using BusinessLogic.Manager;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataLaag.Repos;
using DataLaag;
using System.Configuration;
using UserInterfaceWPF.Bestelling;

namespace UserInterfaceWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        #region Constructor
        public MainWindow() {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;
        }
        #endregion

        #region Methods
        private void btn_CloseAppMainWindow_Click(object sender, RoutedEventArgs e) {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_OpenMenu_Click(object sender, RoutedEventArgs e) {
            btn_OpenMenu.Visibility = Visibility.Collapsed;
            btn_CloseMenu.Visibility = Visibility.Visible;
        }

        private void btn_CloseMenu_Click(object sender, RoutedEventArgs e) {
            btn_OpenMenu.Visibility = Visibility.Visible;
            btn_CloseMenu.Visibility = Visibility.Collapsed;
        }

        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            KlantAlgemeenWindow kaw = new KlantAlgemeenWindow();
            kaw.Show();
            this.Close();
        }


        private void PackIcon_TruiDoubleClick(object sender, MouseButtonEventArgs e) {
            TruiAlgemeenWindow truia = new TruiAlgemeenWindow();
            truia.Show();
            this.Close();
        }


        private void PackIcon_BestellingDoubleClick(object sender, MouseButtonEventArgs e) {
            BestellingWindow baw = new BestellingWindow();
            baw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Louis Gheysens", "Ontwikkelaar", MessageBoxButton.OK);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            try {
                MessageBoxResult result = MessageBox.Show("Wenst u verdere instellingen te wijzigen?",
                    "Instellingen", MessageBoxButton.YesNoCancel);

                switch (result) {
                    case MessageBoxResult.Yes:
                        MessageBox.Show("Neem contact op met de klantendienst!", "Contact", MessageBoxButton.OK);
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("Instellingen werden niet gewijzigd!",
                            "Instellingen", MessageBoxButton.OK);
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("Actie wordt gecanceld....", "Instellingen", MessageBoxButton.OK);
                        break;

                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, ex.GetType().Name);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            MessageBox.Show("Deze applicatie werd ontwikkeld door Louis Gheysens");
        }
        #endregion
    }
}
