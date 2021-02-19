using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class MISC_PAYMENT_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<MISC_PAYMENT_FILE> Collection( Guid? rowid,
															decimal? clinic_nbrmin,
															decimal? clinic_nbrmax,
															string filler,
															string hdr_agent_cd,
															string doc_nbr,
															string doc_name,
															string clmdtl_oma_cd,
															decimal? signed_amt_netmin,
															decimal? signed_amt_netmax,
															string clmhdr_reference,
															string bypass_edit,
															string filler_cr,
															string filler_lf,
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
					new SqlParameter("minCLINIC_NBR",clinic_nbrmin),
					new SqlParameter("maxCLINIC_NBR",clinic_nbrmax),
					new SqlParameter("FILLER",filler),
					new SqlParameter("HDR_AGENT_CD",hdr_agent_cd),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("DOC_NAME",doc_name),
					new SqlParameter("CLMDTL_OMA_CD",clmdtl_oma_cd),
					new SqlParameter("minSIGNED_AMT_NET",signed_amt_netmin),
					new SqlParameter("maxSIGNED_AMT_NET",signed_amt_netmax),
					new SqlParameter("CLMHDR_REFERENCE",clmhdr_reference),
					new SqlParameter("BYPASS_EDIT",bypass_edit),
					new SqlParameter("FILLER_CR",filler_cr),
					new SqlParameter("FILLER_LF",filler_lf),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<MISC_PAYMENT_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_Search]", parameters);
            var collection = new ObservableCollection<MISC_PAYMENT_FILE>();

            while (Reader.Read())
            {
                collection.Add(new MISC_PAYMENT_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					FILLER = Reader["FILLER"].ToString(),
					HDR_AGENT_CD = Reader["HDR_AGENT_CD"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
					BYPASS_EDIT = Reader["BYPASS_EDIT"].ToString(),
					FILLER_CR = Reader["FILLER_CR"].ToString(),
					FILLER_LF = Reader["FILLER_LF"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalHdr_agent_cd = Reader["HDR_AGENT_CD"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalBypass_edit = Reader["BYPASS_EDIT"].ToString(),
					_originalFiller_cr = Reader["FILLER_CR"].ToString(),
					_originalFiller_lf = Reader["FILLER_LF"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public MISC_PAYMENT_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<MISC_PAYMENT_FILE> Collection(ObservableCollection<MISC_PAYMENT_FILE>
                                                               miscPaymentFile = null)
        {
            if (IsSameSearch() && miscPaymentFile != null)
            {
                return miscPaymentFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<MISC_PAYMENT_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLINIC_NBR",WhereClinic_nbr),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("HDR_AGENT_CD",WhereHdr_agent_cd),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_NAME",WhereDoc_name),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("SIGNED_AMT_NET",WhereSigned_amt_net),
					new SqlParameter("CLMHDR_REFERENCE",WhereClmhdr_reference),
					new SqlParameter("BYPASS_EDIT",WhereBypass_edit),
					new SqlParameter("FILLER_CR",WhereFiller_cr),
					new SqlParameter("FILLER_LF",WhereFiller_lf),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_Match]", parameters);
            var collection = new ObservableCollection<MISC_PAYMENT_FILE>();

            while (Reader.Read())
            {
                collection.Add(new MISC_PAYMENT_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]),
					FILLER = Reader["FILLER"].ToString(),
					HDR_AGENT_CD = Reader["HDR_AGENT_CD"].ToString(),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
					BYPASS_EDIT = Reader["BYPASS_EDIT"].ToString(),
					FILLER_CR = Reader["FILLER_CR"].ToString(),
					FILLER_LF = Reader["FILLER_LF"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClinic_nbr = WhereClinic_nbr,
					_whereFiller = WhereFiller,
					_whereHdr_agent_cd = WhereHdr_agent_cd,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_name = WhereDoc_name,
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
					_whereSigned_amt_net = WhereSigned_amt_net,
					_whereClmhdr_reference = WhereClmhdr_reference,
					_whereBypass_edit = WhereBypass_edit,
					_whereFiller_cr = WhereFiller_cr,
					_whereFiller_lf = WhereFiller_lf,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalHdr_agent_cd = Reader["HDR_AGENT_CD"].ToString(),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalBypass_edit = Reader["BYPASS_EDIT"].ToString(),
					_originalFiller_cr = Reader["FILLER_CR"].ToString(),
					_originalFiller_lf = Reader["FILLER_LF"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClinic_nbr = WhereClinic_nbr;
					_whereFiller = WhereFiller;
					_whereHdr_agent_cd = WhereHdr_agent_cd;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_name = WhereDoc_name;
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd;
					_whereSigned_amt_net = WhereSigned_amt_net;
					_whereClmhdr_reference = WhereClmhdr_reference;
					_whereBypass_edit = WhereBypass_edit;
					_whereFiller_cr = WhereFiller_cr;
					_whereFiller_lf = WhereFiller_lf;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClinic_nbr == null 
				&& WhereFiller == null 
				&& WhereHdr_agent_cd == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_name == null 
				&& WhereClmdtl_oma_cd == null 
				&& WhereSigned_amt_net == null 
				&& WhereClmhdr_reference == null 
				&& WhereBypass_edit == null 
				&& WhereFiller_cr == null 
				&& WhereFiller_lf == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClinic_nbr ==  _whereClinic_nbr
				&& WhereFiller ==  _whereFiller
				&& WhereHdr_agent_cd ==  _whereHdr_agent_cd
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_name ==  _whereDoc_name
				&& WhereClmdtl_oma_cd ==  _whereClmdtl_oma_cd
				&& WhereSigned_amt_net ==  _whereSigned_amt_net
				&& WhereClmhdr_reference ==  _whereClmhdr_reference
				&& WhereBypass_edit ==  _whereBypass_edit
				&& WhereFiller_cr ==  _whereFiller_cr
				&& WhereFiller_lf ==  _whereFiller_lf
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClinic_nbr = null; 
			WhereFiller = null; 
			WhereHdr_agent_cd = null; 
			WhereDoc_nbr = null; 
			WhereDoc_name = null; 
			WhereClmdtl_oma_cd = null; 
			WhereSigned_amt_net = null; 
			WhereClmhdr_reference = null; 
			WhereBypass_edit = null; 
			WhereFiller_cr = null; 
			WhereFiller_lf = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CLINIC_NBR;
		private string _FILLER;
		private string _HDR_AGENT_CD;
		private string _DOC_NBR;
		private string _DOC_NAME;
		private string _CLMDTL_OMA_CD;
		private decimal? _SIGNED_AMT_NET;
		private string _CLMHDR_REFERENCE;
		private string _BYPASS_EDIT;
		private string _FILLER_CR;
		private string _FILLER_LF;
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
		public decimal? CLINIC_NBR
		{
			get { return _CLINIC_NBR; }
			set
			{
				if (_CLINIC_NBR != value)
				{
					_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string FILLER
		{
			get { return _FILLER; }
			set
			{
				if (_FILLER != value)
				{
					_FILLER = value;
					ChangeState();
				}
			}
		}
		public string HDR_AGENT_CD
		{
			get { return _HDR_AGENT_CD; }
			set
			{
				if (_HDR_AGENT_CD != value)
				{
					_HDR_AGENT_CD = value;
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
		public string DOC_NAME
		{
			get { return _DOC_NAME; }
			set
			{
				if (_DOC_NAME != value)
				{
					_DOC_NAME = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_OMA_CD
		{
			get { return _CLMDTL_OMA_CD; }
			set
			{
				if (_CLMDTL_OMA_CD != value)
				{
					_CLMDTL_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? SIGNED_AMT_NET
		{
			get { return _SIGNED_AMT_NET; }
			set
			{
				if (_SIGNED_AMT_NET != value)
				{
					_SIGNED_AMT_NET = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_REFERENCE
		{
			get { return _CLMHDR_REFERENCE; }
			set
			{
				if (_CLMHDR_REFERENCE != value)
				{
					_CLMHDR_REFERENCE = value;
					ChangeState();
				}
			}
		}
		public string BYPASS_EDIT
		{
			get { return _BYPASS_EDIT; }
			set
			{
				if (_BYPASS_EDIT != value)
				{
					_BYPASS_EDIT = value;
					ChangeState();
				}
			}
		}
		public string FILLER_CR
		{
			get { return _FILLER_CR; }
			set
			{
				if (_FILLER_CR != value)
				{
					_FILLER_CR = value;
					ChangeState();
				}
			}
		}
		public string FILLER_LF
		{
			get { return _FILLER_LF; }
			set
			{
				if (_FILLER_LF != value)
				{
					_FILLER_LF = value;
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
		public decimal? WhereClinic_nbr { get; set; }
		private decimal? _whereClinic_nbr;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public string WhereHdr_agent_cd { get; set; }
		private string _whereHdr_agent_cd;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public string WhereDoc_name { get; set; }
		private string _whereDoc_name;
		public string WhereClmdtl_oma_cd { get; set; }
		private string _whereClmdtl_oma_cd;
		public decimal? WhereSigned_amt_net { get; set; }
		private decimal? _whereSigned_amt_net;
		public string WhereClmhdr_reference { get; set; }
		private string _whereClmhdr_reference;
		public string WhereBypass_edit { get; set; }
		private string _whereBypass_edit;
		public string WhereFiller_cr { get; set; }
		private string _whereFiller_cr;
		public string WhereFiller_lf { get; set; }
		private string _whereFiller_lf;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalClinic_nbr;
		private string _originalFiller;
		private string _originalHdr_agent_cd;
		private string _originalDoc_nbr;
		private string _originalDoc_name;
		private string _originalClmdtl_oma_cd;
		private decimal? _originalSigned_amt_net;
		private string _originalClmhdr_reference;
		private string _originalBypass_edit;
		private string _originalFiller_cr;
		private string _originalFiller_lf;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLINIC_NBR = _originalClinic_nbr;
			FILLER = _originalFiller;
			HDR_AGENT_CD = _originalHdr_agent_cd;
			DOC_NBR = _originalDoc_nbr;
			DOC_NAME = _originalDoc_name;
			CLMDTL_OMA_CD = _originalClmdtl_oma_cd;
			SIGNED_AMT_NET = _originalSigned_amt_net;
			CLMHDR_REFERENCE = _originalClmhdr_reference;
			BYPASS_EDIT = _originalBypass_edit;
			FILLER_CR = _originalFiller_cr;
			FILLER_LF = _originalFiller_lf;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_Purge]");
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
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("HDR_AGENT_CD", SqlNull(HDR_AGENT_CD)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("SIGNED_AMT_NET", SqlNull(SIGNED_AMT_NET)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("BYPASS_EDIT", SqlNull(BYPASS_EDIT)),
						new SqlParameter("FILLER_CR", SqlNull(FILLER_CR)),
						new SqlParameter("FILLER_LF", SqlNull(FILLER_LF)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						FILLER = Reader["FILLER"].ToString();
						HDR_AGENT_CD = Reader["HDR_AGENT_CD"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						BYPASS_EDIT = Reader["BYPASS_EDIT"].ToString();
						FILLER_CR = Reader["FILLER_CR"].ToString();
						FILLER_LF = Reader["FILLER_LF"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalHdr_agent_cd = Reader["HDR_AGENT_CD"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalBypass_edit = Reader["BYPASS_EDIT"].ToString();
						_originalFiller_cr = Reader["FILLER_CR"].ToString();
						_originalFiller_lf = Reader["FILLER_LF"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLINIC_NBR", SqlNull(CLINIC_NBR)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("HDR_AGENT_CD", SqlNull(HDR_AGENT_CD)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("SIGNED_AMT_NET", SqlNull(SIGNED_AMT_NET)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("BYPASS_EDIT", SqlNull(BYPASS_EDIT)),
						new SqlParameter("FILLER_CR", SqlNull(FILLER_CR)),
						new SqlParameter("FILLER_LF", SqlNull(FILLER_LF)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_MISC_PAYMENT_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLINIC_NBR = ConvertDEC(Reader["CLINIC_NBR"]);
						FILLER = Reader["FILLER"].ToString();
						HDR_AGENT_CD = Reader["HDR_AGENT_CD"].ToString();
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						SIGNED_AMT_NET = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						BYPASS_EDIT = Reader["BYPASS_EDIT"].ToString();
						FILLER_CR = Reader["FILLER_CR"].ToString();
						FILLER_LF = Reader["FILLER_LF"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClinic_nbr = ConvertDEC(Reader["CLINIC_NBR"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalHdr_agent_cd = Reader["HDR_AGENT_CD"].ToString();
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalSigned_amt_net = ConvertDEC(Reader["SIGNED_AMT_NET"]);
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalBypass_edit = Reader["BYPASS_EDIT"].ToString();
						_originalFiller_cr = Reader["FILLER_CR"].ToString();
						_originalFiller_lf = Reader["FILLER_LF"].ToString();
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