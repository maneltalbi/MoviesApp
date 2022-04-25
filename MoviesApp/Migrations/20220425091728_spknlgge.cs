using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class spknlgge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idSpokenlgg",
                table: "SpokenLggSeries");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Productioncountries");

            migrationBuilder.AddColumn<string>(
                name: "Spokenlgg",
                table: "SpokenLggSeries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProdCountrie",
                table: "ProdCountrieSeries",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spokenlgg",
                table: "SpokenLggSeries");

            migrationBuilder.AddColumn<int>(
                name: "idSpokenlgg",
                table: "SpokenLggSeries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProdCountrie",
                table: "ProdCountrieSeries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
