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
    public class CategoriasController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Categorias
        public ActionResult Index()
        {
            try
            {
                var tbCategorias = db.tbCategorias.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbCategorias.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: Categorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Categ_Nombre")] tbCategorias tbCategorias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toastr = db.SP_Categorias_Insertar(tbCategorias.Categ_Nombre, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    if (int.Parse(toastr.ToString()) == 1)
                    {
                        db.SaveChanges();
                        TempData["success"] = "Se ha insertado correctamente";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Se trato de ingresar un campo duplicado";
                        return RedirectToAction("Index");
                    }
                }

                ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioCreacion);
                ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioModificacion);
                return View(tbCategorias);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Categorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Categ_Id,Categ_Nombre")] tbCategorias tbCategorias)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toastr = db.SP_Categorias_Modificar(tbCategorias.Categ_Id,tbCategorias.Categ_Nombre, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    if (int.Parse(toastr.ToString()) == 1)
                    {
                        db.SaveChanges();
                        TempData["success"] = "Se ha insertado correctamente";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Se trato de ingresar un campo duplicado";
                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Categ_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioCreacion);
                ViewBag.Categ_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCategorias.Categ_UsuarioModificacion);
                return View(tbCategorias);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Categ_Id")] tbCategorias tbCategorias)
        {
            try
            {
                var toastr = db.SP_Categorias_Eliminar(tbCategorias.Categ_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                if (int.Parse(toastr.ToString()) == 1)
                {
                    db.SaveChanges();
                    TempData["success"] = "Se ha actualizado el estado correctamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "Algo salio mal";
                    return RedirectToAction("Index");
                }
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
