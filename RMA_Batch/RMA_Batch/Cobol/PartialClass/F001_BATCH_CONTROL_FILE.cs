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
    public partial class F001_BATCH_CONTROL_FILE
    {

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file = null)
        {
            if (f001_batch_control_file != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    _whereBatctrl_batch_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_clinic_nbr;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file;
                    }
                }
            }

            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[BATCTRL_BATCH_NBR]")
               .Append(" ,[BATCTRL_BATCH_TYPE]")
               .Append(" ,[BATCTRL_ADJ_CD]")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE]")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR]")
               .Append(" ,[BATCTRL_CLINIC_NBR]")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP]")
               .Append(" ,[BATCTRL_HOSP]")
               .Append(" ,[BATCTRL_LOC]")
               .Append(" ,[BATCTRL_AGENT_CD]")
               .Append(" ,[BATCTRL_I_O_PAT_IND]")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED]")
               .Append(" ,[BATCTRL_DATE_PERIOD_END]")
               .Append(" ,[BATCTRL_CYCLE_NBR]")
               .Append(" ,[BATCTRL_AMT_EST]")
               .Append(" ,[BATCTRL_AMT_ACT]")
               .Append(" ,[BATCTRL_SVC_EST]")
               .Append(" ,[BATCTRL_SVC_ACT]")
               .Append(" ,[BATCTRL_AR_YY_MM]")
               .Append(" ,[BATCTRL_CALC_AR_DUE]")
               .Append(" ,[BATCTRL_CALC_TOT_REV]")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT]")
               .Append(" ,[BATCTRL_BATCH_STATUS]")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" BATCTRL_CLINIC_NBR >= '").Append(WhereBatctrl_clinic_nbr).Append("'")
               .Append(" ORDER BY  BATCTRL_CLINIC_NBR");

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                   // ROWID = (Guid)Reader["ROWID"],
                    BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString(),
                    BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
                    BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
                    BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
                    BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
                    BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString(),
                    BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
                    BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString(),
                    BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString(),
                    BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
                    BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
                    BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
                    BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
                    BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
                    BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
                    BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
                    BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
                    BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
                    BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString(),
                    BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
                    BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
                    BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
                    BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
                    BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),
                    
                    _whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr,
                    _whereBatctrl_batch_type = WhereBatctrl_batch_type,
                    _whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
                    _whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type,
                    _whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr,
                    _whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr,
                    _whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip,
                    _whereBatctrl_hosp = WhereBatctrl_hosp,
                    _whereBatctrl_loc = WhereBatctrl_loc,
                    _whereBatctrl_agent_cd = WhereBatctrl_agent_cd,
                    _whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind,
                    _whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered,
                    _whereBatctrl_date_period_end = WhereBatctrl_date_period_end,
                    _whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr,
                    _whereBatctrl_amt_est = WhereBatctrl_amt_est,
                    _whereBatctrl_amt_act = WhereBatctrl_amt_act,
                    _whereBatctrl_svc_est = WhereBatctrl_svc_est,
                    _whereBatctrl_svc_act = WhereBatctrl_svc_act,
                    _whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm,
                    _whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due,
                    _whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev,
                    _whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot,
                    _whereBatctrl_batch_status = WhereBatctrl_batch_status,
                    _whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch,
                    _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }


        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_Using_Start_Batctrl_bat_clinic_nbr_1_2(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file = null)
        {
            if (f001_batch_control_file != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    _whereBatctrl_batch_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_batch_nbr;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file;
                    }
                }
            }

            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[BATCTRL_BATCH_NBR]")
               .Append(" ,[BATCTRL_BATCH_TYPE]")
               .Append(" ,[BATCTRL_ADJ_CD]")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE]")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR]")
               .Append(" ,[BATCTRL_CLINIC_NBR]")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP]")
               .Append(" ,[BATCTRL_HOSP]")
               .Append(" ,[BATCTRL_LOC]")
               .Append(" ,[BATCTRL_AGENT_CD]")
               .Append(" ,[BATCTRL_I_O_PAT_IND]")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED]")
               .Append(" ,[BATCTRL_DATE_PERIOD_END]")
               .Append(" ,[BATCTRL_CYCLE_NBR]")
               .Append(" ,[BATCTRL_AMT_EST]")
               .Append(" ,[BATCTRL_AMT_ACT]")
               .Append(" ,[BATCTRL_SVC_EST]")
               .Append(" ,[BATCTRL_SVC_ACT]")
               .Append(" ,[BATCTRL_AR_YY_MM]")
               .Append(" ,[BATCTRL_CALC_AR_DUE]")
               .Append(" ,[BATCTRL_CALC_TOT_REV]")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT]")
               .Append(" ,[BATCTRL_BATCH_STATUS]")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" LEFT(BATCTRL_BATCH_NBR,2) >= ").Append(WhereBatctrl_batch_nbr)
               .Append(" ORDER BY  BATCTRL_BATCH_NBR");

            // 01  batctrl-rec.
            //     05  batctrl-batch - nbr.
            //     10  batctrl-bat-clinic-nbr-1-2      pic 99.
            //     10  batctrl-bat-doc-nbr         pic x(3).
            //           10  batctrl-bat-week-day.
            //               15  batctrl-bat-week        pic 99.
            //               15  batctrl-bat-day         pic 9.
            //           10  batctrl-bat-week-day-r redefines batctrl-bat-week-day

            Debug.WriteLine(sql.ToString());

                  Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),                    
                    BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString(),
                    BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
                    BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
                    BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
                    BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
                    BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString(),
                    BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
                    BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString(),
                    BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString(),
                    BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
                    BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
                    BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
                    BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
                    BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
                    BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
                    BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
                    BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
                    BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
                    BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString(),
                    BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
                    BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
                    BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
                    BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
                    BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),
                    
                    _whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr,
                    _whereBatctrl_batch_type = WhereBatctrl_batch_type,
                    _whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
                    _whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type,
                    _whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr,
                    _whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr,
                    _whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip,
                    _whereBatctrl_hosp = WhereBatctrl_hosp,
                    _whereBatctrl_loc = WhereBatctrl_loc,
                    _whereBatctrl_agent_cd = WhereBatctrl_agent_cd,
                    _whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind,
                    _whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered,
                    _whereBatctrl_date_period_end = WhereBatctrl_date_period_end,
                    _whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr,
                    _whereBatctrl_amt_est = WhereBatctrl_amt_est,
                    _whereBatctrl_amt_act = WhereBatctrl_amt_act,
                    _whereBatctrl_svc_est = WhereBatctrl_svc_est,
                    _whereBatctrl_svc_act = WhereBatctrl_svc_act,
                    _whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm,
                    _whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due,
                    _whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev,
                    _whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot,
                    _whereBatctrl_batch_status = WhereBatctrl_batch_status,
                    _whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch,
                    _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;
        }

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_Using_Start_Key_BatCtrl_File(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file = null)
        {
            if (f001_batch_control_file != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    _whereBatctrl_batch_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_batch_nbr;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file;
                    }
                }
            }

            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[BATCTRL_BATCH_NBR]")
               .Append(" ,[BATCTRL_BATCH_TYPE]")
               .Append(" ,[BATCTRL_ADJ_CD]")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE]")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR]")
               .Append(" ,[BATCTRL_CLINIC_NBR]")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP]")
               .Append(" ,[BATCTRL_HOSP]")
               .Append(" ,[BATCTRL_LOC]")
               .Append(" ,[BATCTRL_AGENT_CD]")
               .Append(" ,[BATCTRL_I_O_PAT_IND]")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED]")
               .Append(" ,[BATCTRL_DATE_PERIOD_END]")
               .Append(" ,[BATCTRL_CYCLE_NBR]")
               .Append(" ,[BATCTRL_AMT_EST]")
               .Append(" ,[BATCTRL_AMT_ACT]")
               .Append(" ,[BATCTRL_SVC_EST]")
               .Append(" ,[BATCTRL_SVC_ACT]")
               .Append(" ,[BATCTRL_AR_YY_MM]")
               .Append(" ,[BATCTRL_CALC_AR_DUE]")
               .Append(" ,[BATCTRL_CALC_TOT_REV]")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT]")
               .Append(" ,[BATCTRL_BATCH_STATUS]")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]   ")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE] WITH (NOLOCK)")
               .Append(" WHERE 1 = 1");

            /* sql.Append(" AND ")   // for debugging only
             .Append(" ( LEFT(BATCTRL_BATCH_NBR,2) = 61")
                .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 62")
                  .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 63")
                 .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 64")
                  .Append(" OR  LEFT(BATCTRL_BATCH_NBR,2) = 66 )"); */

           /* sql.Append(" AND ")   // for debugging only
             .Append("  LEFT(BATCTRL_BATCH_NBR,2) = 73");
             /* .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 71")
                 .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 72")
                .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 73")
                .Append(" OR LEFT(BATCTRL_BATCH_NBR,2) = 74")
                 .Append(" OR  LEFT(BATCTRL_BATCH_NBR,2) = 75 )"); */

            if (!string.IsNullOrWhiteSpace(WhereBatctrl_batch_nbr)) {                
                sql.Append(" AND ")
                .Append(" LEFT(BATCTRL_BATCH_NBR,2) >= ").Append(WhereBatctrl_batch_nbr.PadRight(8, ' '))
                .Append(" AND")
                .Append(" SUBSTRING(BATCTRL_BATCH_NBR,3,3) >= '").Append(WhereBatctrl_batch_nbr.PadRight(8, ' ').Substring(2, 3)).Append("'")
                .Append(" AND")
                .Append(" SUBSTRING(BATCTRL_BATCH_NBR,6,2) >= '").Append(WhereBatctrl_batch_nbr.PadRight(8, ' ').Substring(5, 2)).Append("'")
                .Append(" AND")
                .Append(" SUBSTRING(BATCTRL_BATCH_NBR,8,1) >= '").Append(WhereBatctrl_batch_nbr.PadRight(8, ' ').Substring(7, 1)).Append("'");
               }
               if (!String.IsNullOrWhiteSpace(WhereBatctrl_batch_status))
               {
                  sql.Append(" AND ")
                  .Append(" BATCTRL_BATCH_STATUS = '").Append(WhereBatctrl_batch_status).Append("'");
               }
               sql.Append(" ORDER BY  BATCTRL_BATCH_NBR ");
            

            // 01  batctrl-rec.
            //     05  batctrl-batch - nbr.
            //     10  batctrl-bat-clinic-nbr-1-2      pic 99.
            //     10  batctrl-bat-doc-nbr         pic x(3).
            //           10  batctrl-bat-week-day.
            //               15  batctrl-bat-week        pic 99.
            //               15  batctrl-bat-day         pic 9.
            //           10  batctrl-bat-week-day-r redefines batctrl-bat-week-day

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString(),
                    BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
                    BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
                    BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
                    BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
                    BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString(),
                    BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
                    BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString(),
                    BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString(),
                    BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
                    BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
                    BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
                    BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
                    BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
                    BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
                    BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
                    BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
                    BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
                    BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString(),
                    BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
                    BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
                    BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
                    BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
                    BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),

                    _whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr,
                    _whereBatctrl_batch_type = WhereBatctrl_batch_type,
                    _whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
                    _whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type,
                    _whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr,
                    _whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr,
                    _whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip,
                    _whereBatctrl_hosp = WhereBatctrl_hosp,
                    _whereBatctrl_loc = WhereBatctrl_loc,
                    _whereBatctrl_agent_cd = WhereBatctrl_agent_cd,
                    _whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind,
                    _whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered,
                    _whereBatctrl_date_period_end = WhereBatctrl_date_period_end,
                    _whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr,
                    _whereBatctrl_amt_est = WhereBatctrl_amt_est,
                    _whereBatctrl_amt_act = WhereBatctrl_amt_act,
                    _whereBatctrl_svc_est = WhereBatctrl_svc_est,
                    _whereBatctrl_svc_act = WhereBatctrl_svc_act,
                    _whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm,
                    _whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due,
                    _whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev,
                    _whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot,
                    _whereBatctrl_batch_status = WhereBatctrl_batch_status,
                    _whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch,
                    _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;
        }

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_UsingIN(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file = null, bool isUseOrderBy = true)
        {
            if (f001_batch_control_file != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    //_whereBatctrl_batch_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_clinic_nbr;
                    _whereBatctrl_batch_status = objF001_BATCH_CONTROL_FILE._whereBatctrl_batch_status;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file;
                    }
                }
            }

            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[BATCTRL_BATCH_NBR]")
               .Append(" ,[BATCTRL_BATCH_TYPE]")
               .Append(" ,[BATCTRL_ADJ_CD]")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE]")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR]")
               .Append(" ,[BATCTRL_CLINIC_NBR]")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP]")
               .Append(" ,[BATCTRL_HOSP]")
               .Append(" ,[BATCTRL_LOC]")
               .Append(" ,[BATCTRL_AGENT_CD]")
               .Append(" ,[BATCTRL_I_O_PAT_IND]")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED]")
               .Append(" ,[BATCTRL_DATE_PERIOD_END]")
               .Append(" ,[BATCTRL_CYCLE_NBR]")
               .Append(" ,[BATCTRL_AMT_EST]")
               .Append(" ,[BATCTRL_AMT_ACT]")
               .Append(" ,[BATCTRL_SVC_EST]")
               .Append(" ,[BATCTRL_SVC_ACT]")
               .Append(" ,[BATCTRL_AR_YY_MM]")
               .Append(" ,[BATCTRL_CALC_AR_DUE]")
               .Append(" ,[BATCTRL_CALC_TOT_REV]")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT]")
               .Append(" ,[BATCTRL_BATCH_STATUS]")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]  WITH (NOLOCK) ")
               .Append(" WHERE")
               .Append(" 1 = 1");


            // debugging only
           // sql.Append(" AND ")
           //    .Append(" BATCTRL_BATCH_NBR = '2352C148'");  
               


            if (!string.IsNullOrWhiteSpace(WhereBatctrl_batch_status))
            {
                sql.Append(" AND ");
                sql.Append(" BATCTRL_BATCH_STATUS IN ");
                sql.Append("(").Append(WhereBatctrl_batch_status).Append(")");
            } 

            if (isUseOrderBy)
            {
                sql.Append(" ORDER BY  BATCTRL_BATCH_NBR");
            }

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    // ROWID = (Guid)Reader["ROWID"],
                    BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString(),
                    BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
                    BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
                    BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
                    BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
                    BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString(),
                    BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
                    BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString(),
                    BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString(),
                    BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
                    BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
                    BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
                    BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
                    BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
                    BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
                    BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
                    BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
                    BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
                    BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString(),
                    BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
                    BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
                    BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
                    BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
                    BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),

                    _whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr,
                    _whereBatctrl_batch_type = WhereBatctrl_batch_type,
                    _whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
                    _whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type,
                    _whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr,
                    _whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr,
                    _whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip,
                    _whereBatctrl_hosp = WhereBatctrl_hosp,
                    _whereBatctrl_loc = WhereBatctrl_loc,
                    _whereBatctrl_agent_cd = WhereBatctrl_agent_cd,
                    _whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind,
                    _whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered,
                    _whereBatctrl_date_period_end = WhereBatctrl_date_period_end,
                    _whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr,
                    _whereBatctrl_amt_est = WhereBatctrl_amt_est,
                    _whereBatctrl_amt_act = WhereBatctrl_amt_act,
                    _whereBatctrl_svc_est = WhereBatctrl_svc_est,
                    _whereBatctrl_svc_act = WhereBatctrl_svc_act,
                    _whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm,
                    _whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due,
                    _whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev,
                    _whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot,
                    _whereBatctrl_batch_status = WhereBatctrl_batch_status,
                    _whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch,
                    _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_All(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file = null,bool isUseOrderBy = true)
        {
            if (f001_batch_control_file != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {                                      

                    if (f001_batch_control_file.Count() > 0)
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file;
                    }
                }
            }

            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[BATCTRL_BATCH_NBR]")
               .Append(" ,[BATCTRL_BATCH_TYPE]")
               .Append(" ,[BATCTRL_ADJ_CD]")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE]")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR]")
               .Append(" ,[BATCTRL_CLINIC_NBR]")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP]")
               .Append(" ,[BATCTRL_HOSP]")
               .Append(" ,[BATCTRL_LOC]")
               .Append(" ,[BATCTRL_AGENT_CD]")
               .Append(" ,[BATCTRL_I_O_PAT_IND]")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED]")
               .Append(" ,[BATCTRL_DATE_PERIOD_END]")
               .Append(" ,[BATCTRL_CYCLE_NBR]")
               .Append(" ,[BATCTRL_AMT_EST]")
               .Append(" ,[BATCTRL_AMT_ACT]")
               .Append(" ,[BATCTRL_SVC_EST]")
               .Append(" ,[BATCTRL_SVC_ACT]")
               .Append(" ,[BATCTRL_AR_YY_MM]")
               .Append(" ,[BATCTRL_CALC_AR_DUE]")
               .Append(" ,[BATCTRL_CALC_TOT_REV]")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT]")
               .Append(" ,[BATCTRL_BATCH_STATUS]")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]  WITH (NOLOCK) ");

            //  sql.Append(" WHERE BATCTRL_BATCH_NBR = '" + WhereBatctrl_batch_nbr + "'"); // FOR DEBUGGING ONLY...
           // sql.Append(" WHERE BATCTRL_BATCH_NBR IN ('98X23044','98X45003','98X45003','98X95166','98X95167')");

               if (isUseOrderBy) {
                sql.Append(" ORDER BY  BATCTRL_BATCH_NBR");
                }

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    // ROWID = (Guid)Reader["ROWID"],
                    BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString(),
                    BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString(),
                    BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString(),
                    BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
                    BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
                    BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString(),
                    BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
                    BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString(),
                    BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString(),
                    BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
                    BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
                    BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
                    BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
                    BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
                    BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
                    BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
                    BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
                    BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
                    BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString(),
                    BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
                    BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
                    BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
                    BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString(),
                    BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),

                    _whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr,
                    _whereBatctrl_batch_type = WhereBatctrl_batch_type,
                    _whereBatctrl_adj_cd = WhereBatctrl_adj_cd,
                    _whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type,
                    _whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr,
                    _whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr,
                    _whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip,
                    _whereBatctrl_hosp = WhereBatctrl_hosp,
                    _whereBatctrl_loc = WhereBatctrl_loc,
                    _whereBatctrl_agent_cd = WhereBatctrl_agent_cd,
                    _whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind,
                    _whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered,
                    _whereBatctrl_date_period_end = WhereBatctrl_date_period_end,
                    _whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr,
                    _whereBatctrl_amt_est = WhereBatctrl_amt_est,
                    _whereBatctrl_amt_act = WhereBatctrl_amt_act,
                    _whereBatctrl_svc_est = WhereBatctrl_svc_est,
                    _whereBatctrl_svc_act = WhereBatctrl_svc_act,
                    _whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm,
                    _whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due,
                    _whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev,
                    _whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot,
                    _whereBatctrl_batch_status = WhereBatctrl_batch_status,
                    _whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch,
                    _whereChecksum_value = WhereChecksum_value,

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }

    }
}
