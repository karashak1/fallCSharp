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
        string _AccessToken;

        public Contacts2VM() {
            int i = 0;
            _DB = new CSharpContext();
            Contacts = new ObservableCollection<Contact>();
            SaveCommand = new DelegateCommand(() => _DB.SaveChanges());
            AddCommand = new DelegateCommand(() => {
                CurrentContact = new Contact();
                Contacts.Add(CurrentContact);
                _DB.Contacts.Add(CurrentContact);
            });
            AddEmailCommand = new DelegateCommand(() => {
                var cm = new ContactMethod();
                CurrentContact.ContactMethods.Add(cm);
            });
            DeleteCommand = new DelegateCommand(() => {
                _DB.Contacts.Remove(CurrentContact);
                Contacts.Remove(CurrentContact);
            });
            LoginCommand = new DelegateCommand(LoginFB);


            Init();
        }

        async void Init() {
            IsLoading = System.Windows.Visibility.Visible;
            var temp = _DB.Contacts;
            var contacts = await temp.ToListAsync();
            foreach (var item in contacts) {
                Contacts.Add(item);
            }
            IsLoading = System.Windows.Visibility.Hidden;

        }

        async void LoadFacebook() {
            if (CurrentContact == null) return;
            var client = new HttpClient {
                BaseAddress = new Uri("https://graph.facebook.com/"),
                DefaultRequestHeaders = { { "accept", "application/json" } }
            };
            try {
                var response = await client.GetAsync(CurrentContact.fbid + "?access_token=" + _AccessToken);
                var fbMovie = await response.Content.ReadAsAsync<FBMovie>();
                FBItem = fbMovie;
                if (fbMovie.category != "Movie") {
                    response = await client.GetAsync(CurrentContact.fbid + "?access_token=" + _AccessToken);
                    var fbUser = await response.Content.ReadAsAsync<FBUser>();
                    FBItem = fbUser;
                }
                Log = await response.Content.ReadAsStringAsync();
            }
            catch (Exception) {
            }
        }
        async void LoadFacebookFeed() {
            if (CurrentContact == null) return;
            var client = new HttpClient {
                BaseAddress = new Uri("https://graph.facebook.com/"),
                DefaultRequestHeaders = { { "accept", "application/json" } }
            };
            try {
                var response = await client.GetAsync(CurrentContact.fbid + "/feed?access_token=" + _AccessToken);
                FBFeed = await response.Content.ReadAsAsync<FacebookFeed>();
                Log = await response.Content.ReadAsStringAsync();
            }
            catch (Exception) {
            }
        }

        void LoginFB() {
            var client_id = 1431663537049299;
            var redirect_uri = "https://www.facebook.com/connect/login_success.html";
            var scope = "email,friends_about_me,friends_activities,friends_birthday,friends_checkins,friends_education_history,friends_events,friends_groups,friends_hometown,friends_interests,friends_likes,friends_location,friends_notes,friends_photos,friends_questions,friends_relationships,friends_relationship_details,friends_religion_politics,friends_status,friends_subscriptions,friends_videos,friends_website,friends_work_history,read_stream,friends_online_presence,rsvp_event";
            var login_url = string.Format(
                "https://www.facebook.com/dialog/oauth?response_type=token&display=popup&client_id={0}&redirect_uri={1}&scope={2}",
                client_id, redirect_uri, scope);
            var w = new BrowserWindow { Width = 600, Height = 500 };
            w.web1.Navigate(login_url);
            w.Show();

            w.web1.Navigated += (s, e) => {
                if (e.Uri.PathAndQuery == "/connect/login_success.html") {
                    var str = e.Uri.Fragment;
                    var dict = str.TrimStart('#').Split('&').Select(x => x.Split('=')).ToDictionary(x => x[0], x => x[1]);
                    _AccessToken = dict["access_token"];
                    //add the search view model
                    w.Close();
                }
            };
        }

        public ObservableCollection<Contact> Contacts { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand AddEmailCommand { get; private set; }
        public ICommand LoginCommand { get; private set; }

        private Contact _CurrentContact;

        public Contact CurrentContact {
            get { return _CurrentContact; }
            set {
                _CurrentContact = value;
                OnPropertyChanged();
                LoadFacebook();
                LoadFacebookFeed();
            }
        }

        private System.Windows.Visibility _IsLoading;
        public System.Windows.Visibility IsLoading {
            get { return _IsLoading; }
            set { _IsLoading = value; OnPropertyChanged(); }
        }

        private string _Log;
        public string Log {
            get { return _Log; }
            set { _Log = value; OnPropertyChanged(); }
        }

        private FBItem _FBItem;
        public FBItem FBItem {
            get { return _FBItem; }
            set { _FBItem = value; OnPropertyChanged(); }
        }

        private FacebookFeed _FBFeed;
        public FacebookFeed FBFeed {
            get { return _FBFeed; }
            set { _FBFeed = value; OnPropertyChanged(); }
        }

    }



    public class FBMovie : FBItem {
        public string about { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string directed_by { get; set; }
        public string genre { get; set; }
        public bool is_published { get; set; }
        public string produced_by { get; set; }
        public string release_date { get; set; }
        public string screenplay_by { get; set; }
        public string starring { get; set; }
        public string studio { get; set; }
        public int talking_about_count { get; set; }
        public string username { get; set; }
        public string website { get; set; }
        public int were_here_count { get; set; }
        public string link { get; set; }
        public int likes { get; set; }
        public Cover cover { get; set; }
    }

    public class Cover {
        public string cover_id { get; set; }
        public string source { get; set; }
        public int offset_y { get; set; }
        public int offset_x { get; set; }
    }


    public class FBUser : FBItem {
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string link { get; set; }
        public string username { get; set; }
        public FBItem hometown { get; set; }
        public FBItem location { get; set; }
        public string bio { get; set; }
        public string quotes { get; set; }
        public Work[] work { get; set; }
        public FBItem[] inspirational_people { get; set; }
        public Education[] education { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public string political { get; set; }
        public string email { get; set; }
        public int timezone { get; set; }
        public string locale { get; set; }
        public FBItem[] languages { get; set; }
        public bool verified { get; set; }
        public DateTime updated_time { get; set; }
    }


    public class Work {
        public FBItem employer { get; set; }
        public FBItem position { get; set; }
    }



    public class Education {
        public FBItem school { get; set; }
        public FBItem[] concentration { get; set; }
        public string type { get; set; }
        public Class1[] classes { get; set; }
    }


    public class Class1 : FBItem {
        public FBItem[] with { get; set; }
    }


    public class FBItem {
        public string id { get; set; }
        public string name { get; set; }

    }

}
