using System.Collections.Generic;

namespace XURentalSystem
{
    public class Inventory
    {
        private InventoryManager inventoryManager;
        public List<Product> Products;

        public Inventory()
        {
            inventoryManager = new InventoryManager();
            Products = new List<Product>();
            Load();
        }

        public void addProduct(Product product)
        {
            Products.Add(product);
            Save();
        }

        public void RemoveProduct(int product)
        {
            Products.RemoveAt(product);
            Save();
        }

        private void Load()
        {
            Products = inventoryManager.LoadProduct();
        }

        private void Save()
        {
            inventoryManager.SaveProducts(Products);
        }
    }
}