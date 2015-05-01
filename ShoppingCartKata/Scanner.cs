namespace ShoppingCartKata
{
    public interface IScan
    {
        string[] Scan(string items);
    }

    public class Scanner : IScan
    {
        public string[] Scan(string items)
        {
            return items.Split(new []{ ',' });
        }
    }
}