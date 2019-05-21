using Microsoft.AspNetCore.Http;
using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Services
{
	public interface IHeaderService
	{
		IEnumerable<HeaderModel> GetHeaderEntityFromRequestHeaders(IHeaderDictionary headers);
	}
}
