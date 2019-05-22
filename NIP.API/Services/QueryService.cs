using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NIP.API.Helpers;
using NIP.API.Models;

namespace NIP.API.Services
{
	public class QueryService : IQueryService
	{
		private const string KrsParam = "KRS";
		private const string NipParam = "NIP";
		private const string RegonParam = "REGON";

		public QueryModel GetQueryModelFromFilterParams(FilterParams filterParams)
		{
			var result = new QueryModel();

			if (filterParams.Krs != null)
			{
				return new QueryModel
				{
					QueryParamName = KrsParam,
					QueryParamValue = filterParams.Krs,
					InsertDate = DateTime.Now
				};
			}

			if (filterParams.Nip != null)
			{
				return new QueryModel
				{
					QueryParamName = NipParam,
					QueryParamValue = filterParams.Nip,
					InsertDate = DateTime.Now
				};
			}

			return new QueryModel
			{
				QueryParamName = RegonParam,
				QueryParamValue = filterParams.Regon,
				InsertDate = DateTime.Now
			};
		}
	}
}
