using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaAcademiaProgramadores.Attributes;
using SistemaAcademiaProgramadores.Models;

namespace SistemaAcademiaProgramadores.Controllers
{
    [CustomAuthorize]
    public class UsuariosController : Controller
    {

        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Usuarios
        public ActionResult Index()
        {
            try
            {
                ViewBag.Instr_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion");
                var tbUsuarios = db.tbUsuarios.Include(t => t.tbInstructores2).Include(t => t.tbRoles2).Include(t => t.tbUsuarios2).Include(t => t.tbUsuarios3);
                return View(tbUsuarios.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
                if (tbUsuarios == null)
                {
                    return HttpNotFound();
                }
                return View(tbUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Instr_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion");
                ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usuar_Id,Usuar_Usuario,Usuar_Contrasena,Usuar_UltimaSesion,Instr_Id,Roles_Id,Usuar_Admin,Usuar_UsuarioCreacion,Usuar_FechaCreacion,Usuar_UsuarioModificacion,Usuar_FechaModificacion,Usuar_Estado")] tbUsuarios tbUsuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tbUsuarios.Add(tbUsuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Instr_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbUsuarios.Instr_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuarios.Roles_Id);
                ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioCreacion);
                ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioModificacion);
                return View(tbUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
                if (tbUsuarios == null)

                {
                    return HttpNotFound();
                }
                ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbUsuarios.Instr_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuarios.Roles_Id);
                ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioCreacion);
                ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioModificacion);
                return View(tbUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usuar_Id,Usuar_Usuario,Usuar_Contrasena,Usuar_UltimaSesion,Instr_Id,Roles_Id,Usuar_Admin,Usuar_UsuarioCreacion,Usuar_FechaCreacion,Usuar_UsuarioModificacion,Usuar_FechaModificacion,Usuar_Estado")] tbUsuarios tbUsuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbUsuarios).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbUsuarios.Instr_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbUsuarios.Roles_Id);
                ViewBag.Usuar_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioCreacion);
                ViewBag.Usuar_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbUsuarios.Usuar_UsuarioModificacion);
                return View(tbUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
                if (tbUsuarios == null)
                {
                    return HttpNotFound();
                }
                return View(tbUsuarios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
                db.tbUsuarios.Remove(tbUsuarios);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
