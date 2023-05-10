using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace restapi.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "cityID",
                table: "PointOfInterests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInterests_cityID",
                table: "PointOfInterests",
                column: "cityID");

            migrationBuilder.AddForeignKey(
                name: "FK_PointOfInterests_Cities_cityID",
                table: "PointOfInterests",
                column: "cityID",
                principalTable: "Cities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointOfInterests_Cities_cityID",
                table: "PointOfInterests");

            migrationBuilder.DropIndex(
                name: "IX_PointOfInterests_cityID",
                table: "PointOfInterests");

            migrationBuilder.DropColumn(
                name: "cityID",
                table: "PointOfInterests");
        }
    }
}
