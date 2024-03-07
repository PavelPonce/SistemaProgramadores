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
    public class MunicipiosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: Municipios
        public ActionResult Index()
        {
            try
            {
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                var tbMunicipios = db.tbMunicipios.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbDepartamentos);
                return View(tbMunicipios.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Municipios/Details/5
        public ActionResult Details(string id)
        {
            try
            {
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
                if (tbMunicipios == null)
                {
                    return HttpNotFound();
                }
                return View(tbMunicipios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Munic_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Munic_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Municipios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Munic_Id,Munic_Descripcion,Depar_Id")] tbMunicipios tbMunicipios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Municipios_Insertar(tbMunicipios.Munic_Id,tbMunicipios.Munic_Descripcion,tbMunicipios.Depar_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.Munic_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioCreacion);
                ViewBag.Munic_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioModificacion);
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbMunicipios.Depar_Id);
                return View(tbMunicipios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
                if (tbMunicipios == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Munic_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioCreacion);
                ViewBag.Munic_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioModificacion);
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbMunicipios.Depar_Id);
                return View(tbMunicipios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Municipios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Munic_Id,Munic_Descripcion,Depar_Id")] tbMunicipios tbMunicipios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_Municipios_Modificar(tbMunicipios.Munic_Id,tbMunicipios.Munic_Descripcion,tbMunicipios.Depar_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Munic_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioCreacion);
                ViewBag.Munic_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbMunicipios.Munic_UsuarioModificacion);
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbMunicipios.Depar_Id);
                return View(tbMunicipios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbMunicipios tbMunicipios = db.tbMunicipios.Find(id);
                if (tbMunicipios == null)
                {
                    return HttpNotFound();
                }
                return View(tbMunicipios);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Munic_Id")] tbMunicipios tbMunicipios)
        {
            try
            {
                db.SP_Municipios_Eliminar(tbMunicipios.Munic_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
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
