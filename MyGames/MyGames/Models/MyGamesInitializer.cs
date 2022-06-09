using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;

namespace MyGames.Models
{
    /// <summary>
    /// Database initializer to create records on database create
    /// </summary>
    public class MyGamesInitializer : DropCreateDatabaseIfModelChanges<MyGamesSQLServerCompactContext>
    {
        protected override void Seed(MyGamesSQLServerCompactContext context)
        {
            // Create genres
            // TODO Will be added through form in future
            GetGenres().ForEach(g => context.Genres.Add(g));
            // Create platforms
            // TODO Will be added through form in future
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
                },
                new Genre
                {
                    GenreName = "RPG"
                },
                new Genre
                {
                    GenreName = "MMO"
                },
                new Genre
                {
                    GenreName = "Racing"
                },
                new Genre
                {
                    GenreName = "RTS"
                },
                new Genre
                {
                    GenreName = "Strategy"
                },
                new Genre
                {
                    GenreName = "Platform"
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
            },
            new Platform
            {
                PlatformName = "Playstation 2",
                PlatformShort = "PS2"
            },
            new Platform
            {
                PlatformName = "Playstation 3",
                PlatformShort = "PS3"
            },
            new Platform
            {
                PlatformName = "Xbox",
                PlatformShort = "Xbox"
            },
            new Platform
            {
                PlatformName = "Nintendo Entertainment System",
                PlatformShort = "NES"
            },
            new Platform
            {
                PlatformName = "Super Nintendo Entertainment System",
                PlatformShort = "SNES"
            },
            new Platform
            {
                PlatformName = "Sega Master System",
                PlatformShort = "SMS"
            },
            new Platform
            {
                PlatformName = "Sega Mega Drive",
                PlatformShort = "SMD"
            },
            new Platform
            {
                PlatformName = "Atari 2600",
                PlatformShort = "Atari 2600"
            }
        };
            return platforms;
        }
    }
}
