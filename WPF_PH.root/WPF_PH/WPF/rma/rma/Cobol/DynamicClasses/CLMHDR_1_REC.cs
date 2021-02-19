using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CLMHDR_1_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CLMHDR_1_REC> Collection( Guid? rowid,
															string clmhdr_1_trans_id,
															string clmhdr_1_rec_id,
															string clmhdr_1_health_num,
															string clmhdr_1_version_cd,
															decimal? clmhdr_1_birth_datemin,
															decimal? clmhdr_1_birth_datemax,
															string clmhdr_1_account_num,
															string clmhdr_1_payment_prg,
															string clmhdr_1_payee,
															decimal? clmhdr_1_ref_doc_nummin,
															decimal? clmhdr_1_ref_doc_nummax,
															decimal? clmhdr_1_hosp_nummin,
															decimal? clmhdr_1_hosp_nummax,
															decimal? clmhdr_1_admit_datemin,
															decimal? clmhdr_1_admit_datemax,
															decimal? clmhdr_1_ref_lab_nummin,
															decimal? clmhdr_1_ref_lab_nummax,
															string clmhdr_1_man_rev_ind,
															string clmhdr_1_loc_code,
															string clmhdr_1_filler,
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
					new SqlParameter("CLMHDR_1_TRANS_ID",clmhdr_1_trans_id),
					new SqlParameter("CLMHDR_1_REC_ID",clmhdr_1_rec_id),
					new SqlParameter("CLMHDR_1_HEALTH_NUM",clmhdr_1_health_num),
					new SqlParameter("CLMHDR_1_VERSION_CD",clmhdr_1_version_cd),
					new SqlParameter("minCLMHDR_1_BIRTH_DATE",clmhdr_1_birth_datemin),
					new SqlParameter("maxCLMHDR_1_BIRTH_DATE",clmhdr_1_birth_datemax),
					new SqlParameter("CLMHDR_1_ACCOUNT_NUM",clmhdr_1_account_num),
					new SqlParameter("CLMHDR_1_PAYMENT_PRG",clmhdr_1_payment_prg),
					new SqlParameter("CLMHDR_1_PAYEE",clmhdr_1_payee),
					new SqlParameter("minCLMHDR_1_REF_DOC_NUM",clmhdr_1_ref_doc_nummin),
					new SqlParameter("maxCLMHDR_1_REF_DOC_NUM",clmhdr_1_ref_doc_nummax),
					new SqlParameter("minCLMHDR_1_HOSP_NUM",clmhdr_1_hosp_nummin),
					new SqlParameter("maxCLMHDR_1_HOSP_NUM",clmhdr_1_hosp_nummax),
					new SqlParameter("minCLMHDR_1_ADMIT_DATE",clmhdr_1_admit_datemin),
					new SqlParameter("maxCLMHDR_1_ADMIT_DATE",clmhdr_1_admit_datemax),
					new SqlParameter("minCLMHDR_1_REF_LAB_NUM",clmhdr_1_ref_lab_nummin),
					new SqlParameter("maxCLMHDR_1_REF_LAB_NUM",clmhdr_1_ref_lab_nummax),
					new SqlParameter("CLMHDR_1_MAN_REV_IND",clmhdr_1_man_rev_ind),
					new SqlParameter("CLMHDR_1_LOC_CODE",clmhdr_1_loc_code),
					new SqlParameter("CLMHDR_1_FILLER",clmhdr_1_filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_1_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CLMHDR_1_REC>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_1_REC_Search]", parameters);
            var collection = new ObservableCollection<CLMHDR_1_REC>();

            while (Reader.Read())
            {
                collection.Add(new CLMHDR_1_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_1_TRANS_ID = Reader["CLMHDR_1_TRANS_ID"].ToString(),
					CLMHDR_1_REC_ID = Reader["CLMHDR_1_REC_ID"].ToString(),
					CLMHDR_1_HEALTH_NUM = Reader["CLMHDR_1_HEALTH_NUM"].ToString(),
					CLMHDR_1_VERSION_CD = Reader["CLMHDR_1_VERSION_CD"].ToString(),
					CLMHDR_1_BIRTH_DATE = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]),
					CLMHDR_1_ACCOUNT_NUM = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString(),
					CLMHDR_1_PAYMENT_PRG = Reader["CLMHDR_1_PAYMENT_PRG"].ToString(),
					CLMHDR_1_PAYEE = Reader["CLMHDR_1_PAYEE"].ToString(),
					CLMHDR_1_REF_DOC_NUM = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]),
					CLMHDR_1_HOSP_NUM = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]),
					CLMHDR_1_ADMIT_DATE = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]),
					CLMHDR_1_REF_LAB_NUM = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]),
					CLMHDR_1_MAN_REV_IND = Reader["CLMHDR_1_MAN_REV_IND"].ToString(),
					CLMHDR_1_LOC_CODE = Reader["CLMHDR_1_LOC_CODE"].ToString(),
					CLMHDR_1_FILLER = Reader["CLMHDR_1_FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_1_trans_id = Reader["CLMHDR_1_TRANS_ID"].ToString(),
					_originalClmhdr_1_rec_id = Reader["CLMHDR_1_REC_ID"].ToString(),
					_originalClmhdr_1_health_num = Reader["CLMHDR_1_HEALTH_NUM"].ToString(),
					_originalClmhdr_1_version_cd = Reader["CLMHDR_1_VERSION_CD"].ToString(),
					_originalClmhdr_1_birth_date = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]),
					_originalClmhdr_1_account_num = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString(),
					_originalClmhdr_1_payment_prg = Reader["CLMHDR_1_PAYMENT_PRG"].ToString(),
					_originalClmhdr_1_payee = Reader["CLMHDR_1_PAYEE"].ToString(),
					_originalClmhdr_1_ref_doc_num = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]),
					_originalClmhdr_1_hosp_num = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]),
					_originalClmhdr_1_admit_date = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]),
					_originalClmhdr_1_ref_lab_num = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]),
					_originalClmhdr_1_man_rev_ind = Reader["CLMHDR_1_MAN_REV_IND"].ToString(),
					_originalClmhdr_1_loc_code = Reader["CLMHDR_1_LOC_CODE"].ToString(),
					_originalClmhdr_1_filler = Reader["CLMHDR_1_FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CLMHDR_1_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CLMHDR_1_REC> Collection(ObservableCollection<CLMHDR_1_REC>
                                                               clmhdr1Rec = null)
        {
            if (IsSameSearch() && clmhdr1Rec != null)
            {
                return clmhdr1Rec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CLMHDR_1_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_1_TRANS_ID",WhereClmhdr_1_trans_id),
					new SqlParameter("CLMHDR_1_REC_ID",WhereClmhdr_1_rec_id),
					new SqlParameter("CLMHDR_1_HEALTH_NUM",WhereClmhdr_1_health_num),
					new SqlParameter("CLMHDR_1_VERSION_CD",WhereClmhdr_1_version_cd),
					new SqlParameter("CLMHDR_1_BIRTH_DATE",WhereClmhdr_1_birth_date),
					new SqlParameter("CLMHDR_1_ACCOUNT_NUM",WhereClmhdr_1_account_num),
					new SqlParameter("CLMHDR_1_PAYMENT_PRG",WhereClmhdr_1_payment_prg),
					new SqlParameter("CLMHDR_1_PAYEE",WhereClmhdr_1_payee),
					new SqlParameter("CLMHDR_1_REF_DOC_NUM",WhereClmhdr_1_ref_doc_num),
					new SqlParameter("CLMHDR_1_HOSP_NUM",WhereClmhdr_1_hosp_num),
					new SqlParameter("CLMHDR_1_ADMIT_DATE",WhereClmhdr_1_admit_date),
					new SqlParameter("CLMHDR_1_REF_LAB_NUM",WhereClmhdr_1_ref_lab_num),
					new SqlParameter("CLMHDR_1_MAN_REV_IND",WhereClmhdr_1_man_rev_ind),
					new SqlParameter("CLMHDR_1_LOC_CODE",WhereClmhdr_1_loc_code),
					new SqlParameter("CLMHDR_1_FILLER",WhereClmhdr_1_filler),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_1_REC_Match]", parameters);
            var collection = new ObservableCollection<CLMHDR_1_REC>();

            while (Reader.Read())
            {
                collection.Add(new CLMHDR_1_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_1_TRANS_ID = Reader["CLMHDR_1_TRANS_ID"].ToString(),
					CLMHDR_1_REC_ID = Reader["CLMHDR_1_REC_ID"].ToString(),
					CLMHDR_1_HEALTH_NUM = Reader["CLMHDR_1_HEALTH_NUM"].ToString(),
					CLMHDR_1_VERSION_CD = Reader["CLMHDR_1_VERSION_CD"].ToString(),
					CLMHDR_1_BIRTH_DATE = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]),
					CLMHDR_1_ACCOUNT_NUM = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString(),
					CLMHDR_1_PAYMENT_PRG = Reader["CLMHDR_1_PAYMENT_PRG"].ToString(),
					CLMHDR_1_PAYEE = Reader["CLMHDR_1_PAYEE"].ToString(),
					CLMHDR_1_REF_DOC_NUM = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]),
					CLMHDR_1_HOSP_NUM = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]),
					CLMHDR_1_ADMIT_DATE = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]),
					CLMHDR_1_REF_LAB_NUM = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]),
					CLMHDR_1_MAN_REV_IND = Reader["CLMHDR_1_MAN_REV_IND"].ToString(),
					CLMHDR_1_LOC_CODE = Reader["CLMHDR_1_LOC_CODE"].ToString(),
					CLMHDR_1_FILLER = Reader["CLMHDR_1_FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_1_trans_id = WhereClmhdr_1_trans_id,
					_whereClmhdr_1_rec_id = WhereClmhdr_1_rec_id,
					_whereClmhdr_1_health_num = WhereClmhdr_1_health_num,
					_whereClmhdr_1_version_cd = WhereClmhdr_1_version_cd,
					_whereClmhdr_1_birth_date = WhereClmhdr_1_birth_date,
					_whereClmhdr_1_account_num = WhereClmhdr_1_account_num,
					_whereClmhdr_1_payment_prg = WhereClmhdr_1_payment_prg,
					_whereClmhdr_1_payee = WhereClmhdr_1_payee,
					_whereClmhdr_1_ref_doc_num = WhereClmhdr_1_ref_doc_num,
					_whereClmhdr_1_hosp_num = WhereClmhdr_1_hosp_num,
					_whereClmhdr_1_admit_date = WhereClmhdr_1_admit_date,
					_whereClmhdr_1_ref_lab_num = WhereClmhdr_1_ref_lab_num,
					_whereClmhdr_1_man_rev_ind = WhereClmhdr_1_man_rev_ind,
					_whereClmhdr_1_loc_code = WhereClmhdr_1_loc_code,
					_whereClmhdr_1_filler = WhereClmhdr_1_filler,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_1_trans_id = Reader["CLMHDR_1_TRANS_ID"].ToString(),
					_originalClmhdr_1_rec_id = Reader["CLMHDR_1_REC_ID"].ToString(),
					_originalClmhdr_1_health_num = Reader["CLMHDR_1_HEALTH_NUM"].ToString(),
					_originalClmhdr_1_version_cd = Reader["CLMHDR_1_VERSION_CD"].ToString(),
					_originalClmhdr_1_birth_date = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]),
					_originalClmhdr_1_account_num = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString(),
					_originalClmhdr_1_payment_prg = Reader["CLMHDR_1_PAYMENT_PRG"].ToString(),
					_originalClmhdr_1_payee = Reader["CLMHDR_1_PAYEE"].ToString(),
					_originalClmhdr_1_ref_doc_num = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]),
					_originalClmhdr_1_hosp_num = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]),
					_originalClmhdr_1_admit_date = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]),
					_originalClmhdr_1_ref_lab_num = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]),
					_originalClmhdr_1_man_rev_ind = Reader["CLMHDR_1_MAN_REV_IND"].ToString(),
					_originalClmhdr_1_loc_code = Reader["CLMHDR_1_LOC_CODE"].ToString(),
					_originalClmhdr_1_filler = Reader["CLMHDR_1_FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_1_trans_id = WhereClmhdr_1_trans_id;
					_whereClmhdr_1_rec_id = WhereClmhdr_1_rec_id;
					_whereClmhdr_1_health_num = WhereClmhdr_1_health_num;
					_whereClmhdr_1_version_cd = WhereClmhdr_1_version_cd;
					_whereClmhdr_1_birth_date = WhereClmhdr_1_birth_date;
					_whereClmhdr_1_account_num = WhereClmhdr_1_account_num;
					_whereClmhdr_1_payment_prg = WhereClmhdr_1_payment_prg;
					_whereClmhdr_1_payee = WhereClmhdr_1_payee;
					_whereClmhdr_1_ref_doc_num = WhereClmhdr_1_ref_doc_num;
					_whereClmhdr_1_hosp_num = WhereClmhdr_1_hosp_num;
					_whereClmhdr_1_admit_date = WhereClmhdr_1_admit_date;
					_whereClmhdr_1_ref_lab_num = WhereClmhdr_1_ref_lab_num;
					_whereClmhdr_1_man_rev_ind = WhereClmhdr_1_man_rev_ind;
					_whereClmhdr_1_loc_code = WhereClmhdr_1_loc_code;
					_whereClmhdr_1_filler = WhereClmhdr_1_filler;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_1_trans_id == null 
				&& WhereClmhdr_1_rec_id == null 
				&& WhereClmhdr_1_health_num == null 
				&& WhereClmhdr_1_version_cd == null 
				&& WhereClmhdr_1_birth_date == null 
				&& WhereClmhdr_1_account_num == null 
				&& WhereClmhdr_1_payment_prg == null 
				&& WhereClmhdr_1_payee == null 
				&& WhereClmhdr_1_ref_doc_num == null 
				&& WhereClmhdr_1_hosp_num == null 
				&& WhereClmhdr_1_admit_date == null 
				&& WhereClmhdr_1_ref_lab_num == null 
				&& WhereClmhdr_1_man_rev_ind == null 
				&& WhereClmhdr_1_loc_code == null 
				&& WhereClmhdr_1_filler == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_1_trans_id ==  _whereClmhdr_1_trans_id
				&& WhereClmhdr_1_rec_id ==  _whereClmhdr_1_rec_id
				&& WhereClmhdr_1_health_num ==  _whereClmhdr_1_health_num
				&& WhereClmhdr_1_version_cd ==  _whereClmhdr_1_version_cd
				&& WhereClmhdr_1_birth_date ==  _whereClmhdr_1_birth_date
				&& WhereClmhdr_1_account_num ==  _whereClmhdr_1_account_num
				&& WhereClmhdr_1_payment_prg ==  _whereClmhdr_1_payment_prg
				&& WhereClmhdr_1_payee ==  _whereClmhdr_1_payee
				&& WhereClmhdr_1_ref_doc_num ==  _whereClmhdr_1_ref_doc_num
				&& WhereClmhdr_1_hosp_num ==  _whereClmhdr_1_hosp_num
				&& WhereClmhdr_1_admit_date ==  _whereClmhdr_1_admit_date
				&& WhereClmhdr_1_ref_lab_num ==  _whereClmhdr_1_ref_lab_num
				&& WhereClmhdr_1_man_rev_ind ==  _whereClmhdr_1_man_rev_ind
				&& WhereClmhdr_1_loc_code ==  _whereClmhdr_1_loc_code
				&& WhereClmhdr_1_filler ==  _whereClmhdr_1_filler
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_1_trans_id = null; 
			WhereClmhdr_1_rec_id = null; 
			WhereClmhdr_1_health_num = null; 
			WhereClmhdr_1_version_cd = null; 
			WhereClmhdr_1_birth_date = null; 
			WhereClmhdr_1_account_num = null; 
			WhereClmhdr_1_payment_prg = null; 
			WhereClmhdr_1_payee = null; 
			WhereClmhdr_1_ref_doc_num = null; 
			WhereClmhdr_1_hosp_num = null; 
			WhereClmhdr_1_admit_date = null; 
			WhereClmhdr_1_ref_lab_num = null; 
			WhereClmhdr_1_man_rev_ind = null; 
			WhereClmhdr_1_loc_code = null; 
			WhereClmhdr_1_filler = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_1_TRANS_ID;
		private string _CLMHDR_1_REC_ID;
		private string _CLMHDR_1_HEALTH_NUM;
		private string _CLMHDR_1_VERSION_CD;
		private decimal? _CLMHDR_1_BIRTH_DATE;
		private string _CLMHDR_1_ACCOUNT_NUM;
		private string _CLMHDR_1_PAYMENT_PRG;
		private string _CLMHDR_1_PAYEE;
		private decimal? _CLMHDR_1_REF_DOC_NUM;
		private decimal? _CLMHDR_1_HOSP_NUM;
		private decimal? _CLMHDR_1_ADMIT_DATE;
		private decimal? _CLMHDR_1_REF_LAB_NUM;
		private string _CLMHDR_1_MAN_REV_IND;
		private string _CLMHDR_1_LOC_CODE;
		private string _CLMHDR_1_FILLER;
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
		public string CLMHDR_1_TRANS_ID
		{
			get { return _CLMHDR_1_TRANS_ID; }
			set
			{
				if (_CLMHDR_1_TRANS_ID != value)
				{
					_CLMHDR_1_TRANS_ID = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_REC_ID
		{
			get { return _CLMHDR_1_REC_ID; }
			set
			{
				if (_CLMHDR_1_REC_ID != value)
				{
					_CLMHDR_1_REC_ID = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_HEALTH_NUM
		{
			get { return _CLMHDR_1_HEALTH_NUM; }
			set
			{
				if (_CLMHDR_1_HEALTH_NUM != value)
				{
					_CLMHDR_1_HEALTH_NUM = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_VERSION_CD
		{
			get { return _CLMHDR_1_VERSION_CD; }
			set
			{
				if (_CLMHDR_1_VERSION_CD != value)
				{
					_CLMHDR_1_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_1_BIRTH_DATE
		{
			get { return _CLMHDR_1_BIRTH_DATE; }
			set
			{
				if (_CLMHDR_1_BIRTH_DATE != value)
				{
					_CLMHDR_1_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_ACCOUNT_NUM
		{
			get { return _CLMHDR_1_ACCOUNT_NUM; }
			set
			{
				if (_CLMHDR_1_ACCOUNT_NUM != value)
				{
					_CLMHDR_1_ACCOUNT_NUM = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_PAYMENT_PRG
		{
			get { return _CLMHDR_1_PAYMENT_PRG; }
			set
			{
				if (_CLMHDR_1_PAYMENT_PRG != value)
				{
					_CLMHDR_1_PAYMENT_PRG = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_PAYEE
		{
			get { return _CLMHDR_1_PAYEE; }
			set
			{
				if (_CLMHDR_1_PAYEE != value)
				{
					_CLMHDR_1_PAYEE = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_1_REF_DOC_NUM
		{
			get { return _CLMHDR_1_REF_DOC_NUM; }
			set
			{
				if (_CLMHDR_1_REF_DOC_NUM != value)
				{
					_CLMHDR_1_REF_DOC_NUM = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_1_HOSP_NUM
		{
			get { return _CLMHDR_1_HOSP_NUM; }
			set
			{
				if (_CLMHDR_1_HOSP_NUM != value)
				{
					_CLMHDR_1_HOSP_NUM = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_1_ADMIT_DATE
		{
			get { return _CLMHDR_1_ADMIT_DATE; }
			set
			{
				if (_CLMHDR_1_ADMIT_DATE != value)
				{
					_CLMHDR_1_ADMIT_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_1_REF_LAB_NUM
		{
			get { return _CLMHDR_1_REF_LAB_NUM; }
			set
			{
				if (_CLMHDR_1_REF_LAB_NUM != value)
				{
					_CLMHDR_1_REF_LAB_NUM = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_MAN_REV_IND
		{
			get { return _CLMHDR_1_MAN_REV_IND; }
			set
			{
				if (_CLMHDR_1_MAN_REV_IND != value)
				{
					_CLMHDR_1_MAN_REV_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_LOC_CODE
		{
			get { return _CLMHDR_1_LOC_CODE; }
			set
			{
				if (_CLMHDR_1_LOC_CODE != value)
				{
					_CLMHDR_1_LOC_CODE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_1_FILLER
		{
			get { return _CLMHDR_1_FILLER; }
			set
			{
				if (_CLMHDR_1_FILLER != value)
				{
					_CLMHDR_1_FILLER = value;
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
		public string WhereClmhdr_1_trans_id { get; set; }
		private string _whereClmhdr_1_trans_id;
		public string WhereClmhdr_1_rec_id { get; set; }
		private string _whereClmhdr_1_rec_id;
		public string WhereClmhdr_1_health_num { get; set; }
		private string _whereClmhdr_1_health_num;
		public string WhereClmhdr_1_version_cd { get; set; }
		private string _whereClmhdr_1_version_cd;
		public decimal? WhereClmhdr_1_birth_date { get; set; }
		private decimal? _whereClmhdr_1_birth_date;
		public string WhereClmhdr_1_account_num { get; set; }
		private string _whereClmhdr_1_account_num;
		public string WhereClmhdr_1_payment_prg { get; set; }
		private string _whereClmhdr_1_payment_prg;
		public string WhereClmhdr_1_payee { get; set; }
		private string _whereClmhdr_1_payee;
		public decimal? WhereClmhdr_1_ref_doc_num { get; set; }
		private decimal? _whereClmhdr_1_ref_doc_num;
		public decimal? WhereClmhdr_1_hosp_num { get; set; }
		private decimal? _whereClmhdr_1_hosp_num;
		public decimal? WhereClmhdr_1_admit_date { get; set; }
		private decimal? _whereClmhdr_1_admit_date;
		public decimal? WhereClmhdr_1_ref_lab_num { get; set; }
		private decimal? _whereClmhdr_1_ref_lab_num;
		public string WhereClmhdr_1_man_rev_ind { get; set; }
		private string _whereClmhdr_1_man_rev_ind;
		public string WhereClmhdr_1_loc_code { get; set; }
		private string _whereClmhdr_1_loc_code;
		public string WhereClmhdr_1_filler { get; set; }
		private string _whereClmhdr_1_filler;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_1_trans_id;
		private string _originalClmhdr_1_rec_id;
		private string _originalClmhdr_1_health_num;
		private string _originalClmhdr_1_version_cd;
		private decimal? _originalClmhdr_1_birth_date;
		private string _originalClmhdr_1_account_num;
		private string _originalClmhdr_1_payment_prg;
		private string _originalClmhdr_1_payee;
		private decimal? _originalClmhdr_1_ref_doc_num;
		private decimal? _originalClmhdr_1_hosp_num;
		private decimal? _originalClmhdr_1_admit_date;
		private decimal? _originalClmhdr_1_ref_lab_num;
		private string _originalClmhdr_1_man_rev_ind;
		private string _originalClmhdr_1_loc_code;
		private string _originalClmhdr_1_filler;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_1_TRANS_ID = _originalClmhdr_1_trans_id;
			CLMHDR_1_REC_ID = _originalClmhdr_1_rec_id;
			CLMHDR_1_HEALTH_NUM = _originalClmhdr_1_health_num;
			CLMHDR_1_VERSION_CD = _originalClmhdr_1_version_cd;
			CLMHDR_1_BIRTH_DATE = _originalClmhdr_1_birth_date;
			CLMHDR_1_ACCOUNT_NUM = _originalClmhdr_1_account_num;
			CLMHDR_1_PAYMENT_PRG = _originalClmhdr_1_payment_prg;
			CLMHDR_1_PAYEE = _originalClmhdr_1_payee;
			CLMHDR_1_REF_DOC_NUM = _originalClmhdr_1_ref_doc_num;
			CLMHDR_1_HOSP_NUM = _originalClmhdr_1_hosp_num;
			CLMHDR_1_ADMIT_DATE = _originalClmhdr_1_admit_date;
			CLMHDR_1_REF_LAB_NUM = _originalClmhdr_1_ref_lab_num;
			CLMHDR_1_MAN_REV_IND = _originalClmhdr_1_man_rev_ind;
			CLMHDR_1_LOC_CODE = _originalClmhdr_1_loc_code;
			CLMHDR_1_FILLER = _originalClmhdr_1_filler;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLMHDR_1_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLMHDR_1_REC_Purge]");
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
						new SqlParameter("CLMHDR_1_TRANS_ID", SqlNull(CLMHDR_1_TRANS_ID)),
						new SqlParameter("CLMHDR_1_REC_ID", SqlNull(CLMHDR_1_REC_ID)),
						new SqlParameter("CLMHDR_1_HEALTH_NUM", SqlNull(CLMHDR_1_HEALTH_NUM)),
						new SqlParameter("CLMHDR_1_VERSION_CD", SqlNull(CLMHDR_1_VERSION_CD)),
						new SqlParameter("CLMHDR_1_BIRTH_DATE", SqlNull(CLMHDR_1_BIRTH_DATE)),
						new SqlParameter("CLMHDR_1_ACCOUNT_NUM", SqlNull(CLMHDR_1_ACCOUNT_NUM)),
						new SqlParameter("CLMHDR_1_PAYMENT_PRG", SqlNull(CLMHDR_1_PAYMENT_PRG)),
						new SqlParameter("CLMHDR_1_PAYEE", SqlNull(CLMHDR_1_PAYEE)),
						new SqlParameter("CLMHDR_1_REF_DOC_NUM", SqlNull(CLMHDR_1_REF_DOC_NUM)),
						new SqlParameter("CLMHDR_1_HOSP_NUM", SqlNull(CLMHDR_1_HOSP_NUM)),
						new SqlParameter("CLMHDR_1_ADMIT_DATE", SqlNull(CLMHDR_1_ADMIT_DATE)),
						new SqlParameter("CLMHDR_1_REF_LAB_NUM", SqlNull(CLMHDR_1_REF_LAB_NUM)),
						new SqlParameter("CLMHDR_1_MAN_REV_IND", SqlNull(CLMHDR_1_MAN_REV_IND)),
						new SqlParameter("CLMHDR_1_LOC_CODE", SqlNull(CLMHDR_1_LOC_CODE)),
						new SqlParameter("CLMHDR_1_FILLER", SqlNull(CLMHDR_1_FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_1_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_1_TRANS_ID = Reader["CLMHDR_1_TRANS_ID"].ToString();
						CLMHDR_1_REC_ID = Reader["CLMHDR_1_REC_ID"].ToString();
						CLMHDR_1_HEALTH_NUM = Reader["CLMHDR_1_HEALTH_NUM"].ToString();
						CLMHDR_1_VERSION_CD = Reader["CLMHDR_1_VERSION_CD"].ToString();
						CLMHDR_1_BIRTH_DATE = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]);
						CLMHDR_1_ACCOUNT_NUM = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString();
						CLMHDR_1_PAYMENT_PRG = Reader["CLMHDR_1_PAYMENT_PRG"].ToString();
						CLMHDR_1_PAYEE = Reader["CLMHDR_1_PAYEE"].ToString();
						CLMHDR_1_REF_DOC_NUM = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]);
						CLMHDR_1_HOSP_NUM = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]);
						CLMHDR_1_ADMIT_DATE = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]);
						CLMHDR_1_REF_LAB_NUM = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]);
						CLMHDR_1_MAN_REV_IND = Reader["CLMHDR_1_MAN_REV_IND"].ToString();
						CLMHDR_1_LOC_CODE = Reader["CLMHDR_1_LOC_CODE"].ToString();
						CLMHDR_1_FILLER = Reader["CLMHDR_1_FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_1_trans_id = Reader["CLMHDR_1_TRANS_ID"].ToString();
						_originalClmhdr_1_rec_id = Reader["CLMHDR_1_REC_ID"].ToString();
						_originalClmhdr_1_health_num = Reader["CLMHDR_1_HEALTH_NUM"].ToString();
						_originalClmhdr_1_version_cd = Reader["CLMHDR_1_VERSION_CD"].ToString();
						_originalClmhdr_1_birth_date = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]);
						_originalClmhdr_1_account_num = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString();
						_originalClmhdr_1_payment_prg = Reader["CLMHDR_1_PAYMENT_PRG"].ToString();
						_originalClmhdr_1_payee = Reader["CLMHDR_1_PAYEE"].ToString();
						_originalClmhdr_1_ref_doc_num = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]);
						_originalClmhdr_1_hosp_num = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]);
						_originalClmhdr_1_admit_date = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]);
						_originalClmhdr_1_ref_lab_num = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]);
						_originalClmhdr_1_man_rev_ind = Reader["CLMHDR_1_MAN_REV_IND"].ToString();
						_originalClmhdr_1_loc_code = Reader["CLMHDR_1_LOC_CODE"].ToString();
						_originalClmhdr_1_filler = Reader["CLMHDR_1_FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMHDR_1_TRANS_ID", SqlNull(CLMHDR_1_TRANS_ID)),
						new SqlParameter("CLMHDR_1_REC_ID", SqlNull(CLMHDR_1_REC_ID)),
						new SqlParameter("CLMHDR_1_HEALTH_NUM", SqlNull(CLMHDR_1_HEALTH_NUM)),
						new SqlParameter("CLMHDR_1_VERSION_CD", SqlNull(CLMHDR_1_VERSION_CD)),
						new SqlParameter("CLMHDR_1_BIRTH_DATE", SqlNull(CLMHDR_1_BIRTH_DATE)),
						new SqlParameter("CLMHDR_1_ACCOUNT_NUM", SqlNull(CLMHDR_1_ACCOUNT_NUM)),
						new SqlParameter("CLMHDR_1_PAYMENT_PRG", SqlNull(CLMHDR_1_PAYMENT_PRG)),
						new SqlParameter("CLMHDR_1_PAYEE", SqlNull(CLMHDR_1_PAYEE)),
						new SqlParameter("CLMHDR_1_REF_DOC_NUM", SqlNull(CLMHDR_1_REF_DOC_NUM)),
						new SqlParameter("CLMHDR_1_HOSP_NUM", SqlNull(CLMHDR_1_HOSP_NUM)),
						new SqlParameter("CLMHDR_1_ADMIT_DATE", SqlNull(CLMHDR_1_ADMIT_DATE)),
						new SqlParameter("CLMHDR_1_REF_LAB_NUM", SqlNull(CLMHDR_1_REF_LAB_NUM)),
						new SqlParameter("CLMHDR_1_MAN_REV_IND", SqlNull(CLMHDR_1_MAN_REV_IND)),
						new SqlParameter("CLMHDR_1_LOC_CODE", SqlNull(CLMHDR_1_LOC_CODE)),
						new SqlParameter("CLMHDR_1_FILLER", SqlNull(CLMHDR_1_FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLMHDR_1_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_1_TRANS_ID = Reader["CLMHDR_1_TRANS_ID"].ToString();
						CLMHDR_1_REC_ID = Reader["CLMHDR_1_REC_ID"].ToString();
						CLMHDR_1_HEALTH_NUM = Reader["CLMHDR_1_HEALTH_NUM"].ToString();
						CLMHDR_1_VERSION_CD = Reader["CLMHDR_1_VERSION_CD"].ToString();
						CLMHDR_1_BIRTH_DATE = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]);
						CLMHDR_1_ACCOUNT_NUM = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString();
						CLMHDR_1_PAYMENT_PRG = Reader["CLMHDR_1_PAYMENT_PRG"].ToString();
						CLMHDR_1_PAYEE = Reader["CLMHDR_1_PAYEE"].ToString();
						CLMHDR_1_REF_DOC_NUM = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]);
						CLMHDR_1_HOSP_NUM = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]);
						CLMHDR_1_ADMIT_DATE = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]);
						CLMHDR_1_REF_LAB_NUM = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]);
						CLMHDR_1_MAN_REV_IND = Reader["CLMHDR_1_MAN_REV_IND"].ToString();
						CLMHDR_1_LOC_CODE = Reader["CLMHDR_1_LOC_CODE"].ToString();
						CLMHDR_1_FILLER = Reader["CLMHDR_1_FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_1_trans_id = Reader["CLMHDR_1_TRANS_ID"].ToString();
						_originalClmhdr_1_rec_id = Reader["CLMHDR_1_REC_ID"].ToString();
						_originalClmhdr_1_health_num = Reader["CLMHDR_1_HEALTH_NUM"].ToString();
						_originalClmhdr_1_version_cd = Reader["CLMHDR_1_VERSION_CD"].ToString();
						_originalClmhdr_1_birth_date = ConvertDEC(Reader["CLMHDR_1_BIRTH_DATE"]);
						_originalClmhdr_1_account_num = Reader["CLMHDR_1_ACCOUNT_NUM"].ToString();
						_originalClmhdr_1_payment_prg = Reader["CLMHDR_1_PAYMENT_PRG"].ToString();
						_originalClmhdr_1_payee = Reader["CLMHDR_1_PAYEE"].ToString();
						_originalClmhdr_1_ref_doc_num = ConvertDEC(Reader["CLMHDR_1_REF_DOC_NUM"]);
						_originalClmhdr_1_hosp_num = ConvertDEC(Reader["CLMHDR_1_HOSP_NUM"]);
						_originalClmhdr_1_admit_date = ConvertDEC(Reader["CLMHDR_1_ADMIT_DATE"]);
						_originalClmhdr_1_ref_lab_num = ConvertDEC(Reader["CLMHDR_1_REF_LAB_NUM"]);
						_originalClmhdr_1_man_rev_ind = Reader["CLMHDR_1_MAN_REV_IND"].ToString();
						_originalClmhdr_1_loc_code = Reader["CLMHDR_1_LOC_CODE"].ToString();
						_originalClmhdr_1_filler = Reader["CLMHDR_1_FILLER"].ToString();
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