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
    public class UsuariosController : Controller
    {
        private dbAcademiaProgramadoresEntities db = new dbAcademiaProgramadoresEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var tbUsuarios = db.tbUsuarios.Include(t => t.tbInstructore).Include(t => t.tbRole).Include(t => t.tbUsuario1).Include(t => t.tbUsuario2);
            return View(tbUsuarios.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuarios.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Instr_Telefono");
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion");
            ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuar_Id,Usuar_Usuario,Usuar_Contrasena,Usuar_Correo,Usuar_UltimaSesion,Instr_Id,Roles_Id,Usuar_Admin,Usuar_UsuarioCreacion,Usuar_FechaCreacion,Usuar_UsuarioModificacion,Usuar_FechaModificacion,Usuar_Estado")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuarios.Add(tbUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Instr_Telefono", tbUsuario.Instr_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuario.Roles_Id);
            ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioCreacion);
            ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioModificacion);
            return View(tbUsuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuarios.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Instr_Telefono", tbUsuario.Instr_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuario.Roles_Id);
            ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioCreacion);
            ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioModificacion);
            return View(tbUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuar_Id,Usuar_Usuario,Usuar_Contrasena,Usuar_Correo,Usuar_UltimaSesion,Instr_Id,Roles_Id,Usuar_Admin,Usuar_UsuarioCreacion,Usuar_FechaCreacion,Usuar_UsuarioModificacion,Usuar_FechaModificacion,Usuar_Estado")] tbUsuario tbUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Instr_Telefono", tbUsuario.Instr_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuario.Roles_Id);
            ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioCreacion);
            ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuario.Usuar_UsuarioModificacion);
            return View(tbUsuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuario tbUsuario = db.tbUsuarios.Find(id);
            if (tbUsuario == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsuario tbUsuario = db.tbUsuarios.Find(id);
            db.tbUsuarios.Remove(tbUsuario);
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
