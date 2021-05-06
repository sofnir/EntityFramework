using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentAPI.Migrations
{
    public partial class RenameCourseTagForeginKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Courses_CoursesId",
                table: "CourseTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Tags_TagsId",
                table: "CourseTag");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "CourseTag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseTag",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTag_TagsId",
                table: "CourseTag",
                newName: "IX_CourseTag_TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTag_Courses_CourseId",
                table: "CourseTag",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTag_Tags_TagId",
                table: "CourseTag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Courses_CourseId",
                table: "CourseTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Tags_TagId",
                table: "CourseTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "CourseTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseTag",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTag_TagId",
                table: "CourseTag",
                newName: "IX_CourseTag_TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTag_Courses_CoursesId",
                table: "CourseTag",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTag_Tags_TagsId",
                table: "CourseTag",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
