using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GuitarShackShop.Web.Pages
{
    public class Products : PageModel
    {
        private ProductList _productList = new ProductList();

        public void OnGet()
        {
            _productList = new ProductList();
        }

        public ProductList ProductList => _productList;
    }
}