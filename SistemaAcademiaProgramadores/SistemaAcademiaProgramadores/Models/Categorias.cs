using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{

    [MetadataType(typeof(CategoriasMetaData))]
    public partial class tbCategorias
    {

    }
    public class CategoriasMetaData
    {
        [Display(Name = "Id Categoria")]
        public int Categ_Id { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "La {0} es requerido")]
        [RegularExpression("[a-zA-Z]*$", ErrorMessage = "La {0} solo puede contener letras")]
        public string Categ_Nombre { get; set; }
        public int Categ_UsuarioCreacion { get; set; }
    }
}