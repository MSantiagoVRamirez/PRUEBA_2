using System.ComponentModel.DataAnnotations;

namespace Prueba2.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; } = null!;

        [MaxLength(50)]
        public string Apellido { get; set; } = null!;

        [EmailAddress]
        [MaxLength(50)]
        public string Correo { get; set; } = null!;

        public int Edad { get; set; }  
    }
}
