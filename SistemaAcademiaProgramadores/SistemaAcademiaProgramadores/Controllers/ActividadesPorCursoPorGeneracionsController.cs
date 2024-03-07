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
        public JsonResult LlenarCursosPorGeneracion(string Gener_Id)
        {
            return Json(db.SP_InstrucoresPorCursoPorGeneracion_LlenarCursosPorGeneracion(int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ModificarCursosPorGeneracion(string[] cursosPorHabilitar, string[] cursosPorDeshabilitar, int Gener_Id)
        {
            var Curso_IdsXML = "<Curso_IdsXML>";
            if (cursosPorHabilitar != null)
            {
                for (int i = 0; i < cursosPorHabilitar.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        Curso_IdsXML += "<Curso_Attr>";
                        Curso_IdsXML += $"<Curso_Id>{cursosPorHabilitar[i]}</Curso_Id>";
                        Curso_IdsXML += "<Bit>1</Bit>";
                        Curso_IdsXML += $"<Instr_Id>{cursosPorHabilitar[i + 1]}</Instr_Id>";
                        Curso_IdsXML += "</Curso_Attr>";
                    }
                }
            }

            if (cursosPorDeshabilitar != null)
            {
                for (int i = 0; i < cursosPorDeshabilitar.Length; i++)
                {
                    Curso_IdsXML += "<Curso_Attr>";
                    Curso_IdsXML += $"<Curso_Id>{cursosPorDeshabilitar[i]}</Curso_Id>";
                    Curso_IdsXML += "<Bit>0</Bit>";
                    Curso_IdsXML += "</Curso_Attr>";
                }
            }
            Curso_IdsXML += "</Curso_IdsXML>";
            return Json(db.SP_InstructoresPorCursoPorGeneracion_InsertarEliminar(Curso_IdsXML, Gener_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now).ToList(), JsonRequestBehavior.AllowGet);
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
