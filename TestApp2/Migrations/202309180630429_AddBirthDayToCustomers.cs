namespace TestApp2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddBirthDayToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDay");
        }
    }
}
