using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoCodesAspNetCoreWebApi.Persistence.Migrations
{
    public partial class EditedPromoCodeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 2,
                column: "Amount",
                value: 10.00m);

            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 4,
                column: "Amount",
                value: 12.00m);

            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 6,
                column: "Amount",
                value: 30.00m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 2,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 4,
                column: "Amount",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "PromoCode",
                keyColumn: "PromoCodeId",
                keyValue: 6,
                column: "Amount",
                value: 0m);
        }
    }
}
