using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MemoTime.Api.Migrations
{
    public partial class tasks_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Projects_ProjectId",
                table: "TodoTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask");

            migrationBuilder.RenameTable(
                name: "TodoTask",
                newName: "Tasks");

            migrationBuilder.RenameIndex(
                name: "IX_TodoTask_ProjectId",
                table: "Tasks",
                newName: "IX_Tasks_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tasks",
                table: "Tasks");

            migrationBuilder.RenameTable(
                name: "Tasks",
                newName: "TodoTask");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_ProjectId",
                table: "TodoTask",
                newName: "IX_TodoTask_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoTask",
                table: "TodoTask",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Projects_ProjectId",
                table: "TodoTask",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
