using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationExamen.Database;
using WebApplicationExamen.Models;

namespace WebApplicationExamen.Controllers
{
    public class FacturaDetalleController : Controller
    {
        private Context db = new Context();

        // GET: FacturaDetalle
        public ActionResult Index()
        {
            var facturaDetalles = db.FacturaDetalles.Include(f => f.Factura).Include(f => f.Servicio);
            return View(facturaDetalles.ToList());
        }

        // GET: FacturaDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Create
        public ActionResult Create()
        {
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId");
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Codigo");
            return View();
        }

        // POST: FacturaDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaDetalleId,FacturaId,ServicioId,Precio,Cantidad,ISV,TotalLinea")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.FacturaDetalles.Add(facturaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Codigo", facturaDetalle.ServicioId);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Codigo", facturaDetalle.ServicioId);
            return View(facturaDetalle);
        }

        // POST: FacturaDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaDetalleId,FacturaId,ServicioId,Precio,Cantidad,ISV,TotalLinea")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacturaId = new SelectList(db.Facturas, "FacturaId", "FacturaId", facturaDetalle.FacturaId);
            ViewBag.ServicioId = new SelectList(db.Servicios, "ServicioId", "Codigo", facturaDetalle.ServicioId);
            return View(facturaDetalle);
        }

        // GET: FacturaDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            if (facturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(facturaDetalle);
        }

        // POST: FacturaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FacturaDetalle facturaDetalle = db.FacturaDetalles.Find(id);
            db.FacturaDetalles.Remove(facturaDetalle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
