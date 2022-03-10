using System.Collections.Generic;
using System.Collections.Immutable;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GuitarShackShop.Test
{
    public class WebBasketDriver : IBasketDriver
    {
        private WebDriver _webDriver;
        public void New()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Navigate().GoToUrl(HOME_PAGE);
        }

        private const string HOME_PAGE = "http://localhost:5000/";

        public void Add(int productId, int quantity)
        {
            IWebElement productsLink = _webDriver.FindElement(By.PartialLinkText("Products"));
            productsLink.Click();
            
            IWebElement productLink = _webDriver.FindElement(By.XPath("//a[contains(@href, 'id=" + productId + "')]"));
            productLink.Click();

            IWebElement addToBasketButton = _webDriver.FindElement(By.Id("add_to_basket"));

            while (quantity > 0)
            {
                addToBasketButton.Click();
                quantity--;
            }
        }

        public int ItemQuantity(int index)
        {
            IWebElement basketLink = _webDriver.FindElement(By.PartialLinkText("Basket"));
            basketLink.Click();

            IReadOnlyCollection<IWebElement> quantities = _webDriver.FindElements(By.Id("quantity"));
            
            return int.Parse(quantities.ToImmutableList()[index].Text);
        }

        public int Stock(int productId)
        {
            _webDriver.Navigate().GoToUrl("http://localhost:5000/ProductPage?id=" + productId);
            IWebElement stock = _webDriver.FindElement(By.Id("stock"));
            return int.Parse(stock.Text);
        }

        public bool? AddIsAllowed(int productId)
        {
            _webDriver.Navigate().GoToUrl("http://localhost:5000/ProductPage?id=" + productId);
            IWebElement addToBasketButton = _webDriver.FindElement(By.Id("add_to_basket"));
            return addToBasketButton.Enabled;
        }

        public double Total
        {
            get
            {
                _webDriver.Navigate().GoToUrl("http://localhost:5000/Checkout");
                IWebElement total = _webDriver.FindElement(By.Id("total"));
                return double.Parse(total.GetAttribute("value"));
            }
        }

        public void Quit()
        {
            _webDriver.Quit();
        }
    }
}