using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MemoTime.Api.Migrations
{
    public partial class labelspropintask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "Tasks");

            migrationBuilder.AddColumn<Guid>(
                name: "LabelId",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LabelId",
                table: "Tasks",
                column: "LabelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_LabelId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "Tasks",
                nullable: true);
        }
    }
}
