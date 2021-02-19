using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F020_DOCTOR_EXTRA : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F020_DOCTOR_EXTRA> Collection( Guid? rowid,
															string doc_nbr,
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
															string ceireq_prt_format,
															string ytdreq_prt_format,
															string ceitar_prt_format,
															string ytdtar_prt_format,
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
															string cash_flow_flag,
															string filler,
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
					new SqlParameter("CEIREQ_PRT_FORMAT",ceireq_prt_format),
					new SqlParameter("YTDREQ_PRT_FORMAT",ytdreq_prt_format),
					new SqlParameter("CEITAR_PRT_FORMAT",ceitar_prt_format),
					new SqlParameter("YTDTAR_PRT_FORMAT",ytdtar_prt_format),
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
					new SqlParameter("CASH_FLOW_FLAG",cash_flow_flag),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_EXTRA_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F020_DOCTOR_EXTRA>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_EXTRA_Search]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_EXTRA>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_EXTRA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString(),
					YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString(),
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
					CASH_FLOW_FLAG = Reader["CASH_FLOW_FLAG"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString(),
					_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString(),
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
					_originalCash_flow_flag = Reader["CASH_FLOW_FLAG"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F020_DOCTOR_EXTRA Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F020_DOCTOR_EXTRA> Collection(ObservableCollection<F020_DOCTOR_EXTRA>
                                                               f020DoctorExtra = null)
        {
            if (IsSameSearch() && f020DoctorExtra != null)
            {
                return f020DoctorExtra;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F020_DOCTOR_EXTRA>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_YRLY_REQUIRE_REVENUE",WhereDoc_yrly_require_revenue),
					new SqlParameter("DOC_YRLY_TARGET_REVENUE",WhereDoc_yrly_target_revenue),
					new SqlParameter("DOC_CEIREQ",WhereDoc_ceireq),
					new SqlParameter("DOC_YTDREQ",WhereDoc_ytdreq),
					new SqlParameter("DOC_CEITAR",WhereDoc_ceitar),
					new SqlParameter("DOC_YTDTAR",WhereDoc_ytdtar),
					new SqlParameter("CEIREQ_PRT_FORMAT",WhereCeireq_prt_format),
					new SqlParameter("YTDREQ_PRT_FORMAT",WhereYtdreq_prt_format),
					new SqlParameter("CEITAR_PRT_FORMAT",WhereCeitar_prt_format),
					new SqlParameter("YTDTAR_PRT_FORMAT",WhereYtdtar_prt_format),
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
					new SqlParameter("CASH_FLOW_FLAG",WhereCash_flow_flag),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_EXTRA_Match]", parameters);
            var collection = new ObservableCollection<F020_DOCTOR_EXTRA>();

            while (Reader.Read())
            {
                collection.Add(new F020_DOCTOR_EXTRA
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]),
					DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]),
					DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]),
					DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]),
					CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString(),
					YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString(),
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
					CASH_FLOW_FLAG = Reader["CASH_FLOW_FLAG"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue,
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue,
					_whereDoc_ceireq = WhereDoc_ceireq,
					_whereDoc_ytdreq = WhereDoc_ytdreq,
					_whereDoc_ceitar = WhereDoc_ceitar,
					_whereDoc_ytdtar = WhereDoc_ytdtar,
					_whereCeireq_prt_format = WhereCeireq_prt_format,
					_whereYtdreq_prt_format = WhereYtdreq_prt_format,
					_whereCeitar_prt_format = WhereCeitar_prt_format,
					_whereYtdtar_prt_format = WhereYtdtar_prt_format,
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
					_whereCash_flow_flag = WhereCash_flow_flag,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]),
					_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]),
					_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]),
					_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]),
					_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]),
					_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString(),
					_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString(),
					_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString(),
					_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString(),
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
					_originalCash_flow_flag = Reader["CASH_FLOW_FLAG"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue;
					_whereDoc_yrly_target_revenue = WhereDoc_yrly_target_revenue;
					_whereDoc_ceireq = WhereDoc_ceireq;
					_whereDoc_ytdreq = WhereDoc_ytdreq;
					_whereDoc_ceitar = WhereDoc_ceitar;
					_whereDoc_ytdtar = WhereDoc_ytdtar;
					_whereCeireq_prt_format = WhereCeireq_prt_format;
					_whereYtdreq_prt_format = WhereYtdreq_prt_format;
					_whereCeitar_prt_format = WhereCeitar_prt_format;
					_whereYtdtar_prt_format = WhereYtdtar_prt_format;
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
					_whereCash_flow_flag = WhereCash_flow_flag;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_yrly_require_revenue == null 
				&& WhereDoc_yrly_target_revenue == null 
				&& WhereDoc_ceireq == null 
				&& WhereDoc_ytdreq == null 
				&& WhereDoc_ceitar == null 
				&& WhereDoc_ytdtar == null 
				&& WhereCeireq_prt_format == null 
				&& WhereYtdreq_prt_format == null 
				&& WhereCeitar_prt_format == null 
				&& WhereYtdtar_prt_format == null 
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
				&& WhereCash_flow_flag == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_yrly_require_revenue ==  _whereDoc_yrly_require_revenue
				&& WhereDoc_yrly_target_revenue ==  _whereDoc_yrly_target_revenue
				&& WhereDoc_ceireq ==  _whereDoc_ceireq
				&& WhereDoc_ytdreq ==  _whereDoc_ytdreq
				&& WhereDoc_ceitar ==  _whereDoc_ceitar
				&& WhereDoc_ytdtar ==  _whereDoc_ytdtar
				&& WhereCeireq_prt_format ==  _whereCeireq_prt_format
				&& WhereYtdreq_prt_format ==  _whereYtdreq_prt_format
				&& WhereCeitar_prt_format ==  _whereCeitar_prt_format
				&& WhereYtdtar_prt_format ==  _whereYtdtar_prt_format
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
				&& WhereCash_flow_flag ==  _whereCash_flow_flag
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDoc_nbr = null; 
			WhereDoc_yrly_require_revenue = null; 
			WhereDoc_yrly_target_revenue = null; 
			WhereDoc_ceireq = null; 
			WhereDoc_ytdreq = null; 
			WhereDoc_ceitar = null; 
			WhereDoc_ytdtar = null; 
			WhereCeireq_prt_format = null; 
			WhereYtdreq_prt_format = null; 
			WhereCeitar_prt_format = null; 
			WhereYtdtar_prt_format = null; 
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
			WhereCash_flow_flag = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _DOC_NBR;
		private decimal? _DOC_YRLY_REQUIRE_REVENUE;
		private decimal? _DOC_YRLY_TARGET_REVENUE;
		private decimal? _DOC_CEIREQ;
		private decimal? _DOC_YTDREQ;
		private decimal? _DOC_CEITAR;
		private decimal? _DOC_YTDTAR;
		private string _CEIREQ_PRT_FORMAT;
		private string _YTDREQ_PRT_FORMAT;
		private string _CEITAR_PRT_FORMAT;
		private string _YTDTAR_PRT_FORMAT;
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
		private string _CASH_FLOW_FLAG;
		private string _FILLER;
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
		public string CEIREQ_PRT_FORMAT
		{
			get { return _CEIREQ_PRT_FORMAT; }
			set
			{
				if (_CEIREQ_PRT_FORMAT != value)
				{
					_CEIREQ_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDREQ_PRT_FORMAT
		{
			get { return _YTDREQ_PRT_FORMAT; }
			set
			{
				if (_YTDREQ_PRT_FORMAT != value)
				{
					_YTDREQ_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string CEITAR_PRT_FORMAT
		{
			get { return _CEITAR_PRT_FORMAT; }
			set
			{
				if (_CEITAR_PRT_FORMAT != value)
				{
					_CEITAR_PRT_FORMAT = value;
					ChangeState();
				}
			}
		}
		public string YTDTAR_PRT_FORMAT
		{
			get { return _YTDTAR_PRT_FORMAT; }
			set
			{
				if (_YTDTAR_PRT_FORMAT != value)
				{
					_YTDTAR_PRT_FORMAT = value;
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
		public string CASH_FLOW_FLAG
		{
			get { return _CASH_FLOW_FLAG; }
			set
			{
				if (_CASH_FLOW_FLAG != value)
				{
					_CASH_FLOW_FLAG = value;
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
		public string WhereCeireq_prt_format { get; set; }
		private string _whereCeireq_prt_format;
		public string WhereYtdreq_prt_format { get; set; }
		private string _whereYtdreq_prt_format;
		public string WhereCeitar_prt_format { get; set; }
		private string _whereCeitar_prt_format;
		public string WhereYtdtar_prt_format { get; set; }
		private string _whereYtdtar_prt_format;
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
		public string WhereCash_flow_flag { get; set; }
		private string _whereCash_flow_flag;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_yrly_require_revenue;
		private decimal? _originalDoc_yrly_target_revenue;
		private decimal? _originalDoc_ceireq;
		private decimal? _originalDoc_ytdreq;
		private decimal? _originalDoc_ceitar;
		private decimal? _originalDoc_ytdtar;
		private string _originalCeireq_prt_format;
		private string _originalYtdreq_prt_format;
		private string _originalCeitar_prt_format;
		private string _originalYtdtar_prt_format;
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
		private string _originalCash_flow_flag;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOC_NBR = _originalDoc_nbr;
			DOC_YRLY_REQUIRE_REVENUE = _originalDoc_yrly_require_revenue;
			DOC_YRLY_TARGET_REVENUE = _originalDoc_yrly_target_revenue;
			DOC_CEIREQ = _originalDoc_ceireq;
			DOC_YTDREQ = _originalDoc_ytdreq;
			DOC_CEITAR = _originalDoc_ceitar;
			DOC_YTDTAR = _originalDoc_ytdtar;
			CEIREQ_PRT_FORMAT = _originalCeireq_prt_format;
			YTDREQ_PRT_FORMAT = _originalYtdreq_prt_format;
			CEITAR_PRT_FORMAT = _originalCeitar_prt_format;
			YTDTAR_PRT_FORMAT = _originalYtdtar_prt_format;
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
			CASH_FLOW_FLAG = _originalCash_flow_flag;
			FILLER = _originalFiller;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOCTOR_EXTRA_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F020_DOCTOR_EXTRA_Purge]");
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
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("CEIREQ_PRT_FORMAT", SqlNull(CEIREQ_PRT_FORMAT)),
						new SqlParameter("YTDREQ_PRT_FORMAT", SqlNull(YTDREQ_PRT_FORMAT)),
						new SqlParameter("CEITAR_PRT_FORMAT", SqlNull(CEITAR_PRT_FORMAT)),
						new SqlParameter("YTDTAR_PRT_FORMAT", SqlNull(YTDTAR_PRT_FORMAT)),
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
						new SqlParameter("CASH_FLOW_FLAG", SqlNull(CASH_FLOW_FLAG)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_EXTRA_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString();
						YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString();
						CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString();
						YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString();
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
						CASH_FLOW_FLAG = Reader["CASH_FLOW_FLAG"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString();
						_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString();
						_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString();
						_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString();
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
						_originalCash_flow_flag = Reader["CASH_FLOW_FLAG"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_YRLY_TARGET_REVENUE", SqlNull(DOC_YRLY_TARGET_REVENUE)),
						new SqlParameter("DOC_CEIREQ", SqlNull(DOC_CEIREQ)),
						new SqlParameter("DOC_YTDREQ", SqlNull(DOC_YTDREQ)),
						new SqlParameter("DOC_CEITAR", SqlNull(DOC_CEITAR)),
						new SqlParameter("DOC_YTDTAR", SqlNull(DOC_YTDTAR)),
						new SqlParameter("CEIREQ_PRT_FORMAT", SqlNull(CEIREQ_PRT_FORMAT)),
						new SqlParameter("YTDREQ_PRT_FORMAT", SqlNull(YTDREQ_PRT_FORMAT)),
						new SqlParameter("CEITAR_PRT_FORMAT", SqlNull(CEITAR_PRT_FORMAT)),
						new SqlParameter("YTDTAR_PRT_FORMAT", SqlNull(YTDTAR_PRT_FORMAT)),
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
						new SqlParameter("CASH_FLOW_FLAG", SqlNull(CASH_FLOW_FLAG)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F020_DOCTOR_EXTRA_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_YRLY_TARGET_REVENUE = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						DOC_CEIREQ = ConvertDEC(Reader["DOC_CEIREQ"]);
						DOC_YTDREQ = ConvertDEC(Reader["DOC_YTDREQ"]);
						DOC_CEITAR = ConvertDEC(Reader["DOC_CEITAR"]);
						DOC_YTDTAR = ConvertDEC(Reader["DOC_YTDTAR"]);
						CEIREQ_PRT_FORMAT = Reader["CEIREQ_PRT_FORMAT"].ToString();
						YTDREQ_PRT_FORMAT = Reader["YTDREQ_PRT_FORMAT"].ToString();
						CEITAR_PRT_FORMAT = Reader["CEITAR_PRT_FORMAT"].ToString();
						YTDTAR_PRT_FORMAT = Reader["YTDTAR_PRT_FORMAT"].ToString();
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
						CASH_FLOW_FLAG = Reader["CASH_FLOW_FLAG"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_yrly_target_revenue = ConvertDEC(Reader["DOC_YRLY_TARGET_REVENUE"]);
						_originalDoc_ceireq = ConvertDEC(Reader["DOC_CEIREQ"]);
						_originalDoc_ytdreq = ConvertDEC(Reader["DOC_YTDREQ"]);
						_originalDoc_ceitar = ConvertDEC(Reader["DOC_CEITAR"]);
						_originalDoc_ytdtar = ConvertDEC(Reader["DOC_YTDTAR"]);
						_originalCeireq_prt_format = Reader["CEIREQ_PRT_FORMAT"].ToString();
						_originalYtdreq_prt_format = Reader["YTDREQ_PRT_FORMAT"].ToString();
						_originalCeitar_prt_format = Reader["CEITAR_PRT_FORMAT"].ToString();
						_originalYtdtar_prt_format = Reader["YTDTAR_PRT_FORMAT"].ToString();
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
						_originalCash_flow_flag = Reader["CASH_FLOW_FLAG"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
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