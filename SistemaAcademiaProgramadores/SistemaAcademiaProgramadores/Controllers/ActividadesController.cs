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
    public class ActividadesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Actividades
        public ActionResult Index()
        {
            var tbActividades = db.tbActividades.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbActividades.ToList());
        }

        // GET: Actividades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividades tbActividades = db.tbActividades.Find(id);
            if (tbActividades == null)
            {
                return HttpNotFound();
            }
            return View(tbActividades);
        }

        // GET: Actividades/Create
        public ActionResult Create()
        {
            ViewBag.Activ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Activ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: Actividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Activ_Id,Activ_Nombre,Activ_UsuarioCreacion,Activ_FechaCreacion,Activ_UsuarioModificacion,Activ_FechaModificacion,Activ_Estado")] tbActividades tbActividades)
        {
            if (ModelState.IsValid)
            {
                db.tbActividades.Add(tbActividades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Activ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioCreacion);
            ViewBag.Activ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioModificacion);
            return View(tbActividades);
        }

        // GET: Actividades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividades tbActividades = db.tbActividades.Find(id);
            if (tbActividades == null)
            {
                return HttpNotFound();
            }
            ViewBag.Activ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioCreacion);
            ViewBag.Activ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioModificacion);
            return View(tbActividades);
        }

        // POST: Actividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Activ_Id,Activ_Nombre,Activ_UsuarioCreacion,Activ_FechaCreacion,Activ_UsuarioModificacion,Activ_FechaModificacion,Activ_Estado")] tbActividades tbActividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbActividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Activ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioCreacion);
            ViewBag.Activ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividades.Activ_UsuarioModificacion);
            return View(tbActividades);
        }

        // GET: Actividades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividades tbActividades = db.tbActividades.Find(id);
            if (tbActividades == null)
            {
                return HttpNotFound();
            }
            return View(tbActividades);
        }

        // POST: Actividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbActividades tbActividades = db.tbActividades.Find(id);
            db.tbActividades.Remove(tbActividades);
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
