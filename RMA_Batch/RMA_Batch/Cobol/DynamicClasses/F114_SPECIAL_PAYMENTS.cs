using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F114_SPECIAL_PAYMENTS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F114_SPECIAL_PAYMENTS> Collection( Guid? rowid,
															string doc_nbr,
															string comp_code,
															string rec_type,
															decimal? ep_nbr_frommin,
															decimal? ep_nbr_frommax,
															decimal? ep_nbr_tomin,
															decimal? ep_nbr_tomax,
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
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("REC_TYPE",rec_type),
					new SqlParameter("minEP_NBR_FROM",ep_nbr_frommin),
					new SqlParameter("maxEP_NBR_FROM",ep_nbr_frommax),
					new SqlParameter("minEP_NBR_TO",ep_nbr_tomin),
					new SqlParameter("maxEP_NBR_TO",ep_nbr_tomax),
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
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F114_SPECIAL_PAYMENTS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_Search]", parameters);
            var collection = new ObservableCollection<F114_SPECIAL_PAYMENTS>();

            while (Reader.Read())
            {
                collection.Add(new F114_SPECIAL_PAYMENTS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					EP_NBR_FROM = ConvertDEC(Reader["EP_NBR_FROM"]),
					EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalEp_nbr_from = ConvertDEC(Reader["EP_NBR_FROM"]),
					_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
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

        public F114_SPECIAL_PAYMENTS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F114_SPECIAL_PAYMENTS> Collection(ObservableCollection<F114_SPECIAL_PAYMENTS>
                                                               f114SpecialPayments = null)
        {
            if (IsSameSearch() && f114SpecialPayments != null)
            {
                return f114SpecialPayments;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F114_SPECIAL_PAYMENTS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("REC_TYPE",WhereRec_type),
					new SqlParameter("EP_NBR_FROM",WhereEp_nbr_from),
					new SqlParameter("EP_NBR_TO",WhereEp_nbr_to),
					new SqlParameter("COMP_UNITS",WhereComp_units),
					new SqlParameter("AMT_GROSS",WhereAmt_gross),
					new SqlParameter("AMT_NET",WhereAmt_net),
					new SqlParameter("EP_NBR_ENTRY",WhereEp_nbr_entry),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_Match]", parameters);
            var collection = new ObservableCollection<F114_SPECIAL_PAYMENTS>();

            while (Reader.Read())
            {
                collection.Add(new F114_SPECIAL_PAYMENTS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					EP_NBR_FROM = ConvertDEC(Reader["EP_NBR_FROM"]),
					EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereComp_code = WhereComp_code,
					_whereRec_type = WhereRec_type,
					_whereEp_nbr_from = WhereEp_nbr_from,
					_whereEp_nbr_to = WhereEp_nbr_to,
					_whereComp_units = WhereComp_units,
					_whereAmt_gross = WhereAmt_gross,
					_whereAmt_net = WhereAmt_net,
					_whereEp_nbr_entry = WhereEp_nbr_entry,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalEp_nbr_from = ConvertDEC(Reader["EP_NBR_FROM"]),
					_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereComp_code = WhereComp_code;
					_whereRec_type = WhereRec_type;
					_whereEp_nbr_from = WhereEp_nbr_from;
					_whereEp_nbr_to = WhereEp_nbr_to;
					_whereComp_units = WhereComp_units;
					_whereAmt_gross = WhereAmt_gross;
					_whereAmt_net = WhereAmt_net;
					_whereEp_nbr_entry = WhereEp_nbr_entry;
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
				&& WhereDoc_nbr == null 
				&& WhereComp_code == null 
				&& WhereRec_type == null 
				&& WhereEp_nbr_from == null 
				&& WhereEp_nbr_to == null 
				&& WhereComp_units == null 
				&& WhereAmt_gross == null 
				&& WhereAmt_net == null 
				&& WhereEp_nbr_entry == null 
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
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereComp_code ==  _whereComp_code
				&& WhereRec_type ==  _whereRec_type
				&& WhereEp_nbr_from ==  _whereEp_nbr_from
				&& WhereEp_nbr_to ==  _whereEp_nbr_to
				&& WhereComp_units ==  _whereComp_units
				&& WhereAmt_gross ==  _whereAmt_gross
				&& WhereAmt_net ==  _whereAmt_net
				&& WhereEp_nbr_entry ==  _whereEp_nbr_entry
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereComp_code = null; 
			WhereRec_type = null; 
			WhereEp_nbr_from = null; 
			WhereEp_nbr_to = null; 
			WhereComp_units = null; 
			WhereAmt_gross = null; 
			WhereAmt_net = null; 
			WhereEp_nbr_entry = null; 
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
		private string _DOC_NBR;
		private string _COMP_CODE;
		private string _REC_TYPE;
		private decimal? _EP_NBR_FROM;
		private decimal? _EP_NBR_TO;
		private decimal? _COMP_UNITS;
		private decimal? _AMT_GROSS;
		private decimal? _AMT_NET;
		private decimal? _EP_NBR_ENTRY;
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
		public string REC_TYPE
		{
			get { return _REC_TYPE; }
			set
			{
				if (_REC_TYPE != value)
				{
					_REC_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_NBR_FROM
		{
			get { return _EP_NBR_FROM; }
			set
			{
				if (_EP_NBR_FROM != value)
				{
					_EP_NBR_FROM = value;
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
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public string WhereRec_type { get; set; }
		private string _whereRec_type;
		public decimal? WhereEp_nbr_from { get; set; }
		private decimal? _whereEp_nbr_from;
		public decimal? WhereEp_nbr_to { get; set; }
		private decimal? _whereEp_nbr_to;
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
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private string _originalComp_code;
		private string _originalRec_type;
		private decimal? _originalEp_nbr_from;
		private decimal? _originalEp_nbr_to;
		private decimal? _originalComp_units;
		private decimal? _originalAmt_gross;
		private decimal? _originalAmt_net;
		private decimal? _originalEp_nbr_entry;
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
			DOC_NBR = _originalDoc_nbr;
			COMP_CODE = _originalComp_code;
			REC_TYPE = _originalRec_type;
			EP_NBR_FROM = _originalEp_nbr_from;
			EP_NBR_TO = _originalEp_nbr_to;
			COMP_UNITS = _originalComp_units;
			AMT_GROSS = _originalAmt_gross;
			AMT_NET = _originalAmt_net;
			EP_NBR_ENTRY = _originalEp_nbr_entry;
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
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("COMP_CODE",COMP_CODE),
					new SqlParameter("REC_TYPE",REC_TYPE),
					new SqlParameter("EP_NBR_FROM",EP_NBR_FROM)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_Purge]");
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
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("EP_NBR_FROM", SqlNull(EP_NBR_FROM)),
						new SqlParameter("EP_NBR_TO", SqlNull(EP_NBR_TO)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						COMP_CODE = Reader["COMP_CODE"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						EP_NBR_FROM = ConvertDEC(Reader["EP_NBR_FROM"]);
						EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]);
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalEp_nbr_from = ConvertDEC(Reader["EP_NBR_FROM"]);
						_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]);
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("EP_NBR_FROM", SqlNull(EP_NBR_FROM)),
						new SqlParameter("EP_NBR_TO", SqlNull(EP_NBR_TO)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F114_SPECIAL_PAYMENTS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						COMP_CODE = Reader["COMP_CODE"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						EP_NBR_FROM = ConvertDEC(Reader["EP_NBR_FROM"]);
						EP_NBR_TO = ConvertDEC(Reader["EP_NBR_TO"]);
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalEp_nbr_from = ConvertDEC(Reader["EP_NBR_FROM"]);
						_originalEp_nbr_to = ConvertDEC(Reader["EP_NBR_TO"]);
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
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