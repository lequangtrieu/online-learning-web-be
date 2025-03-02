using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_AccountId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_AccountId",
                table: "Profile");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Profile",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "60034531-9265-4184-8390-0dca2a54af7e", "f9fc37e0-a715-40da-b283-3f3f919909ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5200e7a6-8ffc-4dcd-b926-ca192b80570b", "ba179ee7-747e-4df9-9b82-8132aa58178f" });

            migrationBuilder.InsertData(
                table: "CourseCategory",
                columns: new[] { "categoryId", "name" },
                values: new object[,]
                {
                    { 1, "Artificial Intelligence" },
                    { 2, "Programming Languages" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "courseId", "categoryId", "CourseTitle", "CreateDate", "Description", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1, "Introduction to AI", new DateOnly(2025, 1, 1), "Learn the fundamentals of Artificial Intelligence.", "2" },
                    { 2, 2, "Advanced Python Programming", new DateOnly(2024, 12, 2), "Master Python with advanced concepts and libraries.", "2" }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollment",
                columns: new[] { "courseEnrollmentId", "accountId", "CourseId", "EnrollmentDate", "IsCompleted", "ProgressPercentage" },
                values: new object[,]
                {
                    { 1, "2", 1, null, null, null },
                    { 2, "2", 2, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "CourseTags",
                columns: new[] { "courseTagId", "courseId", "tagName" },
                values: new object[,]
                {
                    { 1, 1, "AI" },
                    { 2, 2, "Python" }
                });

            migrationBuilder.InsertData(
                table: "Feedback",
                columns: new[] { "feedbackId", "accountId", "CourseId", "FeedbackText", "Rating" },
                values: new object[,]
                {
                    { 1, "2", 1, "Great course on AI!", null },
                    { 2, "2", 2, "The Python content is very insightful!", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AccountId",
                table: "Profile",
                column: "AccountId",
                unique: true,
                filter: "[AccountId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_AccountId",
                table: "Profile",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profile_AspNetUsers_AccountId",
                table: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Profile_AccountId",
                table: "Profile");

            migrationBuilder.DeleteData(
                table: "CourseEnrollment",
                keyColumn: "courseEnrollmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseEnrollment",
                keyColumn: "courseEnrollmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumn: "courseTagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseTags",
                keyColumn: "courseTagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "feedbackId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Feedback",
                keyColumn: "feedbackId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CourseCategory",
                keyColumn: "categoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CourseCategory",
                keyColumn: "categoryId",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "Profile",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1efb2675-9d97-4add-9537-58d5d07726db", "0142b147-24a6-49a1-ae63-e5149c7f2898" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "0491f763-9e97-4f91-ab24-8af088fb3547", "05f4c63f-11d8-420c-8c4b-34efe1325535" });

            migrationBuilder.CreateIndex(
                name: "IX_Profile_AccountId",
                table: "Profile",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_AspNetUsers_AccountId",
                table: "Profile",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
