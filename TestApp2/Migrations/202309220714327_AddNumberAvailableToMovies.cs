﻿namespace TestApp2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddNumberAvailableToMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Movies SET NumberAvailable = NoInStock");
        }

        public override void Down()
        {
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
