using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F010_PAT_MSTR : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F010_PAT_MSTR> Collection( Guid? rowid,
															string pat_acronym_first6,
															string pat_acronym_last3,
															string pat_direct_alpha,
															decimal? pat_direct_yymin,
															decimal? pat_direct_yymax,
															decimal? pat_direct_mmmin,
															decimal? pat_direct_mmmax,
															decimal? pat_direct_ddmin,
															decimal? pat_direct_ddmax,
															string pat_direct_last_6,
															string pat_chart_nbr,
															string pat_chart_nbr_2,
															string pat_chart_nbr_3,
															string pat_chart_nbr_4,
															string pat_chart_nbr_5,
															string pat_surname_first3,
															string pat_surname_last22,
															string pat_given_name_first1,
															string filler3,
															string pat_init1,
															string pat_init2,
															string pat_init3,
															string pat_location_field,
															string pat_last_doc_nbr_seen,
															decimal? pat_birth_date_yymin,
															decimal? pat_birth_date_yymax,
															decimal? pat_birth_date_mmmin,
															decimal? pat_birth_date_mmmax,
															decimal? pat_birth_date_ddmin,
															decimal? pat_birth_date_ddmax,
															decimal? pat_date_last_maintmin,
															decimal? pat_date_last_maintmax,
															decimal? pat_date_last_visitmin,
															decimal? pat_date_last_visitmax,
															decimal? pat_date_last_admitmin,
															decimal? pat_date_last_admitmax,
															string pat_phone_nbr,
															decimal? pat_total_nbr_visitsmin,
															decimal? pat_total_nbr_visitsmax,
															decimal? pat_total_nbr_claimsmin,
															decimal? pat_total_nbr_claimsmax,
															string pat_sex,
															string pat_in_out,
															decimal? pat_nbr_outstanding_claimsmin,
															decimal? pat_nbr_outstanding_claimsmax,
															string pat_i_key,
															decimal? pat_con_nbrmin,
															decimal? pat_con_nbrmax,
															decimal? pat_i_nbrmin,
															decimal? pat_i_nbrmax,
															string filler4,
															decimal? pat_health_nbrmin,
															decimal? pat_health_nbrmax,
															string pat_version_cd,
															string pat_health_65_ind,
															decimal? pat_expiry_yymin,
															decimal? pat_expiry_yymax,
															decimal? pat_expiry_mmmin,
															decimal? pat_expiry_mmmax,
															string pat_prov_cd,
															string subscr_addr1,
															string subscr_addr2,
															string subscr_addr3,
															string subscr_prov_cd,
															string subscr_post_cd1,
															string subscr_post_cd2,
															string subscr_post_cd3,
															string subscr_post_cd4,
															string subscr_post_cd5,
															string subscr_post_cd6,
															string filler,
															string subscr_msg_nbr,
															decimal? subscr_date_msg_nbr_effect_to_yymin,
															decimal? subscr_date_msg_nbr_effect_to_yymax,
															decimal? subscr_date_msg_nbr_effect_to_mmmin,
															decimal? subscr_date_msg_nbr_effect_to_mmmax,
															decimal? subscr_date_msg_nbr_effect_to_ddmin,
															decimal? subscr_date_msg_nbr_effect_to_ddmax,
															decimal? subscr_date_last_statement_yymin,
															decimal? subscr_date_last_statement_yymax,
															decimal? subscr_date_last_statement_mmmin,
															decimal? subscr_date_last_statement_mmmax,
															decimal? subscr_date_last_statement_ddmin,
															decimal? subscr_date_last_statement_ddmax,
															string subscr_auto_update,
															string pat_last_mod_by,
															decimal? pat_date_last_elig_mailingmin,
															decimal? pat_date_last_elig_mailingmax,
															decimal? pat_date_last_elig_maintmin,
															decimal? pat_date_last_elig_maintmax,
															decimal? pat_last_birth_datemin,
															decimal? pat_last_birth_datemax,
															string pat_last_version_cd,
															string pat_mess_code,
															string pat_country,
															decimal? pat_no_of_letter_sentmin,
															decimal? pat_no_of_letter_sentmax,
															string pat_dialysis,
															string pat_ohip_validation_status,
															string pat_obec_status,
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
					new SqlParameter("PAT_ACRONYM_FIRST6",pat_acronym_first6),
					new SqlParameter("PAT_ACRONYM_LAST3",pat_acronym_last3),
					new SqlParameter("PAT_DIRECT_ALPHA",pat_direct_alpha),
					new SqlParameter("minPAT_DIRECT_YY",pat_direct_yymin),
					new SqlParameter("maxPAT_DIRECT_YY",pat_direct_yymax),
					new SqlParameter("minPAT_DIRECT_MM",pat_direct_mmmin),
					new SqlParameter("maxPAT_DIRECT_MM",pat_direct_mmmax),
					new SqlParameter("minPAT_DIRECT_DD",pat_direct_ddmin),
					new SqlParameter("maxPAT_DIRECT_DD",pat_direct_ddmax),
					new SqlParameter("PAT_DIRECT_LAST_6",pat_direct_last_6),
					new SqlParameter("PAT_CHART_NBR",pat_chart_nbr),
					new SqlParameter("PAT_CHART_NBR_2",pat_chart_nbr_2),
					new SqlParameter("PAT_CHART_NBR_3",pat_chart_nbr_3),
					new SqlParameter("PAT_CHART_NBR_4",pat_chart_nbr_4),
					new SqlParameter("PAT_CHART_NBR_5",pat_chart_nbr_5),
					new SqlParameter("PAT_SURNAME_FIRST3",pat_surname_first3),
					new SqlParameter("PAT_SURNAME_LAST22",pat_surname_last22),
					new SqlParameter("PAT_GIVEN_NAME_FIRST1",pat_given_name_first1),
					new SqlParameter("FILLER3",filler3),
					new SqlParameter("PAT_INIT1",pat_init1),
					new SqlParameter("PAT_INIT2",pat_init2),
					new SqlParameter("PAT_INIT3",pat_init3),
					new SqlParameter("PAT_LOCATION_FIELD",pat_location_field),
					new SqlParameter("PAT_LAST_DOC_NBR_SEEN",pat_last_doc_nbr_seen),
					new SqlParameter("minPAT_BIRTH_DATE_YY",pat_birth_date_yymin),
					new SqlParameter("maxPAT_BIRTH_DATE_YY",pat_birth_date_yymax),
					new SqlParameter("minPAT_BIRTH_DATE_MM",pat_birth_date_mmmin),
					new SqlParameter("maxPAT_BIRTH_DATE_MM",pat_birth_date_mmmax),
					new SqlParameter("minPAT_BIRTH_DATE_DD",pat_birth_date_ddmin),
					new SqlParameter("maxPAT_BIRTH_DATE_DD",pat_birth_date_ddmax),
					new SqlParameter("minPAT_DATE_LAST_MAINT",pat_date_last_maintmin),
					new SqlParameter("maxPAT_DATE_LAST_MAINT",pat_date_last_maintmax),
					new SqlParameter("minPAT_DATE_LAST_VISIT",pat_date_last_visitmin),
					new SqlParameter("maxPAT_DATE_LAST_VISIT",pat_date_last_visitmax),
					new SqlParameter("minPAT_DATE_LAST_ADMIT",pat_date_last_admitmin),
					new SqlParameter("maxPAT_DATE_LAST_ADMIT",pat_date_last_admitmax),
					new SqlParameter("PAT_PHONE_NBR",pat_phone_nbr),
					new SqlParameter("minPAT_TOTAL_NBR_VISITS",pat_total_nbr_visitsmin),
					new SqlParameter("maxPAT_TOTAL_NBR_VISITS",pat_total_nbr_visitsmax),
					new SqlParameter("minPAT_TOTAL_NBR_CLAIMS",pat_total_nbr_claimsmin),
					new SqlParameter("maxPAT_TOTAL_NBR_CLAIMS",pat_total_nbr_claimsmax),
					new SqlParameter("PAT_SEX",pat_sex),
					new SqlParameter("PAT_IN_OUT",pat_in_out),
					new SqlParameter("minPAT_NBR_OUTSTANDING_CLAIMS",pat_nbr_outstanding_claimsmin),
					new SqlParameter("maxPAT_NBR_OUTSTANDING_CLAIMS",pat_nbr_outstanding_claimsmax),
					new SqlParameter("PAT_I_KEY",pat_i_key),
					new SqlParameter("minPAT_CON_NBR",pat_con_nbrmin),
					new SqlParameter("maxPAT_CON_NBR",pat_con_nbrmax),
					new SqlParameter("minPAT_I_NBR",pat_i_nbrmin),
					new SqlParameter("maxPAT_I_NBR",pat_i_nbrmax),
					new SqlParameter("FILLER4",filler4),
					new SqlParameter("minPAT_HEALTH_NBR",pat_health_nbrmin),
					new SqlParameter("maxPAT_HEALTH_NBR",pat_health_nbrmax),
					new SqlParameter("PAT_VERSION_CD",pat_version_cd),
					new SqlParameter("PAT_HEALTH_65_IND",pat_health_65_ind),
					new SqlParameter("minPAT_EXPIRY_YY",pat_expiry_yymin),
					new SqlParameter("maxPAT_EXPIRY_YY",pat_expiry_yymax),
					new SqlParameter("minPAT_EXPIRY_MM",pat_expiry_mmmin),
					new SqlParameter("maxPAT_EXPIRY_MM",pat_expiry_mmmax),
					new SqlParameter("PAT_PROV_CD",pat_prov_cd),
					new SqlParameter("SUBSCR_ADDR1",subscr_addr1),
					new SqlParameter("SUBSCR_ADDR2",subscr_addr2),
					new SqlParameter("SUBSCR_ADDR3",subscr_addr3),
					new SqlParameter("SUBSCR_PROV_CD",subscr_prov_cd),
					new SqlParameter("SUBSCR_POST_CD1",subscr_post_cd1),
					new SqlParameter("SUBSCR_POST_CD2",subscr_post_cd2),
					new SqlParameter("SUBSCR_POST_CD3",subscr_post_cd3),
					new SqlParameter("SUBSCR_POST_CD4",subscr_post_cd4),
					new SqlParameter("SUBSCR_POST_CD5",subscr_post_cd5),
					new SqlParameter("SUBSCR_POST_CD6",subscr_post_cd6),
					new SqlParameter("FILLER",filler),
					new SqlParameter("SUBSCR_MSG_NBR",subscr_msg_nbr),
					new SqlParameter("minSUBSCR_DATE_MSG_NBR_EFFECT_TO_YY",subscr_date_msg_nbr_effect_to_yymin),
					new SqlParameter("maxSUBSCR_DATE_MSG_NBR_EFFECT_TO_YY",subscr_date_msg_nbr_effect_to_yymax),
					new SqlParameter("minSUBSCR_DATE_MSG_NBR_EFFECT_TO_MM",subscr_date_msg_nbr_effect_to_mmmin),
					new SqlParameter("maxSUBSCR_DATE_MSG_NBR_EFFECT_TO_MM",subscr_date_msg_nbr_effect_to_mmmax),
					new SqlParameter("minSUBSCR_DATE_MSG_NBR_EFFECT_TO_DD",subscr_date_msg_nbr_effect_to_ddmin),
					new SqlParameter("maxSUBSCR_DATE_MSG_NBR_EFFECT_TO_DD",subscr_date_msg_nbr_effect_to_ddmax),
					new SqlParameter("minSUBSCR_DATE_LAST_STATEMENT_YY",subscr_date_last_statement_yymin),
					new SqlParameter("maxSUBSCR_DATE_LAST_STATEMENT_YY",subscr_date_last_statement_yymax),
					new SqlParameter("minSUBSCR_DATE_LAST_STATEMENT_MM",subscr_date_last_statement_mmmin),
					new SqlParameter("maxSUBSCR_DATE_LAST_STATEMENT_MM",subscr_date_last_statement_mmmax),
					new SqlParameter("minSUBSCR_DATE_LAST_STATEMENT_DD",subscr_date_last_statement_ddmin),
					new SqlParameter("maxSUBSCR_DATE_LAST_STATEMENT_DD",subscr_date_last_statement_ddmax),
					new SqlParameter("SUBSCR_AUTO_UPDATE",subscr_auto_update),
					new SqlParameter("PAT_LAST_MOD_BY",pat_last_mod_by),
					new SqlParameter("minPAT_DATE_LAST_ELIG_MAILING",pat_date_last_elig_mailingmin),
					new SqlParameter("maxPAT_DATE_LAST_ELIG_MAILING",pat_date_last_elig_mailingmax),
					new SqlParameter("minPAT_DATE_LAST_ELIG_MAINT",pat_date_last_elig_maintmin),
					new SqlParameter("maxPAT_DATE_LAST_ELIG_MAINT",pat_date_last_elig_maintmax),
					new SqlParameter("minPAT_LAST_BIRTH_DATE",pat_last_birth_datemin),
					new SqlParameter("maxPAT_LAST_BIRTH_DATE",pat_last_birth_datemax),
					new SqlParameter("PAT_LAST_VERSION_CD",pat_last_version_cd),
					new SqlParameter("PAT_MESS_CODE",pat_mess_code),
					new SqlParameter("PAT_COUNTRY",pat_country),
					new SqlParameter("minPAT_NO_OF_LETTER_SENT",pat_no_of_letter_sentmin),
					new SqlParameter("maxPAT_NO_OF_LETTER_SENT",pat_no_of_letter_sentmax),
					new SqlParameter("PAT_DIALYSIS",pat_dialysis),
					new SqlParameter("PAT_OHIP_VALIDATION_STATUS",pat_ohip_validation_status),
					new SqlParameter("PAT_OBEC_STATUS",pat_obec_status),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F010_PAT_MSTR>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Search]", parameters);
            var collection = new ObservableCollection<F010_PAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F010_PAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					PAT_DIRECT_ALPHA = Reader["PAT_DIRECT_ALPHA"].ToString(),
					PAT_DIRECT_YY = ConvertDEC(Reader["PAT_DIRECT_YY"]),
					PAT_DIRECT_MM = ConvertDEC(Reader["PAT_DIRECT_MM"]),
					PAT_DIRECT_DD = ConvertDEC(Reader["PAT_DIRECT_DD"]),
					PAT_DIRECT_LAST_6 = Reader["PAT_DIRECT_LAST_6"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					PAT_SURNAME_FIRST3 = Reader["PAT_SURNAME_FIRST3"].ToString(),
					PAT_SURNAME_LAST22 = Reader["PAT_SURNAME_LAST22"].ToString(),
					PAT_GIVEN_NAME_FIRST1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString(),
					FILLER3 = Reader["FILLER3"].ToString(),
					PAT_INIT1 = Reader["PAT_INIT1"].ToString(),
					PAT_INIT2 = Reader["PAT_INIT2"].ToString(),
					PAT_INIT3 = Reader["PAT_INIT3"].ToString(),
					PAT_LOCATION_FIELD = Reader["PAT_LOCATION_FIELD"].ToString(),
					PAT_LAST_DOC_NBR_SEEN = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString(),
					PAT_BIRTH_DATE_YY = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]),
					PAT_BIRTH_DATE_MM = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]),
					PAT_BIRTH_DATE_DD = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]),
					PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					PAT_DATE_LAST_VISIT = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]),
					PAT_DATE_LAST_ADMIT = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]),
					PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString(),
					PAT_TOTAL_NBR_VISITS = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]),
					PAT_TOTAL_NBR_CLAIMS = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					PAT_IN_OUT = Reader["PAT_IN_OUT"].ToString(),
					PAT_NBR_OUTSTANDING_CLAIMS = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]),
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_HEALTH_65_IND = Reader["PAT_HEALTH_65_IND"].ToString(),
					PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString(),
					SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString(),
					SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString(),
					SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString(),
					SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString(),
					SUBSCR_POST_CD1 = Reader["SUBSCR_POST_CD1"].ToString(),
					SUBSCR_POST_CD2 = Reader["SUBSCR_POST_CD2"].ToString(),
					SUBSCR_POST_CD3 = Reader["SUBSCR_POST_CD3"].ToString(),
					SUBSCR_POST_CD4 = Reader["SUBSCR_POST_CD4"].ToString(),
					SUBSCR_POST_CD5 = Reader["SUBSCR_POST_CD5"].ToString(),
					SUBSCR_POST_CD6 = Reader["SUBSCR_POST_CD6"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					SUBSCR_MSG_NBR = Reader["SUBSCR_MSG_NBR"].ToString(),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]),
					SUBSCR_DATE_LAST_STATEMENT_YY = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]),
					SUBSCR_DATE_LAST_STATEMENT_MM = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]),
					SUBSCR_DATE_LAST_STATEMENT_DD = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]),
					SUBSCR_AUTO_UPDATE = Reader["SUBSCR_AUTO_UPDATE"].ToString(),
					PAT_LAST_MOD_BY = Reader["PAT_LAST_MOD_BY"].ToString(),
					PAT_DATE_LAST_ELIG_MAILING = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]),
					PAT_DATE_LAST_ELIG_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]),
					PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
					PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
					PAT_MESS_CODE = Reader["PAT_MESS_CODE"].ToString(),
					PAT_COUNTRY = Reader["PAT_COUNTRY"].ToString(),
					PAT_NO_OF_LETTER_SENT = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]),
					PAT_DIALYSIS = Reader["PAT_DIALYSIS"].ToString(),
					PAT_OHIP_VALIDATION_STATUS = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString(),
					PAT_OBEC_STATUS = Reader["PAT_OBEC_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					_originalPat_direct_alpha = Reader["PAT_DIRECT_ALPHA"].ToString(),
					_originalPat_direct_yy = ConvertDEC(Reader["PAT_DIRECT_YY"]),
					_originalPat_direct_mm = ConvertDEC(Reader["PAT_DIRECT_MM"]),
					_originalPat_direct_dd = ConvertDEC(Reader["PAT_DIRECT_DD"]),
					_originalPat_direct_last_6 = Reader["PAT_DIRECT_LAST_6"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					_originalPat_surname_first3 = Reader["PAT_SURNAME_FIRST3"].ToString(),
					_originalPat_surname_last22 = Reader["PAT_SURNAME_LAST22"].ToString(),
					_originalPat_given_name_first1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString(),
					_originalFiller3 = Reader["FILLER3"].ToString(),
					_originalPat_init1 = Reader["PAT_INIT1"].ToString(),
					_originalPat_init2 = Reader["PAT_INIT2"].ToString(),
					_originalPat_init3 = Reader["PAT_INIT3"].ToString(),
					_originalPat_location_field = Reader["PAT_LOCATION_FIELD"].ToString(),
					_originalPat_last_doc_nbr_seen = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString(),
					_originalPat_birth_date_yy = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]),
					_originalPat_birth_date_mm = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]),
					_originalPat_birth_date_dd = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]),
					_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					_originalPat_date_last_visit = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]),
					_originalPat_date_last_admit = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]),
					_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString(),
					_originalPat_total_nbr_visits = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]),
					_originalPat_total_nbr_claims = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalPat_in_out = Reader["PAT_IN_OUT"].ToString(),
					_originalPat_nbr_outstanding_claims = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]),
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_health_65_ind = Reader["PAT_HEALTH_65_IND"].ToString(),
					_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString(),
					_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString(),
					_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString(),
					_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString(),
					_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString(),
					_originalSubscr_post_cd1 = Reader["SUBSCR_POST_CD1"].ToString(),
					_originalSubscr_post_cd2 = Reader["SUBSCR_POST_CD2"].ToString(),
					_originalSubscr_post_cd3 = Reader["SUBSCR_POST_CD3"].ToString(),
					_originalSubscr_post_cd4 = Reader["SUBSCR_POST_CD4"].ToString(),
					_originalSubscr_post_cd5 = Reader["SUBSCR_POST_CD5"].ToString(),
					_originalSubscr_post_cd6 = Reader["SUBSCR_POST_CD6"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalSubscr_msg_nbr = Reader["SUBSCR_MSG_NBR"].ToString(),
					_originalSubscr_date_msg_nbr_effect_to_yy = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]),
					_originalSubscr_date_msg_nbr_effect_to_mm = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]),
					_originalSubscr_date_msg_nbr_effect_to_dd = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]),
					_originalSubscr_date_last_statement_yy = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]),
					_originalSubscr_date_last_statement_mm = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]),
					_originalSubscr_date_last_statement_dd = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]),
					_originalSubscr_auto_update = Reader["SUBSCR_AUTO_UPDATE"].ToString(),
					_originalPat_last_mod_by = Reader["PAT_LAST_MOD_BY"].ToString(),
					_originalPat_date_last_elig_mailing = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]),
					_originalPat_date_last_elig_maint = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]),
					_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
					_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
					_originalPat_mess_code = Reader["PAT_MESS_CODE"].ToString(),
					_originalPat_country = Reader["PAT_COUNTRY"].ToString(),
					_originalPat_no_of_letter_sent = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]),
					_originalPat_dialysis = Reader["PAT_DIALYSIS"].ToString(),
					_originalPat_ohip_validation_status = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString(),
					_originalPat_obec_status = Reader["PAT_OBEC_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F010_PAT_MSTR Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection(null).FirstOrDefault();
        }

        public ObservableCollection<F010_PAT_MSTR> Collection(ObservableCollection<F010_PAT_MSTR>
                                                               f010PatMstr = null)
        {
            if (IsSameSearch() && f010PatMstr != null)
            {
                return f010PatMstr;
            }

           /* if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F010_PAT_MSTR>();
            } */

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("PAT_ACRONYM_FIRST6",WherePat_acronym_first6),
					new SqlParameter("PAT_ACRONYM_LAST3",WherePat_acronym_last3),
					new SqlParameter("PAT_DIRECT_ALPHA",WherePat_direct_alpha),
					new SqlParameter("PAT_DIRECT_YY",WherePat_direct_yy),
					new SqlParameter("PAT_DIRECT_MM",WherePat_direct_mm),
					new SqlParameter("PAT_DIRECT_DD",WherePat_direct_dd),
					new SqlParameter("PAT_DIRECT_LAST_6",WherePat_direct_last_6),
					new SqlParameter("PAT_CHART_NBR",WherePat_chart_nbr),
					new SqlParameter("PAT_CHART_NBR_2",WherePat_chart_nbr_2),
					new SqlParameter("PAT_CHART_NBR_3",WherePat_chart_nbr_3),
					new SqlParameter("PAT_CHART_NBR_4",WherePat_chart_nbr_4),
					new SqlParameter("PAT_CHART_NBR_5",WherePat_chart_nbr_5),
					new SqlParameter("PAT_SURNAME_FIRST3",WherePat_surname_first3),
					new SqlParameter("PAT_SURNAME_LAST22",WherePat_surname_last22),
					new SqlParameter("PAT_GIVEN_NAME_FIRST1",WherePat_given_name_first1),
					new SqlParameter("FILLER3",WhereFiller3),
					new SqlParameter("PAT_INIT1",WherePat_init1),
					new SqlParameter("PAT_INIT2",WherePat_init2),
					new SqlParameter("PAT_INIT3",WherePat_init3),
					new SqlParameter("PAT_LOCATION_FIELD",WherePat_location_field),
					new SqlParameter("PAT_LAST_DOC_NBR_SEEN",WherePat_last_doc_nbr_seen),
					new SqlParameter("PAT_BIRTH_DATE_YY",WherePat_birth_date_yy),
					new SqlParameter("PAT_BIRTH_DATE_MM",WherePat_birth_date_mm),
					new SqlParameter("PAT_BIRTH_DATE_DD",WherePat_birth_date_dd),
					new SqlParameter("PAT_DATE_LAST_MAINT",WherePat_date_last_maint),
					new SqlParameter("PAT_DATE_LAST_VISIT",WherePat_date_last_visit),
					new SqlParameter("PAT_DATE_LAST_ADMIT",WherePat_date_last_admit),
					new SqlParameter("PAT_PHONE_NBR",WherePat_phone_nbr),
					new SqlParameter("PAT_TOTAL_NBR_VISITS",WherePat_total_nbr_visits),
					new SqlParameter("PAT_TOTAL_NBR_CLAIMS",WherePat_total_nbr_claims),
					new SqlParameter("PAT_SEX",WherePat_sex),
					new SqlParameter("PAT_IN_OUT",WherePat_in_out),
					new SqlParameter("PAT_NBR_OUTSTANDING_CLAIMS",WherePat_nbr_outstanding_claims),

					new SqlParameter("PAT_I_KEY",WherePat_i_key),
					new SqlParameter("PAT_CON_NBR",WherePat_con_nbr),
					new SqlParameter("PAT_I_NBR",WherePat_i_nbr),
					new SqlParameter("FILLER4",WhereFiller4),

					new SqlParameter("PAT_HEALTH_NBR",WherePat_health_nbr),
					new SqlParameter("PAT_VERSION_CD",WherePat_version_cd),
					new SqlParameter("PAT_HEALTH_65_IND",WherePat_health_65_ind),
					new SqlParameter("PAT_EXPIRY_YY",WherePat_expiry_yy),
					new SqlParameter("PAT_EXPIRY_MM",WherePat_expiry_mm),
					new SqlParameter("PAT_PROV_CD",WherePat_prov_cd),
					new SqlParameter("SUBSCR_ADDR1",WhereSubscr_addr1),
					new SqlParameter("SUBSCR_ADDR2",WhereSubscr_addr2),
					new SqlParameter("SUBSCR_ADDR3",WhereSubscr_addr3),
					new SqlParameter("SUBSCR_PROV_CD",WhereSubscr_prov_cd),
					new SqlParameter("SUBSCR_POST_CD1",WhereSubscr_post_cd1),
					new SqlParameter("SUBSCR_POST_CD2",WhereSubscr_post_cd2),
					new SqlParameter("SUBSCR_POST_CD3",WhereSubscr_post_cd3),
					new SqlParameter("SUBSCR_POST_CD4",WhereSubscr_post_cd4),
					new SqlParameter("SUBSCR_POST_CD5",WhereSubscr_post_cd5),
					new SqlParameter("SUBSCR_POST_CD6",WhereSubscr_post_cd6),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("SUBSCR_MSG_NBR",WhereSubscr_msg_nbr),
					new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY",WhereSubscr_date_msg_nbr_effect_to_yy),
					new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM",WhereSubscr_date_msg_nbr_effect_to_mm),
					new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD",WhereSubscr_date_msg_nbr_effect_to_dd),
					new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_YY",WhereSubscr_date_last_statement_yy),
					new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_MM",WhereSubscr_date_last_statement_mm),
					new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_DD",WhereSubscr_date_last_statement_dd),
					new SqlParameter("SUBSCR_AUTO_UPDATE",WhereSubscr_auto_update),
					new SqlParameter("PAT_LAST_MOD_BY",WherePat_last_mod_by),
					new SqlParameter("PAT_DATE_LAST_ELIG_MAILING",WherePat_date_last_elig_mailing),
					new SqlParameter("PAT_DATE_LAST_ELIG_MAINT",WherePat_date_last_elig_maint),
					new SqlParameter("PAT_LAST_BIRTH_DATE",WherePat_last_birth_date),
					new SqlParameter("PAT_LAST_VERSION_CD",WherePat_last_version_cd),
					new SqlParameter("PAT_MESS_CODE",WherePat_mess_code),
					new SqlParameter("PAT_COUNTRY",WherePat_country),
					new SqlParameter("PAT_NO_OF_LETTER_SENT",WherePat_no_of_letter_sent),
					new SqlParameter("PAT_DIALYSIS",WherePat_dialysis),
					new SqlParameter("PAT_OHIP_VALIDATION_STATUS",WherePat_ohip_validation_status),
					new SqlParameter("PAT_OBEC_STATUS",WherePat_obec_status),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value), 
				};

			Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Match]", parameters);
            var collection = new ObservableCollection<F010_PAT_MSTR>();

            while (Reader.Read())
            {
                collection.Add(new F010_PAT_MSTR
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					PAT_DIRECT_ALPHA = Reader["PAT_DIRECT_ALPHA"].ToString(),
					PAT_DIRECT_YY = ConvertDEC(Reader["PAT_DIRECT_YY"]),
					PAT_DIRECT_MM = ConvertDEC(Reader["PAT_DIRECT_MM"]),
					PAT_DIRECT_DD = ConvertDEC(Reader["PAT_DIRECT_DD"]),
					PAT_DIRECT_LAST_6 = Reader["PAT_DIRECT_LAST_6"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					PAT_SURNAME_FIRST3 = Reader["PAT_SURNAME_FIRST3"].ToString(),
					PAT_SURNAME_LAST22 = Reader["PAT_SURNAME_LAST22"].ToString(),
					PAT_GIVEN_NAME_FIRST1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString(),
					FILLER3 = Reader["FILLER3"].ToString(),
					PAT_INIT1 = Reader["PAT_INIT1"].ToString(),
					PAT_INIT2 = Reader["PAT_INIT2"].ToString(),
					PAT_INIT3 = Reader["PAT_INIT3"].ToString(),
					PAT_LOCATION_FIELD = Reader["PAT_LOCATION_FIELD"].ToString(),
					PAT_LAST_DOC_NBR_SEEN = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString(),
					PAT_BIRTH_DATE_YY = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]),
					PAT_BIRTH_DATE_MM = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]),
					PAT_BIRTH_DATE_DD = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]),
					PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					PAT_DATE_LAST_VISIT = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]),
					PAT_DATE_LAST_ADMIT = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]),
					PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString(),
					PAT_TOTAL_NBR_VISITS = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]),
					PAT_TOTAL_NBR_CLAIMS = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					PAT_IN_OUT = Reader["PAT_IN_OUT"].ToString(),
					PAT_NBR_OUTSTANDING_CLAIMS = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]),
					PAT_I_KEY = Reader["PAT_I_KEY"].ToString(),
					PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]),
					PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]),
					FILLER4 = Reader["FILLER4"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_HEALTH_65_IND = Reader["PAT_HEALTH_65_IND"].ToString(),
					PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString(),
					SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString(),
					SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString(),
					SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString(),
					SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString(),
					SUBSCR_POST_CD1 = Reader["SUBSCR_POST_CD1"].ToString(),
					SUBSCR_POST_CD2 = Reader["SUBSCR_POST_CD2"].ToString(),
					SUBSCR_POST_CD3 = Reader["SUBSCR_POST_CD3"].ToString(),
					SUBSCR_POST_CD4 = Reader["SUBSCR_POST_CD4"].ToString(),
					SUBSCR_POST_CD5 = Reader["SUBSCR_POST_CD5"].ToString(),
					SUBSCR_POST_CD6 = Reader["SUBSCR_POST_CD6"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					SUBSCR_MSG_NBR = Reader["SUBSCR_MSG_NBR"].ToString(),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]),
					SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]),
					SUBSCR_DATE_LAST_STATEMENT_YY = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]),
					SUBSCR_DATE_LAST_STATEMENT_MM = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]),
					SUBSCR_DATE_LAST_STATEMENT_DD = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]),
					SUBSCR_AUTO_UPDATE = Reader["SUBSCR_AUTO_UPDATE"].ToString(),
					PAT_LAST_MOD_BY = Reader["PAT_LAST_MOD_BY"].ToString(),
					PAT_DATE_LAST_ELIG_MAILING = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]),
					PAT_DATE_LAST_ELIG_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]),
					PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
					PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString(),
					PAT_MESS_CODE = Reader["PAT_MESS_CODE"].ToString(),
					PAT_COUNTRY = Reader["PAT_COUNTRY"].ToString(),
					PAT_NO_OF_LETTER_SENT = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]),
					PAT_DIALYSIS = Reader["PAT_DIALYSIS"].ToString(),
					PAT_OHIP_VALIDATION_STATUS = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString(),
					PAT_OBEC_STATUS = Reader["PAT_OBEC_STATUS"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_wherePat_acronym_first6 = WherePat_acronym_first6,
					_wherePat_acronym_last3 = WherePat_acronym_last3,
					_wherePat_direct_alpha = WherePat_direct_alpha,
					_wherePat_direct_yy = WherePat_direct_yy,
					_wherePat_direct_mm = WherePat_direct_mm,
					_wherePat_direct_dd = WherePat_direct_dd,
					_wherePat_direct_last_6 = WherePat_direct_last_6,
					_wherePat_chart_nbr = WherePat_chart_nbr,
					_wherePat_chart_nbr_2 = WherePat_chart_nbr_2,
					_wherePat_chart_nbr_3 = WherePat_chart_nbr_3,
					_wherePat_chart_nbr_4 = WherePat_chart_nbr_4,
					_wherePat_chart_nbr_5 = WherePat_chart_nbr_5,
					_wherePat_surname_first3 = WherePat_surname_first3,
					_wherePat_surname_last22 = WherePat_surname_last22,
					_wherePat_given_name_first1 = WherePat_given_name_first1,
					_whereFiller3 = WhereFiller3,
					_wherePat_init1 = WherePat_init1,
					_wherePat_init2 = WherePat_init2,
					_wherePat_init3 = WherePat_init3,
					_wherePat_location_field = WherePat_location_field,
					_wherePat_last_doc_nbr_seen = WherePat_last_doc_nbr_seen,
					_wherePat_birth_date_yy = WherePat_birth_date_yy,
					_wherePat_birth_date_mm = WherePat_birth_date_mm,
					_wherePat_birth_date_dd = WherePat_birth_date_dd,
					_wherePat_date_last_maint = WherePat_date_last_maint,
					_wherePat_date_last_visit = WherePat_date_last_visit,
					_wherePat_date_last_admit = WherePat_date_last_admit,
					_wherePat_phone_nbr = WherePat_phone_nbr,
					_wherePat_total_nbr_visits = WherePat_total_nbr_visits,
					_wherePat_total_nbr_claims = WherePat_total_nbr_claims,
					_wherePat_sex = WherePat_sex,
					_wherePat_in_out = WherePat_in_out,
					_wherePat_nbr_outstanding_claims = WherePat_nbr_outstanding_claims,
					_wherePat_i_key = WherePat_i_key,
					_wherePat_con_nbr = WherePat_con_nbr,
					_wherePat_i_nbr = WherePat_i_nbr,
					_whereFiller4 = WhereFiller4,
					_wherePat_health_nbr = WherePat_health_nbr,
					_wherePat_version_cd = WherePat_version_cd,
					_wherePat_health_65_ind = WherePat_health_65_ind,
					_wherePat_expiry_yy = WherePat_expiry_yy,
					_wherePat_expiry_mm = WherePat_expiry_mm,
					_wherePat_prov_cd = WherePat_prov_cd,
					_whereSubscr_addr1 = WhereSubscr_addr1,
					_whereSubscr_addr2 = WhereSubscr_addr2,
					_whereSubscr_addr3 = WhereSubscr_addr3,
					_whereSubscr_prov_cd = WhereSubscr_prov_cd,
					_whereSubscr_post_cd1 = WhereSubscr_post_cd1,
					_whereSubscr_post_cd2 = WhereSubscr_post_cd2,
					_whereSubscr_post_cd3 = WhereSubscr_post_cd3,
					_whereSubscr_post_cd4 = WhereSubscr_post_cd4,
					_whereSubscr_post_cd5 = WhereSubscr_post_cd5,
					_whereSubscr_post_cd6 = WhereSubscr_post_cd6,
					_whereFiller = WhereFiller,
					_whereSubscr_msg_nbr = WhereSubscr_msg_nbr,
					_whereSubscr_date_msg_nbr_effect_to_yy = WhereSubscr_date_msg_nbr_effect_to_yy,
					_whereSubscr_date_msg_nbr_effect_to_mm = WhereSubscr_date_msg_nbr_effect_to_mm,
					_whereSubscr_date_msg_nbr_effect_to_dd = WhereSubscr_date_msg_nbr_effect_to_dd,
					_whereSubscr_date_last_statement_yy = WhereSubscr_date_last_statement_yy,
					_whereSubscr_date_last_statement_mm = WhereSubscr_date_last_statement_mm,
					_whereSubscr_date_last_statement_dd = WhereSubscr_date_last_statement_dd,
					_whereSubscr_auto_update = WhereSubscr_auto_update,
					_wherePat_last_mod_by = WherePat_last_mod_by,
					_wherePat_date_last_elig_mailing = WherePat_date_last_elig_mailing,
					_wherePat_date_last_elig_maint = WherePat_date_last_elig_maint,
					_wherePat_last_birth_date = WherePat_last_birth_date,
					_wherePat_last_version_cd = WherePat_last_version_cd,
					_wherePat_mess_code = WherePat_mess_code,
					_wherePat_country = WherePat_country,
					_wherePat_no_of_letter_sent = WherePat_no_of_letter_sent,
					_wherePat_dialysis = WherePat_dialysis,
					_wherePat_ohip_validation_status = WherePat_ohip_validation_status,
					_wherePat_obec_status = WherePat_obec_status,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString(),
					_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString(),
					_originalPat_direct_alpha = Reader["PAT_DIRECT_ALPHA"].ToString(),
					_originalPat_direct_yy = ConvertDEC(Reader["PAT_DIRECT_YY"]),
					_originalPat_direct_mm = ConvertDEC(Reader["PAT_DIRECT_MM"]),
					_originalPat_direct_dd = ConvertDEC(Reader["PAT_DIRECT_DD"]),
					_originalPat_direct_last_6 = Reader["PAT_DIRECT_LAST_6"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					_originalPat_surname_first3 = Reader["PAT_SURNAME_FIRST3"].ToString(),
					_originalPat_surname_last22 = Reader["PAT_SURNAME_LAST22"].ToString(),
					_originalPat_given_name_first1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString(),
					_originalFiller3 = Reader["FILLER3"].ToString(),
					_originalPat_init1 = Reader["PAT_INIT1"].ToString(),
					_originalPat_init2 = Reader["PAT_INIT2"].ToString(),
					_originalPat_init3 = Reader["PAT_INIT3"].ToString(),
					_originalPat_location_field = Reader["PAT_LOCATION_FIELD"].ToString(),
					_originalPat_last_doc_nbr_seen = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString(),
					_originalPat_birth_date_yy = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]),
					_originalPat_birth_date_mm = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]),
					_originalPat_birth_date_dd = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]),
					_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]),
					_originalPat_date_last_visit = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]),
					_originalPat_date_last_admit = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]),
					_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString(),
					_originalPat_total_nbr_visits = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]),
					_originalPat_total_nbr_claims = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalPat_in_out = Reader["PAT_IN_OUT"].ToString(),
					_originalPat_nbr_outstanding_claims = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]),
					_originalPat_i_key = Reader["PAT_I_KEY"].ToString(),
					_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]),
					_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]),
					_originalFiller4 = Reader["FILLER4"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_health_65_ind = Reader["PAT_HEALTH_65_IND"].ToString(),
					_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]),
					_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]),
					_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString(),
					_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString(),
					_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString(),
					_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString(),
					_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString(),
					_originalSubscr_post_cd1 = Reader["SUBSCR_POST_CD1"].ToString(),
					_originalSubscr_post_cd2 = Reader["SUBSCR_POST_CD2"].ToString(),
					_originalSubscr_post_cd3 = Reader["SUBSCR_POST_CD3"].ToString(),
					_originalSubscr_post_cd4 = Reader["SUBSCR_POST_CD4"].ToString(),
					_originalSubscr_post_cd5 = Reader["SUBSCR_POST_CD5"].ToString(),
					_originalSubscr_post_cd6 = Reader["SUBSCR_POST_CD6"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalSubscr_msg_nbr = Reader["SUBSCR_MSG_NBR"].ToString(),
					_originalSubscr_date_msg_nbr_effect_to_yy = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]),
					_originalSubscr_date_msg_nbr_effect_to_mm = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]),
					_originalSubscr_date_msg_nbr_effect_to_dd = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]),
					_originalSubscr_date_last_statement_yy = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]),
					_originalSubscr_date_last_statement_mm = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]),
					_originalSubscr_date_last_statement_dd = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]),
					_originalSubscr_auto_update = Reader["SUBSCR_AUTO_UPDATE"].ToString(),
					_originalPat_last_mod_by = Reader["PAT_LAST_MOD_BY"].ToString(),
					_originalPat_date_last_elig_mailing = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]),
					_originalPat_date_last_elig_maint = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]),
					_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]),
					_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString(),
					_originalPat_mess_code = Reader["PAT_MESS_CODE"].ToString(),
					_originalPat_country = Reader["PAT_COUNTRY"].ToString(),
					_originalPat_no_of_letter_sent = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]),
					_originalPat_dialysis = Reader["PAT_DIALYSIS"].ToString(),
					_originalPat_ohip_validation_status = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString(),
					_originalPat_obec_status = Reader["PAT_OBEC_STATUS"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_wherePat_acronym_first6 = WherePat_acronym_first6;
					_wherePat_acronym_last3 = WherePat_acronym_last3;
					_wherePat_direct_alpha = WherePat_direct_alpha;
					_wherePat_direct_yy = WherePat_direct_yy;
					_wherePat_direct_mm = WherePat_direct_mm;
					_wherePat_direct_dd = WherePat_direct_dd;
					_wherePat_direct_last_6 = WherePat_direct_last_6;
					_wherePat_chart_nbr = WherePat_chart_nbr;
					_wherePat_chart_nbr_2 = WherePat_chart_nbr_2;
					_wherePat_chart_nbr_3 = WherePat_chart_nbr_3;
					_wherePat_chart_nbr_4 = WherePat_chart_nbr_4;
					_wherePat_chart_nbr_5 = WherePat_chart_nbr_5;
					_wherePat_surname_first3 = WherePat_surname_first3;
					_wherePat_surname_last22 = WherePat_surname_last22;
					_wherePat_given_name_first1 = WherePat_given_name_first1;
					_whereFiller3 = WhereFiller3;
					_wherePat_init1 = WherePat_init1;
					_wherePat_init2 = WherePat_init2;
					_wherePat_init3 = WherePat_init3;
					_wherePat_location_field = WherePat_location_field;
					_wherePat_last_doc_nbr_seen = WherePat_last_doc_nbr_seen;
					_wherePat_birth_date_yy = WherePat_birth_date_yy;
					_wherePat_birth_date_mm = WherePat_birth_date_mm;
					_wherePat_birth_date_dd = WherePat_birth_date_dd;
					_wherePat_date_last_maint = WherePat_date_last_maint;
					_wherePat_date_last_visit = WherePat_date_last_visit;
					_wherePat_date_last_admit = WherePat_date_last_admit;
					_wherePat_phone_nbr = WherePat_phone_nbr;
					_wherePat_total_nbr_visits = WherePat_total_nbr_visits;
					_wherePat_total_nbr_claims = WherePat_total_nbr_claims;
					_wherePat_sex = WherePat_sex;
					_wherePat_in_out = WherePat_in_out;
					_wherePat_nbr_outstanding_claims = WherePat_nbr_outstanding_claims;
					_wherePat_i_key = WherePat_i_key;
					_wherePat_con_nbr = WherePat_con_nbr;
					_wherePat_i_nbr = WherePat_i_nbr;
					_whereFiller4 = WhereFiller4;
					_wherePat_health_nbr = WherePat_health_nbr;
					_wherePat_version_cd = WherePat_version_cd;
					_wherePat_health_65_ind = WherePat_health_65_ind;
					_wherePat_expiry_yy = WherePat_expiry_yy;
					_wherePat_expiry_mm = WherePat_expiry_mm;
					_wherePat_prov_cd = WherePat_prov_cd;
					_whereSubscr_addr1 = WhereSubscr_addr1;
					_whereSubscr_addr2 = WhereSubscr_addr2;
					_whereSubscr_addr3 = WhereSubscr_addr3;
					_whereSubscr_prov_cd = WhereSubscr_prov_cd;
					_whereSubscr_post_cd1 = WhereSubscr_post_cd1;
					_whereSubscr_post_cd2 = WhereSubscr_post_cd2;
					_whereSubscr_post_cd3 = WhereSubscr_post_cd3;
					_whereSubscr_post_cd4 = WhereSubscr_post_cd4;
					_whereSubscr_post_cd5 = WhereSubscr_post_cd5;
					_whereSubscr_post_cd6 = WhereSubscr_post_cd6;
					_whereFiller = WhereFiller;
					_whereSubscr_msg_nbr = WhereSubscr_msg_nbr;
					_whereSubscr_date_msg_nbr_effect_to_yy = WhereSubscr_date_msg_nbr_effect_to_yy;
					_whereSubscr_date_msg_nbr_effect_to_mm = WhereSubscr_date_msg_nbr_effect_to_mm;
					_whereSubscr_date_msg_nbr_effect_to_dd = WhereSubscr_date_msg_nbr_effect_to_dd;
					_whereSubscr_date_last_statement_yy = WhereSubscr_date_last_statement_yy;
					_whereSubscr_date_last_statement_mm = WhereSubscr_date_last_statement_mm;
					_whereSubscr_date_last_statement_dd = WhereSubscr_date_last_statement_dd;
					_whereSubscr_auto_update = WhereSubscr_auto_update;
					_wherePat_last_mod_by = WherePat_last_mod_by;
					_wherePat_date_last_elig_mailing = WherePat_date_last_elig_mailing;
					_wherePat_date_last_elig_maint = WherePat_date_last_elig_maint;
					_wherePat_last_birth_date = WherePat_last_birth_date;
					_wherePat_last_version_cd = WherePat_last_version_cd;
					_wherePat_mess_code = WherePat_mess_code;
					_wherePat_country = WherePat_country;
					_wherePat_no_of_letter_sent = WherePat_no_of_letter_sent;
					_wherePat_dialysis = WherePat_dialysis;
					_wherePat_ohip_validation_status = WherePat_ohip_validation_status;
					_wherePat_obec_status = WherePat_obec_status;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WherePat_acronym_first6 == null 
				&& WherePat_acronym_last3 == null 
				&& WherePat_direct_alpha == null 
				&& WherePat_direct_yy == null 
				&& WherePat_direct_mm == null 
				&& WherePat_direct_dd == null 
				&& WherePat_direct_last_6 == null 
				&& WherePat_chart_nbr == null 
				&& WherePat_chart_nbr_2 == null 
				&& WherePat_chart_nbr_3 == null 
				&& WherePat_chart_nbr_4 == null 
				&& WherePat_chart_nbr_5 == null 
				&& WherePat_surname_first3 == null 
				&& WherePat_surname_last22 == null 
				&& WherePat_given_name_first1 == null 
				&& WhereFiller3 == null 
				&& WherePat_init1 == null 
				&& WherePat_init2 == null 
				&& WherePat_init3 == null 
				&& WherePat_location_field == null 
				&& WherePat_last_doc_nbr_seen == null 
				&& WherePat_birth_date_yy == null 
				&& WherePat_birth_date_mm == null 
				&& WherePat_birth_date_dd == null 
				&& WherePat_date_last_maint == null 
				&& WherePat_date_last_visit == null 
				&& WherePat_date_last_admit == null 
				&& WherePat_phone_nbr == null 
				&& WherePat_total_nbr_visits == null 
				&& WherePat_total_nbr_claims == null 
				&& WherePat_sex == null 
				&& WherePat_in_out == null 
				&& WherePat_nbr_outstanding_claims == null 
				&& WherePat_i_key == null 
				&& WherePat_con_nbr == null 
				&& WherePat_i_nbr == null 
				&& WhereFiller4 == null 
				&& WherePat_health_nbr == null 
				&& WherePat_version_cd == null 
				&& WherePat_health_65_ind == null 
				&& WherePat_expiry_yy == null 
				&& WherePat_expiry_mm == null 
				&& WherePat_prov_cd == null 
				&& WhereSubscr_addr1 == null 
				&& WhereSubscr_addr2 == null 
				&& WhereSubscr_addr3 == null 
				&& WhereSubscr_prov_cd == null 
				&& WhereSubscr_post_cd1 == null 
				&& WhereSubscr_post_cd2 == null 
				&& WhereSubscr_post_cd3 == null 
				&& WhereSubscr_post_cd4 == null 
				&& WhereSubscr_post_cd5 == null 
				&& WhereSubscr_post_cd6 == null 
				&& WhereFiller == null 
				&& WhereSubscr_msg_nbr == null 
				&& WhereSubscr_date_msg_nbr_effect_to_yy == null 
				&& WhereSubscr_date_msg_nbr_effect_to_mm == null 
				&& WhereSubscr_date_msg_nbr_effect_to_dd == null 
				&& WhereSubscr_date_last_statement_yy == null 
				&& WhereSubscr_date_last_statement_mm == null 
				&& WhereSubscr_date_last_statement_dd == null 
				&& WhereSubscr_auto_update == null 
				&& WherePat_last_mod_by == null 
				&& WherePat_date_last_elig_mailing == null 
				&& WherePat_date_last_elig_maint == null 
				&& WherePat_last_birth_date == null 
				&& WherePat_last_version_cd == null 
				&& WherePat_mess_code == null 
				&& WherePat_country == null 
				&& WherePat_no_of_letter_sent == null 
				&& WherePat_dialysis == null 
				&& WherePat_ohip_validation_status == null 
				&& WherePat_obec_status == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WherePat_acronym_first6 ==  _wherePat_acronym_first6
				&& WherePat_acronym_last3 ==  _wherePat_acronym_last3
				&& WherePat_direct_alpha ==  _wherePat_direct_alpha
				&& WherePat_direct_yy ==  _wherePat_direct_yy
				&& WherePat_direct_mm ==  _wherePat_direct_mm
				&& WherePat_direct_dd ==  _wherePat_direct_dd
				&& WherePat_direct_last_6 ==  _wherePat_direct_last_6
				&& WherePat_chart_nbr ==  _wherePat_chart_nbr
				&& WherePat_chart_nbr_2 ==  _wherePat_chart_nbr_2
				&& WherePat_chart_nbr_3 ==  _wherePat_chart_nbr_3
				&& WherePat_chart_nbr_4 ==  _wherePat_chart_nbr_4
				&& WherePat_chart_nbr_5 ==  _wherePat_chart_nbr_5
				&& WherePat_surname_first3 ==  _wherePat_surname_first3
				&& WherePat_surname_last22 ==  _wherePat_surname_last22
				&& WherePat_given_name_first1 ==  _wherePat_given_name_first1
				&& WhereFiller3 ==  _whereFiller3
				&& WherePat_init1 ==  _wherePat_init1
				&& WherePat_init2 ==  _wherePat_init2
				&& WherePat_init3 ==  _wherePat_init3
				&& WherePat_location_field ==  _wherePat_location_field
				&& WherePat_last_doc_nbr_seen ==  _wherePat_last_doc_nbr_seen
				&& WherePat_birth_date_yy ==  _wherePat_birth_date_yy
				&& WherePat_birth_date_mm ==  _wherePat_birth_date_mm
				&& WherePat_birth_date_dd ==  _wherePat_birth_date_dd
				&& WherePat_date_last_maint ==  _wherePat_date_last_maint
				&& WherePat_date_last_visit ==  _wherePat_date_last_visit
				&& WherePat_date_last_admit ==  _wherePat_date_last_admit
				&& WherePat_phone_nbr ==  _wherePat_phone_nbr
				&& WherePat_total_nbr_visits ==  _wherePat_total_nbr_visits
				&& WherePat_total_nbr_claims ==  _wherePat_total_nbr_claims
				&& WherePat_sex ==  _wherePat_sex
				&& WherePat_in_out ==  _wherePat_in_out
				&& WherePat_nbr_outstanding_claims ==  _wherePat_nbr_outstanding_claims
				&& WherePat_i_key ==  _wherePat_i_key
				&& WherePat_con_nbr ==  _wherePat_con_nbr
				&& WherePat_i_nbr ==  _wherePat_i_nbr
				&& WhereFiller4 ==  _whereFiller4
				&& WherePat_health_nbr ==  _wherePat_health_nbr
				&& WherePat_version_cd ==  _wherePat_version_cd
				&& WherePat_health_65_ind ==  _wherePat_health_65_ind
				&& WherePat_expiry_yy ==  _wherePat_expiry_yy
				&& WherePat_expiry_mm ==  _wherePat_expiry_mm
				&& WherePat_prov_cd ==  _wherePat_prov_cd
				&& WhereSubscr_addr1 ==  _whereSubscr_addr1
				&& WhereSubscr_addr2 ==  _whereSubscr_addr2
				&& WhereSubscr_addr3 ==  _whereSubscr_addr3
				&& WhereSubscr_prov_cd ==  _whereSubscr_prov_cd
				&& WhereSubscr_post_cd1 ==  _whereSubscr_post_cd1
				&& WhereSubscr_post_cd2 ==  _whereSubscr_post_cd2
				&& WhereSubscr_post_cd3 ==  _whereSubscr_post_cd3
				&& WhereSubscr_post_cd4 ==  _whereSubscr_post_cd4
				&& WhereSubscr_post_cd5 ==  _whereSubscr_post_cd5
				&& WhereSubscr_post_cd6 ==  _whereSubscr_post_cd6
				&& WhereFiller ==  _whereFiller
				&& WhereSubscr_msg_nbr ==  _whereSubscr_msg_nbr
				&& WhereSubscr_date_msg_nbr_effect_to_yy ==  _whereSubscr_date_msg_nbr_effect_to_yy
				&& WhereSubscr_date_msg_nbr_effect_to_mm ==  _whereSubscr_date_msg_nbr_effect_to_mm
				&& WhereSubscr_date_msg_nbr_effect_to_dd ==  _whereSubscr_date_msg_nbr_effect_to_dd
				&& WhereSubscr_date_last_statement_yy ==  _whereSubscr_date_last_statement_yy
				&& WhereSubscr_date_last_statement_mm ==  _whereSubscr_date_last_statement_mm
				&& WhereSubscr_date_last_statement_dd ==  _whereSubscr_date_last_statement_dd
				&& WhereSubscr_auto_update ==  _whereSubscr_auto_update
				&& WherePat_last_mod_by ==  _wherePat_last_mod_by
				&& WherePat_date_last_elig_mailing ==  _wherePat_date_last_elig_mailing
				&& WherePat_date_last_elig_maint ==  _wherePat_date_last_elig_maint
				&& WherePat_last_birth_date ==  _wherePat_last_birth_date
				&& WherePat_last_version_cd ==  _wherePat_last_version_cd
				&& WherePat_mess_code ==  _wherePat_mess_code
				&& WherePat_country ==  _wherePat_country
				&& WherePat_no_of_letter_sent ==  _wherePat_no_of_letter_sent
				&& WherePat_dialysis ==  _wherePat_dialysis
				&& WherePat_ohip_validation_status ==  _wherePat_ohip_validation_status
				&& WherePat_obec_status ==  _wherePat_obec_status
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WherePat_acronym_first6 = null; 
			WherePat_acronym_last3 = null; 
			WherePat_direct_alpha = null; 
			WherePat_direct_yy = null; 
			WherePat_direct_mm = null; 
			WherePat_direct_dd = null; 
			WherePat_direct_last_6 = null; 
			WherePat_chart_nbr = null; 
			WherePat_chart_nbr_2 = null; 
			WherePat_chart_nbr_3 = null; 
			WherePat_chart_nbr_4 = null; 
			WherePat_chart_nbr_5 = null; 
			WherePat_surname_first3 = null; 
			WherePat_surname_last22 = null; 
			WherePat_given_name_first1 = null; 
			WhereFiller3 = null; 
			WherePat_init1 = null; 
			WherePat_init2 = null; 
			WherePat_init3 = null; 
			WherePat_location_field = null; 
			WherePat_last_doc_nbr_seen = null; 
			WherePat_birth_date_yy = null; 
			WherePat_birth_date_mm = null; 
			WherePat_birth_date_dd = null; 
			WherePat_date_last_maint = null; 
			WherePat_date_last_visit = null; 
			WherePat_date_last_admit = null; 
			WherePat_phone_nbr = null; 
			WherePat_total_nbr_visits = null; 
			WherePat_total_nbr_claims = null; 
			WherePat_sex = null; 
			WherePat_in_out = null; 
			WherePat_nbr_outstanding_claims = null; 
			WherePat_i_key = null; 
			WherePat_con_nbr = null; 
			WherePat_i_nbr = null; 
			WhereFiller4 = null;
            WhereKey_pat_mstr = null; 
			WherePat_health_nbr = null; 
			WherePat_version_cd = null; 
			WherePat_health_65_ind = null; 
			WherePat_expiry_yy = null; 
			WherePat_expiry_mm = null; 
			WherePat_prov_cd = null; 
			WhereSubscr_addr1 = null; 
			WhereSubscr_addr2 = null; 
			WhereSubscr_addr3 = null; 
			WhereSubscr_prov_cd = null; 
			WhereSubscr_post_cd1 = null; 
			WhereSubscr_post_cd2 = null; 
			WhereSubscr_post_cd3 = null; 
			WhereSubscr_post_cd4 = null; 
			WhereSubscr_post_cd5 = null; 
			WhereSubscr_post_cd6 = null; 
			WhereFiller = null; 
			WhereSubscr_msg_nbr = null; 
			WhereSubscr_date_msg_nbr_effect_to_yy = null; 
			WhereSubscr_date_msg_nbr_effect_to_mm = null; 
			WhereSubscr_date_msg_nbr_effect_to_dd = null; 
			WhereSubscr_date_last_statement_yy = null; 
			WhereSubscr_date_last_statement_mm = null; 
			WhereSubscr_date_last_statement_dd = null; 
			WhereSubscr_auto_update = null; 
			WherePat_last_mod_by = null; 
			WherePat_date_last_elig_mailing = null; 
			WherePat_date_last_elig_maint = null; 
			WherePat_last_birth_date = null; 
			WherePat_last_version_cd = null; 
			WherePat_mess_code = null; 
			WherePat_country = null; 
			WherePat_no_of_letter_sent = null; 
			WherePat_dialysis = null; 
			WherePat_ohip_validation_status = null; 
			WherePat_obec_status = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _PAT_ACRONYM_FIRST6;
		private string _PAT_ACRONYM_LAST3;
		private string _PAT_DIRECT_ALPHA;
		private decimal? _PAT_DIRECT_YY;
		private decimal? _PAT_DIRECT_MM;
		private decimal? _PAT_DIRECT_DD;
		private string _PAT_DIRECT_LAST_6;
		private string _PAT_CHART_NBR;
		private string _PAT_CHART_NBR_2;
		private string _PAT_CHART_NBR_3;
		private string _PAT_CHART_NBR_4;
		private string _PAT_CHART_NBR_5;
		private string _PAT_SURNAME_FIRST3;
		private string _PAT_SURNAME_LAST22;
		private string _PAT_GIVEN_NAME_FIRST1;
		private string _FILLER3;
		private string _PAT_INIT1;
		private string _PAT_INIT2;
		private string _PAT_INIT3;
		private string _PAT_LOCATION_FIELD;
		private string _PAT_LAST_DOC_NBR_SEEN;
		private decimal? _PAT_BIRTH_DATE_YY;
		private decimal? _PAT_BIRTH_DATE_MM;
		private decimal? _PAT_BIRTH_DATE_DD;
		private decimal? _PAT_DATE_LAST_MAINT;
		private decimal? _PAT_DATE_LAST_VISIT;
		private decimal? _PAT_DATE_LAST_ADMIT;
		private string _PAT_PHONE_NBR;
		private decimal? _PAT_TOTAL_NBR_VISITS;
		private decimal? _PAT_TOTAL_NBR_CLAIMS;
		private string _PAT_SEX;
		private string _PAT_IN_OUT;
		private decimal? _PAT_NBR_OUTSTANDING_CLAIMS;
		private string _PAT_I_KEY;
		private decimal? _PAT_CON_NBR;
		private decimal? _PAT_I_NBR;
		private string _FILLER4;
		private decimal? _PAT_HEALTH_NBR;
		private string _PAT_VERSION_CD;
		private string _PAT_HEALTH_65_IND;
		private decimal? _PAT_EXPIRY_YY;
		private decimal? _PAT_EXPIRY_MM;
		private string _PAT_PROV_CD;
		private string _SUBSCR_ADDR1;
		private string _SUBSCR_ADDR2;
		private string _SUBSCR_ADDR3;
		private string _SUBSCR_PROV_CD;
		private string _SUBSCR_POST_CD1;
		private string _SUBSCR_POST_CD2;
		private string _SUBSCR_POST_CD3;
		private string _SUBSCR_POST_CD4;
		private string _SUBSCR_POST_CD5;
		private string _SUBSCR_POST_CD6;
		private string _FILLER;
		private string _SUBSCR_MSG_NBR;
		private decimal? _SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY;
		private decimal? _SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM;
		private decimal? _SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD;
		private decimal? _SUBSCR_DATE_LAST_STATEMENT_YY;
		private decimal? _SUBSCR_DATE_LAST_STATEMENT_MM;
		private decimal? _SUBSCR_DATE_LAST_STATEMENT_DD;
		private string _SUBSCR_AUTO_UPDATE;
		private string _PAT_LAST_MOD_BY;
		private decimal? _PAT_DATE_LAST_ELIG_MAILING;
		private decimal? _PAT_DATE_LAST_ELIG_MAINT;
		private decimal? _PAT_LAST_BIRTH_DATE;
		private string _PAT_LAST_VERSION_CD;
		private string _PAT_MESS_CODE;
		private string _PAT_COUNTRY;
		private decimal? _PAT_NO_OF_LETTER_SENT;
		private string _PAT_DIALYSIS;
		private string _PAT_OHIP_VALIDATION_STATUS;
		private string _PAT_OBEC_STATUS;
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
		public string PAT_ACRONYM_FIRST6
		{
			get { return _PAT_ACRONYM_FIRST6; }
			set
			{
				if (_PAT_ACRONYM_FIRST6 != value)
				{
					_PAT_ACRONYM_FIRST6 = value;
					ChangeState();
				}
			}
		}
		public string PAT_ACRONYM_LAST3
		{
			get { return _PAT_ACRONYM_LAST3; }
			set
			{
				if (_PAT_ACRONYM_LAST3 != value)
				{
					_PAT_ACRONYM_LAST3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_DIRECT_ALPHA
		{
			get { return _PAT_DIRECT_ALPHA; }
			set
			{
				if (_PAT_DIRECT_ALPHA != value)
				{
					_PAT_DIRECT_ALPHA = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DIRECT_YY
		{
			get { return _PAT_DIRECT_YY; }
			set
			{
				if (_PAT_DIRECT_YY != value)
				{
					_PAT_DIRECT_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DIRECT_MM
		{
			get { return _PAT_DIRECT_MM; }
			set
			{
				if (_PAT_DIRECT_MM != value)
				{
					_PAT_DIRECT_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DIRECT_DD
		{
			get { return _PAT_DIRECT_DD; }
			set
			{
				if (_PAT_DIRECT_DD != value)
				{
					_PAT_DIRECT_DD = value;
					ChangeState();
				}
			}
		}
		public string PAT_DIRECT_LAST_6
		{
			get { return _PAT_DIRECT_LAST_6; }
			set
			{
				if (_PAT_DIRECT_LAST_6 != value)
				{
					_PAT_DIRECT_LAST_6 = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR
		{
			get { return _PAT_CHART_NBR; }
			set
			{
				if (_PAT_CHART_NBR != value)
				{
					_PAT_CHART_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR_2
		{
			get { return _PAT_CHART_NBR_2; }
			set
			{
				if (_PAT_CHART_NBR_2 != value)
				{
					_PAT_CHART_NBR_2 = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR_3
		{
			get { return _PAT_CHART_NBR_3; }
			set
			{
				if (_PAT_CHART_NBR_3 != value)
				{
					_PAT_CHART_NBR_3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR_4
		{
			get { return _PAT_CHART_NBR_4; }
			set
			{
				if (_PAT_CHART_NBR_4 != value)
				{
					_PAT_CHART_NBR_4 = value;
					ChangeState();
				}
			}
		}
		public string PAT_CHART_NBR_5
		{
			get { return _PAT_CHART_NBR_5; }
			set
			{
				if (_PAT_CHART_NBR_5 != value)
				{
					_PAT_CHART_NBR_5 = value;
					ChangeState();
				}
			}
		}
		public string PAT_SURNAME_FIRST3
		{
			get { return _PAT_SURNAME_FIRST3; }
			set
			{
				if (_PAT_SURNAME_FIRST3 != value)
				{
					_PAT_SURNAME_FIRST3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_SURNAME_LAST22
		{
			get { return _PAT_SURNAME_LAST22; }
			set
			{
				if (_PAT_SURNAME_LAST22 != value)
				{
					_PAT_SURNAME_LAST22 = value;
					ChangeState();
				}
			}
		}
		public string PAT_GIVEN_NAME_FIRST1
		{
			get { return _PAT_GIVEN_NAME_FIRST1; }
			set
			{
				if (_PAT_GIVEN_NAME_FIRST1 != value)
				{
					_PAT_GIVEN_NAME_FIRST1 = value;
					ChangeState();
				}
			}
		}
		public string FILLER3
		{
			get { return _FILLER3; }
			set
			{
				if (_FILLER3 != value)
				{
					_FILLER3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_INIT1
		{
			get { return _PAT_INIT1; }
			set
			{
				if (_PAT_INIT1 != value)
				{
					_PAT_INIT1 = value;
					ChangeState();
				}
			}
		}
		public string PAT_INIT2
		{
			get { return _PAT_INIT2; }
			set
			{
				if (_PAT_INIT2 != value)
				{
					_PAT_INIT2 = value;
					ChangeState();
				}
			}
		}
		public string PAT_INIT3
		{
			get { return _PAT_INIT3; }
			set
			{
				if (_PAT_INIT3 != value)
				{
					_PAT_INIT3 = value;
					ChangeState();
				}
			}
		}
		public string PAT_LOCATION_FIELD
		{
			get { return _PAT_LOCATION_FIELD; }
			set
			{
				if (_PAT_LOCATION_FIELD != value)
				{
					_PAT_LOCATION_FIELD = value;
					ChangeState();
				}
			}
		}
		public string PAT_LAST_DOC_NBR_SEEN
		{
			get { return _PAT_LAST_DOC_NBR_SEEN; }
			set
			{
				if (_PAT_LAST_DOC_NBR_SEEN != value)
				{
					_PAT_LAST_DOC_NBR_SEEN = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_BIRTH_DATE_YY
		{
			get { return _PAT_BIRTH_DATE_YY; }
			set
			{
				if (_PAT_BIRTH_DATE_YY != value)
				{
					_PAT_BIRTH_DATE_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_BIRTH_DATE_MM
		{
			get { return _PAT_BIRTH_DATE_MM; }
			set
			{
				if (_PAT_BIRTH_DATE_MM != value)
				{
					_PAT_BIRTH_DATE_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_BIRTH_DATE_DD
		{
			get { return _PAT_BIRTH_DATE_DD; }
			set
			{
				if (_PAT_BIRTH_DATE_DD != value)
				{
					_PAT_BIRTH_DATE_DD = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DATE_LAST_MAINT
		{
			get { return _PAT_DATE_LAST_MAINT; }
			set
			{
				if (_PAT_DATE_LAST_MAINT != value)
				{
					_PAT_DATE_LAST_MAINT = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DATE_LAST_VISIT
		{
			get { return _PAT_DATE_LAST_VISIT; }
			set
			{
				if (_PAT_DATE_LAST_VISIT != value)
				{
					_PAT_DATE_LAST_VISIT = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DATE_LAST_ADMIT
		{
			get { return _PAT_DATE_LAST_ADMIT; }
			set
			{
				if (_PAT_DATE_LAST_ADMIT != value)
				{
					_PAT_DATE_LAST_ADMIT = value;
					ChangeState();
				}
			}
		}
		public string PAT_PHONE_NBR
		{
			get { return _PAT_PHONE_NBR; }
			set
			{
				if (_PAT_PHONE_NBR != value)
				{
					_PAT_PHONE_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_TOTAL_NBR_VISITS
		{
			get { return _PAT_TOTAL_NBR_VISITS; }
			set
			{
				if (_PAT_TOTAL_NBR_VISITS != value)
				{
					_PAT_TOTAL_NBR_VISITS = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_TOTAL_NBR_CLAIMS
		{
			get { return _PAT_TOTAL_NBR_CLAIMS; }
			set
			{
				if (_PAT_TOTAL_NBR_CLAIMS != value)
				{
					_PAT_TOTAL_NBR_CLAIMS = value;
					ChangeState();
				}
			}
		}
		public string PAT_SEX
		{
			get { return _PAT_SEX; }
			set
			{
				if (_PAT_SEX != value)
				{
					_PAT_SEX = value;
					ChangeState();
				}
			}
		}
		public string PAT_IN_OUT
		{
			get { return _PAT_IN_OUT; }
			set
			{
				if (_PAT_IN_OUT != value)
				{
					_PAT_IN_OUT = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_NBR_OUTSTANDING_CLAIMS
		{
			get { return _PAT_NBR_OUTSTANDING_CLAIMS; }
			set
			{
				if (_PAT_NBR_OUTSTANDING_CLAIMS != value)
				{
					_PAT_NBR_OUTSTANDING_CLAIMS = value;
					ChangeState();
				}
			}
		}
		public string PAT_I_KEY
		{
			get { return _PAT_I_KEY; }
			set
			{
				if (_PAT_I_KEY != value)
				{
					_PAT_I_KEY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_CON_NBR
		{
			get { return _PAT_CON_NBR; }
			set
			{
				if (_PAT_CON_NBR != value)
				{
					_PAT_CON_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_I_NBR
		{
			get { return _PAT_I_NBR; }
			set
			{
				if (_PAT_I_NBR != value)
				{
					_PAT_I_NBR = value;
					ChangeState();
				}
			}
		}
		public string FILLER4
		{
			get { return _FILLER4; }
			set
			{
				if (_FILLER4 != value)
				{
					_FILLER4 = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_HEALTH_NBR
		{
			get { return _PAT_HEALTH_NBR; }
			set
			{
				if (_PAT_HEALTH_NBR != value)
				{
					_PAT_HEALTH_NBR = value;
					ChangeState();
				}
			}
		}
		public string PAT_VERSION_CD
		{
			get { return _PAT_VERSION_CD; }
			set
			{
				if (_PAT_VERSION_CD != value)
				{
					_PAT_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public string PAT_HEALTH_65_IND
		{
			get { return _PAT_HEALTH_65_IND; }
			set
			{
				if (_PAT_HEALTH_65_IND != value)
				{
					_PAT_HEALTH_65_IND = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_EXPIRY_YY
		{
			get { return _PAT_EXPIRY_YY; }
			set
			{
				if (_PAT_EXPIRY_YY != value)
				{
					_PAT_EXPIRY_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_EXPIRY_MM
		{
			get { return _PAT_EXPIRY_MM; }
			set
			{
				if (_PAT_EXPIRY_MM != value)
				{
					_PAT_EXPIRY_MM = value;
					ChangeState();
				}
			}
		}
		public string PAT_PROV_CD
		{
			get { return _PAT_PROV_CD; }
			set
			{
				if (_PAT_PROV_CD != value)
				{
					_PAT_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_ADDR1
		{
			get { return _SUBSCR_ADDR1; }
			set
			{
				if (_SUBSCR_ADDR1 != value)
				{
					_SUBSCR_ADDR1 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_ADDR2
		{
			get { return _SUBSCR_ADDR2; }
			set
			{
				if (_SUBSCR_ADDR2 != value)
				{
					_SUBSCR_ADDR2 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_ADDR3
		{
			get { return _SUBSCR_ADDR3; }
			set
			{
				if (_SUBSCR_ADDR3 != value)
				{
					_SUBSCR_ADDR3 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_PROV_CD
		{
			get { return _SUBSCR_PROV_CD; }
			set
			{
				if (_SUBSCR_PROV_CD != value)
				{
					_SUBSCR_PROV_CD = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD1
		{
			get { return _SUBSCR_POST_CD1; }
			set
			{
				if (_SUBSCR_POST_CD1 != value)
				{
					_SUBSCR_POST_CD1 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD2
		{
			get { return _SUBSCR_POST_CD2; }
			set
			{
				if (_SUBSCR_POST_CD2 != value)
				{
					_SUBSCR_POST_CD2 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD3
		{
			get { return _SUBSCR_POST_CD3; }
			set
			{
				if (_SUBSCR_POST_CD3 != value)
				{
					_SUBSCR_POST_CD3 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD4
		{
			get { return _SUBSCR_POST_CD4; }
			set
			{
				if (_SUBSCR_POST_CD4 != value)
				{
					_SUBSCR_POST_CD4 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD5
		{
			get { return _SUBSCR_POST_CD5; }
			set
			{
				if (_SUBSCR_POST_CD5 != value)
				{
					_SUBSCR_POST_CD5 = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_POST_CD6
		{
			get { return _SUBSCR_POST_CD6; }
			set
			{
				if (_SUBSCR_POST_CD6 != value)
				{
					_SUBSCR_POST_CD6 = value;
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
		public string SUBSCR_MSG_NBR
		{
			get { return _SUBSCR_MSG_NBR; }
			set
			{
				if (_SUBSCR_MSG_NBR != value)
				{
					_SUBSCR_MSG_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY
		{
			get { return _SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY; }
			set
			{
				if (_SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY != value)
				{
					_SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM
		{
			get { return _SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM; }
			set
			{
				if (_SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM != value)
				{
					_SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD
		{
			get { return _SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD; }
			set
			{
				if (_SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD != value)
				{
					_SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_LAST_STATEMENT_YY
		{
			get { return _SUBSCR_DATE_LAST_STATEMENT_YY; }
			set
			{
				if (_SUBSCR_DATE_LAST_STATEMENT_YY != value)
				{
					_SUBSCR_DATE_LAST_STATEMENT_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_LAST_STATEMENT_MM
		{
			get { return _SUBSCR_DATE_LAST_STATEMENT_MM; }
			set
			{
				if (_SUBSCR_DATE_LAST_STATEMENT_MM != value)
				{
					_SUBSCR_DATE_LAST_STATEMENT_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? SUBSCR_DATE_LAST_STATEMENT_DD
		{
			get { return _SUBSCR_DATE_LAST_STATEMENT_DD; }
			set
			{
				if (_SUBSCR_DATE_LAST_STATEMENT_DD != value)
				{
					_SUBSCR_DATE_LAST_STATEMENT_DD = value;
					ChangeState();
				}
			}
		}
		public string SUBSCR_AUTO_UPDATE
		{
			get { return _SUBSCR_AUTO_UPDATE; }
			set
			{
				if (_SUBSCR_AUTO_UPDATE != value)
				{
					_SUBSCR_AUTO_UPDATE = value;
					ChangeState();
				}
			}
		}
		public string PAT_LAST_MOD_BY
		{
			get { return _PAT_LAST_MOD_BY; }
			set
			{
				if (_PAT_LAST_MOD_BY != value)
				{
					_PAT_LAST_MOD_BY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DATE_LAST_ELIG_MAILING
		{
			get { return _PAT_DATE_LAST_ELIG_MAILING; }
			set
			{
				if (_PAT_DATE_LAST_ELIG_MAILING != value)
				{
					_PAT_DATE_LAST_ELIG_MAILING = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_DATE_LAST_ELIG_MAINT
		{
			get { return _PAT_DATE_LAST_ELIG_MAINT; }
			set
			{
				if (_PAT_DATE_LAST_ELIG_MAINT != value)
				{
					_PAT_DATE_LAST_ELIG_MAINT = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_LAST_BIRTH_DATE
		{
			get { return _PAT_LAST_BIRTH_DATE; }
			set
			{
				if (_PAT_LAST_BIRTH_DATE != value)
				{
					_PAT_LAST_BIRTH_DATE = value;
					ChangeState();
				}
			}
		}
		public string PAT_LAST_VERSION_CD
		{
			get { return _PAT_LAST_VERSION_CD; }
			set
			{
				if (_PAT_LAST_VERSION_CD != value)
				{
					_PAT_LAST_VERSION_CD = value;
					ChangeState();
				}
			}
		}
		public string PAT_MESS_CODE
		{
			get { return _PAT_MESS_CODE; }
			set
			{
				if (_PAT_MESS_CODE != value)
				{
					_PAT_MESS_CODE = value;
					ChangeState();
				}
			}
		}
		public string PAT_COUNTRY
		{
			get { return _PAT_COUNTRY; }
			set
			{
				if (_PAT_COUNTRY != value)
				{
					_PAT_COUNTRY = value;
					ChangeState();
				}
			}
		}
		public decimal? PAT_NO_OF_LETTER_SENT
		{
			get { return _PAT_NO_OF_LETTER_SENT; }
			set
			{
				if (_PAT_NO_OF_LETTER_SENT != value)
				{
					_PAT_NO_OF_LETTER_SENT = value;
					ChangeState();
				}
			}
		}
		public string PAT_DIALYSIS
		{
			get { return _PAT_DIALYSIS; }
			set
			{
				if (_PAT_DIALYSIS != value)
				{
					_PAT_DIALYSIS = value;
					ChangeState();
				}
			}
		}
		public string PAT_OHIP_VALIDATION_STATUS
		{
			get { return _PAT_OHIP_VALIDATION_STATUS; }
			set
			{
				if (_PAT_OHIP_VALIDATION_STATUS != value)
				{
					_PAT_OHIP_VALIDATION_STATUS = value;
					ChangeState();
				}
			}
		}
		public string PAT_OBEC_STATUS
		{
			get { return _PAT_OBEC_STATUS; }
			set
			{
				if (_PAT_OBEC_STATUS != value)
				{
					_PAT_OBEC_STATUS = value;
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
		public string WherePat_acronym_first6 { get; set; }
		private string _wherePat_acronym_first6;
		public string WherePat_acronym_last3 { get; set; }
		private string _wherePat_acronym_last3;
		public string WherePat_direct_alpha { get; set; }
		private string _wherePat_direct_alpha;
		public decimal? WherePat_direct_yy { get; set; }
		private decimal? _wherePat_direct_yy;
		public decimal? WherePat_direct_mm { get; set; }
		private decimal? _wherePat_direct_mm;
		public decimal? WherePat_direct_dd { get; set; }
		private decimal? _wherePat_direct_dd;
		public string WherePat_direct_last_6 { get; set; }
		private string _wherePat_direct_last_6;
		public string WherePat_chart_nbr { get; set; }
		private string _wherePat_chart_nbr;
		public string WherePat_chart_nbr_2 { get; set; }
		private string _wherePat_chart_nbr_2;
		public string WherePat_chart_nbr_3 { get; set; }
		private string _wherePat_chart_nbr_3;
		public string WherePat_chart_nbr_4 { get; set; }
		private string _wherePat_chart_nbr_4;
		public string WherePat_chart_nbr_5 { get; set; }
		private string _wherePat_chart_nbr_5;
		public string WherePat_surname_first3 { get; set; }
		private string _wherePat_surname_first3;
		public string WherePat_surname_last22 { get; set; }
		private string _wherePat_surname_last22;
		public string WherePat_given_name_first1 { get; set; }
		private string _wherePat_given_name_first1;
		public string WhereFiller3 { get; set; }
		private string _whereFiller3;
		public string WherePat_init1 { get; set; }
		private string _wherePat_init1;
		public string WherePat_init2 { get; set; }
		private string _wherePat_init2;
		public string WherePat_init3 { get; set; }
		private string _wherePat_init3;
		public string WherePat_location_field { get; set; }
		private string _wherePat_location_field;
		public string WherePat_last_doc_nbr_seen { get; set; }
		private string _wherePat_last_doc_nbr_seen;
		public decimal? WherePat_birth_date_yy { get; set; }
		private decimal? _wherePat_birth_date_yy;
		public decimal? WherePat_birth_date_mm { get; set; }
		private decimal? _wherePat_birth_date_mm;
		public decimal? WherePat_birth_date_dd { get; set; }
		private decimal? _wherePat_birth_date_dd;
		public decimal? WherePat_date_last_maint { get; set; }
		private decimal? _wherePat_date_last_maint;
		public decimal? WherePat_date_last_visit { get; set; }
		private decimal? _wherePat_date_last_visit;
		public decimal? WherePat_date_last_admit { get; set; }
		private decimal? _wherePat_date_last_admit;
		public string WherePat_phone_nbr { get; set; }
		private string _wherePat_phone_nbr;
		public decimal? WherePat_total_nbr_visits { get; set; }
		private decimal? _wherePat_total_nbr_visits;
		public decimal? WherePat_total_nbr_claims { get; set; }
		private decimal? _wherePat_total_nbr_claims;
		public string WherePat_sex { get; set; }
		private string _wherePat_sex;
		public string WherePat_in_out { get; set; }
		private string _wherePat_in_out;
		public decimal? WherePat_nbr_outstanding_claims { get; set; }
		private decimal? _wherePat_nbr_outstanding_claims;
		public string WherePat_i_key { get; set; }
		private string _wherePat_i_key;
		public decimal? WherePat_con_nbr { get; set; }
		private decimal? _wherePat_con_nbr;
		public decimal? WherePat_i_nbr { get; set; }
		private decimal? _wherePat_i_nbr;
		public string WhereFiller4 { get; set; }
		private string _whereFiller4;
        public string WhereKey_pat_mstr { get; set; }
        private string _whereKey_pat_mstr;
        public decimal? WherePat_health_nbr { get; set; }
		private decimal? _wherePat_health_nbr;
		public string WherePat_version_cd { get; set; }
		private string _wherePat_version_cd;
		public string WherePat_health_65_ind { get; set; }
		private string _wherePat_health_65_ind;
		public decimal? WherePat_expiry_yy { get; set; }
		private decimal? _wherePat_expiry_yy;
		public decimal? WherePat_expiry_mm { get; set; }
		private decimal? _wherePat_expiry_mm;
		public string WherePat_prov_cd { get; set; }
		private string _wherePat_prov_cd;
		public string WhereSubscr_addr1 { get; set; }
		private string _whereSubscr_addr1;
		public string WhereSubscr_addr2 { get; set; }
		private string _whereSubscr_addr2;
		public string WhereSubscr_addr3 { get; set; }
		private string _whereSubscr_addr3;
		public string WhereSubscr_prov_cd { get; set; }
		private string _whereSubscr_prov_cd;
		public string WhereSubscr_post_cd1 { get; set; }
		private string _whereSubscr_post_cd1;
		public string WhereSubscr_post_cd2 { get; set; }
		private string _whereSubscr_post_cd2;
		public string WhereSubscr_post_cd3 { get; set; }
		private string _whereSubscr_post_cd3;
		public string WhereSubscr_post_cd4 { get; set; }
		private string _whereSubscr_post_cd4;
		public string WhereSubscr_post_cd5 { get; set; }
		private string _whereSubscr_post_cd5;
		public string WhereSubscr_post_cd6 { get; set; }
		private string _whereSubscr_post_cd6;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public string WhereSubscr_msg_nbr { get; set; }
		private string _whereSubscr_msg_nbr;
		public decimal? WhereSubscr_date_msg_nbr_effect_to_yy { get; set; }
		private decimal? _whereSubscr_date_msg_nbr_effect_to_yy;
		public decimal? WhereSubscr_date_msg_nbr_effect_to_mm { get; set; }
		private decimal? _whereSubscr_date_msg_nbr_effect_to_mm;
		public decimal? WhereSubscr_date_msg_nbr_effect_to_dd { get; set; }
		private decimal? _whereSubscr_date_msg_nbr_effect_to_dd;
		public decimal? WhereSubscr_date_last_statement_yy { get; set; }
		private decimal? _whereSubscr_date_last_statement_yy;
		public decimal? WhereSubscr_date_last_statement_mm { get; set; }
		private decimal? _whereSubscr_date_last_statement_mm;
		public decimal? WhereSubscr_date_last_statement_dd { get; set; }
		private decimal? _whereSubscr_date_last_statement_dd;
		public string WhereSubscr_auto_update { get; set; }
		private string _whereSubscr_auto_update;
		public string WherePat_last_mod_by { get; set; }
		private string _wherePat_last_mod_by;
		public decimal? WherePat_date_last_elig_mailing { get; set; }
		private decimal? _wherePat_date_last_elig_mailing;
		public decimal? WherePat_date_last_elig_maint { get; set; }
		private decimal? _wherePat_date_last_elig_maint;
		public decimal? WherePat_last_birth_date { get; set; }
		private decimal? _wherePat_last_birth_date;
		public string WherePat_last_version_cd { get; set; }
		private string _wherePat_last_version_cd;
		public string WherePat_mess_code { get; set; }
		private string _wherePat_mess_code;
		public string WherePat_country { get; set; }
		private string _wherePat_country;
		public decimal? WherePat_no_of_letter_sent { get; set; }
		private decimal? _wherePat_no_of_letter_sent;
		public string WherePat_dialysis { get; set; }
		private string _wherePat_dialysis;
		public string WherePat_ohip_validation_status { get; set; }
		private string _wherePat_ohip_validation_status;
		public string WherePat_obec_status { get; set; }
		private string _wherePat_obec_status;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalPat_acronym_first6;
		private string _originalPat_acronym_last3;
		private string _originalPat_direct_alpha;
		private decimal? _originalPat_direct_yy;
		private decimal? _originalPat_direct_mm;
		private decimal? _originalPat_direct_dd;
		private string _originalPat_direct_last_6;
		private string _originalPat_chart_nbr;
		private string _originalPat_chart_nbr_2;
		private string _originalPat_chart_nbr_3;
		private string _originalPat_chart_nbr_4;
		private string _originalPat_chart_nbr_5;
		private string _originalPat_surname_first3;
		private string _originalPat_surname_last22;
		private string _originalPat_given_name_first1;
		private string _originalFiller3;
		private string _originalPat_init1;
		private string _originalPat_init2;
		private string _originalPat_init3;
		private string _originalPat_location_field;
		private string _originalPat_last_doc_nbr_seen;
		private decimal? _originalPat_birth_date_yy;
		private decimal? _originalPat_birth_date_mm;
		private decimal? _originalPat_birth_date_dd;
		private decimal? _originalPat_date_last_maint;
		private decimal? _originalPat_date_last_visit;
		private decimal? _originalPat_date_last_admit;
		private string _originalPat_phone_nbr;
		private decimal? _originalPat_total_nbr_visits;
		private decimal? _originalPat_total_nbr_claims;
		private string _originalPat_sex;
		private string _originalPat_in_out;
		private decimal? _originalPat_nbr_outstanding_claims;
		private string _originalPat_i_key;
		private decimal? _originalPat_con_nbr;
		private decimal? _originalPat_i_nbr;
		private string _originalFiller4;
		private decimal? _originalPat_health_nbr;
		private string _originalPat_version_cd;
		private string _originalPat_health_65_ind;
		private decimal? _originalPat_expiry_yy;
		private decimal? _originalPat_expiry_mm;
		private string _originalPat_prov_cd;
		private string _originalSubscr_addr1;
		private string _originalSubscr_addr2;
		private string _originalSubscr_addr3;
		private string _originalSubscr_prov_cd;
		private string _originalSubscr_post_cd1;
		private string _originalSubscr_post_cd2;
		private string _originalSubscr_post_cd3;
		private string _originalSubscr_post_cd4;
		private string _originalSubscr_post_cd5;
		private string _originalSubscr_post_cd6;
		private string _originalFiller;
		private string _originalSubscr_msg_nbr;
		private decimal? _originalSubscr_date_msg_nbr_effect_to_yy;
		private decimal? _originalSubscr_date_msg_nbr_effect_to_mm;
		private decimal? _originalSubscr_date_msg_nbr_effect_to_dd;
		private decimal? _originalSubscr_date_last_statement_yy;
		private decimal? _originalSubscr_date_last_statement_mm;
		private decimal? _originalSubscr_date_last_statement_dd;
		private string _originalSubscr_auto_update;
		private string _originalPat_last_mod_by;
		private decimal? _originalPat_date_last_elig_mailing;
		private decimal? _originalPat_date_last_elig_maint;
		private decimal? _originalPat_last_birth_date;
		private string _originalPat_last_version_cd;
		private string _originalPat_mess_code;
		private string _originalPat_country;
		private decimal? _originalPat_no_of_letter_sent;
		private string _originalPat_dialysis;
		private string _originalPat_ohip_validation_status;
		private string _originalPat_obec_status;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			PAT_ACRONYM_FIRST6 = _originalPat_acronym_first6;
			PAT_ACRONYM_LAST3 = _originalPat_acronym_last3;
			PAT_DIRECT_ALPHA = _originalPat_direct_alpha;
			PAT_DIRECT_YY = _originalPat_direct_yy;
			PAT_DIRECT_MM = _originalPat_direct_mm;
			PAT_DIRECT_DD = _originalPat_direct_dd;
			PAT_DIRECT_LAST_6 = _originalPat_direct_last_6;
			PAT_CHART_NBR = _originalPat_chart_nbr;
			PAT_CHART_NBR_2 = _originalPat_chart_nbr_2;
			PAT_CHART_NBR_3 = _originalPat_chart_nbr_3;
			PAT_CHART_NBR_4 = _originalPat_chart_nbr_4;
			PAT_CHART_NBR_5 = _originalPat_chart_nbr_5;
			PAT_SURNAME_FIRST3 = _originalPat_surname_first3;
			PAT_SURNAME_LAST22 = _originalPat_surname_last22;
			PAT_GIVEN_NAME_FIRST1 = _originalPat_given_name_first1;
			FILLER3 = _originalFiller3;
			PAT_INIT1 = _originalPat_init1;
			PAT_INIT2 = _originalPat_init2;
			PAT_INIT3 = _originalPat_init3;
			PAT_LOCATION_FIELD = _originalPat_location_field;
			PAT_LAST_DOC_NBR_SEEN = _originalPat_last_doc_nbr_seen;
			PAT_BIRTH_DATE_YY = _originalPat_birth_date_yy;
			PAT_BIRTH_DATE_MM = _originalPat_birth_date_mm;
			PAT_BIRTH_DATE_DD = _originalPat_birth_date_dd;
			PAT_DATE_LAST_MAINT = _originalPat_date_last_maint;
			PAT_DATE_LAST_VISIT = _originalPat_date_last_visit;
			PAT_DATE_LAST_ADMIT = _originalPat_date_last_admit;
			PAT_PHONE_NBR = _originalPat_phone_nbr;
			PAT_TOTAL_NBR_VISITS = _originalPat_total_nbr_visits;
			PAT_TOTAL_NBR_CLAIMS = _originalPat_total_nbr_claims;
			PAT_SEX = _originalPat_sex;
			PAT_IN_OUT = _originalPat_in_out;
			PAT_NBR_OUTSTANDING_CLAIMS = _originalPat_nbr_outstanding_claims;
			PAT_I_KEY = _originalPat_i_key;
			PAT_CON_NBR = _originalPat_con_nbr;
			PAT_I_NBR = _originalPat_i_nbr;
			FILLER4 = _originalFiller4;
			PAT_HEALTH_NBR = _originalPat_health_nbr;
			PAT_VERSION_CD = _originalPat_version_cd;
			PAT_HEALTH_65_IND = _originalPat_health_65_ind;
			PAT_EXPIRY_YY = _originalPat_expiry_yy;
			PAT_EXPIRY_MM = _originalPat_expiry_mm;
			PAT_PROV_CD = _originalPat_prov_cd;
			SUBSCR_ADDR1 = _originalSubscr_addr1;
			SUBSCR_ADDR2 = _originalSubscr_addr2;
			SUBSCR_ADDR3 = _originalSubscr_addr3;
			SUBSCR_PROV_CD = _originalSubscr_prov_cd;
			SUBSCR_POST_CD1 = _originalSubscr_post_cd1;
			SUBSCR_POST_CD2 = _originalSubscr_post_cd2;
			SUBSCR_POST_CD3 = _originalSubscr_post_cd3;
			SUBSCR_POST_CD4 = _originalSubscr_post_cd4;
			SUBSCR_POST_CD5 = _originalSubscr_post_cd5;
			SUBSCR_POST_CD6 = _originalSubscr_post_cd6;
			FILLER = _originalFiller;
			SUBSCR_MSG_NBR = _originalSubscr_msg_nbr;
			SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = _originalSubscr_date_msg_nbr_effect_to_yy;
			SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = _originalSubscr_date_msg_nbr_effect_to_mm;
			SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = _originalSubscr_date_msg_nbr_effect_to_dd;
			SUBSCR_DATE_LAST_STATEMENT_YY = _originalSubscr_date_last_statement_yy;
			SUBSCR_DATE_LAST_STATEMENT_MM = _originalSubscr_date_last_statement_mm;
			SUBSCR_DATE_LAST_STATEMENT_DD = _originalSubscr_date_last_statement_dd;
			SUBSCR_AUTO_UPDATE = _originalSubscr_auto_update;
			PAT_LAST_MOD_BY = _originalPat_last_mod_by;
			PAT_DATE_LAST_ELIG_MAILING = _originalPat_date_last_elig_mailing;
			PAT_DATE_LAST_ELIG_MAINT = _originalPat_date_last_elig_maint;
			PAT_LAST_BIRTH_DATE = _originalPat_last_birth_date;
			PAT_LAST_VERSION_CD = _originalPat_last_version_cd;
			PAT_MESS_CODE = _originalPat_mess_code;
			PAT_COUNTRY = _originalPat_country;
			PAT_NO_OF_LETTER_SENT = _originalPat_no_of_letter_sent;
			PAT_DIALYSIS = _originalPat_dialysis;
			PAT_OHIP_VALIDATION_STATUS = _originalPat_ohip_validation_status;
			PAT_OBEC_STATUS = _originalPat_obec_status;
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
					new SqlParameter("PAT_I_KEY",PAT_I_KEY),
					new SqlParameter("PAT_CON_NBR",PAT_CON_NBR),
					new SqlParameter("PAT_I_NBR",PAT_I_NBR),
					new SqlParameter("FILLER4",FILLER4)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_PAT_MSTR_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F010_PAT_MSTR_Purge]");
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
						new SqlParameter("PAT_ACRONYM_FIRST6", SqlNull(PAT_ACRONYM_FIRST6)),
						new SqlParameter("PAT_ACRONYM_LAST3", SqlNull(PAT_ACRONYM_LAST3)),
						new SqlParameter("PAT_DIRECT_ALPHA", SqlNull(PAT_DIRECT_ALPHA)),
						new SqlParameter("PAT_DIRECT_YY", SqlNull(PAT_DIRECT_YY)),
						new SqlParameter("PAT_DIRECT_MM", SqlNull(PAT_DIRECT_MM)),
						new SqlParameter("PAT_DIRECT_DD", SqlNull(PAT_DIRECT_DD)),
						new SqlParameter("PAT_DIRECT_LAST_6", SqlNull(PAT_DIRECT_LAST_6)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_CHART_NBR_2", SqlNull(PAT_CHART_NBR_2)),
						new SqlParameter("PAT_CHART_NBR_3", SqlNull(PAT_CHART_NBR_3)),
						new SqlParameter("PAT_CHART_NBR_4", SqlNull(PAT_CHART_NBR_4)),
						new SqlParameter("PAT_CHART_NBR_5", SqlNull(PAT_CHART_NBR_5)),
						new SqlParameter("PAT_SURNAME_FIRST3", SqlNull(PAT_SURNAME_FIRST3)),
						new SqlParameter("PAT_SURNAME_LAST22", SqlNull(PAT_SURNAME_LAST22)),
						new SqlParameter("PAT_GIVEN_NAME_FIRST1", SqlNull(PAT_GIVEN_NAME_FIRST1)),
						new SqlParameter("FILLER3", SqlNull(FILLER3)),
						new SqlParameter("PAT_INIT1", SqlNull(PAT_INIT1)),
						new SqlParameter("PAT_INIT2", SqlNull(PAT_INIT2)),
						new SqlParameter("PAT_INIT3", SqlNull(PAT_INIT3)),
						new SqlParameter("PAT_LOCATION_FIELD", SqlNull(PAT_LOCATION_FIELD)),
						new SqlParameter("PAT_LAST_DOC_NBR_SEEN", SqlNull(PAT_LAST_DOC_NBR_SEEN)),
						new SqlParameter("PAT_BIRTH_DATE_YY", SqlNull(PAT_BIRTH_DATE_YY)),
						new SqlParameter("PAT_BIRTH_DATE_MM", SqlNull(PAT_BIRTH_DATE_MM)),
						new SqlParameter("PAT_BIRTH_DATE_DD", SqlNull(PAT_BIRTH_DATE_DD)),
						new SqlParameter("PAT_DATE_LAST_MAINT", SqlNull(PAT_DATE_LAST_MAINT)),
						new SqlParameter("PAT_DATE_LAST_VISIT", SqlNull(PAT_DATE_LAST_VISIT)),
						new SqlParameter("PAT_DATE_LAST_ADMIT", SqlNull(PAT_DATE_LAST_ADMIT)),
						new SqlParameter("PAT_PHONE_NBR", SqlNull(PAT_PHONE_NBR)),
						new SqlParameter("PAT_TOTAL_NBR_VISITS", SqlNull(PAT_TOTAL_NBR_VISITS)),
						new SqlParameter("PAT_TOTAL_NBR_CLAIMS", SqlNull(PAT_TOTAL_NBR_CLAIMS)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("PAT_IN_OUT", SqlNull(PAT_IN_OUT)),
						new SqlParameter("PAT_NBR_OUTSTANDING_CLAIMS", SqlNull(PAT_NBR_OUTSTANDING_CLAIMS)),
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_HEALTH_65_IND", SqlNull(PAT_HEALTH_65_IND)),
						new SqlParameter("PAT_EXPIRY_YY", SqlNull(PAT_EXPIRY_YY)),
						new SqlParameter("PAT_EXPIRY_MM", SqlNull(PAT_EXPIRY_MM)),
						new SqlParameter("PAT_PROV_CD", SqlNull(PAT_PROV_CD)),
						new SqlParameter("SUBSCR_ADDR1", SqlNull(SUBSCR_ADDR1)),
						new SqlParameter("SUBSCR_ADDR2", SqlNull(SUBSCR_ADDR2)),
						new SqlParameter("SUBSCR_ADDR3", SqlNull(SUBSCR_ADDR3)),
						new SqlParameter("SUBSCR_PROV_CD", SqlNull(SUBSCR_PROV_CD)),
						new SqlParameter("SUBSCR_POST_CD1", SqlNull(SUBSCR_POST_CD1)),
						new SqlParameter("SUBSCR_POST_CD2", SqlNull(SUBSCR_POST_CD2)),
						new SqlParameter("SUBSCR_POST_CD3", SqlNull(SUBSCR_POST_CD3)),
						new SqlParameter("SUBSCR_POST_CD4", SqlNull(SUBSCR_POST_CD4)),
						new SqlParameter("SUBSCR_POST_CD5", SqlNull(SUBSCR_POST_CD5)),
						new SqlParameter("SUBSCR_POST_CD6", SqlNull(SUBSCR_POST_CD6)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("SUBSCR_MSG_NBR", SqlNull(SUBSCR_MSG_NBR)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_YY", SqlNull(SUBSCR_DATE_LAST_STATEMENT_YY)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_MM", SqlNull(SUBSCR_DATE_LAST_STATEMENT_MM)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_DD", SqlNull(SUBSCR_DATE_LAST_STATEMENT_DD)),
						new SqlParameter("SUBSCR_AUTO_UPDATE", SqlNull(SUBSCR_AUTO_UPDATE)),
						new SqlParameter("PAT_LAST_MOD_BY", SqlNull(PAT_LAST_MOD_BY)),
						new SqlParameter("PAT_DATE_LAST_ELIG_MAILING", SqlNull(PAT_DATE_LAST_ELIG_MAILING)),
						new SqlParameter("PAT_DATE_LAST_ELIG_MAINT", SqlNull(PAT_DATE_LAST_ELIG_MAINT)),
						new SqlParameter("PAT_LAST_BIRTH_DATE", SqlNull(PAT_LAST_BIRTH_DATE)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_MESS_CODE", SqlNull(PAT_MESS_CODE)),
						new SqlParameter("PAT_COUNTRY", SqlNull(PAT_COUNTRY)),
						new SqlParameter("PAT_NO_OF_LETTER_SENT", SqlNull(PAT_NO_OF_LETTER_SENT)),
						new SqlParameter("PAT_DIALYSIS", SqlNull(PAT_DIALYSIS)),
						new SqlParameter("PAT_OHIP_VALIDATION_STATUS", SqlNull(PAT_OHIP_VALIDATION_STATUS)),
						new SqlParameter("PAT_OBEC_STATUS", SqlNull(PAT_OBEC_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						PAT_DIRECT_ALPHA = Reader["PAT_DIRECT_ALPHA"].ToString();
						PAT_DIRECT_YY = ConvertDEC(Reader["PAT_DIRECT_YY"]);
						PAT_DIRECT_MM = ConvertDEC(Reader["PAT_DIRECT_MM"]);
						PAT_DIRECT_DD = ConvertDEC(Reader["PAT_DIRECT_DD"]);
						PAT_DIRECT_LAST_6 = Reader["PAT_DIRECT_LAST_6"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString();
						PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString();
						PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString();
						PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString();
						PAT_SURNAME_FIRST3 = Reader["PAT_SURNAME_FIRST3"].ToString();
						PAT_SURNAME_LAST22 = Reader["PAT_SURNAME_LAST22"].ToString();
						PAT_GIVEN_NAME_FIRST1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString();
						FILLER3 = Reader["FILLER3"].ToString();
						PAT_INIT1 = Reader["PAT_INIT1"].ToString();
						PAT_INIT2 = Reader["PAT_INIT2"].ToString();
						PAT_INIT3 = Reader["PAT_INIT3"].ToString();
						PAT_LOCATION_FIELD = Reader["PAT_LOCATION_FIELD"].ToString();
						PAT_LAST_DOC_NBR_SEEN = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString();
						PAT_BIRTH_DATE_YY = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]);
						PAT_BIRTH_DATE_MM = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]);
						PAT_BIRTH_DATE_DD = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]);
						PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						PAT_DATE_LAST_VISIT = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]);
						PAT_DATE_LAST_ADMIT = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]);
						PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString();
						PAT_TOTAL_NBR_VISITS = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]);
						PAT_TOTAL_NBR_CLAIMS = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]);
						PAT_SEX = Reader["PAT_SEX"].ToString();
						PAT_IN_OUT = Reader["PAT_IN_OUT"].ToString();
						PAT_NBR_OUTSTANDING_CLAIMS = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]);
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_HEALTH_65_IND = Reader["PAT_HEALTH_65_IND"].ToString();
						PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString();
						SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString();
						SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString();
						SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString();
						SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString();
						SUBSCR_POST_CD1 = Reader["SUBSCR_POST_CD1"].ToString();
						SUBSCR_POST_CD2 = Reader["SUBSCR_POST_CD2"].ToString();
						SUBSCR_POST_CD3 = Reader["SUBSCR_POST_CD3"].ToString();
						SUBSCR_POST_CD4 = Reader["SUBSCR_POST_CD4"].ToString();
						SUBSCR_POST_CD5 = Reader["SUBSCR_POST_CD5"].ToString();
						SUBSCR_POST_CD6 = Reader["SUBSCR_POST_CD6"].ToString();
						FILLER = Reader["FILLER"].ToString();
						SUBSCR_MSG_NBR = Reader["SUBSCR_MSG_NBR"].ToString();
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]);
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]);
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]);
						SUBSCR_DATE_LAST_STATEMENT_YY = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]);
						SUBSCR_DATE_LAST_STATEMENT_MM = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]);
						SUBSCR_DATE_LAST_STATEMENT_DD = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]);
						SUBSCR_AUTO_UPDATE = Reader["SUBSCR_AUTO_UPDATE"].ToString();
						PAT_LAST_MOD_BY = Reader["PAT_LAST_MOD_BY"].ToString();
						PAT_DATE_LAST_ELIG_MAILING = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]);
						PAT_DATE_LAST_ELIG_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]);
						PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_MESS_CODE = Reader["PAT_MESS_CODE"].ToString();
						PAT_COUNTRY = Reader["PAT_COUNTRY"].ToString();
						PAT_NO_OF_LETTER_SENT = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]);
						PAT_DIALYSIS = Reader["PAT_DIALYSIS"].ToString();
						PAT_OHIP_VALIDATION_STATUS = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString();
						PAT_OBEC_STATUS = Reader["PAT_OBEC_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						_originalPat_direct_alpha = Reader["PAT_DIRECT_ALPHA"].ToString();
						_originalPat_direct_yy = ConvertDEC(Reader["PAT_DIRECT_YY"]);
						_originalPat_direct_mm = ConvertDEC(Reader["PAT_DIRECT_MM"]);
						_originalPat_direct_dd = ConvertDEC(Reader["PAT_DIRECT_DD"]);
						_originalPat_direct_last_6 = Reader["PAT_DIRECT_LAST_6"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString();
						_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString();
						_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString();
						_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString();
						_originalPat_surname_first3 = Reader["PAT_SURNAME_FIRST3"].ToString();
						_originalPat_surname_last22 = Reader["PAT_SURNAME_LAST22"].ToString();
						_originalPat_given_name_first1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString();
						_originalFiller3 = Reader["FILLER3"].ToString();
						_originalPat_init1 = Reader["PAT_INIT1"].ToString();
						_originalPat_init2 = Reader["PAT_INIT2"].ToString();
						_originalPat_init3 = Reader["PAT_INIT3"].ToString();
						_originalPat_location_field = Reader["PAT_LOCATION_FIELD"].ToString();
						_originalPat_last_doc_nbr_seen = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString();
						_originalPat_birth_date_yy = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]);
						_originalPat_birth_date_mm = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]);
						_originalPat_birth_date_dd = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]);
						_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						_originalPat_date_last_visit = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]);
						_originalPat_date_last_admit = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]);
						_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString();
						_originalPat_total_nbr_visits = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]);
						_originalPat_total_nbr_claims = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]);
						_originalPat_sex = Reader["PAT_SEX"].ToString();
						_originalPat_in_out = Reader["PAT_IN_OUT"].ToString();
						_originalPat_nbr_outstanding_claims = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]);
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_health_65_ind = Reader["PAT_HEALTH_65_IND"].ToString();
						_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString();
						_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString();
						_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString();
						_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString();
						_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString();
						_originalSubscr_post_cd1 = Reader["SUBSCR_POST_CD1"].ToString();
						_originalSubscr_post_cd2 = Reader["SUBSCR_POST_CD2"].ToString();
						_originalSubscr_post_cd3 = Reader["SUBSCR_POST_CD3"].ToString();
						_originalSubscr_post_cd4 = Reader["SUBSCR_POST_CD4"].ToString();
						_originalSubscr_post_cd5 = Reader["SUBSCR_POST_CD5"].ToString();
						_originalSubscr_post_cd6 = Reader["SUBSCR_POST_CD6"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalSubscr_msg_nbr = Reader["SUBSCR_MSG_NBR"].ToString();
						_originalSubscr_date_msg_nbr_effect_to_yy = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]);
						_originalSubscr_date_msg_nbr_effect_to_mm = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]);
						_originalSubscr_date_msg_nbr_effect_to_dd = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]);
						_originalSubscr_date_last_statement_yy = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]);
						_originalSubscr_date_last_statement_mm = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]);
						_originalSubscr_date_last_statement_dd = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]);
						_originalSubscr_auto_update = Reader["SUBSCR_AUTO_UPDATE"].ToString();
						_originalPat_last_mod_by = Reader["PAT_LAST_MOD_BY"].ToString();
						_originalPat_date_last_elig_mailing = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]);
						_originalPat_date_last_elig_maint = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]);
						_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_mess_code = Reader["PAT_MESS_CODE"].ToString();
						_originalPat_country = Reader["PAT_COUNTRY"].ToString();
						_originalPat_no_of_letter_sent = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]);
						_originalPat_dialysis = Reader["PAT_DIALYSIS"].ToString();
						_originalPat_ohip_validation_status = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString();
						_originalPat_obec_status = Reader["PAT_OBEC_STATUS"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("PAT_ACRONYM_FIRST6", SqlNull(PAT_ACRONYM_FIRST6)),
						new SqlParameter("PAT_ACRONYM_LAST3", SqlNull(PAT_ACRONYM_LAST3)),
						new SqlParameter("PAT_DIRECT_ALPHA", SqlNull(PAT_DIRECT_ALPHA)),
						new SqlParameter("PAT_DIRECT_YY", SqlNull(PAT_DIRECT_YY)),
						new SqlParameter("PAT_DIRECT_MM", SqlNull(PAT_DIRECT_MM)),
						new SqlParameter("PAT_DIRECT_DD", SqlNull(PAT_DIRECT_DD)),
						new SqlParameter("PAT_DIRECT_LAST_6", SqlNull(PAT_DIRECT_LAST_6)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_CHART_NBR_2", SqlNull(PAT_CHART_NBR_2)),
						new SqlParameter("PAT_CHART_NBR_3", SqlNull(PAT_CHART_NBR_3)),
						new SqlParameter("PAT_CHART_NBR_4", SqlNull(PAT_CHART_NBR_4)),
						new SqlParameter("PAT_CHART_NBR_5", SqlNull(PAT_CHART_NBR_5)),
						new SqlParameter("PAT_SURNAME_FIRST3", SqlNull(PAT_SURNAME_FIRST3)),
						new SqlParameter("PAT_SURNAME_LAST22", SqlNull(PAT_SURNAME_LAST22)),
						new SqlParameter("PAT_GIVEN_NAME_FIRST1", SqlNull(PAT_GIVEN_NAME_FIRST1)),
						new SqlParameter("FILLER3", SqlNull(FILLER3)),
						new SqlParameter("PAT_INIT1", SqlNull(PAT_INIT1)),
						new SqlParameter("PAT_INIT2", SqlNull(PAT_INIT2)),
						new SqlParameter("PAT_INIT3", SqlNull(PAT_INIT3)),
						new SqlParameter("PAT_LOCATION_FIELD", SqlNull(PAT_LOCATION_FIELD)),
						new SqlParameter("PAT_LAST_DOC_NBR_SEEN", SqlNull(PAT_LAST_DOC_NBR_SEEN)),
						new SqlParameter("PAT_BIRTH_DATE_YY", SqlNull(PAT_BIRTH_DATE_YY)),
						new SqlParameter("PAT_BIRTH_DATE_MM", SqlNull(PAT_BIRTH_DATE_MM)),
						new SqlParameter("PAT_BIRTH_DATE_DD", SqlNull(PAT_BIRTH_DATE_DD)),
						new SqlParameter("PAT_DATE_LAST_MAINT", SqlNull(PAT_DATE_LAST_MAINT)),
						new SqlParameter("PAT_DATE_LAST_VISIT", SqlNull(PAT_DATE_LAST_VISIT)),
						new SqlParameter("PAT_DATE_LAST_ADMIT", SqlNull(PAT_DATE_LAST_ADMIT)),
						new SqlParameter("PAT_PHONE_NBR", SqlNull(PAT_PHONE_NBR)),
						new SqlParameter("PAT_TOTAL_NBR_VISITS", SqlNull(PAT_TOTAL_NBR_VISITS)),
						new SqlParameter("PAT_TOTAL_NBR_CLAIMS", SqlNull(PAT_TOTAL_NBR_CLAIMS)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("PAT_IN_OUT", SqlNull(PAT_IN_OUT)),
						new SqlParameter("PAT_NBR_OUTSTANDING_CLAIMS", SqlNull(PAT_NBR_OUTSTANDING_CLAIMS)),
						new SqlParameter("PAT_I_KEY", SqlNull(PAT_I_KEY)),
						new SqlParameter("PAT_CON_NBR", SqlNull(PAT_CON_NBR)),
						new SqlParameter("PAT_I_NBR", SqlNull(PAT_I_NBR)),
						new SqlParameter("FILLER4", SqlNull(FILLER4)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_HEALTH_65_IND", SqlNull(PAT_HEALTH_65_IND)),
						new SqlParameter("PAT_EXPIRY_YY", SqlNull(PAT_EXPIRY_YY)),
						new SqlParameter("PAT_EXPIRY_MM", SqlNull(PAT_EXPIRY_MM)),
						new SqlParameter("PAT_PROV_CD", SqlNull(PAT_PROV_CD)),
						new SqlParameter("SUBSCR_ADDR1", SqlNull(SUBSCR_ADDR1)),
						new SqlParameter("SUBSCR_ADDR2", SqlNull(SUBSCR_ADDR2)),
						new SqlParameter("SUBSCR_ADDR3", SqlNull(SUBSCR_ADDR3)),
						new SqlParameter("SUBSCR_PROV_CD", SqlNull(SUBSCR_PROV_CD)),
						new SqlParameter("SUBSCR_POST_CD1", SqlNull(SUBSCR_POST_CD1)),
						new SqlParameter("SUBSCR_POST_CD2", SqlNull(SUBSCR_POST_CD2)),
						new SqlParameter("SUBSCR_POST_CD3", SqlNull(SUBSCR_POST_CD3)),
						new SqlParameter("SUBSCR_POST_CD4", SqlNull(SUBSCR_POST_CD4)),
						new SqlParameter("SUBSCR_POST_CD5", SqlNull(SUBSCR_POST_CD5)),
						new SqlParameter("SUBSCR_POST_CD6", SqlNull(SUBSCR_POST_CD6)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("SUBSCR_MSG_NBR", SqlNull(SUBSCR_MSG_NBR)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM)),
						new SqlParameter("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", SqlNull(SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_YY", SqlNull(SUBSCR_DATE_LAST_STATEMENT_YY)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_MM", SqlNull(SUBSCR_DATE_LAST_STATEMENT_MM)),
						new SqlParameter("SUBSCR_DATE_LAST_STATEMENT_DD", SqlNull(SUBSCR_DATE_LAST_STATEMENT_DD)),
						new SqlParameter("SUBSCR_AUTO_UPDATE", SqlNull(SUBSCR_AUTO_UPDATE)),
						new SqlParameter("PAT_LAST_MOD_BY", SqlNull(PAT_LAST_MOD_BY)),
						new SqlParameter("PAT_DATE_LAST_ELIG_MAILING", SqlNull(PAT_DATE_LAST_ELIG_MAILING)),
						new SqlParameter("PAT_DATE_LAST_ELIG_MAINT", SqlNull(PAT_DATE_LAST_ELIG_MAINT)),
						new SqlParameter("PAT_LAST_BIRTH_DATE", SqlNull(PAT_LAST_BIRTH_DATE)),
						new SqlParameter("PAT_LAST_VERSION_CD", SqlNull(PAT_LAST_VERSION_CD)),
						new SqlParameter("PAT_MESS_CODE", SqlNull(PAT_MESS_CODE)),
						new SqlParameter("PAT_COUNTRY", SqlNull(PAT_COUNTRY)),
						new SqlParameter("PAT_NO_OF_LETTER_SENT", SqlNull(PAT_NO_OF_LETTER_SENT)),
						new SqlParameter("PAT_DIALYSIS", SqlNull(PAT_DIALYSIS)),
						new SqlParameter("PAT_OHIP_VALIDATION_STATUS", SqlNull(PAT_OHIP_VALIDATION_STATUS)),
						new SqlParameter("PAT_OBEC_STATUS", SqlNull(PAT_OBEC_STATUS)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						PAT_ACRONYM_FIRST6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						PAT_ACRONYM_LAST3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						PAT_DIRECT_ALPHA = Reader["PAT_DIRECT_ALPHA"].ToString();
						PAT_DIRECT_YY = ConvertDEC(Reader["PAT_DIRECT_YY"]);
						PAT_DIRECT_MM = ConvertDEC(Reader["PAT_DIRECT_MM"]);
						PAT_DIRECT_DD = ConvertDEC(Reader["PAT_DIRECT_DD"]);
						PAT_DIRECT_LAST_6 = Reader["PAT_DIRECT_LAST_6"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString();
						PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString();
						PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString();
						PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString();
						PAT_SURNAME_FIRST3 = Reader["PAT_SURNAME_FIRST3"].ToString();
						PAT_SURNAME_LAST22 = Reader["PAT_SURNAME_LAST22"].ToString();
						PAT_GIVEN_NAME_FIRST1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString();
						FILLER3 = Reader["FILLER3"].ToString();
						PAT_INIT1 = Reader["PAT_INIT1"].ToString();
						PAT_INIT2 = Reader["PAT_INIT2"].ToString();
						PAT_INIT3 = Reader["PAT_INIT3"].ToString();
						PAT_LOCATION_FIELD = Reader["PAT_LOCATION_FIELD"].ToString();
						PAT_LAST_DOC_NBR_SEEN = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString();
						PAT_BIRTH_DATE_YY = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]);
						PAT_BIRTH_DATE_MM = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]);
						PAT_BIRTH_DATE_DD = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]);
						PAT_DATE_LAST_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						PAT_DATE_LAST_VISIT = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]);
						PAT_DATE_LAST_ADMIT = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]);
						PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString();
						PAT_TOTAL_NBR_VISITS = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]);
						PAT_TOTAL_NBR_CLAIMS = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]);
						PAT_SEX = Reader["PAT_SEX"].ToString();
						PAT_IN_OUT = Reader["PAT_IN_OUT"].ToString();
						PAT_NBR_OUTSTANDING_CLAIMS = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]);
						PAT_I_KEY = Reader["PAT_I_KEY"].ToString();
						PAT_CON_NBR = ConvertDEC(Reader["PAT_CON_NBR"]);
						PAT_I_NBR = ConvertDEC(Reader["PAT_I_NBR"]);
						FILLER4 = Reader["FILLER4"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_HEALTH_65_IND = Reader["PAT_HEALTH_65_IND"].ToString();
						PAT_EXPIRY_YY = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						PAT_EXPIRY_MM = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString();
						SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString();
						SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString();
						SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString();
						SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString();
						SUBSCR_POST_CD1 = Reader["SUBSCR_POST_CD1"].ToString();
						SUBSCR_POST_CD2 = Reader["SUBSCR_POST_CD2"].ToString();
						SUBSCR_POST_CD3 = Reader["SUBSCR_POST_CD3"].ToString();
						SUBSCR_POST_CD4 = Reader["SUBSCR_POST_CD4"].ToString();
						SUBSCR_POST_CD5 = Reader["SUBSCR_POST_CD5"].ToString();
						SUBSCR_POST_CD6 = Reader["SUBSCR_POST_CD6"].ToString();
						FILLER = Reader["FILLER"].ToString();
						SUBSCR_MSG_NBR = Reader["SUBSCR_MSG_NBR"].ToString();
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]);
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]);
						SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]);
						SUBSCR_DATE_LAST_STATEMENT_YY = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]);
						SUBSCR_DATE_LAST_STATEMENT_MM = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]);
						SUBSCR_DATE_LAST_STATEMENT_DD = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]);
						SUBSCR_AUTO_UPDATE = Reader["SUBSCR_AUTO_UPDATE"].ToString();
						PAT_LAST_MOD_BY = Reader["PAT_LAST_MOD_BY"].ToString();
						PAT_DATE_LAST_ELIG_MAILING = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]);
						PAT_DATE_LAST_ELIG_MAINT = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]);
						PAT_LAST_BIRTH_DATE = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						PAT_LAST_VERSION_CD = Reader["PAT_LAST_VERSION_CD"].ToString();
						PAT_MESS_CODE = Reader["PAT_MESS_CODE"].ToString();
						PAT_COUNTRY = Reader["PAT_COUNTRY"].ToString();
						PAT_NO_OF_LETTER_SENT = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]);
						PAT_DIALYSIS = Reader["PAT_DIALYSIS"].ToString();
						PAT_OHIP_VALIDATION_STATUS = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString();
						PAT_OBEC_STATUS = Reader["PAT_OBEC_STATUS"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalPat_acronym_first6 = Reader["PAT_ACRONYM_FIRST6"].ToString();
						_originalPat_acronym_last3 = Reader["PAT_ACRONYM_LAST3"].ToString();
						_originalPat_direct_alpha = Reader["PAT_DIRECT_ALPHA"].ToString();
						_originalPat_direct_yy = ConvertDEC(Reader["PAT_DIRECT_YY"]);
						_originalPat_direct_mm = ConvertDEC(Reader["PAT_DIRECT_MM"]);
						_originalPat_direct_dd = ConvertDEC(Reader["PAT_DIRECT_DD"]);
						_originalPat_direct_last_6 = Reader["PAT_DIRECT_LAST_6"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString();
						_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString();
						_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString();
						_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString();
						_originalPat_surname_first3 = Reader["PAT_SURNAME_FIRST3"].ToString();
						_originalPat_surname_last22 = Reader["PAT_SURNAME_LAST22"].ToString();
						_originalPat_given_name_first1 = Reader["PAT_GIVEN_NAME_FIRST1"].ToString();
						_originalFiller3 = Reader["FILLER3"].ToString();
						_originalPat_init1 = Reader["PAT_INIT1"].ToString();
						_originalPat_init2 = Reader["PAT_INIT2"].ToString();
						_originalPat_init3 = Reader["PAT_INIT3"].ToString();
						_originalPat_location_field = Reader["PAT_LOCATION_FIELD"].ToString();
						_originalPat_last_doc_nbr_seen = Reader["PAT_LAST_DOC_NBR_SEEN"].ToString();
						_originalPat_birth_date_yy = ConvertDEC(Reader["PAT_BIRTH_DATE_YY"]);
						_originalPat_birth_date_mm = ConvertDEC(Reader["PAT_BIRTH_DATE_MM"]);
						_originalPat_birth_date_dd = ConvertDEC(Reader["PAT_BIRTH_DATE_DD"]);
						_originalPat_date_last_maint = ConvertDEC(Reader["PAT_DATE_LAST_MAINT"]);
						_originalPat_date_last_visit = ConvertDEC(Reader["PAT_DATE_LAST_VISIT"]);
						_originalPat_date_last_admit = ConvertDEC(Reader["PAT_DATE_LAST_ADMIT"]);
						_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString();
						_originalPat_total_nbr_visits = ConvertDEC(Reader["PAT_TOTAL_NBR_VISITS"]);
						_originalPat_total_nbr_claims = ConvertDEC(Reader["PAT_TOTAL_NBR_CLAIMS"]);
						_originalPat_sex = Reader["PAT_SEX"].ToString();
						_originalPat_in_out = Reader["PAT_IN_OUT"].ToString();
						_originalPat_nbr_outstanding_claims = ConvertDEC(Reader["PAT_NBR_OUTSTANDING_CLAIMS"]);
						_originalPat_i_key = Reader["PAT_I_KEY"].ToString();
						_originalPat_con_nbr = ConvertDEC(Reader["PAT_CON_NBR"]);
						_originalPat_i_nbr = ConvertDEC(Reader["PAT_I_NBR"]);
						_originalFiller4 = Reader["FILLER4"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_health_65_ind = Reader["PAT_HEALTH_65_IND"].ToString();
						_originalPat_expiry_yy = ConvertDEC(Reader["PAT_EXPIRY_YY"]);
						_originalPat_expiry_mm = ConvertDEC(Reader["PAT_EXPIRY_MM"]);
						_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString();
						_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString();
						_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString();
						_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString();
						_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString();
						_originalSubscr_post_cd1 = Reader["SUBSCR_POST_CD1"].ToString();
						_originalSubscr_post_cd2 = Reader["SUBSCR_POST_CD2"].ToString();
						_originalSubscr_post_cd3 = Reader["SUBSCR_POST_CD3"].ToString();
						_originalSubscr_post_cd4 = Reader["SUBSCR_POST_CD4"].ToString();
						_originalSubscr_post_cd5 = Reader["SUBSCR_POST_CD5"].ToString();
						_originalSubscr_post_cd6 = Reader["SUBSCR_POST_CD6"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalSubscr_msg_nbr = Reader["SUBSCR_MSG_NBR"].ToString();
						_originalSubscr_date_msg_nbr_effect_to_yy = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"]);
						_originalSubscr_date_msg_nbr_effect_to_mm = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"]);
						_originalSubscr_date_msg_nbr_effect_to_dd = ConvertDEC(Reader["SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"]);
						_originalSubscr_date_last_statement_yy = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_YY"]);
						_originalSubscr_date_last_statement_mm = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_MM"]);
						_originalSubscr_date_last_statement_dd = ConvertDEC(Reader["SUBSCR_DATE_LAST_STATEMENT_DD"]);
						_originalSubscr_auto_update = Reader["SUBSCR_AUTO_UPDATE"].ToString();
						_originalPat_last_mod_by = Reader["PAT_LAST_MOD_BY"].ToString();
						_originalPat_date_last_elig_mailing = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAILING"]);
						_originalPat_date_last_elig_maint = ConvertDEC(Reader["PAT_DATE_LAST_ELIG_MAINT"]);
						_originalPat_last_birth_date = ConvertDEC(Reader["PAT_LAST_BIRTH_DATE"]);
						_originalPat_last_version_cd = Reader["PAT_LAST_VERSION_CD"].ToString();
						_originalPat_mess_code = Reader["PAT_MESS_CODE"].ToString();
						_originalPat_country = Reader["PAT_COUNTRY"].ToString();
						_originalPat_no_of_letter_sent = ConvertDEC(Reader["PAT_NO_OF_LETTER_SENT"]);
						_originalPat_dialysis = Reader["PAT_DIALYSIS"].ToString();
						_originalPat_ohip_validation_status = Reader["PAT_OHIP_VALIDATION_STATUS"].ToString();
						_originalPat_obec_status = Reader["PAT_OBEC_STATUS"].ToString();
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