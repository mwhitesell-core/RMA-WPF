using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIMS_EXTRA : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIMS_EXTRA> Collection( Guid? rowid,
															string clmhdr_rma_clm_nbr,
															string clmhdr_ohip_clm_nbr,
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
					new SqlParameter("CLMHDR_RMA_CLM_NBR",clmhdr_rma_clm_nbr),
					new SqlParameter("CLMHDR_OHIP_CLM_NBR",clmhdr_ohip_clm_nbr),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_EXTRA_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIMS_EXTRA>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_EXTRA_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_EXTRA>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_EXTRA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_RMA_CLM_NBR = Reader["CLMHDR_RMA_CLM_NBR"].ToString(),
					CLMHDR_OHIP_CLM_NBR = Reader["CLMHDR_OHIP_CLM_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_rma_clm_nbr = Reader["CLMHDR_RMA_CLM_NBR"].ToString(),
					_originalClmhdr_ohip_clm_nbr = Reader["CLMHDR_OHIP_CLM_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_CLAIMS_EXTRA Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIMS_EXTRA> Collection(ObservableCollection<F002_CLAIMS_EXTRA>
                                                               f002ClaimsExtra = null)
        {
            if (IsSameSearch() && f002ClaimsExtra != null)
            {
                return f002ClaimsExtra;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIMS_EXTRA>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_RMA_CLM_NBR",WhereClmhdr_rma_clm_nbr),
					new SqlParameter("CLMHDR_OHIP_CLM_NBR",WhereClmhdr_ohip_clm_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_EXTRA_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_EXTRA>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_EXTRA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_RMA_CLM_NBR = Reader["CLMHDR_RMA_CLM_NBR"].ToString(),
					CLMHDR_OHIP_CLM_NBR = Reader["CLMHDR_OHIP_CLM_NBR"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_rma_clm_nbr = WhereClmhdr_rma_clm_nbr,
					_whereClmhdr_ohip_clm_nbr = WhereClmhdr_ohip_clm_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_rma_clm_nbr = Reader["CLMHDR_RMA_CLM_NBR"].ToString(),
					_originalClmhdr_ohip_clm_nbr = Reader["CLMHDR_OHIP_CLM_NBR"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_rma_clm_nbr = WhereClmhdr_rma_clm_nbr;
					_whereClmhdr_ohip_clm_nbr = WhereClmhdr_ohip_clm_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_rma_clm_nbr == null 
				&& WhereClmhdr_ohip_clm_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_rma_clm_nbr ==  _whereClmhdr_rma_clm_nbr
				&& WhereClmhdr_ohip_clm_nbr ==  _whereClmhdr_ohip_clm_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_rma_clm_nbr = null; 
			WhereClmhdr_ohip_clm_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_RMA_CLM_NBR;
		private string _CLMHDR_OHIP_CLM_NBR;
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
		public string CLMHDR_RMA_CLM_NBR
		{
			get { return _CLMHDR_RMA_CLM_NBR; }
			set
			{
				if (_CLMHDR_RMA_CLM_NBR != value)
				{
					_CLMHDR_RMA_CLM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_OHIP_CLM_NBR
		{
			get { return _CLMHDR_OHIP_CLM_NBR; }
			set
			{
				if (_CLMHDR_OHIP_CLM_NBR != value)
				{
					_CLMHDR_OHIP_CLM_NBR = value;
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
		public string WhereClmhdr_rma_clm_nbr { get; set; }
		private string _whereClmhdr_rma_clm_nbr;
		public string WhereClmhdr_ohip_clm_nbr { get; set; }
		private string _whereClmhdr_ohip_clm_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_rma_clm_nbr;
		private string _originalClmhdr_ohip_clm_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_RMA_CLM_NBR = _originalClmhdr_rma_clm_nbr;
			CLMHDR_OHIP_CLM_NBR = _originalClmhdr_ohip_clm_nbr;
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
					new SqlParameter("CLMHDR_RMA_CLM_NBR",CLMHDR_RMA_CLM_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_EXTRA_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_EXTRA_Purge]");
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
						new SqlParameter("CLMHDR_RMA_CLM_NBR", SqlNull(CLMHDR_RMA_CLM_NBR)),
						new SqlParameter("CLMHDR_OHIP_CLM_NBR", SqlNull(CLMHDR_OHIP_CLM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_EXTRA_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_RMA_CLM_NBR = Reader["CLMHDR_RMA_CLM_NBR"].ToString();
						CLMHDR_OHIP_CLM_NBR = Reader["CLMHDR_OHIP_CLM_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_rma_clm_nbr = Reader["CLMHDR_RMA_CLM_NBR"].ToString();
						_originalClmhdr_ohip_clm_nbr = Reader["CLMHDR_OHIP_CLM_NBR"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_RMA_CLM_NBR", SqlNull(CLMHDR_RMA_CLM_NBR)),
						new SqlParameter("CLMHDR_OHIP_CLM_NBR", SqlNull(CLMHDR_OHIP_CLM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_EXTRA_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_RMA_CLM_NBR = Reader["CLMHDR_RMA_CLM_NBR"].ToString();
						CLMHDR_OHIP_CLM_NBR = Reader["CLMHDR_OHIP_CLM_NBR"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_rma_clm_nbr = Reader["CLMHDR_RMA_CLM_NBR"].ToString();
						_originalClmhdr_ohip_clm_nbr = Reader["CLMHDR_OHIP_CLM_NBR"].ToString();
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