using Adding_a_Factory_Provider.Business.Models.Commerce;
using Adding_a_Factory_Provider.Business.Models.Commerce.Invoice;
using Adding_a_Factory_Provider.Business.Models.Commerce.Summary;
using Adding_a_Factory_Provider.Business.Models.Shipping;

namespace Adding_a_Factory_Provider.Business
{
    public interface IPurchaseProviderFactory
    {
        ShippingProvider CreateShippingProvider(Order order);
        IInvoice CreateInvoice(Order order);
        ISummary CreateSummary(Order order);
    }
}
