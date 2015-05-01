namespace ShoppingCartKata
{
    public class Scanner
    {
        public string[] Scan(string items)
        {
            return items.Split(new []{ ',' });
        }
    }
}