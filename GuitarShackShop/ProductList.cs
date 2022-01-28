using System.Collections.Generic;

namespace GuitarShackShop
{
    public class ProductList
    {
        public List<Product> Products
        {
            get;
            set;
        }

        public ProductList()
        {
        }

        public ProductList(List<Product> products)
        {
            Products = products;
        }

        public Product GetProduct(int productId)
        {
            return Products.Find(p => p.Id == productId);
        }
    }
}