using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GuitarShackShop.Web.Pages
{
    public class Checkout : PageModel
    {
        public Basket Basket { get; private set; }

        public void OnGet()
        {
            string basketJson = HttpContext.Session.GetString("basket");
            Basket = JsonConvert.DeserializeObject<Basket>(basketJson);
        }
    }
}