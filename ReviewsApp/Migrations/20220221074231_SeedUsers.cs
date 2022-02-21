using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsApp.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'050c7db2-e6e7-4c7f-b46b-5c6946cd7735', N'Amy', N'AMY', N'amy@example.com', N'AMY@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEAaITvWquRoV0EZCN6IQH/Bts4O3h1/eACQbZ8Yh/miWqSxwqANzMoR+Go8KuKwigw==', N'3QTRSPGGM2Z2ZAO4KF5JVHUHLJIRECW2', N'a971f5ce-639a-491c-a348-5b3b4593952e', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0c53baf5-60f7-4ad4-9c8a-7cd0fb2bd113', N'Jack', N'JACK', N'jack@example.com', N'JACK@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAENGbLHZDMSCVT0h1s0ERTQXAA4pmR9q/RTzRKpWKh5GMsIou17YxcTmCtOy/YlN+FQ==', N'RWYFXCIVEYNQU26U2I2B3VA4KZNIVLGV', N'84fbea64-854f-429b-8e96-4becb59b8fe5', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'5dd01525-b24d-4e44-b2bb-ca08632619e5', N'Alyx', N'ALYX', N'alyx_vance@example.com', N'ALYX_VANCE@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAELKWnObrRwTZ08VRUX4kRSYBhx9haWAp/VqCSYHis9YS/u8MuHVtzKsEdvBNU1Ui8A==', N'IGX3LGJGSQPM7DHUADC2POJVMT74QRZ7', N'776014fc-fda6-4d47-8917-b0d8ab8b32b0', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'a8d38ec2-c535-49b2-8d80-50379a2bf3d7', N'Joe', N'JOE', N'joe@example.com', N'JOE@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEIDnxRRVmiZIN6ulImVlGiNWgRFWHDFmi1HKmuIHvxzwK2s1WzuwxOmmD6ZUWF0Z+g==', N'WESPWKXTR75YM7WRX7IQU5FAGT2BEWKZ', N'7157b676-abf5-4754-b06c-46cc901d2eb6', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'd377db5c-e4ad-4022-9675-1fbadbe7c702', N'Admin', N'ADMIN', N'admin@example.com', N'ADMIN@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEAcKDXEQdVClfCec0G5wxirZUg23JvSzM3ToEYsO3sKdyXx56YLAly1krft/+hQENw==', N'GNB44US5TWDREUMVQCNEPMVDUTXVX4ZH', N'f5ed59d0-62c8-4f54-a861-9cc67481bce8', NULL, 0, 0, NULL, 1, 0)
                INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fde5e3bd-5186-4b88-86f8-56b2db6f070e', N'Jim', N'JIM', N'jim@example.com', N'JIM@EXAMPLE.COM', 0, N'AQAAAAEAACcQAAAAEEqxqBTDQ4puutYSW3YiznJIO86414y4L17yE06yCsE43GzZAjgRSDT7L3ruRrqKNA==', N'AHBTICJE4P5WE7BJTHNXPFA2V2P6WKGO', N'f0f7a5c4-7e04-4b36-ba8a-1064bab4cae0', NULL, 0, 0, NULL, 1, 0)
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'bc89299c-8e5a-4ad2-9f38-78e22a6a9239', N'Admin', N'ADMIN', N'cb136d0a-8671-4ab1-ae06-45bddc49b4b4')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd377db5c-e4ad-4022-9675-1fbadbe7c702', N'bc89299c-8e5a-4ad2-9f38-78e22a6a9239')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
