using System.Collections.Generic;

namespace ShoppingCartKata
{
    public class Pricing : ICalculate
    {
        private readonly PricingList _pricingList;
        private readonly Discount[] _discounts;

        public Pricing(PricingList pricingList, Discount[] discounts)
        {
            _pricingList = pricingList;
            _discounts = discounts;
        }

        public Discount[] Discounts()
        {
            return _discounts;
        }

        public decimal Sum(string[] scannedItems)
        {
            var sum = 0m;

            var discountBuffer = new Dictionary<string, int>();
            var discountedItems = new List<string>();
            foreach (var scannedItem in scannedItems)
            {
                if(!discountBuffer.ContainsKey(scannedItem))
                    discountBuffer.Add(scannedItem, 0);
            }

            foreach (var discount in _discounts)
            {
                foreach (var scannedItem in scannedItems)
                {

                    if (scannedItem != discount.Item)
                        continue;

                    discountBuffer[scannedItem] += 1;

                    if (discountBuffer[scannedItem] != discount.Count) 
                        continue;
                    
                    sum += discount.Price;

                    for (var i = 0; i < discount.Count; i++)
                        discountedItems.Add(scannedItem);

                    discountBuffer[scannedItem] = 0;
                }
            }

            foreach (var scannedItem in scannedItems)
            {
                if (discountedItems.Contains(scannedItem))
                {
                    discountedItems.Remove(scannedItem);
                    continue;
                }
                sum += _pricingList.Item(scannedItem);
            }

            return sum;
        }
    }
}