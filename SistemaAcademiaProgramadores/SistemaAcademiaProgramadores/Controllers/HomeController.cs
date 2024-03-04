using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaAcademiaProgramadores.Models;

namespace SistemaAcademiaProgramadores.Controllers
{
    public class HomeController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtUsuario, string txtContra)
        {
            var usuario = db.SP_tbUsuarios_LOGIN(txtUsuario, txtContra).ToList();
            if (usuario.Count > 0)
            {
                foreach (var item in usuario)
                {
                    Session["Usuario"] = item.Perso_PrimerNombre;

                }
                string nombre = Session["Usuario"].ToString();
                Session["txtUsuario"] = txtUsuario;

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult llenarInputs(string id, string spLlenarEditar)
        {
            //var selectall = db.tbDepartamentos.Select("*").Where(t => t.Depar_Id == id).ToList();
            //var selectall = new List<>;

            switch (spLlenarEditar)
            {
                case "tbDepartamentos":
                    return  Json(db.SP_Departamentos_LlenarEditar(id).ToList(), JsonRequestBehavior.AllowGet);
                case "tbTitulos":
                    return Json(db.SP_Titulos_LlenarEditar(int.Parse(id)).ToList(), JsonRequestBehavior.AllowGet);
                case "tbMunicipios":
                    return Json(db.SP_Municipios_LlenarEditar(id).ToList(), JsonRequestBehavior.AllowGet);
                case "tbEstadosCiviles":
                    return Json(db.SP_EstadosCiviles_LlenarEditar(int.Parse(id)).ToList(), JsonRequestBehavior.AllowGet);
            }

            //var tbDepartamentos = db.tbDepartamentos.Find(id);
            return Json(0);
        }

    }
}