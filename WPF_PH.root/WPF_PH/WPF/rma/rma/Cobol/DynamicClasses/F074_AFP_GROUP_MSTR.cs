using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F074_AFP_GROUP_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F074_AFP_GROUP_MSTR> Collection( Guid? rowid,
															string afp_governance_group,
															string doc_afp_paym_group,
															string batctrl_payroll,
															string afp_group_name,
															string afp_reporting_mth,
															decimal? afp_multi_doc_ra_percentagemin,
															decimal? afp_multi_doc_ra_percentagemax,
															decimal? afp_payment_amtmin,
															decimal? afp_payment_amtmax,
															decimal? afp_payment_amt_totalmin,
															decimal? afp_payment_amt_totalmax,
															string afp_group_process_flag,
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
					new SqlParameter("AFP_GOVERNANCE_GROUP",afp_governance_group),
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("BATCTRL_PAYROLL",batctrl_payroll),
					new SqlParameter("AFP_GROUP_NAME",afp_group_name),
					new SqlParameter("AFP_REPORTING_MTH",afp_reporting_mth),
					new SqlParameter("minAFP_MULTI_DOC_RA_PERCENTAGE",afp_multi_doc_ra_percentagemin),
					new SqlParameter("maxAFP_MULTI_DOC_RA_PERCENTAGE",afp_multi_doc_ra_percentagemax),
					new SqlParameter("minAFP_PAYMENT_AMT",afp_payment_amtmin),
					new SqlParameter("maxAFP_PAYMENT_AMT",afp_payment_amtmax),
					new SqlParameter("minAFP_PAYMENT_AMT_TOTAL",afp_payment_amt_totalmin),
					new SqlParameter("maxAFP_PAYMENT_AMT_TOTAL",afp_payment_amt_totalmax),
					new SqlParameter("AFP_GROUP_PROCESS_FLAG",afp_group_process_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F074_AFP_GROUP_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F074_AFP_GROUP_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F074_AFP_GROUP_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					BATCTRL_PAYROLL = Reader["BATCTRL_PAYROLL"].ToString(),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					AFP_GROUP_PROCESS_FLAG = Reader["AFP_GROUP_PROCESS_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalBatctrl_payroll = Reader["BATCTRL_PAYROLL"].ToString(),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					_originalAfp_group_process_flag = Reader["AFP_GROUP_PROCESS_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F074_AFP_GROUP_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F074_AFP_GROUP_MSTR> Collection(ObservableCollection<F074_AFP_GROUP_MSTR>
                                                               f074AfpGroupMstr = null)
        {
            if (IsSameSearch() && f074AfpGroupMstr != null)
            {
                return f074AfpGroupMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F074_AFP_GROUP_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("AFP_GOVERNANCE_GROUP",WhereAfp_governance_group),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("BATCTRL_PAYROLL",WhereBatctrl_payroll),
					new SqlParameter("AFP_GROUP_NAME",WhereAfp_group_name),
					new SqlParameter("AFP_REPORTING_MTH",WhereAfp_reporting_mth),
					new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE",WhereAfp_multi_doc_ra_percentage),
					new SqlParameter("AFP_PAYMENT_AMT",WhereAfp_payment_amt),
					new SqlParameter("AFP_PAYMENT_AMT_TOTAL",WhereAfp_payment_amt_total),
					new SqlParameter("AFP_GROUP_PROCESS_FLAG",WhereAfp_group_process_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F074_AFP_GROUP_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F074_AFP_GROUP_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					BATCTRL_PAYROLL = Reader["BATCTRL_PAYROLL"].ToString(),
					AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					AFP_GROUP_PROCESS_FLAG = Reader["AFP_GROUP_PROCESS_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereAfp_governance_group = WhereAfp_governance_group,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereBatctrl_payroll = WhereBatctrl_payroll,
					_whereAfp_group_name = WhereAfp_group_name,
					_whereAfp_reporting_mth = WhereAfp_reporting_mth,
					_whereAfp_multi_doc_ra_percentage = WhereAfp_multi_doc_ra_percentage,
					_whereAfp_payment_amt = WhereAfp_payment_amt,
					_whereAfp_payment_amt_total = WhereAfp_payment_amt_total,
					_whereAfp_group_process_flag = WhereAfp_group_process_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalBatctrl_payroll = Reader["BATCTRL_PAYROLL"].ToString(),
					_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					_originalAfp_group_process_flag = Reader["AFP_GROUP_PROCESS_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereAfp_governance_group = WhereAfp_governance_group;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereBatctrl_payroll = WhereBatctrl_payroll;
					_whereAfp_group_name = WhereAfp_group_name;
					_whereAfp_reporting_mth = WhereAfp_reporting_mth;
					_whereAfp_multi_doc_ra_percentage = WhereAfp_multi_doc_ra_percentage;
					_whereAfp_payment_amt = WhereAfp_payment_amt;
					_whereAfp_payment_amt_total = WhereAfp_payment_amt_total;
					_whereAfp_group_process_flag = WhereAfp_group_process_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereAfp_governance_group == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereBatctrl_payroll == null 
				&& WhereAfp_group_name == null 
				&& WhereAfp_reporting_mth == null 
				&& WhereAfp_multi_doc_ra_percentage == null 
				&& WhereAfp_payment_amt == null 
				&& WhereAfp_payment_amt_total == null 
				&& WhereAfp_group_process_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereAfp_governance_group ==  _whereAfp_governance_group
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereBatctrl_payroll ==  _whereBatctrl_payroll
				&& WhereAfp_group_name ==  _whereAfp_group_name
				&& WhereAfp_reporting_mth ==  _whereAfp_reporting_mth
				&& WhereAfp_multi_doc_ra_percentage ==  _whereAfp_multi_doc_ra_percentage
				&& WhereAfp_payment_amt ==  _whereAfp_payment_amt
				&& WhereAfp_payment_amt_total ==  _whereAfp_payment_amt_total
				&& WhereAfp_group_process_flag ==  _whereAfp_group_process_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereAfp_governance_group = null; 
			WhereDoc_afp_paym_group = null; 
			WhereBatctrl_payroll = null; 
			WhereAfp_group_name = null; 
			WhereAfp_reporting_mth = null; 
			WhereAfp_multi_doc_ra_percentage = null; 
			WhereAfp_payment_amt = null; 
			WhereAfp_payment_amt_total = null; 
			WhereAfp_group_process_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _AFP_GOVERNANCE_GROUP;
		private string _DOC_AFP_PAYM_GROUP;
		private string _BATCTRL_PAYROLL;
		private string _AFP_GROUP_NAME;
		private string _AFP_REPORTING_MTH;
		private decimal? _AFP_MULTI_DOC_RA_PERCENTAGE;
		private decimal? _AFP_PAYMENT_AMT;
		private decimal? _AFP_PAYMENT_AMT_TOTAL;
		private string _AFP_GROUP_PROCESS_FLAG;
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
		public string BATCTRL_PAYROLL
		{
			get { return _BATCTRL_PAYROLL; }
			set
			{
				if (_BATCTRL_PAYROLL != value)
				{
					_BATCTRL_PAYROLL = value;
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
		public decimal? AFP_MULTI_DOC_RA_PERCENTAGE
		{
			get { return _AFP_MULTI_DOC_RA_PERCENTAGE; }
			set
			{
				if (_AFP_MULTI_DOC_RA_PERCENTAGE != value)
				{
					_AFP_MULTI_DOC_RA_PERCENTAGE = value;
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
		public decimal? AFP_PAYMENT_AMT_TOTAL
		{
			get { return _AFP_PAYMENT_AMT_TOTAL; }
			set
			{
				if (_AFP_PAYMENT_AMT_TOTAL != value)
				{
					_AFP_PAYMENT_AMT_TOTAL = value;
					ChangeState();
				}
			}
		}
		public string AFP_GROUP_PROCESS_FLAG
		{
			get { return _AFP_GROUP_PROCESS_FLAG; }
			set
			{
				if (_AFP_GROUP_PROCESS_FLAG != value)
				{
					_AFP_GROUP_PROCESS_FLAG = value;
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
		public string WhereAfp_governance_group { get; set; }
		private string _whereAfp_governance_group;
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public string WhereBatctrl_payroll { get; set; }
		private string _whereBatctrl_payroll;
		public string WhereAfp_group_name { get; set; }
		private string _whereAfp_group_name;
		public string WhereAfp_reporting_mth { get; set; }
		private string _whereAfp_reporting_mth;
		public decimal? WhereAfp_multi_doc_ra_percentage { get; set; }
		private decimal? _whereAfp_multi_doc_ra_percentage;
		public decimal? WhereAfp_payment_amt { get; set; }
		private decimal? _whereAfp_payment_amt;
		public decimal? WhereAfp_payment_amt_total { get; set; }
		private decimal? _whereAfp_payment_amt_total;
		public string WhereAfp_group_process_flag { get; set; }
		private string _whereAfp_group_process_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalAfp_governance_group;
		private string _originalDoc_afp_paym_group;
		private string _originalBatctrl_payroll;
		private string _originalAfp_group_name;
		private string _originalAfp_reporting_mth;
		private decimal? _originalAfp_multi_doc_ra_percentage;
		private decimal? _originalAfp_payment_amt;
		private decimal? _originalAfp_payment_amt_total;
		private string _originalAfp_group_process_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			AFP_GOVERNANCE_GROUP = _originalAfp_governance_group;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			BATCTRL_PAYROLL = _originalBatctrl_payroll;
			AFP_GROUP_NAME = _originalAfp_group_name;
			AFP_REPORTING_MTH = _originalAfp_reporting_mth;
			AFP_MULTI_DOC_RA_PERCENTAGE = _originalAfp_multi_doc_ra_percentage;
			AFP_PAYMENT_AMT = _originalAfp_payment_amt;
			AFP_PAYMENT_AMT_TOTAL = _originalAfp_payment_amt_total;
			AFP_GROUP_PROCESS_FLAG = _originalAfp_group_process_flag;
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
					new SqlParameter("DOC_AFP_PAYM_GROUP",DOC_AFP_PAYM_GROUP)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F074_AFP_GROUP_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F074_AFP_GROUP_MSTR_Purge]");
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
						new SqlParameter("AFP_GOVERNANCE_GROUP", SqlNull(AFP_GOVERNANCE_GROUP)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("BATCTRL_PAYROLL", SqlNull(BATCTRL_PAYROLL)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE", SqlNull(AFP_MULTI_DOC_RA_PERCENTAGE)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_TOTAL", SqlNull(AFP_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_GROUP_PROCESS_FLAG", SqlNull(AFP_GROUP_PROCESS_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						BATCTRL_PAYROLL = Reader["BATCTRL_PAYROLL"].ToString();
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						AFP_GROUP_PROCESS_FLAG = Reader["AFP_GROUP_PROCESS_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalBatctrl_payroll = Reader["BATCTRL_PAYROLL"].ToString();
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						_originalAfp_group_process_flag = Reader["AFP_GROUP_PROCESS_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("AFP_GOVERNANCE_GROUP", SqlNull(AFP_GOVERNANCE_GROUP)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("BATCTRL_PAYROLL", SqlNull(BATCTRL_PAYROLL)),
						new SqlParameter("AFP_GROUP_NAME", SqlNull(AFP_GROUP_NAME)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE", SqlNull(AFP_MULTI_DOC_RA_PERCENTAGE)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_TOTAL", SqlNull(AFP_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_GROUP_PROCESS_FLAG", SqlNull(AFP_GROUP_PROCESS_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F074_AFP_GROUP_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						AFP_GOVERNANCE_GROUP = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						BATCTRL_PAYROLL = Reader["BATCTRL_PAYROLL"].ToString();
						AFP_GROUP_NAME = Reader["AFP_GROUP_NAME"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						AFP_GROUP_PROCESS_FLAG = Reader["AFP_GROUP_PROCESS_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalAfp_governance_group = Reader["AFP_GOVERNANCE_GROUP"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalBatctrl_payroll = Reader["BATCTRL_PAYROLL"].ToString();
						_originalAfp_group_name = Reader["AFP_GROUP_NAME"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						_originalAfp_group_process_flag = Reader["AFP_GROUP_PROCESS_FLAG"].ToString();
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