using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess;

namespace BasicContacts {
    class ContactsVM : BaseVM {

        private string _FirstName;
        public string FirstName {
            get { return _FirstName; }
            set { 
                _FirstName = value;
                OnPropertyChanged();
                AddCommand.OnCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand { get; private set; }
        private ObservableCollection<Contact> _Contacts;

        public ObservableCollection<Contact> Contacts {
            get { return _Contacts; }
            set { _Contacts = value; OnPropertyChanged(); }
        }        

        public ContactsVM() {
            AddCommand = new DelegateCommand(
                () => {
                    Contacts.Add(new Contact { FirstName = this.FirstName });
                    FirstName = null;
                },
                () => !String.IsNullOrWhiteSpace(FirstName)
            );
            var db = new CSharpContext();
            Contacts = db.Contacts.Local;
            db.Contacts.Load(); ;
        }
    }
}
