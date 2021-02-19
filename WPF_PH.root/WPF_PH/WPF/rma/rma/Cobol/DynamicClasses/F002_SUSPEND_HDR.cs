using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_SUSPEND_HDR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_SUSPEND_HDR> Collection( Guid? rowid,
															string clmhdr_batch_nbr,
															decimal? clmhdr_clinic_nbr_1_2min,
															decimal? clmhdr_clinic_nbr_1_2max,
															string clmhdr_doc_nbr,
															decimal? clmhdr_weekmin,
															decimal? clmhdr_weekmax,
															decimal? clmhdr_daymin,
															decimal? clmhdr_daymax,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															string clmhdr_adj_oma_cd,
															string clmhdr_adj_oma_suff,
															string clmhdr_adj_adj_nbrf,
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
															string clmhdr_date_cash_tape_payment,
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
															string clmhdr_orig_batch_nbr,
															decimal? clmhdr_orig_claim_nbrmin,
															decimal? clmhdr_orig_claim_nbrmax,
															string clmhdr_status,
															string clmhdr_health_care_nbr,
															string clmhdr_health_care_ver,
															string clmhdr_health_care_prov,
															string clmhdr_relationship,
															string clmhdr_patient_surname,
															string clmhdr_subscr_initials,
															string clmhdr_wcb_claim_nbr,
															decimal? clmhdr_wcb_accident_datemin,
															decimal? clmhdr_wcb_accident_datemax,
															string clmhdr_wcb_employer_name_addr,
															string clmhdr_wcb_employer_postal_code,
															string clmhdr_confidential_flag,
															decimal? clmhdr_nbr_suspend_desc_recsmin,
															decimal? clmhdr_nbr_suspend_desc_recsmax,
															decimal? clmhdr_doc_ohip_nbrmin,
															decimal? clmhdr_doc_ohip_nbrmax,
															string clmhdr_accounting_nbr,
															string susp_hdr_doc_nbr,
															decimal? susp_hdr_clinic_nbrmin,
															decimal? susp_hdr_clinic_nbrmax,
															string susp_hdr_acronym,
															string susp_hdr_accounting_nbr,
                                                            string debug_info,
                                                            decimal? error_flagmin,
                                                            decimal? error_flagmax,
                                                            string input_file_location,
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
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLINIC_NBR_1_2",clmhdr_clinic_nbr_1_2min),
					new SqlParameter("maxCLMHDR_CLINIC_NBR_1_2",clmhdr_clinic_nbr_1_2max),
					new SqlParameter("CLMHDR_DOC_NBR",clmhdr_doc_nbr),
					new SqlParameter("minCLMHDR_WEEK",clmhdr_weekmin),
					new SqlParameter("maxCLMHDR_WEEK",clmhdr_weekmax),
					new SqlParameter("minCLMHDR_DAY",clmhdr_daymin),
					new SqlParameter("maxCLMHDR_DAY",clmhdr_daymax),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("CLMHDR_ADJ_OMA_CD",clmhdr_adj_oma_cd),
					new SqlParameter("CLMHDR_ADJ_OMA_SUFF",clmhdr_adj_oma_suff),
					new SqlParameter("CLMHDR_ADJ_ADJ_NBRF",clmhdr_adj_adj_nbrf),
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
					new SqlParameter("CLMHDR_DATE_CASH_TAPE_PAYMENT",clmhdr_date_cash_tape_payment),
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
					new SqlParameter("CLMHDR_ORIG_BATCH_NBR",clmhdr_orig_batch_nbr),
					new SqlParameter("minCLMHDR_ORIG_CLAIM_NBR",clmhdr_orig_claim_nbrmin),
					new SqlParameter("maxCLMHDR_ORIG_CLAIM_NBR",clmhdr_orig_claim_nbrmax),
					new SqlParameter("CLMHDR_STATUS",clmhdr_status),
					new SqlParameter("CLMHDR_HEALTH_CARE_NBR",clmhdr_health_care_nbr),
					new SqlParameter("CLMHDR_HEALTH_CARE_VER",clmhdr_health_care_ver),
					new SqlParameter("CLMHDR_HEALTH_CARE_PROV",clmhdr_health_care_prov),
					new SqlParameter("CLMHDR_RELATIONSHIP",clmhdr_relationship),
					new SqlParameter("CLMHDR_PATIENT_SURNAME",clmhdr_patient_surname),
					new SqlParameter("CLMHDR_SUBSCR_INITIALS",clmhdr_subscr_initials),
					new SqlParameter("CLMHDR_WCB_CLAIM_NBR",clmhdr_wcb_claim_nbr),
					new SqlParameter("minCLMHDR_WCB_ACCIDENT_DATE",clmhdr_wcb_accident_datemin),
					new SqlParameter("maxCLMHDR_WCB_ACCIDENT_DATE",clmhdr_wcb_accident_datemax),
					new SqlParameter("CLMHDR_WCB_EMPLOYER_NAME_ADDR",clmhdr_wcb_employer_name_addr),
					new SqlParameter("CLMHDR_WCB_EMPLOYER_POSTAL_CODE",clmhdr_wcb_employer_postal_code),
					new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG",clmhdr_confidential_flag),
					new SqlParameter("minCLMHDR_NBR_SUSPEND_DESC_RECS",clmhdr_nbr_suspend_desc_recsmin),
					new SqlParameter("maxCLMHDR_NBR_SUSPEND_DESC_RECS",clmhdr_nbr_suspend_desc_recsmax),
					new SqlParameter("minCLMHDR_DOC_OHIP_NBR",clmhdr_doc_ohip_nbrmin),
					new SqlParameter("maxCLMHDR_DOC_OHIP_NBR",clmhdr_doc_ohip_nbrmax),
					new SqlParameter("CLMHDR_ACCOUNTING_NBR",clmhdr_accounting_nbr),
					new SqlParameter("SUSP_HDR_DOC_NBR",susp_hdr_doc_nbr),
					new SqlParameter("minSUSP_HDR_CLINIC_NBR",susp_hdr_clinic_nbrmin),
					new SqlParameter("maxSUSP_HDR_CLINIC_NBR",susp_hdr_clinic_nbrmax),
					new SqlParameter("SUSP_HDR_ACRONYM",susp_hdr_acronym),
					new SqlParameter("SUSP_HDR_ACCOUNTING_NBR",susp_hdr_accounting_nbr),
                    new SqlParameter("DEBUG_INFO",debug_info),
                    new SqlParameter("minERROR_FLAG",error_flagmin),
                    new SqlParameter("maxERROR_FLAG",error_flagmax),
                    new SqlParameter("INPUT_FILE_LOCATION",input_file_location),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_HDR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_SUSPEND_HDR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_HDR_Search]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_HDR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
                    CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
                    CLMHDR_WEEK = ConvertDEC(Reader["CLMHDR_WEEK"]),
                    CLMHDR_DAY = ConvertDEC(Reader["CLMHDR_DAY"]),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    CLMHDR_ADJ_ADJ_NBRF = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString(),
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
                    CLMHDR_DATE_CASH_TAPE_PAYMENT = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString(),
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
                    CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    CLMHDR_STATUS = Reader["CLMHDR_STATUS"].ToString(),
                    CLMHDR_HEALTH_CARE_NBR = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString(),
                    CLMHDR_HEALTH_CARE_VER = Reader["CLMHDR_HEALTH_CARE_VER"].ToString(),
                    CLMHDR_HEALTH_CARE_PROV = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString(),
                    CLMHDR_RELATIONSHIP = Reader["CLMHDR_RELATIONSHIP"].ToString(),
                    CLMHDR_PATIENT_SURNAME = Reader["CLMHDR_PATIENT_SURNAME"].ToString(),
                    CLMHDR_SUBSCR_INITIALS = Reader["CLMHDR_SUBSCR_INITIALS"].ToString(),
                    CLMHDR_WCB_CLAIM_NBR = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString(),
                    CLMHDR_WCB_ACCIDENT_DATE = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]),
                    CLMHDR_WCB_EMPLOYER_NAME_ADDR = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString(),
                    CLMHDR_WCB_EMPLOYER_POSTAL_CODE = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString(),
                    CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    CLMHDR_NBR_SUSPEND_DESC_RECS = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]),
                    CLMHDR_DOC_OHIP_NBR = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]),
                    CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
                    SUSP_HDR_DOC_NBR = Reader["SUSP_HDR_DOC_NBR"].ToString(),
                    SUSP_HDR_CLINIC_NBR = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]),
                    SUSP_HDR_ACRONYM = Reader["SUSP_HDR_ACRONYM"].ToString(),
                    SUSP_HDR_ACCOUNTING_NBR = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString(),
                    DEBUG_INFO = Reader["DEBUG_INFO"].ToString(),
                    ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]),
                    INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalClmhdr_week = ConvertDEC(Reader["CLMHDR_WEEK"]),
					_originalClmhdr_day = ConvertDEC(Reader["CLMHDR_DAY"]),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
					_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
					_originalClmhdr_adj_adj_nbrf = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString(),
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
					_originalClmhdr_date_cash_tape_payment = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString(),
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
					_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
					_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
					_originalClmhdr_status = Reader["CLMHDR_STATUS"].ToString(),
					_originalClmhdr_health_care_nbr = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString(),
					_originalClmhdr_health_care_ver = Reader["CLMHDR_HEALTH_CARE_VER"].ToString(),
					_originalClmhdr_health_care_prov = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString(),
					_originalClmhdr_relationship = Reader["CLMHDR_RELATIONSHIP"].ToString(),
					_originalClmhdr_patient_surname = Reader["CLMHDR_PATIENT_SURNAME"].ToString(),
					_originalClmhdr_subscr_initials = Reader["CLMHDR_SUBSCR_INITIALS"].ToString(),
					_originalClmhdr_wcb_claim_nbr = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString(),
					_originalClmhdr_wcb_accident_date = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]),
					_originalClmhdr_wcb_employer_name_addr = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString(),
					_originalClmhdr_wcb_employer_postal_code = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString(),
					_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
					_originalClmhdr_nbr_suspend_desc_recs = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]),
					_originalClmhdr_doc_ohip_nbr = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]),
					_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
					_originalSusp_hdr_doc_nbr = Reader["SUSP_HDR_DOC_NBR"].ToString(),
					_originalSusp_hdr_clinic_nbr = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]),
					_originalSusp_hdr_acronym = Reader["SUSP_HDR_ACRONYM"].ToString(),
					_originalSusp_hdr_accounting_nbr = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString(),
                    _originalDebug_info = Reader["DEBUG_INFO"].ToString(),
                    _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]),
                    _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F002_SUSPEND_HDR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_SUSPEND_HDR> Collection(ObservableCollection<F002_SUSPEND_HDR>
                                                               f002SuspendHdr = null)
        {
            if (IsSameSearch() && f002SuspendHdr != null)
            {
                return f002SuspendHdr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_SUSPEND_HDR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLINIC_NBR_1_2",WhereClmhdr_clinic_nbr_1_2),
					new SqlParameter("CLMHDR_DOC_NBR",WhereClmhdr_doc_nbr),
					new SqlParameter("CLMHDR_WEEK",WhereClmhdr_week),
					new SqlParameter("CLMHDR_DAY",WhereClmhdr_day),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("CLMHDR_ADJ_OMA_CD",WhereClmhdr_adj_oma_cd),
					new SqlParameter("CLMHDR_ADJ_OMA_SUFF",WhereClmhdr_adj_oma_suff),
					new SqlParameter("CLMHDR_ADJ_ADJ_NBRF",WhereClmhdr_adj_adj_nbrf),
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
					new SqlParameter("CLMHDR_DATE_CASH_TAPE_PAYMENT",WhereClmhdr_date_cash_tape_payment),
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
					new SqlParameter("CLMHDR_ORIG_BATCH_NBR",WhereClmhdr_orig_batch_nbr),
					new SqlParameter("CLMHDR_ORIG_CLAIM_NBR",WhereClmhdr_orig_claim_nbr),
					new SqlParameter("CLMHDR_STATUS",WhereClmhdr_status),
					new SqlParameter("CLMHDR_HEALTH_CARE_NBR",WhereClmhdr_health_care_nbr),
					new SqlParameter("CLMHDR_HEALTH_CARE_VER",WhereClmhdr_health_care_ver),
					new SqlParameter("CLMHDR_HEALTH_CARE_PROV",WhereClmhdr_health_care_prov),
					new SqlParameter("CLMHDR_RELATIONSHIP",WhereClmhdr_relationship),
					new SqlParameter("CLMHDR_PATIENT_SURNAME",WhereClmhdr_patient_surname),
					new SqlParameter("CLMHDR_SUBSCR_INITIALS",WhereClmhdr_subscr_initials),
					new SqlParameter("CLMHDR_WCB_CLAIM_NBR",WhereClmhdr_wcb_claim_nbr),
					new SqlParameter("CLMHDR_WCB_ACCIDENT_DATE",WhereClmhdr_wcb_accident_date),
					new SqlParameter("CLMHDR_WCB_EMPLOYER_NAME_ADDR",WhereClmhdr_wcb_employer_name_addr),
					new SqlParameter("CLMHDR_WCB_EMPLOYER_POSTAL_CODE",WhereClmhdr_wcb_employer_postal_code),
					new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG",WhereClmhdr_confidential_flag),
					new SqlParameter("CLMHDR_NBR_SUSPEND_DESC_RECS",WhereClmhdr_nbr_suspend_desc_recs),
					new SqlParameter("CLMHDR_DOC_OHIP_NBR",WhereClmhdr_doc_ohip_nbr),
					new SqlParameter("CLMHDR_ACCOUNTING_NBR",WhereClmhdr_accounting_nbr),
					new SqlParameter("SUSP_HDR_DOC_NBR",WhereSusp_hdr_doc_nbr),
					new SqlParameter("SUSP_HDR_CLINIC_NBR",WhereSusp_hdr_clinic_nbr),
					new SqlParameter("SUSP_HDR_ACRONYM",WhereSusp_hdr_acronym),
					new SqlParameter("SUSP_HDR_ACCOUNTING_NBR",WhereSusp_hdr_accounting_nbr),
                    new SqlParameter("DEBUG_INFO",WhereDebug_info),
                    new SqlParameter("ERROR_FLAG",WhereError_flag),
                    new SqlParameter("INPUT_FILE_LOCATION",WhereInput_file_location),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_HDR_Match]", parameters);
            var collection = new ObservableCollection<F002_SUSPEND_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F002_SUSPEND_HDR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
                    CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
                    CLMHDR_WEEK = ConvertDEC(Reader["CLMHDR_WEEK"]),
                    CLMHDR_DAY = ConvertDEC(Reader["CLMHDR_DAY"]),
                    CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    CLMHDR_ADJ_ADJ_NBRF = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString(),
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
                    CLMHDR_DATE_CASH_TAPE_PAYMENT = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString(),
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
                    CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    CLMHDR_STATUS = Reader["CLMHDR_STATUS"].ToString(),
                    CLMHDR_HEALTH_CARE_NBR = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString(),
                    CLMHDR_HEALTH_CARE_VER = Reader["CLMHDR_HEALTH_CARE_VER"].ToString(),
                    CLMHDR_HEALTH_CARE_PROV = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString(),
                    CLMHDR_RELATIONSHIP = Reader["CLMHDR_RELATIONSHIP"].ToString(),
                    CLMHDR_PATIENT_SURNAME = Reader["CLMHDR_PATIENT_SURNAME"].ToString(),
                    CLMHDR_SUBSCR_INITIALS = Reader["CLMHDR_SUBSCR_INITIALS"].ToString(),
                    CLMHDR_WCB_CLAIM_NBR = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString(),
                    CLMHDR_WCB_ACCIDENT_DATE = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]),
                    CLMHDR_WCB_EMPLOYER_NAME_ADDR = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString(),
                    CLMHDR_WCB_EMPLOYER_POSTAL_CODE = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString(),
                    CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    CLMHDR_NBR_SUSPEND_DESC_RECS = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]),
                    CLMHDR_DOC_OHIP_NBR = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]),
                    CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
                    SUSP_HDR_DOC_NBR = Reader["SUSP_HDR_DOC_NBR"].ToString(),
                    SUSP_HDR_CLINIC_NBR = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]),
                    SUSP_HDR_ACRONYM = Reader["SUSP_HDR_ACRONYM"].ToString(),
                    SUSP_HDR_ACCOUNTING_NBR = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString(),
                    DEBUG_INFO = Reader["DEBUG_INFO"].ToString(),
                    ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]),
                    INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString(),
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _whereRowid = WhereRowid,
                    _whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
                    _whereClmhdr_clinic_nbr_1_2 = WhereClmhdr_clinic_nbr_1_2,
                    _whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr,
                    _whereClmhdr_week = WhereClmhdr_week,
                    _whereClmhdr_day = WhereClmhdr_day,
                    _whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
                    _whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd,
                    _whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff,
                    _whereClmhdr_adj_adj_nbrf = WhereClmhdr_adj_adj_nbrf,
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
                    _whereClmhdr_date_cash_tape_payment = WhereClmhdr_date_cash_tape_payment,
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
                    _whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr,
                    _whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr,
                    _whereClmhdr_status = WhereClmhdr_status,
                    _whereClmhdr_health_care_nbr = WhereClmhdr_health_care_nbr,
                    _whereClmhdr_health_care_ver = WhereClmhdr_health_care_ver,
                    _whereClmhdr_health_care_prov = WhereClmhdr_health_care_prov,
                    _whereClmhdr_relationship = WhereClmhdr_relationship,
                    _whereClmhdr_patient_surname = WhereClmhdr_patient_surname,
                    _whereClmhdr_subscr_initials = WhereClmhdr_subscr_initials,
                    _whereClmhdr_wcb_claim_nbr = WhereClmhdr_wcb_claim_nbr,
                    _whereClmhdr_wcb_accident_date = WhereClmhdr_wcb_accident_date,
                    _whereClmhdr_wcb_employer_name_addr = WhereClmhdr_wcb_employer_name_addr,
                    _whereClmhdr_wcb_employer_postal_code = WhereClmhdr_wcb_employer_postal_code,
                    _whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag,
                    _whereClmhdr_nbr_suspend_desc_recs = WhereClmhdr_nbr_suspend_desc_recs,
                    _whereClmhdr_doc_ohip_nbr = WhereClmhdr_doc_ohip_nbr,
                    _whereClmhdr_accounting_nbr = WhereClmhdr_accounting_nbr,
                    _whereSusp_hdr_doc_nbr = WhereSusp_hdr_doc_nbr,
                    _whereSusp_hdr_clinic_nbr = WhereSusp_hdr_clinic_nbr,
                    _whereSusp_hdr_acronym = WhereSusp_hdr_acronym,
                    _whereSusp_hdr_accounting_nbr = WhereSusp_hdr_accounting_nbr,
                    _whereDebug_info = WhereDebug_info,
                    _whereError_flag = WhereError_flag,
                    _whereInput_file_location = WhereInput_file_location,
                    _whereChecksum_value = WhereChecksum_value,

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
                    _originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]),
                    _originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
                    _originalClmhdr_week = ConvertDEC(Reader["CLMHDR_WEEK"]),
                    _originalClmhdr_day = ConvertDEC(Reader["CLMHDR_DAY"]),
                    _originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
                    _originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString(),
                    _originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString(),
                    _originalClmhdr_adj_adj_nbrf = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString(),
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
                    _originalClmhdr_date_cash_tape_payment = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString(),
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
                    _originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString(),
                    _originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]),
                    _originalClmhdr_status = Reader["CLMHDR_STATUS"].ToString(),
                    _originalClmhdr_health_care_nbr = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString(),
                    _originalClmhdr_health_care_ver = Reader["CLMHDR_HEALTH_CARE_VER"].ToString(),
                    _originalClmhdr_health_care_prov = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString(),
                    _originalClmhdr_relationship = Reader["CLMHDR_RELATIONSHIP"].ToString(),
                    _originalClmhdr_patient_surname = Reader["CLMHDR_PATIENT_SURNAME"].ToString(),
                    _originalClmhdr_subscr_initials = Reader["CLMHDR_SUBSCR_INITIALS"].ToString(),
                    _originalClmhdr_wcb_claim_nbr = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString(),
                    _originalClmhdr_wcb_accident_date = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]),
                    _originalClmhdr_wcb_employer_name_addr = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString(),
                    _originalClmhdr_wcb_employer_postal_code = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString(),
                    _originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString(),
                    _originalClmhdr_nbr_suspend_desc_recs = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]),
                    _originalClmhdr_doc_ohip_nbr = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]),
                    _originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString(),
                    _originalSusp_hdr_doc_nbr = Reader["SUSP_HDR_DOC_NBR"].ToString(),
                    _originalSusp_hdr_clinic_nbr = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]),
                    _originalSusp_hdr_acronym = Reader["SUSP_HDR_ACRONYM"].ToString(),
                    _originalSusp_hdr_accounting_nbr = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString(),
                    _originalDebug_info = Reader["DEBUG_INFO"].ToString(),
                    _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]),
                    _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_clinic_nbr_1_2 = WhereClmhdr_clinic_nbr_1_2;
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr;
					_whereClmhdr_week = WhereClmhdr_week;
					_whereClmhdr_day = WhereClmhdr_day;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereClmhdr_adj_oma_cd = WhereClmhdr_adj_oma_cd;
					_whereClmhdr_adj_oma_suff = WhereClmhdr_adj_oma_suff;
					_whereClmhdr_adj_adj_nbrf = WhereClmhdr_adj_adj_nbrf;
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
					_whereClmhdr_date_cash_tape_payment = WhereClmhdr_date_cash_tape_payment;
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
					_whereClmhdr_orig_batch_nbr = WhereClmhdr_orig_batch_nbr;
					_whereClmhdr_orig_claim_nbr = WhereClmhdr_orig_claim_nbr;
					_whereClmhdr_status = WhereClmhdr_status;
					_whereClmhdr_health_care_nbr = WhereClmhdr_health_care_nbr;
					_whereClmhdr_health_care_ver = WhereClmhdr_health_care_ver;
					_whereClmhdr_health_care_prov = WhereClmhdr_health_care_prov;
					_whereClmhdr_relationship = WhereClmhdr_relationship;
					_whereClmhdr_patient_surname = WhereClmhdr_patient_surname;
					_whereClmhdr_subscr_initials = WhereClmhdr_subscr_initials;
					_whereClmhdr_wcb_claim_nbr = WhereClmhdr_wcb_claim_nbr;
					_whereClmhdr_wcb_accident_date = WhereClmhdr_wcb_accident_date;
					_whereClmhdr_wcb_employer_name_addr = WhereClmhdr_wcb_employer_name_addr;
					_whereClmhdr_wcb_employer_postal_code = WhereClmhdr_wcb_employer_postal_code;
					_whereClmhdr_confidential_flag = WhereClmhdr_confidential_flag;
					_whereClmhdr_nbr_suspend_desc_recs = WhereClmhdr_nbr_suspend_desc_recs;
					_whereClmhdr_doc_ohip_nbr = WhereClmhdr_doc_ohip_nbr;
					_whereClmhdr_accounting_nbr = WhereClmhdr_accounting_nbr;
					_whereSusp_hdr_doc_nbr = WhereSusp_hdr_doc_nbr;
					_whereSusp_hdr_clinic_nbr = WhereSusp_hdr_clinic_nbr;
					_whereSusp_hdr_acronym = WhereSusp_hdr_acronym;
                    _whereSusp_hdr_accounting_nbr = WhereSusp_hdr_accounting_nbr;
                    _whereDebug_info = WhereDebug_info;
                    _whereError_flag = WhereError_flag;
                    _whereInput_file_location = WhereInput_file_location;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_clinic_nbr_1_2 == null 
				&& WhereClmhdr_doc_nbr == null 
				&& WhereClmhdr_week == null 
				&& WhereClmhdr_day == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereClmhdr_adj_oma_cd == null 
				&& WhereClmhdr_adj_oma_suff == null 
				&& WhereClmhdr_adj_adj_nbrf == null 
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
				&& WhereClmhdr_date_cash_tape_payment == null 
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
				&& WhereClmhdr_orig_batch_nbr == null 
				&& WhereClmhdr_orig_claim_nbr == null 
				&& WhereClmhdr_status == null 
				&& WhereClmhdr_health_care_nbr == null 
				&& WhereClmhdr_health_care_ver == null 
				&& WhereClmhdr_health_care_prov == null 
				&& WhereClmhdr_relationship == null 
				&& WhereClmhdr_patient_surname == null 
				&& WhereClmhdr_subscr_initials == null 
				&& WhereClmhdr_wcb_claim_nbr == null 
				&& WhereClmhdr_wcb_accident_date == null 
				&& WhereClmhdr_wcb_employer_name_addr == null 
				&& WhereClmhdr_wcb_employer_postal_code == null 
				&& WhereClmhdr_confidential_flag == null 
				&& WhereClmhdr_nbr_suspend_desc_recs == null 
				&& WhereClmhdr_doc_ohip_nbr == null 
				&& WhereClmhdr_accounting_nbr == null 
				&& WhereSusp_hdr_doc_nbr == null 
				&& WhereSusp_hdr_clinic_nbr == null 
				&& WhereSusp_hdr_acronym == null 
				&& WhereSusp_hdr_accounting_nbr == null 
                && WhereDebug_info == null
                && WhereError_flag == null
                && WhereInput_file_location == null
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_clinic_nbr_1_2 ==  _whereClmhdr_clinic_nbr_1_2
				&& WhereClmhdr_doc_nbr ==  _whereClmhdr_doc_nbr
				&& WhereClmhdr_week ==  _whereClmhdr_week
				&& WhereClmhdr_day ==  _whereClmhdr_day
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereClmhdr_adj_oma_cd ==  _whereClmhdr_adj_oma_cd
				&& WhereClmhdr_adj_oma_suff ==  _whereClmhdr_adj_oma_suff
				&& WhereClmhdr_adj_adj_nbrf ==  _whereClmhdr_adj_adj_nbrf
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
				&& WhereClmhdr_date_cash_tape_payment ==  _whereClmhdr_date_cash_tape_payment
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
				&& WhereClmhdr_orig_batch_nbr ==  _whereClmhdr_orig_batch_nbr
				&& WhereClmhdr_orig_claim_nbr ==  _whereClmhdr_orig_claim_nbr
				&& WhereClmhdr_status ==  _whereClmhdr_status
				&& WhereClmhdr_health_care_nbr ==  _whereClmhdr_health_care_nbr
				&& WhereClmhdr_health_care_ver ==  _whereClmhdr_health_care_ver
				&& WhereClmhdr_health_care_prov ==  _whereClmhdr_health_care_prov
				&& WhereClmhdr_relationship ==  _whereClmhdr_relationship
				&& WhereClmhdr_patient_surname ==  _whereClmhdr_patient_surname
				&& WhereClmhdr_subscr_initials ==  _whereClmhdr_subscr_initials
				&& WhereClmhdr_wcb_claim_nbr ==  _whereClmhdr_wcb_claim_nbr
				&& WhereClmhdr_wcb_accident_date ==  _whereClmhdr_wcb_accident_date
				&& WhereClmhdr_wcb_employer_name_addr ==  _whereClmhdr_wcb_employer_name_addr
				&& WhereClmhdr_wcb_employer_postal_code ==  _whereClmhdr_wcb_employer_postal_code
				&& WhereClmhdr_confidential_flag ==  _whereClmhdr_confidential_flag
				&& WhereClmhdr_nbr_suspend_desc_recs ==  _whereClmhdr_nbr_suspend_desc_recs
				&& WhereClmhdr_doc_ohip_nbr ==  _whereClmhdr_doc_ohip_nbr
				&& WhereClmhdr_accounting_nbr ==  _whereClmhdr_accounting_nbr
				&& WhereSusp_hdr_doc_nbr ==  _whereSusp_hdr_doc_nbr
				&& WhereSusp_hdr_clinic_nbr ==  _whereSusp_hdr_clinic_nbr
				&& WhereSusp_hdr_acronym ==  _whereSusp_hdr_acronym
				&& WhereSusp_hdr_accounting_nbr ==  _whereSusp_hdr_accounting_nbr
                && WhereDebug_info == _whereDebug_info
                && WhereError_flag == _whereError_flag
                && WhereInput_file_location == _whereInput_file_location
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_clinic_nbr_1_2 = null; 
			WhereClmhdr_doc_nbr = null; 
			WhereClmhdr_week = null; 
			WhereClmhdr_day = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereClmhdr_adj_oma_cd = null; 
			WhereClmhdr_adj_oma_suff = null; 
			WhereClmhdr_adj_adj_nbrf = null; 
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
			WhereClmhdr_date_cash_tape_payment = null; 
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
			WhereClmhdr_orig_batch_nbr = null; 
			WhereClmhdr_orig_claim_nbr = null; 
			WhereClmhdr_status = null; 
			WhereClmhdr_health_care_nbr = null; 
			WhereClmhdr_health_care_ver = null; 
			WhereClmhdr_health_care_prov = null; 
			WhereClmhdr_relationship = null; 
			WhereClmhdr_patient_surname = null; 
			WhereClmhdr_subscr_initials = null; 
			WhereClmhdr_wcb_claim_nbr = null; 
			WhereClmhdr_wcb_accident_date = null; 
			WhereClmhdr_wcb_employer_name_addr = null; 
			WhereClmhdr_wcb_employer_postal_code = null; 
			WhereClmhdr_confidential_flag = null; 
			WhereClmhdr_nbr_suspend_desc_recs = null; 
			WhereClmhdr_doc_ohip_nbr = null; 
			WhereClmhdr_accounting_nbr = null; 
			WhereSusp_hdr_doc_nbr = null; 
			WhereSusp_hdr_clinic_nbr = null; 
			WhereSusp_hdr_acronym = null; 
			WhereSusp_hdr_accounting_nbr = null;
            WhereDebug_info = null;
            WhereError_flag = null;
            WhereInput_file_location = null;
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLINIC_NBR_1_2;
		private string _CLMHDR_DOC_NBR;
		private decimal? _CLMHDR_WEEK;
		private decimal? _CLMHDR_DAY;
		private decimal? _CLMHDR_CLAIM_NBR;
		private string _CLMHDR_ADJ_OMA_CD;
		private string _CLMHDR_ADJ_OMA_SUFF;
		private string _CLMHDR_ADJ_ADJ_NBRF;
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
		private string _CLMHDR_DATE_CASH_TAPE_PAYMENT;
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
		private string _CLMHDR_ORIG_BATCH_NBR;
		private decimal? _CLMHDR_ORIG_CLAIM_NBR;
		private string _CLMHDR_STATUS;
		private string _CLMHDR_HEALTH_CARE_NBR;
		private string _CLMHDR_HEALTH_CARE_VER;
		private string _CLMHDR_HEALTH_CARE_PROV;
		private string _CLMHDR_RELATIONSHIP;
		private string _CLMHDR_PATIENT_SURNAME;
		private string _CLMHDR_SUBSCR_INITIALS;
		private string _CLMHDR_WCB_CLAIM_NBR;
		private decimal? _CLMHDR_WCB_ACCIDENT_DATE;
		private string _CLMHDR_WCB_EMPLOYER_NAME_ADDR;
		private string _CLMHDR_WCB_EMPLOYER_POSTAL_CODE;
		private string _CLMHDR_CONFIDENTIAL_FLAG;
		private decimal? _CLMHDR_NBR_SUSPEND_DESC_RECS;
		private decimal? _CLMHDR_DOC_OHIP_NBR;
		private string _CLMHDR_ACCOUNTING_NBR;
		private string _SUSP_HDR_DOC_NBR;
		private decimal? _SUSP_HDR_CLINIC_NBR;
		private string _SUSP_HDR_ACRONYM;
		private string _SUSP_HDR_ACCOUNTING_NBR;
        private string _DEBUG_INFO;
        private decimal? _ERROR_FLAG;
        private string _INPUT_FILE_LOCATION;
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
		public decimal? CLMHDR_CLINIC_NBR_1_2
		{
			get { return _CLMHDR_CLINIC_NBR_1_2; }
			set
			{
				if (_CLMHDR_CLINIC_NBR_1_2 != value)
				{
					_CLMHDR_CLINIC_NBR_1_2 = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_DOC_NBR
		{
			get { return _CLMHDR_DOC_NBR; }
			set
			{
				if (_CLMHDR_DOC_NBR != value)
				{
					_CLMHDR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_WEEK
		{
			get { return _CLMHDR_WEEK; }
			set
			{
				if (_CLMHDR_WEEK != value)
				{
					_CLMHDR_WEEK = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DAY
		{
			get { return _CLMHDR_DAY; }
			set
			{
				if (_CLMHDR_DAY != value)
				{
					_CLMHDR_DAY = value;
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
		public string CLMHDR_ADJ_ADJ_NBRF
		{
			get { return _CLMHDR_ADJ_ADJ_NBRF; }
			set
			{
				if (_CLMHDR_ADJ_ADJ_NBRF != value)
				{
					_CLMHDR_ADJ_ADJ_NBRF = value;
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
		public string CLMHDR_DATE_CASH_TAPE_PAYMENT
		{
			get { return _CLMHDR_DATE_CASH_TAPE_PAYMENT; }
			set
			{
				if (_CLMHDR_DATE_CASH_TAPE_PAYMENT != value)
				{
					_CLMHDR_DATE_CASH_TAPE_PAYMENT = value;
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
		public string CLMHDR_STATUS
		{
			get { return _CLMHDR_STATUS; }
			set
			{
				if (_CLMHDR_STATUS != value)
				{
					_CLMHDR_STATUS = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_HEALTH_CARE_NBR
		{
			get { return _CLMHDR_HEALTH_CARE_NBR; }
			set
			{
				if (_CLMHDR_HEALTH_CARE_NBR != value)
				{
					_CLMHDR_HEALTH_CARE_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_HEALTH_CARE_VER
		{
			get { return _CLMHDR_HEALTH_CARE_VER; }
			set
			{
				if (_CLMHDR_HEALTH_CARE_VER != value)
				{
					_CLMHDR_HEALTH_CARE_VER = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_HEALTH_CARE_PROV
		{
			get { return _CLMHDR_HEALTH_CARE_PROV; }
			set
			{
				if (_CLMHDR_HEALTH_CARE_PROV != value)
				{
					_CLMHDR_HEALTH_CARE_PROV = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_RELATIONSHIP
		{
			get { return _CLMHDR_RELATIONSHIP; }
			set
			{
				if (_CLMHDR_RELATIONSHIP != value)
				{
					_CLMHDR_RELATIONSHIP = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PATIENT_SURNAME
		{
			get { return _CLMHDR_PATIENT_SURNAME; }
			set
			{
				if (_CLMHDR_PATIENT_SURNAME != value)
				{
					_CLMHDR_PATIENT_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_SUBSCR_INITIALS
		{
			get { return _CLMHDR_SUBSCR_INITIALS; }
			set
			{
				if (_CLMHDR_SUBSCR_INITIALS != value)
				{
					_CLMHDR_SUBSCR_INITIALS = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_WCB_CLAIM_NBR
		{
			get { return _CLMHDR_WCB_CLAIM_NBR; }
			set
			{
				if (_CLMHDR_WCB_CLAIM_NBR != value)
				{
					_CLMHDR_WCB_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_WCB_ACCIDENT_DATE
		{
			get { return _CLMHDR_WCB_ACCIDENT_DATE; }
			set
			{
				if (_CLMHDR_WCB_ACCIDENT_DATE != value)
				{
					_CLMHDR_WCB_ACCIDENT_DATE = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_WCB_EMPLOYER_NAME_ADDR
		{
			get { return _CLMHDR_WCB_EMPLOYER_NAME_ADDR; }
			set
			{
				if (_CLMHDR_WCB_EMPLOYER_NAME_ADDR != value)
				{
					_CLMHDR_WCB_EMPLOYER_NAME_ADDR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_WCB_EMPLOYER_POSTAL_CODE
		{
			get { return _CLMHDR_WCB_EMPLOYER_POSTAL_CODE; }
			set
			{
				if (_CLMHDR_WCB_EMPLOYER_POSTAL_CODE != value)
				{
					_CLMHDR_WCB_EMPLOYER_POSTAL_CODE = value;
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
		public decimal? CLMHDR_NBR_SUSPEND_DESC_RECS
		{
			get { return _CLMHDR_NBR_SUSPEND_DESC_RECS; }
			set
			{
				if (_CLMHDR_NBR_SUSPEND_DESC_RECS != value)
				{
					_CLMHDR_NBR_SUSPEND_DESC_RECS = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_OHIP_NBR
		{
			get { return _CLMHDR_DOC_OHIP_NBR; }
			set
			{
				if (_CLMHDR_DOC_OHIP_NBR != value)
				{
					_CLMHDR_DOC_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_ACCOUNTING_NBR
		{
			get { return _CLMHDR_ACCOUNTING_NBR; }
			set
			{
				if (_CLMHDR_ACCOUNTING_NBR != value)
				{
					_CLMHDR_ACCOUNTING_NBR = value;
					ChangeState();
				}
			}
		}
		public string SUSP_HDR_DOC_NBR
		{
			get { return _SUSP_HDR_DOC_NBR; }
			set
			{
				if (_SUSP_HDR_DOC_NBR != value)
				{
					_SUSP_HDR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? SUSP_HDR_CLINIC_NBR
		{
			get { return _SUSP_HDR_CLINIC_NBR; }
			set
			{
				if (_SUSP_HDR_CLINIC_NBR != value)
				{
					_SUSP_HDR_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string SUSP_HDR_ACRONYM
		{
			get { return _SUSP_HDR_ACRONYM; }
			set
			{
				if (_SUSP_HDR_ACRONYM != value)
				{
					_SUSP_HDR_ACRONYM = value;
					ChangeState();
				}
			}
		}
		public string SUSP_HDR_ACCOUNTING_NBR
		{
			get { return _SUSP_HDR_ACCOUNTING_NBR; }
			set
			{
				if (_SUSP_HDR_ACCOUNTING_NBR != value)
				{
					_SUSP_HDR_ACCOUNTING_NBR = value;
					ChangeState();
				}
			}
		}
        public string DEBUG_INFO
        {
            get { return _DEBUG_INFO; }
            set
            {
                if (_DEBUG_INFO != value)
                {
                    _DEBUG_INFO = value;
                    ChangeState();
                }
            }
        }
        public decimal? ERROR_FLAG
        {
            get { return _ERROR_FLAG; }
            set
            {
                if (_ERROR_FLAG != value)
                {
                    _ERROR_FLAG = value;
                    ChangeState();
                }
            }
        }
        public string INPUT_FILE_LOCATION
        {
            get { return _INPUT_FILE_LOCATION; }
            set
            {
                if (_INPUT_FILE_LOCATION != value)
                {
                    _INPUT_FILE_LOCATION = value;
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
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_clinic_nbr_1_2 { get; set; }
		private decimal? _whereClmhdr_clinic_nbr_1_2;
		public string WhereClmhdr_doc_nbr { get; set; }
		private string _whereClmhdr_doc_nbr;
		public decimal? WhereClmhdr_week { get; set; }
		private decimal? _whereClmhdr_week;
		public decimal? WhereClmhdr_day { get; set; }
		private decimal? _whereClmhdr_day;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public string WhereClmhdr_adj_oma_cd { get; set; }
		private string _whereClmhdr_adj_oma_cd;
		public string WhereClmhdr_adj_oma_suff { get; set; }
		private string _whereClmhdr_adj_oma_suff;
		public string WhereClmhdr_adj_adj_nbrf { get; set; }
		private string _whereClmhdr_adj_adj_nbrf;
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
		public string WhereClmhdr_date_cash_tape_payment { get; set; }
		private string _whereClmhdr_date_cash_tape_payment;
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
		public string WhereClmhdr_orig_batch_nbr { get; set; }
		private string _whereClmhdr_orig_batch_nbr;
		public decimal? WhereClmhdr_orig_claim_nbr { get; set; }
		private decimal? _whereClmhdr_orig_claim_nbr;
		public string WhereClmhdr_status { get; set; }
		private string _whereClmhdr_status;
		public string WhereClmhdr_health_care_nbr { get; set; }
		private string _whereClmhdr_health_care_nbr;
		public string WhereClmhdr_health_care_ver { get; set; }
		private string _whereClmhdr_health_care_ver;
		public string WhereClmhdr_health_care_prov { get; set; }
		private string _whereClmhdr_health_care_prov;
		public string WhereClmhdr_relationship { get; set; }
		private string _whereClmhdr_relationship;
		public string WhereClmhdr_patient_surname { get; set; }
		private string _whereClmhdr_patient_surname;
		public string WhereClmhdr_subscr_initials { get; set; }
		private string _whereClmhdr_subscr_initials;
		public string WhereClmhdr_wcb_claim_nbr { get; set; }
		private string _whereClmhdr_wcb_claim_nbr;
		public decimal? WhereClmhdr_wcb_accident_date { get; set; }
		private decimal? _whereClmhdr_wcb_accident_date;
		public string WhereClmhdr_wcb_employer_name_addr { get; set; }
		private string _whereClmhdr_wcb_employer_name_addr;
		public string WhereClmhdr_wcb_employer_postal_code { get; set; }
		private string _whereClmhdr_wcb_employer_postal_code;
		public string WhereClmhdr_confidential_flag { get; set; }
		private string _whereClmhdr_confidential_flag;
		public decimal? WhereClmhdr_nbr_suspend_desc_recs { get; set; }
		private decimal? _whereClmhdr_nbr_suspend_desc_recs;
		public decimal? WhereClmhdr_doc_ohip_nbr { get; set; }
		private decimal? _whereClmhdr_doc_ohip_nbr;
		public string WhereClmhdr_accounting_nbr { get; set; }
		private string _whereClmhdr_accounting_nbr;
		public string WhereSusp_hdr_doc_nbr { get; set; }
		private string _whereSusp_hdr_doc_nbr;
		public decimal? WhereSusp_hdr_clinic_nbr { get; set; }
		private decimal? _whereSusp_hdr_clinic_nbr;
		public string WhereSusp_hdr_acronym { get; set; }
		private string _whereSusp_hdr_acronym;
		public string WhereSusp_hdr_accounting_nbr { get; set; }
		private string _whereSusp_hdr_accounting_nbr;
        public string WhereDebug_info { get; set; }
        private string _whereDebug_info;
        public decimal? WhereError_flag { get; set; }
        private decimal? _whereError_flag;
        public string WhereInput_file_location { get; set; }
        private string _whereInput_file_location;
        public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_clinic_nbr_1_2;
		private string _originalClmhdr_doc_nbr;
		private decimal? _originalClmhdr_week;
		private decimal? _originalClmhdr_day;
		private decimal? _originalClmhdr_claim_nbr;
		private string _originalClmhdr_adj_oma_cd;
		private string _originalClmhdr_adj_oma_suff;
		private string _originalClmhdr_adj_adj_nbrf;
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
		private string _originalClmhdr_date_cash_tape_payment;
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
		private string _originalClmhdr_orig_batch_nbr;
		private decimal? _originalClmhdr_orig_claim_nbr;
		private string _originalClmhdr_status;
		private string _originalClmhdr_health_care_nbr;
		private string _originalClmhdr_health_care_ver;
		private string _originalClmhdr_health_care_prov;
		private string _originalClmhdr_relationship;
		private string _originalClmhdr_patient_surname;
		private string _originalClmhdr_subscr_initials;
		private string _originalClmhdr_wcb_claim_nbr;
		private decimal? _originalClmhdr_wcb_accident_date;
		private string _originalClmhdr_wcb_employer_name_addr;
		private string _originalClmhdr_wcb_employer_postal_code;
		private string _originalClmhdr_confidential_flag;
		private decimal? _originalClmhdr_nbr_suspend_desc_recs;
		private decimal? _originalClmhdr_doc_ohip_nbr;
		private string _originalClmhdr_accounting_nbr;
		private string _originalSusp_hdr_doc_nbr;
		private decimal? _originalSusp_hdr_clinic_nbr;
		private string _originalSusp_hdr_acronym;
		private string _originalSusp_hdr_accounting_nbr;
        private string _originalDebug_info;
        private decimal? _originalError_flag;
        private string _originalInput_file_location;
        private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLINIC_NBR_1_2 = _originalClmhdr_clinic_nbr_1_2;
			CLMHDR_DOC_NBR = _originalClmhdr_doc_nbr;
			CLMHDR_WEEK = _originalClmhdr_week;
			CLMHDR_DAY = _originalClmhdr_day;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			CLMHDR_ADJ_OMA_CD = _originalClmhdr_adj_oma_cd;
			CLMHDR_ADJ_OMA_SUFF = _originalClmhdr_adj_oma_suff;
			CLMHDR_ADJ_ADJ_NBRF = _originalClmhdr_adj_adj_nbrf;
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
			CLMHDR_DATE_CASH_TAPE_PAYMENT = _originalClmhdr_date_cash_tape_payment;
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
			CLMHDR_ORIG_BATCH_NBR = _originalClmhdr_orig_batch_nbr;
			CLMHDR_ORIG_CLAIM_NBR = _originalClmhdr_orig_claim_nbr;
			CLMHDR_STATUS = _originalClmhdr_status;
			CLMHDR_HEALTH_CARE_NBR = _originalClmhdr_health_care_nbr;
			CLMHDR_HEALTH_CARE_VER = _originalClmhdr_health_care_ver;
			CLMHDR_HEALTH_CARE_PROV = _originalClmhdr_health_care_prov;
			CLMHDR_RELATIONSHIP = _originalClmhdr_relationship;
			CLMHDR_PATIENT_SURNAME = _originalClmhdr_patient_surname;
			CLMHDR_SUBSCR_INITIALS = _originalClmhdr_subscr_initials;
			CLMHDR_WCB_CLAIM_NBR = _originalClmhdr_wcb_claim_nbr;
			CLMHDR_WCB_ACCIDENT_DATE = _originalClmhdr_wcb_accident_date;
			CLMHDR_WCB_EMPLOYER_NAME_ADDR = _originalClmhdr_wcb_employer_name_addr;
			CLMHDR_WCB_EMPLOYER_POSTAL_CODE = _originalClmhdr_wcb_employer_postal_code;
			CLMHDR_CONFIDENTIAL_FLAG = _originalClmhdr_confidential_flag;
			CLMHDR_NBR_SUSPEND_DESC_RECS = _originalClmhdr_nbr_suspend_desc_recs;
			CLMHDR_DOC_OHIP_NBR = _originalClmhdr_doc_ohip_nbr;
			CLMHDR_ACCOUNTING_NBR = _originalClmhdr_accounting_nbr;
			SUSP_HDR_DOC_NBR = _originalSusp_hdr_doc_nbr;
			SUSP_HDR_CLINIC_NBR = _originalSusp_hdr_clinic_nbr;
			SUSP_HDR_ACRONYM = _originalSusp_hdr_acronym;
			SUSP_HDR_ACCOUNTING_NBR = _originalSusp_hdr_accounting_nbr;
            DEBUG_INFO = _originalDebug_info;
            ERROR_FLAG = _originalError_flag;
            INPUT_FILE_LOCATION = _originalInput_file_location;
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
					new SqlParameter("CLMHDR_DOC_OHIP_NBR",CLMHDR_DOC_OHIP_NBR),
					new SqlParameter("CLMHDR_ACCOUNTING_NBR",CLMHDR_ACCOUNTING_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_HDR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_SUSPEND_HDR_Purge]");
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
                        new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
                        new SqlParameter("CLMHDR_CLINIC_NBR_1_2", SqlNull(CLMHDR_CLINIC_NBR_1_2)),
                        new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
                        new SqlParameter("CLMHDR_WEEK", SqlNull(CLMHDR_WEEK)),
                        new SqlParameter("CLMHDR_DAY", SqlNull(CLMHDR_DAY)),
                        new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_ADJ_OMA_CD", SqlNull(CLMHDR_ADJ_OMA_CD)),
                        new SqlParameter("CLMHDR_ADJ_OMA_SUFF", SqlNull(CLMHDR_ADJ_OMA_SUFF)),
                        new SqlParameter("CLMHDR_ADJ_ADJ_NBRF", SqlNull(CLMHDR_ADJ_ADJ_NBRF)),
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
                        new SqlParameter("CLMHDR_DATE_CASH_TAPE_PAYMENT", SqlNull(CLMHDR_DATE_CASH_TAPE_PAYMENT)),
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
                        new SqlParameter("CLMHDR_ORIG_BATCH_NBR", SqlNull(CLMHDR_ORIG_BATCH_NBR)),
                        new SqlParameter("CLMHDR_ORIG_CLAIM_NBR", SqlNull(CLMHDR_ORIG_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_STATUS", SqlNull(CLMHDR_STATUS)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_NBR", SqlNull(CLMHDR_HEALTH_CARE_NBR)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_VER", SqlNull(CLMHDR_HEALTH_CARE_VER)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_PROV", SqlNull(CLMHDR_HEALTH_CARE_PROV)),
                        new SqlParameter("CLMHDR_RELATIONSHIP", SqlNull(CLMHDR_RELATIONSHIP)),
                        new SqlParameter("CLMHDR_PATIENT_SURNAME", SqlNull(CLMHDR_PATIENT_SURNAME)),
                        new SqlParameter("CLMHDR_SUBSCR_INITIALS", SqlNull(CLMHDR_SUBSCR_INITIALS)),
                        new SqlParameter("CLMHDR_WCB_CLAIM_NBR", SqlNull(CLMHDR_WCB_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_WCB_ACCIDENT_DATE", SqlNull(CLMHDR_WCB_ACCIDENT_DATE)),
                        new SqlParameter("CLMHDR_WCB_EMPLOYER_NAME_ADDR", SqlNull(CLMHDR_WCB_EMPLOYER_NAME_ADDR)),
                        new SqlParameter("CLMHDR_WCB_EMPLOYER_POSTAL_CODE", SqlNull(CLMHDR_WCB_EMPLOYER_POSTAL_CODE)),
                        new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG", SqlNull(CLMHDR_CONFIDENTIAL_FLAG)),
                        new SqlParameter("CLMHDR_NBR_SUSPEND_DESC_RECS", SqlNull(CLMHDR_NBR_SUSPEND_DESC_RECS)),
                        new SqlParameter("CLMHDR_DOC_OHIP_NBR", SqlNull(CLMHDR_DOC_OHIP_NBR)),
                        new SqlParameter("CLMHDR_ACCOUNTING_NBR", SqlNull(CLMHDR_ACCOUNTING_NBR)),
                        new SqlParameter("SUSP_HDR_DOC_NBR", SqlNull(SUSP_HDR_DOC_NBR)),
                        new SqlParameter("SUSP_HDR_CLINIC_NBR", SqlNull(SUSP_HDR_CLINIC_NBR)),
                        new SqlParameter("SUSP_HDR_ACRONYM", SqlNull(SUSP_HDR_ACRONYM)),
                        new SqlParameter("SUSP_HDR_ACCOUNTING_NBR", SqlNull(SUSP_HDR_ACCOUNTING_NBR)),
                        new SqlParameter("DEBUG_INFO", SqlNull(DEBUG_INFO)),
                        new SqlParameter("ERROR_FLAG", SqlNull(ERROR_FLAG)),
                        new SqlParameter("INPUT_FILE_LOCATION", SqlNull(INPUT_FILE_LOCATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_HDR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_WEEK = ConvertDEC(Reader["CLMHDR_WEEK"]);
						CLMHDR_DAY = ConvertDEC(Reader["CLMHDR_DAY"]);
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						CLMHDR_ADJ_ADJ_NBRF = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString();
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
						CLMHDR_DATE_CASH_TAPE_PAYMENT = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString();
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
						CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						CLMHDR_STATUS = Reader["CLMHDR_STATUS"].ToString();
						CLMHDR_HEALTH_CARE_NBR = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString();
						CLMHDR_HEALTH_CARE_VER = Reader["CLMHDR_HEALTH_CARE_VER"].ToString();
						CLMHDR_HEALTH_CARE_PROV = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString();
						CLMHDR_RELATIONSHIP = Reader["CLMHDR_RELATIONSHIP"].ToString();
						CLMHDR_PATIENT_SURNAME = Reader["CLMHDR_PATIENT_SURNAME"].ToString();
						CLMHDR_SUBSCR_INITIALS = Reader["CLMHDR_SUBSCR_INITIALS"].ToString();
						CLMHDR_WCB_CLAIM_NBR = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString();
						CLMHDR_WCB_ACCIDENT_DATE = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]);
						CLMHDR_WCB_EMPLOYER_NAME_ADDR = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString();
						CLMHDR_WCB_EMPLOYER_POSTAL_CODE = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString();
						CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						CLMHDR_NBR_SUSPEND_DESC_RECS = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]);
						CLMHDR_DOC_OHIP_NBR = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]);
						CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						SUSP_HDR_DOC_NBR = Reader["SUSP_HDR_DOC_NBR"].ToString();
						SUSP_HDR_CLINIC_NBR = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]);
						SUSP_HDR_ACRONYM = Reader["SUSP_HDR_ACRONYM"].ToString();
						SUSP_HDR_ACCOUNTING_NBR = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString();
                        DEBUG_INFO = Reader["DEBUG_INFO"].ToString();
                        ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]);
                        INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_week = ConvertDEC(Reader["CLMHDR_WEEK"]);
						_originalClmhdr_day = ConvertDEC(Reader["CLMHDR_DAY"]);
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						_originalClmhdr_adj_adj_nbrf = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString();
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
						_originalClmhdr_date_cash_tape_payment = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString();
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
						_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						_originalClmhdr_status = Reader["CLMHDR_STATUS"].ToString();
						_originalClmhdr_health_care_nbr = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString();
						_originalClmhdr_health_care_ver = Reader["CLMHDR_HEALTH_CARE_VER"].ToString();
						_originalClmhdr_health_care_prov = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString();
						_originalClmhdr_relationship = Reader["CLMHDR_RELATIONSHIP"].ToString();
						_originalClmhdr_patient_surname = Reader["CLMHDR_PATIENT_SURNAME"].ToString();
						_originalClmhdr_subscr_initials = Reader["CLMHDR_SUBSCR_INITIALS"].ToString();
						_originalClmhdr_wcb_claim_nbr = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString();
						_originalClmhdr_wcb_accident_date = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]);
						_originalClmhdr_wcb_employer_name_addr = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString();
						_originalClmhdr_wcb_employer_postal_code = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString();
						_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						_originalClmhdr_nbr_suspend_desc_recs = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]);
						_originalClmhdr_doc_ohip_nbr = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]);
						_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						_originalSusp_hdr_doc_nbr = Reader["SUSP_HDR_DOC_NBR"].ToString();
						_originalSusp_hdr_clinic_nbr = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]);
						_originalSusp_hdr_acronym = Reader["SUSP_HDR_ACRONYM"].ToString();
						_originalSusp_hdr_accounting_nbr = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString();
                        _originalDebug_info = Reader["DEBUG_INFO"].ToString();
                        _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]);
                        _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RowCheckSum",RowCheckSum),
                        new SqlParameter("ROWID", ROWID),
                        new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
                        new SqlParameter("CLMHDR_CLINIC_NBR_1_2", SqlNull(CLMHDR_CLINIC_NBR_1_2)),
                        new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
                        new SqlParameter("CLMHDR_WEEK", SqlNull(CLMHDR_WEEK)),
                        new SqlParameter("CLMHDR_DAY", SqlNull(CLMHDR_DAY)),
                        new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_ADJ_OMA_CD", SqlNull(CLMHDR_ADJ_OMA_CD)),
                        new SqlParameter("CLMHDR_ADJ_OMA_SUFF", SqlNull(CLMHDR_ADJ_OMA_SUFF)),
                        new SqlParameter("CLMHDR_ADJ_ADJ_NBRF", SqlNull(CLMHDR_ADJ_ADJ_NBRF)),
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
                        new SqlParameter("CLMHDR_DATE_CASH_TAPE_PAYMENT", SqlNull(CLMHDR_DATE_CASH_TAPE_PAYMENT)),
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
                        new SqlParameter("CLMHDR_ORIG_BATCH_NBR", SqlNull(CLMHDR_ORIG_BATCH_NBR)),
                        new SqlParameter("CLMHDR_ORIG_CLAIM_NBR", SqlNull(CLMHDR_ORIG_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_STATUS", SqlNull(CLMHDR_STATUS)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_NBR", SqlNull(CLMHDR_HEALTH_CARE_NBR)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_VER", SqlNull(CLMHDR_HEALTH_CARE_VER)),
                        new SqlParameter("CLMHDR_HEALTH_CARE_PROV", SqlNull(CLMHDR_HEALTH_CARE_PROV)),
                        new SqlParameter("CLMHDR_RELATIONSHIP", SqlNull(CLMHDR_RELATIONSHIP)),
                        new SqlParameter("CLMHDR_PATIENT_SURNAME", SqlNull(CLMHDR_PATIENT_SURNAME)),
                        new SqlParameter("CLMHDR_SUBSCR_INITIALS", SqlNull(CLMHDR_SUBSCR_INITIALS)),
                        new SqlParameter("CLMHDR_WCB_CLAIM_NBR", SqlNull(CLMHDR_WCB_CLAIM_NBR)),
                        new SqlParameter("CLMHDR_WCB_ACCIDENT_DATE", SqlNull(CLMHDR_WCB_ACCIDENT_DATE)),
                        new SqlParameter("CLMHDR_WCB_EMPLOYER_NAME_ADDR", SqlNull(CLMHDR_WCB_EMPLOYER_NAME_ADDR)),
                        new SqlParameter("CLMHDR_WCB_EMPLOYER_POSTAL_CODE", SqlNull(CLMHDR_WCB_EMPLOYER_POSTAL_CODE)),
                        new SqlParameter("CLMHDR_CONFIDENTIAL_FLAG", SqlNull(CLMHDR_CONFIDENTIAL_FLAG)),
                        new SqlParameter("CLMHDR_NBR_SUSPEND_DESC_RECS", SqlNull(CLMHDR_NBR_SUSPEND_DESC_RECS)),
                        new SqlParameter("CLMHDR_DOC_OHIP_NBR", SqlNull(CLMHDR_DOC_OHIP_NBR)),
                        new SqlParameter("CLMHDR_ACCOUNTING_NBR", SqlNull(CLMHDR_ACCOUNTING_NBR)),
                        new SqlParameter("SUSP_HDR_DOC_NBR", SqlNull(SUSP_HDR_DOC_NBR)),
                        new SqlParameter("SUSP_HDR_CLINIC_NBR", SqlNull(SUSP_HDR_CLINIC_NBR)),
                        new SqlParameter("SUSP_HDR_ACRONYM", SqlNull(SUSP_HDR_ACRONYM)),
                        new SqlParameter("SUSP_HDR_ACCOUNTING_NBR", SqlNull(SUSP_HDR_ACCOUNTING_NBR)),
                        new SqlParameter("DEBUG_INFO", SqlNull(DEBUG_INFO)),
                        new SqlParameter("ERROR_FLAG", SqlNull(ERROR_FLAG)),
                        new SqlParameter("INPUT_FILE_LOCATION", SqlNull(INPUT_FILE_LOCATION)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F002_SUSPEND_HDR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLINIC_NBR_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						CLMHDR_WEEK = ConvertDEC(Reader["CLMHDR_WEEK"]);
						CLMHDR_DAY = ConvertDEC(Reader["CLMHDR_DAY"]);
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						CLMHDR_ADJ_OMA_CD = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						CLMHDR_ADJ_OMA_SUFF = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						CLMHDR_ADJ_ADJ_NBRF = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString();
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
						CLMHDR_DATE_CASH_TAPE_PAYMENT = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString();
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
						CLMHDR_ORIG_BATCH_NBR = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						CLMHDR_ORIG_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						CLMHDR_STATUS = Reader["CLMHDR_STATUS"].ToString();
						CLMHDR_HEALTH_CARE_NBR = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString();
						CLMHDR_HEALTH_CARE_VER = Reader["CLMHDR_HEALTH_CARE_VER"].ToString();
						CLMHDR_HEALTH_CARE_PROV = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString();
						CLMHDR_RELATIONSHIP = Reader["CLMHDR_RELATIONSHIP"].ToString();
						CLMHDR_PATIENT_SURNAME = Reader["CLMHDR_PATIENT_SURNAME"].ToString();
						CLMHDR_SUBSCR_INITIALS = Reader["CLMHDR_SUBSCR_INITIALS"].ToString();
						CLMHDR_WCB_CLAIM_NBR = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString();
						CLMHDR_WCB_ACCIDENT_DATE = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]);
						CLMHDR_WCB_EMPLOYER_NAME_ADDR = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString();
						CLMHDR_WCB_EMPLOYER_POSTAL_CODE = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString();
						CLMHDR_CONFIDENTIAL_FLAG = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						CLMHDR_NBR_SUSPEND_DESC_RECS = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]);
						CLMHDR_DOC_OHIP_NBR = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]);
						CLMHDR_ACCOUNTING_NBR = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						SUSP_HDR_DOC_NBR = Reader["SUSP_HDR_DOC_NBR"].ToString();
						SUSP_HDR_CLINIC_NBR = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]);
						SUSP_HDR_ACRONYM = Reader["SUSP_HDR_ACRONYM"].ToString();
						SUSP_HDR_ACCOUNTING_NBR = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString();
                        DEBUG_INFO = Reader["DEBUG_INFO"].ToString();
                        ERROR_FLAG = ConvertDEC(Reader["ERROR_FLAG"]);
                        INPUT_FILE_LOCATION = Reader["INPUT_FILE_LOCATION"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_clinic_nbr_1_2 = ConvertDEC(Reader["CLMHDR_CLINIC_NBR_1_2"]);
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalClmhdr_week = ConvertDEC(Reader["CLMHDR_WEEK"]);
						_originalClmhdr_day = ConvertDEC(Reader["CLMHDR_DAY"]);
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalClmhdr_adj_oma_cd = Reader["CLMHDR_ADJ_OMA_CD"].ToString();
						_originalClmhdr_adj_oma_suff = Reader["CLMHDR_ADJ_OMA_SUFF"].ToString();
						_originalClmhdr_adj_adj_nbrf = Reader["CLMHDR_ADJ_ADJ_NBRF"].ToString();
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
						_originalClmhdr_date_cash_tape_payment = Reader["CLMHDR_DATE_CASH_TAPE_PAYMENT"].ToString();
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
						_originalClmhdr_orig_batch_nbr = Reader["CLMHDR_ORIG_BATCH_NBR"].ToString();
						_originalClmhdr_orig_claim_nbr = ConvertDEC(Reader["CLMHDR_ORIG_CLAIM_NBR"]);
						_originalClmhdr_status = Reader["CLMHDR_STATUS"].ToString();
						_originalClmhdr_health_care_nbr = Reader["CLMHDR_HEALTH_CARE_NBR"].ToString();
						_originalClmhdr_health_care_ver = Reader["CLMHDR_HEALTH_CARE_VER"].ToString();
						_originalClmhdr_health_care_prov = Reader["CLMHDR_HEALTH_CARE_PROV"].ToString();
						_originalClmhdr_relationship = Reader["CLMHDR_RELATIONSHIP"].ToString();
						_originalClmhdr_patient_surname = Reader["CLMHDR_PATIENT_SURNAME"].ToString();
						_originalClmhdr_subscr_initials = Reader["CLMHDR_SUBSCR_INITIALS"].ToString();
						_originalClmhdr_wcb_claim_nbr = Reader["CLMHDR_WCB_CLAIM_NBR"].ToString();
						_originalClmhdr_wcb_accident_date = ConvertDEC(Reader["CLMHDR_WCB_ACCIDENT_DATE"]);
						_originalClmhdr_wcb_employer_name_addr = Reader["CLMHDR_WCB_EMPLOYER_NAME_ADDR"].ToString();
						_originalClmhdr_wcb_employer_postal_code = Reader["CLMHDR_WCB_EMPLOYER_POSTAL_CODE"].ToString();
						_originalClmhdr_confidential_flag = Reader["CLMHDR_CONFIDENTIAL_FLAG"].ToString();
						_originalClmhdr_nbr_suspend_desc_recs = ConvertDEC(Reader["CLMHDR_NBR_SUSPEND_DESC_RECS"]);
						_originalClmhdr_doc_ohip_nbr = ConvertDEC(Reader["CLMHDR_DOC_OHIP_NBR"]);
						_originalClmhdr_accounting_nbr = Reader["CLMHDR_ACCOUNTING_NBR"].ToString();
						_originalSusp_hdr_doc_nbr = Reader["SUSP_HDR_DOC_NBR"].ToString();
						_originalSusp_hdr_clinic_nbr = ConvertDEC(Reader["SUSP_HDR_CLINIC_NBR"]);
						_originalSusp_hdr_acronym = Reader["SUSP_HDR_ACRONYM"].ToString();
						_originalSusp_hdr_accounting_nbr = Reader["SUSP_HDR_ACCOUNTING_NBR"].ToString();
                        _originalDebug_info = Reader["DEBUG_INFO"].ToString();
                        _originalError_flag = ConvertDEC(Reader["ERROR_FLAG"]);
                        _originalInput_file_location = Reader["INPUT_FILE_LOCATION"].ToString();
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