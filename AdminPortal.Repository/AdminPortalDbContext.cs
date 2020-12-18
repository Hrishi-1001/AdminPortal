using AdminPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminPortal.Repository
{
	public class AdminPortalDbContext : DbContext
	{
		public AdminPortalDbContext(DbContextOptions<AdminPortalDbContext> options) : base(options)
		{
			
		}

		public DbSet<IUser> Users { get; set; }
	}
}
