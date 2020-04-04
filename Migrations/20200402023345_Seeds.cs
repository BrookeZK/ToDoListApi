using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoListApi.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Career Goals" },
                    { 2, "Life Goals" },
                    { 3, "Yolo Goals" },
                    { 4, "Friendship" },
                    { 5, "Garden" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "Description" },
                values: new object[,]
                {
                    { 1, "Walk the doog" },
                    { 2, "Pet the cat" },
                    { 3, "Water the plants" },
                    { 4, "Ask for help" },
                    { 5, "meditate" }
                });

            migrationBuilder.InsertData(
                table: "CategoryItem",
                columns: new[] { "CategoryItemId", "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 3, 2 },
                    { 4, 4, 3 },
                    { 5, 1, 4 },
                    { 3, 5, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryItem",
                keyColumn: "CategoryItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryItem",
                keyColumn: "CategoryItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryItem",
                keyColumn: "CategoryItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryItem",
                keyColumn: "CategoryItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoryItem",
                keyColumn: "CategoryItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: 5);
        }
    }
}
