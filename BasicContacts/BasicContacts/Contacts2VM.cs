using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Data.Entity;
using System.Windows.Input;

namespace BasicContacts {
    public class Contacts2VM : BaseVM {

        public ObservableCollection<Contact> Contacts { get; private set; }

        private Contact _CurrentContact;
        public Contact CurrentContact {
            get { return _CurrentContact; }
            set { 
                _CurrentContact = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }

        public Contacts2VM() {
            var db = new CSharpContext();
            Contacts = db.Contacts.Local;
            db.Contacts.ToList();
            SaveCommand = new DelegateCommand(() => db.SaveChanges());

        }
    }
}
