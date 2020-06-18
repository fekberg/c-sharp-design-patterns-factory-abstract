namespace Factory_Pattern_in_Testing.Business.Models.Commerce.Summary
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
