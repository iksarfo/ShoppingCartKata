using NUnit.Framework;

namespace ShoppingCartKata
{
/*
        
     * Step 1: Shopping cart

        ● You are building a checkout system for a shop which only sells apples and oranges.

        ● Apples cost 60p and oranges cost 25p.

        ● Build a checkout system which takes a list of items scanned at the till and outputs the total cost

        ● For example: [ Apple, Apple, Orange, Apple ] => £2.05

        ● Make reasonable assumptions about the inputs to your solution; for example, many candidates take a list of strings as input
    
 
     * Step 2: Simple offers

        ● The shop decides to introduce two new offers

        ○ buy one, get one free on Apples

        ○ 3 for the price of 2 on Oranges

*/
    [TestFixture]
    public class CheckoutTests
    {
        [TestCase("apple", 1)]
        [TestCase("apple,orange", 2)]
        public void AcceptsItems(string items, int expectedCount)
        {
            var checkout = new Checkout();
            var scannedItems = checkout.Scan(items);
            Assert.That(scannedItems.Length, Is.EqualTo(expectedCount));
        }
    }

    public class Checkout
    {
        public string[] Scan(string items)
        {
            return items.Split(new []{ ',' });
        }
    }
}
