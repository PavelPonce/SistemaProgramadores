using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SistemaAcademiaProgramadores.Models;

namespace SistemaAcademiaProgramadores.Models
{
    [MetadataType(typeof(PantallasPorRolesMetadata))]
    public partial class tbPantallasPorRoles
    {

    }
    public class PantallasPorRolesMetadata
    {
        public int Papro_Id { get; set; }
        public int Panta_Id { get; set; }
        public int Roles_Id { get; set; }
        public int Papro_UsuarioCreacion { get; set; }
        public System.DateTime Papro_FechaCreacion { get; set; }
        public Nullable<int> Papro_UsuarioModificacion { get; set; }
        public Nullable<System.DateTime> Papro_FechaModificacion { get; set; }
        public virtual tbPantallas tbPantallas { get; set; }
        public virtual tbRoles tbRoles { get; set; }
        public virtual tbUsuarios tbUsuarios { get; set; }
        public virtual tbUsuarios tbUsuarios1 { get; set; }
        
    }
}