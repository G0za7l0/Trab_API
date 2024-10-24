using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabajo_Api.Data;
using Trabajo_Api.Models;

namespace Trabajo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/usuario/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _context.Database.ExecuteSqlRaw("usp_registrar @p0, @p1, @p2, @p3, @p4",
                usuario.DocumentoIdentidad, usuario.Nombres, usuario.Telefono, usuario.Correo, usuario.Ciudad);

            return Ok(result);
        }

        // PUT: api/usuario/modificar
        [HttpPut("modificar")]
        public async Task<IActionResult> Modificar([FromBody] Usuarios usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _context.Database.ExecuteSqlRaw("usp_modificar @p0, @p1, @p2, @p3, @p4, @p5",
                usuario.IdUsuario, usuario.DocumentoIdentidad, usuario.Nombres, usuario.Telefono, usuario.Correo, usuario.Ciudad);

            return Ok(result);
        }

        // GET: api/usuario/obtener/{id}
        [HttpGet("obtener/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var usuario = await _context.Usuarios.FromSqlRaw("usp_obtener @p0", id).FirstOrDefaultAsync();

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        // GET: api/usuario/listar
        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _context.Usuarios.FromSqlRaw("usp_listar").ToListAsync();
            return Ok(usuarios);
        }

        // DELETE: api/usuario/eliminar/{id}
        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = _context.Database.ExecuteSqlRaw("usp_eliminar @p0", id);

            return Ok(result);
        }
    }

}
