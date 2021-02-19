using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_6 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_6> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? current_ep_nbrmin,
															decimal? current_ep_nbrmax,
															decimal? first_ep_nbr_of_fiscal_yrmin,
															decimal? first_ep_nbr_of_fiscal_yrmax,
															decimal? last_ep_nbr_of_fiscal_yrmin,
															decimal? last_ep_nbr_of_fiscal_yrmax,
															decimal? first_ep_nbr_of_cal_yrmin,
															decimal? first_ep_nbr_of_cal_yrmax,
															decimal? last_ep_nbr_of_cal_yrmin,
															decimal? last_ep_nbr_of_cal_yrmax,
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
					new SqlParameter("minCURRENT_EP_NBR",current_ep_nbrmin),
					new SqlParameter("maxCURRENT_EP_NBR",current_ep_nbrmax),
					new SqlParameter("minFIRST_EP_NBR_OF_FISCAL_YR",first_ep_nbr_of_fiscal_yrmin),
					new SqlParameter("maxFIRST_EP_NBR_OF_FISCAL_YR",first_ep_nbr_of_fiscal_yrmax),
					new SqlParameter("minLAST_EP_NBR_OF_FISCAL_YR",last_ep_nbr_of_fiscal_yrmin),
					new SqlParameter("maxLAST_EP_NBR_OF_FISCAL_YR",last_ep_nbr_of_fiscal_yrmax),
					new SqlParameter("minFIRST_EP_NBR_OF_CAL_YR",first_ep_nbr_of_cal_yrmin),
					new SqlParameter("maxFIRST_EP_NBR_OF_CAL_YR",first_ep_nbr_of_cal_yrmax),
					new SqlParameter("minLAST_EP_NBR_OF_CAL_YR",last_ep_nbr_of_cal_yrmin),
					new SqlParameter("maxLAST_EP_NBR_OF_CAL_YR",last_ep_nbr_of_cal_yrmax),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_6>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_6>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_6
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					FIRST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]),
					LAST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]),
					FIRST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]),
					LAST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					_originalFirst_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]),
					_originalLast_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]),
					_originalFirst_ep_nbr_of_cal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]),
					_originalLast_ep_nbr_of_cal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_6 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_6> Collection(ObservableCollection<CONSTANTS_MSTR_REC_6>
                                                               constantsMstrRec6 = null)
        {
            if (IsSameSearch() && constantsMstrRec6 != null)
            {
                return constantsMstrRec6;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_6>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CURRENT_EP_NBR",WhereCurrent_ep_nbr),
					new SqlParameter("FIRST_EP_NBR_OF_FISCAL_YR",WhereFirst_ep_nbr_of_fiscal_yr),
					new SqlParameter("LAST_EP_NBR_OF_FISCAL_YR",WhereLast_ep_nbr_of_fiscal_yr),
					new SqlParameter("FIRST_EP_NBR_OF_CAL_YR",WhereFirst_ep_nbr_of_cal_yr),
					new SqlParameter("LAST_EP_NBR_OF_CAL_YR",WhereLast_ep_nbr_of_cal_yr),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_6>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_6
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					FIRST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]),
					LAST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]),
					FIRST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]),
					LAST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereCurrent_ep_nbr = WhereCurrent_ep_nbr,
					_whereFirst_ep_nbr_of_fiscal_yr = WhereFirst_ep_nbr_of_fiscal_yr,
					_whereLast_ep_nbr_of_fiscal_yr = WhereLast_ep_nbr_of_fiscal_yr,
					_whereFirst_ep_nbr_of_cal_yr = WhereFirst_ep_nbr_of_cal_yr,
					_whereLast_ep_nbr_of_cal_yr = WhereLast_ep_nbr_of_cal_yr,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					_originalFirst_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]),
					_originalLast_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]),
					_originalFirst_ep_nbr_of_cal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]),
					_originalLast_ep_nbr_of_cal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereCurrent_ep_nbr = WhereCurrent_ep_nbr;
					_whereFirst_ep_nbr_of_fiscal_yr = WhereFirst_ep_nbr_of_fiscal_yr;
					_whereLast_ep_nbr_of_fiscal_yr = WhereLast_ep_nbr_of_fiscal_yr;
					_whereFirst_ep_nbr_of_cal_yr = WhereFirst_ep_nbr_of_cal_yr;
					_whereLast_ep_nbr_of_cal_yr = WhereLast_ep_nbr_of_cal_yr;
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
				&& WhereCurrent_ep_nbr == null 
				&& WhereFirst_ep_nbr_of_fiscal_yr == null 
				&& WhereLast_ep_nbr_of_fiscal_yr == null 
				&& WhereFirst_ep_nbr_of_cal_yr == null 
				&& WhereLast_ep_nbr_of_cal_yr == null 
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
				&& WhereCurrent_ep_nbr ==  _whereCurrent_ep_nbr
				&& WhereFirst_ep_nbr_of_fiscal_yr ==  _whereFirst_ep_nbr_of_fiscal_yr
				&& WhereLast_ep_nbr_of_fiscal_yr ==  _whereLast_ep_nbr_of_fiscal_yr
				&& WhereFirst_ep_nbr_of_cal_yr ==  _whereFirst_ep_nbr_of_cal_yr
				&& WhereLast_ep_nbr_of_cal_yr ==  _whereLast_ep_nbr_of_cal_yr
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereCurrent_ep_nbr = null; 
			WhereFirst_ep_nbr_of_fiscal_yr = null; 
			WhereLast_ep_nbr_of_fiscal_yr = null; 
			WhereFirst_ep_nbr_of_cal_yr = null; 
			WhereLast_ep_nbr_of_cal_yr = null; 
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
		private decimal? _CURRENT_EP_NBR;
		private decimal? _FIRST_EP_NBR_OF_FISCAL_YR;
		private decimal? _LAST_EP_NBR_OF_FISCAL_YR;
		private decimal? _FIRST_EP_NBR_OF_CAL_YR;
		private decimal? _LAST_EP_NBR_OF_CAL_YR;
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
		public decimal? CURRENT_EP_NBR
		{
			get { return _CURRENT_EP_NBR; }
			set
			{
				if (_CURRENT_EP_NBR != value)
				{
					_CURRENT_EP_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? FIRST_EP_NBR_OF_FISCAL_YR
		{
			get { return _FIRST_EP_NBR_OF_FISCAL_YR; }
			set
			{
				if (_FIRST_EP_NBR_OF_FISCAL_YR != value)
				{
					_FIRST_EP_NBR_OF_FISCAL_YR = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_EP_NBR_OF_FISCAL_YR
		{
			get { return _LAST_EP_NBR_OF_FISCAL_YR; }
			set
			{
				if (_LAST_EP_NBR_OF_FISCAL_YR != value)
				{
					_LAST_EP_NBR_OF_FISCAL_YR = value;
					ChangeState();
				}
			}
		}
		public decimal? FIRST_EP_NBR_OF_CAL_YR
		{
			get { return _FIRST_EP_NBR_OF_CAL_YR; }
			set
			{
				if (_FIRST_EP_NBR_OF_CAL_YR != value)
				{
					_FIRST_EP_NBR_OF_CAL_YR = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_EP_NBR_OF_CAL_YR
		{
			get { return _LAST_EP_NBR_OF_CAL_YR; }
			set
			{
				if (_LAST_EP_NBR_OF_CAL_YR != value)
				{
					_LAST_EP_NBR_OF_CAL_YR = value;
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
		public decimal? WhereCurrent_ep_nbr { get; set; }
		private decimal? _whereCurrent_ep_nbr;
		public decimal? WhereFirst_ep_nbr_of_fiscal_yr { get; set; }
		private decimal? _whereFirst_ep_nbr_of_fiscal_yr;
		public decimal? WhereLast_ep_nbr_of_fiscal_yr { get; set; }
		private decimal? _whereLast_ep_nbr_of_fiscal_yr;
		public decimal? WhereFirst_ep_nbr_of_cal_yr { get; set; }
		private decimal? _whereFirst_ep_nbr_of_cal_yr;
		public decimal? WhereLast_ep_nbr_of_cal_yr { get; set; }
		private decimal? _whereLast_ep_nbr_of_cal_yr;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalCurrent_ep_nbr;
		private decimal? _originalFirst_ep_nbr_of_fiscal_yr;
		private decimal? _originalLast_ep_nbr_of_fiscal_yr;
		private decimal? _originalFirst_ep_nbr_of_cal_yr;
		private decimal? _originalLast_ep_nbr_of_cal_yr;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CURRENT_EP_NBR = _originalCurrent_ep_nbr;
			FIRST_EP_NBR_OF_FISCAL_YR = _originalFirst_ep_nbr_of_fiscal_yr;
			LAST_EP_NBR_OF_FISCAL_YR = _originalLast_ep_nbr_of_fiscal_yr;
			FIRST_EP_NBR_OF_CAL_YR = _originalFirst_ep_nbr_of_cal_yr;
			LAST_EP_NBR_OF_CAL_YR = _originalLast_ep_nbr_of_cal_yr;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_Purge]");
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
						new SqlParameter("CURRENT_EP_NBR", SqlNull(CURRENT_EP_NBR)),
						new SqlParameter("FIRST_EP_NBR_OF_FISCAL_YR", SqlNull(FIRST_EP_NBR_OF_FISCAL_YR)),
						new SqlParameter("LAST_EP_NBR_OF_FISCAL_YR", SqlNull(LAST_EP_NBR_OF_FISCAL_YR)),
						new SqlParameter("FIRST_EP_NBR_OF_CAL_YR", SqlNull(FIRST_EP_NBR_OF_CAL_YR)),
						new SqlParameter("LAST_EP_NBR_OF_CAL_YR", SqlNull(LAST_EP_NBR_OF_CAL_YR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						FIRST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]);
						LAST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]);
						FIRST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]);
						LAST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						_originalFirst_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]);
						_originalLast_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]);
						_originalFirst_ep_nbr_of_cal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]);
						_originalLast_ep_nbr_of_cal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]);
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
						new SqlParameter("CURRENT_EP_NBR", SqlNull(CURRENT_EP_NBR)),
						new SqlParameter("FIRST_EP_NBR_OF_FISCAL_YR", SqlNull(FIRST_EP_NBR_OF_FISCAL_YR)),
						new SqlParameter("LAST_EP_NBR_OF_FISCAL_YR", SqlNull(LAST_EP_NBR_OF_FISCAL_YR)),
						new SqlParameter("FIRST_EP_NBR_OF_CAL_YR", SqlNull(FIRST_EP_NBR_OF_CAL_YR)),
						new SqlParameter("LAST_EP_NBR_OF_CAL_YR", SqlNull(LAST_EP_NBR_OF_CAL_YR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_6_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						FIRST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]);
						LAST_EP_NBR_OF_FISCAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]);
						FIRST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]);
						LAST_EP_NBR_OF_CAL_YR = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						_originalFirst_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_FISCAL_YR"]);
						_originalLast_ep_nbr_of_fiscal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_FISCAL_YR"]);
						_originalFirst_ep_nbr_of_cal_yr = ConvertDEC(Reader["FIRST_EP_NBR_OF_CAL_YR"]);
						_originalLast_ep_nbr_of_cal_yr = ConvertDEC(Reader["LAST_EP_NBR_OF_CAL_YR"]);
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