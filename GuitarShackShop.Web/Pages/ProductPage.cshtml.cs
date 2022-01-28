using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GuitarShackShop.Web.Pages
{
    public class ProductPage : PageModel
    {
        private Product _product;
        private SessionBasket _sessionBasket;

        public Product Product => _product;
        public bool AddToBasketEnabled => _product.Stock > 0;

        public void OnGet()
        {
            _sessionBasket = new SessionBasket(HttpContext.Session);
            ProductList productList = _sessionBasket.GetProductList();
            
            int productId = Int32.Parse(Request.Query["id"]);
            string action = Request.Query["action"];

            _product = productList.GetProduct(productId);

            if (action != null)
            {
                AddToBasket(_product);
            }
            
            _sessionBasket.SetProductList(productList);

        }

        private void AddToBasket(Product product)
        {
            var basket = _sessionBasket.GetBasket();

            basket.Add(product, 1);
            _sessionBasket.SetBasket(basket);
        }


    }
}