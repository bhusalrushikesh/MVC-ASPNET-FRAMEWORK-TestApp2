namespace TestApp2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'928ea920-e506-4ce2-8c5c-86fb373d458b', N'guest@testapp2.com', 0, N'AL7LcffVJpYTBqJMpFYATH3yAGlxx0SSutm+QiJ86h7ftQkrCBZOKPA82u+9ckgurw==', N'2275e9e7-e460-4882-af05-8471bc649420', NULL, 0, 0, NULL, 1, 0, N'guest@testapp2.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ee03aabf-d74c-4db1-91f1-9b989cf60191', N'admin@testapp2.com', 0, N'ABNw/VMCaPqIqM7uvXQH6QDHpOXlwqNsw4TnL/Vvr3BfBI7tQGlc0ekbSb07Ra3k+Q==', N'2e56cf52-554d-4709-9ada-87db6da5ad5b', NULL, 0, 0, NULL, 1, 0, N'admin@testapp2.com')
                    
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4309f06f-35e4-4fa6-a26e-24e67870a5c4', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ee03aabf-d74c-4db1-91f1-9b989cf60191', N'4309f06f-35e4-4fa6-a26e-24e67870a5c4')


            ");
        }

        public override void Down()
        {
        }
    }
}
