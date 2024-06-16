using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KormosalaWebApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Industries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Industries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
