using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTGVentasMVC.Manager;
using HTGVentaMVC.Utils;
using HTGVentasMVC.Models;


namespace HTGVentasMVC.Web.Controllers
{
    public class ProductoController : Controller
    {
        private producto Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.producto
                    .Where(x => x.idProducto == id)
                    .SingleOrDefault();
                return obj;
            }
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(new ProductoManager().lista()); 
        }
        [HttpGet]
        
        public ActionResult Create()
        {
            ViewBag.op = MisConstantes.INSERT;
            ViewBag.cate = new SelectList(new CategoriasManager().lista(), "IdCategoria", "Nombre");
            return View("Create", new producto());

        }

        [HttpPost]
        public ActionResult Create(producto obj)
        {
            if (ModelState.IsValid)
            {
                new ProductoManager().Insertar(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", obj);
            }

        }

        [HttpGet]
        public ActionResult Update(String id)
        {
            ViewBag.op = MisConstantes.EDIT;
            ViewBag.cate = new SelectList(new CategoriasManager().lista(), "IdCategoria", "Nombre");
            return View("Create", new ProductoManager().Obtener(id));
            
        }
        [HttpPost]
        public ActionResult Update(producto obj)
        {
            if (ModelState.IsValid)
            {
                new ProductoManager().Modificar(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", obj);
            }
        }

        [HttpGet]
        public ActionResult Delete(String id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                producto obj = Obtener(id);
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }


    }

}

