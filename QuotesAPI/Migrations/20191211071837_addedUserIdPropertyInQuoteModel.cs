using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotesAPI.Migrations
{
    public partial class addedUserIdPropertyInQuoteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Quotes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Quotes");
        }
    }
}
