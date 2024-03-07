using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(GeneracionesMetaData))]
    public partial class tbGeneraciones
    {

    }
    public class GeneracionesMetaData
    {
        public int Gener_Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(30,ErrorMessage = "El campo {0} tiene un maximo de 30 caracteres")]
        public string Gener_Nombre { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "El {0} es requerido")]
        [RegularExpression("[0-9]*$", ErrorMessage = "El {0} solo puede contener numeros")]
        [Range(1900, 3000, ErrorMessage = "El {0} no puede ser menor a 1900 ni mayor a 3000")]
        public int Gener_Anhio { get; set; }
    }
}