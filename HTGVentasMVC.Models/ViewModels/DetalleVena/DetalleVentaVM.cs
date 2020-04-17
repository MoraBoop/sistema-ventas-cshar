using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Models.ViewModels.DetalleVena
{
    public class DetalleVentaVM
    {
        public int idDetalle { get; set; }
        public decimal numFactura { get; set; }
        public decimal Venta { get; set; }
        public float subTotal { get; set; }
        public string Producto { get; set; }
        public decimal descuento { get; set; }
        public int cantidad { get; set; }
    }
}
