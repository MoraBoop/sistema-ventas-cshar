using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTGVentasMVC.Models.ViewModels.Vendedor;
using HTGVentasMVC.Models;

namespace HTGVentasMVC.Manager
{
    public class VendedorManager
    {
        public List<VendedorVM> lista()
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var lista = ctx.vendedor.Select(x => new VendedorVM
                {
                    idVendedor = x.idVendedor,
                    nombre = x.nombre,
                    apPaterno = x.apPaterno,
                    apMaterno = x.apMaterno,
                    dni=x.dni,
                    telefono=x.telefono
                }).ToList();
                return lista;
            }
        }
        public vendedor Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.vendedor
                    .Where(x => x.idVendedor == id)
                    .SingleOrDefault();
                return obj;
            }
        }

        public void Insertar(vendedor obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
            }
        }
        public void Modificar(vendedor obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Eliminar(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = Obtener(id);
                ctx.Entry(obj).State =
                    System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}

