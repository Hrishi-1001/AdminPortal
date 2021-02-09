using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPortal.Web.Models
{
	public class Alert
	{
		[Key]
		public int AlertID { get; set; }

		[DataType(DataType.MultilineText)]
		public string Text { get; set; }

		public int AssetID { get; set; }
	}
}
