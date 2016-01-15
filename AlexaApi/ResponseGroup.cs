using System;
using System.Linq;
using System.Text;

namespace AlexaApi
{
    [Flags]
	public enum CategoryBrowseResponseGroup 
	{
		Categories = 1,
		RelatedCategories = 1 << 1,
		LanguageCategories = 1 << 2,
		LetterBars = 1 << 3,
		All = Categories | RelatedCategories | LanguageCategories | LetterBars
	}

	[Flags]
	public enum UrlInfoResponseGroup
	{
		RelatedLinks = 1,
		Categories = 1 << 1,
		Rank = 1 << 2,
		RankByCountry = 1 << 3,
		UsageStats = 1 << 4,
		ContactInfo = 1 << 5,
		AdultContent = 1 << 6,
		Speed = 1 << 7,
		Language = 1 << 8,
		OwnedDomains = 1 << 9,
		LinksInCount = 1 << 10,
		SiteData = 1 << 11,

		Related = RelatedLinks | Categories,
		TrafficData = Rank | UsageStats,
		ContentData = SiteData | AdultContent | Speed | Language,
		
		All = RelatedLinks | Categories | Rank | RankByCountry | UsageStats | ContactInfo | AdultContent | Speed |
			Language | OwnedDomains | LinksInCount | SiteData
	}

	internal static class ResponseGroupHelper
	{
		public static string ToQuery<T>(this T group) where T : struct
		{
			var sb = new StringBuilder();
			int bit = 1;
			var castGroup = ((Enum)(object)group);
			var max = Enum.GetValues(typeof(T)).Cast<int>().Max();
			while (bit < max + 1)
			{
				var testGroup = (Enum)Enum.ToObject(group.GetType(), bit);
				if (castGroup.HasFlag(testGroup))
				{
					var name = Enum.GetName(group.GetType(), bit);
					sb.AppendFormat("{0},", name);
				}
				bit = bit << 1;
			}
			if (sb.Length > 0)
				sb.Remove(sb.Length - 1, 1);
			return sb.ToString();
		}
	}

}
