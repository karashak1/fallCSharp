using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using System.Data.Entity;
using System.Windows.Input;
using DataAccess;

namespace BasicContacts {
    public class Contacts2VM : BaseVM {

        CSharpContext _DB;

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

        public ICommand AddCommand { get; private set; }

        public Contacts2VM() {
            int i = 0;
            _DB = new CSharpContext();
            Contacts = _DB.Contacts.Local;
            Init();
        }

        async void Init() {
            await Task.Run(() => { 
                System.Threading.Thread.Sleep(5000); 
            });

            _DB.Contacts.ToList();
            SaveCommand = new DelegateCommand(() => _DB.SaveChanges());
        }
    }
}
