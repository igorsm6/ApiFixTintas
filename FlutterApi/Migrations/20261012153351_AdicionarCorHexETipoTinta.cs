using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlutterApi.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCorHexETipoTinta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CorHex",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoTinta",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorHex",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TipoTinta",
                table: "Produtos");
        }
    }
}
