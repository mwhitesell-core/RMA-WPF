using System.Data.SqlClient;

namespace RmaDAL
{
    public sealed class DALState
    {
        #region Singleton Behavior

        private static DALState _current;

        public static DALState Current
        {
            get { return _current ?? (_current = new DALState()); }
            internal set { _current = value; }
        }

        #endregion

        //public AppUser CurrentUser { get; set; }

        #region Transaction

        public SqlTransaction DalTransaction { get; set; }
        public string RmaConnection { get; set; }
        public string FilesConnection { get; set; }
        public string LoggingConnection { get; set; }

        #endregion
    }
}