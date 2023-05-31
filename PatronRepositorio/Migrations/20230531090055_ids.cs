using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatronRepositorio.Migrations
{
    /// <inheritdoc />
    public partial class ids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdComida",
                table: "Hamburguesa",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdComida",
                table: "Alita",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Hamburguesa",
                newName: "IdComida");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alita",
                newName: "IdComida");
        }
    }
}
