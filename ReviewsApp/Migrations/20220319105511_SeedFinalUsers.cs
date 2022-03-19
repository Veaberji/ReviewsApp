using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedFinalUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'03bf6ef9-de38-43c8-92cf-9f1e8459c86c', N'Alyx', N'ALYX', N'alyx_vance@example.com', N'ALYX_VANCE@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEEZWOJJrKsB2dcpcGvZnpDigNOK5XJyJlElV/wQ63KN86QA6MU/ErA6nCCGkbWairg==', N'UIGDS5LRCJDO257LO7WWDWNKQDKBUAOE', N'6f21d51e-4fa9-4210-8169-11e9512b1abc', NULL, 0, 0, NULL, 1, 0, N'Alyx')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'334cb13b-b0b3-4302-af06-a368c5d5d773', N'Admin', N'ADMIN', N'admin@example.com', N'ADMIN@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEIS/WzpEbkBVylLoDlihK3TkSMqWU+wHWZZo1FC2FSIvXkjFPTY5+Fci2Ihat1tMFA==', N'QZP6PS4HLDKZUANPSF2AS7O3QUHH7B7H', N'90f4f2b2-be3a-4fd7-a3bf-ba6a01512741', NULL, 0, 0, NULL, 1, 0, N'admin')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'3969ed41-dc33-4ef5-af93-8d4e8c6515cf', N'Jim', N'JIM', N'jim@example.com', N'JIM@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEIQLNzYUqeGQ1CQ0m3S21OWQKobEjjnqdzLQP4l2RtLFm0gWW6s7Z8b09Ya2ekVEeg==', N'CONPMDCMXCRINYF5M336NXZ6CZTHCS7E', N'2ae9b6f2-9442-418a-a1eb-d34210509139', NULL, 0, 0, NULL, 1, 0, N'Jim')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'649c29ca-b31f-4cda-969b-e40bd70eae74', N'Amy', N'AMY', N'amy@example.com', N'AMY@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAENzNXNM164049aBx90+D8ARrBpQj45mP3SZtNO+PPUPz9EWI/Bkohr7eHiQirgtAdQ==', N'ZCUW6O4GD45KDFR7PPX46UY3WNU3UYKH', N'6d5a4e1f-ed5d-46df-b173-4fdbe3b89b1d', NULL, 0, 0, NULL, 1, 0, N'amy')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'c60e1cf6-8023-423e-899a-274f869f19d5', N'Jack', N'JACK', N'jack@example.com', N'JACK@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAECVnu35NlDNRHM8Ohp4l7LQXt86pkDcW0F6AMtCYNViCZiAhxo6KRngnwcX2a1tR4Q==', N'45SBCQVYBALKFG56OVJFMJ6YPUAUGAEF', N'4bc19727-848b-433e-858a-525795372f71', NULL, 0, 0, NULL, 1, 0, N'Jack')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [DisplayName]) VALUES (N'e912533c-ff6e-4d58-bec4-734ec8f6a175', N'Joe', N'JOE', N'joe@example.com', N'JOE@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEIQ4rXSFFvMcb2CQjwlspTe2s/OxhP4HGZJ/kfskstLL3nqAwwUSmbpkiQxPz65BjQ==', N'HI3W7BE7TCDQCZU2EDNOM6BFDMTL4G3W', N'54c380bf-4776-48d1-910e-477f84274d44', NULL, 0, 0, NULL, 1, 0, N'joe')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'418a80d6-6429-4eb4-98b2-88459320ae23', N'Admin', N'ADMIN', N'1cd885a4-44c7-42fc-bd38-3e6225773fdb')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'334cb13b-b0b3-4302-af06-a368c5d5d773', N'418a80d6-6429-4eb4-98b2-88459320ae23')
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
