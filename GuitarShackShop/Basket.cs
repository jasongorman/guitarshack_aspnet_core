using System.Collections.Generic;
using System.Linq;

namespace GuitarShackShop
{
    public class Basket
    {
        public List<Item> Items { get; } = new List<Item>();

        public void Add(Product product, int quantity)
        {
            Item item = Items.Find(it => it.Product.Id == product.Id);

            if (item == null)
            {
                item = new Item(product, 0);
                Items.Add(item);
            }

            item.Quantity += quantity;

        }

        public double Total => Items.Select(item => item.Product.Price * item.Quantity).Sum();
    }
}