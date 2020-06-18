using Factory_Pattern_in_Testing.Business.Models.Commerce;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Invoice;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Summary;
using Factory_Pattern_in_Testing.Business.Models.Shipping;
using Factory_Pattern_in_Testing.Business.Models.Shipping.Factories;

namespace Factory_Pattern_in_Testing.Business
{
    public class AustraliaPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            return new GSTInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            var shippingProviderFactory = new StandardShippingProviderFactory();

            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            return new CsvSummary();
        }
    }
}
