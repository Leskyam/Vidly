namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCustomerColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewletter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
