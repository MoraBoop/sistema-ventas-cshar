using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Models.ViewModels.Venta
{
    public class VentaVM
    {
        public decimal idVenta { get; set; }
        public float total { get; set; }
        public decimal idCliente { get; set; }
        public string idVendedor { get; set; }
        public DateTime fecha { get; set; }
        public decimal IVA { get; set; }
    }
}
