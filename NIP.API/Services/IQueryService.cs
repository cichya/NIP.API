using NIP.API.Helpers;
using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Services
{
	public interface IQueryService
	{
		QueryModel GetQueryModelFromFilterParams(FilterParams filterParams);
	}
}
