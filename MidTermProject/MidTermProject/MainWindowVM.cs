using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data.Entity;

namespace MidTermProject {
    class MainWindowVM : BaseVM {

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
        
        private int _ContactSize;
        public int ContactSize {
            get { return _ContactSize; }
            set { _ContactSize = value; }
        }

        private int _KeywordSize;
        public int KeywordSize {
            get { return _KeywordSize; }
            set { _KeywordSize = value; }
        }

        private int _ContactMethodSize;
        public int ContactMethodSize {
            get { return _ContactMethodSize; }
            set { _ContactMethodSize = value; }
        }

        private int _AddressSize;

        public int AddressSize {
            get { return _AddressSize; }
            set { _AddressSize = value; }
        }
        

        private ObservableCollection<Keyword> _Keywords;    

        public ObservableCollection<Keyword> Keywords {
            get { return _Keywords; }
            set { _Keywords = value; }
        }
        

        private ObservableCollection<Contact> _Contacts;
        public ObservableCollection<Contact> Contacts {
            get { return _Contacts; }
            set { _Contacts = value; OnPropertyChanged(); }
        }

        private ObservableCollection<ContactMethod> _ContactMethods;
        public ObservableCollection<ContactMethod> ContactMethods {
            get { return _ContactMethods; }
            set { _ContactMethods = value; }
        }

        private ObservableCollection<Address> _Addresses;

        public ObservableCollection<Address> Addresses {  
            get { return _Addresses; }
            set { _Addresses = value; }
        }
        
        

        public MainWindowVM() {
            /*
            AddCommand = new DelegateCommand(
                () => {
                    Contacts.Add(new Contact { FirstName = this.FirstName });
                    FirstName = null;
                },
                () => !String.IsNullOrWhiteSpace(FirstName)
            );
             */
            var db = new CSharpContext();
            Contacts = db.Contacts.Local;
            Keywords = db.Keywords.Local;
            ContactMethods = db.ContactMethods.Local;
            Addresses = db.Addresses.Local;
            db.Contacts.Load();
            db.Keywords.Load();
            db.ContactMethods.Load();
            db.Addresses.Load();
            ContactSize = Contacts.Count;
            KeywordSize = Keywords.Count;
            ContactMethodSize = ContactMethods.Count;
            AddressSize = Addresses.Count;
            
        }
    
    }

    public class BaseVM : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null) {

            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class DelegateCommand : ICommand {

        private Action _Action;
        private Func<bool> _CanExecute;

        public DelegateCommand(Action action, Func<bool> canExecute = null) {
            _Action = action;
            _CanExecute = canExecute;
        }

        public bool CanExecute(object parameter) {
            //throw new NotImplementedException();
            if (_CanExecute == null)
                return true;
            else
                return _CanExecute();
        }

        public event EventHandler CanExecuteChanged;
        public void OnCanExecuteChanged() {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public void Execute(object parameter) {
            //throw new NotImplementedException();
            _Action();
        }
    }
}
