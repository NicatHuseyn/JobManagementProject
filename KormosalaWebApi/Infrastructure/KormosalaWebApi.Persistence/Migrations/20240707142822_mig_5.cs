﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KormosalaWebApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "UserMessage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserMessage",
                table: "Contacts",
                newName: "Message");
        }
    }
}
