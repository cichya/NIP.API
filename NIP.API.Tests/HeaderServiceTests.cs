using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIP.API.Controllers;
using NIP.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NIP.API.Tests
{
	[TestClass]
	public class HeaderServiceTests
	{
		[TestMethod]
		public void GetHeaderEntityFromRequestHeaders_Test()
		{
			var ctrl = new CompanyController(null, null, null, null, null);
			ctrl.ControllerContext = new ControllerContext();
			ctrl.ControllerContext.HttpContext = new DefaultHttpContext();
			ctrl.ControllerContext.HttpContext.Request.Headers["header1"] = "value1";
			ctrl.ControllerContext.HttpContext.Request.Headers["header2"] = "value2";

			var target = new HeaderService();

			IEnumerable<Models.HeaderModel> result = target.GetHeaderEntityFromRequestHeaders(ctrl.ControllerContext.HttpContext.Request.Headers);

			Assert.IsNotNull(result);
			Assert.AreEqual(2, result.Count());

			Assert.IsNotNull(result.FirstOrDefault(x => x.HeaderName == "header1" && x.HeaderValue == "value1"));
			Assert.IsNotNull(result.FirstOrDefault(x => x.HeaderName == "header2" && x.HeaderValue == "value2"));
		}
	}
}
