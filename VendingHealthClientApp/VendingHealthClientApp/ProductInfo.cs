using System.Diagnostics;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace VendingHealthClientApp
{
    public class ProductInfo
    {
        public Product[] GetProducts()
        {
            HttpWebRequest firebaseRequest = (HttpWebRequest)WebRequest.Create("https://vendinghealth-alpha.firebaseio.com/Products.json");

            WebResponse response = firebaseRequest.GetResponse();

            Stream objStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string jsonResponse = objReader.ReadToEnd();
            JObject jObject = JObject.Parse(jsonResponse);

            int i = 0;
            Product[] products = new Product[jObject.Count];

            foreach (JToken productToken in jObject.Children()) {
                JToken productDescriptionToken = productToken.First;
                products[i] = (Product)productDescriptionToken.ToObject<Product>();
                i++;
            }   

            return products;

        }

        static void Main()
        {
            Product[] products = new ProductInfo().GetProducts();
            Debug.WriteLine(products[0].Name);
            Debug.WriteLine(products[1].Name);

        }
    }
}
