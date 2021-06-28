using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2_Backend.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "WorkRequests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WorkRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Incident",
                table: "WorkRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Purpose",
                table: "WorkRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SafetyDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwitchingPlans",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Point = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCreateId = table.Column<long>(type: "bigint", nullable: true),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwitchingPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SwitchingPlans_Users_UserCreateId",
                        column: x => x.UserCreateId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwitchingPlans_UserCreateId",
                table: "SwitchingPlans",
                column: "UserCreateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SafetyDocuments");

            migrationBuilder.DropTable(
                name: "SwitchingPlans");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "WorkRequests");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkRequests");

            migrationBuilder.DropColumn(
                name: "Incident",
                table: "WorkRequests");

            migrationBuilder.DropColumn(
                name: "Purpose",
                table: "WorkRequests");
        }
    }
}
