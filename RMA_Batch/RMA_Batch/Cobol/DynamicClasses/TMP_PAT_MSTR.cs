using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_PAT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_PAT_MSTR> Collection( Guid? rowid,
															string pat_acronym_first6,
															string pat_acronym_last3,
															string pat_chart_nbr,
															string pat_init,
															string pat_i_key,
															decimal? pat_con_nbrmin,
															decimal? pat_con_nbrmax,
															decimal? pat_i_nbrmin,
															decimal? pat_i_nbrmax,
															string filler4,
															decimal? pat_health_nbrmin,
															decimal? pat_health_nbrmax,
															string pat_version_cd,
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
					new SqlParameter("PAT_ACRONYM_FIRST6",pat_acronym_first6),
					new SqlParameter("PAT_ACRONYM_LAST3",pat_acronym_last3),
					new SqlParameter("PAT_CHART_NBR",pat_chart_nbr),
					new SqlParameter("PAT_INIT",pat_init),
					new SqlParameter("PAT_I_KEY",pat_i_key),
					new SqlParameter("minPAT_CON_NBR",pat_con_nbrmin),
					new SqlParameter("maxPAT_CON_NBR",pat_con_nbrmax),
					new SqlParameter("minPAT_I_NBR",pat_i_nbrmin),
					new SqlParameter("maxPAT_I_NBR",pat_i_nbrmax),
					new SqlParameter("FILLER4",filler4),
					new SqlParameter("minPAT_HEALTH_NBR",pat_health_nbrmin),
					new SqlParameter("maxPAT_HEALTH_NBR",pat_health_nbrmax),
					new SqlParameter("PAT_VERSION_CD",pat_version_cd),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_PAT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_PAT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_PAT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<TMP_PAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new TMP_PAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_INIT = Reader["PAT_INIT"].ToString(),
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_init = Reader["PAT_INIT"].ToString(),
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_PAT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_PAT_MSTR> Collection(ObservableCollection<TMP_PAT_MSTR>
                                                               tmpPatMstr = null)
        {
            if (IsSameSearch() && tmpPatMstr != null)
            {
                return tmpPatMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_PAT_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PAT_ACRONYM_FIRST6",WherePat_acronym_first6),
					new SqlParameter("PAT_ACRONYM_LAST3",WherePat_acronym_last3),
					new SqlParameter("PAT_CHART_NBR",WherePat_chart_nbr),
					new SqlParameter("PAT_INIT",WherePat_init),
					new SqlParameter("PAT_I_KEY",WherePat_i_key),
					new SqlParameter("PAT_CON_NBR",WherePat_con_nbr),
					new SqlParameter("PAT_I_NBR",WherePat_i_nbr),
					new SqlParameter("FILLER4",WhereFiller4),
					new SqlParameter("PAT_HEALTH_NBR",WherePat_health_nbr),
					new SqlParameter("PAT_VERSION_CD",WherePat_version_cd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_PAT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<TMP_PAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new TMP_PAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_INIT = Reader["PAT_INIT"].ToString(),
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePat_acronym_first6 = WherePat_acronym_first6,
					_wherePat_acronym_last3 = WherePat_acronym_last3,
					_wherePat_chart_nbr = WherePat_chart_nbr,
					_wherePat_init = WherePat_init,
					_wherePat_i_key = WherePat_i_key,
					_wherePat_con_nbr = WherePat_con_nbr,
					_wherePat_i_nbr = WherePat_i_nbr,
					_whereFiller4 = WhereFiller4,
					_wherePat_health_nbr = WherePat_health_nbr,
					_wherePat_version_cd = WherePat_version_cd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_init = Reader["PAT_INIT"].ToString(),
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePat_acronym_first6 = WherePat_acronym_first6;
					_wherePat_acronym_last3 = WherePat_acronym_last3;
					_wherePat_chart_nbr = WherePat_chart_nbr;
					_wherePat_init = WherePat_init;
					_wherePat_i_key = WherePat_i_key;
					_wherePat_con_nbr = WherePat_con_nbr;
					_wherePat_i_nbr = WherePat_i_nbr;
					_whereFiller4 = WhereFiller4;
					_wherePat_health_nbr = WherePat_health_nbr;
					_wherePat_version_cd = WherePat_version_cd;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePat_acronym_first6 == null 
				&& WherePat_acronym_last3 == null 
				&& WherePat_chart_nbr == null 
				&& WherePat_init == null 
				&& WherePat_i_key == null 
				&& WherePat_con_nbr == null 
				&& WherePat_i_nbr == null 
				&& WhereFiller4 == null 
				&& WherePat_health_nbr == null 
				&& WherePat_version_cd == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePat_acronym_first6 ==  _wherePat_acronym_first6
				&& WherePat_acronym_last3 ==  _wherePat_acronym_last3
				&& WherePat_chart_nbr ==  _wherePat_chart_nbr
				&& WherePat_init ==  _wherePat_init
				&& WherePat_i_key ==  _wherePat_i_key
				&& WherePat_con_nbr ==  _wherePat_con_nbr
				&& WherePat_i_nbr ==  _wherePat_i_nbr
				&& WhereFiller4 ==  _whereFiller4
				&& WherePat_health_nbr ==  _wherePat_health_nbr
				&& WherePat_version_cd ==  _wherePat_version_cd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePat_acronym_first6 = null; 
			WherePat_acronym_last3 = null; 
			WherePat_chart_nbr = null; 
			WherePat_init = null; 
			WherePat_i_key = null; 
			WherePat_con_nbr = null; 
			WherePat_i_nbr = null; 
			WhereFiller4 = null; 
			WherePat_health_nbr = null; 
			WherePat_version_cd = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _PAT_ACRONYM_FIRST6;
		private string _PAT_ACRONYM_LAST3;
		private string _PAT_CHART_NBR;
		private string _PAT_INIT;
		private string _PAT_I_KEY;
		private decimal? _PAT_CON_NBR;
		private decimal? _PAT_I_NBR;
		private string _FILLER4;
		private decimal? _PAT_HEALTH_NBR;
		private string _PAT_VERSION_CD;
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
		public string PAT_ACRONYM_FIRST6
		{
			get { return _PAT_ACRONYM_FIRST6; }
			set
			{
				if (_PAT_ACRONYM_FIRST6 != value)
				{
					_PAT_ACRONYM_FIRST6 = value;
					ChangeState();
				}
			}
		}
		public string PAT_ACRONYM_LAST3
		{
			get { return _PAT_ACRONYM_LAST3; }
			set
			{
				if (_PAT_ACRONYM_LAST3 != value)
				{
					_PAT_ACRONYM_LAST3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR
		{
			get { return _PAT_CHART_NBR; }
			set
			{
				if (_PAT_CHART_NBR != value)
				{
					_PAT_CHART_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_INIT
		{
			get { return _PAT_INIT; }
			set
			{
				if (_PAT_INIT != value)
				{
					_PAT_INIT = value;
					ChangeState();
				}
			}
		}
		public string PAT_I_KEY
		{
			get { return _PAT_I_KEY; }
			set
			{
				if (_PAT_I_KEY != value)
				{
					_PAT_I_KEY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_CON_NBR
		{
			get { return _PAT_CON_NBR; }
			set
			{
				if (_PAT_CON_NBR != value)
				{
					_PAT_CON_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_I_NBR
		{
			get { return _PAT_I_NBR; }
			set
			{
				if (_PAT_I_NBR != value)
				{
					_PAT_I_NBR = value;
					ChangeState();
				}
			}
		}
		public string FILLER4
		{
			get { return _FILLER4; }
			set
			{
				if (_FILLER4 != value)
				{
					_FILLER4 = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_HEALTH_NBR
		{
			get { return _PAT_HEALTH_NBR; }
			set
			{
				if (_PAT_HEALTH_NBR != value)
				{
					_PAT_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_VERSION_CD
		{
			get { return _PAT_VERSION_CD; }
			set
			{
				if (_PAT_VERSION_CD != value)
				{
					_PAT_VERSION_CD = value;
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
		public string WherePat_acronym_first6 { get; set; }
		private string _wherePat_acronym_first6;
		public string WherePat_acronym_last3 { get; set; }
		private string _wherePat_acronym_last3;
		public string WherePat_chart_nbr { get; set; }
		private string _wherePat_chart_nbr;
		public string WherePat_init { get; set; }
		private string _wherePat_init;
		public string WherePat_i_key { get; set; }
		private string _wherePat_i_key;
		public decimal? WherePat_con_nbr { get; set; }
		private decimal? _wherePat_con_nbr;
		public decimal? WherePat_i_nbr { get; set; }
		private decimal? _wherePat_i_nbr;
		public string WhereFiller4 { get; set; }
		private string _whereFiller4;
		public decimal? WherePat_health_nbr { get; set; }
		private decimal? _wherePat_health_nbr;
		public string WherePat_version_cd { get; set; }
		private string _wherePat_version_cd;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalPat_acronym_first6;
		private string _originalPat_acronym_last3;
		private string _originalPat_chart_nbr;
		private string _originalPat_init;
		private string _originalPat_i_key;
		private decimal? _originalPat_con_nbr;
		private decimal? _originalPat_i_nbr;
		private string _originalFiller4;
		private decimal? _originalPat_health_nbr;
		private string _originalPat_version_cd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PAT_ACRONYM_FIRST6 = _originalPat_acronym_first6;
			PAT_ACRONYM_LAST3 = _originalPat_acronym_last3;
			PAT_CHART_NBR = _originalPat_chart_nbr;
			PAT_INIT = _originalPat_init;
			PAT_I_KEY = _originalPat_i_key;
			PAT_CON_NBR = _originalPat_con_nbr;
			PAT_I_NBR = _originalPat_i_nbr;
			FILLER4 = _originalFiller4;
			PAT_HEALTH_NBR = _originalPat_health_nbr;
			PAT_VERSION_CD = _originalPat_version_cd;
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
					new SqlParameter("PAT_I_KEY",PAT_I_KEY),
					new SqlParameter("PAT_CON_NBR",PAT_CON_NBR),
					new SqlParameter("PAT_I_NBR",PAT_I_NBR),
					new SqlParameter("FILLER4",FILLER4)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_PAT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_PAT_MSTR_Purge]");
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
						new SqlParameter("PAT_ACRONYM_FIRST6", SqlNull(PAT_ACRONYM_FIRST6)),
						new SqlParameter("PAT_ACRONYM_LAST3", SqlNull(PAT_ACRONYM_LAST3)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_INIT", SqlNull(PAT_INIT)),
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_PAT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_INIT = Reader["PAT_INIT"].ToString();
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_init = Reader["PAT_INIT"].ToString();
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PAT_ACRONYM_FIRST6", SqlNull(PAT_ACRONYM_FIRST6)),
						new SqlParameter("PAT_ACRONYM_LAST3", SqlNull(PAT_ACRONYM_LAST3)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_INIT", SqlNull(PAT_INIT)),
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_PAT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_INIT = Reader["PAT_INIT"].ToString();
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_init = Reader["PAT_INIT"].ToString();
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
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