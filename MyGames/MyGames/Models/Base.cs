using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace MyGames.Models
{
    /// <summary>
    /// Base model with common properties
    /// </summary>
    public abstract class Base : INotifyPropertyChanged
    {
        // Let id be incremented automatically and used as key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int _id;        
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                // Notify if property changed
                OnPropertyChanged("Id");
            }
        }
        // Title is required
        [Required, StringLength(150)]
        private string _title;        
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        // FUTURE
        // This doesn't work without the private declaration.
        // Not sure why
        private DateTime _timestamp;
        // Set default timestamp value
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        private DateTime? _releaseDate;
        public DateTime? ReleaseDate
        {
            get
            {
                return _releaseDate;
            }
            set
            {
                _releaseDate = value;
                OnPropertyChanged("ReleaseDate");
            } 
        }
        private int? _condition;
        public int? Condition {
            get
            {
                return _condition;
            }
            set 
            { 
                _condition = value;
                OnPropertyChanged("Condition");
            } 
        }
        [StringLength(64)]
        private string _image;
        public string Image { 
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        private bool? _box;
        public bool? Box { 
            get {
                return _box;
            } 
            set 
            { 
                _box = value;
                OnPropertyChanged("Box");
            }
        }
        private bool? _manual;
        public bool? Manual
        {
            get
            {
                return _manual;
            }
            set
            {
                _manual = value;
                OnPropertyChanged("Manual");
            }
        }
        [StringLength(512)]
        private string _comment;
        public string Comment 
        { 
            get 
            {
                return _comment;
            }
            set 
            {
                _comment = value;
                OnPropertyChanged("Comment");
            } 
        }
        [StringLength(16)]
        private string _region;
        public string Region
        {
            get
            {
                return _region;
            }
            set
            {
                _region = value;
                OnPropertyChanged("Region");
            }
        }

        public Base()
        {
        }
        #region INotifypropertyChangedMembers
        // Property changed EventHandler
        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion        
    }
}
