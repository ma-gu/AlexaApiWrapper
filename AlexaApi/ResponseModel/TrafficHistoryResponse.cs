using RestSharp.Deserializers;
using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    [DeserializeAs(Name = "Response")]
	public class TrafficHistoryResponse : IEquatable<TrafficHistoryResponse>
	{
		public bool Equals(TrafficHistoryResponse other)
		{
			return Equals(TrafficHistoryResult, other.TrafficHistoryResult) &&
                Equals(ResponseStatus, other.ResponseStatus);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TrafficHistoryResponse)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((TrafficHistoryResult != null ? TrafficHistoryResult.GetHashCode() : 0) * 397) ^
                    (ResponseStatus != null ? ResponseStatus.GetHashCode() : 0);
			}
		}

		public OperationRequest OperationRequest { get; set; }
		public TrafficHistoryResult TrafficHistoryResult { get; set; }
		public ResponseStatus ResponseStatus { get; set; }
	}

	public class TrafficHistoryResult : IEquatable<TrafficHistoryResult>
	{
		public bool Equals(TrafficHistoryResult other)
		{
			return Equals(Alexa, other.Alexa);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TrafficHistoryResult)obj);
		}

		public override int GetHashCode()
		{
			return (Alexa != null ? Alexa.GetHashCode() : 0);
		}

		public TrafficHistoryAlexa Alexa { get; set; }
	}

	[DeserializeAs(Name = "Alexa")]
	public class TrafficHistoryAlexa : IEquatable<TrafficHistoryAlexa>
	{
		public bool Equals(TrafficHistoryAlexa other)
		{
			return Equals(TrafficHistory, other.TrafficHistory);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TrafficHistoryAlexa)obj);
		}

		public override int GetHashCode()
		{
			return (TrafficHistory != null ? TrafficHistory.GetHashCode() : 0);
		}

		public TrafficHistory TrafficHistory { get; set; }
	}

	public class TrafficHistory : IEquatable<TrafficHistory>
	{
		public bool Equals(TrafficHistory other)
		{
			return Range == other.Range && string.Equals(Site, other.Site);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((TrafficHistory)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Range * 397) ^ (Site != null ? Site.GetHashCode() : 0);
			}
		}

		public int Range { get; set; }
		public string Site { get; set; }
		public DateTime Start { get; set; }
		public HistoricalData HistoricalData { get; set; }
	}

	public class HistoricalData : IEquatable<HistoricalData>
	{
		public bool Equals(HistoricalData other)
		{
			return Datas.ListsAreEqual(other.Datas);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((HistoricalData)obj);
		}

		public override int GetHashCode()
		{
			return (Datas != null ? Datas.GetHashCode() : 0);
		}

		public List<Data> Datas { get; set; }
	}

	public class Data : IEquatable<Data>
	{
		public bool Equals(Data other)
		{
			return Date.Equals(other.Date) && Equals(PageViews, other.PageViews) && Rank == other.Rank && Equals(Reach, other.Reach);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Data)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Date.GetHashCode();
				hashCode = (hashCode * 397) ^ (PageViews != null ? PageViews.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ Rank;
				hashCode = (hashCode * 397) ^ (Reach != null ? Reach.GetHashCode() : 0);
				return hashCode;
			}
		}

		public DateTime Date { get; set; }
		public PageViews PageViews { get; set; }
		public int Rank { get; set; }
		public Reach Reach { get; set; }

	}

	public class PageViews : IEquatable<PageViews>
	{
		public bool Equals(PageViews other)
		{
			return PerMillion == other.PerMillion && PerUser.Equals(other.PerUser);
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
				return (PerMillion * 397) ^ PerUser.GetHashCode();
			}
		}

		public int PerMillion { get; set; }
		public double PerUser { get; set; }
	}

	public class Reach : IEquatable<Reach>
	{
		public bool Equals(Reach other)
		{
			return PerMillion == other.PerMillion;
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
			return PerMillion;
		}

		public int PerMillion { get; set; }
	}
}
