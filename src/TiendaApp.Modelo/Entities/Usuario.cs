using System.ComponentModel.DataAnnotations;

namespace TiendaApp.Modelo.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string DNI { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
        
        public ICollection<UsuarioRol> UsuariosRoles { get; set; } = [];
    }
}
