using Microsoft.EntityFrameworkCore.Migrations;

namespace Web2_Backend.Migrations
{
    public partial class MultimediaAttachments2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "WorkRequestId",
                table: "MultimediaAttachments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaAttachments_WorkRequestId",
                table: "MultimediaAttachments",
                column: "WorkRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_MultimediaAttachments_WorkRequests_WorkRequestId",
                table: "MultimediaAttachments",
                column: "WorkRequestId",
                principalTable: "WorkRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultimediaAttachments_WorkRequests_WorkRequestId",
                table: "MultimediaAttachments");

            migrationBuilder.DropIndex(
                name: "IX_MultimediaAttachments_WorkRequestId",
                table: "MultimediaAttachments");

            migrationBuilder.DropColumn(
                name: "WorkRequestId",
                table: "MultimediaAttachments");
        }
    }
}
