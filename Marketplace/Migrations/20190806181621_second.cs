using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cd899c94-dc7a-4747-bc55-85d1462d99c5", "AQAAAAEAACcQAAAAEKNyhG231CHfidAnDdt2eIbPZNolPF4Y0wq0DBOkHWP1kRs6kK5+40EI5tRxqPiGmw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "57ff52c8-972d-44ec-8431-77244f1c0d25", "AQAAAAEAACcQAAAAEDhVkvn5wKBBVGKiJGrhr6XCaU357g1eSy2Zy9ys+tymBlX5/U9l5dBumqUSdZ9I5Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "130593e2-8b02-4f14-a7ea-e02da967fa7f", "AQAAAAEAACcQAAAAEMfXKsuvAureA7GV/K+ReMIqk4tPGMEkqXrCjPKOLxvBSOAiF3gd8EgzJ9sda1FMEg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ce5bef93-1622-4ce8-a812-aa2e0eab2c1c", "AQAAAAEAACcQAAAAEEIGIspccsCnW3Mbt9z+j6RnQ3SlZemj2q6bbqE2+AcL810Ujzfs7uXud0WlFkUE/Q==" });
        }
    }
}
