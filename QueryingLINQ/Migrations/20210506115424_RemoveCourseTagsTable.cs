using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryingLINQ.Migrations
{
    public partial class RemoveCourseTagsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseTags",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTags", x => new { x.CourseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_CourseTags_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseTags",
                columns: new[] { "CourseId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 2 },
                    { 6, 4 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_TagId",
                table: "CourseTags",
                column: "TagId");
        }
    }
}
