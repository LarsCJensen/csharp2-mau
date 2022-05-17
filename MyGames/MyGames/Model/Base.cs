using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Model
{
    public abstract class Base 
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR(250)")]        
        public string Title { get; set; }
        // TODO Set default data
        public DateTime Timestamp { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Condition { get; set; }
        public bool Image { get; set; }
        public bool Box { get; set; }
        public bool Manual { get; set; }
        public string Comment { get; set; }

        public Base()
        {
        }
    }
}
