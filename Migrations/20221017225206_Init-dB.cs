using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductManager.Migrations
{
    public partial class InitdB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeNew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeNewName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNew", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    TypeNewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_TypeNew_TypeNewId",
                        column: x => x.TypeNewId,
                        principalTable: "TypeNew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_TypeNewId",
                table: "News",
                column: "TypeNewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "TypeNew");
        }
    }
}
