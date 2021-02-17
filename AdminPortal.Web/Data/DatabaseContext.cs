using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Web.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{

		}

		public DbSet<Models.Asset> Assets { get; set; }
		public DbSet<Models.Alert> Alerts { get; set; }
		public DbSet<Models.Location> Locations { get; set; }
	}
}
