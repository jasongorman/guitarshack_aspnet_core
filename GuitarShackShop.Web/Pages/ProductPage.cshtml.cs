using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GuitarShackShop.Web.Pages
{
    public class ProductPage : PageModel
    {
        private Product _product;

        public Product Product => _product;

        public void OnGet()
        {
            ProductList productList = new ProductList();
            
            int productId = Int32.Parse(Request.Query["id"]);
            string action = Request.Query["action"];

            _product = productList.GetProduct(productId);
            
            if (action != null)
                AddToBasket(_product);
        }

        private void AddToBasket(Product product)
        {
            var sessionBasket = new SessionBasket(HttpContext.Session);
            var basket = sessionBasket.GetBasket();

            basket.Add(product, 1);
            sessionBasket.SetBasket(basket);
        }


    }
}