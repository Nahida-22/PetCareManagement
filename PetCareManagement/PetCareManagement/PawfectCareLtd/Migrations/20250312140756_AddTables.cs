using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectCareLtd.Migrations
{
    /// <inheritdoc />
    public partial class AddTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_Medications_MedicationID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicationID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicationID",
                table: "Prescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MedicationID",
                table: "Prescriptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicationID",
                table: "Prescriptions",
                column: "MedicationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_Medications_MedicationID",
                table: "Prescriptions",
                column: "MedicationID",
                principalTable: "Medications",
                principalColumn: "MedicationID");
        }
    }
}
