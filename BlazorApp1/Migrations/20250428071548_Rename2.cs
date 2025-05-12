using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class Rename2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentsEntity_usersEntity_userid",
                table: "commentsEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "usersEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationEntitiesEntity",
                table: "OperationEntitiesEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_comments",
                table: "commentsEntity");

            migrationBuilder.RenameTable(
                name: "usersEntity",
                newName: "UserEntities");

            migrationBuilder.RenameTable(
                name: "OperationEntitiesEntity",
                newName: "OperationEntities");

            migrationBuilder.RenameTable(
                name: "commentsEntity",
                newName: "CommentEntities");

            migrationBuilder.RenameIndex(
                name: "IX_commentsEntity_userid",
                table: "CommentEntities",
                newName: "IX_CommentEntities_userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationEntities",
                table: "OperationEntities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentEntities",
                table: "CommentEntities",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentEntities_UserEntities_userid",
                table: "CommentEntities",
                column: "userid",
                principalTable: "UserEntities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentEntities_UserEntities_userid",
                table: "CommentEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEntities",
                table: "UserEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationEntities",
                table: "OperationEntities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentEntities",
                table: "CommentEntities");

            migrationBuilder.RenameTable(
                name: "UserEntities",
                newName: "usersEntity");

            migrationBuilder.RenameTable(
                name: "OperationEntities",
                newName: "OperationEntitiesEntity");

            migrationBuilder.RenameTable(
                name: "CommentEntities",
                newName: "commentsEntity");

            migrationBuilder.RenameIndex(
                name: "IX_CommentEntities_userid",
                table: "commentsEntity",
                newName: "IX_commentsEntity_userid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "usersEntity",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationEntitiesEntity",
                table: "OperationEntitiesEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_comments",
                table: "commentsEntity",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_commentsEntity_usersEntity_userid",
                table: "commentsEntity",
                column: "userid",
                principalTable: "usersEntity",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
