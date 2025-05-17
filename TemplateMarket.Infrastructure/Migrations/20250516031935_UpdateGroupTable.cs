using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroupTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_Companies_CompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_User_UserId",
                table: "UserCompanyGroups");

            migrationBuilder.DropColumn(
                name: "Productd",
                table: "WorkflowItem");

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "UserCompanyId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CompanyId1",
                table: "UserCompany",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompanyId1",
                table: "UserCompany",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompany_Companies_CompanyId1",
                table: "UserCompany",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_Companies_CompanyId",
                table: "UserCompanyGroups",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId",
                principalTable: "UserCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_User_UserId",
                table: "UserCompanyGroups",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompany_Companies_CompanyId1",
                table: "UserCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_Companies_CompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_User_UserId",
                table: "UserCompanyGroups");

            migrationBuilder.DropIndex(
                name: "IX_UserCompany_CompanyId1",
                table: "UserCompany");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "UserCompany");

            migrationBuilder.AddColumn<long>(
                name: "Productd",
                table: "WorkflowItem",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserCompanyId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CompanyId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_Companies_CompanyId",
                table: "UserCompanyGroups",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId",
                principalTable: "UserCompany",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_User_UserId",
                table: "UserCompanyGroups",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
