using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Repositories
{
	public interface IHeaderRepository
	{
		Task<HeaderModel> Add(HeaderModel header);

		Task<bool> SaveAll();
	}
}
