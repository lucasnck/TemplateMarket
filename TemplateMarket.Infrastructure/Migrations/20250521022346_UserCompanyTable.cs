using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserCompanyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Companies_CompanyId",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Companies_CompanyId1",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_User_UserId",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany");

            migrationBuilder.RenameTable(
                name: "UserCompany",
                newName: "UserCompanies");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompanies",
                newName: "IX_UserCompanies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompany_CompanyId1",
                table: "UserCompanies",
                newName: "IX_UserCompanies_CompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompany_CompanyId",
                table: "UserCompanies",
                newName: "IX_UserCompanies_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanies",
                table: "UserCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId1",
                table: "UserCompanies",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_UserCompanies_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId",
                principalTable: "UserCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_Companies_CompanyId1",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanies_User_UserId",
                table: "UserCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_UserCompanies_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanies",
                table: "UserCompanies");

            migrationBuilder.RenameTable(
                name: "UserCompanies",
                newName: "UserCompany");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanies_UserId",
                table: "UserCompany",
                newName: "IX_UserCompany_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanies_CompanyId1",
                table: "UserCompany",
                newName: "IX_UserCompany_CompanyId1");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanies_CompanyId",
                table: "UserCompany",
                newName: "IX_UserCompany_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompany",
                table: "UserCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Companies_CompanyId",
                table: "UserCompany",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Companies_CompanyId1",
                table: "UserCompany",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_User_UserId",
                table: "UserCompany",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
