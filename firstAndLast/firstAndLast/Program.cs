

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
}

