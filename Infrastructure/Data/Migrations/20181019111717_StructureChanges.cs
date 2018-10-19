using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore.BestPractices.Infrastructure.Data.Migrations
{
    public partial class StructureChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Blogs");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Blogs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Name_AuthorId",
                table: "Blogs",
                column: "AuthorId",
                principalTable: "Name",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Name_AuthorId",
                table: "Blogs");

            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_AuthorId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Blogs");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Blogs",
                nullable: true);
        }
    }
}
