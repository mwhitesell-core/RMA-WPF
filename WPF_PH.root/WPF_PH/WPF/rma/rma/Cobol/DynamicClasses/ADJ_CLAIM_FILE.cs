using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class ADJ_CLAIM_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<ADJ_CLAIM_FILE> Collection( Guid? rowid,
															string adj_batch_nbr,
															decimal? adj_claim_nbrmin,
															decimal? adj_claim_nbrmax,
															string adj_oma_cd_suff,
															decimal? adj_serv_datemin,
															decimal? adj_serv_datemax,
															decimal? adj_agent_cdmin,
															decimal? adj_agent_cdmax,
															string adj_pat_acronym,
															decimal? adj_amt_balmin,
															decimal? adj_amt_balmax,
															decimal? adj_diag_cdmin,
															decimal? adj_diag_cdmax,
															decimal? adj_line_nomin,
															decimal? adj_line_nomax,
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
					new SqlParameter("ADJ_BATCH_NBR",adj_batch_nbr),
					new SqlParameter("minADJ_CLAIM_NBR",adj_claim_nbrmin),
					new SqlParameter("maxADJ_CLAIM_NBR",adj_claim_nbrmax),
					new SqlParameter("ADJ_OMA_CD_SUFF",adj_oma_cd_suff),
					new SqlParameter("minADJ_SERV_DATE",adj_serv_datemin),
					new SqlParameter("maxADJ_SERV_DATE",adj_serv_datemax),
					new SqlParameter("minADJ_AGENT_CD",adj_agent_cdmin),
					new SqlParameter("maxADJ_AGENT_CD",adj_agent_cdmax),
					new SqlParameter("ADJ_PAT_ACRONYM",adj_pat_acronym),
					new SqlParameter("minADJ_AMT_BAL",adj_amt_balmin),
					new SqlParameter("maxADJ_AMT_BAL",adj_amt_balmax),
					new SqlParameter("minADJ_DIAG_CD",adj_diag_cdmin),
					new SqlParameter("maxADJ_DIAG_CD",adj_diag_cdmax),
					new SqlParameter("minADJ_LINE_NO",adj_line_nomin),
					new SqlParameter("maxADJ_LINE_NO",adj_line_nomax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<ADJ_CLAIM_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_Search]", parameters);
            var collection = new ObservableCollection<ADJ_CLAIM_FILE>();

            while (Reader.Read())
            {
                collection.Add(new ADJ_CLAIM_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ADJ_BATCH_NBR = Reader["ADJ_BATCH_NBR"].ToString(),
					ADJ_CLAIM_NBR = ConvertDEC(Reader["ADJ_CLAIM_NBR"]),
					ADJ_OMA_CD_SUFF = Reader["ADJ_OMA_CD_SUFF"].ToString(),
					ADJ_SERV_DATE = ConvertDEC(Reader["ADJ_SERV_DATE"]),
					ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					ADJ_PAT_ACRONYM = Reader["ADJ_PAT_ACRONYM"].ToString(),
					ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					ADJ_DIAG_CD = ConvertDEC(Reader["ADJ_DIAG_CD"]),
					ADJ_LINE_NO = ConvertDEC(Reader["ADJ_LINE_NO"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAdj_batch_nbr = Reader["ADJ_BATCH_NBR"].ToString(),
					_originalAdj_claim_nbr = ConvertDEC(Reader["ADJ_CLAIM_NBR"]),
					_originalAdj_oma_cd_suff = Reader["ADJ_OMA_CD_SUFF"].ToString(),
					_originalAdj_serv_date = ConvertDEC(Reader["ADJ_SERV_DATE"]),
					_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					_originalAdj_pat_acronym = Reader["ADJ_PAT_ACRONYM"].ToString(),
					_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					_originalAdj_diag_cd = ConvertDEC(Reader["ADJ_DIAG_CD"]),
					_originalAdj_line_no = ConvertDEC(Reader["ADJ_LINE_NO"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public ADJ_CLAIM_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<ADJ_CLAIM_FILE> Collection(ObservableCollection<ADJ_CLAIM_FILE>
                                                               adjClaimFile = null)
        {
            if (IsSameSearch() && adjClaimFile != null)
            {
                return adjClaimFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<ADJ_CLAIM_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ADJ_BATCH_NBR",WhereAdj_batch_nbr),
					new SqlParameter("ADJ_CLAIM_NBR",WhereAdj_claim_nbr),
					new SqlParameter("ADJ_OMA_CD_SUFF",WhereAdj_oma_cd_suff),
					new SqlParameter("ADJ_SERV_DATE",WhereAdj_serv_date),
					new SqlParameter("ADJ_AGENT_CD",WhereAdj_agent_cd),
					new SqlParameter("ADJ_PAT_ACRONYM",WhereAdj_pat_acronym),
					new SqlParameter("ADJ_AMT_BAL",WhereAdj_amt_bal),
					new SqlParameter("ADJ_DIAG_CD",WhereAdj_diag_cd),
					new SqlParameter("ADJ_LINE_NO",WhereAdj_line_no),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_Match]", parameters);
            var collection = new ObservableCollection<ADJ_CLAIM_FILE>();

            while (Reader.Read())
            {
                collection.Add(new ADJ_CLAIM_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ADJ_BATCH_NBR = Reader["ADJ_BATCH_NBR"].ToString(),
					ADJ_CLAIM_NBR = ConvertDEC(Reader["ADJ_CLAIM_NBR"]),
					ADJ_OMA_CD_SUFF = Reader["ADJ_OMA_CD_SUFF"].ToString(),
					ADJ_SERV_DATE = ConvertDEC(Reader["ADJ_SERV_DATE"]),
					ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					ADJ_PAT_ACRONYM = Reader["ADJ_PAT_ACRONYM"].ToString(),
					ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					ADJ_DIAG_CD = ConvertDEC(Reader["ADJ_DIAG_CD"]),
					ADJ_LINE_NO = ConvertDEC(Reader["ADJ_LINE_NO"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAdj_batch_nbr = WhereAdj_batch_nbr,
					_whereAdj_claim_nbr = WhereAdj_claim_nbr,
					_whereAdj_oma_cd_suff = WhereAdj_oma_cd_suff,
					_whereAdj_serv_date = WhereAdj_serv_date,
					_whereAdj_agent_cd = WhereAdj_agent_cd,
					_whereAdj_pat_acronym = WhereAdj_pat_acronym,
					_whereAdj_amt_bal = WhereAdj_amt_bal,
					_whereAdj_diag_cd = WhereAdj_diag_cd,
					_whereAdj_line_no = WhereAdj_line_no,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAdj_batch_nbr = Reader["ADJ_BATCH_NBR"].ToString(),
					_originalAdj_claim_nbr = ConvertDEC(Reader["ADJ_CLAIM_NBR"]),
					_originalAdj_oma_cd_suff = Reader["ADJ_OMA_CD_SUFF"].ToString(),
					_originalAdj_serv_date = ConvertDEC(Reader["ADJ_SERV_DATE"]),
					_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					_originalAdj_pat_acronym = Reader["ADJ_PAT_ACRONYM"].ToString(),
					_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					_originalAdj_diag_cd = ConvertDEC(Reader["ADJ_DIAG_CD"]),
					_originalAdj_line_no = ConvertDEC(Reader["ADJ_LINE_NO"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAdj_batch_nbr = WhereAdj_batch_nbr;
					_whereAdj_claim_nbr = WhereAdj_claim_nbr;
					_whereAdj_oma_cd_suff = WhereAdj_oma_cd_suff;
					_whereAdj_serv_date = WhereAdj_serv_date;
					_whereAdj_agent_cd = WhereAdj_agent_cd;
					_whereAdj_pat_acronym = WhereAdj_pat_acronym;
					_whereAdj_amt_bal = WhereAdj_amt_bal;
					_whereAdj_diag_cd = WhereAdj_diag_cd;
					_whereAdj_line_no = WhereAdj_line_no;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereAdj_batch_nbr == null 
				&& WhereAdj_claim_nbr == null 
				&& WhereAdj_oma_cd_suff == null 
				&& WhereAdj_serv_date == null 
				&& WhereAdj_agent_cd == null 
				&& WhereAdj_pat_acronym == null 
				&& WhereAdj_amt_bal == null 
				&& WhereAdj_diag_cd == null 
				&& WhereAdj_line_no == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereAdj_batch_nbr ==  _whereAdj_batch_nbr
				&& WhereAdj_claim_nbr ==  _whereAdj_claim_nbr
				&& WhereAdj_oma_cd_suff ==  _whereAdj_oma_cd_suff
				&& WhereAdj_serv_date ==  _whereAdj_serv_date
				&& WhereAdj_agent_cd ==  _whereAdj_agent_cd
				&& WhereAdj_pat_acronym ==  _whereAdj_pat_acronym
				&& WhereAdj_amt_bal ==  _whereAdj_amt_bal
				&& WhereAdj_diag_cd ==  _whereAdj_diag_cd
				&& WhereAdj_line_no ==  _whereAdj_line_no
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereAdj_batch_nbr = null; 
			WhereAdj_claim_nbr = null; 
			WhereAdj_oma_cd_suff = null; 
			WhereAdj_serv_date = null; 
			WhereAdj_agent_cd = null; 
			WhereAdj_pat_acronym = null; 
			WhereAdj_amt_bal = null; 
			WhereAdj_diag_cd = null; 
			WhereAdj_line_no = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _ADJ_BATCH_NBR;
		private decimal? _ADJ_CLAIM_NBR;
		private string _ADJ_OMA_CD_SUFF;
		private decimal? _ADJ_SERV_DATE;
		private decimal? _ADJ_AGENT_CD;
		private string _ADJ_PAT_ACRONYM;
		private decimal? _ADJ_AMT_BAL;
		private decimal? _ADJ_DIAG_CD;
		private decimal? _ADJ_LINE_NO;
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
		public string ADJ_BATCH_NBR
		{
			get { return _ADJ_BATCH_NBR; }
			set
			{
				if (_ADJ_BATCH_NBR != value)
				{
					_ADJ_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_CLAIM_NBR
		{
			get { return _ADJ_CLAIM_NBR; }
			set
			{
				if (_ADJ_CLAIM_NBR != value)
				{
					_ADJ_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string ADJ_OMA_CD_SUFF
		{
			get { return _ADJ_OMA_CD_SUFF; }
			set
			{
				if (_ADJ_OMA_CD_SUFF != value)
				{
					_ADJ_OMA_CD_SUFF = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_SERV_DATE
		{
			get { return _ADJ_SERV_DATE; }
			set
			{
				if (_ADJ_SERV_DATE != value)
				{
					_ADJ_SERV_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_AGENT_CD
		{
			get { return _ADJ_AGENT_CD; }
			set
			{
				if (_ADJ_AGENT_CD != value)
				{
					_ADJ_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string ADJ_PAT_ACRONYM
		{
			get { return _ADJ_PAT_ACRONYM; }
			set
			{
				if (_ADJ_PAT_ACRONYM != value)
				{
					_ADJ_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_AMT_BAL
		{
			get { return _ADJ_AMT_BAL; }
			set
			{
				if (_ADJ_AMT_BAL != value)
				{
					_ADJ_AMT_BAL = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_DIAG_CD
		{
			get { return _ADJ_DIAG_CD; }
			set
			{
				if (_ADJ_DIAG_CD != value)
				{
					_ADJ_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_LINE_NO
		{
			get { return _ADJ_LINE_NO; }
			set
			{
				if (_ADJ_LINE_NO != value)
				{
					_ADJ_LINE_NO = value;
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
		public string WhereAdj_batch_nbr { get; set; }
		private string _whereAdj_batch_nbr;
		public decimal? WhereAdj_claim_nbr { get; set; }
		private decimal? _whereAdj_claim_nbr;
		public string WhereAdj_oma_cd_suff { get; set; }
		private string _whereAdj_oma_cd_suff;
		public decimal? WhereAdj_serv_date { get; set; }
		private decimal? _whereAdj_serv_date;
		public decimal? WhereAdj_agent_cd { get; set; }
		private decimal? _whereAdj_agent_cd;
		public string WhereAdj_pat_acronym { get; set; }
		private string _whereAdj_pat_acronym;
		public decimal? WhereAdj_amt_bal { get; set; }
		private decimal? _whereAdj_amt_bal;
		public decimal? WhereAdj_diag_cd { get; set; }
		private decimal? _whereAdj_diag_cd;
		public decimal? WhereAdj_line_no { get; set; }
		private decimal? _whereAdj_line_no;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalAdj_batch_nbr;
		private decimal? _originalAdj_claim_nbr;
		private string _originalAdj_oma_cd_suff;
		private decimal? _originalAdj_serv_date;
		private decimal? _originalAdj_agent_cd;
		private string _originalAdj_pat_acronym;
		private decimal? _originalAdj_amt_bal;
		private decimal? _originalAdj_diag_cd;
		private decimal? _originalAdj_line_no;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ADJ_BATCH_NBR = _originalAdj_batch_nbr;
			ADJ_CLAIM_NBR = _originalAdj_claim_nbr;
			ADJ_OMA_CD_SUFF = _originalAdj_oma_cd_suff;
			ADJ_SERV_DATE = _originalAdj_serv_date;
			ADJ_AGENT_CD = _originalAdj_agent_cd;
			ADJ_PAT_ACRONYM = _originalAdj_pat_acronym;
			ADJ_AMT_BAL = _originalAdj_amt_bal;
			ADJ_DIAG_CD = _originalAdj_diag_cd;
			ADJ_LINE_NO = _originalAdj_line_no;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_Purge]");
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
						new SqlParameter("ADJ_BATCH_NBR", SqlNull(ADJ_BATCH_NBR)),
						new SqlParameter("ADJ_CLAIM_NBR", SqlNull(ADJ_CLAIM_NBR)),
						new SqlParameter("ADJ_OMA_CD_SUFF", SqlNull(ADJ_OMA_CD_SUFF)),
						new SqlParameter("ADJ_SERV_DATE", SqlNull(ADJ_SERV_DATE)),
						new SqlParameter("ADJ_AGENT_CD", SqlNull(ADJ_AGENT_CD)),
						new SqlParameter("ADJ_PAT_ACRONYM", SqlNull(ADJ_PAT_ACRONYM)),
						new SqlParameter("ADJ_AMT_BAL", SqlNull(ADJ_AMT_BAL)),
						new SqlParameter("ADJ_DIAG_CD", SqlNull(ADJ_DIAG_CD)),
						new SqlParameter("ADJ_LINE_NO", SqlNull(ADJ_LINE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ADJ_BATCH_NBR = Reader["ADJ_BATCH_NBR"].ToString();
						ADJ_CLAIM_NBR = ConvertDEC(Reader["ADJ_CLAIM_NBR"]);
						ADJ_OMA_CD_SUFF = Reader["ADJ_OMA_CD_SUFF"].ToString();
						ADJ_SERV_DATE = ConvertDEC(Reader["ADJ_SERV_DATE"]);
						ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						ADJ_PAT_ACRONYM = Reader["ADJ_PAT_ACRONYM"].ToString();
						ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						ADJ_DIAG_CD = ConvertDEC(Reader["ADJ_DIAG_CD"]);
						ADJ_LINE_NO = ConvertDEC(Reader["ADJ_LINE_NO"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAdj_batch_nbr = Reader["ADJ_BATCH_NBR"].ToString();
						_originalAdj_claim_nbr = ConvertDEC(Reader["ADJ_CLAIM_NBR"]);
						_originalAdj_oma_cd_suff = Reader["ADJ_OMA_CD_SUFF"].ToString();
						_originalAdj_serv_date = ConvertDEC(Reader["ADJ_SERV_DATE"]);
						_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						_originalAdj_pat_acronym = Reader["ADJ_PAT_ACRONYM"].ToString();
						_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						_originalAdj_diag_cd = ConvertDEC(Reader["ADJ_DIAG_CD"]);
						_originalAdj_line_no = ConvertDEC(Reader["ADJ_LINE_NO"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ADJ_BATCH_NBR", SqlNull(ADJ_BATCH_NBR)),
						new SqlParameter("ADJ_CLAIM_NBR", SqlNull(ADJ_CLAIM_NBR)),
						new SqlParameter("ADJ_OMA_CD_SUFF", SqlNull(ADJ_OMA_CD_SUFF)),
						new SqlParameter("ADJ_SERV_DATE", SqlNull(ADJ_SERV_DATE)),
						new SqlParameter("ADJ_AGENT_CD", SqlNull(ADJ_AGENT_CD)),
						new SqlParameter("ADJ_PAT_ACRONYM", SqlNull(ADJ_PAT_ACRONYM)),
						new SqlParameter("ADJ_AMT_BAL", SqlNull(ADJ_AMT_BAL)),
						new SqlParameter("ADJ_DIAG_CD", SqlNull(ADJ_DIAG_CD)),
						new SqlParameter("ADJ_LINE_NO", SqlNull(ADJ_LINE_NO)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_ADJ_CLAIM_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ADJ_BATCH_NBR = Reader["ADJ_BATCH_NBR"].ToString();
						ADJ_CLAIM_NBR = ConvertDEC(Reader["ADJ_CLAIM_NBR"]);
						ADJ_OMA_CD_SUFF = Reader["ADJ_OMA_CD_SUFF"].ToString();
						ADJ_SERV_DATE = ConvertDEC(Reader["ADJ_SERV_DATE"]);
						ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						ADJ_PAT_ACRONYM = Reader["ADJ_PAT_ACRONYM"].ToString();
						ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						ADJ_DIAG_CD = ConvertDEC(Reader["ADJ_DIAG_CD"]);
						ADJ_LINE_NO = ConvertDEC(Reader["ADJ_LINE_NO"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAdj_batch_nbr = Reader["ADJ_BATCH_NBR"].ToString();
						_originalAdj_claim_nbr = ConvertDEC(Reader["ADJ_CLAIM_NBR"]);
						_originalAdj_oma_cd_suff = Reader["ADJ_OMA_CD_SUFF"].ToString();
						_originalAdj_serv_date = ConvertDEC(Reader["ADJ_SERV_DATE"]);
						_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						_originalAdj_pat_acronym = Reader["ADJ_PAT_ACRONYM"].ToString();
						_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						_originalAdj_diag_cd = ConvertDEC(Reader["ADJ_DIAG_CD"]);
						_originalAdj_line_no = ConvertDEC(Reader["ADJ_LINE_NO"]);
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