using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Likes] ON
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (241, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 45)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (242, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 44)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (243, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 43)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (244, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 42)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (245, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 41)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (246, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 50)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (247, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 49)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (248, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 48)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (249, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 47)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (250, N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 46)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (251, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 50)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (252, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 49)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (253, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 48)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (254, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 47)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (255, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 46)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (256, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 55)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (257, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 54)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (258, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 53)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (259, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 52)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (260, N'649c29ca-b31f-4cda-969b-e40bd70eae74', 51)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (261, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 54)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (262, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 53)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (263, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 52)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (264, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 51)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (265, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 59)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (266, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 58)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (267, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 57)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (268, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', 56)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (269, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 34)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (270, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 38)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (271, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 37)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (272, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 59)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (273, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 57)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (274, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 56)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (275, N'c60e1cf6-8023-423e-899a-274f869f19d5', 43)
            INSERT INTO [dbo].[Likes] ([Id], [AuthorId], [ReviewId]) VALUES (276, N'c60e1cf6-8023-423e-899a-274f869f19d5', 34)
            SET IDENTITY_INSERT [dbo].[Likes] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
