using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            SET IDENTITY_INSERT [dbo].[Comments] ON
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (27, N'Qui maxime accusantium aut accusamus obcaecati est quia temporibus. Ex quod nemo est voluptatem mollitia non maiores consequatur et temporibus explicabo.', N'2022-03-19 15:09:18', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 54)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (28, N'Quo officiis aliquam aut tenetur quia qui nostrum dignissimos 33 possimus minus vel velit iure non doloremque quae ut recusandae consequatur.', N'2022-03-19 15:09:49', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 53)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (29, N'Quo eius recusandae in deserunt corrupti non vero voluptatum vel cupiditate autem ab repellendus eaque ad laborum reiciendis et sunt nesciunt.', N'2022-03-19 15:10:01', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 52)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (30, N'Qui nihil adipisci sed nihil debitis est similique sapiente ut reprehenderit nisi aut perspiciatis debitis ut aliquid architecto et dolorum consequatur. Aut iure rerum rerum beatae 33 nemo totam. ', N'2022-03-19 15:10:12', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 51)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (31, N'Est amet quasi et adipisci consequatur qui quibusdam libero ut iusto dignissimos sed sint totam est facere exercitationem.', N'2022-03-19 15:10:36', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 60)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (32, N'Hic voluptas minus ut distinctio illo hic aliquid assumenda ut perspiciatis omnis sit nihil eligendi.', N'2022-03-19 15:10:50', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 59)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (33, N'Est repudiandae vitae et aliquam molestiae ut omnis ipsam et placeat minima?Aut repudiandae fugit eos accusantium atque qui illo galisum.', N'2022-03-19 15:11:04', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 58)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (34, N'Qui natus Quis eligendi veritatis sit veniam natus aut nisi autem aut consectetur cumque.', N'2022-03-19 15:11:15', N'e912533c-ff6e-4d58-bec4-734ec8f6a175', 57)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (35, N'33 rerum dolorem et consequatur quae non voluptate quia sed tempore vitae.Aut quae asperiores ex quas quisquam aut illum fuga sed quod assumenda aut culpa unde.', N'2022-03-19 15:12:00', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 55)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (36, N'Vel corrupti tenetur qui dolore fugit ab voluptatum dolor qui pariatur quisquam qui omnis distinctio est deserunt quaerat.Ab aspernatur omnis est ullam internos ab modi unde?', N'2022-03-19 15:12:20', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 54)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (37, N'Aut possimus sequi et rerum nostrum eum atque internos.', N'2022-03-19 15:12:28', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 53)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (38, N'Et recusandae quod 33 dolor vero ut nesciunt aspernatur vel sequi quas ab aperiam incidunt ut omnis itaque enim autem. ', N'2022-03-19 15:12:50', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 59)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (39, N'Ab quia temporibus ut rerum sint hic illum Quis. Est delectus aut voluptatibus explicabo in voluptas consequatur ut quis voluptas est dolores cupiditate.', N'2022-03-19 15:13:06', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 58)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (40, N'Quo soluta harum est inventore neque et neque repellendus vel enim aliquid et galisum sequi rem voluptas libero.', N'2022-03-19 15:13:15', N'649c29ca-b31f-4cda-969b-e40bd70eae74', 57)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (41, N'Qui debitis culpa provident libero sit temporibus quas sed nesciunt magnam non voluptas minus est ipsa debitis eum reprehenderit earum?', N'2022-03-19 15:13:54', N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 60)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (42, N'Est reiciendis error ut tenetur dolorem qui veniam minus sit alias quam qui fugit iure At laborum officiis sit consequatur maxime.', N'2022-03-19 15:14:23', N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 59)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (43, N'Est tempora quam a odit possimus est impedit fuga et blanditiis numquam cum accusantium magni eum facilis necessitatibus. Est optio beatae et iste quas rem provident accusantium nam ipsam repudiandae.', N'2022-03-19 15:14:48', N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 54)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (44, N'Ut reprehenderit molestiae sit expedita dolorem ea accusantium sapiente quo laudantium tempore et cupiditate quia At velit quia.', N'2022-03-19 15:15:09', N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', 52)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (45, N'Non officiis internos aut dicta reiciendis qui quisquam provident est beatae necessitatibus. Ut quos nihil est fugiat aspernatur quo reprehenderit dolore!', N'2022-03-19 15:15:44', N'c60e1cf6-8023-423e-899a-274f869f19d5', 55)
            INSERT INTO [dbo].[Comments] ([Id], [Body], [PublishingDate], [AuthorId], [ReviewId]) VALUES (46, N'Non vero dolorem aut eaque iste et recusandae autem qui omnis eveniet ad unde sapiente est eveniet eligendi sit quod molestiae. Qui libero rerum a voluptates ipsam et nesciunt blanditiis ut eveniet laboriosam. Et enim cupiditate quo similique necessitatibus et autem quia cum nobis dolores At tempora exercitationem sed quia praesentium.', N'2022-03-19 15:16:07', N'c60e1cf6-8023-423e-899a-274f869f19d5', 60)
            SET IDENTITY_INSERT [dbo].[Comments] OFF
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
