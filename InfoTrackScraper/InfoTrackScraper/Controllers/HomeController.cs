using System.Web.Mvc;
using InfoTrackScraper.Models;

namespace InfoTrackScraper.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index(SearchViewModel srvm) {
			// retrieve the data from the JSON file
			return View("Index", srvm);
		}

		[HttpPost]
		public ActionResult GSearch(SearchViewModel SearchModel) {
			SearchViewModel srvm = new SearchViewModel();
			if(SearchModel.DefaultSearchIsChecked){
				SearchModel.SearchText = "The checkbox was selected";
				SearchModel.CurrentResult = 99; 
			}
			else{
				SearchModel.SearchText = "checkbox was unselected";
				SearchModel.CurrentResult = 101; 
			}

			return View("Index", SearchModel);
			//Search google for the string
			//get the first 100 results
			//search for the index of the string
			//return the number or null
			//append the number and the DateTime into a JSON file
		}
	}
}