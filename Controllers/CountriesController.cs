
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestCountries.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CountriesController : ControllerBase
	{

		public static string countriesUrl = "https://restcountries.com/v3.1/all";
		public static string findCountryUrl = "https://restcountries.com/v3.1/name";

		HttpClient client = new HttpClient();

		[HttpGet]
		public async Task<dynamic> Get()
		{
			dynamic result = "";
			HttpResponseMessage response = await client.GetAsync(countriesUrl);
			if (response.IsSuccessStatusCode)
			{
				result = await response.Content.ReadAsStringAsync();
			}

			return result;
		}

		[HttpGet("country/{name}")]
		public async Task<dynamic> GetCountry(string name)
		{
			dynamic result = "";
			HttpResponseMessage response = await client.GetAsync($"{findCountryUrl}/{name}");
			if (response.IsSuccessStatusCode)
			{
				result = await response.Content.ReadAsStringAsync();
			}

			return result;
		}
	}
}
