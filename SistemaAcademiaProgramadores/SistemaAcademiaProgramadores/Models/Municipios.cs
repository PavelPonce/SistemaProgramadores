using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(MunicipiosMetaData))]
    public partial class tbMunicipios
    {

    }
    public class MunicipiosMetaData
    {
        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "4 caracteres numericos ('01', '02'...)")]
        [Required]
        public string Munic_Id { get; set; }
        [Required]
        [Display(Name = "Municipio")]
        public string Munic_Descripcion { get; set; }
        [Display(Name = "Departamento")]
        public string Depar_Id { get; set; }
    }
}