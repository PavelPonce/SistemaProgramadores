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
    public class AlumnosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Alumnos
        public ActionResult Index()
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre");
            ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre");
            var tbAlumnos = db.tbAlumnos.Include(t => t.tbPersonas).Include(t => t.tbTitulos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbCentrosEducativos).Include(t => t.tbCentrosEducativos1);
            return View(tbAlumnos.ToList());
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
            ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre");
            ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre");
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perso_Id,CenEd_IdColegio,CenEd_IdUniversidad,Titul_Id,Alumn_UsuarioCreacion,Alumn_FechaCreacion,Alumn_UsuarioModificacion,Alumn_FechaModificacion,Alumn_Estado,Alumn_Observaciones,Alumn_FechaIngreso,Gener_Id")] tbAlumnos tbAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.tbAlumnos.Add(tbAlumnos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
            ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
            ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
            ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
            return View(tbAlumnos);
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
            ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
            ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
            ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
            return View(tbAlumnos);
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perso_Id,CenEd_IdColegio,CenEd_IdUniversidad,Titul_Id,Alumn_UsuarioCreacion,Alumn_FechaCreacion,Alumn_UsuarioModificacion,Alumn_FechaModificacion,Alumn_Estado,Alumn_Observaciones,Alumn_FechaIngreso,Gener_Id")] tbAlumnos tbAlumnos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbAlumnos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
            ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
            ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
            ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
            ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
            ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
            return View(tbAlumnos);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            if (tbAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(tbAlumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
            db.tbAlumnos.Remove(tbAlumnos);
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
