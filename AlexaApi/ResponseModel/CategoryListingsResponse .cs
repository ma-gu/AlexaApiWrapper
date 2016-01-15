using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    [DeserializeAs(Name = "Response")]
	public class CategoryListingsResponse : IEquatable<CategoryListingsResponse>
	{
		public bool Equals(CategoryListingsResponse other)
		{
			return Equals(CategoryListingsResult, other.CategoryListingsResult) &&
                Equals(ResponseStatus, other.ResponseStatus);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryListingsResponse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((CategoryListingsResult != null ? CategoryListingsResult.GetHashCode() : 0) * 397) ^
                    (ResponseStatus != null ? ResponseStatus.GetHashCode() : 0);
			}
		}

		public OperationRequest OperationRequest { get; set; }
		public CategoryListingsResult CategoryListingsResult { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class CategoryListingsResult : IEquatable<CategoryListingsResult>
	{
		public bool Equals(CategoryListingsResult other)
		{
			return Equals(Alexa, other.Alexa);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryListingsResult)obj);
		}

		public override int GetHashCode()
		{
			return (Alexa != null ? Alexa.GetHashCode() : 0);
		}

		public CatListingAlexa Alexa { get; set; }
	}

	[DeserializeAs(Name = "Alexa")]
	public class CatListingAlexa : IEquatable<CatListingAlexa>
	{
		public bool Equals(CatListingAlexa other)
		{
			return Equals(CategoryListings, other.CategoryListings);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CatListingAlexa)obj);
		}

		public override int GetHashCode()
		{
			return (CategoryListings != null ? CategoryListings.GetHashCode() : 0);
		}

		public CategoryListings CategoryListings { get; set; }
	}

	public class CategoryListings : IEquatable<CategoryListings>
	{
		public bool Equals(CategoryListings other)
		{
			return RecursiveCount == other.RecursiveCount &&
                Count == other.Count && 
                Listings.ListsAreEqual(other.Listings);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryListings)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = RecursiveCount;
				hashCode = (hashCode * 397) ^ Count;
				hashCode = (hashCode * 397) ^ (Listings != null ? Listings.GetHashCode() : 0);
				return hashCode;
			}
		}

		public int RecursiveCount { get; set; }
		public int Count { get; set; }
		public List<Listing> Listings { get; set; }
	}

	public class Listing : IEquatable<Listing>
	{
		public bool Equals(Listing other)
		{
			return string.Equals(DataUrl, other.DataUrl) &&
                string.Equals(Title, other.Title) && 
                PopularityRank == other.PopularityRank && 
                AverageReview.Equals(other.AverageReview) &&
                string.Equals(Description, other.Description);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Listing)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (DataUrl != null ? DataUrl.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ PopularityRank;
				hashCode = (hashCode * 397) ^ AverageReview.GetHashCode();
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				return hashCode;
			}
		}

		public string DataUrl { get; set; }
		public string Title { get; set; }
		public int PopularityRank { get; set; }
		public double AverageReview { get; set; }
		public string Description { get; set; }
	}
}
