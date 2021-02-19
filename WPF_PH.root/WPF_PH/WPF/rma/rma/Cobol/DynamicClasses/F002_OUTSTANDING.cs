using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_OUTSTANDING : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_OUTSTANDING> Collection( Guid? rowid,
															string key_clm_type,
															string key_clm_batch_nbr,
															decimal? key_clm_claim_nbrmin,
															decimal? key_clm_claim_nbrmax,
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
					new SqlParameter("KEY_CLM_TYPE",key_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR",key_clm_batch_nbr),
					new SqlParameter("minKEY_CLM_CLAIM_NBR",key_clm_claim_nbrmin),
					new SqlParameter("maxKEY_CLM_CLAIM_NBR",key_clm_claim_nbrmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_OUTSTANDING_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_OUTSTANDING>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_OUTSTANDING_Search]", parameters);
            var collection = new ObservableCollection<F002_OUTSTANDING>();

            while (Reader.Read())
            {
                collection.Add(new F002_OUTSTANDING
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_OUTSTANDING Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_OUTSTANDING> Collection(ObservableCollection<F002_OUTSTANDING>
                                                               f002Outstanding = null)
        {
            if (IsSameSearch() && f002Outstanding != null)
            {
                return f002Outstanding;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_OUTSTANDING>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("KEY_CLM_TYPE",WhereKey_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR",WhereKey_clm_batch_nbr),
					new SqlParameter("KEY_CLM_CLAIM_NBR",WhereKey_clm_claim_nbr),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_OUTSTANDING_Match]", parameters);
            var collection = new ObservableCollection<F002_OUTSTANDING>();

            while (Reader.Read())
            {
                collection.Add(new F002_OUTSTANDING
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereKey_clm_type = WhereKey_clm_type,
					_whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
					_whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereKey_clm_type = WhereKey_clm_type;
					_whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr;
					_whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereKey_clm_type == null 
				&& WhereKey_clm_batch_nbr == null 
				&& WhereKey_clm_claim_nbr == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereKey_clm_type ==  _whereKey_clm_type
				&& WhereKey_clm_batch_nbr ==  _whereKey_clm_batch_nbr
				&& WhereKey_clm_claim_nbr ==  _whereKey_clm_claim_nbr
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereKey_clm_type = null; 
			WhereKey_clm_batch_nbr = null; 
			WhereKey_clm_claim_nbr = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _KEY_CLM_TYPE;
		private string _KEY_CLM_BATCH_NBR;
		private decimal? _KEY_CLM_CLAIM_NBR;
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
		public string KEY_CLM_TYPE
		{
			get { return _KEY_CLM_TYPE; }
			set
			{
				if (_KEY_CLM_TYPE != value)
				{
					_KEY_CLM_TYPE = value;
					ChangeState();
				}
			}
		}
		public string KEY_CLM_BATCH_NBR
		{
			get { return _KEY_CLM_BATCH_NBR; }
			set
			{
				if (_KEY_CLM_BATCH_NBR != value)
				{
					_KEY_CLM_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? KEY_CLM_CLAIM_NBR
		{
			get { return _KEY_CLM_CLAIM_NBR; }
			set
			{
				if (_KEY_CLM_CLAIM_NBR != value)
				{
					_KEY_CLM_CLAIM_NBR = value;
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
		public string WhereKey_clm_type { get; set; }
		private string _whereKey_clm_type;
		public string WhereKey_clm_batch_nbr { get; set; }
		private string _whereKey_clm_batch_nbr;
		public decimal? WhereKey_clm_claim_nbr { get; set; }
		private decimal? _whereKey_clm_claim_nbr;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalKey_clm_type;
		private string _originalKey_clm_batch_nbr;
		private decimal? _originalKey_clm_claim_nbr;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			KEY_CLM_TYPE = _originalKey_clm_type;
			KEY_CLM_BATCH_NBR = _originalKey_clm_batch_nbr;
			KEY_CLM_CLAIM_NBR = _originalKey_clm_claim_nbr;
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
					new SqlParameter("KEY_CLM_TYPE",KEY_CLM_TYPE),
					new SqlParameter("KEY_CLM_BATCH_NBR",KEY_CLM_BATCH_NBR),
					new SqlParameter("KEY_CLM_CLAIM_NBR",KEY_CLM_CLAIM_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_OUTSTANDING_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_OUTSTANDING_Purge]");
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
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR", SqlNull(KEY_CLM_BATCH_NBR)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_OUTSTANDING_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString();
						_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR", SqlNull(KEY_CLM_BATCH_NBR)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_OUTSTANDING_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString();
						_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
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