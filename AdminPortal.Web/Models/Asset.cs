using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Web.Models
{
	public class Asset
	{
		[Key]
		public string ID { get; set; }

		[DataType(DataType.PostalCode)]
		public int ZIP { get; set; }

		public string Latitude { get; set; }
		public string Longitude { get; set; }

		[DataType(DataType.MultilineText)] 
		public string Alert { get; set; } //needs to be a separate class

		public Asset()
		{

		}

	}
}
