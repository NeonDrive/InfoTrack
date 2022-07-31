using InfoTrackScraper;
using InfoTrackScraper.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace InfoTrackScraper.Tests.Controllers
{
	[TestClass]
	public class HomeControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			HomeController controller = new HomeController();

			// Act
			ViewResult result = controller.Index(new Models.SearchViewModel()) as ViewResult;

			// Assert
			Assert.IsNotNull(result);
		}
	}
}
