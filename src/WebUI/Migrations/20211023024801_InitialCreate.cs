using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Synopsis = table.Column<string>(type: "TEXT", nullable: true),
                    YearPublished = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Media",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Media", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookMedium",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    MediumId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookMedium", x => new { x.BookId, x.MediumId });
                    table.ForeignKey(
                        name: "FK_BookMedium_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookMedium_Media_MediumId",
                        column: x => x.MediumId,
                        principalTable: "Media",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Synopsis", "Title", "YearPublished" },
                values: new object[] { 1, "Miguel de Cervantes Saavedra", "The ingenious gentleman Don Quixote of La Mancha", "Don Quixote - Part 1", 1605 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Synopsis", "Title", "YearPublished" },
                values: new object[] { 2, "Miguel de Cervantes Saavedra", "The ingenious gentleman Don Quixote of La Mancha", "Don Quixote - Part 1", 1615 });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Book" });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Audiobook" });

            migrationBuilder.InsertData(
                table: "Media",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Ebook" });

            migrationBuilder.CreateIndex(
                name: "IX_BookMedium_MediumId",
                table: "BookMedium",
                column: "MediumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookMedium");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Media");
        }
    }
}
