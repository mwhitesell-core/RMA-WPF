using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F113_DEFAULT_COMP_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F113_DEFAULT_COMP_HISTORY> Collection( Guid? rowid,
															string doc_nbr,
															decimal? ep_yrmin,
															decimal? ep_yrmax,
															decimal? ep_mmmin,
															decimal? ep_mmmax,
															string comp_code,
															decimal? ep_nbr_tomin,
															decimal? ep_nbr_tomax,
															decimal? factormin,
															decimal? factormax,
															string factor_override,
															decimal? comp_unitsmin,
															decimal? comp_unitsmax,
															decimal? amt_grossmin,
															decimal? amt_grossmax,
															decimal? amt_netmin,
															decimal? amt_netmax,
															decimal? ep_nbr_entrymin,
															decimal? ep_nbr_entrymax,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
															string core_comment,
															string filler,
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
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minEP_YR",ep_yrmin),
					new SqlParameter("maxEP_YR",ep_yrmax),
					new SqlParameter("minEP_MM",ep_mmmin),
					new SqlParameter("maxEP_MM",ep_mmmax),
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("minEP_NBR_TO",ep_nbr_tomin),
					new SqlParameter("maxEP_NBR_TO",ep_nbr_tomax),
					new SqlParameter("minFACTOR",factormin),
					new SqlParameter("maxFACTOR",factormax),
					new SqlParameter("FACTOR_OVERRIDE",factor_override),
					new SqlParameter("minCOMP_UNITS",comp_unitsmin),
					new SqlParameter("maxCOMP_UNITS",comp_unitsmax),
					new SqlParameter("minAMT_GROSS",amt_grossmin),
					new SqlParameter("maxAMT_GROSS",amt_grossmax),
					new SqlParameter("minAMT_NET",amt_netmin),
					new SqlParameter("maxAMT_NET",amt_netmax),
					new SqlParameter("minEP_NBR_ENTRY",ep_nbr_entrymin),
					new SqlParameter("maxEP_NBR_ENTRY",ep_nbr_entrymax),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("CORE_COMMENT",core_comment),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F113_DEFAULT_COMP_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F113_DEFAULT_COMP_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F113_DEFAULT_COMP_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					EP_MM = ConvertDEC(Reader["EP_MM"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString(),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CORE_COMMENT = Reader["CORE_COMMENT"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalEp_mm = ConvertDEC(Reader["EP_MM"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString(),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalCore_comment = Reader["CORE_COMMENT"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F113_DEFAULT_COMP_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F113_DEFAULT_COMP_HISTORY> Collection(ObservableCollection<F113_DEFAULT_COMP_HISTORY>
                                                               f113DefaultCompHistory = null)
        {
            if (IsSameSearch() && f113DefaultCompHistory != null)
            {
                return f113DefaultCompHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F113_DEFAULT_COMP_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("EP_YR",WhereEp_yr),
					new SqlParameter("EP_MM",WhereEp_mm),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("EP_NBR_TO",WhereEp_nbr_to),
					new SqlParameter("FACTOR",WhereFactor),
					new SqlParameter("FACTOR_OVERRIDE",WhereFactor_override),
					new SqlParameter("COMP_UNITS",WhereComp_units),
					new SqlParameter("AMT_GROSS",WhereAmt_gross),
					new SqlParameter("AMT_NET",WhereAmt_net),
					new SqlParameter("EP_NBR_ENTRY",WhereEp_nbr_entry),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CORE_COMMENT",WhereCore_comment),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F113_DEFAULT_COMP_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F113_DEFAULT_COMP_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					EP_MM = ConvertDEC(Reader["EP_MM"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString(),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CORE_COMMENT = Reader["CORE_COMMENT"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereEp_yr = WhereEp_yr,
					_whereEp_mm = WhereEp_mm,
					_whereComp_code = WhereComp_code,
					_whereEp_nbr_to = WhereEp_nbr_to,
					_whereFactor = WhereFactor,
					_whereFactor_override = WhereFactor_override,
					_whereComp_units = WhereComp_units,
					_whereAmt_gross = WhereAmt_gross,
					_whereAmt_net = WhereAmt_net,
					_whereEp_nbr_entry = WhereEp_nbr_entry,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereCore_comment = WhereCore_comment,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalEp_mm = ConvertDEC(Reader["EP_MM"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString(),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalCore_comment = Reader["CORE_COMMENT"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereEp_yr = WhereEp_yr;
					_whereEp_mm = WhereEp_mm;
					_whereComp_code = WhereComp_code;
					_whereEp_nbr_to = WhereEp_nbr_to;
					_whereFactor = WhereFactor;
					_whereFactor_override = WhereFactor_override;
					_whereComp_units = WhereComp_units;
					_whereAmt_gross = WhereAmt_gross;
					_whereAmt_net = WhereAmt_net;
					_whereEp_nbr_entry = WhereEp_nbr_entry;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
					_whereCore_comment = WhereCore_comment;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereEp_yr == null 
				&& WhereEp_mm == null 
				&& WhereComp_code == null 
				&& WhereEp_nbr_to == null 
				&& WhereFactor == null 
				&& WhereFactor_override == null 
				&& WhereComp_units == null 
				&& WhereAmt_gross == null 
				&& WhereAmt_net == null 
				&& WhereEp_nbr_entry == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereCore_comment == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereEp_yr ==  _whereEp_yr
				&& WhereEp_mm ==  _whereEp_mm
				&& WhereComp_code ==  _whereComp_code
				&& WhereEp_nbr_to ==  _whereEp_nbr_to
				&& WhereFactor ==  _whereFactor
				&& WhereFactor_override ==  _whereFactor_override
				&& WhereComp_units ==  _whereComp_units
				&& WhereAmt_gross ==  _whereAmt_gross
				&& WhereAmt_net ==  _whereAmt_net
				&& WhereEp_nbr_entry ==  _whereEp_nbr_entry
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereCore_comment ==  _whereCore_comment
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereEp_yr = null; 
			WhereEp_mm = null; 
			WhereComp_code = null; 
			WhereEp_nbr_to = null; 
			WhereFactor = null; 
			WhereFactor_override = null; 
			WhereComp_units = null; 
			WhereAmt_gross = null; 
			WhereAmt_net = null; 
			WhereEp_nbr_entry = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
			WhereCore_comment = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _EP_YR;
		private decimal? _EP_MM;
		private string _COMP_CODE;
		private decimal? _EP_NBR_TO;
		private decimal? _FACTOR;
		private string _FACTOR_OVERRIDE;
		private decimal? _COMP_UNITS;
		private decimal? _AMT_GROSS;
		private decimal? _AMT_NET;
		private decimal? _EP_NBR_ENTRY;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
		private string _CORE_COMMENT;
		private string _FILLER;
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
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_YR
		{
			get { return _EP_YR; }
			set
			{
				if (_EP_YR != value)
				{
					_EP_YR = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_MM
		{
			get { return _EP_MM; }
			set
			{
				if (_EP_MM != value)
				{
					_EP_MM = value;
					ChangeState();
				}
			}
		}
		public string COMP_CODE
		{
			get { return _COMP_CODE; }
			set
			{
				if (_COMP_CODE != value)
				{
					_COMP_CODE = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_NBR_TO
		{
			get { return _EP_NBR_TO; }
			set
			{
				if (_EP_NBR_TO != value)
				{
					_EP_NBR_TO = value;
					ChangeState();
				}
			}
		}
		public decimal? FACTOR
		{
			get { return _FACTOR; }
			set
			{
				if (_FACTOR != value)
				{
					_FACTOR = value;
					ChangeState();
				}
			}
		}
		public string FACTOR_OVERRIDE
		{
			get { return _FACTOR_OVERRIDE; }
			set
			{
				if (_FACTOR_OVERRIDE != value)
				{
					_FACTOR_OVERRIDE = value;
					ChangeState();
				}
			}
		}
		public decimal? COMP_UNITS
		{
			get { return _COMP_UNITS; }
			set
			{
				if (_COMP_UNITS != value)
				{
					_COMP_UNITS = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_GROSS
		{
			get { return _AMT_GROSS; }
			set
			{
				if (_AMT_GROSS != value)
				{
					_AMT_GROSS = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_NET
		{
			get { return _AMT_NET; }
			set
			{
				if (_AMT_NET != value)
				{
					_AMT_NET = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_NBR_ENTRY
		{
			get { return _EP_NBR_ENTRY; }
			set
			{
				if (_EP_NBR_ENTRY != value)
				{
					_EP_NBR_ENTRY = value;
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
		public string CORE_COMMENT
		{
			get { return _CORE_COMMENT; }
			set
			{
				if (_CORE_COMMENT != value)
				{
					_CORE_COMMENT = value;
					ChangeState();
				}
			}
		}
		public string FILLER
		{
			get { return _FILLER; }
			set
			{
				if (_FILLER != value)
				{
					_FILLER = value;
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
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereEp_yr { get; set; }
		private decimal? _whereEp_yr;
		public decimal? WhereEp_mm { get; set; }
		private decimal? _whereEp_mm;
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public decimal? WhereEp_nbr_to { get; set; }
		private decimal? _whereEp_nbr_to;
		public decimal? WhereFactor { get; set; }
		private decimal? _whereFactor;
		public string WhereFactor_override { get; set; }
		private string _whereFactor_override;
		public decimal? WhereComp_units { get; set; }
		private decimal? _whereComp_units;
		public decimal? WhereAmt_gross { get; set; }
		private decimal? _whereAmt_gross;
		public decimal? WhereAmt_net { get; set; }
		private decimal? _whereAmt_net;
		public decimal? WhereEp_nbr_entry { get; set; }
		private decimal? _whereEp_nbr_entry;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public string WhereCore_comment { get; set; }
		private string _whereCore_comment;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalEp_yr;
		private decimal? _originalEp_mm;
		private string _originalComp_code;
		private decimal? _originalEp_nbr_to;
		private decimal? _originalFactor;
		private string _originalFactor_override;
		private decimal? _originalComp_units;
		private decimal? _originalAmt_gross;
		private decimal? _originalAmt_net;
		private decimal? _originalEp_nbr_entry;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private string _originalCore_comment;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			EP_YR = _originalEp_yr;
			EP_MM = _originalEp_mm;
			COMP_CODE = _originalComp_code;
			EP_NBR_TO = _originalEp_nbr_to;
			FACTOR = _originalFactor;
			FACTOR_OVERRIDE = _originalFactor_override;
			COMP_UNITS = _originalComp_units;
			AMT_GROSS = _originalAmt_gross;
			AMT_NET = _originalAmt_net;
			EP_NBR_ENTRY = _originalEp_nbr_entry;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
			CORE_COMMENT = _originalCore_comment;
			FILLER = _originalFiller;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_Purge]");
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("EP_MM", SqlNull(EP_MM)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("EP_NBR_TO", SqlNull(EP_NBR_TO)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("FACTOR_OVERRIDE", SqlNull(FACTOR_OVERRIDE)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CORE_COMMENT", SqlNull(CORE_COMMENT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						EP_MM = ConvertDEC(Reader["EP_MM"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]);
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString();
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CORE_COMMENT = Reader["CORE_COMMENT"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalEp_mm = ConvertDEC(Reader["EP_MM"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]);
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString();
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalCore_comment = Reader["CORE_COMMENT"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("EP_MM", SqlNull(EP_MM)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("EP_NBR_TO", SqlNull(EP_NBR_TO)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("FACTOR_OVERRIDE", SqlNull(FACTOR_OVERRIDE)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CORE_COMMENT", SqlNull(CORE_COMMENT)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F113_DEFAULT_COMP_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						EP_MM = ConvertDEC(Reader["EP_MM"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]);
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString();
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CORE_COMMENT = Reader["CORE_COMMENT"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalEp_mm = ConvertDEC(Reader["EP_MM"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]);
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString();
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalCore_comment = Reader["CORE_COMMENT"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
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