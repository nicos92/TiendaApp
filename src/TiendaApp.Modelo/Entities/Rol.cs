using System.ComponentModel.DataAnnotations;

namespace TiendaApp.Modelo.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
        
        public ICollection<UsuarioRol> UsuariosRoles { get; set; } = [];
    }
}
