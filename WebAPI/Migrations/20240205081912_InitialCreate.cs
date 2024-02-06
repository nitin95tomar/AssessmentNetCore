using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgressNotes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionName = table.Column<string>(type: "TEXT", nullable: false),
                    SectionText = table.Column<string>(type: "TEXT", nullable: false),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressNotes_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgressNotes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 11111L, "Asian" },
                    { 22222L, "Appollo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1111, "john1111@abc.com", "john1111", "1111@abc" },
                    { 2222, "john2222@abc.com", "john2222", "2222@abc" },
                    { 3333, "john3333@abc.com", "john3333", "3333@abc" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Address", "City", "CreatedAt", "FirstName", "IsDeleted", "LastName", "OrganizationId", "State", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, null, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(320), "John", null, "Wick", 11111L, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(360) },
                    { 2L, null, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(370), "John", null, "Cena", 11111L, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(370) },
                    { 3L, null, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(380), "Iron", null, "Man", 22222L, null, new DateTime(2024, 2, 5, 13, 49, 12, 590, DateTimeKind.Local).AddTicks(380) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_OrganizationId",
                table: "Patients",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressNotes_OrganizationId",
                table: "ProgressNotes",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressNotes_PatientId",
                table: "ProgressNotes",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgressNotes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
