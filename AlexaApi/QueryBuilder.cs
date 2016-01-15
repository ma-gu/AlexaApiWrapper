using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AlexaApi
{
    internal class QueryBuilder
	{
		private RestRequest _request;

		private Dictionary<string, object> _paramDict = new Dictionary<string, object>();

		public QueryBuilder(RestRequest request)
		{
			_request = request;
		}

		public void AddParameter(string name, object value)
		{
			if (value != null)
			{
				_request.AddParameter(name, value);
				_paramDict.Add(name, value);
			}
		}

		public string Query
		{
			get 
			{
				var queryString = new StringBuilder();
				var sorted = _paramDict.OrderBy(p => p.Key, StringComparer.Ordinal).ToArray();
				foreach (var v in sorted)
				{
					if (queryString.Length > 0)
						queryString.Append("&");

					queryString.AppendFormat("{0}={1}", v.Key, v.Value.ToString().UpperCaseUrlEncode());
				}
				return queryString.ToString(); 
			}
		}
	}

	internal static class StringHelper
	{
		public static string UpperCaseUrlEncode(this string s)
		{
			
			char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
			for (int i = 0; i < temp.Length - 2; i++)
			{
				if (temp[i] == '%')
				{
					temp[i + 1] = char.ToUpper(temp[i + 1]);
					temp[i + 2] = char.ToUpper(temp[i + 2]);
				}
			}
			return new string(temp);
		}
	}
}
