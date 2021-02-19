using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class PART_PAID_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<PART_PAID_DTL> Collection( Guid? rowid,
															decimal? part_dtl_clinic_nbrmin,
															decimal? part_dtl_clinic_nbrmax,
															string part_dtl_claim_nbr,
															string part_dtl_oma_cd,
															decimal? part_dtl_amt_billmin,
															decimal? part_dtl_amt_billmax,
															decimal? part_dtl_amt_paidmin,
															decimal? part_dtl_amt_paidmax,
															string part_dtl_explan_cd,
															decimal? part_dtl_serv_datemin,
															decimal? part_dtl_serv_datemax,
															string part_dtl_equiv_flag,
															decimal? part_dtl_nbr_servmin,
															decimal? part_dtl_nbr_servmax,
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
					new SqlParameter("minPART_DTL_CLINIC_NBR",part_dtl_clinic_nbrmin),
					new SqlParameter("maxPART_DTL_CLINIC_NBR",part_dtl_clinic_nbrmax),
					new SqlParameter("PART_DTL_CLAIM_NBR",part_dtl_claim_nbr),
					new SqlParameter("PART_DTL_OMA_CD",part_dtl_oma_cd),
					new SqlParameter("minPART_DTL_AMT_BILL",part_dtl_amt_billmin),
					new SqlParameter("maxPART_DTL_AMT_BILL",part_dtl_amt_billmax),
					new SqlParameter("minPART_DTL_AMT_PAID",part_dtl_amt_paidmin),
					new SqlParameter("maxPART_DTL_AMT_PAID",part_dtl_amt_paidmax),
					new SqlParameter("PART_DTL_EXPLAN_CD",part_dtl_explan_cd),
					new SqlParameter("minPART_DTL_SERV_DATE",part_dtl_serv_datemin),
					new SqlParameter("maxPART_DTL_SERV_DATE",part_dtl_serv_datemax),
					new SqlParameter("PART_DTL_EQUIV_FLAG",part_dtl_equiv_flag),
					new SqlParameter("minPART_DTL_NBR_SERV",part_dtl_nbr_servmin),
					new SqlParameter("maxPART_DTL_NBR_SERV",part_dtl_nbr_servmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_PART_PAID_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<PART_PAID_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_PART_PAID_DTL_Search]", parameters);
            var collection = new ObservableCollection<PART_PAID_DTL>();

            while (Reader.Read())
            {
                collection.Add(new PART_PAID_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_DTL_CLINIC_NBR = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]),
					PART_DTL_CLAIM_NBR = Reader["PART_DTL_CLAIM_NBR"].ToString(),
					PART_DTL_OMA_CD = Reader["PART_DTL_OMA_CD"].ToString(),
					PART_DTL_AMT_BILL = ConvertDEC(Reader["PART_DTL_AMT_BILL"]),
					PART_DTL_AMT_PAID = ConvertDEC(Reader["PART_DTL_AMT_PAID"]),
					PART_DTL_EXPLAN_CD = Reader["PART_DTL_EXPLAN_CD"].ToString(),
					PART_DTL_SERV_DATE = ConvertDEC(Reader["PART_DTL_SERV_DATE"]),
					PART_DTL_EQUIV_FLAG = Reader["PART_DTL_EQUIV_FLAG"].ToString(),
					PART_DTL_NBR_SERV = ConvertDEC(Reader["PART_DTL_NBR_SERV"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_dtl_clinic_nbr = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]),
					_originalPart_dtl_claim_nbr = Reader["PART_DTL_CLAIM_NBR"].ToString(),
					_originalPart_dtl_oma_cd = Reader["PART_DTL_OMA_CD"].ToString(),
					_originalPart_dtl_amt_bill = ConvertDEC(Reader["PART_DTL_AMT_BILL"]),
					_originalPart_dtl_amt_paid = ConvertDEC(Reader["PART_DTL_AMT_PAID"]),
					_originalPart_dtl_explan_cd = Reader["PART_DTL_EXPLAN_CD"].ToString(),
					_originalPart_dtl_serv_date = ConvertDEC(Reader["PART_DTL_SERV_DATE"]),
					_originalPart_dtl_equiv_flag = Reader["PART_DTL_EQUIV_FLAG"].ToString(),
					_originalPart_dtl_nbr_serv = ConvertDEC(Reader["PART_DTL_NBR_SERV"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public PART_PAID_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<PART_PAID_DTL> Collection(ObservableCollection<PART_PAID_DTL>
                                                               partPaidDtl = null)
        {
            if (IsSameSearch() && partPaidDtl != null)
            {
                return partPaidDtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<PART_PAID_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PART_DTL_CLINIC_NBR",WherePart_dtl_clinic_nbr),
					new SqlParameter("PART_DTL_CLAIM_NBR",WherePart_dtl_claim_nbr),
					new SqlParameter("PART_DTL_OMA_CD",WherePart_dtl_oma_cd),
					new SqlParameter("PART_DTL_AMT_BILL",WherePart_dtl_amt_bill),
					new SqlParameter("PART_DTL_AMT_PAID",WherePart_dtl_amt_paid),
					new SqlParameter("PART_DTL_EXPLAN_CD",WherePart_dtl_explan_cd),
					new SqlParameter("PART_DTL_SERV_DATE",WherePart_dtl_serv_date),
					new SqlParameter("PART_DTL_EQUIV_FLAG",WherePart_dtl_equiv_flag),
					new SqlParameter("PART_DTL_NBR_SERV",WherePart_dtl_nbr_serv),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_PART_PAID_DTL_Match]", parameters);
            var collection = new ObservableCollection<PART_PAID_DTL>();

            while (Reader.Read())
            {
                collection.Add(new PART_PAID_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_DTL_CLINIC_NBR = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]),
					PART_DTL_CLAIM_NBR = Reader["PART_DTL_CLAIM_NBR"].ToString(),
					PART_DTL_OMA_CD = Reader["PART_DTL_OMA_CD"].ToString(),
					PART_DTL_AMT_BILL = ConvertDEC(Reader["PART_DTL_AMT_BILL"]),
					PART_DTL_AMT_PAID = ConvertDEC(Reader["PART_DTL_AMT_PAID"]),
					PART_DTL_EXPLAN_CD = Reader["PART_DTL_EXPLAN_CD"].ToString(),
					PART_DTL_SERV_DATE = ConvertDEC(Reader["PART_DTL_SERV_DATE"]),
					PART_DTL_EQUIV_FLAG = Reader["PART_DTL_EQUIV_FLAG"].ToString(),
					PART_DTL_NBR_SERV = ConvertDEC(Reader["PART_DTL_NBR_SERV"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePart_dtl_clinic_nbr = WherePart_dtl_clinic_nbr,
					_wherePart_dtl_claim_nbr = WherePart_dtl_claim_nbr,
					_wherePart_dtl_oma_cd = WherePart_dtl_oma_cd,
					_wherePart_dtl_amt_bill = WherePart_dtl_amt_bill,
					_wherePart_dtl_amt_paid = WherePart_dtl_amt_paid,
					_wherePart_dtl_explan_cd = WherePart_dtl_explan_cd,
					_wherePart_dtl_serv_date = WherePart_dtl_serv_date,
					_wherePart_dtl_equiv_flag = WherePart_dtl_equiv_flag,
					_wherePart_dtl_nbr_serv = WherePart_dtl_nbr_serv,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_dtl_clinic_nbr = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]),
					_originalPart_dtl_claim_nbr = Reader["PART_DTL_CLAIM_NBR"].ToString(),
					_originalPart_dtl_oma_cd = Reader["PART_DTL_OMA_CD"].ToString(),
					_originalPart_dtl_amt_bill = ConvertDEC(Reader["PART_DTL_AMT_BILL"]),
					_originalPart_dtl_amt_paid = ConvertDEC(Reader["PART_DTL_AMT_PAID"]),
					_originalPart_dtl_explan_cd = Reader["PART_DTL_EXPLAN_CD"].ToString(),
					_originalPart_dtl_serv_date = ConvertDEC(Reader["PART_DTL_SERV_DATE"]),
					_originalPart_dtl_equiv_flag = Reader["PART_DTL_EQUIV_FLAG"].ToString(),
					_originalPart_dtl_nbr_serv = ConvertDEC(Reader["PART_DTL_NBR_SERV"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePart_dtl_clinic_nbr = WherePart_dtl_clinic_nbr;
					_wherePart_dtl_claim_nbr = WherePart_dtl_claim_nbr;
					_wherePart_dtl_oma_cd = WherePart_dtl_oma_cd;
					_wherePart_dtl_amt_bill = WherePart_dtl_amt_bill;
					_wherePart_dtl_amt_paid = WherePart_dtl_amt_paid;
					_wherePart_dtl_explan_cd = WherePart_dtl_explan_cd;
					_wherePart_dtl_serv_date = WherePart_dtl_serv_date;
					_wherePart_dtl_equiv_flag = WherePart_dtl_equiv_flag;
					_wherePart_dtl_nbr_serv = WherePart_dtl_nbr_serv;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePart_dtl_clinic_nbr == null 
				&& WherePart_dtl_claim_nbr == null 
				&& WherePart_dtl_oma_cd == null 
				&& WherePart_dtl_amt_bill == null 
				&& WherePart_dtl_amt_paid == null 
				&& WherePart_dtl_explan_cd == null 
				&& WherePart_dtl_serv_date == null 
				&& WherePart_dtl_equiv_flag == null 
				&& WherePart_dtl_nbr_serv == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePart_dtl_clinic_nbr ==  _wherePart_dtl_clinic_nbr
				&& WherePart_dtl_claim_nbr ==  _wherePart_dtl_claim_nbr
				&& WherePart_dtl_oma_cd ==  _wherePart_dtl_oma_cd
				&& WherePart_dtl_amt_bill ==  _wherePart_dtl_amt_bill
				&& WherePart_dtl_amt_paid ==  _wherePart_dtl_amt_paid
				&& WherePart_dtl_explan_cd ==  _wherePart_dtl_explan_cd
				&& WherePart_dtl_serv_date ==  _wherePart_dtl_serv_date
				&& WherePart_dtl_equiv_flag ==  _wherePart_dtl_equiv_flag
				&& WherePart_dtl_nbr_serv ==  _wherePart_dtl_nbr_serv
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePart_dtl_clinic_nbr = null; 
			WherePart_dtl_claim_nbr = null; 
			WherePart_dtl_oma_cd = null; 
			WherePart_dtl_amt_bill = null; 
			WherePart_dtl_amt_paid = null; 
			WherePart_dtl_explan_cd = null; 
			WherePart_dtl_serv_date = null; 
			WherePart_dtl_equiv_flag = null; 
			WherePart_dtl_nbr_serv = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _PART_DTL_CLINIC_NBR;
		private string _PART_DTL_CLAIM_NBR;
		private string _PART_DTL_OMA_CD;
		private decimal? _PART_DTL_AMT_BILL;
		private decimal? _PART_DTL_AMT_PAID;
		private string _PART_DTL_EXPLAN_CD;
		private decimal? _PART_DTL_SERV_DATE;
		private string _PART_DTL_EQUIV_FLAG;
		private decimal? _PART_DTL_NBR_SERV;
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
		public decimal? PART_DTL_CLINIC_NBR
		{
			get { return _PART_DTL_CLINIC_NBR; }
			set
			{
				if (_PART_DTL_CLINIC_NBR != value)
				{
					_PART_DTL_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string PART_DTL_CLAIM_NBR
		{
			get { return _PART_DTL_CLAIM_NBR; }
			set
			{
				if (_PART_DTL_CLAIM_NBR != value)
				{
					_PART_DTL_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string PART_DTL_OMA_CD
		{
			get { return _PART_DTL_OMA_CD; }
			set
			{
				if (_PART_DTL_OMA_CD != value)
				{
					_PART_DTL_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_DTL_AMT_BILL
		{
			get { return _PART_DTL_AMT_BILL; }
			set
			{
				if (_PART_DTL_AMT_BILL != value)
				{
					_PART_DTL_AMT_BILL = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_DTL_AMT_PAID
		{
			get { return _PART_DTL_AMT_PAID; }
			set
			{
				if (_PART_DTL_AMT_PAID != value)
				{
					_PART_DTL_AMT_PAID = value;
					ChangeState();
				}
			}
		}
		public string PART_DTL_EXPLAN_CD
		{
			get { return _PART_DTL_EXPLAN_CD; }
			set
			{
				if (_PART_DTL_EXPLAN_CD != value)
				{
					_PART_DTL_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_DTL_SERV_DATE
		{
			get { return _PART_DTL_SERV_DATE; }
			set
			{
				if (_PART_DTL_SERV_DATE != value)
				{
					_PART_DTL_SERV_DATE = value;
					ChangeState();
				}
			}
		}
		public string PART_DTL_EQUIV_FLAG
		{
			get { return _PART_DTL_EQUIV_FLAG; }
			set
			{
				if (_PART_DTL_EQUIV_FLAG != value)
				{
					_PART_DTL_EQUIV_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_DTL_NBR_SERV
		{
			get { return _PART_DTL_NBR_SERV; }
			set
			{
				if (_PART_DTL_NBR_SERV != value)
				{
					_PART_DTL_NBR_SERV = value;
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
		public decimal? WherePart_dtl_clinic_nbr { get; set; }
		private decimal? _wherePart_dtl_clinic_nbr;
		public string WherePart_dtl_claim_nbr { get; set; }
		private string _wherePart_dtl_claim_nbr;
		public string WherePart_dtl_oma_cd { get; set; }
		private string _wherePart_dtl_oma_cd;
		public decimal? WherePart_dtl_amt_bill { get; set; }
		private decimal? _wherePart_dtl_amt_bill;
		public decimal? WherePart_dtl_amt_paid { get; set; }
		private decimal? _wherePart_dtl_amt_paid;
		public string WherePart_dtl_explan_cd { get; set; }
		private string _wherePart_dtl_explan_cd;
		public decimal? WherePart_dtl_serv_date { get; set; }
		private decimal? _wherePart_dtl_serv_date;
		public string WherePart_dtl_equiv_flag { get; set; }
		private string _wherePart_dtl_equiv_flag;
		public decimal? WherePart_dtl_nbr_serv { get; set; }
		private decimal? _wherePart_dtl_nbr_serv;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalPart_dtl_clinic_nbr;
		private string _originalPart_dtl_claim_nbr;
		private string _originalPart_dtl_oma_cd;
		private decimal? _originalPart_dtl_amt_bill;
		private decimal? _originalPart_dtl_amt_paid;
		private string _originalPart_dtl_explan_cd;
		private decimal? _originalPart_dtl_serv_date;
		private string _originalPart_dtl_equiv_flag;
		private decimal? _originalPart_dtl_nbr_serv;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PART_DTL_CLINIC_NBR = _originalPart_dtl_clinic_nbr;
			PART_DTL_CLAIM_NBR = _originalPart_dtl_claim_nbr;
			PART_DTL_OMA_CD = _originalPart_dtl_oma_cd;
			PART_DTL_AMT_BILL = _originalPart_dtl_amt_bill;
			PART_DTL_AMT_PAID = _originalPart_dtl_amt_paid;
			PART_DTL_EXPLAN_CD = _originalPart_dtl_explan_cd;
			PART_DTL_SERV_DATE = _originalPart_dtl_serv_date;
			PART_DTL_EQUIV_FLAG = _originalPart_dtl_equiv_flag;
			PART_DTL_NBR_SERV = _originalPart_dtl_nbr_serv;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_PAID_DTL_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_PAID_DTL_Purge]");
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
						new SqlParameter("PART_DTL_CLINIC_NBR", SqlNull(PART_DTL_CLINIC_NBR)),
						new SqlParameter("PART_DTL_CLAIM_NBR", SqlNull(PART_DTL_CLAIM_NBR)),
						new SqlParameter("PART_DTL_OMA_CD", SqlNull(PART_DTL_OMA_CD)),
						new SqlParameter("PART_DTL_AMT_BILL", SqlNull(PART_DTL_AMT_BILL)),
						new SqlParameter("PART_DTL_AMT_PAID", SqlNull(PART_DTL_AMT_PAID)),
						new SqlParameter("PART_DTL_EXPLAN_CD", SqlNull(PART_DTL_EXPLAN_CD)),
						new SqlParameter("PART_DTL_SERV_DATE", SqlNull(PART_DTL_SERV_DATE)),
						new SqlParameter("PART_DTL_EQUIV_FLAG", SqlNull(PART_DTL_EQUIV_FLAG)),
						new SqlParameter("PART_DTL_NBR_SERV", SqlNull(PART_DTL_NBR_SERV)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_PAID_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_DTL_CLINIC_NBR = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]);
						PART_DTL_CLAIM_NBR = Reader["PART_DTL_CLAIM_NBR"].ToString();
						PART_DTL_OMA_CD = Reader["PART_DTL_OMA_CD"].ToString();
						PART_DTL_AMT_BILL = ConvertDEC(Reader["PART_DTL_AMT_BILL"]);
						PART_DTL_AMT_PAID = ConvertDEC(Reader["PART_DTL_AMT_PAID"]);
						PART_DTL_EXPLAN_CD = Reader["PART_DTL_EXPLAN_CD"].ToString();
						PART_DTL_SERV_DATE = ConvertDEC(Reader["PART_DTL_SERV_DATE"]);
						PART_DTL_EQUIV_FLAG = Reader["PART_DTL_EQUIV_FLAG"].ToString();
						PART_DTL_NBR_SERV = ConvertDEC(Reader["PART_DTL_NBR_SERV"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_dtl_clinic_nbr = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]);
						_originalPart_dtl_claim_nbr = Reader["PART_DTL_CLAIM_NBR"].ToString();
						_originalPart_dtl_oma_cd = Reader["PART_DTL_OMA_CD"].ToString();
						_originalPart_dtl_amt_bill = ConvertDEC(Reader["PART_DTL_AMT_BILL"]);
						_originalPart_dtl_amt_paid = ConvertDEC(Reader["PART_DTL_AMT_PAID"]);
						_originalPart_dtl_explan_cd = Reader["PART_DTL_EXPLAN_CD"].ToString();
						_originalPart_dtl_serv_date = ConvertDEC(Reader["PART_DTL_SERV_DATE"]);
						_originalPart_dtl_equiv_flag = Reader["PART_DTL_EQUIV_FLAG"].ToString();
						_originalPart_dtl_nbr_serv = ConvertDEC(Reader["PART_DTL_NBR_SERV"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PART_DTL_CLINIC_NBR", SqlNull(PART_DTL_CLINIC_NBR)),
						new SqlParameter("PART_DTL_CLAIM_NBR", SqlNull(PART_DTL_CLAIM_NBR)),
						new SqlParameter("PART_DTL_OMA_CD", SqlNull(PART_DTL_OMA_CD)),
						new SqlParameter("PART_DTL_AMT_BILL", SqlNull(PART_DTL_AMT_BILL)),
						new SqlParameter("PART_DTL_AMT_PAID", SqlNull(PART_DTL_AMT_PAID)),
						new SqlParameter("PART_DTL_EXPLAN_CD", SqlNull(PART_DTL_EXPLAN_CD)),
						new SqlParameter("PART_DTL_SERV_DATE", SqlNull(PART_DTL_SERV_DATE)),
						new SqlParameter("PART_DTL_EQUIV_FLAG", SqlNull(PART_DTL_EQUIV_FLAG)),
						new SqlParameter("PART_DTL_NBR_SERV", SqlNull(PART_DTL_NBR_SERV)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_PAID_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_DTL_CLINIC_NBR = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]);
						PART_DTL_CLAIM_NBR = Reader["PART_DTL_CLAIM_NBR"].ToString();
						PART_DTL_OMA_CD = Reader["PART_DTL_OMA_CD"].ToString();
						PART_DTL_AMT_BILL = ConvertDEC(Reader["PART_DTL_AMT_BILL"]);
						PART_DTL_AMT_PAID = ConvertDEC(Reader["PART_DTL_AMT_PAID"]);
						PART_DTL_EXPLAN_CD = Reader["PART_DTL_EXPLAN_CD"].ToString();
						PART_DTL_SERV_DATE = ConvertDEC(Reader["PART_DTL_SERV_DATE"]);
						PART_DTL_EQUIV_FLAG = Reader["PART_DTL_EQUIV_FLAG"].ToString();
						PART_DTL_NBR_SERV = ConvertDEC(Reader["PART_DTL_NBR_SERV"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_dtl_clinic_nbr = ConvertDEC(Reader["PART_DTL_CLINIC_NBR"]);
						_originalPart_dtl_claim_nbr = Reader["PART_DTL_CLAIM_NBR"].ToString();
						_originalPart_dtl_oma_cd = Reader["PART_DTL_OMA_CD"].ToString();
						_originalPart_dtl_amt_bill = ConvertDEC(Reader["PART_DTL_AMT_BILL"]);
						_originalPart_dtl_amt_paid = ConvertDEC(Reader["PART_DTL_AMT_PAID"]);
						_originalPart_dtl_explan_cd = Reader["PART_DTL_EXPLAN_CD"].ToString();
						_originalPart_dtl_serv_date = ConvertDEC(Reader["PART_DTL_SERV_DATE"]);
						_originalPart_dtl_equiv_flag = Reader["PART_DTL_EQUIV_FLAG"].ToString();
						_originalPart_dtl_nbr_serv = ConvertDEC(Reader["PART_DTL_NBR_SERV"]);
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