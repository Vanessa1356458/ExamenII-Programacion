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
    public class FacturaController : Controller
    {
        private Context db = new Context();

        // GET: Factura
        public ActionResult Index()
        {
            var facturas = db.Facturas.Include(f => f.Cliente);
            return View(facturas.ToList());
        }

        // GET: Factura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Factura/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Codigo");
            return View();
        }

        // POST: Factura/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacturaId,ClienteId,Fecha,Subtotal,TotalIVA,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Facturas.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Codigo", factura.ClienteId);
            return View(factura);
        }

        // GET: Factura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Codigo", factura.ClienteId);
            return View(factura);
        }

        // POST: Factura/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacturaId,ClienteId,Fecha,Subtotal,TotalIVA,Total")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "ClienteId", "Codigo", factura.ClienteId);
            return View(factura);
        }

        // GET: Factura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = db.Facturas.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Factura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Factura factura = db.Facturas.Find(id);
            db.Facturas.Remove(factura);
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
