using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "journey",
                columns: table => new
                {
                    journey_id = table.Column<int>(type: "int", nullable: false),
                    origin = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    destination = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__journey__B6E9049CA1960992", x => x.journey_id);
                });

            migrationBuilder.CreateTable(
                name: "transport",
                columns: table => new
                {
                    transport_id = table.Column<int>(type: "int", nullable: false),
                    fligth_carrier = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    fligth_carrier_number = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__transpor__A17E3277E9A38D81", x => x.transport_id);
                });

            migrationBuilder.CreateTable(
                name: "fligth",
                columns: table => new
                {
                    fligth_id = table.Column<int>(type: "int", nullable: false),
                    transport_id = table.Column<int>(type: "int", nullable: false),
                    origin = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    destination = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__fligth__76261301FBEDCE68", x => x.fligth_id);
                    table.ForeignKey(
                        name: "FK__fligth__transpor__4D94879B",
                        column: x => x.transport_id,
                        principalTable: "transport",
                        principalColumn: "transport_id");
                });

            migrationBuilder.CreateTable(
                name: "journey_flight",
                columns: table => new
                {
                    journey_flight_id = table.Column<int>(type: "int", nullable: false),
                    fligth_id = table.Column<int>(type: "int", nullable: false),
                    journey_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__journey___EE01FF5AE489D814", x => x.journey_flight_id);
                    table.ForeignKey(
                        name: "FK__journey_f__fligt__52593CB8",
                        column: x => x.fligth_id,
                        principalTable: "fligth",
                        principalColumn: "fligth_id");
                    table.ForeignKey(
                        name: "FK__journey_f__journ__534D60F1",
                        column: x => x.journey_id,
                        principalTable: "journey",
                        principalColumn: "journey_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fligth_transport_id",
                table: "fligth",
                column: "transport_id");

            migrationBuilder.CreateIndex(
                name: "IX_journey_flight_fligth_id",
                table: "journey_flight",
                column: "fligth_id");

            migrationBuilder.CreateIndex(
                name: "IX_journey_flight_journey_id",
                table: "journey_flight",
                column: "journey_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "journey_flight");

            migrationBuilder.DropTable(
                name: "fligth");

            migrationBuilder.DropTable(
                name: "journey");

            migrationBuilder.DropTable(
                name: "transport");
        }
    }
}
