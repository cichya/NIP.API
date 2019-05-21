using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NIP.API.Data;
using NIP.API.Helpers;
using NIP.API.Models;

namespace NIP.API.Repositories
{
	public class CompanyRepository : ICompanyRepository
	{
		private readonly DataContext dataContext;

		public CompanyRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public async Task<CompanyModel> Get(FilterParams filter)
		{
			if (filter.Nip != null)
			{
				return await this.dataContext.companies.FirstOrDefaultAsync(x => x.TaxNumber == filter.Nip);
			}
			
			if (filter.Regon != null)
			{
				return await this.dataContext.companies.FirstOrDefaultAsync(x => x.NationalBusinessRegistryNumber == filter.Regon);
			}

			return await this.dataContext.companies.FirstOrDefaultAsync(x => x.NationalCourtRegister == filter.Krs);
		}

		public async Task<bool> SaveAll()
		{
			return await this.dataContext.SaveChangesAsync() > 0;
		}
	}
}
