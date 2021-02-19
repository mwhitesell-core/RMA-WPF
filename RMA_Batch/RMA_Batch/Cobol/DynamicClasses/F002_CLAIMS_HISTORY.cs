using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIMS_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIMS_HISTORY> Collection( Guid? rowid,
															string claim_nbr,
															string clmhdr_date_sys,
															string claim_status,
															decimal? clmhdr_curr_paymentmin,
															decimal? clmhdr_curr_paymentmax,
															decimal? adj_amt_balmin,
															decimal? adj_amt_balmax,
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
					new SqlParameter("CLAIM_NBR",claim_nbr),
					new SqlParameter("CLMHDR_DATE_SYS",clmhdr_date_sys),
					new SqlParameter("CLAIM_STATUS",claim_status),
					new SqlParameter("minCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmin),
					new SqlParameter("maxCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmax),
					new SqlParameter("minADJ_AMT_BAL",adj_amt_balmin),
					new SqlParameter("maxADJ_AMT_BAL",adj_amt_balmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIMS_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
					CLAIM_STATUS = Reader["CLAIM_STATUS"].ToString(),
					CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString(),
					_originalClaim_status = Reader["CLAIM_STATUS"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_CLAIMS_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIMS_HISTORY> Collection(ObservableCollection<F002_CLAIMS_HISTORY>
                                                               f002ClaimsHistory = null)
        {
            if (IsSameSearch() && f002ClaimsHistory != null)
            {
                return f002ClaimsHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIMS_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLAIM_NBR",WhereClaim_nbr),
					new SqlParameter("CLMHDR_DATE_SYS",WhereClmhdr_date_sys),
					new SqlParameter("CLAIM_STATUS",WhereClaim_status),
					new SqlParameter("CLMHDR_CURR_PAYMENT",WhereClmhdr_curr_payment),
					new SqlParameter("ADJ_AMT_BAL",WhereAdj_amt_bal),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
					CLAIM_STATUS = Reader["CLAIM_STATUS"].ToString(),
					CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClaim_nbr = WhereClaim_nbr,
					_whereClmhdr_date_sys = WhereClmhdr_date_sys,
					_whereClaim_status = WhereClaim_status,
					_whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
					_whereAdj_amt_bal = WhereAdj_amt_bal,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString(),
					_originalClaim_status = Reader["CLAIM_STATUS"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClaim_nbr = WhereClaim_nbr;
					_whereClmhdr_date_sys = WhereClmhdr_date_sys;
					_whereClaim_status = WhereClaim_status;
					_whereClmhdr_curr_payment = WhereClmhdr_curr_payment;
					_whereAdj_amt_bal = WhereAdj_amt_bal;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClaim_nbr == null 
				&& WhereClmhdr_date_sys == null 
				&& WhereClaim_status == null 
				&& WhereClmhdr_curr_payment == null 
				&& WhereAdj_amt_bal == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClaim_nbr ==  _whereClaim_nbr
				&& WhereClmhdr_date_sys ==  _whereClmhdr_date_sys
				&& WhereClaim_status ==  _whereClaim_status
				&& WhereClmhdr_curr_payment ==  _whereClmhdr_curr_payment
				&& WhereAdj_amt_bal ==  _whereAdj_amt_bal
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClaim_nbr = null; 
			WhereClmhdr_date_sys = null; 
			WhereClaim_status = null; 
			WhereClmhdr_curr_payment = null; 
			WhereAdj_amt_bal = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLAIM_NBR;
		private string _CLMHDR_DATE_SYS;
		private string _CLAIM_STATUS;
		private decimal? _CLMHDR_CURR_PAYMENT;
		private decimal? _ADJ_AMT_BAL;
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
		public string CLAIM_NBR
		{
			get { return _CLAIM_NBR; }
			set
			{
				if (_CLAIM_NBR != value)
				{
					_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_DATE_SYS
		{
			get { return _CLMHDR_DATE_SYS; }
			set
			{
				if (_CLMHDR_DATE_SYS != value)
				{
					_CLMHDR_DATE_SYS = value;
					ChangeState();
				}
			}
		}
		public string CLAIM_STATUS
		{
			get { return _CLAIM_STATUS; }
			set
			{
				if (_CLAIM_STATUS != value)
				{
					_CLAIM_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CURR_PAYMENT
		{
			get { return _CLMHDR_CURR_PAYMENT; }
			set
			{
				if (_CLMHDR_CURR_PAYMENT != value)
				{
					_CLMHDR_CURR_PAYMENT = value;
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
		public string WhereClaim_nbr { get; set; }
		private string _whereClaim_nbr;
		public string WhereClmhdr_date_sys { get; set; }
		private string _whereClmhdr_date_sys;
		public string WhereClaim_status { get; set; }
		private string _whereClaim_status;
		public decimal? WhereClmhdr_curr_payment { get; set; }
		private decimal? _whereClmhdr_curr_payment;
		public decimal? WhereAdj_amt_bal { get; set; }
		private decimal? _whereAdj_amt_bal;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClaim_nbr;
		private string _originalClmhdr_date_sys;
		private string _originalClaim_status;
		private decimal? _originalClmhdr_curr_payment;
		private decimal? _originalAdj_amt_bal;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLAIM_NBR = _originalClaim_nbr;
			CLMHDR_DATE_SYS = _originalClmhdr_date_sys;
			CLAIM_STATUS = _originalClaim_status;
			CLMHDR_CURR_PAYMENT = _originalClmhdr_curr_payment;
			ADJ_AMT_BAL = _originalAdj_amt_bal;
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
					new SqlParameter("CLAIM_NBR",CLAIM_NBR),
					new SqlParameter("CLMHDR_DATE_SYS",CLMHDR_DATE_SYS),
					new SqlParameter("CLAIM_STATUS",CLAIM_STATUS)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_HISTORY_Purge]");
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
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_DATE_SYS", SqlNull(CLMHDR_DATE_SYS)),
						new SqlParameter("CLAIM_STATUS", SqlNull(CLAIM_STATUS)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("ADJ_AMT_BAL", SqlNull(ADJ_AMT_BAL)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString();
						CLAIM_STATUS = Reader["CLAIM_STATUS"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString();
						_originalClaim_status = Reader["CLAIM_STATUS"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("CLMHDR_DATE_SYS", SqlNull(CLMHDR_DATE_SYS)),
						new SqlParameter("CLAIM_STATUS", SqlNull(CLAIM_STATUS)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("ADJ_AMT_BAL", SqlNull(ADJ_AMT_BAL)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString();
						CLAIM_STATUS = Reader["CLAIM_STATUS"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						ADJ_AMT_BAL = ConvertDEC(Reader["ADJ_AMT_BAL"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString();
						_originalClaim_status = Reader["CLAIM_STATUS"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						_originalAdj_amt_bal = ConvertDEC(Reader["ADJ_AMT_BAL"]);
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