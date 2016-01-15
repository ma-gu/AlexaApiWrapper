using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlexaApi;
using AlexaApi.ResponseModel;
using RestSharp;

namespace AlexaApi.Test
{
	[TestClass]
	public class DeserealizationTests
	{
		[TestMethod]
		public void UrlInfoDeserializationTest()
		{
			const string content =
				"<aws:UrlInfoResponse xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:Response xmlns:aws='http://awis.amazonaws.com/doc/2005-07-11'><aws:OperationRequest><aws:RequestId>5486794a-0d03-4d47-a45b-e95764c3f0ee</aws:RequestId></aws:OperationRequest><aws:UrlInfoResult><aws:Alexa><aws:ContentData><aws:DataUrl type='canonical'>yahoo.com/</aws:DataUrl><aws:Asin>B00006D2TC</aws:Asin><aws:SiteData><aws:Title>Yahoo!</aws:Title><aws:Description>Personalized content and search options. Chatrooms, free e-mail, clubs, and pager.</aws:Description><aws:OnlineSince>18-Jan-1995</aws:OnlineSince></aws:SiteData><aws:Speed><aws:MedianLoadTime>2242</aws:MedianLoadTime><aws:Percentile>51</aws:Percentile></aws:Speed><aws:AdultContent>no</aws:AdultContent><aws:Language><aws:Locale>en</aws:Locale></aws:Language><aws:LinksInCount>76894</aws:LinksInCount><aws:OwnedDomains><aws:OwnedDomain><aws:Domain>yahooligans.com</aws:Domain><aws:Title>yahooligans.com</aws:Title></aws:OwnedDomain></aws:OwnedDomains></aws:ContentData><aws:Related><aws:DataUrl type='canonical'>yahoo.com/</aws:DataUrl><aws:Asin>B00006D2TC</aws:Asin><aws:RelatedLinks><aws:RelatedLink><aws:DataUrl type='canonical'>aol.com/</aws:DataUrl><aws:NavigableUrl>http://aol.com/</aws:NavigableUrl><aws:Asin>B00006ARD3</aws:Asin><aws:Relevance>301</aws:Relevance></aws:RelatedLink></aws:RelatedLinks><aws:Categories><aws:CategoryData><aws:Title>On the Web/Web Portals</aws:Title><aws:AbsolutePath>Top/Computers/Internet/On_the_Web/Web_Portals</aws:AbsolutePath></aws:CategoryData></aws:Categories></aws:Related><aws:TrafficData><aws:DataUrl type='canonical'>yahoo.com/</aws:DataUrl><aws:Asin>B00006D2TC</aws:Asin><aws:Rank>1</aws:Rank><aws:UsageStatistics><aws:UsageStatistic><aws:TimeRange><aws:Days>1</aws:Days></aws:TimeRange><aws:Rank><aws:Value>1</aws:Value><aws:Delta>+0</aws:Delta></aws:Rank><aws:Reach><aws:Rank><aws:Value>2</aws:Value><aws:Delta>+0</aws:Delta></aws:Rank><aws:PerMillion><aws:Value>252,500</aws:Value><aws:Delta>-1%</aws:Delta></aws:PerMillion></aws:Reach><aws:PageViews><aws:PerMillion><aws:Value>51,400</aws:Value><aws:Delta>-1%</aws:Delta></aws:PerMillion><aws:Rank><aws:Value>1</aws:Value><aws:Delta>+0</aws:Delta></aws:Rank><aws:PerUser><aws:Value>13.7</aws:Value><aws:Delta>-1%</aws:Delta></aws:PerUser></aws:PageViews></aws:UsageStatistic></aws:UsageStatistics></aws:TrafficData></aws:Alexa></aws:UrlInfoResult><aws:ResponseStatus xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:StatusCode>Success</aws:StatusCode></aws:ResponseStatus></aws:Response></aws:UrlInfoResponse>";
			var xml = new RestSharp.Deserializers.XmlDeserializer();
			//xml.DateFormat = "yyyy-MM-dd";
			var output = xml.Deserialize<UrlInfoResponse>(new RestResponse { Content = content });
			Assert.AreEqual("B00006D2TC", output.UrlInfoResult.Alexa.ContentData.Asin);
		}

		[TestMethod]
		public void TrafficHistoryDeserializationTest()
		{
			const string content =
				"<aws:TrafficHistoryResponse xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:Response xmlns:aws='http://awis.amazonaws.com/doc/2005-07-11'><aws:OperationRequest><aws:RequestId>39ab4736-ec1a-492d-924b-d0d768d2692d</aws:RequestId></aws:OperationRequest><aws:TrafficHistoryResult><aws:Alexa><aws:TrafficHistory><aws:Range>31</aws:Range><aws:Site>amazon.com</aws:Site><aws:Start>2005-01-01</aws:Start><aws:HistoricalData><aws:Data><aws:Date>2005-01-01</aws:Date><aws:PageViews><aws:PerMillion>2801</aws:PerMillion><aws:PerUser>5.0</aws:PerUser></aws:PageViews><aws:Rank>18</aws:Rank><aws:Reach><aws:PerMillion>26041</aws:PerMillion></aws:Reach></aws:Data></aws:HistoricalData></aws:TrafficHistory></aws:Alexa></aws:TrafficHistoryResult><aws:ResponseStatus xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:StatusCode>Success</aws:StatusCode></aws:ResponseStatus></aws:Response></aws:TrafficHistoryResponse>";
			var xml = new RestSharp.Deserializers.XmlDeserializer();
			//xml.DateFormat = "yyyy-MM-dd";
			var output = xml.Deserialize<TrafficHistoryResponse>(new RestResponse { Content = content });
			Assert.AreEqual(2801, output.TrafficHistoryResult.Alexa.
				TrafficHistory.HistoricalData.Datas[0].PageViews.PerMillion);
		}

		[TestMethod]
		public void CatBrowseDeserializationTest()
		{
			const string content =
				"<aws:CategoryBrowseResponse xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:Response xmlns:aws='http://awis.amazonaws.com/doc/2005-07-11'><aws:OperationRequest><aws:RequestId>cadde770-fe83-483c-9bcc-465a77d4ea0c</aws:RequestId></aws:OperationRequest><aws:CategoryBrowseResult><aws:Alexa><aws:CategoryBrowse><aws:Categories><aws:Category><aws:Path>Top/Business/Consumer_Goods_and_Services/Electronics/Accessories</aws:Path><aws:Title>Accessories</aws:Title><aws:SubCategoryCount>2</aws:SubCategoryCount><aws:TotalListingCount>186</aws:TotalListingCount></aws:Category><aws:Category><aws:Path>Top/Business/Consumer_Goods_and_Services/Electronics/Audio</aws:Path><aws:Title>Audio</aws:Title><aws:SubCategoryCount>8</aws:SubCategoryCount><aws:TotalListingCount>1135</aws:TotalListingCount></aws:Category></aws:Categories><aws:LetterBars/></aws:CategoryBrowse></aws:Alexa></aws:CategoryBrowseResult><aws:ResponseStatus xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:StatusCode>Success</aws:StatusCode></aws:ResponseStatus></aws:Response></aws:CategoryBrowseResponse>";
			var xml = new RestSharp.Deserializers.XmlDeserializer();
			var output = xml.Deserialize<CategoryBrowseResponse>(new RestResponse { Content = content });
			Assert.AreEqual(186, output.CategoryBrowseResult.Alexa.CategoryBrowse.Categories[0].TotalListingCount);
		}

		[TestMethod]
		public void CatListingsDeserializationTest()
		{
			const string content =
				"<aws:CategoryListingsResponse xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:Response xmlns:aws='http://awis.amazonaws.com/doc/2005-07-11'><aws:OperationRequest><aws:RequestId>0bf0a4b0-a441-49e7-9cfe-44b71e0df086</aws:RequestId></aws:OperationRequest><aws:CategoryListingsResult><aws:Alexa><aws:CategoryListings><aws:RecursiveCount>1804</aws:RecursiveCount><aws:Count>217</aws:Count><aws:Listings><aws:Listing><aws:DataUrl type='navigable'>http://www.sony.com</aws:DataUrl><aws:Title>Sony Electronics</aws:Title><aws:PopularityRank>882</aws:PopularityRank></aws:Listing><aws:Listing><aws:DataUrl type='navigable'>http://www.samsung.com/</aws:DataUrl><aws:Title>Samsung Electronics</aws:Title><aws:PopularityRank>899</aws:PopularityRank></aws:Listing></aws:Listings></aws:CategoryListings></aws:Alexa></aws:CategoryListingsResult><aws:ResponseStatus xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:StatusCode>Success</aws:StatusCode></aws:ResponseStatus></aws:Response></aws:CategoryListingsResponse>";
			var xml = new RestSharp.Deserializers.XmlDeserializer();
			var output = xml.Deserialize<CategoryListingsResponse>(new RestResponse { Content = content });
			Assert.AreEqual(882, output.CategoryListingsResult.Alexa.CategoryListings.Listings[0].PopularityRank);
		}

		[TestMethod]
		public void SitesDeserializationTest()
		{
			const string content =
				"<aws:SitesLinkingInResponse xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:Response xmlns:aws='http://awis.amazonaws.com/doc/2005-07-11'><aws:OperationRequest><aws:RequestId>08876c86-2c4d-bc5a-108f-ca30d1cf70b7</aws:RequestId></aws:OperationRequest><aws:SitesLinkingInResult><aws:Alexa><aws:SitesLinkingIn><aws:Site><aws:Title>google.com</aws:Title><aws:Url>ibm-pc.com:80</aws:Url></aws:Site><aws:Site><aws:Title>linkedin.com</aws:Title><aws:Url>blog.linkedin.com:80/2007/09/27/a-pictures-wort</aws:Url></aws:Site></aws:SitesLinkingIn></aws:Alexa></aws:SitesLinkingInResult><aws:ResponseStatus xmlns:aws='http://alexa.amazonaws.com/doc/2005-10-05/'><aws:StatusCode>Success</aws:StatusCode></aws:ResponseStatus></aws:Response></aws:SitesLinkingInResponse>";
			var xml = new RestSharp.Deserializers.XmlDeserializer();
			var output = xml.Deserialize<SitesLinkingInResponse>(new RestResponse { Content = content });
			Assert.AreEqual("linkedin.com", output.SitesLinkingInResult.Alexa.SitesLinkingIn.Sites[1].Title);
		}

	}
}
