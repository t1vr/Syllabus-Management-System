using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AppUserProfiles_Renamed_To_AppUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_AppUserProfiles_AppUserId",
                schema: "Portal",
                table: "CourseUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserProfiles",
                schema: "Portal",
                table: "AppUserProfiles");

            migrationBuilder.RenameTable(
                name: "AppUserProfiles",
                schema: "Portal",
                newName: "AppUsers",
                newSchema: "Portal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUsers",
                schema: "Portal",
                table: "AppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_AppUsers_AppUserId",
                schema: "Portal",
                table: "CourseUsers",
                column: "AppUserId",
                principalSchema: "Portal",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_AppUsers_AppUserId",
                schema: "Portal",
                table: "CourseUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUsers",
                schema: "Portal",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "AppUsers",
                schema: "Portal",
                newName: "AppUserProfiles",
                newSchema: "Portal");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserProfiles",
                schema: "Portal",
                table: "AppUserProfiles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_AppUserProfiles_AppUserId",
                schema: "Portal",
                table: "CourseUsers",
                column: "AppUserId",
                principalSchema: "Portal",
                principalTable: "AppUserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
