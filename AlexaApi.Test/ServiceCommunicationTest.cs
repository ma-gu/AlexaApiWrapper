using AlexaApi.ResponseModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;



namespace AlexaApi.Test
{
    [TestClass]
	public class ServiceCommunicationTest
	{
        private const string _alexaKey = "Your key here";
        private const string _alexaSecretKey = "Your secret key here";

        private readonly string _sampleDataPath = Path.Combine(Environment.CurrentDirectory, "Sample.TestData");

		private readonly Type[] _typesToCompare = new[] { typeof(int), typeof(double), typeof(string), typeof(DateTime), 
		typeof(int?), typeof(double?), typeof(DateTime?)};

		private string PathFor(string sampleFile)
		{
			return Path.Combine(_sampleDataPath, sampleFile);
		}

		private T LoadSample<T>(string filename)
		{
			var xmlpath = PathFor(filename);
			var doc = XDocument.Load(xmlpath);

			var xml = new XmlDeserializer();
			var output = xml.Deserialize<T>(new RestResponse { Content = doc.ToString() });
			return output;
		}

		private void TestTemplate<T>(string filename, Func<T> endpointMethod)
		{
			try
			{
				var expected = LoadSample<T>(filename);
				var actual = endpointMethod();
				Assert.AreEqual(expected, actual);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[TestMethod]
		public void UrlInfoMS()
		{
			var client = new AlexaClient(_alexaKey, _alexaSecretKey);
			TestTemplate<UrlInfoResponse>("UrlInfo-microsoft.xml",
				() => client.GetUrlInfo("http://microsoft.com", UrlInfoResponseGroup.All));
		}

		[TestMethod]
		public void TrafficHistoryYahoo()
		{
			var client = new AlexaClient(_alexaKey, _alexaSecretKey);
			TestTemplate<TrafficHistoryResponse>("TrafficHistory-yahoo.xml",
				() => client.GetTrafficHistory("http://yahoo.com", 31, new DateTime(2007, 8, 1)));
		}

		[TestMethod]
		public void CategoryBrowseBoard_Games()
		{
			var client = new AlexaClient(_alexaKey, _alexaSecretKey);
			TestTemplate<CategoryBrowseResponse>("CategoryBrowse_Board_Games.xml",
				() => client.GetCategoryBrowse(CategoryBrowseResponseGroup.All, "Top/Games/Board_Games"));
		}

		[TestMethod]
		public void CategoryListingsTop_Arts_Literature_Authors()
		{
			var client = new AlexaClient(_alexaKey, _alexaSecretKey);
			TestTemplate<CategoryListingsResponse>("CategoryListings_Top_Arts_Literature_Authors.xml",
				() => client.GetCategoryListings("Top/Arts/Literature/Authors", CategoryListingsSortBy.AverageReview,
					true, descriptions: true));
		}

		[TestMethod]
		public void SitesLinkingInYahoo()
		{
			var client = new AlexaClient(_alexaKey, _alexaSecretKey);
			TestTemplate<SitesLinkingInResponse>("SitesLinkingIn-yahoo.xml",
				() => client.GetSitesLinkingIn("yahoo.com"));
		}

	}
}
