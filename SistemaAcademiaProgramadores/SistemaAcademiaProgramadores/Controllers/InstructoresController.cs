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
    public class InstructoresController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Instructores
        public ActionResult Index()
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            var tbInstructores = db.tbInstructores.Include(t => t.tbPersonas).Include(t => t.tbTitulos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbInstructores.ToList());
        }

        // GET: Instructores/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructores tbInstructores = db.tbInstructores.Find(id);
            if (tbInstructores == null)
            {
                return HttpNotFound();
            }
            return View(tbInstructores);
        }

        // GET: Instructores/Create
        public ActionResult Create()
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: Instructores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perso_Id,Titul_Id,CenEd_Id,Instr_UsuarioCreacion,Instr_FechaCreacion,Instr_UsuarioModificacion,Instr_FechaModificacion,Instr_Estado")] tbInstructores tbInstructores)
        {
            if (ModelState.IsValid)
            {
                db.tbInstructores.Add(tbInstructores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
            ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
            ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
            return View(tbInstructores);
        }

        // GET: Instructores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructores tbInstructores = db.tbInstructores.Find(id);
            if (tbInstructores == null)
            {
                return HttpNotFound();
            }
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
            ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
            ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
            return View(tbInstructores);
        }

        // POST: Instructores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perso_Id,Titul_Id,CenEd_Id,Instr_UsuarioCreacion,Instr_FechaCreacion,Instr_UsuarioModificacion,Instr_FechaModificacion,Instr_Estado")] tbInstructores tbInstructores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbInstructores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
            ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
            ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
            return View(tbInstructores);
        }

        // GET: Instructores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructores tbInstructores = db.tbInstructores.Find(id);
            if (tbInstructores == null)
            {
                return HttpNotFound();
            }
            return View(tbInstructores);
        }

        // POST: Instructores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbInstructores tbInstructores = db.tbInstructores.Find(id);
            db.tbInstructores.Remove(tbInstructores);
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
