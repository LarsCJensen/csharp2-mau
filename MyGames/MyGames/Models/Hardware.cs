using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGames.Models
{
    /// <summary>
    /// Model for hardware
    /// NOT YET IMPLEMENTED
    /// </summary>
    [Table("Hardware")]
    public class Hardware: Base, IDataErrorInfo
    {
        #region Properties
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
                OnPropertyChanged("Platform");
            }
        }
        #endregion
        // FUTURE Not yet implemented
        #region IDataErrorInfo
        public string Error => throw new NotImplementedException();

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
                    case "PlatformId":
                        validationResult = ValidatePlatform();
                        break;
                }
                return validationResult;
            }
        }
        private string ValidateTitle()
        {
            return String.IsNullOrEmpty(Title) ? "Title cannot be empty" : String.Empty;
        }
                
        private string ValidatePlatform()
        {
            return _platformId == 0 ? "Please select Platform" : String.Empty;
        }
        #endregion
    }
}
