using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MemoTime.Api.Migrations
{
    public partial class tasklabelrelationsup1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Labels_LabelId",
                table: "Tasks",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
