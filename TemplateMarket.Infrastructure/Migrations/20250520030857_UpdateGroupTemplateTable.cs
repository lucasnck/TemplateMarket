using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGroupTemplateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroupTemplates_Groups_GroupId",
                table: "UserGroupTemplates");

            migrationBuilder.DropIndex(
                name: "IX_UserGroupTemplates_GroupId",
                table: "UserGroupTemplates");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "UserGroupTemplates");

            migrationBuilder.AddColumn<long>(
                name: "GroupTemplateId",
                table: "Groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_GroupTemplateId",
                table: "Groups",
                column: "GroupTemplateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_UserGroupTemplates_GroupTemplateId",
                table: "Groups",
                column: "GroupTemplateId",
                principalTable: "UserGroupTemplates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserGroupTemplates_GroupTemplateId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupTemplateId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "GroupTemplateId",
                table: "Groups");

            migrationBuilder.AddColumn<long>(
                name: "GroupId",
                table: "UserGroupTemplates",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupTemplates_GroupId",
                table: "UserGroupTemplates",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroupTemplates_Groups_GroupId",
                table: "UserGroupTemplates",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
