using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Consistrack.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GPSMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vender = table.Column<string>(nullable: true),
                    DOP = table.Column<DateTime>(nullable: true),
                    DeviceModel = table.Column<string>(nullable: true),
                    ATModel = table.Column<string>(nullable: false),
                    IMEINo = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDT = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDT = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSMasters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SimMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ATSN = table.Column<string>(nullable: true),
                    OperatorName = table.Column<string>(nullable: false),
                    MobileNo = table.Column<string>(nullable: false),
                    SimNo = table.Column<string>(nullable: false),
                    Apn = table.Column<string>(nullable: true),
                    Plan = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDT = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDT = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimMasters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GPSMasters");

            migrationBuilder.DropTable(
                name: "SimMasters");
        }
    }
}
