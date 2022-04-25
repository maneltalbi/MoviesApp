using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class @for : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idCol",
                table: "parts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idMovie",
                table: "Collections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_parts_idCol",
                table: "parts",
                column: "idCol");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_idMovie",
                table: "Collections",
                column: "idMovie");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Episodes_idMovie",
                table: "Collections",
                column: "idMovie",
                principalTable: "Episodes",
                principalColumn: "idEpisode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_parts_Episodes_idCol",
                table: "parts",
                column: "idCol",
                principalTable: "Episodes",
                principalColumn: "idEpisode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Episodes_idMovie",
                table: "Collections");

            migrationBuilder.DropForeignKey(
                name: "FK_parts_Episodes_idCol",
                table: "parts");

            migrationBuilder.DropIndex(
                name: "IX_parts_idCol",
                table: "parts");

            migrationBuilder.DropIndex(
                name: "IX_Collections_idMovie",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "idCol",
                table: "parts");

            migrationBuilder.DropColumn(
                name: "idMovie",
                table: "Collections");
        }
    }
}
