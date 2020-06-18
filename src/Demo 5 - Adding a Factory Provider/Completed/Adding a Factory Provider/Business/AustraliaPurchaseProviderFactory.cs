using Adding_a_Factory_Provider.Business.Models.Commerce;
using Adding_a_Factory_Provider.Business.Models.Commerce.Invoice;
using Adding_a_Factory_Provider.Business.Models.Commerce.Summary;
using Adding_a_Factory_Provider.Business.Models.Shipping;
using Adding_a_Factory_Provider.Business.Models.Shipping.Factories;

namespace Adding_a_Factory_Provider.Business
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
