﻿namespace TestApp2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNameToMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
