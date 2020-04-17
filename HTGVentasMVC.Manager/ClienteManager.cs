using System;
using System.Collections.Generic;
using System.Linq;
using HTGVentasMVC.Models.ViewModels.Cliente;
using HTGVentasMVC.Models;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Manager
{
    public class ClienteManager
    {
        public List<ClienteVM> lista()
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var lista = ctx.cliente.Select(x => new ClienteVM
                {
                    idCliente = x.idCliente,
                    nombre = x.nombre,
                    apPaterno = x.apPaterno,
                    apMaterno=x.apMaterno,
                    direccion=x.direccion,
                    telefono=x.telefono,
                    dni=x.dni

                }).ToList();
                return lista;
            }
        }
        public cliente Obtener(decimal id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.cliente
                    .Where(x => x.idCliente == id)
                    .SingleOrDefault();
                return obj;
            }
        }

        public void Insertar(cliente obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
            }
        }
        public void Modificar(cliente obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Eliminar(decimal id)
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
