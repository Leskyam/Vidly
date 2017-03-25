namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoreGenresAndMovies : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert Genres on");
            Sql("insert into Genres (Id, Name) values (4, 'Action')");
            Sql("insert into Genres (Id, Name) values (5, 'Family')");
            Sql("insert into Genres (Id, Name) values (6, 'Romance')");
            Sql("set identity_insert Genres off");
            Sql("set identity_insert Movies on");
            Sql("insert into Movies (Id, Name, GenreId) values (3, 'King Kong', 4)");
            Sql("insert into Movies (Id, Name, GenreId) values (4, 'Die Hard', 4)");
            Sql("insert into Movies (Id, Name, GenreId) values (5, 'The Terminator', 4)");
            Sql("insert into Movies (Id, Name, GenreId) values (6, 'Toy Story', 5)");
            Sql("insert into Movies (Id, Name, GenreId) values (7, 'Titanic', 6)");
            Sql("insert into Movies (Id, Name, GenreId) values (8, 'Hangover', 1)");
            Sql("set identity_insert Movies off");
        }

        public override void Down()
        {
        }
    }
}
