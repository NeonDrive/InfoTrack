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
		public List<SearchResult> SearchResults { get; set; } = new List<SearchResult>(){ //TODO: These should be read in values
			new SearchResult(){SearchDateTime = System.DateTime.Now, Location = 3},
			new SearchResult(){SearchDateTime = System.DateTime.Now.AddDays(-346315), Location = 14},
			new SearchResult(){SearchDateTime = System.DateTime.Now.AddHours(-3546315), Location = 15}
		};

		public string WebResponse {get; set;} = "";
	}
}