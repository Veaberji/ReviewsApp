using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class ClearDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DELETE FROM [dbo].[Tags]
                DELETE FROM [dbo].[Images]
                DELETE FROM [dbo].[Comments]
                DELETE FROM [dbo].[Likes]
                DELETE FROM [dbo].[Reviews]
                DELETE FROM [dbo].[UserGrades]
                DELETE FROM [dbo].[Products]

                DELETE FROM [dbo].[AspNetRoles]
                DELETE FROM [dbo].[AspNetUserLogins]
                DELETE FROM [dbo].[AspNetUsers] 
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
