using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserRegistrationApp.Migrations
{
    /// <inheritdoc />
    public partial class AddOtpToUsernew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "Users",
                newName: "ResetToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResetToken",
                table: "Users",
                newName: "Otp");
        }
    }
}
