using System;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    /// <summary>
    /// DBContext for SQL Server Express
    /// NOT USED
    /// </summary>
    public class MyGamesContext : DbContext
    {
        public MyGamesContext()
            : base("name=MyGamesConnectionString")
        {
            // Initializer for database
            Database.SetInitializer(new MyGamesInitializer());
        }

        // DBSets for all models used
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }

    }
}