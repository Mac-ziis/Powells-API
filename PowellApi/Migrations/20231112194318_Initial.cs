using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowellApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Summary", "Title" },
                values: new object[] { 1, "Fred Jumpturd", "Summary1Summary1Summary1Summary1Summary1Summary1", "Linux For Dummies" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Summary", "Title" },
                values: new object[] { 2, null, "Summary2Summary2Summary2Summary2Summary2", "Api for Dummies" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Summary", "Title" },
                values: new object[] { 3, null, "Summary3Summary3Summary3Summary3Summary3", "C# for Dummies" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
