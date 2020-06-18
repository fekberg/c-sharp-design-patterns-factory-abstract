using Factory_Pattern_in_Testing.Business.Models.Commerce;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Invoice;
using Factory_Pattern_in_Testing.Business.Models.Commerce.Summary;
using Factory_Pattern_in_Testing.Business.Models.Shipping;

namespace Factory_Pattern_in_Testing.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }
}
