using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea2_acceso_premier.Models;

namespace Tarea2_acceso_premier.Controllers
{
    public class Acceso_PremierController : Controller
    {
        private Tarea2Entities db = new Tarea2Entities();

        // GET: Acceso_Premier
        public ActionResult Index()
        {
            var acceso_Premier = db.Acceso_Premier.Include(a => a.Pelicula).Include(a => a.Persona);
            return View(acceso_Premier.ToList());
        }

        // GET: Acceso_Premier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso_Premier acceso_Premier = db.Acceso_Premier.Find(id);
            if (acceso_Premier == null)
            {
                return HttpNotFound();
            }

            return View(acceso_Premier);
        }

        // GET: Acceso_Premier/Create
        public ActionResult Create()
        {
            ViewBag.Nombre_pelicula = new SelectList(db.Pelicula, "Nombre", "Nombre");
            ViewBag.idPersona = new SelectList(db.Persona, "Idpersona", "Idpersona");
            return View();
        }

        // POST: Acceso_Premier/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idapremier,Nombre_pelicula,idPersona")] Acceso_Premier acceso_Premier)
        {
            if (ModelState.IsValid)
            {
                db.Acceso_Premier.Add(acceso_Premier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nombre_pelicula = new SelectList(db.Pelicula, "Nombre", "Nombre", acceso_Premier.Nombre_pelicula);
            ViewBag.idPersona = new SelectList(db.Persona, "Idpersona", "Idpersona", acceso_Premier.idPersona);
            return View(acceso_Premier);
        }

        // GET: Acceso_Premier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso_Premier acceso_Premier = db.Acceso_Premier.Find(id);
            if (acceso_Premier == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nombre_pelicula = new SelectList(db.Pelicula, "Nombre", "Nombre", acceso_Premier.Nombre_pelicula);
            ViewBag.idPersona = new SelectList(db.Persona, "Idpersona", "Idpersona", acceso_Premier.idPersona);
            return View(acceso_Premier);
        }

        // POST: Acceso_Premier/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idapremier,Nombre_pelicula,idPersona")] Acceso_Premier acceso_Premier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acceso_Premier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nombre_pelicula = new SelectList(db.Pelicula, "Nombre", "Nombre", acceso_Premier.Nombre_pelicula);
            ViewBag.idPersona = new SelectList(db.Persona, "Idpersona", "Idpersona", acceso_Premier.idPersona);
            return View(acceso_Premier);
        }

        // GET: Acceso_Premier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Acceso_Premier acceso_Premier = db.Acceso_Premier.Find(id);
            if (acceso_Premier == null)
            {
                return HttpNotFound();
            }
            return View(acceso_Premier);
        }

        // POST: Acceso_Premier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Acceso_Premier acceso_Premier = db.Acceso_Premier.Find(id);
            db.Acceso_Premier.Remove(acceso_Premier);
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
