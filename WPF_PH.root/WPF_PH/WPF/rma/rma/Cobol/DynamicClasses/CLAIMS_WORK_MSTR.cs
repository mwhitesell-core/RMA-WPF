using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CLAIMS_WORK_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CLAIMS_WORK_MSTR> Collection( Guid? rowid,
															decimal? dept_nbrmin,
															decimal? dept_nbrmax,
															string appti_fd_record_status,
															decimal? agent_cdmin,
															decimal? agent_cdmax,
															decimal? adj_agent_cdmin,
															decimal? adj_agent_cdmax,
															string clmhdr_pat_acronym,
															string filler_brad1,
															string claim_nbr_brad,
															string ohip_status,
															string filler_brad2,
															decimal? fee_omamin,
															decimal? fee_omamax,
															decimal? fee_ohipmin,
															decimal? fee_ohipmax,
															decimal? fee_paidmin,
															decimal? fee_paidmax,
															decimal? fee_duemin,
															decimal? fee_duemax,
															decimal? pedmin,
															decimal? pedmax,
															string service_date,
															string filler_brad3,
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
					new SqlParameter("minDEPT_NBR",dept_nbrmin),
					new SqlParameter("maxDEPT_NBR",dept_nbrmax),
					new SqlParameter("APPTI_FD_RECORD_STATUS",appti_fd_record_status),
					new SqlParameter("minAGENT_CD",agent_cdmin),
					new SqlParameter("maxAGENT_CD",agent_cdmax),
					new SqlParameter("minADJ_AGENT_CD",adj_agent_cdmin),
					new SqlParameter("maxADJ_AGENT_CD",adj_agent_cdmax),
					new SqlParameter("CLMHDR_PAT_ACRONYM",clmhdr_pat_acronym),
					new SqlParameter("FILLER_BRAD1",filler_brad1),
					new SqlParameter("CLAIM_NBR_BRAD",claim_nbr_brad),
					new SqlParameter("OHIP_STATUS",ohip_status),
					new SqlParameter("FILLER_BRAD2",filler_brad2),
					new SqlParameter("minFEE_OMA",fee_omamin),
					new SqlParameter("maxFEE_OMA",fee_omamax),
					new SqlParameter("minFEE_OHIP",fee_ohipmin),
					new SqlParameter("maxFEE_OHIP",fee_ohipmax),
					new SqlParameter("minFEE_PAID",fee_paidmin),
					new SqlParameter("maxFEE_PAID",fee_paidmax),
					new SqlParameter("minFEE_DUE",fee_duemin),
					new SqlParameter("maxFEE_DUE",fee_duemax),
					new SqlParameter("minPED",pedmin),
					new SqlParameter("maxPED",pedmax),
					new SqlParameter("SERVICE_DATE",service_date),
					new SqlParameter("FILLER_BRAD3",filler_brad3),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CLAIMS_WORK_MSTR>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_Search]", parameters);
            var collection = new ObservableCollection<CLAIMS_WORK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new CLAIMS_WORK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					APPTI_FD_RECORD_STATUS = Reader["APPTI_FD_RECORD_STATUS"].ToString(),
					AGENT_CD = ConvertDEC(Reader["AGENT_CD"]),
					ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					FILLER_BRAD1 = Reader["FILLER_BRAD1"].ToString(),
					CLAIM_NBR_BRAD = Reader["CLAIM_NBR_BRAD"].ToString(),
					OHIP_STATUS = Reader["OHIP_STATUS"].ToString(),
					FILLER_BRAD2 = Reader["FILLER_BRAD2"].ToString(),
					FEE_OMA = ConvertDEC(Reader["FEE_OMA"]),
					FEE_OHIP = ConvertDEC(Reader["FEE_OHIP"]),
					FEE_PAID = ConvertDEC(Reader["FEE_PAID"]),
					FEE_DUE = ConvertDEC(Reader["FEE_DUE"]),
					PED = ConvertDEC(Reader["PED"]),
					SERVICE_DATE = Reader["SERVICE_DATE"].ToString(),
					FILLER_BRAD3 = Reader["FILLER_BRAD3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalAppti_fd_record_status = Reader["APPTI_FD_RECORD_STATUS"].ToString(),
					_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]),
					_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalFiller_brad1 = Reader["FILLER_BRAD1"].ToString(),
					_originalClaim_nbr_brad = Reader["CLAIM_NBR_BRAD"].ToString(),
					_originalOhip_status = Reader["OHIP_STATUS"].ToString(),
					_originalFiller_brad2 = Reader["FILLER_BRAD2"].ToString(),
					_originalFee_oma = ConvertDEC(Reader["FEE_OMA"]),
					_originalFee_ohip = ConvertDEC(Reader["FEE_OHIP"]),
					_originalFee_paid = ConvertDEC(Reader["FEE_PAID"]),
					_originalFee_due = ConvertDEC(Reader["FEE_DUE"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalService_date = Reader["SERVICE_DATE"].ToString(),
					_originalFiller_brad3 = Reader["FILLER_BRAD3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CLAIMS_WORK_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CLAIMS_WORK_MSTR> Collection(ObservableCollection<CLAIMS_WORK_MSTR>
                                                               claimsWorkMstr = null)
        {
            if (IsSameSearch() && claimsWorkMstr != null)
            {
                return claimsWorkMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CLAIMS_WORK_MSTR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DEPT_NBR",WhereDept_nbr),
					new SqlParameter("APPTI_FD_RECORD_STATUS",WhereAppti_fd_record_status),
					new SqlParameter("AGENT_CD",WhereAgent_cd),
					new SqlParameter("ADJ_AGENT_CD",WhereAdj_agent_cd),
					new SqlParameter("CLMHDR_PAT_ACRONYM",WhereClmhdr_pat_acronym),
					new SqlParameter("FILLER_BRAD1",WhereFiller_brad1),
					new SqlParameter("CLAIM_NBR_BRAD",WhereClaim_nbr_brad),
					new SqlParameter("OHIP_STATUS",WhereOhip_status),
					new SqlParameter("FILLER_BRAD2",WhereFiller_brad2),
					new SqlParameter("FEE_OMA",WhereFee_oma),
					new SqlParameter("FEE_OHIP",WhereFee_ohip),
					new SqlParameter("FEE_PAID",WhereFee_paid),
					new SqlParameter("FEE_DUE",WhereFee_due),
					new SqlParameter("PED",WherePed),
					new SqlParameter("SERVICE_DATE",WhereService_date),
					new SqlParameter("FILLER_BRAD3",WhereFiller_brad3),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_Match]", parameters);
            var collection = new ObservableCollection<CLAIMS_WORK_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new CLAIMS_WORK_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]),
					APPTI_FD_RECORD_STATUS = Reader["APPTI_FD_RECORD_STATUS"].ToString(),
					AGENT_CD = ConvertDEC(Reader["AGENT_CD"]),
					ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					FILLER_BRAD1 = Reader["FILLER_BRAD1"].ToString(),
					CLAIM_NBR_BRAD = Reader["CLAIM_NBR_BRAD"].ToString(),
					OHIP_STATUS = Reader["OHIP_STATUS"].ToString(),
					FILLER_BRAD2 = Reader["FILLER_BRAD2"].ToString(),
					FEE_OMA = ConvertDEC(Reader["FEE_OMA"]),
					FEE_OHIP = ConvertDEC(Reader["FEE_OHIP"]),
					FEE_PAID = ConvertDEC(Reader["FEE_PAID"]),
					FEE_DUE = ConvertDEC(Reader["FEE_DUE"]),
					PED = ConvertDEC(Reader["PED"]),
					SERVICE_DATE = Reader["SERVICE_DATE"].ToString(),
					FILLER_BRAD3 = Reader["FILLER_BRAD3"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDept_nbr = WhereDept_nbr,
					_whereAppti_fd_record_status = WhereAppti_fd_record_status,
					_whereAgent_cd = WhereAgent_cd,
					_whereAdj_agent_cd = WhereAdj_agent_cd,
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym,
					_whereFiller_brad1 = WhereFiller_brad1,
					_whereClaim_nbr_brad = WhereClaim_nbr_brad,
					_whereOhip_status = WhereOhip_status,
					_whereFiller_brad2 = WhereFiller_brad2,
					_whereFee_oma = WhereFee_oma,
					_whereFee_ohip = WhereFee_ohip,
					_whereFee_paid = WhereFee_paid,
					_whereFee_due = WhereFee_due,
					_wherePed = WherePed,
					_whereService_date = WhereService_date,
					_whereFiller_brad3 = WhereFiller_brad3,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]),
					_originalAppti_fd_record_status = Reader["APPTI_FD_RECORD_STATUS"].ToString(),
					_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]),
					_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]),
					_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString(),
					_originalFiller_brad1 = Reader["FILLER_BRAD1"].ToString(),
					_originalClaim_nbr_brad = Reader["CLAIM_NBR_BRAD"].ToString(),
					_originalOhip_status = Reader["OHIP_STATUS"].ToString(),
					_originalFiller_brad2 = Reader["FILLER_BRAD2"].ToString(),
					_originalFee_oma = ConvertDEC(Reader["FEE_OMA"]),
					_originalFee_ohip = ConvertDEC(Reader["FEE_OHIP"]),
					_originalFee_paid = ConvertDEC(Reader["FEE_PAID"]),
					_originalFee_due = ConvertDEC(Reader["FEE_DUE"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalService_date = Reader["SERVICE_DATE"].ToString(),
					_originalFiller_brad3 = Reader["FILLER_BRAD3"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDept_nbr = WhereDept_nbr;
					_whereAppti_fd_record_status = WhereAppti_fd_record_status;
					_whereAgent_cd = WhereAgent_cd;
					_whereAdj_agent_cd = WhereAdj_agent_cd;
					_whereClmhdr_pat_acronym = WhereClmhdr_pat_acronym;
					_whereFiller_brad1 = WhereFiller_brad1;
					_whereClaim_nbr_brad = WhereClaim_nbr_brad;
					_whereOhip_status = WhereOhip_status;
					_whereFiller_brad2 = WhereFiller_brad2;
					_whereFee_oma = WhereFee_oma;
					_whereFee_ohip = WhereFee_ohip;
					_whereFee_paid = WhereFee_paid;
					_whereFee_due = WhereFee_due;
					_wherePed = WherePed;
					_whereService_date = WhereService_date;
					_whereFiller_brad3 = WhereFiller_brad3;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDept_nbr == null 
				&& WhereAppti_fd_record_status == null 
				&& WhereAgent_cd == null 
				&& WhereAdj_agent_cd == null 
				&& WhereClmhdr_pat_acronym == null 
				&& WhereFiller_brad1 == null 
				&& WhereClaim_nbr_brad == null 
				&& WhereOhip_status == null 
				&& WhereFiller_brad2 == null 
				&& WhereFee_oma == null 
				&& WhereFee_ohip == null 
				&& WhereFee_paid == null 
				&& WhereFee_due == null 
				&& WherePed == null 
				&& WhereService_date == null 
				&& WhereFiller_brad3 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDept_nbr ==  _whereDept_nbr
				&& WhereAppti_fd_record_status ==  _whereAppti_fd_record_status
				&& WhereAgent_cd ==  _whereAgent_cd
				&& WhereAdj_agent_cd ==  _whereAdj_agent_cd
				&& WhereClmhdr_pat_acronym ==  _whereClmhdr_pat_acronym
				&& WhereFiller_brad1 ==  _whereFiller_brad1
				&& WhereClaim_nbr_brad ==  _whereClaim_nbr_brad
				&& WhereOhip_status ==  _whereOhip_status
				&& WhereFiller_brad2 ==  _whereFiller_brad2
				&& WhereFee_oma ==  _whereFee_oma
				&& WhereFee_ohip ==  _whereFee_ohip
				&& WhereFee_paid ==  _whereFee_paid
				&& WhereFee_due ==  _whereFee_due
				&& WherePed ==  _wherePed
				&& WhereService_date ==  _whereService_date
				&& WhereFiller_brad3 ==  _whereFiller_brad3
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDept_nbr = null; 
			WhereAppti_fd_record_status = null; 
			WhereAgent_cd = null; 
			WhereAdj_agent_cd = null; 
			WhereClmhdr_pat_acronym = null; 
			WhereFiller_brad1 = null; 
			WhereClaim_nbr_brad = null; 
			WhereOhip_status = null; 
			WhereFiller_brad2 = null; 
			WhereFee_oma = null; 
			WhereFee_ohip = null; 
			WhereFee_paid = null; 
			WhereFee_due = null; 
			WherePed = null; 
			WhereService_date = null; 
			WhereFiller_brad3 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DEPT_NBR;
		private string _APPTI_FD_RECORD_STATUS;
		private decimal? _AGENT_CD;
		private decimal? _ADJ_AGENT_CD;
		private string _CLMHDR_PAT_ACRONYM;
		private string _FILLER_BRAD1;
		private string _CLAIM_NBR_BRAD;
		private string _OHIP_STATUS;
		private string _FILLER_BRAD2;
		private decimal? _FEE_OMA;
		private decimal? _FEE_OHIP;
		private decimal? _FEE_PAID;
		private decimal? _FEE_DUE;
		private decimal? _PED;
		private string _SERVICE_DATE;
		private string _FILLER_BRAD3;
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
		public decimal? DEPT_NBR
		{
			get { return _DEPT_NBR; }
			set
			{
				if (_DEPT_NBR != value)
				{
					_DEPT_NBR = value;
					ChangeState();
				}
			}
		}
		public string APPTI_FD_RECORD_STATUS
		{
			get { return _APPTI_FD_RECORD_STATUS; }
			set
			{
				if (_APPTI_FD_RECORD_STATUS != value)
				{
					_APPTI_FD_RECORD_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? AGENT_CD
		{
			get { return _AGENT_CD; }
			set
			{
				if (_AGENT_CD != value)
				{
					_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? ADJ_AGENT_CD
		{
			get { return _ADJ_AGENT_CD; }
			set
			{
				if (_ADJ_AGENT_CD != value)
				{
					_ADJ_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_ACRONYM
		{
			get { return _CLMHDR_PAT_ACRONYM; }
			set
			{
				if (_CLMHDR_PAT_ACRONYM != value)
				{
					_CLMHDR_PAT_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string FILLER_BRAD1
		{
			get { return _FILLER_BRAD1; }
			set
			{
				if (_FILLER_BRAD1 != value)
				{
					_FILLER_BRAD1 = value;
					ChangeState();
				}
			}
		}
		public string CLAIM_NBR_BRAD
		{
			get { return _CLAIM_NBR_BRAD; }
			set
			{
				if (_CLAIM_NBR_BRAD != value)
				{
					_CLAIM_NBR_BRAD = value;
					ChangeState();
				}
			}
		}
		public string OHIP_STATUS
		{
			get { return _OHIP_STATUS; }
			set
			{
				if (_OHIP_STATUS != value)
				{
					_OHIP_STATUS = value;
					ChangeState();
				}
			}
		}
		public string FILLER_BRAD2
		{
			get { return _FILLER_BRAD2; }
			set
			{
				if (_FILLER_BRAD2 != value)
				{
					_FILLER_BRAD2 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_OMA
		{
			get { return _FEE_OMA; }
			set
			{
				if (_FEE_OMA != value)
				{
					_FEE_OMA = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_OHIP
		{
			get { return _FEE_OHIP; }
			set
			{
				if (_FEE_OHIP != value)
				{
					_FEE_OHIP = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PAID
		{
			get { return _FEE_PAID; }
			set
			{
				if (_FEE_PAID != value)
				{
					_FEE_PAID = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_DUE
		{
			get { return _FEE_DUE; }
			set
			{
				if (_FEE_DUE != value)
				{
					_FEE_DUE = value;
					ChangeState();
				}
			}
		}
		public decimal? PED
		{
			get { return _PED; }
			set
			{
				if (_PED != value)
				{
					_PED = value;
					ChangeState();
				}
			}
		}
		public string SERVICE_DATE
		{
			get { return _SERVICE_DATE; }
			set
			{
				if (_SERVICE_DATE != value)
				{
					_SERVICE_DATE = value;
					ChangeState();
				}
			}
		}
		public string FILLER_BRAD3
		{
			get { return _FILLER_BRAD3; }
			set
			{
				if (_FILLER_BRAD3 != value)
				{
					_FILLER_BRAD3 = value;
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
		public decimal? WhereDept_nbr { get; set; }
		private decimal? _whereDept_nbr;
		public string WhereAppti_fd_record_status { get; set; }
		private string _whereAppti_fd_record_status;
		public decimal? WhereAgent_cd { get; set; }
		private decimal? _whereAgent_cd;
		public decimal? WhereAdj_agent_cd { get; set; }
		private decimal? _whereAdj_agent_cd;
		public string WhereClmhdr_pat_acronym { get; set; }
		private string _whereClmhdr_pat_acronym;
		public string WhereFiller_brad1 { get; set; }
		private string _whereFiller_brad1;
		public string WhereClaim_nbr_brad { get; set; }
		private string _whereClaim_nbr_brad;
		public string WhereOhip_status { get; set; }
		private string _whereOhip_status;
		public string WhereFiller_brad2 { get; set; }
		private string _whereFiller_brad2;
		public decimal? WhereFee_oma { get; set; }
		private decimal? _whereFee_oma;
		public decimal? WhereFee_ohip { get; set; }
		private decimal? _whereFee_ohip;
		public decimal? WhereFee_paid { get; set; }
		private decimal? _whereFee_paid;
		public decimal? WhereFee_due { get; set; }
		private decimal? _whereFee_due;
		public decimal? WherePed { get; set; }
		private decimal? _wherePed;
		public string WhereService_date { get; set; }
		private string _whereService_date;
		public string WhereFiller_brad3 { get; set; }
		private string _whereFiller_brad3;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDept_nbr;
		private string _originalAppti_fd_record_status;
		private decimal? _originalAgent_cd;
		private decimal? _originalAdj_agent_cd;
		private string _originalClmhdr_pat_acronym;
		private string _originalFiller_brad1;
		private string _originalClaim_nbr_brad;
		private string _originalOhip_status;
		private string _originalFiller_brad2;
		private decimal? _originalFee_oma;
		private decimal? _originalFee_ohip;
		private decimal? _originalFee_paid;
		private decimal? _originalFee_due;
		private decimal? _originalPed;
		private string _originalService_date;
		private string _originalFiller_brad3;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DEPT_NBR = _originalDept_nbr;
			APPTI_FD_RECORD_STATUS = _originalAppti_fd_record_status;
			AGENT_CD = _originalAgent_cd;
			ADJ_AGENT_CD = _originalAdj_agent_cd;
			CLMHDR_PAT_ACRONYM = _originalClmhdr_pat_acronym;
			FILLER_BRAD1 = _originalFiller_brad1;
			CLAIM_NBR_BRAD = _originalClaim_nbr_brad;
			OHIP_STATUS = _originalOhip_status;
			FILLER_BRAD2 = _originalFiller_brad2;
			FEE_OMA = _originalFee_oma;
			FEE_OHIP = _originalFee_ohip;
			FEE_PAID = _originalFee_paid;
			FEE_DUE = _originalFee_due;
			PED = _originalPed;
			SERVICE_DATE = _originalService_date;
			FILLER_BRAD3 = _originalFiller_brad3;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_Purge]");
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
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("APPTI_FD_RECORD_STATUS", SqlNull(APPTI_FD_RECORD_STATUS)),
						new SqlParameter("AGENT_CD", SqlNull(AGENT_CD)),
						new SqlParameter("ADJ_AGENT_CD", SqlNull(ADJ_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("FILLER_BRAD1", SqlNull(FILLER_BRAD1)),
						new SqlParameter("CLAIM_NBR_BRAD", SqlNull(CLAIM_NBR_BRAD)),
						new SqlParameter("OHIP_STATUS", SqlNull(OHIP_STATUS)),
						new SqlParameter("FILLER_BRAD2", SqlNull(FILLER_BRAD2)),
						new SqlParameter("FEE_OMA", SqlNull(FEE_OMA)),
						new SqlParameter("FEE_OHIP", SqlNull(FEE_OHIP)),
						new SqlParameter("FEE_PAID", SqlNull(FEE_PAID)),
						new SqlParameter("FEE_DUE", SqlNull(FEE_DUE)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("SERVICE_DATE", SqlNull(SERVICE_DATE)),
						new SqlParameter("FILLER_BRAD3", SqlNull(FILLER_BRAD3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						APPTI_FD_RECORD_STATUS = Reader["APPTI_FD_RECORD_STATUS"].ToString();
						AGENT_CD = ConvertDEC(Reader["AGENT_CD"]);
						ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						FILLER_BRAD1 = Reader["FILLER_BRAD1"].ToString();
						CLAIM_NBR_BRAD = Reader["CLAIM_NBR_BRAD"].ToString();
						OHIP_STATUS = Reader["OHIP_STATUS"].ToString();
						FILLER_BRAD2 = Reader["FILLER_BRAD2"].ToString();
						FEE_OMA = ConvertDEC(Reader["FEE_OMA"]);
						FEE_OHIP = ConvertDEC(Reader["FEE_OHIP"]);
						FEE_PAID = ConvertDEC(Reader["FEE_PAID"]);
						FEE_DUE = ConvertDEC(Reader["FEE_DUE"]);
						PED = ConvertDEC(Reader["PED"]);
						SERVICE_DATE = Reader["SERVICE_DATE"].ToString();
						FILLER_BRAD3 = Reader["FILLER_BRAD3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalAppti_fd_record_status = Reader["APPTI_FD_RECORD_STATUS"].ToString();
						_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]);
						_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalFiller_brad1 = Reader["FILLER_BRAD1"].ToString();
						_originalClaim_nbr_brad = Reader["CLAIM_NBR_BRAD"].ToString();
						_originalOhip_status = Reader["OHIP_STATUS"].ToString();
						_originalFiller_brad2 = Reader["FILLER_BRAD2"].ToString();
						_originalFee_oma = ConvertDEC(Reader["FEE_OMA"]);
						_originalFee_ohip = ConvertDEC(Reader["FEE_OHIP"]);
						_originalFee_paid = ConvertDEC(Reader["FEE_PAID"]);
						_originalFee_due = ConvertDEC(Reader["FEE_DUE"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalService_date = Reader["SERVICE_DATE"].ToString();
						_originalFiller_brad3 = Reader["FILLER_BRAD3"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DEPT_NBR", SqlNull(DEPT_NBR)),
						new SqlParameter("APPTI_FD_RECORD_STATUS", SqlNull(APPTI_FD_RECORD_STATUS)),
						new SqlParameter("AGENT_CD", SqlNull(AGENT_CD)),
						new SqlParameter("ADJ_AGENT_CD", SqlNull(ADJ_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_ACRONYM", SqlNull(CLMHDR_PAT_ACRONYM)),
						new SqlParameter("FILLER_BRAD1", SqlNull(FILLER_BRAD1)),
						new SqlParameter("CLAIM_NBR_BRAD", SqlNull(CLAIM_NBR_BRAD)),
						new SqlParameter("OHIP_STATUS", SqlNull(OHIP_STATUS)),
						new SqlParameter("FILLER_BRAD2", SqlNull(FILLER_BRAD2)),
						new SqlParameter("FEE_OMA", SqlNull(FEE_OMA)),
						new SqlParameter("FEE_OHIP", SqlNull(FEE_OHIP)),
						new SqlParameter("FEE_PAID", SqlNull(FEE_PAID)),
						new SqlParameter("FEE_DUE", SqlNull(FEE_DUE)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("SERVICE_DATE", SqlNull(SERVICE_DATE)),
						new SqlParameter("FILLER_BRAD3", SqlNull(FILLER_BRAD3)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_WORK_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DEPT_NBR = ConvertDEC(Reader["DEPT_NBR"]);
						APPTI_FD_RECORD_STATUS = Reader["APPTI_FD_RECORD_STATUS"].ToString();
						AGENT_CD = ConvertDEC(Reader["AGENT_CD"]);
						ADJ_AGENT_CD = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						CLMHDR_PAT_ACRONYM = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						FILLER_BRAD1 = Reader["FILLER_BRAD1"].ToString();
						CLAIM_NBR_BRAD = Reader["CLAIM_NBR_BRAD"].ToString();
						OHIP_STATUS = Reader["OHIP_STATUS"].ToString();
						FILLER_BRAD2 = Reader["FILLER_BRAD2"].ToString();
						FEE_OMA = ConvertDEC(Reader["FEE_OMA"]);
						FEE_OHIP = ConvertDEC(Reader["FEE_OHIP"]);
						FEE_PAID = ConvertDEC(Reader["FEE_PAID"]);
						FEE_DUE = ConvertDEC(Reader["FEE_DUE"]);
						PED = ConvertDEC(Reader["PED"]);
						SERVICE_DATE = Reader["SERVICE_DATE"].ToString();
						FILLER_BRAD3 = Reader["FILLER_BRAD3"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDept_nbr = ConvertDEC(Reader["DEPT_NBR"]);
						_originalAppti_fd_record_status = Reader["APPTI_FD_RECORD_STATUS"].ToString();
						_originalAgent_cd = ConvertDEC(Reader["AGENT_CD"]);
						_originalAdj_agent_cd = ConvertDEC(Reader["ADJ_AGENT_CD"]);
						_originalClmhdr_pat_acronym = Reader["CLMHDR_PAT_ACRONYM"].ToString();
						_originalFiller_brad1 = Reader["FILLER_BRAD1"].ToString();
						_originalClaim_nbr_brad = Reader["CLAIM_NBR_BRAD"].ToString();
						_originalOhip_status = Reader["OHIP_STATUS"].ToString();
						_originalFiller_brad2 = Reader["FILLER_BRAD2"].ToString();
						_originalFee_oma = ConvertDEC(Reader["FEE_OMA"]);
						_originalFee_ohip = ConvertDEC(Reader["FEE_OHIP"]);
						_originalFee_paid = ConvertDEC(Reader["FEE_PAID"]);
						_originalFee_due = ConvertDEC(Reader["FEE_DUE"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalService_date = Reader["SERVICE_DATE"].ToString();
						_originalFiller_brad3 = Reader["FILLER_BRAD3"].ToString();
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