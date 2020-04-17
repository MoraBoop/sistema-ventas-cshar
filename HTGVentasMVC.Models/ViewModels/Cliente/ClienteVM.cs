using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Models.ViewModels.Cliente
{
   public class ClienteVM
    {
        public decimal idCliente { get; set; }
        public string nombre { get; set; }
        public string apPaterno { get; set; }
        public string apMaterno { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public decimal dni { get; set; }
       
    }
}
