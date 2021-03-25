using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingExercisePaymentGateway.Migrations
{
    public partial class ChangePaymentStateToEnum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Failed",
                table: "PaymentState");

            migrationBuilder.DropColumn(
                name: "Pending",
                table: "PaymentState");

            migrationBuilder.RenameColumn(
                name: "Processed",
                table: "PaymentState",
                newName: "PaymentProcessStatus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PaymentProcessStatus",
                table: "PaymentState",
                newName: "Processed");

            migrationBuilder.AddColumn<int>(
                name: "Failed",
                table: "PaymentState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Pending",
                table: "PaymentState",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
