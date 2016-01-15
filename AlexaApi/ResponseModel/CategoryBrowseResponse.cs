using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    [DeserializeAs(Name = "Response")]
	public class CategoryBrowseResponse : IEquatable<CategoryBrowseResponse>
	{
		public bool Equals(CategoryBrowseResponse other)
		{
			return Equals(CategoryBrowseResult, other.CategoryBrowseResult) &&
                Equals(ResponseStatus, other.ResponseStatus);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryBrowseResponse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((CategoryBrowseResult != null ? CategoryBrowseResult.GetHashCode() : 0) * 397) ^
                    (ResponseStatus != null ? ResponseStatus.GetHashCode() : 0);
			}
		}

		public OperationRequest OperationRequest { get; set; }
		public CategoryBrowseResult CategoryBrowseResult { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class CategoryBrowseResult : IEquatable<CategoryBrowseResult>
	{
		public bool Equals(CategoryBrowseResult other)
		{
			return Equals(Alexa, other.Alexa);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryBrowseResult)obj);
		}

		public override int GetHashCode()
		{
			return (Alexa != null ? Alexa.GetHashCode() : 0);
		}

		public CatBrowseAlexa Alexa { get; set; }
	}

	[DeserializeAs(Name = "Alexa")]
	public class CatBrowseAlexa : IEquatable<CatBrowseAlexa>
	{
		public bool Equals(CatBrowseAlexa other)
		{
			return Equals(CategoryBrowse, other.CategoryBrowse);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CatBrowseAlexa)obj);
		}

		public override int GetHashCode()
		{
			return (CategoryBrowse != null ? CategoryBrowse.GetHashCode() : 0);
		}

		public CategoryBrowse CategoryBrowse { get; set; }
	}

	public class CategoryBrowse : IEquatable<CategoryBrowse>
	{
		public bool Equals(CategoryBrowse other)
		{
			return Categories.ListsAreEqual(other.Categories) &&
                RelatedCategories.ListsAreEqual(other.RelatedCategories) &&
                LanguageCategories.ListsAreEqual(other.LanguageCategories) &&
                LetterBars.ListsAreEqual(other.LetterBars);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((CategoryBrowse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Categories != null ? Categories.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (RelatedCategories != null ? RelatedCategories.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LanguageCategories != null ? LanguageCategories.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (LetterBars != null ? LetterBars.GetHashCode() : 0);
				return hashCode;
			}
		}

		public List<Category> Categories { get; set; }
		public List<Category> RelatedCategories { get; set; }
		public List<Category> LanguageCategories { get; set; }
		public List<Category> LetterBars { get; set; }
	}

	public class Category : IEquatable<Category>
	{
		public bool Equals(Category other)
		{
			return string.Equals(Path, other.Path) &&
                string.Equals(Title, other.Title) && 
                SubCategoryCount == other.SubCategoryCount &&
                TotalListingCount == other.TotalListingCount && 
                string.Equals(Description, other.Description);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Category)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (Path != null ? Path.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ SubCategoryCount;
				hashCode = (hashCode * 397) ^ TotalListingCount;
				hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
				return hashCode;
			}
		}

		public string Path { get; set; }
		public string Title { get; set; }
		public int SubCategoryCount { get; set; }
		public int TotalListingCount { get; set; }
		public string Description { get; set; }
	}

}
