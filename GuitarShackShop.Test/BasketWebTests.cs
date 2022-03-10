using NUnit.Framework;

namespace GuitarShackShop.Test
{
    public class BasketWebTests : BasketTestsBase
    {
        private readonly WebBasketDriver _webBasketDriver;

        public BasketWebTests()
        {
            _webBasketDriver = new WebBasketDriver();
            Basket = _webBasketDriver;
        }

        [TearDown]
        public void CloseBrowser()
        {
            _webBasketDriver.Quit();
        }
            
    }
}