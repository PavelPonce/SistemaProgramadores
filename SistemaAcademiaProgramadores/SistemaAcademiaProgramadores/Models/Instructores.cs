using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(InstructoresMetaData))]
    public partial class tbInstructores
    {

    }
    public class InstructoresMetaData
    {
        [Display(Name = "Instructor")]
        public int Perso_Id { get; set; }
        [Display(Name = "Titulo")]
        public int Titul_Id { get; set; }
        [Display(Name = "Universidad")]
        public int CenEd_Id { get; set; }
    }
}