﻿using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIP.API.Data;
using NIP.API.Models;
using NIP.API.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NIP.API.Tests
{
	[TestClass]
	public class HeaderRepositoryTests
	{
		private DataContext dataContext;

		[TestMethod]
		public async Task Add_Test()
		{
			var header = new HeaderModel
			{
				HeaderName = "Header",
				HeaderValue = "Value"
			};

			var query = new QueryModel
			{
				InsertDate = DateTime.Now,
				QueryParamName = "Param",
				QueryParamValue = "Value"
			};

			query.Headers = new List<HeaderModel>();

			query.Headers.Add(header);

			header.Query = query;

			var target = new HeaderRepository(this.dataContext);

			var result = await target.Add(header);

			Assert.IsNotNull(result);
			Assert.AreNotEqual(0, result.Id);
			Assert.AreNotEqual(0, result.Query.Id);
		}

		[TestInitialize]
		public void Init()
		{
			var options = new DbContextOptionsBuilder<DataContext>()
				.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
				.Options;

			this.dataContext = new DataContext(options);
		}

		[TestCleanup]
		public void Clean()
		{
			this.dataContext.Dispose();
		}
	}
}
