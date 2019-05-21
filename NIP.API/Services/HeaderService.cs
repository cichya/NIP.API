using Microsoft.AspNetCore.Http;
using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Services
{
	public class HeaderService : IHeaderService
	{
		public IEnumerable<HeaderModel> GetHeaderEntityFromRequestHeaders(IHeaderDictionary headers)
		{
			List<HeaderModel> result = new List<HeaderModel>();

			foreach (var header in headers)
			{
				result.Add(new HeaderModel
				{
					HeaderName = header.Key,
					HeaderValue = header.Value
				});
			}

			return result;
		}
	}
}
