using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F088_RAT_REJECTED_CLAIMS_HIST_HDR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR> Collection( Guid? rowid,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															decimal? pedmin,
															decimal? pedmax,
															string ohip_err_code,
															decimal? part_hdr_amt_billmin,
															decimal? part_hdr_amt_billmax,
															decimal? part_hdr_amt_paidmin,
															decimal? part_hdr_amt_paidmax,
															string clmhdr_doc_nbr,
															decimal? clmhdr_date_period_endmin,
															decimal? clmhdr_date_period_endmax,
															decimal? clmhdr_serv_datemin,
															decimal? clmhdr_serv_datemax,
															string charge_status,
															decimal? entry_datemin,
															decimal? entry_datemax,
															decimal? entry_time_longmin,
															decimal? entry_time_longmax,
															string entry_user_id,
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
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("minPED",pedmin),
					new SqlParameter("maxPED",pedmax),
					new SqlParameter("OHIP_ERR_CODE",ohip_err_code),
					new SqlParameter("minPART_HDR_AMT_BILL",part_hdr_amt_billmin),
					new SqlParameter("maxPART_HDR_AMT_BILL",part_hdr_amt_billmax),
					new SqlParameter("minPART_HDR_AMT_PAID",part_hdr_amt_paidmin),
					new SqlParameter("maxPART_HDR_AMT_PAID",part_hdr_amt_paidmax),
					new SqlParameter("CLMHDR_DOC_NBR",clmhdr_doc_nbr),
					new SqlParameter("minCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmin),
					new SqlParameter("maxCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmax),
					new SqlParameter("minCLMHDR_SERV_DATE",clmhdr_serv_datemin),
					new SqlParameter("maxCLMHDR_SERV_DATE",clmhdr_serv_datemax),
					new SqlParameter("CHARGE_STATUS",charge_status),
					new SqlParameter("minENTRY_DATE",entry_datemin),
					new SqlParameter("maxENTRY_DATE",entry_datemax),
					new SqlParameter("minENTRY_TIME_LONG",entry_time_longmin),
					new SqlParameter("maxENTRY_TIME_LONG",entry_time_longmax),
					new SqlParameter("ENTRY_USER_ID",entry_user_id),
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
                Reader = CoreReader("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_Search]", parameters);
            var collection = new ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F088_RAT_REJECTED_CLAIMS_HIST_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					PED = ConvertDEC(Reader["PED"]),
					OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString(),
					PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString(),
					_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalCharge_status = Reader["CHARGE_STATUS"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
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

        public F088_RAT_REJECTED_CLAIMS_HIST_HDR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR> Collection(ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR>
                                                               f088RatRejectedClaimsHistHdr = null)
        {
            if (IsSameSearch() && f088RatRejectedClaimsHistHdr != null)
            {
                return f088RatRejectedClaimsHistHdr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("PED",WherePed),
					new SqlParameter("OHIP_ERR_CODE",WhereOhip_err_code),
					new SqlParameter("PART_HDR_AMT_BILL",WherePart_hdr_amt_bill),
					new SqlParameter("PART_HDR_AMT_PAID",WherePart_hdr_amt_paid),
					new SqlParameter("CLMHDR_DOC_NBR",WhereClmhdr_doc_nbr),
					new SqlParameter("CLMHDR_DATE_PERIOD_END",WhereClmhdr_date_period_end),
					new SqlParameter("CLMHDR_SERV_DATE",WhereClmhdr_serv_date),
					new SqlParameter("CHARGE_STATUS",WhereCharge_status),
					new SqlParameter("ENTRY_DATE",WhereEntry_date),
					new SqlParameter("ENTRY_TIME_LONG",WhereEntry_time_long),
					new SqlParameter("ENTRY_USER_ID",WhereEntry_user_id),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_Match]", parameters);
            var collection = new ObservableCollection<F088_RAT_REJECTED_CLAIMS_HIST_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F088_RAT_REJECTED_CLAIMS_HIST_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					PED = ConvertDEC(Reader["PED"]),
					OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString(),
					PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
					_wherePed = WherePed,
					_whereOhip_err_code = WhereOhip_err_code,
					_wherePart_hdr_amt_bill = WherePart_hdr_amt_bill,
					_wherePart_hdr_amt_paid = WherePart_hdr_amt_paid,
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr,
					_whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
					_whereClmhdr_serv_date = WhereClmhdr_serv_date,
					_whereCharge_status = WhereCharge_status,
					_whereEntry_date = WhereEntry_date,
					_whereEntry_time_long = WhereEntry_time_long,
					_whereEntry_user_id = WhereEntry_user_id,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString(),
					_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]),
					_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]),
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalCharge_status = Reader["CHARGE_STATUS"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_wherePed = WherePed;
					_whereOhip_err_code = WhereOhip_err_code;
					_wherePart_hdr_amt_bill = WherePart_hdr_amt_bill;
					_wherePart_hdr_amt_paid = WherePart_hdr_amt_paid;
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr;
					_whereClmhdr_date_period_end = WhereClmhdr_date_period_end;
					_whereClmhdr_serv_date = WhereClmhdr_serv_date;
					_whereCharge_status = WhereCharge_status;
					_whereEntry_date = WhereEntry_date;
					_whereEntry_time_long = WhereEntry_time_long;
					_whereEntry_user_id = WhereEntry_user_id;
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
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WherePed == null 
				&& WhereOhip_err_code == null 
				&& WherePart_hdr_amt_bill == null 
				&& WherePart_hdr_amt_paid == null 
				&& WhereClmhdr_doc_nbr == null 
				&& WhereClmhdr_date_period_end == null 
				&& WhereClmhdr_serv_date == null 
				&& WhereCharge_status == null 
				&& WhereEntry_date == null 
				&& WhereEntry_time_long == null 
				&& WhereEntry_user_id == null 
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
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WherePed ==  _wherePed
				&& WhereOhip_err_code ==  _whereOhip_err_code
				&& WherePart_hdr_amt_bill ==  _wherePart_hdr_amt_bill
				&& WherePart_hdr_amt_paid ==  _wherePart_hdr_amt_paid
				&& WhereClmhdr_doc_nbr ==  _whereClmhdr_doc_nbr
				&& WhereClmhdr_date_period_end ==  _whereClmhdr_date_period_end
				&& WhereClmhdr_serv_date ==  _whereClmhdr_serv_date
				&& WhereCharge_status ==  _whereCharge_status
				&& WhereEntry_date ==  _whereEntry_date
				&& WhereEntry_time_long ==  _whereEntry_time_long
				&& WhereEntry_user_id ==  _whereEntry_user_id
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WherePed = null; 
			WhereOhip_err_code = null; 
			WherePart_hdr_amt_bill = null; 
			WherePart_hdr_amt_paid = null; 
			WhereClmhdr_doc_nbr = null; 
			WhereClmhdr_date_period_end = null; 
			WhereClmhdr_serv_date = null; 
			WhereCharge_status = null; 
			WhereEntry_date = null; 
			WhereEntry_time_long = null; 
			WhereEntry_user_id = null; 
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
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private decimal? _PED;
		private string _OHIP_ERR_CODE;
		private decimal? _PART_HDR_AMT_BILL;
		private decimal? _PART_HDR_AMT_PAID;
		private string _CLMHDR_DOC_NBR;
		private decimal? _CLMHDR_DATE_PERIOD_END;
		private decimal? _CLMHDR_SERV_DATE;
		private string _CHARGE_STATUS;
		private decimal? _ENTRY_DATE;
		private decimal? _ENTRY_TIME_LONG;
		private string _ENTRY_USER_ID;
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
		public decimal? PED
		{
			get { return _PED; }
			set
			{
				if (_PED != value)
				{
					_PED = value;
					ChangeState();
				}
			}
		}
		public string OHIP_ERR_CODE
		{
			get { return _OHIP_ERR_CODE; }
			set
			{
				if (_OHIP_ERR_CODE != value)
				{
					_OHIP_ERR_CODE = value;
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
		public string CLMHDR_DOC_NBR
		{
			get { return _CLMHDR_DOC_NBR; }
			set
			{
				if (_CLMHDR_DOC_NBR != value)
				{
					_CLMHDR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DATE_PERIOD_END
		{
			get { return _CLMHDR_DATE_PERIOD_END; }
			set
			{
				if (_CLMHDR_DATE_PERIOD_END != value)
				{
					_CLMHDR_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_SERV_DATE
		{
			get { return _CLMHDR_SERV_DATE; }
			set
			{
				if (_CLMHDR_SERV_DATE != value)
				{
					_CLMHDR_SERV_DATE = value;
					ChangeState();
				}
			}
		}
		public string CHARGE_STATUS
		{
			get { return _CHARGE_STATUS; }
			set
			{
				if (_CHARGE_STATUS != value)
				{
					_CHARGE_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_DATE
		{
			get { return _ENTRY_DATE; }
			set
			{
				if (_ENTRY_DATE != value)
				{
					_ENTRY_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_TIME_LONG
		{
			get { return _ENTRY_TIME_LONG; }
			set
			{
				if (_ENTRY_TIME_LONG != value)
				{
					_ENTRY_TIME_LONG = value;
					ChangeState();
				}
			}
		}
		public string ENTRY_USER_ID
		{
			get { return _ENTRY_USER_ID; }
			set
			{
				if (_ENTRY_USER_ID != value)
				{
					_ENTRY_USER_ID = value;
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
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public decimal? WherePed { get; set; }
		private decimal? _wherePed;
		public string WhereOhip_err_code { get; set; }
		private string _whereOhip_err_code;
		public decimal? WherePart_hdr_amt_bill { get; set; }
		private decimal? _wherePart_hdr_amt_bill;
		public decimal? WherePart_hdr_amt_paid { get; set; }
		private decimal? _wherePart_hdr_amt_paid;
		public string WhereClmhdr_doc_nbr { get; set; }
		private string _whereClmhdr_doc_nbr;
		public decimal? WhereClmhdr_date_period_end { get; set; }
		private decimal? _whereClmhdr_date_period_end;
		public decimal? WhereClmhdr_serv_date { get; set; }
		private decimal? _whereClmhdr_serv_date;
		public string WhereCharge_status { get; set; }
		private string _whereCharge_status;
		public decimal? WhereEntry_date { get; set; }
		private decimal? _whereEntry_date;
		public decimal? WhereEntry_time_long { get; set; }
		private decimal? _whereEntry_time_long;
		public string WhereEntry_user_id { get; set; }
		private string _whereEntry_user_id;
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
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private decimal? _originalPed;
		private string _originalOhip_err_code;
		private decimal? _originalPart_hdr_amt_bill;
		private decimal? _originalPart_hdr_amt_paid;
		private string _originalClmhdr_doc_nbr;
		private decimal? _originalClmhdr_date_period_end;
		private decimal? _originalClmhdr_serv_date;
		private string _originalCharge_status;
		private decimal? _originalEntry_date;
		private decimal? _originalEntry_time_long;
		private string _originalEntry_user_id;
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
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			PED = _originalPed;
			OHIP_ERR_CODE = _originalOhip_err_code;
			PART_HDR_AMT_BILL = _originalPart_hdr_amt_bill;
			PART_HDR_AMT_PAID = _originalPart_hdr_amt_paid;
			CLMHDR_DOC_NBR = _originalClmhdr_doc_nbr;
			CLMHDR_DATE_PERIOD_END = _originalClmhdr_date_period_end;
			CLMHDR_SERV_DATE = _originalClmhdr_serv_date;
			CHARGE_STATUS = _originalCharge_status;
			ENTRY_DATE = _originalEntry_date;
			ENTRY_TIME_LONG = _originalEntry_time_long;
			ENTRY_USER_ID = _originalEntry_user_id;
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
					new SqlParameter("CLMHDR_BATCH_NBR",CLMHDR_BATCH_NBR),
					new SqlParameter("CLMHDR_CLAIM_NBR",CLMHDR_CLAIM_NBR),
					new SqlParameter("PED",PED)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_Purge]");
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
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("OHIP_ERR_CODE", SqlNull(OHIP_ERR_CODE)),
						new SqlParameter("PART_HDR_AMT_BILL", SqlNull(PART_HDR_AMT_BILL)),
						new SqlParameter("PART_HDR_AMT_PAID", SqlNull(PART_HDR_AMT_PAID)),
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CHARGE_STATUS", SqlNull(CHARGE_STATUS)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						PED = ConvertDEC(Reader["PED"]);
						OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString();
						PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString();
						_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalCharge_status = Reader["CHARGE_STATUS"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
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
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("OHIP_ERR_CODE", SqlNull(OHIP_ERR_CODE)),
						new SqlParameter("PART_HDR_AMT_BILL", SqlNull(PART_HDR_AMT_BILL)),
						new SqlParameter("PART_HDR_AMT_PAID", SqlNull(PART_HDR_AMT_PAID)),
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CHARGE_STATUS", SqlNull(CHARGE_STATUS)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F088_RAT_REJECTED_CLAIMS_HIST_HDR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						PED = ConvertDEC(Reader["PED"]);
						OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString();
						PART_HDR_AMT_BILL = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						PART_HDR_AMT_PAID = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString();
						_originalPart_hdr_amt_bill = ConvertDEC(Reader["PART_HDR_AMT_BILL"]);
						_originalPart_hdr_amt_paid = ConvertDEC(Reader["PART_HDR_AMT_PAID"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalCharge_status = Reader["CHARGE_STATUS"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
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