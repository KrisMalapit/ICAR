using Microsoft.EntityFrameworkCore.Migrations;

namespace ICAR.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Departments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Departments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "ID",
                keyValue: 1,
                column: "CompanyId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CompanyId",
                table: "Departments",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Companies_CompanyId",
                table: "Departments",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
