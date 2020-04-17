using System.Collections.Generic;
using System.Linq;
using HTGVentasMVC.Models.ViewModels.Categoria;
using HTGVentasMVC.Models;
namespace HTGVentasMVC.Manager { 

   public class CategoriasManager
    {
        public List<CategoriaVM> lista()
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var lista = ctx.categoria.Select(x => new CategoriaVM
                {
                    idCategoria = x.idCategoria,
                    nombre = x.nombre,
                    descripcion = x.descripcion

                }).ToList();
                return lista;
            }
        }
        public categoria Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.categoria
                    .Where(x => x.idCategoria == id)
                    .SingleOrDefault();
                return obj;
            }
        }

        public void Insertar(categoria obj)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Added;
                ctx.SaveChanges();
            }
        }
        public void Modificar(categoria obj)
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