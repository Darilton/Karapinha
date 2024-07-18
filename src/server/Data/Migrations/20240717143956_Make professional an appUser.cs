using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeprofessionalanappUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProfessionalAppointments_Professionals_ProfessionalId",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_workingHours_Professionals_ProfessionalId",
                table: "workingHours");

            migrationBuilder.DropTable(
                name: "Professionals");

            migrationBuilder.AlterColumn<string>(
                name: "ProfessionalId",
                table: "workingHours",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProfessionalId",
                table: "ServiceProfessionalAppointments",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CategoryId",
                table: "AspNetUsers",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Categories_CategoryId",
                table: "AspNetUsers",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProfessionalAppointments_AspNetUsers_ProfessionalId",
                table: "ServiceProfessionalAppointments",
                column: "ProfessionalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workingHours_AspNetUsers_ProfessionalId",
                table: "workingHours",
                column: "ProfessionalId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Categories_CategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProfessionalAppointments_AspNetUsers_ProfessionalId",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_workingHours_AspNetUsers_ProfessionalId",
                table: "workingHours");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CategoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "workingHours",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProfessionalId",
                table: "ServiceProfessionalAppointments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "Professionals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bilhete = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professionals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professionals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Professionals_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_CategoryId",
                table: "Professionals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Professionals_ImageId",
                table: "Professionals",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProfessionalAppointments_Professionals_ProfessionalId",
                table: "ServiceProfessionalAppointments",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workingHours_Professionals_ProfessionalId",
                table: "workingHours",
                column: "ProfessionalId",
                principalTable: "Professionals",
                principalColumn: "Id");
        }
    }
}
