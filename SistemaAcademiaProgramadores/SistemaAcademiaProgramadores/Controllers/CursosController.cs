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
    public class CursosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Cursos
        public ActionResult Index()
        {
            try
            {
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre");
                var tbCursos = db.tbCursos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbCategorias);
                return View(tbCursos.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Cursos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre");
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCursos tbCursos = db.tbCursos.Find(id);
                if (tbCursos == null)
                {
                    return HttpNotFound();
                }
                return View(tbCursos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Cursos/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Curso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Curso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: Cursos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Curso_Nombre,Categ_Id")] tbCursos tbCursos, string paginaAlterna)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Cursos_Insertar(tbCursos.Curso_Nombre,tbCursos.Categ_Id,int.Parse(Session["Usuar_Id"].ToString()),DateTime.Now);
                    db.SaveChanges();
                    if(paginaAlterna != "1")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index","InstructoresPorCursoPorGeneracion");
                    }   
                }
                ViewBag.Curso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioCreacion);
                ViewBag.Curso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioModificacion);
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre", tbCursos.Categ_Id);
                return View(tbCursos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Cursos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCursos tbCursos = db.tbCursos.Find(id);
                if (tbCursos == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Curso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioCreacion);
                ViewBag.Curso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioModificacion);
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre", tbCursos.Categ_Id);
                return View(tbCursos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Cursos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Curso_Id,Curso_Nombre,Categ_Id")] tbCursos tbCursos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Cursos_Modificar(tbCursos.Curso_Id,tbCursos.Curso_Nombre, tbCursos.Categ_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Curso_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioCreacion);
                ViewBag.Curso_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCursos.Curso_UsuarioModificacion);
                ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre", tbCursos.Categ_Id);
                return View(tbCursos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Cursos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCursos tbCursos = db.tbCursos.Find(id);
                if (tbCursos == null)
                {
                    return HttpNotFound();
                }
                return View(tbCursos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Curso_Id")] tbCursos tbCursos)
        {
            try
            {
                db.SP_Cursos_Eliminar(tbCursos.Categ_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                db.tbCursos.Remove(tbCursos);
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
