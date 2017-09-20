using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SOF.Data.Migrations
{
    public partial class votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "noVote",
                table: "Questions",
                type: "int4",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "yesVote",
                table: "Questions",
                type: "int4",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "noVote",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "yesVote",
                table: "Questions");
        }
    }
}
