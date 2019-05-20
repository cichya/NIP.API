using Microsoft.EntityFrameworkCore;
using NIP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NIP.API.Data
{
	public class DataContext : DbContext
	{
		public DbSet<CompanyModel> companies { get; set; }
		public DbSet<QueryModel> queries { get; set; }
		public DbSet<HeaderModel> headers { get; set; }

		public DataContext(DbContextOptions<DataContext> options)
			: base(options) {}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<QueryModel>()
				.HasMany(h => h.Headers)
				.WithOne(q => q.Query)
				.IsRequired();
		}
	}
}
