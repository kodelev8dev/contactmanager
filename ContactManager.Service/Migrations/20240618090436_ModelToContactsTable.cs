using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactManager.Service.Migrations
{
    /// <inheritdoc />
    public partial class ModelToContactsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(70), new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(100), new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(100), new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(100) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(110), new DateTime(2024, 6, 18, 17, 4, 36, 643, DateTimeKind.Local).AddTicks(110) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(3990), new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020), new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030) });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created", "LastUpdated" },
                values: new object[] { new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030) });
        }
    }
}
