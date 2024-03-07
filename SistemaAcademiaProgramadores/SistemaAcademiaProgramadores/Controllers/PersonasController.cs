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
    public class PersonasController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Personas
        public ActionResult Index()
        {
            var tbPersonas = db.tbPersonas.Include(t => t.tbAlumnos).Include(t => t.tbInstructores).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbEstadosCiviles).Include(t => t.tbMunicipios);
            return View(tbPersonas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersonas tbPersonas = db.tbPersonas.Find(id);
            if (tbPersonas == null)
            {
                return HttpNotFound();
            }
            return View(tbPersonas);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.Perso_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones");
            ViewBag.Perso_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id");
            ViewBag.Perso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Perso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
            ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perso_Id,Perso_PrimerNombre,Perso_SegundoNombre,Perso_PrimerApellido,Perso_SegundoApellido,Perso_FechaNacimiento,Perso_Sexo,Estci_Id,Perso_Direccion,Munic_Id,Perso_Telefono,Perso_CorreoElectronico,Perso_UsuarioCreacion,Perso_FechaCreacion,Perso_UsuarioModificacion,Perso_FechaModificacion,Perso_Estado")] tbPersonas tbPersonas)
        {
            if (ModelState.IsValid)
            {
                db.tbPersonas.Add(tbPersonas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Perso_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbPersonas.Perso_Id);
            ViewBag.Perso_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbPersonas.Perso_Id);
            ViewBag.Perso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioCreacion);
            ViewBag.Perso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioModificacion);
            ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion", tbPersonas.Estci_Id);
            ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbPersonas.Munic_Id);
            return View(tbPersonas);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersonas tbPersonas = db.tbPersonas.Find(id);
            if (tbPersonas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Perso_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbPersonas.Perso_Id);
            ViewBag.Perso_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbPersonas.Perso_Id);
            ViewBag.Perso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioCreacion);
            ViewBag.Perso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioModificacion);
            ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion", tbPersonas.Estci_Id);
            ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbPersonas.Munic_Id);
            return View(tbPersonas);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perso_Id,Perso_PrimerNombre,Perso_SegundoNombre,Perso_PrimerApellido,Perso_SegundoApellido,Perso_FechaNacimiento,Perso_Sexo,Estci_Id,Perso_Direccion,Munic_Id,Perso_Telefono,Perso_CorreoElectronico,Perso_UsuarioCreacion,Perso_FechaCreacion,Perso_UsuarioModificacion,Perso_FechaModificacion,Perso_Estado")] tbPersonas tbPersonas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPersonas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Perso_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbPersonas.Perso_Id);
            ViewBag.Perso_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbPersonas.Perso_Id);
            ViewBag.Perso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioCreacion);
            ViewBag.Perso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPersonas.Perso_UsuarioModificacion);
            ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion", tbPersonas.Estci_Id);
            ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbPersonas.Munic_Id);
            return View(tbPersonas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPersonas tbPersonas = db.tbPersonas.Find(id);
            if (tbPersonas == null)
            {
                return HttpNotFound();
            }
            return View(tbPersonas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPersonas tbPersonas = db.tbPersonas.Find(id);
            db.tbPersonas.Remove(tbPersonas);
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
