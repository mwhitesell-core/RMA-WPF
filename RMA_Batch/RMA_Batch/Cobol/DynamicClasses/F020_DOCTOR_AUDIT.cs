using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_DOCTOR_AUDIT : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_DOCTOR_AUDIT> Collection( Guid? rowid,
															string doc_nbr,
															decimal? doc_deptmin,
															decimal? doc_deptmax,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															decimal? doc_sin_nbrmin,
															decimal? doc_sin_nbrmax,
															decimal? doc_spec_cdmin,
															decimal? doc_spec_cdmax,
															string doc_hosp_nbr,
															string doc_name,
															string doc_name_soundex,
															string doc_inits,
															string doc_full_part_ind,
															decimal? doc_bank_nbrmin,
															decimal? doc_bank_nbrmax,
															decimal? doc_bank_branchmin,
															decimal? doc_bank_branchmax,
															string doc_bank_acct,
															decimal? doc_date_fac_startmin,
															decimal? doc_date_fac_startmax,
															decimal? doc_date_fac_termmin,
															decimal? doc_date_fac_termmax,
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
															decimal? doc_spec_cd_2min,
															decimal? doc_spec_cd_2max,
															decimal? doc_spec_cd_3min,
															decimal? doc_spec_cd_3max,
															decimal? doc_ytdinc_gmin,
															decimal? doc_ytdinc_gmax,
															string doc_locations,
															int? doc_rma_expense_percent_miscmin,
															int? doc_rma_expense_percent_miscmax,
															string doc_afp_paym_group,
															decimal? doc_dept_2min,
															decimal? doc_dept_2max,
															string doc_ind_pays_gst,
															decimal? doc_yrly_ceiling_computedmin,
															decimal? doc_yrly_ceiling_computedmax,
															decimal? doc_yrly_expense_computedmin,
															decimal? doc_yrly_expense_computedmax,
															int? doc_rma_expense_percent_regmin,
															int? doc_rma_expense_percent_regmax,
															string doc_sub_specialty,
															decimal? doc_payeftmin,
															decimal? doc_payeftmax,
															decimal? doc_ytddedmin,
															decimal? doc_ytddedmax,
															int? doc_dept_expense_percent_miscmin,
															int? doc_dept_expense_percent_miscmax,
															int? doc_dept_expense_percent_regmin,
															int? doc_dept_expense_percent_regmax,
															decimal? doc_ep_pedmin,
															decimal? doc_ep_pedmax,
															string doc_ep_pay_code,
															string doc_ep_pay_sub_code,
															string doc_partnership,
															string doc_ind_holdback_active,
															string group_regular_service,
															string group_over_serviced,
															string doc_specialties,
															decimal? doc_yrly_require_revenuemin,
															decimal? doc_yrly_require_revenuemax,
															decimal? doc_yrly_target_revenuemin,
															decimal? doc_yrly_target_revenuemax,
															decimal? doc_ceireqmin,
															decimal? doc_ceireqmax,
															decimal? doc_ytdreqmin,
															decimal? doc_ytdreqmax,
															decimal? doc_ceitarmin,
															decimal? doc_ceitarmax,
															decimal? doc_ytdtarmin,
															decimal? doc_ytdtarmax,
															string billing_via_paper_flag,
															string billing_via_diskette_flag,
															string billing_via_web_test_flag,
															string billing_via_web_live_flag,
															string billing_via_rma_data_entry,
															decimal? date_start_rma_data_entrymin,
															decimal? date_start_rma_data_entrymax,
															decimal? date_start_diskettemin,
															decimal? date_start_diskettemax,
															decimal? date_start_papermin,
															decimal? date_start_papermax,
															decimal? date_start_web_livemin,
															decimal? date_start_web_livemax,
															decimal? date_start_web_testmin,
															decimal? date_start_web_testmax,
															string leave_description,
															decimal? leave_date_startmin,
															decimal? leave_date_startmax,
															decimal? leave_date_endmin,
															decimal? leave_date_endmax,
															string web_user_revenue_only_flag,
															string manager_flag,
															string chair_flag,
															string abe_user_flag,
															string cpso_nbr,
															string cmpa_nbr,
															string oma_nbr,
															string cfpc_nbr,
															string rcpsc_nbr,
															string doc_med_prof_corp,
															decimal? mcmaster_employee_idmin,
															decimal? mcmaster_employee_idmax,
															decimal? doc_spec_cd_eff_datemin,
															decimal? doc_spec_cd_eff_datemax,
															decimal? doc_spec_cd_2_eff_datemin,
															decimal? doc_spec_cd_2_eff_datemax,
															decimal? doc_spec_cd_3_eff_datemin,
															decimal? doc_spec_cd_3_eff_datemax,
															decimal? factor_gst_income_regmin,
															decimal? factor_gst_income_regmax,
															decimal? factor_gst_income_miscmin,
															decimal? factor_gst_income_miscmax,
															string yellow_pages_flag,
															string replaced_by_doc_nbr,
															string prior_doc_nbr,
															string cop_nbr,
															string doc_flag_primary,
															string has_valid_current_payroll_record,
															string pay_this_doctor_ohip_premium,
															decimal? doc_fiscal_yr_start_monthmin,
															decimal? doc_fiscal_yr_start_monthmax,
															string last_mod_flag,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
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
					new SqlParameter("minDOC_SIN_NBR",doc_sin_nbrmin),
					new SqlParameter("maxDOC_SIN_NBR",doc_sin_nbrmax),
					new SqlParameter("minDOC_SPEC_CD",doc_spec_cdmin),
					new SqlParameter("maxDOC_SPEC_CD",doc_spec_cdmax),
					new SqlParameter("DOC_HOSP_NBR",doc_hosp_nbr),
					new SqlParameter("DOC_NAME",doc_name),
					new SqlParameter("DOC_NAME_SOUNDEX",doc_name_soundex),
					new SqlParameter("DOC_INITS",doc_inits),
					new SqlParameter("DOC_FULL_PART_IND",doc_full_part_ind),
					new SqlParameter("minDOC_BANK_NBR",doc_bank_nbrmin),
					new SqlParameter("maxDOC_BANK_NBR",doc_bank_nbrmax),
					new SqlParameter("minDOC_BANK_BRANCH",doc_bank_branchmin),
					new SqlParameter("maxDOC_BANK_BRANCH",doc_bank_branchmax),
					new SqlParameter("DOC_BANK_ACCT",doc_bank_acct),
					new SqlParameter("minDOC_DATE_FAC_START",doc_date_fac_startmin),
					new SqlParameter("maxDOC_DATE_FAC_START",doc_date_fac_startmax),
					new SqlParameter("minDOC_DATE_FAC_TERM",doc_date_fac_termmin),
					new SqlParameter("maxDOC_DATE_FAC_TERM",doc_date_fac_termmax),
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
					new SqlParameter("minDOC_SPEC_CD_2",doc_spec_cd_2min),
					new SqlParameter("maxDOC_SPEC_CD_2",doc_spec_cd_2max),
					new SqlParameter("minDOC_SPEC_CD_3",doc_spec_cd_3min),
					new SqlParameter("maxDOC_SPEC_CD_3",doc_spec_cd_3max),
					new SqlParameter("minDOC_YTDINC_G",doc_ytdinc_gmin),
					new SqlParameter("maxDOC_YTDINC_G",doc_ytdinc_gmax),
					new SqlParameter("DOC_LOCATIONS",doc_locations),
					new SqlParameter("minDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmin),
					new SqlParameter("maxDOC_RMA_EXPENSE_PERCENT_MISC",doc_rma_expense_percent_miscmax),
					new SqlParameter("DOC_AFP_PAYM_GROUP",doc_afp_paym_group),
					new SqlParameter("minDOC_DEPT_2",doc_dept_2min),
					new SqlParameter("maxDOC_DEPT_2",doc_dept_2max),
					new SqlParameter("DOC_IND_PAYS_GST",doc_ind_pays_gst),
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
					new SqlParameter("DOC_SPECIALTIES",doc_specialties),
					new SqlParameter("minDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemin),
					new SqlParameter("maxDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemax),
					new SqlParameter("minDOC_YRLY_TARGET_REVENUE",doc_yrly_target_revenuemin),
					new SqlParameter("maxDOC_YRLY_TARGET_REVENUE",doc_yrly_target_revenuemax),
					new SqlParameter("minDOC_CEIREQ",doc_ceireqmin),
					new SqlParameter("maxDOC_CEIREQ",doc_ceireqmax),
					new SqlParameter("minDOC_YTDREQ",doc_ytdreqmin),
					new SqlParameter("maxDOC_YTDREQ",doc_ytdreqmax),
					new SqlParameter("minDOC_CEITAR",doc_ceitarmin),
					new SqlParameter("maxDOC_CEITAR",doc_ceitarmax),
					new SqlParameter("minDOC_YTDTAR",doc_ytdtarmin),
					new SqlParameter("maxDOC_YTDTAR",doc_ytdtarmax),
					new SqlParameter("BILLING_VIA_PAPER_FLAG",billing_via_paper_flag),
					new SqlParameter("BILLING_VIA_DISKETTE_FLAG",billing_via_diskette_flag),
					new SqlParameter("BILLING_VIA_WEB_TEST_FLAG",billing_via_web_test_flag),
					new SqlParameter("BILLING_VIA_WEB_LIVE_FLAG",billing_via_web_live_flag),
					new SqlParameter("BILLING_VIA_RMA_DATA_ENTRY",billing_via_rma_data_entry),
					new SqlParameter("minDATE_START_RMA_DATA_ENTRY",date_start_rma_data_entrymin),
					new SqlParameter("maxDATE_START_RMA_DATA_ENTRY",date_start_rma_data_entrymax),
					new SqlParameter("minDATE_START_DISKETTE",date_start_diskettemin),
					new SqlParameter("maxDATE_START_DISKETTE",date_start_diskettemax),
					new SqlParameter("minDATE_START_PAPER",date_start_papermin),
					new SqlParameter("maxDATE_START_PAPER",date_start_papermax),
					new SqlParameter("minDATE_START_WEB_LIVE",date_start_web_livemin),
					new SqlParameter("maxDATE_START_WEB_LIVE",date_start_web_livemax),
					new SqlParameter("minDATE_START_WEB_TEST",date_start_web_testmin),
					new SqlParameter("maxDATE_START_WEB_TEST",date_start_web_testmax),
					new SqlParameter("LEAVE_DESCRIPTION",leave_description),
					new SqlParameter("minLEAVE_DATE_START",leave_date_startmin),
					new SqlParameter("maxLEAVE_DATE_START",leave_date_startmax),
					new SqlParameter("minLEAVE_DATE_END",leave_date_endmin),
					new SqlParameter("maxLEAVE_DATE_END",leave_date_endmax),
					new SqlParameter("WEB_USER_REVENUE_ONLY_FLAG",web_user_revenue_only_flag),
					new SqlParameter("MANAGER_FLAG",manager_flag),
					new SqlParameter("CHAIR_FLAG",chair_flag),
					new SqlParameter("ABE_USER_FLAG",abe_user_flag),
					new SqlParameter("CPSO_NBR",cpso_nbr),
					new SqlParameter("CMPA_NBR",cmpa_nbr),
					new SqlParameter("OMA_NBR",oma_nbr),
					new SqlParameter("CFPC_NBR",cfpc_nbr),
					new SqlParameter("RCPSC_NBR",rcpsc_nbr),
					new SqlParameter("DOC_MED_PROF_CORP",doc_med_prof_corp),
					new SqlParameter("minMCMASTER_EMPLOYEE_ID",mcmaster_employee_idmin),
					new SqlParameter("maxMCMASTER_EMPLOYEE_ID",mcmaster_employee_idmax),
					new SqlParameter("minDOC_SPEC_CD_EFF_DATE",doc_spec_cd_eff_datemin),
					new SqlParameter("maxDOC_SPEC_CD_EFF_DATE",doc_spec_cd_eff_datemax),
					new SqlParameter("minDOC_SPEC_CD_2_EFF_DATE",doc_spec_cd_2_eff_datemin),
					new SqlParameter("maxDOC_SPEC_CD_2_EFF_DATE",doc_spec_cd_2_eff_datemax),
					new SqlParameter("minDOC_SPEC_CD_3_EFF_DATE",doc_spec_cd_3_eff_datemin),
					new SqlParameter("maxDOC_SPEC_CD_3_EFF_DATE",doc_spec_cd_3_eff_datemax),
					new SqlParameter("minFACTOR_GST_INCOME_REG",factor_gst_income_regmin),
					new SqlParameter("maxFACTOR_GST_INCOME_REG",factor_gst_income_regmax),
					new SqlParameter("minFACTOR_GST_INCOME_MISC",factor_gst_income_miscmin),
					new SqlParameter("maxFACTOR_GST_INCOME_MISC",factor_gst_income_miscmax),
					new SqlParameter("YELLOW_PAGES_FLAG",yellow_pages_flag),
					new SqlParameter("REPLACED_BY_DOC_NBR",replaced_by_doc_nbr),
					new SqlParameter("PRIOR_DOC_NBR",prior_doc_nbr),
					new SqlParameter("COP_NBR",cop_nbr),
					new SqlParameter("DOC_FLAG_PRIMARY",doc_flag_primary),
					new SqlParameter("HAS_VALID_CURRENT_PAYROLL_RECORD",has_valid_current_payroll_record),
					new SqlParameter("PAY_THIS_DOCTOR_OHIP_PREMIUM",pay_this_doctor_ohip_premium),
					new SqlParameter("minDOC_FISCAL_YR_START_MONTH",doc_fiscal_yr_start_monthmin),
					new SqlParameter("maxDOC_FISCAL_YR_START_MONTH",doc_fiscal_yr_start_monthmax),
					new SqlParameter("LAST_MOD_FLAG",last_mod_flag),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020_DOCTOR_AUDIT>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_Search]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
					DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
					DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
					DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
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
					DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
					DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
					DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
					DOC_LOCATIONS = Reader["DOC_LOCATIONS"].ToString(),
					DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
					DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString(),
					DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
					DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					DOC_EP_PED = ConvertDEC(Reader["DOC_EP_PED"]),
					DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
					DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString(),
					DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
					GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString(),
					GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString(),
					DOC_SPECIALTIES = Reader["DOC_SPECIALTIES"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					BILLING_VIA_PAPER_FLAG = Reader["BILLING_VIA_PAPER_FLAG"].ToString(),
					BILLING_VIA_DISKETTE_FLAG = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString(),
					BILLING_VIA_WEB_TEST_FLAG = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString(),
					BILLING_VIA_WEB_LIVE_FLAG = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString(),
					BILLING_VIA_RMA_DATA_ENTRY = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString(),
					DATE_START_RMA_DATA_ENTRY = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]),
					DATE_START_DISKETTE = ConvertDEC(Reader["DATE_START_DISKETTE"]),
					DATE_START_PAPER = ConvertDEC(Reader["DATE_START_PAPER"]),
					DATE_START_WEB_LIVE = ConvertDEC(Reader["DATE_START_WEB_LIVE"]),
					DATE_START_WEB_TEST = ConvertDEC(Reader["DATE_START_WEB_TEST"]),
					LEAVE_DESCRIPTION = Reader["LEAVE_DESCRIPTION"].ToString(),
					LEAVE_DATE_START = ConvertDEC(Reader["LEAVE_DATE_START"]),
					LEAVE_DATE_END = ConvertDEC(Reader["LEAVE_DATE_END"]),
					WEB_USER_REVENUE_ONLY_FLAG = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString(),
					MANAGER_FLAG = Reader["MANAGER_FLAG"].ToString(),
					CHAIR_FLAG = Reader["CHAIR_FLAG"].ToString(),
					ABE_USER_FLAG = Reader["ABE_USER_FLAG"].ToString(),
					CPSO_NBR = Reader["CPSO_NBR"].ToString(),
					CMPA_NBR = Reader["CMPA_NBR"].ToString(),
					OMA_NBR = Reader["OMA_NBR"].ToString(),
					CFPC_NBR = Reader["CFPC_NBR"].ToString(),
					RCPSC_NBR = Reader["RCPSC_NBR"].ToString(),
					DOC_MED_PROF_CORP = Reader["DOC_MED_PROF_CORP"].ToString(),
					MCMASTER_EMPLOYEE_ID = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]),
					DOC_SPEC_CD_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]),
					DOC_SPEC_CD_2_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]),
					DOC_SPEC_CD_3_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]),
					FACTOR_GST_INCOME_REG = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]),
					FACTOR_GST_INCOME_MISC = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]),
					YELLOW_PAGES_FLAG = Reader["YELLOW_PAGES_FLAG"].ToString(),
					REPLACED_BY_DOC_NBR = Reader["REPLACED_BY_DOC_NBR"].ToString(),
					PRIOR_DOC_NBR = Reader["PRIOR_DOC_NBR"].ToString(),
					COP_NBR = Reader["COP_NBR"].ToString(),
					DOC_FLAG_PRIMARY = Reader["DOC_FLAG_PRIMARY"].ToString(),
					HAS_VALID_CURRENT_PAYROLL_RECORD = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString(),
					PAY_THIS_DOCTOR_OHIP_PREMIUM = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString(),
					DOC_FISCAL_YR_START_MONTH = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
					_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
					_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
					_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
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
					_originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
					_originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
					_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
					_originalDoc_locations = Reader["DOC_LOCATIONS"].ToString(),
					_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
					_originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					_originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString(),
					_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
					_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
					_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					_originalDoc_ep_ped = ConvertDEC(Reader["DOC_EP_PED"]),
					_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
					_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					_originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString(),
					_originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
					_originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString(),
					_originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString(),
					_originalDoc_specialties = Reader["DOC_SPECIALTIES"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalvia_paper_flag = Reader["BILLING_VIA_PAPER_FLAG"].ToString(),
					_originalvia_diskette_flag = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString(),
					_originalvia_web_test_flag = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString(),
					_originalvia_web_live_flag = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString(),
					_originalvia_rma_data_entry = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString(),
					_originalDate_start_rma_data_entry = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]),
					_originalDate_start_diskette = ConvertDEC(Reader["DATE_START_DISKETTE"]),
					_originalDate_start_paper = ConvertDEC(Reader["DATE_START_PAPER"]),
					_originalDate_start_web_live = ConvertDEC(Reader["DATE_START_WEB_LIVE"]),
					_originalDate_start_web_test = ConvertDEC(Reader["DATE_START_WEB_TEST"]),
					_originalLeave_description = Reader["LEAVE_DESCRIPTION"].ToString(),
					_originalLeave_date_start = ConvertDEC(Reader["LEAVE_DATE_START"]),
					_originalLeave_date_end = ConvertDEC(Reader["LEAVE_DATE_END"]),
					_originalWeb_user_revenue_only_flag = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString(),
					_originalManager_flag = Reader["MANAGER_FLAG"].ToString(),
					_originalChair_flag = Reader["CHAIR_FLAG"].ToString(),
					_originalAbe_user_flag = Reader["ABE_USER_FLAG"].ToString(),
					_originalCpso_nbr = Reader["CPSO_NBR"].ToString(),
					_originalCmpa_nbr = Reader["CMPA_NBR"].ToString(),
					_originalOma_nbr = Reader["OMA_NBR"].ToString(),
					_originalCfpc_nbr = Reader["CFPC_NBR"].ToString(),
					_originalRcpsc_nbr = Reader["RCPSC_NBR"].ToString(),
					_originalDoc_med_prof_corp = Reader["DOC_MED_PROF_CORP"].ToString(),
					_originalMcmaster_employee_id = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]),
					_originalDoc_spec_cd_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]),
					_originalDoc_spec_cd_2_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]),
					_originalDoc_spec_cd_3_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]),
					_originalFactor_gst_income_reg = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]),
					_originalFactor_gst_income_misc = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]),
					_originalYellow_pages_flag = Reader["YELLOW_PAGES_FLAG"].ToString(),
					_originalReplaced_by_doc_nbr = Reader["REPLACED_BY_DOC_NBR"].ToString(),
					_originalPrior_doc_nbr = Reader["PRIOR_DOC_NBR"].ToString(),
					_originalCop_nbr = Reader["COP_NBR"].ToString(),
					_originalDoc_flag_primary = Reader["DOC_FLAG_PRIMARY"].ToString(),
					_originalHas_valid_current_payroll_record = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString(),
					_originalPay_this_doctor_ohip_premium = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString(),
					_originalDoc_fiscal_yr_start_month = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020_DOCTOR_AUDIT Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_DOCTOR_AUDIT> Collection(ObservableCollection<F020_DOCTOR_AUDIT>
                                                               f020DoctorAudit = null)
        {
            if (IsSameSearch() && f020DoctorAudit != null)
            {
                return f020DoctorAudit;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_DOCTOR_AUDIT>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_DEPT",WhereDoc_dept),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("DOC_SIN_NBR",WhereDoc_sin_nbr),
					new SqlParameter("DOC_SPEC_CD",WhereDoc_spec_cd),
					new SqlParameter("DOC_HOSP_NBR",WhereDoc_hosp_nbr),
					new SqlParameter("DOC_NAME",WhereDoc_name),
					new SqlParameter("DOC_NAME_SOUNDEX",WhereDoc_name_soundex),
					new SqlParameter("DOC_INITS",WhereDoc_inits),
					new SqlParameter("DOC_FULL_PART_IND",WhereDoc_full_part_ind),
					new SqlParameter("DOC_BANK_NBR",WhereDoc_bank_nbr),
					new SqlParameter("DOC_BANK_BRANCH",WhereDoc_bank_branch),
					new SqlParameter("DOC_BANK_ACCT",WhereDoc_bank_acct),
					new SqlParameter("DOC_DATE_FAC_START",WhereDoc_date_fac_start),
					new SqlParameter("DOC_DATE_FAC_TERM",WhereDoc_date_fac_term),
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
					new SqlParameter("DOC_SPEC_CD_2",WhereDoc_spec_cd_2),
					new SqlParameter("DOC_SPEC_CD_3",WhereDoc_spec_cd_3),
					new SqlParameter("DOC_YTDINC_G",WhereDoc_ytdinc_g),
					new SqlParameter("DOC_LOCATIONS",WhereDoc_locations),
					new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC",WhereDoc_rma_expense_percent_misc),
					new SqlParameter("DOC_AFP_PAYM_GROUP",WhereDoc_afp_paym_group),
					new SqlParameter("DOC_DEPT_2",WhereDoc_dept_2),
					new SqlParameter("DOC_IND_PAYS_GST",WhereDoc_ind_pays_gst),
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
					new SqlParameter("DOC_SPECIALTIES",WhereDoc_specialties),
					new SqlParameter("DOC_YRLY_REQUIRE_REVENUE",WhereDoc_yrly_require_revenue),
					new SqlParameter("DOC_YRLY_TARGET_REVENUE",WhereDoc_yrly_target_revenue),
					new SqlParameter("DOC_CEIREQ",WhereDoc_ceireq),
					new SqlParameter("DOC_YTDREQ",WhereDoc_ytdreq),
					new SqlParameter("DOC_CEITAR",WhereDoc_ceitar),
					new SqlParameter("DOC_YTDTAR",WhereDoc_ytdtar),
					new SqlParameter("BILLING_VIA_PAPER_FLAG",Wherevia_paper_flag),
					new SqlParameter("BILLING_VIA_DISKETTE_FLAG",Wherevia_diskette_flag),
					new SqlParameter("BILLING_VIA_WEB_TEST_FLAG",Wherevia_web_test_flag),
					new SqlParameter("BILLING_VIA_WEB_LIVE_FLAG",Wherevia_web_live_flag),
					new SqlParameter("BILLING_VIA_RMA_DATA_ENTRY",Wherevia_rma_data_entry),
					new SqlParameter("DATE_START_RMA_DATA_ENTRY",WhereDate_start_rma_data_entry),
					new SqlParameter("DATE_START_DISKETTE",WhereDate_start_diskette),
					new SqlParameter("DATE_START_PAPER",WhereDate_start_paper),
					new SqlParameter("DATE_START_WEB_LIVE",WhereDate_start_web_live),
					new SqlParameter("DATE_START_WEB_TEST",WhereDate_start_web_test),
					new SqlParameter("LEAVE_DESCRIPTION",WhereLeave_description),
					new SqlParameter("LEAVE_DATE_START",WhereLeave_date_start),
					new SqlParameter("LEAVE_DATE_END",WhereLeave_date_end),
					new SqlParameter("WEB_USER_REVENUE_ONLY_FLAG",WhereWeb_user_revenue_only_flag),
					new SqlParameter("MANAGER_FLAG",WhereManager_flag),
					new SqlParameter("CHAIR_FLAG",WhereChair_flag),
					new SqlParameter("ABE_USER_FLAG",WhereAbe_user_flag),
					new SqlParameter("CPSO_NBR",WhereCpso_nbr),
					new SqlParameter("CMPA_NBR",WhereCmpa_nbr),
					new SqlParameter("OMA_NBR",WhereOma_nbr),
					new SqlParameter("CFPC_NBR",WhereCfpc_nbr),
					new SqlParameter("RCPSC_NBR",WhereRcpsc_nbr),
					new SqlParameter("DOC_MED_PROF_CORP",WhereDoc_med_prof_corp),
					new SqlParameter("MCMASTER_EMPLOYEE_ID",WhereMcmaster_employee_id),
					new SqlParameter("DOC_SPEC_CD_EFF_DATE",WhereDoc_spec_cd_eff_date),
					new SqlParameter("DOC_SPEC_CD_2_EFF_DATE",WhereDoc_spec_cd_2_eff_date),
					new SqlParameter("DOC_SPEC_CD_3_EFF_DATE",WhereDoc_spec_cd_3_eff_date),
					new SqlParameter("FACTOR_GST_INCOME_REG",WhereFactor_gst_income_reg),
					new SqlParameter("FACTOR_GST_INCOME_MISC",WhereFactor_gst_income_misc),
					new SqlParameter("YELLOW_PAGES_FLAG",WhereYellow_pages_flag),
					new SqlParameter("REPLACED_BY_DOC_NBR",WhereReplaced_by_doc_nbr),
					new SqlParameter("PRIOR_DOC_NBR",WherePrior_doc_nbr),
					new SqlParameter("COP_NBR",WhereCop_nbr),
					new SqlParameter("DOC_FLAG_PRIMARY",WhereDoc_flag_primary),
					new SqlParameter("HAS_VALID_CURRENT_PAYROLL_RECORD",WhereHas_valid_current_payroll_record),
					new SqlParameter("PAY_THIS_DOCTOR_OHIP_PREMIUM",WherePay_this_doctor_ohip_premium),
					new SqlParameter("DOC_FISCAL_YR_START_MONTH",WhereDoc_fiscal_yr_start_month),
					new SqlParameter("LAST_MOD_FLAG",WhereLast_mod_flag),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_Match]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_AUDIT>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_AUDIT
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString(),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
					DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]),
					DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString(),
					DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
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
					DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
					DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
					DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]),
					DOC_LOCATIONS = Reader["DOC_LOCATIONS"].ToString(),
					DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
					DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString(),
					DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]),
					DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]),
					DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					DOC_EP_PED = ConvertDEC(Reader["DOC_EP_PED"]),
					DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString(),
					DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString(),
					DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
					GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString(),
					GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString(),
					DOC_SPECIALTIES = Reader["DOC_SPECIALTIES"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					BILLING_VIA_PAPER_FLAG = Reader["BILLING_VIA_PAPER_FLAG"].ToString(),
					BILLING_VIA_DISKETTE_FLAG = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString(),
					BILLING_VIA_WEB_TEST_FLAG = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString(),
					BILLING_VIA_WEB_LIVE_FLAG = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString(),
					BILLING_VIA_RMA_DATA_ENTRY = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString(),
					DATE_START_RMA_DATA_ENTRY = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]),
					DATE_START_DISKETTE = ConvertDEC(Reader["DATE_START_DISKETTE"]),
					DATE_START_PAPER = ConvertDEC(Reader["DATE_START_PAPER"]),
					DATE_START_WEB_LIVE = ConvertDEC(Reader["DATE_START_WEB_LIVE"]),
					DATE_START_WEB_TEST = ConvertDEC(Reader["DATE_START_WEB_TEST"]),
					LEAVE_DESCRIPTION = Reader["LEAVE_DESCRIPTION"].ToString(),
					LEAVE_DATE_START = ConvertDEC(Reader["LEAVE_DATE_START"]),
					LEAVE_DATE_END = ConvertDEC(Reader["LEAVE_DATE_END"]),
					WEB_USER_REVENUE_ONLY_FLAG = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString(),
					MANAGER_FLAG = Reader["MANAGER_FLAG"].ToString(),
					CHAIR_FLAG = Reader["CHAIR_FLAG"].ToString(),
					ABE_USER_FLAG = Reader["ABE_USER_FLAG"].ToString(),
					CPSO_NBR = Reader["CPSO_NBR"].ToString(),
					CMPA_NBR = Reader["CMPA_NBR"].ToString(),
					OMA_NBR = Reader["OMA_NBR"].ToString(),
					CFPC_NBR = Reader["CFPC_NBR"].ToString(),
					RCPSC_NBR = Reader["RCPSC_NBR"].ToString(),
					DOC_MED_PROF_CORP = Reader["DOC_MED_PROF_CORP"].ToString(),
					MCMASTER_EMPLOYEE_ID = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]),
					DOC_SPEC_CD_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]),
					DOC_SPEC_CD_2_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]),
					DOC_SPEC_CD_3_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]),
					FACTOR_GST_INCOME_REG = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]),
					FACTOR_GST_INCOME_MISC = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]),
					YELLOW_PAGES_FLAG = Reader["YELLOW_PAGES_FLAG"].ToString(),
					REPLACED_BY_DOC_NBR = Reader["REPLACED_BY_DOC_NBR"].ToString(),
					PRIOR_DOC_NBR = Reader["PRIOR_DOC_NBR"].ToString(),
					COP_NBR = Reader["COP_NBR"].ToString(),
					DOC_FLAG_PRIMARY = Reader["DOC_FLAG_PRIMARY"].ToString(),
					HAS_VALID_CURRENT_PAYROLL_RECORD = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString(),
					PAY_THIS_DOCTOR_OHIP_PREMIUM = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString(),
					DOC_FISCAL_YR_START_MONTH = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]),
					LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_dept = WhereDoc_dept,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereDoc_sin_nbr = WhereDoc_sin_nbr,
					_whereDoc_spec_cd = WhereDoc_spec_cd,
					_whereDoc_hosp_nbr = WhereDoc_hosp_nbr,
					_whereDoc_name = WhereDoc_name,
					_whereDoc_name_soundex = WhereDoc_name_soundex,
					_whereDoc_inits = WhereDoc_inits,
					_whereDoc_full_part_ind = WhereDoc_full_part_ind,
					_whereDoc_bank_nbr = WhereDoc_bank_nbr,
					_whereDoc_bank_branch = WhereDoc_bank_branch,
					_whereDoc_bank_acct = WhereDoc_bank_acct,
					_whereDoc_date_fac_start = WhereDoc_date_fac_start,
					_whereDoc_date_fac_term = WhereDoc_date_fac_term,
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
					_whereDoc_spec_cd_2 = WhereDoc_spec_cd_2,
					_whereDoc_spec_cd_3 = WhereDoc_spec_cd_3,
					_whereDoc_ytdinc_g = WhereDoc_ytdinc_g,
					_whereDoc_locations = WhereDoc_locations,
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc,
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group,
					_whereDoc_dept_2 = WhereDoc_dept_2,
					_whereDoc_ind_pays_gst = WhereDoc_ind_pays_gst,
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
					_whereDoc_specialties = WhereDoc_specialties,
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue,
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue,
					_whereDoc_ceireq = WhereDoc_ceireq,
					_whereDoc_ytdreq = WhereDoc_ytdreq,
					_whereDoc_ceitar = WhereDoc_ceitar,
					_whereDoc_ytdtar = WhereDoc_ytdtar,
					_wherevia_paper_flag = Wherevia_paper_flag,
					_wherevia_diskette_flag = Wherevia_diskette_flag,
					_wherevia_web_test_flag = Wherevia_web_test_flag,
					_wherevia_web_live_flag = Wherevia_web_live_flag,
					_wherevia_rma_data_entry = Wherevia_rma_data_entry,
					_whereDate_start_rma_data_entry = WhereDate_start_rma_data_entry,
					_whereDate_start_diskette = WhereDate_start_diskette,
					_whereDate_start_paper = WhereDate_start_paper,
					_whereDate_start_web_live = WhereDate_start_web_live,
					_whereDate_start_web_test = WhereDate_start_web_test,
					_whereLeave_description = WhereLeave_description,
					_whereLeave_date_start = WhereLeave_date_start,
					_whereLeave_date_end = WhereLeave_date_end,
					_whereWeb_user_revenue_only_flag = WhereWeb_user_revenue_only_flag,
					_whereManager_flag = WhereManager_flag,
					_whereChair_flag = WhereChair_flag,
					_whereAbe_user_flag = WhereAbe_user_flag,
					_whereCpso_nbr = WhereCpso_nbr,
					_whereCmpa_nbr = WhereCmpa_nbr,
					_whereOma_nbr = WhereOma_nbr,
					_whereCfpc_nbr = WhereCfpc_nbr,
					_whereRcpsc_nbr = WhereRcpsc_nbr,
					_whereDoc_med_prof_corp = WhereDoc_med_prof_corp,
					_whereMcmaster_employee_id = WhereMcmaster_employee_id,
					_whereDoc_spec_cd_eff_date = WhereDoc_spec_cd_eff_date,
					_whereDoc_spec_cd_2_eff_date = WhereDoc_spec_cd_2_eff_date,
					_whereDoc_spec_cd_3_eff_date = WhereDoc_spec_cd_3_eff_date,
					_whereFactor_gst_income_reg = WhereFactor_gst_income_reg,
					_whereFactor_gst_income_misc = WhereFactor_gst_income_misc,
					_whereYellow_pages_flag = WhereYellow_pages_flag,
					_whereReplaced_by_doc_nbr = WhereReplaced_by_doc_nbr,
					_wherePrior_doc_nbr = WherePrior_doc_nbr,
					_whereCop_nbr = WhereCop_nbr,
					_whereDoc_flag_primary = WhereDoc_flag_primary,
					_whereHas_valid_current_payroll_record = WhereHas_valid_current_payroll_record,
					_wherePay_this_doctor_ohip_premium = WherePay_this_doctor_ohip_premium,
					_whereDoc_fiscal_yr_start_month = WhereDoc_fiscal_yr_start_month,
					_whereLast_mod_flag = WhereLast_mod_flag,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString(),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
					_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]),
					_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]),
					_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString(),
					_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
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
					_originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]),
					_originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]),
					_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]),
					_originalDoc_locations = Reader["DOC_LOCATIONS"].ToString(),
					_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]),
					_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString(),
					_originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]),
					_originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]),
					_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]),
					_originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString(),
					_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]),
					_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]),
					_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]),
					_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]),
					_originalDoc_ep_ped = ConvertDEC(Reader["DOC_EP_PED"]),
					_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString(),
					_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString(),
					_originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString(),
					_originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString(),
					_originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString(),
					_originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString(),
					_originalDoc_specialties = Reader["DOC_SPECIALTIES"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalvia_paper_flag = Reader["BILLING_VIA_PAPER_FLAG"].ToString(),
					_originalvia_diskette_flag = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString(),
					_originalvia_web_test_flag = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString(),
					_originalvia_web_live_flag = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString(),
					_originalvia_rma_data_entry = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString(),
					_originalDate_start_rma_data_entry = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]),
					_originalDate_start_diskette = ConvertDEC(Reader["DATE_START_DISKETTE"]),
					_originalDate_start_paper = ConvertDEC(Reader["DATE_START_PAPER"]),
					_originalDate_start_web_live = ConvertDEC(Reader["DATE_START_WEB_LIVE"]),
					_originalDate_start_web_test = ConvertDEC(Reader["DATE_START_WEB_TEST"]),
					_originalLeave_description = Reader["LEAVE_DESCRIPTION"].ToString(),
					_originalLeave_date_start = ConvertDEC(Reader["LEAVE_DATE_START"]),
					_originalLeave_date_end = ConvertDEC(Reader["LEAVE_DATE_END"]),
					_originalWeb_user_revenue_only_flag = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString(),
					_originalManager_flag = Reader["MANAGER_FLAG"].ToString(),
					_originalChair_flag = Reader["CHAIR_FLAG"].ToString(),
					_originalAbe_user_flag = Reader["ABE_USER_FLAG"].ToString(),
					_originalCpso_nbr = Reader["CPSO_NBR"].ToString(),
					_originalCmpa_nbr = Reader["CMPA_NBR"].ToString(),
					_originalOma_nbr = Reader["OMA_NBR"].ToString(),
					_originalCfpc_nbr = Reader["CFPC_NBR"].ToString(),
					_originalRcpsc_nbr = Reader["RCPSC_NBR"].ToString(),
					_originalDoc_med_prof_corp = Reader["DOC_MED_PROF_CORP"].ToString(),
					_originalMcmaster_employee_id = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]),
					_originalDoc_spec_cd_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]),
					_originalDoc_spec_cd_2_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]),
					_originalDoc_spec_cd_3_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]),
					_originalFactor_gst_income_reg = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]),
					_originalFactor_gst_income_misc = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]),
					_originalYellow_pages_flag = Reader["YELLOW_PAGES_FLAG"].ToString(),
					_originalReplaced_by_doc_nbr = Reader["REPLACED_BY_DOC_NBR"].ToString(),
					_originalPrior_doc_nbr = Reader["PRIOR_DOC_NBR"].ToString(),
					_originalCop_nbr = Reader["COP_NBR"].ToString(),
					_originalDoc_flag_primary = Reader["DOC_FLAG_PRIMARY"].ToString(),
					_originalHas_valid_current_payroll_record = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString(),
					_originalPay_this_doctor_ohip_premium = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString(),
					_originalDoc_fiscal_yr_start_month = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]),
					_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_dept = WhereDoc_dept;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereDoc_sin_nbr = WhereDoc_sin_nbr;
					_whereDoc_spec_cd = WhereDoc_spec_cd;
					_whereDoc_hosp_nbr = WhereDoc_hosp_nbr;
					_whereDoc_name = WhereDoc_name;
					_whereDoc_name_soundex = WhereDoc_name_soundex;
					_whereDoc_inits = WhereDoc_inits;
					_whereDoc_full_part_ind = WhereDoc_full_part_ind;
					_whereDoc_bank_nbr = WhereDoc_bank_nbr;
					_whereDoc_bank_branch = WhereDoc_bank_branch;
					_whereDoc_bank_acct = WhereDoc_bank_acct;
					_whereDoc_date_fac_start = WhereDoc_date_fac_start;
					_whereDoc_date_fac_term = WhereDoc_date_fac_term;
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
					_whereDoc_spec_cd_2 = WhereDoc_spec_cd_2;
					_whereDoc_spec_cd_3 = WhereDoc_spec_cd_3;
					_whereDoc_ytdinc_g = WhereDoc_ytdinc_g;
					_whereDoc_locations = WhereDoc_locations;
					_whereDoc_rma_expense_percent_misc = WhereDoc_rma_expense_percent_misc;
					_whereDoc_afp_paym_group = WhereDoc_afp_paym_group;
					_whereDoc_dept_2 = WhereDoc_dept_2;
					_whereDoc_ind_pays_gst = WhereDoc_ind_pays_gst;
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
					_whereDoc_specialties = WhereDoc_specialties;
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue;
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue;
					_whereDoc_ceireq = WhereDoc_ceireq;
					_whereDoc_ytdreq = WhereDoc_ytdreq;
					_whereDoc_ceitar = WhereDoc_ceitar;
					_whereDoc_ytdtar = WhereDoc_ytdtar;
					_wherevia_paper_flag = Wherevia_paper_flag;
					_wherevia_diskette_flag = Wherevia_diskette_flag;
					_wherevia_web_test_flag = Wherevia_web_test_flag;
					_wherevia_web_live_flag = Wherevia_web_live_flag;
					_wherevia_rma_data_entry = Wherevia_rma_data_entry;
					_whereDate_start_rma_data_entry = WhereDate_start_rma_data_entry;
					_whereDate_start_diskette = WhereDate_start_diskette;
					_whereDate_start_paper = WhereDate_start_paper;
					_whereDate_start_web_live = WhereDate_start_web_live;
					_whereDate_start_web_test = WhereDate_start_web_test;
					_whereLeave_description = WhereLeave_description;
					_whereLeave_date_start = WhereLeave_date_start;
					_whereLeave_date_end = WhereLeave_date_end;
					_whereWeb_user_revenue_only_flag = WhereWeb_user_revenue_only_flag;
					_whereManager_flag = WhereManager_flag;
					_whereChair_flag = WhereChair_flag;
					_whereAbe_user_flag = WhereAbe_user_flag;
					_whereCpso_nbr = WhereCpso_nbr;
					_whereCmpa_nbr = WhereCmpa_nbr;
					_whereOma_nbr = WhereOma_nbr;
					_whereCfpc_nbr = WhereCfpc_nbr;
					_whereRcpsc_nbr = WhereRcpsc_nbr;
					_whereDoc_med_prof_corp = WhereDoc_med_prof_corp;
					_whereMcmaster_employee_id = WhereMcmaster_employee_id;
					_whereDoc_spec_cd_eff_date = WhereDoc_spec_cd_eff_date;
					_whereDoc_spec_cd_2_eff_date = WhereDoc_spec_cd_2_eff_date;
					_whereDoc_spec_cd_3_eff_date = WhereDoc_spec_cd_3_eff_date;
					_whereFactor_gst_income_reg = WhereFactor_gst_income_reg;
					_whereFactor_gst_income_misc = WhereFactor_gst_income_misc;
					_whereYellow_pages_flag = WhereYellow_pages_flag;
					_whereReplaced_by_doc_nbr = WhereReplaced_by_doc_nbr;
					_wherePrior_doc_nbr = WherePrior_doc_nbr;
					_whereCop_nbr = WhereCop_nbr;
					_whereDoc_flag_primary = WhereDoc_flag_primary;
					_whereHas_valid_current_payroll_record = WhereHas_valid_current_payroll_record;
					_wherePay_this_doctor_ohip_premium = WherePay_this_doctor_ohip_premium;
					_whereDoc_fiscal_yr_start_month = WhereDoc_fiscal_yr_start_month;
					_whereLast_mod_flag = WhereLast_mod_flag;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
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
				&& WhereDoc_sin_nbr == null 
				&& WhereDoc_spec_cd == null 
				&& WhereDoc_hosp_nbr == null 
				&& WhereDoc_name == null 
				&& WhereDoc_name_soundex == null 
				&& WhereDoc_inits == null 
				&& WhereDoc_full_part_ind == null 
				&& WhereDoc_bank_nbr == null 
				&& WhereDoc_bank_branch == null 
				&& WhereDoc_bank_acct == null 
				&& WhereDoc_date_fac_start == null 
				&& WhereDoc_date_fac_term == null 
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
				&& WhereDoc_spec_cd_2 == null 
				&& WhereDoc_spec_cd_3 == null 
				&& WhereDoc_ytdinc_g == null 
				&& WhereDoc_locations == null 
				&& WhereDoc_rma_expense_percent_misc == null 
				&& WhereDoc_afp_paym_group == null 
				&& WhereDoc_dept_2 == null 
				&& WhereDoc_ind_pays_gst == null 
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
				&& WhereDoc_specialties == null 
				&& WhereDoc_yrly_require_revenue == null 
				&& WhereDoc_yrly_target_revenue == null 
				&& WhereDoc_ceireq == null 
				&& WhereDoc_ytdreq == null 
				&& WhereDoc_ceitar == null 
				&& WhereDoc_ytdtar == null 
				&& Wherevia_paper_flag == null 
				&& Wherevia_diskette_flag == null 
				&& Wherevia_web_test_flag == null 
				&& Wherevia_web_live_flag == null 
				&& Wherevia_rma_data_entry == null 
				&& WhereDate_start_rma_data_entry == null 
				&& WhereDate_start_diskette == null 
				&& WhereDate_start_paper == null 
				&& WhereDate_start_web_live == null 
				&& WhereDate_start_web_test == null 
				&& WhereLeave_description == null 
				&& WhereLeave_date_start == null 
				&& WhereLeave_date_end == null 
				&& WhereWeb_user_revenue_only_flag == null 
				&& WhereManager_flag == null 
				&& WhereChair_flag == null 
				&& WhereAbe_user_flag == null 
				&& WhereCpso_nbr == null 
				&& WhereCmpa_nbr == null 
				&& WhereOma_nbr == null 
				&& WhereCfpc_nbr == null 
				&& WhereRcpsc_nbr == null 
				&& WhereDoc_med_prof_corp == null 
				&& WhereMcmaster_employee_id == null 
				&& WhereDoc_spec_cd_eff_date == null 
				&& WhereDoc_spec_cd_2_eff_date == null 
				&& WhereDoc_spec_cd_3_eff_date == null 
				&& WhereFactor_gst_income_reg == null 
				&& WhereFactor_gst_income_misc == null 
				&& WhereYellow_pages_flag == null 
				&& WhereReplaced_by_doc_nbr == null 
				&& WherePrior_doc_nbr == null 
				&& WhereCop_nbr == null 
				&& WhereDoc_flag_primary == null 
				&& WhereHas_valid_current_payroll_record == null 
				&& WherePay_this_doctor_ohip_premium == null 
				&& WhereDoc_fiscal_yr_start_month == null 
				&& WhereLast_mod_flag == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_dept ==  _whereDoc_dept
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereDoc_sin_nbr ==  _whereDoc_sin_nbr
				&& WhereDoc_spec_cd ==  _whereDoc_spec_cd
				&& WhereDoc_hosp_nbr ==  _whereDoc_hosp_nbr
				&& WhereDoc_name ==  _whereDoc_name
				&& WhereDoc_name_soundex ==  _whereDoc_name_soundex
				&& WhereDoc_inits ==  _whereDoc_inits
				&& WhereDoc_full_part_ind ==  _whereDoc_full_part_ind
				&& WhereDoc_bank_nbr ==  _whereDoc_bank_nbr
				&& WhereDoc_bank_branch ==  _whereDoc_bank_branch
				&& WhereDoc_bank_acct ==  _whereDoc_bank_acct
				&& WhereDoc_date_fac_start ==  _whereDoc_date_fac_start
				&& WhereDoc_date_fac_term ==  _whereDoc_date_fac_term
				&& WhereDoc_ytdgua ==  _whereDoc_ytdgua
				&& WhereDoc_ytdgub ==  _whereDoc_ytdgub
				&& WhereDoc_ytdguc ==  _whereDoc_ytdguc
				&& WhereDoc_ytdgud ==  _whereDoc_ytdgud
				&& WhereDoc_ytdcea ==  _whereDoc_ytdcea
				&& WhereDoc_ytdcex ==  _whereDoc_ytdcex
				&& WhereDoc_ytdear ==  _whereDoc_ytdear
				&& WhereDoc_ytdinc ==  _whereDoc_ytdinc
				&& WhereDoc_ytdeft ==  _whereDoc_ytdeft
				&& WhereDoc_totinc_g ==  _whereDoc_totinc_g
				&& WhereDoc_ep_date_deposit ==  _whereDoc_ep_date_deposit
				&& WhereDoc_totinc ==  _whereDoc_totinc
				&& WhereDoc_ep_ceiexp ==  _whereDoc_ep_ceiexp
				&& WhereDoc_adjcea ==  _whereDoc_adjcea
				&& WhereDoc_adjcex ==  _whereDoc_adjcex
				&& WhereDoc_ceicea ==  _whereDoc_ceicea
				&& WhereDoc_ceicex ==  _whereDoc_ceicex
				&& WhereDoc_spec_cd_2 ==  _whereDoc_spec_cd_2
				&& WhereDoc_spec_cd_3 ==  _whereDoc_spec_cd_3
				&& WhereDoc_ytdinc_g ==  _whereDoc_ytdinc_g
				&& WhereDoc_locations ==  _whereDoc_locations
				&& WhereDoc_rma_expense_percent_misc ==  _whereDoc_rma_expense_percent_misc
				&& WhereDoc_afp_paym_group ==  _whereDoc_afp_paym_group
				&& WhereDoc_dept_2 ==  _whereDoc_dept_2
				&& WhereDoc_ind_pays_gst ==  _whereDoc_ind_pays_gst
				&& WhereDoc_yrly_ceiling_computed ==  _whereDoc_yrly_ceiling_computed
				&& WhereDoc_yrly_expense_computed ==  _whereDoc_yrly_expense_computed
				&& WhereDoc_rma_expense_percent_reg ==  _whereDoc_rma_expense_percent_reg
				&& WhereDoc_sub_specialty ==  _whereDoc_sub_specialty
				&& WhereDoc_payeft ==  _whereDoc_payeft
				&& WhereDoc_ytdded ==  _whereDoc_ytdded
				&& WhereDoc_dept_expense_percent_misc ==  _whereDoc_dept_expense_percent_misc
				&& WhereDoc_dept_expense_percent_reg ==  _whereDoc_dept_expense_percent_reg
				&& WhereDoc_ep_ped ==  _whereDoc_ep_ped
				&& WhereDoc_ep_pay_code ==  _whereDoc_ep_pay_code
				&& WhereDoc_ep_pay_sub_code ==  _whereDoc_ep_pay_sub_code
				&& WhereDoc_partnership ==  _whereDoc_partnership
				&& WhereDoc_ind_holdback_active ==  _whereDoc_ind_holdback_active
				&& WhereGroup_regular_service ==  _whereGroup_regular_service
				&& WhereGroup_over_serviced ==  _whereGroup_over_serviced
				&& WhereDoc_specialties ==  _whereDoc_specialties
				&& WhereDoc_yrly_require_revenue ==  _whereDoc_yrly_require_revenue
				&& WhereDoc_yrly_target_revenue ==  _whereDoc_yrly_target_revenue
				&& WhereDoc_ceireq ==  _whereDoc_ceireq
				&& WhereDoc_ytdreq ==  _whereDoc_ytdreq
				&& WhereDoc_ceitar ==  _whereDoc_ceitar
				&& WhereDoc_ytdtar ==  _whereDoc_ytdtar
				&& Wherevia_paper_flag ==  _wherevia_paper_flag
				&& Wherevia_diskette_flag ==  _wherevia_diskette_flag
				&& Wherevia_web_test_flag ==  _wherevia_web_test_flag
				&& Wherevia_web_live_flag ==  _wherevia_web_live_flag
				&& Wherevia_rma_data_entry ==  _wherevia_rma_data_entry
				&& WhereDate_start_rma_data_entry ==  _whereDate_start_rma_data_entry
				&& WhereDate_start_diskette ==  _whereDate_start_diskette
				&& WhereDate_start_paper ==  _whereDate_start_paper
				&& WhereDate_start_web_live ==  _whereDate_start_web_live
				&& WhereDate_start_web_test ==  _whereDate_start_web_test
				&& WhereLeave_description ==  _whereLeave_description
				&& WhereLeave_date_start ==  _whereLeave_date_start
				&& WhereLeave_date_end ==  _whereLeave_date_end
				&& WhereWeb_user_revenue_only_flag ==  _whereWeb_user_revenue_only_flag
				&& WhereManager_flag ==  _whereManager_flag
				&& WhereChair_flag ==  _whereChair_flag
				&& WhereAbe_user_flag ==  _whereAbe_user_flag
				&& WhereCpso_nbr ==  _whereCpso_nbr
				&& WhereCmpa_nbr ==  _whereCmpa_nbr
				&& WhereOma_nbr ==  _whereOma_nbr
				&& WhereCfpc_nbr ==  _whereCfpc_nbr
				&& WhereRcpsc_nbr ==  _whereRcpsc_nbr
				&& WhereDoc_med_prof_corp ==  _whereDoc_med_prof_corp
				&& WhereMcmaster_employee_id ==  _whereMcmaster_employee_id
				&& WhereDoc_spec_cd_eff_date ==  _whereDoc_spec_cd_eff_date
				&& WhereDoc_spec_cd_2_eff_date ==  _whereDoc_spec_cd_2_eff_date
				&& WhereDoc_spec_cd_3_eff_date ==  _whereDoc_spec_cd_3_eff_date
				&& WhereFactor_gst_income_reg ==  _whereFactor_gst_income_reg
				&& WhereFactor_gst_income_misc ==  _whereFactor_gst_income_misc
				&& WhereYellow_pages_flag ==  _whereYellow_pages_flag
				&& WhereReplaced_by_doc_nbr ==  _whereReplaced_by_doc_nbr
				&& WherePrior_doc_nbr ==  _wherePrior_doc_nbr
				&& WhereCop_nbr ==  _whereCop_nbr
				&& WhereDoc_flag_primary ==  _whereDoc_flag_primary
				&& WhereHas_valid_current_payroll_record ==  _whereHas_valid_current_payroll_record
				&& WherePay_this_doctor_ohip_premium ==  _wherePay_this_doctor_ohip_premium
				&& WhereDoc_fiscal_yr_start_month ==  _whereDoc_fiscal_yr_start_month
				&& WhereLast_mod_flag ==  _whereLast_mod_flag
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereDoc_dept = null; 
			WhereDoc_ohip_nbr = null; 
			WhereDoc_sin_nbr = null; 
			WhereDoc_spec_cd = null; 
			WhereDoc_hosp_nbr = null; 
			WhereDoc_name = null; 
			WhereDoc_name_soundex = null; 
			WhereDoc_inits = null; 
			WhereDoc_full_part_ind = null; 
			WhereDoc_bank_nbr = null; 
			WhereDoc_bank_branch = null; 
			WhereDoc_bank_acct = null; 
			WhereDoc_date_fac_start = null; 
			WhereDoc_date_fac_term = null; 
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
			WhereDoc_spec_cd_2 = null; 
			WhereDoc_spec_cd_3 = null; 
			WhereDoc_ytdinc_g = null; 
			WhereDoc_locations = null; 
			WhereDoc_rma_expense_percent_misc = null; 
			WhereDoc_afp_paym_group = null; 
			WhereDoc_dept_2 = null; 
			WhereDoc_ind_pays_gst = null; 
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
			WhereDoc_specialties = null; 
			WhereDoc_yrly_require_revenue = null; 
			WhereDoc_yrly_target_revenue = null; 
			WhereDoc_ceireq = null; 
			WhereDoc_ytdreq = null; 
			WhereDoc_ceitar = null; 
			WhereDoc_ytdtar = null; 
			Wherevia_paper_flag = null; 
			Wherevia_diskette_flag = null; 
			Wherevia_web_test_flag = null; 
			Wherevia_web_live_flag = null; 
			Wherevia_rma_data_entry = null; 
			WhereDate_start_rma_data_entry = null; 
			WhereDate_start_diskette = null; 
			WhereDate_start_paper = null; 
			WhereDate_start_web_live = null; 
			WhereDate_start_web_test = null; 
			WhereLeave_description = null; 
			WhereLeave_date_start = null; 
			WhereLeave_date_end = null; 
			WhereWeb_user_revenue_only_flag = null; 
			WhereManager_flag = null; 
			WhereChair_flag = null; 
			WhereAbe_user_flag = null; 
			WhereCpso_nbr = null; 
			WhereCmpa_nbr = null; 
			WhereOma_nbr = null; 
			WhereCfpc_nbr = null; 
			WhereRcpsc_nbr = null; 
			WhereDoc_med_prof_corp = null; 
			WhereMcmaster_employee_id = null; 
			WhereDoc_spec_cd_eff_date = null; 
			WhereDoc_spec_cd_2_eff_date = null; 
			WhereDoc_spec_cd_3_eff_date = null; 
			WhereFactor_gst_income_reg = null; 
			WhereFactor_gst_income_misc = null; 
			WhereYellow_pages_flag = null; 
			WhereReplaced_by_doc_nbr = null; 
			WherePrior_doc_nbr = null; 
			WhereCop_nbr = null; 
			WhereDoc_flag_primary = null; 
			WhereHas_valid_current_payroll_record = null; 
			WherePay_this_doctor_ohip_premium = null; 
			WhereDoc_fiscal_yr_start_month = null; 
			WhereLast_mod_flag = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
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
		private decimal? _DOC_SIN_NBR;
		private decimal? _DOC_SPEC_CD;
		private string _DOC_HOSP_NBR;
		private string _DOC_NAME;
		private string _DOC_NAME_SOUNDEX;
		private string _DOC_INITS;
		private string _DOC_FULL_PART_IND;
		private decimal? _DOC_BANK_NBR;
		private decimal? _DOC_BANK_BRANCH;
		private string _DOC_BANK_ACCT;
		private decimal? _DOC_DATE_FAC_START;
		private decimal? _DOC_DATE_FAC_TERM;
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
		private decimal? _DOC_SPEC_CD_2;
		private decimal? _DOC_SPEC_CD_3;
		private decimal? _DOC_YTDINC_G;
		private string _DOC_LOCATIONS;
		private int? _DOC_RMA_EXPENSE_PERCENT_MISC;
		private string _DOC_AFP_PAYM_GROUP;
		private decimal? _DOC_DEPT_2;
		private string _DOC_IND_PAYS_GST;
		private decimal? _DOC_YRLY_CEILING_COMPUTED;
		private decimal? _DOC_YRLY_EXPENSE_COMPUTED;
		private int? _DOC_RMA_EXPENSE_PERCENT_REG;
		private string _DOC_SUB_SPECIALTY;
		private decimal? _DOC_PAYEFT;
		private decimal? _DOC_YTDDED;
		private int? _DOC_DEPT_EXPENSE_PERCENT_MISC;
		private int? _DOC_DEPT_EXPENSE_PERCENT_REG;
		private decimal? _DOC_EP_PED;
		private string _DOC_EP_PAY_CODE;
		private string _DOC_EP_PAY_SUB_CODE;
		private string _DOC_PARTNERSHIP;
		private string _DOC_IND_HOLDBACK_ACTIVE;
		private string _GROUP_REGULAR_SERVICE;
		private string _GROUP_OVER_SERVICED;
		private string _DOC_SPECIALTIES;
		private decimal? _DOC_YRLY_REQUIRE_REVENUE;
		private decimal? _DOC_YRLY_TARGET_REVENUE;
		private decimal? _DOC_CEIREQ;
		private decimal? _DOC_YTDREQ;
		private decimal? _DOC_CEITAR;
		private decimal? _DOC_YTDTAR;
		private string _BILLING_VIA_PAPER_FLAG;
		private string _BILLING_VIA_DISKETTE_FLAG;
		private string _BILLING_VIA_WEB_TEST_FLAG;
		private string _BILLING_VIA_WEB_LIVE_FLAG;
		private string _BILLING_VIA_RMA_DATA_ENTRY;
		private decimal? _DATE_START_RMA_DATA_ENTRY;
		private decimal? _DATE_START_DISKETTE;
		private decimal? _DATE_START_PAPER;
		private decimal? _DATE_START_WEB_LIVE;
		private decimal? _DATE_START_WEB_TEST;
		private string _LEAVE_DESCRIPTION;
		private decimal? _LEAVE_DATE_START;
		private decimal? _LEAVE_DATE_END;
		private string _WEB_USER_REVENUE_ONLY_FLAG;
		private string _MANAGER_FLAG;
		private string _CHAIR_FLAG;
		private string _ABE_USER_FLAG;
		private string _CPSO_NBR;
		private string _CMPA_NBR;
		private string _OMA_NBR;
		private string _CFPC_NBR;
		private string _RCPSC_NBR;
		private string _DOC_MED_PROF_CORP;
		private decimal? _MCMASTER_EMPLOYEE_ID;
		private decimal? _DOC_SPEC_CD_EFF_DATE;
		private decimal? _DOC_SPEC_CD_2_EFF_DATE;
		private decimal? _DOC_SPEC_CD_3_EFF_DATE;
		private decimal? _FACTOR_GST_INCOME_REG;
		private decimal? _FACTOR_GST_INCOME_MISC;
		private string _YELLOW_PAGES_FLAG;
		private string _REPLACED_BY_DOC_NBR;
		private string _PRIOR_DOC_NBR;
		private string _COP_NBR;
		private string _DOC_FLAG_PRIMARY;
		private string _HAS_VALID_CURRENT_PAYROLL_RECORD;
		private string _PAY_THIS_DOCTOR_OHIP_PREMIUM;
		private decimal? _DOC_FISCAL_YR_START_MONTH;
		private string _LAST_MOD_FLAG;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
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
		public decimal? DOC_SIN_NBR
		{
			get { return _DOC_SIN_NBR; }
			set
			{
				if (_DOC_SIN_NBR != value)
				{
					_DOC_SIN_NBR = value;
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
		public string DOC_INITS
		{
			get { return _DOC_INITS; }
			set
			{
				if (_DOC_INITS != value)
				{
					_DOC_INITS = value;
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
		public decimal? DOC_DATE_FAC_START
		{
			get { return _DOC_DATE_FAC_START; }
			set
			{
				if (_DOC_DATE_FAC_START != value)
				{
					_DOC_DATE_FAC_START = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_DATE_FAC_TERM
		{
			get { return _DOC_DATE_FAC_TERM; }
			set
			{
				if (_DOC_DATE_FAC_TERM != value)
				{
					_DOC_DATE_FAC_TERM = value;
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
		public string DOC_LOCATIONS
		{
			get { return _DOC_LOCATIONS; }
			set
			{
				if (_DOC_LOCATIONS != value)
				{
					_DOC_LOCATIONS = value;
					ChangeState();
				}
			}
		}
		public int? DOC_RMA_EXPENSE_PERCENT_MISC
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
		public int? DOC_RMA_EXPENSE_PERCENT_REG
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
		public int? DOC_DEPT_EXPENSE_PERCENT_MISC
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
		public int? DOC_DEPT_EXPENSE_PERCENT_REG
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
		public decimal? DOC_EP_PED
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
		public string DOC_SPECIALTIES
		{
			get { return _DOC_SPECIALTIES; }
			set
			{
				if (_DOC_SPECIALTIES != value)
				{
					_DOC_SPECIALTIES = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_REQUIRE_REVENUE
		{
			get { return _DOC_YRLY_REQUIRE_REVENUE; }
			set
			{
				if (_DOC_YRLY_REQUIRE_REVENUE != value)
				{
					_DOC_YRLY_REQUIRE_REVENUE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YRLY_TARGET_REVENUE
		{
			get { return _DOC_YRLY_TARGET_REVENUE; }
			set
			{
				if (_DOC_YRLY_TARGET_REVENUE != value)
				{
					_DOC_YRLY_TARGET_REVENUE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEIREQ
		{
			get { return _DOC_CEIREQ; }
			set
			{
				if (_DOC_CEIREQ != value)
				{
					_DOC_CEIREQ = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDREQ
		{
			get { return _DOC_YTDREQ; }
			set
			{
				if (_DOC_YTDREQ != value)
				{
					_DOC_YTDREQ = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_CEITAR
		{
			get { return _DOC_CEITAR; }
			set
			{
				if (_DOC_CEITAR != value)
				{
					_DOC_CEITAR = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_YTDTAR
		{
			get { return _DOC_YTDTAR; }
			set
			{
				if (_DOC_YTDTAR != value)
				{
					_DOC_YTDTAR = value;
					ChangeState();
				}
			}
		}
		public string BILLING_VIA_PAPER_FLAG
		{
			get { return _BILLING_VIA_PAPER_FLAG; }
			set
			{
				if (_BILLING_VIA_PAPER_FLAG != value)
				{
					_BILLING_VIA_PAPER_FLAG = value;
					ChangeState();
				}
			}
		}
		public string BILLING_VIA_DISKETTE_FLAG
		{
			get { return _BILLING_VIA_DISKETTE_FLAG; }
			set
			{
				if (_BILLING_VIA_DISKETTE_FLAG != value)
				{
					_BILLING_VIA_DISKETTE_FLAG = value;
					ChangeState();
				}
			}
		}
		public string BILLING_VIA_WEB_TEST_FLAG
		{
			get { return _BILLING_VIA_WEB_TEST_FLAG; }
			set
			{
				if (_BILLING_VIA_WEB_TEST_FLAG != value)
				{
					_BILLING_VIA_WEB_TEST_FLAG = value;
					ChangeState();
				}
			}
		}
		public string BILLING_VIA_WEB_LIVE_FLAG
		{
			get { return _BILLING_VIA_WEB_LIVE_FLAG; }
			set
			{
				if (_BILLING_VIA_WEB_LIVE_FLAG != value)
				{
					_BILLING_VIA_WEB_LIVE_FLAG = value;
					ChangeState();
				}
			}
		}
		public string BILLING_VIA_RMA_DATA_ENTRY
		{
			get { return _BILLING_VIA_RMA_DATA_ENTRY; }
			set
			{
				if (_BILLING_VIA_RMA_DATA_ENTRY != value)
				{
					_BILLING_VIA_RMA_DATA_ENTRY = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_START_RMA_DATA_ENTRY
		{
			get { return _DATE_START_RMA_DATA_ENTRY; }
			set
			{
				if (_DATE_START_RMA_DATA_ENTRY != value)
				{
					_DATE_START_RMA_DATA_ENTRY = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_START_DISKETTE
		{
			get { return _DATE_START_DISKETTE; }
			set
			{
				if (_DATE_START_DISKETTE != value)
				{
					_DATE_START_DISKETTE = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_START_PAPER
		{
			get { return _DATE_START_PAPER; }
			set
			{
				if (_DATE_START_PAPER != value)
				{
					_DATE_START_PAPER = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_START_WEB_LIVE
		{
			get { return _DATE_START_WEB_LIVE; }
			set
			{
				if (_DATE_START_WEB_LIVE != value)
				{
					_DATE_START_WEB_LIVE = value;
					ChangeState();
				}
			}
		}
		public decimal? DATE_START_WEB_TEST
		{
			get { return _DATE_START_WEB_TEST; }
			set
			{
				if (_DATE_START_WEB_TEST != value)
				{
					_DATE_START_WEB_TEST = value;
					ChangeState();
				}
			}
		}
		public string LEAVE_DESCRIPTION
		{
			get { return _LEAVE_DESCRIPTION; }
			set
			{
				if (_LEAVE_DESCRIPTION != value)
				{
					_LEAVE_DESCRIPTION = value;
					ChangeState();
				}
			}
		}
		public decimal? LEAVE_DATE_START
		{
			get { return _LEAVE_DATE_START; }
			set
			{
				if (_LEAVE_DATE_START != value)
				{
					_LEAVE_DATE_START = value;
					ChangeState();
				}
			}
		}
		public decimal? LEAVE_DATE_END
		{
			get { return _LEAVE_DATE_END; }
			set
			{
				if (_LEAVE_DATE_END != value)
				{
					_LEAVE_DATE_END = value;
					ChangeState();
				}
			}
		}
		public string WEB_USER_REVENUE_ONLY_FLAG
		{
			get { return _WEB_USER_REVENUE_ONLY_FLAG; }
			set
			{
				if (_WEB_USER_REVENUE_ONLY_FLAG != value)
				{
					_WEB_USER_REVENUE_ONLY_FLAG = value;
					ChangeState();
				}
			}
		}
		public string MANAGER_FLAG
		{
			get { return _MANAGER_FLAG; }
			set
			{
				if (_MANAGER_FLAG != value)
				{
					_MANAGER_FLAG = value;
					ChangeState();
				}
			}
		}
		public string CHAIR_FLAG
		{
			get { return _CHAIR_FLAG; }
			set
			{
				if (_CHAIR_FLAG != value)
				{
					_CHAIR_FLAG = value;
					ChangeState();
				}
			}
		}
		public string ABE_USER_FLAG
		{
			get { return _ABE_USER_FLAG; }
			set
			{
				if (_ABE_USER_FLAG != value)
				{
					_ABE_USER_FLAG = value;
					ChangeState();
				}
			}
		}
		public string CPSO_NBR
		{
			get { return _CPSO_NBR; }
			set
			{
				if (_CPSO_NBR != value)
				{
					_CPSO_NBR = value;
					ChangeState();
				}
			}
		}
		public string CMPA_NBR
		{
			get { return _CMPA_NBR; }
			set
			{
				if (_CMPA_NBR != value)
				{
					_CMPA_NBR = value;
					ChangeState();
				}
			}
		}
		public string OMA_NBR
		{
			get { return _OMA_NBR; }
			set
			{
				if (_OMA_NBR != value)
				{
					_OMA_NBR = value;
					ChangeState();
				}
			}
		}
		public string CFPC_NBR
		{
			get { return _CFPC_NBR; }
			set
			{
				if (_CFPC_NBR != value)
				{
					_CFPC_NBR = value;
					ChangeState();
				}
			}
		}
		public string RCPSC_NBR
		{
			get { return _RCPSC_NBR; }
			set
			{
				if (_RCPSC_NBR != value)
				{
					_RCPSC_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOC_MED_PROF_CORP
		{
			get { return _DOC_MED_PROF_CORP; }
			set
			{
				if (_DOC_MED_PROF_CORP != value)
				{
					_DOC_MED_PROF_CORP = value;
					ChangeState();
				}
			}
		}
		public decimal? MCMASTER_EMPLOYEE_ID
		{
			get { return _MCMASTER_EMPLOYEE_ID; }
			set
			{
				if (_MCMASTER_EMPLOYEE_ID != value)
				{
					_MCMASTER_EMPLOYEE_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_SPEC_CD_EFF_DATE
		{
			get { return _DOC_SPEC_CD_EFF_DATE; }
			set
			{
				if (_DOC_SPEC_CD_EFF_DATE != value)
				{
					_DOC_SPEC_CD_EFF_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_SPEC_CD_2_EFF_DATE
		{
			get { return _DOC_SPEC_CD_2_EFF_DATE; }
			set
			{
				if (_DOC_SPEC_CD_2_EFF_DATE != value)
				{
					_DOC_SPEC_CD_2_EFF_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_SPEC_CD_3_EFF_DATE
		{
			get { return _DOC_SPEC_CD_3_EFF_DATE; }
			set
			{
				if (_DOC_SPEC_CD_3_EFF_DATE != value)
				{
					_DOC_SPEC_CD_3_EFF_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? FACTOR_GST_INCOME_REG
		{
			get { return _FACTOR_GST_INCOME_REG; }
			set
			{
				if (_FACTOR_GST_INCOME_REG != value)
				{
					_FACTOR_GST_INCOME_REG = value;
					ChangeState();
				}
			}
		}
		public decimal? FACTOR_GST_INCOME_MISC
		{
			get { return _FACTOR_GST_INCOME_MISC; }
			set
			{
				if (_FACTOR_GST_INCOME_MISC != value)
				{
					_FACTOR_GST_INCOME_MISC = value;
					ChangeState();
				}
			}
		}
		public string YELLOW_PAGES_FLAG
		{
			get { return _YELLOW_PAGES_FLAG; }
			set
			{
				if (_YELLOW_PAGES_FLAG != value)
				{
					_YELLOW_PAGES_FLAG = value;
					ChangeState();
				}
			}
		}
		public string REPLACED_BY_DOC_NBR
		{
			get { return _REPLACED_BY_DOC_NBR; }
			set
			{
				if (_REPLACED_BY_DOC_NBR != value)
				{
					_REPLACED_BY_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string PRIOR_DOC_NBR
		{
			get { return _PRIOR_DOC_NBR; }
			set
			{
				if (_PRIOR_DOC_NBR != value)
				{
					_PRIOR_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string COP_NBR
		{
			get { return _COP_NBR; }
			set
			{
				if (_COP_NBR != value)
				{
					_COP_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOC_FLAG_PRIMARY
		{
			get { return _DOC_FLAG_PRIMARY; }
			set
			{
				if (_DOC_FLAG_PRIMARY != value)
				{
					_DOC_FLAG_PRIMARY = value;
					ChangeState();
				}
			}
		}
		public string HAS_VALID_CURRENT_PAYROLL_RECORD
		{
			get { return _HAS_VALID_CURRENT_PAYROLL_RECORD; }
			set
			{
				if (_HAS_VALID_CURRENT_PAYROLL_RECORD != value)
				{
					_HAS_VALID_CURRENT_PAYROLL_RECORD = value;
					ChangeState();
				}
			}
		}
		public string PAY_THIS_DOCTOR_OHIP_PREMIUM
		{
			get { return _PAY_THIS_DOCTOR_OHIP_PREMIUM; }
			set
			{
				if (_PAY_THIS_DOCTOR_OHIP_PREMIUM != value)
				{
					_PAY_THIS_DOCTOR_OHIP_PREMIUM = value;
					ChangeState();
				}
			}
		}
		public decimal? DOC_FISCAL_YR_START_MONTH
		{
			get { return _DOC_FISCAL_YR_START_MONTH; }
			set
			{
				if (_DOC_FISCAL_YR_START_MONTH != value)
				{
					_DOC_FISCAL_YR_START_MONTH = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_FLAG
		{
			get { return _LAST_MOD_FLAG; }
			set
			{
				if (_LAST_MOD_FLAG != value)
				{
					_LAST_MOD_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_DATE
		{
			get { return _LAST_MOD_DATE; }
			set
			{
				if (_LAST_MOD_DATE != value)
				{
					_LAST_MOD_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? LAST_MOD_TIME
		{
			get { return _LAST_MOD_TIME; }
			set
			{
				if (_LAST_MOD_TIME != value)
				{
					_LAST_MOD_TIME = value;
					ChangeState();
				}
			}
		}
		public string LAST_MOD_USER_ID
		{
			get { return _LAST_MOD_USER_ID; }
			set
			{
				if (_LAST_MOD_USER_ID != value)
				{
					_LAST_MOD_USER_ID = value;
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
		public decimal? WhereDoc_sin_nbr { get; set; }
		private decimal? _whereDoc_sin_nbr;
		public decimal? WhereDoc_spec_cd { get; set; }
		private decimal? _whereDoc_spec_cd;
		public string WhereDoc_hosp_nbr { get; set; }
		private string _whereDoc_hosp_nbr;
		public string WhereDoc_name { get; set; }
		private string _whereDoc_name;
		public string WhereDoc_name_soundex { get; set; }
		private string _whereDoc_name_soundex;
		public string WhereDoc_inits { get; set; }
		private string _whereDoc_inits;
		public string WhereDoc_full_part_ind { get; set; }
		private string _whereDoc_full_part_ind;
		public decimal? WhereDoc_bank_nbr { get; set; }
		private decimal? _whereDoc_bank_nbr;
		public decimal? WhereDoc_bank_branch { get; set; }
		private decimal? _whereDoc_bank_branch;
		public string WhereDoc_bank_acct { get; set; }
		private string _whereDoc_bank_acct;
		public decimal? WhereDoc_date_fac_start { get; set; }
		private decimal? _whereDoc_date_fac_start;
		public decimal? WhereDoc_date_fac_term { get; set; }
		private decimal? _whereDoc_date_fac_term;
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
		public decimal? WhereDoc_spec_cd_2 { get; set; }
		private decimal? _whereDoc_spec_cd_2;
		public decimal? WhereDoc_spec_cd_3 { get; set; }
		private decimal? _whereDoc_spec_cd_3;
		public decimal? WhereDoc_ytdinc_g { get; set; }
		private decimal? _whereDoc_ytdinc_g;
		public string WhereDoc_locations { get; set; }
		private string _whereDoc_locations;
		public int? WhereDoc_rma_expense_percent_misc { get; set; }
		private int? _whereDoc_rma_expense_percent_misc;
		public string WhereDoc_afp_paym_group { get; set; }
		private string _whereDoc_afp_paym_group;
		public decimal? WhereDoc_dept_2 { get; set; }
		private decimal? _whereDoc_dept_2;
		public string WhereDoc_ind_pays_gst { get; set; }
		private string _whereDoc_ind_pays_gst;
		public decimal? WhereDoc_yrly_ceiling_computed { get; set; }
		private decimal? _whereDoc_yrly_ceiling_computed;
		public decimal? WhereDoc_yrly_expense_computed { get; set; }
		private decimal? _whereDoc_yrly_expense_computed;
		public int? WhereDoc_rma_expense_percent_reg { get; set; }
		private int? _whereDoc_rma_expense_percent_reg;
		public string WhereDoc_sub_specialty { get; set; }
		private string _whereDoc_sub_specialty;
		public decimal? WhereDoc_payeft { get; set; }
		private decimal? _whereDoc_payeft;
		public decimal? WhereDoc_ytdded { get; set; }
		private decimal? _whereDoc_ytdded;
		public int? WhereDoc_dept_expense_percent_misc { get; set; }
		private int? _whereDoc_dept_expense_percent_misc;
		public int? WhereDoc_dept_expense_percent_reg { get; set; }
		private int? _whereDoc_dept_expense_percent_reg;
		public decimal? WhereDoc_ep_ped { get; set; }
		private decimal? _whereDoc_ep_ped;
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
		public string WhereDoc_specialties { get; set; }
		private string _whereDoc_specialties;
		public decimal? WhereDoc_yrly_require_revenue { get; set; }
		private decimal? _whereDoc_yrly_require_revenue;
		public decimal? WhereDoc_yrly_target_revenue { get; set; }
		private decimal? _whereDoc_yrly_target_revenue;
		public decimal? WhereDoc_ceireq { get; set; }
		private decimal? _whereDoc_ceireq;
		public decimal? WhereDoc_ytdreq { get; set; }
		private decimal? _whereDoc_ytdreq;
		public decimal? WhereDoc_ceitar { get; set; }
		private decimal? _whereDoc_ceitar;
		public decimal? WhereDoc_ytdtar { get; set; }
		private decimal? _whereDoc_ytdtar;
		public string Wherevia_paper_flag { get; set; }
		private string _wherevia_paper_flag;
		public string Wherevia_diskette_flag { get; set; }
		private string _wherevia_diskette_flag;
		public string Wherevia_web_test_flag { get; set; }
		private string _wherevia_web_test_flag;
		public string Wherevia_web_live_flag { get; set; }
		private string _wherevia_web_live_flag;
		public string Wherevia_rma_data_entry { get; set; }
		private string _wherevia_rma_data_entry;
		public decimal? WhereDate_start_rma_data_entry { get; set; }
		private decimal? _whereDate_start_rma_data_entry;
		public decimal? WhereDate_start_diskette { get; set; }
		private decimal? _whereDate_start_diskette;
		public decimal? WhereDate_start_paper { get; set; }
		private decimal? _whereDate_start_paper;
		public decimal? WhereDate_start_web_live { get; set; }
		private decimal? _whereDate_start_web_live;
		public decimal? WhereDate_start_web_test { get; set; }
		private decimal? _whereDate_start_web_test;
		public string WhereLeave_description { get; set; }
		private string _whereLeave_description;
		public decimal? WhereLeave_date_start { get; set; }
		private decimal? _whereLeave_date_start;
		public decimal? WhereLeave_date_end { get; set; }
		private decimal? _whereLeave_date_end;
		public string WhereWeb_user_revenue_only_flag { get; set; }
		private string _whereWeb_user_revenue_only_flag;
		public string WhereManager_flag { get; set; }
		private string _whereManager_flag;
		public string WhereChair_flag { get; set; }
		private string _whereChair_flag;
		public string WhereAbe_user_flag { get; set; }
		private string _whereAbe_user_flag;
		public string WhereCpso_nbr { get; set; }
		private string _whereCpso_nbr;
		public string WhereCmpa_nbr { get; set; }
		private string _whereCmpa_nbr;
		public string WhereOma_nbr { get; set; }
		private string _whereOma_nbr;
		public string WhereCfpc_nbr { get; set; }
		private string _whereCfpc_nbr;
		public string WhereRcpsc_nbr { get; set; }
		private string _whereRcpsc_nbr;
		public string WhereDoc_med_prof_corp { get; set; }
		private string _whereDoc_med_prof_corp;
		public decimal? WhereMcmaster_employee_id { get; set; }
		private decimal? _whereMcmaster_employee_id;
		public decimal? WhereDoc_spec_cd_eff_date { get; set; }
		private decimal? _whereDoc_spec_cd_eff_date;
		public decimal? WhereDoc_spec_cd_2_eff_date { get; set; }
		private decimal? _whereDoc_spec_cd_2_eff_date;
		public decimal? WhereDoc_spec_cd_3_eff_date { get; set; }
		private decimal? _whereDoc_spec_cd_3_eff_date;
		public decimal? WhereFactor_gst_income_reg { get; set; }
		private decimal? _whereFactor_gst_income_reg;
		public decimal? WhereFactor_gst_income_misc { get; set; }
		private decimal? _whereFactor_gst_income_misc;
		public string WhereYellow_pages_flag { get; set; }
		private string _whereYellow_pages_flag;
		public string WhereReplaced_by_doc_nbr { get; set; }
		private string _whereReplaced_by_doc_nbr;
		public string WherePrior_doc_nbr { get; set; }
		private string _wherePrior_doc_nbr;
		public string WhereCop_nbr { get; set; }
		private string _whereCop_nbr;
		public string WhereDoc_flag_primary { get; set; }
		private string _whereDoc_flag_primary;
		public string WhereHas_valid_current_payroll_record { get; set; }
		private string _whereHas_valid_current_payroll_record;
		public string WherePay_this_doctor_ohip_premium { get; set; }
		private string _wherePay_this_doctor_ohip_premium;
		public decimal? WhereDoc_fiscal_yr_start_month { get; set; }
		private decimal? _whereDoc_fiscal_yr_start_month;
		public string WhereLast_mod_flag { get; set; }
		private string _whereLast_mod_flag;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_dept;
		private decimal? _originalDoc_ohip_nbr;
		private decimal? _originalDoc_sin_nbr;
		private decimal? _originalDoc_spec_cd;
		private string _originalDoc_hosp_nbr;
		private string _originalDoc_name;
		private string _originalDoc_name_soundex;
		private string _originalDoc_inits;
		private string _originalDoc_full_part_ind;
		private decimal? _originalDoc_bank_nbr;
		private decimal? _originalDoc_bank_branch;
		private string _originalDoc_bank_acct;
		private decimal? _originalDoc_date_fac_start;
		private decimal? _originalDoc_date_fac_term;
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
		private decimal? _originalDoc_spec_cd_2;
		private decimal? _originalDoc_spec_cd_3;
		private decimal? _originalDoc_ytdinc_g;
		private string _originalDoc_locations;
		private int? _originalDoc_rma_expense_percent_misc;
		private string _originalDoc_afp_paym_group;
		private decimal? _originalDoc_dept_2;
		private string _originalDoc_ind_pays_gst;
		private decimal? _originalDoc_yrly_ceiling_computed;
		private decimal? _originalDoc_yrly_expense_computed;
		private int? _originalDoc_rma_expense_percent_reg;
		private string _originalDoc_sub_specialty;
		private decimal? _originalDoc_payeft;
		private decimal? _originalDoc_ytdded;
		private int? _originalDoc_dept_expense_percent_misc;
		private int? _originalDoc_dept_expense_percent_reg;
		private decimal? _originalDoc_ep_ped;
		private string _originalDoc_ep_pay_code;
		private string _originalDoc_ep_pay_sub_code;
		private string _originalDoc_partnership;
		private string _originalDoc_ind_holdback_active;
		private string _originalGroup_regular_service;
		private string _originalGroup_over_serviced;
		private string _originalDoc_specialties;
		private decimal? _originalDoc_yrly_require_revenue;
		private decimal? _originalDoc_yrly_target_revenue;
		private decimal? _originalDoc_ceireq;
		private decimal? _originalDoc_ytdreq;
		private decimal? _originalDoc_ceitar;
		private decimal? _originalDoc_ytdtar;
		private string _originalvia_paper_flag;
		private string _originalvia_diskette_flag;
		private string _originalvia_web_test_flag;
		private string _originalvia_web_live_flag;
		private string _originalvia_rma_data_entry;
		private decimal? _originalDate_start_rma_data_entry;
		private decimal? _originalDate_start_diskette;
		private decimal? _originalDate_start_paper;
		private decimal? _originalDate_start_web_live;
		private decimal? _originalDate_start_web_test;
		private string _originalLeave_description;
		private decimal? _originalLeave_date_start;
		private decimal? _originalLeave_date_end;
		private string _originalWeb_user_revenue_only_flag;
		private string _originalManager_flag;
		private string _originalChair_flag;
		private string _originalAbe_user_flag;
		private string _originalCpso_nbr;
		private string _originalCmpa_nbr;
		private string _originalOma_nbr;
		private string _originalCfpc_nbr;
		private string _originalRcpsc_nbr;
		private string _originalDoc_med_prof_corp;
		private decimal? _originalMcmaster_employee_id;
		private decimal? _originalDoc_spec_cd_eff_date;
		private decimal? _originalDoc_spec_cd_2_eff_date;
		private decimal? _originalDoc_spec_cd_3_eff_date;
		private decimal? _originalFactor_gst_income_reg;
		private decimal? _originalFactor_gst_income_misc;
		private string _originalYellow_pages_flag;
		private string _originalReplaced_by_doc_nbr;
		private string _originalPrior_doc_nbr;
		private string _originalCop_nbr;
		private string _originalDoc_flag_primary;
		private string _originalHas_valid_current_payroll_record;
		private string _originalPay_this_doctor_ohip_premium;
		private decimal? _originalDoc_fiscal_yr_start_month;
		private string _originalLast_mod_flag;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
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
			DOC_SIN_NBR = _originalDoc_sin_nbr;
			DOC_SPEC_CD = _originalDoc_spec_cd;
			DOC_HOSP_NBR = _originalDoc_hosp_nbr;
			DOC_NAME = _originalDoc_name;
			DOC_NAME_SOUNDEX = _originalDoc_name_soundex;
			DOC_INITS = _originalDoc_inits;
			DOC_FULL_PART_IND = _originalDoc_full_part_ind;
			DOC_BANK_NBR = _originalDoc_bank_nbr;
			DOC_BANK_BRANCH = _originalDoc_bank_branch;
			DOC_BANK_ACCT = _originalDoc_bank_acct;
			DOC_DATE_FAC_START = _originalDoc_date_fac_start;
			DOC_DATE_FAC_TERM = _originalDoc_date_fac_term;
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
			DOC_SPEC_CD_2 = _originalDoc_spec_cd_2;
			DOC_SPEC_CD_3 = _originalDoc_spec_cd_3;
			DOC_YTDINC_G = _originalDoc_ytdinc_g;
			DOC_LOCATIONS = _originalDoc_locations;
			DOC_RMA_EXPENSE_PERCENT_MISC = _originalDoc_rma_expense_percent_misc;
			DOC_AFP_PAYM_GROUP = _originalDoc_afp_paym_group;
			DOC_DEPT_2 = _originalDoc_dept_2;
			DOC_IND_PAYS_GST = _originalDoc_ind_pays_gst;
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
			DOC_SPECIALTIES = _originalDoc_specialties;
			DOC_YRLY_REQUIRE_REVENUE = _originalDoc_yrly_require_revenue;
			DOC_YRLY_TARGET_REVENUE = _originalDoc_yrly_target_revenue;
			DOC_CEIREQ = _originalDoc_ceireq;
			DOC_YTDREQ = _originalDoc_ytdreq;
			DOC_CEITAR = _originalDoc_ceitar;
			DOC_YTDTAR = _originalDoc_ytdtar;
			BILLING_VIA_PAPER_FLAG = _originalvia_paper_flag;
			BILLING_VIA_DISKETTE_FLAG = _originalvia_diskette_flag;
			BILLING_VIA_WEB_TEST_FLAG = _originalvia_web_test_flag;
			BILLING_VIA_WEB_LIVE_FLAG = _originalvia_web_live_flag;
			BILLING_VIA_RMA_DATA_ENTRY = _originalvia_rma_data_entry;
			DATE_START_RMA_DATA_ENTRY = _originalDate_start_rma_data_entry;
			DATE_START_DISKETTE = _originalDate_start_diskette;
			DATE_START_PAPER = _originalDate_start_paper;
			DATE_START_WEB_LIVE = _originalDate_start_web_live;
			DATE_START_WEB_TEST = _originalDate_start_web_test;
			LEAVE_DESCRIPTION = _originalLeave_description;
			LEAVE_DATE_START = _originalLeave_date_start;
			LEAVE_DATE_END = _originalLeave_date_end;
			WEB_USER_REVENUE_ONLY_FLAG = _originalWeb_user_revenue_only_flag;
			MANAGER_FLAG = _originalManager_flag;
			CHAIR_FLAG = _originalChair_flag;
			ABE_USER_FLAG = _originalAbe_user_flag;
			CPSO_NBR = _originalCpso_nbr;
			CMPA_NBR = _originalCmpa_nbr;
			OMA_NBR = _originalOma_nbr;
			CFPC_NBR = _originalCfpc_nbr;
			RCPSC_NBR = _originalRcpsc_nbr;
			DOC_MED_PROF_CORP = _originalDoc_med_prof_corp;
			MCMASTER_EMPLOYEE_ID = _originalMcmaster_employee_id;
			DOC_SPEC_CD_EFF_DATE = _originalDoc_spec_cd_eff_date;
			DOC_SPEC_CD_2_EFF_DATE = _originalDoc_spec_cd_2_eff_date;
			DOC_SPEC_CD_3_EFF_DATE = _originalDoc_spec_cd_3_eff_date;
			FACTOR_GST_INCOME_REG = _originalFactor_gst_income_reg;
			FACTOR_GST_INCOME_MISC = _originalFactor_gst_income_misc;
			YELLOW_PAGES_FLAG = _originalYellow_pages_flag;
			REPLACED_BY_DOC_NBR = _originalReplaced_by_doc_nbr;
			PRIOR_DOC_NBR = _originalPrior_doc_nbr;
			COP_NBR = _originalCop_nbr;
			DOC_FLAG_PRIMARY = _originalDoc_flag_primary;
			HAS_VALID_CURRENT_PAYROLL_RECORD = _originalHas_valid_current_payroll_record;
			PAY_THIS_DOCTOR_OHIP_PREMIUM = _originalPay_this_doctor_ohip_premium;
			DOC_FISCAL_YR_START_MONTH = _originalDoc_fiscal_yr_start_month;
			LAST_MOD_FLAG = _originalLast_mod_flag;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_Purge]");
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
						new SqlParameter("DOC_SIN_NBR", SqlNull(DOC_SIN_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("DOC_HOSP_NBR", SqlNull(DOC_HOSP_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_NAME_SOUNDEX", SqlNull(DOC_NAME_SOUNDEX)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
						new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
						new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
						new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
						new SqlParameter("DOC_DATE_FAC_START", SqlNull(DOC_DATE_FAC_START)),
						new SqlParameter("DOC_DATE_FAC_TERM", SqlNull(DOC_DATE_FAC_TERM)),
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
						new SqlParameter("DOC_SPEC_CD_2", SqlNull(DOC_SPEC_CD_2)),
						new SqlParameter("DOC_SPEC_CD_3", SqlNull(DOC_SPEC_CD_3)),
						new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
						new SqlParameter("DOC_LOCATIONS", SqlNull(DOC_LOCATIONS)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_DEPT_2", SqlNull(DOC_DEPT_2)),
						new SqlParameter("DOC_IND_PAYS_GST", SqlNull(DOC_IND_PAYS_GST)),
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
						new SqlParameter("DOC_SPECIALTIES", SqlNull(DOC_SPECIALTIES)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("BILLING_VIA_PAPER_FLAG", SqlNull(BILLING_VIA_PAPER_FLAG)),
						new SqlParameter("BILLING_VIA_DISKETTE_FLAG", SqlNull(BILLING_VIA_DISKETTE_FLAG)),
						new SqlParameter("BILLING_VIA_WEB_TEST_FLAG", SqlNull(BILLING_VIA_WEB_TEST_FLAG)),
						new SqlParameter("BILLING_VIA_WEB_LIVE_FLAG", SqlNull(BILLING_VIA_WEB_LIVE_FLAG)),
						new SqlParameter("BILLING_VIA_RMA_DATA_ENTRY", SqlNull(BILLING_VIA_RMA_DATA_ENTRY)),
						new SqlParameter("DATE_START_RMA_DATA_ENTRY", SqlNull(DATE_START_RMA_DATA_ENTRY)),
						new SqlParameter("DATE_START_DISKETTE", SqlNull(DATE_START_DISKETTE)),
						new SqlParameter("DATE_START_PAPER", SqlNull(DATE_START_PAPER)),
						new SqlParameter("DATE_START_WEB_LIVE", SqlNull(DATE_START_WEB_LIVE)),
						new SqlParameter("DATE_START_WEB_TEST", SqlNull(DATE_START_WEB_TEST)),
						new SqlParameter("LEAVE_DESCRIPTION", SqlNull(LEAVE_DESCRIPTION)),
						new SqlParameter("LEAVE_DATE_START", SqlNull(LEAVE_DATE_START)),
						new SqlParameter("LEAVE_DATE_END", SqlNull(LEAVE_DATE_END)),
						new SqlParameter("WEB_USER_REVENUE_ONLY_FLAG", SqlNull(WEB_USER_REVENUE_ONLY_FLAG)),
						new SqlParameter("MANAGER_FLAG", SqlNull(MANAGER_FLAG)),
						new SqlParameter("CHAIR_FLAG", SqlNull(CHAIR_FLAG)),
						new SqlParameter("ABE_USER_FLAG", SqlNull(ABE_USER_FLAG)),
						new SqlParameter("CPSO_NBR", SqlNull(CPSO_NBR)),
						new SqlParameter("CMPA_NBR", SqlNull(CMPA_NBR)),
						new SqlParameter("OMA_NBR", SqlNull(OMA_NBR)),
						new SqlParameter("CFPC_NBR", SqlNull(CFPC_NBR)),
						new SqlParameter("RCPSC_NBR", SqlNull(RCPSC_NBR)),
						new SqlParameter("DOC_MED_PROF_CORP", SqlNull(DOC_MED_PROF_CORP)),
						new SqlParameter("MCMASTER_EMPLOYEE_ID", SqlNull(MCMASTER_EMPLOYEE_ID)),
						new SqlParameter("DOC_SPEC_CD_EFF_DATE", SqlNull(DOC_SPEC_CD_EFF_DATE)),
						new SqlParameter("DOC_SPEC_CD_2_EFF_DATE", SqlNull(DOC_SPEC_CD_2_EFF_DATE)),
						new SqlParameter("DOC_SPEC_CD_3_EFF_DATE", SqlNull(DOC_SPEC_CD_3_EFF_DATE)),
						new SqlParameter("FACTOR_GST_INCOME_REG", SqlNull(FACTOR_GST_INCOME_REG)),
						new SqlParameter("FACTOR_GST_INCOME_MISC", SqlNull(FACTOR_GST_INCOME_MISC)),
						new SqlParameter("YELLOW_PAGES_FLAG", SqlNull(YELLOW_PAGES_FLAG)),
						new SqlParameter("REPLACED_BY_DOC_NBR", SqlNull(REPLACED_BY_DOC_NBR)),
						new SqlParameter("PRIOR_DOC_NBR", SqlNull(PRIOR_DOC_NBR)),
						new SqlParameter("COP_NBR", SqlNull(COP_NBR)),
						new SqlParameter("DOC_FLAG_PRIMARY", SqlNull(DOC_FLAG_PRIMARY)),
						new SqlParameter("HAS_VALID_CURRENT_PAYROLL_RECORD", SqlNull(HAS_VALID_CURRENT_PAYROLL_RECORD)),
						new SqlParameter("PAY_THIS_DOCTOR_OHIP_PREMIUM", SqlNull(PAY_THIS_DOCTOR_OHIP_PREMIUM)),
						new SqlParameter("DOC_FISCAL_YR_START_MONTH", SqlNull(DOC_FISCAL_YR_START_MONTH)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
						DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
						DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
						DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
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
						DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
						DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
						DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
						DOC_LOCATIONS = Reader["DOC_LOCATIONS"].ToString();
						DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
						DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString();
						DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
						DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						DOC_EP_PED = ConvertDEC(Reader["DOC_EP_PED"]);
						DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
						DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString();
						DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
						GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString();
						GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString();
						DOC_SPECIALTIES = Reader["DOC_SPECIALTIES"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						BILLING_VIA_PAPER_FLAG = Reader["BILLING_VIA_PAPER_FLAG"].ToString();
						BILLING_VIA_DISKETTE_FLAG = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString();
						BILLING_VIA_WEB_TEST_FLAG = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString();
						BILLING_VIA_WEB_LIVE_FLAG = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString();
						BILLING_VIA_RMA_DATA_ENTRY = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString();
						DATE_START_RMA_DATA_ENTRY = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]);
						DATE_START_DISKETTE = ConvertDEC(Reader["DATE_START_DISKETTE"]);
						DATE_START_PAPER = ConvertDEC(Reader["DATE_START_PAPER"]);
						DATE_START_WEB_LIVE = ConvertDEC(Reader["DATE_START_WEB_LIVE"]);
						DATE_START_WEB_TEST = ConvertDEC(Reader["DATE_START_WEB_TEST"]);
						LEAVE_DESCRIPTION = Reader["LEAVE_DESCRIPTION"].ToString();
						LEAVE_DATE_START = ConvertDEC(Reader["LEAVE_DATE_START"]);
						LEAVE_DATE_END = ConvertDEC(Reader["LEAVE_DATE_END"]);
						WEB_USER_REVENUE_ONLY_FLAG = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString();
						MANAGER_FLAG = Reader["MANAGER_FLAG"].ToString();
						CHAIR_FLAG = Reader["CHAIR_FLAG"].ToString();
						ABE_USER_FLAG = Reader["ABE_USER_FLAG"].ToString();
						CPSO_NBR = Reader["CPSO_NBR"].ToString();
						CMPA_NBR = Reader["CMPA_NBR"].ToString();
						OMA_NBR = Reader["OMA_NBR"].ToString();
						CFPC_NBR = Reader["CFPC_NBR"].ToString();
						RCPSC_NBR = Reader["RCPSC_NBR"].ToString();
						DOC_MED_PROF_CORP = Reader["DOC_MED_PROF_CORP"].ToString();
						MCMASTER_EMPLOYEE_ID = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]);
						DOC_SPEC_CD_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]);
						DOC_SPEC_CD_2_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]);
						DOC_SPEC_CD_3_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]);
						FACTOR_GST_INCOME_REG = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]);
						FACTOR_GST_INCOME_MISC = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]);
						YELLOW_PAGES_FLAG = Reader["YELLOW_PAGES_FLAG"].ToString();
						REPLACED_BY_DOC_NBR = Reader["REPLACED_BY_DOC_NBR"].ToString();
						PRIOR_DOC_NBR = Reader["PRIOR_DOC_NBR"].ToString();
						COP_NBR = Reader["COP_NBR"].ToString();
						DOC_FLAG_PRIMARY = Reader["DOC_FLAG_PRIMARY"].ToString();
						HAS_VALID_CURRENT_PAYROLL_RECORD = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString();
						PAY_THIS_DOCTOR_OHIP_PREMIUM = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString();
						DOC_FISCAL_YR_START_MONTH = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
						_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
						_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
						_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
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
						_originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
						_originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
						_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
						_originalDoc_locations = Reader["DOC_LOCATIONS"].ToString();
						_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
						_originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						_originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString();
						_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
						_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
						_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						_originalDoc_ep_ped = ConvertDEC(Reader["DOC_EP_PED"]);
						_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
						_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						_originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString();
						_originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
						_originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString();
						_originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString();
						_originalDoc_specialties = Reader["DOC_SPECIALTIES"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalvia_paper_flag = Reader["BILLING_VIA_PAPER_FLAG"].ToString();
						_originalvia_diskette_flag = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString();
						_originalvia_web_test_flag = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString();
						_originalvia_web_live_flag = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString();
						_originalvia_rma_data_entry = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString();
						_originalDate_start_rma_data_entry = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]);
						_originalDate_start_diskette = ConvertDEC(Reader["DATE_START_DISKETTE"]);
						_originalDate_start_paper = ConvertDEC(Reader["DATE_START_PAPER"]);
						_originalDate_start_web_live = ConvertDEC(Reader["DATE_START_WEB_LIVE"]);
						_originalDate_start_web_test = ConvertDEC(Reader["DATE_START_WEB_TEST"]);
						_originalLeave_description = Reader["LEAVE_DESCRIPTION"].ToString();
						_originalLeave_date_start = ConvertDEC(Reader["LEAVE_DATE_START"]);
						_originalLeave_date_end = ConvertDEC(Reader["LEAVE_DATE_END"]);
						_originalWeb_user_revenue_only_flag = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString();
						_originalManager_flag = Reader["MANAGER_FLAG"].ToString();
						_originalChair_flag = Reader["CHAIR_FLAG"].ToString();
						_originalAbe_user_flag = Reader["ABE_USER_FLAG"].ToString();
						_originalCpso_nbr = Reader["CPSO_NBR"].ToString();
						_originalCmpa_nbr = Reader["CMPA_NBR"].ToString();
						_originalOma_nbr = Reader["OMA_NBR"].ToString();
						_originalCfpc_nbr = Reader["CFPC_NBR"].ToString();
						_originalRcpsc_nbr = Reader["RCPSC_NBR"].ToString();
						_originalDoc_med_prof_corp = Reader["DOC_MED_PROF_CORP"].ToString();
						_originalMcmaster_employee_id = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]);
						_originalDoc_spec_cd_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]);
						_originalDoc_spec_cd_2_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]);
						_originalDoc_spec_cd_3_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]);
						_originalFactor_gst_income_reg = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]);
						_originalFactor_gst_income_misc = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]);
						_originalYellow_pages_flag = Reader["YELLOW_PAGES_FLAG"].ToString();
						_originalReplaced_by_doc_nbr = Reader["REPLACED_BY_DOC_NBR"].ToString();
						_originalPrior_doc_nbr = Reader["PRIOR_DOC_NBR"].ToString();
						_originalCop_nbr = Reader["COP_NBR"].ToString();
						_originalDoc_flag_primary = Reader["DOC_FLAG_PRIMARY"].ToString();
						_originalHas_valid_current_payroll_record = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString();
						_originalPay_this_doctor_ohip_premium = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString();
						_originalDoc_fiscal_yr_start_month = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]);
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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
						new SqlParameter("DOC_SIN_NBR", SqlNull(DOC_SIN_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("DOC_HOSP_NBR", SqlNull(DOC_HOSP_NBR)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_NAME_SOUNDEX", SqlNull(DOC_NAME_SOUNDEX)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
						new SqlParameter("DOC_BANK_NBR", SqlNull(DOC_BANK_NBR)),
						new SqlParameter("DOC_BANK_BRANCH", SqlNull(DOC_BANK_BRANCH)),
						new SqlParameter("DOC_BANK_ACCT", SqlNull(DOC_BANK_ACCT)),
						new SqlParameter("DOC_DATE_FAC_START", SqlNull(DOC_DATE_FAC_START)),
						new SqlParameter("DOC_DATE_FAC_TERM", SqlNull(DOC_DATE_FAC_TERM)),
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
						new SqlParameter("DOC_SPEC_CD_2", SqlNull(DOC_SPEC_CD_2)),
						new SqlParameter("DOC_SPEC_CD_3", SqlNull(DOC_SPEC_CD_3)),
						new SqlParameter("DOC_YTDINC_G", SqlNull(DOC_YTDINC_G)),
						new SqlParameter("DOC_LOCATIONS", SqlNull(DOC_LOCATIONS)),
						new SqlParameter("DOC_RMA_EXPENSE_PERCENT_MISC", SqlNull(DOC_RMA_EXPENSE_PERCENT_MISC)),
						new SqlParameter("DOC_AFP_PAYM_GROUP", SqlNull(DOC_AFP_PAYM_GROUP)),
						new SqlParameter("DOC_DEPT_2", SqlNull(DOC_DEPT_2)),
						new SqlParameter("DOC_IND_PAYS_GST", SqlNull(DOC_IND_PAYS_GST)),
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
						new SqlParameter("DOC_SPECIALTIES", SqlNull(DOC_SPECIALTIES)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("BILLING_VIA_PAPER_FLAG", SqlNull(BILLING_VIA_PAPER_FLAG)),
						new SqlParameter("BILLING_VIA_DISKETTE_FLAG", SqlNull(BILLING_VIA_DISKETTE_FLAG)),
						new SqlParameter("BILLING_VIA_WEB_TEST_FLAG", SqlNull(BILLING_VIA_WEB_TEST_FLAG)),
						new SqlParameter("BILLING_VIA_WEB_LIVE_FLAG", SqlNull(BILLING_VIA_WEB_LIVE_FLAG)),
						new SqlParameter("BILLING_VIA_RMA_DATA_ENTRY", SqlNull(BILLING_VIA_RMA_DATA_ENTRY)),
						new SqlParameter("DATE_START_RMA_DATA_ENTRY", SqlNull(DATE_START_RMA_DATA_ENTRY)),
						new SqlParameter("DATE_START_DISKETTE", SqlNull(DATE_START_DISKETTE)),
						new SqlParameter("DATE_START_PAPER", SqlNull(DATE_START_PAPER)),
						new SqlParameter("DATE_START_WEB_LIVE", SqlNull(DATE_START_WEB_LIVE)),
						new SqlParameter("DATE_START_WEB_TEST", SqlNull(DATE_START_WEB_TEST)),
						new SqlParameter("LEAVE_DESCRIPTION", SqlNull(LEAVE_DESCRIPTION)),
						new SqlParameter("LEAVE_DATE_START", SqlNull(LEAVE_DATE_START)),
						new SqlParameter("LEAVE_DATE_END", SqlNull(LEAVE_DATE_END)),
						new SqlParameter("WEB_USER_REVENUE_ONLY_FLAG", SqlNull(WEB_USER_REVENUE_ONLY_FLAG)),
						new SqlParameter("MANAGER_FLAG", SqlNull(MANAGER_FLAG)),
						new SqlParameter("CHAIR_FLAG", SqlNull(CHAIR_FLAG)),
						new SqlParameter("ABE_USER_FLAG", SqlNull(ABE_USER_FLAG)),
						new SqlParameter("CPSO_NBR", SqlNull(CPSO_NBR)),
						new SqlParameter("CMPA_NBR", SqlNull(CMPA_NBR)),
						new SqlParameter("OMA_NBR", SqlNull(OMA_NBR)),
						new SqlParameter("CFPC_NBR", SqlNull(CFPC_NBR)),
						new SqlParameter("RCPSC_NBR", SqlNull(RCPSC_NBR)),
						new SqlParameter("DOC_MED_PROF_CORP", SqlNull(DOC_MED_PROF_CORP)),
						new SqlParameter("MCMASTER_EMPLOYEE_ID", SqlNull(MCMASTER_EMPLOYEE_ID)),
						new SqlParameter("DOC_SPEC_CD_EFF_DATE", SqlNull(DOC_SPEC_CD_EFF_DATE)),
						new SqlParameter("DOC_SPEC_CD_2_EFF_DATE", SqlNull(DOC_SPEC_CD_2_EFF_DATE)),
						new SqlParameter("DOC_SPEC_CD_3_EFF_DATE", SqlNull(DOC_SPEC_CD_3_EFF_DATE)),
						new SqlParameter("FACTOR_GST_INCOME_REG", SqlNull(FACTOR_GST_INCOME_REG)),
						new SqlParameter("FACTOR_GST_INCOME_MISC", SqlNull(FACTOR_GST_INCOME_MISC)),
						new SqlParameter("YELLOW_PAGES_FLAG", SqlNull(YELLOW_PAGES_FLAG)),
						new SqlParameter("REPLACED_BY_DOC_NBR", SqlNull(REPLACED_BY_DOC_NBR)),
						new SqlParameter("PRIOR_DOC_NBR", SqlNull(PRIOR_DOC_NBR)),
						new SqlParameter("COP_NBR", SqlNull(COP_NBR)),
						new SqlParameter("DOC_FLAG_PRIMARY", SqlNull(DOC_FLAG_PRIMARY)),
						new SqlParameter("HAS_VALID_CURRENT_PAYROLL_RECORD", SqlNull(HAS_VALID_CURRENT_PAYROLL_RECORD)),
						new SqlParameter("PAY_THIS_DOCTOR_OHIP_PREMIUM", SqlNull(PAY_THIS_DOCTOR_OHIP_PREMIUM)),
						new SqlParameter("DOC_FISCAL_YR_START_MONTH", SqlNull(DOC_FISCAL_YR_START_MONTH)),
						new SqlParameter("LAST_MOD_FLAG", SqlNull(LAST_MOD_FLAG)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_F020_DOCTOR_AUDIT_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						DOC_HOSP_NBR = Reader["DOC_HOSP_NBR"].ToString();
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_NAME_SOUNDEX = Reader["DOC_NAME_SOUNDEX"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
						DOC_BANK_NBR = ConvertDEC(Reader["DOC_BANK_NBR"]);
						DOC_BANK_BRANCH = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						DOC_BANK_ACCT = Reader["DOC_BANK_ACCT"].ToString();
						DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
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
						DOC_SPEC_CD_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
						DOC_SPEC_CD_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
						DOC_YTDINC_G = ConvertDEC(Reader["DOC_YTDINC_G"]);
						DOC_LOCATIONS = Reader["DOC_LOCATIONS"].ToString();
						DOC_RMA_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						DOC_AFP_PAYM_GROUP = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						DOC_DEPT_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
						DOC_IND_PAYS_GST = Reader["DOC_IND_PAYS_GST"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_YRLY_EXPENSE_COMPUTED = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						DOC_RMA_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						DOC_SUB_SPECIALTY = Reader["DOC_SUB_SPECIALTY"].ToString();
						DOC_PAYEFT = ConvertDEC(Reader["DOC_PAYEFT"]);
						DOC_YTDDED = ConvertDEC(Reader["DOC_YTDDED"]);
						DOC_DEPT_EXPENSE_PERCENT_MISC = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						DOC_DEPT_EXPENSE_PERCENT_REG = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						DOC_EP_PED = ConvertDEC(Reader["DOC_EP_PED"]);
						DOC_EP_PAY_CODE = Reader["DOC_EP_PAY_CODE"].ToString();
						DOC_EP_PAY_SUB_CODE = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						DOC_PARTNERSHIP = Reader["DOC_PARTNERSHIP"].ToString();
						DOC_IND_HOLDBACK_ACTIVE = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
						GROUP_REGULAR_SERVICE = Reader["GROUP_REGULAR_SERVICE"].ToString();
						GROUP_OVER_SERVICED = Reader["GROUP_OVER_SERVICED"].ToString();
						DOC_SPECIALTIES = Reader["DOC_SPECIALTIES"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						BILLING_VIA_PAPER_FLAG = Reader["BILLING_VIA_PAPER_FLAG"].ToString();
						BILLING_VIA_DISKETTE_FLAG = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString();
						BILLING_VIA_WEB_TEST_FLAG = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString();
						BILLING_VIA_WEB_LIVE_FLAG = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString();
						BILLING_VIA_RMA_DATA_ENTRY = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString();
						DATE_START_RMA_DATA_ENTRY = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]);
						DATE_START_DISKETTE = ConvertDEC(Reader["DATE_START_DISKETTE"]);
						DATE_START_PAPER = ConvertDEC(Reader["DATE_START_PAPER"]);
						DATE_START_WEB_LIVE = ConvertDEC(Reader["DATE_START_WEB_LIVE"]);
						DATE_START_WEB_TEST = ConvertDEC(Reader["DATE_START_WEB_TEST"]);
						LEAVE_DESCRIPTION = Reader["LEAVE_DESCRIPTION"].ToString();
						LEAVE_DATE_START = ConvertDEC(Reader["LEAVE_DATE_START"]);
						LEAVE_DATE_END = ConvertDEC(Reader["LEAVE_DATE_END"]);
						WEB_USER_REVENUE_ONLY_FLAG = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString();
						MANAGER_FLAG = Reader["MANAGER_FLAG"].ToString();
						CHAIR_FLAG = Reader["CHAIR_FLAG"].ToString();
						ABE_USER_FLAG = Reader["ABE_USER_FLAG"].ToString();
						CPSO_NBR = Reader["CPSO_NBR"].ToString();
						CMPA_NBR = Reader["CMPA_NBR"].ToString();
						OMA_NBR = Reader["OMA_NBR"].ToString();
						CFPC_NBR = Reader["CFPC_NBR"].ToString();
						RCPSC_NBR = Reader["RCPSC_NBR"].ToString();
						DOC_MED_PROF_CORP = Reader["DOC_MED_PROF_CORP"].ToString();
						MCMASTER_EMPLOYEE_ID = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]);
						DOC_SPEC_CD_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]);
						DOC_SPEC_CD_2_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]);
						DOC_SPEC_CD_3_EFF_DATE = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]);
						FACTOR_GST_INCOME_REG = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]);
						FACTOR_GST_INCOME_MISC = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]);
						YELLOW_PAGES_FLAG = Reader["YELLOW_PAGES_FLAG"].ToString();
						REPLACED_BY_DOC_NBR = Reader["REPLACED_BY_DOC_NBR"].ToString();
						PRIOR_DOC_NBR = Reader["PRIOR_DOC_NBR"].ToString();
						COP_NBR = Reader["COP_NBR"].ToString();
						DOC_FLAG_PRIMARY = Reader["DOC_FLAG_PRIMARY"].ToString();
						HAS_VALID_CURRENT_PAYROLL_RECORD = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString();
						PAY_THIS_DOCTOR_OHIP_PREMIUM = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString();
						DOC_FISCAL_YR_START_MONTH = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]);
						LAST_MOD_FLAG = Reader["LAST_MOD_FLAG"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalDoc_hosp_nbr = Reader["DOC_HOSP_NBR"].ToString();
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_name_soundex = Reader["DOC_NAME_SOUNDEX"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
						_originalDoc_bank_nbr = ConvertDEC(Reader["DOC_BANK_NBR"]);
						_originalDoc_bank_branch = ConvertDEC(Reader["DOC_BANK_BRANCH"]);
						_originalDoc_bank_acct = Reader["DOC_BANK_ACCT"].ToString();
						_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
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
						_originalDoc_spec_cd_2 = ConvertDEC(Reader["DOC_SPEC_CD_2"]);
						_originalDoc_spec_cd_3 = ConvertDEC(Reader["DOC_SPEC_CD_3"]);
						_originalDoc_ytdinc_g = ConvertDEC(Reader["DOC_YTDINC_G"]);
						_originalDoc_locations = Reader["DOC_LOCATIONS"].ToString();
						_originalDoc_rma_expense_percent_misc = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_MISC"]);
						_originalDoc_afp_paym_group = Reader["DOC_AFP_PAYM_GROUP"].ToString();
						_originalDoc_dept_2 = ConvertDEC(Reader["DOC_DEPT_2"]);
						_originalDoc_ind_pays_gst = Reader["DOC_IND_PAYS_GST"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_yrly_expense_computed = ConvertDEC(Reader["DOC_YRLY_EXPENSE_COMPUTED"]);
						_originalDoc_rma_expense_percent_reg = ConvertINT(Reader["DOC_RMA_EXPENSE_PERCENT_REG"]);
						_originalDoc_sub_specialty = Reader["DOC_SUB_SPECIALTY"].ToString();
						_originalDoc_payeft = ConvertDEC(Reader["DOC_PAYEFT"]);
						_originalDoc_ytdded = ConvertDEC(Reader["DOC_YTDDED"]);
						_originalDoc_dept_expense_percent_misc = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_MISC"]);
						_originalDoc_dept_expense_percent_reg = ConvertINT(Reader["DOC_DEPT_EXPENSE_PERCENT_REG"]);
						_originalDoc_ep_ped = ConvertDEC(Reader["DOC_EP_PED"]);
						_originalDoc_ep_pay_code = Reader["DOC_EP_PAY_CODE"].ToString();
						_originalDoc_ep_pay_sub_code = Reader["DOC_EP_PAY_SUB_CODE"].ToString();
						_originalDoc_partnership = Reader["DOC_PARTNERSHIP"].ToString();
						_originalDoc_ind_holdback_active = Reader["DOC_IND_HOLDBACK_ACTIVE"].ToString();
						_originalGroup_regular_service = Reader["GROUP_REGULAR_SERVICE"].ToString();
						_originalGroup_over_serviced = Reader["GROUP_OVER_SERVICED"].ToString();
						_originalDoc_specialties = Reader["DOC_SPECIALTIES"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalvia_paper_flag = Reader["BILLING_VIA_PAPER_FLAG"].ToString();
						_originalvia_diskette_flag = Reader["BILLING_VIA_DISKETTE_FLAG"].ToString();
						_originalvia_web_test_flag = Reader["BILLING_VIA_WEB_TEST_FLAG"].ToString();
						_originalvia_web_live_flag = Reader["BILLING_VIA_WEB_LIVE_FLAG"].ToString();
						_originalvia_rma_data_entry = Reader["BILLING_VIA_RMA_DATA_ENTRY"].ToString();
						_originalDate_start_rma_data_entry = ConvertDEC(Reader["DATE_START_RMA_DATA_ENTRY"]);
						_originalDate_start_diskette = ConvertDEC(Reader["DATE_START_DISKETTE"]);
						_originalDate_start_paper = ConvertDEC(Reader["DATE_START_PAPER"]);
						_originalDate_start_web_live = ConvertDEC(Reader["DATE_START_WEB_LIVE"]);
						_originalDate_start_web_test = ConvertDEC(Reader["DATE_START_WEB_TEST"]);
						_originalLeave_description = Reader["LEAVE_DESCRIPTION"].ToString();
						_originalLeave_date_start = ConvertDEC(Reader["LEAVE_DATE_START"]);
						_originalLeave_date_end = ConvertDEC(Reader["LEAVE_DATE_END"]);
						_originalWeb_user_revenue_only_flag = Reader["WEB_USER_REVENUE_ONLY_FLAG"].ToString();
						_originalManager_flag = Reader["MANAGER_FLAG"].ToString();
						_originalChair_flag = Reader["CHAIR_FLAG"].ToString();
						_originalAbe_user_flag = Reader["ABE_USER_FLAG"].ToString();
						_originalCpso_nbr = Reader["CPSO_NBR"].ToString();
						_originalCmpa_nbr = Reader["CMPA_NBR"].ToString();
						_originalOma_nbr = Reader["OMA_NBR"].ToString();
						_originalCfpc_nbr = Reader["CFPC_NBR"].ToString();
						_originalRcpsc_nbr = Reader["RCPSC_NBR"].ToString();
						_originalDoc_med_prof_corp = Reader["DOC_MED_PROF_CORP"].ToString();
						_originalMcmaster_employee_id = ConvertDEC(Reader["MCMASTER_EMPLOYEE_ID"]);
						_originalDoc_spec_cd_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_EFF_DATE"]);
						_originalDoc_spec_cd_2_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_2_EFF_DATE"]);
						_originalDoc_spec_cd_3_eff_date = ConvertDEC(Reader["DOC_SPEC_CD_3_EFF_DATE"]);
						_originalFactor_gst_income_reg = ConvertDEC(Reader["FACTOR_GST_INCOME_REG"]);
						_originalFactor_gst_income_misc = ConvertDEC(Reader["FACTOR_GST_INCOME_MISC"]);
						_originalYellow_pages_flag = Reader["YELLOW_PAGES_FLAG"].ToString();
						_originalReplaced_by_doc_nbr = Reader["REPLACED_BY_DOC_NBR"].ToString();
						_originalPrior_doc_nbr = Reader["PRIOR_DOC_NBR"].ToString();
						_originalCop_nbr = Reader["COP_NBR"].ToString();
						_originalDoc_flag_primary = Reader["DOC_FLAG_PRIMARY"].ToString();
						_originalHas_valid_current_payroll_record = Reader["HAS_VALID_CURRENT_PAYROLL_RECORD"].ToString();
						_originalPay_this_doctor_ohip_premium = Reader["PAY_THIS_DOCTOR_OHIP_PREMIUM"].ToString();
						_originalDoc_fiscal_yr_start_month = ConvertDEC(Reader["DOC_FISCAL_YR_START_MONTH"]);
						_originalLast_mod_flag = Reader["LAST_MOD_FLAG"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
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