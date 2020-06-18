using System.Text;

namespace Factory_Pattern_in_Testing.Business.Models.Commerce.Invoice
{
    public class GSTInvoice : IInvoice
    {
        public byte[] GenerateInvoice()
        {
            return Encoding.Default.GetBytes("Hello world from a VAT Invoice");
        }
    }
}
