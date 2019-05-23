using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Helpers
{
	public class RequiredFromQueryParam : Attribute, IActionConstraint
	{
		public readonly string[] expectedParams = { "nip", "krs", "regon" };

		public int Order => 0;

		public bool Accept(ActionConstraintContext context)
		{
			if (context.RouteContext.HttpContext.Request.Query.Count == 0 ||
				context.RouteContext.HttpContext.Request.Query.Count > 1)
			{
				return false;
			}

			string param = context.RouteContext.HttpContext.Request.Query.First().Key.ToLower();

			return expectedParams.Contains(param);
		}
	}
}
