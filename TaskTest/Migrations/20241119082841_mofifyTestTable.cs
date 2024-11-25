using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTest.Migrations
{
    /// <inheritdoc />
    public partial class mofifyTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Test",
                table: "Tests",
                newName: "Result");

            migrationBuilder.AddColumn<string>(
                name: "Parameter",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parameter",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Tests",
                newName: "Test");
        }
    }
}
