using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class U030_TAPE_67_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<U030_TAPE_67_FILE> Collection( Guid? rowid,
															decimal? rat_67_amt_claims_adjmin,
															decimal? rat_67_amt_claims_adjmax,
															decimal? rat_67_amt_advancesmin,
															decimal? rat_67_amt_advancesmax,
															decimal? rat_67_amt_reductionsmin,
															decimal? rat_67_amt_reductionsmax,
															decimal? rat_67_amt_deductionsmin,
															decimal? rat_67_amt_deductionsmax,
															string rat_67_trans_cd,
															string rat_67_cheque_ind,
															decimal? rat_67_trans_datemin,
															decimal? rat_67_trans_datemax,
															decimal? rat_67_trans_amtmin,
															decimal? rat_67_trans_amtmax,
															string rat_67_trans_message,
															decimal? rat_67_total_clinic_amtmin,
															decimal? rat_67_total_clinic_amtmax,
															decimal? rat_67_amt_billmin,
															decimal? rat_67_amt_billmax,
															decimal? rat_67_amt_paidmin,
															decimal? rat_67_amt_paidmax,
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
					new SqlParameter("minRAT_67_AMT_CLAIMS_ADJ",rat_67_amt_claims_adjmin),
					new SqlParameter("maxRAT_67_AMT_CLAIMS_ADJ",rat_67_amt_claims_adjmax),
					new SqlParameter("minRAT_67_AMT_ADVANCES",rat_67_amt_advancesmin),
					new SqlParameter("maxRAT_67_AMT_ADVANCES",rat_67_amt_advancesmax),
					new SqlParameter("minRAT_67_AMT_REDUCTIONS",rat_67_amt_reductionsmin),
					new SqlParameter("maxRAT_67_AMT_REDUCTIONS",rat_67_amt_reductionsmax),
					new SqlParameter("minRAT_67_AMT_DEDUCTIONS",rat_67_amt_deductionsmin),
					new SqlParameter("maxRAT_67_AMT_DEDUCTIONS",rat_67_amt_deductionsmax),
					new SqlParameter("RAT_67_TRANS_CD",rat_67_trans_cd),
					new SqlParameter("RAT_67_CHEQUE_IND",rat_67_cheque_ind),
					new SqlParameter("minRAT_67_TRANS_DATE",rat_67_trans_datemin),
					new SqlParameter("maxRAT_67_TRANS_DATE",rat_67_trans_datemax),
					new SqlParameter("minRAT_67_TRANS_AMT",rat_67_trans_amtmin),
					new SqlParameter("maxRAT_67_TRANS_AMT",rat_67_trans_amtmax),
					new SqlParameter("RAT_67_TRANS_MESSAGE",rat_67_trans_message),
					new SqlParameter("minRAT_67_TOTAL_CLINIC_AMT",rat_67_total_clinic_amtmin),
					new SqlParameter("maxRAT_67_TOTAL_CLINIC_AMT",rat_67_total_clinic_amtmax),
					new SqlParameter("minRAT_67_AMT_BILL",rat_67_amt_billmin),
					new SqlParameter("maxRAT_67_AMT_BILL",rat_67_amt_billmax),
					new SqlParameter("minRAT_67_AMT_PAID",rat_67_amt_paidmin),
					new SqlParameter("maxRAT_67_AMT_PAID",rat_67_amt_paidmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<U030_TAPE_67_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Search]", parameters);
            var collection = new ObservableCollection<U030_TAPE_67_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U030_TAPE_67_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_67_AMT_CLAIMS_ADJ = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]),
					RAT_67_AMT_ADVANCES = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]),
					RAT_67_AMT_REDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]),
					RAT_67_AMT_DEDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]),
					RAT_67_TRANS_CD = Reader["RAT_67_TRANS_CD"].ToString(),
					RAT_67_CHEQUE_IND = Reader["RAT_67_CHEQUE_IND"].ToString(),
					RAT_67_TRANS_DATE = ConvertDEC(Reader["RAT_67_TRANS_DATE"]),
					RAT_67_TRANS_AMT = ConvertDEC(Reader["RAT_67_TRANS_AMT"]),
					RAT_67_TRANS_MESSAGE = Reader["RAT_67_TRANS_MESSAGE"].ToString(),
					RAT_67_TOTAL_CLINIC_AMT = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]),
					RAT_67_AMT_BILL = ConvertDEC(Reader["RAT_67_AMT_BILL"]),
					RAT_67_AMT_PAID = ConvertDEC(Reader["RAT_67_AMT_PAID"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_67_amt_claims_adj = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]),
					_originalRat_67_amt_advances = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]),
					_originalRat_67_amt_reductions = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]),
					_originalRat_67_amt_deductions = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]),
					_originalRat_67_trans_cd = Reader["RAT_67_TRANS_CD"].ToString(),
					_originalRat_67_cheque_ind = Reader["RAT_67_CHEQUE_IND"].ToString(),
					_originalRat_67_trans_date = ConvertDEC(Reader["RAT_67_TRANS_DATE"]),
					_originalRat_67_trans_amt = ConvertDEC(Reader["RAT_67_TRANS_AMT"]),
					_originalRat_67_trans_message = Reader["RAT_67_TRANS_MESSAGE"].ToString(),
					_originalRat_67_total_clinic_amt = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]),
					_originalRat_67_amt_bill = ConvertDEC(Reader["RAT_67_AMT_BILL"]),
					_originalRat_67_amt_paid = ConvertDEC(Reader["RAT_67_AMT_PAID"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public U030_TAPE_67_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<U030_TAPE_67_FILE> Collection(ObservableCollection<U030_TAPE_67_FILE>
                                                               u030Tape67File = null)
        {
            if (IsSameSearch() && u030Tape67File != null)
            {
                return u030Tape67File;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<U030_TAPE_67_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RAT_67_AMT_CLAIMS_ADJ",WhereRat_67_amt_claims_adj),
					new SqlParameter("RAT_67_AMT_ADVANCES",WhereRat_67_amt_advances),
					new SqlParameter("RAT_67_AMT_REDUCTIONS",WhereRat_67_amt_reductions),
					new SqlParameter("RAT_67_AMT_DEDUCTIONS",WhereRat_67_amt_deductions),
					new SqlParameter("RAT_67_TRANS_CD",WhereRat_67_trans_cd),
					new SqlParameter("RAT_67_CHEQUE_IND",WhereRat_67_cheque_ind),
					new SqlParameter("RAT_67_TRANS_DATE",WhereRat_67_trans_date),
					new SqlParameter("RAT_67_TRANS_AMT",WhereRat_67_trans_amt),
					new SqlParameter("RAT_67_TRANS_MESSAGE",WhereRat_67_trans_message),
					new SqlParameter("RAT_67_TOTAL_CLINIC_AMT",WhereRat_67_total_clinic_amt),
					new SqlParameter("RAT_67_AMT_BILL",WhereRat_67_amt_bill),
					new SqlParameter("RAT_67_AMT_PAID",WhereRat_67_amt_paid),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Match]", parameters);
            var collection = new ObservableCollection<U030_TAPE_67_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U030_TAPE_67_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_67_AMT_CLAIMS_ADJ = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]),
					RAT_67_AMT_ADVANCES = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]),
					RAT_67_AMT_REDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]),
					RAT_67_AMT_DEDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]),
					RAT_67_TRANS_CD = Reader["RAT_67_TRANS_CD"].ToString(),
					RAT_67_CHEQUE_IND = Reader["RAT_67_CHEQUE_IND"].ToString(),
					RAT_67_TRANS_DATE = ConvertDEC(Reader["RAT_67_TRANS_DATE"]),
					RAT_67_TRANS_AMT = ConvertDEC(Reader["RAT_67_TRANS_AMT"]),
					RAT_67_TRANS_MESSAGE = Reader["RAT_67_TRANS_MESSAGE"].ToString(),
					RAT_67_TOTAL_CLINIC_AMT = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]),
					RAT_67_AMT_BILL = ConvertDEC(Reader["RAT_67_AMT_BILL"]),
					RAT_67_AMT_PAID = ConvertDEC(Reader["RAT_67_AMT_PAID"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRat_67_amt_claims_adj = WhereRat_67_amt_claims_adj,
					_whereRat_67_amt_advances = WhereRat_67_amt_advances,
					_whereRat_67_amt_reductions = WhereRat_67_amt_reductions,
					_whereRat_67_amt_deductions = WhereRat_67_amt_deductions,
					_whereRat_67_trans_cd = WhereRat_67_trans_cd,
					_whereRat_67_cheque_ind = WhereRat_67_cheque_ind,
					_whereRat_67_trans_date = WhereRat_67_trans_date,
					_whereRat_67_trans_amt = WhereRat_67_trans_amt,
					_whereRat_67_trans_message = WhereRat_67_trans_message,
					_whereRat_67_total_clinic_amt = WhereRat_67_total_clinic_amt,
					_whereRat_67_amt_bill = WhereRat_67_amt_bill,
					_whereRat_67_amt_paid = WhereRat_67_amt_paid,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_67_amt_claims_adj = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]),
					_originalRat_67_amt_advances = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]),
					_originalRat_67_amt_reductions = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]),
					_originalRat_67_amt_deductions = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]),
					_originalRat_67_trans_cd = Reader["RAT_67_TRANS_CD"].ToString(),
					_originalRat_67_cheque_ind = Reader["RAT_67_CHEQUE_IND"].ToString(),
					_originalRat_67_trans_date = ConvertDEC(Reader["RAT_67_TRANS_DATE"]),
					_originalRat_67_trans_amt = ConvertDEC(Reader["RAT_67_TRANS_AMT"]),
					_originalRat_67_trans_message = Reader["RAT_67_TRANS_MESSAGE"].ToString(),
					_originalRat_67_total_clinic_amt = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]),
					_originalRat_67_amt_bill = ConvertDEC(Reader["RAT_67_AMT_BILL"]),
					_originalRat_67_amt_paid = ConvertDEC(Reader["RAT_67_AMT_PAID"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRat_67_amt_claims_adj = WhereRat_67_amt_claims_adj;
					_whereRat_67_amt_advances = WhereRat_67_amt_advances;
					_whereRat_67_amt_reductions = WhereRat_67_amt_reductions;
					_whereRat_67_amt_deductions = WhereRat_67_amt_deductions;
					_whereRat_67_trans_cd = WhereRat_67_trans_cd;
					_whereRat_67_cheque_ind = WhereRat_67_cheque_ind;
					_whereRat_67_trans_date = WhereRat_67_trans_date;
					_whereRat_67_trans_amt = WhereRat_67_trans_amt;
					_whereRat_67_trans_message = WhereRat_67_trans_message;
					_whereRat_67_total_clinic_amt = WhereRat_67_total_clinic_amt;
					_whereRat_67_amt_bill = WhereRat_67_amt_bill;
					_whereRat_67_amt_paid = WhereRat_67_amt_paid;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRat_67_amt_claims_adj == null 
				&& WhereRat_67_amt_advances == null 
				&& WhereRat_67_amt_reductions == null 
				&& WhereRat_67_amt_deductions == null 
				&& WhereRat_67_trans_cd == null 
				&& WhereRat_67_cheque_ind == null 
				&& WhereRat_67_trans_date == null 
				&& WhereRat_67_trans_amt == null 
				&& WhereRat_67_trans_message == null 
				&& WhereRat_67_total_clinic_amt == null 
				&& WhereRat_67_amt_bill == null 
				&& WhereRat_67_amt_paid == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRat_67_amt_claims_adj ==  _whereRat_67_amt_claims_adj
				&& WhereRat_67_amt_advances ==  _whereRat_67_amt_advances
				&& WhereRat_67_amt_reductions ==  _whereRat_67_amt_reductions
				&& WhereRat_67_amt_deductions ==  _whereRat_67_amt_deductions
				&& WhereRat_67_trans_cd ==  _whereRat_67_trans_cd
				&& WhereRat_67_cheque_ind ==  _whereRat_67_cheque_ind
				&& WhereRat_67_trans_date ==  _whereRat_67_trans_date
				&& WhereRat_67_trans_amt ==  _whereRat_67_trans_amt
				&& WhereRat_67_trans_message ==  _whereRat_67_trans_message
				&& WhereRat_67_total_clinic_amt ==  _whereRat_67_total_clinic_amt
				&& WhereRat_67_amt_bill ==  _whereRat_67_amt_bill
				&& WhereRat_67_amt_paid ==  _whereRat_67_amt_paid
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRat_67_amt_claims_adj = null; 
			WhereRat_67_amt_advances = null; 
			WhereRat_67_amt_reductions = null; 
			WhereRat_67_amt_deductions = null; 
			WhereRat_67_trans_cd = null; 
			WhereRat_67_cheque_ind = null; 
			WhereRat_67_trans_date = null; 
			WhereRat_67_trans_amt = null; 
			WhereRat_67_trans_message = null; 
			WhereRat_67_total_clinic_amt = null; 
			WhereRat_67_amt_bill = null; 
			WhereRat_67_amt_paid = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _RAT_67_AMT_CLAIMS_ADJ;
		private decimal? _RAT_67_AMT_ADVANCES;
		private decimal? _RAT_67_AMT_REDUCTIONS;
		private decimal? _RAT_67_AMT_DEDUCTIONS;
		private string _RAT_67_TRANS_CD;
		private string _RAT_67_CHEQUE_IND;
		private decimal? _RAT_67_TRANS_DATE;
		private decimal? _RAT_67_TRANS_AMT;
		private string _RAT_67_TRANS_MESSAGE;
		private decimal? _RAT_67_TOTAL_CLINIC_AMT;
		private decimal? _RAT_67_AMT_BILL;
		private decimal? _RAT_67_AMT_PAID;
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
		public decimal? RAT_67_AMT_CLAIMS_ADJ
		{
			get { return _RAT_67_AMT_CLAIMS_ADJ; }
			set
			{
				if (_RAT_67_AMT_CLAIMS_ADJ != value)
				{
					_RAT_67_AMT_CLAIMS_ADJ = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_AMT_ADVANCES
		{
			get { return _RAT_67_AMT_ADVANCES; }
			set
			{
				if (_RAT_67_AMT_ADVANCES != value)
				{
					_RAT_67_AMT_ADVANCES = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_AMT_REDUCTIONS
		{
			get { return _RAT_67_AMT_REDUCTIONS; }
			set
			{
				if (_RAT_67_AMT_REDUCTIONS != value)
				{
					_RAT_67_AMT_REDUCTIONS = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_AMT_DEDUCTIONS
		{
			get { return _RAT_67_AMT_DEDUCTIONS; }
			set
			{
				if (_RAT_67_AMT_DEDUCTIONS != value)
				{
					_RAT_67_AMT_DEDUCTIONS = value;
					ChangeState();
				}
			}
		}
		public string RAT_67_TRANS_CD
		{
			get { return _RAT_67_TRANS_CD; }
			set
			{
				if (_RAT_67_TRANS_CD != value)
				{
					_RAT_67_TRANS_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_67_CHEQUE_IND
		{
			get { return _RAT_67_CHEQUE_IND; }
			set
			{
				if (_RAT_67_CHEQUE_IND != value)
				{
					_RAT_67_CHEQUE_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_TRANS_DATE
		{
			get { return _RAT_67_TRANS_DATE; }
			set
			{
				if (_RAT_67_TRANS_DATE != value)
				{
					_RAT_67_TRANS_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_TRANS_AMT
		{
			get { return _RAT_67_TRANS_AMT; }
			set
			{
				if (_RAT_67_TRANS_AMT != value)
				{
					_RAT_67_TRANS_AMT = value;
					ChangeState();
				}
			}
		}
		public string RAT_67_TRANS_MESSAGE
		{
			get { return _RAT_67_TRANS_MESSAGE; }
			set
			{
				if (_RAT_67_TRANS_MESSAGE != value)
				{
					_RAT_67_TRANS_MESSAGE = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_TOTAL_CLINIC_AMT
		{
			get { return _RAT_67_TOTAL_CLINIC_AMT; }
			set
			{
				if (_RAT_67_TOTAL_CLINIC_AMT != value)
				{
					_RAT_67_TOTAL_CLINIC_AMT = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_AMT_BILL
		{
			get { return _RAT_67_AMT_BILL; }
			set
			{
				if (_RAT_67_AMT_BILL != value)
				{
					_RAT_67_AMT_BILL = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_67_AMT_PAID
		{
			get { return _RAT_67_AMT_PAID; }
			set
			{
				if (_RAT_67_AMT_PAID != value)
				{
					_RAT_67_AMT_PAID = value;
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
		public decimal? WhereRat_67_amt_claims_adj { get; set; }
		private decimal? _whereRat_67_amt_claims_adj;
		public decimal? WhereRat_67_amt_advances { get; set; }
		private decimal? _whereRat_67_amt_advances;
		public decimal? WhereRat_67_amt_reductions { get; set; }
		private decimal? _whereRat_67_amt_reductions;
		public decimal? WhereRat_67_amt_deductions { get; set; }
		private decimal? _whereRat_67_amt_deductions;
		public string WhereRat_67_trans_cd { get; set; }
		private string _whereRat_67_trans_cd;
		public string WhereRat_67_cheque_ind { get; set; }
		private string _whereRat_67_cheque_ind;
		public decimal? WhereRat_67_trans_date { get; set; }
		private decimal? _whereRat_67_trans_date;
		public decimal? WhereRat_67_trans_amt { get; set; }
		private decimal? _whereRat_67_trans_amt;
		public string WhereRat_67_trans_message { get; set; }
		private string _whereRat_67_trans_message;
		public decimal? WhereRat_67_total_clinic_amt { get; set; }
		private decimal? _whereRat_67_total_clinic_amt;
		public decimal? WhereRat_67_amt_bill { get; set; }
		private decimal? _whereRat_67_amt_bill;
		public decimal? WhereRat_67_amt_paid { get; set; }
		private decimal? _whereRat_67_amt_paid;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalRat_67_amt_claims_adj;
		private decimal? _originalRat_67_amt_advances;
		private decimal? _originalRat_67_amt_reductions;
		private decimal? _originalRat_67_amt_deductions;
		private string _originalRat_67_trans_cd;
		private string _originalRat_67_cheque_ind;
		private decimal? _originalRat_67_trans_date;
		private decimal? _originalRat_67_trans_amt;
		private string _originalRat_67_trans_message;
		private decimal? _originalRat_67_total_clinic_amt;
		private decimal? _originalRat_67_amt_bill;
		private decimal? _originalRat_67_amt_paid;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RAT_67_AMT_CLAIMS_ADJ = _originalRat_67_amt_claims_adj;
			RAT_67_AMT_ADVANCES = _originalRat_67_amt_advances;
			RAT_67_AMT_REDUCTIONS = _originalRat_67_amt_reductions;
			RAT_67_AMT_DEDUCTIONS = _originalRat_67_amt_deductions;
			RAT_67_TRANS_CD = _originalRat_67_trans_cd;
			RAT_67_CHEQUE_IND = _originalRat_67_cheque_ind;
			RAT_67_TRANS_DATE = _originalRat_67_trans_date;
			RAT_67_TRANS_AMT = _originalRat_67_trans_amt;
			RAT_67_TRANS_MESSAGE = _originalRat_67_trans_message;
			RAT_67_TOTAL_CLINIC_AMT = _originalRat_67_total_clinic_amt;
			RAT_67_AMT_BILL = _originalRat_67_amt_bill;
			RAT_67_AMT_PAID = _originalRat_67_amt_paid;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Purge]");
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
						new SqlParameter("RAT_67_AMT_CLAIMS_ADJ", SqlNull(RAT_67_AMT_CLAIMS_ADJ)),
						new SqlParameter("RAT_67_AMT_ADVANCES", SqlNull(RAT_67_AMT_ADVANCES)),
						new SqlParameter("RAT_67_AMT_REDUCTIONS", SqlNull(RAT_67_AMT_REDUCTIONS)),
						new SqlParameter("RAT_67_AMT_DEDUCTIONS", SqlNull(RAT_67_AMT_DEDUCTIONS)),
						new SqlParameter("RAT_67_TRANS_CD", SqlNull(RAT_67_TRANS_CD)),
						new SqlParameter("RAT_67_CHEQUE_IND", SqlNull(RAT_67_CHEQUE_IND)),
						new SqlParameter("RAT_67_TRANS_DATE", SqlNull(RAT_67_TRANS_DATE)),
						new SqlParameter("RAT_67_TRANS_AMT", SqlNull(RAT_67_TRANS_AMT)),
						new SqlParameter("RAT_67_TRANS_MESSAGE", SqlNull(RAT_67_TRANS_MESSAGE)),
						new SqlParameter("RAT_67_TOTAL_CLINIC_AMT", SqlNull(RAT_67_TOTAL_CLINIC_AMT)),
						new SqlParameter("RAT_67_AMT_BILL", SqlNull(RAT_67_AMT_BILL)),
						new SqlParameter("RAT_67_AMT_PAID", SqlNull(RAT_67_AMT_PAID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_67_AMT_CLAIMS_ADJ = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]);
						RAT_67_AMT_ADVANCES = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]);
						RAT_67_AMT_REDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]);
						RAT_67_AMT_DEDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]);
						RAT_67_TRANS_CD = Reader["RAT_67_TRANS_CD"].ToString();
						RAT_67_CHEQUE_IND = Reader["RAT_67_CHEQUE_IND"].ToString();
						RAT_67_TRANS_DATE = ConvertDEC(Reader["RAT_67_TRANS_DATE"]);
						RAT_67_TRANS_AMT = ConvertDEC(Reader["RAT_67_TRANS_AMT"]);
						RAT_67_TRANS_MESSAGE = Reader["RAT_67_TRANS_MESSAGE"].ToString();
						RAT_67_TOTAL_CLINIC_AMT = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]);
						RAT_67_AMT_BILL = ConvertDEC(Reader["RAT_67_AMT_BILL"]);
						RAT_67_AMT_PAID = ConvertDEC(Reader["RAT_67_AMT_PAID"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_67_amt_claims_adj = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]);
						_originalRat_67_amt_advances = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]);
						_originalRat_67_amt_reductions = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]);
						_originalRat_67_amt_deductions = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]);
						_originalRat_67_trans_cd = Reader["RAT_67_TRANS_CD"].ToString();
						_originalRat_67_cheque_ind = Reader["RAT_67_CHEQUE_IND"].ToString();
						_originalRat_67_trans_date = ConvertDEC(Reader["RAT_67_TRANS_DATE"]);
						_originalRat_67_trans_amt = ConvertDEC(Reader["RAT_67_TRANS_AMT"]);
						_originalRat_67_trans_message = Reader["RAT_67_TRANS_MESSAGE"].ToString();
						_originalRat_67_total_clinic_amt = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]);
						_originalRat_67_amt_bill = ConvertDEC(Reader["RAT_67_AMT_BILL"]);
						_originalRat_67_amt_paid = ConvertDEC(Reader["RAT_67_AMT_PAID"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RAT_67_AMT_CLAIMS_ADJ", SqlNull(RAT_67_AMT_CLAIMS_ADJ)),
						new SqlParameter("RAT_67_AMT_ADVANCES", SqlNull(RAT_67_AMT_ADVANCES)),
						new SqlParameter("RAT_67_AMT_REDUCTIONS", SqlNull(RAT_67_AMT_REDUCTIONS)),
						new SqlParameter("RAT_67_AMT_DEDUCTIONS", SqlNull(RAT_67_AMT_DEDUCTIONS)),
						new SqlParameter("RAT_67_TRANS_CD", SqlNull(RAT_67_TRANS_CD)),
						new SqlParameter("RAT_67_CHEQUE_IND", SqlNull(RAT_67_CHEQUE_IND)),
						new SqlParameter("RAT_67_TRANS_DATE", SqlNull(RAT_67_TRANS_DATE)),
						new SqlParameter("RAT_67_TRANS_AMT", SqlNull(RAT_67_TRANS_AMT)),
						new SqlParameter("RAT_67_TRANS_MESSAGE", SqlNull(RAT_67_TRANS_MESSAGE)),
						new SqlParameter("RAT_67_TOTAL_CLINIC_AMT", SqlNull(RAT_67_TOTAL_CLINIC_AMT)),
						new SqlParameter("RAT_67_AMT_BILL", SqlNull(RAT_67_AMT_BILL)),
						new SqlParameter("RAT_67_AMT_PAID", SqlNull(RAT_67_AMT_PAID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_67_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_67_AMT_CLAIMS_ADJ = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]);
						RAT_67_AMT_ADVANCES = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]);
						RAT_67_AMT_REDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]);
						RAT_67_AMT_DEDUCTIONS = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]);
						RAT_67_TRANS_CD = Reader["RAT_67_TRANS_CD"].ToString();
						RAT_67_CHEQUE_IND = Reader["RAT_67_CHEQUE_IND"].ToString();
						RAT_67_TRANS_DATE = ConvertDEC(Reader["RAT_67_TRANS_DATE"]);
						RAT_67_TRANS_AMT = ConvertDEC(Reader["RAT_67_TRANS_AMT"]);
						RAT_67_TRANS_MESSAGE = Reader["RAT_67_TRANS_MESSAGE"].ToString();
						RAT_67_TOTAL_CLINIC_AMT = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]);
						RAT_67_AMT_BILL = ConvertDEC(Reader["RAT_67_AMT_BILL"]);
						RAT_67_AMT_PAID = ConvertDEC(Reader["RAT_67_AMT_PAID"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_67_amt_claims_adj = ConvertDEC(Reader["RAT_67_AMT_CLAIMS_ADJ"]);
						_originalRat_67_amt_advances = ConvertDEC(Reader["RAT_67_AMT_ADVANCES"]);
						_originalRat_67_amt_reductions = ConvertDEC(Reader["RAT_67_AMT_REDUCTIONS"]);
						_originalRat_67_amt_deductions = ConvertDEC(Reader["RAT_67_AMT_DEDUCTIONS"]);
						_originalRat_67_trans_cd = Reader["RAT_67_TRANS_CD"].ToString();
						_originalRat_67_cheque_ind = Reader["RAT_67_CHEQUE_IND"].ToString();
						_originalRat_67_trans_date = ConvertDEC(Reader["RAT_67_TRANS_DATE"]);
						_originalRat_67_trans_amt = ConvertDEC(Reader["RAT_67_TRANS_AMT"]);
						_originalRat_67_trans_message = Reader["RAT_67_TRANS_MESSAGE"].ToString();
						_originalRat_67_total_clinic_amt = ConvertDEC(Reader["RAT_67_TOTAL_CLINIC_AMT"]);
						_originalRat_67_amt_bill = ConvertDEC(Reader["RAT_67_AMT_BILL"]);
						_originalRat_67_amt_paid = ConvertDEC(Reader["RAT_67_AMT_PAID"]);
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