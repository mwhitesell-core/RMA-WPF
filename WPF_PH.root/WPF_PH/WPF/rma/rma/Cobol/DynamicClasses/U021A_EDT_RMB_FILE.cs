using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class U021A_EDT_RMB_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<U021A_EDT_RMB_FILE> Collection( Guid? rowid,
															string rat_rmb_moh_off_cd,
															string rat_rmb_group_nbr,
															decimal? rat_rmb_doc_nbrmin,
															decimal? rat_rmb_doc_nbrmax,
															decimal? rat_rmb_specialty_cdmin,
															decimal? rat_rmb_specialty_cdmax,
															string rat_rmb_station_nbr,
															decimal? rat_rmb_process_datemin,
															decimal? rat_rmb_process_datemax,
															string rat_rmb_health_nbr,
															string rat_rmb_version_cd,
															decimal? rat_rmb_birth_datemin,
															decimal? rat_rmb_birth_datemax,
															string rat_rmb_account_nbr,
															decimal? rat_rmb_orig_seq_nbrmin,
															decimal? rat_rmb_orig_seq_nbrmax,
															string rat_rmb_pay_prog,
															string rat_rmb_payee,
															decimal? rat_rmb_refer_doc_nbrmin,
															decimal? rat_rmb_refer_doc_nbrmax,
															string rat_rmb_facility_nbr,
															decimal? rat_rmb_admit_datemin,
															decimal? rat_rmb_admit_datemax,
															string rat_rmb_loc_cd,
															string rat_rmb_error_h_cd_1,
															string rat_rmb_error_h_cd_2,
															string rat_rmb_error_h_cd_3,
															string rat_rmb_error_h_cd_4,
															string rat_rmb_error_h_cd_5,
															string rat_rmb_registration_nbr,
															string rat_rmb_last_name,
															string rat_rmb_first_name,
															string rat_rmb_sex,
															string rat_rmb_prov_cd,
															string rat_rmb_error_r_cd_1,
															string rat_rmb_error_r_cd_2,
															string rat_rmb_error_r_cd_3,
															string rat_rmb_error_r_cd_4,
															string rat_rmb_error_r_cd_5,
															string rat_rmb_service_cd,
															decimal? rat_rmb_amount_submin,
															decimal? rat_rmb_amount_submax,
															decimal? rat_rmb_nbr_of_servmin,
															decimal? rat_rmb_nbr_of_servmax,
															decimal? rat_rmb_service_datemin,
															decimal? rat_rmb_service_datemax,
															string rat_rmb_diag_cd,
															string rat_rmb_t_explan_cd,
															string rat_rmb_error_t_cd_1,
															string rat_rmb_error_t_cd_2,
															string rat_rmb_error_t_cd_3,
															string rat_rmb_error_t_cd_4,
															string rat_rmb_error_t_cd_5,
															string rat_rmb_8_explan_cd,
															string rat_rmb_8_explan_desc,
															string rat_rmb_file_name,
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
					new SqlParameter("RAT_RMB_MOH_OFF_CD",rat_rmb_moh_off_cd),
					new SqlParameter("RAT_RMB_GROUP_NBR",rat_rmb_group_nbr),
					new SqlParameter("minRAT_RMB_DOC_NBR",rat_rmb_doc_nbrmin),
					new SqlParameter("maxRAT_RMB_DOC_NBR",rat_rmb_doc_nbrmax),
					new SqlParameter("minRAT_RMB_SPECIALTY_CD",rat_rmb_specialty_cdmin),
					new SqlParameter("maxRAT_RMB_SPECIALTY_CD",rat_rmb_specialty_cdmax),
					new SqlParameter("RAT_RMB_STATION_NBR",rat_rmb_station_nbr),
					new SqlParameter("minRAT_RMB_PROCESS_DATE",rat_rmb_process_datemin),
					new SqlParameter("maxRAT_RMB_PROCESS_DATE",rat_rmb_process_datemax),
					new SqlParameter("RAT_RMB_HEALTH_NBR",rat_rmb_health_nbr),
					new SqlParameter("RAT_RMB_VERSION_CD",rat_rmb_version_cd),
					new SqlParameter("minRAT_RMB_BIRTH_DATE",rat_rmb_birth_datemin),
					new SqlParameter("maxRAT_RMB_BIRTH_DATE",rat_rmb_birth_datemax),
					new SqlParameter("RAT_RMB_ACCOUNT_NBR",rat_rmb_account_nbr),
					new SqlParameter("minRAT_RMB_ORIG_SEQ_NBR",rat_rmb_orig_seq_nbrmin),
					new SqlParameter("maxRAT_RMB_ORIG_SEQ_NBR",rat_rmb_orig_seq_nbrmax),
					new SqlParameter("RAT_RMB_PAY_PROG",rat_rmb_pay_prog),
					new SqlParameter("RAT_RMB_PAYEE",rat_rmb_payee),
					new SqlParameter("minRAT_RMB_REFER_DOC_NBR",rat_rmb_refer_doc_nbrmin),
					new SqlParameter("maxRAT_RMB_REFER_DOC_NBR",rat_rmb_refer_doc_nbrmax),
					new SqlParameter("RAT_RMB_FACILITY_NBR",rat_rmb_facility_nbr),
					new SqlParameter("minRAT_RMB_ADMIT_DATE",rat_rmb_admit_datemin),
					new SqlParameter("maxRAT_RMB_ADMIT_DATE",rat_rmb_admit_datemax),
					new SqlParameter("RAT_RMB_LOC_CD",rat_rmb_loc_cd),
					new SqlParameter("RAT_RMB_ERROR_H_CD_1",rat_rmb_error_h_cd_1),
					new SqlParameter("RAT_RMB_ERROR_H_CD_2",rat_rmb_error_h_cd_2),
					new SqlParameter("RAT_RMB_ERROR_H_CD_3",rat_rmb_error_h_cd_3),
					new SqlParameter("RAT_RMB_ERROR_H_CD_4",rat_rmb_error_h_cd_4),
					new SqlParameter("RAT_RMB_ERROR_H_CD_5",rat_rmb_error_h_cd_5),
					new SqlParameter("RAT_RMB_REGISTRATION_NBR",rat_rmb_registration_nbr),
					new SqlParameter("RAT_RMB_LAST_NAME",rat_rmb_last_name),
					new SqlParameter("RAT_RMB_FIRST_NAME",rat_rmb_first_name),
					new SqlParameter("RAT_RMB_SEX",rat_rmb_sex),
					new SqlParameter("RAT_RMB_PROV_CD",rat_rmb_prov_cd),
					new SqlParameter("RAT_RMB_ERROR_R_CD_1",rat_rmb_error_r_cd_1),
					new SqlParameter("RAT_RMB_ERROR_R_CD_2",rat_rmb_error_r_cd_2),
					new SqlParameter("RAT_RMB_ERROR_R_CD_3",rat_rmb_error_r_cd_3),
					new SqlParameter("RAT_RMB_ERROR_R_CD_4",rat_rmb_error_r_cd_4),
					new SqlParameter("RAT_RMB_ERROR_R_CD_5",rat_rmb_error_r_cd_5),
					new SqlParameter("RAT_RMB_SERVICE_CD",rat_rmb_service_cd),
					new SqlParameter("minRAT_RMB_AMOUNT_SUB",rat_rmb_amount_submin),
					new SqlParameter("maxRAT_RMB_AMOUNT_SUB",rat_rmb_amount_submax),
					new SqlParameter("minRAT_RMB_NBR_OF_SERV",rat_rmb_nbr_of_servmin),
					new SqlParameter("maxRAT_RMB_NBR_OF_SERV",rat_rmb_nbr_of_servmax),
					new SqlParameter("minRAT_RMB_SERVICE_DATE",rat_rmb_service_datemin),
					new SqlParameter("maxRAT_RMB_SERVICE_DATE",rat_rmb_service_datemax),
					new SqlParameter("RAT_RMB_DIAG_CD",rat_rmb_diag_cd),
					new SqlParameter("RAT_RMB_T_EXPLAN_CD",rat_rmb_t_explan_cd),
					new SqlParameter("RAT_RMB_ERROR_T_CD_1",rat_rmb_error_t_cd_1),
					new SqlParameter("RAT_RMB_ERROR_T_CD_2",rat_rmb_error_t_cd_2),
					new SqlParameter("RAT_RMB_ERROR_T_CD_3",rat_rmb_error_t_cd_3),
					new SqlParameter("RAT_RMB_ERROR_T_CD_4",rat_rmb_error_t_cd_4),
					new SqlParameter("RAT_RMB_ERROR_T_CD_5",rat_rmb_error_t_cd_5),
					new SqlParameter("RAT_RMB_8_EXPLAN_CD",rat_rmb_8_explan_cd),
					new SqlParameter("RAT_RMB_8_EXPLAN_DESC",rat_rmb_8_explan_desc),
					new SqlParameter("RAT_RMB_FILE_NAME",rat_rmb_file_name),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<U021A_EDT_RMB_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_Search]", parameters);
            var collection = new ObservableCollection<U021A_EDT_RMB_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U021A_EDT_RMB_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_RMB_MOH_OFF_CD = Reader["RAT_RMB_MOH_OFF_CD"].ToString(),
					RAT_RMB_GROUP_NBR = Reader["RAT_RMB_GROUP_NBR"].ToString(),
					RAT_RMB_DOC_NBR = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]),
					RAT_RMB_SPECIALTY_CD = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]),
					RAT_RMB_STATION_NBR = Reader["RAT_RMB_STATION_NBR"].ToString(),
					RAT_RMB_PROCESS_DATE = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]),
					RAT_RMB_HEALTH_NBR = Reader["RAT_RMB_HEALTH_NBR"].ToString(),
					RAT_RMB_VERSION_CD = Reader["RAT_RMB_VERSION_CD"].ToString(),
					RAT_RMB_BIRTH_DATE = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]),
					RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					RAT_RMB_ORIG_SEQ_NBR = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]),
					RAT_RMB_PAY_PROG = Reader["RAT_RMB_PAY_PROG"].ToString(),
					RAT_RMB_PAYEE = Reader["RAT_RMB_PAYEE"].ToString(),
					RAT_RMB_REFER_DOC_NBR = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]),
					RAT_RMB_FACILITY_NBR = Reader["RAT_RMB_FACILITY_NBR"].ToString(),
					RAT_RMB_ADMIT_DATE = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]),
					RAT_RMB_LOC_CD = Reader["RAT_RMB_LOC_CD"].ToString(),
					RAT_RMB_ERROR_H_CD_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString(),
					RAT_RMB_ERROR_H_CD_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString(),
					RAT_RMB_ERROR_H_CD_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString(),
					RAT_RMB_ERROR_H_CD_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString(),
					RAT_RMB_ERROR_H_CD_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString(),
					RAT_RMB_REGISTRATION_NBR = Reader["RAT_RMB_REGISTRATION_NBR"].ToString(),
					RAT_RMB_LAST_NAME = Reader["RAT_RMB_LAST_NAME"].ToString(),
					RAT_RMB_FIRST_NAME = Reader["RAT_RMB_FIRST_NAME"].ToString(),
					RAT_RMB_SEX = Reader["RAT_RMB_SEX"].ToString(),
					RAT_RMB_PROV_CD = Reader["RAT_RMB_PROV_CD"].ToString(),
					RAT_RMB_ERROR_R_CD_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString(),
					RAT_RMB_ERROR_R_CD_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString(),
					RAT_RMB_ERROR_R_CD_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString(),
					RAT_RMB_ERROR_R_CD_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString(),
					RAT_RMB_ERROR_R_CD_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString(),
					RAT_RMB_SERVICE_CD = Reader["RAT_RMB_SERVICE_CD"].ToString(),
					RAT_RMB_AMOUNT_SUB = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]),
					RAT_RMB_NBR_OF_SERV = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]),
					RAT_RMB_SERVICE_DATE = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]),
					RAT_RMB_DIAG_CD = Reader["RAT_RMB_DIAG_CD"].ToString(),
					RAT_RMB_T_EXPLAN_CD = Reader["RAT_RMB_T_EXPLAN_CD"].ToString(),
					RAT_RMB_ERROR_T_CD_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString(),
					RAT_RMB_ERROR_T_CD_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString(),
					RAT_RMB_ERROR_T_CD_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString(),
					RAT_RMB_ERROR_T_CD_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString(),
					RAT_RMB_ERROR_T_CD_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString(),
					RAT_RMB_8_EXPLAN_CD = Reader["RAT_RMB_8_EXPLAN_CD"].ToString(),
					RAT_RMB_8_EXPLAN_DESC = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString(),
					RAT_RMB_FILE_NAME = Reader["RAT_RMB_FILE_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_rmb_moh_off_cd = Reader["RAT_RMB_MOH_OFF_CD"].ToString(),
					_originalRat_rmb_group_nbr = Reader["RAT_RMB_GROUP_NBR"].ToString(),
					_originalRat_rmb_doc_nbr = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]),
					_originalRat_rmb_specialty_cd = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]),
					_originalRat_rmb_station_nbr = Reader["RAT_RMB_STATION_NBR"].ToString(),
					_originalRat_rmb_process_date = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]),
					_originalRat_rmb_health_nbr = Reader["RAT_RMB_HEALTH_NBR"].ToString(),
					_originalRat_rmb_version_cd = Reader["RAT_RMB_VERSION_CD"].ToString(),
					_originalRat_rmb_birth_date = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]),
					_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					_originalRat_rmb_orig_seq_nbr = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]),
					_originalRat_rmb_pay_prog = Reader["RAT_RMB_PAY_PROG"].ToString(),
					_originalRat_rmb_payee = Reader["RAT_RMB_PAYEE"].ToString(),
					_originalRat_rmb_refer_doc_nbr = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]),
					_originalRat_rmb_facility_nbr = Reader["RAT_RMB_FACILITY_NBR"].ToString(),
					_originalRat_rmb_admit_date = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]),
					_originalRat_rmb_loc_cd = Reader["RAT_RMB_LOC_CD"].ToString(),
					_originalRat_rmb_error_h_cd_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString(),
					_originalRat_rmb_error_h_cd_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString(),
					_originalRat_rmb_error_h_cd_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString(),
					_originalRat_rmb_error_h_cd_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString(),
					_originalRat_rmb_error_h_cd_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString(),
					_originalRat_rmb_registration_nbr = Reader["RAT_RMB_REGISTRATION_NBR"].ToString(),
					_originalRat_rmb_last_name = Reader["RAT_RMB_LAST_NAME"].ToString(),
					_originalRat_rmb_first_name = Reader["RAT_RMB_FIRST_NAME"].ToString(),
					_originalRat_rmb_sex = Reader["RAT_RMB_SEX"].ToString(),
					_originalRat_rmb_prov_cd = Reader["RAT_RMB_PROV_CD"].ToString(),
					_originalRat_rmb_error_r_cd_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString(),
					_originalRat_rmb_error_r_cd_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString(),
					_originalRat_rmb_error_r_cd_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString(),
					_originalRat_rmb_error_r_cd_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString(),
					_originalRat_rmb_error_r_cd_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString(),
					_originalRat_rmb_service_cd = Reader["RAT_RMB_SERVICE_CD"].ToString(),
					_originalRat_rmb_amount_sub = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]),
					_originalRat_rmb_nbr_of_serv = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]),
					_originalRat_rmb_service_date = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]),
					_originalRat_rmb_diag_cd = Reader["RAT_RMB_DIAG_CD"].ToString(),
					_originalRat_rmb_t_explan_cd = Reader["RAT_RMB_T_EXPLAN_CD"].ToString(),
					_originalRat_rmb_error_t_cd_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString(),
					_originalRat_rmb_error_t_cd_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString(),
					_originalRat_rmb_error_t_cd_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString(),
					_originalRat_rmb_error_t_cd_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString(),
					_originalRat_rmb_error_t_cd_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString(),
					_originalRat_rmb_8_explan_cd = Reader["RAT_RMB_8_EXPLAN_CD"].ToString(),
					_originalRat_rmb_8_explan_desc = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString(),
					_originalRat_rmb_file_name = Reader["RAT_RMB_FILE_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public U021A_EDT_RMB_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<U021A_EDT_RMB_FILE> Collection(ObservableCollection<U021A_EDT_RMB_FILE>
                                                               u021aEdtRmbFile = null)
        {
            if (IsSameSearch() && u021aEdtRmbFile != null)
            {
                return u021aEdtRmbFile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<U021A_EDT_RMB_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RAT_RMB_MOH_OFF_CD",WhereRat_rmb_moh_off_cd),
					new SqlParameter("RAT_RMB_GROUP_NBR",WhereRat_rmb_group_nbr),
					new SqlParameter("RAT_RMB_DOC_NBR",WhereRat_rmb_doc_nbr),
					new SqlParameter("RAT_RMB_SPECIALTY_CD",WhereRat_rmb_specialty_cd),
					new SqlParameter("RAT_RMB_STATION_NBR",WhereRat_rmb_station_nbr),
					new SqlParameter("RAT_RMB_PROCESS_DATE",WhereRat_rmb_process_date),
					new SqlParameter("RAT_RMB_HEALTH_NBR",WhereRat_rmb_health_nbr),
					new SqlParameter("RAT_RMB_VERSION_CD",WhereRat_rmb_version_cd),
					new SqlParameter("RAT_RMB_BIRTH_DATE",WhereRat_rmb_birth_date),
					new SqlParameter("RAT_RMB_ACCOUNT_NBR",WhereRat_rmb_account_nbr),
					new SqlParameter("RAT_RMB_ORIG_SEQ_NBR",WhereRat_rmb_orig_seq_nbr),
					new SqlParameter("RAT_RMB_PAY_PROG",WhereRat_rmb_pay_prog),
					new SqlParameter("RAT_RMB_PAYEE",WhereRat_rmb_payee),
					new SqlParameter("RAT_RMB_REFER_DOC_NBR",WhereRat_rmb_refer_doc_nbr),
					new SqlParameter("RAT_RMB_FACILITY_NBR",WhereRat_rmb_facility_nbr),
					new SqlParameter("RAT_RMB_ADMIT_DATE",WhereRat_rmb_admit_date),
					new SqlParameter("RAT_RMB_LOC_CD",WhereRat_rmb_loc_cd),
					new SqlParameter("RAT_RMB_ERROR_H_CD_1",WhereRat_rmb_error_h_cd_1),
					new SqlParameter("RAT_RMB_ERROR_H_CD_2",WhereRat_rmb_error_h_cd_2),
					new SqlParameter("RAT_RMB_ERROR_H_CD_3",WhereRat_rmb_error_h_cd_3),
					new SqlParameter("RAT_RMB_ERROR_H_CD_4",WhereRat_rmb_error_h_cd_4),
					new SqlParameter("RAT_RMB_ERROR_H_CD_5",WhereRat_rmb_error_h_cd_5),
					new SqlParameter("RAT_RMB_REGISTRATION_NBR",WhereRat_rmb_registration_nbr),
					new SqlParameter("RAT_RMB_LAST_NAME",WhereRat_rmb_last_name),
					new SqlParameter("RAT_RMB_FIRST_NAME",WhereRat_rmb_first_name),
					new SqlParameter("RAT_RMB_SEX",WhereRat_rmb_sex),
					new SqlParameter("RAT_RMB_PROV_CD",WhereRat_rmb_prov_cd),
					new SqlParameter("RAT_RMB_ERROR_R_CD_1",WhereRat_rmb_error_r_cd_1),
					new SqlParameter("RAT_RMB_ERROR_R_CD_2",WhereRat_rmb_error_r_cd_2),
					new SqlParameter("RAT_RMB_ERROR_R_CD_3",WhereRat_rmb_error_r_cd_3),
					new SqlParameter("RAT_RMB_ERROR_R_CD_4",WhereRat_rmb_error_r_cd_4),
					new SqlParameter("RAT_RMB_ERROR_R_CD_5",WhereRat_rmb_error_r_cd_5),
					new SqlParameter("RAT_RMB_SERVICE_CD",WhereRat_rmb_service_cd),
					new SqlParameter("RAT_RMB_AMOUNT_SUB",WhereRat_rmb_amount_sub),
					new SqlParameter("RAT_RMB_NBR_OF_SERV",WhereRat_rmb_nbr_of_serv),
					new SqlParameter("RAT_RMB_SERVICE_DATE",WhereRat_rmb_service_date),
					new SqlParameter("RAT_RMB_DIAG_CD",WhereRat_rmb_diag_cd),
					new SqlParameter("RAT_RMB_T_EXPLAN_CD",WhereRat_rmb_t_explan_cd),
					new SqlParameter("RAT_RMB_ERROR_T_CD_1",WhereRat_rmb_error_t_cd_1),
					new SqlParameter("RAT_RMB_ERROR_T_CD_2",WhereRat_rmb_error_t_cd_2),
					new SqlParameter("RAT_RMB_ERROR_T_CD_3",WhereRat_rmb_error_t_cd_3),
					new SqlParameter("RAT_RMB_ERROR_T_CD_4",WhereRat_rmb_error_t_cd_4),
					new SqlParameter("RAT_RMB_ERROR_T_CD_5",WhereRat_rmb_error_t_cd_5),
					new SqlParameter("RAT_RMB_8_EXPLAN_CD",WhereRat_rmb_8_explan_cd),
					new SqlParameter("RAT_RMB_8_EXPLAN_DESC",WhereRat_rmb_8_explan_desc),
					new SqlParameter("RAT_RMB_FILE_NAME",WhereRat_rmb_file_name),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_Match]", parameters);
            var collection = new ObservableCollection<U021A_EDT_RMB_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U021A_EDT_RMB_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_RMB_MOH_OFF_CD = Reader["RAT_RMB_MOH_OFF_CD"].ToString(),
					RAT_RMB_GROUP_NBR = Reader["RAT_RMB_GROUP_NBR"].ToString(),
					RAT_RMB_DOC_NBR = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]),
					RAT_RMB_SPECIALTY_CD = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]),
					RAT_RMB_STATION_NBR = Reader["RAT_RMB_STATION_NBR"].ToString(),
					RAT_RMB_PROCESS_DATE = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]),
					RAT_RMB_HEALTH_NBR = Reader["RAT_RMB_HEALTH_NBR"].ToString(),
					RAT_RMB_VERSION_CD = Reader["RAT_RMB_VERSION_CD"].ToString(),
					RAT_RMB_BIRTH_DATE = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]),
					RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					RAT_RMB_ORIG_SEQ_NBR = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]),
					RAT_RMB_PAY_PROG = Reader["RAT_RMB_PAY_PROG"].ToString(),
					RAT_RMB_PAYEE = Reader["RAT_RMB_PAYEE"].ToString(),
					RAT_RMB_REFER_DOC_NBR = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]),
					RAT_RMB_FACILITY_NBR = Reader["RAT_RMB_FACILITY_NBR"].ToString(),
					RAT_RMB_ADMIT_DATE = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]),
					RAT_RMB_LOC_CD = Reader["RAT_RMB_LOC_CD"].ToString(),
					RAT_RMB_ERROR_H_CD_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString(),
					RAT_RMB_ERROR_H_CD_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString(),
					RAT_RMB_ERROR_H_CD_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString(),
					RAT_RMB_ERROR_H_CD_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString(),
					RAT_RMB_ERROR_H_CD_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString(),
					RAT_RMB_REGISTRATION_NBR = Reader["RAT_RMB_REGISTRATION_NBR"].ToString(),
					RAT_RMB_LAST_NAME = Reader["RAT_RMB_LAST_NAME"].ToString(),
					RAT_RMB_FIRST_NAME = Reader["RAT_RMB_FIRST_NAME"].ToString(),
					RAT_RMB_SEX = Reader["RAT_RMB_SEX"].ToString(),
					RAT_RMB_PROV_CD = Reader["RAT_RMB_PROV_CD"].ToString(),
					RAT_RMB_ERROR_R_CD_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString(),
					RAT_RMB_ERROR_R_CD_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString(),
					RAT_RMB_ERROR_R_CD_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString(),
					RAT_RMB_ERROR_R_CD_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString(),
					RAT_RMB_ERROR_R_CD_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString(),
					RAT_RMB_SERVICE_CD = Reader["RAT_RMB_SERVICE_CD"].ToString(),
					RAT_RMB_AMOUNT_SUB = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]),
					RAT_RMB_NBR_OF_SERV = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]),
					RAT_RMB_SERVICE_DATE = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]),
					RAT_RMB_DIAG_CD = Reader["RAT_RMB_DIAG_CD"].ToString(),
					RAT_RMB_T_EXPLAN_CD = Reader["RAT_RMB_T_EXPLAN_CD"].ToString(),
					RAT_RMB_ERROR_T_CD_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString(),
					RAT_RMB_ERROR_T_CD_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString(),
					RAT_RMB_ERROR_T_CD_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString(),
					RAT_RMB_ERROR_T_CD_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString(),
					RAT_RMB_ERROR_T_CD_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString(),
					RAT_RMB_8_EXPLAN_CD = Reader["RAT_RMB_8_EXPLAN_CD"].ToString(),
					RAT_RMB_8_EXPLAN_DESC = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString(),
					RAT_RMB_FILE_NAME = Reader["RAT_RMB_FILE_NAME"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRat_rmb_moh_off_cd = WhereRat_rmb_moh_off_cd,
					_whereRat_rmb_group_nbr = WhereRat_rmb_group_nbr,
					_whereRat_rmb_doc_nbr = WhereRat_rmb_doc_nbr,
					_whereRat_rmb_specialty_cd = WhereRat_rmb_specialty_cd,
					_whereRat_rmb_station_nbr = WhereRat_rmb_station_nbr,
					_whereRat_rmb_process_date = WhereRat_rmb_process_date,
					_whereRat_rmb_health_nbr = WhereRat_rmb_health_nbr,
					_whereRat_rmb_version_cd = WhereRat_rmb_version_cd,
					_whereRat_rmb_birth_date = WhereRat_rmb_birth_date,
					_whereRat_rmb_account_nbr = WhereRat_rmb_account_nbr,
					_whereRat_rmb_orig_seq_nbr = WhereRat_rmb_orig_seq_nbr,
					_whereRat_rmb_pay_prog = WhereRat_rmb_pay_prog,
					_whereRat_rmb_payee = WhereRat_rmb_payee,
					_whereRat_rmb_refer_doc_nbr = WhereRat_rmb_refer_doc_nbr,
					_whereRat_rmb_facility_nbr = WhereRat_rmb_facility_nbr,
					_whereRat_rmb_admit_date = WhereRat_rmb_admit_date,
					_whereRat_rmb_loc_cd = WhereRat_rmb_loc_cd,
					_whereRat_rmb_error_h_cd_1 = WhereRat_rmb_error_h_cd_1,
					_whereRat_rmb_error_h_cd_2 = WhereRat_rmb_error_h_cd_2,
					_whereRat_rmb_error_h_cd_3 = WhereRat_rmb_error_h_cd_3,
					_whereRat_rmb_error_h_cd_4 = WhereRat_rmb_error_h_cd_4,
					_whereRat_rmb_error_h_cd_5 = WhereRat_rmb_error_h_cd_5,
					_whereRat_rmb_registration_nbr = WhereRat_rmb_registration_nbr,
					_whereRat_rmb_last_name = WhereRat_rmb_last_name,
					_whereRat_rmb_first_name = WhereRat_rmb_first_name,
					_whereRat_rmb_sex = WhereRat_rmb_sex,
					_whereRat_rmb_prov_cd = WhereRat_rmb_prov_cd,
					_whereRat_rmb_error_r_cd_1 = WhereRat_rmb_error_r_cd_1,
					_whereRat_rmb_error_r_cd_2 = WhereRat_rmb_error_r_cd_2,
					_whereRat_rmb_error_r_cd_3 = WhereRat_rmb_error_r_cd_3,
					_whereRat_rmb_error_r_cd_4 = WhereRat_rmb_error_r_cd_4,
					_whereRat_rmb_error_r_cd_5 = WhereRat_rmb_error_r_cd_5,
					_whereRat_rmb_service_cd = WhereRat_rmb_service_cd,
					_whereRat_rmb_amount_sub = WhereRat_rmb_amount_sub,
					_whereRat_rmb_nbr_of_serv = WhereRat_rmb_nbr_of_serv,
					_whereRat_rmb_service_date = WhereRat_rmb_service_date,
					_whereRat_rmb_diag_cd = WhereRat_rmb_diag_cd,
					_whereRat_rmb_t_explan_cd = WhereRat_rmb_t_explan_cd,
					_whereRat_rmb_error_t_cd_1 = WhereRat_rmb_error_t_cd_1,
					_whereRat_rmb_error_t_cd_2 = WhereRat_rmb_error_t_cd_2,
					_whereRat_rmb_error_t_cd_3 = WhereRat_rmb_error_t_cd_3,
					_whereRat_rmb_error_t_cd_4 = WhereRat_rmb_error_t_cd_4,
					_whereRat_rmb_error_t_cd_5 = WhereRat_rmb_error_t_cd_5,
					_whereRat_rmb_8_explan_cd = WhereRat_rmb_8_explan_cd,
					_whereRat_rmb_8_explan_desc = WhereRat_rmb_8_explan_desc,
					_whereRat_rmb_file_name = WhereRat_rmb_file_name,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_rmb_moh_off_cd = Reader["RAT_RMB_MOH_OFF_CD"].ToString(),
					_originalRat_rmb_group_nbr = Reader["RAT_RMB_GROUP_NBR"].ToString(),
					_originalRat_rmb_doc_nbr = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]),
					_originalRat_rmb_specialty_cd = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]),
					_originalRat_rmb_station_nbr = Reader["RAT_RMB_STATION_NBR"].ToString(),
					_originalRat_rmb_process_date = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]),
					_originalRat_rmb_health_nbr = Reader["RAT_RMB_HEALTH_NBR"].ToString(),
					_originalRat_rmb_version_cd = Reader["RAT_RMB_VERSION_CD"].ToString(),
					_originalRat_rmb_birth_date = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]),
					_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString(),
					_originalRat_rmb_orig_seq_nbr = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]),
					_originalRat_rmb_pay_prog = Reader["RAT_RMB_PAY_PROG"].ToString(),
					_originalRat_rmb_payee = Reader["RAT_RMB_PAYEE"].ToString(),
					_originalRat_rmb_refer_doc_nbr = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]),
					_originalRat_rmb_facility_nbr = Reader["RAT_RMB_FACILITY_NBR"].ToString(),
					_originalRat_rmb_admit_date = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]),
					_originalRat_rmb_loc_cd = Reader["RAT_RMB_LOC_CD"].ToString(),
					_originalRat_rmb_error_h_cd_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString(),
					_originalRat_rmb_error_h_cd_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString(),
					_originalRat_rmb_error_h_cd_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString(),
					_originalRat_rmb_error_h_cd_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString(),
					_originalRat_rmb_error_h_cd_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString(),
					_originalRat_rmb_registration_nbr = Reader["RAT_RMB_REGISTRATION_NBR"].ToString(),
					_originalRat_rmb_last_name = Reader["RAT_RMB_LAST_NAME"].ToString(),
					_originalRat_rmb_first_name = Reader["RAT_RMB_FIRST_NAME"].ToString(),
					_originalRat_rmb_sex = Reader["RAT_RMB_SEX"].ToString(),
					_originalRat_rmb_prov_cd = Reader["RAT_RMB_PROV_CD"].ToString(),
					_originalRat_rmb_error_r_cd_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString(),
					_originalRat_rmb_error_r_cd_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString(),
					_originalRat_rmb_error_r_cd_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString(),
					_originalRat_rmb_error_r_cd_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString(),
					_originalRat_rmb_error_r_cd_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString(),
					_originalRat_rmb_service_cd = Reader["RAT_RMB_SERVICE_CD"].ToString(),
					_originalRat_rmb_amount_sub = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]),
					_originalRat_rmb_nbr_of_serv = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]),
					_originalRat_rmb_service_date = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]),
					_originalRat_rmb_diag_cd = Reader["RAT_RMB_DIAG_CD"].ToString(),
					_originalRat_rmb_t_explan_cd = Reader["RAT_RMB_T_EXPLAN_CD"].ToString(),
					_originalRat_rmb_error_t_cd_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString(),
					_originalRat_rmb_error_t_cd_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString(),
					_originalRat_rmb_error_t_cd_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString(),
					_originalRat_rmb_error_t_cd_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString(),
					_originalRat_rmb_error_t_cd_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString(),
					_originalRat_rmb_8_explan_cd = Reader["RAT_RMB_8_EXPLAN_CD"].ToString(),
					_originalRat_rmb_8_explan_desc = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString(),
					_originalRat_rmb_file_name = Reader["RAT_RMB_FILE_NAME"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRat_rmb_moh_off_cd = WhereRat_rmb_moh_off_cd;
					_whereRat_rmb_group_nbr = WhereRat_rmb_group_nbr;
					_whereRat_rmb_doc_nbr = WhereRat_rmb_doc_nbr;
					_whereRat_rmb_specialty_cd = WhereRat_rmb_specialty_cd;
					_whereRat_rmb_station_nbr = WhereRat_rmb_station_nbr;
					_whereRat_rmb_process_date = WhereRat_rmb_process_date;
					_whereRat_rmb_health_nbr = WhereRat_rmb_health_nbr;
					_whereRat_rmb_version_cd = WhereRat_rmb_version_cd;
					_whereRat_rmb_birth_date = WhereRat_rmb_birth_date;
					_whereRat_rmb_account_nbr = WhereRat_rmb_account_nbr;
					_whereRat_rmb_orig_seq_nbr = WhereRat_rmb_orig_seq_nbr;
					_whereRat_rmb_pay_prog = WhereRat_rmb_pay_prog;
					_whereRat_rmb_payee = WhereRat_rmb_payee;
					_whereRat_rmb_refer_doc_nbr = WhereRat_rmb_refer_doc_nbr;
					_whereRat_rmb_facility_nbr = WhereRat_rmb_facility_nbr;
					_whereRat_rmb_admit_date = WhereRat_rmb_admit_date;
					_whereRat_rmb_loc_cd = WhereRat_rmb_loc_cd;
					_whereRat_rmb_error_h_cd_1 = WhereRat_rmb_error_h_cd_1;
					_whereRat_rmb_error_h_cd_2 = WhereRat_rmb_error_h_cd_2;
					_whereRat_rmb_error_h_cd_3 = WhereRat_rmb_error_h_cd_3;
					_whereRat_rmb_error_h_cd_4 = WhereRat_rmb_error_h_cd_4;
					_whereRat_rmb_error_h_cd_5 = WhereRat_rmb_error_h_cd_5;
					_whereRat_rmb_registration_nbr = WhereRat_rmb_registration_nbr;
					_whereRat_rmb_last_name = WhereRat_rmb_last_name;
					_whereRat_rmb_first_name = WhereRat_rmb_first_name;
					_whereRat_rmb_sex = WhereRat_rmb_sex;
					_whereRat_rmb_prov_cd = WhereRat_rmb_prov_cd;
					_whereRat_rmb_error_r_cd_1 = WhereRat_rmb_error_r_cd_1;
					_whereRat_rmb_error_r_cd_2 = WhereRat_rmb_error_r_cd_2;
					_whereRat_rmb_error_r_cd_3 = WhereRat_rmb_error_r_cd_3;
					_whereRat_rmb_error_r_cd_4 = WhereRat_rmb_error_r_cd_4;
					_whereRat_rmb_error_r_cd_5 = WhereRat_rmb_error_r_cd_5;
					_whereRat_rmb_service_cd = WhereRat_rmb_service_cd;
					_whereRat_rmb_amount_sub = WhereRat_rmb_amount_sub;
					_whereRat_rmb_nbr_of_serv = WhereRat_rmb_nbr_of_serv;
					_whereRat_rmb_service_date = WhereRat_rmb_service_date;
					_whereRat_rmb_diag_cd = WhereRat_rmb_diag_cd;
					_whereRat_rmb_t_explan_cd = WhereRat_rmb_t_explan_cd;
					_whereRat_rmb_error_t_cd_1 = WhereRat_rmb_error_t_cd_1;
					_whereRat_rmb_error_t_cd_2 = WhereRat_rmb_error_t_cd_2;
					_whereRat_rmb_error_t_cd_3 = WhereRat_rmb_error_t_cd_3;
					_whereRat_rmb_error_t_cd_4 = WhereRat_rmb_error_t_cd_4;
					_whereRat_rmb_error_t_cd_5 = WhereRat_rmb_error_t_cd_5;
					_whereRat_rmb_8_explan_cd = WhereRat_rmb_8_explan_cd;
					_whereRat_rmb_8_explan_desc = WhereRat_rmb_8_explan_desc;
					_whereRat_rmb_file_name = WhereRat_rmb_file_name;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRat_rmb_moh_off_cd == null 
				&& WhereRat_rmb_group_nbr == null 
				&& WhereRat_rmb_doc_nbr == null 
				&& WhereRat_rmb_specialty_cd == null 
				&& WhereRat_rmb_station_nbr == null 
				&& WhereRat_rmb_process_date == null 
				&& WhereRat_rmb_health_nbr == null 
				&& WhereRat_rmb_version_cd == null 
				&& WhereRat_rmb_birth_date == null 
				&& WhereRat_rmb_account_nbr == null 
				&& WhereRat_rmb_orig_seq_nbr == null 
				&& WhereRat_rmb_pay_prog == null 
				&& WhereRat_rmb_payee == null 
				&& WhereRat_rmb_refer_doc_nbr == null 
				&& WhereRat_rmb_facility_nbr == null 
				&& WhereRat_rmb_admit_date == null 
				&& WhereRat_rmb_loc_cd == null 
				&& WhereRat_rmb_error_h_cd_1 == null 
				&& WhereRat_rmb_error_h_cd_2 == null 
				&& WhereRat_rmb_error_h_cd_3 == null 
				&& WhereRat_rmb_error_h_cd_4 == null 
				&& WhereRat_rmb_error_h_cd_5 == null 
				&& WhereRat_rmb_registration_nbr == null 
				&& WhereRat_rmb_last_name == null 
				&& WhereRat_rmb_first_name == null 
				&& WhereRat_rmb_sex == null 
				&& WhereRat_rmb_prov_cd == null 
				&& WhereRat_rmb_error_r_cd_1 == null 
				&& WhereRat_rmb_error_r_cd_2 == null 
				&& WhereRat_rmb_error_r_cd_3 == null 
				&& WhereRat_rmb_error_r_cd_4 == null 
				&& WhereRat_rmb_error_r_cd_5 == null 
				&& WhereRat_rmb_service_cd == null 
				&& WhereRat_rmb_amount_sub == null 
				&& WhereRat_rmb_nbr_of_serv == null 
				&& WhereRat_rmb_service_date == null 
				&& WhereRat_rmb_diag_cd == null 
				&& WhereRat_rmb_t_explan_cd == null 
				&& WhereRat_rmb_error_t_cd_1 == null 
				&& WhereRat_rmb_error_t_cd_2 == null 
				&& WhereRat_rmb_error_t_cd_3 == null 
				&& WhereRat_rmb_error_t_cd_4 == null 
				&& WhereRat_rmb_error_t_cd_5 == null 
				&& WhereRat_rmb_8_explan_cd == null 
				&& WhereRat_rmb_8_explan_desc == null 
				&& WhereRat_rmb_file_name == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRat_rmb_moh_off_cd ==  _whereRat_rmb_moh_off_cd
				&& WhereRat_rmb_group_nbr ==  _whereRat_rmb_group_nbr
				&& WhereRat_rmb_doc_nbr ==  _whereRat_rmb_doc_nbr
				&& WhereRat_rmb_specialty_cd ==  _whereRat_rmb_specialty_cd
				&& WhereRat_rmb_station_nbr ==  _whereRat_rmb_station_nbr
				&& WhereRat_rmb_process_date ==  _whereRat_rmb_process_date
				&& WhereRat_rmb_health_nbr ==  _whereRat_rmb_health_nbr
				&& WhereRat_rmb_version_cd ==  _whereRat_rmb_version_cd
				&& WhereRat_rmb_birth_date ==  _whereRat_rmb_birth_date
				&& WhereRat_rmb_account_nbr ==  _whereRat_rmb_account_nbr
				&& WhereRat_rmb_orig_seq_nbr ==  _whereRat_rmb_orig_seq_nbr
				&& WhereRat_rmb_pay_prog ==  _whereRat_rmb_pay_prog
				&& WhereRat_rmb_payee ==  _whereRat_rmb_payee
				&& WhereRat_rmb_refer_doc_nbr ==  _whereRat_rmb_refer_doc_nbr
				&& WhereRat_rmb_facility_nbr ==  _whereRat_rmb_facility_nbr
				&& WhereRat_rmb_admit_date ==  _whereRat_rmb_admit_date
				&& WhereRat_rmb_loc_cd ==  _whereRat_rmb_loc_cd
				&& WhereRat_rmb_error_h_cd_1 ==  _whereRat_rmb_error_h_cd_1
				&& WhereRat_rmb_error_h_cd_2 ==  _whereRat_rmb_error_h_cd_2
				&& WhereRat_rmb_error_h_cd_3 ==  _whereRat_rmb_error_h_cd_3
				&& WhereRat_rmb_error_h_cd_4 ==  _whereRat_rmb_error_h_cd_4
				&& WhereRat_rmb_error_h_cd_5 ==  _whereRat_rmb_error_h_cd_5
				&& WhereRat_rmb_registration_nbr ==  _whereRat_rmb_registration_nbr
				&& WhereRat_rmb_last_name ==  _whereRat_rmb_last_name
				&& WhereRat_rmb_first_name ==  _whereRat_rmb_first_name
				&& WhereRat_rmb_sex ==  _whereRat_rmb_sex
				&& WhereRat_rmb_prov_cd ==  _whereRat_rmb_prov_cd
				&& WhereRat_rmb_error_r_cd_1 ==  _whereRat_rmb_error_r_cd_1
				&& WhereRat_rmb_error_r_cd_2 ==  _whereRat_rmb_error_r_cd_2
				&& WhereRat_rmb_error_r_cd_3 ==  _whereRat_rmb_error_r_cd_3
				&& WhereRat_rmb_error_r_cd_4 ==  _whereRat_rmb_error_r_cd_4
				&& WhereRat_rmb_error_r_cd_5 ==  _whereRat_rmb_error_r_cd_5
				&& WhereRat_rmb_service_cd ==  _whereRat_rmb_service_cd
				&& WhereRat_rmb_amount_sub ==  _whereRat_rmb_amount_sub
				&& WhereRat_rmb_nbr_of_serv ==  _whereRat_rmb_nbr_of_serv
				&& WhereRat_rmb_service_date ==  _whereRat_rmb_service_date
				&& WhereRat_rmb_diag_cd ==  _whereRat_rmb_diag_cd
				&& WhereRat_rmb_t_explan_cd ==  _whereRat_rmb_t_explan_cd
				&& WhereRat_rmb_error_t_cd_1 ==  _whereRat_rmb_error_t_cd_1
				&& WhereRat_rmb_error_t_cd_2 ==  _whereRat_rmb_error_t_cd_2
				&& WhereRat_rmb_error_t_cd_3 ==  _whereRat_rmb_error_t_cd_3
				&& WhereRat_rmb_error_t_cd_4 ==  _whereRat_rmb_error_t_cd_4
				&& WhereRat_rmb_error_t_cd_5 ==  _whereRat_rmb_error_t_cd_5
				&& WhereRat_rmb_8_explan_cd ==  _whereRat_rmb_8_explan_cd
				&& WhereRat_rmb_8_explan_desc ==  _whereRat_rmb_8_explan_desc
				&& WhereRat_rmb_file_name ==  _whereRat_rmb_file_name
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRat_rmb_moh_off_cd = null; 
			WhereRat_rmb_group_nbr = null; 
			WhereRat_rmb_doc_nbr = null; 
			WhereRat_rmb_specialty_cd = null; 
			WhereRat_rmb_station_nbr = null; 
			WhereRat_rmb_process_date = null; 
			WhereRat_rmb_health_nbr = null; 
			WhereRat_rmb_version_cd = null; 
			WhereRat_rmb_birth_date = null; 
			WhereRat_rmb_account_nbr = null; 
			WhereRat_rmb_orig_seq_nbr = null; 
			WhereRat_rmb_pay_prog = null; 
			WhereRat_rmb_payee = null; 
			WhereRat_rmb_refer_doc_nbr = null; 
			WhereRat_rmb_facility_nbr = null; 
			WhereRat_rmb_admit_date = null; 
			WhereRat_rmb_loc_cd = null; 
			WhereRat_rmb_error_h_cd_1 = null; 
			WhereRat_rmb_error_h_cd_2 = null; 
			WhereRat_rmb_error_h_cd_3 = null; 
			WhereRat_rmb_error_h_cd_4 = null; 
			WhereRat_rmb_error_h_cd_5 = null; 
			WhereRat_rmb_registration_nbr = null; 
			WhereRat_rmb_last_name = null; 
			WhereRat_rmb_first_name = null; 
			WhereRat_rmb_sex = null; 
			WhereRat_rmb_prov_cd = null; 
			WhereRat_rmb_error_r_cd_1 = null; 
			WhereRat_rmb_error_r_cd_2 = null; 
			WhereRat_rmb_error_r_cd_3 = null; 
			WhereRat_rmb_error_r_cd_4 = null; 
			WhereRat_rmb_error_r_cd_5 = null; 
			WhereRat_rmb_service_cd = null; 
			WhereRat_rmb_amount_sub = null; 
			WhereRat_rmb_nbr_of_serv = null; 
			WhereRat_rmb_service_date = null; 
			WhereRat_rmb_diag_cd = null; 
			WhereRat_rmb_t_explan_cd = null; 
			WhereRat_rmb_error_t_cd_1 = null; 
			WhereRat_rmb_error_t_cd_2 = null; 
			WhereRat_rmb_error_t_cd_3 = null; 
			WhereRat_rmb_error_t_cd_4 = null; 
			WhereRat_rmb_error_t_cd_5 = null; 
			WhereRat_rmb_8_explan_cd = null; 
			WhereRat_rmb_8_explan_desc = null; 
			WhereRat_rmb_file_name = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RAT_RMB_MOH_OFF_CD;
		private string _RAT_RMB_GROUP_NBR;
		private decimal? _RAT_RMB_DOC_NBR;
		private decimal? _RAT_RMB_SPECIALTY_CD;
		private string _RAT_RMB_STATION_NBR;
		private decimal? _RAT_RMB_PROCESS_DATE;
		private string _RAT_RMB_HEALTH_NBR;
		private string _RAT_RMB_VERSION_CD;
		private decimal? _RAT_RMB_BIRTH_DATE;
		private string _RAT_RMB_ACCOUNT_NBR;
		private decimal? _RAT_RMB_ORIG_SEQ_NBR;
		private string _RAT_RMB_PAY_PROG;
		private string _RAT_RMB_PAYEE;
		private decimal? _RAT_RMB_REFER_DOC_NBR;
		private string _RAT_RMB_FACILITY_NBR;
		private decimal? _RAT_RMB_ADMIT_DATE;
		private string _RAT_RMB_LOC_CD;
		private string _RAT_RMB_ERROR_H_CD_1;
		private string _RAT_RMB_ERROR_H_CD_2;
		private string _RAT_RMB_ERROR_H_CD_3;
		private string _RAT_RMB_ERROR_H_CD_4;
		private string _RAT_RMB_ERROR_H_CD_5;
		private string _RAT_RMB_REGISTRATION_NBR;
		private string _RAT_RMB_LAST_NAME;
		private string _RAT_RMB_FIRST_NAME;
		private string _RAT_RMB_SEX;
		private string _RAT_RMB_PROV_CD;
		private string _RAT_RMB_ERROR_R_CD_1;
		private string _RAT_RMB_ERROR_R_CD_2;
		private string _RAT_RMB_ERROR_R_CD_3;
		private string _RAT_RMB_ERROR_R_CD_4;
		private string _RAT_RMB_ERROR_R_CD_5;
		private string _RAT_RMB_SERVICE_CD;
		private decimal? _RAT_RMB_AMOUNT_SUB;
		private decimal? _RAT_RMB_NBR_OF_SERV;
		private decimal? _RAT_RMB_SERVICE_DATE;
		private string _RAT_RMB_DIAG_CD;
		private string _RAT_RMB_T_EXPLAN_CD;
		private string _RAT_RMB_ERROR_T_CD_1;
		private string _RAT_RMB_ERROR_T_CD_2;
		private string _RAT_RMB_ERROR_T_CD_3;
		private string _RAT_RMB_ERROR_T_CD_4;
		private string _RAT_RMB_ERROR_T_CD_5;
		private string _RAT_RMB_8_EXPLAN_CD;
		private string _RAT_RMB_8_EXPLAN_DESC;
		private string _RAT_RMB_FILE_NAME;
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
		public string RAT_RMB_MOH_OFF_CD
		{
			get { return _RAT_RMB_MOH_OFF_CD; }
			set
			{
				if (_RAT_RMB_MOH_OFF_CD != value)
				{
					_RAT_RMB_MOH_OFF_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_GROUP_NBR
		{
			get { return _RAT_RMB_GROUP_NBR; }
			set
			{
				if (_RAT_RMB_GROUP_NBR != value)
				{
					_RAT_RMB_GROUP_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_DOC_NBR
		{
			get { return _RAT_RMB_DOC_NBR; }
			set
			{
				if (_RAT_RMB_DOC_NBR != value)
				{
					_RAT_RMB_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_SPECIALTY_CD
		{
			get { return _RAT_RMB_SPECIALTY_CD; }
			set
			{
				if (_RAT_RMB_SPECIALTY_CD != value)
				{
					_RAT_RMB_SPECIALTY_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_STATION_NBR
		{
			get { return _RAT_RMB_STATION_NBR; }
			set
			{
				if (_RAT_RMB_STATION_NBR != value)
				{
					_RAT_RMB_STATION_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_PROCESS_DATE
		{
			get { return _RAT_RMB_PROCESS_DATE; }
			set
			{
				if (_RAT_RMB_PROCESS_DATE != value)
				{
					_RAT_RMB_PROCESS_DATE = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_HEALTH_NBR
		{
			get { return _RAT_RMB_HEALTH_NBR; }
			set
			{
				if (_RAT_RMB_HEALTH_NBR != value)
				{
					_RAT_RMB_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_VERSION_CD
		{
			get { return _RAT_RMB_VERSION_CD; }
			set
			{
				if (_RAT_RMB_VERSION_CD != value)
				{
					_RAT_RMB_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_BIRTH_DATE
		{
			get { return _RAT_RMB_BIRTH_DATE; }
			set
			{
				if (_RAT_RMB_BIRTH_DATE != value)
				{
					_RAT_RMB_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ACCOUNT_NBR
		{
			get { return _RAT_RMB_ACCOUNT_NBR; }
			set
			{
				if (_RAT_RMB_ACCOUNT_NBR != value)
				{
					_RAT_RMB_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_ORIG_SEQ_NBR
		{
			get { return _RAT_RMB_ORIG_SEQ_NBR; }
			set
			{
				if (_RAT_RMB_ORIG_SEQ_NBR != value)
				{
					_RAT_RMB_ORIG_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_PAY_PROG
		{
			get { return _RAT_RMB_PAY_PROG; }
			set
			{
				if (_RAT_RMB_PAY_PROG != value)
				{
					_RAT_RMB_PAY_PROG = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_PAYEE
		{
			get { return _RAT_RMB_PAYEE; }
			set
			{
				if (_RAT_RMB_PAYEE != value)
				{
					_RAT_RMB_PAYEE = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_REFER_DOC_NBR
		{
			get { return _RAT_RMB_REFER_DOC_NBR; }
			set
			{
				if (_RAT_RMB_REFER_DOC_NBR != value)
				{
					_RAT_RMB_REFER_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_FACILITY_NBR
		{
			get { return _RAT_RMB_FACILITY_NBR; }
			set
			{
				if (_RAT_RMB_FACILITY_NBR != value)
				{
					_RAT_RMB_FACILITY_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_ADMIT_DATE
		{
			get { return _RAT_RMB_ADMIT_DATE; }
			set
			{
				if (_RAT_RMB_ADMIT_DATE != value)
				{
					_RAT_RMB_ADMIT_DATE = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_LOC_CD
		{
			get { return _RAT_RMB_LOC_CD; }
			set
			{
				if (_RAT_RMB_LOC_CD != value)
				{
					_RAT_RMB_LOC_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_H_CD_1
		{
			get { return _RAT_RMB_ERROR_H_CD_1; }
			set
			{
				if (_RAT_RMB_ERROR_H_CD_1 != value)
				{
					_RAT_RMB_ERROR_H_CD_1 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_H_CD_2
		{
			get { return _RAT_RMB_ERROR_H_CD_2; }
			set
			{
				if (_RAT_RMB_ERROR_H_CD_2 != value)
				{
					_RAT_RMB_ERROR_H_CD_2 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_H_CD_3
		{
			get { return _RAT_RMB_ERROR_H_CD_3; }
			set
			{
				if (_RAT_RMB_ERROR_H_CD_3 != value)
				{
					_RAT_RMB_ERROR_H_CD_3 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_H_CD_4
		{
			get { return _RAT_RMB_ERROR_H_CD_4; }
			set
			{
				if (_RAT_RMB_ERROR_H_CD_4 != value)
				{
					_RAT_RMB_ERROR_H_CD_4 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_H_CD_5
		{
			get { return _RAT_RMB_ERROR_H_CD_5; }
			set
			{
				if (_RAT_RMB_ERROR_H_CD_5 != value)
				{
					_RAT_RMB_ERROR_H_CD_5 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_REGISTRATION_NBR
		{
			get { return _RAT_RMB_REGISTRATION_NBR; }
			set
			{
				if (_RAT_RMB_REGISTRATION_NBR != value)
				{
					_RAT_RMB_REGISTRATION_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_LAST_NAME
		{
			get { return _RAT_RMB_LAST_NAME; }
			set
			{
				if (_RAT_RMB_LAST_NAME != value)
				{
					_RAT_RMB_LAST_NAME = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_FIRST_NAME
		{
			get { return _RAT_RMB_FIRST_NAME; }
			set
			{
				if (_RAT_RMB_FIRST_NAME != value)
				{
					_RAT_RMB_FIRST_NAME = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_SEX
		{
			get { return _RAT_RMB_SEX; }
			set
			{
				if (_RAT_RMB_SEX != value)
				{
					_RAT_RMB_SEX = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_PROV_CD
		{
			get { return _RAT_RMB_PROV_CD; }
			set
			{
				if (_RAT_RMB_PROV_CD != value)
				{
					_RAT_RMB_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_R_CD_1
		{
			get { return _RAT_RMB_ERROR_R_CD_1; }
			set
			{
				if (_RAT_RMB_ERROR_R_CD_1 != value)
				{
					_RAT_RMB_ERROR_R_CD_1 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_R_CD_2
		{
			get { return _RAT_RMB_ERROR_R_CD_2; }
			set
			{
				if (_RAT_RMB_ERROR_R_CD_2 != value)
				{
					_RAT_RMB_ERROR_R_CD_2 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_R_CD_3
		{
			get { return _RAT_RMB_ERROR_R_CD_3; }
			set
			{
				if (_RAT_RMB_ERROR_R_CD_3 != value)
				{
					_RAT_RMB_ERROR_R_CD_3 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_R_CD_4
		{
			get { return _RAT_RMB_ERROR_R_CD_4; }
			set
			{
				if (_RAT_RMB_ERROR_R_CD_4 != value)
				{
					_RAT_RMB_ERROR_R_CD_4 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_R_CD_5
		{
			get { return _RAT_RMB_ERROR_R_CD_5; }
			set
			{
				if (_RAT_RMB_ERROR_R_CD_5 != value)
				{
					_RAT_RMB_ERROR_R_CD_5 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_SERVICE_CD
		{
			get { return _RAT_RMB_SERVICE_CD; }
			set
			{
				if (_RAT_RMB_SERVICE_CD != value)
				{
					_RAT_RMB_SERVICE_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_AMOUNT_SUB
		{
			get { return _RAT_RMB_AMOUNT_SUB; }
			set
			{
				if (_RAT_RMB_AMOUNT_SUB != value)
				{
					_RAT_RMB_AMOUNT_SUB = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_NBR_OF_SERV
		{
			get { return _RAT_RMB_NBR_OF_SERV; }
			set
			{
				if (_RAT_RMB_NBR_OF_SERV != value)
				{
					_RAT_RMB_NBR_OF_SERV = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_RMB_SERVICE_DATE
		{
			get { return _RAT_RMB_SERVICE_DATE; }
			set
			{
				if (_RAT_RMB_SERVICE_DATE != value)
				{
					_RAT_RMB_SERVICE_DATE = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_DIAG_CD
		{
			get { return _RAT_RMB_DIAG_CD; }
			set
			{
				if (_RAT_RMB_DIAG_CD != value)
				{
					_RAT_RMB_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_T_EXPLAN_CD
		{
			get { return _RAT_RMB_T_EXPLAN_CD; }
			set
			{
				if (_RAT_RMB_T_EXPLAN_CD != value)
				{
					_RAT_RMB_T_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_T_CD_1
		{
			get { return _RAT_RMB_ERROR_T_CD_1; }
			set
			{
				if (_RAT_RMB_ERROR_T_CD_1 != value)
				{
					_RAT_RMB_ERROR_T_CD_1 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_T_CD_2
		{
			get { return _RAT_RMB_ERROR_T_CD_2; }
			set
			{
				if (_RAT_RMB_ERROR_T_CD_2 != value)
				{
					_RAT_RMB_ERROR_T_CD_2 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_T_CD_3
		{
			get { return _RAT_RMB_ERROR_T_CD_3; }
			set
			{
				if (_RAT_RMB_ERROR_T_CD_3 != value)
				{
					_RAT_RMB_ERROR_T_CD_3 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_T_CD_4
		{
			get { return _RAT_RMB_ERROR_T_CD_4; }
			set
			{
				if (_RAT_RMB_ERROR_T_CD_4 != value)
				{
					_RAT_RMB_ERROR_T_CD_4 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_ERROR_T_CD_5
		{
			get { return _RAT_RMB_ERROR_T_CD_5; }
			set
			{
				if (_RAT_RMB_ERROR_T_CD_5 != value)
				{
					_RAT_RMB_ERROR_T_CD_5 = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_8_EXPLAN_CD
		{
			get { return _RAT_RMB_8_EXPLAN_CD; }
			set
			{
				if (_RAT_RMB_8_EXPLAN_CD != value)
				{
					_RAT_RMB_8_EXPLAN_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_8_EXPLAN_DESC
		{
			get { return _RAT_RMB_8_EXPLAN_DESC; }
			set
			{
				if (_RAT_RMB_8_EXPLAN_DESC != value)
				{
					_RAT_RMB_8_EXPLAN_DESC = value;
					ChangeState();
				}
			}
		}
		public string RAT_RMB_FILE_NAME
		{
			get { return _RAT_RMB_FILE_NAME; }
			set
			{
				if (_RAT_RMB_FILE_NAME != value)
				{
					_RAT_RMB_FILE_NAME = value;
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
		public string WhereRat_rmb_moh_off_cd { get; set; }
		private string _whereRat_rmb_moh_off_cd;
		public string WhereRat_rmb_group_nbr { get; set; }
		private string _whereRat_rmb_group_nbr;
		public decimal? WhereRat_rmb_doc_nbr { get; set; }
		private decimal? _whereRat_rmb_doc_nbr;
		public decimal? WhereRat_rmb_specialty_cd { get; set; }
		private decimal? _whereRat_rmb_specialty_cd;
		public string WhereRat_rmb_station_nbr { get; set; }
		private string _whereRat_rmb_station_nbr;
		public decimal? WhereRat_rmb_process_date { get; set; }
		private decimal? _whereRat_rmb_process_date;
		public string WhereRat_rmb_health_nbr { get; set; }
		private string _whereRat_rmb_health_nbr;
		public string WhereRat_rmb_version_cd { get; set; }
		private string _whereRat_rmb_version_cd;
		public decimal? WhereRat_rmb_birth_date { get; set; }
		private decimal? _whereRat_rmb_birth_date;
		public string WhereRat_rmb_account_nbr { get; set; }
		private string _whereRat_rmb_account_nbr;
		public decimal? WhereRat_rmb_orig_seq_nbr { get; set; }
		private decimal? _whereRat_rmb_orig_seq_nbr;
		public string WhereRat_rmb_pay_prog { get; set; }
		private string _whereRat_rmb_pay_prog;
		public string WhereRat_rmb_payee { get; set; }
		private string _whereRat_rmb_payee;
		public decimal? WhereRat_rmb_refer_doc_nbr { get; set; }
		private decimal? _whereRat_rmb_refer_doc_nbr;
		public string WhereRat_rmb_facility_nbr { get; set; }
		private string _whereRat_rmb_facility_nbr;
		public decimal? WhereRat_rmb_admit_date { get; set; }
		private decimal? _whereRat_rmb_admit_date;
		public string WhereRat_rmb_loc_cd { get; set; }
		private string _whereRat_rmb_loc_cd;
		public string WhereRat_rmb_error_h_cd_1 { get; set; }
		private string _whereRat_rmb_error_h_cd_1;
		public string WhereRat_rmb_error_h_cd_2 { get; set; }
		private string _whereRat_rmb_error_h_cd_2;
		public string WhereRat_rmb_error_h_cd_3 { get; set; }
		private string _whereRat_rmb_error_h_cd_3;
		public string WhereRat_rmb_error_h_cd_4 { get; set; }
		private string _whereRat_rmb_error_h_cd_4;
		public string WhereRat_rmb_error_h_cd_5 { get; set; }
		private string _whereRat_rmb_error_h_cd_5;
		public string WhereRat_rmb_registration_nbr { get; set; }
		private string _whereRat_rmb_registration_nbr;
		public string WhereRat_rmb_last_name { get; set; }
		private string _whereRat_rmb_last_name;
		public string WhereRat_rmb_first_name { get; set; }
		private string _whereRat_rmb_first_name;
		public string WhereRat_rmb_sex { get; set; }
		private string _whereRat_rmb_sex;
		public string WhereRat_rmb_prov_cd { get; set; }
		private string _whereRat_rmb_prov_cd;
		public string WhereRat_rmb_error_r_cd_1 { get; set; }
		private string _whereRat_rmb_error_r_cd_1;
		public string WhereRat_rmb_error_r_cd_2 { get; set; }
		private string _whereRat_rmb_error_r_cd_2;
		public string WhereRat_rmb_error_r_cd_3 { get; set; }
		private string _whereRat_rmb_error_r_cd_3;
		public string WhereRat_rmb_error_r_cd_4 { get; set; }
		private string _whereRat_rmb_error_r_cd_4;
		public string WhereRat_rmb_error_r_cd_5 { get; set; }
		private string _whereRat_rmb_error_r_cd_5;
		public string WhereRat_rmb_service_cd { get; set; }
		private string _whereRat_rmb_service_cd;
		public decimal? WhereRat_rmb_amount_sub { get; set; }
		private decimal? _whereRat_rmb_amount_sub;
		public decimal? WhereRat_rmb_nbr_of_serv { get; set; }
		private decimal? _whereRat_rmb_nbr_of_serv;
		public decimal? WhereRat_rmb_service_date { get; set; }
		private decimal? _whereRat_rmb_service_date;
		public string WhereRat_rmb_diag_cd { get; set; }
		private string _whereRat_rmb_diag_cd;
		public string WhereRat_rmb_t_explan_cd { get; set; }
		private string _whereRat_rmb_t_explan_cd;
		public string WhereRat_rmb_error_t_cd_1 { get; set; }
		private string _whereRat_rmb_error_t_cd_1;
		public string WhereRat_rmb_error_t_cd_2 { get; set; }
		private string _whereRat_rmb_error_t_cd_2;
		public string WhereRat_rmb_error_t_cd_3 { get; set; }
		private string _whereRat_rmb_error_t_cd_3;
		public string WhereRat_rmb_error_t_cd_4 { get; set; }
		private string _whereRat_rmb_error_t_cd_4;
		public string WhereRat_rmb_error_t_cd_5 { get; set; }
		private string _whereRat_rmb_error_t_cd_5;
		public string WhereRat_rmb_8_explan_cd { get; set; }
		private string _whereRat_rmb_8_explan_cd;
		public string WhereRat_rmb_8_explan_desc { get; set; }
		private string _whereRat_rmb_8_explan_desc;
		public string WhereRat_rmb_file_name { get; set; }
		private string _whereRat_rmb_file_name;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRat_rmb_moh_off_cd;
		private string _originalRat_rmb_group_nbr;
		private decimal? _originalRat_rmb_doc_nbr;
		private decimal? _originalRat_rmb_specialty_cd;
		private string _originalRat_rmb_station_nbr;
		private decimal? _originalRat_rmb_process_date;
		private string _originalRat_rmb_health_nbr;
		private string _originalRat_rmb_version_cd;
		private decimal? _originalRat_rmb_birth_date;
		private string _originalRat_rmb_account_nbr;
		private decimal? _originalRat_rmb_orig_seq_nbr;
		private string _originalRat_rmb_pay_prog;
		private string _originalRat_rmb_payee;
		private decimal? _originalRat_rmb_refer_doc_nbr;
		private string _originalRat_rmb_facility_nbr;
		private decimal? _originalRat_rmb_admit_date;
		private string _originalRat_rmb_loc_cd;
		private string _originalRat_rmb_error_h_cd_1;
		private string _originalRat_rmb_error_h_cd_2;
		private string _originalRat_rmb_error_h_cd_3;
		private string _originalRat_rmb_error_h_cd_4;
		private string _originalRat_rmb_error_h_cd_5;
		private string _originalRat_rmb_registration_nbr;
		private string _originalRat_rmb_last_name;
		private string _originalRat_rmb_first_name;
		private string _originalRat_rmb_sex;
		private string _originalRat_rmb_prov_cd;
		private string _originalRat_rmb_error_r_cd_1;
		private string _originalRat_rmb_error_r_cd_2;
		private string _originalRat_rmb_error_r_cd_3;
		private string _originalRat_rmb_error_r_cd_4;
		private string _originalRat_rmb_error_r_cd_5;
		private string _originalRat_rmb_service_cd;
		private decimal? _originalRat_rmb_amount_sub;
		private decimal? _originalRat_rmb_nbr_of_serv;
		private decimal? _originalRat_rmb_service_date;
		private string _originalRat_rmb_diag_cd;
		private string _originalRat_rmb_t_explan_cd;
		private string _originalRat_rmb_error_t_cd_1;
		private string _originalRat_rmb_error_t_cd_2;
		private string _originalRat_rmb_error_t_cd_3;
		private string _originalRat_rmb_error_t_cd_4;
		private string _originalRat_rmb_error_t_cd_5;
		private string _originalRat_rmb_8_explan_cd;
		private string _originalRat_rmb_8_explan_desc;
		private string _originalRat_rmb_file_name;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RAT_RMB_MOH_OFF_CD = _originalRat_rmb_moh_off_cd;
			RAT_RMB_GROUP_NBR = _originalRat_rmb_group_nbr;
			RAT_RMB_DOC_NBR = _originalRat_rmb_doc_nbr;
			RAT_RMB_SPECIALTY_CD = _originalRat_rmb_specialty_cd;
			RAT_RMB_STATION_NBR = _originalRat_rmb_station_nbr;
			RAT_RMB_PROCESS_DATE = _originalRat_rmb_process_date;
			RAT_RMB_HEALTH_NBR = _originalRat_rmb_health_nbr;
			RAT_RMB_VERSION_CD = _originalRat_rmb_version_cd;
			RAT_RMB_BIRTH_DATE = _originalRat_rmb_birth_date;
			RAT_RMB_ACCOUNT_NBR = _originalRat_rmb_account_nbr;
			RAT_RMB_ORIG_SEQ_NBR = _originalRat_rmb_orig_seq_nbr;
			RAT_RMB_PAY_PROG = _originalRat_rmb_pay_prog;
			RAT_RMB_PAYEE = _originalRat_rmb_payee;
			RAT_RMB_REFER_DOC_NBR = _originalRat_rmb_refer_doc_nbr;
			RAT_RMB_FACILITY_NBR = _originalRat_rmb_facility_nbr;
			RAT_RMB_ADMIT_DATE = _originalRat_rmb_admit_date;
			RAT_RMB_LOC_CD = _originalRat_rmb_loc_cd;
			RAT_RMB_ERROR_H_CD_1 = _originalRat_rmb_error_h_cd_1;
			RAT_RMB_ERROR_H_CD_2 = _originalRat_rmb_error_h_cd_2;
			RAT_RMB_ERROR_H_CD_3 = _originalRat_rmb_error_h_cd_3;
			RAT_RMB_ERROR_H_CD_4 = _originalRat_rmb_error_h_cd_4;
			RAT_RMB_ERROR_H_CD_5 = _originalRat_rmb_error_h_cd_5;
			RAT_RMB_REGISTRATION_NBR = _originalRat_rmb_registration_nbr;
			RAT_RMB_LAST_NAME = _originalRat_rmb_last_name;
			RAT_RMB_FIRST_NAME = _originalRat_rmb_first_name;
			RAT_RMB_SEX = _originalRat_rmb_sex;
			RAT_RMB_PROV_CD = _originalRat_rmb_prov_cd;
			RAT_RMB_ERROR_R_CD_1 = _originalRat_rmb_error_r_cd_1;
			RAT_RMB_ERROR_R_CD_2 = _originalRat_rmb_error_r_cd_2;
			RAT_RMB_ERROR_R_CD_3 = _originalRat_rmb_error_r_cd_3;
			RAT_RMB_ERROR_R_CD_4 = _originalRat_rmb_error_r_cd_4;
			RAT_RMB_ERROR_R_CD_5 = _originalRat_rmb_error_r_cd_5;
			RAT_RMB_SERVICE_CD = _originalRat_rmb_service_cd;
			RAT_RMB_AMOUNT_SUB = _originalRat_rmb_amount_sub;
			RAT_RMB_NBR_OF_SERV = _originalRat_rmb_nbr_of_serv;
			RAT_RMB_SERVICE_DATE = _originalRat_rmb_service_date;
			RAT_RMB_DIAG_CD = _originalRat_rmb_diag_cd;
			RAT_RMB_T_EXPLAN_CD = _originalRat_rmb_t_explan_cd;
			RAT_RMB_ERROR_T_CD_1 = _originalRat_rmb_error_t_cd_1;
			RAT_RMB_ERROR_T_CD_2 = _originalRat_rmb_error_t_cd_2;
			RAT_RMB_ERROR_T_CD_3 = _originalRat_rmb_error_t_cd_3;
			RAT_RMB_ERROR_T_CD_4 = _originalRat_rmb_error_t_cd_4;
			RAT_RMB_ERROR_T_CD_5 = _originalRat_rmb_error_t_cd_5;
			RAT_RMB_8_EXPLAN_CD = _originalRat_rmb_8_explan_cd;
			RAT_RMB_8_EXPLAN_DESC = _originalRat_rmb_8_explan_desc;
			RAT_RMB_FILE_NAME = _originalRat_rmb_file_name;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_Purge]");
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
						new SqlParameter("RAT_RMB_MOH_OFF_CD", SqlNull(RAT_RMB_MOH_OFF_CD)),
						new SqlParameter("RAT_RMB_GROUP_NBR", SqlNull(RAT_RMB_GROUP_NBR)),
						new SqlParameter("RAT_RMB_DOC_NBR", SqlNull(RAT_RMB_DOC_NBR)),
						new SqlParameter("RAT_RMB_SPECIALTY_CD", SqlNull(RAT_RMB_SPECIALTY_CD)),
						new SqlParameter("RAT_RMB_STATION_NBR", SqlNull(RAT_RMB_STATION_NBR)),
						new SqlParameter("RAT_RMB_PROCESS_DATE", SqlNull(RAT_RMB_PROCESS_DATE)),
						new SqlParameter("RAT_RMB_HEALTH_NBR", SqlNull(RAT_RMB_HEALTH_NBR)),
						new SqlParameter("RAT_RMB_VERSION_CD", SqlNull(RAT_RMB_VERSION_CD)),
						new SqlParameter("RAT_RMB_BIRTH_DATE", SqlNull(RAT_RMB_BIRTH_DATE)),
						new SqlParameter("RAT_RMB_ACCOUNT_NBR", SqlNull(RAT_RMB_ACCOUNT_NBR)),
						new SqlParameter("RAT_RMB_ORIG_SEQ_NBR", SqlNull(RAT_RMB_ORIG_SEQ_NBR)),
						new SqlParameter("RAT_RMB_PAY_PROG", SqlNull(RAT_RMB_PAY_PROG)),
						new SqlParameter("RAT_RMB_PAYEE", SqlNull(RAT_RMB_PAYEE)),
						new SqlParameter("RAT_RMB_REFER_DOC_NBR", SqlNull(RAT_RMB_REFER_DOC_NBR)),
						new SqlParameter("RAT_RMB_FACILITY_NBR", SqlNull(RAT_RMB_FACILITY_NBR)),
						new SqlParameter("RAT_RMB_ADMIT_DATE", SqlNull(RAT_RMB_ADMIT_DATE)),
						new SqlParameter("RAT_RMB_LOC_CD", SqlNull(RAT_RMB_LOC_CD)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_1", SqlNull(RAT_RMB_ERROR_H_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_2", SqlNull(RAT_RMB_ERROR_H_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_3", SqlNull(RAT_RMB_ERROR_H_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_4", SqlNull(RAT_RMB_ERROR_H_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_5", SqlNull(RAT_RMB_ERROR_H_CD_5)),
						new SqlParameter("RAT_RMB_REGISTRATION_NBR", SqlNull(RAT_RMB_REGISTRATION_NBR)),
						new SqlParameter("RAT_RMB_LAST_NAME", SqlNull(RAT_RMB_LAST_NAME)),
						new SqlParameter("RAT_RMB_FIRST_NAME", SqlNull(RAT_RMB_FIRST_NAME)),
						new SqlParameter("RAT_RMB_SEX", SqlNull(RAT_RMB_SEX)),
						new SqlParameter("RAT_RMB_PROV_CD", SqlNull(RAT_RMB_PROV_CD)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_1", SqlNull(RAT_RMB_ERROR_R_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_2", SqlNull(RAT_RMB_ERROR_R_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_3", SqlNull(RAT_RMB_ERROR_R_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_4", SqlNull(RAT_RMB_ERROR_R_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_5", SqlNull(RAT_RMB_ERROR_R_CD_5)),
						new SqlParameter("RAT_RMB_SERVICE_CD", SqlNull(RAT_RMB_SERVICE_CD)),
						new SqlParameter("RAT_RMB_AMOUNT_SUB", SqlNull(RAT_RMB_AMOUNT_SUB)),
						new SqlParameter("RAT_RMB_NBR_OF_SERV", SqlNull(RAT_RMB_NBR_OF_SERV)),
						new SqlParameter("RAT_RMB_SERVICE_DATE", SqlNull(RAT_RMB_SERVICE_DATE)),
						new SqlParameter("RAT_RMB_DIAG_CD", SqlNull(RAT_RMB_DIAG_CD)),
						new SqlParameter("RAT_RMB_T_EXPLAN_CD", SqlNull(RAT_RMB_T_EXPLAN_CD)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_1", SqlNull(RAT_RMB_ERROR_T_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_2", SqlNull(RAT_RMB_ERROR_T_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_3", SqlNull(RAT_RMB_ERROR_T_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_4", SqlNull(RAT_RMB_ERROR_T_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_5", SqlNull(RAT_RMB_ERROR_T_CD_5)),
						new SqlParameter("RAT_RMB_8_EXPLAN_CD", SqlNull(RAT_RMB_8_EXPLAN_CD)),
						new SqlParameter("RAT_RMB_8_EXPLAN_DESC", SqlNull(RAT_RMB_8_EXPLAN_DESC)),
						new SqlParameter("RAT_RMB_FILE_NAME", SqlNull(RAT_RMB_FILE_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_RMB_MOH_OFF_CD = Reader["RAT_RMB_MOH_OFF_CD"].ToString();
						RAT_RMB_GROUP_NBR = Reader["RAT_RMB_GROUP_NBR"].ToString();
						RAT_RMB_DOC_NBR = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]);
						RAT_RMB_SPECIALTY_CD = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]);
						RAT_RMB_STATION_NBR = Reader["RAT_RMB_STATION_NBR"].ToString();
						RAT_RMB_PROCESS_DATE = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]);
						RAT_RMB_HEALTH_NBR = Reader["RAT_RMB_HEALTH_NBR"].ToString();
						RAT_RMB_VERSION_CD = Reader["RAT_RMB_VERSION_CD"].ToString();
						RAT_RMB_BIRTH_DATE = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]);
						RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						RAT_RMB_ORIG_SEQ_NBR = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]);
						RAT_RMB_PAY_PROG = Reader["RAT_RMB_PAY_PROG"].ToString();
						RAT_RMB_PAYEE = Reader["RAT_RMB_PAYEE"].ToString();
						RAT_RMB_REFER_DOC_NBR = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]);
						RAT_RMB_FACILITY_NBR = Reader["RAT_RMB_FACILITY_NBR"].ToString();
						RAT_RMB_ADMIT_DATE = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]);
						RAT_RMB_LOC_CD = Reader["RAT_RMB_LOC_CD"].ToString();
						RAT_RMB_ERROR_H_CD_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString();
						RAT_RMB_ERROR_H_CD_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString();
						RAT_RMB_ERROR_H_CD_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString();
						RAT_RMB_ERROR_H_CD_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString();
						RAT_RMB_ERROR_H_CD_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString();
						RAT_RMB_REGISTRATION_NBR = Reader["RAT_RMB_REGISTRATION_NBR"].ToString();
						RAT_RMB_LAST_NAME = Reader["RAT_RMB_LAST_NAME"].ToString();
						RAT_RMB_FIRST_NAME = Reader["RAT_RMB_FIRST_NAME"].ToString();
						RAT_RMB_SEX = Reader["RAT_RMB_SEX"].ToString();
						RAT_RMB_PROV_CD = Reader["RAT_RMB_PROV_CD"].ToString();
						RAT_RMB_ERROR_R_CD_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString();
						RAT_RMB_ERROR_R_CD_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString();
						RAT_RMB_ERROR_R_CD_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString();
						RAT_RMB_ERROR_R_CD_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString();
						RAT_RMB_ERROR_R_CD_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString();
						RAT_RMB_SERVICE_CD = Reader["RAT_RMB_SERVICE_CD"].ToString();
						RAT_RMB_AMOUNT_SUB = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]);
						RAT_RMB_NBR_OF_SERV = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]);
						RAT_RMB_SERVICE_DATE = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]);
						RAT_RMB_DIAG_CD = Reader["RAT_RMB_DIAG_CD"].ToString();
						RAT_RMB_T_EXPLAN_CD = Reader["RAT_RMB_T_EXPLAN_CD"].ToString();
						RAT_RMB_ERROR_T_CD_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString();
						RAT_RMB_ERROR_T_CD_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString();
						RAT_RMB_ERROR_T_CD_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString();
						RAT_RMB_ERROR_T_CD_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString();
						RAT_RMB_ERROR_T_CD_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString();
						RAT_RMB_8_EXPLAN_CD = Reader["RAT_RMB_8_EXPLAN_CD"].ToString();
						RAT_RMB_8_EXPLAN_DESC = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString();
						RAT_RMB_FILE_NAME = Reader["RAT_RMB_FILE_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_rmb_moh_off_cd = Reader["RAT_RMB_MOH_OFF_CD"].ToString();
						_originalRat_rmb_group_nbr = Reader["RAT_RMB_GROUP_NBR"].ToString();
						_originalRat_rmb_doc_nbr = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]);
						_originalRat_rmb_specialty_cd = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]);
						_originalRat_rmb_station_nbr = Reader["RAT_RMB_STATION_NBR"].ToString();
						_originalRat_rmb_process_date = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]);
						_originalRat_rmb_health_nbr = Reader["RAT_RMB_HEALTH_NBR"].ToString();
						_originalRat_rmb_version_cd = Reader["RAT_RMB_VERSION_CD"].ToString();
						_originalRat_rmb_birth_date = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]);
						_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						_originalRat_rmb_orig_seq_nbr = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]);
						_originalRat_rmb_pay_prog = Reader["RAT_RMB_PAY_PROG"].ToString();
						_originalRat_rmb_payee = Reader["RAT_RMB_PAYEE"].ToString();
						_originalRat_rmb_refer_doc_nbr = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]);
						_originalRat_rmb_facility_nbr = Reader["RAT_RMB_FACILITY_NBR"].ToString();
						_originalRat_rmb_admit_date = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]);
						_originalRat_rmb_loc_cd = Reader["RAT_RMB_LOC_CD"].ToString();
						_originalRat_rmb_error_h_cd_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString();
						_originalRat_rmb_error_h_cd_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString();
						_originalRat_rmb_error_h_cd_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString();
						_originalRat_rmb_error_h_cd_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString();
						_originalRat_rmb_error_h_cd_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString();
						_originalRat_rmb_registration_nbr = Reader["RAT_RMB_REGISTRATION_NBR"].ToString();
						_originalRat_rmb_last_name = Reader["RAT_RMB_LAST_NAME"].ToString();
						_originalRat_rmb_first_name = Reader["RAT_RMB_FIRST_NAME"].ToString();
						_originalRat_rmb_sex = Reader["RAT_RMB_SEX"].ToString();
						_originalRat_rmb_prov_cd = Reader["RAT_RMB_PROV_CD"].ToString();
						_originalRat_rmb_error_r_cd_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString();
						_originalRat_rmb_error_r_cd_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString();
						_originalRat_rmb_error_r_cd_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString();
						_originalRat_rmb_error_r_cd_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString();
						_originalRat_rmb_error_r_cd_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString();
						_originalRat_rmb_service_cd = Reader["RAT_RMB_SERVICE_CD"].ToString();
						_originalRat_rmb_amount_sub = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]);
						_originalRat_rmb_nbr_of_serv = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]);
						_originalRat_rmb_service_date = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]);
						_originalRat_rmb_diag_cd = Reader["RAT_RMB_DIAG_CD"].ToString();
						_originalRat_rmb_t_explan_cd = Reader["RAT_RMB_T_EXPLAN_CD"].ToString();
						_originalRat_rmb_error_t_cd_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString();
						_originalRat_rmb_error_t_cd_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString();
						_originalRat_rmb_error_t_cd_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString();
						_originalRat_rmb_error_t_cd_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString();
						_originalRat_rmb_error_t_cd_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString();
						_originalRat_rmb_8_explan_cd = Reader["RAT_RMB_8_EXPLAN_CD"].ToString();
						_originalRat_rmb_8_explan_desc = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString();
						_originalRat_rmb_file_name = Reader["RAT_RMB_FILE_NAME"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RAT_RMB_MOH_OFF_CD", SqlNull(RAT_RMB_MOH_OFF_CD)),
						new SqlParameter("RAT_RMB_GROUP_NBR", SqlNull(RAT_RMB_GROUP_NBR)),
						new SqlParameter("RAT_RMB_DOC_NBR", SqlNull(RAT_RMB_DOC_NBR)),
						new SqlParameter("RAT_RMB_SPECIALTY_CD", SqlNull(RAT_RMB_SPECIALTY_CD)),
						new SqlParameter("RAT_RMB_STATION_NBR", SqlNull(RAT_RMB_STATION_NBR)),
						new SqlParameter("RAT_RMB_PROCESS_DATE", SqlNull(RAT_RMB_PROCESS_DATE)),
						new SqlParameter("RAT_RMB_HEALTH_NBR", SqlNull(RAT_RMB_HEALTH_NBR)),
						new SqlParameter("RAT_RMB_VERSION_CD", SqlNull(RAT_RMB_VERSION_CD)),
						new SqlParameter("RAT_RMB_BIRTH_DATE", SqlNull(RAT_RMB_BIRTH_DATE)),
						new SqlParameter("RAT_RMB_ACCOUNT_NBR", SqlNull(RAT_RMB_ACCOUNT_NBR)),
						new SqlParameter("RAT_RMB_ORIG_SEQ_NBR", SqlNull(RAT_RMB_ORIG_SEQ_NBR)),
						new SqlParameter("RAT_RMB_PAY_PROG", SqlNull(RAT_RMB_PAY_PROG)),
						new SqlParameter("RAT_RMB_PAYEE", SqlNull(RAT_RMB_PAYEE)),
						new SqlParameter("RAT_RMB_REFER_DOC_NBR", SqlNull(RAT_RMB_REFER_DOC_NBR)),
						new SqlParameter("RAT_RMB_FACILITY_NBR", SqlNull(RAT_RMB_FACILITY_NBR)),
						new SqlParameter("RAT_RMB_ADMIT_DATE", SqlNull(RAT_RMB_ADMIT_DATE)),
						new SqlParameter("RAT_RMB_LOC_CD", SqlNull(RAT_RMB_LOC_CD)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_1", SqlNull(RAT_RMB_ERROR_H_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_2", SqlNull(RAT_RMB_ERROR_H_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_3", SqlNull(RAT_RMB_ERROR_H_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_4", SqlNull(RAT_RMB_ERROR_H_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_H_CD_5", SqlNull(RAT_RMB_ERROR_H_CD_5)),
						new SqlParameter("RAT_RMB_REGISTRATION_NBR", SqlNull(RAT_RMB_REGISTRATION_NBR)),
						new SqlParameter("RAT_RMB_LAST_NAME", SqlNull(RAT_RMB_LAST_NAME)),
						new SqlParameter("RAT_RMB_FIRST_NAME", SqlNull(RAT_RMB_FIRST_NAME)),
						new SqlParameter("RAT_RMB_SEX", SqlNull(RAT_RMB_SEX)),
						new SqlParameter("RAT_RMB_PROV_CD", SqlNull(RAT_RMB_PROV_CD)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_1", SqlNull(RAT_RMB_ERROR_R_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_2", SqlNull(RAT_RMB_ERROR_R_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_3", SqlNull(RAT_RMB_ERROR_R_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_4", SqlNull(RAT_RMB_ERROR_R_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_R_CD_5", SqlNull(RAT_RMB_ERROR_R_CD_5)),
						new SqlParameter("RAT_RMB_SERVICE_CD", SqlNull(RAT_RMB_SERVICE_CD)),
						new SqlParameter("RAT_RMB_AMOUNT_SUB", SqlNull(RAT_RMB_AMOUNT_SUB)),
						new SqlParameter("RAT_RMB_NBR_OF_SERV", SqlNull(RAT_RMB_NBR_OF_SERV)),
						new SqlParameter("RAT_RMB_SERVICE_DATE", SqlNull(RAT_RMB_SERVICE_DATE)),
						new SqlParameter("RAT_RMB_DIAG_CD", SqlNull(RAT_RMB_DIAG_CD)),
						new SqlParameter("RAT_RMB_T_EXPLAN_CD", SqlNull(RAT_RMB_T_EXPLAN_CD)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_1", SqlNull(RAT_RMB_ERROR_T_CD_1)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_2", SqlNull(RAT_RMB_ERROR_T_CD_2)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_3", SqlNull(RAT_RMB_ERROR_T_CD_3)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_4", SqlNull(RAT_RMB_ERROR_T_CD_4)),
						new SqlParameter("RAT_RMB_ERROR_T_CD_5", SqlNull(RAT_RMB_ERROR_T_CD_5)),
						new SqlParameter("RAT_RMB_8_EXPLAN_CD", SqlNull(RAT_RMB_8_EXPLAN_CD)),
						new SqlParameter("RAT_RMB_8_EXPLAN_DESC", SqlNull(RAT_RMB_8_EXPLAN_DESC)),
						new SqlParameter("RAT_RMB_FILE_NAME", SqlNull(RAT_RMB_FILE_NAME)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U021A_EDT_RMB_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_RMB_MOH_OFF_CD = Reader["RAT_RMB_MOH_OFF_CD"].ToString();
						RAT_RMB_GROUP_NBR = Reader["RAT_RMB_GROUP_NBR"].ToString();
						RAT_RMB_DOC_NBR = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]);
						RAT_RMB_SPECIALTY_CD = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]);
						RAT_RMB_STATION_NBR = Reader["RAT_RMB_STATION_NBR"].ToString();
						RAT_RMB_PROCESS_DATE = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]);
						RAT_RMB_HEALTH_NBR = Reader["RAT_RMB_HEALTH_NBR"].ToString();
						RAT_RMB_VERSION_CD = Reader["RAT_RMB_VERSION_CD"].ToString();
						RAT_RMB_BIRTH_DATE = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]);
						RAT_RMB_ACCOUNT_NBR = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						RAT_RMB_ORIG_SEQ_NBR = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]);
						RAT_RMB_PAY_PROG = Reader["RAT_RMB_PAY_PROG"].ToString();
						RAT_RMB_PAYEE = Reader["RAT_RMB_PAYEE"].ToString();
						RAT_RMB_REFER_DOC_NBR = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]);
						RAT_RMB_FACILITY_NBR = Reader["RAT_RMB_FACILITY_NBR"].ToString();
						RAT_RMB_ADMIT_DATE = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]);
						RAT_RMB_LOC_CD = Reader["RAT_RMB_LOC_CD"].ToString();
						RAT_RMB_ERROR_H_CD_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString();
						RAT_RMB_ERROR_H_CD_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString();
						RAT_RMB_ERROR_H_CD_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString();
						RAT_RMB_ERROR_H_CD_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString();
						RAT_RMB_ERROR_H_CD_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString();
						RAT_RMB_REGISTRATION_NBR = Reader["RAT_RMB_REGISTRATION_NBR"].ToString();
						RAT_RMB_LAST_NAME = Reader["RAT_RMB_LAST_NAME"].ToString();
						RAT_RMB_FIRST_NAME = Reader["RAT_RMB_FIRST_NAME"].ToString();
						RAT_RMB_SEX = Reader["RAT_RMB_SEX"].ToString();
						RAT_RMB_PROV_CD = Reader["RAT_RMB_PROV_CD"].ToString();
						RAT_RMB_ERROR_R_CD_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString();
						RAT_RMB_ERROR_R_CD_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString();
						RAT_RMB_ERROR_R_CD_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString();
						RAT_RMB_ERROR_R_CD_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString();
						RAT_RMB_ERROR_R_CD_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString();
						RAT_RMB_SERVICE_CD = Reader["RAT_RMB_SERVICE_CD"].ToString();
						RAT_RMB_AMOUNT_SUB = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]);
						RAT_RMB_NBR_OF_SERV = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]);
						RAT_RMB_SERVICE_DATE = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]);
						RAT_RMB_DIAG_CD = Reader["RAT_RMB_DIAG_CD"].ToString();
						RAT_RMB_T_EXPLAN_CD = Reader["RAT_RMB_T_EXPLAN_CD"].ToString();
						RAT_RMB_ERROR_T_CD_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString();
						RAT_RMB_ERROR_T_CD_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString();
						RAT_RMB_ERROR_T_CD_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString();
						RAT_RMB_ERROR_T_CD_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString();
						RAT_RMB_ERROR_T_CD_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString();
						RAT_RMB_8_EXPLAN_CD = Reader["RAT_RMB_8_EXPLAN_CD"].ToString();
						RAT_RMB_8_EXPLAN_DESC = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString();
						RAT_RMB_FILE_NAME = Reader["RAT_RMB_FILE_NAME"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_rmb_moh_off_cd = Reader["RAT_RMB_MOH_OFF_CD"].ToString();
						_originalRat_rmb_group_nbr = Reader["RAT_RMB_GROUP_NBR"].ToString();
						_originalRat_rmb_doc_nbr = ConvertDEC(Reader["RAT_RMB_DOC_NBR"]);
						_originalRat_rmb_specialty_cd = ConvertDEC(Reader["RAT_RMB_SPECIALTY_CD"]);
						_originalRat_rmb_station_nbr = Reader["RAT_RMB_STATION_NBR"].ToString();
						_originalRat_rmb_process_date = ConvertDEC(Reader["RAT_RMB_PROCESS_DATE"]);
						_originalRat_rmb_health_nbr = Reader["RAT_RMB_HEALTH_NBR"].ToString();
						_originalRat_rmb_version_cd = Reader["RAT_RMB_VERSION_CD"].ToString();
						_originalRat_rmb_birth_date = ConvertDEC(Reader["RAT_RMB_BIRTH_DATE"]);
						_originalRat_rmb_account_nbr = Reader["RAT_RMB_ACCOUNT_NBR"].ToString();
						_originalRat_rmb_orig_seq_nbr = ConvertDEC(Reader["RAT_RMB_ORIG_SEQ_NBR"]);
						_originalRat_rmb_pay_prog = Reader["RAT_RMB_PAY_PROG"].ToString();
						_originalRat_rmb_payee = Reader["RAT_RMB_PAYEE"].ToString();
						_originalRat_rmb_refer_doc_nbr = ConvertDEC(Reader["RAT_RMB_REFER_DOC_NBR"]);
						_originalRat_rmb_facility_nbr = Reader["RAT_RMB_FACILITY_NBR"].ToString();
						_originalRat_rmb_admit_date = ConvertDEC(Reader["RAT_RMB_ADMIT_DATE"]);
						_originalRat_rmb_loc_cd = Reader["RAT_RMB_LOC_CD"].ToString();
						_originalRat_rmb_error_h_cd_1 = Reader["RAT_RMB_ERROR_H_CD_1"].ToString();
						_originalRat_rmb_error_h_cd_2 = Reader["RAT_RMB_ERROR_H_CD_2"].ToString();
						_originalRat_rmb_error_h_cd_3 = Reader["RAT_RMB_ERROR_H_CD_3"].ToString();
						_originalRat_rmb_error_h_cd_4 = Reader["RAT_RMB_ERROR_H_CD_4"].ToString();
						_originalRat_rmb_error_h_cd_5 = Reader["RAT_RMB_ERROR_H_CD_5"].ToString();
						_originalRat_rmb_registration_nbr = Reader["RAT_RMB_REGISTRATION_NBR"].ToString();
						_originalRat_rmb_last_name = Reader["RAT_RMB_LAST_NAME"].ToString();
						_originalRat_rmb_first_name = Reader["RAT_RMB_FIRST_NAME"].ToString();
						_originalRat_rmb_sex = Reader["RAT_RMB_SEX"].ToString();
						_originalRat_rmb_prov_cd = Reader["RAT_RMB_PROV_CD"].ToString();
						_originalRat_rmb_error_r_cd_1 = Reader["RAT_RMB_ERROR_R_CD_1"].ToString();
						_originalRat_rmb_error_r_cd_2 = Reader["RAT_RMB_ERROR_R_CD_2"].ToString();
						_originalRat_rmb_error_r_cd_3 = Reader["RAT_RMB_ERROR_R_CD_3"].ToString();
						_originalRat_rmb_error_r_cd_4 = Reader["RAT_RMB_ERROR_R_CD_4"].ToString();
						_originalRat_rmb_error_r_cd_5 = Reader["RAT_RMB_ERROR_R_CD_5"].ToString();
						_originalRat_rmb_service_cd = Reader["RAT_RMB_SERVICE_CD"].ToString();
						_originalRat_rmb_amount_sub = ConvertDEC(Reader["RAT_RMB_AMOUNT_SUB"]);
						_originalRat_rmb_nbr_of_serv = ConvertDEC(Reader["RAT_RMB_NBR_OF_SERV"]);
						_originalRat_rmb_service_date = ConvertDEC(Reader["RAT_RMB_SERVICE_DATE"]);
						_originalRat_rmb_diag_cd = Reader["RAT_RMB_DIAG_CD"].ToString();
						_originalRat_rmb_t_explan_cd = Reader["RAT_RMB_T_EXPLAN_CD"].ToString();
						_originalRat_rmb_error_t_cd_1 = Reader["RAT_RMB_ERROR_T_CD_1"].ToString();
						_originalRat_rmb_error_t_cd_2 = Reader["RAT_RMB_ERROR_T_CD_2"].ToString();
						_originalRat_rmb_error_t_cd_3 = Reader["RAT_RMB_ERROR_T_CD_3"].ToString();
						_originalRat_rmb_error_t_cd_4 = Reader["RAT_RMB_ERROR_T_CD_4"].ToString();
						_originalRat_rmb_error_t_cd_5 = Reader["RAT_RMB_ERROR_T_CD_5"].ToString();
						_originalRat_rmb_8_explan_cd = Reader["RAT_RMB_8_EXPLAN_CD"].ToString();
						_originalRat_rmb_8_explan_desc = Reader["RAT_RMB_8_EXPLAN_DESC"].ToString();
						_originalRat_rmb_file_name = Reader["RAT_RMB_FILE_NAME"].ToString();
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