using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingExercisePaymentGateway.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PaymentStateId",
                table: "payments",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pending = table.Column<int>(type: "int", nullable: false),
                    Processed = table.Column<int>(type: "int", nullable: false),
                    Failed = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentState", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_payments_PaymentStateId",
                table: "payments",
                column: "PaymentStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_PaymentState_PaymentStateId",
                table: "payments",
                column: "PaymentStateId",
                principalTable: "PaymentState",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_PaymentState_PaymentStateId",
                table: "payments");

            migrationBuilder.DropTable(
                name: "PaymentState");

            migrationBuilder.DropIndex(
                name: "IX_payments_PaymentStateId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PaymentStateId",
                table: "payments");
        }
    }
}
