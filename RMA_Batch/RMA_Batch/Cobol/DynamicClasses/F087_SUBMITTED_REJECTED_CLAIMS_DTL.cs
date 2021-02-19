using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F087_SUBMITTED_REJECTED_CLAIMS_DTL : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL> Collection( Guid? rowid,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															decimal? pedmin,
															decimal? pedmax,
															decimal? edt_process_datemin,
															decimal? edt_process_datemax,
															decimal? key_dtl_seq_nbrmin,
															decimal? key_dtl_seq_nbrmax,
															string edt_oma_service_cd_and_suffix,
															decimal? edt_service_datemin,
															decimal? edt_service_datemax,
															string edt_dtl_diag_cd,
															decimal? edt_nbr_servmin,
															decimal? edt_nbr_servmax,
															decimal? edt_amount_submittedmin,
															decimal? edt_amount_submittedmax,
															string edt_dtl_err_explan_cd,
															string edt_dtl_err_cd_1,
															string edt_dtl_err_cd_2,
															string edt_dtl_err_cd_3,
															string edt_dtl_err_cd_4,
															string edt_dtl_err_cd_5,
															string edt_dtl_err_8_explan_cd,
															string edt_dtl_err_8_explan_desc,
															decimal? entry_datemin,
															decimal? entry_datemax,
															decimal? entry_time_longmin,
															decimal? entry_time_longmax,
															string entry_user_id,
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
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("minPED",pedmin),
					new SqlParameter("maxPED",pedmax),
					new SqlParameter("minEDT_PROCESS_DATE",edt_process_datemin),
					new SqlParameter("maxEDT_PROCESS_DATE",edt_process_datemax),
					new SqlParameter("minKEY_DTL_SEQ_NBR",key_dtl_seq_nbrmin),
					new SqlParameter("maxKEY_DTL_SEQ_NBR",key_dtl_seq_nbrmax),
					new SqlParameter("EDT_OMA_SERVICE_CD_AND_SUFFIX",edt_oma_service_cd_and_suffix),
					new SqlParameter("minEDT_SERVICE_DATE",edt_service_datemin),
					new SqlParameter("maxEDT_SERVICE_DATE",edt_service_datemax),
					new SqlParameter("EDT_DTL_DIAG_CD",edt_dtl_diag_cd),
					new SqlParameter("minEDT_NBR_SERV",edt_nbr_servmin),
					new SqlParameter("maxEDT_NBR_SERV",edt_nbr_servmax),
					new SqlParameter("minEDT_AMOUNT_SUBMITTED",edt_amount_submittedmin),
					new SqlParameter("maxEDT_AMOUNT_SUBMITTED",edt_amount_submittedmax),
					new SqlParameter("EDT_DTL_ERR_EXPLAN_CD",edt_dtl_err_explan_cd),
					new SqlParameter("EDT_DTL_ERR_CD_1",edt_dtl_err_cd_1),
					new SqlParameter("EDT_DTL_ERR_CD_2",edt_dtl_err_cd_2),
					new SqlParameter("EDT_DTL_ERR_CD_3",edt_dtl_err_cd_3),
					new SqlParameter("EDT_DTL_ERR_CD_4",edt_dtl_err_cd_4),
					new SqlParameter("EDT_DTL_ERR_CD_5",edt_dtl_err_cd_5),
					new SqlParameter("EDT_DTL_ERR_8_EXPLAN_CD",edt_dtl_err_8_explan_cd),
					new SqlParameter("EDT_DTL_ERR_8_EXPLAN_DESC",edt_dtl_err_8_explan_desc),
					new SqlParameter("minENTRY_DATE",entry_datemin),
					new SqlParameter("maxENTRY_DATE",entry_datemax),
					new SqlParameter("minENTRY_TIME_LONG",entry_time_longmin),
					new SqlParameter("maxENTRY_TIME_LONG",entry_time_longmax),
					new SqlParameter("ENTRY_USER_ID",entry_user_id),
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
                Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_Search]", parameters);
            var collection = new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F087_SUBMITTED_REJECTED_CLAIMS_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					PED = ConvertDEC(Reader["PED"]),
					EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
					EDT_OMA_SERVICE_CD_AND_SUFFIX = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString(),
					EDT_SERVICE_DATE = ConvertDEC(Reader["EDT_SERVICE_DATE"]),
					EDT_DTL_DIAG_CD = Reader["EDT_DTL_DIAG_CD"].ToString(),
					EDT_NBR_SERV = ConvertDEC(Reader["EDT_NBR_SERV"]),
					EDT_AMOUNT_SUBMITTED = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]),
					EDT_DTL_ERR_EXPLAN_CD = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString(),
					EDT_DTL_ERR_CD_1 = Reader["EDT_DTL_ERR_CD_1"].ToString(),
					EDT_DTL_ERR_CD_2 = Reader["EDT_DTL_ERR_CD_2"].ToString(),
					EDT_DTL_ERR_CD_3 = Reader["EDT_DTL_ERR_CD_3"].ToString(),
					EDT_DTL_ERR_CD_4 = Reader["EDT_DTL_ERR_CD_4"].ToString(),
					EDT_DTL_ERR_CD_5 = Reader["EDT_DTL_ERR_CD_5"].ToString(),
					EDT_DTL_ERR_8_EXPLAN_CD = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString(),
					EDT_DTL_ERR_8_EXPLAN_DESC = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
					_originalEdt_oma_service_cd_and_suffix = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString(),
					_originalEdt_service_date = ConvertDEC(Reader["EDT_SERVICE_DATE"]),
					_originalEdt_dtl_diag_cd = Reader["EDT_DTL_DIAG_CD"].ToString(),
					_originalEdt_nbr_serv = ConvertDEC(Reader["EDT_NBR_SERV"]),
					_originalEdt_amount_submitted = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]),
					_originalEdt_dtl_err_explan_cd = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString(),
					_originalEdt_dtl_err_cd_1 = Reader["EDT_DTL_ERR_CD_1"].ToString(),
					_originalEdt_dtl_err_cd_2 = Reader["EDT_DTL_ERR_CD_2"].ToString(),
					_originalEdt_dtl_err_cd_3 = Reader["EDT_DTL_ERR_CD_3"].ToString(),
					_originalEdt_dtl_err_cd_4 = Reader["EDT_DTL_ERR_CD_4"].ToString(),
					_originalEdt_dtl_err_cd_5 = Reader["EDT_DTL_ERR_CD_5"].ToString(),
					_originalEdt_dtl_err_8_explan_cd = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString(),
					_originalEdt_dtl_err_8_explan_desc = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
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

        public F087_SUBMITTED_REJECTED_CLAIMS_DTL Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL> Collection(ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL>
                                                               f087SubmittedRejectedClaimsDtl = null)
        {
            if (IsSameSearch() && f087SubmittedRejectedClaimsDtl != null)
            {
                return f087SubmittedRejectedClaimsDtl;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("PED",WherePed),
					new SqlParameter("EDT_PROCESS_DATE",WhereEdt_process_date),
					new SqlParameter("KEY_DTL_SEQ_NBR",WhereKey_dtl_seq_nbr),
					new SqlParameter("EDT_OMA_SERVICE_CD_AND_SUFFIX",WhereEdt_oma_service_cd_and_suffix),
					new SqlParameter("EDT_SERVICE_DATE",WhereEdt_service_date),
					new SqlParameter("EDT_DTL_DIAG_CD",WhereEdt_dtl_diag_cd),
					new SqlParameter("EDT_NBR_SERV",WhereEdt_nbr_serv),
					new SqlParameter("EDT_AMOUNT_SUBMITTED",WhereEdt_amount_submitted),
					new SqlParameter("EDT_DTL_ERR_EXPLAN_CD",WhereEdt_dtl_err_explan_cd),
					new SqlParameter("EDT_DTL_ERR_CD_1",WhereEdt_dtl_err_cd_1),
					new SqlParameter("EDT_DTL_ERR_CD_2",WhereEdt_dtl_err_cd_2),
					new SqlParameter("EDT_DTL_ERR_CD_3",WhereEdt_dtl_err_cd_3),
					new SqlParameter("EDT_DTL_ERR_CD_4",WhereEdt_dtl_err_cd_4),
					new SqlParameter("EDT_DTL_ERR_CD_5",WhereEdt_dtl_err_cd_5),
					new SqlParameter("EDT_DTL_ERR_8_EXPLAN_CD",WhereEdt_dtl_err_8_explan_cd),
					new SqlParameter("EDT_DTL_ERR_8_EXPLAN_DESC",WhereEdt_dtl_err_8_explan_desc),
					new SqlParameter("ENTRY_DATE",WhereEntry_date),
					new SqlParameter("ENTRY_TIME_LONG",WhereEntry_time_long),
					new SqlParameter("ENTRY_USER_ID",WhereEntry_user_id),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_Match]", parameters);
            var collection = new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_DTL>();

            while (Reader.Read())
            {
                collection.Add(new F087_SUBMITTED_REJECTED_CLAIMS_DTL
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					PED = ConvertDEC(Reader["PED"]),
					EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
					EDT_OMA_SERVICE_CD_AND_SUFFIX = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString(),
					EDT_SERVICE_DATE = ConvertDEC(Reader["EDT_SERVICE_DATE"]),
					EDT_DTL_DIAG_CD = Reader["EDT_DTL_DIAG_CD"].ToString(),
					EDT_NBR_SERV = ConvertDEC(Reader["EDT_NBR_SERV"]),
					EDT_AMOUNT_SUBMITTED = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]),
					EDT_DTL_ERR_EXPLAN_CD = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString(),
					EDT_DTL_ERR_CD_1 = Reader["EDT_DTL_ERR_CD_1"].ToString(),
					EDT_DTL_ERR_CD_2 = Reader["EDT_DTL_ERR_CD_2"].ToString(),
					EDT_DTL_ERR_CD_3 = Reader["EDT_DTL_ERR_CD_3"].ToString(),
					EDT_DTL_ERR_CD_4 = Reader["EDT_DTL_ERR_CD_4"].ToString(),
					EDT_DTL_ERR_CD_5 = Reader["EDT_DTL_ERR_CD_5"].ToString(),
					EDT_DTL_ERR_8_EXPLAN_CD = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString(),
					EDT_DTL_ERR_8_EXPLAN_DESC = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
					_wherePed = WherePed,
					_whereEdt_process_date = WhereEdt_process_date,
					_whereKey_dtl_seq_nbr = WhereKey_dtl_seq_nbr,
					_whereEdt_oma_service_cd_and_suffix = WhereEdt_oma_service_cd_and_suffix,
					_whereEdt_service_date = WhereEdt_service_date,
					_whereEdt_dtl_diag_cd = WhereEdt_dtl_diag_cd,
					_whereEdt_nbr_serv = WhereEdt_nbr_serv,
					_whereEdt_amount_submitted = WhereEdt_amount_submitted,
					_whereEdt_dtl_err_explan_cd = WhereEdt_dtl_err_explan_cd,
					_whereEdt_dtl_err_cd_1 = WhereEdt_dtl_err_cd_1,
					_whereEdt_dtl_err_cd_2 = WhereEdt_dtl_err_cd_2,
					_whereEdt_dtl_err_cd_3 = WhereEdt_dtl_err_cd_3,
					_whereEdt_dtl_err_cd_4 = WhereEdt_dtl_err_cd_4,
					_whereEdt_dtl_err_cd_5 = WhereEdt_dtl_err_cd_5,
					_whereEdt_dtl_err_8_explan_cd = WhereEdt_dtl_err_8_explan_cd,
					_whereEdt_dtl_err_8_explan_desc = WhereEdt_dtl_err_8_explan_desc,
					_whereEntry_date = WhereEntry_date,
					_whereEntry_time_long = WhereEntry_time_long,
					_whereEntry_user_id = WhereEntry_user_id,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]),
					_originalEdt_oma_service_cd_and_suffix = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString(),
					_originalEdt_service_date = ConvertDEC(Reader["EDT_SERVICE_DATE"]),
					_originalEdt_dtl_diag_cd = Reader["EDT_DTL_DIAG_CD"].ToString(),
					_originalEdt_nbr_serv = ConvertDEC(Reader["EDT_NBR_SERV"]),
					_originalEdt_amount_submitted = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]),
					_originalEdt_dtl_err_explan_cd = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString(),
					_originalEdt_dtl_err_cd_1 = Reader["EDT_DTL_ERR_CD_1"].ToString(),
					_originalEdt_dtl_err_cd_2 = Reader["EDT_DTL_ERR_CD_2"].ToString(),
					_originalEdt_dtl_err_cd_3 = Reader["EDT_DTL_ERR_CD_3"].ToString(),
					_originalEdt_dtl_err_cd_4 = Reader["EDT_DTL_ERR_CD_4"].ToString(),
					_originalEdt_dtl_err_cd_5 = Reader["EDT_DTL_ERR_CD_5"].ToString(),
					_originalEdt_dtl_err_8_explan_cd = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString(),
					_originalEdt_dtl_err_8_explan_desc = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString(),
					_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]),
					_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_wherePed = WherePed;
					_whereEdt_process_date = WhereEdt_process_date;
					_whereKey_dtl_seq_nbr = WhereKey_dtl_seq_nbr;
					_whereEdt_oma_service_cd_and_suffix = WhereEdt_oma_service_cd_and_suffix;
					_whereEdt_service_date = WhereEdt_service_date;
					_whereEdt_dtl_diag_cd = WhereEdt_dtl_diag_cd;
					_whereEdt_nbr_serv = WhereEdt_nbr_serv;
					_whereEdt_amount_submitted = WhereEdt_amount_submitted;
					_whereEdt_dtl_err_explan_cd = WhereEdt_dtl_err_explan_cd;
					_whereEdt_dtl_err_cd_1 = WhereEdt_dtl_err_cd_1;
					_whereEdt_dtl_err_cd_2 = WhereEdt_dtl_err_cd_2;
					_whereEdt_dtl_err_cd_3 = WhereEdt_dtl_err_cd_3;
					_whereEdt_dtl_err_cd_4 = WhereEdt_dtl_err_cd_4;
					_whereEdt_dtl_err_cd_5 = WhereEdt_dtl_err_cd_5;
					_whereEdt_dtl_err_8_explan_cd = WhereEdt_dtl_err_8_explan_cd;
					_whereEdt_dtl_err_8_explan_desc = WhereEdt_dtl_err_8_explan_desc;
					_whereEntry_date = WhereEntry_date;
					_whereEntry_time_long = WhereEntry_time_long;
					_whereEntry_user_id = WhereEntry_user_id;
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
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WherePed == null 
				&& WhereEdt_process_date == null 
				&& WhereKey_dtl_seq_nbr == null 
				&& WhereEdt_oma_service_cd_and_suffix == null 
				&& WhereEdt_service_date == null 
				&& WhereEdt_dtl_diag_cd == null 
				&& WhereEdt_nbr_serv == null 
				&& WhereEdt_amount_submitted == null 
				&& WhereEdt_dtl_err_explan_cd == null 
				&& WhereEdt_dtl_err_cd_1 == null 
				&& WhereEdt_dtl_err_cd_2 == null 
				&& WhereEdt_dtl_err_cd_3 == null 
				&& WhereEdt_dtl_err_cd_4 == null 
				&& WhereEdt_dtl_err_cd_5 == null 
				&& WhereEdt_dtl_err_8_explan_cd == null 
				&& WhereEdt_dtl_err_8_explan_desc == null 
				&& WhereEntry_date == null 
				&& WhereEntry_time_long == null 
				&& WhereEntry_user_id == null 
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
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WherePed ==  _wherePed
				&& WhereEdt_process_date ==  _whereEdt_process_date
				&& WhereKey_dtl_seq_nbr ==  _whereKey_dtl_seq_nbr
				&& WhereEdt_oma_service_cd_and_suffix ==  _whereEdt_oma_service_cd_and_suffix
				&& WhereEdt_service_date ==  _whereEdt_service_date
				&& WhereEdt_dtl_diag_cd ==  _whereEdt_dtl_diag_cd
				&& WhereEdt_nbr_serv ==  _whereEdt_nbr_serv
				&& WhereEdt_amount_submitted ==  _whereEdt_amount_submitted
				&& WhereEdt_dtl_err_explan_cd ==  _whereEdt_dtl_err_explan_cd
				&& WhereEdt_dtl_err_cd_1 ==  _whereEdt_dtl_err_cd_1
				&& WhereEdt_dtl_err_cd_2 ==  _whereEdt_dtl_err_cd_2
				&& WhereEdt_dtl_err_cd_3 ==  _whereEdt_dtl_err_cd_3
				&& WhereEdt_dtl_err_cd_4 ==  _whereEdt_dtl_err_cd_4
				&& WhereEdt_dtl_err_cd_5 ==  _whereEdt_dtl_err_cd_5
				&& WhereEdt_dtl_err_8_explan_cd ==  _whereEdt_dtl_err_8_explan_cd
				&& WhereEdt_dtl_err_8_explan_desc ==  _whereEdt_dtl_err_8_explan_desc
				&& WhereEntry_date ==  _whereEntry_date
				&& WhereEntry_time_long ==  _whereEntry_time_long
				&& WhereEntry_user_id ==  _whereEntry_user_id
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WherePed = null; 
			WhereEdt_process_date = null; 
			WhereKey_dtl_seq_nbr = null; 
			WhereEdt_oma_service_cd_and_suffix = null; 
			WhereEdt_service_date = null; 
			WhereEdt_dtl_diag_cd = null; 
			WhereEdt_nbr_serv = null; 
			WhereEdt_amount_submitted = null; 
			WhereEdt_dtl_err_explan_cd = null; 
			WhereEdt_dtl_err_cd_1 = null; 
			WhereEdt_dtl_err_cd_2 = null; 
			WhereEdt_dtl_err_cd_3 = null; 
			WhereEdt_dtl_err_cd_4 = null; 
			WhereEdt_dtl_err_cd_5 = null; 
			WhereEdt_dtl_err_8_explan_cd = null; 
			WhereEdt_dtl_err_8_explan_desc = null; 
			WhereEntry_date = null; 
			WhereEntry_time_long = null; 
			WhereEntry_user_id = null; 
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
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private decimal? _PED;
		private decimal? _EDT_PROCESS_DATE;
		private decimal? _KEY_DTL_SEQ_NBR;
		private string _EDT_OMA_SERVICE_CD_AND_SUFFIX;
		private decimal? _EDT_SERVICE_DATE;
		private string _EDT_DTL_DIAG_CD;
		private decimal? _EDT_NBR_SERV;
		private decimal? _EDT_AMOUNT_SUBMITTED;
		private string _EDT_DTL_ERR_EXPLAN_CD;
		private string _EDT_DTL_ERR_CD_1;
		private string _EDT_DTL_ERR_CD_2;
		private string _EDT_DTL_ERR_CD_3;
		private string _EDT_DTL_ERR_CD_4;
		private string _EDT_DTL_ERR_CD_5;
		private string _EDT_DTL_ERR_8_EXPLAN_CD;
		private string _EDT_DTL_ERR_8_EXPLAN_DESC;
		private decimal? _ENTRY_DATE;
		private decimal? _ENTRY_TIME_LONG;
		private string _ENTRY_USER_ID;
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
		public decimal? PED
		{
			get { return _PED; }
			set
			{
				if (_PED != value)
				{
					_PED = value;
					ChangeState();
				}
			}
		}
		public decimal? EDT_PROCESS_DATE
		{
			get { return _EDT_PROCESS_DATE; }
			set
			{
				if (_EDT_PROCESS_DATE != value)
				{
					_EDT_PROCESS_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? KEY_DTL_SEQ_NBR
		{
			get { return _KEY_DTL_SEQ_NBR; }
			set
			{
				if (_KEY_DTL_SEQ_NBR != value)
				{
					_KEY_DTL_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string EDT_OMA_SERVICE_CD_AND_SUFFIX
		{
			get { return _EDT_OMA_SERVICE_CD_AND_SUFFIX; }
			set
			{
				if (_EDT_OMA_SERVICE_CD_AND_SUFFIX != value)
				{
					_EDT_OMA_SERVICE_CD_AND_SUFFIX = value;
					ChangeState();
				}
			}
		}
		public decimal? EDT_SERVICE_DATE
		{
			get { return _EDT_SERVICE_DATE; }
			set
			{
				if (_EDT_SERVICE_DATE != value)
				{
					_EDT_SERVICE_DATE = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_DIAG_CD
		{
			get { return _EDT_DTL_DIAG_CD; }
			set
			{
				if (_EDT_DTL_DIAG_CD != value)
				{
					_EDT_DTL_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? EDT_NBR_SERV
		{
			get { return _EDT_NBR_SERV; }
			set
			{
				if (_EDT_NBR_SERV != value)
				{
					_EDT_NBR_SERV = value;
					ChangeState();
				}
			}
		}
		public decimal? EDT_AMOUNT_SUBMITTED
		{
			get { return _EDT_AMOUNT_SUBMITTED; }
			set
			{
				if (_EDT_AMOUNT_SUBMITTED != value)
				{
					_EDT_AMOUNT_SUBMITTED = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_EXPLAN_CD
		{
			get { return _EDT_DTL_ERR_EXPLAN_CD; }
			set
			{
				if (_EDT_DTL_ERR_EXPLAN_CD != value)
				{
					_EDT_DTL_ERR_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_CD_1
		{
			get { return _EDT_DTL_ERR_CD_1; }
			set
			{
				if (_EDT_DTL_ERR_CD_1 != value)
				{
					_EDT_DTL_ERR_CD_1 = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_CD_2
		{
			get { return _EDT_DTL_ERR_CD_2; }
			set
			{
				if (_EDT_DTL_ERR_CD_2 != value)
				{
					_EDT_DTL_ERR_CD_2 = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_CD_3
		{
			get { return _EDT_DTL_ERR_CD_3; }
			set
			{
				if (_EDT_DTL_ERR_CD_3 != value)
				{
					_EDT_DTL_ERR_CD_3 = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_CD_4
		{
			get { return _EDT_DTL_ERR_CD_4; }
			set
			{
				if (_EDT_DTL_ERR_CD_4 != value)
				{
					_EDT_DTL_ERR_CD_4 = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_CD_5
		{
			get { return _EDT_DTL_ERR_CD_5; }
			set
			{
				if (_EDT_DTL_ERR_CD_5 != value)
				{
					_EDT_DTL_ERR_CD_5 = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_8_EXPLAN_CD
		{
			get { return _EDT_DTL_ERR_8_EXPLAN_CD; }
			set
			{
				if (_EDT_DTL_ERR_8_EXPLAN_CD != value)
				{
					_EDT_DTL_ERR_8_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public string EDT_DTL_ERR_8_EXPLAN_DESC
		{
			get { return _EDT_DTL_ERR_8_EXPLAN_DESC; }
			set
			{
				if (_EDT_DTL_ERR_8_EXPLAN_DESC != value)
				{
					_EDT_DTL_ERR_8_EXPLAN_DESC = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_DATE
		{
			get { return _ENTRY_DATE; }
			set
			{
				if (_ENTRY_DATE != value)
				{
					_ENTRY_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? ENTRY_TIME_LONG
		{
			get { return _ENTRY_TIME_LONG; }
			set
			{
				if (_ENTRY_TIME_LONG != value)
				{
					_ENTRY_TIME_LONG = value;
					ChangeState();
				}
			}
		}
		public string ENTRY_USER_ID
		{
			get { return _ENTRY_USER_ID; }
			set
			{
				if (_ENTRY_USER_ID != value)
				{
					_ENTRY_USER_ID = value;
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
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public decimal? WherePed { get; set; }
		private decimal? _wherePed;
		public decimal? WhereEdt_process_date { get; set; }
		private decimal? _whereEdt_process_date;
		public decimal? WhereKey_dtl_seq_nbr { get; set; }
		private decimal? _whereKey_dtl_seq_nbr;
		public string WhereEdt_oma_service_cd_and_suffix { get; set; }
		private string _whereEdt_oma_service_cd_and_suffix;
		public decimal? WhereEdt_service_date { get; set; }
		private decimal? _whereEdt_service_date;
		public string WhereEdt_dtl_diag_cd { get; set; }
		private string _whereEdt_dtl_diag_cd;
		public decimal? WhereEdt_nbr_serv { get; set; }
		private decimal? _whereEdt_nbr_serv;
		public decimal? WhereEdt_amount_submitted { get; set; }
		private decimal? _whereEdt_amount_submitted;
		public string WhereEdt_dtl_err_explan_cd { get; set; }
		private string _whereEdt_dtl_err_explan_cd;
		public string WhereEdt_dtl_err_cd_1 { get; set; }
		private string _whereEdt_dtl_err_cd_1;
		public string WhereEdt_dtl_err_cd_2 { get; set; }
		private string _whereEdt_dtl_err_cd_2;
		public string WhereEdt_dtl_err_cd_3 { get; set; }
		private string _whereEdt_dtl_err_cd_3;
		public string WhereEdt_dtl_err_cd_4 { get; set; }
		private string _whereEdt_dtl_err_cd_4;
		public string WhereEdt_dtl_err_cd_5 { get; set; }
		private string _whereEdt_dtl_err_cd_5;
		public string WhereEdt_dtl_err_8_explan_cd { get; set; }
		private string _whereEdt_dtl_err_8_explan_cd;
		public string WhereEdt_dtl_err_8_explan_desc { get; set; }
		private string _whereEdt_dtl_err_8_explan_desc;
		public decimal? WhereEntry_date { get; set; }
		private decimal? _whereEntry_date;
		public decimal? WhereEntry_time_long { get; set; }
		private decimal? _whereEntry_time_long;
		public string WhereEntry_user_id { get; set; }
		private string _whereEntry_user_id;
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
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private decimal? _originalPed;
		private decimal? _originalEdt_process_date;
		private decimal? _originalKey_dtl_seq_nbr;
		private string _originalEdt_oma_service_cd_and_suffix;
		private decimal? _originalEdt_service_date;
		private string _originalEdt_dtl_diag_cd;
		private decimal? _originalEdt_nbr_serv;
		private decimal? _originalEdt_amount_submitted;
		private string _originalEdt_dtl_err_explan_cd;
		private string _originalEdt_dtl_err_cd_1;
		private string _originalEdt_dtl_err_cd_2;
		private string _originalEdt_dtl_err_cd_3;
		private string _originalEdt_dtl_err_cd_4;
		private string _originalEdt_dtl_err_cd_5;
		private string _originalEdt_dtl_err_8_explan_cd;
		private string _originalEdt_dtl_err_8_explan_desc;
		private decimal? _originalEntry_date;
		private decimal? _originalEntry_time_long;
		private string _originalEntry_user_id;
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
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			PED = _originalPed;
			EDT_PROCESS_DATE = _originalEdt_process_date;
			KEY_DTL_SEQ_NBR = _originalKey_dtl_seq_nbr;
			EDT_OMA_SERVICE_CD_AND_SUFFIX = _originalEdt_oma_service_cd_and_suffix;
			EDT_SERVICE_DATE = _originalEdt_service_date;
			EDT_DTL_DIAG_CD = _originalEdt_dtl_diag_cd;
			EDT_NBR_SERV = _originalEdt_nbr_serv;
			EDT_AMOUNT_SUBMITTED = _originalEdt_amount_submitted;
			EDT_DTL_ERR_EXPLAN_CD = _originalEdt_dtl_err_explan_cd;
			EDT_DTL_ERR_CD_1 = _originalEdt_dtl_err_cd_1;
			EDT_DTL_ERR_CD_2 = _originalEdt_dtl_err_cd_2;
			EDT_DTL_ERR_CD_3 = _originalEdt_dtl_err_cd_3;
			EDT_DTL_ERR_CD_4 = _originalEdt_dtl_err_cd_4;
			EDT_DTL_ERR_CD_5 = _originalEdt_dtl_err_cd_5;
			EDT_DTL_ERR_8_EXPLAN_CD = _originalEdt_dtl_err_8_explan_cd;
			EDT_DTL_ERR_8_EXPLAN_DESC = _originalEdt_dtl_err_8_explan_desc;
			ENTRY_DATE = _originalEntry_date;
			ENTRY_TIME_LONG = _originalEntry_time_long;
			ENTRY_USER_ID = _originalEntry_user_id;
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
					new SqlParameter("ROWID",ROWID),
					new SqlParameter("CLMHDR_BATCH_NBR",CLMHDR_BATCH_NBR),
					new SqlParameter("CLMHDR_CLAIM_NBR",CLMHDR_CLAIM_NBR),
					new SqlParameter("PED",PED),
					new SqlParameter("EDT_PROCESS_DATE",EDT_PROCESS_DATE),
					new SqlParameter("KEY_DTL_SEQ_NBR",KEY_DTL_SEQ_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_Purge]");
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
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("EDT_PROCESS_DATE", SqlNull(EDT_PROCESS_DATE)),
						new SqlParameter("KEY_DTL_SEQ_NBR", SqlNull(KEY_DTL_SEQ_NBR)),
						new SqlParameter("EDT_OMA_SERVICE_CD_AND_SUFFIX", SqlNull(EDT_OMA_SERVICE_CD_AND_SUFFIX)),
						new SqlParameter("EDT_SERVICE_DATE", SqlNull(EDT_SERVICE_DATE)),
						new SqlParameter("EDT_DTL_DIAG_CD", SqlNull(EDT_DTL_DIAG_CD)),
						new SqlParameter("EDT_NBR_SERV", SqlNull(EDT_NBR_SERV)),
						new SqlParameter("EDT_AMOUNT_SUBMITTED", SqlNull(EDT_AMOUNT_SUBMITTED)),
						new SqlParameter("EDT_DTL_ERR_EXPLAN_CD", SqlNull(EDT_DTL_ERR_EXPLAN_CD)),
						new SqlParameter("EDT_DTL_ERR_CD_1", SqlNull(EDT_DTL_ERR_CD_1)),
						new SqlParameter("EDT_DTL_ERR_CD_2", SqlNull(EDT_DTL_ERR_CD_2)),
						new SqlParameter("EDT_DTL_ERR_CD_3", SqlNull(EDT_DTL_ERR_CD_3)),
						new SqlParameter("EDT_DTL_ERR_CD_4", SqlNull(EDT_DTL_ERR_CD_4)),
						new SqlParameter("EDT_DTL_ERR_CD_5", SqlNull(EDT_DTL_ERR_CD_5)),
						new SqlParameter("EDT_DTL_ERR_8_EXPLAN_CD", SqlNull(EDT_DTL_ERR_8_EXPLAN_CD)),
						new SqlParameter("EDT_DTL_ERR_8_EXPLAN_DESC", SqlNull(EDT_DTL_ERR_8_EXPLAN_DESC)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						PED = ConvertDEC(Reader["PED"]);
						EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						EDT_OMA_SERVICE_CD_AND_SUFFIX = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString();
						EDT_SERVICE_DATE = ConvertDEC(Reader["EDT_SERVICE_DATE"]);
						EDT_DTL_DIAG_CD = Reader["EDT_DTL_DIAG_CD"].ToString();
						EDT_NBR_SERV = ConvertDEC(Reader["EDT_NBR_SERV"]);
						EDT_AMOUNT_SUBMITTED = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]);
						EDT_DTL_ERR_EXPLAN_CD = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString();
						EDT_DTL_ERR_CD_1 = Reader["EDT_DTL_ERR_CD_1"].ToString();
						EDT_DTL_ERR_CD_2 = Reader["EDT_DTL_ERR_CD_2"].ToString();
						EDT_DTL_ERR_CD_3 = Reader["EDT_DTL_ERR_CD_3"].ToString();
						EDT_DTL_ERR_CD_4 = Reader["EDT_DTL_ERR_CD_4"].ToString();
						EDT_DTL_ERR_CD_5 = Reader["EDT_DTL_ERR_CD_5"].ToString();
						EDT_DTL_ERR_8_EXPLAN_CD = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString();
						EDT_DTL_ERR_8_EXPLAN_DESC = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						_originalEdt_oma_service_cd_and_suffix = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString();
						_originalEdt_service_date = ConvertDEC(Reader["EDT_SERVICE_DATE"]);
						_originalEdt_dtl_diag_cd = Reader["EDT_DTL_DIAG_CD"].ToString();
						_originalEdt_nbr_serv = ConvertDEC(Reader["EDT_NBR_SERV"]);
						_originalEdt_amount_submitted = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]);
						_originalEdt_dtl_err_explan_cd = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString();
						_originalEdt_dtl_err_cd_1 = Reader["EDT_DTL_ERR_CD_1"].ToString();
						_originalEdt_dtl_err_cd_2 = Reader["EDT_DTL_ERR_CD_2"].ToString();
						_originalEdt_dtl_err_cd_3 = Reader["EDT_DTL_ERR_CD_3"].ToString();
						_originalEdt_dtl_err_cd_4 = Reader["EDT_DTL_ERR_CD_4"].ToString();
						_originalEdt_dtl_err_cd_5 = Reader["EDT_DTL_ERR_CD_5"].ToString();
						_originalEdt_dtl_err_8_explan_cd = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString();
						_originalEdt_dtl_err_8_explan_desc = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
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
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("EDT_PROCESS_DATE", SqlNull(EDT_PROCESS_DATE)),
						new SqlParameter("KEY_DTL_SEQ_NBR", SqlNull(KEY_DTL_SEQ_NBR)),
						new SqlParameter("EDT_OMA_SERVICE_CD_AND_SUFFIX", SqlNull(EDT_OMA_SERVICE_CD_AND_SUFFIX)),
						new SqlParameter("EDT_SERVICE_DATE", SqlNull(EDT_SERVICE_DATE)),
						new SqlParameter("EDT_DTL_DIAG_CD", SqlNull(EDT_DTL_DIAG_CD)),
						new SqlParameter("EDT_NBR_SERV", SqlNull(EDT_NBR_SERV)),
						new SqlParameter("EDT_AMOUNT_SUBMITTED", SqlNull(EDT_AMOUNT_SUBMITTED)),
						new SqlParameter("EDT_DTL_ERR_EXPLAN_CD", SqlNull(EDT_DTL_ERR_EXPLAN_CD)),
						new SqlParameter("EDT_DTL_ERR_CD_1", SqlNull(EDT_DTL_ERR_CD_1)),
						new SqlParameter("EDT_DTL_ERR_CD_2", SqlNull(EDT_DTL_ERR_CD_2)),
						new SqlParameter("EDT_DTL_ERR_CD_3", SqlNull(EDT_DTL_ERR_CD_3)),
						new SqlParameter("EDT_DTL_ERR_CD_4", SqlNull(EDT_DTL_ERR_CD_4)),
						new SqlParameter("EDT_DTL_ERR_CD_5", SqlNull(EDT_DTL_ERR_CD_5)),
						new SqlParameter("EDT_DTL_ERR_8_EXPLAN_CD", SqlNull(EDT_DTL_ERR_8_EXPLAN_CD)),
						new SqlParameter("EDT_DTL_ERR_8_EXPLAN_DESC", SqlNull(EDT_DTL_ERR_8_EXPLAN_DESC)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_DTL_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						PED = ConvertDEC(Reader["PED"]);
						EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						KEY_DTL_SEQ_NBR = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						EDT_OMA_SERVICE_CD_AND_SUFFIX = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString();
						EDT_SERVICE_DATE = ConvertDEC(Reader["EDT_SERVICE_DATE"]);
						EDT_DTL_DIAG_CD = Reader["EDT_DTL_DIAG_CD"].ToString();
						EDT_NBR_SERV = ConvertDEC(Reader["EDT_NBR_SERV"]);
						EDT_AMOUNT_SUBMITTED = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]);
						EDT_DTL_ERR_EXPLAN_CD = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString();
						EDT_DTL_ERR_CD_1 = Reader["EDT_DTL_ERR_CD_1"].ToString();
						EDT_DTL_ERR_CD_2 = Reader["EDT_DTL_ERR_CD_2"].ToString();
						EDT_DTL_ERR_CD_3 = Reader["EDT_DTL_ERR_CD_3"].ToString();
						EDT_DTL_ERR_CD_4 = Reader["EDT_DTL_ERR_CD_4"].ToString();
						EDT_DTL_ERR_CD_5 = Reader["EDT_DTL_ERR_CD_5"].ToString();
						EDT_DTL_ERR_8_EXPLAN_CD = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString();
						EDT_DTL_ERR_8_EXPLAN_DESC = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						_originalKey_dtl_seq_nbr = ConvertDEC(Reader["KEY_DTL_SEQ_NBR"]);
						_originalEdt_oma_service_cd_and_suffix = Reader["EDT_OMA_SERVICE_CD_AND_SUFFIX"].ToString();
						_originalEdt_service_date = ConvertDEC(Reader["EDT_SERVICE_DATE"]);
						_originalEdt_dtl_diag_cd = Reader["EDT_DTL_DIAG_CD"].ToString();
						_originalEdt_nbr_serv = ConvertDEC(Reader["EDT_NBR_SERV"]);
						_originalEdt_amount_submitted = ConvertDEC(Reader["EDT_AMOUNT_SUBMITTED"]);
						_originalEdt_dtl_err_explan_cd = Reader["EDT_DTL_ERR_EXPLAN_CD"].ToString();
						_originalEdt_dtl_err_cd_1 = Reader["EDT_DTL_ERR_CD_1"].ToString();
						_originalEdt_dtl_err_cd_2 = Reader["EDT_DTL_ERR_CD_2"].ToString();
						_originalEdt_dtl_err_cd_3 = Reader["EDT_DTL_ERR_CD_3"].ToString();
						_originalEdt_dtl_err_cd_4 = Reader["EDT_DTL_ERR_CD_4"].ToString();
						_originalEdt_dtl_err_cd_5 = Reader["EDT_DTL_ERR_CD_5"].ToString();
						_originalEdt_dtl_err_8_explan_cd = Reader["EDT_DTL_ERR_8_EXPLAN_CD"].ToString();
						_originalEdt_dtl_err_8_explan_desc = Reader["EDT_DTL_ERR_8_EXPLAN_DESC"].ToString();
						_originalEntry_date = ConvertDEC(Reader["ENTRY_DATE"]);
						_originalEntry_time_long = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						_originalEntry_user_id = Reader["ENTRY_USER_ID"].ToString();
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