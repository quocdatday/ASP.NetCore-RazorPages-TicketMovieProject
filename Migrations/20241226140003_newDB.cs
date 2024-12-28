using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ASPNetCoreRazorPage_TicketMovie.Migrations
{
    /// <inheritdoc />
    public partial class newDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Screen_Cinema_CinemaCIN_ID",
                table: "Screen");

            migrationBuilder.DropIndex(
                name: "IX_Screen_CinemaCIN_ID",
                table: "Screen");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5b0ad371-245f-46c0-80ea-f2f722a9f03e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6fa68e8b-b4c4-4822-b761-18c5bb56cea4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bd6f790f-c4c2-4469-a6fa-d9d289d5ba48");

            migrationBuilder.DropColumn(
                name: "CinemaCIN_ID",
                table: "Screen");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "129e2440-e896-4d64-b582-1045ef37347b", null, "staff", "staff" },
                    { "27fb0413-2fb9-47dd-ad41-1ea16d244f04", null, "user", "user" },
                    { "d7d259e8-037d-4cdd-b4a1-ff9da8608131", null, "admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "129e2440-e896-4d64-b582-1045ef37347b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "27fb0413-2fb9-47dd-ad41-1ea16d244f04");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d7d259e8-037d-4cdd-b4a1-ff9da8608131");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Payment");

            migrationBuilder.AddColumn<int>(
                name: "CinemaCIN_ID",
                table: "Screen",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Payment",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b0ad371-245f-46c0-80ea-f2f722a9f03e", null, "staff", "staff" },
                    { "6fa68e8b-b4c4-4822-b761-18c5bb56cea4", null, "user", "user" },
                    { "bd6f790f-c4c2-4469-a6fa-d9d289d5ba48", null, "admin", "admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Screen_CinemaCIN_ID",
                table: "Screen",
                column: "CinemaCIN_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Screen_Cinema_CinemaCIN_ID",
                table: "Screen",
                column: "CinemaCIN_ID",
                principalTable: "Cinema",
                principalColumn: "CIN_ID");
        }
    }
}
