using GlobalSolutionCS.Data;
using GlobalSolutionCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionCS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsuariosController : ControllerBase
	{
		private readonly SmartBinContext _context;

		public UsuariosController(SmartBinContext context)
		{
			_context = context;
		}

		// GET: api/Usuarios
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
		{
			return await _context.Usuarios.Include(u => u.Pontuacoes).ToListAsync();
		}

		// GET: api/Usuarios/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Usuario>> GetUsuario(int id)
		{
			var usuario = await _context.Usuarios.Include(u => u.Pontuacoes).FirstOrDefaultAsync(u => u.Id == id);

			if (usuario == null)
			{
				return NotFound();
			}

			return usuario;
		}

		// POST: api/Usuarios
		[HttpPost]
		public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
		{
			if (usuario == null)
			{
				return BadRequest();
			}

			foreach (var pontos in usuario.Pontuacoes)
			{
				pontos.Usuario = usuario;  // Vincula a pontuação ao usuário
			}

			_context.Usuarios.Add(usuario);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
		}

		// PUT: api/Usuarios/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
		{
			if (id != usuario.Id)
			{
				return BadRequest();
			}

			_context.Entry(usuario).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UsuarioExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE: api/Usuarios/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUsuario(int id)
		{
			var usuario = await _context.Usuarios.FindAsync(id);
			if (usuario == null)
			{
				return NotFound();
			}

			_context.Usuarios.Remove(usuario);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UsuarioExists(int id)
		{
			return _context.Usuarios.Any(e => e.Id == id);
		}
	}
}