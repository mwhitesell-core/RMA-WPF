using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class PART_ADJ_BATCH : BaseTable
    {
        #region Retrieve

        public ObservableCollection<PART_ADJ_BATCH> Collection( Guid? rowid,
															string part_adj_claim_id,
															decimal? part_adj_balmin,
															decimal? part_adj_balmax,
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
					new SqlParameter("PART_ADJ_CLAIM_ID",part_adj_claim_id),
					new SqlParameter("minPART_ADJ_BAL",part_adj_balmin),
					new SqlParameter("maxPART_ADJ_BAL",part_adj_balmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_PART_ADJ_BATCH_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<PART_ADJ_BATCH>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_PART_ADJ_BATCH_Search]", parameters);
            var collection = new ObservableCollection<PART_ADJ_BATCH>();

            while (Reader.Read())
            {
                collection.Add(new PART_ADJ_BATCH
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_ADJ_CLAIM_ID = Reader["PART_ADJ_CLAIM_ID"].ToString(),
					PART_ADJ_BAL = ConvertDEC(Reader["PART_ADJ_BAL"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_adj_claim_id = Reader["PART_ADJ_CLAIM_ID"].ToString(),
					_originalPart_adj_bal = ConvertDEC(Reader["PART_ADJ_BAL"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public PART_ADJ_BATCH Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<PART_ADJ_BATCH> Collection(ObservableCollection<PART_ADJ_BATCH>
                                                               partAdjBatch = null)
        {
            if (IsSameSearch() && partAdjBatch != null)
            {
                return partAdjBatch;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<PART_ADJ_BATCH>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PART_ADJ_CLAIM_ID",WherePart_adj_claim_id),
					new SqlParameter("PART_ADJ_BAL",WherePart_adj_bal),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_PART_ADJ_BATCH_Match]", parameters);
            var collection = new ObservableCollection<PART_ADJ_BATCH>();

            while (Reader.Read())
            {
                collection.Add(new PART_ADJ_BATCH
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PART_ADJ_CLAIM_ID = Reader["PART_ADJ_CLAIM_ID"].ToString(),
					PART_ADJ_BAL = ConvertDEC(Reader["PART_ADJ_BAL"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePart_adj_claim_id = WherePart_adj_claim_id,
					_wherePart_adj_bal = WherePart_adj_bal,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPart_adj_claim_id = Reader["PART_ADJ_CLAIM_ID"].ToString(),
					_originalPart_adj_bal = ConvertDEC(Reader["PART_ADJ_BAL"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePart_adj_claim_id = WherePart_adj_claim_id;
					_wherePart_adj_bal = WherePart_adj_bal;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePart_adj_claim_id == null 
				&& WherePart_adj_bal == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePart_adj_claim_id ==  _wherePart_adj_claim_id
				&& WherePart_adj_bal ==  _wherePart_adj_bal
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePart_adj_claim_id = null; 
			WherePart_adj_bal = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _PART_ADJ_CLAIM_ID;
		private decimal? _PART_ADJ_BAL;
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
		public string PART_ADJ_CLAIM_ID
		{
			get { return _PART_ADJ_CLAIM_ID; }
			set
			{
				if (_PART_ADJ_CLAIM_ID != value)
				{
					_PART_ADJ_CLAIM_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? PART_ADJ_BAL
		{
			get { return _PART_ADJ_BAL; }
			set
			{
				if (_PART_ADJ_BAL != value)
				{
					_PART_ADJ_BAL = value;
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
		public string WherePart_adj_claim_id { get; set; }
		private string _wherePart_adj_claim_id;
		public decimal? WherePart_adj_bal { get; set; }
		private decimal? _wherePart_adj_bal;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalPart_adj_claim_id;
		private decimal? _originalPart_adj_bal;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PART_ADJ_CLAIM_ID = _originalPart_adj_claim_id;
			PART_ADJ_BAL = _originalPart_adj_bal;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_ADJ_BATCH_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_PART_ADJ_BATCH_Purge]");
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
						new SqlParameter("PART_ADJ_CLAIM_ID", SqlNull(PART_ADJ_CLAIM_ID)),
						new SqlParameter("PART_ADJ_BAL", SqlNull(PART_ADJ_BAL)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_ADJ_BATCH_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_ADJ_CLAIM_ID = Reader["PART_ADJ_CLAIM_ID"].ToString();
						PART_ADJ_BAL = ConvertDEC(Reader["PART_ADJ_BAL"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_adj_claim_id = Reader["PART_ADJ_CLAIM_ID"].ToString();
						_originalPart_adj_bal = ConvertDEC(Reader["PART_ADJ_BAL"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PART_ADJ_CLAIM_ID", SqlNull(PART_ADJ_CLAIM_ID)),
						new SqlParameter("PART_ADJ_BAL", SqlNull(PART_ADJ_BAL)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_PART_ADJ_BATCH_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PART_ADJ_CLAIM_ID = Reader["PART_ADJ_CLAIM_ID"].ToString();
						PART_ADJ_BAL = ConvertDEC(Reader["PART_ADJ_BAL"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPart_adj_claim_id = Reader["PART_ADJ_CLAIM_ID"].ToString();
						_originalPart_adj_bal = ConvertDEC(Reader["PART_ADJ_BAL"]);
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