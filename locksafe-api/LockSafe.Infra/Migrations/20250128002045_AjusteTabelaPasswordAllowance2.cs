using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LockSafe.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTabelaPasswordAllowance2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
