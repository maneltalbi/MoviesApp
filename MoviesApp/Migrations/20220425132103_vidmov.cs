using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class vidmov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Movies_MoviesidMovie",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_parts_Collections_CollectionsidCol",
                table: "parts");

            migrationBuilder.DropIndex(
                name: "IX_parts_CollectionsidCol",
                table: "parts");

            migrationBuilder.DropIndex(
                name: "IX_Collections_MoviesidMovie",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "CollectionsidCol",
                table: "parts");

            migrationBuilder.DropColumn(
                name: "MoviesidMovie",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "overview",
                table: "Collections");

            migrationBuilder.CreateTable(
                name: "VideosMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    idVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideosMovies", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideosMovies");

            migrationBuilder.AddColumn<int>(
                name: "CollectionsidCol",
                table: "parts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoviesidMovie",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "overview",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parts_CollectionsidCol",
                table: "parts",
                column: "CollectionsidCol");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_MoviesidMovie",
                table: "Collections",
                column: "MoviesidMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Movies_MoviesidMovie",
                table: "Collections",
                column: "MoviesidMovie",
                principalTable: "Movies",
                principalColumn: "idMovie",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_parts_Collections_CollectionsidCol",
                table: "parts",
                column: "CollectionsidCol",
                principalTable: "Collections",
                principalColumn: "idCol",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
