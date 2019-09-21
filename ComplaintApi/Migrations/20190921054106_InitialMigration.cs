using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComplaintApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyMasters",
                columns: table => new
                {
                    CompanyID = table.Column<string>(maxLength: 100, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(maxLength: 150, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMasters", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "ComplainsHistories",
                columns: table => new
                {
                    HistoryID = table.Column<string>(maxLength: 100, nullable: false),
                    ComplainID = table.Column<string>(maxLength: 50, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainsHistories", x => new { x.HistoryID, x.ComplainID });
                });

            migrationBuilder.CreateTable(
                name: "ComplainsMasters",
                columns: table => new
                {
                    CompanyID = table.Column<string>(maxLength: 100, nullable: false),
                    ModuleID = table.Column<string>(maxLength: 50, nullable: false),
                    EmpID = table.Column<string>(maxLength: 50, nullable: false),
                    PriorityID = table.Column<string>(maxLength: 50, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<string>(maxLength: 50, nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplainsMasters", x => new { x.CompanyID, x.ModuleID, x.EmpID, x.PriorityID });
                });

            migrationBuilder.CreateTable(
                name: "ModuleMasters",
                columns: table => new
                {
                    ModuleID = table.Column<string>(maxLength: 50, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    ModuleName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuleMasters", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "PriorityMasters",
                columns: table => new
                {
                    PriorityID = table.Column<string>(maxLength: 100, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriorityMasters", x => x.PriorityID);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanies",
                columns: table => new
                {
                    EmpID = table.Column<string>(maxLength: 50, nullable: false),
                    CompanyID = table.Column<string>(maxLength: 100, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanies", x => new { x.EmpID, x.CompanyID });
                });

            migrationBuilder.CreateTable(
                name: "UserMasters",
                columns: table => new
                {
                    EmpID = table.Column<string>(maxLength: 50, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 40, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    IsAdmin = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMasters", x => x.EmpID);
                });

            migrationBuilder.CreateTable(
                name: "UserModules",
                columns: table => new
                {
                    EmpID = table.Column<string>(maxLength: 50, nullable: false),
                    ModuleID = table.Column<string>(maxLength: 50, nullable: false),
                    COMPCODE = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModules", x => new { x.EmpID, x.ModuleID });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyMasters");

            migrationBuilder.DropTable(
                name: "ComplainsHistories");

            migrationBuilder.DropTable(
                name: "ComplainsMasters");

            migrationBuilder.DropTable(
                name: "ModuleMasters");

            migrationBuilder.DropTable(
                name: "PriorityMasters");

            migrationBuilder.DropTable(
                name: "UserCompanies");

            migrationBuilder.DropTable(
                name: "UserMasters");

            migrationBuilder.DropTable(
                name: "UserModules");
        }
    }
}
