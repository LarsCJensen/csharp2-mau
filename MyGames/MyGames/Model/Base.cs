using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Model
{
    public abstract class Base 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(150)]        
        public string Title { get; set; }
        // TODO I would prefer setting the default in the database, but it only seems to work in EF core
        [Required]        
        public DateTime? Timestamp { get; set; } = DateTime.Now;
        public DateTime? ReleaseDate { get; set; }
        public int? Condition { get; set; }
        [StringLength(64)]
        public string Image { get; set; }
        public bool? Box { get; set; }
        public bool? Manual { get; set; }
        [StringLength(512)]
        public string Comment { get; set; }

        public Base()
        {
        }
    }
}
