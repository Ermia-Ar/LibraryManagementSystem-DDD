using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Alala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circulates",
                schema: "Library");

            migrationBuilder.AddColumn<string>(
                name: "LoanIds",
                schema: "Library",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReservationIds",
                schema: "Library",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CopyIds",
                schema: "Library",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Loans",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    CopyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FineAmount_Money_Value = table.Column<double>(type: "float", nullable: false),
                    ReturnDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Copies_CopyId",
                        column: x => x.CopyId,
                        principalSchema: "Library",
                        principalTable: "Copies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Library",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CopyId",
                schema: "Library",
                table: "Loans",
                column: "CopyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_UserId",
                schema: "Library",
                table: "Loans",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans",
                schema: "Library");

            migrationBuilder.DropColumn(
                name: "LoanIds",
                schema: "Library",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ReservationIds",
                schema: "Library",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CopyIds",
                schema: "Library",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "Circulates",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    CopyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BorrowDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FineAmount_Money_Value = table.Column<double>(type: "float", nullable: false),
                    ReturnDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circulates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circulates_Copies_CopyId",
                        column: x => x.CopyId,
                        principalSchema: "Library",
                        principalTable: "Copies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Circulates_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Library",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circulates_CopyId",
                schema: "Library",
                table: "Circulates",
                column: "CopyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circulates_UserId",
                schema: "Library",
                table: "Circulates",
                column: "UserId");
        }
    }
}
