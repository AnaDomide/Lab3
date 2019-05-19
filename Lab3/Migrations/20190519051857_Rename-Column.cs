using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab3.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Expenses_ExpenseId",
            //    table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Expenses",
                newName: "Typ");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ExpenseId",
            //    table: "Comments",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Expenses_ExpenseId",
            //    table: "Comments",
            //    column: "ExpenseId",
            //    principalTable: "Expenses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Comments_Expenses_ExpenseId",
            //    table: "Comments");

            migrationBuilder.RenameColumn(
                name: "Typ",
                table: "Expenses",
                newName: "Type");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ExpenseId",
            //    table: "Comments",
            //    nullable: true,
            //    oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Comments_Expenses_ExpenseId",
            //    table: "Comments",
            //    column: "ExpenseId",
            //    principalTable: "Expenses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
