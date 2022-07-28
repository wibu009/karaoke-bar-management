using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL.Migrations
{
    public partial class DA1_862_QLPM_Karaoke_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UuDai3",
                table: "CongThucTinh",
                type: "float",
                nullable: true,
                defaultValueSql: "((0))",
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "CongThucTinh",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdtrangThai",
                table: "CongThucTinh",
                type: "int",
                nullable: true,
                defaultValueSql: "((1))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "CongThucTinh");

            migrationBuilder.DropColumn(
                name: "IdtrangThai",
                table: "CongThucTinh");

            migrationBuilder.AlterColumn<double>(
                name: "UuDai3",
                table: "CongThucTinh",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true,
                oldDefaultValueSql: "((0))");
        }
    }
}
