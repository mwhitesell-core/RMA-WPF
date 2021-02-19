using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F051_DOC_CASH_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F051_DOC_CASH_MSTR> Collection( Guid? rowid,
															string docash_clinic_1_2,
															decimal? docash_deptmin,
															decimal? docash_deptmax,
															string docash_doc_nbr,
															string docash_location,
															string docash_agency_type,
															decimal? docash_mtd_in_recmin,
															decimal? docash_mtd_in_recmax,
															decimal? docash_mtd_in_svcmin,
															decimal? docash_mtd_in_svcmax,
															decimal? docash_ytd_in_recmin,
															decimal? docash_ytd_in_recmax,
															decimal? docash_ytd_in_svcmin,
															decimal? docash_ytd_in_svcmax,
															string filler,
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
					new SqlParameter("DOCASH_CLINIC_1_2",docash_clinic_1_2),
					new SqlParameter("minDOCASH_DEPT",docash_deptmin),
					new SqlParameter("maxDOCASH_DEPT",docash_deptmax),
					new SqlParameter("DOCASH_DOC_NBR",docash_doc_nbr),
					new SqlParameter("DOCASH_LOCATION",docash_location),
					new SqlParameter("DOCASH_AGENCY_TYPE",docash_agency_type),
					new SqlParameter("minDOCASH_MTD_IN_REC",docash_mtd_in_recmin),
					new SqlParameter("maxDOCASH_MTD_IN_REC",docash_mtd_in_recmax),
					new SqlParameter("minDOCASH_MTD_IN_SVC",docash_mtd_in_svcmin),
					new SqlParameter("maxDOCASH_MTD_IN_SVC",docash_mtd_in_svcmax),
					new SqlParameter("minDOCASH_YTD_IN_REC",docash_ytd_in_recmin),
					new SqlParameter("maxDOCASH_YTD_IN_REC",docash_ytd_in_recmax),
					new SqlParameter("minDOCASH_YTD_IN_SVC",docash_ytd_in_svcmin),
					new SqlParameter("maxDOCASH_YTD_IN_SVC",docash_ytd_in_svcmax),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F051_DOC_CASH_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F051_DOC_CASH_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F051_DOC_CASH_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F051_DOC_CASH_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F051_DOC_CASH_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
					DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]),
					DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString(),
					DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString(),
					DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString(),
					DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
					DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
					DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
					DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocash_clinic_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
					_originalDocash_dept = ConvertDEC(Reader["DOCASH_DEPT"]),
					_originalDocash_doc_nbr = Reader["DOCASH_DOC_NBR"].ToString(),
					_originalDocash_location = Reader["DOCASH_LOCATION"].ToString(),
					_originalDocash_agency_type = Reader["DOCASH_AGENCY_TYPE"].ToString(),
					_originalDocash_mtd_in_rec = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
					_originalDocash_mtd_in_svc = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
					_originalDocash_ytd_in_rec = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
					_originalDocash_ytd_in_svc = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F051_DOC_CASH_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F051_DOC_CASH_MSTR> Collection(ObservableCollection<F051_DOC_CASH_MSTR>
                                                               f051DocCashMstr = null)
        {
            if (IsSameSearch() && f051DocCashMstr != null)
            {
                return f051DocCashMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F051_DOC_CASH_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOCASH_CLINIC_1_2",WhereDocash_clinic_1_2),
					new SqlParameter("DOCASH_DEPT",WhereDocash_dept),
					new SqlParameter("DOCASH_DOC_NBR",WhereDocash_doc_nbr),
					new SqlParameter("DOCASH_LOCATION",WhereDocash_location),
					new SqlParameter("DOCASH_AGENCY_TYPE",WhereDocash_agency_type),
					new SqlParameter("DOCASH_MTD_IN_REC",WhereDocash_mtd_in_rec),
					new SqlParameter("DOCASH_MTD_IN_SVC",WhereDocash_mtd_in_svc),
					new SqlParameter("DOCASH_YTD_IN_REC",WhereDocash_ytd_in_rec),
					new SqlParameter("DOCASH_YTD_IN_SVC",WhereDocash_ytd_in_svc),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F051_DOC_CASH_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F051_DOC_CASH_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F051_DOC_CASH_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
					DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]),
					DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString(),
					DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString(),
					DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString(),
					DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
					DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
					DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
					DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDocash_clinic_1_2 = WhereDocash_clinic_1_2,
					_whereDocash_dept = WhereDocash_dept,
					_whereDocash_doc_nbr = WhereDocash_doc_nbr,
					_whereDocash_location = WhereDocash_location,
					_whereDocash_agency_type = WhereDocash_agency_type,
					_whereDocash_mtd_in_rec = WhereDocash_mtd_in_rec,
					_whereDocash_mtd_in_svc = WhereDocash_mtd_in_svc,
					_whereDocash_ytd_in_rec = WhereDocash_ytd_in_rec,
					_whereDocash_ytd_in_svc = WhereDocash_ytd_in_svc,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocash_clinic_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString(),
					_originalDocash_dept = ConvertDEC(Reader["DOCASH_DEPT"]),
					_originalDocash_doc_nbr = Reader["DOCASH_DOC_NBR"].ToString(),
					_originalDocash_location = Reader["DOCASH_LOCATION"].ToString(),
					_originalDocash_agency_type = Reader["DOCASH_AGENCY_TYPE"].ToString(),
					_originalDocash_mtd_in_rec = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]),
					_originalDocash_mtd_in_svc = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]),
					_originalDocash_ytd_in_rec = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]),
					_originalDocash_ytd_in_svc = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDocash_clinic_1_2 = WhereDocash_clinic_1_2;
					_whereDocash_dept = WhereDocash_dept;
					_whereDocash_doc_nbr = WhereDocash_doc_nbr;
					_whereDocash_location = WhereDocash_location;
					_whereDocash_agency_type = WhereDocash_agency_type;
					_whereDocash_mtd_in_rec = WhereDocash_mtd_in_rec;
					_whereDocash_mtd_in_svc = WhereDocash_mtd_in_svc;
					_whereDocash_ytd_in_rec = WhereDocash_ytd_in_rec;
					_whereDocash_ytd_in_svc = WhereDocash_ytd_in_svc;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDocash_clinic_1_2 == null 
				&& WhereDocash_dept == null 
				&& WhereDocash_doc_nbr == null 
				&& WhereDocash_location == null 
				&& WhereDocash_agency_type == null 
				&& WhereDocash_mtd_in_rec == null 
				&& WhereDocash_mtd_in_svc == null 
				&& WhereDocash_ytd_in_rec == null 
				&& WhereDocash_ytd_in_svc == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDocash_clinic_1_2 ==  _whereDocash_clinic_1_2
				&& WhereDocash_dept ==  _whereDocash_dept
				&& WhereDocash_doc_nbr ==  _whereDocash_doc_nbr
				&& WhereDocash_location ==  _whereDocash_location
				&& WhereDocash_agency_type ==  _whereDocash_agency_type
				&& WhereDocash_mtd_in_rec ==  _whereDocash_mtd_in_rec
				&& WhereDocash_mtd_in_svc ==  _whereDocash_mtd_in_svc
				&& WhereDocash_ytd_in_rec ==  _whereDocash_ytd_in_rec
				&& WhereDocash_ytd_in_svc ==  _whereDocash_ytd_in_svc
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDocash_clinic_1_2 = null; 
			WhereDocash_dept = null; 
			WhereDocash_doc_nbr = null; 
			WhereDocash_location = null; 
			WhereDocash_agency_type = null; 
			WhereDocash_mtd_in_rec = null; 
			WhereDocash_mtd_in_svc = null; 
			WhereDocash_ytd_in_rec = null; 
			WhereDocash_ytd_in_svc = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOCASH_CLINIC_1_2;
		private decimal? _DOCASH_DEPT;
		private string _DOCASH_DOC_NBR;
		private string _DOCASH_LOCATION;
		private string _DOCASH_AGENCY_TYPE;
		private decimal? _DOCASH_MTD_IN_REC;
		private decimal? _DOCASH_MTD_IN_SVC;
		private decimal? _DOCASH_YTD_IN_REC;
		private decimal? _DOCASH_YTD_IN_SVC;
		private string _FILLER;
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
		public string DOCASH_CLINIC_1_2
		{
			get { return _DOCASH_CLINIC_1_2; }
			set
			{
				if (_DOCASH_CLINIC_1_2 != value)
				{
					_DOCASH_CLINIC_1_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASH_DEPT
		{
			get { return _DOCASH_DEPT; }
			set
			{
				if (_DOCASH_DEPT != value)
				{
					_DOCASH_DEPT = value;
					ChangeState();
				}
			}
		}
		public string DOCASH_DOC_NBR
		{
			get { return _DOCASH_DOC_NBR; }
			set
			{
				if (_DOCASH_DOC_NBR != value)
				{
					_DOCASH_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOCASH_LOCATION
		{
			get { return _DOCASH_LOCATION; }
			set
			{
				if (_DOCASH_LOCATION != value)
				{
					_DOCASH_LOCATION = value;
					ChangeState();
				}
			}
		}
		public string DOCASH_AGENCY_TYPE
		{
			get { return _DOCASH_AGENCY_TYPE; }
			set
			{
				if (_DOCASH_AGENCY_TYPE != value)
				{
					_DOCASH_AGENCY_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASH_MTD_IN_REC
		{
			get { return _DOCASH_MTD_IN_REC; }
			set
			{
				if (_DOCASH_MTD_IN_REC != value)
				{
					_DOCASH_MTD_IN_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASH_MTD_IN_SVC
		{
			get { return _DOCASH_MTD_IN_SVC; }
			set
			{
				if (_DOCASH_MTD_IN_SVC != value)
				{
					_DOCASH_MTD_IN_SVC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASH_YTD_IN_REC
		{
			get { return _DOCASH_YTD_IN_REC; }
			set
			{
				if (_DOCASH_YTD_IN_REC != value)
				{
					_DOCASH_YTD_IN_REC = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASH_YTD_IN_SVC
		{
			get { return _DOCASH_YTD_IN_SVC; }
			set
			{
				if (_DOCASH_YTD_IN_SVC != value)
				{
					_DOCASH_YTD_IN_SVC = value;
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
		public string WhereDocash_clinic_1_2 { get; set; }
		private string _whereDocash_clinic_1_2;
		public decimal? WhereDocash_dept { get; set; }
		private decimal? _whereDocash_dept;
		public string WhereDocash_doc_nbr { get; set; }
		private string _whereDocash_doc_nbr;
		public string WhereDocash_location { get; set; }
		private string _whereDocash_location;
		public string WhereDocash_agency_type { get; set; }
		private string _whereDocash_agency_type;
		public decimal? WhereDocash_mtd_in_rec { get; set; }
		private decimal? _whereDocash_mtd_in_rec;
		public decimal? WhereDocash_mtd_in_svc { get; set; }
		private decimal? _whereDocash_mtd_in_svc;
		public decimal? WhereDocash_ytd_in_rec { get; set; }
		private decimal? _whereDocash_ytd_in_rec;
		public decimal? WhereDocash_ytd_in_svc { get; set; }
		private decimal? _whereDocash_ytd_in_svc;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDocash_clinic_1_2;
		private decimal? _originalDocash_dept;
		private string _originalDocash_doc_nbr;
		private string _originalDocash_location;
		private string _originalDocash_agency_type;
		private decimal? _originalDocash_mtd_in_rec;
		private decimal? _originalDocash_mtd_in_svc;
		private decimal? _originalDocash_ytd_in_rec;
		private decimal? _originalDocash_ytd_in_svc;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOCASH_CLINIC_1_2 = _originalDocash_clinic_1_2;
			DOCASH_DEPT = _originalDocash_dept;
			DOCASH_DOC_NBR = _originalDocash_doc_nbr;
			DOCASH_LOCATION = _originalDocash_location;
			DOCASH_AGENCY_TYPE = _originalDocash_agency_type;
			DOCASH_MTD_IN_REC = _originalDocash_mtd_in_rec;
			DOCASH_MTD_IN_SVC = _originalDocash_mtd_in_svc;
			DOCASH_YTD_IN_REC = _originalDocash_ytd_in_rec;
			DOCASH_YTD_IN_SVC = _originalDocash_ytd_in_svc;
			FILLER = _originalFiller;
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
					new SqlParameter("DOCASH_CLINIC_1_2",DOCASH_CLINIC_1_2),
					new SqlParameter("DOCASH_DEPT",DOCASH_DEPT),
					new SqlParameter("DOCASH_DOC_NBR",DOCASH_DOC_NBR),
					new SqlParameter("DOCASH_LOCATION",DOCASH_LOCATION),
					new SqlParameter("DOCASH_AGENCY_TYPE",DOCASH_AGENCY_TYPE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F051_DOC_CASH_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F051_DOC_CASH_MSTR_Purge]");
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
						new SqlParameter("DOCASH_CLINIC_1_2", SqlNull(DOCASH_CLINIC_1_2)),
						new SqlParameter("DOCASH_DEPT", SqlNull(DOCASH_DEPT)),
						new SqlParameter("DOCASH_DOC_NBR", SqlNull(DOCASH_DOC_NBR)),
						new SqlParameter("DOCASH_LOCATION", SqlNull(DOCASH_LOCATION)),
						new SqlParameter("DOCASH_AGENCY_TYPE", SqlNull(DOCASH_AGENCY_TYPE)),
						new SqlParameter("DOCASH_MTD_IN_REC", SqlNull(DOCASH_MTD_IN_REC)),
						new SqlParameter("DOCASH_MTD_IN_SVC", SqlNull(DOCASH_MTD_IN_SVC)),
						new SqlParameter("DOCASH_YTD_IN_REC", SqlNull(DOCASH_YTD_IN_REC)),
						new SqlParameter("DOCASH_YTD_IN_SVC", SqlNull(DOCASH_YTD_IN_SVC)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F051_DOC_CASH_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString();
						DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]);
						DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString();
						DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString();
						DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString();
						DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]);
						DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]);
						DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]);
						DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocash_clinic_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString();
						_originalDocash_dept = ConvertDEC(Reader["DOCASH_DEPT"]);
						_originalDocash_doc_nbr = Reader["DOCASH_DOC_NBR"].ToString();
						_originalDocash_location = Reader["DOCASH_LOCATION"].ToString();
						_originalDocash_agency_type = Reader["DOCASH_AGENCY_TYPE"].ToString();
						_originalDocash_mtd_in_rec = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]);
						_originalDocash_mtd_in_svc = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]);
						_originalDocash_ytd_in_rec = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]);
						_originalDocash_ytd_in_svc = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOCASH_CLINIC_1_2", SqlNull(DOCASH_CLINIC_1_2)),
						new SqlParameter("DOCASH_DEPT", SqlNull(DOCASH_DEPT)),
						new SqlParameter("DOCASH_DOC_NBR", SqlNull(DOCASH_DOC_NBR)),
						new SqlParameter("DOCASH_LOCATION", SqlNull(DOCASH_LOCATION)),
						new SqlParameter("DOCASH_AGENCY_TYPE", SqlNull(DOCASH_AGENCY_TYPE)),
						new SqlParameter("DOCASH_MTD_IN_REC", SqlNull(DOCASH_MTD_IN_REC)),
						new SqlParameter("DOCASH_MTD_IN_SVC", SqlNull(DOCASH_MTD_IN_SVC)),
						new SqlParameter("DOCASH_YTD_IN_REC", SqlNull(DOCASH_YTD_IN_REC)),
						new SqlParameter("DOCASH_YTD_IN_SVC", SqlNull(DOCASH_YTD_IN_SVC)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F051_DOC_CASH_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCASH_CLINIC_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString();
						DOCASH_DEPT = ConvertDEC(Reader["DOCASH_DEPT"]);
						DOCASH_DOC_NBR = Reader["DOCASH_DOC_NBR"].ToString();
						DOCASH_LOCATION = Reader["DOCASH_LOCATION"].ToString();
						DOCASH_AGENCY_TYPE = Reader["DOCASH_AGENCY_TYPE"].ToString();
						DOCASH_MTD_IN_REC = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]);
						DOCASH_MTD_IN_SVC = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]);
						DOCASH_YTD_IN_REC = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]);
						DOCASH_YTD_IN_SVC = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocash_clinic_1_2 = Reader["DOCASH_CLINIC_1_2"].ToString();
						_originalDocash_dept = ConvertDEC(Reader["DOCASH_DEPT"]);
						_originalDocash_doc_nbr = Reader["DOCASH_DOC_NBR"].ToString();
						_originalDocash_location = Reader["DOCASH_LOCATION"].ToString();
						_originalDocash_agency_type = Reader["DOCASH_AGENCY_TYPE"].ToString();
						_originalDocash_mtd_in_rec = ConvertDEC(Reader["DOCASH_MTD_IN_REC"]);
						_originalDocash_mtd_in_svc = ConvertDEC(Reader["DOCASH_MTD_IN_SVC"]);
						_originalDocash_ytd_in_rec = ConvertDEC(Reader["DOCASH_YTD_IN_REC"]);
						_originalDocash_ytd_in_svc = ConvertDEC(Reader["DOCASH_YTD_IN_SVC"]);
						_originalFiller = Reader["FILLER"].ToString();
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