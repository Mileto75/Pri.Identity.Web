using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.CleanArchitecture.Music.Infrastructure.Migrations
{
    public partial class addIdentitySeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRecord_AspNetUsers_UsersId",
                table: "ApplicationUserRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRecord",
                table: "ApplicationUserRecord");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserRecord_UsersId",
                table: "ApplicationUserRecord");

            migrationBuilder.DeleteData(
                table: "PropertyRecord",
                keyColumns: new[] { "PropertiesId", "RecordsId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "ApplicationUserRecord",
                newName: "ApplicationUsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRecord",
                table: "ApplicationUserRecord",
                columns: new[] { "ApplicationUsersId", "RecordsId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "d24cb3f9-0c3e-4a87-9bd1-f5c823f5bde3", "Admin", "ADMIN" },
                    { "2", "1dcd2c85-367c-48ed-9559-d5b1db30c598", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "64fc13d7-a254-4dba-a261-4b9b7aef5bc0", new DateTime(2024, 3, 14, 11, 26, 49, 212, DateTimeKind.Local).AddTicks(8069), "admin@music.com", true, "Bart", "Soete", false, null, "ADMIN@MUSIC.COM", "ADMIN@MUSIC.COM", "AQAAAAEAACcQAAAAEF31B8Be6x5XpHykIdAYlttE6DBUTNjFQdd5bmXgMAsUmKIaotGDMfDkoJQb5xfJsA==", null, false, "330b3a97-e4e0-4375-bf00-e85e492d05c4", false, "admin@music.com" },
                    { "2", 0, "eafb03cc-2086-4162-bc0e-12aecc1c6c0e", new DateTime(2024, 3, 14, 11, 26, 49, 212, DateTimeKind.Local).AddTicks(8103), "user@music.com", true, "Mileto", "Di Marco", false, null, "USER@MUSIC.COM", "USER@MUSIC.COM", "AQAAAAEAACcQAAAAEFdwRzy910LPuOZ/g+OAS8YeC+QxQ8lQMdrAaAi0ReDcmA+K4/uBc/9NBZetn5/Vrw==", null, false, "daccfd10-fbd0-4d4d-8562-212bda9a527e", false, "user@music.com" }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserRecord",
                columns: new[] { "ApplicationUsersId", "RecordsId" },
                values: new object[,]
                {
                    { "1", 1 },
                    { "1", 2 },
                    { "1", 3 },
                    { "2", 1 },
                    { "2", 2 },
                    { "2", 3 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecord_RecordsId",
                table: "ApplicationUserRecord",
                column: "RecordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRecord_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserRecord",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserRecord_AspNetUsers_ApplicationUsersId",
                table: "ApplicationUserRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserRecord",
                table: "ApplicationUserRecord");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserRecord_RecordsId",
                table: "ApplicationUserRecord");

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "1", 1 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "1", 2 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "1", 3 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "2", 1 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "2", 2 });

            migrationBuilder.DeleteData(
                table: "ApplicationUserRecord",
                keyColumns: new[] { "ApplicationUsersId", "RecordsId" },
                keyValues: new object[] { "2", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.RenameColumn(
                name: "ApplicationUsersId",
                table: "ApplicationUserRecord",
                newName: "UsersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserRecord",
                table: "ApplicationUserRecord",
                columns: new[] { "RecordsId", "UsersId" });

            migrationBuilder.InsertData(
                table: "PropertyRecord",
                columns: new[] { "PropertiesId", "RecordsId" },
                values: new object[] { 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserRecord_UsersId",
                table: "ApplicationUserRecord",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserRecord_AspNetUsers_UsersId",
                table: "ApplicationUserRecord",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
