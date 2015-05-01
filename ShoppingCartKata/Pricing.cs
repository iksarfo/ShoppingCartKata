using System.Linq;

namespace ShoppingCartKata
{
    public class Pricing : ICalculate
    {
        private readonly Discount[] _discounts;

        public Pricing(Discount[] discounts)
        {
            _discounts = discounts;
        }

        public Discount[] Discounts()
        {
            return _discounts;
        }

        public decimal Sum(string[] scannedItems)
        {
            var sum = 0m;

            sum = _discounts.First().Price;

            return sum;
        }
    }
}