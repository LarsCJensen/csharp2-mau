﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGames.ViewModels
{
    // TODO
    public abstract class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        public string DisplayName { get; set; }
        
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
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real, 
            // public, instance property on this object. 
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                //if (this.ThrowOnInvalidPropertyName)
                //    throw new Exception(msg);
                //else
                //    Debug.Fail(msg);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public event EventHandler RequestClose;
    }
}
