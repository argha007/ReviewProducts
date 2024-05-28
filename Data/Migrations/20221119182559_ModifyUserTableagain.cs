using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ModifyUserTableagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "firsName",
                table: "User",
                newName: "firstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
