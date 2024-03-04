using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SistemaAcademiaProgramadores.Models;

namespace SistemaAcademiaProgramadores.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string txtUsuario, string txtContra)
        {
            var usuario = db.SP_Usuarios_Login(txtUsuario, txtContra).ToList();
            if (usuario.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(usuario[0].Usuar_Usuario, false);
                Session["Perso_NombreCompleto"] = usuario[0].Perso_NombreCompleto;
                Session["Roles_Descripcion"] = usuario[0].Roles_Descripcion;
                string menuHTML = "<li>";
                string esquemaAccesosHTML = "<a href='#'>" +
                                    "<i class='fa fa-lock'></i><span class='nav-label'>Acceso</span><span class='fa arrow'></span>" +
                                "</a>" +
                                "<ul class='nav nav-second-level'>";
                string esquemaMantenimientoHTML = "<a href='#'>" +
                                    "<i class='fa fa-wrench'></i><span class='nav-label'>Mantenimiento</span><span class='fa arrow'></span>" +
                                "</a>" +
                                "<ul class='nav nav-second-level'>";
                string esquemaAcademiaHTML = "<a href='#'>" +
                                    "<i class='fa fa-book'></i><span class='nav-label'>Academia</span><span class='fa arrow'></span>" +
                                "</a>" +
                                "<ul class='nav nav-second-level'>";
                var pantallasPorRol = db.SP_PantallasPorRoles_SeleccionarPantallasPorRol(usuario[0].Roles_Id).ToList();
                string layout = "<li>" +
                            "<a href='{url}'>" +
                                "<i class='{icon}'></i> {item.Panta_Descripcion}" +
                            "</a>" +
                        "</li>";
                string layoutWithReplacedIcon = "";
                string layoutWithReplacedUrl = "";
                foreach (var item in pantallasPorRol)
                {
                    switch (item.Panta_Esquema)
                    {
                        case "Acces":
                            layoutWithReplacedIcon = layout.Replace("{icon}", "fa fa-lock");
                            layoutWithReplacedUrl += layoutWithReplacedIcon.Replace("{url}", Url.Action("Index", item.Panta_Descripcion));
                            esquemaAccesosHTML += layoutWithReplacedUrl.Replace("{item.Panta_Descripcion}", item.Panta_Descripcion);
                            layoutWithReplacedIcon = "";
                            layoutWithReplacedUrl = "";
                            break;
                        case "Mante":
                            layoutWithReplacedIcon = layout.Replace("{icon}", "fa fa-lock");
                            layoutWithReplacedUrl += layoutWithReplacedIcon.Replace("{url}", Url.Action("Index", item.Panta_Descripcion));
                            esquemaMantenimientoHTML += layoutWithReplacedUrl.Replace("{item.Panta_Descripcion}", item.Panta_Descripcion);
                            layoutWithReplacedIcon = "";
                            layoutWithReplacedUrl = "";
                            break;
                        case "Acade":
                            layoutWithReplacedIcon = layout.Replace("{icon}", "fa fa-book");
                            layoutWithReplacedUrl += layoutWithReplacedIcon.Replace("{url}", Url.Action("Index", item.Panta_Descripcion));
                            esquemaAcademiaHTML += layoutWithReplacedUrl.Replace("{item.Panta_Descripcion}", item.Panta_Descripcion);
                            layoutWithReplacedIcon = "";
                            layoutWithReplacedUrl = "";
                            break;
                        case "Calif":
                            layoutWithReplacedIcon = layout.Replace("{icon}", "fa fa-book");
                            layoutWithReplacedUrl += layoutWithReplacedIcon.Replace("{url}", Url.Action("Index", item.Panta_Descripcion));
                            esquemaAcademiaHTML += layoutWithReplacedUrl.Replace("{item.Panta_Descripcion}", item.Panta_Descripcion);
                            layoutWithReplacedIcon = "";
                            layoutWithReplacedUrl = "";
                            break;
                        default:
                            break;
                    }
                }
                if (esquemaAccesosHTML.Contains("<li>"))
                {
                    esquemaAccesosHTML += "</ul>";
                    menuHTML += esquemaAccesosHTML;
                }
                if (esquemaMantenimientoHTML.Contains("<li>"))
                {
                    esquemaMantenimientoHTML += "</ul>";
                    menuHTML += esquemaMantenimientoHTML;
                }
                if (esquemaAcademiaHTML.Contains("<li>"))
                {
                    esquemaAcademiaHTML += "</ul>";
                    menuHTML += esquemaAcademiaHTML;
                }
                menuHTML += "</li>";
                Session["menuHTML"] = menuHTML;
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            return RedirectToAction("Login");
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
                    return Json(db.SP_Departamentos_LlenarEditar(id).ToList(), JsonRequestBehavior.AllowGet);
                case "tbTitulos":
                    return Json(db.SP_Titulos_LlenarEditar(int.Parse(id)).ToList(), JsonRequestBehavior.AllowGet);
                case "tbMunicipios":
                    return Json(db.SP_Municipios_LlenarEditar(id).ToList(), JsonRequestBehavior.AllowGet);
                case "tbEstadosCiviles":
                    return Json(db.SP_EstadosCiviles_LlenarEditar(int.Parse(id)).ToList(), JsonRequestBehavior.AllowGet);
            }
            return Json(0);
        }
    }
}