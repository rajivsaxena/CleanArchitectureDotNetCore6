using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drona.AyushmanBharat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedprogressstep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TxnId",
                table: "GenerateAadhaarOtpResponse",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProgressStep",
                table: "GenerateAadhaarOtpResponse",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProgressStep",
                table: "GenerateAadhaarOtpResponse");

            migrationBuilder.AlterColumn<string>(
                name: "TxnId",
                table: "GenerateAadhaarOtpResponse",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
