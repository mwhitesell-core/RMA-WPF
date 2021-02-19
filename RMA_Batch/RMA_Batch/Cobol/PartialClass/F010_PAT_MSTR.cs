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
        public ObservableCollection<F010_PAT_MSTR> Collection_HealthNumber(ref bool isRetreiveRecord, ObservableCollection<F010_PAT_MSTR> f010_pat_mstr_Collection = null, int rows = 3000)
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
               .Append(" ,[CHECKSUM_VALUE]")
               .Append(" FROM ")
               .Append(" [INDEXED].[F010_PAT_MSTR]")
               .Append(" WHERE")
               .Append(" 1=1");

            if (WherePat_health_nbr != null)
            {
                sql.Append(" AND PAT_HEALTH_NBR = ").Append(WherePat_health_nbr);
            }

            sql.Append(" ORDER BY (PAT_I_KEY + CONVERT(varchar(2), PAT_CON_NBR) + CONVERT(varchar(12), PAT_I_NBR) + FILLER4) DESC");
            //  Debug.WriteLine(sql.ToString());

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
                    _originalChecksum_value = ConvertINT(Reader["RowCheckSum"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;

        }

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

            //  Debug.WriteLine(sql.ToString());

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

            //Debug.WriteLine(sql.ToString());

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

        public ObservableCollection<F010_PAT_MSTR> Collection_FirstTwo_GreaterOrEqual(ref bool isRetreiveRecord, ObservableCollection<F010_PAT_MSTR> f010_pat_mstr_Collection = null, int rows = 2)
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
                sql.Append(" AND (PAT_I_KEY + CONVERT(VARCHAR(2), PAT_CON_NBR) + CONVERT(VARCHAR(9), PAT_I_NBR)) >= '").Append(WhereKey_pat_mstr).Append("'");
            }

            //  Debug.WriteLine(sql.ToString());

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

        public ObservableCollection<F010_PAT_MSTR> Collection(ObservableCollection<F010_PAT_MSTR>
                                                            f010PatMstr = null, bool isClosedConnection = true, SqlConnection objConn = null)
        {
            if (IsSameSearch() && f010PatMstr != null)
            {
                return f010PatMstr;
            }

           /*  if (IsBlankSearch())
             {
                 ClearSearch();
                 return new ObservableCollection<F010_PAT_MSTR>();
             }  */

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

            if (!isClosedConnection)
            {
                Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Match]", parameters,objConn);
            }
            else
            {
                Reader = CoreReader("[INDEXED].[sp_F010_PAT_MSTR_Match]", parameters);
            }

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
            CloseConnection(isClosedConnection);
            return collection;
        }
    }
  
}
