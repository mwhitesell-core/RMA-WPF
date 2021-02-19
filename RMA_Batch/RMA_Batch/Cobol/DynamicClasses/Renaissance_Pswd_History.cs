using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class Renaissance_Pswd_History : BaseTable
    {
        #region Retrieve

        public ObservableCollection<Renaissance_Pswd_History> Collection( string user_name,
															string pswd,
															DateTime? datemin,
															DateTime? datemax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("User_Name",user_name),
					new SqlParameter("Pswd",pswd),
					new SqlParameter("fromDate", ConvertDATE(datemin, true)),
					new SqlParameter("toDate", ConvertDATE(datemax,false)),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_Renaissance_Pswd_History_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<Renaissance_Pswd_History>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_Renaissance_Pswd_History_Search]", parameters);
            var collection = new ObservableCollection<Renaissance_Pswd_History>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Pswd_History
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					User_Name = Convert.ToInt32(Reader["User_Name"]),
					Pswd = Reader["Pswd"].ToString(),
					Date = ConvertDATETIME(Reader["Date"]),

					_originalUser_name = Convert.ToInt32(Reader["User_Name"]),
					_originalPswd = Reader["Pswd"].ToString(),
					_originalDate = ConvertDATETIME(Reader["Date"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public Renaissance_Pswd_History Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<Renaissance_Pswd_History> Collection(ObservableCollection<Renaissance_Pswd_History>
                                                               renaissancePswdHistory = null)
        {
            if (IsSameSearch() && renaissancePswdHistory != null)
            {
                return renaissancePswdHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<Renaissance_Pswd_History>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("User_Name",WhereUser_name),
					new SqlParameter("Pswd",WherePswd),
					new SqlParameter("Date",WhereDate),
				};

			Reader = CoreReader("[INDEXED].[sp_Renaissance_Pswd_History_Match]", parameters);
            var collection = new ObservableCollection<Renaissance_Pswd_History>();

            while (Reader.Read())
            {
                collection.Add(new Renaissance_Pswd_History
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					User_Name = Convert.ToInt32(Reader["User_Name"]),
					Pswd = Reader["Pswd"].ToString(),
					Date = ConvertDATETIME(Reader["Date"]),

					_whereUser_name = WhereUser_name,
					_wherePswd = WherePswd,
					_whereDate = WhereDate,

					_originalUser_name = Convert.ToInt32(Reader["User_Name"]),
					_originalPswd = Reader["Pswd"].ToString(),
					_originalDate = ConvertDATETIME(Reader["Date"]),

                    RecordState = State.UnChanged
                });
            }

					_whereUser_name = WhereUser_name;
					_wherePswd = WherePswd;
					_whereDate = WhereDate;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereUser_name == null 
				&& WherePswd == null 
				&& WhereDate == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereUser_name ==  _whereUser_name
				&& WherePswd ==  _wherePswd
				&& WhereDate ==  _whereDate
;
        }

        private bool ClearSearch()
        {
			WhereUser_name = null; 
			WherePswd = null; 
			WhereDate = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private int _User_Name;
		private string _Pswd;
		private DateTime? _Date;

		public int User_Name
		{
			get { return _User_Name; }
			set
			{
				if (_User_Name != value)
				{
					_User_Name = value;
					ChangeState();
				}
			}
		}
		public string Pswd
		{
			get { return _Pswd; }
			set
			{
				if (_Pswd != value)
				{
					_Pswd = value;
					ChangeState();
				}
			}
		}
		public DateTime? Date
		{
			get { return _Date; }
			set
			{
				if (_Date != value)
				{
					_Date = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public string WhereUser_name { get; set; }
		private string _whereUser_name;
		public string WherePswd { get; set; }
		private string _wherePswd;
		public DateTime? WhereDate { get; set; }
		private DateTime? _whereDate;


        #endregion

        #region Original

		private int _originalUser_name;
		private string _originalPswd;
		private DateTime? _originalDate;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			User_Name = _originalUser_name;
			Pswd = _originalPswd;
			Date = _originalDate;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Pswd_History_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_Renaissance_Pswd_History_Purge]");
		    CloseConnection();
		    return true;
		}


        #endregion

        #region Submit

        public void Submit()
        {
            int RowsAffected = 0;
            SqlParameter[] parameters; 
            switch (RecordState)
            {
                case State.Adding:
                case State.Added:
					parameters = new SqlParameter[]
					{
						new SqlParameter("User_Name", SqlNull(User_Name)),
						new SqlParameter("Pswd", SqlNull(Pswd)),
						new SqlParameter("Date", SqlNull(Date))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Pswd_History_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						User_Name = Convert.ToInt32(Reader["User_Name"]);
						Pswd = Reader["Pswd"].ToString();
						Date = ConvertDATETIME(Reader["Date"]);
						_originalUser_name = Convert.ToInt32(Reader["User_Name"]);
						_originalPswd = Reader["Pswd"].ToString();
						_originalDate = ConvertDATETIME(Reader["Date"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("User_Name", SqlNull(User_Name)),
						new SqlParameter("Pswd", SqlNull(Pswd)),
						new SqlParameter("Date", SqlNull(Date))
					};
					Reader = CoreReader("[INDEXED].[sp_Renaissance_Pswd_History_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						User_Name = Convert.ToInt32(Reader["User_Name"]);
						Pswd = Reader["Pswd"].ToString();
						Date = ConvertDATETIME(Reader["Date"]);
						_originalUser_name = Convert.ToInt32(Reader["User_Name"]);
						_originalPswd = Reader["Pswd"].ToString();
						_originalDate = ConvertDATETIME(Reader["Date"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}