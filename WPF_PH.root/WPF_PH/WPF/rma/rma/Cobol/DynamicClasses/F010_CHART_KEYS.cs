using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F010_CHART_KEYS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F010_CHART_KEYS> Collection( Guid? rowid,
															string key_pat_mstr,
															string pat_chart_nbr_r,
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
					new SqlParameter("KEY_PAT_MSTR",key_pat_mstr),
					new SqlParameter("PAT_CHART_NBR_R",pat_chart_nbr_r),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F010_CHART_KEYS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F010_CHART_KEYS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F010_CHART_KEYS_Search]", parameters);
            var collection = new ObservableCollection<F010_CHART_KEYS>();

            while (Reader.Read())
            {
                collection.Add(new F010_CHART_KEYS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
					PAT_CHART_NBR_R = Reader["PAT_CHART_NBR_R"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
					_originalPat_chart_nbr_r = Reader["PAT_CHART_NBR_R"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F010_CHART_KEYS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F010_CHART_KEYS> Collection(ObservableCollection<F010_CHART_KEYS>
                                                               f010ChartKeys = null)
        {
            if (IsSameSearch() && f010ChartKeys != null)
            {
                return f010ChartKeys;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F010_CHART_KEYS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("KEY_PAT_MSTR",WhereKey_pat_mstr),
					new SqlParameter("PAT_CHART_NBR_R",WherePat_chart_nbr_r),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F010_CHART_KEYS_Match]", parameters);
            var collection = new ObservableCollection<F010_CHART_KEYS>();

            while (Reader.Read())
            {
                collection.Add(new F010_CHART_KEYS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString(),
					PAT_CHART_NBR_R = Reader["PAT_CHART_NBR_R"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereKey_pat_mstr = WhereKey_pat_mstr,
					_wherePat_chart_nbr_r = WherePat_chart_nbr_r,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString(),
					_originalPat_chart_nbr_r = Reader["PAT_CHART_NBR_R"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereKey_pat_mstr = WhereKey_pat_mstr;
					_wherePat_chart_nbr_r = WherePat_chart_nbr_r;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereKey_pat_mstr == null 
				&& WherePat_chart_nbr_r == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereKey_pat_mstr ==  _whereKey_pat_mstr
				&& WherePat_chart_nbr_r ==  _wherePat_chart_nbr_r
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereKey_pat_mstr = null; 
			WherePat_chart_nbr_r = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _KEY_PAT_MSTR;
		private string _PAT_CHART_NBR_R;
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
		public string KEY_PAT_MSTR
		{
			get { return _KEY_PAT_MSTR; }
			set
			{
				if (_KEY_PAT_MSTR != value)
				{
					_KEY_PAT_MSTR = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR_R
		{
			get { return _PAT_CHART_NBR_R; }
			set
			{
				if (_PAT_CHART_NBR_R != value)
				{
					_PAT_CHART_NBR_R = value;
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
		public string WhereKey_pat_mstr { get; set; }
		private string _whereKey_pat_mstr;
		public string WherePat_chart_nbr_r { get; set; }
		private string _wherePat_chart_nbr_r;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalKey_pat_mstr;
		private string _originalPat_chart_nbr_r;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			KEY_PAT_MSTR = _originalKey_pat_mstr;
			PAT_CHART_NBR_R = _originalPat_chart_nbr_r;
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
					new SqlParameter("PAT_CHART_NBR_R",PAT_CHART_NBR_R)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_CHART_KEYS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_CHART_KEYS_Purge]");
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
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("PAT_CHART_NBR_R", SqlNull(PAT_CHART_NBR_R)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_CHART_KEYS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						PAT_CHART_NBR_R = Reader["PAT_CHART_NBR_R"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalPat_chart_nbr_r = Reader["PAT_CHART_NBR_R"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("KEY_PAT_MSTR", SqlNull(KEY_PAT_MSTR)),
						new SqlParameter("PAT_CHART_NBR_R", SqlNull(PAT_CHART_NBR_R)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_CHART_KEYS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_PAT_MSTR = Reader["KEY_PAT_MSTR"].ToString();
						PAT_CHART_NBR_R = Reader["PAT_CHART_NBR_R"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_pat_mstr = Reader["KEY_PAT_MSTR"].ToString();
						_originalPat_chart_nbr_r = Reader["PAT_CHART_NBR_R"].ToString();
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