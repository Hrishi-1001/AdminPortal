using AdminPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Data
{
	public class AssetRepository : IAssetRepository
	{
		private readonly AssetContext assetContext;

		public AssetRepository(AssetContext assetContext)
		{
			this.assetContext = assetContext;
		}

		public IEnumerable<Asset> GetAllAssets()
		{
			var assets = from asset in assetContext.Assets
						 select asset;
			return assets;
		}

		public IEnumerable<Asset> GetAssetsByID(string id)
		{
			var assets = from asset in assetContext.Assets
						 where asset.ID.Contains(id)
						 select asset;
			return assets;
		}

	}
}
