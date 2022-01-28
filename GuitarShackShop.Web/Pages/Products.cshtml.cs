using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarShackShop.Web.Pages
{
    public class Products : PageModel
    {
        private ProductList _productList;

        public void OnGet()
        {
            _productList = new SessionBasket(new HttpContextAccessor().HttpContext.Session).GetProductList();
        }

        public ProductList ProductList => _productList;
    }
}