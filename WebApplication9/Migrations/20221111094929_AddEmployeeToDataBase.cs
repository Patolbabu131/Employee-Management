using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication9.Migrations
{
    public partial class AddEmployeeToDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    Emp_No = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contact_No = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.Emp_No);
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Sal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_No = table.Column<int>(type: "int", nullable: false),
                    Basic = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HRA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ME = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SY = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    month_year = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Sal_Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employes_Emp_No",
                        column: x => x.Emp_No,
                        principalTable: "Employes",
                        principalColumn: "Emp_No",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_Emp_No",
                table: "Salaries",
                column: "Emp_No");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
