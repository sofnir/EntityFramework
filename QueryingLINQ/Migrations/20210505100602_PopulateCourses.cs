using Microsoft.EntityFrameworkCore.Migrations;

namespace QueryingLINQ.Migrations
{
    public partial class PopulateCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "CoverId", "Description", "FullPrice", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, 0, "Description for C# Basics", 49f, 1, "C# Basics" },
                    { 2, 1, 0, "Description for C# Intermediate", 49f, 2, "C# Intermediate" },
                    { 3, 1, 0, "Description for C# Advanced", 69f, 3, "C# Advanced" },
                    { 4, 2, 0, "Description for Javascript", 149f, 2, "Javascript: Understanding the Weird Parts" },
                    { 5, 2, 0, "Description for AngularJS", 99f, 2, "Learn and Understand AngularJS" },
                    { 6, 2, 0, "Description for NodeJS", 149f, 2, "Learn and Understand NodeJS" },
                    { 7, 3, 0, "Description for Programming for Beginners", 45f, 1, "Programming for Complete Beginners" },
                    { 8, 4, 0, "Description 16 Hour Course", 150f, 1, "A 16 Hour C# Course with Visual Studio 2013" },
                    { 9, 4, 0, "Description Learn Javascript", 20f, 1, "Learn JavaScript Through Visual Studio 2013" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
