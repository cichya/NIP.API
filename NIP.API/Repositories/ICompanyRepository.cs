using NIP.API.Helpers;
using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Repositories
{
	public interface ICompanyRepository
	{
		Task<CompanyModel> Get(FilterParams filter);

		Task<bool> SaveAll();
	}
}
