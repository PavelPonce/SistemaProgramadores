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
    public class CentrosEducativosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        // GET: CentrosEducativos
        public ActionResult Index()
        {
            try
            {
                ViewBag.CenEd_Tipo = new SelectList(db.SP_CentrosEducativos_DropDownListTipo().ToList(), "CenEd_Tipo", "CenEd_TipoDescripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(db.SP_EmptyTable().ToList(),"value","text");

                var tbCentrosEducativos = db.tbCentrosEducativos.Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbMunicipios);
                return View(tbCentrosEducativos.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: CentrosEducativos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ViewBag.CenEd_Tipo = new SelectList(db.SP_CentrosEducativos_DropDownListTipo().ToList(), "CenEd_Tipo", "CenEd_TipoDescripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(db.SP_EmptyTable().ToList(), "value", "text");
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCentrosEducativos tbCentrosEducativos = db.tbCentrosEducativos.Find(id);
                if (tbCentrosEducativos == null)
                {
                    return HttpNotFound();
                }
                return View(tbCentrosEducativos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: CentrosEducativos/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.CenEd_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.CenEd_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: CentrosEducativos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenEd_Nombre,CenEd_Direccion,CenEd_Tipo,Munic_Id")] tbCentrosEducativos tbCentrosEducativos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_CentrosEducativos_Insertar(tbCentrosEducativos.CenEd_Nombre,tbCentrosEducativos.CenEd_Direccion,tbCentrosEducativos.CenEd_Tipo,tbCentrosEducativos.Munic_Id,int.Parse(Session["Usuar_Id"].ToString()),DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.CenEd_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioCreacion);
                ViewBag.CenEd_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioModificacion);
                ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbCentrosEducativos.Munic_Id);
                return View(tbCentrosEducativos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: CentrosEducativos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCentrosEducativos tbCentrosEducativos = db.tbCentrosEducativos.Find(id);
                if (tbCentrosEducativos == null)
                {
                    return HttpNotFound();
                }
                ViewBag.CenEd_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioCreacion);
                ViewBag.CenEd_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioModificacion);
                ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbCentrosEducativos.Munic_Id);
                return View(tbCentrosEducativos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: CentrosEducativos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenEd_Id,CenEd_Nombre,CenEd_Direccion,CenEd_Tipo,Munic_Id")] tbCentrosEducativos tbCentrosEducativos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.SP_CentrosEducativos_Modificar(tbCentrosEducativos.CenEd_Id,tbCentrosEducativos.CenEd_Nombre, tbCentrosEducativos.CenEd_Direccion, tbCentrosEducativos.CenEd_Tipo, tbCentrosEducativos.Munic_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.CenEd_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioCreacion);
                ViewBag.CenEd_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbCentrosEducativos.CenEd_UsuarioModificacion);
                ViewBag.Munic_Id = new SelectList(db.tbMunicipios, "Munic_Id", "Munic_Descripcion", tbCentrosEducativos.Munic_Id);
                return View(tbCentrosEducativos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }


        // GET: CentrosEducativos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbCentrosEducativos tbCentrosEducativos = db.tbCentrosEducativos.Find(id);
                if (tbCentrosEducativos == null)
                {
                    return HttpNotFound();
                }
                return View(tbCentrosEducativos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: CentrosEducativos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "CenEd_Id")] tbCentrosEducativos tbCentrosEducativos)
        {
            try
            {
                db.SP_CentrosEducativos_Eliminar(tbCentrosEducativos.CenEd_Id,int.Parse(Session["Usuar_Id"].ToString()),DateTime.Now);
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
