using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba2.Models;


namespace Prueba2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly PruebaContext _context;

        public RolesController(PruebaContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("crear")]

        public async Task<IActionResult> CrearRol(Rol rol)
        {
            await _context.Roles.AddAsync(rol);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Rol>>> ListaRoles()
        {
            var rol = await _context.Roles.ToListAsync();

            return Ok(rol);
        }
        [HttpGet]
        [Route("ver")]
        public async Task<IActionResult> verRol(int Id)
        {
            Rol rol = await _context.Roles.FindAsync(Id);

            if (rol == null)
            {
                return NotFound();
            }
            return Ok(rol);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarRol(int Id, Rol rol)
        {
            var rolesExistente = await _context.Usuarios.FindAsync(Id);

            rolesExistente!.Nombre = rol.Nombre;
            


            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarRol(int Id)
        {
            var RolBorrado = await _context.Roles.FindAsync(Id);

            _context.Roles.Remove(RolBorrado);

            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
