using Microsoft.EntityFrameworkCore;

namespace VeritabanıProje.Models
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server = DESKTOP-LID0JU7; database = VeritabaniProje; integrated security = true");
		}
		public DbSet<Fuar> fuars { get; set; }
		public DbSet<Sektor> sektors { get; set; }
		public DbSet<Sirket> sirkets { get; set; }
		public DbSet<Stand> stands { get; set; }
		public DbSet<Ziyaretci> ziyaretcis { get; set; }
		public DbSet<Admin> admins { get; set; }

	}
}
