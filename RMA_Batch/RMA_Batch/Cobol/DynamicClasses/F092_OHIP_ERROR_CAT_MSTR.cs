using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F092_OHIP_ERROR_CAT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F092_OHIP_ERROR_CAT_MSTR> Collection( Guid? rowid,
															string ohip_err_cat_code,
															string ohip_err_cat_description,
															decimal? entry_datemin,
															decimal? entry_datemax,
															decimal? entry_timemin,
															decimal? entry_timemax,
															string entry_user_id,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
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
					new SqlParameter("OHIP_ERR_CAT_CODE",ohip_err_cat_code),
					new SqlParameter("OHIP_ERR_CAT_DESCRIPTION",ohip_err_cat_description),
					new SqlParameter("minENTRY_DATE",entry_datemin),
					new SqlParameter("maxENTRY_DATE",entry_datemax),
					new SqlParameter("minENTRY_TIME",entry_timemin),
					new SqlParameter("maxENTRY_TIME",entry_timemax),
					new SqlParameter("ENTRY_USER_ID",entry_user_id),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F092_OHIP_ERROR_CAT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F092_OHIP_ERROR_CAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F092_OHIP_ERROR_CAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OHIP_ERR_CAT_CODE = Reader["OHIP_ERR_CAT_CODE"].ToString(),
					OHIP_ERR_CAT_DESCRIPTION = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME = ConvertDEC(Reader["ENTRY_TIME"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOhip_err_cat_code = Reader["OHIP_ERR_CAT_CODE"].ToString(),
					_originalOhip_err_cat_description = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time = ConvertDEC(Reader["ENTRY_TIME"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F092_OHIP_ERROR_CAT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F092_OHIP_ERROR_CAT_MSTR> Collection(ObservableCollection<F092_OHIP_ERROR_CAT_MSTR>
                                                               f092OhipErrorCatMstr = null)
        {
            if (IsSameSearch() && f092OhipErrorCatMstr != null)
            {
                return f092OhipErrorCatMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F092_OHIP_ERROR_CAT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("OHIP_ERR_CAT_CODE",WhereOhip_err_cat_code),
					new SqlParameter("OHIP_ERR_CAT_DESCRIPTION",WhereOhip_err_cat_description),
					new SqlParameter("ENTRY_DATE",WhereEntry_date),
					new SqlParameter("ENTRY_TIME",WhereEntry_time),
					new SqlParameter("ENTRY_USER_ID",WhereEntry_user_id),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F092_OHIP_ERROR_CAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F092_OHIP_ERROR_CAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					OHIP_ERR_CAT_CODE = Reader["OHIP_ERR_CAT_CODE"].ToString(),
					OHIP_ERR_CAT_DESCRIPTION = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME = ConvertDEC(Reader["ENTRY_TIME"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereOhip_err_cat_code = WhereOhip_err_cat_code,
					_whereOhip_err_cat_description = WhereOhip_err_cat_description,
					_whereEntry_date = WhereEntry_date,
					_whereEntry_time = WhereEntry_time,
					_whereEntry_user_id = WhereEntry_user_id,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOhip_err_cat_code = Reader["OHIP_ERR_CAT_CODE"].ToString(),
					_originalOhip_err_cat_description = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time = ConvertDEC(Reader["ENTRY_TIME"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereOhip_err_cat_code = WhereOhip_err_cat_code;
					_whereOhip_err_cat_description = WhereOhip_err_cat_description;
					_whereEntry_date = WhereEntry_date;
					_whereEntry_time = WhereEntry_time;
					_whereEntry_user_id = WhereEntry_user_id;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereOhip_err_cat_code == null 
				&& WhereOhip_err_cat_description == null 
				&& WhereEntry_date == null 
				&& WhereEntry_time == null 
				&& WhereEntry_user_id == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereOhip_err_cat_code ==  _whereOhip_err_cat_code
				&& WhereOhip_err_cat_description ==  _whereOhip_err_cat_description
				&& WhereEntry_date ==  _whereEntry_date
				&& WhereEntry_time ==  _whereEntry_time
				&& WhereEntry_user_id ==  _whereEntry_user_id
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereOhip_err_cat_code = null; 
			WhereOhip_err_cat_description = null; 
			WhereEntry_date = null; 
			WhereEntry_time = null; 
			WhereEntry_user_id = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _OHIP_ERR_CAT_CODE;
		private string _OHIP_ERR_CAT_DESCRIPTION;
		private decimal? _ENTRY_DATE;
		private decimal? _ENTRY_TIME;
		private string _ENTRY_USER_ID;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
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
		public string OHIP_ERR_CAT_CODE
		{
			get { return _OHIP_ERR_CAT_CODE; }
			set
			{
				if (_OHIP_ERR_CAT_CODE != value)
				{
					_OHIP_ERR_CAT_CODE = value;
					ChangeState();
				}
			}
		}
		public string OHIP_ERR_CAT_DESCRIPTION
		{
			get { return _OHIP_ERR_CAT_DESCRIPTION; }
			set
			{
				if (_OHIP_ERR_CAT_DESCRIPTION != value)
				{
					_OHIP_ERR_CAT_DESCRIPTION = value;
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
		public decimal? ENTRY_TIME
		{
			get { return _ENTRY_TIME; }
			set
			{
				if (_ENTRY_TIME != value)
				{
					_ENTRY_TIME = value;
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
		public decimal? LAST_MOD_DATE
		{
			get { return _LAST_MOD_DATE; }
			set
			{
				if (_LAST_MOD_DATE != value)
				{
					_LAST_MOD_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_TIME
		{
			get { return _LAST_MOD_TIME; }
			set
			{
				if (_LAST_MOD_TIME != value)
				{
					_LAST_MOD_TIME = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_USER_ID
		{
			get { return _LAST_MOD_USER_ID; }
			set
			{
				if (_LAST_MOD_USER_ID != value)
				{
					_LAST_MOD_USER_ID = value;
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
		public string WhereOhip_err_cat_code { get; set; }
		private string _whereOhip_err_cat_code;
		public string WhereOhip_err_cat_description { get; set; }
		private string _whereOhip_err_cat_description;
		public decimal? WhereEntry_date { get; set; }
		private decimal? _whereEntry_date;
		public decimal? WhereEntry_time { get; set; }
		private decimal? _whereEntry_time;
		public string WhereEntry_user_id { get; set; }
		private string _whereEntry_user_id;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalOhip_err_cat_code;
		private string _originalOhip_err_cat_description;
		private decimal? _originalEntry_date;
		private decimal? _originalEntry_time;
		private string _originalEntry_user_id;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			OHIP_ERR_CAT_CODE = _originalOhip_err_cat_code;
			OHIP_ERR_CAT_DESCRIPTION = _originalOhip_err_cat_description;
			ENTRY_DATE = _originalEntry_date;
			ENTRY_TIME = _originalEntry_time;
			ENTRY_USER_ID = _originalEntry_user_id;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
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
					new SqlParameter("OHIP_ERR_CAT_CODE",OHIP_ERR_CAT_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_Purge]");
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
						new SqlParameter("OHIP_ERR_CAT_CODE", SqlNull(OHIP_ERR_CAT_CODE)),
						new SqlParameter("OHIP_ERR_CAT_DESCRIPTION", SqlNull(OHIP_ERR_CAT_DESCRIPTION)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME", SqlNull(ENTRY_TIME)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OHIP_ERR_CAT_CODE = Reader["OHIP_ERR_CAT_CODE"].ToString();
						OHIP_ERR_CAT_DESCRIPTION = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME = ConvertDEC(Reader["ENTRY_TIME"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOhip_err_cat_code = Reader["OHIP_ERR_CAT_CODE"].ToString();
						_originalOhip_err_cat_description = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time = ConvertDEC(Reader["ENTRY_TIME"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("OHIP_ERR_CAT_CODE", SqlNull(OHIP_ERR_CAT_CODE)),
						new SqlParameter("OHIP_ERR_CAT_DESCRIPTION", SqlNull(OHIP_ERR_CAT_DESCRIPTION)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME", SqlNull(ENTRY_TIME)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F092_OHIP_ERROR_CAT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						OHIP_ERR_CAT_CODE = Reader["OHIP_ERR_CAT_CODE"].ToString();
						OHIP_ERR_CAT_DESCRIPTION = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME = ConvertDEC(Reader["ENTRY_TIME"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOhip_err_cat_code = Reader["OHIP_ERR_CAT_CODE"].ToString();
						_originalOhip_err_cat_description = Reader["OHIP_ERR_CAT_DESCRIPTION"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time = ConvertDEC(Reader["ENTRY_TIME"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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