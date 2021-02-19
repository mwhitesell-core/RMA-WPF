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
    public partial class F002_CLAIMS_MSTR_DTL
    {
        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F002_CLAIMS_MSTR_DTL> f002_claims_mstr_dtl = null)
        {
            if (f002_claims_mstr_dtl != null)
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = f002_claims_mstr_dtl.FirstOrDefault();
                if (objF002_CLAIMS_MSTR_DTL != null)
                {
                    _whereKey_clm_type = objF002_CLAIMS_MSTR_DTL._KEY_CLM_TYPE; // KEY_CLM_TYPE;
                    _whereClmdtl_batch_nbr = objF002_CLAIMS_MSTR_DTL._CLMDTL_BATCH_NBR; //CLMDTL_BATCH_NBR;
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
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT  ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
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
               /*.Append(" ,[CLMDTL_SV_NBR1]")
               .Append(" ,[CLMDTL_SV_NBR2]")
               .Append(" ,[CLMDTL_SV_NBR3]")
               .Append(" ,[CLMDTL_SV_DAY1]")
               .Append(" ,[CLMDTL_SV_DAY2]")
               .Append(" ,[CLMDTL_SV_DAY3]")
               .Append(" ,[CLMDTL_SV_NBR_1]")
               .Append(" ,[CLMDTL_SV_DAY_1]")
               .Append(" ,[CLMDTL_SV_NBR_2]")
               .Append(" ,[CLMDTL_SV_DAY_2]")
               .Append(" ,[CLMDTL_SV_NBR_3]")
               .Append(" ,[CLMDTL_SV_DAY_3]") */
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
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_DTL] WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               .Append(" AND")
               //.Append(" KEY_CLM_BATCH_NBR >= '").Append(WhereClmdtl_batch_nbr).Append("'")
               .Append(" CLMDTL_BATCH_NBR >= '").Append(WhereClmdtl_batch_nbr).Append("'")
               .Append(" AND")
               //.Append(" KEY_CLM_CLAIM_NBR >= ").Append(WhereKey_clm_claim_nbr)
               .Append(" CLMDTL_CLAIM_NBR >= ").Append(WhereClmdtl_claim_nbr)
               .Append(" AND")
               //.Append(" KEY_CLM_SERV_CODE >= '").Append(WhereKey_clm_serv_code).Append("'")
               .Append(" CLMDTL_OMA_CD >=  '").Append(WhereClmdtl_oma_cd).Append("'")
               .Append(" AND")
               //.Append(" KEY_CLM_ADJ_NBR >= '").Append(WhereKey_clm_adj_nbr).Append("'")         
               .Append(" CLMDTL_OMA_SUFF >= '").Append(WhereClmdtl_oma_suff).Append("'")
               .Append(" AND")
               .Append(" CLMDTL_ADJ_NBR >=").Append(WhereClmdtl_adj_nbr)
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               /*.Append(" KEY_CLM_BATCH_NBR, ")
               .Append(" KEY_CLM_CLAIM_NBR,")
               .Append(" KEY_CLM_SERV_CODE,")
               .Append(" KEY_CLM_ADJ_NBR"); */
               .Append("  CLMDTL_BATCH_NBR,")
               .Append(" CLMDTL_CLAIM_NBR,")
               .Append(" CLMDTL_OMA_CD,")
               .Append(" CLMDTL_OMA_SUFF,")
               .Append(" CLMDTL_ADJ_NBR");

            Reader = CoreReader(sql.ToString());

            while(Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                   // _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            return collection;
        }

        public F002_CLAIMS_MSTR_DTL Collection_ReadStart()
        {
                       
            StringBuilder sql = null;
            sql = new StringBuilder();           

            sql.Append("SELECT  TOP 1")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
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
               /*.Append(" ,[CLMDTL_SV_NBR1]")
               .Append(" ,[CLMDTL_SV_NBR2]")
               .Append(" ,[CLMDTL_SV_NBR3]")
               .Append(" ,[CLMDTL_SV_DAY1]")
               .Append(" ,[CLMDTL_SV_DAY2]")
               .Append(" ,[CLMDTL_SV_DAY3]")
               .Append(" ,[CLMDTL_SV_NBR_1]")
               .Append(" ,[CLMDTL_SV_DAY_1]")
               .Append(" ,[CLMDTL_SV_NBR_2]")
               .Append(" ,[CLMDTL_SV_DAY_2]")
               .Append(" ,[CLMDTL_SV_NBR_3]")
               .Append(" ,[CLMDTL_SV_DAY_3]") */
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
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_DTL]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_BATCH_NBR >= '").Append(WhereClmdtl_batch_nbr).Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_CLAIM_NBR >= ").Append(WhereClmdtl_claim_nbr)
               .Append(" AND")               
               .Append(" CLMDTL_OMA_CD >=  '").Append(WhereClmdtl_oma_cd).Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_OMA_SUFF >= '").Append(WhereClmdtl_oma_suff).Append("'")
               .Append(" AND")
               .Append(" CLMDTL_ADJ_NBR >=").Append(WhereClmdtl_adj_nbr)
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")               
               .Append(" CLMDTL_BATCH_NBR,")
               .Append(" CLMDTL_CLAIM_NBR,")
               .Append(" CLMDTL_OMA_CD,")
               .Append(" CLMDTL_OMA_SUFF,")
               .Append(" CLMDTL_ADJ_NBR");

            Reader = CoreReader(sql.ToString());

            F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;

            while (Reader.Read())
            {
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                    CLMDTL_CONSEC_DATES_R = CLMDTL_CONSEC_DATES_R = Reader["CLMDTL_CONSEC_DATES_R"].ToString(),
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
                    // _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                };
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }

        public F002_CLAIMS_MSTR_DTL Collection_ReadNext(F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL)
        {
           
            StringBuilder sql = null;
            sql = new StringBuilder();           
            
            sql.Append("SELECT  TOP 2")
                .Append(" ROW_NUMBER() OVER (ORDER BY KEY_CLM_TYPE,CLMDTL_BATCH_NBR,CLMDTL_CLAIM_NBR,CLMDTL_OMA_CD,CLMDTL_OMA_SUFF,CLMDTL_ADJ_NBR) AS 'ROWNUM'")
               .Append(" ,BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
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
              /* .Append(" ,[CLMDTL_SV_NBR1]")
               .Append(" ,[CLMDTL_SV_NBR2]")
               .Append(" ,[CLMDTL_SV_NBR3]")
               .Append(" ,[CLMDTL_SV_DAY1]")
               .Append(" ,[CLMDTL_SV_DAY2]")
               .Append(" ,[CLMDTL_SV_DAY3]")
               .Append(" ,[CLMDTL_SV_NBR_1]")
               .Append(" ,[CLMDTL_SV_DAY_1]")
               .Append(" ,[CLMDTL_SV_NBR_2]")
               .Append(" ,[CLMDTL_SV_DAY_2]")
               .Append(" ,[CLMDTL_SV_NBR_3]")
               .Append(" ,[CLMDTL_SV_DAY_3]") */
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
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_DTL]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_TYPE).Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_BATCH_NBR >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_BATCH_NBR) .Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_CLAIM_NBR >= ").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_CLAIM_NBR)
               .Append(" AND")               
               .Append(" CLMDTL_OMA_CD >=  '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD).Append("'")
               .Append(" AND")               
               .Append(" CLMDTL_OMA_SUFF >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF).Append("'")
               .Append(" AND")
               .Append(" CLMDTL_ADJ_NBR >= ").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_NBR)
               .Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")               
               .Append(" CLMDTL_BATCH_NBR,")
               .Append(" CLMDTL_CLAIM_NBR,")
               .Append(" CLMDTL_OMA_CD,")
               .Append(" CLMDTL_OMA_SUFF,")
               .Append(" CLMDTL_ADJ_NBR");

            Reader = CoreReader(sql.ToString());
            objF002_CLAIMS_MSTR_DTL = null;

            while (Reader.Read())
            {
                if (ConvertINT(Reader["ROWNUM"]) == 2)
                {
                    objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                    {
                        RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                        // _whereChecksum_value = WhereChecksum_value,

                        RecordState = State.UnChanged
                    };
                }
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }

        public F002_CLAIMS_MSTR_DTL Collection_B_Clinic_Nbr_1_2_ReadStart()
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT  TOP 1")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
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
              /* .Append(" ,[CLMDTL_SV_NBR1]")
               .Append(" ,[CLMDTL_SV_NBR2]")
               .Append(" ,[CLMDTL_SV_NBR3]")
               .Append(" ,[CLMDTL_SV_DAY1]")
               .Append(" ,[CLMDTL_SV_DAY2]")
               .Append(" ,[CLMDTL_SV_DAY3]")
               .Append(" ,[CLMDTL_SV_NBR_1]")
               .Append(" ,[CLMDTL_SV_DAY_1]")
               .Append(" ,[CLMDTL_SV_NBR_2]")
               .Append(" ,[CLMDTL_SV_DAY_2]")
               .Append(" ,[CLMDTL_SV_NBR_3]")
               .Append(" ,[CLMDTL_SV_DAY_3]") */
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
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_DTL]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(WhereKey_clm_type).Append("'")
               .Append(" AND")
               .Append(" LEFT(CLMDTL_BATCH_NBR,2) >= ").Append(WhereClmdtl_batch_nbr).Append("");

                if (WhereClmdtl_claim_nbr > 0)
                {
                   sql.Append(" AND")
                      .Append(" CLMDTL_CLAIM_NBR >= ").Append(WhereClmdtl_claim_nbr);
                }
                       
               sql.Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               .Append(" CLMDTL_BATCH_NBR,")
               .Append(" CLMDTL_CLAIM_NBR,")
               .Append(" CLMDTL_OMA_CD,")
               .Append(" CLMDTL_OMA_SUFF,")
               .Append(" CLMDTL_ADJ_NBR");

            Reader = CoreReader(sql.ToString());

            F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;

            while (Reader.Read())
            {
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
                    RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                    // _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                };
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }

        public F002_CLAIMS_MSTR_DTL Collection_B_Clinic_Nbr_1_2_ReadNext(F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT  TOP 2")
                .Append(" ROW_NUMBER() OVER (ORDER BY KEY_CLM_TYPE,CLMDTL_BATCH_NBR,CLMDTL_CLAIM_NBR,CLMDTL_OMA_CD,CLMDTL_OMA_SUFF,CLMDTL_ADJ_NBR) AS 'ROWNUM'")
               .Append(" ,BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
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
              /* .Append(" ,[CLMDTL_SV_NBR1]")
               .Append(" ,[CLMDTL_SV_NBR2]")
               .Append(" ,[CLMDTL_SV_NBR3]")
               .Append(" ,[CLMDTL_SV_DAY1]")
               .Append(" ,[CLMDTL_SV_DAY2]")
               .Append(" ,[CLMDTL_SV_DAY3]")
               .Append(" ,[CLMDTL_SV_NBR_1]")
               .Append(" ,[CLMDTL_SV_DAY_1]")
               .Append(" ,[CLMDTL_SV_NBR_2]")
               .Append(" ,[CLMDTL_SV_DAY_2]")
               .Append(" ,[CLMDTL_SV_NBR_3]")
               .Append(" ,[CLMDTL_SV_DAY_3]") */
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
               .Append(" [INDEXED].[F002_CLAIMS_MSTR_DTL]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" KEY_CLM_TYPE >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_TYPE).Append("'")
               .Append(" AND")
               .Append(" LEFT(CLMDTL_BATCH_NBR,2) >= ").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_BATCH_NBR).Append("");              

               if (objF002_CLAIMS_MSTR_DTL.CLMDTL_CLAIM_NBR > 0 )
               {
                 sql.Append(" AND")
                    .Append(" CLMDTL_CLAIM_NBR >= ").Append(WhereClmdtl_claim_nbr);
               }

               sql.Append(" ORDER BY")
               .Append(" KEY_CLM_TYPE, ")
               .Append(" CLMDTL_BATCH_NBR,")
               .Append(" CLMDTL_CLAIM_NBR,")
               .Append(" CLMDTL_OMA_CD,")
               .Append(" CLMDTL_OMA_SUFF,")
               .Append(" CLMDTL_ADJ_NBR");

            Reader = CoreReader(sql.ToString());
            objF002_CLAIMS_MSTR_DTL = null;

            while (Reader.Read())
            {
                if (ConvertINT(Reader["ROWNUM"]) == 2)
                {
                    objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                    {
                        RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                        // _whereChecksum_value = WhereChecksum_value,

                        RecordState = State.UnChanged
                    };
                }
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }


        // Added for INNER JOIN Claims_MSTR_HDR and Claims_MSTR_DTL
        #region  Claims_Mstr_Hdr  
        #region Columns
        //private int RowCheckSum;
        private Guid _ROWID_HDR;
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
        /*private string _KEY_CLM_TYPE;
        private string _KEY_CLM_BATCH_NBR;
        private decimal? _KEY_CLM_CLAIM_NBR;
        private string _KEY_CLM_SERV_CODE;
        private string _KEY_CLM_ADJ_NBR;
        private string _KEY_P_CLM_TYPE;
        private string _KEY_P_CLM_DATA;
        private int? _CHECKSUM_VALUE; */

        public Guid ROWID_HDR
        {
            get { return _ROWID_HDR; }
            set
            {
                if (_ROWID_HDR != value)
                {
                    _ROWID_HDR = value;
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
     
        #endregion

        #region Where

      
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
       

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_HDR_DTL_For_Clinic_NBR(ref bool isRetrieveRecord, ObservableCollection<F002_CLAIMS_MSTR_DTL> f002_claims_mstr_dtl = null)
        {

            if (f002_claims_mstr_dtl != null)
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = f002_claims_mstr_dtl.FirstOrDefault();
                if (objF002_CLAIMS_MSTR_DTL != null)
                {
                    _whereKey_clm_type = objF002_CLAIMS_MSTR_DTL._KEY_CLM_TYPE; // KEY_CLM_TYPE;
                    _whereClmdtl_batch_nbr = objF002_CLAIMS_MSTR_DTL._CLMDTL_BATCH_NBR.PadRight(8,' ').Substring(0,2); //CLMDTL_BATCH_NBR;
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
               .Append("  a.ROWID as 'ROWID_HDR'")
               .Append(" ,a.[CLMHDR_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_CLAIM_NBR]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,a.[CLMHDR_BATCH_TYPE]")
               .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,a.[CLMHDR_DIAG_CD]")
               .Append(" ,a.[CLMHDR_LOC]")
               .Append(" ,a.[CLMHDR_HOSP]")
               .Append(" ,a.[CLMHDR_AGENT_CD]")
               .Append(" ,a.[CLMHDR_ADJ_CD]")
               .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
               .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,a.[CLMHDR_REFERENCE]")
               .Append(" ,a.[CLMHDR_DATE_ADMIT]")
               .Append(" ,a.[CLMHDR_DOC_DEPT]")
               .Append(" ,a.[CLMHDR_MSG_NBR]")
               .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
               .Append(" ,a.[CLMHDR_SUB_NBR]")
               .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
               .Append(" ,a.[FILLER]")
               .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
               .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,a.[CLMHDR_CYCLE_NBR]")
               .Append(" ,a.[CLMHDR_DATE_SYS]")
               .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,a.[CLMHDR_STATUS_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
               .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,a.[CLMHDR_SERV_DATE]")
               .Append(" ,a.[CLMHDR_ELIG_ERROR]")
               .Append(" ,a.[CLMHDR_ELIG_STATUS]")
               .Append(" ,a.[CLMHDR_SERV_ERROR]")
               .Append(" ,a.[CLMHDR_SERV_STATUS]")
               .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")

               .Append(" ,b.[CLMDTL_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_CLAIM_NBR]")
               .Append(" ,b.[CLMDTL_OMA_CD]")
               .Append(" ,b.[CLMDTL_OMA_SUFF]")
               .Append(" ,b.[CLMDTL_ADJ_NBR]")
               .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
               .Append(" ,b.[CLMDTL_AGENT_CD]")
               .Append(" ,b.[CLMDTL_ADJ_CD]")
               .Append(" ,b.[CLMDTL_NBR_SERV]")
               .Append(" ,b.[CLMDTL_SV_YY]")
               .Append(" ,b.[CLMDTL_SV_MM]")
               .Append(" ,b.[CLMDTL_SV_DD]")
               /*.Append(" ,b.[CLMDTL_SV_NBR1]")
               .Append(" ,b.[CLMDTL_SV_NBR2]")
               .Append(" ,b.[CLMDTL_SV_NBR3]")
               .Append(" ,b.[CLMDTL_SV_DAY1]")
               .Append(" ,b.[CLMDTL_SV_DAY2]")
               .Append(" ,b.[CLMDTL_SV_DAY3]")
               .Append(" ,b.[CLMDTL_SV_NBR_1]")
               .Append(" ,b.[CLMDTL_SV_DAY_1]")
               .Append(" ,b.[CLMDTL_SV_NBR_2]")
               .Append(" ,b.[CLMDTL_SV_DAY_2]")
               .Append(" ,b.[CLMDTL_SV_NBR_3]")
               .Append(" ,b.[CLMDTL_SV_DAY_3]") */
               .Append(" ,b.[CLMDTL_CONSEC_DATES_R]")
               .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
               .Append(" ,b.[CLMDTL_FEE_OMA]")
               .Append(" ,b.[CLMDTL_FEE_OHIP]")
               .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
               .Append(" ,b.[CLMDTL_CYCLE_NBR]")
               .Append(" ,b.[CLMDTL_DIAG_CD]")
               .Append(" ,b.[CLMDTL_LINE_NO]")
               .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
               .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
               .Append(" ,b.[CLMDTL_DESC]")
               .Append(" ,b.[CLMDTL_FILLER9]")
               .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
               .Append(" ,b.[KEY_CLM_TYPE]")
               .Append(" ,b.[KEY_CLM_BATCH_NBR]")
               .Append(" ,b.[KEY_CLM_CLAIM_NBR]")
               .Append(" ,b.[KEY_CLM_SERV_CODE]")
               .Append(" ,b.[KEY_CLM_ADJ_NBR]")
               .Append(" ,b.[KEY_P_CLM_TYPE]")
               .Append(" ,b.[KEY_P_CLM_DATA]")

               .Append(" FROM")
              .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
              .Append("      INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.KEY_CLM_BATCH_NBR = b.KEY_CLM_BATCH_NBR ")
              .Append("                                                    AND a.KEY_CLM_CLAIM_NBR = b.KEY_CLM_CLAIM_NBR")
               .Append(" WHERE")
               .Append("   1= 1");

               if (!string.IsNullOrWhiteSpace(WhereClmhdr_batch_type)) {
                sql.Append(" AND")                   
                   .Append(" a.[CLMHDR_BATCH_TYPE] = '").Append(WhereClmhdr_batch_type).Append("'");
               }

               if (!string.IsNullOrWhiteSpace(WhereKey_clm_type)) {
                 sql.Append("   AND")
                .Append("    b.[KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
               }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append("    AND ")
               .Append("   LEFT(a.KEY_CLM_BATCH_NBR,2) = ").Append(WhereKey_clm_batch_nbr);
            }

            if (!string.IsNullOrWhiteSpace(WhereClmdtl_batch_nbr))
              {
                sql.Append("    AND ")
                .Append("    LEFT(b.CLMDTL_BATCH_NBR,2) = ").Append(WhereClmdtl_batch_nbr);
              }

               if (WhereClmdtl_claim_nbr > 0 )
               {
                     sql.Append(" AND")
                    .Append(" b.CLMDTL_CLAIM_NBR >= ").Append(WhereClmdtl_claim_nbr);
               }
               sql.Append(" ORDER BY")
               .Append(" a.[KEY_CLM_TYPE],a.[KEY_CLM_BATCH_NBR],a.[KEY_CLM_CLAIM_NBR]");

            // .Append("    a.CLMHDR_BATCH_NBR,a.CLMHDR_CLAIM_NBR, a.CLMHDR_ADJ_OMA_CD, a.CLMHDR_ADJ_OMA_SUFF, a.CLMHDR_ADJ_ADJ_NBR,")
            // .Append("    b.CLMDTL_BATCH_NBR, b.CLMDTL_CLAIM_NBR, b.CLMDTL_OMA_CD, b.CLMDTL_OMA_SUFF");

          //  Debug.WriteLine(sql.ToString());

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F002_CLAIMS_MSTR_DTL
                {
                    //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                    /* KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(), */

                    //RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                    _whereClmdtl_consec_dates_r =WhereClmdtl_consec_dates_r,
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

        public F002_CLAIMS_MSTR_DTL Collection_HDR_DTL_INNERJOIN_ReadStart()
        {
                       
            StringBuilder sql = null;            
            sql = new StringBuilder();

            sql.Append("SELECT TOP 1")
               .Append("  a.ROWID as 'ROWID_HDR'")
               .Append(" ,a.[CLMHDR_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_CLAIM_NBR]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,a.[CLMHDR_BATCH_TYPE]")
               .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,a.[CLMHDR_DIAG_CD]")
               .Append(" ,a.[CLMHDR_LOC]")
               .Append(" ,a.[CLMHDR_HOSP]")
               .Append(" ,a.[CLMHDR_AGENT_CD]")
               .Append(" ,a.[CLMHDR_ADJ_CD]")
               .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
               .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,a.[CLMHDR_REFERENCE]")
               .Append(" ,a.[CLMHDR_DATE_ADMIT]")
               .Append(" ,a.[CLMHDR_DOC_DEPT]")
               .Append(" ,a.[CLMHDR_MSG_NBR]")
               .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
               .Append(" ,a.[CLMHDR_SUB_NBR]")
               .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
               .Append(" ,a.[FILLER]")
               .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
               .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,a.[CLMHDR_CYCLE_NBR]")
               .Append(" ,a.[CLMHDR_DATE_SYS]")
               .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,a.[CLMHDR_STATUS_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
               .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,a.[CLMHDR_SERV_DATE]")
               .Append(" ,a.[CLMHDR_ELIG_ERROR]")
               .Append(" ,a.[CLMHDR_ELIG_STATUS]")
               .Append(" ,a.[CLMHDR_SERV_ERROR]")
               .Append(" ,a.[CLMHDR_SERV_STATUS]")
               .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")

               .Append(" ,b.ROWID as 'ROWID'")
               .Append(" ,b.[CLMDTL_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_CLAIM_NBR]")
               .Append(" ,b.[CLMDTL_OMA_CD]")
               .Append(" ,b.[CLMDTL_OMA_SUFF]")
               .Append(" ,b.[CLMDTL_ADJ_NBR]")
               .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
               .Append(" ,b.[CLMDTL_AGENT_CD]")
               .Append(" ,b.[CLMDTL_ADJ_CD]")
               .Append(" ,b.[CLMDTL_NBR_SERV]")
               .Append(" ,b.[CLMDTL_SV_YY]")
               .Append(" ,b.[CLMDTL_SV_MM]")
               .Append(" ,b.[CLMDTL_SV_DD]")
               /*.Append(" ,b.[CLMDTL_SV_NBR1]")
               .Append(" ,b.[CLMDTL_SV_NBR2]")
               .Append(" ,b.[CLMDTL_SV_NBR3]")
               .Append(" ,b.[CLMDTL_SV_DAY1]")
               .Append(" ,b.[CLMDTL_SV_DAY2]")
               .Append(" ,b.[CLMDTL_SV_DAY3]")
               .Append(" ,b.[CLMDTL_SV_NBR_1]")
               .Append(" ,b.[CLMDTL_SV_DAY_1]")
               .Append(" ,b.[CLMDTL_SV_NBR_2]")
               .Append(" ,b.[CLMDTL_SV_DAY_2]")
               .Append(" ,b.[CLMDTL_SV_NBR_3]")
               .Append(" ,b.[CLMDTL_SV_DAY_3]") */
               .Append(" ,b.[CLMDTL_CONSEC_DATES_R]")
               .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
               .Append(" ,b.[CLMDTL_FEE_OMA]")
               .Append(" ,b.[CLMDTL_FEE_OHIP]")
               .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
               .Append(" ,b.[CLMDTL_CYCLE_NBR]")
               .Append(" ,b.[CLMDTL_DIAG_CD]")
               .Append(" ,b.[CLMDTL_LINE_NO]")
               .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
               .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
               .Append(" ,b.[CLMDTL_DESC]")
               .Append(" ,b.[CLMDTL_FILLER9]")
               .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
               .Append(" ,b.[KEY_CLM_TYPE]")
               .Append(" ,b.[KEY_CLM_BATCH_NBR]")
               .Append(" ,b.[KEY_CLM_CLAIM_NBR]")
               .Append(" ,b.[KEY_CLM_SERV_CODE]")
               .Append(" ,b.[KEY_CLM_ADJ_NBR]")
               .Append(" ,b.[KEY_P_CLM_TYPE]")
               .Append(" ,b.[KEY_P_CLM_DATA]")

               .Append(" FROM")
               .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
               .Append("      INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.CLMHDR_BATCH_NBR = b.CLMDTL_BATCH_NBR ")
               .Append("                                                    AND a.CLMHDR_CLAIM_NBR = b.CLMDTL_CLAIM_NBR")
               .Append(" WHERE")
               .Append("   1= 1");
            
            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append("   AND")
               .Append("    b.[KEY_CLM_TYPE] >= '").Append(WhereKey_clm_type).Append("'");
            }

           /* if (!string.IsNullOrWhiteSpace(WhereClmhdr_batch_nbr))
            {
                sql.Append("    AND ")
                .Append("    a.CLMHDR_BATCH_NBR >= '").Append(WhereClmhdr_batch_nbr).Append("'");
            }

            if (WhereClmhdr_claim_nbr > 0)
            {
                sql.Append(" AND")
               .Append(" a.CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr);
            }

            if(!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_cd))
            {
                sql.Append(" AND")
                .Append(" a.CLMHDR_ADJ_OMA_CD >= '").Append(WhereClmhdr_adj_oma_cd).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_suff))
            {
                sql.Append(" AND")
                .Append("  a.CLMHDR_ADJ_OMA_SUFF >= '").Append(WhereClmhdr_adj_oma_suff).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_adj_nbr))
            {
                sql.Append(" AND")
                .Append("  a.CLMHDR_ADJ_ADJ_NBR >= '").Append(WhereClmhdr_adj_adj_nbr).Append("'");
            } */

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr  ))
            {
                sql.Append(" AND ")
                    .Append(" b.KEY_CLM_BATCH_NBR >= '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereKey_clm_claim_nbr > 0 )
            {
                sql.Append(" AND ")
                    .Append(" b.KEY_CLM_CLAIM_NBR >= ").Append(WhereKey_clm_claim_nbr);
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_serv_code))
            {
                sql.Append(" AND ")
                    .Append(" b.KEY_CLM_SERV_CODE >= '").Append(WhereKey_clm_serv_code).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_adj_nbr)) {
                sql.Append(" AND ")
                    .Append(" b.KEY_CLM_ADJ_NBR >= '").Append(WhereKey_clm_adj_nbr).Append("'");
            }


            sql.Append(" ORDER BY")
                .Append(" b.KEY_CLM_BATCH_NBR, b.KEY_CLM_CLAIM_NBR,  b.KEY_CLM_SERV_CODE, b.KEY_CLM_ADJ_NBR  ");
           // .Append("    a.CLMHDR_BATCH_NBR,a.CLMHDR_CLAIM_NBR, a.CLMHDR_ADJ_OMA_CD, a.CLMHDR_ADJ_OMA_SUFF, a.CLMHDR_ADJ_ADJ_NBR");
           // .Append("    b.CLMDTL_BATCH_NBR, b.CLMDTL_CLAIM_NBR, b.CLMDTL_OMA_CD, b.CLMDTL_OMA_SUFF");

          //  Debug.WriteLine(sql.ToString());

            Reader = CoreReader(sql.ToString());

            F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;

            while (Reader.Read())
            {
                objF002_CLAIMS_MSTR_DTL =  new F002_CLAIMS_MSTR_DTL
                {
                    //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                    /* KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(), */

                    //RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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
                    _whereClmdtl_consec_dates_r =WhereClmdtl_consec_dates_r,
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
                };
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }

        public F002_CLAIMS_MSTR_DTL Collection_HDR_DTL_INNERJOIN_ReadNext(F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL)
        {
                   
            StringBuilder sql = null;            
            sql = new StringBuilder();

            sql.Append("SELECT * FROM (");
            sql.Append("SELECT TOP 2")
               .Append("  a.ROWID as 'ROWID_HDR'")
               //.Append(" ,ROW_NUMBER() OVER (ORDER BY CLMHDR_BATCH_NBR,CLMHDR_CLAIM_NBR,CLMHDR_ADJ_OMA_CD,CLMHDR_ADJ_OMA_SUFF,CLMHDR_ADJ_ADJ_NBR) AS 'ROWNUM'")
               .Append(" ,ROW_NUMBER() OVER (ORDER BY b.KEY_CLM_BATCH_NBR, b.KEY_CLM_CLAIM_NBR,  b.KEY_CLM_SERV_CODE, b.KEY_CLM_ADJ_NBR) AS 'ROWNUM'")               
               .Append(" ,a.[CLMHDR_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_CLAIM_NBR]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
               .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
               .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
               .Append(" ,a.[CLMHDR_BATCH_TYPE]")
               .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
               .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
               .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
               .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
               .Append(" ,a.[CLMHDR_DIAG_CD]")
               .Append(" ,a.[CLMHDR_LOC]")
               .Append(" ,a.[CLMHDR_HOSP]")
               .Append(" ,a.[CLMHDR_AGENT_CD]")
               .Append(" ,a.[CLMHDR_ADJ_CD]")
               .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
               .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
               .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
               .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
               .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
               .Append(" ,a.[CLMHDR_REFERENCE]")
               .Append(" ,a.[CLMHDR_DATE_ADMIT]")
               .Append(" ,a.[CLMHDR_DOC_DEPT]")
               .Append(" ,a.[CLMHDR_MSG_NBR]")
               .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
               .Append(" ,a.[CLMHDR_SUB_NBR]")
               .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
               .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
               .Append(" ,a.[FILLER]")
               .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
               .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
               .Append(" ,a.[CLMHDR_CYCLE_NBR]")
               .Append(" ,a.[CLMHDR_DATE_SYS]")
               .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
               .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
               .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
               .Append(" ,a.[CLMHDR_STATUS_OHIP]")
               .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
               .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
               .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
               .Append(" ,a.[CLMHDR_SERV_DATE]")
               .Append(" ,a.[CLMHDR_ELIG_ERROR]")
               .Append(" ,a.[CLMHDR_ELIG_STATUS]")
               .Append(" ,a.[CLMHDR_SERV_ERROR]")
               .Append(" ,a.[CLMHDR_SERV_STATUS]")
               .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
               .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")

               .Append(" ,b.ROWID as 'ROWID'")
               .Append(" ,b.[CLMDTL_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_CLAIM_NBR]")
               .Append(" ,b.[CLMDTL_OMA_CD]")
               .Append(" ,b.[CLMDTL_OMA_SUFF]")
               .Append(" ,b.[CLMDTL_ADJ_NBR]")
               .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
               .Append(" ,b.[CLMDTL_AGENT_CD]")
               .Append(" ,b.[CLMDTL_ADJ_CD]")
               .Append(" ,b.[CLMDTL_NBR_SERV]")
               .Append(" ,b.[CLMDTL_SV_YY]")
               .Append(" ,b.[CLMDTL_SV_MM]")
               .Append(" ,b.[CLMDTL_SV_DD]")
               /*.Append(" ,b.[CLMDTL_SV_NBR1]")
               .Append(" ,b.[CLMDTL_SV_NBR2]")
               .Append(" ,b.[CLMDTL_SV_NBR3]")
               .Append(" ,b.[CLMDTL_SV_DAY1]")
               .Append(" ,b.[CLMDTL_SV_DAY2]")
               .Append(" ,b.[CLMDTL_SV_DAY3]")
               .Append(" ,b.[CLMDTL_SV_NBR_1]")
               .Append(" ,b.[CLMDTL_SV_DAY_1]")
               .Append(" ,b.[CLMDTL_SV_NBR_2]")
               .Append(" ,b.[CLMDTL_SV_DAY_2]")
               .Append(" ,b.[CLMDTL_SV_NBR_3]")
               .Append(" ,b.[CLMDTL_SV_DAY_3]") */
               .Append(" ,b.[CLMDTL_CONSEC_DATES_R]")
               .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
               .Append(" ,b.[CLMDTL_FEE_OMA]")
               .Append(" ,b.[CLMDTL_FEE_OHIP]")
               .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
               .Append(" ,b.[CLMDTL_CYCLE_NBR]")
               .Append(" ,b.[CLMDTL_DIAG_CD]")
               .Append(" ,b.[CLMDTL_LINE_NO]")
               .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
               .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
               .Append(" ,b.[CLMDTL_DESC]")
               .Append(" ,b.[CLMDTL_FILLER9]")
               .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
               .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
               .Append(" ,b.[KEY_CLM_TYPE]")
               .Append(" ,b.[KEY_CLM_BATCH_NBR]")
               .Append(" ,b.[KEY_CLM_CLAIM_NBR]")
               .Append(" ,b.[KEY_CLM_SERV_CODE]")
               .Append(" ,b.[KEY_CLM_ADJ_NBR]")
               .Append(" ,b.[KEY_P_CLM_TYPE]")
               .Append(" ,b.[KEY_P_CLM_DATA]")

               .Append(" FROM")
               .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
               .Append("      INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.CLMHDR_BATCH_NBR = b.CLMDTL_BATCH_NBR ")
               .Append("                                                    AND a.CLMHDR_CLAIM_NBR = b.CLMDTL_CLAIM_NBR")
               .Append(" WHERE")
               .Append("   1= 1")
               .Append(" AND")
               .Append(" b.[KEY_CLM_TYPE] >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_TYPE).Append("'")
              /* .Append(" AND ")
               .Append(" b.CLMDTL_BATCH_NBR >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_BATCH_NBR).Append("'")
               .Append(" AND")
               .Append(" b.CLMDTL_CLAIM_NBR >= ").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_CLAIM_NBR)
               .Append(" AND")
               .Append(" b.CLMDTL_OMA_CD >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_OMA_CD).Append("'")
               .Append(" AND")
               .Append("  b.CLMDTL_OMA_SUFF >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_OMA_SUFF).Append("'")
               .Append(" AND")
               .Append("  b.CLMDTL_ADJ_NBR >= '").Append(objF002_CLAIMS_MSTR_DTL.CLMDTL_ADJ_NBR).Append("'")
               .Append(" AND")
               .Append(" b.KEY_CLM_CLAIM_NBR >= ").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_CLAIM_NBR); */
            
                .Append(" AND ")
                .Append(" b.KEY_CLM_BATCH_NBR >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_BATCH_NBR).Append("'")
                .Append(" AND ")
                .Append(" b.KEY_CLM_CLAIM_NBR >= ").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_CLAIM_NBR)            
                .Append(" AND ")
                .Append(" b.KEY_CLM_SERV_CODE >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_SERV_CODE).Append("'")
                .Append(" AND ")
                .Append(" b.KEY_CLM_ADJ_NBR >= '").Append(objF002_CLAIMS_MSTR_DTL.KEY_CLM_ADJ_NBR).Append("'")
                .Append(") x ")
                .Append(" WHERE ROWNUM = 2");

           // sql.Append(" ORDER BY")
           //    .Append(" x.KEY_CLM_BATCH_NBR, x.KEY_CLM_CLAIM_NBR,  x.KEY_CLM_SERV_CODE, x.KEY_CLM_ADJ_NBR  ");
            //.Append(" ORDER BY")
            //.Append("    a.CLMHDR_BATCH_NBR,a.CLMHDR_CLAIM_NBR, a.CLMHDR_ADJ_OMA_CD, a.CLMHDR_ADJ_OMA_SUFF, a.CLMHDR_ADJ_ADJ_NBR");
            //.Append("    b.CLMDTL_BATCH_NBR, b.CLMDTL_CLAIM_NBR, b.CLMDTL_OMA_CD, b.CLMDTL_OMA_SUFF");

          //  Debug.WriteLine(sql.ToString());

            Reader = CoreReader(sql.ToString());
            objF002_CLAIMS_MSTR_DTL = null;

            int ctr = 0;

            while (Reader.Read())
            {
                ctr++;

                if (ctr > 1)
                {

                }
                     
                if (ConvertINT(Reader["ROWNUM"]) == 2) 
                {
                    objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                    {
                        //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                        ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                        /* KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                        KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                        KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                        KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                        KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                        KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                        KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(), */

                        //RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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

                        RecordState = State.UnChanged
                    };
                }
            }

            CloseConnection();
            return objF002_CLAIMS_MSTR_DTL;
        }


        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_HDR_DTL_INNERJOIN_UsingTop(int rows = 3000,bool isClosedConnection = true, SqlConnection objConn = null)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();
            
            sql.Append("SELECT TOP ").Append(rows)
              .Append("  a.ROWID as 'ROWID_HDR'")
              .Append(" ,a.[CLMHDR_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_CLAIM_NBR]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
              .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
              .Append(" ,a.[CLMHDR_BATCH_TYPE]")
              .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
              .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
              .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
              .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
              .Append(" ,a.[CLMHDR_DIAG_CD]")
              .Append(" ,a.[CLMHDR_LOC]")
              .Append(" ,a.[CLMHDR_HOSP]")
              .Append(" ,a.[CLMHDR_AGENT_CD]")
              .Append(" ,a.[CLMHDR_ADJ_CD]")
              .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
              .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
              .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
              .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
              .Append(" ,a.[CLMHDR_REFERENCE]")
              .Append(" ,a.[CLMHDR_DATE_ADMIT]")
              .Append(" ,a.[CLMHDR_DOC_DEPT]")
              .Append(" ,a.[CLMHDR_MSG_NBR]")
              .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
              .Append(" ,a.[CLMHDR_SUB_NBR]")
              .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
              .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
              .Append(" ,a.[FILLER]")
              .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
              .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
              .Append(" ,a.[CLMHDR_CYCLE_NBR]")
              .Append(" ,a.[CLMHDR_DATE_SYS]")
              .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
              .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
              .Append(" ,a.[CLMHDR_STATUS_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
              .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
              .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
              .Append(" ,a.[CLMHDR_SERV_DATE]")
              .Append(" ,a.[CLMHDR_ELIG_ERROR]")
              .Append(" ,a.[CLMHDR_ELIG_STATUS]")
              .Append(" ,a.[CLMHDR_SERV_ERROR]")
              .Append(" ,a.[CLMHDR_SERV_STATUS]")
              .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")
              /*.Append(" ,a.[KEY_CLM_BATCH_NBR]")
              .Append(" ,a.[KEY_CLM_CLAIM_NBR]")
              .Append(" ,a.[KEY_CLM_SERV_CODE]")
              .Append(" ,a.[KEY_CLM_ADJ_NBR]")
              .Append(" ,a.[KEY_P_CLM_TYPE]")
              .Append(" ,a.[KEY_P_CLM_DATA]") */
              .Append(" ,a.[KEY_CLM_TYPE]")
             .Append(" ,a.[KEY_CLM_BATCH_NBR]")
             .Append(" ,a.[KEY_CLM_CLAIM_NBR]")
             .Append(" ,a.[KEY_CLM_SERV_CODE]")
             .Append(" ,a.[KEY_CLM_ADJ_NBR]")
             .Append(" ,a.[KEY_P_CLM_TYPE]")
             .Append(" ,a.[KEY_P_CLM_DATA]") 

              .Append(" ,b.[CLMDTL_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_CLAIM_NBR]")
              .Append(" ,b.[CLMDTL_OMA_CD]")
              .Append(" ,b.[CLMDTL_OMA_SUFF]")
              .Append(" ,b.[CLMDTL_ADJ_NBR]")
              .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
              .Append(" ,b.[CLMDTL_AGENT_CD]")
              .Append(" ,b.[CLMDTL_ADJ_CD]")
              .Append(" ,b.[CLMDTL_NBR_SERV]")
              .Append(" ,b.[CLMDTL_SV_YY]")
              .Append(" ,b.[CLMDTL_SV_MM]")
              .Append(" ,b.[CLMDTL_SV_DD]")
              /*.Append(" ,b.[CLMDTL_SV_NBR1]")
              .Append(" ,b.[CLMDTL_SV_NBR2]")
              .Append(" ,b.[CLMDTL_SV_NBR3]")
              .Append(" ,b.[CLMDTL_SV_DAY1]")
              .Append(" ,b.[CLMDTL_SV_DAY2]")
              .Append(" ,b.[CLMDTL_SV_DAY3]")
              .Append(" ,b.[CLMDTL_SV_NBR_1]")
              .Append(" ,b.[CLMDTL_SV_DAY_1]")
              .Append(" ,b.[CLMDTL_SV_NBR_2]")
              .Append(" ,b.[CLMDTL_SV_DAY_2]")
              .Append(" ,b.[CLMDTL_SV_NBR_3]") 
              .Append(" ,b.[CLMDTL_SV_DAY_3]") */
              .Append(" ,b.CLMDTL_CONSEC_DATES_R")
              .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
              .Append(" ,b.[CLMDTL_FEE_OMA]")
              .Append(" ,b.[CLMDTL_FEE_OHIP]")
              .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
              .Append(" ,b.[CLMDTL_CYCLE_NBR]")
              .Append(" ,b.[CLMDTL_DIAG_CD]")
              .Append(" ,b.[CLMDTL_LINE_NO]")
              .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
              .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
              .Append(" ,b.[CLMDTL_DESC]")
              .Append(" ,b.[CLMDTL_FILLER9]")
              .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
              /*.Append(" ,b.[KEY_CLM_TYPE]")
              .Append(" ,b.[KEY_CLM_BATCH_NBR]")
              .Append(" ,b.[KEY_CLM_CLAIM_NBR]")
              .Append(" ,b.[KEY_CLM_SERV_CODE]")
              .Append(" ,b.[KEY_CLM_ADJ_NBR]")
              .Append(" ,b.[KEY_P_CLM_TYPE]")
              .Append(" ,b.[KEY_P_CLM_DATA]") */

              .Append(" FROM")
              .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
              .Append("      INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.KEY_CLM_BATCH_NBR = b.KEY_CLM_BATCH_NBR ")
              .Append("                                                    AND a.KEY_CLM_CLAIM_NBR = b.KEY_CLM_CLAIM_NBR")
              .Append(" WHERE")
              .Append("   1= 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append("   AND")
               .Append("    b.[KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_batch_nbr))
            {
                sql.Append("    AND ")
                .Append("    a.CLMHDR_BATCH_NBR >= '").Append(WhereClmhdr_batch_nbr).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append("    AND ")
               .Append("    a.KEY_CLM_BATCH_NBR >= '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereKey_clm_claim_nbr != null)
            {
                sql.Append("    AND ")
                .Append("    a.[KEY_CLM_CLAIM_NBR] >= ").Append(WhereKey_clm_claim_nbr);
            }

            if (WhereClmhdr_claim_nbr > 0)
            {
                sql.Append(" AND")
               .Append(" a.CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr);
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_cd))
            {
                sql.Append(" AND")
                .Append(" a.CLMHDR_ADJ_OMA_CD >= '").Append(WhereClmhdr_adj_oma_cd).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_suff))
            {
                sql.Append(" AND")
                .Append("  a.CLMHDR_ADJ_OMA_SUFF >= '").Append(WhereClmhdr_adj_oma_suff).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_adj_nbr))
            {
                sql.Append(" AND")
                .Append("  a.CLMHDR_ADJ_ADJ_NBR >= '").Append(WhereClmhdr_adj_adj_nbr).Append("'");
            }

            sql.Append(" ORDER BY")
           // .Append("    a.CLMHDR_BATCH_NBR,a.CLMHDR_CLAIM_NBR, a.CLMHDR_ADJ_OMA_CD, a.CLMHDR_ADJ_OMA_SUFF, a.CLMHDR_ADJ_ADJ_NBR");
           // .Append(" a.[KEY_CLM_TYPE],a.[KEY_CLM_BATCH_NBR],a.[KEY_CLM_CLAIM_NBR],a.CLMHDR_ADJ_OMA_CD, a.CLMHDR_ADJ_OMA_SUFF, a.CLMHDR_ADJ_ADJ_NBR");
           .Append(" a.[KEY_CLM_TYPE],a.[KEY_CLM_BATCH_NBR],a.[KEY_CLM_CLAIM_NBR]");


         //    Debug.WriteLine(sql.ToString());

            if (!isClosedConnection)
            {
                Reader = CoreReader(sql.ToString(),objConn);
            } else
            {
                Reader = CoreReader(sql.ToString());
            }

           ObservableCollection<F002_CLAIMS_MSTR_DTL> F002_CLAIMS_MSTR_DTL_Collection = null;
            F002_CLAIMS_MSTR_DTL_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
                    //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                    /* KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(), */

                    //RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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

                    RecordState = State.UnChanged                   
                };
                F002_CLAIMS_MSTR_DTL_Collection.Add(objF002_CLAIMS_MSTR_DTL);
            }

            CloseConnection(isClosedConnection);
            return F002_CLAIMS_MSTR_DTL_Collection;
        }

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_HDR_DTL_INNERJOIN_Equals_UsingTop(int rows = 3000, bool isClosedConnection = true, SqlConnection objConn = null)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP ").Append(rows)
              .Append("  a.ROWID as 'ROWID_HDR'")
              .Append(" ,a.[CLMHDR_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_CLAIM_NBR]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
              .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
              .Append(" ,a.[CLMHDR_BATCH_TYPE]")
              .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
              .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
              .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
              .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
              .Append(" ,a.[CLMHDR_DIAG_CD]")
              .Append(" ,a.[CLMHDR_LOC]")
              .Append(" ,a.[CLMHDR_HOSP]")
              .Append(" ,a.[CLMHDR_AGENT_CD]")
              .Append(" ,a.[CLMHDR_ADJ_CD]")
              .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
              .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
              .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
              .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
              .Append(" ,a.[CLMHDR_REFERENCE]")
              .Append(" ,a.[CLMHDR_DATE_ADMIT]")
              .Append(" ,a.[CLMHDR_DOC_DEPT]")
              .Append(" ,a.[CLMHDR_MSG_NBR]")
              .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
              .Append(" ,a.[CLMHDR_SUB_NBR]")
              .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
              .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
              .Append(" ,a.[FILLER]")
              .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
              .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
              .Append(" ,a.[CLMHDR_CYCLE_NBR]")
              .Append(" ,a.[CLMHDR_DATE_SYS]")
              .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
              .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
              .Append(" ,a.[CLMHDR_STATUS_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
              .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
              .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
              .Append(" ,a.[CLMHDR_SERV_DATE]")
              .Append(" ,a.[CLMHDR_ELIG_ERROR]")
              .Append(" ,a.[CLMHDR_ELIG_STATUS]")
              .Append(" ,a.[CLMHDR_SERV_ERROR]")
              .Append(" ,a.[CLMHDR_SERV_STATUS]")
              .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")
              /*.Append(" ,a.[KEY_CLM_BATCH_NBR]")
              .Append(" ,a.[KEY_CLM_CLAIM_NBR]")
              .Append(" ,a.[KEY_CLM_SERV_CODE]")
              .Append(" ,a.[KEY_CLM_ADJ_NBR]")
              .Append(" ,a.[KEY_P_CLM_TYPE]")
              .Append(" ,a.[KEY_P_CLM_DATA]") */
              .Append(" ,a.[KEY_CLM_TYPE]")
             .Append(" ,a.[KEY_CLM_BATCH_NBR]")
             .Append(" ,a.[KEY_CLM_CLAIM_NBR]")
             .Append(" ,a.[KEY_CLM_SERV_CODE]")
             .Append(" ,a.[KEY_CLM_ADJ_NBR]")
             .Append(" ,a.[KEY_P_CLM_TYPE]")
             .Append(" ,a.[KEY_P_CLM_DATA]")

              .Append(" ,b.[CLMDTL_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_CLAIM_NBR]")
              .Append(" ,b.[CLMDTL_OMA_CD]")
              .Append(" ,b.[CLMDTL_OMA_SUFF]")
              .Append(" ,b.[CLMDTL_ADJ_NBR]")
              .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
              .Append(" ,b.[CLMDTL_AGENT_CD]")
              .Append(" ,b.[CLMDTL_ADJ_CD]")
              .Append(" ,b.[CLMDTL_NBR_SERV]")
              .Append(" ,b.[CLMDTL_SV_YY]")
              .Append(" ,b.[CLMDTL_SV_MM]")
              .Append(" ,b.[CLMDTL_SV_DD]")
              /*.Append(" ,b.[CLMDTL_SV_NBR1]")
              .Append(" ,b.[CLMDTL_SV_NBR2]")
              .Append(" ,b.[CLMDTL_SV_NBR3]")
              .Append(" ,b.[CLMDTL_SV_DAY1]")
              .Append(" ,b.[CLMDTL_SV_DAY2]")
              .Append(" ,b.[CLMDTL_SV_DAY3]")
              .Append(" ,b.[CLMDTL_SV_NBR_1]")
              .Append(" ,b.[CLMDTL_SV_DAY_1]")
              .Append(" ,b.[CLMDTL_SV_NBR_2]")
              .Append(" ,b.[CLMDTL_SV_DAY_2]")
              .Append(" ,b.[CLMDTL_SV_NBR_3]") 
              .Append(" ,b.[CLMDTL_SV_DAY_3]") */
              .Append(" ,b.CLMDTL_CONSEC_DATES_R")
              .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
              .Append(" ,b.[CLMDTL_FEE_OMA]")
              .Append(" ,b.[CLMDTL_FEE_OHIP]")
              .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
              .Append(" ,b.[CLMDTL_CYCLE_NBR]")
              .Append(" ,b.[CLMDTL_DIAG_CD]")
              .Append(" ,b.[CLMDTL_LINE_NO]")
              .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
              .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
              .Append(" ,b.[CLMDTL_DESC]")
              .Append(" ,b.[CLMDTL_FILLER9]")
              .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")
              /*.Append(" ,b.[KEY_CLM_TYPE]")
              .Append(" ,b.[KEY_CLM_BATCH_NBR]")
              .Append(" ,b.[KEY_CLM_CLAIM_NBR]")
              .Append(" ,b.[KEY_CLM_SERV_CODE]")
              .Append(" ,b.[KEY_CLM_ADJ_NBR]")
              .Append(" ,b.[KEY_P_CLM_TYPE]")
              .Append(" ,b.[KEY_P_CLM_DATA]") */

              .Append(" FROM")
              .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
              .Append("      INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.KEY_CLM_BATCH_NBR = b.KEY_CLM_BATCH_NBR ")
              .Append("                                                    AND a.KEY_CLM_CLAIM_NBR = b.KEY_CLM_CLAIM_NBR")
              .Append(" WHERE")
              .Append("   1= 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append("   AND")
               .Append("    b.[KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
            }
            
            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append("    AND ")
               .Append("    a.KEY_CLM_BATCH_NBR = '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereKey_clm_claim_nbr != null)
            {
                sql.Append("    AND ")
                .Append("    a.[KEY_CLM_CLAIM_NBR] = ").Append(WhereKey_clm_claim_nbr);
            }
                                                
            sql.Append(" ORDER BY")           
           .Append(" a.[KEY_CLM_TYPE],a.[KEY_CLM_BATCH_NBR],a.[KEY_CLM_CLAIM_NBR]");


            Debug.WriteLine(sql.ToString());

            if (!isClosedConnection)
            {
                Reader = CoreReader(sql.ToString(), objConn);
            }
            else
            {
                Reader = CoreReader(sql.ToString());
            }

            ObservableCollection<F002_CLAIMS_MSTR_DTL> F002_CLAIMS_MSTR_DTL_Collection = null;
            F002_CLAIMS_MSTR_DTL_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
                    //RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                    /* KEY_CLM_TYPE = Reader["KEY_CLM_TYPE"].ToString(),
                    KEY_CLM_BATCH_NBR = Reader["KEY_CLM_BATCH_NBR"].ToString(),
                    KEY_CLM_CLAIM_NBR = ConvertDEC(Reader["KEY_CLM_CLAIM_NBR"]),
                    KEY_CLM_SERV_CODE = Reader["KEY_CLM_SERV_CODE"].ToString(),
                    KEY_CLM_ADJ_NBR = Reader["KEY_CLM_ADJ_NBR"].ToString(),
                    KEY_P_CLM_TYPE = Reader["KEY_P_CLM_TYPE"].ToString(),
                    KEY_P_CLM_DATA = Reader["KEY_P_CLM_DATA"].ToString(), */

                    //RowCheckSum = Convert.ToInt32(Reader["ROWCHECKSUM"]),
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

                    RecordState = State.UnChanged
                };
                F002_CLAIMS_MSTR_DTL_Collection.Add(objF002_CLAIMS_MSTR_DTL);
            }

            CloseConnection(isClosedConnection);
            return F002_CLAIMS_MSTR_DTL_Collection;
        }

        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_HDR_DTL_INNERJOIN(bool isClosedConnection = true, SqlConnection objConn = null)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT ")
              .Append("  a.ROWID as 'ROWID_HDR'")
              .Append(" ,a.[CLMHDR_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_CLAIM_NBR]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_CD]")
              .Append(" ,a.[CLMHDR_ADJ_OMA_SUFF]")
              .Append(" ,a.[CLMHDR_ADJ_ADJ_NBR]")
              .Append(" ,a.[CLMHDR_BATCH_TYPE]")
              .Append(" ,a.[CLMHDR_ADJ_CD_SUB_TYPE]")
              .Append(" ,a.[CLMHDR_DOC_NBR_OHIP]")
              .Append(" ,a.[CLMHDR_DOC_SPEC_CD]")
              .Append(" ,a.[CLMHDR_REFER_DOC_NBR]")
              .Append(" ,a.[CLMHDR_DIAG_CD]")
              .Append(" ,a.[CLMHDR_LOC]")
              .Append(" ,a.[CLMHDR_HOSP]")
              .Append(" ,a.[CLMHDR_AGENT_CD]")
              .Append(" ,a.[CLMHDR_ADJ_CD]")
              .Append(" ,a.[CLMHDR_TAPE_SUBMIT_IND]")
              .Append(" ,a.[CLMHDR_I_O_PAT_IND]")
              .Append(" ,a.[CLMHDR_PAT_KEY_TYPE]")
              .Append(" ,a.[CLMHDR_PAT_KEY_DATA]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM6]")
              .Append(" ,a.[CLMHDR_PAT_ACRONYM3]")
              .Append(" ,a.[CLMHDR_REFERENCE]")
              .Append(" ,a.[CLMHDR_DATE_ADMIT]")
              .Append(" ,a.[CLMHDR_DOC_DEPT]")
              .Append(" ,a.[CLMHDR_MSG_NBR]")
              .Append(" ,a.[CLMHDR_REPRINT_FLAG]")
              .Append(" ,a.[CLMHDR_SUB_NBR]")
              .Append(" ,a.[CLMHDR_AUTO_LOGOUT]")
              .Append(" ,a.[CLMHDR_FEE_COMPLEX]")
              .Append(" ,a.[FILLER]")
              .Append(" ,a.[CLMHDR_CURR_PAYMENT]")
              .Append(" ,a.[CLMHDR_DATE_PERIOD_END]")
              .Append(" ,a.[CLMHDR_CYCLE_NBR]")
              .Append(" ,a.[CLMHDR_DATE_SYS]")
              .Append(" ,a.[CLMHDR_AMT_TECH_BILLED]")
              .Append(" ,a.[CLMHDR_AMT_TECH_PAID]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OMA]")
              .Append(" ,a.[CLMHDR_TOT_CLAIM_AR_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_AND_TAPE_PAYMENTS]")
              .Append(" ,a.[CLMHDR_STATUS_OHIP]")
              .Append(" ,a.[CLMHDR_MANUAL_REVIEW]")
              .Append(" ,a.[CLMHDR_SUBMIT_DATE]")
              .Append(" ,a.[CLMHDR_CONFIDENTIAL_FLAG]")
              .Append(" ,a.[CLMHDR_SERV_DATE]")
              .Append(" ,a.[CLMHDR_ELIG_ERROR]")
              .Append(" ,a.[CLMHDR_ELIG_STATUS]")
              .Append(" ,a.[CLMHDR_SERV_ERROR]")
              .Append(" ,a.[CLMHDR_SERV_STATUS]")
              .Append(" ,a.[CLMHDR_ORIG_BATCH_NBR]")
              .Append(" ,a.[CLMHDR_ORIG_CLAIM_NBR]")
              .Append(" ,a.[KEY_CLM_TYPE]")
              .Append(" ,a.[KEY_CLM_BATCH_NBR]")
              .Append(" ,a.[KEY_CLM_CLAIM_NBR]")
              .Append(" ,a.[KEY_CLM_SERV_CODE]")
              .Append(" ,a.[KEY_CLM_ADJ_NBR]")
              .Append(" ,a.[KEY_P_CLM_TYPE]")
              .Append(" ,a.[KEY_P_CLM_DATA]")

              .Append(" ,b.[CLMDTL_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_CLAIM_NBR]")
              .Append(" ,b.[CLMDTL_OMA_CD]")
              .Append(" ,b.[CLMDTL_OMA_SUFF]")
              .Append(" ,b.[CLMDTL_ADJ_NBR]")
              .Append(" ,b.[CLMDTL_REV_GROUP_CD]")
              .Append(" ,b.[CLMDTL_AGENT_CD]")
              .Append(" ,b.[CLMDTL_ADJ_CD]")
              .Append(" ,b.[CLMDTL_NBR_SERV]")
              .Append(" ,b.[CLMDTL_SV_YY]")
              .Append(" ,b.[CLMDTL_SV_MM]")
              .Append(" ,b.[CLMDTL_SV_DD]")
              .Append(" ,b.CLMDTL_CONSEC_DATES_R")
              .Append(" ,b.[CLMDTL_AMT_TECH_BILLED]")
              .Append(" ,b.[CLMDTL_FEE_OMA]")
              .Append(" ,b.[CLMDTL_FEE_OHIP]")
              .Append(" ,b.[CLMDTL_DATE_PERIOD_END]")
              .Append(" ,b.[CLMDTL_CYCLE_NBR]")
              .Append(" ,b.[CLMDTL_DIAG_CD]")
              .Append(" ,b.[CLMDTL_LINE_NO]")
              .Append(" ,b.[CLMDTL_RESUBMIT_FLAG]")
              .Append(" ,b.[CLMDTL_RESERVE_FOR_FUTURE]")
              .Append(" ,b.[CLMDTL_DESC]")
              .Append(" ,b.[CLMDTL_FILLER9]")
              .Append(" ,b.[CLMDTL_ORIG_BATCH_NBR]")
              .Append(" ,b.[CLMDTL_ORIG_CLAIM_NBR_IN_BATCH]")

              .Append(" FROM")
              .Append(" [INDEXED].F002_CLAIMS_MSTR_HDR a  WITH (NOLOCK) ")
              .Append(" INNER JOIN  [INDEXED].[F002_CLAIMS_MSTR_DTL] b  WITH (NOLOCK)  ON a.KEY_CLM_BATCH_NBR = b.KEY_CLM_BATCH_NBR ")
              .Append(" AND a.KEY_CLM_CLAIM_NBR = b.KEY_CLM_CLAIM_NBR")
              .Append(" WHERE")
              .Append(" 1= 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append(" AND ")
               .Append("b.[KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_batch_nbr))
            {
                sql.Append(" AND ")
                .Append("a.CLMHDR_BATCH_NBR = '").Append(WhereClmhdr_batch_nbr).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append(" AND ")
               .Append("a.KEY_CLM_BATCH_NBR = '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereKey_clm_claim_nbr != null)
            {
                sql.Append(" AND ")
                .Append(" a.[KEY_CLM_CLAIM_NBR] >= ").Append(WhereKey_clm_claim_nbr);
            }

            if (WhereClmhdr_claim_nbr > 0)
            {
                sql.Append(" AND ")
               .Append("a.CLMHDR_CLAIM_NBR >= ").Append(WhereClmhdr_claim_nbr);
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_cd))
            {
                sql.Append(" AND ")
                .Append("a.CLMHDR_ADJ_OMA_CD >= '").Append(WhereClmhdr_adj_oma_cd).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_oma_suff))
            {
                sql.Append(" AND ")
                .Append("a.CLMHDR_ADJ_OMA_SUFF >= '").Append(WhereClmhdr_adj_oma_suff).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereClmhdr_adj_adj_nbr))
            {
                sql.Append(" AND ")
                .Append("a.CLMHDR_ADJ_ADJ_NBR >= '").Append(WhereClmhdr_adj_adj_nbr).Append("'");
            }

            sql.Append(" ORDER BY")
           .Append(" a.[KEY_CLM_TYPE],a.[KEY_CLM_BATCH_NBR],a.[KEY_CLM_CLAIM_NBR],b.[CLMDTL_OMA_CD],b.[CLMDTL_OMA_SUFF],b.[CLMDTL_ADJ_NBR]");

            //  Debug.WriteLine(sql.ToString());

            if (!isClosedConnection)
            {
                Reader = CoreReader(sql.ToString(), objConn);
            }
            else
            {
                Reader = CoreReader(sql.ToString());
            }

            ObservableCollection<F002_CLAIMS_MSTR_DTL> F002_CLAIMS_MSTR_DTL_Collection = null;
            F002_CLAIMS_MSTR_DTL_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
                    ROWID_HDR = (Guid)Reader["ROWID_HDR"],
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
                };
                F002_CLAIMS_MSTR_DTL_Collection.Add(objF002_CLAIMS_MSTR_DTL);
            }

            CloseConnection(isClosedConnection);
            return F002_CLAIMS_MSTR_DTL_Collection;
        }

        public void CloseCurrentConnection()
        {
            CloseConnection();
        }



        public ObservableCollection<F002_CLAIMS_MSTR_DTL> Collection_Claims_Detail_Using_Header(int rows = 100, bool isClosedConnection = true, SqlConnection objConn = null)
        {

            StringBuilder sql = null;
            sql = new StringBuilder();

            sql.Append("SELECT TOP ").Append(rows)
              .Append("  ROWID as 'ROWID'")
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
              .Append(" WHERE")
              .Append(" 1 = 1");

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_type))
            {
                sql.Append(" AND")
               .Append(" [KEY_CLM_TYPE] = '").Append(WhereKey_clm_type).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WhereKey_clm_batch_nbr))
            {
                sql.Append(" AND")
               .Append(" KEY_CLM_BATCH_NBR = '").Append(WhereKey_clm_batch_nbr).Append("'");
            }

            if (WhereKey_clm_claim_nbr != null)
            {
                sql.Append(" AND")
                .Append(" [KEY_CLM_CLAIM_NBR] = ").Append(WhereKey_clm_claim_nbr);
            }

            sql.Append(" ORDER BY")
           .Append(" [KEY_CLM_TYPE], [KEY_CLM_BATCH_NBR], [KEY_CLM_CLAIM_NBR]");


            Debug.WriteLine(sql.ToString());

            if (!isClosedConnection)
            {
                Reader = CoreReader(sql.ToString(), objConn);
            }
            else
            {
                Reader = CoreReader(sql.ToString());
            }

            ObservableCollection<F002_CLAIMS_MSTR_DTL> F002_CLAIMS_MSTR_DTL_Collection = null;
            F002_CLAIMS_MSTR_DTL_Collection = new ObservableCollection<F002_CLAIMS_MSTR_DTL>();

            while (Reader.Read())
            {
                F002_CLAIMS_MSTR_DTL objF002_CLAIMS_MSTR_DTL = null;
                objF002_CLAIMS_MSTR_DTL = new F002_CLAIMS_MSTR_DTL
                {
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
                };
                F002_CLAIMS_MSTR_DTL_Collection.Add(objF002_CLAIMS_MSTR_DTL);
            }

            CloseConnection(isClosedConnection);
            return F002_CLAIMS_MSTR_DTL_Collection;
        }

        public F002_CLAIMS_MSTR_DTL ShallowCopyClone()
        {
            return (F002_CLAIMS_MSTR_DTL)this.MemberwiseClone();
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

            if (WhereKey_clm_claim_nbr > 0)
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
        #endregion


    }


}
