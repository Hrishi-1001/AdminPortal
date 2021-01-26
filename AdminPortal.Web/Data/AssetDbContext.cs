using AdminPortal.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Data
{
	public class AssetDbContext : DbContext
	{
		public AssetDbContext(DbContextOptions<AssetDbContext> options):
			base(options)
		{ }

		public DbSet<Asset> Assets { get; set; }
	}
}
