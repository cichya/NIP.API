using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIP.API.Helpers;
using NIP.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace NIP.API.Tests
{
	[TestClass]
	public class QueryServiceTests
	{
		[TestMethod]
		public void GetQueryModelFromFilterParams_Krs_Not_Null_Return_Krs()
		{
			var filterParams = new FilterParams
			{
				Krs = "abc"
			};

			var target = new QueryService();

			var result = target.GetQueryModelFromFilterParams(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual("KRS", result.QueryParamName);
			Assert.AreEqual("abc", result.QueryParamValue);
		}

		[TestMethod]
		public void GetQueryModelFromFilterParams_Regon_Not_Null_Return_Regon()
		{
			var filterParams = new FilterParams
			{
				Regon = "abc"
			};

			var target = new QueryService();

			var result = target.GetQueryModelFromFilterParams(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual("REGON", result.QueryParamName);
			Assert.AreEqual("abc", result.QueryParamValue);
		}

		[TestMethod]
		public void GetQueryModelFromFilterParams_Nip_Not_Null_Return_Nip()
		{
			var filterParams = new FilterParams
			{
				Nip = "abc"
			};

			var target = new QueryService();

			var result = target.GetQueryModelFromFilterParams(filterParams);

			Assert.IsNotNull(result);
			Assert.AreEqual("NIP", result.QueryParamName);
			Assert.AreEqual("abc", result.QueryParamValue);
		}

		[TestMethod]
		public void GetQueryModelFromFilterParams_All_Properties_Null_Return_Null()
		{
			var filterParams = new FilterParams();

			var target = new QueryService();

			var result = target.GetQueryModelFromFilterParams(filterParams);

			Assert.IsNull(result);
		}
	}
}
