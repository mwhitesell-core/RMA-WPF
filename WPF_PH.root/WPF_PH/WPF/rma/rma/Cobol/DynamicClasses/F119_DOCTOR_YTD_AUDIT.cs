using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F119_DOCTOR_YTD_AUDIT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F119_DOCTOR_YTD_AUDIT> Collection( Guid? rowid,
															string doc_nbr,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															string comp_code,
															decimal? process_seqmin,
															decimal? process_seqmax,
															string comp_code_group,
															string rec_type,
															decimal? amt_mtdmin,
															decimal? amt_mtdmax,
															decimal? amt_ytdmin,
															decimal? amt_ytdmax,
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
					new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
					new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("minPROCESS_SEQ",process_seqmin),
					new SqlParameter("maxPROCESS_SEQ",process_seqmax),
					new SqlParameter("COMP_CODE_GROUP",comp_code_group),
					new SqlParameter("REC_TYPE",rec_type),
					new SqlParameter("minAMT_MTD",amt_mtdmin),
					new SqlParameter("maxAMT_MTD",amt_mtdmax),
					new SqlParameter("minAMT_YTD",amt_ytdmin),
					new SqlParameter("maxAMT_YTD",amt_ytdmax),
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
                Reader = CoreReader("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F119_DOCTOR_YTD_AUDIT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_Search]", parameters);
            var collection = new ObservableCollection<F119_DOCTOR_YTD_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F119_DOCTOR_YTD_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					AMT_MTD = ConvertDEC(Reader["AMT_MTD"]),
					AMT_YTD = ConvertDEC(Reader["AMT_YTD"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]),
					_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]),
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

        public F119_DOCTOR_YTD_AUDIT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F119_DOCTOR_YTD_AUDIT> Collection(ObservableCollection<F119_DOCTOR_YTD_AUDIT>
                                                               f119DoctorYtdAudit = null)
        {
            if (IsSameSearch() && f119DoctorYtdAudit != null)
            {
                return f119DoctorYtdAudit;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F119_DOCTOR_YTD_AUDIT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("PROCESS_SEQ",WhereProcess_seq),
					new SqlParameter("COMP_CODE_GROUP",WhereComp_code_group),
					new SqlParameter("REC_TYPE",WhereRec_type),
					new SqlParameter("AMT_MTD",WhereAmt_mtd),
					new SqlParameter("AMT_YTD",WhereAmt_ytd),
					new SqlParameter("LAST_MOD_FLAG",WhereLast_mod_flag),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_Match]", parameters);
            var collection = new ObservableCollection<F119_DOCTOR_YTD_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F119_DOCTOR_YTD_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					AMT_MTD = ConvertDEC(Reader["AMT_MTD"]),
					AMT_YTD = ConvertDEC(Reader["AMT_YTD"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereComp_code = WhereComp_code,
					_whereProcess_seq = WhereProcess_seq,
					_whereComp_code_group = WhereComp_code_group,
					_whereRec_type = WhereRec_type,
					_whereAmt_mtd = WhereAmt_mtd,
					_whereAmt_ytd = WhereAmt_ytd,
					_whereLast_mod_flag = WhereLast_mod_flag,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]),
					_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]),
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
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereComp_code = WhereComp_code;
					_whereProcess_seq = WhereProcess_seq;
					_whereComp_code_group = WhereComp_code_group;
					_whereRec_type = WhereRec_type;
					_whereAmt_mtd = WhereAmt_mtd;
					_whereAmt_ytd = WhereAmt_ytd;
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
				&& WhereDoc_ohip_nbr == null 
				&& WhereComp_code == null 
				&& WhereProcess_seq == null 
				&& WhereComp_code_group == null 
				&& WhereRec_type == null 
				&& WhereAmt_mtd == null 
				&& WhereAmt_ytd == null 
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
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereComp_code ==  _whereComp_code
				&& WhereProcess_seq ==  _whereProcess_seq
				&& WhereComp_code_group ==  _whereComp_code_group
				&& WhereRec_type ==  _whereRec_type
				&& WhereAmt_mtd ==  _whereAmt_mtd
				&& WhereAmt_ytd ==  _whereAmt_ytd
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
			WhereDoc_ohip_nbr = null; 
			WhereComp_code = null; 
			WhereProcess_seq = null; 
			WhereComp_code_group = null; 
			WhereRec_type = null; 
			WhereAmt_mtd = null; 
			WhereAmt_ytd = null; 
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
		private decimal? _DOC_OHIP_NBR;
		private string _COMP_CODE;
		private decimal? _PROCESS_SEQ;
		private string _COMP_CODE_GROUP;
		private string _REC_TYPE;
		private decimal? _AMT_MTD;
		private decimal? _AMT_YTD;
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
		public decimal? DOC_OHIP_NBR
		{
			get { return _DOC_OHIP_NBR; }
			set
			{
				if (_DOC_OHIP_NBR != value)
				{
					_DOC_OHIP_NBR = value;
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
		public string COMP_CODE_GROUP
		{
			get { return _COMP_CODE_GROUP; }
			set
			{
				if (_COMP_CODE_GROUP != value)
				{
					_COMP_CODE_GROUP = value;
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
		public decimal? AMT_MTD
		{
			get { return _AMT_MTD; }
			set
			{
				if (_AMT_MTD != value)
				{
					_AMT_MTD = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD
		{
			get { return _AMT_YTD; }
			set
			{
				if (_AMT_YTD != value)
				{
					_AMT_YTD = value;
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
		public decimal? WhereDoc_ohip_nbr { get; set; }
		private decimal? _whereDoc_ohip_nbr;
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public decimal? WhereProcess_seq { get; set; }
		private decimal? _whereProcess_seq;
		public string WhereComp_code_group { get; set; }
		private string _whereComp_code_group;
		public string WhereRec_type { get; set; }
		private string _whereRec_type;
		public decimal? WhereAmt_mtd { get; set; }
		private decimal? _whereAmt_mtd;
		public decimal? WhereAmt_ytd { get; set; }
		private decimal? _whereAmt_ytd;
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
		private decimal? _originalDoc_ohip_nbr;
		private string _originalComp_code;
		private decimal? _originalProcess_seq;
		private string _originalComp_code_group;
		private string _originalRec_type;
		private decimal? _originalAmt_mtd;
		private decimal? _originalAmt_ytd;
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
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			COMP_CODE = _originalComp_code;
			PROCESS_SEQ = _originalProcess_seq;
			COMP_CODE_GROUP = _originalComp_code_group;
			REC_TYPE = _originalRec_type;
			AMT_MTD = _originalAmt_mtd;
			AMT_YTD = _originalAmt_ytd;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_Purge]");
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
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("AMT_MTD", SqlNull(AMT_MTD)),
						new SqlParameter("AMT_YTD", SqlNull(AMT_YTD)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						AMT_MTD = ConvertDEC(Reader["AMT_MTD"]);
						AMT_YTD = ConvertDEC(Reader["AMT_YTD"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]);
						_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]);
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
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("AMT_MTD", SqlNull(AMT_MTD)),
						new SqlParameter("AMT_YTD", SqlNull(AMT_YTD)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F119_DOCTOR_YTD_AUDIT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						AMT_MTD = ConvertDEC(Reader["AMT_MTD"]);
						AMT_YTD = ConvertDEC(Reader["AMT_YTD"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]);
						_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]);
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