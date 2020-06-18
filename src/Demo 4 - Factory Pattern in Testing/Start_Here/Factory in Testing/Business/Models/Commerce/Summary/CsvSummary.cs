namespace Factory_Pattern_in_Testing.Business.Models.Commerce.Summary
{
    public class CsvSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return "This is a CSV summary";
        }

        public void Send() { }
    }
}
