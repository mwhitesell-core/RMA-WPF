using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class SOCIAL_CONTRACT_FACTOR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<SOCIAL_CONTRACT_FACTOR> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_serv_date_frommin,
															decimal? const_serv_date_frommax,
															decimal? const_serv_date_tomin,
															decimal? const_serv_date_tomax,
															decimal? const_reduction_factormin,
															decimal? const_reduction_factormax,
															decimal? const_overpay_factormin,
															decimal? const_overpay_factormax,
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
					new SqlParameter("minCONST_REC_NBR",const_rec_nbrmin),
					new SqlParameter("maxCONST_REC_NBR",const_rec_nbrmax),
					new SqlParameter("minCONST_SERV_DATE_FROM",const_serv_date_frommin),
					new SqlParameter("maxCONST_SERV_DATE_FROM",const_serv_date_frommax),
					new SqlParameter("minCONST_SERV_DATE_TO",const_serv_date_tomin),
					new SqlParameter("maxCONST_SERV_DATE_TO",const_serv_date_tomax),
					new SqlParameter("minCONST_REDUCTION_FACTOR",const_reduction_factormin),
					new SqlParameter("maxCONST_REDUCTION_FACTOR",const_reduction_factormax),
					new SqlParameter("minCONST_OVERPAY_FACTOR",const_overpay_factormin),
					new SqlParameter("maxCONST_OVERPAY_FACTOR",const_overpay_factormax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<SOCIAL_CONTRACT_FACTOR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_Search]", parameters);
            var collection = new ObservableCollection<SOCIAL_CONTRACT_FACTOR>();

            while (Reader.Read())
            {
                collection.Add(new SOCIAL_CONTRACT_FACTOR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_SERV_DATE_FROM = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]),
					CONST_SERV_DATE_TO = ConvertDEC(Reader["CONST_SERV_DATE_TO"]),
					CONST_REDUCTION_FACTOR = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]),
					CONST_OVERPAY_FACTOR = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_serv_date_from = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]),
					_originalConst_serv_date_to = ConvertDEC(Reader["CONST_SERV_DATE_TO"]),
					_originalConst_reduction_factor = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]),
					_originalConst_overpay_factor = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public SOCIAL_CONTRACT_FACTOR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<SOCIAL_CONTRACT_FACTOR> Collection(ObservableCollection<SOCIAL_CONTRACT_FACTOR>
                                                               socialContractFactor = null)
        {
            if (IsSameSearch() && socialContractFactor != null)
            {
                return socialContractFactor;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<SOCIAL_CONTRACT_FACTOR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_SERV_DATE_FROM",WhereConst_serv_date_from),
					new SqlParameter("CONST_SERV_DATE_TO",WhereConst_serv_date_to),
					new SqlParameter("CONST_REDUCTION_FACTOR",WhereConst_reduction_factor),
					new SqlParameter("CONST_OVERPAY_FACTOR",WhereConst_overpay_factor),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_Match]", parameters);
            var collection = new ObservableCollection<SOCIAL_CONTRACT_FACTOR>();

            while (Reader.Read())
            {
                collection.Add(new SOCIAL_CONTRACT_FACTOR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_SERV_DATE_FROM = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]),
					CONST_SERV_DATE_TO = ConvertDEC(Reader["CONST_SERV_DATE_TO"]),
					CONST_REDUCTION_FACTOR = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]),
					CONST_OVERPAY_FACTOR = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_serv_date_from = WhereConst_serv_date_from,
					_whereConst_serv_date_to = WhereConst_serv_date_to,
					_whereConst_reduction_factor = WhereConst_reduction_factor,
					_whereConst_overpay_factor = WhereConst_overpay_factor,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_serv_date_from = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]),
					_originalConst_serv_date_to = ConvertDEC(Reader["CONST_SERV_DATE_TO"]),
					_originalConst_reduction_factor = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]),
					_originalConst_overpay_factor = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_serv_date_from = WhereConst_serv_date_from;
					_whereConst_serv_date_to = WhereConst_serv_date_to;
					_whereConst_reduction_factor = WhereConst_reduction_factor;
					_whereConst_overpay_factor = WhereConst_overpay_factor;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereConst_rec_nbr == null 
				&& WhereConst_serv_date_from == null 
				&& WhereConst_serv_date_to == null 
				&& WhereConst_reduction_factor == null 
				&& WhereConst_overpay_factor == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereConst_rec_nbr ==  _whereConst_rec_nbr
				&& WhereConst_serv_date_from ==  _whereConst_serv_date_from
				&& WhereConst_serv_date_to ==  _whereConst_serv_date_to
				&& WhereConst_reduction_factor ==  _whereConst_reduction_factor
				&& WhereConst_overpay_factor ==  _whereConst_overpay_factor
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_serv_date_from = null; 
			WhereConst_serv_date_to = null; 
			WhereConst_reduction_factor = null; 
			WhereConst_overpay_factor = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CONST_REC_NBR;
		private decimal? _CONST_SERV_DATE_FROM;
		private decimal? _CONST_SERV_DATE_TO;
		private decimal? _CONST_REDUCTION_FACTOR;
		private decimal? _CONST_OVERPAY_FACTOR;
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
		public decimal? CONST_REC_NBR
		{
			get { return _CONST_REC_NBR; }
			set
			{
				if (_CONST_REC_NBR != value)
				{
					_CONST_REC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_SERV_DATE_FROM
		{
			get { return _CONST_SERV_DATE_FROM; }
			set
			{
				if (_CONST_SERV_DATE_FROM != value)
				{
					_CONST_SERV_DATE_FROM = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_SERV_DATE_TO
		{
			get { return _CONST_SERV_DATE_TO; }
			set
			{
				if (_CONST_SERV_DATE_TO != value)
				{
					_CONST_SERV_DATE_TO = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_REDUCTION_FACTOR
		{
			get { return _CONST_REDUCTION_FACTOR; }
			set
			{
				if (_CONST_REDUCTION_FACTOR != value)
				{
					_CONST_REDUCTION_FACTOR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_OVERPAY_FACTOR
		{
			get { return _CONST_OVERPAY_FACTOR; }
			set
			{
				if (_CONST_OVERPAY_FACTOR != value)
				{
					_CONST_OVERPAY_FACTOR = value;
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
		public decimal? WhereConst_rec_nbr { get; set; }
		private decimal? _whereConst_rec_nbr;
		public decimal? WhereConst_serv_date_from { get; set; }
		private decimal? _whereConst_serv_date_from;
		public decimal? WhereConst_serv_date_to { get; set; }
		private decimal? _whereConst_serv_date_to;
		public decimal? WhereConst_reduction_factor { get; set; }
		private decimal? _whereConst_reduction_factor;
		public decimal? WhereConst_overpay_factor { get; set; }
		private decimal? _whereConst_overpay_factor;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_serv_date_from;
		private decimal? _originalConst_serv_date_to;
		private decimal? _originalConst_reduction_factor;
		private decimal? _originalConst_overpay_factor;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_SERV_DATE_FROM = _originalConst_serv_date_from;
			CONST_SERV_DATE_TO = _originalConst_serv_date_to;
			CONST_REDUCTION_FACTOR = _originalConst_reduction_factor;
			CONST_OVERPAY_FACTOR = _originalConst_overpay_factor;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_Purge]");
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
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("CONST_SERV_DATE_FROM", SqlNull(CONST_SERV_DATE_FROM)),
						new SqlParameter("CONST_SERV_DATE_TO", SqlNull(CONST_SERV_DATE_TO)),
						new SqlParameter("CONST_REDUCTION_FACTOR", SqlNull(CONST_REDUCTION_FACTOR)),
						new SqlParameter("CONST_OVERPAY_FACTOR", SqlNull(CONST_OVERPAY_FACTOR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_SERV_DATE_FROM = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]);
						CONST_SERV_DATE_TO = ConvertDEC(Reader["CONST_SERV_DATE_TO"]);
						CONST_REDUCTION_FACTOR = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]);
						CONST_OVERPAY_FACTOR = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_serv_date_from = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]);
						_originalConst_serv_date_to = ConvertDEC(Reader["CONST_SERV_DATE_TO"]);
						_originalConst_reduction_factor = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]);
						_originalConst_overpay_factor = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("CONST_SERV_DATE_FROM", SqlNull(CONST_SERV_DATE_FROM)),
						new SqlParameter("CONST_SERV_DATE_TO", SqlNull(CONST_SERV_DATE_TO)),
						new SqlParameter("CONST_REDUCTION_FACTOR", SqlNull(CONST_REDUCTION_FACTOR)),
						new SqlParameter("CONST_OVERPAY_FACTOR", SqlNull(CONST_OVERPAY_FACTOR)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_SOCIAL_CONTRACT_FACTOR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_SERV_DATE_FROM = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]);
						CONST_SERV_DATE_TO = ConvertDEC(Reader["CONST_SERV_DATE_TO"]);
						CONST_REDUCTION_FACTOR = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]);
						CONST_OVERPAY_FACTOR = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_serv_date_from = ConvertDEC(Reader["CONST_SERV_DATE_FROM"]);
						_originalConst_serv_date_to = ConvertDEC(Reader["CONST_SERV_DATE_TO"]);
						_originalConst_reduction_factor = ConvertDEC(Reader["CONST_REDUCTION_FACTOR"]);
						_originalConst_overpay_factor = ConvertDEC(Reader["CONST_OVERPAY_FACTOR"]);
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