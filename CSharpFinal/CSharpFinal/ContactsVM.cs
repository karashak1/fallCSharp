using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Collections.ObjectModel;

namespace CSharpFinal {
    public class ContactsVM : BaseVM{
        ContactsContext _DB;

        public ObservableCollection<Contact> Contacts { get; private set; }

        public ObservableCollection<Address> Addresses { get; private set; }

        private Address _ViewingAddress;

        public Address ViewingAddress {
            get { return _ViewingAddress; }
            set { 
                _ViewingAddress = value;
                OnPropertyChanged();
            }
        }
        

        private Contact _ViewingContact;

        public Contact ViewingContact {
            get { return _ViewingContact; }
            set { 
                _ViewingContact = value;
                OnPropertyChanged();
            }
        }
        
        

        public ContactsVM() {
            _DB = new ContactsContext();
            Contacts = new ObservableCollection<Contact>();
            Addresses = new ObservableCollection<Address>();
            init();
        }

        private void init() {
            LoadContacts();
            LoadAddresses();
        }

        private void LoadContacts() {
            IEnumerable<Contact> temp = _DB.Contacts.ToList();
            foreach (var x in temp) {
                Contacts.Add(x);
            }
        }

        private void LoadAddresses() {
            IEnumerable<Address> add = _DB.Addresses.ToList();
            foreach (var x in add) {
                Addresses.Add(x);
            }
        }

    }
}
