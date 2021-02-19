using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class AFP_A2S_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<AFP_A2S_FILE> Collection( Guid? rowid,
															string afp_transaction_id,
															string afp_record_id,
															string filler_1,
															string doc_afp_paym_group,
															string doc_afp_paym_solo,
															string afp_solo_name,
															string afp_conversion_sign,
															decimal? afp_conversion_amtmin,
															decimal? afp_conversion_amtmax,
															decimal? afp_payment_percentagemin,
															decimal? afp_payment_percentagemax,
															string afp_submission_sign,
															decimal? afp_submission_amtmin,
															decimal? afp_submission_amtmax,
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
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("DOC_AFP_PAYM_SOLO",doc_afp_paym_solo),
					new SqlParameter("AFP_SOLO_NAME",afp_solo_name),
					new SqlParameter("AFP_CONVERSION_SIGN",afp_conversion_sign),
					new SqlParameter("minAFP_CONVERSION_AMT",afp_conversion_amtmin),
					new SqlParameter("maxAFP_CONVERSION_AMT",afp_conversion_amtmax),
					new SqlParameter("minAFP_PAYMENT_PERCENTAGE",afp_payment_percentagemin),
					new SqlParameter("maxAFP_PAYMENT_PERCENTAGE",afp_payment_percentagemax),
					new SqlParameter("AFP_SUBMISSION_SIGN",afp_submission_sign),
					new SqlParameter("minAFP_SUBMISSION_AMT",afp_submission_amtmin),
					new SqlParameter("maxAFP_SUBMISSION_AMT",afp_submission_amtmax),
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
                Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A2S_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<AFP_A2S_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A2S_FILE_Search]", parameters);
            var collection = new ObservableCollection<AFP_A2S_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A2S_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_AFP_PAYM_SOLO = Reader["DOC_AFP_PAYM_SOLO"].ToString(),
					AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString(),
					AFP_CONVERSION_SIGN = Reader["AFP_CONVERSION_SIGN"].ToString(),
					AFP_CONVERSION_AMT = ConvertDEC(Reader["AFP_CONVERSION_AMT"]),
					AFP_PAYMENT_PERCENTAGE = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]),
					AFP_SUBMISSION_SIGN = Reader["AFP_SUBMISSION_SIGN"].ToString(),
					AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_afp_paym_solo = Reader["DOC_AFP_PAYM_SOLO"].ToString(),
					_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString(),
					_originalAfp_conversion_sign = Reader["AFP_CONVERSION_SIGN"].ToString(),
					_originalAfp_conversion_amt = ConvertDEC(Reader["AFP_CONVERSION_AMT"]),
					_originalAfp_payment_percentage = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]),
					_originalAfp_submission_sign = Reader["AFP_SUBMISSION_SIGN"].ToString(),
					_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public AFP_A2S_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<AFP_A2S_FILE> Collection(ObservableCollection<AFP_A2S_FILE>
                                                               afpA2sFile = null)
        {
            if (IsSameSearch() && afpA2sFile != null)
            {
                return afpA2sFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<AFP_A2S_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("AFP_TRANSACTION_ID",WhereAfp_transaction_id),
					new SqlParameter("AFP_RECORD_ID",WhereAfp_record_id),
					new SqlParameter("FILLER_1",WhereFiller_1),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("DOC_AFP_PAYM_SOLO",WhereDoc_afp_paym_solo),
					new SqlParameter("AFP_SOLO_NAME",WhereAfp_solo_name),
					new SqlParameter("AFP_CONVERSION_SIGN",WhereAfp_conversion_sign),
					new SqlParameter("AFP_CONVERSION_AMT",WhereAfp_conversion_amt),
					new SqlParameter("AFP_PAYMENT_PERCENTAGE",WhereAfp_payment_percentage),
					new SqlParameter("AFP_SUBMISSION_SIGN",WhereAfp_submission_sign),
					new SqlParameter("AFP_SUBMISSION_AMT",WhereAfp_submission_amt),
					new SqlParameter("FILLER_3",WhereFiller_3),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A2S_FILE_Match]", parameters);
            var collection = new ObservableCollection<AFP_A2S_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A2S_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_AFP_PAYM_SOLO = Reader["DOC_AFP_PAYM_SOLO"].ToString(),
					AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString(),
					AFP_CONVERSION_SIGN = Reader["AFP_CONVERSION_SIGN"].ToString(),
					AFP_CONVERSION_AMT = ConvertDEC(Reader["AFP_CONVERSION_AMT"]),
					AFP_PAYMENT_PERCENTAGE = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]),
					AFP_SUBMISSION_SIGN = Reader["AFP_SUBMISSION_SIGN"].ToString(),
					AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAfp_transaction_id = WhereAfp_transaction_id,
					_whereAfp_record_id = WhereAfp_record_id,
					_whereFiller_1 = WhereFiller_1,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereDoc_afp_paym_solo = WhereDoc_afp_paym_solo,
					_whereAfp_solo_name = WhereAfp_solo_name,
					_whereAfp_conversion_sign = WhereAfp_conversion_sign,
					_whereAfp_conversion_amt = WhereAfp_conversion_amt,
					_whereAfp_payment_percentage = WhereAfp_payment_percentage,
					_whereAfp_submission_sign = WhereAfp_submission_sign,
					_whereAfp_submission_amt = WhereAfp_submission_amt,
					_whereFiller_3 = WhereFiller_3,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_afp_paym_solo = Reader["DOC_AFP_PAYM_SOLO"].ToString(),
					_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString(),
					_originalAfp_conversion_sign = Reader["AFP_CONVERSION_SIGN"].ToString(),
					_originalAfp_conversion_amt = ConvertDEC(Reader["AFP_CONVERSION_AMT"]),
					_originalAfp_payment_percentage = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]),
					_originalAfp_submission_sign = Reader["AFP_SUBMISSION_SIGN"].ToString(),
					_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAfp_transaction_id = WhereAfp_transaction_id;
					_whereAfp_record_id = WhereAfp_record_id;
					_whereFiller_1 = WhereFiller_1;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereDoc_afp_paym_solo = WhereDoc_afp_paym_solo;
					_whereAfp_solo_name = WhereAfp_solo_name;
					_whereAfp_conversion_sign = WhereAfp_conversion_sign;
					_whereAfp_conversion_amt = WhereAfp_conversion_amt;
					_whereAfp_payment_percentage = WhereAfp_payment_percentage;
					_whereAfp_submission_sign = WhereAfp_submission_sign;
					_whereAfp_submission_amt = WhereAfp_submission_amt;
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
				&& WhereDoc_afp_paym_group == null 
				&& WhereDoc_afp_paym_solo == null 
				&& WhereAfp_solo_name == null 
				&& WhereAfp_conversion_sign == null 
				&& WhereAfp_conversion_amt == null 
				&& WhereAfp_payment_percentage == null 
				&& WhereAfp_submission_sign == null 
				&& WhereAfp_submission_amt == null 
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
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereDoc_afp_paym_solo ==  _whereDoc_afp_paym_solo
				&& WhereAfp_solo_name ==  _whereAfp_solo_name
				&& WhereAfp_conversion_sign ==  _whereAfp_conversion_sign
				&& WhereAfp_conversion_amt ==  _whereAfp_conversion_amt
				&& WhereAfp_payment_percentage ==  _whereAfp_payment_percentage
				&& WhereAfp_submission_sign ==  _whereAfp_submission_sign
				&& WhereAfp_submission_amt ==  _whereAfp_submission_amt
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
			WhereDoc_afp_paym_group = null; 
			WhereDoc_afp_paym_solo = null; 
			WhereAfp_solo_name = null; 
			WhereAfp_conversion_sign = null; 
			WhereAfp_conversion_amt = null; 
			WhereAfp_payment_percentage = null; 
			WhereAfp_submission_sign = null; 
			WhereAfp_submission_amt = null; 
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
		private string _DOC_AFP_PAYM_GROUP;
		private string _DOC_AFP_PAYM_SOLO;
		private string _AFP_SOLO_NAME;
		private string _AFP_CONVERSION_SIGN;
		private decimal? _AFP_CONVERSION_AMT;
		private decimal? _AFP_PAYMENT_PERCENTAGE;
		private string _AFP_SUBMISSION_SIGN;
		private decimal? _AFP_SUBMISSION_AMT;
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
		public string DOC_AFP_PAYM_GROUP
		{
			get { return _DOC_AFP_PAYM_GROUP; }
			set
			{
				if (_DOC_AFP_PAYM_GROUP != value)
				{
					_DOC_AFP_PAYM_GROUP = value;
					ChangeState();
				}
			}
		}
		public string DOC_AFP_PAYM_SOLO
		{
			get { return _DOC_AFP_PAYM_SOLO; }
			set
			{
				if (_DOC_AFP_PAYM_SOLO != value)
				{
					_DOC_AFP_PAYM_SOLO = value;
					ChangeState();
				}
			}
		}
		public string AFP_SOLO_NAME
		{
			get { return _AFP_SOLO_NAME; }
			set
			{
				if (_AFP_SOLO_NAME != value)
				{
					_AFP_SOLO_NAME = value;
					ChangeState();
				}
			}
		}
		public string AFP_CONVERSION_SIGN
		{
			get { return _AFP_CONVERSION_SIGN; }
			set
			{
				if (_AFP_CONVERSION_SIGN != value)
				{
					_AFP_CONVERSION_SIGN = value;
					ChangeState();
				}
			}
		}
		public decimal? AFP_CONVERSION_AMT
		{
			get { return _AFP_CONVERSION_AMT; }
			set
			{
				if (_AFP_CONVERSION_AMT != value)
				{
					_AFP_CONVERSION_AMT = value;
					ChangeState();
				}
			}
		}
		public decimal? AFP_PAYMENT_PERCENTAGE
		{
			get { return _AFP_PAYMENT_PERCENTAGE; }
			set
			{
				if (_AFP_PAYMENT_PERCENTAGE != value)
				{
					_AFP_PAYMENT_PERCENTAGE = value;
					ChangeState();
				}
			}
		}
		public string AFP_SUBMISSION_SIGN
		{
			get { return _AFP_SUBMISSION_SIGN; }
			set
			{
				if (_AFP_SUBMISSION_SIGN != value)
				{
					_AFP_SUBMISSION_SIGN = value;
					ChangeState();
				}
			}
		}
		public decimal? AFP_SUBMISSION_AMT
		{
			get { return _AFP_SUBMISSION_AMT; }
			set
			{
				if (_AFP_SUBMISSION_AMT != value)
				{
					_AFP_SUBMISSION_AMT = value;
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
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public string WhereDoc_afp_paym_solo { get; set; }
		private string _whereDoc_afp_paym_solo;
		public string WhereAfp_solo_name { get; set; }
		private string _whereAfp_solo_name;
		public string WhereAfp_conversion_sign { get; set; }
		private string _whereAfp_conversion_sign;
		public decimal? WhereAfp_conversion_amt { get; set; }
		private decimal? _whereAfp_conversion_amt;
		public decimal? WhereAfp_payment_percentage { get; set; }
		private decimal? _whereAfp_payment_percentage;
		public string WhereAfp_submission_sign { get; set; }
		private string _whereAfp_submission_sign;
		public decimal? WhereAfp_submission_amt { get; set; }
		private decimal? _whereAfp_submission_amt;
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
		private string _originalDoc_afp_paym_group;
		private string _originalDoc_afp_paym_solo;
		private string _originalAfp_solo_name;
		private string _originalAfp_conversion_sign;
		private decimal? _originalAfp_conversion_amt;
		private decimal? _originalAfp_payment_percentage;
		private string _originalAfp_submission_sign;
		private decimal? _originalAfp_submission_amt;
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
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			DOC_AFP_PAYM_SOLO = _originalDoc_afp_paym_solo;
			AFP_SOLO_NAME = _originalAfp_solo_name;
			AFP_CONVERSION_SIGN = _originalAfp_conversion_sign;
			AFP_CONVERSION_AMT = _originalAfp_conversion_amt;
			AFP_PAYMENT_PERCENTAGE = _originalAfp_payment_percentage;
			AFP_SUBMISSION_SIGN = _originalAfp_submission_sign;
			AFP_SUBMISSION_AMT = _originalAfp_submission_amt;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A2S_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A2S_FILE_Purge]");
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
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_AFP_PAYM_SOLO", SqlNull(DOC_AFP_PAYM_SOLO)),
						new SqlParameter("AFP_SOLO_NAME", SqlNull(AFP_SOLO_NAME)),
						new SqlParameter("AFP_CONVERSION_SIGN", SqlNull(AFP_CONVERSION_SIGN)),
						new SqlParameter("AFP_CONVERSION_AMT", SqlNull(AFP_CONVERSION_AMT)),
						new SqlParameter("AFP_PAYMENT_PERCENTAGE", SqlNull(AFP_PAYMENT_PERCENTAGE)),
						new SqlParameter("AFP_SUBMISSION_SIGN", SqlNull(AFP_SUBMISSION_SIGN)),
						new SqlParameter("AFP_SUBMISSION_AMT", SqlNull(AFP_SUBMISSION_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A2S_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_AFP_PAYM_SOLO = Reader["DOC_AFP_PAYM_SOLO"].ToString();
						AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString();
						AFP_CONVERSION_SIGN = Reader["AFP_CONVERSION_SIGN"].ToString();
						AFP_CONVERSION_AMT = ConvertDEC(Reader["AFP_CONVERSION_AMT"]);
						AFP_PAYMENT_PERCENTAGE = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]);
						AFP_SUBMISSION_SIGN = Reader["AFP_SUBMISSION_SIGN"].ToString();
						AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_afp_paym_solo = Reader["DOC_AFP_PAYM_SOLO"].ToString();
						_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString();
						_originalAfp_conversion_sign = Reader["AFP_CONVERSION_SIGN"].ToString();
						_originalAfp_conversion_amt = ConvertDEC(Reader["AFP_CONVERSION_AMT"]);
						_originalAfp_payment_percentage = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]);
						_originalAfp_submission_sign = Reader["AFP_SUBMISSION_SIGN"].ToString();
						_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
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
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_AFP_PAYM_SOLO", SqlNull(DOC_AFP_PAYM_SOLO)),
						new SqlParameter("AFP_SOLO_NAME", SqlNull(AFP_SOLO_NAME)),
						new SqlParameter("AFP_CONVERSION_SIGN", SqlNull(AFP_CONVERSION_SIGN)),
						new SqlParameter("AFP_CONVERSION_AMT", SqlNull(AFP_CONVERSION_AMT)),
						new SqlParameter("AFP_PAYMENT_PERCENTAGE", SqlNull(AFP_PAYMENT_PERCENTAGE)),
						new SqlParameter("AFP_SUBMISSION_SIGN", SqlNull(AFP_SUBMISSION_SIGN)),
						new SqlParameter("AFP_SUBMISSION_AMT", SqlNull(AFP_SUBMISSION_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A2S_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_AFP_PAYM_SOLO = Reader["DOC_AFP_PAYM_SOLO"].ToString();
						AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString();
						AFP_CONVERSION_SIGN = Reader["AFP_CONVERSION_SIGN"].ToString();
						AFP_CONVERSION_AMT = ConvertDEC(Reader["AFP_CONVERSION_AMT"]);
						AFP_PAYMENT_PERCENTAGE = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]);
						AFP_SUBMISSION_SIGN = Reader["AFP_SUBMISSION_SIGN"].ToString();
						AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_afp_paym_solo = Reader["DOC_AFP_PAYM_SOLO"].ToString();
						_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString();
						_originalAfp_conversion_sign = Reader["AFP_CONVERSION_SIGN"].ToString();
						_originalAfp_conversion_amt = ConvertDEC(Reader["AFP_CONVERSION_AMT"]);
						_originalAfp_payment_percentage = ConvertDEC(Reader["AFP_PAYMENT_PERCENTAGE"]);
						_originalAfp_submission_sign = Reader["AFP_SUBMISSION_SIGN"].ToString();
						_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
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