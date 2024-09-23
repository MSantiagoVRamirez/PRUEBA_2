using System.ComponentModel.DataAnnotations;

namespace Prueba2.Models
{
    public class Rol
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public bool estado { get; set; }
    }
}
