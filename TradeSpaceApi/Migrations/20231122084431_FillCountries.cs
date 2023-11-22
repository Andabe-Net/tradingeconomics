using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSpaceApi.Migrations
{
    public partial class FillCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "CountriesData");

            migrationBuilder.AlterColumn<string>(
                name: "SourceURL",
                table: "CountriesData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adjustment",
                table: "CountriesData",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CountriesData",
                table: "CountriesData",
                column: "Country");

            migrationBuilder.InsertData(
                table: "CountriesData",
                columns: new[] { "Country", "Adjustment", "Category", "CategoryGroup", "CreateDate", "FirstValueDate", "Frequency", "HistoricalDataSymbol", "LatestValue", "LatestValueDate", "PreviousValue", "PreviousValueDate", "Source", "SourceURL", "Title", "URL", "Unit" },
                values: new object[] { "Mexico", "NSA", "Employment Rate", "Labour", new DateTime(2015, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "MEXICOEMPRAT", 97.120000000000005, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 97.040000000000006, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instituto Nacional de Estadística y Geografía (INEGI)", "https://www.inegi.org.mx/", "Mexico Employment Rate", "/mexico/employment-rate", "percent" });

            migrationBuilder.InsertData(
                table: "CountriesData",
                columns: new[] { "Country", "Adjustment", "Category", "CategoryGroup", "CreateDate", "FirstValueDate", "Frequency", "HistoricalDataSymbol", "LatestValue", "LatestValueDate", "PreviousValue", "PreviousValueDate", "Source", "SourceURL", "Title", "URL", "Unit" },
                values: new object[] { "Nigeria", "NSA", "Employment Rate", "Labour", new DateTime(2015, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2015, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "NGN", 76.700000000000003, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 73.599999999999994, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central Bank of Nigeria", "https://www.cbn./blahblah/", "Nigeria Employment Rate", "/nigeria/employment-rate", "percent" });

            migrationBuilder.InsertData(
                table: "CountriesData",
                columns: new[] { "Country", "Adjustment", "Category", "CategoryGroup", "CreateDate", "FirstValueDate", "Frequency", "HistoricalDataSymbol", "LatestValue", "LatestValueDate", "PreviousValue", "PreviousValueDate", "Source", "SourceURL", "Title", "URL", "Unit" },
                values: new object[] { "United States", "NSA", "Employment Rate", "Labour", new DateTime(2015, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monthly", "United-StatesUSD", 60.200000000000003, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 60.399999999999999, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "World Bank", "https://www.worldbank.org/", "United States Employment Rate", "/United-States/employment-rate", "percent" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CountriesData",
                table: "CountriesData");

            migrationBuilder.DeleteData(
                table: "CountriesData",
                keyColumn: "Country",
                keyValue: "Mexico");

            migrationBuilder.DeleteData(
                table: "CountriesData",
                keyColumn: "Country",
                keyValue: "Nigeria");

            migrationBuilder.DeleteData(
                table: "CountriesData",
                keyColumn: "Country",
                keyValue: "United States");

            migrationBuilder.RenameTable(
                name: "CountriesData",
                newName: "Countries");

            migrationBuilder.AlterColumn<string>(
                name: "SourceURL",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adjustment",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Country");
        }
    }
}
