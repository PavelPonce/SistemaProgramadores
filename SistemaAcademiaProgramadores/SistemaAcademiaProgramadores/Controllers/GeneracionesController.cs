using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAcademiaProgramadores.Models;

namespace SistemaAcademiaProgramadores.Controllers
{
    public class GeneracionesController : Controller
    {
        private dbAcademiaProgramadoresEntities db = new dbAcademiaProgramadoresEntities();

        // GET: Generaciones
        public ActionResult Index()
        {
            var tbGeneraciones = db.tbGeneraciones.Include(t => t.tbUsuario).Include(t => t.tbUsuario1);
            return View(tbGeneraciones.ToList());
        }

        // GET: Generaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneracione tbGeneracione = db.tbGeneraciones.Find(id);
            if (tbGeneracione == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneracione);
        }

        // GET: Generaciones/Create
        public ActionResult Create()
        {
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: Generaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gener_Id,Gener_Nombre,Gener_Anhio,Gener_UsuarioCreacion,Gener_FechaCreacion,Gener_UsuarioModificacion,Gener_FechaModificacion,Gener_Estado")] tbGeneracione tbGeneracione)
        {
            if (ModelState.IsValid)
            {
                db.tbGeneraciones.Add(tbGeneracione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioModificacion);
            return View(tbGeneracione);
        }

        // GET: Generaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneracione tbGeneracione = db.tbGeneraciones.Find(id);
            if (tbGeneracione == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioModificacion);
            return View(tbGeneracione);
        }

        // POST: Generaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gener_Id,Gener_Nombre,Gener_Anhio,Gener_UsuarioCreacion,Gener_FechaCreacion,Gener_UsuarioModificacion,Gener_FechaModificacion,Gener_Estado")] tbGeneracione tbGeneracione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbGeneracione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneracione.Gener_UsuarioModificacion);
            return View(tbGeneracione);
        }

        // GET: Generaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneracione tbGeneracione = db.tbGeneraciones.Find(id);
            if (tbGeneracione == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneracione);
        }

        // POST: Generaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbGeneracione tbGeneracione = db.tbGeneraciones.Find(id);
            db.tbGeneraciones.Remove(tbGeneracione);
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
