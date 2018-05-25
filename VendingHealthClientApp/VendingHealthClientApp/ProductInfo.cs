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
            HttpWebRequest firebaseRequest = (HttpWebRequest)WebRequest.Create("https://vendinghealth-alpha.firebaseio.com/.json");

            WebResponse response = firebaseRequest.GetResponse();

            Stream objStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(objStream);

            string jsonResponse = objReader.ReadToEnd();
            JObject jObject = JObject.Parse(jsonResponse);
            JToken product1 = jObject.SelectToken("Products['1 ']");
            JToken product2 = jObject.SelectToken("Products['2 ']");

            Product[] products = new Product[2];

            products[0] = (Product)product1.ToObject<Product>();
            products[1] = (Product)product2.ToObject<Product>();

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
