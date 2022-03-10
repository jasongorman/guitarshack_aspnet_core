namespace GuitarShackShop.Test
{
    public interface IBasketDriver
    {
        void New();
        void Add(int productId, int quantity);
        int ItemQuantity(int index);
        int Stock(int productId);
        bool? AddIsAllowed(int productId);
        double Total { get; }
    }
}