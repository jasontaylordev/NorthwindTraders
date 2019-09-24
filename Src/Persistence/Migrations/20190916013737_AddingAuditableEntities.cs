using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Northwind.Persistence.Migrations
{
    public partial class AddingAuditableEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Order Details",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Order Details",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Employees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Order Details");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Employees");
        }
    }
}
