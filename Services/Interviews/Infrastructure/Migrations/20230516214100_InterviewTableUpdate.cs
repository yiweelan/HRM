using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InterviewTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterviewTypeId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InterviewerId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Passed",
                table: "Interviews",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Interviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubmissionId",
                table: "Interviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                principalTable: "Interviewers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_interviewTypeLookUps_InterviewTypeId",
                table: "Interviews",
                column: "InterviewTypeId",
                principalTable: "interviewTypeLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Interviewers_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_interviewTypeLookUps_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewTypeId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "InterviewerId",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "Passed",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Interviews");

            migrationBuilder.DropColumn(
                name: "SubmissionId",
                table: "Interviews");
        }
    }
}
