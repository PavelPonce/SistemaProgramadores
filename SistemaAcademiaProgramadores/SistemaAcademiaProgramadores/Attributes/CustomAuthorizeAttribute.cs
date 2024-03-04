using SistemaAcademiaProgramadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SistemaAcademiaProgramadores.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string ControllerName { get; set; }
        static string ParsearControllerName(string input)
        {
            //Estos son casos especiales
            if (input == "InstructoresPorCursoPorGeneracion")
            {
                return "Administracion de Cursos";
            }
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            StringBuilder result = new StringBuilder(input[0].ToString());

            for (int i = 1; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]) && char.IsLower(input[i - 1]))
                {
                    result.Append(' '); // Add a space before the uppercase letter
                }

                result.Append(input[i]);
            }

            return result.ToString();
        }
        private string GetRolesFromDatabase(string Panta_Descripcion)
        {
            dbAcademiaProgramadoresEntities2 db = new dbAcademiaProgramadoresEntities2();
            var listaRolesPorPantalla = db.SP_PantallasPorRoles_SeleccionarRolesPorPantalla(Panta_Descripcion).ToList();

            var str = "";
            for (int i = 0; i < listaRolesPorPantalla.Count; i++)
            {
                if (i == listaRolesPorPantalla.Count - 1)
                {
                    str += listaRolesPorPantalla[i].Roles_Descripcion;
                }
                else
                {
                    str += $"{listaRolesPorPantalla[i].Roles_Descripcion}, ";
                }
            }
            return str;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string roles = GetRolesFromDatabase(ParsearControllerName(ControllerName));
            Roles = roles;
            base.OnAuthorization(filterContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}