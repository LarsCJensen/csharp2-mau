using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyGames.Models
{
    public class MyGamesInitializer : DropCreateDatabaseIfModelChanges<MyGamesSQLServerCompactContext>
    {
        protected override void Seed(MyGamesSQLServerCompactContext context)
        {
            GetGenres().ForEach(g => context.Genres.Add(g));
            GetPlatforms().ForEach(p => context.Platforms.Add(p));
        }
        private static List<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>
            {
                new Genre
                {
                    GenreName = "Action"
                },
                new Genre
                {
                    GenreName = "Adventure"
                }
            };
            return genres;
        }
        private static List<Platform> GetPlatforms()
        {
            List<Platform> platforms = new List<Platform>
        {
            new Platform
            {
                PlatformName = "Playstation 1",
                PlatformShort = "PS1"
            },
            new Platform
            {
                PlatformName = "PC",
                PlatformShort = "PC"
            }
        };
            return platforms;
        }
    }
}
