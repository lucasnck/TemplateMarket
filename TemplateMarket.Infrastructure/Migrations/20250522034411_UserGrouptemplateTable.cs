using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserGrouptemplateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupGroupTemplate_GroupTemplates_GroupTemplatesId",
                table: "GroupGroupTemplate");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupGroupTemplate_Groups_GroupsId",
                table: "GroupGroupTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupGroupTemplate",
                table: "GroupGroupTemplate");

            migrationBuilder.RenameTable(
                name: "GroupGroupTemplate",
                newName: "GroupTemplateGroups");

            migrationBuilder.RenameIndex(
                name: "IX_GroupGroupTemplate_GroupsId",
                table: "GroupTemplateGroups",
                newName: "IX_GroupTemplateGroups_GroupsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTemplateGroups",
                table: "GroupTemplateGroups",
                columns: new[] { "GroupTemplatesId", "GroupsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTemplateGroups_GroupTemplates_GroupTemplatesId",
                table: "GroupTemplateGroups",
                column: "GroupTemplatesId",
                principalTable: "GroupTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTemplateGroups_Groups_GroupsId",
                table: "GroupTemplateGroups",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTemplateGroups_GroupTemplates_GroupTemplatesId",
                table: "GroupTemplateGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupTemplateGroups_Groups_GroupsId",
                table: "GroupTemplateGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTemplateGroups",
                table: "GroupTemplateGroups");

            migrationBuilder.RenameTable(
                name: "GroupTemplateGroups",
                newName: "GroupGroupTemplate");

            migrationBuilder.RenameIndex(
                name: "IX_GroupTemplateGroups_GroupsId",
                table: "GroupGroupTemplate",
                newName: "IX_GroupGroupTemplate_GroupsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupGroupTemplate",
                table: "GroupGroupTemplate",
                columns: new[] { "GroupTemplatesId", "GroupsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_GroupGroupTemplate_GroupTemplates_GroupTemplatesId",
                table: "GroupGroupTemplate",
                column: "GroupTemplatesId",
                principalTable: "GroupTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupGroupTemplate_Groups_GroupsId",
                table: "GroupGroupTemplate",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
