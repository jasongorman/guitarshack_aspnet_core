using NUnit.Framework;

namespace GuitarShackShop.Test
{
    public abstract class BasketTestsBase
    {
        protected IBasketDriver Basket;

        [Test]
        public void TotalOfEmptyBasket()
        {
            Basket.New();
            Assert.AreEqual(0.0, Basket.Total);
        }

        [Test]
        public void TotalOfSingleItem()
        {
            Basket.New();
            Basket.Add(1, 1);
            Assert.AreEqual(399.95, Basket.Total);
        }

        [Test]
        public void TotalOfTwoItems()
        {
            Basket.New();
            Basket.Add(1, 1);
            Basket.Add(2, 1);
            Assert.AreEqual(978.95, Basket.Total, 0.001);
        }

        [Test]
        public void TotalOfItemWithQuantityOfTwo()
        {
            Basket.New();
            Basket.Add(1, 1);
            Basket.Add(1, 1);
            Assert.AreEqual(799.9, Basket.Total);
            Assert.AreEqual(2, Basket.ItemQuantity(0));
        }

        [Test]
        public void AddingProductToBasketReducesStock()
        {
            Basket.New();
            Basket.Add(1, 1);
            Assert.AreEqual(4, Basket.Stock(1));
        }

        [Test]
        public void CannotAddOutOfStockProductToBasket()
        {
            Basket.New();
            Assert.False(Basket.AddIsAllowed(3));
        }
    }
}