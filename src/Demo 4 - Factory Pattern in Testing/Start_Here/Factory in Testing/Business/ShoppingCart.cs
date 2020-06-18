using Factory_Pattern_in_Testing.Business.Models.Commerce;
using Factory_Pattern_in_Testing.Business.Models.Shipping;
using System;

namespace Factory_Pattern_in_Testing.Business
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
