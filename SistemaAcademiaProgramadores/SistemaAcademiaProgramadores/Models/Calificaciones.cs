using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(CalificacionesMetaData))]
    public partial class tbCalificaciones
    {

    }
    public class CalificacionesMetaData
    {
        public int Calif_Id { get; set; }
        [Display(Name = "Nombre del Curso")]

        public int CuGen_Id { get; set; }
        [Display(Name = "Alumno")]

        public int Alumn_Id { get; set; }
        [RegularExpression(@"^[0-9]{1,2}(?:\.[0-9]{1,2})?$", ErrorMessage = "El {0} acepta numeros decimales 0 - 100")]
        [Display(Name ="Nota de Curso")]
        public decimal Calif_Nota { get; set; }
    }
}