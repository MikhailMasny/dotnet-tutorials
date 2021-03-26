using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Masny.DotNet.Crud.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "simple");

            migrationBuilder.CreateTable(
                name: "ParentModels",
                schema: "simple",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StringVar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildModels",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    IntVar = table.Column<int>(type: "int", nullable: false),
                    IntNullVar = table.Column<int>(type: "int", nullable: true),
                    DoubleVar = table.Column<double>(type: "float", nullable: false),
                    StringVar = table.Column<string>(type: "nvarchar(63)", maxLength: 63, nullable: false),
                    StringNullVar = table.Column<string>(type: "nvarchar(127)", maxLength: 127, nullable: true),
                    FloatVar = table.Column<float>(type: "real", nullable: false),
                    DecimalVar = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    CharVar = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    BoolVar = table.Column<bool>(type: "bit", nullable: false),
                    EnumType = table.Column<int>(type: "int", nullable: false),
                    DateVar = table.Column<DateTime>(type: "date", nullable: false),
                    DateTimeVar = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildModels_ParentModels_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "simple",
                        principalTable: "ParentModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildModels_ParentId",
                schema: "dbo",
                table: "ChildModels",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildModels",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ParentModels",
                schema: "simple");
        }
    }
}
