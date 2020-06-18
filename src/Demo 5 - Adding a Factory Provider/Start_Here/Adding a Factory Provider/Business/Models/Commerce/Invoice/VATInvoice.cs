using System.Text;

namespace Adding_a_Factory_Provider.Business.Models.Commerce.Invoice
{
    public class VATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a VAT Invoice");
        }
    }
}
