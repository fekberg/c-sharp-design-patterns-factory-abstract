namespace Adding_a_Factory_Provider.Business.Models.Commerce.Summary
{
    public class EmailSummary : ISummary
    {
        public string CreateOrderSummary(Order order)
        {
            return $"This is an email summary";

        }
        public void Send() { }
    }
}
