using Factory_Pattern_in_Testing.Business.Models.Commerce;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Invoice;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Summary;
using Factory_Pattern_in_Testing.Business.Models.Shipping;
using Factory_Pattern_in_Testing.Business.Models.Shipping.Factories;

namespace Factory_Pattern_in_Testing.Business
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
