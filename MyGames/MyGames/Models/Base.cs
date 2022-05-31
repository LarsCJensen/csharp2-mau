using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    public abstract class Base : INotifyPropertyChanged
    {
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
                OnPropertyChanged("Id");
            }
        }
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
        // TODO Why is this needed?
        private DateTime _timestamp;
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
       
        public Base()
        {
        }
        #region INotifypropertyChangedMembers
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
