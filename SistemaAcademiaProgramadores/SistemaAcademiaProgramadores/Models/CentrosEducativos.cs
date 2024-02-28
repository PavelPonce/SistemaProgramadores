using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(CentrosEducativosMetaData))]
    public partial class tbCentrosEducativos
    {

    }
    public class CentrosEducativosMetaData
    {
        public int CenEd_Id { get; set; }
        [Display(Name = "Centro Educativo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string CenEd_Nombre { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150)]
        public string CenEd_Direccion { get; set; }
        [Display(Name = "Tipo de Centro Educativo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string CenEd_Tipo { get; set; }
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]


        public string Munic_Id { get; set; }
    }
}