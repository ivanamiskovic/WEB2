using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2_Backend.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OperaterId",
                table: "WorkRequests",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperaterId",
                table: "WorkingPlans",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperaterId",
                table: "SwitchingPlans",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperaterId",
                table: "SafetyDocuments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkRequests_OperaterId",
                table: "WorkRequests",
                column: "OperaterId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingPlans_OperaterId",
                table: "WorkingPlans",
                column: "OperaterId");

            migrationBuilder.CreateIndex(
                name: "IX_SwitchingPlans_OperaterId",
                table: "SwitchingPlans",
                column: "OperaterId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyDocuments_OperaterId",
                table: "SafetyDocuments",
                column: "OperaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_SafetyDocuments_Users_OperaterId",
                table: "SafetyDocuments",
                column: "OperaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SwitchingPlans_Users_OperaterId",
                table: "SwitchingPlans",
                column: "OperaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingPlans_Users_OperaterId",
                table: "WorkingPlans",
                column: "OperaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkRequests_Users_OperaterId",
                table: "WorkRequests",
                column: "OperaterId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SafetyDocuments_Users_OperaterId",
                table: "SafetyDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_SwitchingPlans_Users_OperaterId",
                table: "SwitchingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingPlans_Users_OperaterId",
                table: "WorkingPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkRequests_Users_OperaterId",
                table: "WorkRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkRequests_OperaterId",
                table: "WorkRequests");

            migrationBuilder.DropIndex(
                name: "IX_WorkingPlans_OperaterId",
                table: "WorkingPlans");

            migrationBuilder.DropIndex(
                name: "IX_SwitchingPlans_OperaterId",
                table: "SwitchingPlans");

            migrationBuilder.DropIndex(
                name: "IX_SafetyDocuments_OperaterId",
                table: "SafetyDocuments");

            migrationBuilder.DropColumn(
                name: "OperaterId",
                table: "WorkRequests");

            migrationBuilder.DropColumn(
                name: "OperaterId",
                table: "WorkingPlans");

            migrationBuilder.DropColumn(
                name: "OperaterId",
                table: "SwitchingPlans");

            migrationBuilder.DropColumn(
                name: "OperaterId",
                table: "SafetyDocuments");
        }
    }
}
