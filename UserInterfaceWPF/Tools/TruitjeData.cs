using BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceWPF.Tools {
    public class TruitjeData: INotifyPropertyChanged {

        public TruitjeData(BusinessLogic.Trui truitje, int aantal) {
            Truitje = truitje;
            Aantal = aantal;
        }

        public BusinessLogic.Trui Truitje { get; set; }

        private int aantal;

        public int Aantal {
            get { return aantal; }
            set {
                aantal = value;
                
            }
        }

        private void OnPropertyChanged(string name = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
