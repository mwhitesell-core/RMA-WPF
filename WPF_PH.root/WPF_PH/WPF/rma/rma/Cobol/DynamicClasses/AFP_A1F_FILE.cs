using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class AFP_A1F_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<AFP_A1F_FILE> Collection( Guid? rowid,
															string afp_transaction_id,
															string afp_record_id,
															string filler_1,
															string afp_governance_group,
															string filler_2,
															string afp_group_name,
															string afp_payment_sign,
															decimal? afp_payment_amtmin,
															decimal? afp_payment_amtmax,
															string filler_3,
															string afp_reporting_mth,
															string afp_release_id,
															string filler_4,
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
					new SqlParameter("AFP_GOVERNANCE_GROUP",afp_governance_group),
					new SqlParameter("FILLER_2",filler_2),
					new SqlParameter("AFP_GROUP_NAME",afp_group_name),
					new SqlParameter("AFP_PAYMENT_SIGN",afp_payment_sign),
					new SqlParameter("minAFP_PAYMENT_AMT",afp_payment_amtmin),
					new SqlParameter("maxAFP_PAYMENT_AMT",afp_payment_amtmax),
					new SqlParameter("FILLER_3",filler_3),
					new SqlParameter("AFP_REPORTING_MTH",afp_reporting_mth),
					new SqlParameter("AFP_RELEASE_ID",afp_release_id),
					new SqlParameter("FILLER_4",filler_4),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A1F_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<AFP_A1F_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A1F_FILE_Search]", parameters);
            var collection = new ObservableCollection<AFP_A1F_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A1F_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					FILLER_2 = Reader["FILLER_2"].ToString(),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_RELEASE_ID = Reader["AFP_RELEASE_ID"].ToString(),
					FILLER_4 = Reader["FILLER_4"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					_originalFiller_2 = Reader["FILLER_2"].ToString(),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_release_id = Reader["AFP_RELEASE_ID"].ToString(),
					_originalFiller_4 = Reader["FILLER_4"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public AFP_A1F_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<AFP_A1F_FILE> Collection(ObservableCollection<AFP_A1F_FILE>
                                                               afpA1fFile = null)
        {
            if (IsSameSearch() && afpA1fFile != null)
            {
                return afpA1fFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<AFP_A1F_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("AFP_TRANSACTION_ID",WhereAfp_transaction_id),
					new SqlParameter("AFP_RECORD_ID",WhereAfp_record_id),
					new SqlParameter("FILLER_1",WhereFiller_1),
					new SqlParameter("AFP_GOVERNANCE_GROUP",WhereAfp_governance_group),
					new SqlParameter("FILLER_2",WhereFiller_2),
					new SqlParameter("AFP_GROUP_NAME",WhereAfp_group_name),
					new SqlParameter("AFP_PAYMENT_SIGN",WhereAfp_payment_sign),
					new SqlParameter("AFP_PAYMENT_AMT",WhereAfp_payment_amt),
					new SqlParameter("FILLER_3",WhereFiller_3),
					new SqlParameter("AFP_REPORTING_MTH",WhereAfp_reporting_mth),
					new SqlParameter("AFP_RELEASE_ID",WhereAfp_release_id),
					new SqlParameter("FILLER_4",WhereFiller_4),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A1F_FILE_Match]", parameters);
            var collection = new ObservableCollection<AFP_A1F_FILE>();

            while (Reader.Read())
            {
                collection.Add(new AFP_A1F_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString(),
					AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString(),
					FILLER_1 = Reader["FILLER_1"].ToString(),
					AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					FILLER_2 = Reader["FILLER_2"].ToString(),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					FILLER_3 = Reader["FILLER_3"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_RELEASE_ID = Reader["AFP_RELEASE_ID"].ToString(),
					FILLER_4 = Reader["FILLER_4"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAfp_transaction_id = WhereAfp_transaction_id,
					_whereAfp_record_id = WhereAfp_record_id,
					_whereFiller_1 = WhereFiller_1,
					_whereAfp_governance_group = WhereAfp_governance_group,
					_whereFiller_2 = WhereFiller_2,
					_whereAfp_group_name = WhereAfp_group_name,
					_whereAfp_payment_sign = WhereAfp_payment_sign,
					_whereAfp_payment_amt = WhereAfp_payment_amt,
					_whereFiller_3 = WhereFiller_3,
					_whereAfp_reporting_mth = WhereAfp_reporting_mth,
					_whereAfp_release_id = WhereAfp_release_id,
					_whereFiller_4 = WhereFiller_4,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString(),
					_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString(),
					_originalFiller_1 = Reader["FILLER_1"].ToString(),
					_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					_originalFiller_2 = Reader["FILLER_2"].ToString(),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalFiller_3 = Reader["FILLER_3"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_release_id = Reader["AFP_RELEASE_ID"].ToString(),
					_originalFiller_4 = Reader["FILLER_4"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAfp_transaction_id = WhereAfp_transaction_id;
					_whereAfp_record_id = WhereAfp_record_id;
					_whereFiller_1 = WhereFiller_1;
					_whereAfp_governance_group = WhereAfp_governance_group;
					_whereFiller_2 = WhereFiller_2;
					_whereAfp_group_name = WhereAfp_group_name;
					_whereAfp_payment_sign = WhereAfp_payment_sign;
					_whereAfp_payment_amt = WhereAfp_payment_amt;
					_whereFiller_3 = WhereFiller_3;
					_whereAfp_reporting_mth = WhereAfp_reporting_mth;
					_whereAfp_release_id = WhereAfp_release_id;
					_whereFiller_4 = WhereFiller_4;
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
				&& WhereAfp_governance_group == null 
				&& WhereFiller_2 == null 
				&& WhereAfp_group_name == null 
				&& WhereAfp_payment_sign == null 
				&& WhereAfp_payment_amt == null 
				&& WhereFiller_3 == null 
				&& WhereAfp_reporting_mth == null 
				&& WhereAfp_release_id == null 
				&& WhereFiller_4 == null 
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
				&& WhereAfp_governance_group ==  _whereAfp_governance_group
				&& WhereFiller_2 ==  _whereFiller_2
				&& WhereAfp_group_name ==  _whereAfp_group_name
				&& WhereAfp_payment_sign ==  _whereAfp_payment_sign
				&& WhereAfp_payment_amt ==  _whereAfp_payment_amt
				&& WhereFiller_3 ==  _whereFiller_3
				&& WhereAfp_reporting_mth ==  _whereAfp_reporting_mth
				&& WhereAfp_release_id ==  _whereAfp_release_id
				&& WhereFiller_4 ==  _whereFiller_4
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereAfp_transaction_id = null; 
			WhereAfp_record_id = null; 
			WhereFiller_1 = null; 
			WhereAfp_governance_group = null; 
			WhereFiller_2 = null; 
			WhereAfp_group_name = null; 
			WhereAfp_payment_sign = null; 
			WhereAfp_payment_amt = null; 
			WhereFiller_3 = null; 
			WhereAfp_reporting_mth = null; 
			WhereAfp_release_id = null; 
			WhereFiller_4 = null; 
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
		private string _AFP_GOVERNANCE_GROUP;
		private string _FILLER_2;
		private string _AFP_GROUP_NAME;
		private string _AFP_PAYMENT_SIGN;
		private decimal? _AFP_PAYMENT_AMT;
		private string _FILLER_3;
		private string _AFP_REPORTING_MTH;
		private string _AFP_RELEASE_ID;
		private string _FILLER_4;
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
		public string AFP_GOVERNANCE_GROUP
		{
			get { return _AFP_GOVERNANCE_GROUP; }
			set
			{
				if (_AFP_GOVERNANCE_GROUP != value)
				{
					_AFP_GOVERNANCE_GROUP = value;
					ChangeState();
				}
			}
		}
		public string FILLER_2
		{
			get { return _FILLER_2; }
			set
			{
				if (_FILLER_2 != value)
				{
					_FILLER_2 = value;
					ChangeState();
				}
			}
		}
		public string AFP_GROUP_NAME
		{
			get { return _AFP_GROUP_NAME; }
			set
			{
				if (_AFP_GROUP_NAME != value)
				{
					_AFP_GROUP_NAME = value;
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
		public string AFP_REPORTING_MTH
		{
			get { return _AFP_REPORTING_MTH; }
			set
			{
				if (_AFP_REPORTING_MTH != value)
				{
					_AFP_REPORTING_MTH = value;
					ChangeState();
				}
			}
		}
		public string AFP_RELEASE_ID
		{
			get { return _AFP_RELEASE_ID; }
			set
			{
				if (_AFP_RELEASE_ID != value)
				{
					_AFP_RELEASE_ID = value;
					ChangeState();
				}
			}
		}
		public string FILLER_4
		{
			get { return _FILLER_4; }
			set
			{
				if (_FILLER_4 != value)
				{
					_FILLER_4 = value;
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
		public string WhereAfp_governance_group { get; set; }
		private string _whereAfp_governance_group;
		public string WhereFiller_2 { get; set; }
		private string _whereFiller_2;
		public string WhereAfp_group_name { get; set; }
		private string _whereAfp_group_name;
		public string WhereAfp_payment_sign { get; set; }
		private string _whereAfp_payment_sign;
		public decimal? WhereAfp_payment_amt { get; set; }
		private decimal? _whereAfp_payment_amt;
		public string WhereFiller_3 { get; set; }
		private string _whereFiller_3;
		public string WhereAfp_reporting_mth { get; set; }
		private string _whereAfp_reporting_mth;
		public string WhereAfp_release_id { get; set; }
		private string _whereAfp_release_id;
		public string WhereFiller_4 { get; set; }
		private string _whereFiller_4;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalAfp_transaction_id;
		private string _originalAfp_record_id;
		private string _originalFiller_1;
		private string _originalAfp_governance_group;
		private string _originalFiller_2;
		private string _originalAfp_group_name;
		private string _originalAfp_payment_sign;
		private decimal? _originalAfp_payment_amt;
		private string _originalFiller_3;
		private string _originalAfp_reporting_mth;
		private string _originalAfp_release_id;
		private string _originalFiller_4;
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
			AFP_GOVERNANCE_GROUP = _originalAfp_governance_group;
			FILLER_2 = _originalFiller_2;
			AFP_GROUP_NAME = _originalAfp_group_name;
			AFP_PAYMENT_SIGN = _originalAfp_payment_sign;
			AFP_PAYMENT_AMT = _originalAfp_payment_amt;
			FILLER_3 = _originalFiller_3;
			AFP_REPORTING_MTH = _originalAfp_reporting_mth;
			AFP_RELEASE_ID = _originalAfp_release_id;
			FILLER_4 = _originalFiller_4;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A1F_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_AFP_A1F_FILE_Purge]");
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
						new SqlParameter("AFP_GOVERNANCE_GROUP", SqlNull(AFP_GOVERNANCE_GROUP)),
						new SqlParameter("FILLER_2", SqlNull(FILLER_2)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("AFP_PAYMENT_SIGN", SqlNull(AFP_PAYMENT_SIGN)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_RELEASE_ID", SqlNull(AFP_RELEASE_ID)),
						new SqlParameter("FILLER_4", SqlNull(FILLER_4)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A1F_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						FILLER_2 = Reader["FILLER_2"].ToString();
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_RELEASE_ID = Reader["AFP_RELEASE_ID"].ToString();
						FILLER_4 = Reader["FILLER_4"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						_originalFiller_2 = Reader["FILLER_2"].ToString();
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalFiller_3 = Reader["FILLER_3"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_release_id = Reader["AFP_RELEASE_ID"].ToString();
						_originalFiller_4 = Reader["FILLER_4"].ToString();
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
						new SqlParameter("AFP_GOVERNANCE_GROUP", SqlNull(AFP_GOVERNANCE_GROUP)),
						new SqlParameter("FILLER_2", SqlNull(FILLER_2)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("AFP_PAYMENT_SIGN", SqlNull(AFP_PAYMENT_SIGN)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("FILLER_3", SqlNull(FILLER_3)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_RELEASE_ID", SqlNull(AFP_RELEASE_ID)),
						new SqlParameter("FILLER_4", SqlNull(FILLER_4)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_AFP_A1F_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_TRANSACTION_ID = Reader["AFP_TRANSACTION_ID"].ToString();
						AFP_RECORD_ID = Reader["AFP_RECORD_ID"].ToString();
						FILLER_1 = Reader["FILLER_1"].ToString();
						AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						FILLER_2 = Reader["FILLER_2"].ToString();
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						AFP_PAYMENT_SIGN = Reader["AFP_PAYMENT_SIGN"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						FILLER_3 = Reader["FILLER_3"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_RELEASE_ID = Reader["AFP_RELEASE_ID"].ToString();
						FILLER_4 = Reader["FILLER_4"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_transaction_id = Reader["AFP_TRANSACTION_ID"].ToString();
						_originalAfp_record_id = Reader["AFP_RECORD_ID"].ToString();
						_originalFiller_1 = Reader["FILLER_1"].ToString();
						_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						_originalFiller_2 = Reader["FILLER_2"].ToString();
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalAfp_payment_sign = Reader["AFP_PAYMENT_SIGN"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalFiller_3 = Reader["FILLER_3"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_release_id = Reader["AFP_RELEASE_ID"].ToString();
						_originalFiller_4 = Reader["FILLER_4"].ToString();
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