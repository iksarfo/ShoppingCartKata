namespace ShoppingCartKata
{
    public class Discount
    {
        public string Item { get; private set; }
        public int Count { get; private set; }
        public decimal Price { get; private set; }

        public Discount(string item, int count, decimal price)
        {
            Item = item;
            Count = count;
            Price = price;
        }
    }
}