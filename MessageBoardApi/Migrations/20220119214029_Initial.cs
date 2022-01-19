using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageBoardApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(type: "varchar(100) CHARACTER SET utf8mb4", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    Content = table.Column<string>(type: "varchar(250) CHARACTER SET utf8mb4", maxLength: 250, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupId", "GroupName" },
                values: new object[] { 1, "Group1! We did it! Amazing work!" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "DatePosted", "GroupId", "UserName" },
                values: new object[,]
                {
                    { 1, "content1", new DateTime(2022, 1, 18, 12, 0, 0, 0, DateTimeKind.Unspecified), 1, "user1" },
                    { 2, "content2", new DateTime(2021, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "user2" },
                    { 3, "content3", new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "user3" },
                    { 4, "content3", new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "user3" },
                    { 5, "content3", new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "user3" },
                    { 6, "content3", new DateTime(2020, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), 1, "user3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Messages");
        }
    }
}
