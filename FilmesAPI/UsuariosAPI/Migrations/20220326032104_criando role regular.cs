using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class criandoroleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a9b59bfe-8357-47b0-864c-b656feaa9558");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "9bd2647c-32df-4eb8-82e9-581a9cff5a28", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ddc9681-5885-412a-bc8d-da0ade1cf62f", "AQAAAAEAACcQAAAAEBnZrCYzOUyly5Edns47N/HOZCoP+TMt4Z1jBmTTHaBDSQYtSxmS1wSgehFQZpEbmg==", "d034f845-80eb-405f-9b95-090e9ebfcc6c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "56833b8e-b5a7-475c-8449-901ae9c00331");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13782ae2-caf8-437b-b7b2-bda6a4234a48", "AQAAAAEAACcQAAAAENThvzVCbzV0VHvO+JBLQ+Gtts4RBDJrT0f0dYmh/Ln+kcAVSoUbEsqZvRiiCmU8tA==", "181df198-aaed-48f6-a85f-72afe9c7ab90" });
        }
    }
}
