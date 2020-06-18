using Adding_a_Factory_Provider.Business.Models.Commerce;
using Adding_a_Factory_Provider.Business.Models.Commerce.Invoice;
using Adding_a_Factory_Provider.Business.Models.Commerce.Summary;
using Adding_a_Factory_Provider.Business.Models.Shipping;
using Adding_a_Factory_Provider.Business.Models.Shipping.Factories;

namespace Adding_a_Factory_Provider.Business
{
    public class SwedenPurchaseProviderFactory : IPurchaseProviderFactory
    {
        public IInvoice CreateInvoice(Order order)
        {
            if(order.Recipient.Country != order.Sender.Country)
            {
                return new NoVATInvoice();
            }

            return new VATInvoice();
        }

        public ShippingProvider CreateShippingProvider(Order order)
        {
            ShippingProviderFactory shippingProviderFactory;

            if(order.Sender.Country != order.Recipient.Country)
            {
                shippingProviderFactory = new GlobalExpressShippingProviderFactory();
            }
            else
            {
                shippingProviderFactory = new StandardShippingProviderFactory();
            }

            return shippingProviderFactory.CreateShippingProvider(order.Sender.Country);
        }

        public ISummary CreateSummary(Order order)
        {
            // Translate email to Swedish
            return new EmailSummary();
        }
    }
}
