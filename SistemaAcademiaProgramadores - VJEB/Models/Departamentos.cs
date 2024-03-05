using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(DepartamentosMetaData))]
    public partial class tbDepartamentos
    {

    }
    public class DepartamentosMetaData
    {
        [Display(Name ="Codigo")]
        [Required]
        [RegularExpression(@"^[0-9]{2}$",ErrorMessage = "2 caracteres numericos ('01', '02'...)")]
        public string Depar_Id { get; set; }
        [Required] 
        [Display(Name ="Departamento")]

        public string Depar_Descripcion { get; set; }
    }
}