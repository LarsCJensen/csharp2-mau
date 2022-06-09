using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    /// <summary>
    /// Model for platforms
    /// </summary>
    [Table("Platforms")]
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlatformId { get; set; }
        [StringLength(50)]
        public string PlatformName { get; set; }
        [StringLength(15)]
        public string PlatformShort{ get; set; }
        public virtual ICollection<Game> game { get; set; }
        // FUTURE Add hardware
        public Platform()
        {            
        }

    }
}