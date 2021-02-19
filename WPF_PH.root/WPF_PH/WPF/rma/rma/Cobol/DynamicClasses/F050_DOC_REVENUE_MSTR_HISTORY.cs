using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F050_DOC_REVENUE_MSTR_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY> Collection( Guid? rowid,
															string docrev_clinic_1_2,
															decimal? docrev_deptmin,
															decimal? docrev_deptmax,
															string docrev_doc_nbr,
															string docrev_location,
															string docrev_oma_code,
															string docrev_oma_suff,
															decimal? ep_yrmin,
															decimal? ep_yrmax,
															decimal? iconst_date_period_endmin,
															decimal? iconst_date_period_endmax,
															decimal? docrev_mtd_in_recmin,
															decimal? docrev_mtd_in_recmax,
															decimal? docrev_mtd_in_svcmin,
															decimal? docrev_mtd_in_svcmax,
															decimal? docrev_mtd_out_recmin,
															decimal? docrev_mtd_out_recmax,
															decimal? docrev_mtd_out_svcmin,
															decimal? docrev_mtd_out_svcmax,
															decimal? docrev_ytd_in_recmin,
															decimal? docrev_ytd_in_recmax,
															decimal? docrev_ytd_in_svcmin,
															decimal? docrev_ytd_in_svcmax,
															decimal? docrev_ytd_out_recmin,
															decimal? docrev_ytd_out_recmax,
															decimal? docrev_ytd_out_svcmin,
															decimal? docrev_ytd_out_svcmax,
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
					new SqlParameter("DOCREV_CLINIC_1_2",docrev_clinic_1_2),
					new SqlParameter("minDOCREV_DEPT",docrev_deptmin),
					new SqlParameter("maxDOCREV_DEPT",docrev_deptmax),
					new SqlParameter("DOCREV_DOC_NBR",docrev_doc_nbr),
					new SqlParameter("DOCREV_LOCATION",docrev_location),
					new SqlParameter("DOCREV_OMA_CODE",docrev_oma_code),
					new SqlParameter("DOCREV_OMA_SUFF",docrev_oma_suff),
					new SqlParameter("minEP_YR",ep_yrmin),
					new SqlParameter("maxEP_YR",ep_yrmax),
					new SqlParameter("minICONST_DATE_PERIOD_END",iconst_date_period_endmin),
					new SqlParameter("maxICONST_DATE_PERIOD_END",iconst_date_period_endmax),
					new SqlParameter("minDOCREV_MTD_IN_REC",docrev_mtd_in_recmin),
					new SqlParameter("maxDOCREV_MTD_IN_REC",docrev_mtd_in_recmax),
					new SqlParameter("minDOCREV_MTD_IN_SVC",docrev_mtd_in_svcmin),
					new SqlParameter("maxDOCREV_MTD_IN_SVC",docrev_mtd_in_svcmax),
					new SqlParameter("minDOCREV_MTD_OUT_REC",docrev_mtd_out_recmin),
					new SqlParameter("maxDOCREV_MTD_OUT_REC",docrev_mtd_out_recmax),
					new SqlParameter("minDOCREV_MTD_OUT_SVC",docrev_mtd_out_svcmin),
					new SqlParameter("maxDOCREV_MTD_OUT_SVC",docrev_mtd_out_svcmax),
					new SqlParameter("minDOCREV_YTD_IN_REC",docrev_ytd_in_recmin),
					new SqlParameter("maxDOCREV_YTD_IN_REC",docrev_ytd_in_recmax),
					new SqlParameter("minDOCREV_YTD_IN_SVC",docrev_ytd_in_svcmin),
					new SqlParameter("maxDOCREV_YTD_IN_SVC",docrev_ytd_in_svcmax),
					new SqlParameter("minDOCREV_YTD_OUT_REC",docrev_ytd_out_recmin),
					new SqlParameter("maxDOCREV_YTD_OUT_REC",docrev_ytd_out_recmax),
					new SqlParameter("minDOCREV_YTD_OUT_SVC",docrev_ytd_out_svcmin),
					new SqlParameter("maxDOCREV_YTD_OUT_SVC",docrev_ytd_out_svcmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F050_DOC_REVENUE_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
					DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]),
					DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString(),
					DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString(),
					DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString(),
					DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
					DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
					DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
					DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
					DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
					DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocrev_clinic_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
					_originalDocrev_dept = ConvertDEC(Reader["DOCREV_DEPT"]),
					_originalDocrev_doc_nbr = Reader["DOCREV_DOC_NBR"].ToString(),
					_originalDocrev_location = Reader["DOCREV_LOCATION"].ToString(),
					_originalDocrev_oma_code = Reader["DOCREV_OMA_CODE"].ToString(),
					_originalDocrev_oma_suff = Reader["DOCREV_OMA_SUFF"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					_originalDocrev_mtd_in_svc = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
					_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					_originalDocrev_mtd_out_svc = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
					_originalDocrev_ytd_in_rec = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
					_originalDocrev_ytd_in_svc = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
					_originalDocrev_ytd_out_rec = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
					_originalDocrev_ytd_out_svc = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F050_DOC_REVENUE_MSTR_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY> Collection(ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY>
                                                               f050DocRevenueMstrHistory = null)
        {
            if (IsSameSearch() && f050DocRevenueMstrHistory != null)
            {
                return f050DocRevenueMstrHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOCREV_CLINIC_1_2",WhereDocrev_clinic_1_2),
					new SqlParameter("DOCREV_DEPT",WhereDocrev_dept),
					new SqlParameter("DOCREV_DOC_NBR",WhereDocrev_doc_nbr),
					new SqlParameter("DOCREV_LOCATION",WhereDocrev_location),
					new SqlParameter("DOCREV_OMA_CODE",WhereDocrev_oma_code),
					new SqlParameter("DOCREV_OMA_SUFF",WhereDocrev_oma_suff),
					new SqlParameter("EP_YR",WhereEp_yr),
					new SqlParameter("ICONST_DATE_PERIOD_END",WhereIconst_date_period_end),
					new SqlParameter("DOCREV_MTD_IN_REC",WhereDocrev_mtd_in_rec),
					new SqlParameter("DOCREV_MTD_IN_SVC",WhereDocrev_mtd_in_svc),
					new SqlParameter("DOCREV_MTD_OUT_REC",WhereDocrev_mtd_out_rec),
					new SqlParameter("DOCREV_MTD_OUT_SVC",WhereDocrev_mtd_out_svc),
					new SqlParameter("DOCREV_YTD_IN_REC",WhereDocrev_ytd_in_rec),
					new SqlParameter("DOCREV_YTD_IN_SVC",WhereDocrev_ytd_in_svc),
					new SqlParameter("DOCREV_YTD_OUT_REC",WhereDocrev_ytd_out_rec),
					new SqlParameter("DOCREV_YTD_OUT_SVC",WhereDocrev_ytd_out_svc),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F050_DOC_REVENUE_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F050_DOC_REVENUE_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
					DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]),
					DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString(),
					DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString(),
					DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString(),
					DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
					DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
					DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
					DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
					DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
					DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDocrev_clinic_1_2 = WhereDocrev_clinic_1_2,
					_whereDocrev_dept = WhereDocrev_dept,
					_whereDocrev_doc_nbr = WhereDocrev_doc_nbr,
					_whereDocrev_location = WhereDocrev_location,
					_whereDocrev_oma_code = WhereDocrev_oma_code,
					_whereDocrev_oma_suff = WhereDocrev_oma_suff,
					_whereEp_yr = WhereEp_yr,
					_whereIconst_date_period_end = WhereIconst_date_period_end,
					_whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec,
					_whereDocrev_mtd_in_svc = WhereDocrev_mtd_in_svc,
					_whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec,
					_whereDocrev_mtd_out_svc = WhereDocrev_mtd_out_svc,
					_whereDocrev_ytd_in_rec = WhereDocrev_ytd_in_rec,
					_whereDocrev_ytd_in_svc = WhereDocrev_ytd_in_svc,
					_whereDocrev_ytd_out_rec = WhereDocrev_ytd_out_rec,
					_whereDocrev_ytd_out_svc = WhereDocrev_ytd_out_svc,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocrev_clinic_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString(),
					_originalDocrev_dept = ConvertDEC(Reader["DOCREV_DEPT"]),
					_originalDocrev_doc_nbr = Reader["DOCREV_DOC_NBR"].ToString(),
					_originalDocrev_location = Reader["DOCREV_LOCATION"].ToString(),
					_originalDocrev_oma_code = Reader["DOCREV_OMA_CODE"].ToString(),
					_originalDocrev_oma_suff = Reader["DOCREV_OMA_SUFF"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]),
					_originalDocrev_mtd_in_svc = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]),
					_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]),
					_originalDocrev_mtd_out_svc = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]),
					_originalDocrev_ytd_in_rec = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]),
					_originalDocrev_ytd_in_svc = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]),
					_originalDocrev_ytd_out_rec = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]),
					_originalDocrev_ytd_out_svc = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDocrev_clinic_1_2 = WhereDocrev_clinic_1_2;
					_whereDocrev_dept = WhereDocrev_dept;
					_whereDocrev_doc_nbr = WhereDocrev_doc_nbr;
					_whereDocrev_location = WhereDocrev_location;
					_whereDocrev_oma_code = WhereDocrev_oma_code;
					_whereDocrev_oma_suff = WhereDocrev_oma_suff;
					_whereEp_yr = WhereEp_yr;
					_whereIconst_date_period_end = WhereIconst_date_period_end;
					_whereDocrev_mtd_in_rec = WhereDocrev_mtd_in_rec;
					_whereDocrev_mtd_in_svc = WhereDocrev_mtd_in_svc;
					_whereDocrev_mtd_out_rec = WhereDocrev_mtd_out_rec;
					_whereDocrev_mtd_out_svc = WhereDocrev_mtd_out_svc;
					_whereDocrev_ytd_in_rec = WhereDocrev_ytd_in_rec;
					_whereDocrev_ytd_in_svc = WhereDocrev_ytd_in_svc;
					_whereDocrev_ytd_out_rec = WhereDocrev_ytd_out_rec;
					_whereDocrev_ytd_out_svc = WhereDocrev_ytd_out_svc;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDocrev_clinic_1_2 == null 
				&& WhereDocrev_dept == null 
				&& WhereDocrev_doc_nbr == null 
				&& WhereDocrev_location == null 
				&& WhereDocrev_oma_code == null 
				&& WhereDocrev_oma_suff == null 
				&& WhereEp_yr == null 
				&& WhereIconst_date_period_end == null 
				&& WhereDocrev_mtd_in_rec == null 
				&& WhereDocrev_mtd_in_svc == null 
				&& WhereDocrev_mtd_out_rec == null 
				&& WhereDocrev_mtd_out_svc == null 
				&& WhereDocrev_ytd_in_rec == null 
				&& WhereDocrev_ytd_in_svc == null 
				&& WhereDocrev_ytd_out_rec == null 
				&& WhereDocrev_ytd_out_svc == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDocrev_clinic_1_2 ==  _whereDocrev_clinic_1_2
				&& WhereDocrev_dept ==  _whereDocrev_dept
				&& WhereDocrev_doc_nbr ==  _whereDocrev_doc_nbr
				&& WhereDocrev_location ==  _whereDocrev_location
				&& WhereDocrev_oma_code ==  _whereDocrev_oma_code
				&& WhereDocrev_oma_suff ==  _whereDocrev_oma_suff
				&& WhereEp_yr ==  _whereEp_yr
				&& WhereIconst_date_period_end ==  _whereIconst_date_period_end
				&& WhereDocrev_mtd_in_rec ==  _whereDocrev_mtd_in_rec
				&& WhereDocrev_mtd_in_svc ==  _whereDocrev_mtd_in_svc
				&& WhereDocrev_mtd_out_rec ==  _whereDocrev_mtd_out_rec
				&& WhereDocrev_mtd_out_svc ==  _whereDocrev_mtd_out_svc
				&& WhereDocrev_ytd_in_rec ==  _whereDocrev_ytd_in_rec
				&& WhereDocrev_ytd_in_svc ==  _whereDocrev_ytd_in_svc
				&& WhereDocrev_ytd_out_rec ==  _whereDocrev_ytd_out_rec
				&& WhereDocrev_ytd_out_svc ==  _whereDocrev_ytd_out_svc
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDocrev_clinic_1_2 = null; 
			WhereDocrev_dept = null; 
			WhereDocrev_doc_nbr = null; 
			WhereDocrev_location = null; 
			WhereDocrev_oma_code = null; 
			WhereDocrev_oma_suff = null; 
			WhereEp_yr = null; 
			WhereIconst_date_period_end = null; 
			WhereDocrev_mtd_in_rec = null; 
			WhereDocrev_mtd_in_svc = null; 
			WhereDocrev_mtd_out_rec = null; 
			WhereDocrev_mtd_out_svc = null; 
			WhereDocrev_ytd_in_rec = null; 
			WhereDocrev_ytd_in_svc = null; 
			WhereDocrev_ytd_out_rec = null; 
			WhereDocrev_ytd_out_svc = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOCREV_CLINIC_1_2;
		private decimal? _DOCREV_DEPT;
		private string _DOCREV_DOC_NBR;
		private string _DOCREV_LOCATION;
		private string _DOCREV_OMA_CODE;
		private string _DOCREV_OMA_SUFF;
		private decimal? _EP_YR;
		private decimal? _ICONST_DATE_PERIOD_END;
		private decimal? _DOCREV_MTD_IN_REC;
		private decimal? _DOCREV_MTD_IN_SVC;
		private decimal? _DOCREV_MTD_OUT_REC;
		private decimal? _DOCREV_MTD_OUT_SVC;
		private decimal? _DOCREV_YTD_IN_REC;
		private decimal? _DOCREV_YTD_IN_SVC;
		private decimal? _DOCREV_YTD_OUT_REC;
		private decimal? _DOCREV_YTD_OUT_SVC;
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
		public string DOCREV_CLINIC_1_2
		{
			get { return _DOCREV_CLINIC_1_2; }
			set
			{
				if (_DOCREV_CLINIC_1_2 != value)
				{
					_DOCREV_CLINIC_1_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_DEPT
		{
			get { return _DOCREV_DEPT; }
			set
			{
				if (_DOCREV_DEPT != value)
				{
					_DOCREV_DEPT = value;
					ChangeState();
				}
			}
		}
		public string DOCREV_DOC_NBR
		{
			get { return _DOCREV_DOC_NBR; }
			set
			{
				if (_DOCREV_DOC_NBR != value)
				{
					_DOCREV_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOCREV_LOCATION
		{
			get { return _DOCREV_LOCATION; }
			set
			{
				if (_DOCREV_LOCATION != value)
				{
					_DOCREV_LOCATION = value;
					ChangeState();
				}
			}
		}
		public string DOCREV_OMA_CODE
		{
			get { return _DOCREV_OMA_CODE; }
			set
			{
				if (_DOCREV_OMA_CODE != value)
				{
					_DOCREV_OMA_CODE = value;
					ChangeState();
				}
			}
		}
		public string DOCREV_OMA_SUFF
		{
			get { return _DOCREV_OMA_SUFF; }
			set
			{
				if (_DOCREV_OMA_SUFF != value)
				{
					_DOCREV_OMA_SUFF = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_YR
		{
			get { return _EP_YR; }
			set
			{
				if (_EP_YR != value)
				{
					_EP_YR = value;
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
		public decimal? DOCREV_MTD_IN_REC
		{
			get { return _DOCREV_MTD_IN_REC; }
			set
			{
				if (_DOCREV_MTD_IN_REC != value)
				{
					_DOCREV_MTD_IN_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_MTD_IN_SVC
		{
			get { return _DOCREV_MTD_IN_SVC; }
			set
			{
				if (_DOCREV_MTD_IN_SVC != value)
				{
					_DOCREV_MTD_IN_SVC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_MTD_OUT_REC
		{
			get { return _DOCREV_MTD_OUT_REC; }
			set
			{
				if (_DOCREV_MTD_OUT_REC != value)
				{
					_DOCREV_MTD_OUT_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_MTD_OUT_SVC
		{
			get { return _DOCREV_MTD_OUT_SVC; }
			set
			{
				if (_DOCREV_MTD_OUT_SVC != value)
				{
					_DOCREV_MTD_OUT_SVC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_YTD_IN_REC
		{
			get { return _DOCREV_YTD_IN_REC; }
			set
			{
				if (_DOCREV_YTD_IN_REC != value)
				{
					_DOCREV_YTD_IN_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_YTD_IN_SVC
		{
			get { return _DOCREV_YTD_IN_SVC; }
			set
			{
				if (_DOCREV_YTD_IN_SVC != value)
				{
					_DOCREV_YTD_IN_SVC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_YTD_OUT_REC
		{
			get { return _DOCREV_YTD_OUT_REC; }
			set
			{
				if (_DOCREV_YTD_OUT_REC != value)
				{
					_DOCREV_YTD_OUT_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREV_YTD_OUT_SVC
		{
			get { return _DOCREV_YTD_OUT_SVC; }
			set
			{
				if (_DOCREV_YTD_OUT_SVC != value)
				{
					_DOCREV_YTD_OUT_SVC = value;
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
		public string WhereDocrev_clinic_1_2 { get; set; }
		private string _whereDocrev_clinic_1_2;
		public decimal? WhereDocrev_dept { get; set; }
		private decimal? _whereDocrev_dept;
		public string WhereDocrev_doc_nbr { get; set; }
		private string _whereDocrev_doc_nbr;
		public string WhereDocrev_location { get; set; }
		private string _whereDocrev_location;
		public string WhereDocrev_oma_code { get; set; }
		private string _whereDocrev_oma_code;
		public string WhereDocrev_oma_suff { get; set; }
		private string _whereDocrev_oma_suff;
		public decimal? WhereEp_yr { get; set; }
		private decimal? _whereEp_yr;
		public decimal? WhereIconst_date_period_end { get; set; }
		private decimal? _whereIconst_date_period_end;
		public decimal? WhereDocrev_mtd_in_rec { get; set; }
		private decimal? _whereDocrev_mtd_in_rec;
		public decimal? WhereDocrev_mtd_in_svc { get; set; }
		private decimal? _whereDocrev_mtd_in_svc;
		public decimal? WhereDocrev_mtd_out_rec { get; set; }
		private decimal? _whereDocrev_mtd_out_rec;
		public decimal? WhereDocrev_mtd_out_svc { get; set; }
		private decimal? _whereDocrev_mtd_out_svc;
		public decimal? WhereDocrev_ytd_in_rec { get; set; }
		private decimal? _whereDocrev_ytd_in_rec;
		public decimal? WhereDocrev_ytd_in_svc { get; set; }
		private decimal? _whereDocrev_ytd_in_svc;
		public decimal? WhereDocrev_ytd_out_rec { get; set; }
		private decimal? _whereDocrev_ytd_out_rec;
		public decimal? WhereDocrev_ytd_out_svc { get; set; }
		private decimal? _whereDocrev_ytd_out_svc;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDocrev_clinic_1_2;
		private decimal? _originalDocrev_dept;
		private string _originalDocrev_doc_nbr;
		private string _originalDocrev_location;
		private string _originalDocrev_oma_code;
		private string _originalDocrev_oma_suff;
		private decimal? _originalEp_yr;
		private decimal? _originalIconst_date_period_end;
		private decimal? _originalDocrev_mtd_in_rec;
		private decimal? _originalDocrev_mtd_in_svc;
		private decimal? _originalDocrev_mtd_out_rec;
		private decimal? _originalDocrev_mtd_out_svc;
		private decimal? _originalDocrev_ytd_in_rec;
		private decimal? _originalDocrev_ytd_in_svc;
		private decimal? _originalDocrev_ytd_out_rec;
		private decimal? _originalDocrev_ytd_out_svc;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOCREV_CLINIC_1_2 = _originalDocrev_clinic_1_2;
			DOCREV_DEPT = _originalDocrev_dept;
			DOCREV_DOC_NBR = _originalDocrev_doc_nbr;
			DOCREV_LOCATION = _originalDocrev_location;
			DOCREV_OMA_CODE = _originalDocrev_oma_code;
			DOCREV_OMA_SUFF = _originalDocrev_oma_suff;
			EP_YR = _originalEp_yr;
			ICONST_DATE_PERIOD_END = _originalIconst_date_period_end;
			DOCREV_MTD_IN_REC = _originalDocrev_mtd_in_rec;
			DOCREV_MTD_IN_SVC = _originalDocrev_mtd_in_svc;
			DOCREV_MTD_OUT_REC = _originalDocrev_mtd_out_rec;
			DOCREV_MTD_OUT_SVC = _originalDocrev_mtd_out_svc;
			DOCREV_YTD_IN_REC = _originalDocrev_ytd_in_rec;
			DOCREV_YTD_IN_SVC = _originalDocrev_ytd_in_svc;
			DOCREV_YTD_OUT_REC = _originalDocrev_ytd_out_rec;
			DOCREV_YTD_OUT_SVC = _originalDocrev_ytd_out_svc;
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
					new SqlParameter("DOCREV_CLINIC_1_2",DOCREV_CLINIC_1_2),
					new SqlParameter("DOCREV_DEPT",DOCREV_DEPT),
					new SqlParameter("DOCREV_DOC_NBR",DOCREV_DOC_NBR),
					new SqlParameter("DOCREV_LOCATION",DOCREV_LOCATION),
					new SqlParameter("DOCREV_OMA_CODE",DOCREV_OMA_CODE),
					new SqlParameter("DOCREV_OMA_SUFF",DOCREV_OMA_SUFF),
					new SqlParameter("EP_YR",EP_YR),
					new SqlParameter("ICONST_DATE_PERIOD_END",ICONST_DATE_PERIOD_END)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_Purge]");
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
						new SqlParameter("DOCREV_CLINIC_1_2", SqlNull(DOCREV_CLINIC_1_2)),
						new SqlParameter("DOCREV_DEPT", SqlNull(DOCREV_DEPT)),
						new SqlParameter("DOCREV_DOC_NBR", SqlNull(DOCREV_DOC_NBR)),
						new SqlParameter("DOCREV_LOCATION", SqlNull(DOCREV_LOCATION)),
						new SqlParameter("DOCREV_OMA_CODE", SqlNull(DOCREV_OMA_CODE)),
						new SqlParameter("DOCREV_OMA_SUFF", SqlNull(DOCREV_OMA_SUFF)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("DOCREV_MTD_IN_REC", SqlNull(DOCREV_MTD_IN_REC)),
						new SqlParameter("DOCREV_MTD_IN_SVC", SqlNull(DOCREV_MTD_IN_SVC)),
						new SqlParameter("DOCREV_MTD_OUT_REC", SqlNull(DOCREV_MTD_OUT_REC)),
						new SqlParameter("DOCREV_MTD_OUT_SVC", SqlNull(DOCREV_MTD_OUT_SVC)),
						new SqlParameter("DOCREV_YTD_IN_REC", SqlNull(DOCREV_YTD_IN_REC)),
						new SqlParameter("DOCREV_YTD_IN_SVC", SqlNull(DOCREV_YTD_IN_SVC)),
						new SqlParameter("DOCREV_YTD_OUT_REC", SqlNull(DOCREV_YTD_OUT_REC)),
						new SqlParameter("DOCREV_YTD_OUT_SVC", SqlNull(DOCREV_YTD_OUT_SVC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString();
						DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]);
						DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString();
						DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString();
						DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString();
						DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]);
						DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]);
						DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]);
						DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]);
						DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]);
						DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocrev_clinic_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString();
						_originalDocrev_dept = ConvertDEC(Reader["DOCREV_DEPT"]);
						_originalDocrev_doc_nbr = Reader["DOCREV_DOC_NBR"].ToString();
						_originalDocrev_location = Reader["DOCREV_LOCATION"].ToString();
						_originalDocrev_oma_code = Reader["DOCREV_OMA_CODE"].ToString();
						_originalDocrev_oma_suff = Reader["DOCREV_OMA_SUFF"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						_originalDocrev_mtd_in_svc = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]);
						_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						_originalDocrev_mtd_out_svc = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]);
						_originalDocrev_ytd_in_rec = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]);
						_originalDocrev_ytd_in_svc = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]);
						_originalDocrev_ytd_out_rec = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]);
						_originalDocrev_ytd_out_svc = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOCREV_CLINIC_1_2", SqlNull(DOCREV_CLINIC_1_2)),
						new SqlParameter("DOCREV_DEPT", SqlNull(DOCREV_DEPT)),
						new SqlParameter("DOCREV_DOC_NBR", SqlNull(DOCREV_DOC_NBR)),
						new SqlParameter("DOCREV_LOCATION", SqlNull(DOCREV_LOCATION)),
						new SqlParameter("DOCREV_OMA_CODE", SqlNull(DOCREV_OMA_CODE)),
						new SqlParameter("DOCREV_OMA_SUFF", SqlNull(DOCREV_OMA_SUFF)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("DOCREV_MTD_IN_REC", SqlNull(DOCREV_MTD_IN_REC)),
						new SqlParameter("DOCREV_MTD_IN_SVC", SqlNull(DOCREV_MTD_IN_SVC)),
						new SqlParameter("DOCREV_MTD_OUT_REC", SqlNull(DOCREV_MTD_OUT_REC)),
						new SqlParameter("DOCREV_MTD_OUT_SVC", SqlNull(DOCREV_MTD_OUT_SVC)),
						new SqlParameter("DOCREV_YTD_IN_REC", SqlNull(DOCREV_YTD_IN_REC)),
						new SqlParameter("DOCREV_YTD_IN_SVC", SqlNull(DOCREV_YTD_IN_SVC)),
						new SqlParameter("DOCREV_YTD_OUT_REC", SqlNull(DOCREV_YTD_OUT_REC)),
						new SqlParameter("DOCREV_YTD_OUT_SVC", SqlNull(DOCREV_YTD_OUT_SVC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F050_DOC_REVENUE_MSTR_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCREV_CLINIC_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString();
						DOCREV_DEPT = ConvertDEC(Reader["DOCREV_DEPT"]);
						DOCREV_DOC_NBR = Reader["DOCREV_DOC_NBR"].ToString();
						DOCREV_LOCATION = Reader["DOCREV_LOCATION"].ToString();
						DOCREV_OMA_CODE = Reader["DOCREV_OMA_CODE"].ToString();
						DOCREV_OMA_SUFF = Reader["DOCREV_OMA_SUFF"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						DOCREV_MTD_IN_REC = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						DOCREV_MTD_IN_SVC = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]);
						DOCREV_MTD_OUT_REC = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						DOCREV_MTD_OUT_SVC = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]);
						DOCREV_YTD_IN_REC = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]);
						DOCREV_YTD_IN_SVC = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]);
						DOCREV_YTD_OUT_REC = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]);
						DOCREV_YTD_OUT_SVC = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocrev_clinic_1_2 = Reader["DOCREV_CLINIC_1_2"].ToString();
						_originalDocrev_dept = ConvertDEC(Reader["DOCREV_DEPT"]);
						_originalDocrev_doc_nbr = Reader["DOCREV_DOC_NBR"].ToString();
						_originalDocrev_location = Reader["DOCREV_LOCATION"].ToString();
						_originalDocrev_oma_code = Reader["DOCREV_OMA_CODE"].ToString();
						_originalDocrev_oma_suff = Reader["DOCREV_OMA_SUFF"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalDocrev_mtd_in_rec = ConvertDEC(Reader["DOCREV_MTD_IN_REC"]);
						_originalDocrev_mtd_in_svc = ConvertDEC(Reader["DOCREV_MTD_IN_SVC"]);
						_originalDocrev_mtd_out_rec = ConvertDEC(Reader["DOCREV_MTD_OUT_REC"]);
						_originalDocrev_mtd_out_svc = ConvertDEC(Reader["DOCREV_MTD_OUT_SVC"]);
						_originalDocrev_ytd_in_rec = ConvertDEC(Reader["DOCREV_YTD_IN_REC"]);
						_originalDocrev_ytd_in_svc = ConvertDEC(Reader["DOCREV_YTD_IN_SVC"]);
						_originalDocrev_ytd_out_rec = ConvertDEC(Reader["DOCREV_YTD_OUT_REC"]);
						_originalDocrev_ytd_out_svc = ConvertDEC(Reader["DOCREV_YTD_OUT_SVC"]);
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