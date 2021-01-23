using AdminPortal.Web.Models;
using System.Collections.Generic;

namespace AdminPortal.Web.Data
{
	public interface IAssetRepository
	{
		IEnumerable<Asset> GetAllAssets();
		IEnumerable<Asset> GetAssetsByID(string id);
	}
}