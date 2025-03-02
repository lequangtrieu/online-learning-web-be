using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update_Entity_Course : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1ec2dcea-def0-4f27-bb17-dddfece4c286", "4df53dc4-c1ae-4ee7-9a8a-f7d0008dca09" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d15ec93b-0f8c-49db-941a-6c0092bb0990", "aecdcf98-a227-4d37-a081-91eb6a738f3b" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1,
                columns: new[] { "CreateDate", "Status" },
                values: new object[] { new DateOnly(2025, 1, 15), 0 });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                columns: new[] { "CreateDate", "Status" },
                values: new object[] { new DateOnly(2024, 12, 16), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Course");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a651ba2-c82f-43e5-b08c-99e8306656c3", "e46fe438-b72a-4b8e-8798-2e151565e928" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f5992082-8499-4d3d-bbf5-026abd54b117", "54990a8a-efad-4343-94c1-19de858e28b3" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateOnly(2025, 1, 14));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateOnly(2024, 12, 15));
        }
    }
}
