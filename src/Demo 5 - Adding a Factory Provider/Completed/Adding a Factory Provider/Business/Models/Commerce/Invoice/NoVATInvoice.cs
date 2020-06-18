using System.Text;

namespace Adding_a_Factory_Provider.Business.Models.Commerce.Invoice
{
    public class NoVATInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a NO VAT invoice");
        }
    }
}
