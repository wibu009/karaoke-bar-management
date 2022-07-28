using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL.Migrations
{
    public partial class DA1_862_QLPM_Karaoke_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GiaPhong",
                table: "CongThucTinh",
                type: "float",
                nullable: true,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<double>(
                name: "GiaPhongVIP",
                table: "CongThucTinh",
                type: "float",
                nullable: true,
                defaultValueSql: "((0))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiaPhong",
                table: "CongThucTinh");

            migrationBuilder.DropColumn(
                name: "GiaPhongVIP",
                table: "CongThucTinh");
        }
    }
}
