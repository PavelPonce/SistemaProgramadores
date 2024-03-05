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
//using SistemaAcademiaProgramadores.Attributes;

namespace SistemaAcademiaProgramadores.Controllers
{
    [CustomAuthorize]
    public class CalificacionesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Calificaciones
        public ActionResult Index(int? Gener_Id, int? Curso_Id)
        {
            var tbCalificaciones = db.tbCalificaciones.Include(t => t.tbAlumnos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbActividadesPorCursoPorGeneracion);
            var tbGeneraciones = db.tbGeneraciones.ToList();
            var tbCursos = db.tbCursos.ToList();
            //Session["Gener_Id"] = Gener_Id;
            //Session["Curso_Id"] = Curso_Id;
            return View(new Tuple<IEnumerable<tbCalificaciones>, IEnumerable<tbGeneraciones>, IEnumerable<tbCursos>>(tbCalificaciones, tbGeneraciones, tbCursos));
        }
        public JsonResult LlenarCursosDdl(string Gener_Id)
        {
            //el caso del usuario victor no es un instructor
            return Json(db.SP_InstructoresPorCursoPorGeneracion_Seleccionar(int.Parse(Session["Perso_Id"].ToString()), int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarActividades(string Gener_Id, string Curso_Id)
        {
            return Json(db.SP_ActividadesPorCursoPorGeneracion_Seleccionar(int.Parse(Curso_Id), int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CargarCalificaciones(string Gener_Id, string Curso_Id)
        {
            return Json(db.SP_Calificaciones2_Seleccionar(int.Parse(Curso_Id), int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModificarNota(string Alumn_Id, string ActCG_Id, string Calif_Nota)
        {
            return Json(db.SP_Calificaciones_Modificar(ActCG_Id, Alumn_Id, decimal.Parse(Calif_Nota),Session["Usuar_Id"].ToString(), DateTime.Now), JsonRequestBehavior.AllowGet);
        }
        // GET: Calificaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCalificaciones tbCalificaciones = db.tbCalificaciones.Find(id);
            if (tbCalificaciones == null)
            {
                return HttpNotFound();
            }
            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Create
        public ActionResult Create()
        {
            ViewBag.Alumn_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones");
            ViewBag.Calif_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Calif_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.ActCG_Id = new SelectList(db.tbActividadesPorCursoPorGeneracion, "ActCG_Id", "ActCG_Id");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Calif_Id,ActCG_Id,Alumn_Id,Calif_Nota,Calif_UsuarioCreacion,Calif_FechaCreacion,Calif_UsuarioModificacion,Calif_FechaModificacion")] tbCalificaciones tbCalificaciones)
        {
            if (ModelState.IsValid)
            {
                db.tbCalificaciones.Add(tbCalificaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumn_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbCalificaciones.Alumn_Id);
            ViewBag.Calif_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioCreacion);
            ViewBag.Calif_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioModificacion);
            ViewBag.ActCG_Id = new SelectList(db.tbActividadesPorCursoPorGeneracion, "ActCG_Id", "ActCG_Id", tbCalificaciones.ActCG_Id);
            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCalificaciones tbCalificaciones = db.tbCalificaciones.Find(id);
            if (tbCalificaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumn_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbCalificaciones.Alumn_Id);
            ViewBag.Calif_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioCreacion);
            ViewBag.Calif_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioModificacion);
            ViewBag.ActCG_Id = new SelectList(db.tbActividadesPorCursoPorGeneracion, "ActCG_Id", "ActCG_Id", tbCalificaciones.ActCG_Id);
            return View(tbCalificaciones);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Calif_Id,ActCG_Id,Alumn_Id,Calif_Nota,Calif_UsuarioCreacion,Calif_FechaCreacion,Calif_UsuarioModificacion,Calif_FechaModificacion")] tbCalificaciones tbCalificaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbCalificaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumn_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones", tbCalificaciones.Alumn_Id);
            ViewBag.Calif_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioCreacion);
            ViewBag.Calif_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCalificaciones.Calif_UsuarioModificacion);
            ViewBag.ActCG_Id = new SelectList(db.tbActividadesPorCursoPorGeneracion, "ActCG_Id", "ActCG_Id", tbCalificaciones.ActCG_Id);
            return View(tbCalificaciones);
        }

        // GET: Calificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCalificaciones tbCalificaciones = db.tbCalificaciones.Find(id);
            if (tbCalificaciones == null)
            {
                return HttpNotFound();
            }
            return View(tbCalificaciones);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbCalificaciones tbCalificaciones = db.tbCalificaciones.Find(id);
            db.tbCalificaciones.Remove(tbCalificaciones);
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
