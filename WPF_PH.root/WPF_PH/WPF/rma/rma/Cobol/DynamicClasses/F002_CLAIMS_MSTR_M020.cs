using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIMS_MSTR_M020 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIMS_MSTR_M020> Collection( Guid? rowid,
															string claim_header_rec,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															string clmhdr_adj_oma_cd,
															string clmhdr_adj_oma_suff,
															string clmhdr_adj_adj_nbr,
															string clmhdr_batch_type,
															string clmhdr_adj_cd_sub_type,
															decimal? clmhdr_doc_nbr_ohipmin,
															decimal? clmhdr_doc_nbr_ohipmax,
															decimal? clmhdr_doc_spec_cdmin,
															decimal? clmhdr_doc_spec_cdmax,
															decimal? clmhdr_refer_doc_nbrmin,
															decimal? clmhdr_refer_doc_nbrmax,
															decimal? clmhdr_diag_cdmin,
															decimal? clmhdr_diag_cdmax,
															string clmhdr_loc,
															string clmhdr_hosp,
															decimal? clmhdr_agent_cdmin,
															decimal? clmhdr_agent_cdmax,
															string clmhdr_adj_cd,
															string clmhdr_tape_submit_ind,
															string clmhdr_i_o_pat_ind,
															string clmhdr_pat_key_type,
															string clmhdr_pat_key_data,
															string clmhdr_pat_acronym6,
															string clmhdr_pat_acronym3,
															string clmhdr_reference,
															string clmhdr_date_admit,
															decimal? clmhdr_doc_deptmin,
															decimal? clmhdr_doc_deptmax,
															string clmhdr_msg_nbr,
															string clmhdr_reprint_flag,
															string clmhdr_sub_nbr,
															string clmhdr_auto_logout,
															string clmhdr_fee_complex,
															string filler,
															decimal? clmhdr_curr_paymentmin,
															decimal? clmhdr_curr_paymentmax,
															decimal? clmhdr_date_period_endmin,
															decimal? clmhdr_date_period_endmax,
															decimal? clmhdr_cycle_nbrmin,
															decimal? clmhdr_cycle_nbrmax,
															string clmhdr_date_sys,
															decimal? clmhdr_amt_tech_billedmin,
															decimal? clmhdr_amt_tech_billedmax,
															decimal? clmhdr_amt_tech_paidmin,
															decimal? clmhdr_amt_tech_paidmax,
															decimal? clmhdr_tot_claim_ar_omamin,
															decimal? clmhdr_tot_claim_ar_omamax,
															decimal? clmhdr_tot_claim_ar_ohipmin,
															decimal? clmhdr_tot_claim_ar_ohipmax,
															decimal? clmhdr_manual_and_tape_paymentsmin,
															decimal? clmhdr_manual_and_tape_paymentsmax,
															string clmhdr_status_ohip,
															string clmhdr_manual_review,
															decimal? clmhdr_submit_datemin,
															decimal? clmhdr_submit_datemax,
															string clmhdr_confidential_flag,
															decimal? clmhdr_serv_datemin,
															decimal? clmhdr_serv_datemax,
															string clmhdr_elig_error,
															string clmhdr_elig_status,
															string clmhdr_serv_error,
															string clmhdr_serv_status,
															string clmhdr_orig_batch_nbr,
															decimal? clmhdr_orig_claim_nbrmin,
															decimal? clmhdr_orig_claim_nbrmax,
															string clmdtl_batch_nbr,
															decimal? clmdtl_claim_nbrmin,
															decimal? clmdtl_claim_nbrmax,
															string clmdtl_oma_cd,
															string clmdtl_oma_suff,
															decimal? clmdtl_adj_nbrmin,
															decimal? clmdtl_adj_nbrmax,
															string clmdtl_det_rec,
															string clmdtl_rev_group_cd,
															decimal? clmdtl_agent_cdmin,
															decimal? clmdtl_agent_cdmax,
															string clmdtl_adj_cd,
															decimal? clmdtl_nbr_servmin,
															decimal? clmdtl_nbr_servmax,
															decimal? clmdtl_sv_yymin,
															decimal? clmdtl_sv_yymax,
															decimal? clmdtl_sv_mmmin,
															decimal? clmdtl_sv_mmmax,
															decimal? clmdtl_sv_ddmin,
															decimal? clmdtl_sv_ddmax,
															decimal? clmdtl_consec_datesmin,
															decimal? clmdtl_consec_datesmax,
															decimal? clmdtl_consecutive_sv_date1min,
															decimal? clmdtl_consecutive_sv_date1max,
															decimal? clmdtl_consecutive_sv_date2min,
															decimal? clmdtl_consecutive_sv_date2max,
															decimal? clmdtl_consecutive_sv_date3min,
															decimal? clmdtl_consecutive_sv_date3max,
															decimal? clmdtl_amt_tech_billedmin,
															decimal? clmdtl_amt_tech_billedmax,
															decimal? clmdtl_fee_omamin,
															decimal? clmdtl_fee_omamax,
															decimal? clmdtl_fee_ohipmin,
															decimal? clmdtl_fee_ohipmax,
															string clmdtl_date_period_end,
															decimal? clmdtl_cycle_nbrmin,
															decimal? clmdtl_cycle_nbrmax,
															decimal? clmdtl_diag_cdmin,
															decimal? clmdtl_diag_cdmax,
															decimal? clmdtl_line_nomin,
															decimal? clmdtl_line_nomax,
															string clmdtl_resubmit_flag,
															string clmdtl_reserve_for_future,
															string clmdtl_desc,
															string clmdtl_filler0,
															string clmdtl_filler9,
															string clmdtl_orig_batch_nbr,
															decimal? clmdtl_orig_claim_nbr_in_batchmin,
															decimal? clmdtl_orig_claim_nbr_in_batchmax,
															string key_clm_type,
															string key_clm_batch_nbr_red,
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
					new SqlParameter("CLAIM_HEADER_REC",claim_header_rec),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("CLMHDR_ADJ_OMA_CD",clmhdr_adj_oma_cd),
					new SqlParameter("CLMHDR_ADJ_OMA_SUFF",clmhdr_adj_oma_suff),
					new SqlParameter("CLMHDR_ADJ_ADJ_NBR",clmhdr_adj_adj_nbr),
					new SqlParameter("CLMHDR_BATCH_TYPE",clmhdr_batch_type),
					new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE",clmhdr_adj_cd_sub_type),
					new SqlParameter("minCLMHDR_DOC_NBR_OHIP",clmhdr_doc_nbr_ohipmin),
					new SqlParameter("maxCLMHDR_DOC_NBR_OHIP",clmhdr_doc_nbr_ohipmax),
					new SqlParameter("minCLMHDR_DOC_SPEC_CD",clmhdr_doc_spec_cdmin),
					new SqlParameter("maxCLMHDR_DOC_SPEC_CD",clmhdr_doc_spec_cdmax),
					new SqlParameter("minCLMHDR_REFER_DOC_NBR",clmhdr_refer_doc_nbrmin),
					new SqlParameter("maxCLMHDR_REFER_DOC_NBR",clmhdr_refer_doc_nbrmax),
					new SqlParameter("minCLMHDR_DIAG_CD",clmhdr_diag_cdmin),
					new SqlParameter("maxCLMHDR_DIAG_CD",clmhdr_diag_cdmax),
					new SqlParameter("CLMHDR_LOC",clmhdr_loc),
					new SqlParameter("CLMHDR_HOSP",clmhdr_hosp),
					new SqlParameter("minCLMHDR_AGENT_CD",clmhdr_agent_cdmin),
					new SqlParameter("maxCLMHDR_AGENT_CD",clmhdr_agent_cdmax),
					new SqlParameter("CLMHDR_ADJ_CD",clmhdr_adj_cd),
					new SqlParameter("CLMHDR_TAPE_SUBMIT_IND",clmhdr_tape_submit_ind),
					new SqlParameter("CLMHDR_I_O_PAT_IND",clmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_PAT_KEY_TYPE",clmhdr_pat_key_type),
					new SqlParameter("CLMHDR_PAT_KEY_DATA",clmhdr_pat_key_data),
					new SqlParameter("CLMHDR_PAT_ACRONYM6",clmhdr_pat_acronym6),
					new SqlParameter("CLMHDR_PAT_ACRONYM3",clmhdr_pat_acronym3),
					new SqlParameter("CLMHDR_REFERENCE",clmhdr_reference),
					new SqlParameter("CLMHDR_DATE_ADMIT",clmhdr_date_admit),
					new SqlParameter("minCLMHDR_DOC_DEPT",clmhdr_doc_deptmin),
					new SqlParameter("maxCLMHDR_DOC_DEPT",clmhdr_doc_deptmax),
					new SqlParameter("CLMHDR_MSG_NBR",clmhdr_msg_nbr),
					new SqlParameter("CLMHDR_REPRINT_FLAG",clmhdr_reprint_flag),
					new SqlParameter("CLMHDR_SUB_NBR",clmhdr_sub_nbr),
					new SqlParameter("CLMHDR_AUTO_LOGOUT",clmhdr_auto_logout),
					new SqlParameter("CLMHDR_FEE_COMPLEX",clmhdr_fee_complex),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmin),
					new SqlParameter("maxCLMHDR_CURR_PAYMENT",clmhdr_curr_paymentmax),
					new SqlParameter("minCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmin),
					new SqlParameter("maxCLMHDR_DATE_PERIOD_END",clmhdr_date_period_endmax),
					new SqlParameter("minCLMHDR_CYCLE_NBR",clmhdr_cycle_nbrmin),
					new SqlParameter("maxCLMHDR_CYCLE_NBR",clmhdr_cycle_nbrmax),
					new SqlParameter("CLMHDR_DATE_SYS",clmhdr_date_sys),
					new SqlParameter("minCLMHDR_AMT_TECH_BILLED",clmhdr_amt_tech_billedmin),
					new SqlParameter("maxCLMHDR_AMT_TECH_BILLED",clmhdr_amt_tech_billedmax),
					new SqlParameter("minCLMHDR_AMT_TECH_PAID",clmhdr_amt_tech_paidmin),
					new SqlParameter("maxCLMHDR_AMT_TECH_PAID",clmhdr_amt_tech_paidmax),
					new SqlParameter("minCLMHDR_TOT_CLAIM_AR_OMA",clmhdr_tot_claim_ar_omamin),
					new SqlParameter("maxCLMHDR_TOT_CLAIM_AR_OMA",clmhdr_tot_claim_ar_omamax),
					new SqlParameter("minCLMHDR_TOT_CLAIM_AR_OHIP",clmhdr_tot_claim_ar_ohipmin),
					new SqlParameter("maxCLMHDR_TOT_CLAIM_AR_OHIP",clmhdr_tot_claim_ar_ohipmax),
					new SqlParameter("minCLMHDR_MANUAL_AND_TAPE_PAYMENTS",clmhdr_manual_and_tape_paymentsmin),
					new SqlParameter("maxCLMHDR_MANUAL_AND_TAPE_PAYMENTS",clmhdr_manual_and_tape_paymentsmax),
					new SqlParameter("CLMHDR_STATUS_OHIP",clmhdr_status_ohip),
					new SqlParameter("CLMHDR_MANUAL_REVIEW",clmhdr_manual_review),
					new SqlParameter("minCLMHDR_SUBMIT_DATE",clmhdr_submit_datemin),
					new SqlParameter("maxCLMHDR_SUBMIT_DATE",clmhdr_submit_datemax),
					new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG",clmhdr_confidential_flag),
					new SqlParameter("minCLMHDR_SERV_DATE",clmhdr_serv_datemin),
					new SqlParameter("maxCLMHDR_SERV_DATE",clmhdr_serv_datemax),
					new SqlParameter("CLMHDR_ELIG_ERROR",clmhdr_elig_error),
					new SqlParameter("CLMHDR_ELIG_STATUS",clmhdr_elig_status),
					new SqlParameter("CLMHDR_SERV_ERROR",clmhdr_serv_error),
					new SqlParameter("CLMHDR_SERV_STATUS",clmhdr_serv_status),
					new SqlParameter("CLMHDR_ORIG_BATCH_NBR",clmhdr_orig_batch_nbr),
					new SqlParameter("minCLMHDR_ORIG_CLAIM_NBR",clmhdr_orig_claim_nbrmin),
					new SqlParameter("maxCLMHDR_ORIG_CLAIM_NBR",clmhdr_orig_claim_nbrmax),
					new SqlParameter("CLMDTL_BATCH_NBR",clmdtl_batch_nbr),
					new SqlParameter("minCLMDTL_CLAIM_NBR",clmdtl_claim_nbrmin),
					new SqlParameter("maxCLMDTL_CLAIM_NBR",clmdtl_claim_nbrmax),
					new SqlParameter("CLMDTL_OMA_CD",clmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",clmdtl_oma_suff),
					new SqlParameter("minCLMDTL_ADJ_NBR",clmdtl_adj_nbrmin),
					new SqlParameter("maxCLMDTL_ADJ_NBR",clmdtl_adj_nbrmax),
					new SqlParameter("CLMDTL_DET_REC",clmdtl_det_rec),
					new SqlParameter("CLMDTL_REV_GROUP_CD",clmdtl_rev_group_cd),
					new SqlParameter("minCLMDTL_AGENT_CD",clmdtl_agent_cdmin),
					new SqlParameter("maxCLMDTL_AGENT_CD",clmdtl_agent_cdmax),
					new SqlParameter("CLMDTL_ADJ_CD",clmdtl_adj_cd),
					new SqlParameter("minCLMDTL_NBR_SERV",clmdtl_nbr_servmin),
					new SqlParameter("maxCLMDTL_NBR_SERV",clmdtl_nbr_servmax),
					new SqlParameter("minCLMDTL_SV_YY",clmdtl_sv_yymin),
					new SqlParameter("maxCLMDTL_SV_YY",clmdtl_sv_yymax),
					new SqlParameter("minCLMDTL_SV_MM",clmdtl_sv_mmmin),
					new SqlParameter("maxCLMDTL_SV_MM",clmdtl_sv_mmmax),
					new SqlParameter("minCLMDTL_SV_DD",clmdtl_sv_ddmin),
					new SqlParameter("maxCLMDTL_SV_DD",clmdtl_sv_ddmax),
					new SqlParameter("minCLMDTL_CONSEC_DATES",clmdtl_consec_datesmin),
					new SqlParameter("maxCLMDTL_CONSEC_DATES",clmdtl_consec_datesmax),
					new SqlParameter("minCLMDTL_CONSECUTIVE_SV_DATE1",clmdtl_consecutive_sv_date1min),
					new SqlParameter("maxCLMDTL_CONSECUTIVE_SV_DATE1",clmdtl_consecutive_sv_date1max),
					new SqlParameter("minCLMDTL_CONSECUTIVE_SV_DATE2",clmdtl_consecutive_sv_date2min),
					new SqlParameter("maxCLMDTL_CONSECUTIVE_SV_DATE2",clmdtl_consecutive_sv_date2max),
					new SqlParameter("minCLMDTL_CONSECUTIVE_SV_DATE3",clmdtl_consecutive_sv_date3min),
					new SqlParameter("maxCLMDTL_CONSECUTIVE_SV_DATE3",clmdtl_consecutive_sv_date3max),
					new SqlParameter("minCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmin),
					new SqlParameter("maxCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmax),
					new SqlParameter("minCLMDTL_FEE_OMA",clmdtl_fee_omamin),
					new SqlParameter("maxCLMDTL_FEE_OMA",clmdtl_fee_omamax),
					new SqlParameter("minCLMDTL_FEE_OHIP",clmdtl_fee_ohipmin),
					new SqlParameter("maxCLMDTL_FEE_OHIP",clmdtl_fee_ohipmax),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",clmdtl_date_period_end),
					new SqlParameter("minCLMDTL_CYCLE_NBR",clmdtl_cycle_nbrmin),
					new SqlParameter("maxCLMDTL_CYCLE_NBR",clmdtl_cycle_nbrmax),
					new SqlParameter("minCLMDTL_DIAG_CD",clmdtl_diag_cdmin),
					new SqlParameter("maxCLMDTL_DIAG_CD",clmdtl_diag_cdmax),
					new SqlParameter("minCLMDTL_LINE_NO",clmdtl_line_nomin),
					new SqlParameter("maxCLMDTL_LINE_NO",clmdtl_line_nomax),
					new SqlParameter("CLMDTL_RESUBMIT_FLAG",clmdtl_resubmit_flag),
					new SqlParameter("CLMDTL_RESERVE_FOR_FUTURE",clmdtl_reserve_for_future),
					new SqlParameter("CLMDTL_DESC",clmdtl_desc),
					new SqlParameter("CLMDTL_FILLER0",clmdtl_filler0),
					new SqlParameter("CLMDTL_FILLER9",clmdtl_filler9),
					new SqlParameter("CLMDTL_ORIG_BATCH_NBR",clmdtl_orig_batch_nbr),
					new SqlParameter("minCLMDTL_ORIG_CLAIM_NBR_IN_BATCH",clmdtl_orig_claim_nbr_in_batchmin),
					new SqlParameter("maxCLMDTL_ORIG_CLAIM_NBR_IN_BATCH",clmdtl_orig_claim_nbr_in_batchmax),
					new SqlParameter("KEY_CLM_TYPE",key_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR_RED",key_clm_batch_nbr_red),
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
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIMS_MSTR_M020>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_M020>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_M020
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_HEADER_REC = Reader["CLAIM_HEADER_REC"].ToString(),
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
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_DET_REC = Reader["CLMDTL_DET_REC"].ToString(),
					CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					CLMDTL_CONSECUTIVE_SV_DATE1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]),
					CLMDTL_CONSECUTIVE_SV_DATE2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]),
					CLMDTL_CONSECUTIVE_SV_DATE3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]),
					CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CLMDTL_CYCLE_NBR = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]),
					CLMDTL_DIAG_CD = ConvertDEC(Reader["CLMDTL_DIAG_CD"]),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					CLMDTL_RESUBMIT_FLAG = Reader["CLMDTL_RESUBMIT_FLAG"].ToString(),
					CLMDTL_RESERVE_FOR_FUTURE = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString(),
					CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString(),
					CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString(),
					CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString(),
					CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR_RED = Reader["KEY_CLM_BATCH_NBR_RED"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
					KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
					KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_header_rec = Reader["CLAIM_HEADER_REC"].ToString(),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
					_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
					_originalClmhdr_adj_adj_nbr = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
					_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString(),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					_originalClmhdr_pat_acronym6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
					_originalClmhdr_pat_acronym3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_msg_nbr = Reader["CLMHDR_MSG_NBR"].ToString(),
					_originalClmhdr_reprint_flag = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
					_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString(),
					_originalClmhdr_auto_logout = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
					_originalClmhdr_fee_complex = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_cycle_nbr = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
					_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString(),
					_originalClmhdr_amt_tech_billed = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
					_originalClmhdr_amt_tech_paid = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
					_originalClmhdr_tot_claim_ar_oma = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
					_originalClmhdr_tot_claim_ar_ohip = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
					_originalClmhdr_manual_and_tape_payments = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalClmhdr_manual_review = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
					_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					_originalClmhdr_elig_status = Reader["CLMHDR_ELIG_STATUS"].ToString(),
					_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString(),
					_originalClmhdr_serv_status = Reader["CLMHDR_SERV_STATUS"].ToString(),
					_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
					_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
					_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString(),
					_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					_originalClmdtl_det_rec = Reader["CLMDTL_DET_REC"].ToString(),
					_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					_originalClmdtl_consecutive_sv_date1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]),
					_originalClmdtl_consecutive_sv_date2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]),
					_originalClmdtl_consecutive_sv_date3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]),
					_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalClmdtl_cycle_nbr = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]),
					_originalClmdtl_diag_cd = ConvertDEC(Reader["CLMDTL_DIAG_CD"]),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalClmdtl_resubmit_flag = Reader["CLMDTL_RESUBMIT_FLAG"].ToString(),
					_originalClmdtl_reserve_for_future = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString(),
					_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString(),
					_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString(),
					_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString(),
					_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr_red = Reader["KEY_CLM_BATCH_NBR_RED"].ToString(),
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

        public F002_CLAIMS_MSTR_M020 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIMS_MSTR_M020> Collection(ObservableCollection<F002_CLAIMS_MSTR_M020>
                                                               f002ClaimsMstrM020 = null)
        {
            if (IsSameSearch() && f002ClaimsMstrM020 != null)
            {
                return f002ClaimsMstrM020;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIMS_MSTR_M020>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLAIM_HEADER_REC",WhereClaim_header_rec),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("CLMHDR_ADJ_OMA_CD",WhereClmhdr_adj_oma_cd),
					new SqlParameter("CLMHDR_ADJ_OMA_SUFF",WhereClmhdr_adj_oma_suff),
					new SqlParameter("CLMHDR_ADJ_ADJ_NBR",WhereClmhdr_adj_adj_nbr),
					new SqlParameter("CLMHDR_BATCH_TYPE",WhereClmhdr_batch_type),
					new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE",WhereClmhdr_adj_cd_sub_type),
					new SqlParameter("CLMHDR_DOC_NBR_OHIP",WhereClmhdr_doc_nbr_ohip),
					new SqlParameter("CLMHDR_DOC_SPEC_CD",WhereClmhdr_doc_spec_cd),
					new SqlParameter("CLMHDR_REFER_DOC_NBR",WhereClmhdr_refer_doc_nbr),
					new SqlParameter("CLMHDR_DIAG_CD",WhereClmhdr_diag_cd),
					new SqlParameter("CLMHDR_LOC",WhereClmhdr_loc),
					new SqlParameter("CLMHDR_HOSP",WhereClmhdr_hosp),
					new SqlParameter("CLMHDR_AGENT_CD",WhereClmhdr_agent_cd),
					new SqlParameter("CLMHDR_ADJ_CD",WhereClmhdr_adj_cd),
					new SqlParameter("CLMHDR_TAPE_SUBMIT_IND",WhereClmhdr_tape_submit_ind),
					new SqlParameter("CLMHDR_I_O_PAT_IND",WhereClmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_PAT_KEY_TYPE",WhereClmhdr_pat_key_type),
					new SqlParameter("CLMHDR_PAT_KEY_DATA",WhereClmhdr_pat_key_data),
					new SqlParameter("CLMHDR_PAT_ACRONYM6",WhereClmhdr_pat_acronym6),
					new SqlParameter("CLMHDR_PAT_ACRONYM3",WhereClmhdr_pat_acronym3),
					new SqlParameter("CLMHDR_REFERENCE",WhereClmhdr_reference),
					new SqlParameter("CLMHDR_DATE_ADMIT",WhereClmhdr_date_admit),
					new SqlParameter("CLMHDR_DOC_DEPT",WhereClmhdr_doc_dept),
					new SqlParameter("CLMHDR_MSG_NBR",WhereClmhdr_msg_nbr),
					new SqlParameter("CLMHDR_REPRINT_FLAG",WhereClmhdr_reprint_flag),
					new SqlParameter("CLMHDR_SUB_NBR",WhereClmhdr_sub_nbr),
					new SqlParameter("CLMHDR_AUTO_LOGOUT",WhereClmhdr_auto_logout),
					new SqlParameter("CLMHDR_FEE_COMPLEX",WhereClmhdr_fee_complex),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CLMHDR_CURR_PAYMENT",WhereClmhdr_curr_payment),
					new SqlParameter("CLMHDR_DATE_PERIOD_END",WhereClmhdr_date_period_end),
					new SqlParameter("CLMHDR_CYCLE_NBR",WhereClmhdr_cycle_nbr),
					new SqlParameter("CLMHDR_DATE_SYS",WhereClmhdr_date_sys),
					new SqlParameter("CLMHDR_AMT_TECH_BILLED",WhereClmhdr_amt_tech_billed),
					new SqlParameter("CLMHDR_AMT_TECH_PAID",WhereClmhdr_amt_tech_paid),
					new SqlParameter("CLMHDR_TOT_CLAIM_AR_OMA",WhereClmhdr_tot_claim_ar_oma),
					new SqlParameter("CLMHDR_TOT_CLAIM_AR_OHIP",WhereClmhdr_tot_claim_ar_ohip),
					new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS",WhereClmhdr_manual_and_tape_payments),
					new SqlParameter("CLMHDR_STATUS_OHIP",WhereClmhdr_status_ohip),
					new SqlParameter("CLMHDR_MANUAL_REVIEW",WhereClmhdr_manual_review),
					new SqlParameter("CLMHDR_SUBMIT_DATE",WhereClmhdr_submit_date),
					new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG",WhereClmhdr_confidential_flag),
					new SqlParameter("CLMHDR_SERV_DATE",WhereClmhdr_serv_date),
					new SqlParameter("CLMHDR_ELIG_ERROR",WhereClmhdr_elig_error),
					new SqlParameter("CLMHDR_ELIG_STATUS",WhereClmhdr_elig_status),
					new SqlParameter("CLMHDR_SERV_ERROR",WhereClmhdr_serv_error),
					new SqlParameter("CLMHDR_SERV_STATUS",WhereClmhdr_serv_status),
					new SqlParameter("CLMHDR_ORIG_BATCH_NBR",WhereClmhdr_orig_batch_nbr),
					new SqlParameter("CLMHDR_ORIG_CLAIM_NBR",WhereClmhdr_orig_claim_nbr),
					new SqlParameter("CLMDTL_BATCH_NBR",WhereClmdtl_batch_nbr),
					new SqlParameter("CLMDTL_CLAIM_NBR",WhereClmdtl_claim_nbr),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",WhereClmdtl_oma_suff),
					new SqlParameter("CLMDTL_ADJ_NBR",WhereClmdtl_adj_nbr),
					new SqlParameter("CLMDTL_DET_REC",WhereClmdtl_det_rec),
					new SqlParameter("CLMDTL_REV_GROUP_CD",WhereClmdtl_rev_group_cd),
					new SqlParameter("CLMDTL_AGENT_CD",WhereClmdtl_agent_cd),
					new SqlParameter("CLMDTL_ADJ_CD",WhereClmdtl_adj_cd),
					new SqlParameter("CLMDTL_NBR_SERV",WhereClmdtl_nbr_serv),
					new SqlParameter("CLMDTL_SV_YY",WhereClmdtl_sv_yy),
					new SqlParameter("CLMDTL_SV_MM",WhereClmdtl_sv_mm),
					new SqlParameter("CLMDTL_SV_DD",WhereClmdtl_sv_dd),
					new SqlParameter("CLMDTL_CONSEC_DATES",WhereClmdtl_consec_dates),
					new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE1",WhereClmdtl_consecutive_sv_date1),
					new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE2",WhereClmdtl_consecutive_sv_date2),
					new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE3",WhereClmdtl_consecutive_sv_date3),
					new SqlParameter("CLMDTL_AMT_TECH_BILLED",WhereClmdtl_amt_tech_billed),
					new SqlParameter("CLMDTL_FEE_OMA",WhereClmdtl_fee_oma),
					new SqlParameter("CLMDTL_FEE_OHIP",WhereClmdtl_fee_ohip),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",WhereClmdtl_date_period_end),
					new SqlParameter("CLMDTL_CYCLE_NBR",WhereClmdtl_cycle_nbr),
					new SqlParameter("CLMDTL_DIAG_CD",WhereClmdtl_diag_cd),
					new SqlParameter("CLMDTL_LINE_NO",WhereClmdtl_line_no),
					new SqlParameter("CLMDTL_RESUBMIT_FLAG",WhereClmdtl_resubmit_flag),
					new SqlParameter("CLMDTL_RESERVE_FOR_FUTURE",WhereClmdtl_reserve_for_future),
					new SqlParameter("CLMDTL_DESC",WhereClmdtl_desc),
					new SqlParameter("CLMDTL_FILLER0",WhereClmdtl_filler0),
					new SqlParameter("CLMDTL_FILLER9",WhereClmdtl_filler9),
					new SqlParameter("CLMDTL_ORIG_BATCH_NBR",WhereClmdtl_orig_batch_nbr),
					new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH",WhereClmdtl_orig_claim_nbr_in_batch),
					new SqlParameter("KEY_CLM_TYPE",WhereKey_clm_type),
					new SqlParameter("KEY_CLM_BATCH_NBR_RED",WhereKey_clm_batch_nbr_red),
					new SqlParameter("KEY_CLM_CLAIM_NBR",WhereKey_clm_claim_nbr),
					new SqlParameter("KEY_CLM_SERV_CODE",WhereKey_clm_serv_code),
					new SqlParameter("KEY_CLM_ADJ_NBR",WhereKey_clm_adj_nbr),
					new SqlParameter("KEY_P_CLM_TYPE",WhereKey_p_clm_type),
					new SqlParameter("KEY_P_CLM_DATA",WhereKey_p_clm_data),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_M020>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_M020
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLAIM_HEADER_REC = Reader["CLAIM_HEADER_REC"].ToString(),
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
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_DET_REC = Reader["CLMDTL_DET_REC"].ToString(),
					CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					CLMDTL_CONSECUTIVE_SV_DATE1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]),
					CLMDTL_CONSECUTIVE_SV_DATE2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]),
					CLMDTL_CONSECUTIVE_SV_DATE3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]),
					CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CLMDTL_CYCLE_NBR = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]),
					CLMDTL_DIAG_CD = ConvertDEC(Reader["CLMDTL_DIAG_CD"]),
					CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					CLMDTL_RESUBMIT_FLAG = Reader["CLMDTL_RESUBMIT_FLAG"].ToString(),
					CLMDTL_RESERVE_FOR_FUTURE = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString(),
					CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString(),
					CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString(),
					CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString(),
					CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
					KEY_CLM_BATCH_NBR_RED = Reader["KEY_CLM_BATCH_NBR_RED"].ToString(),
					KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
					KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
					KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
					KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
					KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClaim_header_rec = WhereClaim_header_rec,
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
					_whereClmdtl_batch_nbr = WhereClmdtl_batch_nbr,
					_whereClmdtl_claim_nbr = WhereClmdtl_claim_nbr,
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff,
					_whereClmdtl_adj_nbr = WhereClmdtl_adj_nbr,
					_whereClmdtl_det_rec = WhereClmdtl_det_rec,
					_whereClmdtl_rev_group_cd = WhereClmdtl_rev_group_cd,
					_whereClmdtl_agent_cd = WhereClmdtl_agent_cd,
					_whereClmdtl_adj_cd = WhereClmdtl_adj_cd,
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv,
					_whereClmdtl_sv_yy = WhereClmdtl_sv_yy,
					_whereClmdtl_sv_mm = WhereClmdtl_sv_mm,
					_whereClmdtl_sv_dd = WhereClmdtl_sv_dd,
					_whereClmdtl_consec_dates = WhereClmdtl_consec_dates,
					_whereClmdtl_consecutive_sv_date1 = WhereClmdtl_consecutive_sv_date1,
					_whereClmdtl_consecutive_sv_date2 = WhereClmdtl_consecutive_sv_date2,
					_whereClmdtl_consecutive_sv_date3 = WhereClmdtl_consecutive_sv_date3,
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed,
					_whereClmdtl_fee_oma = WhereClmdtl_fee_oma,
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip,
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end,
					_whereClmdtl_cycle_nbr = WhereClmdtl_cycle_nbr,
					_whereClmdtl_diag_cd = WhereClmdtl_diag_cd,
					_whereClmdtl_line_no = WhereClmdtl_line_no,
					_whereClmdtl_resubmit_flag = WhereClmdtl_resubmit_flag,
					_whereClmdtl_reserve_for_future = WhereClmdtl_reserve_for_future,
					_whereClmdtl_desc = WhereClmdtl_desc,
					_whereClmdtl_filler0 = WhereClmdtl_filler0,
					_whereClmdtl_filler9 = WhereClmdtl_filler9,
					_whereClmdtl_orig_batch_nbr = WhereClmdtl_orig_batch_nbr,
					_whereClmdtl_orig_claim_nbr_in_batch = WhereClmdtl_orig_claim_nbr_in_batch,
					_whereKey_clm_type = WhereKey_clm_type,
					_whereKey_clm_batch_nbr_red = WhereKey_clm_batch_nbr_red,
					_whereKey_clm_claim_nbr = WhereKey_clm_claim_nbr,
					_whereKey_clm_serv_code = WhereKey_clm_serv_code,
					_whereKey_clm_adj_nbr = WhereKey_clm_adj_nbr,
					_whereKey_p_clm_type = WhereKey_p_clm_type,
					_whereKey_p_clm_data = WhereKey_p_clm_data,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClaim_header_rec = Reader["CLAIM_HEADER_REC"].ToString(),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
					_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
					_originalClmhdr_adj_adj_nbr = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString(),
					_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString(),
					_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString(),
					_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString(),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString(),
					_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString(),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString(),
					_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString(),
					_originalClmhdr_pat_acronym6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString(),
					_originalClmhdr_pat_acronym3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString(),
					_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString(),
					_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_msg_nbr = Reader["CLMHDR_MSG_NBR"].ToString(),
					_originalClmhdr_reprint_flag = Reader["CLMHDR_REPRINT_FLAG"].ToString(),
					_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString(),
					_originalClmhdr_auto_logout = Reader["CLMHDR_AUTO_LOGOUT"].ToString(),
					_originalClmhdr_fee_complex = Reader["CLMHDR_FEE_COMPLEX"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]),
					_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]),
					_originalClmhdr_cycle_nbr = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]),
					_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString(),
					_originalClmhdr_amt_tech_billed = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]),
					_originalClmhdr_amt_tech_paid = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]),
					_originalClmhdr_tot_claim_ar_oma = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]),
					_originalClmhdr_tot_claim_ar_ohip = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]),
					_originalClmhdr_manual_and_tape_payments = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]),
					_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString(),
					_originalClmhdr_manual_review = Reader["CLMHDR_MANUAL_REVIEW"].ToString(),
					_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]),
					_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
					_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]),
					_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString(),
					_originalClmhdr_elig_status = Reader["CLMHDR_ELIG_STATUS"].ToString(),
					_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString(),
					_originalClmhdr_serv_status = Reader["CLMHDR_SERV_STATUS"].ToString(),
					_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
					_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
					_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString(),
					_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString(),
					_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString(),
					_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					_originalClmdtl_det_rec = Reader["CLMDTL_DET_REC"].ToString(),
					_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					_originalClmdtl_consecutive_sv_date1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]),
					_originalClmdtl_consecutive_sv_date2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]),
					_originalClmdtl_consecutive_sv_date3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]),
					_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalClmdtl_cycle_nbr = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]),
					_originalClmdtl_diag_cd = ConvertDEC(Reader["CLMDTL_DIAG_CD"]),
					_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]),
					_originalClmdtl_resubmit_flag = Reader["CLMDTL_RESUBMIT_FLAG"].ToString(),
					_originalClmdtl_reserve_for_future = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString(),
					_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString(),
					_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString(),
					_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString(),
					_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString(),
					_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]),
					_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString(),
					_originalKey_clm_batch_nbr_red = Reader["KEY_CLM_BATCH_NBR_RED"].ToString(),
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
					_whereClaim_header_rec = WhereClaim_header_rec;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd;
					_whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff;
					_whereClmhdr_adj_adj_nbr = WhereClmhdr_adj_adj_nbr;
					_whereClmhdr_batch_type = WhereClmhdr_batch_type;
					_whereClmhdr_adj_cd_sub_type = WhereClmhdr_adj_cd_sub_type;
					_whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip;
					_whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd;
					_whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr;
					_whereClmhdr_diag_cd = WhereClmhdr_diag_cd;
					_whereClmhdr_loc = WhereClmhdr_loc;
					_whereClmhdr_hosp = WhereClmhdr_hosp;
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd;
					_whereClmhdr_adj_cd = WhereClmhdr_adj_cd;
					_whereClmhdr_tape_submit_ind = WhereClmhdr_tape_submit_ind;
					_whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind;
					_whereClmhdr_pat_key_type = WhereClmhdr_pat_key_type;
					_whereClmhdr_pat_key_data = WhereClmhdr_pat_key_data;
					_whereClmhdr_pat_acronym6 = WhereClmhdr_pat_acronym6;
					_whereClmhdr_pat_acronym3 = WhereClmhdr_pat_acronym3;
					_whereClmhdr_reference = WhereClmhdr_reference;
					_whereClmhdr_date_admit = WhereClmhdr_date_admit;
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept;
					_whereClmhdr_msg_nbr = WhereClmhdr_msg_nbr;
					_whereClmhdr_reprint_flag = WhereClmhdr_reprint_flag;
					_whereClmhdr_sub_nbr = WhereClmhdr_sub_nbr;
					_whereClmhdr_auto_logout = WhereClmhdr_auto_logout;
					_whereClmhdr_fee_complex = WhereClmhdr_fee_complex;
					_whereFiller = WhereFiller;
					_whereClmhdr_curr_payment = WhereClmhdr_curr_payment;
					_whereClmhdr_date_period_end = WhereClmhdr_date_period_end;
					_whereClmhdr_cycle_nbr = WhereClmhdr_cycle_nbr;
					_whereClmhdr_date_sys = WhereClmhdr_date_sys;
					_whereClmhdr_amt_tech_billed = WhereClmhdr_amt_tech_billed;
					_whereClmhdr_amt_tech_paid = WhereClmhdr_amt_tech_paid;
					_whereClmhdr_tot_claim_ar_oma = WhereClmhdr_tot_claim_ar_oma;
					_whereClmhdr_tot_claim_ar_ohip = WhereClmhdr_tot_claim_ar_ohip;
					_whereClmhdr_manual_and_tape_payments = WhereClmhdr_manual_and_tape_payments;
					_whereClmhdr_status_ohip = WhereClmhdr_status_ohip;
					_whereClmhdr_manual_review = WhereClmhdr_manual_review;
					_whereClmhdr_submit_date = WhereClmhdr_submit_date;
					_whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag;
					_whereClmhdr_serv_date = WhereClmhdr_serv_date;
					_whereClmhdr_elig_error = WhereClmhdr_elig_error;
					_whereClmhdr_elig_status = WhereClmhdr_elig_status;
					_whereClmhdr_serv_error = WhereClmhdr_serv_error;
					_whereClmhdr_serv_status = WhereClmhdr_serv_status;
					_whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr;
					_whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr;
					_whereClmdtl_batch_nbr = WhereClmdtl_batch_nbr;
					_whereClmdtl_claim_nbr = WhereClmdtl_claim_nbr;
					_whereClmdtl_oma_cd = WhereClmdtl_oma_cd;
					_whereClmdtl_oma_suff = WhereClmdtl_oma_suff;
					_whereClmdtl_adj_nbr = WhereClmdtl_adj_nbr;
					_whereClmdtl_det_rec = WhereClmdtl_det_rec;
					_whereClmdtl_rev_group_cd = WhereClmdtl_rev_group_cd;
					_whereClmdtl_agent_cd = WhereClmdtl_agent_cd;
					_whereClmdtl_adj_cd = WhereClmdtl_adj_cd;
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv;
					_whereClmdtl_sv_yy = WhereClmdtl_sv_yy;
					_whereClmdtl_sv_mm = WhereClmdtl_sv_mm;
					_whereClmdtl_sv_dd = WhereClmdtl_sv_dd;
					_whereClmdtl_consec_dates = WhereClmdtl_consec_dates;
					_whereClmdtl_consecutive_sv_date1 = WhereClmdtl_consecutive_sv_date1;
					_whereClmdtl_consecutive_sv_date2 = WhereClmdtl_consecutive_sv_date2;
					_whereClmdtl_consecutive_sv_date3 = WhereClmdtl_consecutive_sv_date3;
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed;
					_whereClmdtl_fee_oma = WhereClmdtl_fee_oma;
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip;
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end;
					_whereClmdtl_cycle_nbr = WhereClmdtl_cycle_nbr;
					_whereClmdtl_diag_cd = WhereClmdtl_diag_cd;
					_whereClmdtl_line_no = WhereClmdtl_line_no;
					_whereClmdtl_resubmit_flag = WhereClmdtl_resubmit_flag;
					_whereClmdtl_reserve_for_future = WhereClmdtl_reserve_for_future;
					_whereClmdtl_desc = WhereClmdtl_desc;
					_whereClmdtl_filler0 = WhereClmdtl_filler0;
					_whereClmdtl_filler9 = WhereClmdtl_filler9;
					_whereClmdtl_orig_batch_nbr = WhereClmdtl_orig_batch_nbr;
					_whereClmdtl_orig_claim_nbr_in_batch = WhereClmdtl_orig_claim_nbr_in_batch;
					_whereKey_clm_type = WhereKey_clm_type;
					_whereKey_clm_batch_nbr_red = WhereKey_clm_batch_nbr_red;
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
				&& WhereClaim_header_rec == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereClmhdr_adj_oma_cd == null 
				&& WhereClmhdr_adj_oma_suff == null 
				&& WhereClmhdr_adj_adj_nbr == null 
				&& WhereClmhdr_batch_type == null 
				&& WhereClmhdr_adj_cd_sub_type == null 
				&& WhereClmhdr_doc_nbr_ohip == null 
				&& WhereClmhdr_doc_spec_cd == null 
				&& WhereClmhdr_refer_doc_nbr == null 
				&& WhereClmhdr_diag_cd == null 
				&& WhereClmhdr_loc == null 
				&& WhereClmhdr_hosp == null 
				&& WhereClmhdr_agent_cd == null 
				&& WhereClmhdr_adj_cd == null 
				&& WhereClmhdr_tape_submit_ind == null 
				&& WhereClmhdr_i_o_pat_ind == null 
				&& WhereClmhdr_pat_key_type == null 
				&& WhereClmhdr_pat_key_data == null 
				&& WhereClmhdr_pat_acronym6 == null 
				&& WhereClmhdr_pat_acronym3 == null 
				&& WhereClmhdr_reference == null 
				&& WhereClmhdr_date_admit == null 
				&& WhereClmhdr_doc_dept == null 
				&& WhereClmhdr_msg_nbr == null 
				&& WhereClmhdr_reprint_flag == null 
				&& WhereClmhdr_sub_nbr == null 
				&& WhereClmhdr_auto_logout == null 
				&& WhereClmhdr_fee_complex == null 
				&& WhereFiller == null 
				&& WhereClmhdr_curr_payment == null 
				&& WhereClmhdr_date_period_end == null 
				&& WhereClmhdr_cycle_nbr == null 
				&& WhereClmhdr_date_sys == null 
				&& WhereClmhdr_amt_tech_billed == null 
				&& WhereClmhdr_amt_tech_paid == null 
				&& WhereClmhdr_tot_claim_ar_oma == null 
				&& WhereClmhdr_tot_claim_ar_ohip == null 
				&& WhereClmhdr_manual_and_tape_payments == null 
				&& WhereClmhdr_status_ohip == null 
				&& WhereClmhdr_manual_review == null 
				&& WhereClmhdr_submit_date == null 
				&& WhereClmhdr_confidential_flag == null 
				&& WhereClmhdr_serv_date == null 
				&& WhereClmhdr_elig_error == null 
				&& WhereClmhdr_elig_status == null 
				&& WhereClmhdr_serv_error == null 
				&& WhereClmhdr_serv_status == null 
				&& WhereClmhdr_orig_batch_nbr == null 
				&& WhereClmhdr_orig_claim_nbr == null 
				&& WhereClmdtl_batch_nbr == null 
				&& WhereClmdtl_claim_nbr == null 
				&& WhereClmdtl_oma_cd == null 
				&& WhereClmdtl_oma_suff == null 
				&& WhereClmdtl_adj_nbr == null 
				&& WhereClmdtl_det_rec == null 
				&& WhereClmdtl_rev_group_cd == null 
				&& WhereClmdtl_agent_cd == null 
				&& WhereClmdtl_adj_cd == null 
				&& WhereClmdtl_nbr_serv == null 
				&& WhereClmdtl_sv_yy == null 
				&& WhereClmdtl_sv_mm == null 
				&& WhereClmdtl_sv_dd == null 
				&& WhereClmdtl_consec_dates == null 
				&& WhereClmdtl_consecutive_sv_date1 == null 
				&& WhereClmdtl_consecutive_sv_date2 == null 
				&& WhereClmdtl_consecutive_sv_date3 == null 
				&& WhereClmdtl_amt_tech_billed == null 
				&& WhereClmdtl_fee_oma == null 
				&& WhereClmdtl_fee_ohip == null 
				&& WhereClmdtl_date_period_end == null 
				&& WhereClmdtl_cycle_nbr == null 
				&& WhereClmdtl_diag_cd == null 
				&& WhereClmdtl_line_no == null 
				&& WhereClmdtl_resubmit_flag == null 
				&& WhereClmdtl_reserve_for_future == null 
				&& WhereClmdtl_desc == null 
				&& WhereClmdtl_filler0 == null 
				&& WhereClmdtl_filler9 == null 
				&& WhereClmdtl_orig_batch_nbr == null 
				&& WhereClmdtl_orig_claim_nbr_in_batch == null 
				&& WhereKey_clm_type == null 
				&& WhereKey_clm_batch_nbr_red == null 
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
				&& WhereClaim_header_rec ==  _whereClaim_header_rec
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereClmhdr_adj_oma_cd ==  _whereClmhdr_adj_oma_cd
				&& WhereClmhdr_adj_oma_suff ==  _whereClmhdr_adj_oma_suff
				&& WhereClmhdr_adj_adj_nbr ==  _whereClmhdr_adj_adj_nbr
				&& WhereClmhdr_batch_type ==  _whereClmhdr_batch_type
				&& WhereClmhdr_adj_cd_sub_type ==  _whereClmhdr_adj_cd_sub_type
				&& WhereClmhdr_doc_nbr_ohip ==  _whereClmhdr_doc_nbr_ohip
				&& WhereClmhdr_doc_spec_cd ==  _whereClmhdr_doc_spec_cd
				&& WhereClmhdr_refer_doc_nbr ==  _whereClmhdr_refer_doc_nbr
				&& WhereClmhdr_diag_cd ==  _whereClmhdr_diag_cd
				&& WhereClmhdr_loc ==  _whereClmhdr_loc
				&& WhereClmhdr_hosp ==  _whereClmhdr_hosp
				&& WhereClmhdr_agent_cd ==  _whereClmhdr_agent_cd
				&& WhereClmhdr_adj_cd ==  _whereClmhdr_adj_cd
				&& WhereClmhdr_tape_submit_ind ==  _whereClmhdr_tape_submit_ind
				&& WhereClmhdr_i_o_pat_ind ==  _whereClmhdr_i_o_pat_ind
				&& WhereClmhdr_pat_key_type ==  _whereClmhdr_pat_key_type
				&& WhereClmhdr_pat_key_data ==  _whereClmhdr_pat_key_data
				&& WhereClmhdr_pat_acronym6 ==  _whereClmhdr_pat_acronym6
				&& WhereClmhdr_pat_acronym3 ==  _whereClmhdr_pat_acronym3
				&& WhereClmhdr_reference ==  _whereClmhdr_reference
				&& WhereClmhdr_date_admit ==  _whereClmhdr_date_admit
				&& WhereClmhdr_doc_dept ==  _whereClmhdr_doc_dept
				&& WhereClmhdr_msg_nbr ==  _whereClmhdr_msg_nbr
				&& WhereClmhdr_reprint_flag ==  _whereClmhdr_reprint_flag
				&& WhereClmhdr_sub_nbr ==  _whereClmhdr_sub_nbr
				&& WhereClmhdr_auto_logout ==  _whereClmhdr_auto_logout
				&& WhereClmhdr_fee_complex ==  _whereClmhdr_fee_complex
				&& WhereFiller ==  _whereFiller
				&& WhereClmhdr_curr_payment ==  _whereClmhdr_curr_payment
				&& WhereClmhdr_date_period_end ==  _whereClmhdr_date_period_end
				&& WhereClmhdr_cycle_nbr ==  _whereClmhdr_cycle_nbr
				&& WhereClmhdr_date_sys ==  _whereClmhdr_date_sys
				&& WhereClmhdr_amt_tech_billed ==  _whereClmhdr_amt_tech_billed
				&& WhereClmhdr_amt_tech_paid ==  _whereClmhdr_amt_tech_paid
				&& WhereClmhdr_tot_claim_ar_oma ==  _whereClmhdr_tot_claim_ar_oma
				&& WhereClmhdr_tot_claim_ar_ohip ==  _whereClmhdr_tot_claim_ar_ohip
				&& WhereClmhdr_manual_and_tape_payments ==  _whereClmhdr_manual_and_tape_payments
				&& WhereClmhdr_status_ohip ==  _whereClmhdr_status_ohip
				&& WhereClmhdr_manual_review ==  _whereClmhdr_manual_review
				&& WhereClmhdr_submit_date ==  _whereClmhdr_submit_date
				&& WhereClmhdr_confidential_flag ==  _whereClmhdr_confidential_flag
				&& WhereClmhdr_serv_date ==  _whereClmhdr_serv_date
				&& WhereClmhdr_elig_error ==  _whereClmhdr_elig_error
				&& WhereClmhdr_elig_status ==  _whereClmhdr_elig_status
				&& WhereClmhdr_serv_error ==  _whereClmhdr_serv_error
				&& WhereClmhdr_serv_status ==  _whereClmhdr_serv_status
				&& WhereClmhdr_orig_batch_nbr ==  _whereClmhdr_orig_batch_nbr
				&& WhereClmhdr_orig_claim_nbr ==  _whereClmhdr_orig_claim_nbr
				&& WhereClmdtl_batch_nbr ==  _whereClmdtl_batch_nbr
				&& WhereClmdtl_claim_nbr ==  _whereClmdtl_claim_nbr
				&& WhereClmdtl_oma_cd ==  _whereClmdtl_oma_cd
				&& WhereClmdtl_oma_suff ==  _whereClmdtl_oma_suff
				&& WhereClmdtl_adj_nbr ==  _whereClmdtl_adj_nbr
				&& WhereClmdtl_det_rec ==  _whereClmdtl_det_rec
				&& WhereClmdtl_rev_group_cd ==  _whereClmdtl_rev_group_cd
				&& WhereClmdtl_agent_cd ==  _whereClmdtl_agent_cd
				&& WhereClmdtl_adj_cd ==  _whereClmdtl_adj_cd
				&& WhereClmdtl_nbr_serv ==  _whereClmdtl_nbr_serv
				&& WhereClmdtl_sv_yy ==  _whereClmdtl_sv_yy
				&& WhereClmdtl_sv_mm ==  _whereClmdtl_sv_mm
				&& WhereClmdtl_sv_dd ==  _whereClmdtl_sv_dd
				&& WhereClmdtl_consec_dates ==  _whereClmdtl_consec_dates
				&& WhereClmdtl_consecutive_sv_date1 ==  _whereClmdtl_consecutive_sv_date1
				&& WhereClmdtl_consecutive_sv_date2 ==  _whereClmdtl_consecutive_sv_date2
				&& WhereClmdtl_consecutive_sv_date3 ==  _whereClmdtl_consecutive_sv_date3
				&& WhereClmdtl_amt_tech_billed ==  _whereClmdtl_amt_tech_billed
				&& WhereClmdtl_fee_oma ==  _whereClmdtl_fee_oma
				&& WhereClmdtl_fee_ohip ==  _whereClmdtl_fee_ohip
				&& WhereClmdtl_date_period_end ==  _whereClmdtl_date_period_end
				&& WhereClmdtl_cycle_nbr ==  _whereClmdtl_cycle_nbr
				&& WhereClmdtl_diag_cd ==  _whereClmdtl_diag_cd
				&& WhereClmdtl_line_no ==  _whereClmdtl_line_no
				&& WhereClmdtl_resubmit_flag ==  _whereClmdtl_resubmit_flag
				&& WhereClmdtl_reserve_for_future ==  _whereClmdtl_reserve_for_future
				&& WhereClmdtl_desc ==  _whereClmdtl_desc
				&& WhereClmdtl_filler0 ==  _whereClmdtl_filler0
				&& WhereClmdtl_filler9 ==  _whereClmdtl_filler9
				&& WhereClmdtl_orig_batch_nbr ==  _whereClmdtl_orig_batch_nbr
				&& WhereClmdtl_orig_claim_nbr_in_batch ==  _whereClmdtl_orig_claim_nbr_in_batch
				&& WhereKey_clm_type ==  _whereKey_clm_type
				&& WhereKey_clm_batch_nbr_red ==  _whereKey_clm_batch_nbr_red
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
			WhereClaim_header_rec = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereClmhdr_adj_oma_cd = null; 
			WhereClmhdr_adj_oma_suff = null; 
			WhereClmhdr_adj_adj_nbr = null; 
			WhereClmhdr_batch_type = null; 
			WhereClmhdr_adj_cd_sub_type = null; 
			WhereClmhdr_doc_nbr_ohip = null; 
			WhereClmhdr_doc_spec_cd = null; 
			WhereClmhdr_refer_doc_nbr = null; 
			WhereClmhdr_diag_cd = null; 
			WhereClmhdr_loc = null; 
			WhereClmhdr_hosp = null; 
			WhereClmhdr_agent_cd = null; 
			WhereClmhdr_adj_cd = null; 
			WhereClmhdr_tape_submit_ind = null; 
			WhereClmhdr_i_o_pat_ind = null; 
			WhereClmhdr_pat_key_type = null; 
			WhereClmhdr_pat_key_data = null; 
			WhereClmhdr_pat_acronym6 = null; 
			WhereClmhdr_pat_acronym3 = null; 
			WhereClmhdr_reference = null; 
			WhereClmhdr_date_admit = null; 
			WhereClmhdr_doc_dept = null; 
			WhereClmhdr_msg_nbr = null; 
			WhereClmhdr_reprint_flag = null; 
			WhereClmhdr_sub_nbr = null; 
			WhereClmhdr_auto_logout = null; 
			WhereClmhdr_fee_complex = null; 
			WhereFiller = null; 
			WhereClmhdr_curr_payment = null; 
			WhereClmhdr_date_period_end = null; 
			WhereClmhdr_cycle_nbr = null; 
			WhereClmhdr_date_sys = null; 
			WhereClmhdr_amt_tech_billed = null; 
			WhereClmhdr_amt_tech_paid = null; 
			WhereClmhdr_tot_claim_ar_oma = null; 
			WhereClmhdr_tot_claim_ar_ohip = null; 
			WhereClmhdr_manual_and_tape_payments = null; 
			WhereClmhdr_status_ohip = null; 
			WhereClmhdr_manual_review = null; 
			WhereClmhdr_submit_date = null; 
			WhereClmhdr_confidential_flag = null; 
			WhereClmhdr_serv_date = null; 
			WhereClmhdr_elig_error = null; 
			WhereClmhdr_elig_status = null; 
			WhereClmhdr_serv_error = null; 
			WhereClmhdr_serv_status = null; 
			WhereClmhdr_orig_batch_nbr = null; 
			WhereClmhdr_orig_claim_nbr = null; 
			WhereClmdtl_batch_nbr = null; 
			WhereClmdtl_claim_nbr = null; 
			WhereClmdtl_oma_cd = null; 
			WhereClmdtl_oma_suff = null; 
			WhereClmdtl_adj_nbr = null; 
			WhereClmdtl_det_rec = null; 
			WhereClmdtl_rev_group_cd = null; 
			WhereClmdtl_agent_cd = null; 
			WhereClmdtl_adj_cd = null; 
			WhereClmdtl_nbr_serv = null; 
			WhereClmdtl_sv_yy = null; 
			WhereClmdtl_sv_mm = null; 
			WhereClmdtl_sv_dd = null; 
			WhereClmdtl_consec_dates = null; 
			WhereClmdtl_consecutive_sv_date1 = null; 
			WhereClmdtl_consecutive_sv_date2 = null; 
			WhereClmdtl_consecutive_sv_date3 = null; 
			WhereClmdtl_amt_tech_billed = null; 
			WhereClmdtl_fee_oma = null; 
			WhereClmdtl_fee_ohip = null; 
			WhereClmdtl_date_period_end = null; 
			WhereClmdtl_cycle_nbr = null; 
			WhereClmdtl_diag_cd = null; 
			WhereClmdtl_line_no = null; 
			WhereClmdtl_resubmit_flag = null; 
			WhereClmdtl_reserve_for_future = null; 
			WhereClmdtl_desc = null; 
			WhereClmdtl_filler0 = null; 
			WhereClmdtl_filler9 = null; 
			WhereClmdtl_orig_batch_nbr = null; 
			WhereClmdtl_orig_claim_nbr_in_batch = null; 
			WhereKey_clm_type = null; 
			WhereKey_clm_batch_nbr_red = null; 
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
		private string _CLAIM_HEADER_REC;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private string _CLMHDR_ADJ_OMA_CD;
		private string _CLMHDR_ADJ_OMA_SUFF;
		private string _CLMHDR_ADJ_ADJ_NBR;
		private string _CLMHDR_BATCH_TYPE;
		private string _CLMHDR_ADJ_CD_SUB_TYPE;
		private decimal? _CLMHDR_DOC_NBR_OHIP;
		private decimal? _CLMHDR_DOC_SPEC_CD;
		private decimal? _CLMHDR_REFER_DOC_NBR;
		private decimal? _CLMHDR_DIAG_CD;
		private string _CLMHDR_LOC;
		private string _CLMHDR_HOSP;
		private decimal? _CLMHDR_AGENT_CD;
		private string _CLMHDR_ADJ_CD;
		private string _CLMHDR_TAPE_SUBMIT_IND;
		private string _CLMHDR_I_O_PAT_IND;
		private string _CLMHDR_PAT_KEY_TYPE;
		private string _CLMHDR_PAT_KEY_DATA;
		private string _CLMHDR_PAT_ACRONYM6;
		private string _CLMHDR_PAT_ACRONYM3;
		private string _CLMHDR_REFERENCE;
		private string _CLMHDR_DATE_ADMIT;
		private decimal? _CLMHDR_DOC_DEPT;
		private string _CLMHDR_MSG_NBR;
		private string _CLMHDR_REPRINT_FLAG;
		private string _CLMHDR_SUB_NBR;
		private string _CLMHDR_AUTO_LOGOUT;
		private string _CLMHDR_FEE_COMPLEX;
		private string _FILLER;
		private decimal? _CLMHDR_CURR_PAYMENT;
		private decimal? _CLMHDR_DATE_PERIOD_END;
		private decimal? _CLMHDR_CYCLE_NBR;
		private string _CLMHDR_DATE_SYS;
		private decimal? _CLMHDR_AMT_TECH_BILLED;
		private decimal? _CLMHDR_AMT_TECH_PAID;
		private decimal? _CLMHDR_TOT_CLAIM_AR_OMA;
		private decimal? _CLMHDR_TOT_CLAIM_AR_OHIP;
		private decimal? _CLMHDR_MANUAL_AND_TAPE_PAYMENTS;
		private string _CLMHDR_STATUS_OHIP;
		private string _CLMHDR_MANUAL_REVIEW;
		private decimal? _CLMHDR_SUBMIT_DATE;
		private string _CLMHDR_CONFIDENTIAL_FLAG;
		private decimal? _CLMHDR_SERV_DATE;
		private string _CLMHDR_ELIG_ERROR;
		private string _CLMHDR_ELIG_STATUS;
		private string _CLMHDR_SERV_ERROR;
		private string _CLMHDR_SERV_STATUS;
		private string _CLMHDR_ORIG_BATCH_NBR;
		private decimal? _CLMHDR_ORIG_CLAIM_NBR;
		private string _CLMDTL_BATCH_NBR;
		private decimal? _CLMDTL_CLAIM_NBR;
		private string _CLMDTL_OMA_CD;
		private string _CLMDTL_OMA_SUFF;
		private decimal? _CLMDTL_ADJ_NBR;
		private string _CLMDTL_DET_REC;
		private string _CLMDTL_REV_GROUP_CD;
		private decimal? _CLMDTL_AGENT_CD;
		private string _CLMDTL_ADJ_CD;
		private decimal? _CLMDTL_NBR_SERV;
		private decimal? _CLMDTL_SV_YY;
		private decimal? _CLMDTL_SV_MM;
		private decimal? _CLMDTL_SV_DD;
		private decimal? _CLMDTL_CONSEC_DATES;
		private decimal? _CLMDTL_CONSECUTIVE_SV_DATE1;
		private decimal? _CLMDTL_CONSECUTIVE_SV_DATE2;
		private decimal? _CLMDTL_CONSECUTIVE_SV_DATE3;
		private decimal? _CLMDTL_AMT_TECH_BILLED;
		private decimal? _CLMDTL_FEE_OMA;
		private decimal? _CLMDTL_FEE_OHIP;
		private string _CLMDTL_DATE_PERIOD_END;
		private decimal? _CLMDTL_CYCLE_NBR;
		private decimal? _CLMDTL_DIAG_CD;
		private decimal? _CLMDTL_LINE_NO;
		private string _CLMDTL_RESUBMIT_FLAG;
		private string _CLMDTL_RESERVE_FOR_FUTURE;
		private string _CLMDTL_DESC;
		private string _CLMDTL_FILLER0;
		private string _CLMDTL_FILLER9;
		private string _CLMDTL_ORIG_BATCH_NBR;
		private decimal? _CLMDTL_ORIG_CLAIM_NBR_IN_BATCH;
		private string _KEY_CLM_TYPE;
		private string _KEY_CLM_BATCH_NBR_RED;
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
		public string CLAIM_HEADER_REC
		{
			get { return _CLAIM_HEADER_REC; }
			set
			{
				if (_CLAIM_HEADER_REC != value)
				{
					_CLAIM_HEADER_REC = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_NBR
		{
			get { return _CLMHDR_BATCH_NBR; }
			set
			{
				if (_CLMHDR_BATCH_NBR != value)
				{
					_CLMHDR_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CLAIM_NBR
		{
			get { return _CLMHDR_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_CLAIM_NBR != value)
				{
					_CLMHDR_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_OMA_CD
		{
			get { return _CLMHDR_ADJ_OMA_CD; }
			set
			{
				if (_CLMHDR_ADJ_OMA_CD != value)
				{
					_CLMHDR_ADJ_OMA_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_OMA_SUFF
		{
			get { return _CLMHDR_ADJ_OMA_SUFF; }
			set
			{
				if (_CLMHDR_ADJ_OMA_SUFF != value)
				{
					_CLMHDR_ADJ_OMA_SUFF = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_ADJ_NBR
		{
			get { return _CLMHDR_ADJ_ADJ_NBR; }
			set
			{
				if (_CLMHDR_ADJ_ADJ_NBR != value)
				{
					_CLMHDR_ADJ_ADJ_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_BATCH_TYPE
		{
			get { return _CLMHDR_BATCH_TYPE; }
			set
			{
				if (_CLMHDR_BATCH_TYPE != value)
				{
					_CLMHDR_BATCH_TYPE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_CD_SUB_TYPE
		{
			get { return _CLMHDR_ADJ_CD_SUB_TYPE; }
			set
			{
				if (_CLMHDR_ADJ_CD_SUB_TYPE != value)
				{
					_CLMHDR_ADJ_CD_SUB_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_NBR_OHIP
		{
			get { return _CLMHDR_DOC_NBR_OHIP; }
			set
			{
				if (_CLMHDR_DOC_NBR_OHIP != value)
				{
					_CLMHDR_DOC_NBR_OHIP = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_SPEC_CD
		{
			get { return _CLMHDR_DOC_SPEC_CD; }
			set
			{
				if (_CLMHDR_DOC_SPEC_CD != value)
				{
					_CLMHDR_DOC_SPEC_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_REFER_DOC_NBR
		{
			get { return _CLMHDR_REFER_DOC_NBR; }
			set
			{
				if (_CLMHDR_REFER_DOC_NBR != value)
				{
					_CLMHDR_REFER_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DIAG_CD
		{
			get { return _CLMHDR_DIAG_CD; }
			set
			{
				if (_CLMHDR_DIAG_CD != value)
				{
					_CLMHDR_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_LOC
		{
			get { return _CLMHDR_LOC; }
			set
			{
				if (_CLMHDR_LOC != value)
				{
					_CLMHDR_LOC = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_HOSP
		{
			get { return _CLMHDR_HOSP; }
			set
			{
				if (_CLMHDR_HOSP != value)
				{
					_CLMHDR_HOSP = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_AGENT_CD
		{
			get { return _CLMHDR_AGENT_CD; }
			set
			{
				if (_CLMHDR_AGENT_CD != value)
				{
					_CLMHDR_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ADJ_CD
		{
			get { return _CLMHDR_ADJ_CD; }
			set
			{
				if (_CLMHDR_ADJ_CD != value)
				{
					_CLMHDR_ADJ_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_TAPE_SUBMIT_IND
		{
			get { return _CLMHDR_TAPE_SUBMIT_IND; }
			set
			{
				if (_CLMHDR_TAPE_SUBMIT_IND != value)
				{
					_CLMHDR_TAPE_SUBMIT_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_I_O_PAT_IND
		{
			get { return _CLMHDR_I_O_PAT_IND; }
			set
			{
				if (_CLMHDR_I_O_PAT_IND != value)
				{
					_CLMHDR_I_O_PAT_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_KEY_TYPE
		{
			get { return _CLMHDR_PAT_KEY_TYPE; }
			set
			{
				if (_CLMHDR_PAT_KEY_TYPE != value)
				{
					_CLMHDR_PAT_KEY_TYPE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_KEY_DATA
		{
			get { return _CLMHDR_PAT_KEY_DATA; }
			set
			{
				if (_CLMHDR_PAT_KEY_DATA != value)
				{
					_CLMHDR_PAT_KEY_DATA = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_ACRONYM6
		{
			get { return _CLMHDR_PAT_ACRONYM6; }
			set
			{
				if (_CLMHDR_PAT_ACRONYM6 != value)
				{
					_CLMHDR_PAT_ACRONYM6 = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_ACRONYM3
		{
			get { return _CLMHDR_PAT_ACRONYM3; }
			set
			{
				if (_CLMHDR_PAT_ACRONYM3 != value)
				{
					_CLMHDR_PAT_ACRONYM3 = value;
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
		public string CLMHDR_DATE_ADMIT
		{
			get { return _CLMHDR_DATE_ADMIT; }
			set
			{
				if (_CLMHDR_DATE_ADMIT != value)
				{
					_CLMHDR_DATE_ADMIT = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_DEPT
		{
			get { return _CLMHDR_DOC_DEPT; }
			set
			{
				if (_CLMHDR_DOC_DEPT != value)
				{
					_CLMHDR_DOC_DEPT = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_MSG_NBR
		{
			get { return _CLMHDR_MSG_NBR; }
			set
			{
				if (_CLMHDR_MSG_NBR != value)
				{
					_CLMHDR_MSG_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_REPRINT_FLAG
		{
			get { return _CLMHDR_REPRINT_FLAG; }
			set
			{
				if (_CLMHDR_REPRINT_FLAG != value)
				{
					_CLMHDR_REPRINT_FLAG = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SUB_NBR
		{
			get { return _CLMHDR_SUB_NBR; }
			set
			{
				if (_CLMHDR_SUB_NBR != value)
				{
					_CLMHDR_SUB_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_AUTO_LOGOUT
		{
			get { return _CLMHDR_AUTO_LOGOUT; }
			set
			{
				if (_CLMHDR_AUTO_LOGOUT != value)
				{
					_CLMHDR_AUTO_LOGOUT = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_FEE_COMPLEX
		{
			get { return _CLMHDR_FEE_COMPLEX; }
			set
			{
				if (_CLMHDR_FEE_COMPLEX != value)
				{
					_CLMHDR_FEE_COMPLEX = value;
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
		public decimal? CLMHDR_CURR_PAYMENT
		{
			get { return _CLMHDR_CURR_PAYMENT; }
			set
			{
				if (_CLMHDR_CURR_PAYMENT != value)
				{
					_CLMHDR_CURR_PAYMENT = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DATE_PERIOD_END
		{
			get { return _CLMHDR_DATE_PERIOD_END; }
			set
			{
				if (_CLMHDR_DATE_PERIOD_END != value)
				{
					_CLMHDR_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_CYCLE_NBR
		{
			get { return _CLMHDR_CYCLE_NBR; }
			set
			{
				if (_CLMHDR_CYCLE_NBR != value)
				{
					_CLMHDR_CYCLE_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_DATE_SYS
		{
			get { return _CLMHDR_DATE_SYS; }
			set
			{
				if (_CLMHDR_DATE_SYS != value)
				{
					_CLMHDR_DATE_SYS = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_AMT_TECH_BILLED
		{
			get { return _CLMHDR_AMT_TECH_BILLED; }
			set
			{
				if (_CLMHDR_AMT_TECH_BILLED != value)
				{
					_CLMHDR_AMT_TECH_BILLED = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_AMT_TECH_PAID
		{
			get { return _CLMHDR_AMT_TECH_PAID; }
			set
			{
				if (_CLMHDR_AMT_TECH_PAID != value)
				{
					_CLMHDR_AMT_TECH_PAID = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_TOT_CLAIM_AR_OMA
		{
			get { return _CLMHDR_TOT_CLAIM_AR_OMA; }
			set
			{
				if (_CLMHDR_TOT_CLAIM_AR_OMA != value)
				{
					_CLMHDR_TOT_CLAIM_AR_OMA = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_TOT_CLAIM_AR_OHIP
		{
			get { return _CLMHDR_TOT_CLAIM_AR_OHIP; }
			set
			{
				if (_CLMHDR_TOT_CLAIM_AR_OHIP != value)
				{
					_CLMHDR_TOT_CLAIM_AR_OHIP = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_MANUAL_AND_TAPE_PAYMENTS
		{
			get { return _CLMHDR_MANUAL_AND_TAPE_PAYMENTS; }
			set
			{
				if (_CLMHDR_MANUAL_AND_TAPE_PAYMENTS != value)
				{
					_CLMHDR_MANUAL_AND_TAPE_PAYMENTS = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_STATUS_OHIP
		{
			get { return _CLMHDR_STATUS_OHIP; }
			set
			{
				if (_CLMHDR_STATUS_OHIP != value)
				{
					_CLMHDR_STATUS_OHIP = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_MANUAL_REVIEW
		{
			get { return _CLMHDR_MANUAL_REVIEW; }
			set
			{
				if (_CLMHDR_MANUAL_REVIEW != value)
				{
					_CLMHDR_MANUAL_REVIEW = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_SUBMIT_DATE
		{
			get { return _CLMHDR_SUBMIT_DATE; }
			set
			{
				if (_CLMHDR_SUBMIT_DATE != value)
				{
					_CLMHDR_SUBMIT_DATE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_CONFIDENTIAL_FLAG
		{
			get { return _CLMHDR_CONFIDENTIAL_FLAG; }
			set
			{
				if (_CLMHDR_CONFIDENTIAL_FLAG != value)
				{
					_CLMHDR_CONFIDENTIAL_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_SERV_DATE
		{
			get { return _CLMHDR_SERV_DATE; }
			set
			{
				if (_CLMHDR_SERV_DATE != value)
				{
					_CLMHDR_SERV_DATE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ELIG_ERROR
		{
			get { return _CLMHDR_ELIG_ERROR; }
			set
			{
				if (_CLMHDR_ELIG_ERROR != value)
				{
					_CLMHDR_ELIG_ERROR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ELIG_STATUS
		{
			get { return _CLMHDR_ELIG_STATUS; }
			set
			{
				if (_CLMHDR_ELIG_STATUS != value)
				{
					_CLMHDR_ELIG_STATUS = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SERV_ERROR
		{
			get { return _CLMHDR_SERV_ERROR; }
			set
			{
				if (_CLMHDR_SERV_ERROR != value)
				{
					_CLMHDR_SERV_ERROR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SERV_STATUS
		{
			get { return _CLMHDR_SERV_STATUS; }
			set
			{
				if (_CLMHDR_SERV_STATUS != value)
				{
					_CLMHDR_SERV_STATUS = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ORIG_BATCH_NBR
		{
			get { return _CLMHDR_ORIG_BATCH_NBR; }
			set
			{
				if (_CLMHDR_ORIG_BATCH_NBR != value)
				{
					_CLMHDR_ORIG_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_ORIG_CLAIM_NBR
		{
			get { return _CLMHDR_ORIG_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_ORIG_CLAIM_NBR != value)
				{
					_CLMHDR_ORIG_CLAIM_NBR = value;
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
		public string CLMDTL_DET_REC
		{
			get { return _CLMDTL_DET_REC; }
			set
			{
				if (_CLMDTL_DET_REC != value)
				{
					_CLMDTL_DET_REC = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_REV_GROUP_CD
		{
			get { return _CLMDTL_REV_GROUP_CD; }
			set
			{
				if (_CLMDTL_REV_GROUP_CD != value)
				{
					_CLMDTL_REV_GROUP_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_AGENT_CD
		{
			get { return _CLMDTL_AGENT_CD; }
			set
			{
				if (_CLMDTL_AGENT_CD != value)
				{
					_CLMDTL_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_ADJ_CD
		{
			get { return _CLMDTL_ADJ_CD; }
			set
			{
				if (_CLMDTL_ADJ_CD != value)
				{
					_CLMDTL_ADJ_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_NBR_SERV
		{
			get { return _CLMDTL_NBR_SERV; }
			set
			{
				if (_CLMDTL_NBR_SERV != value)
				{
					_CLMDTL_NBR_SERV = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_YY
		{
			get { return _CLMDTL_SV_YY; }
			set
			{
				if (_CLMDTL_SV_YY != value)
				{
					_CLMDTL_SV_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_MM
		{
			get { return _CLMDTL_SV_MM; }
			set
			{
				if (_CLMDTL_SV_MM != value)
				{
					_CLMDTL_SV_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_DD
		{
			get { return _CLMDTL_SV_DD; }
			set
			{
				if (_CLMDTL_SV_DD != value)
				{
					_CLMDTL_SV_DD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CONSEC_DATES
		{
			get { return _CLMDTL_CONSEC_DATES; }
			set
			{
				if (_CLMDTL_CONSEC_DATES != value)
				{
					_CLMDTL_CONSEC_DATES = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CONSECUTIVE_SV_DATE1
		{
			get { return _CLMDTL_CONSECUTIVE_SV_DATE1; }
			set
			{
				if (_CLMDTL_CONSECUTIVE_SV_DATE1 != value)
				{
					_CLMDTL_CONSECUTIVE_SV_DATE1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CONSECUTIVE_SV_DATE2
		{
			get { return _CLMDTL_CONSECUTIVE_SV_DATE2; }
			set
			{
				if (_CLMDTL_CONSECUTIVE_SV_DATE2 != value)
				{
					_CLMDTL_CONSECUTIVE_SV_DATE2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CONSECUTIVE_SV_DATE3
		{
			get { return _CLMDTL_CONSECUTIVE_SV_DATE3; }
			set
			{
				if (_CLMDTL_CONSECUTIVE_SV_DATE3 != value)
				{
					_CLMDTL_CONSECUTIVE_SV_DATE3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_AMT_TECH_BILLED
		{
			get { return _CLMDTL_AMT_TECH_BILLED; }
			set
			{
				if (_CLMDTL_AMT_TECH_BILLED != value)
				{
					_CLMDTL_AMT_TECH_BILLED = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_FEE_OMA
		{
			get { return _CLMDTL_FEE_OMA; }
			set
			{
				if (_CLMDTL_FEE_OMA != value)
				{
					_CLMDTL_FEE_OMA = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_FEE_OHIP
		{
			get { return _CLMDTL_FEE_OHIP; }
			set
			{
				if (_CLMDTL_FEE_OHIP != value)
				{
					_CLMDTL_FEE_OHIP = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_DATE_PERIOD_END
		{
			get { return _CLMDTL_DATE_PERIOD_END; }
			set
			{
				if (_CLMDTL_DATE_PERIOD_END != value)
				{
					_CLMDTL_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CYCLE_NBR
		{
			get { return _CLMDTL_CYCLE_NBR; }
			set
			{
				if (_CLMDTL_CYCLE_NBR != value)
				{
					_CLMDTL_CYCLE_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_DIAG_CD
		{
			get { return _CLMDTL_DIAG_CD; }
			set
			{
				if (_CLMDTL_DIAG_CD != value)
				{
					_CLMDTL_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_LINE_NO
		{
			get { return _CLMDTL_LINE_NO; }
			set
			{
				if (_CLMDTL_LINE_NO != value)
				{
					_CLMDTL_LINE_NO = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_RESUBMIT_FLAG
		{
			get { return _CLMDTL_RESUBMIT_FLAG; }
			set
			{
				if (_CLMDTL_RESUBMIT_FLAG != value)
				{
					_CLMDTL_RESUBMIT_FLAG = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_RESERVE_FOR_FUTURE
		{
			get { return _CLMDTL_RESERVE_FOR_FUTURE; }
			set
			{
				if (_CLMDTL_RESERVE_FOR_FUTURE != value)
				{
					_CLMDTL_RESERVE_FOR_FUTURE = value;
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
		public string KEY_CLM_BATCH_NBR_RED
		{
			get { return _KEY_CLM_BATCH_NBR_RED; }
			set
			{
				if (_KEY_CLM_BATCH_NBR_RED != value)
				{
					_KEY_CLM_BATCH_NBR_RED = value;
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
		public string WhereClaim_header_rec { get; set; }
		private string _whereClaim_header_rec;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public string WhereClmhdr_adj_oma_cd { get; set; }
		private string _whereClmhdr_adj_oma_cd;
		public string WhereClmhdr_adj_oma_suff { get; set; }
		private string _whereClmhdr_adj_oma_suff;
		public string WhereClmhdr_adj_adj_nbr { get; set; }
		private string _whereClmhdr_adj_adj_nbr;
		public string WhereClmhdr_batch_type { get; set; }
		private string _whereClmhdr_batch_type;
		public string WhereClmhdr_adj_cd_sub_type { get; set; }
		private string _whereClmhdr_adj_cd_sub_type;
		public decimal? WhereClmhdr_doc_nbr_ohip { get; set; }
		private decimal? _whereClmhdr_doc_nbr_ohip;
		public decimal? WhereClmhdr_doc_spec_cd { get; set; }
		private decimal? _whereClmhdr_doc_spec_cd;
		public decimal? WhereClmhdr_refer_doc_nbr { get; set; }
		private decimal? _whereClmhdr_refer_doc_nbr;
		public decimal? WhereClmhdr_diag_cd { get; set; }
		private decimal? _whereClmhdr_diag_cd;
		public string WhereClmhdr_loc { get; set; }
		private string _whereClmhdr_loc;
		public string WhereClmhdr_hosp { get; set; }
		private string _whereClmhdr_hosp;
		public decimal? WhereClmhdr_agent_cd { get; set; }
		private decimal? _whereClmhdr_agent_cd;
		public string WhereClmhdr_adj_cd { get; set; }
		private string _whereClmhdr_adj_cd;
		public string WhereClmhdr_tape_submit_ind { get; set; }
		private string _whereClmhdr_tape_submit_ind;
		public string WhereClmhdr_i_o_pat_ind { get; set; }
		private string _whereClmhdr_i_o_pat_ind;
		public string WhereClmhdr_pat_key_type { get; set; }
		private string _whereClmhdr_pat_key_type;
		public string WhereClmhdr_pat_key_data { get; set; }
		private string _whereClmhdr_pat_key_data;
		public string WhereClmhdr_pat_acronym6 { get; set; }
		private string _whereClmhdr_pat_acronym6;
		public string WhereClmhdr_pat_acronym3 { get; set; }
		private string _whereClmhdr_pat_acronym3;
		public string WhereClmhdr_reference { get; set; }
		private string _whereClmhdr_reference;
		public string WhereClmhdr_date_admit { get; set; }
		private string _whereClmhdr_date_admit;
		public decimal? WhereClmhdr_doc_dept { get; set; }
		private decimal? _whereClmhdr_doc_dept;
		public string WhereClmhdr_msg_nbr { get; set; }
		private string _whereClmhdr_msg_nbr;
		public string WhereClmhdr_reprint_flag { get; set; }
		private string _whereClmhdr_reprint_flag;
		public string WhereClmhdr_sub_nbr { get; set; }
		private string _whereClmhdr_sub_nbr;
		public string WhereClmhdr_auto_logout { get; set; }
		private string _whereClmhdr_auto_logout;
		public string WhereClmhdr_fee_complex { get; set; }
		private string _whereClmhdr_fee_complex;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public decimal? WhereClmhdr_curr_payment { get; set; }
		private decimal? _whereClmhdr_curr_payment;
		public decimal? WhereClmhdr_date_period_end { get; set; }
		private decimal? _whereClmhdr_date_period_end;
		public decimal? WhereClmhdr_cycle_nbr { get; set; }
		private decimal? _whereClmhdr_cycle_nbr;
		public string WhereClmhdr_date_sys { get; set; }
		private string _whereClmhdr_date_sys;
		public decimal? WhereClmhdr_amt_tech_billed { get; set; }
		private decimal? _whereClmhdr_amt_tech_billed;
		public decimal? WhereClmhdr_amt_tech_paid { get; set; }
		private decimal? _whereClmhdr_amt_tech_paid;
		public decimal? WhereClmhdr_tot_claim_ar_oma { get; set; }
		private decimal? _whereClmhdr_tot_claim_ar_oma;
		public decimal? WhereClmhdr_tot_claim_ar_ohip { get; set; }
		private decimal? _whereClmhdr_tot_claim_ar_ohip;
		public decimal? WhereClmhdr_manual_and_tape_payments { get; set; }
		private decimal? _whereClmhdr_manual_and_tape_payments;
		public string WhereClmhdr_status_ohip { get; set; }
		private string _whereClmhdr_status_ohip;
		public string WhereClmhdr_manual_review { get; set; }
		private string _whereClmhdr_manual_review;
		public decimal? WhereClmhdr_submit_date { get; set; }
		private decimal? _whereClmhdr_submit_date;
		public string WhereClmhdr_confidential_flag { get; set; }
		private string _whereClmhdr_confidential_flag;
		public decimal? WhereClmhdr_serv_date { get; set; }
		private decimal? _whereClmhdr_serv_date;
		public string WhereClmhdr_elig_error { get; set; }
		private string _whereClmhdr_elig_error;
		public string WhereClmhdr_elig_status { get; set; }
		private string _whereClmhdr_elig_status;
		public string WhereClmhdr_serv_error { get; set; }
		private string _whereClmhdr_serv_error;
		public string WhereClmhdr_serv_status { get; set; }
		private string _whereClmhdr_serv_status;
		public string WhereClmhdr_orig_batch_nbr { get; set; }
		private string _whereClmhdr_orig_batch_nbr;
		public decimal? WhereClmhdr_orig_claim_nbr { get; set; }
		private decimal? _whereClmhdr_orig_claim_nbr;
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
		public string WhereClmdtl_det_rec { get; set; }
		private string _whereClmdtl_det_rec;
		public string WhereClmdtl_rev_group_cd { get; set; }
		private string _whereClmdtl_rev_group_cd;
		public decimal? WhereClmdtl_agent_cd { get; set; }
		private decimal? _whereClmdtl_agent_cd;
		public string WhereClmdtl_adj_cd { get; set; }
		private string _whereClmdtl_adj_cd;
		public decimal? WhereClmdtl_nbr_serv { get; set; }
		private decimal? _whereClmdtl_nbr_serv;
		public decimal? WhereClmdtl_sv_yy { get; set; }
		private decimal? _whereClmdtl_sv_yy;
		public decimal? WhereClmdtl_sv_mm { get; set; }
		private decimal? _whereClmdtl_sv_mm;
		public decimal? WhereClmdtl_sv_dd { get; set; }
		private decimal? _whereClmdtl_sv_dd;
		public decimal? WhereClmdtl_consec_dates { get; set; }
		private decimal? _whereClmdtl_consec_dates;
		public decimal? WhereClmdtl_consecutive_sv_date1 { get; set; }
		private decimal? _whereClmdtl_consecutive_sv_date1;
		public decimal? WhereClmdtl_consecutive_sv_date2 { get; set; }
		private decimal? _whereClmdtl_consecutive_sv_date2;
		public decimal? WhereClmdtl_consecutive_sv_date3 { get; set; }
		private decimal? _whereClmdtl_consecutive_sv_date3;
		public decimal? WhereClmdtl_amt_tech_billed { get; set; }
		private decimal? _whereClmdtl_amt_tech_billed;
		public decimal? WhereClmdtl_fee_oma { get; set; }
		private decimal? _whereClmdtl_fee_oma;
		public decimal? WhereClmdtl_fee_ohip { get; set; }
		private decimal? _whereClmdtl_fee_ohip;
		public string WhereClmdtl_date_period_end { get; set; }
		private string _whereClmdtl_date_period_end;
		public decimal? WhereClmdtl_cycle_nbr { get; set; }
		private decimal? _whereClmdtl_cycle_nbr;
		public decimal? WhereClmdtl_diag_cd { get; set; }
		private decimal? _whereClmdtl_diag_cd;
		public decimal? WhereClmdtl_line_no { get; set; }
		private decimal? _whereClmdtl_line_no;
		public string WhereClmdtl_resubmit_flag { get; set; }
		private string _whereClmdtl_resubmit_flag;
		public string WhereClmdtl_reserve_for_future { get; set; }
		private string _whereClmdtl_reserve_for_future;
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
		public string WhereKey_clm_batch_nbr_red { get; set; }
		private string _whereKey_clm_batch_nbr_red;
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
		private string _originalClaim_header_rec;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private string _originalClmhdr_adj_oma_cd;
		private string _originalClmhdr_adj_oma_suff;
		private string _originalClmhdr_adj_adj_nbr;
		private string _originalClmhdr_batch_type;
		private string _originalClmhdr_adj_cd_sub_type;
		private decimal? _originalClmhdr_doc_nbr_ohip;
		private decimal? _originalClmhdr_doc_spec_cd;
		private decimal? _originalClmhdr_refer_doc_nbr;
		private decimal? _originalClmhdr_diag_cd;
		private string _originalClmhdr_loc;
		private string _originalClmhdr_hosp;
		private decimal? _originalClmhdr_agent_cd;
		private string _originalClmhdr_adj_cd;
		private string _originalClmhdr_tape_submit_ind;
		private string _originalClmhdr_i_o_pat_ind;
		private string _originalClmhdr_pat_key_type;
		private string _originalClmhdr_pat_key_data;
		private string _originalClmhdr_pat_acronym6;
		private string _originalClmhdr_pat_acronym3;
		private string _originalClmhdr_reference;
		private string _originalClmhdr_date_admit;
		private decimal? _originalClmhdr_doc_dept;
		private string _originalClmhdr_msg_nbr;
		private string _originalClmhdr_reprint_flag;
		private string _originalClmhdr_sub_nbr;
		private string _originalClmhdr_auto_logout;
		private string _originalClmhdr_fee_complex;
		private string _originalFiller;
		private decimal? _originalClmhdr_curr_payment;
		private decimal? _originalClmhdr_date_period_end;
		private decimal? _originalClmhdr_cycle_nbr;
		private string _originalClmhdr_date_sys;
		private decimal? _originalClmhdr_amt_tech_billed;
		private decimal? _originalClmhdr_amt_tech_paid;
		private decimal? _originalClmhdr_tot_claim_ar_oma;
		private decimal? _originalClmhdr_tot_claim_ar_ohip;
		private decimal? _originalClmhdr_manual_and_tape_payments;
		private string _originalClmhdr_status_ohip;
		private string _originalClmhdr_manual_review;
		private decimal? _originalClmhdr_submit_date;
		private string _originalClmhdr_confidential_flag;
		private decimal? _originalClmhdr_serv_date;
		private string _originalClmhdr_elig_error;
		private string _originalClmhdr_elig_status;
		private string _originalClmhdr_serv_error;
		private string _originalClmhdr_serv_status;
		private string _originalClmhdr_orig_batch_nbr;
		private decimal? _originalClmhdr_orig_claim_nbr;
		private string _originalClmdtl_batch_nbr;
		private decimal? _originalClmdtl_claim_nbr;
		private string _originalClmdtl_oma_cd;
		private string _originalClmdtl_oma_suff;
		private decimal? _originalClmdtl_adj_nbr;
		private string _originalClmdtl_det_rec;
		private string _originalClmdtl_rev_group_cd;
		private decimal? _originalClmdtl_agent_cd;
		private string _originalClmdtl_adj_cd;
		private decimal? _originalClmdtl_nbr_serv;
		private decimal? _originalClmdtl_sv_yy;
		private decimal? _originalClmdtl_sv_mm;
		private decimal? _originalClmdtl_sv_dd;
		private decimal? _originalClmdtl_consec_dates;
		private decimal? _originalClmdtl_consecutive_sv_date1;
		private decimal? _originalClmdtl_consecutive_sv_date2;
		private decimal? _originalClmdtl_consecutive_sv_date3;
		private decimal? _originalClmdtl_amt_tech_billed;
		private decimal? _originalClmdtl_fee_oma;
		private decimal? _originalClmdtl_fee_ohip;
		private string _originalClmdtl_date_period_end;
		private decimal? _originalClmdtl_cycle_nbr;
		private decimal? _originalClmdtl_diag_cd;
		private decimal? _originalClmdtl_line_no;
		private string _originalClmdtl_resubmit_flag;
		private string _originalClmdtl_reserve_for_future;
		private string _originalClmdtl_desc;
		private string _originalClmdtl_filler0;
		private string _originalClmdtl_filler9;
		private string _originalClmdtl_orig_batch_nbr;
		private decimal? _originalClmdtl_orig_claim_nbr_in_batch;
		private string _originalKey_clm_type;
		private string _originalKey_clm_batch_nbr_red;
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
			CLAIM_HEADER_REC = _originalClaim_header_rec;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			CLMHDR_ADJ_OMA_CD = _originalClmhdr_adj_oma_cd;
			CLMHDR_ADJ_OMA_SUFF = _originalClmhdr_adj_oma_suff;
			CLMHDR_ADJ_ADJ_NBR = _originalClmhdr_adj_adj_nbr;
			CLMHDR_BATCH_TYPE = _originalClmhdr_batch_type;
			CLMHDR_ADJ_CD_SUB_TYPE = _originalClmhdr_adj_cd_sub_type;
			CLMHDR_DOC_NBR_OHIP = _originalClmhdr_doc_nbr_ohip;
			CLMHDR_DOC_SPEC_CD = _originalClmhdr_doc_spec_cd;
			CLMHDR_REFER_DOC_NBR = _originalClmhdr_refer_doc_nbr;
			CLMHDR_DIAG_CD = _originalClmhdr_diag_cd;
			CLMHDR_LOC = _originalClmhdr_loc;
			CLMHDR_HOSP = _originalClmhdr_hosp;
			CLMHDR_AGENT_CD = _originalClmhdr_agent_cd;
			CLMHDR_ADJ_CD = _originalClmhdr_adj_cd;
			CLMHDR_TAPE_SUBMIT_IND = _originalClmhdr_tape_submit_ind;
			CLMHDR_I_O_PAT_IND = _originalClmhdr_i_o_pat_ind;
			CLMHDR_PAT_KEY_TYPE = _originalClmhdr_pat_key_type;
			CLMHDR_PAT_KEY_DATA = _originalClmhdr_pat_key_data;
			CLMHDR_PAT_ACRONYM6 = _originalClmhdr_pat_acronym6;
			CLMHDR_PAT_ACRONYM3 = _originalClmhdr_pat_acronym3;
			CLMHDR_REFERENCE = _originalClmhdr_reference;
			CLMHDR_DATE_ADMIT = _originalClmhdr_date_admit;
			CLMHDR_DOC_DEPT = _originalClmhdr_doc_dept;
			CLMHDR_MSG_NBR = _originalClmhdr_msg_nbr;
			CLMHDR_REPRINT_FLAG = _originalClmhdr_reprint_flag;
			CLMHDR_SUB_NBR = _originalClmhdr_sub_nbr;
			CLMHDR_AUTO_LOGOUT = _originalClmhdr_auto_logout;
			CLMHDR_FEE_COMPLEX = _originalClmhdr_fee_complex;
			FILLER = _originalFiller;
			CLMHDR_CURR_PAYMENT = _originalClmhdr_curr_payment;
			CLMHDR_DATE_PERIOD_END = _originalClmhdr_date_period_end;
			CLMHDR_CYCLE_NBR = _originalClmhdr_cycle_nbr;
			CLMHDR_DATE_SYS = _originalClmhdr_date_sys;
			CLMHDR_AMT_TECH_BILLED = _originalClmhdr_amt_tech_billed;
			CLMHDR_AMT_TECH_PAID = _originalClmhdr_amt_tech_paid;
			CLMHDR_TOT_CLAIM_AR_OMA = _originalClmhdr_tot_claim_ar_oma;
			CLMHDR_TOT_CLAIM_AR_OHIP = _originalClmhdr_tot_claim_ar_ohip;
			CLMHDR_MANUAL_AND_TAPE_PAYMENTS = _originalClmhdr_manual_and_tape_payments;
			CLMHDR_STATUS_OHIP = _originalClmhdr_status_ohip;
			CLMHDR_MANUAL_REVIEW = _originalClmhdr_manual_review;
			CLMHDR_SUBMIT_DATE = _originalClmhdr_submit_date;
			CLMHDR_CONFIDENTIAL_FLAG = _originalClmhdr_confidential_flag;
			CLMHDR_SERV_DATE = _originalClmhdr_serv_date;
			CLMHDR_ELIG_ERROR = _originalClmhdr_elig_error;
			CLMHDR_ELIG_STATUS = _originalClmhdr_elig_status;
			CLMHDR_SERV_ERROR = _originalClmhdr_serv_error;
			CLMHDR_SERV_STATUS = _originalClmhdr_serv_status;
			CLMHDR_ORIG_BATCH_NBR = _originalClmhdr_orig_batch_nbr;
			CLMHDR_ORIG_CLAIM_NBR = _originalClmhdr_orig_claim_nbr;
			CLMDTL_BATCH_NBR = _originalClmdtl_batch_nbr;
			CLMDTL_CLAIM_NBR = _originalClmdtl_claim_nbr;
			CLMDTL_OMA_CD = _originalClmdtl_oma_cd;
			CLMDTL_OMA_SUFF = _originalClmdtl_oma_suff;
			CLMDTL_ADJ_NBR = _originalClmdtl_adj_nbr;
			CLMDTL_DET_REC = _originalClmdtl_det_rec;
			CLMDTL_REV_GROUP_CD = _originalClmdtl_rev_group_cd;
			CLMDTL_AGENT_CD = _originalClmdtl_agent_cd;
			CLMDTL_ADJ_CD = _originalClmdtl_adj_cd;
			CLMDTL_NBR_SERV = _originalClmdtl_nbr_serv;
			CLMDTL_SV_YY = _originalClmdtl_sv_yy;
			CLMDTL_SV_MM = _originalClmdtl_sv_mm;
			CLMDTL_SV_DD = _originalClmdtl_sv_dd;
			CLMDTL_CONSEC_DATES = _originalClmdtl_consec_dates;
			CLMDTL_CONSECUTIVE_SV_DATE1 = _originalClmdtl_consecutive_sv_date1;
			CLMDTL_CONSECUTIVE_SV_DATE2 = _originalClmdtl_consecutive_sv_date2;
			CLMDTL_CONSECUTIVE_SV_DATE3 = _originalClmdtl_consecutive_sv_date3;
			CLMDTL_AMT_TECH_BILLED = _originalClmdtl_amt_tech_billed;
			CLMDTL_FEE_OMA = _originalClmdtl_fee_oma;
			CLMDTL_FEE_OHIP = _originalClmdtl_fee_ohip;
			CLMDTL_DATE_PERIOD_END = _originalClmdtl_date_period_end;
			CLMDTL_CYCLE_NBR = _originalClmdtl_cycle_nbr;
			CLMDTL_DIAG_CD = _originalClmdtl_diag_cd;
			CLMDTL_LINE_NO = _originalClmdtl_line_no;
			CLMDTL_RESUBMIT_FLAG = _originalClmdtl_resubmit_flag;
			CLMDTL_RESERVE_FOR_FUTURE = _originalClmdtl_reserve_for_future;
			CLMDTL_DESC = _originalClmdtl_desc;
			CLMDTL_FILLER0 = _originalClmdtl_filler0;
			CLMDTL_FILLER9 = _originalClmdtl_filler9;
			CLMDTL_ORIG_BATCH_NBR = _originalClmdtl_orig_batch_nbr;
			CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = _originalClmdtl_orig_claim_nbr_in_batch;
			KEY_CLM_TYPE = _originalKey_clm_type;
			KEY_CLM_BATCH_NBR_RED = _originalKey_clm_batch_nbr_red;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_Purge]");
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
						new SqlParameter("CLAIM_HEADER_REC", SqlNull(CLAIM_HEADER_REC)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("CLMHDR_ADJ_OMA_CD", SqlNull(CLMHDR_ADJ_OMA_CD)),
						new SqlParameter("CLMHDR_ADJ_OMA_SUFF", SqlNull(CLMHDR_ADJ_OMA_SUFF)),
						new SqlParameter("CLMHDR_ADJ_ADJ_NBR", SqlNull(CLMHDR_ADJ_ADJ_NBR)),
						new SqlParameter("CLMHDR_BATCH_TYPE", SqlNull(CLMHDR_BATCH_TYPE)),
						new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE", SqlNull(CLMHDR_ADJ_CD_SUB_TYPE)),
						new SqlParameter("CLMHDR_DOC_NBR_OHIP", SqlNull(CLMHDR_DOC_NBR_OHIP)),
						new SqlParameter("CLMHDR_DOC_SPEC_CD", SqlNull(CLMHDR_DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_REFER_DOC_NBR", SqlNull(CLMHDR_REFER_DOC_NBR)),
						new SqlParameter("CLMHDR_DIAG_CD", SqlNull(CLMHDR_DIAG_CD)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_HOSP", SqlNull(CLMHDR_HOSP)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("CLMHDR_TAPE_SUBMIT_IND", SqlNull(CLMHDR_TAPE_SUBMIT_IND)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_PAT_KEY_TYPE", SqlNull(CLMHDR_PAT_KEY_TYPE)),
						new SqlParameter("CLMHDR_PAT_KEY_DATA", SqlNull(CLMHDR_PAT_KEY_DATA)),
						new SqlParameter("CLMHDR_PAT_ACRONYM6", SqlNull(CLMHDR_PAT_ACRONYM6)),
						new SqlParameter("CLMHDR_PAT_ACRONYM3", SqlNull(CLMHDR_PAT_ACRONYM3)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("CLMHDR_DATE_ADMIT", SqlNull(CLMHDR_DATE_ADMIT)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_MSG_NBR", SqlNull(CLMHDR_MSG_NBR)),
						new SqlParameter("CLMHDR_REPRINT_FLAG", SqlNull(CLMHDR_REPRINT_FLAG)),
						new SqlParameter("CLMHDR_SUB_NBR", SqlNull(CLMHDR_SUB_NBR)),
						new SqlParameter("CLMHDR_AUTO_LOGOUT", SqlNull(CLMHDR_AUTO_LOGOUT)),
						new SqlParameter("CLMHDR_FEE_COMPLEX", SqlNull(CLMHDR_FEE_COMPLEX)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_CYCLE_NBR", SqlNull(CLMHDR_CYCLE_NBR)),
						new SqlParameter("CLMHDR_DATE_SYS", SqlNull(CLMHDR_DATE_SYS)),
						new SqlParameter("CLMHDR_AMT_TECH_BILLED", SqlNull(CLMHDR_AMT_TECH_BILLED)),
						new SqlParameter("CLMHDR_AMT_TECH_PAID", SqlNull(CLMHDR_AMT_TECH_PAID)),
						new SqlParameter("CLMHDR_TOT_CLAIM_AR_OMA", SqlNull(CLMHDR_TOT_CLAIM_AR_OMA)),
						new SqlParameter("CLMHDR_TOT_CLAIM_AR_OHIP", SqlNull(CLMHDR_TOT_CLAIM_AR_OHIP)),
						new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", SqlNull(CLMHDR_MANUAL_AND_TAPE_PAYMENTS)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("CLMHDR_MANUAL_REVIEW", SqlNull(CLMHDR_MANUAL_REVIEW)),
						new SqlParameter("CLMHDR_SUBMIT_DATE", SqlNull(CLMHDR_SUBMIT_DATE)),
						new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG", SqlNull(CLMHDR_CONFIDENTIAL_FLAG)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CLMHDR_ELIG_ERROR", SqlNull(CLMHDR_ELIG_ERROR)),
						new SqlParameter("CLMHDR_ELIG_STATUS", SqlNull(CLMHDR_ELIG_STATUS)),
						new SqlParameter("CLMHDR_SERV_ERROR", SqlNull(CLMHDR_SERV_ERROR)),
						new SqlParameter("CLMHDR_SERV_STATUS", SqlNull(CLMHDR_SERV_STATUS)),
						new SqlParameter("CLMHDR_ORIG_BATCH_NBR", SqlNull(CLMHDR_ORIG_BATCH_NBR)),
						new SqlParameter("CLMHDR_ORIG_CLAIM_NBR", SqlNull(CLMHDR_ORIG_CLAIM_NBR)),
						new SqlParameter("CLMDTL_BATCH_NBR", SqlNull(CLMDTL_BATCH_NBR)),
						new SqlParameter("CLMDTL_CLAIM_NBR", SqlNull(CLMDTL_CLAIM_NBR)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_ADJ_NBR", SqlNull(CLMDTL_ADJ_NBR)),
						new SqlParameter("CLMDTL_DET_REC", SqlNull(CLMDTL_DET_REC)),
						new SqlParameter("CLMDTL_REV_GROUP_CD", SqlNull(CLMDTL_REV_GROUP_CD)),
						new SqlParameter("CLMDTL_AGENT_CD", SqlNull(CLMDTL_AGENT_CD)),
						new SqlParameter("CLMDTL_ADJ_CD", SqlNull(CLMDTL_ADJ_CD)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_SV_YY", SqlNull(CLMDTL_SV_YY)),
						new SqlParameter("CLMDTL_SV_MM", SqlNull(CLMDTL_SV_MM)),
						new SqlParameter("CLMDTL_SV_DD", SqlNull(CLMDTL_SV_DD)),
						new SqlParameter("CLMDTL_CONSEC_DATES", SqlNull(CLMDTL_CONSEC_DATES)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE1", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE1)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE2", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE2)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE3", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE3)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_FEE_OMA", SqlNull(CLMDTL_FEE_OMA)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CLMDTL_CYCLE_NBR", SqlNull(CLMDTL_CYCLE_NBR)),
						new SqlParameter("CLMDTL_DIAG_CD", SqlNull(CLMDTL_DIAG_CD)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("CLMDTL_RESUBMIT_FLAG", SqlNull(CLMDTL_RESUBMIT_FLAG)),
						new SqlParameter("CLMDTL_RESERVE_FOR_FUTURE", SqlNull(CLMDTL_RESERVE_FOR_FUTURE)),
						new SqlParameter("CLMDTL_DESC", SqlNull(CLMDTL_DESC)),
						new SqlParameter("CLMDTL_FILLER0", SqlNull(CLMDTL_FILLER0)),
						new SqlParameter("CLMDTL_FILLER9", SqlNull(CLMDTL_FILLER9)),
						new SqlParameter("CLMDTL_ORIG_BATCH_NBR", SqlNull(CLMDTL_ORIG_BATCH_NBR)),
						new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", SqlNull(CLMDTL_ORIG_CLAIM_NBR_IN_BATCH)),
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR_RED", SqlNull(KEY_CLM_BATCH_NBR_RED)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("KEY_CLM_SERV_CODE", SqlNull(KEY_CLM_SERV_CODE)),
						new SqlParameter("KEY_CLM_ADJ_NBR", SqlNull(KEY_CLM_ADJ_NBR)),
						new SqlParameter("KEY_P_CLM_TYPE", SqlNull(KEY_P_CLM_TYPE)),
						new SqlParameter("KEY_P_CLM_DATA", SqlNull(KEY_P_CLM_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_HEADER_REC = Reader["CLAIM_HEADER_REC"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString();
						CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString();
						CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString();
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString();
						CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString();
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString();
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString();
						CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString();
						CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString();
						CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString();
						CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]);
						CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString();
						CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]);
						CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]);
						CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]);
						CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]);
						CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString();
						CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString();
						CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString();
						CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString();
						CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString();
						CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_DET_REC = Reader["CLMDTL_DET_REC"].ToString();
						CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]);
						CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						CLMDTL_CONSECUTIVE_SV_DATE1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]);
						CLMDTL_CONSECUTIVE_SV_DATE2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]);
						CLMDTL_CONSECUTIVE_SV_DATE3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]);
						CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CLMDTL_CYCLE_NBR = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]);
						CLMDTL_DIAG_CD = ConvertDEC(Reader["CLMDTL_DIAG_CD"]);
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						CLMDTL_RESUBMIT_FLAG = Reader["CLMDTL_RESUBMIT_FLAG"].ToString();
						CLMDTL_RESERVE_FOR_FUTURE = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString();
						CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString();
						CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString();
						CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString();
						CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR_RED = Reader["KEY_CLM_BATCH_NBR_RED"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString();
						KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString();
						KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString();
						KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_header_rec = Reader["CLAIM_HEADER_REC"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						_originalClmhdr_adj_adj_nbr = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString();
						_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString();
						_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString();
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						_originalClmhdr_pat_acronym6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString();
						_originalClmhdr_pat_acronym3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString();
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString();
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_msg_nbr = Reader["CLMHDR_MSG_NBR"].ToString();
						_originalClmhdr_reprint_flag = Reader["CLMHDR_REPRINT_FLAG"].ToString();
						_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString();
						_originalClmhdr_auto_logout = Reader["CLMHDR_AUTO_LOGOUT"].ToString();
						_originalClmhdr_fee_complex = Reader["CLMHDR_FEE_COMPLEX"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_cycle_nbr = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]);
						_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString();
						_originalClmhdr_amt_tech_billed = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]);
						_originalClmhdr_amt_tech_paid = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]);
						_originalClmhdr_tot_claim_ar_oma = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]);
						_originalClmhdr_tot_claim_ar_ohip = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]);
						_originalClmhdr_manual_and_tape_payments = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalClmhdr_manual_review = Reader["CLMHDR_MANUAL_REVIEW"].ToString();
						_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString();
						_originalClmhdr_elig_status = Reader["CLMHDR_ELIG_STATUS"].ToString();
						_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString();
						_originalClmhdr_serv_status = Reader["CLMHDR_SERV_STATUS"].ToString();
						_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString();
						_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						_originalClmdtl_det_rec = Reader["CLMDTL_DET_REC"].ToString();
						_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]);
						_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						_originalClmdtl_consecutive_sv_date1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]);
						_originalClmdtl_consecutive_sv_date2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]);
						_originalClmdtl_consecutive_sv_date3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]);
						_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						_originalClmdtl_cycle_nbr = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]);
						_originalClmdtl_diag_cd = ConvertDEC(Reader["CLMDTL_DIAG_CD"]);
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						_originalClmdtl_resubmit_flag = Reader["CLMDTL_RESUBMIT_FLAG"].ToString();
						_originalClmdtl_reserve_for_future = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString();
						_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString();
						_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString();
						_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString();
						_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr_red = Reader["KEY_CLM_BATCH_NBR_RED"].ToString();
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
						new SqlParameter("CLAIM_HEADER_REC", SqlNull(CLAIM_HEADER_REC)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("CLMHDR_ADJ_OMA_CD", SqlNull(CLMHDR_ADJ_OMA_CD)),
						new SqlParameter("CLMHDR_ADJ_OMA_SUFF", SqlNull(CLMHDR_ADJ_OMA_SUFF)),
						new SqlParameter("CLMHDR_ADJ_ADJ_NBR", SqlNull(CLMHDR_ADJ_ADJ_NBR)),
						new SqlParameter("CLMHDR_BATCH_TYPE", SqlNull(CLMHDR_BATCH_TYPE)),
						new SqlParameter("CLMHDR_ADJ_CD_SUB_TYPE", SqlNull(CLMHDR_ADJ_CD_SUB_TYPE)),
						new SqlParameter("CLMHDR_DOC_NBR_OHIP", SqlNull(CLMHDR_DOC_NBR_OHIP)),
						new SqlParameter("CLMHDR_DOC_SPEC_CD", SqlNull(CLMHDR_DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_REFER_DOC_NBR", SqlNull(CLMHDR_REFER_DOC_NBR)),
						new SqlParameter("CLMHDR_DIAG_CD", SqlNull(CLMHDR_DIAG_CD)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_HOSP", SqlNull(CLMHDR_HOSP)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_ADJ_CD", SqlNull(CLMHDR_ADJ_CD)),
						new SqlParameter("CLMHDR_TAPE_SUBMIT_IND", SqlNull(CLMHDR_TAPE_SUBMIT_IND)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_PAT_KEY_TYPE", SqlNull(CLMHDR_PAT_KEY_TYPE)),
						new SqlParameter("CLMHDR_PAT_KEY_DATA", SqlNull(CLMHDR_PAT_KEY_DATA)),
						new SqlParameter("CLMHDR_PAT_ACRONYM6", SqlNull(CLMHDR_PAT_ACRONYM6)),
						new SqlParameter("CLMHDR_PAT_ACRONYM3", SqlNull(CLMHDR_PAT_ACRONYM3)),
						new SqlParameter("CLMHDR_REFERENCE", SqlNull(CLMHDR_REFERENCE)),
						new SqlParameter("CLMHDR_DATE_ADMIT", SqlNull(CLMHDR_DATE_ADMIT)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_MSG_NBR", SqlNull(CLMHDR_MSG_NBR)),
						new SqlParameter("CLMHDR_REPRINT_FLAG", SqlNull(CLMHDR_REPRINT_FLAG)),
						new SqlParameter("CLMHDR_SUB_NBR", SqlNull(CLMHDR_SUB_NBR)),
						new SqlParameter("CLMHDR_AUTO_LOGOUT", SqlNull(CLMHDR_AUTO_LOGOUT)),
						new SqlParameter("CLMHDR_FEE_COMPLEX", SqlNull(CLMHDR_FEE_COMPLEX)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CLMHDR_CURR_PAYMENT", SqlNull(CLMHDR_CURR_PAYMENT)),
						new SqlParameter("CLMHDR_DATE_PERIOD_END", SqlNull(CLMHDR_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_CYCLE_NBR", SqlNull(CLMHDR_CYCLE_NBR)),
						new SqlParameter("CLMHDR_DATE_SYS", SqlNull(CLMHDR_DATE_SYS)),
						new SqlParameter("CLMHDR_AMT_TECH_BILLED", SqlNull(CLMHDR_AMT_TECH_BILLED)),
						new SqlParameter("CLMHDR_AMT_TECH_PAID", SqlNull(CLMHDR_AMT_TECH_PAID)),
						new SqlParameter("CLMHDR_TOT_CLAIM_AR_OMA", SqlNull(CLMHDR_TOT_CLAIM_AR_OMA)),
						new SqlParameter("CLMHDR_TOT_CLAIM_AR_OHIP", SqlNull(CLMHDR_TOT_CLAIM_AR_OHIP)),
						new SqlParameter("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", SqlNull(CLMHDR_MANUAL_AND_TAPE_PAYMENTS)),
						new SqlParameter("CLMHDR_STATUS_OHIP", SqlNull(CLMHDR_STATUS_OHIP)),
						new SqlParameter("CLMHDR_MANUAL_REVIEW", SqlNull(CLMHDR_MANUAL_REVIEW)),
						new SqlParameter("CLMHDR_SUBMIT_DATE", SqlNull(CLMHDR_SUBMIT_DATE)),
						new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG", SqlNull(CLMHDR_CONFIDENTIAL_FLAG)),
						new SqlParameter("CLMHDR_SERV_DATE", SqlNull(CLMHDR_SERV_DATE)),
						new SqlParameter("CLMHDR_ELIG_ERROR", SqlNull(CLMHDR_ELIG_ERROR)),
						new SqlParameter("CLMHDR_ELIG_STATUS", SqlNull(CLMHDR_ELIG_STATUS)),
						new SqlParameter("CLMHDR_SERV_ERROR", SqlNull(CLMHDR_SERV_ERROR)),
						new SqlParameter("CLMHDR_SERV_STATUS", SqlNull(CLMHDR_SERV_STATUS)),
						new SqlParameter("CLMHDR_ORIG_BATCH_NBR", SqlNull(CLMHDR_ORIG_BATCH_NBR)),
						new SqlParameter("CLMHDR_ORIG_CLAIM_NBR", SqlNull(CLMHDR_ORIG_CLAIM_NBR)),
						new SqlParameter("CLMDTL_BATCH_NBR", SqlNull(CLMDTL_BATCH_NBR)),
						new SqlParameter("CLMDTL_CLAIM_NBR", SqlNull(CLMDTL_CLAIM_NBR)),
						new SqlParameter("CLMDTL_OMA_CD", SqlNull(CLMDTL_OMA_CD)),
						new SqlParameter("CLMDTL_OMA_SUFF", SqlNull(CLMDTL_OMA_SUFF)),
						new SqlParameter("CLMDTL_ADJ_NBR", SqlNull(CLMDTL_ADJ_NBR)),
						new SqlParameter("CLMDTL_DET_REC", SqlNull(CLMDTL_DET_REC)),
						new SqlParameter("CLMDTL_REV_GROUP_CD", SqlNull(CLMDTL_REV_GROUP_CD)),
						new SqlParameter("CLMDTL_AGENT_CD", SqlNull(CLMDTL_AGENT_CD)),
						new SqlParameter("CLMDTL_ADJ_CD", SqlNull(CLMDTL_ADJ_CD)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_SV_YY", SqlNull(CLMDTL_SV_YY)),
						new SqlParameter("CLMDTL_SV_MM", SqlNull(CLMDTL_SV_MM)),
						new SqlParameter("CLMDTL_SV_DD", SqlNull(CLMDTL_SV_DD)),
						new SqlParameter("CLMDTL_CONSEC_DATES", SqlNull(CLMDTL_CONSEC_DATES)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE1", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE1)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE2", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE2)),
						new SqlParameter("CLMDTL_CONSECUTIVE_SV_DATE3", SqlNull(CLMDTL_CONSECUTIVE_SV_DATE3)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_FEE_OMA", SqlNull(CLMDTL_FEE_OMA)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CLMDTL_CYCLE_NBR", SqlNull(CLMDTL_CYCLE_NBR)),
						new SqlParameter("CLMDTL_DIAG_CD", SqlNull(CLMDTL_DIAG_CD)),
						new SqlParameter("CLMDTL_LINE_NO", SqlNull(CLMDTL_LINE_NO)),
						new SqlParameter("CLMDTL_RESUBMIT_FLAG", SqlNull(CLMDTL_RESUBMIT_FLAG)),
						new SqlParameter("CLMDTL_RESERVE_FOR_FUTURE", SqlNull(CLMDTL_RESERVE_FOR_FUTURE)),
						new SqlParameter("CLMDTL_DESC", SqlNull(CLMDTL_DESC)),
						new SqlParameter("CLMDTL_FILLER0", SqlNull(CLMDTL_FILLER0)),
						new SqlParameter("CLMDTL_FILLER9", SqlNull(CLMDTL_FILLER9)),
						new SqlParameter("CLMDTL_ORIG_BATCH_NBR", SqlNull(CLMDTL_ORIG_BATCH_NBR)),
						new SqlParameter("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", SqlNull(CLMDTL_ORIG_CLAIM_NBR_IN_BATCH)),
						new SqlParameter("KEY_CLM_TYPE", SqlNull(KEY_CLM_TYPE)),
						new SqlParameter("KEY_CLM_BATCH_NBR_RED", SqlNull(KEY_CLM_BATCH_NBR_RED)),
						new SqlParameter("KEY_CLM_CLAIM_NBR", SqlNull(KEY_CLM_CLAIM_NBR)),
						new SqlParameter("KEY_CLM_SERV_CODE", SqlNull(KEY_CLM_SERV_CODE)),
						new SqlParameter("KEY_CLM_ADJ_NBR", SqlNull(KEY_CLM_ADJ_NBR)),
						new SqlParameter("KEY_P_CLM_TYPE", SqlNull(KEY_P_CLM_TYPE)),
						new SqlParameter("KEY_P_CLM_DATA", SqlNull(KEY_P_CLM_DATA)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_M020_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLAIM_HEADER_REC = Reader["CLAIM_HEADER_REC"].ToString();
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						CLMHDR_ADJ_ADJ_NBR = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString();
						CLMHDR_BATCH_TYPE = Reader["CLMHDR_BATCH_TYPE"].ToString();
						CLMHDR_ADJ_CD_SUB_TYPE = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString();
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_ADJ_CD = Reader["CLMHDR_ADJ_CD"].ToString();
						CLMHDR_TAPE_SUBMIT_IND = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_PAT_KEY_TYPE = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						CLMHDR_PAT_KEY_DATA = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						CLMHDR_PAT_ACRONYM6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString();
						CLMHDR_PAT_ACRONYM3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString();
						CLMHDR_REFERENCE = Reader["CLMHDR_REFERENCE"].ToString();
						CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString();
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_MSG_NBR = Reader["CLMHDR_MSG_NBR"].ToString();
						CLMHDR_REPRINT_FLAG = Reader["CLMHDR_REPRINT_FLAG"].ToString();
						CLMHDR_SUB_NBR = Reader["CLMHDR_SUB_NBR"].ToString();
						CLMHDR_AUTO_LOGOUT = Reader["CLMHDR_AUTO_LOGOUT"].ToString();
						CLMHDR_FEE_COMPLEX = Reader["CLMHDR_FEE_COMPLEX"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CLMHDR_CURR_PAYMENT = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						CLMHDR_DATE_PERIOD_END = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						CLMHDR_CYCLE_NBR = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]);
						CLMHDR_DATE_SYS = Reader["CLMHDR_DATE_SYS"].ToString();
						CLMHDR_AMT_TECH_BILLED = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]);
						CLMHDR_AMT_TECH_PAID = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]);
						CLMHDR_TOT_CLAIM_AR_OMA = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]);
						CLMHDR_TOT_CLAIM_AR_OHIP = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]);
						CLMHDR_MANUAL_AND_TAPE_PAYMENTS = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						CLMHDR_STATUS_OHIP = Reader["CLMHDR_STATUS_OHIP"].ToString();
						CLMHDR_MANUAL_REVIEW = Reader["CLMHDR_MANUAL_REVIEW"].ToString();
						CLMHDR_SUBMIT_DATE = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						CLMHDR_SERV_DATE = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						CLMHDR_ELIG_ERROR = Reader["CLMHDR_ELIG_ERROR"].ToString();
						CLMHDR_ELIG_STATUS = Reader["CLMHDR_ELIG_STATUS"].ToString();
						CLMHDR_SERV_ERROR = Reader["CLMHDR_SERV_ERROR"].ToString();
						CLMHDR_SERV_STATUS = Reader["CLMHDR_SERV_STATUS"].ToString();
						CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_DET_REC = Reader["CLMDTL_DET_REC"].ToString();
						CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]);
						CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						CLMDTL_CONSECUTIVE_SV_DATE1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]);
						CLMDTL_CONSECUTIVE_SV_DATE2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]);
						CLMDTL_CONSECUTIVE_SV_DATE3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]);
						CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CLMDTL_CYCLE_NBR = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]);
						CLMDTL_DIAG_CD = ConvertDEC(Reader["CLMDTL_DIAG_CD"]);
						CLMDTL_LINE_NO = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						CLMDTL_RESUBMIT_FLAG = Reader["CLMDTL_RESUBMIT_FLAG"].ToString();
						CLMDTL_RESERVE_FOR_FUTURE = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString();
						CLMDTL_DESC = Reader["CLMDTL_DESC"].ToString();
						CLMDTL_FILLER0 = Reader["CLMDTL_FILLER0"].ToString();
						CLMDTL_FILLER9 = Reader["CLMDTL_FILLER9"].ToString();
						CLMDTL_ORIG_BATCH_NBR = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						CLMDTL_ORIG_CLAIM_NBR_IN_BATCH = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString();
						KEY_CLM_BATCH_NBR_RED = Reader["KEY_CLM_BATCH_NBR_RED"].ToString();
						KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]);
						KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString();
						KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString();
						KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString();
						KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClaim_header_rec = Reader["CLAIM_HEADER_REC"].ToString();
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						_originalClmhdr_adj_adj_nbr = Reader["CLMHDR_ADJ_ADJ_NBR"].ToString();
						_originalClmhdr_batch_type = Reader["CLMHDR_BATCH_TYPE"].ToString();
						_originalClmhdr_adj_cd_sub_type = Reader["CLMHDR_ADJ_CD_SUB_TYPE"].ToString();
						_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString();
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_adj_cd = Reader["CLMHDR_ADJ_CD"].ToString();
						_originalClmhdr_tape_submit_ind = Reader["CLMHDR_TAPE_SUBMIT_IND"].ToString();
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_pat_key_type = Reader["CLMHDR_PAT_KEY_TYPE"].ToString();
						_originalClmhdr_pat_key_data = Reader["CLMHDR_PAT_KEY_DATA"].ToString();
						_originalClmhdr_pat_acronym6 = Reader["CLMHDR_PAT_ACRONYM6"].ToString();
						_originalClmhdr_pat_acronym3 = Reader["CLMHDR_PAT_ACRONYM3"].ToString();
						_originalClmhdr_reference = Reader["CLMHDR_REFERENCE"].ToString();
						_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString();
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_msg_nbr = Reader["CLMHDR_MSG_NBR"].ToString();
						_originalClmhdr_reprint_flag = Reader["CLMHDR_REPRINT_FLAG"].ToString();
						_originalClmhdr_sub_nbr = Reader["CLMHDR_SUB_NBR"].ToString();
						_originalClmhdr_auto_logout = Reader["CLMHDR_AUTO_LOGOUT"].ToString();
						_originalClmhdr_fee_complex = Reader["CLMHDR_FEE_COMPLEX"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalClmhdr_curr_payment = ConvertDEC(Reader["CLMHDR_CURR_PAYMENT"]);
						_originalClmhdr_date_period_end = ConvertDEC(Reader["CLMHDR_DATE_PERIOD_END"]);
						_originalClmhdr_cycle_nbr = ConvertDEC(Reader["CLMHDR_CYCLE_NBR"]);
						_originalClmhdr_date_sys = Reader["CLMHDR_DATE_SYS"].ToString();
						_originalClmhdr_amt_tech_billed = ConvertDEC(Reader["CLMHDR_AMT_TECH_BILLED"]);
						_originalClmhdr_amt_tech_paid = ConvertDEC(Reader["CLMHDR_AMT_TECH_PAID"]);
						_originalClmhdr_tot_claim_ar_oma = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OMA"]);
						_originalClmhdr_tot_claim_ar_ohip = ConvertDEC(Reader["CLMHDR_TOT_CLAIM_AR_OHIP"]);
						_originalClmhdr_manual_and_tape_payments = ConvertDEC(Reader["CLMHDR_MANUAL_AND_TAPE_PAYMENTS"]);
						_originalClmhdr_status_ohip = Reader["CLMHDR_STATUS_OHIP"].ToString();
						_originalClmhdr_manual_review = Reader["CLMHDR_MANUAL_REVIEW"].ToString();
						_originalClmhdr_submit_date = ConvertDEC(Reader["CLMHDR_SUBMIT_DATE"]);
						_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						_originalClmhdr_serv_date = ConvertDEC(Reader["CLMHDR_SERV_DATE"]);
						_originalClmhdr_elig_error = Reader["CLMHDR_ELIG_ERROR"].ToString();
						_originalClmhdr_elig_status = Reader["CLMHDR_ELIG_STATUS"].ToString();
						_originalClmhdr_serv_error = Reader["CLMHDR_SERV_ERROR"].ToString();
						_originalClmhdr_serv_status = Reader["CLMHDR_SERV_STATUS"].ToString();
						_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						_originalClmdtl_batch_nbr = Reader["CLMDTL_BATCH_NBR"].ToString();
						_originalClmdtl_claim_nbr = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						_originalClmdtl_oma_cd = Reader["CLMDTL_OMA_CD"].ToString();
						_originalClmdtl_oma_suff = Reader["CLMDTL_OMA_SUFF"].ToString();
						_originalClmdtl_adj_nbr = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						_originalClmdtl_det_rec = Reader["CLMDTL_DET_REC"].ToString();
						_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]);
						_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						_originalClmdtl_consecutive_sv_date1 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE1"]);
						_originalClmdtl_consecutive_sv_date2 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE2"]);
						_originalClmdtl_consecutive_sv_date3 = ConvertDEC(Reader["CLMDTL_CONSECUTIVE_SV_DATE3"]);
						_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						_originalClmdtl_cycle_nbr = ConvertDEC(Reader["CLMDTL_CYCLE_NBR"]);
						_originalClmdtl_diag_cd = ConvertDEC(Reader["CLMDTL_DIAG_CD"]);
						_originalClmdtl_line_no = ConvertDEC(Reader["CLMDTL_LINE_NO"]);
						_originalClmdtl_resubmit_flag = Reader["CLMDTL_RESUBMIT_FLAG"].ToString();
						_originalClmdtl_reserve_for_future = Reader["CLMDTL_RESERVE_FOR_FUTURE"].ToString();
						_originalClmdtl_desc = Reader["CLMDTL_DESC"].ToString();
						_originalClmdtl_filler0 = Reader["CLMDTL_FILLER0"].ToString();
						_originalClmdtl_filler9 = Reader["CLMDTL_FILLER9"].ToString();
						_originalClmdtl_orig_batch_nbr = Reader["CLMDTL_ORIG_BATCH_NBR"].ToString();
						_originalClmdtl_orig_claim_nbr_in_batch = ConvertDEC(Reader["CLMDTL_ORIG_CLAIM_NBR_IN_BATCH"]);
						_originalKey_clm_type = Reader["KEY_CLM_TYPE"].ToString();
						_originalKey_clm_batch_nbr_red = Reader["KEY_CLM_BATCH_NBR_RED"].ToString();
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