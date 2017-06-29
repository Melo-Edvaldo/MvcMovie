using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                     new Movie
                     {
                         Title = "The Other Side of Heaven",
                         ReleaseDate = DateTime.Parse("2001-12-14"),
                         Genre = "Adventure, Biography, Drama",
                         Rating = "R",
                         Price = 20.09M
                     }
                );
                context.SaveChanges();
            }
        }
    }
}