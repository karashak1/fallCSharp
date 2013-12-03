using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BasicContacts {

    public class FBSearchVM : BaseVM {
        public FBSearchVM(string access_token) {
            AccessToken = access_token;
        }

        protected HttpClient _Client = new HttpClient {
            BaseAddress = new Uri("https://graph.facebook.com/"),
            DefaultRequestHeaders = { { "accept", "application/json" } }
        };

        public DelegateCommand UpdateCurrentCommand {
            get { return new DelegateCommand(() => { }); }
        }
        public DelegateCommand AddNewCommand {
            get {
                return new DelegateCommand(() => { });
            }
        }

        public string AccessToken { get; set; }

        private string _SearchTerm;
        public string SearchTerm {
            get { return _SearchTerm; }
            set {
                _SearchTerm = value;
                OnPropertyChanged();
                Search(value);
            }
        }
        private string _Log;
        public string Log {
            get { return _Log; }
            set { _Log = value; OnPropertyChanged(); }
        }

        private object _FBData;
        public object FBData {
            get { return _FBData; }
            set { _FBData = value; OnPropertyChanged(); }
        }

        private Xceed.Wpf.Toolkit.WindowState _windowState = Xceed.Wpf.Toolkit.WindowState.Closed;
        public Xceed.Wpf.Toolkit.WindowState WindowState {
            get { return _windowState; }
            set {
                _windowState = value;
                OnPropertyChanged();
            }
        }

        private SearchType _SearchType;
        public SearchType SearchType {
            get { return _SearchType; }
            set {
                _SearchType = value;
                OnPropertyChanged();
                Search(SearchTerm);
            }
        }


        async void Search(string searchTerm) {
            HttpResponseMessage response= null;
            if (searchTerm == null) return;
            try {
                if (SearchType == BasicContacts.SearchType.Everyone) {
                    response = await _Client.GetAsync("/search?q=" + searchTerm + "&type=user&fields=id,name,username&limit=10&access_token=" + AccessToken);
                }
                else if (SearchType == BasicContacts.SearchType.Bing) {
                    var bing = new BingServiceReference.Bing.BingSearchContainer(new Uri("https://api.datamarket.azure.com/Bing/Search/v1/"));
                    bing.WebResultSet.Where(x => x.Title == "");
                }
                else {
                    var fql = "SELECT uid, name, username FROM user WHERE uid IN (SELECT uid2 FROM friend WHERE uid1 = me()) AND strpos(lower(name), lower('" + searchTerm + "'))>=0";
                    response = await _Client.GetAsync("/fql?q=" + fql + "&limit=10&access_token=" + AccessToken);
                }
                FBData = await response.Content.ReadAsAsync<FBSearch>();
                Log = await response.Content.ReadAsStringAsync();
            }
            catch (Exception) {
            }
        }
    }

    public enum SearchType {
        Everyone, Friends, Bing
    }

    public class MatchConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value != null && value.ToString().Equals(parameter))
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (true.Equals(value))
                return parameter;
            return null;
        }
    }

    public class FormatConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return string.Format(parameter.ToString(), value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }

    public class FBSearch {
        public FBSearchItem[] data { get; set; }
        public Paging paging { get; set; }
    }


    public class FBSearchItem {
        public string id { get; set; }
        public string uid { get; set; }
        public FBEndPoint from { get; set; }
        public string story { get; set; }
        public string username { get; set; }
        public string picture { get; set; }
        public string link { get; set; }
        public string source { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Property1[] properties { get; set; }
        public string icon { get; set; }
        public Privacy privacy { get; set; }
        public string type { get; set; }
        public string object_id { get; set; }
        public FBApplication application { get; set; }
        public DateTime created_time { get; set; }
        public DateTime updated_time { get; set; }
        public string message { get; set; }
        public FBAction[] actions { get; set; }
        public Likes likes { get; set; }
        public string caption { get; set; }
        public To to { get; set; }
        public Message_Tags3 message_tags { get; set; }
        public Shares shares { get; set; }
    }





    public class Message_Tags3 {
        public Message_Tag[][] Tags { get; set; }
    }

    public class Message_Tag {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int offset { get; set; }
        public int length { get; set; }
    }


    public class Property1 {
        public string name { get; set; }
        public string text { get; set; }
        public string href { get; set; }
    }

}
