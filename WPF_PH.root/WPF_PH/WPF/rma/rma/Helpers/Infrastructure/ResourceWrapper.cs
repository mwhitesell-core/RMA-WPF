using System;
using System.ComponentModel;

namespace Core.Resources
{
    /// <summary>
    ///     Wraps access to the strongly typed resource classes so that you can bind
    ///     control properties to resource strings in XAML
    /// </summary>
    public sealed class ResourceWrapper : INotifyPropertyChanged
    {
        // Events.

        // Member variables.
        private static readonly Labels labels = new Labels();
        private static readonly Help help = new Help();
        private static readonly Messages messages = new Messages();


        // INotifyPropertyChanged.

        public Messages Messages
        {
            get { return messages; }
            set { NotifyChange("Messages"); }
        }


        public Labels Labels
        {
            get { return labels; }
            set { NotifyChange("Labels"); }
        }

        public Help Help
        {
            get { return help; }
            set { NotifyChange("Help"); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void NotifyChange(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}