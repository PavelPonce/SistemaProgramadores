using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(EstadosCivilesMetaData))]
    public partial class tbEstadosCiviles
    {

    }
    public class EstadosCivilesMetaData
    {
        public int Estci_Id { get; set; }
        [Display(Name = "Estado Civil")]
        [Required]
        [RegularExpression(@"^[a-zA-ZáéíóúüñÑ]+$",ErrorMessage = "El campo {0} solo acepta letras")]
        public string Estci_Descripcion { get; set; }
    }
}