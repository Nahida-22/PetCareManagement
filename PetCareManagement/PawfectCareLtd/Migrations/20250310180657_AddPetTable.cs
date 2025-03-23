/**using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectCareLtd.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_Pet_OwnerID",
            //    table: "Pet");

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Pet",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "Pet",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_OwnerID",
                table: "Pet",
                column: "OwnerID");
        }
    }
}**/
