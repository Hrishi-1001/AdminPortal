using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace AdminPortal.Data
{
	public class Instalment
	{
		public Instalment(IPAddress iD, string location)
		{
			ID = iD;
			Location = location;
		}

		//ID
		public IPAddress ID { get; set; }

		[DataType(DataType.PostalCode)]
		public string Location { get; set; }
	}
}
