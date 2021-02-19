using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_7 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_7> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? previous_fiscal_start_yymmddmin,
															decimal? previous_fiscal_start_yymmddmax,
															decimal? previous_fiscal_end_yymmddmin,
															decimal? previous_fiscal_end_yymmddmax,
															decimal? current_fiscal_start_yymmddmin,
															decimal? current_fiscal_start_yymmddmax,
															decimal? current_fiscal_end_yymmddmin,
															decimal? current_fiscal_end_yymmddmax,
															decimal? current_costing_cutoff_yymmddmin,
															decimal? current_costing_cutoff_yymmddmax,
															decimal? ep_yrmin,
															decimal? ep_yrmax,
															decimal? current_costing_pedmin,
															decimal? current_costing_pedmax,
															decimal? ohip_run_datemin,
															decimal? ohip_run_datemax,
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
					new SqlParameter("minCONST_REC_NBR",const_rec_nbrmin),
					new SqlParameter("maxCONST_REC_NBR",const_rec_nbrmax),
					new SqlParameter("minPREVIOUS_FISCAL_START_YYMMDD",previous_fiscal_start_yymmddmin),
					new SqlParameter("maxPREVIOUS_FISCAL_START_YYMMDD",previous_fiscal_start_yymmddmax),
					new SqlParameter("minPREVIOUS_FISCAL_END_YYMMDD",previous_fiscal_end_yymmddmin),
					new SqlParameter("maxPREVIOUS_FISCAL_END_YYMMDD",previous_fiscal_end_yymmddmax),
					new SqlParameter("minCURRENT_FISCAL_START_YYMMDD",current_fiscal_start_yymmddmin),
					new SqlParameter("maxCURRENT_FISCAL_START_YYMMDD",current_fiscal_start_yymmddmax),
					new SqlParameter("minCURRENT_FISCAL_END_YYMMDD",current_fiscal_end_yymmddmin),
					new SqlParameter("maxCURRENT_FISCAL_END_YYMMDD",current_fiscal_end_yymmddmax),
					new SqlParameter("minCURRENT_COSTING_CUTOFF_YYMMDD",current_costing_cutoff_yymmddmin),
					new SqlParameter("maxCURRENT_COSTING_CUTOFF_YYMMDD",current_costing_cutoff_yymmddmax),
					new SqlParameter("minEP_YR",ep_yrmin),
					new SqlParameter("maxEP_YR",ep_yrmax),
					new SqlParameter("minCURRENT_COSTING_PED",current_costing_pedmin),
					new SqlParameter("maxCURRENT_COSTING_PED",current_costing_pedmax),
					new SqlParameter("minOHIP_RUN_DATE",ohip_run_datemin),
					new SqlParameter("maxOHIP_RUN_DATE",ohip_run_datemax),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_7>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_7>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_7
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					PREVIOUS_FISCAL_START_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]),
					PREVIOUS_FISCAL_END_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]),
					CURRENT_FISCAL_START_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]),
					CURRENT_FISCAL_END_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]),
					CURRENT_COSTING_CUTOFF_YYMMDD = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					CURRENT_COSTING_PED = ConvertDEC(Reader["CURRENT_COSTING_PED"]),
					OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalPrevious_fiscal_start_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]),
					_originalPrevious_fiscal_end_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]),
					_originalCurrent_fiscal_start_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]),
					_originalCurrent_fiscal_end_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]),
					_originalCurrent_costing_cutoff_yymmdd = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalCurrent_costing_ped = ConvertDEC(Reader["CURRENT_COSTING_PED"]),
					_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_7 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_7> Collection(ObservableCollection<CONSTANTS_MSTR_REC_7>
                                                               constantsMstrRec7 = null)
        {
            if (IsSameSearch() && constantsMstrRec7 != null)
            {
                return constantsMstrRec7;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_7>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("PREVIOUS_FISCAL_START_YYMMDD",WherePrevious_fiscal_start_yymmdd),
					new SqlParameter("PREVIOUS_FISCAL_END_YYMMDD",WherePrevious_fiscal_end_yymmdd),
					new SqlParameter("CURRENT_FISCAL_START_YYMMDD",WhereCurrent_fiscal_start_yymmdd),
					new SqlParameter("CURRENT_FISCAL_END_YYMMDD",WhereCurrent_fiscal_end_yymmdd),
					new SqlParameter("CURRENT_COSTING_CUTOFF_YYMMDD",WhereCurrent_costing_cutoff_yymmdd),
					new SqlParameter("EP_YR",WhereEp_yr),
					new SqlParameter("CURRENT_COSTING_PED",WhereCurrent_costing_ped),
					new SqlParameter("OHIP_RUN_DATE",WhereOhip_run_date),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_7>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_7
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					PREVIOUS_FISCAL_START_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]),
					PREVIOUS_FISCAL_END_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]),
					CURRENT_FISCAL_START_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]),
					CURRENT_FISCAL_END_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]),
					CURRENT_COSTING_CUTOFF_YYMMDD = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					CURRENT_COSTING_PED = ConvertDEC(Reader["CURRENT_COSTING_PED"]),
					OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_wherePrevious_fiscal_start_yymmdd = WherePrevious_fiscal_start_yymmdd,
					_wherePrevious_fiscal_end_yymmdd = WherePrevious_fiscal_end_yymmdd,
					_whereCurrent_fiscal_start_yymmdd = WhereCurrent_fiscal_start_yymmdd,
					_whereCurrent_fiscal_end_yymmdd = WhereCurrent_fiscal_end_yymmdd,
					_whereCurrent_costing_cutoff_yymmdd = WhereCurrent_costing_cutoff_yymmdd,
					_whereEp_yr = WhereEp_yr,
					_whereCurrent_costing_ped = WhereCurrent_costing_ped,
					_whereOhip_run_date = WhereOhip_run_date,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalPrevious_fiscal_start_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]),
					_originalPrevious_fiscal_end_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]),
					_originalCurrent_fiscal_start_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]),
					_originalCurrent_fiscal_end_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]),
					_originalCurrent_costing_cutoff_yymmdd = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalCurrent_costing_ped = ConvertDEC(Reader["CURRENT_COSTING_PED"]),
					_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_wherePrevious_fiscal_start_yymmdd = WherePrevious_fiscal_start_yymmdd;
					_wherePrevious_fiscal_end_yymmdd = WherePrevious_fiscal_end_yymmdd;
					_whereCurrent_fiscal_start_yymmdd = WhereCurrent_fiscal_start_yymmdd;
					_whereCurrent_fiscal_end_yymmdd = WhereCurrent_fiscal_end_yymmdd;
					_whereCurrent_costing_cutoff_yymmdd = WhereCurrent_costing_cutoff_yymmdd;
					_whereEp_yr = WhereEp_yr;
					_whereCurrent_costing_ped = WhereCurrent_costing_ped;
					_whereOhip_run_date = WhereOhip_run_date;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereConst_rec_nbr == null 
				&& WherePrevious_fiscal_start_yymmdd == null 
				&& WherePrevious_fiscal_end_yymmdd == null 
				&& WhereCurrent_fiscal_start_yymmdd == null 
				&& WhereCurrent_fiscal_end_yymmdd == null 
				&& WhereCurrent_costing_cutoff_yymmdd == null 
				&& WhereEp_yr == null 
				&& WhereCurrent_costing_ped == null 
				&& WhereOhip_run_date == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereConst_rec_nbr ==  _whereConst_rec_nbr
				&& WherePrevious_fiscal_start_yymmdd ==  _wherePrevious_fiscal_start_yymmdd
				&& WherePrevious_fiscal_end_yymmdd ==  _wherePrevious_fiscal_end_yymmdd
				&& WhereCurrent_fiscal_start_yymmdd ==  _whereCurrent_fiscal_start_yymmdd
				&& WhereCurrent_fiscal_end_yymmdd ==  _whereCurrent_fiscal_end_yymmdd
				&& WhereCurrent_costing_cutoff_yymmdd ==  _whereCurrent_costing_cutoff_yymmdd
				&& WhereEp_yr ==  _whereEp_yr
				&& WhereCurrent_costing_ped ==  _whereCurrent_costing_ped
				&& WhereOhip_run_date ==  _whereOhip_run_date
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WherePrevious_fiscal_start_yymmdd = null; 
			WherePrevious_fiscal_end_yymmdd = null; 
			WhereCurrent_fiscal_start_yymmdd = null; 
			WhereCurrent_fiscal_end_yymmdd = null; 
			WhereCurrent_costing_cutoff_yymmdd = null; 
			WhereEp_yr = null; 
			WhereCurrent_costing_ped = null; 
			WhereOhip_run_date = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CONST_REC_NBR;
		private decimal? _PREVIOUS_FISCAL_START_YYMMDD;
		private decimal? _PREVIOUS_FISCAL_END_YYMMDD;
		private decimal? _CURRENT_FISCAL_START_YYMMDD;
		private decimal? _CURRENT_FISCAL_END_YYMMDD;
		private decimal? _CURRENT_COSTING_CUTOFF_YYMMDD;
		private decimal? _EP_YR;
		private decimal? _CURRENT_COSTING_PED;
		private decimal? _OHIP_RUN_DATE;
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
		public decimal? CONST_REC_NBR
		{
			get { return _CONST_REC_NBR; }
			set
			{
				if (_CONST_REC_NBR != value)
				{
					_CONST_REC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PREVIOUS_FISCAL_START_YYMMDD
		{
			get { return _PREVIOUS_FISCAL_START_YYMMDD; }
			set
			{
				if (_PREVIOUS_FISCAL_START_YYMMDD != value)
				{
					_PREVIOUS_FISCAL_START_YYMMDD = value;
					ChangeState();
				}
			}
		}
		public decimal? PREVIOUS_FISCAL_END_YYMMDD
		{
			get { return _PREVIOUS_FISCAL_END_YYMMDD; }
			set
			{
				if (_PREVIOUS_FISCAL_END_YYMMDD != value)
				{
					_PREVIOUS_FISCAL_END_YYMMDD = value;
					ChangeState();
				}
			}
		}
		public decimal? CURRENT_FISCAL_START_YYMMDD
		{
			get { return _CURRENT_FISCAL_START_YYMMDD; }
			set
			{
				if (_CURRENT_FISCAL_START_YYMMDD != value)
				{
					_CURRENT_FISCAL_START_YYMMDD = value;
					ChangeState();
				}
			}
		}
		public decimal? CURRENT_FISCAL_END_YYMMDD
		{
			get { return _CURRENT_FISCAL_END_YYMMDD; }
			set
			{
				if (_CURRENT_FISCAL_END_YYMMDD != value)
				{
					_CURRENT_FISCAL_END_YYMMDD = value;
					ChangeState();
				}
			}
		}
		public decimal? CURRENT_COSTING_CUTOFF_YYMMDD
		{
			get { return _CURRENT_COSTING_CUTOFF_YYMMDD; }
			set
			{
				if (_CURRENT_COSTING_CUTOFF_YYMMDD != value)
				{
					_CURRENT_COSTING_CUTOFF_YYMMDD = value;
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
		public decimal? CURRENT_COSTING_PED
		{
			get { return _CURRENT_COSTING_PED; }
			set
			{
				if (_CURRENT_COSTING_PED != value)
				{
					_CURRENT_COSTING_PED = value;
					ChangeState();
				}
			}
		}
		public decimal? OHIP_RUN_DATE
		{
			get { return _OHIP_RUN_DATE; }
			set
			{
				if (_OHIP_RUN_DATE != value)
				{
					_OHIP_RUN_DATE = value;
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
		public decimal? WhereConst_rec_nbr { get; set; }
		private decimal? _whereConst_rec_nbr;
		public decimal? WherePrevious_fiscal_start_yymmdd { get; set; }
		private decimal? _wherePrevious_fiscal_start_yymmdd;
		public decimal? WherePrevious_fiscal_end_yymmdd { get; set; }
		private decimal? _wherePrevious_fiscal_end_yymmdd;
		public decimal? WhereCurrent_fiscal_start_yymmdd { get; set; }
		private decimal? _whereCurrent_fiscal_start_yymmdd;
		public decimal? WhereCurrent_fiscal_end_yymmdd { get; set; }
		private decimal? _whereCurrent_fiscal_end_yymmdd;
		public decimal? WhereCurrent_costing_cutoff_yymmdd { get; set; }
		private decimal? _whereCurrent_costing_cutoff_yymmdd;
		public decimal? WhereEp_yr { get; set; }
		private decimal? _whereEp_yr;
		public decimal? WhereCurrent_costing_ped { get; set; }
		private decimal? _whereCurrent_costing_ped;
		public decimal? WhereOhip_run_date { get; set; }
		private decimal? _whereOhip_run_date;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalPrevious_fiscal_start_yymmdd;
		private decimal? _originalPrevious_fiscal_end_yymmdd;
		private decimal? _originalCurrent_fiscal_start_yymmdd;
		private decimal? _originalCurrent_fiscal_end_yymmdd;
		private decimal? _originalCurrent_costing_cutoff_yymmdd;
		private decimal? _originalEp_yr;
		private decimal? _originalCurrent_costing_ped;
		private decimal? _originalOhip_run_date;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			PREVIOUS_FISCAL_START_YYMMDD = _originalPrevious_fiscal_start_yymmdd;
			PREVIOUS_FISCAL_END_YYMMDD = _originalPrevious_fiscal_end_yymmdd;
			CURRENT_FISCAL_START_YYMMDD = _originalCurrent_fiscal_start_yymmdd;
			CURRENT_FISCAL_END_YYMMDD = _originalCurrent_fiscal_end_yymmdd;
			CURRENT_COSTING_CUTOFF_YYMMDD = _originalCurrent_costing_cutoff_yymmdd;
			EP_YR = _originalEp_yr;
			CURRENT_COSTING_PED = _originalCurrent_costing_ped;
			OHIP_RUN_DATE = _originalOhip_run_date;
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
					new SqlParameter("CONST_REC_NBR",CONST_REC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_Purge]");
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
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("PREVIOUS_FISCAL_START_YYMMDD", SqlNull(PREVIOUS_FISCAL_START_YYMMDD)),
						new SqlParameter("PREVIOUS_FISCAL_END_YYMMDD", SqlNull(PREVIOUS_FISCAL_END_YYMMDD)),
						new SqlParameter("CURRENT_FISCAL_START_YYMMDD", SqlNull(CURRENT_FISCAL_START_YYMMDD)),
						new SqlParameter("CURRENT_FISCAL_END_YYMMDD", SqlNull(CURRENT_FISCAL_END_YYMMDD)),
						new SqlParameter("CURRENT_COSTING_CUTOFF_YYMMDD", SqlNull(CURRENT_COSTING_CUTOFF_YYMMDD)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("CURRENT_COSTING_PED", SqlNull(CURRENT_COSTING_PED)),
						new SqlParameter("OHIP_RUN_DATE", SqlNull(OHIP_RUN_DATE)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						PREVIOUS_FISCAL_START_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]);
						PREVIOUS_FISCAL_END_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]);
						CURRENT_FISCAL_START_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]);
						CURRENT_FISCAL_END_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]);
						CURRENT_COSTING_CUTOFF_YYMMDD = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]);
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						CURRENT_COSTING_PED = ConvertDEC(Reader["CURRENT_COSTING_PED"]);
						OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalPrevious_fiscal_start_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]);
						_originalPrevious_fiscal_end_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]);
						_originalCurrent_fiscal_start_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]);
						_originalCurrent_fiscal_end_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]);
						_originalCurrent_costing_cutoff_yymmdd = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]);
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalCurrent_costing_ped = ConvertDEC(Reader["CURRENT_COSTING_PED"]);
						_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("PREVIOUS_FISCAL_START_YYMMDD", SqlNull(PREVIOUS_FISCAL_START_YYMMDD)),
						new SqlParameter("PREVIOUS_FISCAL_END_YYMMDD", SqlNull(PREVIOUS_FISCAL_END_YYMMDD)),
						new SqlParameter("CURRENT_FISCAL_START_YYMMDD", SqlNull(CURRENT_FISCAL_START_YYMMDD)),
						new SqlParameter("CURRENT_FISCAL_END_YYMMDD", SqlNull(CURRENT_FISCAL_END_YYMMDD)),
						new SqlParameter("CURRENT_COSTING_CUTOFF_YYMMDD", SqlNull(CURRENT_COSTING_CUTOFF_YYMMDD)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("CURRENT_COSTING_PED", SqlNull(CURRENT_COSTING_PED)),
						new SqlParameter("OHIP_RUN_DATE", SqlNull(OHIP_RUN_DATE)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_7_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						PREVIOUS_FISCAL_START_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]);
						PREVIOUS_FISCAL_END_YYMMDD = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]);
						CURRENT_FISCAL_START_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]);
						CURRENT_FISCAL_END_YYMMDD = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]);
						CURRENT_COSTING_CUTOFF_YYMMDD = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]);
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						CURRENT_COSTING_PED = ConvertDEC(Reader["CURRENT_COSTING_PED"]);
						OHIP_RUN_DATE = ConvertDEC(Reader["OHIP_RUN_DATE"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalPrevious_fiscal_start_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_START_YYMMDD"]);
						_originalPrevious_fiscal_end_yymmdd = ConvertDEC(Reader["PREVIOUS_FISCAL_END_YYMMDD"]);
						_originalCurrent_fiscal_start_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_START_YYMMDD"]);
						_originalCurrent_fiscal_end_yymmdd = ConvertDEC(Reader["CURRENT_FISCAL_END_YYMMDD"]);
						_originalCurrent_costing_cutoff_yymmdd = ConvertDEC(Reader["CURRENT_COSTING_CUTOFF_YYMMDD"]);
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalCurrent_costing_ped = ConvertDEC(Reader["CURRENT_COSTING_PED"]);
						_originalOhip_run_date = ConvertDEC(Reader["OHIP_RUN_DATE"]);
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