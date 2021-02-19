using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F191_EARNINGS_PERIOD : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F191_EARNINGS_PERIOD> Collection( Guid? rowid,
															decimal? ep_nbrmin,
															decimal? ep_nbrmax,
															decimal? iconst_date_period_endmin,
															decimal? iconst_date_period_endmax,
															decimal? ep_date_startmin,
															decimal? ep_date_startmax,
															long? ep_date_endmin,
															long? ep_date_endmax,
															decimal? ep_qtr_calendarmin,
															decimal? ep_qtr_calendarmax,
															decimal? ep_qtr_fiscalmin,
															decimal? ep_qtr_fiscalmax,
															decimal? date_eft_depositmin,
															decimal? date_eft_depositmax,
															decimal? accounting_period_nbrmin,
															decimal? accounting_period_nbrmax,
															decimal? accounting_period_date_endmin,
															decimal? accounting_period_date_endmax,
															string ep_status,
															decimal? ep_date_closedmin,
															decimal? ep_date_closedmax,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
															decimal? ep_fiscal_nbrmin,
															decimal? ep_fiscal_nbrmax,
															string filler,
															decimal? ped_yyyymmmin,
															decimal? ped_yyyymmmax,
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
					new SqlParameter("minEP_NBR",ep_nbrmin),
					new SqlParameter("maxEP_NBR",ep_nbrmax),
					new SqlParameter("minICONST_DATE_PERIOD_END",iconst_date_period_endmin),
					new SqlParameter("maxICONST_DATE_PERIOD_END",iconst_date_period_endmax),
					new SqlParameter("minEP_DATE_START",ep_date_startmin),
					new SqlParameter("maxEP_DATE_START",ep_date_startmax),
					new SqlParameter("minEP_DATE_END",ep_date_endmin),
					new SqlParameter("maxEP_DATE_END",ep_date_endmax),
					new SqlParameter("minEP_QTR_CALENDAR",ep_qtr_calendarmin),
					new SqlParameter("maxEP_QTR_CALENDAR",ep_qtr_calendarmax),
					new SqlParameter("minEP_QTR_FISCAL",ep_qtr_fiscalmin),
					new SqlParameter("maxEP_QTR_FISCAL",ep_qtr_fiscalmax),
					new SqlParameter("minDATE_EFT_DEPOSIT",date_eft_depositmin),
					new SqlParameter("maxDATE_EFT_DEPOSIT",date_eft_depositmax),
					new SqlParameter("minACCOUNTING_PERIOD_NBR",accounting_period_nbrmin),
					new SqlParameter("maxACCOUNTING_PERIOD_NBR",accounting_period_nbrmax),
					new SqlParameter("minACCOUNTING_PERIOD_DATE_END",accounting_period_date_endmin),
					new SqlParameter("maxACCOUNTING_PERIOD_DATE_END",accounting_period_date_endmax),
					new SqlParameter("EP_STATUS",ep_status),
					new SqlParameter("minEP_DATE_CLOSED",ep_date_closedmin),
					new SqlParameter("maxEP_DATE_CLOSED",ep_date_closedmax),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minEP_FISCAL_NBR",ep_fiscal_nbrmin),
					new SqlParameter("maxEP_FISCAL_NBR",ep_fiscal_nbrmax),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minPED_YYYYMM",ped_yyyymmmin),
					new SqlParameter("maxPED_YYYYMM",ped_yyyymmmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F191_EARNINGS_PERIOD_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F191_EARNINGS_PERIOD>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F191_EARNINGS_PERIOD_Search]", parameters);
            var collection = new ObservableCollection<F191_EARNINGS_PERIOD>();

            while (Reader.Read())
            {
                collection.Add(new F191_EARNINGS_PERIOD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					EP_DATE_START = ConvertDEC(Reader["EP_DATE_START"]),
					EP_DATE_END = Reader["EP_DATE_END"].ToString(),
					EP_QTR_CALENDAR = ConvertDEC(Reader["EP_QTR_CALENDAR"]),
					EP_QTR_FISCAL = ConvertDEC(Reader["EP_QTR_FISCAL"]),
					DATE_EFT_DEPOSIT = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]),
					ACCOUNTING_PERIOD_NBR = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]),
					ACCOUNTING_PERIOD_DATE_END = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]),
					EP_STATUS = Reader["EP_STATUS"].ToString(),
					EP_DATE_CLOSED = ConvertDEC(Reader["EP_DATE_CLOSED"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					EP_FISCAL_NBR = ConvertDEC(Reader["EP_FISCAL_NBR"]),
					FILLER = Reader["FILLER"].ToString(),
					PED_YYYYMM = ConvertDEC(Reader["PED_YYYYMM"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalEp_date_start = ConvertDEC(Reader["EP_DATE_START"]),
					_originalEp_date_end = Reader["EP_DATE_END"].ToString(),
					_originalEp_qtr_calendar = ConvertDEC(Reader["EP_QTR_CALENDAR"]),
					_originalEp_qtr_fiscal = ConvertDEC(Reader["EP_QTR_FISCAL"]),
					_originalDate_eft_deposit = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]),
					_originalAccounting_period_nbr = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]),
					_originalAccounting_period_date_end = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]),
					_originalEp_status = Reader["EP_STATUS"].ToString(),
					_originalEp_date_closed = ConvertDEC(Reader["EP_DATE_CLOSED"]),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalEp_fiscal_nbr = ConvertDEC(Reader["EP_FISCAL_NBR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalPed_yyyymm = ConvertDEC(Reader["PED_YYYYMM"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F191_EARNINGS_PERIOD Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F191_EARNINGS_PERIOD> Collection(ObservableCollection<F191_EARNINGS_PERIOD>
                                                               f191EarningsPeriod = null)
        {
            if (IsSameSearch() && f191EarningsPeriod != null)
            {
                return f191EarningsPeriod;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F191_EARNINGS_PERIOD>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("EP_NBR",WhereEp_nbr),
					new SqlParameter("ICONST_DATE_PERIOD_END",WhereIconst_date_period_end),
					new SqlParameter("EP_DATE_START",WhereEp_date_start),
					new SqlParameter("EP_DATE_END",WhereEp_date_end),
					new SqlParameter("EP_QTR_CALENDAR",WhereEp_qtr_calendar),
					new SqlParameter("EP_QTR_FISCAL",WhereEp_qtr_fiscal),
					new SqlParameter("DATE_EFT_DEPOSIT",WhereDate_eft_deposit),
					new SqlParameter("ACCOUNTING_PERIOD_NBR",WhereAccounting_period_nbr),
					new SqlParameter("ACCOUNTING_PERIOD_DATE_END",WhereAccounting_period_date_end),
					new SqlParameter("EP_STATUS",WhereEp_status),
					new SqlParameter("EP_DATE_CLOSED",WhereEp_date_closed),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("EP_FISCAL_NBR",WhereEp_fiscal_nbr),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("PED_YYYYMM",WherePed_yyyymm),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F191_EARNINGS_PERIOD_Match]", parameters);
            var collection = new ObservableCollection<F191_EARNINGS_PERIOD>();

            while (Reader.Read())
            {
                collection.Add(new F191_EARNINGS_PERIOD
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					EP_NBR = ConvertDEC(Reader["EP_NBR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					EP_DATE_START = ConvertDEC(Reader["EP_DATE_START"]),
					EP_DATE_END = Reader["EP_DATE_END"].ToString(),
					EP_QTR_CALENDAR = ConvertDEC(Reader["EP_QTR_CALENDAR"]),
					EP_QTR_FISCAL = ConvertDEC(Reader["EP_QTR_FISCAL"]),
					DATE_EFT_DEPOSIT = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]),
					ACCOUNTING_PERIOD_NBR = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]),
					ACCOUNTING_PERIOD_DATE_END = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]),
					EP_STATUS = Reader["EP_STATUS"].ToString(),
					EP_DATE_CLOSED = ConvertDEC(Reader["EP_DATE_CLOSED"]),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					EP_FISCAL_NBR = ConvertDEC(Reader["EP_FISCAL_NBR"]),
					FILLER = Reader["FILLER"].ToString(),
					PED_YYYYMM = ConvertDEC(Reader["PED_YYYYMM"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereEp_nbr = WhereEp_nbr,
					_whereIconst_date_period_end = WhereIconst_date_period_end,
					_whereEp_date_start = WhereEp_date_start,
					_whereEp_date_end = WhereEp_date_end,
					_whereEp_qtr_calendar = WhereEp_qtr_calendar,
					_whereEp_qtr_fiscal = WhereEp_qtr_fiscal,
					_whereDate_eft_deposit = WhereDate_eft_deposit,
					_whereAccounting_period_nbr = WhereAccounting_period_nbr,
					_whereAccounting_period_date_end = WhereAccounting_period_date_end,
					_whereEp_status = WhereEp_status,
					_whereEp_date_closed = WhereEp_date_closed,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereEp_fiscal_nbr = WhereEp_fiscal_nbr,
					_whereFiller = WhereFiller,
					_wherePed_yyyymm = WherePed_yyyymm,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalEp_date_start = ConvertDEC(Reader["EP_DATE_START"]),
					_originalEp_date_end = Reader["EP_DATE_END"].ToString(),
					_originalEp_qtr_calendar = ConvertDEC(Reader["EP_QTR_CALENDAR"]),
					_originalEp_qtr_fiscal = ConvertDEC(Reader["EP_QTR_FISCAL"]),
					_originalDate_eft_deposit = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]),
					_originalAccounting_period_nbr = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]),
					_originalAccounting_period_date_end = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]),
					_originalEp_status = Reader["EP_STATUS"].ToString(),
					_originalEp_date_closed = ConvertDEC(Reader["EP_DATE_CLOSED"]),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalEp_fiscal_nbr = ConvertDEC(Reader["EP_FISCAL_NBR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalPed_yyyymm = ConvertDEC(Reader["PED_YYYYMM"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereEp_nbr = WhereEp_nbr;
					_whereIconst_date_period_end = WhereIconst_date_period_end;
					_whereEp_date_start = WhereEp_date_start;
					_whereEp_date_end = WhereEp_date_end;
					_whereEp_qtr_calendar = WhereEp_qtr_calendar;
					_whereEp_qtr_fiscal = WhereEp_qtr_fiscal;
					_whereDate_eft_deposit = WhereDate_eft_deposit;
					_whereAccounting_period_nbr = WhereAccounting_period_nbr;
					_whereAccounting_period_date_end = WhereAccounting_period_date_end;
					_whereEp_status = WhereEp_status;
					_whereEp_date_closed = WhereEp_date_closed;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
					_whereEp_fiscal_nbr = WhereEp_fiscal_nbr;
					_whereFiller = WhereFiller;
					_wherePed_yyyymm = WherePed_yyyymm;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereEp_nbr == null 
				&& WhereIconst_date_period_end == null 
				&& WhereEp_date_start == null 
				&& WhereEp_date_end == null 
				&& WhereEp_qtr_calendar == null 
				&& WhereEp_qtr_fiscal == null 
				&& WhereDate_eft_deposit == null 
				&& WhereAccounting_period_nbr == null 
				&& WhereAccounting_period_date_end == null 
				&& WhereEp_status == null 
				&& WhereEp_date_closed == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereEp_fiscal_nbr == null 
				&& WhereFiller == null 
				&& WherePed_yyyymm == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereEp_nbr ==  _whereEp_nbr
				&& WhereIconst_date_period_end ==  _whereIconst_date_period_end
				&& WhereEp_date_start ==  _whereEp_date_start
				&& WhereEp_date_end ==  _whereEp_date_end
				&& WhereEp_qtr_calendar ==  _whereEp_qtr_calendar
				&& WhereEp_qtr_fiscal ==  _whereEp_qtr_fiscal
				&& WhereDate_eft_deposit ==  _whereDate_eft_deposit
				&& WhereAccounting_period_nbr ==  _whereAccounting_period_nbr
				&& WhereAccounting_period_date_end ==  _whereAccounting_period_date_end
				&& WhereEp_status ==  _whereEp_status
				&& WhereEp_date_closed ==  _whereEp_date_closed
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereEp_fiscal_nbr ==  _whereEp_fiscal_nbr
				&& WhereFiller ==  _whereFiller
				&& WherePed_yyyymm ==  _wherePed_yyyymm
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereEp_nbr = null; 
			WhereIconst_date_period_end = null; 
			WhereEp_date_start = null; 
			WhereEp_date_end = null; 
			WhereEp_qtr_calendar = null; 
			WhereEp_qtr_fiscal = null; 
			WhereDate_eft_deposit = null; 
			WhereAccounting_period_nbr = null; 
			WhereAccounting_period_date_end = null; 
			WhereEp_status = null; 
			WhereEp_date_closed = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
			WhereEp_fiscal_nbr = null; 
			WhereFiller = null; 
			WherePed_yyyymm = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _EP_NBR;
		private decimal? _ICONST_DATE_PERIOD_END;
		private decimal? _EP_DATE_START;
		private string _EP_DATE_END;
		private decimal? _EP_QTR_CALENDAR;
		private decimal? _EP_QTR_FISCAL;
		private decimal? _DATE_EFT_DEPOSIT;
		private decimal? _ACCOUNTING_PERIOD_NBR;
		private decimal? _ACCOUNTING_PERIOD_DATE_END;
		private string _EP_STATUS;
		private decimal? _EP_DATE_CLOSED;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
		private decimal? _EP_FISCAL_NBR;
		private string _FILLER;
		private decimal? _PED_YYYYMM;
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
		public decimal? ICONST_DATE_PERIOD_END
		{
			get { return _ICONST_DATE_PERIOD_END; }
			set
			{
				if (_ICONST_DATE_PERIOD_END != value)
				{
					_ICONST_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_DATE_START
		{
			get { return _EP_DATE_START; }
			set
			{
				if (_EP_DATE_START != value)
				{
					_EP_DATE_START = value;
					ChangeState();
				}
			}
		}
		public string EP_DATE_END
		{
			get { return _EP_DATE_END; }
			set
			{
				if (_EP_DATE_END != value)
				{
					_EP_DATE_END = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_QTR_CALENDAR
		{
			get { return _EP_QTR_CALENDAR; }
			set
			{
				if (_EP_QTR_CALENDAR != value)
				{
					_EP_QTR_CALENDAR = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_QTR_FISCAL
		{
			get { return _EP_QTR_FISCAL; }
			set
			{
				if (_EP_QTR_FISCAL != value)
				{
					_EP_QTR_FISCAL = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_EFT_DEPOSIT
		{
			get { return _DATE_EFT_DEPOSIT; }
			set
			{
				if (_DATE_EFT_DEPOSIT != value)
				{
					_DATE_EFT_DEPOSIT = value;
					ChangeState();
				}
			}
		}
		public decimal? ACCOUNTING_PERIOD_NBR
		{
			get { return _ACCOUNTING_PERIOD_NBR; }
			set
			{
				if (_ACCOUNTING_PERIOD_NBR != value)
				{
					_ACCOUNTING_PERIOD_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? ACCOUNTING_PERIOD_DATE_END
		{
			get { return _ACCOUNTING_PERIOD_DATE_END; }
			set
			{
				if (_ACCOUNTING_PERIOD_DATE_END != value)
				{
					_ACCOUNTING_PERIOD_DATE_END = value;
					ChangeState();
				}
			}
		}
		public string EP_STATUS
		{
			get { return _EP_STATUS; }
			set
			{
				if (_EP_STATUS != value)
				{
					_EP_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_DATE_CLOSED
		{
			get { return _EP_DATE_CLOSED; }
			set
			{
				if (_EP_DATE_CLOSED != value)
				{
					_EP_DATE_CLOSED = value;
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
		public decimal? EP_FISCAL_NBR
		{
			get { return _EP_FISCAL_NBR; }
			set
			{
				if (_EP_FISCAL_NBR != value)
				{
					_EP_FISCAL_NBR = value;
					ChangeState();
				}
			}
		}
		public string FILLER
		{
			get { return _FILLER; }
			set
			{
				if (_FILLER != value)
				{
					_FILLER = value;
					ChangeState();
				}
			}
		}
		public decimal? PED_YYYYMM
		{
			get { return _PED_YYYYMM; }
			set
			{
				if (_PED_YYYYMM != value)
				{
					_PED_YYYYMM = value;
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
		public decimal? WhereEp_nbr { get; set; }
		private decimal? _whereEp_nbr;
		public decimal? WhereIconst_date_period_end { get; set; }
		private decimal? _whereIconst_date_period_end;
		public decimal? WhereEp_date_start { get; set; }
		private decimal? _whereEp_date_start;
		public string WhereEp_date_end { get; set; }
		private string _whereEp_date_end;
		public decimal? WhereEp_qtr_calendar { get; set; }
		private decimal? _whereEp_qtr_calendar;
		public decimal? WhereEp_qtr_fiscal { get; set; }
		private decimal? _whereEp_qtr_fiscal;
		public decimal? WhereDate_eft_deposit { get; set; }
		private decimal? _whereDate_eft_deposit;
		public decimal? WhereAccounting_period_nbr { get; set; }
		private decimal? _whereAccounting_period_nbr;
		public decimal? WhereAccounting_period_date_end { get; set; }
		private decimal? _whereAccounting_period_date_end;
		public string WhereEp_status { get; set; }
		private string _whereEp_status;
		public decimal? WhereEp_date_closed { get; set; }
		private decimal? _whereEp_date_closed;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public decimal? WhereEp_fiscal_nbr { get; set; }
		private decimal? _whereEp_fiscal_nbr;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public decimal? WherePed_yyyymm { get; set; }
		private decimal? _wherePed_yyyymm;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalEp_nbr;
		private decimal? _originalIconst_date_period_end;
		private decimal? _originalEp_date_start;
		private string _originalEp_date_end;
		private decimal? _originalEp_qtr_calendar;
		private decimal? _originalEp_qtr_fiscal;
		private decimal? _originalDate_eft_deposit;
		private decimal? _originalAccounting_period_nbr;
		private decimal? _originalAccounting_period_date_end;
		private string _originalEp_status;
		private decimal? _originalEp_date_closed;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private decimal? _originalEp_fiscal_nbr;
		private string _originalFiller;
		private decimal? _originalPed_yyyymm;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			EP_NBR = _originalEp_nbr;
			ICONST_DATE_PERIOD_END = _originalIconst_date_period_end;
			EP_DATE_START = _originalEp_date_start;
			EP_DATE_END = _originalEp_date_end;
			EP_QTR_CALENDAR = _originalEp_qtr_calendar;
			EP_QTR_FISCAL = _originalEp_qtr_fiscal;
			DATE_EFT_DEPOSIT = _originalDate_eft_deposit;
			ACCOUNTING_PERIOD_NBR = _originalAccounting_period_nbr;
			ACCOUNTING_PERIOD_DATE_END = _originalAccounting_period_date_end;
			EP_STATUS = _originalEp_status;
			EP_DATE_CLOSED = _originalEp_date_closed;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
			EP_FISCAL_NBR = _originalEp_fiscal_nbr;
			FILLER = _originalFiller;
			PED_YYYYMM = _originalPed_yyyymm;
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
					new SqlParameter("EP_NBR",EP_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F191_EARNINGS_PERIOD_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F191_EARNINGS_PERIOD_Purge]");
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
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("EP_DATE_START", SqlNull(EP_DATE_START)),
						new SqlParameter("EP_DATE_END", SqlNull(EP_DATE_END)),
						new SqlParameter("EP_QTR_CALENDAR", SqlNull(EP_QTR_CALENDAR)),
						new SqlParameter("EP_QTR_FISCAL", SqlNull(EP_QTR_FISCAL)),
						new SqlParameter("DATE_EFT_DEPOSIT", SqlNull(DATE_EFT_DEPOSIT)),
						new SqlParameter("ACCOUNTING_PERIOD_NBR", SqlNull(ACCOUNTING_PERIOD_NBR)),
						new SqlParameter("ACCOUNTING_PERIOD_DATE_END", SqlNull(ACCOUNTING_PERIOD_DATE_END)),
						new SqlParameter("EP_STATUS", SqlNull(EP_STATUS)),
						new SqlParameter("EP_DATE_CLOSED", SqlNull(EP_DATE_CLOSED)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("EP_FISCAL_NBR", SqlNull(EP_FISCAL_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("PED_YYYYMM", SqlNull(PED_YYYYMM)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F191_EARNINGS_PERIOD_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						EP_DATE_START = ConvertDEC(Reader["EP_DATE_START"]);
						EP_DATE_END = Reader["EP_DATE_END"].ToString();
						EP_QTR_CALENDAR = ConvertDEC(Reader["EP_QTR_CALENDAR"]);
						EP_QTR_FISCAL = ConvertDEC(Reader["EP_QTR_FISCAL"]);
						DATE_EFT_DEPOSIT = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]);
						ACCOUNTING_PERIOD_NBR = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]);
						ACCOUNTING_PERIOD_DATE_END = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]);
						EP_STATUS = Reader["EP_STATUS"].ToString();
						EP_DATE_CLOSED = ConvertDEC(Reader["EP_DATE_CLOSED"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						EP_FISCAL_NBR = ConvertDEC(Reader["EP_FISCAL_NBR"]);
						FILLER = Reader["FILLER"].ToString();
						PED_YYYYMM = ConvertDEC(Reader["PED_YYYYMM"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalEp_date_start = ConvertDEC(Reader["EP_DATE_START"]);
						_originalEp_date_end = Reader["EP_DATE_END"].ToString();
						_originalEp_qtr_calendar = ConvertDEC(Reader["EP_QTR_CALENDAR"]);
						_originalEp_qtr_fiscal = ConvertDEC(Reader["EP_QTR_FISCAL"]);
						_originalDate_eft_deposit = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]);
						_originalAccounting_period_nbr = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]);
						_originalAccounting_period_date_end = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]);
						_originalEp_status = Reader["EP_STATUS"].ToString();
						_originalEp_date_closed = ConvertDEC(Reader["EP_DATE_CLOSED"]);
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalEp_fiscal_nbr = ConvertDEC(Reader["EP_FISCAL_NBR"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalPed_yyyymm = ConvertDEC(Reader["PED_YYYYMM"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("EP_NBR", SqlNull(EP_NBR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("EP_DATE_START", SqlNull(EP_DATE_START)),
						new SqlParameter("EP_DATE_END", SqlNull(EP_DATE_END)),
						new SqlParameter("EP_QTR_CALENDAR", SqlNull(EP_QTR_CALENDAR)),
						new SqlParameter("EP_QTR_FISCAL", SqlNull(EP_QTR_FISCAL)),
						new SqlParameter("DATE_EFT_DEPOSIT", SqlNull(DATE_EFT_DEPOSIT)),
						new SqlParameter("ACCOUNTING_PERIOD_NBR", SqlNull(ACCOUNTING_PERIOD_NBR)),
						new SqlParameter("ACCOUNTING_PERIOD_DATE_END", SqlNull(ACCOUNTING_PERIOD_DATE_END)),
						new SqlParameter("EP_STATUS", SqlNull(EP_STATUS)),
						new SqlParameter("EP_DATE_CLOSED", SqlNull(EP_DATE_CLOSED)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("EP_FISCAL_NBR", SqlNull(EP_FISCAL_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("PED_YYYYMM", SqlNull(PED_YYYYMM)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F191_EARNINGS_PERIOD_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						EP_NBR = ConvertDEC(Reader["EP_NBR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						EP_DATE_START = ConvertDEC(Reader["EP_DATE_START"]);
						EP_DATE_END = Reader["EP_DATE_END"].ToString();
						EP_QTR_CALENDAR = ConvertDEC(Reader["EP_QTR_CALENDAR"]);
						EP_QTR_FISCAL = ConvertDEC(Reader["EP_QTR_FISCAL"]);
						DATE_EFT_DEPOSIT = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]);
						ACCOUNTING_PERIOD_NBR = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]);
						ACCOUNTING_PERIOD_DATE_END = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]);
						EP_STATUS = Reader["EP_STATUS"].ToString();
						EP_DATE_CLOSED = ConvertDEC(Reader["EP_DATE_CLOSED"]);
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						EP_FISCAL_NBR = ConvertDEC(Reader["EP_FISCAL_NBR"]);
						FILLER = Reader["FILLER"].ToString();
						PED_YYYYMM = ConvertDEC(Reader["PED_YYYYMM"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalEp_nbr = ConvertDEC(Reader["EP_NBR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalEp_date_start = ConvertDEC(Reader["EP_DATE_START"]);
						_originalEp_date_end = Reader["EP_DATE_END"].ToString();
						_originalEp_qtr_calendar = ConvertDEC(Reader["EP_QTR_CALENDAR"]);
						_originalEp_qtr_fiscal = ConvertDEC(Reader["EP_QTR_FISCAL"]);
						_originalDate_eft_deposit = ConvertDEC(Reader["DATE_EFT_DEPOSIT"]);
						_originalAccounting_period_nbr = ConvertDEC(Reader["ACCOUNTING_PERIOD_NBR"]);
						_originalAccounting_period_date_end = ConvertDEC(Reader["ACCOUNTING_PERIOD_DATE_END"]);
						_originalEp_status = Reader["EP_STATUS"].ToString();
						_originalEp_date_closed = ConvertDEC(Reader["EP_DATE_CLOSED"]);
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalEp_fiscal_nbr = ConvertDEC(Reader["EP_FISCAL_NBR"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalPed_yyyymm = ConvertDEC(Reader["PED_YYYYMM"]);
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