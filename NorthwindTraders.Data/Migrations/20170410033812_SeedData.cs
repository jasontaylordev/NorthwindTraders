using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using NorthwindTraders.Data.Properties;

namespace NorthwindTraders.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Resources.ResourceManager.GetString("SeedData_Up"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Resources.ResourceManager.GetString("SeedData_Down"));
        }
    }
}
