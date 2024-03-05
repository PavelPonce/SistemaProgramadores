using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(PersonasMetaData))]
    public partial class tbPersonas
    {

    }
    public class PersonasMetaData
    {
        public int Perso_Id { get; set; }
        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Perso_PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre")]

        public string Perso_SegundoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Perso_PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]

        public string Perso_SegundoApellido { get; set; }
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public System.DateTime Perso_FechaNacimiento { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Perso_Sexo { get; set; }
        [Display(Name = "Estado Civil")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public int Estci_Id { get; set; }
        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(150,ErrorMessage ="El campo {0} tiene un maximo de 150 caracteres")]

        public string Perso_Direccion { get; set; }
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Munic_Id { get; set; }
        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El campo {0} es requerido")]

        public string Perso_Telefono { get; set; }
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [RegularExpression(@"^(([^<>()[]\.,;:\s@\”]+(.[^<>()[]\.,;:\s@\”]+)*)|(\”.+\”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|(([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$")]
        public string Perso_CorreoElectronico { get; set; }
    }
}