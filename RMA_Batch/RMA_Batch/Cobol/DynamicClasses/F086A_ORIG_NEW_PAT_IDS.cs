using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F086A_ORIG_NEW_PAT_IDS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F086A_ORIG_NEW_PAT_IDS> Collection( Guid? rowid,
															string orig_clmhdr_pat_ohip_id_or_chart,
															string orig_pat_old_surname,
															string orig_pat_old_given_name,
															string clmhdr_pat_ohip_id_or_chart,
															string pat_old_surname,
															string pat_old_given_name,
                                                            string aduser,
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
					new SqlParameter("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART",orig_clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("ORIG_PAT_OLD_SURNAME",orig_pat_old_surname),
					new SqlParameter("ORIG_PAT_OLD_GIVEN_NAME",orig_pat_old_given_name),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("PAT_OLD_SURNAME",pat_old_surname),
					new SqlParameter("PAT_OLD_GIVEN_NAME",pat_old_given_name),
                    new SqlParameter("ADUSER",aduser),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F086A_ORIG_NEW_PAT_IDS>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_Search]", parameters);
            var collection = new ObservableCollection<F086A_ORIG_NEW_PAT_IDS>();

            while (Reader.Read())
            {
                collection.Add(new F086A_ORIG_NEW_PAT_IDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					ORIG_PAT_OLD_SURNAME = Reader["ORIG_PAT_OLD_SURNAME"].ToString(),
					ORIG_PAT_OLD_GIVEN_NAME = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString(),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString(),
					PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    ADUSER = Reader["ADUSER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOrig_clmhdr_pat_ohip_id_or_chart = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalOrig_pat_old_surname = Reader["ORIG_PAT_OLD_SURNAME"].ToString(),
					_originalOrig_pat_old_given_name = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString(),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString(),
					_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    _originalAduser = Reader["ADUSER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F086A_ORIG_NEW_PAT_IDS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F086A_ORIG_NEW_PAT_IDS> Collection(ObservableCollection<F086A_ORIG_NEW_PAT_IDS>
                                                               f086aOrigNewPatIds = null)
        {
            if (IsSameSearch() && f086aOrigNewPatIds != null)
            {
                return f086aOrigNewPatIds;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F086A_ORIG_NEW_PAT_IDS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART",WhereOrig_clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("ORIG_PAT_OLD_SURNAME",WhereOrig_pat_old_surname),
					new SqlParameter("ORIG_PAT_OLD_GIVEN_NAME",WhereOrig_pat_old_given_name),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",WhereClmhdr_pat_ohip_id_or_chart),
					new SqlParameter("PAT_OLD_SURNAME",WherePat_old_surname),
					new SqlParameter("PAT_OLD_GIVEN_NAME",WherePat_old_given_name),
                    new SqlParameter("ADUSER",WhereAduser),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_Match]", parameters);
            var collection = new ObservableCollection<F086A_ORIG_NEW_PAT_IDS>();

            while (Reader.Read())
            {
                collection.Add(new F086A_ORIG_NEW_PAT_IDS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					ORIG_PAT_OLD_SURNAME = Reader["ORIG_PAT_OLD_SURNAME"].ToString(),
					ORIG_PAT_OLD_GIVEN_NAME = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString(),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString(),
					PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    ADUSER = Reader["ADUSER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereOrig_clmhdr_pat_ohip_id_or_chart = WhereOrig_clmhdr_pat_ohip_id_or_chart,
					_whereOrig_pat_old_surname = WhereOrig_pat_old_surname,
					_whereOrig_pat_old_given_name = WhereOrig_pat_old_given_name,
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart,
					_wherePat_old_surname = WherePat_old_surname,
					_wherePat_old_given_name = WherePat_old_given_name,
                    _whereAduser = WhereAduser,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalOrig_clmhdr_pat_ohip_id_or_chart = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalOrig_pat_old_surname = Reader["ORIG_PAT_OLD_SURNAME"].ToString(),
					_originalOrig_pat_old_given_name = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString(),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString(),
					_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    _originalAduser = Reader["ADUSER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereOrig_clmhdr_pat_ohip_id_or_chart = WhereOrig_clmhdr_pat_ohip_id_or_chart;
					_whereOrig_pat_old_surname = WhereOrig_pat_old_surname;
					_whereOrig_pat_old_given_name = WhereOrig_pat_old_given_name;
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart;
					_wherePat_old_surname = WherePat_old_surname;
					_wherePat_old_given_name = WherePat_old_given_name;
                    _whereAduser = WhereAduser;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereOrig_clmhdr_pat_ohip_id_or_chart == null 
				&& WhereOrig_pat_old_surname == null 
				&& WhereOrig_pat_old_given_name == null 
				&& WhereClmhdr_pat_ohip_id_or_chart == null 
				&& WherePat_old_surname == null 
				&& WherePat_old_given_name == null
                && WhereAduser == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereOrig_clmhdr_pat_ohip_id_or_chart ==  _whereOrig_clmhdr_pat_ohip_id_or_chart
				&& WhereOrig_pat_old_surname ==  _whereOrig_pat_old_surname
				&& WhereOrig_pat_old_given_name ==  _whereOrig_pat_old_given_name
				&& WhereClmhdr_pat_ohip_id_or_chart ==  _whereClmhdr_pat_ohip_id_or_chart
				&& WherePat_old_surname ==  _wherePat_old_surname
				&& WherePat_old_given_name ==  _wherePat_old_given_name
                && WhereAduser ==  _whereAduser
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereOrig_clmhdr_pat_ohip_id_or_chart = null; 
			WhereOrig_pat_old_surname = null; 
			WhereOrig_pat_old_given_name = null; 
			WhereClmhdr_pat_ohip_id_or_chart = null; 
			WherePat_old_surname = null; 
			WherePat_old_given_name = null;
            WhereAduser = null;
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART;
		private string _ORIG_PAT_OLD_SURNAME;
		private string _ORIG_PAT_OLD_GIVEN_NAME;
		private string _CLMHDR_PAT_OHIP_ID_OR_CHART;
		private string _PAT_OLD_SURNAME;
		private string _PAT_OLD_GIVEN_NAME;
        private string _ADUSER;
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
		public string ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART
		{
			get { return _ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART; }
			set
			{
				if (_ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART != value)
				{
					_ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = value;
					ChangeState();
				}
			}
		}
		public string ORIG_PAT_OLD_SURNAME
		{
			get { return _ORIG_PAT_OLD_SURNAME; }
			set
			{
				if (_ORIG_PAT_OLD_SURNAME != value)
				{
					_ORIG_PAT_OLD_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string ORIG_PAT_OLD_GIVEN_NAME
		{
			get { return _ORIG_PAT_OLD_GIVEN_NAME; }
			set
			{
				if (_ORIG_PAT_OLD_GIVEN_NAME != value)
				{
					_ORIG_PAT_OLD_GIVEN_NAME = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_OHIP_ID_OR_CHART
		{
			get { return _CLMHDR_PAT_OHIP_ID_OR_CHART; }
			set
			{
				if (_CLMHDR_PAT_OHIP_ID_OR_CHART != value)
				{
					_CLMHDR_PAT_OHIP_ID_OR_CHART = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_SURNAME
		{
			get { return _PAT_OLD_SURNAME; }
			set
			{
				if (_PAT_OLD_SURNAME != value)
				{
					_PAT_OLD_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_GIVEN_NAME
		{
			get { return _PAT_OLD_GIVEN_NAME; }
			set
			{
				if (_PAT_OLD_GIVEN_NAME != value)
				{
					_PAT_OLD_GIVEN_NAME = value;
					ChangeState();
				}
			}
		}
        public string ADUSER
        {
            get { return _ADUSER; }
            set
            {
                if (_ADUSER != value)
                {
                    _ADUSER = value;
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
		public string WhereOrig_clmhdr_pat_ohip_id_or_chart { get; set; }
		private string _whereOrig_clmhdr_pat_ohip_id_or_chart;
		public string WhereOrig_pat_old_surname { get; set; }
		private string _whereOrig_pat_old_surname;
		public string WhereOrig_pat_old_given_name { get; set; }
		private string _whereOrig_pat_old_given_name;
		public string WhereClmhdr_pat_ohip_id_or_chart { get; set; }
		private string _whereClmhdr_pat_ohip_id_or_chart;
		public string WherePat_old_surname { get; set; }
		private string _wherePat_old_surname;
		public string WherePat_old_given_name { get; set; }
		private string _wherePat_old_given_name;
        public string WhereAduser { get; set; }
        private string _whereAduser;
        public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalOrig_clmhdr_pat_ohip_id_or_chart;
		private string _originalOrig_pat_old_surname;
		private string _originalOrig_pat_old_given_name;
		private string _originalClmhdr_pat_ohip_id_or_chart;
		private string _originalPat_old_surname;
		private string _originalPat_old_given_name;
        private string _originalAduser;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = _originalOrig_clmhdr_pat_ohip_id_or_chart;
			ORIG_PAT_OLD_SURNAME = _originalOrig_pat_old_surname;
			ORIG_PAT_OLD_GIVEN_NAME = _originalOrig_pat_old_given_name;
			CLMHDR_PAT_OHIP_ID_OR_CHART = _originalClmhdr_pat_ohip_id_or_chart;
			PAT_OLD_SURNAME = _originalPat_old_surname;
			PAT_OLD_GIVEN_NAME = _originalPat_old_given_name;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_Purge]");
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
						new SqlParameter("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("ORIG_PAT_OLD_SURNAME", SqlNull(ORIG_PAT_OLD_SURNAME)),
						new SqlParameter("ORIG_PAT_OLD_GIVEN_NAME", SqlNull(ORIG_PAT_OLD_GIVEN_NAME)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("PAT_OLD_SURNAME", SqlNull(PAT_OLD_SURNAME)),
						new SqlParameter("PAT_OLD_GIVEN_NAME", SqlNull(PAT_OLD_GIVEN_NAME)),
                        new SqlParameter("ADUSER", SqlNull(ADUSER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						ORIG_PAT_OLD_SURNAME = Reader["ORIG_PAT_OLD_SURNAME"].ToString();
						ORIG_PAT_OLD_GIVEN_NAME = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString();
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString();
						PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString();
                        ADUSER = Reader["ADUSER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOrig_clmhdr_pat_ohip_id_or_chart = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalOrig_pat_old_surname = Reader["ORIG_PAT_OLD_SURNAME"].ToString();
						_originalOrig_pat_old_given_name = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString();
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString();
						_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString();
                        _originalAduser = Reader["ADUSER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("ORIG_PAT_OLD_SURNAME", SqlNull(ORIG_PAT_OLD_SURNAME)),
						new SqlParameter("ORIG_PAT_OLD_GIVEN_NAME", SqlNull(ORIG_PAT_OLD_GIVEN_NAME)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("PAT_OLD_SURNAME", SqlNull(PAT_OLD_SURNAME)),
						new SqlParameter("PAT_OLD_GIVEN_NAME", SqlNull(PAT_OLD_GIVEN_NAME)),
                        new SqlParameter("ADUSER", SqlNull(ADUSER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F086A_ORIG_NEW_PAT_IDS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						ORIG_PAT_OLD_SURNAME = Reader["ORIG_PAT_OLD_SURNAME"].ToString();
						ORIG_PAT_OLD_GIVEN_NAME = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString();
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString();
						PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString();
                        ADUSER = Reader["ADUSER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalOrig_clmhdr_pat_ohip_id_or_chart = Reader["ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalOrig_pat_old_surname = Reader["ORIG_PAT_OLD_SURNAME"].ToString();
						_originalOrig_pat_old_given_name = Reader["ORIG_PAT_OLD_GIVEN_NAME"].ToString();
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString();
						_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString();
                        _originalAduser = Reader["ADUSER"].ToString();
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