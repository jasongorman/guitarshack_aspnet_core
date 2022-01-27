using NUnit.Framework;

namespace GuitarShackShop.Test
{
    public class BasketTests
    {

        [Test]
        public void TotalOfEmptyBasket()
        {
            Basket basket = new Basket();
            Assert.AreEqual(0.0, basket.Total);
        }

        [Test]
        public void TotalOfSingleItem()
        {
            Basket basket = new Basket();
            basket.Add(new Product() { Price = 399.95 }, 1);
            Assert.AreEqual(399.95, basket.Total);
        }
        
        [Test]
        public void TotalOfTwoItems()
        {
            Basket basket = new Basket();
            basket.Add(new Product() { Id = 1, Price = 399.95 }, 1);
            basket.Add(new Product() { Id = 2, Price = 579.00 }, 1);
            Assert.AreEqual(978.95, basket.Total);
        }
        
        [Test]
        public void TotalOfItemWithQuantityOfTwo()
        {
            Basket basket = new Basket();
            basket.Add(new Product() { Id = 1, Price = 399.95 }, 1);
            basket.Add(new Product() { Id = 1, Price = 399.95 }, 1);
            Assert.AreEqual(799.9, basket.Total);
            Assert.AreEqual(2, basket.Items[0].Quantity);
        }
    }
}