using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MyGames.Models
{
    /// <summary>
    /// Model for Game
    /// </summary>
    [Table("Games")]
    public class Game : Base, IDataErrorInfo
    {
        private int? _grade;
        public int? Grade 
        { 
            get
            { 
                return _grade;
            }
            set 
            { 
                _grade = value;
                OnPropertyChanged("Grade");
            } 
        }
        [Required]
        private int _genreId;
        public int GenreId
        {
            get
            {
                return _genreId;
            }
            set
            {
                _genreId = value;
                OnPropertyChanged("GenreId");

            }
        }
        private Genre _genre;
        public virtual Genre Genre 
        {
            get 
            {
                return _genre;
            } 
            set
            {
                _genre = value;
                // TODO Is this needed??
                //OnPropertyChanged("Genre");
            }
        }
        // TODO Is the id necessary?        
        private int _platformId;
        public int PlatformId
        {
            get
            {
                return _platformId;
            }
            set
            {
                _platformId = value;
                OnPropertyChanged("PlatformId");

            }
        }
        private Platform _platform;
        public virtual Platform Platform
        {
            get
            {
                return _platform;
            }
            set
            {
                _platform = value;
                // TODO Is this needed??
                //OnPropertyChanged("Platform");
            }
        }

        #region IDataErrorInfo
        public string Error => throw new NotImplementedException();
        /// <summary>
        /// Validation of properties
        /// </summary>
        /// <param name="property">Property to validate</param>
        /// <returns>string</returns>
        public string this[string property]
        {
            get
            {
                string validationResult = String.Empty;
                switch (property)
                {
                    case "Title":
                        validationResult = ValidateTitle();
                        break;
                    case "GenreId":
                        validationResult = ValidateGenre();
                        break;
                    case "PlatformId":
                        validationResult = ValidatePlatform();
                        break;
                }
                return validationResult;
            }
        }
        /// <summary>
        /// Method for validating title
        /// </summary>
        /// <returns>string</returns>
        private string ValidateTitle()
        {
            return String.IsNullOrEmpty(Title) ? "Title cannot be empty" : String.Empty;
        }
        /// <summary>
        /// Method for validating genre
        /// </summary>
        /// <returns>string</returns>
        private string ValidateGenre()
        {
            return _genreId == 0 ? "Please select Genre" : String.Empty;
        }
        /// <summary>
        /// Method for validating platform
        /// </summary>
        /// <returns>string</returns>
        private string ValidatePlatform()
        {
            return _platformId == 0 ? "Please select Platform" : String.Empty;
        }

        #endregion
        public Game()
        {
        }
    }
}