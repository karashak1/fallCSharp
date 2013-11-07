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
using System.Net.Http;

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
                LoadFacebook();
            }
        }

        private String _Log;
        public String Log {
            get { return _Log; }
            set { _Log = value; OnPropertyChanged(); }
        }

        private FBUser _FBUser; 

        public FBUser FBUser {
            get { return _FBUser; }
            set { _FBUser = value; OnPropertyChanged(); }
        }
        

        async void LoadFacebook() {
            if (CurrentContact == null) return;
            var client = new HttpClient {
                BaseAddress = new Uri("http://graph.facebook.com/"),
                DefaultRequestHeaders = { { "accept" , "application/json"} }
            };
            try {
                var response = await client.GetAsync(CurrentContact.fbid + "?access_token="+access_token);
                var fb = await response.Content.ReadAsAsync<FBUser>();
                FBUser = fb;
                Log = fb.about;
            }
            catch (Exception) {
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
        public ICommand LoginCommand { get; private set; }

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
            LoginCommand = new DelegateCommand(Login);
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
        string access_token; //put the token here
        void Login() {
            var w = new BrowserWindow();
            w.web1.Navigate("https://www.facebook.com/dialog/oauth?client_id=1431663537049299&redirect_uri=https://www.facebook.com/connect/login_success.html&response_type=token");
            w.Show();
            w.web1.Navigated += web1_Navigated;
        }

        void web1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e) {
            if (e.Uri.PathAndQuery == "connect/login_success.html") {
                var str = e.Uri.Fragment;
            }
        }
    }

    public class FBUser {
        public string  about { get; set; }
        public string category{ get; set; }

    }
}
