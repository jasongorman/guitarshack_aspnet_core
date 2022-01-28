using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GuitarShackShop.Web
{
    public class SessionBasket
    {
        private readonly ISession _session;

        public SessionBasket(ISession session)
        {
            _session = session;
        }

        public Basket GetBasket()
        {
            string basketJson = _session.GetString("basket");
            Basket basket;

            if (basketJson == null)
            {
                basket = new Basket();

                SetBasket(basket);
            }
            else
            {
                basket = JsonConvert.DeserializeObject<Basket>(basketJson);
            }

            return basket;
        }

        public ProductList GetProductList()
        {
            string productsJson = _session.GetString("products");
            ProductList products;

            if (productsJson == null)
            {
                products = new ProductList(new List<Product>()
                {
                    new Product() { Id = 1, Description = "Epiphone Les Paul Classic", Price = 399.95, Stock = 5 },
                    new Product() { Id = 2, Description = "Fender Player Stratocaster", Price = 579.00, Stock = 1  },
                    new Product() { Id = 3, Description = "Ibanez Tube Screamer", Price = 195.00, Stock = 0 },
                    new Product() { Id = 4, Description = "Boss Katana 100W", Price = 279.00, Stock = 12 }
                });
                SetProductList(products);
            }
            else
            {
                products = JsonConvert.DeserializeObject<ProductList>(productsJson);
            }

            return products;
        }

        public void SetBasket(Basket basket)
        {
            _session.SetString("basket", JsonConvert.SerializeObject(basket));
        }

        public void SetProductList(ProductList productList)
        {
            _session.SetString("products", JsonConvert.SerializeObject(productList));
        }
    }
}