using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F087_SUBMITTED_REJECTED_CLAIMS_HDR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR> Collection( Guid? rowid,
															string clmhdr_doc_nbr,
															decimal? pedmin,
															decimal? pedmax,
															string clmhdr_batch_nbr,
															decimal? clmhdr_claim_nbrmin,
															decimal? clmhdr_claim_nbrmax,
															decimal? edt_process_datemin,
															decimal? edt_process_datemax,
															decimal? edt_pat_birth_datemin,
															decimal? edt_pat_birth_datemax,
															string edt_account_nbr,
															string edt_health_nbr,
															string edt_health_version_cd,
															string edt_pay_prog,
															string edt_payee,
															decimal? eft_referring_doc_nbrmin,
															decimal? eft_referring_doc_nbrmax,
															string edt_facility_nbr,
															decimal? edt_admit_datemin,
															decimal? edt_admit_datemax,
															string edt_location_cd,
															string ohip_err_code,
															string edt_err_h_cd_1,
															string edt_err_h_cd_2,
															string edt_err_h_cd_3,
															string edt_err_h_cd_4,
															string edt_err_h_cd_5,
															string charge_status,
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
					new SqlParameter("CLMHDR_DOC_NBR",clmhdr_doc_nbr),
					new SqlParameter("minPED",pedmin),
					new SqlParameter("maxPED",pedmax),
					new SqlParameter("CLMHDR_BATCH_NBR",clmhdr_batch_nbr),
					new SqlParameter("minCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmin),
					new SqlParameter("maxCLMHDR_CLAIM_NBR",clmhdr_claim_nbrmax),
					new SqlParameter("minEDT_PROCESS_DATE",edt_process_datemin),
					new SqlParameter("maxEDT_PROCESS_DATE",edt_process_datemax),
					new SqlParameter("minEDT_PAT_BIRTH_DATE",edt_pat_birth_datemin),
					new SqlParameter("maxEDT_PAT_BIRTH_DATE",edt_pat_birth_datemax),
					new SqlParameter("EDT_ACCOUNT_NBR",edt_account_nbr),
					new SqlParameter("EDT_HEALTH_NBR",edt_health_nbr),
					new SqlParameter("EDT_HEALTH_VERSION_CD",edt_health_version_cd),
					new SqlParameter("EDT_PAY_PROG",edt_pay_prog),
					new SqlParameter("EDT_PAYEE",edt_payee),
					new SqlParameter("minEFT_REFERRING_DOC_NBR",eft_referring_doc_nbrmin),
					new SqlParameter("maxEFT_REFERRING_DOC_NBR",eft_referring_doc_nbrmax),
					new SqlParameter("EDT_FACILITY_NBR",edt_facility_nbr),
					new SqlParameter("minEDT_ADMIT_DATE",edt_admit_datemin),
					new SqlParameter("maxEDT_ADMIT_DATE",edt_admit_datemax),
					new SqlParameter("EDT_LOCATION_CD",edt_location_cd),
					new SqlParameter("OHIP_ERR_CODE",ohip_err_code),
					new SqlParameter("EDT_ERR_H_CD_1",edt_err_h_cd_1),
					new SqlParameter("EDT_ERR_H_CD_2",edt_err_h_cd_2),
					new SqlParameter("EDT_ERR_H_CD_3",edt_err_h_cd_3),
					new SqlParameter("EDT_ERR_H_CD_4",edt_err_h_cd_4),
					new SqlParameter("EDT_ERR_H_CD_5",edt_err_h_cd_5),
					new SqlParameter("CHARGE_STATUS",charge_status),
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
                Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_Search]", parameters);
            var collection = new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F087_SUBMITTED_REJECTED_CLAIMS_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					PED = ConvertDEC(Reader["PED"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					EDT_PAT_BIRTH_DATE = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]),
					EDT_ACCOUNT_NBR = Reader["EDT_ACCOUNT_NBR"].ToString(),
					EDT_HEALTH_NBR = Reader["EDT_HEALTH_NBR"].ToString(),
					EDT_HEALTH_VERSION_CD = Reader["EDT_HEALTH_VERSION_CD"].ToString(),
					EDT_PAY_PROG = Reader["EDT_PAY_PROG"].ToString(),
					EDT_PAYEE = Reader["EDT_PAYEE"].ToString(),
					EFT_REFERRING_DOC_NBR = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]),
					EDT_FACILITY_NBR = Reader["EDT_FACILITY_NBR"].ToString(),
					EDT_ADMIT_DATE = ConvertDEC(Reader["EDT_ADMIT_DATE"]),
					EDT_LOCATION_CD = Reader["EDT_LOCATION_CD"].ToString(),
					OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString(),
					EDT_ERR_H_CD_1 = Reader["EDT_ERR_H_CD_1"].ToString(),
					EDT_ERR_H_CD_2 = Reader["EDT_ERR_H_CD_2"].ToString(),
					EDT_ERR_H_CD_3 = Reader["EDT_ERR_H_CD_3"].ToString(),
					EDT_ERR_H_CD_4 = Reader["EDT_ERR_H_CD_4"].ToString(),
					EDT_ERR_H_CD_5 = Reader["EDT_ERR_H_CD_5"].ToString(),
					CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					_originalEdt_pat_birth_date = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]),
					_originalEdt_account_nbr = Reader["EDT_ACCOUNT_NBR"].ToString(),
					_originalEdt_health_nbr = Reader["EDT_HEALTH_NBR"].ToString(),
					_originalEdt_health_version_cd = Reader["EDT_HEALTH_VERSION_CD"].ToString(),
					_originalEdt_pay_prog = Reader["EDT_PAY_PROG"].ToString(),
					_originalEdt_payee = Reader["EDT_PAYEE"].ToString(),
					_originalEft_referring_doc_nbr = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]),
					_originalEdt_facility_nbr = Reader["EDT_FACILITY_NBR"].ToString(),
					_originalEdt_admit_date = ConvertDEC(Reader["EDT_ADMIT_DATE"]),
					_originalEdt_location_cd = Reader["EDT_LOCATION_CD"].ToString(),
					_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString(),
					_originalEdt_err_h_cd_1 = Reader["EDT_ERR_H_CD_1"].ToString(),
					_originalEdt_err_h_cd_2 = Reader["EDT_ERR_H_CD_2"].ToString(),
					_originalEdt_err_h_cd_3 = Reader["EDT_ERR_H_CD_3"].ToString(),
					_originalEdt_err_h_cd_4 = Reader["EDT_ERR_H_CD_4"].ToString(),
					_originalEdt_err_h_cd_5 = Reader["EDT_ERR_H_CD_5"].ToString(),
					_originalCharge_status = Reader["CHARGE_STATUS"].ToString(),
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

        public F087_SUBMITTED_REJECTED_CLAIMS_HDR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR> Collection(ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR>
                                                               f087SubmittedRejectedClaimsHdr = null)
        {
            if (IsSameSearch() && f087SubmittedRejectedClaimsHdr != null)
            {
                return f087SubmittedRejectedClaimsHdr;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMHDR_DOC_NBR",WhereClmhdr_doc_nbr),
					new SqlParameter("PED",WherePed),
					new SqlParameter("CLMHDR_BATCH_NBR",WhereClmhdr_batch_nbr),
					new SqlParameter("CLMHDR_CLAIM_NBR",WhereClmhdr_claim_nbr),
					new SqlParameter("EDT_PROCESS_DATE",WhereEdt_process_date),
					new SqlParameter("EDT_PAT_BIRTH_DATE",WhereEdt_pat_birth_date),
					new SqlParameter("EDT_ACCOUNT_NBR",WhereEdt_account_nbr),
					new SqlParameter("EDT_HEALTH_NBR",WhereEdt_health_nbr),
					new SqlParameter("EDT_HEALTH_VERSION_CD",WhereEdt_health_version_cd),
					new SqlParameter("EDT_PAY_PROG",WhereEdt_pay_prog),
					new SqlParameter("EDT_PAYEE",WhereEdt_payee),
					new SqlParameter("EFT_REFERRING_DOC_NBR",WhereEft_referring_doc_nbr),
					new SqlParameter("EDT_FACILITY_NBR",WhereEdt_facility_nbr),
					new SqlParameter("EDT_ADMIT_DATE",WhereEdt_admit_date),
					new SqlParameter("EDT_LOCATION_CD",WhereEdt_location_cd),
					new SqlParameter("OHIP_ERR_CODE",WhereOhip_err_code),
					new SqlParameter("EDT_ERR_H_CD_1",WhereEdt_err_h_cd_1),
					new SqlParameter("EDT_ERR_H_CD_2",WhereEdt_err_h_cd_2),
					new SqlParameter("EDT_ERR_H_CD_3",WhereEdt_err_h_cd_3),
					new SqlParameter("EDT_ERR_H_CD_4",WhereEdt_err_h_cd_4),
					new SqlParameter("EDT_ERR_H_CD_5",WhereEdt_err_h_cd_5),
					new SqlParameter("CHARGE_STATUS",WhereCharge_status),
					new SqlParameter("ENTRY_DATE",WhereEntry_date),
					new SqlParameter("ENTRY_TIME_LONG",WhereEntry_time_long),
					new SqlParameter("ENTRY_USER_ID",WhereEntry_user_id),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_Match]", parameters);
            var collection = new ObservableCollection<F087_SUBMITTED_REJECTED_CLAIMS_HDR>();

            while (Reader.Read())
            {
                collection.Add(new F087_SUBMITTED_REJECTED_CLAIMS_HDR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString(),
					PED = ConvertDEC(Reader["PED"]),
					CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString(),
					CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					EDT_PAT_BIRTH_DATE = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]),
					EDT_ACCOUNT_NBR = Reader["EDT_ACCOUNT_NBR"].ToString(),
					EDT_HEALTH_NBR = Reader["EDT_HEALTH_NBR"].ToString(),
					EDT_HEALTH_VERSION_CD = Reader["EDT_HEALTH_VERSION_CD"].ToString(),
					EDT_PAY_PROG = Reader["EDT_PAY_PROG"].ToString(),
					EDT_PAYEE = Reader["EDT_PAYEE"].ToString(),
					EFT_REFERRING_DOC_NBR = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]),
					EDT_FACILITY_NBR = Reader["EDT_FACILITY_NBR"].ToString(),
					EDT_ADMIT_DATE = ConvertDEC(Reader["EDT_ADMIT_DATE"]),
					EDT_LOCATION_CD = Reader["EDT_LOCATION_CD"].ToString(),
					OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString(),
					EDT_ERR_H_CD_1 = Reader["EDT_ERR_H_CD_1"].ToString(),
					EDT_ERR_H_CD_2 = Reader["EDT_ERR_H_CD_2"].ToString(),
					EDT_ERR_H_CD_3 = Reader["EDT_ERR_H_CD_3"].ToString(),
					EDT_ERR_H_CD_4 = Reader["EDT_ERR_H_CD_4"].ToString(),
					EDT_ERR_H_CD_5 = Reader["EDT_ERR_H_CD_5"].ToString(),
					CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString(),
					ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]),
					ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]),
					ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr,
					_wherePed = WherePed,
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr,
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr,
					_whereEdt_process_date = WhereEdt_process_date,
					_whereEdt_pat_birth_date = WhereEdt_pat_birth_date,
					_whereEdt_account_nbr = WhereEdt_account_nbr,
					_whereEdt_health_nbr = WhereEdt_health_nbr,
					_whereEdt_health_version_cd = WhereEdt_health_version_cd,
					_whereEdt_pay_prog = WhereEdt_pay_prog,
					_whereEdt_payee = WhereEdt_payee,
					_whereEft_referring_doc_nbr = WhereEft_referring_doc_nbr,
					_whereEdt_facility_nbr = WhereEdt_facility_nbr,
					_whereEdt_admit_date = WhereEdt_admit_date,
					_whereEdt_location_cd = WhereEdt_location_cd,
					_whereOhip_err_code = WhereOhip_err_code,
					_whereEdt_err_h_cd_1 = WhereEdt_err_h_cd_1,
					_whereEdt_err_h_cd_2 = WhereEdt_err_h_cd_2,
					_whereEdt_err_h_cd_3 = WhereEdt_err_h_cd_3,
					_whereEdt_err_h_cd_4 = WhereEdt_err_h_cd_4,
					_whereEdt_err_h_cd_5 = WhereEdt_err_h_cd_5,
					_whereCharge_status = WhereCharge_status,
					_whereEntry_date = WhereEntry_date,
					_whereEntry_time_long = WhereEntry_time_long,
					_whereEntry_user_id = WhereEntry_user_id,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString(),
					_originalPed = ConvertDEC(Reader["PED"]),
					_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString(),
					_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]),
					_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]),
					_originalEdt_pat_birth_date = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]),
					_originalEdt_account_nbr = Reader["EDT_ACCOUNT_NBR"].ToString(),
					_originalEdt_health_nbr = Reader["EDT_HEALTH_NBR"].ToString(),
					_originalEdt_health_version_cd = Reader["EDT_HEALTH_VERSION_CD"].ToString(),
					_originalEdt_pay_prog = Reader["EDT_PAY_PROG"].ToString(),
					_originalEdt_payee = Reader["EDT_PAYEE"].ToString(),
					_originalEft_referring_doc_nbr = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]),
					_originalEdt_facility_nbr = Reader["EDT_FACILITY_NBR"].ToString(),
					_originalEdt_admit_date = ConvertDEC(Reader["EDT_ADMIT_DATE"]),
					_originalEdt_location_cd = Reader["EDT_LOCATION_CD"].ToString(),
					_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString(),
					_originalEdt_err_h_cd_1 = Reader["EDT_ERR_H_CD_1"].ToString(),
					_originalEdt_err_h_cd_2 = Reader["EDT_ERR_H_CD_2"].ToString(),
					_originalEdt_err_h_cd_3 = Reader["EDT_ERR_H_CD_3"].ToString(),
					_originalEdt_err_h_cd_4 = Reader["EDT_ERR_H_CD_4"].ToString(),
					_originalEdt_err_h_cd_5 = Reader["EDT_ERR_H_CD_5"].ToString(),
					_originalCharge_status = Reader["CHARGE_STATUS"].ToString(),
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
					_whereClmhdr_doc_nbr = WhereClmhdr_doc_nbr;
					_wherePed = WherePed;
					_whereClmhdr_batch_nbr = WhereClmhdr_batch_nbr;
					_whereClmhdr_claim_nbr = WhereClmhdr_claim_nbr;
					_whereEdt_process_date = WhereEdt_process_date;
					_whereEdt_pat_birth_date = WhereEdt_pat_birth_date;
					_whereEdt_account_nbr = WhereEdt_account_nbr;
					_whereEdt_health_nbr = WhereEdt_health_nbr;
					_whereEdt_health_version_cd = WhereEdt_health_version_cd;
					_whereEdt_pay_prog = WhereEdt_pay_prog;
					_whereEdt_payee = WhereEdt_payee;
					_whereEft_referring_doc_nbr = WhereEft_referring_doc_nbr;
					_whereEdt_facility_nbr = WhereEdt_facility_nbr;
					_whereEdt_admit_date = WhereEdt_admit_date;
					_whereEdt_location_cd = WhereEdt_location_cd;
					_whereOhip_err_code = WhereOhip_err_code;
					_whereEdt_err_h_cd_1 = WhereEdt_err_h_cd_1;
					_whereEdt_err_h_cd_2 = WhereEdt_err_h_cd_2;
					_whereEdt_err_h_cd_3 = WhereEdt_err_h_cd_3;
					_whereEdt_err_h_cd_4 = WhereEdt_err_h_cd_4;
					_whereEdt_err_h_cd_5 = WhereEdt_err_h_cd_5;
					_whereCharge_status = WhereCharge_status;
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
				&& WhereClmhdr_doc_nbr == null 
				&& WherePed == null 
				&& WhereClmhdr_batch_nbr == null 
				&& WhereClmhdr_claim_nbr == null 
				&& WhereEdt_process_date == null 
				&& WhereEdt_pat_birth_date == null 
				&& WhereEdt_account_nbr == null 
				&& WhereEdt_health_nbr == null 
				&& WhereEdt_health_version_cd == null 
				&& WhereEdt_pay_prog == null 
				&& WhereEdt_payee == null 
				&& WhereEft_referring_doc_nbr == null 
				&& WhereEdt_facility_nbr == null 
				&& WhereEdt_admit_date == null 
				&& WhereEdt_location_cd == null 
				&& WhereOhip_err_code == null 
				&& WhereEdt_err_h_cd_1 == null 
				&& WhereEdt_err_h_cd_2 == null 
				&& WhereEdt_err_h_cd_3 == null 
				&& WhereEdt_err_h_cd_4 == null 
				&& WhereEdt_err_h_cd_5 == null 
				&& WhereCharge_status == null 
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
				&& WhereClmhdr_doc_nbr ==  _whereClmhdr_doc_nbr
				&& WherePed ==  _wherePed
				&& WhereClmhdr_batch_nbr ==  _whereClmhdr_batch_nbr
				&& WhereClmhdr_claim_nbr ==  _whereClmhdr_claim_nbr
				&& WhereEdt_process_date ==  _whereEdt_process_date
				&& WhereEdt_pat_birth_date ==  _whereEdt_pat_birth_date
				&& WhereEdt_account_nbr ==  _whereEdt_account_nbr
				&& WhereEdt_health_nbr ==  _whereEdt_health_nbr
				&& WhereEdt_health_version_cd ==  _whereEdt_health_version_cd
				&& WhereEdt_pay_prog ==  _whereEdt_pay_prog
				&& WhereEdt_payee ==  _whereEdt_payee
				&& WhereEft_referring_doc_nbr ==  _whereEft_referring_doc_nbr
				&& WhereEdt_facility_nbr ==  _whereEdt_facility_nbr
				&& WhereEdt_admit_date ==  _whereEdt_admit_date
				&& WhereEdt_location_cd ==  _whereEdt_location_cd
				&& WhereOhip_err_code ==  _whereOhip_err_code
				&& WhereEdt_err_h_cd_1 ==  _whereEdt_err_h_cd_1
				&& WhereEdt_err_h_cd_2 ==  _whereEdt_err_h_cd_2
				&& WhereEdt_err_h_cd_3 ==  _whereEdt_err_h_cd_3
				&& WhereEdt_err_h_cd_4 ==  _whereEdt_err_h_cd_4
				&& WhereEdt_err_h_cd_5 ==  _whereEdt_err_h_cd_5
				&& WhereCharge_status ==  _whereCharge_status
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
			WhereClmhdr_doc_nbr = null; 
			WherePed = null; 
			WhereClmhdr_batch_nbr = null; 
			WhereClmhdr_claim_nbr = null; 
			WhereEdt_process_date = null; 
			WhereEdt_pat_birth_date = null; 
			WhereEdt_account_nbr = null; 
			WhereEdt_health_nbr = null; 
			WhereEdt_health_version_cd = null; 
			WhereEdt_pay_prog = null; 
			WhereEdt_payee = null; 
			WhereEft_referring_doc_nbr = null; 
			WhereEdt_facility_nbr = null; 
			WhereEdt_admit_date = null; 
			WhereEdt_location_cd = null; 
			WhereOhip_err_code = null; 
			WhereEdt_err_h_cd_1 = null; 
			WhereEdt_err_h_cd_2 = null; 
			WhereEdt_err_h_cd_3 = null; 
			WhereEdt_err_h_cd_4 = null; 
			WhereEdt_err_h_cd_5 = null; 
			WhereCharge_status = null; 
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
		private string _CLMHDR_DOC_NBR;
		private decimal? _PED;
		private string _CLMHDR_BATCH_NBR;
		private decimal? _CLMHDR_CLAIM_NBR;
		private decimal? _EDT_PROCESS_DATE;
		private decimal? _EDT_PAT_BIRTH_DATE;
		private string _EDT_ACCOUNT_NBR;
		private string _EDT_HEALTH_NBR;
		private string _EDT_HEALTH_VERSION_CD;
		private string _EDT_PAY_PROG;
		private string _EDT_PAYEE;
		private decimal? _EFT_REFERRING_DOC_NBR;
		private string _EDT_FACILITY_NBR;
		private decimal? _EDT_ADMIT_DATE;
		private string _EDT_LOCATION_CD;
		private string _OHIP_ERR_CODE;
		private string _EDT_ERR_H_CD_1;
		private string _EDT_ERR_H_CD_2;
		private string _EDT_ERR_H_CD_3;
		private string _EDT_ERR_H_CD_4;
		private string _EDT_ERR_H_CD_5;
		private string _CHARGE_STATUS;
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
		public string CLMHDR_DOC_NBR
		{
			get { return _CLMHDR_DOC_NBR; }
			set
			{
				if (_CLMHDR_DOC_NBR != value)
				{
					_CLMHDR_DOC_NBR = value;
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
		public decimal? EDT_PAT_BIRTH_DATE
		{
			get { return _EDT_PAT_BIRTH_DATE; }
			set
			{
				if (_EDT_PAT_BIRTH_DATE != value)
				{
					_EDT_PAT_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string EDT_ACCOUNT_NBR
		{
			get { return _EDT_ACCOUNT_NBR; }
			set
			{
				if (_EDT_ACCOUNT_NBR != value)
				{
					_EDT_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public string EDT_HEALTH_NBR
		{
			get { return _EDT_HEALTH_NBR; }
			set
			{
				if (_EDT_HEALTH_NBR != value)
				{
					_EDT_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public string EDT_HEALTH_VERSION_CD
		{
			get { return _EDT_HEALTH_VERSION_CD; }
			set
			{
				if (_EDT_HEALTH_VERSION_CD != value)
				{
					_EDT_HEALTH_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public string EDT_PAY_PROG
		{
			get { return _EDT_PAY_PROG; }
			set
			{
				if (_EDT_PAY_PROG != value)
				{
					_EDT_PAY_PROG = value;
					ChangeState();
				}
			}
		}
		public string EDT_PAYEE
		{
			get { return _EDT_PAYEE; }
			set
			{
				if (_EDT_PAYEE != value)
				{
					_EDT_PAYEE = value;
					ChangeState();
				}
			}
		}
		public decimal? EFT_REFERRING_DOC_NBR
		{
			get { return _EFT_REFERRING_DOC_NBR; }
			set
			{
				if (_EFT_REFERRING_DOC_NBR != value)
				{
					_EFT_REFERRING_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string EDT_FACILITY_NBR
		{
			get { return _EDT_FACILITY_NBR; }
			set
			{
				if (_EDT_FACILITY_NBR != value)
				{
					_EDT_FACILITY_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? EDT_ADMIT_DATE
		{
			get { return _EDT_ADMIT_DATE; }
			set
			{
				if (_EDT_ADMIT_DATE != value)
				{
					_EDT_ADMIT_DATE = value;
					ChangeState();
				}
			}
		}
		public string EDT_LOCATION_CD
		{
			get { return _EDT_LOCATION_CD; }
			set
			{
				if (_EDT_LOCATION_CD != value)
				{
					_EDT_LOCATION_CD = value;
					ChangeState();
				}
			}
		}
		public string OHIP_ERR_CODE
		{
			get { return _OHIP_ERR_CODE; }
			set
			{
				if (_OHIP_ERR_CODE != value)
				{
					_OHIP_ERR_CODE = value;
					ChangeState();
				}
			}
		}
		public string EDT_ERR_H_CD_1
		{
			get { return _EDT_ERR_H_CD_1; }
			set
			{
				if (_EDT_ERR_H_CD_1 != value)
				{
					_EDT_ERR_H_CD_1 = value;
					ChangeState();
				}
			}
		}
		public string EDT_ERR_H_CD_2
		{
			get { return _EDT_ERR_H_CD_2; }
			set
			{
				if (_EDT_ERR_H_CD_2 != value)
				{
					_EDT_ERR_H_CD_2 = value;
					ChangeState();
				}
			}
		}
		public string EDT_ERR_H_CD_3
		{
			get { return _EDT_ERR_H_CD_3; }
			set
			{
				if (_EDT_ERR_H_CD_3 != value)
				{
					_EDT_ERR_H_CD_3 = value;
					ChangeState();
				}
			}
		}
		public string EDT_ERR_H_CD_4
		{
			get { return _EDT_ERR_H_CD_4; }
			set
			{
				if (_EDT_ERR_H_CD_4 != value)
				{
					_EDT_ERR_H_CD_4 = value;
					ChangeState();
				}
			}
		}
		public string EDT_ERR_H_CD_5
		{
			get { return _EDT_ERR_H_CD_5; }
			set
			{
				if (_EDT_ERR_H_CD_5 != value)
				{
					_EDT_ERR_H_CD_5 = value;
					ChangeState();
				}
			}
		}
		public string CHARGE_STATUS
		{
			get { return _CHARGE_STATUS; }
			set
			{
				if (_CHARGE_STATUS != value)
				{
					_CHARGE_STATUS = value;
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
		public string WhereClmhdr_doc_nbr { get; set; }
		private string _whereClmhdr_doc_nbr;
		public decimal? WherePed { get; set; }
		private decimal? _wherePed;
		public string WhereClmhdr_batch_nbr { get; set; }
		private string _whereClmhdr_batch_nbr;
		public decimal? WhereClmhdr_claim_nbr { get; set; }
		private decimal? _whereClmhdr_claim_nbr;
		public decimal? WhereEdt_process_date { get; set; }
		private decimal? _whereEdt_process_date;
		public decimal? WhereEdt_pat_birth_date { get; set; }
		private decimal? _whereEdt_pat_birth_date;
		public string WhereEdt_account_nbr { get; set; }
		private string _whereEdt_account_nbr;
		public string WhereEdt_health_nbr { get; set; }
		private string _whereEdt_health_nbr;
		public string WhereEdt_health_version_cd { get; set; }
		private string _whereEdt_health_version_cd;
		public string WhereEdt_pay_prog { get; set; }
		private string _whereEdt_pay_prog;
		public string WhereEdt_payee { get; set; }
		private string _whereEdt_payee;
		public decimal? WhereEft_referring_doc_nbr { get; set; }
		private decimal? _whereEft_referring_doc_nbr;
		public string WhereEdt_facility_nbr { get; set; }
		private string _whereEdt_facility_nbr;
		public decimal? WhereEdt_admit_date { get; set; }
		private decimal? _whereEdt_admit_date;
		public string WhereEdt_location_cd { get; set; }
		private string _whereEdt_location_cd;
		public string WhereOhip_err_code { get; set; }
		private string _whereOhip_err_code;
		public string WhereEdt_err_h_cd_1 { get; set; }
		private string _whereEdt_err_h_cd_1;
		public string WhereEdt_err_h_cd_2 { get; set; }
		private string _whereEdt_err_h_cd_2;
		public string WhereEdt_err_h_cd_3 { get; set; }
		private string _whereEdt_err_h_cd_3;
		public string WhereEdt_err_h_cd_4 { get; set; }
		private string _whereEdt_err_h_cd_4;
		public string WhereEdt_err_h_cd_5 { get; set; }
		private string _whereEdt_err_h_cd_5;
		public string WhereCharge_status { get; set; }
		private string _whereCharge_status;
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
		private string _originalClmhdr_doc_nbr;
		private decimal? _originalPed;
		private string _originalClmhdr_batch_nbr;
		private decimal? _originalClmhdr_claim_nbr;
		private decimal? _originalEdt_process_date;
		private decimal? _originalEdt_pat_birth_date;
		private string _originalEdt_account_nbr;
		private string _originalEdt_health_nbr;
		private string _originalEdt_health_version_cd;
		private string _originalEdt_pay_prog;
		private string _originalEdt_payee;
		private decimal? _originalEft_referring_doc_nbr;
		private string _originalEdt_facility_nbr;
		private decimal? _originalEdt_admit_date;
		private string _originalEdt_location_cd;
		private string _originalOhip_err_code;
		private string _originalEdt_err_h_cd_1;
		private string _originalEdt_err_h_cd_2;
		private string _originalEdt_err_h_cd_3;
		private string _originalEdt_err_h_cd_4;
		private string _originalEdt_err_h_cd_5;
		private string _originalCharge_status;
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
			CLMHDR_DOC_NBR = _originalClmhdr_doc_nbr;
			PED = _originalPed;
			CLMHDR_BATCH_NBR = _originalClmhdr_batch_nbr;
			CLMHDR_CLAIM_NBR = _originalClmhdr_claim_nbr;
			EDT_PROCESS_DATE = _originalEdt_process_date;
			EDT_PAT_BIRTH_DATE = _originalEdt_pat_birth_date;
			EDT_ACCOUNT_NBR = _originalEdt_account_nbr;
			EDT_HEALTH_NBR = _originalEdt_health_nbr;
			EDT_HEALTH_VERSION_CD = _originalEdt_health_version_cd;
			EDT_PAY_PROG = _originalEdt_pay_prog;
			EDT_PAYEE = _originalEdt_payee;
			EFT_REFERRING_DOC_NBR = _originalEft_referring_doc_nbr;
			EDT_FACILITY_NBR = _originalEdt_facility_nbr;
			EDT_ADMIT_DATE = _originalEdt_admit_date;
			EDT_LOCATION_CD = _originalEdt_location_cd;
			OHIP_ERR_CODE = _originalOhip_err_code;
			EDT_ERR_H_CD_1 = _originalEdt_err_h_cd_1;
			EDT_ERR_H_CD_2 = _originalEdt_err_h_cd_2;
			EDT_ERR_H_CD_3 = _originalEdt_err_h_cd_3;
			EDT_ERR_H_CD_4 = _originalEdt_err_h_cd_4;
			EDT_ERR_H_CD_5 = _originalEdt_err_h_cd_5;
			CHARGE_STATUS = _originalCharge_status;
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
					new SqlParameter("PED",PED),
					new SqlParameter("CLMHDR_BATCH_NBR",CLMHDR_BATCH_NBR),
					new SqlParameter("CLMHDR_CLAIM_NBR",CLMHDR_CLAIM_NBR),
					new SqlParameter("EDT_PROCESS_DATE",EDT_PROCESS_DATE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_Purge]");
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
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("EDT_PROCESS_DATE", SqlNull(EDT_PROCESS_DATE)),
						new SqlParameter("EDT_PAT_BIRTH_DATE", SqlNull(EDT_PAT_BIRTH_DATE)),
						new SqlParameter("EDT_ACCOUNT_NBR", SqlNull(EDT_ACCOUNT_NBR)),
						new SqlParameter("EDT_HEALTH_NBR", SqlNull(EDT_HEALTH_NBR)),
						new SqlParameter("EDT_HEALTH_VERSION_CD", SqlNull(EDT_HEALTH_VERSION_CD)),
						new SqlParameter("EDT_PAY_PROG", SqlNull(EDT_PAY_PROG)),
						new SqlParameter("EDT_PAYEE", SqlNull(EDT_PAYEE)),
						new SqlParameter("EFT_REFERRING_DOC_NBR", SqlNull(EFT_REFERRING_DOC_NBR)),
						new SqlParameter("EDT_FACILITY_NBR", SqlNull(EDT_FACILITY_NBR)),
						new SqlParameter("EDT_ADMIT_DATE", SqlNull(EDT_ADMIT_DATE)),
						new SqlParameter("EDT_LOCATION_CD", SqlNull(EDT_LOCATION_CD)),
						new SqlParameter("OHIP_ERR_CODE", SqlNull(OHIP_ERR_CODE)),
						new SqlParameter("EDT_ERR_H_CD_1", SqlNull(EDT_ERR_H_CD_1)),
						new SqlParameter("EDT_ERR_H_CD_2", SqlNull(EDT_ERR_H_CD_2)),
						new SqlParameter("EDT_ERR_H_CD_3", SqlNull(EDT_ERR_H_CD_3)),
						new SqlParameter("EDT_ERR_H_CD_4", SqlNull(EDT_ERR_H_CD_4)),
						new SqlParameter("EDT_ERR_H_CD_5", SqlNull(EDT_ERR_H_CD_5)),
						new SqlParameter("CHARGE_STATUS", SqlNull(CHARGE_STATUS)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						PED = ConvertDEC(Reader["PED"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						EDT_PAT_BIRTH_DATE = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]);
						EDT_ACCOUNT_NBR = Reader["EDT_ACCOUNT_NBR"].ToString();
						EDT_HEALTH_NBR = Reader["EDT_HEALTH_NBR"].ToString();
						EDT_HEALTH_VERSION_CD = Reader["EDT_HEALTH_VERSION_CD"].ToString();
						EDT_PAY_PROG = Reader["EDT_PAY_PROG"].ToString();
						EDT_PAYEE = Reader["EDT_PAYEE"].ToString();
						EFT_REFERRING_DOC_NBR = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]);
						EDT_FACILITY_NBR = Reader["EDT_FACILITY_NBR"].ToString();
						EDT_ADMIT_DATE = ConvertDEC(Reader["EDT_ADMIT_DATE"]);
						EDT_LOCATION_CD = Reader["EDT_LOCATION_CD"].ToString();
						OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString();
						EDT_ERR_H_CD_1 = Reader["EDT_ERR_H_CD_1"].ToString();
						EDT_ERR_H_CD_2 = Reader["EDT_ERR_H_CD_2"].ToString();
						EDT_ERR_H_CD_3 = Reader["EDT_ERR_H_CD_3"].ToString();
						EDT_ERR_H_CD_4 = Reader["EDT_ERR_H_CD_4"].ToString();
						EDT_ERR_H_CD_5 = Reader["EDT_ERR_H_CD_5"].ToString();
						CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						_originalEdt_pat_birth_date = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]);
						_originalEdt_account_nbr = Reader["EDT_ACCOUNT_NBR"].ToString();
						_originalEdt_health_nbr = Reader["EDT_HEALTH_NBR"].ToString();
						_originalEdt_health_version_cd = Reader["EDT_HEALTH_VERSION_CD"].ToString();
						_originalEdt_pay_prog = Reader["EDT_PAY_PROG"].ToString();
						_originalEdt_payee = Reader["EDT_PAYEE"].ToString();
						_originalEft_referring_doc_nbr = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]);
						_originalEdt_facility_nbr = Reader["EDT_FACILITY_NBR"].ToString();
						_originalEdt_admit_date = ConvertDEC(Reader["EDT_ADMIT_DATE"]);
						_originalEdt_location_cd = Reader["EDT_LOCATION_CD"].ToString();
						_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString();
						_originalEdt_err_h_cd_1 = Reader["EDT_ERR_H_CD_1"].ToString();
						_originalEdt_err_h_cd_2 = Reader["EDT_ERR_H_CD_2"].ToString();
						_originalEdt_err_h_cd_3 = Reader["EDT_ERR_H_CD_3"].ToString();
						_originalEdt_err_h_cd_4 = Reader["EDT_ERR_H_CD_4"].ToString();
						_originalEdt_err_h_cd_5 = Reader["EDT_ERR_H_CD_5"].ToString();
						_originalCharge_status = Reader["CHARGE_STATUS"].ToString();
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
						new SqlParameter("CLMHDR_DOC_NBR", SqlNull(CLMHDR_DOC_NBR)),
						new SqlParameter("PED", SqlNull(PED)),
						new SqlParameter("CLMHDR_BATCH_NBR", SqlNull(CLMHDR_BATCH_NBR)),
						new SqlParameter("CLMHDR_CLAIM_NBR", SqlNull(CLMHDR_CLAIM_NBR)),
						new SqlParameter("EDT_PROCESS_DATE", SqlNull(EDT_PROCESS_DATE)),
						new SqlParameter("EDT_PAT_BIRTH_DATE", SqlNull(EDT_PAT_BIRTH_DATE)),
						new SqlParameter("EDT_ACCOUNT_NBR", SqlNull(EDT_ACCOUNT_NBR)),
						new SqlParameter("EDT_HEALTH_NBR", SqlNull(EDT_HEALTH_NBR)),
						new SqlParameter("EDT_HEALTH_VERSION_CD", SqlNull(EDT_HEALTH_VERSION_CD)),
						new SqlParameter("EDT_PAY_PROG", SqlNull(EDT_PAY_PROG)),
						new SqlParameter("EDT_PAYEE", SqlNull(EDT_PAYEE)),
						new SqlParameter("EFT_REFERRING_DOC_NBR", SqlNull(EFT_REFERRING_DOC_NBR)),
						new SqlParameter("EDT_FACILITY_NBR", SqlNull(EDT_FACILITY_NBR)),
						new SqlParameter("EDT_ADMIT_DATE", SqlNull(EDT_ADMIT_DATE)),
						new SqlParameter("EDT_LOCATION_CD", SqlNull(EDT_LOCATION_CD)),
						new SqlParameter("OHIP_ERR_CODE", SqlNull(OHIP_ERR_CODE)),
						new SqlParameter("EDT_ERR_H_CD_1", SqlNull(EDT_ERR_H_CD_1)),
						new SqlParameter("EDT_ERR_H_CD_2", SqlNull(EDT_ERR_H_CD_2)),
						new SqlParameter("EDT_ERR_H_CD_3", SqlNull(EDT_ERR_H_CD_3)),
						new SqlParameter("EDT_ERR_H_CD_4", SqlNull(EDT_ERR_H_CD_4)),
						new SqlParameter("EDT_ERR_H_CD_5", SqlNull(EDT_ERR_H_CD_5)),
						new SqlParameter("CHARGE_STATUS", SqlNull(CHARGE_STATUS)),
						new SqlParameter("ENTRY_DATE", SqlNull(ENTRY_DATE)),
						new SqlParameter("ENTRY_TIME_LONG", SqlNull(ENTRY_TIME_LONG)),
						new SqlParameter("ENTRY_USER_ID", SqlNull(ENTRY_USER_ID)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F087_SUBMITTED_REJECTED_CLAIMS_HDR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMHDR_DOC_NBR = Reader["CLMHDR_DOC_NBR"].ToString();
						PED = ConvertDEC(Reader["PED"]);
						CLMHDR_BATCH_NBR = Reader["CLMHDR_BATCH_NBR"].ToString();
						CLMHDR_CLAIM_NBR = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						EDT_PROCESS_DATE = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						EDT_PAT_BIRTH_DATE = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]);
						EDT_ACCOUNT_NBR = Reader["EDT_ACCOUNT_NBR"].ToString();
						EDT_HEALTH_NBR = Reader["EDT_HEALTH_NBR"].ToString();
						EDT_HEALTH_VERSION_CD = Reader["EDT_HEALTH_VERSION_CD"].ToString();
						EDT_PAY_PROG = Reader["EDT_PAY_PROG"].ToString();
						EDT_PAYEE = Reader["EDT_PAYEE"].ToString();
						EFT_REFERRING_DOC_NBR = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]);
						EDT_FACILITY_NBR = Reader["EDT_FACILITY_NBR"].ToString();
						EDT_ADMIT_DATE = ConvertDEC(Reader["EDT_ADMIT_DATE"]);
						EDT_LOCATION_CD = Reader["EDT_LOCATION_CD"].ToString();
						OHIP_ERR_CODE = Reader["OHIP_ERR_CODE"].ToString();
						EDT_ERR_H_CD_1 = Reader["EDT_ERR_H_CD_1"].ToString();
						EDT_ERR_H_CD_2 = Reader["EDT_ERR_H_CD_2"].ToString();
						EDT_ERR_H_CD_3 = Reader["EDT_ERR_H_CD_3"].ToString();
						EDT_ERR_H_CD_4 = Reader["EDT_ERR_H_CD_4"].ToString();
						EDT_ERR_H_CD_5 = Reader["EDT_ERR_H_CD_5"].ToString();
						CHARGE_STATUS = Reader["CHARGE_STATUS"].ToString();
						ENTRY_DATE = ConvertDEC(Reader["ENTRY_DATE"]);
						ENTRY_TIME_LONG = ConvertDEC(Reader["ENTRY_TIME_LONG"]);
						ENTRY_USER_ID = Reader["ENTRY_USER_ID"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmhdr_doc_nbr = Reader["CLMHDR_DOC_NBR"].ToString();
						_originalPed = ConvertDEC(Reader["PED"]);
						_originalClmhdr_batch_nbr = Reader["CLMHDR_BATCH_NBR"].ToString();
						_originalClmhdr_claim_nbr = ConvertDEC(Reader["CLMHDR_CLAIM_NBR"]);
						_originalEdt_process_date = ConvertDEC(Reader["EDT_PROCESS_DATE"]);
						_originalEdt_pat_birth_date = ConvertDEC(Reader["EDT_PAT_BIRTH_DATE"]);
						_originalEdt_account_nbr = Reader["EDT_ACCOUNT_NBR"].ToString();
						_originalEdt_health_nbr = Reader["EDT_HEALTH_NBR"].ToString();
						_originalEdt_health_version_cd = Reader["EDT_HEALTH_VERSION_CD"].ToString();
						_originalEdt_pay_prog = Reader["EDT_PAY_PROG"].ToString();
						_originalEdt_payee = Reader["EDT_PAYEE"].ToString();
						_originalEft_referring_doc_nbr = ConvertDEC(Reader["EFT_REFERRING_DOC_NBR"]);
						_originalEdt_facility_nbr = Reader["EDT_FACILITY_NBR"].ToString();
						_originalEdt_admit_date = ConvertDEC(Reader["EDT_ADMIT_DATE"]);
						_originalEdt_location_cd = Reader["EDT_LOCATION_CD"].ToString();
						_originalOhip_err_code = Reader["OHIP_ERR_CODE"].ToString();
						_originalEdt_err_h_cd_1 = Reader["EDT_ERR_H_CD_1"].ToString();
						_originalEdt_err_h_cd_2 = Reader["EDT_ERR_H_CD_2"].ToString();
						_originalEdt_err_h_cd_3 = Reader["EDT_ERR_H_CD_3"].ToString();
						_originalEdt_err_h_cd_4 = Reader["EDT_ERR_H_CD_4"].ToString();
						_originalEdt_err_h_cd_5 = Reader["EDT_ERR_H_CD_5"].ToString();
						_originalCharge_status = Reader["CHARGE_STATUS"].ToString();
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