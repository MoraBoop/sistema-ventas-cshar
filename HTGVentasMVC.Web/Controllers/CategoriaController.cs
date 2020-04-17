using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HTGVentasMVC.Manager;
using HTGVentaMVC.Utils;
using HTGVentasMVC.Models;
using System.Web.Mvc;

namespace HTGVentasMVC.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private categoria Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.categoria
                    .Where(x => x.idCategoria == id)
                    .SingleOrDefault();
                return obj;
            }
        }
        // GET: Products
        public ActionResult Index()
        {
            return View(new CategoriasManager().lista());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.op = MisConstantes.INSERT;
            ViewBag.cate = new SelectList(new CategoriasManager().lista(), "IdCategoria", "Nombre");
            return View("Create");

        }

        [HttpPost]
        public ActionResult Create(categoria obj)
        {
            if (ModelState.IsValid)
            {
                new CategoriasManager().Insertar(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", obj);
            }

        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.op = MisConstantes.EDIT;
            return View("Create");
            
        }
        [HttpPost]
        public ActionResult Update(categoria obj)
        {
            if (ModelState.IsValid)
            {
                new CategoriasManager().Modificar(obj);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", obj);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                categoria obj = Obtener(id);
                ctx.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}