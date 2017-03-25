namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDOBToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: false));
            Sql($"update Customers set Dob = '{DateTime.Now.AddYears(-43)}' where Id = 1");
            Sql($"update Customers set Dob = '{DateTime.Now.AddYears(-35)}' where Id = 2");
        }

        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
