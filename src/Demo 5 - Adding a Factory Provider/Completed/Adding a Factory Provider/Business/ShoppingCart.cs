using Adding_a_Factory_Provider.Business.Models.Commerce;
using Adding_a_Factory_Provider.Business.Models.Shipping;
using System;

namespace Adding_a_Factory_Provider.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly IPurchaseProviderFactory purchaseProviderFactory;

        public ShoppingCart(Order order, IPurchaseProviderFactory purchaseProviderFactory)
        {
            this.order = order;
            this.purchaseProviderFactory = purchaseProviderFactory;
        }

        public string Finalize()
        {
            if(order.ShippingStatus == ShippingStatus.ReadyForShippment)
            {
                throw new InvalidOperationException();
            }

            var shippingProvider = purchaseProviderFactory.CreateShippingProvider(order);

            var invoice = purchaseProviderFactory.CreateInvoice(order);

            // Send invoice

            invoice.GenerateInvoice();

            var summary = purchaseProviderFactory.CreateSummary(order);

            summary.Send();

            // Send summary

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
