using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDatetoappointmentjoiningclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointments");

            migrationBuilder.AddColumn<int>(
                name: "WorkingHourId",
                table: "ServiceProfessionalAppointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "date",
                table: "ServiceProfessionalAppointments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<float>(
                name: "totalPrice",
                table: "ServiceProfessionalAppointments",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProfessionalAppointments_WorkingHourId",
                table: "ServiceProfessionalAppointments",
                column: "WorkingHourId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceProfessionalAppointments_workingHours_WorkingHourId",
                table: "ServiceProfessionalAppointments",
                column: "WorkingHourId",
                principalTable: "workingHours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceProfessionalAppointments_workingHours_WorkingHourId",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropIndex(
                name: "IX_ServiceProfessionalAppointments_WorkingHourId",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropColumn(
                name: "WorkingHourId",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropColumn(
                name: "date",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.DropColumn(
                name: "totalPrice",
                table: "ServiceProfessionalAppointments");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Appointments",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
