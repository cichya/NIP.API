using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIP.API.Helpers;
using NIP.API.Models;
using NIP.API.Repositories;

namespace NIP.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyRepository companyRepository;

		public CompanyController(ICompanyRepository companyRepository)
		{
			this.companyRepository = companyRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetCompany([FromQuery] FilterParams filterParams)
		{
			var company = await this.companyRepository.Get(filterParams);

			if (company == null)
			{
				return this.NotFound();
			}

			return this.Ok(company);
		}
	}
}