using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NIP.API.Data;
using NIP.API.Models;

namespace NIP.API.Repositories
{
	public class QueryRepository : IQueryRepository
	{
		private readonly DataContext dataContext;

		public QueryRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public async Task<QueryModel> Add(QueryModel query)
		{
			await this.dataContext.AddAsync(query);

			return query;
		}

		public async Task<bool> SaveAll()
		{
			return await this.dataContext.SaveChangesAsync() > 0;
		}
	}
}
