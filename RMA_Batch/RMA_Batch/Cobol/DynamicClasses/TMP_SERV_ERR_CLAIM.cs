using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_SERV_ERR_CLAIM : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_SERV_ERR_CLAIM> Collection( Guid? rowid,
															string rat_rmb_account_nbr,
															decimal? trailer_t_countmin,
															decimal? trailer_t_countmax,
															string clmhdr_elig_error,
															string clmhdr_serv_error,
															string clmhdr_status_ohip,
															decimal? entry_datemin,
															decimal? entry_datemax,
															decimal? entry_time_longmin,
															decimal? entry_time_longmax,
															string entry_user_id,
															int? checksum_valuemin,
															int? checksum_valuemax,
                                                            string sortcolumn,
                                                            string sortdirection,
                                                            bool replaceSearch,
                                                            int skip)
        {
            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",rowid),
					new SqlParameter("RAT_RMB_ACCOUNT_NBR",rat_rmb_account_nbr),
					new SqlParameter("minTRAILER_T_COUNT",trailer_t_countmin),
					new SqlParameter("maxTRAILER_T_COUNT",trailer_t_countmax),
					new SqlParameter("CLMHDR_ELIG_ERROR",clmhdr_elig_error),
					new SqlParameter("CLMHDR_SERV_ERROR",clmhdr_serv_error),
					new SqlParameter("CLMHDR_STATUS_OHIP",clmhdr_status_ohip),
					new SqlParameter("minENTRY_DATE",entry_datemin),
					new SqlParameter("maxENTRY_DATE",entry_datemax),
					new SqlParameter("minENTRY_TIME_LONG",entry_time_longmin),
					new SqlParameter("maxENTRY_TIME_LONG",entry_time_longmax),
					new SqlParameter("ENTRY_USER_ID",entry_user_id),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_SERV_ERR_CLAIM>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_Search]", parameters);
            var collection = new ObservableCollection<TMP_SERV_ERR_CLAIM>();

            while (Reader.Read())
            {
                collection.Add(new TMP_SERV_ERR_CLAIM
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
					CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString(),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_SERV_ERR_CLAIM Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_SERV_ERR_CLAIM> Collection(ObservableCollection<TMP_SERV_ERR_CLAIM>
                                                               tmpServErrClaim = null)
        {
            if (IsSameSearch() && tmpServErrClaim != null)
            {
                return tmpServErrClaim;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_SERV_ERR_CLAIM>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RAT_RMB_ACCOUNT_NBR",WhereRat_rmb_account_nbr),
					new SqlParameter("TRAILER_T_COUNT",WhereTrailer_t_count),
					new SqlParameter("CLMHDR_ELIG_ERROR",WhereClmhdr_elig_error),
					new SqlParameter("CLMHDR_SERV_ERROR",WhereClmhdr_serv_error),
					new SqlParameter("CLMHDR_STATUS_OHIP",WhereClmhdr_status_ohip),
					new SqlParameter("ENTRY_DATE",WhereEntry_date),
					new SqlParameter("ENTRY_TIME_LONG",WhereEntry_time_long),
					new SqlParameter("ENTRY_USER_ID",WhereEntry_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_Match]", parameters);
            var collection = new ObservableCollection<TMP_SERV_ERR_CLAIM>();

            while (Reader.Read())
            {
                collection.Add(new TMP_SERV_ERR_CLAIM
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
					CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRat_rmb_account_nbr = WhereRat_rmb_account_nbr,
					_whereTrailer_t_count = WhereTrailer_t_count,
					_whereClmhdr_elig_error = WhereClmhdr_elig_error,
					_whereClmhdr_serv_error = WhereClmhdr_serv_error,
					_whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
					_whereEntry_date = WhereEntry_date,
					_whereEntry_time_long = WhereEntry_time_long,
					_whereEntry_user_id = WhereEntry_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]),
					_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString(),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRat_rmb_account_nbr = WhereRat_rmb_account_nbr;
					_whereTrailer_t_count = WhereTrailer_t_count;
					_whereClmhdr_elig_error = WhereClmhdr_elig_error;
					_whereClmhdr_serv_error = WhereClmhdr_serv_error;
					_whereClmhdr_status_ohip = WhereClmhdr_status_ohip;
					_whereEntry_date = WhereEntry_date;
					_whereEntry_time_long = WhereEntry_time_long;
					_whereEntry_user_id = WhereEntry_user_id;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRat_rmb_account_nbr == null 
				&& WhereTrailer_t_count == null 
				&& WhereClmhdr_elig_error == null 
				&& WhereClmhdr_serv_error == null 
				&& WhereClmhdr_status_ohip == null 
				&& WhereEntry_date == null 
				&& WhereEntry_time_long == null 
				&& WhereEntry_user_id == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRat_rmb_account_nbr ==  _whereRat_rmb_account_nbr
				&& WhereTrailer_t_count ==  _whereTrailer_t_count
				&& WhereClmhdr_elig_error ==  _whereClmhdr_elig_error
				&& WhereClmhdr_serv_error ==  _whereClmhdr_serv_error
				&& WhereClmhdr_status_ohip ==  _whereClmhdr_status_ohip
				&& WhereEntry_date ==  _whereEntry_date
				&& WhereEntry_time_long ==  _whereEntry_time_long
				&& WhereEntry_user_id ==  _whereEntry_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRat_rmb_account_nbr = null; 
			WhereTrailer_t_count = null; 
			WhereClmhdr_elig_error = null; 
			WhereClmhdr_serv_error = null; 
			WhereClmhdr_status_ohip = null; 
			WhereEntry_date = null; 
			WhereEntry_time_long = null; 
			WhereEntry_user_id = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RAT_RMB_ACCOUNT_NBR;
		private decimal? _TRAILER_T_COUNT;
		private string _CLMHDR_ELIG_ERROR;
		private string _CLMHDR_SERV_ERROR;
		private string _CLMHDR_STATUS_OHIP;
		private decimal? _ENTRY_DATE;
		private decimal? _ENTRY_TIME_LONG;
		private string _ENTRY_USER_ID;
		private int? _CHECKSUM_VALUE;

		public Guid ROWID
		{
			get { return _ROWID; }
			set
			{
				if (_ROWID != value)
				{
					_ROWID = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ACCOUNT_NBR
		{
			get { return _RAT_RMB_ACCOUNT_NBR; }
			set
			{
				if (_RAT_RMB_ACCOUNT_NBR != value)
				{
					_RAT_RMB_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? TRAILER_T_COUNT
		{
			get { return _TRAILER_T_COUNT; }
			set
			{
				if (_TRAILER_T_COUNT != value)
				{
					_TRAILER_T_COUNT = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ELIG_ERROR
		{
			get { return _CLMHDR_ELIG_ERROR; }
			set
			{
				if (_CLMHDR_ELIG_ERROR != value)
				{
					_CLMHDR_ELIG_ERROR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SERV_ERROR
		{
			get { return _CLMHDR_SERV_ERROR; }
			set
			{
				if (_CLMHDR_SERV_ERROR != value)
				{
					_CLMHDR_SERV_ERROR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_STATUS_OHIP
		{
			get { return _CLMHDR_STATUS_OHIP; }
			set
			{
				if (_CLMHDR_STATUS_OHIP != value)
				{
					_CLMHDR_STATUS_OHIP = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_DATE
		{
			get { return _ENTRY_DATE; }
			set
			{
				if (_ENTRY_DATE != value)
				{
					_ENTRY_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_TIME_LONG
		{
			get { return _ENTRY_TIME_LONG; }
			set
			{
				if (_ENTRY_TIME_LONG != value)
				{
					_ENTRY_TIME_LONG = value;
					ChangeState();
				}
			}
		}
		public string ENTRY_USER_ID
		{
			get { return _ENTRY_USER_ID; }
			set
			{
				if (_ENTRY_USER_ID != value)
				{
					_ENTRY_USER_ID = value;
					ChangeState();
				}
			}
		}
		public int? CHECKSUM_VALUE
		{
			get { return _CHECKSUM_VALUE; }
			set
			{
				if (_CHECKSUM_VALUE != value)
				{
					_CHECKSUM_VALUE = value;
					ChangeState();
				}
			}
		}


        #endregion

        #region Where

		public Guid? WhereRowid { get; set; }
		private Guid? _whereRowid;
		public string WhereRat_rmb_account_nbr { get; set; }
		private string _whereRat_rmb_account_nbr;
		public decimal? WhereTrailer_t_count { get; set; }
		private decimal? _whereTrailer_t_count;
		public string WhereClmhdr_elig_error { get; set; }
		private string _whereClmhdr_elig_error;
		public string WhereClmhdr_serv_error { get; set; }
		private string _whereClmhdr_serv_error;
		public string WhereClmhdr_status_ohip { get; set; }
		private string _whereClmhdr_status_ohip;
		public decimal? WhereEntry_date { get; set; }
		private decimal? _whereEntry_date;
		public decimal? WhereEntry_time_long { get; set; }
		private decimal? _whereEntry_time_long;
		public string WhereEntry_user_id { get; set; }
		private string _whereEntry_user_id;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRat_rmb_account_nbr;
		private decimal? _originalTrailer_t_count;
		private string _originalClmhdr_elig_error;
		private string _originalClmhdr_serv_error;
		private string _originalClmhdr_status_ohip;
		private decimal? _originalEntry_date;
		private decimal? _originalEntry_time_long;
		private string _originalEntry_user_id;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RAT_RMB_ACCOUNT_NBR = _originalRat_rmb_account_nbr;
			TRAILER_T_COUNT = _originalTrailer_t_count;
			CLMHDR_ELIG_ERROR = _originalClmhdr_elig_error;
			CLMHDR_SERV_ERROR = _originalClmhdr_serv_error;
			CLMHDR_STATUS_OHIP = _originalClmhdr_status_ohip;
			ENTRY_DATE = _originalEntry_date;
			ENTRY_TIME_LONG = _originalEntry_time_long;
			ENTRY_USER_ID = _originalEntry_user_id;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
			int RowsAffected = 0;
			var parameters = new SqlParameter[]
				{
					new SqlParameter("RowCheckSum",RowCheckSum),
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("RAT_RMB_ACCOUNT_NBR",RAT_RMB_ACCOUNT_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_Purge]");
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
						new SqlParameter("RAT_RMB_ACCOUNT_NBR", SqlNull(RAT_RMB_ACCOUNT_NBR)),
						new SqlParameter("TRAILER_T_COUNT", SqlNull(TRAILER_T_COUNT)),
						new SqlParameter("CLMHDR_ELIG_ERROR", SqlNull(CLMHDR_ELIG_ERROR)),
						new SqlParameter("CLMHDR_SERV_ERROR", SqlNull(CLMHDR_SERV_ERROR)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString();
						CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString();
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString();
						_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString();
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RAT_RMB_ACCOUNT_NBR", SqlNull(RAT_RMB_ACCOUNT_NBR)),
						new SqlParameter("TRAILER_T_COUNT", SqlNull(TRAILER_T_COUNT)),
						new SqlParameter("CLMHDR_ELIG_ERROR", SqlNull(CLMHDR_ELIG_ERROR)),
						new SqlParameter("CLMHDR_SERV_ERROR", SqlNull(CLMHDR_SERV_ERROR)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_SERV_ERR_CLAIM_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						TRAILER_T_COUNT = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString();
						CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString();
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						_originalTrailer_t_count = ConvertDEC(Reader["TRAILER_T_COUNT"]);
						_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString();
						_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString();
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                   
                    break;
            }
	    CloseConnection();
	     
            RecordState = State.UnChanged;
        }

        #endregion

      
    }
}