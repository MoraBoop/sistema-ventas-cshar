using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Models.ViewModels.Factura
{
    public class FacturaVM
    {
        public decimal numFactura { get; set; }
        public DateTime fecha { get; set; }

        public float IVA { get; set; }

        public float total { get; set; }

        public int numPago { get; set; }
        public decimal? descuento { get; set; }
    }
}
