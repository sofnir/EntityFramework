using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentAPI.Migrations
{
    public partial class RenameTableCourseTagToCourseTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Courses_CoursesId",
                table: "CourseTag");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTag_Tags_TagsId",
                table: "CourseTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTag",
                table: "CourseTag");

            migrationBuilder.RenameTable(
                name: "CourseTag",
                newName: "CourseTags");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTag_TagsId",
                table: "CourseTags",
                newName: "IX_CourseTags_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTags",
                table: "CourseTags",
                columns: new[] { "CoursesId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTags_Courses_CoursesId",
                table: "CourseTags",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTags_Tags_TagsId",
                table: "CourseTags",
                column: "TagsId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Courses_CoursesId",
                table: "CourseTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Tags_TagsId",
                table: "CourseTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseTags",
                table: "CourseTags");

            migrationBuilder.RenameTable(
                name: "CourseTags",
                newName: "CourseTag");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTags_TagsId",
                table: "CourseTag",
                newName: "IX_CourseTag_TagsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseTag",
                table: "CourseTag",
                columns: new[] { "CoursesId", "TagsId" });

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
