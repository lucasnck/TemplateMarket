using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompanies",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
