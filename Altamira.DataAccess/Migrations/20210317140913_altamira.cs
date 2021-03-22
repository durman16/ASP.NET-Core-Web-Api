using Microsoft.EntityFrameworkCore.Migrations;

namespace Altamira.DataAccess.Migrations
{
    public partial class altamira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    companyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    catchPhrase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.companyid);
                });

            migrationBuilder.CreateTable(
                name: "geos",
                columns: table => new
                {
                    geoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_geos", x => x.geoid);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    addressid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    suite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    geoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.addressid);
                    table.ForeignKey(
                        name: "FK_Addresses_geos_geoid",
                        column: x => x.geoid,
                        principalTable: "geos",
                        principalColumn: "geoid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyid = table.Column<int>(type: "int", nullable: true),
                    addressid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Addresses_addressid",
                        column: x => x.addressid,
                        principalTable: "Addresses",
                        principalColumn: "addressid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Companies_companyid",
                        column: x => x.companyid,
                        principalTable: "Companies",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_geoid",
                table: "Addresses",
                column: "geoid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_addressid",
                table: "Users",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_companyid",
                table: "Users",
                column: "companyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "geos");
        }
    }
}
