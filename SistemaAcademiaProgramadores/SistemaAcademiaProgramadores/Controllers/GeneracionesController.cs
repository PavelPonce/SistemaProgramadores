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
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Generaciones
        public ActionResult Index()
        {
            try
            {
                var tbGeneraciones = db.tbGeneraciones.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbGeneraciones.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Generaciones/Details/5
        public ActionResult Details(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Generaciones/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Generaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gener_Nombre,Gener_Anhio")] tbGeneraciones tbGeneraciones)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Generaciones_Insertar(tbGeneraciones.Gener_Nombre,tbGeneraciones.Gener_Anhio, int.Parse(Session["Usuar_Id"].ToString()),DateTime.Now, tbGeneraciones.Gener_FechaInicio);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioCreacion);
                ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioModificacion);
                return View(tbGeneraciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Generaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Generaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gener_Id,Gener_Nombre,Gener_Anhio,Gener_UsuarioCreacion,Gener_FechaInicio,Gener_FechaFin")] tbGeneraciones tbGeneraciones)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Generaciones_Modificar(tbGeneraciones.Gener_Id,tbGeneraciones.Gener_Nombre, tbGeneraciones.Gener_Anhio, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now, tbGeneraciones.Gener_FechaInicio, tbGeneraciones.Gener_FechaFin);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Gener_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioCreacion);
                ViewBag.Gener_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbGeneraciones.Gener_UsuarioModificacion);
                return View(tbGeneraciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Generaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Generaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Gener_Id")] tbGeneraciones tbGeneraciones)
        {
            try
            {
                db.SP_Generaciones_Eliminar(tbGeneraciones.Gener_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
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
