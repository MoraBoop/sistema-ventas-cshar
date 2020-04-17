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
    public class VendedorController : Controller
    {

        private vendedor Obtener(string id)
        {
            using (var ctx = new HTGVentasMVCConect())
            {
                var obj = ctx.vendedor
                    .Where(x => x.idVendedor == id)
                    .SingleOrDefault();
                return obj;
            }
        }
        // GET: Vendedor
        public ActionResult Index()
        {
            return View(new VendedorController().lista());
        }
        [HttpGet]

        public ActionResult Create()
        {
            ViewBag.op = MisConstantes.INSERT;

            return View("Create", new vendedor());

        }

        [HttpPost]
        public ActionResult Create(vendedor obj)
        {
            if (ModelState.IsValid)
            {
                new VendedorManager().Insertar(obj);
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
            return View("Create", new VendedorManager().Obtener(id));
            //ViewBag.Operacion = "MODIFICAR";
            //return View("Formulario", Obtener(id));
        }
        [HttpPost]
        public ActionResult Update(vendedor obj)
        {
            if (ModelState.IsValid)
            {
                new VendedorManager().Modificar(obj);
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

