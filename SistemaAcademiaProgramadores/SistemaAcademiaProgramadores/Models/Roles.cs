using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(RolesMetaData))]
    public partial class tbRoles
    {

    }
    public class RolesMetaData
    {
        [Display(Name = "Id Rol")]
        public int Roles_Id { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "El {0} solo puede contener letras")]
        public string Roles_Descripcion { get; set; }
    }
}