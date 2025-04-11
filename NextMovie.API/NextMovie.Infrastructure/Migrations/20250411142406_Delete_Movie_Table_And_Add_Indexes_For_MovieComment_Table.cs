using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextMovie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Movie_Table_And_Add_Indexes_For_MovieComment_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "MovieComments");

            migrationBuilder.AddColumn<string>(
                name: "TmdbMovieId",
                table: "MovieComments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_TmdbMovieId",
                table: "MovieComments",
                column: "TmdbMovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieComments_TmdbMovieId",
                table: "MovieComments");

            migrationBuilder.DropColumn(
                name: "TmdbMovieId",
                table: "MovieComments");

            migrationBuilder.AddColumn<Guid>(
                name: "MovieId",
                table: "MovieComments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieDbId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieComments_MovieId",
                table: "MovieComments",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieDbId",
                table: "Movies",
                column: "MovieDbId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieComments_Movies_MovieId",
                table: "MovieComments",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
