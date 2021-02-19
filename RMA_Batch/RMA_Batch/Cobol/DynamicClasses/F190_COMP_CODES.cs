using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F190_COMP_CODES : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F190_COMP_CODES> Collection( Guid? rowid,
															string comp_code,
															string comp_type,
															string comp_owner,
															string desc_long,
															string desc_short,
															decimal? process_seqmin,
															decimal? process_seqmax,
															string units_dollars_flag,
															decimal? factormin,
															decimal? factormax,
															decimal? amt_employeemin,
															decimal? amt_employeemax,
															decimal? amt_employermin,
															decimal? amt_employermax,
															decimal? amt_taxablemin,
															decimal? amt_taxablemax,
															decimal? process_minmin,
															decimal? process_minmax,
															decimal? process_maxmin,
															decimal? process_maxmax,
															decimal? fiscal_maxmin,
															decimal? fiscal_maxmax,
															decimal? calendar_maxmin,
															decimal? calendar_maxmax,
															decimal? ltd_maxmin,
															decimal? ltd_maxmax,
															string affect_gross1,
															string affect_gross2,
															string affect_gross3,
															string affect_gross4,
															string affect_gross5,
															string affect_gross6,
															string affect_gross7,
															string affect_gross8,
															string affect_gross9,
															string affect_gross10,
															string affect_gross11,
															string affect_gross12,
															string affect_gross13,
															string affect_gross14,
															string affect_gross15,
															string affect_gross16,
															string affect_gross17,
															string affect_gross18,
															string affect_gross19,
															string affect_gross20,
															decimal? last_mod_datemin,
															decimal? last_mod_datemax,
															decimal? last_mod_timemin,
															decimal? last_mod_timemax,
															string last_mod_user_id,
															decimal? amt_per_unitmin,
															decimal? amt_per_unitmax,
															decimal? percent_pstmin,
															decimal? percent_pstmax,
															decimal? percent_gstmin,
															decimal? percent_gstmax,
															string comp_code_ytd,
															string comp_code_group,
															decimal? reporting_seqmin,
															decimal? reporting_seqmax,
															string comp_sub_type,
															string doc_class_type,
															string doc_operator,
															string doc_member_type,
															string dept_hosp_class_type,
															string dept_hosp_operator,
															string dept_hosp_member_type,
															decimal? reduction_factormin,
															decimal? reduction_factormax,
															string equity_rpt_col,
															string t4_net_tax_flag,
															string t4_net_pay_flag,
															string t4_net_deduc_flag,
															string doc_tax_rpt_flag,
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
					new SqlParameter("COMP_CODE",comp_code),
					new SqlParameter("COMP_TYPE",comp_type),
					new SqlParameter("COMP_OWNER",comp_owner),
					new SqlParameter("DESC_LONG",desc_long),
					new SqlParameter("DESC_SHORT",desc_short),
					new SqlParameter("minPROCESS_SEQ",process_seqmin),
					new SqlParameter("maxPROCESS_SEQ",process_seqmax),
					new SqlParameter("UNITS_DOLLARS_FLAG",units_dollars_flag),
					new SqlParameter("minFACTOR",factormin),
					new SqlParameter("maxFACTOR",factormax),
					new SqlParameter("minAMT_EMPLOYEE",amt_employeemin),
					new SqlParameter("maxAMT_EMPLOYEE",amt_employeemax),
					new SqlParameter("minAMT_EMPLOYER",amt_employermin),
					new SqlParameter("maxAMT_EMPLOYER",amt_employermax),
					new SqlParameter("minAMT_TAXABLE",amt_taxablemin),
					new SqlParameter("maxAMT_TAXABLE",amt_taxablemax),
					new SqlParameter("minPROCESS_MIN",process_minmin),
					new SqlParameter("maxPROCESS_MIN",process_minmax),
					new SqlParameter("minPROCESS_MAX",process_maxmin),
					new SqlParameter("maxPROCESS_MAX",process_maxmax),
					new SqlParameter("minFISCAL_MAX",fiscal_maxmin),
					new SqlParameter("maxFISCAL_MAX",fiscal_maxmax),
					new SqlParameter("minCALENDAR_MAX",calendar_maxmin),
					new SqlParameter("maxCALENDAR_MAX",calendar_maxmax),
					new SqlParameter("minLTD_MAX",ltd_maxmin),
					new SqlParameter("maxLTD_MAX",ltd_maxmax),
					new SqlParameter("AFFECT_GROSS1",affect_gross1),
					new SqlParameter("AFFECT_GROSS2",affect_gross2),
					new SqlParameter("AFFECT_GROSS3",affect_gross3),
					new SqlParameter("AFFECT_GROSS4",affect_gross4),
					new SqlParameter("AFFECT_GROSS5",affect_gross5),
					new SqlParameter("AFFECT_GROSS6",affect_gross6),
					new SqlParameter("AFFECT_GROSS7",affect_gross7),
					new SqlParameter("AFFECT_GROSS8",affect_gross8),
					new SqlParameter("AFFECT_GROSS9",affect_gross9),
					new SqlParameter("AFFECT_GROSS10",affect_gross10),
					new SqlParameter("AFFECT_GROSS11",affect_gross11),
					new SqlParameter("AFFECT_GROSS12",affect_gross12),
					new SqlParameter("AFFECT_GROSS13",affect_gross13),
					new SqlParameter("AFFECT_GROSS14",affect_gross14),
					new SqlParameter("AFFECT_GROSS15",affect_gross15),
					new SqlParameter("AFFECT_GROSS16",affect_gross16),
					new SqlParameter("AFFECT_GROSS17",affect_gross17),
					new SqlParameter("AFFECT_GROSS18",affect_gross18),
					new SqlParameter("AFFECT_GROSS19",affect_gross19),
					new SqlParameter("AFFECT_GROSS20",affect_gross20),
					new SqlParameter("minLAST_MOD_DATE",last_mod_datemin),
					new SqlParameter("maxLAST_MOD_DATE",last_mod_datemax),
					new SqlParameter("minLAST_MOD_TIME",last_mod_timemin),
					new SqlParameter("maxLAST_MOD_TIME",last_mod_timemax),
					new SqlParameter("LAST_MOD_USER_ID",last_mod_user_id),
					new SqlParameter("minAMT_PER_UNIT",amt_per_unitmin),
					new SqlParameter("maxAMT_PER_UNIT",amt_per_unitmax),
					new SqlParameter("minPERCENT_PST",percent_pstmin),
					new SqlParameter("maxPERCENT_PST",percent_pstmax),
					new SqlParameter("minPERCENT_GST",percent_gstmin),
					new SqlParameter("maxPERCENT_GST",percent_gstmax),
					new SqlParameter("COMP_CODE_YTD",comp_code_ytd),
					new SqlParameter("COMP_CODE_GROUP",comp_code_group),
					new SqlParameter("minREPORTING_SEQ",reporting_seqmin),
					new SqlParameter("maxREPORTING_SEQ",reporting_seqmax),
					new SqlParameter("COMP_SUB_TYPE",comp_sub_type),
					new SqlParameter("DOC_CLASS_TYPE",doc_class_type),
					new SqlParameter("DOC_OPERATOR",doc_operator),
					new SqlParameter("DOC_MEMBER_TYPE",doc_member_type),
					new SqlParameter("DEPT_HOSP_CLASS_TYPE",dept_hosp_class_type),
					new SqlParameter("DEPT_HOSP_OPERATOR",dept_hosp_operator),
					new SqlParameter("DEPT_HOSP_MEMBER_TYPE",dept_hosp_member_type),
					new SqlParameter("minREDUCTION_FACTOR",reduction_factormin),
					new SqlParameter("maxREDUCTION_FACTOR",reduction_factormax),
					new SqlParameter("EQUITY_RPT_COL",equity_rpt_col),
					new SqlParameter("T4_NET_TAX_FLAG",t4_net_tax_flag),
					new SqlParameter("T4_NET_PAY_FLAG",t4_net_pay_flag),
					new SqlParameter("T4_NET_DEDUC_FLAG",t4_net_deduc_flag),
					new SqlParameter("DOC_TAX_RPT_FLAG",doc_tax_rpt_flag),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F190_COMP_CODES_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F190_COMP_CODES>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F190_COMP_CODES_Search]", parameters);
            var collection = new ObservableCollection<F190_COMP_CODES>();

            while (Reader.Read())
            {
                collection.Add(new F190_COMP_CODES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					COMP_TYPE = Reader["COMP_TYPE"].ToString(),
					COMP_OWNER = Reader["COMP_OWNER"].ToString(),
					DESC_LONG = Reader["DESC_LONG"].ToString(),
					DESC_SHORT = Reader["DESC_SHORT"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					UNITS_DOLLARS_FLAG = Reader["UNITS_DOLLARS_FLAG"].ToString(),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					AMT_EMPLOYEE = ConvertDEC(Reader["AMT_EMPLOYEE"]),
					AMT_EMPLOYER = ConvertDEC(Reader["AMT_EMPLOYER"]),
					AMT_TAXABLE = ConvertDEC(Reader["AMT_TAXABLE"]),
					PROCESS_MIN = ConvertDEC(Reader["PROCESS_MIN"]),
					PROCESS_MAX = ConvertDEC(Reader["PROCESS_MAX"]),
					FISCAL_MAX = ConvertDEC(Reader["FISCAL_MAX"]),
					CALENDAR_MAX = ConvertDEC(Reader["CALENDAR_MAX"]),
					LTD_MAX = ConvertDEC(Reader["LTD_MAX"]),
					AFFECT_GROSS1 = Reader["AFFECT_GROSS1"].ToString(),
					AFFECT_GROSS2 = Reader["AFFECT_GROSS2"].ToString(),
					AFFECT_GROSS3 = Reader["AFFECT_GROSS3"].ToString(),
					AFFECT_GROSS4 = Reader["AFFECT_GROSS4"].ToString(),
					AFFECT_GROSS5 = Reader["AFFECT_GROSS5"].ToString(),
					AFFECT_GROSS6 = Reader["AFFECT_GROSS6"].ToString(),
					AFFECT_GROSS7 = Reader["AFFECT_GROSS7"].ToString(),
					AFFECT_GROSS8 = Reader["AFFECT_GROSS8"].ToString(),
					AFFECT_GROSS9 = Reader["AFFECT_GROSS9"].ToString(),
					AFFECT_GROSS10 = Reader["AFFECT_GROSS10"].ToString(),
					AFFECT_GROSS11 = Reader["AFFECT_GROSS11"].ToString(),
					AFFECT_GROSS12 = Reader["AFFECT_GROSS12"].ToString(),
					AFFECT_GROSS13 = Reader["AFFECT_GROSS13"].ToString(),
					AFFECT_GROSS14 = Reader["AFFECT_GROSS14"].ToString(),
					AFFECT_GROSS15 = Reader["AFFECT_GROSS15"].ToString(),
					AFFECT_GROSS16 = Reader["AFFECT_GROSS16"].ToString(),
					AFFECT_GROSS17 = Reader["AFFECT_GROSS17"].ToString(),
					AFFECT_GROSS18 = Reader["AFFECT_GROSS18"].ToString(),
					AFFECT_GROSS19 = Reader["AFFECT_GROSS19"].ToString(),
					AFFECT_GROSS20 = Reader["AFFECT_GROSS20"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					AMT_PER_UNIT = ConvertDEC(Reader["AMT_PER_UNIT"]),
					PERCENT_PST = ConvertDEC(Reader["PERCENT_PST"]),
					PERCENT_GST = ConvertDEC(Reader["PERCENT_GST"]),
					COMP_CODE_YTD = Reader["COMP_CODE_YTD"].ToString(),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]),
					COMP_SUB_TYPE = Reader["COMP_SUB_TYPE"].ToString(),
					DOC_CLASS_TYPE = Reader["DOC_CLASS_TYPE"].ToString(),
					DOC_OPERATOR = Reader["DOC_OPERATOR"].ToString(),
					DOC_MEMBER_TYPE = Reader["DOC_MEMBER_TYPE"].ToString(),
					DEPT_HOSP_CLASS_TYPE = Reader["DEPT_HOSP_CLASS_TYPE"].ToString(),
					DEPT_HOSP_OPERATOR = Reader["DEPT_HOSP_OPERATOR"].ToString(),
					DEPT_HOSP_MEMBER_TYPE = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString(),
					REDUCTION_FACTOR = ConvertDEC(Reader["REDUCTION_FACTOR"]),
					EQUITY_RPT_COL = Reader["EQUITY_RPT_COL"].ToString(),
					T4_NET_TAX_FLAG = Reader["T4_NET_TAX_FLAG"].ToString(),
					T4_NET_PAY_FLAG = Reader["T4_NET_PAY_FLAG"].ToString(),
					T4_NET_DEDUC_FLAG = Reader["T4_NET_DEDUC_FLAG"].ToString(),
					DOC_TAX_RPT_FLAG = Reader["DOC_TAX_RPT_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalComp_type = Reader["COMP_TYPE"].ToString(),
					_originalComp_owner = Reader["COMP_OWNER"].ToString(),
					_originalDesc_long = Reader["DESC_LONG"].ToString(),
					_originalDesc_short = Reader["DESC_SHORT"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalUnits_dollars_flag = Reader["UNITS_DOLLARS_FLAG"].ToString(),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalAmt_employee = ConvertDEC(Reader["AMT_EMPLOYEE"]),
					_originalAmt_employer = ConvertDEC(Reader["AMT_EMPLOYER"]),
					_originalAmt_taxable = ConvertDEC(Reader["AMT_TAXABLE"]),
					_originalProcess_min = ConvertDEC(Reader["PROCESS_MIN"]),
					_originalProcess_max = ConvertDEC(Reader["PROCESS_MAX"]),
					_originalFiscal_max = ConvertDEC(Reader["FISCAL_MAX"]),
					_originalCalendar_max = ConvertDEC(Reader["CALENDAR_MAX"]),
					_originalLtd_max = ConvertDEC(Reader["LTD_MAX"]),
					_originalAffect_gross1 = Reader["AFFECT_GROSS1"].ToString(),
					_originalAffect_gross2 = Reader["AFFECT_GROSS2"].ToString(),
					_originalAffect_gross3 = Reader["AFFECT_GROSS3"].ToString(),
					_originalAffect_gross4 = Reader["AFFECT_GROSS4"].ToString(),
					_originalAffect_gross5 = Reader["AFFECT_GROSS5"].ToString(),
					_originalAffect_gross6 = Reader["AFFECT_GROSS6"].ToString(),
					_originalAffect_gross7 = Reader["AFFECT_GROSS7"].ToString(),
					_originalAffect_gross8 = Reader["AFFECT_GROSS8"].ToString(),
					_originalAffect_gross9 = Reader["AFFECT_GROSS9"].ToString(),
					_originalAffect_gross10 = Reader["AFFECT_GROSS10"].ToString(),
					_originalAffect_gross11 = Reader["AFFECT_GROSS11"].ToString(),
					_originalAffect_gross12 = Reader["AFFECT_GROSS12"].ToString(),
					_originalAffect_gross13 = Reader["AFFECT_GROSS13"].ToString(),
					_originalAffect_gross14 = Reader["AFFECT_GROSS14"].ToString(),
					_originalAffect_gross15 = Reader["AFFECT_GROSS15"].ToString(),
					_originalAffect_gross16 = Reader["AFFECT_GROSS16"].ToString(),
					_originalAffect_gross17 = Reader["AFFECT_GROSS17"].ToString(),
					_originalAffect_gross18 = Reader["AFFECT_GROSS18"].ToString(),
					_originalAffect_gross19 = Reader["AFFECT_GROSS19"].ToString(),
					_originalAffect_gross20 = Reader["AFFECT_GROSS20"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalAmt_per_unit = ConvertDEC(Reader["AMT_PER_UNIT"]),
					_originalPercent_pst = ConvertDEC(Reader["PERCENT_PST"]),
					_originalPercent_gst = ConvertDEC(Reader["PERCENT_GST"]),
					_originalComp_code_ytd = Reader["COMP_CODE_YTD"].ToString(),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]),
					_originalComp_sub_type = Reader["COMP_SUB_TYPE"].ToString(),
					_originalDoc_class_type = Reader["DOC_CLASS_TYPE"].ToString(),
					_originalDoc_operator = Reader["DOC_OPERATOR"].ToString(),
					_originalDoc_member_type = Reader["DOC_MEMBER_TYPE"].ToString(),
					_originalDept_hosp_class_type = Reader["DEPT_HOSP_CLASS_TYPE"].ToString(),
					_originalDept_hosp_operator = Reader["DEPT_HOSP_OPERATOR"].ToString(),
					_originalDept_hosp_member_type = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString(),
					_originalReduction_factor = ConvertDEC(Reader["REDUCTION_FACTOR"]),
					_originalEquity_rpt_col = Reader["EQUITY_RPT_COL"].ToString(),
					_originalT4_net_tax_flag = Reader["T4_NET_TAX_FLAG"].ToString(),
					_originalT4_net_pay_flag = Reader["T4_NET_PAY_FLAG"].ToString(),
					_originalT4_net_deduc_flag = Reader["T4_NET_DEDUC_FLAG"].ToString(),
					_originalDoc_tax_rpt_flag = Reader["DOC_TAX_RPT_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F190_COMP_CODES Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F190_COMP_CODES> Collection(ObservableCollection<F190_COMP_CODES>
                                                               f190CompCodes = null)
        {
            if (IsSameSearch() && f190CompCodes != null)
            {
                return f190CompCodes;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F190_COMP_CODES>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("COMP_CODE",WhereComp_code),
					new SqlParameter("COMP_TYPE",WhereComp_type),
					new SqlParameter("COMP_OWNER",WhereComp_owner),
					new SqlParameter("DESC_LONG",WhereDesc_long),
					new SqlParameter("DESC_SHORT",WhereDesc_short),
					new SqlParameter("PROCESS_SEQ",WhereProcess_seq),
					new SqlParameter("UNITS_DOLLARS_FLAG",WhereUnits_dollars_flag),
					new SqlParameter("FACTOR",WhereFactor),
					new SqlParameter("AMT_EMPLOYEE",WhereAmt_employee),
					new SqlParameter("AMT_EMPLOYER",WhereAmt_employer),
					new SqlParameter("AMT_TAXABLE",WhereAmt_taxable),
					new SqlParameter("PROCESS_MIN",WhereProcess_min),
					new SqlParameter("PROCESS_MAX",WhereProcess_max),
					new SqlParameter("FISCAL_MAX",WhereFiscal_max),
					new SqlParameter("CALENDAR_MAX",WhereCalendar_max),
					new SqlParameter("LTD_MAX",WhereLtd_max),
					new SqlParameter("AFFECT_GROSS1",WhereAffect_gross1),
					new SqlParameter("AFFECT_GROSS2",WhereAffect_gross2),
					new SqlParameter("AFFECT_GROSS3",WhereAffect_gross3),
					new SqlParameter("AFFECT_GROSS4",WhereAffect_gross4),
					new SqlParameter("AFFECT_GROSS5",WhereAffect_gross5),
					new SqlParameter("AFFECT_GROSS6",WhereAffect_gross6),
					new SqlParameter("AFFECT_GROSS7",WhereAffect_gross7),
					new SqlParameter("AFFECT_GROSS8",WhereAffect_gross8),
					new SqlParameter("AFFECT_GROSS9",WhereAffect_gross9),
					new SqlParameter("AFFECT_GROSS10",WhereAffect_gross10),
					new SqlParameter("AFFECT_GROSS11",WhereAffect_gross11),
					new SqlParameter("AFFECT_GROSS12",WhereAffect_gross12),
					new SqlParameter("AFFECT_GROSS13",WhereAffect_gross13),
					new SqlParameter("AFFECT_GROSS14",WhereAffect_gross14),
					new SqlParameter("AFFECT_GROSS15",WhereAffect_gross15),
					new SqlParameter("AFFECT_GROSS16",WhereAffect_gross16),
					new SqlParameter("AFFECT_GROSS17",WhereAffect_gross17),
					new SqlParameter("AFFECT_GROSS18",WhereAffect_gross18),
					new SqlParameter("AFFECT_GROSS19",WhereAffect_gross19),
					new SqlParameter("AFFECT_GROSS20",WhereAffect_gross20),
					new SqlParameter("LAST_MOD_DATE",WhereLast_mod_date),
					new SqlParameter("LAST_MOD_TIME",WhereLast_mod_time),
					new SqlParameter("LAST_MOD_USER_ID",WhereLast_mod_user_id),
					new SqlParameter("AMT_PER_UNIT",WhereAmt_per_unit),
					new SqlParameter("PERCENT_PST",WherePercent_pst),
					new SqlParameter("PERCENT_GST",WherePercent_gst),
					new SqlParameter("COMP_CODE_YTD",WhereComp_code_ytd),
					new SqlParameter("COMP_CODE_GROUP",WhereComp_code_group),
					new SqlParameter("REPORTING_SEQ",WhereReporting_seq),
					new SqlParameter("COMP_SUB_TYPE",WhereComp_sub_type),
					new SqlParameter("DOC_CLASS_TYPE",WhereDoc_class_type),
					new SqlParameter("DOC_OPERATOR",WhereDoc_operator),
					new SqlParameter("DOC_MEMBER_TYPE",WhereDoc_member_type),
					new SqlParameter("DEPT_HOSP_CLASS_TYPE",WhereDept_hosp_class_type),
					new SqlParameter("DEPT_HOSP_OPERATOR",WhereDept_hosp_operator),
					new SqlParameter("DEPT_HOSP_MEMBER_TYPE",WhereDept_hosp_member_type),
					new SqlParameter("REDUCTION_FACTOR",WhereReduction_factor),
					new SqlParameter("EQUITY_RPT_COL",WhereEquity_rpt_col),
					new SqlParameter("T4_NET_TAX_FLAG",WhereT4_net_tax_flag),
					new SqlParameter("T4_NET_PAY_FLAG",WhereT4_net_pay_flag),
					new SqlParameter("T4_NET_DEDUC_FLAG",WhereT4_net_deduc_flag),
					new SqlParameter("DOC_TAX_RPT_FLAG",WhereDoc_tax_rpt_flag),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F190_COMP_CODES_Match]", parameters);
            var collection = new ObservableCollection<F190_COMP_CODES>();

            while (Reader.Read())
            {
                collection.Add(new F190_COMP_CODES
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					COMP_CODE = Reader["COMP_CODE"].ToString(),
					COMP_TYPE = Reader["COMP_TYPE"].ToString(),
					COMP_OWNER = Reader["COMP_OWNER"].ToString(),
					DESC_LONG = Reader["DESC_LONG"].ToString(),
					DESC_SHORT = Reader["DESC_SHORT"].ToString(),
					PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]),
					UNITS_DOLLARS_FLAG = Reader["UNITS_DOLLARS_FLAG"].ToString(),
					FACTOR = ConvertDEC(Reader["FACTOR"]),
					AMT_EMPLOYEE = ConvertDEC(Reader["AMT_EMPLOYEE"]),
					AMT_EMPLOYER = ConvertDEC(Reader["AMT_EMPLOYER"]),
					AMT_TAXABLE = ConvertDEC(Reader["AMT_TAXABLE"]),
					PROCESS_MIN = ConvertDEC(Reader["PROCESS_MIN"]),
					PROCESS_MAX = ConvertDEC(Reader["PROCESS_MAX"]),
					FISCAL_MAX = ConvertDEC(Reader["FISCAL_MAX"]),
					CALENDAR_MAX = ConvertDEC(Reader["CALENDAR_MAX"]),
					LTD_MAX = ConvertDEC(Reader["LTD_MAX"]),
					AFFECT_GROSS1 = Reader["AFFECT_GROSS1"].ToString(),
					AFFECT_GROSS2 = Reader["AFFECT_GROSS2"].ToString(),
					AFFECT_GROSS3 = Reader["AFFECT_GROSS3"].ToString(),
					AFFECT_GROSS4 = Reader["AFFECT_GROSS4"].ToString(),
					AFFECT_GROSS5 = Reader["AFFECT_GROSS5"].ToString(),
					AFFECT_GROSS6 = Reader["AFFECT_GROSS6"].ToString(),
					AFFECT_GROSS7 = Reader["AFFECT_GROSS7"].ToString(),
					AFFECT_GROSS8 = Reader["AFFECT_GROSS8"].ToString(),
					AFFECT_GROSS9 = Reader["AFFECT_GROSS9"].ToString(),
					AFFECT_GROSS10 = Reader["AFFECT_GROSS10"].ToString(),
					AFFECT_GROSS11 = Reader["AFFECT_GROSS11"].ToString(),
					AFFECT_GROSS12 = Reader["AFFECT_GROSS12"].ToString(),
					AFFECT_GROSS13 = Reader["AFFECT_GROSS13"].ToString(),
					AFFECT_GROSS14 = Reader["AFFECT_GROSS14"].ToString(),
					AFFECT_GROSS15 = Reader["AFFECT_GROSS15"].ToString(),
					AFFECT_GROSS16 = Reader["AFFECT_GROSS16"].ToString(),
					AFFECT_GROSS17 = Reader["AFFECT_GROSS17"].ToString(),
					AFFECT_GROSS18 = Reader["AFFECT_GROSS18"].ToString(),
					AFFECT_GROSS19 = Reader["AFFECT_GROSS19"].ToString(),
					AFFECT_GROSS20 = Reader["AFFECT_GROSS20"].ToString(),
					LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]),
					LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]),
					LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString(),
					AMT_PER_UNIT = ConvertDEC(Reader["AMT_PER_UNIT"]),
					PERCENT_PST = ConvertDEC(Reader["PERCENT_PST"]),
					PERCENT_GST = ConvertDEC(Reader["PERCENT_GST"]),
					COMP_CODE_YTD = Reader["COMP_CODE_YTD"].ToString(),
					COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString(),
					REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]),
					COMP_SUB_TYPE = Reader["COMP_SUB_TYPE"].ToString(),
					DOC_CLASS_TYPE = Reader["DOC_CLASS_TYPE"].ToString(),
					DOC_OPERATOR = Reader["DOC_OPERATOR"].ToString(),
					DOC_MEMBER_TYPE = Reader["DOC_MEMBER_TYPE"].ToString(),
					DEPT_HOSP_CLASS_TYPE = Reader["DEPT_HOSP_CLASS_TYPE"].ToString(),
					DEPT_HOSP_OPERATOR = Reader["DEPT_HOSP_OPERATOR"].ToString(),
					DEPT_HOSP_MEMBER_TYPE = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString(),
					REDUCTION_FACTOR = ConvertDEC(Reader["REDUCTION_FACTOR"]),
					EQUITY_RPT_COL = Reader["EQUITY_RPT_COL"].ToString(),
					T4_NET_TAX_FLAG = Reader["T4_NET_TAX_FLAG"].ToString(),
					T4_NET_PAY_FLAG = Reader["T4_NET_PAY_FLAG"].ToString(),
					T4_NET_DEDUC_FLAG = Reader["T4_NET_DEDUC_FLAG"].ToString(),
					DOC_TAX_RPT_FLAG = Reader["DOC_TAX_RPT_FLAG"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereComp_code = WhereComp_code,
					_whereComp_type = WhereComp_type,
					_whereComp_owner = WhereComp_owner,
					_whereDesc_long = WhereDesc_long,
					_whereDesc_short = WhereDesc_short,
					_whereProcess_seq = WhereProcess_seq,
					_whereUnits_dollars_flag = WhereUnits_dollars_flag,
					_whereFactor = WhereFactor,
					_whereAmt_employee = WhereAmt_employee,
					_whereAmt_employer = WhereAmt_employer,
					_whereAmt_taxable = WhereAmt_taxable,
					_whereProcess_min = WhereProcess_min,
					_whereProcess_max = WhereProcess_max,
					_whereFiscal_max = WhereFiscal_max,
					_whereCalendar_max = WhereCalendar_max,
					_whereLtd_max = WhereLtd_max,
					_whereAffect_gross1 = WhereAffect_gross1,
					_whereAffect_gross2 = WhereAffect_gross2,
					_whereAffect_gross3 = WhereAffect_gross3,
					_whereAffect_gross4 = WhereAffect_gross4,
					_whereAffect_gross5 = WhereAffect_gross5,
					_whereAffect_gross6 = WhereAffect_gross6,
					_whereAffect_gross7 = WhereAffect_gross7,
					_whereAffect_gross8 = WhereAffect_gross8,
					_whereAffect_gross9 = WhereAffect_gross9,
					_whereAffect_gross10 = WhereAffect_gross10,
					_whereAffect_gross11 = WhereAffect_gross11,
					_whereAffect_gross12 = WhereAffect_gross12,
					_whereAffect_gross13 = WhereAffect_gross13,
					_whereAffect_gross14 = WhereAffect_gross14,
					_whereAffect_gross15 = WhereAffect_gross15,
					_whereAffect_gross16 = WhereAffect_gross16,
					_whereAffect_gross17 = WhereAffect_gross17,
					_whereAffect_gross18 = WhereAffect_gross18,
					_whereAffect_gross19 = WhereAffect_gross19,
					_whereAffect_gross20 = WhereAffect_gross20,
					_whereLast_mod_date = WhereLast_mod_date,
					_whereLast_mod_time = WhereLast_mod_time,
					_whereLast_mod_user_id = WhereLast_mod_user_id,
					_whereAmt_per_unit = WhereAmt_per_unit,
					_wherePercent_pst = WherePercent_pst,
					_wherePercent_gst = WherePercent_gst,
					_whereComp_code_ytd = WhereComp_code_ytd,
					_whereComp_code_group = WhereComp_code_group,
					_whereReporting_seq = WhereReporting_seq,
					_whereComp_sub_type = WhereComp_sub_type,
					_whereDoc_class_type = WhereDoc_class_type,
					_whereDoc_operator = WhereDoc_operator,
					_whereDoc_member_type = WhereDoc_member_type,
					_whereDept_hosp_class_type = WhereDept_hosp_class_type,
					_whereDept_hosp_operator = WhereDept_hosp_operator,
					_whereDept_hosp_member_type = WhereDept_hosp_member_type,
					_whereReduction_factor = WhereReduction_factor,
					_whereEquity_rpt_col = WhereEquity_rpt_col,
					_whereT4_net_tax_flag = WhereT4_net_tax_flag,
					_whereT4_net_pay_flag = WhereT4_net_pay_flag,
					_whereT4_net_deduc_flag = WhereT4_net_deduc_flag,
					_whereDoc_tax_rpt_flag = WhereDoc_tax_rpt_flag,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalComp_code = Reader["COMP_CODE"].ToString(),
					_originalComp_type = Reader["COMP_TYPE"].ToString(),
					_originalComp_owner = Reader["COMP_OWNER"].ToString(),
					_originalDesc_long = Reader["DESC_LONG"].ToString(),
					_originalDesc_short = Reader["DESC_SHORT"].ToString(),
					_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]),
					_originalUnits_dollars_flag = Reader["UNITS_DOLLARS_FLAG"].ToString(),
					_originalFactor = ConvertDEC(Reader["FACTOR"]),
					_originalAmt_employee = ConvertDEC(Reader["AMT_EMPLOYEE"]),
					_originalAmt_employer = ConvertDEC(Reader["AMT_EMPLOYER"]),
					_originalAmt_taxable = ConvertDEC(Reader["AMT_TAXABLE"]),
					_originalProcess_min = ConvertDEC(Reader["PROCESS_MIN"]),
					_originalProcess_max = ConvertDEC(Reader["PROCESS_MAX"]),
					_originalFiscal_max = ConvertDEC(Reader["FISCAL_MAX"]),
					_originalCalendar_max = ConvertDEC(Reader["CALENDAR_MAX"]),
					_originalLtd_max = ConvertDEC(Reader["LTD_MAX"]),
					_originalAffect_gross1 = Reader["AFFECT_GROSS1"].ToString(),
					_originalAffect_gross2 = Reader["AFFECT_GROSS2"].ToString(),
					_originalAffect_gross3 = Reader["AFFECT_GROSS3"].ToString(),
					_originalAffect_gross4 = Reader["AFFECT_GROSS4"].ToString(),
					_originalAffect_gross5 = Reader["AFFECT_GROSS5"].ToString(),
					_originalAffect_gross6 = Reader["AFFECT_GROSS6"].ToString(),
					_originalAffect_gross7 = Reader["AFFECT_GROSS7"].ToString(),
					_originalAffect_gross8 = Reader["AFFECT_GROSS8"].ToString(),
					_originalAffect_gross9 = Reader["AFFECT_GROSS9"].ToString(),
					_originalAffect_gross10 = Reader["AFFECT_GROSS10"].ToString(),
					_originalAffect_gross11 = Reader["AFFECT_GROSS11"].ToString(),
					_originalAffect_gross12 = Reader["AFFECT_GROSS12"].ToString(),
					_originalAffect_gross13 = Reader["AFFECT_GROSS13"].ToString(),
					_originalAffect_gross14 = Reader["AFFECT_GROSS14"].ToString(),
					_originalAffect_gross15 = Reader["AFFECT_GROSS15"].ToString(),
					_originalAffect_gross16 = Reader["AFFECT_GROSS16"].ToString(),
					_originalAffect_gross17 = Reader["AFFECT_GROSS17"].ToString(),
					_originalAffect_gross18 = Reader["AFFECT_GROSS18"].ToString(),
					_originalAffect_gross19 = Reader["AFFECT_GROSS19"].ToString(),
					_originalAffect_gross20 = Reader["AFFECT_GROSS20"].ToString(),
					_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]),
					_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]),
					_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString(),
					_originalAmt_per_unit = ConvertDEC(Reader["AMT_PER_UNIT"]),
					_originalPercent_pst = ConvertDEC(Reader["PERCENT_PST"]),
					_originalPercent_gst = ConvertDEC(Reader["PERCENT_GST"]),
					_originalComp_code_ytd = Reader["COMP_CODE_YTD"].ToString(),
					_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString(),
					_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]),
					_originalComp_sub_type = Reader["COMP_SUB_TYPE"].ToString(),
					_originalDoc_class_type = Reader["DOC_CLASS_TYPE"].ToString(),
					_originalDoc_operator = Reader["DOC_OPERATOR"].ToString(),
					_originalDoc_member_type = Reader["DOC_MEMBER_TYPE"].ToString(),
					_originalDept_hosp_class_type = Reader["DEPT_HOSP_CLASS_TYPE"].ToString(),
					_originalDept_hosp_operator = Reader["DEPT_HOSP_OPERATOR"].ToString(),
					_originalDept_hosp_member_type = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString(),
					_originalReduction_factor = ConvertDEC(Reader["REDUCTION_FACTOR"]),
					_originalEquity_rpt_col = Reader["EQUITY_RPT_COL"].ToString(),
					_originalT4_net_tax_flag = Reader["T4_NET_TAX_FLAG"].ToString(),
					_originalT4_net_pay_flag = Reader["T4_NET_PAY_FLAG"].ToString(),
					_originalT4_net_deduc_flag = Reader["T4_NET_DEDUC_FLAG"].ToString(),
					_originalDoc_tax_rpt_flag = Reader["DOC_TAX_RPT_FLAG"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereComp_code = WhereComp_code;
					_whereComp_type = WhereComp_type;
					_whereComp_owner = WhereComp_owner;
					_whereDesc_long = WhereDesc_long;
					_whereDesc_short = WhereDesc_short;
					_whereProcess_seq = WhereProcess_seq;
					_whereUnits_dollars_flag = WhereUnits_dollars_flag;
					_whereFactor = WhereFactor;
					_whereAmt_employee = WhereAmt_employee;
					_whereAmt_employer = WhereAmt_employer;
					_whereAmt_taxable = WhereAmt_taxable;
					_whereProcess_min = WhereProcess_min;
					_whereProcess_max = WhereProcess_max;
					_whereFiscal_max = WhereFiscal_max;
					_whereCalendar_max = WhereCalendar_max;
					_whereLtd_max = WhereLtd_max;
					_whereAffect_gross1 = WhereAffect_gross1;
					_whereAffect_gross2 = WhereAffect_gross2;
					_whereAffect_gross3 = WhereAffect_gross3;
					_whereAffect_gross4 = WhereAffect_gross4;
					_whereAffect_gross5 = WhereAffect_gross5;
					_whereAffect_gross6 = WhereAffect_gross6;
					_whereAffect_gross7 = WhereAffect_gross7;
					_whereAffect_gross8 = WhereAffect_gross8;
					_whereAffect_gross9 = WhereAffect_gross9;
					_whereAffect_gross10 = WhereAffect_gross10;
					_whereAffect_gross11 = WhereAffect_gross11;
					_whereAffect_gross12 = WhereAffect_gross12;
					_whereAffect_gross13 = WhereAffect_gross13;
					_whereAffect_gross14 = WhereAffect_gross14;
					_whereAffect_gross15 = WhereAffect_gross15;
					_whereAffect_gross16 = WhereAffect_gross16;
					_whereAffect_gross17 = WhereAffect_gross17;
					_whereAffect_gross18 = WhereAffect_gross18;
					_whereAffect_gross19 = WhereAffect_gross19;
					_whereAffect_gross20 = WhereAffect_gross20;
					_whereLast_mod_date = WhereLast_mod_date;
					_whereLast_mod_time = WhereLast_mod_time;
					_whereLast_mod_user_id = WhereLast_mod_user_id;
					_whereAmt_per_unit = WhereAmt_per_unit;
					_wherePercent_pst = WherePercent_pst;
					_wherePercent_gst = WherePercent_gst;
					_whereComp_code_ytd = WhereComp_code_ytd;
					_whereComp_code_group = WhereComp_code_group;
					_whereReporting_seq = WhereReporting_seq;
					_whereComp_sub_type = WhereComp_sub_type;
					_whereDoc_class_type = WhereDoc_class_type;
					_whereDoc_operator = WhereDoc_operator;
					_whereDoc_member_type = WhereDoc_member_type;
					_whereDept_hosp_class_type = WhereDept_hosp_class_type;
					_whereDept_hosp_operator = WhereDept_hosp_operator;
					_whereDept_hosp_member_type = WhereDept_hosp_member_type;
					_whereReduction_factor = WhereReduction_factor;
					_whereEquity_rpt_col = WhereEquity_rpt_col;
					_whereT4_net_tax_flag = WhereT4_net_tax_flag;
					_whereT4_net_pay_flag = WhereT4_net_pay_flag;
					_whereT4_net_deduc_flag = WhereT4_net_deduc_flag;
					_whereDoc_tax_rpt_flag = WhereDoc_tax_rpt_flag;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereComp_code == null 
				&& WhereComp_type == null 
				&& WhereComp_owner == null 
				&& WhereDesc_long == null 
				&& WhereDesc_short == null 
				&& WhereProcess_seq == null 
				&& WhereUnits_dollars_flag == null 
				&& WhereFactor == null 
				&& WhereAmt_employee == null 
				&& WhereAmt_employer == null 
				&& WhereAmt_taxable == null 
				&& WhereProcess_min == null 
				&& WhereProcess_max == null 
				&& WhereFiscal_max == null 
				&& WhereCalendar_max == null 
				&& WhereLtd_max == null 
				&& WhereAffect_gross1 == null 
				&& WhereAffect_gross2 == null 
				&& WhereAffect_gross3 == null 
				&& WhereAffect_gross4 == null 
				&& WhereAffect_gross5 == null 
				&& WhereAffect_gross6 == null 
				&& WhereAffect_gross7 == null 
				&& WhereAffect_gross8 == null 
				&& WhereAffect_gross9 == null 
				&& WhereAffect_gross10 == null 
				&& WhereAffect_gross11 == null 
				&& WhereAffect_gross12 == null 
				&& WhereAffect_gross13 == null 
				&& WhereAffect_gross14 == null 
				&& WhereAffect_gross15 == null 
				&& WhereAffect_gross16 == null 
				&& WhereAffect_gross17 == null 
				&& WhereAffect_gross18 == null 
				&& WhereAffect_gross19 == null 
				&& WhereAffect_gross20 == null 
				&& WhereLast_mod_date == null 
				&& WhereLast_mod_time == null 
				&& WhereLast_mod_user_id == null 
				&& WhereAmt_per_unit == null 
				&& WherePercent_pst == null 
				&& WherePercent_gst == null 
				&& WhereComp_code_ytd == null 
				&& WhereComp_code_group == null 
				&& WhereReporting_seq == null 
				&& WhereComp_sub_type == null 
				&& WhereDoc_class_type == null 
				&& WhereDoc_operator == null 
				&& WhereDoc_member_type == null 
				&& WhereDept_hosp_class_type == null 
				&& WhereDept_hosp_operator == null 
				&& WhereDept_hosp_member_type == null 
				&& WhereReduction_factor == null 
				&& WhereEquity_rpt_col == null 
				&& WhereT4_net_tax_flag == null 
				&& WhereT4_net_pay_flag == null 
				&& WhereT4_net_deduc_flag == null 
				&& WhereDoc_tax_rpt_flag == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereComp_code ==  _whereComp_code
				&& WhereComp_type ==  _whereComp_type
				&& WhereComp_owner ==  _whereComp_owner
				&& WhereDesc_long ==  _whereDesc_long
				&& WhereDesc_short ==  _whereDesc_short
				&& WhereProcess_seq ==  _whereProcess_seq
				&& WhereUnits_dollars_flag ==  _whereUnits_dollars_flag
				&& WhereFactor ==  _whereFactor
				&& WhereAmt_employee ==  _whereAmt_employee
				&& WhereAmt_employer ==  _whereAmt_employer
				&& WhereAmt_taxable ==  _whereAmt_taxable
				&& WhereProcess_min ==  _whereProcess_min
				&& WhereProcess_max ==  _whereProcess_max
				&& WhereFiscal_max ==  _whereFiscal_max
				&& WhereCalendar_max ==  _whereCalendar_max
				&& WhereLtd_max ==  _whereLtd_max
				&& WhereAffect_gross1 ==  _whereAffect_gross1
				&& WhereAffect_gross2 ==  _whereAffect_gross2
				&& WhereAffect_gross3 ==  _whereAffect_gross3
				&& WhereAffect_gross4 ==  _whereAffect_gross4
				&& WhereAffect_gross5 ==  _whereAffect_gross5
				&& WhereAffect_gross6 ==  _whereAffect_gross6
				&& WhereAffect_gross7 ==  _whereAffect_gross7
				&& WhereAffect_gross8 ==  _whereAffect_gross8
				&& WhereAffect_gross9 ==  _whereAffect_gross9
				&& WhereAffect_gross10 ==  _whereAffect_gross10
				&& WhereAffect_gross11 ==  _whereAffect_gross11
				&& WhereAffect_gross12 ==  _whereAffect_gross12
				&& WhereAffect_gross13 ==  _whereAffect_gross13
				&& WhereAffect_gross14 ==  _whereAffect_gross14
				&& WhereAffect_gross15 ==  _whereAffect_gross15
				&& WhereAffect_gross16 ==  _whereAffect_gross16
				&& WhereAffect_gross17 ==  _whereAffect_gross17
				&& WhereAffect_gross18 ==  _whereAffect_gross18
				&& WhereAffect_gross19 ==  _whereAffect_gross19
				&& WhereAffect_gross20 ==  _whereAffect_gross20
				&& WhereLast_mod_date ==  _whereLast_mod_date
				&& WhereLast_mod_time ==  _whereLast_mod_time
				&& WhereLast_mod_user_id ==  _whereLast_mod_user_id
				&& WhereAmt_per_unit ==  _whereAmt_per_unit
				&& WherePercent_pst ==  _wherePercent_pst
				&& WherePercent_gst ==  _wherePercent_gst
				&& WhereComp_code_ytd ==  _whereComp_code_ytd
				&& WhereComp_code_group ==  _whereComp_code_group
				&& WhereReporting_seq ==  _whereReporting_seq
				&& WhereComp_sub_type ==  _whereComp_sub_type
				&& WhereDoc_class_type ==  _whereDoc_class_type
				&& WhereDoc_operator ==  _whereDoc_operator
				&& WhereDoc_member_type ==  _whereDoc_member_type
				&& WhereDept_hosp_class_type ==  _whereDept_hosp_class_type
				&& WhereDept_hosp_operator ==  _whereDept_hosp_operator
				&& WhereDept_hosp_member_type ==  _whereDept_hosp_member_type
				&& WhereReduction_factor ==  _whereReduction_factor
				&& WhereEquity_rpt_col ==  _whereEquity_rpt_col
				&& WhereT4_net_tax_flag ==  _whereT4_net_tax_flag
				&& WhereT4_net_pay_flag ==  _whereT4_net_pay_flag
				&& WhereT4_net_deduc_flag ==  _whereT4_net_deduc_flag
				&& WhereDoc_tax_rpt_flag ==  _whereDoc_tax_rpt_flag
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereComp_code = null; 
			WhereComp_type = null; 
			WhereComp_owner = null; 
			WhereDesc_long = null; 
			WhereDesc_short = null; 
			WhereProcess_seq = null; 
			WhereUnits_dollars_flag = null; 
			WhereFactor = null; 
			WhereAmt_employee = null; 
			WhereAmt_employer = null; 
			WhereAmt_taxable = null; 
			WhereProcess_min = null; 
			WhereProcess_max = null; 
			WhereFiscal_max = null; 
			WhereCalendar_max = null; 
			WhereLtd_max = null; 
			WhereAffect_gross1 = null; 
			WhereAffect_gross2 = null; 
			WhereAffect_gross3 = null; 
			WhereAffect_gross4 = null; 
			WhereAffect_gross5 = null; 
			WhereAffect_gross6 = null; 
			WhereAffect_gross7 = null; 
			WhereAffect_gross8 = null; 
			WhereAffect_gross9 = null; 
			WhereAffect_gross10 = null; 
			WhereAffect_gross11 = null; 
			WhereAffect_gross12 = null; 
			WhereAffect_gross13 = null; 
			WhereAffect_gross14 = null; 
			WhereAffect_gross15 = null; 
			WhereAffect_gross16 = null; 
			WhereAffect_gross17 = null; 
			WhereAffect_gross18 = null; 
			WhereAffect_gross19 = null; 
			WhereAffect_gross20 = null; 
			WhereLast_mod_date = null; 
			WhereLast_mod_time = null; 
			WhereLast_mod_user_id = null; 
			WhereAmt_per_unit = null; 
			WherePercent_pst = null; 
			WherePercent_gst = null; 
			WhereComp_code_ytd = null; 
			WhereComp_code_group = null; 
			WhereReporting_seq = null; 
			WhereComp_sub_type = null; 
			WhereDoc_class_type = null; 
			WhereDoc_operator = null; 
			WhereDoc_member_type = null; 
			WhereDept_hosp_class_type = null; 
			WhereDept_hosp_operator = null; 
			WhereDept_hosp_member_type = null; 
			WhereReduction_factor = null; 
			WhereEquity_rpt_col = null; 
			WhereT4_net_tax_flag = null; 
			WhereT4_net_pay_flag = null; 
			WhereT4_net_deduc_flag = null; 
			WhereDoc_tax_rpt_flag = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _COMP_CODE;
		private string _COMP_TYPE;
		private string _COMP_OWNER;
		private string _DESC_LONG;
		private string _DESC_SHORT;
		private decimal? _PROCESS_SEQ;
		private string _UNITS_DOLLARS_FLAG;
		private decimal? _FACTOR;
		private decimal? _AMT_EMPLOYEE;
		private decimal? _AMT_EMPLOYER;
		private decimal? _AMT_TAXABLE;
		private decimal? _PROCESS_MIN;
		private decimal? _PROCESS_MAX;
		private decimal? _FISCAL_MAX;
		private decimal? _CALENDAR_MAX;
		private decimal? _LTD_MAX;
		private string _AFFECT_GROSS1;
		private string _AFFECT_GROSS2;
		private string _AFFECT_GROSS3;
		private string _AFFECT_GROSS4;
		private string _AFFECT_GROSS5;
		private string _AFFECT_GROSS6;
		private string _AFFECT_GROSS7;
		private string _AFFECT_GROSS8;
		private string _AFFECT_GROSS9;
		private string _AFFECT_GROSS10;
		private string _AFFECT_GROSS11;
		private string _AFFECT_GROSS12;
		private string _AFFECT_GROSS13;
		private string _AFFECT_GROSS14;
		private string _AFFECT_GROSS15;
		private string _AFFECT_GROSS16;
		private string _AFFECT_GROSS17;
		private string _AFFECT_GROSS18;
		private string _AFFECT_GROSS19;
		private string _AFFECT_GROSS20;
		private decimal? _LAST_MOD_DATE;
		private decimal? _LAST_MOD_TIME;
		private string _LAST_MOD_USER_ID;
		private decimal? _AMT_PER_UNIT;
		private decimal? _PERCENT_PST;
		private decimal? _PERCENT_GST;
		private string _COMP_CODE_YTD;
		private string _COMP_CODE_GROUP;
		private decimal? _REPORTING_SEQ;
		private string _COMP_SUB_TYPE;
		private string _DOC_CLASS_TYPE;
		private string _DOC_OPERATOR;
		private string _DOC_MEMBER_TYPE;
		private string _DEPT_HOSP_CLASS_TYPE;
		private string _DEPT_HOSP_OPERATOR;
		private string _DEPT_HOSP_MEMBER_TYPE;
		private decimal? _REDUCTION_FACTOR;
		private string _EQUITY_RPT_COL;
		private string _T4_NET_TAX_FLAG;
		private string _T4_NET_PAY_FLAG;
		private string _T4_NET_DEDUC_FLAG;
		private string _DOC_TAX_RPT_FLAG;
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
		public string COMP_CODE
		{
			get { return _COMP_CODE; }
			set
			{
				if (_COMP_CODE != value)
				{
					_COMP_CODE = value;
					ChangeState();
				}
			}
		}
		public string COMP_TYPE
		{
			get { return _COMP_TYPE; }
			set
			{
				if (_COMP_TYPE != value)
				{
					_COMP_TYPE = value;
					ChangeState();
				}
			}
		}
		public string COMP_OWNER
		{
			get { return _COMP_OWNER; }
			set
			{
				if (_COMP_OWNER != value)
				{
					_COMP_OWNER = value;
					ChangeState();
				}
			}
		}
		public string DESC_LONG
		{
			get { return _DESC_LONG; }
			set
			{
				if (_DESC_LONG != value)
				{
					_DESC_LONG = value;
					ChangeState();
				}
			}
		}
		public string DESC_SHORT
		{
			get { return _DESC_SHORT; }
			set
			{
				if (_DESC_SHORT != value)
				{
					_DESC_SHORT = value;
					ChangeState();
				}
			}
		}
		public decimal? PROCESS_SEQ
		{
			get { return _PROCESS_SEQ; }
			set
			{
				if (_PROCESS_SEQ != value)
				{
					_PROCESS_SEQ = value;
					ChangeState();
				}
			}
		}
		public string UNITS_DOLLARS_FLAG
		{
			get { return _UNITS_DOLLARS_FLAG; }
			set
			{
				if (_UNITS_DOLLARS_FLAG != value)
				{
					_UNITS_DOLLARS_FLAG = value;
					ChangeState();
				}
			}
		}
		public decimal? FACTOR
		{
			get { return _FACTOR; }
			set
			{
				if (_FACTOR != value)
				{
					_FACTOR = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_EMPLOYEE
		{
			get { return _AMT_EMPLOYEE; }
			set
			{
				if (_AMT_EMPLOYEE != value)
				{
					_AMT_EMPLOYEE = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_EMPLOYER
		{
			get { return _AMT_EMPLOYER; }
			set
			{
				if (_AMT_EMPLOYER != value)
				{
					_AMT_EMPLOYER = value;
					ChangeState();
				}
			}
		}
		public decimal? AMT_TAXABLE
		{
			get { return _AMT_TAXABLE; }
			set
			{
				if (_AMT_TAXABLE != value)
				{
					_AMT_TAXABLE = value;
					ChangeState();
				}
			}
		}
		public decimal? PROCESS_MIN
		{
			get { return _PROCESS_MIN; }
			set
			{
				if (_PROCESS_MIN != value)
				{
					_PROCESS_MIN = value;
					ChangeState();
				}
			}
		}
		public decimal? PROCESS_MAX
		{
			get { return _PROCESS_MAX; }
			set
			{
				if (_PROCESS_MAX != value)
				{
					_PROCESS_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? FISCAL_MAX
		{
			get { return _FISCAL_MAX; }
			set
			{
				if (_FISCAL_MAX != value)
				{
					_FISCAL_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? CALENDAR_MAX
		{
			get { return _CALENDAR_MAX; }
			set
			{
				if (_CALENDAR_MAX != value)
				{
					_CALENDAR_MAX = value;
					ChangeState();
				}
			}
		}
		public decimal? LTD_MAX
		{
			get { return _LTD_MAX; }
			set
			{
				if (_LTD_MAX != value)
				{
					_LTD_MAX = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS1
		{
			get { return _AFFECT_GROSS1; }
			set
			{
				if (_AFFECT_GROSS1 != value)
				{
					_AFFECT_GROSS1 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS2
		{
			get { return _AFFECT_GROSS2; }
			set
			{
				if (_AFFECT_GROSS2 != value)
				{
					_AFFECT_GROSS2 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS3
		{
			get { return _AFFECT_GROSS3; }
			set
			{
				if (_AFFECT_GROSS3 != value)
				{
					_AFFECT_GROSS3 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS4
		{
			get { return _AFFECT_GROSS4; }
			set
			{
				if (_AFFECT_GROSS4 != value)
				{
					_AFFECT_GROSS4 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS5
		{
			get { return _AFFECT_GROSS5; }
			set
			{
				if (_AFFECT_GROSS5 != value)
				{
					_AFFECT_GROSS5 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS6
		{
			get { return _AFFECT_GROSS6; }
			set
			{
				if (_AFFECT_GROSS6 != value)
				{
					_AFFECT_GROSS6 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS7
		{
			get { return _AFFECT_GROSS7; }
			set
			{
				if (_AFFECT_GROSS7 != value)
				{
					_AFFECT_GROSS7 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS8
		{
			get { return _AFFECT_GROSS8; }
			set
			{
				if (_AFFECT_GROSS8 != value)
				{
					_AFFECT_GROSS8 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS9
		{
			get { return _AFFECT_GROSS9; }
			set
			{
				if (_AFFECT_GROSS9 != value)
				{
					_AFFECT_GROSS9 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS10
		{
			get { return _AFFECT_GROSS10; }
			set
			{
				if (_AFFECT_GROSS10 != value)
				{
					_AFFECT_GROSS10 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS11
		{
			get { return _AFFECT_GROSS11; }
			set
			{
				if (_AFFECT_GROSS11 != value)
				{
					_AFFECT_GROSS11 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS12
		{
			get { return _AFFECT_GROSS12; }
			set
			{
				if (_AFFECT_GROSS12 != value)
				{
					_AFFECT_GROSS12 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS13
		{
			get { return _AFFECT_GROSS13; }
			set
			{
				if (_AFFECT_GROSS13 != value)
				{
					_AFFECT_GROSS13 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS14
		{
			get { return _AFFECT_GROSS14; }
			set
			{
				if (_AFFECT_GROSS14 != value)
				{
					_AFFECT_GROSS14 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS15
		{
			get { return _AFFECT_GROSS15; }
			set
			{
				if (_AFFECT_GROSS15 != value)
				{
					_AFFECT_GROSS15 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS16
		{
			get { return _AFFECT_GROSS16; }
			set
			{
				if (_AFFECT_GROSS16 != value)
				{
					_AFFECT_GROSS16 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS17
		{
			get { return _AFFECT_GROSS17; }
			set
			{
				if (_AFFECT_GROSS17 != value)
				{
					_AFFECT_GROSS17 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS18
		{
			get { return _AFFECT_GROSS18; }
			set
			{
				if (_AFFECT_GROSS18 != value)
				{
					_AFFECT_GROSS18 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS19
		{
			get { return _AFFECT_GROSS19; }
			set
			{
				if (_AFFECT_GROSS19 != value)
				{
					_AFFECT_GROSS19 = value;
					ChangeState();
				}
			}
		}
		public string AFFECT_GROSS20
		{
			get { return _AFFECT_GROSS20; }
			set
			{
				if (_AFFECT_GROSS20 != value)
				{
					_AFFECT_GROSS20 = value;
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
		public decimal? AMT_PER_UNIT
		{
			get { return _AMT_PER_UNIT; }
			set
			{
				if (_AMT_PER_UNIT != value)
				{
					_AMT_PER_UNIT = value;
					ChangeState();
				}
			}
		}
		public decimal? PERCENT_PST
		{
			get { return _PERCENT_PST; }
			set
			{
				if (_PERCENT_PST != value)
				{
					_PERCENT_PST = value;
					ChangeState();
				}
			}
		}
		public decimal? PERCENT_GST
		{
			get { return _PERCENT_GST; }
			set
			{
				if (_PERCENT_GST != value)
				{
					_PERCENT_GST = value;
					ChangeState();
				}
			}
		}
		public string COMP_CODE_YTD
		{
			get { return _COMP_CODE_YTD; }
			set
			{
				if (_COMP_CODE_YTD != value)
				{
					_COMP_CODE_YTD = value;
					ChangeState();
				}
			}
		}
		public string COMP_CODE_GROUP
		{
			get { return _COMP_CODE_GROUP; }
			set
			{
				if (_COMP_CODE_GROUP != value)
				{
					_COMP_CODE_GROUP = value;
					ChangeState();
				}
			}
		}
		public decimal? REPORTING_SEQ
		{
			get { return _REPORTING_SEQ; }
			set
			{
				if (_REPORTING_SEQ != value)
				{
					_REPORTING_SEQ = value;
					ChangeState();
				}
			}
		}
		public string COMP_SUB_TYPE
		{
			get { return _COMP_SUB_TYPE; }
			set
			{
				if (_COMP_SUB_TYPE != value)
				{
					_COMP_SUB_TYPE = value;
					ChangeState();
				}
			}
		}
		public string DOC_CLASS_TYPE
		{
			get { return _DOC_CLASS_TYPE; }
			set
			{
				if (_DOC_CLASS_TYPE != value)
				{
					_DOC_CLASS_TYPE = value;
					ChangeState();
				}
			}
		}
		public string DOC_OPERATOR
		{
			get { return _DOC_OPERATOR; }
			set
			{
				if (_DOC_OPERATOR != value)
				{
					_DOC_OPERATOR = value;
					ChangeState();
				}
			}
		}
		public string DOC_MEMBER_TYPE
		{
			get { return _DOC_MEMBER_TYPE; }
			set
			{
				if (_DOC_MEMBER_TYPE != value)
				{
					_DOC_MEMBER_TYPE = value;
					ChangeState();
				}
			}
		}
		public string DEPT_HOSP_CLASS_TYPE
		{
			get { return _DEPT_HOSP_CLASS_TYPE; }
			set
			{
				if (_DEPT_HOSP_CLASS_TYPE != value)
				{
					_DEPT_HOSP_CLASS_TYPE = value;
					ChangeState();
				}
			}
		}
		public string DEPT_HOSP_OPERATOR
		{
			get { return _DEPT_HOSP_OPERATOR; }
			set
			{
				if (_DEPT_HOSP_OPERATOR != value)
				{
					_DEPT_HOSP_OPERATOR = value;
					ChangeState();
				}
			}
		}
		public string DEPT_HOSP_MEMBER_TYPE
		{
			get { return _DEPT_HOSP_MEMBER_TYPE; }
			set
			{
				if (_DEPT_HOSP_MEMBER_TYPE != value)
				{
					_DEPT_HOSP_MEMBER_TYPE = value;
					ChangeState();
				}
			}
		}
		public decimal? REDUCTION_FACTOR
		{
			get { return _REDUCTION_FACTOR; }
			set
			{
				if (_REDUCTION_FACTOR != value)
				{
					_REDUCTION_FACTOR = value;
					ChangeState();
				}
			}
		}
		public string EQUITY_RPT_COL
		{
			get { return _EQUITY_RPT_COL; }
			set
			{
				if (_EQUITY_RPT_COL != value)
				{
					_EQUITY_RPT_COL = value;
					ChangeState();
				}
			}
		}
		public string T4_NET_TAX_FLAG
		{
			get { return _T4_NET_TAX_FLAG; }
			set
			{
				if (_T4_NET_TAX_FLAG != value)
				{
					_T4_NET_TAX_FLAG = value;
					ChangeState();
				}
			}
		}
		public string T4_NET_PAY_FLAG
		{
			get { return _T4_NET_PAY_FLAG; }
			set
			{
				if (_T4_NET_PAY_FLAG != value)
				{
					_T4_NET_PAY_FLAG = value;
					ChangeState();
				}
			}
		}
		public string T4_NET_DEDUC_FLAG
		{
			get { return _T4_NET_DEDUC_FLAG; }
			set
			{
				if (_T4_NET_DEDUC_FLAG != value)
				{
					_T4_NET_DEDUC_FLAG = value;
					ChangeState();
				}
			}
		}
		public string DOC_TAX_RPT_FLAG
		{
			get { return _DOC_TAX_RPT_FLAG; }
			set
			{
				if (_DOC_TAX_RPT_FLAG != value)
				{
					_DOC_TAX_RPT_FLAG = value;
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
		public string WhereComp_code { get; set; }
		private string _whereComp_code;
		public string WhereComp_type { get; set; }
		private string _whereComp_type;
		public string WhereComp_owner { get; set; }
		private string _whereComp_owner;
		public string WhereDesc_long { get; set; }
		private string _whereDesc_long;
		public string WhereDesc_short { get; set; }
		private string _whereDesc_short;
		public decimal? WhereProcess_seq { get; set; }
		private decimal? _whereProcess_seq;
		public string WhereUnits_dollars_flag { get; set; }
		private string _whereUnits_dollars_flag;
		public decimal? WhereFactor { get; set; }
		private decimal? _whereFactor;
		public decimal? WhereAmt_employee { get; set; }
		private decimal? _whereAmt_employee;
		public decimal? WhereAmt_employer { get; set; }
		private decimal? _whereAmt_employer;
		public decimal? WhereAmt_taxable { get; set; }
		private decimal? _whereAmt_taxable;
		public decimal? WhereProcess_min { get; set; }
		private decimal? _whereProcess_min;
		public decimal? WhereProcess_max { get; set; }
		private decimal? _whereProcess_max;
		public decimal? WhereFiscal_max { get; set; }
		private decimal? _whereFiscal_max;
		public decimal? WhereCalendar_max { get; set; }
		private decimal? _whereCalendar_max;
		public decimal? WhereLtd_max { get; set; }
		private decimal? _whereLtd_max;
		public string WhereAffect_gross1 { get; set; }
		private string _whereAffect_gross1;
		public string WhereAffect_gross2 { get; set; }
		private string _whereAffect_gross2;
		public string WhereAffect_gross3 { get; set; }
		private string _whereAffect_gross3;
		public string WhereAffect_gross4 { get; set; }
		private string _whereAffect_gross4;
		public string WhereAffect_gross5 { get; set; }
		private string _whereAffect_gross5;
		public string WhereAffect_gross6 { get; set; }
		private string _whereAffect_gross6;
		public string WhereAffect_gross7 { get; set; }
		private string _whereAffect_gross7;
		public string WhereAffect_gross8 { get; set; }
		private string _whereAffect_gross8;
		public string WhereAffect_gross9 { get; set; }
		private string _whereAffect_gross9;
		public string WhereAffect_gross10 { get; set; }
		private string _whereAffect_gross10;
		public string WhereAffect_gross11 { get; set; }
		private string _whereAffect_gross11;
		public string WhereAffect_gross12 { get; set; }
		private string _whereAffect_gross12;
		public string WhereAffect_gross13 { get; set; }
		private string _whereAffect_gross13;
		public string WhereAffect_gross14 { get; set; }
		private string _whereAffect_gross14;
		public string WhereAffect_gross15 { get; set; }
		private string _whereAffect_gross15;
		public string WhereAffect_gross16 { get; set; }
		private string _whereAffect_gross16;
		public string WhereAffect_gross17 { get; set; }
		private string _whereAffect_gross17;
		public string WhereAffect_gross18 { get; set; }
		private string _whereAffect_gross18;
		public string WhereAffect_gross19 { get; set; }
		private string _whereAffect_gross19;
		public string WhereAffect_gross20 { get; set; }
		private string _whereAffect_gross20;
		public decimal? WhereLast_mod_date { get; set; }
		private decimal? _whereLast_mod_date;
		public decimal? WhereLast_mod_time { get; set; }
		private decimal? _whereLast_mod_time;
		public string WhereLast_mod_user_id { get; set; }
		private string _whereLast_mod_user_id;
		public decimal? WhereAmt_per_unit { get; set; }
		private decimal? _whereAmt_per_unit;
		public decimal? WherePercent_pst { get; set; }
		private decimal? _wherePercent_pst;
		public decimal? WherePercent_gst { get; set; }
		private decimal? _wherePercent_gst;
		public string WhereComp_code_ytd { get; set; }
		private string _whereComp_code_ytd;
		public string WhereComp_code_group { get; set; }
		private string _whereComp_code_group;
		public decimal? WhereReporting_seq { get; set; }
		private decimal? _whereReporting_seq;
		public string WhereComp_sub_type { get; set; }
		private string _whereComp_sub_type;
		public string WhereDoc_class_type { get; set; }
		private string _whereDoc_class_type;
		public string WhereDoc_operator { get; set; }
		private string _whereDoc_operator;
		public string WhereDoc_member_type { get; set; }
		private string _whereDoc_member_type;
		public string WhereDept_hosp_class_type { get; set; }
		private string _whereDept_hosp_class_type;
		public string WhereDept_hosp_operator { get; set; }
		private string _whereDept_hosp_operator;
		public string WhereDept_hosp_member_type { get; set; }
		private string _whereDept_hosp_member_type;
		public decimal? WhereReduction_factor { get; set; }
		private decimal? _whereReduction_factor;
		public string WhereEquity_rpt_col { get; set; }
		private string _whereEquity_rpt_col;
		public string WhereT4_net_tax_flag { get; set; }
		private string _whereT4_net_tax_flag;
		public string WhereT4_net_pay_flag { get; set; }
		private string _whereT4_net_pay_flag;
		public string WhereT4_net_deduc_flag { get; set; }
		private string _whereT4_net_deduc_flag;
		public string WhereDoc_tax_rpt_flag { get; set; }
		private string _whereDoc_tax_rpt_flag;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalComp_code;
		private string _originalComp_type;
		private string _originalComp_owner;
		private string _originalDesc_long;
		private string _originalDesc_short;
		private decimal? _originalProcess_seq;
		private string _originalUnits_dollars_flag;
		private decimal? _originalFactor;
		private decimal? _originalAmt_employee;
		private decimal? _originalAmt_employer;
		private decimal? _originalAmt_taxable;
		private decimal? _originalProcess_min;
		private decimal? _originalProcess_max;
		private decimal? _originalFiscal_max;
		private decimal? _originalCalendar_max;
		private decimal? _originalLtd_max;
		private string _originalAffect_gross1;
		private string _originalAffect_gross2;
		private string _originalAffect_gross3;
		private string _originalAffect_gross4;
		private string _originalAffect_gross5;
		private string _originalAffect_gross6;
		private string _originalAffect_gross7;
		private string _originalAffect_gross8;
		private string _originalAffect_gross9;
		private string _originalAffect_gross10;
		private string _originalAffect_gross11;
		private string _originalAffect_gross12;
		private string _originalAffect_gross13;
		private string _originalAffect_gross14;
		private string _originalAffect_gross15;
		private string _originalAffect_gross16;
		private string _originalAffect_gross17;
		private string _originalAffect_gross18;
		private string _originalAffect_gross19;
		private string _originalAffect_gross20;
		private decimal? _originalLast_mod_date;
		private decimal? _originalLast_mod_time;
		private string _originalLast_mod_user_id;
		private decimal? _originalAmt_per_unit;
		private decimal? _originalPercent_pst;
		private decimal? _originalPercent_gst;
		private string _originalComp_code_ytd;
		private string _originalComp_code_group;
		private decimal? _originalReporting_seq;
		private string _originalComp_sub_type;
		private string _originalDoc_class_type;
		private string _originalDoc_operator;
		private string _originalDoc_member_type;
		private string _originalDept_hosp_class_type;
		private string _originalDept_hosp_operator;
		private string _originalDept_hosp_member_type;
		private decimal? _originalReduction_factor;
		private string _originalEquity_rpt_col;
		private string _originalT4_net_tax_flag;
		private string _originalT4_net_pay_flag;
		private string _originalT4_net_deduc_flag;
		private string _originalDoc_tax_rpt_flag;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			COMP_CODE = _originalComp_code;
			COMP_TYPE = _originalComp_type;
			COMP_OWNER = _originalComp_owner;
			DESC_LONG = _originalDesc_long;
			DESC_SHORT = _originalDesc_short;
			PROCESS_SEQ = _originalProcess_seq;
			UNITS_DOLLARS_FLAG = _originalUnits_dollars_flag;
			FACTOR = _originalFactor;
			AMT_EMPLOYEE = _originalAmt_employee;
			AMT_EMPLOYER = _originalAmt_employer;
			AMT_TAXABLE = _originalAmt_taxable;
			PROCESS_MIN = _originalProcess_min;
			PROCESS_MAX = _originalProcess_max;
			FISCAL_MAX = _originalFiscal_max;
			CALENDAR_MAX = _originalCalendar_max;
			LTD_MAX = _originalLtd_max;
			AFFECT_GROSS1 = _originalAffect_gross1;
			AFFECT_GROSS2 = _originalAffect_gross2;
			AFFECT_GROSS3 = _originalAffect_gross3;
			AFFECT_GROSS4 = _originalAffect_gross4;
			AFFECT_GROSS5 = _originalAffect_gross5;
			AFFECT_GROSS6 = _originalAffect_gross6;
			AFFECT_GROSS7 = _originalAffect_gross7;
			AFFECT_GROSS8 = _originalAffect_gross8;
			AFFECT_GROSS9 = _originalAffect_gross9;
			AFFECT_GROSS10 = _originalAffect_gross10;
			AFFECT_GROSS11 = _originalAffect_gross11;
			AFFECT_GROSS12 = _originalAffect_gross12;
			AFFECT_GROSS13 = _originalAffect_gross13;
			AFFECT_GROSS14 = _originalAffect_gross14;
			AFFECT_GROSS15 = _originalAffect_gross15;
			AFFECT_GROSS16 = _originalAffect_gross16;
			AFFECT_GROSS17 = _originalAffect_gross17;
			AFFECT_GROSS18 = _originalAffect_gross18;
			AFFECT_GROSS19 = _originalAffect_gross19;
			AFFECT_GROSS20 = _originalAffect_gross20;
			LAST_MOD_DATE = _originalLast_mod_date;
			LAST_MOD_TIME = _originalLast_mod_time;
			LAST_MOD_USER_ID = _originalLast_mod_user_id;
			AMT_PER_UNIT = _originalAmt_per_unit;
			PERCENT_PST = _originalPercent_pst;
			PERCENT_GST = _originalPercent_gst;
			COMP_CODE_YTD = _originalComp_code_ytd;
			COMP_CODE_GROUP = _originalComp_code_group;
			REPORTING_SEQ = _originalReporting_seq;
			COMP_SUB_TYPE = _originalComp_sub_type;
			DOC_CLASS_TYPE = _originalDoc_class_type;
			DOC_OPERATOR = _originalDoc_operator;
			DOC_MEMBER_TYPE = _originalDoc_member_type;
			DEPT_HOSP_CLASS_TYPE = _originalDept_hosp_class_type;
			DEPT_HOSP_OPERATOR = _originalDept_hosp_operator;
			DEPT_HOSP_MEMBER_TYPE = _originalDept_hosp_member_type;
			REDUCTION_FACTOR = _originalReduction_factor;
			EQUITY_RPT_COL = _originalEquity_rpt_col;
			T4_NET_TAX_FLAG = _originalT4_net_tax_flag;
			T4_NET_PAY_FLAG = _originalT4_net_pay_flag;
			T4_NET_DEDUC_FLAG = _originalT4_net_deduc_flag;
			DOC_TAX_RPT_FLAG = _originalDoc_tax_rpt_flag;
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
					new SqlParameter("COMP_CODE",COMP_CODE)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F190_COMP_CODES_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F190_COMP_CODES_Purge]");
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
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("COMP_TYPE", SqlNull(COMP_TYPE)),
						new SqlParameter("COMP_OWNER", SqlNull(COMP_OWNER)),
						new SqlParameter("DESC_LONG", SqlNull(DESC_LONG)),
						new SqlParameter("DESC_SHORT", SqlNull(DESC_SHORT)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("UNITS_DOLLARS_FLAG", SqlNull(UNITS_DOLLARS_FLAG)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("AMT_EMPLOYEE", SqlNull(AMT_EMPLOYEE)),
						new SqlParameter("AMT_EMPLOYER", SqlNull(AMT_EMPLOYER)),
						new SqlParameter("AMT_TAXABLE", SqlNull(AMT_TAXABLE)),
						new SqlParameter("PROCESS_MIN", SqlNull(PROCESS_MIN)),
						new SqlParameter("PROCESS_MAX", SqlNull(PROCESS_MAX)),
						new SqlParameter("FISCAL_MAX", SqlNull(FISCAL_MAX)),
						new SqlParameter("CALENDAR_MAX", SqlNull(CALENDAR_MAX)),
						new SqlParameter("LTD_MAX", SqlNull(LTD_MAX)),
						new SqlParameter("AFFECT_GROSS1", SqlNull(AFFECT_GROSS1)),
						new SqlParameter("AFFECT_GROSS2", SqlNull(AFFECT_GROSS2)),
						new SqlParameter("AFFECT_GROSS3", SqlNull(AFFECT_GROSS3)),
						new SqlParameter("AFFECT_GROSS4", SqlNull(AFFECT_GROSS4)),
						new SqlParameter("AFFECT_GROSS5", SqlNull(AFFECT_GROSS5)),
						new SqlParameter("AFFECT_GROSS6", SqlNull(AFFECT_GROSS6)),
						new SqlParameter("AFFECT_GROSS7", SqlNull(AFFECT_GROSS7)),
						new SqlParameter("AFFECT_GROSS8", SqlNull(AFFECT_GROSS8)),
						new SqlParameter("AFFECT_GROSS9", SqlNull(AFFECT_GROSS9)),
						new SqlParameter("AFFECT_GROSS10", SqlNull(AFFECT_GROSS10)),
						new SqlParameter("AFFECT_GROSS11", SqlNull(AFFECT_GROSS11)),
						new SqlParameter("AFFECT_GROSS12", SqlNull(AFFECT_GROSS12)),
						new SqlParameter("AFFECT_GROSS13", SqlNull(AFFECT_GROSS13)),
						new SqlParameter("AFFECT_GROSS14", SqlNull(AFFECT_GROSS14)),
						new SqlParameter("AFFECT_GROSS15", SqlNull(AFFECT_GROSS15)),
						new SqlParameter("AFFECT_GROSS16", SqlNull(AFFECT_GROSS16)),
						new SqlParameter("AFFECT_GROSS17", SqlNull(AFFECT_GROSS17)),
						new SqlParameter("AFFECT_GROSS18", SqlNull(AFFECT_GROSS18)),
						new SqlParameter("AFFECT_GROSS19", SqlNull(AFFECT_GROSS19)),
						new SqlParameter("AFFECT_GROSS20", SqlNull(AFFECT_GROSS20)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("AMT_PER_UNIT", SqlNull(AMT_PER_UNIT)),
						new SqlParameter("PERCENT_PST", SqlNull(PERCENT_PST)),
						new SqlParameter("PERCENT_GST", SqlNull(PERCENT_GST)),
						new SqlParameter("COMP_CODE_YTD", SqlNull(COMP_CODE_YTD)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REPORTING_SEQ", SqlNull(REPORTING_SEQ)),
						new SqlParameter("COMP_SUB_TYPE", SqlNull(COMP_SUB_TYPE)),
						new SqlParameter("DOC_CLASS_TYPE", SqlNull(DOC_CLASS_TYPE)),
						new SqlParameter("DOC_OPERATOR", SqlNull(DOC_OPERATOR)),
						new SqlParameter("DOC_MEMBER_TYPE", SqlNull(DOC_MEMBER_TYPE)),
						new SqlParameter("DEPT_HOSP_CLASS_TYPE", SqlNull(DEPT_HOSP_CLASS_TYPE)),
						new SqlParameter("DEPT_HOSP_OPERATOR", SqlNull(DEPT_HOSP_OPERATOR)),
						new SqlParameter("DEPT_HOSP_MEMBER_TYPE", SqlNull(DEPT_HOSP_MEMBER_TYPE)),
						new SqlParameter("REDUCTION_FACTOR", SqlNull(REDUCTION_FACTOR)),
						new SqlParameter("EQUITY_RPT_COL", SqlNull(EQUITY_RPT_COL)),
						new SqlParameter("T4_NET_TAX_FLAG", SqlNull(T4_NET_TAX_FLAG)),
						new SqlParameter("T4_NET_PAY_FLAG", SqlNull(T4_NET_PAY_FLAG)),
						new SqlParameter("T4_NET_DEDUC_FLAG", SqlNull(T4_NET_DEDUC_FLAG)),
						new SqlParameter("DOC_TAX_RPT_FLAG", SqlNull(DOC_TAX_RPT_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F190_COMP_CODES_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						COMP_CODE = Reader["COMP_CODE"].ToString();
						COMP_TYPE = Reader["COMP_TYPE"].ToString();
						COMP_OWNER = Reader["COMP_OWNER"].ToString();
						DESC_LONG = Reader["DESC_LONG"].ToString();
						DESC_SHORT = Reader["DESC_SHORT"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						UNITS_DOLLARS_FLAG = Reader["UNITS_DOLLARS_FLAG"].ToString();
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						AMT_EMPLOYEE = ConvertDEC(Reader["AMT_EMPLOYEE"]);
						AMT_EMPLOYER = ConvertDEC(Reader["AMT_EMPLOYER"]);
						AMT_TAXABLE = ConvertDEC(Reader["AMT_TAXABLE"]);
						PROCESS_MIN = ConvertDEC(Reader["PROCESS_MIN"]);
						PROCESS_MAX = ConvertDEC(Reader["PROCESS_MAX"]);
						FISCAL_MAX = ConvertDEC(Reader["FISCAL_MAX"]);
						CALENDAR_MAX = ConvertDEC(Reader["CALENDAR_MAX"]);
						LTD_MAX = ConvertDEC(Reader["LTD_MAX"]);
						AFFECT_GROSS1 = Reader["AFFECT_GROSS1"].ToString();
						AFFECT_GROSS2 = Reader["AFFECT_GROSS2"].ToString();
						AFFECT_GROSS3 = Reader["AFFECT_GROSS3"].ToString();
						AFFECT_GROSS4 = Reader["AFFECT_GROSS4"].ToString();
						AFFECT_GROSS5 = Reader["AFFECT_GROSS5"].ToString();
						AFFECT_GROSS6 = Reader["AFFECT_GROSS6"].ToString();
						AFFECT_GROSS7 = Reader["AFFECT_GROSS7"].ToString();
						AFFECT_GROSS8 = Reader["AFFECT_GROSS8"].ToString();
						AFFECT_GROSS9 = Reader["AFFECT_GROSS9"].ToString();
						AFFECT_GROSS10 = Reader["AFFECT_GROSS10"].ToString();
						AFFECT_GROSS11 = Reader["AFFECT_GROSS11"].ToString();
						AFFECT_GROSS12 = Reader["AFFECT_GROSS12"].ToString();
						AFFECT_GROSS13 = Reader["AFFECT_GROSS13"].ToString();
						AFFECT_GROSS14 = Reader["AFFECT_GROSS14"].ToString();
						AFFECT_GROSS15 = Reader["AFFECT_GROSS15"].ToString();
						AFFECT_GROSS16 = Reader["AFFECT_GROSS16"].ToString();
						AFFECT_GROSS17 = Reader["AFFECT_GROSS17"].ToString();
						AFFECT_GROSS18 = Reader["AFFECT_GROSS18"].ToString();
						AFFECT_GROSS19 = Reader["AFFECT_GROSS19"].ToString();
						AFFECT_GROSS20 = Reader["AFFECT_GROSS20"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						AMT_PER_UNIT = ConvertDEC(Reader["AMT_PER_UNIT"]);
						PERCENT_PST = ConvertDEC(Reader["PERCENT_PST"]);
						PERCENT_GST = ConvertDEC(Reader["PERCENT_GST"]);
						COMP_CODE_YTD = Reader["COMP_CODE_YTD"].ToString();
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]);
						COMP_SUB_TYPE = Reader["COMP_SUB_TYPE"].ToString();
						DOC_CLASS_TYPE = Reader["DOC_CLASS_TYPE"].ToString();
						DOC_OPERATOR = Reader["DOC_OPERATOR"].ToString();
						DOC_MEMBER_TYPE = Reader["DOC_MEMBER_TYPE"].ToString();
						DEPT_HOSP_CLASS_TYPE = Reader["DEPT_HOSP_CLASS_TYPE"].ToString();
						DEPT_HOSP_OPERATOR = Reader["DEPT_HOSP_OPERATOR"].ToString();
						DEPT_HOSP_MEMBER_TYPE = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString();
						REDUCTION_FACTOR = ConvertDEC(Reader["REDUCTION_FACTOR"]);
						EQUITY_RPT_COL = Reader["EQUITY_RPT_COL"].ToString();
						T4_NET_TAX_FLAG = Reader["T4_NET_TAX_FLAG"].ToString();
						T4_NET_PAY_FLAG = Reader["T4_NET_PAY_FLAG"].ToString();
						T4_NET_DEDUC_FLAG = Reader["T4_NET_DEDUC_FLAG"].ToString();
						DOC_TAX_RPT_FLAG = Reader["DOC_TAX_RPT_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalComp_type = Reader["COMP_TYPE"].ToString();
						_originalComp_owner = Reader["COMP_OWNER"].ToString();
						_originalDesc_long = Reader["DESC_LONG"].ToString();
						_originalDesc_short = Reader["DESC_SHORT"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalUnits_dollars_flag = Reader["UNITS_DOLLARS_FLAG"].ToString();
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalAmt_employee = ConvertDEC(Reader["AMT_EMPLOYEE"]);
						_originalAmt_employer = ConvertDEC(Reader["AMT_EMPLOYER"]);
						_originalAmt_taxable = ConvertDEC(Reader["AMT_TAXABLE"]);
						_originalProcess_min = ConvertDEC(Reader["PROCESS_MIN"]);
						_originalProcess_max = ConvertDEC(Reader["PROCESS_MAX"]);
						_originalFiscal_max = ConvertDEC(Reader["FISCAL_MAX"]);
						_originalCalendar_max = ConvertDEC(Reader["CALENDAR_MAX"]);
						_originalLtd_max = ConvertDEC(Reader["LTD_MAX"]);
						_originalAffect_gross1 = Reader["AFFECT_GROSS1"].ToString();
						_originalAffect_gross2 = Reader["AFFECT_GROSS2"].ToString();
						_originalAffect_gross3 = Reader["AFFECT_GROSS3"].ToString();
						_originalAffect_gross4 = Reader["AFFECT_GROSS4"].ToString();
						_originalAffect_gross5 = Reader["AFFECT_GROSS5"].ToString();
						_originalAffect_gross6 = Reader["AFFECT_GROSS6"].ToString();
						_originalAffect_gross7 = Reader["AFFECT_GROSS7"].ToString();
						_originalAffect_gross8 = Reader["AFFECT_GROSS8"].ToString();
						_originalAffect_gross9 = Reader["AFFECT_GROSS9"].ToString();
						_originalAffect_gross10 = Reader["AFFECT_GROSS10"].ToString();
						_originalAffect_gross11 = Reader["AFFECT_GROSS11"].ToString();
						_originalAffect_gross12 = Reader["AFFECT_GROSS12"].ToString();
						_originalAffect_gross13 = Reader["AFFECT_GROSS13"].ToString();
						_originalAffect_gross14 = Reader["AFFECT_GROSS14"].ToString();
						_originalAffect_gross15 = Reader["AFFECT_GROSS15"].ToString();
						_originalAffect_gross16 = Reader["AFFECT_GROSS16"].ToString();
						_originalAffect_gross17 = Reader["AFFECT_GROSS17"].ToString();
						_originalAffect_gross18 = Reader["AFFECT_GROSS18"].ToString();
						_originalAffect_gross19 = Reader["AFFECT_GROSS19"].ToString();
						_originalAffect_gross20 = Reader["AFFECT_GROSS20"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalAmt_per_unit = ConvertDEC(Reader["AMT_PER_UNIT"]);
						_originalPercent_pst = ConvertDEC(Reader["PERCENT_PST"]);
						_originalPercent_gst = ConvertDEC(Reader["PERCENT_GST"]);
						_originalComp_code_ytd = Reader["COMP_CODE_YTD"].ToString();
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]);
						_originalComp_sub_type = Reader["COMP_SUB_TYPE"].ToString();
						_originalDoc_class_type = Reader["DOC_CLASS_TYPE"].ToString();
						_originalDoc_operator = Reader["DOC_OPERATOR"].ToString();
						_originalDoc_member_type = Reader["DOC_MEMBER_TYPE"].ToString();
						_originalDept_hosp_class_type = Reader["DEPT_HOSP_CLASS_TYPE"].ToString();
						_originalDept_hosp_operator = Reader["DEPT_HOSP_OPERATOR"].ToString();
						_originalDept_hosp_member_type = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString();
						_originalReduction_factor = ConvertDEC(Reader["REDUCTION_FACTOR"]);
						_originalEquity_rpt_col = Reader["EQUITY_RPT_COL"].ToString();
						_originalT4_net_tax_flag = Reader["T4_NET_TAX_FLAG"].ToString();
						_originalT4_net_pay_flag = Reader["T4_NET_PAY_FLAG"].ToString();
						_originalT4_net_deduc_flag = Reader["T4_NET_DEDUC_FLAG"].ToString();
						_originalDoc_tax_rpt_flag = Reader["DOC_TAX_RPT_FLAG"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("COMP_CODE", SqlNull(COMP_CODE)),
						new SqlParameter("COMP_TYPE", SqlNull(COMP_TYPE)),
						new SqlParameter("COMP_OWNER", SqlNull(COMP_OWNER)),
						new SqlParameter("DESC_LONG", SqlNull(DESC_LONG)),
						new SqlParameter("DESC_SHORT", SqlNull(DESC_SHORT)),
						new SqlParameter("PROCESS_SEQ", SqlNull(PROCESS_SEQ)),
						new SqlParameter("UNITS_DOLLARS_FLAG", SqlNull(UNITS_DOLLARS_FLAG)),
						new SqlParameter("FACTOR", SqlNull(FACTOR)),
						new SqlParameter("AMT_EMPLOYEE", SqlNull(AMT_EMPLOYEE)),
						new SqlParameter("AMT_EMPLOYER", SqlNull(AMT_EMPLOYER)),
						new SqlParameter("AMT_TAXABLE", SqlNull(AMT_TAXABLE)),
						new SqlParameter("PROCESS_MIN", SqlNull(PROCESS_MIN)),
						new SqlParameter("PROCESS_MAX", SqlNull(PROCESS_MAX)),
						new SqlParameter("FISCAL_MAX", SqlNull(FISCAL_MAX)),
						new SqlParameter("CALENDAR_MAX", SqlNull(CALENDAR_MAX)),
						new SqlParameter("LTD_MAX", SqlNull(LTD_MAX)),
						new SqlParameter("AFFECT_GROSS1", SqlNull(AFFECT_GROSS1)),
						new SqlParameter("AFFECT_GROSS2", SqlNull(AFFECT_GROSS2)),
						new SqlParameter("AFFECT_GROSS3", SqlNull(AFFECT_GROSS3)),
						new SqlParameter("AFFECT_GROSS4", SqlNull(AFFECT_GROSS4)),
						new SqlParameter("AFFECT_GROSS5", SqlNull(AFFECT_GROSS5)),
						new SqlParameter("AFFECT_GROSS6", SqlNull(AFFECT_GROSS6)),
						new SqlParameter("AFFECT_GROSS7", SqlNull(AFFECT_GROSS7)),
						new SqlParameter("AFFECT_GROSS8", SqlNull(AFFECT_GROSS8)),
						new SqlParameter("AFFECT_GROSS9", SqlNull(AFFECT_GROSS9)),
						new SqlParameter("AFFECT_GROSS10", SqlNull(AFFECT_GROSS10)),
						new SqlParameter("AFFECT_GROSS11", SqlNull(AFFECT_GROSS11)),
						new SqlParameter("AFFECT_GROSS12", SqlNull(AFFECT_GROSS12)),
						new SqlParameter("AFFECT_GROSS13", SqlNull(AFFECT_GROSS13)),
						new SqlParameter("AFFECT_GROSS14", SqlNull(AFFECT_GROSS14)),
						new SqlParameter("AFFECT_GROSS15", SqlNull(AFFECT_GROSS15)),
						new SqlParameter("AFFECT_GROSS16", SqlNull(AFFECT_GROSS16)),
						new SqlParameter("AFFECT_GROSS17", SqlNull(AFFECT_GROSS17)),
						new SqlParameter("AFFECT_GROSS18", SqlNull(AFFECT_GROSS18)),
						new SqlParameter("AFFECT_GROSS19", SqlNull(AFFECT_GROSS19)),
						new SqlParameter("AFFECT_GROSS20", SqlNull(AFFECT_GROSS20)),
						new SqlParameter("LAST_MOD_DATE", SqlNull(LAST_MOD_DATE)),
						new SqlParameter("LAST_MOD_TIME", SqlNull(LAST_MOD_TIME)),
						new SqlParameter("LAST_MOD_USER_ID", SqlNull(LAST_MOD_USER_ID)),
						new SqlParameter("AMT_PER_UNIT", SqlNull(AMT_PER_UNIT)),
						new SqlParameter("PERCENT_PST", SqlNull(PERCENT_PST)),
						new SqlParameter("PERCENT_GST", SqlNull(PERCENT_GST)),
						new SqlParameter("COMP_CODE_YTD", SqlNull(COMP_CODE_YTD)),
						new SqlParameter("COMP_CODE_GROUP", SqlNull(COMP_CODE_GROUP)),
						new SqlParameter("REPORTING_SEQ", SqlNull(REPORTING_SEQ)),
						new SqlParameter("COMP_SUB_TYPE", SqlNull(COMP_SUB_TYPE)),
						new SqlParameter("DOC_CLASS_TYPE", SqlNull(DOC_CLASS_TYPE)),
						new SqlParameter("DOC_OPERATOR", SqlNull(DOC_OPERATOR)),
						new SqlParameter("DOC_MEMBER_TYPE", SqlNull(DOC_MEMBER_TYPE)),
						new SqlParameter("DEPT_HOSP_CLASS_TYPE", SqlNull(DEPT_HOSP_CLASS_TYPE)),
						new SqlParameter("DEPT_HOSP_OPERATOR", SqlNull(DEPT_HOSP_OPERATOR)),
						new SqlParameter("DEPT_HOSP_MEMBER_TYPE", SqlNull(DEPT_HOSP_MEMBER_TYPE)),
						new SqlParameter("REDUCTION_FACTOR", SqlNull(REDUCTION_FACTOR)),
						new SqlParameter("EQUITY_RPT_COL", SqlNull(EQUITY_RPT_COL)),
						new SqlParameter("T4_NET_TAX_FLAG", SqlNull(T4_NET_TAX_FLAG)),
						new SqlParameter("T4_NET_PAY_FLAG", SqlNull(T4_NET_PAY_FLAG)),
						new SqlParameter("T4_NET_DEDUC_FLAG", SqlNull(T4_NET_DEDUC_FLAG)),
						new SqlParameter("DOC_TAX_RPT_FLAG", SqlNull(DOC_TAX_RPT_FLAG)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F190_COMP_CODES_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						COMP_CODE = Reader["COMP_CODE"].ToString();
						COMP_TYPE = Reader["COMP_TYPE"].ToString();
						COMP_OWNER = Reader["COMP_OWNER"].ToString();
						DESC_LONG = Reader["DESC_LONG"].ToString();
						DESC_SHORT = Reader["DESC_SHORT"].ToString();
						PROCESS_SEQ = ConvertDEC(Reader["PROCESS_SEQ"]);
						UNITS_DOLLARS_FLAG = Reader["UNITS_DOLLARS_FLAG"].ToString();
						FACTOR = ConvertDEC(Reader["FACTOR"]);
						AMT_EMPLOYEE = ConvertDEC(Reader["AMT_EMPLOYEE"]);
						AMT_EMPLOYER = ConvertDEC(Reader["AMT_EMPLOYER"]);
						AMT_TAXABLE = ConvertDEC(Reader["AMT_TAXABLE"]);
						PROCESS_MIN = ConvertDEC(Reader["PROCESS_MIN"]);
						PROCESS_MAX = ConvertDEC(Reader["PROCESS_MAX"]);
						FISCAL_MAX = ConvertDEC(Reader["FISCAL_MAX"]);
						CALENDAR_MAX = ConvertDEC(Reader["CALENDAR_MAX"]);
						LTD_MAX = ConvertDEC(Reader["LTD_MAX"]);
						AFFECT_GROSS1 = Reader["AFFECT_GROSS1"].ToString();
						AFFECT_GROSS2 = Reader["AFFECT_GROSS2"].ToString();
						AFFECT_GROSS3 = Reader["AFFECT_GROSS3"].ToString();
						AFFECT_GROSS4 = Reader["AFFECT_GROSS4"].ToString();
						AFFECT_GROSS5 = Reader["AFFECT_GROSS5"].ToString();
						AFFECT_GROSS6 = Reader["AFFECT_GROSS6"].ToString();
						AFFECT_GROSS7 = Reader["AFFECT_GROSS7"].ToString();
						AFFECT_GROSS8 = Reader["AFFECT_GROSS8"].ToString();
						AFFECT_GROSS9 = Reader["AFFECT_GROSS9"].ToString();
						AFFECT_GROSS10 = Reader["AFFECT_GROSS10"].ToString();
						AFFECT_GROSS11 = Reader["AFFECT_GROSS11"].ToString();
						AFFECT_GROSS12 = Reader["AFFECT_GROSS12"].ToString();
						AFFECT_GROSS13 = Reader["AFFECT_GROSS13"].ToString();
						AFFECT_GROSS14 = Reader["AFFECT_GROSS14"].ToString();
						AFFECT_GROSS15 = Reader["AFFECT_GROSS15"].ToString();
						AFFECT_GROSS16 = Reader["AFFECT_GROSS16"].ToString();
						AFFECT_GROSS17 = Reader["AFFECT_GROSS17"].ToString();
						AFFECT_GROSS18 = Reader["AFFECT_GROSS18"].ToString();
						AFFECT_GROSS19 = Reader["AFFECT_GROSS19"].ToString();
						AFFECT_GROSS20 = Reader["AFFECT_GROSS20"].ToString();
						LAST_MOD_DATE = ConvertDEC(Reader["LAST_MOD_DATE"]);
						LAST_MOD_TIME = ConvertDEC(Reader["LAST_MOD_TIME"]);
						LAST_MOD_USER_ID = Reader["LAST_MOD_USER_ID"].ToString();
						AMT_PER_UNIT = ConvertDEC(Reader["AMT_PER_UNIT"]);
						PERCENT_PST = ConvertDEC(Reader["PERCENT_PST"]);
						PERCENT_GST = ConvertDEC(Reader["PERCENT_GST"]);
						COMP_CODE_YTD = Reader["COMP_CODE_YTD"].ToString();
						COMP_CODE_GROUP = Reader["COMP_CODE_GROUP"].ToString();
						REPORTING_SEQ = ConvertDEC(Reader["REPORTING_SEQ"]);
						COMP_SUB_TYPE = Reader["COMP_SUB_TYPE"].ToString();
						DOC_CLASS_TYPE = Reader["DOC_CLASS_TYPE"].ToString();
						DOC_OPERATOR = Reader["DOC_OPERATOR"].ToString();
						DOC_MEMBER_TYPE = Reader["DOC_MEMBER_TYPE"].ToString();
						DEPT_HOSP_CLASS_TYPE = Reader["DEPT_HOSP_CLASS_TYPE"].ToString();
						DEPT_HOSP_OPERATOR = Reader["DEPT_HOSP_OPERATOR"].ToString();
						DEPT_HOSP_MEMBER_TYPE = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString();
						REDUCTION_FACTOR = ConvertDEC(Reader["REDUCTION_FACTOR"]);
						EQUITY_RPT_COL = Reader["EQUITY_RPT_COL"].ToString();
						T4_NET_TAX_FLAG = Reader["T4_NET_TAX_FLAG"].ToString();
						T4_NET_PAY_FLAG = Reader["T4_NET_PAY_FLAG"].ToString();
						T4_NET_DEDUC_FLAG = Reader["T4_NET_DEDUC_FLAG"].ToString();
						DOC_TAX_RPT_FLAG = Reader["DOC_TAX_RPT_FLAG"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalComp_code = Reader["COMP_CODE"].ToString();
						_originalComp_type = Reader["COMP_TYPE"].ToString();
						_originalComp_owner = Reader["COMP_OWNER"].ToString();
						_originalDesc_long = Reader["DESC_LONG"].ToString();
						_originalDesc_short = Reader["DESC_SHORT"].ToString();
						_originalProcess_seq = ConvertDEC(Reader["PROCESS_SEQ"]);
						_originalUnits_dollars_flag = Reader["UNITS_DOLLARS_FLAG"].ToString();
						_originalFactor = ConvertDEC(Reader["FACTOR"]);
						_originalAmt_employee = ConvertDEC(Reader["AMT_EMPLOYEE"]);
						_originalAmt_employer = ConvertDEC(Reader["AMT_EMPLOYER"]);
						_originalAmt_taxable = ConvertDEC(Reader["AMT_TAXABLE"]);
						_originalProcess_min = ConvertDEC(Reader["PROCESS_MIN"]);
						_originalProcess_max = ConvertDEC(Reader["PROCESS_MAX"]);
						_originalFiscal_max = ConvertDEC(Reader["FISCAL_MAX"]);
						_originalCalendar_max = ConvertDEC(Reader["CALENDAR_MAX"]);
						_originalLtd_max = ConvertDEC(Reader["LTD_MAX"]);
						_originalAffect_gross1 = Reader["AFFECT_GROSS1"].ToString();
						_originalAffect_gross2 = Reader["AFFECT_GROSS2"].ToString();
						_originalAffect_gross3 = Reader["AFFECT_GROSS3"].ToString();
						_originalAffect_gross4 = Reader["AFFECT_GROSS4"].ToString();
						_originalAffect_gross5 = Reader["AFFECT_GROSS5"].ToString();
						_originalAffect_gross6 = Reader["AFFECT_GROSS6"].ToString();
						_originalAffect_gross7 = Reader["AFFECT_GROSS7"].ToString();
						_originalAffect_gross8 = Reader["AFFECT_GROSS8"].ToString();
						_originalAffect_gross9 = Reader["AFFECT_GROSS9"].ToString();
						_originalAffect_gross10 = Reader["AFFECT_GROSS10"].ToString();
						_originalAffect_gross11 = Reader["AFFECT_GROSS11"].ToString();
						_originalAffect_gross12 = Reader["AFFECT_GROSS12"].ToString();
						_originalAffect_gross13 = Reader["AFFECT_GROSS13"].ToString();
						_originalAffect_gross14 = Reader["AFFECT_GROSS14"].ToString();
						_originalAffect_gross15 = Reader["AFFECT_GROSS15"].ToString();
						_originalAffect_gross16 = Reader["AFFECT_GROSS16"].ToString();
						_originalAffect_gross17 = Reader["AFFECT_GROSS17"].ToString();
						_originalAffect_gross18 = Reader["AFFECT_GROSS18"].ToString();
						_originalAffect_gross19 = Reader["AFFECT_GROSS19"].ToString();
						_originalAffect_gross20 = Reader["AFFECT_GROSS20"].ToString();
						_originalLast_mod_date = ConvertDEC(Reader["LAST_MOD_DATE"]);
						_originalLast_mod_time = ConvertDEC(Reader["LAST_MOD_TIME"]);
						_originalLast_mod_user_id = Reader["LAST_MOD_USER_ID"].ToString();
						_originalAmt_per_unit = ConvertDEC(Reader["AMT_PER_UNIT"]);
						_originalPercent_pst = ConvertDEC(Reader["PERCENT_PST"]);
						_originalPercent_gst = ConvertDEC(Reader["PERCENT_GST"]);
						_originalComp_code_ytd = Reader["COMP_CODE_YTD"].ToString();
						_originalComp_code_group = Reader["COMP_CODE_GROUP"].ToString();
						_originalReporting_seq = ConvertDEC(Reader["REPORTING_SEQ"]);
						_originalComp_sub_type = Reader["COMP_SUB_TYPE"].ToString();
						_originalDoc_class_type = Reader["DOC_CLASS_TYPE"].ToString();
						_originalDoc_operator = Reader["DOC_OPERATOR"].ToString();
						_originalDoc_member_type = Reader["DOC_MEMBER_TYPE"].ToString();
						_originalDept_hosp_class_type = Reader["DEPT_HOSP_CLASS_TYPE"].ToString();
						_originalDept_hosp_operator = Reader["DEPT_HOSP_OPERATOR"].ToString();
						_originalDept_hosp_member_type = Reader["DEPT_HOSP_MEMBER_TYPE"].ToString();
						_originalReduction_factor = ConvertDEC(Reader["REDUCTION_FACTOR"]);
						_originalEquity_rpt_col = Reader["EQUITY_RPT_COL"].ToString();
						_originalT4_net_tax_flag = Reader["T4_NET_TAX_FLAG"].ToString();
						_originalT4_net_pay_flag = Reader["T4_NET_PAY_FLAG"].ToString();
						_originalT4_net_deduc_flag = Reader["T4_NET_DEDUC_FLAG"].ToString();
						_originalDoc_tax_rpt_flag = Reader["DOC_TAX_RPT_FLAG"].ToString();
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