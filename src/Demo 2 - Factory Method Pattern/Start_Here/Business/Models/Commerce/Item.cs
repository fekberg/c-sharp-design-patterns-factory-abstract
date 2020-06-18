namespace Factory_Method_Pattern.Business.Models.Commerce
{
    public class Item
    {
        public string Id { get; }
        public string Name { get; }
        public decimal Price { get; }

        public Item(string id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}