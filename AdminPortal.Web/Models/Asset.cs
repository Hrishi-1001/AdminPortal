﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{

	public class Asset
	{
		[Key]
		public int AssetID { get; set; }

		public Location Area { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		
		public AssetState State { get; set; }

		public decimal Temperature { get; set; }
		public decimal Moisture { get; set; }
	}
}
