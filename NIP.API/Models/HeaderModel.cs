using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Models
{
	public class HeaderModel
	{
		public int Id { get; set; }
		public int QueryId { get; set; }
		public string HeaderName { get; set; }
		public string HeaderValue { get; set; }
		public QueryModel Query { get; set; }
	}
}
