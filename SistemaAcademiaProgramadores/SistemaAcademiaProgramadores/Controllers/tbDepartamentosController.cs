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
    public class tbDepartamentosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: tbDepartamentos
        public ActionResult Index()
        {
            var tbDepartamentos = db.tbDepartamentos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbDepartamentos.ToList());
        }

        // GET: tbDepartamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Create
        public ActionResult Create()
        {
            ViewBag.Depar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Depar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: tbDepartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Depar_Id,Depar_Descripcion,Depar_UsuarioCreacion,Depar_FechaCreacion,Depar_UsuarioModificacion,Depar_FechaModificacion,Depar_Estado")] tbDepartamentos tbDepartamentos)
        {
            ModelState.Remove("Depar_UsuarioModificacion");
            ModelState.Remove("Depar_UsuarioCreacion");
            ModelState.Remove("Depar_FechaCreacion");
            ModelState.Remove("Depar_FechaModificacion");
            tbDepartamentos.Depar_UsuarioCreacion = 1;
            tbDepartamentos.Depar_FechaCreacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.tbDepartamentos.Add(tbDepartamentos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Depar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioCreacion);
            ViewBag.Depar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioModificacion);
            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Depar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioCreacion);
            ViewBag.Depar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioModificacion);
            return View(tbDepartamentos);
        }

        // POST: tbDepartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Depar_Id,Depar_Descripcion,Depar_UsuarioCreacion,Depar_FechaCreacion,Depar_UsuarioModificacion,Depar_FechaModificacion,Depar_Estado")] tbDepartamentos tbDepartamentos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbDepartamentos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Depar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioCreacion);
            ViewBag.Depar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbDepartamentos.Depar_UsuarioModificacion);
            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: tbDepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            db.tbDepartamentos.Remove(tbDepartamentos);
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
