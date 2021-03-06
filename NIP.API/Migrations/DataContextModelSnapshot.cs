﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NIP.API.Data;

namespace NIP.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("NIP.API.Models.CompanyModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("NationalBusinessRegistryNumber")
                        .HasMaxLength(9);

                    b.Property<string>("NationalCourtRegister")
                        .HasMaxLength(10);

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("TaxNumber")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("NIP.API.Models.HeaderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HeaderName");

                    b.Property<string>("HeaderValue");

                    b.Property<int>("QueryId");

                    b.HasKey("Id");

                    b.HasIndex("QueryId");

                    b.ToTable("headers");
                });

            modelBuilder.Entity("NIP.API.Models.QueryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("InsertDate");

                    b.Property<string>("QueryParamName");

                    b.Property<string>("QueryParamValue");

                    b.HasKey("Id");

                    b.ToTable("queries");
                });

            modelBuilder.Entity("NIP.API.Models.HeaderModel", b =>
                {
                    b.HasOne("NIP.API.Models.QueryModel", "Query")
                        .WithMany("Headers")
                        .HasForeignKey("QueryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
