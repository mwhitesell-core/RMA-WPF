using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F071_CLIENT_RMA_CLAIM_NBR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR> Collection( Guid? rowid,
															string claim_nbr_client,
															decimal? clinic_nbrmin,
															decimal? clinic_nbrmax,
															string claim_nbr_rma,
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
					new SqlParameter("CLAIM_NBR_CLIENT",claim_nbr_client),
					new SqlParameter("minCLINIC_NBR",clinic_nbrmin),
					new SqlParameter("maxCLINIC_NBR",clinic_nbrmax),
					new SqlParameter("CLAIM_NBR_RMA",claim_nbr_rma),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_Search]", parameters);
            var collection = new ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F071_CLIENT_RMA_CLAIM_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR_CLIENT = Reader["CLAIM_NBR_CLIENT"].ToString(),
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					CLAIM_NBR_RMA = Reader["CLAIM_NBR_RMA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr_client = Reader["CLAIM_NBR_CLIENT"].ToString(),
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalClaim_nbr_rma = Reader["CLAIM_NBR_RMA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F071_CLIENT_RMA_CLAIM_NBR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR> Collection(ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR>
                                                               f071ClientRmaClaimNbr = null)
        {
            if (IsSameSearch() && f071ClientRmaClaimNbr != null)
            {
                return f071ClientRmaClaimNbr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLAIM_NBR_CLIENT",WhereClaim_nbr_client),
					new SqlParameter("CLINIC_NBR",WhereClinic_nbr),
					new SqlParameter("CLAIM_NBR_RMA",WhereClaim_nbr_rma),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_Match]", parameters);
            var collection = new ObservableCollection<F071_CLIENT_RMA_CLAIM_NBR>();

            while (Reader.Read())
            {
                collection.Add(new F071_CLIENT_RMA_CLAIM_NBR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_NBR_CLIENT = Reader["CLAIM_NBR_CLIENT"].ToString(),
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					CLAIM_NBR_RMA = Reader["CLAIM_NBR_RMA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClaim_nbr_client = WhereClaim_nbr_client,
					_whereClinic_nbr = WhereClinic_nbr,
					_whereClaim_nbr_rma = WhereClaim_nbr_rma,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_nbr_client = Reader["CLAIM_NBR_CLIENT"].ToString(),
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalClaim_nbr_rma = Reader["CLAIM_NBR_RMA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClaim_nbr_client = WhereClaim_nbr_client;
					_whereClinic_nbr = WhereClinic_nbr;
					_whereClaim_nbr_rma = WhereClaim_nbr_rma;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClaim_nbr_client == null 
				&& WhereClinic_nbr == null 
				&& WhereClaim_nbr_rma == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClaim_nbr_client ==  _whereClaim_nbr_client
				&& WhereClinic_nbr ==  _whereClinic_nbr
				&& WhereClaim_nbr_rma ==  _whereClaim_nbr_rma
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClaim_nbr_client = null; 
			WhereClinic_nbr = null; 
			WhereClaim_nbr_rma = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLAIM_NBR_CLIENT;
		private decimal? _CLINIC_NBR;
		private string _CLAIM_NBR_RMA;
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
		public string CLAIM_NBR_CLIENT
		{
			get { return _CLAIM_NBR_CLIENT; }
			set
			{
				if (_CLAIM_NBR_CLIENT != value)
				{
					_CLAIM_NBR_CLIENT = value;
					ChangeState();
				}
			}
		}
		public decimal? CLINIC_NBR
		{
			get { return _CLINIC_NBR; }
			set
			{
				if (_CLINIC_NBR != value)
				{
					_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLAIM_NBR_RMA
		{
			get { return _CLAIM_NBR_RMA; }
			set
			{
				if (_CLAIM_NBR_RMA != value)
				{
					_CLAIM_NBR_RMA = value;
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
		public string WhereClaim_nbr_client { get; set; }
		private string _whereClaim_nbr_client;
		public decimal? WhereClinic_nbr { get; set; }
		private decimal? _whereClinic_nbr;
		public string WhereClaim_nbr_rma { get; set; }
		private string _whereClaim_nbr_rma;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClaim_nbr_client;
		private decimal? _originalClinic_nbr;
		private string _originalClaim_nbr_rma;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLAIM_NBR_CLIENT = _originalClaim_nbr_client;
			CLINIC_NBR = _originalClinic_nbr;
			CLAIM_NBR_RMA = _originalClaim_nbr_rma;
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
					new SqlParameter("CLAIM_NBR_CLIENT",CLAIM_NBR_CLIENT)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_Purge]");
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
						new SqlParameter("CLAIM_NBR_CLIENT", SqlNull(CLAIM_NBR_CLIENT)),
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("CLAIM_NBR_RMA", SqlNull(CLAIM_NBR_RMA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR_CLIENT = Reader["CLAIM_NBR_CLIENT"].ToString();
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						CLAIM_NBR_RMA = Reader["CLAIM_NBR_RMA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr_client = Reader["CLAIM_NBR_CLIENT"].ToString();
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalClaim_nbr_rma = Reader["CLAIM_NBR_RMA"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLAIM_NBR_CLIENT", SqlNull(CLAIM_NBR_CLIENT)),
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("CLAIM_NBR_RMA", SqlNull(CLAIM_NBR_RMA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F071_CLIENT_RMA_CLAIM_NBR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_NBR_CLIENT = Reader["CLAIM_NBR_CLIENT"].ToString();
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						CLAIM_NBR_RMA = Reader["CLAIM_NBR_RMA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_nbr_client = Reader["CLAIM_NBR_CLIENT"].ToString();
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalClaim_nbr_rma = Reader["CLAIM_NBR_RMA"].ToString();
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