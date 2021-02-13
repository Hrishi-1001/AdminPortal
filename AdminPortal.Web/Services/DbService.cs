using AdminPortal.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Services
{
	public class DbService
	{
		private readonly DatabaseContext databaseContext;

		public DbService(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public DbSet<Models.Asset> Assets { get => databaseContext.Assets; }
		public DbSet<Models.Location> Locations { get => databaseContext.Locations; }
	}
}
