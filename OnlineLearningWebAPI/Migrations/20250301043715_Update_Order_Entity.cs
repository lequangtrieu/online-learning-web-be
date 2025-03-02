using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearningWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update_Order_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "MOOC",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "46d4d14b-163d-40e4-99d5-5cedfc72bcbb", "3a9cf9be-2b9a-4ef1-9011-4c9fcd170dee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "52405696-6998-4e82-ae67-99731b9a7975", "eaad34c6-c7d3-46bf-aa7c-5a0adf6cff68" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateOnly(2025, 3, 1));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateOnly(2025, 1, 30));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderName",
                value: null);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderName",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "MOOC");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1a701e17-c589-4fc4-ba40-7083b7acf441", "b8255265-a4f0-41ef-9666-0f1a0c7ec4b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a71eeda-a74d-4ebe-9daa-a8d2639f991a", "6bae7ed8-7a1f-4339-8747-a7b464309b1c" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 1,
                column: "CreateDate",
                value: new DateOnly(2025, 2, 18));

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "courseId",
                keyValue: 2,
                column: "CreateDate",
                value: new DateOnly(2025, 1, 19));
        }
    }
}
