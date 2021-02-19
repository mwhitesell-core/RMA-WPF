using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;
using System.Diagnostics;

namespace RmaDAL
{
    public partial class F002_CLAIMS_MSTR_HDR
    {

        public int WhereClinic_nbr { get; set; }
        private int _whereClinic_nbr;

        private int? _CLINIC_NBR;
        public int?  CLINIC_NBR
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


        public ObservableCollection<F002_CLAIMS_MSTR_HDR> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F002_CLAIMS_MSTR_HDR> f002_claims_mstr_hdr = null)
        {
            if (f002_claims_mstr_hdr != null)
            {
                F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = f002_claims_mstr_hdr.FirstOrDefault();
                if (objF002_CLAIMS_MSTR_HDR != null)
                {                    
                    _whereKey_clm_type = objF002_CLAIMS_MSTR_HDR._KEY_CLM_TYPE;                 
                    _whereKey_clm_batch_nbr = objF002_CLAIMS_MSTR_HDR._KEY_CLM_BATCH_NBR;                    
                    _whereKey_clm_claim_nbr = objF002_CLAIMS_MSTR_HDR._KEY_CLM_CLAIM_NBR;                    
                    _whereKey_clm_serv_code = objF002_CLAIMS_MSTR_HDR._KEY_CLM_SERV_CODE;                    
                    _whereKey_clm_adj_nbr = objF002_CLAIMS_MSTR_HDR._KEY_CLM_ADJ_NBR;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f002_claims_mstr_hdr;
                    }
                }
            }

            var collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[CLMHDR_BATCH_NBR]")
               .Append(" ,[CLMHDR_CLAIM_NBR]")
               .Append(" ,[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,[CLMHDR_BATCH_TYPE]")
               .Append(" ,[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,[CLMHDR_DIAG_CD]")
               .Append(" ,[CLMHDR_LOC]")
               .Append(" ,[CLMHDR_HOSP]")
               .Append(" ,[CLMHDR_AGENT_CD]")
               .Append(" ,[CLMHDR_ADJ_CD]")
               .Append(" ,[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,[CLMHDR_I_O_PAT_IND]")
               .Append(" ,[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,[CLMHDR_REFERENCE]")
               .Append(" ,[CLMHDR_DATE_ADMIT]")
               .Append(" ,[CLMHDR_DOC_DEPT]")
               .Append(" ,[CLMHDR_MSG_NBR]")
               .Append(" ,[CLMHDR_REPRINT_FLAG]")
               .Append(" ,[CLMHDR_SUB_NBR]")
               .Append(" ,[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,[CLMHDR_FEE_COMPLEX]")
               .Append(" ,[FILLER]")
               .Append(" ,[CLMHDR_CURR_PAYMENT]")
               .Append(" ,[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,[CLMHDR_CYCLE_NBR]")
               .Append(" ,[CLMHDR_DATE_SYS]")
               .Append(" ,[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,[CLMHDR_STATUS_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,[CLMHDR_SUBMIT_DATE]")
               .Append(" ,[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,[CLMHDR_SERV_DATE]")
               .Append(" ,[CLMHDR_ELIG_ERROR]")
               .Append(" ,[CLMHDR_ELIG_STATUS]")
               .Append(" ,[CLMHDR_SERV_ERROR]")
               .Append(" ,[CLMHDR_SERV_STATUS]")
               .Append(" ,[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,[CLMHDR_ORIG_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_TYPE]")
               .Append(" ,[KEY_CLM_BATCH_NBR]")
               .Append(" ,[KEY_CLM_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_SERV_CODE]")
               .Append(" ,[KEY_CLM_ADJ_NBR]")
               .Append(" ,[KEY_P_CLM_TYPE]")
               .Append(" ,[KEY_P_CLM_DATA]")
               .Append(" FROM")
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_HDR]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               .Append(" AND")
               .Append(" KEY_CLM_BATCH_NBR >= '").Append(WhereKey_clm_batch_nbr).Append("'")
               .Append(" AND")
               .Append(" KEY_CLM_CLAIM_NBR >= ").Append(WhereKey_clm_claim_nbr)
               .Append(" AND")
               .Append(" KEY_CLM_SERV_CODE >= '").Append(WhereKey_clm_serv_code).Append("'")
               .Append(" AND")
               .Append(" KEY_CLM_ADJ_NBR >= '").Append(WhereKey_clm_adj_nbr).Append("'")
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               .Append(" KEY_CLM_BATCH_NBR, ")
               .Append(" KEY_CLM_CLAIM_NBR,")
               .Append(" KEY_CLM_SERV_CODE,")
               .Append(" KEY_CLM_ADJ_NBR");

            Reader = CoreReader(sql.ToString());

            while(Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_HDR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
                    CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
                    CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
                    CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
                    CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
                    CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
                    CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
                    CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
                    CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
                    CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
                    CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
                    CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
                    CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
                    CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
                    CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
                    CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
                    CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
                    CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
                    CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
                    CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
                    CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString(),
                    CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
                    CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
                    CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
                    CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
                    FILLER = Reader["FILLER"].ToString(),
                    CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
                    CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
                    CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
                    CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
                    CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
                    CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
                    CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
                    CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
                    CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
                    CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
                    CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
                    CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
                    CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
                    CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
                    CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString(),
                    CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
                    CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString(),
                    CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),

                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                    _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                    _whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr,
                    _whereClmhdr_batch_type = WhereClmhdr_batch_type,
                    _whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
                    _whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
                    _whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
                    _whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
                    _whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
                    _whereClmhdr_loc = WhereClmhdr_loc,
                    _whereClmhdr_hosp = WhereClmhdr_hosp,
                    _whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
                    _whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
                    _whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
                    _whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
                    _whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
                    _whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
                    _whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6,
                    _whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3,
                    _whereClmhdr_reference = WhereClmhdr_reference,
                    _whereClmhdr_date_admit = WhereClmhdr_date_admit,
                    _whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
                    _whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr,
                    _whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag,
                    _whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
                    _whereClmhdr_auto_logout = WhereClmhdr_auto_logout,
                    _whereClmhdr_fee_complex = WhereClmhdr_fee_complex,
                    _whereFiller = WhereFiller,
                    _whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
                    _whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
                    _whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr,
                    _whereClmhdr_date_sys = WhereClmhdr_date_sys,
                    _whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed,
                    _whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
                    _whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma,
                    _whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip,
                    _whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
                    _whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
                    _whereClmhdr_manual_review = WhereClmhdr_manual_review,
                    _whereClmhdr_submit_date = WhereClmhdr_submit_date,
                    _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                    _whereClmhdr_serv_date = WhereClmhdr_serv_date,
                    _whereClmhdr_elig_error = WhereClmhdr_elig_error,
                    _whereClmhdr_elig_status = WhereClmhdr_elig_status,
                    _whereClmhdr_serv_error = WhereClmhdr_serv_error,
                    _whereClmhdr_serv_status = WhereClmhdr_serv_status,
                    _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                    _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                    _whereKey_clm_type = WhereKey_clm_type,
                    _whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
                    _whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
                    _whereKey_clm_serv_code = WhereKey_clm_serv_code,
                    _whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
                    _whereKey_p_clm_type = WhereKey_p_clm_type,
                    _whereKey_p_clm_data = WhereKey_p_clm_data,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            return collection;
        }

        public F002_CLAIMS_MSTR_HDR Collection_ReadStart()
        {                                 
            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP 1 ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(",ROWID")
               .Append(" ,[CLMHDR_BATCH_NBR]")
               .Append(" ,[CLMHDR_CLAIM_NBR]")
               .Append(" ,[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,[CLMHDR_BATCH_TYPE]")
               .Append(" ,[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,[CLMHDR_DIAG_CD]")
               .Append(" ,[CLMHDR_LOC]")
               .Append(" ,[CLMHDR_HOSP]")
               .Append(" ,[CLMHDR_AGENT_CD]")
               .Append(" ,[CLMHDR_ADJ_CD]")
               .Append(" ,[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,[CLMHDR_I_O_PAT_IND]")
               .Append(" ,[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,[CLMHDR_REFERENCE]")
               .Append(" ,[CLMHDR_DATE_ADMIT]")
               .Append(" ,[CLMHDR_DOC_DEPT]")
               .Append(" ,[CLMHDR_MSG_NBR]")
               .Append(" ,[CLMHDR_REPRINT_FLAG]")
               .Append(" ,[CLMHDR_SUB_NBR]")
               .Append(" ,[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,[CLMHDR_FEE_COMPLEX]")
               .Append(" ,[FILLER]")
               .Append(" ,[CLMHDR_CURR_PAYMENT]")
               .Append(" ,[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,[CLMHDR_CYCLE_NBR]")
               .Append(" ,[CLMHDR_DATE_SYS]")
               .Append(" ,[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,[CLMHDR_STATUS_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,[CLMHDR_SUBMIT_DATE]")
               .Append(" ,[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,[CLMHDR_SERV_DATE]")
               .Append(" ,[CLMHDR_ELIG_ERROR]")
               .Append(" ,[CLMHDR_ELIG_STATUS]")
               .Append(" ,[CLMHDR_SERV_ERROR]")
               .Append(" ,[CLMHDR_SERV_STATUS]")
               .Append(" ,[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,[CLMHDR_ORIG_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_TYPE]")
               .Append(" ,[KEY_CLM_BATCH_NBR]")
               .Append(" ,[KEY_CLM_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_SERV_CODE]")
               .Append(" ,[KEY_CLM_ADJ_NBR]")
               .Append(" ,[KEY_P_CLM_TYPE]")
               .Append(" ,[KEY_P_CLM_DATA]")
               .Append(" FROM")
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_HDR]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_BATCH_NBR >= '").Append(WhereClmhdr_batch_nbr).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr)
               .Append(" AND")
               .Append(" CLMHDR_ADJ_OMA_CD >= '").Append(WhereClmhdr_adj_oma_cd).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_ADJ_OMA_SUFF >= '").Append(WhereClmhdr_adj_oma_suff).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_ADJ_ADJ_NBR >= '").Append(WhereClmhdr_adj_adj_nbr).Append("'")
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               .Append(" CLMHDR_BATCH_NBR,")
               .Append(" CLMHDR_CLAIM_NBR,")
               .Append(" CLMHDR_ADJ_OMA_CD,")
               .Append(" CLMHDR_ADJ_OMA_SUFF,")
               .Append(" CLMHDR_ADJ_ADJ_NBR");
             

            Reader = CoreReader(sql.ToString());

            F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR = null;

            while (Reader.Read())
            {
                objF002_CLAIMS_MSTR_HDR =   new F002_CLAIMS_MSTR_HDR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
                    CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
                    CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
                    CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
                    CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
                    CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
                    CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
                    CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
                    CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
                    CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
                    CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
                    CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
                    CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
                    CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
                    CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
                    CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
                    CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
                    CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
                    CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
                    CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
                    CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString(),
                    CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
                    CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
                    CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
                    CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
                    FILLER = Reader["FILLER"].ToString(),
                    CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
                    CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
                    CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
                    CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
                    CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
                    CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
                    CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
                    CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
                    CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
                    CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
                    CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
                    CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
                    CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
                    CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
                    CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString(),
                    CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
                    CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString(),
                    CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),

                    _whereRowid = WhereRowid,
                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                    _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                    _whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr,
                    _whereClmhdr_batch_type = WhereClmhdr_batch_type,
                    _whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
                    _whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
                    _whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
                    _whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
                    _whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
                    _whereClmhdr_loc = WhereClmhdr_loc,
                    _whereClmhdr_hosp = WhereClmhdr_hosp,
                    _whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
                    _whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
                    _whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
                    _whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
                    _whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
                    _whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
                    _whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6,
                    _whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3,
                    _whereClmhdr_reference = WhereClmhdr_reference,
                    _whereClmhdr_date_admit = WhereClmhdr_date_admit,
                    _whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
                    _whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr,
                    _whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag,
                    _whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
                    _whereClmhdr_auto_logout = WhereClmhdr_auto_logout,
                    _whereClmhdr_fee_complex = WhereClmhdr_fee_complex,
                    _whereFiller = WhereFiller,
                    _whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
                    _whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
                    _whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr,
                    _whereClmhdr_date_sys = WhereClmhdr_date_sys,
                    _whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed,
                    _whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
                    _whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma,
                    _whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip,
                    _whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
                    _whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
                    _whereClmhdr_manual_review = WhereClmhdr_manual_review,
                    _whereClmhdr_submit_date = WhereClmhdr_submit_date,
                    _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                    _whereClmhdr_serv_date = WhereClmhdr_serv_date,
                    _whereClmhdr_elig_error = WhereClmhdr_elig_error,
                    _whereClmhdr_elig_status = WhereClmhdr_elig_status,
                    _whereClmhdr_serv_error = WhereClmhdr_serv_error,
                    _whereClmhdr_serv_status = WhereClmhdr_serv_status,
                    _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                    _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                    _whereKey_clm_type = WhereKey_clm_type,
                    _whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
                    _whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
                    _whereKey_clm_serv_code = WhereKey_clm_serv_code,
                    _whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
                    _whereKey_p_clm_type = WhereKey_p_clm_type,
                    _whereKey_p_clm_data = WhereKey_p_clm_data,

                    RecordState = State.UnChanged
                };
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_HDR;
        }

        public F002_CLAIMS_MSTR_HDR Collection_ReadNext(F002_CLAIMS_MSTR_HDR objF002_CLAIMS_MSTR_HDR)
        {
            StringBuilder sql = null;
            sql = new StringBuilder();
           
            sql.Append("SELECT TOP 2 ")
               .Append(" ROW_NUMBER() OVER (ORDER BY KEY_CLM_TYPE,CLMHDR_BATCH_NBR,CLMHDR_CLAIM_NBR,CLMHDR_ADJ_OMA_CD,CLMHDR_ADJ_OMA_SUFF,CLMHDR_ADJ_ADJ_NBR) AS 'ROWNUM'")
               .Append(" ,BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,ROWID")
               .Append(" ,[CLMHDR_BATCH_NBR]")
               .Append(" ,[CLMHDR_CLAIM_NBR]")
               .Append(" ,[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,[CLMHDR_BATCH_TYPE]")
               .Append(" ,[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,[CLMHDR_DIAG_CD]")
               .Append(" ,[CLMHDR_LOC]")
               .Append(" ,[CLMHDR_HOSP]")
               .Append(" ,[CLMHDR_AGENT_CD]")
               .Append(" ,[CLMHDR_ADJ_CD]")
               .Append(" ,[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,[CLMHDR_I_O_PAT_IND]")
               .Append(" ,[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,[CLMHDR_REFERENCE]")
               .Append(" ,[CLMHDR_DATE_ADMIT]")
               .Append(" ,[CLMHDR_DOC_DEPT]")
               .Append(" ,[CLMHDR_MSG_NBR]")
               .Append(" ,[CLMHDR_REPRINT_FLAG]")
               .Append(" ,[CLMHDR_SUB_NBR]")
               .Append(" ,[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,[CLMHDR_FEE_COMPLEX]")
               .Append(" ,[FILLER]")
               .Append(" ,[CLMHDR_CURR_PAYMENT]")
               .Append(" ,[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,[CLMHDR_CYCLE_NBR]")
               .Append(" ,[CLMHDR_DATE_SYS]")
               .Append(" ,[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,[CLMHDR_STATUS_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,[CLMHDR_SUBMIT_DATE]")
               .Append(" ,[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,[CLMHDR_SERV_DATE]")
               .Append(" ,[CLMHDR_ELIG_ERROR]")
               .Append(" ,[CLMHDR_ELIG_STATUS]")
               .Append(" ,[CLMHDR_SERV_ERROR]")
               .Append(" ,[CLMHDR_SERV_STATUS]")
               .Append(" ,[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,[CLMHDR_ORIG_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_TYPE]")
               .Append(" ,[KEY_CLM_BATCH_NBR]")
               .Append(" ,[KEY_CLM_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_SERV_CODE]")
               .Append(" ,[KEY_CLM_ADJ_NBR]")
               .Append(" ,[KEY_P_CLM_TYPE]")
               .Append(" ,[KEY_P_CLM_DATA]")
               .Append(" FROM")
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_HDR]  WITH (NOLOCK) ")
               .Append(" WHERE")               
               .Append(" KEY_CLM_TYPE >= '").Append(objF002_CLAIMS_MSTR_HDR.KEY_CLM_TYPE).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_BATCH_NBR >= '").Append(objF002_CLAIMS_MSTR_HDR.KEY_CLM_BATCH_NBR).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_CLAIM_NBR >= ").Append(objF002_CLAIMS_MSTR_HDR.CLMHDR_CLAIM_NBR)
               .Append(" AND")
               .Append(" CLMHDR_ADJ_OMA_CD >= '").Append(objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_CD).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_ADJ_OMA_SUFF >= '").Append(objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_OMA_SUFF).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_ADJ_ADJ_NBR >= '").Append(objF002_CLAIMS_MSTR_HDR.CLMHDR_ADJ_ADJ_NBR).Append("'")
               .Append(" ORDER BY")
                .Append(" KEY_CLM_TYPE, ")
               .Append(" CLMHDR_BATCH_NBR,")
               .Append(" CLMHDR_CLAIM_NBR,")
               .Append(" CLMHDR_ADJ_OMA_CD,")
               .Append(" CLMHDR_ADJ_OMA_SUFF,")
               .Append(" CLMHDR_ADJ_ADJ_NBR");

            Reader = CoreReader(sql.ToString());
            objF002_CLAIMS_MSTR_HDR = null;

            while (Reader.Read())
            {
                if (ConvertINT(Reader["ROWNUM"]) == 2)
                {
                    objF002_CLAIMS_MSTR_HDR = new F002_CLAIMS_MSTR_HDR
                    {
                        RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                        ROWID = (Guid)Reader["ROWID"],
                        CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                        CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                        CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                        CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                        CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
                        CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
                        CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
                        CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
                        CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
                        CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
                        CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
                        CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
                        CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
                        CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
                        CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
                        CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
                        CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
                        CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
                        CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
                        CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
                        CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
                        CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
                        CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
                        CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
                        CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString(),
                        CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
                        CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
                        CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
                        CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
                        FILLER = Reader["FILLER"].ToString(),
                        CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
                        CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
                        CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
                        CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
                        CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
                        CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
                        CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
                        CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
                        CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
                        CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
                        CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
                        CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
                        CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                        CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
                        CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
                        CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString(),
                        CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
                        CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString(),
                        CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                        CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                        KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                        KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                        KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                        KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                        KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                        KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                        KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),

                        _whereRowid = WhereRowid,
                        _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                        _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                        _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                        _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                        _whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr,
                        _whereClmhdr_batch_type = WhereClmhdr_batch_type,
                        _whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
                        _whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
                        _whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
                        _whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
                        _whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
                        _whereClmhdr_loc = WhereClmhdr_loc,
                        _whereClmhdr_hosp = WhereClmhdr_hosp,
                        _whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
                        _whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
                        _whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
                        _whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
                        _whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
                        _whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
                        _whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6,
                        _whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3,
                        _whereClmhdr_reference = WhereClmhdr_reference,
                        _whereClmhdr_date_admit = WhereClmhdr_date_admit,
                        _whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
                        _whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr,
                        _whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag,
                        _whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
                        _whereClmhdr_auto_logout = WhereClmhdr_auto_logout,
                        _whereClmhdr_fee_complex = WhereClmhdr_fee_complex,
                        _whereFiller = WhereFiller,
                        _whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
                        _whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
                        _whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr,
                        _whereClmhdr_date_sys = WhereClmhdr_date_sys,
                        _whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed,
                        _whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
                        _whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma,
                        _whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip,
                        _whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
                        _whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
                        _whereClmhdr_manual_review = WhereClmhdr_manual_review,
                        _whereClmhdr_submit_date = WhereClmhdr_submit_date,
                        _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                        _whereClmhdr_serv_date = WhereClmhdr_serv_date,
                        _whereClmhdr_elig_error = WhereClmhdr_elig_error,
                        _whereClmhdr_elig_status = WhereClmhdr_elig_status,
                        _whereClmhdr_serv_error = WhereClmhdr_serv_error,
                        _whereClmhdr_serv_status = WhereClmhdr_serv_status,
                        _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                        _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                        _whereKey_clm_type = WhereKey_clm_type,
                        _whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
                        _whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
                        _whereKey_clm_serv_code = WhereKey_clm_serv_code,
                        _whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
                        _whereKey_p_clm_type = WhereKey_p_clm_type,
                        _whereKey_p_clm_data = WhereKey_p_clm_data,

                        RecordState = State.UnChanged
                    };
                }
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_HDR;
        }


        public ObservableCollection<F002_CLAIMS_MSTR_HDR> Collection_ClinicNbr()
        {
           
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();            
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" DISTINCT LEFT(CLMHDR_BATCH_NBR,2) CLINIC_NBR ")
               .Append(" FROM")
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_HDR]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" CLMHDR_DATE_PERIOD_END <= ").Append(WhereClmhdr_date_period_end)
              // .Append(" AND ")  // debugging only 
              // .Append (" LEFT(CLMHDR_BATCH_NBR,2) IN (75,72) ")  // debugging only
               .Append(" ORDER BY LEFT(CLMHDR_BATCH_NBR,2)  asc ");
               
            Debug.WriteLine(sql.ToString());

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_HDR
                {
                    
                    CLINIC_NBR = ConvertINT(Reader["CLINIC_NBR"]),
                    
                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                    _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                    _whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr,
                    _whereClmhdr_batch_type = WhereClmhdr_batch_type,
                    _whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
                    _whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
                    _whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
                    _whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
                    _whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
                    _whereClmhdr_loc = WhereClmhdr_loc,
                    _whereClmhdr_hosp = WhereClmhdr_hosp,
                    _whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
                    _whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
                    _whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
                    _whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
                    _whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
                    _whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
                    _whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6,
                    _whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3,
                    _whereClmhdr_reference = WhereClmhdr_reference,
                    _whereClmhdr_date_admit = WhereClmhdr_date_admit,
                    _whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
                    _whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr,
                    _whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag,
                    _whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
                    _whereClmhdr_auto_logout = WhereClmhdr_auto_logout,
                    _whereClmhdr_fee_complex = WhereClmhdr_fee_complex,
                    _whereFiller = WhereFiller,
                    _whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
                    _whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
                    _whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr,
                    _whereClmhdr_date_sys = WhereClmhdr_date_sys,
                    _whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed,
                    _whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
                    _whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma,
                    _whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip,
                    _whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
                    _whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
                    _whereClmhdr_manual_review = WhereClmhdr_manual_review,
                    _whereClmhdr_submit_date = WhereClmhdr_submit_date,
                    _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                    _whereClmhdr_serv_date = WhereClmhdr_serv_date,
                    _whereClmhdr_elig_error = WhereClmhdr_elig_error,
                    _whereClmhdr_elig_status = WhereClmhdr_elig_status,
                    _whereClmhdr_serv_error = WhereClmhdr_serv_error,
                    _whereClmhdr_serv_status = WhereClmhdr_serv_status,
                    _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                    _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                    _whereKey_clm_type = WhereKey_clm_type,
                    _whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
                    _whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
                    _whereKey_clm_serv_code = WhereKey_clm_serv_code,
                    _whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
                    _whereKey_p_clm_type = WhereKey_p_clm_type,
                    _whereKey_p_clm_data = WhereKey_p_clm_data,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            return collection;
        }

        public ObservableCollection<F002_CLAIMS_MSTR_HDR> Collection_ClinicNbr_CutOff_Date(bool isClosedConnection = true, SqlConnection objConn = null)
        {           

            var collection = new ObservableCollection<F002_CLAIMS_MSTR_HDR>();            
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[CLMHDR_BATCH_NBR]")
               .Append(" ,[CLMHDR_CLAIM_NBR]")
               .Append(" ,[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,[CLMHDR_BATCH_TYPE]")
               .Append(" ,[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,[CLMHDR_DIAG_CD]")
               .Append(" ,[CLMHDR_LOC]")
               .Append(" ,[CLMHDR_HOSP]")
               .Append(" ,[CLMHDR_AGENT_CD]")
               .Append(" ,[CLMHDR_ADJ_CD]")
               .Append(" ,[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,[CLMHDR_I_O_PAT_IND]")
               .Append(" ,[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,[CLMHDR_REFERENCE]")
               .Append(" ,[CLMHDR_DATE_ADMIT]")
               .Append(" ,[CLMHDR_DOC_DEPT]")
               .Append(" ,[CLMHDR_MSG_NBR]")
               .Append(" ,[CLMHDR_REPRINT_FLAG]")
               .Append(" ,[CLMHDR_SUB_NBR]")
               .Append(" ,[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,[CLMHDR_FEE_COMPLEX]")
               .Append(" ,[FILLER]")
               .Append(" ,[CLMHDR_CURR_PAYMENT]")
               .Append(" ,[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,[CLMHDR_CYCLE_NBR]")
               .Append(" ,[CLMHDR_DATE_SYS]")
               .Append(" ,[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,[CLMHDR_STATUS_OHIP]")
               .Append(" ,[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,[CLMHDR_SUBMIT_DATE]")
               .Append(" ,[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,[CLMHDR_SERV_DATE]")
               .Append(" ,[CLMHDR_ELIG_ERROR]")
               .Append(" ,[CLMHDR_ELIG_STATUS]")
               .Append(" ,[CLMHDR_SERV_ERROR]")
               .Append(" ,[CLMHDR_SERV_STATUS]")
               .Append(" ,[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,[CLMHDR_ORIG_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_TYPE]")
               .Append(" ,[KEY_CLM_BATCH_NBR]")
               .Append(" ,[KEY_CLM_CLAIM_NBR]")
               .Append(" ,[KEY_CLM_SERV_CODE]")
               .Append(" ,[KEY_CLM_ADJ_NBR]")
               .Append(" ,[KEY_P_CLM_TYPE]")
               .Append(" ,[KEY_P_CLM_DATA]")
               .Append(" FROM")
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_HDR]  WITH (NOLOCK) ")
               .Append(" WHERE")
               //.Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               //.Append(" AND")
               .Append(" LEFT(KEY_CLM_BATCH_NBR,2) = '").Append(WhereClinic_nbr).Append("'")
               .Append(" AND")
               .Append(" CLMHDR_DATE_PERIOD_END <= ").Append(WhereClmhdr_date_period_end)
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               .Append(" KEY_CLM_BATCH_NBR, ")
               .Append(" KEY_CLM_CLAIM_NBR,")
               .Append(" KEY_CLM_SERV_CODE,")
               .Append(" KEY_CLM_ADJ_NBR");

            Debug.WriteLine(sql.ToString());

            if (!isClosedConnection)
            {
                Reader = CoreReader(sql.ToString(),objConn);
            }
            else {
                Reader = CoreReader(sql.ToString());
            }

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_HDR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
                    CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString(),
                    CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
                    CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
                    CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
                    CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
                    CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
                    CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
                    CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
                    CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
                    CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString(),
                    CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
                    CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
                    CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
                    CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
                    CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
                    CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
                    CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString(),
                    CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
                    CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
                    CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString(),
                    CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
                    CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString(),
                    CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
                    CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
                    FILLER = Reader["FILLER"].ToString(),
                    CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
                    CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
                    CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
                    CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString(),
                    CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
                    CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
                    CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
                    CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
                    CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
                    CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString(),
                    CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
                    CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
                    CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
                    CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString(),
                    CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString(),
                    CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString(),
                    CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString(),
                    CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),

                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                    _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                    _whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr,
                    _whereClmhdr_batch_type = WhereClmhdr_batch_type,
                    _whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type,
                    _whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
                    _whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
                    _whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
                    _whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
                    _whereClmhdr_loc = WhereClmhdr_loc,
                    _whereClmhdr_hosp = WhereClmhdr_hosp,
                    _whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
                    _whereClmhdr_adj_cd = WhereClmhdr_adj_cd,
                    _whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind,
                    _whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
                    _whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type,
                    _whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data,
                    _whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6,
                    _whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3,
                    _whereClmhdr_reference = WhereClmhdr_reference,
                    _whereClmhdr_date_admit = WhereClmhdr_date_admit,
                    _whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
                    _whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr,
                    _whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag,
                    _whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr,
                    _whereClmhdr_auto_logout = WhereClmhdr_auto_logout,
                    _whereClmhdr_fee_complex = WhereClmhdr_fee_complex,
                    _whereFiller = WhereFiller,
                    _whereClmhdr_curr_payment = WhereClmhdr_curr_payment,
                    _whereClmhdr_date_period_end = WhereClmhdr_date_period_end,
                    _whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr,
                    _whereClmhdr_date_sys = WhereClmhdr_date_sys,
                    _whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed,
                    _whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid,
                    _whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma,
                    _whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip,
                    _whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments,
                    _whereClmhdr_status_ohip = WhereClmhdr_status_ohip,
                    _whereClmhdr_manual_review = WhereClmhdr_manual_review,
                    _whereClmhdr_submit_date = WhereClmhdr_submit_date,
                    _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                    _whereClmhdr_serv_date = WhereClmhdr_serv_date,
                    _whereClmhdr_elig_error = WhereClmhdr_elig_error,
                    _whereClmhdr_elig_status = WhereClmhdr_elig_status,
                    _whereClmhdr_serv_error = WhereClmhdr_serv_error,
                    _whereClmhdr_serv_status = WhereClmhdr_serv_status,
                    _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                    _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                    _whereKey_clm_type = WhereKey_clm_type,
                    _whereKey_clm_batch_nbr = WhereKey_clm_batch_nbr,
                    _whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
                    _whereKey_clm_serv_code = WhereKey_clm_serv_code,
                    _whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
                    _whereKey_p_clm_type = WhereKey_p_clm_type,
                    _whereKey_p_clm_data = WhereKey_p_clm_data,

                    RecordState = State.UnChanged
                });
            }
         
           CloseConnection(isClosedConnection);         
            return collection;
        }
    }
}
