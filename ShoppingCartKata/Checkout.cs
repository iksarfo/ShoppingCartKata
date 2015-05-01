namespace ShoppingCartKata
{
    public class Checkout
    {
        private readonly ICalculate _calculator;

        public Checkout(ICalculate calculator)
        {
            _calculator = calculator;
        }

        public CheckoutResult Complete(string[] items)
        {
            return new CheckoutResult(items, _calculator.Sum(items));
        }
    }
}