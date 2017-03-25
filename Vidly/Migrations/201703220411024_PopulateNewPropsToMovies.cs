using System.Diagnostics;
using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNewPropsToMovies : DbMigration
    {
        public override void Up()
        {
            ApplicationDbContext db = ApplicationDbContext.Create();
            foreach (var movie in db.Movies)
            {
                var sql = $"update Movies set ReleaseDate = '{DateTime.Now.AddYears((-movie.Id*2))}', DateAdded = '{DateTime.Now.AddYears(-movie.Id)}', InStock = {movie.Id * 2}";
                Sql(sql);
            }
            db.Dispose();
        }

        public override void Down()
        {
        }
    }
}
