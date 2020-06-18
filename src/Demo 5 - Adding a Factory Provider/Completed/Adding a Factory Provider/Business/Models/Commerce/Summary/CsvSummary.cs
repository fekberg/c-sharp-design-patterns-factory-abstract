namespace Adding_a_Factory_Provider.Business.Models.Commerce.Summary
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
