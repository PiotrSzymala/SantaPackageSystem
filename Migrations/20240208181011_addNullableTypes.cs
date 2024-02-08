using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SantaPackageSystem.Migrations
{
    /// <inheritdoc />
    public partial class addNullableTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedElfId",
                table: "Packages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages",
                column: "AssignedElfId",
                principalTable: "Elves",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages");

            migrationBuilder.AlterColumn<int>(
                name: "AssignedElfId",
                table: "Packages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Elves_AssignedElfId",
                table: "Packages",
                column: "AssignedElfId",
                principalTable: "Elves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
