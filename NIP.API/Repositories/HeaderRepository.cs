using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NIP.API.Data;
using NIP.API.Models;

namespace NIP.API.Repositories
{
	public class HeaderRepository : IHeaderRepository
	{
		private readonly DataContext dataContext;

		public HeaderRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public async Task<HeaderModel> Add(HeaderModel header)
		{
			await this.dataContext.AddAsync(header);

			return header;
		}

		public async Task<bool> SaveAll()
		{
			return await this.dataContext.SaveChangesAsync() > 0;
		}
	}
}
