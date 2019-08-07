using Microsoft.EntityFrameworkCore.Migrations;

namespace Marketplace.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c40d4644-42cf-4952-9b32-f3b9cb48c299", "AQAAAAEAACcQAAAAEKFSWEeneg1UzNtEy3Y1ZvhzCf2PQ8q+JkMjNugY8TPfEehuMPjbriySN2d8hcWhVQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-aaaa-bbbb-cccc-dddddddddddd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9a2eb110-29e6-4837-8a62-4d256b1f1612", "AQAAAAEAACcQAAAAED0W3oPYQo5k1q78vsxZUtDwkQ8ZtM6P3ef39I2ceuvKQdFAGK5XKVFBpFS/CPFE2Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
