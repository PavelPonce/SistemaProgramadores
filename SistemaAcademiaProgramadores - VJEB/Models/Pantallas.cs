using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(PantallasMetaData))]
    public partial class tbPantallas
    {

    }
    public class PantallasMetaData
    {
        [Display(Name = "Id Pantalla")]
        public int Panta_Id { get; set; }
        [Display(Name = "Pantalla")]
        [Required(ErrorMessage = "La {0} es requerido")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "La {0} solo puede contener letras")]
        public string Panta_Descripcion { get; set; }
    }
}