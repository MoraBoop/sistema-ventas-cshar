using System.Collections.Generic;
using System.Linq;
using HTGVentasMvc.Models.ViewModels.Productos;
using HTGVentasMVC.Models;

namespace HTGVentasMVC.Manager
{
    public class ProductoManager
    {
 public List<ProductosVM> lista()
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var lista = ctx.producto.Select(x => new ProductosVM
                {
                    idProducto = x.idProducto,
                    nombre = x.nombre,
                    precioUnitario = x.precioUnitario,
                   
                    categoria = x.categoria.nombre
                  
                }).ToList();
                return lista;
            }
        }
        public producto Obtener (string id)
        {
            using (var ctx =new HTGVentasMVCConect())
            {
                var obj = ctx.producto
                    .Where(x => x.idProducto == id)
                    .SingleOrDefault();
                return obj;
            }
        } 

        public void  Insertar(producto obj)
        {
            using (var ctx =new HTGVentasMVCConect())
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
