using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace dndReboot.ViewModel
{
    public abstract class ViewModelBase :  INotifyPropertyChanged, IDisposable
    {

        protected ViewModelBase()
        {
        }

        public virtual string DisplayName { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            
        }




        public void Dispose()
        {
            this.OnDispose();
        }
        protected virtual void OnDispose()
        {
        }

    }
}
