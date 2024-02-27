using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(UsuariosMetaData))]
    public partial class tbUsuario
    {

    }
    public class UsuariosMetaData
    {
        [Display(Name = "Id")]
        public int Usuar_Id { get; set; }

        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "{0} es requerido")]
        public string Usuar_Usuario { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "{0} es requerida")]
        public string Usuar_Contrasena { get; set; }
        [Display(Name = "Correo")]
        public string Usuar_Correo { get; set; }
        [Display(Name = "Ultima Sesion")]
        public Nullable<System.DateTime> Usuar_UltimaSesion { get; set; }
        [Display(Name = "Instructor")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int Instr_Id { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "{0} es requerido")]
        public int Roles_Id { get; set; }
        [Display(Name = "Es Admin")]
        public Nullable<bool> Usuar_Admin { get; set; }
    }
}