using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
	public class Asset
	{
		[Display(Name = "Asset ID")]
		public int Id { get; set; }

		[Display(Name = "State")]
		public AssetState State { get; set; }

		[Display(Name = "Current Temperature")]
		public decimal Temperature { get; set; }
		
		[Display(Name = "Current Mosture")]
		public decimal Moisture { get; set; }

		public IList<Alert> Alerts { get; set; }

		public Location Location { get; set; }

		[DataType(DataType.PostalCode)]
		public int LocationId { get; set; }

		[Display(Name = "Latitude")]
		public double Latitude { get; set; }

		[Display(Name = "Longitude")]
		public double Longitude { get; set; }
	}
}
