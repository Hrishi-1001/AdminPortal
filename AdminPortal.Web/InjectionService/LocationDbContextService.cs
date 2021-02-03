using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.InjectionService
{
	public class LocationDbContextService
	{
		private readonly AppDbContext locationDbContext;

		public LocationDbContextService(AppDbContext locationDbContext)
		{
			this.locationDbContext = locationDbContext;
		}

		public AppDbContext Adopt()
		{
			return locationDbContext;
		}
	}
}
