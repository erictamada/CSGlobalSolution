using GlobalSolutionCS.Data;
using GlobalSolutionCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionCS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LixeirasController : ControllerBase
	{
		private readonly SmartBinContext _context;

		public LixeirasController(SmartBinContext context)
		{
			_context = context;
		}

		// GET: api/Lixeiras
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Lixeira>>> GetLixeiras()
		{
			return await _context.Lixeiras.Include(l => l.Itens).ToListAsync();
		}

		// GET: api/Lixeiras/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<Lixeira>> GetLixeira(int id)
		{
			var lixeira = await _context.Lixeiras.Include(l => l.Itens).FirstOrDefaultAsync(l => l.Id == id);

			if (lixeira == null)
			{
				return NotFound();
			}

			return lixeira;
		}

		// POST: api/Lixeiras
		[HttpPost]
		public async Task<ActionResult<Lixeira>> PostLixeira(Lixeira lixeira)
		{
			if (lixeira == null)
			{
				return BadRequest();
			}

			foreach (var item in lixeira.Itens)
			{
				item.LixeiraId = lixeira.Id;  // Vincula o item à lixeira
			}

			_context.Lixeiras.Add(lixeira);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetLixeira), new { id = lixeira.Id }, lixeira);
		}

		// PUT: api/Lixeiras/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> PutLixeira(int id, Lixeira lixeira)
		{
			if (id != lixeira.Id)
			{
				return BadRequest();
			}

			_context.Entry(lixeira).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LixeiraExists(id))
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

		// DELETE: api/Lixeiras/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteLixeira(int id)
		{
			var lixeira = await _context.Lixeiras.FindAsync(id);
			if (lixeira == null)
			{
				return NotFound();
			}

			_context.Lixeiras.Remove(lixeira);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool LixeiraExists(int id)
		{
			return _context.Lixeiras.Any(e => e.Id == id);
		}
	}
}