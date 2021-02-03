using AdminPortal.Web.Data;
using AdminPortal.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace AdminPortal.Web.Pages.Partials
{
	public class SelectLocModel : PageModel
	{
		private readonly HttpClient httpClient;
		private readonly string key = "AIzaSyBNP8qLyU6qxfS49mZ4O9n4JQrSbc8p-EM";

		public string Location { get; set; }

		public List<SelectListItem> Locations { get; }

		public SelectLocModel(HttpClient httpClient, AppDbContext locationDbContext)
		{
			this.httpClient = httpClient;
			foreach (var location in locationDbContext.Locations)
			{
				Locations.Add(new SelectListItem(location.Name, location.Name));
			}
		}

		public void OnSubmit()
		{

		}

		public void OnGet()
		{
			
		}

		public void OnGetSubmit()
		{

		}

		public async void OnGetLocation()
		{
			string geocodeRequest = $"https://maps.googleapis.com/maps/api/geocode/json?address={Location}&key={key}";
			Location jsonResponse = await httpClient.GetFromJsonAsync<Location>(geocodeRequest);
		}
	}
}
