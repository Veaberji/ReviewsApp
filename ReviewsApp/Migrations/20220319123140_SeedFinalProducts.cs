using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                SET IDENTITY_INSERT [dbo].[Products] ON
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (32, N'X-Men Origins Wolverine', 1)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (33, N'The Untamed', 1)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (35, N'Kimi | 2022', 1)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (36, N'Fantastic Beasts: The Secrets of Dumbledore | 2022', 1)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (37, N'Gold | 2021', 1)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (39, N'In Search of Lost Time by Marcel Proust', 2)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (40, N'Ulysses by James Joyce', 2)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (41, N'Don Quixote by Miguel de Cervantes', 2)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (42, N'One Hundred Years of Solitude by Gabriel Garcia Marquez', 2)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (43, N'The Great Gatsby by F. Scott Fitzgerald', 2)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (44, N'Grand Theft Auto IV', 3)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (45, N'RED DEAD REDEMPTION 2', 3)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (46, N'Super Mario Galaxy', 3)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (47, N'ELDEN RING', 3)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (48, N'HALF-LIFE 2', 3)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (49, N'Say It Right - Nelly Furtado', 4)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (50, N'Mi Gata - Standly & El Barto', 4)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (51, N'Something In The Way - Nirvana', 4)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (52, N'Finesse - Pheelz & Buju', 4)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (53, N'Pepas - Farruko', 4)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (54, N'Man and Beast', 5)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (55, N'One Big Bag', 5)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (56, N'The Swing', 5)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (57, N'Chandelier of Grief', 5)
                INSERT INTO [dbo].[Products] ([Id], [Name], [Type]) VALUES (58, N'Untitled', 5)
                SET IDENTITY_INSERT [dbo].[Products] OFF
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
