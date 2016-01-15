using System;
using System.Collections.Generic;

namespace AlexaApi.ResponseModel
{
    public class OperationRequest
	{
		public string RequestId { get; set; }
	}

	public class ResponseStatus : IEquatable<ResponseStatus>
	{
		public bool Equals(ResponseStatus other)
		{
			return string.Equals(StatusCode, other.StatusCode);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((ResponseStatus)obj);
		}

		public override int GetHashCode()
		{
			return (StatusCode != null ? StatusCode.GetHashCode() : 0);
		}

		public string StatusCode { get; set; }
	}

	internal static class ListHelper
	{
		public static bool ListsAreEqual<T>(this List<T> obj, List<T> comp)
		{
			if (obj.Count != comp.Count) return false;
			foreach(var item in obj)
			{
				if (!comp.Contains(item))
					return false;
			}
			return true;
		}
	}
}
