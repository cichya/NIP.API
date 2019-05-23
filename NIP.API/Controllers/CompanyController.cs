using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIP.API.Helpers;
using NIP.API.Models;
using NIP.API.Repositories;
using NIP.API.Services;

namespace NIP.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyRepository companyRepository;
		private readonly IQueryRepository queryRepository;
		private readonly IHeaderRepository headerRepository;
		private readonly IHeaderService headerService;
		private readonly IQueryService queryService;

		public CompanyController(ICompanyRepository companyRepository,
			IQueryRepository queryRepository,
			IHeaderRepository headerRepository,
			IHeaderService headerService,
			IQueryService queryService)
		{
			this.companyRepository = companyRepository;
			this.queryRepository = queryRepository;
			this.headerRepository = headerRepository;
			this.headerService = headerService;
			this.queryService = queryService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCompany([FromQuery] FilterParams filterParams)
		{
			var query = this.queryService.GetQueryModelFromFilterParams(filterParams);

			if (query == null)
			{
				return this.NotFound();
			}

			query.Headers = new List<HeaderModel>();
			
			var headers = this.headerService.GetHeaderEntityFromRequestHeaders(this.Request.Headers);

			foreach (var header in headers)
			{				
				query.Headers.Add(header);
				header.Query = query;

				await this.headerRepository.Add(header);
			}

			await this.queryRepository.Add(query);

			if (!await this.queryRepository.SaveAll())
			{
				return this.StatusCode(500);
			}

			var company = await this.companyRepository.Get(filterParams);

			if (company == null)
			{
				return this.NotFound();
			}

			return this.Ok(company);
		}
	}
}