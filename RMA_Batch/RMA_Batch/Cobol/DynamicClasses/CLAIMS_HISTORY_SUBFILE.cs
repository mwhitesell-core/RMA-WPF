using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CLAIMS_HISTORY_SUBFILE : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CLAIMS_HISTORY_SUBFILE> Collection( Guid? rowid,
															string clmdtl_id,
															decimal? clmdtl_nbr_servmin,
															decimal? clmdtl_nbr_servmax,
															string clmdtl_sv_date,
															decimal? clmdtl_consec_datesmin,
															decimal? clmdtl_consec_datesmax,
															decimal? clmdtl_sv_nbr1min,
															decimal? clmdtl_sv_nbr1max,
															decimal? clmdtl_sv_nbr2min,
															decimal? clmdtl_sv_nbr2max,
															decimal? clmdtl_sv_nbr3min,
															decimal? clmdtl_sv_nbr3max,
															decimal? clmdtl_sv_day1min,
															decimal? clmdtl_sv_day1max,
															decimal? clmdtl_sv_day2min,
															decimal? clmdtl_sv_day2max,
															decimal? clmdtl_sv_day3min,
															decimal? clmdtl_sv_day3max,
															decimal? clmdtl_amt_tech_billedmin,
															decimal? clmdtl_amt_tech_billedmax,
															decimal? clmdtl_fee_omamin,
															decimal? clmdtl_fee_omamax,
															decimal? clmdtl_fee_ohipmin,
															decimal? clmdtl_fee_ohipmax,
															string clmdtl_date_period_end,
															string clmhdr_hosp,
															decimal? clmhdr_doc_deptmin,
															decimal? clmhdr_doc_deptmax,
															decimal? clmhdr_agent_cdmin,
															decimal? clmhdr_agent_cdmax,
															string clmhdr_pat_ohip_id_or_chart,
															string clmhdr_loc,
															decimal? clmhdr_refer_doc_nbrmin,
															decimal? clmhdr_refer_doc_nbrmax,
															decimal? clmhdr_diag_cdmin,
															decimal? clmhdr_diag_cdmax,
															decimal? clmhdr_doc_spec_cdmin,
															decimal? clmhdr_doc_spec_cdmax,
															string clmhdr_i_o_pat_ind,
															string clmhdr_date_admit,
															decimal? clmhdr_doc_nbr_ohipmin,
															decimal? clmhdr_doc_nbr_ohipmax,
															string pat_ohip_mmyy,
															string pat_chart_nbr,
															string pat_chart_nbr_2,
															string pat_chart_nbr_3,
															string pat_chart_nbr_4,
															string pat_chart_nbr_5,
															decimal? pat_health_nbrmin,
															decimal? pat_health_nbrmax,
															string pat_version_cd,
															string pat_prov_cd,
															decimal? pat_birth_datemin,
															decimal? pat_birth_datemax,
															string pat_sex,
															string pat_surname,
															string pat_given_name,
															string pat_init,
															string pat_phone_nbr,
															string subscr_addr1,
															string subscr_addr2,
															string subscr_addr3,
															string subscr_prov_cd,
															string subscr_postal_cd,
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
					new SqlParameter("CLMDTL_ID",clmdtl_id),
					new SqlParameter("minCLMDTL_NBR_SERV",clmdtl_nbr_servmin),
					new SqlParameter("maxCLMDTL_NBR_SERV",clmdtl_nbr_servmax),
					new SqlParameter("CLMDTL_SV_DATE",clmdtl_sv_date),
					new SqlParameter("minCLMDTL_CONSEC_DATES",clmdtl_consec_datesmin),
					new SqlParameter("maxCLMDTL_CONSEC_DATES",clmdtl_consec_datesmax),
					new SqlParameter("minCLMDTL_SV_NBR1",clmdtl_sv_nbr1min),
					new SqlParameter("maxCLMDTL_SV_NBR1",clmdtl_sv_nbr1max),
					new SqlParameter("minCLMDTL_SV_NBR2",clmdtl_sv_nbr2min),
					new SqlParameter("maxCLMDTL_SV_NBR2",clmdtl_sv_nbr2max),
					new SqlParameter("minCLMDTL_SV_NBR3",clmdtl_sv_nbr3min),
					new SqlParameter("maxCLMDTL_SV_NBR3",clmdtl_sv_nbr3max),
					new SqlParameter("minCLMDTL_SV_DAY1",clmdtl_sv_day1min),
					new SqlParameter("maxCLMDTL_SV_DAY1",clmdtl_sv_day1max),
					new SqlParameter("minCLMDTL_SV_DAY2",clmdtl_sv_day2min),
					new SqlParameter("maxCLMDTL_SV_DAY2",clmdtl_sv_day2max),
					new SqlParameter("minCLMDTL_SV_DAY3",clmdtl_sv_day3min),
					new SqlParameter("maxCLMDTL_SV_DAY3",clmdtl_sv_day3max),
					new SqlParameter("minCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmin),
					new SqlParameter("maxCLMDTL_AMT_TECH_BILLED",clmdtl_amt_tech_billedmax),
					new SqlParameter("minCLMDTL_FEE_OMA",clmdtl_fee_omamin),
					new SqlParameter("maxCLMDTL_FEE_OMA",clmdtl_fee_omamax),
					new SqlParameter("minCLMDTL_FEE_OHIP",clmdtl_fee_ohipmin),
					new SqlParameter("maxCLMDTL_FEE_OHIP",clmdtl_fee_ohipmax),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",clmdtl_date_period_end),
					new SqlParameter("CLMHDR_HOSP",clmhdr_hosp),
					new SqlParameter("minCLMHDR_DOC_DEPT",clmhdr_doc_deptmin),
					new SqlParameter("maxCLMHDR_DOC_DEPT",clmhdr_doc_deptmax),
					new SqlParameter("minCLMHDR_AGENT_CD",clmhdr_agent_cdmin),
					new SqlParameter("maxCLMHDR_AGENT_CD",clmhdr_agent_cdmax),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",clmhdr_pat_ohip_id_or_chart),
					new SqlParameter("CLMHDR_LOC",clmhdr_loc),
					new SqlParameter("minCLMHDR_REFER_DOC_NBR",clmhdr_refer_doc_nbrmin),
					new SqlParameter("maxCLMHDR_REFER_DOC_NBR",clmhdr_refer_doc_nbrmax),
					new SqlParameter("minCLMHDR_DIAG_CD",clmhdr_diag_cdmin),
					new SqlParameter("maxCLMHDR_DIAG_CD",clmhdr_diag_cdmax),
					new SqlParameter("minCLMHDR_DOC_SPEC_CD",clmhdr_doc_spec_cdmin),
					new SqlParameter("maxCLMHDR_DOC_SPEC_CD",clmhdr_doc_spec_cdmax),
					new SqlParameter("CLMHDR_I_O_PAT_IND",clmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_DATE_ADMIT",clmhdr_date_admit),
					new SqlParameter("minCLMHDR_DOC_NBR_OHIP",clmhdr_doc_nbr_ohipmin),
					new SqlParameter("maxCLMHDR_DOC_NBR_OHIP",clmhdr_doc_nbr_ohipmax),
					new SqlParameter("PAT_OHIP_MMYY",pat_ohip_mmyy),
					new SqlParameter("PAT_CHART_NBR",pat_chart_nbr),
					new SqlParameter("PAT_CHART_NBR_2",pat_chart_nbr_2),
					new SqlParameter("PAT_CHART_NBR_3",pat_chart_nbr_3),
					new SqlParameter("PAT_CHART_NBR_4",pat_chart_nbr_4),
					new SqlParameter("PAT_CHART_NBR_5",pat_chart_nbr_5),
					new SqlParameter("minPAT_HEALTH_NBR",pat_health_nbrmin),
					new SqlParameter("maxPAT_HEALTH_NBR",pat_health_nbrmax),
					new SqlParameter("PAT_VERSION_CD",pat_version_cd),
					new SqlParameter("PAT_PROV_CD",pat_prov_cd),
					new SqlParameter("minPAT_BIRTH_DATE",pat_birth_datemin),
					new SqlParameter("maxPAT_BIRTH_DATE",pat_birth_datemax),
					new SqlParameter("PAT_SEX",pat_sex),
					new SqlParameter("PAT_SURNAME",pat_surname),
					new SqlParameter("PAT_GIVEN_NAME",pat_given_name),
					new SqlParameter("PAT_INIT",pat_init),
					new SqlParameter("PAT_PHONE_NBR",pat_phone_nbr),
					new SqlParameter("SUBSCR_ADDR1",subscr_addr1),
					new SqlParameter("SUBSCR_ADDR2",subscr_addr2),
					new SqlParameter("SUBSCR_ADDR3",subscr_addr3),
					new SqlParameter("SUBSCR_PROV_CD",subscr_prov_cd),
					new SqlParameter("SUBSCR_POSTAL_CD",subscr_postal_cd),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CLAIMS_HISTORY_SUBFILE>();
				}

            }

            Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_Search]", parameters);
            var collection = new ObservableCollection<CLAIMS_HISTORY_SUBFILE>();

            while (Reader.Read())
            {
                collection.Add(new CLAIMS_HISTORY_SUBFILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_ID = Reader["CLMDTL_ID"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_DATE = Reader["CLMDTL_SV_DATE"].ToString(),
					CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
					CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString(),
					PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					PAT_SURNAME = Reader["PAT_SURNAME"].ToString(),
					PAT_GIVEN_NAME = Reader["PAT_GIVEN_NAME"].ToString(),
					PAT_INIT = Reader["PAT_INIT"].ToString(),
					PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString(),
					SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString(),
					SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString(),
					SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString(),
					SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString(),
					SUBSCR_POSTAL_CD = Reader["SUBSCR_POSTAL_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_id = Reader["CLMDTL_ID"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_date = Reader["CLMDTL_SV_DATE"].ToString(),
					_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString(),
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString(),
					_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalPat_surname = Reader["PAT_SURNAME"].ToString(),
					_originalPat_given_name = Reader["PAT_GIVEN_NAME"].ToString(),
					_originalPat_init = Reader["PAT_INIT"].ToString(),
					_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString(),
					_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString(),
					_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString(),
					_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString(),
					_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString(),
					_originalSubscr_postal_cd = Reader["SUBSCR_POSTAL_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CLAIMS_HISTORY_SUBFILE Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CLAIMS_HISTORY_SUBFILE> Collection(ObservableCollection<CLAIMS_HISTORY_SUBFILE>
                                                               claimsHistorySubfile = null)
        {
            if (IsSameSearch() && claimsHistorySubfile != null)
            {
                return claimsHistorySubfile;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CLAIMS_HISTORY_SUBFILE>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CLMDTL_ID",WhereClmdtl_id),
					new SqlParameter("CLMDTL_NBR_SERV",WhereClmdtl_nbr_serv),
					new SqlParameter("CLMDTL_SV_DATE",WhereClmdtl_sv_date),
					new SqlParameter("CLMDTL_CONSEC_DATES",WhereClmdtl_consec_dates),
					new SqlParameter("CLMDTL_SV_NBR1",WhereClmdtl_sv_nbr1),
					new SqlParameter("CLMDTL_SV_NBR2",WhereClmdtl_sv_nbr2),
					new SqlParameter("CLMDTL_SV_NBR3",WhereClmdtl_sv_nbr3),
					new SqlParameter("CLMDTL_SV_DAY1",WhereClmdtl_sv_day1),
					new SqlParameter("CLMDTL_SV_DAY2",WhereClmdtl_sv_day2),
					new SqlParameter("CLMDTL_SV_DAY3",WhereClmdtl_sv_day3),
					new SqlParameter("CLMDTL_AMT_TECH_BILLED",WhereClmdtl_amt_tech_billed),
					new SqlParameter("CLMDTL_FEE_OMA",WhereClmdtl_fee_oma),
					new SqlParameter("CLMDTL_FEE_OHIP",WhereClmdtl_fee_ohip),
					new SqlParameter("CLMDTL_DATE_PERIOD_END",WhereClmdtl_date_period_end),
					new SqlParameter("CLMHDR_HOSP",WhereClmhdr_hosp),
					new SqlParameter("CLMHDR_DOC_DEPT",WhereClmhdr_doc_dept),
					new SqlParameter("CLMHDR_AGENT_CD",WhereClmhdr_agent_cd),
					new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART",WhereClmhdr_pat_ohip_id_or_chart),
					new SqlParameter("CLMHDR_LOC",WhereClmhdr_loc),
					new SqlParameter("CLMHDR_REFER_DOC_NBR",WhereClmhdr_refer_doc_nbr),
					new SqlParameter("CLMHDR_DIAG_CD",WhereClmhdr_diag_cd),
					new SqlParameter("CLMHDR_DOC_SPEC_CD",WhereClmhdr_doc_spec_cd),
					new SqlParameter("CLMHDR_I_O_PAT_IND",WhereClmhdr_i_o_pat_ind),
					new SqlParameter("CLMHDR_DATE_ADMIT",WhereClmhdr_date_admit),
					new SqlParameter("CLMHDR_DOC_NBR_OHIP",WhereClmhdr_doc_nbr_ohip),
					new SqlParameter("PAT_OHIP_MMYY",WherePat_ohip_mmyy),
					new SqlParameter("PAT_CHART_NBR",WherePat_chart_nbr),
					new SqlParameter("PAT_CHART_NBR_2",WherePat_chart_nbr_2),
					new SqlParameter("PAT_CHART_NBR_3",WherePat_chart_nbr_3),
					new SqlParameter("PAT_CHART_NBR_4",WherePat_chart_nbr_4),
					new SqlParameter("PAT_CHART_NBR_5",WherePat_chart_nbr_5),
					new SqlParameter("PAT_HEALTH_NBR",WherePat_health_nbr),
					new SqlParameter("PAT_VERSION_CD",WherePat_version_cd),
					new SqlParameter("PAT_PROV_CD",WherePat_prov_cd),
					new SqlParameter("PAT_BIRTH_DATE",WherePat_birth_date),
					new SqlParameter("PAT_SEX",WherePat_sex),
					new SqlParameter("PAT_SURNAME",WherePat_surname),
					new SqlParameter("PAT_GIVEN_NAME",WherePat_given_name),
					new SqlParameter("PAT_INIT",WherePat_init),
					new SqlParameter("PAT_PHONE_NBR",WherePat_phone_nbr),
					new SqlParameter("SUBSCR_ADDR1",WhereSubscr_addr1),
					new SqlParameter("SUBSCR_ADDR2",WhereSubscr_addr2),
					new SqlParameter("SUBSCR_ADDR3",WhereSubscr_addr3),
					new SqlParameter("SUBSCR_PROV_CD",WhereSubscr_prov_cd),
					new SqlParameter("SUBSCR_POSTAL_CD",WhereSubscr_postal_cd),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_Match]", parameters);
            var collection = new ObservableCollection<CLAIMS_HISTORY_SUBFILE>();

            while (Reader.Read())
            {
                collection.Add(new CLAIMS_HISTORY_SUBFILE
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CLMDTL_ID = Reader["CLMDTL_ID"].ToString(),
					CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					CLMDTL_SV_DATE = Reader["CLMDTL_SV_DATE"].ToString(),
					CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString(),
					CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString(),
					CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString(),
					PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString(),
					PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString(),
					PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString(),
					PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					PAT_SEX = Reader["PAT_SEX"].ToString(),
					PAT_SURNAME = Reader["PAT_SURNAME"].ToString(),
					PAT_GIVEN_NAME = Reader["PAT_GIVEN_NAME"].ToString(),
					PAT_INIT = Reader["PAT_INIT"].ToString(),
					PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString(),
					SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString(),
					SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString(),
					SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString(),
					SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString(),
					SUBSCR_POSTAL_CD = Reader["SUBSCR_POSTAL_CD"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereClmdtl_id = WhereClmdtl_id,
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv,
					_whereClmdtl_sv_date = WhereClmdtl_sv_date,
					_whereClmdtl_consec_dates = WhereClmdtl_consec_dates,
					_whereClmdtl_sv_nbr1 = WhereClmdtl_sv_nbr1,
					_whereClmdtl_sv_nbr2 = WhereClmdtl_sv_nbr2,
					_whereClmdtl_sv_nbr3 = WhereClmdtl_sv_nbr3,
					_whereClmdtl_sv_day1 = WhereClmdtl_sv_day1,
					_whereClmdtl_sv_day2 = WhereClmdtl_sv_day2,
					_whereClmdtl_sv_day3 = WhereClmdtl_sv_day3,
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed,
					_whereClmdtl_fee_oma = WhereClmdtl_fee_oma,
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip,
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end,
					_whereClmhdr_hosp = WhereClmhdr_hosp,
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept,
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd,
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart,
					_whereClmhdr_loc = WhereClmhdr_loc,
					_whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr,
					_whereClmhdr_diag_cd = WhereClmhdr_diag_cd,
					_whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd,
					_whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind,
					_whereClmhdr_date_admit = WhereClmhdr_date_admit,
					_whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip,
					_wherePat_ohip_mmyy = WherePat_ohip_mmyy,
					_wherePat_chart_nbr = WherePat_chart_nbr,
					_wherePat_chart_nbr_2 = WherePat_chart_nbr_2,
					_wherePat_chart_nbr_3 = WherePat_chart_nbr_3,
					_wherePat_chart_nbr_4 = WherePat_chart_nbr_4,
					_wherePat_chart_nbr_5 = WherePat_chart_nbr_5,
					_wherePat_health_nbr = WherePat_health_nbr,
					_wherePat_version_cd = WherePat_version_cd,
					_wherePat_prov_cd = WherePat_prov_cd,
					_wherePat_birth_date = WherePat_birth_date,
					_wherePat_sex = WherePat_sex,
					_wherePat_surname = WherePat_surname,
					_wherePat_given_name = WherePat_given_name,
					_wherePat_init = WherePat_init,
					_wherePat_phone_nbr = WherePat_phone_nbr,
					_whereSubscr_addr1 = WhereSubscr_addr1,
					_whereSubscr_addr2 = WhereSubscr_addr2,
					_whereSubscr_addr3 = WhereSubscr_addr3,
					_whereSubscr_prov_cd = WhereSubscr_prov_cd,
					_whereSubscr_postal_cd = WhereSubscr_postal_cd,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalClmdtl_id = Reader["CLMDTL_ID"].ToString(),
					_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]),
					_originalClmdtl_sv_date = Reader["CLMDTL_SV_DATE"].ToString(),
					_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]),
					_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]),
					_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]),
					_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]),
					_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]),
					_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]),
					_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]),
					_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]),
					_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]),
					_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]),
					_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString(),
					_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString(),
					_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]),
					_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]),
					_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString(),
					_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString(),
					_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]),
					_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]),
					_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]),
					_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString(),
					_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString(),
					_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]),
					_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString(),
					_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString(),
					_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString(),
					_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString(),
					_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString(),
					_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString(),
					_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]),
					_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString(),
					_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString(),
					_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]),
					_originalPat_sex = Reader["PAT_SEX"].ToString(),
					_originalPat_surname = Reader["PAT_SURNAME"].ToString(),
					_originalPat_given_name = Reader["PAT_GIVEN_NAME"].ToString(),
					_originalPat_init = Reader["PAT_INIT"].ToString(),
					_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString(),
					_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString(),
					_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString(),
					_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString(),
					_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString(),
					_originalSubscr_postal_cd = Reader["SUBSCR_POSTAL_CD"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereClmdtl_id = WhereClmdtl_id;
					_whereClmdtl_nbr_serv = WhereClmdtl_nbr_serv;
					_whereClmdtl_sv_date = WhereClmdtl_sv_date;
					_whereClmdtl_consec_dates = WhereClmdtl_consec_dates;
					_whereClmdtl_sv_nbr1 = WhereClmdtl_sv_nbr1;
					_whereClmdtl_sv_nbr2 = WhereClmdtl_sv_nbr2;
					_whereClmdtl_sv_nbr3 = WhereClmdtl_sv_nbr3;
					_whereClmdtl_sv_day1 = WhereClmdtl_sv_day1;
					_whereClmdtl_sv_day2 = WhereClmdtl_sv_day2;
					_whereClmdtl_sv_day3 = WhereClmdtl_sv_day3;
					_whereClmdtl_amt_tech_billed = WhereClmdtl_amt_tech_billed;
					_whereClmdtl_fee_oma = WhereClmdtl_fee_oma;
					_whereClmdtl_fee_ohip = WhereClmdtl_fee_ohip;
					_whereClmdtl_date_period_end = WhereClmdtl_date_period_end;
					_whereClmhdr_hosp = WhereClmhdr_hosp;
					_whereClmhdr_doc_dept = WhereClmhdr_doc_dept;
					_whereClmhdr_agent_cd = WhereClmhdr_agent_cd;
					_whereClmhdr_pat_ohip_id_or_chart = WhereClmhdr_pat_ohip_id_or_chart;
					_whereClmhdr_loc = WhereClmhdr_loc;
					_whereClmhdr_refer_doc_nbr = WhereClmhdr_refer_doc_nbr;
					_whereClmhdr_diag_cd = WhereClmhdr_diag_cd;
					_whereClmhdr_doc_spec_cd = WhereClmhdr_doc_spec_cd;
					_whereClmhdr_i_o_pat_ind = WhereClmhdr_i_o_pat_ind;
					_whereClmhdr_date_admit = WhereClmhdr_date_admit;
					_whereClmhdr_doc_nbr_ohip = WhereClmhdr_doc_nbr_ohip;
					_wherePat_ohip_mmyy = WherePat_ohip_mmyy;
					_wherePat_chart_nbr = WherePat_chart_nbr;
					_wherePat_chart_nbr_2 = WherePat_chart_nbr_2;
					_wherePat_chart_nbr_3 = WherePat_chart_nbr_3;
					_wherePat_chart_nbr_4 = WherePat_chart_nbr_4;
					_wherePat_chart_nbr_5 = WherePat_chart_nbr_5;
					_wherePat_health_nbr = WherePat_health_nbr;
					_wherePat_version_cd = WherePat_version_cd;
					_wherePat_prov_cd = WherePat_prov_cd;
					_wherePat_birth_date = WherePat_birth_date;
					_wherePat_sex = WherePat_sex;
					_wherePat_surname = WherePat_surname;
					_wherePat_given_name = WherePat_given_name;
					_wherePat_init = WherePat_init;
					_wherePat_phone_nbr = WherePat_phone_nbr;
					_whereSubscr_addr1 = WhereSubscr_addr1;
					_whereSubscr_addr2 = WhereSubscr_addr2;
					_whereSubscr_addr3 = WhereSubscr_addr3;
					_whereSubscr_prov_cd = WhereSubscr_prov_cd;
					_whereSubscr_postal_cd = WhereSubscr_postal_cd;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereClmdtl_id == null 
				&& WhereClmdtl_nbr_serv == null 
				&& WhereClmdtl_sv_date == null 
				&& WhereClmdtl_consec_dates == null 
				&& WhereClmdtl_sv_nbr1 == null 
				&& WhereClmdtl_sv_nbr2 == null 
				&& WhereClmdtl_sv_nbr3 == null 
				&& WhereClmdtl_sv_day1 == null 
				&& WhereClmdtl_sv_day2 == null 
				&& WhereClmdtl_sv_day3 == null 
				&& WhereClmdtl_amt_tech_billed == null 
				&& WhereClmdtl_fee_oma == null 
				&& WhereClmdtl_fee_ohip == null 
				&& WhereClmdtl_date_period_end == null 
				&& WhereClmhdr_hosp == null 
				&& WhereClmhdr_doc_dept == null 
				&& WhereClmhdr_agent_cd == null 
				&& WhereClmhdr_pat_ohip_id_or_chart == null 
				&& WhereClmhdr_loc == null 
				&& WhereClmhdr_refer_doc_nbr == null 
				&& WhereClmhdr_diag_cd == null 
				&& WhereClmhdr_doc_spec_cd == null 
				&& WhereClmhdr_i_o_pat_ind == null 
				&& WhereClmhdr_date_admit == null 
				&& WhereClmhdr_doc_nbr_ohip == null 
				&& WherePat_ohip_mmyy == null 
				&& WherePat_chart_nbr == null 
				&& WherePat_chart_nbr_2 == null 
				&& WherePat_chart_nbr_3 == null 
				&& WherePat_chart_nbr_4 == null 
				&& WherePat_chart_nbr_5 == null 
				&& WherePat_health_nbr == null 
				&& WherePat_version_cd == null 
				&& WherePat_prov_cd == null 
				&& WherePat_birth_date == null 
				&& WherePat_sex == null 
				&& WherePat_surname == null 
				&& WherePat_given_name == null 
				&& WherePat_init == null 
				&& WherePat_phone_nbr == null 
				&& WhereSubscr_addr1 == null 
				&& WhereSubscr_addr2 == null 
				&& WhereSubscr_addr3 == null 
				&& WhereSubscr_prov_cd == null 
				&& WhereSubscr_postal_cd == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereClmdtl_id ==  _whereClmdtl_id
				&& WhereClmdtl_nbr_serv ==  _whereClmdtl_nbr_serv
				&& WhereClmdtl_sv_date ==  _whereClmdtl_sv_date
				&& WhereClmdtl_consec_dates ==  _whereClmdtl_consec_dates
				&& WhereClmdtl_sv_nbr1 ==  _whereClmdtl_sv_nbr1
				&& WhereClmdtl_sv_nbr2 ==  _whereClmdtl_sv_nbr2
				&& WhereClmdtl_sv_nbr3 ==  _whereClmdtl_sv_nbr3
				&& WhereClmdtl_sv_day1 ==  _whereClmdtl_sv_day1
				&& WhereClmdtl_sv_day2 ==  _whereClmdtl_sv_day2
				&& WhereClmdtl_sv_day3 ==  _whereClmdtl_sv_day3
				&& WhereClmdtl_amt_tech_billed ==  _whereClmdtl_amt_tech_billed
				&& WhereClmdtl_fee_oma ==  _whereClmdtl_fee_oma
				&& WhereClmdtl_fee_ohip ==  _whereClmdtl_fee_ohip
				&& WhereClmdtl_date_period_end ==  _whereClmdtl_date_period_end
				&& WhereClmhdr_hosp ==  _whereClmhdr_hosp
				&& WhereClmhdr_doc_dept ==  _whereClmhdr_doc_dept
				&& WhereClmhdr_agent_cd ==  _whereClmhdr_agent_cd
				&& WhereClmhdr_pat_ohip_id_or_chart ==  _whereClmhdr_pat_ohip_id_or_chart
				&& WhereClmhdr_loc ==  _whereClmhdr_loc
				&& WhereClmhdr_refer_doc_nbr ==  _whereClmhdr_refer_doc_nbr
				&& WhereClmhdr_diag_cd ==  _whereClmhdr_diag_cd
				&& WhereClmhdr_doc_spec_cd ==  _whereClmhdr_doc_spec_cd
				&& WhereClmhdr_i_o_pat_ind ==  _whereClmhdr_i_o_pat_ind
				&& WhereClmhdr_date_admit ==  _whereClmhdr_date_admit
				&& WhereClmhdr_doc_nbr_ohip ==  _whereClmhdr_doc_nbr_ohip
				&& WherePat_ohip_mmyy ==  _wherePat_ohip_mmyy
				&& WherePat_chart_nbr ==  _wherePat_chart_nbr
				&& WherePat_chart_nbr_2 ==  _wherePat_chart_nbr_2
				&& WherePat_chart_nbr_3 ==  _wherePat_chart_nbr_3
				&& WherePat_chart_nbr_4 ==  _wherePat_chart_nbr_4
				&& WherePat_chart_nbr_5 ==  _wherePat_chart_nbr_5
				&& WherePat_health_nbr ==  _wherePat_health_nbr
				&& WherePat_version_cd ==  _wherePat_version_cd
				&& WherePat_prov_cd ==  _wherePat_prov_cd
				&& WherePat_birth_date ==  _wherePat_birth_date
				&& WherePat_sex ==  _wherePat_sex
				&& WherePat_surname ==  _wherePat_surname
				&& WherePat_given_name ==  _wherePat_given_name
				&& WherePat_init ==  _wherePat_init
				&& WherePat_phone_nbr ==  _wherePat_phone_nbr
				&& WhereSubscr_addr1 ==  _whereSubscr_addr1
				&& WhereSubscr_addr2 ==  _whereSubscr_addr2
				&& WhereSubscr_addr3 ==  _whereSubscr_addr3
				&& WhereSubscr_prov_cd ==  _whereSubscr_prov_cd
				&& WhereSubscr_postal_cd ==  _whereSubscr_postal_cd
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereClmdtl_id = null; 
			WhereClmdtl_nbr_serv = null; 
			WhereClmdtl_sv_date = null; 
			WhereClmdtl_consec_dates = null; 
			WhereClmdtl_sv_nbr1 = null; 
			WhereClmdtl_sv_nbr2 = null; 
			WhereClmdtl_sv_nbr3 = null; 
			WhereClmdtl_sv_day1 = null; 
			WhereClmdtl_sv_day2 = null; 
			WhereClmdtl_sv_day3 = null; 
			WhereClmdtl_amt_tech_billed = null; 
			WhereClmdtl_fee_oma = null; 
			WhereClmdtl_fee_ohip = null; 
			WhereClmdtl_date_period_end = null; 
			WhereClmhdr_hosp = null; 
			WhereClmhdr_doc_dept = null; 
			WhereClmhdr_agent_cd = null; 
			WhereClmhdr_pat_ohip_id_or_chart = null; 
			WhereClmhdr_loc = null; 
			WhereClmhdr_refer_doc_nbr = null; 
			WhereClmhdr_diag_cd = null; 
			WhereClmhdr_doc_spec_cd = null; 
			WhereClmhdr_i_o_pat_ind = null; 
			WhereClmhdr_date_admit = null; 
			WhereClmhdr_doc_nbr_ohip = null; 
			WherePat_ohip_mmyy = null; 
			WherePat_chart_nbr = null; 
			WherePat_chart_nbr_2 = null; 
			WherePat_chart_nbr_3 = null; 
			WherePat_chart_nbr_4 = null; 
			WherePat_chart_nbr_5 = null; 
			WherePat_health_nbr = null; 
			WherePat_version_cd = null; 
			WherePat_prov_cd = null; 
			WherePat_birth_date = null; 
			WherePat_sex = null; 
			WherePat_surname = null; 
			WherePat_given_name = null; 
			WherePat_init = null; 
			WherePat_phone_nbr = null; 
			WhereSubscr_addr1 = null; 
			WhereSubscr_addr2 = null; 
			WhereSubscr_addr3 = null; 
			WhereSubscr_prov_cd = null; 
			WhereSubscr_postal_cd = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _CLMDTL_ID;
		private decimal? _CLMDTL_NBR_SERV;
		private string _CLMDTL_SV_DATE;
		private decimal? _CLMDTL_CONSEC_DATES;
		private decimal? _CLMDTL_SV_NBR1;
		private decimal? _CLMDTL_SV_NBR2;
		private decimal? _CLMDTL_SV_NBR3;
		private decimal? _CLMDTL_SV_DAY1;
		private decimal? _CLMDTL_SV_DAY2;
		private decimal? _CLMDTL_SV_DAY3;
		private decimal? _CLMDTL_AMT_TECH_BILLED;
		private decimal? _CLMDTL_FEE_OMA;
		private decimal? _CLMDTL_FEE_OHIP;
		private string _CLMDTL_DATE_PERIOD_END;
		private string _CLMHDR_HOSP;
		private decimal? _CLMHDR_DOC_DEPT;
		private decimal? _CLMHDR_AGENT_CD;
		private string _CLMHDR_PAT_OHIP_ID_OR_CHART;
		private string _CLMHDR_LOC;
		private decimal? _CLMHDR_REFER_DOC_NBR;
		private decimal? _CLMHDR_DIAG_CD;
		private decimal? _CLMHDR_DOC_SPEC_CD;
		private string _CLMHDR_I_O_PAT_IND;
		private string _CLMHDR_DATE_ADMIT;
		private decimal? _CLMHDR_DOC_NBR_OHIP;
		private string _PAT_OHIP_MMYY;
		private string _PAT_CHART_NBR;
		private string _PAT_CHART_NBR_2;
		private string _PAT_CHART_NBR_3;
		private string _PAT_CHART_NBR_4;
		private string _PAT_CHART_NBR_5;
		private decimal? _PAT_HEALTH_NBR;
		private string _PAT_VERSION_CD;
		private string _PAT_PROV_CD;
		private decimal? _PAT_BIRTH_DATE;
		private string _PAT_SEX;
		private string _PAT_SURNAME;
		private string _PAT_GIVEN_NAME;
		private string _PAT_INIT;
		private string _PAT_PHONE_NBR;
		private string _SUBSCR_ADDR1;
		private string _SUBSCR_ADDR2;
		private string _SUBSCR_ADDR3;
		private string _SUBSCR_PROV_CD;
		private string _SUBSCR_POSTAL_CD;
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
		public string CLMDTL_ID
		{
			get { return _CLMDTL_ID; }
			set
			{
				if (_CLMDTL_ID != value)
				{
					_CLMDTL_ID = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_NBR_SERV
		{
			get { return _CLMDTL_NBR_SERV; }
			set
			{
				if (_CLMDTL_NBR_SERV != value)
				{
					_CLMDTL_NBR_SERV = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_SV_DATE
		{
			get { return _CLMDTL_SV_DATE; }
			set
			{
				if (_CLMDTL_SV_DATE != value)
				{
					_CLMDTL_SV_DATE = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_CONSEC_DATES
		{
			get { return _CLMDTL_CONSEC_DATES; }
			set
			{
				if (_CLMDTL_CONSEC_DATES != value)
				{
					_CLMDTL_CONSEC_DATES = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_NBR1
		{
			get { return _CLMDTL_SV_NBR1; }
			set
			{
				if (_CLMDTL_SV_NBR1 != value)
				{
					_CLMDTL_SV_NBR1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_NBR2
		{
			get { return _CLMDTL_SV_NBR2; }
			set
			{
				if (_CLMDTL_SV_NBR2 != value)
				{
					_CLMDTL_SV_NBR2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_NBR3
		{
			get { return _CLMDTL_SV_NBR3; }
			set
			{
				if (_CLMDTL_SV_NBR3 != value)
				{
					_CLMDTL_SV_NBR3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_DAY1
		{
			get { return _CLMDTL_SV_DAY1; }
			set
			{
				if (_CLMDTL_SV_DAY1 != value)
				{
					_CLMDTL_SV_DAY1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_DAY2
		{
			get { return _CLMDTL_SV_DAY2; }
			set
			{
				if (_CLMDTL_SV_DAY2 != value)
				{
					_CLMDTL_SV_DAY2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_SV_DAY3
		{
			get { return _CLMDTL_SV_DAY3; }
			set
			{
				if (_CLMDTL_SV_DAY3 != value)
				{
					_CLMDTL_SV_DAY3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_AMT_TECH_BILLED
		{
			get { return _CLMDTL_AMT_TECH_BILLED; }
			set
			{
				if (_CLMDTL_AMT_TECH_BILLED != value)
				{
					_CLMDTL_AMT_TECH_BILLED = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_FEE_OMA
		{
			get { return _CLMDTL_FEE_OMA; }
			set
			{
				if (_CLMDTL_FEE_OMA != value)
				{
					_CLMDTL_FEE_OMA = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMDTL_FEE_OHIP
		{
			get { return _CLMDTL_FEE_OHIP; }
			set
			{
				if (_CLMDTL_FEE_OHIP != value)
				{
					_CLMDTL_FEE_OHIP = value;
					ChangeState();
				}
			}
		}
		public string CLMDTL_DATE_PERIOD_END
		{
			get { return _CLMDTL_DATE_PERIOD_END; }
			set
			{
				if (_CLMDTL_DATE_PERIOD_END != value)
				{
					_CLMDTL_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_HOSP
		{
			get { return _CLMHDR_HOSP; }
			set
			{
				if (_CLMHDR_HOSP != value)
				{
					_CLMHDR_HOSP = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_DEPT
		{
			get { return _CLMHDR_DOC_DEPT; }
			set
			{
				if (_CLMHDR_DOC_DEPT != value)
				{
					_CLMHDR_DOC_DEPT = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_AGENT_CD
		{
			get { return _CLMHDR_AGENT_CD; }
			set
			{
				if (_CLMHDR_AGENT_CD != value)
				{
					_CLMHDR_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_PAT_OHIP_ID_OR_CHART
		{
			get { return _CLMHDR_PAT_OHIP_ID_OR_CHART; }
			set
			{
				if (_CLMHDR_PAT_OHIP_ID_OR_CHART != value)
				{
					_CLMHDR_PAT_OHIP_ID_OR_CHART = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_LOC
		{
			get { return _CLMHDR_LOC; }
			set
			{
				if (_CLMHDR_LOC != value)
				{
					_CLMHDR_LOC = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_REFER_DOC_NBR
		{
			get { return _CLMHDR_REFER_DOC_NBR; }
			set
			{
				if (_CLMHDR_REFER_DOC_NBR != value)
				{
					_CLMHDR_REFER_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DIAG_CD
		{
			get { return _CLMHDR_DIAG_CD; }
			set
			{
				if (_CLMHDR_DIAG_CD != value)
				{
					_CLMHDR_DIAG_CD = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_SPEC_CD
		{
			get { return _CLMHDR_DOC_SPEC_CD; }
			set
			{
				if (_CLMHDR_DOC_SPEC_CD != value)
				{
					_CLMHDR_DOC_SPEC_CD = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_I_O_PAT_IND
		{
			get { return _CLMHDR_I_O_PAT_IND; }
			set
			{
				if (_CLMHDR_I_O_PAT_IND != value)
				{
					_CLMHDR_I_O_PAT_IND = value;
					ChangeState();
				}
			}
		}
		public string CLMHDR_DATE_ADMIT
		{
			get { return _CLMHDR_DATE_ADMIT; }
			set
			{
				if (_CLMHDR_DATE_ADMIT != value)
				{
					_CLMHDR_DATE_ADMIT = value;
					ChangeState();
				}
			}
		}
		public decimal? CLMHDR_DOC_NBR_OHIP
		{
			get { return _CLMHDR_DOC_NBR_OHIP; }
			set
			{
				if (_CLMHDR_DOC_NBR_OHIP != value)
				{
					_CLMHDR_DOC_NBR_OHIP = value;
					ChangeState();
				}
			}
		}
		public string PAT_OHIP_MMYY
		{
			get { return _PAT_OHIP_MMYY; }
			set
			{
				if (_PAT_OHIP_MMYY != value)
				{
					_PAT_OHIP_MMYY = value;
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
		public decimal? PAT_BIRTH_DATE
		{
			get { return _PAT_BIRTH_DATE; }
			set
			{
				if (_PAT_BIRTH_DATE != value)
				{
					_PAT_BIRTH_DATE = value;
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
		public string PAT_SURNAME
		{
			get { return _PAT_SURNAME; }
			set
			{
				if (_PAT_SURNAME != value)
				{
					_PAT_SURNAME = value;
					ChangeState();
				}
			}
		}
		public string PAT_GIVEN_NAME
		{
			get { return _PAT_GIVEN_NAME; }
			set
			{
				if (_PAT_GIVEN_NAME != value)
				{
					_PAT_GIVEN_NAME = value;
					ChangeState();
				}
			}
		}
		public string PAT_INIT
		{
			get { return _PAT_INIT; }
			set
			{
				if (_PAT_INIT != value)
				{
					_PAT_INIT = value;
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
		public string SUBSCR_POSTAL_CD
		{
			get { return _SUBSCR_POSTAL_CD; }
			set
			{
				if (_SUBSCR_POSTAL_CD != value)
				{
					_SUBSCR_POSTAL_CD = value;
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
		public string WhereClmdtl_id { get; set; }
		private string _whereClmdtl_id;
		public decimal? WhereClmdtl_nbr_serv { get; set; }
		private decimal? _whereClmdtl_nbr_serv;
		public string WhereClmdtl_sv_date { get; set; }
		private string _whereClmdtl_sv_date;
		public decimal? WhereClmdtl_consec_dates { get; set; }
		private decimal? _whereClmdtl_consec_dates;
		public decimal? WhereClmdtl_sv_nbr1 { get; set; }
		private decimal? _whereClmdtl_sv_nbr1;
		public decimal? WhereClmdtl_sv_nbr2 { get; set; }
		private decimal? _whereClmdtl_sv_nbr2;
		public decimal? WhereClmdtl_sv_nbr3 { get; set; }
		private decimal? _whereClmdtl_sv_nbr3;
		public decimal? WhereClmdtl_sv_day1 { get; set; }
		private decimal? _whereClmdtl_sv_day1;
		public decimal? WhereClmdtl_sv_day2 { get; set; }
		private decimal? _whereClmdtl_sv_day2;
		public decimal? WhereClmdtl_sv_day3 { get; set; }
		private decimal? _whereClmdtl_sv_day3;
		public decimal? WhereClmdtl_amt_tech_billed { get; set; }
		private decimal? _whereClmdtl_amt_tech_billed;
		public decimal? WhereClmdtl_fee_oma { get; set; }
		private decimal? _whereClmdtl_fee_oma;
		public decimal? WhereClmdtl_fee_ohip { get; set; }
		private decimal? _whereClmdtl_fee_ohip;
		public string WhereClmdtl_date_period_end { get; set; }
		private string _whereClmdtl_date_period_end;
		public string WhereClmhdr_hosp { get; set; }
		private string _whereClmhdr_hosp;
		public decimal? WhereClmhdr_doc_dept { get; set; }
		private decimal? _whereClmhdr_doc_dept;
		public decimal? WhereClmhdr_agent_cd { get; set; }
		private decimal? _whereClmhdr_agent_cd;
		public string WhereClmhdr_pat_ohip_id_or_chart { get; set; }
		private string _whereClmhdr_pat_ohip_id_or_chart;
		public string WhereClmhdr_loc { get; set; }
		private string _whereClmhdr_loc;
		public decimal? WhereClmhdr_refer_doc_nbr { get; set; }
		private decimal? _whereClmhdr_refer_doc_nbr;
		public decimal? WhereClmhdr_diag_cd { get; set; }
		private decimal? _whereClmhdr_diag_cd;
		public decimal? WhereClmhdr_doc_spec_cd { get; set; }
		private decimal? _whereClmhdr_doc_spec_cd;
		public string WhereClmhdr_i_o_pat_ind { get; set; }
		private string _whereClmhdr_i_o_pat_ind;
		public string WhereClmhdr_date_admit { get; set; }
		private string _whereClmhdr_date_admit;
		public decimal? WhereClmhdr_doc_nbr_ohip { get; set; }
		private decimal? _whereClmhdr_doc_nbr_ohip;
		public string WherePat_ohip_mmyy { get; set; }
		private string _wherePat_ohip_mmyy;
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
		public decimal? WherePat_health_nbr { get; set; }
		private decimal? _wherePat_health_nbr;
		public string WherePat_version_cd { get; set; }
		private string _wherePat_version_cd;
		public string WherePat_prov_cd { get; set; }
		private string _wherePat_prov_cd;
		public decimal? WherePat_birth_date { get; set; }
		private decimal? _wherePat_birth_date;
		public string WherePat_sex { get; set; }
		private string _wherePat_sex;
		public string WherePat_surname { get; set; }
		private string _wherePat_surname;
		public string WherePat_given_name { get; set; }
		private string _wherePat_given_name;
		public string WherePat_init { get; set; }
		private string _wherePat_init;
		public string WherePat_phone_nbr { get; set; }
		private string _wherePat_phone_nbr;
		public string WhereSubscr_addr1 { get; set; }
		private string _whereSubscr_addr1;
		public string WhereSubscr_addr2 { get; set; }
		private string _whereSubscr_addr2;
		public string WhereSubscr_addr3 { get; set; }
		private string _whereSubscr_addr3;
		public string WhereSubscr_prov_cd { get; set; }
		private string _whereSubscr_prov_cd;
		public string WhereSubscr_postal_cd { get; set; }
		private string _whereSubscr_postal_cd;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalClmdtl_id;
		private decimal? _originalClmdtl_nbr_serv;
		private string _originalClmdtl_sv_date;
		private decimal? _originalClmdtl_consec_dates;
		private decimal? _originalClmdtl_sv_nbr1;
		private decimal? _originalClmdtl_sv_nbr2;
		private decimal? _originalClmdtl_sv_nbr3;
		private decimal? _originalClmdtl_sv_day1;
		private decimal? _originalClmdtl_sv_day2;
		private decimal? _originalClmdtl_sv_day3;
		private decimal? _originalClmdtl_amt_tech_billed;
		private decimal? _originalClmdtl_fee_oma;
		private decimal? _originalClmdtl_fee_ohip;
		private string _originalClmdtl_date_period_end;
		private string _originalClmhdr_hosp;
		private decimal? _originalClmhdr_doc_dept;
		private decimal? _originalClmhdr_agent_cd;
		private string _originalClmhdr_pat_ohip_id_or_chart;
		private string _originalClmhdr_loc;
		private decimal? _originalClmhdr_refer_doc_nbr;
		private decimal? _originalClmhdr_diag_cd;
		private decimal? _originalClmhdr_doc_spec_cd;
		private string _originalClmhdr_i_o_pat_ind;
		private string _originalClmhdr_date_admit;
		private decimal? _originalClmhdr_doc_nbr_ohip;
		private string _originalPat_ohip_mmyy;
		private string _originalPat_chart_nbr;
		private string _originalPat_chart_nbr_2;
		private string _originalPat_chart_nbr_3;
		private string _originalPat_chart_nbr_4;
		private string _originalPat_chart_nbr_5;
		private decimal? _originalPat_health_nbr;
		private string _originalPat_version_cd;
		private string _originalPat_prov_cd;
		private decimal? _originalPat_birth_date;
		private string _originalPat_sex;
		private string _originalPat_surname;
		private string _originalPat_given_name;
		private string _originalPat_init;
		private string _originalPat_phone_nbr;
		private string _originalSubscr_addr1;
		private string _originalSubscr_addr2;
		private string _originalSubscr_addr3;
		private string _originalSubscr_prov_cd;
		private string _originalSubscr_postal_cd;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CLMDTL_ID = _originalClmdtl_id;
			CLMDTL_NBR_SERV = _originalClmdtl_nbr_serv;
			CLMDTL_SV_DATE = _originalClmdtl_sv_date;
			CLMDTL_CONSEC_DATES = _originalClmdtl_consec_dates;
			CLMDTL_SV_NBR1 = _originalClmdtl_sv_nbr1;
			CLMDTL_SV_NBR2 = _originalClmdtl_sv_nbr2;
			CLMDTL_SV_NBR3 = _originalClmdtl_sv_nbr3;
			CLMDTL_SV_DAY1 = _originalClmdtl_sv_day1;
			CLMDTL_SV_DAY2 = _originalClmdtl_sv_day2;
			CLMDTL_SV_DAY3 = _originalClmdtl_sv_day3;
			CLMDTL_AMT_TECH_BILLED = _originalClmdtl_amt_tech_billed;
			CLMDTL_FEE_OMA = _originalClmdtl_fee_oma;
			CLMDTL_FEE_OHIP = _originalClmdtl_fee_ohip;
			CLMDTL_DATE_PERIOD_END = _originalClmdtl_date_period_end;
			CLMHDR_HOSP = _originalClmhdr_hosp;
			CLMHDR_DOC_DEPT = _originalClmhdr_doc_dept;
			CLMHDR_AGENT_CD = _originalClmhdr_agent_cd;
			CLMHDR_PAT_OHIP_ID_OR_CHART = _originalClmhdr_pat_ohip_id_or_chart;
			CLMHDR_LOC = _originalClmhdr_loc;
			CLMHDR_REFER_DOC_NBR = _originalClmhdr_refer_doc_nbr;
			CLMHDR_DIAG_CD = _originalClmhdr_diag_cd;
			CLMHDR_DOC_SPEC_CD = _originalClmhdr_doc_spec_cd;
			CLMHDR_I_O_PAT_IND = _originalClmhdr_i_o_pat_ind;
			CLMHDR_DATE_ADMIT = _originalClmhdr_date_admit;
			CLMHDR_DOC_NBR_OHIP = _originalClmhdr_doc_nbr_ohip;
			PAT_OHIP_MMYY = _originalPat_ohip_mmyy;
			PAT_CHART_NBR = _originalPat_chart_nbr;
			PAT_CHART_NBR_2 = _originalPat_chart_nbr_2;
			PAT_CHART_NBR_3 = _originalPat_chart_nbr_3;
			PAT_CHART_NBR_4 = _originalPat_chart_nbr_4;
			PAT_CHART_NBR_5 = _originalPat_chart_nbr_5;
			PAT_HEALTH_NBR = _originalPat_health_nbr;
			PAT_VERSION_CD = _originalPat_version_cd;
			PAT_PROV_CD = _originalPat_prov_cd;
			PAT_BIRTH_DATE = _originalPat_birth_date;
			PAT_SEX = _originalPat_sex;
			PAT_SURNAME = _originalPat_surname;
			PAT_GIVEN_NAME = _originalPat_given_name;
			PAT_INIT = _originalPat_init;
			PAT_PHONE_NBR = _originalPat_phone_nbr;
			SUBSCR_ADDR1 = _originalSubscr_addr1;
			SUBSCR_ADDR2 = _originalSubscr_addr2;
			SUBSCR_ADDR3 = _originalSubscr_addr3;
			SUBSCR_PROV_CD = _originalSubscr_prov_cd;
			SUBSCR_POSTAL_CD = _originalSubscr_postal_cd;
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
			RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_Purge]");
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
						new SqlParameter("CLMDTL_ID", SqlNull(CLMDTL_ID)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_SV_DATE", SqlNull(CLMDTL_SV_DATE)),
						new SqlParameter("CLMDTL_CONSEC_DATES", SqlNull(CLMDTL_CONSEC_DATES)),
						new SqlParameter("CLMDTL_SV_NBR1", SqlNull(CLMDTL_SV_NBR1)),
						new SqlParameter("CLMDTL_SV_NBR2", SqlNull(CLMDTL_SV_NBR2)),
						new SqlParameter("CLMDTL_SV_NBR3", SqlNull(CLMDTL_SV_NBR3)),
						new SqlParameter("CLMDTL_SV_DAY1", SqlNull(CLMDTL_SV_DAY1)),
						new SqlParameter("CLMDTL_SV_DAY2", SqlNull(CLMDTL_SV_DAY2)),
						new SqlParameter("CLMDTL_SV_DAY3", SqlNull(CLMDTL_SV_DAY3)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_FEE_OMA", SqlNull(CLMDTL_FEE_OMA)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_HOSP", SqlNull(CLMHDR_HOSP)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_REFER_DOC_NBR", SqlNull(CLMHDR_REFER_DOC_NBR)),
						new SqlParameter("CLMHDR_DIAG_CD", SqlNull(CLMHDR_DIAG_CD)),
						new SqlParameter("CLMHDR_DOC_SPEC_CD", SqlNull(CLMHDR_DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_DATE_ADMIT", SqlNull(CLMHDR_DATE_ADMIT)),
						new SqlParameter("CLMHDR_DOC_NBR_OHIP", SqlNull(CLMHDR_DOC_NBR_OHIP)),
						new SqlParameter("PAT_OHIP_MMYY", SqlNull(PAT_OHIP_MMYY)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_CHART_NBR_2", SqlNull(PAT_CHART_NBR_2)),
						new SqlParameter("PAT_CHART_NBR_3", SqlNull(PAT_CHART_NBR_3)),
						new SqlParameter("PAT_CHART_NBR_4", SqlNull(PAT_CHART_NBR_4)),
						new SqlParameter("PAT_CHART_NBR_5", SqlNull(PAT_CHART_NBR_5)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_PROV_CD", SqlNull(PAT_PROV_CD)),
						new SqlParameter("PAT_BIRTH_DATE", SqlNull(PAT_BIRTH_DATE)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("PAT_SURNAME", SqlNull(PAT_SURNAME)),
						new SqlParameter("PAT_GIVEN_NAME", SqlNull(PAT_GIVEN_NAME)),
						new SqlParameter("PAT_INIT", SqlNull(PAT_INIT)),
						new SqlParameter("PAT_PHONE_NBR", SqlNull(PAT_PHONE_NBR)),
						new SqlParameter("SUBSCR_ADDR1", SqlNull(SUBSCR_ADDR1)),
						new SqlParameter("SUBSCR_ADDR2", SqlNull(SUBSCR_ADDR2)),
						new SqlParameter("SUBSCR_ADDR3", SqlNull(SUBSCR_ADDR3)),
						new SqlParameter("SUBSCR_PROV_CD", SqlNull(SUBSCR_PROV_CD)),
						new SqlParameter("SUBSCR_POSTAL_CD", SqlNull(SUBSCR_POSTAL_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_ID = Reader["CLMDTL_ID"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_DATE = Reader["CLMDTL_SV_DATE"].ToString();
						CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
						CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
						CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
						CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
						CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
						CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
						CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString();
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString();
						CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString();
						PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString();
						PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString();
						PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString();
						PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						PAT_SEX = Reader["PAT_SEX"].ToString();
						PAT_SURNAME = Reader["PAT_SURNAME"].ToString();
						PAT_GIVEN_NAME = Reader["PAT_GIVEN_NAME"].ToString();
						PAT_INIT = Reader["PAT_INIT"].ToString();
						PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString();
						SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString();
						SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString();
						SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString();
						SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString();
						SUBSCR_POSTAL_CD = Reader["SUBSCR_POSTAL_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_id = Reader["CLMDTL_ID"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_date = Reader["CLMDTL_SV_DATE"].ToString();
						_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
						_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
						_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
						_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
						_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
						_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
						_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString();
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString();
						_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString();
						_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString();
						_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString();
						_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString();
						_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						_originalPat_sex = Reader["PAT_SEX"].ToString();
						_originalPat_surname = Reader["PAT_SURNAME"].ToString();
						_originalPat_given_name = Reader["PAT_GIVEN_NAME"].ToString();
						_originalPat_init = Reader["PAT_INIT"].ToString();
						_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString();
						_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString();
						_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString();
						_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString();
						_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString();
						_originalSubscr_postal_cd = Reader["SUBSCR_POSTAL_CD"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CLMDTL_ID", SqlNull(CLMDTL_ID)),
						new SqlParameter("CLMDTL_NBR_SERV", SqlNull(CLMDTL_NBR_SERV)),
						new SqlParameter("CLMDTL_SV_DATE", SqlNull(CLMDTL_SV_DATE)),
						new SqlParameter("CLMDTL_CONSEC_DATES", SqlNull(CLMDTL_CONSEC_DATES)),
						new SqlParameter("CLMDTL_SV_NBR1", SqlNull(CLMDTL_SV_NBR1)),
						new SqlParameter("CLMDTL_SV_NBR2", SqlNull(CLMDTL_SV_NBR2)),
						new SqlParameter("CLMDTL_SV_NBR3", SqlNull(CLMDTL_SV_NBR3)),
						new SqlParameter("CLMDTL_SV_DAY1", SqlNull(CLMDTL_SV_DAY1)),
						new SqlParameter("CLMDTL_SV_DAY2", SqlNull(CLMDTL_SV_DAY2)),
						new SqlParameter("CLMDTL_SV_DAY3", SqlNull(CLMDTL_SV_DAY3)),
						new SqlParameter("CLMDTL_AMT_TECH_BILLED", SqlNull(CLMDTL_AMT_TECH_BILLED)),
						new SqlParameter("CLMDTL_FEE_OMA", SqlNull(CLMDTL_FEE_OMA)),
						new SqlParameter("CLMDTL_FEE_OHIP", SqlNull(CLMDTL_FEE_OHIP)),
						new SqlParameter("CLMDTL_DATE_PERIOD_END", SqlNull(CLMDTL_DATE_PERIOD_END)),
						new SqlParameter("CLMHDR_HOSP", SqlNull(CLMHDR_HOSP)),
						new SqlParameter("CLMHDR_DOC_DEPT", SqlNull(CLMHDR_DOC_DEPT)),
						new SqlParameter("CLMHDR_AGENT_CD", SqlNull(CLMHDR_AGENT_CD)),
						new SqlParameter("CLMHDR_PAT_OHIP_ID_OR_CHART", SqlNull(CLMHDR_PAT_OHIP_ID_OR_CHART)),
						new SqlParameter("CLMHDR_LOC", SqlNull(CLMHDR_LOC)),
						new SqlParameter("CLMHDR_REFER_DOC_NBR", SqlNull(CLMHDR_REFER_DOC_NBR)),
						new SqlParameter("CLMHDR_DIAG_CD", SqlNull(CLMHDR_DIAG_CD)),
						new SqlParameter("CLMHDR_DOC_SPEC_CD", SqlNull(CLMHDR_DOC_SPEC_CD)),
						new SqlParameter("CLMHDR_I_O_PAT_IND", SqlNull(CLMHDR_I_O_PAT_IND)),
						new SqlParameter("CLMHDR_DATE_ADMIT", SqlNull(CLMHDR_DATE_ADMIT)),
						new SqlParameter("CLMHDR_DOC_NBR_OHIP", SqlNull(CLMHDR_DOC_NBR_OHIP)),
						new SqlParameter("PAT_OHIP_MMYY", SqlNull(PAT_OHIP_MMYY)),
						new SqlParameter("PAT_CHART_NBR", SqlNull(PAT_CHART_NBR)),
						new SqlParameter("PAT_CHART_NBR_2", SqlNull(PAT_CHART_NBR_2)),
						new SqlParameter("PAT_CHART_NBR_3", SqlNull(PAT_CHART_NBR_3)),
						new SqlParameter("PAT_CHART_NBR_4", SqlNull(PAT_CHART_NBR_4)),
						new SqlParameter("PAT_CHART_NBR_5", SqlNull(PAT_CHART_NBR_5)),
						new SqlParameter("PAT_HEALTH_NBR", SqlNull(PAT_HEALTH_NBR)),
						new SqlParameter("PAT_VERSION_CD", SqlNull(PAT_VERSION_CD)),
						new SqlParameter("PAT_PROV_CD", SqlNull(PAT_PROV_CD)),
						new SqlParameter("PAT_BIRTH_DATE", SqlNull(PAT_BIRTH_DATE)),
						new SqlParameter("PAT_SEX", SqlNull(PAT_SEX)),
						new SqlParameter("PAT_SURNAME", SqlNull(PAT_SURNAME)),
						new SqlParameter("PAT_GIVEN_NAME", SqlNull(PAT_GIVEN_NAME)),
						new SqlParameter("PAT_INIT", SqlNull(PAT_INIT)),
						new SqlParameter("PAT_PHONE_NBR", SqlNull(PAT_PHONE_NBR)),
						new SqlParameter("SUBSCR_ADDR1", SqlNull(SUBSCR_ADDR1)),
						new SqlParameter("SUBSCR_ADDR2", SqlNull(SUBSCR_ADDR2)),
						new SqlParameter("SUBSCR_ADDR3", SqlNull(SUBSCR_ADDR3)),
						new SqlParameter("SUBSCR_PROV_CD", SqlNull(SUBSCR_PROV_CD)),
						new SqlParameter("SUBSCR_POSTAL_CD", SqlNull(SUBSCR_POSTAL_CD)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[SEQUENTIAL].[sp_CLAIMS_HISTORY_SUBFILE_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CLMDTL_ID = Reader["CLMDTL_ID"].ToString();
						CLMDTL_NBR_SERV = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						CLMDTL_SV_DATE = Reader["CLMDTL_SV_DATE"].ToString();
						CLMDTL_CONSEC_DATES = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						CLMDTL_SV_NBR1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
						CLMDTL_SV_NBR2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
						CLMDTL_SV_NBR3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
						CLMDTL_SV_DAY1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
						CLMDTL_SV_DAY2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
						CLMDTL_SV_DAY3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
						CLMDTL_AMT_TECH_BILLED = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						CLMDTL_FEE_OMA = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						CLMDTL_FEE_OHIP = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						CLMDTL_DATE_PERIOD_END = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						CLMHDR_HOSP = Reader["CLMHDR_HOSP"].ToString();
						CLMHDR_DOC_DEPT = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						CLMHDR_AGENT_CD = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						CLMHDR_PAT_OHIP_ID_OR_CHART = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						CLMHDR_LOC = Reader["CLMHDR_LOC"].ToString();
						CLMHDR_REFER_DOC_NBR = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						CLMHDR_DIAG_CD = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						CLMHDR_DOC_SPEC_CD = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						CLMHDR_I_O_PAT_IND = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						CLMHDR_DATE_ADMIT = Reader["CLMHDR_DATE_ADMIT"].ToString();
						CLMHDR_DOC_NBR_OHIP = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						PAT_OHIP_MMYY = Reader["PAT_OHIP_MMYY"].ToString();
						PAT_CHART_NBR = Reader["PAT_CHART_NBR"].ToString();
						PAT_CHART_NBR_2 = Reader["PAT_CHART_NBR_2"].ToString();
						PAT_CHART_NBR_3 = Reader["PAT_CHART_NBR_3"].ToString();
						PAT_CHART_NBR_4 = Reader["PAT_CHART_NBR_4"].ToString();
						PAT_CHART_NBR_5 = Reader["PAT_CHART_NBR_5"].ToString();
						PAT_HEALTH_NBR = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						PAT_VERSION_CD = Reader["PAT_VERSION_CD"].ToString();
						PAT_PROV_CD = Reader["PAT_PROV_CD"].ToString();
						PAT_BIRTH_DATE = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						PAT_SEX = Reader["PAT_SEX"].ToString();
						PAT_SURNAME = Reader["PAT_SURNAME"].ToString();
						PAT_GIVEN_NAME = Reader["PAT_GIVEN_NAME"].ToString();
						PAT_INIT = Reader["PAT_INIT"].ToString();
						PAT_PHONE_NBR = Reader["PAT_PHONE_NBR"].ToString();
						SUBSCR_ADDR1 = Reader["SUBSCR_ADDR1"].ToString();
						SUBSCR_ADDR2 = Reader["SUBSCR_ADDR2"].ToString();
						SUBSCR_ADDR3 = Reader["SUBSCR_ADDR3"].ToString();
						SUBSCR_PROV_CD = Reader["SUBSCR_PROV_CD"].ToString();
						SUBSCR_POSTAL_CD = Reader["SUBSCR_POSTAL_CD"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalClmdtl_id = Reader["CLMDTL_ID"].ToString();
						_originalClmdtl_nbr_serv = ConvertDEC(Reader["CLMDTL_NBR_SERV"]);
						_originalClmdtl_sv_date = Reader["CLMDTL_SV_DATE"].ToString();
						_originalClmdtl_consec_dates = ConvertDEC(Reader["CLMDTL_CONSEC_DATES"]);
						_originalClmdtl_sv_nbr1 = ConvertDEC(Reader["CLMDTL_SV_NBR1"]);
						_originalClmdtl_sv_nbr2 = ConvertDEC(Reader["CLMDTL_SV_NBR2"]);
						_originalClmdtl_sv_nbr3 = ConvertDEC(Reader["CLMDTL_SV_NBR3"]);
						_originalClmdtl_sv_day1 = ConvertDEC(Reader["CLMDTL_SV_DAY1"]);
						_originalClmdtl_sv_day2 = ConvertDEC(Reader["CLMDTL_SV_DAY2"]);
						_originalClmdtl_sv_day3 = ConvertDEC(Reader["CLMDTL_SV_DAY3"]);
						_originalClmdtl_amt_tech_billed = ConvertDEC(Reader["CLMDTL_AMT_TECH_BILLED"]);
						_originalClmdtl_fee_oma = ConvertDEC(Reader["CLMDTL_FEE_OMA"]);
						_originalClmdtl_fee_ohip = ConvertDEC(Reader["CLMDTL_FEE_OHIP"]);
						_originalClmdtl_date_period_end = Reader["CLMDTL_DATE_PERIOD_END"].ToString();
						_originalClmhdr_hosp = Reader["CLMHDR_HOSP"].ToString();
						_originalClmhdr_doc_dept = ConvertDEC(Reader["CLMHDR_DOC_DEPT"]);
						_originalClmhdr_agent_cd = ConvertDEC(Reader["CLMHDR_AGENT_CD"]);
						_originalClmhdr_pat_ohip_id_or_chart = Reader["CLMHDR_PAT_OHIP_ID_OR_CHART"].ToString();
						_originalClmhdr_loc = Reader["CLMHDR_LOC"].ToString();
						_originalClmhdr_refer_doc_nbr = ConvertDEC(Reader["CLMHDR_REFER_DOC_NBR"]);
						_originalClmhdr_diag_cd = ConvertDEC(Reader["CLMHDR_DIAG_CD"]);
						_originalClmhdr_doc_spec_cd = ConvertDEC(Reader["CLMHDR_DOC_SPEC_CD"]);
						_originalClmhdr_i_o_pat_ind = Reader["CLMHDR_I_O_PAT_IND"].ToString();
						_originalClmhdr_date_admit = Reader["CLMHDR_DATE_ADMIT"].ToString();
						_originalClmhdr_doc_nbr_ohip = ConvertDEC(Reader["CLMHDR_DOC_NBR_OHIP"]);
						_originalPat_ohip_mmyy = Reader["PAT_OHIP_MMYY"].ToString();
						_originalPat_chart_nbr = Reader["PAT_CHART_NBR"].ToString();
						_originalPat_chart_nbr_2 = Reader["PAT_CHART_NBR_2"].ToString();
						_originalPat_chart_nbr_3 = Reader["PAT_CHART_NBR_3"].ToString();
						_originalPat_chart_nbr_4 = Reader["PAT_CHART_NBR_4"].ToString();
						_originalPat_chart_nbr_5 = Reader["PAT_CHART_NBR_5"].ToString();
						_originalPat_health_nbr = ConvertDEC(Reader["PAT_HEALTH_NBR"]);
						_originalPat_version_cd = Reader["PAT_VERSION_CD"].ToString();
						_originalPat_prov_cd = Reader["PAT_PROV_CD"].ToString();
						_originalPat_birth_date = ConvertDEC(Reader["PAT_BIRTH_DATE"]);
						_originalPat_sex = Reader["PAT_SEX"].ToString();
						_originalPat_surname = Reader["PAT_SURNAME"].ToString();
						_originalPat_given_name = Reader["PAT_GIVEN_NAME"].ToString();
						_originalPat_init = Reader["PAT_INIT"].ToString();
						_originalPat_phone_nbr = Reader["PAT_PHONE_NBR"].ToString();
						_originalSubscr_addr1 = Reader["SUBSCR_ADDR1"].ToString();
						_originalSubscr_addr2 = Reader["SUBSCR_ADDR2"].ToString();
						_originalSubscr_addr3 = Reader["SUBSCR_ADDR3"].ToString();
						_originalSubscr_prov_cd = Reader["SUBSCR_PROV_CD"].ToString();
						_originalSubscr_postal_cd = Reader["SUBSCR_POSTAL_CD"].ToString();
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