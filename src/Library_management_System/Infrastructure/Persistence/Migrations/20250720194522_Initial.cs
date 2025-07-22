using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Library");

            migrationBuilder.CreateTable(
                name: "Books",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Genres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_FullName = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PublicationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Publisher_Name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Title_Content = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "100000, 1"),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_Name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Copies",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    OperationalStatus = table.Column<int>(type: "int", nullable: false),
                    PhysicalCondition = table.Column<int>(type: "int", nullable: false),
                    Price_Moeny_Value = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Copies_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "Library",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Circulates",
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

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "Library",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    CopyId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReservationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Copies_CopyId",
                        column: x => x.CopyId,
                        principalSchema: "Library",
                        principalTable: "Copies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Copies_BookId",
                schema: "Library",
                table: "Copies",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CopyId",
                schema: "Library",
                table: "Reservations",
                column: "CopyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                schema: "Library",
                table: "Reservations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circulates",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Copies",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Library");

            migrationBuilder.DropTable(
                name: "Books",
                schema: "Library");
        }
    }
}
