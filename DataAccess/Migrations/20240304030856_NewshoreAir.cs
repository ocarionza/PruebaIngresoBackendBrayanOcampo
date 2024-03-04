using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class NewshoreAir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__fligth__transpor__4D94879B",
                table: "fligth");

            migrationBuilder.DropForeignKey(
                name: "FK__journey_f__fligt__52593CB8",
                table: "journey_flight");

            migrationBuilder.DropForeignKey(
                name: "FK__journey_f__journ__534D60F1",
                table: "journey_flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK__transpor__A17E3277E9A38D81",
                table: "transport");

            migrationBuilder.DropPrimaryKey(
                name: "PK__journey___EE01FF5AE489D814",
                table: "journey_flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK__journey__B6E9049CA1960992",
                table: "journey");

            migrationBuilder.DropPrimaryKey(
                name: "PK__fligth__76261301FBEDCE68",
                table: "fligth");

            migrationBuilder.AlterColumn<int>(
                name: "transport_id",
                table: "transport",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "journey_flight_id",
                table: "journey_flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "journey_id",
                table: "journey",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "fligth_id",
                table: "fligth",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transport",
                table: "transport",
                column: "transport_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_journey_flight",
                table: "journey_flight",
                column: "journey_flight_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_journey",
                table: "journey",
                column: "journey_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fligth",
                table: "fligth",
                column: "fligth_id");

            migrationBuilder.AddForeignKey(
                name: "FK_fligth_transport_transport_id",
                table: "fligth",
                column: "transport_id",
                principalTable: "transport",
                principalColumn: "transport_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journey_flight_fligth_fligth_id",
                table: "journey_flight",
                column: "fligth_id",
                principalTable: "fligth",
                principalColumn: "fligth_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journey_flight_journey_journey_id",
                table: "journey_flight",
                column: "journey_id",
                principalTable: "journey",
                principalColumn: "journey_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fligth_transport_transport_id",
                table: "fligth");

            migrationBuilder.DropForeignKey(
                name: "FK_journey_flight_fligth_fligth_id",
                table: "journey_flight");

            migrationBuilder.DropForeignKey(
                name: "FK_journey_flight_journey_journey_id",
                table: "journey_flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transport",
                table: "transport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_journey_flight",
                table: "journey_flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_journey",
                table: "journey");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fligth",
                table: "fligth");

            migrationBuilder.AlterColumn<int>(
                name: "transport_id",
                table: "transport",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "journey_flight_id",
                table: "journey_flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "journey_id",
                table: "journey",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "fligth_id",
                table: "fligth",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK__transpor__A17E3277E9A38D81",
                table: "transport",
                column: "transport_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__journey___EE01FF5AE489D814",
                table: "journey_flight",
                column: "journey_flight_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__journey__B6E9049CA1960992",
                table: "journey",
                column: "journey_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__fligth__76261301FBEDCE68",
                table: "fligth",
                column: "fligth_id");

            migrationBuilder.AddForeignKey(
                name: "FK__fligth__transpor__4D94879B",
                table: "fligth",
                column: "transport_id",
                principalTable: "transport",
                principalColumn: "transport_id");

            migrationBuilder.AddForeignKey(
                name: "FK__journey_f__fligt__52593CB8",
                table: "journey_flight",
                column: "fligth_id",
                principalTable: "fligth",
                principalColumn: "fligth_id");

            migrationBuilder.AddForeignKey(
                name: "FK__journey_f__journ__534D60F1",
                table: "journey_flight",
                column: "journey_id",
                principalTable: "journey",
                principalColumn: "journey_id");
        }
    }
}
