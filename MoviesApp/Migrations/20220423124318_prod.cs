using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class prod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productioncountries",
                table: "Productioncountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionCompanies",
                table: "ProductionCompanies");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idProdCountry",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idProdCompany",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productioncountries",
                table: "Productioncountries",
                column: "idProdCountry");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionCompanies",
                table: "ProductionCompanies",
                column: "idProdCompany");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Productioncountries",
                table: "Productioncountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductionCompanies",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "idProdCountry",
                table: "Productioncountries");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idProdCompany",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productioncountries",
                table: "Productioncountries",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductionCompanies",
                table: "ProductionCompanies",
                column: "id");
        }
    }
}
