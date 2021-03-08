using System;
using System.Collections.Generic;
using System.Linq;
using Olimpia.Business.Interface;
using Olimpia.Business.Util;
using Olimpia.Model.Exceptions;
using Olimpia.Model.Model;
using Olimpia.Model.View;

namespace Olimpia.Business.Services
{
    public class InvoiceServices : IInvoiceServices
    {
        public string AddInvoices(IEnumerable<ViewInvoice> invoices)
        {
            try
            {
                ValidationInvoice validation = new ValidationInvoice(invoices);
                validation.ValidateRepeated();
                validation.ValidateItems();
                return $"La sumatoria de todas las facturas es de {validation.CalculateAmount().ToString("#,###")}";
            }
            catch (InvoiceException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Se genero un error, {ex.ToString()}");
            }
        }
    }
}