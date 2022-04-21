using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class changement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Createurs_Series_Seriesid",
                table: "Createurs");

            migrationBuilder.DropForeignKey(
                name: "FK_LastEpisodeToAir_Series_idSerie",
                table: "LastEpisodeToAir");

            migrationBuilder.DropForeignKey(
                name: "FK_Networks_Series_idSerie",
                table: "Networks");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_idSerie",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Networks",
                table: "Networks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Createurs",
                table: "Createurs");

            migrationBuilder.DropColumn(
                name: "genres",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "idNetwork",
                table: "Networks",
                newName: "idNet");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "idVideo",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idSerie",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Networks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idNet",
                table: "Networks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "LastEpisodeToAir",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "overview",
                table: "LastEpisodeToAir",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "production_code",
                table: "LastEpisodeToAir",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "still_path",
                table: "LastEpisodeToAir",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "vote_average",
                table: "LastEpisodeToAir",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "vote_count",
                table: "LastEpisodeToAir",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "idImage",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idgenre",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "credit_id",
                table: "Createurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Seriesid",
                table: "Createurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Createurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "idCreateur",
                table: "Createurs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "idVideo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "idSerie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Networks",
                table: "Networks",
                column: "idNet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "idgenre");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Createurs",
                table: "Createurs",
                column: "idCreateur");

            migrationBuilder.AddForeignKey(
                name: "FK_Createurs_Series_Seriesid",
                table: "Createurs",
                column: "Seriesid",
                principalTable: "Series",
                principalColumn: "idSerie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LastEpisodeToAir_Series_idSerie",
                table: "LastEpisodeToAir",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "idSerie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Networks_Series_idSerie",
                table: "Networks",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "idSerie",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_idSerie",
                table: "Seasons",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "idSerie",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Createurs_Series_Seriesid",
                table: "Createurs");

            migrationBuilder.DropForeignKey(
                name: "FK_LastEpisodeToAir_Series_idSerie",
                table: "LastEpisodeToAir");

            migrationBuilder.DropForeignKey(
                name: "FK_Networks_Series_idSerie",
                table: "Networks");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Series_idSerie",
                table: "Seasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Videos",
                table: "Videos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Series",
                table: "Series");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Networks",
                table: "Networks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Createurs",
                table: "Createurs");

            migrationBuilder.DropColumn(
                name: "idVideo",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "name",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "overview",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "production_code",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "still_path",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "vote_average",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "vote_count",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "idgenre",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "idCreateur",
                table: "Createurs");

            migrationBuilder.RenameColumn(
                name: "idNet",
                table: "Networks",
                newName: "idNetwork");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "Videos",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idSerie",
                table: "Series",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "genres",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Networks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idNetwork",
                table: "Networks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "idImage",
                table: "Images",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Createurs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "credit_id",
                table: "Createurs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Seriesid",
                table: "Createurs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Videos",
                table: "Videos",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Series",
                table: "Series",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Networks",
                table: "Networks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "idImage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Createurs",
                table: "Createurs",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Createurs_Series_Seriesid",
                table: "Createurs",
                column: "Seriesid",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LastEpisodeToAir_Series_idSerie",
                table: "LastEpisodeToAir",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Networks_Series_idSerie",
                table: "Networks",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Series_idSerie",
                table: "Seasons",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
