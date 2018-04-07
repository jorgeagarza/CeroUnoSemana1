using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace D3E1.Migrations
{
    public partial class NewColumnInTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "Todos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "Todos");
        }
    }
}
