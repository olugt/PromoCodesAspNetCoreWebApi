using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoCodesAspNetCoreWebApi.Persistence.Migrations
{
    public partial class AddedMoreSeedDataForServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "Name" },
                values: new object[,]
                {
                    { 14, "Service 14" },
                    { 28, "Service 28" },
                    { 27, "Service 27" },
                    { 26, "Service 26" },
                    { 25, "Service 25" },
                    { 24, "Service 24" },
                    { 23, "Service 23" },
                    { 29, "Service 29" },
                    { 22, "Service 22" },
                    { 20, "Service 20" },
                    { 19, "Service 19" },
                    { 18, "Service 18" },
                    { 17, "Service 17" },
                    { 16, "Service 16" },
                    { 15, "Service 15" },
                    { 21, "Service 21" },
                    { 30, "Service 30" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 30);
        }
    }
}
