using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CheeseMVC.Migrations
{
    public partial class AddCheeseMenu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CheeseMenus",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false),
                    CheeseID = table.Column<int>(nullable: false),
                    CheeseMenuCheeseID = table.Column<int>(nullable: true),
                    CheeseMenuMenuID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheeseMenus", x => new { x.CheeseID, x.MenuID });
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Cheeses_CheeseID",
                        column: x => x.CheeseID,
                        principalTable: "Cheeses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheeseMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheeseMenus_CheeseMenus_CheeseMenuCheeseID_CheeseMenuMenuID",
                        columns: x => new { x.CheeseMenuCheeseID, x.CheeseMenuMenuID },
                        principalTable: "CheeseMenus",
                        principalColumns: new[] { "CheeseID", "MenuID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheeseMenus_MenuID",
                table: "CheeseMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_CheeseMenus_CheeseMenuCheeseID_CheeseMenuMenuID",
                table: "CheeseMenus",
                columns: new[] { "CheeseMenuCheeseID", "CheeseMenuMenuID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheeseMenus");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
