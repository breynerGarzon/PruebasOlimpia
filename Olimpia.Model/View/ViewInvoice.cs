using System.ComponentModel.DataAnnotations;

namespace Olimpia.Model.View
{
    public class ViewInvoice
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El id se encuentra fuera del rango permitido.")]
        public int Id { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "El Nit es un campo que solo acepta valores númericos, intente nuevamente.")]
        public string Nit { get; set; }
        public string Descripcion { get; set; }
        [Required]
        [Range(0D, (double)decimal.MaxValue, ErrorMessage = "El ValorTotal debe ser un número positivo.")]
        public decimal ValorTotal { get; set; }
        [Required]
        [Range(0D, (double)1, ErrorMessage = "El valor del IVA es un valor entre 0(0%) y 1(100%)")]
        public double PorcentajeIVA { get; set; }
        
    }
}