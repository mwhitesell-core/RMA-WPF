using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
//using Core.DataAccess.SqlServer;
//using Core.DataAccess;
using Core.Framework;
using Core.DataAccess.SqlServer;

namespace RmaDAL
{
    public enum State
    {
        NotSet,
        Added,
        Adding,
        UnChanged,
        Modified,
        Deleted
    }

    public class BaseTable 
    {
        #region Variables

        public string ConnectionString = Common.GetSqlConnectionString(); 
        public DataTable DataTable;
        public string FileFBConnectionString = DALState.Current.FilesConnection;
        public SqlDataReader Reader;
        public StringBuilder Sql;
        public int TakeAmount = Convert.ToInt32(ConfigurationManager.AppSettings["RetrieveAmount"]) + 1;
        public StringBuilder Where;
        public bool PreviousTranaction;

        private SqlConnection _filefbSqlConnection;
        private SqlConnection _sqlConnection;
        public int TotalItemCount { get; set; }

        #endregion

        #region Properties

        private State _recordState = State.Added;
        private int _rownum;

        public int RowNum
        {
            get { return _rownum; }
            set
            {
                if (_rownum != value)
                {
                    _rownum = value;
                    ChangeState();                    
                }
            }
        }

        public State RecordState
        {
            get { return _recordState; }
            set
            {
                if (_recordState != value)
                {
                    _recordState = value;                    
                }
            }
        }

        #endregion

        #region Methods

        public int CoreExecuteNonQuery(string commandText, SqlParameter[] parameters)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, commandText, parameters);
            return SqlHelper.ExecuteNonQuery(DALState.Current.DalTransaction, CommandType.StoredProcedure, commandText,
                                             parameters);
        }

        public int CoreExecuteNonQuery(string commandText)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteNonQuery(Connection(), CommandType.StoredProcedure, commandText);
            return SqlHelper.ExecuteNonQuery(DALState.Current.DalTransaction, CommandType.StoredProcedure, commandText);
        }

        public int CoreExecuteNonQuerySQL(string commandText)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteNonQuery(Connection(), CommandType.Text, commandText);
            return SqlHelper.ExecuteNonQuery(DALState.Current.DalTransaction, CommandType.Text, commandText);
        }

        public SqlDataReader CoreReader(string storedProcedure, SqlParameter[] parameters)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteReader(Connection(), CommandType.StoredProcedure, storedProcedure, parameters);
            return SqlHelper.ExecuteReader(DALState.Current.DalTransaction, CommandType.StoredProcedure, storedProcedure,
                                           parameters);
        }

        public SqlDataReader CoreReader(string storedProcedure, SqlParameter[] parameters,SqlConnection conn)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteReader(conn, CommandType.StoredProcedure, storedProcedure, parameters);
            return SqlHelper.ExecuteReader(DALState.Current.DalTransaction, CommandType.StoredProcedure, storedProcedure,
                                           parameters);
        }

        public SqlDataReader CoreReader(string SQL)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteReader(Connection(), CommandType.Text, SQL);
            return SqlHelper.ExecuteReader(DALState.Current.DalTransaction, CommandType.Text, SQL);
        }

        public SqlDataReader CoreReader(string SQL, SqlConnection con)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteReader(con, CommandType.Text, SQL);
            return SqlHelper.ExecuteReader(DALState.Current.DalTransaction, CommandType.Text, SQL);
        }

        public SqlDataReader CoreFileDBReader(string storedProcedure, SqlParameter[] parameters)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteReader(FileFbConnection(), CommandType.StoredProcedure, storedProcedure,
                                               parameters);
            return SqlHelper.ExecuteReader(DALState.Current.DalTransaction, CommandType.StoredProcedure, storedProcedure,
                                           parameters);
        }

        public int CoreFileDBExecuteNonQuery(string commandText, SqlParameter[] parameters)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteNonQuery(FileFbConnection(), CommandType.StoredProcedure, commandText,
                                                 parameters);
            return SqlHelper.ExecuteNonQuery(DALState.Current.DalTransaction, CommandType.StoredProcedure, commandText,
                                             parameters);
        }

        public int CoreFileDBExecuteNonQuery(string commandText)
        {
            if (DALState.Current.DalTransaction == null)
                return SqlHelper.ExecuteNonQuery(FileFbConnection(), CommandType.StoredProcedure, commandText);
            return SqlHelper.ExecuteNonQuery(DALState.Current.DalTransaction, CommandType.StoredProcedure, commandText);
        }

        public SqlConnection Connection()
        {
            if (_sqlConnection == null)
            {
                _sqlConnection = new SqlConnection(ConnectionString);                
            }
            else if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.ConnectionString = ConnectionString;
                _sqlConnection.Open();                
            }
            return _sqlConnection;
        }

        public void CloseConnection(bool isClose = true)
        {
            if (Reader != null) Reader.Dispose();
            if (_sqlConnection != null)
            {
                if (isClose)
                {
                    _sqlConnection.Close();
                    _sqlConnection.Dispose();
                }
            }
        }

        public SqlConnection FileFbConnection()
        {
            if (_filefbSqlConnection == null)
            {
                _filefbSqlConnection = new SqlConnection(FileFBConnectionString);
                
            }
            else if (_filefbSqlConnection.State == ConnectionState.Closed)
            {
                _filefbSqlConnection.ConnectionString = FileFBConnectionString;
                _filefbSqlConnection.Open();
            }
            return _filefbSqlConnection;
        }

        public void CloseFileFbConnection()
        {
            if (Reader != null) Reader.Dispose();
            if (_filefbSqlConnection != null)
            {
                _filefbSqlConnection.Close();
                _filefbSqlConnection.Dispose();
            }
        }

        public void ChangeState()
        {
            if (RecordState == State.UnChanged)
                RecordState = State.Modified;
            else if (RecordState == State.Added)
                RecordState = State.Adding;
        }

        public string WhereAnd(string value)
        {
            return value.ToUpper().IndexOf(" WHERE ") >= 0 ? " AND " : " WHERE ";
        }

        public string Contains(string value)
        {
            return " LIKE '%" + value + "%' ";
        }

        public int? ConvertINT(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                else
                    return Convert.ToInt32(value);
            }
            catch
            {
                return null;
            }
        }

        public int CovertBoolToBit(bool value)
        {
            if (value)
                return 1;
            return 0;
        }

        public long? ConvertLONG(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                else
                    return Convert.ToInt64(value);
            }
            catch
            {
                return null;
            }
        }

        public DateTime? ConvertDATETIME(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                else
                    return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }

        public string ConvertDATE(DateTime? value, bool min)
        {
            if (value == null)
                return null;
            else
            {
                if (min)
                    return value.Value.ToString("yyyy-MM-dd 00:00:00");
                else
                    return value.Value.ToString("yyyy-MM-dd 23:59:59");
            }
        }

        public bool ConvertBool(object value)
        {
            if (value == null)
                return false;
            return (bool) value;
        }

        public decimal? ConvertDEC(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                else
                    return Convert.ToDecimal(value);
            }
            catch
            {
                return null;
            }
        }

        public string ConvertSTR(object value)
        {
            try
            {
                if (value == DBNull.Value)
                    return null;
                else
                    return value.ToString();
            }
            catch
            {
                return null;
            }
        }

        public int? SqlNull(int? value)
        {
            if (value == null)
                return null;
            else
                return value;
        }

        public int SqlNull(int value)
        {
            if (value == null)
                return 0;
            else
                return value;
        }

        public int SqlNull(bool? value)
        {
            if (value == null)
                return 0;
            else
                return 1;
        }

        public int? SqlNullForiegnKey(int? value)
        {
            if (value == null)
                return null;
            else
                return value;
        }

        public Int64? SqlNullForiegnKey(Int64? value)
        {
            if (value == null)
                return null;
            else
                return value;
        }

        public string SqlNull(string value)
        {
            if (value == null)
                return "";
            else
                return value;
        }

        public decimal? SqlNull(decimal? value)
        {
            if (value == null)
                return 0;
            else
                return value;
        }

        public DateTime? SqlNull(DateTime? value)
        {
            if (value == null || value == new DateTime(1900, 1, 1) || value == new DateTime(0001, 1, 1))
                return null;
            else
                return value;
        }

        public DateTime? SqlNullMinMid(DateTime? value)
        {
            if (value == null || value == new DateTime(1900, 1, 1) || value == new DateTime(0001, 1, 1))
                return null;
            else
                return new DateTime(Convert.ToDateTime(value).Year, Convert.ToDateTime(value).Month,
                                    Convert.ToDateTime(value).Day, 0, 1, 0);
        }


        #endregion
    }
}