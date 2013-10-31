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

        private Boolean _IsLoading;
        public System.Windows.Visibility IsLoading {
            get { return _IsLoading ? System.Windows.Visibility.Visible: System.Windows.Visibility.Hidden; }
            set { _IsLoading = value == System.Windows.Visibility.Visible; OnPropertyChanged(); }
        }
        
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddEmailCommand { get; private set; }

        public Contacts2VM() {
            int i = 0;
            _DB = new CSharpContext();
            Contacts = new ObservableCollection<Contact>();
            SaveCommand = new DelegateCommand(() => _DB.SaveChanges());
            AddCommand = new DelegateCommand(() => 
            {
                CurrentContact = new Contact();
                Contacts.Add(CurrentContact);
                _DB.Contacts.Add(CurrentContact);
            });
            AddEmailCommand = new DelegateCommand(() => {
                var cm = new ContactMethod();
                cm.KeywordID = 5;
                CurrentContact.ContactMethods.Add(cm);
            });
            DeleteCommand = new DelegateCommand(() => {
                _DB.Contacts.Remove(CurrentContact);
                Contacts.Remove(CurrentContact);
            });
            Init();
        }

        async void Init() {
            IsLoading = System.Windows.Visibility.Visible;
            var temp = from x in _DB.Contacts
                       select x;
            var contacts = await temp.Take(100).ToListAsync();
            foreach (var item in contacts) {
                Contacts.Add(item);
            }
            _DB.Contacts.ToList();
            IsLoading = System.Windows.Visibility.Hidden;
        }
    }
}
