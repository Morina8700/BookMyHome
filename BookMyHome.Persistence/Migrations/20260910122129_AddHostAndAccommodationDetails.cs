using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMyHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHostAndAccommodationDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "HostId",
                table: "Accommodations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PricePerNight",
                table: "Accommodations",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Address", "HostId", "PricePerNight" },
                values: new object[] { "Beach Road 1", new Guid("33333333-3333-3333-3333-333333333333"), 1200m });

            migrationBuilder.UpdateData(
                table: "Accommodations",
                keyColumn: "AccommodationId",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Address", "HostId", "PricePerNight" },
                values: new object[] { "Main Street 10", new Guid("33333333-3333-3333-3333-333333333333"), 850m });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "Discriminator", "Email", "Name" },
                values: new object[] { new Guid("33333333-3333-3333-3333-333333333333"), "Host", "host@bookmyhome.dk", "Test Host" });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodations_HostId",
                table: "Accommodations",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accommodations_User_HostId",
                table: "Accommodations",
                column: "HostId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accommodations_User_HostId",
                table: "Accommodations");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Accommodations_HostId",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Accommodations");

            migrationBuilder.DropColumn(
                name: "PricePerNight",
                table: "Accommodations");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Accommodations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
