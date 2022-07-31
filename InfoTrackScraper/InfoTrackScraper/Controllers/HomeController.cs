using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using InfoTrackScraper.Models;

namespace InfoTrackScraper.Controllers
{
	public class HomeController : Controller
	{
		private static readonly HttpClient WebClient = new HttpClient();

		public ActionResult Index(SearchViewModel SVM) {
			// retrieve the data from the JSON file
			return View("Index", SVM);
		}

		[HttpPost]
		public ActionResult GSearch(SearchViewModel SearchModel) {
			if(SearchModel.DefaultSearchIsChecked){
				SearchModel.CurrentResult = 99; 
			}
			else{
				SearchModel.CurrentResult = 101; 
			}
			
			var response = PostGoogleConsentSave().Result;
			
			string url = $"https://google.co.uk/search?num=100&q={SearchModel.SearchText.Replace(" ", "+")}";
			SearchModel.WebResponse = CallUrl(url).Result;

			return View("Index", SearchModel);
			//Search google for the string
			//get the first 100 results
			//search for the index of the string
			//return the number or null
			//append the number and the DateTime into a JSON file
		}

		private async Task<string> CallUrl(string URL) =>
			await WebClient.GetStringAsync(URL).ConfigureAwait(false);

		private async Task<HttpResponseMessage> PostGoogleConsentSave() {
			Dictionary<string, string> values = new Dictionary<string, string>{
				{ "bl", "boq_identityfrontenduiserver_20220726" },
				{ "x", "8" },
				{ "gl", "GB" },
				{ "m", "0" },
				{ "pc", "srp" },
				{ "continue", "https://www.google.co.uk/search?num=100&amp;q=land+registry+searches" },
				{ "hl", "en" },
				{ "uxe", "eomtse" },
				{ "set_eom", "false" },
				{ "set_sc", "true" },
				{ "set_aps", "true" }
			};
			var resp =  await WebClient.PostAsync("https://consent.google.co.uk/save", new FormUrlEncodedContent(values)).ConfigureAwait(false);
			return resp;
		}
	}
}