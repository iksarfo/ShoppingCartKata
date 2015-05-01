namespace ShoppingCartKata
{
    public class CheckoutResult
    {
        public string[] Items { get; private set; }
        public decimal TotalCost { get; private set; }

        public CheckoutResult(string[] items, decimal totalCost)
        {
            Items = items;
            TotalCost = totalCost;
        }
    }
}