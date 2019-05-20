using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Models
{
	public class QueryModel
	{
		public int Id { get; set; }
		public DateTime InsertDate { get; set; }
		public string QueryParamName { get; set; }
		public string QueryParamValue { get; set; }
	}
}
