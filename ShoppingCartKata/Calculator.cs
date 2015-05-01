using System.Linq;

namespace ShoppingCartKata
{
    public interface ICalculate
    {
        decimal Sum(string[] scannedItems);
    }

    public class Calculator : ICalculate
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