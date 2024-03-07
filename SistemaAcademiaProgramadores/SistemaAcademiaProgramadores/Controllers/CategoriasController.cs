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
    public class CategoriasController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Categorias
        public ActionResult Index()
        {
            var tbCategorias = db.tbCategorias.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
            return View(tbCategorias.ToList());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategorias tbCategorias = db.tbCategorias.Find(id);
            if (tbCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tbCategorias);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categ_Nombre")] tbCategorias tbCategorias)
        {
            if (ModelState.IsValid)
            {
                db.SP_Categorias_Insertar(tbCategorias.Categ_Nombre, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioCreacion);
            ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioModificacion);
            return View(tbCategorias);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategorias tbCategorias = db.tbCategorias.Find(id);
            if (tbCategorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioCreacion);
            ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioModificacion);
            return View(tbCategorias);
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categ_Id,Categ_Nombre")] tbCategorias tbCategorias)
        {
            if (ModelState.IsValid)
            {
                db.SP_Categorias_Modificar(tbCategorias.Categ_Id,tbCategorias.Categ_Nombre, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioCreacion);
            ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioModificacion);
            return View(tbCategorias);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCategorias tbCategorias = db.tbCategorias.Find(id);
            if (tbCategorias == null)
            {
                return HttpNotFound();
            }
            return View(tbCategorias);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Categ_Id")] tbCategorias tbCategorias)
        {
            db.SP_Categorias_Eliminar(tbCategorias.Categ_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
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
