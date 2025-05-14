using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TemplateMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkflowTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CommandName = table.Column<string>(type: "text", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorOutput",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsFinal = table.Column<bool>(type: "boolean", nullable: false),
                    ConnectedProcessorId = table.Column<long>(type: "bigint", nullable: true),
                    ConnectedProcessorId1 = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorOutput", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessorOutput_Processor_ConnectedProcessorId",
                        column: x => x.ConnectedProcessorId,
                        principalTable: "Processor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessorOutput_Processor_ConnectedProcessorId1",
                        column: x => x.ConnectedProcessorId1,
                        principalTable: "Processor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessorStep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WorkflowId = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowId1 = table.Column<long>(type: "bigint", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessorStep_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessorStep_Workflow_WorkflowId1",
                        column: x => x.WorkflowId1,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkOrderId = table.Column<long>(type: "bigint", nullable: true),
                    OrderId = table.Column<long>(type: "bigint", nullable: true),
                    Productd = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    WorkflowId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowItem_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowItem_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProcessorProcessorStep",
                columns: table => new
                {
                    ProcessorStepsId = table.Column<long>(type: "bigint", nullable: false),
                    ProcessorsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorProcessorStep", x => new { x.ProcessorStepsId, x.ProcessorsId });
                    table.ForeignKey(
                        name: "FK_ProcessorProcessorStep_ProcessorStep_ProcessorStepsId",
                        column: x => x.ProcessorStepsId,
                        principalTable: "ProcessorStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcessorProcessorStep_Processor_ProcessorsId",
                        column: x => x.ProcessorsId,
                        principalTable: "Processor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowStatus",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: false),
                    ProcessorStepId = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowStatus_ProcessorStep_ProcessorStepId",
                        column: x => x.ProcessorStepId,
                        principalTable: "ProcessorStep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowStatus_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemProcessorStep",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WorkflowItemId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItemProcessorStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItemProcessorStep_WorkflowItem_WorkflowItemId",
                        column: x => x.WorkflowItemId,
                        principalTable: "WorkflowItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowView",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ViewName = table.Column<string>(type: "text", nullable: false),
                    WorkflowStatusId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowView", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowView_WorkflowStatus_WorkflowStatusId",
                        column: x => x.WorkflowStatusId,
                        principalTable: "WorkflowStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemProcessor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowItemId = table.Column<long>(type: "bigint", nullable: false),
                    ProcessorOutputId = table.Column<long>(type: "bigint", nullable: false),
                    ProcessorId = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowItemProcessorStepId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItemProcessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItemProcessor_ProcessorOutput_Id",
                        column: x => x.Id,
                        principalTable: "ProcessorOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowItemProcessor_Processor_Id",
                        column: x => x.Id,
                        principalTable: "Processor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowItemProcessor_WorkflowItemProcessorStep_WorkflowIte~",
                        column: x => x.WorkflowItemProcessorStepId,
                        principalTable: "WorkflowItemProcessorStep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowItemProcessor_WorkflowItem_Id",
                        column: x => x.Id,
                        principalTable: "WorkflowItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processor_CommandName",
                table: "Processor",
                column: "CommandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorOutput_ConnectedProcessorId",
                table: "ProcessorOutput",
                column: "ConnectedProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorOutput_ConnectedProcessorId1",
                table: "ProcessorOutput",
                column: "ConnectedProcessorId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorProcessorStep_ProcessorsId",
                table: "ProcessorProcessorStep",
                column: "ProcessorsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorStep_WorkflowId",
                table: "ProcessorStep",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessorStep_WorkflowId1",
                table: "ProcessorStep",
                column: "WorkflowId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItem_OrderId",
                table: "WorkflowItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItem_ProductId",
                table: "WorkflowItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItem_WorkflowId",
                table: "WorkflowItem",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItem_WorkOrderId",
                table: "WorkflowItem",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemProcessor_WorkflowItemProcessorStepId",
                table: "WorkflowItemProcessor",
                column: "WorkflowItemProcessorStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemProcessorStep_WorkflowItemId",
                table: "WorkflowItemProcessorStep",
                column: "WorkflowItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStatus_ProcessorStepId",
                table: "WorkflowStatus",
                column: "ProcessorStepId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowStatus_WorkflowId",
                table: "WorkflowStatus",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowView_WorkflowStatusId",
                table: "WorkflowView",
                column: "WorkflowStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcessorProcessorStep");

            migrationBuilder.DropTable(
                name: "WorkflowItemProcessor");

            migrationBuilder.DropTable(
                name: "WorkflowView");

            migrationBuilder.DropTable(
                name: "ProcessorOutput");

            migrationBuilder.DropTable(
                name: "WorkflowItemProcessorStep");

            migrationBuilder.DropTable(
                name: "WorkflowStatus");

            migrationBuilder.DropTable(
                name: "Processor");

            migrationBuilder.DropTable(
                name: "WorkflowItem");

            migrationBuilder.DropTable(
                name: "ProcessorStep");

            migrationBuilder.DropTable(
                name: "Workflow");
        }
    }
}
