using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F001_BATCH_CONTROL_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection( Guid? rowid,
															string batctrl_batch_nbr,
															string batctrl_batch_type,
															string batctrl_adj_cd,
															string batctrl_adj_cd_sub_type,
															decimal? batctrl_last_claim_nbrmin,
															decimal? batctrl_last_claim_nbrmax,
															string batctrl_clinic_nbr,
															decimal? batctrl_doc_nbr_ohipmin,
															decimal? batctrl_doc_nbr_ohipmax,
															string batctrl_hosp,
															string batctrl_loc,
															decimal? batctrl_agent_cdmin,
															decimal? batctrl_agent_cdmax,
															string batctrl_i_o_pat_ind,
															string batctrl_date_batch_entered,
															string batctrl_date_period_end,
															decimal? batctrl_cycle_nbrmin,
															decimal? batctrl_cycle_nbrmax,
															decimal? batctrl_amt_estmin,
															decimal? batctrl_amt_estmax,
															decimal? batctrl_amt_actmin,
															decimal? batctrl_amt_actmax,
															decimal? batctrl_svc_estmin,
															decimal? batctrl_svc_estmax,
															decimal? batctrl_svc_actmin,
															decimal? batctrl_svc_actmax,
															string batctrl_ar_yy_mm,
															decimal? batctrl_calc_ar_duemin,
															decimal? batctrl_calc_ar_duemax,
															decimal? batctrl_calc_tot_revmin,
															decimal? batctrl_calc_tot_revmax,
															decimal? batctrl_manual_pay_totmin,
															decimal? batctrl_manual_pay_totmax,
															string batctrl_batch_status,
															decimal? batctrl_nbr_claims_in_batchmin,
															decimal? batctrl_nbr_claims_in_batchmax,
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
					new SqlParameter("BATCTRL_BATCH_NBR",batctrl_batch_nbr),
					new SqlParameter("BATCTRL_BATCH_TYPE",batctrl_batch_type),
					new SqlParameter("BATCTRL_ADJ_CD",batctrl_adj_cd),
					new SqlParameter("BATCTRL_ADJ_CD_SUB_TYPE",batctrl_adj_cd_sub_type),
					new SqlParameter("minBATCTRL_LAST_CLAIM_NBR",batctrl_last_claim_nbrmin),
					new SqlParameter("maxBATCTRL_LAST_CLAIM_NBR",batctrl_last_claim_nbrmax),
					new SqlParameter("BATCTRL_CLINIC_NBR",batctrl_clinic_nbr),
					new SqlParameter("minBATCTRL_DOC_NBR_OHIP",batctrl_doc_nbr_ohipmin),
					new SqlParameter("maxBATCTRL_DOC_NBR_OHIP",batctrl_doc_nbr_ohipmax),
					new SqlParameter("BATCTRL_HOSP",batctrl_hosp),
					new SqlParameter("BATCTRL_LOC",batctrl_loc),
					new SqlParameter("minBATCTRL_AGENT_CD",batctrl_agent_cdmin),
					new SqlParameter("maxBATCTRL_AGENT_CD",batctrl_agent_cdmax),
					new SqlParameter("BATCTRL_I_O_PAT_IND",batctrl_i_o_pat_ind),
					new SqlParameter("BATCTRL_DATE_BATCH_ENTERED",batctrl_date_batch_entered),
					new SqlParameter("BATCTRL_DATE_PERIOD_END",batctrl_date_period_end),
					new SqlParameter("minBATCTRL_CYCLE_NBR",batctrl_cycle_nbrmin),
					new SqlParameter("maxBATCTRL_CYCLE_NBR",batctrl_cycle_nbrmax),
					new SqlParameter("minBATCTRL_AMT_EST",batctrl_amt_estmin),
					new SqlParameter("maxBATCTRL_AMT_EST",batctrl_amt_estmax),
					new SqlParameter("minBATCTRL_AMT_ACT",batctrl_amt_actmin),
					new SqlParameter("maxBATCTRL_AMT_ACT",batctrl_amt_actmax),
					new SqlParameter("minBATCTRL_SVC_EST",batctrl_svc_estmin),
					new SqlParameter("maxBATCTRL_SVC_EST",batctrl_svc_estmax),
					new SqlParameter("minBATCTRL_SVC_ACT",batctrl_svc_actmin),
					new SqlParameter("maxBATCTRL_SVC_ACT",batctrl_svc_actmax),
					new SqlParameter("BATCTRL_AR_YY_MM",batctrl_ar_yy_mm),
					new SqlParameter("minBATCTRL_CALC_AR_DUE",batctrl_calc_ar_duemin),
					new SqlParameter("maxBATCTRL_CALC_AR_DUE",batctrl_calc_ar_duemax),
					new SqlParameter("minBATCTRL_CALC_TOT_REV",batctrl_calc_tot_revmin),
					new SqlParameter("maxBATCTRL_CALC_TOT_REV",batctrl_calc_tot_revmax),
					new SqlParameter("minBATCTRL_MANUAL_PAY_TOT",batctrl_manual_pay_totmin),
					new SqlParameter("maxBATCTRL_MANUAL_PAY_TOT",batctrl_manual_pay_totmax),
					new SqlParameter("BATCTRL_BATCH_STATUS",batctrl_batch_status),
					new SqlParameter("minBATCTRL_NBR_CLAIMS_IN_BATCH",batctrl_nbr_claims_in_batchmin),
					new SqlParameter("maxBATCTRL_NBR_CLAIMS_IN_BATCH",batctrl_nbr_claims_in_batchmax),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F001_BATCH_CONTROL_FILE>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_Search]", parameters);
            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

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
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBatctrl_batch_nbr = Reader["BATCTRL_BATCH_NBR"].ToString(),
					_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString(),
					_originalBatctrl_adj_cd_sub_type = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
					_originalBatctrl_last_claim_nbr = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
					_originalBatctrl_clinic_nbr = Reader["BATCTRL_CLINIC_NBR"].ToString(),
					_originalBatctrl_doc_nbr_ohip = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
					_originalBatctrl_hosp = Reader["BATCTRL_HOSP"].ToString(),
					_originalBatctrl_loc = Reader["BATCTRL_LOC"].ToString(),
					_originalBatctrl_agent_cd = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
					_originalBatctrl_i_o_pat_ind = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
					_originalBatctrl_date_batch_entered = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
					_originalBatctrl_date_period_end = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
					_originalBatctrl_cycle_nbr = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
					_originalBatctrl_amt_est = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
					_originalBatctrl_amt_act = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
					_originalBatctrl_svc_est = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
					_originalBatctrl_svc_act = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
					_originalBatctrl_ar_yy_mm = Reader["BATCTRL_AR_YY_MM"].ToString(),
					_originalBatctrl_calc_ar_due = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
					_originalBatctrl_calc_tot_rev = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
					_originalBatctrl_manual_pay_tot = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
					_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					_originalBatctrl_nbr_claims_in_batch = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F001_BATCH_CONTROL_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F001_BATCH_CONTROL_FILE> Collection(ObservableCollection<F001_BATCH_CONTROL_FILE>
                                                               f001BatchControlFile = null)
        {
            if (IsSameSearch() && f001BatchControlFile != null)
            {
                return f001BatchControlFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F001_BATCH_CONTROL_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("BATCTRL_BATCH_NBR",WhereBatctrl_batch_nbr),
					new SqlParameter("BATCTRL_BATCH_TYPE",WhereBatctrl_batch_type),
					new SqlParameter("BATCTRL_ADJ_CD",WhereBatctrl_adj_cd),
					new SqlParameter("BATCTRL_ADJ_CD_SUB_TYPE",WhereBatctrl_adj_cd_sub_type),
					new SqlParameter("BATCTRL_LAST_CLAIM_NBR",WhereBatctrl_last_claim_nbr),
					new SqlParameter("BATCTRL_CLINIC_NBR",WhereBatctrl_clinic_nbr),
					new SqlParameter("BATCTRL_DOC_NBR_OHIP",WhereBatctrl_doc_nbr_ohip),
					new SqlParameter("BATCTRL_HOSP",WhereBatctrl_hosp),
					new SqlParameter("BATCTRL_LOC",WhereBatctrl_loc),
					new SqlParameter("BATCTRL_AGENT_CD",WhereBatctrl_agent_cd),
					new SqlParameter("BATCTRL_I_O_PAT_IND",WhereBatctrl_i_o_pat_ind),
					new SqlParameter("BATCTRL_DATE_BATCH_ENTERED",WhereBatctrl_date_batch_entered),
					new SqlParameter("BATCTRL_DATE_PERIOD_END",WhereBatctrl_date_period_end),
					new SqlParameter("BATCTRL_CYCLE_NBR",WhereBatctrl_cycle_nbr),
					new SqlParameter("BATCTRL_AMT_EST",WhereBatctrl_amt_est),
					new SqlParameter("BATCTRL_AMT_ACT",WhereBatctrl_amt_act),
					new SqlParameter("BATCTRL_SVC_EST",WhereBatctrl_svc_est),
					new SqlParameter("BATCTRL_SVC_ACT",WhereBatctrl_svc_act),
					new SqlParameter("BATCTRL_AR_YY_MM",WhereBatctrl_ar_yy_mm),
					new SqlParameter("BATCTRL_CALC_AR_DUE",WhereBatctrl_calc_ar_due),
					new SqlParameter("BATCTRL_CALC_TOT_REV",WhereBatctrl_calc_tot_rev),
					new SqlParameter("BATCTRL_MANUAL_PAY_TOT",WhereBatctrl_manual_pay_tot),
					new SqlParameter("BATCTRL_BATCH_STATUS",WhereBatctrl_batch_status),
					new SqlParameter("BATCTRL_NBR_CLAIMS_IN_BATCH",WhereBatctrl_nbr_claims_in_batch),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_Match]", parameters);
            var collection = new ObservableCollection<F001_BATCH_CONTROL_FILE>();

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
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

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

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalBatctrl_batch_nbr = Reader["BATCTRL_BATCH_NBR"].ToString(),
					_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString(),
					_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString(),
					_originalBatctrl_adj_cd_sub_type = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString(),
					_originalBatctrl_last_claim_nbr = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]),
					_originalBatctrl_clinic_nbr = Reader["BATCTRL_CLINIC_NBR"].ToString(),
					_originalBatctrl_doc_nbr_ohip = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]),
					_originalBatctrl_hosp = Reader["BATCTRL_HOSP"].ToString(),
					_originalBatctrl_loc = Reader["BATCTRL_LOC"].ToString(),
					_originalBatctrl_agent_cd = ConvertDEC(Reader["BATCTRL_AGENT_CD"]),
					_originalBatctrl_i_o_pat_ind = Reader["BATCTRL_I_O_PAT_IND"].ToString(),
					_originalBatctrl_date_batch_entered = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString(),
					_originalBatctrl_date_period_end = Reader["BATCTRL_DATE_PERIOD_END"].ToString(),
					_originalBatctrl_cycle_nbr = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]),
					_originalBatctrl_amt_est = ConvertDEC(Reader["BATCTRL_AMT_EST"]),
					_originalBatctrl_amt_act = ConvertDEC(Reader["BATCTRL_AMT_ACT"]),
					_originalBatctrl_svc_est = ConvertDEC(Reader["BATCTRL_SVC_EST"]),
					_originalBatctrl_svc_act = ConvertDEC(Reader["BATCTRL_SVC_ACT"]),
					_originalBatctrl_ar_yy_mm = Reader["BATCTRL_AR_YY_MM"].ToString(),
					_originalBatctrl_calc_ar_due = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]),
					_originalBatctrl_calc_tot_rev = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]),
					_originalBatctrl_manual_pay_tot = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]),
					_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString(),
					_originalBatctrl_nbr_claims_in_batch = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereBatctrl_batch_nbr = WhereBatctrl_batch_nbr;
					_whereBatctrl_batch_type = WhereBatctrl_batch_type;
					_whereBatctrl_adj_cd = WhereBatctrl_adj_cd;
					_whereBatctrl_adj_cd_sub_type = WhereBatctrl_adj_cd_sub_type;
					_whereBatctrl_last_claim_nbr = WhereBatctrl_last_claim_nbr;
					_whereBatctrl_clinic_nbr = WhereBatctrl_clinic_nbr;
					_whereBatctrl_doc_nbr_ohip = WhereBatctrl_doc_nbr_ohip;
					_whereBatctrl_hosp = WhereBatctrl_hosp;
					_whereBatctrl_loc = WhereBatctrl_loc;
					_whereBatctrl_agent_cd = WhereBatctrl_agent_cd;
					_whereBatctrl_i_o_pat_ind = WhereBatctrl_i_o_pat_ind;
					_whereBatctrl_date_batch_entered = WhereBatctrl_date_batch_entered;
					_whereBatctrl_date_period_end = WhereBatctrl_date_period_end;
					_whereBatctrl_cycle_nbr = WhereBatctrl_cycle_nbr;
					_whereBatctrl_amt_est = WhereBatctrl_amt_est;
					_whereBatctrl_amt_act = WhereBatctrl_amt_act;
					_whereBatctrl_svc_est = WhereBatctrl_svc_est;
					_whereBatctrl_svc_act = WhereBatctrl_svc_act;
					_whereBatctrl_ar_yy_mm = WhereBatctrl_ar_yy_mm;
					_whereBatctrl_calc_ar_due = WhereBatctrl_calc_ar_due;
					_whereBatctrl_calc_tot_rev = WhereBatctrl_calc_tot_rev;
					_whereBatctrl_manual_pay_tot = WhereBatctrl_manual_pay_tot;
					_whereBatctrl_batch_status = WhereBatctrl_batch_status;
					_whereBatctrl_nbr_claims_in_batch = WhereBatctrl_nbr_claims_in_batch;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereBatctrl_batch_nbr == null 
				&& WhereBatctrl_batch_type == null 
				&& WhereBatctrl_adj_cd == null 
				&& WhereBatctrl_adj_cd_sub_type == null 
				&& WhereBatctrl_last_claim_nbr == null 
				&& WhereBatctrl_clinic_nbr == null 
				&& WhereBatctrl_doc_nbr_ohip == null 
				&& WhereBatctrl_hosp == null 
				&& WhereBatctrl_loc == null 
				&& WhereBatctrl_agent_cd == null 
				&& WhereBatctrl_i_o_pat_ind == null 
				&& WhereBatctrl_date_batch_entered == null 
				&& WhereBatctrl_date_period_end == null 
				&& WhereBatctrl_cycle_nbr == null 
				&& WhereBatctrl_amt_est == null 
				&& WhereBatctrl_amt_act == null 
				&& WhereBatctrl_svc_est == null 
				&& WhereBatctrl_svc_act == null 
				&& WhereBatctrl_ar_yy_mm == null 
				&& WhereBatctrl_calc_ar_due == null 
				&& WhereBatctrl_calc_tot_rev == null 
				&& WhereBatctrl_manual_pay_tot == null 
				&& WhereBatctrl_batch_status == null 
				&& WhereBatctrl_nbr_claims_in_batch == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereBatctrl_batch_nbr ==  _whereBatctrl_batch_nbr
				&& WhereBatctrl_batch_type ==  _whereBatctrl_batch_type
				&& WhereBatctrl_adj_cd ==  _whereBatctrl_adj_cd
				&& WhereBatctrl_adj_cd_sub_type ==  _whereBatctrl_adj_cd_sub_type
				&& WhereBatctrl_last_claim_nbr ==  _whereBatctrl_last_claim_nbr
				&& WhereBatctrl_clinic_nbr ==  _whereBatctrl_clinic_nbr
				&& WhereBatctrl_doc_nbr_ohip ==  _whereBatctrl_doc_nbr_ohip
				&& WhereBatctrl_hosp ==  _whereBatctrl_hosp
				&& WhereBatctrl_loc ==  _whereBatctrl_loc
				&& WhereBatctrl_agent_cd ==  _whereBatctrl_agent_cd
				&& WhereBatctrl_i_o_pat_ind ==  _whereBatctrl_i_o_pat_ind
				&& WhereBatctrl_date_batch_entered ==  _whereBatctrl_date_batch_entered
				&& WhereBatctrl_date_period_end ==  _whereBatctrl_date_period_end
				&& WhereBatctrl_cycle_nbr ==  _whereBatctrl_cycle_nbr
				&& WhereBatctrl_amt_est ==  _whereBatctrl_amt_est
				&& WhereBatctrl_amt_act ==  _whereBatctrl_amt_act
				&& WhereBatctrl_svc_est ==  _whereBatctrl_svc_est
				&& WhereBatctrl_svc_act ==  _whereBatctrl_svc_act
				&& WhereBatctrl_ar_yy_mm ==  _whereBatctrl_ar_yy_mm
				&& WhereBatctrl_calc_ar_due ==  _whereBatctrl_calc_ar_due
				&& WhereBatctrl_calc_tot_rev ==  _whereBatctrl_calc_tot_rev
				&& WhereBatctrl_manual_pay_tot ==  _whereBatctrl_manual_pay_tot
				&& WhereBatctrl_batch_status ==  _whereBatctrl_batch_status
				&& WhereBatctrl_nbr_claims_in_batch ==  _whereBatctrl_nbr_claims_in_batch
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereBatctrl_batch_nbr = null; 
			WhereBatctrl_batch_type = null; 
			WhereBatctrl_adj_cd = null; 
			WhereBatctrl_adj_cd_sub_type = null; 
			WhereBatctrl_last_claim_nbr = null; 
			WhereBatctrl_clinic_nbr = null; 
			WhereBatctrl_doc_nbr_ohip = null; 
			WhereBatctrl_hosp = null; 
			WhereBatctrl_loc = null; 
			WhereBatctrl_agent_cd = null; 
			WhereBatctrl_i_o_pat_ind = null; 
			WhereBatctrl_date_batch_entered = null; 
			WhereBatctrl_date_period_end = null; 
			WhereBatctrl_cycle_nbr = null; 
			WhereBatctrl_amt_est = null; 
			WhereBatctrl_amt_act = null; 
			WhereBatctrl_svc_est = null; 
			WhereBatctrl_svc_act = null; 
			WhereBatctrl_ar_yy_mm = null; 
			WhereBatctrl_calc_ar_due = null; 
			WhereBatctrl_calc_tot_rev = null; 
			WhereBatctrl_manual_pay_tot = null; 
			WhereBatctrl_batch_status = null; 
			WhereBatctrl_nbr_claims_in_batch = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _BATCTRL_BATCH_NBR;
		private string _BATCTRL_BATCH_TYPE;
		private string _BATCTRL_ADJ_CD;
		private string _BATCTRL_ADJ_CD_SUB_TYPE;
		private decimal? _BATCTRL_LAST_CLAIM_NBR;
		private string _BATCTRL_CLINIC_NBR;
		private decimal? _BATCTRL_DOC_NBR_OHIP;
		private string _BATCTRL_HOSP;
		private string _BATCTRL_LOC;
		private decimal? _BATCTRL_AGENT_CD;
		private string _BATCTRL_I_O_PAT_IND;
		private string _BATCTRL_DATE_BATCH_ENTERED;
		private string _BATCTRL_DATE_PERIOD_END;
		private decimal? _BATCTRL_CYCLE_NBR;
		private decimal? _BATCTRL_AMT_EST;
		private decimal? _BATCTRL_AMT_ACT;
		private decimal? _BATCTRL_SVC_EST;
		private decimal? _BATCTRL_SVC_ACT;
		private string _BATCTRL_AR_YY_MM;
		private decimal? _BATCTRL_CALC_AR_DUE;
		private decimal? _BATCTRL_CALC_TOT_REV;
		private decimal? _BATCTRL_MANUAL_PAY_TOT;
		private string _BATCTRL_BATCH_STATUS;
		private decimal? _BATCTRL_NBR_CLAIMS_IN_BATCH;
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
		public string BATCTRL_BATCH_NBR
		{
			get { return _BATCTRL_BATCH_NBR; }
			set
			{
				if (_BATCTRL_BATCH_NBR != value)
				{
					_BATCTRL_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_BATCH_TYPE
		{
			get { return _BATCTRL_BATCH_TYPE; }
			set
			{
				if (_BATCTRL_BATCH_TYPE != value)
				{
					_BATCTRL_BATCH_TYPE = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_ADJ_CD
		{
			get { return _BATCTRL_ADJ_CD; }
			set
			{
				if (_BATCTRL_ADJ_CD != value)
				{
					_BATCTRL_ADJ_CD = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_ADJ_CD_SUB_TYPE
		{
			get { return _BATCTRL_ADJ_CD_SUB_TYPE; }
			set
			{
				if (_BATCTRL_ADJ_CD_SUB_TYPE != value)
				{
					_BATCTRL_ADJ_CD_SUB_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_LAST_CLAIM_NBR
		{
			get { return _BATCTRL_LAST_CLAIM_NBR; }
			set
			{
				if (_BATCTRL_LAST_CLAIM_NBR != value)
				{
					_BATCTRL_LAST_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_CLINIC_NBR
		{
			get { return _BATCTRL_CLINIC_NBR; }
			set
			{
				if (_BATCTRL_CLINIC_NBR != value)
				{
					_BATCTRL_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_DOC_NBR_OHIP
		{
			get { return _BATCTRL_DOC_NBR_OHIP; }
			set
			{
				if (_BATCTRL_DOC_NBR_OHIP != value)
				{
					_BATCTRL_DOC_NBR_OHIP = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_HOSP
		{
			get { return _BATCTRL_HOSP; }
			set
			{
				if (_BATCTRL_HOSP != value)
				{
					_BATCTRL_HOSP = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_LOC
		{
			get { return _BATCTRL_LOC; }
			set
			{
				if (_BATCTRL_LOC != value)
				{
					_BATCTRL_LOC = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_AGENT_CD
		{
			get { return _BATCTRL_AGENT_CD; }
			set
			{
				if (_BATCTRL_AGENT_CD != value)
				{
					_BATCTRL_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_I_O_PAT_IND
		{
			get { return _BATCTRL_I_O_PAT_IND; }
			set
			{
				if (_BATCTRL_I_O_PAT_IND != value)
				{
					_BATCTRL_I_O_PAT_IND = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_DATE_BATCH_ENTERED
		{
			get { return _BATCTRL_DATE_BATCH_ENTERED; }
			set
			{
				if (_BATCTRL_DATE_BATCH_ENTERED != value)
				{
					_BATCTRL_DATE_BATCH_ENTERED = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_DATE_PERIOD_END
		{
			get { return _BATCTRL_DATE_PERIOD_END; }
			set
			{
				if (_BATCTRL_DATE_PERIOD_END != value)
				{
					_BATCTRL_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_CYCLE_NBR
		{
			get { return _BATCTRL_CYCLE_NBR; }
			set
			{
				if (_BATCTRL_CYCLE_NBR != value)
				{
					_BATCTRL_CYCLE_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_AMT_EST
		{
			get { return _BATCTRL_AMT_EST; }
			set
			{
				if (_BATCTRL_AMT_EST != value)
				{
					_BATCTRL_AMT_EST = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_AMT_ACT
		{
			get { return _BATCTRL_AMT_ACT; }
			set
			{
				if (_BATCTRL_AMT_ACT != value)
				{
					_BATCTRL_AMT_ACT = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_SVC_EST
		{
			get { return _BATCTRL_SVC_EST; }
			set
			{
				if (_BATCTRL_SVC_EST != value)
				{
					_BATCTRL_SVC_EST = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_SVC_ACT
		{
			get { return _BATCTRL_SVC_ACT; }
			set
			{
				if (_BATCTRL_SVC_ACT != value)
				{
					_BATCTRL_SVC_ACT = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_AR_YY_MM
		{
			get { return _BATCTRL_AR_YY_MM; }
			set
			{
				if (_BATCTRL_AR_YY_MM != value)
				{
					_BATCTRL_AR_YY_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_CALC_AR_DUE
		{
			get { return _BATCTRL_CALC_AR_DUE; }
			set
			{
				if (_BATCTRL_CALC_AR_DUE != value)
				{
					_BATCTRL_CALC_AR_DUE = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_CALC_TOT_REV
		{
			get { return _BATCTRL_CALC_TOT_REV; }
			set
			{
				if (_BATCTRL_CALC_TOT_REV != value)
				{
					_BATCTRL_CALC_TOT_REV = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_MANUAL_PAY_TOT
		{
			get { return _BATCTRL_MANUAL_PAY_TOT; }
			set
			{
				if (_BATCTRL_MANUAL_PAY_TOT != value)
				{
					_BATCTRL_MANUAL_PAY_TOT = value;
					ChangeState();
				}
			}
		}
		public string BATCTRL_BATCH_STATUS
		{
			get { return _BATCTRL_BATCH_STATUS; }
			set
			{
				if (_BATCTRL_BATCH_STATUS != value)
				{
					_BATCTRL_BATCH_STATUS = value;
					ChangeState();
				}
			}
		}
		public decimal? BATCTRL_NBR_CLAIMS_IN_BATCH
		{
			get { return _BATCTRL_NBR_CLAIMS_IN_BATCH; }
			set
			{
				if (_BATCTRL_NBR_CLAIMS_IN_BATCH != value)
				{
					_BATCTRL_NBR_CLAIMS_IN_BATCH = value;
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
		public string WhereBatctrl_batch_nbr { get; set; }
		private string _whereBatctrl_batch_nbr;
		public string WhereBatctrl_batch_type { get; set; }
		private string _whereBatctrl_batch_type;
		public string WhereBatctrl_adj_cd { get; set; }
		private string _whereBatctrl_adj_cd;
		public string WhereBatctrl_adj_cd_sub_type { get; set; }
		private string _whereBatctrl_adj_cd_sub_type;
		public decimal? WhereBatctrl_last_claim_nbr { get; set; }
		private decimal? _whereBatctrl_last_claim_nbr;
		public string WhereBatctrl_clinic_nbr { get; set; }
		private string _whereBatctrl_clinic_nbr;
		public decimal? WhereBatctrl_doc_nbr_ohip { get; set; }
		private decimal? _whereBatctrl_doc_nbr_ohip;
		public string WhereBatctrl_hosp { get; set; }
		private string _whereBatctrl_hosp;
		public string WhereBatctrl_loc { get; set; }
		private string _whereBatctrl_loc;
		public decimal? WhereBatctrl_agent_cd { get; set; }
		private decimal? _whereBatctrl_agent_cd;
		public string WhereBatctrl_i_o_pat_ind { get; set; }
		private string _whereBatctrl_i_o_pat_ind;
		public string WhereBatctrl_date_batch_entered { get; set; }
		private string _whereBatctrl_date_batch_entered;
		public string WhereBatctrl_date_period_end { get; set; }
		private string _whereBatctrl_date_period_end;
		public decimal? WhereBatctrl_cycle_nbr { get; set; }
		private decimal? _whereBatctrl_cycle_nbr;
		public decimal? WhereBatctrl_amt_est { get; set; }
		private decimal? _whereBatctrl_amt_est;
		public decimal? WhereBatctrl_amt_act { get; set; }
		private decimal? _whereBatctrl_amt_act;
		public decimal? WhereBatctrl_svc_est { get; set; }
		private decimal? _whereBatctrl_svc_est;
		public decimal? WhereBatctrl_svc_act { get; set; }
		private decimal? _whereBatctrl_svc_act;
		public string WhereBatctrl_ar_yy_mm { get; set; }
		private string _whereBatctrl_ar_yy_mm;
		public decimal? WhereBatctrl_calc_ar_due { get; set; }
		private decimal? _whereBatctrl_calc_ar_due;
		public decimal? WhereBatctrl_calc_tot_rev { get; set; }
		private decimal? _whereBatctrl_calc_tot_rev;
		public decimal? WhereBatctrl_manual_pay_tot { get; set; }
		private decimal? _whereBatctrl_manual_pay_tot;
		public string WhereBatctrl_batch_status { get; set; }
		private string _whereBatctrl_batch_status;
		public decimal? WhereBatctrl_nbr_claims_in_batch { get; set; }
		private decimal? _whereBatctrl_nbr_claims_in_batch;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalBatctrl_batch_nbr;
		private string _originalBatctrl_batch_type;
		private string _originalBatctrl_adj_cd;
		private string _originalBatctrl_adj_cd_sub_type;
		private decimal? _originalBatctrl_last_claim_nbr;
		private string _originalBatctrl_clinic_nbr;
		private decimal? _originalBatctrl_doc_nbr_ohip;
		private string _originalBatctrl_hosp;
		private string _originalBatctrl_loc;
		private decimal? _originalBatctrl_agent_cd;
		private string _originalBatctrl_i_o_pat_ind;
		private string _originalBatctrl_date_batch_entered;
		private string _originalBatctrl_date_period_end;
		private decimal? _originalBatctrl_cycle_nbr;
		private decimal? _originalBatctrl_amt_est;
		private decimal? _originalBatctrl_amt_act;
		private decimal? _originalBatctrl_svc_est;
		private decimal? _originalBatctrl_svc_act;
		private string _originalBatctrl_ar_yy_mm;
		private decimal? _originalBatctrl_calc_ar_due;
		private decimal? _originalBatctrl_calc_tot_rev;
		private decimal? _originalBatctrl_manual_pay_tot;
		private string _originalBatctrl_batch_status;
		private decimal? _originalBatctrl_nbr_claims_in_batch;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			BATCTRL_BATCH_NBR = _originalBatctrl_batch_nbr;
			BATCTRL_BATCH_TYPE = _originalBatctrl_batch_type;
			BATCTRL_ADJ_CD = _originalBatctrl_adj_cd;
			BATCTRL_ADJ_CD_SUB_TYPE = _originalBatctrl_adj_cd_sub_type;
			BATCTRL_LAST_CLAIM_NBR = _originalBatctrl_last_claim_nbr;
			BATCTRL_CLINIC_NBR = _originalBatctrl_clinic_nbr;
			BATCTRL_DOC_NBR_OHIP = _originalBatctrl_doc_nbr_ohip;
			BATCTRL_HOSP = _originalBatctrl_hosp;
			BATCTRL_LOC = _originalBatctrl_loc;
			BATCTRL_AGENT_CD = _originalBatctrl_agent_cd;
			BATCTRL_I_O_PAT_IND = _originalBatctrl_i_o_pat_ind;
			BATCTRL_DATE_BATCH_ENTERED = _originalBatctrl_date_batch_entered;
			BATCTRL_DATE_PERIOD_END = _originalBatctrl_date_period_end;
			BATCTRL_CYCLE_NBR = _originalBatctrl_cycle_nbr;
			BATCTRL_AMT_EST = _originalBatctrl_amt_est;
			BATCTRL_AMT_ACT = _originalBatctrl_amt_act;
			BATCTRL_SVC_EST = _originalBatctrl_svc_est;
			BATCTRL_SVC_ACT = _originalBatctrl_svc_act;
			BATCTRL_AR_YY_MM = _originalBatctrl_ar_yy_mm;
			BATCTRL_CALC_AR_DUE = _originalBatctrl_calc_ar_due;
			BATCTRL_CALC_TOT_REV = _originalBatctrl_calc_tot_rev;
			BATCTRL_MANUAL_PAY_TOT = _originalBatctrl_manual_pay_tot;
			BATCTRL_BATCH_STATUS = _originalBatctrl_batch_status;
			BATCTRL_NBR_CLAIMS_IN_BATCH = _originalBatctrl_nbr_claims_in_batch;
			CHECKSUM_VALUE = _originalChecksum_value;

            RecordState = State.UnChanged;

            return true;
        }


        public bool Delete()
        {
            bool retvalue = true;
            int RowsAffected = 0;
            try {
               
                var parameters = new SqlParameter[]
                    {
                    new SqlParameter("RowCheckSum",RowCheckSum),
                    new SqlParameter("ROWID",ROWID),
                    new SqlParameter("BATCTRL_BATCH_NBR",BATCTRL_BATCH_NBR)
                    };
                RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_DeleteRow]", parameters);
            } catch (Exception ex)
            {
                retvalue = false;
            }
            finally
            {
                CloseConnection();
            }
            if (RowsAffected == 0)
                 return false;
            else
                return retvalue;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_Purge]");
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
						new SqlParameter("BATCTRL_BATCH_NBR", SqlNull(BATCTRL_BATCH_NBR)),
						new SqlParameter("BATCTRL_BATCH_TYPE", SqlNull(BATCTRL_BATCH_TYPE)),
						new SqlParameter("BATCTRL_ADJ_CD", SqlNull(BATCTRL_ADJ_CD)),
						new SqlParameter("BATCTRL_ADJ_CD_SUB_TYPE", SqlNull(BATCTRL_ADJ_CD_SUB_TYPE)),
						new SqlParameter("BATCTRL_LAST_CLAIM_NBR", SqlNull(BATCTRL_LAST_CLAIM_NBR)),
						new SqlParameter("BATCTRL_CLINIC_NBR", SqlNull(BATCTRL_CLINIC_NBR)),
						new SqlParameter("BATCTRL_DOC_NBR_OHIP", SqlNull(BATCTRL_DOC_NBR_OHIP)),
						new SqlParameter("BATCTRL_HOSP", SqlNull(BATCTRL_HOSP)),
						new SqlParameter("BATCTRL_LOC", SqlNull(BATCTRL_LOC)),
						new SqlParameter("BATCTRL_AGENT_CD", SqlNull(BATCTRL_AGENT_CD)),
						new SqlParameter("BATCTRL_I_O_PAT_IND", SqlNull(BATCTRL_I_O_PAT_IND)),
						new SqlParameter("BATCTRL_DATE_BATCH_ENTERED", SqlNull(BATCTRL_DATE_BATCH_ENTERED)),
						new SqlParameter("BATCTRL_DATE_PERIOD_END", SqlNull(BATCTRL_DATE_PERIOD_END)),
						new SqlParameter("BATCTRL_CYCLE_NBR", SqlNull(BATCTRL_CYCLE_NBR)),
						new SqlParameter("BATCTRL_AMT_EST", SqlNull(BATCTRL_AMT_EST)),
						new SqlParameter("BATCTRL_AMT_ACT", SqlNull(BATCTRL_AMT_ACT)),
						new SqlParameter("BATCTRL_SVC_EST", SqlNull(BATCTRL_SVC_EST)),
						new SqlParameter("BATCTRL_SVC_ACT", SqlNull(BATCTRL_SVC_ACT)),
						new SqlParameter("BATCTRL_AR_YY_MM", SqlNull(BATCTRL_AR_YY_MM)),
						new SqlParameter("BATCTRL_CALC_AR_DUE", SqlNull(BATCTRL_CALC_AR_DUE)),
						new SqlParameter("BATCTRL_CALC_TOT_REV", SqlNull(BATCTRL_CALC_TOT_REV)),
						new SqlParameter("BATCTRL_MANUAL_PAY_TOT", SqlNull(BATCTRL_MANUAL_PAY_TOT)),
						new SqlParameter("BATCTRL_BATCH_STATUS", SqlNull(BATCTRL_BATCH_STATUS)),
						new SqlParameter("BATCTRL_NBR_CLAIMS_IN_BATCH", SqlNull(BATCTRL_NBR_CLAIMS_IN_BATCH)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString();
						BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString();
						BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString();
						BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString();
						BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]);
						BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString();
						BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]);
						BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString();
						BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString();
						BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]);
						BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString();
						BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString();
						BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString();
						BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]);
						BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]);
						BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]);
						BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]);
						BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]);
						BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString();
						BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]);
						BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]);
						BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]);
						BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString();
						BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBatctrl_batch_nbr = Reader["BATCTRL_BATCH_NBR"].ToString();
						_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString();
						_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString();
						_originalBatctrl_adj_cd_sub_type = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString();
						_originalBatctrl_last_claim_nbr = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]);
						_originalBatctrl_clinic_nbr = Reader["BATCTRL_CLINIC_NBR"].ToString();
						_originalBatctrl_doc_nbr_ohip = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]);
						_originalBatctrl_hosp = Reader["BATCTRL_HOSP"].ToString();
						_originalBatctrl_loc = Reader["BATCTRL_LOC"].ToString();
						_originalBatctrl_agent_cd = ConvertDEC(Reader["BATCTRL_AGENT_CD"]);
						_originalBatctrl_i_o_pat_ind = Reader["BATCTRL_I_O_PAT_IND"].ToString();
						_originalBatctrl_date_batch_entered = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString();
						_originalBatctrl_date_period_end = Reader["BATCTRL_DATE_PERIOD_END"].ToString();
						_originalBatctrl_cycle_nbr = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]);
						_originalBatctrl_amt_est = ConvertDEC(Reader["BATCTRL_AMT_EST"]);
						_originalBatctrl_amt_act = ConvertDEC(Reader["BATCTRL_AMT_ACT"]);
						_originalBatctrl_svc_est = ConvertDEC(Reader["BATCTRL_SVC_EST"]);
						_originalBatctrl_svc_act = ConvertDEC(Reader["BATCTRL_SVC_ACT"]);
						_originalBatctrl_ar_yy_mm = Reader["BATCTRL_AR_YY_MM"].ToString();
						_originalBatctrl_calc_ar_due = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]);
						_originalBatctrl_calc_tot_rev = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]);
						_originalBatctrl_manual_pay_tot = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]);
						_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString();
						_originalBatctrl_nbr_claims_in_batch = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("BATCTRL_BATCH_NBR", SqlNull(BATCTRL_BATCH_NBR)),
						new SqlParameter("BATCTRL_BATCH_TYPE", SqlNull(BATCTRL_BATCH_TYPE)),
						new SqlParameter("BATCTRL_ADJ_CD", SqlNull(BATCTRL_ADJ_CD)),
						new SqlParameter("BATCTRL_ADJ_CD_SUB_TYPE", SqlNull(BATCTRL_ADJ_CD_SUB_TYPE)),
						new SqlParameter("BATCTRL_LAST_CLAIM_NBR", SqlNull(BATCTRL_LAST_CLAIM_NBR)),
						new SqlParameter("BATCTRL_CLINIC_NBR", SqlNull(BATCTRL_CLINIC_NBR)),
						new SqlParameter("BATCTRL_DOC_NBR_OHIP", SqlNull(BATCTRL_DOC_NBR_OHIP)),
						new SqlParameter("BATCTRL_HOSP", SqlNull(BATCTRL_HOSP)),
						new SqlParameter("BATCTRL_LOC", SqlNull(BATCTRL_LOC)),
						new SqlParameter("BATCTRL_AGENT_CD", SqlNull(BATCTRL_AGENT_CD)),
						new SqlParameter("BATCTRL_I_O_PAT_IND", SqlNull(BATCTRL_I_O_PAT_IND)),
						new SqlParameter("BATCTRL_DATE_BATCH_ENTERED", SqlNull(BATCTRL_DATE_BATCH_ENTERED)),
						new SqlParameter("BATCTRL_DATE_PERIOD_END", SqlNull(BATCTRL_DATE_PERIOD_END)),
						new SqlParameter("BATCTRL_CYCLE_NBR", SqlNull(BATCTRL_CYCLE_NBR)),
						new SqlParameter("BATCTRL_AMT_EST", SqlNull(BATCTRL_AMT_EST)),
						new SqlParameter("BATCTRL_AMT_ACT", SqlNull(BATCTRL_AMT_ACT)),
						new SqlParameter("BATCTRL_SVC_EST", SqlNull(BATCTRL_SVC_EST)),
						new SqlParameter("BATCTRL_SVC_ACT", SqlNull(BATCTRL_SVC_ACT)),
						new SqlParameter("BATCTRL_AR_YY_MM", SqlNull(BATCTRL_AR_YY_MM)),
						new SqlParameter("BATCTRL_CALC_AR_DUE", SqlNull(BATCTRL_CALC_AR_DUE)),
						new SqlParameter("BATCTRL_CALC_TOT_REV", SqlNull(BATCTRL_CALC_TOT_REV)),
						new SqlParameter("BATCTRL_MANUAL_PAY_TOT", SqlNull(BATCTRL_MANUAL_PAY_TOT)),
						new SqlParameter("BATCTRL_BATCH_STATUS", SqlNull(BATCTRL_BATCH_STATUS)),
						new SqlParameter("BATCTRL_NBR_CLAIMS_IN_BATCH", SqlNull(BATCTRL_NBR_CLAIMS_IN_BATCH)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F001_BATCH_CONTROL_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						BATCTRL_BATCH_NBR = Reader["BATCTRL_BATCH_NBR"].ToString();
						BATCTRL_BATCH_TYPE = Reader["BATCTRL_BATCH_TYPE"].ToString();
						BATCTRL_ADJ_CD = Reader["BATCTRL_ADJ_CD"].ToString();
						BATCTRL_ADJ_CD_SUB_TYPE = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString();
						BATCTRL_LAST_CLAIM_NBR = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]);
						BATCTRL_CLINIC_NBR = Reader["BATCTRL_CLINIC_NBR"].ToString();
						BATCTRL_DOC_NBR_OHIP = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]);
						BATCTRL_HOSP = Reader["BATCTRL_HOSP"].ToString();
						BATCTRL_LOC = Reader["BATCTRL_LOC"].ToString();
						BATCTRL_AGENT_CD = ConvertDEC(Reader["BATCTRL_AGENT_CD"]);
						BATCTRL_I_O_PAT_IND = Reader["BATCTRL_I_O_PAT_IND"].ToString();
						BATCTRL_DATE_BATCH_ENTERED = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString();
						BATCTRL_DATE_PERIOD_END = Reader["BATCTRL_DATE_PERIOD_END"].ToString();
						BATCTRL_CYCLE_NBR = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]);
						BATCTRL_AMT_EST = ConvertDEC(Reader["BATCTRL_AMT_EST"]);
						BATCTRL_AMT_ACT = ConvertDEC(Reader["BATCTRL_AMT_ACT"]);
						BATCTRL_SVC_EST = ConvertDEC(Reader["BATCTRL_SVC_EST"]);
						BATCTRL_SVC_ACT = ConvertDEC(Reader["BATCTRL_SVC_ACT"]);
						BATCTRL_AR_YY_MM = Reader["BATCTRL_AR_YY_MM"].ToString();
						BATCTRL_CALC_AR_DUE = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]);
						BATCTRL_CALC_TOT_REV = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]);
						BATCTRL_MANUAL_PAY_TOT = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]);
						BATCTRL_BATCH_STATUS = Reader["BATCTRL_BATCH_STATUS"].ToString();
						BATCTRL_NBR_CLAIMS_IN_BATCH = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalBatctrl_batch_nbr = Reader["BATCTRL_BATCH_NBR"].ToString();
						_originalBatctrl_batch_type = Reader["BATCTRL_BATCH_TYPE"].ToString();
						_originalBatctrl_adj_cd = Reader["BATCTRL_ADJ_CD"].ToString();
						_originalBatctrl_adj_cd_sub_type = Reader["BATCTRL_ADJ_CD_SUB_TYPE"].ToString();
						_originalBatctrl_last_claim_nbr = ConvertDEC(Reader["BATCTRL_LAST_CLAIM_NBR"]);
						_originalBatctrl_clinic_nbr = Reader["BATCTRL_CLINIC_NBR"].ToString();
						_originalBatctrl_doc_nbr_ohip = ConvertDEC(Reader["BATCTRL_DOC_NBR_OHIP"]);
						_originalBatctrl_hosp = Reader["BATCTRL_HOSP"].ToString();
						_originalBatctrl_loc = Reader["BATCTRL_LOC"].ToString();
						_originalBatctrl_agent_cd = ConvertDEC(Reader["BATCTRL_AGENT_CD"]);
						_originalBatctrl_i_o_pat_ind = Reader["BATCTRL_I_O_PAT_IND"].ToString();
						_originalBatctrl_date_batch_entered = Reader["BATCTRL_DATE_BATCH_ENTERED"].ToString();
						_originalBatctrl_date_period_end = Reader["BATCTRL_DATE_PERIOD_END"].ToString();
						_originalBatctrl_cycle_nbr = ConvertDEC(Reader["BATCTRL_CYCLE_NBR"]);
						_originalBatctrl_amt_est = ConvertDEC(Reader["BATCTRL_AMT_EST"]);
						_originalBatctrl_amt_act = ConvertDEC(Reader["BATCTRL_AMT_ACT"]);
						_originalBatctrl_svc_est = ConvertDEC(Reader["BATCTRL_SVC_EST"]);
						_originalBatctrl_svc_act = ConvertDEC(Reader["BATCTRL_SVC_ACT"]);
						_originalBatctrl_ar_yy_mm = Reader["BATCTRL_AR_YY_MM"].ToString();
						_originalBatctrl_calc_ar_due = ConvertDEC(Reader["BATCTRL_CALC_AR_DUE"]);
						_originalBatctrl_calc_tot_rev = ConvertDEC(Reader["BATCTRL_CALC_TOT_REV"]);
						_originalBatctrl_manual_pay_tot = ConvertDEC(Reader["BATCTRL_MANUAL_PAY_TOT"]);
						_originalBatctrl_batch_status = Reader["BATCTRL_BATCH_STATUS"].ToString();
						_originalBatctrl_nbr_claims_in_batch = ConvertDEC(Reader["BATCTRL_NBR_CLAIMS_IN_BATCH"]);
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