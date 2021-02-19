using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
using System.Text;
using System.Diagnostics;

namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_2
    {

        public ObservableCollection<CONSTANTS_MSTR_REC_2> Collection_Using101C(ref bool isRetrieveRecord, ObservableCollection<CONSTANTS_MSTR_REC_2> constants_mstr_rec_2 = null)
        {
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_2>();
            isRetrieveRecord = true;
            StringBuilder sql = null;
            sql = new StringBuilder();
            string criteria = string.Empty;

            sql.Append("SELECT ")
               .Append(" BINARY_CHECKSUM(*) AS [ROWCHECKSUM]")
               .Append(" ,[CONST_REC_NBR]")
               .Append(" ,[CONST_YY_CURR]")
               .Append(" ,[CONST_MM_CURR]")
               .Append(" ,[CONST_DD_CURR]")
               .Append(" ,[CONST_BILATERAL_CURR]")
               .Append(" ,[CONST_IC_CURR]")
               .Append(" ,[CONST_SR_CURR]")
               .Append(" ,[CONST_WCB_CURR]")
               .Append(" ,[CONST_ASST_H_CURR]")
               .Append(" ,[CONST_REG_H_CURR]")
               .Append(" ,[CONST_CERT_H_CURR]")
               .Append(" ,[CONST_ASST_A_CURR]")
               .Append(" ,[CONST_REG_A_CURR]")
               .Append(" ,[CONST_CERT_A_CURR]")
               .Append(" ,[CONST_YY_PREV]")
               .Append(" ,[CONST_MM_PREV]")
               .Append(" ,[CONST_DD_PREV]")
               .Append(" ,[CONST_BILATERAL_PREV]")
               .Append(" ,[CONST_IC_PREV]")
               .Append(" ,[CONST_SR_PREV]")
               .Append(" ,[CONST_WCB_PREV]")
               .Append(" ,[CONST_ASST_H_PREV]")
               .Append(" ,[CONST_REG_H_PREV]")
               .Append(" ,[CONST_CERT_H_PREV]")
               .Append(" ,[CONST_ASST_A_PREV]")
               .Append(" ,[CONST_REG_A_PREV]")
               .Append(" ,[CONST_CERT_A_PREV]")
               .Append(" ,[CONST_MAX_NBR_RATES]")
               .Append(" ,[CONST_SECTION1]")
               .Append(" ,[CONST_SECTION2]")
               .Append(" ,[CONST_SECTION3]")
               .Append(" ,[CONST_SECTION4]")
               .Append(" ,[CONST_SECTION5]")
               .Append(" ,[CONST_SECTION6]")
               .Append(" ,[CONST_SECTION7]")
               .Append(" ,[CONST_SECTION8]")
               .Append(" ,[CONST_SECTION9]")
               .Append(" ,[CONST_SECTION10]")
               .Append(" ,[CONST_SECTION11]")
               .Append(" ,[CONST_SECTION12]")
               .Append(" ,[CONST_SECTION13]")
               .Append(" ,[CONST_SECTION14]")
               .Append(" ,[CONST_SECTION15]")
               .Append(" ,[CONST_SECTION16]")
               .Append(" ,[CONST_SECTION17]")
               .Append(" ,[CONST_SECTION18]")
               .Append(" ,[CONST_SECTION19]")
               .Append(" ,[CONST_GROUP1]")
               .Append(" ,[CONST_GROUP2]")
               .Append(" ,[CONST_GROUP3]")
               .Append(" ,[CONST_GROUP4]")
               .Append(" ,[CONST_GROUP5]")
               .Append(" ,[CONST_GROUP6]")
               .Append(" ,[CONST_GROUP7]")
               .Append(" ,[CONST_GROUP8]")
               .Append(" ,[CONST_GROUP9]")
               .Append(" ,[CONST_GROUP10]")
               .Append(" ,[CONST_GROUP11]")
               .Append(" ,[CONST_GROUP12]")
               .Append(" ,[CONST_GROUP13]")
               .Append(" ,[CONST_GROUP14]")
               .Append(" ,[CONST_GROUP15]")
               .Append(" ,[CONST_GROUP16]")
               .Append(" ,[CONST_GROUP17]")
               .Append(" ,[CONST_GROUP18]")
               .Append(" ,[CONST_GROUP19]")
               .Append(" ,[CONST_RATE_CURR1]")
               .Append(" ,[CONST_RATE_CURR2]")
               .Append(" ,[CONST_RATE_CURR3]")
               .Append(" ,[CONST_RATE_CURR4]")
               .Append(" ,[CONST_RATE_CURR5]")
               .Append(" ,[CONST_RATE_CURR6]")
               .Append(" ,[CONST_RATE_CURR7]")
               .Append(" ,[CONST_RATE_CURR8]")
               .Append(" ,[CONST_RATE_CURR9]")
               .Append(" ,[CONST_RATE_CURR10]")
               .Append(" ,[CONST_RATE_CURR11]")
               .Append(" ,[CONST_RATE_CURR12]")
               .Append(" ,[CONST_RATE_CURR13]")
               .Append(" ,[CONST_RATE_CURR14]")
               .Append(" ,[CONST_RATE_CURR15]")
               .Append(" ,[CONST_RATE_CURR16]")
               .Append(" ,[CONST_RATE_CURR17]")
               .Append(" ,[CONST_RATE_CURR18]")
               .Append(" ,[CONST_RATE_CURR19]")
               .Append(" ,[CONST_RATE_PREV1]")
               .Append(" ,[CONST_RATE_PREV2]")
               .Append(" ,[CONST_RATE_PREV3]")
               .Append(" ,[CONST_RATE_PREV4]")
               .Append(" ,[CONST_RATE_PREV5]")
               .Append(" ,[CONST_RATE_PREV6]")
               .Append(" ,[CONST_RATE_PREV7]")
               .Append(" ,[CONST_RATE_PREV8]")
               .Append(" ,[CONST_RATE_PREV9]")
               .Append(" ,[CONST_RATE_PREV10]")
               .Append(" ,[CONST_RATE_PREV11]")
               .Append(" ,[CONST_RATE_PREV12]")
               .Append(" ,[CONST_RATE_PREV13]")
               .Append(" ,[CONST_RATE_PREV14]")
               .Append(" ,[CONST_RATE_PREV15]")
               .Append(" ,[CONST_RATE_PREV16]")
               .Append(" ,[CONST_RATE_PREV17]")
               .Append(" ,[CONST_RATE_PREV18]")
               .Append(" ,[CONST_RATE_PREV19]")
               .Append(" ,[FILLER]")
               .Append(" FROM ")
               .Append(" [101C].[INDEXED].[CONSTANTS_MSTR_REC_2]  WITH (NOLOCK) ");

            Reader = CoreReader(sql.ToString());

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_2
                {
                    RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
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
                    CONST_ASST_A_CURR = ConvertDEC(Reader["CONST_ASST_H_CURR"]),
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

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();

            return collection;
        }
    }
}
