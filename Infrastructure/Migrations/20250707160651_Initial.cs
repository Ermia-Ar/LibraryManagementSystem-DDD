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
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Circulates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CopyId_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DueDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FineAmount_Money_Value = table.Column<double>(type: "float", nullable: false),
                    ReturnDate_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circulates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Copies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OperationalStatus_value__ = table.Column<int>(type: "int", nullable: false),
                    PhysicalCondition_value__ = table.Column<int>(type: "int", nullable: false),
                    Price_Moeny_Value = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CopyId_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationDate_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status_value__ = table.Column<int>(type: "int", nullable: false),
                    UserId_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email_Value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Name_Name = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Sex_value__ = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Circulates");

            migrationBuilder.DropTable(
                name: "Copies");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
