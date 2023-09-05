using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drona.AyushmanBharat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorUniversityAndCollege : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorUniversities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HprUniversityId = table.Column<int>(type: "int", nullable: false),
                    UniversityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineSystemId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorUniversities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorUniversities_MedicineSystems_MedicineSystemId",
                        column: x => x.MedicineSystemId,
                        principalTable: "MedicineSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorColleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HprCollegeId = table.Column<int>(type: "int", nullable: false),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HprUniversityId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorColleges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorColleges_DoctorUniversities_HprUniversityId",
                        column: x => x.HprUniversityId,
                        principalTable: "DoctorUniversities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorColleges_HprUniversityId",
                table: "DoctorColleges",
                column: "HprUniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorUniversities_MedicineSystemId",
                table: "DoctorUniversities",
                column: "MedicineSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorColleges");

            migrationBuilder.DropTable(
                name: "DoctorUniversities");
        }
    }
}
