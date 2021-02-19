using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F201_SLI_OMA_CODE_SUFF : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F201_SLI_OMA_CODE_SUFF> Collection( Guid? rowid,
															string clmdtl_oma_cd,
															string clmdtl_oma_suff,
															string loc_service_location_indicator,
															string fee_admit_ind,
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
					new SqlParameter("CLMDTL_OMA_CD",clmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",clmdtl_oma_suff),
					new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR",loc_service_location_indicator),
					new SqlParameter("FEE_ADMIT_IND",fee_admit_ind),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F201_SLI_OMA_CODE_SUFF>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_Search]", parameters);
            var collection = new ObservableCollection<F201_SLI_OMA_CODE_SUFF>();

            while (Reader.Read())
            {
                collection.Add(new F201_SLI_OMA_CODE_SUFF
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F201_SLI_OMA_CODE_SUFF Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F201_SLI_OMA_CODE_SUFF> Collection(ObservableCollection<F201_SLI_OMA_CODE_SUFF>
                                                               f201SliOmaCodeSuff = null)
        {
            if (IsSameSearch() && f201SliOmaCodeSuff != null)
            {
                return f201SliOmaCodeSuff;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F201_SLI_OMA_CODE_SUFF>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",WhereClmdtl_oma_suff),
					new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR",WhereLoc_service_location_indicator),
					new SqlParameter("FEE_ADMIT_IND",WhereFee_admit_ind),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_Match]", parameters);
            var collection = new ObservableCollection<F201_SLI_OMA_CODE_SUFF>();

            while (Reader.Read())
            {
                collection.Add(new F201_SLI_OMA_CODE_SUFF
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff,
					_whereLoc_service_location_indicator = WhereLoc_service_location_indicator,
					_whereFee_admit_ind = WhereFee_admit_ind,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString(),
					_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd;
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff;
					_whereLoc_service_location_indicator = WhereLoc_service_location_indicator;
					_whereFee_admit_ind = WhereFee_admit_ind;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmdtl_oma_cd == null 
				&& WhereClmdtl_oma_suff == null 
				&& WhereLoc_service_location_indicator == null 
				&& WhereFee_admit_ind == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmdtl_oma_cd ==  _whereClmdtl_oma_cd
				&& WhereClmdtl_oma_suff ==  _whereClmdtl_oma_suff
				&& WhereLoc_service_location_indicator ==  _whereLoc_service_location_indicator
				&& WhereFee_admit_ind ==  _whereFee_admit_ind
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmdtl_oma_cd = null; 
			WhereClmdtl_oma_suff = null; 
			WhereLoc_service_location_indicator = null; 
			WhereFee_admit_ind = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMDTL_OMA_CD;
		private string _CLMDTL_OMA_SUFF;
		private string _LOC_SERVICE_LOCATION_INDICATOR;
		private string _FEE_ADMIT_IND;
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
		public string CLMDTL_OMA_CD
		{
			get { return _CLMDTL_OMA_CD; }
			set
			{
				if (_CLMDTL_OMA_CD != value)
				{
					_CLMDTL_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_OMA_SUFF
		{
			get { return _CLMDTL_OMA_SUFF; }
			set
			{
				if (_CLMDTL_OMA_SUFF != value)
				{
					_CLMDTL_OMA_SUFF = value;
					ChangeState();
				}
			}
		}
		public string LOC_SERVICE_LOCATION_INDICATOR
		{
			get { return _LOC_SERVICE_LOCATION_INDICATOR; }
			set
			{
				if (_LOC_SERVICE_LOCATION_INDICATOR != value)
				{
					_LOC_SERVICE_LOCATION_INDICATOR = value;
					ChangeState();
				}
			}
		}
		public string FEE_ADMIT_IND
		{
			get { return _FEE_ADMIT_IND; }
			set
			{
				if (_FEE_ADMIT_IND != value)
				{
					_FEE_ADMIT_IND = value;
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
		public string WhereClmdtl_oma_cd { get; set; }
		private string _whereClmdtl_oma_cd;
		public string WhereClmdtl_oma_suff { get; set; }
		private string _whereClmdtl_oma_suff;
		public string WhereLoc_service_location_indicator { get; set; }
		private string _whereLoc_service_location_indicator;
		public string WhereFee_admit_ind { get; set; }
		private string _whereFee_admit_ind;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmdtl_oma_cd;
		private string _originalClmdtl_oma_suff;
		private string _originalLoc_service_location_indicator;
		private string _originalFee_admit_ind;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMDTL_OMA_CD = _originalClmdtl_oma_cd;
			CLMDTL_OMA_SUFF = _originalClmdtl_oma_suff;
			LOC_SERVICE_LOCATION_INDICATOR = _originalLoc_service_location_indicator;
			FEE_ADMIT_IND = _originalFee_admit_ind;
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
					new SqlParameter("CLMDTL_OMA_CD",CLMDTL_OMA_CD),
					new SqlParameter("CLMDTL_OMA_SUFF",CLMDTL_OMA_SUFF),
					new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR",LOC_SERVICE_LOCATION_INDICATOR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_Purge]");
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
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR", SqlNull(LOC_SERVICE_LOCATION_INDICATOR)),
						new SqlParameter("FEE_ADMIT_IND", SqlNull(FEE_ADMIT_IND)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("LOC_SERVICE_LOCATION_INDICATOR", SqlNull(LOC_SERVICE_LOCATION_INDICATOR)),
						new SqlParameter("FEE_ADMIT_IND", SqlNull(FEE_ADMIT_IND)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F201_SLI_OMA_CODE_SUFF_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						LOC_SERVICE_LOCATION_INDICATOR = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalLoc_service_location_indicator = Reader["LOC_SERVICE_LOCATION_INDICATOR"].ToString();
						_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString();
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