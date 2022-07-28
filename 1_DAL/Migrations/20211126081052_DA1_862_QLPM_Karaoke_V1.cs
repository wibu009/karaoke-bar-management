using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _1_DAL.Migrations
{
    public partial class DA1_862_QLPM_Karaoke_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucVu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDTrangThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucVu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CongThucTinh",
                columns: table => new
                {
                    IDCongThucTinh = table.Column<int>(type: "int", nullable: false),
                    UuDai1 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    UuDai2 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    UuDai3 = table.Column<double>(type: "float", nullable: true),
                    ThoiGianNhanUuDai1 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    ThoiGianNhanUuDai2 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    ThoiGianNhanUuDai3 = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongThucTinh", x => x.IDCongThucTinh);
                });

            migrationBuilder.CreateTable(
                name: "DonViTinh",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenDVT = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonViTinh", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaKH = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenLoaiPhong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhong", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThietBi",
                columns: table => new
                {
                    MaLoaiTB = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    XuatXu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThietBi", x => x.MaLoaiTB);
                });

            migrationBuilder.CreateTable(
                name: "NhaCungCap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenNCC = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCungCap", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tang",
                columns: table => new
                {
                    IDTang = table.Column<int>(type: "int", nullable: false),
                    TenTang = table.Column<string>(type: "nchar(40)", fixedLength: true, maxLength: 40, nullable: true),
                    SoLuongPhong = table.Column<int>(type: "int", nullable: true),
                    IDTrangThai = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tang", x => x.IDTang);
                });

            migrationBuilder.CreateTable(
                name: "NhanVien",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Username = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    IDChucVu = table.Column<int>(type: "int", nullable: true),
                    Ho = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TenDem = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    GioiTinh = table.Column<int>(type: "int", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVien", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NhanVien_ChucVu",
                        column: x => x.IDChucVu,
                        principalTable: "ChucVu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatHang",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TenMatHang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IDDonViTinh = table.Column<int>(type: "int", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatHang", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MatHang_DonViTinh",
                        column: x => x.IDDonViTinh,
                        principalTable: "DonViTinh",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThietBi",
                columns: table => new
                {
                    MaTB = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    IDMaLoaiTB = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    TenTB = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TinhTrang = table.Column<int>(type: "int", nullable: true),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThietBi", x => x.MaTB);
                    table.ForeignKey(
                        name: "FK_ThietBi_LoaiThietBi",
                        column: x => x.IDMaLoaiTB,
                        principalTable: "LoaiThietBi",
                        principalColumn: "MaLoaiTB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    IDTang = table.Column<int>(type: "int", nullable: true),
                    IDLoaiPhong = table.Column<int>(type: "int", nullable: true),
                    TenPhong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true, defaultValueSql: "((1))"),
                    SucChua = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Phong_LoaiPhong",
                        column: x => x.IDLoaiPhong,
                        principalTable: "LoaiPhong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Phong_Tang",
                        column: x => x.IDTang,
                        principalTable: "Tang",
                        principalColumn: "IDTang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonNhap",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    IDNhanVienNhap = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    IDNhaCC = table.Column<int>(type: "int", nullable: true),
                    NgayNhap = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    TienThanhToan = table.Column<double>(type: "float", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonNhap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HoaDonNhap_NhaCungCap1",
                        column: x => x.IDNhaCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonNhap_NhanVien",
                        column: x => x.IDNhanVienNhap,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietThietBi",
                columns: table => new
                {
                    IDChiTietThietBi = table.Column<int>(type: "int", nullable: false),
                    IDPhong = table.Column<int>(type: "int", nullable: false),
                    IDMaTB = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietThietBi", x => x.IDChiTietThietBi);
                    table.ForeignKey(
                        name: "FK_ChiTietThietBi_Phong",
                        column: x => x.IDPhong,
                        principalTable: "Phong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietThietBi_ThietBi",
                        column: x => x.IDMaTB,
                        principalTable: "ThietBi",
                        principalColumn: "MaTB",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonBanHang",
                columns: table => new
                {
                    IDHoaDon = table.Column<int>(type: "int", nullable: false),
                    IDMaKH = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    IDPhong = table.Column<int>(type: "int", nullable: true),
                    IDMaNV = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    IDCongThucTinh = table.Column<int>(type: "int", nullable: true),
                    ThoiGianBatDau = table.Column<DateTime>(type: "datetime", nullable: true),
                    ThoiGianKetThuc = table.Column<DateTime>(type: "datetime", nullable: true),
                    DonGiaPhong = table.Column<double>(type: "float", nullable: true),
                    NguoiBan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayCapNhap = table.Column<DateTime>(type: "datetime", nullable: true),
                    NguoiCapNhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IDTranngThai = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonBanHang", x => x.IDHoaDon);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_CongThucTinh",
                        column: x => x.IDCongThucTinh,
                        principalTable: "CongThucTinh",
                        principalColumn: "IDCongThucTinh",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_KhachHang",
                        column: x => x.IDMaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_NhanVien",
                        column: x => x.IDMaNV,
                        principalTable: "NhanVien",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDonBanHang_Phong",
                        column: x => x.IDPhong,
                        principalTable: "Phong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDonNhap",
                columns: table => new
                {
                    IDChiTietHoaDonNhap = table.Column<int>(type: "int", nullable: false),
                    IDHoaDon = table.Column<int>(type: "int", nullable: false),
                    IDMatHang = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGiaNhap = table.Column<double>(type: "float", nullable: true),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDonNhap", x => x.IDChiTietHoaDonNhap);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonNhap_HoaDonNhap",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDonNhap",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonNhap_MatHang1",
                        column: x => x.IDMatHang,
                        principalTable: "MatHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDonBan",
                columns: table => new
                {
                    IDChiTietHoaDonBan = table.Column<int>(type: "int", nullable: false),
                    IDHoaDon = table.Column<int>(type: "int", nullable: false),
                    IDMatHang = table.Column<int>(type: "int", nullable: false),
                    IDUsername = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    IDTranngThai = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDonBan", x => x.IDChiTietHoaDonBan);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonBan_HoaDonBanHang",
                        column: x => x.IDHoaDon,
                        principalTable: "HoaDonBanHang",
                        principalColumn: "IDHoaDon",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDonBan_MatHang",
                        column: x => x.IDMatHang,
                        principalTable: "MatHang",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonBan_IDHoaDon",
                table: "ChiTietHoaDonBan",
                column: "IDHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonBan_IDMatHang",
                table: "ChiTietHoaDonBan",
                column: "IDMatHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonNhap_IDHoaDon",
                table: "ChiTietHoaDonNhap",
                column: "IDHoaDon");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDonNhap_IDMatHang",
                table: "ChiTietHoaDonNhap",
                column: "IDMatHang");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThietBi_IDMaTB",
                table: "ChiTietThietBi",
                column: "IDMaTB");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietThietBi_IDPhong",
                table: "ChiTietThietBi",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_IDCongThucTinh",
                table: "HoaDonBanHang",
                column: "IDCongThucTinh");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_IDMaKH",
                table: "HoaDonBanHang",
                column: "IDMaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_IDMaNV",
                table: "HoaDonBanHang",
                column: "IDMaNV");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonBanHang_IDPhong",
                table: "HoaDonBanHang",
                column: "IDPhong");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonNhap_IDNhaCC",
                table: "HoaDonNhap",
                column: "IDNhaCC");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonNhap_IDNhanVienNhap",
                table: "HoaDonNhap",
                column: "IDNhanVienNhap");

            migrationBuilder.CreateIndex(
                name: "IX_MatHang_IDDonViTinh",
                table: "MatHang",
                column: "IDDonViTinh");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVien_IDChucVu",
                table: "NhanVien",
                column: "IDChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_IDLoaiPhong",
                table: "Phong",
                column: "IDLoaiPhong");

            migrationBuilder.CreateIndex(
                name: "IX_Phong_IDTang",
                table: "Phong",
                column: "IDTang");

            migrationBuilder.CreateIndex(
                name: "IX_ThietBi_IDMaLoaiTB",
                table: "ThietBi",
                column: "IDMaLoaiTB");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDonBan");

            migrationBuilder.DropTable(
                name: "ChiTietHoaDonNhap");

            migrationBuilder.DropTable(
                name: "ChiTietThietBi");

            migrationBuilder.DropTable(
                name: "HoaDonBanHang");

            migrationBuilder.DropTable(
                name: "HoaDonNhap");

            migrationBuilder.DropTable(
                name: "MatHang");

            migrationBuilder.DropTable(
                name: "ThietBi");

            migrationBuilder.DropTable(
                name: "CongThucTinh");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "Phong");

            migrationBuilder.DropTable(
                name: "NhaCungCap");

            migrationBuilder.DropTable(
                name: "NhanVien");

            migrationBuilder.DropTable(
                name: "DonViTinh");

            migrationBuilder.DropTable(
                name: "LoaiThietBi");

            migrationBuilder.DropTable(
                name: "LoaiPhong");

            migrationBuilder.DropTable(
                name: "Tang");

            migrationBuilder.DropTable(
                name: "ChucVu");
        }
    }
}
