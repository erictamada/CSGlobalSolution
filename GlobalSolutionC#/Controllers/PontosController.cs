using GlobalSolutionCS.Data;
using GlobalSolutionCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionCS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PontosController : ControllerBase
	{
		private readonly SmartBinContext _context;

		public PontosController(SmartBinContext context)
		{
			_context = context;
		}

		// GET: api/Pontos
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Pontos>>> GetPontos()
		{
			return await _context.Pontos.Include(p => p.Usuario).ToListAsync();
		}

		// GET: api/Pontos/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Pontos>> GetPonto(int id)
		{
			var ponto = await _context.Pontos.Include(p => p.Usuario).FirstOrDefaultAsync(p => p.Id == id);

			if (ponto == null)
			{
				return NotFound();
			}

			return ponto;
		}

		// POST: api/Pontos
		[HttpPost]
		public async Task<ActionResult<Pontos>> PostPonto(Pontos ponto)
		{
			if (ponto == null)
			{
				return BadRequest();
			}

			_context.Pontos.Add(ponto);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPonto), new { id = ponto.Id }, ponto);
		}

		// PUT: api/Pontos/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPonto(int id, Pontos ponto)
		{
			if (id != ponto.Id)
			{
				return BadRequest();
			}

			_context.Entry(ponto).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PontoExists(id))
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

		// DELETE: api/Pontos/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePonto(int id)
		{
			var ponto = await _context.Pontos.FindAsync(id);
			if (ponto == null)
			{
				return NotFound();
			}

			_context.Pontos.Remove(ponto);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PontoExists(int id)
		{
			return _context.Pontos.Any(e => e.Id == id);
		}
	}
}