using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMA_Install
{
    public sealed class ApplicationState
    {
        #region Singleton Behavior

        private static ApplicationState _current;

        public static ApplicationState Current
        {
            get { return _current ?? (_current = new ApplicationState()); }
            internal set { _current = value; }
        }

        #endregion


        public string install_directory
        {
            get; set;
        }

        public string install_batch
        {
            get; set;
        }

        public string reportserver
        {
            get; set;
        }

        public string webservice
        {
            get; set;
        }
    }
}
