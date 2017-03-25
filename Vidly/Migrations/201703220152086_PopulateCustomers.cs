namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Customers on");
            Sql("insert into Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId) values (1, 'John Smith', 0, 1)");
            Sql("insert into Customers (Id, Name, IsSubscribedToNewsletter, MembershipTypeId) values (2, 'Mary Williams', 1, 2)");
            Sql("set identity_insert Customers off");
        }

        public override void Down()
        {
        }
    }
}
