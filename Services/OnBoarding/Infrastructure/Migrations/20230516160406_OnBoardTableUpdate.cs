using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class OnBoardTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpsId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusLookUpsId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeStatusLookUpsId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusId",
                table: "Employees",
                column: "EmployeeStatusId",
                principalTable: "EmployeeStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeStatusId",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeStatusLookUpsId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeStatusLookUpsId",
                table: "Employees",
                column: "EmployeeStatusLookUpsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeStatusLookUps_EmployeeStatusLookUpsId",
                table: "Employees",
                column: "EmployeeStatusLookUpsId",
                principalTable: "EmployeeStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
