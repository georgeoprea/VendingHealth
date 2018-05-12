using Newtonsoft.Json;
using System;

namespace VendingHealthClientApp
{
    public class Product
    {
        [JsonProperty(PropertyName = "image")]
        public Uri ImageUri { get; set; }

        public int Kcal { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }
    }
}