using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ProductsActivity.Dal.Migrations.ProductsActivityMigrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagesLikes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductId = table.Column<long>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    ImageId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesLikesLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PreviousValue = table.Column<string>(nullable: false),
                    NewValue = table.Column<string>(nullable: false),
                    MethodName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesLikesLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsLikes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductId = table.Column<long>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsLikesLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PreviousValue = table.Column<string>(nullable: false),
                    NewValue = table.Column<string>(nullable: false),
                    MethodName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsLikesLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsViewed",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProductId = table.Column<long>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    DateTimeInitial = table.Column<DateTime>(nullable: false),
                    TimeViewed = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsViewed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductsViewedLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Username = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PreviousValue = table.Column<string>(nullable: false),
                    NewValue = table.Column<string>(nullable: false),
                    MethodName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsViewedLogs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_ImageId",
                table: "ImagesLikes",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_ProductId",
                table: "ImagesLikes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesLikes_Username",
                table: "ImagesLikes",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsLikes_ProductCode",
                table: "ProductsLikes",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsLikes_ProductId",
                table: "ProductsLikes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsLikes_Username",
                table: "ProductsLikes",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsViewed_ProductCode",
                table: "ProductsViewed",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsViewed_ProductId",
                table: "ProductsViewed",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsViewed_Username",
                table: "ProductsViewed",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsViewed_Username_ProductId_DateTimeInitial",
                table: "ProductsViewed",
                columns: new[] { "Username", "ProductId", "DateTimeInitial" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesLikes");

            migrationBuilder.DropTable(
                name: "ImagesLikesLogs");

            migrationBuilder.DropTable(
                name: "ProductsLikes");

            migrationBuilder.DropTable(
                name: "ProductsLikesLogs");

            migrationBuilder.DropTable(
                name: "ProductsViewed");

            migrationBuilder.DropTable(
                name: "ProductsViewedLogs");
        }
    }
}
