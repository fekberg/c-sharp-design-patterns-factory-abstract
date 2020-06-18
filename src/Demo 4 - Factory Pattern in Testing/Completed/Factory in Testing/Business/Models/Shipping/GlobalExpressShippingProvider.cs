using Factory_Pattern_in_Testing.Business.Models.Commerce;

namespace Factory_Pattern_in_Testing.Business.Models.Shipping
{
    public class GlobalExpressShippingProvider : ShippingProvider
    {
        public override string GenerateShippingLabelFor(Order order)
        {
            return "GLOBAL-EXPRESS";
        }
    }
}
