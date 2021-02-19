using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class AFP_A3C_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<AFP_A3C_FILE> Collection( Guid? rowid,
															string afp_transaction_id,
															string afp_record_id,
															string filler_1,
															string afp_payment_sign,
															decimal? afp_payment_amtmin,
															decimal? afp_payment_amtmax,
															string filler_3,
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
					new SqlParameter("AFP_TRANSACTION_ID",afp_transaction_id),
					new SqlParameter("AFP_RECORD_ID",afp_record_id),
					new SqlParameter("FILLER_1",filler_1),
					new SqlParameter("AFP_PAYMENT_SIGN",afp_payment_sign),
					new SqlParameter("minAFP_PAYMENT_AMT",afp_payment_amtmin),
					new SqlParameter("maxAFP_PAYMENT_AMT",afp_payment_amtmax),
					new SqlParameter("FILLER_3",filler_3),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A3C_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<AFP_A3C_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A3C_FILE_Search]", parameters);
            var collection = new ObservableCollection<AFP_A3C_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A3C_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public AFP_A3C_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<AFP_A3C_FILE> Collection(ObservableCollection<AFP_A3C_FILE>
                                                               afpA3cFile = null)
        {
            if (IsSameSearch() && afpA3cFile != null)
            {
                return afpA3cFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<AFP_A3C_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("AFP_TRANSACTION_ID",WhereAfp_transaction_id),
					new SqlParameter("AFP_RECORD_ID",WhereAfp_record_id),
					new SqlParameter("FILLER_1",WhereFiller_1),
					new SqlParameter("AFP_PAYMENT_SIGN",WhereAfp_payment_sign),
					new SqlParameter("AFP_PAYMENT_AMT",WhereAfp_payment_amt),
					new SqlParameter("FILLER_3",WhereFiller_3),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A3C_FILE_Match]", parameters);
            var collection = new ObservableCollection<AFP_A3C_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A3C_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAfp_transaction_id = WhereAfp_transaction_id,
					_whereAfp_record_id = WhereAfp_record_id,
					_whereFiller_1 = WhereFiller_1,
					_whereAfp_payment_sign = WhereAfp_payment_sign,
					_whereAfp_payment_amt = WhereAfp_payment_amt,
					_whereFiller_3 = WhereFiller_3,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAfp_transaction_id = WhereAfp_transaction_id;
					_whereAfp_record_id = WhereAfp_record_id;
					_whereFiller_1 = WhereFiller_1;
					_whereAfp_payment_sign = WhereAfp_payment_sign;
					_whereAfp_payment_amt = WhereAfp_payment_amt;
					_whereFiller_3 = WhereFiller_3;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereAfp_transaction_id == null 
				&& WhereAfp_record_id == null 
				&& WhereFiller_1 == null 
				&& WhereAfp_payment_sign == null 
				&& WhereAfp_payment_amt == null 
				&& WhereFiller_3 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereAfp_transaction_id ==  _whereAfp_transaction_id
				&& WhereAfp_record_id ==  _whereAfp_record_id
				&& WhereFiller_1 ==  _whereFiller_1
				&& WhereAfp_payment_sign ==  _whereAfp_payment_sign
				&& WhereAfp_payment_amt ==  _whereAfp_payment_amt
				&& WhereFiller_3 ==  _whereFiller_3
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereAfp_transaction_id = null; 
			WhereAfp_record_id = null; 
			WhereFiller_1 = null; 
			WhereAfp_payment_sign = null; 
			WhereAfp_payment_amt = null; 
			WhereFiller_3 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _AFP_TRANSACTION_ID;
		private string _AFP_RECORD_ID;
		private string _FILLER_1;
		private string _AFP_PAYMENT_SIGN;
		private decimal? _AFP_PAYMENT_AMT;
		private string _FILLER_3;
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
		public string AFP_TRANSACTION_ID
		{
			get { return _AFP_TRANSACTION_ID; }
			set
			{
				if (_AFP_TRANSACTION_ID != value)
				{
					_AFP_TRANSACTION_ID = value;
					ChangeState();
				}
			}
		}
		public string AFP_RECORD_ID
		{
			get { return _AFP_RECORD_ID; }
			set
			{
				if (_AFP_RECORD_ID != value)
				{
					_AFP_RECORD_ID = value;
					ChangeState();
				}
			}
		}
		public string FILLER_1
		{
			get { return _FILLER_1; }
			set
			{
				if (_FILLER_1 != value)
				{
					_FILLER_1 = value;
					ChangeState();
				}
			}
		}
		public string AFP_PAYMENT_SIGN
		{
			get { return _AFP_PAYMENT_SIGN; }
			set
			{
				if (_AFP_PAYMENT_SIGN != value)
				{
					_AFP_PAYMENT_SIGN = value;
					ChangeState();
				}
			}
		}
		public decimal? AFP_PAYMENT_AMT
		{
			get { return _AFP_PAYMENT_AMT; }
			set
			{
				if (_AFP_PAYMENT_AMT != value)
				{
					_AFP_PAYMENT_AMT = value;
					ChangeState();
				}
			}
		}
		public string FILLER_3
		{
			get { return _FILLER_3; }
			set
			{
				if (_FILLER_3 != value)
				{
					_FILLER_3 = value;
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
		public string WhereAfp_transaction_id { get; set; }
		private string _whereAfp_transaction_id;
		public string WhereAfp_record_id { get; set; }
		private string _whereAfp_record_id;
		public string WhereFiller_1 { get; set; }
		private string _whereFiller_1;
		public string WhereAfp_payment_sign { get; set; }
		private string _whereAfp_payment_sign;
		public decimal? WhereAfp_payment_amt { get; set; }
		private decimal? _whereAfp_payment_amt;
		public string WhereFiller_3 { get; set; }
		private string _whereFiller_3;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalAfp_transaction_id;
		private string _originalAfp_record_id;
		private string _originalFiller_1;
		private string _originalAfp_payment_sign;
		private decimal? _originalAfp_payment_amt;
		private string _originalFiller_3;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			AFP_TRANSACTION_ID = _originalAfp_transaction_id;
			AFP_RECORD_ID = _originalAfp_record_id;
			FILLER_1 = _originalFiller_1;
			AFP_PAYMENT_SIGN = _originalAfp_payment_sign;
			AFP_PAYMENT_AMT = _originalAfp_payment_amt;
			FILLER_3 = _originalFiller_3;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A3C_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A3C_FILE_Purge]");
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
						new SqlParameter("AFP_TRANSACTION_ID", SqlNull(AFP_TRANSACTION_ID)),
						new SqlParameter("AFP_RECORD_ID", SqlNull(AFP_RECORD_ID)),
						new SqlParameter("FILLER_1", SqlNull(FILLER_1)),
						new SqlParameter("AFP_PAYMENT_SIGN", SqlNull(AFP_PAYMENT_SIGN)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A3C_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalFiller_3 = Reader["FILLER_3"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("AFP_TRANSACTION_ID", SqlNull(AFP_TRANSACTION_ID)),
						new SqlParameter("AFP_RECORD_ID", SqlNull(AFP_RECORD_ID)),
						new SqlParameter("FILLER_1", SqlNull(FILLER_1)),
						new SqlParameter("AFP_PAYMENT_SIGN", SqlNull(AFP_PAYMENT_SIGN)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A3C_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalFiller_3 = Reader["FILLER_3"].ToString();
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