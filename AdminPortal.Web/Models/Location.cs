using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Web.Models
{
	public class Location
	{
		[DataType(DataType.PostalCode)]
		public int Id { get; set; }
		
		[Display(Name = "Area")]
		public string Name { get; set; }

		public IList<Asset> Assets { get; set; }
	}
}
