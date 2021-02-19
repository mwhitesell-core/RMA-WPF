using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class MOH_OBEC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<MOH_OBEC> Collection( Guid? rowid,
															decimal? pat_health_nbrmin,
															decimal? pat_health_nbrmax,
															string pat_version_cd,
															string obec_submission_id,
															string pat_sex,
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
					new SqlParameter("minPAT_HEALTH_NBR",pat_health_nbrmin),
					new SqlParameter("maxPAT_HEALTH_NBR",pat_health_nbrmax),
					new SqlParameter("PAT_VERSION_CD",pat_version_cd),
					new SqlParameter("OBEC_SUBMISSION_ID",obec_submission_id),
					new SqlParameter("PAT_SEX",pat_sex),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_MOH_OBEC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<MOH_OBEC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_MOH_OBEC_Search]", parameters);
            var collection = new ObservableCollection<MOH_OBEC>();

            while (Reader.Read())
            {
                collection.Add(new MOH_OBEC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					OBEC_SUBMISSION_ID = Reader["OBEC_SUBMISSION_ID"].ToString(),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalObec_submission_id = Reader["OBEC_SUBMISSION_ID"].ToString(),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public MOH_OBEC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<MOH_OBEC> Collection(ObservableCollection<MOH_OBEC>
                                                               mohObec = null)
        {
            if (IsSameSearch() && mohObec != null)
            {
                return mohObec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<MOH_OBEC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PAT_HEALTH_NBR",WherePat_health_nbr),
					new SqlParameter("PAT_VERSION_CD",WherePat_version_cd),
					new SqlParameter("OBEC_SUBMISSION_ID",WhereObec_submission_id),
					new SqlParameter("PAT_SEX",WherePat_sex),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_MOH_OBEC_Match]", parameters);
            var collection = new ObservableCollection<MOH_OBEC>();

            while (Reader.Read())
            {
                collection.Add(new MOH_OBEC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					OBEC_SUBMISSION_ID = Reader["OBEC_SUBMISSION_ID"].ToString(),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePat_health_nbr = WherePat_health_nbr,
					_wherePat_version_cd = WherePat_version_cd,
					_whereObec_submission_id = WhereObec_submission_id,
					_wherePat_sex = WherePat_sex,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalObec_submission_id = Reader["OBEC_SUBMISSION_ID"].ToString(),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePat_health_nbr = WherePat_health_nbr;
					_wherePat_version_cd = WherePat_version_cd;
					_whereObec_submission_id = WhereObec_submission_id;
					_wherePat_sex = WherePat_sex;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePat_health_nbr == null 
				&& WherePat_version_cd == null 
				&& WhereObec_submission_id == null 
				&& WherePat_sex == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePat_health_nbr ==  _wherePat_health_nbr
				&& WherePat_version_cd ==  _wherePat_version_cd
				&& WhereObec_submission_id ==  _whereObec_submission_id
				&& WherePat_sex ==  _wherePat_sex
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePat_health_nbr = null; 
			WherePat_version_cd = null; 
			WhereObec_submission_id = null; 
			WherePat_sex = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _PAT_HEALTH_NBR;
		private string _PAT_VERSION_CD;
		private string _OBEC_SUBMISSION_ID;
		private string _PAT_SEX;
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
		public string OBEC_SUBMISSION_ID
		{
			get { return _OBEC_SUBMISSION_ID; }
			set
			{
				if (_OBEC_SUBMISSION_ID != value)
				{
					_OBEC_SUBMISSION_ID = value;
					ChangeState();
				}
			}
		}
		public string PAT_SEX
		{
			get { return _PAT_SEX; }
			set
			{
				if (_PAT_SEX != value)
				{
					_PAT_SEX = value;
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
		public decimal? WherePat_health_nbr { get; set; }
		private decimal? _wherePat_health_nbr;
		public string WherePat_version_cd { get; set; }
		private string _wherePat_version_cd;
		public string WhereObec_submission_id { get; set; }
		private string _whereObec_submission_id;
		public string WherePat_sex { get; set; }
		private string _wherePat_sex;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalPat_health_nbr;
		private string _originalPat_version_cd;
		private string _originalObec_submission_id;
		private string _originalPat_sex;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PAT_HEALTH_NBR = _originalPat_health_nbr;
			PAT_VERSION_CD = _originalPat_version_cd;
			OBEC_SUBMISSION_ID = _originalObec_submission_id;
			PAT_SEX = _originalPat_sex;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MOH_OBEC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MOH_OBEC_Purge]");
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
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("OBEC_SUBMISSION_ID", SqlNull(OBEC_SUBMISSION_ID)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MOH_OBEC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						OBEC_SUBMISSION_ID = Reader["OBEC_SUBMISSION_ID"].ToString();
						PAT_SEX = Reader["PAT_SEX"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalObec_submission_id = Reader["OBEC_SUBMISSION_ID"].ToString();
						_originalPat_sex = Reader["PAT_SEX"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("OBEC_SUBMISSION_ID", SqlNull(OBEC_SUBMISSION_ID)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MOH_OBEC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						OBEC_SUBMISSION_ID = Reader["OBEC_SUBMISSION_ID"].ToString();
						PAT_SEX = Reader["PAT_SEX"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalObec_submission_id = Reader["OBEC_SUBMISSION_ID"].ToString();
						_originalPat_sex = Reader["PAT_SEX"].ToString();
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