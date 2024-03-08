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
    public class ActividadesPorCursoPorGeneracionsController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: ActividadesPorCursoPorGeneracions
        public ActionResult Index()
        {
            
            var tbActividadesPorCursoPorGeneracion = db.tbActividadesPorCursoPorGeneracion.Include(t => t.tbInstructoresPorCursoPorGeneracion).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbActividades);
            var tbActividades = db.tbActividades;
            var tbCursos = db.tbCursos;
            var tbGeneraciones = db.tbGeneraciones;
            return View(new Tuple<IEnumerable<tbActividadesPorCursoPorGeneracion>, IEnumerable<tbActividades>, IEnumerable<tbCursos>, IEnumerable<tbGeneraciones>>(tbActividadesPorCursoPorGeneracion,tbActividades, tbCursos, tbGeneraciones));
        }

        // GET: ActividadesPorCursoPorGeneracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion = db.tbActividadesPorCursoPorGeneracion.Find(id);
            if (tbActividadesPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            return View(tbActividadesPorCursoPorGeneracion);
        }
        public JsonResult LlenarActividadesPorCurso(string InsCG_Id)
        {
            try
            {
                return Json(db.SP_ActividadesPorCursosPorGeneraciones_LlenarEditarActividadesPorCursoPorGeneracion(int.Parse(InsCG_Id)).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult ModificarActividadesPorCursosPorGeneracion(string[] actividadesPorHabilitar, string[] actividadesPorDeshabilitar,string[] actividadesPorActualizar, string InsCG_Id)
        {
            try
            {
                int parsedInsCG_Id = int.Parse(InsCG_Id);
                var Actividades = db.tbActividadesPorCursoPorGeneracion.Where(t => t.InsCG_Id == parsedInsCG_Id).ToList();

                var Actividades_XML = "<Actividades_XML>";
                //if ()
                //{

                //}
                if (actividadesPorActualizar != null)
                {
                    for (int i = 0; i < actividadesPorActualizar.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            int parsedActividadPorActualizarId = int.Parse(actividadesPorActualizar[i]);
                            Actividades_XML += "<Actividad>";
                            Actividades_XML += $"<Activ_Id>"+actividadesPorActualizar[i]+"</Activ_Id>";
                            decimal parsedNotaPorActualizar = Convert.ToDecimal(actividadesPorActualizar[i+1]);
                            Actividades_XML += $"<ActCG_Nota>" + actividadesPorActualizar[i + 1] + "</ActCG_Nota>";
                            Actividades_XML += $"<Accion>U</Accion>";
                            Actividades_XML += "</Actividad>";
                            

                            var actividadPorActualizar =  Actividades.Find(act=>act.InsCG_Id == parsedInsCG_Id && act.Activ_Id == parsedActividadPorActualizarId);
                            var indiceActividadPorActualizar =  Actividades.IndexOf(actividadPorActualizar);

                            Actividades[indiceActividadPorActualizar].ActCG_Nota = parsedNotaPorActualizar;
                        }
                    }
                }
                if (actividadesPorHabilitar != null)
                {
                    for (int i = 0; i < actividadesPorHabilitar.Length; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Actividades_XML += "<Actividad>";
                            Actividades_XML += $"<Activ_Id>" + actividadesPorHabilitar[i]+ " </Activ_Id>";
                            Actividades_XML += $"<ActCG_Nota>" + actividadesPorHabilitar[i + 1]+ " </ActCG_Nota>";
                            Actividades_XML += $"<Accion>I</Accion>";
                            Actividades_XML += "</Actividad>";
                            var nuevaActividad = new tbActividadesPorCursoPorGeneracion();
                            nuevaActividad.ActCG_Nota = Convert.ToDecimal(actividadesPorHabilitar[i + 1]);
                            Actividades.Add(nuevaActividad);
                        }
                    }
                }

                if (actividadesPorDeshabilitar != null)
                {
                    for (int i = 0; i < actividadesPorDeshabilitar.Length; i++)
                    {
                        var parsedActividadPorDeshabilitar = int.Parse(actividadesPorDeshabilitar[i]);
                        Actividades_XML += "<Actividad>";
                        Actividades_XML += $" <Activ_Id>" + actividadesPorDeshabilitar[i]+ "</Activ_Id>";
                        Actividades_XML += $" <Accion>D</Accion>";
                        Actividades_XML += "</Actividad>";
                        var actividadPorDeshabilitar =  Actividades.Find(act=>act.InsCG_Id == parsedInsCG_Id && act.Activ_Id == parsedActividadPorDeshabilitar);
                        Actividades.Remove(actividadPorDeshabilitar);
                    }
                }
                Actividades_XML += "</Actividades_XML>";
                if (Actividades.Sum(act => act.ActCG_Nota) == 100)
                {
                    var result = db.SP_ActividadesPorCursoPorGeneracion_InsertarEliminar(Actividades_XML, InsCG_Id, Session["Usuar_Id"].ToString(), DateTime.Now).ToList();
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: ActividadesPorCursoPorGeneracions/Create
        public ActionResult Create()
        {
            ViewBag.InsCG_Id = new SelectList(db.tbInstructoresPorCursoPorGeneracion, "InsCG_Id", "InsCG_Id");
            ViewBag.ActCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.ActCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Activ_Id = new SelectList(db.tbActividades, "Activ_Id", "Activ_Nombre");
            return View();
        }

        // POST: ActividadesPorCursoPorGeneracions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActCG_Id,Activ_Id,InsCG_Id,ActCG_Nota,ActCG_UsuarioCreacion,ActCG_FechaCreacion,ActCG_UsuarioModificacion,ActCG_FechaModificacion,ActCG_Estado")] tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion)
        {
            if (ModelState.IsValid)
            {
                db.tbActividadesPorCursoPorGeneracion.Add(tbActividadesPorCursoPorGeneracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsCG_Id = new SelectList(db.tbInstructoresPorCursoPorGeneracion, "InsCG_Id", "InsCG_Id", tbActividadesPorCursoPorGeneracion.InsCG_Id);
            ViewBag.ActCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioCreacion);
            ViewBag.ActCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioModificacion);
            ViewBag.Activ_Id = new SelectList(db.tbActividades, "Activ_Id", "Activ_Nombre", tbActividadesPorCursoPorGeneracion.Activ_Id);
            return View(tbActividadesPorCursoPorGeneracion);
        }

        // GET: ActividadesPorCursoPorGeneracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion = db.tbActividadesPorCursoPorGeneracion.Find(id);
            if (tbActividadesPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsCG_Id = new SelectList(db.tbInstructoresPorCursoPorGeneracion, "InsCG_Id", "InsCG_Id", tbActividadesPorCursoPorGeneracion.InsCG_Id);
            ViewBag.ActCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioCreacion);
            ViewBag.ActCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioModificacion);
            ViewBag.Activ_Id = new SelectList(db.tbActividades, "Activ_Id", "Activ_Nombre", tbActividadesPorCursoPorGeneracion.Activ_Id);
            return View(tbActividadesPorCursoPorGeneracion);
        }

        // POST: ActividadesPorCursoPorGeneracions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActCG_Id,Activ_Id,InsCG_Id,ActCG_Nota,ActCG_UsuarioCreacion,ActCG_FechaCreacion,ActCG_UsuarioModificacion,ActCG_FechaModificacion,ActCG_Estado")] tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbActividadesPorCursoPorGeneracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsCG_Id = new SelectList(db.tbInstructoresPorCursoPorGeneracion, "InsCG_Id", "InsCG_Id", tbActividadesPorCursoPorGeneracion.InsCG_Id);
            ViewBag.ActCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioCreacion);
            ViewBag.ActCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbActividadesPorCursoPorGeneracion.ActCG_UsuarioModificacion);
            ViewBag.Activ_Id = new SelectList(db.tbActividades, "Activ_Id", "Activ_Nombre", tbActividadesPorCursoPorGeneracion.Activ_Id);
            return View(tbActividadesPorCursoPorGeneracion);
        }

        // GET: ActividadesPorCursoPorGeneracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion = db.tbActividadesPorCursoPorGeneracion.Find(id);
            if (tbActividadesPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            return View(tbActividadesPorCursoPorGeneracion);
        }

        // POST: ActividadesPorCursoPorGeneracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbActividadesPorCursoPorGeneracion tbActividadesPorCursoPorGeneracion = db.tbActividadesPorCursoPorGeneracion.Find(id);
            db.tbActividadesPorCursoPorGeneracion.Remove(tbActividadesPorCursoPorGeneracion);
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
