using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Models.ViewModels.Vendedor
{
   public class VendedorVM
    {
        public string idVendedor { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
    }
}
