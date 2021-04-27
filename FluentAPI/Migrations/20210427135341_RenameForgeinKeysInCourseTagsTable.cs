using Microsoft.EntityFrameworkCore.Migrations;

namespace FluentAPI.Migrations
{
    public partial class RenameForgeinKeysInCourseTagsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Courses_CoursesId",
                table: "CourseTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Tags_TagsId",
                table: "CourseTags");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "CourseTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseTags",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTags_TagsId",
                table: "CourseTags",
                newName: "IX_CourseTags_TagId");

            migrationBuilder.CreateTable(
                name: "CourseTag",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTag", x => new { x.CoursesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CourseTag_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTag_TagsId",
                table: "CourseTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTags_Courses_CourseId",
                table: "CourseTags",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseTags_Tags_TagId",
                table: "CourseTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Courses_CourseId",
                table: "CourseTags");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseTags_Tags_TagId",
                table: "CourseTags");

            migrationBuilder.DropTable(
                name: "CourseTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "CourseTags",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseTags",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseTags_TagId",
                table: "CourseTags",
                newName: "IX_CourseTags_TagsId");

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
    }
}
