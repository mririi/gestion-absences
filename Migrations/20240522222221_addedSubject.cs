using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionAbscences.Migrations
{
    /// <inheritdoc />
    public partial class addedSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Absences_SubjectId",
                table: "Absences",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Subjects_SubjectId",
                table: "Absences",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Subjects_SubjectId",
                table: "Absences");

            migrationBuilder.DropIndex(
                name: "IX_Absences_SubjectId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Absences");
        }
    }
}
