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
    public class PantallasPorRolesController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();


        // GET: PantallasPorRoles
        public ActionResult Index()
        {
            try
            {
                var tbPantallasPorRoles = db.tbPantallasPorRoles.Include(t => t.tbPantallas).Include(t => t.tbRoles).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                var tbPantallas = db.tbPantallas.ToList();
                var tbRoles = db.tbRoles.ToList();
                //return View(tbPantallasPorRoles.ToList());
                return View(new Tuple<IEnumerable<tbPantallasPorRoles>, IEnumerable<tbPantallas>, IEnumerable<tbRoles>>(tbPantallasPorRoles, tbPantallas, tbRoles));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }
        
        public JsonResult LlenarPantallasPorRol(string Roles_Id)
        {
            try
            {
                return Json(db.SP_PantallasPorRoles_SeleccionarPantallasPorRol(int.Parse(Roles_Id)).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        //FORMATO DEL XML: 
         //   <Panta_IdsXML>
		       // <False>1</False>
		       // <True>2</True>
		       // <True>3</True>
		       // <False>16</False>
	        //</Panta_IdsXML>
        public JsonResult ModificarPantallasPorRol(List<string> pantallasPorHabilitar, List<string> pantallasPorDeshabilitar, int Roles_Id)
        {
            try
            {
                var Panta_IdsXML = "<Panta_IdsXML>";
                if (pantallasPorHabilitar != null)
                    foreach (var Panta_Id in pantallasPorHabilitar)
                    {
                        Panta_IdsXML += $"<True>{Panta_Id}</True>";
                    }
                { 
                }
                if (pantallasPorDeshabilitar != null)
                {
                    foreach (var Panta_Id in pantallasPorDeshabilitar)
                    {
                        Panta_IdsXML += $"<False>{Panta_Id}</False>";
                    }
                }
                Panta_IdsXML += "</Panta_IdsXML>";
                return Json(db.SP_PantallasPorRoles_InsertarEliminar(Panta_IdsXML, Roles_Id, 1, DateTime.Now).ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(0, JsonRequestBehavior.AllowGet);
            }
        }
        // GET: PantallasPorRoles/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
                if (tbPantallasPorRoles == null)
                {
                    return HttpNotFound();
                }
                return View(tbPantallasPorRoles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: PantallasPorRoles/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion");
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion");
                ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: PantallasPorRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Papro_Id,Panta_Id,Roles_Id,Papro_UsuarioCreacion,Papro_FechaCreacion,Papro_UsuarioModificacion,Papro_FechaModificacion")] tbPantallasPorRoles tbPantallasPorRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tbPantallasPorRoles.Add(tbPantallasPorRoles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
                ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
                ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
                return View(tbPantallasPorRoles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: PantallasPorRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
                if (tbPantallasPorRoles == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
                ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
                ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
                return View(tbPantallasPorRoles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: PantallasPorRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Papro_Id,Panta_Id,Roles_Id,Papro_UsuarioCreacion,Papro_FechaCreacion,Papro_UsuarioModificacion,Papro_FechaModificacion")] tbPantallasPorRoles tbPantallasPorRoles)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbPantallasPorRoles).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Panta_Id = new SelectList(db.tbPantallas, "Panta_Id", "Panta_Descripcion", tbPantallasPorRoles.Panta_Id);
                ViewBag.Roles_Id = new SelectList(db.tbRoles, "Roles_Id", "Roles_Descripcion", tbPantallasPorRoles.Roles_Id);
                ViewBag.Papro_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioCreacion);
                ViewBag.Papro_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbPantallasPorRoles.Papro_UsuarioModificacion);
                return View(tbPantallasPorRoles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: PantallasPorRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
                if (tbPantallasPorRoles == null)
                {
                    return HttpNotFound();
                }
                return View(tbPantallasPorRoles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: PantallasPorRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbPantallasPorRoles tbPantallasPorRoles = db.tbPantallasPorRoles.Find(id);
                db.tbPantallasPorRoles.Remove(tbPantallasPorRoles);
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
