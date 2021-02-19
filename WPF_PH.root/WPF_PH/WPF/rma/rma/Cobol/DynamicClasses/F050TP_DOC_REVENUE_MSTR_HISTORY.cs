using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class F050TP_DOC_REVENUE_MSTR_HISTORY : BaseTable
    {
        #region Retrieve

        public ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY> Collection( Guid? rowid,
															decimal? docrevtp_clinic_nbrmin,
															decimal? docrevtp_clinic_nbrmax,
															string docrevtp_agent_cd,
															string docrevtp_loc_cd,
															string docrevtp_oma_code,
															string docrevtp_oma_suffix,
															string docrevtp_doc_nbr,
															decimal? ep_yrmin,
															decimal? ep_yrmax,
															decimal? iconst_date_period_endmin,
															decimal? iconst_date_period_endmax,
															decimal? docrevtp_in_tech_amt_billed1min,
															decimal? docrevtp_in_tech_amt_billed1max,
															decimal? docrevtp_in_tech_amt_billed2min,
															decimal? docrevtp_in_tech_amt_billed2max,
															decimal? docrevtp_in_tech_amt_adjusts1min,
															decimal? docrevtp_in_tech_amt_adjusts1max,
															decimal? docrevtp_in_tech_amt_adjusts2min,
															decimal? docrevtp_in_tech_amt_adjusts2max,
															decimal? docrevtp_in_tech_nbr_svc1min,
															decimal? docrevtp_in_tech_nbr_svc1max,
															decimal? docrevtp_in_tech_nbr_svc2min,
															decimal? docrevtp_in_tech_nbr_svc2max,
															decimal? docrevtp_in_prof_amt_billed1min,
															decimal? docrevtp_in_prof_amt_billed1max,
															decimal? docrevtp_in_prof_amt_billed2min,
															decimal? docrevtp_in_prof_amt_billed2max,
															decimal? docrevtp_in_prof_amt_adjusts1min,
															decimal? docrevtp_in_prof_amt_adjusts1max,
															decimal? docrevtp_in_prof_amt_adjusts2min,
															decimal? docrevtp_in_prof_amt_adjusts2max,
															decimal? docrevtp_in_prof_nbr_svc1min,
															decimal? docrevtp_in_prof_nbr_svc1max,
															decimal? docrevtp_in_prof_nbr_svc2min,
															decimal? docrevtp_in_prof_nbr_svc2max,
															decimal? docrevtp_out_tech_amt_billed1min,
															decimal? docrevtp_out_tech_amt_billed1max,
															decimal? docrevtp_out_tech_amt_billed2min,
															decimal? docrevtp_out_tech_amt_billed2max,
															decimal? docrevtp_out_tech_amt_adjusts1min,
															decimal? docrevtp_out_tech_amt_adjusts1max,
															decimal? docrevtp_out_tech_amt_adjusts2min,
															decimal? docrevtp_out_tech_amt_adjusts2max,
															decimal? docrevtp_out_tech_nbr_svc1min,
															decimal? docrevtp_out_tech_nbr_svc1max,
															decimal? docrevtp_out_tech_nbr_svc2min,
															decimal? docrevtp_out_tech_nbr_svc2max,
															decimal? docrevtp_out_prof_amt_billed1min,
															decimal? docrevtp_out_prof_amt_billed1max,
															decimal? docrevtp_out_prof_amt_billed2min,
															decimal? docrevtp_out_prof_amt_billed2max,
															decimal? docrevtp_out_prof_amt_adjusts1min,
															decimal? docrevtp_out_prof_amt_adjusts1max,
															decimal? docrevtp_out_prof_amt_adjusts2min,
															decimal? docrevtp_out_prof_amt_adjusts2max,
															decimal? docrevtp_out_prof_nbr_svc1min,
															decimal? docrevtp_out_prof_nbr_svc1max,
															decimal? docrevtp_out_prof_nbr_svc2min,
															decimal? docrevtp_out_prof_nbr_svc2max,
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
					new SqlParameter("minDOCREVTP_CLINIC_NBR",docrevtp_clinic_nbrmin),
					new SqlParameter("maxDOCREVTP_CLINIC_NBR",docrevtp_clinic_nbrmax),
					new SqlParameter("DOCREVTP_AGENT_CD",docrevtp_agent_cd),
					new SqlParameter("DOCREVTP_LOC_CD",docrevtp_loc_cd),
					new SqlParameter("DOCREVTP_OMA_CODE",docrevtp_oma_code),
					new SqlParameter("DOCREVTP_OMA_SUFFIX",docrevtp_oma_suffix),
					new SqlParameter("DOCREVTP_DOC_NBR",docrevtp_doc_nbr),
					new SqlParameter("minEP_YR",ep_yrmin),
					new SqlParameter("maxEP_YR",ep_yrmax),
					new SqlParameter("minICONST_DATE_PERIOD_END",iconst_date_period_endmin),
					new SqlParameter("maxICONST_DATE_PERIOD_END",iconst_date_period_endmax),
					new SqlParameter("minDOCREVTP_IN_TECH_AMT_BILLED1",docrevtp_in_tech_amt_billed1min),
					new SqlParameter("maxDOCREVTP_IN_TECH_AMT_BILLED1",docrevtp_in_tech_amt_billed1max),
					new SqlParameter("minDOCREVTP_IN_TECH_AMT_BILLED2",docrevtp_in_tech_amt_billed2min),
					new SqlParameter("maxDOCREVTP_IN_TECH_AMT_BILLED2",docrevtp_in_tech_amt_billed2max),
					new SqlParameter("minDOCREVTP_IN_TECH_AMT_ADJUSTS1",docrevtp_in_tech_amt_adjusts1min),
					new SqlParameter("maxDOCREVTP_IN_TECH_AMT_ADJUSTS1",docrevtp_in_tech_amt_adjusts1max),
					new SqlParameter("minDOCREVTP_IN_TECH_AMT_ADJUSTS2",docrevtp_in_tech_amt_adjusts2min),
					new SqlParameter("maxDOCREVTP_IN_TECH_AMT_ADJUSTS2",docrevtp_in_tech_amt_adjusts2max),
					new SqlParameter("minDOCREVTP_IN_TECH_NBR_SVC1",docrevtp_in_tech_nbr_svc1min),
					new SqlParameter("maxDOCREVTP_IN_TECH_NBR_SVC1",docrevtp_in_tech_nbr_svc1max),
					new SqlParameter("minDOCREVTP_IN_TECH_NBR_SVC2",docrevtp_in_tech_nbr_svc2min),
					new SqlParameter("maxDOCREVTP_IN_TECH_NBR_SVC2",docrevtp_in_tech_nbr_svc2max),
					new SqlParameter("minDOCREVTP_IN_PROF_AMT_BILLED1",docrevtp_in_prof_amt_billed1min),
					new SqlParameter("maxDOCREVTP_IN_PROF_AMT_BILLED1",docrevtp_in_prof_amt_billed1max),
					new SqlParameter("minDOCREVTP_IN_PROF_AMT_BILLED2",docrevtp_in_prof_amt_billed2min),
					new SqlParameter("maxDOCREVTP_IN_PROF_AMT_BILLED2",docrevtp_in_prof_amt_billed2max),
					new SqlParameter("minDOCREVTP_IN_PROF_AMT_ADJUSTS1",docrevtp_in_prof_amt_adjusts1min),
					new SqlParameter("maxDOCREVTP_IN_PROF_AMT_ADJUSTS1",docrevtp_in_prof_amt_adjusts1max),
					new SqlParameter("minDOCREVTP_IN_PROF_AMT_ADJUSTS2",docrevtp_in_prof_amt_adjusts2min),
					new SqlParameter("maxDOCREVTP_IN_PROF_AMT_ADJUSTS2",docrevtp_in_prof_amt_adjusts2max),
					new SqlParameter("minDOCREVTP_IN_PROF_NBR_SVC1",docrevtp_in_prof_nbr_svc1min),
					new SqlParameter("maxDOCREVTP_IN_PROF_NBR_SVC1",docrevtp_in_prof_nbr_svc1max),
					new SqlParameter("minDOCREVTP_IN_PROF_NBR_SVC2",docrevtp_in_prof_nbr_svc2min),
					new SqlParameter("maxDOCREVTP_IN_PROF_NBR_SVC2",docrevtp_in_prof_nbr_svc2max),
					new SqlParameter("minDOCREVTP_OUT_TECH_AMT_BILLED1",docrevtp_out_tech_amt_billed1min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_AMT_BILLED1",docrevtp_out_tech_amt_billed1max),
					new SqlParameter("minDOCREVTP_OUT_TECH_AMT_BILLED2",docrevtp_out_tech_amt_billed2min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_AMT_BILLED2",docrevtp_out_tech_amt_billed2max),
					new SqlParameter("minDOCREVTP_OUT_TECH_AMT_ADJUSTS1",docrevtp_out_tech_amt_adjusts1min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_AMT_ADJUSTS1",docrevtp_out_tech_amt_adjusts1max),
					new SqlParameter("minDOCREVTP_OUT_TECH_AMT_ADJUSTS2",docrevtp_out_tech_amt_adjusts2min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_AMT_ADJUSTS2",docrevtp_out_tech_amt_adjusts2max),
					new SqlParameter("minDOCREVTP_OUT_TECH_NBR_SVC1",docrevtp_out_tech_nbr_svc1min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_NBR_SVC1",docrevtp_out_tech_nbr_svc1max),
					new SqlParameter("minDOCREVTP_OUT_TECH_NBR_SVC2",docrevtp_out_tech_nbr_svc2min),
					new SqlParameter("maxDOCREVTP_OUT_TECH_NBR_SVC2",docrevtp_out_tech_nbr_svc2max),
					new SqlParameter("minDOCREVTP_OUT_PROF_AMT_BILLED1",docrevtp_out_prof_amt_billed1min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_AMT_BILLED1",docrevtp_out_prof_amt_billed1max),
					new SqlParameter("minDOCREVTP_OUT_PROF_AMT_BILLED2",docrevtp_out_prof_amt_billed2min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_AMT_BILLED2",docrevtp_out_prof_amt_billed2max),
					new SqlParameter("minDOCREVTP_OUT_PROF_AMT_ADJUSTS1",docrevtp_out_prof_amt_adjusts1min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_AMT_ADJUSTS1",docrevtp_out_prof_amt_adjusts1max),
					new SqlParameter("minDOCREVTP_OUT_PROF_AMT_ADJUSTS2",docrevtp_out_prof_amt_adjusts2min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_AMT_ADJUSTS2",docrevtp_out_prof_amt_adjusts2max),
					new SqlParameter("minDOCREVTP_OUT_PROF_NBR_SVC1",docrevtp_out_prof_nbr_svc1min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_NBR_SVC1",docrevtp_out_prof_nbr_svc1max),
					new SqlParameter("minDOCREVTP_OUT_PROF_NBR_SVC2",docrevtp_out_prof_nbr_svc2min),
					new SqlParameter("maxDOCREVTP_OUT_PROF_NBR_SVC2",docrevtp_out_prof_nbr_svc2max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_Search]", parameters);
            var collection = new ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F050TP_DOC_REVENUE_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCREVTP_CLINIC_NBR = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]),
					DOCREVTP_AGENT_CD = Reader["DOCREVTP_AGENT_CD"].ToString(),
					DOCREVTP_LOC_CD = Reader["DOCREVTP_LOC_CD"].ToString(),
					DOCREVTP_OMA_CODE = Reader["DOCREVTP_OMA_CODE"].ToString(),
					DOCREVTP_OMA_SUFFIX = Reader["DOCREVTP_OMA_SUFFIX"].ToString(),
					DOCREVTP_DOC_NBR = Reader["DOCREVTP_DOC_NBR"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					DOCREVTP_IN_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]),
					DOCREVTP_IN_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]),
					DOCREVTP_IN_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]),
					DOCREVTP_IN_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]),
					DOCREVTP_IN_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]),
					DOCREVTP_IN_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]),
					DOCREVTP_IN_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]),
					DOCREVTP_IN_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]),
					DOCREVTP_IN_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]),
					DOCREVTP_IN_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]),
					DOCREVTP_IN_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]),
					DOCREVTP_IN_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]),
					DOCREVTP_OUT_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]),
					DOCREVTP_OUT_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]),
					DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]),
					DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]),
					DOCREVTP_OUT_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]),
					DOCREVTP_OUT_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]),
					DOCREVTP_OUT_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]),
					DOCREVTP_OUT_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]),
					DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]),
					DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]),
					DOCREVTP_OUT_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]),
					DOCREVTP_OUT_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocrevtp_clinic_nbr = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]),
					_originalDocrevtp_agent_cd = Reader["DOCREVTP_AGENT_CD"].ToString(),
					_originalDocrevtp_loc_cd = Reader["DOCREVTP_LOC_CD"].ToString(),
					_originalDocrevtp_oma_code = Reader["DOCREVTP_OMA_CODE"].ToString(),
					_originalDocrevtp_oma_suffix = Reader["DOCREVTP_OMA_SUFFIX"].ToString(),
					_originalDocrevtp_doc_nbr = Reader["DOCREVTP_DOC_NBR"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalDocrevtp_in_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]),
					_originalDocrevtp_in_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]),
					_originalDocrevtp_in_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]),
					_originalDocrevtp_in_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]),
					_originalDocrevtp_in_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]),
					_originalDocrevtp_in_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]),
					_originalDocrevtp_in_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]),
					_originalDocrevtp_in_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]),
					_originalDocrevtp_in_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]),
					_originalDocrevtp_in_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]),
					_originalDocrevtp_in_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]),
					_originalDocrevtp_in_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]),
					_originalDocrevtp_out_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]),
					_originalDocrevtp_out_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]),
					_originalDocrevtp_out_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]),
					_originalDocrevtp_out_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]),
					_originalDocrevtp_out_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]),
					_originalDocrevtp_out_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]),
					_originalDocrevtp_out_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]),
					_originalDocrevtp_out_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]),
					_originalDocrevtp_out_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]),
					_originalDocrevtp_out_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]),
					_originalDocrevtp_out_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]),
					_originalDocrevtp_out_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public F050TP_DOC_REVENUE_MSTR_HISTORY Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY> Collection(ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY>
                                                               f050tpDocRevenueMstrHistory = null)
        {
            if (IsSameSearch() && f050tpDocRevenueMstrHistory != null)
            {
                return f050tpDocRevenueMstrHistory;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("DOCREVTP_CLINIC_NBR",WhereDocrevtp_clinic_nbr),
					new SqlParameter("DOCREVTP_AGENT_CD",WhereDocrevtp_agent_cd),
					new SqlParameter("DOCREVTP_LOC_CD",WhereDocrevtp_loc_cd),
					new SqlParameter("DOCREVTP_OMA_CODE",WhereDocrevtp_oma_code),
					new SqlParameter("DOCREVTP_OMA_SUFFIX",WhereDocrevtp_oma_suffix),
					new SqlParameter("DOCREVTP_DOC_NBR",WhereDocrevtp_doc_nbr),
					new SqlParameter("EP_YR",WhereEp_yr),
					new SqlParameter("ICONST_DATE_PERIOD_END",WhereIconst_date_period_end),
					new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED1",WhereDocrevtp_in_tech_amt_billed1),
					new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED2",WhereDocrevtp_in_tech_amt_billed2),
					new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS1",WhereDocrevtp_in_tech_amt_adjusts1),
					new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS2",WhereDocrevtp_in_tech_amt_adjusts2),
					new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC1",WhereDocrevtp_in_tech_nbr_svc1),
					new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC2",WhereDocrevtp_in_tech_nbr_svc2),
					new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED1",WhereDocrevtp_in_prof_amt_billed1),
					new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED2",WhereDocrevtp_in_prof_amt_billed2),
					new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS1",WhereDocrevtp_in_prof_amt_adjusts1),
					new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS2",WhereDocrevtp_in_prof_amt_adjusts2),
					new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC1",WhereDocrevtp_in_prof_nbr_svc1),
					new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC2",WhereDocrevtp_in_prof_nbr_svc2),
					new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED1",WhereDocrevtp_out_tech_amt_billed1),
					new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED2",WhereDocrevtp_out_tech_amt_billed2),
					new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS1",WhereDocrevtp_out_tech_amt_adjusts1),
					new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS2",WhereDocrevtp_out_tech_amt_adjusts2),
					new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC1",WhereDocrevtp_out_tech_nbr_svc1),
					new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC2",WhereDocrevtp_out_tech_nbr_svc2),
					new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED1",WhereDocrevtp_out_prof_amt_billed1),
					new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED2",WhereDocrevtp_out_prof_amt_billed2),
					new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS1",WhereDocrevtp_out_prof_amt_adjusts1),
					new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS2",WhereDocrevtp_out_prof_amt_adjusts2),
					new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC1",WhereDocrevtp_out_prof_nbr_svc1),
					new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC2",WhereDocrevtp_out_prof_nbr_svc2),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_Match]", parameters);
            var collection = new ObservableCollection<F050TP_DOC_REVENUE_MSTR_HISTORY>();

            while (Reader.Read())
            {
                collection.Add(new F050TP_DOC_REVENUE_MSTR_HISTORY
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					DOCREVTP_CLINIC_NBR = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]),
					DOCREVTP_AGENT_CD = Reader["DOCREVTP_AGENT_CD"].ToString(),
					DOCREVTP_LOC_CD = Reader["DOCREVTP_LOC_CD"].ToString(),
					DOCREVTP_OMA_CODE = Reader["DOCREVTP_OMA_CODE"].ToString(),
					DOCREVTP_OMA_SUFFIX = Reader["DOCREVTP_OMA_SUFFIX"].ToString(),
					DOCREVTP_DOC_NBR = Reader["DOCREVTP_DOC_NBR"].ToString(),
					EP_YR = ConvertDEC(Reader["EP_YR"]),
					ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					DOCREVTP_IN_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]),
					DOCREVTP_IN_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]),
					DOCREVTP_IN_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]),
					DOCREVTP_IN_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]),
					DOCREVTP_IN_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]),
					DOCREVTP_IN_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]),
					DOCREVTP_IN_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]),
					DOCREVTP_IN_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]),
					DOCREVTP_IN_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]),
					DOCREVTP_IN_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]),
					DOCREVTP_IN_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]),
					DOCREVTP_IN_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]),
					DOCREVTP_OUT_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]),
					DOCREVTP_OUT_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]),
					DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]),
					DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]),
					DOCREVTP_OUT_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]),
					DOCREVTP_OUT_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]),
					DOCREVTP_OUT_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]),
					DOCREVTP_OUT_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]),
					DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]),
					DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]),
					DOCREVTP_OUT_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]),
					DOCREVTP_OUT_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereDocrevtp_clinic_nbr = WhereDocrevtp_clinic_nbr,
					_whereDocrevtp_agent_cd = WhereDocrevtp_agent_cd,
					_whereDocrevtp_loc_cd = WhereDocrevtp_loc_cd,
					_whereDocrevtp_oma_code = WhereDocrevtp_oma_code,
					_whereDocrevtp_oma_suffix = WhereDocrevtp_oma_suffix,
					_whereDocrevtp_doc_nbr = WhereDocrevtp_doc_nbr,
					_whereEp_yr = WhereEp_yr,
					_whereIconst_date_period_end = WhereIconst_date_period_end,
					_whereDocrevtp_in_tech_amt_billed1 = WhereDocrevtp_in_tech_amt_billed1,
					_whereDocrevtp_in_tech_amt_billed2 = WhereDocrevtp_in_tech_amt_billed2,
					_whereDocrevtp_in_tech_amt_adjusts1 = WhereDocrevtp_in_tech_amt_adjusts1,
					_whereDocrevtp_in_tech_amt_adjusts2 = WhereDocrevtp_in_tech_amt_adjusts2,
					_whereDocrevtp_in_tech_nbr_svc1 = WhereDocrevtp_in_tech_nbr_svc1,
					_whereDocrevtp_in_tech_nbr_svc2 = WhereDocrevtp_in_tech_nbr_svc2,
					_whereDocrevtp_in_prof_amt_billed1 = WhereDocrevtp_in_prof_amt_billed1,
					_whereDocrevtp_in_prof_amt_billed2 = WhereDocrevtp_in_prof_amt_billed2,
					_whereDocrevtp_in_prof_amt_adjusts1 = WhereDocrevtp_in_prof_amt_adjusts1,
					_whereDocrevtp_in_prof_amt_adjusts2 = WhereDocrevtp_in_prof_amt_adjusts2,
					_whereDocrevtp_in_prof_nbr_svc1 = WhereDocrevtp_in_prof_nbr_svc1,
					_whereDocrevtp_in_prof_nbr_svc2 = WhereDocrevtp_in_prof_nbr_svc2,
					_whereDocrevtp_out_tech_amt_billed1 = WhereDocrevtp_out_tech_amt_billed1,
					_whereDocrevtp_out_tech_amt_billed2 = WhereDocrevtp_out_tech_amt_billed2,
					_whereDocrevtp_out_tech_amt_adjusts1 = WhereDocrevtp_out_tech_amt_adjusts1,
					_whereDocrevtp_out_tech_amt_adjusts2 = WhereDocrevtp_out_tech_amt_adjusts2,
					_whereDocrevtp_out_tech_nbr_svc1 = WhereDocrevtp_out_tech_nbr_svc1,
					_whereDocrevtp_out_tech_nbr_svc2 = WhereDocrevtp_out_tech_nbr_svc2,
					_whereDocrevtp_out_prof_amt_billed1 = WhereDocrevtp_out_prof_amt_billed1,
					_whereDocrevtp_out_prof_amt_billed2 = WhereDocrevtp_out_prof_amt_billed2,
					_whereDocrevtp_out_prof_amt_adjusts1 = WhereDocrevtp_out_prof_amt_adjusts1,
					_whereDocrevtp_out_prof_amt_adjusts2 = WhereDocrevtp_out_prof_amt_adjusts2,
					_whereDocrevtp_out_prof_nbr_svc1 = WhereDocrevtp_out_prof_nbr_svc1,
					_whereDocrevtp_out_prof_nbr_svc2 = WhereDocrevtp_out_prof_nbr_svc2,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalDocrevtp_clinic_nbr = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]),
					_originalDocrevtp_agent_cd = Reader["DOCREVTP_AGENT_CD"].ToString(),
					_originalDocrevtp_loc_cd = Reader["DOCREVTP_LOC_CD"].ToString(),
					_originalDocrevtp_oma_code = Reader["DOCREVTP_OMA_CODE"].ToString(),
					_originalDocrevtp_oma_suffix = Reader["DOCREVTP_OMA_SUFFIX"].ToString(),
					_originalDocrevtp_doc_nbr = Reader["DOCREVTP_DOC_NBR"].ToString(),
					_originalEp_yr = ConvertDEC(Reader["EP_YR"]),
					_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]),
					_originalDocrevtp_in_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]),
					_originalDocrevtp_in_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]),
					_originalDocrevtp_in_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]),
					_originalDocrevtp_in_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]),
					_originalDocrevtp_in_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]),
					_originalDocrevtp_in_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]),
					_originalDocrevtp_in_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]),
					_originalDocrevtp_in_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]),
					_originalDocrevtp_in_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]),
					_originalDocrevtp_in_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]),
					_originalDocrevtp_in_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]),
					_originalDocrevtp_in_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]),
					_originalDocrevtp_out_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]),
					_originalDocrevtp_out_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]),
					_originalDocrevtp_out_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]),
					_originalDocrevtp_out_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]),
					_originalDocrevtp_out_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]),
					_originalDocrevtp_out_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]),
					_originalDocrevtp_out_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]),
					_originalDocrevtp_out_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]),
					_originalDocrevtp_out_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]),
					_originalDocrevtp_out_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]),
					_originalDocrevtp_out_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]),
					_originalDocrevtp_out_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereDocrevtp_clinic_nbr = WhereDocrevtp_clinic_nbr;
					_whereDocrevtp_agent_cd = WhereDocrevtp_agent_cd;
					_whereDocrevtp_loc_cd = WhereDocrevtp_loc_cd;
					_whereDocrevtp_oma_code = WhereDocrevtp_oma_code;
					_whereDocrevtp_oma_suffix = WhereDocrevtp_oma_suffix;
					_whereDocrevtp_doc_nbr = WhereDocrevtp_doc_nbr;
					_whereEp_yr = WhereEp_yr;
					_whereIconst_date_period_end = WhereIconst_date_period_end;
					_whereDocrevtp_in_tech_amt_billed1 = WhereDocrevtp_in_tech_amt_billed1;
					_whereDocrevtp_in_tech_amt_billed2 = WhereDocrevtp_in_tech_amt_billed2;
					_whereDocrevtp_in_tech_amt_adjusts1 = WhereDocrevtp_in_tech_amt_adjusts1;
					_whereDocrevtp_in_tech_amt_adjusts2 = WhereDocrevtp_in_tech_amt_adjusts2;
					_whereDocrevtp_in_tech_nbr_svc1 = WhereDocrevtp_in_tech_nbr_svc1;
					_whereDocrevtp_in_tech_nbr_svc2 = WhereDocrevtp_in_tech_nbr_svc2;
					_whereDocrevtp_in_prof_amt_billed1 = WhereDocrevtp_in_prof_amt_billed1;
					_whereDocrevtp_in_prof_amt_billed2 = WhereDocrevtp_in_prof_amt_billed2;
					_whereDocrevtp_in_prof_amt_adjusts1 = WhereDocrevtp_in_prof_amt_adjusts1;
					_whereDocrevtp_in_prof_amt_adjusts2 = WhereDocrevtp_in_prof_amt_adjusts2;
					_whereDocrevtp_in_prof_nbr_svc1 = WhereDocrevtp_in_prof_nbr_svc1;
					_whereDocrevtp_in_prof_nbr_svc2 = WhereDocrevtp_in_prof_nbr_svc2;
					_whereDocrevtp_out_tech_amt_billed1 = WhereDocrevtp_out_tech_amt_billed1;
					_whereDocrevtp_out_tech_amt_billed2 = WhereDocrevtp_out_tech_amt_billed2;
					_whereDocrevtp_out_tech_amt_adjusts1 = WhereDocrevtp_out_tech_amt_adjusts1;
					_whereDocrevtp_out_tech_amt_adjusts2 = WhereDocrevtp_out_tech_amt_adjusts2;
					_whereDocrevtp_out_tech_nbr_svc1 = WhereDocrevtp_out_tech_nbr_svc1;
					_whereDocrevtp_out_tech_nbr_svc2 = WhereDocrevtp_out_tech_nbr_svc2;
					_whereDocrevtp_out_prof_amt_billed1 = WhereDocrevtp_out_prof_amt_billed1;
					_whereDocrevtp_out_prof_amt_billed2 = WhereDocrevtp_out_prof_amt_billed2;
					_whereDocrevtp_out_prof_amt_adjusts1 = WhereDocrevtp_out_prof_amt_adjusts1;
					_whereDocrevtp_out_prof_amt_adjusts2 = WhereDocrevtp_out_prof_amt_adjusts2;
					_whereDocrevtp_out_prof_nbr_svc1 = WhereDocrevtp_out_prof_nbr_svc1;
					_whereDocrevtp_out_prof_nbr_svc2 = WhereDocrevtp_out_prof_nbr_svc2;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereDocrevtp_clinic_nbr == null 
				&& WhereDocrevtp_agent_cd == null 
				&& WhereDocrevtp_loc_cd == null 
				&& WhereDocrevtp_oma_code == null 
				&& WhereDocrevtp_oma_suffix == null 
				&& WhereDocrevtp_doc_nbr == null 
				&& WhereEp_yr == null 
				&& WhereIconst_date_period_end == null 
				&& WhereDocrevtp_in_tech_amt_billed1 == null 
				&& WhereDocrevtp_in_tech_amt_billed2 == null 
				&& WhereDocrevtp_in_tech_amt_adjusts1 == null 
				&& WhereDocrevtp_in_tech_amt_adjusts2 == null 
				&& WhereDocrevtp_in_tech_nbr_svc1 == null 
				&& WhereDocrevtp_in_tech_nbr_svc2 == null 
				&& WhereDocrevtp_in_prof_amt_billed1 == null 
				&& WhereDocrevtp_in_prof_amt_billed2 == null 
				&& WhereDocrevtp_in_prof_amt_adjusts1 == null 
				&& WhereDocrevtp_in_prof_amt_adjusts2 == null 
				&& WhereDocrevtp_in_prof_nbr_svc1 == null 
				&& WhereDocrevtp_in_prof_nbr_svc2 == null 
				&& WhereDocrevtp_out_tech_amt_billed1 == null 
				&& WhereDocrevtp_out_tech_amt_billed2 == null 
				&& WhereDocrevtp_out_tech_amt_adjusts1 == null 
				&& WhereDocrevtp_out_tech_amt_adjusts2 == null 
				&& WhereDocrevtp_out_tech_nbr_svc1 == null 
				&& WhereDocrevtp_out_tech_nbr_svc2 == null 
				&& WhereDocrevtp_out_prof_amt_billed1 == null 
				&& WhereDocrevtp_out_prof_amt_billed2 == null 
				&& WhereDocrevtp_out_prof_amt_adjusts1 == null 
				&& WhereDocrevtp_out_prof_amt_adjusts2 == null 
				&& WhereDocrevtp_out_prof_nbr_svc1 == null 
				&& WhereDocrevtp_out_prof_nbr_svc2 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereDocrevtp_clinic_nbr ==  _whereDocrevtp_clinic_nbr
				&& WhereDocrevtp_agent_cd ==  _whereDocrevtp_agent_cd
				&& WhereDocrevtp_loc_cd ==  _whereDocrevtp_loc_cd
				&& WhereDocrevtp_oma_code ==  _whereDocrevtp_oma_code
				&& WhereDocrevtp_oma_suffix ==  _whereDocrevtp_oma_suffix
				&& WhereDocrevtp_doc_nbr ==  _whereDocrevtp_doc_nbr
				&& WhereEp_yr ==  _whereEp_yr
				&& WhereIconst_date_period_end ==  _whereIconst_date_period_end
				&& WhereDocrevtp_in_tech_amt_billed1 ==  _whereDocrevtp_in_tech_amt_billed1
				&& WhereDocrevtp_in_tech_amt_billed2 ==  _whereDocrevtp_in_tech_amt_billed2
				&& WhereDocrevtp_in_tech_amt_adjusts1 ==  _whereDocrevtp_in_tech_amt_adjusts1
				&& WhereDocrevtp_in_tech_amt_adjusts2 ==  _whereDocrevtp_in_tech_amt_adjusts2
				&& WhereDocrevtp_in_tech_nbr_svc1 ==  _whereDocrevtp_in_tech_nbr_svc1
				&& WhereDocrevtp_in_tech_nbr_svc2 ==  _whereDocrevtp_in_tech_nbr_svc2
				&& WhereDocrevtp_in_prof_amt_billed1 ==  _whereDocrevtp_in_prof_amt_billed1
				&& WhereDocrevtp_in_prof_amt_billed2 ==  _whereDocrevtp_in_prof_amt_billed2
				&& WhereDocrevtp_in_prof_amt_adjusts1 ==  _whereDocrevtp_in_prof_amt_adjusts1
				&& WhereDocrevtp_in_prof_amt_adjusts2 ==  _whereDocrevtp_in_prof_amt_adjusts2
				&& WhereDocrevtp_in_prof_nbr_svc1 ==  _whereDocrevtp_in_prof_nbr_svc1
				&& WhereDocrevtp_in_prof_nbr_svc2 ==  _whereDocrevtp_in_prof_nbr_svc2
				&& WhereDocrevtp_out_tech_amt_billed1 ==  _whereDocrevtp_out_tech_amt_billed1
				&& WhereDocrevtp_out_tech_amt_billed2 ==  _whereDocrevtp_out_tech_amt_billed2
				&& WhereDocrevtp_out_tech_amt_adjusts1 ==  _whereDocrevtp_out_tech_amt_adjusts1
				&& WhereDocrevtp_out_tech_amt_adjusts2 ==  _whereDocrevtp_out_tech_amt_adjusts2
				&& WhereDocrevtp_out_tech_nbr_svc1 ==  _whereDocrevtp_out_tech_nbr_svc1
				&& WhereDocrevtp_out_tech_nbr_svc2 ==  _whereDocrevtp_out_tech_nbr_svc2
				&& WhereDocrevtp_out_prof_amt_billed1 ==  _whereDocrevtp_out_prof_amt_billed1
				&& WhereDocrevtp_out_prof_amt_billed2 ==  _whereDocrevtp_out_prof_amt_billed2
				&& WhereDocrevtp_out_prof_amt_adjusts1 ==  _whereDocrevtp_out_prof_amt_adjusts1
				&& WhereDocrevtp_out_prof_amt_adjusts2 ==  _whereDocrevtp_out_prof_amt_adjusts2
				&& WhereDocrevtp_out_prof_nbr_svc1 ==  _whereDocrevtp_out_prof_nbr_svc1
				&& WhereDocrevtp_out_prof_nbr_svc2 ==  _whereDocrevtp_out_prof_nbr_svc2
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereDocrevtp_clinic_nbr = null; 
			WhereDocrevtp_agent_cd = null; 
			WhereDocrevtp_loc_cd = null; 
			WhereDocrevtp_oma_code = null; 
			WhereDocrevtp_oma_suffix = null; 
			WhereDocrevtp_doc_nbr = null; 
			WhereEp_yr = null; 
			WhereIconst_date_period_end = null; 
			WhereDocrevtp_in_tech_amt_billed1 = null; 
			WhereDocrevtp_in_tech_amt_billed2 = null; 
			WhereDocrevtp_in_tech_amt_adjusts1 = null; 
			WhereDocrevtp_in_tech_amt_adjusts2 = null; 
			WhereDocrevtp_in_tech_nbr_svc1 = null; 
			WhereDocrevtp_in_tech_nbr_svc2 = null; 
			WhereDocrevtp_in_prof_amt_billed1 = null; 
			WhereDocrevtp_in_prof_amt_billed2 = null; 
			WhereDocrevtp_in_prof_amt_adjusts1 = null; 
			WhereDocrevtp_in_prof_amt_adjusts2 = null; 
			WhereDocrevtp_in_prof_nbr_svc1 = null; 
			WhereDocrevtp_in_prof_nbr_svc2 = null; 
			WhereDocrevtp_out_tech_amt_billed1 = null; 
			WhereDocrevtp_out_tech_amt_billed2 = null; 
			WhereDocrevtp_out_tech_amt_adjusts1 = null; 
			WhereDocrevtp_out_tech_amt_adjusts2 = null; 
			WhereDocrevtp_out_tech_nbr_svc1 = null; 
			WhereDocrevtp_out_tech_nbr_svc2 = null; 
			WhereDocrevtp_out_prof_amt_billed1 = null; 
			WhereDocrevtp_out_prof_amt_billed2 = null; 
			WhereDocrevtp_out_prof_amt_adjusts1 = null; 
			WhereDocrevtp_out_prof_amt_adjusts2 = null; 
			WhereDocrevtp_out_prof_nbr_svc1 = null; 
			WhereDocrevtp_out_prof_nbr_svc2 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _DOCREVTP_CLINIC_NBR;
		private string _DOCREVTP_AGENT_CD;
		private string _DOCREVTP_LOC_CD;
		private string _DOCREVTP_OMA_CODE;
		private string _DOCREVTP_OMA_SUFFIX;
		private string _DOCREVTP_DOC_NBR;
		private decimal? _EP_YR;
		private decimal? _ICONST_DATE_PERIOD_END;
		private decimal? _DOCREVTP_IN_TECH_AMT_BILLED1;
		private decimal? _DOCREVTP_IN_TECH_AMT_BILLED2;
		private decimal? _DOCREVTP_IN_TECH_AMT_ADJUSTS1;
		private decimal? _DOCREVTP_IN_TECH_AMT_ADJUSTS2;
		private decimal? _DOCREVTP_IN_TECH_NBR_SVC1;
		private decimal? _DOCREVTP_IN_TECH_NBR_SVC2;
		private decimal? _DOCREVTP_IN_PROF_AMT_BILLED1;
		private decimal? _DOCREVTP_IN_PROF_AMT_BILLED2;
		private decimal? _DOCREVTP_IN_PROF_AMT_ADJUSTS1;
		private decimal? _DOCREVTP_IN_PROF_AMT_ADJUSTS2;
		private decimal? _DOCREVTP_IN_PROF_NBR_SVC1;
		private decimal? _DOCREVTP_IN_PROF_NBR_SVC2;
		private decimal? _DOCREVTP_OUT_TECH_AMT_BILLED1;
		private decimal? _DOCREVTP_OUT_TECH_AMT_BILLED2;
		private decimal? _DOCREVTP_OUT_TECH_AMT_ADJUSTS1;
		private decimal? _DOCREVTP_OUT_TECH_AMT_ADJUSTS2;
		private decimal? _DOCREVTP_OUT_TECH_NBR_SVC1;
		private decimal? _DOCREVTP_OUT_TECH_NBR_SVC2;
		private decimal? _DOCREVTP_OUT_PROF_AMT_BILLED1;
		private decimal? _DOCREVTP_OUT_PROF_AMT_BILLED2;
		private decimal? _DOCREVTP_OUT_PROF_AMT_ADJUSTS1;
		private decimal? _DOCREVTP_OUT_PROF_AMT_ADJUSTS2;
		private decimal? _DOCREVTP_OUT_PROF_NBR_SVC1;
		private decimal? _DOCREVTP_OUT_PROF_NBR_SVC2;
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
		public decimal? DOCREVTP_CLINIC_NBR
		{
			get { return _DOCREVTP_CLINIC_NBR; }
			set
			{
				if (_DOCREVTP_CLINIC_NBR != value)
				{
					_DOCREVTP_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string DOCREVTP_AGENT_CD
		{
			get { return _DOCREVTP_AGENT_CD; }
			set
			{
				if (_DOCREVTP_AGENT_CD != value)
				{
					_DOCREVTP_AGENT_CD = value;
					ChangeState();
				}
			}
		}
		public string DOCREVTP_LOC_CD
		{
			get { return _DOCREVTP_LOC_CD; }
			set
			{
				if (_DOCREVTP_LOC_CD != value)
				{
					_DOCREVTP_LOC_CD = value;
					ChangeState();
				}
			}
		}
		public string DOCREVTP_OMA_CODE
		{
			get { return _DOCREVTP_OMA_CODE; }
			set
			{
				if (_DOCREVTP_OMA_CODE != value)
				{
					_DOCREVTP_OMA_CODE = value;
					ChangeState();
				}
			}
		}
		public string DOCREVTP_OMA_SUFFIX
		{
			get { return _DOCREVTP_OMA_SUFFIX; }
			set
			{
				if (_DOCREVTP_OMA_SUFFIX != value)
				{
					_DOCREVTP_OMA_SUFFIX = value;
					ChangeState();
				}
			}
		}
		public string DOCREVTP_DOC_NBR
		{
			get { return _DOCREVTP_DOC_NBR; }
			set
			{
				if (_DOCREVTP_DOC_NBR != value)
				{
					_DOCREVTP_DOC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? EP_YR
		{
			get { return _EP_YR; }
			set
			{
				if (_EP_YR != value)
				{
					_EP_YR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END
		{
			get { return _ICONST_DATE_PERIOD_END; }
			set
			{
				if (_ICONST_DATE_PERIOD_END != value)
				{
					_ICONST_DATE_PERIOD_END = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_AMT_BILLED1
		{
			get { return _DOCREVTP_IN_TECH_AMT_BILLED1; }
			set
			{
				if (_DOCREVTP_IN_TECH_AMT_BILLED1 != value)
				{
					_DOCREVTP_IN_TECH_AMT_BILLED1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_AMT_BILLED2
		{
			get { return _DOCREVTP_IN_TECH_AMT_BILLED2; }
			set
			{
				if (_DOCREVTP_IN_TECH_AMT_BILLED2 != value)
				{
					_DOCREVTP_IN_TECH_AMT_BILLED2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_AMT_ADJUSTS1
		{
			get { return _DOCREVTP_IN_TECH_AMT_ADJUSTS1; }
			set
			{
				if (_DOCREVTP_IN_TECH_AMT_ADJUSTS1 != value)
				{
					_DOCREVTP_IN_TECH_AMT_ADJUSTS1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_AMT_ADJUSTS2
		{
			get { return _DOCREVTP_IN_TECH_AMT_ADJUSTS2; }
			set
			{
				if (_DOCREVTP_IN_TECH_AMT_ADJUSTS2 != value)
				{
					_DOCREVTP_IN_TECH_AMT_ADJUSTS2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_NBR_SVC1
		{
			get { return _DOCREVTP_IN_TECH_NBR_SVC1; }
			set
			{
				if (_DOCREVTP_IN_TECH_NBR_SVC1 != value)
				{
					_DOCREVTP_IN_TECH_NBR_SVC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_TECH_NBR_SVC2
		{
			get { return _DOCREVTP_IN_TECH_NBR_SVC2; }
			set
			{
				if (_DOCREVTP_IN_TECH_NBR_SVC2 != value)
				{
					_DOCREVTP_IN_TECH_NBR_SVC2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_AMT_BILLED1
		{
			get { return _DOCREVTP_IN_PROF_AMT_BILLED1; }
			set
			{
				if (_DOCREVTP_IN_PROF_AMT_BILLED1 != value)
				{
					_DOCREVTP_IN_PROF_AMT_BILLED1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_AMT_BILLED2
		{
			get { return _DOCREVTP_IN_PROF_AMT_BILLED2; }
			set
			{
				if (_DOCREVTP_IN_PROF_AMT_BILLED2 != value)
				{
					_DOCREVTP_IN_PROF_AMT_BILLED2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_AMT_ADJUSTS1
		{
			get { return _DOCREVTP_IN_PROF_AMT_ADJUSTS1; }
			set
			{
				if (_DOCREVTP_IN_PROF_AMT_ADJUSTS1 != value)
				{
					_DOCREVTP_IN_PROF_AMT_ADJUSTS1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_AMT_ADJUSTS2
		{
			get { return _DOCREVTP_IN_PROF_AMT_ADJUSTS2; }
			set
			{
				if (_DOCREVTP_IN_PROF_AMT_ADJUSTS2 != value)
				{
					_DOCREVTP_IN_PROF_AMT_ADJUSTS2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_NBR_SVC1
		{
			get { return _DOCREVTP_IN_PROF_NBR_SVC1; }
			set
			{
				if (_DOCREVTP_IN_PROF_NBR_SVC1 != value)
				{
					_DOCREVTP_IN_PROF_NBR_SVC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_IN_PROF_NBR_SVC2
		{
			get { return _DOCREVTP_IN_PROF_NBR_SVC2; }
			set
			{
				if (_DOCREVTP_IN_PROF_NBR_SVC2 != value)
				{
					_DOCREVTP_IN_PROF_NBR_SVC2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_AMT_BILLED1
		{
			get { return _DOCREVTP_OUT_TECH_AMT_BILLED1; }
			set
			{
				if (_DOCREVTP_OUT_TECH_AMT_BILLED1 != value)
				{
					_DOCREVTP_OUT_TECH_AMT_BILLED1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_AMT_BILLED2
		{
			get { return _DOCREVTP_OUT_TECH_AMT_BILLED2; }
			set
			{
				if (_DOCREVTP_OUT_TECH_AMT_BILLED2 != value)
				{
					_DOCREVTP_OUT_TECH_AMT_BILLED2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_AMT_ADJUSTS1
		{
			get { return _DOCREVTP_OUT_TECH_AMT_ADJUSTS1; }
			set
			{
				if (_DOCREVTP_OUT_TECH_AMT_ADJUSTS1 != value)
				{
					_DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_AMT_ADJUSTS2
		{
			get { return _DOCREVTP_OUT_TECH_AMT_ADJUSTS2; }
			set
			{
				if (_DOCREVTP_OUT_TECH_AMT_ADJUSTS2 != value)
				{
					_DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_NBR_SVC1
		{
			get { return _DOCREVTP_OUT_TECH_NBR_SVC1; }
			set
			{
				if (_DOCREVTP_OUT_TECH_NBR_SVC1 != value)
				{
					_DOCREVTP_OUT_TECH_NBR_SVC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_TECH_NBR_SVC2
		{
			get { return _DOCREVTP_OUT_TECH_NBR_SVC2; }
			set
			{
				if (_DOCREVTP_OUT_TECH_NBR_SVC2 != value)
				{
					_DOCREVTP_OUT_TECH_NBR_SVC2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_AMT_BILLED1
		{
			get { return _DOCREVTP_OUT_PROF_AMT_BILLED1; }
			set
			{
				if (_DOCREVTP_OUT_PROF_AMT_BILLED1 != value)
				{
					_DOCREVTP_OUT_PROF_AMT_BILLED1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_AMT_BILLED2
		{
			get { return _DOCREVTP_OUT_PROF_AMT_BILLED2; }
			set
			{
				if (_DOCREVTP_OUT_PROF_AMT_BILLED2 != value)
				{
					_DOCREVTP_OUT_PROF_AMT_BILLED2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_AMT_ADJUSTS1
		{
			get { return _DOCREVTP_OUT_PROF_AMT_ADJUSTS1; }
			set
			{
				if (_DOCREVTP_OUT_PROF_AMT_ADJUSTS1 != value)
				{
					_DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_AMT_ADJUSTS2
		{
			get { return _DOCREVTP_OUT_PROF_AMT_ADJUSTS2; }
			set
			{
				if (_DOCREVTP_OUT_PROF_AMT_ADJUSTS2 != value)
				{
					_DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_NBR_SVC1
		{
			get { return _DOCREVTP_OUT_PROF_NBR_SVC1; }
			set
			{
				if (_DOCREVTP_OUT_PROF_NBR_SVC1 != value)
				{
					_DOCREVTP_OUT_PROF_NBR_SVC1 = value;
					ChangeState();
				}
			}
		}
		public decimal? DOCREVTP_OUT_PROF_NBR_SVC2
		{
			get { return _DOCREVTP_OUT_PROF_NBR_SVC2; }
			set
			{
				if (_DOCREVTP_OUT_PROF_NBR_SVC2 != value)
				{
					_DOCREVTP_OUT_PROF_NBR_SVC2 = value;
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
		public decimal? WhereDocrevtp_clinic_nbr { get; set; }
		private decimal? _whereDocrevtp_clinic_nbr;
		public string WhereDocrevtp_agent_cd { get; set; }
		private string _whereDocrevtp_agent_cd;
		public string WhereDocrevtp_loc_cd { get; set; }
		private string _whereDocrevtp_loc_cd;
		public string WhereDocrevtp_oma_code { get; set; }
		private string _whereDocrevtp_oma_code;
		public string WhereDocrevtp_oma_suffix { get; set; }
		private string _whereDocrevtp_oma_suffix;
		public string WhereDocrevtp_doc_nbr { get; set; }
		private string _whereDocrevtp_doc_nbr;
		public decimal? WhereEp_yr { get; set; }
		private decimal? _whereEp_yr;
		public decimal? WhereIconst_date_period_end { get; set; }
		private decimal? _whereIconst_date_period_end;
		public decimal? WhereDocrevtp_in_tech_amt_billed1 { get; set; }
		private decimal? _whereDocrevtp_in_tech_amt_billed1;
		public decimal? WhereDocrevtp_in_tech_amt_billed2 { get; set; }
		private decimal? _whereDocrevtp_in_tech_amt_billed2;
		public decimal? WhereDocrevtp_in_tech_amt_adjusts1 { get; set; }
		private decimal? _whereDocrevtp_in_tech_amt_adjusts1;
		public decimal? WhereDocrevtp_in_tech_amt_adjusts2 { get; set; }
		private decimal? _whereDocrevtp_in_tech_amt_adjusts2;
		public decimal? WhereDocrevtp_in_tech_nbr_svc1 { get; set; }
		private decimal? _whereDocrevtp_in_tech_nbr_svc1;
		public decimal? WhereDocrevtp_in_tech_nbr_svc2 { get; set; }
		private decimal? _whereDocrevtp_in_tech_nbr_svc2;
		public decimal? WhereDocrevtp_in_prof_amt_billed1 { get; set; }
		private decimal? _whereDocrevtp_in_prof_amt_billed1;
		public decimal? WhereDocrevtp_in_prof_amt_billed2 { get; set; }
		private decimal? _whereDocrevtp_in_prof_amt_billed2;
		public decimal? WhereDocrevtp_in_prof_amt_adjusts1 { get; set; }
		private decimal? _whereDocrevtp_in_prof_amt_adjusts1;
		public decimal? WhereDocrevtp_in_prof_amt_adjusts2 { get; set; }
		private decimal? _whereDocrevtp_in_prof_amt_adjusts2;
		public decimal? WhereDocrevtp_in_prof_nbr_svc1 { get; set; }
		private decimal? _whereDocrevtp_in_prof_nbr_svc1;
		public decimal? WhereDocrevtp_in_prof_nbr_svc2 { get; set; }
		private decimal? _whereDocrevtp_in_prof_nbr_svc2;
		public decimal? WhereDocrevtp_out_tech_amt_billed1 { get; set; }
		private decimal? _whereDocrevtp_out_tech_amt_billed1;
		public decimal? WhereDocrevtp_out_tech_amt_billed2 { get; set; }
		private decimal? _whereDocrevtp_out_tech_amt_billed2;
		public decimal? WhereDocrevtp_out_tech_amt_adjusts1 { get; set; }
		private decimal? _whereDocrevtp_out_tech_amt_adjusts1;
		public decimal? WhereDocrevtp_out_tech_amt_adjusts2 { get; set; }
		private decimal? _whereDocrevtp_out_tech_amt_adjusts2;
		public decimal? WhereDocrevtp_out_tech_nbr_svc1 { get; set; }
		private decimal? _whereDocrevtp_out_tech_nbr_svc1;
		public decimal? WhereDocrevtp_out_tech_nbr_svc2 { get; set; }
		private decimal? _whereDocrevtp_out_tech_nbr_svc2;
		public decimal? WhereDocrevtp_out_prof_amt_billed1 { get; set; }
		private decimal? _whereDocrevtp_out_prof_amt_billed1;
		public decimal? WhereDocrevtp_out_prof_amt_billed2 { get; set; }
		private decimal? _whereDocrevtp_out_prof_amt_billed2;
		public decimal? WhereDocrevtp_out_prof_amt_adjusts1 { get; set; }
		private decimal? _whereDocrevtp_out_prof_amt_adjusts1;
		public decimal? WhereDocrevtp_out_prof_amt_adjusts2 { get; set; }
		private decimal? _whereDocrevtp_out_prof_amt_adjusts2;
		public decimal? WhereDocrevtp_out_prof_nbr_svc1 { get; set; }
		private decimal? _whereDocrevtp_out_prof_nbr_svc1;
		public decimal? WhereDocrevtp_out_prof_nbr_svc2 { get; set; }
		private decimal? _whereDocrevtp_out_prof_nbr_svc2;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalDocrevtp_clinic_nbr;
		private string _originalDocrevtp_agent_cd;
		private string _originalDocrevtp_loc_cd;
		private string _originalDocrevtp_oma_code;
		private string _originalDocrevtp_oma_suffix;
		private string _originalDocrevtp_doc_nbr;
		private decimal? _originalEp_yr;
		private decimal? _originalIconst_date_period_end;
		private decimal? _originalDocrevtp_in_tech_amt_billed1;
		private decimal? _originalDocrevtp_in_tech_amt_billed2;
		private decimal? _originalDocrevtp_in_tech_amt_adjusts1;
		private decimal? _originalDocrevtp_in_tech_amt_adjusts2;
		private decimal? _originalDocrevtp_in_tech_nbr_svc1;
		private decimal? _originalDocrevtp_in_tech_nbr_svc2;
		private decimal? _originalDocrevtp_in_prof_amt_billed1;
		private decimal? _originalDocrevtp_in_prof_amt_billed2;
		private decimal? _originalDocrevtp_in_prof_amt_adjusts1;
		private decimal? _originalDocrevtp_in_prof_amt_adjusts2;
		private decimal? _originalDocrevtp_in_prof_nbr_svc1;
		private decimal? _originalDocrevtp_in_prof_nbr_svc2;
		private decimal? _originalDocrevtp_out_tech_amt_billed1;
		private decimal? _originalDocrevtp_out_tech_amt_billed2;
		private decimal? _originalDocrevtp_out_tech_amt_adjusts1;
		private decimal? _originalDocrevtp_out_tech_amt_adjusts2;
		private decimal? _originalDocrevtp_out_tech_nbr_svc1;
		private decimal? _originalDocrevtp_out_tech_nbr_svc2;
		private decimal? _originalDocrevtp_out_prof_amt_billed1;
		private decimal? _originalDocrevtp_out_prof_amt_billed2;
		private decimal? _originalDocrevtp_out_prof_amt_adjusts1;
		private decimal? _originalDocrevtp_out_prof_amt_adjusts2;
		private decimal? _originalDocrevtp_out_prof_nbr_svc1;
		private decimal? _originalDocrevtp_out_prof_nbr_svc2;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			DOCREVTP_CLINIC_NBR = _originalDocrevtp_clinic_nbr;
			DOCREVTP_AGENT_CD = _originalDocrevtp_agent_cd;
			DOCREVTP_LOC_CD = _originalDocrevtp_loc_cd;
			DOCREVTP_OMA_CODE = _originalDocrevtp_oma_code;
			DOCREVTP_OMA_SUFFIX = _originalDocrevtp_oma_suffix;
			DOCREVTP_DOC_NBR = _originalDocrevtp_doc_nbr;
			EP_YR = _originalEp_yr;
			ICONST_DATE_PERIOD_END = _originalIconst_date_period_end;
			DOCREVTP_IN_TECH_AMT_BILLED1 = _originalDocrevtp_in_tech_amt_billed1;
			DOCREVTP_IN_TECH_AMT_BILLED2 = _originalDocrevtp_in_tech_amt_billed2;
			DOCREVTP_IN_TECH_AMT_ADJUSTS1 = _originalDocrevtp_in_tech_amt_adjusts1;
			DOCREVTP_IN_TECH_AMT_ADJUSTS2 = _originalDocrevtp_in_tech_amt_adjusts2;
			DOCREVTP_IN_TECH_NBR_SVC1 = _originalDocrevtp_in_tech_nbr_svc1;
			DOCREVTP_IN_TECH_NBR_SVC2 = _originalDocrevtp_in_tech_nbr_svc2;
			DOCREVTP_IN_PROF_AMT_BILLED1 = _originalDocrevtp_in_prof_amt_billed1;
			DOCREVTP_IN_PROF_AMT_BILLED2 = _originalDocrevtp_in_prof_amt_billed2;
			DOCREVTP_IN_PROF_AMT_ADJUSTS1 = _originalDocrevtp_in_prof_amt_adjusts1;
			DOCREVTP_IN_PROF_AMT_ADJUSTS2 = _originalDocrevtp_in_prof_amt_adjusts2;
			DOCREVTP_IN_PROF_NBR_SVC1 = _originalDocrevtp_in_prof_nbr_svc1;
			DOCREVTP_IN_PROF_NBR_SVC2 = _originalDocrevtp_in_prof_nbr_svc2;
			DOCREVTP_OUT_TECH_AMT_BILLED1 = _originalDocrevtp_out_tech_amt_billed1;
			DOCREVTP_OUT_TECH_AMT_BILLED2 = _originalDocrevtp_out_tech_amt_billed2;
			DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = _originalDocrevtp_out_tech_amt_adjusts1;
			DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = _originalDocrevtp_out_tech_amt_adjusts2;
			DOCREVTP_OUT_TECH_NBR_SVC1 = _originalDocrevtp_out_tech_nbr_svc1;
			DOCREVTP_OUT_TECH_NBR_SVC2 = _originalDocrevtp_out_tech_nbr_svc2;
			DOCREVTP_OUT_PROF_AMT_BILLED1 = _originalDocrevtp_out_prof_amt_billed1;
			DOCREVTP_OUT_PROF_AMT_BILLED2 = _originalDocrevtp_out_prof_amt_billed2;
			DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = _originalDocrevtp_out_prof_amt_adjusts1;
			DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = _originalDocrevtp_out_prof_amt_adjusts2;
			DOCREVTP_OUT_PROF_NBR_SVC1 = _originalDocrevtp_out_prof_nbr_svc1;
			DOCREVTP_OUT_PROF_NBR_SVC2 = _originalDocrevtp_out_prof_nbr_svc2;
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
					new SqlParameter("DOCREVTP_CLINIC_NBR",DOCREVTP_CLINIC_NBR),
					new SqlParameter("DOCREVTP_AGENT_CD",DOCREVTP_AGENT_CD),
					new SqlParameter("DOCREVTP_LOC_CD",DOCREVTP_LOC_CD),
					new SqlParameter("DOCREVTP_OMA_CODE",DOCREVTP_OMA_CODE),
					new SqlParameter("DOCREVTP_OMA_SUFFIX",DOCREVTP_OMA_SUFFIX),
					new SqlParameter("DOCREVTP_DOC_NBR",DOCREVTP_DOC_NBR),
					new SqlParameter("EP_YR",EP_YR),
					new SqlParameter("ICONST_DATE_PERIOD_END",ICONST_DATE_PERIOD_END)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_Purge]");
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
						new SqlParameter("DOCREVTP_CLINIC_NBR", SqlNull(DOCREVTP_CLINIC_NBR)),
						new SqlParameter("DOCREVTP_AGENT_CD", SqlNull(DOCREVTP_AGENT_CD)),
						new SqlParameter("DOCREVTP_LOC_CD", SqlNull(DOCREVTP_LOC_CD)),
						new SqlParameter("DOCREVTP_OMA_CODE", SqlNull(DOCREVTP_OMA_CODE)),
						new SqlParameter("DOCREVTP_OMA_SUFFIX", SqlNull(DOCREVTP_OMA_SUFFIX)),
						new SqlParameter("DOCREVTP_DOC_NBR", SqlNull(DOCREVTP_DOC_NBR)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED1", SqlNull(DOCREVTP_IN_TECH_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED2", SqlNull(DOCREVTP_IN_TECH_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS1", SqlNull(DOCREVTP_IN_TECH_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS2", SqlNull(DOCREVTP_IN_TECH_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC1", SqlNull(DOCREVTP_IN_TECH_NBR_SVC1)),
						new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC2", SqlNull(DOCREVTP_IN_TECH_NBR_SVC2)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED1", SqlNull(DOCREVTP_IN_PROF_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED2", SqlNull(DOCREVTP_IN_PROF_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS1", SqlNull(DOCREVTP_IN_PROF_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS2", SqlNull(DOCREVTP_IN_PROF_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC1", SqlNull(DOCREVTP_IN_PROF_NBR_SVC1)),
						new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC2", SqlNull(DOCREVTP_IN_PROF_NBR_SVC2)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED1", SqlNull(DOCREVTP_OUT_TECH_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED2", SqlNull(DOCREVTP_OUT_TECH_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS1", SqlNull(DOCREVTP_OUT_TECH_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS2", SqlNull(DOCREVTP_OUT_TECH_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC1", SqlNull(DOCREVTP_OUT_TECH_NBR_SVC1)),
						new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC2", SqlNull(DOCREVTP_OUT_TECH_NBR_SVC2)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED1", SqlNull(DOCREVTP_OUT_PROF_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED2", SqlNull(DOCREVTP_OUT_PROF_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS1", SqlNull(DOCREVTP_OUT_PROF_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS2", SqlNull(DOCREVTP_OUT_PROF_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC1", SqlNull(DOCREVTP_OUT_PROF_NBR_SVC1)),
						new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC2", SqlNull(DOCREVTP_OUT_PROF_NBR_SVC2)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCREVTP_CLINIC_NBR = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]);
						DOCREVTP_AGENT_CD = Reader["DOCREVTP_AGENT_CD"].ToString();
						DOCREVTP_LOC_CD = Reader["DOCREVTP_LOC_CD"].ToString();
						DOCREVTP_OMA_CODE = Reader["DOCREVTP_OMA_CODE"].ToString();
						DOCREVTP_OMA_SUFFIX = Reader["DOCREVTP_OMA_SUFFIX"].ToString();
						DOCREVTP_DOC_NBR = Reader["DOCREVTP_DOC_NBR"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						DOCREVTP_IN_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]);
						DOCREVTP_IN_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]);
						DOCREVTP_IN_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]);
						DOCREVTP_IN_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]);
						DOCREVTP_IN_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]);
						DOCREVTP_IN_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]);
						DOCREVTP_IN_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]);
						DOCREVTP_IN_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]);
						DOCREVTP_IN_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]);
						DOCREVTP_IN_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]);
						DOCREVTP_IN_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]);
						DOCREVTP_IN_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]);
						DOCREVTP_OUT_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]);
						DOCREVTP_OUT_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]);
						DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]);
						DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]);
						DOCREVTP_OUT_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]);
						DOCREVTP_OUT_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]);
						DOCREVTP_OUT_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]);
						DOCREVTP_OUT_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]);
						DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]);
						DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]);
						DOCREVTP_OUT_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]);
						DOCREVTP_OUT_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocrevtp_clinic_nbr = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]);
						_originalDocrevtp_agent_cd = Reader["DOCREVTP_AGENT_CD"].ToString();
						_originalDocrevtp_loc_cd = Reader["DOCREVTP_LOC_CD"].ToString();
						_originalDocrevtp_oma_code = Reader["DOCREVTP_OMA_CODE"].ToString();
						_originalDocrevtp_oma_suffix = Reader["DOCREVTP_OMA_SUFFIX"].ToString();
						_originalDocrevtp_doc_nbr = Reader["DOCREVTP_DOC_NBR"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalDocrevtp_in_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]);
						_originalDocrevtp_in_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]);
						_originalDocrevtp_in_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]);
						_originalDocrevtp_in_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]);
						_originalDocrevtp_in_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]);
						_originalDocrevtp_in_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]);
						_originalDocrevtp_in_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]);
						_originalDocrevtp_in_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]);
						_originalDocrevtp_in_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]);
						_originalDocrevtp_in_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]);
						_originalDocrevtp_in_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]);
						_originalDocrevtp_in_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]);
						_originalDocrevtp_out_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]);
						_originalDocrevtp_out_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]);
						_originalDocrevtp_out_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]);
						_originalDocrevtp_out_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]);
						_originalDocrevtp_out_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]);
						_originalDocrevtp_out_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]);
						_originalDocrevtp_out_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]);
						_originalDocrevtp_out_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]);
						_originalDocrevtp_out_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]);
						_originalDocrevtp_out_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]);
						_originalDocrevtp_out_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]);
						_originalDocrevtp_out_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("DOCREVTP_CLINIC_NBR", SqlNull(DOCREVTP_CLINIC_NBR)),
						new SqlParameter("DOCREVTP_AGENT_CD", SqlNull(DOCREVTP_AGENT_CD)),
						new SqlParameter("DOCREVTP_LOC_CD", SqlNull(DOCREVTP_LOC_CD)),
						new SqlParameter("DOCREVTP_OMA_CODE", SqlNull(DOCREVTP_OMA_CODE)),
						new SqlParameter("DOCREVTP_OMA_SUFFIX", SqlNull(DOCREVTP_OMA_SUFFIX)),
						new SqlParameter("DOCREVTP_DOC_NBR", SqlNull(DOCREVTP_DOC_NBR)),
						new SqlParameter("EP_YR", SqlNull(EP_YR)),
						new SqlParameter("ICONST_DATE_PERIOD_END", SqlNull(ICONST_DATE_PERIOD_END)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED1", SqlNull(DOCREVTP_IN_TECH_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_BILLED2", SqlNull(DOCREVTP_IN_TECH_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS1", SqlNull(DOCREVTP_IN_TECH_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_IN_TECH_AMT_ADJUSTS2", SqlNull(DOCREVTP_IN_TECH_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC1", SqlNull(DOCREVTP_IN_TECH_NBR_SVC1)),
						new SqlParameter("DOCREVTP_IN_TECH_NBR_SVC2", SqlNull(DOCREVTP_IN_TECH_NBR_SVC2)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED1", SqlNull(DOCREVTP_IN_PROF_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_BILLED2", SqlNull(DOCREVTP_IN_PROF_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS1", SqlNull(DOCREVTP_IN_PROF_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_IN_PROF_AMT_ADJUSTS2", SqlNull(DOCREVTP_IN_PROF_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC1", SqlNull(DOCREVTP_IN_PROF_NBR_SVC1)),
						new SqlParameter("DOCREVTP_IN_PROF_NBR_SVC2", SqlNull(DOCREVTP_IN_PROF_NBR_SVC2)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED1", SqlNull(DOCREVTP_OUT_TECH_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_BILLED2", SqlNull(DOCREVTP_OUT_TECH_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS1", SqlNull(DOCREVTP_OUT_TECH_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_OUT_TECH_AMT_ADJUSTS2", SqlNull(DOCREVTP_OUT_TECH_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC1", SqlNull(DOCREVTP_OUT_TECH_NBR_SVC1)),
						new SqlParameter("DOCREVTP_OUT_TECH_NBR_SVC2", SqlNull(DOCREVTP_OUT_TECH_NBR_SVC2)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED1", SqlNull(DOCREVTP_OUT_PROF_AMT_BILLED1)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_BILLED2", SqlNull(DOCREVTP_OUT_PROF_AMT_BILLED2)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS1", SqlNull(DOCREVTP_OUT_PROF_AMT_ADJUSTS1)),
						new SqlParameter("DOCREVTP_OUT_PROF_AMT_ADJUSTS2", SqlNull(DOCREVTP_OUT_PROF_AMT_ADJUSTS2)),
						new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC1", SqlNull(DOCREVTP_OUT_PROF_NBR_SVC1)),
						new SqlParameter("DOCREVTP_OUT_PROF_NBR_SVC2", SqlNull(DOCREVTP_OUT_PROF_NBR_SVC2)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_F050TP_DOC_REVENUE_MSTR_HISTORY_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						DOCREVTP_CLINIC_NBR = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]);
						DOCREVTP_AGENT_CD = Reader["DOCREVTP_AGENT_CD"].ToString();
						DOCREVTP_LOC_CD = Reader["DOCREVTP_LOC_CD"].ToString();
						DOCREVTP_OMA_CODE = Reader["DOCREVTP_OMA_CODE"].ToString();
						DOCREVTP_OMA_SUFFIX = Reader["DOCREVTP_OMA_SUFFIX"].ToString();
						DOCREVTP_DOC_NBR = Reader["DOCREVTP_DOC_NBR"].ToString();
						EP_YR = ConvertDEC(Reader["EP_YR"]);
						ICONST_DATE_PERIOD_END = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						DOCREVTP_IN_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]);
						DOCREVTP_IN_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]);
						DOCREVTP_IN_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]);
						DOCREVTP_IN_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]);
						DOCREVTP_IN_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]);
						DOCREVTP_IN_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]);
						DOCREVTP_IN_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]);
						DOCREVTP_IN_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]);
						DOCREVTP_IN_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]);
						DOCREVTP_IN_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]);
						DOCREVTP_IN_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]);
						DOCREVTP_IN_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]);
						DOCREVTP_OUT_TECH_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]);
						DOCREVTP_OUT_TECH_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]);
						DOCREVTP_OUT_TECH_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]);
						DOCREVTP_OUT_TECH_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]);
						DOCREVTP_OUT_TECH_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]);
						DOCREVTP_OUT_TECH_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]);
						DOCREVTP_OUT_PROF_AMT_BILLED1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]);
						DOCREVTP_OUT_PROF_AMT_BILLED2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]);
						DOCREVTP_OUT_PROF_AMT_ADJUSTS1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]);
						DOCREVTP_OUT_PROF_AMT_ADJUSTS2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]);
						DOCREVTP_OUT_PROF_NBR_SVC1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]);
						DOCREVTP_OUT_PROF_NBR_SVC2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalDocrevtp_clinic_nbr = ConvertDEC(Reader["DOCREVTP_CLINIC_NBR"]);
						_originalDocrevtp_agent_cd = Reader["DOCREVTP_AGENT_CD"].ToString();
						_originalDocrevtp_loc_cd = Reader["DOCREVTP_LOC_CD"].ToString();
						_originalDocrevtp_oma_code = Reader["DOCREVTP_OMA_CODE"].ToString();
						_originalDocrevtp_oma_suffix = Reader["DOCREVTP_OMA_SUFFIX"].ToString();
						_originalDocrevtp_doc_nbr = Reader["DOCREVTP_DOC_NBR"].ToString();
						_originalEp_yr = ConvertDEC(Reader["EP_YR"]);
						_originalIconst_date_period_end = ConvertDEC(Reader["ICONST_DATE_PERIOD_END"]);
						_originalDocrevtp_in_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED1"]);
						_originalDocrevtp_in_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_BILLED2"]);
						_originalDocrevtp_in_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS1"]);
						_originalDocrevtp_in_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_AMT_ADJUSTS2"]);
						_originalDocrevtp_in_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC1"]);
						_originalDocrevtp_in_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_TECH_NBR_SVC2"]);
						_originalDocrevtp_in_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED1"]);
						_originalDocrevtp_in_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_BILLED2"]);
						_originalDocrevtp_in_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS1"]);
						_originalDocrevtp_in_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_AMT_ADJUSTS2"]);
						_originalDocrevtp_in_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC1"]);
						_originalDocrevtp_in_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_IN_PROF_NBR_SVC2"]);
						_originalDocrevtp_out_tech_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED1"]);
						_originalDocrevtp_out_tech_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_BILLED2"]);
						_originalDocrevtp_out_tech_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS1"]);
						_originalDocrevtp_out_tech_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_AMT_ADJUSTS2"]);
						_originalDocrevtp_out_tech_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC1"]);
						_originalDocrevtp_out_tech_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_TECH_NBR_SVC2"]);
						_originalDocrevtp_out_prof_amt_billed1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED1"]);
						_originalDocrevtp_out_prof_amt_billed2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_BILLED2"]);
						_originalDocrevtp_out_prof_amt_adjusts1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS1"]);
						_originalDocrevtp_out_prof_amt_adjusts2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_AMT_ADJUSTS2"]);
						_originalDocrevtp_out_prof_nbr_svc1 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC1"]);
						_originalDocrevtp_out_prof_nbr_svc2 = ConvertDEC(Reader["DOCREVTP_OUT_PROF_NBR_SVC2"]);
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