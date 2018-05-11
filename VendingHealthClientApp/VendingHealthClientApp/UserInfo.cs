using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VendingHealthClientApp
{
    public class UserInfo
    {
        private HttpWebRequest firebaseRequest = (HttpWebRequest)WebRequest.Create("https://vendinghealth-alpha.firebaseio.com/.json");

        public User GetUser(string username)
        {
            WebResponse response = firebaseRequest.GetResponse();

            Stream objStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string jsonResponse = objReader.ReadToEnd();
            JObject jObject = JObject.Parse(jsonResponse);
            JToken usersJToken = jObject.SelectToken("Users");

            foreach (JToken userToken in usersJToken.Children())
                foreach (JToken userDetailsToken in userToken.Children())
                {
                    //"['" + username + "']"
                    string foundUsername = userDetailsToken.SelectToken("username").ToString();
                    if (username == foundUsername)
                        return userDetailsToken.ToObject<User>();
                }

            return null;

        }

        static void Main()
        {
            User user = new UserInfo().GetUser("jee_kuu");
        }

    }
}
