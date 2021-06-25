using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication16.Migrations
{
    public partial class sehend1907 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apples",
                columns: table => new
                {
                    AppleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppleAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apples", x => x.AppleId);
                });

            migrationBuilder.CreateTable(
                name: "Oppos",
                columns: table => new
                {
                    OppoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OppoAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oppos", x => x.OppoId);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelAdres = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelId);
                });

            migrationBuilder.CreateTable(
                name: "Samsungs",
                columns: table => new
                {
                    SamsungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamsungAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamsungFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samsungs", x => x.SamsungId);
                });

            migrationBuilder.CreateTable(
                name: "Xiaomis",
                columns: table => new
                {
                    XiaomiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XiaomiAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xiaomis", x => x.XiaomiId);
                });

            migrationBuilder.CreateTable(
                name: "Urunlers",
                columns: table => new
                {
                    UrunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OppoId = table.Column<int>(type: "int", nullable: true),
                    AppleId = table.Column<int>(type: "int", nullable: true),
                    SamsungId = table.Column<int>(type: "int", nullable: true),
                    XiaomiId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urunlers", x => x.UrunId);
                    table.ForeignKey(
                        name: "FK_Urunlers_Apples_AppleId",
                        column: x => x.AppleId,
                        principalTable: "Apples",
                        principalColumn: "AppleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urunlers_Oppos_OppoId",
                        column: x => x.OppoId,
                        principalTable: "Oppos",
                        principalColumn: "OppoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urunlers_Samsungs_SamsungId",
                        column: x => x.SamsungId,
                        principalTable: "Samsungs",
                        principalColumn: "SamsungId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urunlers_Xiaomis_XiaomiId",
                        column: x => x.XiaomiId,
                        principalTable: "Xiaomis",
                        principalColumn: "XiaomiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mudurs",
                columns: table => new
                {
                    MudurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MudurAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MudurSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MudurEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MudurAdres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelTc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    PersonelTcNavigationPersonelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mudurs", x => x.MudurId);
                    table.ForeignKey(
                        name: "FK_Mudurs_Personels_PersonelTcNavigationPersonelId",
                        column: x => x.PersonelTcNavigationPersonelId,
                        principalTable: "Personels",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mudurs_Urunlers_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urunlers",
                        principalColumn: "UrunId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mudurs_PersonelTcNavigationPersonelId",
                table: "Mudurs",
                column: "PersonelTcNavigationPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Mudurs_UrunId",
                table: "Mudurs",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_AppleId",
                table: "Urunlers",
                column: "AppleId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_OppoId",
                table: "Urunlers",
                column: "OppoId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_SamsungId",
                table: "Urunlers",
                column: "SamsungId");

            migrationBuilder.CreateIndex(
                name: "IX_Urunlers_XiaomiId",
                table: "Urunlers",
                column: "XiaomiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mudurs");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Urunlers");

            migrationBuilder.DropTable(
                name: "Apples");

            migrationBuilder.DropTable(
                name: "Oppos");

            migrationBuilder.DropTable(
                name: "Samsungs");

            migrationBuilder.DropTable(
                name: "Xiaomis");
        }
    }
}
