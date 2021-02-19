using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F119_DOCTOR_YTD_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F119_DOCTOR_YTD_HISTORY> Collection( Guid? rowid,
															string doc_nbr,
															decimal? ep_nbrmin,
															decimal? ep_nbrmax,
															string comp_code,
															decimal? process_seqmin,
															decimal? process_seqmax,
															string comp_code_group,
															string rec_type,
															decimal? amt_mtdmin,
															decimal? amt_mtdmax,
															decimal? amt_ytdmin,
															decimal? amt_ytdmax,
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
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("minPROCESS_SEQ",process_seqmin),
					new SqlParameter("maxPROCESS_SEQ",process_seqmax),
					new SqlParameter("COMP_CODE_GROUP",comp_code_group),
					new SqlParameter("REC_TYPE",rec_type),
					new SqlParameter("minAMT_MTD",amt_mtdmin),
					new SqlParameter("maxAMT_MTD",amt_mtdmax),
					new SqlParameter("minAMT_YTD",amt_ytdmin),
					new SqlParameter("maxAMT_YTD",amt_ytdmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F119_DOCTOR_YTD_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F119_DOCTOR_YTD_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F119_DOCTOR_YTD_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					AMT_MTD = ConvertDEC(Reader["AMT_MTD"]),
					AMT_YTD = ConvertDEC(Reader["AMT_YTD"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]),
					_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F119_DOCTOR_YTD_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F119_DOCTOR_YTD_HISTORY> Collection(ObservableCollection<F119_DOCTOR_YTD_HISTORY>
                                                               f119DoctorYtdHistory = null)
        {
            if (IsSameSearch() && f119DoctorYtdHistory != null)
            {
                return f119DoctorYtdHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F119_DOCTOR_YTD_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("EP_NBR",WhereEp_nbr),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("PROCESS_SEQ",WhereProcess_seq),
					new SqlParameter("COMP_CODE_GROUP",WhereComp_code_group),
					new SqlParameter("REC_TYPE",WhereRec_type),
					new SqlParameter("AMT_MTD",WhereAmt_mtd),
					new SqlParameter("AMT_YTD",WhereAmt_ytd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F119_DOCTOR_YTD_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F119_DOCTOR_YTD_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REC_TYPE = Reader["REC_TYPE"].ToString(),
					AMT_MTD = ConvertDEC(Reader["AMT_MTD"]),
					AMT_YTD = ConvertDEC(Reader["AMT_YTD"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereEp_nbr = WhereEp_nbr,
					_whereComp_code = WhereComp_code,
					_whereProcess_seq = WhereProcess_seq,
					_whereComp_code_group = WhereComp_code_group,
					_whereRec_type = WhereRec_type,
					_whereAmt_mtd = WhereAmt_mtd,
					_whereAmt_ytd = WhereAmt_ytd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalRec_type = Reader["REC_TYPE"].ToString(),
					_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]),
					_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereEp_nbr = WhereEp_nbr;
					_whereComp_code = WhereComp_code;
					_whereProcess_seq = WhereProcess_seq;
					_whereComp_code_group = WhereComp_code_group;
					_whereRec_type = WhereRec_type;
					_whereAmt_mtd = WhereAmt_mtd;
					_whereAmt_ytd = WhereAmt_ytd;
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
				&& WhereComp_code == null 
				&& WhereProcess_seq == null 
				&& WhereComp_code_group == null 
				&& WhereRec_type == null 
				&& WhereAmt_mtd == null 
				&& WhereAmt_ytd == null 
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
				&& WhereComp_code ==  _whereComp_code
				&& WhereProcess_seq ==  _whereProcess_seq
				&& WhereComp_code_group ==  _whereComp_code_group
				&& WhereRec_type ==  _whereRec_type
				&& WhereAmt_mtd ==  _whereAmt_mtd
				&& WhereAmt_ytd ==  _whereAmt_ytd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereEp_nbr = null; 
			WhereComp_code = null; 
			WhereProcess_seq = null; 
			WhereComp_code_group = null; 
			WhereRec_type = null; 
			WhereAmt_mtd = null; 
			WhereAmt_ytd = null; 
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
		private string _COMP_CODE;
		private decimal? _PROCESS_SEQ;
		private string _COMP_CODE_GROUP;
		private string _REC_TYPE;
		private decimal? _AMT_MTD;
		private decimal? _AMT_YTD;
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
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalEp_nbr;
		private string _originalComp_code;
		private decimal? _originalProcess_seq;
		private string _originalComp_code_group;
		private string _originalRec_type;
		private decimal? _originalAmt_mtd;
		private decimal? _originalAmt_ytd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			EP_NBR = _originalEp_nbr;
			COMP_CODE = _originalComp_code;
			PROCESS_SEQ = _originalProcess_seq;
			COMP_CODE_GROUP = _originalComp_code_group;
			REC_TYPE = _originalRec_type;
			AMT_MTD = _originalAmt_mtd;
			AMT_YTD = _originalAmt_ytd;
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
					new SqlParameter("EP_NBR",EP_NBR),
					new SqlParameter("COMP_CODE",COMP_CODE),
					new SqlParameter("PROCESS_SEQ",PROCESS_SEQ),
					new SqlParameter("COMP_CODE_GROUP",COMP_CODE_GROUP),
					new SqlParameter("REC_TYPE",REC_TYPE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_Purge]");
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
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("AMT_MTD", SqlNull(AMT_MTD)),
						new SqlParameter("AMT_YTD", SqlNull(AMT_YTD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						AMT_MTD = ConvertDEC(Reader["AMT_MTD"]);
						AMT_YTD = ConvertDEC(Reader["AMT_YTD"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]);
						_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]);
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
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REC_TYPE", SqlNull(REC_TYPE)),
						new SqlParameter("AMT_MTD", SqlNull(AMT_MTD)),
						new SqlParameter("AMT_YTD", SqlNull(AMT_YTD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F119_DOCTOR_YTD_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						COMP_CODE = Reader["COMP_CODE"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REC_TYPE = Reader["REC_TYPE"].ToString();
						AMT_MTD = ConvertDEC(Reader["AMT_MTD"]);
						AMT_YTD = ConvertDEC(Reader["AMT_YTD"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalRec_type = Reader["REC_TYPE"].ToString();
						_originalAmt_mtd = ConvertDEC(Reader["AMT_MTD"]);
						_originalAmt_ytd = ConvertDEC(Reader["AMT_YTD"]);
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