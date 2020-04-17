using System;
using System.Collections.Generic;
using System.Linq;
using HTGVentasMVC.Models.ViewModels.DetalleVena;
using HTGVentasMVC.Models;
using System.Text;
using System.Threading.Tasks;

namespace HTGVentasMVC.Manager
{
    public class DetallleVentaManager
    {
        public List<DetallleVentaManager> lista()
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var lista = ctx.producto.Select(x => new DetallleVentaManager
                {
                    idProducto = x.idProducto,
                    nombre = x.nombre,
                    precioUnitario = x.precioUnitario,

                    categoria = x.categoria.nombre

                }).ToList();
                return lista;
            }
        }
        public producto Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.producto
                    .Where(x => x.idProducto == id)
                    .SingleOrDefault();
                return obj;
            }
        }

        public void Insertar(producto obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
            }
        }
        public void Modificar(producto obj)
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
