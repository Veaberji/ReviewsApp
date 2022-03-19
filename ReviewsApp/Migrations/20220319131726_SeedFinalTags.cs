using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Tags] ON
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (23, N'movie', 5)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (24, N'x-men', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (25, N'good', 8)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (26, N'omg', 9)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (27, N'untamed', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (30, N'kimi', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (31, N'like-it', 3)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (32, N'fantastic-beasts', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (33, N'not-bad', 10)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (34, N'gold', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (35, N'book', 5)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (36, N'ulysses', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (37, N'quixote', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (38, N'nice', 2)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (39, N'marquez', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (40, N'gatsby', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (41, N'game', 5)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (42, N'gta4', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (43, N'rdr2', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (44, N'mario', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (45, N'eldern-ring', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (46, N'hl2', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (47, N'classic', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (48, N'music', 5)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (49, N'nelly-furtado', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (50, N'awesome', 2)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (51, N'standly', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (52, N'nirvana', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (53, N'pheelz-buju', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (54, N'farruko', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (55, N'art', 5)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (56, N'man-and-beast', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (57, N'one-big-bag', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (58, N'the-swing', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (59, N'kusama', 1)
            INSERT INTO [dbo].[Tags] ([Id], [Text], [Count]) VALUES (60, N'untitled', 1)
            SET IDENTITY_INSERT [dbo].[Tags] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
