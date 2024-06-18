using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactManager.Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "Created", "Email", "IsDeleted", "LastUpdated", "Name", "Notes", "Phone" },
                values: new object[,]
                {
                    { 1, "123 Main St", new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(3990), "iUqFP@example.com", false, new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020), "John Doe", "Test contact", "1234567890" },
                    { 2, "456 Oak St", new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020), "b2yJn@example.com", false, new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4020), "Jane Doe", "Test contact", "0987654321" },
                    { 3, "123 Main St", new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), "iUqFP@example.com", false, new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), "John Smith", "Test contact", "1234567890" },
                    { 4, "456 Oak St", new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), "b2yJn@example.com", true, new DateTime(2024, 6, 18, 17, 1, 3, 758, DateTimeKind.Local).AddTicks(4030), "Jane Smith", "Test contact", "0987654321" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
