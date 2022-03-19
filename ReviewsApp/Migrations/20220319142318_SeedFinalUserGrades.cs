using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalUserGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[UserGrades] ON
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (45, 4, 39, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (46, 3, 40, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (47, 4, 41, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (48, 5, 42, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (50, 4, 44, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (51, 3, 45, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (52, 5, 46, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (53, 3, 47, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (54, 4, 52, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (55, 3, 51, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (56, 4, 50, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (57, 5, 49, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (58, 4, 57, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (59, 4, 56, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (60, 4, 55, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (61, 5, 54, N'e912533c-ff6e-4d58-bec4-734ec8f6a175')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (62, 4, 36, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (63, 3, 35, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (64, 4, 33, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (65, 4, 32, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (66, 4, 47, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (67, 4, 46, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (68, 4, 45, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (69, 5, 44, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (70, 4, 52, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (71, 2, 51, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (72, 2, 50, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (73, 3, 49, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (74, 3, 57, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (75, 3, 56, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (76, 4, 55, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (77, 4, 54, N'649c29ca-b31f-4cda-969b-e40bd70eae74')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (78, 4, 36, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (79, 5, 35, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (80, 4, 33, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (81, 5, 32, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (82, 5, 42, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (83, 3, 41, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (84, 4, 40, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (85, 4, 39, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (86, 5, 52, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (87, 3, 51, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (88, 4, 50, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (91, 5, 49, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (92, 4, 57, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (93, 5, 56, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (94, 3, 55, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (95, 4, 54, N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (96, 5, 36, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (97, 3, 35, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (98, 5, 33, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (99, 5, 32, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (100, 5, 42, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (101, 4, 41, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (102, 4, 40, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (103, 4, 39, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (104, 4, 47, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (105, 4, 46, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (106, 3, 45, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (107, 5, 44, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (108, 4, 57, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (109, 4, 56, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (110, 4, 55, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (111, 4, 54, N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (112, 4, 36, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (113, 3, 35, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (114, 4, 33, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (115, 5, 32, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (116, 5, 42, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (117, 4, 41, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (118, 2, 40, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (119, 3, 39, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (120, 4, 47, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (121, 3, 46, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (122, 4, 45, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (123, 3, 44, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (124, 5, 52, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (125, 3, 51, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (126, 3, 50, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            INSERT INTO [dbo].[UserGrades] ([Id], [Grade], [ProductId], [UserId]) VALUES (127, 4, 49, N'c60e1cf6-8023-423e-899a-274f869f19d5')
            SET IDENTITY_INSERT [dbo].[UserGrades] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
