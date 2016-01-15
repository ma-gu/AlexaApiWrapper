using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    [DeserializeAs(Name = "Response")]
	public class SitesLinkingInResponse : IEquatable<SitesLinkingInResponse>
	{
		public bool Equals(SitesLinkingInResponse other)
		{
			return Equals(SitesLinkingInResult, other.SitesLinkingInResult) &&
                Equals(ResponseStatus, other.ResponseStatus);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SitesLinkingInResponse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((SitesLinkingInResult != null ? SitesLinkingInResult.GetHashCode() : 0) * 397) ^
                    (ResponseStatus != null ? ResponseStatus.GetHashCode() : 0);
			}
		}

		public OperationRequest OperationRequest { get; set; }
		public SitesLinkingInResult SitesLinkingInResult { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class SitesLinkingInResult : IEquatable<SitesLinkingInResult>
	{
		public bool Equals(SitesLinkingInResult other)
		{
			return Equals(Alexa, other.Alexa);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SitesLinkingInResult)obj);
		}

		public override int GetHashCode()
		{
			return (Alexa != null ? Alexa.GetHashCode() : 0);
		}

		public SitesAlexa Alexa { get; set; }
	}

	[DeserializeAs(Name = "Alexa")]
	public class SitesAlexa : IEquatable<SitesAlexa>
	{
		public bool Equals(SitesAlexa other)
		{
			return Equals(SitesLinkingIn, other.SitesLinkingIn);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SitesAlexa)obj);
		}

		public override int GetHashCode()
		{
			return (SitesLinkingIn != null ? SitesLinkingIn.GetHashCode() : 0);
		}

		public SitesLinkingIn SitesLinkingIn { get; set; }
	}

	public class SitesLinkingIn : IEquatable<SitesLinkingIn>
	{
		public bool Equals(SitesLinkingIn other)
		{
			return Sites.ListsAreEqual(other.Sites);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((SitesLinkingIn)obj);
		}

		public override int GetHashCode()
		{
			return (Sites != null ? Sites.GetHashCode() : 0);
		}

		public List<Site> Sites { get; set; }
	}

	public class Site : IEquatable<Site>
	{
		public bool Equals(Site other)
		{
			return string.Equals(Title, other.Title) && string.Equals(Url, other.Url);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Site)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Title != null ? Title.GetHashCode() : 0) * 397) ^
                    (Url != null ? Url.GetHashCode() : 0);
			}
		}

		public string Title { get; set; }
		public string Url { get; set; }
	}


}
