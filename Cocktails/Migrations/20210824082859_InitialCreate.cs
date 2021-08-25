using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Cocktails.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alcohols",
                columns: table => new
                {
                    AlcoholId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcohols", x => x.AlcoholId);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    DrinkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.DrinkId);
                });

            migrationBuilder.CreateTable(
                name: "Mixers",
                columns: table => new
                {
                    MixerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mixers", x => x.MixerId);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    AccessoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DrinkId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.AccessoryId);
                    table.ForeignKey(
                        name: "FK_Accessories_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlcoholAmounts",
                columns: table => new
                {
                    AlcoholAmountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    MeasureType = table.Column<string>(type: "text", nullable: true),
                    AlcoholId = table.Column<int>(type: "integer", nullable: true),
                    DrinkId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlcoholAmounts", x => x.AlcoholAmountId);
                    table.ForeignKey(
                        name: "FK_AlcoholAmounts_Alcohols_AlcoholId",
                        column: x => x.AlcoholId,
                        principalTable: "Alcohols",
                        principalColumn: "AlcoholId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlcoholAmounts_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MixerAmounts",
                columns: table => new
                {
                    MixerAmountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    MeasureType = table.Column<string>(type: "text", nullable: true),
                    MixerId = table.Column<int>(type: "integer", nullable: true),
                    DrinkId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MixerAmounts", x => x.MixerAmountId);
                    table.ForeignKey(
                        name: "FK_MixerAmounts_Drinks_DrinkId",
                        column: x => x.DrinkId,
                        principalTable: "Drinks",
                        principalColumn: "DrinkId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MixerAmounts_Mixers_MixerId",
                        column: x => x.MixerId,
                        principalTable: "Mixers",
                        principalColumn: "MixerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_DrinkId",
                table: "Accessories",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholAmounts_AlcoholId",
                table: "AlcoholAmounts",
                column: "AlcoholId");

            migrationBuilder.CreateIndex(
                name: "IX_AlcoholAmounts_DrinkId",
                table: "AlcoholAmounts",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_MixerAmounts_DrinkId",
                table: "MixerAmounts",
                column: "DrinkId");

            migrationBuilder.CreateIndex(
                name: "IX_MixerAmounts_MixerId",
                table: "MixerAmounts",
                column: "MixerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "AlcoholAmounts");

            migrationBuilder.DropTable(
                name: "MixerAmounts");

            migrationBuilder.DropTable(
                name: "Alcohols");

            migrationBuilder.DropTable(
                name: "Drinks");

            migrationBuilder.DropTable(
                name: "Mixers");
        }
    }
}
