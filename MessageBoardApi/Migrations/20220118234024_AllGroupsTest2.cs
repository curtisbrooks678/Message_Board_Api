using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoardApi.Migrations
{
    public partial class AllGroupsTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DatePosted", "Group", "UserName" },
                values: new object[] { 3, "content3", new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), "Zeta", "user3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);
        }
    }
}
