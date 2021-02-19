using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_DOCTOR_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_DOCTOR_MSTR> Collection(Guid? rowid,
                                                            string doc_nbr,
                                                            decimal? doc_deptmin,
                                                            decimal? doc_deptmax,
                                                            decimal? doc_ohip_nbrmin,
                                                            decimal? doc_ohip_nbrmax,
                                                            decimal? doc_sin_123min,
                                                            decimal? doc_sin_123max,
                                                            decimal? doc_sin_456min,
                                                            decimal? doc_sin_456max,
                                                            decimal? doc_sin_789min,
                                                            decimal? doc_sin_789max,
                                                            decimal? doc_spec_cdmin,
                                                            decimal? doc_spec_cdmax,
                                                            string doc_hosp_nbr,
                                                            string doc_name,
                                                            string doc_name_soundex,
                                                            string doc_init1,
                                                            string doc_init2,
                                                            string doc_init3,
                                                            string doc_addr_office_1,
                                                            string doc_addr_office_2,
                                                            string doc_addr_office_3,
                                                            string doc_addr_office_pc1,
                                                            decimal? doc_addr_office_pc2min,
                                                            decimal? doc_addr_office_pc2max,
                                                            string doc_addr_office_pc3,
                                                            decimal? doc_addr_office_pc4min,
                                                            decimal? doc_addr_office_pc4max,
                                                            string doc_addr_office_pc5,
                                                            decimal? doc_addr_office_pc6min,
                                                            decimal? doc_addr_office_pc6max,
                                                            string doc_addr_home_1,
                                                            string doc_addr_home_2,
                                                            string doc_addr_home_3,
                                                            string doc_addr_home_pc1,
                                                            decimal? doc_addr_home_pc2min,
                                                            decimal? doc_addr_home_pc2max,
                                                            string doc_addr_home_pc3,
                                                            decimal? doc_addr_home_pc4min,
                                                            decimal? doc_addr_home_pc4max,
                                                            string doc_addr_home_pc5,
                                                            decimal? doc_addr_home_pc6min,
                                                            decimal? doc_addr_home_pc6max,
                                                            string doc_full_part_ind,
                                                            decimal? doc_bank_nbrmin,
                                                            decimal? doc_bank_nbrmax,
                                                            decimal? doc_bank_branchmin,
                                                            decimal? doc_bank_branchmax,
                                                            string doc_bank_acct,
                                                            decimal? doc_date_fac_start_yymin,
                                                            decimal? doc_date_fac_start_yymax,
                                                            decimal? doc_date_fac_start_mmmin,
                                                            decimal? doc_date_fac_start_mmmax,
                                                            decimal? doc_date_fac_start_ddmin,
                                                            decimal? doc_date_fac_start_ddmax,
                                                            decimal? doc_date_fac_term_yymin,
                                                            decimal? doc_date_fac_term_yymax,
                                                            decimal? doc_date_fac_term_mmmin,
                                                            decimal? doc_date_fac_term_mmmax,
                                                            decimal? doc_date_fac_term_ddmin,
                                                            decimal? doc_date_fac_term_ddmax,
                                                            decimal? doc_ytdguamin,
                                                            decimal? doc_ytdguamax,
                                                            decimal? doc_ytdgubmin,
                                                            decimal? doc_ytdgubmax,
                                                            decimal? doc_ytdgucmin,
                                                            decimal? doc_ytdgucmax,
                                                            decimal? doc_ytdgudmin,
                                                            decimal? doc_ytdgudmax,
                                                            decimal? doc_ytdceamin,
                                                            decimal? doc_ytdceamax,
                                                            decimal? doc_ytdcexmin,
                                                            decimal? doc_ytdcexmax,
                                                            decimal? doc_ytdearmin,
                                                            decimal? doc_ytdearmax,
                                                            decimal? doc_ytdincmin,
                                                            decimal? doc_ytdincmax,
                                                            decimal? doc_ytdeftmin,
                                                            decimal? doc_ytdeftmax,
                                                            decimal? doc_totinc_gmin,
                                                            decimal? doc_totinc_gmax,
                                                            decimal? doc_ep_date_depositmin,
                                                            decimal? doc_ep_date_depositmax,
                                                            decimal? doc_totincmin,
                                                            decimal? doc_totincmax,
                                                            decimal? doc_ep_ceiexpmin,
                                                            decimal? doc_ep_ceiexpmax,
                                                            decimal? doc_adjceamin,
                                                            decimal? doc_adjceamax,
                                                            decimal? doc_adjcexmin,
                                                            decimal? doc_adjcexmax,
                                                            decimal? doc_ceiceamin,
                                                            decimal? doc_ceiceamax,
                                                            decimal? doc_ceicexmin,
                                                            decimal? doc_ceicexmax,
                                                            string ceicea_prt_format,
                                                            string ceicex_prt_format,
                                                            string ytdcea_prt_format,
                                                            string ytdcex_prt_format,
                                                            decimal? doc_spec_cd_2min,
                                                            decimal? doc_spec_cd_2max,
                                                            decimal? doc_spec_cd_3min,
                                                            decimal? doc_spec_cd_3max,
                                                            decimal? doc_ytdinc_gmin,
                                                            decimal? doc_ytdinc_gmax,
                                                            long? doc_rma_expense_percent_miscmin,
                                                            long? doc_rma_expense_percent_miscmax,
                                                            string doc_afp_paym_group,
                                                            decimal? doc_dept_2min,
                                                            decimal? doc_dept_2max,
                                                            string doc_ind_pays_gst,
                                                            decimal? doc_nx_avail_batchmin,
                                                            decimal? doc_nx_avail_batchmax,
                                                            decimal? doc_nx_avail_batch_2min,
                                                            decimal? doc_nx_avail_batch_2max,
                                                            decimal? doc_nx_avail_batch_3min,
                                                            decimal? doc_nx_avail_batch_3max,
                                                            decimal? doc_nx_avail_batch_4min,
                                                            decimal? doc_nx_avail_batch_4max,
                                                            decimal? doc_nx_avail_batch_5min,
                                                            decimal? doc_nx_avail_batch_5max,
                                                            decimal? doc_nx_avail_batch_6min,
                                                            decimal? doc_nx_avail_batch_6max,
                                                            decimal? doc_yrly_ceiling_computedmin,
                                                            decimal? doc_yrly_ceiling_computedmax,
                                                            decimal? doc_yrly_expense_computedmin,
                                                            decimal? doc_yrly_expense_computedmax,
                                                            long? doc_rma_expense_percent_regmin,
                                                            long? doc_rma_expense_percent_regmax,
                                                            string doc_sub_specialty,
                                                            decimal? doc_payeftmin,
                                                            decimal? doc_payeftmax,
                                                            decimal? doc_ytddedmin,
                                                            decimal? doc_ytddedmax,
                                                            long? doc_dept_expense_percent_miscmin,
                                                            long? doc_dept_expense_percent_miscmax,
                                                            long? doc_dept_expense_percent_regmin,
                                                            long? doc_dept_expense_percent_regmax,
                                                            long? doc_ep_pedmin,
                                                            long? doc_ep_pedmax,
                                                            string doc_ep_pay_code,
                                                            string doc_ep_pay_sub_code,
                                                            string doc_partnership,
                                                            string doc_ind_holdback_active,
                                                            string group_regular_service,
                                                            string group_over_serviced,
                                                            string doc_loc_1_s1,
                                                            string doc_loc_1_s2,
                                                            string doc_loc_1_s3,
                                                            string doc_loc_2_s1,
                                                            string doc_loc_2_s2,
                                                            string doc_loc_2_s3,
                                                            string doc_loc_3_s1,
                                                            string doc_loc_3_s2,
                                                            string doc_loc_3_s3,
                                                            string doc_loc_4_s1,
                                                            string doc_loc_4_s2,
                                                            string doc_loc_4_s3,
                                                            string doc_loc_5_s1,
                                                            string doc_loc_5_s2,
                                                            string doc_loc_5_s3,
                                                            string doc_loc_6_s1,
                                                            string doc_loc_6_s2,
                                                            string doc_loc_6_s3,
                                                            string doc_loc_7_s1,
                                                            string doc_loc_7_s2,
                                                            string doc_loc_7_s3,
                                                            string doc_loc_8_s1,
                                                            string doc_loc_8_s2,
                                                            string doc_loc_8_s3,
                                                            string doc_loc_9_s1,
                                                            string doc_loc_9_s2,
                                                            string doc_loc_9_s3,
                                                            string doc_loc_10_s1,
                                                            string doc_loc_10_s2,
                                                            string doc_loc_10_s3,
                                                            string doc_loc_11_s1,
                                                            string doc_loc_11_s2,
                                                            string doc_loc_11_s3,
                                                            string doc_loc_12_s1,
                                                            string doc_loc_12_s2,
                                                            string doc_loc_12_s3,
                                                            string doc_loc_13_s1,
                                                            string doc_loc_13_s2,
                                                            string doc_loc_13_s3,
                                                            string doc_loc_14_s1,
                                                            string doc_loc_14_s2,
                                                            string doc_loc_14_s3,
                                                            string doc_loc_15_s1,
                                                            string doc_loc_15_s2,
                                                            string doc_loc_15_s3,
                                                            string doc_loc_16_s1,
                                                            string doc_loc_16_s2,
                                                            string doc_loc_16_s3,
                                                            string doc_loc_17_s1,
                                                            string doc_loc_17_s2,
                                                            string doc_loc_17_s3,
                                                            string doc_loc_18_s1,
                                                            string doc_loc_18_s2,
                                                            string doc_loc_18_s3,
                                                            string doc_loc_19_s1,
                                                            string doc_loc_19_s2,
                                                            string doc_loc_19_s3,
                                                            string doc_loc_20_s1,
                                                            string doc_loc_20_s2,
                                                            string doc_loc_20_s3,
                                                            string doc_loc_21_s1,
                                                            string doc_loc_21_s2,
                                                            string doc_loc_21_s3,
                                                            string doc_loc_22_s1,
                                                            string doc_loc_22_s2,
                                                            string doc_loc_22_s3,
                                                            string doc_loc_23_s1,
                                                            string doc_loc_23_s2,
                                                            string doc_loc_23_s3,
                                                            string doc_loc_24_s1,
                                                            string doc_loc_24_s2,
                                                            string doc_loc_24_s3,
                                                            string doc_loc_25_s1,
                                                            string doc_loc_25_s2,
                                                            string doc_loc_25_s3,
                                                            string doc_loc_26_s1,
                                                            string doc_loc_26_s2,
                                                            string doc_loc_26_s3,
                                                            string doc_loc_27_s1,
                                                            string doc_loc_27_s2,
                                                            string doc_loc_27_s3,
                                                            string doc_loc_28_s1,
                                                            string doc_loc_28_s2,
                                                            string doc_loc_28_s3,
                                                            string doc_loc_29_s1,
                                                            string doc_loc_29_s2,
                                                            string doc_loc_29_s3,
                                                            string doc_loc_30_s1,
                                                            string doc_loc_30_s2,
                                                            string doc_loc_30_s3,
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
                    new SqlParameter("DOC_NBR",doc_nbr),
                    new SqlParameter("minDOC_DEPT",doc_deptmin),
                    new SqlParameter("maxDOC_DEPT",doc_deptmax),
                    new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
                    new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
                    new SqlParameter("minDOC_SIN_123",doc_sin_123min),
                    new SqlParameter("maxDOC_SIN_123",doc_sin_123max),
                    new SqlParameter("minDOC_SIN_456",doc_sin_456min),
                    new SqlParameter("maxDOC_SIN_456",doc_sin_456max),
                    new SqlParameter("minDOC_SIN_789",doc_sin_789min),
                    new SqlParameter("maxDOC_SIN_789",doc_sin_789max),
                    new SqlParameter("minDOC_SPEC_CD",doc_spec_cdmin),
                    new SqlParameter("maxDOC_SPEC_CD",doc_spec_cdmax),
                    new SqlParameter("DOC_HOSP_NBR",doc_hosp_nbr),
                    new SqlParameter("DOC_NAME",doc_name),
                    new SqlParameter("DOC_NAME_SOUNDEX",doc_name_soundex),
                    new SqlParameter("DOC_INIT1",doc_init1),
                    new SqlParameter("DOC_INIT2",doc_init2),
                    new SqlParameter("DOC_INIT3",doc_init3),
                    new SqlParameter("DOC_ADDR_OFFICE_1",doc_addr_office_1),
                    new SqlParameter("DOC_ADDR_OFFICE_2",doc_addr_office_2),
                    new SqlParameter("DOC_ADDR_OFFICE_3",doc_addr_office_3),
                    new SqlParameter("DOC_ADDR_OFFICE_PC1",doc_addr_office_pc1),
                    new SqlParameter("minDOC_ADDR_OFFICE_PC2",doc_addr_office_pc2min),
                    new SqlParameter("maxDOC_ADDR_OFFICE_PC2",doc_addr_office_pc2max),
                    new SqlParameter("DOC_ADDR_OFFICE_PC3",doc_addr_office_pc3),
                    new SqlParameter("minDOC_ADDR_OFFICE_PC4",doc_addr_office_pc4min),
                    new SqlParameter("maxDOC_ADDR_OFFICE_PC4",doc_addr_office_pc4max),
                    new SqlParameter("DOC_ADDR_OFFICE_PC5",doc_addr_office_pc5),
                    new SqlParameter("minDOC_ADDR_OFFICE_PC6",doc_addr_office_pc6min),
                    new SqlParameter("maxDOC_ADDR_OFFICE_PC6",doc_addr_office_pc6max),
                    new SqlParameter("DOC_ADDR_HOME_1",doc_addr_home_1),
                    new SqlParameter("DOC_ADDR_HOME_2",doc_addr_home_2),
                    new SqlParameter("DOC_ADDR_HOME_3",doc_addr_home_3),
                    new SqlParameter("DOC_ADDR_HOME_PC1",doc_addr_home_pc1),
                    new SqlParameter("minDOC_ADDR_HOME_PC2",doc_addr_home_pc2min),
                    new SqlParameter("maxDOC_ADDR_HOME_PC2",doc_addr_home_pc2max),
                    new SqlParameter("DOC_ADDR_HOME_PC3",doc_addr_home_pc3),
                    new SqlParameter("minDOC_ADDR_HOME_PC4",doc_addr_home_pc4min),
                    new SqlParameter("maxDOC_ADDR_HOME_PC4",doc_addr_home_pc4max),
                    new SqlParameter("DOC_ADDR_HOME_PC5",doc_addr_home_pc5),
                    new SqlParameter("minDOC_ADDR_HOME_PC6",doc_addr_home_pc6min),
                    new SqlParameter("maxDOC_ADDR_HOME_PC6",doc_addr_home_pc6max),
                    new SqlParameter("DOC_FULL_PART_IND",doc_full_part_ind),
                    new SqlParameter("minDOC_BANK_NBR",doc_bank_nbrmin),
                    new SqlParameter("maxDOC_BANK_NBR",doc_bank_nbrmax),
                    new SqlParameter("minDOC_BANK_BRANCH",doc_bank_branchmin),
                    new SqlParameter("maxDOC_BANK_BRANCH",doc_bank_branchmax),
                    new SqlParameter("DOC_BANK_ACCT",doc_bank_acct),
                    new SqlParameter("minDOC_DATE_FAC_START_YY",doc_date_fac_start_yymin),
                    new SqlParameter("maxDOC_DATE_FAC_START_YY",doc_date_fac_start_yymax),
                    new SqlParameter("minDOC_DATE_FAC_START_MM",doc_date_fac_start_mmmin),
                    new SqlParameter("maxDOC_DATE_FAC_START_MM",doc_date_fac_start_mmmax),
                    new SqlParameter("minDOC_DATE_FAC_START_DD",doc_date_fac_start_ddmin),
                    new SqlParameter("maxDOC_DATE_FAC_START_DD",doc_date_fac_start_ddmax),
                    new SqlParameter("minDOC_DATE_FAC_TERM_YY",doc_date_fac_term_yymin),
                    new SqlParameter("maxDOC_DATE_FAC_TERM_YY",doc_date_fac_term_yymax),
                    new SqlParameter("minDOC_DATE_FAC_TERM_MM",doc_date_fac_term_mmmin),
                    new SqlParameter("maxDOC_DATE_FAC_TERM_MM",doc_date_fac_term_mmmax),
                    new SqlParameter("minDOC_DATE_FAC_TERM_DD",doc_date_fac_term_ddmin),
                    new SqlParameter("maxDOC_DATE_FAC_TERM_DD",doc_date_fac_term_ddmax),
                    new SqlParameter("minDOC_YTDGUA",doc_ytdguamin),
                    new SqlParameter("maxDOC_YTDGUA",doc_ytdguamax),
                    new SqlParameter("minDOC_YTDGUB",doc_ytdgubmin),
                    new SqlParameter("maxDOC_YTDGUB",doc_ytdgubmax),
                    new SqlParameter("minDOC_YTDGUC",doc_ytdgucmin),
                    new SqlParameter("maxDOC_YTDGUC",doc_ytdgucmax),
                    new SqlParameter("minDOC_YTDGUD",doc_ytdgudmin),
                    new SqlParameter("maxDOC_YTDGUD",doc_ytdgudmax),
                    new SqlParameter("minDOC_YTDCEA",doc_ytdceamin),
                    new SqlParameter("maxDOC_YTDCEA",doc_ytdceamax),
                    new SqlParameter("minDOC_YTDCEX",doc_ytdcexmin),
                    new SqlParameter("maxDOC_YTDCEX",doc_ytdcexmax),
                    new SqlParameter("minDOC_YTDEAR",doc_ytdearmin),
                    new SqlParameter("maxDOC_YTDEAR",doc_ytdearmax),
                    new SqlParameter("minDOC_YTDINC",doc_ytdincmin),
                    new SqlParameter("maxDOC_YTDINC",doc_ytdincmax),
                    new SqlParameter("minDOC_YTDEFT",doc_ytdeftmin),
                    new SqlParameter("maxDOC_YTDEFT",doc_ytdeftmax),
                    new SqlParameter("minDOC_TOTINC_G",doc_totinc_gmin),
                    new SqlParameter("maxDOC_TOTINC_G",doc_totinc_gmax),
                    new SqlParameter("minDOC_EP_DATE_DEPOSIT",doc_ep_date_depositmin),
                    new SqlParameter("maxDOC_EP_DATE_DEPOSIT",doc_ep_date_depositmax),
                    new SqlParameter("minDOC_TOTINC",doc_totincmin),
                    new SqlParameter("maxDOC_TOTINC",doc_totincmax),
                    new SqlParameter("minDOC_EP_CEIEXP",doc_ep_ceiexpmin),
                    new SqlParameter("maxDOC_EP_CEIEXP",doc_ep_ceiexpmax),
                    new SqlParameter("minDOC_ADJCEA",doc_adjceamin),
                    new SqlParameter("maxDOC_ADJCEA",doc_adjceamax),
                    new SqlParameter("minDOC_ADJCEX",doc_adjcexmin),
                    new SqlParameter("maxDOC_ADJCEX",doc_adjcexmax),
                    new SqlParameter("minDOC_CEICEA",doc_ceiceamin),
                    new SqlParameter("maxDOC_CEICEA",doc_ceiceamax),
                    new SqlParameter("minDOC_CEICEX",doc_ceicexmin),
                    new SqlParameter("maxDOC_CEICEX",doc_ceicexmax),
                    new SqlParameter("CEICEA_PRT_FORMAT",ceicea_prt_format),
                    new SqlParameter("CEICEX_PRT_FORMAT",ceicex_prt_format),
                    new SqlParameter("YTDCEA_PRT_FORMAT",ytdcea_prt_format),
                    new SqlParameter("YTDCEX_PRT_FORMAT",ytdcex_prt_format),
                    new SqlParameter("minDOC_SPEC_CD_2",doc_spec_cd_2min),
                    new SqlParameter("maxDOC_SPEC_CD_2",doc_spec_cd_2max),
                    new SqlParameter("minDOC_SPEC_CD_3",doc_spec_cd_3min),
                    new SqlParameter("maxDOC_SPEC_CD_3",doc_spec_cd_3max),
                    new SqlParameter("minDOC_YTDINC_G",doc_ytdinc_gmin),
                    new SqlParameter("maxDOC_YTDINC_G",doc_ytdinc_gmax),
                    new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmin),
                    new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmax),
                    new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
                    new SqlParameter("minDOC_DEPT_2",doc_dept_2min),
                    new SqlParameter("maxDOC_DEPT_2",doc_dept_2max),
                    new SqlParameter("DOC_IND_PAYS_GST",doc_ind_pays_gst),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH",doc_nx_avail_batchmin),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH",doc_nx_avail_batchmax),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH_2",doc_nx_avail_batch_2min),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH_2",doc_nx_avail_batch_2max),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH_3",doc_nx_avail_batch_3min),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH_3",doc_nx_avail_batch_3max),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH_4",doc_nx_avail_batch_4min),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH_4",doc_nx_avail_batch_4max),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH_5",doc_nx_avail_batch_5min),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH_5",doc_nx_avail_batch_5max),
                    new SqlParameter("minDOC_NX_AVAIL_BATCH_6",doc_nx_avail_batch_6min),
                    new SqlParameter("maxDOC_NX_AVAIL_BATCH_6",doc_nx_avail_batch_6max),
                    new SqlParameter("minDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmin),
                    new SqlParameter("maxDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmax),
                    new SqlParameter("minDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmin),
                    new SqlParameter("maxDOC_YRLY_EXPENSE_COMPUTED",doc_yrly_expense_computedmax),
                    new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmin),
                    new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_REG",doc_rma_expense_percent_regmax),
                    new SqlParameter("DOC_SUB_SPECIALTY",doc_sub_specialty),
                    new SqlParameter("minDOC_PAYEFT",doc_payeftmin),
                    new SqlParameter("maxDOC_PAYEFT",doc_payeftmax),
                    new SqlParameter("minDOC_YTDDED",doc_ytddedmin),
                    new SqlParameter("maxDOC_YTDDED",doc_ytddedmax),
                    new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmin),
                    new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_MISC",doc_dept_expense_percent_miscmax),
                    new SqlParameter("minDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmin),
                    new SqlParameter("maxDOC_DEPT_EXPENSE_PERCENT_REG",doc_dept_expense_percent_regmax),
                    new SqlParameter("minDOC_EP_PED",doc_ep_pedmin),
                    new SqlParameter("maxDOC_EP_PED",doc_ep_pedmax),
                    new SqlParameter("DOC_EP_PAY_CODE",doc_ep_pay_code),
                    new SqlParameter("DOC_EP_PAY_SUB_CODE",doc_ep_pay_sub_code),
                    new SqlParameter("DOC_PARTNERSHIP",doc_partnership),
                    new SqlParameter("DOC_IND_HOLDBACK_ACTIVE",doc_ind_holdback_active),
                    new SqlParameter("GROUP_REGULAR_SERVICE",group_regular_service),
                    new SqlParameter("GROUP_OVER_SERVICED",group_over_serviced),
                    new SqlParameter("DOC_LOC_1_S1",doc_loc_1_s1),
                    new SqlParameter("DOC_LOC_1_S2",doc_loc_1_s2),
                    new SqlParameter("DOC_LOC_1_S3",doc_loc_1_s3),
                    new SqlParameter("DOC_LOC_2_S1",doc_loc_2_s1),
                    new SqlParameter("DOC_LOC_2_S2",doc_loc_2_s2),
                    new SqlParameter("DOC_LOC_2_S3",doc_loc_2_s3),
                    new SqlParameter("DOC_LOC_3_S1",doc_loc_3_s1),
                    new SqlParameter("DOC_LOC_3_S2",doc_loc_3_s2),
                    new SqlParameter("DOC_LOC_3_S3",doc_loc_3_s3),
                    new SqlParameter("DOC_LOC_4_S1",doc_loc_4_s1),
                    new SqlParameter("DOC_LOC_4_S2",doc_loc_4_s2),
                    new SqlParameter("DOC_LOC_4_S3",doc_loc_4_s3),
                    new SqlParameter("DOC_LOC_5_S1",doc_loc_5_s1),
                    new SqlParameter("DOC_LOC_5_S2",doc_loc_5_s2),
                    new SqlParameter("DOC_LOC_5_S3",doc_loc_5_s3),
                    new SqlParameter("DOC_LOC_6_S1",doc_loc_6_s1),
                    new SqlParameter("DOC_LOC_6_S2",doc_loc_6_s2),
                    new SqlParameter("DOC_LOC_6_S3",doc_loc_6_s3),
                    new SqlParameter("DOC_LOC_7_S1",doc_loc_7_s1),
                    new SqlParameter("DOC_LOC_7_S2",doc_loc_7_s2),
                    new SqlParameter("DOC_LOC_7_S3",doc_loc_7_s3),
                    new SqlParameter("DOC_LOC_8_S1",doc_loc_8_s1),
                    new SqlParameter("DOC_LOC_8_S2",doc_loc_8_s2),
                    new SqlParameter("DOC_LOC_8_S3",doc_loc_8_s3),
                    new SqlParameter("DOC_LOC_9_S1",doc_loc_9_s1),
                    new SqlParameter("DOC_LOC_9_S2",doc_loc_9_s2),
                    new SqlParameter("DOC_LOC_9_S3",doc_loc_9_s3),
                    new SqlParameter("DOC_LOC_10_S1",doc_loc_10_s1),
                    new SqlParameter("DOC_LOC_10_S2",doc_loc_10_s2),
                    new SqlParameter("DOC_LOC_10_S3",doc_loc_10_s3),
                    new SqlParameter("DOC_LOC_11_S1",doc_loc_11_s1),
                    new SqlParameter("DOC_LOC_11_S2",doc_loc_11_s2),
                    new SqlParameter("DOC_LOC_11_S3",doc_loc_11_s3),
                    new SqlParameter("DOC_LOC_12_S1",doc_loc_12_s1),
                    new SqlParameter("DOC_LOC_12_S2",doc_loc_12_s2),
                    new SqlParameter("DOC_LOC_12_S3",doc_loc_12_s3),
                    new SqlParameter("DOC_LOC_13_S1",doc_loc_13_s1),
                    new SqlParameter("DOC_LOC_13_S2",doc_loc_13_s2),
                    new SqlParameter("DOC_LOC_13_S3",doc_loc_13_s3),
                    new SqlParameter("DOC_LOC_14_S1",doc_loc_14_s1),
                    new SqlParameter("DOC_LOC_14_S2",doc_loc_14_s2),
                    new SqlParameter("DOC_LOC_14_S3",doc_loc_14_s3),
                    new SqlParameter("DOC_LOC_15_S1",doc_loc_15_s1),
                    new SqlParameter("DOC_LOC_15_S2",doc_loc_15_s2),
                    new SqlParameter("DOC_LOC_15_S3",doc_loc_15_s3),
                    new SqlParameter("DOC_LOC_16_S1",doc_loc_16_s1),
                    new SqlParameter("DOC_LOC_16_S2",doc_loc_16_s2),
                    new SqlParameter("DOC_LOC_16_S3",doc_loc_16_s3),
                    new SqlParameter("DOC_LOC_17_S1",doc_loc_17_s1),
                    new SqlParameter("DOC_LOC_17_S2",doc_loc_17_s2),
                    new SqlParameter("DOC_LOC_17_S3",doc_loc_17_s3),
                    new SqlParameter("DOC_LOC_18_S1",doc_loc_18_s1),
                    new SqlParameter("DOC_LOC_18_S2",doc_loc_18_s2),
                    new SqlParameter("DOC_LOC_18_S3",doc_loc_18_s3),
                    new SqlParameter("DOC_LOC_19_S1",doc_loc_19_s1),
                    new SqlParameter("DOC_LOC_19_S2",doc_loc_19_s2),
                    new SqlParameter("DOC_LOC_19_S3",doc_loc_19_s3),
                    new SqlParameter("DOC_LOC_20_S1",doc_loc_20_s1),
                    new SqlParameter("DOC_LOC_20_S2",doc_loc_20_s2),
                    new SqlParameter("DOC_LOC_20_S3",doc_loc_20_s3),
                    new SqlParameter("DOC_LOC_21_S1",doc_loc_21_s1),
                    new SqlParameter("DOC_LOC_21_S2",doc_loc_21_s2),
                    new SqlParameter("DOC_LOC_21_S3",doc_loc_21_s3),
                    new SqlParameter("DOC_LOC_22_S1",doc_loc_22_s1),
                    new SqlParameter("DOC_LOC_22_S2",doc_loc_22_s2),
                    new SqlParameter("DOC_LOC_22_S3",doc_loc_22_s3),
                    new SqlParameter("DOC_LOC_23_S1",doc_loc_23_s1),
                    new SqlParameter("DOC_LOC_23_S2",doc_loc_23_s2),
                    new SqlParameter("DOC_LOC_23_S3",doc_loc_23_s3),
                    new SqlParameter("DOC_LOC_24_S1",doc_loc_24_s1),
                    new SqlParameter("DOC_LOC_24_S2",doc_loc_24_s2),
                    new SqlParameter("DOC_LOC_24_S3",doc_loc_24_s3),
                    new SqlParameter("DOC_LOC_25_S1",doc_loc_25_s1),
                    new SqlParameter("DOC_LOC_25_S2",doc_loc_25_s2),
                    new SqlParameter("DOC_LOC_25_S3",doc_loc_25_s3),
                    new SqlParameter("DOC_LOC_26_S1",doc_loc_26_s1),
                    new SqlParameter("DOC_LOC_26_S2",doc_loc_26_s2),
                    new SqlParameter("DOC_LOC_26_S3",doc_loc_26_s3),
                    new SqlParameter("DOC_LOC_27_S1",doc_loc_27_s1),
                    new SqlParameter("DOC_LOC_27_S2",doc_loc_27_s2),
                    new SqlParameter("DOC_LOC_27_S3",doc_loc_27_s3),
                    new SqlParameter("DOC_LOC_28_S1",doc_loc_28_s1),
                    new SqlParameter("DOC_LOC_28_S2",doc_loc_28_s2),
                    new SqlParameter("DOC_LOC_28_S3",doc_loc_28_s3),
                    new SqlParameter("DOC_LOC_29_S1",doc_loc_29_s1),
                    new SqlParameter("DOC_LOC_29_S2",doc_loc_29_s2),
                    new SqlParameter("DOC_LOC_29_S3",doc_loc_29_s3),
                    new SqlParameter("DOC_LOC_30_S1",doc_loc_30_s1),
                    new SqlParameter("DOC_LOC_30_S2",doc_loc_30_s2),
                    new SqlParameter("DOC_LOC_30_S3",doc_loc_30_s3),
                    new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
                    new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
                    new SqlParameter("SortColumn",sortcolumn),
                    new SqlParameter("SortDirection",sortdirection),
                    new SqlParameter("Skip",skip),
                    new SqlParameter("Take",skip + TakeAmount)
            };


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_MSTR_RecordCount]", parameters);
                if (Reader.Read())
                    TotalItemCount = (int)Reader[0];
                if (TotalItemCount == 0)
                {
                    return new ObservableCollection<F020_DOCTOR_MSTR>();
                }

            }

            Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    DOC_NBR = Reader["DOC_NBR"].ToString(),
                    DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
                    DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
                    DOC_SIN_123 = ConvertDEC(Reader["DOC_SIN_123"]),
                    DOC_SIN_456 = ConvertDEC(Reader["DOC_SIN_456"]),
                    DOC_SIN_789 = ConvertDEC(Reader["DOC_SIN_789"]),
                    DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
                    DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString(),
                    DOC_NAME = Reader["DOC_NAME"].ToString(),
                    DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString(),
                    DOC_INIT1 = Reader["DOC_INIT1"].ToString(),
                    DOC_INIT2 = Reader["DOC_INIT2"].ToString(),
                    DOC_INIT3 = Reader["DOC_INIT3"].ToString(),
                    DOC_ADDR_OFFICE_1 = Reader["DOC_ADDR_OFFICE_1"].ToString(),
                    DOC_ADDR_OFFICE_2 = Reader["DOC_ADDR_OFFICE_2"].ToString(),
                    DOC_ADDR_OFFICE_3 = Reader["DOC_ADDR_OFFICE_3"].ToString(),
                    DOC_ADDR_OFFICE_PC1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString(),
                    DOC_ADDR_OFFICE_PC2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]),
                    DOC_ADDR_OFFICE_PC3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString(),
                    DOC_ADDR_OFFICE_PC4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]),
                    DOC_ADDR_OFFICE_PC5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString(),
                    DOC_ADDR_OFFICE_PC6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]),
                    DOC_ADDR_HOME_1 = Reader["DOC_ADDR_HOME_1"].ToString(),
                    DOC_ADDR_HOME_2 = Reader["DOC_ADDR_HOME_2"].ToString(),
                    DOC_ADDR_HOME_3 = Reader["DOC_ADDR_HOME_3"].ToString(),
                    DOC_ADDR_HOME_PC1 = Reader["DOC_ADDR_HOME_PC1"].ToString(),
                    DOC_ADDR_HOME_PC2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]),
                    DOC_ADDR_HOME_PC3 = Reader["DOC_ADDR_HOME_PC3"].ToString(),
                    DOC_ADDR_HOME_PC4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]),
                    DOC_ADDR_HOME_PC5 = Reader["DOC_ADDR_HOME_PC5"].ToString(),
                    DOC_ADDR_HOME_PC6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]),
                    DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
                    DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
                    DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
                    DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
                    DOC_DATE_FAC_START_YY = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]),
                    DOC_DATE_FAC_START_MM = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]),
                    DOC_DATE_FAC_START_DD = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]),
                    DOC_DATE_FAC_TERM_YY = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]),
                    DOC_DATE_FAC_TERM_MM = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]),
                    DOC_DATE_FAC_TERM_DD = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]),
                    DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]),
                    DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]),
                    DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]),
                    DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]),
                    DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]),
                    DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]),
                    DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]),
                    DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]),
                    DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]),
                    DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]),
                    DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
                    DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]),
                    DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
                    DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]),
                    DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]),
                    DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]),
                    DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]),
                    CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString(),
                    CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString(),
                    YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString(),
                    YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString(),
                    DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
                    DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
                    DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
                    DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
                    DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
                    DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
                    DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString(),
                    DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
                    DOC_NX_AVAIL_BATCH_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]),
                    DOC_NX_AVAIL_BATCH_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]),
                    DOC_NX_AVAIL_BATCH_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]),
                    DOC_NX_AVAIL_BATCH_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]),
                    DOC_NX_AVAIL_BATCH_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]),
                    DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
                    DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
                    DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
                    DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString(),
                    DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
                    DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
                    DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
                    DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
                    DOC_EP_PED = Reader["DOC_EP_PED"].ToString(),
                    DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
                    DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
                    DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString(),
                    DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
                    GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString(),
                    GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString(),
                    DOC_LOC_1_S1 = Reader["DOC_LOC_1_S1"].ToString(),
                    DOC_LOC_1_S2 = Reader["DOC_LOC_1_S2"].ToString(),
                    DOC_LOC_1_S3 = Reader["DOC_LOC_1_S3"].ToString(),
                    DOC_LOC_2_S1 = Reader["DOC_LOC_2_S1"].ToString(),
                    DOC_LOC_2_S2 = Reader["DOC_LOC_2_S2"].ToString(),
                    DOC_LOC_2_S3 = Reader["DOC_LOC_2_S3"].ToString(),
                    DOC_LOC_3_S1 = Reader["DOC_LOC_3_S1"].ToString(),
                    DOC_LOC_3_S2 = Reader["DOC_LOC_3_S2"].ToString(),
                    DOC_LOC_3_S3 = Reader["DOC_LOC_3_S3"].ToString(),
                    DOC_LOC_4_S1 = Reader["DOC_LOC_4_S1"].ToString(),
                    DOC_LOC_4_S2 = Reader["DOC_LOC_4_S2"].ToString(),
                    DOC_LOC_4_S3 = Reader["DOC_LOC_4_S3"].ToString(),
                    DOC_LOC_5_S1 = Reader["DOC_LOC_5_S1"].ToString(),
                    DOC_LOC_5_S2 = Reader["DOC_LOC_5_S2"].ToString(),
                    DOC_LOC_5_S3 = Reader["DOC_LOC_5_S3"].ToString(),
                    DOC_LOC_6_S1 = Reader["DOC_LOC_6_S1"].ToString(),
                    DOC_LOC_6_S2 = Reader["DOC_LOC_6_S2"].ToString(),
                    DOC_LOC_6_S3 = Reader["DOC_LOC_6_S3"].ToString(),
                    DOC_LOC_7_S1 = Reader["DOC_LOC_7_S1"].ToString(),
                    DOC_LOC_7_S2 = Reader["DOC_LOC_7_S2"].ToString(),
                    DOC_LOC_7_S3 = Reader["DOC_LOC_7_S3"].ToString(),
                    DOC_LOC_8_S1 = Reader["DOC_LOC_8_S1"].ToString(),
                    DOC_LOC_8_S2 = Reader["DOC_LOC_8_S2"].ToString(),
                    DOC_LOC_8_S3 = Reader["DOC_LOC_8_S3"].ToString(),
                    DOC_LOC_9_S1 = Reader["DOC_LOC_9_S1"].ToString(),
                    DOC_LOC_9_S2 = Reader["DOC_LOC_9_S2"].ToString(),
                    DOC_LOC_9_S3 = Reader["DOC_LOC_9_S3"].ToString(),
                    DOC_LOC_10_S1 = Reader["DOC_LOC_10_S1"].ToString(),
                    DOC_LOC_10_S2 = Reader["DOC_LOC_10_S2"].ToString(),
                    DOC_LOC_10_S3 = Reader["DOC_LOC_10_S3"].ToString(),
                    DOC_LOC_11_S1 = Reader["DOC_LOC_11_S1"].ToString(),
                    DOC_LOC_11_S2 = Reader["DOC_LOC_11_S2"].ToString(),
                    DOC_LOC_11_S3 = Reader["DOC_LOC_11_S3"].ToString(),
                    DOC_LOC_12_S1 = Reader["DOC_LOC_12_S1"].ToString(),
                    DOC_LOC_12_S2 = Reader["DOC_LOC_12_S2"].ToString(),
                    DOC_LOC_12_S3 = Reader["DOC_LOC_12_S3"].ToString(),
                    DOC_LOC_13_S1 = Reader["DOC_LOC_13_S1"].ToString(),
                    DOC_LOC_13_S2 = Reader["DOC_LOC_13_S2"].ToString(),
                    DOC_LOC_13_S3 = Reader["DOC_LOC_13_S3"].ToString(),
                    DOC_LOC_14_S1 = Reader["DOC_LOC_14_S1"].ToString(),
                    DOC_LOC_14_S2 = Reader["DOC_LOC_14_S2"].ToString(),
                    DOC_LOC_14_S3 = Reader["DOC_LOC_14_S3"].ToString(),
                    DOC_LOC_15_S1 = Reader["DOC_LOC_15_S1"].ToString(),
                    DOC_LOC_15_S2 = Reader["DOC_LOC_15_S2"].ToString(),
                    DOC_LOC_15_S3 = Reader["DOC_LOC_15_S3"].ToString(),
                    DOC_LOC_16_S1 = Reader["DOC_LOC_16_S1"].ToString(),
                    DOC_LOC_16_S2 = Reader["DOC_LOC_16_S2"].ToString(),
                    DOC_LOC_16_S3 = Reader["DOC_LOC_16_S3"].ToString(),
                    DOC_LOC_17_S1 = Reader["DOC_LOC_17_S1"].ToString(),
                    DOC_LOC_17_S2 = Reader["DOC_LOC_17_S2"].ToString(),
                    DOC_LOC_17_S3 = Reader["DOC_LOC_17_S3"].ToString(),
                    DOC_LOC_18_S1 = Reader["DOC_LOC_18_S1"].ToString(),
                    DOC_LOC_18_S2 = Reader["DOC_LOC_18_S2"].ToString(),
                    DOC_LOC_18_S3 = Reader["DOC_LOC_18_S3"].ToString(),
                    DOC_LOC_19_S1 = Reader["DOC_LOC_19_S1"].ToString(),
                    DOC_LOC_19_S2 = Reader["DOC_LOC_19_S2"].ToString(),
                    DOC_LOC_19_S3 = Reader["DOC_LOC_19_S3"].ToString(),
                    DOC_LOC_20_S1 = Reader["DOC_LOC_20_S1"].ToString(),
                    DOC_LOC_20_S2 = Reader["DOC_LOC_20_S2"].ToString(),
                    DOC_LOC_20_S3 = Reader["DOC_LOC_20_S3"].ToString(),
                    DOC_LOC_21_S1 = Reader["DOC_LOC_21_S1"].ToString(),
                    DOC_LOC_21_S2 = Reader["DOC_LOC_21_S2"].ToString(),
                    DOC_LOC_21_S3 = Reader["DOC_LOC_21_S3"].ToString(),
                    DOC_LOC_22_S1 = Reader["DOC_LOC_22_S1"].ToString(),
                    DOC_LOC_22_S2 = Reader["DOC_LOC_22_S2"].ToString(),
                    DOC_LOC_22_S3 = Reader["DOC_LOC_22_S3"].ToString(),
                    DOC_LOC_23_S1 = Reader["DOC_LOC_23_S1"].ToString(),
                    DOC_LOC_23_S2 = Reader["DOC_LOC_23_S2"].ToString(),
                    DOC_LOC_23_S3 = Reader["DOC_LOC_23_S3"].ToString(),
                    DOC_LOC_24_S1 = Reader["DOC_LOC_24_S1"].ToString(),
                    DOC_LOC_24_S2 = Reader["DOC_LOC_24_S2"].ToString(),
                    DOC_LOC_24_S3 = Reader["DOC_LOC_24_S3"].ToString(),
                    DOC_LOC_25_S1 = Reader["DOC_LOC_25_S1"].ToString(),
                    DOC_LOC_25_S2 = Reader["DOC_LOC_25_S2"].ToString(),
                    DOC_LOC_25_S3 = Reader["DOC_LOC_25_S3"].ToString(),
                    DOC_LOC_26_S1 = Reader["DOC_LOC_26_S1"].ToString(),
                    DOC_LOC_26_S2 = Reader["DOC_LOC_26_S2"].ToString(),
                    DOC_LOC_26_S3 = Reader["DOC_LOC_26_S3"].ToString(),
                    DOC_LOC_27_S1 = Reader["DOC_LOC_27_S1"].ToString(),
                    DOC_LOC_27_S2 = Reader["DOC_LOC_27_S2"].ToString(),
                    DOC_LOC_27_S3 = Reader["DOC_LOC_27_S3"].ToString(),
                    DOC_LOC_28_S1 = Reader["DOC_LOC_28_S1"].ToString(),
                    DOC_LOC_28_S2 = Reader["DOC_LOC_28_S2"].ToString(),
                    DOC_LOC_28_S3 = Reader["DOC_LOC_28_S3"].ToString(),
                    DOC_LOC_29_S1 = Reader["DOC_LOC_29_S1"].ToString(),
                    DOC_LOC_29_S2 = Reader["DOC_LOC_29_S2"].ToString(),
                    DOC_LOC_29_S3 = Reader["DOC_LOC_29_S3"].ToString(),
                    DOC_LOC_30_S1 = Reader["DOC_LOC_30_S1"].ToString(),
                    DOC_LOC_30_S2 = Reader["DOC_LOC_30_S2"].ToString(),
                    DOC_LOC_30_S3 = Reader["DOC_LOC_30_S3"].ToString(),
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalDoc_nbr = Reader["DOC_NBR"].ToString(),
                    _originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
                    _originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
                    _originalDoc_sin_123 = ConvertDEC(Reader["DOC_SIN_123"]),
                    _originalDoc_sin_456 = ConvertDEC(Reader["DOC_SIN_456"]),
                    _originalDoc_sin_789 = ConvertDEC(Reader["DOC_SIN_789"]),
                    _originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
                    _originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString(),
                    _originalDoc_name = Reader["DOC_NAME"].ToString(),
                    _originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString(),
                    _originalDoc_init1 = Reader["DOC_INIT1"].ToString(),
                    _originalDoc_init2 = Reader["DOC_INIT2"].ToString(),
                    _originalDoc_init3 = Reader["DOC_INIT3"].ToString(),
                    _originalDoc_addr_office_1 = Reader["DOC_ADDR_OFFICE_1"].ToString(),
                    _originalDoc_addr_office_2 = Reader["DOC_ADDR_OFFICE_2"].ToString(),
                    _originalDoc_addr_office_3 = Reader["DOC_ADDR_OFFICE_3"].ToString(),
                    _originalDoc_addr_office_pc1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString(),
                    _originalDoc_addr_office_pc2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]),
                    _originalDoc_addr_office_pc3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString(),
                    _originalDoc_addr_office_pc4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]),
                    _originalDoc_addr_office_pc5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString(),
                    _originalDoc_addr_office_pc6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]),
                    _originalDoc_addr_home_1 = Reader["DOC_ADDR_HOME_1"].ToString(),
                    _originalDoc_addr_home_2 = Reader["DOC_ADDR_HOME_2"].ToString(),
                    _originalDoc_addr_home_3 = Reader["DOC_ADDR_HOME_3"].ToString(),
                    _originalDoc_addr_home_pc1 = Reader["DOC_ADDR_HOME_PC1"].ToString(),
                    _originalDoc_addr_home_pc2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]),
                    _originalDoc_addr_home_pc3 = Reader["DOC_ADDR_HOME_PC3"].ToString(),
                    _originalDoc_addr_home_pc4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]),
                    _originalDoc_addr_home_pc5 = Reader["DOC_ADDR_HOME_PC5"].ToString(),
                    _originalDoc_addr_home_pc6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]),
                    _originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
                    _originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
                    _originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
                    _originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
                    _originalDoc_date_fac_start_yy = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]),
                    _originalDoc_date_fac_start_mm = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]),
                    _originalDoc_date_fac_start_dd = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]),
                    _originalDoc_date_fac_term_yy = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]),
                    _originalDoc_date_fac_term_mm = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]),
                    _originalDoc_date_fac_term_dd = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]),
                    _originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]),
                    _originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]),
                    _originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]),
                    _originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]),
                    _originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]),
                    _originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]),
                    _originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]),
                    _originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]),
                    _originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]),
                    _originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]),
                    _originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
                    _originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]),
                    _originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
                    _originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]),
                    _originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]),
                    _originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]),
                    _originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]),
                    _originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString(),
                    _originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString(),
                    _originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString(),
                    _originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString(),
                    _originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
                    _originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
                    _originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
                    _originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
                    _originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
                    _originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
                    _originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString(),
                    _originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
                    _originalDoc_nx_avail_batch_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]),
                    _originalDoc_nx_avail_batch_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]),
                    _originalDoc_nx_avail_batch_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]),
                    _originalDoc_nx_avail_batch_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]),
                    _originalDoc_nx_avail_batch_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]),
                    _originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
                    _originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
                    _originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
                    _originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString(),
                    _originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
                    _originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
                    _originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
                    _originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
                    _originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString(),
                    _originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
                    _originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
                    _originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString(),
                    _originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
                    _originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString(),
                    _originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString(),
                    _originalDoc_loc_1_s1 = Reader["DOC_LOC_1_S1"].ToString(),
                    _originalDoc_loc_1_s2 = Reader["DOC_LOC_1_S2"].ToString(),
                    _originalDoc_loc_1_s3 = Reader["DOC_LOC_1_S3"].ToString(),
                    _originalDoc_loc_2_s1 = Reader["DOC_LOC_2_S1"].ToString(),
                    _originalDoc_loc_2_s2 = Reader["DOC_LOC_2_S2"].ToString(),
                    _originalDoc_loc_2_s3 = Reader["DOC_LOC_2_S3"].ToString(),
                    _originalDoc_loc_3_s1 = Reader["DOC_LOC_3_S1"].ToString(),
                    _originalDoc_loc_3_s2 = Reader["DOC_LOC_3_S2"].ToString(),
                    _originalDoc_loc_3_s3 = Reader["DOC_LOC_3_S3"].ToString(),
                    _originalDoc_loc_4_s1 = Reader["DOC_LOC_4_S1"].ToString(),
                    _originalDoc_loc_4_s2 = Reader["DOC_LOC_4_S2"].ToString(),
                    _originalDoc_loc_4_s3 = Reader["DOC_LOC_4_S3"].ToString(),
                    _originalDoc_loc_5_s1 = Reader["DOC_LOC_5_S1"].ToString(),
                    _originalDoc_loc_5_s2 = Reader["DOC_LOC_5_S2"].ToString(),
                    _originalDoc_loc_5_s3 = Reader["DOC_LOC_5_S3"].ToString(),
                    _originalDoc_loc_6_s1 = Reader["DOC_LOC_6_S1"].ToString(),
                    _originalDoc_loc_6_s2 = Reader["DOC_LOC_6_S2"].ToString(),
                    _originalDoc_loc_6_s3 = Reader["DOC_LOC_6_S3"].ToString(),
                    _originalDoc_loc_7_s1 = Reader["DOC_LOC_7_S1"].ToString(),
                    _originalDoc_loc_7_s2 = Reader["DOC_LOC_7_S2"].ToString(),
                    _originalDoc_loc_7_s3 = Reader["DOC_LOC_7_S3"].ToString(),
                    _originalDoc_loc_8_s1 = Reader["DOC_LOC_8_S1"].ToString(),
                    _originalDoc_loc_8_s2 = Reader["DOC_LOC_8_S2"].ToString(),
                    _originalDoc_loc_8_s3 = Reader["DOC_LOC_8_S3"].ToString(),
                    _originalDoc_loc_9_s1 = Reader["DOC_LOC_9_S1"].ToString(),
                    _originalDoc_loc_9_s2 = Reader["DOC_LOC_9_S2"].ToString(),
                    _originalDoc_loc_9_s3 = Reader["DOC_LOC_9_S3"].ToString(),
                    _originalDoc_loc_10_s1 = Reader["DOC_LOC_10_S1"].ToString(),
                    _originalDoc_loc_10_s2 = Reader["DOC_LOC_10_S2"].ToString(),
                    _originalDoc_loc_10_s3 = Reader["DOC_LOC_10_S3"].ToString(),
                    _originalDoc_loc_11_s1 = Reader["DOC_LOC_11_S1"].ToString(),
                    _originalDoc_loc_11_s2 = Reader["DOC_LOC_11_S2"].ToString(),
                    _originalDoc_loc_11_s3 = Reader["DOC_LOC_11_S3"].ToString(),
                    _originalDoc_loc_12_s1 = Reader["DOC_LOC_12_S1"].ToString(),
                    _originalDoc_loc_12_s2 = Reader["DOC_LOC_12_S2"].ToString(),
                    _originalDoc_loc_12_s3 = Reader["DOC_LOC_12_S3"].ToString(),
                    _originalDoc_loc_13_s1 = Reader["DOC_LOC_13_S1"].ToString(),
                    _originalDoc_loc_13_s2 = Reader["DOC_LOC_13_S2"].ToString(),
                    _originalDoc_loc_13_s3 = Reader["DOC_LOC_13_S3"].ToString(),
                    _originalDoc_loc_14_s1 = Reader["DOC_LOC_14_S1"].ToString(),
                    _originalDoc_loc_14_s2 = Reader["DOC_LOC_14_S2"].ToString(),
                    _originalDoc_loc_14_s3 = Reader["DOC_LOC_14_S3"].ToString(),
                    _originalDoc_loc_15_s1 = Reader["DOC_LOC_15_S1"].ToString(),
                    _originalDoc_loc_15_s2 = Reader["DOC_LOC_15_S2"].ToString(),
                    _originalDoc_loc_15_s3 = Reader["DOC_LOC_15_S3"].ToString(),
                    _originalDoc_loc_16_s1 = Reader["DOC_LOC_16_S1"].ToString(),
                    _originalDoc_loc_16_s2 = Reader["DOC_LOC_16_S2"].ToString(),
                    _originalDoc_loc_16_s3 = Reader["DOC_LOC_16_S3"].ToString(),
                    _originalDoc_loc_17_s1 = Reader["DOC_LOC_17_S1"].ToString(),
                    _originalDoc_loc_17_s2 = Reader["DOC_LOC_17_S2"].ToString(),
                    _originalDoc_loc_17_s3 = Reader["DOC_LOC_17_S3"].ToString(),
                    _originalDoc_loc_18_s1 = Reader["DOC_LOC_18_S1"].ToString(),
                    _originalDoc_loc_18_s2 = Reader["DOC_LOC_18_S2"].ToString(),
                    _originalDoc_loc_18_s3 = Reader["DOC_LOC_18_S3"].ToString(),
                    _originalDoc_loc_19_s1 = Reader["DOC_LOC_19_S1"].ToString(),
                    _originalDoc_loc_19_s2 = Reader["DOC_LOC_19_S2"].ToString(),
                    _originalDoc_loc_19_s3 = Reader["DOC_LOC_19_S3"].ToString(),
                    _originalDoc_loc_20_s1 = Reader["DOC_LOC_20_S1"].ToString(),
                    _originalDoc_loc_20_s2 = Reader["DOC_LOC_20_S2"].ToString(),
                    _originalDoc_loc_20_s3 = Reader["DOC_LOC_20_S3"].ToString(),
                    _originalDoc_loc_21_s1 = Reader["DOC_LOC_21_S1"].ToString(),
                    _originalDoc_loc_21_s2 = Reader["DOC_LOC_21_S2"].ToString(),
                    _originalDoc_loc_21_s3 = Reader["DOC_LOC_21_S3"].ToString(),
                    _originalDoc_loc_22_s1 = Reader["DOC_LOC_22_S1"].ToString(),
                    _originalDoc_loc_22_s2 = Reader["DOC_LOC_22_S2"].ToString(),
                    _originalDoc_loc_22_s3 = Reader["DOC_LOC_22_S3"].ToString(),
                    _originalDoc_loc_23_s1 = Reader["DOC_LOC_23_S1"].ToString(),
                    _originalDoc_loc_23_s2 = Reader["DOC_LOC_23_S2"].ToString(),
                    _originalDoc_loc_23_s3 = Reader["DOC_LOC_23_S3"].ToString(),
                    _originalDoc_loc_24_s1 = Reader["DOC_LOC_24_S1"].ToString(),
                    _originalDoc_loc_24_s2 = Reader["DOC_LOC_24_S2"].ToString(),
                    _originalDoc_loc_24_s3 = Reader["DOC_LOC_24_S3"].ToString(),
                    _originalDoc_loc_25_s1 = Reader["DOC_LOC_25_S1"].ToString(),
                    _originalDoc_loc_25_s2 = Reader["DOC_LOC_25_S2"].ToString(),
                    _originalDoc_loc_25_s3 = Reader["DOC_LOC_25_S3"].ToString(),
                    _originalDoc_loc_26_s1 = Reader["DOC_LOC_26_S1"].ToString(),
                    _originalDoc_loc_26_s2 = Reader["DOC_LOC_26_S2"].ToString(),
                    _originalDoc_loc_26_s3 = Reader["DOC_LOC_26_S3"].ToString(),
                    _originalDoc_loc_27_s1 = Reader["DOC_LOC_27_S1"].ToString(),
                    _originalDoc_loc_27_s2 = Reader["DOC_LOC_27_S2"].ToString(),
                    _originalDoc_loc_27_s3 = Reader["DOC_LOC_27_S3"].ToString(),
                    _originalDoc_loc_28_s1 = Reader["DOC_LOC_28_S1"].ToString(),
                    _originalDoc_loc_28_s2 = Reader["DOC_LOC_28_S2"].ToString(),
                    _originalDoc_loc_28_s3 = Reader["DOC_LOC_28_S3"].ToString(),
                    _originalDoc_loc_29_s1 = Reader["DOC_LOC_29_S1"].ToString(),
                    _originalDoc_loc_29_s2 = Reader["DOC_LOC_29_S2"].ToString(),
                    _originalDoc_loc_29_s3 = Reader["DOC_LOC_29_S3"].ToString(),
                    _originalDoc_loc_30_s1 = Reader["DOC_LOC_30_S1"].ToString(),
                    _originalDoc_loc_30_s2 = Reader["DOC_LOC_30_S2"].ToString(),
                    _originalDoc_loc_30_s3 = Reader["DOC_LOC_30_S3"].ToString(),
                    _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;
        }

        public F020_DOCTOR_MSTR Class()
        {
            if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_DOCTOR_MSTR> Collection(ObservableCollection<F020_DOCTOR_MSTR>
                                                               f020DoctorMstr = null)
        {
            if (IsSameSearch() && f020DoctorMstr != null)
            {
                return f020DoctorMstr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_DOCTOR_MSTR>();
            }

            var parameters = new SqlParameter[]
            {
                    new SqlParameter("ROWID",WhereRowid),
                    new SqlParameter("DOC_NBR",WhereDoc_nbr),
                    new SqlParameter("DOC_DEPT",WhereDoc_dept),
                    new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
                    new SqlParameter("DOC_SIN_123",WhereDoc_sin_123),
                    new SqlParameter("DOC_SIN_456",WhereDoc_sin_456),
                    new SqlParameter("DOC_SIN_789",WhereDoc_sin_789),
                    new SqlParameter("DOC_SPEC_CD",WhereDoc_spec_cd),
                    new SqlParameter("DOC_HOSP_NBR",WhereDoc_hosp_nbr),
                    new SqlParameter("DOC_NAME",WhereDoc_name),
                    new SqlParameter("DOC_NAME_SOUNDEX",WhereDoc_name_soundex),
                    new SqlParameter("DOC_INIT1",WhereDoc_init1),
                    new SqlParameter("DOC_INIT2",WhereDoc_init2),
                    new SqlParameter("DOC_INIT3",WhereDoc_init3),
                    new SqlParameter("DOC_ADDR_OFFICE_1",WhereDoc_addr_office_1),
                    new SqlParameter("DOC_ADDR_OFFICE_2",WhereDoc_addr_office_2),
                    new SqlParameter("DOC_ADDR_OFFICE_3",WhereDoc_addr_office_3),
                    new SqlParameter("DOC_ADDR_OFFICE_PC1",WhereDoc_addr_office_pc1),
                    new SqlParameter("DOC_ADDR_OFFICE_PC2",WhereDoc_addr_office_pc2),
                    new SqlParameter("DOC_ADDR_OFFICE_PC3",WhereDoc_addr_office_pc3),
                    new SqlParameter("DOC_ADDR_OFFICE_PC4",WhereDoc_addr_office_pc4),
                    new SqlParameter("DOC_ADDR_OFFICE_PC5",WhereDoc_addr_office_pc5),
                    new SqlParameter("DOC_ADDR_OFFICE_PC6",WhereDoc_addr_office_pc6),
                    new SqlParameter("DOC_ADDR_HOME_1",WhereDoc_addr_home_1),
                    new SqlParameter("DOC_ADDR_HOME_2",WhereDoc_addr_home_2),
                    new SqlParameter("DOC_ADDR_HOME_3",WhereDoc_addr_home_3),
                    new SqlParameter("DOC_ADDR_HOME_PC1",WhereDoc_addr_home_pc1),
                    new SqlParameter("DOC_ADDR_HOME_PC2",WhereDoc_addr_home_pc2),
                    new SqlParameter("DOC_ADDR_HOME_PC3",WhereDoc_addr_home_pc3),
                    new SqlParameter("DOC_ADDR_HOME_PC4",WhereDoc_addr_home_pc4),
                    new SqlParameter("DOC_ADDR_HOME_PC5",WhereDoc_addr_home_pc5),
                    new SqlParameter("DOC_ADDR_HOME_PC6",WhereDoc_addr_home_pc6),
                    new SqlParameter("DOC_FULL_PART_IND",WhereDoc_full_part_ind),
                    new SqlParameter("DOC_BANK_NBR",WhereDoc_bank_nbr),
                    new SqlParameter("DOC_BANK_BRANCH",WhereDoc_bank_branch),
                    new SqlParameter("DOC_BANK_ACCT",WhereDoc_bank_acct),
                    new SqlParameter("DOC_DATE_FAC_START_YY",WhereDoc_date_fac_start_yy),
                    new SqlParameter("DOC_DATE_FAC_START_MM",WhereDoc_date_fac_start_mm),
                    new SqlParameter("DOC_DATE_FAC_START_DD",WhereDoc_date_fac_start_dd),
                    new SqlParameter("DOC_DATE_FAC_TERM_YY",WhereDoc_date_fac_term_yy),
                    new SqlParameter("DOC_DATE_FAC_TERM_MM",WhereDoc_date_fac_term_mm),
                    new SqlParameter("DOC_DATE_FAC_TERM_DD",WhereDoc_date_fac_term_dd),
                    new SqlParameter("DOC_YTDGUA",WhereDoc_ytdgua),
                    new SqlParameter("DOC_YTDGUB",WhereDoc_ytdgub),
                    new SqlParameter("DOC_YTDGUC",WhereDoc_ytdguc),
                    new SqlParameter("DOC_YTDGUD",WhereDoc_ytdgud),
                    new SqlParameter("DOC_YTDCEA",WhereDoc_ytdcea),
                    new SqlParameter("DOC_YTDCEX",WhereDoc_ytdcex),
                    new SqlParameter("DOC_YTDEAR",WhereDoc_ytdear),
                    new SqlParameter("DOC_YTDINC",WhereDoc_ytdinc),
                    new SqlParameter("DOC_YTDEFT",WhereDoc_ytdeft),
                    new SqlParameter("DOC_TOTINC_G",WhereDoc_totinc_g),
                    new SqlParameter("DOC_EP_DATE_DEPOSIT",WhereDoc_ep_date_deposit),
                    new SqlParameter("DOC_TOTINC",WhereDoc_totinc),
                    new SqlParameter("DOC_EP_CEIEXP",WhereDoc_ep_ceiexp),
                    new SqlParameter("DOC_ADJCEA",WhereDoc_adjcea),
                    new SqlParameter("DOC_ADJCEX",WhereDoc_adjcex),
                    new SqlParameter("DOC_CEICEA",WhereDoc_ceicea),
                    new SqlParameter("DOC_CEICEX",WhereDoc_ceicex),
                    new SqlParameter("CEICEA_PRT_FORMAT",WhereCeicea_prt_format),
                    new SqlParameter("CEICEX_PRT_FORMAT",WhereCeicex_prt_format),
                    new SqlParameter("YTDCEA_PRT_FORMAT",WhereYtdcea_prt_format),
                    new SqlParameter("YTDCEX_PRT_FORMAT",WhereYtdcex_prt_format),
                    new SqlParameter("DOC_SPEC_CD_2",WhereDoc_spec_cd_2),
                    new SqlParameter("DOC_SPEC_CD_3",WhereDoc_spec_cd_3),
                    new SqlParameter("DOC_YTDINC_G",WhereDoc_ytdinc_g),
                    new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC",WhereDoc_rma_expense_percent_misc),
                    new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
                    new SqlParameter("DOC_DEPT_2",WhereDoc_dept_2),
                    new SqlParameter("DOC_IND_PAYS_GST",WhereDoc_ind_pays_gst),
				/*	new SqlParameter("DOC_NX_AVAIL_BATCH",WhereDoc_nx_avail_batch),
					new SqlParameter("DOC_NX_AVAIL_BATCH_2",WhereDoc_nx_avail_batch_2),
					new SqlParameter("DOC_NX_AVAIL_BATCH_3",WhereDoc_nx_avail_batch_3),
					new SqlParameter("DOC_NX_AVAIL_BATCH_4",WhereDoc_nx_avail_batch_4),
					new SqlParameter("DOC_NX_AVAIL_BATCH_5",WhereDoc_nx_avail_batch_5),
					new SqlParameter("DOC_NX_AVAIL_BATCH_6",WhereDoc_nx_avail_batch_6), */
					new SqlParameter("DOC_YRLY_CEILING_COMPUTED",WhereDoc_yrly_ceiling_computed),
                    new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED",WhereDoc_yrly_expense_computed),
                    new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG",WhereDoc_rma_expense_percent_reg),
                    new SqlParameter("DOC_SUB_SPECIALTY",WhereDoc_sub_specialty),
                    new SqlParameter("DOC_PAYEFT",WhereDoc_payeft),
                    new SqlParameter("DOC_YTDDED",WhereDoc_ytdded),
                    new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC",WhereDoc_dept_expense_percent_misc),
                    new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG",WhereDoc_dept_expense_percent_reg),
                    new SqlParameter("DOC_EP_PED",WhereDoc_ep_ped),
                    new SqlParameter("DOC_EP_PAY_CODE",WhereDoc_ep_pay_code),
                    new SqlParameter("DOC_EP_PAY_SUB_CODE",WhereDoc_ep_pay_sub_code),
                    new SqlParameter("DOC_PARTNERSHIP",WhereDoc_partnership),
                    new SqlParameter("DOC_IND_HOLDBACK_ACTIVE",WhereDoc_ind_holdback_active),
                    new SqlParameter("GROUP_REGULAR_SERVICE",WhereGroup_regular_service),
                    new SqlParameter("GROUP_OVER_SERVICED",WhereGroup_over_serviced),
				/*	new SqlParameter("DOC_LOC_1_S1",WhereDoc_loc_1_s1),
					new SqlParameter("DOC_LOC_1_S2",WhereDoc_loc_1_s2),
					new SqlParameter("DOC_LOC_1_S3",WhereDoc_loc_1_s3),
					new SqlParameter("DOC_LOC_2_S1",WhereDoc_loc_2_s1),
					new SqlParameter("DOC_LOC_2_S2",WhereDoc_loc_2_s2),
					new SqlParameter("DOC_LOC_2_S3",WhereDoc_loc_2_s3),
					new SqlParameter("DOC_LOC_3_S1",WhereDoc_loc_3_s1),
					new SqlParameter("DOC_LOC_3_S2",WhereDoc_loc_3_s2),
					new SqlParameter("DOC_LOC_3_S3",WhereDoc_loc_3_s3),
					new SqlParameter("DOC_LOC_4_S1",WhereDoc_loc_4_s1),
					new SqlParameter("DOC_LOC_4_S2",WhereDoc_loc_4_s2),
					new SqlParameter("DOC_LOC_4_S3",WhereDoc_loc_4_s3),
					new SqlParameter("DOC_LOC_5_S1",WhereDoc_loc_5_s1),
					new SqlParameter("DOC_LOC_5_S2",WhereDoc_loc_5_s2),
					new SqlParameter("DOC_LOC_5_S3",WhereDoc_loc_5_s3),
					new SqlParameter("DOC_LOC_6_S1",WhereDoc_loc_6_s1),
					new SqlParameter("DOC_LOC_6_S2",WhereDoc_loc_6_s2),
					new SqlParameter("DOC_LOC_6_S3",WhereDoc_loc_6_s3),
					new SqlParameter("DOC_LOC_7_S1",WhereDoc_loc_7_s1),
					new SqlParameter("DOC_LOC_7_S2",WhereDoc_loc_7_s2),
					new SqlParameter("DOC_LOC_7_S3",WhereDoc_loc_7_s3),
					new SqlParameter("DOC_LOC_8_S1",WhereDoc_loc_8_s1),
					new SqlParameter("DOC_LOC_8_S2",WhereDoc_loc_8_s2),
					new SqlParameter("DOC_LOC_8_S3",WhereDoc_loc_8_s3),
					new SqlParameter("DOC_LOC_9_S1",WhereDoc_loc_9_s1),
					new SqlParameter("DOC_LOC_9_S2",WhereDoc_loc_9_s2),
					new SqlParameter("DOC_LOC_9_S3",WhereDoc_loc_9_s3),
					new SqlParameter("DOC_LOC_10_S1",WhereDoc_loc_10_s1),
					new SqlParameter("DOC_LOC_10_S2",WhereDoc_loc_10_s2),
					new SqlParameter("DOC_LOC_10_S3",WhereDoc_loc_10_s3),
					new SqlParameter("DOC_LOC_11_S1",WhereDoc_loc_11_s1),
					new SqlParameter("DOC_LOC_11_S2",WhereDoc_loc_11_s2),
					new SqlParameter("DOC_LOC_11_S3",WhereDoc_loc_11_s3),
					new SqlParameter("DOC_LOC_12_S1",WhereDoc_loc_12_s1),
					new SqlParameter("DOC_LOC_12_S2",WhereDoc_loc_12_s2),
					new SqlParameter("DOC_LOC_12_S3",WhereDoc_loc_12_s3),
					new SqlParameter("DOC_LOC_13_S1",WhereDoc_loc_13_s1),
					new SqlParameter("DOC_LOC_13_S2",WhereDoc_loc_13_s2),
					new SqlParameter("DOC_LOC_13_S3",WhereDoc_loc_13_s3),
					new SqlParameter("DOC_LOC_14_S1",WhereDoc_loc_14_s1),
					new SqlParameter("DOC_LOC_14_S2",WhereDoc_loc_14_s2),
					new SqlParameter("DOC_LOC_14_S3",WhereDoc_loc_14_s3),
					new SqlParameter("DOC_LOC_15_S1",WhereDoc_loc_15_s1),
					new SqlParameter("DOC_LOC_15_S2",WhereDoc_loc_15_s2),
					new SqlParameter("DOC_LOC_15_S3",WhereDoc_loc_15_s3),
					new SqlParameter("DOC_LOC_16_S1",WhereDoc_loc_16_s1),
					new SqlParameter("DOC_LOC_16_S2",WhereDoc_loc_16_s2),
					new SqlParameter("DOC_LOC_16_S3",WhereDoc_loc_16_s3),
					new SqlParameter("DOC_LOC_17_S1",WhereDoc_loc_17_s1),
					new SqlParameter("DOC_LOC_17_S2",WhereDoc_loc_17_s2),
					new SqlParameter("DOC_LOC_17_S3",WhereDoc_loc_17_s3),
					new SqlParameter("DOC_LOC_18_S1",WhereDoc_loc_18_s1),
					new SqlParameter("DOC_LOC_18_S2",WhereDoc_loc_18_s2),
					new SqlParameter("DOC_LOC_18_S3",WhereDoc_loc_18_s3),
					new SqlParameter("DOC_LOC_19_S1",WhereDoc_loc_19_s1),
					new SqlParameter("DOC_LOC_19_S2",WhereDoc_loc_19_s2),
					new SqlParameter("DOC_LOC_19_S3",WhereDoc_loc_19_s3),
					new SqlParameter("DOC_LOC_20_S1",WhereDoc_loc_20_s1),
					new SqlParameter("DOC_LOC_20_S2",WhereDoc_loc_20_s2),
					new SqlParameter("DOC_LOC_20_S3",WhereDoc_loc_20_s3),
					new SqlParameter("DOC_LOC_21_S1",WhereDoc_loc_21_s1),
					new SqlParameter("DOC_LOC_21_S2",WhereDoc_loc_21_s2),
					new SqlParameter("DOC_LOC_21_S3",WhereDoc_loc_21_s3),
					new SqlParameter("DOC_LOC_22_S1",WhereDoc_loc_22_s1),
					new SqlParameter("DOC_LOC_22_S2",WhereDoc_loc_22_s2),
					new SqlParameter("DOC_LOC_22_S3",WhereDoc_loc_22_s3),
					new SqlParameter("DOC_LOC_23_S1",WhereDoc_loc_23_s1),
					new SqlParameter("DOC_LOC_23_S2",WhereDoc_loc_23_s2),
					new SqlParameter("DOC_LOC_23_S3",WhereDoc_loc_23_s3),
					new SqlParameter("DOC_LOC_24_S1",WhereDoc_loc_24_s1),
					new SqlParameter("DOC_LOC_24_S2",WhereDoc_loc_24_s2),
					new SqlParameter("DOC_LOC_24_S3",WhereDoc_loc_24_s3),
					new SqlParameter("DOC_LOC_25_S1",WhereDoc_loc_25_s1),
					new SqlParameter("DOC_LOC_25_S2",WhereDoc_loc_25_s2),
					new SqlParameter("DOC_LOC_25_S3",WhereDoc_loc_25_s3),
					new SqlParameter("DOC_LOC_26_S1",WhereDoc_loc_26_s1),
					new SqlParameter("DOC_LOC_26_S2",WhereDoc_loc_26_s2),
					new SqlParameter("DOC_LOC_26_S3",WhereDoc_loc_26_s3),
					new SqlParameter("DOC_LOC_27_S1",WhereDoc_loc_27_s1),
					new SqlParameter("DOC_LOC_27_S2",WhereDoc_loc_27_s2),
					new SqlParameter("DOC_LOC_27_S3",WhereDoc_loc_27_s3),
					new SqlParameter("DOC_LOC_28_S1",WhereDoc_loc_28_s1),
					new SqlParameter("DOC_LOC_28_S2",WhereDoc_loc_28_s2),
					new SqlParameter("DOC_LOC_28_S3",WhereDoc_loc_28_s3),
					new SqlParameter("DOC_LOC_29_S1",WhereDoc_loc_29_s1),
					new SqlParameter("DOC_LOC_29_S2",WhereDoc_loc_29_s2),
					new SqlParameter("DOC_LOC_29_S3",WhereDoc_loc_29_s3),
					new SqlParameter("DOC_LOC_30_S1",WhereDoc_loc_30_s1),
					new SqlParameter("DOC_LOC_30_S2",WhereDoc_loc_30_s2),
					new SqlParameter("DOC_LOC_30_S3",WhereDoc_loc_30_s3),*/
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
            };

            Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_MSTR
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    DOC_NBR = Reader["DOC_NBR"].ToString(),
                    DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
                    DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
                    DOC_SIN_123 = ConvertDEC(Reader["DOC_SIN_123"]),
                    DOC_SIN_456 = ConvertDEC(Reader["DOC_SIN_456"]),
                    DOC_SIN_789 = ConvertDEC(Reader["DOC_SIN_789"]),
                    DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
                    DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString(),
                    DOC_NAME = Reader["DOC_NAME"].ToString(),
                    DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString(),
                    DOC_INIT1 = Reader["DOC_INIT1"].ToString(),
                    DOC_INIT2 = Reader["DOC_INIT2"].ToString(),
                    DOC_INIT3 = Reader["DOC_INIT3"].ToString(),
                    DOC_ADDR_OFFICE_1 = Reader["DOC_ADDR_OFFICE_1"].ToString(),
                    DOC_ADDR_OFFICE_2 = Reader["DOC_ADDR_OFFICE_2"].ToString(),
                    DOC_ADDR_OFFICE_3 = Reader["DOC_ADDR_OFFICE_3"].ToString(),
                    DOC_ADDR_OFFICE_PC1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString(),
                    DOC_ADDR_OFFICE_PC2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]),
                    DOC_ADDR_OFFICE_PC3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString(),
                    DOC_ADDR_OFFICE_PC4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]),
                    DOC_ADDR_OFFICE_PC5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString(),
                    DOC_ADDR_OFFICE_PC6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]),
                    DOC_ADDR_HOME_1 = Reader["DOC_ADDR_HOME_1"].ToString(),
                    DOC_ADDR_HOME_2 = Reader["DOC_ADDR_HOME_2"].ToString(),
                    DOC_ADDR_HOME_3 = Reader["DOC_ADDR_HOME_3"].ToString(),
                    DOC_ADDR_HOME_PC1 = Reader["DOC_ADDR_HOME_PC1"].ToString(),
                    DOC_ADDR_HOME_PC2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]),
                    DOC_ADDR_HOME_PC3 = Reader["DOC_ADDR_HOME_PC3"].ToString(),
                    DOC_ADDR_HOME_PC4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]),
                    DOC_ADDR_HOME_PC5 = Reader["DOC_ADDR_HOME_PC5"].ToString(),
                    DOC_ADDR_HOME_PC6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]),
                    DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
                    DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
                    DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
                    DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
                    DOC_DATE_FAC_START_YY = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]),
                    DOC_DATE_FAC_START_MM = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]),
                    DOC_DATE_FAC_START_DD = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]),
                    DOC_DATE_FAC_TERM_YY = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]),
                    DOC_DATE_FAC_TERM_MM = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]),
                    DOC_DATE_FAC_TERM_DD = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]),
                    DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]),
                    DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]),
                    DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]),
                    DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]),
                    DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]),
                    DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]),
                    DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]),
                    DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]),
                    DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]),
                    DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]),
                    DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
                    DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]),
                    DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
                    DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]),
                    DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]),
                    DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]),
                    DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]),
                    CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString(),
                    CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString(),
                    YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString(),
                    YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString(),
                    DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
                    DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
                    DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
                    DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
                    DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
                    DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
                    DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString(),
                    /*	DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
                        DOC_NX_AVAIL_BATCH_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]),
                        DOC_NX_AVAIL_BATCH_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]),
                        DOC_NX_AVAIL_BATCH_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]),
                        DOC_NX_AVAIL_BATCH_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]),
                        DOC_NX_AVAIL_BATCH_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]), */
                    DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
                    DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
                    DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
                    DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString(),
                    DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
                    DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
                    DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
                    DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
                    DOC_EP_PED = Reader["DOC_EP_PED"].ToString(),
                    DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
                    DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
                    DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString(),
                    DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
                    GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString(),
                    GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString(),
                    /*	DOC_LOC_1_S1 = Reader["DOC_LOC_1_S1"].ToString(),
                        DOC_LOC_1_S2 = Reader["DOC_LOC_1_S2"].ToString(),
                        DOC_LOC_1_S3 = Reader["DOC_LOC_1_S3"].ToString(),
                        DOC_LOC_2_S1 = Reader["DOC_LOC_2_S1"].ToString(),
                        DOC_LOC_2_S2 = Reader["DOC_LOC_2_S2"].ToString(),
                        DOC_LOC_2_S3 = Reader["DOC_LOC_2_S3"].ToString(),
                        DOC_LOC_3_S1 = Reader["DOC_LOC_3_S1"].ToString(),
                        DOC_LOC_3_S2 = Reader["DOC_LOC_3_S2"].ToString(),
                        DOC_LOC_3_S3 = Reader["DOC_LOC_3_S3"].ToString(),
                        DOC_LOC_4_S1 = Reader["DOC_LOC_4_S1"].ToString(),
                        DOC_LOC_4_S2 = Reader["DOC_LOC_4_S2"].ToString(),
                        DOC_LOC_4_S3 = Reader["DOC_LOC_4_S3"].ToString(),
                        DOC_LOC_5_S1 = Reader["DOC_LOC_5_S1"].ToString(),
                        DOC_LOC_5_S2 = Reader["DOC_LOC_5_S2"].ToString(),
                        DOC_LOC_5_S3 = Reader["DOC_LOC_5_S3"].ToString(),
                        DOC_LOC_6_S1 = Reader["DOC_LOC_6_S1"].ToString(),
                        DOC_LOC_6_S2 = Reader["DOC_LOC_6_S2"].ToString(),
                        DOC_LOC_6_S3 = Reader["DOC_LOC_6_S3"].ToString(),
                        DOC_LOC_7_S1 = Reader["DOC_LOC_7_S1"].ToString(),
                        DOC_LOC_7_S2 = Reader["DOC_LOC_7_S2"].ToString(),
                        DOC_LOC_7_S3 = Reader["DOC_LOC_7_S3"].ToString(),
                        DOC_LOC_8_S1 = Reader["DOC_LOC_8_S1"].ToString(),
                        DOC_LOC_8_S2 = Reader["DOC_LOC_8_S2"].ToString(),
                        DOC_LOC_8_S3 = Reader["DOC_LOC_8_S3"].ToString(),
                        DOC_LOC_9_S1 = Reader["DOC_LOC_9_S1"].ToString(),
                        DOC_LOC_9_S2 = Reader["DOC_LOC_9_S2"].ToString(),
                        DOC_LOC_9_S3 = Reader["DOC_LOC_9_S3"].ToString(),
                        DOC_LOC_10_S1 = Reader["DOC_LOC_10_S1"].ToString(),
                        DOC_LOC_10_S2 = Reader["DOC_LOC_10_S2"].ToString(),
                        DOC_LOC_10_S3 = Reader["DOC_LOC_10_S3"].ToString(),
                        DOC_LOC_11_S1 = Reader["DOC_LOC_11_S1"].ToString(),
                        DOC_LOC_11_S2 = Reader["DOC_LOC_11_S2"].ToString(),
                        DOC_LOC_11_S3 = Reader["DOC_LOC_11_S3"].ToString(),
                        DOC_LOC_12_S1 = Reader["DOC_LOC_12_S1"].ToString(),
                        DOC_LOC_12_S2 = Reader["DOC_LOC_12_S2"].ToString(),
                        DOC_LOC_12_S3 = Reader["DOC_LOC_12_S3"].ToString(),
                        DOC_LOC_13_S1 = Reader["DOC_LOC_13_S1"].ToString(),
                        DOC_LOC_13_S2 = Reader["DOC_LOC_13_S2"].ToString(),
                        DOC_LOC_13_S3 = Reader["DOC_LOC_13_S3"].ToString(),
                        DOC_LOC_14_S1 = Reader["DOC_LOC_14_S1"].ToString(),
                        DOC_LOC_14_S2 = Reader["DOC_LOC_14_S2"].ToString(),
                        DOC_LOC_14_S3 = Reader["DOC_LOC_14_S3"].ToString(),
                        DOC_LOC_15_S1 = Reader["DOC_LOC_15_S1"].ToString(),
                        DOC_LOC_15_S2 = Reader["DOC_LOC_15_S2"].ToString(),
                        DOC_LOC_15_S3 = Reader["DOC_LOC_15_S3"].ToString(),
                        DOC_LOC_16_S1 = Reader["DOC_LOC_16_S1"].ToString(),
                        DOC_LOC_16_S2 = Reader["DOC_LOC_16_S2"].ToString(),
                        DOC_LOC_16_S3 = Reader["DOC_LOC_16_S3"].ToString(),
                        DOC_LOC_17_S1 = Reader["DOC_LOC_17_S1"].ToString(),
                        DOC_LOC_17_S2 = Reader["DOC_LOC_17_S2"].ToString(),
                        DOC_LOC_17_S3 = Reader["DOC_LOC_17_S3"].ToString(),
                        DOC_LOC_18_S1 = Reader["DOC_LOC_18_S1"].ToString(),
                        DOC_LOC_18_S2 = Reader["DOC_LOC_18_S2"].ToString(),
                        DOC_LOC_18_S3 = Reader["DOC_LOC_18_S3"].ToString(),
                        DOC_LOC_19_S1 = Reader["DOC_LOC_19_S1"].ToString(),
                        DOC_LOC_19_S2 = Reader["DOC_LOC_19_S2"].ToString(),
                        DOC_LOC_19_S3 = Reader["DOC_LOC_19_S3"].ToString(),
                        DOC_LOC_20_S1 = Reader["DOC_LOC_20_S1"].ToString(),
                        DOC_LOC_20_S2 = Reader["DOC_LOC_20_S2"].ToString(),
                        DOC_LOC_20_S3 = Reader["DOC_LOC_20_S3"].ToString(),
                        DOC_LOC_21_S1 = Reader["DOC_LOC_21_S1"].ToString(),
                        DOC_LOC_21_S2 = Reader["DOC_LOC_21_S2"].ToString(),
                        DOC_LOC_21_S3 = Reader["DOC_LOC_21_S3"].ToString(),
                        DOC_LOC_22_S1 = Reader["DOC_LOC_22_S1"].ToString(),
                        DOC_LOC_22_S2 = Reader["DOC_LOC_22_S2"].ToString(),
                        DOC_LOC_22_S3 = Reader["DOC_LOC_22_S3"].ToString(),
                        DOC_LOC_23_S1 = Reader["DOC_LOC_23_S1"].ToString(),
                        DOC_LOC_23_S2 = Reader["DOC_LOC_23_S2"].ToString(),
                        DOC_LOC_23_S3 = Reader["DOC_LOC_23_S3"].ToString(),
                        DOC_LOC_24_S1 = Reader["DOC_LOC_24_S1"].ToString(),
                        DOC_LOC_24_S2 = Reader["DOC_LOC_24_S2"].ToString(),
                        DOC_LOC_24_S3 = Reader["DOC_LOC_24_S3"].ToString(),
                        DOC_LOC_25_S1 = Reader["DOC_LOC_25_S1"].ToString(),
                        DOC_LOC_25_S2 = Reader["DOC_LOC_25_S2"].ToString(),
                        DOC_LOC_25_S3 = Reader["DOC_LOC_25_S3"].ToString(),
                        DOC_LOC_26_S1 = Reader["DOC_LOC_26_S1"].ToString(),
                        DOC_LOC_26_S2 = Reader["DOC_LOC_26_S2"].ToString(),
                        DOC_LOC_26_S3 = Reader["DOC_LOC_26_S3"].ToString(),
                        DOC_LOC_27_S1 = Reader["DOC_LOC_27_S1"].ToString(),
                        DOC_LOC_27_S2 = Reader["DOC_LOC_27_S2"].ToString(),
                        DOC_LOC_27_S3 = Reader["DOC_LOC_27_S3"].ToString(),
                        DOC_LOC_28_S1 = Reader["DOC_LOC_28_S1"].ToString(),
                        DOC_LOC_28_S2 = Reader["DOC_LOC_28_S2"].ToString(),
                        DOC_LOC_28_S3 = Reader["DOC_LOC_28_S3"].ToString(),
                        DOC_LOC_29_S1 = Reader["DOC_LOC_29_S1"].ToString(),
                        DOC_LOC_29_S2 = Reader["DOC_LOC_29_S2"].ToString(),
                        DOC_LOC_29_S3 = Reader["DOC_LOC_29_S3"].ToString(),
                        DOC_LOC_30_S1 = Reader["DOC_LOC_30_S1"].ToString(),
                        DOC_LOC_30_S2 = Reader["DOC_LOC_30_S2"].ToString(),
                        DOC_LOC_30_S3 = Reader["DOC_LOC_30_S3"].ToString(), */
                    CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    _whereRowid = WhereRowid,
                    _whereDoc_nbr = WhereDoc_nbr,
                    _whereDoc_dept = WhereDoc_dept,
                    _whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
                    _whereDoc_sin_123 = WhereDoc_sin_123,
                    _whereDoc_sin_456 = WhereDoc_sin_456,
                    _whereDoc_sin_789 = WhereDoc_sin_789,
                    _whereDoc_spec_cd = WhereDoc_spec_cd,
                    _whereDoc_hosp_nbr = WhereDoc_hosp_nbr,
                    _whereDoc_name = WhereDoc_name,
                    _whereDoc_name_soundex = WhereDoc_name_soundex,
                    _whereDoc_init1 = WhereDoc_init1,
                    _whereDoc_init2 = WhereDoc_init2,
                    _whereDoc_init3 = WhereDoc_init3,
                    _whereDoc_addr_office_1 = WhereDoc_addr_office_1,
                    _whereDoc_addr_office_2 = WhereDoc_addr_office_2,
                    _whereDoc_addr_office_3 = WhereDoc_addr_office_3,
                    _whereDoc_addr_office_pc1 = WhereDoc_addr_office_pc1,
                    _whereDoc_addr_office_pc2 = WhereDoc_addr_office_pc2,
                    _whereDoc_addr_office_pc3 = WhereDoc_addr_office_pc3,
                    _whereDoc_addr_office_pc4 = WhereDoc_addr_office_pc4,
                    _whereDoc_addr_office_pc5 = WhereDoc_addr_office_pc5,
                    _whereDoc_addr_office_pc6 = WhereDoc_addr_office_pc6,
                    _whereDoc_addr_home_1 = WhereDoc_addr_home_1,
                    _whereDoc_addr_home_2 = WhereDoc_addr_home_2,
                    _whereDoc_addr_home_3 = WhereDoc_addr_home_3,
                    _whereDoc_addr_home_pc1 = WhereDoc_addr_home_pc1,
                    _whereDoc_addr_home_pc2 = WhereDoc_addr_home_pc2,
                    _whereDoc_addr_home_pc3 = WhereDoc_addr_home_pc3,
                    _whereDoc_addr_home_pc4 = WhereDoc_addr_home_pc4,
                    _whereDoc_addr_home_pc5 = WhereDoc_addr_home_pc5,
                    _whereDoc_addr_home_pc6 = WhereDoc_addr_home_pc6,
                    _whereDoc_full_part_ind = WhereDoc_full_part_ind,
                    _whereDoc_bank_nbr = WhereDoc_bank_nbr,
                    _whereDoc_bank_branch = WhereDoc_bank_branch,
                    _whereDoc_bank_acct = WhereDoc_bank_acct,
                    _whereDoc_date_fac_start_yy = WhereDoc_date_fac_start_yy,
                    _whereDoc_date_fac_start_mm = WhereDoc_date_fac_start_mm,
                    _whereDoc_date_fac_start_dd = WhereDoc_date_fac_start_dd,
                    _whereDoc_date_fac_term_yy = WhereDoc_date_fac_term_yy,
                    _whereDoc_date_fac_term_mm = WhereDoc_date_fac_term_mm,
                    _whereDoc_date_fac_term_dd = WhereDoc_date_fac_term_dd,
                    _whereDoc_ytdgua = WhereDoc_ytdgua,
                    _whereDoc_ytdgub = WhereDoc_ytdgub,
                    _whereDoc_ytdguc = WhereDoc_ytdguc,
                    _whereDoc_ytdgud = WhereDoc_ytdgud,
                    _whereDoc_ytdcea = WhereDoc_ytdcea,
                    _whereDoc_ytdcex = WhereDoc_ytdcex,
                    _whereDoc_ytdear = WhereDoc_ytdear,
                    _whereDoc_ytdinc = WhereDoc_ytdinc,
                    _whereDoc_ytdeft = WhereDoc_ytdeft,
                    _whereDoc_totinc_g = WhereDoc_totinc_g,
                    _whereDoc_ep_date_deposit = WhereDoc_ep_date_deposit,
                    _whereDoc_totinc = WhereDoc_totinc,
                    _whereDoc_ep_ceiexp = WhereDoc_ep_ceiexp,
                    _whereDoc_adjcea = WhereDoc_adjcea,
                    _whereDoc_adjcex = WhereDoc_adjcex,
                    _whereDoc_ceicea = WhereDoc_ceicea,
                    _whereDoc_ceicex = WhereDoc_ceicex,
                    _whereCeicea_prt_format = WhereCeicea_prt_format,
                    _whereCeicex_prt_format = WhereCeicex_prt_format,
                    _whereYtdcea_prt_format = WhereYtdcea_prt_format,
                    _whereYtdcex_prt_format = WhereYtdcex_prt_format,
                    _whereDoc_spec_cd_2 = WhereDoc_spec_cd_2,
                    _whereDoc_spec_cd_3 = WhereDoc_spec_cd_3,
                    _whereDoc_ytdinc_g = WhereDoc_ytdinc_g,
                    _whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc,
                    _whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
                    _whereDoc_dept_2 = WhereDoc_dept_2,
                    _whereDoc_ind_pays_gst = WhereDoc_ind_pays_gst,
                    /*	_whereDoc_nx_avail_batch = WhereDoc_nx_avail_batch,
                        _whereDoc_nx_avail_batch_2 = WhereDoc_nx_avail_batch_2,
                        _whereDoc_nx_avail_batch_3 = WhereDoc_nx_avail_batch_3,
                        _whereDoc_nx_avail_batch_4 = WhereDoc_nx_avail_batch_4,
                        _whereDoc_nx_avail_batch_5 = WhereDoc_nx_avail_batch_5,
                        _whereDoc_nx_avail_batch_6 = WhereDoc_nx_avail_batch_6, */
                    _whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed,
                    _whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed,
                    _whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg,
                    _whereDoc_sub_specialty = WhereDoc_sub_specialty,
                    _whereDoc_payeft = WhereDoc_payeft,
                    _whereDoc_ytdded = WhereDoc_ytdded,
                    _whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc,
                    _whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg,
                    _whereDoc_ep_ped = WhereDoc_ep_ped,
                    _whereDoc_ep_pay_code = WhereDoc_ep_pay_code,
                    _whereDoc_ep_pay_sub_code = WhereDoc_ep_pay_sub_code,
                    _whereDoc_partnership = WhereDoc_partnership,
                    _whereDoc_ind_holdback_active = WhereDoc_ind_holdback_active,
                    _whereGroup_regular_service = WhereGroup_regular_service,
                    _whereGroup_over_serviced = WhereGroup_over_serviced,
                    /*	_whereDoc_loc_1_s1 = WhereDoc_loc_1_s1,
                        _whereDoc_loc_1_s2 = WhereDoc_loc_1_s2,
                        _whereDoc_loc_1_s3 = WhereDoc_loc_1_s3,
                        _whereDoc_loc_2_s1 = WhereDoc_loc_2_s1,
                        _whereDoc_loc_2_s2 = WhereDoc_loc_2_s2,
                        _whereDoc_loc_2_s3 = WhereDoc_loc_2_s3,
                        _whereDoc_loc_3_s1 = WhereDoc_loc_3_s1,
                        _whereDoc_loc_3_s2 = WhereDoc_loc_3_s2,
                        _whereDoc_loc_3_s3 = WhereDoc_loc_3_s3,
                        _whereDoc_loc_4_s1 = WhereDoc_loc_4_s1,
                        _whereDoc_loc_4_s2 = WhereDoc_loc_4_s2,
                        _whereDoc_loc_4_s3 = WhereDoc_loc_4_s3,
                        _whereDoc_loc_5_s1 = WhereDoc_loc_5_s1,
                        _whereDoc_loc_5_s2 = WhereDoc_loc_5_s2,
                        _whereDoc_loc_5_s3 = WhereDoc_loc_5_s3,
                        _whereDoc_loc_6_s1 = WhereDoc_loc_6_s1,
                        _whereDoc_loc_6_s2 = WhereDoc_loc_6_s2,
                        _whereDoc_loc_6_s3 = WhereDoc_loc_6_s3,
                        _whereDoc_loc_7_s1 = WhereDoc_loc_7_s1,
                        _whereDoc_loc_7_s2 = WhereDoc_loc_7_s2,
                        _whereDoc_loc_7_s3 = WhereDoc_loc_7_s3,
                        _whereDoc_loc_8_s1 = WhereDoc_loc_8_s1,
                        _whereDoc_loc_8_s2 = WhereDoc_loc_8_s2,
                        _whereDoc_loc_8_s3 = WhereDoc_loc_8_s3,
                        _whereDoc_loc_9_s1 = WhereDoc_loc_9_s1,
                        _whereDoc_loc_9_s2 = WhereDoc_loc_9_s2,
                        _whereDoc_loc_9_s3 = WhereDoc_loc_9_s3,
                        _whereDoc_loc_10_s1 = WhereDoc_loc_10_s1,
                        _whereDoc_loc_10_s2 = WhereDoc_loc_10_s2,
                        _whereDoc_loc_10_s3 = WhereDoc_loc_10_s3,
                        _whereDoc_loc_11_s1 = WhereDoc_loc_11_s1,
                        _whereDoc_loc_11_s2 = WhereDoc_loc_11_s2,
                        _whereDoc_loc_11_s3 = WhereDoc_loc_11_s3,
                        _whereDoc_loc_12_s1 = WhereDoc_loc_12_s1,
                        _whereDoc_loc_12_s2 = WhereDoc_loc_12_s2,
                        _whereDoc_loc_12_s3 = WhereDoc_loc_12_s3,
                        _whereDoc_loc_13_s1 = WhereDoc_loc_13_s1,
                        _whereDoc_loc_13_s2 = WhereDoc_loc_13_s2,
                        _whereDoc_loc_13_s3 = WhereDoc_loc_13_s3,
                        _whereDoc_loc_14_s1 = WhereDoc_loc_14_s1,
                        _whereDoc_loc_14_s2 = WhereDoc_loc_14_s2,
                        _whereDoc_loc_14_s3 = WhereDoc_loc_14_s3,
                        _whereDoc_loc_15_s1 = WhereDoc_loc_15_s1,
                        _whereDoc_loc_15_s2 = WhereDoc_loc_15_s2,
                        _whereDoc_loc_15_s3 = WhereDoc_loc_15_s3,
                        _whereDoc_loc_16_s1 = WhereDoc_loc_16_s1,
                        _whereDoc_loc_16_s2 = WhereDoc_loc_16_s2,
                        _whereDoc_loc_16_s3 = WhereDoc_loc_16_s3,
                        _whereDoc_loc_17_s1 = WhereDoc_loc_17_s1,
                        _whereDoc_loc_17_s2 = WhereDoc_loc_17_s2,
                        _whereDoc_loc_17_s3 = WhereDoc_loc_17_s3,
                        _whereDoc_loc_18_s1 = WhereDoc_loc_18_s1,
                        _whereDoc_loc_18_s2 = WhereDoc_loc_18_s2,
                        _whereDoc_loc_18_s3 = WhereDoc_loc_18_s3,
                        _whereDoc_loc_19_s1 = WhereDoc_loc_19_s1,
                        _whereDoc_loc_19_s2 = WhereDoc_loc_19_s2,
                        _whereDoc_loc_19_s3 = WhereDoc_loc_19_s3,
                        _whereDoc_loc_20_s1 = WhereDoc_loc_20_s1,
                        _whereDoc_loc_20_s2 = WhereDoc_loc_20_s2,
                        _whereDoc_loc_20_s3 = WhereDoc_loc_20_s3,
                        _whereDoc_loc_21_s1 = WhereDoc_loc_21_s1,
                        _whereDoc_loc_21_s2 = WhereDoc_loc_21_s2,
                        _whereDoc_loc_21_s3 = WhereDoc_loc_21_s3,
                        _whereDoc_loc_22_s1 = WhereDoc_loc_22_s1,
                        _whereDoc_loc_22_s2 = WhereDoc_loc_22_s2,
                        _whereDoc_loc_22_s3 = WhereDoc_loc_22_s3,
                        _whereDoc_loc_23_s1 = WhereDoc_loc_23_s1,
                        _whereDoc_loc_23_s2 = WhereDoc_loc_23_s2,
                        _whereDoc_loc_23_s3 = WhereDoc_loc_23_s3,
                        _whereDoc_loc_24_s1 = WhereDoc_loc_24_s1,
                        _whereDoc_loc_24_s2 = WhereDoc_loc_24_s2,
                        _whereDoc_loc_24_s3 = WhereDoc_loc_24_s3,
                        _whereDoc_loc_25_s1 = WhereDoc_loc_25_s1,
                        _whereDoc_loc_25_s2 = WhereDoc_loc_25_s2,
                        _whereDoc_loc_25_s3 = WhereDoc_loc_25_s3,
                        _whereDoc_loc_26_s1 = WhereDoc_loc_26_s1,
                        _whereDoc_loc_26_s2 = WhereDoc_loc_26_s2,
                        _whereDoc_loc_26_s3 = WhereDoc_loc_26_s3,
                        _whereDoc_loc_27_s1 = WhereDoc_loc_27_s1,
                        _whereDoc_loc_27_s2 = WhereDoc_loc_27_s2,
                        _whereDoc_loc_27_s3 = WhereDoc_loc_27_s3,
                        _whereDoc_loc_28_s1 = WhereDoc_loc_28_s1,
                        _whereDoc_loc_28_s2 = WhereDoc_loc_28_s2,
                        _whereDoc_loc_28_s3 = WhereDoc_loc_28_s3,
                        _whereDoc_loc_29_s1 = WhereDoc_loc_29_s1,
                        _whereDoc_loc_29_s2 = WhereDoc_loc_29_s2,
                        _whereDoc_loc_29_s3 = WhereDoc_loc_29_s3,
                        _whereDoc_loc_30_s1 = WhereDoc_loc_30_s1,
                        _whereDoc_loc_30_s2 = WhereDoc_loc_30_s2,
                        _whereDoc_loc_30_s3 = WhereDoc_loc_30_s3, */
                    _whereChecksum_value = WhereChecksum_value,

                    _originalRowid = (Guid)Reader["ROWID"],
                    _originalDoc_nbr = Reader["DOC_NBR"].ToString(),
                    _originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
                    _originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
                    _originalDoc_sin_123 = ConvertDEC(Reader["DOC_SIN_123"]),
                    _originalDoc_sin_456 = ConvertDEC(Reader["DOC_SIN_456"]),
                    _originalDoc_sin_789 = ConvertDEC(Reader["DOC_SIN_789"]),
                    _originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
                    _originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString(),
                    _originalDoc_name = Reader["DOC_NAME"].ToString(),
                    _originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString(),
                    _originalDoc_init1 = Reader["DOC_INIT1"].ToString(),
                    _originalDoc_init2 = Reader["DOC_INIT2"].ToString(),
                    _originalDoc_init3 = Reader["DOC_INIT3"].ToString(),
                    _originalDoc_addr_office_1 = Reader["DOC_ADDR_OFFICE_1"].ToString(),
                    _originalDoc_addr_office_2 = Reader["DOC_ADDR_OFFICE_2"].ToString(),
                    _originalDoc_addr_office_3 = Reader["DOC_ADDR_OFFICE_3"].ToString(),
                    _originalDoc_addr_office_pc1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString(),
                    _originalDoc_addr_office_pc2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]),
                    _originalDoc_addr_office_pc3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString(),
                    _originalDoc_addr_office_pc4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]),
                    _originalDoc_addr_office_pc5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString(),
                    _originalDoc_addr_office_pc6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]),
                    _originalDoc_addr_home_1 = Reader["DOC_ADDR_HOME_1"].ToString(),
                    _originalDoc_addr_home_2 = Reader["DOC_ADDR_HOME_2"].ToString(),
                    _originalDoc_addr_home_3 = Reader["DOC_ADDR_HOME_3"].ToString(),
                    _originalDoc_addr_home_pc1 = Reader["DOC_ADDR_HOME_PC1"].ToString(),
                    _originalDoc_addr_home_pc2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]),
                    _originalDoc_addr_home_pc3 = Reader["DOC_ADDR_HOME_PC3"].ToString(),
                    _originalDoc_addr_home_pc4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]),
                    _originalDoc_addr_home_pc5 = Reader["DOC_ADDR_HOME_PC5"].ToString(),
                    _originalDoc_addr_home_pc6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]),
                    _originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
                    _originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
                    _originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
                    _originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
                    _originalDoc_date_fac_start_yy = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]),
                    _originalDoc_date_fac_start_mm = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]),
                    _originalDoc_date_fac_start_dd = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]),
                    _originalDoc_date_fac_term_yy = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]),
                    _originalDoc_date_fac_term_mm = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]),
                    _originalDoc_date_fac_term_dd = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]),
                    _originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]),
                    _originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]),
                    _originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]),
                    _originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]),
                    _originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]),
                    _originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]),
                    _originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]),
                    _originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]),
                    _originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]),
                    _originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]),
                    _originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]),
                    _originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]),
                    _originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]),
                    _originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]),
                    _originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]),
                    _originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]),
                    _originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]),
                    _originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString(),
                    _originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString(),
                    _originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString(),
                    _originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString(),
                    _originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
                    _originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
                    _originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
                    _originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString(),
                    _originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
                    _originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
                    _originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString(),
                    /*	_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]),
                        _originalDoc_nx_avail_batch_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]),
                        _originalDoc_nx_avail_batch_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]),
                        _originalDoc_nx_avail_batch_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]),
                        _originalDoc_nx_avail_batch_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]),
                        _originalDoc_nx_avail_batch_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]), */
                    _originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
                    _originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
                    _originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString(),
                    _originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString(),
                    _originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
                    _originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
                    _originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString(),
                    _originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString(),
                    _originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString(),
                    _originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
                    _originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
                    _originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString(),
                    _originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
                    _originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString(),
                    _originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString(),
                    /*	_originalDoc_loc_1_s1 = Reader["DOC_LOC_1_S1"].ToString(),
                        _originalDoc_loc_1_s2 = Reader["DOC_LOC_1_S2"].ToString(),
                        _originalDoc_loc_1_s3 = Reader["DOC_LOC_1_S3"].ToString(),
                        _originalDoc_loc_2_s1 = Reader["DOC_LOC_2_S1"].ToString(),
                        _originalDoc_loc_2_s2 = Reader["DOC_LOC_2_S2"].ToString(),
                        _originalDoc_loc_2_s3 = Reader["DOC_LOC_2_S3"].ToString(),
                        _originalDoc_loc_3_s1 = Reader["DOC_LOC_3_S1"].ToString(),
                        _originalDoc_loc_3_s2 = Reader["DOC_LOC_3_S2"].ToString(),
                        _originalDoc_loc_3_s3 = Reader["DOC_LOC_3_S3"].ToString(),
                        _originalDoc_loc_4_s1 = Reader["DOC_LOC_4_S1"].ToString(),
                        _originalDoc_loc_4_s2 = Reader["DOC_LOC_4_S2"].ToString(),
                        _originalDoc_loc_4_s3 = Reader["DOC_LOC_4_S3"].ToString(),
                        _originalDoc_loc_5_s1 = Reader["DOC_LOC_5_S1"].ToString(),
                        _originalDoc_loc_5_s2 = Reader["DOC_LOC_5_S2"].ToString(),
                        _originalDoc_loc_5_s3 = Reader["DOC_LOC_5_S3"].ToString(),
                        _originalDoc_loc_6_s1 = Reader["DOC_LOC_6_S1"].ToString(),
                        _originalDoc_loc_6_s2 = Reader["DOC_LOC_6_S2"].ToString(),
                        _originalDoc_loc_6_s3 = Reader["DOC_LOC_6_S3"].ToString(),
                        _originalDoc_loc_7_s1 = Reader["DOC_LOC_7_S1"].ToString(),
                        _originalDoc_loc_7_s2 = Reader["DOC_LOC_7_S2"].ToString(),
                        _originalDoc_loc_7_s3 = Reader["DOC_LOC_7_S3"].ToString(),
                        _originalDoc_loc_8_s1 = Reader["DOC_LOC_8_S1"].ToString(),
                        _originalDoc_loc_8_s2 = Reader["DOC_LOC_8_S2"].ToString(),
                        _originalDoc_loc_8_s3 = Reader["DOC_LOC_8_S3"].ToString(),
                        _originalDoc_loc_9_s1 = Reader["DOC_LOC_9_S1"].ToString(),
                        _originalDoc_loc_9_s2 = Reader["DOC_LOC_9_S2"].ToString(),
                        _originalDoc_loc_9_s3 = Reader["DOC_LOC_9_S3"].ToString(),
                        _originalDoc_loc_10_s1 = Reader["DOC_LOC_10_S1"].ToString(),
                        _originalDoc_loc_10_s2 = Reader["DOC_LOC_10_S2"].ToString(),
                        _originalDoc_loc_10_s3 = Reader["DOC_LOC_10_S3"].ToString(),
                        _originalDoc_loc_11_s1 = Reader["DOC_LOC_11_S1"].ToString(),
                        _originalDoc_loc_11_s2 = Reader["DOC_LOC_11_S2"].ToString(),
                        _originalDoc_loc_11_s3 = Reader["DOC_LOC_11_S3"].ToString(),
                        _originalDoc_loc_12_s1 = Reader["DOC_LOC_12_S1"].ToString(),
                        _originalDoc_loc_12_s2 = Reader["DOC_LOC_12_S2"].ToString(),
                        _originalDoc_loc_12_s3 = Reader["DOC_LOC_12_S3"].ToString(),
                        _originalDoc_loc_13_s1 = Reader["DOC_LOC_13_S1"].ToString(),
                        _originalDoc_loc_13_s2 = Reader["DOC_LOC_13_S2"].ToString(),
                        _originalDoc_loc_13_s3 = Reader["DOC_LOC_13_S3"].ToString(),
                        _originalDoc_loc_14_s1 = Reader["DOC_LOC_14_S1"].ToString(),
                        _originalDoc_loc_14_s2 = Reader["DOC_LOC_14_S2"].ToString(),
                        _originalDoc_loc_14_s3 = Reader["DOC_LOC_14_S3"].ToString(),
                        _originalDoc_loc_15_s1 = Reader["DOC_LOC_15_S1"].ToString(),
                        _originalDoc_loc_15_s2 = Reader["DOC_LOC_15_S2"].ToString(),
                        _originalDoc_loc_15_s3 = Reader["DOC_LOC_15_S3"].ToString(),
                        _originalDoc_loc_16_s1 = Reader["DOC_LOC_16_S1"].ToString(),
                        _originalDoc_loc_16_s2 = Reader["DOC_LOC_16_S2"].ToString(),
                        _originalDoc_loc_16_s3 = Reader["DOC_LOC_16_S3"].ToString(),
                        _originalDoc_loc_17_s1 = Reader["DOC_LOC_17_S1"].ToString(),
                        _originalDoc_loc_17_s2 = Reader["DOC_LOC_17_S2"].ToString(),
                        _originalDoc_loc_17_s3 = Reader["DOC_LOC_17_S3"].ToString(),
                        _originalDoc_loc_18_s1 = Reader["DOC_LOC_18_S1"].ToString(),
                        _originalDoc_loc_18_s2 = Reader["DOC_LOC_18_S2"].ToString(),
                        _originalDoc_loc_18_s3 = Reader["DOC_LOC_18_S3"].ToString(),
                        _originalDoc_loc_19_s1 = Reader["DOC_LOC_19_S1"].ToString(),
                        _originalDoc_loc_19_s2 = Reader["DOC_LOC_19_S2"].ToString(),
                        _originalDoc_loc_19_s3 = Reader["DOC_LOC_19_S3"].ToString(),
                        _originalDoc_loc_20_s1 = Reader["DOC_LOC_20_S1"].ToString(),
                        _originalDoc_loc_20_s2 = Reader["DOC_LOC_20_S2"].ToString(),
                        _originalDoc_loc_20_s3 = Reader["DOC_LOC_20_S3"].ToString(),
                        _originalDoc_loc_21_s1 = Reader["DOC_LOC_21_S1"].ToString(),
                        _originalDoc_loc_21_s2 = Reader["DOC_LOC_21_S2"].ToString(),
                        _originalDoc_loc_21_s3 = Reader["DOC_LOC_21_S3"].ToString(),
                        _originalDoc_loc_22_s1 = Reader["DOC_LOC_22_S1"].ToString(),
                        _originalDoc_loc_22_s2 = Reader["DOC_LOC_22_S2"].ToString(),
                        _originalDoc_loc_22_s3 = Reader["DOC_LOC_22_S3"].ToString(),
                        _originalDoc_loc_23_s1 = Reader["DOC_LOC_23_S1"].ToString(),
                        _originalDoc_loc_23_s2 = Reader["DOC_LOC_23_S2"].ToString(),
                        _originalDoc_loc_23_s3 = Reader["DOC_LOC_23_S3"].ToString(),
                        _originalDoc_loc_24_s1 = Reader["DOC_LOC_24_S1"].ToString(),
                        _originalDoc_loc_24_s2 = Reader["DOC_LOC_24_S2"].ToString(),
                        _originalDoc_loc_24_s3 = Reader["DOC_LOC_24_S3"].ToString(),
                        _originalDoc_loc_25_s1 = Reader["DOC_LOC_25_S1"].ToString(),
                        _originalDoc_loc_25_s2 = Reader["DOC_LOC_25_S2"].ToString(),
                        _originalDoc_loc_25_s3 = Reader["DOC_LOC_25_S3"].ToString(),
                        _originalDoc_loc_26_s1 = Reader["DOC_LOC_26_S1"].ToString(),
                        _originalDoc_loc_26_s2 = Reader["DOC_LOC_26_S2"].ToString(),
                        _originalDoc_loc_26_s3 = Reader["DOC_LOC_26_S3"].ToString(),
                        _originalDoc_loc_27_s1 = Reader["DOC_LOC_27_S1"].ToString(),
                        _originalDoc_loc_27_s2 = Reader["DOC_LOC_27_S2"].ToString(),
                        _originalDoc_loc_27_s3 = Reader["DOC_LOC_27_S3"].ToString(),
                        _originalDoc_loc_28_s1 = Reader["DOC_LOC_28_S1"].ToString(),
                        _originalDoc_loc_28_s2 = Reader["DOC_LOC_28_S2"].ToString(),
                        _originalDoc_loc_28_s3 = Reader["DOC_LOC_28_S3"].ToString(),
                        _originalDoc_loc_29_s1 = Reader["DOC_LOC_29_S1"].ToString(),
                        _originalDoc_loc_29_s2 = Reader["DOC_LOC_29_S2"].ToString(),
                        _originalDoc_loc_29_s3 = Reader["DOC_LOC_29_S3"].ToString(),
                        _originalDoc_loc_30_s1 = Reader["DOC_LOC_30_S1"].ToString(),
                        _originalDoc_loc_30_s2 = Reader["DOC_LOC_30_S2"].ToString(),
                        _originalDoc_loc_30_s3 = Reader["DOC_LOC_30_S3"].ToString(), */
                    _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            _whereRowid = WhereRowid;
            _whereDoc_nbr = WhereDoc_nbr;
            _whereDoc_dept = WhereDoc_dept;
            _whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
            _whereDoc_sin_123 = WhereDoc_sin_123;
            _whereDoc_sin_456 = WhereDoc_sin_456;
            _whereDoc_sin_789 = WhereDoc_sin_789;
            _whereDoc_spec_cd = WhereDoc_spec_cd;
            _whereDoc_hosp_nbr = WhereDoc_hosp_nbr;
            _whereDoc_name = WhereDoc_name;
            _whereDoc_name_soundex = WhereDoc_name_soundex;
            _whereDoc_init1 = WhereDoc_init1;
            _whereDoc_init2 = WhereDoc_init2;
            _whereDoc_init3 = WhereDoc_init3;
            _whereDoc_addr_office_1 = WhereDoc_addr_office_1;
            _whereDoc_addr_office_2 = WhereDoc_addr_office_2;
            _whereDoc_addr_office_3 = WhereDoc_addr_office_3;
            _whereDoc_addr_office_pc1 = WhereDoc_addr_office_pc1;
            _whereDoc_addr_office_pc2 = WhereDoc_addr_office_pc2;
            _whereDoc_addr_office_pc3 = WhereDoc_addr_office_pc3;
            _whereDoc_addr_office_pc4 = WhereDoc_addr_office_pc4;
            _whereDoc_addr_office_pc5 = WhereDoc_addr_office_pc5;
            _whereDoc_addr_office_pc6 = WhereDoc_addr_office_pc6;
            _whereDoc_addr_home_1 = WhereDoc_addr_home_1;
            _whereDoc_addr_home_2 = WhereDoc_addr_home_2;
            _whereDoc_addr_home_3 = WhereDoc_addr_home_3;
            _whereDoc_addr_home_pc1 = WhereDoc_addr_home_pc1;
            _whereDoc_addr_home_pc2 = WhereDoc_addr_home_pc2;
            _whereDoc_addr_home_pc3 = WhereDoc_addr_home_pc3;
            _whereDoc_addr_home_pc4 = WhereDoc_addr_home_pc4;
            _whereDoc_addr_home_pc5 = WhereDoc_addr_home_pc5;
            _whereDoc_addr_home_pc6 = WhereDoc_addr_home_pc6;
            _whereDoc_full_part_ind = WhereDoc_full_part_ind;
            _whereDoc_bank_nbr = WhereDoc_bank_nbr;
            _whereDoc_bank_branch = WhereDoc_bank_branch;
            _whereDoc_bank_acct = WhereDoc_bank_acct;
            _whereDoc_date_fac_start_yy = WhereDoc_date_fac_start_yy;
            _whereDoc_date_fac_start_mm = WhereDoc_date_fac_start_mm;
            _whereDoc_date_fac_start_dd = WhereDoc_date_fac_start_dd;
            _whereDoc_date_fac_term_yy = WhereDoc_date_fac_term_yy;
            _whereDoc_date_fac_term_mm = WhereDoc_date_fac_term_mm;
            _whereDoc_date_fac_term_dd = WhereDoc_date_fac_term_dd;
            _whereDoc_ytdgua = WhereDoc_ytdgua;
            _whereDoc_ytdgub = WhereDoc_ytdgub;
            _whereDoc_ytdguc = WhereDoc_ytdguc;
            _whereDoc_ytdgud = WhereDoc_ytdgud;
            _whereDoc_ytdcea = WhereDoc_ytdcea;
            _whereDoc_ytdcex = WhereDoc_ytdcex;
            _whereDoc_ytdear = WhereDoc_ytdear;
            _whereDoc_ytdinc = WhereDoc_ytdinc;
            _whereDoc_ytdeft = WhereDoc_ytdeft;
            _whereDoc_totinc_g = WhereDoc_totinc_g;
            _whereDoc_ep_date_deposit = WhereDoc_ep_date_deposit;
            _whereDoc_totinc = WhereDoc_totinc;
            _whereDoc_ep_ceiexp = WhereDoc_ep_ceiexp;
            _whereDoc_adjcea = WhereDoc_adjcea;
            _whereDoc_adjcex = WhereDoc_adjcex;
            _whereDoc_ceicea = WhereDoc_ceicea;
            _whereDoc_ceicex = WhereDoc_ceicex;
            _whereCeicea_prt_format = WhereCeicea_prt_format;
            _whereCeicex_prt_format = WhereCeicex_prt_format;
            _whereYtdcea_prt_format = WhereYtdcea_prt_format;
            _whereYtdcex_prt_format = WhereYtdcex_prt_format;
            _whereDoc_spec_cd_2 = WhereDoc_spec_cd_2;
            _whereDoc_spec_cd_3 = WhereDoc_spec_cd_3;
            _whereDoc_ytdinc_g = WhereDoc_ytdinc_g;
            _whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc;
            _whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
            _whereDoc_dept_2 = WhereDoc_dept_2;
            _whereDoc_ind_pays_gst = WhereDoc_ind_pays_gst;
            /*	_whereDoc_nx_avail_batch = WhereDoc_nx_avail_batch;
                _whereDoc_nx_avail_batch_2 = WhereDoc_nx_avail_batch_2;
                _whereDoc_nx_avail_batch_3 = WhereDoc_nx_avail_batch_3;
                _whereDoc_nx_avail_batch_4 = WhereDoc_nx_avail_batch_4;
                _whereDoc_nx_avail_batch_5 = WhereDoc_nx_avail_batch_5;
                _whereDoc_nx_avail_batch_6 = WhereDoc_nx_avail_batch_6; */
            _whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed;
            _whereDoc_yrly_expense_computed = WhereDoc_yrly_expense_computed;
            _whereDoc_rma_expense_percent_reg = WhereDoc_rma_expense_percent_reg;
            _whereDoc_sub_specialty = WhereDoc_sub_specialty;
            _whereDoc_payeft = WhereDoc_payeft;
            _whereDoc_ytdded = WhereDoc_ytdded;
            _whereDoc_dept_expense_percent_misc = WhereDoc_dept_expense_percent_misc;
            _whereDoc_dept_expense_percent_reg = WhereDoc_dept_expense_percent_reg;
            _whereDoc_ep_ped = WhereDoc_ep_ped;
            _whereDoc_ep_pay_code = WhereDoc_ep_pay_code;
            _whereDoc_ep_pay_sub_code = WhereDoc_ep_pay_sub_code;
            _whereDoc_partnership = WhereDoc_partnership;
            _whereDoc_ind_holdback_active = WhereDoc_ind_holdback_active;
            _whereGroup_regular_service = WhereGroup_regular_service;
            _whereGroup_over_serviced = WhereGroup_over_serviced;
            /*	_whereDoc_loc_1_s1 = WhereDoc_loc_1_s1;
                _whereDoc_loc_1_s2 = WhereDoc_loc_1_s2;
                _whereDoc_loc_1_s3 = WhereDoc_loc_1_s3;
                _whereDoc_loc_2_s1 = WhereDoc_loc_2_s1;
                _whereDoc_loc_2_s2 = WhereDoc_loc_2_s2;
                _whereDoc_loc_2_s3 = WhereDoc_loc_2_s3;
                _whereDoc_loc_3_s1 = WhereDoc_loc_3_s1;
                _whereDoc_loc_3_s2 = WhereDoc_loc_3_s2;
                _whereDoc_loc_3_s3 = WhereDoc_loc_3_s3;
                _whereDoc_loc_4_s1 = WhereDoc_loc_4_s1;
                _whereDoc_loc_4_s2 = WhereDoc_loc_4_s2;
                _whereDoc_loc_4_s3 = WhereDoc_loc_4_s3;
                _whereDoc_loc_5_s1 = WhereDoc_loc_5_s1;
                _whereDoc_loc_5_s2 = WhereDoc_loc_5_s2;
                _whereDoc_loc_5_s3 = WhereDoc_loc_5_s3;
                _whereDoc_loc_6_s1 = WhereDoc_loc_6_s1;
                _whereDoc_loc_6_s2 = WhereDoc_loc_6_s2;
                _whereDoc_loc_6_s3 = WhereDoc_loc_6_s3;
                _whereDoc_loc_7_s1 = WhereDoc_loc_7_s1;
                _whereDoc_loc_7_s2 = WhereDoc_loc_7_s2;
                _whereDoc_loc_7_s3 = WhereDoc_loc_7_s3;
                _whereDoc_loc_8_s1 = WhereDoc_loc_8_s1;
                _whereDoc_loc_8_s2 = WhereDoc_loc_8_s2;
                _whereDoc_loc_8_s3 = WhereDoc_loc_8_s3;
                _whereDoc_loc_9_s1 = WhereDoc_loc_9_s1;
                _whereDoc_loc_9_s2 = WhereDoc_loc_9_s2;
                _whereDoc_loc_9_s3 = WhereDoc_loc_9_s3;
                _whereDoc_loc_10_s1 = WhereDoc_loc_10_s1;
                _whereDoc_loc_10_s2 = WhereDoc_loc_10_s2;
                _whereDoc_loc_10_s3 = WhereDoc_loc_10_s3;
                _whereDoc_loc_11_s1 = WhereDoc_loc_11_s1;
                _whereDoc_loc_11_s2 = WhereDoc_loc_11_s2;
                _whereDoc_loc_11_s3 = WhereDoc_loc_11_s3;
                _whereDoc_loc_12_s1 = WhereDoc_loc_12_s1;
                _whereDoc_loc_12_s2 = WhereDoc_loc_12_s2;
                _whereDoc_loc_12_s3 = WhereDoc_loc_12_s3;
                _whereDoc_loc_13_s1 = WhereDoc_loc_13_s1;
                _whereDoc_loc_13_s2 = WhereDoc_loc_13_s2;
                _whereDoc_loc_13_s3 = WhereDoc_loc_13_s3;
                _whereDoc_loc_14_s1 = WhereDoc_loc_14_s1;
                _whereDoc_loc_14_s2 = WhereDoc_loc_14_s2;
                _whereDoc_loc_14_s3 = WhereDoc_loc_14_s3;
                _whereDoc_loc_15_s1 = WhereDoc_loc_15_s1;
                _whereDoc_loc_15_s2 = WhereDoc_loc_15_s2;
                _whereDoc_loc_15_s3 = WhereDoc_loc_15_s3;
                _whereDoc_loc_16_s1 = WhereDoc_loc_16_s1;
                _whereDoc_loc_16_s2 = WhereDoc_loc_16_s2;
                _whereDoc_loc_16_s3 = WhereDoc_loc_16_s3;
                _whereDoc_loc_17_s1 = WhereDoc_loc_17_s1;
                _whereDoc_loc_17_s2 = WhereDoc_loc_17_s2;
                _whereDoc_loc_17_s3 = WhereDoc_loc_17_s3;
                _whereDoc_loc_18_s1 = WhereDoc_loc_18_s1;
                _whereDoc_loc_18_s2 = WhereDoc_loc_18_s2;
                _whereDoc_loc_18_s3 = WhereDoc_loc_18_s3;
                _whereDoc_loc_19_s1 = WhereDoc_loc_19_s1;
                _whereDoc_loc_19_s2 = WhereDoc_loc_19_s2;
                _whereDoc_loc_19_s3 = WhereDoc_loc_19_s3;
                _whereDoc_loc_20_s1 = WhereDoc_loc_20_s1;
                _whereDoc_loc_20_s2 = WhereDoc_loc_20_s2;
                _whereDoc_loc_20_s3 = WhereDoc_loc_20_s3;
                _whereDoc_loc_21_s1 = WhereDoc_loc_21_s1;
                _whereDoc_loc_21_s2 = WhereDoc_loc_21_s2;
                _whereDoc_loc_21_s3 = WhereDoc_loc_21_s3;
                _whereDoc_loc_22_s1 = WhereDoc_loc_22_s1;
                _whereDoc_loc_22_s2 = WhereDoc_loc_22_s2;
                _whereDoc_loc_22_s3 = WhereDoc_loc_22_s3;
                _whereDoc_loc_23_s1 = WhereDoc_loc_23_s1;
                _whereDoc_loc_23_s2 = WhereDoc_loc_23_s2;
                _whereDoc_loc_23_s3 = WhereDoc_loc_23_s3;
                _whereDoc_loc_24_s1 = WhereDoc_loc_24_s1;
                _whereDoc_loc_24_s2 = WhereDoc_loc_24_s2;
                _whereDoc_loc_24_s3 = WhereDoc_loc_24_s3;
                _whereDoc_loc_25_s1 = WhereDoc_loc_25_s1;
                _whereDoc_loc_25_s2 = WhereDoc_loc_25_s2;
                _whereDoc_loc_25_s3 = WhereDoc_loc_25_s3;
                _whereDoc_loc_26_s1 = WhereDoc_loc_26_s1;
                _whereDoc_loc_26_s2 = WhereDoc_loc_26_s2;
                _whereDoc_loc_26_s3 = WhereDoc_loc_26_s3;
                _whereDoc_loc_27_s1 = WhereDoc_loc_27_s1;
                _whereDoc_loc_27_s2 = WhereDoc_loc_27_s2;
                _whereDoc_loc_27_s3 = WhereDoc_loc_27_s3;
                _whereDoc_loc_28_s1 = WhereDoc_loc_28_s1;
                _whereDoc_loc_28_s2 = WhereDoc_loc_28_s2;
                _whereDoc_loc_28_s3 = WhereDoc_loc_28_s3;
                _whereDoc_loc_29_s1 = WhereDoc_loc_29_s1;
                _whereDoc_loc_29_s2 = WhereDoc_loc_29_s2;
                _whereDoc_loc_29_s3 = WhereDoc_loc_29_s3;
                _whereDoc_loc_30_s1 = WhereDoc_loc_30_s1;
                _whereDoc_loc_30_s2 = WhereDoc_loc_30_s2;
                _whereDoc_loc_30_s3 = WhereDoc_loc_30_s3; */
            _whereChecksum_value = WhereChecksum_value;


            ClearSearch();
            CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null
                && WhereDoc_nbr == null
                && WhereDoc_dept == null
                && WhereDoc_ohip_nbr == null
                && WhereDoc_sin_123 == null
                && WhereDoc_sin_456 == null
                && WhereDoc_sin_789 == null
                && WhereDoc_spec_cd == null
                && WhereDoc_hosp_nbr == null
                && WhereDoc_name == null
                && WhereDoc_name_soundex == null
                && WhereDoc_init1 == null
                && WhereDoc_init2 == null
                && WhereDoc_init3 == null
                && WhereDoc_addr_office_1 == null
                && WhereDoc_addr_office_2 == null
                && WhereDoc_addr_office_3 == null
                && WhereDoc_addr_office_pc1 == null
                && WhereDoc_addr_office_pc2 == null
                && WhereDoc_addr_office_pc3 == null
                && WhereDoc_addr_office_pc4 == null
                && WhereDoc_addr_office_pc5 == null
                && WhereDoc_addr_office_pc6 == null
                && WhereDoc_addr_home_1 == null
                && WhereDoc_addr_home_2 == null
                && WhereDoc_addr_home_3 == null
                && WhereDoc_addr_home_pc1 == null
                && WhereDoc_addr_home_pc2 == null
                && WhereDoc_addr_home_pc3 == null
                && WhereDoc_addr_home_pc4 == null
                && WhereDoc_addr_home_pc5 == null
                && WhereDoc_addr_home_pc6 == null
                && WhereDoc_full_part_ind == null
                && WhereDoc_bank_nbr == null
                && WhereDoc_bank_branch == null
                && WhereDoc_bank_acct == null
                && WhereDoc_date_fac_start_yy == null
                && WhereDoc_date_fac_start_mm == null
                && WhereDoc_date_fac_start_dd == null
                && WhereDoc_date_fac_term_yy == null
                && WhereDoc_date_fac_term_mm == null
                && WhereDoc_date_fac_term_dd == null
                && WhereDoc_ytdgua == null
                && WhereDoc_ytdgub == null
                && WhereDoc_ytdguc == null
                && WhereDoc_ytdgud == null
                && WhereDoc_ytdcea == null
                && WhereDoc_ytdcex == null
                && WhereDoc_ytdear == null
                && WhereDoc_ytdinc == null
                && WhereDoc_ytdeft == null
                && WhereDoc_totinc_g == null
                && WhereDoc_ep_date_deposit == null
                && WhereDoc_totinc == null
                && WhereDoc_ep_ceiexp == null
                && WhereDoc_adjcea == null
                && WhereDoc_adjcex == null
                && WhereDoc_ceicea == null
                && WhereDoc_ceicex == null
                && WhereCeicea_prt_format == null
                && WhereCeicex_prt_format == null
                && WhereYtdcea_prt_format == null
                && WhereYtdcex_prt_format == null
                && WhereDoc_spec_cd_2 == null
                && WhereDoc_spec_cd_3 == null
                && WhereDoc_ytdinc_g == null
                && WhereDoc_rma_expense_percent_misc == null
                && WhereDoc_afp_paym_group == null
                && WhereDoc_dept_2 == null
                && WhereDoc_ind_pays_gst == null
                && WhereDoc_nx_avail_batch == null
                && WhereDoc_nx_avail_batch_2 == null
                && WhereDoc_nx_avail_batch_3 == null
                && WhereDoc_nx_avail_batch_4 == null
                && WhereDoc_nx_avail_batch_5 == null
                && WhereDoc_nx_avail_batch_6 == null
                && WhereDoc_yrly_ceiling_computed == null
                && WhereDoc_yrly_expense_computed == null
                && WhereDoc_rma_expense_percent_reg == null
                && WhereDoc_sub_specialty == null
                && WhereDoc_payeft == null
                && WhereDoc_ytdded == null
                && WhereDoc_dept_expense_percent_misc == null
                && WhereDoc_dept_expense_percent_reg == null
                && WhereDoc_ep_ped == null
                && WhereDoc_ep_pay_code == null
                && WhereDoc_ep_pay_sub_code == null
                && WhereDoc_partnership == null
                && WhereDoc_ind_holdback_active == null
                && WhereGroup_regular_service == null
                && WhereGroup_over_serviced == null
                && WhereDoc_loc_1_s1 == null
                && WhereDoc_loc_1_s2 == null
                && WhereDoc_loc_1_s3 == null
                && WhereDoc_loc_2_s1 == null
                && WhereDoc_loc_2_s2 == null
                && WhereDoc_loc_2_s3 == null
                && WhereDoc_loc_3_s1 == null
                && WhereDoc_loc_3_s2 == null
                && WhereDoc_loc_3_s3 == null
                && WhereDoc_loc_4_s1 == null
                && WhereDoc_loc_4_s2 == null
                && WhereDoc_loc_4_s3 == null
                && WhereDoc_loc_5_s1 == null
                && WhereDoc_loc_5_s2 == null
                && WhereDoc_loc_5_s3 == null
                && WhereDoc_loc_6_s1 == null
                && WhereDoc_loc_6_s2 == null
                && WhereDoc_loc_6_s3 == null
                && WhereDoc_loc_7_s1 == null
                && WhereDoc_loc_7_s2 == null
                && WhereDoc_loc_7_s3 == null
                && WhereDoc_loc_8_s1 == null
                && WhereDoc_loc_8_s2 == null
                && WhereDoc_loc_8_s3 == null
                && WhereDoc_loc_9_s1 == null
                && WhereDoc_loc_9_s2 == null
                && WhereDoc_loc_9_s3 == null
                && WhereDoc_loc_10_s1 == null
                && WhereDoc_loc_10_s2 == null
                && WhereDoc_loc_10_s3 == null
                && WhereDoc_loc_11_s1 == null
                && WhereDoc_loc_11_s2 == null
                && WhereDoc_loc_11_s3 == null
                && WhereDoc_loc_12_s1 == null
                && WhereDoc_loc_12_s2 == null
                && WhereDoc_loc_12_s3 == null
                && WhereDoc_loc_13_s1 == null
                && WhereDoc_loc_13_s2 == null
                && WhereDoc_loc_13_s3 == null
                && WhereDoc_loc_14_s1 == null
                && WhereDoc_loc_14_s2 == null
                && WhereDoc_loc_14_s3 == null
                && WhereDoc_loc_15_s1 == null
                && WhereDoc_loc_15_s2 == null
                && WhereDoc_loc_15_s3 == null
                && WhereDoc_loc_16_s1 == null
                && WhereDoc_loc_16_s2 == null
                && WhereDoc_loc_16_s3 == null
                && WhereDoc_loc_17_s1 == null
                && WhereDoc_loc_17_s2 == null
                && WhereDoc_loc_17_s3 == null
                && WhereDoc_loc_18_s1 == null
                && WhereDoc_loc_18_s2 == null
                && WhereDoc_loc_18_s3 == null
                && WhereDoc_loc_19_s1 == null
                && WhereDoc_loc_19_s2 == null
                && WhereDoc_loc_19_s3 == null
                && WhereDoc_loc_20_s1 == null
                && WhereDoc_loc_20_s2 == null
                && WhereDoc_loc_20_s3 == null
                && WhereDoc_loc_21_s1 == null
                && WhereDoc_loc_21_s2 == null
                && WhereDoc_loc_21_s3 == null
                && WhereDoc_loc_22_s1 == null
                && WhereDoc_loc_22_s2 == null
                && WhereDoc_loc_22_s3 == null
                && WhereDoc_loc_23_s1 == null
                && WhereDoc_loc_23_s2 == null
                && WhereDoc_loc_23_s3 == null
                && WhereDoc_loc_24_s1 == null
                && WhereDoc_loc_24_s2 == null
                && WhereDoc_loc_24_s3 == null
                && WhereDoc_loc_25_s1 == null
                && WhereDoc_loc_25_s2 == null
                && WhereDoc_loc_25_s3 == null
                && WhereDoc_loc_26_s1 == null
                && WhereDoc_loc_26_s2 == null
                && WhereDoc_loc_26_s3 == null
                && WhereDoc_loc_27_s1 == null
                && WhereDoc_loc_27_s2 == null
                && WhereDoc_loc_27_s3 == null
                && WhereDoc_loc_28_s1 == null
                && WhereDoc_loc_28_s2 == null
                && WhereDoc_loc_28_s3 == null
                && WhereDoc_loc_29_s1 == null
                && WhereDoc_loc_29_s2 == null
                && WhereDoc_loc_29_s3 == null
                && WhereDoc_loc_30_s1 == null
                && WhereDoc_loc_30_s2 == null
                && WhereDoc_loc_30_s3 == null
                && WhereChecksum_value == null
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
            return WhereRowid == _whereRowid
                 && WhereDoc_nbr == _whereDoc_nbr
                 && WhereDoc_dept == _whereDoc_dept
                 && WhereDoc_ohip_nbr == _whereDoc_ohip_nbr
                 && WhereDoc_sin_123 == _whereDoc_sin_123
                 && WhereDoc_sin_456 == _whereDoc_sin_456
                 && WhereDoc_sin_789 == _whereDoc_sin_789
                 && WhereDoc_spec_cd == _whereDoc_spec_cd
                 && WhereDoc_hosp_nbr == _whereDoc_hosp_nbr
                 && WhereDoc_name == _whereDoc_name
                 && WhereDoc_name_soundex == _whereDoc_name_soundex
                 && WhereDoc_init1 == _whereDoc_init1
                 && WhereDoc_init2 == _whereDoc_init2
                 && WhereDoc_init3 == _whereDoc_init3
                 && WhereDoc_addr_office_1 == _whereDoc_addr_office_1
                 && WhereDoc_addr_office_2 == _whereDoc_addr_office_2
                 && WhereDoc_addr_office_3 == _whereDoc_addr_office_3
                 && WhereDoc_addr_office_pc1 == _whereDoc_addr_office_pc1
                 && WhereDoc_addr_office_pc2 == _whereDoc_addr_office_pc2
                 && WhereDoc_addr_office_pc3 == _whereDoc_addr_office_pc3
                 && WhereDoc_addr_office_pc4 == _whereDoc_addr_office_pc4
                 && WhereDoc_addr_office_pc5 == _whereDoc_addr_office_pc5
                 && WhereDoc_addr_office_pc6 == _whereDoc_addr_office_pc6
                 && WhereDoc_addr_home_1 == _whereDoc_addr_home_1
                 && WhereDoc_addr_home_2 == _whereDoc_addr_home_2
                 && WhereDoc_addr_home_3 == _whereDoc_addr_home_3
                 && WhereDoc_addr_home_pc1 == _whereDoc_addr_home_pc1
                 && WhereDoc_addr_home_pc2 == _whereDoc_addr_home_pc2
                 && WhereDoc_addr_home_pc3 == _whereDoc_addr_home_pc3
                 && WhereDoc_addr_home_pc4 == _whereDoc_addr_home_pc4
                 && WhereDoc_addr_home_pc5 == _whereDoc_addr_home_pc5
                 && WhereDoc_addr_home_pc6 == _whereDoc_addr_home_pc6
                 && WhereDoc_full_part_ind == _whereDoc_full_part_ind
                 && WhereDoc_bank_nbr == _whereDoc_bank_nbr
                 && WhereDoc_bank_branch == _whereDoc_bank_branch
                 && WhereDoc_bank_acct == _whereDoc_bank_acct
                 && WhereDoc_date_fac_start_yy == _whereDoc_date_fac_start_yy
                 && WhereDoc_date_fac_start_mm == _whereDoc_date_fac_start_mm
                 && WhereDoc_date_fac_start_dd == _whereDoc_date_fac_start_dd
                 && WhereDoc_date_fac_term_yy == _whereDoc_date_fac_term_yy
                 && WhereDoc_date_fac_term_mm == _whereDoc_date_fac_term_mm
                 && WhereDoc_date_fac_term_dd == _whereDoc_date_fac_term_dd
                 && WhereDoc_ytdgua == _whereDoc_ytdgua
                 && WhereDoc_ytdgub == _whereDoc_ytdgub
                 && WhereDoc_ytdguc == _whereDoc_ytdguc
                 && WhereDoc_ytdgud == _whereDoc_ytdgud
                 && WhereDoc_ytdcea == _whereDoc_ytdcea
                 && WhereDoc_ytdcex == _whereDoc_ytdcex
                 && WhereDoc_ytdear == _whereDoc_ytdear
                 && WhereDoc_ytdinc == _whereDoc_ytdinc
                 && WhereDoc_ytdeft == _whereDoc_ytdeft
                 && WhereDoc_totinc_g == _whereDoc_totinc_g
                 && WhereDoc_ep_date_deposit == _whereDoc_ep_date_deposit
                 && WhereDoc_totinc == _whereDoc_totinc
                 && WhereDoc_ep_ceiexp == _whereDoc_ep_ceiexp
                 && WhereDoc_adjcea == _whereDoc_adjcea
                 && WhereDoc_adjcex == _whereDoc_adjcex
                 && WhereDoc_ceicea == _whereDoc_ceicea
                 && WhereDoc_ceicex == _whereDoc_ceicex
                 && WhereCeicea_prt_format == _whereCeicea_prt_format
                 && WhereCeicex_prt_format == _whereCeicex_prt_format
                 && WhereYtdcea_prt_format == _whereYtdcea_prt_format
                 && WhereYtdcex_prt_format == _whereYtdcex_prt_format
                 && WhereDoc_spec_cd_2 == _whereDoc_spec_cd_2
                 && WhereDoc_spec_cd_3 == _whereDoc_spec_cd_3
                 && WhereDoc_ytdinc_g == _whereDoc_ytdinc_g
                 && WhereDoc_rma_expense_percent_misc == _whereDoc_rma_expense_percent_misc
                 && WhereDoc_afp_paym_group == _whereDoc_afp_paym_group
                 && WhereDoc_dept_2 == _whereDoc_dept_2
                 && WhereDoc_ind_pays_gst == _whereDoc_ind_pays_gst
                 && WhereDoc_nx_avail_batch == _whereDoc_nx_avail_batch
                 && WhereDoc_nx_avail_batch_2 == _whereDoc_nx_avail_batch_2
                 && WhereDoc_nx_avail_batch_3 == _whereDoc_nx_avail_batch_3
                 && WhereDoc_nx_avail_batch_4 == _whereDoc_nx_avail_batch_4
                 && WhereDoc_nx_avail_batch_5 == _whereDoc_nx_avail_batch_5
                 && WhereDoc_nx_avail_batch_6 == _whereDoc_nx_avail_batch_6
                 && WhereDoc_yrly_ceiling_computed == _whereDoc_yrly_ceiling_computed
                 && WhereDoc_yrly_expense_computed == _whereDoc_yrly_expense_computed
                 && WhereDoc_rma_expense_percent_reg == _whereDoc_rma_expense_percent_reg
                 && WhereDoc_sub_specialty == _whereDoc_sub_specialty
                 && WhereDoc_payeft == _whereDoc_payeft
                 && WhereDoc_ytdded == _whereDoc_ytdded
                 && WhereDoc_dept_expense_percent_misc == _whereDoc_dept_expense_percent_misc
                 && WhereDoc_dept_expense_percent_reg == _whereDoc_dept_expense_percent_reg
                 && WhereDoc_ep_ped == _whereDoc_ep_ped
                 && WhereDoc_ep_pay_code == _whereDoc_ep_pay_code
                 && WhereDoc_ep_pay_sub_code == _whereDoc_ep_pay_sub_code
                 && WhereDoc_partnership == _whereDoc_partnership
                 && WhereDoc_ind_holdback_active == _whereDoc_ind_holdback_active
                 && WhereGroup_regular_service == _whereGroup_regular_service
                 && WhereGroup_over_serviced == _whereGroup_over_serviced
                 && WhereDoc_loc_1_s1 == _whereDoc_loc_1_s1
                 && WhereDoc_loc_1_s2 == _whereDoc_loc_1_s2
                 && WhereDoc_loc_1_s3 == _whereDoc_loc_1_s3
                 && WhereDoc_loc_2_s1 == _whereDoc_loc_2_s1
                 && WhereDoc_loc_2_s2 == _whereDoc_loc_2_s2
                 && WhereDoc_loc_2_s3 == _whereDoc_loc_2_s3
                 && WhereDoc_loc_3_s1 == _whereDoc_loc_3_s1
                 && WhereDoc_loc_3_s2 == _whereDoc_loc_3_s2
                 && WhereDoc_loc_3_s3 == _whereDoc_loc_3_s3
                 && WhereDoc_loc_4_s1 == _whereDoc_loc_4_s1
                 && WhereDoc_loc_4_s2 == _whereDoc_loc_4_s2
                 && WhereDoc_loc_4_s3 == _whereDoc_loc_4_s3
                 && WhereDoc_loc_5_s1 == _whereDoc_loc_5_s1
                 && WhereDoc_loc_5_s2 == _whereDoc_loc_5_s2
                 && WhereDoc_loc_5_s3 == _whereDoc_loc_5_s3
                 && WhereDoc_loc_6_s1 == _whereDoc_loc_6_s1
                 && WhereDoc_loc_6_s2 == _whereDoc_loc_6_s2
                 && WhereDoc_loc_6_s3 == _whereDoc_loc_6_s3
                 && WhereDoc_loc_7_s1 == _whereDoc_loc_7_s1
                 && WhereDoc_loc_7_s2 == _whereDoc_loc_7_s2
                 && WhereDoc_loc_7_s3 == _whereDoc_loc_7_s3
                 && WhereDoc_loc_8_s1 == _whereDoc_loc_8_s1
                 && WhereDoc_loc_8_s2 == _whereDoc_loc_8_s2
                 && WhereDoc_loc_8_s3 == _whereDoc_loc_8_s3
                 && WhereDoc_loc_9_s1 == _whereDoc_loc_9_s1
                 && WhereDoc_loc_9_s2 == _whereDoc_loc_9_s2
                 && WhereDoc_loc_9_s3 == _whereDoc_loc_9_s3
                 && WhereDoc_loc_10_s1 == _whereDoc_loc_10_s1
                 && WhereDoc_loc_10_s2 == _whereDoc_loc_10_s2
                 && WhereDoc_loc_10_s3 == _whereDoc_loc_10_s3
                 && WhereDoc_loc_11_s1 == _whereDoc_loc_11_s1
                 && WhereDoc_loc_11_s2 == _whereDoc_loc_11_s2
                 && WhereDoc_loc_11_s3 == _whereDoc_loc_11_s3
                 && WhereDoc_loc_12_s1 == _whereDoc_loc_12_s1
                 && WhereDoc_loc_12_s2 == _whereDoc_loc_12_s2
                 && WhereDoc_loc_12_s3 == _whereDoc_loc_12_s3
                 && WhereDoc_loc_13_s1 == _whereDoc_loc_13_s1
                 && WhereDoc_loc_13_s2 == _whereDoc_loc_13_s2
                 && WhereDoc_loc_13_s3 == _whereDoc_loc_13_s3
                 && WhereDoc_loc_14_s1 == _whereDoc_loc_14_s1
                 && WhereDoc_loc_14_s2 == _whereDoc_loc_14_s2
                 && WhereDoc_loc_14_s3 == _whereDoc_loc_14_s3
                 && WhereDoc_loc_15_s1 == _whereDoc_loc_15_s1
                 && WhereDoc_loc_15_s2 == _whereDoc_loc_15_s2
                 && WhereDoc_loc_15_s3 == _whereDoc_loc_15_s3
                 && WhereDoc_loc_16_s1 == _whereDoc_loc_16_s1
                 && WhereDoc_loc_16_s2 == _whereDoc_loc_16_s2
                 && WhereDoc_loc_16_s3 == _whereDoc_loc_16_s3
                 && WhereDoc_loc_17_s1 == _whereDoc_loc_17_s1
                 && WhereDoc_loc_17_s2 == _whereDoc_loc_17_s2
                 && WhereDoc_loc_17_s3 == _whereDoc_loc_17_s3
                 && WhereDoc_loc_18_s1 == _whereDoc_loc_18_s1
                 && WhereDoc_loc_18_s2 == _whereDoc_loc_18_s2
                 && WhereDoc_loc_18_s3 == _whereDoc_loc_18_s3
                 && WhereDoc_loc_19_s1 == _whereDoc_loc_19_s1
                 && WhereDoc_loc_19_s2 == _whereDoc_loc_19_s2
                 && WhereDoc_loc_19_s3 == _whereDoc_loc_19_s3
                 && WhereDoc_loc_20_s1 == _whereDoc_loc_20_s1
                 && WhereDoc_loc_20_s2 == _whereDoc_loc_20_s2
                 && WhereDoc_loc_20_s3 == _whereDoc_loc_20_s3
                 && WhereDoc_loc_21_s1 == _whereDoc_loc_21_s1
                 && WhereDoc_loc_21_s2 == _whereDoc_loc_21_s2
                 && WhereDoc_loc_21_s3 == _whereDoc_loc_21_s3
                 && WhereDoc_loc_22_s1 == _whereDoc_loc_22_s1
                 && WhereDoc_loc_22_s2 == _whereDoc_loc_22_s2
                 && WhereDoc_loc_22_s3 == _whereDoc_loc_22_s3
                 && WhereDoc_loc_23_s1 == _whereDoc_loc_23_s1
                 && WhereDoc_loc_23_s2 == _whereDoc_loc_23_s2
                 && WhereDoc_loc_23_s3 == _whereDoc_loc_23_s3
                 && WhereDoc_loc_24_s1 == _whereDoc_loc_24_s1
                 && WhereDoc_loc_24_s2 == _whereDoc_loc_24_s2
                 && WhereDoc_loc_24_s3 == _whereDoc_loc_24_s3
                 && WhereDoc_loc_25_s1 == _whereDoc_loc_25_s1
                 && WhereDoc_loc_25_s2 == _whereDoc_loc_25_s2
                 && WhereDoc_loc_25_s3 == _whereDoc_loc_25_s3
                 && WhereDoc_loc_26_s1 == _whereDoc_loc_26_s1
                 && WhereDoc_loc_26_s2 == _whereDoc_loc_26_s2
                 && WhereDoc_loc_26_s3 == _whereDoc_loc_26_s3
                 && WhereDoc_loc_27_s1 == _whereDoc_loc_27_s1
                 && WhereDoc_loc_27_s2 == _whereDoc_loc_27_s2
                 && WhereDoc_loc_27_s3 == _whereDoc_loc_27_s3
                 && WhereDoc_loc_28_s1 == _whereDoc_loc_28_s1
                 && WhereDoc_loc_28_s2 == _whereDoc_loc_28_s2
                 && WhereDoc_loc_28_s3 == _whereDoc_loc_28_s3
                 && WhereDoc_loc_29_s1 == _whereDoc_loc_29_s1
                 && WhereDoc_loc_29_s2 == _whereDoc_loc_29_s2
                 && WhereDoc_loc_29_s3 == _whereDoc_loc_29_s3
                 && WhereDoc_loc_30_s1 == _whereDoc_loc_30_s1
                 && WhereDoc_loc_30_s2 == _whereDoc_loc_30_s2
                 && WhereDoc_loc_30_s3 == _whereDoc_loc_30_s3
                 && WhereChecksum_value == _whereChecksum_value
 ;
        }

        private bool ClearSearch()
        {
            WhereRowid = null;
            WhereDoc_nbr = null;
            WhereDoc_dept = null;
            WhereDoc_ohip_nbr = null;
            WhereDoc_sin_123 = null;
            WhereDoc_sin_456 = null;
            WhereDoc_sin_789 = null;
            WhereDoc_spec_cd = null;
            WhereDoc_hosp_nbr = null;
            WhereDoc_name = null;
            WhereDoc_name_soundex = null;
            WhereDoc_init1 = null;
            WhereDoc_init2 = null;
            WhereDoc_init3 = null;
            WhereDoc_addr_office_1 = null;
            WhereDoc_addr_office_2 = null;
            WhereDoc_addr_office_3 = null;
            WhereDoc_addr_office_pc1 = null;
            WhereDoc_addr_office_pc2 = null;
            WhereDoc_addr_office_pc3 = null;
            WhereDoc_addr_office_pc4 = null;
            WhereDoc_addr_office_pc5 = null;
            WhereDoc_addr_office_pc6 = null;
            WhereDoc_addr_home_1 = null;
            WhereDoc_addr_home_2 = null;
            WhereDoc_addr_home_3 = null;
            WhereDoc_addr_home_pc1 = null;
            WhereDoc_addr_home_pc2 = null;
            WhereDoc_addr_home_pc3 = null;
            WhereDoc_addr_home_pc4 = null;
            WhereDoc_addr_home_pc5 = null;
            WhereDoc_addr_home_pc6 = null;
            WhereDoc_full_part_ind = null;
            WhereDoc_bank_nbr = null;
            WhereDoc_bank_branch = null;
            WhereDoc_bank_acct = null;
            WhereDoc_date_fac_start_yy = null;
            WhereDoc_date_fac_start_mm = null;
            WhereDoc_date_fac_start_dd = null;
            WhereDoc_date_fac_term_yy = null;
            WhereDoc_date_fac_term_mm = null;
            WhereDoc_date_fac_term_dd = null;
            WhereDoc_ytdgua = null;
            WhereDoc_ytdgub = null;
            WhereDoc_ytdguc = null;
            WhereDoc_ytdgud = null;
            WhereDoc_ytdcea = null;
            WhereDoc_ytdcex = null;
            WhereDoc_ytdear = null;
            WhereDoc_ytdinc = null;
            WhereDoc_ytdeft = null;
            WhereDoc_totinc_g = null;
            WhereDoc_ep_date_deposit = null;
            WhereDoc_totinc = null;
            WhereDoc_ep_ceiexp = null;
            WhereDoc_adjcea = null;
            WhereDoc_adjcex = null;
            WhereDoc_ceicea = null;
            WhereDoc_ceicex = null;
            WhereCeicea_prt_format = null;
            WhereCeicex_prt_format = null;
            WhereYtdcea_prt_format = null;
            WhereYtdcex_prt_format = null;
            WhereDoc_spec_cd_2 = null;
            WhereDoc_spec_cd_3 = null;
            WhereDoc_ytdinc_g = null;
            WhereDoc_rma_expense_percent_misc = null;
            WhereDoc_afp_paym_group = null;
            WhereDoc_dept_2 = null;
            WhereDoc_ind_pays_gst = null;
            WhereDoc_nx_avail_batch = null;
            WhereDoc_nx_avail_batch_2 = null;
            WhereDoc_nx_avail_batch_3 = null;
            WhereDoc_nx_avail_batch_4 = null;
            WhereDoc_nx_avail_batch_5 = null;
            WhereDoc_nx_avail_batch_6 = null;
            WhereDoc_yrly_ceiling_computed = null;
            WhereDoc_yrly_expense_computed = null;
            WhereDoc_rma_expense_percent_reg = null;
            WhereDoc_sub_specialty = null;
            WhereDoc_payeft = null;
            WhereDoc_ytdded = null;
            WhereDoc_dept_expense_percent_misc = null;
            WhereDoc_dept_expense_percent_reg = null;
            WhereDoc_ep_ped = null;
            WhereDoc_ep_pay_code = null;
            WhereDoc_ep_pay_sub_code = null;
            WhereDoc_partnership = null;
            WhereDoc_ind_holdback_active = null;
            WhereGroup_regular_service = null;
            WhereGroup_over_serviced = null;
            WhereDoc_loc_1_s1 = null;
            WhereDoc_loc_1_s2 = null;
            WhereDoc_loc_1_s3 = null;
            WhereDoc_loc_2_s1 = null;
            WhereDoc_loc_2_s2 = null;
            WhereDoc_loc_2_s3 = null;
            WhereDoc_loc_3_s1 = null;
            WhereDoc_loc_3_s2 = null;
            WhereDoc_loc_3_s3 = null;
            WhereDoc_loc_4_s1 = null;
            WhereDoc_loc_4_s2 = null;
            WhereDoc_loc_4_s3 = null;
            WhereDoc_loc_5_s1 = null;
            WhereDoc_loc_5_s2 = null;
            WhereDoc_loc_5_s3 = null;
            WhereDoc_loc_6_s1 = null;
            WhereDoc_loc_6_s2 = null;
            WhereDoc_loc_6_s3 = null;
            WhereDoc_loc_7_s1 = null;
            WhereDoc_loc_7_s2 = null;
            WhereDoc_loc_7_s3 = null;
            WhereDoc_loc_8_s1 = null;
            WhereDoc_loc_8_s2 = null;
            WhereDoc_loc_8_s3 = null;
            WhereDoc_loc_9_s1 = null;
            WhereDoc_loc_9_s2 = null;
            WhereDoc_loc_9_s3 = null;
            WhereDoc_loc_10_s1 = null;
            WhereDoc_loc_10_s2 = null;
            WhereDoc_loc_10_s3 = null;
            WhereDoc_loc_11_s1 = null;
            WhereDoc_loc_11_s2 = null;
            WhereDoc_loc_11_s3 = null;
            WhereDoc_loc_12_s1 = null;
            WhereDoc_loc_12_s2 = null;
            WhereDoc_loc_12_s3 = null;
            WhereDoc_loc_13_s1 = null;
            WhereDoc_loc_13_s2 = null;
            WhereDoc_loc_13_s3 = null;
            WhereDoc_loc_14_s1 = null;
            WhereDoc_loc_14_s2 = null;
            WhereDoc_loc_14_s3 = null;
            WhereDoc_loc_15_s1 = null;
            WhereDoc_loc_15_s2 = null;
            WhereDoc_loc_15_s3 = null;
            WhereDoc_loc_16_s1 = null;
            WhereDoc_loc_16_s2 = null;
            WhereDoc_loc_16_s3 = null;
            WhereDoc_loc_17_s1 = null;
            WhereDoc_loc_17_s2 = null;
            WhereDoc_loc_17_s3 = null;
            WhereDoc_loc_18_s1 = null;
            WhereDoc_loc_18_s2 = null;
            WhereDoc_loc_18_s3 = null;
            WhereDoc_loc_19_s1 = null;
            WhereDoc_loc_19_s2 = null;
            WhereDoc_loc_19_s3 = null;
            WhereDoc_loc_20_s1 = null;
            WhereDoc_loc_20_s2 = null;
            WhereDoc_loc_20_s3 = null;
            WhereDoc_loc_21_s1 = null;
            WhereDoc_loc_21_s2 = null;
            WhereDoc_loc_21_s3 = null;
            WhereDoc_loc_22_s1 = null;
            WhereDoc_loc_22_s2 = null;
            WhereDoc_loc_22_s3 = null;
            WhereDoc_loc_23_s1 = null;
            WhereDoc_loc_23_s2 = null;
            WhereDoc_loc_23_s3 = null;
            WhereDoc_loc_24_s1 = null;
            WhereDoc_loc_24_s2 = null;
            WhereDoc_loc_24_s3 = null;
            WhereDoc_loc_25_s1 = null;
            WhereDoc_loc_25_s2 = null;
            WhereDoc_loc_25_s3 = null;
            WhereDoc_loc_26_s1 = null;
            WhereDoc_loc_26_s2 = null;
            WhereDoc_loc_26_s3 = null;
            WhereDoc_loc_27_s1 = null;
            WhereDoc_loc_27_s2 = null;
            WhereDoc_loc_27_s3 = null;
            WhereDoc_loc_28_s1 = null;
            WhereDoc_loc_28_s2 = null;
            WhereDoc_loc_28_s3 = null;
            WhereDoc_loc_29_s1 = null;
            WhereDoc_loc_29_s2 = null;
            WhereDoc_loc_29_s3 = null;
            WhereDoc_loc_30_s1 = null;
            WhereDoc_loc_30_s2 = null;
            WhereDoc_loc_30_s3 = null;
            WhereChecksum_value = null;

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
        private Guid _ROWID;
        private string _DOC_NBR;
        private decimal? _DOC_DEPT;
        private decimal? _DOC_OHIP_NBR;
        private decimal? _DOC_SIN_123;
        private decimal? _DOC_SIN_456;
        private decimal? _DOC_SIN_789;
        private decimal? _DOC_SPEC_CD;
        private string _DOC_HOSP_NBR;
        private string _DOC_NAME;
        private string _DOC_NAME_SOUNDEX;
        private string _DOC_INIT1;
        private string _DOC_INIT2;
        private string _DOC_INIT3;
        private string _DOC_ADDR_OFFICE_1;
        private string _DOC_ADDR_OFFICE_2;
        private string _DOC_ADDR_OFFICE_3;
        private string _DOC_ADDR_OFFICE_PC1;
        private decimal? _DOC_ADDR_OFFICE_PC2;
        private string _DOC_ADDR_OFFICE_PC3;
        private decimal? _DOC_ADDR_OFFICE_PC4;
        private string _DOC_ADDR_OFFICE_PC5;
        private decimal? _DOC_ADDR_OFFICE_PC6;
        private string _DOC_ADDR_HOME_1;
        private string _DOC_ADDR_HOME_2;
        private string _DOC_ADDR_HOME_3;
        private string _DOC_ADDR_HOME_PC1;
        private decimal? _DOC_ADDR_HOME_PC2;
        private string _DOC_ADDR_HOME_PC3;
        private decimal? _DOC_ADDR_HOME_PC4;
        private string _DOC_ADDR_HOME_PC5;
        private decimal? _DOC_ADDR_HOME_PC6;
        private string _DOC_FULL_PART_IND;
        private decimal? _DOC_BANK_NBR;
        private decimal? _DOC_BANK_BRANCH;
        private string _DOC_BANK_ACCT;
        private decimal? _DOC_DATE_FAC_START_YY;
        private decimal? _DOC_DATE_FAC_START_MM;
        private decimal? _DOC_DATE_FAC_START_DD;
        private decimal? _DOC_DATE_FAC_TERM_YY;
        private decimal? _DOC_DATE_FAC_TERM_MM;
        private decimal? _DOC_DATE_FAC_TERM_DD;
        private decimal? _DOC_YTDGUA;
        private decimal? _DOC_YTDGUB;
        private decimal? _DOC_YTDGUC;
        private decimal? _DOC_YTDGUD;
        private decimal? _DOC_YTDCEA;
        private decimal? _DOC_YTDCEX;
        private decimal? _DOC_YTDEAR;
        private decimal? _DOC_YTDINC;
        private decimal? _DOC_YTDEFT;
        private decimal? _DOC_TOTINC_G;
        private decimal? _DOC_EP_DATE_DEPOSIT;
        private decimal? _DOC_TOTINC;
        private decimal? _DOC_EP_CEIEXP;
        private decimal? _DOC_ADJCEA;
        private decimal? _DOC_ADJCEX;
        private decimal? _DOC_CEICEA;
        private decimal? _DOC_CEICEX;
        private string _CEICEA_PRT_FORMAT;
        private string _CEICEX_PRT_FORMAT;
        private string _YTDCEA_PRT_FORMAT;
        private string _YTDCEX_PRT_FORMAT;
        private decimal? _DOC_SPEC_CD_2;
        private decimal? _DOC_SPEC_CD_3;
        private decimal? _DOC_YTDINC_G;
        private string _DOC_RMA_EXPENSE_PERCENT_MISC;
        private string _DOC_AFP_PAYM_GROUP;
        private decimal? _DOC_DEPT_2;
        private string _DOC_IND_PAYS_GST;
        private decimal? _DOC_NX_AVAIL_BATCH;
        private decimal? _DOC_NX_AVAIL_BATCH_2;
        private decimal? _DOC_NX_AVAIL_BATCH_3;
        private decimal? _DOC_NX_AVAIL_BATCH_4;
        private decimal? _DOC_NX_AVAIL_BATCH_5;
        private decimal? _DOC_NX_AVAIL_BATCH_6;
        private decimal? _DOC_YRLY_CEILING_COMPUTED;
        private decimal? _DOC_YRLY_EXPENSE_COMPUTED;
        private string _DOC_RMA_EXPENSE_PERCENT_REG;
        private string _DOC_SUB_SPECIALTY;
        private decimal? _DOC_PAYEFT;
        private decimal? _DOC_YTDDED;
        private string _DOC_DEPT_EXPENSE_PERCENT_MISC;
        private string _DOC_DEPT_EXPENSE_PERCENT_REG;
        private string _DOC_EP_PED;
        private string _DOC_EP_PAY_CODE;
        private string _DOC_EP_PAY_SUB_CODE;
        private string _DOC_PARTNERSHIP;
        private string _DOC_IND_HOLDBACK_ACTIVE;
        private string _GROUP_REGULAR_SERVICE;
        private string _GROUP_OVER_SERVICED;
        private string _DOC_LOC_1_S1;
        private string _DOC_LOC_1_S2;
        private string _DOC_LOC_1_S3;
        private string _DOC_LOC_2_S1;
        private string _DOC_LOC_2_S2;
        private string _DOC_LOC_2_S3;
        private string _DOC_LOC_3_S1;
        private string _DOC_LOC_3_S2;
        private string _DOC_LOC_3_S3;
        private string _DOC_LOC_4_S1;
        private string _DOC_LOC_4_S2;
        private string _DOC_LOC_4_S3;
        private string _DOC_LOC_5_S1;
        private string _DOC_LOC_5_S2;
        private string _DOC_LOC_5_S3;
        private string _DOC_LOC_6_S1;
        private string _DOC_LOC_6_S2;
        private string _DOC_LOC_6_S3;
        private string _DOC_LOC_7_S1;
        private string _DOC_LOC_7_S2;
        private string _DOC_LOC_7_S3;
        private string _DOC_LOC_8_S1;
        private string _DOC_LOC_8_S2;
        private string _DOC_LOC_8_S3;
        private string _DOC_LOC_9_S1;
        private string _DOC_LOC_9_S2;
        private string _DOC_LOC_9_S3;
        private string _DOC_LOC_10_S1;
        private string _DOC_LOC_10_S2;
        private string _DOC_LOC_10_S3;
        private string _DOC_LOC_11_S1;
        private string _DOC_LOC_11_S2;
        private string _DOC_LOC_11_S3;
        private string _DOC_LOC_12_S1;
        private string _DOC_LOC_12_S2;
        private string _DOC_LOC_12_S3;
        private string _DOC_LOC_13_S1;
        private string _DOC_LOC_13_S2;
        private string _DOC_LOC_13_S3;
        private string _DOC_LOC_14_S1;
        private string _DOC_LOC_14_S2;
        private string _DOC_LOC_14_S3;
        private string _DOC_LOC_15_S1;
        private string _DOC_LOC_15_S2;
        private string _DOC_LOC_15_S3;
        private string _DOC_LOC_16_S1;
        private string _DOC_LOC_16_S2;
        private string _DOC_LOC_16_S3;
        private string _DOC_LOC_17_S1;
        private string _DOC_LOC_17_S2;
        private string _DOC_LOC_17_S3;
        private string _DOC_LOC_18_S1;
        private string _DOC_LOC_18_S2;
        private string _DOC_LOC_18_S3;
        private string _DOC_LOC_19_S1;
        private string _DOC_LOC_19_S2;
        private string _DOC_LOC_19_S3;
        private string _DOC_LOC_20_S1;
        private string _DOC_LOC_20_S2;
        private string _DOC_LOC_20_S3;
        private string _DOC_LOC_21_S1;
        private string _DOC_LOC_21_S2;
        private string _DOC_LOC_21_S3;
        private string _DOC_LOC_22_S1;
        private string _DOC_LOC_22_S2;
        private string _DOC_LOC_22_S3;
        private string _DOC_LOC_23_S1;
        private string _DOC_LOC_23_S2;
        private string _DOC_LOC_23_S3;
        private string _DOC_LOC_24_S1;
        private string _DOC_LOC_24_S2;
        private string _DOC_LOC_24_S3;
        private string _DOC_LOC_25_S1;
        private string _DOC_LOC_25_S2;
        private string _DOC_LOC_25_S3;
        private string _DOC_LOC_26_S1;
        private string _DOC_LOC_26_S2;
        private string _DOC_LOC_26_S3;
        private string _DOC_LOC_27_S1;
        private string _DOC_LOC_27_S2;
        private string _DOC_LOC_27_S3;
        private string _DOC_LOC_28_S1;
        private string _DOC_LOC_28_S2;
        private string _DOC_LOC_28_S3;
        private string _DOC_LOC_29_S1;
        private string _DOC_LOC_29_S2;
        private string _DOC_LOC_29_S3;
        private string _DOC_LOC_30_S1;
        private string _DOC_LOC_30_S2;
        private string _DOC_LOC_30_S3;
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
        public decimal? DOC_DEPT
        {
            get { return _DOC_DEPT; }
            set
            {
                if (_DOC_DEPT != value)
                {
                    _DOC_DEPT = value;
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
        public decimal? DOC_SIN_123
        {
            get { return _DOC_SIN_123; }
            set
            {
                if (_DOC_SIN_123 != value)
                {
                    _DOC_SIN_123 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_SIN_456
        {
            get { return _DOC_SIN_456; }
            set
            {
                if (_DOC_SIN_456 != value)
                {
                    _DOC_SIN_456 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_SIN_789
        {
            get { return _DOC_SIN_789; }
            set
            {
                if (_DOC_SIN_789 != value)
                {
                    _DOC_SIN_789 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_SPEC_CD
        {
            get { return _DOC_SPEC_CD; }
            set
            {
                if (_DOC_SPEC_CD != value)
                {
                    _DOC_SPEC_CD = value;
                    ChangeState();
                }
            }
        }
        public string DOC_HOSP_NBR
        {
            get { return _DOC_HOSP_NBR; }
            set
            {
                if (_DOC_HOSP_NBR != value)
                {
                    _DOC_HOSP_NBR = value;
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
        public string DOC_NAME_SOUNDEX
        {
            get { return _DOC_NAME_SOUNDEX; }
            set
            {
                if (_DOC_NAME_SOUNDEX != value)
                {
                    _DOC_NAME_SOUNDEX = value;
                    ChangeState();
                }
            }
        }
        public string DOC_INIT1
        {
            get { return _DOC_INIT1; }
            set
            {
                if (_DOC_INIT1 != value)
                {
                    _DOC_INIT1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_INIT2
        {
            get { return _DOC_INIT2; }
            set
            {
                if (_DOC_INIT2 != value)
                {
                    _DOC_INIT2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_INIT3
        {
            get { return _DOC_INIT3; }
            set
            {
                if (_DOC_INIT3 != value)
                {
                    _DOC_INIT3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_1
        {
            get { return _DOC_ADDR_OFFICE_1; }
            set
            {
                if (_DOC_ADDR_OFFICE_1 != value)
                {
                    _DOC_ADDR_OFFICE_1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_2
        {
            get { return _DOC_ADDR_OFFICE_2; }
            set
            {
                if (_DOC_ADDR_OFFICE_2 != value)
                {
                    _DOC_ADDR_OFFICE_2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_3
        {
            get { return _DOC_ADDR_OFFICE_3; }
            set
            {
                if (_DOC_ADDR_OFFICE_3 != value)
                {
                    _DOC_ADDR_OFFICE_3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_PC1
        {
            get { return _DOC_ADDR_OFFICE_PC1; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC1 != value)
                {
                    _DOC_ADDR_OFFICE_PC1 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_OFFICE_PC2
        {
            get { return _DOC_ADDR_OFFICE_PC2; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC2 != value)
                {
                    _DOC_ADDR_OFFICE_PC2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_PC3
        {
            get { return _DOC_ADDR_OFFICE_PC3; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC3 != value)
                {
                    _DOC_ADDR_OFFICE_PC3 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_OFFICE_PC4
        {
            get { return _DOC_ADDR_OFFICE_PC4; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC4 != value)
                {
                    _DOC_ADDR_OFFICE_PC4 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_OFFICE_PC5
        {
            get { return _DOC_ADDR_OFFICE_PC5; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC5 != value)
                {
                    _DOC_ADDR_OFFICE_PC5 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_OFFICE_PC6
        {
            get { return _DOC_ADDR_OFFICE_PC6; }
            set
            {
                if (_DOC_ADDR_OFFICE_PC6 != value)
                {
                    _DOC_ADDR_OFFICE_PC6 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_1
        {
            get { return _DOC_ADDR_HOME_1; }
            set
            {
                if (_DOC_ADDR_HOME_1 != value)
                {
                    _DOC_ADDR_HOME_1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_2
        {
            get { return _DOC_ADDR_HOME_2; }
            set
            {
                if (_DOC_ADDR_HOME_2 != value)
                {
                    _DOC_ADDR_HOME_2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_3
        {
            get { return _DOC_ADDR_HOME_3; }
            set
            {
                if (_DOC_ADDR_HOME_3 != value)
                {
                    _DOC_ADDR_HOME_3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_PC1
        {
            get { return _DOC_ADDR_HOME_PC1; }
            set
            {
                if (_DOC_ADDR_HOME_PC1 != value)
                {
                    _DOC_ADDR_HOME_PC1 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_HOME_PC2
        {
            get { return _DOC_ADDR_HOME_PC2; }
            set
            {
                if (_DOC_ADDR_HOME_PC2 != value)
                {
                    _DOC_ADDR_HOME_PC2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_PC3
        {
            get { return _DOC_ADDR_HOME_PC3; }
            set
            {
                if (_DOC_ADDR_HOME_PC3 != value)
                {
                    _DOC_ADDR_HOME_PC3 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_HOME_PC4
        {
            get { return _DOC_ADDR_HOME_PC4; }
            set
            {
                if (_DOC_ADDR_HOME_PC4 != value)
                {
                    _DOC_ADDR_HOME_PC4 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_ADDR_HOME_PC5
        {
            get { return _DOC_ADDR_HOME_PC5; }
            set
            {
                if (_DOC_ADDR_HOME_PC5 != value)
                {
                    _DOC_ADDR_HOME_PC5 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADDR_HOME_PC6
        {
            get { return _DOC_ADDR_HOME_PC6; }
            set
            {
                if (_DOC_ADDR_HOME_PC6 != value)
                {
                    _DOC_ADDR_HOME_PC6 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_FULL_PART_IND
        {
            get { return _DOC_FULL_PART_IND; }
            set
            {
                if (_DOC_FULL_PART_IND != value)
                {
                    _DOC_FULL_PART_IND = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_BANK_NBR
        {
            get { return _DOC_BANK_NBR; }
            set
            {
                if (_DOC_BANK_NBR != value)
                {
                    _DOC_BANK_NBR = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_BANK_BRANCH
        {
            get { return _DOC_BANK_BRANCH; }
            set
            {
                if (_DOC_BANK_BRANCH != value)
                {
                    _DOC_BANK_BRANCH = value;
                    ChangeState();
                }
            }
        }
        public string DOC_BANK_ACCT
        {
            get { return _DOC_BANK_ACCT; }
            set
            {
                if (_DOC_BANK_ACCT != value)
                {
                    _DOC_BANK_ACCT = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_START_YY
        {
            get { return _DOC_DATE_FAC_START_YY; }
            set
            {
                if (_DOC_DATE_FAC_START_YY != value)
                {
                    _DOC_DATE_FAC_START_YY = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_START_MM
        {
            get { return _DOC_DATE_FAC_START_MM; }
            set
            {
                if (_DOC_DATE_FAC_START_MM != value)
                {
                    _DOC_DATE_FAC_START_MM = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_START_DD
        {
            get { return _DOC_DATE_FAC_START_DD; }
            set
            {
                if (_DOC_DATE_FAC_START_DD != value)
                {
                    _DOC_DATE_FAC_START_DD = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_TERM_YY
        {
            get { return _DOC_DATE_FAC_TERM_YY; }
            set
            {
                if (_DOC_DATE_FAC_TERM_YY != value)
                {
                    _DOC_DATE_FAC_TERM_YY = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_TERM_MM
        {
            get { return _DOC_DATE_FAC_TERM_MM; }
            set
            {
                if (_DOC_DATE_FAC_TERM_MM != value)
                {
                    _DOC_DATE_FAC_TERM_MM = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_DATE_FAC_TERM_DD
        {
            get { return _DOC_DATE_FAC_TERM_DD; }
            set
            {
                if (_DOC_DATE_FAC_TERM_DD != value)
                {
                    _DOC_DATE_FAC_TERM_DD = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDGUA
        {
            get { return _DOC_YTDGUA; }
            set
            {
                if (_DOC_YTDGUA != value)
                {
                    _DOC_YTDGUA = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDGUB
        {
            get { return _DOC_YTDGUB; }
            set
            {
                if (_DOC_YTDGUB != value)
                {
                    _DOC_YTDGUB = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDGUC
        {
            get { return _DOC_YTDGUC; }
            set
            {
                if (_DOC_YTDGUC != value)
                {
                    _DOC_YTDGUC = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDGUD
        {
            get { return _DOC_YTDGUD; }
            set
            {
                if (_DOC_YTDGUD != value)
                {
                    _DOC_YTDGUD = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDCEA
        {
            get { return _DOC_YTDCEA; }
            set
            {
                if (_DOC_YTDCEA != value)
                {
                    _DOC_YTDCEA = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDCEX
        {
            get { return _DOC_YTDCEX; }
            set
            {
                if (_DOC_YTDCEX != value)
                {
                    _DOC_YTDCEX = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDEAR
        {
            get { return _DOC_YTDEAR; }
            set
            {
                if (_DOC_YTDEAR != value)
                {
                    _DOC_YTDEAR = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDINC
        {
            get { return _DOC_YTDINC; }
            set
            {
                if (_DOC_YTDINC != value)
                {
                    _DOC_YTDINC = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDEFT
        {
            get { return _DOC_YTDEFT; }
            set
            {
                if (_DOC_YTDEFT != value)
                {
                    _DOC_YTDEFT = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_TOTINC_G
        {
            get { return _DOC_TOTINC_G; }
            set
            {
                if (_DOC_TOTINC_G != value)
                {
                    _DOC_TOTINC_G = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_EP_DATE_DEPOSIT
        {
            get { return _DOC_EP_DATE_DEPOSIT; }
            set
            {
                if (_DOC_EP_DATE_DEPOSIT != value)
                {
                    _DOC_EP_DATE_DEPOSIT = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_TOTINC
        {
            get { return _DOC_TOTINC; }
            set
            {
                if (_DOC_TOTINC != value)
                {
                    _DOC_TOTINC = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_EP_CEIEXP
        {
            get { return _DOC_EP_CEIEXP; }
            set
            {
                if (_DOC_EP_CEIEXP != value)
                {
                    _DOC_EP_CEIEXP = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADJCEA
        {
            get { return _DOC_ADJCEA; }
            set
            {
                if (_DOC_ADJCEA != value)
                {
                    _DOC_ADJCEA = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_ADJCEX
        {
            get { return _DOC_ADJCEX; }
            set
            {
                if (_DOC_ADJCEX != value)
                {
                    _DOC_ADJCEX = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_CEICEA
        {
            get { return _DOC_CEICEA; }
            set
            {
                if (_DOC_CEICEA != value)
                {
                    _DOC_CEICEA = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_CEICEX
        {
            get { return _DOC_CEICEX; }
            set
            {
                if (_DOC_CEICEX != value)
                {
                    _DOC_CEICEX = value;
                    ChangeState();
                }
            }
        }
        public string CEICEA_PRT_FORMAT
        {
            get { return _CEICEA_PRT_FORMAT; }
            set
            {
                if (_CEICEA_PRT_FORMAT != value)
                {
                    _CEICEA_PRT_FORMAT = value;
                    ChangeState();
                }
            }
        }
        public string CEICEX_PRT_FORMAT
        {
            get { return _CEICEX_PRT_FORMAT; }
            set
            {
                if (_CEICEX_PRT_FORMAT != value)
                {
                    _CEICEX_PRT_FORMAT = value;
                    ChangeState();
                }
            }
        }
        public string YTDCEA_PRT_FORMAT
        {
            get { return _YTDCEA_PRT_FORMAT; }
            set
            {
                if (_YTDCEA_PRT_FORMAT != value)
                {
                    _YTDCEA_PRT_FORMAT = value;
                    ChangeState();
                }
            }
        }
        public string YTDCEX_PRT_FORMAT
        {
            get { return _YTDCEX_PRT_FORMAT; }
            set
            {
                if (_YTDCEX_PRT_FORMAT != value)
                {
                    _YTDCEX_PRT_FORMAT = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_SPEC_CD_2
        {
            get { return _DOC_SPEC_CD_2; }
            set
            {
                if (_DOC_SPEC_CD_2 != value)
                {
                    _DOC_SPEC_CD_2 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_SPEC_CD_3
        {
            get { return _DOC_SPEC_CD_3; }
            set
            {
                if (_DOC_SPEC_CD_3 != value)
                {
                    _DOC_SPEC_CD_3 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDINC_G
        {
            get { return _DOC_YTDINC_G; }
            set
            {
                if (_DOC_YTDINC_G != value)
                {
                    _DOC_YTDINC_G = value;
                    ChangeState();
                }
            }
        }
        public string DOC_RMA_EXPENSE_PERCENT_MISC
        {
            get { return _DOC_RMA_EXPENSE_PERCENT_MISC; }
            set
            {
                if (_DOC_RMA_EXPENSE_PERCENT_MISC != value)
                {
                    _DOC_RMA_EXPENSE_PERCENT_MISC = value;
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
        public decimal? DOC_DEPT_2
        {
            get { return _DOC_DEPT_2; }
            set
            {
                if (_DOC_DEPT_2 != value)
                {
                    _DOC_DEPT_2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_IND_PAYS_GST
        {
            get { return _DOC_IND_PAYS_GST; }
            set
            {
                if (_DOC_IND_PAYS_GST != value)
                {
                    _DOC_IND_PAYS_GST = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH
        {
            get { return _DOC_NX_AVAIL_BATCH; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH != value)
                {
                    _DOC_NX_AVAIL_BATCH = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH_2
        {
            get { return _DOC_NX_AVAIL_BATCH_2; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH_2 != value)
                {
                    _DOC_NX_AVAIL_BATCH_2 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH_3
        {
            get { return _DOC_NX_AVAIL_BATCH_3; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH_3 != value)
                {
                    _DOC_NX_AVAIL_BATCH_3 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH_4
        {
            get { return _DOC_NX_AVAIL_BATCH_4; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH_4 != value)
                {
                    _DOC_NX_AVAIL_BATCH_4 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH_5
        {
            get { return _DOC_NX_AVAIL_BATCH_5; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH_5 != value)
                {
                    _DOC_NX_AVAIL_BATCH_5 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_NX_AVAIL_BATCH_6
        {
            get { return _DOC_NX_AVAIL_BATCH_6; }
            set
            {
                if (_DOC_NX_AVAIL_BATCH_6 != value)
                {
                    _DOC_NX_AVAIL_BATCH_6 = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YRLY_CEILING_COMPUTED
        {
            get { return _DOC_YRLY_CEILING_COMPUTED; }
            set
            {
                if (_DOC_YRLY_CEILING_COMPUTED != value)
                {
                    _DOC_YRLY_CEILING_COMPUTED = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YRLY_EXPENSE_COMPUTED
        {
            get { return _DOC_YRLY_EXPENSE_COMPUTED; }
            set
            {
                if (_DOC_YRLY_EXPENSE_COMPUTED != value)
                {
                    _DOC_YRLY_EXPENSE_COMPUTED = value;
                    ChangeState();
                }
            }
        }
        public string DOC_RMA_EXPENSE_PERCENT_REG
        {
            get { return _DOC_RMA_EXPENSE_PERCENT_REG; }
            set
            {
                if (_DOC_RMA_EXPENSE_PERCENT_REG != value)
                {
                    _DOC_RMA_EXPENSE_PERCENT_REG = value;
                    ChangeState();
                }
            }
        }
        public string DOC_SUB_SPECIALTY
        {
            get { return _DOC_SUB_SPECIALTY; }
            set
            {
                if (_DOC_SUB_SPECIALTY != value)
                {
                    _DOC_SUB_SPECIALTY = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_PAYEFT
        {
            get { return _DOC_PAYEFT; }
            set
            {
                if (_DOC_PAYEFT != value)
                {
                    _DOC_PAYEFT = value;
                    ChangeState();
                }
            }
        }
        public decimal? DOC_YTDDED
        {
            get { return _DOC_YTDDED; }
            set
            {
                if (_DOC_YTDDED != value)
                {
                    _DOC_YTDDED = value;
                    ChangeState();
                }
            }
        }
        public string DOC_DEPT_EXPENSE_PERCENT_MISC
        {
            get { return _DOC_DEPT_EXPENSE_PERCENT_MISC; }
            set
            {
                if (_DOC_DEPT_EXPENSE_PERCENT_MISC != value)
                {
                    _DOC_DEPT_EXPENSE_PERCENT_MISC = value;
                    ChangeState();
                }
            }
        }
        public string DOC_DEPT_EXPENSE_PERCENT_REG
        {
            get { return _DOC_DEPT_EXPENSE_PERCENT_REG; }
            set
            {
                if (_DOC_DEPT_EXPENSE_PERCENT_REG != value)
                {
                    _DOC_DEPT_EXPENSE_PERCENT_REG = value;
                    ChangeState();
                }
            }
        }
        public string DOC_EP_PED
        {
            get { return _DOC_EP_PED; }
            set
            {
                if (_DOC_EP_PED != value)
                {
                    _DOC_EP_PED = value;
                    ChangeState();
                }
            }
        }
        public string DOC_EP_PAY_CODE
        {
            get { return _DOC_EP_PAY_CODE; }
            set
            {
                if (_DOC_EP_PAY_CODE != value)
                {
                    _DOC_EP_PAY_CODE = value;
                    ChangeState();
                }
            }
        }
        public string DOC_EP_PAY_SUB_CODE
        {
            get { return _DOC_EP_PAY_SUB_CODE; }
            set
            {
                if (_DOC_EP_PAY_SUB_CODE != value)
                {
                    _DOC_EP_PAY_SUB_CODE = value;
                    ChangeState();
                }
            }
        }
        public string DOC_PARTNERSHIP
        {
            get { return _DOC_PARTNERSHIP; }
            set
            {
                if (_DOC_PARTNERSHIP != value)
                {
                    _DOC_PARTNERSHIP = value;
                    ChangeState();
                }
            }
        }
        public string DOC_IND_HOLDBACK_ACTIVE
        {
            get { return _DOC_IND_HOLDBACK_ACTIVE; }
            set
            {
                if (_DOC_IND_HOLDBACK_ACTIVE != value)
                {
                    _DOC_IND_HOLDBACK_ACTIVE = value;
                    ChangeState();
                }
            }
        }
        public string GROUP_REGULAR_SERVICE
        {
            get { return _GROUP_REGULAR_SERVICE; }
            set
            {
                if (_GROUP_REGULAR_SERVICE != value)
                {
                    _GROUP_REGULAR_SERVICE = value;
                    ChangeState();
                }
            }
        }
        public string GROUP_OVER_SERVICED
        {
            get { return _GROUP_OVER_SERVICED; }
            set
            {
                if (_GROUP_OVER_SERVICED != value)
                {
                    _GROUP_OVER_SERVICED = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_1_S1
        {
            get { return _DOC_LOC_1_S1; }
            set
            {
                if (_DOC_LOC_1_S1 != value)
                {
                    _DOC_LOC_1_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_1_S2
        {
            get { return _DOC_LOC_1_S2; }
            set
            {
                if (_DOC_LOC_1_S2 != value)
                {
                    _DOC_LOC_1_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_1_S3
        {
            get { return _DOC_LOC_1_S3; }
            set
            {
                if (_DOC_LOC_1_S3 != value)
                {
                    _DOC_LOC_1_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_2_S1
        {
            get { return _DOC_LOC_2_S1; }
            set
            {
                if (_DOC_LOC_2_S1 != value)
                {
                    _DOC_LOC_2_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_2_S2
        {
            get { return _DOC_LOC_2_S2; }
            set
            {
                if (_DOC_LOC_2_S2 != value)
                {
                    _DOC_LOC_2_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_2_S3
        {
            get { return _DOC_LOC_2_S3; }
            set
            {
                if (_DOC_LOC_2_S3 != value)
                {
                    _DOC_LOC_2_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_3_S1
        {
            get { return _DOC_LOC_3_S1; }
            set
            {
                if (_DOC_LOC_3_S1 != value)
                {
                    _DOC_LOC_3_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_3_S2
        {
            get { return _DOC_LOC_3_S2; }
            set
            {
                if (_DOC_LOC_3_S2 != value)
                {
                    _DOC_LOC_3_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_3_S3
        {
            get { return _DOC_LOC_3_S3; }
            set
            {
                if (_DOC_LOC_3_S3 != value)
                {
                    _DOC_LOC_3_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_4_S1
        {
            get { return _DOC_LOC_4_S1; }
            set
            {
                if (_DOC_LOC_4_S1 != value)
                {
                    _DOC_LOC_4_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_4_S2
        {
            get { return _DOC_LOC_4_S2; }
            set
            {
                if (_DOC_LOC_4_S2 != value)
                {
                    _DOC_LOC_4_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_4_S3
        {
            get { return _DOC_LOC_4_S3; }
            set
            {
                if (_DOC_LOC_4_S3 != value)
                {
                    _DOC_LOC_4_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_5_S1
        {
            get { return _DOC_LOC_5_S1; }
            set
            {
                if (_DOC_LOC_5_S1 != value)
                {
                    _DOC_LOC_5_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_5_S2
        {
            get { return _DOC_LOC_5_S2; }
            set
            {
                if (_DOC_LOC_5_S2 != value)
                {
                    _DOC_LOC_5_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_5_S3
        {
            get { return _DOC_LOC_5_S3; }
            set
            {
                if (_DOC_LOC_5_S3 != value)
                {
                    _DOC_LOC_5_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_6_S1
        {
            get { return _DOC_LOC_6_S1; }
            set
            {
                if (_DOC_LOC_6_S1 != value)
                {
                    _DOC_LOC_6_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_6_S2
        {
            get { return _DOC_LOC_6_S2; }
            set
            {
                if (_DOC_LOC_6_S2 != value)
                {
                    _DOC_LOC_6_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_6_S3
        {
            get { return _DOC_LOC_6_S3; }
            set
            {
                if (_DOC_LOC_6_S3 != value)
                {
                    _DOC_LOC_6_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_7_S1
        {
            get { return _DOC_LOC_7_S1; }
            set
            {
                if (_DOC_LOC_7_S1 != value)
                {
                    _DOC_LOC_7_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_7_S2
        {
            get { return _DOC_LOC_7_S2; }
            set
            {
                if (_DOC_LOC_7_S2 != value)
                {
                    _DOC_LOC_7_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_7_S3
        {
            get { return _DOC_LOC_7_S3; }
            set
            {
                if (_DOC_LOC_7_S3 != value)
                {
                    _DOC_LOC_7_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_8_S1
        {
            get { return _DOC_LOC_8_S1; }
            set
            {
                if (_DOC_LOC_8_S1 != value)
                {
                    _DOC_LOC_8_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_8_S2
        {
            get { return _DOC_LOC_8_S2; }
            set
            {
                if (_DOC_LOC_8_S2 != value)
                {
                    _DOC_LOC_8_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_8_S3
        {
            get { return _DOC_LOC_8_S3; }
            set
            {
                if (_DOC_LOC_8_S3 != value)
                {
                    _DOC_LOC_8_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_9_S1
        {
            get { return _DOC_LOC_9_S1; }
            set
            {
                if (_DOC_LOC_9_S1 != value)
                {
                    _DOC_LOC_9_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_9_S2
        {
            get { return _DOC_LOC_9_S2; }
            set
            {
                if (_DOC_LOC_9_S2 != value)
                {
                    _DOC_LOC_9_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_9_S3
        {
            get { return _DOC_LOC_9_S3; }
            set
            {
                if (_DOC_LOC_9_S3 != value)
                {
                    _DOC_LOC_9_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_10_S1
        {
            get { return _DOC_LOC_10_S1; }
            set
            {
                if (_DOC_LOC_10_S1 != value)
                {
                    _DOC_LOC_10_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_10_S2
        {
            get { return _DOC_LOC_10_S2; }
            set
            {
                if (_DOC_LOC_10_S2 != value)
                {
                    _DOC_LOC_10_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_10_S3
        {
            get { return _DOC_LOC_10_S3; }
            set
            {
                if (_DOC_LOC_10_S3 != value)
                {
                    _DOC_LOC_10_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_11_S1
        {
            get { return _DOC_LOC_11_S1; }
            set
            {
                if (_DOC_LOC_11_S1 != value)
                {
                    _DOC_LOC_11_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_11_S2
        {
            get { return _DOC_LOC_11_S2; }
            set
            {
                if (_DOC_LOC_11_S2 != value)
                {
                    _DOC_LOC_11_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_11_S3
        {
            get { return _DOC_LOC_11_S3; }
            set
            {
                if (_DOC_LOC_11_S3 != value)
                {
                    _DOC_LOC_11_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_12_S1
        {
            get { return _DOC_LOC_12_S1; }
            set
            {
                if (_DOC_LOC_12_S1 != value)
                {
                    _DOC_LOC_12_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_12_S2
        {
            get { return _DOC_LOC_12_S2; }
            set
            {
                if (_DOC_LOC_12_S2 != value)
                {
                    _DOC_LOC_12_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_12_S3
        {
            get { return _DOC_LOC_12_S3; }
            set
            {
                if (_DOC_LOC_12_S3 != value)
                {
                    _DOC_LOC_12_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_13_S1
        {
            get { return _DOC_LOC_13_S1; }
            set
            {
                if (_DOC_LOC_13_S1 != value)
                {
                    _DOC_LOC_13_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_13_S2
        {
            get { return _DOC_LOC_13_S2; }
            set
            {
                if (_DOC_LOC_13_S2 != value)
                {
                    _DOC_LOC_13_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_13_S3
        {
            get { return _DOC_LOC_13_S3; }
            set
            {
                if (_DOC_LOC_13_S3 != value)
                {
                    _DOC_LOC_13_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_14_S1
        {
            get { return _DOC_LOC_14_S1; }
            set
            {
                if (_DOC_LOC_14_S1 != value)
                {
                    _DOC_LOC_14_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_14_S2
        {
            get { return _DOC_LOC_14_S2; }
            set
            {
                if (_DOC_LOC_14_S2 != value)
                {
                    _DOC_LOC_14_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_14_S3
        {
            get { return _DOC_LOC_14_S3; }
            set
            {
                if (_DOC_LOC_14_S3 != value)
                {
                    _DOC_LOC_14_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_15_S1
        {
            get { return _DOC_LOC_15_S1; }
            set
            {
                if (_DOC_LOC_15_S1 != value)
                {
                    _DOC_LOC_15_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_15_S2
        {
            get { return _DOC_LOC_15_S2; }
            set
            {
                if (_DOC_LOC_15_S2 != value)
                {
                    _DOC_LOC_15_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_15_S3
        {
            get { return _DOC_LOC_15_S3; }
            set
            {
                if (_DOC_LOC_15_S3 != value)
                {
                    _DOC_LOC_15_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_16_S1
        {
            get { return _DOC_LOC_16_S1; }
            set
            {
                if (_DOC_LOC_16_S1 != value)
                {
                    _DOC_LOC_16_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_16_S2
        {
            get { return _DOC_LOC_16_S2; }
            set
            {
                if (_DOC_LOC_16_S2 != value)
                {
                    _DOC_LOC_16_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_16_S3
        {
            get { return _DOC_LOC_16_S3; }
            set
            {
                if (_DOC_LOC_16_S3 != value)
                {
                    _DOC_LOC_16_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_17_S1
        {
            get { return _DOC_LOC_17_S1; }
            set
            {
                if (_DOC_LOC_17_S1 != value)
                {
                    _DOC_LOC_17_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_17_S2
        {
            get { return _DOC_LOC_17_S2; }
            set
            {
                if (_DOC_LOC_17_S2 != value)
                {
                    _DOC_LOC_17_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_17_S3
        {
            get { return _DOC_LOC_17_S3; }
            set
            {
                if (_DOC_LOC_17_S3 != value)
                {
                    _DOC_LOC_17_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_18_S1
        {
            get { return _DOC_LOC_18_S1; }
            set
            {
                if (_DOC_LOC_18_S1 != value)
                {
                    _DOC_LOC_18_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_18_S2
        {
            get { return _DOC_LOC_18_S2; }
            set
            {
                if (_DOC_LOC_18_S2 != value)
                {
                    _DOC_LOC_18_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_18_S3
        {
            get { return _DOC_LOC_18_S3; }
            set
            {
                if (_DOC_LOC_18_S3 != value)
                {
                    _DOC_LOC_18_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_19_S1
        {
            get { return _DOC_LOC_19_S1; }
            set
            {
                if (_DOC_LOC_19_S1 != value)
                {
                    _DOC_LOC_19_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_19_S2
        {
            get { return _DOC_LOC_19_S2; }
            set
            {
                if (_DOC_LOC_19_S2 != value)
                {
                    _DOC_LOC_19_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_19_S3
        {
            get { return _DOC_LOC_19_S3; }
            set
            {
                if (_DOC_LOC_19_S3 != value)
                {
                    _DOC_LOC_19_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_20_S1
        {
            get { return _DOC_LOC_20_S1; }
            set
            {
                if (_DOC_LOC_20_S1 != value)
                {
                    _DOC_LOC_20_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_20_S2
        {
            get { return _DOC_LOC_20_S2; }
            set
            {
                if (_DOC_LOC_20_S2 != value)
                {
                    _DOC_LOC_20_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_20_S3
        {
            get { return _DOC_LOC_20_S3; }
            set
            {
                if (_DOC_LOC_20_S3 != value)
                {
                    _DOC_LOC_20_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_21_S1
        {
            get { return _DOC_LOC_21_S1; }
            set
            {
                if (_DOC_LOC_21_S1 != value)
                {
                    _DOC_LOC_21_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_21_S2
        {
            get { return _DOC_LOC_21_S2; }
            set
            {
                if (_DOC_LOC_21_S2 != value)
                {
                    _DOC_LOC_21_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_21_S3
        {
            get { return _DOC_LOC_21_S3; }
            set
            {
                if (_DOC_LOC_21_S3 != value)
                {
                    _DOC_LOC_21_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_22_S1
        {
            get { return _DOC_LOC_22_S1; }
            set
            {
                if (_DOC_LOC_22_S1 != value)
                {
                    _DOC_LOC_22_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_22_S2
        {
            get { return _DOC_LOC_22_S2; }
            set
            {
                if (_DOC_LOC_22_S2 != value)
                {
                    _DOC_LOC_22_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_22_S3
        {
            get { return _DOC_LOC_22_S3; }
            set
            {
                if (_DOC_LOC_22_S3 != value)
                {
                    _DOC_LOC_22_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_23_S1
        {
            get { return _DOC_LOC_23_S1; }
            set
            {
                if (_DOC_LOC_23_S1 != value)
                {
                    _DOC_LOC_23_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_23_S2
        {
            get { return _DOC_LOC_23_S2; }
            set
            {
                if (_DOC_LOC_23_S2 != value)
                {
                    _DOC_LOC_23_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_23_S3
        {
            get { return _DOC_LOC_23_S3; }
            set
            {
                if (_DOC_LOC_23_S3 != value)
                {
                    _DOC_LOC_23_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_24_S1
        {
            get { return _DOC_LOC_24_S1; }
            set
            {
                if (_DOC_LOC_24_S1 != value)
                {
                    _DOC_LOC_24_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_24_S2
        {
            get { return _DOC_LOC_24_S2; }
            set
            {
                if (_DOC_LOC_24_S2 != value)
                {
                    _DOC_LOC_24_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_24_S3
        {
            get { return _DOC_LOC_24_S3; }
            set
            {
                if (_DOC_LOC_24_S3 != value)
                {
                    _DOC_LOC_24_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_25_S1
        {
            get { return _DOC_LOC_25_S1; }
            set
            {
                if (_DOC_LOC_25_S1 != value)
                {
                    _DOC_LOC_25_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_25_S2
        {
            get { return _DOC_LOC_25_S2; }
            set
            {
                if (_DOC_LOC_25_S2 != value)
                {
                    _DOC_LOC_25_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_25_S3
        {
            get { return _DOC_LOC_25_S3; }
            set
            {
                if (_DOC_LOC_25_S3 != value)
                {
                    _DOC_LOC_25_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_26_S1
        {
            get { return _DOC_LOC_26_S1; }
            set
            {
                if (_DOC_LOC_26_S1 != value)
                {
                    _DOC_LOC_26_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_26_S2
        {
            get { return _DOC_LOC_26_S2; }
            set
            {
                if (_DOC_LOC_26_S2 != value)
                {
                    _DOC_LOC_26_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_26_S3
        {
            get { return _DOC_LOC_26_S3; }
            set
            {
                if (_DOC_LOC_26_S3 != value)
                {
                    _DOC_LOC_26_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_27_S1
        {
            get { return _DOC_LOC_27_S1; }
            set
            {
                if (_DOC_LOC_27_S1 != value)
                {
                    _DOC_LOC_27_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_27_S2
        {
            get { return _DOC_LOC_27_S2; }
            set
            {
                if (_DOC_LOC_27_S2 != value)
                {
                    _DOC_LOC_27_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_27_S3
        {
            get { return _DOC_LOC_27_S3; }
            set
            {
                if (_DOC_LOC_27_S3 != value)
                {
                    _DOC_LOC_27_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_28_S1
        {
            get { return _DOC_LOC_28_S1; }
            set
            {
                if (_DOC_LOC_28_S1 != value)
                {
                    _DOC_LOC_28_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_28_S2
        {
            get { return _DOC_LOC_28_S2; }
            set
            {
                if (_DOC_LOC_28_S2 != value)
                {
                    _DOC_LOC_28_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_28_S3
        {
            get { return _DOC_LOC_28_S3; }
            set
            {
                if (_DOC_LOC_28_S3 != value)
                {
                    _DOC_LOC_28_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_29_S1
        {
            get { return _DOC_LOC_29_S1; }
            set
            {
                if (_DOC_LOC_29_S1 != value)
                {
                    _DOC_LOC_29_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_29_S2
        {
            get { return _DOC_LOC_29_S2; }
            set
            {
                if (_DOC_LOC_29_S2 != value)
                {
                    _DOC_LOC_29_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_29_S3
        {
            get { return _DOC_LOC_29_S3; }
            set
            {
                if (_DOC_LOC_29_S3 != value)
                {
                    _DOC_LOC_29_S3 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_30_S1
        {
            get { return _DOC_LOC_30_S1; }
            set
            {
                if (_DOC_LOC_30_S1 != value)
                {
                    _DOC_LOC_30_S1 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_30_S2
        {
            get { return _DOC_LOC_30_S2; }
            set
            {
                if (_DOC_LOC_30_S2 != value)
                {
                    _DOC_LOC_30_S2 = value;
                    ChangeState();
                }
            }
        }
        public string DOC_LOC_30_S3
        {
            get { return _DOC_LOC_30_S3; }
            set
            {
                if (_DOC_LOC_30_S3 != value)
                {
                    _DOC_LOC_30_S3 = value;
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
        public string WhereDoc_nbr { get; set; }
        private string _whereDoc_nbr;
        public decimal? WhereDoc_dept { get; set; }
        private decimal? _whereDoc_dept;
        public decimal? WhereDoc_ohip_nbr { get; set; }
        private decimal? _whereDoc_ohip_nbr;
        public decimal? WhereDoc_sin_123 { get; set; }
        private decimal? _whereDoc_sin_123;
        public decimal? WhereDoc_sin_456 { get; set; }
        private decimal? _whereDoc_sin_456;
        public decimal? WhereDoc_sin_789 { get; set; }
        private decimal? _whereDoc_sin_789;
        public decimal? WhereDoc_spec_cd { get; set; }
        private decimal? _whereDoc_spec_cd;
        public string WhereDoc_hosp_nbr { get; set; }
        private string _whereDoc_hosp_nbr;
        public string WhereDoc_name { get; set; }
        private string _whereDoc_name;
        public string WhereDoc_name_soundex { get; set; }
        private string _whereDoc_name_soundex;
        public string WhereDoc_init1 { get; set; }
        private string _whereDoc_init1;
        public string WhereDoc_init2 { get; set; }
        private string _whereDoc_init2;
        public string WhereDoc_init3 { get; set; }
        private string _whereDoc_init3;
        public string WhereDoc_addr_office_1 { get; set; }
        private string _whereDoc_addr_office_1;
        public string WhereDoc_addr_office_2 { get; set; }
        private string _whereDoc_addr_office_2;
        public string WhereDoc_addr_office_3 { get; set; }
        private string _whereDoc_addr_office_3;
        public string WhereDoc_addr_office_pc1 { get; set; }
        private string _whereDoc_addr_office_pc1;
        public decimal? WhereDoc_addr_office_pc2 { get; set; }
        private decimal? _whereDoc_addr_office_pc2;
        public string WhereDoc_addr_office_pc3 { get; set; }
        private string _whereDoc_addr_office_pc3;
        public decimal? WhereDoc_addr_office_pc4 { get; set; }
        private decimal? _whereDoc_addr_office_pc4;
        public string WhereDoc_addr_office_pc5 { get; set; }
        private string _whereDoc_addr_office_pc5;
        public decimal? WhereDoc_addr_office_pc6 { get; set; }
        private decimal? _whereDoc_addr_office_pc6;
        public string WhereDoc_addr_home_1 { get; set; }
        private string _whereDoc_addr_home_1;
        public string WhereDoc_addr_home_2 { get; set; }
        private string _whereDoc_addr_home_2;
        public string WhereDoc_addr_home_3 { get; set; }
        private string _whereDoc_addr_home_3;
        public string WhereDoc_addr_home_pc1 { get; set; }
        private string _whereDoc_addr_home_pc1;
        public decimal? WhereDoc_addr_home_pc2 { get; set; }
        private decimal? _whereDoc_addr_home_pc2;
        public string WhereDoc_addr_home_pc3 { get; set; }
        private string _whereDoc_addr_home_pc3;
        public decimal? WhereDoc_addr_home_pc4 { get; set; }
        private decimal? _whereDoc_addr_home_pc4;
        public string WhereDoc_addr_home_pc5 { get; set; }
        private string _whereDoc_addr_home_pc5;
        public decimal? WhereDoc_addr_home_pc6 { get; set; }
        private decimal? _whereDoc_addr_home_pc6;
        public string WhereDoc_full_part_ind { get; set; }
        private string _whereDoc_full_part_ind;
        public decimal? WhereDoc_bank_nbr { get; set; }
        private decimal? _whereDoc_bank_nbr;
        public decimal? WhereDoc_bank_branch { get; set; }
        private decimal? _whereDoc_bank_branch;
        public string WhereDoc_bank_acct { get; set; }
        private string _whereDoc_bank_acct;
        public decimal? WhereDoc_date_fac_start_yy { get; set; }
        private decimal? _whereDoc_date_fac_start_yy;
        public decimal? WhereDoc_date_fac_start_mm { get; set; }
        private decimal? _whereDoc_date_fac_start_mm;
        public decimal? WhereDoc_date_fac_start_dd { get; set; }
        private decimal? _whereDoc_date_fac_start_dd;
        public decimal? WhereDoc_date_fac_term_yy { get; set; }
        private decimal? _whereDoc_date_fac_term_yy;
        public decimal? WhereDoc_date_fac_term_mm { get; set; }
        private decimal? _whereDoc_date_fac_term_mm;
        public decimal? WhereDoc_date_fac_term_dd { get; set; }
        private decimal? _whereDoc_date_fac_term_dd;
        public decimal? WhereDoc_ytdgua { get; set; }
        private decimal? _whereDoc_ytdgua;
        public decimal? WhereDoc_ytdgub { get; set; }
        private decimal? _whereDoc_ytdgub;
        public decimal? WhereDoc_ytdguc { get; set; }
        private decimal? _whereDoc_ytdguc;
        public decimal? WhereDoc_ytdgud { get; set; }
        private decimal? _whereDoc_ytdgud;
        public decimal? WhereDoc_ytdcea { get; set; }
        private decimal? _whereDoc_ytdcea;
        public decimal? WhereDoc_ytdcex { get; set; }
        private decimal? _whereDoc_ytdcex;
        public decimal? WhereDoc_ytdear { get; set; }
        private decimal? _whereDoc_ytdear;
        public decimal? WhereDoc_ytdinc { get; set; }
        private decimal? _whereDoc_ytdinc;
        public decimal? WhereDoc_ytdeft { get; set; }
        private decimal? _whereDoc_ytdeft;
        public decimal? WhereDoc_totinc_g { get; set; }
        private decimal? _whereDoc_totinc_g;
        public decimal? WhereDoc_ep_date_deposit { get; set; }
        private decimal? _whereDoc_ep_date_deposit;
        public decimal? WhereDoc_totinc { get; set; }
        private decimal? _whereDoc_totinc;
        public decimal? WhereDoc_ep_ceiexp { get; set; }
        private decimal? _whereDoc_ep_ceiexp;
        public decimal? WhereDoc_adjcea { get; set; }
        private decimal? _whereDoc_adjcea;
        public decimal? WhereDoc_adjcex { get; set; }
        private decimal? _whereDoc_adjcex;
        public decimal? WhereDoc_ceicea { get; set; }
        private decimal? _whereDoc_ceicea;
        public decimal? WhereDoc_ceicex { get; set; }
        private decimal? _whereDoc_ceicex;
        public string WhereCeicea_prt_format { get; set; }
        private string _whereCeicea_prt_format;
        public string WhereCeicex_prt_format { get; set; }
        private string _whereCeicex_prt_format;
        public string WhereYtdcea_prt_format { get; set; }
        private string _whereYtdcea_prt_format;
        public string WhereYtdcex_prt_format { get; set; }
        private string _whereYtdcex_prt_format;
        public decimal? WhereDoc_spec_cd_2 { get; set; }
        private decimal? _whereDoc_spec_cd_2;
        public decimal? WhereDoc_spec_cd_3 { get; set; }
        private decimal? _whereDoc_spec_cd_3;
        public decimal? WhereDoc_ytdinc_g { get; set; }
        private decimal? _whereDoc_ytdinc_g;
        public string WhereDoc_rma_expense_percent_misc { get; set; }
        private string _whereDoc_rma_expense_percent_misc;
        public string WhereDoc_afp_paym_group { get; set; }
        private string _whereDoc_afp_paym_group;
        public decimal? WhereDoc_dept_2 { get; set; }
        private decimal? _whereDoc_dept_2;
        public string WhereDoc_ind_pays_gst { get; set; }
        private string _whereDoc_ind_pays_gst;
        public decimal? WhereDoc_nx_avail_batch { get; set; }
        private decimal? _whereDoc_nx_avail_batch;
        public decimal? WhereDoc_nx_avail_batch_2 { get; set; }
        private decimal? _whereDoc_nx_avail_batch_2;
        public decimal? WhereDoc_nx_avail_batch_3 { get; set; }
        private decimal? _whereDoc_nx_avail_batch_3;
        public decimal? WhereDoc_nx_avail_batch_4 { get; set; }
        private decimal? _whereDoc_nx_avail_batch_4;
        public decimal? WhereDoc_nx_avail_batch_5 { get; set; }
        private decimal? _whereDoc_nx_avail_batch_5;
        public decimal? WhereDoc_nx_avail_batch_6 { get; set; }
        private decimal? _whereDoc_nx_avail_batch_6;
        public decimal? WhereDoc_yrly_ceiling_computed { get; set; }
        private decimal? _whereDoc_yrly_ceiling_computed;
        public decimal? WhereDoc_yrly_expense_computed { get; set; }
        private decimal? _whereDoc_yrly_expense_computed;
        public string WhereDoc_rma_expense_percent_reg { get; set; }
        private string _whereDoc_rma_expense_percent_reg;
        public string WhereDoc_sub_specialty { get; set; }
        private string _whereDoc_sub_specialty;
        public decimal? WhereDoc_payeft { get; set; }
        private decimal? _whereDoc_payeft;
        public decimal? WhereDoc_ytdded { get; set; }
        private decimal? _whereDoc_ytdded;
        public string WhereDoc_dept_expense_percent_misc { get; set; }
        private string _whereDoc_dept_expense_percent_misc;
        public string WhereDoc_dept_expense_percent_reg { get; set; }
        private string _whereDoc_dept_expense_percent_reg;
        public string WhereDoc_ep_ped { get; set; }
        private string _whereDoc_ep_ped;
        public string WhereDoc_ep_pay_code { get; set; }
        private string _whereDoc_ep_pay_code;
        public string WhereDoc_ep_pay_sub_code { get; set; }
        private string _whereDoc_ep_pay_sub_code;
        public string WhereDoc_partnership { get; set; }
        private string _whereDoc_partnership;
        public string WhereDoc_ind_holdback_active { get; set; }
        private string _whereDoc_ind_holdback_active;
        public string WhereGroup_regular_service { get; set; }
        private string _whereGroup_regular_service;
        public string WhereGroup_over_serviced { get; set; }
        private string _whereGroup_over_serviced;
        public string WhereDoc_loc_1_s1 { get; set; }
        private string _whereDoc_loc_1_s1;
        public string WhereDoc_loc_1_s2 { get; set; }
        private string _whereDoc_loc_1_s2;
        public string WhereDoc_loc_1_s3 { get; set; }
        private string _whereDoc_loc_1_s3;
        public string WhereDoc_loc_2_s1 { get; set; }
        private string _whereDoc_loc_2_s1;
        public string WhereDoc_loc_2_s2 { get; set; }
        private string _whereDoc_loc_2_s2;
        public string WhereDoc_loc_2_s3 { get; set; }
        private string _whereDoc_loc_2_s3;
        public string WhereDoc_loc_3_s1 { get; set; }
        private string _whereDoc_loc_3_s1;
        public string WhereDoc_loc_3_s2 { get; set; }
        private string _whereDoc_loc_3_s2;
        public string WhereDoc_loc_3_s3 { get; set; }
        private string _whereDoc_loc_3_s3;
        public string WhereDoc_loc_4_s1 { get; set; }
        private string _whereDoc_loc_4_s1;
        public string WhereDoc_loc_4_s2 { get; set; }
        private string _whereDoc_loc_4_s2;
        public string WhereDoc_loc_4_s3 { get; set; }
        private string _whereDoc_loc_4_s3;
        public string WhereDoc_loc_5_s1 { get; set; }
        private string _whereDoc_loc_5_s1;
        public string WhereDoc_loc_5_s2 { get; set; }
        private string _whereDoc_loc_5_s2;
        public string WhereDoc_loc_5_s3 { get; set; }
        private string _whereDoc_loc_5_s3;
        public string WhereDoc_loc_6_s1 { get; set; }
        private string _whereDoc_loc_6_s1;
        public string WhereDoc_loc_6_s2 { get; set; }
        private string _whereDoc_loc_6_s2;
        public string WhereDoc_loc_6_s3 { get; set; }
        private string _whereDoc_loc_6_s3;
        public string WhereDoc_loc_7_s1 { get; set; }
        private string _whereDoc_loc_7_s1;
        public string WhereDoc_loc_7_s2 { get; set; }
        private string _whereDoc_loc_7_s2;
        public string WhereDoc_loc_7_s3 { get; set; }
        private string _whereDoc_loc_7_s3;
        public string WhereDoc_loc_8_s1 { get; set; }
        private string _whereDoc_loc_8_s1;
        public string WhereDoc_loc_8_s2 { get; set; }
        private string _whereDoc_loc_8_s2;
        public string WhereDoc_loc_8_s3 { get; set; }
        private string _whereDoc_loc_8_s3;
        public string WhereDoc_loc_9_s1 { get; set; }
        private string _whereDoc_loc_9_s1;
        public string WhereDoc_loc_9_s2 { get; set; }
        private string _whereDoc_loc_9_s2;
        public string WhereDoc_loc_9_s3 { get; set; }
        private string _whereDoc_loc_9_s3;
        public string WhereDoc_loc_10_s1 { get; set; }
        private string _whereDoc_loc_10_s1;
        public string WhereDoc_loc_10_s2 { get; set; }
        private string _whereDoc_loc_10_s2;
        public string WhereDoc_loc_10_s3 { get; set; }
        private string _whereDoc_loc_10_s3;
        public string WhereDoc_loc_11_s1 { get; set; }
        private string _whereDoc_loc_11_s1;
        public string WhereDoc_loc_11_s2 { get; set; }
        private string _whereDoc_loc_11_s2;
        public string WhereDoc_loc_11_s3 { get; set; }
        private string _whereDoc_loc_11_s3;
        public string WhereDoc_loc_12_s1 { get; set; }
        private string _whereDoc_loc_12_s1;
        public string WhereDoc_loc_12_s2 { get; set; }
        private string _whereDoc_loc_12_s2;
        public string WhereDoc_loc_12_s3 { get; set; }
        private string _whereDoc_loc_12_s3;
        public string WhereDoc_loc_13_s1 { get; set; }
        private string _whereDoc_loc_13_s1;
        public string WhereDoc_loc_13_s2 { get; set; }
        private string _whereDoc_loc_13_s2;
        public string WhereDoc_loc_13_s3 { get; set; }
        private string _whereDoc_loc_13_s3;
        public string WhereDoc_loc_14_s1 { get; set; }
        private string _whereDoc_loc_14_s1;
        public string WhereDoc_loc_14_s2 { get; set; }
        private string _whereDoc_loc_14_s2;
        public string WhereDoc_loc_14_s3 { get; set; }
        private string _whereDoc_loc_14_s3;
        public string WhereDoc_loc_15_s1 { get; set; }
        private string _whereDoc_loc_15_s1;
        public string WhereDoc_loc_15_s2 { get; set; }
        private string _whereDoc_loc_15_s2;
        public string WhereDoc_loc_15_s3 { get; set; }
        private string _whereDoc_loc_15_s3;
        public string WhereDoc_loc_16_s1 { get; set; }
        private string _whereDoc_loc_16_s1;
        public string WhereDoc_loc_16_s2 { get; set; }
        private string _whereDoc_loc_16_s2;
        public string WhereDoc_loc_16_s3 { get; set; }
        private string _whereDoc_loc_16_s3;
        public string WhereDoc_loc_17_s1 { get; set; }
        private string _whereDoc_loc_17_s1;
        public string WhereDoc_loc_17_s2 { get; set; }
        private string _whereDoc_loc_17_s2;
        public string WhereDoc_loc_17_s3 { get; set; }
        private string _whereDoc_loc_17_s3;
        public string WhereDoc_loc_18_s1 { get; set; }
        private string _whereDoc_loc_18_s1;
        public string WhereDoc_loc_18_s2 { get; set; }
        private string _whereDoc_loc_18_s2;
        public string WhereDoc_loc_18_s3 { get; set; }
        private string _whereDoc_loc_18_s3;
        public string WhereDoc_loc_19_s1 { get; set; }
        private string _whereDoc_loc_19_s1;
        public string WhereDoc_loc_19_s2 { get; set; }
        private string _whereDoc_loc_19_s2;
        public string WhereDoc_loc_19_s3 { get; set; }
        private string _whereDoc_loc_19_s3;
        public string WhereDoc_loc_20_s1 { get; set; }
        private string _whereDoc_loc_20_s1;
        public string WhereDoc_loc_20_s2 { get; set; }
        private string _whereDoc_loc_20_s2;
        public string WhereDoc_loc_20_s3 { get; set; }
        private string _whereDoc_loc_20_s3;
        public string WhereDoc_loc_21_s1 { get; set; }
        private string _whereDoc_loc_21_s1;
        public string WhereDoc_loc_21_s2 { get; set; }
        private string _whereDoc_loc_21_s2;
        public string WhereDoc_loc_21_s3 { get; set; }
        private string _whereDoc_loc_21_s3;
        public string WhereDoc_loc_22_s1 { get; set; }
        private string _whereDoc_loc_22_s1;
        public string WhereDoc_loc_22_s2 { get; set; }
        private string _whereDoc_loc_22_s2;
        public string WhereDoc_loc_22_s3 { get; set; }
        private string _whereDoc_loc_22_s3;
        public string WhereDoc_loc_23_s1 { get; set; }
        private string _whereDoc_loc_23_s1;
        public string WhereDoc_loc_23_s2 { get; set; }
        private string _whereDoc_loc_23_s2;
        public string WhereDoc_loc_23_s3 { get; set; }
        private string _whereDoc_loc_23_s3;
        public string WhereDoc_loc_24_s1 { get; set; }
        private string _whereDoc_loc_24_s1;
        public string WhereDoc_loc_24_s2 { get; set; }
        private string _whereDoc_loc_24_s2;
        public string WhereDoc_loc_24_s3 { get; set; }
        private string _whereDoc_loc_24_s3;
        public string WhereDoc_loc_25_s1 { get; set; }
        private string _whereDoc_loc_25_s1;
        public string WhereDoc_loc_25_s2 { get; set; }
        private string _whereDoc_loc_25_s2;
        public string WhereDoc_loc_25_s3 { get; set; }
        private string _whereDoc_loc_25_s3;
        public string WhereDoc_loc_26_s1 { get; set; }
        private string _whereDoc_loc_26_s1;
        public string WhereDoc_loc_26_s2 { get; set; }
        private string _whereDoc_loc_26_s2;
        public string WhereDoc_loc_26_s3 { get; set; }
        private string _whereDoc_loc_26_s3;
        public string WhereDoc_loc_27_s1 { get; set; }
        private string _whereDoc_loc_27_s1;
        public string WhereDoc_loc_27_s2 { get; set; }
        private string _whereDoc_loc_27_s2;
        public string WhereDoc_loc_27_s3 { get; set; }
        private string _whereDoc_loc_27_s3;
        public string WhereDoc_loc_28_s1 { get; set; }
        private string _whereDoc_loc_28_s1;
        public string WhereDoc_loc_28_s2 { get; set; }
        private string _whereDoc_loc_28_s2;
        public string WhereDoc_loc_28_s3 { get; set; }
        private string _whereDoc_loc_28_s3;
        public string WhereDoc_loc_29_s1 { get; set; }
        private string _whereDoc_loc_29_s1;
        public string WhereDoc_loc_29_s2 { get; set; }
        private string _whereDoc_loc_29_s2;
        public string WhereDoc_loc_29_s3 { get; set; }
        private string _whereDoc_loc_29_s3;
        public string WhereDoc_loc_30_s1 { get; set; }
        private string _whereDoc_loc_30_s1;
        public string WhereDoc_loc_30_s2 { get; set; }
        private string _whereDoc_loc_30_s2;
        public string WhereDoc_loc_30_s3 { get; set; }
        private string _whereDoc_loc_30_s3;
        public int? WhereChecksum_value { get; set; }
        private int? _whereChecksum_value;


        #endregion

        #region Original

        private Guid _originalRowid;
        private string _originalDoc_nbr;
        private decimal? _originalDoc_dept;
        private decimal? _originalDoc_ohip_nbr;
        private decimal? _originalDoc_sin_123;
        private decimal? _originalDoc_sin_456;
        private decimal? _originalDoc_sin_789;
        private decimal? _originalDoc_spec_cd;
        private string _originalDoc_hosp_nbr;
        private string _originalDoc_name;
        private string _originalDoc_name_soundex;
        private string _originalDoc_init1;
        private string _originalDoc_init2;
        private string _originalDoc_init3;
        private string _originalDoc_addr_office_1;
        private string _originalDoc_addr_office_2;
        private string _originalDoc_addr_office_3;
        private string _originalDoc_addr_office_pc1;
        private decimal? _originalDoc_addr_office_pc2;
        private string _originalDoc_addr_office_pc3;
        private decimal? _originalDoc_addr_office_pc4;
        private string _originalDoc_addr_office_pc5;
        private decimal? _originalDoc_addr_office_pc6;
        private string _originalDoc_addr_home_1;
        private string _originalDoc_addr_home_2;
        private string _originalDoc_addr_home_3;
        private string _originalDoc_addr_home_pc1;
        private decimal? _originalDoc_addr_home_pc2;
        private string _originalDoc_addr_home_pc3;
        private decimal? _originalDoc_addr_home_pc4;
        private string _originalDoc_addr_home_pc5;
        private decimal? _originalDoc_addr_home_pc6;
        private string _originalDoc_full_part_ind;
        private decimal? _originalDoc_bank_nbr;
        private decimal? _originalDoc_bank_branch;
        private string _originalDoc_bank_acct;
        private decimal? _originalDoc_date_fac_start_yy;
        private decimal? _originalDoc_date_fac_start_mm;
        private decimal? _originalDoc_date_fac_start_dd;
        private decimal? _originalDoc_date_fac_term_yy;
        private decimal? _originalDoc_date_fac_term_mm;
        private decimal? _originalDoc_date_fac_term_dd;
        private decimal? _originalDoc_ytdgua;
        private decimal? _originalDoc_ytdgub;
        private decimal? _originalDoc_ytdguc;
        private decimal? _originalDoc_ytdgud;
        private decimal? _originalDoc_ytdcea;
        private decimal? _originalDoc_ytdcex;
        private decimal? _originalDoc_ytdear;
        private decimal? _originalDoc_ytdinc;
        private decimal? _originalDoc_ytdeft;
        private decimal? _originalDoc_totinc_g;
        private decimal? _originalDoc_ep_date_deposit;
        private decimal? _originalDoc_totinc;
        private decimal? _originalDoc_ep_ceiexp;
        private decimal? _originalDoc_adjcea;
        private decimal? _originalDoc_adjcex;
        private decimal? _originalDoc_ceicea;
        private decimal? _originalDoc_ceicex;
        private string _originalCeicea_prt_format;
        private string _originalCeicex_prt_format;
        private string _originalYtdcea_prt_format;
        private string _originalYtdcex_prt_format;
        private decimal? _originalDoc_spec_cd_2;
        private decimal? _originalDoc_spec_cd_3;
        private decimal? _originalDoc_ytdinc_g;
        private string _originalDoc_rma_expense_percent_misc;
        private string _originalDoc_afp_paym_group;
        private decimal? _originalDoc_dept_2;
        private string _originalDoc_ind_pays_gst;
        private decimal? _originalDoc_nx_avail_batch;
        private decimal? _originalDoc_nx_avail_batch_2;
        private decimal? _originalDoc_nx_avail_batch_3;
        private decimal? _originalDoc_nx_avail_batch_4;
        private decimal? _originalDoc_nx_avail_batch_5;
        private decimal? _originalDoc_nx_avail_batch_6;
        private decimal? _originalDoc_yrly_ceiling_computed;
        private decimal? _originalDoc_yrly_expense_computed;
        private string _originalDoc_rma_expense_percent_reg;
        private string _originalDoc_sub_specialty;
        private decimal? _originalDoc_payeft;
        private decimal? _originalDoc_ytdded;
        private string _originalDoc_dept_expense_percent_misc;
        private string _originalDoc_dept_expense_percent_reg;
        private string _originalDoc_ep_ped;
        private string _originalDoc_ep_pay_code;
        private string _originalDoc_ep_pay_sub_code;
        private string _originalDoc_partnership;
        private string _originalDoc_ind_holdback_active;
        private string _originalGroup_regular_service;
        private string _originalGroup_over_serviced;
        private string _originalDoc_loc_1_s1;
        private string _originalDoc_loc_1_s2;
        private string _originalDoc_loc_1_s3;
        private string _originalDoc_loc_2_s1;
        private string _originalDoc_loc_2_s2;
        private string _originalDoc_loc_2_s3;
        private string _originalDoc_loc_3_s1;
        private string _originalDoc_loc_3_s2;
        private string _originalDoc_loc_3_s3;
        private string _originalDoc_loc_4_s1;
        private string _originalDoc_loc_4_s2;
        private string _originalDoc_loc_4_s3;
        private string _originalDoc_loc_5_s1;
        private string _originalDoc_loc_5_s2;
        private string _originalDoc_loc_5_s3;
        private string _originalDoc_loc_6_s1;
        private string _originalDoc_loc_6_s2;
        private string _originalDoc_loc_6_s3;
        private string _originalDoc_loc_7_s1;
        private string _originalDoc_loc_7_s2;
        private string _originalDoc_loc_7_s3;
        private string _originalDoc_loc_8_s1;
        private string _originalDoc_loc_8_s2;
        private string _originalDoc_loc_8_s3;
        private string _originalDoc_loc_9_s1;
        private string _originalDoc_loc_9_s2;
        private string _originalDoc_loc_9_s3;
        private string _originalDoc_loc_10_s1;
        private string _originalDoc_loc_10_s2;
        private string _originalDoc_loc_10_s3;
        private string _originalDoc_loc_11_s1;
        private string _originalDoc_loc_11_s2;
        private string _originalDoc_loc_11_s3;
        private string _originalDoc_loc_12_s1;
        private string _originalDoc_loc_12_s2;
        private string _originalDoc_loc_12_s3;
        private string _originalDoc_loc_13_s1;
        private string _originalDoc_loc_13_s2;
        private string _originalDoc_loc_13_s3;
        private string _originalDoc_loc_14_s1;
        private string _originalDoc_loc_14_s2;
        private string _originalDoc_loc_14_s3;
        private string _originalDoc_loc_15_s1;
        private string _originalDoc_loc_15_s2;
        private string _originalDoc_loc_15_s3;
        private string _originalDoc_loc_16_s1;
        private string _originalDoc_loc_16_s2;
        private string _originalDoc_loc_16_s3;
        private string _originalDoc_loc_17_s1;
        private string _originalDoc_loc_17_s2;
        private string _originalDoc_loc_17_s3;
        private string _originalDoc_loc_18_s1;
        private string _originalDoc_loc_18_s2;
        private string _originalDoc_loc_18_s3;
        private string _originalDoc_loc_19_s1;
        private string _originalDoc_loc_19_s2;
        private string _originalDoc_loc_19_s3;
        private string _originalDoc_loc_20_s1;
        private string _originalDoc_loc_20_s2;
        private string _originalDoc_loc_20_s3;
        private string _originalDoc_loc_21_s1;
        private string _originalDoc_loc_21_s2;
        private string _originalDoc_loc_21_s3;
        private string _originalDoc_loc_22_s1;
        private string _originalDoc_loc_22_s2;
        private string _originalDoc_loc_22_s3;
        private string _originalDoc_loc_23_s1;
        private string _originalDoc_loc_23_s2;
        private string _originalDoc_loc_23_s3;
        private string _originalDoc_loc_24_s1;
        private string _originalDoc_loc_24_s2;
        private string _originalDoc_loc_24_s3;
        private string _originalDoc_loc_25_s1;
        private string _originalDoc_loc_25_s2;
        private string _originalDoc_loc_25_s3;
        private string _originalDoc_loc_26_s1;
        private string _originalDoc_loc_26_s2;
        private string _originalDoc_loc_26_s3;
        private string _originalDoc_loc_27_s1;
        private string _originalDoc_loc_27_s2;
        private string _originalDoc_loc_27_s3;
        private string _originalDoc_loc_28_s1;
        private string _originalDoc_loc_28_s2;
        private string _originalDoc_loc_28_s3;
        private string _originalDoc_loc_29_s1;
        private string _originalDoc_loc_29_s2;
        private string _originalDoc_loc_29_s3;
        private string _originalDoc_loc_30_s1;
        private string _originalDoc_loc_30_s2;
        private string _originalDoc_loc_30_s3;
        private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
            ROWID = _originalRowid;
            DOC_NBR = _originalDoc_nbr;
            DOC_DEPT = _originalDoc_dept;
            DOC_OHIP_NBR = _originalDoc_ohip_nbr;
            DOC_SIN_123 = _originalDoc_sin_123;
            DOC_SIN_456 = _originalDoc_sin_456;
            DOC_SIN_789 = _originalDoc_sin_789;
            DOC_SPEC_CD = _originalDoc_spec_cd;
            DOC_HOSP_NBR = _originalDoc_hosp_nbr;
            DOC_NAME = _originalDoc_name;
            DOC_NAME_SOUNDEX = _originalDoc_name_soundex;
            DOC_INIT1 = _originalDoc_init1;
            DOC_INIT2 = _originalDoc_init2;
            DOC_INIT3 = _originalDoc_init3;
            DOC_ADDR_OFFICE_1 = _originalDoc_addr_office_1;
            DOC_ADDR_OFFICE_2 = _originalDoc_addr_office_2;
            DOC_ADDR_OFFICE_3 = _originalDoc_addr_office_3;
            DOC_ADDR_OFFICE_PC1 = _originalDoc_addr_office_pc1;
            DOC_ADDR_OFFICE_PC2 = _originalDoc_addr_office_pc2;
            DOC_ADDR_OFFICE_PC3 = _originalDoc_addr_office_pc3;
            DOC_ADDR_OFFICE_PC4 = _originalDoc_addr_office_pc4;
            DOC_ADDR_OFFICE_PC5 = _originalDoc_addr_office_pc5;
            DOC_ADDR_OFFICE_PC6 = _originalDoc_addr_office_pc6;
            DOC_ADDR_HOME_1 = _originalDoc_addr_home_1;
            DOC_ADDR_HOME_2 = _originalDoc_addr_home_2;
            DOC_ADDR_HOME_3 = _originalDoc_addr_home_3;
            DOC_ADDR_HOME_PC1 = _originalDoc_addr_home_pc1;
            DOC_ADDR_HOME_PC2 = _originalDoc_addr_home_pc2;
            DOC_ADDR_HOME_PC3 = _originalDoc_addr_home_pc3;
            DOC_ADDR_HOME_PC4 = _originalDoc_addr_home_pc4;
            DOC_ADDR_HOME_PC5 = _originalDoc_addr_home_pc5;
            DOC_ADDR_HOME_PC6 = _originalDoc_addr_home_pc6;
            DOC_FULL_PART_IND = _originalDoc_full_part_ind;
            DOC_BANK_NBR = _originalDoc_bank_nbr;
            DOC_BANK_BRANCH = _originalDoc_bank_branch;
            DOC_BANK_ACCT = _originalDoc_bank_acct;
            DOC_DATE_FAC_START_YY = _originalDoc_date_fac_start_yy;
            DOC_DATE_FAC_START_MM = _originalDoc_date_fac_start_mm;
            DOC_DATE_FAC_START_DD = _originalDoc_date_fac_start_dd;
            DOC_DATE_FAC_TERM_YY = _originalDoc_date_fac_term_yy;
            DOC_DATE_FAC_TERM_MM = _originalDoc_date_fac_term_mm;
            DOC_DATE_FAC_TERM_DD = _originalDoc_date_fac_term_dd;
            DOC_YTDGUA = _originalDoc_ytdgua;
            DOC_YTDGUB = _originalDoc_ytdgub;
            DOC_YTDGUC = _originalDoc_ytdguc;
            DOC_YTDGUD = _originalDoc_ytdgud;
            DOC_YTDCEA = _originalDoc_ytdcea;
            DOC_YTDCEX = _originalDoc_ytdcex;
            DOC_YTDEAR = _originalDoc_ytdear;
            DOC_YTDINC = _originalDoc_ytdinc;
            DOC_YTDEFT = _originalDoc_ytdeft;
            DOC_TOTINC_G = _originalDoc_totinc_g;
            DOC_EP_DATE_DEPOSIT = _originalDoc_ep_date_deposit;
            DOC_TOTINC = _originalDoc_totinc;
            DOC_EP_CEIEXP = _originalDoc_ep_ceiexp;
            DOC_ADJCEA = _originalDoc_adjcea;
            DOC_ADJCEX = _originalDoc_adjcex;
            DOC_CEICEA = _originalDoc_ceicea;
            DOC_CEICEX = _originalDoc_ceicex;
            CEICEA_PRT_FORMAT = _originalCeicea_prt_format;
            CEICEX_PRT_FORMAT = _originalCeicex_prt_format;
            YTDCEA_PRT_FORMAT = _originalYtdcea_prt_format;
            YTDCEX_PRT_FORMAT = _originalYtdcex_prt_format;
            DOC_SPEC_CD_2 = _originalDoc_spec_cd_2;
            DOC_SPEC_CD_3 = _originalDoc_spec_cd_3;
            DOC_YTDINC_G = _originalDoc_ytdinc_g;
            DOC_RMA_EXPENSE_PERCENT_MISC = _originalDoc_rma_expense_percent_misc;
            DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
            DOC_DEPT_2 = _originalDoc_dept_2;
            DOC_IND_PAYS_GST = _originalDoc_ind_pays_gst;
            DOC_NX_AVAIL_BATCH = _originalDoc_nx_avail_batch;
            DOC_NX_AVAIL_BATCH_2 = _originalDoc_nx_avail_batch_2;
            DOC_NX_AVAIL_BATCH_3 = _originalDoc_nx_avail_batch_3;
            DOC_NX_AVAIL_BATCH_4 = _originalDoc_nx_avail_batch_4;
            DOC_NX_AVAIL_BATCH_5 = _originalDoc_nx_avail_batch_5;
            DOC_NX_AVAIL_BATCH_6 = _originalDoc_nx_avail_batch_6;
            DOC_YRLY_CEILING_COMPUTED = _originalDoc_yrly_ceiling_computed;
            DOC_YRLY_EXPENSE_COMPUTED = _originalDoc_yrly_expense_computed;
            DOC_RMA_EXPENSE_PERCENT_REG = _originalDoc_rma_expense_percent_reg;
            DOC_SUB_SPECIALTY = _originalDoc_sub_specialty;
            DOC_PAYEFT = _originalDoc_payeft;
            DOC_YTDDED = _originalDoc_ytdded;
            DOC_DEPT_EXPENSE_PERCENT_MISC = _originalDoc_dept_expense_percent_misc;
            DOC_DEPT_EXPENSE_PERCENT_REG = _originalDoc_dept_expense_percent_reg;
            DOC_EP_PED = _originalDoc_ep_ped;
            DOC_EP_PAY_CODE = _originalDoc_ep_pay_code;
            DOC_EP_PAY_SUB_CODE = _originalDoc_ep_pay_sub_code;
            DOC_PARTNERSHIP = _originalDoc_partnership;
            DOC_IND_HOLDBACK_ACTIVE = _originalDoc_ind_holdback_active;
            GROUP_REGULAR_SERVICE = _originalGroup_regular_service;
            GROUP_OVER_SERVICED = _originalGroup_over_serviced;
            DOC_LOC_1_S1 = _originalDoc_loc_1_s1;
            DOC_LOC_1_S2 = _originalDoc_loc_1_s2;
            DOC_LOC_1_S3 = _originalDoc_loc_1_s3;
            DOC_LOC_2_S1 = _originalDoc_loc_2_s1;
            DOC_LOC_2_S2 = _originalDoc_loc_2_s2;
            DOC_LOC_2_S3 = _originalDoc_loc_2_s3;
            DOC_LOC_3_S1 = _originalDoc_loc_3_s1;
            DOC_LOC_3_S2 = _originalDoc_loc_3_s2;
            DOC_LOC_3_S3 = _originalDoc_loc_3_s3;
            DOC_LOC_4_S1 = _originalDoc_loc_4_s1;
            DOC_LOC_4_S2 = _originalDoc_loc_4_s2;
            DOC_LOC_4_S3 = _originalDoc_loc_4_s3;
            DOC_LOC_5_S1 = _originalDoc_loc_5_s1;
            DOC_LOC_5_S2 = _originalDoc_loc_5_s2;
            DOC_LOC_5_S3 = _originalDoc_loc_5_s3;
            DOC_LOC_6_S1 = _originalDoc_loc_6_s1;
            DOC_LOC_6_S2 = _originalDoc_loc_6_s2;
            DOC_LOC_6_S3 = _originalDoc_loc_6_s3;
            DOC_LOC_7_S1 = _originalDoc_loc_7_s1;
            DOC_LOC_7_S2 = _originalDoc_loc_7_s2;
            DOC_LOC_7_S3 = _originalDoc_loc_7_s3;
            DOC_LOC_8_S1 = _originalDoc_loc_8_s1;
            DOC_LOC_8_S2 = _originalDoc_loc_8_s2;
            DOC_LOC_8_S3 = _originalDoc_loc_8_s3;
            DOC_LOC_9_S1 = _originalDoc_loc_9_s1;
            DOC_LOC_9_S2 = _originalDoc_loc_9_s2;
            DOC_LOC_9_S3 = _originalDoc_loc_9_s3;
            DOC_LOC_10_S1 = _originalDoc_loc_10_s1;
            DOC_LOC_10_S2 = _originalDoc_loc_10_s2;
            DOC_LOC_10_S3 = _originalDoc_loc_10_s3;
            DOC_LOC_11_S1 = _originalDoc_loc_11_s1;
            DOC_LOC_11_S2 = _originalDoc_loc_11_s2;
            DOC_LOC_11_S3 = _originalDoc_loc_11_s3;
            DOC_LOC_12_S1 = _originalDoc_loc_12_s1;
            DOC_LOC_12_S2 = _originalDoc_loc_12_s2;
            DOC_LOC_12_S3 = _originalDoc_loc_12_s3;
            DOC_LOC_13_S1 = _originalDoc_loc_13_s1;
            DOC_LOC_13_S2 = _originalDoc_loc_13_s2;
            DOC_LOC_13_S3 = _originalDoc_loc_13_s3;
            DOC_LOC_14_S1 = _originalDoc_loc_14_s1;
            DOC_LOC_14_S2 = _originalDoc_loc_14_s2;
            DOC_LOC_14_S3 = _originalDoc_loc_14_s3;
            DOC_LOC_15_S1 = _originalDoc_loc_15_s1;
            DOC_LOC_15_S2 = _originalDoc_loc_15_s2;
            DOC_LOC_15_S3 = _originalDoc_loc_15_s3;
            DOC_LOC_16_S1 = _originalDoc_loc_16_s1;
            DOC_LOC_16_S2 = _originalDoc_loc_16_s2;
            DOC_LOC_16_S3 = _originalDoc_loc_16_s3;
            DOC_LOC_17_S1 = _originalDoc_loc_17_s1;
            DOC_LOC_17_S2 = _originalDoc_loc_17_s2;
            DOC_LOC_17_S3 = _originalDoc_loc_17_s3;
            DOC_LOC_18_S1 = _originalDoc_loc_18_s1;
            DOC_LOC_18_S2 = _originalDoc_loc_18_s2;
            DOC_LOC_18_S3 = _originalDoc_loc_18_s3;
            DOC_LOC_19_S1 = _originalDoc_loc_19_s1;
            DOC_LOC_19_S2 = _originalDoc_loc_19_s2;
            DOC_LOC_19_S3 = _originalDoc_loc_19_s3;
            DOC_LOC_20_S1 = _originalDoc_loc_20_s1;
            DOC_LOC_20_S2 = _originalDoc_loc_20_s2;
            DOC_LOC_20_S3 = _originalDoc_loc_20_s3;
            DOC_LOC_21_S1 = _originalDoc_loc_21_s1;
            DOC_LOC_21_S2 = _originalDoc_loc_21_s2;
            DOC_LOC_21_S3 = _originalDoc_loc_21_s3;
            DOC_LOC_22_S1 = _originalDoc_loc_22_s1;
            DOC_LOC_22_S2 = _originalDoc_loc_22_s2;
            DOC_LOC_22_S3 = _originalDoc_loc_22_s3;
            DOC_LOC_23_S1 = _originalDoc_loc_23_s1;
            DOC_LOC_23_S2 = _originalDoc_loc_23_s2;
            DOC_LOC_23_S3 = _originalDoc_loc_23_s3;
            DOC_LOC_24_S1 = _originalDoc_loc_24_s1;
            DOC_LOC_24_S2 = _originalDoc_loc_24_s2;
            DOC_LOC_24_S3 = _originalDoc_loc_24_s3;
            DOC_LOC_25_S1 = _originalDoc_loc_25_s1;
            DOC_LOC_25_S2 = _originalDoc_loc_25_s2;
            DOC_LOC_25_S3 = _originalDoc_loc_25_s3;
            DOC_LOC_26_S1 = _originalDoc_loc_26_s1;
            DOC_LOC_26_S2 = _originalDoc_loc_26_s2;
            DOC_LOC_26_S3 = _originalDoc_loc_26_s3;
            DOC_LOC_27_S1 = _originalDoc_loc_27_s1;
            DOC_LOC_27_S2 = _originalDoc_loc_27_s2;
            DOC_LOC_27_S3 = _originalDoc_loc_27_s3;
            DOC_LOC_28_S1 = _originalDoc_loc_28_s1;
            DOC_LOC_28_S2 = _originalDoc_loc_28_s2;
            DOC_LOC_28_S3 = _originalDoc_loc_28_s3;
            DOC_LOC_29_S1 = _originalDoc_loc_29_s1;
            DOC_LOC_29_S2 = _originalDoc_loc_29_s2;
            DOC_LOC_29_S3 = _originalDoc_loc_29_s3;
            DOC_LOC_30_S1 = _originalDoc_loc_30_s1;
            DOC_LOC_30_S2 = _originalDoc_loc_30_s2;
            DOC_LOC_30_S3 = _originalDoc_loc_30_s3;
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
                    new SqlParameter("DOC_NBR",DOC_NBR)
                };
            RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOCTOR_MSTR_DeleteRow]", parameters);

            CloseConnection();
            return true;
        }

        public bool Purge()
        {
            int RowsAffected = 0;
            RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOCTOR_MSTR_Purge]");
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
                        new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
                        new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
                        new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
                        new SqlParameter("DOC_SIN_123", SqlNull(DOC_SIN_123)),
                        new SqlParameter("DOC_SIN_456", SqlNull(DOC_SIN_456)),
                        new SqlParameter("DOC_SIN_789", SqlNull(DOC_SIN_789)),
                        new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
                        new SqlParameter("DOC_HOSP_NBR", SqlNull(DOC_HOSP_NBR)),
                        new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
                        new SqlParameter("DOC_NAME_SOUNDEX", SqlNull(DOC_NAME_SOUNDEX)),
                        new SqlParameter("DOC_INIT1", SqlNull(DOC_INIT1)),
                        new SqlParameter("DOC_INIT2", SqlNull(DOC_INIT2)),
                        new SqlParameter("DOC_INIT3", SqlNull(DOC_INIT3)),
                        new SqlParameter("DOC_ADDR_OFFICE_1", SqlNull(DOC_ADDR_OFFICE_1)),
                        new SqlParameter("DOC_ADDR_OFFICE_2", SqlNull(DOC_ADDR_OFFICE_2)),
                        new SqlParameter("DOC_ADDR_OFFICE_3", SqlNull(DOC_ADDR_OFFICE_3)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC1", SqlNull(DOC_ADDR_OFFICE_PC1)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC2", SqlNull(DOC_ADDR_OFFICE_PC2)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC3", SqlNull(DOC_ADDR_OFFICE_PC3)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC4", SqlNull(DOC_ADDR_OFFICE_PC4)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC5", SqlNull(DOC_ADDR_OFFICE_PC5)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC6", SqlNull(DOC_ADDR_OFFICE_PC6)),
                        new SqlParameter("DOC_ADDR_HOME_1", SqlNull(DOC_ADDR_HOME_1)),
                        new SqlParameter("DOC_ADDR_HOME_2", SqlNull(DOC_ADDR_HOME_2)),
                        new SqlParameter("DOC_ADDR_HOME_3", SqlNull(DOC_ADDR_HOME_3)),
                        new SqlParameter("DOC_ADDR_HOME_PC1", SqlNull(DOC_ADDR_HOME_PC1)),
                        new SqlParameter("DOC_ADDR_HOME_PC2", SqlNull(DOC_ADDR_HOME_PC2)),
                        new SqlParameter("DOC_ADDR_HOME_PC3", SqlNull(DOC_ADDR_HOME_PC3)),
                        new SqlParameter("DOC_ADDR_HOME_PC4", SqlNull(DOC_ADDR_HOME_PC4)),
                        new SqlParameter("DOC_ADDR_HOME_PC5", SqlNull(DOC_ADDR_HOME_PC5)),
                        new SqlParameter("DOC_ADDR_HOME_PC6", SqlNull(DOC_ADDR_HOME_PC6)),
                        new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
                        new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
                        new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
                        new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
                        new SqlParameter("DOC_DATE_FAC_START_YY", SqlNull(DOC_DATE_FAC_START_YY)),
                        new SqlParameter("DOC_DATE_FAC_START_MM", SqlNull(DOC_DATE_FAC_START_MM)),
                        new SqlParameter("DOC_DATE_FAC_START_DD", SqlNull(DOC_DATE_FAC_START_DD)),
                        new SqlParameter("DOC_DATE_FAC_TERM_YY", SqlNull(DOC_DATE_FAC_TERM_YY)),
                        new SqlParameter("DOC_DATE_FAC_TERM_MM", SqlNull(DOC_DATE_FAC_TERM_MM)),
                        new SqlParameter("DOC_DATE_FAC_TERM_DD", SqlNull(DOC_DATE_FAC_TERM_DD)),
                        new SqlParameter("DOC_YTDGUA", SqlNull(DOC_YTDGUA)),
                        new SqlParameter("DOC_YTDGUB", SqlNull(DOC_YTDGUB)),
                        new SqlParameter("DOC_YTDGUC", SqlNull(DOC_YTDGUC)),
                        new SqlParameter("DOC_YTDGUD", SqlNull(DOC_YTDGUD)),
                        new SqlParameter("DOC_YTDCEA", SqlNull(DOC_YTDCEA)),
                        new SqlParameter("DOC_YTDCEX", SqlNull(DOC_YTDCEX)),
                        new SqlParameter("DOC_YTDEAR", SqlNull(DOC_YTDEAR)),
                        new SqlParameter("DOC_YTDINC", SqlNull(DOC_YTDINC)),
                        new SqlParameter("DOC_YTDEFT", SqlNull(DOC_YTDEFT)),
                        new SqlParameter("DOC_TOTINC_G", SqlNull(DOC_TOTINC_G)),
                        new SqlParameter("DOC_EP_DATE_DEPOSIT", SqlNull(DOC_EP_DATE_DEPOSIT)),
                        new SqlParameter("DOC_TOTINC", SqlNull(DOC_TOTINC)),
                        new SqlParameter("DOC_EP_CEIEXP", SqlNull(DOC_EP_CEIEXP)),
                        new SqlParameter("DOC_ADJCEA", SqlNull(DOC_ADJCEA)),
                        new SqlParameter("DOC_ADJCEX", SqlNull(DOC_ADJCEX)),
                        new SqlParameter("DOC_CEICEA", SqlNull(DOC_CEICEA)),
                        new SqlParameter("DOC_CEICEX", SqlNull(DOC_CEICEX)),
                        new SqlParameter("CEICEA_PRT_FORMAT", SqlNull(CEICEA_PRT_FORMAT)),
                        new SqlParameter("CEICEX_PRT_FORMAT", SqlNull(CEICEX_PRT_FORMAT)),
                        new SqlParameter("YTDCEA_PRT_FORMAT", SqlNull(YTDCEA_PRT_FORMAT)),
                        new SqlParameter("YTDCEX_PRT_FORMAT", SqlNull(YTDCEX_PRT_FORMAT)),
                        new SqlParameter("DOC_SPEC_CD_2", SqlNull(DOC_SPEC_CD_2)),
                        new SqlParameter("DOC_SPEC_CD_3", SqlNull(DOC_SPEC_CD_3)),
                        new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
                        new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
                        new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
                        new SqlParameter("DOC_DEPT_2", SqlNull(DOC_DEPT_2)),
                        new SqlParameter("DOC_IND_PAYS_GST", SqlNull(DOC_IND_PAYS_GST)),
						/*new SqlParameter("DOC_NX_AVAIL_BATCH", SqlNull(DOC_NX_AVAIL_BATCH)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_2", SqlNull(DOC_NX_AVAIL_BATCH_2)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_3", SqlNull(DOC_NX_AVAIL_BATCH_3)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_4", SqlNull(DOC_NX_AVAIL_BATCH_4)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_5", SqlNull(DOC_NX_AVAIL_BATCH_5)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_6", SqlNull(DOC_NX_AVAIL_BATCH_6)), */
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
                        new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
                        new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
                        new SqlParameter("DOC_SUB_SPECIALTY", SqlNull(DOC_SUB_SPECIALTY)),
                        new SqlParameter("DOC_PAYEFT", SqlNull(DOC_PAYEFT)),
                        new SqlParameter("DOC_YTDDED", SqlNull(DOC_YTDDED)),
                        new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
                        new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
                        new SqlParameter("DOC_EP_PED", SqlNull(DOC_EP_PED)),
                        new SqlParameter("DOC_EP_PAY_CODE", SqlNull(DOC_EP_PAY_CODE)),
                        new SqlParameter("DOC_EP_PAY_SUB_CODE", SqlNull(DOC_EP_PAY_SUB_CODE)),
                        new SqlParameter("DOC_PARTNERSHIP", SqlNull(DOC_PARTNERSHIP)),
                        new SqlParameter("DOC_IND_HOLDBACK_ACTIVE", SqlNull(DOC_IND_HOLDBACK_ACTIVE)),
                        new SqlParameter("GROUP_REGULAR_SERVICE", SqlNull(GROUP_REGULAR_SERVICE)),
                        new SqlParameter("GROUP_OVER_SERVICED", SqlNull(GROUP_OVER_SERVICED)),
					/*	new SqlParameter("DOC_LOC_1_S1", SqlNull(DOC_LOC_1_S1)),
						new SqlParameter("DOC_LOC_1_S2", SqlNull(DOC_LOC_1_S2)),
						new SqlParameter("DOC_LOC_1_S3", SqlNull(DOC_LOC_1_S3)),
						new SqlParameter("DOC_LOC_2_S1", SqlNull(DOC_LOC_2_S1)),
						new SqlParameter("DOC_LOC_2_S2", SqlNull(DOC_LOC_2_S2)),
						new SqlParameter("DOC_LOC_2_S3", SqlNull(DOC_LOC_2_S3)),
						new SqlParameter("DOC_LOC_3_S1", SqlNull(DOC_LOC_3_S1)),
						new SqlParameter("DOC_LOC_3_S2", SqlNull(DOC_LOC_3_S2)),
						new SqlParameter("DOC_LOC_3_S3", SqlNull(DOC_LOC_3_S3)),
						new SqlParameter("DOC_LOC_4_S1", SqlNull(DOC_LOC_4_S1)),
						new SqlParameter("DOC_LOC_4_S2", SqlNull(DOC_LOC_4_S2)),
						new SqlParameter("DOC_LOC_4_S3", SqlNull(DOC_LOC_4_S3)),
						new SqlParameter("DOC_LOC_5_S1", SqlNull(DOC_LOC_5_S1)),
						new SqlParameter("DOC_LOC_5_S2", SqlNull(DOC_LOC_5_S2)),
						new SqlParameter("DOC_LOC_5_S3", SqlNull(DOC_LOC_5_S3)),
						new SqlParameter("DOC_LOC_6_S1", SqlNull(DOC_LOC_6_S1)),
						new SqlParameter("DOC_LOC_6_S2", SqlNull(DOC_LOC_6_S2)),
						new SqlParameter("DOC_LOC_6_S3", SqlNull(DOC_LOC_6_S3)),
						new SqlParameter("DOC_LOC_7_S1", SqlNull(DOC_LOC_7_S1)),
						new SqlParameter("DOC_LOC_7_S2", SqlNull(DOC_LOC_7_S2)),
						new SqlParameter("DOC_LOC_7_S3", SqlNull(DOC_LOC_7_S3)),
						new SqlParameter("DOC_LOC_8_S1", SqlNull(DOC_LOC_8_S1)),
						new SqlParameter("DOC_LOC_8_S2", SqlNull(DOC_LOC_8_S2)),
						new SqlParameter("DOC_LOC_8_S3", SqlNull(DOC_LOC_8_S3)),
						new SqlParameter("DOC_LOC_9_S1", SqlNull(DOC_LOC_9_S1)),
						new SqlParameter("DOC_LOC_9_S2", SqlNull(DOC_LOC_9_S2)),
						new SqlParameter("DOC_LOC_9_S3", SqlNull(DOC_LOC_9_S3)),
						new SqlParameter("DOC_LOC_10_S1", SqlNull(DOC_LOC_10_S1)),
						new SqlParameter("DOC_LOC_10_S2", SqlNull(DOC_LOC_10_S2)),
						new SqlParameter("DOC_LOC_10_S3", SqlNull(DOC_LOC_10_S3)),
						new SqlParameter("DOC_LOC_11_S1", SqlNull(DOC_LOC_11_S1)),
						new SqlParameter("DOC_LOC_11_S2", SqlNull(DOC_LOC_11_S2)),
						new SqlParameter("DOC_LOC_11_S3", SqlNull(DOC_LOC_11_S3)),
						new SqlParameter("DOC_LOC_12_S1", SqlNull(DOC_LOC_12_S1)),
						new SqlParameter("DOC_LOC_12_S2", SqlNull(DOC_LOC_12_S2)),
						new SqlParameter("DOC_LOC_12_S3", SqlNull(DOC_LOC_12_S3)),
						new SqlParameter("DOC_LOC_13_S1", SqlNull(DOC_LOC_13_S1)),
						new SqlParameter("DOC_LOC_13_S2", SqlNull(DOC_LOC_13_S2)),
						new SqlParameter("DOC_LOC_13_S3", SqlNull(DOC_LOC_13_S3)),
						new SqlParameter("DOC_LOC_14_S1", SqlNull(DOC_LOC_14_S1)),
						new SqlParameter("DOC_LOC_14_S2", SqlNull(DOC_LOC_14_S2)),
						new SqlParameter("DOC_LOC_14_S3", SqlNull(DOC_LOC_14_S3)),
						new SqlParameter("DOC_LOC_15_S1", SqlNull(DOC_LOC_15_S1)),
						new SqlParameter("DOC_LOC_15_S2", SqlNull(DOC_LOC_15_S2)),
						new SqlParameter("DOC_LOC_15_S3", SqlNull(DOC_LOC_15_S3)),
						new SqlParameter("DOC_LOC_16_S1", SqlNull(DOC_LOC_16_S1)),
						new SqlParameter("DOC_LOC_16_S2", SqlNull(DOC_LOC_16_S2)),
						new SqlParameter("DOC_LOC_16_S3", SqlNull(DOC_LOC_16_S3)),
						new SqlParameter("DOC_LOC_17_S1", SqlNull(DOC_LOC_17_S1)),
						new SqlParameter("DOC_LOC_17_S2", SqlNull(DOC_LOC_17_S2)),
						new SqlParameter("DOC_LOC_17_S3", SqlNull(DOC_LOC_17_S3)),
						new SqlParameter("DOC_LOC_18_S1", SqlNull(DOC_LOC_18_S1)),
						new SqlParameter("DOC_LOC_18_S2", SqlNull(DOC_LOC_18_S2)),
						new SqlParameter("DOC_LOC_18_S3", SqlNull(DOC_LOC_18_S3)),
						new SqlParameter("DOC_LOC_19_S1", SqlNull(DOC_LOC_19_S1)),
						new SqlParameter("DOC_LOC_19_S2", SqlNull(DOC_LOC_19_S2)),
						new SqlParameter("DOC_LOC_19_S3", SqlNull(DOC_LOC_19_S3)),
						new SqlParameter("DOC_LOC_20_S1", SqlNull(DOC_LOC_20_S1)),
						new SqlParameter("DOC_LOC_20_S2", SqlNull(DOC_LOC_20_S2)),
						new SqlParameter("DOC_LOC_20_S3", SqlNull(DOC_LOC_20_S3)),
						new SqlParameter("DOC_LOC_21_S1", SqlNull(DOC_LOC_21_S1)),
						new SqlParameter("DOC_LOC_21_S2", SqlNull(DOC_LOC_21_S2)),
						new SqlParameter("DOC_LOC_21_S3", SqlNull(DOC_LOC_21_S3)),
						new SqlParameter("DOC_LOC_22_S1", SqlNull(DOC_LOC_22_S1)),
						new SqlParameter("DOC_LOC_22_S2", SqlNull(DOC_LOC_22_S2)),
						new SqlParameter("DOC_LOC_22_S3", SqlNull(DOC_LOC_22_S3)),
						new SqlParameter("DOC_LOC_23_S1", SqlNull(DOC_LOC_23_S1)),
						new SqlParameter("DOC_LOC_23_S2", SqlNull(DOC_LOC_23_S2)),
						new SqlParameter("DOC_LOC_23_S3", SqlNull(DOC_LOC_23_S3)),
						new SqlParameter("DOC_LOC_24_S1", SqlNull(DOC_LOC_24_S1)),
						new SqlParameter("DOC_LOC_24_S2", SqlNull(DOC_LOC_24_S2)),
						new SqlParameter("DOC_LOC_24_S3", SqlNull(DOC_LOC_24_S3)),
						new SqlParameter("DOC_LOC_25_S1", SqlNull(DOC_LOC_25_S1)),
						new SqlParameter("DOC_LOC_25_S2", SqlNull(DOC_LOC_25_S2)),
						new SqlParameter("DOC_LOC_25_S3", SqlNull(DOC_LOC_25_S3)),
						new SqlParameter("DOC_LOC_26_S1", SqlNull(DOC_LOC_26_S1)),
						new SqlParameter("DOC_LOC_26_S2", SqlNull(DOC_LOC_26_S2)),
						new SqlParameter("DOC_LOC_26_S3", SqlNull(DOC_LOC_26_S3)),
						new SqlParameter("DOC_LOC_27_S1", SqlNull(DOC_LOC_27_S1)),
						new SqlParameter("DOC_LOC_27_S2", SqlNull(DOC_LOC_27_S2)),
						new SqlParameter("DOC_LOC_27_S3", SqlNull(DOC_LOC_27_S3)),
						new SqlParameter("DOC_LOC_28_S1", SqlNull(DOC_LOC_28_S1)),
						new SqlParameter("DOC_LOC_28_S2", SqlNull(DOC_LOC_28_S2)),
						new SqlParameter("DOC_LOC_28_S3", SqlNull(DOC_LOC_28_S3)),
						new SqlParameter("DOC_LOC_29_S1", SqlNull(DOC_LOC_29_S1)),
						new SqlParameter("DOC_LOC_29_S2", SqlNull(DOC_LOC_29_S2)),
						new SqlParameter("DOC_LOC_29_S3", SqlNull(DOC_LOC_29_S3)),
						new SqlParameter("DOC_LOC_30_S1", SqlNull(DOC_LOC_30_S1)),
						new SqlParameter("DOC_LOC_30_S2", SqlNull(DOC_LOC_30_S2)),
						new SqlParameter("DOC_LOC_30_S3", SqlNull(DOC_LOC_30_S3)), */
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_MSTR_Insert]", parameters);
                    if (Reader.Read())
                    {
                        RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
                        ROWID = (Guid)Reader["ROWID"];
                        DOC_NBR = Reader["DOC_NBR"].ToString();
                        DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
                        DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
                        DOC_SIN_123 = ConvertDEC(Reader["DOC_SIN_123"]);
                        DOC_SIN_456 = ConvertDEC(Reader["DOC_SIN_456"]);
                        DOC_SIN_789 = ConvertDEC(Reader["DOC_SIN_789"]);
                        DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
                        DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString();
                        DOC_NAME = Reader["DOC_NAME"].ToString();
                        DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString();
                        DOC_INIT1 = Reader["DOC_INIT1"].ToString();
                        DOC_INIT2 = Reader["DOC_INIT2"].ToString();
                        DOC_INIT3 = Reader["DOC_INIT3"].ToString();
                        DOC_ADDR_OFFICE_1 = Reader["DOC_ADDR_OFFICE_1"].ToString();
                        DOC_ADDR_OFFICE_2 = Reader["DOC_ADDR_OFFICE_2"].ToString();
                        DOC_ADDR_OFFICE_3 = Reader["DOC_ADDR_OFFICE_3"].ToString();
                        DOC_ADDR_OFFICE_PC1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString();
                        DOC_ADDR_OFFICE_PC2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]);
                        DOC_ADDR_OFFICE_PC3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString();
                        DOC_ADDR_OFFICE_PC4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]);
                        DOC_ADDR_OFFICE_PC5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString();
                        DOC_ADDR_OFFICE_PC6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]);
                        DOC_ADDR_HOME_1 = Reader["DOC_ADDR_HOME_1"].ToString();
                        DOC_ADDR_HOME_2 = Reader["DOC_ADDR_HOME_2"].ToString();
                        DOC_ADDR_HOME_3 = Reader["DOC_ADDR_HOME_3"].ToString();
                        DOC_ADDR_HOME_PC1 = Reader["DOC_ADDR_HOME_PC1"].ToString();
                        DOC_ADDR_HOME_PC2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]);
                        DOC_ADDR_HOME_PC3 = Reader["DOC_ADDR_HOME_PC3"].ToString();
                        DOC_ADDR_HOME_PC4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]);
                        DOC_ADDR_HOME_PC5 = Reader["DOC_ADDR_HOME_PC5"].ToString();
                        DOC_ADDR_HOME_PC6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]);
                        DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
                        DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
                        DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
                        DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
                        DOC_DATE_FAC_START_YY = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]);
                        DOC_DATE_FAC_START_MM = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]);
                        DOC_DATE_FAC_START_DD = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]);
                        DOC_DATE_FAC_TERM_YY = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]);
                        DOC_DATE_FAC_TERM_MM = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]);
                        DOC_DATE_FAC_TERM_DD = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]);
                        DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]);
                        DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]);
                        DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]);
                        DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]);
                        DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]);
                        DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]);
                        DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]);
                        DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]);
                        DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]);
                        DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]);
                        DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
                        DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]);
                        DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
                        DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]);
                        DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]);
                        DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]);
                        DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]);
                        CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString();
                        CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString();
                        YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString();
                        YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString();
                        DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
                        DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
                        DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
                        DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
                        DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
                        DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
                        DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString();
                        /*	DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
                            DOC_NX_AVAIL_BATCH_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]);
                            DOC_NX_AVAIL_BATCH_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]);
                            DOC_NX_AVAIL_BATCH_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]);
                            DOC_NX_AVAIL_BATCH_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]);
                            DOC_NX_AVAIL_BATCH_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]); */
                        DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
                        DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
                        DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
                        DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString();
                        DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
                        DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
                        DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
                        DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
                        DOC_EP_PED = Reader["DOC_EP_PED"].ToString();
                        DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
                        DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
                        DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString();
                        DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
                        GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString();
                        GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString();
                        /*	DOC_LOC_1_S1 = Reader["DOC_LOC_1_S1"].ToString();
                            DOC_LOC_1_S2 = Reader["DOC_LOC_1_S2"].ToString();
                            DOC_LOC_1_S3 = Reader["DOC_LOC_1_S3"].ToString();
                            DOC_LOC_2_S1 = Reader["DOC_LOC_2_S1"].ToString();
                            DOC_LOC_2_S2 = Reader["DOC_LOC_2_S2"].ToString();
                            DOC_LOC_2_S3 = Reader["DOC_LOC_2_S3"].ToString();
                            DOC_LOC_3_S1 = Reader["DOC_LOC_3_S1"].ToString();
                            DOC_LOC_3_S2 = Reader["DOC_LOC_3_S2"].ToString();
                            DOC_LOC_3_S3 = Reader["DOC_LOC_3_S3"].ToString();
                            DOC_LOC_4_S1 = Reader["DOC_LOC_4_S1"].ToString();
                            DOC_LOC_4_S2 = Reader["DOC_LOC_4_S2"].ToString();
                            DOC_LOC_4_S3 = Reader["DOC_LOC_4_S3"].ToString();
                            DOC_LOC_5_S1 = Reader["DOC_LOC_5_S1"].ToString();
                            DOC_LOC_5_S2 = Reader["DOC_LOC_5_S2"].ToString();
                            DOC_LOC_5_S3 = Reader["DOC_LOC_5_S3"].ToString();
                            DOC_LOC_6_S1 = Reader["DOC_LOC_6_S1"].ToString();
                            DOC_LOC_6_S2 = Reader["DOC_LOC_6_S2"].ToString();
                            DOC_LOC_6_S3 = Reader["DOC_LOC_6_S3"].ToString();
                            DOC_LOC_7_S1 = Reader["DOC_LOC_7_S1"].ToString();
                            DOC_LOC_7_S2 = Reader["DOC_LOC_7_S2"].ToString();
                            DOC_LOC_7_S3 = Reader["DOC_LOC_7_S3"].ToString();
                            DOC_LOC_8_S1 = Reader["DOC_LOC_8_S1"].ToString();
                            DOC_LOC_8_S2 = Reader["DOC_LOC_8_S2"].ToString();
                            DOC_LOC_8_S3 = Reader["DOC_LOC_8_S3"].ToString();
                            DOC_LOC_9_S1 = Reader["DOC_LOC_9_S1"].ToString();
                            DOC_LOC_9_S2 = Reader["DOC_LOC_9_S2"].ToString();
                            DOC_LOC_9_S3 = Reader["DOC_LOC_9_S3"].ToString();
                            DOC_LOC_10_S1 = Reader["DOC_LOC_10_S1"].ToString();
                            DOC_LOC_10_S2 = Reader["DOC_LOC_10_S2"].ToString();
                            DOC_LOC_10_S3 = Reader["DOC_LOC_10_S3"].ToString();
                            DOC_LOC_11_S1 = Reader["DOC_LOC_11_S1"].ToString();
                            DOC_LOC_11_S2 = Reader["DOC_LOC_11_S2"].ToString();
                            DOC_LOC_11_S3 = Reader["DOC_LOC_11_S3"].ToString();
                            DOC_LOC_12_S1 = Reader["DOC_LOC_12_S1"].ToString();
                            DOC_LOC_12_S2 = Reader["DOC_LOC_12_S2"].ToString();
                            DOC_LOC_12_S3 = Reader["DOC_LOC_12_S3"].ToString();
                            DOC_LOC_13_S1 = Reader["DOC_LOC_13_S1"].ToString();
                            DOC_LOC_13_S2 = Reader["DOC_LOC_13_S2"].ToString();
                            DOC_LOC_13_S3 = Reader["DOC_LOC_13_S3"].ToString();
                            DOC_LOC_14_S1 = Reader["DOC_LOC_14_S1"].ToString();
                            DOC_LOC_14_S2 = Reader["DOC_LOC_14_S2"].ToString();
                            DOC_LOC_14_S3 = Reader["DOC_LOC_14_S3"].ToString();
                            DOC_LOC_15_S1 = Reader["DOC_LOC_15_S1"].ToString();
                            DOC_LOC_15_S2 = Reader["DOC_LOC_15_S2"].ToString();
                            DOC_LOC_15_S3 = Reader["DOC_LOC_15_S3"].ToString();
                            DOC_LOC_16_S1 = Reader["DOC_LOC_16_S1"].ToString();
                            DOC_LOC_16_S2 = Reader["DOC_LOC_16_S2"].ToString();
                            DOC_LOC_16_S3 = Reader["DOC_LOC_16_S3"].ToString();
                            DOC_LOC_17_S1 = Reader["DOC_LOC_17_S1"].ToString();
                            DOC_LOC_17_S2 = Reader["DOC_LOC_17_S2"].ToString();
                            DOC_LOC_17_S3 = Reader["DOC_LOC_17_S3"].ToString();
                            DOC_LOC_18_S1 = Reader["DOC_LOC_18_S1"].ToString();
                            DOC_LOC_18_S2 = Reader["DOC_LOC_18_S2"].ToString();
                            DOC_LOC_18_S3 = Reader["DOC_LOC_18_S3"].ToString();
                            DOC_LOC_19_S1 = Reader["DOC_LOC_19_S1"].ToString();
                            DOC_LOC_19_S2 = Reader["DOC_LOC_19_S2"].ToString();
                            DOC_LOC_19_S3 = Reader["DOC_LOC_19_S3"].ToString();
                            DOC_LOC_20_S1 = Reader["DOC_LOC_20_S1"].ToString();
                            DOC_LOC_20_S2 = Reader["DOC_LOC_20_S2"].ToString();
                            DOC_LOC_20_S3 = Reader["DOC_LOC_20_S3"].ToString();
                            DOC_LOC_21_S1 = Reader["DOC_LOC_21_S1"].ToString();
                            DOC_LOC_21_S2 = Reader["DOC_LOC_21_S2"].ToString();
                            DOC_LOC_21_S3 = Reader["DOC_LOC_21_S3"].ToString();
                            DOC_LOC_22_S1 = Reader["DOC_LOC_22_S1"].ToString();
                            DOC_LOC_22_S2 = Reader["DOC_LOC_22_S2"].ToString();
                            DOC_LOC_22_S3 = Reader["DOC_LOC_22_S3"].ToString();
                            DOC_LOC_23_S1 = Reader["DOC_LOC_23_S1"].ToString();
                            DOC_LOC_23_S2 = Reader["DOC_LOC_23_S2"].ToString();
                            DOC_LOC_23_S3 = Reader["DOC_LOC_23_S3"].ToString();
                            DOC_LOC_24_S1 = Reader["DOC_LOC_24_S1"].ToString();
                            DOC_LOC_24_S2 = Reader["DOC_LOC_24_S2"].ToString();
                            DOC_LOC_24_S3 = Reader["DOC_LOC_24_S3"].ToString();
                            DOC_LOC_25_S1 = Reader["DOC_LOC_25_S1"].ToString();
                            DOC_LOC_25_S2 = Reader["DOC_LOC_25_S2"].ToString();
                            DOC_LOC_25_S3 = Reader["DOC_LOC_25_S3"].ToString();
                            DOC_LOC_26_S1 = Reader["DOC_LOC_26_S1"].ToString();
                            DOC_LOC_26_S2 = Reader["DOC_LOC_26_S2"].ToString();
                            DOC_LOC_26_S3 = Reader["DOC_LOC_26_S3"].ToString();
                            DOC_LOC_27_S1 = Reader["DOC_LOC_27_S1"].ToString();
                            DOC_LOC_27_S2 = Reader["DOC_LOC_27_S2"].ToString();
                            DOC_LOC_27_S3 = Reader["DOC_LOC_27_S3"].ToString();
                            DOC_LOC_28_S1 = Reader["DOC_LOC_28_S1"].ToString();
                            DOC_LOC_28_S2 = Reader["DOC_LOC_28_S2"].ToString();
                            DOC_LOC_28_S3 = Reader["DOC_LOC_28_S3"].ToString();
                            DOC_LOC_29_S1 = Reader["DOC_LOC_29_S1"].ToString();
                            DOC_LOC_29_S2 = Reader["DOC_LOC_29_S2"].ToString();
                            DOC_LOC_29_S3 = Reader["DOC_LOC_29_S3"].ToString();
                            DOC_LOC_30_S1 = Reader["DOC_LOC_30_S1"].ToString();
                            DOC_LOC_30_S2 = Reader["DOC_LOC_30_S2"].ToString();
                            DOC_LOC_30_S3 = Reader["DOC_LOC_30_S3"].ToString(); */
                        CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
                        _originalRowid = (Guid)Reader["ROWID"];
                        _originalDoc_nbr = Reader["DOC_NBR"].ToString();
                        _originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
                        _originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
                        _originalDoc_sin_123 = ConvertDEC(Reader["DOC_SIN_123"]);
                        _originalDoc_sin_456 = ConvertDEC(Reader["DOC_SIN_456"]);
                        _originalDoc_sin_789 = ConvertDEC(Reader["DOC_SIN_789"]);
                        _originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
                        _originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString();
                        _originalDoc_name = Reader["DOC_NAME"].ToString();
                        _originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString();
                        _originalDoc_init1 = Reader["DOC_INIT1"].ToString();
                        _originalDoc_init2 = Reader["DOC_INIT2"].ToString();
                        _originalDoc_init3 = Reader["DOC_INIT3"].ToString();
                        _originalDoc_addr_office_1 = Reader["DOC_ADDR_OFFICE_1"].ToString();
                        _originalDoc_addr_office_2 = Reader["DOC_ADDR_OFFICE_2"].ToString();
                        _originalDoc_addr_office_3 = Reader["DOC_ADDR_OFFICE_3"].ToString();
                        _originalDoc_addr_office_pc1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString();
                        _originalDoc_addr_office_pc2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]);
                        _originalDoc_addr_office_pc3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString();
                        _originalDoc_addr_office_pc4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]);
                        _originalDoc_addr_office_pc5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString();
                        _originalDoc_addr_office_pc6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]);
                        _originalDoc_addr_home_1 = Reader["DOC_ADDR_HOME_1"].ToString();
                        _originalDoc_addr_home_2 = Reader["DOC_ADDR_HOME_2"].ToString();
                        _originalDoc_addr_home_3 = Reader["DOC_ADDR_HOME_3"].ToString();
                        _originalDoc_addr_home_pc1 = Reader["DOC_ADDR_HOME_PC1"].ToString();
                        _originalDoc_addr_home_pc2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]);
                        _originalDoc_addr_home_pc3 = Reader["DOC_ADDR_HOME_PC3"].ToString();
                        _originalDoc_addr_home_pc4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]);
                        _originalDoc_addr_home_pc5 = Reader["DOC_ADDR_HOME_PC5"].ToString();
                        _originalDoc_addr_home_pc6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]);
                        _originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
                        _originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
                        _originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
                        _originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
                        _originalDoc_date_fac_start_yy = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]);
                        _originalDoc_date_fac_start_mm = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]);
                        _originalDoc_date_fac_start_dd = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]);
                        _originalDoc_date_fac_term_yy = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]);
                        _originalDoc_date_fac_term_mm = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]);
                        _originalDoc_date_fac_term_dd = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]);
                        _originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]);
                        _originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]);
                        _originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]);
                        _originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]);
                        _originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]);
                        _originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]);
                        _originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]);
                        _originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]);
                        _originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]);
                        _originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]);
                        _originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
                        _originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]);
                        _originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
                        _originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]);
                        _originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]);
                        _originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]);
                        _originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]);
                        _originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString();
                        _originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString();
                        _originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString();
                        _originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString();
                        _originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
                        _originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
                        _originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
                        _originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
                        _originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
                        _originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
                        _originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString();
                        /*	_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
                            _originalDoc_nx_avail_batch_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]);
                            _originalDoc_nx_avail_batch_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]);
                            _originalDoc_nx_avail_batch_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]);
                            _originalDoc_nx_avail_batch_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]);
                            _originalDoc_nx_avail_batch_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]); */
                        _originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
                        _originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
                        _originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
                        _originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString();
                        _originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
                        _originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
                        _originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
                        _originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
                        _originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString();
                        _originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
                        _originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
                        _originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString();
                        _originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
                        _originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString();
                        _originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString();
                        /*	_originalDoc_loc_1_s1 = Reader["DOC_LOC_1_S1"].ToString();
                            _originalDoc_loc_1_s2 = Reader["DOC_LOC_1_S2"].ToString();
                            _originalDoc_loc_1_s3 = Reader["DOC_LOC_1_S3"].ToString();
                            _originalDoc_loc_2_s1 = Reader["DOC_LOC_2_S1"].ToString();
                            _originalDoc_loc_2_s2 = Reader["DOC_LOC_2_S2"].ToString();
                            _originalDoc_loc_2_s3 = Reader["DOC_LOC_2_S3"].ToString();
                            _originalDoc_loc_3_s1 = Reader["DOC_LOC_3_S1"].ToString();
                            _originalDoc_loc_3_s2 = Reader["DOC_LOC_3_S2"].ToString();
                            _originalDoc_loc_3_s3 = Reader["DOC_LOC_3_S3"].ToString();
                            _originalDoc_loc_4_s1 = Reader["DOC_LOC_4_S1"].ToString();
                            _originalDoc_loc_4_s2 = Reader["DOC_LOC_4_S2"].ToString();
                            _originalDoc_loc_4_s3 = Reader["DOC_LOC_4_S3"].ToString();
                            _originalDoc_loc_5_s1 = Reader["DOC_LOC_5_S1"].ToString();
                            _originalDoc_loc_5_s2 = Reader["DOC_LOC_5_S2"].ToString();
                            _originalDoc_loc_5_s3 = Reader["DOC_LOC_5_S3"].ToString();
                            _originalDoc_loc_6_s1 = Reader["DOC_LOC_6_S1"].ToString();
                            _originalDoc_loc_6_s2 = Reader["DOC_LOC_6_S2"].ToString();
                            _originalDoc_loc_6_s3 = Reader["DOC_LOC_6_S3"].ToString();
                            _originalDoc_loc_7_s1 = Reader["DOC_LOC_7_S1"].ToString();
                            _originalDoc_loc_7_s2 = Reader["DOC_LOC_7_S2"].ToString();
                            _originalDoc_loc_7_s3 = Reader["DOC_LOC_7_S3"].ToString();
                            _originalDoc_loc_8_s1 = Reader["DOC_LOC_8_S1"].ToString();
                            _originalDoc_loc_8_s2 = Reader["DOC_LOC_8_S2"].ToString();
                            _originalDoc_loc_8_s3 = Reader["DOC_LOC_8_S3"].ToString();
                            _originalDoc_loc_9_s1 = Reader["DOC_LOC_9_S1"].ToString();
                            _originalDoc_loc_9_s2 = Reader["DOC_LOC_9_S2"].ToString();
                            _originalDoc_loc_9_s3 = Reader["DOC_LOC_9_S3"].ToString();
                            _originalDoc_loc_10_s1 = Reader["DOC_LOC_10_S1"].ToString();
                            _originalDoc_loc_10_s2 = Reader["DOC_LOC_10_S2"].ToString();
                            _originalDoc_loc_10_s3 = Reader["DOC_LOC_10_S3"].ToString();
                            _originalDoc_loc_11_s1 = Reader["DOC_LOC_11_S1"].ToString();
                            _originalDoc_loc_11_s2 = Reader["DOC_LOC_11_S2"].ToString();
                            _originalDoc_loc_11_s3 = Reader["DOC_LOC_11_S3"].ToString();
                            _originalDoc_loc_12_s1 = Reader["DOC_LOC_12_S1"].ToString();
                            _originalDoc_loc_12_s2 = Reader["DOC_LOC_12_S2"].ToString();
                            _originalDoc_loc_12_s3 = Reader["DOC_LOC_12_S3"].ToString();
                            _originalDoc_loc_13_s1 = Reader["DOC_LOC_13_S1"].ToString();
                            _originalDoc_loc_13_s2 = Reader["DOC_LOC_13_S2"].ToString();
                            _originalDoc_loc_13_s3 = Reader["DOC_LOC_13_S3"].ToString();
                            _originalDoc_loc_14_s1 = Reader["DOC_LOC_14_S1"].ToString();
                            _originalDoc_loc_14_s2 = Reader["DOC_LOC_14_S2"].ToString();
                            _originalDoc_loc_14_s3 = Reader["DOC_LOC_14_S3"].ToString();
                            _originalDoc_loc_15_s1 = Reader["DOC_LOC_15_S1"].ToString();
                            _originalDoc_loc_15_s2 = Reader["DOC_LOC_15_S2"].ToString();
                            _originalDoc_loc_15_s3 = Reader["DOC_LOC_15_S3"].ToString();
                            _originalDoc_loc_16_s1 = Reader["DOC_LOC_16_S1"].ToString();
                            _originalDoc_loc_16_s2 = Reader["DOC_LOC_16_S2"].ToString();
                            _originalDoc_loc_16_s3 = Reader["DOC_LOC_16_S3"].ToString();
                            _originalDoc_loc_17_s1 = Reader["DOC_LOC_17_S1"].ToString();
                            _originalDoc_loc_17_s2 = Reader["DOC_LOC_17_S2"].ToString();
                            _originalDoc_loc_17_s3 = Reader["DOC_LOC_17_S3"].ToString();
                            _originalDoc_loc_18_s1 = Reader["DOC_LOC_18_S1"].ToString();
                            _originalDoc_loc_18_s2 = Reader["DOC_LOC_18_S2"].ToString();
                            _originalDoc_loc_18_s3 = Reader["DOC_LOC_18_S3"].ToString();
                            _originalDoc_loc_19_s1 = Reader["DOC_LOC_19_S1"].ToString();
                            _originalDoc_loc_19_s2 = Reader["DOC_LOC_19_S2"].ToString();
                            _originalDoc_loc_19_s3 = Reader["DOC_LOC_19_S3"].ToString();
                            _originalDoc_loc_20_s1 = Reader["DOC_LOC_20_S1"].ToString();
                            _originalDoc_loc_20_s2 = Reader["DOC_LOC_20_S2"].ToString();
                            _originalDoc_loc_20_s3 = Reader["DOC_LOC_20_S3"].ToString();
                            _originalDoc_loc_21_s1 = Reader["DOC_LOC_21_S1"].ToString();
                            _originalDoc_loc_21_s2 = Reader["DOC_LOC_21_S2"].ToString();
                            _originalDoc_loc_21_s3 = Reader["DOC_LOC_21_S3"].ToString();
                            _originalDoc_loc_22_s1 = Reader["DOC_LOC_22_S1"].ToString();
                            _originalDoc_loc_22_s2 = Reader["DOC_LOC_22_S2"].ToString();
                            _originalDoc_loc_22_s3 = Reader["DOC_LOC_22_S3"].ToString();
                            _originalDoc_loc_23_s1 = Reader["DOC_LOC_23_S1"].ToString();
                            _originalDoc_loc_23_s2 = Reader["DOC_LOC_23_S2"].ToString();
                            _originalDoc_loc_23_s3 = Reader["DOC_LOC_23_S3"].ToString();
                            _originalDoc_loc_24_s1 = Reader["DOC_LOC_24_S1"].ToString();
                            _originalDoc_loc_24_s2 = Reader["DOC_LOC_24_S2"].ToString();
                            _originalDoc_loc_24_s3 = Reader["DOC_LOC_24_S3"].ToString();
                            _originalDoc_loc_25_s1 = Reader["DOC_LOC_25_S1"].ToString();
                            _originalDoc_loc_25_s2 = Reader["DOC_LOC_25_S2"].ToString();
                            _originalDoc_loc_25_s3 = Reader["DOC_LOC_25_S3"].ToString();
                            _originalDoc_loc_26_s1 = Reader["DOC_LOC_26_S1"].ToString();
                            _originalDoc_loc_26_s2 = Reader["DOC_LOC_26_S2"].ToString();
                            _originalDoc_loc_26_s3 = Reader["DOC_LOC_26_S3"].ToString();
                            _originalDoc_loc_27_s1 = Reader["DOC_LOC_27_S1"].ToString();
                            _originalDoc_loc_27_s2 = Reader["DOC_LOC_27_S2"].ToString();
                            _originalDoc_loc_27_s3 = Reader["DOC_LOC_27_S3"].ToString();
                            _originalDoc_loc_28_s1 = Reader["DOC_LOC_28_S1"].ToString();
                            _originalDoc_loc_28_s2 = Reader["DOC_LOC_28_S2"].ToString();
                            _originalDoc_loc_28_s3 = Reader["DOC_LOC_28_S3"].ToString();
                            _originalDoc_loc_29_s1 = Reader["DOC_LOC_29_S1"].ToString();
                            _originalDoc_loc_29_s2 = Reader["DOC_LOC_29_S2"].ToString();
                            _originalDoc_loc_29_s3 = Reader["DOC_LOC_29_S3"].ToString();
                            _originalDoc_loc_30_s1 = Reader["DOC_LOC_30_S1"].ToString();
                            _originalDoc_loc_30_s2 = Reader["DOC_LOC_30_S2"].ToString();
                            _originalDoc_loc_30_s3 = Reader["DOC_LOC_30_S3"].ToString(); */
                        _originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
                    }

                    break;
                case State.Modified:
                    parameters = new SqlParameter[]
                    {
                        new SqlParameter("RowCheckSum",RowCheckSum),
                        new SqlParameter("ROWID", ROWID),
                        new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
                        new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
                        new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
                        new SqlParameter("DOC_SIN_123", SqlNull(DOC_SIN_123)),
                        new SqlParameter("DOC_SIN_456", SqlNull(DOC_SIN_456)),
                        new SqlParameter("DOC_SIN_789", SqlNull(DOC_SIN_789)),
                        new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
                        new SqlParameter("DOC_HOSP_NBR", SqlNull(DOC_HOSP_NBR)),
                        new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
                        new SqlParameter("DOC_NAME_SOUNDEX", SqlNull(DOC_NAME_SOUNDEX)),
                        new SqlParameter("DOC_INIT1", SqlNull(DOC_INIT1)),
                        new SqlParameter("DOC_INIT2", SqlNull(DOC_INIT2)),
                        new SqlParameter("DOC_INIT3", SqlNull(DOC_INIT3)),
                        new SqlParameter("DOC_ADDR_OFFICE_1", SqlNull(DOC_ADDR_OFFICE_1)),
                        new SqlParameter("DOC_ADDR_OFFICE_2", SqlNull(DOC_ADDR_OFFICE_2)),
                        new SqlParameter("DOC_ADDR_OFFICE_3", SqlNull(DOC_ADDR_OFFICE_3)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC1", SqlNull(DOC_ADDR_OFFICE_PC1)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC2", SqlNull(DOC_ADDR_OFFICE_PC2)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC3", SqlNull(DOC_ADDR_OFFICE_PC3)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC4", SqlNull(DOC_ADDR_OFFICE_PC4)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC5", SqlNull(DOC_ADDR_OFFICE_PC5)),
                        new SqlParameter("DOC_ADDR_OFFICE_PC6", SqlNull(DOC_ADDR_OFFICE_PC6)),
                        new SqlParameter("DOC_ADDR_HOME_1", SqlNull(DOC_ADDR_HOME_1)),
                        new SqlParameter("DOC_ADDR_HOME_2", SqlNull(DOC_ADDR_HOME_2)),
                        new SqlParameter("DOC_ADDR_HOME_3", SqlNull(DOC_ADDR_HOME_3)),
                        new SqlParameter("DOC_ADDR_HOME_PC1", SqlNull(DOC_ADDR_HOME_PC1)),
                        new SqlParameter("DOC_ADDR_HOME_PC2", SqlNull(DOC_ADDR_HOME_PC2)),
                        new SqlParameter("DOC_ADDR_HOME_PC3", SqlNull(DOC_ADDR_HOME_PC3)),
                        new SqlParameter("DOC_ADDR_HOME_PC4", SqlNull(DOC_ADDR_HOME_PC4)),
                        new SqlParameter("DOC_ADDR_HOME_PC5", SqlNull(DOC_ADDR_HOME_PC5)),
                        new SqlParameter("DOC_ADDR_HOME_PC6", SqlNull(DOC_ADDR_HOME_PC6)),
                        new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
                        new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
                        new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
                        new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
                        new SqlParameter("DOC_DATE_FAC_START_YY", SqlNull(DOC_DATE_FAC_START_YY)),
                        new SqlParameter("DOC_DATE_FAC_START_MM", SqlNull(DOC_DATE_FAC_START_MM)),
                        new SqlParameter("DOC_DATE_FAC_START_DD", SqlNull(DOC_DATE_FAC_START_DD)),
                        new SqlParameter("DOC_DATE_FAC_TERM_YY", SqlNull(DOC_DATE_FAC_TERM_YY)),
                        new SqlParameter("DOC_DATE_FAC_TERM_MM", SqlNull(DOC_DATE_FAC_TERM_MM)),
                        new SqlParameter("DOC_DATE_FAC_TERM_DD", SqlNull(DOC_DATE_FAC_TERM_DD)),
                        new SqlParameter("DOC_YTDGUA", SqlNull(DOC_YTDGUA)),
                        new SqlParameter("DOC_YTDGUB", SqlNull(DOC_YTDGUB)),
                        new SqlParameter("DOC_YTDGUC", SqlNull(DOC_YTDGUC)),
                        new SqlParameter("DOC_YTDGUD", SqlNull(DOC_YTDGUD)),
                        new SqlParameter("DOC_YTDCEA", SqlNull(DOC_YTDCEA)),
                        new SqlParameter("DOC_YTDCEX", SqlNull(DOC_YTDCEX)),
                        new SqlParameter("DOC_YTDEAR", SqlNull(DOC_YTDEAR)),
                        new SqlParameter("DOC_YTDINC", SqlNull(DOC_YTDINC)),
                        new SqlParameter("DOC_YTDEFT", SqlNull(DOC_YTDEFT)),
                        new SqlParameter("DOC_TOTINC_G", SqlNull(DOC_TOTINC_G)),
                        new SqlParameter("DOC_EP_DATE_DEPOSIT", SqlNull(DOC_EP_DATE_DEPOSIT)),
                        new SqlParameter("DOC_TOTINC", SqlNull(DOC_TOTINC)),
                        new SqlParameter("DOC_EP_CEIEXP", SqlNull(DOC_EP_CEIEXP)),
                        new SqlParameter("DOC_ADJCEA", SqlNull(DOC_ADJCEA)),
                        new SqlParameter("DOC_ADJCEX", SqlNull(DOC_ADJCEX)),
                        new SqlParameter("DOC_CEICEA", SqlNull(DOC_CEICEA)),
                        new SqlParameter("DOC_CEICEX", SqlNull(DOC_CEICEX)),
                        new SqlParameter("CEICEA_PRT_FORMAT", SqlNull(CEICEA_PRT_FORMAT)),
                        new SqlParameter("CEICEX_PRT_FORMAT", SqlNull(CEICEX_PRT_FORMAT)),
                        new SqlParameter("YTDCEA_PRT_FORMAT", SqlNull(YTDCEA_PRT_FORMAT)),
                        new SqlParameter("YTDCEX_PRT_FORMAT", SqlNull(YTDCEX_PRT_FORMAT)),
                        new SqlParameter("DOC_SPEC_CD_2", SqlNull(DOC_SPEC_CD_2)),
                        new SqlParameter("DOC_SPEC_CD_3", SqlNull(DOC_SPEC_CD_3)),
                        new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
                        new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
                        new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
                        new SqlParameter("DOC_DEPT_2", SqlNull(DOC_DEPT_2)),
                        new SqlParameter("DOC_IND_PAYS_GST", SqlNull(DOC_IND_PAYS_GST)),
					/*	new SqlParameter("DOC_NX_AVAIL_BATCH", SqlNull(DOC_NX_AVAIL_BATCH)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_2", SqlNull(DOC_NX_AVAIL_BATCH_2)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_3", SqlNull(DOC_NX_AVAIL_BATCH_3)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_4", SqlNull(DOC_NX_AVAIL_BATCH_4)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_5", SqlNull(DOC_NX_AVAIL_BATCH_5)),
						new SqlParameter("DOC_NX_AVAIL_BATCH_6", SqlNull(DOC_NX_AVAIL_BATCH_6)), */
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
                        new SqlParameter("DOC_YRLY_EXPENSE_COMPUTED", SqlNull(DOC_YRLY_EXPENSE_COMPUTED)),
                        new SqlParameter("DOC_RMA_EXPENSE_PERCENT_REG", SqlNull(DOC_RMA_EXPENSE_PERCENT_REG)),
                        new SqlParameter("DOC_SUB_SPECIALTY", SqlNull(DOC_SUB_SPECIALTY)),
                        new SqlParameter("DOC_PAYEFT", SqlNull(DOC_PAYEFT)),
                        new SqlParameter("DOC_YTDDED", SqlNull(DOC_YTDDED)),
                        new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_MISC", SqlNull(DOC_DEPT_EXPENSE_PERCENT_MISC)),
                        new SqlParameter("DOC_DEPT_EXPENSE_PERCENT_REG", SqlNull(DOC_DEPT_EXPENSE_PERCENT_REG)),
                        new SqlParameter("DOC_EP_PED", SqlNull(DOC_EP_PED)),
                        new SqlParameter("DOC_EP_PAY_CODE", SqlNull(DOC_EP_PAY_CODE)),
                        new SqlParameter("DOC_EP_PAY_SUB_CODE", SqlNull(DOC_EP_PAY_SUB_CODE)),
                        new SqlParameter("DOC_PARTNERSHIP", SqlNull(DOC_PARTNERSHIP)),
                        new SqlParameter("DOC_IND_HOLDBACK_ACTIVE", SqlNull(DOC_IND_HOLDBACK_ACTIVE)),
                        new SqlParameter("GROUP_REGULAR_SERVICE", SqlNull(GROUP_REGULAR_SERVICE)),
                        new SqlParameter("GROUP_OVER_SERVICED", SqlNull(GROUP_OVER_SERVICED)),
					/*	new SqlParameter("DOC_LOC_1_S1", SqlNull(DOC_LOC_1_S1)),
						new SqlParameter("DOC_LOC_1_S2", SqlNull(DOC_LOC_1_S2)),
						new SqlParameter("DOC_LOC_1_S3", SqlNull(DOC_LOC_1_S3)),
						new SqlParameter("DOC_LOC_2_S1", SqlNull(DOC_LOC_2_S1)),
						new SqlParameter("DOC_LOC_2_S2", SqlNull(DOC_LOC_2_S2)),
						new SqlParameter("DOC_LOC_2_S3", SqlNull(DOC_LOC_2_S3)),
						new SqlParameter("DOC_LOC_3_S1", SqlNull(DOC_LOC_3_S1)),
						new SqlParameter("DOC_LOC_3_S2", SqlNull(DOC_LOC_3_S2)),
						new SqlParameter("DOC_LOC_3_S3", SqlNull(DOC_LOC_3_S3)),
						new SqlParameter("DOC_LOC_4_S1", SqlNull(DOC_LOC_4_S1)),
						new SqlParameter("DOC_LOC_4_S2", SqlNull(DOC_LOC_4_S2)),
						new SqlParameter("DOC_LOC_4_S3", SqlNull(DOC_LOC_4_S3)),
						new SqlParameter("DOC_LOC_5_S1", SqlNull(DOC_LOC_5_S1)),
						new SqlParameter("DOC_LOC_5_S2", SqlNull(DOC_LOC_5_S2)),
						new SqlParameter("DOC_LOC_5_S3", SqlNull(DOC_LOC_5_S3)),
						new SqlParameter("DOC_LOC_6_S1", SqlNull(DOC_LOC_6_S1)),
						new SqlParameter("DOC_LOC_6_S2", SqlNull(DOC_LOC_6_S2)),
						new SqlParameter("DOC_LOC_6_S3", SqlNull(DOC_LOC_6_S3)),
						new SqlParameter("DOC_LOC_7_S1", SqlNull(DOC_LOC_7_S1)),
						new SqlParameter("DOC_LOC_7_S2", SqlNull(DOC_LOC_7_S2)),
						new SqlParameter("DOC_LOC_7_S3", SqlNull(DOC_LOC_7_S3)),
						new SqlParameter("DOC_LOC_8_S1", SqlNull(DOC_LOC_8_S1)),
						new SqlParameter("DOC_LOC_8_S2", SqlNull(DOC_LOC_8_S2)),
						new SqlParameter("DOC_LOC_8_S3", SqlNull(DOC_LOC_8_S3)),
						new SqlParameter("DOC_LOC_9_S1", SqlNull(DOC_LOC_9_S1)),
						new SqlParameter("DOC_LOC_9_S2", SqlNull(DOC_LOC_9_S2)),
						new SqlParameter("DOC_LOC_9_S3", SqlNull(DOC_LOC_9_S3)),
						new SqlParameter("DOC_LOC_10_S1", SqlNull(DOC_LOC_10_S1)),
						new SqlParameter("DOC_LOC_10_S2", SqlNull(DOC_LOC_10_S2)),
						new SqlParameter("DOC_LOC_10_S3", SqlNull(DOC_LOC_10_S3)),
						new SqlParameter("DOC_LOC_11_S1", SqlNull(DOC_LOC_11_S1)),
						new SqlParameter("DOC_LOC_11_S2", SqlNull(DOC_LOC_11_S2)),
						new SqlParameter("DOC_LOC_11_S3", SqlNull(DOC_LOC_11_S3)),
						new SqlParameter("DOC_LOC_12_S1", SqlNull(DOC_LOC_12_S1)),
						new SqlParameter("DOC_LOC_12_S2", SqlNull(DOC_LOC_12_S2)),
						new SqlParameter("DOC_LOC_12_S3", SqlNull(DOC_LOC_12_S3)),
						new SqlParameter("DOC_LOC_13_S1", SqlNull(DOC_LOC_13_S1)),
						new SqlParameter("DOC_LOC_13_S2", SqlNull(DOC_LOC_13_S2)),
						new SqlParameter("DOC_LOC_13_S3", SqlNull(DOC_LOC_13_S3)),
						new SqlParameter("DOC_LOC_14_S1", SqlNull(DOC_LOC_14_S1)),
						new SqlParameter("DOC_LOC_14_S2", SqlNull(DOC_LOC_14_S2)),
						new SqlParameter("DOC_LOC_14_S3", SqlNull(DOC_LOC_14_S3)),
						new SqlParameter("DOC_LOC_15_S1", SqlNull(DOC_LOC_15_S1)),
						new SqlParameter("DOC_LOC_15_S2", SqlNull(DOC_LOC_15_S2)),
						new SqlParameter("DOC_LOC_15_S3", SqlNull(DOC_LOC_15_S3)),
						new SqlParameter("DOC_LOC_16_S1", SqlNull(DOC_LOC_16_S1)),
						new SqlParameter("DOC_LOC_16_S2", SqlNull(DOC_LOC_16_S2)),
						new SqlParameter("DOC_LOC_16_S3", SqlNull(DOC_LOC_16_S3)),
						new SqlParameter("DOC_LOC_17_S1", SqlNull(DOC_LOC_17_S1)),
						new SqlParameter("DOC_LOC_17_S2", SqlNull(DOC_LOC_17_S2)),
						new SqlParameter("DOC_LOC_17_S3", SqlNull(DOC_LOC_17_S3)),
						new SqlParameter("DOC_LOC_18_S1", SqlNull(DOC_LOC_18_S1)),
						new SqlParameter("DOC_LOC_18_S2", SqlNull(DOC_LOC_18_S2)),
						new SqlParameter("DOC_LOC_18_S3", SqlNull(DOC_LOC_18_S3)),
						new SqlParameter("DOC_LOC_19_S1", SqlNull(DOC_LOC_19_S1)),
						new SqlParameter("DOC_LOC_19_S2", SqlNull(DOC_LOC_19_S2)),
						new SqlParameter("DOC_LOC_19_S3", SqlNull(DOC_LOC_19_S3)),
						new SqlParameter("DOC_LOC_20_S1", SqlNull(DOC_LOC_20_S1)),
						new SqlParameter("DOC_LOC_20_S2", SqlNull(DOC_LOC_20_S2)),
						new SqlParameter("DOC_LOC_20_S3", SqlNull(DOC_LOC_20_S3)),
						new SqlParameter("DOC_LOC_21_S1", SqlNull(DOC_LOC_21_S1)),
						new SqlParameter("DOC_LOC_21_S2", SqlNull(DOC_LOC_21_S2)),
						new SqlParameter("DOC_LOC_21_S3", SqlNull(DOC_LOC_21_S3)),
						new SqlParameter("DOC_LOC_22_S1", SqlNull(DOC_LOC_22_S1)),
						new SqlParameter("DOC_LOC_22_S2", SqlNull(DOC_LOC_22_S2)),
						new SqlParameter("DOC_LOC_22_S3", SqlNull(DOC_LOC_22_S3)),
						new SqlParameter("DOC_LOC_23_S1", SqlNull(DOC_LOC_23_S1)),
						new SqlParameter("DOC_LOC_23_S2", SqlNull(DOC_LOC_23_S2)),
						new SqlParameter("DOC_LOC_23_S3", SqlNull(DOC_LOC_23_S3)),
						new SqlParameter("DOC_LOC_24_S1", SqlNull(DOC_LOC_24_S1)),
						new SqlParameter("DOC_LOC_24_S2", SqlNull(DOC_LOC_24_S2)),
						new SqlParameter("DOC_LOC_24_S3", SqlNull(DOC_LOC_24_S3)),
						new SqlParameter("DOC_LOC_25_S1", SqlNull(DOC_LOC_25_S1)),
						new SqlParameter("DOC_LOC_25_S2", SqlNull(DOC_LOC_25_S2)),
						new SqlParameter("DOC_LOC_25_S3", SqlNull(DOC_LOC_25_S3)),
						new SqlParameter("DOC_LOC_26_S1", SqlNull(DOC_LOC_26_S1)),
						new SqlParameter("DOC_LOC_26_S2", SqlNull(DOC_LOC_26_S2)),
						new SqlParameter("DOC_LOC_26_S3", SqlNull(DOC_LOC_26_S3)),
						new SqlParameter("DOC_LOC_27_S1", SqlNull(DOC_LOC_27_S1)),
						new SqlParameter("DOC_LOC_27_S2", SqlNull(DOC_LOC_27_S2)),
						new SqlParameter("DOC_LOC_27_S3", SqlNull(DOC_LOC_27_S3)),
						new SqlParameter("DOC_LOC_28_S1", SqlNull(DOC_LOC_28_S1)),
						new SqlParameter("DOC_LOC_28_S2", SqlNull(DOC_LOC_28_S2)),
						new SqlParameter("DOC_LOC_28_S3", SqlNull(DOC_LOC_28_S3)),
						new SqlParameter("DOC_LOC_29_S1", SqlNull(DOC_LOC_29_S1)),
						new SqlParameter("DOC_LOC_29_S2", SqlNull(DOC_LOC_29_S2)),
						new SqlParameter("DOC_LOC_29_S3", SqlNull(DOC_LOC_29_S3)),
						new SqlParameter("DOC_LOC_30_S1", SqlNull(DOC_LOC_30_S1)),
						new SqlParameter("DOC_LOC_30_S2", SqlNull(DOC_LOC_30_S2)),
						new SqlParameter("DOC_LOC_30_S3", SqlNull(DOC_LOC_30_S3)), */
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
                    };
                    Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_MSTR_Update]", parameters);
                    if (Reader.Read())
                    {
                        RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
                        ROWID = (Guid)Reader["ROWID"];
                        DOC_NBR = Reader["DOC_NBR"].ToString();
                        DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
                        DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
                        DOC_SIN_123 = ConvertDEC(Reader["DOC_SIN_123"]);
                        DOC_SIN_456 = ConvertDEC(Reader["DOC_SIN_456"]);
                        DOC_SIN_789 = ConvertDEC(Reader["DOC_SIN_789"]);
                        DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
                        DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString();
                        DOC_NAME = Reader["DOC_NAME"].ToString();
                        DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString();
                        DOC_INIT1 = Reader["DOC_INIT1"].ToString();
                        DOC_INIT2 = Reader["DOC_INIT2"].ToString();
                        DOC_INIT3 = Reader["DOC_INIT3"].ToString();
                        DOC_ADDR_OFFICE_1 = Reader["DOC_ADDR_OFFICE_1"].ToString();
                        DOC_ADDR_OFFICE_2 = Reader["DOC_ADDR_OFFICE_2"].ToString();
                        DOC_ADDR_OFFICE_3 = Reader["DOC_ADDR_OFFICE_3"].ToString();
                        DOC_ADDR_OFFICE_PC1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString();
                        DOC_ADDR_OFFICE_PC2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]);
                        DOC_ADDR_OFFICE_PC3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString();
                        DOC_ADDR_OFFICE_PC4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]);
                        DOC_ADDR_OFFICE_PC5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString();
                        DOC_ADDR_OFFICE_PC6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]);
                        DOC_ADDR_HOME_1 = Reader["DOC_ADDR_HOME_1"].ToString();
                        DOC_ADDR_HOME_2 = Reader["DOC_ADDR_HOME_2"].ToString();
                        DOC_ADDR_HOME_3 = Reader["DOC_ADDR_HOME_3"].ToString();
                        DOC_ADDR_HOME_PC1 = Reader["DOC_ADDR_HOME_PC1"].ToString();
                        DOC_ADDR_HOME_PC2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]);
                        DOC_ADDR_HOME_PC3 = Reader["DOC_ADDR_HOME_PC3"].ToString();
                        DOC_ADDR_HOME_PC4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]);
                        DOC_ADDR_HOME_PC5 = Reader["DOC_ADDR_HOME_PC5"].ToString();
                        DOC_ADDR_HOME_PC6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]);
                        DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
                        DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
                        DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
                        DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
                        DOC_DATE_FAC_START_YY = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]);
                        DOC_DATE_FAC_START_MM = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]);
                        DOC_DATE_FAC_START_DD = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]);
                        DOC_DATE_FAC_TERM_YY = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]);
                        DOC_DATE_FAC_TERM_MM = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]);
                        DOC_DATE_FAC_TERM_DD = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]);
                        DOC_YTDGUA = ConvertDEC(Reader["DOC_YTDGUA"]);
                        DOC_YTDGUB = ConvertDEC(Reader["DOC_YTDGUB"]);
                        DOC_YTDGUC = ConvertDEC(Reader["DOC_YTDGUC"]);
                        DOC_YTDGUD = ConvertDEC(Reader["DOC_YTDGUD"]);
                        DOC_YTDCEA = ConvertDEC(Reader["DOC_YTDCEA"]);
                        DOC_YTDCEX = ConvertDEC(Reader["DOC_YTDCEX"]);
                        DOC_YTDEAR = ConvertDEC(Reader["DOC_YTDEAR"]);
                        DOC_YTDINC = ConvertDEC(Reader["DOC_YTDINC"]);
                        DOC_YTDEFT = ConvertDEC(Reader["DOC_YTDEFT"]);
                        DOC_TOTINC_G = ConvertDEC(Reader["DOC_TOTINC_G"]);
                        DOC_EP_DATE_DEPOSIT = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
                        DOC_TOTINC = ConvertDEC(Reader["DOC_TOTINC"]);
                        DOC_EP_CEIEXP = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
                        DOC_ADJCEA = ConvertDEC(Reader["DOC_ADJCEA"]);
                        DOC_ADJCEX = ConvertDEC(Reader["DOC_ADJCEX"]);
                        DOC_CEICEA = ConvertDEC(Reader["DOC_CEICEA"]);
                        DOC_CEICEX = ConvertDEC(Reader["DOC_CEICEX"]);
                        CEICEA_PRT_FORMAT = Reader["CEICEA_PRT_FORMAT"].ToString();
                        CEICEX_PRT_FORMAT = Reader["CEICEX_PRT_FORMAT"].ToString();
                        YTDCEA_PRT_FORMAT = Reader["YTDCEA_PRT_FORMAT"].ToString();
                        YTDCEX_PRT_FORMAT = Reader["YTDCEX_PRT_FORMAT"].ToString();
                        DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
                        DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
                        DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
                        DOC_RMA_EXPENSE_PERCENT_MISC = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
                        DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
                        DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
                        DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString();
                        /*	DOC_NX_AVAIL_BATCH = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
                            DOC_NX_AVAIL_BATCH_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]);
                            DOC_NX_AVAIL_BATCH_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]);
                            DOC_NX_AVAIL_BATCH_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]);
                            DOC_NX_AVAIL_BATCH_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]);
                            DOC_NX_AVAIL_BATCH_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]); */
                        DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
                        DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
                        DOC_RMA_EXPENSE_PERCENT_REG = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
                        DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString();
                        DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
                        DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
                        DOC_DEPT_EXPENSE_PERCENT_MISC = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
                        DOC_DEPT_EXPENSE_PERCENT_REG = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
                        DOC_EP_PED = Reader["DOC_EP_PED"].ToString();
                        DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
                        DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
                        DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString();
                        DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
                        GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString();
                        GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString();
                        /*	DOC_LOC_1_S1 = Reader["DOC_LOC_1_S1"].ToString();
                            DOC_LOC_1_S2 = Reader["DOC_LOC_1_S2"].ToString();
                            DOC_LOC_1_S3 = Reader["DOC_LOC_1_S3"].ToString();
                            DOC_LOC_2_S1 = Reader["DOC_LOC_2_S1"].ToString();
                            DOC_LOC_2_S2 = Reader["DOC_LOC_2_S2"].ToString();
                            DOC_LOC_2_S3 = Reader["DOC_LOC_2_S3"].ToString();
                            DOC_LOC_3_S1 = Reader["DOC_LOC_3_S1"].ToString();
                            DOC_LOC_3_S2 = Reader["DOC_LOC_3_S2"].ToString();
                            DOC_LOC_3_S3 = Reader["DOC_LOC_3_S3"].ToString();
                            DOC_LOC_4_S1 = Reader["DOC_LOC_4_S1"].ToString();
                            DOC_LOC_4_S2 = Reader["DOC_LOC_4_S2"].ToString();
                            DOC_LOC_4_S3 = Reader["DOC_LOC_4_S3"].ToString();
                            DOC_LOC_5_S1 = Reader["DOC_LOC_5_S1"].ToString();
                            DOC_LOC_5_S2 = Reader["DOC_LOC_5_S2"].ToString();
                            DOC_LOC_5_S3 = Reader["DOC_LOC_5_S3"].ToString();
                            DOC_LOC_6_S1 = Reader["DOC_LOC_6_S1"].ToString();
                            DOC_LOC_6_S2 = Reader["DOC_LOC_6_S2"].ToString();
                            DOC_LOC_6_S3 = Reader["DOC_LOC_6_S3"].ToString();
                            DOC_LOC_7_S1 = Reader["DOC_LOC_7_S1"].ToString();
                            DOC_LOC_7_S2 = Reader["DOC_LOC_7_S2"].ToString();
                            DOC_LOC_7_S3 = Reader["DOC_LOC_7_S3"].ToString();
                            DOC_LOC_8_S1 = Reader["DOC_LOC_8_S1"].ToString();
                            DOC_LOC_8_S2 = Reader["DOC_LOC_8_S2"].ToString();
                            DOC_LOC_8_S3 = Reader["DOC_LOC_8_S3"].ToString();
                            DOC_LOC_9_S1 = Reader["DOC_LOC_9_S1"].ToString();
                            DOC_LOC_9_S2 = Reader["DOC_LOC_9_S2"].ToString();
                            DOC_LOC_9_S3 = Reader["DOC_LOC_9_S3"].ToString();
                            DOC_LOC_10_S1 = Reader["DOC_LOC_10_S1"].ToString();
                            DOC_LOC_10_S2 = Reader["DOC_LOC_10_S2"].ToString();
                            DOC_LOC_10_S3 = Reader["DOC_LOC_10_S3"].ToString();
                            DOC_LOC_11_S1 = Reader["DOC_LOC_11_S1"].ToString();
                            DOC_LOC_11_S2 = Reader["DOC_LOC_11_S2"].ToString();
                            DOC_LOC_11_S3 = Reader["DOC_LOC_11_S3"].ToString();
                            DOC_LOC_12_S1 = Reader["DOC_LOC_12_S1"].ToString();
                            DOC_LOC_12_S2 = Reader["DOC_LOC_12_S2"].ToString();
                            DOC_LOC_12_S3 = Reader["DOC_LOC_12_S3"].ToString();
                            DOC_LOC_13_S1 = Reader["DOC_LOC_13_S1"].ToString();
                            DOC_LOC_13_S2 = Reader["DOC_LOC_13_S2"].ToString();
                            DOC_LOC_13_S3 = Reader["DOC_LOC_13_S3"].ToString();
                            DOC_LOC_14_S1 = Reader["DOC_LOC_14_S1"].ToString();
                            DOC_LOC_14_S2 = Reader["DOC_LOC_14_S2"].ToString();
                            DOC_LOC_14_S3 = Reader["DOC_LOC_14_S3"].ToString();
                            DOC_LOC_15_S1 = Reader["DOC_LOC_15_S1"].ToString();
                            DOC_LOC_15_S2 = Reader["DOC_LOC_15_S2"].ToString();
                            DOC_LOC_15_S3 = Reader["DOC_LOC_15_S3"].ToString();
                            DOC_LOC_16_S1 = Reader["DOC_LOC_16_S1"].ToString();
                            DOC_LOC_16_S2 = Reader["DOC_LOC_16_S2"].ToString();
                            DOC_LOC_16_S3 = Reader["DOC_LOC_16_S3"].ToString();
                            DOC_LOC_17_S1 = Reader["DOC_LOC_17_S1"].ToString();
                            DOC_LOC_17_S2 = Reader["DOC_LOC_17_S2"].ToString();
                            DOC_LOC_17_S3 = Reader["DOC_LOC_17_S3"].ToString();
                            DOC_LOC_18_S1 = Reader["DOC_LOC_18_S1"].ToString();
                            DOC_LOC_18_S2 = Reader["DOC_LOC_18_S2"].ToString();
                            DOC_LOC_18_S3 = Reader["DOC_LOC_18_S3"].ToString();
                            DOC_LOC_19_S1 = Reader["DOC_LOC_19_S1"].ToString();
                            DOC_LOC_19_S2 = Reader["DOC_LOC_19_S2"].ToString();
                            DOC_LOC_19_S3 = Reader["DOC_LOC_19_S3"].ToString();
                            DOC_LOC_20_S1 = Reader["DOC_LOC_20_S1"].ToString();
                            DOC_LOC_20_S2 = Reader["DOC_LOC_20_S2"].ToString();
                            DOC_LOC_20_S3 = Reader["DOC_LOC_20_S3"].ToString();
                            DOC_LOC_21_S1 = Reader["DOC_LOC_21_S1"].ToString();
                            DOC_LOC_21_S2 = Reader["DOC_LOC_21_S2"].ToString();
                            DOC_LOC_21_S3 = Reader["DOC_LOC_21_S3"].ToString();
                            DOC_LOC_22_S1 = Reader["DOC_LOC_22_S1"].ToString();
                            DOC_LOC_22_S2 = Reader["DOC_LOC_22_S2"].ToString();
                            DOC_LOC_22_S3 = Reader["DOC_LOC_22_S3"].ToString();
                            DOC_LOC_23_S1 = Reader["DOC_LOC_23_S1"].ToString();
                            DOC_LOC_23_S2 = Reader["DOC_LOC_23_S2"].ToString();
                            DOC_LOC_23_S3 = Reader["DOC_LOC_23_S3"].ToString();
                            DOC_LOC_24_S1 = Reader["DOC_LOC_24_S1"].ToString();
                            DOC_LOC_24_S2 = Reader["DOC_LOC_24_S2"].ToString();
                            DOC_LOC_24_S3 = Reader["DOC_LOC_24_S3"].ToString();
                            DOC_LOC_25_S1 = Reader["DOC_LOC_25_S1"].ToString();
                            DOC_LOC_25_S2 = Reader["DOC_LOC_25_S2"].ToString();
                            DOC_LOC_25_S3 = Reader["DOC_LOC_25_S3"].ToString();
                            DOC_LOC_26_S1 = Reader["DOC_LOC_26_S1"].ToString();
                            DOC_LOC_26_S2 = Reader["DOC_LOC_26_S2"].ToString();
                            DOC_LOC_26_S3 = Reader["DOC_LOC_26_S3"].ToString();
                            DOC_LOC_27_S1 = Reader["DOC_LOC_27_S1"].ToString();
                            DOC_LOC_27_S2 = Reader["DOC_LOC_27_S2"].ToString();
                            DOC_LOC_27_S3 = Reader["DOC_LOC_27_S3"].ToString();
                            DOC_LOC_28_S1 = Reader["DOC_LOC_28_S1"].ToString();
                            DOC_LOC_28_S2 = Reader["DOC_LOC_28_S2"].ToString();
                            DOC_LOC_28_S3 = Reader["DOC_LOC_28_S3"].ToString();
                            DOC_LOC_29_S1 = Reader["DOC_LOC_29_S1"].ToString();
                            DOC_LOC_29_S2 = Reader["DOC_LOC_29_S2"].ToString();
                            DOC_LOC_29_S3 = Reader["DOC_LOC_29_S3"].ToString();
                            DOC_LOC_30_S1 = Reader["DOC_LOC_30_S1"].ToString();
                            DOC_LOC_30_S2 = Reader["DOC_LOC_30_S2"].ToString();
                            DOC_LOC_30_S3 = Reader["DOC_LOC_30_S3"].ToString(); */
                        CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
                        _originalRowid = (Guid)Reader["ROWID"];
                        _originalDoc_nbr = Reader["DOC_NBR"].ToString();
                        _originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
                        _originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
                        _originalDoc_sin_123 = ConvertDEC(Reader["DOC_SIN_123"]);
                        _originalDoc_sin_456 = ConvertDEC(Reader["DOC_SIN_456"]);
                        _originalDoc_sin_789 = ConvertDEC(Reader["DOC_SIN_789"]);
                        _originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
                        _originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString();
                        _originalDoc_name = Reader["DOC_NAME"].ToString();
                        _originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString();
                        _originalDoc_init1 = Reader["DOC_INIT1"].ToString();
                        _originalDoc_init2 = Reader["DOC_INIT2"].ToString();
                        _originalDoc_init3 = Reader["DOC_INIT3"].ToString();
                        _originalDoc_addr_office_1 = Reader["DOC_ADDR_OFFICE_1"].ToString();
                        _originalDoc_addr_office_2 = Reader["DOC_ADDR_OFFICE_2"].ToString();
                        _originalDoc_addr_office_3 = Reader["DOC_ADDR_OFFICE_3"].ToString();
                        _originalDoc_addr_office_pc1 = Reader["DOC_ADDR_OFFICE_PC1"].ToString();
                        _originalDoc_addr_office_pc2 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC2"]);
                        _originalDoc_addr_office_pc3 = Reader["DOC_ADDR_OFFICE_PC3"].ToString();
                        _originalDoc_addr_office_pc4 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC4"]);
                        _originalDoc_addr_office_pc5 = Reader["DOC_ADDR_OFFICE_PC5"].ToString();
                        _originalDoc_addr_office_pc6 = ConvertDEC(Reader["DOC_ADDR_OFFICE_PC6"]);
                        _originalDoc_addr_home_1 = Reader["DOC_ADDR_HOME_1"].ToString();
                        _originalDoc_addr_home_2 = Reader["DOC_ADDR_HOME_2"].ToString();
                        _originalDoc_addr_home_3 = Reader["DOC_ADDR_HOME_3"].ToString();
                        _originalDoc_addr_home_pc1 = Reader["DOC_ADDR_HOME_PC1"].ToString();
                        _originalDoc_addr_home_pc2 = ConvertDEC(Reader["DOC_ADDR_HOME_PC2"]);
                        _originalDoc_addr_home_pc3 = Reader["DOC_ADDR_HOME_PC3"].ToString();
                        _originalDoc_addr_home_pc4 = ConvertDEC(Reader["DOC_ADDR_HOME_PC4"]);
                        _originalDoc_addr_home_pc5 = Reader["DOC_ADDR_HOME_PC5"].ToString();
                        _originalDoc_addr_home_pc6 = ConvertDEC(Reader["DOC_ADDR_HOME_PC6"]);
                        _originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
                        _originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
                        _originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
                        _originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
                        _originalDoc_date_fac_start_yy = ConvertDEC(Reader["DOC_DATE_FAC_START_YY"]);
                        _originalDoc_date_fac_start_mm = ConvertDEC(Reader["DOC_DATE_FAC_START_MM"]);
                        _originalDoc_date_fac_start_dd = ConvertDEC(Reader["DOC_DATE_FAC_START_DD"]);
                        _originalDoc_date_fac_term_yy = ConvertDEC(Reader["DOC_DATE_FAC_TERM_YY"]);
                        _originalDoc_date_fac_term_mm = ConvertDEC(Reader["DOC_DATE_FAC_TERM_MM"]);
                        _originalDoc_date_fac_term_dd = ConvertDEC(Reader["DOC_DATE_FAC_TERM_DD"]);
                        _originalDoc_ytdgua = ConvertDEC(Reader["DOC_YTDGUA"]);
                        _originalDoc_ytdgub = ConvertDEC(Reader["DOC_YTDGUB"]);
                        _originalDoc_ytdguc = ConvertDEC(Reader["DOC_YTDGUC"]);
                        _originalDoc_ytdgud = ConvertDEC(Reader["DOC_YTDGUD"]);
                        _originalDoc_ytdcea = ConvertDEC(Reader["DOC_YTDCEA"]);
                        _originalDoc_ytdcex = ConvertDEC(Reader["DOC_YTDCEX"]);
                        _originalDoc_ytdear = ConvertDEC(Reader["DOC_YTDEAR"]);
                        _originalDoc_ytdinc = ConvertDEC(Reader["DOC_YTDINC"]);
                        _originalDoc_ytdeft = ConvertDEC(Reader["DOC_YTDEFT"]);
                        _originalDoc_totinc_g = ConvertDEC(Reader["DOC_TOTINC_G"]);
                        _originalDoc_ep_date_deposit = ConvertDEC(Reader["DOC_EP_DATE_DEPOSIT"]);
                        _originalDoc_totinc = ConvertDEC(Reader["DOC_TOTINC"]);
                        _originalDoc_ep_ceiexp = ConvertDEC(Reader["DOC_EP_CEIEXP"]);
                        _originalDoc_adjcea = ConvertDEC(Reader["DOC_ADJCEA"]);
                        _originalDoc_adjcex = ConvertDEC(Reader["DOC_ADJCEX"]);
                        _originalDoc_ceicea = ConvertDEC(Reader["DOC_CEICEA"]);
                        _originalDoc_ceicex = ConvertDEC(Reader["DOC_CEICEX"]);
                        _originalCeicea_prt_format = Reader["CEICEA_PRT_FORMAT"].ToString();
                        _originalCeicex_prt_format = Reader["CEICEX_PRT_FORMAT"].ToString();
                        _originalYtdcea_prt_format = Reader["YTDCEA_PRT_FORMAT"].ToString();
                        _originalYtdcex_prt_format = Reader["YTDCEX_PRT_FORMAT"].ToString();
                        _originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
                        _originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
                        _originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
                        _originalDoc_rma_expense_percent_misc = Reader["DOC_RMA_EXPENSE_PERCENT_MISC"].ToString();
                        _originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
                        _originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
                        _originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString();
                        /*	_originalDoc_nx_avail_batch = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH"]);
                            _originalDoc_nx_avail_batch_2 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_2"]);
                            _originalDoc_nx_avail_batch_3 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_3"]);
                            _originalDoc_nx_avail_batch_4 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_4"]);
                            _originalDoc_nx_avail_batch_5 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_5"]);
                            _originalDoc_nx_avail_batch_6 = ConvertDEC(Reader["DOC_NX_AVAIL_BATCH_6"]); */
                        _originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
                        _originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
                        _originalDoc_rma_expense_percent_reg = Reader["DOC_RMA_EXPENSE_PERCENT_REG"].ToString();
                        _originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString();
                        _originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
                        _originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
                        _originalDoc_dept_expense_percent_misc = Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"].ToString();
                        _originalDoc_dept_expense_percent_reg = Reader["DOC_DEPT_EXPENSE_PERCENT_REG"].ToString();
                        _originalDoc_ep_ped = Reader["DOC_EP_PED"].ToString();
                        _originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
                        _originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
                        _originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString();
                        _originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
                        _originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString();
                        _originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString();
                        /*	_originalDoc_loc_1_s1 = Reader["DOC_LOC_1_S1"].ToString();
                            _originalDoc_loc_1_s2 = Reader["DOC_LOC_1_S2"].ToString();
                            _originalDoc_loc_1_s3 = Reader["DOC_LOC_1_S3"].ToString();
                            _originalDoc_loc_2_s1 = Reader["DOC_LOC_2_S1"].ToString();
                            _originalDoc_loc_2_s2 = Reader["DOC_LOC_2_S2"].ToString();
                            _originalDoc_loc_2_s3 = Reader["DOC_LOC_2_S3"].ToString();
                            _originalDoc_loc_3_s1 = Reader["DOC_LOC_3_S1"].ToString();
                            _originalDoc_loc_3_s2 = Reader["DOC_LOC_3_S2"].ToString();
                            _originalDoc_loc_3_s3 = Reader["DOC_LOC_3_S3"].ToString();
                            _originalDoc_loc_4_s1 = Reader["DOC_LOC_4_S1"].ToString();
                            _originalDoc_loc_4_s2 = Reader["DOC_LOC_4_S2"].ToString();
                            _originalDoc_loc_4_s3 = Reader["DOC_LOC_4_S3"].ToString();
                            _originalDoc_loc_5_s1 = Reader["DOC_LOC_5_S1"].ToString();
                            _originalDoc_loc_5_s2 = Reader["DOC_LOC_5_S2"].ToString();
                            _originalDoc_loc_5_s3 = Reader["DOC_LOC_5_S3"].ToString();
                            _originalDoc_loc_6_s1 = Reader["DOC_LOC_6_S1"].ToString();
                            _originalDoc_loc_6_s2 = Reader["DOC_LOC_6_S2"].ToString();
                            _originalDoc_loc_6_s3 = Reader["DOC_LOC_6_S3"].ToString();
                            _originalDoc_loc_7_s1 = Reader["DOC_LOC_7_S1"].ToString();
                            _originalDoc_loc_7_s2 = Reader["DOC_LOC_7_S2"].ToString();
                            _originalDoc_loc_7_s3 = Reader["DOC_LOC_7_S3"].ToString();
                            _originalDoc_loc_8_s1 = Reader["DOC_LOC_8_S1"].ToString();
                            _originalDoc_loc_8_s2 = Reader["DOC_LOC_8_S2"].ToString();
                            _originalDoc_loc_8_s3 = Reader["DOC_LOC_8_S3"].ToString();
                            _originalDoc_loc_9_s1 = Reader["DOC_LOC_9_S1"].ToString();
                            _originalDoc_loc_9_s2 = Reader["DOC_LOC_9_S2"].ToString();
                            _originalDoc_loc_9_s3 = Reader["DOC_LOC_9_S3"].ToString();
                            _originalDoc_loc_10_s1 = Reader["DOC_LOC_10_S1"].ToString();
                            _originalDoc_loc_10_s2 = Reader["DOC_LOC_10_S2"].ToString();
                            _originalDoc_loc_10_s3 = Reader["DOC_LOC_10_S3"].ToString();
                            _originalDoc_loc_11_s1 = Reader["DOC_LOC_11_S1"].ToString();
                            _originalDoc_loc_11_s2 = Reader["DOC_LOC_11_S2"].ToString();
                            _originalDoc_loc_11_s3 = Reader["DOC_LOC_11_S3"].ToString();
                            _originalDoc_loc_12_s1 = Reader["DOC_LOC_12_S1"].ToString();
                            _originalDoc_loc_12_s2 = Reader["DOC_LOC_12_S2"].ToString();
                            _originalDoc_loc_12_s3 = Reader["DOC_LOC_12_S3"].ToString();
                            _originalDoc_loc_13_s1 = Reader["DOC_LOC_13_S1"].ToString();
                            _originalDoc_loc_13_s2 = Reader["DOC_LOC_13_S2"].ToString();
                            _originalDoc_loc_13_s3 = Reader["DOC_LOC_13_S3"].ToString();
                            _originalDoc_loc_14_s1 = Reader["DOC_LOC_14_S1"].ToString();
                            _originalDoc_loc_14_s2 = Reader["DOC_LOC_14_S2"].ToString();
                            _originalDoc_loc_14_s3 = Reader["DOC_LOC_14_S3"].ToString();
                            _originalDoc_loc_15_s1 = Reader["DOC_LOC_15_S1"].ToString();
                            _originalDoc_loc_15_s2 = Reader["DOC_LOC_15_S2"].ToString();
                            _originalDoc_loc_15_s3 = Reader["DOC_LOC_15_S3"].ToString();
                            _originalDoc_loc_16_s1 = Reader["DOC_LOC_16_S1"].ToString();
                            _originalDoc_loc_16_s2 = Reader["DOC_LOC_16_S2"].ToString();
                            _originalDoc_loc_16_s3 = Reader["DOC_LOC_16_S3"].ToString();
                            _originalDoc_loc_17_s1 = Reader["DOC_LOC_17_S1"].ToString();
                            _originalDoc_loc_17_s2 = Reader["DOC_LOC_17_S2"].ToString();
                            _originalDoc_loc_17_s3 = Reader["DOC_LOC_17_S3"].ToString();
                            _originalDoc_loc_18_s1 = Reader["DOC_LOC_18_S1"].ToString();
                            _originalDoc_loc_18_s2 = Reader["DOC_LOC_18_S2"].ToString();
                            _originalDoc_loc_18_s3 = Reader["DOC_LOC_18_S3"].ToString();
                            _originalDoc_loc_19_s1 = Reader["DOC_LOC_19_S1"].ToString();
                            _originalDoc_loc_19_s2 = Reader["DOC_LOC_19_S2"].ToString();
                            _originalDoc_loc_19_s3 = Reader["DOC_LOC_19_S3"].ToString();
                            _originalDoc_loc_20_s1 = Reader["DOC_LOC_20_S1"].ToString();
                            _originalDoc_loc_20_s2 = Reader["DOC_LOC_20_S2"].ToString();
                            _originalDoc_loc_20_s3 = Reader["DOC_LOC_20_S3"].ToString();
                            _originalDoc_loc_21_s1 = Reader["DOC_LOC_21_S1"].ToString();
                            _originalDoc_loc_21_s2 = Reader["DOC_LOC_21_S2"].ToString();
                            _originalDoc_loc_21_s3 = Reader["DOC_LOC_21_S3"].ToString();
                            _originalDoc_loc_22_s1 = Reader["DOC_LOC_22_S1"].ToString();
                            _originalDoc_loc_22_s2 = Reader["DOC_LOC_22_S2"].ToString();
                            _originalDoc_loc_22_s3 = Reader["DOC_LOC_22_S3"].ToString();
                            _originalDoc_loc_23_s1 = Reader["DOC_LOC_23_S1"].ToString();
                            _originalDoc_loc_23_s2 = Reader["DOC_LOC_23_S2"].ToString();
                            _originalDoc_loc_23_s3 = Reader["DOC_LOC_23_S3"].ToString();
                            _originalDoc_loc_24_s1 = Reader["DOC_LOC_24_S1"].ToString();
                            _originalDoc_loc_24_s2 = Reader["DOC_LOC_24_S2"].ToString();
                            _originalDoc_loc_24_s3 = Reader["DOC_LOC_24_S3"].ToString();
                            _originalDoc_loc_25_s1 = Reader["DOC_LOC_25_S1"].ToString();
                            _originalDoc_loc_25_s2 = Reader["DOC_LOC_25_S2"].ToString();
                            _originalDoc_loc_25_s3 = Reader["DOC_LOC_25_S3"].ToString();
                            _originalDoc_loc_26_s1 = Reader["DOC_LOC_26_S1"].ToString();
                            _originalDoc_loc_26_s2 = Reader["DOC_LOC_26_S2"].ToString();
                            _originalDoc_loc_26_s3 = Reader["DOC_LOC_26_S3"].ToString();
                            _originalDoc_loc_27_s1 = Reader["DOC_LOC_27_S1"].ToString();
                            _originalDoc_loc_27_s2 = Reader["DOC_LOC_27_S2"].ToString();
                            _originalDoc_loc_27_s3 = Reader["DOC_LOC_27_S3"].ToString();
                            _originalDoc_loc_28_s1 = Reader["DOC_LOC_28_S1"].ToString();
                            _originalDoc_loc_28_s2 = Reader["DOC_LOC_28_S2"].ToString();
                            _originalDoc_loc_28_s3 = Reader["DOC_LOC_28_S3"].ToString();
                            _originalDoc_loc_29_s1 = Reader["DOC_LOC_29_S1"].ToString();
                            _originalDoc_loc_29_s2 = Reader["DOC_LOC_29_S2"].ToString();
                            _originalDoc_loc_29_s3 = Reader["DOC_LOC_29_S3"].ToString();
                            _originalDoc_loc_30_s1 = Reader["DOC_LOC_30_S1"].ToString();
                            _originalDoc_loc_30_s2 = Reader["DOC_LOC_30_S2"].ToString();
                            _originalDoc_loc_30_s3 = Reader["DOC_LOC_30_S3"].ToString(); */
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