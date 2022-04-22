using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class addvideosseasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonsidSeason",
                table: "GuestStars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeasonsidSeason",
                table: "Crew",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestStars_SeasonsidSeason",
                table: "GuestStars",
                column: "SeasonsidSeason");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_SeasonsidSeason",
                table: "Crew",
                column: "SeasonsidSeason");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Seasons_SeasonsidSeason",
                table: "Crew",
                column: "SeasonsidSeason",
                principalTable: "Seasons",
                principalColumn: "idSeason",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestStars_Seasons_SeasonsidSeason",
                table: "GuestStars",
                column: "SeasonsidSeason",
                principalTable: "Seasons",
                principalColumn: "idSeason",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Seasons_SeasonsidSeason",
                table: "Crew");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestStars_Seasons_SeasonsidSeason",
                table: "GuestStars");

            migrationBuilder.DropIndex(
                name: "IX_GuestStars_SeasonsidSeason",
                table: "GuestStars");

            migrationBuilder.DropIndex(
                name: "IX_Crew_SeasonsidSeason",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "SeasonsidSeason",
                table: "GuestStars");

            migrationBuilder.DropColumn(
                name: "SeasonsidSeason",
                table: "Crew");
        }
    }
}
