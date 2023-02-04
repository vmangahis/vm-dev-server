using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vmdevserver.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleName = table.Column<string>(name: "Role_Name", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Experiences");
        }
    }
}
