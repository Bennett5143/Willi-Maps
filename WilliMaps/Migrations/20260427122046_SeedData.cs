using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WilliMaps.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Hamburg", "Vogelhüttendeich 55", "21107" },
                    { 2, "Hamburg", "Rotenhäuser Straße 67", "21107" },
                    { 3, "Hamburg", "Mengestraße 20", "21107" },
                    { 4, "Hamburg", "Dresdner Straße 36", "21107" },
                    { 5, "Hamburg", "Ernst-August-Straße 13", "21107" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[,]
                {
                    { 1, "#FF5733", "Jugendzentrum" },
                    { 2, "#3380FF", "Bücherhalle" },
                    { 3, "#33FF57", "Sportverein" },
                    { 4, "#FF33F5", "Selbstorganisierter Raum" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "ColorHex", "Name" },
                values: new object[,]
                {
                    { 1, "#00C853", "Kostenfrei" },
                    { 2, "#2196F3", "Barrierefrei" },
                    { 3, "#FF9800", "Altersgerecht" },
                    { 4, "#9C27B0", "Für alle Geschlechter" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "AddressId", "CategoryId", "Coordinates", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (10.0014 53.4965)"), "Offenes Jugendzentrum mit Freizeitangeboten für Jugendliche", "Jugendzentrum Wilhelmsburg" },
                    { 2, 2, 2, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (10.0089 53.4953)"), "Öffentliche Bücherhalle mit Lese- und Aufenthaltsbereich", "Bücherhalle Wilhelmsburg" },
                    { 3, 3, 4, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (10.0035 53.4947)"), "Kulturzentrum mit selbstorganisierten Angeboten für alle", "Kulturpalast Wilhelmsburg" },
                    { 4, 4, 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (10.0056 53.4981)"), "Lokaler Fußballverein mit offenen Trainingsangeboten", "FC Wilhelmsburg" },
                    { 5, 5, 3, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (9.9934 53.4932)"), "Weitläufiger Park mit kostenlosen Sport- und Freizeitflächen", "Inselpark Wilhelmsburg" }
                });

            migrationBuilder.InsertData(
                table: "LocationProperty",
                columns: new[] { "LocationId", "PropertiesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "LocationProperty",
                keyColumns: new[] { "LocationId", "PropertiesId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
