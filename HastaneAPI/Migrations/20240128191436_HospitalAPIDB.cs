using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneAPI.Migrations
{
    public partial class HospitalAPIDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HospitalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Klinik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HastaneID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patients_Hospitals_HastaneID",
                        column: x => x.HastaneID,
                        principalTable: "Hospitals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "ID", "Address", "HospitalName" },
                values: new object[] { 1, "Şişli,İstanbul", "Şişli Eftal" });

            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "ID", "Address", "HospitalName" },
                values: new object[] { 2, "Bakırköy,Istanbul", "Bakırköy Sadi Konuk" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "ControlDate", "FirstName", "HastaneID", "Klinik", "LastName" },
                values: new object[] { 1, new DateTime(2023, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 1, "deri ve zührevi hastlıkları", "Doe" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "ID", "ControlDate", "FirstName", "HastaneID", "Klinik", "LastName" },
                values: new object[] { 2, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeyn", 2, "Üroloji ve zührevi hastlıkları", "Doe" });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_HastaneID",
                table: "Patients",
                column: "HastaneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Hospitals");
        }
    }
}
