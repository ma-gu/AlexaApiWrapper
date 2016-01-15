using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaApi.ResponseModel
{
	[DeserializeAs(Name="Response")]
	public class AlexaError
	{
		public List<Error> Errors { get; set; }
		public RequestID RequestID { get; set; }
	}

	public class Error
	{
		public string Code { get; set; }
		public string Message { get; set; }
	}

	public class RequestID
	{
		public string Value { get; set; }
	}
}
