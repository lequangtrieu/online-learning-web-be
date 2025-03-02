using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceColumnToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72b92128-327e-4a19-a4ba-a5f287f61c42", "3250c9e3-9d63-4edf-b2d9-f390d5247832" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c87182d9-774b-4eaa-8625-edc7a94d0293", "e3b079e2-4f6e-4bec-bd56-07c86624061c" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1,
                columns: new[] { "CreateDate", "Price" },
                values: new object[] { new DateOnly(2025, 2, 18), 0 });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                columns: new[] { "CreateDate", "Price" },
                values: new object[] { new DateOnly(2025, 1, 19), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Course");

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
                column: "CreateDate",
                value: new DateOnly(2025, 1, 15));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateOnly(2024, 12, 16));
        }
    }
}
