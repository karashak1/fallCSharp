

using System.Net.Http;
using System.Linq;
namespace firstAndLast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //display items 
            var db = new DataAccess.ContactModelContainer();
            var keywords = db.Keywords;
            foreach (var k in keywords) {
                System.Console.WriteLine("{0} - {1}", k.Parent.Name, k.Name);
            }
            System.Console.ReadLine();
            //add item
            System.Console.WriteLine("Enter a contact in the following format (FirstName LastName Phone)");
            var results = System.Console.ReadLine();
            var values = results.Split();
            var contact = new DataAccess.Contact {FirstName = values[0], LastName = values[1], KeywordsId = 5 };
            db.Contacts.Add(contact);
            contact.ContractMethods.Add(new DataAccess.ContactMethod { Contact = 8, Value= values[2] });
            db.SaveChanges();
            /*
            System.Console.WriteLine("Hello World");
            //System.Console.ReadLine();
            System.Console.WriteLine("What is your username");
            var response = System.Console.ReadLine();
            System.Console.WriteLine("Here's your profile info");
            System.Console.Write(GetProfile(response)+"\n");

            var db = new DataAccess.Test1Entities();
            foreach (var item in db.Contacts) {
                System.Console.WriteLine(item.FirstName + " " + item.LastName);
            }
            System.Console.ReadLine();
             */ 
        }

        public static string GetProfile(string username)
        {
            var client = new HttpClient();

            var json = client.GetStringAsync("http://graph.facebook.com/" + username).Result;
            return json;
        }
    }

    public delegate int Multiply(int x, int y);

    public class Dog {
        private string _DogsWord = "woof";
        private System.Collections.Generic.List<string> _ListOfWords = new System.Collections.Generic.List<string>();

        public string DogsWord {
            get {
                return _DogsWord;
            }
            set { 
                _DogsWord = value; 
            }
        } 

        public string Speed { get; set; }

        public string Bark() {
            return _DogsWord + string.Join(",", _ListOfWords);
        }

        public void LearnNewWord(string word) {
            _ListOfWords.Add(word);

            //int hello = _ListOfWords[1];
        }

        public string Run() {
            return "I am running at " + Speed + " Miles per Hour";
        }
    }
}

