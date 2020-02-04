using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Verivox.Domain.Migrations
{
    public partial class AddConsumptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    ReadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumptions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ReadDate", "Value" },
                values: new object[] { new Guid("3f3cf52a-52de-4fda-be3c-99168b01e36f"), new DateTime(2020, 2, 4, 1, 55, 24, 861, DateTimeKind.Utc).AddTicks(9694), 3500m });

            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ReadDate", "Value" },
                values: new object[] { new Guid("c36154b3-bbf5-4dc5-8291-3b2b816081f3"), new DateTime(2020, 2, 4, 1, 55, 24, 862, DateTimeKind.Utc).AddTicks(420), 4500m });

            migrationBuilder.InsertData(
                table: "Consumptions",
                columns: new[] { "Id", "ReadDate", "Value" },
                values: new object[] { new Guid("6c4c002e-fc16-43a9-807e-fedd44649bc4"), new DateTime(2020, 2, 4, 1, 55, 24, 862, DateTimeKind.Utc).AddTicks(446), 6000m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumptions");
        }
    }
}
