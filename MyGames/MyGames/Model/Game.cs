using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Model
{
    [Table("Games")]
    public class Game : Base
    {   public int Grade { get; set; }
        // TODO This is also in hardware
        public int GenreId { get; set; }

        // TODO Region
        public Game()
        {
        }

        public class InheritanceMappingContext : DbContext
        {
            public DbSet<Genre> Genre { get; set; }
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}