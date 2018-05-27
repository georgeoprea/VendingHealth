using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace VendingHealthClientApp
{
    public class UserInfo
    {

        public User GetUser(string username, string password)
        {
            HttpWebRequest firebaseRequest = (HttpWebRequest)WebRequest.Create("https://vendinghealth-alpha.firebaseio.com/Users.json");

            WebResponse response = firebaseRequest.GetResponse();

            Stream objStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string jsonResponse = objReader.ReadToEnd();
            JObject jObject = JObject.Parse(jsonResponse);

            
            foreach (JToken userToken in jObject.Children())
                foreach (JToken userDetailsToken in userToken.Children())
                {
                    string foundUsername = userDetailsToken.SelectToken("username").ToString();
                    string foundPassword = userDetailsToken.SelectToken("password").ToString();

                    if (username == foundUsername && password == foundPassword)
                        return userDetailsToken.ToObject<User>();
                }

            return null;

        }

        static void Main()
        {
            User user = new UserInfo().GetUser("jee_kuu", "pass");
        }

    }
}
