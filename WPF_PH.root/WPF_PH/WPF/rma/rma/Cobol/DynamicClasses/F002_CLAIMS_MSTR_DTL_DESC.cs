using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIMS_MSTR_DTL_DESC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC> Collection( Guid? rowid,
															string clmdtl_batch_nbr,
															decimal? clmdtl_claim_nbrmin,
															decimal? clmdtl_claim_nbrmax,
															string clmdtl_oma_cd,
															string clmdtl_oma_suff,
															decimal? clmdtl_adj_nbrmin,
															decimal? clmdtl_adj_nbrmax,
															string clmdtl_desc,
															string clmdtl_filler0,
															string clmdtl_filler9,
															string clmdtl_orig_batch_nbr,
															decimal? clmdtl_orig_claim_nbr_in_batchmin,
															decimal? clmdtl_orig_claim_nbr_in_batchmax,
															string key_clm_type,
															string key_clm_batch_nbr,
															decimal? key_clm_claim_nbrmin,
															decimal? key_clm_claim_nbrmax,
															string key_clm_serv_code,
															string key_clm_adj_nbr,
															string key_p_clm_type,
															string key_p_clm_data,
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
					new SqlParameter("CLMDTL_BATCH_NBR",clmdtl_batch_nbr),
					new SqlParameter("minCLMDTL_CLAIM_NBR",clmdtl_claim_nbrmin),
					new SqlParameter("maxCLMDTL_CLAIM_NBR",clmdtl_claim_nbrmax),
					new SqlParameter("CLMDTL_OMA_CD",clmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",clmdtl_oma_suff),
					new SqlParameter("minCLMDTL_ADJ_NBR",clmdtl_adj_nbrmin),
					new SqlParameter("maxCLMDTL_ADJ_NBR",clmdtl_adj_nbrmax),
					new SqlParameter("CLMDTL_DESC",clmdtl_desc),
					new SqlParameter("CLMDTL_FILLER0",clmdtl_filler0),
					new SqlParameter("CLMDTL_FILLER9",clmdtl_filler9),
					new SqlParameter("CLMDTL_ORIG_BATCH_NBR",clmdtl_orig_batch_nbr),
					new SqlParameter("minCLMDTL_ORIG_CLAIM_NBR_IN_BATCH",clmdtl_orig_claim_nbr_in_batchmin),
					new SqlParameter("maxCLMDTL_ORIG_CLAIM_NBR_IN_BATCH",clmdtl_orig_claim_nbr_in_batchmax),
					new SqlParameter("KEY_CLM_TYPE",key_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR",key_clm_batch_nbr),
					new SqlParameter("minKEY_CLM_CLAIM_NBR",key_clm_claim_nbrmin),
					new SqlParameter("maxKEY_CLM_CLAIM_NBR",key_clm_claim_nbrmax),
					new SqlParameter("KEY_CLM_SERV_CODE",key_clm_serv_code),
					new SqlParameter("KEY_CLM_ADJ_NBR",key_clm_adj_nbr),
					new SqlParameter("KEY_P_CLM_TYPE",key_p_clm_type),
					new SqlParameter("KEY_P_CLM_DATA",key_p_clm_data),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_DESC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_DESC_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString(),
					CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString(),
					CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString(),
					CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
					KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
					KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString(),
					_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString(),
					_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString(),
					_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString(),
					_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					_originalKey_clm_serv_code = Reader["KEY_CLM_SERV_CODE"].ToString(),
					_originalKey_clm_adj_nbr = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					_originalKey_p_clm_type = Reader["KEY_P_CLM_TYPE"].ToString(),
					_originalKey_p_clm_data = Reader["KEY_P_CLM_DATA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_CLAIMS_MSTR_DTL_DESC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC> Collection(ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>
                                                               f002ClaimsMstrDtlDesc = null)
        {
            if (IsSameSearch() && f002ClaimsMstrDtlDesc != null)
            {
                return f002ClaimsMstrDtlDesc;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_BATCH_NBR",WhereClmdtl_batch_nbr),
					new SqlParameter("CLMDTL_CLAIM_NBR",WhereClmdtl_claim_nbr),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",WhereClmdtl_oma_suff),
					new SqlParameter("CLMDTL_ADJ_NBR",WhereClmdtl_adj_nbr),
					new SqlParameter("CLMDTL_DESC",WhereClmdtl_desc),
					new SqlParameter("CLMDTL_FILLER0",WhereClmdtl_filler0),
					new SqlParameter("CLMDTL_FILLER9",WhereClmdtl_filler9),
					new SqlParameter("CLMDTL_ORIG_BATCH_NBR",WhereClmdtl_orig_batch_nbr),
					new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH",WhereClmdtl_orig_claim_nbr_in_batch),
					new SqlParameter("KEY_CLM_TYPE",WhereKey_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR",WhereKey_clm_batch_nbr),
					new SqlParameter("KEY_CLM_CLAIM_NBR",WhereKey_clm_claim_nbr),
					new SqlParameter("KEY_CLM_SERV_CODE",WhereKey_clm_serv_code),
					new SqlParameter("KEY_CLM_ADJ_NBR",WhereKey_clm_adj_nbr),
					new SqlParameter("KEY_P_CLM_TYPE",WhereKey_p_clm_type),
					new SqlParameter("KEY_P_CLM_DATA",WhereKey_p_clm_data),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DESC_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL_DESC>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL_DESC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString(),
					CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString(),
					CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString(),
					CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
					KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
					KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmdtl_batch_nbr = WhereClmdtl_batch_nbr,
					_whereClmdtl_claim_nbr = WhereClmdtl_claim_nbr,
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff,
					_whereClmdtl_adj_nbr = WhereClmdtl_adj_nbr,
					_whereClmdtl_desc = WhereClmdtl_desc,
					_whereClmdtl_filler0 = WhereClmdtl_filler0,
					_whereClmdtl_filler9 = WhereClmdtl_filler9,
					_whereClmdtl_orig_batch_nbr = WhereClmdtl_orig_batch_nbr,
					_whereClmdtl_orig_claim_nbr_in_batch = WhereClmdtl_orig_claim_nbr_in_batch,
					_whereKey_clm_type = WhereKey_clm_type,
					_whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
					_whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
					_whereKey_clm_serv_code = WhereKey_clm_serv_code,
					_whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
					_whereKey_p_clm_type = WhereKey_p_clm_type,
					_whereKey_p_clm_data = WhereKey_p_clm_data,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString(),
					_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString(),
					_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString(),
					_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString(),
					_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString(),
					_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					_originalKey_clm_serv_code = Reader["KEY_CLM_SERV_CODE"].ToString(),
					_originalKey_clm_adj_nbr = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					_originalKey_p_clm_type = Reader["KEY_P_CLM_TYPE"].ToString(),
					_originalKey_p_clm_data = Reader["KEY_P_CLM_DATA"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmdtl_batch_nbr = WhereClmdtl_batch_nbr;
					_whereClmdtl_claim_nbr = WhereClmdtl_claim_nbr;
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd;
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff;
					_whereClmdtl_adj_nbr = WhereClmdtl_adj_nbr;
					_whereClmdtl_desc = WhereClmdtl_desc;
					_whereClmdtl_filler0 = WhereClmdtl_filler0;
					_whereClmdtl_filler9 = WhereClmdtl_filler9;
					_whereClmdtl_orig_batch_nbr = WhereClmdtl_orig_batch_nbr;
					_whereClmdtl_orig_claim_nbr_in_batch = WhereClmdtl_orig_claim_nbr_in_batch;
					_whereKey_clm_type = WhereKey_clm_type;
					_whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr;
					_whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr;
					_whereKey_clm_serv_code = WhereKey_clm_serv_code;
					_whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr;
					_whereKey_p_clm_type = WhereKey_p_clm_type;
					_whereKey_p_clm_data = WhereKey_p_clm_data;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmdtl_batch_nbr == null 
				&& WhereClmdtl_claim_nbr == null 
				&& WhereClmdtl_oma_cd == null 
				&& WhereClmdtl_oma_suff == null 
				&& WhereClmdtl_adj_nbr == null 
				&& WhereClmdtl_desc == null 
				&& WhereClmdtl_filler0 == null 
				&& WhereClmdtl_filler9 == null 
				&& WhereClmdtl_orig_batch_nbr == null 
				&& WhereClmdtl_orig_claim_nbr_in_batch == null 
				&& WhereKey_clm_type == null 
				&& WhereKey_clm_batch_nbr == null 
				&& WhereKey_clm_claim_nbr == null 
				&& WhereKey_clm_serv_code == null 
				&& WhereKey_clm_adj_nbr == null 
				&& WhereKey_p_clm_type == null 
				&& WhereKey_p_clm_data == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmdtl_batch_nbr ==  _whereClmdtl_batch_nbr
				&& WhereClmdtl_claim_nbr ==  _whereClmdtl_claim_nbr
				&& WhereClmdtl_oma_cd ==  _whereClmdtl_oma_cd
				&& WhereClmdtl_oma_suff ==  _whereClmdtl_oma_suff
				&& WhereClmdtl_adj_nbr ==  _whereClmdtl_adj_nbr
				&& WhereClmdtl_desc ==  _whereClmdtl_desc
				&& WhereClmdtl_filler0 ==  _whereClmdtl_filler0
				&& WhereClmdtl_filler9 ==  _whereClmdtl_filler9
				&& WhereClmdtl_orig_batch_nbr ==  _whereClmdtl_orig_batch_nbr
				&& WhereClmdtl_orig_claim_nbr_in_batch ==  _whereClmdtl_orig_claim_nbr_in_batch
				&& WhereKey_clm_type ==  _whereKey_clm_type
				&& WhereKey_clm_batch_nbr ==  _whereKey_clm_batch_nbr
				&& WhereKey_clm_claim_nbr ==  _whereKey_clm_claim_nbr
				&& WhereKey_clm_serv_code ==  _whereKey_clm_serv_code
				&& WhereKey_clm_adj_nbr ==  _whereKey_clm_adj_nbr
				&& WhereKey_p_clm_type ==  _whereKey_p_clm_type
				&& WhereKey_p_clm_data ==  _whereKey_p_clm_data
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmdtl_batch_nbr = null; 
			WhereClmdtl_claim_nbr = null; 
			WhereClmdtl_oma_cd = null; 
			WhereClmdtl_oma_suff = null; 
			WhereClmdtl_adj_nbr = null; 
			WhereClmdtl_desc = null; 
			WhereClmdtl_filler0 = null; 
			WhereClmdtl_filler9 = null; 
			WhereClmdtl_orig_batch_nbr = null; 
			WhereClmdtl_orig_claim_nbr_in_batch = null; 
			WhereKey_clm_type = null; 
			WhereKey_clm_batch_nbr = null; 
			WhereKey_clm_claim_nbr = null; 
			WhereKey_clm_serv_code = null; 
			WhereKey_clm_adj_nbr = null; 
			WhereKey_p_clm_type = null; 
			WhereKey_p_clm_data = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMDTL_BATCH_NBR;
		private decimal? _CLMDTL_CLAIM_NBR;
		private string _CLMDTL_OMA_CD;
		private string _CLMDTL_OMA_SUFF;
		private decimal? _CLMDTL_ADJ_NBR;
		private string _CLMDTL_DESC;
		private string _CLMDTL_FILLER0;
		private string _CLMDTL_FILLER9;
		private string _CLMDTL_ORIG_BATCH_NBR;
		private decimal? _CLMDTL_ORIG_CLAIM_NBR_IN_BATCH;
		private string _KEY_CLM_TYPE;
		private string _KEY_CLM_BATCH_NBR;
		private decimal? _KEY_CLM_CLAIM_NBR;
		private string _KEY_CLM_SERV_CODE;
		private string _KEY_CLM_ADJ_NBR;
		private string _KEY_P_CLM_TYPE;
		private string _KEY_P_CLM_DATA;
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
		public string CLMDTL_BATCH_NBR
		{
			get { return _CLMDTL_BATCH_NBR; }
			set
			{
				if (_CLMDTL_BATCH_NBR != value)
				{
					_CLMDTL_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CLAIM_NBR
		{
			get { return _CLMDTL_CLAIM_NBR; }
			set
			{
				if (_CLMDTL_CLAIM_NBR != value)
				{
					_CLMDTL_CLAIM_NBR = value;
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
		public string CLMDTL_OMA_SUFF
		{
			get { return _CLMDTL_OMA_SUFF; }
			set
			{
				if (_CLMDTL_OMA_SUFF != value)
				{
					_CLMDTL_OMA_SUFF = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_ADJ_NBR
		{
			get { return _CLMDTL_ADJ_NBR; }
			set
			{
				if (_CLMDTL_ADJ_NBR != value)
				{
					_CLMDTL_ADJ_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_DESC
		{
			get { return _CLMDTL_DESC; }
			set
			{
				if (_CLMDTL_DESC != value)
				{
					_CLMDTL_DESC = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_FILLER0
		{
			get { return _CLMDTL_FILLER0; }
			set
			{
				if (_CLMDTL_FILLER0 != value)
				{
					_CLMDTL_FILLER0 = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_FILLER9
		{
			get { return _CLMDTL_FILLER9; }
			set
			{
				if (_CLMDTL_FILLER9 != value)
				{
					_CLMDTL_FILLER9 = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_ORIG_BATCH_NBR
		{
			get { return _CLMDTL_ORIG_BATCH_NBR; }
			set
			{
				if (_CLMDTL_ORIG_BATCH_NBR != value)
				{
					_CLMDTL_ORIG_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_ORIG_CLAIM_NBR_IN_BATCH
		{
			get { return _CLMDTL_ORIG_CLAIM_NBR_IN_BATCH; }
			set
			{
				if (_CLMDTL_ORIG_CLAIM_NBR_IN_BATCH != value)
				{
					_CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = value;
					ChangeState();
				}
			}
		}
		public string KEY_CLM_TYPE
		{
			get { return _KEY_CLM_TYPE; }
			set
			{
				if (_KEY_CLM_TYPE != value)
				{
					_KEY_CLM_TYPE = value;
					ChangeState();
				}
			}
		}
		public string KEY_CLM_BATCH_NBR
		{
			get { return _KEY_CLM_BATCH_NBR; }
			set
			{
				if (_KEY_CLM_BATCH_NBR != value)
				{
					_KEY_CLM_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? KEY_CLM_CLAIM_NBR
		{
			get { return _KEY_CLM_CLAIM_NBR; }
			set
			{
				if (_KEY_CLM_CLAIM_NBR != value)
				{
					_KEY_CLM_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string KEY_CLM_SERV_CODE
		{
			get { return _KEY_CLM_SERV_CODE; }
			set
			{
				if (_KEY_CLM_SERV_CODE != value)
				{
					_KEY_CLM_SERV_CODE = value;
					ChangeState();
				}
			}
		}
		public string KEY_CLM_ADJ_NBR
		{
			get { return _KEY_CLM_ADJ_NBR; }
			set
			{
				if (_KEY_CLM_ADJ_NBR != value)
				{
					_KEY_CLM_ADJ_NBR = value;
					ChangeState();
				}
			}
		}
		public string KEY_P_CLM_TYPE
		{
			get { return _KEY_P_CLM_TYPE; }
			set
			{
				if (_KEY_P_CLM_TYPE != value)
				{
					_KEY_P_CLM_TYPE = value;
					ChangeState();
				}
			}
		}
		public string KEY_P_CLM_DATA
		{
			get { return _KEY_P_CLM_DATA; }
			set
			{
				if (_KEY_P_CLM_DATA != value)
				{
					_KEY_P_CLM_DATA = value;
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
		public string WhereClmdtl_batch_nbr { get; set; }
		private string _whereClmdtl_batch_nbr;
		public decimal? WhereClmdtl_claim_nbr { get; set; }
		private decimal? _whereClmdtl_claim_nbr;
		public string WhereClmdtl_oma_cd { get; set; }
		private string _whereClmdtl_oma_cd;
		public string WhereClmdtl_oma_suff { get; set; }
		private string _whereClmdtl_oma_suff;
		public decimal? WhereClmdtl_adj_nbr { get; set; }
		private decimal? _whereClmdtl_adj_nbr;
		public string WhereClmdtl_desc { get; set; }
		private string _whereClmdtl_desc;
		public string WhereClmdtl_filler0 { get; set; }
		private string _whereClmdtl_filler0;
		public string WhereClmdtl_filler9 { get; set; }
		private string _whereClmdtl_filler9;
		public string WhereClmdtl_orig_batch_nbr { get; set; }
		private string _whereClmdtl_orig_batch_nbr;
		public decimal? WhereClmdtl_orig_claim_nbr_in_batch { get; set; }
		private decimal? _whereClmdtl_orig_claim_nbr_in_batch;
		public string WhereKey_clm_type { get; set; }
		private string _whereKey_clm_type;
		public string WhereKey_clm_batch_nbr { get; set; }
		private string _whereKey_clm_batch_nbr;
		public decimal? WhereKey_clm_claim_nbr { get; set; }
		private decimal? _whereKey_clm_claim_nbr;
		public string WhereKey_clm_serv_code { get; set; }
		private string _whereKey_clm_serv_code;
		public string WhereKey_clm_adj_nbr { get; set; }
		private string _whereKey_clm_adj_nbr;
		public string WhereKey_p_clm_type { get; set; }
		private string _whereKey_p_clm_type;
		public string WhereKey_p_clm_data { get; set; }
		private string _whereKey_p_clm_data;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmdtl_batch_nbr;
		private decimal? _originalClmdtl_claim_nbr;
		private string _originalClmdtl_oma_cd;
		private string _originalClmdtl_oma_suff;
		private decimal? _originalClmdtl_adj_nbr;
		private string _originalClmdtl_desc;
		private string _originalClmdtl_filler0;
		private string _originalClmdtl_filler9;
		private string _originalClmdtl_orig_batch_nbr;
		private decimal? _originalClmdtl_orig_claim_nbr_in_batch;
		private string _originalKey_clm_type;
		private string _originalKey_clm_batch_nbr;
		private decimal? _originalKey_clm_claim_nbr;
		private string _originalKey_clm_serv_code;
		private string _originalKey_clm_adj_nbr;
		private string _originalKey_p_clm_type;
		private string _originalKey_p_clm_data;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMDTL_BATCH_NBR = _originalClmdtl_batch_nbr;
			CLMDTL_CLAIM_NBR = _originalClmdtl_claim_nbr;
			CLMDTL_OMA_CD = _originalClmdtl_oma_cd;
			CLMDTL_OMA_SUFF = _originalClmdtl_oma_suff;
			CLMDTL_ADJ_NBR = _originalClmdtl_adj_nbr;
			CLMDTL_DESC = _originalClmdtl_desc;
			CLMDTL_FILLER0 = _originalClmdtl_filler0;
			CLMDTL_FILLER9 = _originalClmdtl_filler9;
			CLMDTL_ORIG_BATCH_NBR = _originalClmdtl_orig_batch_nbr;
			CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = _originalClmdtl_orig_claim_nbr_in_batch;
			KEY_CLM_TYPE = _originalKey_clm_type;
			KEY_CLM_BATCH_NBR = _originalKey_clm_batch_nbr;
			KEY_CLM_CLAIM_NBR = _originalKey_clm_claim_nbr;
			KEY_CLM_SERV_CODE = _originalKey_clm_serv_code;
			KEY_CLM_ADJ_NBR = _originalKey_clm_adj_nbr;
			KEY_P_CLM_TYPE = _originalKey_p_clm_type;
			KEY_P_CLM_DATA = _originalKey_p_clm_data;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_DESC_DeleteRow]", parameters);

	    CloseConnection();
            if (RowsAffected == 0)
                 return false;
            else
                return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_DESC_Purge]");
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
						new SqlParameter("CLMDTL_BATCH_NBR", SqlNull(CLMDTL_BATCH_NBR)),
						new SqlParameter("CLMDTL_CLAIM_NBR", SqlNull(CLMDTL_CLAIM_NBR)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_ADJ_NBR", SqlNull(CLMDTL_ADJ_NBR)),
						new SqlParameter("CLMDTL_DESC", SqlNull(CLMDTL_DESC)),
						new SqlParameter("CLMDTL_FILLER0", SqlNull(CLMDTL_FILLER0)),
						new SqlParameter("CLMDTL_FILLER9", SqlNull(CLMDTL_FILLER9)),
						new SqlParameter("CLMDTL_ORIG_BATCH_NBR", SqlNull(CLMDTL_ORIG_BATCH_NBR)),
						new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", SqlNull(CLMDTL_ORIG_CLAIM_NBR_IN_BATCH)),
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR", SqlNull(KEY_CLM_BATCH_NBR)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("KEY_CLM_SERV_CODE", SqlNull(KEY_CLM_SERV_CODE)),
						new SqlParameter("KEY_CLM_ADJ_NBR", SqlNull(KEY_CLM_ADJ_NBR)),
						new SqlParameter("KEY_P_CLM_TYPE", SqlNull(KEY_P_CLM_TYPE)),
						new SqlParameter("KEY_P_CLM_DATA", SqlNull(KEY_P_CLM_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DESC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString();
						CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString();
						CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString();
						CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString();
						KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString();
						KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString();
						KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString();
						_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString();
						_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString();
						_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString();
						_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString();
						_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						_originalKey_clm_serv_code = Reader["KEY_CLM_SERV_CODE"].ToString();
						_originalKey_clm_adj_nbr = Reader["KEY_CLM_ADJ_NBR"].ToString();
						_originalKey_p_clm_type = Reader["KEY_P_CLM_TYPE"].ToString();
						_originalKey_p_clm_data = Reader["KEY_P_CLM_DATA"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMDTL_BATCH_NBR", SqlNull(CLMDTL_BATCH_NBR)),
						new SqlParameter("CLMDTL_CLAIM_NBR", SqlNull(CLMDTL_CLAIM_NBR)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_ADJ_NBR", SqlNull(CLMDTL_ADJ_NBR)),
						new SqlParameter("CLMDTL_DESC", SqlNull(CLMDTL_DESC)),
						new SqlParameter("CLMDTL_FILLER0", SqlNull(CLMDTL_FILLER0)),
						new SqlParameter("CLMDTL_FILLER9", SqlNull(CLMDTL_FILLER9)),
						new SqlParameter("CLMDTL_ORIG_BATCH_NBR", SqlNull(CLMDTL_ORIG_BATCH_NBR)),
						new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", SqlNull(CLMDTL_ORIG_CLAIM_NBR_IN_BATCH)),
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR", SqlNull(KEY_CLM_BATCH_NBR)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("KEY_CLM_SERV_CODE", SqlNull(KEY_CLM_SERV_CODE)),
						new SqlParameter("KEY_CLM_ADJ_NBR", SqlNull(KEY_CLM_ADJ_NBR)),
						new SqlParameter("KEY_P_CLM_TYPE", SqlNull(KEY_P_CLM_TYPE)),
						new SqlParameter("KEY_P_CLM_DATA", SqlNull(KEY_P_CLM_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DESC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString();
						CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString();
						CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString();
						CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString();
						KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString();
						KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString();
						KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString();
						_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString();
						_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString();
						_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString();
						_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr = Reader["KEY_CLM_BATCH_NBR"].ToString();
						_originalKey_clm_claim_nbr = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						_originalKey_clm_serv_code = Reader["KEY_CLM_SERV_CODE"].ToString();
						_originalKey_clm_adj_nbr = Reader["KEY_CLM_ADJ_NBR"].ToString();
						_originalKey_p_clm_type = Reader["KEY_P_CLM_TYPE"].ToString();
						_originalKey_p_clm_data = Reader["KEY_P_CLM_DATA"].ToString();
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