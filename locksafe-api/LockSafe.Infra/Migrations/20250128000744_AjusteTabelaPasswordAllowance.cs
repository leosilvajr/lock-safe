using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LockSafe.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaPasswordAllowance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordAllowances_Passwords_PasswordId1",
                table: "PasswordAllowances");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordAllowances_Users_UsersId",
                table: "PasswordAllowances");

            migrationBuilder.DropIndex(
                name: "IX_PasswordAllowances_PasswordId1",
                table: "PasswordAllowances");

            migrationBuilder.DropIndex(
                name: "IX_PasswordAllowances_UsersId",
                table: "PasswordAllowances");

            migrationBuilder.DropColumn(
                name: "PasswordId1",
                table: "PasswordAllowances");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "PasswordAllowances");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Passwords",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Passwords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<int>(
                name: "AssociatedPasswordId",
                table: "PasswordAllowances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AssociatedUserId",
                table: "PasswordAllowances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordAllowances_AssociatedPasswordId",
                table: "PasswordAllowances",
                column: "AssociatedPasswordId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordAllowances_AssociatedUserId",
                table: "PasswordAllowances",
                column: "AssociatedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordAllowances_Passwords_AssociatedPasswordId",
                table: "PasswordAllowances",
                column: "AssociatedPasswordId",
                principalTable: "Passwords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordAllowances_Users_AssociatedUserId",
                table: "PasswordAllowances",
                column: "AssociatedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PasswordAllowances_Passwords_AssociatedPasswordId",
                table: "PasswordAllowances");

            migrationBuilder.DropForeignKey(
                name: "FK_PasswordAllowances_Users_AssociatedUserId",
                table: "PasswordAllowances");

            migrationBuilder.DropIndex(
                name: "IX_PasswordAllowances_AssociatedPasswordId",
                table: "PasswordAllowances");

            migrationBuilder.DropIndex(
                name: "IX_PasswordAllowances_AssociatedUserId",
                table: "PasswordAllowances");

            migrationBuilder.DropColumn(
                name: "AssociatedPasswordId",
                table: "PasswordAllowances");

            migrationBuilder.DropColumn(
                name: "AssociatedUserId",
                table: "PasswordAllowances");

            migrationBuilder.AlterColumn<string>(
                name: "ProfileImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reference",
                table: "Passwords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Passwords",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PasswordId1",
                table: "PasswordAllowances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "PasswordAllowances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PasswordAllowances_PasswordId1",
                table: "PasswordAllowances",
                column: "PasswordId1");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordAllowances_UsersId",
                table: "PasswordAllowances",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordAllowances_Passwords_PasswordId1",
                table: "PasswordAllowances",
                column: "PasswordId1",
                principalTable: "Passwords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PasswordAllowances_Users_UsersId",
                table: "PasswordAllowances",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
