using System.Collections.Generic;
using Olimpia.Model.View;

namespace Olimpia.Business.Interface
{
    public interface IInvoiceServices
    {
        string AddInvoices(IEnumerable<ViewInvoice> invoices);
    }
}