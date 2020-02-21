using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ActividadRealizarsController : Controller
    {
        private WebApplication1Context db = new WebApplication1Context();

        // GET: ActividadRealizars
        public ActionResult Index()
        {
            return View(db.ActividadRealizars.ToList());
        }

        // GET: ActividadRealizars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadRealizar actividadRealizar = db.ActividadRealizars.Find(id);
            if (actividadRealizar == null)
            {
                return HttpNotFound();
            }
            return View(actividadRealizar);
        }

        // GET: ActividadRealizars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActividadRealizars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,descripcion,estado")] ActividadRealizar actividadRealizar)
        {
            if (ModelState.IsValid)
            {
                db.ActividadRealizars.Add(actividadRealizar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actividadRealizar);
        }

        // GET: ActividadRealizars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadRealizar actividadRealizar = db.ActividadRealizars.Find(id);
            if (actividadRealizar == null)
            {
                return HttpNotFound();
            }
            return View(actividadRealizar);
        }

        // POST: ActividadRealizars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,descripcion,estado")] ActividadRealizar actividadRealizar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actividadRealizar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actividadRealizar);
        }

        // GET: ActividadRealizars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActividadRealizar actividadRealizar = db.ActividadRealizars.Find(id);
            if (actividadRealizar == null)
            {
                return HttpNotFound();
            }
            return View(actividadRealizar);
        }

        // POST: ActividadRealizars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActividadRealizar actividadRealizar = db.ActividadRealizars.Find(id);
            db.ActividadRealizars.Remove(actividadRealizar);
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
