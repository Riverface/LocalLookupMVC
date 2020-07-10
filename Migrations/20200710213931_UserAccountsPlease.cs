using Microsoft.EntityFrameworkCore.Migrations;

namespace LocalLookupMVC.Migrations
{
    public partial class UserAccountsPlease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "Blurb",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Cities",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "ZipCode",
                table: "Cities",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cities",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Cities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Blurb",
                table: "Cities",
                nullable: true);
        }
    }
}
