using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookMyHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAndSeedAccommodationImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccommodationImages",
                columns: new[] { "AccommodationImageId", "AccommodationId", "ImageUrl" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-facade.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-facade-terrasse.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-inde-alrum.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-inde-stue.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-inde-stue-kurvesofa.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-inde-stue-sofa.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-inde-stue-udgang-terrasse.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), new Guid("a09af322-d431-4be3-b01a-d7a444355088"), "/Images/SommerHus1/Nova-idyll-plan.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "AccommodationImages",
                keyColumn: "AccommodationImageId",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));
        }
    }
}
