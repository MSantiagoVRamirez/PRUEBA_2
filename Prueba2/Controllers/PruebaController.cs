using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Models;


namespace Prueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly PruebaContext _context;

        public UsuarioController(PruebaContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("crear")]

        public async Task<IActionResult> CrearProductos(Usuarios usuarios)
        {
            await _context.Usuarios.AddAsync(usuarios);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Usuarios>>> ListaUsuarios()
        {
            var productos = await _context.Usuarios.ToListAsync();

            return Ok(productos);
        }
        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> verUsuario(int Id)
        {
            Usuarios usuarios = await _context.Usuarios.FindAsync(Id);

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarUsuario(int Id, Usuarios usuarios)
        {
            var usuariosExistente = await _context.Usuarios.FindAsync(Id);

            usuariosExistente!.Nombre = usuarios.Nombre;
            usuariosExistente.Apellido = usuarios.Apellido;
            usuariosExistente.Correo = usuarios.Correo;
            usuariosExistente.Edad = usuarios.Edad;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarUsuario(int Id)
        {
            var usuarioBorrado = await _context.Usuarios.FindAsync(Id);

            _context.Usuarios.Remove(usuarioBorrado);

            await _context.SaveChangesAsync();
            return Ok();
        }
        
   
    }

}
