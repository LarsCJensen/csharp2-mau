using System;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    /// <summary>
    /// DBContext for SQL Server Compact
    /// </summary>
    public class MyGamesSQLServerCompactContext : DbContext
    {
        public MyGamesSQLServerCompactContext()
            : base("name=MyGamesSQLServerCompactContext")
        {
            
        }
        // DBSets for all models used
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }        
    }
}