using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryingLINQ.Migrations
{
    public partial class PopulateCourseTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumns: new[] { "CourseId", "TagId" },
                keyValues: new object[] { 9, 3 });
        }
    }
}
