using Microsoft.EntityFrameworkCore.Migrations;

namespace CacheEx.API.Migrations
{
    public partial class pessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pessoa",
                columns: new[] { "Id", "Idade", "Nome", "Sobrenome" },
                values: new object[,]
                {
                    { 1L, 32, "Leandro", "Cesar" },
                    { 2L, 67, "Silvio", "Cesar" },
                    { 3L, 50, "Luciana", "Santos" },
                    { 4L, 27, "Dayanne", "Santos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
