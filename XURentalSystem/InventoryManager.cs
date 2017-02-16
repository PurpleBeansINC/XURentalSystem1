using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace XURentalSystem
{
    internal class InventoryManager
    {
        private string dataPath = "Inventory.json";

        public void SaveProducts(List<Product> productsToSave)
        {
            if (!File.Exists(dataPath))
                File.Create(dataPath);

            string json = JsonConvert.SerializeObject(productsToSave);

            File.WriteAllText(dataPath, json);
        }

        public List<Product> LoadProduct()
        {
            List<Product> listOfProducts = new List<Product>();

            if (File.Exists(dataPath))
            {
                string json = File.ReadAllText("Inventory.json");
                if (!string.IsNullOrWhiteSpace(json))
                {
                    listOfProducts = JsonConvert.DeserializeObject<List<Product>>(json);
                }
            }

            return listOfProducts;
        }
    }
}