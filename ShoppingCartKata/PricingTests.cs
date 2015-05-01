using NUnit.Framework;

namespace ShoppingCartKata
{
    [TestFixture]
    public class PricingTests
    {
        [Test]
        public void PricesItems()
        {
            var pricer = new PricingList("apple,60;orange,25");
            var itemPrice = PricingList.Item("apple");
            Assert.That(itemPrice, Is.EqualTo(0.60m));
        }
    }
}