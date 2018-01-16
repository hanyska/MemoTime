using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MemoTime.Api.Migrations
{
    public partial class Next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Tasks",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<bool>(
                name: "Done",
                table: "Tasks",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Done",
                table: "Tasks");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Tasks",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
