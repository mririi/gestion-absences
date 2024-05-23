using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscences.Migrations
{
    /// <inheritdoc />
    public partial class MakeGroupIdNullableSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "GroupSubjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "GroupSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupSubjects_Groups_GroupId",
                table: "GroupSubjects",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
