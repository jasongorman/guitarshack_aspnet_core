using System.Collections.Generic;
using NUnit.Framework;

namespace GuitarShackShop.Test
{
    public class BasketModelDriver : IBasketDriver
    {
        private Basket _basket;
        private ProductList _products;

        public double Total => _basket.Total;

        public void New()
        {
            _products = new ProductList(new List<Product>()
            {
                new Product() { Id = 1, Description = "Epiphone Les Paul Classic", Price = 399.95, Stock = 5 },
                new Product() { Id = 2, Description = "Fender Player Stratocaster", Price = 579.00, Stock = 1  },
                new Product() { Id = 3, Description = "Ibanez Tube Screamer", Price = 195.00, Stock = 0 },
                new Product() { Id = 4, Description = "Boss Katana 100W", Price = 279.00, Stock = 12 }
            });
            _basket = new Basket();
        }

        public void Add(int productId, int quantity)
        {
            _basket.Add(_products.GetProduct(productId), quantity);
        }
        
        public int ItemQuantity(int index)
        {
            return _basket.Items[index].Quantity;
        }

        public int Stock(int productId)
        {
            return _products.GetProduct(productId).Stock;
        }
        
        public bool? AddIsAllowed(int productId)
        {
            try
            {
                Add(productId, 1);
                return true;
            }
            catch (OutOfStockException e)
            {
                return false;
            }
        }
    }
}