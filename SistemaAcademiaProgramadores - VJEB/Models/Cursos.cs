using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(CursosMetaData))]
    public partial class tbCursos
    {
       
    }
    public class CursosMetaData
    {
        public int Curso_Id { get; set; }
        [Display(Name = "Curso")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Curso_Nombre { get; set; }
        [Display(Name = "Categoria de Curso")]
        public int Categ_Id { get; set; }
    }
}