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
    public class PantallasPorRolesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: PantallasPorRoles
        public ActionResult Index()
        {
            var tbPantallasPorRoles = db.tbPantallasPorRoles.Include(t => t.tbPantallas).Include(t => t.tbRoles).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbPantallasPorRoles.ToList());
        }

        // GET: PantallasPorRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
            if (tbPantallasPorRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbPantallasPorRoles);
        }

        // GET: PantallasPorRoles/Create
        public ActionResult Create()
        {
            ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion");
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion");
            ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: PantallasPorRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Papro_Id,Panta_Id,Roles_Id,Papro_UsuarioCreacion,Papro_FechaCreacion,Papro_UsuarioModificacion,Papro_FechaModificacion")] tbPantallasPorRoles tbPantallasPorRoles)
        {
            if (ModelState.IsValid)
            {
                db.tbPantallasPorRoles.Add(tbPantallasPorRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
            ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
            ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
            return View(tbPantallasPorRoles);
        }

        // GET: PantallasPorRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
            if (tbPantallasPorRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
            ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
            ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
            return View(tbPantallasPorRoles);
        }

        // POST: PantallasPorRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Papro_Id,Panta_Id,Roles_Id,Papro_UsuarioCreacion,Papro_FechaCreacion,Papro_UsuarioModificacion,Papro_FechaModificacion")] tbPantallasPorRoles tbPantallasPorRoles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPantallasPorRoles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
            ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
            ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
            ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
            return View(tbPantallasPorRoles);
        }

        // GET: PantallasPorRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
            if (tbPantallasPorRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbPantallasPorRoles);
        }

        // POST: PantallasPorRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
            db.tbPantallasPorRoles.Remove(tbPantallasPorRoles);
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
