using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema_project.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "SubImg");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_MovieId",
                table: "Actors",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Movies_MovieId",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_MovieId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "SubImg",
                table: "Movies",
                newName: "Title");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
