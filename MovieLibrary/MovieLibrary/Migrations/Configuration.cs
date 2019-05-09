namespace MovieLibrary.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieLibrary.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieLibrary.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Movies.AddOrUpdate(
    new Models.Movies { Title = "The Departed", Genre = "Drama", DirectorName = "Martin Scorsese" },
    new Models.Movies { Title = "The Dark Knight", Genre = "Drama", DirectorName = "Christopher Nolan" },
    new Models.Movies { Title = "Inception", Genre = "Drama", DirectorName = "Christopher Nolan" },
    new Models.Movies { Title = "Pineapple Express", Genre = "Comedy", DirectorName = "David Gordon Green" },
    new Models.Movies { Title = "Die Hard", Genre = "Action", DirectorName = "John McTiernan" }
);
        }
    }
}
