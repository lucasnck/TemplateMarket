using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserComapnyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserCompanyId",
                table: "UserCompanyGroups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserGroupId",
                table: "GroupRoles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserCompany",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCompany_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCompany_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyGroups_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoles_UserGroupId",
                table: "GroupRoles",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_CompanyId",
                table: "UserCompany",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompany_UserId",
                table: "UserCompany",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoles_UserGroups_UserGroupId",
                table: "GroupRoles",
                column: "UserGroupId",
                principalTable: "UserGroups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups",
                column: "UserCompanyId",
                principalTable: "UserCompany",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoles_UserGroups_UserGroupId",
                table: "GroupRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyGroups_UserCompany_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropTable(
                name: "UserCompany");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanyGroups_UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoles_UserGroupId",
                table: "GroupRoles");

            migrationBuilder.DropColumn(
                name: "UserCompanyId",
                table: "UserCompanyGroups");

            migrationBuilder.DropColumn(
                name: "UserGroupId",
                table: "GroupRoles");
        }
    }
}
