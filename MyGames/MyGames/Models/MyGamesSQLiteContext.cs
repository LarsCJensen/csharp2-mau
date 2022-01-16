using System;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    /// <summary>
    /// DBContext for SQLite
    /// NOT USED
    /// </summary>
    public class MyGamesSQLiteContext : DbContext
    {
        public MyGamesSQLiteContext()
            : base("name=MyGamesSQLite")
        {
            Database.SetInitializer(new MyGamesInitializer());
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
    }
}