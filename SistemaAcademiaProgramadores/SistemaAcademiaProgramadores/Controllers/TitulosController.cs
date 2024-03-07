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
    public class TitulosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Titulos
        public ActionResult Index()
        {
            try
            {
                ViewBag.Titul_Tipo = new SelectList(db.SP_Titulos_DropDownList().ToList(), "Titul_Tipo","Titul_TipoDescripcion");
                var tbTitulos = db.tbTitulos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbTitulos.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Titulos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ViewBag.Titul_Tipo = new SelectList(db.SP_Titulos_DropDownList().ToList(), "Titul_Tipo","Titul_TipoDescripcion");
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbTitulos tbTitulos = db.tbTitulos.Find(id);
                if (tbTitulos == null)
                {
                    return HttpNotFound();
                }
                return View(tbTitulos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Titulos/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Titul_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Titul_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Titulos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Titul_Nombre,Titul_Tipo")] tbTitulos tbTitulos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Titulos_Insertar(tbTitulos.Titul_Nombre,tbTitulos.Titul_Tipo,1,DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Titul_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioCreacion);
                ViewBag.Titul_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioModificacion);
                return View(tbTitulos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Titulos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbTitulos tbTitulos = db.tbTitulos.Find(id);
                if (tbTitulos == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Titul_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioCreacion);
                ViewBag.Titul_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioModificacion);
                return View(tbTitulos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Titulos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Titul_Id,Titul_Nombre,Titul_Tipo")] tbTitulos tbTitulos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Titulos_Modificar(tbTitulos.Titul_Id,tbTitulos.Titul_Nombre, tbTitulos.Titul_Tipo, 1, DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Titul_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioCreacion);
                ViewBag.Titul_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbTitulos.Titul_UsuarioModificacion);
                return View(tbTitulos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Titulos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbTitulos tbTitulos = db.tbTitulos.Find(id);
                if (tbTitulos == null)
                {
                    return HttpNotFound();
                }
                return View(tbTitulos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Titulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Titul_Id")] tbTitulos tbTitulos)
        {
            try
            {
                int usuarioLogueado = int.Parse(Session["Usuar_Id"].ToString());
                db.SP_Titulos_Eliminar(tbTitulos.Titul_Id,usuarioLogueado,DateTime.Now);
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
