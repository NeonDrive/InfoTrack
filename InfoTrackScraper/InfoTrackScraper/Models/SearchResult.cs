using System;
using System.ComponentModel.DataAnnotations;

namespace InfoTrackScraper.Models {
	public class SearchResult {
		[Display(Name = "Search Time:")]
		public DateTime SearchDateTime { get; set; } //TODO: come back and rename to something more appropriate
		
		[Display(Name = "Result Location:")]
		public int Location { get; set; }
	}
}