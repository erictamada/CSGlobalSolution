using GlobalSolutionCS.Data;
using GlobalSolutionCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionCS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItensLixeiraController : ControllerBase
	{
		private readonly SmartBinContext _context;

		public ItensLixeiraController(SmartBinContext context)
		{
			_context = context;
		}

		// Método GET -> api/ItensLixeira
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ItemLixeira>>> GetItensLixeira()
		{
			return await _context.ItensLixeira.Include(i => i.Lixeira).ToListAsync();
		}

		// Método GET pelo "id" -> api/ItensLixeira/{id}
		[HttpGet("{id}")]
		public async Task<ActionResult<ItemLixeira>> GetItemLixeira(int id)
		{
			var itemLixeira = await _context.ItensLixeira.Include(i => i.Lixeira).FirstOrDefaultAsync(i => i.Id == id);

			if (itemLixeira == null)
			{
				return NotFound();
			}

			return itemLixeira;
		}

		// Método POST -> api/ItensLixeira
		[HttpPost]
		public async Task<ActionResult<ItemLixeira>> PostItemLixeira(ItemLixeira itemLixeira)
		{
			if (itemLixeira == null)
			{
				return BadRequest();
			}

			_context.ItensLixeira.Add(itemLixeira);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetItemLixeira), new { id = itemLixeira.Id }, itemLixeira);
		}

		// Método PUT -> api/ItensLixeira/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> PutItemLixeira(int id, ItemLixeira itemLixeira)
		{
			if (id != itemLixeira.Id)
			{
				return BadRequest();
			}

			_context.Entry(itemLixeira).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ItemLixeiraExists(id))
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

		// Método DELETE -> api/ItensLixeira/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteItemLixeira(int id)
		{
			var itemLixeira = await _context.ItensLixeira.FindAsync(id);
			if (itemLixeira == null)
			{
				return NotFound();
			}

			_context.ItensLixeira.Remove(itemLixeira);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool ItemLixeiraExists(int id)
		{
			return _context.ItensLixeira.Any(e => e.Id == id);
		}
	}
}
