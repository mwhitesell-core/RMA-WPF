using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_2 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_2> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_yy_currmin,
															decimal? const_yy_currmax,
															decimal? const_mm_currmin,
															decimal? const_mm_currmax,
															decimal? const_dd_currmin,
															decimal? const_dd_currmax,
															decimal? const_bilateral_currmin,
															decimal? const_bilateral_currmax,
															decimal? const_ic_currmin,
															decimal? const_ic_currmax,
															decimal? const_sr_currmin,
															decimal? const_sr_currmax,
															decimal? const_wcb_currmin,
															decimal? const_wcb_currmax,
															decimal? const_asst_h_currmin,
															decimal? const_asst_h_currmax,
															decimal? const_reg_h_currmin,
															decimal? const_reg_h_currmax,
															decimal? const_cert_h_currmin,
															decimal? const_cert_h_currmax,
															decimal? const_asst_a_currmin,
															decimal? const_asst_a_currmax,
															decimal? const_reg_a_currmin,
															decimal? const_reg_a_currmax,
															decimal? const_cert_a_currmin,
															decimal? const_cert_a_currmax,
															decimal? const_yy_prevmin,
															decimal? const_yy_prevmax,
															decimal? const_mm_prevmin,
															decimal? const_mm_prevmax,
															decimal? const_dd_prevmin,
															decimal? const_dd_prevmax,
															decimal? const_bilateral_prevmin,
															decimal? const_bilateral_prevmax,
															decimal? const_ic_prevmin,
															decimal? const_ic_prevmax,
															decimal? const_sr_prevmin,
															decimal? const_sr_prevmax,
															decimal? const_wcb_prevmin,
															decimal? const_wcb_prevmax,
															decimal? const_asst_h_prevmin,
															decimal? const_asst_h_prevmax,
															decimal? const_reg_h_prevmin,
															decimal? const_reg_h_prevmax,
															decimal? const_cert_h_prevmin,
															decimal? const_cert_h_prevmax,
															decimal? const_asst_a_prevmin,
															decimal? const_asst_a_prevmax,
															decimal? const_reg_a_prevmin,
															decimal? const_reg_a_prevmax,
															decimal? const_cert_a_prevmin,
															decimal? const_cert_a_prevmax,
															decimal? const_max_nbr_ratesmin,
															decimal? const_max_nbr_ratesmax,
															string const_section1,
															string const_section2,
															string const_section3,
															string const_section4,
															string const_section5,
															string const_section6,
															string const_section7,
															string const_section8,
															string const_section9,
															string const_section10,
															string const_section11,
															string const_section12,
															string const_section13,
															string const_section14,
															string const_section15,
															string const_section16,
															string const_section17,
															string const_section18,
															string const_section19,
															decimal? const_group1min,
															decimal? const_group1max,
															decimal? const_group2min,
															decimal? const_group2max,
															decimal? const_group3min,
															decimal? const_group3max,
															decimal? const_group4min,
															decimal? const_group4max,
															decimal? const_group5min,
															decimal? const_group5max,
															decimal? const_group6min,
															decimal? const_group6max,
															decimal? const_group7min,
															decimal? const_group7max,
															decimal? const_group8min,
															decimal? const_group8max,
															decimal? const_group9min,
															decimal? const_group9max,
															decimal? const_group10min,
															decimal? const_group10max,
															decimal? const_group11min,
															decimal? const_group11max,
															decimal? const_group12min,
															decimal? const_group12max,
															decimal? const_group13min,
															decimal? const_group13max,
															decimal? const_group14min,
															decimal? const_group14max,
															decimal? const_group15min,
															decimal? const_group15max,
															decimal? const_group16min,
															decimal? const_group16max,
															decimal? const_group17min,
															decimal? const_group17max,
															decimal? const_group18min,
															decimal? const_group18max,
															decimal? const_group19min,
															decimal? const_group19max,
															decimal? const_rate_curr1min,
															decimal? const_rate_curr1max,
															decimal? const_rate_curr2min,
															decimal? const_rate_curr2max,
															decimal? const_rate_curr3min,
															decimal? const_rate_curr3max,
															decimal? const_rate_curr4min,
															decimal? const_rate_curr4max,
															decimal? const_rate_curr5min,
															decimal? const_rate_curr5max,
															decimal? const_rate_curr6min,
															decimal? const_rate_curr6max,
															decimal? const_rate_curr7min,
															decimal? const_rate_curr7max,
															decimal? const_rate_curr8min,
															decimal? const_rate_curr8max,
															decimal? const_rate_curr9min,
															decimal? const_rate_curr9max,
															decimal? const_rate_curr10min,
															decimal? const_rate_curr10max,
															decimal? const_rate_curr11min,
															decimal? const_rate_curr11max,
															decimal? const_rate_curr12min,
															decimal? const_rate_curr12max,
															decimal? const_rate_curr13min,
															decimal? const_rate_curr13max,
															decimal? const_rate_curr14min,
															decimal? const_rate_curr14max,
															decimal? const_rate_curr15min,
															decimal? const_rate_curr15max,
															decimal? const_rate_curr16min,
															decimal? const_rate_curr16max,
															decimal? const_rate_curr17min,
															decimal? const_rate_curr17max,
															decimal? const_rate_curr18min,
															decimal? const_rate_curr18max,
															decimal? const_rate_curr19min,
															decimal? const_rate_curr19max,
															decimal? const_rate_prev1min,
															decimal? const_rate_prev1max,
															decimal? const_rate_prev2min,
															decimal? const_rate_prev2max,
															decimal? const_rate_prev3min,
															decimal? const_rate_prev3max,
															decimal? const_rate_prev4min,
															decimal? const_rate_prev4max,
															decimal? const_rate_prev5min,
															decimal? const_rate_prev5max,
															decimal? const_rate_prev6min,
															decimal? const_rate_prev6max,
															decimal? const_rate_prev7min,
															decimal? const_rate_prev7max,
															decimal? const_rate_prev8min,
															decimal? const_rate_prev8max,
															decimal? const_rate_prev9min,
															decimal? const_rate_prev9max,
															decimal? const_rate_prev10min,
															decimal? const_rate_prev10max,
															decimal? const_rate_prev11min,
															decimal? const_rate_prev11max,
															decimal? const_rate_prev12min,
															decimal? const_rate_prev12max,
															decimal? const_rate_prev13min,
															decimal? const_rate_prev13max,
															decimal? const_rate_prev14min,
															decimal? const_rate_prev14max,
															decimal? const_rate_prev15min,
															decimal? const_rate_prev15max,
															decimal? const_rate_prev16min,
															decimal? const_rate_prev16max,
															decimal? const_rate_prev17min,
															decimal? const_rate_prev17max,
															decimal? const_rate_prev18min,
															decimal? const_rate_prev18max,
															decimal? const_rate_prev19min,
															decimal? const_rate_prev19max,
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
					new SqlParameter("minCONST_REC_NBR",const_rec_nbrmin),
					new SqlParameter("maxCONST_REC_NBR",const_rec_nbrmax),
					new SqlParameter("minCONST_YY_CURR",const_yy_currmin),
					new SqlParameter("maxCONST_YY_CURR",const_yy_currmax),
					new SqlParameter("minCONST_MM_CURR",const_mm_currmin),
					new SqlParameter("maxCONST_MM_CURR",const_mm_currmax),
					new SqlParameter("minCONST_DD_CURR",const_dd_currmin),
					new SqlParameter("maxCONST_DD_CURR",const_dd_currmax),
					new SqlParameter("minCONST_BILATERAL_CURR",const_bilateral_currmin),
					new SqlParameter("maxCONST_BILATERAL_CURR",const_bilateral_currmax),
					new SqlParameter("minCONST_IC_CURR",const_ic_currmin),
					new SqlParameter("maxCONST_IC_CURR",const_ic_currmax),
					new SqlParameter("minCONST_SR_CURR",const_sr_currmin),
					new SqlParameter("maxCONST_SR_CURR",const_sr_currmax),
					new SqlParameter("minCONST_WCB_CURR",const_wcb_currmin),
					new SqlParameter("maxCONST_WCB_CURR",const_wcb_currmax),
					new SqlParameter("minCONST_ASST_H_CURR",const_asst_h_currmin),
					new SqlParameter("maxCONST_ASST_H_CURR",const_asst_h_currmax),
					new SqlParameter("minCONST_REG_H_CURR",const_reg_h_currmin),
					new SqlParameter("maxCONST_REG_H_CURR",const_reg_h_currmax),
					new SqlParameter("minCONST_CERT_H_CURR",const_cert_h_currmin),
					new SqlParameter("maxCONST_CERT_H_CURR",const_cert_h_currmax),
					new SqlParameter("minCONST_ASST_A_CURR",const_asst_a_currmin),
					new SqlParameter("maxCONST_ASST_A_CURR",const_asst_a_currmax),
					new SqlParameter("minCONST_REG_A_CURR",const_reg_a_currmin),
					new SqlParameter("maxCONST_REG_A_CURR",const_reg_a_currmax),
					new SqlParameter("minCONST_CERT_A_CURR",const_cert_a_currmin),
					new SqlParameter("maxCONST_CERT_A_CURR",const_cert_a_currmax),
					new SqlParameter("minCONST_YY_PREV",const_yy_prevmin),
					new SqlParameter("maxCONST_YY_PREV",const_yy_prevmax),
					new SqlParameter("minCONST_MM_PREV",const_mm_prevmin),
					new SqlParameter("maxCONST_MM_PREV",const_mm_prevmax),
					new SqlParameter("minCONST_DD_PREV",const_dd_prevmin),
					new SqlParameter("maxCONST_DD_PREV",const_dd_prevmax),
					new SqlParameter("minCONST_BILATERAL_PREV",const_bilateral_prevmin),
					new SqlParameter("maxCONST_BILATERAL_PREV",const_bilateral_prevmax),
					new SqlParameter("minCONST_IC_PREV",const_ic_prevmin),
					new SqlParameter("maxCONST_IC_PREV",const_ic_prevmax),
					new SqlParameter("minCONST_SR_PREV",const_sr_prevmin),
					new SqlParameter("maxCONST_SR_PREV",const_sr_prevmax),
					new SqlParameter("minCONST_WCB_PREV",const_wcb_prevmin),
					new SqlParameter("maxCONST_WCB_PREV",const_wcb_prevmax),
					new SqlParameter("minCONST_ASST_H_PREV",const_asst_h_prevmin),
					new SqlParameter("maxCONST_ASST_H_PREV",const_asst_h_prevmax),
					new SqlParameter("minCONST_REG_H_PREV",const_reg_h_prevmin),
					new SqlParameter("maxCONST_REG_H_PREV",const_reg_h_prevmax),
					new SqlParameter("minCONST_CERT_H_PREV",const_cert_h_prevmin),
					new SqlParameter("maxCONST_CERT_H_PREV",const_cert_h_prevmax),
					new SqlParameter("minCONST_ASST_A_PREV",const_asst_a_prevmin),
					new SqlParameter("maxCONST_ASST_A_PREV",const_asst_a_prevmax),
					new SqlParameter("minCONST_REG_A_PREV",const_reg_a_prevmin),
					new SqlParameter("maxCONST_REG_A_PREV",const_reg_a_prevmax),
					new SqlParameter("minCONST_CERT_A_PREV",const_cert_a_prevmin),
					new SqlParameter("maxCONST_CERT_A_PREV",const_cert_a_prevmax),
					new SqlParameter("minCONST_MAX_NBR_RATES",const_max_nbr_ratesmin),
					new SqlParameter("maxCONST_MAX_NBR_RATES",const_max_nbr_ratesmax),
					new SqlParameter("CONST_SECTION1",const_section1),
					new SqlParameter("CONST_SECTION2",const_section2),
					new SqlParameter("CONST_SECTION3",const_section3),
					new SqlParameter("CONST_SECTION4",const_section4),
					new SqlParameter("CONST_SECTION5",const_section5),
					new SqlParameter("CONST_SECTION6",const_section6),
					new SqlParameter("CONST_SECTION7",const_section7),
					new SqlParameter("CONST_SECTION8",const_section8),
					new SqlParameter("CONST_SECTION9",const_section9),
					new SqlParameter("CONST_SECTION10",const_section10),
					new SqlParameter("CONST_SECTION11",const_section11),
					new SqlParameter("CONST_SECTION12",const_section12),
					new SqlParameter("CONST_SECTION13",const_section13),
					new SqlParameter("CONST_SECTION14",const_section14),
					new SqlParameter("CONST_SECTION15",const_section15),
					new SqlParameter("CONST_SECTION16",const_section16),
					new SqlParameter("CONST_SECTION17",const_section17),
					new SqlParameter("CONST_SECTION18",const_section18),
					new SqlParameter("CONST_SECTION19",const_section19),
					new SqlParameter("minCONST_GROUP1",const_group1min),
					new SqlParameter("maxCONST_GROUP1",const_group1max),
					new SqlParameter("minCONST_GROUP2",const_group2min),
					new SqlParameter("maxCONST_GROUP2",const_group2max),
					new SqlParameter("minCONST_GROUP3",const_group3min),
					new SqlParameter("maxCONST_GROUP3",const_group3max),
					new SqlParameter("minCONST_GROUP4",const_group4min),
					new SqlParameter("maxCONST_GROUP4",const_group4max),
					new SqlParameter("minCONST_GROUP5",const_group5min),
					new SqlParameter("maxCONST_GROUP5",const_group5max),
					new SqlParameter("minCONST_GROUP6",const_group6min),
					new SqlParameter("maxCONST_GROUP6",const_group6max),
					new SqlParameter("minCONST_GROUP7",const_group7min),
					new SqlParameter("maxCONST_GROUP7",const_group7max),
					new SqlParameter("minCONST_GROUP8",const_group8min),
					new SqlParameter("maxCONST_GROUP8",const_group8max),
					new SqlParameter("minCONST_GROUP9",const_group9min),
					new SqlParameter("maxCONST_GROUP9",const_group9max),
					new SqlParameter("minCONST_GROUP10",const_group10min),
					new SqlParameter("maxCONST_GROUP10",const_group10max),
					new SqlParameter("minCONST_GROUP11",const_group11min),
					new SqlParameter("maxCONST_GROUP11",const_group11max),
					new SqlParameter("minCONST_GROUP12",const_group12min),
					new SqlParameter("maxCONST_GROUP12",const_group12max),
					new SqlParameter("minCONST_GROUP13",const_group13min),
					new SqlParameter("maxCONST_GROUP13",const_group13max),
					new SqlParameter("minCONST_GROUP14",const_group14min),
					new SqlParameter("maxCONST_GROUP14",const_group14max),
					new SqlParameter("minCONST_GROUP15",const_group15min),
					new SqlParameter("maxCONST_GROUP15",const_group15max),
					new SqlParameter("minCONST_GROUP16",const_group16min),
					new SqlParameter("maxCONST_GROUP16",const_group16max),
					new SqlParameter("minCONST_GROUP17",const_group17min),
					new SqlParameter("maxCONST_GROUP17",const_group17max),
					new SqlParameter("minCONST_GROUP18",const_group18min),
					new SqlParameter("maxCONST_GROUP18",const_group18max),
					new SqlParameter("minCONST_GROUP19",const_group19min),
					new SqlParameter("maxCONST_GROUP19",const_group19max),
					new SqlParameter("minCONST_RATE_CURR1",const_rate_curr1min),
					new SqlParameter("maxCONST_RATE_CURR1",const_rate_curr1max),
					new SqlParameter("minCONST_RATE_CURR2",const_rate_curr2min),
					new SqlParameter("maxCONST_RATE_CURR2",const_rate_curr2max),
					new SqlParameter("minCONST_RATE_CURR3",const_rate_curr3min),
					new SqlParameter("maxCONST_RATE_CURR3",const_rate_curr3max),
					new SqlParameter("minCONST_RATE_CURR4",const_rate_curr4min),
					new SqlParameter("maxCONST_RATE_CURR4",const_rate_curr4max),
					new SqlParameter("minCONST_RATE_CURR5",const_rate_curr5min),
					new SqlParameter("maxCONST_RATE_CURR5",const_rate_curr5max),
					new SqlParameter("minCONST_RATE_CURR6",const_rate_curr6min),
					new SqlParameter("maxCONST_RATE_CURR6",const_rate_curr6max),
					new SqlParameter("minCONST_RATE_CURR7",const_rate_curr7min),
					new SqlParameter("maxCONST_RATE_CURR7",const_rate_curr7max),
					new SqlParameter("minCONST_RATE_CURR8",const_rate_curr8min),
					new SqlParameter("maxCONST_RATE_CURR8",const_rate_curr8max),
					new SqlParameter("minCONST_RATE_CURR9",const_rate_curr9min),
					new SqlParameter("maxCONST_RATE_CURR9",const_rate_curr9max),
					new SqlParameter("minCONST_RATE_CURR10",const_rate_curr10min),
					new SqlParameter("maxCONST_RATE_CURR10",const_rate_curr10max),
					new SqlParameter("minCONST_RATE_CURR11",const_rate_curr11min),
					new SqlParameter("maxCONST_RATE_CURR11",const_rate_curr11max),
					new SqlParameter("minCONST_RATE_CURR12",const_rate_curr12min),
					new SqlParameter("maxCONST_RATE_CURR12",const_rate_curr12max),
					new SqlParameter("minCONST_RATE_CURR13",const_rate_curr13min),
					new SqlParameter("maxCONST_RATE_CURR13",const_rate_curr13max),
					new SqlParameter("minCONST_RATE_CURR14",const_rate_curr14min),
					new SqlParameter("maxCONST_RATE_CURR14",const_rate_curr14max),
					new SqlParameter("minCONST_RATE_CURR15",const_rate_curr15min),
					new SqlParameter("maxCONST_RATE_CURR15",const_rate_curr15max),
					new SqlParameter("minCONST_RATE_CURR16",const_rate_curr16min),
					new SqlParameter("maxCONST_RATE_CURR16",const_rate_curr16max),
					new SqlParameter("minCONST_RATE_CURR17",const_rate_curr17min),
					new SqlParameter("maxCONST_RATE_CURR17",const_rate_curr17max),
					new SqlParameter("minCONST_RATE_CURR18",const_rate_curr18min),
					new SqlParameter("maxCONST_RATE_CURR18",const_rate_curr18max),
					new SqlParameter("minCONST_RATE_CURR19",const_rate_curr19min),
					new SqlParameter("maxCONST_RATE_CURR19",const_rate_curr19max),
					new SqlParameter("minCONST_RATE_PREV1",const_rate_prev1min),
					new SqlParameter("maxCONST_RATE_PREV1",const_rate_prev1max),
					new SqlParameter("minCONST_RATE_PREV2",const_rate_prev2min),
					new SqlParameter("maxCONST_RATE_PREV2",const_rate_prev2max),
					new SqlParameter("minCONST_RATE_PREV3",const_rate_prev3min),
					new SqlParameter("maxCONST_RATE_PREV3",const_rate_prev3max),
					new SqlParameter("minCONST_RATE_PREV4",const_rate_prev4min),
					new SqlParameter("maxCONST_RATE_PREV4",const_rate_prev4max),
					new SqlParameter("minCONST_RATE_PREV5",const_rate_prev5min),
					new SqlParameter("maxCONST_RATE_PREV5",const_rate_prev5max),
					new SqlParameter("minCONST_RATE_PREV6",const_rate_prev6min),
					new SqlParameter("maxCONST_RATE_PREV6",const_rate_prev6max),
					new SqlParameter("minCONST_RATE_PREV7",const_rate_prev7min),
					new SqlParameter("maxCONST_RATE_PREV7",const_rate_prev7max),
					new SqlParameter("minCONST_RATE_PREV8",const_rate_prev8min),
					new SqlParameter("maxCONST_RATE_PREV8",const_rate_prev8max),
					new SqlParameter("minCONST_RATE_PREV9",const_rate_prev9min),
					new SqlParameter("maxCONST_RATE_PREV9",const_rate_prev9max),
					new SqlParameter("minCONST_RATE_PREV10",const_rate_prev10min),
					new SqlParameter("maxCONST_RATE_PREV10",const_rate_prev10max),
					new SqlParameter("minCONST_RATE_PREV11",const_rate_prev11min),
					new SqlParameter("maxCONST_RATE_PREV11",const_rate_prev11max),
					new SqlParameter("minCONST_RATE_PREV12",const_rate_prev12min),
					new SqlParameter("maxCONST_RATE_PREV12",const_rate_prev12max),
					new SqlParameter("minCONST_RATE_PREV13",const_rate_prev13min),
					new SqlParameter("maxCONST_RATE_PREV13",const_rate_prev13max),
					new SqlParameter("minCONST_RATE_PREV14",const_rate_prev14min),
					new SqlParameter("maxCONST_RATE_PREV14",const_rate_prev14max),
					new SqlParameter("minCONST_RATE_PREV15",const_rate_prev15min),
					new SqlParameter("maxCONST_RATE_PREV15",const_rate_prev15max),
					new SqlParameter("minCONST_RATE_PREV16",const_rate_prev16min),
					new SqlParameter("maxCONST_RATE_PREV16",const_rate_prev16max),
					new SqlParameter("minCONST_RATE_PREV17",const_rate_prev17min),
					new SqlParameter("maxCONST_RATE_PREV17",const_rate_prev17max),
					new SqlParameter("minCONST_RATE_PREV18",const_rate_prev18min),
					new SqlParameter("maxCONST_RATE_PREV18",const_rate_prev18max),
					new SqlParameter("minCONST_RATE_PREV19",const_rate_prev19min),
					new SqlParameter("maxCONST_RATE_PREV19",const_rate_prev19max),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_2>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_2
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_YY_CURR = ConvertDEC(Reader["CONST_YY_CURR"]),
					CONST_MM_CURR = ConvertDEC(Reader["CONST_MM_CURR"]),
					CONST_DD_CURR = ConvertDEC(Reader["CONST_DD_CURR"]),
					CONST_BILATERAL_CURR = ConvertDEC(Reader["CONST_BILATERAL_CURR"]),
					CONST_IC_CURR = ConvertDEC(Reader["CONST_IC_CURR"]),
					CONST_SR_CURR = ConvertDEC(Reader["CONST_SR_CURR"]),
					CONST_WCB_CURR = ConvertDEC(Reader["CONST_WCB_CURR"]),
					CONST_ASST_H_CURR = ConvertDEC(Reader["CONST_ASST_H_CURR"]),
					CONST_REG_H_CURR = ConvertDEC(Reader["CONST_REG_H_CURR"]),
					CONST_CERT_H_CURR = ConvertDEC(Reader["CONST_CERT_H_CURR"]),
					CONST_ASST_A_CURR = ConvertDEC(Reader["CONST_ASST_A_CURR"]),
					CONST_REG_A_CURR = ConvertDEC(Reader["CONST_REG_A_CURR"]),
					CONST_CERT_A_CURR = ConvertDEC(Reader["CONST_CERT_A_CURR"]),
					CONST_YY_PREV = ConvertDEC(Reader["CONST_YY_PREV"]),
					CONST_MM_PREV = ConvertDEC(Reader["CONST_MM_PREV"]),
					CONST_DD_PREV = ConvertDEC(Reader["CONST_DD_PREV"]),
					CONST_BILATERAL_PREV = ConvertDEC(Reader["CONST_BILATERAL_PREV"]),
					CONST_IC_PREV = ConvertDEC(Reader["CONST_IC_PREV"]),
					CONST_SR_PREV = ConvertDEC(Reader["CONST_SR_PREV"]),
					CONST_WCB_PREV = ConvertDEC(Reader["CONST_WCB_PREV"]),
					CONST_ASST_H_PREV = ConvertDEC(Reader["CONST_ASST_H_PREV"]),
					CONST_REG_H_PREV = ConvertDEC(Reader["CONST_REG_H_PREV"]),
					CONST_CERT_H_PREV = ConvertDEC(Reader["CONST_CERT_H_PREV"]),
					CONST_ASST_A_PREV = ConvertDEC(Reader["CONST_ASST_A_PREV"]),
					CONST_REG_A_PREV = ConvertDEC(Reader["CONST_REG_A_PREV"]),
					CONST_CERT_A_PREV = ConvertDEC(Reader["CONST_CERT_A_PREV"]),
					CONST_MAX_NBR_RATES = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]),
					CONST_SECTION1 = Reader["CONST_SECTION1"].ToString(),
					CONST_SECTION2 = Reader["CONST_SECTION2"].ToString(),
					CONST_SECTION3 = Reader["CONST_SECTION3"].ToString(),
					CONST_SECTION4 = Reader["CONST_SECTION4"].ToString(),
					CONST_SECTION5 = Reader["CONST_SECTION5"].ToString(),
					CONST_SECTION6 = Reader["CONST_SECTION6"].ToString(),
					CONST_SECTION7 = Reader["CONST_SECTION7"].ToString(),
					CONST_SECTION8 = Reader["CONST_SECTION8"].ToString(),
					CONST_SECTION9 = Reader["CONST_SECTION9"].ToString(),
					CONST_SECTION10 = Reader["CONST_SECTION10"].ToString(),
					CONST_SECTION11 = Reader["CONST_SECTION11"].ToString(),
					CONST_SECTION12 = Reader["CONST_SECTION12"].ToString(),
					CONST_SECTION13 = Reader["CONST_SECTION13"].ToString(),
					CONST_SECTION14 = Reader["CONST_SECTION14"].ToString(),
					CONST_SECTION15 = Reader["CONST_SECTION15"].ToString(),
					CONST_SECTION16 = Reader["CONST_SECTION16"].ToString(),
					CONST_SECTION17 = Reader["CONST_SECTION17"].ToString(),
					CONST_SECTION18 = Reader["CONST_SECTION18"].ToString(),
					CONST_SECTION19 = Reader["CONST_SECTION19"].ToString(),
					CONST_GROUP1 = ConvertDEC(Reader["CONST_GROUP1"]),
					CONST_GROUP2 = ConvertDEC(Reader["CONST_GROUP2"]),
					CONST_GROUP3 = ConvertDEC(Reader["CONST_GROUP3"]),
					CONST_GROUP4 = ConvertDEC(Reader["CONST_GROUP4"]),
					CONST_GROUP5 = ConvertDEC(Reader["CONST_GROUP5"]),
					CONST_GROUP6 = ConvertDEC(Reader["CONST_GROUP6"]),
					CONST_GROUP7 = ConvertDEC(Reader["CONST_GROUP7"]),
					CONST_GROUP8 = ConvertDEC(Reader["CONST_GROUP8"]),
					CONST_GROUP9 = ConvertDEC(Reader["CONST_GROUP9"]),
					CONST_GROUP10 = ConvertDEC(Reader["CONST_GROUP10"]),
					CONST_GROUP11 = ConvertDEC(Reader["CONST_GROUP11"]),
					CONST_GROUP12 = ConvertDEC(Reader["CONST_GROUP12"]),
					CONST_GROUP13 = ConvertDEC(Reader["CONST_GROUP13"]),
					CONST_GROUP14 = ConvertDEC(Reader["CONST_GROUP14"]),
					CONST_GROUP15 = ConvertDEC(Reader["CONST_GROUP15"]),
					CONST_GROUP16 = ConvertDEC(Reader["CONST_GROUP16"]),
					CONST_GROUP17 = ConvertDEC(Reader["CONST_GROUP17"]),
					CONST_GROUP18 = ConvertDEC(Reader["CONST_GROUP18"]),
					CONST_GROUP19 = ConvertDEC(Reader["CONST_GROUP19"]),
					CONST_RATE_CURR1 = ConvertDEC(Reader["CONST_RATE_CURR1"]),
					CONST_RATE_CURR2 = ConvertDEC(Reader["CONST_RATE_CURR2"]),
					CONST_RATE_CURR3 = ConvertDEC(Reader["CONST_RATE_CURR3"]),
					CONST_RATE_CURR4 = ConvertDEC(Reader["CONST_RATE_CURR4"]),
					CONST_RATE_CURR5 = ConvertDEC(Reader["CONST_RATE_CURR5"]),
					CONST_RATE_CURR6 = ConvertDEC(Reader["CONST_RATE_CURR6"]),
					CONST_RATE_CURR7 = ConvertDEC(Reader["CONST_RATE_CURR7"]),
					CONST_RATE_CURR8 = ConvertDEC(Reader["CONST_RATE_CURR8"]),
					CONST_RATE_CURR9 = ConvertDEC(Reader["CONST_RATE_CURR9"]),
					CONST_RATE_CURR10 = ConvertDEC(Reader["CONST_RATE_CURR10"]),
					CONST_RATE_CURR11 = ConvertDEC(Reader["CONST_RATE_CURR11"]),
					CONST_RATE_CURR12 = ConvertDEC(Reader["CONST_RATE_CURR12"]),
					CONST_RATE_CURR13 = ConvertDEC(Reader["CONST_RATE_CURR13"]),
					CONST_RATE_CURR14 = ConvertDEC(Reader["CONST_RATE_CURR14"]),
					CONST_RATE_CURR15 = ConvertDEC(Reader["CONST_RATE_CURR15"]),
					CONST_RATE_CURR16 = ConvertDEC(Reader["CONST_RATE_CURR16"]),
					CONST_RATE_CURR17 = ConvertDEC(Reader["CONST_RATE_CURR17"]),
					CONST_RATE_CURR18 = ConvertDEC(Reader["CONST_RATE_CURR18"]),
					CONST_RATE_CURR19 = ConvertDEC(Reader["CONST_RATE_CURR19"]),
					CONST_RATE_PREV1 = ConvertDEC(Reader["CONST_RATE_PREV1"]),
					CONST_RATE_PREV2 = ConvertDEC(Reader["CONST_RATE_PREV2"]),
					CONST_RATE_PREV3 = ConvertDEC(Reader["CONST_RATE_PREV3"]),
					CONST_RATE_PREV4 = ConvertDEC(Reader["CONST_RATE_PREV4"]),
					CONST_RATE_PREV5 = ConvertDEC(Reader["CONST_RATE_PREV5"]),
					CONST_RATE_PREV6 = ConvertDEC(Reader["CONST_RATE_PREV6"]),
					CONST_RATE_PREV7 = ConvertDEC(Reader["CONST_RATE_PREV7"]),
					CONST_RATE_PREV8 = ConvertDEC(Reader["CONST_RATE_PREV8"]),
					CONST_RATE_PREV9 = ConvertDEC(Reader["CONST_RATE_PREV9"]),
					CONST_RATE_PREV10 = ConvertDEC(Reader["CONST_RATE_PREV10"]),
					CONST_RATE_PREV11 = ConvertDEC(Reader["CONST_RATE_PREV11"]),
					CONST_RATE_PREV12 = ConvertDEC(Reader["CONST_RATE_PREV12"]),
					CONST_RATE_PREV13 = ConvertDEC(Reader["CONST_RATE_PREV13"]),
					CONST_RATE_PREV14 = ConvertDEC(Reader["CONST_RATE_PREV14"]),
					CONST_RATE_PREV15 = ConvertDEC(Reader["CONST_RATE_PREV15"]),
					CONST_RATE_PREV16 = ConvertDEC(Reader["CONST_RATE_PREV16"]),
					CONST_RATE_PREV17 = ConvertDEC(Reader["CONST_RATE_PREV17"]),
					CONST_RATE_PREV18 = ConvertDEC(Reader["CONST_RATE_PREV18"]),
					CONST_RATE_PREV19 = ConvertDEC(Reader["CONST_RATE_PREV19"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_yy_curr = ConvertDEC(Reader["CONST_YY_CURR"]),
					_originalConst_mm_curr = ConvertDEC(Reader["CONST_MM_CURR"]),
					_originalConst_dd_curr = ConvertDEC(Reader["CONST_DD_CURR"]),
					_originalConst_bilateral_curr = ConvertDEC(Reader["CONST_BILATERAL_CURR"]),
					_originalConst_ic_curr = ConvertDEC(Reader["CONST_IC_CURR"]),
					_originalConst_sr_curr = ConvertDEC(Reader["CONST_SR_CURR"]),
					_originalConst_wcb_curr = ConvertDEC(Reader["CONST_WCB_CURR"]),
					_originalConst_asst_h_curr = ConvertDEC(Reader["CONST_ASST_H_CURR"]),
					_originalConst_reg_h_curr = ConvertDEC(Reader["CONST_REG_H_CURR"]),
					_originalConst_cert_h_curr = ConvertDEC(Reader["CONST_CERT_H_CURR"]),
					_originalConst_asst_a_curr = ConvertDEC(Reader["CONST_ASST_A_CURR"]),
					_originalConst_reg_a_curr = ConvertDEC(Reader["CONST_REG_A_CURR"]),
					_originalConst_cert_a_curr = ConvertDEC(Reader["CONST_CERT_A_CURR"]),
					_originalConst_yy_prev = ConvertDEC(Reader["CONST_YY_PREV"]),
					_originalConst_mm_prev = ConvertDEC(Reader["CONST_MM_PREV"]),
					_originalConst_dd_prev = ConvertDEC(Reader["CONST_DD_PREV"]),
					_originalConst_bilateral_prev = ConvertDEC(Reader["CONST_BILATERAL_PREV"]),
					_originalConst_ic_prev = ConvertDEC(Reader["CONST_IC_PREV"]),
					_originalConst_sr_prev = ConvertDEC(Reader["CONST_SR_PREV"]),
					_originalConst_wcb_prev = ConvertDEC(Reader["CONST_WCB_PREV"]),
					_originalConst_asst_h_prev = ConvertDEC(Reader["CONST_ASST_H_PREV"]),
					_originalConst_reg_h_prev = ConvertDEC(Reader["CONST_REG_H_PREV"]),
					_originalConst_cert_h_prev = ConvertDEC(Reader["CONST_CERT_H_PREV"]),
					_originalConst_asst_a_prev = ConvertDEC(Reader["CONST_ASST_A_PREV"]),
					_originalConst_reg_a_prev = ConvertDEC(Reader["CONST_REG_A_PREV"]),
					_originalConst_cert_a_prev = ConvertDEC(Reader["CONST_CERT_A_PREV"]),
					_originalConst_max_nbr_rates = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]),
					_originalConst_section1 = Reader["CONST_SECTION1"].ToString(),
					_originalConst_section2 = Reader["CONST_SECTION2"].ToString(),
					_originalConst_section3 = Reader["CONST_SECTION3"].ToString(),
					_originalConst_section4 = Reader["CONST_SECTION4"].ToString(),
					_originalConst_section5 = Reader["CONST_SECTION5"].ToString(),
					_originalConst_section6 = Reader["CONST_SECTION6"].ToString(),
					_originalConst_section7 = Reader["CONST_SECTION7"].ToString(),
					_originalConst_section8 = Reader["CONST_SECTION8"].ToString(),
					_originalConst_section9 = Reader["CONST_SECTION9"].ToString(),
					_originalConst_section10 = Reader["CONST_SECTION10"].ToString(),
					_originalConst_section11 = Reader["CONST_SECTION11"].ToString(),
					_originalConst_section12 = Reader["CONST_SECTION12"].ToString(),
					_originalConst_section13 = Reader["CONST_SECTION13"].ToString(),
					_originalConst_section14 = Reader["CONST_SECTION14"].ToString(),
					_originalConst_section15 = Reader["CONST_SECTION15"].ToString(),
					_originalConst_section16 = Reader["CONST_SECTION16"].ToString(),
					_originalConst_section17 = Reader["CONST_SECTION17"].ToString(),
					_originalConst_section18 = Reader["CONST_SECTION18"].ToString(),
					_originalConst_section19 = Reader["CONST_SECTION19"].ToString(),
					_originalConst_group1 = ConvertDEC(Reader["CONST_GROUP1"]),
					_originalConst_group2 = ConvertDEC(Reader["CONST_GROUP2"]),
					_originalConst_group3 = ConvertDEC(Reader["CONST_GROUP3"]),
					_originalConst_group4 = ConvertDEC(Reader["CONST_GROUP4"]),
					_originalConst_group5 = ConvertDEC(Reader["CONST_GROUP5"]),
					_originalConst_group6 = ConvertDEC(Reader["CONST_GROUP6"]),
					_originalConst_group7 = ConvertDEC(Reader["CONST_GROUP7"]),
					_originalConst_group8 = ConvertDEC(Reader["CONST_GROUP8"]),
					_originalConst_group9 = ConvertDEC(Reader["CONST_GROUP9"]),
					_originalConst_group10 = ConvertDEC(Reader["CONST_GROUP10"]),
					_originalConst_group11 = ConvertDEC(Reader["CONST_GROUP11"]),
					_originalConst_group12 = ConvertDEC(Reader["CONST_GROUP12"]),
					_originalConst_group13 = ConvertDEC(Reader["CONST_GROUP13"]),
					_originalConst_group14 = ConvertDEC(Reader["CONST_GROUP14"]),
					_originalConst_group15 = ConvertDEC(Reader["CONST_GROUP15"]),
					_originalConst_group16 = ConvertDEC(Reader["CONST_GROUP16"]),
					_originalConst_group17 = ConvertDEC(Reader["CONST_GROUP17"]),
					_originalConst_group18 = ConvertDEC(Reader["CONST_GROUP18"]),
					_originalConst_group19 = ConvertDEC(Reader["CONST_GROUP19"]),
					_originalConst_rate_curr1 = ConvertDEC(Reader["CONST_RATE_CURR1"]),
					_originalConst_rate_curr2 = ConvertDEC(Reader["CONST_RATE_CURR2"]),
					_originalConst_rate_curr3 = ConvertDEC(Reader["CONST_RATE_CURR3"]),
					_originalConst_rate_curr4 = ConvertDEC(Reader["CONST_RATE_CURR4"]),
					_originalConst_rate_curr5 = ConvertDEC(Reader["CONST_RATE_CURR5"]),
					_originalConst_rate_curr6 = ConvertDEC(Reader["CONST_RATE_CURR6"]),
					_originalConst_rate_curr7 = ConvertDEC(Reader["CONST_RATE_CURR7"]),
					_originalConst_rate_curr8 = ConvertDEC(Reader["CONST_RATE_CURR8"]),
					_originalConst_rate_curr9 = ConvertDEC(Reader["CONST_RATE_CURR9"]),
					_originalConst_rate_curr10 = ConvertDEC(Reader["CONST_RATE_CURR10"]),
					_originalConst_rate_curr11 = ConvertDEC(Reader["CONST_RATE_CURR11"]),
					_originalConst_rate_curr12 = ConvertDEC(Reader["CONST_RATE_CURR12"]),
					_originalConst_rate_curr13 = ConvertDEC(Reader["CONST_RATE_CURR13"]),
					_originalConst_rate_curr14 = ConvertDEC(Reader["CONST_RATE_CURR14"]),
					_originalConst_rate_curr15 = ConvertDEC(Reader["CONST_RATE_CURR15"]),
					_originalConst_rate_curr16 = ConvertDEC(Reader["CONST_RATE_CURR16"]),
					_originalConst_rate_curr17 = ConvertDEC(Reader["CONST_RATE_CURR17"]),
					_originalConst_rate_curr18 = ConvertDEC(Reader["CONST_RATE_CURR18"]),
					_originalConst_rate_curr19 = ConvertDEC(Reader["CONST_RATE_CURR19"]),
					_originalConst_rate_prev1 = ConvertDEC(Reader["CONST_RATE_PREV1"]),
					_originalConst_rate_prev2 = ConvertDEC(Reader["CONST_RATE_PREV2"]),
					_originalConst_rate_prev3 = ConvertDEC(Reader["CONST_RATE_PREV3"]),
					_originalConst_rate_prev4 = ConvertDEC(Reader["CONST_RATE_PREV4"]),
					_originalConst_rate_prev5 = ConvertDEC(Reader["CONST_RATE_PREV5"]),
					_originalConst_rate_prev6 = ConvertDEC(Reader["CONST_RATE_PREV6"]),
					_originalConst_rate_prev7 = ConvertDEC(Reader["CONST_RATE_PREV7"]),
					_originalConst_rate_prev8 = ConvertDEC(Reader["CONST_RATE_PREV8"]),
					_originalConst_rate_prev9 = ConvertDEC(Reader["CONST_RATE_PREV9"]),
					_originalConst_rate_prev10 = ConvertDEC(Reader["CONST_RATE_PREV10"]),
					_originalConst_rate_prev11 = ConvertDEC(Reader["CONST_RATE_PREV11"]),
					_originalConst_rate_prev12 = ConvertDEC(Reader["CONST_RATE_PREV12"]),
					_originalConst_rate_prev13 = ConvertDEC(Reader["CONST_RATE_PREV13"]),
					_originalConst_rate_prev14 = ConvertDEC(Reader["CONST_RATE_PREV14"]),
					_originalConst_rate_prev15 = ConvertDEC(Reader["CONST_RATE_PREV15"]),
					_originalConst_rate_prev16 = ConvertDEC(Reader["CONST_RATE_PREV16"]),
					_originalConst_rate_prev17 = ConvertDEC(Reader["CONST_RATE_PREV17"]),
					_originalConst_rate_prev18 = ConvertDEC(Reader["CONST_RATE_PREV18"]),
					_originalConst_rate_prev19 = ConvertDEC(Reader["CONST_RATE_PREV19"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_2 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_2> Collection(ObservableCollection<CONSTANTS_MSTR_REC_2>
                                                               constantsMstrRec2 = null)
        {
            if (IsSameSearch() && constantsMstrRec2 != null)
            {
                return constantsMstrRec2;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_2>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_YY_CURR",WhereConst_yy_curr),
					new SqlParameter("CONST_MM_CURR",WhereConst_mm_curr),
					new SqlParameter("CONST_DD_CURR",WhereConst_dd_curr),
					new SqlParameter("CONST_BILATERAL_CURR",WhereConst_bilateral_curr),
					new SqlParameter("CONST_IC_CURR",WhereConst_ic_curr),
					new SqlParameter("CONST_SR_CURR",WhereConst_sr_curr),
					new SqlParameter("CONST_WCB_CURR",WhereConst_wcb_curr),
					new SqlParameter("CONST_ASST_H_CURR",WhereConst_asst_h_curr),
					new SqlParameter("CONST_REG_H_CURR",WhereConst_reg_h_curr),
					new SqlParameter("CONST_CERT_H_CURR",WhereConst_cert_h_curr),
					new SqlParameter("CONST_ASST_A_CURR",WhereConst_asst_a_curr),
					new SqlParameter("CONST_REG_A_CURR",WhereConst_reg_a_curr),
					new SqlParameter("CONST_CERT_A_CURR",WhereConst_cert_a_curr),
					new SqlParameter("CONST_YY_PREV",WhereConst_yy_prev),
					new SqlParameter("CONST_MM_PREV",WhereConst_mm_prev),
					new SqlParameter("CONST_DD_PREV",WhereConst_dd_prev),
					new SqlParameter("CONST_BILATERAL_PREV",WhereConst_bilateral_prev),
					new SqlParameter("CONST_IC_PREV",WhereConst_ic_prev),
					new SqlParameter("CONST_SR_PREV",WhereConst_sr_prev),
					new SqlParameter("CONST_WCB_PREV",WhereConst_wcb_prev),
					new SqlParameter("CONST_ASST_H_PREV",WhereConst_asst_h_prev),
					new SqlParameter("CONST_REG_H_PREV",WhereConst_reg_h_prev),
					new SqlParameter("CONST_CERT_H_PREV",WhereConst_cert_h_prev),
					new SqlParameter("CONST_ASST_A_PREV",WhereConst_asst_a_prev),
					new SqlParameter("CONST_REG_A_PREV",WhereConst_reg_a_prev),
					new SqlParameter("CONST_CERT_A_PREV",WhereConst_cert_a_prev),
					new SqlParameter("CONST_MAX_NBR_RATES",WhereConst_max_nbr_rates),
					new SqlParameter("CONST_SECTION1",WhereConst_section1),
					new SqlParameter("CONST_SECTION2",WhereConst_section2),
					new SqlParameter("CONST_SECTION3",WhereConst_section3),
					new SqlParameter("CONST_SECTION4",WhereConst_section4),
					new SqlParameter("CONST_SECTION5",WhereConst_section5),
					new SqlParameter("CONST_SECTION6",WhereConst_section6),
					new SqlParameter("CONST_SECTION7",WhereConst_section7),
					new SqlParameter("CONST_SECTION8",WhereConst_section8),
					new SqlParameter("CONST_SECTION9",WhereConst_section9),
					new SqlParameter("CONST_SECTION10",WhereConst_section10),
					new SqlParameter("CONST_SECTION11",WhereConst_section11),
					new SqlParameter("CONST_SECTION12",WhereConst_section12),
					new SqlParameter("CONST_SECTION13",WhereConst_section13),
					new SqlParameter("CONST_SECTION14",WhereConst_section14),
					new SqlParameter("CONST_SECTION15",WhereConst_section15),
					new SqlParameter("CONST_SECTION16",WhereConst_section16),
					new SqlParameter("CONST_SECTION17",WhereConst_section17),
					new SqlParameter("CONST_SECTION18",WhereConst_section18),
					new SqlParameter("CONST_SECTION19",WhereConst_section19),
					new SqlParameter("CONST_GROUP1",WhereConst_group1),
					new SqlParameter("CONST_GROUP2",WhereConst_group2),
					new SqlParameter("CONST_GROUP3",WhereConst_group3),
					new SqlParameter("CONST_GROUP4",WhereConst_group4),
					new SqlParameter("CONST_GROUP5",WhereConst_group5),
					new SqlParameter("CONST_GROUP6",WhereConst_group6),
					new SqlParameter("CONST_GROUP7",WhereConst_group7),
					new SqlParameter("CONST_GROUP8",WhereConst_group8),
					new SqlParameter("CONST_GROUP9",WhereConst_group9),
					new SqlParameter("CONST_GROUP10",WhereConst_group10),
					new SqlParameter("CONST_GROUP11",WhereConst_group11),
					new SqlParameter("CONST_GROUP12",WhereConst_group12),
					new SqlParameter("CONST_GROUP13",WhereConst_group13),
					new SqlParameter("CONST_GROUP14",WhereConst_group14),
					new SqlParameter("CONST_GROUP15",WhereConst_group15),
					new SqlParameter("CONST_GROUP16",WhereConst_group16),
					new SqlParameter("CONST_GROUP17",WhereConst_group17),
					new SqlParameter("CONST_GROUP18",WhereConst_group18),
					new SqlParameter("CONST_GROUP19",WhereConst_group19),
					new SqlParameter("CONST_RATE_CURR1",WhereConst_rate_curr1),
					new SqlParameter("CONST_RATE_CURR2",WhereConst_rate_curr2),
					new SqlParameter("CONST_RATE_CURR3",WhereConst_rate_curr3),
					new SqlParameter("CONST_RATE_CURR4",WhereConst_rate_curr4),
					new SqlParameter("CONST_RATE_CURR5",WhereConst_rate_curr5),
					new SqlParameter("CONST_RATE_CURR6",WhereConst_rate_curr6),
					new SqlParameter("CONST_RATE_CURR7",WhereConst_rate_curr7),
					new SqlParameter("CONST_RATE_CURR8",WhereConst_rate_curr8),
					new SqlParameter("CONST_RATE_CURR9",WhereConst_rate_curr9),
					new SqlParameter("CONST_RATE_CURR10",WhereConst_rate_curr10),
					new SqlParameter("CONST_RATE_CURR11",WhereConst_rate_curr11),
					new SqlParameter("CONST_RATE_CURR12",WhereConst_rate_curr12),
					new SqlParameter("CONST_RATE_CURR13",WhereConst_rate_curr13),
					new SqlParameter("CONST_RATE_CURR14",WhereConst_rate_curr14),
					new SqlParameter("CONST_RATE_CURR15",WhereConst_rate_curr15),
					new SqlParameter("CONST_RATE_CURR16",WhereConst_rate_curr16),
					new SqlParameter("CONST_RATE_CURR17",WhereConst_rate_curr17),
					new SqlParameter("CONST_RATE_CURR18",WhereConst_rate_curr18),
					new SqlParameter("CONST_RATE_CURR19",WhereConst_rate_curr19),
					new SqlParameter("CONST_RATE_PREV1",WhereConst_rate_prev1),
					new SqlParameter("CONST_RATE_PREV2",WhereConst_rate_prev2),
					new SqlParameter("CONST_RATE_PREV3",WhereConst_rate_prev3),
					new SqlParameter("CONST_RATE_PREV4",WhereConst_rate_prev4),
					new SqlParameter("CONST_RATE_PREV5",WhereConst_rate_prev5),
					new SqlParameter("CONST_RATE_PREV6",WhereConst_rate_prev6),
					new SqlParameter("CONST_RATE_PREV7",WhereConst_rate_prev7),
					new SqlParameter("CONST_RATE_PREV8",WhereConst_rate_prev8),
					new SqlParameter("CONST_RATE_PREV9",WhereConst_rate_prev9),
					new SqlParameter("CONST_RATE_PREV10",WhereConst_rate_prev10),
					new SqlParameter("CONST_RATE_PREV11",WhereConst_rate_prev11),
					new SqlParameter("CONST_RATE_PREV12",WhereConst_rate_prev12),
					new SqlParameter("CONST_RATE_PREV13",WhereConst_rate_prev13),
					new SqlParameter("CONST_RATE_PREV14",WhereConst_rate_prev14),
					new SqlParameter("CONST_RATE_PREV15",WhereConst_rate_prev15),
					new SqlParameter("CONST_RATE_PREV16",WhereConst_rate_prev16),
					new SqlParameter("CONST_RATE_PREV17",WhereConst_rate_prev17),
					new SqlParameter("CONST_RATE_PREV18",WhereConst_rate_prev18),
					new SqlParameter("CONST_RATE_PREV19",WhereConst_rate_prev19),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_2
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_YY_CURR = ConvertDEC(Reader["CONST_YY_CURR"]),
					CONST_MM_CURR = ConvertDEC(Reader["CONST_MM_CURR"]),
					CONST_DD_CURR = ConvertDEC(Reader["CONST_DD_CURR"]),
					CONST_BILATERAL_CURR = ConvertDEC(Reader["CONST_BILATERAL_CURR"]),
					CONST_IC_CURR = ConvertDEC(Reader["CONST_IC_CURR"]),
					CONST_SR_CURR = ConvertDEC(Reader["CONST_SR_CURR"]),
					CONST_WCB_CURR = ConvertDEC(Reader["CONST_WCB_CURR"]),
					CONST_ASST_H_CURR = ConvertDEC(Reader["CONST_ASST_H_CURR"]),
					CONST_REG_H_CURR = ConvertDEC(Reader["CONST_REG_H_CURR"]),
					CONST_CERT_H_CURR = ConvertDEC(Reader["CONST_CERT_H_CURR"]),
					CONST_ASST_A_CURR = ConvertDEC(Reader["CONST_ASST_A_CURR"]),
					CONST_REG_A_CURR = ConvertDEC(Reader["CONST_REG_A_CURR"]),
					CONST_CERT_A_CURR = ConvertDEC(Reader["CONST_CERT_A_CURR"]),
					CONST_YY_PREV = ConvertDEC(Reader["CONST_YY_PREV"]),
					CONST_MM_PREV = ConvertDEC(Reader["CONST_MM_PREV"]),
					CONST_DD_PREV = ConvertDEC(Reader["CONST_DD_PREV"]),
					CONST_BILATERAL_PREV = ConvertDEC(Reader["CONST_BILATERAL_PREV"]),
					CONST_IC_PREV = ConvertDEC(Reader["CONST_IC_PREV"]),
					CONST_SR_PREV = ConvertDEC(Reader["CONST_SR_PREV"]),
					CONST_WCB_PREV = ConvertDEC(Reader["CONST_WCB_PREV"]),
					CONST_ASST_H_PREV = ConvertDEC(Reader["CONST_ASST_H_PREV"]),
					CONST_REG_H_PREV = ConvertDEC(Reader["CONST_REG_H_PREV"]),
					CONST_CERT_H_PREV = ConvertDEC(Reader["CONST_CERT_H_PREV"]),
					CONST_ASST_A_PREV = ConvertDEC(Reader["CONST_ASST_A_PREV"]),
					CONST_REG_A_PREV = ConvertDEC(Reader["CONST_REG_A_PREV"]),
					CONST_CERT_A_PREV = ConvertDEC(Reader["CONST_CERT_A_PREV"]),
					CONST_MAX_NBR_RATES = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]),
					CONST_SECTION1 = Reader["CONST_SECTION1"].ToString(),
					CONST_SECTION2 = Reader["CONST_SECTION2"].ToString(),
					CONST_SECTION3 = Reader["CONST_SECTION3"].ToString(),
					CONST_SECTION4 = Reader["CONST_SECTION4"].ToString(),
					CONST_SECTION5 = Reader["CONST_SECTION5"].ToString(),
					CONST_SECTION6 = Reader["CONST_SECTION6"].ToString(),
					CONST_SECTION7 = Reader["CONST_SECTION7"].ToString(),
					CONST_SECTION8 = Reader["CONST_SECTION8"].ToString(),
					CONST_SECTION9 = Reader["CONST_SECTION9"].ToString(),
					CONST_SECTION10 = Reader["CONST_SECTION10"].ToString(),
					CONST_SECTION11 = Reader["CONST_SECTION11"].ToString(),
					CONST_SECTION12 = Reader["CONST_SECTION12"].ToString(),
					CONST_SECTION13 = Reader["CONST_SECTION13"].ToString(),
					CONST_SECTION14 = Reader["CONST_SECTION14"].ToString(),
					CONST_SECTION15 = Reader["CONST_SECTION15"].ToString(),
					CONST_SECTION16 = Reader["CONST_SECTION16"].ToString(),
					CONST_SECTION17 = Reader["CONST_SECTION17"].ToString(),
					CONST_SECTION18 = Reader["CONST_SECTION18"].ToString(),
					CONST_SECTION19 = Reader["CONST_SECTION19"].ToString(),
					CONST_GROUP1 = ConvertDEC(Reader["CONST_GROUP1"]),
					CONST_GROUP2 = ConvertDEC(Reader["CONST_GROUP2"]),
					CONST_GROUP3 = ConvertDEC(Reader["CONST_GROUP3"]),
					CONST_GROUP4 = ConvertDEC(Reader["CONST_GROUP4"]),
					CONST_GROUP5 = ConvertDEC(Reader["CONST_GROUP5"]),
					CONST_GROUP6 = ConvertDEC(Reader["CONST_GROUP6"]),
					CONST_GROUP7 = ConvertDEC(Reader["CONST_GROUP7"]),
					CONST_GROUP8 = ConvertDEC(Reader["CONST_GROUP8"]),
					CONST_GROUP9 = ConvertDEC(Reader["CONST_GROUP9"]),
					CONST_GROUP10 = ConvertDEC(Reader["CONST_GROUP10"]),
					CONST_GROUP11 = ConvertDEC(Reader["CONST_GROUP11"]),
					CONST_GROUP12 = ConvertDEC(Reader["CONST_GROUP12"]),
					CONST_GROUP13 = ConvertDEC(Reader["CONST_GROUP13"]),
					CONST_GROUP14 = ConvertDEC(Reader["CONST_GROUP14"]),
					CONST_GROUP15 = ConvertDEC(Reader["CONST_GROUP15"]),
					CONST_GROUP16 = ConvertDEC(Reader["CONST_GROUP16"]),
					CONST_GROUP17 = ConvertDEC(Reader["CONST_GROUP17"]),
					CONST_GROUP18 = ConvertDEC(Reader["CONST_GROUP18"]),
					CONST_GROUP19 = ConvertDEC(Reader["CONST_GROUP19"]),
					CONST_RATE_CURR1 = ConvertDEC(Reader["CONST_RATE_CURR1"]),
					CONST_RATE_CURR2 = ConvertDEC(Reader["CONST_RATE_CURR2"]),
					CONST_RATE_CURR3 = ConvertDEC(Reader["CONST_RATE_CURR3"]),
					CONST_RATE_CURR4 = ConvertDEC(Reader["CONST_RATE_CURR4"]),
					CONST_RATE_CURR5 = ConvertDEC(Reader["CONST_RATE_CURR5"]),
					CONST_RATE_CURR6 = ConvertDEC(Reader["CONST_RATE_CURR6"]),
					CONST_RATE_CURR7 = ConvertDEC(Reader["CONST_RATE_CURR7"]),
					CONST_RATE_CURR8 = ConvertDEC(Reader["CONST_RATE_CURR8"]),
					CONST_RATE_CURR9 = ConvertDEC(Reader["CONST_RATE_CURR9"]),
					CONST_RATE_CURR10 = ConvertDEC(Reader["CONST_RATE_CURR10"]),
					CONST_RATE_CURR11 = ConvertDEC(Reader["CONST_RATE_CURR11"]),
					CONST_RATE_CURR12 = ConvertDEC(Reader["CONST_RATE_CURR12"]),
					CONST_RATE_CURR13 = ConvertDEC(Reader["CONST_RATE_CURR13"]),
					CONST_RATE_CURR14 = ConvertDEC(Reader["CONST_RATE_CURR14"]),
					CONST_RATE_CURR15 = ConvertDEC(Reader["CONST_RATE_CURR15"]),
					CONST_RATE_CURR16 = ConvertDEC(Reader["CONST_RATE_CURR16"]),
					CONST_RATE_CURR17 = ConvertDEC(Reader["CONST_RATE_CURR17"]),
					CONST_RATE_CURR18 = ConvertDEC(Reader["CONST_RATE_CURR18"]),
					CONST_RATE_CURR19 = ConvertDEC(Reader["CONST_RATE_CURR19"]),
					CONST_RATE_PREV1 = ConvertDEC(Reader["CONST_RATE_PREV1"]),
					CONST_RATE_PREV2 = ConvertDEC(Reader["CONST_RATE_PREV2"]),
					CONST_RATE_PREV3 = ConvertDEC(Reader["CONST_RATE_PREV3"]),
					CONST_RATE_PREV4 = ConvertDEC(Reader["CONST_RATE_PREV4"]),
					CONST_RATE_PREV5 = ConvertDEC(Reader["CONST_RATE_PREV5"]),
					CONST_RATE_PREV6 = ConvertDEC(Reader["CONST_RATE_PREV6"]),
					CONST_RATE_PREV7 = ConvertDEC(Reader["CONST_RATE_PREV7"]),
					CONST_RATE_PREV8 = ConvertDEC(Reader["CONST_RATE_PREV8"]),
					CONST_RATE_PREV9 = ConvertDEC(Reader["CONST_RATE_PREV9"]),
					CONST_RATE_PREV10 = ConvertDEC(Reader["CONST_RATE_PREV10"]),
					CONST_RATE_PREV11 = ConvertDEC(Reader["CONST_RATE_PREV11"]),
					CONST_RATE_PREV12 = ConvertDEC(Reader["CONST_RATE_PREV12"]),
					CONST_RATE_PREV13 = ConvertDEC(Reader["CONST_RATE_PREV13"]),
					CONST_RATE_PREV14 = ConvertDEC(Reader["CONST_RATE_PREV14"]),
					CONST_RATE_PREV15 = ConvertDEC(Reader["CONST_RATE_PREV15"]),
					CONST_RATE_PREV16 = ConvertDEC(Reader["CONST_RATE_PREV16"]),
					CONST_RATE_PREV17 = ConvertDEC(Reader["CONST_RATE_PREV17"]),
					CONST_RATE_PREV18 = ConvertDEC(Reader["CONST_RATE_PREV18"]),
					CONST_RATE_PREV19 = ConvertDEC(Reader["CONST_RATE_PREV19"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_yy_curr = WhereConst_yy_curr,
					_whereConst_mm_curr = WhereConst_mm_curr,
					_whereConst_dd_curr = WhereConst_dd_curr,
					_whereConst_bilateral_curr = WhereConst_bilateral_curr,
					_whereConst_ic_curr = WhereConst_ic_curr,
					_whereConst_sr_curr = WhereConst_sr_curr,
					_whereConst_wcb_curr = WhereConst_wcb_curr,
					_whereConst_asst_h_curr = WhereConst_asst_h_curr,
					_whereConst_reg_h_curr = WhereConst_reg_h_curr,
					_whereConst_cert_h_curr = WhereConst_cert_h_curr,
					_whereConst_asst_a_curr = WhereConst_asst_a_curr,
					_whereConst_reg_a_curr = WhereConst_reg_a_curr,
					_whereConst_cert_a_curr = WhereConst_cert_a_curr,
					_whereConst_yy_prev = WhereConst_yy_prev,
					_whereConst_mm_prev = WhereConst_mm_prev,
					_whereConst_dd_prev = WhereConst_dd_prev,
					_whereConst_bilateral_prev = WhereConst_bilateral_prev,
					_whereConst_ic_prev = WhereConst_ic_prev,
					_whereConst_sr_prev = WhereConst_sr_prev,
					_whereConst_wcb_prev = WhereConst_wcb_prev,
					_whereConst_asst_h_prev = WhereConst_asst_h_prev,
					_whereConst_reg_h_prev = WhereConst_reg_h_prev,
					_whereConst_cert_h_prev = WhereConst_cert_h_prev,
					_whereConst_asst_a_prev = WhereConst_asst_a_prev,
					_whereConst_reg_a_prev = WhereConst_reg_a_prev,
					_whereConst_cert_a_prev = WhereConst_cert_a_prev,
					_whereConst_max_nbr_rates = WhereConst_max_nbr_rates,
					_whereConst_section1 = WhereConst_section1,
					_whereConst_section2 = WhereConst_section2,
					_whereConst_section3 = WhereConst_section3,
					_whereConst_section4 = WhereConst_section4,
					_whereConst_section5 = WhereConst_section5,
					_whereConst_section6 = WhereConst_section6,
					_whereConst_section7 = WhereConst_section7,
					_whereConst_section8 = WhereConst_section8,
					_whereConst_section9 = WhereConst_section9,
					_whereConst_section10 = WhereConst_section10,
					_whereConst_section11 = WhereConst_section11,
					_whereConst_section12 = WhereConst_section12,
					_whereConst_section13 = WhereConst_section13,
					_whereConst_section14 = WhereConst_section14,
					_whereConst_section15 = WhereConst_section15,
					_whereConst_section16 = WhereConst_section16,
					_whereConst_section17 = WhereConst_section17,
					_whereConst_section18 = WhereConst_section18,
					_whereConst_section19 = WhereConst_section19,
					_whereConst_group1 = WhereConst_group1,
					_whereConst_group2 = WhereConst_group2,
					_whereConst_group3 = WhereConst_group3,
					_whereConst_group4 = WhereConst_group4,
					_whereConst_group5 = WhereConst_group5,
					_whereConst_group6 = WhereConst_group6,
					_whereConst_group7 = WhereConst_group7,
					_whereConst_group8 = WhereConst_group8,
					_whereConst_group9 = WhereConst_group9,
					_whereConst_group10 = WhereConst_group10,
					_whereConst_group11 = WhereConst_group11,
					_whereConst_group12 = WhereConst_group12,
					_whereConst_group13 = WhereConst_group13,
					_whereConst_group14 = WhereConst_group14,
					_whereConst_group15 = WhereConst_group15,
					_whereConst_group16 = WhereConst_group16,
					_whereConst_group17 = WhereConst_group17,
					_whereConst_group18 = WhereConst_group18,
					_whereConst_group19 = WhereConst_group19,
					_whereConst_rate_curr1 = WhereConst_rate_curr1,
					_whereConst_rate_curr2 = WhereConst_rate_curr2,
					_whereConst_rate_curr3 = WhereConst_rate_curr3,
					_whereConst_rate_curr4 = WhereConst_rate_curr4,
					_whereConst_rate_curr5 = WhereConst_rate_curr5,
					_whereConst_rate_curr6 = WhereConst_rate_curr6,
					_whereConst_rate_curr7 = WhereConst_rate_curr7,
					_whereConst_rate_curr8 = WhereConst_rate_curr8,
					_whereConst_rate_curr9 = WhereConst_rate_curr9,
					_whereConst_rate_curr10 = WhereConst_rate_curr10,
					_whereConst_rate_curr11 = WhereConst_rate_curr11,
					_whereConst_rate_curr12 = WhereConst_rate_curr12,
					_whereConst_rate_curr13 = WhereConst_rate_curr13,
					_whereConst_rate_curr14 = WhereConst_rate_curr14,
					_whereConst_rate_curr15 = WhereConst_rate_curr15,
					_whereConst_rate_curr16 = WhereConst_rate_curr16,
					_whereConst_rate_curr17 = WhereConst_rate_curr17,
					_whereConst_rate_curr18 = WhereConst_rate_curr18,
					_whereConst_rate_curr19 = WhereConst_rate_curr19,
					_whereConst_rate_prev1 = WhereConst_rate_prev1,
					_whereConst_rate_prev2 = WhereConst_rate_prev2,
					_whereConst_rate_prev3 = WhereConst_rate_prev3,
					_whereConst_rate_prev4 = WhereConst_rate_prev4,
					_whereConst_rate_prev5 = WhereConst_rate_prev5,
					_whereConst_rate_prev6 = WhereConst_rate_prev6,
					_whereConst_rate_prev7 = WhereConst_rate_prev7,
					_whereConst_rate_prev8 = WhereConst_rate_prev8,
					_whereConst_rate_prev9 = WhereConst_rate_prev9,
					_whereConst_rate_prev10 = WhereConst_rate_prev10,
					_whereConst_rate_prev11 = WhereConst_rate_prev11,
					_whereConst_rate_prev12 = WhereConst_rate_prev12,
					_whereConst_rate_prev13 = WhereConst_rate_prev13,
					_whereConst_rate_prev14 = WhereConst_rate_prev14,
					_whereConst_rate_prev15 = WhereConst_rate_prev15,
					_whereConst_rate_prev16 = WhereConst_rate_prev16,
					_whereConst_rate_prev17 = WhereConst_rate_prev17,
					_whereConst_rate_prev18 = WhereConst_rate_prev18,
					_whereConst_rate_prev19 = WhereConst_rate_prev19,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_yy_curr = ConvertDEC(Reader["CONST_YY_CURR"]),
					_originalConst_mm_curr = ConvertDEC(Reader["CONST_MM_CURR"]),
					_originalConst_dd_curr = ConvertDEC(Reader["CONST_DD_CURR"]),
					_originalConst_bilateral_curr = ConvertDEC(Reader["CONST_BILATERAL_CURR"]),
					_originalConst_ic_curr = ConvertDEC(Reader["CONST_IC_CURR"]),
					_originalConst_sr_curr = ConvertDEC(Reader["CONST_SR_CURR"]),
					_originalConst_wcb_curr = ConvertDEC(Reader["CONST_WCB_CURR"]),
					_originalConst_asst_h_curr = ConvertDEC(Reader["CONST_ASST_H_CURR"]),
					_originalConst_reg_h_curr = ConvertDEC(Reader["CONST_REG_H_CURR"]),
					_originalConst_cert_h_curr = ConvertDEC(Reader["CONST_CERT_H_CURR"]),
					_originalConst_asst_a_curr = ConvertDEC(Reader["CONST_ASST_A_CURR"]),
					_originalConst_reg_a_curr = ConvertDEC(Reader["CONST_REG_A_CURR"]),
					_originalConst_cert_a_curr = ConvertDEC(Reader["CONST_CERT_A_CURR"]),
					_originalConst_yy_prev = ConvertDEC(Reader["CONST_YY_PREV"]),
					_originalConst_mm_prev = ConvertDEC(Reader["CONST_MM_PREV"]),
					_originalConst_dd_prev = ConvertDEC(Reader["CONST_DD_PREV"]),
					_originalConst_bilateral_prev = ConvertDEC(Reader["CONST_BILATERAL_PREV"]),
					_originalConst_ic_prev = ConvertDEC(Reader["CONST_IC_PREV"]),
					_originalConst_sr_prev = ConvertDEC(Reader["CONST_SR_PREV"]),
					_originalConst_wcb_prev = ConvertDEC(Reader["CONST_WCB_PREV"]),
					_originalConst_asst_h_prev = ConvertDEC(Reader["CONST_ASST_H_PREV"]),
					_originalConst_reg_h_prev = ConvertDEC(Reader["CONST_REG_H_PREV"]),
					_originalConst_cert_h_prev = ConvertDEC(Reader["CONST_CERT_H_PREV"]),
					_originalConst_asst_a_prev = ConvertDEC(Reader["CONST_ASST_A_PREV"]),
					_originalConst_reg_a_prev = ConvertDEC(Reader["CONST_REG_A_PREV"]),
					_originalConst_cert_a_prev = ConvertDEC(Reader["CONST_CERT_A_PREV"]),
					_originalConst_max_nbr_rates = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]),
					_originalConst_section1 = Reader["CONST_SECTION1"].ToString(),
					_originalConst_section2 = Reader["CONST_SECTION2"].ToString(),
					_originalConst_section3 = Reader["CONST_SECTION3"].ToString(),
					_originalConst_section4 = Reader["CONST_SECTION4"].ToString(),
					_originalConst_section5 = Reader["CONST_SECTION5"].ToString(),
					_originalConst_section6 = Reader["CONST_SECTION6"].ToString(),
					_originalConst_section7 = Reader["CONST_SECTION7"].ToString(),
					_originalConst_section8 = Reader["CONST_SECTION8"].ToString(),
					_originalConst_section9 = Reader["CONST_SECTION9"].ToString(),
					_originalConst_section10 = Reader["CONST_SECTION10"].ToString(),
					_originalConst_section11 = Reader["CONST_SECTION11"].ToString(),
					_originalConst_section12 = Reader["CONST_SECTION12"].ToString(),
					_originalConst_section13 = Reader["CONST_SECTION13"].ToString(),
					_originalConst_section14 = Reader["CONST_SECTION14"].ToString(),
					_originalConst_section15 = Reader["CONST_SECTION15"].ToString(),
					_originalConst_section16 = Reader["CONST_SECTION16"].ToString(),
					_originalConst_section17 = Reader["CONST_SECTION17"].ToString(),
					_originalConst_section18 = Reader["CONST_SECTION18"].ToString(),
					_originalConst_section19 = Reader["CONST_SECTION19"].ToString(),
					_originalConst_group1 = ConvertDEC(Reader["CONST_GROUP1"]),
					_originalConst_group2 = ConvertDEC(Reader["CONST_GROUP2"]),
					_originalConst_group3 = ConvertDEC(Reader["CONST_GROUP3"]),
					_originalConst_group4 = ConvertDEC(Reader["CONST_GROUP4"]),
					_originalConst_group5 = ConvertDEC(Reader["CONST_GROUP5"]),
					_originalConst_group6 = ConvertDEC(Reader["CONST_GROUP6"]),
					_originalConst_group7 = ConvertDEC(Reader["CONST_GROUP7"]),
					_originalConst_group8 = ConvertDEC(Reader["CONST_GROUP8"]),
					_originalConst_group9 = ConvertDEC(Reader["CONST_GROUP9"]),
					_originalConst_group10 = ConvertDEC(Reader["CONST_GROUP10"]),
					_originalConst_group11 = ConvertDEC(Reader["CONST_GROUP11"]),
					_originalConst_group12 = ConvertDEC(Reader["CONST_GROUP12"]),
					_originalConst_group13 = ConvertDEC(Reader["CONST_GROUP13"]),
					_originalConst_group14 = ConvertDEC(Reader["CONST_GROUP14"]),
					_originalConst_group15 = ConvertDEC(Reader["CONST_GROUP15"]),
					_originalConst_group16 = ConvertDEC(Reader["CONST_GROUP16"]),
					_originalConst_group17 = ConvertDEC(Reader["CONST_GROUP17"]),
					_originalConst_group18 = ConvertDEC(Reader["CONST_GROUP18"]),
					_originalConst_group19 = ConvertDEC(Reader["CONST_GROUP19"]),
					_originalConst_rate_curr1 = ConvertDEC(Reader["CONST_RATE_CURR1"]),
					_originalConst_rate_curr2 = ConvertDEC(Reader["CONST_RATE_CURR2"]),
					_originalConst_rate_curr3 = ConvertDEC(Reader["CONST_RATE_CURR3"]),
					_originalConst_rate_curr4 = ConvertDEC(Reader["CONST_RATE_CURR4"]),
					_originalConst_rate_curr5 = ConvertDEC(Reader["CONST_RATE_CURR5"]),
					_originalConst_rate_curr6 = ConvertDEC(Reader["CONST_RATE_CURR6"]),
					_originalConst_rate_curr7 = ConvertDEC(Reader["CONST_RATE_CURR7"]),
					_originalConst_rate_curr8 = ConvertDEC(Reader["CONST_RATE_CURR8"]),
					_originalConst_rate_curr9 = ConvertDEC(Reader["CONST_RATE_CURR9"]),
					_originalConst_rate_curr10 = ConvertDEC(Reader["CONST_RATE_CURR10"]),
					_originalConst_rate_curr11 = ConvertDEC(Reader["CONST_RATE_CURR11"]),
					_originalConst_rate_curr12 = ConvertDEC(Reader["CONST_RATE_CURR12"]),
					_originalConst_rate_curr13 = ConvertDEC(Reader["CONST_RATE_CURR13"]),
					_originalConst_rate_curr14 = ConvertDEC(Reader["CONST_RATE_CURR14"]),
					_originalConst_rate_curr15 = ConvertDEC(Reader["CONST_RATE_CURR15"]),
					_originalConst_rate_curr16 = ConvertDEC(Reader["CONST_RATE_CURR16"]),
					_originalConst_rate_curr17 = ConvertDEC(Reader["CONST_RATE_CURR17"]),
					_originalConst_rate_curr18 = ConvertDEC(Reader["CONST_RATE_CURR18"]),
					_originalConst_rate_curr19 = ConvertDEC(Reader["CONST_RATE_CURR19"]),
					_originalConst_rate_prev1 = ConvertDEC(Reader["CONST_RATE_PREV1"]),
					_originalConst_rate_prev2 = ConvertDEC(Reader["CONST_RATE_PREV2"]),
					_originalConst_rate_prev3 = ConvertDEC(Reader["CONST_RATE_PREV3"]),
					_originalConst_rate_prev4 = ConvertDEC(Reader["CONST_RATE_PREV4"]),
					_originalConst_rate_prev5 = ConvertDEC(Reader["CONST_RATE_PREV5"]),
					_originalConst_rate_prev6 = ConvertDEC(Reader["CONST_RATE_PREV6"]),
					_originalConst_rate_prev7 = ConvertDEC(Reader["CONST_RATE_PREV7"]),
					_originalConst_rate_prev8 = ConvertDEC(Reader["CONST_RATE_PREV8"]),
					_originalConst_rate_prev9 = ConvertDEC(Reader["CONST_RATE_PREV9"]),
					_originalConst_rate_prev10 = ConvertDEC(Reader["CONST_RATE_PREV10"]),
					_originalConst_rate_prev11 = ConvertDEC(Reader["CONST_RATE_PREV11"]),
					_originalConst_rate_prev12 = ConvertDEC(Reader["CONST_RATE_PREV12"]),
					_originalConst_rate_prev13 = ConvertDEC(Reader["CONST_RATE_PREV13"]),
					_originalConst_rate_prev14 = ConvertDEC(Reader["CONST_RATE_PREV14"]),
					_originalConst_rate_prev15 = ConvertDEC(Reader["CONST_RATE_PREV15"]),
					_originalConst_rate_prev16 = ConvertDEC(Reader["CONST_RATE_PREV16"]),
					_originalConst_rate_prev17 = ConvertDEC(Reader["CONST_RATE_PREV17"]),
					_originalConst_rate_prev18 = ConvertDEC(Reader["CONST_RATE_PREV18"]),
					_originalConst_rate_prev19 = ConvertDEC(Reader["CONST_RATE_PREV19"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_yy_curr = WhereConst_yy_curr;
					_whereConst_mm_curr = WhereConst_mm_curr;
					_whereConst_dd_curr = WhereConst_dd_curr;
					_whereConst_bilateral_curr = WhereConst_bilateral_curr;
					_whereConst_ic_curr = WhereConst_ic_curr;
					_whereConst_sr_curr = WhereConst_sr_curr;
					_whereConst_wcb_curr = WhereConst_wcb_curr;
					_whereConst_asst_h_curr = WhereConst_asst_h_curr;
					_whereConst_reg_h_curr = WhereConst_reg_h_curr;
					_whereConst_cert_h_curr = WhereConst_cert_h_curr;
					_whereConst_asst_a_curr = WhereConst_asst_a_curr;
					_whereConst_reg_a_curr = WhereConst_reg_a_curr;
					_whereConst_cert_a_curr = WhereConst_cert_a_curr;
					_whereConst_yy_prev = WhereConst_yy_prev;
					_whereConst_mm_prev = WhereConst_mm_prev;
					_whereConst_dd_prev = WhereConst_dd_prev;
					_whereConst_bilateral_prev = WhereConst_bilateral_prev;
					_whereConst_ic_prev = WhereConst_ic_prev;
					_whereConst_sr_prev = WhereConst_sr_prev;
					_whereConst_wcb_prev = WhereConst_wcb_prev;
					_whereConst_asst_h_prev = WhereConst_asst_h_prev;
					_whereConst_reg_h_prev = WhereConst_reg_h_prev;
					_whereConst_cert_h_prev = WhereConst_cert_h_prev;
					_whereConst_asst_a_prev = WhereConst_asst_a_prev;
					_whereConst_reg_a_prev = WhereConst_reg_a_prev;
					_whereConst_cert_a_prev = WhereConst_cert_a_prev;
					_whereConst_max_nbr_rates = WhereConst_max_nbr_rates;
					_whereConst_section1 = WhereConst_section1;
					_whereConst_section2 = WhereConst_section2;
					_whereConst_section3 = WhereConst_section3;
					_whereConst_section4 = WhereConst_section4;
					_whereConst_section5 = WhereConst_section5;
					_whereConst_section6 = WhereConst_section6;
					_whereConst_section7 = WhereConst_section7;
					_whereConst_section8 = WhereConst_section8;
					_whereConst_section9 = WhereConst_section9;
					_whereConst_section10 = WhereConst_section10;
					_whereConst_section11 = WhereConst_section11;
					_whereConst_section12 = WhereConst_section12;
					_whereConst_section13 = WhereConst_section13;
					_whereConst_section14 = WhereConst_section14;
					_whereConst_section15 = WhereConst_section15;
					_whereConst_section16 = WhereConst_section16;
					_whereConst_section17 = WhereConst_section17;
					_whereConst_section18 = WhereConst_section18;
					_whereConst_section19 = WhereConst_section19;
					_whereConst_group1 = WhereConst_group1;
					_whereConst_group2 = WhereConst_group2;
					_whereConst_group3 = WhereConst_group3;
					_whereConst_group4 = WhereConst_group4;
					_whereConst_group5 = WhereConst_group5;
					_whereConst_group6 = WhereConst_group6;
					_whereConst_group7 = WhereConst_group7;
					_whereConst_group8 = WhereConst_group8;
					_whereConst_group9 = WhereConst_group9;
					_whereConst_group10 = WhereConst_group10;
					_whereConst_group11 = WhereConst_group11;
					_whereConst_group12 = WhereConst_group12;
					_whereConst_group13 = WhereConst_group13;
					_whereConst_group14 = WhereConst_group14;
					_whereConst_group15 = WhereConst_group15;
					_whereConst_group16 = WhereConst_group16;
					_whereConst_group17 = WhereConst_group17;
					_whereConst_group18 = WhereConst_group18;
					_whereConst_group19 = WhereConst_group19;
					_whereConst_rate_curr1 = WhereConst_rate_curr1;
					_whereConst_rate_curr2 = WhereConst_rate_curr2;
					_whereConst_rate_curr3 = WhereConst_rate_curr3;
					_whereConst_rate_curr4 = WhereConst_rate_curr4;
					_whereConst_rate_curr5 = WhereConst_rate_curr5;
					_whereConst_rate_curr6 = WhereConst_rate_curr6;
					_whereConst_rate_curr7 = WhereConst_rate_curr7;
					_whereConst_rate_curr8 = WhereConst_rate_curr8;
					_whereConst_rate_curr9 = WhereConst_rate_curr9;
					_whereConst_rate_curr10 = WhereConst_rate_curr10;
					_whereConst_rate_curr11 = WhereConst_rate_curr11;
					_whereConst_rate_curr12 = WhereConst_rate_curr12;
					_whereConst_rate_curr13 = WhereConst_rate_curr13;
					_whereConst_rate_curr14 = WhereConst_rate_curr14;
					_whereConst_rate_curr15 = WhereConst_rate_curr15;
					_whereConst_rate_curr16 = WhereConst_rate_curr16;
					_whereConst_rate_curr17 = WhereConst_rate_curr17;
					_whereConst_rate_curr18 = WhereConst_rate_curr18;
					_whereConst_rate_curr19 = WhereConst_rate_curr19;
					_whereConst_rate_prev1 = WhereConst_rate_prev1;
					_whereConst_rate_prev2 = WhereConst_rate_prev2;
					_whereConst_rate_prev3 = WhereConst_rate_prev3;
					_whereConst_rate_prev4 = WhereConst_rate_prev4;
					_whereConst_rate_prev5 = WhereConst_rate_prev5;
					_whereConst_rate_prev6 = WhereConst_rate_prev6;
					_whereConst_rate_prev7 = WhereConst_rate_prev7;
					_whereConst_rate_prev8 = WhereConst_rate_prev8;
					_whereConst_rate_prev9 = WhereConst_rate_prev9;
					_whereConst_rate_prev10 = WhereConst_rate_prev10;
					_whereConst_rate_prev11 = WhereConst_rate_prev11;
					_whereConst_rate_prev12 = WhereConst_rate_prev12;
					_whereConst_rate_prev13 = WhereConst_rate_prev13;
					_whereConst_rate_prev14 = WhereConst_rate_prev14;
					_whereConst_rate_prev15 = WhereConst_rate_prev15;
					_whereConst_rate_prev16 = WhereConst_rate_prev16;
					_whereConst_rate_prev17 = WhereConst_rate_prev17;
					_whereConst_rate_prev18 = WhereConst_rate_prev18;
					_whereConst_rate_prev19 = WhereConst_rate_prev19;
					_whereFiller = WhereFiller;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereConst_rec_nbr == null 
				&& WhereConst_yy_curr == null 
				&& WhereConst_mm_curr == null 
				&& WhereConst_dd_curr == null 
				&& WhereConst_bilateral_curr == null 
				&& WhereConst_ic_curr == null 
				&& WhereConst_sr_curr == null 
				&& WhereConst_wcb_curr == null 
				&& WhereConst_asst_h_curr == null 
				&& WhereConst_reg_h_curr == null 
				&& WhereConst_cert_h_curr == null 
				&& WhereConst_asst_a_curr == null 
				&& WhereConst_reg_a_curr == null 
				&& WhereConst_cert_a_curr == null 
				&& WhereConst_yy_prev == null 
				&& WhereConst_mm_prev == null 
				&& WhereConst_dd_prev == null 
				&& WhereConst_bilateral_prev == null 
				&& WhereConst_ic_prev == null 
				&& WhereConst_sr_prev == null 
				&& WhereConst_wcb_prev == null 
				&& WhereConst_asst_h_prev == null 
				&& WhereConst_reg_h_prev == null 
				&& WhereConst_cert_h_prev == null 
				&& WhereConst_asst_a_prev == null 
				&& WhereConst_reg_a_prev == null 
				&& WhereConst_cert_a_prev == null 
				&& WhereConst_max_nbr_rates == null 
				&& WhereConst_section1 == null 
				&& WhereConst_section2 == null 
				&& WhereConst_section3 == null 
				&& WhereConst_section4 == null 
				&& WhereConst_section5 == null 
				&& WhereConst_section6 == null 
				&& WhereConst_section7 == null 
				&& WhereConst_section8 == null 
				&& WhereConst_section9 == null 
				&& WhereConst_section10 == null 
				&& WhereConst_section11 == null 
				&& WhereConst_section12 == null 
				&& WhereConst_section13 == null 
				&& WhereConst_section14 == null 
				&& WhereConst_section15 == null 
				&& WhereConst_section16 == null 
				&& WhereConst_section17 == null 
				&& WhereConst_section18 == null 
				&& WhereConst_section19 == null 
				&& WhereConst_group1 == null 
				&& WhereConst_group2 == null 
				&& WhereConst_group3 == null 
				&& WhereConst_group4 == null 
				&& WhereConst_group5 == null 
				&& WhereConst_group6 == null 
				&& WhereConst_group7 == null 
				&& WhereConst_group8 == null 
				&& WhereConst_group9 == null 
				&& WhereConst_group10 == null 
				&& WhereConst_group11 == null 
				&& WhereConst_group12 == null 
				&& WhereConst_group13 == null 
				&& WhereConst_group14 == null 
				&& WhereConst_group15 == null 
				&& WhereConst_group16 == null 
				&& WhereConst_group17 == null 
				&& WhereConst_group18 == null 
				&& WhereConst_group19 == null 
				&& WhereConst_rate_curr1 == null 
				&& WhereConst_rate_curr2 == null 
				&& WhereConst_rate_curr3 == null 
				&& WhereConst_rate_curr4 == null 
				&& WhereConst_rate_curr5 == null 
				&& WhereConst_rate_curr6 == null 
				&& WhereConst_rate_curr7 == null 
				&& WhereConst_rate_curr8 == null 
				&& WhereConst_rate_curr9 == null 
				&& WhereConst_rate_curr10 == null 
				&& WhereConst_rate_curr11 == null 
				&& WhereConst_rate_curr12 == null 
				&& WhereConst_rate_curr13 == null 
				&& WhereConst_rate_curr14 == null 
				&& WhereConst_rate_curr15 == null 
				&& WhereConst_rate_curr16 == null 
				&& WhereConst_rate_curr17 == null 
				&& WhereConst_rate_curr18 == null 
				&& WhereConst_rate_curr19 == null 
				&& WhereConst_rate_prev1 == null 
				&& WhereConst_rate_prev2 == null 
				&& WhereConst_rate_prev3 == null 
				&& WhereConst_rate_prev4 == null 
				&& WhereConst_rate_prev5 == null 
				&& WhereConst_rate_prev6 == null 
				&& WhereConst_rate_prev7 == null 
				&& WhereConst_rate_prev8 == null 
				&& WhereConst_rate_prev9 == null 
				&& WhereConst_rate_prev10 == null 
				&& WhereConst_rate_prev11 == null 
				&& WhereConst_rate_prev12 == null 
				&& WhereConst_rate_prev13 == null 
				&& WhereConst_rate_prev14 == null 
				&& WhereConst_rate_prev15 == null 
				&& WhereConst_rate_prev16 == null 
				&& WhereConst_rate_prev17 == null 
				&& WhereConst_rate_prev18 == null 
				&& WhereConst_rate_prev19 == null 
				&& WhereFiller == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereConst_rec_nbr ==  _whereConst_rec_nbr
				&& WhereConst_yy_curr ==  _whereConst_yy_curr
				&& WhereConst_mm_curr ==  _whereConst_mm_curr
				&& WhereConst_dd_curr ==  _whereConst_dd_curr
				&& WhereConst_bilateral_curr ==  _whereConst_bilateral_curr
				&& WhereConst_ic_curr ==  _whereConst_ic_curr
				&& WhereConst_sr_curr ==  _whereConst_sr_curr
				&& WhereConst_wcb_curr ==  _whereConst_wcb_curr
				&& WhereConst_asst_h_curr ==  _whereConst_asst_h_curr
				&& WhereConst_reg_h_curr ==  _whereConst_reg_h_curr
				&& WhereConst_cert_h_curr ==  _whereConst_cert_h_curr
				&& WhereConst_asst_a_curr ==  _whereConst_asst_a_curr
				&& WhereConst_reg_a_curr ==  _whereConst_reg_a_curr
				&& WhereConst_cert_a_curr ==  _whereConst_cert_a_curr
				&& WhereConst_yy_prev ==  _whereConst_yy_prev
				&& WhereConst_mm_prev ==  _whereConst_mm_prev
				&& WhereConst_dd_prev ==  _whereConst_dd_prev
				&& WhereConst_bilateral_prev ==  _whereConst_bilateral_prev
				&& WhereConst_ic_prev ==  _whereConst_ic_prev
				&& WhereConst_sr_prev ==  _whereConst_sr_prev
				&& WhereConst_wcb_prev ==  _whereConst_wcb_prev
				&& WhereConst_asst_h_prev ==  _whereConst_asst_h_prev
				&& WhereConst_reg_h_prev ==  _whereConst_reg_h_prev
				&& WhereConst_cert_h_prev ==  _whereConst_cert_h_prev
				&& WhereConst_asst_a_prev ==  _whereConst_asst_a_prev
				&& WhereConst_reg_a_prev ==  _whereConst_reg_a_prev
				&& WhereConst_cert_a_prev ==  _whereConst_cert_a_prev
				&& WhereConst_max_nbr_rates ==  _whereConst_max_nbr_rates
				&& WhereConst_section1 ==  _whereConst_section1
				&& WhereConst_section2 ==  _whereConst_section2
				&& WhereConst_section3 ==  _whereConst_section3
				&& WhereConst_section4 ==  _whereConst_section4
				&& WhereConst_section5 ==  _whereConst_section5
				&& WhereConst_section6 ==  _whereConst_section6
				&& WhereConst_section7 ==  _whereConst_section7
				&& WhereConst_section8 ==  _whereConst_section8
				&& WhereConst_section9 ==  _whereConst_section9
				&& WhereConst_section10 ==  _whereConst_section10
				&& WhereConst_section11 ==  _whereConst_section11
				&& WhereConst_section12 ==  _whereConst_section12
				&& WhereConst_section13 ==  _whereConst_section13
				&& WhereConst_section14 ==  _whereConst_section14
				&& WhereConst_section15 ==  _whereConst_section15
				&& WhereConst_section16 ==  _whereConst_section16
				&& WhereConst_section17 ==  _whereConst_section17
				&& WhereConst_section18 ==  _whereConst_section18
				&& WhereConst_section19 ==  _whereConst_section19
				&& WhereConst_group1 ==  _whereConst_group1
				&& WhereConst_group2 ==  _whereConst_group2
				&& WhereConst_group3 ==  _whereConst_group3
				&& WhereConst_group4 ==  _whereConst_group4
				&& WhereConst_group5 ==  _whereConst_group5
				&& WhereConst_group6 ==  _whereConst_group6
				&& WhereConst_group7 ==  _whereConst_group7
				&& WhereConst_group8 ==  _whereConst_group8
				&& WhereConst_group9 ==  _whereConst_group9
				&& WhereConst_group10 ==  _whereConst_group10
				&& WhereConst_group11 ==  _whereConst_group11
				&& WhereConst_group12 ==  _whereConst_group12
				&& WhereConst_group13 ==  _whereConst_group13
				&& WhereConst_group14 ==  _whereConst_group14
				&& WhereConst_group15 ==  _whereConst_group15
				&& WhereConst_group16 ==  _whereConst_group16
				&& WhereConst_group17 ==  _whereConst_group17
				&& WhereConst_group18 ==  _whereConst_group18
				&& WhereConst_group19 ==  _whereConst_group19
				&& WhereConst_rate_curr1 ==  _whereConst_rate_curr1
				&& WhereConst_rate_curr2 ==  _whereConst_rate_curr2
				&& WhereConst_rate_curr3 ==  _whereConst_rate_curr3
				&& WhereConst_rate_curr4 ==  _whereConst_rate_curr4
				&& WhereConst_rate_curr5 ==  _whereConst_rate_curr5
				&& WhereConst_rate_curr6 ==  _whereConst_rate_curr6
				&& WhereConst_rate_curr7 ==  _whereConst_rate_curr7
				&& WhereConst_rate_curr8 ==  _whereConst_rate_curr8
				&& WhereConst_rate_curr9 ==  _whereConst_rate_curr9
				&& WhereConst_rate_curr10 ==  _whereConst_rate_curr10
				&& WhereConst_rate_curr11 ==  _whereConst_rate_curr11
				&& WhereConst_rate_curr12 ==  _whereConst_rate_curr12
				&& WhereConst_rate_curr13 ==  _whereConst_rate_curr13
				&& WhereConst_rate_curr14 ==  _whereConst_rate_curr14
				&& WhereConst_rate_curr15 ==  _whereConst_rate_curr15
				&& WhereConst_rate_curr16 ==  _whereConst_rate_curr16
				&& WhereConst_rate_curr17 ==  _whereConst_rate_curr17
				&& WhereConst_rate_curr18 ==  _whereConst_rate_curr18
				&& WhereConst_rate_curr19 ==  _whereConst_rate_curr19
				&& WhereConst_rate_prev1 ==  _whereConst_rate_prev1
				&& WhereConst_rate_prev2 ==  _whereConst_rate_prev2
				&& WhereConst_rate_prev3 ==  _whereConst_rate_prev3
				&& WhereConst_rate_prev4 ==  _whereConst_rate_prev4
				&& WhereConst_rate_prev5 ==  _whereConst_rate_prev5
				&& WhereConst_rate_prev6 ==  _whereConst_rate_prev6
				&& WhereConst_rate_prev7 ==  _whereConst_rate_prev7
				&& WhereConst_rate_prev8 ==  _whereConst_rate_prev8
				&& WhereConst_rate_prev9 ==  _whereConst_rate_prev9
				&& WhereConst_rate_prev10 ==  _whereConst_rate_prev10
				&& WhereConst_rate_prev11 ==  _whereConst_rate_prev11
				&& WhereConst_rate_prev12 ==  _whereConst_rate_prev12
				&& WhereConst_rate_prev13 ==  _whereConst_rate_prev13
				&& WhereConst_rate_prev14 ==  _whereConst_rate_prev14
				&& WhereConst_rate_prev15 ==  _whereConst_rate_prev15
				&& WhereConst_rate_prev16 ==  _whereConst_rate_prev16
				&& WhereConst_rate_prev17 ==  _whereConst_rate_prev17
				&& WhereConst_rate_prev18 ==  _whereConst_rate_prev18
				&& WhereConst_rate_prev19 ==  _whereConst_rate_prev19
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_yy_curr = null; 
			WhereConst_mm_curr = null; 
			WhereConst_dd_curr = null; 
			WhereConst_bilateral_curr = null; 
			WhereConst_ic_curr = null; 
			WhereConst_sr_curr = null; 
			WhereConst_wcb_curr = null; 
			WhereConst_asst_h_curr = null; 
			WhereConst_reg_h_curr = null; 
			WhereConst_cert_h_curr = null; 
			WhereConst_asst_a_curr = null; 
			WhereConst_reg_a_curr = null; 
			WhereConst_cert_a_curr = null; 
			WhereConst_yy_prev = null; 
			WhereConst_mm_prev = null; 
			WhereConst_dd_prev = null; 
			WhereConst_bilateral_prev = null; 
			WhereConst_ic_prev = null; 
			WhereConst_sr_prev = null; 
			WhereConst_wcb_prev = null; 
			WhereConst_asst_h_prev = null; 
			WhereConst_reg_h_prev = null; 
			WhereConst_cert_h_prev = null; 
			WhereConst_asst_a_prev = null; 
			WhereConst_reg_a_prev = null; 
			WhereConst_cert_a_prev = null; 
			WhereConst_max_nbr_rates = null; 
			WhereConst_section1 = null; 
			WhereConst_section2 = null; 
			WhereConst_section3 = null; 
			WhereConst_section4 = null; 
			WhereConst_section5 = null; 
			WhereConst_section6 = null; 
			WhereConst_section7 = null; 
			WhereConst_section8 = null; 
			WhereConst_section9 = null; 
			WhereConst_section10 = null; 
			WhereConst_section11 = null; 
			WhereConst_section12 = null; 
			WhereConst_section13 = null; 
			WhereConst_section14 = null; 
			WhereConst_section15 = null; 
			WhereConst_section16 = null; 
			WhereConst_section17 = null; 
			WhereConst_section18 = null; 
			WhereConst_section19 = null; 
			WhereConst_group1 = null; 
			WhereConst_group2 = null; 
			WhereConst_group3 = null; 
			WhereConst_group4 = null; 
			WhereConst_group5 = null; 
			WhereConst_group6 = null; 
			WhereConst_group7 = null; 
			WhereConst_group8 = null; 
			WhereConst_group9 = null; 
			WhereConst_group10 = null; 
			WhereConst_group11 = null; 
			WhereConst_group12 = null; 
			WhereConst_group13 = null; 
			WhereConst_group14 = null; 
			WhereConst_group15 = null; 
			WhereConst_group16 = null; 
			WhereConst_group17 = null; 
			WhereConst_group18 = null; 
			WhereConst_group19 = null; 
			WhereConst_rate_curr1 = null; 
			WhereConst_rate_curr2 = null; 
			WhereConst_rate_curr3 = null; 
			WhereConst_rate_curr4 = null; 
			WhereConst_rate_curr5 = null; 
			WhereConst_rate_curr6 = null; 
			WhereConst_rate_curr7 = null; 
			WhereConst_rate_curr8 = null; 
			WhereConst_rate_curr9 = null; 
			WhereConst_rate_curr10 = null; 
			WhereConst_rate_curr11 = null; 
			WhereConst_rate_curr12 = null; 
			WhereConst_rate_curr13 = null; 
			WhereConst_rate_curr14 = null; 
			WhereConst_rate_curr15 = null; 
			WhereConst_rate_curr16 = null; 
			WhereConst_rate_curr17 = null; 
			WhereConst_rate_curr18 = null; 
			WhereConst_rate_curr19 = null; 
			WhereConst_rate_prev1 = null; 
			WhereConst_rate_prev2 = null; 
			WhereConst_rate_prev3 = null; 
			WhereConst_rate_prev4 = null; 
			WhereConst_rate_prev5 = null; 
			WhereConst_rate_prev6 = null; 
			WhereConst_rate_prev7 = null; 
			WhereConst_rate_prev8 = null; 
			WhereConst_rate_prev9 = null; 
			WhereConst_rate_prev10 = null; 
			WhereConst_rate_prev11 = null; 
			WhereConst_rate_prev12 = null; 
			WhereConst_rate_prev13 = null; 
			WhereConst_rate_prev14 = null; 
			WhereConst_rate_prev15 = null; 
			WhereConst_rate_prev16 = null; 
			WhereConst_rate_prev17 = null; 
			WhereConst_rate_prev18 = null; 
			WhereConst_rate_prev19 = null; 
			WhereFiller = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private decimal? _CONST_REC_NBR;
		private decimal? _CONST_YY_CURR;
		private decimal? _CONST_MM_CURR;
		private decimal? _CONST_DD_CURR;
		private decimal? _CONST_BILATERAL_CURR;
		private decimal? _CONST_IC_CURR;
		private decimal? _CONST_SR_CURR;
		private decimal? _CONST_WCB_CURR;
		private decimal? _CONST_ASST_H_CURR;
		private decimal? _CONST_REG_H_CURR;
		private decimal? _CONST_CERT_H_CURR;
		private decimal? _CONST_ASST_A_CURR;
		private decimal? _CONST_REG_A_CURR;
		private decimal? _CONST_CERT_A_CURR;
		private decimal? _CONST_YY_PREV;
		private decimal? _CONST_MM_PREV;
		private decimal? _CONST_DD_PREV;
		private decimal? _CONST_BILATERAL_PREV;
		private decimal? _CONST_IC_PREV;
		private decimal? _CONST_SR_PREV;
		private decimal? _CONST_WCB_PREV;
		private decimal? _CONST_ASST_H_PREV;
		private decimal? _CONST_REG_H_PREV;
		private decimal? _CONST_CERT_H_PREV;
		private decimal? _CONST_ASST_A_PREV;
		private decimal? _CONST_REG_A_PREV;
		private decimal? _CONST_CERT_A_PREV;
		private decimal? _CONST_MAX_NBR_RATES;
		private string _CONST_SECTION1;
		private string _CONST_SECTION2;
		private string _CONST_SECTION3;
		private string _CONST_SECTION4;
		private string _CONST_SECTION5;
		private string _CONST_SECTION6;
		private string _CONST_SECTION7;
		private string _CONST_SECTION8;
		private string _CONST_SECTION9;
		private string _CONST_SECTION10;
		private string _CONST_SECTION11;
		private string _CONST_SECTION12;
		private string _CONST_SECTION13;
		private string _CONST_SECTION14;
		private string _CONST_SECTION15;
		private string _CONST_SECTION16;
		private string _CONST_SECTION17;
		private string _CONST_SECTION18;
		private string _CONST_SECTION19;
		private decimal? _CONST_GROUP1;
		private decimal? _CONST_GROUP2;
		private decimal? _CONST_GROUP3;
		private decimal? _CONST_GROUP4;
		private decimal? _CONST_GROUP5;
		private decimal? _CONST_GROUP6;
		private decimal? _CONST_GROUP7;
		private decimal? _CONST_GROUP8;
		private decimal? _CONST_GROUP9;
		private decimal? _CONST_GROUP10;
		private decimal? _CONST_GROUP11;
		private decimal? _CONST_GROUP12;
		private decimal? _CONST_GROUP13;
		private decimal? _CONST_GROUP14;
		private decimal? _CONST_GROUP15;
		private decimal? _CONST_GROUP16;
		private decimal? _CONST_GROUP17;
		private decimal? _CONST_GROUP18;
		private decimal? _CONST_GROUP19;
		private decimal? _CONST_RATE_CURR1;
		private decimal? _CONST_RATE_CURR2;
		private decimal? _CONST_RATE_CURR3;
		private decimal? _CONST_RATE_CURR4;
		private decimal? _CONST_RATE_CURR5;
		private decimal? _CONST_RATE_CURR6;
		private decimal? _CONST_RATE_CURR7;
		private decimal? _CONST_RATE_CURR8;
		private decimal? _CONST_RATE_CURR9;
		private decimal? _CONST_RATE_CURR10;
		private decimal? _CONST_RATE_CURR11;
		private decimal? _CONST_RATE_CURR12;
		private decimal? _CONST_RATE_CURR13;
		private decimal? _CONST_RATE_CURR14;
		private decimal? _CONST_RATE_CURR15;
		private decimal? _CONST_RATE_CURR16;
		private decimal? _CONST_RATE_CURR17;
		private decimal? _CONST_RATE_CURR18;
		private decimal? _CONST_RATE_CURR19;
		private decimal? _CONST_RATE_PREV1;
		private decimal? _CONST_RATE_PREV2;
		private decimal? _CONST_RATE_PREV3;
		private decimal? _CONST_RATE_PREV4;
		private decimal? _CONST_RATE_PREV5;
		private decimal? _CONST_RATE_PREV6;
		private decimal? _CONST_RATE_PREV7;
		private decimal? _CONST_RATE_PREV8;
		private decimal? _CONST_RATE_PREV9;
		private decimal? _CONST_RATE_PREV10;
		private decimal? _CONST_RATE_PREV11;
		private decimal? _CONST_RATE_PREV12;
		private decimal? _CONST_RATE_PREV13;
		private decimal? _CONST_RATE_PREV14;
		private decimal? _CONST_RATE_PREV15;
		private decimal? _CONST_RATE_PREV16;
		private decimal? _CONST_RATE_PREV17;
		private decimal? _CONST_RATE_PREV18;
		private decimal? _CONST_RATE_PREV19;
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
		public decimal? CONST_REC_NBR
		{
			get { return _CONST_REC_NBR; }
			set
			{
				if (_CONST_REC_NBR != value)
				{
					_CONST_REC_NBR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_YY_CURR
		{
			get { return _CONST_YY_CURR; }
			set
			{
				if (_CONST_YY_CURR != value)
				{
					_CONST_YY_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MM_CURR
		{
			get { return _CONST_MM_CURR; }
			set
			{
				if (_CONST_MM_CURR != value)
				{
					_CONST_MM_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_DD_CURR
		{
			get { return _CONST_DD_CURR; }
			set
			{
				if (_CONST_DD_CURR != value)
				{
					_CONST_DD_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_BILATERAL_CURR
		{
			get { return _CONST_BILATERAL_CURR; }
			set
			{
				if (_CONST_BILATERAL_CURR != value)
				{
					_CONST_BILATERAL_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_IC_CURR
		{
			get { return _CONST_IC_CURR; }
			set
			{
				if (_CONST_IC_CURR != value)
				{
					_CONST_IC_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_SR_CURR
		{
			get { return _CONST_SR_CURR; }
			set
			{
				if (_CONST_SR_CURR != value)
				{
					_CONST_SR_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_WCB_CURR
		{
			get { return _CONST_WCB_CURR; }
			set
			{
				if (_CONST_WCB_CURR != value)
				{
					_CONST_WCB_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_ASST_H_CURR
		{
			get { return _CONST_ASST_H_CURR; }
			set
			{
				if (_CONST_ASST_H_CURR != value)
				{
					_CONST_ASST_H_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_REG_H_CURR
		{
			get { return _CONST_REG_H_CURR; }
			set
			{
				if (_CONST_REG_H_CURR != value)
				{
					_CONST_REG_H_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CERT_H_CURR
		{
			get { return _CONST_CERT_H_CURR; }
			set
			{
				if (_CONST_CERT_H_CURR != value)
				{
					_CONST_CERT_H_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_ASST_A_CURR
		{
			get { return _CONST_ASST_A_CURR; }
			set
			{
				if (_CONST_ASST_A_CURR != value)
				{
					_CONST_ASST_A_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_REG_A_CURR
		{
			get { return _CONST_REG_A_CURR; }
			set
			{
				if (_CONST_REG_A_CURR != value)
				{
					_CONST_REG_A_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CERT_A_CURR
		{
			get { return _CONST_CERT_A_CURR; }
			set
			{
				if (_CONST_CERT_A_CURR != value)
				{
					_CONST_CERT_A_CURR = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_YY_PREV
		{
			get { return _CONST_YY_PREV; }
			set
			{
				if (_CONST_YY_PREV != value)
				{
					_CONST_YY_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MM_PREV
		{
			get { return _CONST_MM_PREV; }
			set
			{
				if (_CONST_MM_PREV != value)
				{
					_CONST_MM_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_DD_PREV
		{
			get { return _CONST_DD_PREV; }
			set
			{
				if (_CONST_DD_PREV != value)
				{
					_CONST_DD_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_BILATERAL_PREV
		{
			get { return _CONST_BILATERAL_PREV; }
			set
			{
				if (_CONST_BILATERAL_PREV != value)
				{
					_CONST_BILATERAL_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_IC_PREV
		{
			get { return _CONST_IC_PREV; }
			set
			{
				if (_CONST_IC_PREV != value)
				{
					_CONST_IC_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_SR_PREV
		{
			get { return _CONST_SR_PREV; }
			set
			{
				if (_CONST_SR_PREV != value)
				{
					_CONST_SR_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_WCB_PREV
		{
			get { return _CONST_WCB_PREV; }
			set
			{
				if (_CONST_WCB_PREV != value)
				{
					_CONST_WCB_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_ASST_H_PREV
		{
			get { return _CONST_ASST_H_PREV; }
			set
			{
				if (_CONST_ASST_H_PREV != value)
				{
					_CONST_ASST_H_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_REG_H_PREV
		{
			get { return _CONST_REG_H_PREV; }
			set
			{
				if (_CONST_REG_H_PREV != value)
				{
					_CONST_REG_H_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CERT_H_PREV
		{
			get { return _CONST_CERT_H_PREV; }
			set
			{
				if (_CONST_CERT_H_PREV != value)
				{
					_CONST_CERT_H_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_ASST_A_PREV
		{
			get { return _CONST_ASST_A_PREV; }
			set
			{
				if (_CONST_ASST_A_PREV != value)
				{
					_CONST_ASST_A_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_REG_A_PREV
		{
			get { return _CONST_REG_A_PREV; }
			set
			{
				if (_CONST_REG_A_PREV != value)
				{
					_CONST_REG_A_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CERT_A_PREV
		{
			get { return _CONST_CERT_A_PREV; }
			set
			{
				if (_CONST_CERT_A_PREV != value)
				{
					_CONST_CERT_A_PREV = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MAX_NBR_RATES
		{
			get { return _CONST_MAX_NBR_RATES; }
			set
			{
				if (_CONST_MAX_NBR_RATES != value)
				{
					_CONST_MAX_NBR_RATES = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION1
		{
			get { return _CONST_SECTION1; }
			set
			{
				if (_CONST_SECTION1 != value)
				{
					_CONST_SECTION1 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION2
		{
			get { return _CONST_SECTION2; }
			set
			{
				if (_CONST_SECTION2 != value)
				{
					_CONST_SECTION2 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION3
		{
			get { return _CONST_SECTION3; }
			set
			{
				if (_CONST_SECTION3 != value)
				{
					_CONST_SECTION3 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION4
		{
			get { return _CONST_SECTION4; }
			set
			{
				if (_CONST_SECTION4 != value)
				{
					_CONST_SECTION4 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION5
		{
			get { return _CONST_SECTION5; }
			set
			{
				if (_CONST_SECTION5 != value)
				{
					_CONST_SECTION5 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION6
		{
			get { return _CONST_SECTION6; }
			set
			{
				if (_CONST_SECTION6 != value)
				{
					_CONST_SECTION6 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION7
		{
			get { return _CONST_SECTION7; }
			set
			{
				if (_CONST_SECTION7 != value)
				{
					_CONST_SECTION7 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION8
		{
			get { return _CONST_SECTION8; }
			set
			{
				if (_CONST_SECTION8 != value)
				{
					_CONST_SECTION8 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION9
		{
			get { return _CONST_SECTION9; }
			set
			{
				if (_CONST_SECTION9 != value)
				{
					_CONST_SECTION9 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION10
		{
			get { return _CONST_SECTION10; }
			set
			{
				if (_CONST_SECTION10 != value)
				{
					_CONST_SECTION10 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION11
		{
			get { return _CONST_SECTION11; }
			set
			{
				if (_CONST_SECTION11 != value)
				{
					_CONST_SECTION11 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION12
		{
			get { return _CONST_SECTION12; }
			set
			{
				if (_CONST_SECTION12 != value)
				{
					_CONST_SECTION12 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION13
		{
			get { return _CONST_SECTION13; }
			set
			{
				if (_CONST_SECTION13 != value)
				{
					_CONST_SECTION13 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION14
		{
			get { return _CONST_SECTION14; }
			set
			{
				if (_CONST_SECTION14 != value)
				{
					_CONST_SECTION14 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION15
		{
			get { return _CONST_SECTION15; }
			set
			{
				if (_CONST_SECTION15 != value)
				{
					_CONST_SECTION15 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION16
		{
			get { return _CONST_SECTION16; }
			set
			{
				if (_CONST_SECTION16 != value)
				{
					_CONST_SECTION16 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION17
		{
			get { return _CONST_SECTION17; }
			set
			{
				if (_CONST_SECTION17 != value)
				{
					_CONST_SECTION17 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION18
		{
			get { return _CONST_SECTION18; }
			set
			{
				if (_CONST_SECTION18 != value)
				{
					_CONST_SECTION18 = value;
					ChangeState();
				}
			}
		}
		public string CONST_SECTION19
		{
			get { return _CONST_SECTION19; }
			set
			{
				if (_CONST_SECTION19 != value)
				{
					_CONST_SECTION19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP1
		{
			get { return _CONST_GROUP1; }
			set
			{
				if (_CONST_GROUP1 != value)
				{
					_CONST_GROUP1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP2
		{
			get { return _CONST_GROUP2; }
			set
			{
				if (_CONST_GROUP2 != value)
				{
					_CONST_GROUP2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP3
		{
			get { return _CONST_GROUP3; }
			set
			{
				if (_CONST_GROUP3 != value)
				{
					_CONST_GROUP3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP4
		{
			get { return _CONST_GROUP4; }
			set
			{
				if (_CONST_GROUP4 != value)
				{
					_CONST_GROUP4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP5
		{
			get { return _CONST_GROUP5; }
			set
			{
				if (_CONST_GROUP5 != value)
				{
					_CONST_GROUP5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP6
		{
			get { return _CONST_GROUP6; }
			set
			{
				if (_CONST_GROUP6 != value)
				{
					_CONST_GROUP6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP7
		{
			get { return _CONST_GROUP7; }
			set
			{
				if (_CONST_GROUP7 != value)
				{
					_CONST_GROUP7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP8
		{
			get { return _CONST_GROUP8; }
			set
			{
				if (_CONST_GROUP8 != value)
				{
					_CONST_GROUP8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP9
		{
			get { return _CONST_GROUP9; }
			set
			{
				if (_CONST_GROUP9 != value)
				{
					_CONST_GROUP9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP10
		{
			get { return _CONST_GROUP10; }
			set
			{
				if (_CONST_GROUP10 != value)
				{
					_CONST_GROUP10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP11
		{
			get { return _CONST_GROUP11; }
			set
			{
				if (_CONST_GROUP11 != value)
				{
					_CONST_GROUP11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP12
		{
			get { return _CONST_GROUP12; }
			set
			{
				if (_CONST_GROUP12 != value)
				{
					_CONST_GROUP12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP13
		{
			get { return _CONST_GROUP13; }
			set
			{
				if (_CONST_GROUP13 != value)
				{
					_CONST_GROUP13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP14
		{
			get { return _CONST_GROUP14; }
			set
			{
				if (_CONST_GROUP14 != value)
				{
					_CONST_GROUP14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP15
		{
			get { return _CONST_GROUP15; }
			set
			{
				if (_CONST_GROUP15 != value)
				{
					_CONST_GROUP15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP16
		{
			get { return _CONST_GROUP16; }
			set
			{
				if (_CONST_GROUP16 != value)
				{
					_CONST_GROUP16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP17
		{
			get { return _CONST_GROUP17; }
			set
			{
				if (_CONST_GROUP17 != value)
				{
					_CONST_GROUP17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP18
		{
			get { return _CONST_GROUP18; }
			set
			{
				if (_CONST_GROUP18 != value)
				{
					_CONST_GROUP18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_GROUP19
		{
			get { return _CONST_GROUP19; }
			set
			{
				if (_CONST_GROUP19 != value)
				{
					_CONST_GROUP19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR1
		{
			get { return _CONST_RATE_CURR1; }
			set
			{
				if (_CONST_RATE_CURR1 != value)
				{
					_CONST_RATE_CURR1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR2
		{
			get { return _CONST_RATE_CURR2; }
			set
			{
				if (_CONST_RATE_CURR2 != value)
				{
					_CONST_RATE_CURR2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR3
		{
			get { return _CONST_RATE_CURR3; }
			set
			{
				if (_CONST_RATE_CURR3 != value)
				{
					_CONST_RATE_CURR3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR4
		{
			get { return _CONST_RATE_CURR4; }
			set
			{
				if (_CONST_RATE_CURR4 != value)
				{
					_CONST_RATE_CURR4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR5
		{
			get { return _CONST_RATE_CURR5; }
			set
			{
				if (_CONST_RATE_CURR5 != value)
				{
					_CONST_RATE_CURR5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR6
		{
			get { return _CONST_RATE_CURR6; }
			set
			{
				if (_CONST_RATE_CURR6 != value)
				{
					_CONST_RATE_CURR6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR7
		{
			get { return _CONST_RATE_CURR7; }
			set
			{
				if (_CONST_RATE_CURR7 != value)
				{
					_CONST_RATE_CURR7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR8
		{
			get { return _CONST_RATE_CURR8; }
			set
			{
				if (_CONST_RATE_CURR8 != value)
				{
					_CONST_RATE_CURR8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR9
		{
			get { return _CONST_RATE_CURR9; }
			set
			{
				if (_CONST_RATE_CURR9 != value)
				{
					_CONST_RATE_CURR9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR10
		{
			get { return _CONST_RATE_CURR10; }
			set
			{
				if (_CONST_RATE_CURR10 != value)
				{
					_CONST_RATE_CURR10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR11
		{
			get { return _CONST_RATE_CURR11; }
			set
			{
				if (_CONST_RATE_CURR11 != value)
				{
					_CONST_RATE_CURR11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR12
		{
			get { return _CONST_RATE_CURR12; }
			set
			{
				if (_CONST_RATE_CURR12 != value)
				{
					_CONST_RATE_CURR12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR13
		{
			get { return _CONST_RATE_CURR13; }
			set
			{
				if (_CONST_RATE_CURR13 != value)
				{
					_CONST_RATE_CURR13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR14
		{
			get { return _CONST_RATE_CURR14; }
			set
			{
				if (_CONST_RATE_CURR14 != value)
				{
					_CONST_RATE_CURR14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR15
		{
			get { return _CONST_RATE_CURR15; }
			set
			{
				if (_CONST_RATE_CURR15 != value)
				{
					_CONST_RATE_CURR15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR16
		{
			get { return _CONST_RATE_CURR16; }
			set
			{
				if (_CONST_RATE_CURR16 != value)
				{
					_CONST_RATE_CURR16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR17
		{
			get { return _CONST_RATE_CURR17; }
			set
			{
				if (_CONST_RATE_CURR17 != value)
				{
					_CONST_RATE_CURR17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR18
		{
			get { return _CONST_RATE_CURR18; }
			set
			{
				if (_CONST_RATE_CURR18 != value)
				{
					_CONST_RATE_CURR18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_CURR19
		{
			get { return _CONST_RATE_CURR19; }
			set
			{
				if (_CONST_RATE_CURR19 != value)
				{
					_CONST_RATE_CURR19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV1
		{
			get { return _CONST_RATE_PREV1; }
			set
			{
				if (_CONST_RATE_PREV1 != value)
				{
					_CONST_RATE_PREV1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV2
		{
			get { return _CONST_RATE_PREV2; }
			set
			{
				if (_CONST_RATE_PREV2 != value)
				{
					_CONST_RATE_PREV2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV3
		{
			get { return _CONST_RATE_PREV3; }
			set
			{
				if (_CONST_RATE_PREV3 != value)
				{
					_CONST_RATE_PREV3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV4
		{
			get { return _CONST_RATE_PREV4; }
			set
			{
				if (_CONST_RATE_PREV4 != value)
				{
					_CONST_RATE_PREV4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV5
		{
			get { return _CONST_RATE_PREV5; }
			set
			{
				if (_CONST_RATE_PREV5 != value)
				{
					_CONST_RATE_PREV5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV6
		{
			get { return _CONST_RATE_PREV6; }
			set
			{
				if (_CONST_RATE_PREV6 != value)
				{
					_CONST_RATE_PREV6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV7
		{
			get { return _CONST_RATE_PREV7; }
			set
			{
				if (_CONST_RATE_PREV7 != value)
				{
					_CONST_RATE_PREV7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV8
		{
			get { return _CONST_RATE_PREV8; }
			set
			{
				if (_CONST_RATE_PREV8 != value)
				{
					_CONST_RATE_PREV8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV9
		{
			get { return _CONST_RATE_PREV9; }
			set
			{
				if (_CONST_RATE_PREV9 != value)
				{
					_CONST_RATE_PREV9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV10
		{
			get { return _CONST_RATE_PREV10; }
			set
			{
				if (_CONST_RATE_PREV10 != value)
				{
					_CONST_RATE_PREV10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV11
		{
			get { return _CONST_RATE_PREV11; }
			set
			{
				if (_CONST_RATE_PREV11 != value)
				{
					_CONST_RATE_PREV11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV12
		{
			get { return _CONST_RATE_PREV12; }
			set
			{
				if (_CONST_RATE_PREV12 != value)
				{
					_CONST_RATE_PREV12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV13
		{
			get { return _CONST_RATE_PREV13; }
			set
			{
				if (_CONST_RATE_PREV13 != value)
				{
					_CONST_RATE_PREV13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV14
		{
			get { return _CONST_RATE_PREV14; }
			set
			{
				if (_CONST_RATE_PREV14 != value)
				{
					_CONST_RATE_PREV14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV15
		{
			get { return _CONST_RATE_PREV15; }
			set
			{
				if (_CONST_RATE_PREV15 != value)
				{
					_CONST_RATE_PREV15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV16
		{
			get { return _CONST_RATE_PREV16; }
			set
			{
				if (_CONST_RATE_PREV16 != value)
				{
					_CONST_RATE_PREV16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV17
		{
			get { return _CONST_RATE_PREV17; }
			set
			{
				if (_CONST_RATE_PREV17 != value)
				{
					_CONST_RATE_PREV17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV18
		{
			get { return _CONST_RATE_PREV18; }
			set
			{
				if (_CONST_RATE_PREV18 != value)
				{
					_CONST_RATE_PREV18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_RATE_PREV19
		{
			get { return _CONST_RATE_PREV19; }
			set
			{
				if (_CONST_RATE_PREV19 != value)
				{
					_CONST_RATE_PREV19 = value;
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
		public decimal? WhereConst_rec_nbr { get; set; }
		private decimal? _whereConst_rec_nbr;
		public decimal? WhereConst_yy_curr { get; set; }
		private decimal? _whereConst_yy_curr;
		public decimal? WhereConst_mm_curr { get; set; }
		private decimal? _whereConst_mm_curr;
		public decimal? WhereConst_dd_curr { get; set; }
		private decimal? _whereConst_dd_curr;
		public decimal? WhereConst_bilateral_curr { get; set; }
		private decimal? _whereConst_bilateral_curr;
		public decimal? WhereConst_ic_curr { get; set; }
		private decimal? _whereConst_ic_curr;
		public decimal? WhereConst_sr_curr { get; set; }
		private decimal? _whereConst_sr_curr;
		public decimal? WhereConst_wcb_curr { get; set; }
		private decimal? _whereConst_wcb_curr;
		public decimal? WhereConst_asst_h_curr { get; set; }
		private decimal? _whereConst_asst_h_curr;
		public decimal? WhereConst_reg_h_curr { get; set; }
		private decimal? _whereConst_reg_h_curr;
		public decimal? WhereConst_cert_h_curr { get; set; }
		private decimal? _whereConst_cert_h_curr;
		public decimal? WhereConst_asst_a_curr { get; set; }
		private decimal? _whereConst_asst_a_curr;
		public decimal? WhereConst_reg_a_curr { get; set; }
		private decimal? _whereConst_reg_a_curr;
		public decimal? WhereConst_cert_a_curr { get; set; }
		private decimal? _whereConst_cert_a_curr;
		public decimal? WhereConst_yy_prev { get; set; }
		private decimal? _whereConst_yy_prev;
		public decimal? WhereConst_mm_prev { get; set; }
		private decimal? _whereConst_mm_prev;
		public decimal? WhereConst_dd_prev { get; set; }
		private decimal? _whereConst_dd_prev;
		public decimal? WhereConst_bilateral_prev { get; set; }
		private decimal? _whereConst_bilateral_prev;
		public decimal? WhereConst_ic_prev { get; set; }
		private decimal? _whereConst_ic_prev;
		public decimal? WhereConst_sr_prev { get; set; }
		private decimal? _whereConst_sr_prev;
		public decimal? WhereConst_wcb_prev { get; set; }
		private decimal? _whereConst_wcb_prev;
		public decimal? WhereConst_asst_h_prev { get; set; }
		private decimal? _whereConst_asst_h_prev;
		public decimal? WhereConst_reg_h_prev { get; set; }
		private decimal? _whereConst_reg_h_prev;
		public decimal? WhereConst_cert_h_prev { get; set; }
		private decimal? _whereConst_cert_h_prev;
		public decimal? WhereConst_asst_a_prev { get; set; }
		private decimal? _whereConst_asst_a_prev;
		public decimal? WhereConst_reg_a_prev { get; set; }
		private decimal? _whereConst_reg_a_prev;
		public decimal? WhereConst_cert_a_prev { get; set; }
		private decimal? _whereConst_cert_a_prev;
		public decimal? WhereConst_max_nbr_rates { get; set; }
		private decimal? _whereConst_max_nbr_rates;
		public string WhereConst_section1 { get; set; }
		private string _whereConst_section1;
		public string WhereConst_section2 { get; set; }
		private string _whereConst_section2;
		public string WhereConst_section3 { get; set; }
		private string _whereConst_section3;
		public string WhereConst_section4 { get; set; }
		private string _whereConst_section4;
		public string WhereConst_section5 { get; set; }
		private string _whereConst_section5;
		public string WhereConst_section6 { get; set; }
		private string _whereConst_section6;
		public string WhereConst_section7 { get; set; }
		private string _whereConst_section7;
		public string WhereConst_section8 { get; set; }
		private string _whereConst_section8;
		public string WhereConst_section9 { get; set; }
		private string _whereConst_section9;
		public string WhereConst_section10 { get; set; }
		private string _whereConst_section10;
		public string WhereConst_section11 { get; set; }
		private string _whereConst_section11;
		public string WhereConst_section12 { get; set; }
		private string _whereConst_section12;
		public string WhereConst_section13 { get; set; }
		private string _whereConst_section13;
		public string WhereConst_section14 { get; set; }
		private string _whereConst_section14;
		public string WhereConst_section15 { get; set; }
		private string _whereConst_section15;
		public string WhereConst_section16 { get; set; }
		private string _whereConst_section16;
		public string WhereConst_section17 { get; set; }
		private string _whereConst_section17;
		public string WhereConst_section18 { get; set; }
		private string _whereConst_section18;
		public string WhereConst_section19 { get; set; }
		private string _whereConst_section19;
		public decimal? WhereConst_group1 { get; set; }
		private decimal? _whereConst_group1;
		public decimal? WhereConst_group2 { get; set; }
		private decimal? _whereConst_group2;
		public decimal? WhereConst_group3 { get; set; }
		private decimal? _whereConst_group3;
		public decimal? WhereConst_group4 { get; set; }
		private decimal? _whereConst_group4;
		public decimal? WhereConst_group5 { get; set; }
		private decimal? _whereConst_group5;
		public decimal? WhereConst_group6 { get; set; }
		private decimal? _whereConst_group6;
		public decimal? WhereConst_group7 { get; set; }
		private decimal? _whereConst_group7;
		public decimal? WhereConst_group8 { get; set; }
		private decimal? _whereConst_group8;
		public decimal? WhereConst_group9 { get; set; }
		private decimal? _whereConst_group9;
		public decimal? WhereConst_group10 { get; set; }
		private decimal? _whereConst_group10;
		public decimal? WhereConst_group11 { get; set; }
		private decimal? _whereConst_group11;
		public decimal? WhereConst_group12 { get; set; }
		private decimal? _whereConst_group12;
		public decimal? WhereConst_group13 { get; set; }
		private decimal? _whereConst_group13;
		public decimal? WhereConst_group14 { get; set; }
		private decimal? _whereConst_group14;
		public decimal? WhereConst_group15 { get; set; }
		private decimal? _whereConst_group15;
		public decimal? WhereConst_group16 { get; set; }
		private decimal? _whereConst_group16;
		public decimal? WhereConst_group17 { get; set; }
		private decimal? _whereConst_group17;
		public decimal? WhereConst_group18 { get; set; }
		private decimal? _whereConst_group18;
		public decimal? WhereConst_group19 { get; set; }
		private decimal? _whereConst_group19;
		public decimal? WhereConst_rate_curr1 { get; set; }
		private decimal? _whereConst_rate_curr1;
		public decimal? WhereConst_rate_curr2 { get; set; }
		private decimal? _whereConst_rate_curr2;
		public decimal? WhereConst_rate_curr3 { get; set; }
		private decimal? _whereConst_rate_curr3;
		public decimal? WhereConst_rate_curr4 { get; set; }
		private decimal? _whereConst_rate_curr4;
		public decimal? WhereConst_rate_curr5 { get; set; }
		private decimal? _whereConst_rate_curr5;
		public decimal? WhereConst_rate_curr6 { get; set; }
		private decimal? _whereConst_rate_curr6;
		public decimal? WhereConst_rate_curr7 { get; set; }
		private decimal? _whereConst_rate_curr7;
		public decimal? WhereConst_rate_curr8 { get; set; }
		private decimal? _whereConst_rate_curr8;
		public decimal? WhereConst_rate_curr9 { get; set; }
		private decimal? _whereConst_rate_curr9;
		public decimal? WhereConst_rate_curr10 { get; set; }
		private decimal? _whereConst_rate_curr10;
		public decimal? WhereConst_rate_curr11 { get; set; }
		private decimal? _whereConst_rate_curr11;
		public decimal? WhereConst_rate_curr12 { get; set; }
		private decimal? _whereConst_rate_curr12;
		public decimal? WhereConst_rate_curr13 { get; set; }
		private decimal? _whereConst_rate_curr13;
		public decimal? WhereConst_rate_curr14 { get; set; }
		private decimal? _whereConst_rate_curr14;
		public decimal? WhereConst_rate_curr15 { get; set; }
		private decimal? _whereConst_rate_curr15;
		public decimal? WhereConst_rate_curr16 { get; set; }
		private decimal? _whereConst_rate_curr16;
		public decimal? WhereConst_rate_curr17 { get; set; }
		private decimal? _whereConst_rate_curr17;
		public decimal? WhereConst_rate_curr18 { get; set; }
		private decimal? _whereConst_rate_curr18;
		public decimal? WhereConst_rate_curr19 { get; set; }
		private decimal? _whereConst_rate_curr19;
		public decimal? WhereConst_rate_prev1 { get; set; }
		private decimal? _whereConst_rate_prev1;
		public decimal? WhereConst_rate_prev2 { get; set; }
		private decimal? _whereConst_rate_prev2;
		public decimal? WhereConst_rate_prev3 { get; set; }
		private decimal? _whereConst_rate_prev3;
		public decimal? WhereConst_rate_prev4 { get; set; }
		private decimal? _whereConst_rate_prev4;
		public decimal? WhereConst_rate_prev5 { get; set; }
		private decimal? _whereConst_rate_prev5;
		public decimal? WhereConst_rate_prev6 { get; set; }
		private decimal? _whereConst_rate_prev6;
		public decimal? WhereConst_rate_prev7 { get; set; }
		private decimal? _whereConst_rate_prev7;
		public decimal? WhereConst_rate_prev8 { get; set; }
		private decimal? _whereConst_rate_prev8;
		public decimal? WhereConst_rate_prev9 { get; set; }
		private decimal? _whereConst_rate_prev9;
		public decimal? WhereConst_rate_prev10 { get; set; }
		private decimal? _whereConst_rate_prev10;
		public decimal? WhereConst_rate_prev11 { get; set; }
		private decimal? _whereConst_rate_prev11;
		public decimal? WhereConst_rate_prev12 { get; set; }
		private decimal? _whereConst_rate_prev12;
		public decimal? WhereConst_rate_prev13 { get; set; }
		private decimal? _whereConst_rate_prev13;
		public decimal? WhereConst_rate_prev14 { get; set; }
		private decimal? _whereConst_rate_prev14;
		public decimal? WhereConst_rate_prev15 { get; set; }
		private decimal? _whereConst_rate_prev15;
		public decimal? WhereConst_rate_prev16 { get; set; }
		private decimal? _whereConst_rate_prev16;
		public decimal? WhereConst_rate_prev17 { get; set; }
		private decimal? _whereConst_rate_prev17;
		public decimal? WhereConst_rate_prev18 { get; set; }
		private decimal? _whereConst_rate_prev18;
		public decimal? WhereConst_rate_prev19 { get; set; }
		private decimal? _whereConst_rate_prev19;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_yy_curr;
		private decimal? _originalConst_mm_curr;
		private decimal? _originalConst_dd_curr;
		private decimal? _originalConst_bilateral_curr;
		private decimal? _originalConst_ic_curr;
		private decimal? _originalConst_sr_curr;
		private decimal? _originalConst_wcb_curr;
		private decimal? _originalConst_asst_h_curr;
		private decimal? _originalConst_reg_h_curr;
		private decimal? _originalConst_cert_h_curr;
		private decimal? _originalConst_asst_a_curr;
		private decimal? _originalConst_reg_a_curr;
		private decimal? _originalConst_cert_a_curr;
		private decimal? _originalConst_yy_prev;
		private decimal? _originalConst_mm_prev;
		private decimal? _originalConst_dd_prev;
		private decimal? _originalConst_bilateral_prev;
		private decimal? _originalConst_ic_prev;
		private decimal? _originalConst_sr_prev;
		private decimal? _originalConst_wcb_prev;
		private decimal? _originalConst_asst_h_prev;
		private decimal? _originalConst_reg_h_prev;
		private decimal? _originalConst_cert_h_prev;
		private decimal? _originalConst_asst_a_prev;
		private decimal? _originalConst_reg_a_prev;
		private decimal? _originalConst_cert_a_prev;
		private decimal? _originalConst_max_nbr_rates;
		private string _originalConst_section1;
		private string _originalConst_section2;
		private string _originalConst_section3;
		private string _originalConst_section4;
		private string _originalConst_section5;
		private string _originalConst_section6;
		private string _originalConst_section7;
		private string _originalConst_section8;
		private string _originalConst_section9;
		private string _originalConst_section10;
		private string _originalConst_section11;
		private string _originalConst_section12;
		private string _originalConst_section13;
		private string _originalConst_section14;
		private string _originalConst_section15;
		private string _originalConst_section16;
		private string _originalConst_section17;
		private string _originalConst_section18;
		private string _originalConst_section19;
		private decimal? _originalConst_group1;
		private decimal? _originalConst_group2;
		private decimal? _originalConst_group3;
		private decimal? _originalConst_group4;
		private decimal? _originalConst_group5;
		private decimal? _originalConst_group6;
		private decimal? _originalConst_group7;
		private decimal? _originalConst_group8;
		private decimal? _originalConst_group9;
		private decimal? _originalConst_group10;
		private decimal? _originalConst_group11;
		private decimal? _originalConst_group12;
		private decimal? _originalConst_group13;
		private decimal? _originalConst_group14;
		private decimal? _originalConst_group15;
		private decimal? _originalConst_group16;
		private decimal? _originalConst_group17;
		private decimal? _originalConst_group18;
		private decimal? _originalConst_group19;
		private decimal? _originalConst_rate_curr1;
		private decimal? _originalConst_rate_curr2;
		private decimal? _originalConst_rate_curr3;
		private decimal? _originalConst_rate_curr4;
		private decimal? _originalConst_rate_curr5;
		private decimal? _originalConst_rate_curr6;
		private decimal? _originalConst_rate_curr7;
		private decimal? _originalConst_rate_curr8;
		private decimal? _originalConst_rate_curr9;
		private decimal? _originalConst_rate_curr10;
		private decimal? _originalConst_rate_curr11;
		private decimal? _originalConst_rate_curr12;
		private decimal? _originalConst_rate_curr13;
		private decimal? _originalConst_rate_curr14;
		private decimal? _originalConst_rate_curr15;
		private decimal? _originalConst_rate_curr16;
		private decimal? _originalConst_rate_curr17;
		private decimal? _originalConst_rate_curr18;
		private decimal? _originalConst_rate_curr19;
		private decimal? _originalConst_rate_prev1;
		private decimal? _originalConst_rate_prev2;
		private decimal? _originalConst_rate_prev3;
		private decimal? _originalConst_rate_prev4;
		private decimal? _originalConst_rate_prev5;
		private decimal? _originalConst_rate_prev6;
		private decimal? _originalConst_rate_prev7;
		private decimal? _originalConst_rate_prev8;
		private decimal? _originalConst_rate_prev9;
		private decimal? _originalConst_rate_prev10;
		private decimal? _originalConst_rate_prev11;
		private decimal? _originalConst_rate_prev12;
		private decimal? _originalConst_rate_prev13;
		private decimal? _originalConst_rate_prev14;
		private decimal? _originalConst_rate_prev15;
		private decimal? _originalConst_rate_prev16;
		private decimal? _originalConst_rate_prev17;
		private decimal? _originalConst_rate_prev18;
		private decimal? _originalConst_rate_prev19;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_YY_CURR = _originalConst_yy_curr;
			CONST_MM_CURR = _originalConst_mm_curr;
			CONST_DD_CURR = _originalConst_dd_curr;
			CONST_BILATERAL_CURR = _originalConst_bilateral_curr;
			CONST_IC_CURR = _originalConst_ic_curr;
			CONST_SR_CURR = _originalConst_sr_curr;
			CONST_WCB_CURR = _originalConst_wcb_curr;
			CONST_ASST_H_CURR = _originalConst_asst_h_curr;
			CONST_REG_H_CURR = _originalConst_reg_h_curr;
			CONST_CERT_H_CURR = _originalConst_cert_h_curr;
			CONST_ASST_A_CURR = _originalConst_asst_a_curr;
			CONST_REG_A_CURR = _originalConst_reg_a_curr;
			CONST_CERT_A_CURR = _originalConst_cert_a_curr;
			CONST_YY_PREV = _originalConst_yy_prev;
			CONST_MM_PREV = _originalConst_mm_prev;
			CONST_DD_PREV = _originalConst_dd_prev;
			CONST_BILATERAL_PREV = _originalConst_bilateral_prev;
			CONST_IC_PREV = _originalConst_ic_prev;
			CONST_SR_PREV = _originalConst_sr_prev;
			CONST_WCB_PREV = _originalConst_wcb_prev;
			CONST_ASST_H_PREV = _originalConst_asst_h_prev;
			CONST_REG_H_PREV = _originalConst_reg_h_prev;
			CONST_CERT_H_PREV = _originalConst_cert_h_prev;
			CONST_ASST_A_PREV = _originalConst_asst_a_prev;
			CONST_REG_A_PREV = _originalConst_reg_a_prev;
			CONST_CERT_A_PREV = _originalConst_cert_a_prev;
			CONST_MAX_NBR_RATES = _originalConst_max_nbr_rates;
			CONST_SECTION1 = _originalConst_section1;
			CONST_SECTION2 = _originalConst_section2;
			CONST_SECTION3 = _originalConst_section3;
			CONST_SECTION4 = _originalConst_section4;
			CONST_SECTION5 = _originalConst_section5;
			CONST_SECTION6 = _originalConst_section6;
			CONST_SECTION7 = _originalConst_section7;
			CONST_SECTION8 = _originalConst_section8;
			CONST_SECTION9 = _originalConst_section9;
			CONST_SECTION10 = _originalConst_section10;
			CONST_SECTION11 = _originalConst_section11;
			CONST_SECTION12 = _originalConst_section12;
			CONST_SECTION13 = _originalConst_section13;
			CONST_SECTION14 = _originalConst_section14;
			CONST_SECTION15 = _originalConst_section15;
			CONST_SECTION16 = _originalConst_section16;
			CONST_SECTION17 = _originalConst_section17;
			CONST_SECTION18 = _originalConst_section18;
			CONST_SECTION19 = _originalConst_section19;
			CONST_GROUP1 = _originalConst_group1;
			CONST_GROUP2 = _originalConst_group2;
			CONST_GROUP3 = _originalConst_group3;
			CONST_GROUP4 = _originalConst_group4;
			CONST_GROUP5 = _originalConst_group5;
			CONST_GROUP6 = _originalConst_group6;
			CONST_GROUP7 = _originalConst_group7;
			CONST_GROUP8 = _originalConst_group8;
			CONST_GROUP9 = _originalConst_group9;
			CONST_GROUP10 = _originalConst_group10;
			CONST_GROUP11 = _originalConst_group11;
			CONST_GROUP12 = _originalConst_group12;
			CONST_GROUP13 = _originalConst_group13;
			CONST_GROUP14 = _originalConst_group14;
			CONST_GROUP15 = _originalConst_group15;
			CONST_GROUP16 = _originalConst_group16;
			CONST_GROUP17 = _originalConst_group17;
			CONST_GROUP18 = _originalConst_group18;
			CONST_GROUP19 = _originalConst_group19;
			CONST_RATE_CURR1 = _originalConst_rate_curr1;
			CONST_RATE_CURR2 = _originalConst_rate_curr2;
			CONST_RATE_CURR3 = _originalConst_rate_curr3;
			CONST_RATE_CURR4 = _originalConst_rate_curr4;
			CONST_RATE_CURR5 = _originalConst_rate_curr5;
			CONST_RATE_CURR6 = _originalConst_rate_curr6;
			CONST_RATE_CURR7 = _originalConst_rate_curr7;
			CONST_RATE_CURR8 = _originalConst_rate_curr8;
			CONST_RATE_CURR9 = _originalConst_rate_curr9;
			CONST_RATE_CURR10 = _originalConst_rate_curr10;
			CONST_RATE_CURR11 = _originalConst_rate_curr11;
			CONST_RATE_CURR12 = _originalConst_rate_curr12;
			CONST_RATE_CURR13 = _originalConst_rate_curr13;
			CONST_RATE_CURR14 = _originalConst_rate_curr14;
			CONST_RATE_CURR15 = _originalConst_rate_curr15;
			CONST_RATE_CURR16 = _originalConst_rate_curr16;
			CONST_RATE_CURR17 = _originalConst_rate_curr17;
			CONST_RATE_CURR18 = _originalConst_rate_curr18;
			CONST_RATE_CURR19 = _originalConst_rate_curr19;
			CONST_RATE_PREV1 = _originalConst_rate_prev1;
			CONST_RATE_PREV2 = _originalConst_rate_prev2;
			CONST_RATE_PREV3 = _originalConst_rate_prev3;
			CONST_RATE_PREV4 = _originalConst_rate_prev4;
			CONST_RATE_PREV5 = _originalConst_rate_prev5;
			CONST_RATE_PREV6 = _originalConst_rate_prev6;
			CONST_RATE_PREV7 = _originalConst_rate_prev7;
			CONST_RATE_PREV8 = _originalConst_rate_prev8;
			CONST_RATE_PREV9 = _originalConst_rate_prev9;
			CONST_RATE_PREV10 = _originalConst_rate_prev10;
			CONST_RATE_PREV11 = _originalConst_rate_prev11;
			CONST_RATE_PREV12 = _originalConst_rate_prev12;
			CONST_RATE_PREV13 = _originalConst_rate_prev13;
			CONST_RATE_PREV14 = _originalConst_rate_prev14;
			CONST_RATE_PREV15 = _originalConst_rate_prev15;
			CONST_RATE_PREV16 = _originalConst_rate_prev16;
			CONST_RATE_PREV17 = _originalConst_rate_prev17;
			CONST_RATE_PREV18 = _originalConst_rate_prev18;
			CONST_RATE_PREV19 = _originalConst_rate_prev19;
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
					new SqlParameter("CONST_REC_NBR",CONST_REC_NBR)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_Purge]");
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
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("CONST_YY_CURR", SqlNull(CONST_YY_CURR)),
						new SqlParameter("CONST_MM_CURR", SqlNull(CONST_MM_CURR)),
						new SqlParameter("CONST_DD_CURR", SqlNull(CONST_DD_CURR)),
						new SqlParameter("CONST_BILATERAL_CURR", SqlNull(CONST_BILATERAL_CURR)),
						new SqlParameter("CONST_IC_CURR", SqlNull(CONST_IC_CURR)),
						new SqlParameter("CONST_SR_CURR", SqlNull(CONST_SR_CURR)),
						new SqlParameter("CONST_WCB_CURR", SqlNull(CONST_WCB_CURR)),
						new SqlParameter("CONST_ASST_H_CURR", SqlNull(CONST_ASST_H_CURR)),
						new SqlParameter("CONST_REG_H_CURR", SqlNull(CONST_REG_H_CURR)),
						new SqlParameter("CONST_CERT_H_CURR", SqlNull(CONST_CERT_H_CURR)),
						new SqlParameter("CONST_ASST_A_CURR", SqlNull(CONST_ASST_A_CURR)),
						new SqlParameter("CONST_REG_A_CURR", SqlNull(CONST_REG_A_CURR)),
						new SqlParameter("CONST_CERT_A_CURR", SqlNull(CONST_CERT_A_CURR)),
						new SqlParameter("CONST_YY_PREV", SqlNull(CONST_YY_PREV)),
						new SqlParameter("CONST_MM_PREV", SqlNull(CONST_MM_PREV)),
						new SqlParameter("CONST_DD_PREV", SqlNull(CONST_DD_PREV)),
						new SqlParameter("CONST_BILATERAL_PREV", SqlNull(CONST_BILATERAL_PREV)),
						new SqlParameter("CONST_IC_PREV", SqlNull(CONST_IC_PREV)),
						new SqlParameter("CONST_SR_PREV", SqlNull(CONST_SR_PREV)),
						new SqlParameter("CONST_WCB_PREV", SqlNull(CONST_WCB_PREV)),
						new SqlParameter("CONST_ASST_H_PREV", SqlNull(CONST_ASST_H_PREV)),
						new SqlParameter("CONST_REG_H_PREV", SqlNull(CONST_REG_H_PREV)),
						new SqlParameter("CONST_CERT_H_PREV", SqlNull(CONST_CERT_H_PREV)),
						new SqlParameter("CONST_ASST_A_PREV", SqlNull(CONST_ASST_A_PREV)),
						new SqlParameter("CONST_REG_A_PREV", SqlNull(CONST_REG_A_PREV)),
						new SqlParameter("CONST_CERT_A_PREV", SqlNull(CONST_CERT_A_PREV)),
						new SqlParameter("CONST_MAX_NBR_RATES", SqlNull(CONST_MAX_NBR_RATES)),
						new SqlParameter("CONST_SECTION1", SqlNull(CONST_SECTION1)),
						new SqlParameter("CONST_SECTION2", SqlNull(CONST_SECTION2)),
						new SqlParameter("CONST_SECTION3", SqlNull(CONST_SECTION3)),
						new SqlParameter("CONST_SECTION4", SqlNull(CONST_SECTION4)),
						new SqlParameter("CONST_SECTION5", SqlNull(CONST_SECTION5)),
						new SqlParameter("CONST_SECTION6", SqlNull(CONST_SECTION6)),
						new SqlParameter("CONST_SECTION7", SqlNull(CONST_SECTION7)),
						new SqlParameter("CONST_SECTION8", SqlNull(CONST_SECTION8)),
						new SqlParameter("CONST_SECTION9", SqlNull(CONST_SECTION9)),
						new SqlParameter("CONST_SECTION10", SqlNull(CONST_SECTION10)),
						new SqlParameter("CONST_SECTION11", SqlNull(CONST_SECTION11)),
						new SqlParameter("CONST_SECTION12", SqlNull(CONST_SECTION12)),
						new SqlParameter("CONST_SECTION13", SqlNull(CONST_SECTION13)),
						new SqlParameter("CONST_SECTION14", SqlNull(CONST_SECTION14)),
						new SqlParameter("CONST_SECTION15", SqlNull(CONST_SECTION15)),
						new SqlParameter("CONST_SECTION16", SqlNull(CONST_SECTION16)),
						new SqlParameter("CONST_SECTION17", SqlNull(CONST_SECTION17)),
						new SqlParameter("CONST_SECTION18", SqlNull(CONST_SECTION18)),
						new SqlParameter("CONST_SECTION19", SqlNull(CONST_SECTION19)),
						new SqlParameter("CONST_GROUP1", SqlNull(CONST_GROUP1)),
						new SqlParameter("CONST_GROUP2", SqlNull(CONST_GROUP2)),
						new SqlParameter("CONST_GROUP3", SqlNull(CONST_GROUP3)),
						new SqlParameter("CONST_GROUP4", SqlNull(CONST_GROUP4)),
						new SqlParameter("CONST_GROUP5", SqlNull(CONST_GROUP5)),
						new SqlParameter("CONST_GROUP6", SqlNull(CONST_GROUP6)),
						new SqlParameter("CONST_GROUP7", SqlNull(CONST_GROUP7)),
						new SqlParameter("CONST_GROUP8", SqlNull(CONST_GROUP8)),
						new SqlParameter("CONST_GROUP9", SqlNull(CONST_GROUP9)),
						new SqlParameter("CONST_GROUP10", SqlNull(CONST_GROUP10)),
						new SqlParameter("CONST_GROUP11", SqlNull(CONST_GROUP11)),
						new SqlParameter("CONST_GROUP12", SqlNull(CONST_GROUP12)),
						new SqlParameter("CONST_GROUP13", SqlNull(CONST_GROUP13)),
						new SqlParameter("CONST_GROUP14", SqlNull(CONST_GROUP14)),
						new SqlParameter("CONST_GROUP15", SqlNull(CONST_GROUP15)),
						new SqlParameter("CONST_GROUP16", SqlNull(CONST_GROUP16)),
						new SqlParameter("CONST_GROUP17", SqlNull(CONST_GROUP17)),
						new SqlParameter("CONST_GROUP18", SqlNull(CONST_GROUP18)),
						new SqlParameter("CONST_GROUP19", SqlNull(CONST_GROUP19)),
						new SqlParameter("CONST_RATE_CURR1", SqlNull(CONST_RATE_CURR1)),
						new SqlParameter("CONST_RATE_CURR2", SqlNull(CONST_RATE_CURR2)),
						new SqlParameter("CONST_RATE_CURR3", SqlNull(CONST_RATE_CURR3)),
						new SqlParameter("CONST_RATE_CURR4", SqlNull(CONST_RATE_CURR4)),
						new SqlParameter("CONST_RATE_CURR5", SqlNull(CONST_RATE_CURR5)),
						new SqlParameter("CONST_RATE_CURR6", SqlNull(CONST_RATE_CURR6)),
						new SqlParameter("CONST_RATE_CURR7", SqlNull(CONST_RATE_CURR7)),
						new SqlParameter("CONST_RATE_CURR8", SqlNull(CONST_RATE_CURR8)),
						new SqlParameter("CONST_RATE_CURR9", SqlNull(CONST_RATE_CURR9)),
						new SqlParameter("CONST_RATE_CURR10", SqlNull(CONST_RATE_CURR10)),
						new SqlParameter("CONST_RATE_CURR11", SqlNull(CONST_RATE_CURR11)),
						new SqlParameter("CONST_RATE_CURR12", SqlNull(CONST_RATE_CURR12)),
						new SqlParameter("CONST_RATE_CURR13", SqlNull(CONST_RATE_CURR13)),
						new SqlParameter("CONST_RATE_CURR14", SqlNull(CONST_RATE_CURR14)),
						new SqlParameter("CONST_RATE_CURR15", SqlNull(CONST_RATE_CURR15)),
						new SqlParameter("CONST_RATE_CURR16", SqlNull(CONST_RATE_CURR16)),
						new SqlParameter("CONST_RATE_CURR17", SqlNull(CONST_RATE_CURR17)),
						new SqlParameter("CONST_RATE_CURR18", SqlNull(CONST_RATE_CURR18)),
						new SqlParameter("CONST_RATE_CURR19", SqlNull(CONST_RATE_CURR19)),
						new SqlParameter("CONST_RATE_PREV1", SqlNull(CONST_RATE_PREV1)),
						new SqlParameter("CONST_RATE_PREV2", SqlNull(CONST_RATE_PREV2)),
						new SqlParameter("CONST_RATE_PREV3", SqlNull(CONST_RATE_PREV3)),
						new SqlParameter("CONST_RATE_PREV4", SqlNull(CONST_RATE_PREV4)),
						new SqlParameter("CONST_RATE_PREV5", SqlNull(CONST_RATE_PREV5)),
						new SqlParameter("CONST_RATE_PREV6", SqlNull(CONST_RATE_PREV6)),
						new SqlParameter("CONST_RATE_PREV7", SqlNull(CONST_RATE_PREV7)),
						new SqlParameter("CONST_RATE_PREV8", SqlNull(CONST_RATE_PREV8)),
						new SqlParameter("CONST_RATE_PREV9", SqlNull(CONST_RATE_PREV9)),
						new SqlParameter("CONST_RATE_PREV10", SqlNull(CONST_RATE_PREV10)),
						new SqlParameter("CONST_RATE_PREV11", SqlNull(CONST_RATE_PREV11)),
						new SqlParameter("CONST_RATE_PREV12", SqlNull(CONST_RATE_PREV12)),
						new SqlParameter("CONST_RATE_PREV13", SqlNull(CONST_RATE_PREV13)),
						new SqlParameter("CONST_RATE_PREV14", SqlNull(CONST_RATE_PREV14)),
						new SqlParameter("CONST_RATE_PREV15", SqlNull(CONST_RATE_PREV15)),
						new SqlParameter("CONST_RATE_PREV16", SqlNull(CONST_RATE_PREV16)),
						new SqlParameter("CONST_RATE_PREV17", SqlNull(CONST_RATE_PREV17)),
						new SqlParameter("CONST_RATE_PREV18", SqlNull(CONST_RATE_PREV18)),
						new SqlParameter("CONST_RATE_PREV19", SqlNull(CONST_RATE_PREV19)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_YY_CURR = ConvertDEC(Reader["CONST_YY_CURR"]);
						CONST_MM_CURR = ConvertDEC(Reader["CONST_MM_CURR"]);
						CONST_DD_CURR = ConvertDEC(Reader["CONST_DD_CURR"]);
						CONST_BILATERAL_CURR = ConvertDEC(Reader["CONST_BILATERAL_CURR"]);
						CONST_IC_CURR = ConvertDEC(Reader["CONST_IC_CURR"]);
						CONST_SR_CURR = ConvertDEC(Reader["CONST_SR_CURR"]);
						CONST_WCB_CURR = ConvertDEC(Reader["CONST_WCB_CURR"]);
						CONST_ASST_H_CURR = ConvertDEC(Reader["CONST_ASST_H_CURR"]);
						CONST_REG_H_CURR = ConvertDEC(Reader["CONST_REG_H_CURR"]);
						CONST_CERT_H_CURR = ConvertDEC(Reader["CONST_CERT_H_CURR"]);
						CONST_ASST_A_CURR = ConvertDEC(Reader["CONST_ASST_A_CURR"]);
						CONST_REG_A_CURR = ConvertDEC(Reader["CONST_REG_A_CURR"]);
						CONST_CERT_A_CURR = ConvertDEC(Reader["CONST_CERT_A_CURR"]);
						CONST_YY_PREV = ConvertDEC(Reader["CONST_YY_PREV"]);
						CONST_MM_PREV = ConvertDEC(Reader["CONST_MM_PREV"]);
						CONST_DD_PREV = ConvertDEC(Reader["CONST_DD_PREV"]);
						CONST_BILATERAL_PREV = ConvertDEC(Reader["CONST_BILATERAL_PREV"]);
						CONST_IC_PREV = ConvertDEC(Reader["CONST_IC_PREV"]);
						CONST_SR_PREV = ConvertDEC(Reader["CONST_SR_PREV"]);
						CONST_WCB_PREV = ConvertDEC(Reader["CONST_WCB_PREV"]);
						CONST_ASST_H_PREV = ConvertDEC(Reader["CONST_ASST_H_PREV"]);
						CONST_REG_H_PREV = ConvertDEC(Reader["CONST_REG_H_PREV"]);
						CONST_CERT_H_PREV = ConvertDEC(Reader["CONST_CERT_H_PREV"]);
						CONST_ASST_A_PREV = ConvertDEC(Reader["CONST_ASST_A_PREV"]);
						CONST_REG_A_PREV = ConvertDEC(Reader["CONST_REG_A_PREV"]);
						CONST_CERT_A_PREV = ConvertDEC(Reader["CONST_CERT_A_PREV"]);
						CONST_MAX_NBR_RATES = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]);
						CONST_SECTION1 = Reader["CONST_SECTION1"].ToString();
						CONST_SECTION2 = Reader["CONST_SECTION2"].ToString();
						CONST_SECTION3 = Reader["CONST_SECTION3"].ToString();
						CONST_SECTION4 = Reader["CONST_SECTION4"].ToString();
						CONST_SECTION5 = Reader["CONST_SECTION5"].ToString();
						CONST_SECTION6 = Reader["CONST_SECTION6"].ToString();
						CONST_SECTION7 = Reader["CONST_SECTION7"].ToString();
						CONST_SECTION8 = Reader["CONST_SECTION8"].ToString();
						CONST_SECTION9 = Reader["CONST_SECTION9"].ToString();
						CONST_SECTION10 = Reader["CONST_SECTION10"].ToString();
						CONST_SECTION11 = Reader["CONST_SECTION11"].ToString();
						CONST_SECTION12 = Reader["CONST_SECTION12"].ToString();
						CONST_SECTION13 = Reader["CONST_SECTION13"].ToString();
						CONST_SECTION14 = Reader["CONST_SECTION14"].ToString();
						CONST_SECTION15 = Reader["CONST_SECTION15"].ToString();
						CONST_SECTION16 = Reader["CONST_SECTION16"].ToString();
						CONST_SECTION17 = Reader["CONST_SECTION17"].ToString();
						CONST_SECTION18 = Reader["CONST_SECTION18"].ToString();
						CONST_SECTION19 = Reader["CONST_SECTION19"].ToString();
						CONST_GROUP1 = ConvertDEC(Reader["CONST_GROUP1"]);
						CONST_GROUP2 = ConvertDEC(Reader["CONST_GROUP2"]);
						CONST_GROUP3 = ConvertDEC(Reader["CONST_GROUP3"]);
						CONST_GROUP4 = ConvertDEC(Reader["CONST_GROUP4"]);
						CONST_GROUP5 = ConvertDEC(Reader["CONST_GROUP5"]);
						CONST_GROUP6 = ConvertDEC(Reader["CONST_GROUP6"]);
						CONST_GROUP7 = ConvertDEC(Reader["CONST_GROUP7"]);
						CONST_GROUP8 = ConvertDEC(Reader["CONST_GROUP8"]);
						CONST_GROUP9 = ConvertDEC(Reader["CONST_GROUP9"]);
						CONST_GROUP10 = ConvertDEC(Reader["CONST_GROUP10"]);
						CONST_GROUP11 = ConvertDEC(Reader["CONST_GROUP11"]);
						CONST_GROUP12 = ConvertDEC(Reader["CONST_GROUP12"]);
						CONST_GROUP13 = ConvertDEC(Reader["CONST_GROUP13"]);
						CONST_GROUP14 = ConvertDEC(Reader["CONST_GROUP14"]);
						CONST_GROUP15 = ConvertDEC(Reader["CONST_GROUP15"]);
						CONST_GROUP16 = ConvertDEC(Reader["CONST_GROUP16"]);
						CONST_GROUP17 = ConvertDEC(Reader["CONST_GROUP17"]);
						CONST_GROUP18 = ConvertDEC(Reader["CONST_GROUP18"]);
						CONST_GROUP19 = ConvertDEC(Reader["CONST_GROUP19"]);
						CONST_RATE_CURR1 = ConvertDEC(Reader["CONST_RATE_CURR1"]);
						CONST_RATE_CURR2 = ConvertDEC(Reader["CONST_RATE_CURR2"]);
						CONST_RATE_CURR3 = ConvertDEC(Reader["CONST_RATE_CURR3"]);
						CONST_RATE_CURR4 = ConvertDEC(Reader["CONST_RATE_CURR4"]);
						CONST_RATE_CURR5 = ConvertDEC(Reader["CONST_RATE_CURR5"]);
						CONST_RATE_CURR6 = ConvertDEC(Reader["CONST_RATE_CURR6"]);
						CONST_RATE_CURR7 = ConvertDEC(Reader["CONST_RATE_CURR7"]);
						CONST_RATE_CURR8 = ConvertDEC(Reader["CONST_RATE_CURR8"]);
						CONST_RATE_CURR9 = ConvertDEC(Reader["CONST_RATE_CURR9"]);
						CONST_RATE_CURR10 = ConvertDEC(Reader["CONST_RATE_CURR10"]);
						CONST_RATE_CURR11 = ConvertDEC(Reader["CONST_RATE_CURR11"]);
						CONST_RATE_CURR12 = ConvertDEC(Reader["CONST_RATE_CURR12"]);
						CONST_RATE_CURR13 = ConvertDEC(Reader["CONST_RATE_CURR13"]);
						CONST_RATE_CURR14 = ConvertDEC(Reader["CONST_RATE_CURR14"]);
						CONST_RATE_CURR15 = ConvertDEC(Reader["CONST_RATE_CURR15"]);
						CONST_RATE_CURR16 = ConvertDEC(Reader["CONST_RATE_CURR16"]);
						CONST_RATE_CURR17 = ConvertDEC(Reader["CONST_RATE_CURR17"]);
						CONST_RATE_CURR18 = ConvertDEC(Reader["CONST_RATE_CURR18"]);
						CONST_RATE_CURR19 = ConvertDEC(Reader["CONST_RATE_CURR19"]);
						CONST_RATE_PREV1 = ConvertDEC(Reader["CONST_RATE_PREV1"]);
						CONST_RATE_PREV2 = ConvertDEC(Reader["CONST_RATE_PREV2"]);
						CONST_RATE_PREV3 = ConvertDEC(Reader["CONST_RATE_PREV3"]);
						CONST_RATE_PREV4 = ConvertDEC(Reader["CONST_RATE_PREV4"]);
						CONST_RATE_PREV5 = ConvertDEC(Reader["CONST_RATE_PREV5"]);
						CONST_RATE_PREV6 = ConvertDEC(Reader["CONST_RATE_PREV6"]);
						CONST_RATE_PREV7 = ConvertDEC(Reader["CONST_RATE_PREV7"]);
						CONST_RATE_PREV8 = ConvertDEC(Reader["CONST_RATE_PREV8"]);
						CONST_RATE_PREV9 = ConvertDEC(Reader["CONST_RATE_PREV9"]);
						CONST_RATE_PREV10 = ConvertDEC(Reader["CONST_RATE_PREV10"]);
						CONST_RATE_PREV11 = ConvertDEC(Reader["CONST_RATE_PREV11"]);
						CONST_RATE_PREV12 = ConvertDEC(Reader["CONST_RATE_PREV12"]);
						CONST_RATE_PREV13 = ConvertDEC(Reader["CONST_RATE_PREV13"]);
						CONST_RATE_PREV14 = ConvertDEC(Reader["CONST_RATE_PREV14"]);
						CONST_RATE_PREV15 = ConvertDEC(Reader["CONST_RATE_PREV15"]);
						CONST_RATE_PREV16 = ConvertDEC(Reader["CONST_RATE_PREV16"]);
						CONST_RATE_PREV17 = ConvertDEC(Reader["CONST_RATE_PREV17"]);
						CONST_RATE_PREV18 = ConvertDEC(Reader["CONST_RATE_PREV18"]);
						CONST_RATE_PREV19 = ConvertDEC(Reader["CONST_RATE_PREV19"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_yy_curr = ConvertDEC(Reader["CONST_YY_CURR"]);
						_originalConst_mm_curr = ConvertDEC(Reader["CONST_MM_CURR"]);
						_originalConst_dd_curr = ConvertDEC(Reader["CONST_DD_CURR"]);
						_originalConst_bilateral_curr = ConvertDEC(Reader["CONST_BILATERAL_CURR"]);
						_originalConst_ic_curr = ConvertDEC(Reader["CONST_IC_CURR"]);
						_originalConst_sr_curr = ConvertDEC(Reader["CONST_SR_CURR"]);
						_originalConst_wcb_curr = ConvertDEC(Reader["CONST_WCB_CURR"]);
						_originalConst_asst_h_curr = ConvertDEC(Reader["CONST_ASST_H_CURR"]);
						_originalConst_reg_h_curr = ConvertDEC(Reader["CONST_REG_H_CURR"]);
						_originalConst_cert_h_curr = ConvertDEC(Reader["CONST_CERT_H_CURR"]);
						_originalConst_asst_a_curr = ConvertDEC(Reader["CONST_ASST_A_CURR"]);
						_originalConst_reg_a_curr = ConvertDEC(Reader["CONST_REG_A_CURR"]);
						_originalConst_cert_a_curr = ConvertDEC(Reader["CONST_CERT_A_CURR"]);
						_originalConst_yy_prev = ConvertDEC(Reader["CONST_YY_PREV"]);
						_originalConst_mm_prev = ConvertDEC(Reader["CONST_MM_PREV"]);
						_originalConst_dd_prev = ConvertDEC(Reader["CONST_DD_PREV"]);
						_originalConst_bilateral_prev = ConvertDEC(Reader["CONST_BILATERAL_PREV"]);
						_originalConst_ic_prev = ConvertDEC(Reader["CONST_IC_PREV"]);
						_originalConst_sr_prev = ConvertDEC(Reader["CONST_SR_PREV"]);
						_originalConst_wcb_prev = ConvertDEC(Reader["CONST_WCB_PREV"]);
						_originalConst_asst_h_prev = ConvertDEC(Reader["CONST_ASST_H_PREV"]);
						_originalConst_reg_h_prev = ConvertDEC(Reader["CONST_REG_H_PREV"]);
						_originalConst_cert_h_prev = ConvertDEC(Reader["CONST_CERT_H_PREV"]);
						_originalConst_asst_a_prev = ConvertDEC(Reader["CONST_ASST_A_PREV"]);
						_originalConst_reg_a_prev = ConvertDEC(Reader["CONST_REG_A_PREV"]);
						_originalConst_cert_a_prev = ConvertDEC(Reader["CONST_CERT_A_PREV"]);
						_originalConst_max_nbr_rates = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]);
						_originalConst_section1 = Reader["CONST_SECTION1"].ToString();
						_originalConst_section2 = Reader["CONST_SECTION2"].ToString();
						_originalConst_section3 = Reader["CONST_SECTION3"].ToString();
						_originalConst_section4 = Reader["CONST_SECTION4"].ToString();
						_originalConst_section5 = Reader["CONST_SECTION5"].ToString();
						_originalConst_section6 = Reader["CONST_SECTION6"].ToString();
						_originalConst_section7 = Reader["CONST_SECTION7"].ToString();
						_originalConst_section8 = Reader["CONST_SECTION8"].ToString();
						_originalConst_section9 = Reader["CONST_SECTION9"].ToString();
						_originalConst_section10 = Reader["CONST_SECTION10"].ToString();
						_originalConst_section11 = Reader["CONST_SECTION11"].ToString();
						_originalConst_section12 = Reader["CONST_SECTION12"].ToString();
						_originalConst_section13 = Reader["CONST_SECTION13"].ToString();
						_originalConst_section14 = Reader["CONST_SECTION14"].ToString();
						_originalConst_section15 = Reader["CONST_SECTION15"].ToString();
						_originalConst_section16 = Reader["CONST_SECTION16"].ToString();
						_originalConst_section17 = Reader["CONST_SECTION17"].ToString();
						_originalConst_section18 = Reader["CONST_SECTION18"].ToString();
						_originalConst_section19 = Reader["CONST_SECTION19"].ToString();
						_originalConst_group1 = ConvertDEC(Reader["CONST_GROUP1"]);
						_originalConst_group2 = ConvertDEC(Reader["CONST_GROUP2"]);
						_originalConst_group3 = ConvertDEC(Reader["CONST_GROUP3"]);
						_originalConst_group4 = ConvertDEC(Reader["CONST_GROUP4"]);
						_originalConst_group5 = ConvertDEC(Reader["CONST_GROUP5"]);
						_originalConst_group6 = ConvertDEC(Reader["CONST_GROUP6"]);
						_originalConst_group7 = ConvertDEC(Reader["CONST_GROUP7"]);
						_originalConst_group8 = ConvertDEC(Reader["CONST_GROUP8"]);
						_originalConst_group9 = ConvertDEC(Reader["CONST_GROUP9"]);
						_originalConst_group10 = ConvertDEC(Reader["CONST_GROUP10"]);
						_originalConst_group11 = ConvertDEC(Reader["CONST_GROUP11"]);
						_originalConst_group12 = ConvertDEC(Reader["CONST_GROUP12"]);
						_originalConst_group13 = ConvertDEC(Reader["CONST_GROUP13"]);
						_originalConst_group14 = ConvertDEC(Reader["CONST_GROUP14"]);
						_originalConst_group15 = ConvertDEC(Reader["CONST_GROUP15"]);
						_originalConst_group16 = ConvertDEC(Reader["CONST_GROUP16"]);
						_originalConst_group17 = ConvertDEC(Reader["CONST_GROUP17"]);
						_originalConst_group18 = ConvertDEC(Reader["CONST_GROUP18"]);
						_originalConst_group19 = ConvertDEC(Reader["CONST_GROUP19"]);
						_originalConst_rate_curr1 = ConvertDEC(Reader["CONST_RATE_CURR1"]);
						_originalConst_rate_curr2 = ConvertDEC(Reader["CONST_RATE_CURR2"]);
						_originalConst_rate_curr3 = ConvertDEC(Reader["CONST_RATE_CURR3"]);
						_originalConst_rate_curr4 = ConvertDEC(Reader["CONST_RATE_CURR4"]);
						_originalConst_rate_curr5 = ConvertDEC(Reader["CONST_RATE_CURR5"]);
						_originalConst_rate_curr6 = ConvertDEC(Reader["CONST_RATE_CURR6"]);
						_originalConst_rate_curr7 = ConvertDEC(Reader["CONST_RATE_CURR7"]);
						_originalConst_rate_curr8 = ConvertDEC(Reader["CONST_RATE_CURR8"]);
						_originalConst_rate_curr9 = ConvertDEC(Reader["CONST_RATE_CURR9"]);
						_originalConst_rate_curr10 = ConvertDEC(Reader["CONST_RATE_CURR10"]);
						_originalConst_rate_curr11 = ConvertDEC(Reader["CONST_RATE_CURR11"]);
						_originalConst_rate_curr12 = ConvertDEC(Reader["CONST_RATE_CURR12"]);
						_originalConst_rate_curr13 = ConvertDEC(Reader["CONST_RATE_CURR13"]);
						_originalConst_rate_curr14 = ConvertDEC(Reader["CONST_RATE_CURR14"]);
						_originalConst_rate_curr15 = ConvertDEC(Reader["CONST_RATE_CURR15"]);
						_originalConst_rate_curr16 = ConvertDEC(Reader["CONST_RATE_CURR16"]);
						_originalConst_rate_curr17 = ConvertDEC(Reader["CONST_RATE_CURR17"]);
						_originalConst_rate_curr18 = ConvertDEC(Reader["CONST_RATE_CURR18"]);
						_originalConst_rate_curr19 = ConvertDEC(Reader["CONST_RATE_CURR19"]);
						_originalConst_rate_prev1 = ConvertDEC(Reader["CONST_RATE_PREV1"]);
						_originalConst_rate_prev2 = ConvertDEC(Reader["CONST_RATE_PREV2"]);
						_originalConst_rate_prev3 = ConvertDEC(Reader["CONST_RATE_PREV3"]);
						_originalConst_rate_prev4 = ConvertDEC(Reader["CONST_RATE_PREV4"]);
						_originalConst_rate_prev5 = ConvertDEC(Reader["CONST_RATE_PREV5"]);
						_originalConst_rate_prev6 = ConvertDEC(Reader["CONST_RATE_PREV6"]);
						_originalConst_rate_prev7 = ConvertDEC(Reader["CONST_RATE_PREV7"]);
						_originalConst_rate_prev8 = ConvertDEC(Reader["CONST_RATE_PREV8"]);
						_originalConst_rate_prev9 = ConvertDEC(Reader["CONST_RATE_PREV9"]);
						_originalConst_rate_prev10 = ConvertDEC(Reader["CONST_RATE_PREV10"]);
						_originalConst_rate_prev11 = ConvertDEC(Reader["CONST_RATE_PREV11"]);
						_originalConst_rate_prev12 = ConvertDEC(Reader["CONST_RATE_PREV12"]);
						_originalConst_rate_prev13 = ConvertDEC(Reader["CONST_RATE_PREV13"]);
						_originalConst_rate_prev14 = ConvertDEC(Reader["CONST_RATE_PREV14"]);
						_originalConst_rate_prev15 = ConvertDEC(Reader["CONST_RATE_PREV15"]);
						_originalConst_rate_prev16 = ConvertDEC(Reader["CONST_RATE_PREV16"]);
						_originalConst_rate_prev17 = ConvertDEC(Reader["CONST_RATE_PREV17"]);
						_originalConst_rate_prev18 = ConvertDEC(Reader["CONST_RATE_PREV18"]);
						_originalConst_rate_prev19 = ConvertDEC(Reader["CONST_RATE_PREV19"]);
						_originalFiller = Reader["FILLER"].ToString();
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("CONST_REC_NBR", SqlNull(CONST_REC_NBR)),
						new SqlParameter("CONST_YY_CURR", SqlNull(CONST_YY_CURR)),
						new SqlParameter("CONST_MM_CURR", SqlNull(CONST_MM_CURR)),
						new SqlParameter("CONST_DD_CURR", SqlNull(CONST_DD_CURR)),
						new SqlParameter("CONST_BILATERAL_CURR", SqlNull(CONST_BILATERAL_CURR)),
						new SqlParameter("CONST_IC_CURR", SqlNull(CONST_IC_CURR)),
						new SqlParameter("CONST_SR_CURR", SqlNull(CONST_SR_CURR)),
						new SqlParameter("CONST_WCB_CURR", SqlNull(CONST_WCB_CURR)),
						new SqlParameter("CONST_ASST_H_CURR", SqlNull(CONST_ASST_H_CURR)),
						new SqlParameter("CONST_REG_H_CURR", SqlNull(CONST_REG_H_CURR)),
						new SqlParameter("CONST_CERT_H_CURR", SqlNull(CONST_CERT_H_CURR)),
						new SqlParameter("CONST_ASST_A_CURR", SqlNull(CONST_ASST_A_CURR)),
						new SqlParameter("CONST_REG_A_CURR", SqlNull(CONST_REG_A_CURR)),
						new SqlParameter("CONST_CERT_A_CURR", SqlNull(CONST_CERT_A_CURR)),
						new SqlParameter("CONST_YY_PREV", SqlNull(CONST_YY_PREV)),
						new SqlParameter("CONST_MM_PREV", SqlNull(CONST_MM_PREV)),
						new SqlParameter("CONST_DD_PREV", SqlNull(CONST_DD_PREV)),
						new SqlParameter("CONST_BILATERAL_PREV", SqlNull(CONST_BILATERAL_PREV)),
						new SqlParameter("CONST_IC_PREV", SqlNull(CONST_IC_PREV)),
						new SqlParameter("CONST_SR_PREV", SqlNull(CONST_SR_PREV)),
						new SqlParameter("CONST_WCB_PREV", SqlNull(CONST_WCB_PREV)),
						new SqlParameter("CONST_ASST_H_PREV", SqlNull(CONST_ASST_H_PREV)),
						new SqlParameter("CONST_REG_H_PREV", SqlNull(CONST_REG_H_PREV)),
						new SqlParameter("CONST_CERT_H_PREV", SqlNull(CONST_CERT_H_PREV)),
						new SqlParameter("CONST_ASST_A_PREV", SqlNull(CONST_ASST_A_PREV)),
						new SqlParameter("CONST_REG_A_PREV", SqlNull(CONST_REG_A_PREV)),
						new SqlParameter("CONST_CERT_A_PREV", SqlNull(CONST_CERT_A_PREV)),
						new SqlParameter("CONST_MAX_NBR_RATES", SqlNull(CONST_MAX_NBR_RATES)),
						new SqlParameter("CONST_SECTION1", SqlNull(CONST_SECTION1)),
						new SqlParameter("CONST_SECTION2", SqlNull(CONST_SECTION2)),
						new SqlParameter("CONST_SECTION3", SqlNull(CONST_SECTION3)),
						new SqlParameter("CONST_SECTION4", SqlNull(CONST_SECTION4)),
						new SqlParameter("CONST_SECTION5", SqlNull(CONST_SECTION5)),
						new SqlParameter("CONST_SECTION6", SqlNull(CONST_SECTION6)),
						new SqlParameter("CONST_SECTION7", SqlNull(CONST_SECTION7)),
						new SqlParameter("CONST_SECTION8", SqlNull(CONST_SECTION8)),
						new SqlParameter("CONST_SECTION9", SqlNull(CONST_SECTION9)),
						new SqlParameter("CONST_SECTION10", SqlNull(CONST_SECTION10)),
						new SqlParameter("CONST_SECTION11", SqlNull(CONST_SECTION11)),
						new SqlParameter("CONST_SECTION12", SqlNull(CONST_SECTION12)),
						new SqlParameter("CONST_SECTION13", SqlNull(CONST_SECTION13)),
						new SqlParameter("CONST_SECTION14", SqlNull(CONST_SECTION14)),
						new SqlParameter("CONST_SECTION15", SqlNull(CONST_SECTION15)),
						new SqlParameter("CONST_SECTION16", SqlNull(CONST_SECTION16)),
						new SqlParameter("CONST_SECTION17", SqlNull(CONST_SECTION17)),
						new SqlParameter("CONST_SECTION18", SqlNull(CONST_SECTION18)),
						new SqlParameter("CONST_SECTION19", SqlNull(CONST_SECTION19)),
						new SqlParameter("CONST_GROUP1", SqlNull(CONST_GROUP1)),
						new SqlParameter("CONST_GROUP2", SqlNull(CONST_GROUP2)),
						new SqlParameter("CONST_GROUP3", SqlNull(CONST_GROUP3)),
						new SqlParameter("CONST_GROUP4", SqlNull(CONST_GROUP4)),
						new SqlParameter("CONST_GROUP5", SqlNull(CONST_GROUP5)),
						new SqlParameter("CONST_GROUP6", SqlNull(CONST_GROUP6)),
						new SqlParameter("CONST_GROUP7", SqlNull(CONST_GROUP7)),
						new SqlParameter("CONST_GROUP8", SqlNull(CONST_GROUP8)),
						new SqlParameter("CONST_GROUP9", SqlNull(CONST_GROUP9)),
						new SqlParameter("CONST_GROUP10", SqlNull(CONST_GROUP10)),
						new SqlParameter("CONST_GROUP11", SqlNull(CONST_GROUP11)),
						new SqlParameter("CONST_GROUP12", SqlNull(CONST_GROUP12)),
						new SqlParameter("CONST_GROUP13", SqlNull(CONST_GROUP13)),
						new SqlParameter("CONST_GROUP14", SqlNull(CONST_GROUP14)),
						new SqlParameter("CONST_GROUP15", SqlNull(CONST_GROUP15)),
						new SqlParameter("CONST_GROUP16", SqlNull(CONST_GROUP16)),
						new SqlParameter("CONST_GROUP17", SqlNull(CONST_GROUP17)),
						new SqlParameter("CONST_GROUP18", SqlNull(CONST_GROUP18)),
						new SqlParameter("CONST_GROUP19", SqlNull(CONST_GROUP19)),
						new SqlParameter("CONST_RATE_CURR1", SqlNull(CONST_RATE_CURR1)),
						new SqlParameter("CONST_RATE_CURR2", SqlNull(CONST_RATE_CURR2)),
						new SqlParameter("CONST_RATE_CURR3", SqlNull(CONST_RATE_CURR3)),
						new SqlParameter("CONST_RATE_CURR4", SqlNull(CONST_RATE_CURR4)),
						new SqlParameter("CONST_RATE_CURR5", SqlNull(CONST_RATE_CURR5)),
						new SqlParameter("CONST_RATE_CURR6", SqlNull(CONST_RATE_CURR6)),
						new SqlParameter("CONST_RATE_CURR7", SqlNull(CONST_RATE_CURR7)),
						new SqlParameter("CONST_RATE_CURR8", SqlNull(CONST_RATE_CURR8)),
						new SqlParameter("CONST_RATE_CURR9", SqlNull(CONST_RATE_CURR9)),
						new SqlParameter("CONST_RATE_CURR10", SqlNull(CONST_RATE_CURR10)),
						new SqlParameter("CONST_RATE_CURR11", SqlNull(CONST_RATE_CURR11)),
						new SqlParameter("CONST_RATE_CURR12", SqlNull(CONST_RATE_CURR12)),
						new SqlParameter("CONST_RATE_CURR13", SqlNull(CONST_RATE_CURR13)),
						new SqlParameter("CONST_RATE_CURR14", SqlNull(CONST_RATE_CURR14)),
						new SqlParameter("CONST_RATE_CURR15", SqlNull(CONST_RATE_CURR15)),
						new SqlParameter("CONST_RATE_CURR16", SqlNull(CONST_RATE_CURR16)),
						new SqlParameter("CONST_RATE_CURR17", SqlNull(CONST_RATE_CURR17)),
						new SqlParameter("CONST_RATE_CURR18", SqlNull(CONST_RATE_CURR18)),
						new SqlParameter("CONST_RATE_CURR19", SqlNull(CONST_RATE_CURR19)),
						new SqlParameter("CONST_RATE_PREV1", SqlNull(CONST_RATE_PREV1)),
						new SqlParameter("CONST_RATE_PREV2", SqlNull(CONST_RATE_PREV2)),
						new SqlParameter("CONST_RATE_PREV3", SqlNull(CONST_RATE_PREV3)),
						new SqlParameter("CONST_RATE_PREV4", SqlNull(CONST_RATE_PREV4)),
						new SqlParameter("CONST_RATE_PREV5", SqlNull(CONST_RATE_PREV5)),
						new SqlParameter("CONST_RATE_PREV6", SqlNull(CONST_RATE_PREV6)),
						new SqlParameter("CONST_RATE_PREV7", SqlNull(CONST_RATE_PREV7)),
						new SqlParameter("CONST_RATE_PREV8", SqlNull(CONST_RATE_PREV8)),
						new SqlParameter("CONST_RATE_PREV9", SqlNull(CONST_RATE_PREV9)),
						new SqlParameter("CONST_RATE_PREV10", SqlNull(CONST_RATE_PREV10)),
						new SqlParameter("CONST_RATE_PREV11", SqlNull(CONST_RATE_PREV11)),
						new SqlParameter("CONST_RATE_PREV12", SqlNull(CONST_RATE_PREV12)),
						new SqlParameter("CONST_RATE_PREV13", SqlNull(CONST_RATE_PREV13)),
						new SqlParameter("CONST_RATE_PREV14", SqlNull(CONST_RATE_PREV14)),
						new SqlParameter("CONST_RATE_PREV15", SqlNull(CONST_RATE_PREV15)),
						new SqlParameter("CONST_RATE_PREV16", SqlNull(CONST_RATE_PREV16)),
						new SqlParameter("CONST_RATE_PREV17", SqlNull(CONST_RATE_PREV17)),
						new SqlParameter("CONST_RATE_PREV18", SqlNull(CONST_RATE_PREV18)),
						new SqlParameter("CONST_RATE_PREV19", SqlNull(CONST_RATE_PREV19)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_2_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_YY_CURR = ConvertDEC(Reader["CONST_YY_CURR"]);
						CONST_MM_CURR = ConvertDEC(Reader["CONST_MM_CURR"]);
						CONST_DD_CURR = ConvertDEC(Reader["CONST_DD_CURR"]);
						CONST_BILATERAL_CURR = ConvertDEC(Reader["CONST_BILATERAL_CURR"]);
						CONST_IC_CURR = ConvertDEC(Reader["CONST_IC_CURR"]);
						CONST_SR_CURR = ConvertDEC(Reader["CONST_SR_CURR"]);
						CONST_WCB_CURR = ConvertDEC(Reader["CONST_WCB_CURR"]);
						CONST_ASST_H_CURR = ConvertDEC(Reader["CONST_ASST_H_CURR"]);
						CONST_REG_H_CURR = ConvertDEC(Reader["CONST_REG_H_CURR"]);
						CONST_CERT_H_CURR = ConvertDEC(Reader["CONST_CERT_H_CURR"]);
						CONST_ASST_A_CURR = ConvertDEC(Reader["CONST_ASST_A_CURR"]);
						CONST_REG_A_CURR = ConvertDEC(Reader["CONST_REG_A_CURR"]);
						CONST_CERT_A_CURR = ConvertDEC(Reader["CONST_CERT_A_CURR"]);
						CONST_YY_PREV = ConvertDEC(Reader["CONST_YY_PREV"]);
						CONST_MM_PREV = ConvertDEC(Reader["CONST_MM_PREV"]);
						CONST_DD_PREV = ConvertDEC(Reader["CONST_DD_PREV"]);
						CONST_BILATERAL_PREV = ConvertDEC(Reader["CONST_BILATERAL_PREV"]);
						CONST_IC_PREV = ConvertDEC(Reader["CONST_IC_PREV"]);
						CONST_SR_PREV = ConvertDEC(Reader["CONST_SR_PREV"]);
						CONST_WCB_PREV = ConvertDEC(Reader["CONST_WCB_PREV"]);
						CONST_ASST_H_PREV = ConvertDEC(Reader["CONST_ASST_H_PREV"]);
						CONST_REG_H_PREV = ConvertDEC(Reader["CONST_REG_H_PREV"]);
						CONST_CERT_H_PREV = ConvertDEC(Reader["CONST_CERT_H_PREV"]);
						CONST_ASST_A_PREV = ConvertDEC(Reader["CONST_ASST_A_PREV"]);
						CONST_REG_A_PREV = ConvertDEC(Reader["CONST_REG_A_PREV"]);
						CONST_CERT_A_PREV = ConvertDEC(Reader["CONST_CERT_A_PREV"]);
						CONST_MAX_NBR_RATES = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]);
						CONST_SECTION1 = Reader["CONST_SECTION1"].ToString();
						CONST_SECTION2 = Reader["CONST_SECTION2"].ToString();
						CONST_SECTION3 = Reader["CONST_SECTION3"].ToString();
						CONST_SECTION4 = Reader["CONST_SECTION4"].ToString();
						CONST_SECTION5 = Reader["CONST_SECTION5"].ToString();
						CONST_SECTION6 = Reader["CONST_SECTION6"].ToString();
						CONST_SECTION7 = Reader["CONST_SECTION7"].ToString();
						CONST_SECTION8 = Reader["CONST_SECTION8"].ToString();
						CONST_SECTION9 = Reader["CONST_SECTION9"].ToString();
						CONST_SECTION10 = Reader["CONST_SECTION10"].ToString();
						CONST_SECTION11 = Reader["CONST_SECTION11"].ToString();
						CONST_SECTION12 = Reader["CONST_SECTION12"].ToString();
						CONST_SECTION13 = Reader["CONST_SECTION13"].ToString();
						CONST_SECTION14 = Reader["CONST_SECTION14"].ToString();
						CONST_SECTION15 = Reader["CONST_SECTION15"].ToString();
						CONST_SECTION16 = Reader["CONST_SECTION16"].ToString();
						CONST_SECTION17 = Reader["CONST_SECTION17"].ToString();
						CONST_SECTION18 = Reader["CONST_SECTION18"].ToString();
						CONST_SECTION19 = Reader["CONST_SECTION19"].ToString();
						CONST_GROUP1 = ConvertDEC(Reader["CONST_GROUP1"]);
						CONST_GROUP2 = ConvertDEC(Reader["CONST_GROUP2"]);
						CONST_GROUP3 = ConvertDEC(Reader["CONST_GROUP3"]);
						CONST_GROUP4 = ConvertDEC(Reader["CONST_GROUP4"]);
						CONST_GROUP5 = ConvertDEC(Reader["CONST_GROUP5"]);
						CONST_GROUP6 = ConvertDEC(Reader["CONST_GROUP6"]);
						CONST_GROUP7 = ConvertDEC(Reader["CONST_GROUP7"]);
						CONST_GROUP8 = ConvertDEC(Reader["CONST_GROUP8"]);
						CONST_GROUP9 = ConvertDEC(Reader["CONST_GROUP9"]);
						CONST_GROUP10 = ConvertDEC(Reader["CONST_GROUP10"]);
						CONST_GROUP11 = ConvertDEC(Reader["CONST_GROUP11"]);
						CONST_GROUP12 = ConvertDEC(Reader["CONST_GROUP12"]);
						CONST_GROUP13 = ConvertDEC(Reader["CONST_GROUP13"]);
						CONST_GROUP14 = ConvertDEC(Reader["CONST_GROUP14"]);
						CONST_GROUP15 = ConvertDEC(Reader["CONST_GROUP15"]);
						CONST_GROUP16 = ConvertDEC(Reader["CONST_GROUP16"]);
						CONST_GROUP17 = ConvertDEC(Reader["CONST_GROUP17"]);
						CONST_GROUP18 = ConvertDEC(Reader["CONST_GROUP18"]);
						CONST_GROUP19 = ConvertDEC(Reader["CONST_GROUP19"]);
						CONST_RATE_CURR1 = ConvertDEC(Reader["CONST_RATE_CURR1"]);
						CONST_RATE_CURR2 = ConvertDEC(Reader["CONST_RATE_CURR2"]);
						CONST_RATE_CURR3 = ConvertDEC(Reader["CONST_RATE_CURR3"]);
						CONST_RATE_CURR4 = ConvertDEC(Reader["CONST_RATE_CURR4"]);
						CONST_RATE_CURR5 = ConvertDEC(Reader["CONST_RATE_CURR5"]);
						CONST_RATE_CURR6 = ConvertDEC(Reader["CONST_RATE_CURR6"]);
						CONST_RATE_CURR7 = ConvertDEC(Reader["CONST_RATE_CURR7"]);
						CONST_RATE_CURR8 = ConvertDEC(Reader["CONST_RATE_CURR8"]);
						CONST_RATE_CURR9 = ConvertDEC(Reader["CONST_RATE_CURR9"]);
						CONST_RATE_CURR10 = ConvertDEC(Reader["CONST_RATE_CURR10"]);
						CONST_RATE_CURR11 = ConvertDEC(Reader["CONST_RATE_CURR11"]);
						CONST_RATE_CURR12 = ConvertDEC(Reader["CONST_RATE_CURR12"]);
						CONST_RATE_CURR13 = ConvertDEC(Reader["CONST_RATE_CURR13"]);
						CONST_RATE_CURR14 = ConvertDEC(Reader["CONST_RATE_CURR14"]);
						CONST_RATE_CURR15 = ConvertDEC(Reader["CONST_RATE_CURR15"]);
						CONST_RATE_CURR16 = ConvertDEC(Reader["CONST_RATE_CURR16"]);
						CONST_RATE_CURR17 = ConvertDEC(Reader["CONST_RATE_CURR17"]);
						CONST_RATE_CURR18 = ConvertDEC(Reader["CONST_RATE_CURR18"]);
						CONST_RATE_CURR19 = ConvertDEC(Reader["CONST_RATE_CURR19"]);
						CONST_RATE_PREV1 = ConvertDEC(Reader["CONST_RATE_PREV1"]);
						CONST_RATE_PREV2 = ConvertDEC(Reader["CONST_RATE_PREV2"]);
						CONST_RATE_PREV3 = ConvertDEC(Reader["CONST_RATE_PREV3"]);
						CONST_RATE_PREV4 = ConvertDEC(Reader["CONST_RATE_PREV4"]);
						CONST_RATE_PREV5 = ConvertDEC(Reader["CONST_RATE_PREV5"]);
						CONST_RATE_PREV6 = ConvertDEC(Reader["CONST_RATE_PREV6"]);
						CONST_RATE_PREV7 = ConvertDEC(Reader["CONST_RATE_PREV7"]);
						CONST_RATE_PREV8 = ConvertDEC(Reader["CONST_RATE_PREV8"]);
						CONST_RATE_PREV9 = ConvertDEC(Reader["CONST_RATE_PREV9"]);
						CONST_RATE_PREV10 = ConvertDEC(Reader["CONST_RATE_PREV10"]);
						CONST_RATE_PREV11 = ConvertDEC(Reader["CONST_RATE_PREV11"]);
						CONST_RATE_PREV12 = ConvertDEC(Reader["CONST_RATE_PREV12"]);
						CONST_RATE_PREV13 = ConvertDEC(Reader["CONST_RATE_PREV13"]);
						CONST_RATE_PREV14 = ConvertDEC(Reader["CONST_RATE_PREV14"]);
						CONST_RATE_PREV15 = ConvertDEC(Reader["CONST_RATE_PREV15"]);
						CONST_RATE_PREV16 = ConvertDEC(Reader["CONST_RATE_PREV16"]);
						CONST_RATE_PREV17 = ConvertDEC(Reader["CONST_RATE_PREV17"]);
						CONST_RATE_PREV18 = ConvertDEC(Reader["CONST_RATE_PREV18"]);
						CONST_RATE_PREV19 = ConvertDEC(Reader["CONST_RATE_PREV19"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_yy_curr = ConvertDEC(Reader["CONST_YY_CURR"]);
						_originalConst_mm_curr = ConvertDEC(Reader["CONST_MM_CURR"]);
						_originalConst_dd_curr = ConvertDEC(Reader["CONST_DD_CURR"]);
						_originalConst_bilateral_curr = ConvertDEC(Reader["CONST_BILATERAL_CURR"]);
						_originalConst_ic_curr = ConvertDEC(Reader["CONST_IC_CURR"]);
						_originalConst_sr_curr = ConvertDEC(Reader["CONST_SR_CURR"]);
						_originalConst_wcb_curr = ConvertDEC(Reader["CONST_WCB_CURR"]);
						_originalConst_asst_h_curr = ConvertDEC(Reader["CONST_ASST_H_CURR"]);
						_originalConst_reg_h_curr = ConvertDEC(Reader["CONST_REG_H_CURR"]);
						_originalConst_cert_h_curr = ConvertDEC(Reader["CONST_CERT_H_CURR"]);
						_originalConst_asst_a_curr = ConvertDEC(Reader["CONST_ASST_A_CURR"]);
						_originalConst_reg_a_curr = ConvertDEC(Reader["CONST_REG_A_CURR"]);
						_originalConst_cert_a_curr = ConvertDEC(Reader["CONST_CERT_A_CURR"]);
						_originalConst_yy_prev = ConvertDEC(Reader["CONST_YY_PREV"]);
						_originalConst_mm_prev = ConvertDEC(Reader["CONST_MM_PREV"]);
						_originalConst_dd_prev = ConvertDEC(Reader["CONST_DD_PREV"]);
						_originalConst_bilateral_prev = ConvertDEC(Reader["CONST_BILATERAL_PREV"]);
						_originalConst_ic_prev = ConvertDEC(Reader["CONST_IC_PREV"]);
						_originalConst_sr_prev = ConvertDEC(Reader["CONST_SR_PREV"]);
						_originalConst_wcb_prev = ConvertDEC(Reader["CONST_WCB_PREV"]);
						_originalConst_asst_h_prev = ConvertDEC(Reader["CONST_ASST_H_PREV"]);
						_originalConst_reg_h_prev = ConvertDEC(Reader["CONST_REG_H_PREV"]);
						_originalConst_cert_h_prev = ConvertDEC(Reader["CONST_CERT_H_PREV"]);
						_originalConst_asst_a_prev = ConvertDEC(Reader["CONST_ASST_A_PREV"]);
						_originalConst_reg_a_prev = ConvertDEC(Reader["CONST_REG_A_PREV"]);
						_originalConst_cert_a_prev = ConvertDEC(Reader["CONST_CERT_A_PREV"]);
						_originalConst_max_nbr_rates = ConvertDEC(Reader["CONST_MAX_NBR_RATES"]);
						_originalConst_section1 = Reader["CONST_SECTION1"].ToString();
						_originalConst_section2 = Reader["CONST_SECTION2"].ToString();
						_originalConst_section3 = Reader["CONST_SECTION3"].ToString();
						_originalConst_section4 = Reader["CONST_SECTION4"].ToString();
						_originalConst_section5 = Reader["CONST_SECTION5"].ToString();
						_originalConst_section6 = Reader["CONST_SECTION6"].ToString();
						_originalConst_section7 = Reader["CONST_SECTION7"].ToString();
						_originalConst_section8 = Reader["CONST_SECTION8"].ToString();
						_originalConst_section9 = Reader["CONST_SECTION9"].ToString();
						_originalConst_section10 = Reader["CONST_SECTION10"].ToString();
						_originalConst_section11 = Reader["CONST_SECTION11"].ToString();
						_originalConst_section12 = Reader["CONST_SECTION12"].ToString();
						_originalConst_section13 = Reader["CONST_SECTION13"].ToString();
						_originalConst_section14 = Reader["CONST_SECTION14"].ToString();
						_originalConst_section15 = Reader["CONST_SECTION15"].ToString();
						_originalConst_section16 = Reader["CONST_SECTION16"].ToString();
						_originalConst_section17 = Reader["CONST_SECTION17"].ToString();
						_originalConst_section18 = Reader["CONST_SECTION18"].ToString();
						_originalConst_section19 = Reader["CONST_SECTION19"].ToString();
						_originalConst_group1 = ConvertDEC(Reader["CONST_GROUP1"]);
						_originalConst_group2 = ConvertDEC(Reader["CONST_GROUP2"]);
						_originalConst_group3 = ConvertDEC(Reader["CONST_GROUP3"]);
						_originalConst_group4 = ConvertDEC(Reader["CONST_GROUP4"]);
						_originalConst_group5 = ConvertDEC(Reader["CONST_GROUP5"]);
						_originalConst_group6 = ConvertDEC(Reader["CONST_GROUP6"]);
						_originalConst_group7 = ConvertDEC(Reader["CONST_GROUP7"]);
						_originalConst_group8 = ConvertDEC(Reader["CONST_GROUP8"]);
						_originalConst_group9 = ConvertDEC(Reader["CONST_GROUP9"]);
						_originalConst_group10 = ConvertDEC(Reader["CONST_GROUP10"]);
						_originalConst_group11 = ConvertDEC(Reader["CONST_GROUP11"]);
						_originalConst_group12 = ConvertDEC(Reader["CONST_GROUP12"]);
						_originalConst_group13 = ConvertDEC(Reader["CONST_GROUP13"]);
						_originalConst_group14 = ConvertDEC(Reader["CONST_GROUP14"]);
						_originalConst_group15 = ConvertDEC(Reader["CONST_GROUP15"]);
						_originalConst_group16 = ConvertDEC(Reader["CONST_GROUP16"]);
						_originalConst_group17 = ConvertDEC(Reader["CONST_GROUP17"]);
						_originalConst_group18 = ConvertDEC(Reader["CONST_GROUP18"]);
						_originalConst_group19 = ConvertDEC(Reader["CONST_GROUP19"]);
						_originalConst_rate_curr1 = ConvertDEC(Reader["CONST_RATE_CURR1"]);
						_originalConst_rate_curr2 = ConvertDEC(Reader["CONST_RATE_CURR2"]);
						_originalConst_rate_curr3 = ConvertDEC(Reader["CONST_RATE_CURR3"]);
						_originalConst_rate_curr4 = ConvertDEC(Reader["CONST_RATE_CURR4"]);
						_originalConst_rate_curr5 = ConvertDEC(Reader["CONST_RATE_CURR5"]);
						_originalConst_rate_curr6 = ConvertDEC(Reader["CONST_RATE_CURR6"]);
						_originalConst_rate_curr7 = ConvertDEC(Reader["CONST_RATE_CURR7"]);
						_originalConst_rate_curr8 = ConvertDEC(Reader["CONST_RATE_CURR8"]);
						_originalConst_rate_curr9 = ConvertDEC(Reader["CONST_RATE_CURR9"]);
						_originalConst_rate_curr10 = ConvertDEC(Reader["CONST_RATE_CURR10"]);
						_originalConst_rate_curr11 = ConvertDEC(Reader["CONST_RATE_CURR11"]);
						_originalConst_rate_curr12 = ConvertDEC(Reader["CONST_RATE_CURR12"]);
						_originalConst_rate_curr13 = ConvertDEC(Reader["CONST_RATE_CURR13"]);
						_originalConst_rate_curr14 = ConvertDEC(Reader["CONST_RATE_CURR14"]);
						_originalConst_rate_curr15 = ConvertDEC(Reader["CONST_RATE_CURR15"]);
						_originalConst_rate_curr16 = ConvertDEC(Reader["CONST_RATE_CURR16"]);
						_originalConst_rate_curr17 = ConvertDEC(Reader["CONST_RATE_CURR17"]);
						_originalConst_rate_curr18 = ConvertDEC(Reader["CONST_RATE_CURR18"]);
						_originalConst_rate_curr19 = ConvertDEC(Reader["CONST_RATE_CURR19"]);
						_originalConst_rate_prev1 = ConvertDEC(Reader["CONST_RATE_PREV1"]);
						_originalConst_rate_prev2 = ConvertDEC(Reader["CONST_RATE_PREV2"]);
						_originalConst_rate_prev3 = ConvertDEC(Reader["CONST_RATE_PREV3"]);
						_originalConst_rate_prev4 = ConvertDEC(Reader["CONST_RATE_PREV4"]);
						_originalConst_rate_prev5 = ConvertDEC(Reader["CONST_RATE_PREV5"]);
						_originalConst_rate_prev6 = ConvertDEC(Reader["CONST_RATE_PREV6"]);
						_originalConst_rate_prev7 = ConvertDEC(Reader["CONST_RATE_PREV7"]);
						_originalConst_rate_prev8 = ConvertDEC(Reader["CONST_RATE_PREV8"]);
						_originalConst_rate_prev9 = ConvertDEC(Reader["CONST_RATE_PREV9"]);
						_originalConst_rate_prev10 = ConvertDEC(Reader["CONST_RATE_PREV10"]);
						_originalConst_rate_prev11 = ConvertDEC(Reader["CONST_RATE_PREV11"]);
						_originalConst_rate_prev12 = ConvertDEC(Reader["CONST_RATE_PREV12"]);
						_originalConst_rate_prev13 = ConvertDEC(Reader["CONST_RATE_PREV13"]);
						_originalConst_rate_prev14 = ConvertDEC(Reader["CONST_RATE_PREV14"]);
						_originalConst_rate_prev15 = ConvertDEC(Reader["CONST_RATE_PREV15"]);
						_originalConst_rate_prev16 = ConvertDEC(Reader["CONST_RATE_PREV16"]);
						_originalConst_rate_prev17 = ConvertDEC(Reader["CONST_RATE_PREV17"]);
						_originalConst_rate_prev18 = ConvertDEC(Reader["CONST_RATE_PREV18"]);
						_originalConst_rate_prev19 = ConvertDEC(Reader["CONST_RATE_PREV19"]);
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