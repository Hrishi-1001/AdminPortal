using AdminPortal.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdminPortal.Repository
{
	public class AdminPortalDbContext : DbContext
	{
		public AdminPortalDbContext(DbContextOptions<AdminPortalDbContext> options) : base(options)
		{
			
		}

		public DbSet<User> Users { get; set; }
	}
}
