using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F002_CLAIMS_MSTR_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection( Guid? rowid,
															string clmdtl_batch_nbr,
															decimal? clmdtl_claim_nbrmin,
															decimal? clmdtl_claim_nbrmax,
															string clmdtl_oma_cd,
															string clmdtl_oma_suff,
															decimal? clmdtl_adj_nbrmin,
															decimal? clmdtl_adj_nbrmax,
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
															//decimal? clmdtl_sv_nbr1min,
															//decimal? clmdtl_sv_nbr1max,
															//decimal? clmdtl_sv_nbr2min,
															//decimal? clmdtl_sv_nbr2max,
															//decimal? clmdtl_sv_nbr3min,
															//decimal? clmdtl_sv_nbr3max,
															//decimal? clmdtl_sv_day1min,
															//decimal? clmdtl_sv_day1max,
															//decimal? clmdtl_sv_day2min,
															//decimal? clmdtl_sv_day2max,
															//decimal? clmdtl_sv_day3min,
															//decimal? clmdtl_sv_day3max,
															//decimal? clmdtl_sv_nbr_1min,
															//decimal? clmdtl_sv_nbr_1max,
															//decimal? clmdtl_sv_day_1min,
															//decimal? clmdtl_sv_day_1max,
															//decimal? clmdtl_sv_nbr_2min,
															//decimal? clmdtl_sv_nbr_2max,
															//decimal? clmdtl_sv_day_2min,
															//decimal? clmdtl_sv_day_2max,
															//decimal? clmdtl_sv_nbr_3min,
															//decimal? clmdtl_sv_nbr_3max,
															//decimal? clmdtl_sv_day_3min,
															//decimal? clmdtl_sv_day_3max,
                                                            string clmdtl_consec_dates_r,
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
//					new SqlParameter("minCLMDTL_SV_NBR1",clmdtl_sv_nbr1min),
//					new SqlParameter("maxCLMDTL_SV_NBR1",clmdtl_sv_nbr1max),
//					new SqlParameter("minCLMDTL_SV_NBR2",clmdtl_sv_nbr2min),
//					new SqlParameter("maxCLMDTL_SV_NBR2",clmdtl_sv_nbr2max),
//					new SqlParameter("minCLMDTL_SV_NBR3",clmdtl_sv_nbr3min),
//					new SqlParameter("maxCLMDTL_SV_NBR3",clmdtl_sv_nbr3max),
//					new SqlParameter("minCLMDTL_SV_DAY1",clmdtl_sv_day1min),
//					new SqlParameter("maxCLMDTL_SV_DAY1",clmdtl_sv_day1max),
//					new SqlParameter("minCLMDTL_SV_DAY2",clmdtl_sv_day2min),
//					new SqlParameter("maxCLMDTL_SV_DAY2",clmdtl_sv_day2max),
//					new SqlParameter("minCLMDTL_SV_DAY3",clmdtl_sv_day3min),
//					new SqlParameter("maxCLMDTL_SV_DAY3",clmdtl_sv_day3max),
//					new SqlParameter("minCLMDTL_SV_NBR_1",clmdtl_sv_nbr_1min),
//					new SqlParameter("maxCLMDTL_SV_NBR_1",clmdtl_sv_nbr_1max),
//					new SqlParameter("minCLMDTL_SV_DAY_1",clmdtl_sv_day_1min),
//					new SqlParameter("maxCLMDTL_SV_DAY_1",clmdtl_sv_day_1max),
//					new SqlParameter("minCLMDTL_SV_NBR_2",clmdtl_sv_nbr_2min),
//					new SqlParameter("maxCLMDTL_SV_NBR_2",clmdtl_sv_nbr_2max),
//					new SqlParameter("minCLMDTL_SV_DAY_2",clmdtl_sv_day_2min),
//					new SqlParameter("maxCLMDTL_SV_DAY_2",clmdtl_sv_day_2max),
//					new SqlParameter("minCLMDTL_SV_NBR_3",clmdtl_sv_nbr_3min),
//					new SqlParameter("maxCLMDTL_SV_NBR_3",clmdtl_sv_nbr_3max),
//					new SqlParameter("minCLMDTL_SV_DAY_3",clmdtl_sv_day_3min),
//					new SqlParameter("maxCLMDTL_SV_DAY_3",clmdtl_sv_day_3max),
                    new SqlParameter("CLMDTL_CONSEC_DATES_R",clmdtl_consec_dates_r),
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
                Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F002_CLAIMS_MSTR_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_Search]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					//CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					//CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					//CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					//CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					//CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					//CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					//CLMDTL_SV_NBR_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]),
					//CLMDTL_SV_DAY_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]),
					//CLMDTL_SV_NBR_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]),
					//CLMDTL_SV_DAY_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]),
					//CLMDTL_SV_NBR_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]),
					//CLMDTL_SV_DAY_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]),
                    CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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
					_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					//_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					//_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					//_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					//_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					//_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					//_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					//_originalClmdtl_sv_nbr_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]),
					//_originalClmdtl_sv_day_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]),
					//_originalClmdtl_sv_nbr_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]),
					//_originalClmdtl_sv_day_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]),
					//_originalClmdtl_sv_nbr_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]),
					//_originalClmdtl_sv_day_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]),
                    _originalClmdtl_consec_dates_r = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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

        public F002_CLAIMS_MSTR_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection(ObservableCollection<F002_CLAIMS_MSTR_DTL>
                                                               f002ClaimsMstrDtl = null)
        {
            if (IsSameSearch() && f002ClaimsMstrDtl != null)
            {
                return f002ClaimsMstrDtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F002_CLAIMS_MSTR_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_BATCH_NBR",WhereClmdtl_batch_nbr),
					new SqlParameter("CLMDTL_CLAIM_NBR",WhereClmdtl_claim_nbr),
					new SqlParameter("CLMDTL_OMA_CD",WhereClmdtl_oma_cd),
					new SqlParameter("CLMDTL_OMA_SUFF",WhereClmdtl_oma_suff),
					new SqlParameter("CLMDTL_ADJ_NBR",WhereClmdtl_adj_nbr),
					new SqlParameter("CLMDTL_REV_GROUP_CD",WhereClmdtl_rev_group_cd),
					new SqlParameter("CLMDTL_AGENT_CD",WhereClmdtl_agent_cd),
					new SqlParameter("CLMDTL_ADJ_CD",WhereClmdtl_adj_cd),
					new SqlParameter("CLMDTL_NBR_SERV",WhereClmdtl_nbr_serv),
					new SqlParameter("CLMDTL_SV_YY",WhereClmdtl_sv_yy),
					new SqlParameter("CLMDTL_SV_MM",WhereClmdtl_sv_mm),
					new SqlParameter("CLMDTL_SV_DD",WhereClmdtl_sv_dd),
					//new SqlParameter("CLMDTL_SV_NBR1",WhereClmdtl_sv_nbr1),
					//new SqlParameter("CLMDTL_SV_NBR2",WhereClmdtl_sv_nbr2),
					//new SqlParameter("CLMDTL_SV_NBR3",WhereClmdtl_sv_nbr3),
					//new SqlParameter("CLMDTL_SV_DAY1",WhereClmdtl_sv_day1),
					//new SqlParameter("CLMDTL_SV_DAY2",WhereClmdtl_sv_day2),
					//new SqlParameter("CLMDTL_SV_DAY3",WhereClmdtl_sv_day3),
					//new SqlParameter("CLMDTL_SV_NBR_1",WhereClmdtl_sv_nbr_1),
					//new SqlParameter("CLMDTL_SV_DAY_1",WhereClmdtl_sv_day_1),
					//new SqlParameter("CLMDTL_SV_NBR_2",WhereClmdtl_sv_nbr_2),
					//new SqlParameter("CLMDTL_SV_DAY_2",WhereClmdtl_sv_day_2),
					//new SqlParameter("CLMDTL_SV_NBR_3",WhereClmdtl_sv_nbr_3),
					//new SqlParameter("CLMDTL_SV_DAY_3",WhereClmdtl_sv_day_3),
                    new SqlParameter("CLMDTL_CONSEC_DATES_R",WhereClmdtl_consec_dates_r),
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

			Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_Match]", parameters);
            var collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
					CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
					CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
					CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
					CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
					CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					//CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					//CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					//CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					//CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					//CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					//CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					//CLMDTL_SV_NBR_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]),
					//CLMDTL_SV_DAY_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]),
					//CLMDTL_SV_NBR_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]),
					//CLMDTL_SV_DAY_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]),
					//CLMDTL_SV_NBR_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]),
					//CLMDTL_SV_DAY_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]),
                    CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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
					_whereClmdtl_rev_group_cd = WhereClmdtl_rev_group_cd,
					_whereClmdtl_agent_cd = WhereClmdtl_agent_cd,
					_whereClmdtl_adj_cd = WhereClmdtl_adj_cd,
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv,
					_whereClmdtl_sv_yy = WhereClmdtl_sv_yy,
					_whereClmdtl_sv_mm = WhereClmdtl_sv_mm,
					_whereClmdtl_sv_dd = WhereClmdtl_sv_dd,
					//_whereClmdtl_sv_nbr1 = WhereClmdtl_sv_nbr1,
					//_whereClmdtl_sv_nbr2 = WhereClmdtl_sv_nbr2,
					//_whereClmdtl_sv_nbr3 = WhereClmdtl_sv_nbr3,
					//_whereClmdtl_sv_day1 = WhereClmdtl_sv_day1,
					//_whereClmdtl_sv_day2 = WhereClmdtl_sv_day2,
					//_whereClmdtl_sv_day3 = WhereClmdtl_sv_day3,
					//_whereClmdtl_sv_nbr_1 = WhereClmdtl_sv_nbr_1,
					//_whereClmdtl_sv_day_1 = WhereClmdtl_sv_day_1,
					//_whereClmdtl_sv_nbr_2 = WhereClmdtl_sv_nbr_2,
					//_whereClmdtl_sv_day_2 = WhereClmdtl_sv_day_2,
					//_whereClmdtl_sv_nbr_3 = WhereClmdtl_sv_nbr_3,
					//_whereClmdtl_sv_day_3 = WhereClmdtl_sv_day_3,
                    _whereClmdtl_consec_dates_r = WhereClmdtl_consec_dates_r,
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
					_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
					_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
					_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]),
					_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]),
					_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]),
					//_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					//_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					//_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					//_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					//_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					//_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					//_originalClmdtl_sv_nbr_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]),
					//_originalClmdtl_sv_day_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]),
					//_originalClmdtl_sv_nbr_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]),
					//_originalClmdtl_sv_day_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]),
					//_originalClmdtl_sv_nbr_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]),
					//_originalClmdtl_sv_day_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]),
                    _originalClmdtl_consec_dates_r = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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
					_whereClmdtl_rev_group_cd = WhereClmdtl_rev_group_cd;
					_whereClmdtl_agent_cd = WhereClmdtl_agent_cd;
					_whereClmdtl_adj_cd = WhereClmdtl_adj_cd;
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv;
					_whereClmdtl_sv_yy = WhereClmdtl_sv_yy;
					_whereClmdtl_sv_mm = WhereClmdtl_sv_mm;
					_whereClmdtl_sv_dd = WhereClmdtl_sv_dd;
            //_whereClmdtl_sv_nbr1 = WhereClmdtl_sv_nbr1;
            //_whereClmdtl_sv_nbr2 = WhereClmdtl_sv_nbr2;
            //_whereClmdtl_sv_nbr3 = WhereClmdtl_sv_nbr3;
            //_whereClmdtl_sv_day1 = WhereClmdtl_sv_day1;
            //_whereClmdtl_sv_day2 = WhereClmdtl_sv_day2;
            //_whereClmdtl_sv_day3 = WhereClmdtl_sv_day3;
            //_whereClmdtl_sv_nbr_1 = WhereClmdtl_sv_nbr_1;
            //_whereClmdtl_sv_day_1 = WhereClmdtl_sv_day_1;
            //_whereClmdtl_sv_nbr_2 = WhereClmdtl_sv_nbr_2;
            //_whereClmdtl_sv_day_2 = WhereClmdtl_sv_day_2;
            //_whereClmdtl_sv_nbr_3 = WhereClmdtl_sv_nbr_3;
            //_whereClmdtl_sv_day_3 = WhereClmdtl_sv_day_3;
            _whereClmdtl_consec_dates_r = WhereClmdtl_consec_dates_r;
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
				&& WhereClmdtl_rev_group_cd == null 
				&& WhereClmdtl_agent_cd == null 
				&& WhereClmdtl_adj_cd == null 
				&& WhereClmdtl_nbr_serv == null 
				&& WhereClmdtl_sv_yy == null 
				&& WhereClmdtl_sv_mm == null 
				&& WhereClmdtl_sv_dd == null 
				//&& WhereClmdtl_sv_nbr1 == null 
				//&& WhereClmdtl_sv_nbr2 == null 
				//&& WhereClmdtl_sv_nbr3 == null 
				//&& WhereClmdtl_sv_day1 == null 
				//&& WhereClmdtl_sv_day2 == null 
				//&& WhereClmdtl_sv_day3 == null 
				//&& WhereClmdtl_sv_nbr_1 == null 
				//&& WhereClmdtl_sv_day_1 == null 
				//&& WhereClmdtl_sv_nbr_2 == null 
				//&& WhereClmdtl_sv_day_2 == null 
				//&& WhereClmdtl_sv_nbr_3 == null 
				//&& WhereClmdtl_sv_day_3 == null 
                && WhereClmdtl_consec_dates_r == null
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
				&& WhereClmdtl_rev_group_cd ==  _whereClmdtl_rev_group_cd
				&& WhereClmdtl_agent_cd ==  _whereClmdtl_agent_cd
				&& WhereClmdtl_adj_cd ==  _whereClmdtl_adj_cd
				&& WhereClmdtl_nbr_serv ==  _whereClmdtl_nbr_serv
				&& WhereClmdtl_sv_yy ==  _whereClmdtl_sv_yy
				&& WhereClmdtl_sv_mm ==  _whereClmdtl_sv_mm
				&& WhereClmdtl_sv_dd ==  _whereClmdtl_sv_dd
				//&& WhereClmdtl_sv_nbr1 ==  _whereClmdtl_sv_nbr1
				//&& WhereClmdtl_sv_nbr2 ==  _whereClmdtl_sv_nbr2
				//&& WhereClmdtl_sv_nbr3 ==  _whereClmdtl_sv_nbr3
				//&& WhereClmdtl_sv_day1 ==  _whereClmdtl_sv_day1
				//&& WhereClmdtl_sv_day2 ==  _whereClmdtl_sv_day2
				//&& WhereClmdtl_sv_day3 ==  _whereClmdtl_sv_day3
				//&& WhereClmdtl_sv_nbr_1 ==  _whereClmdtl_sv_nbr_1
				//&& WhereClmdtl_sv_day_1 ==  _whereClmdtl_sv_day_1
				//&& WhereClmdtl_sv_nbr_2 ==  _whereClmdtl_sv_nbr_2
				//&& WhereClmdtl_sv_day_2 ==  _whereClmdtl_sv_day_2
				//&& WhereClmdtl_sv_nbr_3 ==  _whereClmdtl_sv_nbr_3
				//&& WhereClmdtl_sv_day_3 ==  _whereClmdtl_sv_day_3
                && WhereClmdtl_consec_dates_r == _whereClmdtl_consec_dates_r
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
			WhereClmdtl_rev_group_cd = null; 
			WhereClmdtl_agent_cd = null; 
			WhereClmdtl_adj_cd = null; 
			WhereClmdtl_nbr_serv = null; 
			WhereClmdtl_sv_yy = null; 
			WhereClmdtl_sv_mm = null; 
			WhereClmdtl_sv_dd = null;
            //WhereClmdtl_sv_nbr1 = null; 
            //WhereClmdtl_sv_nbr2 = null; 
            //WhereClmdtl_sv_nbr3 = null; 
            //WhereClmdtl_sv_day1 = null; 
            //WhereClmdtl_sv_day2 = null; 
            //WhereClmdtl_sv_day3 = null; 
            //WhereClmdtl_sv_nbr_1 = null; 
            //WhereClmdtl_sv_day_1 = null; 
            //WhereClmdtl_sv_nbr_2 = null; 
            //WhereClmdtl_sv_day_2 = null; 
            //WhereClmdtl_sv_nbr_3 = null; 
            //WhereClmdtl_sv_day_3 = null; 
            WhereClmdtl_consec_dates_r = null;
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

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_DTL_For_Clinic_NBR(ref bool isRetrieveRecord, ObservableCollection<F002_CLAIMS_MSTR_DTL> f002_claims_mstr_dtl = null)
        {
            if (f002_claims_mstr_dtl != null)
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = f002_claims_mstr_dtl.FirstOrDefault();
                if (objF002_CLAIMS_MSTR_DTL != null)
                {
                    _whereKey_clm_type = objF002_CLAIMS_MSTR_DTL._KEY_CLM_TYPE; // KEY_CLM_TYPE;
                    _whereClmdtl_batch_nbr = objF002_CLAIMS_MSTR_DTL._CLMDTL_BATCH_NBR.PadRight(8, ' ').Substring(0, 2); //CLMDTL_BATCH_NBR;
                    _whereClmdtl_claim_nbr = objF002_CLAIMS_MSTR_DTL._CLMDTL_CLAIM_NBR; //CLMDTL_CLAIM_NBR;
                    _whereClmdtl_oma_cd = objF002_CLAIMS_MSTR_DTL._CLMDTL_OMA_CD; //CLMDTL_OMA_CD;
                    _whereClmdtl_oma_suff = objF002_CLAIMS_MSTR_DTL._CLMDTL_OMA_SUFF; //CLMDTL_OMA_SUFF;
                    _whereClmdtl_adj_nbr = objF002_CLAIMS_MSTR_DTL._CLMDTL_ADJ_NBR; //CLMDTL_ADJ_NBR;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f002_claims_mstr_dtl;
                    }
                }
            }

            var collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();
            StringBuilder sql = null;
            isRetrieveRecord = true;
            sql = new StringBuilder();

            sql.Append("SELECT ")
                .Append(" ROWID as 'ROWID'")
                .Append(" ,[CLMDTL_BATCH_NBR]")
                .Append(" ,[CLMDTL_CLAIM_NBR]")
                .Append(" ,[CLMDTL_OMA_CD]")
                .Append(" ,[CLMDTL_OMA_SUFF]")
                .Append(" ,[CLMDTL_ADJ_NBR]")
                .Append(" ,[CLMDTL_REV_GROUP_CD]")
                .Append(" ,[CLMDTL_AGENT_CD]")
                .Append(" ,[CLMDTL_ADJ_CD]")
                .Append(" ,[CLMDTL_NBR_SERV]")
                .Append(" ,[CLMDTL_SV_YY]")
                .Append(" ,[CLMDTL_SV_MM]")
                .Append(" ,[CLMDTL_SV_DD]")
                .Append(" ,[CLMDTL_CONSEC_DATES_R]")
                .Append(" ,[CLMDTL_AMT_TECH_BILLED]")
                .Append(" ,[CLMDTL_FEE_OMA]")
                .Append(" ,[CLMDTL_FEE_OHIP]")
                .Append(" ,[CLMDTL_DATE_PERIOD_END]")
                .Append(" ,[CLMDTL_CYCLE_NBR]")
                .Append(" ,[CLMDTL_DIAG_CD]")
                .Append(" ,[CLMDTL_LINE_NO]")
                .Append(" ,[CLMDTL_RESUBMIT_FLAG]")
                .Append(" ,[CLMDTL_RESERVE_FOR_FUTURE]")
                .Append(" ,[CLMDTL_DESC]")
                .Append(" ,[CLMDTL_FILLER9]")
                .Append(" ,[CLMDTL_ORIG_BATCH_NBR]")
                .Append(" ,[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
                .Append(" ,[KEY_CLM_TYPE]")
                .Append(" ,[KEY_CLM_BATCH_NBR]")
                .Append(" ,[KEY_CLM_CLAIM_NBR]")
                .Append(" ,[KEY_CLM_SERV_CODE]")
                .Append(" ,[KEY_CLM_ADJ_NBR]")
                .Append(" ,[KEY_P_CLM_TYPE]")
                .Append(" ,[KEY_P_CLM_DATA]")
                .Append(" FROM")
                .Append(" [INDEXED].F002_CLAIMS_MSTR_DTL WITH (NOLOCK) ")
                .Append(" WHERE 1 = 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append(" AND ").Append("[KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append(" AND ").Append("[KEY_CLM_BATCH_NBR] = '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereClmdtl_claim_nbr > 0)
            {
                sql.Append(" AND ").Append("KEY_CLM_CLAIM_NBR >= ").Append(WhereKey_clm_claim_nbr);
            }

            sql.Append(" ORDER BY ").Append("[KEY_CLM_TYPE], [KEY_CLM_BATCH_NBR], [KEY_CLM_CLAIM_NBR]");

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL
                {
                    //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
                    CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString(),
                    CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]),
                    CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString(),
                    CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString(),
                    CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]),
                    CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString(),
                    CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]),
                    CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString(),
                    CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
                    CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]),
                    CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]),
                    CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]),
                    CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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

                    _whereClmdtl_batch_nbr = WhereClmdtl_batch_nbr,
                    _whereClmdtl_claim_nbr = WhereClmdtl_claim_nbr,
                    _whereClmdtl_oma_cd = WhereClmdtl_oma_cd,
                    _whereClmdtl_oma_suff = WhereClmdtl_oma_suff,
                    _whereClmdtl_adj_nbr = WhereClmdtl_adj_nbr,
                    _whereClmdtl_rev_group_cd = WhereClmdtl_rev_group_cd,
                    _whereClmdtl_agent_cd = WhereClmdtl_agent_cd,
                    _whereClmdtl_adj_cd = WhereClmdtl_adj_cd,
                    _whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv,
                    _whereClmdtl_sv_yy = WhereClmdtl_sv_yy,
                    _whereClmdtl_sv_mm = WhereClmdtl_sv_mm,
                    _whereClmdtl_sv_dd = WhereClmdtl_sv_dd,
                    _whereClmdtl_consec_dates_r = WhereClmdtl_consec_dates_r,
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

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            return collection;
        }

        #endregion

        #region Properties

        #region Columns
        protected int RowCheckSum;
		private Guid _ROWID;
		private string _CLMDTL_BATCH_NBR;
		private decimal? _CLMDTL_CLAIM_NBR;
		private string _CLMDTL_OMA_CD;
		private string _CLMDTL_OMA_SUFF;
		private decimal? _CLMDTL_ADJ_NBR;
		private string _CLMDTL_REV_GROUP_CD;
		private decimal? _CLMDTL_AGENT_CD;
		private string _CLMDTL_ADJ_CD;
		private decimal? _CLMDTL_NBR_SERV;
		private decimal? _CLMDTL_SV_YY;
		private decimal? _CLMDTL_SV_MM;
		private decimal? _CLMDTL_SV_DD;
        //private decimal? _CLMDTL_SV_NBR1;
        //private decimal? _CLMDTL_SV_NBR2;
        //private decimal? _CLMDTL_SV_NBR3;
        //private decimal? _CLMDTL_SV_DAY1;
        //private decimal? _CLMDTL_SV_DAY2;
        //private decimal? _CLMDTL_SV_DAY3;
        //private decimal? _CLMDTL_SV_NBR_1;
        //private decimal? _CLMDTL_SV_DAY_1;
        //private decimal? _CLMDTL_SV_NBR_2;
        //private decimal? _CLMDTL_SV_DAY_2;
        //private decimal? _CLMDTL_SV_NBR_3;
        //private decimal? _CLMDTL_SV_DAY_3;
        private string _CLMDTL_CONSEC_DATES_R;
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


        private string _MSTR_DESC_CLMDTL_OMA_CD;
            public string MSTR_DESC_CLMDTL_OMA_CD
        {
            get { return _MSTR_DESC_CLMDTL_OMA_CD; }
            set
            {
                if (_MSTR_DESC_CLMDTL_OMA_CD != value)
                {
                    _MSTR_DESC_CLMDTL_OMA_CD = value;
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
        //public decimal? CLMDTL_SV_NBR1
        //{
        //	get { return _CLMDTL_SV_NBR1; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR1 != value)
        //		{
        //			_CLMDTL_SV_NBR1 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_NBR2
        //{
        //	get { return _CLMDTL_SV_NBR2; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR2 != value)
        //		{
        //			_CLMDTL_SV_NBR2 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_NBR3
        //{
        //	get { return _CLMDTL_SV_NBR3; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR3 != value)
        //		{
        //			_CLMDTL_SV_NBR3 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY1
        //{
        //	get { return _CLMDTL_SV_DAY1; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY1 != value)
        //		{
        //			_CLMDTL_SV_DAY1 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY2
        //{
        //	get { return _CLMDTL_SV_DAY2; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY2 != value)
        //		{
        //			_CLMDTL_SV_DAY2 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY3
        //{
        //	get { return _CLMDTL_SV_DAY3; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY3 != value)
        //		{
        //			_CLMDTL_SV_DAY3 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_NBR_1
        //{
        //	get { return _CLMDTL_SV_NBR_1; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR_1 != value)
        //		{
        //			_CLMDTL_SV_NBR_1 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY_1
        //{
        //	get { return _CLMDTL_SV_DAY_1; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY_1 != value)
        //		{
        //			_CLMDTL_SV_DAY_1 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_NBR_2
        //{
        //	get { return _CLMDTL_SV_NBR_2; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR_2 != value)
        //		{
        //			_CLMDTL_SV_NBR_2 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY_2
        //{
        //	get { return _CLMDTL_SV_DAY_2; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY_2 != value)
        //		{
        //			_CLMDTL_SV_DAY_2 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_NBR_3
        //{
        //	get { return _CLMDTL_SV_NBR_3; }
        //	set
        //	{
        //		if (_CLMDTL_SV_NBR_3 != value)
        //		{
        //			_CLMDTL_SV_NBR_3 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        //public decimal? CLMDTL_SV_DAY_3
        //{
        //	get { return _CLMDTL_SV_DAY_3; }
        //	set
        //	{
        //		if (_CLMDTL_SV_DAY_3 != value)
        //		{
        //			_CLMDTL_SV_DAY_3 = value;
        //			ChangeState();
        //		}
        //	}
        //}
        public string CLMDTL_CONSEC_DATES_R
        {
            get { return _CLMDTL_CONSEC_DATES_R; }
            set
            {
                if (_CLMDTL_CONSEC_DATES_R != value)
                {
                    _CLMDTL_CONSEC_DATES_R = value;
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

        private string _MSTR_DESC_DTL_DESC;
        public string MSTR_DESC_DTL_DESC
        {
            get { return _MSTR_DESC_DTL_DESC; }
            set
            {
                if (_MSTR_DESC_DTL_DESC != value)
                {
                    _MSTR_DESC_DTL_DESC = value;
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
        //public decimal? WhereClmdtl_sv_nbr1 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr1;
        //public decimal? WhereClmdtl_sv_nbr2 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr2;
        //public decimal? WhereClmdtl_sv_nbr3 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr3;
        //public decimal? WhereClmdtl_sv_day1 { get; set; }
        //private decimal? _whereClmdtl_sv_day1;
        //public decimal? WhereClmdtl_sv_day2 { get; set; }
        //private decimal? _whereClmdtl_sv_day2;
        //public decimal? WhereClmdtl_sv_day3 { get; set; }
        //private decimal? _whereClmdtl_sv_day3;
        //public decimal? WhereClmdtl_sv_nbr_1 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr_1;
        //public decimal? WhereClmdtl_sv_day_1 { get; set; }
        //private decimal? _whereClmdtl_sv_day_1;
        //public decimal? WhereClmdtl_sv_nbr_2 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr_2;
        //public decimal? WhereClmdtl_sv_day_2 { get; set; }
        //private decimal? _whereClmdtl_sv_day_2;
        //public decimal? WhereClmdtl_sv_nbr_3 { get; set; }
        //private decimal? _whereClmdtl_sv_nbr_3;
        //public decimal? WhereClmdtl_sv_day_3 { get; set; }
        //private decimal? _whereClmdtl_sv_day_3;
        public string WhereClmdtl_consec_dates_r { get; set; }
        private string _whereClmdtl_consec_dates_r;
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
		private string _originalClmdtl_rev_group_cd;
		private decimal? _originalClmdtl_agent_cd;
		private string _originalClmdtl_adj_cd;
		private decimal? _originalClmdtl_nbr_serv;
		private decimal? _originalClmdtl_sv_yy;
		private decimal? _originalClmdtl_sv_mm;
		private decimal? _originalClmdtl_sv_dd;
        //private decimal? _originalClmdtl_sv_nbr1;
        //private decimal? _originalClmdtl_sv_nbr2;
        //private decimal? _originalClmdtl_sv_nbr3;
        //private decimal? _originalClmdtl_sv_day1;
        //private decimal? _originalClmdtl_sv_day2;
        //private decimal? _originalClmdtl_sv_day3;
        //private decimal? _originalClmdtl_sv_nbr_1;
        //private decimal? _originalClmdtl_sv_day_1;
        //private decimal? _originalClmdtl_sv_nbr_2;
        //private decimal? _originalClmdtl_sv_day_2;
        //private decimal? _originalClmdtl_sv_nbr_3;
        //private decimal? _originalClmdtl_sv_day_3;
        private string _originalClmdtl_consec_dates_r;
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
			CLMDTL_REV_GROUP_CD = _originalClmdtl_rev_group_cd;
			CLMDTL_AGENT_CD = _originalClmdtl_agent_cd;
			CLMDTL_ADJ_CD = _originalClmdtl_adj_cd;
			CLMDTL_NBR_SERV = _originalClmdtl_nbr_serv;
			CLMDTL_SV_YY = _originalClmdtl_sv_yy;
			CLMDTL_SV_MM = _originalClmdtl_sv_mm;
			CLMDTL_SV_DD = _originalClmdtl_sv_dd;
            //CLMDTL_SV_NBR1 = _originalClmdtl_sv_nbr1;
            //CLMDTL_SV_NBR2 = _originalClmdtl_sv_nbr2;
            //CLMDTL_SV_NBR3 = _originalClmdtl_sv_nbr3;
            //CLMDTL_SV_DAY1 = _originalClmdtl_sv_day1;
            //CLMDTL_SV_DAY2 = _originalClmdtl_sv_day2;
            //CLMDTL_SV_DAY3 = _originalClmdtl_sv_day3;
            //CLMDTL_SV_NBR_1 = _originalClmdtl_sv_nbr_1;
            //CLMDTL_SV_DAY_1 = _originalClmdtl_sv_day_1;
            //CLMDTL_SV_NBR_2 = _originalClmdtl_sv_nbr_2;
            //CLMDTL_SV_DAY_2 = _originalClmdtl_sv_day_2;
            //CLMDTL_SV_NBR_3 = _originalClmdtl_sv_nbr_3;
            //CLMDTL_SV_DAY_3 = _originalClmdtl_sv_day_3;
            CLMDTL_CONSEC_DATES_R = _originalClmdtl_consec_dates_r;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_DeleteRow]", parameters);

	    CloseConnection();

            if (RowsAffected == 0)
                return false;
            else
                return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_Purge]");
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
						new SqlParameter("CLMDTL_REV_GROUP_CD", SqlNull(CLMDTL_REV_GROUP_CD)),
						new SqlParameter("CLMDTL_AGENT_CD", SqlNull(CLMDTL_AGENT_CD)),
						new SqlParameter("CLMDTL_ADJ_CD", SqlNull(CLMDTL_ADJ_CD)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_SV_YY", SqlNull(CLMDTL_SV_YY)),
						new SqlParameter("CLMDTL_SV_MM", SqlNull(CLMDTL_SV_MM)),
						new SqlParameter("CLMDTL_SV_DD", SqlNull(CLMDTL_SV_DD)),
						//new SqlParameter("CLMDTL_SV_NBR1", SqlNull(CLMDTL_SV_NBR1)),
						//new SqlParameter("CLMDTL_SV_NBR2", SqlNull(CLMDTL_SV_NBR2)),
						//new SqlParameter("CLMDTL_SV_NBR3", SqlNull(CLMDTL_SV_NBR3)),
						//new SqlParameter("CLMDTL_SV_DAY1", SqlNull(CLMDTL_SV_DAY1)),
						//new SqlParameter("CLMDTL_SV_DAY2", SqlNull(CLMDTL_SV_DAY2)),
						//new SqlParameter("CLMDTL_SV_DAY3", SqlNull(CLMDTL_SV_DAY3)),
						//new SqlParameter("CLMDTL_SV_NBR_1", SqlNull(CLMDTL_SV_NBR_1)),
						//new SqlParameter("CLMDTL_SV_DAY_1", SqlNull(CLMDTL_SV_DAY_1)),
						//new SqlParameter("CLMDTL_SV_NBR_2", SqlNull(CLMDTL_SV_NBR_2)),
						//new SqlParameter("CLMDTL_SV_DAY_2", SqlNull(CLMDTL_SV_DAY_2)),
						//new SqlParameter("CLMDTL_SV_NBR_3", SqlNull(CLMDTL_SV_NBR_3)),
						//new SqlParameter("CLMDTL_SV_DAY_3", SqlNull(CLMDTL_SV_DAY_3)),
                        new SqlParameter("CLMDTL_CONSEC_DATES_R", SqlNull(CLMDTL_CONSEC_DATES_R)),
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
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]);
                        //CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
                        //CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
                        //CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
                        //CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
                        //CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
                        //CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
                        //CLMDTL_SV_NBR_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]);
                        //CLMDTL_SV_DAY_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]);
                        //CLMDTL_SV_NBR_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]);
                        //CLMDTL_SV_DAY_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]);
                        //CLMDTL_SV_NBR_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]);
                        //CLMDTL_SV_DAY_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]);
                        CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString();
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
						_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]);
                        //_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
                        //_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
                        //_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
                        //_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
                        //_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
                        //_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
                        //_originalClmdtl_sv_nbr_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]);
                        //_originalClmdtl_sv_day_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]);
                        //_originalClmdtl_sv_nbr_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]);
                        //_originalClmdtl_sv_day_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]);
                        //_originalClmdtl_sv_nbr_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]);
                        //_originalClmdtl_sv_day_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]);
                        _originalClmdtl_consec_dates_r = Reader["CLMDTL_CONSEC_DATES_R"].ToString();
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
                        new SqlParameter("CLMDTL_REV_GROUP_CD", SqlNull(CLMDTL_REV_GROUP_CD)),
                        new SqlParameter("CLMDTL_AGENT_CD", SqlNull(CLMDTL_AGENT_CD)),
                        new SqlParameter("CLMDTL_ADJ_CD", SqlNull(CLMDTL_ADJ_CD)),
                        new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
                        new SqlParameter("CLMDTL_SV_YY", SqlNull(CLMDTL_SV_YY)),
                        new SqlParameter("CLMDTL_SV_MM", SqlNull(CLMDTL_SV_MM)),
                        new SqlParameter("CLMDTL_SV_DD", SqlNull(CLMDTL_SV_DD)),
						//new SqlParameter("CLMDTL_SV_NBR1", SqlNull(CLMDTL_SV_NBR1)),
						//new SqlParameter("CLMDTL_SV_NBR2", SqlNull(CLMDTL_SV_NBR2)),
						//new SqlParameter("CLMDTL_SV_NBR3", SqlNull(CLMDTL_SV_NBR3)),
						//new SqlParameter("CLMDTL_SV_DAY1", SqlNull(CLMDTL_SV_DAY1)),
						//new SqlParameter("CLMDTL_SV_DAY2", SqlNull(CLMDTL_SV_DAY2)),
						//new SqlParameter("CLMDTL_SV_DAY3", SqlNull(CLMDTL_SV_DAY3)),
						//new SqlParameter("CLMDTL_SV_NBR_1", SqlNull(CLMDTL_SV_NBR_1)),
						//new SqlParameter("CLMDTL_SV_DAY_1", SqlNull(CLMDTL_SV_DAY_1)),
						//new SqlParameter("CLMDTL_SV_NBR_2", SqlNull(CLMDTL_SV_NBR_2)),
						//new SqlParameter("CLMDTL_SV_DAY_2", SqlNull(CLMDTL_SV_DAY_2)),
						//new SqlParameter("CLMDTL_SV_NBR_3", SqlNull(CLMDTL_SV_NBR_3)),
						//new SqlParameter("CLMDTL_SV_DAY_3", SqlNull(CLMDTL_SV_DAY_3)),
                        new SqlParameter("CLMDTL_CONSEC_DATES_R", SqlNull(CLMDTL_CONSEC_DATES_R)),
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
					Reader = CoreReader("[INDEXED].[sp_F002_CLAIMS_MSTR_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_BATCH_NBR = Reader["CLMDTL_BATCH_NBR"].ToString();
						CLMDTL_CLAIM_NBR = ConvertDEC(Reader["CLMDTL_CLAIM_NBR"]);
						CLMDTL_OMA_CD = Reader["CLMDTL_OMA_CD"].ToString();
						CLMDTL_OMA_SUFF = Reader["CLMDTL_OMA_SUFF"].ToString();
						CLMDTL_ADJ_NBR = ConvertDEC(Reader["CLMDTL_ADJ_NBR"]);
						CLMDTL_REV_GROUP_CD = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						CLMDTL_AGENT_CD = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						CLMDTL_ADJ_CD = Reader["CLMDTL_ADJ_CD"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_YY = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						CLMDTL_SV_MM = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						CLMDTL_SV_DD = ConvertDEC(Reader["CLMDTL_SV_DD"]);
                        //CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
                        //CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
                        //CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
                        //CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
                        //CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
                        //CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
                        //CLMDTL_SV_NBR_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]);
                        //CLMDTL_SV_DAY_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]);
                        //CLMDTL_SV_NBR_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]);
                        //CLMDTL_SV_DAY_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]);
                        //CLMDTL_SV_NBR_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]);
                        //CLMDTL_SV_DAY_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]);
                        CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString();
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
						_originalClmdtl_rev_group_cd = Reader["CLMDTL_REV_GROUP_CD"].ToString();
						_originalClmdtl_agent_cd = ConvertDEC(Reader["CLMDTL_AGENT_CD"]);
						_originalClmdtl_adj_cd = Reader["CLMDTL_ADJ_CD"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_yy = ConvertDEC(Reader["CLMDTL_SV_YY"]);
						_originalClmdtl_sv_mm = ConvertDEC(Reader["CLMDTL_SV_MM"]);
						_originalClmdtl_sv_dd = ConvertDEC(Reader["CLMDTL_SV_DD"]);
                        //_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
                        //_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
                        //_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
                        //_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
                        //_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
                        //_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
                        //_originalClmdtl_sv_nbr_1 = ConvertDEC(Reader["CLMDTL_SV_NBR_1"]);
                        //_originalClmdtl_sv_day_1 = ConvertDEC(Reader["CLMDTL_SV_DAY_1"]);
                        //_originalClmdtl_sv_nbr_2 = ConvertDEC(Reader["CLMDTL_SV_NBR_2"]);
                        //_originalClmdtl_sv_day_2 = ConvertDEC(Reader["CLMDTL_SV_DAY_2"]);
                        //_originalClmdtl_sv_nbr_3 = ConvertDEC(Reader["CLMDTL_SV_NBR_3"]);
                        //_originalClmdtl_sv_day_3 = ConvertDEC(Reader["CLMDTL_SV_DAY_3"]);
                        _originalClmdtl_consec_dates_r = Reader["CLMDTL_CONSEC_DATES_R"].ToString();
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