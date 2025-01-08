﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 1, 8, 16, 31, 30, 878, DateTimeKind.Utc).AddTicks(3528), new byte[] { 8, 55, 26, 10, 148, 220, 17, 64, 43, 7, 184, 204, 206, 70, 106, 88, 164, 248, 215, 33, 247, 44, 192, 84, 52, 114, 201, 146, 132, 143, 53, 60, 98, 2, 236, 46, 231, 76, 162, 189, 55, 254, 111, 103, 16, 22, 35, 53, 43, 17, 9, 72, 21, 222, 136, 177, 105, 180, 111, 173, 25, 94, 37, 233 }, new byte[] { 151, 157, 218, 68, 61, 228, 243, 139, 87, 141, 125, 33, 95, 137, 112, 177, 114, 116, 185, 253, 232, 65, 210, 128, 48, 153, 160, 254, 43, 124, 18, 160, 170, 10, 196, 183, 138, 30, 187, 191, 162, 0, 228, 148, 50, 177, 225, 195, 129, 129, 182, 156, 168, 235, 102, 168, 223, 195, 29, 170, 107, 90, 121, 232, 123, 203, 148, 202, 149, 73, 35, 230, 220, 242, 253, 16, 19, 143, 143, 79, 84, 178, 85, 134, 128, 252, 118, 185, 178, 187, 234, 51, 97, 176, 90, 79, 200, 121, 153, 120, 239, 209, 134, 107, 213, 11, 123, 153, 224, 59, 18, 33, 116, 179, 96, 136, 197, 172, 89, 104, 74, 15, 127, 66, 115, 128, 57, 53 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 1, 8, 16, 26, 22, 293, DateTimeKind.Utc).AddTicks(3492), new byte[] { 32, 7, 38, 123, 80, 152, 232, 20, 210, 24, 34, 63, 66, 200, 235, 119, 183, 88, 56, 14, 214, 123, 246, 136, 183, 79, 164, 6, 81, 9, 188, 255, 117, 114, 73, 64, 93, 221, 80, 65, 13, 14, 192, 209, 212, 125, 186, 107, 109, 76, 48, 229, 67, 170, 72, 235, 7, 62, 53, 147, 127, 208, 46, 239 }, new byte[] { 72, 153, 177, 107, 61, 187, 109, 4, 175, 190, 117, 167, 194, 101, 220, 97, 191, 215, 122, 215, 197, 162, 169, 58, 72, 60, 54, 35, 208, 211, 29, 171, 21, 218, 130, 25, 216, 229, 37, 3, 177, 140, 49, 112, 105, 95, 182, 157, 186, 6, 175, 151, 172, 243, 162, 104, 200, 95, 94, 34, 63, 2, 157, 11, 90, 44, 247, 198, 113, 47, 201, 33, 60, 73, 44, 32, 156, 11, 180, 223, 79, 131, 185, 81, 212, 40, 21, 6, 70, 21, 70, 70, 34, 162, 45, 229, 31, 216, 255, 36, 160, 141, 172, 194, 113, 67, 23, 193, 189, 64, 223, 145, 217, 204, 10, 49, 148, 227, 182, 33, 104, 224, 184, 179, 17, 248, 59, 62 } });
        }
    }
}
