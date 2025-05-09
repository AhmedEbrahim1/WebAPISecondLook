using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPISecondLook.Migrations
{
    /// <inheritdoc />
    public partial class updateV01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeptId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeptId",
                table: "Employee",
                column: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DeptId",
                table: "Employee",
                column: "DeptId",
                principalTable: "Department",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DeptId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DeptId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeptId",
                table: "Employee");
        }
    }
}
