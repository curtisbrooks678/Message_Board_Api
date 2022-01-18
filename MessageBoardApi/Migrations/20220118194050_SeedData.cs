using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoardApi.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "Messages",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DatePosted", "Group", "UserName" },
                values: new object[] { 1, "content1", new DateTime(2022, 1, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), "Group1", "user1" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DatePosted", "Group", "UserName" },
                values: new object[] { 2, "content2", new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), "Group2", "user2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Group",
                table: "Messages");
        }
    }
}
