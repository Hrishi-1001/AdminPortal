using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Web.Models
{
	public enum AssetState
	{
		[Display(Name = "Non-functional")]
		non_functional,
		[Display(Name = "Under-Maintenance")]
		under_maintenance,
		[Display(Name = "Functional")]
		functional
	}
}
