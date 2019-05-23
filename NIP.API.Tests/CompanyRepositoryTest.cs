using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIP.API.Data;
using NIP.API.Helpers;
using NIP.API.Models;
using NIP.API.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NIP.API.Tests
{
	[TestClass]
	public class CompanyRepositoryTest
	{
		private DataContext dataContext;

		[TestMethod]
		public async Task Get_Nip_Param_NotEmpty_Return_Company_With_TaxNumber_Match_Test()
		{
			string nip = "TaxNumber3";

			var filterParams = new FilterParams
			{
				Nip = nip
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual(nip, result.TaxNumber);
		}

		[TestMethod]
		public async Task Get_Regon_Param_NotEmpty_Return_Company_With_NationalBusinessRegistryNumber_Match_Test()
		{
			string regon = "REGON2222";

			var filterParams = new FilterParams
			{
				Regon = regon
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual(regon, result.NationalBusinessRegistryNumber);
		}

		[TestMethod]
		public async Task Get_Krs_Param_NotEmpty_Return_Company_With_NationalCourtRegister_Match_Test()
		{
			string krs = "Krs1111111";

			var filterParams = new FilterParams
			{
				Krs = krs
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual(krs, result.NationalCourtRegister);
		}

		[TestMethod]
		public async Task Get_Nip_Param_Not_Exists_Return_Null_Test()
		{
			string nip = "TaxNumber4";

			var filterParams = new FilterParams
			{
				Nip = nip
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNull(result);
		}

		[TestMethod]
		public async Task Get_Regon_Param_Not_Exists_Return_Null_Test()
		{
			string regon = "REGON4444";

			var filterParams = new FilterParams
			{
				Regon = regon
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNull(result);
		}

		[TestMethod]
		public async Task Get_Krs_Param_Not_Exists_Return_Null_Test()
		{
			string krs = "Krs4444444";

			var filterParams = new FilterParams
			{
				Krs = krs
			};

			var target = new CompanyRepository(this.dataContext);

			var result = await target.Get(filterParams);

			Assert.IsNull(result);
		}

		[TestInitialize]
		public void TestInit()
		{
			List<CompanyModel> companies = new List<CompanyModel>
			{
				new CompanyModel
				{
					Id = 1,
					City = "City1",
					Name = "Name1",
					Street = "Street1",
					PostalCode = "11-111",
					StreetNumber = "1",
					TaxNumber = "TaxNumber1",
					NationalBusinessRegistryNumber = "REGON1111",
					NationalCourtRegister = "Krs1111111"
				},
				new CompanyModel
				{
					Id = 2,
					City = "City2",
					Name = "Name2",
					Street = "Street2",
					PostalCode = "22-222",
					StreetNumber = "2",
					TaxNumber = "TaxNumber2",
					NationalBusinessRegistryNumber = "REGON2222",
					NationalCourtRegister = "Krs2222222"
				},
				new CompanyModel
				{
					Id = 3,
					City = "City3",
					Name = "Name3",
					Street = "Street3",
					PostalCode = "33-333",
					StreetNumber = "3",
					TaxNumber = "TaxNumber3",
					NationalBusinessRegistryNumber = "REGON3333",
					NationalCourtRegister = "Krs3333333"
				}
			};

			var options = new DbContextOptionsBuilder<DataContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
				.Options;

			this.dataContext = new DataContext(options);

			foreach (var company in companies)
			{
				dataContext.Add(company);
			}

			this.dataContext.SaveChanges();
		}

		[TestCleanup]
		public void CleanUp()
		{
			this.dataContext.Dispose();
		}
	}
}
