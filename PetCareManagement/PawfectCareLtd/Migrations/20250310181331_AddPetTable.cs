using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawfectCareLtd.Migrations
{
    /// <inheritdoc />
    public partial class AddPetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    PetID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    OwnerID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PetType = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.PetID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");
        }
    }
}
