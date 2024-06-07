using GlobalSolutionCS.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolutionCS.Data 
{
	public class SmartBinContext : DbContext
	{
		public SmartBinContext(DbContextOptions<SmartBinContext> options) : base(options) { }

		public DbSet<ItemLixeira> ItensLixeira { get; set; }
		public DbSet<Lixeira> Lixeiras { get; set; }
		public DbSet<Pontos> Pontos { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ItemLixeira>()
				.HasOne(i => i.Lixeira)
				.WithMany(l => l.Itens);
				

			modelBuilder.Entity<Pontos>()
				.HasOne(p => p.Usuario)
				.WithMany(u => u.Pontuacoes)
				.HasForeignKey(p => p.UsuarioId);
		}
	}
}
