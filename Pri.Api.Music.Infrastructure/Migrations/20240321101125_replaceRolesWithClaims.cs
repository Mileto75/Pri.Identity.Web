using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pri.CleanArchitecture.Music.Infrastructure.Migrations
{
    public partial class replaceRolesWithClaims : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", "1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "User", "2" },
                    { 3, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "21/03/2024 11:11:24", "1" },
                    { 4, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth", "21/03/2024 11:11:24", "2" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b4259f6-c013-4650-b298-8ce16da9fa68", new DateTime(2024, 3, 21, 11, 11, 24, 886, DateTimeKind.Local).AddTicks(4918), "AQAAAAEAACcQAAAAEA2Suo6s3qgAbzYc+pSd5+NeUXjZRgbHmJBC0L5EzNoig93WMgwFmsDjuTJnlSC9wA==", "d9cc26a0-17b2-4b95-b387-7de4c1181284" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42cf148b-252a-400b-b637-f87498f34aac", new DateTime(2024, 3, 21, 11, 11, 24, 886, DateTimeKind.Local).AddTicks(4960), "AQAAAAEAACcQAAAAEBFnvSlL3X1lIks4ik9hB2RUUcbPndoNfdPYh4oLsxjECFx3jqjhaJe861mwbL8syw==", "2c8de881-a89e-4da5-b5ee-f8a169ca1ecf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "d24cb3f9-0c3e-4a87-9bd1-f5c823f5bde3", "Admin", "ADMIN" },
                    { "2", "1dcd2c85-367c-48ed-9559-d5b1db30c598", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64fc13d7-a254-4dba-a261-4b9b7aef5bc0", new DateTime(2024, 3, 14, 11, 26, 49, 212, DateTimeKind.Local).AddTicks(8069), "AQAAAAEAACcQAAAAEF31B8Be6x5XpHykIdAYlttE6DBUTNjFQdd5bmXgMAsUmKIaotGDMfDkoJQb5xfJsA==", "330b3a97-e4e0-4375-bf00-e85e492d05c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eafb03cc-2086-4162-bc0e-12aecc1c6c0e", new DateTime(2024, 3, 14, 11, 26, 49, 212, DateTimeKind.Local).AddTicks(8103), "AQAAAAEAACcQAAAAEFdwRzy910LPuOZ/g+OAS8YeC+QxQ8lQMdrAaAi0ReDcmA+K4/uBc/9NBZetn5/Vrw==", "daccfd10-fbd0-4d4d-8562-212bda9a527e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });
        }
    }
}
