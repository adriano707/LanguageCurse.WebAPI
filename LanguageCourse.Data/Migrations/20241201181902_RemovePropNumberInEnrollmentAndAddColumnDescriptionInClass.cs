using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageCourse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePropNumberInEnrollmentAndAddColumnDescriptionInClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Enrollment");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Class",
                type: "varchar(250)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Class");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Enrollment",
                type: "varchar(250)",
                nullable: true);
        }
    }
}
