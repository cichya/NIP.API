using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Repositories
{
	public interface IQueryRepository
	{
		Task<QueryModel> Add(QueryModel query);

		Task<bool> SaveAll();
	}
}
