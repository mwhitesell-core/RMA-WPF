using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class U030_TAPE_145_FILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<U030_TAPE_145_FILE> Collection( Guid? rowid,
															string rat_145_group_nbr,
															string rat_145_moh_off_cd,
															decimal? rat_145_data_seq_nbrmin,
															decimal? rat_145_data_seq_nbrmax,
															decimal? rat_145_payment_datemin,
															decimal? rat_145_payment_datemax,
															string rat_145_pay_last_name,
															string rat_145_pay_title,
															string rat_145_pay_initials,
															decimal? rat_145_tot_amt_paymin,
															decimal? rat_145_tot_amt_paymax,
															string rat_145_cheq_nbr,
															string rat_145_claim_nbr,
															decimal? rat_145_trans_typemin,
															decimal? rat_145_trans_typemax,
															decimal? rat_145_doc_nbrmin,
															decimal? rat_145_doc_nbrmax,
															decimal? rat_145_specialty_cdmin,
															decimal? rat_145_specialty_cdmax,
															string rat_145_account_nbr,
															string rat_145_last_name,
															string rat_145_first_name,
															string rat_145_prov_cd,
															string rat_145_health_ohip_nbr,
															string rat_145_version_cd,
															string rat_145_pay_prog,
															string rat_145_conv_health_nbr,
															decimal? rat_145_service_datemin,
															decimal? rat_145_service_datemax,
															decimal? rat_145_nbr_of_servmin,
															decimal? rat_145_nbr_of_servmax,
															string rat_145_service_cd,
															string rat_145_eligibility_ind,
															decimal? rat_145_amount_submin,
															decimal? rat_145_amount_submax,
															decimal? rat_145_amt_paidmin,
															decimal? rat_145_amt_paidmax,
															string rat_145_explan_cd,
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
					new SqlParameter("RAT_145_GROUP_NBR",rat_145_group_nbr),
					new SqlParameter("RAT_145_MOH_OFF_CD",rat_145_moh_off_cd),
					new SqlParameter("minRAT_145_DATA_SEQ_NBR",rat_145_data_seq_nbrmin),
					new SqlParameter("maxRAT_145_DATA_SEQ_NBR",rat_145_data_seq_nbrmax),
					new SqlParameter("minRAT_145_PAYMENT_DATE",rat_145_payment_datemin),
					new SqlParameter("maxRAT_145_PAYMENT_DATE",rat_145_payment_datemax),
					new SqlParameter("RAT_145_PAY_LAST_NAME",rat_145_pay_last_name),
					new SqlParameter("RAT_145_PAY_TITLE",rat_145_pay_title),
					new SqlParameter("RAT_145_PAY_INITIALS",rat_145_pay_initials),
					new SqlParameter("minRAT_145_TOT_AMT_PAY",rat_145_tot_amt_paymin),
					new SqlParameter("maxRAT_145_TOT_AMT_PAY",rat_145_tot_amt_paymax),
					new SqlParameter("RAT_145_CHEQ_NBR",rat_145_cheq_nbr),
					new SqlParameter("RAT_145_CLAIM_NBR",rat_145_claim_nbr),
					new SqlParameter("minRAT_145_TRANS_TYPE",rat_145_trans_typemin),
					new SqlParameter("maxRAT_145_TRANS_TYPE",rat_145_trans_typemax),
					new SqlParameter("minRAT_145_DOC_NBR",rat_145_doc_nbrmin),
					new SqlParameter("maxRAT_145_DOC_NBR",rat_145_doc_nbrmax),
					new SqlParameter("minRAT_145_SPECIALTY_CD",rat_145_specialty_cdmin),
					new SqlParameter("maxRAT_145_SPECIALTY_CD",rat_145_specialty_cdmax),
					new SqlParameter("RAT_145_ACCOUNT_NBR",rat_145_account_nbr),
					new SqlParameter("RAT_145_LAST_NAME",rat_145_last_name),
					new SqlParameter("RAT_145_FIRST_NAME",rat_145_first_name),
					new SqlParameter("RAT_145_PROV_CD",rat_145_prov_cd),
					new SqlParameter("RAT_145_HEALTH_OHIP_NBR",rat_145_health_ohip_nbr),
					new SqlParameter("RAT_145_VERSION_CD",rat_145_version_cd),
					new SqlParameter("RAT_145_PAY_PROG",rat_145_pay_prog),
					new SqlParameter("RAT_145_CONV_HEALTH_NBR",rat_145_conv_health_nbr),
					new SqlParameter("minRAT_145_SERVICE_DATE",rat_145_service_datemin),
					new SqlParameter("maxRAT_145_SERVICE_DATE",rat_145_service_datemax),
					new SqlParameter("minRAT_145_NBR_OF_SERV",rat_145_nbr_of_servmin),
					new SqlParameter("maxRAT_145_NBR_OF_SERV",rat_145_nbr_of_servmax),
					new SqlParameter("RAT_145_SERVICE_CD",rat_145_service_cd),
					new SqlParameter("RAT_145_ELIGIBILITY_IND",rat_145_eligibility_ind),
					new SqlParameter("minRAT_145_AMOUNT_SUB",rat_145_amount_submin),
					new SqlParameter("maxRAT_145_AMOUNT_SUB",rat_145_amount_submax),
					new SqlParameter("minRAT_145_AMT_PAID",rat_145_amt_paidmin),
					new SqlParameter("maxRAT_145_AMT_PAID",rat_145_amt_paidmax),
					new SqlParameter("RAT_145_EXPLAN_CD",rat_145_explan_cd),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<U030_TAPE_145_FILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Search]", parameters);
            var collection = new ObservableCollection<U030_TAPE_145_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U030_TAPE_145_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_145_GROUP_NBR = Reader["RAT_145_GROUP_NBR"].ToString(),
					RAT_145_MOH_OFF_CD = Reader["RAT_145_MOH_OFF_CD"].ToString(),
					RAT_145_DATA_SEQ_NBR = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]),
					RAT_145_PAYMENT_DATE = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]),
					RAT_145_PAY_LAST_NAME = Reader["RAT_145_PAY_LAST_NAME"].ToString(),
					RAT_145_PAY_TITLE = Reader["RAT_145_PAY_TITLE"].ToString(),
					RAT_145_PAY_INITIALS = Reader["RAT_145_PAY_INITIALS"].ToString(),
					RAT_145_TOT_AMT_PAY = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]),
					RAT_145_CHEQ_NBR = Reader["RAT_145_CHEQ_NBR"].ToString(),
					RAT_145_CLAIM_NBR = Reader["RAT_145_CLAIM_NBR"].ToString(),
					RAT_145_TRANS_TYPE = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]),
					RAT_145_DOC_NBR = ConvertDEC(Reader["RAT_145_DOC_NBR"]),
					RAT_145_SPECIALTY_CD = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]),
					RAT_145_ACCOUNT_NBR = Reader["RAT_145_ACCOUNT_NBR"].ToString(),
					RAT_145_LAST_NAME = Reader["RAT_145_LAST_NAME"].ToString(),
					RAT_145_FIRST_NAME = Reader["RAT_145_FIRST_NAME"].ToString(),
					RAT_145_PROV_CD = Reader["RAT_145_PROV_CD"].ToString(),
					RAT_145_HEALTH_OHIP_NBR = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString(),
					RAT_145_VERSION_CD = Reader["RAT_145_VERSION_CD"].ToString(),
					RAT_145_PAY_PROG = Reader["RAT_145_PAY_PROG"].ToString(),
					RAT_145_CONV_HEALTH_NBR = Reader["RAT_145_CONV_HEALTH_NBR"].ToString(),
					RAT_145_SERVICE_DATE = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]),
					RAT_145_NBR_OF_SERV = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]),
					RAT_145_SERVICE_CD = Reader["RAT_145_SERVICE_CD"].ToString(),
					RAT_145_ELIGIBILITY_IND = Reader["RAT_145_ELIGIBILITY_IND"].ToString(),
					RAT_145_AMOUNT_SUB = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]),
					RAT_145_AMT_PAID = ConvertDEC(Reader["RAT_145_AMT_PAID"]),
					RAT_145_EXPLAN_CD = Reader["RAT_145_EXPLAN_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_145_group_nbr = Reader["RAT_145_GROUP_NBR"].ToString(),
					_originalRat_145_moh_off_cd = Reader["RAT_145_MOH_OFF_CD"].ToString(),
					_originalRat_145_data_seq_nbr = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]),
					_originalRat_145_payment_date = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]),
					_originalRat_145_pay_last_name = Reader["RAT_145_PAY_LAST_NAME"].ToString(),
					_originalRat_145_pay_title = Reader["RAT_145_PAY_TITLE"].ToString(),
					_originalRat_145_pay_initials = Reader["RAT_145_PAY_INITIALS"].ToString(),
					_originalRat_145_tot_amt_pay = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]),
					_originalRat_145_cheq_nbr = Reader["RAT_145_CHEQ_NBR"].ToString(),
					_originalRat_145_claim_nbr = Reader["RAT_145_CLAIM_NBR"].ToString(),
					_originalRat_145_trans_type = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]),
					_originalRat_145_doc_nbr = ConvertDEC(Reader["RAT_145_DOC_NBR"]),
					_originalRat_145_specialty_cd = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]),
					_originalRat_145_account_nbr = Reader["RAT_145_ACCOUNT_NBR"].ToString(),
					_originalRat_145_last_name = Reader["RAT_145_LAST_NAME"].ToString(),
					_originalRat_145_first_name = Reader["RAT_145_FIRST_NAME"].ToString(),
					_originalRat_145_prov_cd = Reader["RAT_145_PROV_CD"].ToString(),
					_originalRat_145_health_ohip_nbr = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString(),
					_originalRat_145_version_cd = Reader["RAT_145_VERSION_CD"].ToString(),
					_originalRat_145_pay_prog = Reader["RAT_145_PAY_PROG"].ToString(),
					_originalRat_145_conv_health_nbr = Reader["RAT_145_CONV_HEALTH_NBR"].ToString(),
					_originalRat_145_service_date = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]),
					_originalRat_145_nbr_of_serv = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]),
					_originalRat_145_service_cd = Reader["RAT_145_SERVICE_CD"].ToString(),
					_originalRat_145_eligibility_ind = Reader["RAT_145_ELIGIBILITY_IND"].ToString(),
					_originalRat_145_amount_sub = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]),
					_originalRat_145_amt_paid = ConvertDEC(Reader["RAT_145_AMT_PAID"]),
					_originalRat_145_explan_cd = Reader["RAT_145_EXPLAN_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public U030_TAPE_145_FILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<U030_TAPE_145_FILE> Collection(ObservableCollection<U030_TAPE_145_FILE>
                                                               u030Tape145File = null)
        {
            if (IsSameSearch() && u030Tape145File != null)
            {
                return u030Tape145File;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<U030_TAPE_145_FILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("RAT_145_GROUP_NBR",WhereRat_145_group_nbr),
					new SqlParameter("RAT_145_MOH_OFF_CD",WhereRat_145_moh_off_cd),
					new SqlParameter("RAT_145_DATA_SEQ_NBR",WhereRat_145_data_seq_nbr),
					new SqlParameter("RAT_145_PAYMENT_DATE",WhereRat_145_payment_date),
					new SqlParameter("RAT_145_PAY_LAST_NAME",WhereRat_145_pay_last_name),
					new SqlParameter("RAT_145_PAY_TITLE",WhereRat_145_pay_title),
					new SqlParameter("RAT_145_PAY_INITIALS",WhereRat_145_pay_initials),
					new SqlParameter("RAT_145_TOT_AMT_PAY",WhereRat_145_tot_amt_pay),
					new SqlParameter("RAT_145_CHEQ_NBR",WhereRat_145_cheq_nbr),
					new SqlParameter("RAT_145_CLAIM_NBR",WhereRat_145_claim_nbr),
					new SqlParameter("RAT_145_TRANS_TYPE",WhereRat_145_trans_type),
					new SqlParameter("RAT_145_DOC_NBR",WhereRat_145_doc_nbr),
					new SqlParameter("RAT_145_SPECIALTY_CD",WhereRat_145_specialty_cd),
					new SqlParameter("RAT_145_ACCOUNT_NBR",WhereRat_145_account_nbr),
					new SqlParameter("RAT_145_LAST_NAME",WhereRat_145_last_name),
					new SqlParameter("RAT_145_FIRST_NAME",WhereRat_145_first_name),
					new SqlParameter("RAT_145_PROV_CD",WhereRat_145_prov_cd),
					new SqlParameter("RAT_145_HEALTH_OHIP_NBR",WhereRat_145_health_ohip_nbr),
					new SqlParameter("RAT_145_VERSION_CD",WhereRat_145_version_cd),
					new SqlParameter("RAT_145_PAY_PROG",WhereRat_145_pay_prog),
					new SqlParameter("RAT_145_CONV_HEALTH_NBR",WhereRat_145_conv_health_nbr),
					new SqlParameter("RAT_145_SERVICE_DATE",WhereRat_145_service_date),
					new SqlParameter("RAT_145_NBR_OF_SERV",WhereRat_145_nbr_of_serv),
					new SqlParameter("RAT_145_SERVICE_CD",WhereRat_145_service_cd),
					new SqlParameter("RAT_145_ELIGIBILITY_IND",WhereRat_145_eligibility_ind),
					new SqlParameter("RAT_145_AMOUNT_SUB",WhereRat_145_amount_sub),
					new SqlParameter("RAT_145_AMT_PAID",WhereRat_145_amt_paid),
					new SqlParameter("RAT_145_EXPLAN_CD",WhereRat_145_explan_cd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Match]", parameters);
            var collection = new ObservableCollection<U030_TAPE_145_FILE>();

            while (Reader.Read())
            {
                collection.Add(new U030_TAPE_145_FILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					RAT_145_GROUP_NBR = Reader["RAT_145_GROUP_NBR"].ToString(),
					RAT_145_MOH_OFF_CD = Reader["RAT_145_MOH_OFF_CD"].ToString(),
					RAT_145_DATA_SEQ_NBR = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]),
					RAT_145_PAYMENT_DATE = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]),
					RAT_145_PAY_LAST_NAME = Reader["RAT_145_PAY_LAST_NAME"].ToString(),
					RAT_145_PAY_TITLE = Reader["RAT_145_PAY_TITLE"].ToString(),
					RAT_145_PAY_INITIALS = Reader["RAT_145_PAY_INITIALS"].ToString(),
					RAT_145_TOT_AMT_PAY = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]),
					RAT_145_CHEQ_NBR = Reader["RAT_145_CHEQ_NBR"].ToString(),
					RAT_145_CLAIM_NBR = Reader["RAT_145_CLAIM_NBR"].ToString(),
					RAT_145_TRANS_TYPE = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]),
					RAT_145_DOC_NBR = ConvertDEC(Reader["RAT_145_DOC_NBR"]),
					RAT_145_SPECIALTY_CD = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]),
					RAT_145_ACCOUNT_NBR = Reader["RAT_145_ACCOUNT_NBR"].ToString(),
					RAT_145_LAST_NAME = Reader["RAT_145_LAST_NAME"].ToString(),
					RAT_145_FIRST_NAME = Reader["RAT_145_FIRST_NAME"].ToString(),
					RAT_145_PROV_CD = Reader["RAT_145_PROV_CD"].ToString(),
					RAT_145_HEALTH_OHIP_NBR = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString(),
					RAT_145_VERSION_CD = Reader["RAT_145_VERSION_CD"].ToString(),
					RAT_145_PAY_PROG = Reader["RAT_145_PAY_PROG"].ToString(),
					RAT_145_CONV_HEALTH_NBR = Reader["RAT_145_CONV_HEALTH_NBR"].ToString(),
					RAT_145_SERVICE_DATE = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]),
					RAT_145_NBR_OF_SERV = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]),
					RAT_145_SERVICE_CD = Reader["RAT_145_SERVICE_CD"].ToString(),
					RAT_145_ELIGIBILITY_IND = Reader["RAT_145_ELIGIBILITY_IND"].ToString(),
					RAT_145_AMOUNT_SUB = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]),
					RAT_145_AMT_PAID = ConvertDEC(Reader["RAT_145_AMT_PAID"]),
					RAT_145_EXPLAN_CD = Reader["RAT_145_EXPLAN_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereRat_145_group_nbr = WhereRat_145_group_nbr,
					_whereRat_145_moh_off_cd = WhereRat_145_moh_off_cd,
					_whereRat_145_data_seq_nbr = WhereRat_145_data_seq_nbr,
					_whereRat_145_payment_date = WhereRat_145_payment_date,
					_whereRat_145_pay_last_name = WhereRat_145_pay_last_name,
					_whereRat_145_pay_title = WhereRat_145_pay_title,
					_whereRat_145_pay_initials = WhereRat_145_pay_initials,
					_whereRat_145_tot_amt_pay = WhereRat_145_tot_amt_pay,
					_whereRat_145_cheq_nbr = WhereRat_145_cheq_nbr,
					_whereRat_145_claim_nbr = WhereRat_145_claim_nbr,
					_whereRat_145_trans_type = WhereRat_145_trans_type,
					_whereRat_145_doc_nbr = WhereRat_145_doc_nbr,
					_whereRat_145_specialty_cd = WhereRat_145_specialty_cd,
					_whereRat_145_account_nbr = WhereRat_145_account_nbr,
					_whereRat_145_last_name = WhereRat_145_last_name,
					_whereRat_145_first_name = WhereRat_145_first_name,
					_whereRat_145_prov_cd = WhereRat_145_prov_cd,
					_whereRat_145_health_ohip_nbr = WhereRat_145_health_ohip_nbr,
					_whereRat_145_version_cd = WhereRat_145_version_cd,
					_whereRat_145_pay_prog = WhereRat_145_pay_prog,
					_whereRat_145_conv_health_nbr = WhereRat_145_conv_health_nbr,
					_whereRat_145_service_date = WhereRat_145_service_date,
					_whereRat_145_nbr_of_serv = WhereRat_145_nbr_of_serv,
					_whereRat_145_service_cd = WhereRat_145_service_cd,
					_whereRat_145_eligibility_ind = WhereRat_145_eligibility_ind,
					_whereRat_145_amount_sub = WhereRat_145_amount_sub,
					_whereRat_145_amt_paid = WhereRat_145_amt_paid,
					_whereRat_145_explan_cd = WhereRat_145_explan_cd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalRat_145_group_nbr = Reader["RAT_145_GROUP_NBR"].ToString(),
					_originalRat_145_moh_off_cd = Reader["RAT_145_MOH_OFF_CD"].ToString(),
					_originalRat_145_data_seq_nbr = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]),
					_originalRat_145_payment_date = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]),
					_originalRat_145_pay_last_name = Reader["RAT_145_PAY_LAST_NAME"].ToString(),
					_originalRat_145_pay_title = Reader["RAT_145_PAY_TITLE"].ToString(),
					_originalRat_145_pay_initials = Reader["RAT_145_PAY_INITIALS"].ToString(),
					_originalRat_145_tot_amt_pay = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]),
					_originalRat_145_cheq_nbr = Reader["RAT_145_CHEQ_NBR"].ToString(),
					_originalRat_145_claim_nbr = Reader["RAT_145_CLAIM_NBR"].ToString(),
					_originalRat_145_trans_type = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]),
					_originalRat_145_doc_nbr = ConvertDEC(Reader["RAT_145_DOC_NBR"]),
					_originalRat_145_specialty_cd = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]),
					_originalRat_145_account_nbr = Reader["RAT_145_ACCOUNT_NBR"].ToString(),
					_originalRat_145_last_name = Reader["RAT_145_LAST_NAME"].ToString(),
					_originalRat_145_first_name = Reader["RAT_145_FIRST_NAME"].ToString(),
					_originalRat_145_prov_cd = Reader["RAT_145_PROV_CD"].ToString(),
					_originalRat_145_health_ohip_nbr = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString(),
					_originalRat_145_version_cd = Reader["RAT_145_VERSION_CD"].ToString(),
					_originalRat_145_pay_prog = Reader["RAT_145_PAY_PROG"].ToString(),
					_originalRat_145_conv_health_nbr = Reader["RAT_145_CONV_HEALTH_NBR"].ToString(),
					_originalRat_145_service_date = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]),
					_originalRat_145_nbr_of_serv = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]),
					_originalRat_145_service_cd = Reader["RAT_145_SERVICE_CD"].ToString(),
					_originalRat_145_eligibility_ind = Reader["RAT_145_ELIGIBILITY_IND"].ToString(),
					_originalRat_145_amount_sub = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]),
					_originalRat_145_amt_paid = ConvertDEC(Reader["RAT_145_AMT_PAID"]),
					_originalRat_145_explan_cd = Reader["RAT_145_EXPLAN_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereRat_145_group_nbr = WhereRat_145_group_nbr;
					_whereRat_145_moh_off_cd = WhereRat_145_moh_off_cd;
					_whereRat_145_data_seq_nbr = WhereRat_145_data_seq_nbr;
					_whereRat_145_payment_date = WhereRat_145_payment_date;
					_whereRat_145_pay_last_name = WhereRat_145_pay_last_name;
					_whereRat_145_pay_title = WhereRat_145_pay_title;
					_whereRat_145_pay_initials = WhereRat_145_pay_initials;
					_whereRat_145_tot_amt_pay = WhereRat_145_tot_amt_pay;
					_whereRat_145_cheq_nbr = WhereRat_145_cheq_nbr;
					_whereRat_145_claim_nbr = WhereRat_145_claim_nbr;
					_whereRat_145_trans_type = WhereRat_145_trans_type;
					_whereRat_145_doc_nbr = WhereRat_145_doc_nbr;
					_whereRat_145_specialty_cd = WhereRat_145_specialty_cd;
					_whereRat_145_account_nbr = WhereRat_145_account_nbr;
					_whereRat_145_last_name = WhereRat_145_last_name;
					_whereRat_145_first_name = WhereRat_145_first_name;
					_whereRat_145_prov_cd = WhereRat_145_prov_cd;
					_whereRat_145_health_ohip_nbr = WhereRat_145_health_ohip_nbr;
					_whereRat_145_version_cd = WhereRat_145_version_cd;
					_whereRat_145_pay_prog = WhereRat_145_pay_prog;
					_whereRat_145_conv_health_nbr = WhereRat_145_conv_health_nbr;
					_whereRat_145_service_date = WhereRat_145_service_date;
					_whereRat_145_nbr_of_serv = WhereRat_145_nbr_of_serv;
					_whereRat_145_service_cd = WhereRat_145_service_cd;
					_whereRat_145_eligibility_ind = WhereRat_145_eligibility_ind;
					_whereRat_145_amount_sub = WhereRat_145_amount_sub;
					_whereRat_145_amt_paid = WhereRat_145_amt_paid;
					_whereRat_145_explan_cd = WhereRat_145_explan_cd;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereRat_145_group_nbr == null 
				&& WhereRat_145_moh_off_cd == null 
				&& WhereRat_145_data_seq_nbr == null 
				&& WhereRat_145_payment_date == null 
				&& WhereRat_145_pay_last_name == null 
				&& WhereRat_145_pay_title == null 
				&& WhereRat_145_pay_initials == null 
				&& WhereRat_145_tot_amt_pay == null 
				&& WhereRat_145_cheq_nbr == null 
				&& WhereRat_145_claim_nbr == null 
				&& WhereRat_145_trans_type == null 
				&& WhereRat_145_doc_nbr == null 
				&& WhereRat_145_specialty_cd == null 
				&& WhereRat_145_account_nbr == null 
				&& WhereRat_145_last_name == null 
				&& WhereRat_145_first_name == null 
				&& WhereRat_145_prov_cd == null 
				&& WhereRat_145_health_ohip_nbr == null 
				&& WhereRat_145_version_cd == null 
				&& WhereRat_145_pay_prog == null 
				&& WhereRat_145_conv_health_nbr == null 
				&& WhereRat_145_service_date == null 
				&& WhereRat_145_nbr_of_serv == null 
				&& WhereRat_145_service_cd == null 
				&& WhereRat_145_eligibility_ind == null 
				&& WhereRat_145_amount_sub == null 
				&& WhereRat_145_amt_paid == null 
				&& WhereRat_145_explan_cd == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereRat_145_group_nbr ==  _whereRat_145_group_nbr
				&& WhereRat_145_moh_off_cd ==  _whereRat_145_moh_off_cd
				&& WhereRat_145_data_seq_nbr ==  _whereRat_145_data_seq_nbr
				&& WhereRat_145_payment_date ==  _whereRat_145_payment_date
				&& WhereRat_145_pay_last_name ==  _whereRat_145_pay_last_name
				&& WhereRat_145_pay_title ==  _whereRat_145_pay_title
				&& WhereRat_145_pay_initials ==  _whereRat_145_pay_initials
				&& WhereRat_145_tot_amt_pay ==  _whereRat_145_tot_amt_pay
				&& WhereRat_145_cheq_nbr ==  _whereRat_145_cheq_nbr
				&& WhereRat_145_claim_nbr ==  _whereRat_145_claim_nbr
				&& WhereRat_145_trans_type ==  _whereRat_145_trans_type
				&& WhereRat_145_doc_nbr ==  _whereRat_145_doc_nbr
				&& WhereRat_145_specialty_cd ==  _whereRat_145_specialty_cd
				&& WhereRat_145_account_nbr ==  _whereRat_145_account_nbr
				&& WhereRat_145_last_name ==  _whereRat_145_last_name
				&& WhereRat_145_first_name ==  _whereRat_145_first_name
				&& WhereRat_145_prov_cd ==  _whereRat_145_prov_cd
				&& WhereRat_145_health_ohip_nbr ==  _whereRat_145_health_ohip_nbr
				&& WhereRat_145_version_cd ==  _whereRat_145_version_cd
				&& WhereRat_145_pay_prog ==  _whereRat_145_pay_prog
				&& WhereRat_145_conv_health_nbr ==  _whereRat_145_conv_health_nbr
				&& WhereRat_145_service_date ==  _whereRat_145_service_date
				&& WhereRat_145_nbr_of_serv ==  _whereRat_145_nbr_of_serv
				&& WhereRat_145_service_cd ==  _whereRat_145_service_cd
				&& WhereRat_145_eligibility_ind ==  _whereRat_145_eligibility_ind
				&& WhereRat_145_amount_sub ==  _whereRat_145_amount_sub
				&& WhereRat_145_amt_paid ==  _whereRat_145_amt_paid
				&& WhereRat_145_explan_cd ==  _whereRat_145_explan_cd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereRat_145_group_nbr = null; 
			WhereRat_145_moh_off_cd = null; 
			WhereRat_145_data_seq_nbr = null; 
			WhereRat_145_payment_date = null; 
			WhereRat_145_pay_last_name = null; 
			WhereRat_145_pay_title = null; 
			WhereRat_145_pay_initials = null; 
			WhereRat_145_tot_amt_pay = null; 
			WhereRat_145_cheq_nbr = null; 
			WhereRat_145_claim_nbr = null; 
			WhereRat_145_trans_type = null; 
			WhereRat_145_doc_nbr = null; 
			WhereRat_145_specialty_cd = null; 
			WhereRat_145_account_nbr = null; 
			WhereRat_145_last_name = null; 
			WhereRat_145_first_name = null; 
			WhereRat_145_prov_cd = null; 
			WhereRat_145_health_ohip_nbr = null; 
			WhereRat_145_version_cd = null; 
			WhereRat_145_pay_prog = null; 
			WhereRat_145_conv_health_nbr = null; 
			WhereRat_145_service_date = null; 
			WhereRat_145_nbr_of_serv = null; 
			WhereRat_145_service_cd = null; 
			WhereRat_145_eligibility_ind = null; 
			WhereRat_145_amount_sub = null; 
			WhereRat_145_amt_paid = null; 
			WhereRat_145_explan_cd = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _RAT_145_GROUP_NBR;
		private string _RAT_145_MOH_OFF_CD;
		private decimal? _RAT_145_DATA_SEQ_NBR;
		private decimal? _RAT_145_PAYMENT_DATE;
		private string _RAT_145_PAY_LAST_NAME;
		private string _RAT_145_PAY_TITLE;
		private string _RAT_145_PAY_INITIALS;
		private decimal? _RAT_145_TOT_AMT_PAY;
		private string _RAT_145_CHEQ_NBR;
		private string _RAT_145_CLAIM_NBR;
		private decimal? _RAT_145_TRANS_TYPE;
		private decimal? _RAT_145_DOC_NBR;
		private decimal? _RAT_145_SPECIALTY_CD;
		private string _RAT_145_ACCOUNT_NBR;
		private string _RAT_145_LAST_NAME;
		private string _RAT_145_FIRST_NAME;
		private string _RAT_145_PROV_CD;
		private string _RAT_145_HEALTH_OHIP_NBR;
		private string _RAT_145_VERSION_CD;
		private string _RAT_145_PAY_PROG;
		private string _RAT_145_CONV_HEALTH_NBR;
		private decimal? _RAT_145_SERVICE_DATE;
		private decimal? _RAT_145_NBR_OF_SERV;
		private string _RAT_145_SERVICE_CD;
		private string _RAT_145_ELIGIBILITY_IND;
		private decimal? _RAT_145_AMOUNT_SUB;
		private decimal? _RAT_145_AMT_PAID;
		private string _RAT_145_EXPLAN_CD;
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
		public string RAT_145_GROUP_NBR
		{
			get { return _RAT_145_GROUP_NBR; }
			set
			{
				if (_RAT_145_GROUP_NBR != value)
				{
					_RAT_145_GROUP_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_MOH_OFF_CD
		{
			get { return _RAT_145_MOH_OFF_CD; }
			set
			{
				if (_RAT_145_MOH_OFF_CD != value)
				{
					_RAT_145_MOH_OFF_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_DATA_SEQ_NBR
		{
			get { return _RAT_145_DATA_SEQ_NBR; }
			set
			{
				if (_RAT_145_DATA_SEQ_NBR != value)
				{
					_RAT_145_DATA_SEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_PAYMENT_DATE
		{
			get { return _RAT_145_PAYMENT_DATE; }
			set
			{
				if (_RAT_145_PAYMENT_DATE != value)
				{
					_RAT_145_PAYMENT_DATE = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_PAY_LAST_NAME
		{
			get { return _RAT_145_PAY_LAST_NAME; }
			set
			{
				if (_RAT_145_PAY_LAST_NAME != value)
				{
					_RAT_145_PAY_LAST_NAME = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_PAY_TITLE
		{
			get { return _RAT_145_PAY_TITLE; }
			set
			{
				if (_RAT_145_PAY_TITLE != value)
				{
					_RAT_145_PAY_TITLE = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_PAY_INITIALS
		{
			get { return _RAT_145_PAY_INITIALS; }
			set
			{
				if (_RAT_145_PAY_INITIALS != value)
				{
					_RAT_145_PAY_INITIALS = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_TOT_AMT_PAY
		{
			get { return _RAT_145_TOT_AMT_PAY; }
			set
			{
				if (_RAT_145_TOT_AMT_PAY != value)
				{
					_RAT_145_TOT_AMT_PAY = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_CHEQ_NBR
		{
			get { return _RAT_145_CHEQ_NBR; }
			set
			{
				if (_RAT_145_CHEQ_NBR != value)
				{
					_RAT_145_CHEQ_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_CLAIM_NBR
		{
			get { return _RAT_145_CLAIM_NBR; }
			set
			{
				if (_RAT_145_CLAIM_NBR != value)
				{
					_RAT_145_CLAIM_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_TRANS_TYPE
		{
			get { return _RAT_145_TRANS_TYPE; }
			set
			{
				if (_RAT_145_TRANS_TYPE != value)
				{
					_RAT_145_TRANS_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_DOC_NBR
		{
			get { return _RAT_145_DOC_NBR; }
			set
			{
				if (_RAT_145_DOC_NBR != value)
				{
					_RAT_145_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_SPECIALTY_CD
		{
			get { return _RAT_145_SPECIALTY_CD; }
			set
			{
				if (_RAT_145_SPECIALTY_CD != value)
				{
					_RAT_145_SPECIALTY_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_ACCOUNT_NBR
		{
			get { return _RAT_145_ACCOUNT_NBR; }
			set
			{
				if (_RAT_145_ACCOUNT_NBR != value)
				{
					_RAT_145_ACCOUNT_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_LAST_NAME
		{
			get { return _RAT_145_LAST_NAME; }
			set
			{
				if (_RAT_145_LAST_NAME != value)
				{
					_RAT_145_LAST_NAME = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_FIRST_NAME
		{
			get { return _RAT_145_FIRST_NAME; }
			set
			{
				if (_RAT_145_FIRST_NAME != value)
				{
					_RAT_145_FIRST_NAME = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_PROV_CD
		{
			get { return _RAT_145_PROV_CD; }
			set
			{
				if (_RAT_145_PROV_CD != value)
				{
					_RAT_145_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_HEALTH_OHIP_NBR
		{
			get { return _RAT_145_HEALTH_OHIP_NBR; }
			set
			{
				if (_RAT_145_HEALTH_OHIP_NBR != value)
				{
					_RAT_145_HEALTH_OHIP_NBR = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_VERSION_CD
		{
			get { return _RAT_145_VERSION_CD; }
			set
			{
				if (_RAT_145_VERSION_CD != value)
				{
					_RAT_145_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_PAY_PROG
		{
			get { return _RAT_145_PAY_PROG; }
			set
			{
				if (_RAT_145_PAY_PROG != value)
				{
					_RAT_145_PAY_PROG = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_CONV_HEALTH_NBR
		{
			get { return _RAT_145_CONV_HEALTH_NBR; }
			set
			{
				if (_RAT_145_CONV_HEALTH_NBR != value)
				{
					_RAT_145_CONV_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_SERVICE_DATE
		{
			get { return _RAT_145_SERVICE_DATE; }
			set
			{
				if (_RAT_145_SERVICE_DATE != value)
				{
					_RAT_145_SERVICE_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_NBR_OF_SERV
		{
			get { return _RAT_145_NBR_OF_SERV; }
			set
			{
				if (_RAT_145_NBR_OF_SERV != value)
				{
					_RAT_145_NBR_OF_SERV = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_SERVICE_CD
		{
			get { return _RAT_145_SERVICE_CD; }
			set
			{
				if (_RAT_145_SERVICE_CD != value)
				{
					_RAT_145_SERVICE_CD = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_ELIGIBILITY_IND
		{
			get { return _RAT_145_ELIGIBILITY_IND; }
			set
			{
				if (_RAT_145_ELIGIBILITY_IND != value)
				{
					_RAT_145_ELIGIBILITY_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_AMOUNT_SUB
		{
			get { return _RAT_145_AMOUNT_SUB; }
			set
			{
				if (_RAT_145_AMOUNT_SUB != value)
				{
					_RAT_145_AMOUNT_SUB = value;
					ChangeState();
				}
			}
		}
		public decimal? RAT_145_AMT_PAID
		{
			get { return _RAT_145_AMT_PAID; }
			set
			{
				if (_RAT_145_AMT_PAID != value)
				{
					_RAT_145_AMT_PAID = value;
					ChangeState();
				}
			}
		}
		public string RAT_145_EXPLAN_CD
		{
			get { return _RAT_145_EXPLAN_CD; }
			set
			{
				if (_RAT_145_EXPLAN_CD != value)
				{
					_RAT_145_EXPLAN_CD = value;
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
		public string WhereRat_145_group_nbr { get; set; }
		private string _whereRat_145_group_nbr;
		public string WhereRat_145_moh_off_cd { get; set; }
		private string _whereRat_145_moh_off_cd;
		public decimal? WhereRat_145_data_seq_nbr { get; set; }
		private decimal? _whereRat_145_data_seq_nbr;
		public decimal? WhereRat_145_payment_date { get; set; }
		private decimal? _whereRat_145_payment_date;
		public string WhereRat_145_pay_last_name { get; set; }
		private string _whereRat_145_pay_last_name;
		public string WhereRat_145_pay_title { get; set; }
		private string _whereRat_145_pay_title;
		public string WhereRat_145_pay_initials { get; set; }
		private string _whereRat_145_pay_initials;
		public decimal? WhereRat_145_tot_amt_pay { get; set; }
		private decimal? _whereRat_145_tot_amt_pay;
		public string WhereRat_145_cheq_nbr { get; set; }
		private string _whereRat_145_cheq_nbr;
		public string WhereRat_145_claim_nbr { get; set; }
		private string _whereRat_145_claim_nbr;
		public decimal? WhereRat_145_trans_type { get; set; }
		private decimal? _whereRat_145_trans_type;
		public decimal? WhereRat_145_doc_nbr { get; set; }
		private decimal? _whereRat_145_doc_nbr;
		public decimal? WhereRat_145_specialty_cd { get; set; }
		private decimal? _whereRat_145_specialty_cd;
		public string WhereRat_145_account_nbr { get; set; }
		private string _whereRat_145_account_nbr;
		public string WhereRat_145_last_name { get; set; }
		private string _whereRat_145_last_name;
		public string WhereRat_145_first_name { get; set; }
		private string _whereRat_145_first_name;
		public string WhereRat_145_prov_cd { get; set; }
		private string _whereRat_145_prov_cd;
		public string WhereRat_145_health_ohip_nbr { get; set; }
		private string _whereRat_145_health_ohip_nbr;
		public string WhereRat_145_version_cd { get; set; }
		private string _whereRat_145_version_cd;
		public string WhereRat_145_pay_prog { get; set; }
		private string _whereRat_145_pay_prog;
		public string WhereRat_145_conv_health_nbr { get; set; }
		private string _whereRat_145_conv_health_nbr;
		public decimal? WhereRat_145_service_date { get; set; }
		private decimal? _whereRat_145_service_date;
		public decimal? WhereRat_145_nbr_of_serv { get; set; }
		private decimal? _whereRat_145_nbr_of_serv;
		public string WhereRat_145_service_cd { get; set; }
		private string _whereRat_145_service_cd;
		public string WhereRat_145_eligibility_ind { get; set; }
		private string _whereRat_145_eligibility_ind;
		public decimal? WhereRat_145_amount_sub { get; set; }
		private decimal? _whereRat_145_amount_sub;
		public decimal? WhereRat_145_amt_paid { get; set; }
		private decimal? _whereRat_145_amt_paid;
		public string WhereRat_145_explan_cd { get; set; }
		private string _whereRat_145_explan_cd;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalRat_145_group_nbr;
		private string _originalRat_145_moh_off_cd;
		private decimal? _originalRat_145_data_seq_nbr;
		private decimal? _originalRat_145_payment_date;
		private string _originalRat_145_pay_last_name;
		private string _originalRat_145_pay_title;
		private string _originalRat_145_pay_initials;
		private decimal? _originalRat_145_tot_amt_pay;
		private string _originalRat_145_cheq_nbr;
		private string _originalRat_145_claim_nbr;
		private decimal? _originalRat_145_trans_type;
		private decimal? _originalRat_145_doc_nbr;
		private decimal? _originalRat_145_specialty_cd;
		private string _originalRat_145_account_nbr;
		private string _originalRat_145_last_name;
		private string _originalRat_145_first_name;
		private string _originalRat_145_prov_cd;
		private string _originalRat_145_health_ohip_nbr;
		private string _originalRat_145_version_cd;
		private string _originalRat_145_pay_prog;
		private string _originalRat_145_conv_health_nbr;
		private decimal? _originalRat_145_service_date;
		private decimal? _originalRat_145_nbr_of_serv;
		private string _originalRat_145_service_cd;
		private string _originalRat_145_eligibility_ind;
		private decimal? _originalRat_145_amount_sub;
		private decimal? _originalRat_145_amt_paid;
		private string _originalRat_145_explan_cd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			RAT_145_GROUP_NBR = _originalRat_145_group_nbr;
			RAT_145_MOH_OFF_CD = _originalRat_145_moh_off_cd;
			RAT_145_DATA_SEQ_NBR = _originalRat_145_data_seq_nbr;
			RAT_145_PAYMENT_DATE = _originalRat_145_payment_date;
			RAT_145_PAY_LAST_NAME = _originalRat_145_pay_last_name;
			RAT_145_PAY_TITLE = _originalRat_145_pay_title;
			RAT_145_PAY_INITIALS = _originalRat_145_pay_initials;
			RAT_145_TOT_AMT_PAY = _originalRat_145_tot_amt_pay;
			RAT_145_CHEQ_NBR = _originalRat_145_cheq_nbr;
			RAT_145_CLAIM_NBR = _originalRat_145_claim_nbr;
			RAT_145_TRANS_TYPE = _originalRat_145_trans_type;
			RAT_145_DOC_NBR = _originalRat_145_doc_nbr;
			RAT_145_SPECIALTY_CD = _originalRat_145_specialty_cd;
			RAT_145_ACCOUNT_NBR = _originalRat_145_account_nbr;
			RAT_145_LAST_NAME = _originalRat_145_last_name;
			RAT_145_FIRST_NAME = _originalRat_145_first_name;
			RAT_145_PROV_CD = _originalRat_145_prov_cd;
			RAT_145_HEALTH_OHIP_NBR = _originalRat_145_health_ohip_nbr;
			RAT_145_VERSION_CD = _originalRat_145_version_cd;
			RAT_145_PAY_PROG = _originalRat_145_pay_prog;
			RAT_145_CONV_HEALTH_NBR = _originalRat_145_conv_health_nbr;
			RAT_145_SERVICE_DATE = _originalRat_145_service_date;
			RAT_145_NBR_OF_SERV = _originalRat_145_nbr_of_serv;
			RAT_145_SERVICE_CD = _originalRat_145_service_cd;
			RAT_145_ELIGIBILITY_IND = _originalRat_145_eligibility_ind;
			RAT_145_AMOUNT_SUB = _originalRat_145_amount_sub;
			RAT_145_AMT_PAID = _originalRat_145_amt_paid;
			RAT_145_EXPLAN_CD = _originalRat_145_explan_cd;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Purge]");
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
						new SqlParameter("RAT_145_GROUP_NBR", SqlNull(RAT_145_GROUP_NBR)),
						new SqlParameter("RAT_145_MOH_OFF_CD", SqlNull(RAT_145_MOH_OFF_CD)),
						new SqlParameter("RAT_145_DATA_SEQ_NBR", SqlNull(RAT_145_DATA_SEQ_NBR)),
						new SqlParameter("RAT_145_PAYMENT_DATE", SqlNull(RAT_145_PAYMENT_DATE)),
						new SqlParameter("RAT_145_PAY_LAST_NAME", SqlNull(RAT_145_PAY_LAST_NAME)),
						new SqlParameter("RAT_145_PAY_TITLE", SqlNull(RAT_145_PAY_TITLE)),
						new SqlParameter("RAT_145_PAY_INITIALS", SqlNull(RAT_145_PAY_INITIALS)),
						new SqlParameter("RAT_145_TOT_AMT_PAY", SqlNull(RAT_145_TOT_AMT_PAY)),
						new SqlParameter("RAT_145_CHEQ_NBR", SqlNull(RAT_145_CHEQ_NBR)),
						new SqlParameter("RAT_145_CLAIM_NBR", SqlNull(RAT_145_CLAIM_NBR)),
						new SqlParameter("RAT_145_TRANS_TYPE", SqlNull(RAT_145_TRANS_TYPE)),
						new SqlParameter("RAT_145_DOC_NBR", SqlNull(RAT_145_DOC_NBR)),
						new SqlParameter("RAT_145_SPECIALTY_CD", SqlNull(RAT_145_SPECIALTY_CD)),
						new SqlParameter("RAT_145_ACCOUNT_NBR", SqlNull(RAT_145_ACCOUNT_NBR)),
						new SqlParameter("RAT_145_LAST_NAME", SqlNull(RAT_145_LAST_NAME)),
						new SqlParameter("RAT_145_FIRST_NAME", SqlNull(RAT_145_FIRST_NAME)),
						new SqlParameter("RAT_145_PROV_CD", SqlNull(RAT_145_PROV_CD)),
						new SqlParameter("RAT_145_HEALTH_OHIP_NBR", SqlNull(RAT_145_HEALTH_OHIP_NBR)),
						new SqlParameter("RAT_145_VERSION_CD", SqlNull(RAT_145_VERSION_CD)),
						new SqlParameter("RAT_145_PAY_PROG", SqlNull(RAT_145_PAY_PROG)),
						new SqlParameter("RAT_145_CONV_HEALTH_NBR", SqlNull(RAT_145_CONV_HEALTH_NBR)),
						new SqlParameter("RAT_145_SERVICE_DATE", SqlNull(RAT_145_SERVICE_DATE)),
						new SqlParameter("RAT_145_NBR_OF_SERV", SqlNull(RAT_145_NBR_OF_SERV)),
						new SqlParameter("RAT_145_SERVICE_CD", SqlNull(RAT_145_SERVICE_CD)),
						new SqlParameter("RAT_145_ELIGIBILITY_IND", SqlNull(RAT_145_ELIGIBILITY_IND)),
						new SqlParameter("RAT_145_AMOUNT_SUB", SqlNull(RAT_145_AMOUNT_SUB)),
						new SqlParameter("RAT_145_AMT_PAID", SqlNull(RAT_145_AMT_PAID)),
						new SqlParameter("RAT_145_EXPLAN_CD", SqlNull(RAT_145_EXPLAN_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_145_GROUP_NBR = Reader["RAT_145_GROUP_NBR"].ToString();
						RAT_145_MOH_OFF_CD = Reader["RAT_145_MOH_OFF_CD"].ToString();
						RAT_145_DATA_SEQ_NBR = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]);
						RAT_145_PAYMENT_DATE = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]);
						RAT_145_PAY_LAST_NAME = Reader["RAT_145_PAY_LAST_NAME"].ToString();
						RAT_145_PAY_TITLE = Reader["RAT_145_PAY_TITLE"].ToString();
						RAT_145_PAY_INITIALS = Reader["RAT_145_PAY_INITIALS"].ToString();
						RAT_145_TOT_AMT_PAY = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]);
						RAT_145_CHEQ_NBR = Reader["RAT_145_CHEQ_NBR"].ToString();
						RAT_145_CLAIM_NBR = Reader["RAT_145_CLAIM_NBR"].ToString();
						RAT_145_TRANS_TYPE = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]);
						RAT_145_DOC_NBR = ConvertDEC(Reader["RAT_145_DOC_NBR"]);
						RAT_145_SPECIALTY_CD = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]);
						RAT_145_ACCOUNT_NBR = Reader["RAT_145_ACCOUNT_NBR"].ToString();
						RAT_145_LAST_NAME = Reader["RAT_145_LAST_NAME"].ToString();
						RAT_145_FIRST_NAME = Reader["RAT_145_FIRST_NAME"].ToString();
						RAT_145_PROV_CD = Reader["RAT_145_PROV_CD"].ToString();
						RAT_145_HEALTH_OHIP_NBR = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString();
						RAT_145_VERSION_CD = Reader["RAT_145_VERSION_CD"].ToString();
						RAT_145_PAY_PROG = Reader["RAT_145_PAY_PROG"].ToString();
						RAT_145_CONV_HEALTH_NBR = Reader["RAT_145_CONV_HEALTH_NBR"].ToString();
						RAT_145_SERVICE_DATE = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]);
						RAT_145_NBR_OF_SERV = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]);
						RAT_145_SERVICE_CD = Reader["RAT_145_SERVICE_CD"].ToString();
						RAT_145_ELIGIBILITY_IND = Reader["RAT_145_ELIGIBILITY_IND"].ToString();
						RAT_145_AMOUNT_SUB = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]);
						RAT_145_AMT_PAID = ConvertDEC(Reader["RAT_145_AMT_PAID"]);
						RAT_145_EXPLAN_CD = Reader["RAT_145_EXPLAN_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_145_group_nbr = Reader["RAT_145_GROUP_NBR"].ToString();
						_originalRat_145_moh_off_cd = Reader["RAT_145_MOH_OFF_CD"].ToString();
						_originalRat_145_data_seq_nbr = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]);
						_originalRat_145_payment_date = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]);
						_originalRat_145_pay_last_name = Reader["RAT_145_PAY_LAST_NAME"].ToString();
						_originalRat_145_pay_title = Reader["RAT_145_PAY_TITLE"].ToString();
						_originalRat_145_pay_initials = Reader["RAT_145_PAY_INITIALS"].ToString();
						_originalRat_145_tot_amt_pay = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]);
						_originalRat_145_cheq_nbr = Reader["RAT_145_CHEQ_NBR"].ToString();
						_originalRat_145_claim_nbr = Reader["RAT_145_CLAIM_NBR"].ToString();
						_originalRat_145_trans_type = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]);
						_originalRat_145_doc_nbr = ConvertDEC(Reader["RAT_145_DOC_NBR"]);
						_originalRat_145_specialty_cd = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]);
						_originalRat_145_account_nbr = Reader["RAT_145_ACCOUNT_NBR"].ToString();
						_originalRat_145_last_name = Reader["RAT_145_LAST_NAME"].ToString();
						_originalRat_145_first_name = Reader["RAT_145_FIRST_NAME"].ToString();
						_originalRat_145_prov_cd = Reader["RAT_145_PROV_CD"].ToString();
						_originalRat_145_health_ohip_nbr = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString();
						_originalRat_145_version_cd = Reader["RAT_145_VERSION_CD"].ToString();
						_originalRat_145_pay_prog = Reader["RAT_145_PAY_PROG"].ToString();
						_originalRat_145_conv_health_nbr = Reader["RAT_145_CONV_HEALTH_NBR"].ToString();
						_originalRat_145_service_date = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]);
						_originalRat_145_nbr_of_serv = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]);
						_originalRat_145_service_cd = Reader["RAT_145_SERVICE_CD"].ToString();
						_originalRat_145_eligibility_ind = Reader["RAT_145_ELIGIBILITY_IND"].ToString();
						_originalRat_145_amount_sub = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]);
						_originalRat_145_amt_paid = ConvertDEC(Reader["RAT_145_AMT_PAID"]);
						_originalRat_145_explan_cd = Reader["RAT_145_EXPLAN_CD"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("RAT_145_GROUP_NBR", SqlNull(RAT_145_GROUP_NBR)),
						new SqlParameter("RAT_145_MOH_OFF_CD", SqlNull(RAT_145_MOH_OFF_CD)),
						new SqlParameter("RAT_145_DATA_SEQ_NBR", SqlNull(RAT_145_DATA_SEQ_NBR)),
						new SqlParameter("RAT_145_PAYMENT_DATE", SqlNull(RAT_145_PAYMENT_DATE)),
						new SqlParameter("RAT_145_PAY_LAST_NAME", SqlNull(RAT_145_PAY_LAST_NAME)),
						new SqlParameter("RAT_145_PAY_TITLE", SqlNull(RAT_145_PAY_TITLE)),
						new SqlParameter("RAT_145_PAY_INITIALS", SqlNull(RAT_145_PAY_INITIALS)),
						new SqlParameter("RAT_145_TOT_AMT_PAY", SqlNull(RAT_145_TOT_AMT_PAY)),
						new SqlParameter("RAT_145_CHEQ_NBR", SqlNull(RAT_145_CHEQ_NBR)),
						new SqlParameter("RAT_145_CLAIM_NBR", SqlNull(RAT_145_CLAIM_NBR)),
						new SqlParameter("RAT_145_TRANS_TYPE", SqlNull(RAT_145_TRANS_TYPE)),
						new SqlParameter("RAT_145_DOC_NBR", SqlNull(RAT_145_DOC_NBR)),
						new SqlParameter("RAT_145_SPECIALTY_CD", SqlNull(RAT_145_SPECIALTY_CD)),
						new SqlParameter("RAT_145_ACCOUNT_NBR", SqlNull(RAT_145_ACCOUNT_NBR)),
						new SqlParameter("RAT_145_LAST_NAME", SqlNull(RAT_145_LAST_NAME)),
						new SqlParameter("RAT_145_FIRST_NAME", SqlNull(RAT_145_FIRST_NAME)),
						new SqlParameter("RAT_145_PROV_CD", SqlNull(RAT_145_PROV_CD)),
						new SqlParameter("RAT_145_HEALTH_OHIP_NBR", SqlNull(RAT_145_HEALTH_OHIP_NBR)),
						new SqlParameter("RAT_145_VERSION_CD", SqlNull(RAT_145_VERSION_CD)),
						new SqlParameter("RAT_145_PAY_PROG", SqlNull(RAT_145_PAY_PROG)),
						new SqlParameter("RAT_145_CONV_HEALTH_NBR", SqlNull(RAT_145_CONV_HEALTH_NBR)),
						new SqlParameter("RAT_145_SERVICE_DATE", SqlNull(RAT_145_SERVICE_DATE)),
						new SqlParameter("RAT_145_NBR_OF_SERV", SqlNull(RAT_145_NBR_OF_SERV)),
						new SqlParameter("RAT_145_SERVICE_CD", SqlNull(RAT_145_SERVICE_CD)),
						new SqlParameter("RAT_145_ELIGIBILITY_IND", SqlNull(RAT_145_ELIGIBILITY_IND)),
						new SqlParameter("RAT_145_AMOUNT_SUB", SqlNull(RAT_145_AMOUNT_SUB)),
						new SqlParameter("RAT_145_AMT_PAID", SqlNull(RAT_145_AMT_PAID)),
						new SqlParameter("RAT_145_EXPLAN_CD", SqlNull(RAT_145_EXPLAN_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_U030_TAPE_145_FILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						RAT_145_GROUP_NBR = Reader["RAT_145_GROUP_NBR"].ToString();
						RAT_145_MOH_OFF_CD = Reader["RAT_145_MOH_OFF_CD"].ToString();
						RAT_145_DATA_SEQ_NBR = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]);
						RAT_145_PAYMENT_DATE = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]);
						RAT_145_PAY_LAST_NAME = Reader["RAT_145_PAY_LAST_NAME"].ToString();
						RAT_145_PAY_TITLE = Reader["RAT_145_PAY_TITLE"].ToString();
						RAT_145_PAY_INITIALS = Reader["RAT_145_PAY_INITIALS"].ToString();
						RAT_145_TOT_AMT_PAY = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]);
						RAT_145_CHEQ_NBR = Reader["RAT_145_CHEQ_NBR"].ToString();
						RAT_145_CLAIM_NBR = Reader["RAT_145_CLAIM_NBR"].ToString();
						RAT_145_TRANS_TYPE = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]);
						RAT_145_DOC_NBR = ConvertDEC(Reader["RAT_145_DOC_NBR"]);
						RAT_145_SPECIALTY_CD = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]);
						RAT_145_ACCOUNT_NBR = Reader["RAT_145_ACCOUNT_NBR"].ToString();
						RAT_145_LAST_NAME = Reader["RAT_145_LAST_NAME"].ToString();
						RAT_145_FIRST_NAME = Reader["RAT_145_FIRST_NAME"].ToString();
						RAT_145_PROV_CD = Reader["RAT_145_PROV_CD"].ToString();
						RAT_145_HEALTH_OHIP_NBR = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString();
						RAT_145_VERSION_CD = Reader["RAT_145_VERSION_CD"].ToString();
						RAT_145_PAY_PROG = Reader["RAT_145_PAY_PROG"].ToString();
						RAT_145_CONV_HEALTH_NBR = Reader["RAT_145_CONV_HEALTH_NBR"].ToString();
						RAT_145_SERVICE_DATE = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]);
						RAT_145_NBR_OF_SERV = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]);
						RAT_145_SERVICE_CD = Reader["RAT_145_SERVICE_CD"].ToString();
						RAT_145_ELIGIBILITY_IND = Reader["RAT_145_ELIGIBILITY_IND"].ToString();
						RAT_145_AMOUNT_SUB = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]);
						RAT_145_AMT_PAID = ConvertDEC(Reader["RAT_145_AMT_PAID"]);
						RAT_145_EXPLAN_CD = Reader["RAT_145_EXPLAN_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalRat_145_group_nbr = Reader["RAT_145_GROUP_NBR"].ToString();
						_originalRat_145_moh_off_cd = Reader["RAT_145_MOH_OFF_CD"].ToString();
						_originalRat_145_data_seq_nbr = ConvertDEC(Reader["RAT_145_DATA_SEQ_NBR"]);
						_originalRat_145_payment_date = ConvertDEC(Reader["RAT_145_PAYMENT_DATE"]);
						_originalRat_145_pay_last_name = Reader["RAT_145_PAY_LAST_NAME"].ToString();
						_originalRat_145_pay_title = Reader["RAT_145_PAY_TITLE"].ToString();
						_originalRat_145_pay_initials = Reader["RAT_145_PAY_INITIALS"].ToString();
						_originalRat_145_tot_amt_pay = ConvertDEC(Reader["RAT_145_TOT_AMT_PAY"]);
						_originalRat_145_cheq_nbr = Reader["RAT_145_CHEQ_NBR"].ToString();
						_originalRat_145_claim_nbr = Reader["RAT_145_CLAIM_NBR"].ToString();
						_originalRat_145_trans_type = ConvertDEC(Reader["RAT_145_TRANS_TYPE"]);
						_originalRat_145_doc_nbr = ConvertDEC(Reader["RAT_145_DOC_NBR"]);
						_originalRat_145_specialty_cd = ConvertDEC(Reader["RAT_145_SPECIALTY_CD"]);
						_originalRat_145_account_nbr = Reader["RAT_145_ACCOUNT_NBR"].ToString();
						_originalRat_145_last_name = Reader["RAT_145_LAST_NAME"].ToString();
						_originalRat_145_first_name = Reader["RAT_145_FIRST_NAME"].ToString();
						_originalRat_145_prov_cd = Reader["RAT_145_PROV_CD"].ToString();
						_originalRat_145_health_ohip_nbr = Reader["RAT_145_HEALTH_OHIP_NBR"].ToString();
						_originalRat_145_version_cd = Reader["RAT_145_VERSION_CD"].ToString();
						_originalRat_145_pay_prog = Reader["RAT_145_PAY_PROG"].ToString();
						_originalRat_145_conv_health_nbr = Reader["RAT_145_CONV_HEALTH_NBR"].ToString();
						_originalRat_145_service_date = ConvertDEC(Reader["RAT_145_SERVICE_DATE"]);
						_originalRat_145_nbr_of_serv = ConvertDEC(Reader["RAT_145_NBR_OF_SERV"]);
						_originalRat_145_service_cd = Reader["RAT_145_SERVICE_CD"].ToString();
						_originalRat_145_eligibility_ind = Reader["RAT_145_ELIGIBILITY_IND"].ToString();
						_originalRat_145_amount_sub = ConvertDEC(Reader["RAT_145_AMOUNT_SUB"]);
						_originalRat_145_amt_paid = ConvertDEC(Reader["RAT_145_AMT_PAID"]);
						_originalRat_145_explan_cd = Reader["RAT_145_EXPLAN_CD"].ToString();
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