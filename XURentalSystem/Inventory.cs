using System.Collections.Generic;

namespace XURentalSystem
{
    internal class Inventory
    {
        public List<Product> Products;

        public Inventory()
        {
            Products = new List<Product>();
        }

        public void addProduct(Product product)
        {
            Products.Add(product);
        }

        private void Load()
        {
        }

        private void Save()
        {
        }
    }
}