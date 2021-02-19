using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_GOVERNANCE_PAYMENTS_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE> Collection( Guid? rowid,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															string afp_solo_name,
															decimal? afp_payment_amtmin,
															decimal? afp_payment_amtmax,
															decimal? afp_payment_amt_payroll_amin,
															decimal? afp_payment_amt_payroll_amax,
															decimal? afp_payment_amt_payroll_bmin,
															decimal? afp_payment_amt_payroll_bmax,
															string reported_in_r140b_report,
															string doc_afp_paym_group,
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
					new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
					new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
					new SqlParameter("AFP_SOLO_NAME",afp_solo_name),
					new SqlParameter("minAFP_PAYMENT_AMT",afp_payment_amtmin),
					new SqlParameter("maxAFP_PAYMENT_AMT",afp_payment_amtmax),
					new SqlParameter("minAFP_PAYMENT_AMT_PAYROLL_A",afp_payment_amt_payroll_amin),
					new SqlParameter("maxAFP_PAYMENT_AMT_PAYROLL_A",afp_payment_amt_payroll_amax),
					new SqlParameter("minAFP_PAYMENT_AMT_PAYROLL_B",afp_payment_amt_payroll_bmin),
					new SqlParameter("maxAFP_PAYMENT_AMT_PAYROLL_B",afp_payment_amt_payroll_bmax),
					new SqlParameter("REPORTED_IN_R140B_REPORT",reported_in_r140b_report),
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_Search]", parameters);
            var collection = new ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE>();

            while (Reader.Read())
            {
                collection.Add(new TMP_GOVERNANCE_PAYMENTS_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_PAYROLL_A = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]),
					AFP_PAYMENT_AMT_PAYROLL_B = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]),
					REPORTED_IN_R140B_REPORT = Reader["REPORTED_IN_R140B_REPORT"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_payroll_a = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]),
					_originalAfp_payment_amt_payroll_b = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]),
					_originalReported_in_r140b_report = Reader["REPORTED_IN_R140B_REPORT"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_GOVERNANCE_PAYMENTS_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE> Collection(ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE>
                                                               tmpGovernancePaymentsFile = null)
        {
            if (IsSameSearch() && tmpGovernancePaymentsFile != null)
            {
                return tmpGovernancePaymentsFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("AFP_SOLO_NAME",WhereAfp_solo_name),
					new SqlParameter("AFP_PAYMENT_AMT",WhereAfp_payment_amt),
					new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_A",WhereAfp_payment_amt_payroll_a),
					new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_B",WhereAfp_payment_amt_payroll_b),
					new SqlParameter("REPORTED_IN_R140B_REPORT",WhereReported_in_r140b_report),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_Match]", parameters);
            var collection = new ObservableCollection<TMP_GOVERNANCE_PAYMENTS_FILE>();

            while (Reader.Read())
            {
                collection.Add(new TMP_GOVERNANCE_PAYMENTS_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString(),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_PAYROLL_A = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]),
					AFP_PAYMENT_AMT_PAYROLL_B = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]),
					REPORTED_IN_R140B_REPORT = Reader["REPORTED_IN_R140B_REPORT"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereAfp_solo_name = WhereAfp_solo_name,
					_whereAfp_payment_amt = WhereAfp_payment_amt,
					_whereAfp_payment_amt_payroll_a = WhereAfp_payment_amt_payroll_a,
					_whereAfp_payment_amt_payroll_b = WhereAfp_payment_amt_payroll_b,
					_whereReported_in_r140b_report = WhereReported_in_r140b_report,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString(),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_payroll_a = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]),
					_originalAfp_payment_amt_payroll_b = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]),
					_originalReported_in_r140b_report = Reader["REPORTED_IN_R140B_REPORT"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereAfp_solo_name = WhereAfp_solo_name;
					_whereAfp_payment_amt = WhereAfp_payment_amt;
					_whereAfp_payment_amt_payroll_a = WhereAfp_payment_amt_payroll_a;
					_whereAfp_payment_amt_payroll_b = WhereAfp_payment_amt_payroll_b;
					_whereReported_in_r140b_report = WhereReported_in_r140b_report;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_ohip_nbr == null 
				&& WhereAfp_solo_name == null 
				&& WhereAfp_payment_amt == null 
				&& WhereAfp_payment_amt_payroll_a == null 
				&& WhereAfp_payment_amt_payroll_b == null 
				&& WhereReported_in_r140b_report == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereAfp_solo_name ==  _whereAfp_solo_name
				&& WhereAfp_payment_amt ==  _whereAfp_payment_amt
				&& WhereAfp_payment_amt_payroll_a ==  _whereAfp_payment_amt_payroll_a
				&& WhereAfp_payment_amt_payroll_b ==  _whereAfp_payment_amt_payroll_b
				&& WhereReported_in_r140b_report ==  _whereReported_in_r140b_report
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_ohip_nbr = null; 
			WhereAfp_solo_name = null; 
			WhereAfp_payment_amt = null; 
			WhereAfp_payment_amt_payroll_a = null; 
			WhereAfp_payment_amt_payroll_b = null; 
			WhereReported_in_r140b_report = null; 
			WhereDoc_afp_paym_group = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOC_OHIP_NBR;
		private string _AFP_SOLO_NAME;
		private decimal? _AFP_PAYMENT_AMT;
		private decimal? _AFP_PAYMENT_AMT_PAYROLL_A;
		private decimal? _AFP_PAYMENT_AMT_PAYROLL_B;
		private string _REPORTED_IN_R140B_REPORT;
		private string _DOC_AFP_PAYM_GROUP;
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
		public decimal? DOC_OHIP_NBR
		{
			get { return _DOC_OHIP_NBR; }
			set
			{
				if (_DOC_OHIP_NBR != value)
				{
					_DOC_OHIP_NBR = value;
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
		public decimal? AFP_PAYMENT_AMT_PAYROLL_A
		{
			get { return _AFP_PAYMENT_AMT_PAYROLL_A; }
			set
			{
				if (_AFP_PAYMENT_AMT_PAYROLL_A != value)
				{
					_AFP_PAYMENT_AMT_PAYROLL_A = value;
					ChangeState();
				}
			}
		}
		public decimal? AFP_PAYMENT_AMT_PAYROLL_B
		{
			get { return _AFP_PAYMENT_AMT_PAYROLL_B; }
			set
			{
				if (_AFP_PAYMENT_AMT_PAYROLL_B != value)
				{
					_AFP_PAYMENT_AMT_PAYROLL_B = value;
					ChangeState();
				}
			}
		}
		public string REPORTED_IN_R140B_REPORT
		{
			get { return _REPORTED_IN_R140B_REPORT; }
			set
			{
				if (_REPORTED_IN_R140B_REPORT != value)
				{
					_REPORTED_IN_R140B_REPORT = value;
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
		public decimal? WhereDoc_ohip_nbr { get; set; }
		private decimal? _whereDoc_ohip_nbr;
		public string WhereAfp_solo_name { get; set; }
		private string _whereAfp_solo_name;
		public decimal? WhereAfp_payment_amt { get; set; }
		private decimal? _whereAfp_payment_amt;
		public decimal? WhereAfp_payment_amt_payroll_a { get; set; }
		private decimal? _whereAfp_payment_amt_payroll_a;
		public decimal? WhereAfp_payment_amt_payroll_b { get; set; }
		private decimal? _whereAfp_payment_amt_payroll_b;
		public string WhereReported_in_r140b_report { get; set; }
		private string _whereReported_in_r140b_report;
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDoc_ohip_nbr;
		private string _originalAfp_solo_name;
		private decimal? _originalAfp_payment_amt;
		private decimal? _originalAfp_payment_amt_payroll_a;
		private decimal? _originalAfp_payment_amt_payroll_b;
		private string _originalReported_in_r140b_report;
		private string _originalDoc_afp_paym_group;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			AFP_SOLO_NAME = _originalAfp_solo_name;
			AFP_PAYMENT_AMT = _originalAfp_payment_amt;
			AFP_PAYMENT_AMT_PAYROLL_A = _originalAfp_payment_amt_payroll_a;
			AFP_PAYMENT_AMT_PAYROLL_B = _originalAfp_payment_amt_payroll_b;
			REPORTED_IN_R140B_REPORT = _originalReported_in_r140b_report;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
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
					new SqlParameter("DOC_OHIP_NBR",DOC_OHIP_NBR),
					new SqlParameter("DOC_AFP_PAYM_GROUP",DOC_AFP_PAYM_GROUP)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_Purge]");
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
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("AFP_SOLO_NAME", SqlNull(AFP_SOLO_NAME)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_A", SqlNull(AFP_PAYMENT_AMT_PAYROLL_A)),
						new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_B", SqlNull(AFP_PAYMENT_AMT_PAYROLL_B)),
						new SqlParameter("REPORTED_IN_R140B_REPORT", SqlNull(REPORTED_IN_R140B_REPORT)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_PAYROLL_A = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]);
						AFP_PAYMENT_AMT_PAYROLL_B = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]);
						REPORTED_IN_R140B_REPORT = Reader["REPORTED_IN_R140B_REPORT"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_payroll_a = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]);
						_originalAfp_payment_amt_payroll_b = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]);
						_originalReported_in_r140b_report = Reader["REPORTED_IN_R140B_REPORT"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("AFP_SOLO_NAME", SqlNull(AFP_SOLO_NAME)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_A", SqlNull(AFP_PAYMENT_AMT_PAYROLL_A)),
						new SqlParameter("AFP_PAYMENT_AMT_PAYROLL_B", SqlNull(AFP_PAYMENT_AMT_PAYROLL_B)),
						new SqlParameter("REPORTED_IN_R140B_REPORT", SqlNull(REPORTED_IN_R140B_REPORT)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_GOVERNANCE_PAYMENTS_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						AFP_SOLO_NAME = Reader["AFP_SOLO_NAME"].ToString();
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_PAYROLL_A = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]);
						AFP_PAYMENT_AMT_PAYROLL_B = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]);
						REPORTED_IN_R140B_REPORT = Reader["REPORTED_IN_R140B_REPORT"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalAfp_solo_name = Reader["AFP_SOLO_NAME"].ToString();
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_payroll_a = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_A"]);
						_originalAfp_payment_amt_payroll_b = ConvertDEC(Reader["AFP_PAYMENT_AMT_PAYROLL_B"]);
						_originalReported_in_r140b_report = Reader["REPORTED_IN_R140B_REPORT"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
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