using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(AlumnosMetaData))]
    public partial class tbAlumnos
    {

    }
    public class AlumnosMetaData
    {
        public int Perso_Id { get; set; }
        [Display(Name = "Colegio")]

        [Required(ErrorMessage = "El {0} es requerido")]
        public int CenEd_IdColegio { get; set; }
        [Display(Name = "Universidad")]

        [Required(ErrorMessage = "El {0} es requerido")]
        public int CenEd_IdUniversidad { get; set; }
        [Display(Name = "Titulo")]

        [Required(ErrorMessage = "El {0} es requerido")]
        public int Titul_Id { get; set; }
        [Display(Name = "Observaciones")]
        public string Alumn_Observaciones { get; set; }
        [Display(Name = "Fecha de Ingreso")]

        [Required(ErrorMessage = "El {0} es requerido")]
        public System.DateTime Alumn_FechaIngreso { get; set; }

    }
}