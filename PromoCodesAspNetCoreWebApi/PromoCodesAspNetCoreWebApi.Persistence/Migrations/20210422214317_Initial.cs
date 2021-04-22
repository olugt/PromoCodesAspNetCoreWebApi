using Microsoft.EntityFrameworkCore.Migrations;

namespace PromoCodesAspNetCoreWebApi.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PromoCode",
                columns: table => new
                {
                    PromoCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCode", x => x.PromoCodeId);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHashToBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Bonus",
                columns: table => new
                {
                    BonusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    PromoCodeId = table.Column<int>(type: "int", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonus", x => x.BonusId);
                    table.ForeignKey(
                        name: "FK_Bonus_PromoCode_PromoCodeId",
                        column: x => x.PromoCodeId,
                        principalTable: "PromoCode",
                        principalColumn: "PromoCodeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bonus_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bonus_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PromoCode",
                columns: new[] { "PromoCodeId", "Name" },
                values: new object[,]
                {
                    { 1, "promo-code-1" },
                    { 2, "promo-code-2" },
                    { 3, "promo-code-3" },
                    { 4, "promo-code-4" },
                    { 5, "promo-code-5" },
                    { 6, "promo-code-6" }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "Name" },
                values: new object[,]
                {
                    { 13, "Service 13" },
                    { 12, "Service 12" },
                    { 11, "Service 11" },
                    { 10, "Service 10" },
                    { 9, "Service 9" },
                    { 8, "Service 8" },
                    { 5, "Service 5" },
                    { 6, "Service 6" },
                    { 4, "Service 4" },
                    { 3, "Service 3" },
                    { 2, "Service 2" },
                    { 1, "Service 1" },
                    { 7, "Service 7" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "EmailAddress", "PasswordHashToBase64" },
                values: new object[,]
                {
                    { 2, "user2@example.com", "B8Z3ujhmjbX5A3sBJbChHOtYkfP7jmdIu6WkxvUkJD0=" },
                    { 1, "user1@example.com", "vzPpKDsZCudRgRhmIGQdq8F0TFIkjBynvl935RCMy1I=" },
                    { 3, "user3@example.com", "8sjNudBiNzbUY9C23oDdel/rQ/bp4dXnmlVA12IOZeE=" }
                });

            migrationBuilder.InsertData(
                table: "Bonus",
                columns: new[] { "BonusId", "Amount", "IsActivated", "PromoCodeId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 1, 12.3m, null, null, 1, 1 },
                    { 2, 23.4m, null, null, 4, 1 },
                    { 3, 45.6m, null, null, 7, 1 },
                    { 4, 56.7m, null, null, 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_PromoCodeId",
                table: "Bonus",
                column: "PromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_ServiceId",
                table: "Bonus",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bonus_UserId_ServiceId",
                table: "Bonus",
                columns: new[] { "UserId", "ServiceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromoCode_Name",
                table: "PromoCode",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Service_Name",
                table: "Service",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailAddress",
                table: "User",
                column: "EmailAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonus");

            migrationBuilder.DropTable(
                name: "PromoCode");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
