using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NIP.API.Controllers;
using NIP.API.Helpers;
using NIP.API.Models;
using NIP.API.Repositories;
using NIP.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NIP.API.Tests
{
	[TestClass]
	public class CompanyControllerTests
	{
		private Mock<ICompanyRepository> companyRepositoryMock;
		private Mock<IQueryRepository> queryRepositoryMock;
		private Mock<IHeaderRepository> headerRepositoryMock;
		private Mock<IHeaderService> headerServiceMock;
		private Mock<IQueryService> queryServiceMock;

		[TestMethod]
		public async Task GetCompany_QueryRepository_SaveAll_False_Return_500_Test()
		{
			this.queryRepositoryMock.Setup(m => m.SaveAll()).Returns(Task.FromResult(false));

			var target = new CompanyController(this.companyRepositoryMock.Object,
				this.queryRepositoryMock.Object,
				this.headerRepositoryMock.Object,
				this.headerServiceMock.Object,
				this.queryServiceMock.Object);

			target.ControllerContext = new ControllerContext();
			target.ControllerContext.HttpContext = new DefaultHttpContext();
			target.ControllerContext.HttpContext.Request.Headers["header1"] = "value1";

			var result = await target.GetCompany(new FilterParams());

			var statusCode = result as StatusCodeResult;

			Assert.AreEqual(500, statusCode.StatusCode);

			this.queryServiceMock.Verify(m => m.GetQueryModelFromFilterParams(It.IsAny<FilterParams>()), Times.Once);
			this.headerServiceMock.Verify(m => m.GetHeaderEntityFromRequestHeaders(It.IsAny<IHeaderDictionary>()), Times.Once); 
			this.headerRepositoryMock.Verify(m => m.Add(It.IsAny<HeaderModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.Add(It.IsAny<QueryModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.SaveAll(), Times.Once);
		}

		[TestMethod]
		public async Task GetCompany_CompanyRepository_Get_Return_Null_Return_NoContent_Test()
		{
			CompanyModel companyModel = null;

			this.companyRepositoryMock.Setup(m => m.Get(It.IsAny<FilterParams>())).Returns(Task.FromResult(companyModel));

			var target = new CompanyController(this.companyRepositoryMock.Object,
				this.queryRepositoryMock.Object,
				this.headerRepositoryMock.Object,
				this.headerServiceMock.Object,
				this.queryServiceMock.Object);

			target.ControllerContext = new ControllerContext();
			target.ControllerContext.HttpContext = new DefaultHttpContext();
			target.ControllerContext.HttpContext.Request.Headers["header1"] = "value1";

			var result = await target.GetCompany(new FilterParams());

			var notFoundResult = result as NotFoundResult;

			Assert.IsNotNull(notFoundResult);

			this.queryServiceMock.Verify(m => m.GetQueryModelFromFilterParams(It.IsAny<FilterParams>()), Times.Once);
			this.headerServiceMock.Verify(m => m.GetHeaderEntityFromRequestHeaders(It.IsAny<IHeaderDictionary>()), Times.Once);
			this.headerRepositoryMock.Verify(m => m.Add(It.IsAny<HeaderModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.Add(It.IsAny<QueryModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.SaveAll(), Times.Once);
			this.companyRepositoryMock.Verify(m => m.Get(It.IsAny<FilterParams>()), Times.Once);
		}

		[TestMethod]
		public async Task GetCompany_CompanyRepository_Get_Return_Company_Return_Ok_Test()
		{
			CompanyModel companyModel = new CompanyModel
			{
				Id = 1
			};

			this.companyRepositoryMock.Setup(m => m.Get(It.IsAny<FilterParams>())).Returns(Task.FromResult(companyModel));

			var target = new CompanyController(this.companyRepositoryMock.Object,
				this.queryRepositoryMock.Object,
				this.headerRepositoryMock.Object,
				this.headerServiceMock.Object,
				this.queryServiceMock.Object);

			target.ControllerContext = new ControllerContext();
			target.ControllerContext.HttpContext = new DefaultHttpContext();
			target.ControllerContext.HttpContext.Request.Headers["header1"] = "value1";

			var result = await target.GetCompany(new FilterParams());

			var okObjectResult = result as OkObjectResult;

			Assert.IsNotNull(okObjectResult);

			var company = okObjectResult.Value as CompanyModel;

			Assert.IsNotNull(company);
			Assert.AreEqual(1, company.Id);

			this.queryServiceMock.Verify(m => m.GetQueryModelFromFilterParams(It.IsAny<FilterParams>()), Times.Once);
			this.headerServiceMock.Verify(m => m.GetHeaderEntityFromRequestHeaders(It.IsAny<IHeaderDictionary>()), Times.Once);
			this.headerRepositoryMock.Verify(m => m.Add(It.IsAny<HeaderModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.Add(It.IsAny<QueryModel>()), Times.Once);
			this.queryRepositoryMock.Verify(m => m.SaveAll(), Times.Once);
			this.companyRepositoryMock.Verify(m => m.Get(It.IsAny<FilterParams>()), Times.Once);
		}

		[TestInitialize]
		public void Init()
		{
			this.queryServiceMock = new Mock<IQueryService>();

			this.queryServiceMock.Setup(m => m.GetQueryModelFromFilterParams(It.IsAny<FilterParams>())).Returns(new QueryModel {});

			this.headerServiceMock = new Mock<IHeaderService>();

			this.headerServiceMock.Setup(m => m.GetHeaderEntityFromRequestHeaders(It.IsAny<IHeaderDictionary>())).Returns(new List<HeaderModel>
			{
				new HeaderModel()
			});

			this.headerRepositoryMock = new Mock<IHeaderRepository>();

			this.headerRepositoryMock.Setup(m => m.Add(It.IsAny<HeaderModel>())).Returns(Task.FromResult(new HeaderModel()));

			this.queryRepositoryMock = new Mock<IQueryRepository>();

			this.queryRepositoryMock.Setup(m => m.Add(It.IsAny<QueryModel>())).Returns(Task.FromResult(new QueryModel()));

			this.queryRepositoryMock.Setup(m => m.SaveAll()).Returns(Task.FromResult(true));

			this.companyRepositoryMock = new Mock<ICompanyRepository>();
		}
	}
}
