using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityAndProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Services_ServiceId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Services_ServiceId1",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Templates_TemplateId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Templates_TemplateId1",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_Partners_PartnerId",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_Services_ServiceId",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_Services_ServiceId1",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_WorkOrders_WorkOrderId2",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Partners_AssignedToPartnerId",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "TemplateCategories");

            migrationBuilder.DropTable(
                name: "TemplatePlatforms");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_OrderItemServiceId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemServices_ServiceId",
                table: "OrderItemServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemServices_ServiceId1",
                table: "OrderItemServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ServiceId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ServiceId1",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_TemplateId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_TemplateId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "OrderItemServices");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "OrderItemServices");

            migrationBuilder.DropColumn(
                name: "WorkOrderId",
                table: "OrderItemServices");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ServiceId1",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TemplateId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "TemplateId1",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "FinishedDate",
                table: "WorkOrders",
                newName: "StartedDate");

            migrationBuilder.RenameColumn(
                name: "AssignedToPartnerId",
                table: "WorkOrders",
                newName: "PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_AssignedToPartnerId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_PartnerId");

            migrationBuilder.RenameColumn(
                name: "WorkOrderId2",
                table: "OrderItemServices",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemServices_WorkOrderId2",
                table: "OrderItemServices",
                newName: "IX_OrderItemServices_ProductId");

            migrationBuilder.AlterColumn<long>(
                name: "OrderItemServiceId",
                table: "WorkOrders",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "AssignedToUserId",
                table: "WorkOrders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedDate",
                table: "WorkOrders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderItemId",
                table: "WorkOrders",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Platforms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "PartnerId",
                table: "OrderItemServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrderItemId1",
                table: "OrderItemServices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PlatformId",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PlatformId2",
                table: "Categories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SKU = table.Column<string>(type: "text", nullable: false),
                    StockQuantity = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ProductType = table.Column<string>(type: "text", nullable: false),
                    PartnerId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    PartnerId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Partners_PartnerId1",
                        column: x => x.PartnerId1,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Showcase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showcase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Showcase_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedDeliveryDays = table.Column<int>(type: "integer", nullable: false),
                    SupportType = table.Column<string>(type: "text", nullable: true),
                    PartnerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    PreviewUrl = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShowcaseProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ShowcaseId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowcaseProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowcaseProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShowcaseProduct_Showcase_ShowcaseId",
                        column: x => x.ShowcaseId,
                        principalTable: "Showcase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignedToUserId",
                table: "WorkOrders",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderItemId",
                table: "WorkOrders",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderItemServiceId",
                table: "WorkOrders",
                column: "OrderItemServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Platforms_CategoryId",
                table: "Platforms",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemServices_OrderItemId1",
                table: "OrderItemServices",
                column: "OrderItemId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlatformId2",
                table: "Categories",
                column: "PlatformId2");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId1",
                table: "ProductCategories",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PartnerId",
                table: "Products",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PartnerId1",
                table: "Products",
                column: "PartnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_PartnerId",
                table: "ServiceDetails",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ProductId",
                table: "ServiceDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Showcase_CategoryId",
                table: "Showcase",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseProduct_ProductId",
                table: "ShowcaseProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowcaseProduct_ShowcaseId",
                table: "ShowcaseProduct",
                column: "ShowcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateDetails_ProductId",
                table: "TemplateDetails",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Platforms_PlatformId2",
                table: "Categories",
                column: "PlatformId2",
                principalTable: "Platforms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_OrderItems_OrderItemId1",
                table: "OrderItemServices",
                column: "OrderItemId1",
                principalTable: "OrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_Partners_PartnerId",
                table: "OrderItemServices",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_Products_ProductId",
                table: "OrderItemServices",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Platforms_Categories_CategoryId",
                table: "Platforms",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_OrderItems_OrderItemId",
                table: "WorkOrders",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Partners_PartnerId",
                table: "WorkOrders",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_User_AssignedToUserId",
                table: "WorkOrders",
                column: "AssignedToUserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Platforms_PlatformId2",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_OrderItems_OrderItemId1",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_Partners_PartnerId",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemServices_Products_ProductId",
                table: "OrderItemServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Platforms_Categories_CategoryId",
                table: "Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_OrderItems_OrderItemId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_Partners_PartnerId",
                table: "WorkOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrders_User_AssignedToUserId",
                table: "WorkOrders");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ServiceDetails");

            migrationBuilder.DropTable(
                name: "ShowcaseProduct");

            migrationBuilder.DropTable(
                name: "TemplateDetails");

            migrationBuilder.DropTable(
                name: "Showcase");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_AssignedToUserId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_OrderItemId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrders_OrderItemServiceId",
                table: "WorkOrders");

            migrationBuilder.DropIndex(
                name: "IX_Platforms_CategoryId",
                table: "Platforms");

            migrationBuilder.DropIndex(
                name: "IX_OrderItemServices_OrderItemId1",
                table: "OrderItemServices");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PlatformId2",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AssignedToUserId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CompletedDate",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Platforms");

            migrationBuilder.DropColumn(
                name: "OrderItemId1",
                table: "OrderItemServices");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PlatformId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PlatformId2",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "StartedDate",
                table: "WorkOrders",
                newName: "FinishedDate");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "WorkOrders",
                newName: "AssignedToPartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrders_PartnerId",
                table: "WorkOrders",
                newName: "IX_WorkOrders_AssignedToPartnerId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItemServices",
                newName: "WorkOrderId2");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItemServices_ProductId",
                table: "OrderItemServices",
                newName: "IX_OrderItemServices_WorkOrderId2");

            migrationBuilder.AlterColumn<long>(
                name: "OrderItemServiceId",
                table: "WorkOrders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PartnerId",
                table: "OrderItemServices",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "OrderItemServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId1",
                table: "OrderItemServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "WorkOrderId",
                table: "OrderItemServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ServiceId1",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TemplateId",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TemplateId1",
                table: "OrderItems",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PartnerId = table.Column<long>(type: "bigint", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartnerId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PreviewUrl = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Theme = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Templates_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    ServiceId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => new { x.ServiceId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ServiceCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCategories_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateCategories",
                columns: table => new
                {
                    TemplateId = table.Column<long>(type: "bigint", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateCategories", x => new { x.TemplateId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TemplateCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplateCategories_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplatePlatforms",
                columns: table => new
                {
                    TemplateId = table.Column<long>(type: "bigint", nullable: false),
                    PlatformId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplatePlatforms", x => new { x.TemplateId, x.PlatformId });
                    table.ForeignKey(
                        name: "FK_TemplatePlatforms_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemplatePlatforms_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_OrderItemServiceId",
                table: "WorkOrders",
                column: "OrderItemServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemServices_ServiceId",
                table: "OrderItemServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemServices_ServiceId1",
                table: "OrderItemServices",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ServiceId",
                table: "OrderItems",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ServiceId1",
                table: "OrderItems",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_TemplateId",
                table: "OrderItems",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_TemplateId1",
                table: "OrderItems",
                column: "TemplateId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_CategoryId",
                table: "ServiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PartnerId",
                table: "Services",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateCategories_CategoryId",
                table: "TemplateCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplatePlatforms_PlatformId",
                table: "TemplatePlatforms",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_PartnerId",
                table: "Templates",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Services_ServiceId",
                table: "OrderItems",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Services_ServiceId1",
                table: "OrderItems",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Templates_TemplateId",
                table: "OrderItems",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Templates_TemplateId1",
                table: "OrderItems",
                column: "TemplateId1",
                principalTable: "Templates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_Partners_PartnerId",
                table: "OrderItemServices",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_Services_ServiceId",
                table: "OrderItemServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_Services_ServiceId1",
                table: "OrderItemServices",
                column: "ServiceId1",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemServices_WorkOrders_WorkOrderId2",
                table: "OrderItemServices",
                column: "WorkOrderId2",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrders_Partners_AssignedToPartnerId",
                table: "WorkOrders",
                column: "AssignedToPartnerId",
                principalTable: "Partners",
                principalColumn: "Id");
        }
    }
}
