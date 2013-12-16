using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CSharpFinal.SoapService;

namespace CSharpFinal {
    public class ContactsVM : BaseVM{
        ContactsContext _DB;
        SoapServiceClient soapClient; 

        ObservableCollection<int> AddressIDs { get; set; }

        public ObservableCollection<Address> Addresses { get; private set; }
        private Address _ViewingAddress;
        public Address ViewingAddress {
            get { return _ViewingAddress; }
            set { 
                _ViewingAddress = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ContactMethod> Methods { get; private set; }
        public ObservableCollection<Contact> Contacts { get; private set; }
        private Contact _ViewingContact;
        public Contact ViewingContact {
            get { return _ViewingContact; }
            set { 
                _ViewingContact = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Company> Companies { get; set; }
        private Company _ViewingCompany;

        public Company ViewingCompany {
            get { return _ViewingCompany; }
            set { 
                _ViewingCompany = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand AddCompanyCommand { get; private set; }
        public ICommand AddAddressCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand DeleteCompanyCommand { get; private set; }
        public ICommand DeleteAddressCommand { get; private set; }
        public ICommand AddContactMethodCommand { get; private set;}
        

        public ContactsVM() {
            _DB = new ContactsContext();
            soapClient = new SoapService.SoapServiceClient();
            Contacts = new ObservableCollection<Contact>();
            Addresses = new ObservableCollection<Address>();
            Companies = new ObservableCollection<Company>();
            AddressIDs = new ObservableCollection<int>();
            /* Old save command
            SaveCommand = new DelegateCommand(() => {
                _DB.SaveChanges();
            });
             */
            SaveCommand = new DelegateCommand(() => {
                foreach (var x in Contacts) {
                    soapClient.AddContact(x);
                }
                soapClient.Save();
            });
            /*old Add Contact
            AddContactCommand = new DelegateCommand(() => {
                ViewingContact = new Contact();
                Contacts.Add(ViewingContact);
                _DB.Contacts.Add(VewingContact);
            });
             */
            AddContactCommand = new DelegateCommand(() => {
                ViewingContact = new Contact();
                Contacts.Add(ViewingContact);
                //soapClient.AddContactAsync(ViewingContact);
            });
            AddCompanyCommand = new DelegateCommand(() => {
                ViewingCompany = new Company();
                Companies.Add(ViewingCompany);
                _DB.Companies.Add(ViewingCompany);
            });
            AddAddressCommand = new DelegateCommand(() => {
                ViewingAddress = new Address();
                Addresses.Add(ViewingAddress);
                _DB.Addresses.Add(ViewingAddress);
            });
            DeleteContactCommand = new DelegateCommand(() => {
                _DB.Contacts.Remove(ViewingContact);
                Contacts.Remove(ViewingContact);
            });
            DeleteCompanyCommand = new DelegateCommand(() => {
                _DB.Contacts.Remove(ViewingContact);
                Contacts.Remove(ViewingContact);
            });
            DeleteAddressCommand = new DelegateCommand(() => {
                _DB.Contacts.Remove(ViewingContact);
                Contacts.Remove(ViewingContact);
            });
            AddContactMethodCommand = new DelegateCommand(() => {
                var cm = new ContactMethod();
                ViewingContact.ContactMethods.Add(cm);
            });
            init();
        }

        private void init() {
            LoadContacts();
            LoadAddresses();
            LoadCompanies();
        }

        private void LoadContacts() {
            //IEnumerable<Contact> temp = _DB.Contacts.ToList();
            IEnumerable<Contact> temp = soapClient.GetContacts();
            foreach (var x in temp) {
                var methods = soapClient.GetContactMethods(x.Id);
                x.ContactMethods = methods.ToList();
                Contacts.Add(x);
            }
        }

        private void LoadAddresses() {
            //IEnumerable<Address> temp = _DB.Addresses.ToList();
            IEnumerable<Address> temp = soapClient.GetAddresses();
            foreach (var x in temp) {
                AddressIDs.Add(x.Id);
                Addresses.Add(x);
            }
        }

        private void LoadCompanies() {
            //IEnumerable<Company> temp = _DB.Companies.ToList();
            IEnumerable<Company> temp = soapClient.GetCompanies();
            foreach (var x in temp) {
                Companies.Add(x);
            }
        }

    }
}
