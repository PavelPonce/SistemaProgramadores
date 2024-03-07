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
    public class EstadosCivilesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: EstadosCiviles
        public ActionResult Index()
        {
            try
            {
                var tbEstadosCiviles = db.tbEstadosCiviles.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbEstadosCiviles.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: EstadosCiviles/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
                if (tbEstadosCiviles == null)
                {
                    return HttpNotFound();
                }
                return View(tbEstadosCiviles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: EstadosCiviles/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Estci_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Estci_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: EstadosCiviles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Estci_Descripcion")] tbEstadosCiviles tbEstadosCiviles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_EstadosCiviles_Insertar(tbEstadosCiviles.Estci_Descripcion, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Estci_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioCreacion);
                ViewBag.Estci_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioModificacion);
                return View(tbEstadosCiviles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: EstadosCiviles/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
                if (tbEstadosCiviles == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Estci_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioCreacion);
                ViewBag.Estci_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioModificacion);
                return View(tbEstadosCiviles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: EstadosCiviles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Estci_Id,Estci_Descripcion")] tbEstadosCiviles tbEstadosCiviles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_EstadosCiviles_Modificar(tbEstadosCiviles.Estci_Id,tbEstadosCiviles.Estci_Descripcion, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Estci_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioCreacion);
                ViewBag.Estci_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbEstadosCiviles.Estci_UsuarioModificacion);
                return View(tbEstadosCiviles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: EstadosCiviles/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbEstadosCiviles tbEstadosCiviles = db.tbEstadosCiviles.Find(id);
                if (tbEstadosCiviles == null)
                {
                    return HttpNotFound();
                }
                return View(tbEstadosCiviles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: EstadosCiviles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Estci_Id")] tbEstadosCiviles tbEstadosCiviles)
        {
            try
            {
                db.SP_EstadosCiviles_Eliminar(tbEstadosCiviles.Estci_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
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
