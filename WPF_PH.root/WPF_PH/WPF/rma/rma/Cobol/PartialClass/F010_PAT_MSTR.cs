using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;
using System.Diagnostics;
using rma.Cobol;

namespace RmaDAL
{ 
    public partial class F010_PAT_MSTR
    {
        public ObservableCollection<F010_PAT_MSTR> Collection_UsingStart(ref bool isRetreiveRecord, ObservableCollection<F010_PAT_MSTR> f010_pat_mstr_Collection = null, int rows = 3000)
        {
            if (f010_pat_mstr_Collection != null)
            {
                F010_PAT_MSTR objF010_PAT_MSTR = f010_pat_mstr_Collection.FirstOrDefault();
                if (objF010_PAT_MSTR != null)
                {
                    WherePat_acronym_first6 = objF010_PAT_MSTR.PAT_ACRONYM_FIRST6;
                    WherePat_acronym_last3 = objF010_PAT_MSTR.PAT_ACRONYM_LAST3;

                    if (IsSameSearch())
                    {
                        isRetreiveRecord = false;
                        return f010_pat_mstr_Collection;
                    }
                }
            }

            var collection = new ObservableCollection<F010_PAT_MSTR>();
            isRetreiveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,ROWID")
               .Append(" ,[PAT_ACRONYM_FIRST6]")
               .Append(" ,[PAT_ACRONYM_LAST3]")
               .Append(" ,[PAT_DIRECT_ALPHA]")
               .Append(" ,[PAT_DIRECT_YY]")
               .Append(" ,[PAT_DIRECT_MM]")
               .Append(" ,[PAT_DIRECT_DD]")
               .Append(" ,[PAT_DIRECT_LAST_6]")
               .Append(" ,[PAT_CHART_NBR]")
               .Append(" ,[PAT_CHART_NBR_2]")
               .Append(" ,[PAT_CHART_NBR_3]")
               .Append(" ,[PAT_CHART_NBR_4]")
               .Append(" ,[PAT_CHART_NBR_5]")
               .Append(" ,[PAT_SURNAME_FIRST3]")
                .Append(" ,[PAT_SURNAME_LAST22]")
               .Append(" ,[PAT_GIVEN_NAME_FIRST1]")
               .Append(" ,[FILLER3]")
               .Append(" ,[PAT_INIT1]")
               .Append(" ,[PAT_INIT2]")
               .Append("  ,[PAT_INIT3]")
               .Append(" ,[PAT_LOCATION_FIELD]")
               .Append(" ,[PAT_LAST_DOC_NBR_SEEN]")
               .Append(" ,[PAT_BIRTH_DATE_YY]")
               .Append(" ,[PAT_BIRTH_DATE_MM]")
               .Append(" ,[PAT_BIRTH_DATE_DD]")
               .Append(" ,[PAT_DATE_LAST_MAINT]")
               .Append(" ,[PAT_DATE_LAST_VISIT]")
               .Append(" ,[PAT_DATE_LAST_ADMIT]")
               .Append(" ,[PAT_PHONE_NBR]")
               .Append(" ,[PAT_TOTAL_NBR_VISITS]")
               .Append(" ,[PAT_TOTAL_NBR_CLAIMS]")
               .Append(" ,[PAT_SEX]")
               .Append(" ,[PAT_IN_OUT]")
               .Append(" ,[PAT_NBR_OUTSTANDING_CLAIMS]")
               .Append(" ,[PAT_I_KEY]")
               .Append(" ,[PAT_CON_NBR]")
               .Append(" ,[PAT_I_NBR]")
               .Append(" ,[FILLER4]")
               .Append(" ,[PAT_HEALTH_NBR]")
               .Append(" ,[PAT_VERSION_CD]")
               .Append(" ,[PAT_HEALTH_65_IND]")
               .Append(" ,[PAT_EXPIRY_YY]")
               .Append(" ,[PAT_EXPIRY_MM]")
               .Append(" ,[PAT_PROV_CD]")
               .Append(" ,[SUBSCR_ADDR1]")
               .Append(" ,[SUBSCR_ADDR2]")
               .Append(" ,[SUBSCR_ADDR3]")
               .Append(" ,[SUBSCR_PROV_CD]")
               .Append(" ,[SUBSCR_POST_CD1]")
               .Append(" ,[SUBSCR_POST_CD2]")
               .Append(" ,[SUBSCR_POST_CD3]")
               .Append(" ,[SUBSCR_POST_CD4]")
               .Append(" ,[SUBSCR_POST_CD5]")
               .Append(" ,[SUBSCR_POST_CD6]")
               .Append(" ,[FILLER]")
               .Append(" ,[SUBSCR_MSG_NBR]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_YY]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_MM]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_DD]")
               .Append(" ,[SUBSCR_AUTO_UPDATE]")
               .Append(" ,[PAT_LAST_MOD_BY]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAILING]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAINT]")
               .Append(" ,[PAT_LAST_BIRTH_DATE]")
               .Append(" ,[PAT_LAST_VERSION_CD]")
               .Append(" ,[PAT_MESS_CODE]")
               .Append(" ,[PAT_COUNTRY]")
               .Append(" ,[PAT_NO_OF_LETTER_SENT]")
               .Append(" ,[PAT_DIALYSIS]")
               .Append(" ,[PAT_OHIP_VALIDATION_STATUS]")
               .Append(" ,[PAT_OBEC_STATUS]")
               .Append(" FROM ")
               .Append("  [INDEXED].[F010_PAT_MSTR]")
               .Append(" WHERE")
               .Append(" 1=1");

            if (!string.IsNullOrWhiteSpace(WherePat_acronym_first6))
            {
                sql.Append(" AND  PAT_ACRONYM_FIRST6 >= '").Append(WherePat_acronym_first6).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WherePat_acronym_last3))
            {
                sql.Append(" AND PAT_ACRONYM_LAST3 >= '").Append(WherePat_acronym_last3).Append("'");
            }

            if (!string.IsNullOrWhiteSpace(WherePat_direct_alpha))
            {
                sql.Append(" AND  PAT_DIRECT_ALPHA >= '").Append(WherePat_direct_alpha).Append("'");
            }

            if (Util.NumInt(WherePat_direct_yy) > 0)
            {
                sql.Append(" AND PAT_DIRECT_YY >=  ").Append(WherePat_direct_yy);
            }

            if (Util.NumInt(WherePat_direct_mm) > 0)
            {
                sql.Append(" AND PAT_DIRECT_MM >= ").Append(WherePat_direct_mm);
            }

            if (Util.NumInt(WherePat_direct_dd) > 0)
            {
                sql.Append(" AND PAT_DIRECT_DD >=  ").Append(WherePat_direct_dd);
            }

            if (!string.IsNullOrWhiteSpace(WherePat_i_key))
            {
                sql.Append(" AND  PAT_I_KEY >= '").Append(WherePat_i_key).Append("'");
            }

            if (WherePat_con_nbr != null)
            {
                sql.Append(" AND  PAT_CON_NBR >= ").Append(WherePat_con_nbr);
            }

            if (WherePat_i_nbr != null)
            {
                sql.Append(" AND PAT_I_NBR >= ").Append(WherePat_i_nbr);
            }

               Reader = CoreReader(sql.ToString());

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
                    CHECKSUM_VALUE = ConvertINT(Reader["RowCheckSum"]),

                    //_originalRowid = (Guid)Reader["ROWID"],
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
                    _originalChecksum_value = ConvertINT(Reader["RowCheckSum"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }

        public ObservableCollection<F010_PAT_MSTR> Collection_FirstTwo_LessOrEqual(ref bool isRetreiveRecord, ObservableCollection<F010_PAT_MSTR> f010_pat_mstr_Collection = null, int rows = 3000)
        {
            var collection = new ObservableCollection<F010_PAT_MSTR>();
            isRetreiveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
                .Append(" ,ROWID")
               .Append(" ,[PAT_ACRONYM_FIRST6]")
               .Append(" ,[PAT_ACRONYM_LAST3]")
               .Append(" ,[PAT_DIRECT_ALPHA]")
               .Append(" ,[PAT_DIRECT_YY]")
               .Append(" ,[PAT_DIRECT_MM]")
               .Append(" ,[PAT_DIRECT_DD]")
               .Append(" ,[PAT_DIRECT_LAST_6]")
               .Append(" ,[PAT_CHART_NBR]")
               .Append(" ,[PAT_CHART_NBR_2]")
               .Append(" ,[PAT_CHART_NBR_3]")
               .Append(" ,[PAT_CHART_NBR_4]")
               .Append(" ,[PAT_CHART_NBR_5]")
               .Append(" ,[PAT_SURNAME_FIRST3]")
                .Append(" ,[PAT_SURNAME_LAST22]")
               .Append(" ,[PAT_GIVEN_NAME_FIRST1]")
               .Append(" ,[FILLER3]")
               .Append(" ,[PAT_INIT1]")
               .Append(" ,[PAT_INIT2]")
               .Append("  ,[PAT_INIT3]")
               .Append(" ,[PAT_LOCATION_FIELD]")
               .Append(" ,[PAT_LAST_DOC_NBR_SEEN]")
               .Append(" ,[PAT_BIRTH_DATE_YY]")
               .Append(" ,[PAT_BIRTH_DATE_MM]")
               .Append(" ,[PAT_BIRTH_DATE_DD]")
               .Append(" ,[PAT_DATE_LAST_MAINT]")
               .Append(" ,[PAT_DATE_LAST_VISIT]")
               .Append(" ,[PAT_DATE_LAST_ADMIT]")
               .Append(" ,[PAT_PHONE_NBR]")
               .Append(" ,[PAT_TOTAL_NBR_VISITS]")
               .Append(" ,[PAT_TOTAL_NBR_CLAIMS]")
               .Append(" ,[PAT_SEX]")
               .Append(" ,[PAT_IN_OUT]")
               .Append(" ,[PAT_NBR_OUTSTANDING_CLAIMS]")
               .Append(" ,[PAT_I_KEY]")
               .Append(" ,[PAT_CON_NBR]")
               .Append(" ,[PAT_I_NBR]")
               .Append(" ,[FILLER4]")
               .Append(" ,[PAT_HEALTH_NBR]")
               .Append(" ,[PAT_VERSION_CD]")
               .Append(" ,[PAT_HEALTH_65_IND]")
               .Append(" ,[PAT_EXPIRY_YY]")
               .Append(" ,[PAT_EXPIRY_MM]")
               .Append(" ,[PAT_PROV_CD]")
               .Append(" ,[SUBSCR_ADDR1]")
               .Append(" ,[SUBSCR_ADDR2]")
               .Append(" ,[SUBSCR_ADDR3]")
               .Append(" ,[SUBSCR_PROV_CD]")
               .Append(" ,[SUBSCR_POST_CD1]")
               .Append(" ,[SUBSCR_POST_CD2]")
               .Append(" ,[SUBSCR_POST_CD3]")
               .Append(" ,[SUBSCR_POST_CD4]")
               .Append(" ,[SUBSCR_POST_CD5]")
               .Append(" ,[SUBSCR_POST_CD6]")
               .Append(" ,[FILLER]")
               .Append(" ,[SUBSCR_MSG_NBR]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_YY]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_MM]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_DD]")
               .Append(" ,[SUBSCR_AUTO_UPDATE]")
               .Append(" ,[PAT_LAST_MOD_BY]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAILING]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAINT]")
               .Append(" ,[PAT_LAST_BIRTH_DATE]")
               .Append(" ,[PAT_LAST_VERSION_CD]")
               .Append(" ,[PAT_MESS_CODE]")
               .Append(" ,[PAT_COUNTRY]")
               .Append(" ,[PAT_NO_OF_LETTER_SENT]")
               .Append(" ,[PAT_DIALYSIS]")
               .Append(" ,[PAT_OHIP_VALIDATION_STATUS]")
               .Append(" ,[PAT_OBEC_STATUS]")
               .Append(" FROM ")
               .Append("  [INDEXED].[F010_PAT_MSTR]")
               .Append(" WHERE")
               .Append(" 1=1");

            if (WhereKey_pat_mstr != null)
            {
                sql.Append(" AND (PAT_I_KEY + CONVERT(VARCHAR(2), PAT_CON_NBR) + CONVERT(VARCHAR(9), PAT_I_NBR)) <= '").Append(WhereKey_pat_mstr).Append("'");
            }

            Reader = CoreReader(sql.ToString());

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

                    //_originalRowid = (Guid)Reader["ROWID"],
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

        public ObservableCollection<F010_PAT_MSTR> Collection_FirstTwo_GreaterOrEqual(ref bool isRetreiveRecord, ObservableCollection<F010_PAT_MSTR> f010_pat_mstr_Collection = null, int rows = 3000)
        {
            var collection = new ObservableCollection<F010_PAT_MSTR>();
            isRetreiveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT TOP ").Append(rows)
                .Append(" BINARY_CHECKSUM AS [ROWCHECKSUM]")
                .Append(" ,ROWID")
               .Append(" ,[PAT_ACRONYM_FIRST6]")
               .Append(" ,[PAT_ACRONYM_LAST3]")
               .Append(" ,[PAT_DIRECT_ALPHA]")
               .Append(" ,[PAT_DIRECT_YY]")
               .Append(" ,[PAT_DIRECT_MM]")
               .Append(" ,[PAT_DIRECT_DD]")
               .Append(" ,[PAT_DIRECT_LAST_6]")
               .Append(" ,[PAT_CHART_NBR]")
               .Append(" ,[PAT_CHART_NBR_2]")
               .Append(" ,[PAT_CHART_NBR_3]")
               .Append(" ,[PAT_CHART_NBR_4]")
               .Append(" ,[PAT_CHART_NBR_5]")
               .Append(" ,[PAT_SURNAME_FIRST3]")
                .Append(" ,[PAT_SURNAME_LAST22]")
               .Append(" ,[PAT_GIVEN_NAME_FIRST1]")
               .Append(" ,[FILLER3]")
               .Append(" ,[PAT_INIT1]")
               .Append(" ,[PAT_INIT2]")
               .Append("  ,[PAT_INIT3]")
               .Append(" ,[PAT_LOCATION_FIELD]")
               .Append(" ,[PAT_LAST_DOC_NBR_SEEN]")
               .Append(" ,[PAT_BIRTH_DATE_YY]")
               .Append(" ,[PAT_BIRTH_DATE_MM]")
               .Append(" ,[PAT_BIRTH_DATE_DD]")
               .Append(" ,[PAT_DATE_LAST_MAINT]")
               .Append(" ,[PAT_DATE_LAST_VISIT]")
               .Append(" ,[PAT_DATE_LAST_ADMIT]")
               .Append(" ,[PAT_PHONE_NBR]")
               .Append(" ,[PAT_TOTAL_NBR_VISITS]")
               .Append(" ,[PAT_TOTAL_NBR_CLAIMS]")
               .Append(" ,[PAT_SEX]")
               .Append(" ,[PAT_IN_OUT]")
               .Append(" ,[PAT_NBR_OUTSTANDING_CLAIMS]")
               .Append(" ,[PAT_I_KEY]")
               .Append(" ,[PAT_CON_NBR]")
               .Append(" ,[PAT_I_NBR]")
               .Append(" ,[FILLER4]")
               .Append(" ,[PAT_HEALTH_NBR]")
               .Append(" ,[PAT_VERSION_CD]")
               .Append(" ,[PAT_HEALTH_65_IND]")
               .Append(" ,[PAT_EXPIRY_YY]")
               .Append(" ,[PAT_EXPIRY_MM]")
               .Append(" ,[PAT_PROV_CD]")
               .Append(" ,[SUBSCR_ADDR1]")
               .Append(" ,[SUBSCR_ADDR2]")
               .Append(" ,[SUBSCR_ADDR3]")
               .Append(" ,[SUBSCR_PROV_CD]")
               .Append(" ,[SUBSCR_POST_CD1]")
               .Append(" ,[SUBSCR_POST_CD2]")
               .Append(" ,[SUBSCR_POST_CD3]")
               .Append(" ,[SUBSCR_POST_CD4]")
               .Append(" ,[SUBSCR_POST_CD5]")
               .Append(" ,[SUBSCR_POST_CD6]")
               .Append(" ,[FILLER]")
               .Append(" ,[SUBSCR_MSG_NBR]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM]")
               .Append(" ,[SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_YY]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_MM]")
               .Append(" ,[SUBSCR_DATE_LAST_STATEMENT_DD]")
               .Append(" ,[SUBSCR_AUTO_UPDATE]")
               .Append(" ,[PAT_LAST_MOD_BY]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAILING]")
               .Append(" ,[PAT_DATE_LAST_ELIG_MAINT]")
               .Append(" ,[PAT_LAST_BIRTH_DATE]")
               .Append(" ,[PAT_LAST_VERSION_CD]")
               .Append(" ,[PAT_MESS_CODE]")
               .Append(" ,[PAT_COUNTRY]")
               .Append(" ,[PAT_NO_OF_LETTER_SENT]")
               .Append(" ,[PAT_DIALYSIS]")
               .Append(" ,[PAT_OHIP_VALIDATION_STATUS]")
               .Append(" ,[PAT_OBEC_STATUS]")
               .Append(" FROM ")
               .Append("  [INDEXED].[F010_PAT_MSTR]")
               .Append(" WHERE")
               .Append(" 1=1");

            if (WhereKey_pat_mstr != null)
            {
                sql.Append(" AND (PAT_I_KEY + CONVERT(VARCHAR(2), PAT_CON_NBR) + CONVERT(VARCHAR(9), PAT_I_NBR)) >= '").Append(WhereKey_pat_mstr).Append("'");
            }

            Reader = CoreReader(sql.ToString());

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

                    _originalRowid = (Guid)Reader["ROWID"],
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
    }
  
}
