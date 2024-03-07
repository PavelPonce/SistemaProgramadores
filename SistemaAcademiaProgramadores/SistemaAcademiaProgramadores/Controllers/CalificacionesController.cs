using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
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
            try
            {
                var tbGeneraciones = db.tbGeneraciones.ToList();
                if (Gener_Id != null && Curso_Id != null)
                {
                    //Session["SP_InstructoresPorCursoPorGeneracion_Seleccionar"] = db.SP_InstructoresPorCursoPorGeneracion_Seleccionar(int.Parse(Session["Perso_Id"].ToString()), Gener_Id).ToList();
                    //Session["SP_ActividadesPorCursoPorGeneracion_Seleccionar"] = db.SP_ActividadesPorCursoPorGeneracion_Seleccionar(Curso_Id, Gener_Id).ToList();
                    //Session["SP_Calificaciones2_Seleccionar"] = db.SP_Calificaciones2_Seleccionar(Curso_Id, Gener_Id).ToList();

                    var Cursos = db.SP_InstructoresPorCursoPorGeneracion_Seleccionar(Session["Perso_Id"].ToString(), Gener_Id.ToString()).ToList();
                    var Actividades = db.SP_ActividadesPorCursoPorGeneracion_Seleccionar(Curso_Id, Gener_Id).ToList();
                    var Calificaciones = db.SP_Calificaciones2_Seleccionar(Curso_Id, Gener_Id).ToList();
                    Session["Gener_Id"] = Gener_Id;
                    Session["Curso_Id"] = Curso_Id;
                    Dictionary<int, string> AlumnosDictionary = new Dictionary<int, string>();
                    Dictionary<int, Dictionary<string, decimal>> CalificacionesDictionary = new Dictionary<int, Dictionary<string, decimal>>();
                    foreach (var calificacionItem in Calificaciones)    
                    {
                        int persoId = calificacionItem.Perso_Id;
                        string alumno = calificacionItem.ALUMNO;
                        int actCGId = calificacionItem.ActCG_Id;
                        decimal califNota = calificacionItem.Calif_Nota;

                        AlumnosDictionary[persoId] = alumno;

                        if (CalificacionesDictionary.ContainsKey(persoId))
                        {
                            var nuevaCalificacion = CalificacionesDictionary[persoId];
                            nuevaCalificacion[actCGId.ToString()] = califNota;
                        }
                        else
                        {
                            CalificacionesDictionary[persoId] = new Dictionary<string, decimal> { { actCGId.ToString(), califNota } };
                        }
                    }
                    Session["SP_ActividadesPorCursoPorGeneracion_Seleccionar"] = Actividades;
                    Session["SP_InstructoresPorCursoPorGeneracion_Seleccionar"] = Cursos;
                    Session["CalificacionesDictionary"] = CalificacionesDictionary;
                    Session["AlumnosDictionary"] = AlumnosDictionary;
                }
                return View(tbGeneraciones);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        public JsonResult ObtenerCalificacionesDictionary(string nada)
        {
            try
            {
                var CalificacionesDictionary = Session["CalificacionesDictionary"] as Dictionary<int, Dictionary<string, decimal>> ?? new Dictionary<int, Dictionary<string, decimal>>();
                return Json(CalificacionesDictionary.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult LlenarCursosDdl(string Gener_Id)
        {
            try
            {
                var Perso_Id = Session["Perso_Id"].ToString();
                var resul = db.SP_InstructoresPorCursoPorGeneracion_Seleccionar(Perso_Id, Gener_Id).ToList();
                return Json(resul, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CargarActividades(string Gener_Id, string Curso_Id)
        {
            try
            {
                return Json(db.SP_ActividadesPorCursoPorGeneracion_Seleccionar(int.Parse(Curso_Id), int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CargarCalificaciones(string Gener_Id, string Curso_Id)
        {
            try
            {
                return Json(db.SP_Calificaciones2_Seleccionar(int.Parse(Curso_Id), int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult CrearNota(string Alumn_Id, string ActCG_Id, string Calif_Nota)
        {
            try
            {
                return Json(db.SP_Calificaciones_Insertar(ActCG_Id, Alumn_Id, decimal.Parse(Calif_Nota), Session["Usuar_Id"].ToString(), DateTime.Now), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ModificarNota(string Alumn_Id, string ActCG_Id, string Calif_Nota)
        {
            try
            {
                return Json(db.SP_Calificaciones_Modificar(ActCG_Id, Alumn_Id, decimal.Parse(Calif_Nota), Session["Usuar_Id"].ToString(), DateTime.Now), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: Calificaciones/Details/5
        public ActionResult Details(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Calificaciones/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Alumn_Id = new SelectList(db.tbAlumnos, "Perso_Id", "Alumn_Observaciones");
                ViewBag.Calif_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Calif_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.ActCG_Id = new SelectList(db.tbActividadesPorCursoPorGeneracion, "ActCG_Id", "ActCG_Id");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Calif_Id,ActCG_Id,Alumn_Id,Calif_Nota,Calif_UsuarioCreacion,Calif_FechaCreacion,Calif_UsuarioModificacion,Calif_FechaModificacion")] tbCalificaciones tbCalificaciones)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }

        }

        // GET: Calificaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Calif_Id,ActCG_Id,Alumn_Id,Calif_Nota,Calif_UsuarioCreacion,Calif_FechaCreacion,Calif_UsuarioModificacion,Calif_FechaModificacion")] tbCalificaciones tbCalificaciones)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Calificaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbCalificaciones tbCalificaciones = db.tbCalificaciones.Find(id);
                db.tbCalificaciones.Remove(tbCalificaciones);
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
