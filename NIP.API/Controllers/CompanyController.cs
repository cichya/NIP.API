using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIP.API.Helpers;
using NIP.API.Models;

namespace NIP.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CompanyController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetCompany([FromQuery] FilterParams filterParams)
		{
			var mock = new CompanyModel
			{
				Id = 1,
				City = "Poznan",
				Name = "JanuszSoft",
				NationalBusinessRegistryNumber = "123456789",
				NationalCourtRegister = "0000123456",
				TaxNumber = "0987654321",
				PostalCode = "11-098",
				Street = "Poznanska",
				StreetNumber = "1"
			};

			return this.Ok(mock);
		}
	}
}