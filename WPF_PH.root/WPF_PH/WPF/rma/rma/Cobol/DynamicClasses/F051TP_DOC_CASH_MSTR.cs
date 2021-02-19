using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F051TP_DOC_CASH_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F051TP_DOC_CASH_MSTR> Collection( Guid? rowid,
															decimal? docashtp_clinic_nbrmin,
															decimal? docashtp_clinic_nbrmax,
															string docashtp_agent_cd,
															string docashtp_loc_cd,
															string docashtp_doc_nbr,
															decimal? docashtp_tech_in_mtdmin,
															decimal? docashtp_tech_in_mtdmax,
															decimal? docashtp_prof_in_mtdmin,
															decimal? docashtp_prof_in_mtdmax,
															decimal? docashtp_tech_out_mtdmin,
															decimal? docashtp_tech_out_mtdmax,
															decimal? docashtp_prof_out_mtdmin,
															decimal? docashtp_prof_out_mtdmax,
															decimal? docashtp_tech_in_ytdmin,
															decimal? docashtp_tech_in_ytdmax,
															decimal? docashtp_prof_in_ytdmin,
															decimal? docashtp_prof_in_ytdmax,
															decimal? docashtp_tech_out_ytdmin,
															decimal? docashtp_tech_out_ytdmax,
															decimal? docashtp_prof_out_ytdmin,
															decimal? docashtp_prof_out_ytdmax,
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
					new SqlParameter("minDOCASHTP_CLINIC_NBR",docashtp_clinic_nbrmin),
					new SqlParameter("maxDOCASHTP_CLINIC_NBR",docashtp_clinic_nbrmax),
					new SqlParameter("DOCASHTP_AGENT_CD",docashtp_agent_cd),
					new SqlParameter("DOCASHTP_LOC_CD",docashtp_loc_cd),
					new SqlParameter("DOCASHTP_DOC_NBR",docashtp_doc_nbr),
					new SqlParameter("minDOCASHTP_TECH_IN_MTD",docashtp_tech_in_mtdmin),
					new SqlParameter("maxDOCASHTP_TECH_IN_MTD",docashtp_tech_in_mtdmax),
					new SqlParameter("minDOCASHTP_PROF_IN_MTD",docashtp_prof_in_mtdmin),
					new SqlParameter("maxDOCASHTP_PROF_IN_MTD",docashtp_prof_in_mtdmax),
					new SqlParameter("minDOCASHTP_TECH_OUT_MTD",docashtp_tech_out_mtdmin),
					new SqlParameter("maxDOCASHTP_TECH_OUT_MTD",docashtp_tech_out_mtdmax),
					new SqlParameter("minDOCASHTP_PROF_OUT_MTD",docashtp_prof_out_mtdmin),
					new SqlParameter("maxDOCASHTP_PROF_OUT_MTD",docashtp_prof_out_mtdmax),
					new SqlParameter("minDOCASHTP_TECH_IN_YTD",docashtp_tech_in_ytdmin),
					new SqlParameter("maxDOCASHTP_TECH_IN_YTD",docashtp_tech_in_ytdmax),
					new SqlParameter("minDOCASHTP_PROF_IN_YTD",docashtp_prof_in_ytdmin),
					new SqlParameter("maxDOCASHTP_PROF_IN_YTD",docashtp_prof_in_ytdmax),
					new SqlParameter("minDOCASHTP_TECH_OUT_YTD",docashtp_tech_out_ytdmin),
					new SqlParameter("maxDOCASHTP_TECH_OUT_YTD",docashtp_tech_out_ytdmax),
					new SqlParameter("minDOCASHTP_PROF_OUT_YTD",docashtp_prof_out_ytdmin),
					new SqlParameter("maxDOCASHTP_PROF_OUT_YTD",docashtp_prof_out_ytdmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F051TP_DOC_CASH_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F051TP_DOC_CASH_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F051TP_DOC_CASH_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCASHTP_CLINIC_NBR = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]),
					DOCASHTP_AGENT_CD = Reader["DOCASHTP_AGENT_CD"].ToString(),
					DOCASHTP_LOC_CD = Reader["DOCASHTP_LOC_CD"].ToString(),
					DOCASHTP_DOC_NBR = Reader["DOCASHTP_DOC_NBR"].ToString(),
					DOCASHTP_TECH_IN_MTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]),
					DOCASHTP_PROF_IN_MTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]),
					DOCASHTP_TECH_OUT_MTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]),
					DOCASHTP_PROF_OUT_MTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]),
					DOCASHTP_TECH_IN_YTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]),
					DOCASHTP_PROF_IN_YTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]),
					DOCASHTP_TECH_OUT_YTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]),
					DOCASHTP_PROF_OUT_YTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocashtp_clinic_nbr = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]),
					_originalDocashtp_agent_cd = Reader["DOCASHTP_AGENT_CD"].ToString(),
					_originalDocashtp_loc_cd = Reader["DOCASHTP_LOC_CD"].ToString(),
					_originalDocashtp_doc_nbr = Reader["DOCASHTP_DOC_NBR"].ToString(),
					_originalDocashtp_tech_in_mtd = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]),
					_originalDocashtp_prof_in_mtd = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]),
					_originalDocashtp_tech_out_mtd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]),
					_originalDocashtp_prof_out_mtd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]),
					_originalDocashtp_tech_in_ytd = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]),
					_originalDocashtp_prof_in_ytd = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]),
					_originalDocashtp_tech_out_ytd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]),
					_originalDocashtp_prof_out_ytd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F051TP_DOC_CASH_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F051TP_DOC_CASH_MSTR> Collection(ObservableCollection<F051TP_DOC_CASH_MSTR>
                                                               f051tpDocCashMstr = null)
        {
            if (IsSameSearch() && f051tpDocCashMstr != null)
            {
                return f051tpDocCashMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F051TP_DOC_CASH_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOCASHTP_CLINIC_NBR",WhereDocashtp_clinic_nbr),
					new SqlParameter("DOCASHTP_AGENT_CD",WhereDocashtp_agent_cd),
					new SqlParameter("DOCASHTP_LOC_CD",WhereDocashtp_loc_cd),
					new SqlParameter("DOCASHTP_DOC_NBR",WhereDocashtp_doc_nbr),
					new SqlParameter("DOCASHTP_TECH_IN_MTD",WhereDocashtp_tech_in_mtd),
					new SqlParameter("DOCASHTP_PROF_IN_MTD",WhereDocashtp_prof_in_mtd),
					new SqlParameter("DOCASHTP_TECH_OUT_MTD",WhereDocashtp_tech_out_mtd),
					new SqlParameter("DOCASHTP_PROF_OUT_MTD",WhereDocashtp_prof_out_mtd),
					new SqlParameter("DOCASHTP_TECH_IN_YTD",WhereDocashtp_tech_in_ytd),
					new SqlParameter("DOCASHTP_PROF_IN_YTD",WhereDocashtp_prof_in_ytd),
					new SqlParameter("DOCASHTP_TECH_OUT_YTD",WhereDocashtp_tech_out_ytd),
					new SqlParameter("DOCASHTP_PROF_OUT_YTD",WhereDocashtp_prof_out_ytd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F051TP_DOC_CASH_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F051TP_DOC_CASH_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCASHTP_CLINIC_NBR = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]),
					DOCASHTP_AGENT_CD = Reader["DOCASHTP_AGENT_CD"].ToString(),
					DOCASHTP_LOC_CD = Reader["DOCASHTP_LOC_CD"].ToString(),
					DOCASHTP_DOC_NBR = Reader["DOCASHTP_DOC_NBR"].ToString(),
					DOCASHTP_TECH_IN_MTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]),
					DOCASHTP_PROF_IN_MTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]),
					DOCASHTP_TECH_OUT_MTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]),
					DOCASHTP_PROF_OUT_MTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]),
					DOCASHTP_TECH_IN_YTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]),
					DOCASHTP_PROF_IN_YTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]),
					DOCASHTP_TECH_OUT_YTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]),
					DOCASHTP_PROF_OUT_YTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDocashtp_clinic_nbr = WhereDocashtp_clinic_nbr,
					_whereDocashtp_agent_cd = WhereDocashtp_agent_cd,
					_whereDocashtp_loc_cd = WhereDocashtp_loc_cd,
					_whereDocashtp_doc_nbr = WhereDocashtp_doc_nbr,
					_whereDocashtp_tech_in_mtd = WhereDocashtp_tech_in_mtd,
					_whereDocashtp_prof_in_mtd = WhereDocashtp_prof_in_mtd,
					_whereDocashtp_tech_out_mtd = WhereDocashtp_tech_out_mtd,
					_whereDocashtp_prof_out_mtd = WhereDocashtp_prof_out_mtd,
					_whereDocashtp_tech_in_ytd = WhereDocashtp_tech_in_ytd,
					_whereDocashtp_prof_in_ytd = WhereDocashtp_prof_in_ytd,
					_whereDocashtp_tech_out_ytd = WhereDocashtp_tech_out_ytd,
					_whereDocashtp_prof_out_ytd = WhereDocashtp_prof_out_ytd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocashtp_clinic_nbr = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]),
					_originalDocashtp_agent_cd = Reader["DOCASHTP_AGENT_CD"].ToString(),
					_originalDocashtp_loc_cd = Reader["DOCASHTP_LOC_CD"].ToString(),
					_originalDocashtp_doc_nbr = Reader["DOCASHTP_DOC_NBR"].ToString(),
					_originalDocashtp_tech_in_mtd = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]),
					_originalDocashtp_prof_in_mtd = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]),
					_originalDocashtp_tech_out_mtd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]),
					_originalDocashtp_prof_out_mtd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]),
					_originalDocashtp_tech_in_ytd = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]),
					_originalDocashtp_prof_in_ytd = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]),
					_originalDocashtp_tech_out_ytd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]),
					_originalDocashtp_prof_out_ytd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDocashtp_clinic_nbr = WhereDocashtp_clinic_nbr;
					_whereDocashtp_agent_cd = WhereDocashtp_agent_cd;
					_whereDocashtp_loc_cd = WhereDocashtp_loc_cd;
					_whereDocashtp_doc_nbr = WhereDocashtp_doc_nbr;
					_whereDocashtp_tech_in_mtd = WhereDocashtp_tech_in_mtd;
					_whereDocashtp_prof_in_mtd = WhereDocashtp_prof_in_mtd;
					_whereDocashtp_tech_out_mtd = WhereDocashtp_tech_out_mtd;
					_whereDocashtp_prof_out_mtd = WhereDocashtp_prof_out_mtd;
					_whereDocashtp_tech_in_ytd = WhereDocashtp_tech_in_ytd;
					_whereDocashtp_prof_in_ytd = WhereDocashtp_prof_in_ytd;
					_whereDocashtp_tech_out_ytd = WhereDocashtp_tech_out_ytd;
					_whereDocashtp_prof_out_ytd = WhereDocashtp_prof_out_ytd;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDocashtp_clinic_nbr == null 
				&& WhereDocashtp_agent_cd == null 
				&& WhereDocashtp_loc_cd == null 
				&& WhereDocashtp_doc_nbr == null 
				&& WhereDocashtp_tech_in_mtd == null 
				&& WhereDocashtp_prof_in_mtd == null 
				&& WhereDocashtp_tech_out_mtd == null 
				&& WhereDocashtp_prof_out_mtd == null 
				&& WhereDocashtp_tech_in_ytd == null 
				&& WhereDocashtp_prof_in_ytd == null 
				&& WhereDocashtp_tech_out_ytd == null 
				&& WhereDocashtp_prof_out_ytd == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDocashtp_clinic_nbr ==  _whereDocashtp_clinic_nbr
				&& WhereDocashtp_agent_cd ==  _whereDocashtp_agent_cd
				&& WhereDocashtp_loc_cd ==  _whereDocashtp_loc_cd
				&& WhereDocashtp_doc_nbr ==  _whereDocashtp_doc_nbr
				&& WhereDocashtp_tech_in_mtd ==  _whereDocashtp_tech_in_mtd
				&& WhereDocashtp_prof_in_mtd ==  _whereDocashtp_prof_in_mtd
				&& WhereDocashtp_tech_out_mtd ==  _whereDocashtp_tech_out_mtd
				&& WhereDocashtp_prof_out_mtd ==  _whereDocashtp_prof_out_mtd
				&& WhereDocashtp_tech_in_ytd ==  _whereDocashtp_tech_in_ytd
				&& WhereDocashtp_prof_in_ytd ==  _whereDocashtp_prof_in_ytd
				&& WhereDocashtp_tech_out_ytd ==  _whereDocashtp_tech_out_ytd
				&& WhereDocashtp_prof_out_ytd ==  _whereDocashtp_prof_out_ytd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDocashtp_clinic_nbr = null; 
			WhereDocashtp_agent_cd = null; 
			WhereDocashtp_loc_cd = null; 
			WhereDocashtp_doc_nbr = null; 
			WhereDocashtp_tech_in_mtd = null; 
			WhereDocashtp_prof_in_mtd = null; 
			WhereDocashtp_tech_out_mtd = null; 
			WhereDocashtp_prof_out_mtd = null; 
			WhereDocashtp_tech_in_ytd = null; 
			WhereDocashtp_prof_in_ytd = null; 
			WhereDocashtp_tech_out_ytd = null; 
			WhereDocashtp_prof_out_ytd = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOCASHTP_CLINIC_NBR;
		private string _DOCASHTP_AGENT_CD;
		private string _DOCASHTP_LOC_CD;
		private string _DOCASHTP_DOC_NBR;
		private decimal? _DOCASHTP_TECH_IN_MTD;
		private decimal? _DOCASHTP_PROF_IN_MTD;
		private decimal? _DOCASHTP_TECH_OUT_MTD;
		private decimal? _DOCASHTP_PROF_OUT_MTD;
		private decimal? _DOCASHTP_TECH_IN_YTD;
		private decimal? _DOCASHTP_PROF_IN_YTD;
		private decimal? _DOCASHTP_TECH_OUT_YTD;
		private decimal? _DOCASHTP_PROF_OUT_YTD;
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
		public decimal? DOCASHTP_CLINIC_NBR
		{
			get { return _DOCASHTP_CLINIC_NBR; }
			set
			{
				if (_DOCASHTP_CLINIC_NBR != value)
				{
					_DOCASHTP_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOCASHTP_AGENT_CD
		{
			get { return _DOCASHTP_AGENT_CD; }
			set
			{
				if (_DOCASHTP_AGENT_CD != value)
				{
					_DOCASHTP_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string DOCASHTP_LOC_CD
		{
			get { return _DOCASHTP_LOC_CD; }
			set
			{
				if (_DOCASHTP_LOC_CD != value)
				{
					_DOCASHTP_LOC_CD = value;
					ChangeState();
				}
			}
		}
		public string DOCASHTP_DOC_NBR
		{
			get { return _DOCASHTP_DOC_NBR; }
			set
			{
				if (_DOCASHTP_DOC_NBR != value)
				{
					_DOCASHTP_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_TECH_IN_MTD
		{
			get { return _DOCASHTP_TECH_IN_MTD; }
			set
			{
				if (_DOCASHTP_TECH_IN_MTD != value)
				{
					_DOCASHTP_TECH_IN_MTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_PROF_IN_MTD
		{
			get { return _DOCASHTP_PROF_IN_MTD; }
			set
			{
				if (_DOCASHTP_PROF_IN_MTD != value)
				{
					_DOCASHTP_PROF_IN_MTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_TECH_OUT_MTD
		{
			get { return _DOCASHTP_TECH_OUT_MTD; }
			set
			{
				if (_DOCASHTP_TECH_OUT_MTD != value)
				{
					_DOCASHTP_TECH_OUT_MTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_PROF_OUT_MTD
		{
			get { return _DOCASHTP_PROF_OUT_MTD; }
			set
			{
				if (_DOCASHTP_PROF_OUT_MTD != value)
				{
					_DOCASHTP_PROF_OUT_MTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_TECH_IN_YTD
		{
			get { return _DOCASHTP_TECH_IN_YTD; }
			set
			{
				if (_DOCASHTP_TECH_IN_YTD != value)
				{
					_DOCASHTP_TECH_IN_YTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_PROF_IN_YTD
		{
			get { return _DOCASHTP_PROF_IN_YTD; }
			set
			{
				if (_DOCASHTP_PROF_IN_YTD != value)
				{
					_DOCASHTP_PROF_IN_YTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_TECH_OUT_YTD
		{
			get { return _DOCASHTP_TECH_OUT_YTD; }
			set
			{
				if (_DOCASHTP_TECH_OUT_YTD != value)
				{
					_DOCASHTP_TECH_OUT_YTD = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCASHTP_PROF_OUT_YTD
		{
			get { return _DOCASHTP_PROF_OUT_YTD; }
			set
			{
				if (_DOCASHTP_PROF_OUT_YTD != value)
				{
					_DOCASHTP_PROF_OUT_YTD = value;
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
		public decimal? WhereDocashtp_clinic_nbr { get; set; }
		private decimal? _whereDocashtp_clinic_nbr;
		public string WhereDocashtp_agent_cd { get; set; }
		private string _whereDocashtp_agent_cd;
		public string WhereDocashtp_loc_cd { get; set; }
		private string _whereDocashtp_loc_cd;
		public string WhereDocashtp_doc_nbr { get; set; }
		private string _whereDocashtp_doc_nbr;
		public decimal? WhereDocashtp_tech_in_mtd { get; set; }
		private decimal? _whereDocashtp_tech_in_mtd;
		public decimal? WhereDocashtp_prof_in_mtd { get; set; }
		private decimal? _whereDocashtp_prof_in_mtd;
		public decimal? WhereDocashtp_tech_out_mtd { get; set; }
		private decimal? _whereDocashtp_tech_out_mtd;
		public decimal? WhereDocashtp_prof_out_mtd { get; set; }
		private decimal? _whereDocashtp_prof_out_mtd;
		public decimal? WhereDocashtp_tech_in_ytd { get; set; }
		private decimal? _whereDocashtp_tech_in_ytd;
		public decimal? WhereDocashtp_prof_in_ytd { get; set; }
		private decimal? _whereDocashtp_prof_in_ytd;
		public decimal? WhereDocashtp_tech_out_ytd { get; set; }
		private decimal? _whereDocashtp_tech_out_ytd;
		public decimal? WhereDocashtp_prof_out_ytd { get; set; }
		private decimal? _whereDocashtp_prof_out_ytd;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDocashtp_clinic_nbr;
		private string _originalDocashtp_agent_cd;
		private string _originalDocashtp_loc_cd;
		private string _originalDocashtp_doc_nbr;
		private decimal? _originalDocashtp_tech_in_mtd;
		private decimal? _originalDocashtp_prof_in_mtd;
		private decimal? _originalDocashtp_tech_out_mtd;
		private decimal? _originalDocashtp_prof_out_mtd;
		private decimal? _originalDocashtp_tech_in_ytd;
		private decimal? _originalDocashtp_prof_in_ytd;
		private decimal? _originalDocashtp_tech_out_ytd;
		private decimal? _originalDocashtp_prof_out_ytd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOCASHTP_CLINIC_NBR = _originalDocashtp_clinic_nbr;
			DOCASHTP_AGENT_CD = _originalDocashtp_agent_cd;
			DOCASHTP_LOC_CD = _originalDocashtp_loc_cd;
			DOCASHTP_DOC_NBR = _originalDocashtp_doc_nbr;
			DOCASHTP_TECH_IN_MTD = _originalDocashtp_tech_in_mtd;
			DOCASHTP_PROF_IN_MTD = _originalDocashtp_prof_in_mtd;
			DOCASHTP_TECH_OUT_MTD = _originalDocashtp_tech_out_mtd;
			DOCASHTP_PROF_OUT_MTD = _originalDocashtp_prof_out_mtd;
			DOCASHTP_TECH_IN_YTD = _originalDocashtp_tech_in_ytd;
			DOCASHTP_PROF_IN_YTD = _originalDocashtp_prof_in_ytd;
			DOCASHTP_TECH_OUT_YTD = _originalDocashtp_tech_out_ytd;
			DOCASHTP_PROF_OUT_YTD = _originalDocashtp_prof_out_ytd;
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
					new SqlParameter("DOCASHTP_CLINIC_NBR",DOCASHTP_CLINIC_NBR),
					new SqlParameter("DOCASHTP_AGENT_CD",DOCASHTP_AGENT_CD),
					new SqlParameter("DOCASHTP_LOC_CD",DOCASHTP_LOC_CD),
					new SqlParameter("DOCASHTP_DOC_NBR",DOCASHTP_DOC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_Purge]");
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
						new SqlParameter("DOCASHTP_CLINIC_NBR", SqlNull(DOCASHTP_CLINIC_NBR)),
						new SqlParameter("DOCASHTP_AGENT_CD", SqlNull(DOCASHTP_AGENT_CD)),
						new SqlParameter("DOCASHTP_LOC_CD", SqlNull(DOCASHTP_LOC_CD)),
						new SqlParameter("DOCASHTP_DOC_NBR", SqlNull(DOCASHTP_DOC_NBR)),
						new SqlParameter("DOCASHTP_TECH_IN_MTD", SqlNull(DOCASHTP_TECH_IN_MTD)),
						new SqlParameter("DOCASHTP_PROF_IN_MTD", SqlNull(DOCASHTP_PROF_IN_MTD)),
						new SqlParameter("DOCASHTP_TECH_OUT_MTD", SqlNull(DOCASHTP_TECH_OUT_MTD)),
						new SqlParameter("DOCASHTP_PROF_OUT_MTD", SqlNull(DOCASHTP_PROF_OUT_MTD)),
						new SqlParameter("DOCASHTP_TECH_IN_YTD", SqlNull(DOCASHTP_TECH_IN_YTD)),
						new SqlParameter("DOCASHTP_PROF_IN_YTD", SqlNull(DOCASHTP_PROF_IN_YTD)),
						new SqlParameter("DOCASHTP_TECH_OUT_YTD", SqlNull(DOCASHTP_TECH_OUT_YTD)),
						new SqlParameter("DOCASHTP_PROF_OUT_YTD", SqlNull(DOCASHTP_PROF_OUT_YTD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCASHTP_CLINIC_NBR = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]);
						DOCASHTP_AGENT_CD = Reader["DOCASHTP_AGENT_CD"].ToString();
						DOCASHTP_LOC_CD = Reader["DOCASHTP_LOC_CD"].ToString();
						DOCASHTP_DOC_NBR = Reader["DOCASHTP_DOC_NBR"].ToString();
						DOCASHTP_TECH_IN_MTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]);
						DOCASHTP_PROF_IN_MTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]);
						DOCASHTP_TECH_OUT_MTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]);
						DOCASHTP_PROF_OUT_MTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]);
						DOCASHTP_TECH_IN_YTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]);
						DOCASHTP_PROF_IN_YTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]);
						DOCASHTP_TECH_OUT_YTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]);
						DOCASHTP_PROF_OUT_YTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocashtp_clinic_nbr = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]);
						_originalDocashtp_agent_cd = Reader["DOCASHTP_AGENT_CD"].ToString();
						_originalDocashtp_loc_cd = Reader["DOCASHTP_LOC_CD"].ToString();
						_originalDocashtp_doc_nbr = Reader["DOCASHTP_DOC_NBR"].ToString();
						_originalDocashtp_tech_in_mtd = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]);
						_originalDocashtp_prof_in_mtd = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]);
						_originalDocashtp_tech_out_mtd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]);
						_originalDocashtp_prof_out_mtd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]);
						_originalDocashtp_tech_in_ytd = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]);
						_originalDocashtp_prof_in_ytd = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]);
						_originalDocashtp_tech_out_ytd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]);
						_originalDocashtp_prof_out_ytd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOCASHTP_CLINIC_NBR", SqlNull(DOCASHTP_CLINIC_NBR)),
						new SqlParameter("DOCASHTP_AGENT_CD", SqlNull(DOCASHTP_AGENT_CD)),
						new SqlParameter("DOCASHTP_LOC_CD", SqlNull(DOCASHTP_LOC_CD)),
						new SqlParameter("DOCASHTP_DOC_NBR", SqlNull(DOCASHTP_DOC_NBR)),
						new SqlParameter("DOCASHTP_TECH_IN_MTD", SqlNull(DOCASHTP_TECH_IN_MTD)),
						new SqlParameter("DOCASHTP_PROF_IN_MTD", SqlNull(DOCASHTP_PROF_IN_MTD)),
						new SqlParameter("DOCASHTP_TECH_OUT_MTD", SqlNull(DOCASHTP_TECH_OUT_MTD)),
						new SqlParameter("DOCASHTP_PROF_OUT_MTD", SqlNull(DOCASHTP_PROF_OUT_MTD)),
						new SqlParameter("DOCASHTP_TECH_IN_YTD", SqlNull(DOCASHTP_TECH_IN_YTD)),
						new SqlParameter("DOCASHTP_PROF_IN_YTD", SqlNull(DOCASHTP_PROF_IN_YTD)),
						new SqlParameter("DOCASHTP_TECH_OUT_YTD", SqlNull(DOCASHTP_TECH_OUT_YTD)),
						new SqlParameter("DOCASHTP_PROF_OUT_YTD", SqlNull(DOCASHTP_PROF_OUT_YTD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F051TP_DOC_CASH_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCASHTP_CLINIC_NBR = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]);
						DOCASHTP_AGENT_CD = Reader["DOCASHTP_AGENT_CD"].ToString();
						DOCASHTP_LOC_CD = Reader["DOCASHTP_LOC_CD"].ToString();
						DOCASHTP_DOC_NBR = Reader["DOCASHTP_DOC_NBR"].ToString();
						DOCASHTP_TECH_IN_MTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]);
						DOCASHTP_PROF_IN_MTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]);
						DOCASHTP_TECH_OUT_MTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]);
						DOCASHTP_PROF_OUT_MTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]);
						DOCASHTP_TECH_IN_YTD = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]);
						DOCASHTP_PROF_IN_YTD = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]);
						DOCASHTP_TECH_OUT_YTD = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]);
						DOCASHTP_PROF_OUT_YTD = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocashtp_clinic_nbr = ConvertDEC(Reader["DOCASHTP_CLINIC_NBR"]);
						_originalDocashtp_agent_cd = Reader["DOCASHTP_AGENT_CD"].ToString();
						_originalDocashtp_loc_cd = Reader["DOCASHTP_LOC_CD"].ToString();
						_originalDocashtp_doc_nbr = Reader["DOCASHTP_DOC_NBR"].ToString();
						_originalDocashtp_tech_in_mtd = ConvertDEC(Reader["DOCASHTP_TECH_IN_MTD"]);
						_originalDocashtp_prof_in_mtd = ConvertDEC(Reader["DOCASHTP_PROF_IN_MTD"]);
						_originalDocashtp_tech_out_mtd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_MTD"]);
						_originalDocashtp_prof_out_mtd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_MTD"]);
						_originalDocashtp_tech_in_ytd = ConvertDEC(Reader["DOCASHTP_TECH_IN_YTD"]);
						_originalDocashtp_prof_in_ytd = ConvertDEC(Reader["DOCASHTP_PROF_IN_YTD"]);
						_originalDocashtp_tech_out_ytd = ConvertDEC(Reader["DOCASHTP_TECH_OUT_YTD"]);
						_originalDocashtp_prof_out_ytd = ConvertDEC(Reader["DOCASHTP_PROF_OUT_YTD"]);
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