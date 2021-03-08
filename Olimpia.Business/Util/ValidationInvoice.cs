using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olimpia.Model.Exceptions;
using Olimpia.Model.Model;
using Olimpia.Model.View;

namespace Olimpia.Business.Util
{
    public class ValidationInvoice
    {
        private readonly IEnumerable<ViewInvoice> invoices;
        public ValidationInvoice(IEnumerable<ViewInvoice> invoices)
        {
            this.invoices = invoices;
        }
        public void ValidateRepeated()
        {
            List<ViewError> repeatedInvoices = this.invoices
                                                    .GroupBy(invoice => invoice.Id)
                                                    .Select(invoice =>
                                                    new ViewError()
                                                    {
                                                        Id = invoice.Key,
                                                        Count = invoice.Count()
                                                    }).ToList();
            StringBuilder errors = new StringBuilder();
            repeatedInvoices.ForEach(invoice =>
            {
                if (invoice.Count > 1)
                {
                    errors.AppendLine($"La factura {invoice.Id} se encuentra presente {invoice.Count} veces dentro del listado de facturas");
                }
            });
            if (errors.Length > 0)
            {
                throw new InvoiceException(errors.ToString());
            }
        }

        public void ValidateItems()
        {
            foreach (var item in this.invoices)
            {
                this.ValidateInvoice(item);
            }
        }

        private void ValidateInvoice(ViewInvoice invoice)
        {
            this.ValidateInvoiceId(invoice.Id);
            this.ValidateInvoiceNIT(invoice.Nit, invoice.Id);
            this.ValidateInvoiceValor(invoice.ValorTotal, invoice.Id);
            this.ValidateInvoiceIVA(invoice.PorcentajeIVA, invoice.Id);
        }

        private void ValidateInvoiceId(int id)
        {
            if (id <= 0 || id > int.MaxValue)
            {
                throw new InvoiceException($"El id de para la factura es inválido {id}");
            }
        }

        private void ValidateInvoiceNIT(string nit, int id)
        {
            if (!int.TryParse(nit, out int n))
            {
                throw new InvoiceException($"El nit para la factura identificada con el Id {id}, es inválido, este debe ser solo númerico");
            }
        }

        private void ValidateInvoiceValor(decimal valor, int id)
        {
            if (valor < 0)
            {
                throw new InvoiceException($"El valor de la factura identificada con el Id {id}, es inválido");
            }
        }

        private void ValidateInvoiceIVA(double iva, int id)
        {
            if (iva < 0 || iva > 1d)
            {
                throw new InvoiceException($"El valor del IVA para la factura identificada con el Id {id}, es inválido, le recordamos que el valor permitido es entre 0(%) y 1(100%)");
            }
        }

        public decimal CalculateAmount()
        {
            return this.invoices
                            .Select(invoice => invoice.ValorTotal)
                            .Sum();
        }
    }
}