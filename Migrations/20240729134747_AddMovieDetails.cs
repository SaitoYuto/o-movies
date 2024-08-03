using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMovies.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movie",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCast",
                table: "Movie",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterImageUrl",
                table: "Movie",
                type: "TEXT",
                maxLength: 2083,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Movie",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MainCast",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "PosterImageUrl",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Movie");
        }
    }
}
