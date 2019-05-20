using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NIP.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 10, nullable: true),
                    NationalBusinessRegistryNumber = table.Column<string>(maxLength: 9, nullable: true),
                    NationalCourtRegister = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "queries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InsertDate = table.Column<DateTime>(nullable: false),
                    QueryParamName = table.Column<string>(nullable: true),
                    QueryParamValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_queries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "headers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QueryId = table.Column<int>(nullable: false),
                    HeaderName = table.Column<string>(nullable: true),
                    HeaderValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_headers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_headers_queries_QueryId",
                        column: x => x.QueryId,
                        principalTable: "queries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_headers_QueryId",
                table: "headers",
                column: "QueryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "headers");

            migrationBuilder.DropTable(
                name: "queries");
        }
    }
}
