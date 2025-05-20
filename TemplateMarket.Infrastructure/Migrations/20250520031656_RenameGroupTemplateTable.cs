using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameGroupTemplateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_UserGroupTemplates_GroupTemplateId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_GroupTemplateId",
                table: "Groups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroupTemplates",
                table: "UserGroupTemplates");

            migrationBuilder.DropColumn(
                name: "GroupTemplateId",
                table: "Groups");

            migrationBuilder.RenameTable(
                name: "UserGroupTemplates",
                newName: "GroupTemplates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GroupTemplates",
                table: "GroupTemplates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GroupGroupTemplate",
                columns: table => new
                {
                    GroupTemplatesId = table.Column<long>(type: "bigint", nullable: false),
                    GroupsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupGroupTemplate", x => new { x.GroupTemplatesId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_GroupGroupTemplate_GroupTemplates_GroupTemplatesId",
                        column: x => x.GroupTemplatesId,
                        principalTable: "GroupTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupGroupTemplate_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupGroupTemplate_GroupsId",
                table: "GroupGroupTemplate",
                column: "GroupsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupGroupTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GroupTemplates",
                table: "GroupTemplates");

            migrationBuilder.RenameTable(
                name: "GroupTemplates",
                newName: "UserGroupTemplates");

            migrationBuilder.AddColumn<long>(
                name: "GroupTemplateId",
                table: "Groups",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroupTemplates",
                table: "UserGroupTemplates",
                column: "Id");

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
    }
}
