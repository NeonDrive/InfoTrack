using System.Collections.Generic;
using System.Linq;
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
			// retrieve the data from the CSV file
			return View("Index", SVM);
		}

		[HttpPost]
		public ActionResult GSearch(SearchViewModel SearchModel) {
			_ = PostGoogleConsentSave().Result;
			
			string url = $"https://google.co.uk/search?num=100&q={SearchModel.SearchText.Replace(" ", "+")}";
			SearchModel.WebResponse = CallUrl(url).Result;

			SearchModel.CurrentResult = GetIndexOf(SearchModel.WebResponse, "www.infotrack.co.uk");

			//append the number and the DateTime into a CSV file
			return View("Index", SearchModel);
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

		private int GetIndexOf(string HTML, string URL) {
			var split = HTML.Split('<').Where(s => s.StartsWith("a href=\"/url?q="));

			 return split.Any(s => s.ToLower().Contains(URL)) ? split.Select((String, Index) => new {String, Index})
																	 .FirstOrDefault(s => s.String.ToLower().Contains(URL)).Index
															  : -1;
		}
	}
}