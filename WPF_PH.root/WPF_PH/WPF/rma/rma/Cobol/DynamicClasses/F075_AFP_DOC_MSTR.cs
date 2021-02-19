using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F075_AFP_DOC_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F075_AFP_DOC_MSTR> Collection( Guid? rowid,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															string doc_nbr,
															string doc_afp_paym_group,
															string afp_reporting_mth,
															decimal? afp_multi_doc_ra_percentagemin,
															decimal? afp_multi_doc_ra_percentagemax,
															decimal? ra_payment_amtmin,
															decimal? ra_payment_amtmax,
															decimal? ra_payment_amt_totalmin,
															decimal? ra_payment_amt_totalmax,
															decimal? afp_payment_amtmin,
															decimal? afp_payment_amtmax,
															decimal? afp_payment_amt_totalmin,
															decimal? afp_payment_amt_totalmax,
															decimal? afp_submission_amtmin,
															decimal? afp_submission_amtmax,
															decimal? afp_duplicate_doc_countmin,
															decimal? afp_duplicate_doc_countmax,
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
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("AFP_REPORTING_MTH",afp_reporting_mth),
					new SqlParameter("minAFP_MULTI_DOC_RA_PERCENTAGE",afp_multi_doc_ra_percentagemin),
					new SqlParameter("maxAFP_MULTI_DOC_RA_PERCENTAGE",afp_multi_doc_ra_percentagemax),
					new SqlParameter("minRA_PAYMENT_AMT",ra_payment_amtmin),
					new SqlParameter("maxRA_PAYMENT_AMT",ra_payment_amtmax),
					new SqlParameter("minRA_PAYMENT_AMT_TOTAL",ra_payment_amt_totalmin),
					new SqlParameter("maxRA_PAYMENT_AMT_TOTAL",ra_payment_amt_totalmax),
					new SqlParameter("minAFP_PAYMENT_AMT",afp_payment_amtmin),
					new SqlParameter("maxAFP_PAYMENT_AMT",afp_payment_amtmax),
					new SqlParameter("minAFP_PAYMENT_AMT_TOTAL",afp_payment_amt_totalmin),
					new SqlParameter("maxAFP_PAYMENT_AMT_TOTAL",afp_payment_amt_totalmax),
					new SqlParameter("minAFP_SUBMISSION_AMT",afp_submission_amtmin),
					new SqlParameter("maxAFP_SUBMISSION_AMT",afp_submission_amtmax),
					new SqlParameter("minAFP_DUPLICATE_DOC_COUNT",afp_duplicate_doc_countmin),
					new SqlParameter("maxAFP_DUPLICATE_DOC_COUNT",afp_duplicate_doc_countmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F075_AFP_DOC_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F075_AFP_DOC_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F075_AFP_DOC_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F075_AFP_DOC_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F075_AFP_DOC_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					RA_PAYMENT_AMT = ConvertDEC(Reader["RA_PAYMENT_AMT"]),
					RA_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					AFP_DUPLICATE_DOC_COUNT = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					_originalRa_payment_amt = ConvertDEC(Reader["RA_PAYMENT_AMT"]),
					_originalRa_payment_amt_total = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					_originalAfp_duplicate_doc_count = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F075_AFP_DOC_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F075_AFP_DOC_MSTR> Collection(ObservableCollection<F075_AFP_DOC_MSTR>
                                                               f075AfpDocMstr = null)
        {
            if (IsSameSearch() && f075AfpDocMstr != null)
            {
                return f075AfpDocMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F075_AFP_DOC_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("AFP_REPORTING_MTH",WhereAfp_reporting_mth),
					new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE",WhereAfp_multi_doc_ra_percentage),
					new SqlParameter("RA_PAYMENT_AMT",WhereRa_payment_amt),
					new SqlParameter("RA_PAYMENT_AMT_TOTAL",WhereRa_payment_amt_total),
					new SqlParameter("AFP_PAYMENT_AMT",WhereAfp_payment_amt),
					new SqlParameter("AFP_PAYMENT_AMT_TOTAL",WhereAfp_payment_amt_total),
					new SqlParameter("AFP_SUBMISSION_AMT",WhereAfp_submission_amt),
					new SqlParameter("AFP_DUPLICATE_DOC_COUNT",WhereAfp_duplicate_doc_count),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F075_AFP_DOC_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F075_AFP_DOC_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F075_AFP_DOC_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString(),
					AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					RA_PAYMENT_AMT = ConvertDEC(Reader["RA_PAYMENT_AMT"]),
					RA_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]),
					AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					AFP_DUPLICATE_DOC_COUNT = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereAfp_reporting_mth = WhereAfp_reporting_mth,
					_whereAfp_multi_doc_ra_percentage = WhereAfp_multi_doc_ra_percentage,
					_whereRa_payment_amt = WhereRa_payment_amt,
					_whereRa_payment_amt_total = WhereRa_payment_amt_total,
					_whereAfp_payment_amt = WhereAfp_payment_amt,
					_whereAfp_payment_amt_total = WhereAfp_payment_amt_total,
					_whereAfp_submission_amt = WhereAfp_submission_amt,
					_whereAfp_duplicate_doc_count = WhereAfp_duplicate_doc_count,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString(),
					_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]),
					_originalRa_payment_amt = ConvertDEC(Reader["RA_PAYMENT_AMT"]),
					_originalRa_payment_amt_total = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]),
					_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]),
					_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]),
					_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]),
					_originalAfp_duplicate_doc_count = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereAfp_reporting_mth = WhereAfp_reporting_mth;
					_whereAfp_multi_doc_ra_percentage = WhereAfp_multi_doc_ra_percentage;
					_whereRa_payment_amt = WhereRa_payment_amt;
					_whereRa_payment_amt_total = WhereRa_payment_amt_total;
					_whereAfp_payment_amt = WhereAfp_payment_amt;
					_whereAfp_payment_amt_total = WhereAfp_payment_amt_total;
					_whereAfp_submission_amt = WhereAfp_submission_amt;
					_whereAfp_duplicate_doc_count = WhereAfp_duplicate_doc_count;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_ohip_nbr == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereAfp_reporting_mth == null 
				&& WhereAfp_multi_doc_ra_percentage == null 
				&& WhereRa_payment_amt == null 
				&& WhereRa_payment_amt_total == null 
				&& WhereAfp_payment_amt == null 
				&& WhereAfp_payment_amt_total == null 
				&& WhereAfp_submission_amt == null 
				&& WhereAfp_duplicate_doc_count == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereAfp_reporting_mth ==  _whereAfp_reporting_mth
				&& WhereAfp_multi_doc_ra_percentage ==  _whereAfp_multi_doc_ra_percentage
				&& WhereRa_payment_amt ==  _whereRa_payment_amt
				&& WhereRa_payment_amt_total ==  _whereRa_payment_amt_total
				&& WhereAfp_payment_amt ==  _whereAfp_payment_amt
				&& WhereAfp_payment_amt_total ==  _whereAfp_payment_amt_total
				&& WhereAfp_submission_amt ==  _whereAfp_submission_amt
				&& WhereAfp_duplicate_doc_count ==  _whereAfp_duplicate_doc_count
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_ohip_nbr = null; 
			WhereDoc_nbr = null; 
			WhereDoc_afp_paym_group = null; 
			WhereAfp_reporting_mth = null; 
			WhereAfp_multi_doc_ra_percentage = null; 
			WhereRa_payment_amt = null; 
			WhereRa_payment_amt_total = null; 
			WhereAfp_payment_amt = null; 
			WhereAfp_payment_amt_total = null; 
			WhereAfp_submission_amt = null; 
			WhereAfp_duplicate_doc_count = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOC_OHIP_NBR;
		private string _DOC_NBR;
		private string _DOC_AFP_PAYM_GROUP;
		private string _AFP_REPORTING_MTH;
		private decimal? _AFP_MULTI_DOC_RA_PERCENTAGE;
		private decimal? _RA_PAYMENT_AMT;
		private decimal? _RA_PAYMENT_AMT_TOTAL;
		private decimal? _AFP_PAYMENT_AMT;
		private decimal? _AFP_PAYMENT_AMT_TOTAL;
		private decimal? _AFP_SUBMISSION_AMT;
		private decimal? _AFP_DUPLICATE_DOC_COUNT;
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
		public string DOC_NBR
		{
			get { return _DOC_NBR; }
			set
			{
				if (_DOC_NBR != value)
				{
					_DOC_NBR = value;
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
		public decimal? RA_PAYMENT_AMT
		{
			get { return _RA_PAYMENT_AMT; }
			set
			{
				if (_RA_PAYMENT_AMT != value)
				{
					_RA_PAYMENT_AMT = value;
					ChangeState();
				}
			}
		}
		public decimal? RA_PAYMENT_AMT_TOTAL
		{
			get { return _RA_PAYMENT_AMT_TOTAL; }
			set
			{
				if (_RA_PAYMENT_AMT_TOTAL != value)
				{
					_RA_PAYMENT_AMT_TOTAL = value;
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
		public decimal? AFP_DUPLICATE_DOC_COUNT
		{
			get { return _AFP_DUPLICATE_DOC_COUNT; }
			set
			{
				if (_AFP_DUPLICATE_DOC_COUNT != value)
				{
					_AFP_DUPLICATE_DOC_COUNT = value;
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
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public string WhereAfp_reporting_mth { get; set; }
		private string _whereAfp_reporting_mth;
		public decimal? WhereAfp_multi_doc_ra_percentage { get; set; }
		private decimal? _whereAfp_multi_doc_ra_percentage;
		public decimal? WhereRa_payment_amt { get; set; }
		private decimal? _whereRa_payment_amt;
		public decimal? WhereRa_payment_amt_total { get; set; }
		private decimal? _whereRa_payment_amt_total;
		public decimal? WhereAfp_payment_amt { get; set; }
		private decimal? _whereAfp_payment_amt;
		public decimal? WhereAfp_payment_amt_total { get; set; }
		private decimal? _whereAfp_payment_amt_total;
		public decimal? WhereAfp_submission_amt { get; set; }
		private decimal? _whereAfp_submission_amt;
		public decimal? WhereAfp_duplicate_doc_count { get; set; }
		private decimal? _whereAfp_duplicate_doc_count;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDoc_ohip_nbr;
		private string _originalDoc_nbr;
		private string _originalDoc_afp_paym_group;
		private string _originalAfp_reporting_mth;
		private decimal? _originalAfp_multi_doc_ra_percentage;
		private decimal? _originalRa_payment_amt;
		private decimal? _originalRa_payment_amt_total;
		private decimal? _originalAfp_payment_amt;
		private decimal? _originalAfp_payment_amt_total;
		private decimal? _originalAfp_submission_amt;
		private decimal? _originalAfp_duplicate_doc_count;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			DOC_NBR = _originalDoc_nbr;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			AFP_REPORTING_MTH = _originalAfp_reporting_mth;
			AFP_MULTI_DOC_RA_PERCENTAGE = _originalAfp_multi_doc_ra_percentage;
			RA_PAYMENT_AMT = _originalRa_payment_amt;
			RA_PAYMENT_AMT_TOTAL = _originalRa_payment_amt_total;
			AFP_PAYMENT_AMT = _originalAfp_payment_amt;
			AFP_PAYMENT_AMT_TOTAL = _originalAfp_payment_amt_total;
			AFP_SUBMISSION_AMT = _originalAfp_submission_amt;
			AFP_DUPLICATE_DOC_COUNT = _originalAfp_duplicate_doc_count;
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
					new SqlParameter("DOC_NBR",DOC_NBR),
					new SqlParameter("DOC_AFP_PAYM_GROUP",DOC_AFP_PAYM_GROUP)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F075_AFP_DOC_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F075_AFP_DOC_MSTR_Purge]");
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
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE", SqlNull(AFP_MULTI_DOC_RA_PERCENTAGE)),
						new SqlParameter("RA_PAYMENT_AMT", SqlNull(RA_PAYMENT_AMT)),
						new SqlParameter("RA_PAYMENT_AMT_TOTAL", SqlNull(RA_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_TOTAL", SqlNull(AFP_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_SUBMISSION_AMT", SqlNull(AFP_SUBMISSION_AMT)),
						new SqlParameter("AFP_DUPLICATE_DOC_COUNT", SqlNull(AFP_DUPLICATE_DOC_COUNT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F075_AFP_DOC_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						RA_PAYMENT_AMT = ConvertDEC(Reader["RA_PAYMENT_AMT"]);
						RA_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]);
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						AFP_DUPLICATE_DOC_COUNT = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						_originalRa_payment_amt = ConvertDEC(Reader["RA_PAYMENT_AMT"]);
						_originalRa_payment_amt_total = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]);
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						_originalAfp_duplicate_doc_count = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("AFP_REPORTING_MTH", SqlNull(AFP_REPORTING_MTH)),
						new SqlParameter("AFP_MULTI_DOC_RA_PERCENTAGE", SqlNull(AFP_MULTI_DOC_RA_PERCENTAGE)),
						new SqlParameter("RA_PAYMENT_AMT", SqlNull(RA_PAYMENT_AMT)),
						new SqlParameter("RA_PAYMENT_AMT_TOTAL", SqlNull(RA_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_PAYMENT_AMT", SqlNull(AFP_PAYMENT_AMT)),
						new SqlParameter("AFP_PAYMENT_AMT_TOTAL", SqlNull(AFP_PAYMENT_AMT_TOTAL)),
						new SqlParameter("AFP_SUBMISSION_AMT", SqlNull(AFP_SUBMISSION_AMT)),
						new SqlParameter("AFP_DUPLICATE_DOC_COUNT", SqlNull(AFP_DUPLICATE_DOC_COUNT)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F075_AFP_DOC_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						AFP_REPORTING_MTH = Reader["AFP_REPORTING_MTH"].ToString();
						AFP_MULTI_DOC_RA_PERCENTAGE = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						RA_PAYMENT_AMT = ConvertDEC(Reader["RA_PAYMENT_AMT"]);
						RA_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]);
						AFP_PAYMENT_AMT = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						AFP_PAYMENT_AMT_TOTAL = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						AFP_SUBMISSION_AMT = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						AFP_DUPLICATE_DOC_COUNT = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalAfp_reporting_mth = Reader["AFP_REPORTING_MTH"].ToString();
						_originalAfp_multi_doc_ra_percentage = ConvertDEC(Reader["AFP_MULTI_DOC_RA_PERCENTAGE"]);
						_originalRa_payment_amt = ConvertDEC(Reader["RA_PAYMENT_AMT"]);
						_originalRa_payment_amt_total = ConvertDEC(Reader["RA_PAYMENT_AMT_TOTAL"]);
						_originalAfp_payment_amt = ConvertDEC(Reader["AFP_PAYMENT_AMT"]);
						_originalAfp_payment_amt_total = ConvertDEC(Reader["AFP_PAYMENT_AMT_TOTAL"]);
						_originalAfp_submission_amt = ConvertDEC(Reader["AFP_SUBMISSION_AMT"]);
						_originalAfp_duplicate_doc_count = ConvertDEC(Reader["AFP_DUPLICATE_DOC_COUNT"]);
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