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
    public class InstructoresController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();
        public MyStaticList myStaticList = new MyStaticList();
        public class MyStaticList
        {
            public static List<string> SingleValueList = new List<string>() { "" };
        }
        // GET: Instructores
        public ActionResult Index()
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);

                var tbInstructores = db.tbInstructores.Include(t => t.tbPersonas).Include(t => t.tbTitulos).Include(t => t.tbUsuarios).Include(t => t.tbUsuarios1);
                return View(tbInstructores.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Instructores/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbInstructores tbInstructores = db.tbInstructores.Find(id);
                if (tbInstructores == null)
                {
                    return HttpNotFound();
                }
                return View(tbInstructores);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Instructores/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario");
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Instructores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Perso_Id,Titul_Id,CenEd_Id,Instr_UsuarioCreacion,Instr_FechaCreacion,Instr_UsuarioModificacion,Instr_FechaModificacion,Instr_Estado")] tbInstructores tbInstructores, [Bind(Include = "Perso_Id,Perso_PrimerNombre,Perso_SegundoNombre,Perso_PrimerApellido,Perso_SegundoApellido,Perso_FechaNacimiento,Perso_Sexo,Estci_Id,Perso_Direccion,Munic_Id,Perso_Telefono,Perso_CorreoElectronico,Perso_UsuarioCreacion,Perso_FechaCreacion,Perso_UsuarioModificacion,Perso_FechaModificacion,Perso_Estado")] tbPersonas tbPersonas)
        {
            try
            {
                ModelState.Remove("Perso_Id");
                if (ModelState.IsValid)
                {
                    var toastr = db.SP_Instructores_Insertar(tbPersonas.Perso_PrimerNombre, tbPersonas.Perso_SegundoNombre, tbPersonas.Perso_PrimerApellido, tbPersonas.Perso_SegundoApellido, tbPersonas.Perso_FechaNacimiento, tbPersonas.Perso_Sexo, tbPersonas.Estci_Id, tbPersonas.Perso_Direccion, tbPersonas.Munic_Id, tbPersonas.Perso_Telefono, tbPersonas.Perso_CorreoElectronico, tbInstructores.Titul_Id, tbInstructores.CenEd_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                    if (int.Parse(toastr.ToString()) == 1)
                    {
                        db.SaveChanges();
                        TempData["success"] = "Se ha ingresado el registro correctamente";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Valor repetido. Parece que el registro que estas tratando de ingresar, ya existe";
                        return RedirectToAction("Index");

                    }

                }

                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
                ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
                return View(tbInstructores);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // GET: Instructores/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbInstructores tbInstructores = db.tbInstructores.Find(id);
                if (tbInstructores == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
                ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
                return View(tbInstructores);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Instructores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Perso_Id,Titul_Id,CenEd_Id,Instr_UsuarioCreacion,Instr_FechaCreacion,Instr_UsuarioModificacion,Instr_FechaModificacion,Instr_Estado")] tbInstructores tbInstructores, [Bind(Include = "Perso_Id,Perso_PrimerNombre,Perso_SegundoNombre,Perso_PrimerApellido,Perso_SegundoApellido,Perso_FechaNacimiento,Perso_Sexo,Estci_Id,Perso_Direccion,Munic_Id,Perso_Telefono,Perso_CorreoElectronico,Perso_UsuarioCreacion,Perso_FechaCreacion,Perso_UsuarioModificacion,Perso_FechaModificacion,Perso_Estado")] tbPersonas tbPersonas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var toastr = db.SP_Instructores_Modificar(tbInstructores.Perso_Id,tbPersonas.Perso_PrimerNombre, tbPersonas.Perso_SegundoNombre, tbPersonas.Perso_PrimerApellido, tbPersonas.Perso_SegundoApellido, tbPersonas.Perso_FechaNacimiento, tbPersonas.Perso_Sexo, tbPersonas.Estci_Id, tbPersonas.Perso_Direccion, tbPersonas.Munic_Id, tbPersonas.Perso_Telefono, tbPersonas.Perso_CorreoElectronico, tbInstructores.Titul_Id, tbInstructores.CenEd_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);

                    if (int.Parse(toastr.ToString()) == 1)
                    {
                        db.SaveChanges();
                        TempData["success"] = "Se ha actualizado el registro correctamente";

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["error"] = "Parece que el registro al que tratas de cambiar ya existe.";

                        return RedirectToAction("Index");
                    }
                }
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre", tbInstructores.Perso_Id);
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre", tbInstructores.Titul_Id);
                ViewBag.Perso_Id = new SelectList(db.tbPersonas, "Perso_Id", "Perso_PrimerNombre");
                ViewBag.Titul_Id = new SelectList(db.tbTitulos, "Titul_Id", "Titul_Nombre");
                ViewBag.Estci_Id = new SelectList(db.tbEstadosCiviles, "Estci_Id", "Estci_Descripcion");
                ViewBag.Depar_Id = new SelectList(db.tbDepartamentos, "Depar_Id", "Depar_Descripcion");
                ViewBag.Munic_Id = new SelectList(MyStaticList.SingleValueList);
                ViewBag.Instr_UsuarioCreacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioCreacion);
                ViewBag.Instr_UsuarioModificacion = new SelectList(db.tbUsuarios, "Usuar_Id", "Usuar_Usuario", tbInstructores.Instr_UsuarioModificacion);
                return View(tbInstructores);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algo salio mal";
                return View();
            }
        }

        // GET: Instructores/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbInstructores tbInstructores = db.tbInstructores.Find(id);
                if (tbInstructores == null)
                {
                    return HttpNotFound();
                }
                return View(tbInstructores);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View();
            }
        }

        // POST: Instructores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed([Bind(Include = "Perso_Id,Titul_Id,CenEd_Id,Instr_UsuarioCreacion,Instr_FechaCreacion,Instr_UsuarioModificacion,Instr_FechaModificacion,Instr_Estado")] tbInstructores tbInstructores)
        {
            try
            {
                var toastr = db.SP_Instructores_Eliminar(tbInstructores.Perso_Id, int.Parse(Session["Usuar_Id"].ToString()), DateTime.Now);
                if (int.Parse(toastr.ToString()) == 1)
                {
                    db.SaveChanges();
                    TempData["success"] = "Se ha modificado el estado del registro correctamente";
                    return RedirectToAction("Index");

                }
                else
                {
                    TempData["error"] = "Algo salio mal";
                    return RedirectToAction("Index");
                }
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