using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class RenameToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "comments",
                newName: "commentsEntity"
            );

            migrationBuilder.RenameTable(
                name: "users",
                newName: "usersEntity"
            );

            migrationBuilder.RenameIndex(
                name: "IX_comments_userid",
                table: "commentsEntity",
                newName: "IX_commentsEntity_userid"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_comments_users_userid",
                table: "commentsEntity"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_commentsEntity_usersEntity_userid",
                table: "commentsEntity",
                column: "userid",
                principalTable: "usersEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationEntities",
                table: "OperationEntities");

            migrationBuilder.RenameTable(
                name: "OperationEntities",
                newName: "OperationEntitiesEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationEntitiesEntity",
                table: "OperationEntitiesEntity",
                column: "Id");
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentsEntity_usersEntity_userid",
                table: "commentsEntity"
            );

            migrationBuilder.RenameIndex(
                name: "IX_commentsEntity_userid",
                table: "commentsEntity",
                newName: "IX_comments_userid"
            );

            migrationBuilder.RenameTable(
                name: "commentsEntity",
                newName: "comments"
            );

            migrationBuilder.RenameTable(
                name: "usersEntity",
                newName: "users"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_comments_users_userid",
                table: "comments",
                column: "userid",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationEntitiesEntity",
                table: "OperationEntitiesEntity");

            migrationBuilder.RenameTable(
                name: "OperationEntitiesEntity",
                newName: "OperationEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationEntities",
                table: "OperationEntities",
                column: "Id");
        }
    }
}
