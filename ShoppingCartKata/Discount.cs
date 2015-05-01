namespace ShoppingCartKata
{
    public class Discount
    {
        public decimal Price { get; private set; }

        public Discount(string itemName, int itemCount, decimal price)
        {
            Price = price;
        }
    }
}