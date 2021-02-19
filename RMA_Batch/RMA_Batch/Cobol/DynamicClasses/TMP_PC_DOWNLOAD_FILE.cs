using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_PC_DOWNLOAD_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_PC_DOWNLOAD_FILE> Collection( Guid? rowid,
															decimal? current_ep_nbrmin,
															decimal? current_ep_nbrmax,
															string doc_nbr,
															decimal? doc_deptmin,
															decimal? doc_deptmax,
															decimal? doc_ohip_nbrmin,
															decimal? doc_ohip_nbrmax,
															decimal? doc_sin_nbrmin,
															decimal? doc_sin_nbrmax,
															decimal? doc_clinic_nbrmin,
															decimal? doc_clinic_nbrmax,
															decimal? doc_spec_cdmin,
															decimal? doc_spec_cdmax,
															string doc_name,
															string doc_inits,
															decimal? doc_yrly_ceiling_computedmin,
															decimal? doc_yrly_ceiling_computedmax,
															decimal? doc_date_fac_startmin,
															decimal? doc_date_fac_startmax,
															decimal? doc_date_fac_termmin,
															decimal? doc_date_fac_termmax,
															string doc_full_part_ind,
															decimal? doc_yrly_require_revenuemin,
															decimal? doc_yrly_require_revenuemax,
															decimal? doc_guarantee_percentagemin,
															decimal? doc_guarantee_percentagemax,
															string doc_guarantee_flag,
															decimal? amt_gross_ceiexpmin,
															decimal? amt_gross_ceiexpmax,
															decimal? amt_net_ytdcexmin,
															decimal? amt_net_ytdcexmax,
															string doc_pay_code,
															string doc_pay_sub_code,
															decimal? amt_ytd_totincmin,
															decimal? amt_ytd_totincmax,
															decimal? amt_ytd_incexpmin,
															decimal? amt_ytd_incexpmax,
															decimal? amt_ytd_depexmmin,
															decimal? amt_ytd_depexmmax,
															decimal? amt_ytd_depexrmin,
															decimal? amt_ytd_depexrmax,
															decimal? amt_ytd_ytdearmin,
															decimal? amt_ytd_ytdearmax,
															decimal? amt_ytd_depchrmin,
															decimal? amt_ytd_depchrmax,
															decimal? amt_mtd_payeftmin,
															decimal? amt_mtd_payeftmax,
															decimal? amt_ytd_rmaexrmin,
															decimal? amt_ytd_rmaexrmax,
															decimal? amt_ytd_gstmin,
															decimal? amt_ytd_gstmax,
															decimal? amt_ytd_billmin,
															decimal? amt_ytd_billmax,
															decimal? amt_ytd_rmaexmmin,
															decimal? amt_ytd_rmaexmmax,
															decimal? amt_mtd_paypotmin,
															decimal? amt_mtd_paypotmax,
															decimal? amt_mtd_gtypeamin,
															decimal? amt_mtd_gtypeamax,
															decimal? amt_mtd_rev_01min,
															decimal? amt_mtd_rev_01max,
															decimal? amt_ytd_rev_01min,
															decimal? amt_ytd_rev_01max,
															decimal? amt_mtd_rev_02min,
															decimal? amt_mtd_rev_02max,
															decimal? amt_ytd_rev_02min,
															decimal? amt_ytd_rev_02max,
															decimal? amt_mtd_rev_03min,
															decimal? amt_mtd_rev_03max,
															decimal? amt_ytd_rev_03min,
															decimal? amt_ytd_rev_03max,
															decimal? amt_mtd_rev_04min,
															decimal? amt_mtd_rev_04max,
															decimal? amt_ytd_rev_04min,
															decimal? amt_ytd_rev_04max,
															decimal? amt_mtd_rev_05min,
															decimal? amt_mtd_rev_05max,
															decimal? amt_ytd_rev_05min,
															decimal? amt_ytd_rev_05max,
															decimal? amt_mtd_rev_06min,
															decimal? amt_mtd_rev_06max,
															decimal? amt_ytd_rev_06min,
															decimal? amt_ytd_rev_06max,
															decimal? amt_mtd_rev_07min,
															decimal? amt_mtd_rev_07max,
															decimal? amt_ytd_rev_07min,
															decimal? amt_ytd_rev_07max,
															decimal? amt_mtd_rev_08min,
															decimal? amt_mtd_rev_08max,
															decimal? amt_ytd_rev_08min,
															decimal? amt_ytd_rev_08max,
															decimal? amt_mtd_rev_09min,
															decimal? amt_mtd_rev_09max,
															decimal? amt_ytd_rev_09min,
															decimal? amt_ytd_rev_09max,
															decimal? amt_mtd_rev_10min,
															decimal? amt_mtd_rev_10max,
															decimal? amt_ytd_rev_10min,
															decimal? amt_ytd_rev_10max,
															decimal? amt_mtd_rev_11min,
															decimal? amt_mtd_rev_11max,
															decimal? amt_ytd_rev_11min,
															decimal? amt_ytd_rev_11max,
															decimal? amt_mtd_rev_12min,
															decimal? amt_mtd_rev_12max,
															decimal? amt_ytd_rev_12min,
															decimal? amt_ytd_rev_12max,
															decimal? amt_mtd_rev_13min,
															decimal? amt_mtd_rev_13max,
															decimal? amt_ytd_rev_13min,
															decimal? amt_ytd_rev_13max,
															decimal? amt_mtd_rev_14min,
															decimal? amt_mtd_rev_14max,
															decimal? amt_ytd_rev_14min,
															decimal? amt_ytd_rev_14max,
															decimal? amt_mtd_rev_15min,
															decimal? amt_mtd_rev_15max,
															decimal? amt_ytd_rev_15min,
															decimal? amt_ytd_rev_15max,
															decimal? amt_mtd_rev_16min,
															decimal? amt_mtd_rev_16max,
															decimal? amt_ytd_rev_16min,
															decimal? amt_ytd_rev_16max,
															decimal? amt_mtd_rev_17min,
															decimal? amt_mtd_rev_17max,
															decimal? amt_ytd_rev_17min,
															decimal? amt_ytd_rev_17max,
															decimal? amt_mtd_rev_18min,
															decimal? amt_mtd_rev_18max,
															decimal? amt_ytd_rev_18min,
															decimal? amt_ytd_rev_18max,
															decimal? amt_mtd_rev_19min,
															decimal? amt_mtd_rev_19max,
															decimal? amt_ytd_rev_19min,
															decimal? amt_ytd_rev_19max,
															decimal? amt_mtd_rev_20min,
															decimal? amt_mtd_rev_20max,
															decimal? amt_ytd_rev_20min,
															decimal? amt_ytd_rev_20max,
															decimal? amt_ytd_rev_21min,
															decimal? amt_ytd_rev_21max,
															decimal? amt_ytd_rev_22min,
															decimal? amt_ytd_rev_22max,
															decimal? amt_ytd_rev_23min,
															decimal? amt_ytd_rev_23max,
															decimal? amt_ytd_rev_24min,
															decimal? amt_ytd_rev_24max,
															decimal? amt_ytd_rev_25min,
															decimal? amt_ytd_rev_25max,
															decimal? amt_ytd_rev_26min,
															decimal? amt_ytd_rev_26max,
															decimal? amt_ytd_rev_27min,
															decimal? amt_ytd_rev_27max,
															decimal? amt_ytd_rev_28min,
															decimal? amt_ytd_rev_28max,
															decimal? amt_ytd_rev_29min,
															decimal? amt_ytd_rev_29max,
															decimal? amt_ytd_rev_30min,
															decimal? amt_ytd_rev_30max,
															decimal? amt_ytd_rev_31min,
															decimal? amt_ytd_rev_31max,
															decimal? amt_ytd_rev_32min,
															decimal? amt_ytd_rev_32max,
															decimal? amt_ytd_rev_33min,
															decimal? amt_ytd_rev_33max,
															decimal? amt_ytd_rev_34min,
															decimal? amt_ytd_rev_34max,
															decimal? amt_ytd_rev_35min,
															decimal? amt_ytd_rev_35max,
															decimal? amt_ytd_exp_01min,
															decimal? amt_ytd_exp_01max,
															decimal? amt_ytd_exp_02min,
															decimal? amt_ytd_exp_02max,
															decimal? amt_ytd_exp_03min,
															decimal? amt_ytd_exp_03max,
															decimal? amt_ytd_exp_04min,
															decimal? amt_ytd_exp_04max,
															decimal? amt_ytd_exp_05min,
															decimal? amt_ytd_exp_05max,
															decimal? amt_ytd_exp_06min,
															decimal? amt_ytd_exp_06max,
															decimal? amt_ytd_exp_07min,
															decimal? amt_ytd_exp_07max,
															decimal? amt_ytd_exp_08min,
															decimal? amt_ytd_exp_08max,
															decimal? amt_ytd_exp_09min,
															decimal? amt_ytd_exp_09max,
															decimal? amt_ytd_exp_10min,
															decimal? amt_ytd_exp_10max,
															decimal? amtytdtotincendoflastfiscalyearmin,
															decimal? amtytdtotincendoflastfiscalyearmax,
															string text_misc,
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
					new SqlParameter("minCURRENT_EP_NBR",current_ep_nbrmin),
					new SqlParameter("maxCURRENT_EP_NBR",current_ep_nbrmax),
					new SqlParameter("DOC_NBR",doc_nbr),
					new SqlParameter("minDOC_DEPT",doc_deptmin),
					new SqlParameter("maxDOC_DEPT",doc_deptmax),
					new SqlParameter("minDOC_OHIP_NBR",doc_ohip_nbrmin),
					new SqlParameter("maxDOC_OHIP_NBR",doc_ohip_nbrmax),
					new SqlParameter("minDOC_SIN_NBR",doc_sin_nbrmin),
					new SqlParameter("maxDOC_SIN_NBR",doc_sin_nbrmax),
					new SqlParameter("minDOC_CLINIC_NBR",doc_clinic_nbrmin),
					new SqlParameter("maxDOC_CLINIC_NBR",doc_clinic_nbrmax),
					new SqlParameter("minDOC_SPEC_CD",doc_spec_cdmin),
					new SqlParameter("maxDOC_SPEC_CD",doc_spec_cdmax),
					new SqlParameter("DOC_NAME",doc_name),
					new SqlParameter("DOC_INITS",doc_inits),
					new SqlParameter("minDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmin),
					new SqlParameter("maxDOC_YRLY_CEILING_COMPUTED",doc_yrly_ceiling_computedmax),
					new SqlParameter("minDOC_DATE_FAC_START",doc_date_fac_startmin),
					new SqlParameter("maxDOC_DATE_FAC_START",doc_date_fac_startmax),
					new SqlParameter("minDOC_DATE_FAC_TERM",doc_date_fac_termmin),
					new SqlParameter("maxDOC_DATE_FAC_TERM",doc_date_fac_termmax),
					new SqlParameter("DOC_FULL_PART_IND",doc_full_part_ind),
					new SqlParameter("minDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemin),
					new SqlParameter("maxDOC_YRLY_REQUIRE_REVENUE",doc_yrly_require_revenuemax),
					new SqlParameter("minDOC_GUARANTEE_PERCENTAGE",doc_guarantee_percentagemin),
					new SqlParameter("maxDOC_GUARANTEE_PERCENTAGE",doc_guarantee_percentagemax),
					new SqlParameter("DOC_GUARANTEE_FLAG",doc_guarantee_flag),
					new SqlParameter("minAMT_GROSS_CEIEXP",amt_gross_ceiexpmin),
					new SqlParameter("maxAMT_GROSS_CEIEXP",amt_gross_ceiexpmax),
					new SqlParameter("minAMT_NET_YTDCEX",amt_net_ytdcexmin),
					new SqlParameter("maxAMT_NET_YTDCEX",amt_net_ytdcexmax),
					new SqlParameter("DOC_PAY_CODE",doc_pay_code),
					new SqlParameter("DOC_PAY_SUB_CODE",doc_pay_sub_code),
					new SqlParameter("minAMT_YTD_TOTINC",amt_ytd_totincmin),
					new SqlParameter("maxAMT_YTD_TOTINC",amt_ytd_totincmax),
					new SqlParameter("minAMT_YTD_INCEXP",amt_ytd_incexpmin),
					new SqlParameter("maxAMT_YTD_INCEXP",amt_ytd_incexpmax),
					new SqlParameter("minAMT_YTD_DEPEXM",amt_ytd_depexmmin),
					new SqlParameter("maxAMT_YTD_DEPEXM",amt_ytd_depexmmax),
					new SqlParameter("minAMT_YTD_DEPEXR",amt_ytd_depexrmin),
					new SqlParameter("maxAMT_YTD_DEPEXR",amt_ytd_depexrmax),
					new SqlParameter("minAMT_YTD_YTDEAR",amt_ytd_ytdearmin),
					new SqlParameter("maxAMT_YTD_YTDEAR",amt_ytd_ytdearmax),
					new SqlParameter("minAMT_YTD_DEPCHR",amt_ytd_depchrmin),
					new SqlParameter("maxAMT_YTD_DEPCHR",amt_ytd_depchrmax),
					new SqlParameter("minAMT_MTD_PAYEFT",amt_mtd_payeftmin),
					new SqlParameter("maxAMT_MTD_PAYEFT",amt_mtd_payeftmax),
					new SqlParameter("minAMT_YTD_RMAEXR",amt_ytd_rmaexrmin),
					new SqlParameter("maxAMT_YTD_RMAEXR",amt_ytd_rmaexrmax),
					new SqlParameter("minAMT_YTD_GST",amt_ytd_gstmin),
					new SqlParameter("maxAMT_YTD_GST",amt_ytd_gstmax),
					new SqlParameter("minAMT_YTD_BILL",amt_ytd_billmin),
					new SqlParameter("maxAMT_YTD_BILL",amt_ytd_billmax),
					new SqlParameter("minAMT_YTD_RMAEXM",amt_ytd_rmaexmmin),
					new SqlParameter("maxAMT_YTD_RMAEXM",amt_ytd_rmaexmmax),
					new SqlParameter("minAMT_MTD_PAYPOT",amt_mtd_paypotmin),
					new SqlParameter("maxAMT_MTD_PAYPOT",amt_mtd_paypotmax),
					new SqlParameter("minAMT_MTD_GTYPEA",amt_mtd_gtypeamin),
					new SqlParameter("maxAMT_MTD_GTYPEA",amt_mtd_gtypeamax),
					new SqlParameter("minAMT_MTD_REV_01",amt_mtd_rev_01min),
					new SqlParameter("maxAMT_MTD_REV_01",amt_mtd_rev_01max),
					new SqlParameter("minAMT_YTD_REV_01",amt_ytd_rev_01min),
					new SqlParameter("maxAMT_YTD_REV_01",amt_ytd_rev_01max),
					new SqlParameter("minAMT_MTD_REV_02",amt_mtd_rev_02min),
					new SqlParameter("maxAMT_MTD_REV_02",amt_mtd_rev_02max),
					new SqlParameter("minAMT_YTD_REV_02",amt_ytd_rev_02min),
					new SqlParameter("maxAMT_YTD_REV_02",amt_ytd_rev_02max),
					new SqlParameter("minAMT_MTD_REV_03",amt_mtd_rev_03min),
					new SqlParameter("maxAMT_MTD_REV_03",amt_mtd_rev_03max),
					new SqlParameter("minAMT_YTD_REV_03",amt_ytd_rev_03min),
					new SqlParameter("maxAMT_YTD_REV_03",amt_ytd_rev_03max),
					new SqlParameter("minAMT_MTD_REV_04",amt_mtd_rev_04min),
					new SqlParameter("maxAMT_MTD_REV_04",amt_mtd_rev_04max),
					new SqlParameter("minAMT_YTD_REV_04",amt_ytd_rev_04min),
					new SqlParameter("maxAMT_YTD_REV_04",amt_ytd_rev_04max),
					new SqlParameter("minAMT_MTD_REV_05",amt_mtd_rev_05min),
					new SqlParameter("maxAMT_MTD_REV_05",amt_mtd_rev_05max),
					new SqlParameter("minAMT_YTD_REV_05",amt_ytd_rev_05min),
					new SqlParameter("maxAMT_YTD_REV_05",amt_ytd_rev_05max),
					new SqlParameter("minAMT_MTD_REV_06",amt_mtd_rev_06min),
					new SqlParameter("maxAMT_MTD_REV_06",amt_mtd_rev_06max),
					new SqlParameter("minAMT_YTD_REV_06",amt_ytd_rev_06min),
					new SqlParameter("maxAMT_YTD_REV_06",amt_ytd_rev_06max),
					new SqlParameter("minAMT_MTD_REV_07",amt_mtd_rev_07min),
					new SqlParameter("maxAMT_MTD_REV_07",amt_mtd_rev_07max),
					new SqlParameter("minAMT_YTD_REV_07",amt_ytd_rev_07min),
					new SqlParameter("maxAMT_YTD_REV_07",amt_ytd_rev_07max),
					new SqlParameter("minAMT_MTD_REV_08",amt_mtd_rev_08min),
					new SqlParameter("maxAMT_MTD_REV_08",amt_mtd_rev_08max),
					new SqlParameter("minAMT_YTD_REV_08",amt_ytd_rev_08min),
					new SqlParameter("maxAMT_YTD_REV_08",amt_ytd_rev_08max),
					new SqlParameter("minAMT_MTD_REV_09",amt_mtd_rev_09min),
					new SqlParameter("maxAMT_MTD_REV_09",amt_mtd_rev_09max),
					new SqlParameter("minAMT_YTD_REV_09",amt_ytd_rev_09min),
					new SqlParameter("maxAMT_YTD_REV_09",amt_ytd_rev_09max),
					new SqlParameter("minAMT_MTD_REV_10",amt_mtd_rev_10min),
					new SqlParameter("maxAMT_MTD_REV_10",amt_mtd_rev_10max),
					new SqlParameter("minAMT_YTD_REV_10",amt_ytd_rev_10min),
					new SqlParameter("maxAMT_YTD_REV_10",amt_ytd_rev_10max),
					new SqlParameter("minAMT_MTD_REV_11",amt_mtd_rev_11min),
					new SqlParameter("maxAMT_MTD_REV_11",amt_mtd_rev_11max),
					new SqlParameter("minAMT_YTD_REV_11",amt_ytd_rev_11min),
					new SqlParameter("maxAMT_YTD_REV_11",amt_ytd_rev_11max),
					new SqlParameter("minAMT_MTD_REV_12",amt_mtd_rev_12min),
					new SqlParameter("maxAMT_MTD_REV_12",amt_mtd_rev_12max),
					new SqlParameter("minAMT_YTD_REV_12",amt_ytd_rev_12min),
					new SqlParameter("maxAMT_YTD_REV_12",amt_ytd_rev_12max),
					new SqlParameter("minAMT_MTD_REV_13",amt_mtd_rev_13min),
					new SqlParameter("maxAMT_MTD_REV_13",amt_mtd_rev_13max),
					new SqlParameter("minAMT_YTD_REV_13",amt_ytd_rev_13min),
					new SqlParameter("maxAMT_YTD_REV_13",amt_ytd_rev_13max),
					new SqlParameter("minAMT_MTD_REV_14",amt_mtd_rev_14min),
					new SqlParameter("maxAMT_MTD_REV_14",amt_mtd_rev_14max),
					new SqlParameter("minAMT_YTD_REV_14",amt_ytd_rev_14min),
					new SqlParameter("maxAMT_YTD_REV_14",amt_ytd_rev_14max),
					new SqlParameter("minAMT_MTD_REV_15",amt_mtd_rev_15min),
					new SqlParameter("maxAMT_MTD_REV_15",amt_mtd_rev_15max),
					new SqlParameter("minAMT_YTD_REV_15",amt_ytd_rev_15min),
					new SqlParameter("maxAMT_YTD_REV_15",amt_ytd_rev_15max),
					new SqlParameter("minAMT_MTD_REV_16",amt_mtd_rev_16min),
					new SqlParameter("maxAMT_MTD_REV_16",amt_mtd_rev_16max),
					new SqlParameter("minAMT_YTD_REV_16",amt_ytd_rev_16min),
					new SqlParameter("maxAMT_YTD_REV_16",amt_ytd_rev_16max),
					new SqlParameter("minAMT_MTD_REV_17",amt_mtd_rev_17min),
					new SqlParameter("maxAMT_MTD_REV_17",amt_mtd_rev_17max),
					new SqlParameter("minAMT_YTD_REV_17",amt_ytd_rev_17min),
					new SqlParameter("maxAMT_YTD_REV_17",amt_ytd_rev_17max),
					new SqlParameter("minAMT_MTD_REV_18",amt_mtd_rev_18min),
					new SqlParameter("maxAMT_MTD_REV_18",amt_mtd_rev_18max),
					new SqlParameter("minAMT_YTD_REV_18",amt_ytd_rev_18min),
					new SqlParameter("maxAMT_YTD_REV_18",amt_ytd_rev_18max),
					new SqlParameter("minAMT_MTD_REV_19",amt_mtd_rev_19min),
					new SqlParameter("maxAMT_MTD_REV_19",amt_mtd_rev_19max),
					new SqlParameter("minAMT_YTD_REV_19",amt_ytd_rev_19min),
					new SqlParameter("maxAMT_YTD_REV_19",amt_ytd_rev_19max),
					new SqlParameter("minAMT_MTD_REV_20",amt_mtd_rev_20min),
					new SqlParameter("maxAMT_MTD_REV_20",amt_mtd_rev_20max),
					new SqlParameter("minAMT_YTD_REV_20",amt_ytd_rev_20min),
					new SqlParameter("maxAMT_YTD_REV_20",amt_ytd_rev_20max),
					new SqlParameter("minAMT_YTD_REV_21",amt_ytd_rev_21min),
					new SqlParameter("maxAMT_YTD_REV_21",amt_ytd_rev_21max),
					new SqlParameter("minAMT_YTD_REV_22",amt_ytd_rev_22min),
					new SqlParameter("maxAMT_YTD_REV_22",amt_ytd_rev_22max),
					new SqlParameter("minAMT_YTD_REV_23",amt_ytd_rev_23min),
					new SqlParameter("maxAMT_YTD_REV_23",amt_ytd_rev_23max),
					new SqlParameter("minAMT_YTD_REV_24",amt_ytd_rev_24min),
					new SqlParameter("maxAMT_YTD_REV_24",amt_ytd_rev_24max),
					new SqlParameter("minAMT_YTD_REV_25",amt_ytd_rev_25min),
					new SqlParameter("maxAMT_YTD_REV_25",amt_ytd_rev_25max),
					new SqlParameter("minAMT_YTD_REV_26",amt_ytd_rev_26min),
					new SqlParameter("maxAMT_YTD_REV_26",amt_ytd_rev_26max),
					new SqlParameter("minAMT_YTD_REV_27",amt_ytd_rev_27min),
					new SqlParameter("maxAMT_YTD_REV_27",amt_ytd_rev_27max),
					new SqlParameter("minAMT_YTD_REV_28",amt_ytd_rev_28min),
					new SqlParameter("maxAMT_YTD_REV_28",amt_ytd_rev_28max),
					new SqlParameter("minAMT_YTD_REV_29",amt_ytd_rev_29min),
					new SqlParameter("maxAMT_YTD_REV_29",amt_ytd_rev_29max),
					new SqlParameter("minAMT_YTD_REV_30",amt_ytd_rev_30min),
					new SqlParameter("maxAMT_YTD_REV_30",amt_ytd_rev_30max),
					new SqlParameter("minAMT_YTD_REV_31",amt_ytd_rev_31min),
					new SqlParameter("maxAMT_YTD_REV_31",amt_ytd_rev_31max),
					new SqlParameter("minAMT_YTD_REV_32",amt_ytd_rev_32min),
					new SqlParameter("maxAMT_YTD_REV_32",amt_ytd_rev_32max),
					new SqlParameter("minAMT_YTD_REV_33",amt_ytd_rev_33min),
					new SqlParameter("maxAMT_YTD_REV_33",amt_ytd_rev_33max),
					new SqlParameter("minAMT_YTD_REV_34",amt_ytd_rev_34min),
					new SqlParameter("maxAMT_YTD_REV_34",amt_ytd_rev_34max),
					new SqlParameter("minAMT_YTD_REV_35",amt_ytd_rev_35min),
					new SqlParameter("maxAMT_YTD_REV_35",amt_ytd_rev_35max),
					new SqlParameter("minAMT_YTD_EXP_01",amt_ytd_exp_01min),
					new SqlParameter("maxAMT_YTD_EXP_01",amt_ytd_exp_01max),
					new SqlParameter("minAMT_YTD_EXP_02",amt_ytd_exp_02min),
					new SqlParameter("maxAMT_YTD_EXP_02",amt_ytd_exp_02max),
					new SqlParameter("minAMT_YTD_EXP_03",amt_ytd_exp_03min),
					new SqlParameter("maxAMT_YTD_EXP_03",amt_ytd_exp_03max),
					new SqlParameter("minAMT_YTD_EXP_04",amt_ytd_exp_04min),
					new SqlParameter("maxAMT_YTD_EXP_04",amt_ytd_exp_04max),
					new SqlParameter("minAMT_YTD_EXP_05",amt_ytd_exp_05min),
					new SqlParameter("maxAMT_YTD_EXP_05",amt_ytd_exp_05max),
					new SqlParameter("minAMT_YTD_EXP_06",amt_ytd_exp_06min),
					new SqlParameter("maxAMT_YTD_EXP_06",amt_ytd_exp_06max),
					new SqlParameter("minAMT_YTD_EXP_07",amt_ytd_exp_07min),
					new SqlParameter("maxAMT_YTD_EXP_07",amt_ytd_exp_07max),
					new SqlParameter("minAMT_YTD_EXP_08",amt_ytd_exp_08min),
					new SqlParameter("maxAMT_YTD_EXP_08",amt_ytd_exp_08max),
					new SqlParameter("minAMT_YTD_EXP_09",amt_ytd_exp_09min),
					new SqlParameter("maxAMT_YTD_EXP_09",amt_ytd_exp_09max),
					new SqlParameter("minAMT_YTD_EXP_10",amt_ytd_exp_10min),
					new SqlParameter("maxAMT_YTD_EXP_10",amt_ytd_exp_10max),
					new SqlParameter("minAMTYTDTOTINCENDOFLASTFISCALYEAR",amtytdtotincendoflastfiscalyearmin),
					new SqlParameter("maxAMTYTDTOTINCENDOFLASTFISCALYEAR",amtytdtotincendoflastfiscalyearmax),
					new SqlParameter("TEXT_MISC",text_misc),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_PC_DOWNLOAD_FILE>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_Search]", parameters);
            var collection = new ObservableCollection<TMP_PC_DOWNLOAD_FILE>();

            while (Reader.Read())
            {
                collection.Add(new TMP_PC_DOWNLOAD_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
					DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_GUARANTEE_PERCENTAGE = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]),
					DOC_GUARANTEE_FLAG = Reader["DOC_GUARANTEE_FLAG"].ToString(),
					AMT_GROSS_CEIEXP = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]),
					AMT_NET_YTDCEX = ConvertDEC(Reader["AMT_NET_YTDCEX"]),
					DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString(),
					DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString(),
					AMT_YTD_TOTINC = ConvertDEC(Reader["AMT_YTD_TOTINC"]),
					AMT_YTD_INCEXP = ConvertDEC(Reader["AMT_YTD_INCEXP"]),
					AMT_YTD_DEPEXM = ConvertDEC(Reader["AMT_YTD_DEPEXM"]),
					AMT_YTD_DEPEXR = ConvertDEC(Reader["AMT_YTD_DEPEXR"]),
					AMT_YTD_YTDEAR = ConvertDEC(Reader["AMT_YTD_YTDEAR"]),
					AMT_YTD_DEPCHR = ConvertDEC(Reader["AMT_YTD_DEPCHR"]),
					AMT_MTD_PAYEFT = ConvertDEC(Reader["AMT_MTD_PAYEFT"]),
					AMT_YTD_RMAEXR = ConvertDEC(Reader["AMT_YTD_RMAEXR"]),
					AMT_YTD_GST = ConvertDEC(Reader["AMT_YTD_GST"]),
					AMT_YTD_BILL = ConvertDEC(Reader["AMT_YTD_BILL"]),
					AMT_YTD_RMAEXM = ConvertDEC(Reader["AMT_YTD_RMAEXM"]),
					AMT_MTD_PAYPOT = ConvertDEC(Reader["AMT_MTD_PAYPOT"]),
					AMT_MTD_GTYPEA = ConvertDEC(Reader["AMT_MTD_GTYPEA"]),
					AMT_MTD_REV_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]),
					AMT_YTD_REV_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]),
					AMT_MTD_REV_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]),
					AMT_YTD_REV_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]),
					AMT_MTD_REV_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]),
					AMT_YTD_REV_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]),
					AMT_MTD_REV_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]),
					AMT_YTD_REV_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]),
					AMT_MTD_REV_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]),
					AMT_YTD_REV_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]),
					AMT_MTD_REV_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]),
					AMT_YTD_REV_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]),
					AMT_MTD_REV_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]),
					AMT_YTD_REV_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]),
					AMT_MTD_REV_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]),
					AMT_YTD_REV_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]),
					AMT_MTD_REV_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]),
					AMT_YTD_REV_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]),
					AMT_MTD_REV_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]),
					AMT_YTD_REV_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]),
					AMT_MTD_REV_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]),
					AMT_YTD_REV_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]),
					AMT_MTD_REV_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]),
					AMT_YTD_REV_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]),
					AMT_MTD_REV_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]),
					AMT_YTD_REV_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]),
					AMT_MTD_REV_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]),
					AMT_YTD_REV_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]),
					AMT_MTD_REV_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]),
					AMT_YTD_REV_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]),
					AMT_MTD_REV_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]),
					AMT_YTD_REV_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]),
					AMT_MTD_REV_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]),
					AMT_YTD_REV_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]),
					AMT_MTD_REV_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]),
					AMT_YTD_REV_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]),
					AMT_MTD_REV_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]),
					AMT_YTD_REV_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]),
					AMT_MTD_REV_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]),
					AMT_YTD_REV_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]),
					AMT_YTD_REV_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]),
					AMT_YTD_REV_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]),
					AMT_YTD_REV_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]),
					AMT_YTD_REV_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]),
					AMT_YTD_REV_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]),
					AMT_YTD_REV_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]),
					AMT_YTD_REV_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]),
					AMT_YTD_REV_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]),
					AMT_YTD_REV_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]),
					AMT_YTD_REV_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]),
					AMT_YTD_REV_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]),
					AMT_YTD_REV_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]),
					AMT_YTD_REV_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]),
					AMT_YTD_REV_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]),
					AMT_YTD_REV_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]),
					AMT_YTD_EXP_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]),
					AMT_YTD_EXP_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]),
					AMT_YTD_EXP_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]),
					AMT_YTD_EXP_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]),
					AMT_YTD_EXP_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]),
					AMT_YTD_EXP_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]),
					AMT_YTD_EXP_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]),
					AMT_YTD_EXP_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]),
					AMT_YTD_EXP_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]),
					AMT_YTD_EXP_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]),
					AMTYTDTOTINCENDOFLASTFISCALYEAR = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]),
					TEXT_MISC = Reader["TEXT_MISC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
					_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_guarantee_percentage = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]),
					_originalDoc_guarantee_flag = Reader["DOC_GUARANTEE_FLAG"].ToString(),
					_originalAmt_gross_ceiexp = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]),
					_originalAmt_net_ytdcex = ConvertDEC(Reader["AMT_NET_YTDCEX"]),
					_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString(),
					_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString(),
					_originalAmt_ytd_totinc = ConvertDEC(Reader["AMT_YTD_TOTINC"]),
					_originalAmt_ytd_incexp = ConvertDEC(Reader["AMT_YTD_INCEXP"]),
					_originalAmt_ytd_depexm = ConvertDEC(Reader["AMT_YTD_DEPEXM"]),
					_originalAmt_ytd_depexr = ConvertDEC(Reader["AMT_YTD_DEPEXR"]),
					_originalAmt_ytd_ytdear = ConvertDEC(Reader["AMT_YTD_YTDEAR"]),
					_originalAmt_ytd_depchr = ConvertDEC(Reader["AMT_YTD_DEPCHR"]),
					_originalAmt_mtd_payeft = ConvertDEC(Reader["AMT_MTD_PAYEFT"]),
					_originalAmt_ytd_rmaexr = ConvertDEC(Reader["AMT_YTD_RMAEXR"]),
					_originalAmt_ytd_gst = ConvertDEC(Reader["AMT_YTD_GST"]),
					_originalAmt_ytd_bill = ConvertDEC(Reader["AMT_YTD_BILL"]),
					_originalAmt_ytd_rmaexm = ConvertDEC(Reader["AMT_YTD_RMAEXM"]),
					_originalAmt_mtd_paypot = ConvertDEC(Reader["AMT_MTD_PAYPOT"]),
					_originalAmt_mtd_gtypea = ConvertDEC(Reader["AMT_MTD_GTYPEA"]),
					_originalAmt_mtd_rev_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]),
					_originalAmt_ytd_rev_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]),
					_originalAmt_mtd_rev_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]),
					_originalAmt_ytd_rev_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]),
					_originalAmt_mtd_rev_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]),
					_originalAmt_ytd_rev_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]),
					_originalAmt_mtd_rev_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]),
					_originalAmt_ytd_rev_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]),
					_originalAmt_mtd_rev_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]),
					_originalAmt_ytd_rev_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]),
					_originalAmt_mtd_rev_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]),
					_originalAmt_ytd_rev_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]),
					_originalAmt_mtd_rev_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]),
					_originalAmt_ytd_rev_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]),
					_originalAmt_mtd_rev_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]),
					_originalAmt_ytd_rev_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]),
					_originalAmt_mtd_rev_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]),
					_originalAmt_ytd_rev_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]),
					_originalAmt_mtd_rev_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]),
					_originalAmt_ytd_rev_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]),
					_originalAmt_mtd_rev_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]),
					_originalAmt_ytd_rev_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]),
					_originalAmt_mtd_rev_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]),
					_originalAmt_ytd_rev_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]),
					_originalAmt_mtd_rev_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]),
					_originalAmt_ytd_rev_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]),
					_originalAmt_mtd_rev_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]),
					_originalAmt_ytd_rev_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]),
					_originalAmt_mtd_rev_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]),
					_originalAmt_ytd_rev_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]),
					_originalAmt_mtd_rev_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]),
					_originalAmt_ytd_rev_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]),
					_originalAmt_mtd_rev_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]),
					_originalAmt_ytd_rev_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]),
					_originalAmt_mtd_rev_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]),
					_originalAmt_ytd_rev_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]),
					_originalAmt_mtd_rev_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]),
					_originalAmt_ytd_rev_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]),
					_originalAmt_mtd_rev_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]),
					_originalAmt_ytd_rev_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]),
					_originalAmt_ytd_rev_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]),
					_originalAmt_ytd_rev_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]),
					_originalAmt_ytd_rev_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]),
					_originalAmt_ytd_rev_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]),
					_originalAmt_ytd_rev_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]),
					_originalAmt_ytd_rev_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]),
					_originalAmt_ytd_rev_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]),
					_originalAmt_ytd_rev_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]),
					_originalAmt_ytd_rev_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]),
					_originalAmt_ytd_rev_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]),
					_originalAmt_ytd_rev_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]),
					_originalAmt_ytd_rev_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]),
					_originalAmt_ytd_rev_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]),
					_originalAmt_ytd_rev_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]),
					_originalAmt_ytd_rev_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]),
					_originalAmt_ytd_exp_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]),
					_originalAmt_ytd_exp_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]),
					_originalAmt_ytd_exp_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]),
					_originalAmt_ytd_exp_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]),
					_originalAmt_ytd_exp_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]),
					_originalAmt_ytd_exp_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]),
					_originalAmt_ytd_exp_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]),
					_originalAmt_ytd_exp_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]),
					_originalAmt_ytd_exp_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]),
					_originalAmt_ytd_exp_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]),
					_originalAmtytdtotincendoflastfiscalyear = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]),
					_originalText_misc = Reader["TEXT_MISC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_PC_DOWNLOAD_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_PC_DOWNLOAD_FILE> Collection(ObservableCollection<TMP_PC_DOWNLOAD_FILE>
                                                               tmpPcDownloadFile = null)
        {
            if (IsSameSearch() && tmpPcDownloadFile != null)
            {
                return tmpPcDownloadFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_PC_DOWNLOAD_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CURRENT_EP_NBR",WhereCurrent_ep_nbr),
					new SqlParameter("DOC_NBR",WhereDoc_nbr),
					new SqlParameter("DOC_DEPT",WhereDoc_dept),
					new SqlParameter("DOC_OHIP_NBR",WhereDoc_ohip_nbr),
					new SqlParameter("DOC_SIN_NBR",WhereDoc_sin_nbr),
					new SqlParameter("DOC_CLINIC_NBR",WhereDoc_clinic_nbr),
					new SqlParameter("DOC_SPEC_CD",WhereDoc_spec_cd),
					new SqlParameter("DOC_NAME",WhereDoc_name),
					new SqlParameter("DOC_INITS",WhereDoc_inits),
					new SqlParameter("DOC_YRLY_CEILING_COMPUTED",WhereDoc_yrly_ceiling_computed),
					new SqlParameter("DOC_DATE_FAC_START",WhereDoc_date_fac_start),
					new SqlParameter("DOC_DATE_FAC_TERM",WhereDoc_date_fac_term),
					new SqlParameter("DOC_FULL_PART_IND",WhereDoc_full_part_ind),
					new SqlParameter("DOC_YRLY_REQUIRE_REVENUE",WhereDoc_yrly_require_revenue),
					new SqlParameter("DOC_GUARANTEE_PERCENTAGE",WhereDoc_guarantee_percentage),
					new SqlParameter("DOC_GUARANTEE_FLAG",WhereDoc_guarantee_flag),
					new SqlParameter("AMT_GROSS_CEIEXP",WhereAmt_gross_ceiexp),
					new SqlParameter("AMT_NET_YTDCEX",WhereAmt_net_ytdcex),
					new SqlParameter("DOC_PAY_CODE",WhereDoc_pay_code),
					new SqlParameter("DOC_PAY_SUB_CODE",WhereDoc_pay_sub_code),
					new SqlParameter("AMT_YTD_TOTINC",WhereAmt_ytd_totinc),
					new SqlParameter("AMT_YTD_INCEXP",WhereAmt_ytd_incexp),
					new SqlParameter("AMT_YTD_DEPEXM",WhereAmt_ytd_depexm),
					new SqlParameter("AMT_YTD_DEPEXR",WhereAmt_ytd_depexr),
					new SqlParameter("AMT_YTD_YTDEAR",WhereAmt_ytd_ytdear),
					new SqlParameter("AMT_YTD_DEPCHR",WhereAmt_ytd_depchr),
					new SqlParameter("AMT_MTD_PAYEFT",WhereAmt_mtd_payeft),
					new SqlParameter("AMT_YTD_RMAEXR",WhereAmt_ytd_rmaexr),
					new SqlParameter("AMT_YTD_GST",WhereAmt_ytd_gst),
					new SqlParameter("AMT_YTD_BILL",WhereAmt_ytd_bill),
					new SqlParameter("AMT_YTD_RMAEXM",WhereAmt_ytd_rmaexm),
					new SqlParameter("AMT_MTD_PAYPOT",WhereAmt_mtd_paypot),
					new SqlParameter("AMT_MTD_GTYPEA",WhereAmt_mtd_gtypea),
					new SqlParameter("AMT_MTD_REV_01",WhereAmt_mtd_rev_01),
					new SqlParameter("AMT_YTD_REV_01",WhereAmt_ytd_rev_01),
					new SqlParameter("AMT_MTD_REV_02",WhereAmt_mtd_rev_02),
					new SqlParameter("AMT_YTD_REV_02",WhereAmt_ytd_rev_02),
					new SqlParameter("AMT_MTD_REV_03",WhereAmt_mtd_rev_03),
					new SqlParameter("AMT_YTD_REV_03",WhereAmt_ytd_rev_03),
					new SqlParameter("AMT_MTD_REV_04",WhereAmt_mtd_rev_04),
					new SqlParameter("AMT_YTD_REV_04",WhereAmt_ytd_rev_04),
					new SqlParameter("AMT_MTD_REV_05",WhereAmt_mtd_rev_05),
					new SqlParameter("AMT_YTD_REV_05",WhereAmt_ytd_rev_05),
					new SqlParameter("AMT_MTD_REV_06",WhereAmt_mtd_rev_06),
					new SqlParameter("AMT_YTD_REV_06",WhereAmt_ytd_rev_06),
					new SqlParameter("AMT_MTD_REV_07",WhereAmt_mtd_rev_07),
					new SqlParameter("AMT_YTD_REV_07",WhereAmt_ytd_rev_07),
					new SqlParameter("AMT_MTD_REV_08",WhereAmt_mtd_rev_08),
					new SqlParameter("AMT_YTD_REV_08",WhereAmt_ytd_rev_08),
					new SqlParameter("AMT_MTD_REV_09",WhereAmt_mtd_rev_09),
					new SqlParameter("AMT_YTD_REV_09",WhereAmt_ytd_rev_09),
					new SqlParameter("AMT_MTD_REV_10",WhereAmt_mtd_rev_10),
					new SqlParameter("AMT_YTD_REV_10",WhereAmt_ytd_rev_10),
					new SqlParameter("AMT_MTD_REV_11",WhereAmt_mtd_rev_11),
					new SqlParameter("AMT_YTD_REV_11",WhereAmt_ytd_rev_11),
					new SqlParameter("AMT_MTD_REV_12",WhereAmt_mtd_rev_12),
					new SqlParameter("AMT_YTD_REV_12",WhereAmt_ytd_rev_12),
					new SqlParameter("AMT_MTD_REV_13",WhereAmt_mtd_rev_13),
					new SqlParameter("AMT_YTD_REV_13",WhereAmt_ytd_rev_13),
					new SqlParameter("AMT_MTD_REV_14",WhereAmt_mtd_rev_14),
					new SqlParameter("AMT_YTD_REV_14",WhereAmt_ytd_rev_14),
					new SqlParameter("AMT_MTD_REV_15",WhereAmt_mtd_rev_15),
					new SqlParameter("AMT_YTD_REV_15",WhereAmt_ytd_rev_15),
					new SqlParameter("AMT_MTD_REV_16",WhereAmt_mtd_rev_16),
					new SqlParameter("AMT_YTD_REV_16",WhereAmt_ytd_rev_16),
					new SqlParameter("AMT_MTD_REV_17",WhereAmt_mtd_rev_17),
					new SqlParameter("AMT_YTD_REV_17",WhereAmt_ytd_rev_17),
					new SqlParameter("AMT_MTD_REV_18",WhereAmt_mtd_rev_18),
					new SqlParameter("AMT_YTD_REV_18",WhereAmt_ytd_rev_18),
					new SqlParameter("AMT_MTD_REV_19",WhereAmt_mtd_rev_19),
					new SqlParameter("AMT_YTD_REV_19",WhereAmt_ytd_rev_19),
					new SqlParameter("AMT_MTD_REV_20",WhereAmt_mtd_rev_20),
					new SqlParameter("AMT_YTD_REV_20",WhereAmt_ytd_rev_20),
					new SqlParameter("AMT_YTD_REV_21",WhereAmt_ytd_rev_21),
					new SqlParameter("AMT_YTD_REV_22",WhereAmt_ytd_rev_22),
					new SqlParameter("AMT_YTD_REV_23",WhereAmt_ytd_rev_23),
					new SqlParameter("AMT_YTD_REV_24",WhereAmt_ytd_rev_24),
					new SqlParameter("AMT_YTD_REV_25",WhereAmt_ytd_rev_25),
					new SqlParameter("AMT_YTD_REV_26",WhereAmt_ytd_rev_26),
					new SqlParameter("AMT_YTD_REV_27",WhereAmt_ytd_rev_27),
					new SqlParameter("AMT_YTD_REV_28",WhereAmt_ytd_rev_28),
					new SqlParameter("AMT_YTD_REV_29",WhereAmt_ytd_rev_29),
					new SqlParameter("AMT_YTD_REV_30",WhereAmt_ytd_rev_30),
					new SqlParameter("AMT_YTD_REV_31",WhereAmt_ytd_rev_31),
					new SqlParameter("AMT_YTD_REV_32",WhereAmt_ytd_rev_32),
					new SqlParameter("AMT_YTD_REV_33",WhereAmt_ytd_rev_33),
					new SqlParameter("AMT_YTD_REV_34",WhereAmt_ytd_rev_34),
					new SqlParameter("AMT_YTD_REV_35",WhereAmt_ytd_rev_35),
					new SqlParameter("AMT_YTD_EXP_01",WhereAmt_ytd_exp_01),
					new SqlParameter("AMT_YTD_EXP_02",WhereAmt_ytd_exp_02),
					new SqlParameter("AMT_YTD_EXP_03",WhereAmt_ytd_exp_03),
					new SqlParameter("AMT_YTD_EXP_04",WhereAmt_ytd_exp_04),
					new SqlParameter("AMT_YTD_EXP_05",WhereAmt_ytd_exp_05),
					new SqlParameter("AMT_YTD_EXP_06",WhereAmt_ytd_exp_06),
					new SqlParameter("AMT_YTD_EXP_07",WhereAmt_ytd_exp_07),
					new SqlParameter("AMT_YTD_EXP_08",WhereAmt_ytd_exp_08),
					new SqlParameter("AMT_YTD_EXP_09",WhereAmt_ytd_exp_09),
					new SqlParameter("AMT_YTD_EXP_10",WhereAmt_ytd_exp_10),
					new SqlParameter("AMTYTDTOTINCENDOFLASTFISCALYEAR",WhereAmtytdtotincendoflastfiscalyear),
					new SqlParameter("TEXT_MISC",WhereText_misc),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_Match]", parameters);
            var collection = new ObservableCollection<TMP_PC_DOWNLOAD_FILE>();

            while (Reader.Read())
            {
                collection.Add(new TMP_PC_DOWNLOAD_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					DOC_NBR = Reader["DOC_NBR"].ToString(),
					DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]),
					DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]),
					DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]),
					DOC_NAME = Reader["DOC_NAME"].ToString(),
					DOC_INITS = Reader["DOC_INITS"].ToString(),
					DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
					DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString(),
					DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					DOC_GUARANTEE_PERCENTAGE = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]),
					DOC_GUARANTEE_FLAG = Reader["DOC_GUARANTEE_FLAG"].ToString(),
					AMT_GROSS_CEIEXP = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]),
					AMT_NET_YTDCEX = ConvertDEC(Reader["AMT_NET_YTDCEX"]),
					DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString(),
					DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString(),
					AMT_YTD_TOTINC = ConvertDEC(Reader["AMT_YTD_TOTINC"]),
					AMT_YTD_INCEXP = ConvertDEC(Reader["AMT_YTD_INCEXP"]),
					AMT_YTD_DEPEXM = ConvertDEC(Reader["AMT_YTD_DEPEXM"]),
					AMT_YTD_DEPEXR = ConvertDEC(Reader["AMT_YTD_DEPEXR"]),
					AMT_YTD_YTDEAR = ConvertDEC(Reader["AMT_YTD_YTDEAR"]),
					AMT_YTD_DEPCHR = ConvertDEC(Reader["AMT_YTD_DEPCHR"]),
					AMT_MTD_PAYEFT = ConvertDEC(Reader["AMT_MTD_PAYEFT"]),
					AMT_YTD_RMAEXR = ConvertDEC(Reader["AMT_YTD_RMAEXR"]),
					AMT_YTD_GST = ConvertDEC(Reader["AMT_YTD_GST"]),
					AMT_YTD_BILL = ConvertDEC(Reader["AMT_YTD_BILL"]),
					AMT_YTD_RMAEXM = ConvertDEC(Reader["AMT_YTD_RMAEXM"]),
					AMT_MTD_PAYPOT = ConvertDEC(Reader["AMT_MTD_PAYPOT"]),
					AMT_MTD_GTYPEA = ConvertDEC(Reader["AMT_MTD_GTYPEA"]),
					AMT_MTD_REV_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]),
					AMT_YTD_REV_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]),
					AMT_MTD_REV_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]),
					AMT_YTD_REV_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]),
					AMT_MTD_REV_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]),
					AMT_YTD_REV_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]),
					AMT_MTD_REV_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]),
					AMT_YTD_REV_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]),
					AMT_MTD_REV_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]),
					AMT_YTD_REV_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]),
					AMT_MTD_REV_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]),
					AMT_YTD_REV_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]),
					AMT_MTD_REV_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]),
					AMT_YTD_REV_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]),
					AMT_MTD_REV_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]),
					AMT_YTD_REV_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]),
					AMT_MTD_REV_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]),
					AMT_YTD_REV_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]),
					AMT_MTD_REV_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]),
					AMT_YTD_REV_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]),
					AMT_MTD_REV_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]),
					AMT_YTD_REV_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]),
					AMT_MTD_REV_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]),
					AMT_YTD_REV_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]),
					AMT_MTD_REV_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]),
					AMT_YTD_REV_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]),
					AMT_MTD_REV_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]),
					AMT_YTD_REV_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]),
					AMT_MTD_REV_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]),
					AMT_YTD_REV_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]),
					AMT_MTD_REV_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]),
					AMT_YTD_REV_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]),
					AMT_MTD_REV_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]),
					AMT_YTD_REV_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]),
					AMT_MTD_REV_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]),
					AMT_YTD_REV_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]),
					AMT_MTD_REV_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]),
					AMT_YTD_REV_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]),
					AMT_MTD_REV_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]),
					AMT_YTD_REV_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]),
					AMT_YTD_REV_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]),
					AMT_YTD_REV_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]),
					AMT_YTD_REV_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]),
					AMT_YTD_REV_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]),
					AMT_YTD_REV_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]),
					AMT_YTD_REV_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]),
					AMT_YTD_REV_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]),
					AMT_YTD_REV_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]),
					AMT_YTD_REV_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]),
					AMT_YTD_REV_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]),
					AMT_YTD_REV_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]),
					AMT_YTD_REV_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]),
					AMT_YTD_REV_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]),
					AMT_YTD_REV_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]),
					AMT_YTD_REV_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]),
					AMT_YTD_EXP_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]),
					AMT_YTD_EXP_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]),
					AMT_YTD_EXP_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]),
					AMT_YTD_EXP_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]),
					AMT_YTD_EXP_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]),
					AMT_YTD_EXP_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]),
					AMT_YTD_EXP_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]),
					AMT_YTD_EXP_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]),
					AMT_YTD_EXP_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]),
					AMT_YTD_EXP_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]),
					AMTYTDTOTINCENDOFLASTFISCALYEAR = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]),
					TEXT_MISC = Reader["TEXT_MISC"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereCurrent_ep_nbr = WhereCurrent_ep_nbr,
					_whereDoc_nbr = WhereDoc_nbr,
					_whereDoc_dept = WhereDoc_dept,
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr,
					_whereDoc_sin_nbr = WhereDoc_sin_nbr,
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr,
					_whereDoc_spec_cd = WhereDoc_spec_cd,
					_whereDoc_name = WhereDoc_name,
					_whereDoc_inits = WhereDoc_inits,
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed,
					_whereDoc_date_fac_start = WhereDoc_date_fac_start,
					_whereDoc_date_fac_term = WhereDoc_date_fac_term,
					_whereDoc_full_part_ind = WhereDoc_full_part_ind,
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue,
					_whereDoc_guarantee_percentage = WhereDoc_guarantee_percentage,
					_whereDoc_guarantee_flag = WhereDoc_guarantee_flag,
					_whereAmt_gross_ceiexp = WhereAmt_gross_ceiexp,
					_whereAmt_net_ytdcex = WhereAmt_net_ytdcex,
					_whereDoc_pay_code = WhereDoc_pay_code,
					_whereDoc_pay_sub_code = WhereDoc_pay_sub_code,
					_whereAmt_ytd_totinc = WhereAmt_ytd_totinc,
					_whereAmt_ytd_incexp = WhereAmt_ytd_incexp,
					_whereAmt_ytd_depexm = WhereAmt_ytd_depexm,
					_whereAmt_ytd_depexr = WhereAmt_ytd_depexr,
					_whereAmt_ytd_ytdear = WhereAmt_ytd_ytdear,
					_whereAmt_ytd_depchr = WhereAmt_ytd_depchr,
					_whereAmt_mtd_payeft = WhereAmt_mtd_payeft,
					_whereAmt_ytd_rmaexr = WhereAmt_ytd_rmaexr,
					_whereAmt_ytd_gst = WhereAmt_ytd_gst,
					_whereAmt_ytd_bill = WhereAmt_ytd_bill,
					_whereAmt_ytd_rmaexm = WhereAmt_ytd_rmaexm,
					_whereAmt_mtd_paypot = WhereAmt_mtd_paypot,
					_whereAmt_mtd_gtypea = WhereAmt_mtd_gtypea,
					_whereAmt_mtd_rev_01 = WhereAmt_mtd_rev_01,
					_whereAmt_ytd_rev_01 = WhereAmt_ytd_rev_01,
					_whereAmt_mtd_rev_02 = WhereAmt_mtd_rev_02,
					_whereAmt_ytd_rev_02 = WhereAmt_ytd_rev_02,
					_whereAmt_mtd_rev_03 = WhereAmt_mtd_rev_03,
					_whereAmt_ytd_rev_03 = WhereAmt_ytd_rev_03,
					_whereAmt_mtd_rev_04 = WhereAmt_mtd_rev_04,
					_whereAmt_ytd_rev_04 = WhereAmt_ytd_rev_04,
					_whereAmt_mtd_rev_05 = WhereAmt_mtd_rev_05,
					_whereAmt_ytd_rev_05 = WhereAmt_ytd_rev_05,
					_whereAmt_mtd_rev_06 = WhereAmt_mtd_rev_06,
					_whereAmt_ytd_rev_06 = WhereAmt_ytd_rev_06,
					_whereAmt_mtd_rev_07 = WhereAmt_mtd_rev_07,
					_whereAmt_ytd_rev_07 = WhereAmt_ytd_rev_07,
					_whereAmt_mtd_rev_08 = WhereAmt_mtd_rev_08,
					_whereAmt_ytd_rev_08 = WhereAmt_ytd_rev_08,
					_whereAmt_mtd_rev_09 = WhereAmt_mtd_rev_09,
					_whereAmt_ytd_rev_09 = WhereAmt_ytd_rev_09,
					_whereAmt_mtd_rev_10 = WhereAmt_mtd_rev_10,
					_whereAmt_ytd_rev_10 = WhereAmt_ytd_rev_10,
					_whereAmt_mtd_rev_11 = WhereAmt_mtd_rev_11,
					_whereAmt_ytd_rev_11 = WhereAmt_ytd_rev_11,
					_whereAmt_mtd_rev_12 = WhereAmt_mtd_rev_12,
					_whereAmt_ytd_rev_12 = WhereAmt_ytd_rev_12,
					_whereAmt_mtd_rev_13 = WhereAmt_mtd_rev_13,
					_whereAmt_ytd_rev_13 = WhereAmt_ytd_rev_13,
					_whereAmt_mtd_rev_14 = WhereAmt_mtd_rev_14,
					_whereAmt_ytd_rev_14 = WhereAmt_ytd_rev_14,
					_whereAmt_mtd_rev_15 = WhereAmt_mtd_rev_15,
					_whereAmt_ytd_rev_15 = WhereAmt_ytd_rev_15,
					_whereAmt_mtd_rev_16 = WhereAmt_mtd_rev_16,
					_whereAmt_ytd_rev_16 = WhereAmt_ytd_rev_16,
					_whereAmt_mtd_rev_17 = WhereAmt_mtd_rev_17,
					_whereAmt_ytd_rev_17 = WhereAmt_ytd_rev_17,
					_whereAmt_mtd_rev_18 = WhereAmt_mtd_rev_18,
					_whereAmt_ytd_rev_18 = WhereAmt_ytd_rev_18,
					_whereAmt_mtd_rev_19 = WhereAmt_mtd_rev_19,
					_whereAmt_ytd_rev_19 = WhereAmt_ytd_rev_19,
					_whereAmt_mtd_rev_20 = WhereAmt_mtd_rev_20,
					_whereAmt_ytd_rev_20 = WhereAmt_ytd_rev_20,
					_whereAmt_ytd_rev_21 = WhereAmt_ytd_rev_21,
					_whereAmt_ytd_rev_22 = WhereAmt_ytd_rev_22,
					_whereAmt_ytd_rev_23 = WhereAmt_ytd_rev_23,
					_whereAmt_ytd_rev_24 = WhereAmt_ytd_rev_24,
					_whereAmt_ytd_rev_25 = WhereAmt_ytd_rev_25,
					_whereAmt_ytd_rev_26 = WhereAmt_ytd_rev_26,
					_whereAmt_ytd_rev_27 = WhereAmt_ytd_rev_27,
					_whereAmt_ytd_rev_28 = WhereAmt_ytd_rev_28,
					_whereAmt_ytd_rev_29 = WhereAmt_ytd_rev_29,
					_whereAmt_ytd_rev_30 = WhereAmt_ytd_rev_30,
					_whereAmt_ytd_rev_31 = WhereAmt_ytd_rev_31,
					_whereAmt_ytd_rev_32 = WhereAmt_ytd_rev_32,
					_whereAmt_ytd_rev_33 = WhereAmt_ytd_rev_33,
					_whereAmt_ytd_rev_34 = WhereAmt_ytd_rev_34,
					_whereAmt_ytd_rev_35 = WhereAmt_ytd_rev_35,
					_whereAmt_ytd_exp_01 = WhereAmt_ytd_exp_01,
					_whereAmt_ytd_exp_02 = WhereAmt_ytd_exp_02,
					_whereAmt_ytd_exp_03 = WhereAmt_ytd_exp_03,
					_whereAmt_ytd_exp_04 = WhereAmt_ytd_exp_04,
					_whereAmt_ytd_exp_05 = WhereAmt_ytd_exp_05,
					_whereAmt_ytd_exp_06 = WhereAmt_ytd_exp_06,
					_whereAmt_ytd_exp_07 = WhereAmt_ytd_exp_07,
					_whereAmt_ytd_exp_08 = WhereAmt_ytd_exp_08,
					_whereAmt_ytd_exp_09 = WhereAmt_ytd_exp_09,
					_whereAmt_ytd_exp_10 = WhereAmt_ytd_exp_10,
					_whereAmtytdtotincendoflastfiscalyear = WhereAmtytdtotincendoflastfiscalyear,
					_whereText_misc = WhereText_misc,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]),
					_originalDoc_nbr = Reader["DOC_NBR"].ToString(),
					_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]),
					_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]),
					_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]),
					_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]),
					_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]),
					_originalDoc_name = Reader["DOC_NAME"].ToString(),
					_originalDoc_inits = Reader["DOC_INITS"].ToString(),
					_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]),
					_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]),
					_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]),
					_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString(),
					_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]),
					_originalDoc_guarantee_percentage = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]),
					_originalDoc_guarantee_flag = Reader["DOC_GUARANTEE_FLAG"].ToString(),
					_originalAmt_gross_ceiexp = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]),
					_originalAmt_net_ytdcex = ConvertDEC(Reader["AMT_NET_YTDCEX"]),
					_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString(),
					_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString(),
					_originalAmt_ytd_totinc = ConvertDEC(Reader["AMT_YTD_TOTINC"]),
					_originalAmt_ytd_incexp = ConvertDEC(Reader["AMT_YTD_INCEXP"]),
					_originalAmt_ytd_depexm = ConvertDEC(Reader["AMT_YTD_DEPEXM"]),
					_originalAmt_ytd_depexr = ConvertDEC(Reader["AMT_YTD_DEPEXR"]),
					_originalAmt_ytd_ytdear = ConvertDEC(Reader["AMT_YTD_YTDEAR"]),
					_originalAmt_ytd_depchr = ConvertDEC(Reader["AMT_YTD_DEPCHR"]),
					_originalAmt_mtd_payeft = ConvertDEC(Reader["AMT_MTD_PAYEFT"]),
					_originalAmt_ytd_rmaexr = ConvertDEC(Reader["AMT_YTD_RMAEXR"]),
					_originalAmt_ytd_gst = ConvertDEC(Reader["AMT_YTD_GST"]),
					_originalAmt_ytd_bill = ConvertDEC(Reader["AMT_YTD_BILL"]),
					_originalAmt_ytd_rmaexm = ConvertDEC(Reader["AMT_YTD_RMAEXM"]),
					_originalAmt_mtd_paypot = ConvertDEC(Reader["AMT_MTD_PAYPOT"]),
					_originalAmt_mtd_gtypea = ConvertDEC(Reader["AMT_MTD_GTYPEA"]),
					_originalAmt_mtd_rev_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]),
					_originalAmt_ytd_rev_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]),
					_originalAmt_mtd_rev_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]),
					_originalAmt_ytd_rev_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]),
					_originalAmt_mtd_rev_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]),
					_originalAmt_ytd_rev_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]),
					_originalAmt_mtd_rev_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]),
					_originalAmt_ytd_rev_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]),
					_originalAmt_mtd_rev_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]),
					_originalAmt_ytd_rev_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]),
					_originalAmt_mtd_rev_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]),
					_originalAmt_ytd_rev_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]),
					_originalAmt_mtd_rev_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]),
					_originalAmt_ytd_rev_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]),
					_originalAmt_mtd_rev_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]),
					_originalAmt_ytd_rev_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]),
					_originalAmt_mtd_rev_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]),
					_originalAmt_ytd_rev_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]),
					_originalAmt_mtd_rev_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]),
					_originalAmt_ytd_rev_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]),
					_originalAmt_mtd_rev_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]),
					_originalAmt_ytd_rev_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]),
					_originalAmt_mtd_rev_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]),
					_originalAmt_ytd_rev_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]),
					_originalAmt_mtd_rev_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]),
					_originalAmt_ytd_rev_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]),
					_originalAmt_mtd_rev_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]),
					_originalAmt_ytd_rev_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]),
					_originalAmt_mtd_rev_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]),
					_originalAmt_ytd_rev_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]),
					_originalAmt_mtd_rev_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]),
					_originalAmt_ytd_rev_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]),
					_originalAmt_mtd_rev_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]),
					_originalAmt_ytd_rev_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]),
					_originalAmt_mtd_rev_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]),
					_originalAmt_ytd_rev_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]),
					_originalAmt_mtd_rev_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]),
					_originalAmt_ytd_rev_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]),
					_originalAmt_mtd_rev_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]),
					_originalAmt_ytd_rev_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]),
					_originalAmt_ytd_rev_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]),
					_originalAmt_ytd_rev_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]),
					_originalAmt_ytd_rev_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]),
					_originalAmt_ytd_rev_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]),
					_originalAmt_ytd_rev_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]),
					_originalAmt_ytd_rev_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]),
					_originalAmt_ytd_rev_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]),
					_originalAmt_ytd_rev_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]),
					_originalAmt_ytd_rev_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]),
					_originalAmt_ytd_rev_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]),
					_originalAmt_ytd_rev_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]),
					_originalAmt_ytd_rev_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]),
					_originalAmt_ytd_rev_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]),
					_originalAmt_ytd_rev_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]),
					_originalAmt_ytd_rev_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]),
					_originalAmt_ytd_exp_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]),
					_originalAmt_ytd_exp_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]),
					_originalAmt_ytd_exp_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]),
					_originalAmt_ytd_exp_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]),
					_originalAmt_ytd_exp_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]),
					_originalAmt_ytd_exp_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]),
					_originalAmt_ytd_exp_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]),
					_originalAmt_ytd_exp_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]),
					_originalAmt_ytd_exp_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]),
					_originalAmt_ytd_exp_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]),
					_originalAmtytdtotincendoflastfiscalyear = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]),
					_originalText_misc = Reader["TEXT_MISC"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereCurrent_ep_nbr = WhereCurrent_ep_nbr;
					_whereDoc_nbr = WhereDoc_nbr;
					_whereDoc_dept = WhereDoc_dept;
					_whereDoc_ohip_nbr = WhereDoc_ohip_nbr;
					_whereDoc_sin_nbr = WhereDoc_sin_nbr;
					_whereDoc_clinic_nbr = WhereDoc_clinic_nbr;
					_whereDoc_spec_cd = WhereDoc_spec_cd;
					_whereDoc_name = WhereDoc_name;
					_whereDoc_inits = WhereDoc_inits;
					_whereDoc_yrly_ceiling_computed = WhereDoc_yrly_ceiling_computed;
					_whereDoc_date_fac_start = WhereDoc_date_fac_start;
					_whereDoc_date_fac_term = WhereDoc_date_fac_term;
					_whereDoc_full_part_ind = WhereDoc_full_part_ind;
					_whereDoc_yrly_require_revenue = WhereDoc_yrly_require_revenue;
					_whereDoc_guarantee_percentage = WhereDoc_guarantee_percentage;
					_whereDoc_guarantee_flag = WhereDoc_guarantee_flag;
					_whereAmt_gross_ceiexp = WhereAmt_gross_ceiexp;
					_whereAmt_net_ytdcex = WhereAmt_net_ytdcex;
					_whereDoc_pay_code = WhereDoc_pay_code;
					_whereDoc_pay_sub_code = WhereDoc_pay_sub_code;
					_whereAmt_ytd_totinc = WhereAmt_ytd_totinc;
					_whereAmt_ytd_incexp = WhereAmt_ytd_incexp;
					_whereAmt_ytd_depexm = WhereAmt_ytd_depexm;
					_whereAmt_ytd_depexr = WhereAmt_ytd_depexr;
					_whereAmt_ytd_ytdear = WhereAmt_ytd_ytdear;
					_whereAmt_ytd_depchr = WhereAmt_ytd_depchr;
					_whereAmt_mtd_payeft = WhereAmt_mtd_payeft;
					_whereAmt_ytd_rmaexr = WhereAmt_ytd_rmaexr;
					_whereAmt_ytd_gst = WhereAmt_ytd_gst;
					_whereAmt_ytd_bill = WhereAmt_ytd_bill;
					_whereAmt_ytd_rmaexm = WhereAmt_ytd_rmaexm;
					_whereAmt_mtd_paypot = WhereAmt_mtd_paypot;
					_whereAmt_mtd_gtypea = WhereAmt_mtd_gtypea;
					_whereAmt_mtd_rev_01 = WhereAmt_mtd_rev_01;
					_whereAmt_ytd_rev_01 = WhereAmt_ytd_rev_01;
					_whereAmt_mtd_rev_02 = WhereAmt_mtd_rev_02;
					_whereAmt_ytd_rev_02 = WhereAmt_ytd_rev_02;
					_whereAmt_mtd_rev_03 = WhereAmt_mtd_rev_03;
					_whereAmt_ytd_rev_03 = WhereAmt_ytd_rev_03;
					_whereAmt_mtd_rev_04 = WhereAmt_mtd_rev_04;
					_whereAmt_ytd_rev_04 = WhereAmt_ytd_rev_04;
					_whereAmt_mtd_rev_05 = WhereAmt_mtd_rev_05;
					_whereAmt_ytd_rev_05 = WhereAmt_ytd_rev_05;
					_whereAmt_mtd_rev_06 = WhereAmt_mtd_rev_06;
					_whereAmt_ytd_rev_06 = WhereAmt_ytd_rev_06;
					_whereAmt_mtd_rev_07 = WhereAmt_mtd_rev_07;
					_whereAmt_ytd_rev_07 = WhereAmt_ytd_rev_07;
					_whereAmt_mtd_rev_08 = WhereAmt_mtd_rev_08;
					_whereAmt_ytd_rev_08 = WhereAmt_ytd_rev_08;
					_whereAmt_mtd_rev_09 = WhereAmt_mtd_rev_09;
					_whereAmt_ytd_rev_09 = WhereAmt_ytd_rev_09;
					_whereAmt_mtd_rev_10 = WhereAmt_mtd_rev_10;
					_whereAmt_ytd_rev_10 = WhereAmt_ytd_rev_10;
					_whereAmt_mtd_rev_11 = WhereAmt_mtd_rev_11;
					_whereAmt_ytd_rev_11 = WhereAmt_ytd_rev_11;
					_whereAmt_mtd_rev_12 = WhereAmt_mtd_rev_12;
					_whereAmt_ytd_rev_12 = WhereAmt_ytd_rev_12;
					_whereAmt_mtd_rev_13 = WhereAmt_mtd_rev_13;
					_whereAmt_ytd_rev_13 = WhereAmt_ytd_rev_13;
					_whereAmt_mtd_rev_14 = WhereAmt_mtd_rev_14;
					_whereAmt_ytd_rev_14 = WhereAmt_ytd_rev_14;
					_whereAmt_mtd_rev_15 = WhereAmt_mtd_rev_15;
					_whereAmt_ytd_rev_15 = WhereAmt_ytd_rev_15;
					_whereAmt_mtd_rev_16 = WhereAmt_mtd_rev_16;
					_whereAmt_ytd_rev_16 = WhereAmt_ytd_rev_16;
					_whereAmt_mtd_rev_17 = WhereAmt_mtd_rev_17;
					_whereAmt_ytd_rev_17 = WhereAmt_ytd_rev_17;
					_whereAmt_mtd_rev_18 = WhereAmt_mtd_rev_18;
					_whereAmt_ytd_rev_18 = WhereAmt_ytd_rev_18;
					_whereAmt_mtd_rev_19 = WhereAmt_mtd_rev_19;
					_whereAmt_ytd_rev_19 = WhereAmt_ytd_rev_19;
					_whereAmt_mtd_rev_20 = WhereAmt_mtd_rev_20;
					_whereAmt_ytd_rev_20 = WhereAmt_ytd_rev_20;
					_whereAmt_ytd_rev_21 = WhereAmt_ytd_rev_21;
					_whereAmt_ytd_rev_22 = WhereAmt_ytd_rev_22;
					_whereAmt_ytd_rev_23 = WhereAmt_ytd_rev_23;
					_whereAmt_ytd_rev_24 = WhereAmt_ytd_rev_24;
					_whereAmt_ytd_rev_25 = WhereAmt_ytd_rev_25;
					_whereAmt_ytd_rev_26 = WhereAmt_ytd_rev_26;
					_whereAmt_ytd_rev_27 = WhereAmt_ytd_rev_27;
					_whereAmt_ytd_rev_28 = WhereAmt_ytd_rev_28;
					_whereAmt_ytd_rev_29 = WhereAmt_ytd_rev_29;
					_whereAmt_ytd_rev_30 = WhereAmt_ytd_rev_30;
					_whereAmt_ytd_rev_31 = WhereAmt_ytd_rev_31;
					_whereAmt_ytd_rev_32 = WhereAmt_ytd_rev_32;
					_whereAmt_ytd_rev_33 = WhereAmt_ytd_rev_33;
					_whereAmt_ytd_rev_34 = WhereAmt_ytd_rev_34;
					_whereAmt_ytd_rev_35 = WhereAmt_ytd_rev_35;
					_whereAmt_ytd_exp_01 = WhereAmt_ytd_exp_01;
					_whereAmt_ytd_exp_02 = WhereAmt_ytd_exp_02;
					_whereAmt_ytd_exp_03 = WhereAmt_ytd_exp_03;
					_whereAmt_ytd_exp_04 = WhereAmt_ytd_exp_04;
					_whereAmt_ytd_exp_05 = WhereAmt_ytd_exp_05;
					_whereAmt_ytd_exp_06 = WhereAmt_ytd_exp_06;
					_whereAmt_ytd_exp_07 = WhereAmt_ytd_exp_07;
					_whereAmt_ytd_exp_08 = WhereAmt_ytd_exp_08;
					_whereAmt_ytd_exp_09 = WhereAmt_ytd_exp_09;
					_whereAmt_ytd_exp_10 = WhereAmt_ytd_exp_10;
					_whereAmtytdtotincendoflastfiscalyear = WhereAmtytdtotincendoflastfiscalyear;
					_whereText_misc = WhereText_misc;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereCurrent_ep_nbr == null 
				&& WhereDoc_nbr == null 
				&& WhereDoc_dept == null 
				&& WhereDoc_ohip_nbr == null 
				&& WhereDoc_sin_nbr == null 
				&& WhereDoc_clinic_nbr == null 
				&& WhereDoc_spec_cd == null 
				&& WhereDoc_name == null 
				&& WhereDoc_inits == null 
				&& WhereDoc_yrly_ceiling_computed == null 
				&& WhereDoc_date_fac_start == null 
				&& WhereDoc_date_fac_term == null 
				&& WhereDoc_full_part_ind == null 
				&& WhereDoc_yrly_require_revenue == null 
				&& WhereDoc_guarantee_percentage == null 
				&& WhereDoc_guarantee_flag == null 
				&& WhereAmt_gross_ceiexp == null 
				&& WhereAmt_net_ytdcex == null 
				&& WhereDoc_pay_code == null 
				&& WhereDoc_pay_sub_code == null 
				&& WhereAmt_ytd_totinc == null 
				&& WhereAmt_ytd_incexp == null 
				&& WhereAmt_ytd_depexm == null 
				&& WhereAmt_ytd_depexr == null 
				&& WhereAmt_ytd_ytdear == null 
				&& WhereAmt_ytd_depchr == null 
				&& WhereAmt_mtd_payeft == null 
				&& WhereAmt_ytd_rmaexr == null 
				&& WhereAmt_ytd_gst == null 
				&& WhereAmt_ytd_bill == null 
				&& WhereAmt_ytd_rmaexm == null 
				&& WhereAmt_mtd_paypot == null 
				&& WhereAmt_mtd_gtypea == null 
				&& WhereAmt_mtd_rev_01 == null 
				&& WhereAmt_ytd_rev_01 == null 
				&& WhereAmt_mtd_rev_02 == null 
				&& WhereAmt_ytd_rev_02 == null 
				&& WhereAmt_mtd_rev_03 == null 
				&& WhereAmt_ytd_rev_03 == null 
				&& WhereAmt_mtd_rev_04 == null 
				&& WhereAmt_ytd_rev_04 == null 
				&& WhereAmt_mtd_rev_05 == null 
				&& WhereAmt_ytd_rev_05 == null 
				&& WhereAmt_mtd_rev_06 == null 
				&& WhereAmt_ytd_rev_06 == null 
				&& WhereAmt_mtd_rev_07 == null 
				&& WhereAmt_ytd_rev_07 == null 
				&& WhereAmt_mtd_rev_08 == null 
				&& WhereAmt_ytd_rev_08 == null 
				&& WhereAmt_mtd_rev_09 == null 
				&& WhereAmt_ytd_rev_09 == null 
				&& WhereAmt_mtd_rev_10 == null 
				&& WhereAmt_ytd_rev_10 == null 
				&& WhereAmt_mtd_rev_11 == null 
				&& WhereAmt_ytd_rev_11 == null 
				&& WhereAmt_mtd_rev_12 == null 
				&& WhereAmt_ytd_rev_12 == null 
				&& WhereAmt_mtd_rev_13 == null 
				&& WhereAmt_ytd_rev_13 == null 
				&& WhereAmt_mtd_rev_14 == null 
				&& WhereAmt_ytd_rev_14 == null 
				&& WhereAmt_mtd_rev_15 == null 
				&& WhereAmt_ytd_rev_15 == null 
				&& WhereAmt_mtd_rev_16 == null 
				&& WhereAmt_ytd_rev_16 == null 
				&& WhereAmt_mtd_rev_17 == null 
				&& WhereAmt_ytd_rev_17 == null 
				&& WhereAmt_mtd_rev_18 == null 
				&& WhereAmt_ytd_rev_18 == null 
				&& WhereAmt_mtd_rev_19 == null 
				&& WhereAmt_ytd_rev_19 == null 
				&& WhereAmt_mtd_rev_20 == null 
				&& WhereAmt_ytd_rev_20 == null 
				&& WhereAmt_ytd_rev_21 == null 
				&& WhereAmt_ytd_rev_22 == null 
				&& WhereAmt_ytd_rev_23 == null 
				&& WhereAmt_ytd_rev_24 == null 
				&& WhereAmt_ytd_rev_25 == null 
				&& WhereAmt_ytd_rev_26 == null 
				&& WhereAmt_ytd_rev_27 == null 
				&& WhereAmt_ytd_rev_28 == null 
				&& WhereAmt_ytd_rev_29 == null 
				&& WhereAmt_ytd_rev_30 == null 
				&& WhereAmt_ytd_rev_31 == null 
				&& WhereAmt_ytd_rev_32 == null 
				&& WhereAmt_ytd_rev_33 == null 
				&& WhereAmt_ytd_rev_34 == null 
				&& WhereAmt_ytd_rev_35 == null 
				&& WhereAmt_ytd_exp_01 == null 
				&& WhereAmt_ytd_exp_02 == null 
				&& WhereAmt_ytd_exp_03 == null 
				&& WhereAmt_ytd_exp_04 == null 
				&& WhereAmt_ytd_exp_05 == null 
				&& WhereAmt_ytd_exp_06 == null 
				&& WhereAmt_ytd_exp_07 == null 
				&& WhereAmt_ytd_exp_08 == null 
				&& WhereAmt_ytd_exp_09 == null 
				&& WhereAmt_ytd_exp_10 == null 
				&& WhereAmtytdtotincendoflastfiscalyear == null 
				&& WhereText_misc == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereCurrent_ep_nbr ==  _whereCurrent_ep_nbr
				&& WhereDoc_nbr ==  _whereDoc_nbr
				&& WhereDoc_dept ==  _whereDoc_dept
				&& WhereDoc_ohip_nbr ==  _whereDoc_ohip_nbr
				&& WhereDoc_sin_nbr ==  _whereDoc_sin_nbr
				&& WhereDoc_clinic_nbr ==  _whereDoc_clinic_nbr
				&& WhereDoc_spec_cd ==  _whereDoc_spec_cd
				&& WhereDoc_name ==  _whereDoc_name
				&& WhereDoc_inits ==  _whereDoc_inits
				&& WhereDoc_yrly_ceiling_computed ==  _whereDoc_yrly_ceiling_computed
				&& WhereDoc_date_fac_start ==  _whereDoc_date_fac_start
				&& WhereDoc_date_fac_term ==  _whereDoc_date_fac_term
				&& WhereDoc_full_part_ind ==  _whereDoc_full_part_ind
				&& WhereDoc_yrly_require_revenue ==  _whereDoc_yrly_require_revenue
				&& WhereDoc_guarantee_percentage ==  _whereDoc_guarantee_percentage
				&& WhereDoc_guarantee_flag ==  _whereDoc_guarantee_flag
				&& WhereAmt_gross_ceiexp ==  _whereAmt_gross_ceiexp
				&& WhereAmt_net_ytdcex ==  _whereAmt_net_ytdcex
				&& WhereDoc_pay_code ==  _whereDoc_pay_code
				&& WhereDoc_pay_sub_code ==  _whereDoc_pay_sub_code
				&& WhereAmt_ytd_totinc ==  _whereAmt_ytd_totinc
				&& WhereAmt_ytd_incexp ==  _whereAmt_ytd_incexp
				&& WhereAmt_ytd_depexm ==  _whereAmt_ytd_depexm
				&& WhereAmt_ytd_depexr ==  _whereAmt_ytd_depexr
				&& WhereAmt_ytd_ytdear ==  _whereAmt_ytd_ytdear
				&& WhereAmt_ytd_depchr ==  _whereAmt_ytd_depchr
				&& WhereAmt_mtd_payeft ==  _whereAmt_mtd_payeft
				&& WhereAmt_ytd_rmaexr ==  _whereAmt_ytd_rmaexr
				&& WhereAmt_ytd_gst ==  _whereAmt_ytd_gst
				&& WhereAmt_ytd_bill ==  _whereAmt_ytd_bill
				&& WhereAmt_ytd_rmaexm ==  _whereAmt_ytd_rmaexm
				&& WhereAmt_mtd_paypot ==  _whereAmt_mtd_paypot
				&& WhereAmt_mtd_gtypea ==  _whereAmt_mtd_gtypea
				&& WhereAmt_mtd_rev_01 ==  _whereAmt_mtd_rev_01
				&& WhereAmt_ytd_rev_01 ==  _whereAmt_ytd_rev_01
				&& WhereAmt_mtd_rev_02 ==  _whereAmt_mtd_rev_02
				&& WhereAmt_ytd_rev_02 ==  _whereAmt_ytd_rev_02
				&& WhereAmt_mtd_rev_03 ==  _whereAmt_mtd_rev_03
				&& WhereAmt_ytd_rev_03 ==  _whereAmt_ytd_rev_03
				&& WhereAmt_mtd_rev_04 ==  _whereAmt_mtd_rev_04
				&& WhereAmt_ytd_rev_04 ==  _whereAmt_ytd_rev_04
				&& WhereAmt_mtd_rev_05 ==  _whereAmt_mtd_rev_05
				&& WhereAmt_ytd_rev_05 ==  _whereAmt_ytd_rev_05
				&& WhereAmt_mtd_rev_06 ==  _whereAmt_mtd_rev_06
				&& WhereAmt_ytd_rev_06 ==  _whereAmt_ytd_rev_06
				&& WhereAmt_mtd_rev_07 ==  _whereAmt_mtd_rev_07
				&& WhereAmt_ytd_rev_07 ==  _whereAmt_ytd_rev_07
				&& WhereAmt_mtd_rev_08 ==  _whereAmt_mtd_rev_08
				&& WhereAmt_ytd_rev_08 ==  _whereAmt_ytd_rev_08
				&& WhereAmt_mtd_rev_09 ==  _whereAmt_mtd_rev_09
				&& WhereAmt_ytd_rev_09 ==  _whereAmt_ytd_rev_09
				&& WhereAmt_mtd_rev_10 ==  _whereAmt_mtd_rev_10
				&& WhereAmt_ytd_rev_10 ==  _whereAmt_ytd_rev_10
				&& WhereAmt_mtd_rev_11 ==  _whereAmt_mtd_rev_11
				&& WhereAmt_ytd_rev_11 ==  _whereAmt_ytd_rev_11
				&& WhereAmt_mtd_rev_12 ==  _whereAmt_mtd_rev_12
				&& WhereAmt_ytd_rev_12 ==  _whereAmt_ytd_rev_12
				&& WhereAmt_mtd_rev_13 ==  _whereAmt_mtd_rev_13
				&& WhereAmt_ytd_rev_13 ==  _whereAmt_ytd_rev_13
				&& WhereAmt_mtd_rev_14 ==  _whereAmt_mtd_rev_14
				&& WhereAmt_ytd_rev_14 ==  _whereAmt_ytd_rev_14
				&& WhereAmt_mtd_rev_15 ==  _whereAmt_mtd_rev_15
				&& WhereAmt_ytd_rev_15 ==  _whereAmt_ytd_rev_15
				&& WhereAmt_mtd_rev_16 ==  _whereAmt_mtd_rev_16
				&& WhereAmt_ytd_rev_16 ==  _whereAmt_ytd_rev_16
				&& WhereAmt_mtd_rev_17 ==  _whereAmt_mtd_rev_17
				&& WhereAmt_ytd_rev_17 ==  _whereAmt_ytd_rev_17
				&& WhereAmt_mtd_rev_18 ==  _whereAmt_mtd_rev_18
				&& WhereAmt_ytd_rev_18 ==  _whereAmt_ytd_rev_18
				&& WhereAmt_mtd_rev_19 ==  _whereAmt_mtd_rev_19
				&& WhereAmt_ytd_rev_19 ==  _whereAmt_ytd_rev_19
				&& WhereAmt_mtd_rev_20 ==  _whereAmt_mtd_rev_20
				&& WhereAmt_ytd_rev_20 ==  _whereAmt_ytd_rev_20
				&& WhereAmt_ytd_rev_21 ==  _whereAmt_ytd_rev_21
				&& WhereAmt_ytd_rev_22 ==  _whereAmt_ytd_rev_22
				&& WhereAmt_ytd_rev_23 ==  _whereAmt_ytd_rev_23
				&& WhereAmt_ytd_rev_24 ==  _whereAmt_ytd_rev_24
				&& WhereAmt_ytd_rev_25 ==  _whereAmt_ytd_rev_25
				&& WhereAmt_ytd_rev_26 ==  _whereAmt_ytd_rev_26
				&& WhereAmt_ytd_rev_27 ==  _whereAmt_ytd_rev_27
				&& WhereAmt_ytd_rev_28 ==  _whereAmt_ytd_rev_28
				&& WhereAmt_ytd_rev_29 ==  _whereAmt_ytd_rev_29
				&& WhereAmt_ytd_rev_30 ==  _whereAmt_ytd_rev_30
				&& WhereAmt_ytd_rev_31 ==  _whereAmt_ytd_rev_31
				&& WhereAmt_ytd_rev_32 ==  _whereAmt_ytd_rev_32
				&& WhereAmt_ytd_rev_33 ==  _whereAmt_ytd_rev_33
				&& WhereAmt_ytd_rev_34 ==  _whereAmt_ytd_rev_34
				&& WhereAmt_ytd_rev_35 ==  _whereAmt_ytd_rev_35
				&& WhereAmt_ytd_exp_01 ==  _whereAmt_ytd_exp_01
				&& WhereAmt_ytd_exp_02 ==  _whereAmt_ytd_exp_02
				&& WhereAmt_ytd_exp_03 ==  _whereAmt_ytd_exp_03
				&& WhereAmt_ytd_exp_04 ==  _whereAmt_ytd_exp_04
				&& WhereAmt_ytd_exp_05 ==  _whereAmt_ytd_exp_05
				&& WhereAmt_ytd_exp_06 ==  _whereAmt_ytd_exp_06
				&& WhereAmt_ytd_exp_07 ==  _whereAmt_ytd_exp_07
				&& WhereAmt_ytd_exp_08 ==  _whereAmt_ytd_exp_08
				&& WhereAmt_ytd_exp_09 ==  _whereAmt_ytd_exp_09
				&& WhereAmt_ytd_exp_10 ==  _whereAmt_ytd_exp_10
				&& WhereAmtytdtotincendoflastfiscalyear ==  _whereAmtytdtotincendoflastfiscalyear
				&& WhereText_misc ==  _whereText_misc
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereCurrent_ep_nbr = null; 
			WhereDoc_nbr = null; 
			WhereDoc_dept = null; 
			WhereDoc_ohip_nbr = null; 
			WhereDoc_sin_nbr = null; 
			WhereDoc_clinic_nbr = null; 
			WhereDoc_spec_cd = null; 
			WhereDoc_name = null; 
			WhereDoc_inits = null; 
			WhereDoc_yrly_ceiling_computed = null; 
			WhereDoc_date_fac_start = null; 
			WhereDoc_date_fac_term = null; 
			WhereDoc_full_part_ind = null; 
			WhereDoc_yrly_require_revenue = null; 
			WhereDoc_guarantee_percentage = null; 
			WhereDoc_guarantee_flag = null; 
			WhereAmt_gross_ceiexp = null; 
			WhereAmt_net_ytdcex = null; 
			WhereDoc_pay_code = null; 
			WhereDoc_pay_sub_code = null; 
			WhereAmt_ytd_totinc = null; 
			WhereAmt_ytd_incexp = null; 
			WhereAmt_ytd_depexm = null; 
			WhereAmt_ytd_depexr = null; 
			WhereAmt_ytd_ytdear = null; 
			WhereAmt_ytd_depchr = null; 
			WhereAmt_mtd_payeft = null; 
			WhereAmt_ytd_rmaexr = null; 
			WhereAmt_ytd_gst = null; 
			WhereAmt_ytd_bill = null; 
			WhereAmt_ytd_rmaexm = null; 
			WhereAmt_mtd_paypot = null; 
			WhereAmt_mtd_gtypea = null; 
			WhereAmt_mtd_rev_01 = null; 
			WhereAmt_ytd_rev_01 = null; 
			WhereAmt_mtd_rev_02 = null; 
			WhereAmt_ytd_rev_02 = null; 
			WhereAmt_mtd_rev_03 = null; 
			WhereAmt_ytd_rev_03 = null; 
			WhereAmt_mtd_rev_04 = null; 
			WhereAmt_ytd_rev_04 = null; 
			WhereAmt_mtd_rev_05 = null; 
			WhereAmt_ytd_rev_05 = null; 
			WhereAmt_mtd_rev_06 = null; 
			WhereAmt_ytd_rev_06 = null; 
			WhereAmt_mtd_rev_07 = null; 
			WhereAmt_ytd_rev_07 = null; 
			WhereAmt_mtd_rev_08 = null; 
			WhereAmt_ytd_rev_08 = null; 
			WhereAmt_mtd_rev_09 = null; 
			WhereAmt_ytd_rev_09 = null; 
			WhereAmt_mtd_rev_10 = null; 
			WhereAmt_ytd_rev_10 = null; 
			WhereAmt_mtd_rev_11 = null; 
			WhereAmt_ytd_rev_11 = null; 
			WhereAmt_mtd_rev_12 = null; 
			WhereAmt_ytd_rev_12 = null; 
			WhereAmt_mtd_rev_13 = null; 
			WhereAmt_ytd_rev_13 = null; 
			WhereAmt_mtd_rev_14 = null; 
			WhereAmt_ytd_rev_14 = null; 
			WhereAmt_mtd_rev_15 = null; 
			WhereAmt_ytd_rev_15 = null; 
			WhereAmt_mtd_rev_16 = null; 
			WhereAmt_ytd_rev_16 = null; 
			WhereAmt_mtd_rev_17 = null; 
			WhereAmt_ytd_rev_17 = null; 
			WhereAmt_mtd_rev_18 = null; 
			WhereAmt_ytd_rev_18 = null; 
			WhereAmt_mtd_rev_19 = null; 
			WhereAmt_ytd_rev_19 = null; 
			WhereAmt_mtd_rev_20 = null; 
			WhereAmt_ytd_rev_20 = null; 
			WhereAmt_ytd_rev_21 = null; 
			WhereAmt_ytd_rev_22 = null; 
			WhereAmt_ytd_rev_23 = null; 
			WhereAmt_ytd_rev_24 = null; 
			WhereAmt_ytd_rev_25 = null; 
			WhereAmt_ytd_rev_26 = null; 
			WhereAmt_ytd_rev_27 = null; 
			WhereAmt_ytd_rev_28 = null; 
			WhereAmt_ytd_rev_29 = null; 
			WhereAmt_ytd_rev_30 = null; 
			WhereAmt_ytd_rev_31 = null; 
			WhereAmt_ytd_rev_32 = null; 
			WhereAmt_ytd_rev_33 = null; 
			WhereAmt_ytd_rev_34 = null; 
			WhereAmt_ytd_rev_35 = null; 
			WhereAmt_ytd_exp_01 = null; 
			WhereAmt_ytd_exp_02 = null; 
			WhereAmt_ytd_exp_03 = null; 
			WhereAmt_ytd_exp_04 = null; 
			WhereAmt_ytd_exp_05 = null; 
			WhereAmt_ytd_exp_06 = null; 
			WhereAmt_ytd_exp_07 = null; 
			WhereAmt_ytd_exp_08 = null; 
			WhereAmt_ytd_exp_09 = null; 
			WhereAmt_ytd_exp_10 = null; 
			WhereAmtytdtotincendoflastfiscalyear = null; 
			WhereText_misc = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CURRENT_EP_NBR;
		private string _DOC_NBR;
		private decimal? _DOC_DEPT;
		private decimal? _DOC_OHIP_NBR;
		private decimal? _DOC_SIN_NBR;
		private decimal? _DOC_CLINIC_NBR;
		private decimal? _DOC_SPEC_CD;
		private string _DOC_NAME;
		private string _DOC_INITS;
		private decimal? _DOC_YRLY_CEILING_COMPUTED;
		private decimal? _DOC_DATE_FAC_START;
		private decimal? _DOC_DATE_FAC_TERM;
		private string _DOC_FULL_PART_IND;
		private decimal? _DOC_YRLY_REQUIRE_REVENUE;
		private decimal? _DOC_GUARANTEE_PERCENTAGE;
		private string _DOC_GUARANTEE_FLAG;
		private decimal? _AMT_GROSS_CEIEXP;
		private decimal? _AMT_NET_YTDCEX;
		private string _DOC_PAY_CODE;
		private string _DOC_PAY_SUB_CODE;
		private decimal? _AMT_YTD_TOTINC;
		private decimal? _AMT_YTD_INCEXP;
		private decimal? _AMT_YTD_DEPEXM;
		private decimal? _AMT_YTD_DEPEXR;
		private decimal? _AMT_YTD_YTDEAR;
		private decimal? _AMT_YTD_DEPCHR;
		private decimal? _AMT_MTD_PAYEFT;
		private decimal? _AMT_YTD_RMAEXR;
		private decimal? _AMT_YTD_GST;
		private decimal? _AMT_YTD_BILL;
		private decimal? _AMT_YTD_RMAEXM;
		private decimal? _AMT_MTD_PAYPOT;
		private decimal? _AMT_MTD_GTYPEA;
		private decimal? _AMT_MTD_REV_01;
		private decimal? _AMT_YTD_REV_01;
		private decimal? _AMT_MTD_REV_02;
		private decimal? _AMT_YTD_REV_02;
		private decimal? _AMT_MTD_REV_03;
		private decimal? _AMT_YTD_REV_03;
		private decimal? _AMT_MTD_REV_04;
		private decimal? _AMT_YTD_REV_04;
		private decimal? _AMT_MTD_REV_05;
		private decimal? _AMT_YTD_REV_05;
		private decimal? _AMT_MTD_REV_06;
		private decimal? _AMT_YTD_REV_06;
		private decimal? _AMT_MTD_REV_07;
		private decimal? _AMT_YTD_REV_07;
		private decimal? _AMT_MTD_REV_08;
		private decimal? _AMT_YTD_REV_08;
		private decimal? _AMT_MTD_REV_09;
		private decimal? _AMT_YTD_REV_09;
		private decimal? _AMT_MTD_REV_10;
		private decimal? _AMT_YTD_REV_10;
		private decimal? _AMT_MTD_REV_11;
		private decimal? _AMT_YTD_REV_11;
		private decimal? _AMT_MTD_REV_12;
		private decimal? _AMT_YTD_REV_12;
		private decimal? _AMT_MTD_REV_13;
		private decimal? _AMT_YTD_REV_13;
		private decimal? _AMT_MTD_REV_14;
		private decimal? _AMT_YTD_REV_14;
		private decimal? _AMT_MTD_REV_15;
		private decimal? _AMT_YTD_REV_15;
		private decimal? _AMT_MTD_REV_16;
		private decimal? _AMT_YTD_REV_16;
		private decimal? _AMT_MTD_REV_17;
		private decimal? _AMT_YTD_REV_17;
		private decimal? _AMT_MTD_REV_18;
		private decimal? _AMT_YTD_REV_18;
		private decimal? _AMT_MTD_REV_19;
		private decimal? _AMT_YTD_REV_19;
		private decimal? _AMT_MTD_REV_20;
		private decimal? _AMT_YTD_REV_20;
		private decimal? _AMT_YTD_REV_21;
		private decimal? _AMT_YTD_REV_22;
		private decimal? _AMT_YTD_REV_23;
		private decimal? _AMT_YTD_REV_24;
		private decimal? _AMT_YTD_REV_25;
		private decimal? _AMT_YTD_REV_26;
		private decimal? _AMT_YTD_REV_27;
		private decimal? _AMT_YTD_REV_28;
		private decimal? _AMT_YTD_REV_29;
		private decimal? _AMT_YTD_REV_30;
		private decimal? _AMT_YTD_REV_31;
		private decimal? _AMT_YTD_REV_32;
		private decimal? _AMT_YTD_REV_33;
		private decimal? _AMT_YTD_REV_34;
		private decimal? _AMT_YTD_REV_35;
		private decimal? _AMT_YTD_EXP_01;
		private decimal? _AMT_YTD_EXP_02;
		private decimal? _AMT_YTD_EXP_03;
		private decimal? _AMT_YTD_EXP_04;
		private decimal? _AMT_YTD_EXP_05;
		private decimal? _AMT_YTD_EXP_06;
		private decimal? _AMT_YTD_EXP_07;
		private decimal? _AMT_YTD_EXP_08;
		private decimal? _AMT_YTD_EXP_09;
		private decimal? _AMT_YTD_EXP_10;
		private decimal? _AMTYTDTOTINCENDOFLASTFISCALYEAR;
		private string _TEXT_MISC;
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
		public decimal? CURRENT_EP_NBR
		{
			get { return _CURRENT_EP_NBR; }
			set
			{
				if (_CURRENT_EP_NBR != value)
				{
					_CURRENT_EP_NBR = value;
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
		public decimal? DOC_CLINIC_NBR
		{
			get { return _DOC_CLINIC_NBR; }
			set
			{
				if (_DOC_CLINIC_NBR != value)
				{
					_DOC_CLINIC_NBR = value;
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
		public decimal? DOC_GUARANTEE_PERCENTAGE
		{
			get { return _DOC_GUARANTEE_PERCENTAGE; }
			set
			{
				if (_DOC_GUARANTEE_PERCENTAGE != value)
				{
					_DOC_GUARANTEE_PERCENTAGE = value;
					ChangeState();
				}
			}
		}
		public string DOC_GUARANTEE_FLAG
		{
			get { return _DOC_GUARANTEE_FLAG; }
			set
			{
				if (_DOC_GUARANTEE_FLAG != value)
				{
					_DOC_GUARANTEE_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_GROSS_CEIEXP
		{
			get { return _AMT_GROSS_CEIEXP; }
			set
			{
				if (_AMT_GROSS_CEIEXP != value)
				{
					_AMT_GROSS_CEIEXP = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_NET_YTDCEX
		{
			get { return _AMT_NET_YTDCEX; }
			set
			{
				if (_AMT_NET_YTDCEX != value)
				{
					_AMT_NET_YTDCEX = value;
					ChangeState();
				}
			}
		}
		public string DOC_PAY_CODE
		{
			get { return _DOC_PAY_CODE; }
			set
			{
				if (_DOC_PAY_CODE != value)
				{
					_DOC_PAY_CODE = value;
					ChangeState();
				}
			}
		}
		public string DOC_PAY_SUB_CODE
		{
			get { return _DOC_PAY_SUB_CODE; }
			set
			{
				if (_DOC_PAY_SUB_CODE != value)
				{
					_DOC_PAY_SUB_CODE = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_TOTINC
		{
			get { return _AMT_YTD_TOTINC; }
			set
			{
				if (_AMT_YTD_TOTINC != value)
				{
					_AMT_YTD_TOTINC = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_INCEXP
		{
			get { return _AMT_YTD_INCEXP; }
			set
			{
				if (_AMT_YTD_INCEXP != value)
				{
					_AMT_YTD_INCEXP = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_DEPEXM
		{
			get { return _AMT_YTD_DEPEXM; }
			set
			{
				if (_AMT_YTD_DEPEXM != value)
				{
					_AMT_YTD_DEPEXM = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_DEPEXR
		{
			get { return _AMT_YTD_DEPEXR; }
			set
			{
				if (_AMT_YTD_DEPEXR != value)
				{
					_AMT_YTD_DEPEXR = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_YTDEAR
		{
			get { return _AMT_YTD_YTDEAR; }
			set
			{
				if (_AMT_YTD_YTDEAR != value)
				{
					_AMT_YTD_YTDEAR = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_DEPCHR
		{
			get { return _AMT_YTD_DEPCHR; }
			set
			{
				if (_AMT_YTD_DEPCHR != value)
				{
					_AMT_YTD_DEPCHR = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_PAYEFT
		{
			get { return _AMT_MTD_PAYEFT; }
			set
			{
				if (_AMT_MTD_PAYEFT != value)
				{
					_AMT_MTD_PAYEFT = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_RMAEXR
		{
			get { return _AMT_YTD_RMAEXR; }
			set
			{
				if (_AMT_YTD_RMAEXR != value)
				{
					_AMT_YTD_RMAEXR = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_GST
		{
			get { return _AMT_YTD_GST; }
			set
			{
				if (_AMT_YTD_GST != value)
				{
					_AMT_YTD_GST = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_BILL
		{
			get { return _AMT_YTD_BILL; }
			set
			{
				if (_AMT_YTD_BILL != value)
				{
					_AMT_YTD_BILL = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_RMAEXM
		{
			get { return _AMT_YTD_RMAEXM; }
			set
			{
				if (_AMT_YTD_RMAEXM != value)
				{
					_AMT_YTD_RMAEXM = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_PAYPOT
		{
			get { return _AMT_MTD_PAYPOT; }
			set
			{
				if (_AMT_MTD_PAYPOT != value)
				{
					_AMT_MTD_PAYPOT = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_GTYPEA
		{
			get { return _AMT_MTD_GTYPEA; }
			set
			{
				if (_AMT_MTD_GTYPEA != value)
				{
					_AMT_MTD_GTYPEA = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_01
		{
			get { return _AMT_MTD_REV_01; }
			set
			{
				if (_AMT_MTD_REV_01 != value)
				{
					_AMT_MTD_REV_01 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_01
		{
			get { return _AMT_YTD_REV_01; }
			set
			{
				if (_AMT_YTD_REV_01 != value)
				{
					_AMT_YTD_REV_01 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_02
		{
			get { return _AMT_MTD_REV_02; }
			set
			{
				if (_AMT_MTD_REV_02 != value)
				{
					_AMT_MTD_REV_02 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_02
		{
			get { return _AMT_YTD_REV_02; }
			set
			{
				if (_AMT_YTD_REV_02 != value)
				{
					_AMT_YTD_REV_02 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_03
		{
			get { return _AMT_MTD_REV_03; }
			set
			{
				if (_AMT_MTD_REV_03 != value)
				{
					_AMT_MTD_REV_03 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_03
		{
			get { return _AMT_YTD_REV_03; }
			set
			{
				if (_AMT_YTD_REV_03 != value)
				{
					_AMT_YTD_REV_03 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_04
		{
			get { return _AMT_MTD_REV_04; }
			set
			{
				if (_AMT_MTD_REV_04 != value)
				{
					_AMT_MTD_REV_04 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_04
		{
			get { return _AMT_YTD_REV_04; }
			set
			{
				if (_AMT_YTD_REV_04 != value)
				{
					_AMT_YTD_REV_04 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_05
		{
			get { return _AMT_MTD_REV_05; }
			set
			{
				if (_AMT_MTD_REV_05 != value)
				{
					_AMT_MTD_REV_05 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_05
		{
			get { return _AMT_YTD_REV_05; }
			set
			{
				if (_AMT_YTD_REV_05 != value)
				{
					_AMT_YTD_REV_05 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_06
		{
			get { return _AMT_MTD_REV_06; }
			set
			{
				if (_AMT_MTD_REV_06 != value)
				{
					_AMT_MTD_REV_06 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_06
		{
			get { return _AMT_YTD_REV_06; }
			set
			{
				if (_AMT_YTD_REV_06 != value)
				{
					_AMT_YTD_REV_06 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_07
		{
			get { return _AMT_MTD_REV_07; }
			set
			{
				if (_AMT_MTD_REV_07 != value)
				{
					_AMT_MTD_REV_07 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_07
		{
			get { return _AMT_YTD_REV_07; }
			set
			{
				if (_AMT_YTD_REV_07 != value)
				{
					_AMT_YTD_REV_07 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_08
		{
			get { return _AMT_MTD_REV_08; }
			set
			{
				if (_AMT_MTD_REV_08 != value)
				{
					_AMT_MTD_REV_08 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_08
		{
			get { return _AMT_YTD_REV_08; }
			set
			{
				if (_AMT_YTD_REV_08 != value)
				{
					_AMT_YTD_REV_08 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_09
		{
			get { return _AMT_MTD_REV_09; }
			set
			{
				if (_AMT_MTD_REV_09 != value)
				{
					_AMT_MTD_REV_09 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_09
		{
			get { return _AMT_YTD_REV_09; }
			set
			{
				if (_AMT_YTD_REV_09 != value)
				{
					_AMT_YTD_REV_09 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_10
		{
			get { return _AMT_MTD_REV_10; }
			set
			{
				if (_AMT_MTD_REV_10 != value)
				{
					_AMT_MTD_REV_10 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_10
		{
			get { return _AMT_YTD_REV_10; }
			set
			{
				if (_AMT_YTD_REV_10 != value)
				{
					_AMT_YTD_REV_10 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_11
		{
			get { return _AMT_MTD_REV_11; }
			set
			{
				if (_AMT_MTD_REV_11 != value)
				{
					_AMT_MTD_REV_11 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_11
		{
			get { return _AMT_YTD_REV_11; }
			set
			{
				if (_AMT_YTD_REV_11 != value)
				{
					_AMT_YTD_REV_11 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_12
		{
			get { return _AMT_MTD_REV_12; }
			set
			{
				if (_AMT_MTD_REV_12 != value)
				{
					_AMT_MTD_REV_12 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_12
		{
			get { return _AMT_YTD_REV_12; }
			set
			{
				if (_AMT_YTD_REV_12 != value)
				{
					_AMT_YTD_REV_12 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_13
		{
			get { return _AMT_MTD_REV_13; }
			set
			{
				if (_AMT_MTD_REV_13 != value)
				{
					_AMT_MTD_REV_13 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_13
		{
			get { return _AMT_YTD_REV_13; }
			set
			{
				if (_AMT_YTD_REV_13 != value)
				{
					_AMT_YTD_REV_13 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_14
		{
			get { return _AMT_MTD_REV_14; }
			set
			{
				if (_AMT_MTD_REV_14 != value)
				{
					_AMT_MTD_REV_14 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_14
		{
			get { return _AMT_YTD_REV_14; }
			set
			{
				if (_AMT_YTD_REV_14 != value)
				{
					_AMT_YTD_REV_14 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_15
		{
			get { return _AMT_MTD_REV_15; }
			set
			{
				if (_AMT_MTD_REV_15 != value)
				{
					_AMT_MTD_REV_15 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_15
		{
			get { return _AMT_YTD_REV_15; }
			set
			{
				if (_AMT_YTD_REV_15 != value)
				{
					_AMT_YTD_REV_15 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_16
		{
			get { return _AMT_MTD_REV_16; }
			set
			{
				if (_AMT_MTD_REV_16 != value)
				{
					_AMT_MTD_REV_16 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_16
		{
			get { return _AMT_YTD_REV_16; }
			set
			{
				if (_AMT_YTD_REV_16 != value)
				{
					_AMT_YTD_REV_16 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_17
		{
			get { return _AMT_MTD_REV_17; }
			set
			{
				if (_AMT_MTD_REV_17 != value)
				{
					_AMT_MTD_REV_17 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_17
		{
			get { return _AMT_YTD_REV_17; }
			set
			{
				if (_AMT_YTD_REV_17 != value)
				{
					_AMT_YTD_REV_17 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_18
		{
			get { return _AMT_MTD_REV_18; }
			set
			{
				if (_AMT_MTD_REV_18 != value)
				{
					_AMT_MTD_REV_18 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_18
		{
			get { return _AMT_YTD_REV_18; }
			set
			{
				if (_AMT_YTD_REV_18 != value)
				{
					_AMT_YTD_REV_18 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_19
		{
			get { return _AMT_MTD_REV_19; }
			set
			{
				if (_AMT_MTD_REV_19 != value)
				{
					_AMT_MTD_REV_19 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_19
		{
			get { return _AMT_YTD_REV_19; }
			set
			{
				if (_AMT_YTD_REV_19 != value)
				{
					_AMT_YTD_REV_19 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_MTD_REV_20
		{
			get { return _AMT_MTD_REV_20; }
			set
			{
				if (_AMT_MTD_REV_20 != value)
				{
					_AMT_MTD_REV_20 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_20
		{
			get { return _AMT_YTD_REV_20; }
			set
			{
				if (_AMT_YTD_REV_20 != value)
				{
					_AMT_YTD_REV_20 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_21
		{
			get { return _AMT_YTD_REV_21; }
			set
			{
				if (_AMT_YTD_REV_21 != value)
				{
					_AMT_YTD_REV_21 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_22
		{
			get { return _AMT_YTD_REV_22; }
			set
			{
				if (_AMT_YTD_REV_22 != value)
				{
					_AMT_YTD_REV_22 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_23
		{
			get { return _AMT_YTD_REV_23; }
			set
			{
				if (_AMT_YTD_REV_23 != value)
				{
					_AMT_YTD_REV_23 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_24
		{
			get { return _AMT_YTD_REV_24; }
			set
			{
				if (_AMT_YTD_REV_24 != value)
				{
					_AMT_YTD_REV_24 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_25
		{
			get { return _AMT_YTD_REV_25; }
			set
			{
				if (_AMT_YTD_REV_25 != value)
				{
					_AMT_YTD_REV_25 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_26
		{
			get { return _AMT_YTD_REV_26; }
			set
			{
				if (_AMT_YTD_REV_26 != value)
				{
					_AMT_YTD_REV_26 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_27
		{
			get { return _AMT_YTD_REV_27; }
			set
			{
				if (_AMT_YTD_REV_27 != value)
				{
					_AMT_YTD_REV_27 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_28
		{
			get { return _AMT_YTD_REV_28; }
			set
			{
				if (_AMT_YTD_REV_28 != value)
				{
					_AMT_YTD_REV_28 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_29
		{
			get { return _AMT_YTD_REV_29; }
			set
			{
				if (_AMT_YTD_REV_29 != value)
				{
					_AMT_YTD_REV_29 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_30
		{
			get { return _AMT_YTD_REV_30; }
			set
			{
				if (_AMT_YTD_REV_30 != value)
				{
					_AMT_YTD_REV_30 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_31
		{
			get { return _AMT_YTD_REV_31; }
			set
			{
				if (_AMT_YTD_REV_31 != value)
				{
					_AMT_YTD_REV_31 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_32
		{
			get { return _AMT_YTD_REV_32; }
			set
			{
				if (_AMT_YTD_REV_32 != value)
				{
					_AMT_YTD_REV_32 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_33
		{
			get { return _AMT_YTD_REV_33; }
			set
			{
				if (_AMT_YTD_REV_33 != value)
				{
					_AMT_YTD_REV_33 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_34
		{
			get { return _AMT_YTD_REV_34; }
			set
			{
				if (_AMT_YTD_REV_34 != value)
				{
					_AMT_YTD_REV_34 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_REV_35
		{
			get { return _AMT_YTD_REV_35; }
			set
			{
				if (_AMT_YTD_REV_35 != value)
				{
					_AMT_YTD_REV_35 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_01
		{
			get { return _AMT_YTD_EXP_01; }
			set
			{
				if (_AMT_YTD_EXP_01 != value)
				{
					_AMT_YTD_EXP_01 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_02
		{
			get { return _AMT_YTD_EXP_02; }
			set
			{
				if (_AMT_YTD_EXP_02 != value)
				{
					_AMT_YTD_EXP_02 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_03
		{
			get { return _AMT_YTD_EXP_03; }
			set
			{
				if (_AMT_YTD_EXP_03 != value)
				{
					_AMT_YTD_EXP_03 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_04
		{
			get { return _AMT_YTD_EXP_04; }
			set
			{
				if (_AMT_YTD_EXP_04 != value)
				{
					_AMT_YTD_EXP_04 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_05
		{
			get { return _AMT_YTD_EXP_05; }
			set
			{
				if (_AMT_YTD_EXP_05 != value)
				{
					_AMT_YTD_EXP_05 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_06
		{
			get { return _AMT_YTD_EXP_06; }
			set
			{
				if (_AMT_YTD_EXP_06 != value)
				{
					_AMT_YTD_EXP_06 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_07
		{
			get { return _AMT_YTD_EXP_07; }
			set
			{
				if (_AMT_YTD_EXP_07 != value)
				{
					_AMT_YTD_EXP_07 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_08
		{
			get { return _AMT_YTD_EXP_08; }
			set
			{
				if (_AMT_YTD_EXP_08 != value)
				{
					_AMT_YTD_EXP_08 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_09
		{
			get { return _AMT_YTD_EXP_09; }
			set
			{
				if (_AMT_YTD_EXP_09 != value)
				{
					_AMT_YTD_EXP_09 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_YTD_EXP_10
		{
			get { return _AMT_YTD_EXP_10; }
			set
			{
				if (_AMT_YTD_EXP_10 != value)
				{
					_AMT_YTD_EXP_10 = value;
					ChangeState();
				}
			}
		}
		public decimal? AMTYTDTOTINCENDOFLASTFISCALYEAR
		{
			get { return _AMTYTDTOTINCENDOFLASTFISCALYEAR; }
			set
			{
				if (_AMTYTDTOTINCENDOFLASTFISCALYEAR != value)
				{
					_AMTYTDTOTINCENDOFLASTFISCALYEAR = value;
					ChangeState();
				}
			}
		}
		public string TEXT_MISC
		{
			get { return _TEXT_MISC; }
			set
			{
				if (_TEXT_MISC != value)
				{
					_TEXT_MISC = value;
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
		public decimal? WhereCurrent_ep_nbr { get; set; }
		private decimal? _whereCurrent_ep_nbr;
		public string WhereDoc_nbr { get; set; }
		private string _whereDoc_nbr;
		public decimal? WhereDoc_dept { get; set; }
		private decimal? _whereDoc_dept;
		public decimal? WhereDoc_ohip_nbr { get; set; }
		private decimal? _whereDoc_ohip_nbr;
		public decimal? WhereDoc_sin_nbr { get; set; }
		private decimal? _whereDoc_sin_nbr;
		public decimal? WhereDoc_clinic_nbr { get; set; }
		private decimal? _whereDoc_clinic_nbr;
		public decimal? WhereDoc_spec_cd { get; set; }
		private decimal? _whereDoc_spec_cd;
		public string WhereDoc_name { get; set; }
		private string _whereDoc_name;
		public string WhereDoc_inits { get; set; }
		private string _whereDoc_inits;
		public decimal? WhereDoc_yrly_ceiling_computed { get; set; }
		private decimal? _whereDoc_yrly_ceiling_computed;
		public decimal? WhereDoc_date_fac_start { get; set; }
		private decimal? _whereDoc_date_fac_start;
		public decimal? WhereDoc_date_fac_term { get; set; }
		private decimal? _whereDoc_date_fac_term;
		public string WhereDoc_full_part_ind { get; set; }
		private string _whereDoc_full_part_ind;
		public decimal? WhereDoc_yrly_require_revenue { get; set; }
		private decimal? _whereDoc_yrly_require_revenue;
		public decimal? WhereDoc_guarantee_percentage { get; set; }
		private decimal? _whereDoc_guarantee_percentage;
		public string WhereDoc_guarantee_flag { get; set; }
		private string _whereDoc_guarantee_flag;
		public decimal? WhereAmt_gross_ceiexp { get; set; }
		private decimal? _whereAmt_gross_ceiexp;
		public decimal? WhereAmt_net_ytdcex { get; set; }
		private decimal? _whereAmt_net_ytdcex;
		public string WhereDoc_pay_code { get; set; }
		private string _whereDoc_pay_code;
		public string WhereDoc_pay_sub_code { get; set; }
		private string _whereDoc_pay_sub_code;
		public decimal? WhereAmt_ytd_totinc { get; set; }
		private decimal? _whereAmt_ytd_totinc;
		public decimal? WhereAmt_ytd_incexp { get; set; }
		private decimal? _whereAmt_ytd_incexp;
		public decimal? WhereAmt_ytd_depexm { get; set; }
		private decimal? _whereAmt_ytd_depexm;
		public decimal? WhereAmt_ytd_depexr { get; set; }
		private decimal? _whereAmt_ytd_depexr;
		public decimal? WhereAmt_ytd_ytdear { get; set; }
		private decimal? _whereAmt_ytd_ytdear;
		public decimal? WhereAmt_ytd_depchr { get; set; }
		private decimal? _whereAmt_ytd_depchr;
		public decimal? WhereAmt_mtd_payeft { get; set; }
		private decimal? _whereAmt_mtd_payeft;
		public decimal? WhereAmt_ytd_rmaexr { get; set; }
		private decimal? _whereAmt_ytd_rmaexr;
		public decimal? WhereAmt_ytd_gst { get; set; }
		private decimal? _whereAmt_ytd_gst;
		public decimal? WhereAmt_ytd_bill { get; set; }
		private decimal? _whereAmt_ytd_bill;
		public decimal? WhereAmt_ytd_rmaexm { get; set; }
		private decimal? _whereAmt_ytd_rmaexm;
		public decimal? WhereAmt_mtd_paypot { get; set; }
		private decimal? _whereAmt_mtd_paypot;
		public decimal? WhereAmt_mtd_gtypea { get; set; }
		private decimal? _whereAmt_mtd_gtypea;
		public decimal? WhereAmt_mtd_rev_01 { get; set; }
		private decimal? _whereAmt_mtd_rev_01;
		public decimal? WhereAmt_ytd_rev_01 { get; set; }
		private decimal? _whereAmt_ytd_rev_01;
		public decimal? WhereAmt_mtd_rev_02 { get; set; }
		private decimal? _whereAmt_mtd_rev_02;
		public decimal? WhereAmt_ytd_rev_02 { get; set; }
		private decimal? _whereAmt_ytd_rev_02;
		public decimal? WhereAmt_mtd_rev_03 { get; set; }
		private decimal? _whereAmt_mtd_rev_03;
		public decimal? WhereAmt_ytd_rev_03 { get; set; }
		private decimal? _whereAmt_ytd_rev_03;
		public decimal? WhereAmt_mtd_rev_04 { get; set; }
		private decimal? _whereAmt_mtd_rev_04;
		public decimal? WhereAmt_ytd_rev_04 { get; set; }
		private decimal? _whereAmt_ytd_rev_04;
		public decimal? WhereAmt_mtd_rev_05 { get; set; }
		private decimal? _whereAmt_mtd_rev_05;
		public decimal? WhereAmt_ytd_rev_05 { get; set; }
		private decimal? _whereAmt_ytd_rev_05;
		public decimal? WhereAmt_mtd_rev_06 { get; set; }
		private decimal? _whereAmt_mtd_rev_06;
		public decimal? WhereAmt_ytd_rev_06 { get; set; }
		private decimal? _whereAmt_ytd_rev_06;
		public decimal? WhereAmt_mtd_rev_07 { get; set; }
		private decimal? _whereAmt_mtd_rev_07;
		public decimal? WhereAmt_ytd_rev_07 { get; set; }
		private decimal? _whereAmt_ytd_rev_07;
		public decimal? WhereAmt_mtd_rev_08 { get; set; }
		private decimal? _whereAmt_mtd_rev_08;
		public decimal? WhereAmt_ytd_rev_08 { get; set; }
		private decimal? _whereAmt_ytd_rev_08;
		public decimal? WhereAmt_mtd_rev_09 { get; set; }
		private decimal? _whereAmt_mtd_rev_09;
		public decimal? WhereAmt_ytd_rev_09 { get; set; }
		private decimal? _whereAmt_ytd_rev_09;
		public decimal? WhereAmt_mtd_rev_10 { get; set; }
		private decimal? _whereAmt_mtd_rev_10;
		public decimal? WhereAmt_ytd_rev_10 { get; set; }
		private decimal? _whereAmt_ytd_rev_10;
		public decimal? WhereAmt_mtd_rev_11 { get; set; }
		private decimal? _whereAmt_mtd_rev_11;
		public decimal? WhereAmt_ytd_rev_11 { get; set; }
		private decimal? _whereAmt_ytd_rev_11;
		public decimal? WhereAmt_mtd_rev_12 { get; set; }
		private decimal? _whereAmt_mtd_rev_12;
		public decimal? WhereAmt_ytd_rev_12 { get; set; }
		private decimal? _whereAmt_ytd_rev_12;
		public decimal? WhereAmt_mtd_rev_13 { get; set; }
		private decimal? _whereAmt_mtd_rev_13;
		public decimal? WhereAmt_ytd_rev_13 { get; set; }
		private decimal? _whereAmt_ytd_rev_13;
		public decimal? WhereAmt_mtd_rev_14 { get; set; }
		private decimal? _whereAmt_mtd_rev_14;
		public decimal? WhereAmt_ytd_rev_14 { get; set; }
		private decimal? _whereAmt_ytd_rev_14;
		public decimal? WhereAmt_mtd_rev_15 { get; set; }
		private decimal? _whereAmt_mtd_rev_15;
		public decimal? WhereAmt_ytd_rev_15 { get; set; }
		private decimal? _whereAmt_ytd_rev_15;
		public decimal? WhereAmt_mtd_rev_16 { get; set; }
		private decimal? _whereAmt_mtd_rev_16;
		public decimal? WhereAmt_ytd_rev_16 { get; set; }
		private decimal? _whereAmt_ytd_rev_16;
		public decimal? WhereAmt_mtd_rev_17 { get; set; }
		private decimal? _whereAmt_mtd_rev_17;
		public decimal? WhereAmt_ytd_rev_17 { get; set; }
		private decimal? _whereAmt_ytd_rev_17;
		public decimal? WhereAmt_mtd_rev_18 { get; set; }
		private decimal? _whereAmt_mtd_rev_18;
		public decimal? WhereAmt_ytd_rev_18 { get; set; }
		private decimal? _whereAmt_ytd_rev_18;
		public decimal? WhereAmt_mtd_rev_19 { get; set; }
		private decimal? _whereAmt_mtd_rev_19;
		public decimal? WhereAmt_ytd_rev_19 { get; set; }
		private decimal? _whereAmt_ytd_rev_19;
		public decimal? WhereAmt_mtd_rev_20 { get; set; }
		private decimal? _whereAmt_mtd_rev_20;
		public decimal? WhereAmt_ytd_rev_20 { get; set; }
		private decimal? _whereAmt_ytd_rev_20;
		public decimal? WhereAmt_ytd_rev_21 { get; set; }
		private decimal? _whereAmt_ytd_rev_21;
		public decimal? WhereAmt_ytd_rev_22 { get; set; }
		private decimal? _whereAmt_ytd_rev_22;
		public decimal? WhereAmt_ytd_rev_23 { get; set; }
		private decimal? _whereAmt_ytd_rev_23;
		public decimal? WhereAmt_ytd_rev_24 { get; set; }
		private decimal? _whereAmt_ytd_rev_24;
		public decimal? WhereAmt_ytd_rev_25 { get; set; }
		private decimal? _whereAmt_ytd_rev_25;
		public decimal? WhereAmt_ytd_rev_26 { get; set; }
		private decimal? _whereAmt_ytd_rev_26;
		public decimal? WhereAmt_ytd_rev_27 { get; set; }
		private decimal? _whereAmt_ytd_rev_27;
		public decimal? WhereAmt_ytd_rev_28 { get; set; }
		private decimal? _whereAmt_ytd_rev_28;
		public decimal? WhereAmt_ytd_rev_29 { get; set; }
		private decimal? _whereAmt_ytd_rev_29;
		public decimal? WhereAmt_ytd_rev_30 { get; set; }
		private decimal? _whereAmt_ytd_rev_30;
		public decimal? WhereAmt_ytd_rev_31 { get; set; }
		private decimal? _whereAmt_ytd_rev_31;
		public decimal? WhereAmt_ytd_rev_32 { get; set; }
		private decimal? _whereAmt_ytd_rev_32;
		public decimal? WhereAmt_ytd_rev_33 { get; set; }
		private decimal? _whereAmt_ytd_rev_33;
		public decimal? WhereAmt_ytd_rev_34 { get; set; }
		private decimal? _whereAmt_ytd_rev_34;
		public decimal? WhereAmt_ytd_rev_35 { get; set; }
		private decimal? _whereAmt_ytd_rev_35;
		public decimal? WhereAmt_ytd_exp_01 { get; set; }
		private decimal? _whereAmt_ytd_exp_01;
		public decimal? WhereAmt_ytd_exp_02 { get; set; }
		private decimal? _whereAmt_ytd_exp_02;
		public decimal? WhereAmt_ytd_exp_03 { get; set; }
		private decimal? _whereAmt_ytd_exp_03;
		public decimal? WhereAmt_ytd_exp_04 { get; set; }
		private decimal? _whereAmt_ytd_exp_04;
		public decimal? WhereAmt_ytd_exp_05 { get; set; }
		private decimal? _whereAmt_ytd_exp_05;
		public decimal? WhereAmt_ytd_exp_06 { get; set; }
		private decimal? _whereAmt_ytd_exp_06;
		public decimal? WhereAmt_ytd_exp_07 { get; set; }
		private decimal? _whereAmt_ytd_exp_07;
		public decimal? WhereAmt_ytd_exp_08 { get; set; }
		private decimal? _whereAmt_ytd_exp_08;
		public decimal? WhereAmt_ytd_exp_09 { get; set; }
		private decimal? _whereAmt_ytd_exp_09;
		public decimal? WhereAmt_ytd_exp_10 { get; set; }
		private decimal? _whereAmt_ytd_exp_10;
		public decimal? WhereAmtytdtotincendoflastfiscalyear { get; set; }
		private decimal? _whereAmtytdtotincendoflastfiscalyear;
		public string WhereText_misc { get; set; }
		private string _whereText_misc;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalCurrent_ep_nbr;
		private string _originalDoc_nbr;
		private decimal? _originalDoc_dept;
		private decimal? _originalDoc_ohip_nbr;
		private decimal? _originalDoc_sin_nbr;
		private decimal? _originalDoc_clinic_nbr;
		private decimal? _originalDoc_spec_cd;
		private string _originalDoc_name;
		private string _originalDoc_inits;
		private decimal? _originalDoc_yrly_ceiling_computed;
		private decimal? _originalDoc_date_fac_start;
		private decimal? _originalDoc_date_fac_term;
		private string _originalDoc_full_part_ind;
		private decimal? _originalDoc_yrly_require_revenue;
		private decimal? _originalDoc_guarantee_percentage;
		private string _originalDoc_guarantee_flag;
		private decimal? _originalAmt_gross_ceiexp;
		private decimal? _originalAmt_net_ytdcex;
		private string _originalDoc_pay_code;
		private string _originalDoc_pay_sub_code;
		private decimal? _originalAmt_ytd_totinc;
		private decimal? _originalAmt_ytd_incexp;
		private decimal? _originalAmt_ytd_depexm;
		private decimal? _originalAmt_ytd_depexr;
		private decimal? _originalAmt_ytd_ytdear;
		private decimal? _originalAmt_ytd_depchr;
		private decimal? _originalAmt_mtd_payeft;
		private decimal? _originalAmt_ytd_rmaexr;
		private decimal? _originalAmt_ytd_gst;
		private decimal? _originalAmt_ytd_bill;
		private decimal? _originalAmt_ytd_rmaexm;
		private decimal? _originalAmt_mtd_paypot;
		private decimal? _originalAmt_mtd_gtypea;
		private decimal? _originalAmt_mtd_rev_01;
		private decimal? _originalAmt_ytd_rev_01;
		private decimal? _originalAmt_mtd_rev_02;
		private decimal? _originalAmt_ytd_rev_02;
		private decimal? _originalAmt_mtd_rev_03;
		private decimal? _originalAmt_ytd_rev_03;
		private decimal? _originalAmt_mtd_rev_04;
		private decimal? _originalAmt_ytd_rev_04;
		private decimal? _originalAmt_mtd_rev_05;
		private decimal? _originalAmt_ytd_rev_05;
		private decimal? _originalAmt_mtd_rev_06;
		private decimal? _originalAmt_ytd_rev_06;
		private decimal? _originalAmt_mtd_rev_07;
		private decimal? _originalAmt_ytd_rev_07;
		private decimal? _originalAmt_mtd_rev_08;
		private decimal? _originalAmt_ytd_rev_08;
		private decimal? _originalAmt_mtd_rev_09;
		private decimal? _originalAmt_ytd_rev_09;
		private decimal? _originalAmt_mtd_rev_10;
		private decimal? _originalAmt_ytd_rev_10;
		private decimal? _originalAmt_mtd_rev_11;
		private decimal? _originalAmt_ytd_rev_11;
		private decimal? _originalAmt_mtd_rev_12;
		private decimal? _originalAmt_ytd_rev_12;
		private decimal? _originalAmt_mtd_rev_13;
		private decimal? _originalAmt_ytd_rev_13;
		private decimal? _originalAmt_mtd_rev_14;
		private decimal? _originalAmt_ytd_rev_14;
		private decimal? _originalAmt_mtd_rev_15;
		private decimal? _originalAmt_ytd_rev_15;
		private decimal? _originalAmt_mtd_rev_16;
		private decimal? _originalAmt_ytd_rev_16;
		private decimal? _originalAmt_mtd_rev_17;
		private decimal? _originalAmt_ytd_rev_17;
		private decimal? _originalAmt_mtd_rev_18;
		private decimal? _originalAmt_ytd_rev_18;
		private decimal? _originalAmt_mtd_rev_19;
		private decimal? _originalAmt_ytd_rev_19;
		private decimal? _originalAmt_mtd_rev_20;
		private decimal? _originalAmt_ytd_rev_20;
		private decimal? _originalAmt_ytd_rev_21;
		private decimal? _originalAmt_ytd_rev_22;
		private decimal? _originalAmt_ytd_rev_23;
		private decimal? _originalAmt_ytd_rev_24;
		private decimal? _originalAmt_ytd_rev_25;
		private decimal? _originalAmt_ytd_rev_26;
		private decimal? _originalAmt_ytd_rev_27;
		private decimal? _originalAmt_ytd_rev_28;
		private decimal? _originalAmt_ytd_rev_29;
		private decimal? _originalAmt_ytd_rev_30;
		private decimal? _originalAmt_ytd_rev_31;
		private decimal? _originalAmt_ytd_rev_32;
		private decimal? _originalAmt_ytd_rev_33;
		private decimal? _originalAmt_ytd_rev_34;
		private decimal? _originalAmt_ytd_rev_35;
		private decimal? _originalAmt_ytd_exp_01;
		private decimal? _originalAmt_ytd_exp_02;
		private decimal? _originalAmt_ytd_exp_03;
		private decimal? _originalAmt_ytd_exp_04;
		private decimal? _originalAmt_ytd_exp_05;
		private decimal? _originalAmt_ytd_exp_06;
		private decimal? _originalAmt_ytd_exp_07;
		private decimal? _originalAmt_ytd_exp_08;
		private decimal? _originalAmt_ytd_exp_09;
		private decimal? _originalAmt_ytd_exp_10;
		private decimal? _originalAmtytdtotincendoflastfiscalyear;
		private string _originalText_misc;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CURRENT_EP_NBR = _originalCurrent_ep_nbr;
			DOC_NBR = _originalDoc_nbr;
			DOC_DEPT = _originalDoc_dept;
			DOC_OHIP_NBR = _originalDoc_ohip_nbr;
			DOC_SIN_NBR = _originalDoc_sin_nbr;
			DOC_CLINIC_NBR = _originalDoc_clinic_nbr;
			DOC_SPEC_CD = _originalDoc_spec_cd;
			DOC_NAME = _originalDoc_name;
			DOC_INITS = _originalDoc_inits;
			DOC_YRLY_CEILING_COMPUTED = _originalDoc_yrly_ceiling_computed;
			DOC_DATE_FAC_START = _originalDoc_date_fac_start;
			DOC_DATE_FAC_TERM = _originalDoc_date_fac_term;
			DOC_FULL_PART_IND = _originalDoc_full_part_ind;
			DOC_YRLY_REQUIRE_REVENUE = _originalDoc_yrly_require_revenue;
			DOC_GUARANTEE_PERCENTAGE = _originalDoc_guarantee_percentage;
			DOC_GUARANTEE_FLAG = _originalDoc_guarantee_flag;
			AMT_GROSS_CEIEXP = _originalAmt_gross_ceiexp;
			AMT_NET_YTDCEX = _originalAmt_net_ytdcex;
			DOC_PAY_CODE = _originalDoc_pay_code;
			DOC_PAY_SUB_CODE = _originalDoc_pay_sub_code;
			AMT_YTD_TOTINC = _originalAmt_ytd_totinc;
			AMT_YTD_INCEXP = _originalAmt_ytd_incexp;
			AMT_YTD_DEPEXM = _originalAmt_ytd_depexm;
			AMT_YTD_DEPEXR = _originalAmt_ytd_depexr;
			AMT_YTD_YTDEAR = _originalAmt_ytd_ytdear;
			AMT_YTD_DEPCHR = _originalAmt_ytd_depchr;
			AMT_MTD_PAYEFT = _originalAmt_mtd_payeft;
			AMT_YTD_RMAEXR = _originalAmt_ytd_rmaexr;
			AMT_YTD_GST = _originalAmt_ytd_gst;
			AMT_YTD_BILL = _originalAmt_ytd_bill;
			AMT_YTD_RMAEXM = _originalAmt_ytd_rmaexm;
			AMT_MTD_PAYPOT = _originalAmt_mtd_paypot;
			AMT_MTD_GTYPEA = _originalAmt_mtd_gtypea;
			AMT_MTD_REV_01 = _originalAmt_mtd_rev_01;
			AMT_YTD_REV_01 = _originalAmt_ytd_rev_01;
			AMT_MTD_REV_02 = _originalAmt_mtd_rev_02;
			AMT_YTD_REV_02 = _originalAmt_ytd_rev_02;
			AMT_MTD_REV_03 = _originalAmt_mtd_rev_03;
			AMT_YTD_REV_03 = _originalAmt_ytd_rev_03;
			AMT_MTD_REV_04 = _originalAmt_mtd_rev_04;
			AMT_YTD_REV_04 = _originalAmt_ytd_rev_04;
			AMT_MTD_REV_05 = _originalAmt_mtd_rev_05;
			AMT_YTD_REV_05 = _originalAmt_ytd_rev_05;
			AMT_MTD_REV_06 = _originalAmt_mtd_rev_06;
			AMT_YTD_REV_06 = _originalAmt_ytd_rev_06;
			AMT_MTD_REV_07 = _originalAmt_mtd_rev_07;
			AMT_YTD_REV_07 = _originalAmt_ytd_rev_07;
			AMT_MTD_REV_08 = _originalAmt_mtd_rev_08;
			AMT_YTD_REV_08 = _originalAmt_ytd_rev_08;
			AMT_MTD_REV_09 = _originalAmt_mtd_rev_09;
			AMT_YTD_REV_09 = _originalAmt_ytd_rev_09;
			AMT_MTD_REV_10 = _originalAmt_mtd_rev_10;
			AMT_YTD_REV_10 = _originalAmt_ytd_rev_10;
			AMT_MTD_REV_11 = _originalAmt_mtd_rev_11;
			AMT_YTD_REV_11 = _originalAmt_ytd_rev_11;
			AMT_MTD_REV_12 = _originalAmt_mtd_rev_12;
			AMT_YTD_REV_12 = _originalAmt_ytd_rev_12;
			AMT_MTD_REV_13 = _originalAmt_mtd_rev_13;
			AMT_YTD_REV_13 = _originalAmt_ytd_rev_13;
			AMT_MTD_REV_14 = _originalAmt_mtd_rev_14;
			AMT_YTD_REV_14 = _originalAmt_ytd_rev_14;
			AMT_MTD_REV_15 = _originalAmt_mtd_rev_15;
			AMT_YTD_REV_15 = _originalAmt_ytd_rev_15;
			AMT_MTD_REV_16 = _originalAmt_mtd_rev_16;
			AMT_YTD_REV_16 = _originalAmt_ytd_rev_16;
			AMT_MTD_REV_17 = _originalAmt_mtd_rev_17;
			AMT_YTD_REV_17 = _originalAmt_ytd_rev_17;
			AMT_MTD_REV_18 = _originalAmt_mtd_rev_18;
			AMT_YTD_REV_18 = _originalAmt_ytd_rev_18;
			AMT_MTD_REV_19 = _originalAmt_mtd_rev_19;
			AMT_YTD_REV_19 = _originalAmt_ytd_rev_19;
			AMT_MTD_REV_20 = _originalAmt_mtd_rev_20;
			AMT_YTD_REV_20 = _originalAmt_ytd_rev_20;
			AMT_YTD_REV_21 = _originalAmt_ytd_rev_21;
			AMT_YTD_REV_22 = _originalAmt_ytd_rev_22;
			AMT_YTD_REV_23 = _originalAmt_ytd_rev_23;
			AMT_YTD_REV_24 = _originalAmt_ytd_rev_24;
			AMT_YTD_REV_25 = _originalAmt_ytd_rev_25;
			AMT_YTD_REV_26 = _originalAmt_ytd_rev_26;
			AMT_YTD_REV_27 = _originalAmt_ytd_rev_27;
			AMT_YTD_REV_28 = _originalAmt_ytd_rev_28;
			AMT_YTD_REV_29 = _originalAmt_ytd_rev_29;
			AMT_YTD_REV_30 = _originalAmt_ytd_rev_30;
			AMT_YTD_REV_31 = _originalAmt_ytd_rev_31;
			AMT_YTD_REV_32 = _originalAmt_ytd_rev_32;
			AMT_YTD_REV_33 = _originalAmt_ytd_rev_33;
			AMT_YTD_REV_34 = _originalAmt_ytd_rev_34;
			AMT_YTD_REV_35 = _originalAmt_ytd_rev_35;
			AMT_YTD_EXP_01 = _originalAmt_ytd_exp_01;
			AMT_YTD_EXP_02 = _originalAmt_ytd_exp_02;
			AMT_YTD_EXP_03 = _originalAmt_ytd_exp_03;
			AMT_YTD_EXP_04 = _originalAmt_ytd_exp_04;
			AMT_YTD_EXP_05 = _originalAmt_ytd_exp_05;
			AMT_YTD_EXP_06 = _originalAmt_ytd_exp_06;
			AMT_YTD_EXP_07 = _originalAmt_ytd_exp_07;
			AMT_YTD_EXP_08 = _originalAmt_ytd_exp_08;
			AMT_YTD_EXP_09 = _originalAmt_ytd_exp_09;
			AMT_YTD_EXP_10 = _originalAmt_ytd_exp_10;
			AMTYTDTOTINCENDOFLASTFISCALYEAR = _originalAmtytdtotincendoflastfiscalyear;
			TEXT_MISC = _originalText_misc;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_Purge]");
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
						new SqlParameter("CURRENT_EP_NBR", SqlNull(CURRENT_EP_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_SIN_NBR", SqlNull(DOC_SIN_NBR)),
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_DATE_FAC_START", SqlNull(DOC_DATE_FAC_START)),
						new SqlParameter("DOC_DATE_FAC_TERM", SqlNull(DOC_DATE_FAC_TERM)),
						new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_GUARANTEE_PERCENTAGE", SqlNull(DOC_GUARANTEE_PERCENTAGE)),
						new SqlParameter("DOC_GUARANTEE_FLAG", SqlNull(DOC_GUARANTEE_FLAG)),
						new SqlParameter("AMT_GROSS_CEIEXP", SqlNull(AMT_GROSS_CEIEXP)),
						new SqlParameter("AMT_NET_YTDCEX", SqlNull(AMT_NET_YTDCEX)),
						new SqlParameter("DOC_PAY_CODE", SqlNull(DOC_PAY_CODE)),
						new SqlParameter("DOC_PAY_SUB_CODE", SqlNull(DOC_PAY_SUB_CODE)),
						new SqlParameter("AMT_YTD_TOTINC", SqlNull(AMT_YTD_TOTINC)),
						new SqlParameter("AMT_YTD_INCEXP", SqlNull(AMT_YTD_INCEXP)),
						new SqlParameter("AMT_YTD_DEPEXM", SqlNull(AMT_YTD_DEPEXM)),
						new SqlParameter("AMT_YTD_DEPEXR", SqlNull(AMT_YTD_DEPEXR)),
						new SqlParameter("AMT_YTD_YTDEAR", SqlNull(AMT_YTD_YTDEAR)),
						new SqlParameter("AMT_YTD_DEPCHR", SqlNull(AMT_YTD_DEPCHR)),
						new SqlParameter("AMT_MTD_PAYEFT", SqlNull(AMT_MTD_PAYEFT)),
						new SqlParameter("AMT_YTD_RMAEXR", SqlNull(AMT_YTD_RMAEXR)),
						new SqlParameter("AMT_YTD_GST", SqlNull(AMT_YTD_GST)),
						new SqlParameter("AMT_YTD_BILL", SqlNull(AMT_YTD_BILL)),
						new SqlParameter("AMT_YTD_RMAEXM", SqlNull(AMT_YTD_RMAEXM)),
						new SqlParameter("AMT_MTD_PAYPOT", SqlNull(AMT_MTD_PAYPOT)),
						new SqlParameter("AMT_MTD_GTYPEA", SqlNull(AMT_MTD_GTYPEA)),
						new SqlParameter("AMT_MTD_REV_01", SqlNull(AMT_MTD_REV_01)),
						new SqlParameter("AMT_YTD_REV_01", SqlNull(AMT_YTD_REV_01)),
						new SqlParameter("AMT_MTD_REV_02", SqlNull(AMT_MTD_REV_02)),
						new SqlParameter("AMT_YTD_REV_02", SqlNull(AMT_YTD_REV_02)),
						new SqlParameter("AMT_MTD_REV_03", SqlNull(AMT_MTD_REV_03)),
						new SqlParameter("AMT_YTD_REV_03", SqlNull(AMT_YTD_REV_03)),
						new SqlParameter("AMT_MTD_REV_04", SqlNull(AMT_MTD_REV_04)),
						new SqlParameter("AMT_YTD_REV_04", SqlNull(AMT_YTD_REV_04)),
						new SqlParameter("AMT_MTD_REV_05", SqlNull(AMT_MTD_REV_05)),
						new SqlParameter("AMT_YTD_REV_05", SqlNull(AMT_YTD_REV_05)),
						new SqlParameter("AMT_MTD_REV_06", SqlNull(AMT_MTD_REV_06)),
						new SqlParameter("AMT_YTD_REV_06", SqlNull(AMT_YTD_REV_06)),
						new SqlParameter("AMT_MTD_REV_07", SqlNull(AMT_MTD_REV_07)),
						new SqlParameter("AMT_YTD_REV_07", SqlNull(AMT_YTD_REV_07)),
						new SqlParameter("AMT_MTD_REV_08", SqlNull(AMT_MTD_REV_08)),
						new SqlParameter("AMT_YTD_REV_08", SqlNull(AMT_YTD_REV_08)),
						new SqlParameter("AMT_MTD_REV_09", SqlNull(AMT_MTD_REV_09)),
						new SqlParameter("AMT_YTD_REV_09", SqlNull(AMT_YTD_REV_09)),
						new SqlParameter("AMT_MTD_REV_10", SqlNull(AMT_MTD_REV_10)),
						new SqlParameter("AMT_YTD_REV_10", SqlNull(AMT_YTD_REV_10)),
						new SqlParameter("AMT_MTD_REV_11", SqlNull(AMT_MTD_REV_11)),
						new SqlParameter("AMT_YTD_REV_11", SqlNull(AMT_YTD_REV_11)),
						new SqlParameter("AMT_MTD_REV_12", SqlNull(AMT_MTD_REV_12)),
						new SqlParameter("AMT_YTD_REV_12", SqlNull(AMT_YTD_REV_12)),
						new SqlParameter("AMT_MTD_REV_13", SqlNull(AMT_MTD_REV_13)),
						new SqlParameter("AMT_YTD_REV_13", SqlNull(AMT_YTD_REV_13)),
						new SqlParameter("AMT_MTD_REV_14", SqlNull(AMT_MTD_REV_14)),
						new SqlParameter("AMT_YTD_REV_14", SqlNull(AMT_YTD_REV_14)),
						new SqlParameter("AMT_MTD_REV_15", SqlNull(AMT_MTD_REV_15)),
						new SqlParameter("AMT_YTD_REV_15", SqlNull(AMT_YTD_REV_15)),
						new SqlParameter("AMT_MTD_REV_16", SqlNull(AMT_MTD_REV_16)),
						new SqlParameter("AMT_YTD_REV_16", SqlNull(AMT_YTD_REV_16)),
						new SqlParameter("AMT_MTD_REV_17", SqlNull(AMT_MTD_REV_17)),
						new SqlParameter("AMT_YTD_REV_17", SqlNull(AMT_YTD_REV_17)),
						new SqlParameter("AMT_MTD_REV_18", SqlNull(AMT_MTD_REV_18)),
						new SqlParameter("AMT_YTD_REV_18", SqlNull(AMT_YTD_REV_18)),
						new SqlParameter("AMT_MTD_REV_19", SqlNull(AMT_MTD_REV_19)),
						new SqlParameter("AMT_YTD_REV_19", SqlNull(AMT_YTD_REV_19)),
						new SqlParameter("AMT_MTD_REV_20", SqlNull(AMT_MTD_REV_20)),
						new SqlParameter("AMT_YTD_REV_20", SqlNull(AMT_YTD_REV_20)),
						new SqlParameter("AMT_YTD_REV_21", SqlNull(AMT_YTD_REV_21)),
						new SqlParameter("AMT_YTD_REV_22", SqlNull(AMT_YTD_REV_22)),
						new SqlParameter("AMT_YTD_REV_23", SqlNull(AMT_YTD_REV_23)),
						new SqlParameter("AMT_YTD_REV_24", SqlNull(AMT_YTD_REV_24)),
						new SqlParameter("AMT_YTD_REV_25", SqlNull(AMT_YTD_REV_25)),
						new SqlParameter("AMT_YTD_REV_26", SqlNull(AMT_YTD_REV_26)),
						new SqlParameter("AMT_YTD_REV_27", SqlNull(AMT_YTD_REV_27)),
						new SqlParameter("AMT_YTD_REV_28", SqlNull(AMT_YTD_REV_28)),
						new SqlParameter("AMT_YTD_REV_29", SqlNull(AMT_YTD_REV_29)),
						new SqlParameter("AMT_YTD_REV_30", SqlNull(AMT_YTD_REV_30)),
						new SqlParameter("AMT_YTD_REV_31", SqlNull(AMT_YTD_REV_31)),
						new SqlParameter("AMT_YTD_REV_32", SqlNull(AMT_YTD_REV_32)),
						new SqlParameter("AMT_YTD_REV_33", SqlNull(AMT_YTD_REV_33)),
						new SqlParameter("AMT_YTD_REV_34", SqlNull(AMT_YTD_REV_34)),
						new SqlParameter("AMT_YTD_REV_35", SqlNull(AMT_YTD_REV_35)),
						new SqlParameter("AMT_YTD_EXP_01", SqlNull(AMT_YTD_EXP_01)),
						new SqlParameter("AMT_YTD_EXP_02", SqlNull(AMT_YTD_EXP_02)),
						new SqlParameter("AMT_YTD_EXP_03", SqlNull(AMT_YTD_EXP_03)),
						new SqlParameter("AMT_YTD_EXP_04", SqlNull(AMT_YTD_EXP_04)),
						new SqlParameter("AMT_YTD_EXP_05", SqlNull(AMT_YTD_EXP_05)),
						new SqlParameter("AMT_YTD_EXP_06", SqlNull(AMT_YTD_EXP_06)),
						new SqlParameter("AMT_YTD_EXP_07", SqlNull(AMT_YTD_EXP_07)),
						new SqlParameter("AMT_YTD_EXP_08", SqlNull(AMT_YTD_EXP_08)),
						new SqlParameter("AMT_YTD_EXP_09", SqlNull(AMT_YTD_EXP_09)),
						new SqlParameter("AMT_YTD_EXP_10", SqlNull(AMT_YTD_EXP_10)),
						new SqlParameter("AMTYTDTOTINCENDOFLASTFISCALYEAR", SqlNull(AMTYTDTOTINCENDOFLASTFISCALYEAR)),
						new SqlParameter("TEXT_MISC", SqlNull(TEXT_MISC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]);
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
						DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_GUARANTEE_PERCENTAGE = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]);
						DOC_GUARANTEE_FLAG = Reader["DOC_GUARANTEE_FLAG"].ToString();
						AMT_GROSS_CEIEXP = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]);
						AMT_NET_YTDCEX = ConvertDEC(Reader["AMT_NET_YTDCEX"]);
						DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString();
						DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString();
						AMT_YTD_TOTINC = ConvertDEC(Reader["AMT_YTD_TOTINC"]);
						AMT_YTD_INCEXP = ConvertDEC(Reader["AMT_YTD_INCEXP"]);
						AMT_YTD_DEPEXM = ConvertDEC(Reader["AMT_YTD_DEPEXM"]);
						AMT_YTD_DEPEXR = ConvertDEC(Reader["AMT_YTD_DEPEXR"]);
						AMT_YTD_YTDEAR = ConvertDEC(Reader["AMT_YTD_YTDEAR"]);
						AMT_YTD_DEPCHR = ConvertDEC(Reader["AMT_YTD_DEPCHR"]);
						AMT_MTD_PAYEFT = ConvertDEC(Reader["AMT_MTD_PAYEFT"]);
						AMT_YTD_RMAEXR = ConvertDEC(Reader["AMT_YTD_RMAEXR"]);
						AMT_YTD_GST = ConvertDEC(Reader["AMT_YTD_GST"]);
						AMT_YTD_BILL = ConvertDEC(Reader["AMT_YTD_BILL"]);
						AMT_YTD_RMAEXM = ConvertDEC(Reader["AMT_YTD_RMAEXM"]);
						AMT_MTD_PAYPOT = ConvertDEC(Reader["AMT_MTD_PAYPOT"]);
						AMT_MTD_GTYPEA = ConvertDEC(Reader["AMT_MTD_GTYPEA"]);
						AMT_MTD_REV_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]);
						AMT_YTD_REV_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]);
						AMT_MTD_REV_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]);
						AMT_YTD_REV_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]);
						AMT_MTD_REV_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]);
						AMT_YTD_REV_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]);
						AMT_MTD_REV_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]);
						AMT_YTD_REV_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]);
						AMT_MTD_REV_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]);
						AMT_YTD_REV_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]);
						AMT_MTD_REV_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]);
						AMT_YTD_REV_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]);
						AMT_MTD_REV_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]);
						AMT_YTD_REV_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]);
						AMT_MTD_REV_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]);
						AMT_YTD_REV_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]);
						AMT_MTD_REV_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]);
						AMT_YTD_REV_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]);
						AMT_MTD_REV_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]);
						AMT_YTD_REV_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]);
						AMT_MTD_REV_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]);
						AMT_YTD_REV_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]);
						AMT_MTD_REV_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]);
						AMT_YTD_REV_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]);
						AMT_MTD_REV_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]);
						AMT_YTD_REV_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]);
						AMT_MTD_REV_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]);
						AMT_YTD_REV_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]);
						AMT_MTD_REV_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]);
						AMT_YTD_REV_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]);
						AMT_MTD_REV_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]);
						AMT_YTD_REV_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]);
						AMT_MTD_REV_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]);
						AMT_YTD_REV_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]);
						AMT_MTD_REV_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]);
						AMT_YTD_REV_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]);
						AMT_MTD_REV_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]);
						AMT_YTD_REV_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]);
						AMT_MTD_REV_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]);
						AMT_YTD_REV_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]);
						AMT_YTD_REV_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]);
						AMT_YTD_REV_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]);
						AMT_YTD_REV_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]);
						AMT_YTD_REV_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]);
						AMT_YTD_REV_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]);
						AMT_YTD_REV_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]);
						AMT_YTD_REV_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]);
						AMT_YTD_REV_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]);
						AMT_YTD_REV_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]);
						AMT_YTD_REV_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]);
						AMT_YTD_REV_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]);
						AMT_YTD_REV_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]);
						AMT_YTD_REV_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]);
						AMT_YTD_REV_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]);
						AMT_YTD_REV_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]);
						AMT_YTD_EXP_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]);
						AMT_YTD_EXP_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]);
						AMT_YTD_EXP_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]);
						AMT_YTD_EXP_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]);
						AMT_YTD_EXP_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]);
						AMT_YTD_EXP_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]);
						AMT_YTD_EXP_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]);
						AMT_YTD_EXP_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]);
						AMT_YTD_EXP_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]);
						AMT_YTD_EXP_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]);
						AMTYTDTOTINCENDOFLASTFISCALYEAR = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]);
						TEXT_MISC = Reader["TEXT_MISC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]);
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
						_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_guarantee_percentage = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]);
						_originalDoc_guarantee_flag = Reader["DOC_GUARANTEE_FLAG"].ToString();
						_originalAmt_gross_ceiexp = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]);
						_originalAmt_net_ytdcex = ConvertDEC(Reader["AMT_NET_YTDCEX"]);
						_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString();
						_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString();
						_originalAmt_ytd_totinc = ConvertDEC(Reader["AMT_YTD_TOTINC"]);
						_originalAmt_ytd_incexp = ConvertDEC(Reader["AMT_YTD_INCEXP"]);
						_originalAmt_ytd_depexm = ConvertDEC(Reader["AMT_YTD_DEPEXM"]);
						_originalAmt_ytd_depexr = ConvertDEC(Reader["AMT_YTD_DEPEXR"]);
						_originalAmt_ytd_ytdear = ConvertDEC(Reader["AMT_YTD_YTDEAR"]);
						_originalAmt_ytd_depchr = ConvertDEC(Reader["AMT_YTD_DEPCHR"]);
						_originalAmt_mtd_payeft = ConvertDEC(Reader["AMT_MTD_PAYEFT"]);
						_originalAmt_ytd_rmaexr = ConvertDEC(Reader["AMT_YTD_RMAEXR"]);
						_originalAmt_ytd_gst = ConvertDEC(Reader["AMT_YTD_GST"]);
						_originalAmt_ytd_bill = ConvertDEC(Reader["AMT_YTD_BILL"]);
						_originalAmt_ytd_rmaexm = ConvertDEC(Reader["AMT_YTD_RMAEXM"]);
						_originalAmt_mtd_paypot = ConvertDEC(Reader["AMT_MTD_PAYPOT"]);
						_originalAmt_mtd_gtypea = ConvertDEC(Reader["AMT_MTD_GTYPEA"]);
						_originalAmt_mtd_rev_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]);
						_originalAmt_ytd_rev_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]);
						_originalAmt_mtd_rev_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]);
						_originalAmt_ytd_rev_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]);
						_originalAmt_mtd_rev_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]);
						_originalAmt_ytd_rev_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]);
						_originalAmt_mtd_rev_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]);
						_originalAmt_ytd_rev_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]);
						_originalAmt_mtd_rev_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]);
						_originalAmt_ytd_rev_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]);
						_originalAmt_mtd_rev_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]);
						_originalAmt_ytd_rev_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]);
						_originalAmt_mtd_rev_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]);
						_originalAmt_ytd_rev_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]);
						_originalAmt_mtd_rev_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]);
						_originalAmt_ytd_rev_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]);
						_originalAmt_mtd_rev_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]);
						_originalAmt_ytd_rev_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]);
						_originalAmt_mtd_rev_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]);
						_originalAmt_ytd_rev_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]);
						_originalAmt_mtd_rev_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]);
						_originalAmt_ytd_rev_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]);
						_originalAmt_mtd_rev_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]);
						_originalAmt_ytd_rev_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]);
						_originalAmt_mtd_rev_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]);
						_originalAmt_ytd_rev_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]);
						_originalAmt_mtd_rev_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]);
						_originalAmt_ytd_rev_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]);
						_originalAmt_mtd_rev_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]);
						_originalAmt_ytd_rev_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]);
						_originalAmt_mtd_rev_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]);
						_originalAmt_ytd_rev_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]);
						_originalAmt_mtd_rev_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]);
						_originalAmt_ytd_rev_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]);
						_originalAmt_mtd_rev_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]);
						_originalAmt_ytd_rev_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]);
						_originalAmt_mtd_rev_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]);
						_originalAmt_ytd_rev_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]);
						_originalAmt_mtd_rev_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]);
						_originalAmt_ytd_rev_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]);
						_originalAmt_ytd_rev_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]);
						_originalAmt_ytd_rev_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]);
						_originalAmt_ytd_rev_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]);
						_originalAmt_ytd_rev_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]);
						_originalAmt_ytd_rev_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]);
						_originalAmt_ytd_rev_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]);
						_originalAmt_ytd_rev_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]);
						_originalAmt_ytd_rev_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]);
						_originalAmt_ytd_rev_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]);
						_originalAmt_ytd_rev_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]);
						_originalAmt_ytd_rev_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]);
						_originalAmt_ytd_rev_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]);
						_originalAmt_ytd_rev_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]);
						_originalAmt_ytd_rev_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]);
						_originalAmt_ytd_rev_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]);
						_originalAmt_ytd_exp_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]);
						_originalAmt_ytd_exp_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]);
						_originalAmt_ytd_exp_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]);
						_originalAmt_ytd_exp_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]);
						_originalAmt_ytd_exp_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]);
						_originalAmt_ytd_exp_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]);
						_originalAmt_ytd_exp_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]);
						_originalAmt_ytd_exp_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]);
						_originalAmt_ytd_exp_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]);
						_originalAmt_ytd_exp_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]);
						_originalAmtytdtotincendoflastfiscalyear = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]);
						_originalText_misc = Reader["TEXT_MISC"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CURRENT_EP_NBR", SqlNull(CURRENT_EP_NBR)),
						new SqlParameter("DOC_NBR", SqlNull(DOC_NBR)),
						new SqlParameter("DOC_DEPT", SqlNull(DOC_DEPT)),
						new SqlParameter("DOC_OHIP_NBR", SqlNull(DOC_OHIP_NBR)),
						new SqlParameter("DOC_SIN_NBR", SqlNull(DOC_SIN_NBR)),
						new SqlParameter("DOC_CLINIC_NBR", SqlNull(DOC_CLINIC_NBR)),
						new SqlParameter("DOC_SPEC_CD", SqlNull(DOC_SPEC_CD)),
						new SqlParameter("DOC_NAME", SqlNull(DOC_NAME)),
						new SqlParameter("DOC_INITS", SqlNull(DOC_INITS)),
						new SqlParameter("DOC_YRLY_CEILING_COMPUTED", SqlNull(DOC_YRLY_CEILING_COMPUTED)),
						new SqlParameter("DOC_DATE_FAC_START", SqlNull(DOC_DATE_FAC_START)),
						new SqlParameter("DOC_DATE_FAC_TERM", SqlNull(DOC_DATE_FAC_TERM)),
						new SqlParameter("DOC_FULL_PART_IND", SqlNull(DOC_FULL_PART_IND)),
						new SqlParameter("DOC_YRLY_REQUIRE_REVENUE", SqlNull(DOC_YRLY_REQUIRE_REVENUE)),
						new SqlParameter("DOC_GUARANTEE_PERCENTAGE", SqlNull(DOC_GUARANTEE_PERCENTAGE)),
						new SqlParameter("DOC_GUARANTEE_FLAG", SqlNull(DOC_GUARANTEE_FLAG)),
						new SqlParameter("AMT_GROSS_CEIEXP", SqlNull(AMT_GROSS_CEIEXP)),
						new SqlParameter("AMT_NET_YTDCEX", SqlNull(AMT_NET_YTDCEX)),
						new SqlParameter("DOC_PAY_CODE", SqlNull(DOC_PAY_CODE)),
						new SqlParameter("DOC_PAY_SUB_CODE", SqlNull(DOC_PAY_SUB_CODE)),
						new SqlParameter("AMT_YTD_TOTINC", SqlNull(AMT_YTD_TOTINC)),
						new SqlParameter("AMT_YTD_INCEXP", SqlNull(AMT_YTD_INCEXP)),
						new SqlParameter("AMT_YTD_DEPEXM", SqlNull(AMT_YTD_DEPEXM)),
						new SqlParameter("AMT_YTD_DEPEXR", SqlNull(AMT_YTD_DEPEXR)),
						new SqlParameter("AMT_YTD_YTDEAR", SqlNull(AMT_YTD_YTDEAR)),
						new SqlParameter("AMT_YTD_DEPCHR", SqlNull(AMT_YTD_DEPCHR)),
						new SqlParameter("AMT_MTD_PAYEFT", SqlNull(AMT_MTD_PAYEFT)),
						new SqlParameter("AMT_YTD_RMAEXR", SqlNull(AMT_YTD_RMAEXR)),
						new SqlParameter("AMT_YTD_GST", SqlNull(AMT_YTD_GST)),
						new SqlParameter("AMT_YTD_BILL", SqlNull(AMT_YTD_BILL)),
						new SqlParameter("AMT_YTD_RMAEXM", SqlNull(AMT_YTD_RMAEXM)),
						new SqlParameter("AMT_MTD_PAYPOT", SqlNull(AMT_MTD_PAYPOT)),
						new SqlParameter("AMT_MTD_GTYPEA", SqlNull(AMT_MTD_GTYPEA)),
						new SqlParameter("AMT_MTD_REV_01", SqlNull(AMT_MTD_REV_01)),
						new SqlParameter("AMT_YTD_REV_01", SqlNull(AMT_YTD_REV_01)),
						new SqlParameter("AMT_MTD_REV_02", SqlNull(AMT_MTD_REV_02)),
						new SqlParameter("AMT_YTD_REV_02", SqlNull(AMT_YTD_REV_02)),
						new SqlParameter("AMT_MTD_REV_03", SqlNull(AMT_MTD_REV_03)),
						new SqlParameter("AMT_YTD_REV_03", SqlNull(AMT_YTD_REV_03)),
						new SqlParameter("AMT_MTD_REV_04", SqlNull(AMT_MTD_REV_04)),
						new SqlParameter("AMT_YTD_REV_04", SqlNull(AMT_YTD_REV_04)),
						new SqlParameter("AMT_MTD_REV_05", SqlNull(AMT_MTD_REV_05)),
						new SqlParameter("AMT_YTD_REV_05", SqlNull(AMT_YTD_REV_05)),
						new SqlParameter("AMT_MTD_REV_06", SqlNull(AMT_MTD_REV_06)),
						new SqlParameter("AMT_YTD_REV_06", SqlNull(AMT_YTD_REV_06)),
						new SqlParameter("AMT_MTD_REV_07", SqlNull(AMT_MTD_REV_07)),
						new SqlParameter("AMT_YTD_REV_07", SqlNull(AMT_YTD_REV_07)),
						new SqlParameter("AMT_MTD_REV_08", SqlNull(AMT_MTD_REV_08)),
						new SqlParameter("AMT_YTD_REV_08", SqlNull(AMT_YTD_REV_08)),
						new SqlParameter("AMT_MTD_REV_09", SqlNull(AMT_MTD_REV_09)),
						new SqlParameter("AMT_YTD_REV_09", SqlNull(AMT_YTD_REV_09)),
						new SqlParameter("AMT_MTD_REV_10", SqlNull(AMT_MTD_REV_10)),
						new SqlParameter("AMT_YTD_REV_10", SqlNull(AMT_YTD_REV_10)),
						new SqlParameter("AMT_MTD_REV_11", SqlNull(AMT_MTD_REV_11)),
						new SqlParameter("AMT_YTD_REV_11", SqlNull(AMT_YTD_REV_11)),
						new SqlParameter("AMT_MTD_REV_12", SqlNull(AMT_MTD_REV_12)),
						new SqlParameter("AMT_YTD_REV_12", SqlNull(AMT_YTD_REV_12)),
						new SqlParameter("AMT_MTD_REV_13", SqlNull(AMT_MTD_REV_13)),
						new SqlParameter("AMT_YTD_REV_13", SqlNull(AMT_YTD_REV_13)),
						new SqlParameter("AMT_MTD_REV_14", SqlNull(AMT_MTD_REV_14)),
						new SqlParameter("AMT_YTD_REV_14", SqlNull(AMT_YTD_REV_14)),
						new SqlParameter("AMT_MTD_REV_15", SqlNull(AMT_MTD_REV_15)),
						new SqlParameter("AMT_YTD_REV_15", SqlNull(AMT_YTD_REV_15)),
						new SqlParameter("AMT_MTD_REV_16", SqlNull(AMT_MTD_REV_16)),
						new SqlParameter("AMT_YTD_REV_16", SqlNull(AMT_YTD_REV_16)),
						new SqlParameter("AMT_MTD_REV_17", SqlNull(AMT_MTD_REV_17)),
						new SqlParameter("AMT_YTD_REV_17", SqlNull(AMT_YTD_REV_17)),
						new SqlParameter("AMT_MTD_REV_18", SqlNull(AMT_MTD_REV_18)),
						new SqlParameter("AMT_YTD_REV_18", SqlNull(AMT_YTD_REV_18)),
						new SqlParameter("AMT_MTD_REV_19", SqlNull(AMT_MTD_REV_19)),
						new SqlParameter("AMT_YTD_REV_19", SqlNull(AMT_YTD_REV_19)),
						new SqlParameter("AMT_MTD_REV_20", SqlNull(AMT_MTD_REV_20)),
						new SqlParameter("AMT_YTD_REV_20", SqlNull(AMT_YTD_REV_20)),
						new SqlParameter("AMT_YTD_REV_21", SqlNull(AMT_YTD_REV_21)),
						new SqlParameter("AMT_YTD_REV_22", SqlNull(AMT_YTD_REV_22)),
						new SqlParameter("AMT_YTD_REV_23", SqlNull(AMT_YTD_REV_23)),
						new SqlParameter("AMT_YTD_REV_24", SqlNull(AMT_YTD_REV_24)),
						new SqlParameter("AMT_YTD_REV_25", SqlNull(AMT_YTD_REV_25)),
						new SqlParameter("AMT_YTD_REV_26", SqlNull(AMT_YTD_REV_26)),
						new SqlParameter("AMT_YTD_REV_27", SqlNull(AMT_YTD_REV_27)),
						new SqlParameter("AMT_YTD_REV_28", SqlNull(AMT_YTD_REV_28)),
						new SqlParameter("AMT_YTD_REV_29", SqlNull(AMT_YTD_REV_29)),
						new SqlParameter("AMT_YTD_REV_30", SqlNull(AMT_YTD_REV_30)),
						new SqlParameter("AMT_YTD_REV_31", SqlNull(AMT_YTD_REV_31)),
						new SqlParameter("AMT_YTD_REV_32", SqlNull(AMT_YTD_REV_32)),
						new SqlParameter("AMT_YTD_REV_33", SqlNull(AMT_YTD_REV_33)),
						new SqlParameter("AMT_YTD_REV_34", SqlNull(AMT_YTD_REV_34)),
						new SqlParameter("AMT_YTD_REV_35", SqlNull(AMT_YTD_REV_35)),
						new SqlParameter("AMT_YTD_EXP_01", SqlNull(AMT_YTD_EXP_01)),
						new SqlParameter("AMT_YTD_EXP_02", SqlNull(AMT_YTD_EXP_02)),
						new SqlParameter("AMT_YTD_EXP_03", SqlNull(AMT_YTD_EXP_03)),
						new SqlParameter("AMT_YTD_EXP_04", SqlNull(AMT_YTD_EXP_04)),
						new SqlParameter("AMT_YTD_EXP_05", SqlNull(AMT_YTD_EXP_05)),
						new SqlParameter("AMT_YTD_EXP_06", SqlNull(AMT_YTD_EXP_06)),
						new SqlParameter("AMT_YTD_EXP_07", SqlNull(AMT_YTD_EXP_07)),
						new SqlParameter("AMT_YTD_EXP_08", SqlNull(AMT_YTD_EXP_08)),
						new SqlParameter("AMT_YTD_EXP_09", SqlNull(AMT_YTD_EXP_09)),
						new SqlParameter("AMT_YTD_EXP_10", SqlNull(AMT_YTD_EXP_10)),
						new SqlParameter("AMTYTDTOTINCENDOFLASTFISCALYEAR", SqlNull(AMTYTDTOTINCENDOFLASTFISCALYEAR)),
						new SqlParameter("TEXT_MISC", SqlNull(TEXT_MISC)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_PC_DOWNLOAD_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CURRENT_EP_NBR = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						DOC_NBR = Reader["DOC_NBR"].ToString();
						DOC_DEPT = ConvertDEC(Reader["DOC_DEPT"]);
						DOC_OHIP_NBR = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						DOC_SIN_NBR = ConvertDEC(Reader["DOC_SIN_NBR"]);
						DOC_CLINIC_NBR = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						DOC_SPEC_CD = ConvertDEC(Reader["DOC_SPEC_CD"]);
						DOC_NAME = Reader["DOC_NAME"].ToString();
						DOC_INITS = Reader["DOC_INITS"].ToString();
						DOC_YRLY_CEILING_COMPUTED = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						DOC_DATE_FAC_START = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						DOC_DATE_FAC_TERM = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
						DOC_FULL_PART_IND = Reader["DOC_FULL_PART_IND"].ToString();
						DOC_YRLY_REQUIRE_REVENUE = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						DOC_GUARANTEE_PERCENTAGE = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]);
						DOC_GUARANTEE_FLAG = Reader["DOC_GUARANTEE_FLAG"].ToString();
						AMT_GROSS_CEIEXP = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]);
						AMT_NET_YTDCEX = ConvertDEC(Reader["AMT_NET_YTDCEX"]);
						DOC_PAY_CODE = Reader["DOC_PAY_CODE"].ToString();
						DOC_PAY_SUB_CODE = Reader["DOC_PAY_SUB_CODE"].ToString();
						AMT_YTD_TOTINC = ConvertDEC(Reader["AMT_YTD_TOTINC"]);
						AMT_YTD_INCEXP = ConvertDEC(Reader["AMT_YTD_INCEXP"]);
						AMT_YTD_DEPEXM = ConvertDEC(Reader["AMT_YTD_DEPEXM"]);
						AMT_YTD_DEPEXR = ConvertDEC(Reader["AMT_YTD_DEPEXR"]);
						AMT_YTD_YTDEAR = ConvertDEC(Reader["AMT_YTD_YTDEAR"]);
						AMT_YTD_DEPCHR = ConvertDEC(Reader["AMT_YTD_DEPCHR"]);
						AMT_MTD_PAYEFT = ConvertDEC(Reader["AMT_MTD_PAYEFT"]);
						AMT_YTD_RMAEXR = ConvertDEC(Reader["AMT_YTD_RMAEXR"]);
						AMT_YTD_GST = ConvertDEC(Reader["AMT_YTD_GST"]);
						AMT_YTD_BILL = ConvertDEC(Reader["AMT_YTD_BILL"]);
						AMT_YTD_RMAEXM = ConvertDEC(Reader["AMT_YTD_RMAEXM"]);
						AMT_MTD_PAYPOT = ConvertDEC(Reader["AMT_MTD_PAYPOT"]);
						AMT_MTD_GTYPEA = ConvertDEC(Reader["AMT_MTD_GTYPEA"]);
						AMT_MTD_REV_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]);
						AMT_YTD_REV_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]);
						AMT_MTD_REV_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]);
						AMT_YTD_REV_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]);
						AMT_MTD_REV_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]);
						AMT_YTD_REV_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]);
						AMT_MTD_REV_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]);
						AMT_YTD_REV_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]);
						AMT_MTD_REV_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]);
						AMT_YTD_REV_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]);
						AMT_MTD_REV_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]);
						AMT_YTD_REV_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]);
						AMT_MTD_REV_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]);
						AMT_YTD_REV_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]);
						AMT_MTD_REV_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]);
						AMT_YTD_REV_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]);
						AMT_MTD_REV_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]);
						AMT_YTD_REV_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]);
						AMT_MTD_REV_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]);
						AMT_YTD_REV_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]);
						AMT_MTD_REV_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]);
						AMT_YTD_REV_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]);
						AMT_MTD_REV_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]);
						AMT_YTD_REV_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]);
						AMT_MTD_REV_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]);
						AMT_YTD_REV_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]);
						AMT_MTD_REV_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]);
						AMT_YTD_REV_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]);
						AMT_MTD_REV_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]);
						AMT_YTD_REV_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]);
						AMT_MTD_REV_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]);
						AMT_YTD_REV_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]);
						AMT_MTD_REV_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]);
						AMT_YTD_REV_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]);
						AMT_MTD_REV_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]);
						AMT_YTD_REV_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]);
						AMT_MTD_REV_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]);
						AMT_YTD_REV_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]);
						AMT_MTD_REV_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]);
						AMT_YTD_REV_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]);
						AMT_YTD_REV_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]);
						AMT_YTD_REV_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]);
						AMT_YTD_REV_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]);
						AMT_YTD_REV_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]);
						AMT_YTD_REV_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]);
						AMT_YTD_REV_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]);
						AMT_YTD_REV_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]);
						AMT_YTD_REV_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]);
						AMT_YTD_REV_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]);
						AMT_YTD_REV_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]);
						AMT_YTD_REV_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]);
						AMT_YTD_REV_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]);
						AMT_YTD_REV_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]);
						AMT_YTD_REV_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]);
						AMT_YTD_REV_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]);
						AMT_YTD_EXP_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]);
						AMT_YTD_EXP_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]);
						AMT_YTD_EXP_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]);
						AMT_YTD_EXP_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]);
						AMT_YTD_EXP_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]);
						AMT_YTD_EXP_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]);
						AMT_YTD_EXP_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]);
						AMT_YTD_EXP_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]);
						AMT_YTD_EXP_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]);
						AMT_YTD_EXP_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]);
						AMTYTDTOTINCENDOFLASTFISCALYEAR = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]);
						TEXT_MISC = Reader["TEXT_MISC"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalCurrent_ep_nbr = ConvertDEC(Reader["CURRENT_EP_NBR"]);
						_originalDoc_nbr = Reader["DOC_NBR"].ToString();
						_originalDoc_dept = ConvertDEC(Reader["DOC_DEPT"]);
						_originalDoc_ohip_nbr = ConvertDEC(Reader["DOC_OHIP_NBR"]);
						_originalDoc_sin_nbr = ConvertDEC(Reader["DOC_SIN_NBR"]);
						_originalDoc_clinic_nbr = ConvertDEC(Reader["DOC_CLINIC_NBR"]);
						_originalDoc_spec_cd = ConvertDEC(Reader["DOC_SPEC_CD"]);
						_originalDoc_name = Reader["DOC_NAME"].ToString();
						_originalDoc_inits = Reader["DOC_INITS"].ToString();
						_originalDoc_yrly_ceiling_computed = ConvertDEC(Reader["DOC_YRLY_CEILING_COMPUTED"]);
						_originalDoc_date_fac_start = ConvertDEC(Reader["DOC_DATE_FAC_START"]);
						_originalDoc_date_fac_term = ConvertDEC(Reader["DOC_DATE_FAC_TERM"]);
						_originalDoc_full_part_ind = Reader["DOC_FULL_PART_IND"].ToString();
						_originalDoc_yrly_require_revenue = ConvertDEC(Reader["DOC_YRLY_REQUIRE_REVENUE"]);
						_originalDoc_guarantee_percentage = ConvertDEC(Reader["DOC_GUARANTEE_PERCENTAGE"]);
						_originalDoc_guarantee_flag = Reader["DOC_GUARANTEE_FLAG"].ToString();
						_originalAmt_gross_ceiexp = ConvertDEC(Reader["AMT_GROSS_CEIEXP"]);
						_originalAmt_net_ytdcex = ConvertDEC(Reader["AMT_NET_YTDCEX"]);
						_originalDoc_pay_code = Reader["DOC_PAY_CODE"].ToString();
						_originalDoc_pay_sub_code = Reader["DOC_PAY_SUB_CODE"].ToString();
						_originalAmt_ytd_totinc = ConvertDEC(Reader["AMT_YTD_TOTINC"]);
						_originalAmt_ytd_incexp = ConvertDEC(Reader["AMT_YTD_INCEXP"]);
						_originalAmt_ytd_depexm = ConvertDEC(Reader["AMT_YTD_DEPEXM"]);
						_originalAmt_ytd_depexr = ConvertDEC(Reader["AMT_YTD_DEPEXR"]);
						_originalAmt_ytd_ytdear = ConvertDEC(Reader["AMT_YTD_YTDEAR"]);
						_originalAmt_ytd_depchr = ConvertDEC(Reader["AMT_YTD_DEPCHR"]);
						_originalAmt_mtd_payeft = ConvertDEC(Reader["AMT_MTD_PAYEFT"]);
						_originalAmt_ytd_rmaexr = ConvertDEC(Reader["AMT_YTD_RMAEXR"]);
						_originalAmt_ytd_gst = ConvertDEC(Reader["AMT_YTD_GST"]);
						_originalAmt_ytd_bill = ConvertDEC(Reader["AMT_YTD_BILL"]);
						_originalAmt_ytd_rmaexm = ConvertDEC(Reader["AMT_YTD_RMAEXM"]);
						_originalAmt_mtd_paypot = ConvertDEC(Reader["AMT_MTD_PAYPOT"]);
						_originalAmt_mtd_gtypea = ConvertDEC(Reader["AMT_MTD_GTYPEA"]);
						_originalAmt_mtd_rev_01 = ConvertDEC(Reader["AMT_MTD_REV_01"]);
						_originalAmt_ytd_rev_01 = ConvertDEC(Reader["AMT_YTD_REV_01"]);
						_originalAmt_mtd_rev_02 = ConvertDEC(Reader["AMT_MTD_REV_02"]);
						_originalAmt_ytd_rev_02 = ConvertDEC(Reader["AMT_YTD_REV_02"]);
						_originalAmt_mtd_rev_03 = ConvertDEC(Reader["AMT_MTD_REV_03"]);
						_originalAmt_ytd_rev_03 = ConvertDEC(Reader["AMT_YTD_REV_03"]);
						_originalAmt_mtd_rev_04 = ConvertDEC(Reader["AMT_MTD_REV_04"]);
						_originalAmt_ytd_rev_04 = ConvertDEC(Reader["AMT_YTD_REV_04"]);
						_originalAmt_mtd_rev_05 = ConvertDEC(Reader["AMT_MTD_REV_05"]);
						_originalAmt_ytd_rev_05 = ConvertDEC(Reader["AMT_YTD_REV_05"]);
						_originalAmt_mtd_rev_06 = ConvertDEC(Reader["AMT_MTD_REV_06"]);
						_originalAmt_ytd_rev_06 = ConvertDEC(Reader["AMT_YTD_REV_06"]);
						_originalAmt_mtd_rev_07 = ConvertDEC(Reader["AMT_MTD_REV_07"]);
						_originalAmt_ytd_rev_07 = ConvertDEC(Reader["AMT_YTD_REV_07"]);
						_originalAmt_mtd_rev_08 = ConvertDEC(Reader["AMT_MTD_REV_08"]);
						_originalAmt_ytd_rev_08 = ConvertDEC(Reader["AMT_YTD_REV_08"]);
						_originalAmt_mtd_rev_09 = ConvertDEC(Reader["AMT_MTD_REV_09"]);
						_originalAmt_ytd_rev_09 = ConvertDEC(Reader["AMT_YTD_REV_09"]);
						_originalAmt_mtd_rev_10 = ConvertDEC(Reader["AMT_MTD_REV_10"]);
						_originalAmt_ytd_rev_10 = ConvertDEC(Reader["AMT_YTD_REV_10"]);
						_originalAmt_mtd_rev_11 = ConvertDEC(Reader["AMT_MTD_REV_11"]);
						_originalAmt_ytd_rev_11 = ConvertDEC(Reader["AMT_YTD_REV_11"]);
						_originalAmt_mtd_rev_12 = ConvertDEC(Reader["AMT_MTD_REV_12"]);
						_originalAmt_ytd_rev_12 = ConvertDEC(Reader["AMT_YTD_REV_12"]);
						_originalAmt_mtd_rev_13 = ConvertDEC(Reader["AMT_MTD_REV_13"]);
						_originalAmt_ytd_rev_13 = ConvertDEC(Reader["AMT_YTD_REV_13"]);
						_originalAmt_mtd_rev_14 = ConvertDEC(Reader["AMT_MTD_REV_14"]);
						_originalAmt_ytd_rev_14 = ConvertDEC(Reader["AMT_YTD_REV_14"]);
						_originalAmt_mtd_rev_15 = ConvertDEC(Reader["AMT_MTD_REV_15"]);
						_originalAmt_ytd_rev_15 = ConvertDEC(Reader["AMT_YTD_REV_15"]);
						_originalAmt_mtd_rev_16 = ConvertDEC(Reader["AMT_MTD_REV_16"]);
						_originalAmt_ytd_rev_16 = ConvertDEC(Reader["AMT_YTD_REV_16"]);
						_originalAmt_mtd_rev_17 = ConvertDEC(Reader["AMT_MTD_REV_17"]);
						_originalAmt_ytd_rev_17 = ConvertDEC(Reader["AMT_YTD_REV_17"]);
						_originalAmt_mtd_rev_18 = ConvertDEC(Reader["AMT_MTD_REV_18"]);
						_originalAmt_ytd_rev_18 = ConvertDEC(Reader["AMT_YTD_REV_18"]);
						_originalAmt_mtd_rev_19 = ConvertDEC(Reader["AMT_MTD_REV_19"]);
						_originalAmt_ytd_rev_19 = ConvertDEC(Reader["AMT_YTD_REV_19"]);
						_originalAmt_mtd_rev_20 = ConvertDEC(Reader["AMT_MTD_REV_20"]);
						_originalAmt_ytd_rev_20 = ConvertDEC(Reader["AMT_YTD_REV_20"]);
						_originalAmt_ytd_rev_21 = ConvertDEC(Reader["AMT_YTD_REV_21"]);
						_originalAmt_ytd_rev_22 = ConvertDEC(Reader["AMT_YTD_REV_22"]);
						_originalAmt_ytd_rev_23 = ConvertDEC(Reader["AMT_YTD_REV_23"]);
						_originalAmt_ytd_rev_24 = ConvertDEC(Reader["AMT_YTD_REV_24"]);
						_originalAmt_ytd_rev_25 = ConvertDEC(Reader["AMT_YTD_REV_25"]);
						_originalAmt_ytd_rev_26 = ConvertDEC(Reader["AMT_YTD_REV_26"]);
						_originalAmt_ytd_rev_27 = ConvertDEC(Reader["AMT_YTD_REV_27"]);
						_originalAmt_ytd_rev_28 = ConvertDEC(Reader["AMT_YTD_REV_28"]);
						_originalAmt_ytd_rev_29 = ConvertDEC(Reader["AMT_YTD_REV_29"]);
						_originalAmt_ytd_rev_30 = ConvertDEC(Reader["AMT_YTD_REV_30"]);
						_originalAmt_ytd_rev_31 = ConvertDEC(Reader["AMT_YTD_REV_31"]);
						_originalAmt_ytd_rev_32 = ConvertDEC(Reader["AMT_YTD_REV_32"]);
						_originalAmt_ytd_rev_33 = ConvertDEC(Reader["AMT_YTD_REV_33"]);
						_originalAmt_ytd_rev_34 = ConvertDEC(Reader["AMT_YTD_REV_34"]);
						_originalAmt_ytd_rev_35 = ConvertDEC(Reader["AMT_YTD_REV_35"]);
						_originalAmt_ytd_exp_01 = ConvertDEC(Reader["AMT_YTD_EXP_01"]);
						_originalAmt_ytd_exp_02 = ConvertDEC(Reader["AMT_YTD_EXP_02"]);
						_originalAmt_ytd_exp_03 = ConvertDEC(Reader["AMT_YTD_EXP_03"]);
						_originalAmt_ytd_exp_04 = ConvertDEC(Reader["AMT_YTD_EXP_04"]);
						_originalAmt_ytd_exp_05 = ConvertDEC(Reader["AMT_YTD_EXP_05"]);
						_originalAmt_ytd_exp_06 = ConvertDEC(Reader["AMT_YTD_EXP_06"]);
						_originalAmt_ytd_exp_07 = ConvertDEC(Reader["AMT_YTD_EXP_07"]);
						_originalAmt_ytd_exp_08 = ConvertDEC(Reader["AMT_YTD_EXP_08"]);
						_originalAmt_ytd_exp_09 = ConvertDEC(Reader["AMT_YTD_EXP_09"]);
						_originalAmt_ytd_exp_10 = ConvertDEC(Reader["AMT_YTD_EXP_10"]);
						_originalAmtytdtotincendoflastfiscalyear = ConvertDEC(Reader["AMTYTDTOTINCENDOFLASTFISCALYEAR"]);
						_originalText_misc = Reader["TEXT_MISC"].ToString();
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