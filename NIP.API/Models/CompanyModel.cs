using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Models
{
	public class CompanyModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Street { get; set; }
		public string StreetNumber { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		[MaxLength(10)]
		public string TaxNumber { get; set; }
		[MaxLength(9)]
		public string NationalBusinessRegistryNumber { get; set; }
		[MaxLength(10)]
		public string NationalCourtRegister { get; set; }
	}
}
