using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoTrackScraper.Models {
	public class SearchViewModel {
		[Display(Name = "Search:")]
		public string SearchText { get; set; } = "";

		[Display(Name = "Use the default search text:")]
		public bool DefaultSearchIsChecked { get; set; }

		[Display(Name = "The current result number is")]
		public int? CurrentResult { get; set;} //TODO: This may need to be an array as the result may appear more than once

		[Display(Name = "The past results have been:")]
		public List<SearchResult> SearchResults { get; set; } = new List<SearchResult>(){
			new SearchResult(){SearchDateTime = System.DateTime.Now, Location = 3}
		};
	}
}