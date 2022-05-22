using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace MyGames.Model
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GenreId { get; set; }
        [StringLength(50)]
        public string GenreName { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public Genre()
        {
            this.Games = new HashSet<Game>();
        }

    }
}