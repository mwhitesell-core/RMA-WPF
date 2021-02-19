using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class ICONST_MSTR_REC : BaseTable
    {
        #region Retrieve

        public ObservableCollection<ICONST_MSTR_REC> Collection( Guid? rowid,
															decimal? iconst_clinic_nbr_1_2min,
															decimal? iconst_clinic_nbr_1_2max,
															string iconst_clinic_nbr,
															string iconst_clinic_name,
															decimal? iconst_clinic_cycle_nbrmin,
															decimal? iconst_clinic_cycle_nbrmax,
															decimal? iconst_date_period_end_yymin,
															decimal? iconst_date_period_end_yymax,
															decimal? iconst_date_period_end_mmmin,
															decimal? iconst_date_period_end_mmmax,
															decimal? iconst_date_period_end_ddmin,
															decimal? iconst_date_period_end_ddmax,
															string iconst_clinic_addr_l1,
															string iconst_clinic_addr_l2,
															string iconst_clinic_addr_l3,
															string iconst_clinic_card_colour,
															decimal? iconst_clinic_over_lim1min,
															decimal? iconst_clinic_over_lim1max,
															decimal? iconst_clinic_under_lim2min,
															decimal? iconst_clinic_under_lim2max,
															decimal? iconst_clinic_under_lim3min,
															decimal? iconst_clinic_under_lim3max,
															decimal? iconst_clinic_over_lim4min,
															decimal? iconst_clinic_over_lim4max,
															decimal? iconst_clinic_batch_nbrmin,
															decimal? iconst_clinic_batch_nbrmax,
															decimal? iconst_reduction_factormin,
															decimal? iconst_reduction_factormax,
															decimal? iconst_overpay_factormin,
															decimal? iconst_overpay_factormax,
															decimal? iconstpednumberwithinfiscalyearmin,
															decimal? iconstpednumberwithinfiscalyearmax,
															decimal? iconst_date_period_end_1min,
															decimal? iconst_date_period_end_1max,
															decimal? iconst_date_period_end_2min,
															decimal? iconst_date_period_end_2max,
															decimal? iconst_date_period_end_3min,
															decimal? iconst_date_period_end_3max,
															decimal? iconst_date_period_end_4min,
															decimal? iconst_date_period_end_4max,
															decimal? iconst_date_period_end_5min,
															decimal? iconst_date_period_end_5max,
															decimal? iconst_date_period_end_6min,
															decimal? iconst_date_period_end_6max,
															decimal? iconst_date_period_end_7min,
															decimal? iconst_date_period_end_7max,
															decimal? iconst_date_period_end_8min,
															decimal? iconst_date_period_end_8max,
															decimal? iconst_date_period_end_9min,
															decimal? iconst_date_period_end_9max,
															decimal? iconst_date_period_end_10min,
															decimal? iconst_date_period_end_10max,
															decimal? iconst_date_period_end_11min,
															decimal? iconst_date_period_end_11max,
															decimal? iconst_date_period_end_12min,
															decimal? iconst_date_period_end_12max,
															decimal? iconst_date_period_end_13min,
															decimal? iconst_date_period_end_13max,
															string iconst_clinic_pay_batch_nbr,
															string iconst_monthend,
															string filler,
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
					new SqlParameter("minICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2min),
					new SqlParameter("maxICONST_CLINIC_NBR_1_2",iconst_clinic_nbr_1_2max),
					new SqlParameter("ICONST_CLINIC_NBR",iconst_clinic_nbr),
					new SqlParameter("ICONST_CLINIC_NAME",iconst_clinic_name),
					new SqlParameter("minICONST_CLINIC_CYCLE_NBR",iconst_clinic_cycle_nbrmin),
					new SqlParameter("maxICONST_CLINIC_CYCLE_NBR",iconst_clinic_cycle_nbrmax),
					new SqlParameter("minICONST_DATE_PERIOD_END_YY",iconst_date_period_end_yymin),
					new SqlParameter("maxICONST_DATE_PERIOD_END_YY",iconst_date_period_end_yymax),
					new SqlParameter("minICONST_DATE_PERIOD_END_MM",iconst_date_period_end_mmmin),
					new SqlParameter("maxICONST_DATE_PERIOD_END_MM",iconst_date_period_end_mmmax),
					new SqlParameter("minICONST_DATE_PERIOD_END_DD",iconst_date_period_end_ddmin),
					new SqlParameter("maxICONST_DATE_PERIOD_END_DD",iconst_date_period_end_ddmax),
					new SqlParameter("ICONST_CLINIC_ADDR_L1",iconst_clinic_addr_l1),
					new SqlParameter("ICONST_CLINIC_ADDR_L2",iconst_clinic_addr_l2),
					new SqlParameter("ICONST_CLINIC_ADDR_L3",iconst_clinic_addr_l3),
					new SqlParameter("ICONST_CLINIC_CARD_COLOUR",iconst_clinic_card_colour),
					new SqlParameter("minICONST_CLINIC_OVER_LIM1",iconst_clinic_over_lim1min),
					new SqlParameter("maxICONST_CLINIC_OVER_LIM1",iconst_clinic_over_lim1max),
					new SqlParameter("minICONST_CLINIC_UNDER_LIM2",iconst_clinic_under_lim2min),
					new SqlParameter("maxICONST_CLINIC_UNDER_LIM2",iconst_clinic_under_lim2max),
					new SqlParameter("minICONST_CLINIC_UNDER_LIM3",iconst_clinic_under_lim3min),
					new SqlParameter("maxICONST_CLINIC_UNDER_LIM3",iconst_clinic_under_lim3max),
					new SqlParameter("minICONST_CLINIC_OVER_LIM4",iconst_clinic_over_lim4min),
					new SqlParameter("maxICONST_CLINIC_OVER_LIM4",iconst_clinic_over_lim4max),
					new SqlParameter("minICONST_CLINIC_BATCH_NBR",iconst_clinic_batch_nbrmin),
					new SqlParameter("maxICONST_CLINIC_BATCH_NBR",iconst_clinic_batch_nbrmax),
					new SqlParameter("minICONST_REDUCTION_FACTOR",iconst_reduction_factormin),
					new SqlParameter("maxICONST_REDUCTION_FACTOR",iconst_reduction_factormax),
					new SqlParameter("minICONST_OVERPAY_FACTOR",iconst_overpay_factormin),
					new SqlParameter("maxICONST_OVERPAY_FACTOR",iconst_overpay_factormax),
					new SqlParameter("minICONSTPEDNUMBERWITHINFISCALYEAR",iconstpednumberwithinfiscalyearmin),
					new SqlParameter("maxICONSTPEDNUMBERWITHINFISCALYEAR",iconstpednumberwithinfiscalyearmax),
					new SqlParameter("minICONST_DATE_PERIOD_END_1",iconst_date_period_end_1min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_1",iconst_date_period_end_1max),
					new SqlParameter("minICONST_DATE_PERIOD_END_2",iconst_date_period_end_2min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_2",iconst_date_period_end_2max),
					new SqlParameter("minICONST_DATE_PERIOD_END_3",iconst_date_period_end_3min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_3",iconst_date_period_end_3max),
					new SqlParameter("minICONST_DATE_PERIOD_END_4",iconst_date_period_end_4min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_4",iconst_date_period_end_4max),
					new SqlParameter("minICONST_DATE_PERIOD_END_5",iconst_date_period_end_5min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_5",iconst_date_period_end_5max),
					new SqlParameter("minICONST_DATE_PERIOD_END_6",iconst_date_period_end_6min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_6",iconst_date_period_end_6max),
					new SqlParameter("minICONST_DATE_PERIOD_END_7",iconst_date_period_end_7min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_7",iconst_date_period_end_7max),
					new SqlParameter("minICONST_DATE_PERIOD_END_8",iconst_date_period_end_8min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_8",iconst_date_period_end_8max),
					new SqlParameter("minICONST_DATE_PERIOD_END_9",iconst_date_period_end_9min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_9",iconst_date_period_end_9max),
					new SqlParameter("minICONST_DATE_PERIOD_END_10",iconst_date_period_end_10min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_10",iconst_date_period_end_10max),
					new SqlParameter("minICONST_DATE_PERIOD_END_11",iconst_date_period_end_11min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_11",iconst_date_period_end_11max),
					new SqlParameter("minICONST_DATE_PERIOD_END_12",iconst_date_period_end_12min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_12",iconst_date_period_end_12max),
					new SqlParameter("minICONST_DATE_PERIOD_END_13",iconst_date_period_end_13min),
					new SqlParameter("maxICONST_DATE_PERIOD_END_13",iconst_date_period_end_13max),
					new SqlParameter("ICONST_CLINIC_PAY_BATCH_NBR",iconst_clinic_pay_batch_nbr),
					new SqlParameter("ICONST_MONTHEND",iconst_monthend),
					new SqlParameter("FILLER",filler),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_ICONST_MSTR_REC_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<ICONST_MSTR_REC>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_ICONST_MSTR_REC_Search]", parameters);
            var collection = new ObservableCollection<ICONST_MSTR_REC>();

            while (Reader.Read())
            {
                collection.Add(new ICONST_MSTR_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					ICONST_CLINIC_NBR = Reader["ICONST_CLINIC_NBR"].ToString(),
					ICONST_CLINIC_NAME = Reader["ICONST_CLINIC_NAME"].ToString(),
					ICONST_CLINIC_CYCLE_NBR = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]),
					ICONST_DATE_PERIOD_END_YY = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]),
					ICONST_DATE_PERIOD_END_MM = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]),
					ICONST_DATE_PERIOD_END_DD = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]),
					ICONST_CLINIC_ADDR_L1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString(),
					ICONST_CLINIC_ADDR_L2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString(),
					ICONST_CLINIC_ADDR_L3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString(),
					ICONST_CLINIC_CARD_COLOUR = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString(),
					ICONST_CLINIC_OVER_LIM1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]),
					ICONST_CLINIC_UNDER_LIM2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]),
					ICONST_CLINIC_UNDER_LIM3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]),
					ICONST_CLINIC_OVER_LIM4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]),
					ICONST_CLINIC_BATCH_NBR = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]),
					ICONST_REDUCTION_FACTOR = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]),
					ICONST_OVERPAY_FACTOR = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]),
					ICONSTPEDNUMBERWITHINFISCALYEAR = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]),
					ICONST_DATE_PERIOD_END_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]),
					ICONST_DATE_PERIOD_END_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]),
					ICONST_DATE_PERIOD_END_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]),
					ICONST_DATE_PERIOD_END_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]),
					ICONST_DATE_PERIOD_END_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]),
					ICONST_DATE_PERIOD_END_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]),
					ICONST_DATE_PERIOD_END_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]),
					ICONST_DATE_PERIOD_END_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]),
					ICONST_DATE_PERIOD_END_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]),
					ICONST_DATE_PERIOD_END_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]),
					ICONST_DATE_PERIOD_END_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]),
					ICONST_DATE_PERIOD_END_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]),
					ICONST_DATE_PERIOD_END_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]),
					ICONST_CLINIC_PAY_BATCH_NBR = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString(),
					ICONST_MONTHEND = Reader["ICONST_MONTHEND"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalIconst_clinic_nbr = Reader["ICONST_CLINIC_NBR"].ToString(),
					_originalIconst_clinic_name = Reader["ICONST_CLINIC_NAME"].ToString(),
					_originalIconst_clinic_cycle_nbr = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]),
					_originalIconst_date_period_end_yy = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]),
					_originalIconst_date_period_end_mm = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]),
					_originalIconst_date_period_end_dd = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]),
					_originalIconst_clinic_addr_l1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString(),
					_originalIconst_clinic_addr_l2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString(),
					_originalIconst_clinic_addr_l3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString(),
					_originalIconst_clinic_card_colour = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString(),
					_originalIconst_clinic_over_lim1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]),
					_originalIconst_clinic_under_lim2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]),
					_originalIconst_clinic_under_lim3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]),
					_originalIconst_clinic_over_lim4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]),
					_originalIconst_clinic_batch_nbr = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]),
					_originalIconst_reduction_factor = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]),
					_originalIconst_overpay_factor = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]),
					_originalIconstpednumberwithinfiscalyear = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]),
					_originalIconst_date_period_end_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]),
					_originalIconst_date_period_end_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]),
					_originalIconst_date_period_end_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]),
					_originalIconst_date_period_end_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]),
					_originalIconst_date_period_end_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]),
					_originalIconst_date_period_end_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]),
					_originalIconst_date_period_end_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]),
					_originalIconst_date_period_end_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]),
					_originalIconst_date_period_end_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]),
					_originalIconst_date_period_end_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]),
					_originalIconst_date_period_end_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]),
					_originalIconst_date_period_end_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]),
					_originalIconst_date_period_end_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]),
					_originalIconst_clinic_pay_batch_nbr = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString(),
					_originalIconst_monthend = Reader["ICONST_MONTHEND"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public ICONST_MSTR_REC Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<ICONST_MSTR_REC> Collection(ObservableCollection<ICONST_MSTR_REC>
                                                               iconstMstrRec = null)
        {
            if (IsSameSearch() && iconstMstrRec != null)
            {
                return iconstMstrRec;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<ICONST_MSTR_REC>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("ICONST_CLINIC_NBR_1_2",WhereIconst_clinic_nbr_1_2),
					new SqlParameter("ICONST_CLINIC_NBR",WhereIconst_clinic_nbr),
					new SqlParameter("ICONST_CLINIC_NAME",WhereIconst_clinic_name),
					new SqlParameter("ICONST_CLINIC_CYCLE_NBR",WhereIconst_clinic_cycle_nbr),
					new SqlParameter("ICONST_DATE_PERIOD_END_YY",WhereIconst_date_period_end_yy),
					new SqlParameter("ICONST_DATE_PERIOD_END_MM",WhereIconst_date_period_end_mm),
					new SqlParameter("ICONST_DATE_PERIOD_END_DD",WhereIconst_date_period_end_dd),
					new SqlParameter("ICONST_CLINIC_ADDR_L1",WhereIconst_clinic_addr_l1),
					new SqlParameter("ICONST_CLINIC_ADDR_L2",WhereIconst_clinic_addr_l2),
					new SqlParameter("ICONST_CLINIC_ADDR_L3",WhereIconst_clinic_addr_l3),
					new SqlParameter("ICONST_CLINIC_CARD_COLOUR",WhereIconst_clinic_card_colour),
					new SqlParameter("ICONST_CLINIC_OVER_LIM1",WhereIconst_clinic_over_lim1),
					new SqlParameter("ICONST_CLINIC_UNDER_LIM2",WhereIconst_clinic_under_lim2),
					new SqlParameter("ICONST_CLINIC_UNDER_LIM3",WhereIconst_clinic_under_lim3),
					new SqlParameter("ICONST_CLINIC_OVER_LIM4",WhereIconst_clinic_over_lim4),
					new SqlParameter("ICONST_CLINIC_BATCH_NBR",WhereIconst_clinic_batch_nbr),
					new SqlParameter("ICONST_REDUCTION_FACTOR",WhereIconst_reduction_factor),
					new SqlParameter("ICONST_OVERPAY_FACTOR",WhereIconst_overpay_factor),
					new SqlParameter("ICONSTPEDNUMBERWITHINFISCALYEAR",WhereIconstpednumberwithinfiscalyear),
					new SqlParameter("ICONST_DATE_PERIOD_END_1",WhereIconst_date_period_end_1),
					new SqlParameter("ICONST_DATE_PERIOD_END_2",WhereIconst_date_period_end_2),
					new SqlParameter("ICONST_DATE_PERIOD_END_3",WhereIconst_date_period_end_3),
					new SqlParameter("ICONST_DATE_PERIOD_END_4",WhereIconst_date_period_end_4),
					new SqlParameter("ICONST_DATE_PERIOD_END_5",WhereIconst_date_period_end_5),
					new SqlParameter("ICONST_DATE_PERIOD_END_6",WhereIconst_date_period_end_6),
					new SqlParameter("ICONST_DATE_PERIOD_END_7",WhereIconst_date_period_end_7),
					new SqlParameter("ICONST_DATE_PERIOD_END_8",WhereIconst_date_period_end_8),
					new SqlParameter("ICONST_DATE_PERIOD_END_9",WhereIconst_date_period_end_9),
					new SqlParameter("ICONST_DATE_PERIOD_END_10",WhereIconst_date_period_end_10),
					new SqlParameter("ICONST_DATE_PERIOD_END_11",WhereIconst_date_period_end_11),
					new SqlParameter("ICONST_DATE_PERIOD_END_12",WhereIconst_date_period_end_12),
					new SqlParameter("ICONST_DATE_PERIOD_END_13",WhereIconst_date_period_end_13),
					new SqlParameter("ICONST_CLINIC_PAY_BATCH_NBR",WhereIconst_clinic_pay_batch_nbr),
					new SqlParameter("ICONST_MONTHEND",WhereIconst_monthend),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_ICONST_MSTR_REC_Match]", parameters);
            var collection = new ObservableCollection<ICONST_MSTR_REC>();

            while (Reader.Read())
            {
                collection.Add(new ICONST_MSTR_REC
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					ICONST_CLINIC_NBR = Reader["ICONST_CLINIC_NBR"].ToString(),
					ICONST_CLINIC_NAME = Reader["ICONST_CLINIC_NAME"].ToString(),
					ICONST_CLINIC_CYCLE_NBR = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]),
					ICONST_DATE_PERIOD_END_YY = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]),
					ICONST_DATE_PERIOD_END_MM = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]),
					ICONST_DATE_PERIOD_END_DD = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]),
					ICONST_CLINIC_ADDR_L1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString(),
					ICONST_CLINIC_ADDR_L2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString(),
					ICONST_CLINIC_ADDR_L3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString(),
					ICONST_CLINIC_CARD_COLOUR = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString(),
					ICONST_CLINIC_OVER_LIM1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]),
					ICONST_CLINIC_UNDER_LIM2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]),
					ICONST_CLINIC_UNDER_LIM3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]),
					ICONST_CLINIC_OVER_LIM4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]),
					ICONST_CLINIC_BATCH_NBR = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]),
					ICONST_REDUCTION_FACTOR = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]),
					ICONST_OVERPAY_FACTOR = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]),
					ICONSTPEDNUMBERWITHINFISCALYEAR = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]),
					ICONST_DATE_PERIOD_END_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]),
					ICONST_DATE_PERIOD_END_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]),
					ICONST_DATE_PERIOD_END_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]),
					ICONST_DATE_PERIOD_END_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]),
					ICONST_DATE_PERIOD_END_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]),
					ICONST_DATE_PERIOD_END_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]),
					ICONST_DATE_PERIOD_END_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]),
					ICONST_DATE_PERIOD_END_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]),
					ICONST_DATE_PERIOD_END_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]),
					ICONST_DATE_PERIOD_END_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]),
					ICONST_DATE_PERIOD_END_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]),
					ICONST_DATE_PERIOD_END_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]),
					ICONST_DATE_PERIOD_END_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]),
					ICONST_CLINIC_PAY_BATCH_NBR = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString(),
					ICONST_MONTHEND = Reader["ICONST_MONTHEND"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2,
					_whereIconst_clinic_nbr = WhereIconst_clinic_nbr,
					_whereIconst_clinic_name = WhereIconst_clinic_name,
					_whereIconst_clinic_cycle_nbr = WhereIconst_clinic_cycle_nbr,
					_whereIconst_date_period_end_yy = WhereIconst_date_period_end_yy,
					_whereIconst_date_period_end_mm = WhereIconst_date_period_end_mm,
					_whereIconst_date_period_end_dd = WhereIconst_date_period_end_dd,
					_whereIconst_clinic_addr_l1 = WhereIconst_clinic_addr_l1,
					_whereIconst_clinic_addr_l2 = WhereIconst_clinic_addr_l2,
					_whereIconst_clinic_addr_l3 = WhereIconst_clinic_addr_l3,
					_whereIconst_clinic_card_colour = WhereIconst_clinic_card_colour,
					_whereIconst_clinic_over_lim1 = WhereIconst_clinic_over_lim1,
					_whereIconst_clinic_under_lim2 = WhereIconst_clinic_under_lim2,
					_whereIconst_clinic_under_lim3 = WhereIconst_clinic_under_lim3,
					_whereIconst_clinic_over_lim4 = WhereIconst_clinic_over_lim4,
					_whereIconst_clinic_batch_nbr = WhereIconst_clinic_batch_nbr,
					_whereIconst_reduction_factor = WhereIconst_reduction_factor,
					_whereIconst_overpay_factor = WhereIconst_overpay_factor,
					_whereIconstpednumberwithinfiscalyear = WhereIconstpednumberwithinfiscalyear,
					_whereIconst_date_period_end_1 = WhereIconst_date_period_end_1,
					_whereIconst_date_period_end_2 = WhereIconst_date_period_end_2,
					_whereIconst_date_period_end_3 = WhereIconst_date_period_end_3,
					_whereIconst_date_period_end_4 = WhereIconst_date_period_end_4,
					_whereIconst_date_period_end_5 = WhereIconst_date_period_end_5,
					_whereIconst_date_period_end_6 = WhereIconst_date_period_end_6,
					_whereIconst_date_period_end_7 = WhereIconst_date_period_end_7,
					_whereIconst_date_period_end_8 = WhereIconst_date_period_end_8,
					_whereIconst_date_period_end_9 = WhereIconst_date_period_end_9,
					_whereIconst_date_period_end_10 = WhereIconst_date_period_end_10,
					_whereIconst_date_period_end_11 = WhereIconst_date_period_end_11,
					_whereIconst_date_period_end_12 = WhereIconst_date_period_end_12,
					_whereIconst_date_period_end_13 = WhereIconst_date_period_end_13,
					_whereIconst_clinic_pay_batch_nbr = WhereIconst_clinic_pay_batch_nbr,
					_whereIconst_monthend = WhereIconst_monthend,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]),
					_originalIconst_clinic_nbr = Reader["ICONST_CLINIC_NBR"].ToString(),
					_originalIconst_clinic_name = Reader["ICONST_CLINIC_NAME"].ToString(),
					_originalIconst_clinic_cycle_nbr = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]),
					_originalIconst_date_period_end_yy = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]),
					_originalIconst_date_period_end_mm = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]),
					_originalIconst_date_period_end_dd = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]),
					_originalIconst_clinic_addr_l1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString(),
					_originalIconst_clinic_addr_l2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString(),
					_originalIconst_clinic_addr_l3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString(),
					_originalIconst_clinic_card_colour = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString(),
					_originalIconst_clinic_over_lim1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]),
					_originalIconst_clinic_under_lim2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]),
					_originalIconst_clinic_under_lim3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]),
					_originalIconst_clinic_over_lim4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]),
					_originalIconst_clinic_batch_nbr = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]),
					_originalIconst_reduction_factor = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]),
					_originalIconst_overpay_factor = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]),
					_originalIconstpednumberwithinfiscalyear = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]),
					_originalIconst_date_period_end_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]),
					_originalIconst_date_period_end_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]),
					_originalIconst_date_period_end_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]),
					_originalIconst_date_period_end_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]),
					_originalIconst_date_period_end_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]),
					_originalIconst_date_period_end_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]),
					_originalIconst_date_period_end_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]),
					_originalIconst_date_period_end_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]),
					_originalIconst_date_period_end_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]),
					_originalIconst_date_period_end_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]),
					_originalIconst_date_period_end_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]),
					_originalIconst_date_period_end_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]),
					_originalIconst_date_period_end_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]),
					_originalIconst_clinic_pay_batch_nbr = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString(),
					_originalIconst_monthend = Reader["ICONST_MONTHEND"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereIconst_clinic_nbr_1_2 = WhereIconst_clinic_nbr_1_2;
					_whereIconst_clinic_nbr = WhereIconst_clinic_nbr;
					_whereIconst_clinic_name = WhereIconst_clinic_name;
					_whereIconst_clinic_cycle_nbr = WhereIconst_clinic_cycle_nbr;
					_whereIconst_date_period_end_yy = WhereIconst_date_period_end_yy;
					_whereIconst_date_period_end_mm = WhereIconst_date_period_end_mm;
					_whereIconst_date_period_end_dd = WhereIconst_date_period_end_dd;
					_whereIconst_clinic_addr_l1 = WhereIconst_clinic_addr_l1;
					_whereIconst_clinic_addr_l2 = WhereIconst_clinic_addr_l2;
					_whereIconst_clinic_addr_l3 = WhereIconst_clinic_addr_l3;
					_whereIconst_clinic_card_colour = WhereIconst_clinic_card_colour;
					_whereIconst_clinic_over_lim1 = WhereIconst_clinic_over_lim1;
					_whereIconst_clinic_under_lim2 = WhereIconst_clinic_under_lim2;
					_whereIconst_clinic_under_lim3 = WhereIconst_clinic_under_lim3;
					_whereIconst_clinic_over_lim4 = WhereIconst_clinic_over_lim4;
					_whereIconst_clinic_batch_nbr = WhereIconst_clinic_batch_nbr;
					_whereIconst_reduction_factor = WhereIconst_reduction_factor;
					_whereIconst_overpay_factor = WhereIconst_overpay_factor;
					_whereIconstpednumberwithinfiscalyear = WhereIconstpednumberwithinfiscalyear;
					_whereIconst_date_period_end_1 = WhereIconst_date_period_end_1;
					_whereIconst_date_period_end_2 = WhereIconst_date_period_end_2;
					_whereIconst_date_period_end_3 = WhereIconst_date_period_end_3;
					_whereIconst_date_period_end_4 = WhereIconst_date_period_end_4;
					_whereIconst_date_period_end_5 = WhereIconst_date_period_end_5;
					_whereIconst_date_period_end_6 = WhereIconst_date_period_end_6;
					_whereIconst_date_period_end_7 = WhereIconst_date_period_end_7;
					_whereIconst_date_period_end_8 = WhereIconst_date_period_end_8;
					_whereIconst_date_period_end_9 = WhereIconst_date_period_end_9;
					_whereIconst_date_period_end_10 = WhereIconst_date_period_end_10;
					_whereIconst_date_period_end_11 = WhereIconst_date_period_end_11;
					_whereIconst_date_period_end_12 = WhereIconst_date_period_end_12;
					_whereIconst_date_period_end_13 = WhereIconst_date_period_end_13;
					_whereIconst_clinic_pay_batch_nbr = WhereIconst_clinic_pay_batch_nbr;
					_whereIconst_monthend = WhereIconst_monthend;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereIconst_clinic_nbr_1_2 == null 
				&& WhereIconst_clinic_nbr == null 
				&& WhereIconst_clinic_name == null 
				&& WhereIconst_clinic_cycle_nbr == null 
				&& WhereIconst_date_period_end_yy == null 
				&& WhereIconst_date_period_end_mm == null 
				&& WhereIconst_date_period_end_dd == null 
				&& WhereIconst_clinic_addr_l1 == null 
				&& WhereIconst_clinic_addr_l2 == null 
				&& WhereIconst_clinic_addr_l3 == null 
				&& WhereIconst_clinic_card_colour == null 
				&& WhereIconst_clinic_over_lim1 == null 
				&& WhereIconst_clinic_under_lim2 == null 
				&& WhereIconst_clinic_under_lim3 == null 
				&& WhereIconst_clinic_over_lim4 == null 
				&& WhereIconst_clinic_batch_nbr == null 
				&& WhereIconst_reduction_factor == null 
				&& WhereIconst_overpay_factor == null 
				&& WhereIconstpednumberwithinfiscalyear == null 
				&& WhereIconst_date_period_end_1 == null 
				&& WhereIconst_date_period_end_2 == null 
				&& WhereIconst_date_period_end_3 == null 
				&& WhereIconst_date_period_end_4 == null 
				&& WhereIconst_date_period_end_5 == null 
				&& WhereIconst_date_period_end_6 == null 
				&& WhereIconst_date_period_end_7 == null 
				&& WhereIconst_date_period_end_8 == null 
				&& WhereIconst_date_period_end_9 == null 
				&& WhereIconst_date_period_end_10 == null 
				&& WhereIconst_date_period_end_11 == null 
				&& WhereIconst_date_period_end_12 == null 
				&& WhereIconst_date_period_end_13 == null 
				&& WhereIconst_clinic_pay_batch_nbr == null 
				&& WhereIconst_monthend == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereIconst_clinic_nbr_1_2 ==  _whereIconst_clinic_nbr_1_2
				&& WhereIconst_clinic_nbr ==  _whereIconst_clinic_nbr
				&& WhereIconst_clinic_name ==  _whereIconst_clinic_name
				&& WhereIconst_clinic_cycle_nbr ==  _whereIconst_clinic_cycle_nbr
				&& WhereIconst_date_period_end_yy ==  _whereIconst_date_period_end_yy
				&& WhereIconst_date_period_end_mm ==  _whereIconst_date_period_end_mm
				&& WhereIconst_date_period_end_dd ==  _whereIconst_date_period_end_dd
				&& WhereIconst_clinic_addr_l1 ==  _whereIconst_clinic_addr_l1
				&& WhereIconst_clinic_addr_l2 ==  _whereIconst_clinic_addr_l2
				&& WhereIconst_clinic_addr_l3 ==  _whereIconst_clinic_addr_l3
				&& WhereIconst_clinic_card_colour ==  _whereIconst_clinic_card_colour
				&& WhereIconst_clinic_over_lim1 ==  _whereIconst_clinic_over_lim1
				&& WhereIconst_clinic_under_lim2 ==  _whereIconst_clinic_under_lim2
				&& WhereIconst_clinic_under_lim3 ==  _whereIconst_clinic_under_lim3
				&& WhereIconst_clinic_over_lim4 ==  _whereIconst_clinic_over_lim4
				&& WhereIconst_clinic_batch_nbr ==  _whereIconst_clinic_batch_nbr
				&& WhereIconst_reduction_factor ==  _whereIconst_reduction_factor
				&& WhereIconst_overpay_factor ==  _whereIconst_overpay_factor
				&& WhereIconstpednumberwithinfiscalyear ==  _whereIconstpednumberwithinfiscalyear
				&& WhereIconst_date_period_end_1 ==  _whereIconst_date_period_end_1
				&& WhereIconst_date_period_end_2 ==  _whereIconst_date_period_end_2
				&& WhereIconst_date_period_end_3 ==  _whereIconst_date_period_end_3
				&& WhereIconst_date_period_end_4 ==  _whereIconst_date_period_end_4
				&& WhereIconst_date_period_end_5 ==  _whereIconst_date_period_end_5
				&& WhereIconst_date_period_end_6 ==  _whereIconst_date_period_end_6
				&& WhereIconst_date_period_end_7 ==  _whereIconst_date_period_end_7
				&& WhereIconst_date_period_end_8 ==  _whereIconst_date_period_end_8
				&& WhereIconst_date_period_end_9 ==  _whereIconst_date_period_end_9
				&& WhereIconst_date_period_end_10 ==  _whereIconst_date_period_end_10
				&& WhereIconst_date_period_end_11 ==  _whereIconst_date_period_end_11
				&& WhereIconst_date_period_end_12 ==  _whereIconst_date_period_end_12
				&& WhereIconst_date_period_end_13 ==  _whereIconst_date_period_end_13
				&& WhereIconst_clinic_pay_batch_nbr ==  _whereIconst_clinic_pay_batch_nbr
				&& WhereIconst_monthend ==  _whereIconst_monthend
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereIconst_clinic_nbr_1_2 = null; 
			WhereIconst_clinic_nbr = null; 
			WhereIconst_clinic_name = null; 
			WhereIconst_clinic_cycle_nbr = null; 
			WhereIconst_date_period_end_yy = null; 
			WhereIconst_date_period_end_mm = null; 
			WhereIconst_date_period_end_dd = null; 
			WhereIconst_clinic_addr_l1 = null; 
			WhereIconst_clinic_addr_l2 = null; 
			WhereIconst_clinic_addr_l3 = null; 
			WhereIconst_clinic_card_colour = null; 
			WhereIconst_clinic_over_lim1 = null; 
			WhereIconst_clinic_under_lim2 = null; 
			WhereIconst_clinic_under_lim3 = null; 
			WhereIconst_clinic_over_lim4 = null; 
			WhereIconst_clinic_batch_nbr = null; 
			WhereIconst_reduction_factor = null; 
			WhereIconst_overpay_factor = null; 
			WhereIconstpednumberwithinfiscalyear = null; 
			WhereIconst_date_period_end_1 = null; 
			WhereIconst_date_period_end_2 = null; 
			WhereIconst_date_period_end_3 = null; 
			WhereIconst_date_period_end_4 = null; 
			WhereIconst_date_period_end_5 = null; 
			WhereIconst_date_period_end_6 = null; 
			WhereIconst_date_period_end_7 = null; 
			WhereIconst_date_period_end_8 = null; 
			WhereIconst_date_period_end_9 = null; 
			WhereIconst_date_period_end_10 = null; 
			WhereIconst_date_period_end_11 = null; 
			WhereIconst_date_period_end_12 = null; 
			WhereIconst_date_period_end_13 = null; 
			WhereIconst_clinic_pay_batch_nbr = null; 
			WhereIconst_monthend = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _ICONST_CLINIC_NBR_1_2;
		private string _ICONST_CLINIC_NBR;
		private string _ICONST_CLINIC_NAME;
		private decimal? _ICONST_CLINIC_CYCLE_NBR;
		private decimal? _ICONST_DATE_PERIOD_END_YY;
		private decimal? _ICONST_DATE_PERIOD_END_MM;
		private decimal? _ICONST_DATE_PERIOD_END_DD;
		private string _ICONST_CLINIC_ADDR_L1;
		private string _ICONST_CLINIC_ADDR_L2;
		private string _ICONST_CLINIC_ADDR_L3;
		private string _ICONST_CLINIC_CARD_COLOUR;
		private decimal? _ICONST_CLINIC_OVER_LIM1;
		private decimal? _ICONST_CLINIC_UNDER_LIM2;
		private decimal? _ICONST_CLINIC_UNDER_LIM3;
		private decimal? _ICONST_CLINIC_OVER_LIM4;
		private decimal? _ICONST_CLINIC_BATCH_NBR;
		private decimal? _ICONST_REDUCTION_FACTOR;
		private decimal? _ICONST_OVERPAY_FACTOR;
		private decimal? _ICONSTPEDNUMBERWITHINFISCALYEAR;
		private decimal? _ICONST_DATE_PERIOD_END_1;
		private decimal? _ICONST_DATE_PERIOD_END_2;
		private decimal? _ICONST_DATE_PERIOD_END_3;
		private decimal? _ICONST_DATE_PERIOD_END_4;
		private decimal? _ICONST_DATE_PERIOD_END_5;
		private decimal? _ICONST_DATE_PERIOD_END_6;
		private decimal? _ICONST_DATE_PERIOD_END_7;
		private decimal? _ICONST_DATE_PERIOD_END_8;
		private decimal? _ICONST_DATE_PERIOD_END_9;
		private decimal? _ICONST_DATE_PERIOD_END_10;
		private decimal? _ICONST_DATE_PERIOD_END_11;
		private decimal? _ICONST_DATE_PERIOD_END_12;
		private decimal? _ICONST_DATE_PERIOD_END_13;
		private string _ICONST_CLINIC_PAY_BATCH_NBR;
		private string _ICONST_MONTHEND;
		private string _FILLER;
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
		public decimal? ICONST_CLINIC_NBR_1_2
		{
			get { return _ICONST_CLINIC_NBR_1_2; }
			set
			{
				if (_ICONST_CLINIC_NBR_1_2 != value)
				{
					_ICONST_CLINIC_NBR_1_2 = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_NBR
		{
			get { return _ICONST_CLINIC_NBR; }
			set
			{
				if (_ICONST_CLINIC_NBR != value)
				{
					_ICONST_CLINIC_NBR = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_NAME
		{
			get { return _ICONST_CLINIC_NAME; }
			set
			{
				if (_ICONST_CLINIC_NAME != value)
				{
					_ICONST_CLINIC_NAME = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_CYCLE_NBR
		{
			get { return _ICONST_CLINIC_CYCLE_NBR; }
			set
			{
				if (_ICONST_CLINIC_CYCLE_NBR != value)
				{
					_ICONST_CLINIC_CYCLE_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_YY
		{
			get { return _ICONST_DATE_PERIOD_END_YY; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_YY != value)
				{
					_ICONST_DATE_PERIOD_END_YY = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_MM
		{
			get { return _ICONST_DATE_PERIOD_END_MM; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_MM != value)
				{
					_ICONST_DATE_PERIOD_END_MM = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_DD
		{
			get { return _ICONST_DATE_PERIOD_END_DD; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_DD != value)
				{
					_ICONST_DATE_PERIOD_END_DD = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_ADDR_L1
		{
			get { return _ICONST_CLINIC_ADDR_L1; }
			set
			{
				if (_ICONST_CLINIC_ADDR_L1 != value)
				{
					_ICONST_CLINIC_ADDR_L1 = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_ADDR_L2
		{
			get { return _ICONST_CLINIC_ADDR_L2; }
			set
			{
				if (_ICONST_CLINIC_ADDR_L2 != value)
				{
					_ICONST_CLINIC_ADDR_L2 = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_ADDR_L3
		{
			get { return _ICONST_CLINIC_ADDR_L3; }
			set
			{
				if (_ICONST_CLINIC_ADDR_L3 != value)
				{
					_ICONST_CLINIC_ADDR_L3 = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_CARD_COLOUR
		{
			get { return _ICONST_CLINIC_CARD_COLOUR; }
			set
			{
				if (_ICONST_CLINIC_CARD_COLOUR != value)
				{
					_ICONST_CLINIC_CARD_COLOUR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_OVER_LIM1
		{
			get { return _ICONST_CLINIC_OVER_LIM1; }
			set
			{
				if (_ICONST_CLINIC_OVER_LIM1 != value)
				{
					_ICONST_CLINIC_OVER_LIM1 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_UNDER_LIM2
		{
			get { return _ICONST_CLINIC_UNDER_LIM2; }
			set
			{
				if (_ICONST_CLINIC_UNDER_LIM2 != value)
				{
					_ICONST_CLINIC_UNDER_LIM2 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_UNDER_LIM3
		{
			get { return _ICONST_CLINIC_UNDER_LIM3; }
			set
			{
				if (_ICONST_CLINIC_UNDER_LIM3 != value)
				{
					_ICONST_CLINIC_UNDER_LIM3 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_OVER_LIM4
		{
			get { return _ICONST_CLINIC_OVER_LIM4; }
			set
			{
				if (_ICONST_CLINIC_OVER_LIM4 != value)
				{
					_ICONST_CLINIC_OVER_LIM4 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_CLINIC_BATCH_NBR
		{
			get { return _ICONST_CLINIC_BATCH_NBR; }
			set
			{
				if (_ICONST_CLINIC_BATCH_NBR != value)
				{
					_ICONST_CLINIC_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_REDUCTION_FACTOR
		{
			get { return _ICONST_REDUCTION_FACTOR; }
			set
			{
				if (_ICONST_REDUCTION_FACTOR != value)
				{
					_ICONST_REDUCTION_FACTOR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_OVERPAY_FACTOR
		{
			get { return _ICONST_OVERPAY_FACTOR; }
			set
			{
				if (_ICONST_OVERPAY_FACTOR != value)
				{
					_ICONST_OVERPAY_FACTOR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONSTPEDNUMBERWITHINFISCALYEAR
		{
			get { return _ICONSTPEDNUMBERWITHINFISCALYEAR; }
			set
			{
				if (_ICONSTPEDNUMBERWITHINFISCALYEAR != value)
				{
					_ICONSTPEDNUMBERWITHINFISCALYEAR = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_1
		{
			get { return _ICONST_DATE_PERIOD_END_1; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_1 != value)
				{
					_ICONST_DATE_PERIOD_END_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_2
		{
			get { return _ICONST_DATE_PERIOD_END_2; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_2 != value)
				{
					_ICONST_DATE_PERIOD_END_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_3
		{
			get { return _ICONST_DATE_PERIOD_END_3; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_3 != value)
				{
					_ICONST_DATE_PERIOD_END_3 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_4
		{
			get { return _ICONST_DATE_PERIOD_END_4; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_4 != value)
				{
					_ICONST_DATE_PERIOD_END_4 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_5
		{
			get { return _ICONST_DATE_PERIOD_END_5; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_5 != value)
				{
					_ICONST_DATE_PERIOD_END_5 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_6
		{
			get { return _ICONST_DATE_PERIOD_END_6; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_6 != value)
				{
					_ICONST_DATE_PERIOD_END_6 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_7
		{
			get { return _ICONST_DATE_PERIOD_END_7; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_7 != value)
				{
					_ICONST_DATE_PERIOD_END_7 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_8
		{
			get { return _ICONST_DATE_PERIOD_END_8; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_8 != value)
				{
					_ICONST_DATE_PERIOD_END_8 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_9
		{
			get { return _ICONST_DATE_PERIOD_END_9; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_9 != value)
				{
					_ICONST_DATE_PERIOD_END_9 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_10
		{
			get { return _ICONST_DATE_PERIOD_END_10; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_10 != value)
				{
					_ICONST_DATE_PERIOD_END_10 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_11
		{
			get { return _ICONST_DATE_PERIOD_END_11; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_11 != value)
				{
					_ICONST_DATE_PERIOD_END_11 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_12
		{
			get { return _ICONST_DATE_PERIOD_END_12; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_12 != value)
				{
					_ICONST_DATE_PERIOD_END_12 = value;
					ChangeState();
				}
			}
		}
		public decimal? ICONST_DATE_PERIOD_END_13
		{
			get { return _ICONST_DATE_PERIOD_END_13; }
			set
			{
				if (_ICONST_DATE_PERIOD_END_13 != value)
				{
					_ICONST_DATE_PERIOD_END_13 = value;
					ChangeState();
				}
			}
		}
		public string ICONST_CLINIC_PAY_BATCH_NBR
		{
			get { return _ICONST_CLINIC_PAY_BATCH_NBR; }
			set
			{
				if (_ICONST_CLINIC_PAY_BATCH_NBR != value)
				{
					_ICONST_CLINIC_PAY_BATCH_NBR = value;
					ChangeState();
				}
			}
		}
		public string ICONST_MONTHEND
		{
			get { return _ICONST_MONTHEND; }
			set
			{
				if (_ICONST_MONTHEND != value)
				{
					_ICONST_MONTHEND = value;
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
		public decimal? WhereIconst_clinic_nbr_1_2 { get; set; }
		private decimal? _whereIconst_clinic_nbr_1_2;
		public string WhereIconst_clinic_nbr { get; set; }
		private string _whereIconst_clinic_nbr;
		public string WhereIconst_clinic_name { get; set; }
		private string _whereIconst_clinic_name;
		public decimal? WhereIconst_clinic_cycle_nbr { get; set; }
		private decimal? _whereIconst_clinic_cycle_nbr;
		public decimal? WhereIconst_date_period_end_yy { get; set; }
		private decimal? _whereIconst_date_period_end_yy;
		public decimal? WhereIconst_date_period_end_mm { get; set; }
		private decimal? _whereIconst_date_period_end_mm;
		public decimal? WhereIconst_date_period_end_dd { get; set; }
		private decimal? _whereIconst_date_period_end_dd;
		public string WhereIconst_clinic_addr_l1 { get; set; }
		private string _whereIconst_clinic_addr_l1;
		public string WhereIconst_clinic_addr_l2 { get; set; }
		private string _whereIconst_clinic_addr_l2;
		public string WhereIconst_clinic_addr_l3 { get; set; }
		private string _whereIconst_clinic_addr_l3;
		public string WhereIconst_clinic_card_colour { get; set; }
		private string _whereIconst_clinic_card_colour;
		public decimal? WhereIconst_clinic_over_lim1 { get; set; }
		private decimal? _whereIconst_clinic_over_lim1;
		public decimal? WhereIconst_clinic_under_lim2 { get; set; }
		private decimal? _whereIconst_clinic_under_lim2;
		public decimal? WhereIconst_clinic_under_lim3 { get; set; }
		private decimal? _whereIconst_clinic_under_lim3;
		public decimal? WhereIconst_clinic_over_lim4 { get; set; }
		private decimal? _whereIconst_clinic_over_lim4;
		public decimal? WhereIconst_clinic_batch_nbr { get; set; }
		private decimal? _whereIconst_clinic_batch_nbr;
		public decimal? WhereIconst_reduction_factor { get; set; }
		private decimal? _whereIconst_reduction_factor;
		public decimal? WhereIconst_overpay_factor { get; set; }
		private decimal? _whereIconst_overpay_factor;
		public decimal? WhereIconstpednumberwithinfiscalyear { get; set; }
		private decimal? _whereIconstpednumberwithinfiscalyear;
		public decimal? WhereIconst_date_period_end_1 { get; set; }
		private decimal? _whereIconst_date_period_end_1;
		public decimal? WhereIconst_date_period_end_2 { get; set; }
		private decimal? _whereIconst_date_period_end_2;
		public decimal? WhereIconst_date_period_end_3 { get; set; }
		private decimal? _whereIconst_date_period_end_3;
		public decimal? WhereIconst_date_period_end_4 { get; set; }
		private decimal? _whereIconst_date_period_end_4;
		public decimal? WhereIconst_date_period_end_5 { get; set; }
		private decimal? _whereIconst_date_period_end_5;
		public decimal? WhereIconst_date_period_end_6 { get; set; }
		private decimal? _whereIconst_date_period_end_6;
		public decimal? WhereIconst_date_period_end_7 { get; set; }
		private decimal? _whereIconst_date_period_end_7;
		public decimal? WhereIconst_date_period_end_8 { get; set; }
		private decimal? _whereIconst_date_period_end_8;
		public decimal? WhereIconst_date_period_end_9 { get; set; }
		private decimal? _whereIconst_date_period_end_9;
		public decimal? WhereIconst_date_period_end_10 { get; set; }
		private decimal? _whereIconst_date_period_end_10;
		public decimal? WhereIconst_date_period_end_11 { get; set; }
		private decimal? _whereIconst_date_period_end_11;
		public decimal? WhereIconst_date_period_end_12 { get; set; }
		private decimal? _whereIconst_date_period_end_12;
		public decimal? WhereIconst_date_period_end_13 { get; set; }
		private decimal? _whereIconst_date_period_end_13;
		public string WhereIconst_clinic_pay_batch_nbr { get; set; }
		private string _whereIconst_clinic_pay_batch_nbr;
		public string WhereIconst_monthend { get; set; }
		private string _whereIconst_monthend;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalIconst_clinic_nbr_1_2;
		private string _originalIconst_clinic_nbr;
		private string _originalIconst_clinic_name;
		private decimal? _originalIconst_clinic_cycle_nbr;
		private decimal? _originalIconst_date_period_end_yy;
		private decimal? _originalIconst_date_period_end_mm;
		private decimal? _originalIconst_date_period_end_dd;
		private string _originalIconst_clinic_addr_l1;
		private string _originalIconst_clinic_addr_l2;
		private string _originalIconst_clinic_addr_l3;
		private string _originalIconst_clinic_card_colour;
		private decimal? _originalIconst_clinic_over_lim1;
		private decimal? _originalIconst_clinic_under_lim2;
		private decimal? _originalIconst_clinic_under_lim3;
		private decimal? _originalIconst_clinic_over_lim4;
		private decimal? _originalIconst_clinic_batch_nbr;
		private decimal? _originalIconst_reduction_factor;
		private decimal? _originalIconst_overpay_factor;
		private decimal? _originalIconstpednumberwithinfiscalyear;
		private decimal? _originalIconst_date_period_end_1;
		private decimal? _originalIconst_date_period_end_2;
		private decimal? _originalIconst_date_period_end_3;
		private decimal? _originalIconst_date_period_end_4;
		private decimal? _originalIconst_date_period_end_5;
		private decimal? _originalIconst_date_period_end_6;
		private decimal? _originalIconst_date_period_end_7;
		private decimal? _originalIconst_date_period_end_8;
		private decimal? _originalIconst_date_period_end_9;
		private decimal? _originalIconst_date_period_end_10;
		private decimal? _originalIconst_date_period_end_11;
		private decimal? _originalIconst_date_period_end_12;
		private decimal? _originalIconst_date_period_end_13;
		private string _originalIconst_clinic_pay_batch_nbr;
		private string _originalIconst_monthend;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			ICONST_CLINIC_NBR_1_2 = _originalIconst_clinic_nbr_1_2;
			ICONST_CLINIC_NBR = _originalIconst_clinic_nbr;
			ICONST_CLINIC_NAME = _originalIconst_clinic_name;
			ICONST_CLINIC_CYCLE_NBR = _originalIconst_clinic_cycle_nbr;
			ICONST_DATE_PERIOD_END_YY = _originalIconst_date_period_end_yy;
			ICONST_DATE_PERIOD_END_MM = _originalIconst_date_period_end_mm;
			ICONST_DATE_PERIOD_END_DD = _originalIconst_date_period_end_dd;
			ICONST_CLINIC_ADDR_L1 = _originalIconst_clinic_addr_l1;
			ICONST_CLINIC_ADDR_L2 = _originalIconst_clinic_addr_l2;
			ICONST_CLINIC_ADDR_L3 = _originalIconst_clinic_addr_l3;
			ICONST_CLINIC_CARD_COLOUR = _originalIconst_clinic_card_colour;
			ICONST_CLINIC_OVER_LIM1 = _originalIconst_clinic_over_lim1;
			ICONST_CLINIC_UNDER_LIM2 = _originalIconst_clinic_under_lim2;
			ICONST_CLINIC_UNDER_LIM3 = _originalIconst_clinic_under_lim3;
			ICONST_CLINIC_OVER_LIM4 = _originalIconst_clinic_over_lim4;
			ICONST_CLINIC_BATCH_NBR = _originalIconst_clinic_batch_nbr;
			ICONST_REDUCTION_FACTOR = _originalIconst_reduction_factor;
			ICONST_OVERPAY_FACTOR = _originalIconst_overpay_factor;
			ICONSTPEDNUMBERWITHINFISCALYEAR = _originalIconstpednumberwithinfiscalyear;
			ICONST_DATE_PERIOD_END_1 = _originalIconst_date_period_end_1;
			ICONST_DATE_PERIOD_END_2 = _originalIconst_date_period_end_2;
			ICONST_DATE_PERIOD_END_3 = _originalIconst_date_period_end_3;
			ICONST_DATE_PERIOD_END_4 = _originalIconst_date_period_end_4;
			ICONST_DATE_PERIOD_END_5 = _originalIconst_date_period_end_5;
			ICONST_DATE_PERIOD_END_6 = _originalIconst_date_period_end_6;
			ICONST_DATE_PERIOD_END_7 = _originalIconst_date_period_end_7;
			ICONST_DATE_PERIOD_END_8 = _originalIconst_date_period_end_8;
			ICONST_DATE_PERIOD_END_9 = _originalIconst_date_period_end_9;
			ICONST_DATE_PERIOD_END_10 = _originalIconst_date_period_end_10;
			ICONST_DATE_PERIOD_END_11 = _originalIconst_date_period_end_11;
			ICONST_DATE_PERIOD_END_12 = _originalIconst_date_period_end_12;
			ICONST_DATE_PERIOD_END_13 = _originalIconst_date_period_end_13;
			ICONST_CLINIC_PAY_BATCH_NBR = _originalIconst_clinic_pay_batch_nbr;
			ICONST_MONTHEND = _originalIconst_monthend;
			FILLER = _originalFiller;
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
					new SqlParameter("ICONST_CLINIC_NBR_1_2",ICONST_CLINIC_NBR_1_2)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_ICONST_MSTR_REC_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_ICONST_MSTR_REC_Purge]");
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
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("ICONST_CLINIC_NBR", SqlNull(ICONST_CLINIC_NBR)),
						new SqlParameter("ICONST_CLINIC_NAME", SqlNull(ICONST_CLINIC_NAME)),
						new SqlParameter("ICONST_CLINIC_CYCLE_NBR", SqlNull(ICONST_CLINIC_CYCLE_NBR)),
						new SqlParameter("ICONST_DATE_PERIOD_END_YY", SqlNull(ICONST_DATE_PERIOD_END_YY)),
						new SqlParameter("ICONST_DATE_PERIOD_END_MM", SqlNull(ICONST_DATE_PERIOD_END_MM)),
						new SqlParameter("ICONST_DATE_PERIOD_END_DD", SqlNull(ICONST_DATE_PERIOD_END_DD)),
						new SqlParameter("ICONST_CLINIC_ADDR_L1", SqlNull(ICONST_CLINIC_ADDR_L1)),
						new SqlParameter("ICONST_CLINIC_ADDR_L2", SqlNull(ICONST_CLINIC_ADDR_L2)),
						new SqlParameter("ICONST_CLINIC_ADDR_L3", SqlNull(ICONST_CLINIC_ADDR_L3)),
						new SqlParameter("ICONST_CLINIC_CARD_COLOUR", SqlNull(ICONST_CLINIC_CARD_COLOUR)),
						new SqlParameter("ICONST_CLINIC_OVER_LIM1", SqlNull(ICONST_CLINIC_OVER_LIM1)),
						new SqlParameter("ICONST_CLINIC_UNDER_LIM2", SqlNull(ICONST_CLINIC_UNDER_LIM2)),
						new SqlParameter("ICONST_CLINIC_UNDER_LIM3", SqlNull(ICONST_CLINIC_UNDER_LIM3)),
						new SqlParameter("ICONST_CLINIC_OVER_LIM4", SqlNull(ICONST_CLINIC_OVER_LIM4)),
						new SqlParameter("ICONST_CLINIC_BATCH_NBR", SqlNull(ICONST_CLINIC_BATCH_NBR)),
						new SqlParameter("ICONST_REDUCTION_FACTOR", SqlNull(ICONST_REDUCTION_FACTOR)),
						new SqlParameter("ICONST_OVERPAY_FACTOR", SqlNull(ICONST_OVERPAY_FACTOR)),
						new SqlParameter("ICONSTPEDNUMBERWITHINFISCALYEAR", SqlNull(ICONSTPEDNUMBERWITHINFISCALYEAR)),
						new SqlParameter("ICONST_DATE_PERIOD_END_1", SqlNull(ICONST_DATE_PERIOD_END_1)),
						new SqlParameter("ICONST_DATE_PERIOD_END_2", SqlNull(ICONST_DATE_PERIOD_END_2)),
						new SqlParameter("ICONST_DATE_PERIOD_END_3", SqlNull(ICONST_DATE_PERIOD_END_3)),
						new SqlParameter("ICONST_DATE_PERIOD_END_4", SqlNull(ICONST_DATE_PERIOD_END_4)),
						new SqlParameter("ICONST_DATE_PERIOD_END_5", SqlNull(ICONST_DATE_PERIOD_END_5)),
						new SqlParameter("ICONST_DATE_PERIOD_END_6", SqlNull(ICONST_DATE_PERIOD_END_6)),
						new SqlParameter("ICONST_DATE_PERIOD_END_7", SqlNull(ICONST_DATE_PERIOD_END_7)),
						new SqlParameter("ICONST_DATE_PERIOD_END_8", SqlNull(ICONST_DATE_PERIOD_END_8)),
						new SqlParameter("ICONST_DATE_PERIOD_END_9", SqlNull(ICONST_DATE_PERIOD_END_9)),
						new SqlParameter("ICONST_DATE_PERIOD_END_10", SqlNull(ICONST_DATE_PERIOD_END_10)),
						new SqlParameter("ICONST_DATE_PERIOD_END_11", SqlNull(ICONST_DATE_PERIOD_END_11)),
						new SqlParameter("ICONST_DATE_PERIOD_END_12", SqlNull(ICONST_DATE_PERIOD_END_12)),
						new SqlParameter("ICONST_DATE_PERIOD_END_13", SqlNull(ICONST_DATE_PERIOD_END_13)),
						new SqlParameter("ICONST_CLINIC_PAY_BATCH_NBR", SqlNull(ICONST_CLINIC_PAY_BATCH_NBR)),
						new SqlParameter("ICONST_MONTHEND", SqlNull(ICONST_MONTHEND)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_ICONST_MSTR_REC_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						ICONST_CLINIC_NBR = Reader["ICONST_CLINIC_NBR"].ToString();
						ICONST_CLINIC_NAME = Reader["ICONST_CLINIC_NAME"].ToString();
						ICONST_CLINIC_CYCLE_NBR = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]);
						ICONST_DATE_PERIOD_END_YY = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]);
						ICONST_DATE_PERIOD_END_MM = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]);
						ICONST_DATE_PERIOD_END_DD = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]);
						ICONST_CLINIC_ADDR_L1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString();
						ICONST_CLINIC_ADDR_L2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString();
						ICONST_CLINIC_ADDR_L3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString();
						ICONST_CLINIC_CARD_COLOUR = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString();
						ICONST_CLINIC_OVER_LIM1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]);
						ICONST_CLINIC_UNDER_LIM2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]);
						ICONST_CLINIC_UNDER_LIM3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]);
						ICONST_CLINIC_OVER_LIM4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]);
						ICONST_CLINIC_BATCH_NBR = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]);
						ICONST_REDUCTION_FACTOR = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]);
						ICONST_OVERPAY_FACTOR = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]);
						ICONSTPEDNUMBERWITHINFISCALYEAR = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]);
						ICONST_DATE_PERIOD_END_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]);
						ICONST_DATE_PERIOD_END_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]);
						ICONST_DATE_PERIOD_END_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]);
						ICONST_DATE_PERIOD_END_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]);
						ICONST_DATE_PERIOD_END_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]);
						ICONST_DATE_PERIOD_END_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]);
						ICONST_DATE_PERIOD_END_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]);
						ICONST_DATE_PERIOD_END_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]);
						ICONST_DATE_PERIOD_END_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]);
						ICONST_DATE_PERIOD_END_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]);
						ICONST_DATE_PERIOD_END_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]);
						ICONST_DATE_PERIOD_END_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]);
						ICONST_DATE_PERIOD_END_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]);
						ICONST_CLINIC_PAY_BATCH_NBR = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString();
						ICONST_MONTHEND = Reader["ICONST_MONTHEND"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalIconst_clinic_nbr = Reader["ICONST_CLINIC_NBR"].ToString();
						_originalIconst_clinic_name = Reader["ICONST_CLINIC_NAME"].ToString();
						_originalIconst_clinic_cycle_nbr = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]);
						_originalIconst_date_period_end_yy = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]);
						_originalIconst_date_period_end_mm = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]);
						_originalIconst_date_period_end_dd = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]);
						_originalIconst_clinic_addr_l1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString();
						_originalIconst_clinic_addr_l2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString();
						_originalIconst_clinic_addr_l3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString();
						_originalIconst_clinic_card_colour = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString();
						_originalIconst_clinic_over_lim1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]);
						_originalIconst_clinic_under_lim2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]);
						_originalIconst_clinic_under_lim3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]);
						_originalIconst_clinic_over_lim4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]);
						_originalIconst_clinic_batch_nbr = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]);
						_originalIconst_reduction_factor = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]);
						_originalIconst_overpay_factor = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]);
						_originalIconstpednumberwithinfiscalyear = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]);
						_originalIconst_date_period_end_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]);
						_originalIconst_date_period_end_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]);
						_originalIconst_date_period_end_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]);
						_originalIconst_date_period_end_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]);
						_originalIconst_date_period_end_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]);
						_originalIconst_date_period_end_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]);
						_originalIconst_date_period_end_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]);
						_originalIconst_date_period_end_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]);
						_originalIconst_date_period_end_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]);
						_originalIconst_date_period_end_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]);
						_originalIconst_date_period_end_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]);
						_originalIconst_date_period_end_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]);
						_originalIconst_date_period_end_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]);
						_originalIconst_clinic_pay_batch_nbr = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString();
						_originalIconst_monthend = Reader["ICONST_MONTHEND"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("ICONST_CLINIC_NBR_1_2", SqlNull(ICONST_CLINIC_NBR_1_2)),
						new SqlParameter("ICONST_CLINIC_NBR", SqlNull(ICONST_CLINIC_NBR)),
						new SqlParameter("ICONST_CLINIC_NAME", SqlNull(ICONST_CLINIC_NAME)),
						new SqlParameter("ICONST_CLINIC_CYCLE_NBR", SqlNull(ICONST_CLINIC_CYCLE_NBR)),
						new SqlParameter("ICONST_DATE_PERIOD_END_YY", SqlNull(ICONST_DATE_PERIOD_END_YY)),
						new SqlParameter("ICONST_DATE_PERIOD_END_MM", SqlNull(ICONST_DATE_PERIOD_END_MM)),
						new SqlParameter("ICONST_DATE_PERIOD_END_DD", SqlNull(ICONST_DATE_PERIOD_END_DD)),
						new SqlParameter("ICONST_CLINIC_ADDR_L1", SqlNull(ICONST_CLINIC_ADDR_L1)),
						new SqlParameter("ICONST_CLINIC_ADDR_L2", SqlNull(ICONST_CLINIC_ADDR_L2)),
						new SqlParameter("ICONST_CLINIC_ADDR_L3", SqlNull(ICONST_CLINIC_ADDR_L3)),
						new SqlParameter("ICONST_CLINIC_CARD_COLOUR", SqlNull(ICONST_CLINIC_CARD_COLOUR)),
						new SqlParameter("ICONST_CLINIC_OVER_LIM1", SqlNull(ICONST_CLINIC_OVER_LIM1)),
						new SqlParameter("ICONST_CLINIC_UNDER_LIM2", SqlNull(ICONST_CLINIC_UNDER_LIM2)),
						new SqlParameter("ICONST_CLINIC_UNDER_LIM3", SqlNull(ICONST_CLINIC_UNDER_LIM3)),
						new SqlParameter("ICONST_CLINIC_OVER_LIM4", SqlNull(ICONST_CLINIC_OVER_LIM4)),
						new SqlParameter("ICONST_CLINIC_BATCH_NBR", SqlNull(ICONST_CLINIC_BATCH_NBR)),
						new SqlParameter("ICONST_REDUCTION_FACTOR", SqlNull(ICONST_REDUCTION_FACTOR)),
						new SqlParameter("ICONST_OVERPAY_FACTOR", SqlNull(ICONST_OVERPAY_FACTOR)),
						new SqlParameter("ICONSTPEDNUMBERWITHINFISCALYEAR", SqlNull(ICONSTPEDNUMBERWITHINFISCALYEAR)),
						new SqlParameter("ICONST_DATE_PERIOD_END_1", SqlNull(ICONST_DATE_PERIOD_END_1)),
						new SqlParameter("ICONST_DATE_PERIOD_END_2", SqlNull(ICONST_DATE_PERIOD_END_2)),
						new SqlParameter("ICONST_DATE_PERIOD_END_3", SqlNull(ICONST_DATE_PERIOD_END_3)),
						new SqlParameter("ICONST_DATE_PERIOD_END_4", SqlNull(ICONST_DATE_PERIOD_END_4)),
						new SqlParameter("ICONST_DATE_PERIOD_END_5", SqlNull(ICONST_DATE_PERIOD_END_5)),
						new SqlParameter("ICONST_DATE_PERIOD_END_6", SqlNull(ICONST_DATE_PERIOD_END_6)),
						new SqlParameter("ICONST_DATE_PERIOD_END_7", SqlNull(ICONST_DATE_PERIOD_END_7)),
						new SqlParameter("ICONST_DATE_PERIOD_END_8", SqlNull(ICONST_DATE_PERIOD_END_8)),
						new SqlParameter("ICONST_DATE_PERIOD_END_9", SqlNull(ICONST_DATE_PERIOD_END_9)),
						new SqlParameter("ICONST_DATE_PERIOD_END_10", SqlNull(ICONST_DATE_PERIOD_END_10)),
						new SqlParameter("ICONST_DATE_PERIOD_END_11", SqlNull(ICONST_DATE_PERIOD_END_11)),
						new SqlParameter("ICONST_DATE_PERIOD_END_12", SqlNull(ICONST_DATE_PERIOD_END_12)),
						new SqlParameter("ICONST_DATE_PERIOD_END_13", SqlNull(ICONST_DATE_PERIOD_END_13)),
						new SqlParameter("ICONST_CLINIC_PAY_BATCH_NBR", SqlNull(ICONST_CLINIC_PAY_BATCH_NBR)),
						new SqlParameter("ICONST_MONTHEND", SqlNull(ICONST_MONTHEND)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_ICONST_MSTR_REC_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						ICONST_CLINIC_NBR_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						ICONST_CLINIC_NBR = Reader["ICONST_CLINIC_NBR"].ToString();
						ICONST_CLINIC_NAME = Reader["ICONST_CLINIC_NAME"].ToString();
						ICONST_CLINIC_CYCLE_NBR = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]);
						ICONST_DATE_PERIOD_END_YY = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]);
						ICONST_DATE_PERIOD_END_MM = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]);
						ICONST_DATE_PERIOD_END_DD = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]);
						ICONST_CLINIC_ADDR_L1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString();
						ICONST_CLINIC_ADDR_L2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString();
						ICONST_CLINIC_ADDR_L3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString();
						ICONST_CLINIC_CARD_COLOUR = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString();
						ICONST_CLINIC_OVER_LIM1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]);
						ICONST_CLINIC_UNDER_LIM2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]);
						ICONST_CLINIC_UNDER_LIM3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]);
						ICONST_CLINIC_OVER_LIM4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]);
						ICONST_CLINIC_BATCH_NBR = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]);
						ICONST_REDUCTION_FACTOR = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]);
						ICONST_OVERPAY_FACTOR = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]);
						ICONSTPEDNUMBERWITHINFISCALYEAR = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]);
						ICONST_DATE_PERIOD_END_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]);
						ICONST_DATE_PERIOD_END_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]);
						ICONST_DATE_PERIOD_END_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]);
						ICONST_DATE_PERIOD_END_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]);
						ICONST_DATE_PERIOD_END_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]);
						ICONST_DATE_PERIOD_END_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]);
						ICONST_DATE_PERIOD_END_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]);
						ICONST_DATE_PERIOD_END_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]);
						ICONST_DATE_PERIOD_END_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]);
						ICONST_DATE_PERIOD_END_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]);
						ICONST_DATE_PERIOD_END_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]);
						ICONST_DATE_PERIOD_END_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]);
						ICONST_DATE_PERIOD_END_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]);
						ICONST_CLINIC_PAY_BATCH_NBR = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString();
						ICONST_MONTHEND = Reader["ICONST_MONTHEND"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalIconst_clinic_nbr_1_2 = ConvertDEC(Reader["ICONST_CLINIC_NBR_1_2"]);
						_originalIconst_clinic_nbr = Reader["ICONST_CLINIC_NBR"].ToString();
						_originalIconst_clinic_name = Reader["ICONST_CLINIC_NAME"].ToString();
						_originalIconst_clinic_cycle_nbr = ConvertDEC(Reader["ICONST_CLINIC_CYCLE_NBR"]);
						_originalIconst_date_period_end_yy = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_YY"]);
						_originalIconst_date_period_end_mm = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_MM"]);
						_originalIconst_date_period_end_dd = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_DD"]);
						_originalIconst_clinic_addr_l1 = Reader["ICONST_CLINIC_ADDR_L1"].ToString();
						_originalIconst_clinic_addr_l2 = Reader["ICONST_CLINIC_ADDR_L2"].ToString();
						_originalIconst_clinic_addr_l3 = Reader["ICONST_CLINIC_ADDR_L3"].ToString();
						_originalIconst_clinic_card_colour = Reader["ICONST_CLINIC_CARD_COLOUR"].ToString();
						_originalIconst_clinic_over_lim1 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM1"]);
						_originalIconst_clinic_under_lim2 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM2"]);
						_originalIconst_clinic_under_lim3 = ConvertDEC(Reader["ICONST_CLINIC_UNDER_LIM3"]);
						_originalIconst_clinic_over_lim4 = ConvertDEC(Reader["ICONST_CLINIC_OVER_LIM4"]);
						_originalIconst_clinic_batch_nbr = ConvertDEC(Reader["ICONST_CLINIC_BATCH_NBR"]);
						_originalIconst_reduction_factor = ConvertDEC(Reader["ICONST_REDUCTION_FACTOR"]);
						_originalIconst_overpay_factor = ConvertDEC(Reader["ICONST_OVERPAY_FACTOR"]);
						_originalIconstpednumberwithinfiscalyear = ConvertDEC(Reader["ICONSTPEDNUMBERWITHINFISCALYEAR"]);
						_originalIconst_date_period_end_1 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_1"]);
						_originalIconst_date_period_end_2 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_2"]);
						_originalIconst_date_period_end_3 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_3"]);
						_originalIconst_date_period_end_4 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_4"]);
						_originalIconst_date_period_end_5 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_5"]);
						_originalIconst_date_period_end_6 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_6"]);
						_originalIconst_date_period_end_7 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_7"]);
						_originalIconst_date_period_end_8 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_8"]);
						_originalIconst_date_period_end_9 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_9"]);
						_originalIconst_date_period_end_10 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_10"]);
						_originalIconst_date_period_end_11 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_11"]);
						_originalIconst_date_period_end_12 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_12"]);
						_originalIconst_date_period_end_13 = ConvertDEC(Reader["ICONST_DATE_PERIOD_END_13"]);
						_originalIconst_clinic_pay_batch_nbr = Reader["ICONST_CLINIC_PAY_BATCH_NBR"].ToString();
						_originalIconst_monthend = Reader["ICONST_MONTHEND"].ToString();
						_originalFiller = Reader["FILLER"].ToString();
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