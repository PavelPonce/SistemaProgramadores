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
    public class tbGeneracionesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: tbGeneraciones
        public ActionResult Index()
        {
            var tbGeneraciones = db.tbGeneraciones.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbGeneraciones.ToList());
        }

        // GET: tbGeneraciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneraciones tbGeneraciones = db.tbGeneraciones.Find(id);
            if (tbGeneraciones == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneraciones);
        }

        // GET: tbGeneraciones/Create
        public ActionResult Create()
        {
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: tbGeneraciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gener_Id,Gener_Nombre,Gener_Anhio,Gener_UsuarioCreacion,Gener_FechaCreacion,Gener_UsuarioModificacion,Gener_FechaModificacion,Gener_Estado,Gener_FechaInicio,Gener_FechaFin")] tbGeneraciones tbGeneraciones)
        {
            if (ModelState.IsValid)
            {
                db.tbGeneraciones.Add(tbGeneraciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioModificacion);
            return View(tbGeneraciones);
        }

        // GET: tbGeneraciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneraciones tbGeneraciones = db.tbGeneraciones.Find(id);
            if (tbGeneraciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioModificacion);
            return View(tbGeneraciones);
        }

        // POST: tbGeneraciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gener_Id,Gener_Nombre,Gener_Anhio,Gener_UsuarioCreacion,Gener_FechaCreacion,Gener_UsuarioModificacion,Gener_FechaModificacion,Gener_Estado,Gener_FechaInicio,Gener_FechaFin")] tbGeneraciones tbGeneraciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbGeneraciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioCreacion);
            ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioModificacion);
            return View(tbGeneraciones);
        }

        // GET: tbGeneraciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneraciones tbGeneraciones = db.tbGeneraciones.Find(id);
            if (tbGeneraciones == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneraciones);
        }

        // POST: tbGeneraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbGeneraciones tbGeneraciones = db.tbGeneraciones.Find(id);
            db.tbGeneraciones.Remove(tbGeneraciones);
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
