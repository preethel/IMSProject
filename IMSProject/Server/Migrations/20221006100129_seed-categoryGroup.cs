using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMSProject.Server.Migrations
{
    public partial class seedcategoryGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CategoryGroups",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1, "IMS-1" });

            migrationBuilder.InsertData(
                table: "CategoryGroups",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2, "IMS-2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "", "Chaal" },
                    { 2, "", "Daal" },
                    { 3, "", "Tel" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Description", "Type" },
                values: new object[,]
                {
                    { 1, "Kilogram", "kg" },
                    { 2, "Liter", "L" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Ammount", "CategoryId", "Description", "Quantity", "SellingPrice", "Title", "UnitId" },
                values: new object[,]
                {
                    { 1, 10000, 1, "NotunChaal", 500, 70, "Athais", 1 },
                    { 2, 10000, 1, "NotunChaal", 500, 70, "Miniket", 1 },
                    { 3, 10000, 3, "Soyabin", 500, 60, "Rupchada", 2 },
                    { 4, 10000, 3, "ACI", 500, 90, "Moshur", 2 }
                });
        }
    }
}
