using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F110_COMPENSATION_AUDIT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F110_COMPENSATION_AUDIT> Collection( Guid? rowid,
															string doc_nbr,
															decimal? ep_nbrmin,
															decimal? ep_nbrmax,
															decimal? process_seqmin,
															decimal? process_seqmax,
															string comp_code,
															string comp_type,
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
															string compensation_status,
															string last_mod_flag,
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
					new SqlParameter("minEP_NBR",ep_nbrmin),
					new SqlParameter("maxEP_NBR",ep_nbrmax),
					new SqlParameter("minPROCESS_SEQ",process_seqmin),
					new SqlParameter("maxPROCESS_SEQ",process_seqmax),
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("COMP_TYPE",comp_type),
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
					new SqlParameter("COMPENSATION_STATUS",compensation_status),
					new SqlParameter("LAST_MOD_FLAG",last_mod_flag),
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
                Reader = CoreReader("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F110_COMPENSATION_AUDIT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_Search]", parameters);
            var collection = new ObservableCollection<F110_COMPENSATION_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F110_COMPENSATION_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					COMP_TYPE = Reader["COMP_TYPE"].ToString(),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString(),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					COMPENSATION_STATUS = Reader["COMPENSATION_STATUS"].ToString(),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalComp_type = Reader["COMP_TYPE"].ToString(),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString(),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					_originalCompensation_status = Reader["COMPENSATION_STATUS"].ToString(),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
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

        public F110_COMPENSATION_AUDIT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F110_COMPENSATION_AUDIT> Collection(ObservableCollection<F110_COMPENSATION_AUDIT>
                                                               f110CompensationAudit = null)
        {
            if (IsSameSearch() && f110CompensationAudit != null)
            {
                return f110CompensationAudit;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F110_COMPENSATION_AUDIT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("EP_NBR",WhereEp_nbr),
					new SqlParameter("PROCESS_SEQ",WhereProcess_seq),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("COMP_TYPE",WhereComp_type),
					new SqlParameter("FACTOR",WhereFactor),
					new SqlParameter("FACTOR_OVERRIDE",WhereFactor_override),
					new SqlParameter("COMP_UNITS",WhereComp_units),
					new SqlParameter("AMT_GROSS",WhereAmt_gross),
					new SqlParameter("AMT_NET",WhereAmt_net),
					new SqlParameter("EP_NBR_ENTRY",WhereEp_nbr_entry),
					new SqlParameter("COMPENSATION_STATUS",WhereCompensation_status),
					new SqlParameter("LAST_MOD_FLAG",WhereLast_mod_flag),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_Match]", parameters);
            var collection = new ObservableCollection<F110_COMPENSATION_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F110_COMPENSATION_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					COMP_TYPE = Reader["COMP_TYPE"].ToString(),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString(),
					COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]),
					AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]),
					AMT_NET = ConvertDEC(Reader["AMT_NET"]),
					EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					COMPENSATION_STATUS = Reader["COMPENSATION_STATUS"].ToString(),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereEp_nbr = WhereEp_nbr,
					_whereProcess_seq = WhereProcess_seq,
					_whereComp_code = WhereComp_code,
					_whereComp_type = WhereComp_type,
					_whereFactor = WhereFactor,
					_whereFactor_override = WhereFactor_override,
					_whereComp_units = WhereComp_units,
					_whereAmt_gross = WhereAmt_gross,
					_whereAmt_net = WhereAmt_net,
					_whereEp_nbr_entry = WhereEp_nbr_entry,
					_whereCompensation_status = WhereCompensation_status,
					_whereLast_mod_flag = WhereLast_mod_flag,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalComp_type = Reader["COMP_TYPE"].ToString(),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString(),
					_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]),
					_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]),
					_originalAmt_net = ConvertDEC(Reader["AMT_NET"]),
					_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]),
					_originalCompensation_status = Reader["COMPENSATION_STATUS"].ToString(),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereEp_nbr = WhereEp_nbr;
					_whereProcess_seq = WhereProcess_seq;
					_whereComp_code = WhereComp_code;
					_whereComp_type = WhereComp_type;
					_whereFactor = WhereFactor;
					_whereFactor_override = WhereFactor_override;
					_whereComp_units = WhereComp_units;
					_whereAmt_gross = WhereAmt_gross;
					_whereAmt_net = WhereAmt_net;
					_whereEp_nbr_entry = WhereEp_nbr_entry;
					_whereCompensation_status = WhereCompensation_status;
					_whereLast_mod_flag = WhereLast_mod_flag;
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
				&& WhereEp_nbr == null 
				&& WhereProcess_seq == null 
				&& WhereComp_code == null 
				&& WhereComp_type == null 
				&& WhereFactor == null 
				&& WhereFactor_override == null 
				&& WhereComp_units == null 
				&& WhereAmt_gross == null 
				&& WhereAmt_net == null 
				&& WhereEp_nbr_entry == null 
				&& WhereCompensation_status == null 
				&& WhereLast_mod_flag == null 
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
				&& WhereEp_nbr ==  _whereEp_nbr
				&& WhereProcess_seq ==  _whereProcess_seq
				&& WhereComp_code ==  _whereComp_code
				&& WhereComp_type ==  _whereComp_type
				&& WhereFactor ==  _whereFactor
				&& WhereFactor_override ==  _whereFactor_override
				&& WhereComp_units ==  _whereComp_units
				&& WhereAmt_gross ==  _whereAmt_gross
				&& WhereAmt_net ==  _whereAmt_net
				&& WhereEp_nbr_entry ==  _whereEp_nbr_entry
				&& WhereCompensation_status ==  _whereCompensation_status
				&& WhereLast_mod_flag ==  _whereLast_mod_flag
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
			WhereEp_nbr = null; 
			WhereProcess_seq = null; 
			WhereComp_code = null; 
			WhereComp_type = null; 
			WhereFactor = null; 
			WhereFactor_override = null; 
			WhereComp_units = null; 
			WhereAmt_gross = null; 
			WhereAmt_net = null; 
			WhereEp_nbr_entry = null; 
			WhereCompensation_status = null; 
			WhereLast_mod_flag = null; 
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
		private decimal? _EP_NBR;
		private decimal? _PROCESS_SEQ;
		private string _COMP_CODE;
		private string _COMP_TYPE;
		private decimal? _FACTOR;
		private string _FACTOR_OVERRIDE;
		private decimal? _COMP_UNITS;
		private decimal? _AMT_GROSS;
		private decimal? _AMT_NET;
		private decimal? _EP_NBR_ENTRY;
		private string _COMPENSATION_STATUS;
		private string _LAST_MOD_FLAG;
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
		public decimal? EP_NBR
		{
			get { return _EP_NBR; }
			set
			{
				if (_EP_NBR != value)
				{
					_EP_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PROCESS_SEQ
		{
			get { return _PROCESS_SEQ; }
			set
			{
				if (_PROCESS_SEQ != value)
				{
					_PROCESS_SEQ = value;
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
		public string COMP_TYPE
		{
			get { return _COMP_TYPE; }
			set
			{
				if (_COMP_TYPE != value)
				{
					_COMP_TYPE = value;
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
		public string COMPENSATION_STATUS
		{
			get { return _COMPENSATION_STATUS; }
			set
			{
				if (_COMPENSATION_STATUS != value)
				{
					_COMPENSATION_STATUS = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_FLAG
		{
			get { return _LAST_MOD_FLAG; }
			set
			{
				if (_LAST_MOD_FLAG != value)
				{
					_LAST_MOD_FLAG = value;
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
		public decimal? WhereEp_nbr { get; set; }
		private decimal? _whereEp_nbr;
		public decimal? WhereProcess_seq { get; set; }
		private decimal? _whereProcess_seq;
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public string WhereComp_type { get; set; }
		private string _whereComp_type;
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
		public string WhereCompensation_status { get; set; }
		private string _whereCompensation_status;
		public string WhereLast_mod_flag { get; set; }
		private string _whereLast_mod_flag;
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
		private decimal? _originalEp_nbr;
		private decimal? _originalProcess_seq;
		private string _originalComp_code;
		private string _originalComp_type;
		private decimal? _originalFactor;
		private string _originalFactor_override;
		private decimal? _originalComp_units;
		private decimal? _originalAmt_gross;
		private decimal? _originalAmt_net;
		private decimal? _originalEp_nbr_entry;
		private string _originalCompensation_status;
		private string _originalLast_mod_flag;
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
			EP_NBR = _originalEp_nbr;
			PROCESS_SEQ = _originalProcess_seq;
			COMP_CODE = _originalComp_code;
			COMP_TYPE = _originalComp_type;
			FACTOR = _originalFactor;
			FACTOR_OVERRIDE = _originalFactor_override;
			COMP_UNITS = _originalComp_units;
			AMT_GROSS = _originalAmt_gross;
			AMT_NET = _originalAmt_net;
			EP_NBR_ENTRY = _originalEp_nbr_entry;
			COMPENSATION_STATUS = _originalCompensation_status;
			LAST_MOD_FLAG = _originalLast_mod_flag;
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
					new SqlParameter("ROWID",ROWID)
				};
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_Purge]");
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
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("COMP_TYPE", SqlNull(COMP_TYPE)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("FACTOR_OVERRIDE", SqlNull(FACTOR_OVERRIDE)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("COMPENSATION_STATUS", SqlNull(COMPENSATION_STATUS)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						COMP_TYPE = Reader["COMP_TYPE"].ToString();
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString();
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						COMPENSATION_STATUS = Reader["COMPENSATION_STATUS"].ToString();
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalComp_type = Reader["COMP_TYPE"].ToString();
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString();
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						_originalCompensation_status = Reader["COMPENSATION_STATUS"].ToString();
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
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
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("COMP_TYPE", SqlNull(COMP_TYPE)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("FACTOR_OVERRIDE", SqlNull(FACTOR_OVERRIDE)),
						new SqlParameter("COMP_UNITS", SqlNull(COMP_UNITS)),
						new SqlParameter("AMT_GROSS", SqlNull(AMT_GROSS)),
						new SqlParameter("AMT_NET", SqlNull(AMT_NET)),
						new SqlParameter("EP_NBR_ENTRY", SqlNull(EP_NBR_ENTRY)),
						new SqlParameter("COMPENSATION_STATUS", SqlNull(COMPENSATION_STATUS)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F110_COMPENSATION_AUDIT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						COMP_TYPE = Reader["COMP_TYPE"].ToString();
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						FACTOR_OVERRIDE = Reader["FACTOR_OVERRIDE"].ToString();
						COMP_UNITS = ConvertDEC(Reader["COMP_UNITS"]);
						AMT_GROSS = ConvertDEC(Reader["AMT_GROSS"]);
						AMT_NET = ConvertDEC(Reader["AMT_NET"]);
						EP_NBR_ENTRY = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						COMPENSATION_STATUS = Reader["COMPENSATION_STATUS"].ToString();
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalComp_type = Reader["COMP_TYPE"].ToString();
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalFactor_override = Reader["FACTOR_OVERRIDE"].ToString();
						_originalComp_units = ConvertDEC(Reader["COMP_UNITS"]);
						_originalAmt_gross = ConvertDEC(Reader["AMT_GROSS"]);
						_originalAmt_net = ConvertDEC(Reader["AMT_NET"]);
						_originalEp_nbr_entry = ConvertDEC(Reader["EP_NBR_ENTRY"]);
						_originalCompensation_status = Reader["COMPENSATION_STATUS"].ToString();
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
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