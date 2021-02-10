using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
	public class Location
	{
		[Display(Name = "Postal Code")]
		public string ZIP { get; set; }
		[Display(Name = "Location")]
		public string Name { get; set; }
		[Display(Name = "Latitude")]
		public double Latitude { get; set; }
		[Display(Name = "Longitude")]
		public double Longitude { get; set; }
	}
}
