using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    [DeserializeAs(Name = "Response")]
	public class UrlInfoResponse : IEquatable<UrlInfoResponse>
	{
		public bool Equals(UrlInfoResponse other)
		{
			return Equals(UrlInfoResult, other.UrlInfoResult) && Equals(ResponseStatus, other.ResponseStatus);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((UrlInfoResponse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((UrlInfoResult != null ? UrlInfoResult.GetHashCode() : 0) * 397) ^
                    (ResponseStatus != null ? ResponseStatus.GetHashCode() : 0);
			}
		}

		public OperationRequest OperationRequest { get; set; }
		public UrlInfoResult UrlInfoResult { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class UrlInfoResult : IEquatable<UrlInfoResult>
	{
		public bool Equals(UrlInfoResult other)
		{
			return Equals(Alexa, other.Alexa);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((UrlInfoResult)obj);
		}

		public override int GetHashCode()
		{
			return (Alexa != null ? Alexa.GetHashCode() : 0);
		}

		public UrlInfoAlexa Alexa { get; set; }
	}

	[DeserializeAs(Name = "Alexa")]
	public class UrlInfoAlexa : IEquatable<UrlInfoAlexa>
	{
		public bool Equals(UrlInfoAlexa other)
		{
			return Equals(ContactInfo, other.ContactInfo) &&
                Equals(ContentData, other.ContentData) && 
                Equals(Related, other.Related) && 
                Equals(TrafficData, other.TrafficData);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((UrlInfoAlexa)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (ContactInfo != null ? ContactInfo.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContentData != null ? ContentData.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Related != null ? Related.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TrafficData != null ? TrafficData.GetHashCode() : 0);
				return hashCode;
			}
		}

		public ContactInfo ContactInfo { get; set; }
		public ContentData ContentData { get; set; }
		public Related Related { get; set; }
		public TrafficData TrafficData { get; set; }
	}

	#region ContactInfo classes block

	public class ContactInfo : IEquatable<ContactInfo>
	{
		public bool Equals(ContactInfo other)
		{
			return string.Equals(DataUrl, other.DataUrl) &&
                PhoneNumbers.ListsAreEqual(other.PhoneNumbers) &&
                string.Equals(OwnerName, other.OwnerName) &&
                string.Equals(Email, other.Email) &&
                Equals(PhysicalAddress, other.PhysicalAddress) &&
                Equals(CompanyStockTicker, other.CompanyStockTicker);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ContactInfo)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (PhoneNumbers != null ? PhoneNumbers.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (OwnerName != null ? OwnerName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Email != null ? Email.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (PhysicalAddress != null ? PhysicalAddress.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (CompanyStockTicker != null ? CompanyStockTicker.GetHashCode() : 0);
				return hashCode;
			}
		}

		public string DataUrl { get; set; }
		public List<PhoneNumber> PhoneNumbers { get; set; }
		public string OwnerName { get; set; }
		public string Email { get; set; }
		public PhysicalAddress PhysicalAddress { get; set; }
		public CompanyStockTicker CompanyStockTicker { get; set; }
	}

	public class PhoneNumber : IEquatable<PhoneNumber>
	{
		public bool Equals(PhoneNumber other)
		{
			return string.Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((PhoneNumber)obj);
		}

		public override int GetHashCode()
		{
			return (Value != null ? Value.GetHashCode() : 0);
		}

		public string Value { get; set; }
	}

	public class PhysicalAddress : IEquatable<PhysicalAddress>
	{
		public bool Equals(PhysicalAddress other)
		{
			return Streets.ListsAreEqual(other.Streets) &&
                string.Equals(City, other.City) &&
                string.Equals(State, other.State) &&
                string.Equals(PostalCode, other.PostalCode) &&
                string.Equals(Country, other.Country);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((PhysicalAddress)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Streets != null ? Streets.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (City != null ? City.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (State != null ? State.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (PostalCode != null ? PostalCode.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Country != null ? Country.GetHashCode() : 0);
				return hashCode;
			}
		}

		public List<Street> Streets { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string PostalCode { get; set; }
		public string Country { get; set; }
	}

	public class Street : IEquatable<Street>
	{
		public bool Equals(Street other)
		{
			return string.Equals(Value, other.Value);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Street)obj);
		}

		public override int GetHashCode()
		{
			return (Value != null ? Value.GetHashCode() : 0);
		}

		public string Value { get; set; }
	}

	public class CompanyStockTicker : IEquatable<CompanyStockTicker>
	{
		public bool Equals(CompanyStockTicker other)
		{
			return string.Equals(Symbol, other.Symbol);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CompanyStockTicker)obj);
		}

		public override int GetHashCode()
		{
			return (Symbol != null ? Symbol.GetHashCode() : 0);
		}

		public string Symbol { get; set; }
	}

	#endregion ContactInfo classes block

	#region ContentData classes block

	public class ContentData : IEquatable<ContentData>
	{
		public bool Equals(ContentData other)
		{
			return string.Equals(DataUrl, other.DataUrl) &&
                string.Equals(Asin, other.Asin) &&
                Equals(SiteData, other.SiteData) &&
                Equals(Speed, other.Speed) && 
                string.Equals(AdultContent, other.AdultContent) && 
                Equals(Language, other.Language) &&
                LinksInCount == other.LinksInCount &&
                OwnedDomains.ListsAreEqual(other.OwnedDomains);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ContentData)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Asin != null ? Asin.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (SiteData != null ? SiteData.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Speed != null ? Speed.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (AdultContent != null ? AdultContent.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Language != null ? Language.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ LinksInCount;
				hashCode = (hashCode * 397) ^ (OwnedDomains != null ? OwnedDomains.GetHashCode() : 0);
				return hashCode;
			}
		}

		public class OwnedDomain : IEquatable<OwnedDomain>
		{
			public bool Equals(OwnedDomain other)
			{
				return string.Equals(Domain, other.Domain) &&
                    string.Equals(Title, other.Title);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((OwnedDomain)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return ((Domain != null ? Domain.GetHashCode() : 0) * 397) ^
                        (Title != null ? Title.GetHashCode() : 0);
				}
			}

			public string Domain { get; set; }
			public string Title { get; set; }
		}

		public string DataUrl { get; set; }
		public string Asin { get; set; }
		public SiteData SiteData { get; set; }
		public Speed Speed { get; set; }
		public string AdultContent { get; set; }
		public Language Language { get; set; }

		public int LinksInCount { get; set; }

		public List<OwnedDomain> OwnedDomains { get; set; }
	}

	public class SiteData : IEquatable<SiteData>
	{
		public bool Equals(SiteData other)
		{
			return string.Equals(Title, other.Title) &&
                string.Equals(Description, other.Description) &&
                OnlineSince.Equals(other.OnlineSince);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SiteData)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Title != null ? Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ OnlineSince.GetHashCode();
				return hashCode;
			}
		}

		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime OnlineSince { get; set; }
	}
	public class Speed : IEquatable<Speed>
	{
		public bool Equals(Speed other)
		{
			return MedianLoadTime == other.MedianLoadTime &&
                Percentile == other.Percentile;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Speed)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (MedianLoadTime * 397) ^ Percentile;
			}
		}

		public int MedianLoadTime { get; set; }
		public int Percentile { get; set; }
	}
	public class Language : IEquatable<Language>
	{
		public bool Equals(Language other)
		{
			return string.Equals(Locale, other.Locale);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Language)obj);
		}

		public override int GetHashCode()
		{
			return (Locale != null ? Locale.GetHashCode() : 0);
		}

		public string Locale { get; set; }
	}

	#endregion ContentData classes block

	#region Related classes block

	public class Related : IEquatable<Related>
	{
		public bool Equals(Related other)
		{
			return string.Equals(DataUrl, other.DataUrl) && 
                string.Equals(Asin, other.Asin) && 
                RelatedLinks.ListsAreEqual(other.RelatedLinks) &&
                Categories.ListsAreEqual(other.Categories);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Related)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Asin != null ? Asin.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (RelatedLinks != null ? RelatedLinks.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Categories != null ? Categories.GetHashCode() : 0);
				return hashCode;
			}
		}

		public class RelatedLink : IEquatable<RelatedLink>
		{
			public bool Equals(RelatedLink other)
			{
				return string.Equals(DataUrl, other.DataUrl) &&
                    string.Equals(NavigableUrl, other.NavigableUrl) &&
                    string.Equals(Asin, other.Asin) && 
                    Relevance == other.Relevance && 
                    string.Equals(Title, other.Title);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((RelatedLink)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (NavigableUrl != null ? NavigableUrl.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (Asin != null ? Asin.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ Relevance;
					hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
					return hashCode;
				}
			}

			public string DataUrl { get; set; }
			public string NavigableUrl { get; set; }
			public string Asin { get; set; }
			public int Relevance { get; set; }
			public string Title { get; set; }
		}

		public class CategoryData : IEquatable<CategoryData>
		{
			public bool Equals(CategoryData other)
			{
				return string.Equals(Title, other.Title) &&
                    string.Equals(AbsolutePath, other.AbsolutePath);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((CategoryData)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return ((Title != null ? Title.GetHashCode() : 0) * 397) ^
                        (AbsolutePath != null ? AbsolutePath.GetHashCode() : 0);
				}
			}

			public string Title { get; set; }
			public string AbsolutePath { get; set; }
		}

		public string DataUrl { get; set; }
		public string Asin { get; set; }
		public List<RelatedLink> RelatedLinks { get; set; }
		public List<CategoryData> Categories { get; set; }
	}

	#endregion Related classes block

	#region TrafficData classes block

	public class TrafficData : IEquatable<TrafficData>
	{
		public bool Equals(TrafficData other)
		{
			return string.Equals(DataUrl, other.DataUrl) &&
                string.Equals(Asin, other.Asin) && 
                Rank == other.Rank && 
                Equals(RankByCountry, other.RankByCountry) && 
                UsageStatistics.ListsAreEqual(other.UsageStatistics) && 
                ContributingSubdomains.ListsAreEqual(other.ContributingSubdomains);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TrafficData)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Asin != null ? Asin.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Rank;
				hashCode = (hashCode * 397) ^ (RankByCountry != null ? RankByCountry.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (UsageStatistics != null ? UsageStatistics.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (ContributingSubdomains != null ? ContributingSubdomains.GetHashCode() : 0);
				return hashCode;
			}
		}

		public class Reach : IEquatable<Reach>
		{
			public bool Equals(Reach other)
			{
				return Equals(Rank, other.Rank) && Equals(PerMillion, other.PerMillion);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((Reach)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					return ((Rank != null ? Rank.GetHashCode() : 0) * 397) ^ (PerMillion != null ? PerMillion.GetHashCode() : 0);
				}
			}

			public Rank Rank { get; set; }
			public Rank PerMillion { get; set; }
		}

		public class PageViews : IEquatable<PageViews>
		{
			public bool Equals(PageViews other)
			{
				return Equals(PerMillion, other.PerMillion) &&
                    Equals(Rank, other.Rank) &&
                    Equals(PerUser, other.PerUser);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((PageViews)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					var hashCode = (PerMillion != null ? PerMillion.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (Rank != null ? Rank.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (PerUser != null ? PerUser.GetHashCode() : 0);
					return hashCode;
				}
			}

			public Rank PerMillion { get; set; }
			public Rank Rank { get; set; }
			public Rank PerUser { get; set; }
		}

		public class UsageStatistic : IEquatable<UsageStatistic>
		{
			public bool Equals(UsageStatistic other)
			{
				return Equals(TimeRange, other.TimeRange) &&
                    Equals(Rank, other.Rank) &&
                    Equals(Reach, other.Reach) &&
                    Equals(PageViews, other.PageViews);
			}

			public override bool Equals(object obj)
			{
				if (ReferenceEquals(null, obj)) return false;
				if (ReferenceEquals(this, obj)) return true;
				if (obj.GetType() != this.GetType()) return false;
				return Equals((UsageStatistic)obj);
			}

			public override int GetHashCode()
			{
				unchecked
				{
					var hashCode = (TimeRange != null ? TimeRange.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (Rank != null ? Rank.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (Reach != null ? Reach.GetHashCode() : 0);
					hashCode = (hashCode * 397) ^ (PageViews != null ? PageViews.GetHashCode() : 0);
					return hashCode;
				}
			}

			public TimeRange TimeRange { get; set; }
			public Rank Rank { get; set; }
			public Reach Reach { get; set; }
			public PageViews PageViews { get; set; }
		}

		public string DataUrl { get; set; }
		public string Asin { get; set; }
		public int Rank { get; set; }
		public RankByCountry RankByCountry { get; set; }
		public List<UsageStatistic> UsageStatistics { get; set; }
		public List<ContributingSubdomain> ContributingSubdomains { get; set; }
	}

	public class TimeRange : IEquatable<TimeRange>
	{
		public bool Equals(TimeRange other)
		{
			return Days == other.Days && Months == other.Months;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TimeRange)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Days.GetHashCode() * 397) ^ Months.GetHashCode();
			}
		}

		public int? Days { get; set; }
		public int? Months { get; set; }
	}


	public class Rank : IEquatable<Rank>
	{
		public bool Equals(Rank other)
		{
			return Value.Equals(other.Value) && string.Equals(Delta, other.Delta);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Rank)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Value.GetHashCode() * 397) ^ (Delta != null ? Delta.GetHashCode() : 0);
			}
		}

		public double Value { get; set; }
		public string Delta { get; set; }
	}

	public class RankByCountry : IEquatable<RankByCountry>
	{
		public bool Equals(RankByCountry other)
		{
			return Countries.ListsAreEqual( other.Countries);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((RankByCountry)obj);
		}

		public override int GetHashCode()
		{
			return (Countries != null ? Countries.GetHashCode() : 0);
		}

		public List<Country> Countries { get; set; }
	}

	public class Country : IEquatable<Country>
	{
		public bool Equals(Country other)
		{
			return string.Equals(Code, other.Code) && 
                Rank == other.Rank 
                && Equals(Contribution, other.Contribution);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Country)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Code != null ? Code.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Rank;
				hashCode = (hashCode * 397) ^ (Contribution != null ? Contribution.GetHashCode() : 0);
				return hashCode;
			}
		}

		public string Code { get; set; }
		public int Rank { get; set; }
		public Contribution Contribution { get; set; }
	}

	public class Contribution : IEquatable<Contribution>
	{
		public bool Equals(Contribution other)
		{
			return string.Equals(PageViews, other.PageViews) && string.Equals(Users, other.Users);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Contribution)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((PageViews != null ? PageViews.GetHashCode() : 0) * 397) ^ (Users != null ? Users.GetHashCode() : 0);
			}
		}

		public string PageViews { get; set; }
		public string Users { get; set; }
	}

	public class ContributingSubdomain : IEquatable<ContributingSubdomain>
	{
		public bool Equals(ContributingSubdomain other)
		{
			return string.Equals(DataUrl, other.DataUrl) &&
                Equals(TimeRange, other.TimeRange) &&
                Equals(Reach, other.Reach) &&
                Equals(PageViews, other.PageViews);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ContributingSubdomain)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (TimeRange != null ? TimeRange.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Reach != null ? Reach.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (PageViews != null ? PageViews.GetHashCode() : 0);
				return hashCode;
			}
		}

		public string DataUrl { get; set; }
		public TimeRange TimeRange { get; set; }
		public ReachForSubdomain Reach { get; set; }
		public PageViewsForSubdomain PageViews { get; set; }
	}

	public class ReachForSubdomain : IEquatable<ReachForSubdomain>
	{
		public bool Equals(ReachForSubdomain other)
		{
			return string.Equals(Percentage, other.Percentage);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ReachForSubdomain)obj);
		}

		public override int GetHashCode()
		{
			return (Percentage != null ? Percentage.GetHashCode() : 0);
		}

		public string Percentage { get; set; }
	}

	public class PageViewsForSubdomain : IEquatable<PageViewsForSubdomain>
	{
		public bool Equals(PageViewsForSubdomain other)
		{
			return string.Equals(Percentage, other.Percentage) && string.Equals(PerUser, other.PerUser);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((PageViewsForSubdomain)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Percentage != null ? Percentage.GetHashCode() : 0) * 397) ^
                    (PerUser != null ? PerUser.GetHashCode() : 0);
			}
		}

		public string Percentage { get; set; }
		public string PerUser { get; set; }
	}

	#endregion TrafficData classes block
}
