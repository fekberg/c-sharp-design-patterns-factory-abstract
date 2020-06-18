using Abstract_Factory_Pattern.Business.Models.Commerce;
using Abstract_Factory_Pattern.Business.Models.Shipping;
using Abstract_Factory_Pattern.Business.Models.Shipping.Factories;
using System;

namespace Abstract_Factory_Pattern.Business
{
    public class ShoppingCart
    {
        private readonly Order order;
        private readonly ShippingProviderFactory shippingProviderFactory;

        public ShoppingCart(Order order, ShippingProviderFactory shippingProviderFactory)
        {
            this.order = order;
            this.shippingProviderFactory = shippingProviderFactory;
        }

        public string Finalize()
        {
            var shippingProvider = shippingProviderFactory.CreateShippingProvider(order.Sender.Country);

            order.ShippingStatus = ShippingStatus.ReadyForShippment;

            return shippingProvider.GenerateShippingLabelFor(order);
        }
    }
}
