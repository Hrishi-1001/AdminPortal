using AdminPortal.Web.Data;
using System.Collections.Generic;
using System.Linq;

namespace AdminPortal.Web.Services
{
	public class DbService
	{
		private readonly DatabaseContext databaseContext;

		public DbService(Data.DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public IList<Models.Alert> Alerts => databaseContext.Alerts.ToList();
		public IList<Models.Asset> Assets => databaseContext.Assets.ToList();
		public IList<Models.Location> Locations => databaseContext.Locations.ToList();
	}
}
