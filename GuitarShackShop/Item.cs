namespace GuitarShackShop
{
    public class Item
    {
        public Product Product { get; }
        public int Quantity { get; set; }

        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}