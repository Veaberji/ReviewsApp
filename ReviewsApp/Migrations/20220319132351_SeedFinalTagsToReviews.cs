﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalTagsToReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (34, 23)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (35, 23)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (37, 23)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (38, 23)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (39, 23)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (34, 24)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (34, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (35, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (37, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (39, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (41, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (42, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (47, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (53, 25)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (34, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (45, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (46, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (50, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (51, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (54, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (56, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (57, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (58, 26)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (35, 27)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (37, 30)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (37, 31)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (42, 31)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (49, 31)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (38, 32)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (38, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (39, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (42, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (45, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (48, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (49, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (52, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (55, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (59, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (60, 33)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (39, 34)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (41, 35)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (42, 35)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (43, 35)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (44, 35)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (45, 35)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (42, 36)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (43, 37)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (43, 38)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (44, 38)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (44, 39)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (45, 40)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (46, 41)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (47, 41)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (48, 41)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (49, 41)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (50, 41)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (46, 42)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (47, 43)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (48, 44)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (49, 45)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (50, 46)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (50, 47)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (51, 48)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (52, 48)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (53, 48)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (54, 48)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (55, 48)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (51, 49)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (51, 50)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (53, 50)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (52, 51)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (53, 52)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (54, 53)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (55, 54)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (56, 55)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (57, 55)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (58, 55)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (59, 55)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (60, 55)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (56, 56)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (57, 57)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (58, 58)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (59, 59)
            INSERT INTO [dbo].[ReviewTag] ([ReviewsId], [TagsId]) VALUES (60, 60)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}