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
        public int CenEd_IdColegio { get; set; }
        public int CenEd_IdUniversidad { get; set; }
        public int Titul_Id { get; set; }
        public string Alumn_Observaciones { get; set; }
        public System.DateTime Alumn_FechaIngreso { get; set; }

    }
}