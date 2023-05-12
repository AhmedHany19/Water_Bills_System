using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Default_Slice_Values",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "char(50)", maxLength: 50, nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    Water_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sanitation_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comments = table.Column<string>(type: "char(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Default_Slice_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "real_Estate_Types",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    Name = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Comments = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_real_Estate_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Area = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Mobile = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Comments = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    No = table.Column<int>(type: "int", nullable: true),
                    Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Last_Reading_Meter = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Subscriber_Id = table.Column<string>(type: "char(10)", nullable: false),
                    Real_State_Id = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_real_Estate_Types_Real_State_Id",
                        column: x => x.Real_State_Id,
                        principalTable: "real_Estate_Types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscriptions_Subscribers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "Subscribers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Year = table.Column<string>(type: "char(2)", maxLength: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Previous_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Current_Consumption_Amount = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Amount_Consumption = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Service_Fee = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tax_Rate = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Is_There_Sanitation = table.Column<bool>(type: "bit", nullable: false),
                    Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Wastewater_Consumption_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Invoice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Tax_Value = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Total_Bill = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Comments = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Subscriber_Id = table.Column<string>(type: "char(10)", nullable: false),
                    Subscribetion_Id = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Real_State_Id = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_real_Estate_Types_Real_State_Id",
                        column: x => x.Real_State_Id,
                        principalTable: "real_Estate_Types",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Subscribers_Subscriber_Id",
                        column: x => x.Subscriber_Id,
                        principalTable: "Subscribers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Subscriptions_Subscribetion_Id",
                        column: x => x.Subscribetion_Id,
                        principalTable: "Subscriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Real_State_Id",
                table: "Invoices",
                column: "Real_State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Subscriber_Id",
                table: "Invoices",
                column: "Subscriber_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Subscribetion_Id",
                table: "Invoices",
                column: "Subscribetion_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Real_State_Id",
                table: "Subscriptions",
                column: "Real_State_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Subscriber_Id",
                table: "Subscriptions",
                column: "Subscriber_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Default_Slice_Values");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "real_Estate_Types");

            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
