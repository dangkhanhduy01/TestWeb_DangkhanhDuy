using Microsoft.EntityFrameworkCore.Migrations;

namespace TestWeb_DangkhanhDuy.Migrations
{
    public partial class RecreateBookTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenSach",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TacGia",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "Books",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "GiaBia",
                table: "Books",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Books",
                newName: "TenSach");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Books",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Books",
                newName: "GiaBia");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Books",
                newName: "TacGia");
        }
    }
}
