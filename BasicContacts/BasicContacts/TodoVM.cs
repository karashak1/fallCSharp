using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicContacts {
    public class TodoVM : INotifyPropertyChanged{

        
        public string Text  { get; set; }
        public ObservableCollection<string> List { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public TodoVM() {
            List = new ObservableCollection<string>();
        }
    }
}
