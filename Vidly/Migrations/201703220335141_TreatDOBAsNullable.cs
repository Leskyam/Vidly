namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TreatDOBAsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime());
            Sql("update Customers set Dob = null where Id = 2");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime(nullable: false));
        }
    }
}
