using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosAPI.Migrations
{
    public partial class adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "0aebe7e0-2d13-49ce-8c7e-ba7824578da4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "981d20ed-dfe5-4087-83b7-c14c1b790214");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f9901b1-2be2-4ba4-bc28-96fc5c525585", "AQAAAAEAACcQAAAAEKJRJdd67p4aHhll+elnC07wxK4gmlKPW2gJJYHHTGkYT1asGunWelR9nNHkYze8UA==", "67a17a7e-2b14-478b-b0dc-cb0786b9918f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998,
                column: "ConcurrencyStamp",
                value: "9bd2647c-32df-4eb8-82e9-581a9cff5a28");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "a9b59bfe-8357-47b0-864c-b656feaa9558");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ddc9681-5885-412a-bc8d-da0ade1cf62f", "AQAAAAEAACcQAAAAEBnZrCYzOUyly5Edns47N/HOZCoP+TMt4Z1jBmTTHaBDSQYtSxmS1wSgehFQZpEbmg==", "d034f845-80eb-405f-9b95-090e9ebfcc6c" });
        }
    }
}
