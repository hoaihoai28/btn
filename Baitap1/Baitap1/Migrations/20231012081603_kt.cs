using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baitap1.Migrations
{
    /// <inheritdoc />
    public partial class kt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CuaHangs",
                columns: table => new
                {
                    id_cuahang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenCH = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuaHangs", x => x.id_cuahang);
                });

            migrationBuilder.CreateTable(
                name: "NamThangs",
                columns: table => new
                {
                    id_namthang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NLHD = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamThangs", x => x.id_namthang);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    id_nhanvien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admins = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.id_nhanvien);
                });

            migrationBuilder.CreateTable(
                name: "SanPhams",
                columns: table => new
                {
                    id_sanpham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiaBan = table.Column<int>(type: "int", nullable: false),
                    DienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhams", x => x.id_sanpham);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    id_phanquyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_nhanvien = table.Column<int>(type: "int", nullable: false),
                    id_cuahang = table.Column<int>(type: "int", nullable: false),
                    id_sanpham = table.Column<int>(type: "int", nullable: false),
                    id_namthang = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.id_phanquyen);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_CuaHangs_id_cuahang",
                        column: x => x.id_cuahang,
                        principalTable: "CuaHangs",
                        principalColumn: "id_cuahang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_NamThangs_id_namthang",
                        column: x => x.id_namthang,
                        principalTable: "NamThangs",
                        principalColumn: "id_namthang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_NhanViens_id_nhanvien",
                        column: x => x.id_nhanvien,
                        principalTable: "NhanViens",
                        principalColumn: "id_nhanvien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_SanPhams_id_sanpham",
                        column: x => x.id_sanpham,
                        principalTable: "SanPhams",
                        principalColumn: "id_sanpham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_cuahang",
                table: "PhanQuyens",
                column: "id_cuahang");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_namthang",
                table: "PhanQuyens",
                column: "id_namthang");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_nhanvien",
                table: "PhanQuyens",
                column: "id_nhanvien");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_sanpham",
                table: "PhanQuyens",
                column: "id_sanpham");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "CuaHangs");

            migrationBuilder.DropTable(
                name: "NamThangs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "SanPhams");
        }
    }
}
