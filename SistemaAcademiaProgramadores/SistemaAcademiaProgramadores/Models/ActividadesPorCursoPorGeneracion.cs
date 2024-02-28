using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(ActividadesPorCursoPorGeneracionMetaData))]
    public partial class tbActividadesPorCursoPorGeneracion
    {

    }
    public class ActividadesPorCursoPorGeneracionMetaData
    {
        public int ActCG_Id { get; set; }
        [Display(Name = "Nombre de la Actividad")]
        public int Activ_Id { get; set; }
        [Display(Name = "Nombre del Curso")]
        public int CuGen_Id { get; set; }
        [RegularExpression(@"^[0-9]{1,2}(?:\.[0-9]{1,2})?$", ErrorMessage = "El {0} acepta numeros decimales 0 - 100")]
        [Display(Name = "Nota por Actividad")]
        public decimal ActCG_Nota { get; set; }

    }
}