namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreAndMovie : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Genres on");
            Sql("insert into Genres (Id, Name) values (1, 'Comedy')");
            Sql("insert into Genres (Id, Name) values (2, 'Romantic')");
            Sql("insert into Genres (Id, Name) values (3, 'Drama')");
            Sql("set identity_insert Genres off");

            Sql("set identity_insert Movies on");
            Sql("insert into Movies (Id, Name, GenreId) values (1, 'Shrek!', 1)");
            Sql("insert into Movies (Id, Name, GenreId) values (2, 'Well-a', 3)");
            Sql("set identity_insert Movies off");
        }
        
        public override void Down()
        {
        }
    }
}
