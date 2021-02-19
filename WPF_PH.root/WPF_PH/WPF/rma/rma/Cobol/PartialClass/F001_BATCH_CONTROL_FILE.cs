using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;

namespace RmaDAL
{
    public partial class F001_BATCH_CONTROL_FILE
    {

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_UsingStart(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file_Collection = null)
        {
            if (f001_batch_control_file_Collection != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file_Collection.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    WhereBatctrl_clinic_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_clinic_nbr;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file_Collection;
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
               .Append(" ,[BATCTRL_BATCH_NBR],")
               .Append(" ,[BATCTRL_BATCH_TYPE],")
               .Append(" ,[BATCTRL_ADJ_CD],")
               .Append(" ,[BATCTRL_ADJ_CD_SUB_TYPE],")
               .Append(" ,[BATCTRL_LAST_CLAIM_NBR],")
               .Append(" ,[BATCTRL_CLINIC_NBR],")
               .Append(" ,[BATCTRL_DOC_NBR_OHIP],")
               .Append(" ,[BATCTRL_HOSP],")
               .Append(" ,[BATCTRL_LOC],")
               .Append(" ,[BATCTRL_AGENT_CD],")
               .Append(" ,[BATCTRL_I_O_PAT_IND],")
               .Append(" ,[BATCTRL_DATE_BATCH_ENTERED],")
               .Append(" ,[BATCTRL_DATE_PERIOD_END],")
               .Append(" ,[BATCTRL_CYCLE_NBR],")
               .Append(" ,[BATCTRL_AMT_EST],")
               .Append(" ,[BATCTRL_AMT_ACT],")
               .Append(" ,[BATCTRL_SVC_EST],")
               .Append(" ,[BATCTRL_SVC_ACT],")
               .Append(" ,[BATCTRL_AR_YY_MM],")
               .Append(" ,[BATCTRL_CALC_AR_DUE],")
               .Append(" ,[BATCTRL_CALC_TOT_REV],")
               .Append(" ,[BATCTRL_MANUAL_PAY_TOT],")
               .Append(" ,[BATCTRL_BATCH_STATUS],")
               .Append(" ,[BATCTRL_NBR_CLAIMS_IN_BATCH]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]")
               .Append(" WHERE")
               .Append(" BATCTRL_CLINIC_NBR >= ").Append(WhereBatctrl_clinic_nbr)            
               .Append(" ORDER BY  BATCTRL_CLINIC_NBR");

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new F001_BATCH_CONTROL_FILE
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
                    ROWID = (Guid)Reader["ROWID"],
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

                    _whereRowid = WhereRowid,
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

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection_Using_Start_Batctrl_bat_clinic_nbr_1_2(ref bool isRetrieveRecord, ObservableCollection<F001_BATCH_CONTROL_FILE> f001_batch_control_file_Collection = null)
        {
            if (f001_batch_control_file_Collection != null)
            {
                F001_BATCH_CONTROL_FILE objF001_BATCH_CONTROL_FILE = f001_batch_control_file_Collection.FirstOrDefault();
                if (objF001_BATCH_CONTROL_FILE != null)
                {
                    _whereBatctrl_batch_nbr = objF001_BATCH_CONTROL_FILE._whereBatctrl_batch_nbr;

                    if (IsSameSearch())
                    {
                        isRetrieveRecord = false;
                        return f001_batch_control_file_Collection;
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
               .Append(" [INDEXED].[F001_BATCH_CONTROL_FILE]")
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

        public F001_BATCH_CONTROL_FILE ShallowCopyClone()
        {
            return (F001_BATCH_CONTROL_FILE)this.MemberwiseClone();
        }
    }
}
