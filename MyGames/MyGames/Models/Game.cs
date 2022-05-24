using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Model
{
    [Table("Games")]
    public class Game : Base
    {   
        public int Grade { get; set; }
        // TODO This is also in hardware
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        // TODO Region
        public Game()
        {
        }        
    }
}