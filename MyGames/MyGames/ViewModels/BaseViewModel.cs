using MyGames.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.ViewModels
{
    /// <summary>
    /// Base ViewModel
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public string DisplayName { get; set; }
        // Property changed event handler
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real, public, instance property on this object. 
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;                                               
                throw new VerifyPropertyException(msg);                
            }
        }        
    }
}
