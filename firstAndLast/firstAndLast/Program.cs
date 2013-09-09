

using System.Net.Http;
namespace firstAndLast
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");
            //System.Console.ReadLine();
            System.Console.WriteLine("What is your username");
            var response = System.Console.ReadLine();
            System.Console.WriteLine("Here's your profile info");
            System.Console.Write(GetProfile(response));
            System.Console.ReadLine();
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

