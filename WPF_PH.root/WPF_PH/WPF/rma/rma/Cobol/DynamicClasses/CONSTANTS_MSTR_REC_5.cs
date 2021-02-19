using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_5 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_5> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_con_nbr1min,
															decimal? const_con_nbr1max,
															decimal? const_con_nbr2min,
															decimal? const_con_nbr2max,
															decimal? const_con_nbr3min,
															decimal? const_con_nbr3max,
															decimal? const_con_nbr4min,
															decimal? const_con_nbr4max,
															decimal? const_con_nbr5min,
															decimal? const_con_nbr5max,
															decimal? const_con_nbr6min,
															decimal? const_con_nbr6max,
															decimal? const_con_nbr7min,
															decimal? const_con_nbr7max,
															decimal? const_con_nbr8min,
															decimal? const_con_nbr8max,
															decimal? const_con_nbr9min,
															decimal? const_con_nbr9max,
															decimal? const_con_nbr10min,
															decimal? const_con_nbr10max,
															decimal? const_con_nbr11min,
															decimal? const_con_nbr11max,
															decimal? const_con_nbr12min,
															decimal? const_con_nbr12max,
															decimal? const_con_nbr13min,
															decimal? const_con_nbr13max,
															decimal? const_con_nbr14min,
															decimal? const_con_nbr14max,
															decimal? const_con_nbr15min,
															decimal? const_con_nbr15max,
															decimal? const_con_nbr16min,
															decimal? const_con_nbr16max,
															decimal? const_con_nbr17min,
															decimal? const_con_nbr17max,
															decimal? const_con_nbr18min,
															decimal? const_con_nbr18max,
															decimal? const_con_nbr19min,
															decimal? const_con_nbr19max,
															decimal? const_con_nbr20min,
															decimal? const_con_nbr20max,
															decimal? const_con_nbr21min,
															decimal? const_con_nbr21max,
															decimal? const_con_nbr22min,
															decimal? const_con_nbr22max,
															decimal? const_con_nbr23min,
															decimal? const_con_nbr23max,
															decimal? const_con_nbr24min,
															decimal? const_con_nbr24max,
															decimal? const_con_nbr25min,
															decimal? const_con_nbr25max,
															decimal? const_nx_avail_pat1min,
															decimal? const_nx_avail_pat1max,
															decimal? const_nx_avail_pat2min,
															decimal? const_nx_avail_pat2max,
															decimal? const_nx_avail_pat3min,
															decimal? const_nx_avail_pat3max,
															decimal? const_nx_avail_pat4min,
															decimal? const_nx_avail_pat4max,
															decimal? const_nx_avail_pat5min,
															decimal? const_nx_avail_pat5max,
															decimal? const_nx_avail_pat6min,
															decimal? const_nx_avail_pat6max,
															decimal? const_nx_avail_pat7min,
															decimal? const_nx_avail_pat7max,
															decimal? const_nx_avail_pat8min,
															decimal? const_nx_avail_pat8max,
															decimal? const_nx_avail_pat9min,
															decimal? const_nx_avail_pat9max,
															decimal? const_nx_avail_pat10min,
															decimal? const_nx_avail_pat10max,
															decimal? const_nx_avail_pat11min,
															decimal? const_nx_avail_pat11max,
															decimal? const_nx_avail_pat12min,
															decimal? const_nx_avail_pat12max,
															decimal? const_nx_avail_pat13min,
															decimal? const_nx_avail_pat13max,
															decimal? const_nx_avail_pat14min,
															decimal? const_nx_avail_pat14max,
															decimal? const_nx_avail_pat15min,
															decimal? const_nx_avail_pat15max,
															decimal? const_nx_avail_pat16min,
															decimal? const_nx_avail_pat16max,
															decimal? const_nx_avail_pat17min,
															decimal? const_nx_avail_pat17max,
															decimal? const_nx_avail_pat18min,
															decimal? const_nx_avail_pat18max,
															decimal? const_nx_avail_pat19min,
															decimal? const_nx_avail_pat19max,
															decimal? const_nx_avail_pat20min,
															decimal? const_nx_avail_pat20max,
															decimal? const_nx_avail_pat21min,
															decimal? const_nx_avail_pat21max,
															decimal? const_nx_avail_pat22min,
															decimal? const_nx_avail_pat22max,
															decimal? const_nx_avail_pat23min,
															decimal? const_nx_avail_pat23max,
															decimal? const_nx_avail_pat24min,
															decimal? const_nx_avail_pat24max,
															decimal? const_nx_avail_pat25min,
															decimal? const_nx_avail_pat25max,
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
					new SqlParameter("minCONST_CON_NBR1",const_con_nbr1min),
					new SqlParameter("maxCONST_CON_NBR1",const_con_nbr1max),
					new SqlParameter("minCONST_CON_NBR2",const_con_nbr2min),
					new SqlParameter("maxCONST_CON_NBR2",const_con_nbr2max),
					new SqlParameter("minCONST_CON_NBR3",const_con_nbr3min),
					new SqlParameter("maxCONST_CON_NBR3",const_con_nbr3max),
					new SqlParameter("minCONST_CON_NBR4",const_con_nbr4min),
					new SqlParameter("maxCONST_CON_NBR4",const_con_nbr4max),
					new SqlParameter("minCONST_CON_NBR5",const_con_nbr5min),
					new SqlParameter("maxCONST_CON_NBR5",const_con_nbr5max),
					new SqlParameter("minCONST_CON_NBR6",const_con_nbr6min),
					new SqlParameter("maxCONST_CON_NBR6",const_con_nbr6max),
					new SqlParameter("minCONST_CON_NBR7",const_con_nbr7min),
					new SqlParameter("maxCONST_CON_NBR7",const_con_nbr7max),
					new SqlParameter("minCONST_CON_NBR8",const_con_nbr8min),
					new SqlParameter("maxCONST_CON_NBR8",const_con_nbr8max),
					new SqlParameter("minCONST_CON_NBR9",const_con_nbr9min),
					new SqlParameter("maxCONST_CON_NBR9",const_con_nbr9max),
					new SqlParameter("minCONST_CON_NBR10",const_con_nbr10min),
					new SqlParameter("maxCONST_CON_NBR10",const_con_nbr10max),
					new SqlParameter("minCONST_CON_NBR11",const_con_nbr11min),
					new SqlParameter("maxCONST_CON_NBR11",const_con_nbr11max),
					new SqlParameter("minCONST_CON_NBR12",const_con_nbr12min),
					new SqlParameter("maxCONST_CON_NBR12",const_con_nbr12max),
					new SqlParameter("minCONST_CON_NBR13",const_con_nbr13min),
					new SqlParameter("maxCONST_CON_NBR13",const_con_nbr13max),
					new SqlParameter("minCONST_CON_NBR14",const_con_nbr14min),
					new SqlParameter("maxCONST_CON_NBR14",const_con_nbr14max),
					new SqlParameter("minCONST_CON_NBR15",const_con_nbr15min),
					new SqlParameter("maxCONST_CON_NBR15",const_con_nbr15max),
					new SqlParameter("minCONST_CON_NBR16",const_con_nbr16min),
					new SqlParameter("maxCONST_CON_NBR16",const_con_nbr16max),
					new SqlParameter("minCONST_CON_NBR17",const_con_nbr17min),
					new SqlParameter("maxCONST_CON_NBR17",const_con_nbr17max),
					new SqlParameter("minCONST_CON_NBR18",const_con_nbr18min),
					new SqlParameter("maxCONST_CON_NBR18",const_con_nbr18max),
					new SqlParameter("minCONST_CON_NBR19",const_con_nbr19min),
					new SqlParameter("maxCONST_CON_NBR19",const_con_nbr19max),
					new SqlParameter("minCONST_CON_NBR20",const_con_nbr20min),
					new SqlParameter("maxCONST_CON_NBR20",const_con_nbr20max),
					new SqlParameter("minCONST_CON_NBR21",const_con_nbr21min),
					new SqlParameter("maxCONST_CON_NBR21",const_con_nbr21max),
					new SqlParameter("minCONST_CON_NBR22",const_con_nbr22min),
					new SqlParameter("maxCONST_CON_NBR22",const_con_nbr22max),
					new SqlParameter("minCONST_CON_NBR23",const_con_nbr23min),
					new SqlParameter("maxCONST_CON_NBR23",const_con_nbr23max),
					new SqlParameter("minCONST_CON_NBR24",const_con_nbr24min),
					new SqlParameter("maxCONST_CON_NBR24",const_con_nbr24max),
					new SqlParameter("minCONST_CON_NBR25",const_con_nbr25min),
					new SqlParameter("maxCONST_CON_NBR25",const_con_nbr25max),
					new SqlParameter("minCONST_NX_AVAIL_PAT1",const_nx_avail_pat1min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT1",const_nx_avail_pat1max),
					new SqlParameter("minCONST_NX_AVAIL_PAT2",const_nx_avail_pat2min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT2",const_nx_avail_pat2max),
					new SqlParameter("minCONST_NX_AVAIL_PAT3",const_nx_avail_pat3min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT3",const_nx_avail_pat3max),
					new SqlParameter("minCONST_NX_AVAIL_PAT4",const_nx_avail_pat4min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT4",const_nx_avail_pat4max),
					new SqlParameter("minCONST_NX_AVAIL_PAT5",const_nx_avail_pat5min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT5",const_nx_avail_pat5max),
					new SqlParameter("minCONST_NX_AVAIL_PAT6",const_nx_avail_pat6min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT6",const_nx_avail_pat6max),
					new SqlParameter("minCONST_NX_AVAIL_PAT7",const_nx_avail_pat7min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT7",const_nx_avail_pat7max),
					new SqlParameter("minCONST_NX_AVAIL_PAT8",const_nx_avail_pat8min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT8",const_nx_avail_pat8max),
					new SqlParameter("minCONST_NX_AVAIL_PAT9",const_nx_avail_pat9min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT9",const_nx_avail_pat9max),
					new SqlParameter("minCONST_NX_AVAIL_PAT10",const_nx_avail_pat10min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT10",const_nx_avail_pat10max),
					new SqlParameter("minCONST_NX_AVAIL_PAT11",const_nx_avail_pat11min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT11",const_nx_avail_pat11max),
					new SqlParameter("minCONST_NX_AVAIL_PAT12",const_nx_avail_pat12min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT12",const_nx_avail_pat12max),
					new SqlParameter("minCONST_NX_AVAIL_PAT13",const_nx_avail_pat13min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT13",const_nx_avail_pat13max),
					new SqlParameter("minCONST_NX_AVAIL_PAT14",const_nx_avail_pat14min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT14",const_nx_avail_pat14max),
					new SqlParameter("minCONST_NX_AVAIL_PAT15",const_nx_avail_pat15min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT15",const_nx_avail_pat15max),
					new SqlParameter("minCONST_NX_AVAIL_PAT16",const_nx_avail_pat16min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT16",const_nx_avail_pat16max),
					new SqlParameter("minCONST_NX_AVAIL_PAT17",const_nx_avail_pat17min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT17",const_nx_avail_pat17max),
					new SqlParameter("minCONST_NX_AVAIL_PAT18",const_nx_avail_pat18min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT18",const_nx_avail_pat18max),
					new SqlParameter("minCONST_NX_AVAIL_PAT19",const_nx_avail_pat19min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT19",const_nx_avail_pat19max),
					new SqlParameter("minCONST_NX_AVAIL_PAT20",const_nx_avail_pat20min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT20",const_nx_avail_pat20max),
					new SqlParameter("minCONST_NX_AVAIL_PAT21",const_nx_avail_pat21min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT21",const_nx_avail_pat21max),
					new SqlParameter("minCONST_NX_AVAIL_PAT22",const_nx_avail_pat22min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT22",const_nx_avail_pat22max),
					new SqlParameter("minCONST_NX_AVAIL_PAT23",const_nx_avail_pat23min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT23",const_nx_avail_pat23max),
					new SqlParameter("minCONST_NX_AVAIL_PAT24",const_nx_avail_pat24min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT24",const_nx_avail_pat24max),
					new SqlParameter("minCONST_NX_AVAIL_PAT25",const_nx_avail_pat25min),
					new SqlParameter("maxCONST_NX_AVAIL_PAT25",const_nx_avail_pat25max),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_5>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_5
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_CON_NBR1 = ConvertDEC(Reader["CONST_CON_NBR1"]),
					CONST_CON_NBR2 = ConvertDEC(Reader["CONST_CON_NBR2"]),
					CONST_CON_NBR3 = ConvertDEC(Reader["CONST_CON_NBR3"]),
					CONST_CON_NBR4 = ConvertDEC(Reader["CONST_CON_NBR4"]),
					CONST_CON_NBR5 = ConvertDEC(Reader["CONST_CON_NBR5"]),
					CONST_CON_NBR6 = ConvertDEC(Reader["CONST_CON_NBR6"]),
					CONST_CON_NBR7 = ConvertDEC(Reader["CONST_CON_NBR7"]),
					CONST_CON_NBR8 = ConvertDEC(Reader["CONST_CON_NBR8"]),
					CONST_CON_NBR9 = ConvertDEC(Reader["CONST_CON_NBR9"]),
					CONST_CON_NBR10 = ConvertDEC(Reader["CONST_CON_NBR10"]),
					CONST_CON_NBR11 = ConvertDEC(Reader["CONST_CON_NBR11"]),
					CONST_CON_NBR12 = ConvertDEC(Reader["CONST_CON_NBR12"]),
					CONST_CON_NBR13 = ConvertDEC(Reader["CONST_CON_NBR13"]),
					CONST_CON_NBR14 = ConvertDEC(Reader["CONST_CON_NBR14"]),
					CONST_CON_NBR15 = ConvertDEC(Reader["CONST_CON_NBR15"]),
					CONST_CON_NBR16 = ConvertDEC(Reader["CONST_CON_NBR16"]),
					CONST_CON_NBR17 = ConvertDEC(Reader["CONST_CON_NBR17"]),
					CONST_CON_NBR18 = ConvertDEC(Reader["CONST_CON_NBR18"]),
					CONST_CON_NBR19 = ConvertDEC(Reader["CONST_CON_NBR19"]),
					CONST_CON_NBR20 = ConvertDEC(Reader["CONST_CON_NBR20"]),
					CONST_CON_NBR21 = ConvertDEC(Reader["CONST_CON_NBR21"]),
					CONST_CON_NBR22 = ConvertDEC(Reader["CONST_CON_NBR22"]),
					CONST_CON_NBR23 = ConvertDEC(Reader["CONST_CON_NBR23"]),
					CONST_CON_NBR24 = ConvertDEC(Reader["CONST_CON_NBR24"]),
					CONST_CON_NBR25 = ConvertDEC(Reader["CONST_CON_NBR25"]),
					CONST_NX_AVAIL_PAT1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]),
					CONST_NX_AVAIL_PAT2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]),
					CONST_NX_AVAIL_PAT3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]),
					CONST_NX_AVAIL_PAT4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]),
					CONST_NX_AVAIL_PAT5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]),
					CONST_NX_AVAIL_PAT6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]),
					CONST_NX_AVAIL_PAT7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]),
					CONST_NX_AVAIL_PAT8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]),
					CONST_NX_AVAIL_PAT9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]),
					CONST_NX_AVAIL_PAT10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]),
					CONST_NX_AVAIL_PAT11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]),
					CONST_NX_AVAIL_PAT12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]),
					CONST_NX_AVAIL_PAT13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]),
					CONST_NX_AVAIL_PAT14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]),
					CONST_NX_AVAIL_PAT15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]),
					CONST_NX_AVAIL_PAT16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]),
					CONST_NX_AVAIL_PAT17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]),
					CONST_NX_AVAIL_PAT18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]),
					CONST_NX_AVAIL_PAT19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]),
					CONST_NX_AVAIL_PAT20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]),
					CONST_NX_AVAIL_PAT21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]),
					CONST_NX_AVAIL_PAT22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]),
					CONST_NX_AVAIL_PAT23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]),
					CONST_NX_AVAIL_PAT24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]),
					CONST_NX_AVAIL_PAT25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_con_nbr1 = ConvertDEC(Reader["CONST_CON_NBR1"]),
					_originalConst_con_nbr2 = ConvertDEC(Reader["CONST_CON_NBR2"]),
					_originalConst_con_nbr3 = ConvertDEC(Reader["CONST_CON_NBR3"]),
					_originalConst_con_nbr4 = ConvertDEC(Reader["CONST_CON_NBR4"]),
					_originalConst_con_nbr5 = ConvertDEC(Reader["CONST_CON_NBR5"]),
					_originalConst_con_nbr6 = ConvertDEC(Reader["CONST_CON_NBR6"]),
					_originalConst_con_nbr7 = ConvertDEC(Reader["CONST_CON_NBR7"]),
					_originalConst_con_nbr8 = ConvertDEC(Reader["CONST_CON_NBR8"]),
					_originalConst_con_nbr9 = ConvertDEC(Reader["CONST_CON_NBR9"]),
					_originalConst_con_nbr10 = ConvertDEC(Reader["CONST_CON_NBR10"]),
					_originalConst_con_nbr11 = ConvertDEC(Reader["CONST_CON_NBR11"]),
					_originalConst_con_nbr12 = ConvertDEC(Reader["CONST_CON_NBR12"]),
					_originalConst_con_nbr13 = ConvertDEC(Reader["CONST_CON_NBR13"]),
					_originalConst_con_nbr14 = ConvertDEC(Reader["CONST_CON_NBR14"]),
					_originalConst_con_nbr15 = ConvertDEC(Reader["CONST_CON_NBR15"]),
					_originalConst_con_nbr16 = ConvertDEC(Reader["CONST_CON_NBR16"]),
					_originalConst_con_nbr17 = ConvertDEC(Reader["CONST_CON_NBR17"]),
					_originalConst_con_nbr18 = ConvertDEC(Reader["CONST_CON_NBR18"]),
					_originalConst_con_nbr19 = ConvertDEC(Reader["CONST_CON_NBR19"]),
					_originalConst_con_nbr20 = ConvertDEC(Reader["CONST_CON_NBR20"]),
					_originalConst_con_nbr21 = ConvertDEC(Reader["CONST_CON_NBR21"]),
					_originalConst_con_nbr22 = ConvertDEC(Reader["CONST_CON_NBR22"]),
					_originalConst_con_nbr23 = ConvertDEC(Reader["CONST_CON_NBR23"]),
					_originalConst_con_nbr24 = ConvertDEC(Reader["CONST_CON_NBR24"]),
					_originalConst_con_nbr25 = ConvertDEC(Reader["CONST_CON_NBR25"]),
					_originalConst_nx_avail_pat1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]),
					_originalConst_nx_avail_pat2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]),
					_originalConst_nx_avail_pat3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]),
					_originalConst_nx_avail_pat4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]),
					_originalConst_nx_avail_pat5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]),
					_originalConst_nx_avail_pat6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]),
					_originalConst_nx_avail_pat7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]),
					_originalConst_nx_avail_pat8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]),
					_originalConst_nx_avail_pat9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]),
					_originalConst_nx_avail_pat10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]),
					_originalConst_nx_avail_pat11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]),
					_originalConst_nx_avail_pat12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]),
					_originalConst_nx_avail_pat13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]),
					_originalConst_nx_avail_pat14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]),
					_originalConst_nx_avail_pat15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]),
					_originalConst_nx_avail_pat16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]),
					_originalConst_nx_avail_pat17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]),
					_originalConst_nx_avail_pat18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]),
					_originalConst_nx_avail_pat19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]),
					_originalConst_nx_avail_pat20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]),
					_originalConst_nx_avail_pat21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]),
					_originalConst_nx_avail_pat22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]),
					_originalConst_nx_avail_pat23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]),
					_originalConst_nx_avail_pat24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]),
					_originalConst_nx_avail_pat25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_5 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_5> Collection(ObservableCollection<CONSTANTS_MSTR_REC_5>
                                                               constantsMstrRec5 = null)
        {
            if (IsSameSearch() && constantsMstrRec5 != null)
            {
                return constantsMstrRec5;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_5>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_CON_NBR1",WhereConst_con_nbr1),
					new SqlParameter("CONST_CON_NBR2",WhereConst_con_nbr2),
					new SqlParameter("CONST_CON_NBR3",WhereConst_con_nbr3),
					new SqlParameter("CONST_CON_NBR4",WhereConst_con_nbr4),
					new SqlParameter("CONST_CON_NBR5",WhereConst_con_nbr5),
					new SqlParameter("CONST_CON_NBR6",WhereConst_con_nbr6),
					new SqlParameter("CONST_CON_NBR7",WhereConst_con_nbr7),
					new SqlParameter("CONST_CON_NBR8",WhereConst_con_nbr8),
					new SqlParameter("CONST_CON_NBR9",WhereConst_con_nbr9),
					new SqlParameter("CONST_CON_NBR10",WhereConst_con_nbr10),
					new SqlParameter("CONST_CON_NBR11",WhereConst_con_nbr11),
					new SqlParameter("CONST_CON_NBR12",WhereConst_con_nbr12),
					new SqlParameter("CONST_CON_NBR13",WhereConst_con_nbr13),
					new SqlParameter("CONST_CON_NBR14",WhereConst_con_nbr14),
					new SqlParameter("CONST_CON_NBR15",WhereConst_con_nbr15),
					new SqlParameter("CONST_CON_NBR16",WhereConst_con_nbr16),
					new SqlParameter("CONST_CON_NBR17",WhereConst_con_nbr17),
					new SqlParameter("CONST_CON_NBR18",WhereConst_con_nbr18),
					new SqlParameter("CONST_CON_NBR19",WhereConst_con_nbr19),
					new SqlParameter("CONST_CON_NBR20",WhereConst_con_nbr20),
					new SqlParameter("CONST_CON_NBR21",WhereConst_con_nbr21),
					new SqlParameter("CONST_CON_NBR22",WhereConst_con_nbr22),
					new SqlParameter("CONST_CON_NBR23",WhereConst_con_nbr23),
					new SqlParameter("CONST_CON_NBR24",WhereConst_con_nbr24),
					new SqlParameter("CONST_CON_NBR25",WhereConst_con_nbr25),
					new SqlParameter("CONST_NX_AVAIL_PAT1",WhereConst_nx_avail_pat1),
					new SqlParameter("CONST_NX_AVAIL_PAT2",WhereConst_nx_avail_pat2),
					new SqlParameter("CONST_NX_AVAIL_PAT3",WhereConst_nx_avail_pat3),
					new SqlParameter("CONST_NX_AVAIL_PAT4",WhereConst_nx_avail_pat4),
					new SqlParameter("CONST_NX_AVAIL_PAT5",WhereConst_nx_avail_pat5),
					new SqlParameter("CONST_NX_AVAIL_PAT6",WhereConst_nx_avail_pat6),
					new SqlParameter("CONST_NX_AVAIL_PAT7",WhereConst_nx_avail_pat7),
					new SqlParameter("CONST_NX_AVAIL_PAT8",WhereConst_nx_avail_pat8),
					new SqlParameter("CONST_NX_AVAIL_PAT9",WhereConst_nx_avail_pat9),
					new SqlParameter("CONST_NX_AVAIL_PAT10",WhereConst_nx_avail_pat10),
					new SqlParameter("CONST_NX_AVAIL_PAT11",WhereConst_nx_avail_pat11),
					new SqlParameter("CONST_NX_AVAIL_PAT12",WhereConst_nx_avail_pat12),
					new SqlParameter("CONST_NX_AVAIL_PAT13",WhereConst_nx_avail_pat13),
					new SqlParameter("CONST_NX_AVAIL_PAT14",WhereConst_nx_avail_pat14),
					new SqlParameter("CONST_NX_AVAIL_PAT15",WhereConst_nx_avail_pat15),
					new SqlParameter("CONST_NX_AVAIL_PAT16",WhereConst_nx_avail_pat16),
					new SqlParameter("CONST_NX_AVAIL_PAT17",WhereConst_nx_avail_pat17),
					new SqlParameter("CONST_NX_AVAIL_PAT18",WhereConst_nx_avail_pat18),
					new SqlParameter("CONST_NX_AVAIL_PAT19",WhereConst_nx_avail_pat19),
					new SqlParameter("CONST_NX_AVAIL_PAT20",WhereConst_nx_avail_pat20),
					new SqlParameter("CONST_NX_AVAIL_PAT21",WhereConst_nx_avail_pat21),
					new SqlParameter("CONST_NX_AVAIL_PAT22",WhereConst_nx_avail_pat22),
					new SqlParameter("CONST_NX_AVAIL_PAT23",WhereConst_nx_avail_pat23),
					new SqlParameter("CONST_NX_AVAIL_PAT24",WhereConst_nx_avail_pat24),
					new SqlParameter("CONST_NX_AVAIL_PAT25",WhereConst_nx_avail_pat25),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_5>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_5
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_CON_NBR1 = ConvertDEC(Reader["CONST_CON_NBR1"]),
					CONST_CON_NBR2 = ConvertDEC(Reader["CONST_CON_NBR2"]),
					CONST_CON_NBR3 = ConvertDEC(Reader["CONST_CON_NBR3"]),
					CONST_CON_NBR4 = ConvertDEC(Reader["CONST_CON_NBR4"]),
					CONST_CON_NBR5 = ConvertDEC(Reader["CONST_CON_NBR5"]),
					CONST_CON_NBR6 = ConvertDEC(Reader["CONST_CON_NBR6"]),
					CONST_CON_NBR7 = ConvertDEC(Reader["CONST_CON_NBR7"]),
					CONST_CON_NBR8 = ConvertDEC(Reader["CONST_CON_NBR8"]),
					CONST_CON_NBR9 = ConvertDEC(Reader["CONST_CON_NBR9"]),
					CONST_CON_NBR10 = ConvertDEC(Reader["CONST_CON_NBR10"]),
					CONST_CON_NBR11 = ConvertDEC(Reader["CONST_CON_NBR11"]),
					CONST_CON_NBR12 = ConvertDEC(Reader["CONST_CON_NBR12"]),
					CONST_CON_NBR13 = ConvertDEC(Reader["CONST_CON_NBR13"]),
					CONST_CON_NBR14 = ConvertDEC(Reader["CONST_CON_NBR14"]),
					CONST_CON_NBR15 = ConvertDEC(Reader["CONST_CON_NBR15"]),
					CONST_CON_NBR16 = ConvertDEC(Reader["CONST_CON_NBR16"]),
					CONST_CON_NBR17 = ConvertDEC(Reader["CONST_CON_NBR17"]),
					CONST_CON_NBR18 = ConvertDEC(Reader["CONST_CON_NBR18"]),
					CONST_CON_NBR19 = ConvertDEC(Reader["CONST_CON_NBR19"]),
					CONST_CON_NBR20 = ConvertDEC(Reader["CONST_CON_NBR20"]),
					CONST_CON_NBR21 = ConvertDEC(Reader["CONST_CON_NBR21"]),
					CONST_CON_NBR22 = ConvertDEC(Reader["CONST_CON_NBR22"]),
					CONST_CON_NBR23 = ConvertDEC(Reader["CONST_CON_NBR23"]),
					CONST_CON_NBR24 = ConvertDEC(Reader["CONST_CON_NBR24"]),
					CONST_CON_NBR25 = ConvertDEC(Reader["CONST_CON_NBR25"]),
					CONST_NX_AVAIL_PAT1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]),
					CONST_NX_AVAIL_PAT2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]),
					CONST_NX_AVAIL_PAT3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]),
					CONST_NX_AVAIL_PAT4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]),
					CONST_NX_AVAIL_PAT5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]),
					CONST_NX_AVAIL_PAT6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]),
					CONST_NX_AVAIL_PAT7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]),
					CONST_NX_AVAIL_PAT8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]),
					CONST_NX_AVAIL_PAT9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]),
					CONST_NX_AVAIL_PAT10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]),
					CONST_NX_AVAIL_PAT11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]),
					CONST_NX_AVAIL_PAT12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]),
					CONST_NX_AVAIL_PAT13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]),
					CONST_NX_AVAIL_PAT14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]),
					CONST_NX_AVAIL_PAT15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]),
					CONST_NX_AVAIL_PAT16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]),
					CONST_NX_AVAIL_PAT17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]),
					CONST_NX_AVAIL_PAT18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]),
					CONST_NX_AVAIL_PAT19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]),
					CONST_NX_AVAIL_PAT20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]),
					CONST_NX_AVAIL_PAT21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]),
					CONST_NX_AVAIL_PAT22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]),
					CONST_NX_AVAIL_PAT23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]),
					CONST_NX_AVAIL_PAT24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]),
					CONST_NX_AVAIL_PAT25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_con_nbr1 = WhereConst_con_nbr1,
					_whereConst_con_nbr2 = WhereConst_con_nbr2,
					_whereConst_con_nbr3 = WhereConst_con_nbr3,
					_whereConst_con_nbr4 = WhereConst_con_nbr4,
					_whereConst_con_nbr5 = WhereConst_con_nbr5,
					_whereConst_con_nbr6 = WhereConst_con_nbr6,
					_whereConst_con_nbr7 = WhereConst_con_nbr7,
					_whereConst_con_nbr8 = WhereConst_con_nbr8,
					_whereConst_con_nbr9 = WhereConst_con_nbr9,
					_whereConst_con_nbr10 = WhereConst_con_nbr10,
					_whereConst_con_nbr11 = WhereConst_con_nbr11,
					_whereConst_con_nbr12 = WhereConst_con_nbr12,
					_whereConst_con_nbr13 = WhereConst_con_nbr13,
					_whereConst_con_nbr14 = WhereConst_con_nbr14,
					_whereConst_con_nbr15 = WhereConst_con_nbr15,
					_whereConst_con_nbr16 = WhereConst_con_nbr16,
					_whereConst_con_nbr17 = WhereConst_con_nbr17,
					_whereConst_con_nbr18 = WhereConst_con_nbr18,
					_whereConst_con_nbr19 = WhereConst_con_nbr19,
					_whereConst_con_nbr20 = WhereConst_con_nbr20,
					_whereConst_con_nbr21 = WhereConst_con_nbr21,
					_whereConst_con_nbr22 = WhereConst_con_nbr22,
					_whereConst_con_nbr23 = WhereConst_con_nbr23,
					_whereConst_con_nbr24 = WhereConst_con_nbr24,
					_whereConst_con_nbr25 = WhereConst_con_nbr25,
					_whereConst_nx_avail_pat1 = WhereConst_nx_avail_pat1,
					_whereConst_nx_avail_pat2 = WhereConst_nx_avail_pat2,
					_whereConst_nx_avail_pat3 = WhereConst_nx_avail_pat3,
					_whereConst_nx_avail_pat4 = WhereConst_nx_avail_pat4,
					_whereConst_nx_avail_pat5 = WhereConst_nx_avail_pat5,
					_whereConst_nx_avail_pat6 = WhereConst_nx_avail_pat6,
					_whereConst_nx_avail_pat7 = WhereConst_nx_avail_pat7,
					_whereConst_nx_avail_pat8 = WhereConst_nx_avail_pat8,
					_whereConst_nx_avail_pat9 = WhereConst_nx_avail_pat9,
					_whereConst_nx_avail_pat10 = WhereConst_nx_avail_pat10,
					_whereConst_nx_avail_pat11 = WhereConst_nx_avail_pat11,
					_whereConst_nx_avail_pat12 = WhereConst_nx_avail_pat12,
					_whereConst_nx_avail_pat13 = WhereConst_nx_avail_pat13,
					_whereConst_nx_avail_pat14 = WhereConst_nx_avail_pat14,
					_whereConst_nx_avail_pat15 = WhereConst_nx_avail_pat15,
					_whereConst_nx_avail_pat16 = WhereConst_nx_avail_pat16,
					_whereConst_nx_avail_pat17 = WhereConst_nx_avail_pat17,
					_whereConst_nx_avail_pat18 = WhereConst_nx_avail_pat18,
					_whereConst_nx_avail_pat19 = WhereConst_nx_avail_pat19,
					_whereConst_nx_avail_pat20 = WhereConst_nx_avail_pat20,
					_whereConst_nx_avail_pat21 = WhereConst_nx_avail_pat21,
					_whereConst_nx_avail_pat22 = WhereConst_nx_avail_pat22,
					_whereConst_nx_avail_pat23 = WhereConst_nx_avail_pat23,
					_whereConst_nx_avail_pat24 = WhereConst_nx_avail_pat24,
					_whereConst_nx_avail_pat25 = WhereConst_nx_avail_pat25,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_con_nbr1 = ConvertDEC(Reader["CONST_CON_NBR1"]),
					_originalConst_con_nbr2 = ConvertDEC(Reader["CONST_CON_NBR2"]),
					_originalConst_con_nbr3 = ConvertDEC(Reader["CONST_CON_NBR3"]),
					_originalConst_con_nbr4 = ConvertDEC(Reader["CONST_CON_NBR4"]),
					_originalConst_con_nbr5 = ConvertDEC(Reader["CONST_CON_NBR5"]),
					_originalConst_con_nbr6 = ConvertDEC(Reader["CONST_CON_NBR6"]),
					_originalConst_con_nbr7 = ConvertDEC(Reader["CONST_CON_NBR7"]),
					_originalConst_con_nbr8 = ConvertDEC(Reader["CONST_CON_NBR8"]),
					_originalConst_con_nbr9 = ConvertDEC(Reader["CONST_CON_NBR9"]),
					_originalConst_con_nbr10 = ConvertDEC(Reader["CONST_CON_NBR10"]),
					_originalConst_con_nbr11 = ConvertDEC(Reader["CONST_CON_NBR11"]),
					_originalConst_con_nbr12 = ConvertDEC(Reader["CONST_CON_NBR12"]),
					_originalConst_con_nbr13 = ConvertDEC(Reader["CONST_CON_NBR13"]),
					_originalConst_con_nbr14 = ConvertDEC(Reader["CONST_CON_NBR14"]),
					_originalConst_con_nbr15 = ConvertDEC(Reader["CONST_CON_NBR15"]),
					_originalConst_con_nbr16 = ConvertDEC(Reader["CONST_CON_NBR16"]),
					_originalConst_con_nbr17 = ConvertDEC(Reader["CONST_CON_NBR17"]),
					_originalConst_con_nbr18 = ConvertDEC(Reader["CONST_CON_NBR18"]),
					_originalConst_con_nbr19 = ConvertDEC(Reader["CONST_CON_NBR19"]),
					_originalConst_con_nbr20 = ConvertDEC(Reader["CONST_CON_NBR20"]),
					_originalConst_con_nbr21 = ConvertDEC(Reader["CONST_CON_NBR21"]),
					_originalConst_con_nbr22 = ConvertDEC(Reader["CONST_CON_NBR22"]),
					_originalConst_con_nbr23 = ConvertDEC(Reader["CONST_CON_NBR23"]),
					_originalConst_con_nbr24 = ConvertDEC(Reader["CONST_CON_NBR24"]),
					_originalConst_con_nbr25 = ConvertDEC(Reader["CONST_CON_NBR25"]),
					_originalConst_nx_avail_pat1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]),
					_originalConst_nx_avail_pat2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]),
					_originalConst_nx_avail_pat3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]),
					_originalConst_nx_avail_pat4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]),
					_originalConst_nx_avail_pat5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]),
					_originalConst_nx_avail_pat6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]),
					_originalConst_nx_avail_pat7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]),
					_originalConst_nx_avail_pat8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]),
					_originalConst_nx_avail_pat9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]),
					_originalConst_nx_avail_pat10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]),
					_originalConst_nx_avail_pat11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]),
					_originalConst_nx_avail_pat12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]),
					_originalConst_nx_avail_pat13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]),
					_originalConst_nx_avail_pat14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]),
					_originalConst_nx_avail_pat15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]),
					_originalConst_nx_avail_pat16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]),
					_originalConst_nx_avail_pat17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]),
					_originalConst_nx_avail_pat18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]),
					_originalConst_nx_avail_pat19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]),
					_originalConst_nx_avail_pat20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]),
					_originalConst_nx_avail_pat21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]),
					_originalConst_nx_avail_pat22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]),
					_originalConst_nx_avail_pat23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]),
					_originalConst_nx_avail_pat24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]),
					_originalConst_nx_avail_pat25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_con_nbr1 = WhereConst_con_nbr1;
					_whereConst_con_nbr2 = WhereConst_con_nbr2;
					_whereConst_con_nbr3 = WhereConst_con_nbr3;
					_whereConst_con_nbr4 = WhereConst_con_nbr4;
					_whereConst_con_nbr5 = WhereConst_con_nbr5;
					_whereConst_con_nbr6 = WhereConst_con_nbr6;
					_whereConst_con_nbr7 = WhereConst_con_nbr7;
					_whereConst_con_nbr8 = WhereConst_con_nbr8;
					_whereConst_con_nbr9 = WhereConst_con_nbr9;
					_whereConst_con_nbr10 = WhereConst_con_nbr10;
					_whereConst_con_nbr11 = WhereConst_con_nbr11;
					_whereConst_con_nbr12 = WhereConst_con_nbr12;
					_whereConst_con_nbr13 = WhereConst_con_nbr13;
					_whereConst_con_nbr14 = WhereConst_con_nbr14;
					_whereConst_con_nbr15 = WhereConst_con_nbr15;
					_whereConst_con_nbr16 = WhereConst_con_nbr16;
					_whereConst_con_nbr17 = WhereConst_con_nbr17;
					_whereConst_con_nbr18 = WhereConst_con_nbr18;
					_whereConst_con_nbr19 = WhereConst_con_nbr19;
					_whereConst_con_nbr20 = WhereConst_con_nbr20;
					_whereConst_con_nbr21 = WhereConst_con_nbr21;
					_whereConst_con_nbr22 = WhereConst_con_nbr22;
					_whereConst_con_nbr23 = WhereConst_con_nbr23;
					_whereConst_con_nbr24 = WhereConst_con_nbr24;
					_whereConst_con_nbr25 = WhereConst_con_nbr25;
					_whereConst_nx_avail_pat1 = WhereConst_nx_avail_pat1;
					_whereConst_nx_avail_pat2 = WhereConst_nx_avail_pat2;
					_whereConst_nx_avail_pat3 = WhereConst_nx_avail_pat3;
					_whereConst_nx_avail_pat4 = WhereConst_nx_avail_pat4;
					_whereConst_nx_avail_pat5 = WhereConst_nx_avail_pat5;
					_whereConst_nx_avail_pat6 = WhereConst_nx_avail_pat6;
					_whereConst_nx_avail_pat7 = WhereConst_nx_avail_pat7;
					_whereConst_nx_avail_pat8 = WhereConst_nx_avail_pat8;
					_whereConst_nx_avail_pat9 = WhereConst_nx_avail_pat9;
					_whereConst_nx_avail_pat10 = WhereConst_nx_avail_pat10;
					_whereConst_nx_avail_pat11 = WhereConst_nx_avail_pat11;
					_whereConst_nx_avail_pat12 = WhereConst_nx_avail_pat12;
					_whereConst_nx_avail_pat13 = WhereConst_nx_avail_pat13;
					_whereConst_nx_avail_pat14 = WhereConst_nx_avail_pat14;
					_whereConst_nx_avail_pat15 = WhereConst_nx_avail_pat15;
					_whereConst_nx_avail_pat16 = WhereConst_nx_avail_pat16;
					_whereConst_nx_avail_pat17 = WhereConst_nx_avail_pat17;
					_whereConst_nx_avail_pat18 = WhereConst_nx_avail_pat18;
					_whereConst_nx_avail_pat19 = WhereConst_nx_avail_pat19;
					_whereConst_nx_avail_pat20 = WhereConst_nx_avail_pat20;
					_whereConst_nx_avail_pat21 = WhereConst_nx_avail_pat21;
					_whereConst_nx_avail_pat22 = WhereConst_nx_avail_pat22;
					_whereConst_nx_avail_pat23 = WhereConst_nx_avail_pat23;
					_whereConst_nx_avail_pat24 = WhereConst_nx_avail_pat24;
					_whereConst_nx_avail_pat25 = WhereConst_nx_avail_pat25;
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
				&& WhereConst_con_nbr1 == null 
				&& WhereConst_con_nbr2 == null 
				&& WhereConst_con_nbr3 == null 
				&& WhereConst_con_nbr4 == null 
				&& WhereConst_con_nbr5 == null 
				&& WhereConst_con_nbr6 == null 
				&& WhereConst_con_nbr7 == null 
				&& WhereConst_con_nbr8 == null 
				&& WhereConst_con_nbr9 == null 
				&& WhereConst_con_nbr10 == null 
				&& WhereConst_con_nbr11 == null 
				&& WhereConst_con_nbr12 == null 
				&& WhereConst_con_nbr13 == null 
				&& WhereConst_con_nbr14 == null 
				&& WhereConst_con_nbr15 == null 
				&& WhereConst_con_nbr16 == null 
				&& WhereConst_con_nbr17 == null 
				&& WhereConst_con_nbr18 == null 
				&& WhereConst_con_nbr19 == null 
				&& WhereConst_con_nbr20 == null 
				&& WhereConst_con_nbr21 == null 
				&& WhereConst_con_nbr22 == null 
				&& WhereConst_con_nbr23 == null 
				&& WhereConst_con_nbr24 == null 
				&& WhereConst_con_nbr25 == null 
				&& WhereConst_nx_avail_pat1 == null 
				&& WhereConst_nx_avail_pat2 == null 
				&& WhereConst_nx_avail_pat3 == null 
				&& WhereConst_nx_avail_pat4 == null 
				&& WhereConst_nx_avail_pat5 == null 
				&& WhereConst_nx_avail_pat6 == null 
				&& WhereConst_nx_avail_pat7 == null 
				&& WhereConst_nx_avail_pat8 == null 
				&& WhereConst_nx_avail_pat9 == null 
				&& WhereConst_nx_avail_pat10 == null 
				&& WhereConst_nx_avail_pat11 == null 
				&& WhereConst_nx_avail_pat12 == null 
				&& WhereConst_nx_avail_pat13 == null 
				&& WhereConst_nx_avail_pat14 == null 
				&& WhereConst_nx_avail_pat15 == null 
				&& WhereConst_nx_avail_pat16 == null 
				&& WhereConst_nx_avail_pat17 == null 
				&& WhereConst_nx_avail_pat18 == null 
				&& WhereConst_nx_avail_pat19 == null 
				&& WhereConst_nx_avail_pat20 == null 
				&& WhereConst_nx_avail_pat21 == null 
				&& WhereConst_nx_avail_pat22 == null 
				&& WhereConst_nx_avail_pat23 == null 
				&& WhereConst_nx_avail_pat24 == null 
				&& WhereConst_nx_avail_pat25 == null 
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
				&& WhereConst_con_nbr1 ==  _whereConst_con_nbr1
				&& WhereConst_con_nbr2 ==  _whereConst_con_nbr2
				&& WhereConst_con_nbr3 ==  _whereConst_con_nbr3
				&& WhereConst_con_nbr4 ==  _whereConst_con_nbr4
				&& WhereConst_con_nbr5 ==  _whereConst_con_nbr5
				&& WhereConst_con_nbr6 ==  _whereConst_con_nbr6
				&& WhereConst_con_nbr7 ==  _whereConst_con_nbr7
				&& WhereConst_con_nbr8 ==  _whereConst_con_nbr8
				&& WhereConst_con_nbr9 ==  _whereConst_con_nbr9
				&& WhereConst_con_nbr10 ==  _whereConst_con_nbr10
				&& WhereConst_con_nbr11 ==  _whereConst_con_nbr11
				&& WhereConst_con_nbr12 ==  _whereConst_con_nbr12
				&& WhereConst_con_nbr13 ==  _whereConst_con_nbr13
				&& WhereConst_con_nbr14 ==  _whereConst_con_nbr14
				&& WhereConst_con_nbr15 ==  _whereConst_con_nbr15
				&& WhereConst_con_nbr16 ==  _whereConst_con_nbr16
				&& WhereConst_con_nbr17 ==  _whereConst_con_nbr17
				&& WhereConst_con_nbr18 ==  _whereConst_con_nbr18
				&& WhereConst_con_nbr19 ==  _whereConst_con_nbr19
				&& WhereConst_con_nbr20 ==  _whereConst_con_nbr20
				&& WhereConst_con_nbr21 ==  _whereConst_con_nbr21
				&& WhereConst_con_nbr22 ==  _whereConst_con_nbr22
				&& WhereConst_con_nbr23 ==  _whereConst_con_nbr23
				&& WhereConst_con_nbr24 ==  _whereConst_con_nbr24
				&& WhereConst_con_nbr25 ==  _whereConst_con_nbr25
				&& WhereConst_nx_avail_pat1 ==  _whereConst_nx_avail_pat1
				&& WhereConst_nx_avail_pat2 ==  _whereConst_nx_avail_pat2
				&& WhereConst_nx_avail_pat3 ==  _whereConst_nx_avail_pat3
				&& WhereConst_nx_avail_pat4 ==  _whereConst_nx_avail_pat4
				&& WhereConst_nx_avail_pat5 ==  _whereConst_nx_avail_pat5
				&& WhereConst_nx_avail_pat6 ==  _whereConst_nx_avail_pat6
				&& WhereConst_nx_avail_pat7 ==  _whereConst_nx_avail_pat7
				&& WhereConst_nx_avail_pat8 ==  _whereConst_nx_avail_pat8
				&& WhereConst_nx_avail_pat9 ==  _whereConst_nx_avail_pat9
				&& WhereConst_nx_avail_pat10 ==  _whereConst_nx_avail_pat10
				&& WhereConst_nx_avail_pat11 ==  _whereConst_nx_avail_pat11
				&& WhereConst_nx_avail_pat12 ==  _whereConst_nx_avail_pat12
				&& WhereConst_nx_avail_pat13 ==  _whereConst_nx_avail_pat13
				&& WhereConst_nx_avail_pat14 ==  _whereConst_nx_avail_pat14
				&& WhereConst_nx_avail_pat15 ==  _whereConst_nx_avail_pat15
				&& WhereConst_nx_avail_pat16 ==  _whereConst_nx_avail_pat16
				&& WhereConst_nx_avail_pat17 ==  _whereConst_nx_avail_pat17
				&& WhereConst_nx_avail_pat18 ==  _whereConst_nx_avail_pat18
				&& WhereConst_nx_avail_pat19 ==  _whereConst_nx_avail_pat19
				&& WhereConst_nx_avail_pat20 ==  _whereConst_nx_avail_pat20
				&& WhereConst_nx_avail_pat21 ==  _whereConst_nx_avail_pat21
				&& WhereConst_nx_avail_pat22 ==  _whereConst_nx_avail_pat22
				&& WhereConst_nx_avail_pat23 ==  _whereConst_nx_avail_pat23
				&& WhereConst_nx_avail_pat24 ==  _whereConst_nx_avail_pat24
				&& WhereConst_nx_avail_pat25 ==  _whereConst_nx_avail_pat25
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_con_nbr1 = null; 
			WhereConst_con_nbr2 = null; 
			WhereConst_con_nbr3 = null; 
			WhereConst_con_nbr4 = null; 
			WhereConst_con_nbr5 = null; 
			WhereConst_con_nbr6 = null; 
			WhereConst_con_nbr7 = null; 
			WhereConst_con_nbr8 = null; 
			WhereConst_con_nbr9 = null; 
			WhereConst_con_nbr10 = null; 
			WhereConst_con_nbr11 = null; 
			WhereConst_con_nbr12 = null; 
			WhereConst_con_nbr13 = null; 
			WhereConst_con_nbr14 = null; 
			WhereConst_con_nbr15 = null; 
			WhereConst_con_nbr16 = null; 
			WhereConst_con_nbr17 = null; 
			WhereConst_con_nbr18 = null; 
			WhereConst_con_nbr19 = null; 
			WhereConst_con_nbr20 = null; 
			WhereConst_con_nbr21 = null; 
			WhereConst_con_nbr22 = null; 
			WhereConst_con_nbr23 = null; 
			WhereConst_con_nbr24 = null; 
			WhereConst_con_nbr25 = null; 
			WhereConst_nx_avail_pat1 = null; 
			WhereConst_nx_avail_pat2 = null; 
			WhereConst_nx_avail_pat3 = null; 
			WhereConst_nx_avail_pat4 = null; 
			WhereConst_nx_avail_pat5 = null; 
			WhereConst_nx_avail_pat6 = null; 
			WhereConst_nx_avail_pat7 = null; 
			WhereConst_nx_avail_pat8 = null; 
			WhereConst_nx_avail_pat9 = null; 
			WhereConst_nx_avail_pat10 = null; 
			WhereConst_nx_avail_pat11 = null; 
			WhereConst_nx_avail_pat12 = null; 
			WhereConst_nx_avail_pat13 = null; 
			WhereConst_nx_avail_pat14 = null; 
			WhereConst_nx_avail_pat15 = null; 
			WhereConst_nx_avail_pat16 = null; 
			WhereConst_nx_avail_pat17 = null; 
			WhereConst_nx_avail_pat18 = null; 
			WhereConst_nx_avail_pat19 = null; 
			WhereConst_nx_avail_pat20 = null; 
			WhereConst_nx_avail_pat21 = null; 
			WhereConst_nx_avail_pat22 = null; 
			WhereConst_nx_avail_pat23 = null; 
			WhereConst_nx_avail_pat24 = null; 
			WhereConst_nx_avail_pat25 = null; 
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
		private decimal? _CONST_CON_NBR1;
		private decimal? _CONST_CON_NBR2;
		private decimal? _CONST_CON_NBR3;
		private decimal? _CONST_CON_NBR4;
		private decimal? _CONST_CON_NBR5;
		private decimal? _CONST_CON_NBR6;
		private decimal? _CONST_CON_NBR7;
		private decimal? _CONST_CON_NBR8;
		private decimal? _CONST_CON_NBR9;
		private decimal? _CONST_CON_NBR10;
		private decimal? _CONST_CON_NBR11;
		private decimal? _CONST_CON_NBR12;
		private decimal? _CONST_CON_NBR13;
		private decimal? _CONST_CON_NBR14;
		private decimal? _CONST_CON_NBR15;
		private decimal? _CONST_CON_NBR16;
		private decimal? _CONST_CON_NBR17;
		private decimal? _CONST_CON_NBR18;
		private decimal? _CONST_CON_NBR19;
		private decimal? _CONST_CON_NBR20;
		private decimal? _CONST_CON_NBR21;
		private decimal? _CONST_CON_NBR22;
		private decimal? _CONST_CON_NBR23;
		private decimal? _CONST_CON_NBR24;
		private decimal? _CONST_CON_NBR25;
		private decimal? _CONST_NX_AVAIL_PAT1;
		private decimal? _CONST_NX_AVAIL_PAT2;
		private decimal? _CONST_NX_AVAIL_PAT3;
		private decimal? _CONST_NX_AVAIL_PAT4;
		private decimal? _CONST_NX_AVAIL_PAT5;
		private decimal? _CONST_NX_AVAIL_PAT6;
		private decimal? _CONST_NX_AVAIL_PAT7;
		private decimal? _CONST_NX_AVAIL_PAT8;
		private decimal? _CONST_NX_AVAIL_PAT9;
		private decimal? _CONST_NX_AVAIL_PAT10;
		private decimal? _CONST_NX_AVAIL_PAT11;
		private decimal? _CONST_NX_AVAIL_PAT12;
		private decimal? _CONST_NX_AVAIL_PAT13;
		private decimal? _CONST_NX_AVAIL_PAT14;
		private decimal? _CONST_NX_AVAIL_PAT15;
		private decimal? _CONST_NX_AVAIL_PAT16;
		private decimal? _CONST_NX_AVAIL_PAT17;
		private decimal? _CONST_NX_AVAIL_PAT18;
		private decimal? _CONST_NX_AVAIL_PAT19;
		private decimal? _CONST_NX_AVAIL_PAT20;
		private decimal? _CONST_NX_AVAIL_PAT21;
		private decimal? _CONST_NX_AVAIL_PAT22;
		private decimal? _CONST_NX_AVAIL_PAT23;
		private decimal? _CONST_NX_AVAIL_PAT24;
		private decimal? _CONST_NX_AVAIL_PAT25;
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
		public decimal? CONST_CON_NBR1
		{
			get { return _CONST_CON_NBR1; }
			set
			{
				if (_CONST_CON_NBR1 != value)
				{
					_CONST_CON_NBR1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR2
		{
			get { return _CONST_CON_NBR2; }
			set
			{
				if (_CONST_CON_NBR2 != value)
				{
					_CONST_CON_NBR2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR3
		{
			get { return _CONST_CON_NBR3; }
			set
			{
				if (_CONST_CON_NBR3 != value)
				{
					_CONST_CON_NBR3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR4
		{
			get { return _CONST_CON_NBR4; }
			set
			{
				if (_CONST_CON_NBR4 != value)
				{
					_CONST_CON_NBR4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR5
		{
			get { return _CONST_CON_NBR5; }
			set
			{
				if (_CONST_CON_NBR5 != value)
				{
					_CONST_CON_NBR5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR6
		{
			get { return _CONST_CON_NBR6; }
			set
			{
				if (_CONST_CON_NBR6 != value)
				{
					_CONST_CON_NBR6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR7
		{
			get { return _CONST_CON_NBR7; }
			set
			{
				if (_CONST_CON_NBR7 != value)
				{
					_CONST_CON_NBR7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR8
		{
			get { return _CONST_CON_NBR8; }
			set
			{
				if (_CONST_CON_NBR8 != value)
				{
					_CONST_CON_NBR8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR9
		{
			get { return _CONST_CON_NBR9; }
			set
			{
				if (_CONST_CON_NBR9 != value)
				{
					_CONST_CON_NBR9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR10
		{
			get { return _CONST_CON_NBR10; }
			set
			{
				if (_CONST_CON_NBR10 != value)
				{
					_CONST_CON_NBR10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR11
		{
			get { return _CONST_CON_NBR11; }
			set
			{
				if (_CONST_CON_NBR11 != value)
				{
					_CONST_CON_NBR11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR12
		{
			get { return _CONST_CON_NBR12; }
			set
			{
				if (_CONST_CON_NBR12 != value)
				{
					_CONST_CON_NBR12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR13
		{
			get { return _CONST_CON_NBR13; }
			set
			{
				if (_CONST_CON_NBR13 != value)
				{
					_CONST_CON_NBR13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR14
		{
			get { return _CONST_CON_NBR14; }
			set
			{
				if (_CONST_CON_NBR14 != value)
				{
					_CONST_CON_NBR14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR15
		{
			get { return _CONST_CON_NBR15; }
			set
			{
				if (_CONST_CON_NBR15 != value)
				{
					_CONST_CON_NBR15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR16
		{
			get { return _CONST_CON_NBR16; }
			set
			{
				if (_CONST_CON_NBR16 != value)
				{
					_CONST_CON_NBR16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR17
		{
			get { return _CONST_CON_NBR17; }
			set
			{
				if (_CONST_CON_NBR17 != value)
				{
					_CONST_CON_NBR17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR18
		{
			get { return _CONST_CON_NBR18; }
			set
			{
				if (_CONST_CON_NBR18 != value)
				{
					_CONST_CON_NBR18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR19
		{
			get { return _CONST_CON_NBR19; }
			set
			{
				if (_CONST_CON_NBR19 != value)
				{
					_CONST_CON_NBR19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR20
		{
			get { return _CONST_CON_NBR20; }
			set
			{
				if (_CONST_CON_NBR20 != value)
				{
					_CONST_CON_NBR20 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR21
		{
			get { return _CONST_CON_NBR21; }
			set
			{
				if (_CONST_CON_NBR21 != value)
				{
					_CONST_CON_NBR21 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR22
		{
			get { return _CONST_CON_NBR22; }
			set
			{
				if (_CONST_CON_NBR22 != value)
				{
					_CONST_CON_NBR22 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR23
		{
			get { return _CONST_CON_NBR23; }
			set
			{
				if (_CONST_CON_NBR23 != value)
				{
					_CONST_CON_NBR23 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR24
		{
			get { return _CONST_CON_NBR24; }
			set
			{
				if (_CONST_CON_NBR24 != value)
				{
					_CONST_CON_NBR24 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CON_NBR25
		{
			get { return _CONST_CON_NBR25; }
			set
			{
				if (_CONST_CON_NBR25 != value)
				{
					_CONST_CON_NBR25 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT1
		{
			get { return _CONST_NX_AVAIL_PAT1; }
			set
			{
				if (_CONST_NX_AVAIL_PAT1 != value)
				{
					_CONST_NX_AVAIL_PAT1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT2
		{
			get { return _CONST_NX_AVAIL_PAT2; }
			set
			{
				if (_CONST_NX_AVAIL_PAT2 != value)
				{
					_CONST_NX_AVAIL_PAT2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT3
		{
			get { return _CONST_NX_AVAIL_PAT3; }
			set
			{
				if (_CONST_NX_AVAIL_PAT3 != value)
				{
					_CONST_NX_AVAIL_PAT3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT4
		{
			get { return _CONST_NX_AVAIL_PAT4; }
			set
			{
				if (_CONST_NX_AVAIL_PAT4 != value)
				{
					_CONST_NX_AVAIL_PAT4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT5
		{
			get { return _CONST_NX_AVAIL_PAT5; }
			set
			{
				if (_CONST_NX_AVAIL_PAT5 != value)
				{
					_CONST_NX_AVAIL_PAT5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT6
		{
			get { return _CONST_NX_AVAIL_PAT6; }
			set
			{
				if (_CONST_NX_AVAIL_PAT6 != value)
				{
					_CONST_NX_AVAIL_PAT6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT7
		{
			get { return _CONST_NX_AVAIL_PAT7; }
			set
			{
				if (_CONST_NX_AVAIL_PAT7 != value)
				{
					_CONST_NX_AVAIL_PAT7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT8
		{
			get { return _CONST_NX_AVAIL_PAT8; }
			set
			{
				if (_CONST_NX_AVAIL_PAT8 != value)
				{
					_CONST_NX_AVAIL_PAT8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT9
		{
			get { return _CONST_NX_AVAIL_PAT9; }
			set
			{
				if (_CONST_NX_AVAIL_PAT9 != value)
				{
					_CONST_NX_AVAIL_PAT9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT10
		{
			get { return _CONST_NX_AVAIL_PAT10; }
			set
			{
				if (_CONST_NX_AVAIL_PAT10 != value)
				{
					_CONST_NX_AVAIL_PAT10 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT11
		{
			get { return _CONST_NX_AVAIL_PAT11; }
			set
			{
				if (_CONST_NX_AVAIL_PAT11 != value)
				{
					_CONST_NX_AVAIL_PAT11 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT12
		{
			get { return _CONST_NX_AVAIL_PAT12; }
			set
			{
				if (_CONST_NX_AVAIL_PAT12 != value)
				{
					_CONST_NX_AVAIL_PAT12 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT13
		{
			get { return _CONST_NX_AVAIL_PAT13; }
			set
			{
				if (_CONST_NX_AVAIL_PAT13 != value)
				{
					_CONST_NX_AVAIL_PAT13 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT14
		{
			get { return _CONST_NX_AVAIL_PAT14; }
			set
			{
				if (_CONST_NX_AVAIL_PAT14 != value)
				{
					_CONST_NX_AVAIL_PAT14 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT15
		{
			get { return _CONST_NX_AVAIL_PAT15; }
			set
			{
				if (_CONST_NX_AVAIL_PAT15 != value)
				{
					_CONST_NX_AVAIL_PAT15 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT16
		{
			get { return _CONST_NX_AVAIL_PAT16; }
			set
			{
				if (_CONST_NX_AVAIL_PAT16 != value)
				{
					_CONST_NX_AVAIL_PAT16 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT17
		{
			get { return _CONST_NX_AVAIL_PAT17; }
			set
			{
				if (_CONST_NX_AVAIL_PAT17 != value)
				{
					_CONST_NX_AVAIL_PAT17 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT18
		{
			get { return _CONST_NX_AVAIL_PAT18; }
			set
			{
				if (_CONST_NX_AVAIL_PAT18 != value)
				{
					_CONST_NX_AVAIL_PAT18 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT19
		{
			get { return _CONST_NX_AVAIL_PAT19; }
			set
			{
				if (_CONST_NX_AVAIL_PAT19 != value)
				{
					_CONST_NX_AVAIL_PAT19 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT20
		{
			get { return _CONST_NX_AVAIL_PAT20; }
			set
			{
				if (_CONST_NX_AVAIL_PAT20 != value)
				{
					_CONST_NX_AVAIL_PAT20 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT21
		{
			get { return _CONST_NX_AVAIL_PAT21; }
			set
			{
				if (_CONST_NX_AVAIL_PAT21 != value)
				{
					_CONST_NX_AVAIL_PAT21 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT22
		{
			get { return _CONST_NX_AVAIL_PAT22; }
			set
			{
				if (_CONST_NX_AVAIL_PAT22 != value)
				{
					_CONST_NX_AVAIL_PAT22 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT23
		{
			get { return _CONST_NX_AVAIL_PAT23; }
			set
			{
				if (_CONST_NX_AVAIL_PAT23 != value)
				{
					_CONST_NX_AVAIL_PAT23 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT24
		{
			get { return _CONST_NX_AVAIL_PAT24; }
			set
			{
				if (_CONST_NX_AVAIL_PAT24 != value)
				{
					_CONST_NX_AVAIL_PAT24 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_NX_AVAIL_PAT25
		{
			get { return _CONST_NX_AVAIL_PAT25; }
			set
			{
				if (_CONST_NX_AVAIL_PAT25 != value)
				{
					_CONST_NX_AVAIL_PAT25 = value;
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
		public decimal? WhereConst_con_nbr1 { get; set; }
		private decimal? _whereConst_con_nbr1;
		public decimal? WhereConst_con_nbr2 { get; set; }
		private decimal? _whereConst_con_nbr2;
		public decimal? WhereConst_con_nbr3 { get; set; }
		private decimal? _whereConst_con_nbr3;
		public decimal? WhereConst_con_nbr4 { get; set; }
		private decimal? _whereConst_con_nbr4;
		public decimal? WhereConst_con_nbr5 { get; set; }
		private decimal? _whereConst_con_nbr5;
		public decimal? WhereConst_con_nbr6 { get; set; }
		private decimal? _whereConst_con_nbr6;
		public decimal? WhereConst_con_nbr7 { get; set; }
		private decimal? _whereConst_con_nbr7;
		public decimal? WhereConst_con_nbr8 { get; set; }
		private decimal? _whereConst_con_nbr8;
		public decimal? WhereConst_con_nbr9 { get; set; }
		private decimal? _whereConst_con_nbr9;
		public decimal? WhereConst_con_nbr10 { get; set; }
		private decimal? _whereConst_con_nbr10;
		public decimal? WhereConst_con_nbr11 { get; set; }
		private decimal? _whereConst_con_nbr11;
		public decimal? WhereConst_con_nbr12 { get; set; }
		private decimal? _whereConst_con_nbr12;
		public decimal? WhereConst_con_nbr13 { get; set; }
		private decimal? _whereConst_con_nbr13;
		public decimal? WhereConst_con_nbr14 { get; set; }
		private decimal? _whereConst_con_nbr14;
		public decimal? WhereConst_con_nbr15 { get; set; }
		private decimal? _whereConst_con_nbr15;
		public decimal? WhereConst_con_nbr16 { get; set; }
		private decimal? _whereConst_con_nbr16;
		public decimal? WhereConst_con_nbr17 { get; set; }
		private decimal? _whereConst_con_nbr17;
		public decimal? WhereConst_con_nbr18 { get; set; }
		private decimal? _whereConst_con_nbr18;
		public decimal? WhereConst_con_nbr19 { get; set; }
		private decimal? _whereConst_con_nbr19;
		public decimal? WhereConst_con_nbr20 { get; set; }
		private decimal? _whereConst_con_nbr20;
		public decimal? WhereConst_con_nbr21 { get; set; }
		private decimal? _whereConst_con_nbr21;
		public decimal? WhereConst_con_nbr22 { get; set; }
		private decimal? _whereConst_con_nbr22;
		public decimal? WhereConst_con_nbr23 { get; set; }
		private decimal? _whereConst_con_nbr23;
		public decimal? WhereConst_con_nbr24 { get; set; }
		private decimal? _whereConst_con_nbr24;
		public decimal? WhereConst_con_nbr25 { get; set; }
		private decimal? _whereConst_con_nbr25;
		public decimal? WhereConst_nx_avail_pat1 { get; set; }
		private decimal? _whereConst_nx_avail_pat1;
		public decimal? WhereConst_nx_avail_pat2 { get; set; }
		private decimal? _whereConst_nx_avail_pat2;
		public decimal? WhereConst_nx_avail_pat3 { get; set; }
		private decimal? _whereConst_nx_avail_pat3;
		public decimal? WhereConst_nx_avail_pat4 { get; set; }
		private decimal? _whereConst_nx_avail_pat4;
		public decimal? WhereConst_nx_avail_pat5 { get; set; }
		private decimal? _whereConst_nx_avail_pat5;
		public decimal? WhereConst_nx_avail_pat6 { get; set; }
		private decimal? _whereConst_nx_avail_pat6;
		public decimal? WhereConst_nx_avail_pat7 { get; set; }
		private decimal? _whereConst_nx_avail_pat7;
		public decimal? WhereConst_nx_avail_pat8 { get; set; }
		private decimal? _whereConst_nx_avail_pat8;
		public decimal? WhereConst_nx_avail_pat9 { get; set; }
		private decimal? _whereConst_nx_avail_pat9;
		public decimal? WhereConst_nx_avail_pat10 { get; set; }
		private decimal? _whereConst_nx_avail_pat10;
		public decimal? WhereConst_nx_avail_pat11 { get; set; }
		private decimal? _whereConst_nx_avail_pat11;
		public decimal? WhereConst_nx_avail_pat12 { get; set; }
		private decimal? _whereConst_nx_avail_pat12;
		public decimal? WhereConst_nx_avail_pat13 { get; set; }
		private decimal? _whereConst_nx_avail_pat13;
		public decimal? WhereConst_nx_avail_pat14 { get; set; }
		private decimal? _whereConst_nx_avail_pat14;
		public decimal? WhereConst_nx_avail_pat15 { get; set; }
		private decimal? _whereConst_nx_avail_pat15;
		public decimal? WhereConst_nx_avail_pat16 { get; set; }
		private decimal? _whereConst_nx_avail_pat16;
		public decimal? WhereConst_nx_avail_pat17 { get; set; }
		private decimal? _whereConst_nx_avail_pat17;
		public decimal? WhereConst_nx_avail_pat18 { get; set; }
		private decimal? _whereConst_nx_avail_pat18;
		public decimal? WhereConst_nx_avail_pat19 { get; set; }
		private decimal? _whereConst_nx_avail_pat19;
		public decimal? WhereConst_nx_avail_pat20 { get; set; }
		private decimal? _whereConst_nx_avail_pat20;
		public decimal? WhereConst_nx_avail_pat21 { get; set; }
		private decimal? _whereConst_nx_avail_pat21;
		public decimal? WhereConst_nx_avail_pat22 { get; set; }
		private decimal? _whereConst_nx_avail_pat22;
		public decimal? WhereConst_nx_avail_pat23 { get; set; }
		private decimal? _whereConst_nx_avail_pat23;
		public decimal? WhereConst_nx_avail_pat24 { get; set; }
		private decimal? _whereConst_nx_avail_pat24;
		public decimal? WhereConst_nx_avail_pat25 { get; set; }
		private decimal? _whereConst_nx_avail_pat25;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_con_nbr1;
		private decimal? _originalConst_con_nbr2;
		private decimal? _originalConst_con_nbr3;
		private decimal? _originalConst_con_nbr4;
		private decimal? _originalConst_con_nbr5;
		private decimal? _originalConst_con_nbr6;
		private decimal? _originalConst_con_nbr7;
		private decimal? _originalConst_con_nbr8;
		private decimal? _originalConst_con_nbr9;
		private decimal? _originalConst_con_nbr10;
		private decimal? _originalConst_con_nbr11;
		private decimal? _originalConst_con_nbr12;
		private decimal? _originalConst_con_nbr13;
		private decimal? _originalConst_con_nbr14;
		private decimal? _originalConst_con_nbr15;
		private decimal? _originalConst_con_nbr16;
		private decimal? _originalConst_con_nbr17;
		private decimal? _originalConst_con_nbr18;
		private decimal? _originalConst_con_nbr19;
		private decimal? _originalConst_con_nbr20;
		private decimal? _originalConst_con_nbr21;
		private decimal? _originalConst_con_nbr22;
		private decimal? _originalConst_con_nbr23;
		private decimal? _originalConst_con_nbr24;
		private decimal? _originalConst_con_nbr25;
		private decimal? _originalConst_nx_avail_pat1;
		private decimal? _originalConst_nx_avail_pat2;
		private decimal? _originalConst_nx_avail_pat3;
		private decimal? _originalConst_nx_avail_pat4;
		private decimal? _originalConst_nx_avail_pat5;
		private decimal? _originalConst_nx_avail_pat6;
		private decimal? _originalConst_nx_avail_pat7;
		private decimal? _originalConst_nx_avail_pat8;
		private decimal? _originalConst_nx_avail_pat9;
		private decimal? _originalConst_nx_avail_pat10;
		private decimal? _originalConst_nx_avail_pat11;
		private decimal? _originalConst_nx_avail_pat12;
		private decimal? _originalConst_nx_avail_pat13;
		private decimal? _originalConst_nx_avail_pat14;
		private decimal? _originalConst_nx_avail_pat15;
		private decimal? _originalConst_nx_avail_pat16;
		private decimal? _originalConst_nx_avail_pat17;
		private decimal? _originalConst_nx_avail_pat18;
		private decimal? _originalConst_nx_avail_pat19;
		private decimal? _originalConst_nx_avail_pat20;
		private decimal? _originalConst_nx_avail_pat21;
		private decimal? _originalConst_nx_avail_pat22;
		private decimal? _originalConst_nx_avail_pat23;
		private decimal? _originalConst_nx_avail_pat24;
		private decimal? _originalConst_nx_avail_pat25;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_CON_NBR1 = _originalConst_con_nbr1;
			CONST_CON_NBR2 = _originalConst_con_nbr2;
			CONST_CON_NBR3 = _originalConst_con_nbr3;
			CONST_CON_NBR4 = _originalConst_con_nbr4;
			CONST_CON_NBR5 = _originalConst_con_nbr5;
			CONST_CON_NBR6 = _originalConst_con_nbr6;
			CONST_CON_NBR7 = _originalConst_con_nbr7;
			CONST_CON_NBR8 = _originalConst_con_nbr8;
			CONST_CON_NBR9 = _originalConst_con_nbr9;
			CONST_CON_NBR10 = _originalConst_con_nbr10;
			CONST_CON_NBR11 = _originalConst_con_nbr11;
			CONST_CON_NBR12 = _originalConst_con_nbr12;
			CONST_CON_NBR13 = _originalConst_con_nbr13;
			CONST_CON_NBR14 = _originalConst_con_nbr14;
			CONST_CON_NBR15 = _originalConst_con_nbr15;
			CONST_CON_NBR16 = _originalConst_con_nbr16;
			CONST_CON_NBR17 = _originalConst_con_nbr17;
			CONST_CON_NBR18 = _originalConst_con_nbr18;
			CONST_CON_NBR19 = _originalConst_con_nbr19;
			CONST_CON_NBR20 = _originalConst_con_nbr20;
			CONST_CON_NBR21 = _originalConst_con_nbr21;
			CONST_CON_NBR22 = _originalConst_con_nbr22;
			CONST_CON_NBR23 = _originalConst_con_nbr23;
			CONST_CON_NBR24 = _originalConst_con_nbr24;
			CONST_CON_NBR25 = _originalConst_con_nbr25;
			CONST_NX_AVAIL_PAT1 = _originalConst_nx_avail_pat1;
			CONST_NX_AVAIL_PAT2 = _originalConst_nx_avail_pat2;
			CONST_NX_AVAIL_PAT3 = _originalConst_nx_avail_pat3;
			CONST_NX_AVAIL_PAT4 = _originalConst_nx_avail_pat4;
			CONST_NX_AVAIL_PAT5 = _originalConst_nx_avail_pat5;
			CONST_NX_AVAIL_PAT6 = _originalConst_nx_avail_pat6;
			CONST_NX_AVAIL_PAT7 = _originalConst_nx_avail_pat7;
			CONST_NX_AVAIL_PAT8 = _originalConst_nx_avail_pat8;
			CONST_NX_AVAIL_PAT9 = _originalConst_nx_avail_pat9;
			CONST_NX_AVAIL_PAT10 = _originalConst_nx_avail_pat10;
			CONST_NX_AVAIL_PAT11 = _originalConst_nx_avail_pat11;
			CONST_NX_AVAIL_PAT12 = _originalConst_nx_avail_pat12;
			CONST_NX_AVAIL_PAT13 = _originalConst_nx_avail_pat13;
			CONST_NX_AVAIL_PAT14 = _originalConst_nx_avail_pat14;
			CONST_NX_AVAIL_PAT15 = _originalConst_nx_avail_pat15;
			CONST_NX_AVAIL_PAT16 = _originalConst_nx_avail_pat16;
			CONST_NX_AVAIL_PAT17 = _originalConst_nx_avail_pat17;
			CONST_NX_AVAIL_PAT18 = _originalConst_nx_avail_pat18;
			CONST_NX_AVAIL_PAT19 = _originalConst_nx_avail_pat19;
			CONST_NX_AVAIL_PAT20 = _originalConst_nx_avail_pat20;
			CONST_NX_AVAIL_PAT21 = _originalConst_nx_avail_pat21;
			CONST_NX_AVAIL_PAT22 = _originalConst_nx_avail_pat22;
			CONST_NX_AVAIL_PAT23 = _originalConst_nx_avail_pat23;
			CONST_NX_AVAIL_PAT24 = _originalConst_nx_avail_pat24;
			CONST_NX_AVAIL_PAT25 = _originalConst_nx_avail_pat25;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_Purge]");
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
						new SqlParameter("CONST_CON_NBR1", SqlNull(CONST_CON_NBR1)),
						new SqlParameter("CONST_CON_NBR2", SqlNull(CONST_CON_NBR2)),
						new SqlParameter("CONST_CON_NBR3", SqlNull(CONST_CON_NBR3)),
						new SqlParameter("CONST_CON_NBR4", SqlNull(CONST_CON_NBR4)),
						new SqlParameter("CONST_CON_NBR5", SqlNull(CONST_CON_NBR5)),
						new SqlParameter("CONST_CON_NBR6", SqlNull(CONST_CON_NBR6)),
						new SqlParameter("CONST_CON_NBR7", SqlNull(CONST_CON_NBR7)),
						new SqlParameter("CONST_CON_NBR8", SqlNull(CONST_CON_NBR8)),
						new SqlParameter("CONST_CON_NBR9", SqlNull(CONST_CON_NBR9)),
						new SqlParameter("CONST_CON_NBR10", SqlNull(CONST_CON_NBR10)),
						new SqlParameter("CONST_CON_NBR11", SqlNull(CONST_CON_NBR11)),
						new SqlParameter("CONST_CON_NBR12", SqlNull(CONST_CON_NBR12)),
						new SqlParameter("CONST_CON_NBR13", SqlNull(CONST_CON_NBR13)),
						new SqlParameter("CONST_CON_NBR14", SqlNull(CONST_CON_NBR14)),
						new SqlParameter("CONST_CON_NBR15", SqlNull(CONST_CON_NBR15)),
						new SqlParameter("CONST_CON_NBR16", SqlNull(CONST_CON_NBR16)),
						new SqlParameter("CONST_CON_NBR17", SqlNull(CONST_CON_NBR17)),
						new SqlParameter("CONST_CON_NBR18", SqlNull(CONST_CON_NBR18)),
						new SqlParameter("CONST_CON_NBR19", SqlNull(CONST_CON_NBR19)),
						new SqlParameter("CONST_CON_NBR20", SqlNull(CONST_CON_NBR20)),
						new SqlParameter("CONST_CON_NBR21", SqlNull(CONST_CON_NBR21)),
						new SqlParameter("CONST_CON_NBR22", SqlNull(CONST_CON_NBR22)),
						new SqlParameter("CONST_CON_NBR23", SqlNull(CONST_CON_NBR23)),
						new SqlParameter("CONST_CON_NBR24", SqlNull(CONST_CON_NBR24)),
						new SqlParameter("CONST_CON_NBR25", SqlNull(CONST_CON_NBR25)),
						new SqlParameter("CONST_NX_AVAIL_PAT1", SqlNull(CONST_NX_AVAIL_PAT1)),
						new SqlParameter("CONST_NX_AVAIL_PAT2", SqlNull(CONST_NX_AVAIL_PAT2)),
						new SqlParameter("CONST_NX_AVAIL_PAT3", SqlNull(CONST_NX_AVAIL_PAT3)),
						new SqlParameter("CONST_NX_AVAIL_PAT4", SqlNull(CONST_NX_AVAIL_PAT4)),
						new SqlParameter("CONST_NX_AVAIL_PAT5", SqlNull(CONST_NX_AVAIL_PAT5)),
						new SqlParameter("CONST_NX_AVAIL_PAT6", SqlNull(CONST_NX_AVAIL_PAT6)),
						new SqlParameter("CONST_NX_AVAIL_PAT7", SqlNull(CONST_NX_AVAIL_PAT7)),
						new SqlParameter("CONST_NX_AVAIL_PAT8", SqlNull(CONST_NX_AVAIL_PAT8)),
						new SqlParameter("CONST_NX_AVAIL_PAT9", SqlNull(CONST_NX_AVAIL_PAT9)),
						new SqlParameter("CONST_NX_AVAIL_PAT10", SqlNull(CONST_NX_AVAIL_PAT10)),
						new SqlParameter("CONST_NX_AVAIL_PAT11", SqlNull(CONST_NX_AVAIL_PAT11)),
						new SqlParameter("CONST_NX_AVAIL_PAT12", SqlNull(CONST_NX_AVAIL_PAT12)),
						new SqlParameter("CONST_NX_AVAIL_PAT13", SqlNull(CONST_NX_AVAIL_PAT13)),
						new SqlParameter("CONST_NX_AVAIL_PAT14", SqlNull(CONST_NX_AVAIL_PAT14)),
						new SqlParameter("CONST_NX_AVAIL_PAT15", SqlNull(CONST_NX_AVAIL_PAT15)),
						new SqlParameter("CONST_NX_AVAIL_PAT16", SqlNull(CONST_NX_AVAIL_PAT16)),
						new SqlParameter("CONST_NX_AVAIL_PAT17", SqlNull(CONST_NX_AVAIL_PAT17)),
						new SqlParameter("CONST_NX_AVAIL_PAT18", SqlNull(CONST_NX_AVAIL_PAT18)),
						new SqlParameter("CONST_NX_AVAIL_PAT19", SqlNull(CONST_NX_AVAIL_PAT19)),
						new SqlParameter("CONST_NX_AVAIL_PAT20", SqlNull(CONST_NX_AVAIL_PAT20)),
						new SqlParameter("CONST_NX_AVAIL_PAT21", SqlNull(CONST_NX_AVAIL_PAT21)),
						new SqlParameter("CONST_NX_AVAIL_PAT22", SqlNull(CONST_NX_AVAIL_PAT22)),
						new SqlParameter("CONST_NX_AVAIL_PAT23", SqlNull(CONST_NX_AVAIL_PAT23)),
						new SqlParameter("CONST_NX_AVAIL_PAT24", SqlNull(CONST_NX_AVAIL_PAT24)),
						new SqlParameter("CONST_NX_AVAIL_PAT25", SqlNull(CONST_NX_AVAIL_PAT25)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_CON_NBR1 = ConvertDEC(Reader["CONST_CON_NBR1"]);
						CONST_CON_NBR2 = ConvertDEC(Reader["CONST_CON_NBR2"]);
						CONST_CON_NBR3 = ConvertDEC(Reader["CONST_CON_NBR3"]);
						CONST_CON_NBR4 = ConvertDEC(Reader["CONST_CON_NBR4"]);
						CONST_CON_NBR5 = ConvertDEC(Reader["CONST_CON_NBR5"]);
						CONST_CON_NBR6 = ConvertDEC(Reader["CONST_CON_NBR6"]);
						CONST_CON_NBR7 = ConvertDEC(Reader["CONST_CON_NBR7"]);
						CONST_CON_NBR8 = ConvertDEC(Reader["CONST_CON_NBR8"]);
						CONST_CON_NBR9 = ConvertDEC(Reader["CONST_CON_NBR9"]);
						CONST_CON_NBR10 = ConvertDEC(Reader["CONST_CON_NBR10"]);
						CONST_CON_NBR11 = ConvertDEC(Reader["CONST_CON_NBR11"]);
						CONST_CON_NBR12 = ConvertDEC(Reader["CONST_CON_NBR12"]);
						CONST_CON_NBR13 = ConvertDEC(Reader["CONST_CON_NBR13"]);
						CONST_CON_NBR14 = ConvertDEC(Reader["CONST_CON_NBR14"]);
						CONST_CON_NBR15 = ConvertDEC(Reader["CONST_CON_NBR15"]);
						CONST_CON_NBR16 = ConvertDEC(Reader["CONST_CON_NBR16"]);
						CONST_CON_NBR17 = ConvertDEC(Reader["CONST_CON_NBR17"]);
						CONST_CON_NBR18 = ConvertDEC(Reader["CONST_CON_NBR18"]);
						CONST_CON_NBR19 = ConvertDEC(Reader["CONST_CON_NBR19"]);
						CONST_CON_NBR20 = ConvertDEC(Reader["CONST_CON_NBR20"]);
						CONST_CON_NBR21 = ConvertDEC(Reader["CONST_CON_NBR21"]);
						CONST_CON_NBR22 = ConvertDEC(Reader["CONST_CON_NBR22"]);
						CONST_CON_NBR23 = ConvertDEC(Reader["CONST_CON_NBR23"]);
						CONST_CON_NBR24 = ConvertDEC(Reader["CONST_CON_NBR24"]);
						CONST_CON_NBR25 = ConvertDEC(Reader["CONST_CON_NBR25"]);
						CONST_NX_AVAIL_PAT1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]);
						CONST_NX_AVAIL_PAT2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]);
						CONST_NX_AVAIL_PAT3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]);
						CONST_NX_AVAIL_PAT4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]);
						CONST_NX_AVAIL_PAT5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]);
						CONST_NX_AVAIL_PAT6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]);
						CONST_NX_AVAIL_PAT7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]);
						CONST_NX_AVAIL_PAT8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]);
						CONST_NX_AVAIL_PAT9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]);
						CONST_NX_AVAIL_PAT10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]);
						CONST_NX_AVAIL_PAT11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]);
						CONST_NX_AVAIL_PAT12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]);
						CONST_NX_AVAIL_PAT13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]);
						CONST_NX_AVAIL_PAT14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]);
						CONST_NX_AVAIL_PAT15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]);
						CONST_NX_AVAIL_PAT16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]);
						CONST_NX_AVAIL_PAT17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]);
						CONST_NX_AVAIL_PAT18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]);
						CONST_NX_AVAIL_PAT19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]);
						CONST_NX_AVAIL_PAT20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]);
						CONST_NX_AVAIL_PAT21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]);
						CONST_NX_AVAIL_PAT22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]);
						CONST_NX_AVAIL_PAT23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]);
						CONST_NX_AVAIL_PAT24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]);
						CONST_NX_AVAIL_PAT25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_con_nbr1 = ConvertDEC(Reader["CONST_CON_NBR1"]);
						_originalConst_con_nbr2 = ConvertDEC(Reader["CONST_CON_NBR2"]);
						_originalConst_con_nbr3 = ConvertDEC(Reader["CONST_CON_NBR3"]);
						_originalConst_con_nbr4 = ConvertDEC(Reader["CONST_CON_NBR4"]);
						_originalConst_con_nbr5 = ConvertDEC(Reader["CONST_CON_NBR5"]);
						_originalConst_con_nbr6 = ConvertDEC(Reader["CONST_CON_NBR6"]);
						_originalConst_con_nbr7 = ConvertDEC(Reader["CONST_CON_NBR7"]);
						_originalConst_con_nbr8 = ConvertDEC(Reader["CONST_CON_NBR8"]);
						_originalConst_con_nbr9 = ConvertDEC(Reader["CONST_CON_NBR9"]);
						_originalConst_con_nbr10 = ConvertDEC(Reader["CONST_CON_NBR10"]);
						_originalConst_con_nbr11 = ConvertDEC(Reader["CONST_CON_NBR11"]);
						_originalConst_con_nbr12 = ConvertDEC(Reader["CONST_CON_NBR12"]);
						_originalConst_con_nbr13 = ConvertDEC(Reader["CONST_CON_NBR13"]);
						_originalConst_con_nbr14 = ConvertDEC(Reader["CONST_CON_NBR14"]);
						_originalConst_con_nbr15 = ConvertDEC(Reader["CONST_CON_NBR15"]);
						_originalConst_con_nbr16 = ConvertDEC(Reader["CONST_CON_NBR16"]);
						_originalConst_con_nbr17 = ConvertDEC(Reader["CONST_CON_NBR17"]);
						_originalConst_con_nbr18 = ConvertDEC(Reader["CONST_CON_NBR18"]);
						_originalConst_con_nbr19 = ConvertDEC(Reader["CONST_CON_NBR19"]);
						_originalConst_con_nbr20 = ConvertDEC(Reader["CONST_CON_NBR20"]);
						_originalConst_con_nbr21 = ConvertDEC(Reader["CONST_CON_NBR21"]);
						_originalConst_con_nbr22 = ConvertDEC(Reader["CONST_CON_NBR22"]);
						_originalConst_con_nbr23 = ConvertDEC(Reader["CONST_CON_NBR23"]);
						_originalConst_con_nbr24 = ConvertDEC(Reader["CONST_CON_NBR24"]);
						_originalConst_con_nbr25 = ConvertDEC(Reader["CONST_CON_NBR25"]);
						_originalConst_nx_avail_pat1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]);
						_originalConst_nx_avail_pat2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]);
						_originalConst_nx_avail_pat3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]);
						_originalConst_nx_avail_pat4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]);
						_originalConst_nx_avail_pat5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]);
						_originalConst_nx_avail_pat6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]);
						_originalConst_nx_avail_pat7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]);
						_originalConst_nx_avail_pat8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]);
						_originalConst_nx_avail_pat9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]);
						_originalConst_nx_avail_pat10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]);
						_originalConst_nx_avail_pat11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]);
						_originalConst_nx_avail_pat12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]);
						_originalConst_nx_avail_pat13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]);
						_originalConst_nx_avail_pat14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]);
						_originalConst_nx_avail_pat15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]);
						_originalConst_nx_avail_pat16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]);
						_originalConst_nx_avail_pat17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]);
						_originalConst_nx_avail_pat18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]);
						_originalConst_nx_avail_pat19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]);
						_originalConst_nx_avail_pat20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]);
						_originalConst_nx_avail_pat21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]);
						_originalConst_nx_avail_pat22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]);
						_originalConst_nx_avail_pat23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]);
						_originalConst_nx_avail_pat24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]);
						_originalConst_nx_avail_pat25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]);
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
						new SqlParameter("CONST_CON_NBR1", SqlNull(CONST_CON_NBR1)),
						new SqlParameter("CONST_CON_NBR2", SqlNull(CONST_CON_NBR2)),
						new SqlParameter("CONST_CON_NBR3", SqlNull(CONST_CON_NBR3)),
						new SqlParameter("CONST_CON_NBR4", SqlNull(CONST_CON_NBR4)),
						new SqlParameter("CONST_CON_NBR5", SqlNull(CONST_CON_NBR5)),
						new SqlParameter("CONST_CON_NBR6", SqlNull(CONST_CON_NBR6)),
						new SqlParameter("CONST_CON_NBR7", SqlNull(CONST_CON_NBR7)),
						new SqlParameter("CONST_CON_NBR8", SqlNull(CONST_CON_NBR8)),
						new SqlParameter("CONST_CON_NBR9", SqlNull(CONST_CON_NBR9)),
						new SqlParameter("CONST_CON_NBR10", SqlNull(CONST_CON_NBR10)),
						new SqlParameter("CONST_CON_NBR11", SqlNull(CONST_CON_NBR11)),
						new SqlParameter("CONST_CON_NBR12", SqlNull(CONST_CON_NBR12)),
						new SqlParameter("CONST_CON_NBR13", SqlNull(CONST_CON_NBR13)),
						new SqlParameter("CONST_CON_NBR14", SqlNull(CONST_CON_NBR14)),
						new SqlParameter("CONST_CON_NBR15", SqlNull(CONST_CON_NBR15)),
						new SqlParameter("CONST_CON_NBR16", SqlNull(CONST_CON_NBR16)),
						new SqlParameter("CONST_CON_NBR17", SqlNull(CONST_CON_NBR17)),
						new SqlParameter("CONST_CON_NBR18", SqlNull(CONST_CON_NBR18)),
						new SqlParameter("CONST_CON_NBR19", SqlNull(CONST_CON_NBR19)),
						new SqlParameter("CONST_CON_NBR20", SqlNull(CONST_CON_NBR20)),
						new SqlParameter("CONST_CON_NBR21", SqlNull(CONST_CON_NBR21)),
						new SqlParameter("CONST_CON_NBR22", SqlNull(CONST_CON_NBR22)),
						new SqlParameter("CONST_CON_NBR23", SqlNull(CONST_CON_NBR23)),
						new SqlParameter("CONST_CON_NBR24", SqlNull(CONST_CON_NBR24)),
						new SqlParameter("CONST_CON_NBR25", SqlNull(CONST_CON_NBR25)),
						new SqlParameter("CONST_NX_AVAIL_PAT1", SqlNull(CONST_NX_AVAIL_PAT1)),
						new SqlParameter("CONST_NX_AVAIL_PAT2", SqlNull(CONST_NX_AVAIL_PAT2)),
						new SqlParameter("CONST_NX_AVAIL_PAT3", SqlNull(CONST_NX_AVAIL_PAT3)),
						new SqlParameter("CONST_NX_AVAIL_PAT4", SqlNull(CONST_NX_AVAIL_PAT4)),
						new SqlParameter("CONST_NX_AVAIL_PAT5", SqlNull(CONST_NX_AVAIL_PAT5)),
						new SqlParameter("CONST_NX_AVAIL_PAT6", SqlNull(CONST_NX_AVAIL_PAT6)),
						new SqlParameter("CONST_NX_AVAIL_PAT7", SqlNull(CONST_NX_AVAIL_PAT7)),
						new SqlParameter("CONST_NX_AVAIL_PAT8", SqlNull(CONST_NX_AVAIL_PAT8)),
						new SqlParameter("CONST_NX_AVAIL_PAT9", SqlNull(CONST_NX_AVAIL_PAT9)),
						new SqlParameter("CONST_NX_AVAIL_PAT10", SqlNull(CONST_NX_AVAIL_PAT10)),
						new SqlParameter("CONST_NX_AVAIL_PAT11", SqlNull(CONST_NX_AVAIL_PAT11)),
						new SqlParameter("CONST_NX_AVAIL_PAT12", SqlNull(CONST_NX_AVAIL_PAT12)),
						new SqlParameter("CONST_NX_AVAIL_PAT13", SqlNull(CONST_NX_AVAIL_PAT13)),
						new SqlParameter("CONST_NX_AVAIL_PAT14", SqlNull(CONST_NX_AVAIL_PAT14)),
						new SqlParameter("CONST_NX_AVAIL_PAT15", SqlNull(CONST_NX_AVAIL_PAT15)),
						new SqlParameter("CONST_NX_AVAIL_PAT16", SqlNull(CONST_NX_AVAIL_PAT16)),
						new SqlParameter("CONST_NX_AVAIL_PAT17", SqlNull(CONST_NX_AVAIL_PAT17)),
						new SqlParameter("CONST_NX_AVAIL_PAT18", SqlNull(CONST_NX_AVAIL_PAT18)),
						new SqlParameter("CONST_NX_AVAIL_PAT19", SqlNull(CONST_NX_AVAIL_PAT19)),
						new SqlParameter("CONST_NX_AVAIL_PAT20", SqlNull(CONST_NX_AVAIL_PAT20)),
						new SqlParameter("CONST_NX_AVAIL_PAT21", SqlNull(CONST_NX_AVAIL_PAT21)),
						new SqlParameter("CONST_NX_AVAIL_PAT22", SqlNull(CONST_NX_AVAIL_PAT22)),
						new SqlParameter("CONST_NX_AVAIL_PAT23", SqlNull(CONST_NX_AVAIL_PAT23)),
						new SqlParameter("CONST_NX_AVAIL_PAT24", SqlNull(CONST_NX_AVAIL_PAT24)),
						new SqlParameter("CONST_NX_AVAIL_PAT25", SqlNull(CONST_NX_AVAIL_PAT25)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_5_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_CON_NBR1 = ConvertDEC(Reader["CONST_CON_NBR1"]);
						CONST_CON_NBR2 = ConvertDEC(Reader["CONST_CON_NBR2"]);
						CONST_CON_NBR3 = ConvertDEC(Reader["CONST_CON_NBR3"]);
						CONST_CON_NBR4 = ConvertDEC(Reader["CONST_CON_NBR4"]);
						CONST_CON_NBR5 = ConvertDEC(Reader["CONST_CON_NBR5"]);
						CONST_CON_NBR6 = ConvertDEC(Reader["CONST_CON_NBR6"]);
						CONST_CON_NBR7 = ConvertDEC(Reader["CONST_CON_NBR7"]);
						CONST_CON_NBR8 = ConvertDEC(Reader["CONST_CON_NBR8"]);
						CONST_CON_NBR9 = ConvertDEC(Reader["CONST_CON_NBR9"]);
						CONST_CON_NBR10 = ConvertDEC(Reader["CONST_CON_NBR10"]);
						CONST_CON_NBR11 = ConvertDEC(Reader["CONST_CON_NBR11"]);
						CONST_CON_NBR12 = ConvertDEC(Reader["CONST_CON_NBR12"]);
						CONST_CON_NBR13 = ConvertDEC(Reader["CONST_CON_NBR13"]);
						CONST_CON_NBR14 = ConvertDEC(Reader["CONST_CON_NBR14"]);
						CONST_CON_NBR15 = ConvertDEC(Reader["CONST_CON_NBR15"]);
						CONST_CON_NBR16 = ConvertDEC(Reader["CONST_CON_NBR16"]);
						CONST_CON_NBR17 = ConvertDEC(Reader["CONST_CON_NBR17"]);
						CONST_CON_NBR18 = ConvertDEC(Reader["CONST_CON_NBR18"]);
						CONST_CON_NBR19 = ConvertDEC(Reader["CONST_CON_NBR19"]);
						CONST_CON_NBR20 = ConvertDEC(Reader["CONST_CON_NBR20"]);
						CONST_CON_NBR21 = ConvertDEC(Reader["CONST_CON_NBR21"]);
						CONST_CON_NBR22 = ConvertDEC(Reader["CONST_CON_NBR22"]);
						CONST_CON_NBR23 = ConvertDEC(Reader["CONST_CON_NBR23"]);
						CONST_CON_NBR24 = ConvertDEC(Reader["CONST_CON_NBR24"]);
						CONST_CON_NBR25 = ConvertDEC(Reader["CONST_CON_NBR25"]);
						CONST_NX_AVAIL_PAT1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]);
						CONST_NX_AVAIL_PAT2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]);
						CONST_NX_AVAIL_PAT3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]);
						CONST_NX_AVAIL_PAT4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]);
						CONST_NX_AVAIL_PAT5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]);
						CONST_NX_AVAIL_PAT6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]);
						CONST_NX_AVAIL_PAT7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]);
						CONST_NX_AVAIL_PAT8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]);
						CONST_NX_AVAIL_PAT9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]);
						CONST_NX_AVAIL_PAT10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]);
						CONST_NX_AVAIL_PAT11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]);
						CONST_NX_AVAIL_PAT12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]);
						CONST_NX_AVAIL_PAT13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]);
						CONST_NX_AVAIL_PAT14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]);
						CONST_NX_AVAIL_PAT15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]);
						CONST_NX_AVAIL_PAT16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]);
						CONST_NX_AVAIL_PAT17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]);
						CONST_NX_AVAIL_PAT18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]);
						CONST_NX_AVAIL_PAT19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]);
						CONST_NX_AVAIL_PAT20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]);
						CONST_NX_AVAIL_PAT21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]);
						CONST_NX_AVAIL_PAT22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]);
						CONST_NX_AVAIL_PAT23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]);
						CONST_NX_AVAIL_PAT24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]);
						CONST_NX_AVAIL_PAT25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_con_nbr1 = ConvertDEC(Reader["CONST_CON_NBR1"]);
						_originalConst_con_nbr2 = ConvertDEC(Reader["CONST_CON_NBR2"]);
						_originalConst_con_nbr3 = ConvertDEC(Reader["CONST_CON_NBR3"]);
						_originalConst_con_nbr4 = ConvertDEC(Reader["CONST_CON_NBR4"]);
						_originalConst_con_nbr5 = ConvertDEC(Reader["CONST_CON_NBR5"]);
						_originalConst_con_nbr6 = ConvertDEC(Reader["CONST_CON_NBR6"]);
						_originalConst_con_nbr7 = ConvertDEC(Reader["CONST_CON_NBR7"]);
						_originalConst_con_nbr8 = ConvertDEC(Reader["CONST_CON_NBR8"]);
						_originalConst_con_nbr9 = ConvertDEC(Reader["CONST_CON_NBR9"]);
						_originalConst_con_nbr10 = ConvertDEC(Reader["CONST_CON_NBR10"]);
						_originalConst_con_nbr11 = ConvertDEC(Reader["CONST_CON_NBR11"]);
						_originalConst_con_nbr12 = ConvertDEC(Reader["CONST_CON_NBR12"]);
						_originalConst_con_nbr13 = ConvertDEC(Reader["CONST_CON_NBR13"]);
						_originalConst_con_nbr14 = ConvertDEC(Reader["CONST_CON_NBR14"]);
						_originalConst_con_nbr15 = ConvertDEC(Reader["CONST_CON_NBR15"]);
						_originalConst_con_nbr16 = ConvertDEC(Reader["CONST_CON_NBR16"]);
						_originalConst_con_nbr17 = ConvertDEC(Reader["CONST_CON_NBR17"]);
						_originalConst_con_nbr18 = ConvertDEC(Reader["CONST_CON_NBR18"]);
						_originalConst_con_nbr19 = ConvertDEC(Reader["CONST_CON_NBR19"]);
						_originalConst_con_nbr20 = ConvertDEC(Reader["CONST_CON_NBR20"]);
						_originalConst_con_nbr21 = ConvertDEC(Reader["CONST_CON_NBR21"]);
						_originalConst_con_nbr22 = ConvertDEC(Reader["CONST_CON_NBR22"]);
						_originalConst_con_nbr23 = ConvertDEC(Reader["CONST_CON_NBR23"]);
						_originalConst_con_nbr24 = ConvertDEC(Reader["CONST_CON_NBR24"]);
						_originalConst_con_nbr25 = ConvertDEC(Reader["CONST_CON_NBR25"]);
						_originalConst_nx_avail_pat1 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT1"]);
						_originalConst_nx_avail_pat2 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT2"]);
						_originalConst_nx_avail_pat3 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT3"]);
						_originalConst_nx_avail_pat4 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT4"]);
						_originalConst_nx_avail_pat5 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT5"]);
						_originalConst_nx_avail_pat6 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT6"]);
						_originalConst_nx_avail_pat7 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT7"]);
						_originalConst_nx_avail_pat8 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT8"]);
						_originalConst_nx_avail_pat9 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT9"]);
						_originalConst_nx_avail_pat10 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT10"]);
						_originalConst_nx_avail_pat11 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT11"]);
						_originalConst_nx_avail_pat12 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT12"]);
						_originalConst_nx_avail_pat13 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT13"]);
						_originalConst_nx_avail_pat14 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT14"]);
						_originalConst_nx_avail_pat15 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT15"]);
						_originalConst_nx_avail_pat16 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT16"]);
						_originalConst_nx_avail_pat17 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT17"]);
						_originalConst_nx_avail_pat18 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT18"]);
						_originalConst_nx_avail_pat19 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT19"]);
						_originalConst_nx_avail_pat20 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT20"]);
						_originalConst_nx_avail_pat21 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT21"]);
						_originalConst_nx_avail_pat22 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT22"]);
						_originalConst_nx_avail_pat23 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT23"]);
						_originalConst_nx_avail_pat24 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT24"]);
						_originalConst_nx_avail_pat25 = ConvertDEC(Reader["CONST_NX_AVAIL_PAT25"]);
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