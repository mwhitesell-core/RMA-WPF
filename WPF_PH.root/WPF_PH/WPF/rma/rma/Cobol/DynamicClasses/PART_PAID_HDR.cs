using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class PART_PAID_HDR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<PART_PAID_HDR> Collection( Guid? rowid,
															decimal? part_hdr_clinic_nbrmin,
															decimal? part_hdr_clinic_nbrmax,
															string part_hdr_claim_nbr,
															decimal? part_hdr_amt_billmin,
															decimal? part_hdr_amt_billmax,
															decimal? part_hdr_amt_paidmin,
															decimal? part_hdr_amt_paidmax,
															decimal? part_hdr_ohip_billmin,
															decimal? part_hdr_ohip_billmax,
															string part_hdr_last_name,
															string part_hdr_first_name,
															string part_hdr_ohip_clm_nbr,
															string part_hdr_version_cd,
															string part_hdr_pay_pgm,
															string part_hdr_register_nbr,
															string part_hdr_explan_cd,
															decimal? part_hdr_serv_datemin,
															decimal? part_hdr_serv_datemax,
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
					new SqlParameter("minPART_HDR_CLINIC_NBR",part_hdr_clinic_nbrmin),
					new SqlParameter("maxPART_HDR_CLINIC_NBR",part_hdr_clinic_nbrmax),
					new SqlParameter("PART_HDR_CLAIM_NBR",part_hdr_claim_nbr),
					new SqlParameter("minPART_HDR_AMT_BILL",part_hdr_amt_billmin),
					new SqlParameter("maxPART_HDR_AMT_BILL",part_hdr_amt_billmax),
					new SqlParameter("minPART_HDR_AMT_PAID",part_hdr_amt_paidmin),
					new SqlParameter("maxPART_HDR_AMT_PAID",part_hdr_amt_paidmax),
					new SqlParameter("minPART_HDR_OHIP_BILL",part_hdr_ohip_billmin),
					new SqlParameter("maxPART_HDR_OHIP_BILL",part_hdr_ohip_billmax),
					new SqlParameter("PART_HDR_LAST_NAME",part_hdr_last_name),
					new SqlParameter("PART_HDR_FIRST_NAME",part_hdr_first_name),
					new SqlParameter("PART_HDR_OHIP_CLM_NBR",part_hdr_ohip_clm_nbr),
					new SqlParameter("PART_HDR_VERSION_CD",part_hdr_version_cd),
					new SqlParameter("PART_HDR_PAY_PGM",part_hdr_pay_pgm),
					new SqlParameter("PART_HDR_REGISTER_NBR",part_hdr_register_nbr),
					new SqlParameter("PART_HDR_EXPLAN_CD",part_hdr_explan_cd),
					new SqlParameter("minPART_HDR_SERV_DATE",part_hdr_serv_datemin),
					new SqlParameter("maxPART_HDR_SERV_DATE",part_hdr_serv_datemax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_PART_PAID_HDR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<PART_PAID_HDR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_PART_PAID_HDR_Search]", parameters);
            var collection = new ObservableCollection<PART_PAID_HDR>();

            while (Reader.Read())
            {
                collection.Add(new PART_PAID_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_HDR_CLINIC_NBR = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]),
					PART_HDR_CLAIM_NBR = Reader["PART_HDR_CLAIM_NBR"].ToString(),
					PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					PART_HDR_OHIP_BILL = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]),
					PART_HDR_LAST_NAME = Reader["PART_HDR_LAST_NAME"].ToString(),
					PART_HDR_FIRST_NAME = Reader["PART_HDR_FIRST_NAME"].ToString(),
					PART_HDR_OHIP_CLM_NBR = Reader["PART_HDR_OHIP_CLM_NBR"].ToString(),
					PART_HDR_VERSION_CD = Reader["PART_HDR_VERSION_CD"].ToString(),
					PART_HDR_PAY_PGM = Reader["PART_HDR_PAY_PGM"].ToString(),
					PART_HDR_REGISTER_NBR = Reader["PART_HDR_REGISTER_NBR"].ToString(),
					PART_HDR_EXPLAN_CD = Reader["PART_HDR_EXPLAN_CD"].ToString(),
					PART_HDR_SERV_DATE = ConvertDEC(Reader["PART_HDR_SERV_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_hdr_clinic_nbr = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]),
					_originalPart_hdr_claim_nbr = Reader["PART_HDR_CLAIM_NBR"].ToString(),
					_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					_originalPart_hdr_ohip_bill = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]),
					_originalPart_hdr_last_name = Reader["PART_HDR_LAST_NAME"].ToString(),
					_originalPart_hdr_first_name = Reader["PART_HDR_FIRST_NAME"].ToString(),
					_originalPart_hdr_ohip_clm_nbr = Reader["PART_HDR_OHIP_CLM_NBR"].ToString(),
					_originalPart_hdr_version_cd = Reader["PART_HDR_VERSION_CD"].ToString(),
					_originalPart_hdr_pay_pgm = Reader["PART_HDR_PAY_PGM"].ToString(),
					_originalPart_hdr_register_nbr = Reader["PART_HDR_REGISTER_NBR"].ToString(),
					_originalPart_hdr_explan_cd = Reader["PART_HDR_EXPLAN_CD"].ToString(),
					_originalPart_hdr_serv_date = ConvertDEC(Reader["PART_HDR_SERV_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public PART_PAID_HDR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<PART_PAID_HDR> Collection(ObservableCollection<PART_PAID_HDR>
                                                               partPaidHdr = null)
        {
            if (IsSameSearch() && partPaidHdr != null)
            {
                return partPaidHdr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<PART_PAID_HDR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PART_HDR_CLINIC_NBR",WherePart_hdr_clinic_nbr),
					new SqlParameter("PART_HDR_CLAIM_NBR",WherePart_hdr_claim_nbr),
					new SqlParameter("PART_HDR_AMT_BILL",WherePart_hdr_amt_bill),
					new SqlParameter("PART_HDR_AMT_PAID",WherePart_hdr_amt_paid),
					new SqlParameter("PART_HDR_OHIP_BILL",WherePart_hdr_ohip_bill),
					new SqlParameter("PART_HDR_LAST_NAME",WherePart_hdr_last_name),
					new SqlParameter("PART_HDR_FIRST_NAME",WherePart_hdr_first_name),
					new SqlParameter("PART_HDR_OHIP_CLM_NBR",WherePart_hdr_ohip_clm_nbr),
					new SqlParameter("PART_HDR_VERSION_CD",WherePart_hdr_version_cd),
					new SqlParameter("PART_HDR_PAY_PGM",WherePart_hdr_pay_pgm),
					new SqlParameter("PART_HDR_REGISTER_NBR",WherePart_hdr_register_nbr),
					new SqlParameter("PART_HDR_EXPLAN_CD",WherePart_hdr_explan_cd),
					new SqlParameter("PART_HDR_SERV_DATE",WherePart_hdr_serv_date),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_PART_PAID_HDR_Match]", parameters);
            var collection = new ObservableCollection<PART_PAID_HDR>();

            while (Reader.Read())
            {
                collection.Add(new PART_PAID_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_HDR_CLINIC_NBR = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]),
					PART_HDR_CLAIM_NBR = Reader["PART_HDR_CLAIM_NBR"].ToString(),
					PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					PART_HDR_OHIP_BILL = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]),
					PART_HDR_LAST_NAME = Reader["PART_HDR_LAST_NAME"].ToString(),
					PART_HDR_FIRST_NAME = Reader["PART_HDR_FIRST_NAME"].ToString(),
					PART_HDR_OHIP_CLM_NBR = Reader["PART_HDR_OHIP_CLM_NBR"].ToString(),
					PART_HDR_VERSION_CD = Reader["PART_HDR_VERSION_CD"].ToString(),
					PART_HDR_PAY_PGM = Reader["PART_HDR_PAY_PGM"].ToString(),
					PART_HDR_REGISTER_NBR = Reader["PART_HDR_REGISTER_NBR"].ToString(),
					PART_HDR_EXPLAN_CD = Reader["PART_HDR_EXPLAN_CD"].ToString(),
					PART_HDR_SERV_DATE = ConvertDEC(Reader["PART_HDR_SERV_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePart_hdr_clinic_nbr = WherePart_hdr_clinic_nbr,
					_wherePart_hdr_claim_nbr = WherePart_hdr_claim_nbr,
					_wherePart_hdr_amt_bill = WherePart_hdr_amt_bill,
					_wherePart_hdr_amt_paid = WherePart_hdr_amt_paid,
					_wherePart_hdr_ohip_bill = WherePart_hdr_ohip_bill,
					_wherePart_hdr_last_name = WherePart_hdr_last_name,
					_wherePart_hdr_first_name = WherePart_hdr_first_name,
					_wherePart_hdr_ohip_clm_nbr = WherePart_hdr_ohip_clm_nbr,
					_wherePart_hdr_version_cd = WherePart_hdr_version_cd,
					_wherePart_hdr_pay_pgm = WherePart_hdr_pay_pgm,
					_wherePart_hdr_register_nbr = WherePart_hdr_register_nbr,
					_wherePart_hdr_explan_cd = WherePart_hdr_explan_cd,
					_wherePart_hdr_serv_date = WherePart_hdr_serv_date,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_hdr_clinic_nbr = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]),
					_originalPart_hdr_claim_nbr = Reader["PART_HDR_CLAIM_NBR"].ToString(),
					_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					_originalPart_hdr_ohip_bill = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]),
					_originalPart_hdr_last_name = Reader["PART_HDR_LAST_NAME"].ToString(),
					_originalPart_hdr_first_name = Reader["PART_HDR_FIRST_NAME"].ToString(),
					_originalPart_hdr_ohip_clm_nbr = Reader["PART_HDR_OHIP_CLM_NBR"].ToString(),
					_originalPart_hdr_version_cd = Reader["PART_HDR_VERSION_CD"].ToString(),
					_originalPart_hdr_pay_pgm = Reader["PART_HDR_PAY_PGM"].ToString(),
					_originalPart_hdr_register_nbr = Reader["PART_HDR_REGISTER_NBR"].ToString(),
					_originalPart_hdr_explan_cd = Reader["PART_HDR_EXPLAN_CD"].ToString(),
					_originalPart_hdr_serv_date = ConvertDEC(Reader["PART_HDR_SERV_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePart_hdr_clinic_nbr = WherePart_hdr_clinic_nbr;
					_wherePart_hdr_claim_nbr = WherePart_hdr_claim_nbr;
					_wherePart_hdr_amt_bill = WherePart_hdr_amt_bill;
					_wherePart_hdr_amt_paid = WherePart_hdr_amt_paid;
					_wherePart_hdr_ohip_bill = WherePart_hdr_ohip_bill;
					_wherePart_hdr_last_name = WherePart_hdr_last_name;
					_wherePart_hdr_first_name = WherePart_hdr_first_name;
					_wherePart_hdr_ohip_clm_nbr = WherePart_hdr_ohip_clm_nbr;
					_wherePart_hdr_version_cd = WherePart_hdr_version_cd;
					_wherePart_hdr_pay_pgm = WherePart_hdr_pay_pgm;
					_wherePart_hdr_register_nbr = WherePart_hdr_register_nbr;
					_wherePart_hdr_explan_cd = WherePart_hdr_explan_cd;
					_wherePart_hdr_serv_date = WherePart_hdr_serv_date;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePart_hdr_clinic_nbr == null 
				&& WherePart_hdr_claim_nbr == null 
				&& WherePart_hdr_amt_bill == null 
				&& WherePart_hdr_amt_paid == null 
				&& WherePart_hdr_ohip_bill == null 
				&& WherePart_hdr_last_name == null 
				&& WherePart_hdr_first_name == null 
				&& WherePart_hdr_ohip_clm_nbr == null 
				&& WherePart_hdr_version_cd == null 
				&& WherePart_hdr_pay_pgm == null 
				&& WherePart_hdr_register_nbr == null 
				&& WherePart_hdr_explan_cd == null 
				&& WherePart_hdr_serv_date == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePart_hdr_clinic_nbr ==  _wherePart_hdr_clinic_nbr
				&& WherePart_hdr_claim_nbr ==  _wherePart_hdr_claim_nbr
				&& WherePart_hdr_amt_bill ==  _wherePart_hdr_amt_bill
				&& WherePart_hdr_amt_paid ==  _wherePart_hdr_amt_paid
				&& WherePart_hdr_ohip_bill ==  _wherePart_hdr_ohip_bill
				&& WherePart_hdr_last_name ==  _wherePart_hdr_last_name
				&& WherePart_hdr_first_name ==  _wherePart_hdr_first_name
				&& WherePart_hdr_ohip_clm_nbr ==  _wherePart_hdr_ohip_clm_nbr
				&& WherePart_hdr_version_cd ==  _wherePart_hdr_version_cd
				&& WherePart_hdr_pay_pgm ==  _wherePart_hdr_pay_pgm
				&& WherePart_hdr_register_nbr ==  _wherePart_hdr_register_nbr
				&& WherePart_hdr_explan_cd ==  _wherePart_hdr_explan_cd
				&& WherePart_hdr_serv_date ==  _wherePart_hdr_serv_date
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePart_hdr_clinic_nbr = null; 
			WherePart_hdr_claim_nbr = null; 
			WherePart_hdr_amt_bill = null; 
			WherePart_hdr_amt_paid = null; 
			WherePart_hdr_ohip_bill = null; 
			WherePart_hdr_last_name = null; 
			WherePart_hdr_first_name = null; 
			WherePart_hdr_ohip_clm_nbr = null; 
			WherePart_hdr_version_cd = null; 
			WherePart_hdr_pay_pgm = null; 
			WherePart_hdr_register_nbr = null; 
			WherePart_hdr_explan_cd = null; 
			WherePart_hdr_serv_date = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _PART_HDR_CLINIC_NBR;
		private string _PART_HDR_CLAIM_NBR;
		private decimal? _PART_HDR_AMT_BILL;
		private decimal? _PART_HDR_AMT_PAID;
		private decimal? _PART_HDR_OHIP_BILL;
		private string _PART_HDR_LAST_NAME;
		private string _PART_HDR_FIRST_NAME;
		private string _PART_HDR_OHIP_CLM_NBR;
		private string _PART_HDR_VERSION_CD;
		private string _PART_HDR_PAY_PGM;
		private string _PART_HDR_REGISTER_NBR;
		private string _PART_HDR_EXPLAN_CD;
		private decimal? _PART_HDR_SERV_DATE;
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
		public decimal? PART_HDR_CLINIC_NBR
		{
			get { return _PART_HDR_CLINIC_NBR; }
			set
			{
				if (_PART_HDR_CLINIC_NBR != value)
				{
					_PART_HDR_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_CLAIM_NBR
		{
			get { return _PART_HDR_CLAIM_NBR; }
			set
			{
				if (_PART_HDR_CLAIM_NBR != value)
				{
					_PART_HDR_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_HDR_AMT_BILL
		{
			get { return _PART_HDR_AMT_BILL; }
			set
			{
				if (_PART_HDR_AMT_BILL != value)
				{
					_PART_HDR_AMT_BILL = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_HDR_AMT_PAID
		{
			get { return _PART_HDR_AMT_PAID; }
			set
			{
				if (_PART_HDR_AMT_PAID != value)
				{
					_PART_HDR_AMT_PAID = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_HDR_OHIP_BILL
		{
			get { return _PART_HDR_OHIP_BILL; }
			set
			{
				if (_PART_HDR_OHIP_BILL != value)
				{
					_PART_HDR_OHIP_BILL = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_LAST_NAME
		{
			get { return _PART_HDR_LAST_NAME; }
			set
			{
				if (_PART_HDR_LAST_NAME != value)
				{
					_PART_HDR_LAST_NAME = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_FIRST_NAME
		{
			get { return _PART_HDR_FIRST_NAME; }
			set
			{
				if (_PART_HDR_FIRST_NAME != value)
				{
					_PART_HDR_FIRST_NAME = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_OHIP_CLM_NBR
		{
			get { return _PART_HDR_OHIP_CLM_NBR; }
			set
			{
				if (_PART_HDR_OHIP_CLM_NBR != value)
				{
					_PART_HDR_OHIP_CLM_NBR = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_VERSION_CD
		{
			get { return _PART_HDR_VERSION_CD; }
			set
			{
				if (_PART_HDR_VERSION_CD != value)
				{
					_PART_HDR_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_PAY_PGM
		{
			get { return _PART_HDR_PAY_PGM; }
			set
			{
				if (_PART_HDR_PAY_PGM != value)
				{
					_PART_HDR_PAY_PGM = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_REGISTER_NBR
		{
			get { return _PART_HDR_REGISTER_NBR; }
			set
			{
				if (_PART_HDR_REGISTER_NBR != value)
				{
					_PART_HDR_REGISTER_NBR = value;
					ChangeState();
				}
			}
		}
		public string PART_HDR_EXPLAN_CD
		{
			get { return _PART_HDR_EXPLAN_CD; }
			set
			{
				if (_PART_HDR_EXPLAN_CD != value)
				{
					_PART_HDR_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_HDR_SERV_DATE
		{
			get { return _PART_HDR_SERV_DATE; }
			set
			{
				if (_PART_HDR_SERV_DATE != value)
				{
					_PART_HDR_SERV_DATE = value;
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
		public decimal? WherePart_hdr_clinic_nbr { get; set; }
		private decimal? _wherePart_hdr_clinic_nbr;
		public string WherePart_hdr_claim_nbr { get; set; }
		private string _wherePart_hdr_claim_nbr;
		public decimal? WherePart_hdr_amt_bill { get; set; }
		private decimal? _wherePart_hdr_amt_bill;
		public decimal? WherePart_hdr_amt_paid { get; set; }
		private decimal? _wherePart_hdr_amt_paid;
		public decimal? WherePart_hdr_ohip_bill { get; set; }
		private decimal? _wherePart_hdr_ohip_bill;
		public string WherePart_hdr_last_name { get; set; }
		private string _wherePart_hdr_last_name;
		public string WherePart_hdr_first_name { get; set; }
		private string _wherePart_hdr_first_name;
		public string WherePart_hdr_ohip_clm_nbr { get; set; }
		private string _wherePart_hdr_ohip_clm_nbr;
		public string WherePart_hdr_version_cd { get; set; }
		private string _wherePart_hdr_version_cd;
		public string WherePart_hdr_pay_pgm { get; set; }
		private string _wherePart_hdr_pay_pgm;
		public string WherePart_hdr_register_nbr { get; set; }
		private string _wherePart_hdr_register_nbr;
		public string WherePart_hdr_explan_cd { get; set; }
		private string _wherePart_hdr_explan_cd;
		public decimal? WherePart_hdr_serv_date { get; set; }
		private decimal? _wherePart_hdr_serv_date;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalPart_hdr_clinic_nbr;
		private string _originalPart_hdr_claim_nbr;
		private decimal? _originalPart_hdr_amt_bill;
		private decimal? _originalPart_hdr_amt_paid;
		private decimal? _originalPart_hdr_ohip_bill;
		private string _originalPart_hdr_last_name;
		private string _originalPart_hdr_first_name;
		private string _originalPart_hdr_ohip_clm_nbr;
		private string _originalPart_hdr_version_cd;
		private string _originalPart_hdr_pay_pgm;
		private string _originalPart_hdr_register_nbr;
		private string _originalPart_hdr_explan_cd;
		private decimal? _originalPart_hdr_serv_date;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PART_HDR_CLINIC_NBR = _originalPart_hdr_clinic_nbr;
			PART_HDR_CLAIM_NBR = _originalPart_hdr_claim_nbr;
			PART_HDR_AMT_BILL = _originalPart_hdr_amt_bill;
			PART_HDR_AMT_PAID = _originalPart_hdr_amt_paid;
			PART_HDR_OHIP_BILL = _originalPart_hdr_ohip_bill;
			PART_HDR_LAST_NAME = _originalPart_hdr_last_name;
			PART_HDR_FIRST_NAME = _originalPart_hdr_first_name;
			PART_HDR_OHIP_CLM_NBR = _originalPart_hdr_ohip_clm_nbr;
			PART_HDR_VERSION_CD = _originalPart_hdr_version_cd;
			PART_HDR_PAY_PGM = _originalPart_hdr_pay_pgm;
			PART_HDR_REGISTER_NBR = _originalPart_hdr_register_nbr;
			PART_HDR_EXPLAN_CD = _originalPart_hdr_explan_cd;
			PART_HDR_SERV_DATE = _originalPart_hdr_serv_date;
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
					new SqlParameter("PART_HDR_CLINIC_NBR",PART_HDR_CLINIC_NBR),
					new SqlParameter("PART_HDR_CLAIM_NBR",PART_HDR_CLAIM_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_PAID_HDR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_PAID_HDR_Purge]");
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
						new SqlParameter("PART_HDR_CLINIC_NBR", SqlNull(PART_HDR_CLINIC_NBR)),
						new SqlParameter("PART_HDR_CLAIM_NBR", SqlNull(PART_HDR_CLAIM_NBR)),
						new SqlParameter("PART_HDR_AMT_BILL", SqlNull(PART_HDR_AMT_BILL)),
						new SqlParameter("PART_HDR_AMT_PAID", SqlNull(PART_HDR_AMT_PAID)),
						new SqlParameter("PART_HDR_OHIP_BILL", SqlNull(PART_HDR_OHIP_BILL)),
						new SqlParameter("PART_HDR_LAST_NAME", SqlNull(PART_HDR_LAST_NAME)),
						new SqlParameter("PART_HDR_FIRST_NAME", SqlNull(PART_HDR_FIRST_NAME)),
						new SqlParameter("PART_HDR_OHIP_CLM_NBR", SqlNull(PART_HDR_OHIP_CLM_NBR)),
						new SqlParameter("PART_HDR_VERSION_CD", SqlNull(PART_HDR_VERSION_CD)),
						new SqlParameter("PART_HDR_PAY_PGM", SqlNull(PART_HDR_PAY_PGM)),
						new SqlParameter("PART_HDR_REGISTER_NBR", SqlNull(PART_HDR_REGISTER_NBR)),
						new SqlParameter("PART_HDR_EXPLAN_CD", SqlNull(PART_HDR_EXPLAN_CD)),
						new SqlParameter("PART_HDR_SERV_DATE", SqlNull(PART_HDR_SERV_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_PAID_HDR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_HDR_CLINIC_NBR = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]);
						PART_HDR_CLAIM_NBR = Reader["PART_HDR_CLAIM_NBR"].ToString();
						PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						PART_HDR_OHIP_BILL = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]);
						PART_HDR_LAST_NAME = Reader["PART_HDR_LAST_NAME"].ToString();
						PART_HDR_FIRST_NAME = Reader["PART_HDR_FIRST_NAME"].ToString();
						PART_HDR_OHIP_CLM_NBR = Reader["PART_HDR_OHIP_CLM_NBR"].ToString();
						PART_HDR_VERSION_CD = Reader["PART_HDR_VERSION_CD"].ToString();
						PART_HDR_PAY_PGM = Reader["PART_HDR_PAY_PGM"].ToString();
						PART_HDR_REGISTER_NBR = Reader["PART_HDR_REGISTER_NBR"].ToString();
						PART_HDR_EXPLAN_CD = Reader["PART_HDR_EXPLAN_CD"].ToString();
						PART_HDR_SERV_DATE = ConvertDEC(Reader["PART_HDR_SERV_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_hdr_clinic_nbr = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]);
						_originalPart_hdr_claim_nbr = Reader["PART_HDR_CLAIM_NBR"].ToString();
						_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						_originalPart_hdr_ohip_bill = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]);
						_originalPart_hdr_last_name = Reader["PART_HDR_LAST_NAME"].ToString();
						_originalPart_hdr_first_name = Reader["PART_HDR_FIRST_NAME"].ToString();
						_originalPart_hdr_ohip_clm_nbr = Reader["PART_HDR_OHIP_CLM_NBR"].ToString();
						_originalPart_hdr_version_cd = Reader["PART_HDR_VERSION_CD"].ToString();
						_originalPart_hdr_pay_pgm = Reader["PART_HDR_PAY_PGM"].ToString();
						_originalPart_hdr_register_nbr = Reader["PART_HDR_REGISTER_NBR"].ToString();
						_originalPart_hdr_explan_cd = Reader["PART_HDR_EXPLAN_CD"].ToString();
						_originalPart_hdr_serv_date = ConvertDEC(Reader["PART_HDR_SERV_DATE"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PART_HDR_CLINIC_NBR", SqlNull(PART_HDR_CLINIC_NBR)),
						new SqlParameter("PART_HDR_CLAIM_NBR", SqlNull(PART_HDR_CLAIM_NBR)),
						new SqlParameter("PART_HDR_AMT_BILL", SqlNull(PART_HDR_AMT_BILL)),
						new SqlParameter("PART_HDR_AMT_PAID", SqlNull(PART_HDR_AMT_PAID)),
						new SqlParameter("PART_HDR_OHIP_BILL", SqlNull(PART_HDR_OHIP_BILL)),
						new SqlParameter("PART_HDR_LAST_NAME", SqlNull(PART_HDR_LAST_NAME)),
						new SqlParameter("PART_HDR_FIRST_NAME", SqlNull(PART_HDR_FIRST_NAME)),
						new SqlParameter("PART_HDR_OHIP_CLM_NBR", SqlNull(PART_HDR_OHIP_CLM_NBR)),
						new SqlParameter("PART_HDR_VERSION_CD", SqlNull(PART_HDR_VERSION_CD)),
						new SqlParameter("PART_HDR_PAY_PGM", SqlNull(PART_HDR_PAY_PGM)),
						new SqlParameter("PART_HDR_REGISTER_NBR", SqlNull(PART_HDR_REGISTER_NBR)),
						new SqlParameter("PART_HDR_EXPLAN_CD", SqlNull(PART_HDR_EXPLAN_CD)),
						new SqlParameter("PART_HDR_SERV_DATE", SqlNull(PART_HDR_SERV_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_PAID_HDR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_HDR_CLINIC_NBR = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]);
						PART_HDR_CLAIM_NBR = Reader["PART_HDR_CLAIM_NBR"].ToString();
						PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						PART_HDR_OHIP_BILL = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]);
						PART_HDR_LAST_NAME = Reader["PART_HDR_LAST_NAME"].ToString();
						PART_HDR_FIRST_NAME = Reader["PART_HDR_FIRST_NAME"].ToString();
						PART_HDR_OHIP_CLM_NBR = Reader["PART_HDR_OHIP_CLM_NBR"].ToString();
						PART_HDR_VERSION_CD = Reader["PART_HDR_VERSION_CD"].ToString();
						PART_HDR_PAY_PGM = Reader["PART_HDR_PAY_PGM"].ToString();
						PART_HDR_REGISTER_NBR = Reader["PART_HDR_REGISTER_NBR"].ToString();
						PART_HDR_EXPLAN_CD = Reader["PART_HDR_EXPLAN_CD"].ToString();
						PART_HDR_SERV_DATE = ConvertDEC(Reader["PART_HDR_SERV_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_hdr_clinic_nbr = ConvertDEC(Reader["PART_HDR_CLINIC_NBR"]);
						_originalPart_hdr_claim_nbr = Reader["PART_HDR_CLAIM_NBR"].ToString();
						_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						_originalPart_hdr_ohip_bill = ConvertDEC(Reader["PART_HDR_OHIP_BILL"]);
						_originalPart_hdr_last_name = Reader["PART_HDR_LAST_NAME"].ToString();
						_originalPart_hdr_first_name = Reader["PART_HDR_FIRST_NAME"].ToString();
						_originalPart_hdr_ohip_clm_nbr = Reader["PART_HDR_OHIP_CLM_NBR"].ToString();
						_originalPart_hdr_version_cd = Reader["PART_HDR_VERSION_CD"].ToString();
						_originalPart_hdr_pay_pgm = Reader["PART_HDR_PAY_PGM"].ToString();
						_originalPart_hdr_register_nbr = Reader["PART_HDR_REGISTER_NBR"].ToString();
						_originalPart_hdr_explan_cd = Reader["PART_HDR_EXPLAN_CD"].ToString();
						_originalPart_hdr_serv_date = ConvertDEC(Reader["PART_HDR_SERV_DATE"]);
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