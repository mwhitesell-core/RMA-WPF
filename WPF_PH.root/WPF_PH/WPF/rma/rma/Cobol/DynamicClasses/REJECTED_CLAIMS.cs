using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class REJECTED_CLAIMS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<REJECTED_CLAIMS> Collection( Guid? rowid,
															string claim_nbr,
															string doc_nbr,
															string clmhdr_pat_ohip_id_or_chart,
															string clmhdr_loc,
															string mess_code,
															string logically_deleted_flag,
															decimal? clmhdr_submit_datemin,
															decimal? clmhdr_submit_datemax,
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
					new SqlParameter("CLAIM_NBR",claim_nbr),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("CLMHDR_LOC",clmhdr_loc),
					new SqlParameter("MESS_CODE",mess_code),
					new SqlParameter("LOGICALLY_DELETED_FLAG",logically_deleted_flag),
					new SqlParameter("minCLMHDR_SUBMIT_DATE",clmhdr_submit_datemin),
					new SqlParameter("maxCLMHDR_SUBMIT_DATE",clmhdr_submit_datemax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_REJECTED_CLAIMS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<REJECTED_CLAIMS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_REJECTED_CLAIMS_Search]", parameters);
            var collection = new ObservableCollection<REJECTED_CLAIMS>();

            while (Reader.Read())
            {
                collection.Add(new REJECTED_CLAIMS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					MESS_CODE = Reader["MESS_CODE"].ToString(),
					LOGICALLY_DELETED_FLAG = Reader["LOGICALLY_DELETED_FLAG"].ToString(),
					CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalMess_code = Reader["MESS_CODE"].ToString(),
					_originalLogically_deleted_flag = Reader["LOGICALLY_DELETED_FLAG"].ToString(),
					_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public REJECTED_CLAIMS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<REJECTED_CLAIMS> Collection(ObservableCollection<REJECTED_CLAIMS>
                                                               rejectedClaims = null)
        {
            if (IsSameSearch() && rejectedClaims != null)
            {
                return rejectedClaims;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<REJECTED_CLAIMS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLAIM_NBR",WhereClaim_nbr),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",WhereClmhdr_pat_ohip_id_or_chart),
					new SqlParameter("CLMHDR_LOC",WhereClmhdr_loc),
					new SqlParameter("MESS_CODE",WhereMess_code),
					new SqlParameter("LOGICALLY_DELETED_FLAG",WhereLogically_deleted_flag),
					new SqlParameter("CLMHDR_SUBMIT_DATE",WhereClmhdr_submit_date),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_REJECTED_CLAIMS_Match]", parameters);
            var collection = new ObservableCollection<REJECTED_CLAIMS>();

            while (Reader.Read())
            {
                collection.Add(new REJECTED_CLAIMS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR = Reader["CLAIM_NBR"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					MESS_CODE = Reader["MESS_CODE"].ToString(),
					LOGICALLY_DELETED_FLAG = Reader["LOGICALLY_DELETED_FLAG"].ToString(),
					CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClaim_nbr = WhereClaim_nbr,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart,
					_whereClmhdr_loc = WhereClmhdr_loc,
					_whereMess_code = WhereMess_code,
					_whereLogically_deleted_flag = WhereLogically_deleted_flag,
					_whereClmhdr_submit_date = WhereClmhdr_submit_date,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr = Reader["CLAIM_NBR"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalMess_code = Reader["MESS_CODE"].ToString(),
					_originalLogically_deleted_flag = Reader["LOGICALLY_DELETED_FLAG"].ToString(),
					_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClaim_nbr = WhereClaim_nbr;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart;
					_whereClmhdr_loc = WhereClmhdr_loc;
					_whereMess_code = WhereMess_code;
					_whereLogically_deleted_flag = WhereLogically_deleted_flag;
					_whereClmhdr_submit_date = WhereClmhdr_submit_date;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClaim_nbr == null 
				&& WhereDoc_nbr == null 
				&& WhereClmhdr_pat_ohip_id_or_chart == null 
				&& WhereClmhdr_loc == null 
				&& WhereMess_code == null 
				&& WhereLogically_deleted_flag == null 
				&& WhereClmhdr_submit_date == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClaim_nbr ==  _whereClaim_nbr
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereClmhdr_pat_ohip_id_or_chart ==  _whereClmhdr_pat_ohip_id_or_chart
				&& WhereClmhdr_loc ==  _whereClmhdr_loc
				&& WhereMess_code ==  _whereMess_code
				&& WhereLogically_deleted_flag ==  _whereLogically_deleted_flag
				&& WhereClmhdr_submit_date ==  _whereClmhdr_submit_date
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClaim_nbr = null; 
			WhereDoc_nbr = null; 
			WhereClmhdr_pat_ohip_id_or_chart = null; 
			WhereClmhdr_loc = null; 
			WhereMess_code = null; 
			WhereLogically_deleted_flag = null; 
			WhereClmhdr_submit_date = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLAIM_NBR;
		private string _DOC_NBR;
		private string _CLMHDR_PAT_OHIP_ID_OR_CHART;
		private string _CLMHDR_LOC;
		private string _MESS_CODE;
		private string _LOGICALLY_DELETED_FLAG;
		private decimal? _CLMHDR_SUBMIT_DATE;
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
		public string CLAIM_NBR
		{
			get { return _CLAIM_NBR; }
			set
			{
				if (_CLAIM_NBR != value)
				{
					_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
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
		public string CLMHDR_LOC
		{
			get { return _CLMHDR_LOC; }
			set
			{
				if (_CLMHDR_LOC != value)
				{
					_CLMHDR_LOC = value;
					ChangeState();
				}
			}
		}
		public string MESS_CODE
		{
			get { return _MESS_CODE; }
			set
			{
				if (_MESS_CODE != value)
				{
					_MESS_CODE = value;
					ChangeState();
				}
			}
		}
		public string LOGICALLY_DELETED_FLAG
		{
			get { return _LOGICALLY_DELETED_FLAG; }
			set
			{
				if (_LOGICALLY_DELETED_FLAG != value)
				{
					_LOGICALLY_DELETED_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_SUBMIT_DATE
		{
			get { return _CLMHDR_SUBMIT_DATE; }
			set
			{
				if (_CLMHDR_SUBMIT_DATE != value)
				{
					_CLMHDR_SUBMIT_DATE = value;
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
		public string WhereClaim_nbr { get; set; }
		private string _whereClaim_nbr;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereClmhdr_pat_ohip_id_or_chart { get; set; }
		private string _whereClmhdr_pat_ohip_id_or_chart;
		public string WhereClmhdr_loc { get; set; }
		private string _whereClmhdr_loc;
		public string WhereMess_code { get; set; }
		private string _whereMess_code;
		public string WhereLogically_deleted_flag { get; set; }
		private string _whereLogically_deleted_flag;
		public decimal? WhereClmhdr_submit_date { get; set; }
		private decimal? _whereClmhdr_submit_date;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClaim_nbr;
		private string _originalDoc_nbr;
		private string _originalClmhdr_pat_ohip_id_or_chart;
		private string _originalClmhdr_loc;
		private string _originalMess_code;
		private string _originalLogically_deleted_flag;
		private decimal? _originalClmhdr_submit_date;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLAIM_NBR = _originalClaim_nbr;
			DOC_NBR = _originalDoc_nbr;
			CLMHDR_PAT_OHIP_ID_OR_CHART = _originalClmhdr_pat_ohip_id_or_chart;
			CLMHDR_LOC = _originalClmhdr_loc;
			MESS_CODE = _originalMess_code;
			LOGICALLY_DELETED_FLAG = _originalLogically_deleted_flag;
			CLMHDR_SUBMIT_DATE = _originalClmhdr_submit_date;
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
					new SqlParameter("CLAIM_NBR",CLAIM_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_REJECTED_CLAIMS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_REJECTED_CLAIMS_Purge]");
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
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("MESS_CODE", SqlNull(MESS_CODE)),
						new SqlParameter("LOGICALLY_DELETED_FLAG", SqlNull(LOGICALLY_DELETED_FLAG)),
						new SqlParameter("CLMHDR_SUBMIT_DATE", SqlNull(CLMHDR_SUBMIT_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_REJECTED_CLAIMS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						MESS_CODE = Reader["MESS_CODE"].ToString();
						LOGICALLY_DELETED_FLAG = Reader["LOGICALLY_DELETED_FLAG"].ToString();
						CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalMess_code = Reader["MESS_CODE"].ToString();
						_originalLogically_deleted_flag = Reader["LOGICALLY_DELETED_FLAG"].ToString();
						_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLAIM_NBR", SqlNull(CLAIM_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("MESS_CODE", SqlNull(MESS_CODE)),
						new SqlParameter("LOGICALLY_DELETED_FLAG", SqlNull(LOGICALLY_DELETED_FLAG)),
						new SqlParameter("CLMHDR_SUBMIT_DATE", SqlNull(CLMHDR_SUBMIT_DATE)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_REJECTED_CLAIMS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR = Reader["CLAIM_NBR"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						MESS_CODE = Reader["MESS_CODE"].ToString();
						LOGICALLY_DELETED_FLAG = Reader["LOGICALLY_DELETED_FLAG"].ToString();
						CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr = Reader["CLAIM_NBR"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalMess_code = Reader["MESS_CODE"].ToString();
						_originalLogically_deleted_flag = Reader["LOGICALLY_DELETED_FLAG"].ToString();
						_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
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