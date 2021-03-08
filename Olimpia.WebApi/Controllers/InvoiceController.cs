using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Olimpia.Business.Interface;
using Olimpia.Model.View;

namespace Olimpia.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices invoiceServices;
        public InvoiceController(IInvoiceServices invoiceServices)
        {
            this.invoiceServices = invoiceServices;
        }

        /// <summary>
        /// Este web api esta construido para recibir un listado de facturas, el modelo que es mapeado como factura es ViewInvoice.
        /// </summary>
        /// <param name="idOffice">Id de la oficina</param>
        /// <param name="service">Instancia del servicio INewAttentionService inyectado en el archivo Startup.cs</param>
        /// <returns>Un objecto con perfiles de atención (profiles) y puestos de atención (stands).</returns>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] IEnumerable<ViewInvoice> invoices)
        {
            try
            {
                return Ok(this.invoiceServices.AddInvoices(invoices));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}