using SistemaAcademiaProgramadores.Attributes;
using SistemaAcademiaProgramadores.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace SistemaAcademiaProgramadores.Controllers
{
    [CustomAuthorize]
    public class InstructoresPorCursoPorGeneracionController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: InstructoresPorCursoPorGeneracions
        public ActionResult Index()
        {
            ViewBag.Instr_Id = new SelectList(db.SP_Instructores_DropDownListPersonas().ToList(), "Perso_Id", "Perso_NombreCompleto");
            ViewBag.Categ_Id = new SelectList(db.tbCategorias, "Categ_Id", "Categ_Nombre");

            var tbInstructoresPorCursoPorGeneracion = db.tbInstructoresPorCursoPorGeneracion.Include(t => t.tbCursos).Include(t => t.tbInstructores).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbGeneraciones);
            var tbInstructores = db.tbInstructores.ToList();
            var tbCursos = db.tbCursos.ToList();
            var tbGeneraciones = db.tbGeneraciones.ToList();
            return View(new Tuple<IEnumerable<tbInstructoresPorCursoPorGeneracion>, IEnumerable<tbInstructores>, IEnumerable<tbCursos>, IEnumerable<tbGeneraciones>>(tbInstructoresPorCursoPorGeneracion, tbInstructores, tbCursos, tbGeneraciones));
        }

        // GET: InstructoresPorCursoPorGeneracions/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Gener_Id = new SelectList(db.tbGeneraciones, "Gener_Id", "Gener_Nombre");
            ViewBag.Curso_Id = new SelectList(db.tbCursos, "Curso_Id", "Curso_Nombre");
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion = db.tbInstructoresPorCursoPorGeneracion.Find(id);
            if (tbInstructoresPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            return View(tbInstructoresPorCursoPorGeneracion);
        }
        public JsonResult LlenarCursosPorGeneracion(string Gener_Id)
        {
            try
            {
                return Json(db.SP_InstructoresPorCursoPorGeneracion_LlenarCursosPorGeneracion(int.Parse(Gener_Id)).ToList(), JsonRequestBehavior.AllowGet);

            }
            catch
            {
                TempData["error"] = "Algo salio mal";
                return Json(new {success = false });
            }
        }
        public JsonResult ModificarCursosPorGeneracion(string[] cursosPorHabilitar, string[] cursosPorDeshabilitar, string Gener_Id)
        {
            try
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
                return Json(db.SP_InstructoresPorCursoPorGeneracion_InsertarEliminar(Curso_IdsXML, Gener_Id, Session["Usuar_Id"].ToString(), DateTime.Now).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
            
        }
        // GET: InstructoresPorCursoPorGeneracions/Create
        public ActionResult Create()
        {
            ViewBag.Curso_Id = new SelectList(db.tbCursos, "Curso_Id", "Curso_Nombre");
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id");
            ViewBag.InsCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.InsCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
            ViewBag.Gener_Id = new SelectList(db.tbGeneraciones, "Gener_Id", "Gener_Nombre");
            return View();
        }

        // POST: InstructoresPorCursoPorGeneracions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsCG_Id,Instr_Id,Gener_Id,Curso_Id,InsCG_UsuarioCreacion,InsCG_FechaCreacion,InsCG_UsuarioModificacion,InsCG_FechaModificacion,InsCG_Estado")] tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion)
        {
            if (ModelState.IsValid)
            {
                db.tbInstructoresPorCursoPorGeneracion.Add(tbInstructoresPorCursoPorGeneracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Curso_Id = new SelectList(db.tbCursos, "Curso_Id", "Curso_Nombre", tbInstructoresPorCursoPorGeneracion.Curso_Id);
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbInstructoresPorCursoPorGeneracion.Instr_Id);
            ViewBag.InsCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioCreacion);
            ViewBag.InsCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioModificacion);
            ViewBag.Gener_Id = new SelectList(db.tbGeneraciones, "Gener_Id", "Gener_Nombre", tbInstructoresPorCursoPorGeneracion.Gener_Id);
            return View(tbInstructoresPorCursoPorGeneracion);
        }

        // GET: InstructoresPorCursoPorGeneracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion = db.tbInstructoresPorCursoPorGeneracion.Find(id);
            if (tbInstructoresPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Curso_Id = new SelectList(db.tbCursos, "Curso_Id", "Curso_Nombre", tbInstructoresPorCursoPorGeneracion.Curso_Id);
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbInstructoresPorCursoPorGeneracion.Instr_Id);
            ViewBag.InsCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioCreacion);
            ViewBag.InsCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioModificacion);
            ViewBag.Gener_Id = new SelectList(db.tbGeneraciones, "Gener_Id", "Gener_Nombre", tbInstructoresPorCursoPorGeneracion.Gener_Id);
            return View(tbInstructoresPorCursoPorGeneracion);
        }

        // POST: InstructoresPorCursoPorGeneracions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsCG_Id,Instr_Id,Gener_Id,Curso_Id,InsCG_UsuarioCreacion,InsCG_FechaCreacion,InsCG_UsuarioModificacion,InsCG_FechaModificacion,InsCG_Estado")] tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbInstructoresPorCursoPorGeneracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Curso_Id = new SelectList(db.tbCursos, "Curso_Id", "Curso_Nombre", tbInstructoresPorCursoPorGeneracion.Curso_Id);
            ViewBag.Instr_Id = new SelectList(db.tbInstructores, "Perso_Id", "Perso_Id", tbInstructoresPorCursoPorGeneracion.Instr_Id);
            ViewBag.InsCG_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioCreacion);
            ViewBag.InsCG_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructoresPorCursoPorGeneracion.InsCG_UsuarioModificacion);
            ViewBag.Gener_Id = new SelectList(db.tbGeneraciones, "Gener_Id", "Gener_Nombre", tbInstructoresPorCursoPorGeneracion.Gener_Id);
            return View(tbInstructoresPorCursoPorGeneracion);
        }

        // GET: InstructoresPorCursoPorGeneracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion = db.tbInstructoresPorCursoPorGeneracion.Find(id);
            if (tbInstructoresPorCursoPorGeneracion == null)
            {
                return HttpNotFound();
            }
            return View(tbInstructoresPorCursoPorGeneracion);
        }

        // POST: InstructoresPorCursoPorGeneracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbInstructoresPorCursoPorGeneracion tbInstructoresPorCursoPorGeneracion = db.tbInstructoresPorCursoPorGeneracion.Find(id);
            db.tbInstructoresPorCursoPorGeneracion.Remove(tbInstructoresPorCursoPorGeneracion);
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
