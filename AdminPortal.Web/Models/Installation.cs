using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminPortal.Web.Models
{
	public class Installation
	{
		[Key]
		public string ID { get; set; }

		[DataType(DataType.PostalCode)]
		public int ZIP { get; set; }
		
		public Location Location { get; set; }

		[DataType(DataType.MultilineText)]
		public string Alert { get; set; }
	}
}
