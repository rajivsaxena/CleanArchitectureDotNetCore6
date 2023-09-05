using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drona.AyushmanBharat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorSpeciality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorSpecialities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HprSpcialityId = table.Column<int>(type: "int", nullable: false),
                    SpecialityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicineSystemId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSpecialities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorSpecialities_MedicineSystems_MedicineSystemId",
                        column: x => x.MedicineSystemId,
                        principalTable: "MedicineSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSpecialities_MedicineSystemId",
                table: "DoctorSpecialities",
                column: "MedicineSystemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorSpecialities");
        }
    }
}
