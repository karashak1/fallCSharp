//using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace BasicContacts {
    public class RestWindowVM : BaseVM{

        private string _Log;

        public string Log {
            get { return _Log; }
            set { _Log = value; OnPropertyChanged(); }
        }

        

        public RestWindowVM() {
            var client = new HttpClient();
            //client.BaseAddress = new Uri("https://api.stackexchange.com/2.1/");
            //Log = client.GetStringAsync("questions?site=stackoverflow").Result;
            var formatter = new JsonMediaTypeFormatter();
            client.BaseAddress = new Uri("https://graph.facebook.com");
            var str = client.GetStringAsync("jewpaltz").Result;
            var ob = Newtonsoft.Json.JsonConvert.DeserializeObject<FBuser>(str);
            Log = ob.Name+ob.link + ob.id;

        }
    }

    public class FBuser {
        public string Name { get; set; }
        public long id { get; set; }
        public string link { get; set; }
    }
}
