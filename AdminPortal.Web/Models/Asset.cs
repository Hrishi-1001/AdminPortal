using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Web.Models
{
	public class Asset
	{
		[Key]
		public string ID { get; set; }

		[DataType(DataType.PostalCode)]
		public string ZIP { get; set; }

		public State State { get; set; }

		public Asset()
		{
			
		}

	}
}
