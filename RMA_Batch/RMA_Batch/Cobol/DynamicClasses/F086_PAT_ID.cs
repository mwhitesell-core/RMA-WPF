using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F086_PAT_ID : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F086_PAT_ID> Collection( Guid? rowid,
															string clmhdr_pat_ohip_id_or_chart,
															decimal? pat_last_birth_datemin,
															decimal? pat_last_birth_datemax,
															string pat_last_version_cd,
															string pat_old_surname,
															string pat_old_given_name,
															decimal? pat_old_health_nbrmin,
															decimal? pat_old_health_nbrmax,
															string pat_old_chart_nbr,
															string pat_old_chart_nbr_2,
															string pat_old_chart_nbr_3,
															string pat_old_chart_nbr_4,
															string pat_old_chart_nbr_5,
															string pat_old_addr1,
															string pat_old_addr2,
															string pat_old_addr3,
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
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("minPAT_LAST_BIRTH_DATE",pat_last_birth_datemin),
					new SqlParameter("maxPAT_LAST_BIRTH_DATE",pat_last_birth_datemax),
					new SqlParameter("PAT_LAST_VERSION_CD",pat_last_version_cd),
					new SqlParameter("PAT_OLD_SURNAME",pat_old_surname),
					new SqlParameter("PAT_OLD_GIVEN_NAME",pat_old_given_name),
					new SqlParameter("minPAT_OLD_HEALTH_NBR",pat_old_health_nbrmin),
					new SqlParameter("maxPAT_OLD_HEALTH_NBR",pat_old_health_nbrmax),
					new SqlParameter("PAT_OLD_CHART_NBR",pat_old_chart_nbr),
					new SqlParameter("PAT_OLD_CHART_NBR_2",pat_old_chart_nbr_2),
					new SqlParameter("PAT_OLD_CHART_NBR_3",pat_old_chart_nbr_3),
					new SqlParameter("PAT_OLD_CHART_NBR_4",pat_old_chart_nbr_4),
					new SqlParameter("PAT_OLD_CHART_NBR_5",pat_old_chart_nbr_5),
					new SqlParameter("PAT_OLD_ADDR1",pat_old_addr1),
					new SqlParameter("PAT_OLD_ADDR2",pat_old_addr2),
					new SqlParameter("PAT_OLD_ADDR3",pat_old_addr3),
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
                Reader = CoreReader("[INDEXED].[sp_F086_PAT_ID_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F086_PAT_ID>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F086_PAT_ID_Search]", parameters);
            var collection = new ObservableCollection<F086_PAT_ID>();

            while (Reader.Read())
            {
                collection.Add(new F086_PAT_ID
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
                    PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
                    PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
                    PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString(),
                    PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    PAT_OLD_HEALTH_NBR = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]),
                    PAT_OLD_CHART_NBR = Reader["PAT_OLD_CHART_NBR"].ToString(),
                    PAT_OLD_CHART_NBR_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString(),
                    PAT_OLD_CHART_NBR_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString(),
                    PAT_OLD_CHART_NBR_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString(),
                    PAT_OLD_CHART_NBR_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString(),
                    PAT_OLD_ADDR1 = Reader["PAT_OLD_ADDR1"].ToString(),
                    PAT_OLD_ADDR2 = Reader["PAT_OLD_ADDR2"].ToString(),
                    PAT_OLD_ADDR3 = Reader["PAT_OLD_ADDR3"].ToString(),
                    ADUSER = Reader["ADUSER"].ToString(),
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
                    _originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
                    _originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
                    _originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString(),
                    _originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                    _originalPat_old_health_nbr = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]),
                    _originalPat_old_chart_nbr = Reader["PAT_OLD_CHART_NBR"].ToString(),
                    _originalPat_old_chart_nbr_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString(),
                    _originalPat_old_chart_nbr_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString(),
                    _originalPat_old_chart_nbr_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString(),
                    _originalPat_old_chart_nbr_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString(),
                    _originalPat_old_addr1 = Reader["PAT_OLD_ADDR1"].ToString(),
                    _originalPat_old_addr2 = Reader["PAT_OLD_ADDR2"].ToString(),
                    _originalPat_old_addr3 = Reader["PAT_OLD_ADDR3"].ToString(),
                    _originalAduser = Reader["ADUSER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F086_PAT_ID Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F086_PAT_ID> Collection(ObservableCollection<F086_PAT_ID>
                                                               f086PatId = null)
        {
            if (IsSameSearch() && f086PatId != null)
            {
                return f086PatId;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F086_PAT_ID>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",WhereClmhdr_pat_ohip_id_or_chart),
					new SqlParameter("PAT_LAST_BIRTH_DATE",WherePat_last_birth_date),
					new SqlParameter("PAT_LAST_VERSION_CD",WherePat_last_version_cd),
					new SqlParameter("PAT_OLD_SURNAME",WherePat_old_surname),
					new SqlParameter("PAT_OLD_GIVEN_NAME",WherePat_old_given_name),
					new SqlParameter("PAT_OLD_HEALTH_NBR",WherePat_old_health_nbr),
					new SqlParameter("PAT_OLD_CHART_NBR",WherePat_old_chart_nbr),
					new SqlParameter("PAT_OLD_CHART_NBR_2",WherePat_old_chart_nbr_2),
					new SqlParameter("PAT_OLD_CHART_NBR_3",WherePat_old_chart_nbr_3),
					new SqlParameter("PAT_OLD_CHART_NBR_4",WherePat_old_chart_nbr_4),
					new SqlParameter("PAT_OLD_CHART_NBR_5",WherePat_old_chart_nbr_5),
					new SqlParameter("PAT_OLD_ADDR1",WherePat_old_addr1),
					new SqlParameter("PAT_OLD_ADDR2",WherePat_old_addr2),
					new SqlParameter("PAT_OLD_ADDR3",WherePat_old_addr3),
                    new SqlParameter("ADUSER",WhereAduser),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F086_PAT_ID_Match]", parameters);
            var collection = new ObservableCollection<F086_PAT_ID>();

            while (Reader.Read())
            {
            collection.Add(new F086_PAT_ID
            {
                RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                ROWID = (Guid)Reader["ROWID"],
                CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
                PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
                PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
                PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString(),
                PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                PAT_OLD_HEALTH_NBR = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]),
                PAT_OLD_CHART_NBR = Reader["PAT_OLD_CHART_NBR"].ToString(),
                PAT_OLD_CHART_NBR_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString(),
                PAT_OLD_CHART_NBR_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString(),
                PAT_OLD_CHART_NBR_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString(),
                PAT_OLD_CHART_NBR_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString(),
                PAT_OLD_ADDR1 = Reader["PAT_OLD_ADDR1"].ToString(),
                PAT_OLD_ADDR2 = Reader["PAT_OLD_ADDR2"].ToString(),
                PAT_OLD_ADDR3 = Reader["PAT_OLD_ADDR3"].ToString(),
                ADUSER = Reader["ADUSER"].ToString(),
                CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                _whereRowid = WhereRowid,
                _whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart,
                _wherePat_last_birth_date = WherePat_last_birth_date,
                _wherePat_last_version_cd = WherePat_last_version_cd,
                _wherePat_old_surname = WherePat_old_surname,
                _wherePat_old_given_name = WherePat_old_given_name,
                _wherePat_old_health_nbr = WherePat_old_health_nbr,
                _wherePat_old_chart_nbr = WherePat_old_chart_nbr,
                _wherePat_old_chart_nbr_2 = WherePat_old_chart_nbr_2,
                _wherePat_old_chart_nbr_3 = WherePat_old_chart_nbr_3,
                _wherePat_old_chart_nbr_4 = WherePat_old_chart_nbr_4,
                _wherePat_old_chart_nbr_5 = WherePat_old_chart_nbr_5,
                _wherePat_old_addr1 = WherePat_old_addr1,
                _wherePat_old_addr2 = WherePat_old_addr2,
                _wherePat_old_addr3 = WherePat_old_addr3,
                _whereAduser = WhereAduser,
                _whereChecksum_value = WhereChecksum_value,

                _originalRowid = (Guid)Reader["ROWID"],
                _originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
                _originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
                _originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
                _originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString(),
                _originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString(),
                _originalPat_old_health_nbr = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]),
                _originalPat_old_chart_nbr = Reader["PAT_OLD_CHART_NBR"].ToString(),
                _originalPat_old_chart_nbr_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString(),
                _originalPat_old_chart_nbr_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString(),
                _originalPat_old_chart_nbr_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString(),
                _originalPat_old_chart_nbr_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString(),
                _originalPat_old_addr1 = Reader["PAT_OLD_ADDR1"].ToString(),
                _originalPat_old_addr2 = Reader["PAT_OLD_ADDR2"].ToString(),
                _originalPat_old_addr3 = Reader["PAT_OLD_ADDR3"].ToString(),
                _originalAduser = Reader["ADUSER"].ToString(),
                _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart;
					_wherePat_last_birth_date = WherePat_last_birth_date;
					_wherePat_last_version_cd = WherePat_last_version_cd;
					_wherePat_old_surname = WherePat_old_surname;
					_wherePat_old_given_name = WherePat_old_given_name;
					_wherePat_old_health_nbr = WherePat_old_health_nbr;
					_wherePat_old_chart_nbr = WherePat_old_chart_nbr;
					_wherePat_old_chart_nbr_2 = WherePat_old_chart_nbr_2;
					_wherePat_old_chart_nbr_3 = WherePat_old_chart_nbr_3;
					_wherePat_old_chart_nbr_4 = WherePat_old_chart_nbr_4;
					_wherePat_old_chart_nbr_5 = WherePat_old_chart_nbr_5;
					_wherePat_old_addr1 = WherePat_old_addr1;
					_wherePat_old_addr2 = WherePat_old_addr2;
					_wherePat_old_addr3 = WherePat_old_addr3;
                    _whereAduser = WhereAduser;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_pat_ohip_id_or_chart == null 
				&& WherePat_last_birth_date == null 
				&& WherePat_last_version_cd == null 
				&& WherePat_old_surname == null 
				&& WherePat_old_given_name == null 
				&& WherePat_old_health_nbr == null 
				&& WherePat_old_chart_nbr == null 
				&& WherePat_old_chart_nbr_2 == null 
				&& WherePat_old_chart_nbr_3 == null 
				&& WherePat_old_chart_nbr_4 == null 
				&& WherePat_old_chart_nbr_5 == null 
				&& WherePat_old_addr1 == null 
				&& WherePat_old_addr2 == null 
				&& WherePat_old_addr3 == null 
                && WhereAduser == null
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_pat_ohip_id_or_chart ==  _whereClmhdr_pat_ohip_id_or_chart
				&& WherePat_last_birth_date ==  _wherePat_last_birth_date
				&& WherePat_last_version_cd ==  _wherePat_last_version_cd
				&& WherePat_old_surname ==  _wherePat_old_surname
				&& WherePat_old_given_name ==  _wherePat_old_given_name
				&& WherePat_old_health_nbr ==  _wherePat_old_health_nbr
				&& WherePat_old_chart_nbr ==  _wherePat_old_chart_nbr
				&& WherePat_old_chart_nbr_2 ==  _wherePat_old_chart_nbr_2
				&& WherePat_old_chart_nbr_3 ==  _wherePat_old_chart_nbr_3
				&& WherePat_old_chart_nbr_4 ==  _wherePat_old_chart_nbr_4
				&& WherePat_old_chart_nbr_5 ==  _wherePat_old_chart_nbr_5
				&& WherePat_old_addr1 ==  _wherePat_old_addr1
				&& WherePat_old_addr2 ==  _wherePat_old_addr2
				&& WherePat_old_addr3 ==  _wherePat_old_addr3
                && WhereAduser ==  _whereAduser
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_pat_ohip_id_or_chart = null; 
			WherePat_last_birth_date = null; 
			WherePat_last_version_cd = null; 
			WherePat_old_surname = null; 
			WherePat_old_given_name = null; 
			WherePat_old_health_nbr = null; 
			WherePat_old_chart_nbr = null; 
			WherePat_old_chart_nbr_2 = null; 
			WherePat_old_chart_nbr_3 = null; 
			WherePat_old_chart_nbr_4 = null; 
			WherePat_old_chart_nbr_5 = null; 
			WherePat_old_addr1 = null; 
			WherePat_old_addr2 = null; 
			WherePat_old_addr3 = null;
            WhereAduser = null;
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_PAT_OHIP_ID_OR_CHART;
		private decimal? _PAT_LAST_BIRTH_DATE;
		private string _PAT_LAST_VERSION_CD;
		private string _PAT_OLD_SURNAME;
		private string _PAT_OLD_GIVEN_NAME;
		private decimal? _PAT_OLD_HEALTH_NBR;
		private string _PAT_OLD_CHART_NBR;
		private string _PAT_OLD_CHART_NBR_2;
		private string _PAT_OLD_CHART_NBR_3;
		private string _PAT_OLD_CHART_NBR_4;
		private string _PAT_OLD_CHART_NBR_5;
		private string _PAT_OLD_ADDR1;
		private string _PAT_OLD_ADDR2;
		private string _PAT_OLD_ADDR3;
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
		public decimal? PAT_LAST_BIRTH_DATE
		{
			get { return _PAT_LAST_BIRTH_DATE; }
			set
			{
				if (_PAT_LAST_BIRTH_DATE != value)
				{
					_PAT_LAST_BIRTH_DATE = value;
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
		public decimal? PAT_OLD_HEALTH_NBR
		{
			get { return _PAT_OLD_HEALTH_NBR; }
			set
			{
				if (_PAT_OLD_HEALTH_NBR != value)
				{
					_PAT_OLD_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_CHART_NBR
		{
			get { return _PAT_OLD_CHART_NBR; }
			set
			{
				if (_PAT_OLD_CHART_NBR != value)
				{
					_PAT_OLD_CHART_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_CHART_NBR_2
		{
			get { return _PAT_OLD_CHART_NBR_2; }
			set
			{
				if (_PAT_OLD_CHART_NBR_2 != value)
				{
					_PAT_OLD_CHART_NBR_2 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_CHART_NBR_3
		{
			get { return _PAT_OLD_CHART_NBR_3; }
			set
			{
				if (_PAT_OLD_CHART_NBR_3 != value)
				{
					_PAT_OLD_CHART_NBR_3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_CHART_NBR_4
		{
			get { return _PAT_OLD_CHART_NBR_4; }
			set
			{
				if (_PAT_OLD_CHART_NBR_4 != value)
				{
					_PAT_OLD_CHART_NBR_4 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_CHART_NBR_5
		{
			get { return _PAT_OLD_CHART_NBR_5; }
			set
			{
				if (_PAT_OLD_CHART_NBR_5 != value)
				{
					_PAT_OLD_CHART_NBR_5 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_ADDR1
		{
			get { return _PAT_OLD_ADDR1; }
			set
			{
				if (_PAT_OLD_ADDR1 != value)
				{
					_PAT_OLD_ADDR1 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_ADDR2
		{
			get { return _PAT_OLD_ADDR2; }
			set
			{
				if (_PAT_OLD_ADDR2 != value)
				{
					_PAT_OLD_ADDR2 = value;
					ChangeState();
				}
			}
		}
		public string PAT_OLD_ADDR3
		{
			get { return _PAT_OLD_ADDR3; }
			set
			{
				if (_PAT_OLD_ADDR3 != value)
				{
					_PAT_OLD_ADDR3 = value;
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
		public string WhereClmhdr_pat_ohip_id_or_chart { get; set; }
		private string _whereClmhdr_pat_ohip_id_or_chart;
		public decimal? WherePat_last_birth_date { get; set; }
		private decimal? _wherePat_last_birth_date;
		public string WherePat_last_version_cd { get; set; }
		private string _wherePat_last_version_cd;
		public string WherePat_old_surname { get; set; }
		private string _wherePat_old_surname;
		public string WherePat_old_given_name { get; set; }
		private string _wherePat_old_given_name;
		public decimal? WherePat_old_health_nbr { get; set; }
		private decimal? _wherePat_old_health_nbr;
		public string WherePat_old_chart_nbr { get; set; }
		private string _wherePat_old_chart_nbr;
		public string WherePat_old_chart_nbr_2 { get; set; }
		private string _wherePat_old_chart_nbr_2;
		public string WherePat_old_chart_nbr_3 { get; set; }
		private string _wherePat_old_chart_nbr_3;
		public string WherePat_old_chart_nbr_4 { get; set; }
		private string _wherePat_old_chart_nbr_4;
		public string WherePat_old_chart_nbr_5 { get; set; }
		private string _wherePat_old_chart_nbr_5;
		public string WherePat_old_addr1 { get; set; }
		private string _wherePat_old_addr1;
		public string WherePat_old_addr2 { get; set; }
		private string _wherePat_old_addr2;
		public string WherePat_old_addr3 { get; set; }
		private string _wherePat_old_addr3;
        public string WhereAduser { get; set; }
        private string _whereAduser;
        public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_pat_ohip_id_or_chart;
		private decimal? _originalPat_last_birth_date;
		private string _originalPat_last_version_cd;
		private string _originalPat_old_surname;
		private string _originalPat_old_given_name;
		private decimal? _originalPat_old_health_nbr;
		private string _originalPat_old_chart_nbr;
		private string _originalPat_old_chart_nbr_2;
		private string _originalPat_old_chart_nbr_3;
		private string _originalPat_old_chart_nbr_4;
		private string _originalPat_old_chart_nbr_5;
		private string _originalPat_old_addr1;
		private string _originalPat_old_addr2;
		private string _originalPat_old_addr3;
        private string _originalAduser;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_PAT_OHIP_ID_OR_CHART = _originalClmhdr_pat_ohip_id_or_chart;
			PAT_LAST_BIRTH_DATE = _originalPat_last_birth_date;
			PAT_LAST_VERSION_CD = _originalPat_last_version_cd;
			PAT_OLD_SURNAME = _originalPat_old_surname;
			PAT_OLD_GIVEN_NAME = _originalPat_old_given_name;
			PAT_OLD_HEALTH_NBR = _originalPat_old_health_nbr;
			PAT_OLD_CHART_NBR = _originalPat_old_chart_nbr;
			PAT_OLD_CHART_NBR_2 = _originalPat_old_chart_nbr_2;
			PAT_OLD_CHART_NBR_3 = _originalPat_old_chart_nbr_3;
			PAT_OLD_CHART_NBR_4 = _originalPat_old_chart_nbr_4;
			PAT_OLD_CHART_NBR_5 = _originalPat_old_chart_nbr_5;
			PAT_OLD_ADDR1 = _originalPat_old_addr1;
			PAT_OLD_ADDR2 = _originalPat_old_addr2;
			PAT_OLD_ADDR3 = _originalPat_old_addr3;
            ADUSER = _originalAduser;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F086_PAT_ID_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F086_PAT_ID_Purge]");
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
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("PAT_LAST_BIRTH_DATE", SqlNull(PAT_LAST_BIRTH_DATE)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_OLD_SURNAME", SqlNull(PAT_OLD_SURNAME)),
						new SqlParameter("PAT_OLD_GIVEN_NAME", SqlNull(PAT_OLD_GIVEN_NAME)),
						new SqlParameter("PAT_OLD_HEALTH_NBR", SqlNull(PAT_OLD_HEALTH_NBR)),
						new SqlParameter("PAT_OLD_CHART_NBR", SqlNull(PAT_OLD_CHART_NBR)),
						new SqlParameter("PAT_OLD_CHART_NBR_2", SqlNull(PAT_OLD_CHART_NBR_2)),
						new SqlParameter("PAT_OLD_CHART_NBR_3", SqlNull(PAT_OLD_CHART_NBR_3)),
						new SqlParameter("PAT_OLD_CHART_NBR_4", SqlNull(PAT_OLD_CHART_NBR_4)),
						new SqlParameter("PAT_OLD_CHART_NBR_5", SqlNull(PAT_OLD_CHART_NBR_5)),
						new SqlParameter("PAT_OLD_ADDR1", SqlNull(PAT_OLD_ADDR1)),
						new SqlParameter("PAT_OLD_ADDR2", SqlNull(PAT_OLD_ADDR2)),
						new SqlParameter("PAT_OLD_ADDR3", SqlNull(PAT_OLD_ADDR3)),
                        new SqlParameter("ADUSER", SqlNull(ADUSER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F086_PAT_ID_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString();
						PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString();
						PAT_OLD_HEALTH_NBR = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]);
						PAT_OLD_CHART_NBR = Reader["PAT_OLD_CHART_NBR"].ToString();
						PAT_OLD_CHART_NBR_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString();
						PAT_OLD_CHART_NBR_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString();
						PAT_OLD_CHART_NBR_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString();
						PAT_OLD_CHART_NBR_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString();
						PAT_OLD_ADDR1 = Reader["PAT_OLD_ADDR1"].ToString();
						PAT_OLD_ADDR2 = Reader["PAT_OLD_ADDR2"].ToString();
						PAT_OLD_ADDR3 = Reader["PAT_OLD_ADDR3"].ToString();
                        ADUSER = Reader["ADUSER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString();
						_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString();
						_originalPat_old_health_nbr = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]);
						_originalPat_old_chart_nbr = Reader["PAT_OLD_CHART_NBR"].ToString();
						_originalPat_old_chart_nbr_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString();
						_originalPat_old_chart_nbr_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString();
						_originalPat_old_chart_nbr_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString();
						_originalPat_old_chart_nbr_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString();
						_originalPat_old_addr1 = Reader["PAT_OLD_ADDR1"].ToString();
						_originalPat_old_addr2 = Reader["PAT_OLD_ADDR2"].ToString();
						_originalPat_old_addr3 = Reader["PAT_OLD_ADDR3"].ToString();
                        _originalAduser = Reader["ADUSER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("PAT_LAST_BIRTH_DATE", SqlNull(PAT_LAST_BIRTH_DATE)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_OLD_SURNAME", SqlNull(PAT_OLD_SURNAME)),
						new SqlParameter("PAT_OLD_GIVEN_NAME", SqlNull(PAT_OLD_GIVEN_NAME)),
						new SqlParameter("PAT_OLD_HEALTH_NBR", SqlNull(PAT_OLD_HEALTH_NBR)),
						new SqlParameter("PAT_OLD_CHART_NBR", SqlNull(PAT_OLD_CHART_NBR)),
						new SqlParameter("PAT_OLD_CHART_NBR_2", SqlNull(PAT_OLD_CHART_NBR_2)),
						new SqlParameter("PAT_OLD_CHART_NBR_3", SqlNull(PAT_OLD_CHART_NBR_3)),
						new SqlParameter("PAT_OLD_CHART_NBR_4", SqlNull(PAT_OLD_CHART_NBR_4)),
						new SqlParameter("PAT_OLD_CHART_NBR_5", SqlNull(PAT_OLD_CHART_NBR_5)),
						new SqlParameter("PAT_OLD_ADDR1", SqlNull(PAT_OLD_ADDR1)),
						new SqlParameter("PAT_OLD_ADDR2", SqlNull(PAT_OLD_ADDR2)),
						new SqlParameter("PAT_OLD_ADDR3", SqlNull(PAT_OLD_ADDR3)),
                        new SqlParameter("ADUSER", SqlNull(ADUSER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F086_PAT_ID_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_OLD_SURNAME = Reader["PAT_OLD_SURNAME"].ToString();
						PAT_OLD_GIVEN_NAME = Reader["PAT_OLD_GIVEN_NAME"].ToString();
						PAT_OLD_HEALTH_NBR = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]);
						PAT_OLD_CHART_NBR = Reader["PAT_OLD_CHART_NBR"].ToString();
						PAT_OLD_CHART_NBR_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString();
						PAT_OLD_CHART_NBR_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString();
						PAT_OLD_CHART_NBR_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString();
						PAT_OLD_CHART_NBR_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString();
						PAT_OLD_ADDR1 = Reader["PAT_OLD_ADDR1"].ToString();
						PAT_OLD_ADDR2 = Reader["PAT_OLD_ADDR2"].ToString();
						PAT_OLD_ADDR3 = Reader["PAT_OLD_ADDR3"].ToString();
                        ADUSER = Reader["ADUSER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_old_surname = Reader["PAT_OLD_SURNAME"].ToString();
						_originalPat_old_given_name = Reader["PAT_OLD_GIVEN_NAME"].ToString();
						_originalPat_old_health_nbr = ConvertDEC(Reader["PAT_OLD_HEALTH_NBR"]);
						_originalPat_old_chart_nbr = Reader["PAT_OLD_CHART_NBR"].ToString();
						_originalPat_old_chart_nbr_2 = Reader["PAT_OLD_CHART_NBR_2"].ToString();
						_originalPat_old_chart_nbr_3 = Reader["PAT_OLD_CHART_NBR_3"].ToString();
						_originalPat_old_chart_nbr_4 = Reader["PAT_OLD_CHART_NBR_4"].ToString();
						_originalPat_old_chart_nbr_5 = Reader["PAT_OLD_CHART_NBR_5"].ToString();
						_originalPat_old_addr1 = Reader["PAT_OLD_ADDR1"].ToString();
						_originalPat_old_addr2 = Reader["PAT_OLD_ADDR2"].ToString();
						_originalPat_old_addr3 = Reader["PAT_OLD_ADDR3"].ToString();
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