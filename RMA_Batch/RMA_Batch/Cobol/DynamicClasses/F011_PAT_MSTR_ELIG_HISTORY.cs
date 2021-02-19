using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F011_PAT_MSTR_ELIG_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY> Collection( Guid? rowid,
															string pat_i_key,
															decimal? pat_con_nbrmin,
															decimal? pat_con_nbrmax,
															decimal? pat_i_nbrmin,
															decimal? pat_i_nbrmax,
															string filler4,
															decimal? pat_date_last_maintmin,
															decimal? pat_date_last_maintmax,
															decimal? entry_time_longmin,
															decimal? entry_time_longmax,
															decimal? pat_expiry_yymin,
															decimal? pat_expiry_yymax,
															decimal? pat_expiry_mmmin,
															decimal? pat_expiry_mmmax,
															decimal? pat_health_nbrmin,
															decimal? pat_health_nbrmax,
															decimal? pat_last_health_nbrmin,
															decimal? pat_last_health_nbrmax,
															string pat_version_cd,
															string pat_last_version_cd,
															decimal? pat_birth_datemin,
															decimal? pat_birth_datemax,
															decimal? pat_birth_date_lastmin,
															decimal? pat_birth_date_lastmax,
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
					new SqlParameter("PAT_I_KEY",pat_i_key),
					new SqlParameter("minPAT_CON_NBR",pat_con_nbrmin),
					new SqlParameter("maxPAT_CON_NBR",pat_con_nbrmax),
					new SqlParameter("minPAT_I_NBR",pat_i_nbrmin),
					new SqlParameter("maxPAT_I_NBR",pat_i_nbrmax),
					new SqlParameter("FILLER4",filler4),
					new SqlParameter("minPAT_DATE_LAST_MAINT",pat_date_last_maintmin),
					new SqlParameter("maxPAT_DATE_LAST_MAINT",pat_date_last_maintmax),
					new SqlParameter("minENTRY_TIME_LONG",entry_time_longmin),
					new SqlParameter("maxENTRY_TIME_LONG",entry_time_longmax),
					new SqlParameter("minPAT_EXPIRY_YY",pat_expiry_yymin),
					new SqlParameter("maxPAT_EXPIRY_YY",pat_expiry_yymax),
					new SqlParameter("minPAT_EXPIRY_MM",pat_expiry_mmmin),
					new SqlParameter("maxPAT_EXPIRY_MM",pat_expiry_mmmax),
					new SqlParameter("minPAT_HEALTH_NBR",pat_health_nbrmin),
					new SqlParameter("maxPAT_HEALTH_NBR",pat_health_nbrmax),
					new SqlParameter("minPAT_LAST_HEALTH_NBR",pat_last_health_nbrmin),
					new SqlParameter("maxPAT_LAST_HEALTH_NBR",pat_last_health_nbrmax),
					new SqlParameter("PAT_VERSION_CD",pat_version_cd),
					new SqlParameter("PAT_LAST_VERSION_CD",pat_last_version_cd),
					new SqlParameter("minPAT_BIRTH_DATE",pat_birth_datemin),
					new SqlParameter("maxPAT_BIRTH_DATE",pat_birth_datemax),
					new SqlParameter("minPAT_BIRTH_DATE_LAST",pat_birth_date_lastmin),
					new SqlParameter("maxPAT_BIRTH_DATE_LAST",pat_birth_date_lastmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F011_PAT_MSTR_ELIG_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_LAST_HEALTH_NBR = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
					PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					PAT_BIRTH_DATE_LAST = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_last_health_nbr = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
					_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					_originalPat_birth_date_last = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F011_PAT_MSTR_ELIG_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY> Collection(ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>
                                                               f011PatMstrEligHistory = null)
        {
            if (IsSameSearch() && f011PatMstrEligHistory != null)
            {
                return f011PatMstrEligHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PAT_I_KEY",WherePat_i_key),
					new SqlParameter("PAT_CON_NBR",WherePat_con_nbr),
					new SqlParameter("PAT_I_NBR",WherePat_i_nbr),
					new SqlParameter("FILLER4",WhereFiller4),
					new SqlParameter("PAT_DATE_LAST_MAINT",WherePat_date_last_maint),
					new SqlParameter("ENTRY_TIME_LONG",WhereEntry_time_long),
					new SqlParameter("PAT_EXPIRY_YY",WherePat_expiry_yy),
					new SqlParameter("PAT_EXPIRY_MM",WherePat_expiry_mm),
					new SqlParameter("PAT_HEALTH_NBR",WherePat_health_nbr),
					new SqlParameter("PAT_LAST_HEALTH_NBR",WherePat_last_health_nbr),
					new SqlParameter("PAT_VERSION_CD",WherePat_version_cd),
					new SqlParameter("PAT_LAST_VERSION_CD",WherePat_last_version_cd),
					new SqlParameter("PAT_BIRTH_DATE",WherePat_birth_date),
					new SqlParameter("PAT_BIRTH_DATE_LAST",WherePat_birth_date_last),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F011_PAT_MSTR_ELIG_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F011_PAT_MSTR_ELIG_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_LAST_HEALTH_NBR = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
					PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					PAT_BIRTH_DATE_LAST = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePat_i_key = WherePat_i_key,
					_wherePat_con_nbr = WherePat_con_nbr,
					_wherePat_i_nbr = WherePat_i_nbr,
					_whereFiller4 = WhereFiller4,
					_wherePat_date_last_maint = WherePat_date_last_maint,
					_whereEntry_time_long = WhereEntry_time_long,
					_wherePat_expiry_yy = WherePat_expiry_yy,
					_wherePat_expiry_mm = WherePat_expiry_mm,
					_wherePat_health_nbr = WherePat_health_nbr,
					_wherePat_last_health_nbr = WherePat_last_health_nbr,
					_wherePat_version_cd = WherePat_version_cd,
					_wherePat_last_version_cd = WherePat_last_version_cd,
					_wherePat_birth_date = WherePat_birth_date,
					_wherePat_birth_date_last = WherePat_birth_date_last,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_last_health_nbr = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
					_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					_originalPat_birth_date_last = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePat_i_key = WherePat_i_key;
					_wherePat_con_nbr = WherePat_con_nbr;
					_wherePat_i_nbr = WherePat_i_nbr;
					_whereFiller4 = WhereFiller4;
					_wherePat_date_last_maint = WherePat_date_last_maint;
					_whereEntry_time_long = WhereEntry_time_long;
					_wherePat_expiry_yy = WherePat_expiry_yy;
					_wherePat_expiry_mm = WherePat_expiry_mm;
					_wherePat_health_nbr = WherePat_health_nbr;
					_wherePat_last_health_nbr = WherePat_last_health_nbr;
					_wherePat_version_cd = WherePat_version_cd;
					_wherePat_last_version_cd = WherePat_last_version_cd;
					_wherePat_birth_date = WherePat_birth_date;
					_wherePat_birth_date_last = WherePat_birth_date_last;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePat_i_key == null 
				&& WherePat_con_nbr == null 
				&& WherePat_i_nbr == null 
				&& WhereFiller4 == null 
				&& WherePat_date_last_maint == null 
				&& WhereEntry_time_long == null 
				&& WherePat_expiry_yy == null 
				&& WherePat_expiry_mm == null 
				&& WherePat_health_nbr == null 
				&& WherePat_last_health_nbr == null 
				&& WherePat_version_cd == null 
				&& WherePat_last_version_cd == null 
				&& WherePat_birth_date == null 
				&& WherePat_birth_date_last == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePat_i_key ==  _wherePat_i_key
				&& WherePat_con_nbr ==  _wherePat_con_nbr
				&& WherePat_i_nbr ==  _wherePat_i_nbr
				&& WhereFiller4 ==  _whereFiller4
				&& WherePat_date_last_maint ==  _wherePat_date_last_maint
				&& WhereEntry_time_long ==  _whereEntry_time_long
				&& WherePat_expiry_yy ==  _wherePat_expiry_yy
				&& WherePat_expiry_mm ==  _wherePat_expiry_mm
				&& WherePat_health_nbr ==  _wherePat_health_nbr
				&& WherePat_last_health_nbr ==  _wherePat_last_health_nbr
				&& WherePat_version_cd ==  _wherePat_version_cd
				&& WherePat_last_version_cd ==  _wherePat_last_version_cd
				&& WherePat_birth_date ==  _wherePat_birth_date
				&& WherePat_birth_date_last ==  _wherePat_birth_date_last
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePat_i_key = null; 
			WherePat_con_nbr = null; 
			WherePat_i_nbr = null; 
			WhereFiller4 = null; 
			WherePat_date_last_maint = null; 
			WhereEntry_time_long = null; 
			WherePat_expiry_yy = null; 
			WherePat_expiry_mm = null; 
			WherePat_health_nbr = null; 
			WherePat_last_health_nbr = null; 
			WherePat_version_cd = null; 
			WherePat_last_version_cd = null; 
			WherePat_birth_date = null; 
			WherePat_birth_date_last = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _PAT_I_KEY;
		private decimal? _PAT_CON_NBR;
		private decimal? _PAT_I_NBR;
		private string _FILLER4;
		private decimal? _PAT_DATE_LAST_MAINT;
		private decimal? _ENTRY_TIME_LONG;
		private decimal? _PAT_EXPIRY_YY;
		private decimal? _PAT_EXPIRY_MM;
		private decimal? _PAT_HEALTH_NBR;
		private decimal? _PAT_LAST_HEALTH_NBR;
		private string _PAT_VERSION_CD;
		private string _PAT_LAST_VERSION_CD;
		private decimal? _PAT_BIRTH_DATE;
		private decimal? _PAT_BIRTH_DATE_LAST;
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
		public decimal? PAT_DATE_LAST_MAINT
		{
			get { return _PAT_DATE_LAST_MAINT; }
			set
			{
				if (_PAT_DATE_LAST_MAINT != value)
				{
					_PAT_DATE_LAST_MAINT = value;
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
		public decimal? PAT_EXPIRY_YY
		{
			get { return _PAT_EXPIRY_YY; }
			set
			{
				if (_PAT_EXPIRY_YY != value)
				{
					_PAT_EXPIRY_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_EXPIRY_MM
		{
			get { return _PAT_EXPIRY_MM; }
			set
			{
				if (_PAT_EXPIRY_MM != value)
				{
					_PAT_EXPIRY_MM = value;
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
		public decimal? PAT_LAST_HEALTH_NBR
		{
			get { return _PAT_LAST_HEALTH_NBR; }
			set
			{
				if (_PAT_LAST_HEALTH_NBR != value)
				{
					_PAT_LAST_HEALTH_NBR = value;
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
		public string PAT_LAST_VERSION_CD
		{
			get { return _PAT_LAST_VERSION_CD; }
			set
			{
				if (_PAT_LAST_VERSION_CD != value)
				{
					_PAT_LAST_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_BIRTH_DATE
		{
			get { return _PAT_BIRTH_DATE; }
			set
			{
				if (_PAT_BIRTH_DATE != value)
				{
					_PAT_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_BIRTH_DATE_LAST
		{
			get { return _PAT_BIRTH_DATE_LAST; }
			set
			{
				if (_PAT_BIRTH_DATE_LAST != value)
				{
					_PAT_BIRTH_DATE_LAST = value;
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
		public string WherePat_i_key { get; set; }
		private string _wherePat_i_key;
		public decimal? WherePat_con_nbr { get; set; }
		private decimal? _wherePat_con_nbr;
		public decimal? WherePat_i_nbr { get; set; }
		private decimal? _wherePat_i_nbr;
		public string WhereFiller4 { get; set; }
		private string _whereFiller4;
		public decimal? WherePat_date_last_maint { get; set; }
		private decimal? _wherePat_date_last_maint;
		public decimal? WhereEntry_time_long { get; set; }
		private decimal? _whereEntry_time_long;
		public decimal? WherePat_expiry_yy { get; set; }
		private decimal? _wherePat_expiry_yy;
		public decimal? WherePat_expiry_mm { get; set; }
		private decimal? _wherePat_expiry_mm;
		public decimal? WherePat_health_nbr { get; set; }
		private decimal? _wherePat_health_nbr;
		public decimal? WherePat_last_health_nbr { get; set; }
		private decimal? _wherePat_last_health_nbr;
		public string WherePat_version_cd { get; set; }
		private string _wherePat_version_cd;
		public string WherePat_last_version_cd { get; set; }
		private string _wherePat_last_version_cd;
		public decimal? WherePat_birth_date { get; set; }
		private decimal? _wherePat_birth_date;
		public decimal? WherePat_birth_date_last { get; set; }
		private decimal? _wherePat_birth_date_last;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalPat_i_key;
		private decimal? _originalPat_con_nbr;
		private decimal? _originalPat_i_nbr;
		private string _originalFiller4;
		private decimal? _originalPat_date_last_maint;
		private decimal? _originalEntry_time_long;
		private decimal? _originalPat_expiry_yy;
		private decimal? _originalPat_expiry_mm;
		private decimal? _originalPat_health_nbr;
		private decimal? _originalPat_last_health_nbr;
		private string _originalPat_version_cd;
		private string _originalPat_last_version_cd;
		private decimal? _originalPat_birth_date;
		private decimal? _originalPat_birth_date_last;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PAT_I_KEY = _originalPat_i_key;
			PAT_CON_NBR = _originalPat_con_nbr;
			PAT_I_NBR = _originalPat_i_nbr;
			FILLER4 = _originalFiller4;
			PAT_DATE_LAST_MAINT = _originalPat_date_last_maint;
			ENTRY_TIME_LONG = _originalEntry_time_long;
			PAT_EXPIRY_YY = _originalPat_expiry_yy;
			PAT_EXPIRY_MM = _originalPat_expiry_mm;
			PAT_HEALTH_NBR = _originalPat_health_nbr;
			PAT_LAST_HEALTH_NBR = _originalPat_last_health_nbr;
			PAT_VERSION_CD = _originalPat_version_cd;
			PAT_LAST_VERSION_CD = _originalPat_last_version_cd;
			PAT_BIRTH_DATE = _originalPat_birth_date;
			PAT_BIRTH_DATE_LAST = _originalPat_birth_date_last;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_Purge]");
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
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_DATE_LAST_MAINT", SqlNull(PAT_DATE_LAST_MAINT)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("PAT_EXPIRY_YY", SqlNull(PAT_EXPIRY_YY)),
						new SqlParameter("PAT_EXPIRY_MM", SqlNull(PAT_EXPIRY_MM)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_LAST_HEALTH_NBR", SqlNull(PAT_LAST_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_BIRTH_DATE", SqlNull(PAT_BIRTH_DATE)),
						new SqlParameter("PAT_BIRTH_DATE_LAST", SqlNull(PAT_BIRTH_DATE_LAST)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_LAST_HEALTH_NBR = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						PAT_BIRTH_DATE_LAST = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_last_health_nbr = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						_originalPat_birth_date_last = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_DATE_LAST_MAINT", SqlNull(PAT_DATE_LAST_MAINT)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("PAT_EXPIRY_YY", SqlNull(PAT_EXPIRY_YY)),
						new SqlParameter("PAT_EXPIRY_MM", SqlNull(PAT_EXPIRY_MM)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_LAST_HEALTH_NBR", SqlNull(PAT_LAST_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_BIRTH_DATE", SqlNull(PAT_BIRTH_DATE)),
						new SqlParameter("PAT_BIRTH_DATE_LAST", SqlNull(PAT_BIRTH_DATE_LAST)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F011_PAT_MSTR_ELIG_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_LAST_HEALTH_NBR = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						PAT_BIRTH_DATE_LAST = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_last_health_nbr = ConvertDEC(Reader["PAT_LAST_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						_originalPat_birth_date_last = ConvertDEC(Reader["PAT_BIRTH_DATE_LAST"]);
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