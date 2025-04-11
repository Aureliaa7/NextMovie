using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextMovie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovieComments_Table_Update_Movie_Column_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TmdbMovieId",
                table: "MovieComments",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TmdbMovieId",
                table: "MovieComments",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
