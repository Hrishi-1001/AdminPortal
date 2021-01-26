using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Web.Models
{
	public class Asset
	{
		public enum State
		{
			Offline,
			Online,
			AlertPresent,
			UnderMaintenance,
		}

		[Key]
		public string ID { get; set; }

		[DataType(DataType.PostalCode)]
		public string ZIP { get; set; }

		public int CurrentStatus { get; set; }

		public Asset()
		{
			CurrentStatus = (int)State.AlertPresent;
		}

	}
}
