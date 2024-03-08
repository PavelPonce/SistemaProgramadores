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
    public class AlumnosController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();
        public class MyStaticList
        {
            public static List<string> SingleValueList = new List<string>() { "" };
        }
        // GET: Alumnos
        public ActionResult Index()
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.CenEd_IdColegio = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                var tbAlumnos = db.tbAlumnos.Include(t => t.tbPersonas).Include(t => t.tbTitulos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1).Include(t => t.tbCentrosEducativos).Include(t => t.tbCentrosEducativos1);
                return View(tbAlumnos.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.CenEd_IdColegio = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
                if (tbAlumnos == null)
                {
                    return HttpNotFound();
                }
                return View(tbAlumnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.CenEd_IdColegio = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        // POST: Alumnos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perso_Id,CenEd_IdColegio,CenEd_IdUniversidad,Titul_Id,Alumn_UsuarioCreacion,Alumn_FechaCreacion,Alumn_UsuarioModificacion,Alumn_FechaModificacion,Alumn_Estado,Alumn_Observaciones,Alumn_FechaIngreso,Gener_Id")] tbAlumnos tbAlumnos, [Bind(Include = "Perso_Id,Perso_PrimerNombre,Perso_SegundoNombre,Perso_PrimerApellido,Perso_SegundoApellido,Perso_FechaNacimiento,Perso_Sexo,Estci_Id,Perso_Direccion,Munic_Id,Perso_Telefono,Perso_CorreoElectronico,Perso_UsuarioCreacion,Perso_FechaCreacion,Perso_UsuarioModificacion,Perso_FechaModificacion,Perso_Estado")] tbPersonas tbPersonas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int toastr = db.SP_Alumnos_Insertar(tbPersonas.Perso_PrimerNombre, tbPersonas.Perso_SegundoNombre, tbPersonas.Perso_PrimerApellido, tbPersonas.Perso_SegundoApellido, tbPersonas.Perso_FechaNacimiento, tbPersonas.Perso_Sexo, tbPersonas.Estci_Id, tbPersonas.Perso_Direccion, tbPersonas.Munic_Id, tbPersonas.Perso_Telefono, tbPersonas.Perso_CorreoElectronico, tbAlumnos.CenEd_IdColegio, tbAlumnos.CenEd_IdUniversidad, tbAlumnos.Titul_Id, tbAlumnos.Gener_Id,int.Parse(Session["Usuar_Id"].ToString()),DateTime.Now,tbAlumnos.Alumn_Observaciones,tbAlumnos.Alumn_FechaIngreso);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbAlumnos.tbPersonas.tbMunicipios.Depar_Id);
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
                ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
                ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
                ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
                ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
                return View(tbAlumnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
                if (tbAlumnos == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbAlumnos.tbPersonas.tbMunicipios.Depar_Id);

                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
                ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
                ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
                ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
                ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
                return View(tbAlumnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Alumnos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perso_Id,CenEd_IdColegio,CenEd_IdUniversidad,Titul_Id,Alumn_UsuarioCreacion,Alumn_FechaCreacion,Alumn_UsuarioModificacion,Alumn_FechaModificacion,Alumn_Estado,Alumn_Observaciones,Alumn_FechaIngreso,Gener_Id")] tbAlumnos tbAlumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbAlumnos).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion", tbAlumnos.tbPersonas.tbMunicipios.Depar_Id);

                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbAlumnos.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbAlumnos.Titul_Id);
                ViewBag.Alumn_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioCreacion);
                ViewBag.Alumn_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbAlumnos.Alumn_UsuarioModificacion);
                ViewBag.CenEd_IdColegio = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdColegio);
                ViewBag.CenEd_IdUniversidad = new SelectList(db.tbCentrosEducativos, "CenEd_Id", "CenEd_Nombre", tbAlumnos.CenEd_IdUniversidad);
                return View(tbAlumnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
                if (tbAlumnos == null)
                {
                    return HttpNotFound();
                }
                return View(tbAlumnos);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbAlumnos tbAlumnos = db.tbAlumnos.Find(id);
                db.tbAlumnos.Remove(tbAlumnos);
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
