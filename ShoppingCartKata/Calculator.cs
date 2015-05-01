using System.Linq;

namespace ShoppingCartKata
{
    public class Calculator
    {
        private readonly IPrice _price;

        public Calculator(IPrice price)
        {
            _price = price;
        }

        public decimal Sum(string[] scannedItems)
        {
            return scannedItems.Sum(scannedItem => _price.Item(scannedItem));
        }
    }
}