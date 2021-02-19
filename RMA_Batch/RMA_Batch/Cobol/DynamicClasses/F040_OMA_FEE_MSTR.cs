using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F040_OMA_FEE_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F040_OMA_FEE_MSTR> Collection( Guid? rowid,
															string fee_oma_cd_ltr1,
															string filler_numeric,
															string fee_special_m_suffix_ind,
															decimal? fee_date_yymin,
															decimal? fee_date_yymax,
															decimal? fee_date_mmmin,
															decimal? fee_date_mmmax,
															decimal? fee_date_ddmin,
															decimal? fee_date_ddmax,
															string fee_active_for_entry,
															string fee_desc,
															decimal? fee_curr_a_fee_1min,
															decimal? fee_curr_a_fee_1max,
															decimal? fee_curr_h_fee_1min,
															decimal? fee_curr_h_fee_1max,
															decimal? fee_curr_a_fee_2min,
															decimal? fee_curr_a_fee_2max,
															decimal? fee_curr_h_fee_2min,
															decimal? fee_curr_h_fee_2max,
															decimal? fee_curr_a_minmin,
															decimal? fee_curr_a_minmax,
															decimal? fee_curr_h_minmin,
															decimal? fee_curr_h_minmax,
															decimal? fee_curr_a_maxmin,
															decimal? fee_curr_a_maxmax,
															decimal? fee_curr_h_maxmin,
															decimal? fee_curr_h_maxmax,
															decimal? fee_curr_a_anaemin,
															decimal? fee_curr_a_anaemax,
															decimal? fee_curr_h_anaemin,
															decimal? fee_curr_h_anaemax,
															decimal? fee_curr_a_asstmin,
															decimal? fee_curr_a_asstmax,
															decimal? fee_curr_h_asstmin,
															decimal? fee_curr_h_asstmax,
															string fee_curr_add_on_cd1,
															string fee_curr_add_on_cd2,
															string fee_curr_add_on_cd3,
															string fee_curr_add_on_cd4,
															string fee_curr_add_on_cd5,
															string fee_curr_add_on_cd6,
															string fee_curr_add_on_cd7,
															string fee_curr_add_on_cd8,
															string fee_curr_add_on_cd9,
															string fee_curr_add_on_cd10,
															string fee_curr_oma_ind_card_required1,
															string fee_curr_oma_ind_card_required2,
															string fee_curr_oma_ind_card_required3,
															string fee_curr_page_alpha,
															decimal? fee_curr_page_numericmin,
															decimal? fee_curr_page_numericmax,
															string fee_curr_add_on_perc_or_flat_ind,
															decimal? fee_prev_a_fee_1min,
															decimal? fee_prev_a_fee_1max,
															decimal? fee_prev_h_fee_1min,
															decimal? fee_prev_h_fee_1max,
															decimal? fee_prev_a_fee_2min,
															decimal? fee_prev_a_fee_2max,
															decimal? fee_prev_h_fee_2min,
															decimal? fee_prev_h_fee_2max,
															decimal? fee_prev_a_minmin,
															decimal? fee_prev_a_minmax,
															decimal? fee_prev_h_minmin,
															decimal? fee_prev_h_minmax,
															decimal? fee_prev_a_maxmin,
															decimal? fee_prev_a_maxmax,
															decimal? fee_prev_h_maxmin,
															decimal? fee_prev_h_maxmax,
															decimal? fee_prev_a_anaemin,
															decimal? fee_prev_a_anaemax,
															decimal? fee_prev_h_anaemin,
															decimal? fee_prev_h_anaemax,
															decimal? fee_prev_a_asstmin,
															decimal? fee_prev_a_asstmax,
															decimal? fee_prev_h_asstmin,
															decimal? fee_prev_h_asstmax,
															string fee_prev_add_on_cd1,
															string fee_prev_add_on_cd2,
															string fee_prev_add_on_cd3,
															string fee_prev_add_on_cd4,
															string fee_prev_add_on_cd5,
															string fee_prev_add_on_cd6,
															string fee_prev_add_on_cd7,
															string fee_prev_add_on_cd8,
															string fee_prev_add_on_cd9,
															string fee_prev_add_on_cd10,
															string fee_prev_oma_ind_card_required1,
															string fee_prev_oma_ind_card_required2,
															string fee_prev_oma_ind_card_required3,
															string fee_prev_page_alpha,
															decimal? fee_prev_page_numericmin,
															decimal? fee_prev_page_numericmax,
															string fee_prev_add_on_perc_or_flat_ind,
															string fee_icc_sec,
															decimal? fee_icc_catmin,
															decimal? fee_icc_catmax,
															decimal? fee_icc_grpmin,
															decimal? fee_icc_grpmax,
															decimal? fee_icc_reduc_indmin,
															decimal? fee_icc_reduc_indmax,
															string fee_diag_ind,
															string fee_phy_ind,
															string fee_tech_ind,
															string fee_hosp_nbr_ind,
															string fee_i_o_ind,
															string fee_admit_ind,
															decimal? fee_spec_frmin,
															decimal? fee_spec_frmax,
															decimal? fee_spec_tomin,
															decimal? fee_spec_tomax,
															string feeglobaladdoncdexclusionflag,
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
					new SqlParameter("FEE_OMA_CD_LTR1",fee_oma_cd_ltr1),
					new SqlParameter("FILLER_NUMERIC",filler_numeric),
					new SqlParameter("FEE_SPECIAL_M_SUFFIX_IND",fee_special_m_suffix_ind),
					new SqlParameter("minFEE_DATE_YY",fee_date_yymin),
					new SqlParameter("maxFEE_DATE_YY",fee_date_yymax),
					new SqlParameter("minFEE_DATE_MM",fee_date_mmmin),
					new SqlParameter("maxFEE_DATE_MM",fee_date_mmmax),
					new SqlParameter("minFEE_DATE_DD",fee_date_ddmin),
					new SqlParameter("maxFEE_DATE_DD",fee_date_ddmax),
					new SqlParameter("FEE_ACTIVE_FOR_ENTRY",fee_active_for_entry),
					new SqlParameter("FEE_DESC",fee_desc),
					new SqlParameter("minFEE_CURR_A_FEE_1",fee_curr_a_fee_1min),
					new SqlParameter("maxFEE_CURR_A_FEE_1",fee_curr_a_fee_1max),
					new SqlParameter("minFEE_CURR_H_FEE_1",fee_curr_h_fee_1min),
					new SqlParameter("maxFEE_CURR_H_FEE_1",fee_curr_h_fee_1max),
					new SqlParameter("minFEE_CURR_A_FEE_2",fee_curr_a_fee_2min),
					new SqlParameter("maxFEE_CURR_A_FEE_2",fee_curr_a_fee_2max),
					new SqlParameter("minFEE_CURR_H_FEE_2",fee_curr_h_fee_2min),
					new SqlParameter("maxFEE_CURR_H_FEE_2",fee_curr_h_fee_2max),
					new SqlParameter("minFEE_CURR_A_MIN",fee_curr_a_minmin),
					new SqlParameter("maxFEE_CURR_A_MIN",fee_curr_a_minmax),
					new SqlParameter("minFEE_CURR_H_MIN",fee_curr_h_minmin),
					new SqlParameter("maxFEE_CURR_H_MIN",fee_curr_h_minmax),
					new SqlParameter("minFEE_CURR_A_MAX",fee_curr_a_maxmin),
					new SqlParameter("maxFEE_CURR_A_MAX",fee_curr_a_maxmax),
					new SqlParameter("minFEE_CURR_H_MAX",fee_curr_h_maxmin),
					new SqlParameter("maxFEE_CURR_H_MAX",fee_curr_h_maxmax),
					new SqlParameter("minFEE_CURR_A_ANAE",fee_curr_a_anaemin),
					new SqlParameter("maxFEE_CURR_A_ANAE",fee_curr_a_anaemax),
					new SqlParameter("minFEE_CURR_H_ANAE",fee_curr_h_anaemin),
					new SqlParameter("maxFEE_CURR_H_ANAE",fee_curr_h_anaemax),
					new SqlParameter("minFEE_CURR_A_ASST",fee_curr_a_asstmin),
					new SqlParameter("maxFEE_CURR_A_ASST",fee_curr_a_asstmax),
					new SqlParameter("minFEE_CURR_H_ASST",fee_curr_h_asstmin),
					new SqlParameter("maxFEE_CURR_H_ASST",fee_curr_h_asstmax),
					new SqlParameter("FEE_CURR_ADD_ON_CD1",fee_curr_add_on_cd1),
					new SqlParameter("FEE_CURR_ADD_ON_CD2",fee_curr_add_on_cd2),
					new SqlParameter("FEE_CURR_ADD_ON_CD3",fee_curr_add_on_cd3),
					new SqlParameter("FEE_CURR_ADD_ON_CD4",fee_curr_add_on_cd4),
					new SqlParameter("FEE_CURR_ADD_ON_CD5",fee_curr_add_on_cd5),
					new SqlParameter("FEE_CURR_ADD_ON_CD6",fee_curr_add_on_cd6),
					new SqlParameter("FEE_CURR_ADD_ON_CD7",fee_curr_add_on_cd7),
					new SqlParameter("FEE_CURR_ADD_ON_CD8",fee_curr_add_on_cd8),
					new SqlParameter("FEE_CURR_ADD_ON_CD9",fee_curr_add_on_cd9),
					new SqlParameter("FEE_CURR_ADD_ON_CD10",fee_curr_add_on_cd10),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED1",fee_curr_oma_ind_card_required1),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED2",fee_curr_oma_ind_card_required2),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED3",fee_curr_oma_ind_card_required3),
					new SqlParameter("FEE_CURR_PAGE_ALPHA",fee_curr_page_alpha),
					new SqlParameter("minFEE_CURR_PAGE_NUMERIC",fee_curr_page_numericmin),
					new SqlParameter("maxFEE_CURR_PAGE_NUMERIC",fee_curr_page_numericmax),
					new SqlParameter("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND",fee_curr_add_on_perc_or_flat_ind),
					new SqlParameter("minFEE_PREV_A_FEE_1",fee_prev_a_fee_1min),
					new SqlParameter("maxFEE_PREV_A_FEE_1",fee_prev_a_fee_1max),
					new SqlParameter("minFEE_PREV_H_FEE_1",fee_prev_h_fee_1min),
					new SqlParameter("maxFEE_PREV_H_FEE_1",fee_prev_h_fee_1max),
					new SqlParameter("minFEE_PREV_A_FEE_2",fee_prev_a_fee_2min),
					new SqlParameter("maxFEE_PREV_A_FEE_2",fee_prev_a_fee_2max),
					new SqlParameter("minFEE_PREV_H_FEE_2",fee_prev_h_fee_2min),
					new SqlParameter("maxFEE_PREV_H_FEE_2",fee_prev_h_fee_2max),
					new SqlParameter("minFEE_PREV_A_MIN",fee_prev_a_minmin),
					new SqlParameter("maxFEE_PREV_A_MIN",fee_prev_a_minmax),
					new SqlParameter("minFEE_PREV_H_MIN",fee_prev_h_minmin),
					new SqlParameter("maxFEE_PREV_H_MIN",fee_prev_h_minmax),
					new SqlParameter("minFEE_PREV_A_MAX",fee_prev_a_maxmin),
					new SqlParameter("maxFEE_PREV_A_MAX",fee_prev_a_maxmax),
					new SqlParameter("minFEE_PREV_H_MAX",fee_prev_h_maxmin),
					new SqlParameter("maxFEE_PREV_H_MAX",fee_prev_h_maxmax),
					new SqlParameter("minFEE_PREV_A_ANAE",fee_prev_a_anaemin),
					new SqlParameter("maxFEE_PREV_A_ANAE",fee_prev_a_anaemax),
					new SqlParameter("minFEE_PREV_H_ANAE",fee_prev_h_anaemin),
					new SqlParameter("maxFEE_PREV_H_ANAE",fee_prev_h_anaemax),
					new SqlParameter("minFEE_PREV_A_ASST",fee_prev_a_asstmin),
					new SqlParameter("maxFEE_PREV_A_ASST",fee_prev_a_asstmax),
					new SqlParameter("minFEE_PREV_H_ASST",fee_prev_h_asstmin),
					new SqlParameter("maxFEE_PREV_H_ASST",fee_prev_h_asstmax),
					new SqlParameter("FEE_PREV_ADD_ON_CD1",fee_prev_add_on_cd1),
					new SqlParameter("FEE_PREV_ADD_ON_CD2",fee_prev_add_on_cd2),
					new SqlParameter("FEE_PREV_ADD_ON_CD3",fee_prev_add_on_cd3),
					new SqlParameter("FEE_PREV_ADD_ON_CD4",fee_prev_add_on_cd4),
					new SqlParameter("FEE_PREV_ADD_ON_CD5",fee_prev_add_on_cd5),
					new SqlParameter("FEE_PREV_ADD_ON_CD6",fee_prev_add_on_cd6),
					new SqlParameter("FEE_PREV_ADD_ON_CD7",fee_prev_add_on_cd7),
					new SqlParameter("FEE_PREV_ADD_ON_CD8",fee_prev_add_on_cd8),
					new SqlParameter("FEE_PREV_ADD_ON_CD9",fee_prev_add_on_cd9),
					new SqlParameter("FEE_PREV_ADD_ON_CD10",fee_prev_add_on_cd10),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED1",fee_prev_oma_ind_card_required1),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED2",fee_prev_oma_ind_card_required2),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED3",fee_prev_oma_ind_card_required3),
					new SqlParameter("FEE_PREV_PAGE_ALPHA",fee_prev_page_alpha),
					new SqlParameter("minFEE_PREV_PAGE_NUMERIC",fee_prev_page_numericmin),
					new SqlParameter("maxFEE_PREV_PAGE_NUMERIC",fee_prev_page_numericmax),
					new SqlParameter("FEE_PREV_ADD_ON_PERC_OR_FLAT_IND",fee_prev_add_on_perc_or_flat_ind),
					new SqlParameter("FEE_ICC_SEC",fee_icc_sec),
					new SqlParameter("minFEE_ICC_CAT",fee_icc_catmin),
					new SqlParameter("maxFEE_ICC_CAT",fee_icc_catmax),
					new SqlParameter("minFEE_ICC_GRP",fee_icc_grpmin),
					new SqlParameter("maxFEE_ICC_GRP",fee_icc_grpmax),
					new SqlParameter("minFEE_ICC_REDUC_IND",fee_icc_reduc_indmin),
					new SqlParameter("maxFEE_ICC_REDUC_IND",fee_icc_reduc_indmax),
					new SqlParameter("FEE_DIAG_IND",fee_diag_ind),
					new SqlParameter("FEE_PHY_IND",fee_phy_ind),
					new SqlParameter("FEE_TECH_IND",fee_tech_ind),
					new SqlParameter("FEE_HOSP_NBR_IND",fee_hosp_nbr_ind),
					new SqlParameter("FEE_I_O_IND",fee_i_o_ind),
					new SqlParameter("FEE_ADMIT_IND",fee_admit_ind),
					new SqlParameter("minFEE_SPEC_FR",fee_spec_frmin),
					new SqlParameter("maxFEE_SPEC_FR",fee_spec_frmax),
					new SqlParameter("minFEE_SPEC_TO",fee_spec_tomin),
					new SqlParameter("maxFEE_SPEC_TO",fee_spec_tomax),
					new SqlParameter("FEEGLOBALADDONCDEXCLUSIONFLAG",feeglobaladdoncdexclusionflag),
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
                Reader = CoreReader("[INDEXED].[sp_F040_OMA_FEE_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F040_OMA_FEE_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F040_OMA_FEE_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F040_OMA_FEE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FEE_OMA_CD_LTR1 = Reader["FEE_OMA_CD_LTR1"].ToString(),
					FILLER_NUMERIC = Reader["FILLER_NUMERIC"].ToString(),
					FEE_SPECIAL_M_SUFFIX_IND = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString(),
					FEE_DATE_YY = ConvertDEC(Reader["FEE_DATE_YY"]),
					FEE_DATE_MM = ConvertDEC(Reader["FEE_DATE_MM"]),
					FEE_DATE_DD = ConvertDEC(Reader["FEE_DATE_DD"]),
					FEE_ACTIVE_FOR_ENTRY = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString(),
					FEE_DESC = Reader["FEE_DESC"].ToString(),
					FEE_CURR_A_FEE_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]),
					FEE_CURR_H_FEE_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]),
					FEE_CURR_A_FEE_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]),
					FEE_CURR_H_FEE_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]),
					FEE_CURR_A_MIN = ConvertDEC(Reader["FEE_CURR_A_MIN"]),
					FEE_CURR_H_MIN = ConvertDEC(Reader["FEE_CURR_H_MIN"]),
					FEE_CURR_A_MAX = ConvertDEC(Reader["FEE_CURR_A_MAX"]),
					FEE_CURR_H_MAX = ConvertDEC(Reader["FEE_CURR_H_MAX"]),
					FEE_CURR_A_ANAE = ConvertDEC(Reader["FEE_CURR_A_ANAE"]),
					FEE_CURR_H_ANAE = ConvertDEC(Reader["FEE_CURR_H_ANAE"]),
					FEE_CURR_A_ASST = ConvertDEC(Reader["FEE_CURR_A_ASST"]),
					FEE_CURR_H_ASST = ConvertDEC(Reader["FEE_CURR_H_ASST"]),
					FEE_CURR_ADD_ON_CD1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString(),
					FEE_CURR_ADD_ON_CD2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString(),
					FEE_CURR_ADD_ON_CD3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString(),
					FEE_CURR_ADD_ON_CD4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString(),
					FEE_CURR_ADD_ON_CD5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString(),
					FEE_CURR_ADD_ON_CD6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString(),
					FEE_CURR_ADD_ON_CD7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString(),
					FEE_CURR_ADD_ON_CD8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString(),
					FEE_CURR_ADD_ON_CD9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString(),
					FEE_CURR_ADD_ON_CD10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString(),
					FEE_CURR_PAGE_ALPHA = Reader["FEE_CURR_PAGE_ALPHA"].ToString(),
					FEE_CURR_PAGE_NUMERIC = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]),
					FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					FEE_PREV_A_FEE_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]),
					FEE_PREV_H_FEE_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]),
					FEE_PREV_A_FEE_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]),
					FEE_PREV_H_FEE_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]),
					FEE_PREV_A_MIN = ConvertDEC(Reader["FEE_PREV_A_MIN"]),
					FEE_PREV_H_MIN = ConvertDEC(Reader["FEE_PREV_H_MIN"]),
					FEE_PREV_A_MAX = ConvertDEC(Reader["FEE_PREV_A_MAX"]),
					FEE_PREV_H_MAX = ConvertDEC(Reader["FEE_PREV_H_MAX"]),
					FEE_PREV_A_ANAE = ConvertDEC(Reader["FEE_PREV_A_ANAE"]),
					FEE_PREV_H_ANAE = ConvertDEC(Reader["FEE_PREV_H_ANAE"]),
					FEE_PREV_A_ASST = ConvertDEC(Reader["FEE_PREV_A_ASST"]),
					FEE_PREV_H_ASST = ConvertDEC(Reader["FEE_PREV_H_ASST"]),
					FEE_PREV_ADD_ON_CD1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString(),
					FEE_PREV_ADD_ON_CD2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString(),
					FEE_PREV_ADD_ON_CD3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString(),
					FEE_PREV_ADD_ON_CD4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString(),
					FEE_PREV_ADD_ON_CD5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString(),
					FEE_PREV_ADD_ON_CD6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString(),
					FEE_PREV_ADD_ON_CD7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString(),
					FEE_PREV_ADD_ON_CD8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString(),
					FEE_PREV_ADD_ON_CD9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString(),
					FEE_PREV_ADD_ON_CD10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString(),
					FEE_PREV_PAGE_ALPHA = Reader["FEE_PREV_PAGE_ALPHA"].ToString(),
					FEE_PREV_PAGE_NUMERIC = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]),
					FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					FEE_ICC_SEC = Reader["FEE_ICC_SEC"].ToString(),
					FEE_ICC_CAT = ConvertDEC(Reader["FEE_ICC_CAT"]),
					FEE_ICC_GRP = ConvertDEC(Reader["FEE_ICC_GRP"]),
					FEE_ICC_REDUC_IND = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]),
					FEE_DIAG_IND = Reader["FEE_DIAG_IND"].ToString(),
					FEE_PHY_IND = Reader["FEE_PHY_IND"].ToString(),
					FEE_TECH_IND = Reader["FEE_TECH_IND"].ToString(),
					FEE_HOSP_NBR_IND = Reader["FEE_HOSP_NBR_IND"].ToString(),
					FEE_I_O_IND = Reader["FEE_I_O_IND"].ToString(),
					FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString(),
					FEE_SPEC_FR = ConvertDEC(Reader["FEE_SPEC_FR"]),
					FEE_SPEC_TO = ConvertDEC(Reader["FEE_SPEC_TO"]),
					FEEGLOBALADDONCDEXCLUSIONFLAG = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFee_oma_cd_ltr1 = Reader["FEE_OMA_CD_LTR1"].ToString(),
					_originalFiller_numeric = Reader["FILLER_NUMERIC"].ToString(),
					_originalFee_special_m_suffix_ind = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString(),
					_originalFee_date_yy = ConvertDEC(Reader["FEE_DATE_YY"]),
					_originalFee_date_mm = ConvertDEC(Reader["FEE_DATE_MM"]),
					_originalFee_date_dd = ConvertDEC(Reader["FEE_DATE_DD"]),
					_originalFee_active_for_entry = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString(),
					_originalFee_desc = Reader["FEE_DESC"].ToString(),
					_originalFee_curr_a_fee_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]),
					_originalFee_curr_h_fee_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]),
					_originalFee_curr_a_fee_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]),
					_originalFee_curr_h_fee_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]),
					_originalFee_curr_a_min = ConvertDEC(Reader["FEE_CURR_A_MIN"]),
					_originalFee_curr_h_min = ConvertDEC(Reader["FEE_CURR_H_MIN"]),
					_originalFee_curr_a_max = ConvertDEC(Reader["FEE_CURR_A_MAX"]),
					_originalFee_curr_h_max = ConvertDEC(Reader["FEE_CURR_H_MAX"]),
					_originalFee_curr_a_anae = ConvertDEC(Reader["FEE_CURR_A_ANAE"]),
					_originalFee_curr_h_anae = ConvertDEC(Reader["FEE_CURR_H_ANAE"]),
					_originalFee_curr_a_asst = ConvertDEC(Reader["FEE_CURR_A_ASST"]),
					_originalFee_curr_h_asst = ConvertDEC(Reader["FEE_CURR_H_ASST"]),
					_originalFee_curr_add_on_cd1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString(),
					_originalFee_curr_add_on_cd2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString(),
					_originalFee_curr_add_on_cd3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString(),
					_originalFee_curr_add_on_cd4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString(),
					_originalFee_curr_add_on_cd5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString(),
					_originalFee_curr_add_on_cd6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString(),
					_originalFee_curr_add_on_cd7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString(),
					_originalFee_curr_add_on_cd8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString(),
					_originalFee_curr_add_on_cd9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString(),
					_originalFee_curr_add_on_cd10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString(),
					_originalFee_curr_oma_ind_card_required1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString(),
					_originalFee_curr_oma_ind_card_required2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString(),
					_originalFee_curr_oma_ind_card_required3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString(),
					_originalFee_curr_page_alpha = Reader["FEE_CURR_PAGE_ALPHA"].ToString(),
					_originalFee_curr_page_numeric = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]),
					_originalFee_curr_add_on_perc_or_flat_ind = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					_originalFee_prev_a_fee_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]),
					_originalFee_prev_h_fee_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]),
					_originalFee_prev_a_fee_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]),
					_originalFee_prev_h_fee_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]),
					_originalFee_prev_a_min = ConvertDEC(Reader["FEE_PREV_A_MIN"]),
					_originalFee_prev_h_min = ConvertDEC(Reader["FEE_PREV_H_MIN"]),
					_originalFee_prev_a_max = ConvertDEC(Reader["FEE_PREV_A_MAX"]),
					_originalFee_prev_h_max = ConvertDEC(Reader["FEE_PREV_H_MAX"]),
					_originalFee_prev_a_anae = ConvertDEC(Reader["FEE_PREV_A_ANAE"]),
					_originalFee_prev_h_anae = ConvertDEC(Reader["FEE_PREV_H_ANAE"]),
					_originalFee_prev_a_asst = ConvertDEC(Reader["FEE_PREV_A_ASST"]),
					_originalFee_prev_h_asst = ConvertDEC(Reader["FEE_PREV_H_ASST"]),
					_originalFee_prev_add_on_cd1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString(),
					_originalFee_prev_add_on_cd2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString(),
					_originalFee_prev_add_on_cd3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString(),
					_originalFee_prev_add_on_cd4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString(),
					_originalFee_prev_add_on_cd5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString(),
					_originalFee_prev_add_on_cd6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString(),
					_originalFee_prev_add_on_cd7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString(),
					_originalFee_prev_add_on_cd8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString(),
					_originalFee_prev_add_on_cd9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString(),
					_originalFee_prev_add_on_cd10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString(),
					_originalFee_prev_oma_ind_card_required1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString(),
					_originalFee_prev_oma_ind_card_required2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString(),
					_originalFee_prev_oma_ind_card_required3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString(),
					_originalFee_prev_page_alpha = Reader["FEE_PREV_PAGE_ALPHA"].ToString(),
					_originalFee_prev_page_numeric = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]),
					_originalFee_prev_add_on_perc_or_flat_ind = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					_originalFee_icc_sec = Reader["FEE_ICC_SEC"].ToString(),
					_originalFee_icc_cat = ConvertDEC(Reader["FEE_ICC_CAT"]),
					_originalFee_icc_grp = ConvertDEC(Reader["FEE_ICC_GRP"]),
					_originalFee_icc_reduc_ind = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]),
					_originalFee_diag_ind = Reader["FEE_DIAG_IND"].ToString(),
					_originalFee_phy_ind = Reader["FEE_PHY_IND"].ToString(),
					_originalFee_tech_ind = Reader["FEE_TECH_IND"].ToString(),
					_originalFee_hosp_nbr_ind = Reader["FEE_HOSP_NBR_IND"].ToString(),
					_originalFee_i_o_ind = Reader["FEE_I_O_IND"].ToString(),
					_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString(),
					_originalFee_spec_fr = ConvertDEC(Reader["FEE_SPEC_FR"]),
					_originalFee_spec_to = ConvertDEC(Reader["FEE_SPEC_TO"]),
					_originalFeeglobaladdoncdexclusionflag = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F040_OMA_FEE_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F040_OMA_FEE_MSTR> Collection(ObservableCollection<F040_OMA_FEE_MSTR>
                                                               f040OmaFeeMstr = null)
        {
            if (IsSameSearch() && f040OmaFeeMstr != null)
            {
                return f040OmaFeeMstr;
            }

           /* if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F040_OMA_FEE_MSTR>();
            } */

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("FEE_OMA_CD_LTR1",WhereFee_oma_cd_ltr1),
					new SqlParameter("FILLER_NUMERIC",WhereFiller_numeric),
					new SqlParameter("FEE_SPECIAL_M_SUFFIX_IND",WhereFee_special_m_suffix_ind),
					new SqlParameter("FEE_DATE_YY",WhereFee_date_yy),
					new SqlParameter("FEE_DATE_MM",WhereFee_date_mm),
					new SqlParameter("FEE_DATE_DD",WhereFee_date_dd),
					new SqlParameter("FEE_ACTIVE_FOR_ENTRY",WhereFee_active_for_entry),
					new SqlParameter("FEE_DESC",WhereFee_desc),
					new SqlParameter("FEE_CURR_A_FEE_1",WhereFee_curr_a_fee_1),
					new SqlParameter("FEE_CURR_H_FEE_1",WhereFee_curr_h_fee_1),
					new SqlParameter("FEE_CURR_A_FEE_2",WhereFee_curr_a_fee_2),
					new SqlParameter("FEE_CURR_H_FEE_2",WhereFee_curr_h_fee_2),
					new SqlParameter("FEE_CURR_A_MIN",WhereFee_curr_a_min),
					new SqlParameter("FEE_CURR_H_MIN",WhereFee_curr_h_min),
					new SqlParameter("FEE_CURR_A_MAX",WhereFee_curr_a_max),
					new SqlParameter("FEE_CURR_H_MAX",WhereFee_curr_h_max),
					new SqlParameter("FEE_CURR_A_ANAE",WhereFee_curr_a_anae),
					new SqlParameter("FEE_CURR_H_ANAE",WhereFee_curr_h_anae),
					new SqlParameter("FEE_CURR_A_ASST",WhereFee_curr_a_asst),
					new SqlParameter("FEE_CURR_H_ASST",WhereFee_curr_h_asst),
					new SqlParameter("FEE_CURR_ADD_ON_CD1",WhereFee_curr_add_on_cd1),
					new SqlParameter("FEE_CURR_ADD_ON_CD2",WhereFee_curr_add_on_cd2),
					new SqlParameter("FEE_CURR_ADD_ON_CD3",WhereFee_curr_add_on_cd3),
					new SqlParameter("FEE_CURR_ADD_ON_CD4",WhereFee_curr_add_on_cd4),
					new SqlParameter("FEE_CURR_ADD_ON_CD5",WhereFee_curr_add_on_cd5),
					new SqlParameter("FEE_CURR_ADD_ON_CD6",WhereFee_curr_add_on_cd6),
					new SqlParameter("FEE_CURR_ADD_ON_CD7",WhereFee_curr_add_on_cd7),
					new SqlParameter("FEE_CURR_ADD_ON_CD8",WhereFee_curr_add_on_cd8),
					new SqlParameter("FEE_CURR_ADD_ON_CD9",WhereFee_curr_add_on_cd9),
					new SqlParameter("FEE_CURR_ADD_ON_CD10",WhereFee_curr_add_on_cd10),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED1",WhereFee_curr_oma_ind_card_required1),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED2",WhereFee_curr_oma_ind_card_required2),
					new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED3",WhereFee_curr_oma_ind_card_required3),
					new SqlParameter("FEE_CURR_PAGE_ALPHA",WhereFee_curr_page_alpha),
					new SqlParameter("FEE_CURR_PAGE_NUMERIC",WhereFee_curr_page_numeric),
					new SqlParameter("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND",WhereFee_curr_add_on_perc_or_flat_ind),
					new SqlParameter("FEE_PREV_A_FEE_1",WhereFee_prev_a_fee_1),
					new SqlParameter("FEE_PREV_H_FEE_1",WhereFee_prev_h_fee_1),
					new SqlParameter("FEE_PREV_A_FEE_2",WhereFee_prev_a_fee_2),
					new SqlParameter("FEE_PREV_H_FEE_2",WhereFee_prev_h_fee_2),
					new SqlParameter("FEE_PREV_A_MIN",WhereFee_prev_a_min),
					new SqlParameter("FEE_PREV_H_MIN",WhereFee_prev_h_min),
					new SqlParameter("FEE_PREV_A_MAX",WhereFee_prev_a_max),
					new SqlParameter("FEE_PREV_H_MAX",WhereFee_prev_h_max),
					new SqlParameter("FEE_PREV_A_ANAE",WhereFee_prev_a_anae),
					new SqlParameter("FEE_PREV_H_ANAE",WhereFee_prev_h_anae),
					new SqlParameter("FEE_PREV_A_ASST",WhereFee_prev_a_asst),
					new SqlParameter("FEE_PREV_H_ASST",WhereFee_prev_h_asst),
					new SqlParameter("FEE_PREV_ADD_ON_CD1",WhereFee_prev_add_on_cd1),
					new SqlParameter("FEE_PREV_ADD_ON_CD2",WhereFee_prev_add_on_cd2),
					new SqlParameter("FEE_PREV_ADD_ON_CD3",WhereFee_prev_add_on_cd3),
					new SqlParameter("FEE_PREV_ADD_ON_CD4",WhereFee_prev_add_on_cd4),
					new SqlParameter("FEE_PREV_ADD_ON_CD5",WhereFee_prev_add_on_cd5),
					new SqlParameter("FEE_PREV_ADD_ON_CD6",WhereFee_prev_add_on_cd6),
					new SqlParameter("FEE_PREV_ADD_ON_CD7",WhereFee_prev_add_on_cd7),
					new SqlParameter("FEE_PREV_ADD_ON_CD8",WhereFee_prev_add_on_cd8),
					new SqlParameter("FEE_PREV_ADD_ON_CD9",WhereFee_prev_add_on_cd9),
					new SqlParameter("FEE_PREV_ADD_ON_CD10",WhereFee_prev_add_on_cd10),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED1",WhereFee_prev_oma_ind_card_required1),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED2",WhereFee_prev_oma_ind_card_required2),
					new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED3",WhereFee_prev_oma_ind_card_required3),
					new SqlParameter("FEE_PREV_PAGE_ALPHA",WhereFee_prev_page_alpha),
					new SqlParameter("FEE_PREV_PAGE_NUMERIC",WhereFee_prev_page_numeric),
					new SqlParameter("FEE_PREV_ADD_ON_PERC_OR_FLAT_IND",WhereFee_prev_add_on_perc_or_flat_ind),
					new SqlParameter("FEE_ICC_SEC",WhereFee_icc_sec),
					new SqlParameter("FEE_ICC_CAT",WhereFee_icc_cat),
					new SqlParameter("FEE_ICC_GRP",WhereFee_icc_grp),
					new SqlParameter("FEE_ICC_REDUC_IND",WhereFee_icc_reduc_ind),
					new SqlParameter("FEE_DIAG_IND",WhereFee_diag_ind),
					new SqlParameter("FEE_PHY_IND",WhereFee_phy_ind),
					new SqlParameter("FEE_TECH_IND",WhereFee_tech_ind),
					new SqlParameter("FEE_HOSP_NBR_IND",WhereFee_hosp_nbr_ind),
					new SqlParameter("FEE_I_O_IND",WhereFee_i_o_ind),
					new SqlParameter("FEE_ADMIT_IND",WhereFee_admit_ind),
					new SqlParameter("FEE_SPEC_FR",WhereFee_spec_fr),
					new SqlParameter("FEE_SPEC_TO",WhereFee_spec_to),
					new SqlParameter("FEEGLOBALADDONCDEXCLUSIONFLAG",WhereFeeglobaladdoncdexclusionflag),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F040_OMA_FEE_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F040_OMA_FEE_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F040_OMA_FEE_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					FEE_OMA_CD_LTR1 = Reader["FEE_OMA_CD_LTR1"].ToString(),
					FILLER_NUMERIC = Reader["FILLER_NUMERIC"].ToString(),
					FEE_SPECIAL_M_SUFFIX_IND = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString(),
					FEE_DATE_YY = ConvertDEC(Reader["FEE_DATE_YY"]),
					FEE_DATE_MM = ConvertDEC(Reader["FEE_DATE_MM"]),
					FEE_DATE_DD = ConvertDEC(Reader["FEE_DATE_DD"]),
					FEE_ACTIVE_FOR_ENTRY = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString(),
					FEE_DESC = Reader["FEE_DESC"].ToString(),
					FEE_CURR_A_FEE_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]),
					FEE_CURR_H_FEE_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]),
					FEE_CURR_A_FEE_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]),
					FEE_CURR_H_FEE_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]),
					FEE_CURR_A_MIN = ConvertDEC(Reader["FEE_CURR_A_MIN"]),
					FEE_CURR_H_MIN = ConvertDEC(Reader["FEE_CURR_H_MIN"]),
					FEE_CURR_A_MAX = ConvertDEC(Reader["FEE_CURR_A_MAX"]),
					FEE_CURR_H_MAX = ConvertDEC(Reader["FEE_CURR_H_MAX"]),
					FEE_CURR_A_ANAE = ConvertDEC(Reader["FEE_CURR_A_ANAE"]),
					FEE_CURR_H_ANAE = ConvertDEC(Reader["FEE_CURR_H_ANAE"]),
					FEE_CURR_A_ASST = ConvertDEC(Reader["FEE_CURR_A_ASST"]),
					FEE_CURR_H_ASST = ConvertDEC(Reader["FEE_CURR_H_ASST"]),
					FEE_CURR_ADD_ON_CD1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString(),
					FEE_CURR_ADD_ON_CD2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString(),
					FEE_CURR_ADD_ON_CD3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString(),
					FEE_CURR_ADD_ON_CD4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString(),
					FEE_CURR_ADD_ON_CD5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString(),
					FEE_CURR_ADD_ON_CD6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString(),
					FEE_CURR_ADD_ON_CD7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString(),
					FEE_CURR_ADD_ON_CD8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString(),
					FEE_CURR_ADD_ON_CD9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString(),
					FEE_CURR_ADD_ON_CD10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString(),
					FEE_CURR_OMA_IND_CARD_REQUIRED3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString(),
					FEE_CURR_PAGE_ALPHA = Reader["FEE_CURR_PAGE_ALPHA"].ToString(),
					FEE_CURR_PAGE_NUMERIC = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]),
					FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					FEE_PREV_A_FEE_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]),
					FEE_PREV_H_FEE_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]),
					FEE_PREV_A_FEE_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]),
					FEE_PREV_H_FEE_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]),
					FEE_PREV_A_MIN = ConvertDEC(Reader["FEE_PREV_A_MIN"]),
					FEE_PREV_H_MIN = ConvertDEC(Reader["FEE_PREV_H_MIN"]),
					FEE_PREV_A_MAX = ConvertDEC(Reader["FEE_PREV_A_MAX"]),
					FEE_PREV_H_MAX = ConvertDEC(Reader["FEE_PREV_H_MAX"]),
					FEE_PREV_A_ANAE = ConvertDEC(Reader["FEE_PREV_A_ANAE"]),
					FEE_PREV_H_ANAE = ConvertDEC(Reader["FEE_PREV_H_ANAE"]),
					FEE_PREV_A_ASST = ConvertDEC(Reader["FEE_PREV_A_ASST"]),
					FEE_PREV_H_ASST = ConvertDEC(Reader["FEE_PREV_H_ASST"]),
					FEE_PREV_ADD_ON_CD1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString(),
					FEE_PREV_ADD_ON_CD2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString(),
					FEE_PREV_ADD_ON_CD3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString(),
					FEE_PREV_ADD_ON_CD4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString(),
					FEE_PREV_ADD_ON_CD5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString(),
					FEE_PREV_ADD_ON_CD6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString(),
					FEE_PREV_ADD_ON_CD7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString(),
					FEE_PREV_ADD_ON_CD8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString(),
					FEE_PREV_ADD_ON_CD9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString(),
					FEE_PREV_ADD_ON_CD10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString(),
					FEE_PREV_OMA_IND_CARD_REQUIRED3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString(),
					FEE_PREV_PAGE_ALPHA = Reader["FEE_PREV_PAGE_ALPHA"].ToString(),
					FEE_PREV_PAGE_NUMERIC = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]),
					FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					FEE_ICC_SEC = Reader["FEE_ICC_SEC"].ToString(),
					FEE_ICC_CAT = ConvertDEC(Reader["FEE_ICC_CAT"]),
					FEE_ICC_GRP = ConvertDEC(Reader["FEE_ICC_GRP"]),
					FEE_ICC_REDUC_IND = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]),
					FEE_DIAG_IND = Reader["FEE_DIAG_IND"].ToString(),
					FEE_PHY_IND = Reader["FEE_PHY_IND"].ToString(),
					FEE_TECH_IND = Reader["FEE_TECH_IND"].ToString(),
					FEE_HOSP_NBR_IND = Reader["FEE_HOSP_NBR_IND"].ToString(),
					FEE_I_O_IND = Reader["FEE_I_O_IND"].ToString(),
					FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString(),
					FEE_SPEC_FR = ConvertDEC(Reader["FEE_SPEC_FR"]),
					FEE_SPEC_TO = ConvertDEC(Reader["FEE_SPEC_TO"]),
					FEEGLOBALADDONCDEXCLUSIONFLAG = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereFee_oma_cd_ltr1 = WhereFee_oma_cd_ltr1,
					_whereFiller_numeric = WhereFiller_numeric,
					_whereFee_special_m_suffix_ind = WhereFee_special_m_suffix_ind,
					_whereFee_date_yy = WhereFee_date_yy,
					_whereFee_date_mm = WhereFee_date_mm,
					_whereFee_date_dd = WhereFee_date_dd,
					_whereFee_active_for_entry = WhereFee_active_for_entry,
					_whereFee_desc = WhereFee_desc,
					_whereFee_curr_a_fee_1 = WhereFee_curr_a_fee_1,
					_whereFee_curr_h_fee_1 = WhereFee_curr_h_fee_1,
					_whereFee_curr_a_fee_2 = WhereFee_curr_a_fee_2,
					_whereFee_curr_h_fee_2 = WhereFee_curr_h_fee_2,
					_whereFee_curr_a_min = WhereFee_curr_a_min,
					_whereFee_curr_h_min = WhereFee_curr_h_min,
					_whereFee_curr_a_max = WhereFee_curr_a_max,
					_whereFee_curr_h_max = WhereFee_curr_h_max,
					_whereFee_curr_a_anae = WhereFee_curr_a_anae,
					_whereFee_curr_h_anae = WhereFee_curr_h_anae,
					_whereFee_curr_a_asst = WhereFee_curr_a_asst,
					_whereFee_curr_h_asst = WhereFee_curr_h_asst,
					_whereFee_curr_add_on_cd1 = WhereFee_curr_add_on_cd1,
					_whereFee_curr_add_on_cd2 = WhereFee_curr_add_on_cd2,
					_whereFee_curr_add_on_cd3 = WhereFee_curr_add_on_cd3,
					_whereFee_curr_add_on_cd4 = WhereFee_curr_add_on_cd4,
					_whereFee_curr_add_on_cd5 = WhereFee_curr_add_on_cd5,
					_whereFee_curr_add_on_cd6 = WhereFee_curr_add_on_cd6,
					_whereFee_curr_add_on_cd7 = WhereFee_curr_add_on_cd7,
					_whereFee_curr_add_on_cd8 = WhereFee_curr_add_on_cd8,
					_whereFee_curr_add_on_cd9 = WhereFee_curr_add_on_cd9,
					_whereFee_curr_add_on_cd10 = WhereFee_curr_add_on_cd10,
					_whereFee_curr_oma_ind_card_required1 = WhereFee_curr_oma_ind_card_required1,
					_whereFee_curr_oma_ind_card_required2 = WhereFee_curr_oma_ind_card_required2,
					_whereFee_curr_oma_ind_card_required3 = WhereFee_curr_oma_ind_card_required3,
					_whereFee_curr_page_alpha = WhereFee_curr_page_alpha,
					_whereFee_curr_page_numeric = WhereFee_curr_page_numeric,
					_whereFee_curr_add_on_perc_or_flat_ind = WhereFee_curr_add_on_perc_or_flat_ind,
					_whereFee_prev_a_fee_1 = WhereFee_prev_a_fee_1,
					_whereFee_prev_h_fee_1 = WhereFee_prev_h_fee_1,
					_whereFee_prev_a_fee_2 = WhereFee_prev_a_fee_2,
					_whereFee_prev_h_fee_2 = WhereFee_prev_h_fee_2,
					_whereFee_prev_a_min = WhereFee_prev_a_min,
					_whereFee_prev_h_min = WhereFee_prev_h_min,
					_whereFee_prev_a_max = WhereFee_prev_a_max,
					_whereFee_prev_h_max = WhereFee_prev_h_max,
					_whereFee_prev_a_anae = WhereFee_prev_a_anae,
					_whereFee_prev_h_anae = WhereFee_prev_h_anae,
					_whereFee_prev_a_asst = WhereFee_prev_a_asst,
					_whereFee_prev_h_asst = WhereFee_prev_h_asst,
					_whereFee_prev_add_on_cd1 = WhereFee_prev_add_on_cd1,
					_whereFee_prev_add_on_cd2 = WhereFee_prev_add_on_cd2,
					_whereFee_prev_add_on_cd3 = WhereFee_prev_add_on_cd3,
					_whereFee_prev_add_on_cd4 = WhereFee_prev_add_on_cd4,
					_whereFee_prev_add_on_cd5 = WhereFee_prev_add_on_cd5,
					_whereFee_prev_add_on_cd6 = WhereFee_prev_add_on_cd6,
					_whereFee_prev_add_on_cd7 = WhereFee_prev_add_on_cd7,
					_whereFee_prev_add_on_cd8 = WhereFee_prev_add_on_cd8,
					_whereFee_prev_add_on_cd9 = WhereFee_prev_add_on_cd9,
					_whereFee_prev_add_on_cd10 = WhereFee_prev_add_on_cd10,
					_whereFee_prev_oma_ind_card_required1 = WhereFee_prev_oma_ind_card_required1,
					_whereFee_prev_oma_ind_card_required2 = WhereFee_prev_oma_ind_card_required2,
					_whereFee_prev_oma_ind_card_required3 = WhereFee_prev_oma_ind_card_required3,
					_whereFee_prev_page_alpha = WhereFee_prev_page_alpha,
					_whereFee_prev_page_numeric = WhereFee_prev_page_numeric,
					_whereFee_prev_add_on_perc_or_flat_ind = WhereFee_prev_add_on_perc_or_flat_ind,
					_whereFee_icc_sec = WhereFee_icc_sec,
					_whereFee_icc_cat = WhereFee_icc_cat,
					_whereFee_icc_grp = WhereFee_icc_grp,
					_whereFee_icc_reduc_ind = WhereFee_icc_reduc_ind,
					_whereFee_diag_ind = WhereFee_diag_ind,
					_whereFee_phy_ind = WhereFee_phy_ind,
					_whereFee_tech_ind = WhereFee_tech_ind,
					_whereFee_hosp_nbr_ind = WhereFee_hosp_nbr_ind,
					_whereFee_i_o_ind = WhereFee_i_o_ind,
					_whereFee_admit_ind = WhereFee_admit_ind,
					_whereFee_spec_fr = WhereFee_spec_fr,
					_whereFee_spec_to = WhereFee_spec_to,
					_whereFeeglobaladdoncdexclusionflag = WhereFeeglobaladdoncdexclusionflag,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalFee_oma_cd_ltr1 = Reader["FEE_OMA_CD_LTR1"].ToString(),
					_originalFiller_numeric = Reader["FILLER_NUMERIC"].ToString(),
					_originalFee_special_m_suffix_ind = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString(),
					_originalFee_date_yy = ConvertDEC(Reader["FEE_DATE_YY"]),
					_originalFee_date_mm = ConvertDEC(Reader["FEE_DATE_MM"]),
					_originalFee_date_dd = ConvertDEC(Reader["FEE_DATE_DD"]),
					_originalFee_active_for_entry = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString(),
					_originalFee_desc = Reader["FEE_DESC"].ToString(),
					_originalFee_curr_a_fee_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]),
					_originalFee_curr_h_fee_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]),
					_originalFee_curr_a_fee_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]),
					_originalFee_curr_h_fee_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]),
					_originalFee_curr_a_min = ConvertDEC(Reader["FEE_CURR_A_MIN"]),
					_originalFee_curr_h_min = ConvertDEC(Reader["FEE_CURR_H_MIN"]),
					_originalFee_curr_a_max = ConvertDEC(Reader["FEE_CURR_A_MAX"]),
					_originalFee_curr_h_max = ConvertDEC(Reader["FEE_CURR_H_MAX"]),
					_originalFee_curr_a_anae = ConvertDEC(Reader["FEE_CURR_A_ANAE"]),
					_originalFee_curr_h_anae = ConvertDEC(Reader["FEE_CURR_H_ANAE"]),
					_originalFee_curr_a_asst = ConvertDEC(Reader["FEE_CURR_A_ASST"]),
					_originalFee_curr_h_asst = ConvertDEC(Reader["FEE_CURR_H_ASST"]),
					_originalFee_curr_add_on_cd1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString(),
					_originalFee_curr_add_on_cd2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString(),
					_originalFee_curr_add_on_cd3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString(),
					_originalFee_curr_add_on_cd4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString(),
					_originalFee_curr_add_on_cd5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString(),
					_originalFee_curr_add_on_cd6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString(),
					_originalFee_curr_add_on_cd7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString(),
					_originalFee_curr_add_on_cd8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString(),
					_originalFee_curr_add_on_cd9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString(),
					_originalFee_curr_add_on_cd10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString(),
					_originalFee_curr_oma_ind_card_required1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString(),
					_originalFee_curr_oma_ind_card_required2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString(),
					_originalFee_curr_oma_ind_card_required3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString(),
					_originalFee_curr_page_alpha = Reader["FEE_CURR_PAGE_ALPHA"].ToString(),
					_originalFee_curr_page_numeric = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]),
					_originalFee_curr_add_on_perc_or_flat_ind = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					_originalFee_prev_a_fee_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]),
					_originalFee_prev_h_fee_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]),
					_originalFee_prev_a_fee_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]),
					_originalFee_prev_h_fee_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]),
					_originalFee_prev_a_min = ConvertDEC(Reader["FEE_PREV_A_MIN"]),
					_originalFee_prev_h_min = ConvertDEC(Reader["FEE_PREV_H_MIN"]),
					_originalFee_prev_a_max = ConvertDEC(Reader["FEE_PREV_A_MAX"]),
					_originalFee_prev_h_max = ConvertDEC(Reader["FEE_PREV_H_MAX"]),
					_originalFee_prev_a_anae = ConvertDEC(Reader["FEE_PREV_A_ANAE"]),
					_originalFee_prev_h_anae = ConvertDEC(Reader["FEE_PREV_H_ANAE"]),
					_originalFee_prev_a_asst = ConvertDEC(Reader["FEE_PREV_A_ASST"]),
					_originalFee_prev_h_asst = ConvertDEC(Reader["FEE_PREV_H_ASST"]),
					_originalFee_prev_add_on_cd1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString(),
					_originalFee_prev_add_on_cd2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString(),
					_originalFee_prev_add_on_cd3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString(),
					_originalFee_prev_add_on_cd4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString(),
					_originalFee_prev_add_on_cd5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString(),
					_originalFee_prev_add_on_cd6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString(),
					_originalFee_prev_add_on_cd7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString(),
					_originalFee_prev_add_on_cd8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString(),
					_originalFee_prev_add_on_cd9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString(),
					_originalFee_prev_add_on_cd10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString(),
					_originalFee_prev_oma_ind_card_required1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString(),
					_originalFee_prev_oma_ind_card_required2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString(),
					_originalFee_prev_oma_ind_card_required3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString(),
					_originalFee_prev_page_alpha = Reader["FEE_PREV_PAGE_ALPHA"].ToString(),
					_originalFee_prev_page_numeric = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]),
					_originalFee_prev_add_on_perc_or_flat_ind = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString(),
					_originalFee_icc_sec = Reader["FEE_ICC_SEC"].ToString(),
					_originalFee_icc_cat = ConvertDEC(Reader["FEE_ICC_CAT"]),
					_originalFee_icc_grp = ConvertDEC(Reader["FEE_ICC_GRP"]),
					_originalFee_icc_reduc_ind = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]),
					_originalFee_diag_ind = Reader["FEE_DIAG_IND"].ToString(),
					_originalFee_phy_ind = Reader["FEE_PHY_IND"].ToString(),
					_originalFee_tech_ind = Reader["FEE_TECH_IND"].ToString(),
					_originalFee_hosp_nbr_ind = Reader["FEE_HOSP_NBR_IND"].ToString(),
					_originalFee_i_o_ind = Reader["FEE_I_O_IND"].ToString(),
					_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString(),
					_originalFee_spec_fr = ConvertDEC(Reader["FEE_SPEC_FR"]),
					_originalFee_spec_to = ConvertDEC(Reader["FEE_SPEC_TO"]),
					_originalFeeglobaladdoncdexclusionflag = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereFee_oma_cd_ltr1 = WhereFee_oma_cd_ltr1;
					_whereFiller_numeric = WhereFiller_numeric;
					_whereFee_special_m_suffix_ind = WhereFee_special_m_suffix_ind;
					_whereFee_date_yy = WhereFee_date_yy;
					_whereFee_date_mm = WhereFee_date_mm;
					_whereFee_date_dd = WhereFee_date_dd;
					_whereFee_active_for_entry = WhereFee_active_for_entry;
					_whereFee_desc = WhereFee_desc;
					_whereFee_curr_a_fee_1 = WhereFee_curr_a_fee_1;
					_whereFee_curr_h_fee_1 = WhereFee_curr_h_fee_1;
					_whereFee_curr_a_fee_2 = WhereFee_curr_a_fee_2;
					_whereFee_curr_h_fee_2 = WhereFee_curr_h_fee_2;
					_whereFee_curr_a_min = WhereFee_curr_a_min;
					_whereFee_curr_h_min = WhereFee_curr_h_min;
					_whereFee_curr_a_max = WhereFee_curr_a_max;
					_whereFee_curr_h_max = WhereFee_curr_h_max;
					_whereFee_curr_a_anae = WhereFee_curr_a_anae;
					_whereFee_curr_h_anae = WhereFee_curr_h_anae;
					_whereFee_curr_a_asst = WhereFee_curr_a_asst;
					_whereFee_curr_h_asst = WhereFee_curr_h_asst;
					_whereFee_curr_add_on_cd1 = WhereFee_curr_add_on_cd1;
					_whereFee_curr_add_on_cd2 = WhereFee_curr_add_on_cd2;
					_whereFee_curr_add_on_cd3 = WhereFee_curr_add_on_cd3;
					_whereFee_curr_add_on_cd4 = WhereFee_curr_add_on_cd4;
					_whereFee_curr_add_on_cd5 = WhereFee_curr_add_on_cd5;
					_whereFee_curr_add_on_cd6 = WhereFee_curr_add_on_cd6;
					_whereFee_curr_add_on_cd7 = WhereFee_curr_add_on_cd7;
					_whereFee_curr_add_on_cd8 = WhereFee_curr_add_on_cd8;
					_whereFee_curr_add_on_cd9 = WhereFee_curr_add_on_cd9;
					_whereFee_curr_add_on_cd10 = WhereFee_curr_add_on_cd10;
					_whereFee_curr_oma_ind_card_required1 = WhereFee_curr_oma_ind_card_required1;
					_whereFee_curr_oma_ind_card_required2 = WhereFee_curr_oma_ind_card_required2;
					_whereFee_curr_oma_ind_card_required3 = WhereFee_curr_oma_ind_card_required3;
					_whereFee_curr_page_alpha = WhereFee_curr_page_alpha;
					_whereFee_curr_page_numeric = WhereFee_curr_page_numeric;
					_whereFee_curr_add_on_perc_or_flat_ind = WhereFee_curr_add_on_perc_or_flat_ind;
					_whereFee_prev_a_fee_1 = WhereFee_prev_a_fee_1;
					_whereFee_prev_h_fee_1 = WhereFee_prev_h_fee_1;
					_whereFee_prev_a_fee_2 = WhereFee_prev_a_fee_2;
					_whereFee_prev_h_fee_2 = WhereFee_prev_h_fee_2;
					_whereFee_prev_a_min = WhereFee_prev_a_min;
					_whereFee_prev_h_min = WhereFee_prev_h_min;
					_whereFee_prev_a_max = WhereFee_prev_a_max;
					_whereFee_prev_h_max = WhereFee_prev_h_max;
					_whereFee_prev_a_anae = WhereFee_prev_a_anae;
					_whereFee_prev_h_anae = WhereFee_prev_h_anae;
					_whereFee_prev_a_asst = WhereFee_prev_a_asst;
					_whereFee_prev_h_asst = WhereFee_prev_h_asst;
					_whereFee_prev_add_on_cd1 = WhereFee_prev_add_on_cd1;
					_whereFee_prev_add_on_cd2 = WhereFee_prev_add_on_cd2;
					_whereFee_prev_add_on_cd3 = WhereFee_prev_add_on_cd3;
					_whereFee_prev_add_on_cd4 = WhereFee_prev_add_on_cd4;
					_whereFee_prev_add_on_cd5 = WhereFee_prev_add_on_cd5;
					_whereFee_prev_add_on_cd6 = WhereFee_prev_add_on_cd6;
					_whereFee_prev_add_on_cd7 = WhereFee_prev_add_on_cd7;
					_whereFee_prev_add_on_cd8 = WhereFee_prev_add_on_cd8;
					_whereFee_prev_add_on_cd9 = WhereFee_prev_add_on_cd9;
					_whereFee_prev_add_on_cd10 = WhereFee_prev_add_on_cd10;
					_whereFee_prev_oma_ind_card_required1 = WhereFee_prev_oma_ind_card_required1;
					_whereFee_prev_oma_ind_card_required2 = WhereFee_prev_oma_ind_card_required2;
					_whereFee_prev_oma_ind_card_required3 = WhereFee_prev_oma_ind_card_required3;
					_whereFee_prev_page_alpha = WhereFee_prev_page_alpha;
					_whereFee_prev_page_numeric = WhereFee_prev_page_numeric;
					_whereFee_prev_add_on_perc_or_flat_ind = WhereFee_prev_add_on_perc_or_flat_ind;
					_whereFee_icc_sec = WhereFee_icc_sec;
					_whereFee_icc_cat = WhereFee_icc_cat;
					_whereFee_icc_grp = WhereFee_icc_grp;
					_whereFee_icc_reduc_ind = WhereFee_icc_reduc_ind;
					_whereFee_diag_ind = WhereFee_diag_ind;
					_whereFee_phy_ind = WhereFee_phy_ind;
					_whereFee_tech_ind = WhereFee_tech_ind;
					_whereFee_hosp_nbr_ind = WhereFee_hosp_nbr_ind;
					_whereFee_i_o_ind = WhereFee_i_o_ind;
					_whereFee_admit_ind = WhereFee_admit_ind;
					_whereFee_spec_fr = WhereFee_spec_fr;
					_whereFee_spec_to = WhereFee_spec_to;
					_whereFeeglobaladdoncdexclusionflag = WhereFeeglobaladdoncdexclusionflag;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereFee_oma_cd_ltr1 == null 
				&& WhereFiller_numeric == null 
				&& WhereFee_special_m_suffix_ind == null 
				&& WhereFee_date_yy == null 
				&& WhereFee_date_mm == null 
				&& WhereFee_date_dd == null 
				&& WhereFee_active_for_entry == null 
				&& WhereFee_desc == null 
				&& WhereFee_curr_a_fee_1 == null 
				&& WhereFee_curr_h_fee_1 == null 
				&& WhereFee_curr_a_fee_2 == null 
				&& WhereFee_curr_h_fee_2 == null 
				&& WhereFee_curr_a_min == null 
				&& WhereFee_curr_h_min == null 
				&& WhereFee_curr_a_max == null 
				&& WhereFee_curr_h_max == null 
				&& WhereFee_curr_a_anae == null 
				&& WhereFee_curr_h_anae == null 
				&& WhereFee_curr_a_asst == null 
				&& WhereFee_curr_h_asst == null 
				&& WhereFee_curr_add_on_cd1 == null 
				&& WhereFee_curr_add_on_cd2 == null 
				&& WhereFee_curr_add_on_cd3 == null 
				&& WhereFee_curr_add_on_cd4 == null 
				&& WhereFee_curr_add_on_cd5 == null 
				&& WhereFee_curr_add_on_cd6 == null 
				&& WhereFee_curr_add_on_cd7 == null 
				&& WhereFee_curr_add_on_cd8 == null 
				&& WhereFee_curr_add_on_cd9 == null 
				&& WhereFee_curr_add_on_cd10 == null 
				&& WhereFee_curr_oma_ind_card_required1 == null 
				&& WhereFee_curr_oma_ind_card_required2 == null 
				&& WhereFee_curr_oma_ind_card_required3 == null 
				&& WhereFee_curr_page_alpha == null 
				&& WhereFee_curr_page_numeric == null 
				&& WhereFee_curr_add_on_perc_or_flat_ind == null 
				&& WhereFee_prev_a_fee_1 == null 
				&& WhereFee_prev_h_fee_1 == null 
				&& WhereFee_prev_a_fee_2 == null 
				&& WhereFee_prev_h_fee_2 == null 
				&& WhereFee_prev_a_min == null 
				&& WhereFee_prev_h_min == null 
				&& WhereFee_prev_a_max == null 
				&& WhereFee_prev_h_max == null 
				&& WhereFee_prev_a_anae == null 
				&& WhereFee_prev_h_anae == null 
				&& WhereFee_prev_a_asst == null 
				&& WhereFee_prev_h_asst == null 
				&& WhereFee_prev_add_on_cd1 == null 
				&& WhereFee_prev_add_on_cd2 == null 
				&& WhereFee_prev_add_on_cd3 == null 
				&& WhereFee_prev_add_on_cd4 == null 
				&& WhereFee_prev_add_on_cd5 == null 
				&& WhereFee_prev_add_on_cd6 == null 
				&& WhereFee_prev_add_on_cd7 == null 
				&& WhereFee_prev_add_on_cd8 == null 
				&& WhereFee_prev_add_on_cd9 == null 
				&& WhereFee_prev_add_on_cd10 == null 
				&& WhereFee_prev_oma_ind_card_required1 == null 
				&& WhereFee_prev_oma_ind_card_required2 == null 
				&& WhereFee_prev_oma_ind_card_required3 == null 
				&& WhereFee_prev_page_alpha == null 
				&& WhereFee_prev_page_numeric == null 
				&& WhereFee_prev_add_on_perc_or_flat_ind == null 
				&& WhereFee_icc_sec == null 
				&& WhereFee_icc_cat == null 
				&& WhereFee_icc_grp == null 
				&& WhereFee_icc_reduc_ind == null 
				&& WhereFee_diag_ind == null 
				&& WhereFee_phy_ind == null 
				&& WhereFee_tech_ind == null 
				&& WhereFee_hosp_nbr_ind == null 
				&& WhereFee_i_o_ind == null 
				&& WhereFee_admit_ind == null 
				&& WhereFee_spec_fr == null 
				&& WhereFee_spec_to == null 
				&& WhereFeeglobaladdoncdexclusionflag == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereFee_oma_cd_ltr1 ==  _whereFee_oma_cd_ltr1
				&& WhereFiller_numeric ==  _whereFiller_numeric
				&& WhereFee_special_m_suffix_ind ==  _whereFee_special_m_suffix_ind
				&& WhereFee_date_yy ==  _whereFee_date_yy
				&& WhereFee_date_mm ==  _whereFee_date_mm
				&& WhereFee_date_dd ==  _whereFee_date_dd
				&& WhereFee_active_for_entry ==  _whereFee_active_for_entry
				&& WhereFee_desc ==  _whereFee_desc
				&& WhereFee_curr_a_fee_1 ==  _whereFee_curr_a_fee_1
				&& WhereFee_curr_h_fee_1 ==  _whereFee_curr_h_fee_1
				&& WhereFee_curr_a_fee_2 ==  _whereFee_curr_a_fee_2
				&& WhereFee_curr_h_fee_2 ==  _whereFee_curr_h_fee_2
				&& WhereFee_curr_a_min ==  _whereFee_curr_a_min
				&& WhereFee_curr_h_min ==  _whereFee_curr_h_min
				&& WhereFee_curr_a_max ==  _whereFee_curr_a_max
				&& WhereFee_curr_h_max ==  _whereFee_curr_h_max
				&& WhereFee_curr_a_anae ==  _whereFee_curr_a_anae
				&& WhereFee_curr_h_anae ==  _whereFee_curr_h_anae
				&& WhereFee_curr_a_asst ==  _whereFee_curr_a_asst
				&& WhereFee_curr_h_asst ==  _whereFee_curr_h_asst
				&& WhereFee_curr_add_on_cd1 ==  _whereFee_curr_add_on_cd1
				&& WhereFee_curr_add_on_cd2 ==  _whereFee_curr_add_on_cd2
				&& WhereFee_curr_add_on_cd3 ==  _whereFee_curr_add_on_cd3
				&& WhereFee_curr_add_on_cd4 ==  _whereFee_curr_add_on_cd4
				&& WhereFee_curr_add_on_cd5 ==  _whereFee_curr_add_on_cd5
				&& WhereFee_curr_add_on_cd6 ==  _whereFee_curr_add_on_cd6
				&& WhereFee_curr_add_on_cd7 ==  _whereFee_curr_add_on_cd7
				&& WhereFee_curr_add_on_cd8 ==  _whereFee_curr_add_on_cd8
				&& WhereFee_curr_add_on_cd9 ==  _whereFee_curr_add_on_cd9
				&& WhereFee_curr_add_on_cd10 ==  _whereFee_curr_add_on_cd10
				&& WhereFee_curr_oma_ind_card_required1 ==  _whereFee_curr_oma_ind_card_required1
				&& WhereFee_curr_oma_ind_card_required2 ==  _whereFee_curr_oma_ind_card_required2
				&& WhereFee_curr_oma_ind_card_required3 ==  _whereFee_curr_oma_ind_card_required3
				&& WhereFee_curr_page_alpha ==  _whereFee_curr_page_alpha
				&& WhereFee_curr_page_numeric ==  _whereFee_curr_page_numeric
				&& WhereFee_curr_add_on_perc_or_flat_ind ==  _whereFee_curr_add_on_perc_or_flat_ind
				&& WhereFee_prev_a_fee_1 ==  _whereFee_prev_a_fee_1
				&& WhereFee_prev_h_fee_1 ==  _whereFee_prev_h_fee_1
				&& WhereFee_prev_a_fee_2 ==  _whereFee_prev_a_fee_2
				&& WhereFee_prev_h_fee_2 ==  _whereFee_prev_h_fee_2
				&& WhereFee_prev_a_min ==  _whereFee_prev_a_min
				&& WhereFee_prev_h_min ==  _whereFee_prev_h_min
				&& WhereFee_prev_a_max ==  _whereFee_prev_a_max
				&& WhereFee_prev_h_max ==  _whereFee_prev_h_max
				&& WhereFee_prev_a_anae ==  _whereFee_prev_a_anae
				&& WhereFee_prev_h_anae ==  _whereFee_prev_h_anae
				&& WhereFee_prev_a_asst ==  _whereFee_prev_a_asst
				&& WhereFee_prev_h_asst ==  _whereFee_prev_h_asst
				&& WhereFee_prev_add_on_cd1 ==  _whereFee_prev_add_on_cd1
				&& WhereFee_prev_add_on_cd2 ==  _whereFee_prev_add_on_cd2
				&& WhereFee_prev_add_on_cd3 ==  _whereFee_prev_add_on_cd3
				&& WhereFee_prev_add_on_cd4 ==  _whereFee_prev_add_on_cd4
				&& WhereFee_prev_add_on_cd5 ==  _whereFee_prev_add_on_cd5
				&& WhereFee_prev_add_on_cd6 ==  _whereFee_prev_add_on_cd6
				&& WhereFee_prev_add_on_cd7 ==  _whereFee_prev_add_on_cd7
				&& WhereFee_prev_add_on_cd8 ==  _whereFee_prev_add_on_cd8
				&& WhereFee_prev_add_on_cd9 ==  _whereFee_prev_add_on_cd9
				&& WhereFee_prev_add_on_cd10 ==  _whereFee_prev_add_on_cd10
				&& WhereFee_prev_oma_ind_card_required1 ==  _whereFee_prev_oma_ind_card_required1
				&& WhereFee_prev_oma_ind_card_required2 ==  _whereFee_prev_oma_ind_card_required2
				&& WhereFee_prev_oma_ind_card_required3 ==  _whereFee_prev_oma_ind_card_required3
				&& WhereFee_prev_page_alpha ==  _whereFee_prev_page_alpha
				&& WhereFee_prev_page_numeric ==  _whereFee_prev_page_numeric
				&& WhereFee_prev_add_on_perc_or_flat_ind ==  _whereFee_prev_add_on_perc_or_flat_ind
				&& WhereFee_icc_sec ==  _whereFee_icc_sec
				&& WhereFee_icc_cat ==  _whereFee_icc_cat
				&& WhereFee_icc_grp ==  _whereFee_icc_grp
				&& WhereFee_icc_reduc_ind ==  _whereFee_icc_reduc_ind
				&& WhereFee_diag_ind ==  _whereFee_diag_ind
				&& WhereFee_phy_ind ==  _whereFee_phy_ind
				&& WhereFee_tech_ind ==  _whereFee_tech_ind
				&& WhereFee_hosp_nbr_ind ==  _whereFee_hosp_nbr_ind
				&& WhereFee_i_o_ind ==  _whereFee_i_o_ind
				&& WhereFee_admit_ind ==  _whereFee_admit_ind
				&& WhereFee_spec_fr ==  _whereFee_spec_fr
				&& WhereFee_spec_to ==  _whereFee_spec_to
				&& WhereFeeglobaladdoncdexclusionflag ==  _whereFeeglobaladdoncdexclusionflag
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereFee_oma_cd_ltr1 = null; 
			WhereFiller_numeric = null; 
			WhereFee_special_m_suffix_ind = null; 
			WhereFee_date_yy = null; 
			WhereFee_date_mm = null; 
			WhereFee_date_dd = null; 
			WhereFee_active_for_entry = null; 
			WhereFee_desc = null; 
			WhereFee_curr_a_fee_1 = null; 
			WhereFee_curr_h_fee_1 = null; 
			WhereFee_curr_a_fee_2 = null; 
			WhereFee_curr_h_fee_2 = null; 
			WhereFee_curr_a_min = null; 
			WhereFee_curr_h_min = null; 
			WhereFee_curr_a_max = null; 
			WhereFee_curr_h_max = null; 
			WhereFee_curr_a_anae = null; 
			WhereFee_curr_h_anae = null; 
			WhereFee_curr_a_asst = null; 
			WhereFee_curr_h_asst = null; 
			WhereFee_curr_add_on_cd1 = null; 
			WhereFee_curr_add_on_cd2 = null; 
			WhereFee_curr_add_on_cd3 = null; 
			WhereFee_curr_add_on_cd4 = null; 
			WhereFee_curr_add_on_cd5 = null; 
			WhereFee_curr_add_on_cd6 = null; 
			WhereFee_curr_add_on_cd7 = null; 
			WhereFee_curr_add_on_cd8 = null; 
			WhereFee_curr_add_on_cd9 = null; 
			WhereFee_curr_add_on_cd10 = null; 
			WhereFee_curr_oma_ind_card_required1 = null; 
			WhereFee_curr_oma_ind_card_required2 = null; 
			WhereFee_curr_oma_ind_card_required3 = null; 
			WhereFee_curr_page_alpha = null; 
			WhereFee_curr_page_numeric = null; 
			WhereFee_curr_add_on_perc_or_flat_ind = null; 
			WhereFee_prev_a_fee_1 = null; 
			WhereFee_prev_h_fee_1 = null; 
			WhereFee_prev_a_fee_2 = null; 
			WhereFee_prev_h_fee_2 = null; 
			WhereFee_prev_a_min = null; 
			WhereFee_prev_h_min = null; 
			WhereFee_prev_a_max = null; 
			WhereFee_prev_h_max = null; 
			WhereFee_prev_a_anae = null; 
			WhereFee_prev_h_anae = null; 
			WhereFee_prev_a_asst = null; 
			WhereFee_prev_h_asst = null; 
			WhereFee_prev_add_on_cd1 = null; 
			WhereFee_prev_add_on_cd2 = null; 
			WhereFee_prev_add_on_cd3 = null; 
			WhereFee_prev_add_on_cd4 = null; 
			WhereFee_prev_add_on_cd5 = null; 
			WhereFee_prev_add_on_cd6 = null; 
			WhereFee_prev_add_on_cd7 = null; 
			WhereFee_prev_add_on_cd8 = null; 
			WhereFee_prev_add_on_cd9 = null; 
			WhereFee_prev_add_on_cd10 = null; 
			WhereFee_prev_oma_ind_card_required1 = null; 
			WhereFee_prev_oma_ind_card_required2 = null; 
			WhereFee_prev_oma_ind_card_required3 = null; 
			WhereFee_prev_page_alpha = null; 
			WhereFee_prev_page_numeric = null; 
			WhereFee_prev_add_on_perc_or_flat_ind = null; 
			WhereFee_icc_sec = null; 
			WhereFee_icc_cat = null; 
			WhereFee_icc_grp = null; 
			WhereFee_icc_reduc_ind = null; 
			WhereFee_diag_ind = null; 
			WhereFee_phy_ind = null; 
			WhereFee_tech_ind = null; 
			WhereFee_hosp_nbr_ind = null; 
			WhereFee_i_o_ind = null; 
			WhereFee_admit_ind = null; 
			WhereFee_spec_fr = null; 
			WhereFee_spec_to = null; 
			WhereFeeglobaladdoncdexclusionflag = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _FEE_OMA_CD_LTR1;
		private string _FILLER_NUMERIC;
		private string _FEE_SPECIAL_M_SUFFIX_IND;
		private decimal? _FEE_DATE_YY;
		private decimal? _FEE_DATE_MM;
		private decimal? _FEE_DATE_DD;
		private string _FEE_ACTIVE_FOR_ENTRY;
		private string _FEE_DESC;
		private decimal? _FEE_CURR_A_FEE_1;
		private decimal? _FEE_CURR_H_FEE_1;
		private decimal? _FEE_CURR_A_FEE_2;
		private decimal? _FEE_CURR_H_FEE_2;
		private decimal? _FEE_CURR_A_MIN;
		private decimal? _FEE_CURR_H_MIN;
		private decimal? _FEE_CURR_A_MAX;
		private decimal? _FEE_CURR_H_MAX;
		private decimal? _FEE_CURR_A_ANAE;
		private decimal? _FEE_CURR_H_ANAE;
		private decimal? _FEE_CURR_A_ASST;
		private decimal? _FEE_CURR_H_ASST;
		private string _FEE_CURR_ADD_ON_CD1;
		private string _FEE_CURR_ADD_ON_CD2;
		private string _FEE_CURR_ADD_ON_CD3;
		private string _FEE_CURR_ADD_ON_CD4;
		private string _FEE_CURR_ADD_ON_CD5;
		private string _FEE_CURR_ADD_ON_CD6;
		private string _FEE_CURR_ADD_ON_CD7;
		private string _FEE_CURR_ADD_ON_CD8;
		private string _FEE_CURR_ADD_ON_CD9;
		private string _FEE_CURR_ADD_ON_CD10;
		private string _FEE_CURR_OMA_IND_CARD_REQUIRED1;
		private string _FEE_CURR_OMA_IND_CARD_REQUIRED2;
		private string _FEE_CURR_OMA_IND_CARD_REQUIRED3;
		private string _FEE_CURR_PAGE_ALPHA;
		private decimal? _FEE_CURR_PAGE_NUMERIC;
		private string _FEE_CURR_ADD_ON_PERC_OR_FLAT_IND;
		private decimal? _FEE_PREV_A_FEE_1;
		private decimal? _FEE_PREV_H_FEE_1;
		private decimal? _FEE_PREV_A_FEE_2;
		private decimal? _FEE_PREV_H_FEE_2;
		private decimal? _FEE_PREV_A_MIN;
		private decimal? _FEE_PREV_H_MIN;
		private decimal? _FEE_PREV_A_MAX;
		private decimal? _FEE_PREV_H_MAX;
		private decimal? _FEE_PREV_A_ANAE;
		private decimal? _FEE_PREV_H_ANAE;
		private decimal? _FEE_PREV_A_ASST;
		private decimal? _FEE_PREV_H_ASST;
		private string _FEE_PREV_ADD_ON_CD1;
		private string _FEE_PREV_ADD_ON_CD2;
		private string _FEE_PREV_ADD_ON_CD3;
		private string _FEE_PREV_ADD_ON_CD4;
		private string _FEE_PREV_ADD_ON_CD5;
		private string _FEE_PREV_ADD_ON_CD6;
		private string _FEE_PREV_ADD_ON_CD7;
		private string _FEE_PREV_ADD_ON_CD8;
		private string _FEE_PREV_ADD_ON_CD9;
		private string _FEE_PREV_ADD_ON_CD10;
		private string _FEE_PREV_OMA_IND_CARD_REQUIRED1;
		private string _FEE_PREV_OMA_IND_CARD_REQUIRED2;
		private string _FEE_PREV_OMA_IND_CARD_REQUIRED3;
		private string _FEE_PREV_PAGE_ALPHA;
		private decimal? _FEE_PREV_PAGE_NUMERIC;
		private string _FEE_PREV_ADD_ON_PERC_OR_FLAT_IND;
		private string _FEE_ICC_SEC;
		private decimal? _FEE_ICC_CAT;
		private decimal? _FEE_ICC_GRP;
		private decimal? _FEE_ICC_REDUC_IND;
		private string _FEE_DIAG_IND;
		private string _FEE_PHY_IND;
		private string _FEE_TECH_IND;
		private string _FEE_HOSP_NBR_IND;
		private string _FEE_I_O_IND;
		private string _FEE_ADMIT_IND;
		private decimal? _FEE_SPEC_FR;
		private decimal? _FEE_SPEC_TO;
		private string _FEEGLOBALADDONCDEXCLUSIONFLAG;
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
		public string FEE_OMA_CD_LTR1
		{
			get { return _FEE_OMA_CD_LTR1; }
			set
			{
				if (_FEE_OMA_CD_LTR1 != value)
				{
					_FEE_OMA_CD_LTR1 = value;
					ChangeState();
				}
			}
		}
		public string FILLER_NUMERIC
		{
			get { return _FILLER_NUMERIC; }
			set
			{
				if (_FILLER_NUMERIC != value)
				{
					_FILLER_NUMERIC = value;
					ChangeState();
				}
			}
		}
		public string FEE_SPECIAL_M_SUFFIX_IND
		{
			get { return _FEE_SPECIAL_M_SUFFIX_IND; }
			set
			{
				if (_FEE_SPECIAL_M_SUFFIX_IND != value)
				{
					_FEE_SPECIAL_M_SUFFIX_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_DATE_YY
		{
			get { return _FEE_DATE_YY; }
			set
			{
				if (_FEE_DATE_YY != value)
				{
					_FEE_DATE_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_DATE_MM
		{
			get { return _FEE_DATE_MM; }
			set
			{
				if (_FEE_DATE_MM != value)
				{
					_FEE_DATE_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_DATE_DD
		{
			get { return _FEE_DATE_DD; }
			set
			{
				if (_FEE_DATE_DD != value)
				{
					_FEE_DATE_DD = value;
					ChangeState();
				}
			}
		}
		public string FEE_ACTIVE_FOR_ENTRY
		{
			get { return _FEE_ACTIVE_FOR_ENTRY; }
			set
			{
				if (_FEE_ACTIVE_FOR_ENTRY != value)
				{
					_FEE_ACTIVE_FOR_ENTRY = value;
					ChangeState();
				}
			}
		}
		public string FEE_DESC
		{
			get { return _FEE_DESC; }
			set
			{
				if (_FEE_DESC != value)
				{
					_FEE_DESC = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_FEE_1
		{
			get { return _FEE_CURR_A_FEE_1; }
			set
			{
				if (_FEE_CURR_A_FEE_1 != value)
				{
					_FEE_CURR_A_FEE_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_FEE_1
		{
			get { return _FEE_CURR_H_FEE_1; }
			set
			{
				if (_FEE_CURR_H_FEE_1 != value)
				{
					_FEE_CURR_H_FEE_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_FEE_2
		{
			get { return _FEE_CURR_A_FEE_2; }
			set
			{
				if (_FEE_CURR_A_FEE_2 != value)
				{
					_FEE_CURR_A_FEE_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_FEE_2
		{
			get { return _FEE_CURR_H_FEE_2; }
			set
			{
				if (_FEE_CURR_H_FEE_2 != value)
				{
					_FEE_CURR_H_FEE_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_MIN
		{
			get { return _FEE_CURR_A_MIN; }
			set
			{
				if (_FEE_CURR_A_MIN != value)
				{
					_FEE_CURR_A_MIN = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_MIN
		{
			get { return _FEE_CURR_H_MIN; }
			set
			{
				if (_FEE_CURR_H_MIN != value)
				{
					_FEE_CURR_H_MIN = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_MAX
		{
			get { return _FEE_CURR_A_MAX; }
			set
			{
				if (_FEE_CURR_A_MAX != value)
				{
					_FEE_CURR_A_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_MAX
		{
			get { return _FEE_CURR_H_MAX; }
			set
			{
				if (_FEE_CURR_H_MAX != value)
				{
					_FEE_CURR_H_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_ANAE
		{
			get { return _FEE_CURR_A_ANAE; }
			set
			{
				if (_FEE_CURR_A_ANAE != value)
				{
					_FEE_CURR_A_ANAE = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_ANAE
		{
			get { return _FEE_CURR_H_ANAE; }
			set
			{
				if (_FEE_CURR_H_ANAE != value)
				{
					_FEE_CURR_H_ANAE = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_A_ASST
		{
			get { return _FEE_CURR_A_ASST; }
			set
			{
				if (_FEE_CURR_A_ASST != value)
				{
					_FEE_CURR_A_ASST = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_H_ASST
		{
			get { return _FEE_CURR_H_ASST; }
			set
			{
				if (_FEE_CURR_H_ASST != value)
				{
					_FEE_CURR_H_ASST = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD1
		{
			get { return _FEE_CURR_ADD_ON_CD1; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD1 != value)
				{
					_FEE_CURR_ADD_ON_CD1 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD2
		{
			get { return _FEE_CURR_ADD_ON_CD2; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD2 != value)
				{
					_FEE_CURR_ADD_ON_CD2 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD3
		{
			get { return _FEE_CURR_ADD_ON_CD3; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD3 != value)
				{
					_FEE_CURR_ADD_ON_CD3 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD4
		{
			get { return _FEE_CURR_ADD_ON_CD4; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD4 != value)
				{
					_FEE_CURR_ADD_ON_CD4 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD5
		{
			get { return _FEE_CURR_ADD_ON_CD5; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD5 != value)
				{
					_FEE_CURR_ADD_ON_CD5 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD6
		{
			get { return _FEE_CURR_ADD_ON_CD6; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD6 != value)
				{
					_FEE_CURR_ADD_ON_CD6 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD7
		{
			get { return _FEE_CURR_ADD_ON_CD7; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD7 != value)
				{
					_FEE_CURR_ADD_ON_CD7 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD8
		{
			get { return _FEE_CURR_ADD_ON_CD8; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD8 != value)
				{
					_FEE_CURR_ADD_ON_CD8 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD9
		{
			get { return _FEE_CURR_ADD_ON_CD9; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD9 != value)
				{
					_FEE_CURR_ADD_ON_CD9 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_CD10
		{
			get { return _FEE_CURR_ADD_ON_CD10; }
			set
			{
				if (_FEE_CURR_ADD_ON_CD10 != value)
				{
					_FEE_CURR_ADD_ON_CD10 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_OMA_IND_CARD_REQUIRED1
		{
			get { return _FEE_CURR_OMA_IND_CARD_REQUIRED1; }
			set
			{
				if (_FEE_CURR_OMA_IND_CARD_REQUIRED1 != value)
				{
					_FEE_CURR_OMA_IND_CARD_REQUIRED1 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_OMA_IND_CARD_REQUIRED2
		{
			get { return _FEE_CURR_OMA_IND_CARD_REQUIRED2; }
			set
			{
				if (_FEE_CURR_OMA_IND_CARD_REQUIRED2 != value)
				{
					_FEE_CURR_OMA_IND_CARD_REQUIRED2 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_OMA_IND_CARD_REQUIRED3
		{
			get { return _FEE_CURR_OMA_IND_CARD_REQUIRED3; }
			set
			{
				if (_FEE_CURR_OMA_IND_CARD_REQUIRED3 != value)
				{
					_FEE_CURR_OMA_IND_CARD_REQUIRED3 = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_PAGE_ALPHA
		{
			get { return _FEE_CURR_PAGE_ALPHA; }
			set
			{
				if (_FEE_CURR_PAGE_ALPHA != value)
				{
					_FEE_CURR_PAGE_ALPHA = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_CURR_PAGE_NUMERIC
		{
			get { return _FEE_CURR_PAGE_NUMERIC; }
			set
			{
				if (_FEE_CURR_PAGE_NUMERIC != value)
				{
					_FEE_CURR_PAGE_NUMERIC = value;
					ChangeState();
				}
			}
		}
		public string FEE_CURR_ADD_ON_PERC_OR_FLAT_IND
		{
			get { return _FEE_CURR_ADD_ON_PERC_OR_FLAT_IND; }
			set
			{
				if (_FEE_CURR_ADD_ON_PERC_OR_FLAT_IND != value)
				{
					_FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_FEE_1
		{
			get { return _FEE_PREV_A_FEE_1; }
			set
			{
				if (_FEE_PREV_A_FEE_1 != value)
				{
					_FEE_PREV_A_FEE_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_FEE_1
		{
			get { return _FEE_PREV_H_FEE_1; }
			set
			{
				if (_FEE_PREV_H_FEE_1 != value)
				{
					_FEE_PREV_H_FEE_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_FEE_2
		{
			get { return _FEE_PREV_A_FEE_2; }
			set
			{
				if (_FEE_PREV_A_FEE_2 != value)
				{
					_FEE_PREV_A_FEE_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_FEE_2
		{
			get { return _FEE_PREV_H_FEE_2; }
			set
			{
				if (_FEE_PREV_H_FEE_2 != value)
				{
					_FEE_PREV_H_FEE_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_MIN
		{
			get { return _FEE_PREV_A_MIN; }
			set
			{
				if (_FEE_PREV_A_MIN != value)
				{
					_FEE_PREV_A_MIN = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_MIN
		{
			get { return _FEE_PREV_H_MIN; }
			set
			{
				if (_FEE_PREV_H_MIN != value)
				{
					_FEE_PREV_H_MIN = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_MAX
		{
			get { return _FEE_PREV_A_MAX; }
			set
			{
				if (_FEE_PREV_A_MAX != value)
				{
					_FEE_PREV_A_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_MAX
		{
			get { return _FEE_PREV_H_MAX; }
			set
			{
				if (_FEE_PREV_H_MAX != value)
				{
					_FEE_PREV_H_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_ANAE
		{
			get { return _FEE_PREV_A_ANAE; }
			set
			{
				if (_FEE_PREV_A_ANAE != value)
				{
					_FEE_PREV_A_ANAE = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_ANAE
		{
			get { return _FEE_PREV_H_ANAE; }
			set
			{
				if (_FEE_PREV_H_ANAE != value)
				{
					_FEE_PREV_H_ANAE = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_A_ASST
		{
			get { return _FEE_PREV_A_ASST; }
			set
			{
				if (_FEE_PREV_A_ASST != value)
				{
					_FEE_PREV_A_ASST = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_H_ASST
		{
			get { return _FEE_PREV_H_ASST; }
			set
			{
				if (_FEE_PREV_H_ASST != value)
				{
					_FEE_PREV_H_ASST = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD1
		{
			get { return _FEE_PREV_ADD_ON_CD1; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD1 != value)
				{
					_FEE_PREV_ADD_ON_CD1 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD2
		{
			get { return _FEE_PREV_ADD_ON_CD2; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD2 != value)
				{
					_FEE_PREV_ADD_ON_CD2 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD3
		{
			get { return _FEE_PREV_ADD_ON_CD3; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD3 != value)
				{
					_FEE_PREV_ADD_ON_CD3 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD4
		{
			get { return _FEE_PREV_ADD_ON_CD4; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD4 != value)
				{
					_FEE_PREV_ADD_ON_CD4 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD5
		{
			get { return _FEE_PREV_ADD_ON_CD5; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD5 != value)
				{
					_FEE_PREV_ADD_ON_CD5 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD6
		{
			get { return _FEE_PREV_ADD_ON_CD6; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD6 != value)
				{
					_FEE_PREV_ADD_ON_CD6 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD7
		{
			get { return _FEE_PREV_ADD_ON_CD7; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD7 != value)
				{
					_FEE_PREV_ADD_ON_CD7 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD8
		{
			get { return _FEE_PREV_ADD_ON_CD8; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD8 != value)
				{
					_FEE_PREV_ADD_ON_CD8 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD9
		{
			get { return _FEE_PREV_ADD_ON_CD9; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD9 != value)
				{
					_FEE_PREV_ADD_ON_CD9 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_CD10
		{
			get { return _FEE_PREV_ADD_ON_CD10; }
			set
			{
				if (_FEE_PREV_ADD_ON_CD10 != value)
				{
					_FEE_PREV_ADD_ON_CD10 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_OMA_IND_CARD_REQUIRED1
		{
			get { return _FEE_PREV_OMA_IND_CARD_REQUIRED1; }
			set
			{
				if (_FEE_PREV_OMA_IND_CARD_REQUIRED1 != value)
				{
					_FEE_PREV_OMA_IND_CARD_REQUIRED1 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_OMA_IND_CARD_REQUIRED2
		{
			get { return _FEE_PREV_OMA_IND_CARD_REQUIRED2; }
			set
			{
				if (_FEE_PREV_OMA_IND_CARD_REQUIRED2 != value)
				{
					_FEE_PREV_OMA_IND_CARD_REQUIRED2 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_OMA_IND_CARD_REQUIRED3
		{
			get { return _FEE_PREV_OMA_IND_CARD_REQUIRED3; }
			set
			{
				if (_FEE_PREV_OMA_IND_CARD_REQUIRED3 != value)
				{
					_FEE_PREV_OMA_IND_CARD_REQUIRED3 = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_PAGE_ALPHA
		{
			get { return _FEE_PREV_PAGE_ALPHA; }
			set
			{
				if (_FEE_PREV_PAGE_ALPHA != value)
				{
					_FEE_PREV_PAGE_ALPHA = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_PREV_PAGE_NUMERIC
		{
			get { return _FEE_PREV_PAGE_NUMERIC; }
			set
			{
				if (_FEE_PREV_PAGE_NUMERIC != value)
				{
					_FEE_PREV_PAGE_NUMERIC = value;
					ChangeState();
				}
			}
		}
		public string FEE_PREV_ADD_ON_PERC_OR_FLAT_IND
		{
			get { return _FEE_PREV_ADD_ON_PERC_OR_FLAT_IND; }
			set
			{
				if (_FEE_PREV_ADD_ON_PERC_OR_FLAT_IND != value)
				{
					_FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_ICC_SEC
		{
			get { return _FEE_ICC_SEC; }
			set
			{
				if (_FEE_ICC_SEC != value)
				{
					_FEE_ICC_SEC = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_ICC_CAT
		{
			get { return _FEE_ICC_CAT; }
			set
			{
				if (_FEE_ICC_CAT != value)
				{
					_FEE_ICC_CAT = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_ICC_GRP
		{
			get { return _FEE_ICC_GRP; }
			set
			{
				if (_FEE_ICC_GRP != value)
				{
					_FEE_ICC_GRP = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_ICC_REDUC_IND
		{
			get { return _FEE_ICC_REDUC_IND; }
			set
			{
				if (_FEE_ICC_REDUC_IND != value)
				{
					_FEE_ICC_REDUC_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_DIAG_IND
		{
			get { return _FEE_DIAG_IND; }
			set
			{
				if (_FEE_DIAG_IND != value)
				{
					_FEE_DIAG_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_PHY_IND
		{
			get { return _FEE_PHY_IND; }
			set
			{
				if (_FEE_PHY_IND != value)
				{
					_FEE_PHY_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_TECH_IND
		{
			get { return _FEE_TECH_IND; }
			set
			{
				if (_FEE_TECH_IND != value)
				{
					_FEE_TECH_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_HOSP_NBR_IND
		{
			get { return _FEE_HOSP_NBR_IND; }
			set
			{
				if (_FEE_HOSP_NBR_IND != value)
				{
					_FEE_HOSP_NBR_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_I_O_IND
		{
			get { return _FEE_I_O_IND; }
			set
			{
				if (_FEE_I_O_IND != value)
				{
					_FEE_I_O_IND = value;
					ChangeState();
				}
			}
		}
		public string FEE_ADMIT_IND
		{
			get { return _FEE_ADMIT_IND; }
			set
			{
				if (_FEE_ADMIT_IND != value)
				{
					_FEE_ADMIT_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_SPEC_FR
		{
			get { return _FEE_SPEC_FR; }
			set
			{
				if (_FEE_SPEC_FR != value)
				{
					_FEE_SPEC_FR = value;
					ChangeState();
				}
			}
		}
		public decimal? FEE_SPEC_TO
		{
			get { return _FEE_SPEC_TO; }
			set
			{
				if (_FEE_SPEC_TO != value)
				{
					_FEE_SPEC_TO = value;
					ChangeState();
				}
			}
		}
		public string FEEGLOBALADDONCDEXCLUSIONFLAG
		{
			get { return _FEEGLOBALADDONCDEXCLUSIONFLAG; }
			set
			{
				if (_FEEGLOBALADDONCDEXCLUSIONFLAG != value)
				{
					_FEEGLOBALADDONCDEXCLUSIONFLAG = value;
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
		public string WhereFee_oma_cd_ltr1 { get; set; }
		private string _whereFee_oma_cd_ltr1;
		public string WhereFiller_numeric { get; set; }
		private string _whereFiller_numeric;
		public string WhereFee_special_m_suffix_ind { get; set; }
		private string _whereFee_special_m_suffix_ind;
		public decimal? WhereFee_date_yy { get; set; }
		private decimal? _whereFee_date_yy;
		public decimal? WhereFee_date_mm { get; set; }
		private decimal? _whereFee_date_mm;
		public decimal? WhereFee_date_dd { get; set; }
		private decimal? _whereFee_date_dd;
		public string WhereFee_active_for_entry { get; set; }
		private string _whereFee_active_for_entry;
		public string WhereFee_desc { get; set; }
		private string _whereFee_desc;
		public decimal? WhereFee_curr_a_fee_1 { get; set; }
		private decimal? _whereFee_curr_a_fee_1;
		public decimal? WhereFee_curr_h_fee_1 { get; set; }
		private decimal? _whereFee_curr_h_fee_1;
		public decimal? WhereFee_curr_a_fee_2 { get; set; }
		private decimal? _whereFee_curr_a_fee_2;
		public decimal? WhereFee_curr_h_fee_2 { get; set; }
		private decimal? _whereFee_curr_h_fee_2;
		public decimal? WhereFee_curr_a_min { get; set; }
		private decimal? _whereFee_curr_a_min;
		public decimal? WhereFee_curr_h_min { get; set; }
		private decimal? _whereFee_curr_h_min;
		public decimal? WhereFee_curr_a_max { get; set; }
		private decimal? _whereFee_curr_a_max;
		public decimal? WhereFee_curr_h_max { get; set; }
		private decimal? _whereFee_curr_h_max;
		public decimal? WhereFee_curr_a_anae { get; set; }
		private decimal? _whereFee_curr_a_anae;
		public decimal? WhereFee_curr_h_anae { get; set; }
		private decimal? _whereFee_curr_h_anae;
		public decimal? WhereFee_curr_a_asst { get; set; }
		private decimal? _whereFee_curr_a_asst;
		public decimal? WhereFee_curr_h_asst { get; set; }
		private decimal? _whereFee_curr_h_asst;
		public string WhereFee_curr_add_on_cd1 { get; set; }
		private string _whereFee_curr_add_on_cd1;
		public string WhereFee_curr_add_on_cd2 { get; set; }
		private string _whereFee_curr_add_on_cd2;
		public string WhereFee_curr_add_on_cd3 { get; set; }
		private string _whereFee_curr_add_on_cd3;
		public string WhereFee_curr_add_on_cd4 { get; set; }
		private string _whereFee_curr_add_on_cd4;
		public string WhereFee_curr_add_on_cd5 { get; set; }
		private string _whereFee_curr_add_on_cd5;
		public string WhereFee_curr_add_on_cd6 { get; set; }
		private string _whereFee_curr_add_on_cd6;
		public string WhereFee_curr_add_on_cd7 { get; set; }
		private string _whereFee_curr_add_on_cd7;
		public string WhereFee_curr_add_on_cd8 { get; set; }
		private string _whereFee_curr_add_on_cd8;
		public string WhereFee_curr_add_on_cd9 { get; set; }
		private string _whereFee_curr_add_on_cd9;
		public string WhereFee_curr_add_on_cd10 { get; set; }
		private string _whereFee_curr_add_on_cd10;
		public string WhereFee_curr_oma_ind_card_required1 { get; set; }
		private string _whereFee_curr_oma_ind_card_required1;
		public string WhereFee_curr_oma_ind_card_required2 { get; set; }
		private string _whereFee_curr_oma_ind_card_required2;
		public string WhereFee_curr_oma_ind_card_required3 { get; set; }
		private string _whereFee_curr_oma_ind_card_required3;
		public string WhereFee_curr_page_alpha { get; set; }
		private string _whereFee_curr_page_alpha;
		public decimal? WhereFee_curr_page_numeric { get; set; }
		private decimal? _whereFee_curr_page_numeric;
		public string WhereFee_curr_add_on_perc_or_flat_ind { get; set; }
		private string _whereFee_curr_add_on_perc_or_flat_ind;
		public decimal? WhereFee_prev_a_fee_1 { get; set; }
		private decimal? _whereFee_prev_a_fee_1;
		public decimal? WhereFee_prev_h_fee_1 { get; set; }
		private decimal? _whereFee_prev_h_fee_1;
		public decimal? WhereFee_prev_a_fee_2 { get; set; }
		private decimal? _whereFee_prev_a_fee_2;
		public decimal? WhereFee_prev_h_fee_2 { get; set; }
		private decimal? _whereFee_prev_h_fee_2;
		public decimal? WhereFee_prev_a_min { get; set; }
		private decimal? _whereFee_prev_a_min;
		public decimal? WhereFee_prev_h_min { get; set; }
		private decimal? _whereFee_prev_h_min;
		public decimal? WhereFee_prev_a_max { get; set; }
		private decimal? _whereFee_prev_a_max;
		public decimal? WhereFee_prev_h_max { get; set; }
		private decimal? _whereFee_prev_h_max;
		public decimal? WhereFee_prev_a_anae { get; set; }
		private decimal? _whereFee_prev_a_anae;
		public decimal? WhereFee_prev_h_anae { get; set; }
		private decimal? _whereFee_prev_h_anae;
		public decimal? WhereFee_prev_a_asst { get; set; }
		private decimal? _whereFee_prev_a_asst;
		public decimal? WhereFee_prev_h_asst { get; set; }
		private decimal? _whereFee_prev_h_asst;
		public string WhereFee_prev_add_on_cd1 { get; set; }
		private string _whereFee_prev_add_on_cd1;
		public string WhereFee_prev_add_on_cd2 { get; set; }
		private string _whereFee_prev_add_on_cd2;
		public string WhereFee_prev_add_on_cd3 { get; set; }
		private string _whereFee_prev_add_on_cd3;
		public string WhereFee_prev_add_on_cd4 { get; set; }
		private string _whereFee_prev_add_on_cd4;
		public string WhereFee_prev_add_on_cd5 { get; set; }
		private string _whereFee_prev_add_on_cd5;
		public string WhereFee_prev_add_on_cd6 { get; set; }
		private string _whereFee_prev_add_on_cd6;
		public string WhereFee_prev_add_on_cd7 { get; set; }
		private string _whereFee_prev_add_on_cd7;
		public string WhereFee_prev_add_on_cd8 { get; set; }
		private string _whereFee_prev_add_on_cd8;
		public string WhereFee_prev_add_on_cd9 { get; set; }
		private string _whereFee_prev_add_on_cd9;
		public string WhereFee_prev_add_on_cd10 { get; set; }
		private string _whereFee_prev_add_on_cd10;
		public string WhereFee_prev_oma_ind_card_required1 { get; set; }
		private string _whereFee_prev_oma_ind_card_required1;
		public string WhereFee_prev_oma_ind_card_required2 { get; set; }
		private string _whereFee_prev_oma_ind_card_required2;
		public string WhereFee_prev_oma_ind_card_required3 { get; set; }
		private string _whereFee_prev_oma_ind_card_required3;
		public string WhereFee_prev_page_alpha { get; set; }
		private string _whereFee_prev_page_alpha;
		public decimal? WhereFee_prev_page_numeric { get; set; }
		private decimal? _whereFee_prev_page_numeric;
		public string WhereFee_prev_add_on_perc_or_flat_ind { get; set; }
		private string _whereFee_prev_add_on_perc_or_flat_ind;
		public string WhereFee_icc_sec { get; set; }
		private string _whereFee_icc_sec;
		public decimal? WhereFee_icc_cat { get; set; }
		private decimal? _whereFee_icc_cat;
		public decimal? WhereFee_icc_grp { get; set; }
		private decimal? _whereFee_icc_grp;
		public decimal? WhereFee_icc_reduc_ind { get; set; }
		private decimal? _whereFee_icc_reduc_ind;
		public string WhereFee_diag_ind { get; set; }
		private string _whereFee_diag_ind;
		public string WhereFee_phy_ind { get; set; }
		private string _whereFee_phy_ind;
		public string WhereFee_tech_ind { get; set; }
		private string _whereFee_tech_ind;
		public string WhereFee_hosp_nbr_ind { get; set; }
		private string _whereFee_hosp_nbr_ind;
		public string WhereFee_i_o_ind { get; set; }
		private string _whereFee_i_o_ind;
		public string WhereFee_admit_ind { get; set; }
		private string _whereFee_admit_ind;
		public decimal? WhereFee_spec_fr { get; set; }
		private decimal? _whereFee_spec_fr;
		public decimal? WhereFee_spec_to { get; set; }
		private decimal? _whereFee_spec_to;
		public string WhereFeeglobaladdoncdexclusionflag { get; set; }
		private string _whereFeeglobaladdoncdexclusionflag;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalFee_oma_cd_ltr1;
		private string _originalFiller_numeric;
		private string _originalFee_special_m_suffix_ind;
		private decimal? _originalFee_date_yy;
		private decimal? _originalFee_date_mm;
		private decimal? _originalFee_date_dd;
		private string _originalFee_active_for_entry;
		private string _originalFee_desc;
		private decimal? _originalFee_curr_a_fee_1;
		private decimal? _originalFee_curr_h_fee_1;
		private decimal? _originalFee_curr_a_fee_2;
		private decimal? _originalFee_curr_h_fee_2;
		private decimal? _originalFee_curr_a_min;
		private decimal? _originalFee_curr_h_min;
		private decimal? _originalFee_curr_a_max;
		private decimal? _originalFee_curr_h_max;
		private decimal? _originalFee_curr_a_anae;
		private decimal? _originalFee_curr_h_anae;
		private decimal? _originalFee_curr_a_asst;
		private decimal? _originalFee_curr_h_asst;
		private string _originalFee_curr_add_on_cd1;
		private string _originalFee_curr_add_on_cd2;
		private string _originalFee_curr_add_on_cd3;
		private string _originalFee_curr_add_on_cd4;
		private string _originalFee_curr_add_on_cd5;
		private string _originalFee_curr_add_on_cd6;
		private string _originalFee_curr_add_on_cd7;
		private string _originalFee_curr_add_on_cd8;
		private string _originalFee_curr_add_on_cd9;
		private string _originalFee_curr_add_on_cd10;
		private string _originalFee_curr_oma_ind_card_required1;
		private string _originalFee_curr_oma_ind_card_required2;
		private string _originalFee_curr_oma_ind_card_required3;
		private string _originalFee_curr_page_alpha;
		private decimal? _originalFee_curr_page_numeric;
		private string _originalFee_curr_add_on_perc_or_flat_ind;
		private decimal? _originalFee_prev_a_fee_1;
		private decimal? _originalFee_prev_h_fee_1;
		private decimal? _originalFee_prev_a_fee_2;
		private decimal? _originalFee_prev_h_fee_2;
		private decimal? _originalFee_prev_a_min;
		private decimal? _originalFee_prev_h_min;
		private decimal? _originalFee_prev_a_max;
		private decimal? _originalFee_prev_h_max;
		private decimal? _originalFee_prev_a_anae;
		private decimal? _originalFee_prev_h_anae;
		private decimal? _originalFee_prev_a_asst;
		private decimal? _originalFee_prev_h_asst;
		private string _originalFee_prev_add_on_cd1;
		private string _originalFee_prev_add_on_cd2;
		private string _originalFee_prev_add_on_cd3;
		private string _originalFee_prev_add_on_cd4;
		private string _originalFee_prev_add_on_cd5;
		private string _originalFee_prev_add_on_cd6;
		private string _originalFee_prev_add_on_cd7;
		private string _originalFee_prev_add_on_cd8;
		private string _originalFee_prev_add_on_cd9;
		private string _originalFee_prev_add_on_cd10;
		private string _originalFee_prev_oma_ind_card_required1;
		private string _originalFee_prev_oma_ind_card_required2;
		private string _originalFee_prev_oma_ind_card_required3;
		private string _originalFee_prev_page_alpha;
		private decimal? _originalFee_prev_page_numeric;
		private string _originalFee_prev_add_on_perc_or_flat_ind;
		private string _originalFee_icc_sec;
		private decimal? _originalFee_icc_cat;
		private decimal? _originalFee_icc_grp;
		private decimal? _originalFee_icc_reduc_ind;
		private string _originalFee_diag_ind;
		private string _originalFee_phy_ind;
		private string _originalFee_tech_ind;
		private string _originalFee_hosp_nbr_ind;
		private string _originalFee_i_o_ind;
		private string _originalFee_admit_ind;
		private decimal? _originalFee_spec_fr;
		private decimal? _originalFee_spec_to;
		private string _originalFeeglobaladdoncdexclusionflag;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			FEE_OMA_CD_LTR1 = _originalFee_oma_cd_ltr1;
			FILLER_NUMERIC = _originalFiller_numeric;
			FEE_SPECIAL_M_SUFFIX_IND = _originalFee_special_m_suffix_ind;
			FEE_DATE_YY = _originalFee_date_yy;
			FEE_DATE_MM = _originalFee_date_mm;
			FEE_DATE_DD = _originalFee_date_dd;
			FEE_ACTIVE_FOR_ENTRY = _originalFee_active_for_entry;
			FEE_DESC = _originalFee_desc;
			FEE_CURR_A_FEE_1 = _originalFee_curr_a_fee_1;
			FEE_CURR_H_FEE_1 = _originalFee_curr_h_fee_1;
			FEE_CURR_A_FEE_2 = _originalFee_curr_a_fee_2;
			FEE_CURR_H_FEE_2 = _originalFee_curr_h_fee_2;
			FEE_CURR_A_MIN = _originalFee_curr_a_min;
			FEE_CURR_H_MIN = _originalFee_curr_h_min;
			FEE_CURR_A_MAX = _originalFee_curr_a_max;
			FEE_CURR_H_MAX = _originalFee_curr_h_max;
			FEE_CURR_A_ANAE = _originalFee_curr_a_anae;
			FEE_CURR_H_ANAE = _originalFee_curr_h_anae;
			FEE_CURR_A_ASST = _originalFee_curr_a_asst;
			FEE_CURR_H_ASST = _originalFee_curr_h_asst;
			FEE_CURR_ADD_ON_CD1 = _originalFee_curr_add_on_cd1;
			FEE_CURR_ADD_ON_CD2 = _originalFee_curr_add_on_cd2;
			FEE_CURR_ADD_ON_CD3 = _originalFee_curr_add_on_cd3;
			FEE_CURR_ADD_ON_CD4 = _originalFee_curr_add_on_cd4;
			FEE_CURR_ADD_ON_CD5 = _originalFee_curr_add_on_cd5;
			FEE_CURR_ADD_ON_CD6 = _originalFee_curr_add_on_cd6;
			FEE_CURR_ADD_ON_CD7 = _originalFee_curr_add_on_cd7;
			FEE_CURR_ADD_ON_CD8 = _originalFee_curr_add_on_cd8;
			FEE_CURR_ADD_ON_CD9 = _originalFee_curr_add_on_cd9;
			FEE_CURR_ADD_ON_CD10 = _originalFee_curr_add_on_cd10;
			FEE_CURR_OMA_IND_CARD_REQUIRED1 = _originalFee_curr_oma_ind_card_required1;
			FEE_CURR_OMA_IND_CARD_REQUIRED2 = _originalFee_curr_oma_ind_card_required2;
			FEE_CURR_OMA_IND_CARD_REQUIRED3 = _originalFee_curr_oma_ind_card_required3;
			FEE_CURR_PAGE_ALPHA = _originalFee_curr_page_alpha;
			FEE_CURR_PAGE_NUMERIC = _originalFee_curr_page_numeric;
			FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = _originalFee_curr_add_on_perc_or_flat_ind;
			FEE_PREV_A_FEE_1 = _originalFee_prev_a_fee_1;
			FEE_PREV_H_FEE_1 = _originalFee_prev_h_fee_1;
			FEE_PREV_A_FEE_2 = _originalFee_prev_a_fee_2;
			FEE_PREV_H_FEE_2 = _originalFee_prev_h_fee_2;
			FEE_PREV_A_MIN = _originalFee_prev_a_min;
			FEE_PREV_H_MIN = _originalFee_prev_h_min;
			FEE_PREV_A_MAX = _originalFee_prev_a_max;
			FEE_PREV_H_MAX = _originalFee_prev_h_max;
			FEE_PREV_A_ANAE = _originalFee_prev_a_anae;
			FEE_PREV_H_ANAE = _originalFee_prev_h_anae;
			FEE_PREV_A_ASST = _originalFee_prev_a_asst;
			FEE_PREV_H_ASST = _originalFee_prev_h_asst;
			FEE_PREV_ADD_ON_CD1 = _originalFee_prev_add_on_cd1;
			FEE_PREV_ADD_ON_CD2 = _originalFee_prev_add_on_cd2;
			FEE_PREV_ADD_ON_CD3 = _originalFee_prev_add_on_cd3;
			FEE_PREV_ADD_ON_CD4 = _originalFee_prev_add_on_cd4;
			FEE_PREV_ADD_ON_CD5 = _originalFee_prev_add_on_cd5;
			FEE_PREV_ADD_ON_CD6 = _originalFee_prev_add_on_cd6;
			FEE_PREV_ADD_ON_CD7 = _originalFee_prev_add_on_cd7;
			FEE_PREV_ADD_ON_CD8 = _originalFee_prev_add_on_cd8;
			FEE_PREV_ADD_ON_CD9 = _originalFee_prev_add_on_cd9;
			FEE_PREV_ADD_ON_CD10 = _originalFee_prev_add_on_cd10;
			FEE_PREV_OMA_IND_CARD_REQUIRED1 = _originalFee_prev_oma_ind_card_required1;
			FEE_PREV_OMA_IND_CARD_REQUIRED2 = _originalFee_prev_oma_ind_card_required2;
			FEE_PREV_OMA_IND_CARD_REQUIRED3 = _originalFee_prev_oma_ind_card_required3;
			FEE_PREV_PAGE_ALPHA = _originalFee_prev_page_alpha;
			FEE_PREV_PAGE_NUMERIC = _originalFee_prev_page_numeric;
			FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = _originalFee_prev_add_on_perc_or_flat_ind;
			FEE_ICC_SEC = _originalFee_icc_sec;
			FEE_ICC_CAT = _originalFee_icc_cat;
			FEE_ICC_GRP = _originalFee_icc_grp;
			FEE_ICC_REDUC_IND = _originalFee_icc_reduc_ind;
			FEE_DIAG_IND = _originalFee_diag_ind;
			FEE_PHY_IND = _originalFee_phy_ind;
			FEE_TECH_IND = _originalFee_tech_ind;
			FEE_HOSP_NBR_IND = _originalFee_hosp_nbr_ind;
			FEE_I_O_IND = _originalFee_i_o_ind;
			FEE_ADMIT_IND = _originalFee_admit_ind;
			FEE_SPEC_FR = _originalFee_spec_fr;
			FEE_SPEC_TO = _originalFee_spec_to;
			FEEGLOBALADDONCDEXCLUSIONFLAG = _originalFeeglobaladdoncdexclusionflag;
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
					new SqlParameter("FEE_OMA_CD_LTR1",FEE_OMA_CD_LTR1),
					new SqlParameter("FILLER_NUMERIC",FILLER_NUMERIC)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F040_OMA_FEE_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F040_OMA_FEE_MSTR_Purge]");
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
						new SqlParameter("FEE_OMA_CD_LTR1", SqlNull(FEE_OMA_CD_LTR1)),
						new SqlParameter("FILLER_NUMERIC", SqlNull(FILLER_NUMERIC)),
						new SqlParameter("FEE_SPECIAL_M_SUFFIX_IND", SqlNull(FEE_SPECIAL_M_SUFFIX_IND)),
						new SqlParameter("FEE_DATE_YY", SqlNull(FEE_DATE_YY)),
						new SqlParameter("FEE_DATE_MM", SqlNull(FEE_DATE_MM)),
						new SqlParameter("FEE_DATE_DD", SqlNull(FEE_DATE_DD)),
						new SqlParameter("FEE_ACTIVE_FOR_ENTRY", SqlNull(FEE_ACTIVE_FOR_ENTRY)),
						new SqlParameter("FEE_DESC", SqlNull(FEE_DESC)),
						new SqlParameter("FEE_CURR_A_FEE_1", SqlNull(FEE_CURR_A_FEE_1)),
						new SqlParameter("FEE_CURR_H_FEE_1", SqlNull(FEE_CURR_H_FEE_1)),
						new SqlParameter("FEE_CURR_A_FEE_2", SqlNull(FEE_CURR_A_FEE_2)),
						new SqlParameter("FEE_CURR_H_FEE_2", SqlNull(FEE_CURR_H_FEE_2)),
						new SqlParameter("FEE_CURR_A_MIN", SqlNull(FEE_CURR_A_MIN)),
						new SqlParameter("FEE_CURR_H_MIN", SqlNull(FEE_CURR_H_MIN)),
						new SqlParameter("FEE_CURR_A_MAX", SqlNull(FEE_CURR_A_MAX)),
						new SqlParameter("FEE_CURR_H_MAX", SqlNull(FEE_CURR_H_MAX)),
						new SqlParameter("FEE_CURR_A_ANAE", SqlNull(FEE_CURR_A_ANAE)),
						new SqlParameter("FEE_CURR_H_ANAE", SqlNull(FEE_CURR_H_ANAE)),
						new SqlParameter("FEE_CURR_A_ASST", SqlNull(FEE_CURR_A_ASST)),
						new SqlParameter("FEE_CURR_H_ASST", SqlNull(FEE_CURR_H_ASST)),
						new SqlParameter("FEE_CURR_ADD_ON_CD1", SqlNull(FEE_CURR_ADD_ON_CD1)),
						new SqlParameter("FEE_CURR_ADD_ON_CD2", SqlNull(FEE_CURR_ADD_ON_CD2)),
						new SqlParameter("FEE_CURR_ADD_ON_CD3", SqlNull(FEE_CURR_ADD_ON_CD3)),
						new SqlParameter("FEE_CURR_ADD_ON_CD4", SqlNull(FEE_CURR_ADD_ON_CD4)),
						new SqlParameter("FEE_CURR_ADD_ON_CD5", SqlNull(FEE_CURR_ADD_ON_CD5)),
						new SqlParameter("FEE_CURR_ADD_ON_CD6", SqlNull(FEE_CURR_ADD_ON_CD6)),
						new SqlParameter("FEE_CURR_ADD_ON_CD7", SqlNull(FEE_CURR_ADD_ON_CD7)),
						new SqlParameter("FEE_CURR_ADD_ON_CD8", SqlNull(FEE_CURR_ADD_ON_CD8)),
						new SqlParameter("FEE_CURR_ADD_ON_CD9", SqlNull(FEE_CURR_ADD_ON_CD9)),
						new SqlParameter("FEE_CURR_ADD_ON_CD10", SqlNull(FEE_CURR_ADD_ON_CD10)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED1", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED1)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED2", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED2)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED3", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED3)),
						new SqlParameter("FEE_CURR_PAGE_ALPHA", SqlNull(FEE_CURR_PAGE_ALPHA)),
						new SqlParameter("FEE_CURR_PAGE_NUMERIC", SqlNull(FEE_CURR_PAGE_NUMERIC)),
						new SqlParameter("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND", SqlNull(FEE_CURR_ADD_ON_PERC_OR_FLAT_IND)),
						new SqlParameter("FEE_PREV_A_FEE_1", SqlNull(FEE_PREV_A_FEE_1)),
						new SqlParameter("FEE_PREV_H_FEE_1", SqlNull(FEE_PREV_H_FEE_1)),
						new SqlParameter("FEE_PREV_A_FEE_2", SqlNull(FEE_PREV_A_FEE_2)),
						new SqlParameter("FEE_PREV_H_FEE_2", SqlNull(FEE_PREV_H_FEE_2)),
						new SqlParameter("FEE_PREV_A_MIN", SqlNull(FEE_PREV_A_MIN)),
						new SqlParameter("FEE_PREV_H_MIN", SqlNull(FEE_PREV_H_MIN)),
						new SqlParameter("FEE_PREV_A_MAX", SqlNull(FEE_PREV_A_MAX)),
						new SqlParameter("FEE_PREV_H_MAX", SqlNull(FEE_PREV_H_MAX)),
						new SqlParameter("FEE_PREV_A_ANAE", SqlNull(FEE_PREV_A_ANAE)),
						new SqlParameter("FEE_PREV_H_ANAE", SqlNull(FEE_PREV_H_ANAE)),
						new SqlParameter("FEE_PREV_A_ASST", SqlNull(FEE_PREV_A_ASST)),
						new SqlParameter("FEE_PREV_H_ASST", SqlNull(FEE_PREV_H_ASST)),
						new SqlParameter("FEE_PREV_ADD_ON_CD1", SqlNull(FEE_PREV_ADD_ON_CD1)),
						new SqlParameter("FEE_PREV_ADD_ON_CD2", SqlNull(FEE_PREV_ADD_ON_CD2)),
						new SqlParameter("FEE_PREV_ADD_ON_CD3", SqlNull(FEE_PREV_ADD_ON_CD3)),
						new SqlParameter("FEE_PREV_ADD_ON_CD4", SqlNull(FEE_PREV_ADD_ON_CD4)),
						new SqlParameter("FEE_PREV_ADD_ON_CD5", SqlNull(FEE_PREV_ADD_ON_CD5)),
						new SqlParameter("FEE_PREV_ADD_ON_CD6", SqlNull(FEE_PREV_ADD_ON_CD6)),
						new SqlParameter("FEE_PREV_ADD_ON_CD7", SqlNull(FEE_PREV_ADD_ON_CD7)),
						new SqlParameter("FEE_PREV_ADD_ON_CD8", SqlNull(FEE_PREV_ADD_ON_CD8)),
						new SqlParameter("FEE_PREV_ADD_ON_CD9", SqlNull(FEE_PREV_ADD_ON_CD9)),
						new SqlParameter("FEE_PREV_ADD_ON_CD10", SqlNull(FEE_PREV_ADD_ON_CD10)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED1", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED1)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED2", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED2)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED3", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED3)),
						new SqlParameter("FEE_PREV_PAGE_ALPHA", SqlNull(FEE_PREV_PAGE_ALPHA)),
						new SqlParameter("FEE_PREV_PAGE_NUMERIC", SqlNull(FEE_PREV_PAGE_NUMERIC)),
						new SqlParameter("FEE_PREV_ADD_ON_PERC_OR_FLAT_IND", SqlNull(FEE_PREV_ADD_ON_PERC_OR_FLAT_IND)),
						new SqlParameter("FEE_ICC_SEC", SqlNull(FEE_ICC_SEC)),
						new SqlParameter("FEE_ICC_CAT", SqlNull(FEE_ICC_CAT)),
						new SqlParameter("FEE_ICC_GRP", SqlNull(FEE_ICC_GRP)),
						new SqlParameter("FEE_ICC_REDUC_IND", SqlNull(FEE_ICC_REDUC_IND)),
						new SqlParameter("FEE_DIAG_IND", SqlNull(FEE_DIAG_IND)),
						new SqlParameter("FEE_PHY_IND", SqlNull(FEE_PHY_IND)),
						new SqlParameter("FEE_TECH_IND", SqlNull(FEE_TECH_IND)),
						new SqlParameter("FEE_HOSP_NBR_IND", SqlNull(FEE_HOSP_NBR_IND)),
						new SqlParameter("FEE_I_O_IND", SqlNull(FEE_I_O_IND)),
						new SqlParameter("FEE_ADMIT_IND", SqlNull(FEE_ADMIT_IND)),
						new SqlParameter("FEE_SPEC_FR", SqlNull(FEE_SPEC_FR)),
						new SqlParameter("FEE_SPEC_TO", SqlNull(FEE_SPEC_TO)),
						new SqlParameter("FEEGLOBALADDONCDEXCLUSIONFLAG", SqlNull(FEEGLOBALADDONCDEXCLUSIONFLAG)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F040_OMA_FEE_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FEE_OMA_CD_LTR1 = Reader["FEE_OMA_CD_LTR1"].ToString();
						FILLER_NUMERIC = Reader["FILLER_NUMERIC"].ToString();
						FEE_SPECIAL_M_SUFFIX_IND = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString();
						FEE_DATE_YY = ConvertDEC(Reader["FEE_DATE_YY"]);
						FEE_DATE_MM = ConvertDEC(Reader["FEE_DATE_MM"]);
						FEE_DATE_DD = ConvertDEC(Reader["FEE_DATE_DD"]);
						FEE_ACTIVE_FOR_ENTRY = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString();
						FEE_DESC = Reader["FEE_DESC"].ToString();
						FEE_CURR_A_FEE_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]);
						FEE_CURR_H_FEE_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]);
						FEE_CURR_A_FEE_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]);
						FEE_CURR_H_FEE_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]);
						FEE_CURR_A_MIN = ConvertDEC(Reader["FEE_CURR_A_MIN"]);
						FEE_CURR_H_MIN = ConvertDEC(Reader["FEE_CURR_H_MIN"]);
						FEE_CURR_A_MAX = ConvertDEC(Reader["FEE_CURR_A_MAX"]);
						FEE_CURR_H_MAX = ConvertDEC(Reader["FEE_CURR_H_MAX"]);
						FEE_CURR_A_ANAE = ConvertDEC(Reader["FEE_CURR_A_ANAE"]);
						FEE_CURR_H_ANAE = ConvertDEC(Reader["FEE_CURR_H_ANAE"]);
						FEE_CURR_A_ASST = ConvertDEC(Reader["FEE_CURR_A_ASST"]);
						FEE_CURR_H_ASST = ConvertDEC(Reader["FEE_CURR_H_ASST"]);
						FEE_CURR_ADD_ON_CD1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString();
						FEE_CURR_ADD_ON_CD2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString();
						FEE_CURR_ADD_ON_CD3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString();
						FEE_CURR_ADD_ON_CD4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString();
						FEE_CURR_ADD_ON_CD5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString();
						FEE_CURR_ADD_ON_CD6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString();
						FEE_CURR_ADD_ON_CD7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString();
						FEE_CURR_ADD_ON_CD8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString();
						FEE_CURR_ADD_ON_CD9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString();
						FEE_CURR_ADD_ON_CD10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString();
						FEE_CURR_PAGE_ALPHA = Reader["FEE_CURR_PAGE_ALPHA"].ToString();
						FEE_CURR_PAGE_NUMERIC = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]);
						FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						FEE_PREV_A_FEE_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]);
						FEE_PREV_H_FEE_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]);
						FEE_PREV_A_FEE_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]);
						FEE_PREV_H_FEE_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]);
						FEE_PREV_A_MIN = ConvertDEC(Reader["FEE_PREV_A_MIN"]);
						FEE_PREV_H_MIN = ConvertDEC(Reader["FEE_PREV_H_MIN"]);
						FEE_PREV_A_MAX = ConvertDEC(Reader["FEE_PREV_A_MAX"]);
						FEE_PREV_H_MAX = ConvertDEC(Reader["FEE_PREV_H_MAX"]);
						FEE_PREV_A_ANAE = ConvertDEC(Reader["FEE_PREV_A_ANAE"]);
						FEE_PREV_H_ANAE = ConvertDEC(Reader["FEE_PREV_H_ANAE"]);
						FEE_PREV_A_ASST = ConvertDEC(Reader["FEE_PREV_A_ASST"]);
						FEE_PREV_H_ASST = ConvertDEC(Reader["FEE_PREV_H_ASST"]);
						FEE_PREV_ADD_ON_CD1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString();
						FEE_PREV_ADD_ON_CD2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString();
						FEE_PREV_ADD_ON_CD3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString();
						FEE_PREV_ADD_ON_CD4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString();
						FEE_PREV_ADD_ON_CD5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString();
						FEE_PREV_ADD_ON_CD6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString();
						FEE_PREV_ADD_ON_CD7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString();
						FEE_PREV_ADD_ON_CD8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString();
						FEE_PREV_ADD_ON_CD9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString();
						FEE_PREV_ADD_ON_CD10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString();
						FEE_PREV_PAGE_ALPHA = Reader["FEE_PREV_PAGE_ALPHA"].ToString();
						FEE_PREV_PAGE_NUMERIC = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]);
						FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						FEE_ICC_SEC = Reader["FEE_ICC_SEC"].ToString();
						FEE_ICC_CAT = ConvertDEC(Reader["FEE_ICC_CAT"]);
						FEE_ICC_GRP = ConvertDEC(Reader["FEE_ICC_GRP"]);
						FEE_ICC_REDUC_IND = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]);
						FEE_DIAG_IND = Reader["FEE_DIAG_IND"].ToString();
						FEE_PHY_IND = Reader["FEE_PHY_IND"].ToString();
						FEE_TECH_IND = Reader["FEE_TECH_IND"].ToString();
						FEE_HOSP_NBR_IND = Reader["FEE_HOSP_NBR_IND"].ToString();
						FEE_I_O_IND = Reader["FEE_I_O_IND"].ToString();
						FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString();
						FEE_SPEC_FR = ConvertDEC(Reader["FEE_SPEC_FR"]);
						FEE_SPEC_TO = ConvertDEC(Reader["FEE_SPEC_TO"]);
						FEEGLOBALADDONCDEXCLUSIONFLAG = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFee_oma_cd_ltr1 = Reader["FEE_OMA_CD_LTR1"].ToString();
						_originalFiller_numeric = Reader["FILLER_NUMERIC"].ToString();
						_originalFee_special_m_suffix_ind = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString();
						_originalFee_date_yy = ConvertDEC(Reader["FEE_DATE_YY"]);
						_originalFee_date_mm = ConvertDEC(Reader["FEE_DATE_MM"]);
						_originalFee_date_dd = ConvertDEC(Reader["FEE_DATE_DD"]);
						_originalFee_active_for_entry = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString();
						_originalFee_desc = Reader["FEE_DESC"].ToString();
						_originalFee_curr_a_fee_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]);
						_originalFee_curr_h_fee_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]);
						_originalFee_curr_a_fee_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]);
						_originalFee_curr_h_fee_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]);
						_originalFee_curr_a_min = ConvertDEC(Reader["FEE_CURR_A_MIN"]);
						_originalFee_curr_h_min = ConvertDEC(Reader["FEE_CURR_H_MIN"]);
						_originalFee_curr_a_max = ConvertDEC(Reader["FEE_CURR_A_MAX"]);
						_originalFee_curr_h_max = ConvertDEC(Reader["FEE_CURR_H_MAX"]);
						_originalFee_curr_a_anae = ConvertDEC(Reader["FEE_CURR_A_ANAE"]);
						_originalFee_curr_h_anae = ConvertDEC(Reader["FEE_CURR_H_ANAE"]);
						_originalFee_curr_a_asst = ConvertDEC(Reader["FEE_CURR_A_ASST"]);
						_originalFee_curr_h_asst = ConvertDEC(Reader["FEE_CURR_H_ASST"]);
						_originalFee_curr_add_on_cd1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString();
						_originalFee_curr_add_on_cd2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString();
						_originalFee_curr_add_on_cd3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString();
						_originalFee_curr_add_on_cd4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString();
						_originalFee_curr_add_on_cd5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString();
						_originalFee_curr_add_on_cd6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString();
						_originalFee_curr_add_on_cd7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString();
						_originalFee_curr_add_on_cd8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString();
						_originalFee_curr_add_on_cd9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString();
						_originalFee_curr_add_on_cd10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString();
						_originalFee_curr_oma_ind_card_required1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString();
						_originalFee_curr_oma_ind_card_required2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString();
						_originalFee_curr_oma_ind_card_required3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString();
						_originalFee_curr_page_alpha = Reader["FEE_CURR_PAGE_ALPHA"].ToString();
						_originalFee_curr_page_numeric = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]);
						_originalFee_curr_add_on_perc_or_flat_ind = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						_originalFee_prev_a_fee_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]);
						_originalFee_prev_h_fee_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]);
						_originalFee_prev_a_fee_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]);
						_originalFee_prev_h_fee_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]);
						_originalFee_prev_a_min = ConvertDEC(Reader["FEE_PREV_A_MIN"]);
						_originalFee_prev_h_min = ConvertDEC(Reader["FEE_PREV_H_MIN"]);
						_originalFee_prev_a_max = ConvertDEC(Reader["FEE_PREV_A_MAX"]);
						_originalFee_prev_h_max = ConvertDEC(Reader["FEE_PREV_H_MAX"]);
						_originalFee_prev_a_anae = ConvertDEC(Reader["FEE_PREV_A_ANAE"]);
						_originalFee_prev_h_anae = ConvertDEC(Reader["FEE_PREV_H_ANAE"]);
						_originalFee_prev_a_asst = ConvertDEC(Reader["FEE_PREV_A_ASST"]);
						_originalFee_prev_h_asst = ConvertDEC(Reader["FEE_PREV_H_ASST"]);
						_originalFee_prev_add_on_cd1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString();
						_originalFee_prev_add_on_cd2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString();
						_originalFee_prev_add_on_cd3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString();
						_originalFee_prev_add_on_cd4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString();
						_originalFee_prev_add_on_cd5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString();
						_originalFee_prev_add_on_cd6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString();
						_originalFee_prev_add_on_cd7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString();
						_originalFee_prev_add_on_cd8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString();
						_originalFee_prev_add_on_cd9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString();
						_originalFee_prev_add_on_cd10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString();
						_originalFee_prev_oma_ind_card_required1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString();
						_originalFee_prev_oma_ind_card_required2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString();
						_originalFee_prev_oma_ind_card_required3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString();
						_originalFee_prev_page_alpha = Reader["FEE_PREV_PAGE_ALPHA"].ToString();
						_originalFee_prev_page_numeric = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]);
						_originalFee_prev_add_on_perc_or_flat_ind = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						_originalFee_icc_sec = Reader["FEE_ICC_SEC"].ToString();
						_originalFee_icc_cat = ConvertDEC(Reader["FEE_ICC_CAT"]);
						_originalFee_icc_grp = ConvertDEC(Reader["FEE_ICC_GRP"]);
						_originalFee_icc_reduc_ind = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]);
						_originalFee_diag_ind = Reader["FEE_DIAG_IND"].ToString();
						_originalFee_phy_ind = Reader["FEE_PHY_IND"].ToString();
						_originalFee_tech_ind = Reader["FEE_TECH_IND"].ToString();
						_originalFee_hosp_nbr_ind = Reader["FEE_HOSP_NBR_IND"].ToString();
						_originalFee_i_o_ind = Reader["FEE_I_O_IND"].ToString();
						_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString();
						_originalFee_spec_fr = ConvertDEC(Reader["FEE_SPEC_FR"]);
						_originalFee_spec_to = ConvertDEC(Reader["FEE_SPEC_TO"]);
						_originalFeeglobaladdoncdexclusionflag = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("FEE_OMA_CD_LTR1", SqlNull(FEE_OMA_CD_LTR1)),
						new SqlParameter("FILLER_NUMERIC", SqlNull(FILLER_NUMERIC)),
						new SqlParameter("FEE_SPECIAL_M_SUFFIX_IND", SqlNull(FEE_SPECIAL_M_SUFFIX_IND)),
						new SqlParameter("FEE_DATE_YY", SqlNull(FEE_DATE_YY)),
						new SqlParameter("FEE_DATE_MM", SqlNull(FEE_DATE_MM)),
						new SqlParameter("FEE_DATE_DD", SqlNull(FEE_DATE_DD)),
						new SqlParameter("FEE_ACTIVE_FOR_ENTRY", SqlNull(FEE_ACTIVE_FOR_ENTRY)),
						new SqlParameter("FEE_DESC", SqlNull(FEE_DESC)),
						new SqlParameter("FEE_CURR_A_FEE_1", SqlNull(FEE_CURR_A_FEE_1)),
						new SqlParameter("FEE_CURR_H_FEE_1", SqlNull(FEE_CURR_H_FEE_1)),
						new SqlParameter("FEE_CURR_A_FEE_2", SqlNull(FEE_CURR_A_FEE_2)),
						new SqlParameter("FEE_CURR_H_FEE_2", SqlNull(FEE_CURR_H_FEE_2)),
						new SqlParameter("FEE_CURR_A_MIN", SqlNull(FEE_CURR_A_MIN)),
						new SqlParameter("FEE_CURR_H_MIN", SqlNull(FEE_CURR_H_MIN)),
						new SqlParameter("FEE_CURR_A_MAX", SqlNull(FEE_CURR_A_MAX)),
						new SqlParameter("FEE_CURR_H_MAX", SqlNull(FEE_CURR_H_MAX)),
						new SqlParameter("FEE_CURR_A_ANAE", SqlNull(FEE_CURR_A_ANAE)),
						new SqlParameter("FEE_CURR_H_ANAE", SqlNull(FEE_CURR_H_ANAE)),
						new SqlParameter("FEE_CURR_A_ASST", SqlNull(FEE_CURR_A_ASST)),
						new SqlParameter("FEE_CURR_H_ASST", SqlNull(FEE_CURR_H_ASST)),
						new SqlParameter("FEE_CURR_ADD_ON_CD1", SqlNull(FEE_CURR_ADD_ON_CD1)),
						new SqlParameter("FEE_CURR_ADD_ON_CD2", SqlNull(FEE_CURR_ADD_ON_CD2)),
						new SqlParameter("FEE_CURR_ADD_ON_CD3", SqlNull(FEE_CURR_ADD_ON_CD3)),
						new SqlParameter("FEE_CURR_ADD_ON_CD4", SqlNull(FEE_CURR_ADD_ON_CD4)),
						new SqlParameter("FEE_CURR_ADD_ON_CD5", SqlNull(FEE_CURR_ADD_ON_CD5)),
						new SqlParameter("FEE_CURR_ADD_ON_CD6", SqlNull(FEE_CURR_ADD_ON_CD6)),
						new SqlParameter("FEE_CURR_ADD_ON_CD7", SqlNull(FEE_CURR_ADD_ON_CD7)),
						new SqlParameter("FEE_CURR_ADD_ON_CD8", SqlNull(FEE_CURR_ADD_ON_CD8)),
						new SqlParameter("FEE_CURR_ADD_ON_CD9", SqlNull(FEE_CURR_ADD_ON_CD9)),
						new SqlParameter("FEE_CURR_ADD_ON_CD10", SqlNull(FEE_CURR_ADD_ON_CD10)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED1", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED1)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED2", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED2)),
						new SqlParameter("FEE_CURR_OMA_IND_CARD_REQUIRED3", SqlNull(FEE_CURR_OMA_IND_CARD_REQUIRED3)),
						new SqlParameter("FEE_CURR_PAGE_ALPHA", SqlNull(FEE_CURR_PAGE_ALPHA)),
						new SqlParameter("FEE_CURR_PAGE_NUMERIC", SqlNull(FEE_CURR_PAGE_NUMERIC)),
						new SqlParameter("FEE_CURR_ADD_ON_PERC_OR_FLAT_IND", SqlNull(FEE_CURR_ADD_ON_PERC_OR_FLAT_IND)),
						new SqlParameter("FEE_PREV_A_FEE_1", SqlNull(FEE_PREV_A_FEE_1)),
						new SqlParameter("FEE_PREV_H_FEE_1", SqlNull(FEE_PREV_H_FEE_1)),
						new SqlParameter("FEE_PREV_A_FEE_2", SqlNull(FEE_PREV_A_FEE_2)),
						new SqlParameter("FEE_PREV_H_FEE_2", SqlNull(FEE_PREV_H_FEE_2)),
						new SqlParameter("FEE_PREV_A_MIN", SqlNull(FEE_PREV_A_MIN)),
						new SqlParameter("FEE_PREV_H_MIN", SqlNull(FEE_PREV_H_MIN)),
						new SqlParameter("FEE_PREV_A_MAX", SqlNull(FEE_PREV_A_MAX)),
						new SqlParameter("FEE_PREV_H_MAX", SqlNull(FEE_PREV_H_MAX)),
						new SqlParameter("FEE_PREV_A_ANAE", SqlNull(FEE_PREV_A_ANAE)),
						new SqlParameter("FEE_PREV_H_ANAE", SqlNull(FEE_PREV_H_ANAE)),
						new SqlParameter("FEE_PREV_A_ASST", SqlNull(FEE_PREV_A_ASST)),
						new SqlParameter("FEE_PREV_H_ASST", SqlNull(FEE_PREV_H_ASST)),
						new SqlParameter("FEE_PREV_ADD_ON_CD1", SqlNull(FEE_PREV_ADD_ON_CD1)),
						new SqlParameter("FEE_PREV_ADD_ON_CD2", SqlNull(FEE_PREV_ADD_ON_CD2)),
						new SqlParameter("FEE_PREV_ADD_ON_CD3", SqlNull(FEE_PREV_ADD_ON_CD3)),
						new SqlParameter("FEE_PREV_ADD_ON_CD4", SqlNull(FEE_PREV_ADD_ON_CD4)),
						new SqlParameter("FEE_PREV_ADD_ON_CD5", SqlNull(FEE_PREV_ADD_ON_CD5)),
						new SqlParameter("FEE_PREV_ADD_ON_CD6", SqlNull(FEE_PREV_ADD_ON_CD6)),
						new SqlParameter("FEE_PREV_ADD_ON_CD7", SqlNull(FEE_PREV_ADD_ON_CD7)),
						new SqlParameter("FEE_PREV_ADD_ON_CD8", SqlNull(FEE_PREV_ADD_ON_CD8)),
						new SqlParameter("FEE_PREV_ADD_ON_CD9", SqlNull(FEE_PREV_ADD_ON_CD9)),
						new SqlParameter("FEE_PREV_ADD_ON_CD10", SqlNull(FEE_PREV_ADD_ON_CD10)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED1", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED1)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED2", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED2)),
						new SqlParameter("FEE_PREV_OMA_IND_CARD_REQUIRED3", SqlNull(FEE_PREV_OMA_IND_CARD_REQUIRED3)),
						new SqlParameter("FEE_PREV_PAGE_ALPHA", SqlNull(FEE_PREV_PAGE_ALPHA)),
						new SqlParameter("FEE_PREV_PAGE_NUMERIC", SqlNull(FEE_PREV_PAGE_NUMERIC)),
						new SqlParameter("FEE_PREV_ADD_ON_PERC_OR_FLAT_IND", SqlNull(FEE_PREV_ADD_ON_PERC_OR_FLAT_IND)),
						new SqlParameter("FEE_ICC_SEC", SqlNull(FEE_ICC_SEC)),
						new SqlParameter("FEE_ICC_CAT", SqlNull(FEE_ICC_CAT)),
						new SqlParameter("FEE_ICC_GRP", SqlNull(FEE_ICC_GRP)),
						new SqlParameter("FEE_ICC_REDUC_IND", SqlNull(FEE_ICC_REDUC_IND)),
						new SqlParameter("FEE_DIAG_IND", SqlNull(FEE_DIAG_IND)),
						new SqlParameter("FEE_PHY_IND", SqlNull(FEE_PHY_IND)),
						new SqlParameter("FEE_TECH_IND", SqlNull(FEE_TECH_IND)),
						new SqlParameter("FEE_HOSP_NBR_IND", SqlNull(FEE_HOSP_NBR_IND)),
						new SqlParameter("FEE_I_O_IND", SqlNull(FEE_I_O_IND)),
						new SqlParameter("FEE_ADMIT_IND", SqlNull(FEE_ADMIT_IND)),
						new SqlParameter("FEE_SPEC_FR", SqlNull(FEE_SPEC_FR)),
						new SqlParameter("FEE_SPEC_TO", SqlNull(FEE_SPEC_TO)),
						new SqlParameter("FEEGLOBALADDONCDEXCLUSIONFLAG", SqlNull(FEEGLOBALADDONCDEXCLUSIONFLAG)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F040_OMA_FEE_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						FEE_OMA_CD_LTR1 = Reader["FEE_OMA_CD_LTR1"].ToString();
						FILLER_NUMERIC = Reader["FILLER_NUMERIC"].ToString();
						FEE_SPECIAL_M_SUFFIX_IND = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString();
						FEE_DATE_YY = ConvertDEC(Reader["FEE_DATE_YY"]);
						FEE_DATE_MM = ConvertDEC(Reader["FEE_DATE_MM"]);
						FEE_DATE_DD = ConvertDEC(Reader["FEE_DATE_DD"]);
						FEE_ACTIVE_FOR_ENTRY = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString();
						FEE_DESC = Reader["FEE_DESC"].ToString();
						FEE_CURR_A_FEE_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]);
						FEE_CURR_H_FEE_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]);
						FEE_CURR_A_FEE_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]);
						FEE_CURR_H_FEE_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]);
						FEE_CURR_A_MIN = ConvertDEC(Reader["FEE_CURR_A_MIN"]);
						FEE_CURR_H_MIN = ConvertDEC(Reader["FEE_CURR_H_MIN"]);
						FEE_CURR_A_MAX = ConvertDEC(Reader["FEE_CURR_A_MAX"]);
						FEE_CURR_H_MAX = ConvertDEC(Reader["FEE_CURR_H_MAX"]);
						FEE_CURR_A_ANAE = ConvertDEC(Reader["FEE_CURR_A_ANAE"]);
						FEE_CURR_H_ANAE = ConvertDEC(Reader["FEE_CURR_H_ANAE"]);
						FEE_CURR_A_ASST = ConvertDEC(Reader["FEE_CURR_A_ASST"]);
						FEE_CURR_H_ASST = ConvertDEC(Reader["FEE_CURR_H_ASST"]);
						FEE_CURR_ADD_ON_CD1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString();
						FEE_CURR_ADD_ON_CD2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString();
						FEE_CURR_ADD_ON_CD3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString();
						FEE_CURR_ADD_ON_CD4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString();
						FEE_CURR_ADD_ON_CD5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString();
						FEE_CURR_ADD_ON_CD6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString();
						FEE_CURR_ADD_ON_CD7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString();
						FEE_CURR_ADD_ON_CD8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString();
						FEE_CURR_ADD_ON_CD9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString();
						FEE_CURR_ADD_ON_CD10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString();
						FEE_CURR_OMA_IND_CARD_REQUIRED3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString();
						FEE_CURR_PAGE_ALPHA = Reader["FEE_CURR_PAGE_ALPHA"].ToString();
						FEE_CURR_PAGE_NUMERIC = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]);
						FEE_CURR_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						FEE_PREV_A_FEE_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]);
						FEE_PREV_H_FEE_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]);
						FEE_PREV_A_FEE_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]);
						FEE_PREV_H_FEE_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]);
						FEE_PREV_A_MIN = ConvertDEC(Reader["FEE_PREV_A_MIN"]);
						FEE_PREV_H_MIN = ConvertDEC(Reader["FEE_PREV_H_MIN"]);
						FEE_PREV_A_MAX = ConvertDEC(Reader["FEE_PREV_A_MAX"]);
						FEE_PREV_H_MAX = ConvertDEC(Reader["FEE_PREV_H_MAX"]);
						FEE_PREV_A_ANAE = ConvertDEC(Reader["FEE_PREV_A_ANAE"]);
						FEE_PREV_H_ANAE = ConvertDEC(Reader["FEE_PREV_H_ANAE"]);
						FEE_PREV_A_ASST = ConvertDEC(Reader["FEE_PREV_A_ASST"]);
						FEE_PREV_H_ASST = ConvertDEC(Reader["FEE_PREV_H_ASST"]);
						FEE_PREV_ADD_ON_CD1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString();
						FEE_PREV_ADD_ON_CD2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString();
						FEE_PREV_ADD_ON_CD3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString();
						FEE_PREV_ADD_ON_CD4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString();
						FEE_PREV_ADD_ON_CD5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString();
						FEE_PREV_ADD_ON_CD6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString();
						FEE_PREV_ADD_ON_CD7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString();
						FEE_PREV_ADD_ON_CD8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString();
						FEE_PREV_ADD_ON_CD9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString();
						FEE_PREV_ADD_ON_CD10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString();
						FEE_PREV_OMA_IND_CARD_REQUIRED3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString();
						FEE_PREV_PAGE_ALPHA = Reader["FEE_PREV_PAGE_ALPHA"].ToString();
						FEE_PREV_PAGE_NUMERIC = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]);
						FEE_PREV_ADD_ON_PERC_OR_FLAT_IND = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						FEE_ICC_SEC = Reader["FEE_ICC_SEC"].ToString();
						FEE_ICC_CAT = ConvertDEC(Reader["FEE_ICC_CAT"]);
						FEE_ICC_GRP = ConvertDEC(Reader["FEE_ICC_GRP"]);
						FEE_ICC_REDUC_IND = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]);
						FEE_DIAG_IND = Reader["FEE_DIAG_IND"].ToString();
						FEE_PHY_IND = Reader["FEE_PHY_IND"].ToString();
						FEE_TECH_IND = Reader["FEE_TECH_IND"].ToString();
						FEE_HOSP_NBR_IND = Reader["FEE_HOSP_NBR_IND"].ToString();
						FEE_I_O_IND = Reader["FEE_I_O_IND"].ToString();
						FEE_ADMIT_IND = Reader["FEE_ADMIT_IND"].ToString();
						FEE_SPEC_FR = ConvertDEC(Reader["FEE_SPEC_FR"]);
						FEE_SPEC_TO = ConvertDEC(Reader["FEE_SPEC_TO"]);
						FEEGLOBALADDONCDEXCLUSIONFLAG = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalFee_oma_cd_ltr1 = Reader["FEE_OMA_CD_LTR1"].ToString();
						_originalFiller_numeric = Reader["FILLER_NUMERIC"].ToString();
						_originalFee_special_m_suffix_ind = Reader["FEE_SPECIAL_M_SUFFIX_IND"].ToString();
						_originalFee_date_yy = ConvertDEC(Reader["FEE_DATE_YY"]);
						_originalFee_date_mm = ConvertDEC(Reader["FEE_DATE_MM"]);
						_originalFee_date_dd = ConvertDEC(Reader["FEE_DATE_DD"]);
						_originalFee_active_for_entry = Reader["FEE_ACTIVE_FOR_ENTRY"].ToString();
						_originalFee_desc = Reader["FEE_DESC"].ToString();
						_originalFee_curr_a_fee_1 = ConvertDEC(Reader["FEE_CURR_A_FEE_1"]);
						_originalFee_curr_h_fee_1 = ConvertDEC(Reader["FEE_CURR_H_FEE_1"]);
						_originalFee_curr_a_fee_2 = ConvertDEC(Reader["FEE_CURR_A_FEE_2"]);
						_originalFee_curr_h_fee_2 = ConvertDEC(Reader["FEE_CURR_H_FEE_2"]);
						_originalFee_curr_a_min = ConvertDEC(Reader["FEE_CURR_A_MIN"]);
						_originalFee_curr_h_min = ConvertDEC(Reader["FEE_CURR_H_MIN"]);
						_originalFee_curr_a_max = ConvertDEC(Reader["FEE_CURR_A_MAX"]);
						_originalFee_curr_h_max = ConvertDEC(Reader["FEE_CURR_H_MAX"]);
						_originalFee_curr_a_anae = ConvertDEC(Reader["FEE_CURR_A_ANAE"]);
						_originalFee_curr_h_anae = ConvertDEC(Reader["FEE_CURR_H_ANAE"]);
						_originalFee_curr_a_asst = ConvertDEC(Reader["FEE_CURR_A_ASST"]);
						_originalFee_curr_h_asst = ConvertDEC(Reader["FEE_CURR_H_ASST"]);
						_originalFee_curr_add_on_cd1 = Reader["FEE_CURR_ADD_ON_CD1"].ToString();
						_originalFee_curr_add_on_cd2 = Reader["FEE_CURR_ADD_ON_CD2"].ToString();
						_originalFee_curr_add_on_cd3 = Reader["FEE_CURR_ADD_ON_CD3"].ToString();
						_originalFee_curr_add_on_cd4 = Reader["FEE_CURR_ADD_ON_CD4"].ToString();
						_originalFee_curr_add_on_cd5 = Reader["FEE_CURR_ADD_ON_CD5"].ToString();
						_originalFee_curr_add_on_cd6 = Reader["FEE_CURR_ADD_ON_CD6"].ToString();
						_originalFee_curr_add_on_cd7 = Reader["FEE_CURR_ADD_ON_CD7"].ToString();
						_originalFee_curr_add_on_cd8 = Reader["FEE_CURR_ADD_ON_CD8"].ToString();
						_originalFee_curr_add_on_cd9 = Reader["FEE_CURR_ADD_ON_CD9"].ToString();
						_originalFee_curr_add_on_cd10 = Reader["FEE_CURR_ADD_ON_CD10"].ToString();
						_originalFee_curr_oma_ind_card_required1 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED1"].ToString();
						_originalFee_curr_oma_ind_card_required2 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED2"].ToString();
						_originalFee_curr_oma_ind_card_required3 = Reader["FEE_CURR_OMA_IND_CARD_REQUIRED3"].ToString();
						_originalFee_curr_page_alpha = Reader["FEE_CURR_PAGE_ALPHA"].ToString();
						_originalFee_curr_page_numeric = ConvertDEC(Reader["FEE_CURR_PAGE_NUMERIC"]);
						_originalFee_curr_add_on_perc_or_flat_ind = Reader["FEE_CURR_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						_originalFee_prev_a_fee_1 = ConvertDEC(Reader["FEE_PREV_A_FEE_1"]);
						_originalFee_prev_h_fee_1 = ConvertDEC(Reader["FEE_PREV_H_FEE_1"]);
						_originalFee_prev_a_fee_2 = ConvertDEC(Reader["FEE_PREV_A_FEE_2"]);
						_originalFee_prev_h_fee_2 = ConvertDEC(Reader["FEE_PREV_H_FEE_2"]);
						_originalFee_prev_a_min = ConvertDEC(Reader["FEE_PREV_A_MIN"]);
						_originalFee_prev_h_min = ConvertDEC(Reader["FEE_PREV_H_MIN"]);
						_originalFee_prev_a_max = ConvertDEC(Reader["FEE_PREV_A_MAX"]);
						_originalFee_prev_h_max = ConvertDEC(Reader["FEE_PREV_H_MAX"]);
						_originalFee_prev_a_anae = ConvertDEC(Reader["FEE_PREV_A_ANAE"]);
						_originalFee_prev_h_anae = ConvertDEC(Reader["FEE_PREV_H_ANAE"]);
						_originalFee_prev_a_asst = ConvertDEC(Reader["FEE_PREV_A_ASST"]);
						_originalFee_prev_h_asst = ConvertDEC(Reader["FEE_PREV_H_ASST"]);
						_originalFee_prev_add_on_cd1 = Reader["FEE_PREV_ADD_ON_CD1"].ToString();
						_originalFee_prev_add_on_cd2 = Reader["FEE_PREV_ADD_ON_CD2"].ToString();
						_originalFee_prev_add_on_cd3 = Reader["FEE_PREV_ADD_ON_CD3"].ToString();
						_originalFee_prev_add_on_cd4 = Reader["FEE_PREV_ADD_ON_CD4"].ToString();
						_originalFee_prev_add_on_cd5 = Reader["FEE_PREV_ADD_ON_CD5"].ToString();
						_originalFee_prev_add_on_cd6 = Reader["FEE_PREV_ADD_ON_CD6"].ToString();
						_originalFee_prev_add_on_cd7 = Reader["FEE_PREV_ADD_ON_CD7"].ToString();
						_originalFee_prev_add_on_cd8 = Reader["FEE_PREV_ADD_ON_CD8"].ToString();
						_originalFee_prev_add_on_cd9 = Reader["FEE_PREV_ADD_ON_CD9"].ToString();
						_originalFee_prev_add_on_cd10 = Reader["FEE_PREV_ADD_ON_CD10"].ToString();
						_originalFee_prev_oma_ind_card_required1 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED1"].ToString();
						_originalFee_prev_oma_ind_card_required2 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED2"].ToString();
						_originalFee_prev_oma_ind_card_required3 = Reader["FEE_PREV_OMA_IND_CARD_REQUIRED3"].ToString();
						_originalFee_prev_page_alpha = Reader["FEE_PREV_PAGE_ALPHA"].ToString();
						_originalFee_prev_page_numeric = ConvertDEC(Reader["FEE_PREV_PAGE_NUMERIC"]);
						_originalFee_prev_add_on_perc_or_flat_ind = Reader["FEE_PREV_ADD_ON_PERC_OR_FLAT_IND"].ToString();
						_originalFee_icc_sec = Reader["FEE_ICC_SEC"].ToString();
						_originalFee_icc_cat = ConvertDEC(Reader["FEE_ICC_CAT"]);
						_originalFee_icc_grp = ConvertDEC(Reader["FEE_ICC_GRP"]);
						_originalFee_icc_reduc_ind = ConvertDEC(Reader["FEE_ICC_REDUC_IND"]);
						_originalFee_diag_ind = Reader["FEE_DIAG_IND"].ToString();
						_originalFee_phy_ind = Reader["FEE_PHY_IND"].ToString();
						_originalFee_tech_ind = Reader["FEE_TECH_IND"].ToString();
						_originalFee_hosp_nbr_ind = Reader["FEE_HOSP_NBR_IND"].ToString();
						_originalFee_i_o_ind = Reader["FEE_I_O_IND"].ToString();
						_originalFee_admit_ind = Reader["FEE_ADMIT_IND"].ToString();
						_originalFee_spec_fr = ConvertDEC(Reader["FEE_SPEC_FR"]);
						_originalFee_spec_to = ConvertDEC(Reader["FEE_SPEC_TO"]);
						_originalFeeglobaladdoncdexclusionflag = Reader["FEEGLOBALADDONCDEXCLUSIONFLAG"].ToString();
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