using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaPackageSystem.Migrations
{
    /// <inheritdoc />
    public partial class createRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages",
                column: "AssignedElfId",
                principalTable: "Elves",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages",
                column: "AssignedElfId",
                principalTable: "Elves",
                principalColumn: "Id");
        }
    }
}
