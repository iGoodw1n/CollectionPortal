using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CollectionDataLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CustomString1 = table.Column<string>(type: "text", nullable: true),
                    CustomString2 = table.Column<string>(type: "text", nullable: true),
                    CustomString3 = table.Column<string>(type: "text", nullable: true),
                    CustomInt1 = table.Column<int>(type: "integer", nullable: true),
                    CustomInt2 = table.Column<int>(type: "integer", nullable: true),
                    CustomInt3 = table.Column<int>(type: "integer", nullable: true),
                    CustomText1 = table.Column<string>(type: "text", nullable: true),
                    CustomText2 = table.Column<string>(type: "text", nullable: true),
                    CustomText3 = table.Column<string>(type: "text", nullable: true),
                    CustomCheckBox1 = table.Column<bool>(type: "boolean", nullable: true),
                    CustomCheckBox2 = table.Column<bool>(type: "boolean", nullable: true),
                    CustomCheckBox3 = table.Column<bool>(type: "boolean", nullable: true),
                    CustomDate1 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomDate2 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CustomDate3 = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CustomString1State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomString1Name = table.Column<string>(type: "text", nullable: true),
                    CustomString2State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomString2Name = table.Column<string>(type: "text", nullable: true),
                    CustomString3State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomString3Name = table.Column<string>(type: "text", nullable: true),
                    CustomInt1State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomInt1Name = table.Column<string>(type: "text", nullable: true),
                    CustomInt2State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomInt2Name = table.Column<string>(type: "text", nullable: true),
                    CustomInt3State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomInt3Name = table.Column<string>(type: "text", nullable: true),
                    CustomDate1State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomDate1Name = table.Column<string>(type: "text", nullable: true),
                    CustomDate2State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomDate2Name = table.Column<string>(type: "text", nullable: true),
                    CustomDate3State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomDate3Name = table.Column<string>(type: "text", nullable: true),
                    CustomText1State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomText1Name = table.Column<string>(type: "text", nullable: true),
                    CustomText2State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomText2Name = table.Column<string>(type: "text", nullable: true),
                    CustomText3State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomText3Name = table.Column<string>(type: "text", nullable: true),
                    CustomCheckBox1State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomCheckBox1Name = table.Column<string>(type: "text", nullable: true),
                    CustomCheckBox2State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomCheckBox2Name = table.Column<string>(type: "text", nullable: true),
                    CustomCheckBox3State = table.Column<bool>(type: "boolean", nullable: false),
                    CustomCheckBox3Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Collections_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemId",
                table: "Tags",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
