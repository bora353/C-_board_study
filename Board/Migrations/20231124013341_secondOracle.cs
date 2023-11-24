using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Migrations
{
    /// <inheritdoc />
    public partial class secondOracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board123s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Subject = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Writer = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RegDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReadCount = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GroupNo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrinitNo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrintLevel = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board123s", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Board123s");
        }
    }
}
