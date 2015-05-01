using System;
using System.Collections.Generic;

namespace ShoppingCartKata
{
    public interface IPrice
    {
        decimal Item(string name);
    }

    public class PricingList : IPrice
    {
        private readonly string _prices;

        public PricingList(string prices)
        {
            _prices = prices;
        }

        public decimal Item(string name)
        {
            var priceList = new Dictionary<string, decimal>();
            var itemPrices = _prices.Split(new[] {';'});
            foreach (var itemPrice in itemPrices)
            {
                var item = itemPrice.Split(new[] {','})[0];
                var price = itemPrice.Split(new[] {','})[1];

                priceList.Add(item, Convert.ToDecimal(price));
            }

            return priceList[name];
        }
    }
}