using System.Linq;

namespace ShoppingCartKata
{
    public interface ICalculate
    {
        decimal Sum(string[] scannedItems);
    }

    public class SimplePricing : ICalculate
    {
        private readonly IPrice _price;

        public SimplePricing(IPrice price)
        {
            _price = price;
        }

        public decimal Sum(string[] scannedItems)
        {
            return scannedItems.Sum(scannedItem => _price.Item(scannedItem));
        }
    }
}