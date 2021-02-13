using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
	public class Map
	{
		public double DefaultLatitude { get; set; }
		public double DefaultLongitude { get; set; }
		public int DefaultZoom { get; set; }

		public Map()
		{
			DefaultLatitude = 28.644800;
			DefaultLongitude = 77.216721;
			DefaultZoom = 8;
		}
	}
}
