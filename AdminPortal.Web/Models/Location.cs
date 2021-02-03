using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
	public class Location
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public float Latitude { get; }
		public float Longitude { get; }
	}
}
