using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmes.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FilmesDB");

            migrationBuilder.CreateTable(
                name: "Filmes_Auth",
                schema: "FilmesDB",
                columns: table => new
                {
                    auth_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    auth_username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    auth_password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes_Auth", x => x.auth_id);
                });

            migrationBuilder.CreateTable(
                name: "Filmes_Data",
                schema: "FilmesDB",
                columns: table => new
                {
                    filme_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filme_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    filme_description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filme_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    filme_minutes_duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes_Data", x => x.filme_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes_Auth",
                schema: "FilmesDB");

            migrationBuilder.DropTable(
                name: "Filmes_Data",
                schema: "FilmesDB");
        }
    }
}
