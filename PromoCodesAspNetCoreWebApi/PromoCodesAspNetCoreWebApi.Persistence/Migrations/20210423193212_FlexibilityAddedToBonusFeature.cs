using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoCodesAspNetCoreWebApi.Persistence.Migrations
{
    public partial class FlexibilityAddedToBonusFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bonus_UserId_ServiceId",
                table: "Bonus");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PromoCode",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bonus",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ActivationDateTimeOffset",
                table: "Bonus",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_UserId",
                table: "Bonus",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bonus_UserId",
                table: "Bonus");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PromoCode");

            migrationBuilder.DropColumn(
                name: "ActivationDateTimeOffset",
                table: "Bonus");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Bonus",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_UserId_ServiceId",
                table: "Bonus",
                columns: new[] { "UserId", "ServiceId" },
                unique: true);
        }
    }
}
