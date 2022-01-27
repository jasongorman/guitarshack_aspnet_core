using System.Collections.Generic;

namespace GuitarShackShop
{
    public class ProductList
    {
        private readonly List<Product> _products;
        public List<Product> Products => _products;

        public ProductList()
        {
            _products = new List<Product>()
            {
                new Product() { Id = 1, Description = "Epiphone Les Paul Classic", Price = 399.95, Stock = 5 },
                new Product() { Id = 2, Description = "Fender Player Stratocaster", Price = 579.00, Stock = 1  },
                new Product() { Id = 3, Description = "Ibanez Tube Screamer", Price = 195.00, Stock = 0 },
                new Product() { Id = 4, Description = "Boss Katana 100W", Price = 279.00, Stock = 12 }
            };
        }

        public Product GetProduct(int productId)
        {
            return _products.Find(p => p.Id == productId);
        }
    }
}