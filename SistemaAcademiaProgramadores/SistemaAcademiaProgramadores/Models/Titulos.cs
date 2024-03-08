using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(TitulosMetaData))]
    public partial class tbTitulos
    {

    }
    public class TitulosMetaData
    {
        [Display(Name = "Titulo")]
        public int Titul_Id { get; set; }
        [Display(Name = "Titulo")]
        [StringLength(60)]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Titul_Nombre { get; set; }
        [Display(Name = "Tipo de Titulo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        
        public string Titul_Tipo { get; set; }
    }
}