using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F010_INS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F010_INS> Collection( Guid? rowid,
															string key_pat_mstr,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															string ins_acronym,
															decimal? priority_seqmin,
															decimal? priority_seqmax,
															decimal? percentage_to_paymin,
															decimal? percentage_to_paymax,
															string policy_nbr,
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
					new SqlParameter("KEY_PAT_MSTR",key_pat_mstr),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("INS_ACRONYM",ins_acronym),
					new SqlParameter("minPRIORITY_SEQ",priority_seqmin),
					new SqlParameter("maxPRIORITY_SEQ",priority_seqmax),
					new SqlParameter("minPERCENTAGE_TO_PAY",percentage_to_paymin),
					new SqlParameter("maxPERCENTAGE_TO_PAY",percentage_to_paymax),
					new SqlParameter("POLICY_NBR",policy_nbr),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F010_INS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F010_INS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F010_INS_Search]", parameters);
            var collection = new ObservableCollection<F010_INS>();

            while (Reader.Read())
            {
                collection.Add(new F010_INS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					INS_ACRONYM = Reader["INS_ACRONYM"].ToString(),
					PRIORITY_SEQ = ConvertDEC(Reader["PRIORITY_SEQ"]),
					PERCENTAGE_TO_PAY = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
					POLICY_NBR = Reader["POLICY_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalIns_acronym = Reader["INS_ACRONYM"].ToString(),
					_originalPriority_seq = ConvertDEC(Reader["PRIORITY_SEQ"]),
					_originalPercentage_to_pay = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
					_originalPolicy_nbr = Reader["POLICY_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F010_INS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F010_INS> Collection(ObservableCollection<F010_INS>
                                                               f010Ins = null)
        {
            if (IsSameSearch() && f010Ins != null)
            {
                return f010Ins;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F010_INS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("KEY_PAT_MSTR",WhereKey_pat_mstr),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("INS_ACRONYM",WhereIns_acronym),
					new SqlParameter("PRIORITY_SEQ",WherePriority_seq),
					new SqlParameter("PERCENTAGE_TO_PAY",WherePercentage_to_pay),
					new SqlParameter("POLICY_NBR",WherePolicy_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F010_INS_Match]", parameters);
            var collection = new ObservableCollection<F010_INS>();

            while (Reader.Read())
            {
                collection.Add(new F010_INS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					INS_ACRONYM = Reader["INS_ACRONYM"].ToString(),
					PRIORITY_SEQ = ConvertDEC(Reader["PRIORITY_SEQ"]),
					PERCENTAGE_TO_PAY = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
					POLICY_NBR = Reader["POLICY_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereKey_pat_mstr = WhereKey_pat_mstr,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
					_whereIns_acronym = WhereIns_acronym,
					_wherePriority_seq = WherePriority_seq,
					_wherePercentage_to_pay = WherePercentage_to_pay,
					_wherePolicy_nbr = WherePolicy_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalIns_acronym = Reader["INS_ACRONYM"].ToString(),
					_originalPriority_seq = ConvertDEC(Reader["PRIORITY_SEQ"]),
					_originalPercentage_to_pay = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]),
					_originalPolicy_nbr = Reader["POLICY_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereKey_pat_mstr = WhereKey_pat_mstr;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereIns_acronym = WhereIns_acronym;
					_wherePriority_seq = WherePriority_seq;
					_wherePercentage_to_pay = WherePercentage_to_pay;
					_wherePolicy_nbr = WherePolicy_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereKey_pat_mstr == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereIns_acronym == null 
				&& WherePriority_seq == null 
				&& WherePercentage_to_pay == null 
				&& WherePolicy_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereKey_pat_mstr ==  _whereKey_pat_mstr
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereIns_acronym ==  _whereIns_acronym
				&& WherePriority_seq ==  _wherePriority_seq
				&& WherePercentage_to_pay ==  _wherePercentage_to_pay
				&& WherePolicy_nbr ==  _wherePolicy_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereKey_pat_mstr = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereIns_acronym = null; 
			WherePriority_seq = null; 
			WherePercentage_to_pay = null; 
			WherePolicy_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _KEY_PAT_MSTR;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private string _INS_ACRONYM;
		private decimal? _PRIORITY_SEQ;
		private decimal? _PERCENTAGE_TO_PAY;
		private string _POLICY_NBR;
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
		public string KEY_PAT_MSTR
		{
			get { return _KEY_PAT_MSTR; }
			set
			{
				if (_KEY_PAT_MSTR != value)
				{
					_KEY_PAT_MSTR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_NBR
		{
			get { return _CLMHDR_BATCH_NBR; }
			set
			{
				if (_CLMHDR_BATCH_NBR != value)
				{
					_CLMHDR_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CLAIM_NBR
		{
			get { return _CLMHDR_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_CLAIM_NBR != value)
				{
					_CLMHDR_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string INS_ACRONYM
		{
			get { return _INS_ACRONYM; }
			set
			{
				if (_INS_ACRONYM != value)
				{
					_INS_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public decimal? PRIORITY_SEQ
		{
			get { return _PRIORITY_SEQ; }
			set
			{
				if (_PRIORITY_SEQ != value)
				{
					_PRIORITY_SEQ = value;
					ChangeState();
				}
			}
		}
		public decimal? PERCENTAGE_TO_PAY
		{
			get { return _PERCENTAGE_TO_PAY; }
			set
			{
				if (_PERCENTAGE_TO_PAY != value)
				{
					_PERCENTAGE_TO_PAY = value;
					ChangeState();
				}
			}
		}
		public string POLICY_NBR
		{
			get { return _POLICY_NBR; }
			set
			{
				if (_POLICY_NBR != value)
				{
					_POLICY_NBR = value;
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
		public string WhereKey_pat_mstr { get; set; }
		private string _whereKey_pat_mstr;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public string WhereIns_acronym { get; set; }
		private string _whereIns_acronym;
		public decimal? WherePriority_seq { get; set; }
		private decimal? _wherePriority_seq;
		public decimal? WherePercentage_to_pay { get; set; }
		private decimal? _wherePercentage_to_pay;
		public string WherePolicy_nbr { get; set; }
		private string _wherePolicy_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalKey_pat_mstr;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private string _originalIns_acronym;
		private decimal? _originalPriority_seq;
		private decimal? _originalPercentage_to_pay;
		private string _originalPolicy_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			KEY_PAT_MSTR = _originalKey_pat_mstr;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			INS_ACRONYM = _originalIns_acronym;
			PRIORITY_SEQ = _originalPriority_seq;
			PERCENTAGE_TO_PAY = _originalPercentage_to_pay;
			POLICY_NBR = _originalPolicy_nbr;
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
					new SqlParameter("KEY_PAT_MSTR",KEY_PAT_MSTR),
					new SqlParameter("CLMHDR_BATCH_NBR",CLMHDR_BATCH_NBR),
					new SqlParameter("CLMHDR_CLAIM_NBR",CLMHDR_CLAIM_NBR),
					new SqlParameter("INS_ACRONYM",INS_ACRONYM)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_INS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_INS_Purge]");
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
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("INS_ACRONYM", SqlNull(INS_ACRONYM)),
						new SqlParameter("PRIORITY_SEQ", SqlNull(PRIORITY_SEQ)),
						new SqlParameter("PERCENTAGE_TO_PAY", SqlNull(PERCENTAGE_TO_PAY)),
						new SqlParameter("POLICY_NBR", SqlNull(POLICY_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_INS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						INS_ACRONYM = Reader["INS_ACRONYM"].ToString();
						PRIORITY_SEQ = ConvertDEC(Reader["PRIORITY_SEQ"]);
						PERCENTAGE_TO_PAY = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]);
						POLICY_NBR = Reader["POLICY_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalIns_acronym = Reader["INS_ACRONYM"].ToString();
						_originalPriority_seq = ConvertDEC(Reader["PRIORITY_SEQ"]);
						_originalPercentage_to_pay = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]);
						_originalPolicy_nbr = Reader["POLICY_NBR"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("INS_ACRONYM", SqlNull(INS_ACRONYM)),
						new SqlParameter("PRIORITY_SEQ", SqlNull(PRIORITY_SEQ)),
						new SqlParameter("PERCENTAGE_TO_PAY", SqlNull(PERCENTAGE_TO_PAY)),
						new SqlParameter("POLICY_NBR", SqlNull(POLICY_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_INS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						INS_ACRONYM = Reader["INS_ACRONYM"].ToString();
						PRIORITY_SEQ = ConvertDEC(Reader["PRIORITY_SEQ"]);
						PERCENTAGE_TO_PAY = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]);
						POLICY_NBR = Reader["POLICY_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalIns_acronym = Reader["INS_ACRONYM"].ToString();
						_originalPriority_seq = ConvertDEC(Reader["PRIORITY_SEQ"]);
						_originalPercentage_to_pay = ConvertDEC(Reader["PERCENTAGE_TO_PAY"]);
						_originalPolicy_nbr = Reader["POLICY_NBR"].ToString();
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