using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_1 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_1> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_max_nbr_clinicsmin,
															decimal? const_max_nbr_clinicsmax,
															decimal? const_clinic_nbr_1_21min,
															decimal? const_clinic_nbr_1_21max,
															decimal? const_clinic_nbr_1_22min,
															decimal? const_clinic_nbr_1_22max,
															decimal? const_clinic_nbr_1_23min,
															decimal? const_clinic_nbr_1_23max,
															decimal? const_clinic_nbr_1_24min,
															decimal? const_clinic_nbr_1_24max,
															decimal? const_clinic_nbr_1_25min,
															decimal? const_clinic_nbr_1_25max,
															decimal? const_clinic_nbr_1_26min,
															decimal? const_clinic_nbr_1_26max,
															decimal? const_clinic_nbr_1_27min,
															decimal? const_clinic_nbr_1_27max,
															decimal? const_clinic_nbr_1_28min,
															decimal? const_clinic_nbr_1_28max,
															decimal? const_clinic_nbr_1_29min,
															decimal? const_clinic_nbr_1_29max,
															decimal? const_clinic_nbr_1_210min,
															decimal? const_clinic_nbr_1_210max,
															decimal? const_clinic_nbr_1_211min,
															decimal? const_clinic_nbr_1_211max,
															decimal? const_clinic_nbr_1_212min,
															decimal? const_clinic_nbr_1_212max,
															decimal? const_clinic_nbr_1_213min,
															decimal? const_clinic_nbr_1_213max,
															decimal? const_clinic_nbr_1_214min,
															decimal? const_clinic_nbr_1_214max,
															decimal? const_clinic_nbr_1_215min,
															decimal? const_clinic_nbr_1_215max,
															decimal? const_clinic_nbr_1_216min,
															decimal? const_clinic_nbr_1_216max,
															decimal? const_clinic_nbr_1_217min,
															decimal? const_clinic_nbr_1_217max,
															decimal? const_clinic_nbr_1_218min,
															decimal? const_clinic_nbr_1_218max,
															decimal? const_clinic_nbr_1_219min,
															decimal? const_clinic_nbr_1_219max,
															decimal? const_clinic_nbr_1_220min,
															decimal? const_clinic_nbr_1_220max,
															decimal? const_clinic_nbr_1_221min,
															decimal? const_clinic_nbr_1_221max,
															decimal? const_clinic_nbr_1_222min,
															decimal? const_clinic_nbr_1_222max,
															decimal? const_clinic_nbr_1_223min,
															decimal? const_clinic_nbr_1_223max,
															decimal? const_clinic_nbr_1_224min,
															decimal? const_clinic_nbr_1_224max,
															decimal? const_clinic_nbr_1_225min,
															decimal? const_clinic_nbr_1_225max,
															decimal? const_clinic_nbr_1_226min,
															decimal? const_clinic_nbr_1_226max,
															decimal? const_clinic_nbr_1_227min,
															decimal? const_clinic_nbr_1_227max,
															decimal? const_clinic_nbr_1_228min,
															decimal? const_clinic_nbr_1_228max,
															decimal? const_clinic_nbr_1_229min,
															decimal? const_clinic_nbr_1_229max,
															decimal? const_clinic_nbr_1_230min,
															decimal? const_clinic_nbr_1_230max,
															decimal? const_clinic_nbr_1_231min,
															decimal? const_clinic_nbr_1_231max,
															decimal? const_clinic_nbr_1_232min,
															decimal? const_clinic_nbr_1_232max,
															decimal? const_clinic_nbr_1_233min,
															decimal? const_clinic_nbr_1_233max,
															decimal? const_clinic_nbr_1_234min,
															decimal? const_clinic_nbr_1_234max,
															decimal? const_clinic_nbr_1_235min,
															decimal? const_clinic_nbr_1_235max,
															decimal? const_clinic_nbr_1_236min,
															decimal? const_clinic_nbr_1_236max,
															decimal? const_clinic_nbr_1_237min,
															decimal? const_clinic_nbr_1_237max,
															decimal? const_clinic_nbr_1_238min,
															decimal? const_clinic_nbr_1_238max,
															decimal? const_clinic_nbr_1_239min,
															decimal? const_clinic_nbr_1_239max,
															decimal? const_clinic_nbr_1_240min,
															decimal? const_clinic_nbr_1_240max,
															string const_clinic_nbr1,
															string const_clinic_nbr2,
															string const_clinic_nbr3,
															string const_clinic_nbr4,
															string const_clinic_nbr5,
															string const_clinic_nbr6,
															string const_clinic_nbr7,
															string const_clinic_nbr8,
															string const_clinic_nbr9,
															string const_clinic_nbr10,
															string const_clinic_nbr11,
															string const_clinic_nbr12,
															string const_clinic_nbr13,
															string const_clinic_nbr14,
															string const_clinic_nbr15,
															string const_clinic_nbr16,
															string const_clinic_nbr17,
															string const_clinic_nbr18,
															string const_clinic_nbr19,
															string const_clinic_nbr20,
															string const_clinic_nbr21,
															string const_clinic_nbr22,
															string const_clinic_nbr23,
															string const_clinic_nbr24,
															string const_clinic_nbr25,
															string const_clinic_nbr26,
															string const_clinic_nbr27,
															string const_clinic_nbr28,
															string const_clinic_nbr29,
															string const_clinic_nbr30,
															string const_clinic_nbr31,
															string const_clinic_nbr32,
															string const_clinic_nbr33,
															string const_clinic_nbr34,
															string const_clinic_nbr35,
															string const_clinic_nbr36,
															string const_clinic_nbr37,
															string const_clinic_nbr38,
															string const_clinic_nbr39,
															string const_clinic_nbr40,
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
					new SqlParameter("minCONST_MAX_NBR_CLINICS",const_max_nbr_clinicsmin),
					new SqlParameter("maxCONST_MAX_NBR_CLINICS",const_max_nbr_clinicsmax),
					new SqlParameter("minCONST_CLINIC_NBR_1_21",const_clinic_nbr_1_21min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_21",const_clinic_nbr_1_21max),
					new SqlParameter("minCONST_CLINIC_NBR_1_22",const_clinic_nbr_1_22min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_22",const_clinic_nbr_1_22max),
					new SqlParameter("minCONST_CLINIC_NBR_1_23",const_clinic_nbr_1_23min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_23",const_clinic_nbr_1_23max),
					new SqlParameter("minCONST_CLINIC_NBR_1_24",const_clinic_nbr_1_24min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_24",const_clinic_nbr_1_24max),
					new SqlParameter("minCONST_CLINIC_NBR_1_25",const_clinic_nbr_1_25min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_25",const_clinic_nbr_1_25max),
					new SqlParameter("minCONST_CLINIC_NBR_1_26",const_clinic_nbr_1_26min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_26",const_clinic_nbr_1_26max),
					new SqlParameter("minCONST_CLINIC_NBR_1_27",const_clinic_nbr_1_27min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_27",const_clinic_nbr_1_27max),
					new SqlParameter("minCONST_CLINIC_NBR_1_28",const_clinic_nbr_1_28min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_28",const_clinic_nbr_1_28max),
					new SqlParameter("minCONST_CLINIC_NBR_1_29",const_clinic_nbr_1_29min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_29",const_clinic_nbr_1_29max),
					new SqlParameter("minCONST_CLINIC_NBR_1_210",const_clinic_nbr_1_210min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_210",const_clinic_nbr_1_210max),
					new SqlParameter("minCONST_CLINIC_NBR_1_211",const_clinic_nbr_1_211min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_211",const_clinic_nbr_1_211max),
					new SqlParameter("minCONST_CLINIC_NBR_1_212",const_clinic_nbr_1_212min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_212",const_clinic_nbr_1_212max),
					new SqlParameter("minCONST_CLINIC_NBR_1_213",const_clinic_nbr_1_213min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_213",const_clinic_nbr_1_213max),
					new SqlParameter("minCONST_CLINIC_NBR_1_214",const_clinic_nbr_1_214min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_214",const_clinic_nbr_1_214max),
					new SqlParameter("minCONST_CLINIC_NBR_1_215",const_clinic_nbr_1_215min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_215",const_clinic_nbr_1_215max),
					new SqlParameter("minCONST_CLINIC_NBR_1_216",const_clinic_nbr_1_216min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_216",const_clinic_nbr_1_216max),
					new SqlParameter("minCONST_CLINIC_NBR_1_217",const_clinic_nbr_1_217min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_217",const_clinic_nbr_1_217max),
					new SqlParameter("minCONST_CLINIC_NBR_1_218",const_clinic_nbr_1_218min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_218",const_clinic_nbr_1_218max),
					new SqlParameter("minCONST_CLINIC_NBR_1_219",const_clinic_nbr_1_219min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_219",const_clinic_nbr_1_219max),
					new SqlParameter("minCONST_CLINIC_NBR_1_220",const_clinic_nbr_1_220min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_220",const_clinic_nbr_1_220max),
					new SqlParameter("minCONST_CLINIC_NBR_1_221",const_clinic_nbr_1_221min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_221",const_clinic_nbr_1_221max),
					new SqlParameter("minCONST_CLINIC_NBR_1_222",const_clinic_nbr_1_222min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_222",const_clinic_nbr_1_222max),
					new SqlParameter("minCONST_CLINIC_NBR_1_223",const_clinic_nbr_1_223min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_223",const_clinic_nbr_1_223max),
					new SqlParameter("minCONST_CLINIC_NBR_1_224",const_clinic_nbr_1_224min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_224",const_clinic_nbr_1_224max),
					new SqlParameter("minCONST_CLINIC_NBR_1_225",const_clinic_nbr_1_225min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_225",const_clinic_nbr_1_225max),
					new SqlParameter("minCONST_CLINIC_NBR_1_226",const_clinic_nbr_1_226min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_226",const_clinic_nbr_1_226max),
					new SqlParameter("minCONST_CLINIC_NBR_1_227",const_clinic_nbr_1_227min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_227",const_clinic_nbr_1_227max),
					new SqlParameter("minCONST_CLINIC_NBR_1_228",const_clinic_nbr_1_228min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_228",const_clinic_nbr_1_228max),
					new SqlParameter("minCONST_CLINIC_NBR_1_229",const_clinic_nbr_1_229min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_229",const_clinic_nbr_1_229max),
					new SqlParameter("minCONST_CLINIC_NBR_1_230",const_clinic_nbr_1_230min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_230",const_clinic_nbr_1_230max),
					new SqlParameter("minCONST_CLINIC_NBR_1_231",const_clinic_nbr_1_231min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_231",const_clinic_nbr_1_231max),
					new SqlParameter("minCONST_CLINIC_NBR_1_232",const_clinic_nbr_1_232min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_232",const_clinic_nbr_1_232max),
					new SqlParameter("minCONST_CLINIC_NBR_1_233",const_clinic_nbr_1_233min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_233",const_clinic_nbr_1_233max),
					new SqlParameter("minCONST_CLINIC_NBR_1_234",const_clinic_nbr_1_234min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_234",const_clinic_nbr_1_234max),
					new SqlParameter("minCONST_CLINIC_NBR_1_235",const_clinic_nbr_1_235min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_235",const_clinic_nbr_1_235max),
					new SqlParameter("minCONST_CLINIC_NBR_1_236",const_clinic_nbr_1_236min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_236",const_clinic_nbr_1_236max),
					new SqlParameter("minCONST_CLINIC_NBR_1_237",const_clinic_nbr_1_237min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_237",const_clinic_nbr_1_237max),
					new SqlParameter("minCONST_CLINIC_NBR_1_238",const_clinic_nbr_1_238min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_238",const_clinic_nbr_1_238max),
					new SqlParameter("minCONST_CLINIC_NBR_1_239",const_clinic_nbr_1_239min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_239",const_clinic_nbr_1_239max),
					new SqlParameter("minCONST_CLINIC_NBR_1_240",const_clinic_nbr_1_240min),
					new SqlParameter("maxCONST_CLINIC_NBR_1_240",const_clinic_nbr_1_240max),
					new SqlParameter("CONST_CLINIC_NBR1",const_clinic_nbr1),
					new SqlParameter("CONST_CLINIC_NBR2",const_clinic_nbr2),
					new SqlParameter("CONST_CLINIC_NBR3",const_clinic_nbr3),
					new SqlParameter("CONST_CLINIC_NBR4",const_clinic_nbr4),
					new SqlParameter("CONST_CLINIC_NBR5",const_clinic_nbr5),
					new SqlParameter("CONST_CLINIC_NBR6",const_clinic_nbr6),
					new SqlParameter("CONST_CLINIC_NBR7",const_clinic_nbr7),
					new SqlParameter("CONST_CLINIC_NBR8",const_clinic_nbr8),
					new SqlParameter("CONST_CLINIC_NBR9",const_clinic_nbr9),
					new SqlParameter("CONST_CLINIC_NBR10",const_clinic_nbr10),
					new SqlParameter("CONST_CLINIC_NBR11",const_clinic_nbr11),
					new SqlParameter("CONST_CLINIC_NBR12",const_clinic_nbr12),
					new SqlParameter("CONST_CLINIC_NBR13",const_clinic_nbr13),
					new SqlParameter("CONST_CLINIC_NBR14",const_clinic_nbr14),
					new SqlParameter("CONST_CLINIC_NBR15",const_clinic_nbr15),
					new SqlParameter("CONST_CLINIC_NBR16",const_clinic_nbr16),
					new SqlParameter("CONST_CLINIC_NBR17",const_clinic_nbr17),
					new SqlParameter("CONST_CLINIC_NBR18",const_clinic_nbr18),
					new SqlParameter("CONST_CLINIC_NBR19",const_clinic_nbr19),
					new SqlParameter("CONST_CLINIC_NBR20",const_clinic_nbr20),
					new SqlParameter("CONST_CLINIC_NBR21",const_clinic_nbr21),
					new SqlParameter("CONST_CLINIC_NBR22",const_clinic_nbr22),
					new SqlParameter("CONST_CLINIC_NBR23",const_clinic_nbr23),
					new SqlParameter("CONST_CLINIC_NBR24",const_clinic_nbr24),
					new SqlParameter("CONST_CLINIC_NBR25",const_clinic_nbr25),
					new SqlParameter("CONST_CLINIC_NBR26",const_clinic_nbr26),
					new SqlParameter("CONST_CLINIC_NBR27",const_clinic_nbr27),
					new SqlParameter("CONST_CLINIC_NBR28",const_clinic_nbr28),
					new SqlParameter("CONST_CLINIC_NBR29",const_clinic_nbr29),
					new SqlParameter("CONST_CLINIC_NBR30",const_clinic_nbr30),
					new SqlParameter("CONST_CLINIC_NBR31",const_clinic_nbr31),
					new SqlParameter("CONST_CLINIC_NBR32",const_clinic_nbr32),
					new SqlParameter("CONST_CLINIC_NBR33",const_clinic_nbr33),
					new SqlParameter("CONST_CLINIC_NBR34",const_clinic_nbr34),
					new SqlParameter("CONST_CLINIC_NBR35",const_clinic_nbr35),
					new SqlParameter("CONST_CLINIC_NBR36",const_clinic_nbr36),
					new SqlParameter("CONST_CLINIC_NBR37",const_clinic_nbr37),
					new SqlParameter("CONST_CLINIC_NBR38",const_clinic_nbr38),
					new SqlParameter("CONST_CLINIC_NBR39",const_clinic_nbr39),
					new SqlParameter("CONST_CLINIC_NBR40",const_clinic_nbr40),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_1>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_1
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_MAX_NBR_CLINICS = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]),
					CONST_CLINIC_NBR_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]),
					CONST_CLINIC_NBR_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]),
					CONST_CLINIC_NBR_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]),
					CONST_CLINIC_NBR_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]),
					CONST_CLINIC_NBR_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]),
					CONST_CLINIC_NBR_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]),
					CONST_CLINIC_NBR_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]),
					CONST_CLINIC_NBR_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]),
					CONST_CLINIC_NBR_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]),
					CONST_CLINIC_NBR_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]),
					CONST_CLINIC_NBR_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]),
					CONST_CLINIC_NBR_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]),
					CONST_CLINIC_NBR_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]),
					CONST_CLINIC_NBR_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]),
					CONST_CLINIC_NBR_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]),
					CONST_CLINIC_NBR_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]),
					CONST_CLINIC_NBR_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]),
					CONST_CLINIC_NBR_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]),
					CONST_CLINIC_NBR_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]),
					CONST_CLINIC_NBR_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]),
					CONST_CLINIC_NBR_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]),
					CONST_CLINIC_NBR_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]),
					CONST_CLINIC_NBR_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]),
					CONST_CLINIC_NBR_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]),
					CONST_CLINIC_NBR_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]),
					CONST_CLINIC_NBR_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]),
					CONST_CLINIC_NBR_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]),
					CONST_CLINIC_NBR_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]),
					CONST_CLINIC_NBR_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]),
					CONST_CLINIC_NBR_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]),
					CONST_CLINIC_NBR_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]),
					CONST_CLINIC_NBR_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]),
					CONST_CLINIC_NBR_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]),
					CONST_CLINIC_NBR_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]),
					CONST_CLINIC_NBR_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]),
					CONST_CLINIC_NBR_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]),
					CONST_CLINIC_NBR_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]),
					CONST_CLINIC_NBR_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]),
					CONST_CLINIC_NBR_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]),
					CONST_CLINIC_NBR_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]),
					CONST_CLINIC_NBR1 = Reader["CONST_CLINIC_NBR1"].ToString(),
					CONST_CLINIC_NBR2 = Reader["CONST_CLINIC_NBR2"].ToString(),
					CONST_CLINIC_NBR3 = Reader["CONST_CLINIC_NBR3"].ToString(),
					CONST_CLINIC_NBR4 = Reader["CONST_CLINIC_NBR4"].ToString(),
					CONST_CLINIC_NBR5 = Reader["CONST_CLINIC_NBR5"].ToString(),
					CONST_CLINIC_NBR6 = Reader["CONST_CLINIC_NBR6"].ToString(),
					CONST_CLINIC_NBR7 = Reader["CONST_CLINIC_NBR7"].ToString(),
					CONST_CLINIC_NBR8 = Reader["CONST_CLINIC_NBR8"].ToString(),
					CONST_CLINIC_NBR9 = Reader["CONST_CLINIC_NBR9"].ToString(),
					CONST_CLINIC_NBR10 = Reader["CONST_CLINIC_NBR10"].ToString(),
					CONST_CLINIC_NBR11 = Reader["CONST_CLINIC_NBR11"].ToString(),
					CONST_CLINIC_NBR12 = Reader["CONST_CLINIC_NBR12"].ToString(),
					CONST_CLINIC_NBR13 = Reader["CONST_CLINIC_NBR13"].ToString(),
					CONST_CLINIC_NBR14 = Reader["CONST_CLINIC_NBR14"].ToString(),
					CONST_CLINIC_NBR15 = Reader["CONST_CLINIC_NBR15"].ToString(),
					CONST_CLINIC_NBR16 = Reader["CONST_CLINIC_NBR16"].ToString(),
					CONST_CLINIC_NBR17 = Reader["CONST_CLINIC_NBR17"].ToString(),
					CONST_CLINIC_NBR18 = Reader["CONST_CLINIC_NBR18"].ToString(),
					CONST_CLINIC_NBR19 = Reader["CONST_CLINIC_NBR19"].ToString(),
					CONST_CLINIC_NBR20 = Reader["CONST_CLINIC_NBR20"].ToString(),
					CONST_CLINIC_NBR21 = Reader["CONST_CLINIC_NBR21"].ToString(),
					CONST_CLINIC_NBR22 = Reader["CONST_CLINIC_NBR22"].ToString(),
					CONST_CLINIC_NBR23 = Reader["CONST_CLINIC_NBR23"].ToString(),
					CONST_CLINIC_NBR24 = Reader["CONST_CLINIC_NBR24"].ToString(),
					CONST_CLINIC_NBR25 = Reader["CONST_CLINIC_NBR25"].ToString(),
					CONST_CLINIC_NBR26 = Reader["CONST_CLINIC_NBR26"].ToString(),
					CONST_CLINIC_NBR27 = Reader["CONST_CLINIC_NBR27"].ToString(),
					CONST_CLINIC_NBR28 = Reader["CONST_CLINIC_NBR28"].ToString(),
					CONST_CLINIC_NBR29 = Reader["CONST_CLINIC_NBR29"].ToString(),
					CONST_CLINIC_NBR30 = Reader["CONST_CLINIC_NBR30"].ToString(),
					CONST_CLINIC_NBR31 = Reader["CONST_CLINIC_NBR31"].ToString(),
					CONST_CLINIC_NBR32 = Reader["CONST_CLINIC_NBR32"].ToString(),
					CONST_CLINIC_NBR33 = Reader["CONST_CLINIC_NBR33"].ToString(),
					CONST_CLINIC_NBR34 = Reader["CONST_CLINIC_NBR34"].ToString(),
					CONST_CLINIC_NBR35 = Reader["CONST_CLINIC_NBR35"].ToString(),
					CONST_CLINIC_NBR36 = Reader["CONST_CLINIC_NBR36"].ToString(),
					CONST_CLINIC_NBR37 = Reader["CONST_CLINIC_NBR37"].ToString(),
					CONST_CLINIC_NBR38 = Reader["CONST_CLINIC_NBR38"].ToString(),
					CONST_CLINIC_NBR39 = Reader["CONST_CLINIC_NBR39"].ToString(),
					CONST_CLINIC_NBR40 = Reader["CONST_CLINIC_NBR40"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_max_nbr_clinics = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]),
					_originalConst_clinic_nbr_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]),
					_originalConst_clinic_nbr_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]),
					_originalConst_clinic_nbr_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]),
					_originalConst_clinic_nbr_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]),
					_originalConst_clinic_nbr_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]),
					_originalConst_clinic_nbr_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]),
					_originalConst_clinic_nbr_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]),
					_originalConst_clinic_nbr_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]),
					_originalConst_clinic_nbr_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]),
					_originalConst_clinic_nbr_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]),
					_originalConst_clinic_nbr_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]),
					_originalConst_clinic_nbr_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]),
					_originalConst_clinic_nbr_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]),
					_originalConst_clinic_nbr_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]),
					_originalConst_clinic_nbr_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]),
					_originalConst_clinic_nbr_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]),
					_originalConst_clinic_nbr_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]),
					_originalConst_clinic_nbr_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]),
					_originalConst_clinic_nbr_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]),
					_originalConst_clinic_nbr_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]),
					_originalConst_clinic_nbr_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]),
					_originalConst_clinic_nbr_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]),
					_originalConst_clinic_nbr_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]),
					_originalConst_clinic_nbr_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]),
					_originalConst_clinic_nbr_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]),
					_originalConst_clinic_nbr_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]),
					_originalConst_clinic_nbr_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]),
					_originalConst_clinic_nbr_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]),
					_originalConst_clinic_nbr_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]),
					_originalConst_clinic_nbr_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]),
					_originalConst_clinic_nbr_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]),
					_originalConst_clinic_nbr_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]),
					_originalConst_clinic_nbr_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]),
					_originalConst_clinic_nbr_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]),
					_originalConst_clinic_nbr_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]),
					_originalConst_clinic_nbr_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]),
					_originalConst_clinic_nbr_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]),
					_originalConst_clinic_nbr_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]),
					_originalConst_clinic_nbr_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]),
					_originalConst_clinic_nbr_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]),
					_originalConst_clinic_nbr1 = Reader["CONST_CLINIC_NBR1"].ToString(),
					_originalConst_clinic_nbr2 = Reader["CONST_CLINIC_NBR2"].ToString(),
					_originalConst_clinic_nbr3 = Reader["CONST_CLINIC_NBR3"].ToString(),
					_originalConst_clinic_nbr4 = Reader["CONST_CLINIC_NBR4"].ToString(),
					_originalConst_clinic_nbr5 = Reader["CONST_CLINIC_NBR5"].ToString(),
					_originalConst_clinic_nbr6 = Reader["CONST_CLINIC_NBR6"].ToString(),
					_originalConst_clinic_nbr7 = Reader["CONST_CLINIC_NBR7"].ToString(),
					_originalConst_clinic_nbr8 = Reader["CONST_CLINIC_NBR8"].ToString(),
					_originalConst_clinic_nbr9 = Reader["CONST_CLINIC_NBR9"].ToString(),
					_originalConst_clinic_nbr10 = Reader["CONST_CLINIC_NBR10"].ToString(),
					_originalConst_clinic_nbr11 = Reader["CONST_CLINIC_NBR11"].ToString(),
					_originalConst_clinic_nbr12 = Reader["CONST_CLINIC_NBR12"].ToString(),
					_originalConst_clinic_nbr13 = Reader["CONST_CLINIC_NBR13"].ToString(),
					_originalConst_clinic_nbr14 = Reader["CONST_CLINIC_NBR14"].ToString(),
					_originalConst_clinic_nbr15 = Reader["CONST_CLINIC_NBR15"].ToString(),
					_originalConst_clinic_nbr16 = Reader["CONST_CLINIC_NBR16"].ToString(),
					_originalConst_clinic_nbr17 = Reader["CONST_CLINIC_NBR17"].ToString(),
					_originalConst_clinic_nbr18 = Reader["CONST_CLINIC_NBR18"].ToString(),
					_originalConst_clinic_nbr19 = Reader["CONST_CLINIC_NBR19"].ToString(),
					_originalConst_clinic_nbr20 = Reader["CONST_CLINIC_NBR20"].ToString(),
					_originalConst_clinic_nbr21 = Reader["CONST_CLINIC_NBR21"].ToString(),
					_originalConst_clinic_nbr22 = Reader["CONST_CLINIC_NBR22"].ToString(),
					_originalConst_clinic_nbr23 = Reader["CONST_CLINIC_NBR23"].ToString(),
					_originalConst_clinic_nbr24 = Reader["CONST_CLINIC_NBR24"].ToString(),
					_originalConst_clinic_nbr25 = Reader["CONST_CLINIC_NBR25"].ToString(),
					_originalConst_clinic_nbr26 = Reader["CONST_CLINIC_NBR26"].ToString(),
					_originalConst_clinic_nbr27 = Reader["CONST_CLINIC_NBR27"].ToString(),
					_originalConst_clinic_nbr28 = Reader["CONST_CLINIC_NBR28"].ToString(),
					_originalConst_clinic_nbr29 = Reader["CONST_CLINIC_NBR29"].ToString(),
					_originalConst_clinic_nbr30 = Reader["CONST_CLINIC_NBR30"].ToString(),
					_originalConst_clinic_nbr31 = Reader["CONST_CLINIC_NBR31"].ToString(),
					_originalConst_clinic_nbr32 = Reader["CONST_CLINIC_NBR32"].ToString(),
					_originalConst_clinic_nbr33 = Reader["CONST_CLINIC_NBR33"].ToString(),
					_originalConst_clinic_nbr34 = Reader["CONST_CLINIC_NBR34"].ToString(),
					_originalConst_clinic_nbr35 = Reader["CONST_CLINIC_NBR35"].ToString(),
					_originalConst_clinic_nbr36 = Reader["CONST_CLINIC_NBR36"].ToString(),
					_originalConst_clinic_nbr37 = Reader["CONST_CLINIC_NBR37"].ToString(),
					_originalConst_clinic_nbr38 = Reader["CONST_CLINIC_NBR38"].ToString(),
					_originalConst_clinic_nbr39 = Reader["CONST_CLINIC_NBR39"].ToString(),
					_originalConst_clinic_nbr40 = Reader["CONST_CLINIC_NBR40"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_1 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_1> Collection(ObservableCollection<CONSTANTS_MSTR_REC_1>
                                                               constantsMstrRec1 = null)
        {
            if (IsSameSearch() && constantsMstrRec1 != null)
            {
                return constantsMstrRec1;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_1>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_MAX_NBR_CLINICS",WhereConst_max_nbr_clinics),
					new SqlParameter("CONST_CLINIC_NBR_1_21",WhereConst_clinic_nbr_1_21),
					new SqlParameter("CONST_CLINIC_NBR_1_22",WhereConst_clinic_nbr_1_22),
					new SqlParameter("CONST_CLINIC_NBR_1_23",WhereConst_clinic_nbr_1_23),
					new SqlParameter("CONST_CLINIC_NBR_1_24",WhereConst_clinic_nbr_1_24),
					new SqlParameter("CONST_CLINIC_NBR_1_25",WhereConst_clinic_nbr_1_25),
					new SqlParameter("CONST_CLINIC_NBR_1_26",WhereConst_clinic_nbr_1_26),
					new SqlParameter("CONST_CLINIC_NBR_1_27",WhereConst_clinic_nbr_1_27),
					new SqlParameter("CONST_CLINIC_NBR_1_28",WhereConst_clinic_nbr_1_28),
					new SqlParameter("CONST_CLINIC_NBR_1_29",WhereConst_clinic_nbr_1_29),
					new SqlParameter("CONST_CLINIC_NBR_1_210",WhereConst_clinic_nbr_1_210),
					new SqlParameter("CONST_CLINIC_NBR_1_211",WhereConst_clinic_nbr_1_211),
					new SqlParameter("CONST_CLINIC_NBR_1_212",WhereConst_clinic_nbr_1_212),
					new SqlParameter("CONST_CLINIC_NBR_1_213",WhereConst_clinic_nbr_1_213),
					new SqlParameter("CONST_CLINIC_NBR_1_214",WhereConst_clinic_nbr_1_214),
					new SqlParameter("CONST_CLINIC_NBR_1_215",WhereConst_clinic_nbr_1_215),
					new SqlParameter("CONST_CLINIC_NBR_1_216",WhereConst_clinic_nbr_1_216),
					new SqlParameter("CONST_CLINIC_NBR_1_217",WhereConst_clinic_nbr_1_217),
					new SqlParameter("CONST_CLINIC_NBR_1_218",WhereConst_clinic_nbr_1_218),
					new SqlParameter("CONST_CLINIC_NBR_1_219",WhereConst_clinic_nbr_1_219),
					new SqlParameter("CONST_CLINIC_NBR_1_220",WhereConst_clinic_nbr_1_220),
					new SqlParameter("CONST_CLINIC_NBR_1_221",WhereConst_clinic_nbr_1_221),
					new SqlParameter("CONST_CLINIC_NBR_1_222",WhereConst_clinic_nbr_1_222),
					new SqlParameter("CONST_CLINIC_NBR_1_223",WhereConst_clinic_nbr_1_223),
					new SqlParameter("CONST_CLINIC_NBR_1_224",WhereConst_clinic_nbr_1_224),
					new SqlParameter("CONST_CLINIC_NBR_1_225",WhereConst_clinic_nbr_1_225),
					new SqlParameter("CONST_CLINIC_NBR_1_226",WhereConst_clinic_nbr_1_226),
					new SqlParameter("CONST_CLINIC_NBR_1_227",WhereConst_clinic_nbr_1_227),
					new SqlParameter("CONST_CLINIC_NBR_1_228",WhereConst_clinic_nbr_1_228),
					new SqlParameter("CONST_CLINIC_NBR_1_229",WhereConst_clinic_nbr_1_229),
					new SqlParameter("CONST_CLINIC_NBR_1_230",WhereConst_clinic_nbr_1_230),
					new SqlParameter("CONST_CLINIC_NBR_1_231",WhereConst_clinic_nbr_1_231),
					new SqlParameter("CONST_CLINIC_NBR_1_232",WhereConst_clinic_nbr_1_232),
					new SqlParameter("CONST_CLINIC_NBR_1_233",WhereConst_clinic_nbr_1_233),
					new SqlParameter("CONST_CLINIC_NBR_1_234",WhereConst_clinic_nbr_1_234),
					new SqlParameter("CONST_CLINIC_NBR_1_235",WhereConst_clinic_nbr_1_235),
					new SqlParameter("CONST_CLINIC_NBR_1_236",WhereConst_clinic_nbr_1_236),
					new SqlParameter("CONST_CLINIC_NBR_1_237",WhereConst_clinic_nbr_1_237),
					new SqlParameter("CONST_CLINIC_NBR_1_238",WhereConst_clinic_nbr_1_238),
					new SqlParameter("CONST_CLINIC_NBR_1_239",WhereConst_clinic_nbr_1_239),
					new SqlParameter("CONST_CLINIC_NBR_1_240",WhereConst_clinic_nbr_1_240),
					new SqlParameter("CONST_CLINIC_NBR1",WhereConst_clinic_nbr1),
					new SqlParameter("CONST_CLINIC_NBR2",WhereConst_clinic_nbr2),
					new SqlParameter("CONST_CLINIC_NBR3",WhereConst_clinic_nbr3),
					new SqlParameter("CONST_CLINIC_NBR4",WhereConst_clinic_nbr4),
					new SqlParameter("CONST_CLINIC_NBR5",WhereConst_clinic_nbr5),
					new SqlParameter("CONST_CLINIC_NBR6",WhereConst_clinic_nbr6),
					new SqlParameter("CONST_CLINIC_NBR7",WhereConst_clinic_nbr7),
					new SqlParameter("CONST_CLINIC_NBR8",WhereConst_clinic_nbr8),
					new SqlParameter("CONST_CLINIC_NBR9",WhereConst_clinic_nbr9),
					new SqlParameter("CONST_CLINIC_NBR10",WhereConst_clinic_nbr10),
					new SqlParameter("CONST_CLINIC_NBR11",WhereConst_clinic_nbr11),
					new SqlParameter("CONST_CLINIC_NBR12",WhereConst_clinic_nbr12),
					new SqlParameter("CONST_CLINIC_NBR13",WhereConst_clinic_nbr13),
					new SqlParameter("CONST_CLINIC_NBR14",WhereConst_clinic_nbr14),
					new SqlParameter("CONST_CLINIC_NBR15",WhereConst_clinic_nbr15),
					new SqlParameter("CONST_CLINIC_NBR16",WhereConst_clinic_nbr16),
					new SqlParameter("CONST_CLINIC_NBR17",WhereConst_clinic_nbr17),
					new SqlParameter("CONST_CLINIC_NBR18",WhereConst_clinic_nbr18),
					new SqlParameter("CONST_CLINIC_NBR19",WhereConst_clinic_nbr19),
					new SqlParameter("CONST_CLINIC_NBR20",WhereConst_clinic_nbr20),
					new SqlParameter("CONST_CLINIC_NBR21",WhereConst_clinic_nbr21),
					new SqlParameter("CONST_CLINIC_NBR22",WhereConst_clinic_nbr22),
					new SqlParameter("CONST_CLINIC_NBR23",WhereConst_clinic_nbr23),
					new SqlParameter("CONST_CLINIC_NBR24",WhereConst_clinic_nbr24),
					new SqlParameter("CONST_CLINIC_NBR25",WhereConst_clinic_nbr25),
					new SqlParameter("CONST_CLINIC_NBR26",WhereConst_clinic_nbr26),
					new SqlParameter("CONST_CLINIC_NBR27",WhereConst_clinic_nbr27),
					new SqlParameter("CONST_CLINIC_NBR28",WhereConst_clinic_nbr28),
					new SqlParameter("CONST_CLINIC_NBR29",WhereConst_clinic_nbr29),
					new SqlParameter("CONST_CLINIC_NBR30",WhereConst_clinic_nbr30),
					new SqlParameter("CONST_CLINIC_NBR31",WhereConst_clinic_nbr31),
					new SqlParameter("CONST_CLINIC_NBR32",WhereConst_clinic_nbr32),
					new SqlParameter("CONST_CLINIC_NBR33",WhereConst_clinic_nbr33),
					new SqlParameter("CONST_CLINIC_NBR34",WhereConst_clinic_nbr34),
					new SqlParameter("CONST_CLINIC_NBR35",WhereConst_clinic_nbr35),
					new SqlParameter("CONST_CLINIC_NBR36",WhereConst_clinic_nbr36),
					new SqlParameter("CONST_CLINIC_NBR37",WhereConst_clinic_nbr37),
					new SqlParameter("CONST_CLINIC_NBR38",WhereConst_clinic_nbr38),
					new SqlParameter("CONST_CLINIC_NBR39",WhereConst_clinic_nbr39),
					new SqlParameter("CONST_CLINIC_NBR40",WhereConst_clinic_nbr40),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_1>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_1
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_MAX_NBR_CLINICS = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]),
					CONST_CLINIC_NBR_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]),
					CONST_CLINIC_NBR_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]),
					CONST_CLINIC_NBR_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]),
					CONST_CLINIC_NBR_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]),
					CONST_CLINIC_NBR_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]),
					CONST_CLINIC_NBR_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]),
					CONST_CLINIC_NBR_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]),
					CONST_CLINIC_NBR_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]),
					CONST_CLINIC_NBR_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]),
					CONST_CLINIC_NBR_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]),
					CONST_CLINIC_NBR_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]),
					CONST_CLINIC_NBR_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]),
					CONST_CLINIC_NBR_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]),
					CONST_CLINIC_NBR_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]),
					CONST_CLINIC_NBR_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]),
					CONST_CLINIC_NBR_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]),
					CONST_CLINIC_NBR_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]),
					CONST_CLINIC_NBR_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]),
					CONST_CLINIC_NBR_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]),
					CONST_CLINIC_NBR_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]),
					CONST_CLINIC_NBR_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]),
					CONST_CLINIC_NBR_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]),
					CONST_CLINIC_NBR_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]),
					CONST_CLINIC_NBR_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]),
					CONST_CLINIC_NBR_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]),
					CONST_CLINIC_NBR_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]),
					CONST_CLINIC_NBR_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]),
					CONST_CLINIC_NBR_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]),
					CONST_CLINIC_NBR_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]),
					CONST_CLINIC_NBR_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]),
					CONST_CLINIC_NBR_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]),
					CONST_CLINIC_NBR_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]),
					CONST_CLINIC_NBR_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]),
					CONST_CLINIC_NBR_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]),
					CONST_CLINIC_NBR_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]),
					CONST_CLINIC_NBR_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]),
					CONST_CLINIC_NBR_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]),
					CONST_CLINIC_NBR_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]),
					CONST_CLINIC_NBR_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]),
					CONST_CLINIC_NBR_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]),
					CONST_CLINIC_NBR1 = Reader["CONST_CLINIC_NBR1"].ToString(),
					CONST_CLINIC_NBR2 = Reader["CONST_CLINIC_NBR2"].ToString(),
					CONST_CLINIC_NBR3 = Reader["CONST_CLINIC_NBR3"].ToString(),
					CONST_CLINIC_NBR4 = Reader["CONST_CLINIC_NBR4"].ToString(),
					CONST_CLINIC_NBR5 = Reader["CONST_CLINIC_NBR5"].ToString(),
					CONST_CLINIC_NBR6 = Reader["CONST_CLINIC_NBR6"].ToString(),
					CONST_CLINIC_NBR7 = Reader["CONST_CLINIC_NBR7"].ToString(),
					CONST_CLINIC_NBR8 = Reader["CONST_CLINIC_NBR8"].ToString(),
					CONST_CLINIC_NBR9 = Reader["CONST_CLINIC_NBR9"].ToString(),
					CONST_CLINIC_NBR10 = Reader["CONST_CLINIC_NBR10"].ToString(),
					CONST_CLINIC_NBR11 = Reader["CONST_CLINIC_NBR11"].ToString(),
					CONST_CLINIC_NBR12 = Reader["CONST_CLINIC_NBR12"].ToString(),
					CONST_CLINIC_NBR13 = Reader["CONST_CLINIC_NBR13"].ToString(),
					CONST_CLINIC_NBR14 = Reader["CONST_CLINIC_NBR14"].ToString(),
					CONST_CLINIC_NBR15 = Reader["CONST_CLINIC_NBR15"].ToString(),
					CONST_CLINIC_NBR16 = Reader["CONST_CLINIC_NBR16"].ToString(),
					CONST_CLINIC_NBR17 = Reader["CONST_CLINIC_NBR17"].ToString(),
					CONST_CLINIC_NBR18 = Reader["CONST_CLINIC_NBR18"].ToString(),
					CONST_CLINIC_NBR19 = Reader["CONST_CLINIC_NBR19"].ToString(),
					CONST_CLINIC_NBR20 = Reader["CONST_CLINIC_NBR20"].ToString(),
					CONST_CLINIC_NBR21 = Reader["CONST_CLINIC_NBR21"].ToString(),
					CONST_CLINIC_NBR22 = Reader["CONST_CLINIC_NBR22"].ToString(),
					CONST_CLINIC_NBR23 = Reader["CONST_CLINIC_NBR23"].ToString(),
					CONST_CLINIC_NBR24 = Reader["CONST_CLINIC_NBR24"].ToString(),
					CONST_CLINIC_NBR25 = Reader["CONST_CLINIC_NBR25"].ToString(),
					CONST_CLINIC_NBR26 = Reader["CONST_CLINIC_NBR26"].ToString(),
					CONST_CLINIC_NBR27 = Reader["CONST_CLINIC_NBR27"].ToString(),
					CONST_CLINIC_NBR28 = Reader["CONST_CLINIC_NBR28"].ToString(),
					CONST_CLINIC_NBR29 = Reader["CONST_CLINIC_NBR29"].ToString(),
					CONST_CLINIC_NBR30 = Reader["CONST_CLINIC_NBR30"].ToString(),
					CONST_CLINIC_NBR31 = Reader["CONST_CLINIC_NBR31"].ToString(),
					CONST_CLINIC_NBR32 = Reader["CONST_CLINIC_NBR32"].ToString(),
					CONST_CLINIC_NBR33 = Reader["CONST_CLINIC_NBR33"].ToString(),
					CONST_CLINIC_NBR34 = Reader["CONST_CLINIC_NBR34"].ToString(),
					CONST_CLINIC_NBR35 = Reader["CONST_CLINIC_NBR35"].ToString(),
					CONST_CLINIC_NBR36 = Reader["CONST_CLINIC_NBR36"].ToString(),
					CONST_CLINIC_NBR37 = Reader["CONST_CLINIC_NBR37"].ToString(),
					CONST_CLINIC_NBR38 = Reader["CONST_CLINIC_NBR38"].ToString(),
					CONST_CLINIC_NBR39 = Reader["CONST_CLINIC_NBR39"].ToString(),
					CONST_CLINIC_NBR40 = Reader["CONST_CLINIC_NBR40"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_max_nbr_clinics = WhereConst_max_nbr_clinics,
					_whereConst_clinic_nbr_1_21 = WhereConst_clinic_nbr_1_21,
					_whereConst_clinic_nbr_1_22 = WhereConst_clinic_nbr_1_22,
					_whereConst_clinic_nbr_1_23 = WhereConst_clinic_nbr_1_23,
					_whereConst_clinic_nbr_1_24 = WhereConst_clinic_nbr_1_24,
					_whereConst_clinic_nbr_1_25 = WhereConst_clinic_nbr_1_25,
					_whereConst_clinic_nbr_1_26 = WhereConst_clinic_nbr_1_26,
					_whereConst_clinic_nbr_1_27 = WhereConst_clinic_nbr_1_27,
					_whereConst_clinic_nbr_1_28 = WhereConst_clinic_nbr_1_28,
					_whereConst_clinic_nbr_1_29 = WhereConst_clinic_nbr_1_29,
					_whereConst_clinic_nbr_1_210 = WhereConst_clinic_nbr_1_210,
					_whereConst_clinic_nbr_1_211 = WhereConst_clinic_nbr_1_211,
					_whereConst_clinic_nbr_1_212 = WhereConst_clinic_nbr_1_212,
					_whereConst_clinic_nbr_1_213 = WhereConst_clinic_nbr_1_213,
					_whereConst_clinic_nbr_1_214 = WhereConst_clinic_nbr_1_214,
					_whereConst_clinic_nbr_1_215 = WhereConst_clinic_nbr_1_215,
					_whereConst_clinic_nbr_1_216 = WhereConst_clinic_nbr_1_216,
					_whereConst_clinic_nbr_1_217 = WhereConst_clinic_nbr_1_217,
					_whereConst_clinic_nbr_1_218 = WhereConst_clinic_nbr_1_218,
					_whereConst_clinic_nbr_1_219 = WhereConst_clinic_nbr_1_219,
					_whereConst_clinic_nbr_1_220 = WhereConst_clinic_nbr_1_220,
					_whereConst_clinic_nbr_1_221 = WhereConst_clinic_nbr_1_221,
					_whereConst_clinic_nbr_1_222 = WhereConst_clinic_nbr_1_222,
					_whereConst_clinic_nbr_1_223 = WhereConst_clinic_nbr_1_223,
					_whereConst_clinic_nbr_1_224 = WhereConst_clinic_nbr_1_224,
					_whereConst_clinic_nbr_1_225 = WhereConst_clinic_nbr_1_225,
					_whereConst_clinic_nbr_1_226 = WhereConst_clinic_nbr_1_226,
					_whereConst_clinic_nbr_1_227 = WhereConst_clinic_nbr_1_227,
					_whereConst_clinic_nbr_1_228 = WhereConst_clinic_nbr_1_228,
					_whereConst_clinic_nbr_1_229 = WhereConst_clinic_nbr_1_229,
					_whereConst_clinic_nbr_1_230 = WhereConst_clinic_nbr_1_230,
					_whereConst_clinic_nbr_1_231 = WhereConst_clinic_nbr_1_231,
					_whereConst_clinic_nbr_1_232 = WhereConst_clinic_nbr_1_232,
					_whereConst_clinic_nbr_1_233 = WhereConst_clinic_nbr_1_233,
					_whereConst_clinic_nbr_1_234 = WhereConst_clinic_nbr_1_234,
					_whereConst_clinic_nbr_1_235 = WhereConst_clinic_nbr_1_235,
					_whereConst_clinic_nbr_1_236 = WhereConst_clinic_nbr_1_236,
					_whereConst_clinic_nbr_1_237 = WhereConst_clinic_nbr_1_237,
					_whereConst_clinic_nbr_1_238 = WhereConst_clinic_nbr_1_238,
					_whereConst_clinic_nbr_1_239 = WhereConst_clinic_nbr_1_239,
					_whereConst_clinic_nbr_1_240 = WhereConst_clinic_nbr_1_240,
					_whereConst_clinic_nbr1 = WhereConst_clinic_nbr1,
					_whereConst_clinic_nbr2 = WhereConst_clinic_nbr2,
					_whereConst_clinic_nbr3 = WhereConst_clinic_nbr3,
					_whereConst_clinic_nbr4 = WhereConst_clinic_nbr4,
					_whereConst_clinic_nbr5 = WhereConst_clinic_nbr5,
					_whereConst_clinic_nbr6 = WhereConst_clinic_nbr6,
					_whereConst_clinic_nbr7 = WhereConst_clinic_nbr7,
					_whereConst_clinic_nbr8 = WhereConst_clinic_nbr8,
					_whereConst_clinic_nbr9 = WhereConst_clinic_nbr9,
					_whereConst_clinic_nbr10 = WhereConst_clinic_nbr10,
					_whereConst_clinic_nbr11 = WhereConst_clinic_nbr11,
					_whereConst_clinic_nbr12 = WhereConst_clinic_nbr12,
					_whereConst_clinic_nbr13 = WhereConst_clinic_nbr13,
					_whereConst_clinic_nbr14 = WhereConst_clinic_nbr14,
					_whereConst_clinic_nbr15 = WhereConst_clinic_nbr15,
					_whereConst_clinic_nbr16 = WhereConst_clinic_nbr16,
					_whereConst_clinic_nbr17 = WhereConst_clinic_nbr17,
					_whereConst_clinic_nbr18 = WhereConst_clinic_nbr18,
					_whereConst_clinic_nbr19 = WhereConst_clinic_nbr19,
					_whereConst_clinic_nbr20 = WhereConst_clinic_nbr20,
					_whereConst_clinic_nbr21 = WhereConst_clinic_nbr21,
					_whereConst_clinic_nbr22 = WhereConst_clinic_nbr22,
					_whereConst_clinic_nbr23 = WhereConst_clinic_nbr23,
					_whereConst_clinic_nbr24 = WhereConst_clinic_nbr24,
					_whereConst_clinic_nbr25 = WhereConst_clinic_nbr25,
					_whereConst_clinic_nbr26 = WhereConst_clinic_nbr26,
					_whereConst_clinic_nbr27 = WhereConst_clinic_nbr27,
					_whereConst_clinic_nbr28 = WhereConst_clinic_nbr28,
					_whereConst_clinic_nbr29 = WhereConst_clinic_nbr29,
					_whereConst_clinic_nbr30 = WhereConst_clinic_nbr30,
					_whereConst_clinic_nbr31 = WhereConst_clinic_nbr31,
					_whereConst_clinic_nbr32 = WhereConst_clinic_nbr32,
					_whereConst_clinic_nbr33 = WhereConst_clinic_nbr33,
					_whereConst_clinic_nbr34 = WhereConst_clinic_nbr34,
					_whereConst_clinic_nbr35 = WhereConst_clinic_nbr35,
					_whereConst_clinic_nbr36 = WhereConst_clinic_nbr36,
					_whereConst_clinic_nbr37 = WhereConst_clinic_nbr37,
					_whereConst_clinic_nbr38 = WhereConst_clinic_nbr38,
					_whereConst_clinic_nbr39 = WhereConst_clinic_nbr39,
					_whereConst_clinic_nbr40 = WhereConst_clinic_nbr40,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_max_nbr_clinics = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]),
					_originalConst_clinic_nbr_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]),
					_originalConst_clinic_nbr_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]),
					_originalConst_clinic_nbr_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]),
					_originalConst_clinic_nbr_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]),
					_originalConst_clinic_nbr_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]),
					_originalConst_clinic_nbr_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]),
					_originalConst_clinic_nbr_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]),
					_originalConst_clinic_nbr_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]),
					_originalConst_clinic_nbr_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]),
					_originalConst_clinic_nbr_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]),
					_originalConst_clinic_nbr_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]),
					_originalConst_clinic_nbr_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]),
					_originalConst_clinic_nbr_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]),
					_originalConst_clinic_nbr_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]),
					_originalConst_clinic_nbr_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]),
					_originalConst_clinic_nbr_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]),
					_originalConst_clinic_nbr_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]),
					_originalConst_clinic_nbr_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]),
					_originalConst_clinic_nbr_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]),
					_originalConst_clinic_nbr_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]),
					_originalConst_clinic_nbr_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]),
					_originalConst_clinic_nbr_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]),
					_originalConst_clinic_nbr_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]),
					_originalConst_clinic_nbr_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]),
					_originalConst_clinic_nbr_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]),
					_originalConst_clinic_nbr_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]),
					_originalConst_clinic_nbr_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]),
					_originalConst_clinic_nbr_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]),
					_originalConst_clinic_nbr_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]),
					_originalConst_clinic_nbr_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]),
					_originalConst_clinic_nbr_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]),
					_originalConst_clinic_nbr_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]),
					_originalConst_clinic_nbr_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]),
					_originalConst_clinic_nbr_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]),
					_originalConst_clinic_nbr_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]),
					_originalConst_clinic_nbr_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]),
					_originalConst_clinic_nbr_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]),
					_originalConst_clinic_nbr_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]),
					_originalConst_clinic_nbr_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]),
					_originalConst_clinic_nbr_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]),
					_originalConst_clinic_nbr1 = Reader["CONST_CLINIC_NBR1"].ToString(),
					_originalConst_clinic_nbr2 = Reader["CONST_CLINIC_NBR2"].ToString(),
					_originalConst_clinic_nbr3 = Reader["CONST_CLINIC_NBR3"].ToString(),
					_originalConst_clinic_nbr4 = Reader["CONST_CLINIC_NBR4"].ToString(),
					_originalConst_clinic_nbr5 = Reader["CONST_CLINIC_NBR5"].ToString(),
					_originalConst_clinic_nbr6 = Reader["CONST_CLINIC_NBR6"].ToString(),
					_originalConst_clinic_nbr7 = Reader["CONST_CLINIC_NBR7"].ToString(),
					_originalConst_clinic_nbr8 = Reader["CONST_CLINIC_NBR8"].ToString(),
					_originalConst_clinic_nbr9 = Reader["CONST_CLINIC_NBR9"].ToString(),
					_originalConst_clinic_nbr10 = Reader["CONST_CLINIC_NBR10"].ToString(),
					_originalConst_clinic_nbr11 = Reader["CONST_CLINIC_NBR11"].ToString(),
					_originalConst_clinic_nbr12 = Reader["CONST_CLINIC_NBR12"].ToString(),
					_originalConst_clinic_nbr13 = Reader["CONST_CLINIC_NBR13"].ToString(),
					_originalConst_clinic_nbr14 = Reader["CONST_CLINIC_NBR14"].ToString(),
					_originalConst_clinic_nbr15 = Reader["CONST_CLINIC_NBR15"].ToString(),
					_originalConst_clinic_nbr16 = Reader["CONST_CLINIC_NBR16"].ToString(),
					_originalConst_clinic_nbr17 = Reader["CONST_CLINIC_NBR17"].ToString(),
					_originalConst_clinic_nbr18 = Reader["CONST_CLINIC_NBR18"].ToString(),
					_originalConst_clinic_nbr19 = Reader["CONST_CLINIC_NBR19"].ToString(),
					_originalConst_clinic_nbr20 = Reader["CONST_CLINIC_NBR20"].ToString(),
					_originalConst_clinic_nbr21 = Reader["CONST_CLINIC_NBR21"].ToString(),
					_originalConst_clinic_nbr22 = Reader["CONST_CLINIC_NBR22"].ToString(),
					_originalConst_clinic_nbr23 = Reader["CONST_CLINIC_NBR23"].ToString(),
					_originalConst_clinic_nbr24 = Reader["CONST_CLINIC_NBR24"].ToString(),
					_originalConst_clinic_nbr25 = Reader["CONST_CLINIC_NBR25"].ToString(),
					_originalConst_clinic_nbr26 = Reader["CONST_CLINIC_NBR26"].ToString(),
					_originalConst_clinic_nbr27 = Reader["CONST_CLINIC_NBR27"].ToString(),
					_originalConst_clinic_nbr28 = Reader["CONST_CLINIC_NBR28"].ToString(),
					_originalConst_clinic_nbr29 = Reader["CONST_CLINIC_NBR29"].ToString(),
					_originalConst_clinic_nbr30 = Reader["CONST_CLINIC_NBR30"].ToString(),
					_originalConst_clinic_nbr31 = Reader["CONST_CLINIC_NBR31"].ToString(),
					_originalConst_clinic_nbr32 = Reader["CONST_CLINIC_NBR32"].ToString(),
					_originalConst_clinic_nbr33 = Reader["CONST_CLINIC_NBR33"].ToString(),
					_originalConst_clinic_nbr34 = Reader["CONST_CLINIC_NBR34"].ToString(),
					_originalConst_clinic_nbr35 = Reader["CONST_CLINIC_NBR35"].ToString(),
					_originalConst_clinic_nbr36 = Reader["CONST_CLINIC_NBR36"].ToString(),
					_originalConst_clinic_nbr37 = Reader["CONST_CLINIC_NBR37"].ToString(),
					_originalConst_clinic_nbr38 = Reader["CONST_CLINIC_NBR38"].ToString(),
					_originalConst_clinic_nbr39 = Reader["CONST_CLINIC_NBR39"].ToString(),
					_originalConst_clinic_nbr40 = Reader["CONST_CLINIC_NBR40"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_max_nbr_clinics = WhereConst_max_nbr_clinics;
					_whereConst_clinic_nbr_1_21 = WhereConst_clinic_nbr_1_21;
					_whereConst_clinic_nbr_1_22 = WhereConst_clinic_nbr_1_22;
					_whereConst_clinic_nbr_1_23 = WhereConst_clinic_nbr_1_23;
					_whereConst_clinic_nbr_1_24 = WhereConst_clinic_nbr_1_24;
					_whereConst_clinic_nbr_1_25 = WhereConst_clinic_nbr_1_25;
					_whereConst_clinic_nbr_1_26 = WhereConst_clinic_nbr_1_26;
					_whereConst_clinic_nbr_1_27 = WhereConst_clinic_nbr_1_27;
					_whereConst_clinic_nbr_1_28 = WhereConst_clinic_nbr_1_28;
					_whereConst_clinic_nbr_1_29 = WhereConst_clinic_nbr_1_29;
					_whereConst_clinic_nbr_1_210 = WhereConst_clinic_nbr_1_210;
					_whereConst_clinic_nbr_1_211 = WhereConst_clinic_nbr_1_211;
					_whereConst_clinic_nbr_1_212 = WhereConst_clinic_nbr_1_212;
					_whereConst_clinic_nbr_1_213 = WhereConst_clinic_nbr_1_213;
					_whereConst_clinic_nbr_1_214 = WhereConst_clinic_nbr_1_214;
					_whereConst_clinic_nbr_1_215 = WhereConst_clinic_nbr_1_215;
					_whereConst_clinic_nbr_1_216 = WhereConst_clinic_nbr_1_216;
					_whereConst_clinic_nbr_1_217 = WhereConst_clinic_nbr_1_217;
					_whereConst_clinic_nbr_1_218 = WhereConst_clinic_nbr_1_218;
					_whereConst_clinic_nbr_1_219 = WhereConst_clinic_nbr_1_219;
					_whereConst_clinic_nbr_1_220 = WhereConst_clinic_nbr_1_220;
					_whereConst_clinic_nbr_1_221 = WhereConst_clinic_nbr_1_221;
					_whereConst_clinic_nbr_1_222 = WhereConst_clinic_nbr_1_222;
					_whereConst_clinic_nbr_1_223 = WhereConst_clinic_nbr_1_223;
					_whereConst_clinic_nbr_1_224 = WhereConst_clinic_nbr_1_224;
					_whereConst_clinic_nbr_1_225 = WhereConst_clinic_nbr_1_225;
					_whereConst_clinic_nbr_1_226 = WhereConst_clinic_nbr_1_226;
					_whereConst_clinic_nbr_1_227 = WhereConst_clinic_nbr_1_227;
					_whereConst_clinic_nbr_1_228 = WhereConst_clinic_nbr_1_228;
					_whereConst_clinic_nbr_1_229 = WhereConst_clinic_nbr_1_229;
					_whereConst_clinic_nbr_1_230 = WhereConst_clinic_nbr_1_230;
					_whereConst_clinic_nbr_1_231 = WhereConst_clinic_nbr_1_231;
					_whereConst_clinic_nbr_1_232 = WhereConst_clinic_nbr_1_232;
					_whereConst_clinic_nbr_1_233 = WhereConst_clinic_nbr_1_233;
					_whereConst_clinic_nbr_1_234 = WhereConst_clinic_nbr_1_234;
					_whereConst_clinic_nbr_1_235 = WhereConst_clinic_nbr_1_235;
					_whereConst_clinic_nbr_1_236 = WhereConst_clinic_nbr_1_236;
					_whereConst_clinic_nbr_1_237 = WhereConst_clinic_nbr_1_237;
					_whereConst_clinic_nbr_1_238 = WhereConst_clinic_nbr_1_238;
					_whereConst_clinic_nbr_1_239 = WhereConst_clinic_nbr_1_239;
					_whereConst_clinic_nbr_1_240 = WhereConst_clinic_nbr_1_240;
					_whereConst_clinic_nbr1 = WhereConst_clinic_nbr1;
					_whereConst_clinic_nbr2 = WhereConst_clinic_nbr2;
					_whereConst_clinic_nbr3 = WhereConst_clinic_nbr3;
					_whereConst_clinic_nbr4 = WhereConst_clinic_nbr4;
					_whereConst_clinic_nbr5 = WhereConst_clinic_nbr5;
					_whereConst_clinic_nbr6 = WhereConst_clinic_nbr6;
					_whereConst_clinic_nbr7 = WhereConst_clinic_nbr7;
					_whereConst_clinic_nbr8 = WhereConst_clinic_nbr8;
					_whereConst_clinic_nbr9 = WhereConst_clinic_nbr9;
					_whereConst_clinic_nbr10 = WhereConst_clinic_nbr10;
					_whereConst_clinic_nbr11 = WhereConst_clinic_nbr11;
					_whereConst_clinic_nbr12 = WhereConst_clinic_nbr12;
					_whereConst_clinic_nbr13 = WhereConst_clinic_nbr13;
					_whereConst_clinic_nbr14 = WhereConst_clinic_nbr14;
					_whereConst_clinic_nbr15 = WhereConst_clinic_nbr15;
					_whereConst_clinic_nbr16 = WhereConst_clinic_nbr16;
					_whereConst_clinic_nbr17 = WhereConst_clinic_nbr17;
					_whereConst_clinic_nbr18 = WhereConst_clinic_nbr18;
					_whereConst_clinic_nbr19 = WhereConst_clinic_nbr19;
					_whereConst_clinic_nbr20 = WhereConst_clinic_nbr20;
					_whereConst_clinic_nbr21 = WhereConst_clinic_nbr21;
					_whereConst_clinic_nbr22 = WhereConst_clinic_nbr22;
					_whereConst_clinic_nbr23 = WhereConst_clinic_nbr23;
					_whereConst_clinic_nbr24 = WhereConst_clinic_nbr24;
					_whereConst_clinic_nbr25 = WhereConst_clinic_nbr25;
					_whereConst_clinic_nbr26 = WhereConst_clinic_nbr26;
					_whereConst_clinic_nbr27 = WhereConst_clinic_nbr27;
					_whereConst_clinic_nbr28 = WhereConst_clinic_nbr28;
					_whereConst_clinic_nbr29 = WhereConst_clinic_nbr29;
					_whereConst_clinic_nbr30 = WhereConst_clinic_nbr30;
					_whereConst_clinic_nbr31 = WhereConst_clinic_nbr31;
					_whereConst_clinic_nbr32 = WhereConst_clinic_nbr32;
					_whereConst_clinic_nbr33 = WhereConst_clinic_nbr33;
					_whereConst_clinic_nbr34 = WhereConst_clinic_nbr34;
					_whereConst_clinic_nbr35 = WhereConst_clinic_nbr35;
					_whereConst_clinic_nbr36 = WhereConst_clinic_nbr36;
					_whereConst_clinic_nbr37 = WhereConst_clinic_nbr37;
					_whereConst_clinic_nbr38 = WhereConst_clinic_nbr38;
					_whereConst_clinic_nbr39 = WhereConst_clinic_nbr39;
					_whereConst_clinic_nbr40 = WhereConst_clinic_nbr40;
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
				&& WhereConst_max_nbr_clinics == null 
				&& WhereConst_clinic_nbr_1_21 == null 
				&& WhereConst_clinic_nbr_1_22 == null 
				&& WhereConst_clinic_nbr_1_23 == null 
				&& WhereConst_clinic_nbr_1_24 == null 
				&& WhereConst_clinic_nbr_1_25 == null 
				&& WhereConst_clinic_nbr_1_26 == null 
				&& WhereConst_clinic_nbr_1_27 == null 
				&& WhereConst_clinic_nbr_1_28 == null 
				&& WhereConst_clinic_nbr_1_29 == null 
				&& WhereConst_clinic_nbr_1_210 == null 
				&& WhereConst_clinic_nbr_1_211 == null 
				&& WhereConst_clinic_nbr_1_212 == null 
				&& WhereConst_clinic_nbr_1_213 == null 
				&& WhereConst_clinic_nbr_1_214 == null 
				&& WhereConst_clinic_nbr_1_215 == null 
				&& WhereConst_clinic_nbr_1_216 == null 
				&& WhereConst_clinic_nbr_1_217 == null 
				&& WhereConst_clinic_nbr_1_218 == null 
				&& WhereConst_clinic_nbr_1_219 == null 
				&& WhereConst_clinic_nbr_1_220 == null 
				&& WhereConst_clinic_nbr_1_221 == null 
				&& WhereConst_clinic_nbr_1_222 == null 
				&& WhereConst_clinic_nbr_1_223 == null 
				&& WhereConst_clinic_nbr_1_224 == null 
				&& WhereConst_clinic_nbr_1_225 == null 
				&& WhereConst_clinic_nbr_1_226 == null 
				&& WhereConst_clinic_nbr_1_227 == null 
				&& WhereConst_clinic_nbr_1_228 == null 
				&& WhereConst_clinic_nbr_1_229 == null 
				&& WhereConst_clinic_nbr_1_230 == null 
				&& WhereConst_clinic_nbr_1_231 == null 
				&& WhereConst_clinic_nbr_1_232 == null 
				&& WhereConst_clinic_nbr_1_233 == null 
				&& WhereConst_clinic_nbr_1_234 == null 
				&& WhereConst_clinic_nbr_1_235 == null 
				&& WhereConst_clinic_nbr_1_236 == null 
				&& WhereConst_clinic_nbr_1_237 == null 
				&& WhereConst_clinic_nbr_1_238 == null 
				&& WhereConst_clinic_nbr_1_239 == null 
				&& WhereConst_clinic_nbr_1_240 == null 
				&& WhereConst_clinic_nbr1 == null 
				&& WhereConst_clinic_nbr2 == null 
				&& WhereConst_clinic_nbr3 == null 
				&& WhereConst_clinic_nbr4 == null 
				&& WhereConst_clinic_nbr5 == null 
				&& WhereConst_clinic_nbr6 == null 
				&& WhereConst_clinic_nbr7 == null 
				&& WhereConst_clinic_nbr8 == null 
				&& WhereConst_clinic_nbr9 == null 
				&& WhereConst_clinic_nbr10 == null 
				&& WhereConst_clinic_nbr11 == null 
				&& WhereConst_clinic_nbr12 == null 
				&& WhereConst_clinic_nbr13 == null 
				&& WhereConst_clinic_nbr14 == null 
				&& WhereConst_clinic_nbr15 == null 
				&& WhereConst_clinic_nbr16 == null 
				&& WhereConst_clinic_nbr17 == null 
				&& WhereConst_clinic_nbr18 == null 
				&& WhereConst_clinic_nbr19 == null 
				&& WhereConst_clinic_nbr20 == null 
				&& WhereConst_clinic_nbr21 == null 
				&& WhereConst_clinic_nbr22 == null 
				&& WhereConst_clinic_nbr23 == null 
				&& WhereConst_clinic_nbr24 == null 
				&& WhereConst_clinic_nbr25 == null 
				&& WhereConst_clinic_nbr26 == null 
				&& WhereConst_clinic_nbr27 == null 
				&& WhereConst_clinic_nbr28 == null 
				&& WhereConst_clinic_nbr29 == null 
				&& WhereConst_clinic_nbr30 == null 
				&& WhereConst_clinic_nbr31 == null 
				&& WhereConst_clinic_nbr32 == null 
				&& WhereConst_clinic_nbr33 == null 
				&& WhereConst_clinic_nbr34 == null 
				&& WhereConst_clinic_nbr35 == null 
				&& WhereConst_clinic_nbr36 == null 
				&& WhereConst_clinic_nbr37 == null 
				&& WhereConst_clinic_nbr38 == null 
				&& WhereConst_clinic_nbr39 == null 
				&& WhereConst_clinic_nbr40 == null 
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
				&& WhereConst_max_nbr_clinics ==  _whereConst_max_nbr_clinics
				&& WhereConst_clinic_nbr_1_21 ==  _whereConst_clinic_nbr_1_21
				&& WhereConst_clinic_nbr_1_22 ==  _whereConst_clinic_nbr_1_22
				&& WhereConst_clinic_nbr_1_23 ==  _whereConst_clinic_nbr_1_23
				&& WhereConst_clinic_nbr_1_24 ==  _whereConst_clinic_nbr_1_24
				&& WhereConst_clinic_nbr_1_25 ==  _whereConst_clinic_nbr_1_25
				&& WhereConst_clinic_nbr_1_26 ==  _whereConst_clinic_nbr_1_26
				&& WhereConst_clinic_nbr_1_27 ==  _whereConst_clinic_nbr_1_27
				&& WhereConst_clinic_nbr_1_28 ==  _whereConst_clinic_nbr_1_28
				&& WhereConst_clinic_nbr_1_29 ==  _whereConst_clinic_nbr_1_29
				&& WhereConst_clinic_nbr_1_210 ==  _whereConst_clinic_nbr_1_210
				&& WhereConst_clinic_nbr_1_211 ==  _whereConst_clinic_nbr_1_211
				&& WhereConst_clinic_nbr_1_212 ==  _whereConst_clinic_nbr_1_212
				&& WhereConst_clinic_nbr_1_213 ==  _whereConst_clinic_nbr_1_213
				&& WhereConst_clinic_nbr_1_214 ==  _whereConst_clinic_nbr_1_214
				&& WhereConst_clinic_nbr_1_215 ==  _whereConst_clinic_nbr_1_215
				&& WhereConst_clinic_nbr_1_216 ==  _whereConst_clinic_nbr_1_216
				&& WhereConst_clinic_nbr_1_217 ==  _whereConst_clinic_nbr_1_217
				&& WhereConst_clinic_nbr_1_218 ==  _whereConst_clinic_nbr_1_218
				&& WhereConst_clinic_nbr_1_219 ==  _whereConst_clinic_nbr_1_219
				&& WhereConst_clinic_nbr_1_220 ==  _whereConst_clinic_nbr_1_220
				&& WhereConst_clinic_nbr_1_221 ==  _whereConst_clinic_nbr_1_221
				&& WhereConst_clinic_nbr_1_222 ==  _whereConst_clinic_nbr_1_222
				&& WhereConst_clinic_nbr_1_223 ==  _whereConst_clinic_nbr_1_223
				&& WhereConst_clinic_nbr_1_224 ==  _whereConst_clinic_nbr_1_224
				&& WhereConst_clinic_nbr_1_225 ==  _whereConst_clinic_nbr_1_225
				&& WhereConst_clinic_nbr_1_226 ==  _whereConst_clinic_nbr_1_226
				&& WhereConst_clinic_nbr_1_227 ==  _whereConst_clinic_nbr_1_227
				&& WhereConst_clinic_nbr_1_228 ==  _whereConst_clinic_nbr_1_228
				&& WhereConst_clinic_nbr_1_229 ==  _whereConst_clinic_nbr_1_229
				&& WhereConst_clinic_nbr_1_230 ==  _whereConst_clinic_nbr_1_230
				&& WhereConst_clinic_nbr_1_231 ==  _whereConst_clinic_nbr_1_231
				&& WhereConst_clinic_nbr_1_232 ==  _whereConst_clinic_nbr_1_232
				&& WhereConst_clinic_nbr_1_233 ==  _whereConst_clinic_nbr_1_233
				&& WhereConst_clinic_nbr_1_234 ==  _whereConst_clinic_nbr_1_234
				&& WhereConst_clinic_nbr_1_235 ==  _whereConst_clinic_nbr_1_235
				&& WhereConst_clinic_nbr_1_236 ==  _whereConst_clinic_nbr_1_236
				&& WhereConst_clinic_nbr_1_237 ==  _whereConst_clinic_nbr_1_237
				&& WhereConst_clinic_nbr_1_238 ==  _whereConst_clinic_nbr_1_238
				&& WhereConst_clinic_nbr_1_239 ==  _whereConst_clinic_nbr_1_239
				&& WhereConst_clinic_nbr_1_240 ==  _whereConst_clinic_nbr_1_240
				&& WhereConst_clinic_nbr1 ==  _whereConst_clinic_nbr1
				&& WhereConst_clinic_nbr2 ==  _whereConst_clinic_nbr2
				&& WhereConst_clinic_nbr3 ==  _whereConst_clinic_nbr3
				&& WhereConst_clinic_nbr4 ==  _whereConst_clinic_nbr4
				&& WhereConst_clinic_nbr5 ==  _whereConst_clinic_nbr5
				&& WhereConst_clinic_nbr6 ==  _whereConst_clinic_nbr6
				&& WhereConst_clinic_nbr7 ==  _whereConst_clinic_nbr7
				&& WhereConst_clinic_nbr8 ==  _whereConst_clinic_nbr8
				&& WhereConst_clinic_nbr9 ==  _whereConst_clinic_nbr9
				&& WhereConst_clinic_nbr10 ==  _whereConst_clinic_nbr10
				&& WhereConst_clinic_nbr11 ==  _whereConst_clinic_nbr11
				&& WhereConst_clinic_nbr12 ==  _whereConst_clinic_nbr12
				&& WhereConst_clinic_nbr13 ==  _whereConst_clinic_nbr13
				&& WhereConst_clinic_nbr14 ==  _whereConst_clinic_nbr14
				&& WhereConst_clinic_nbr15 ==  _whereConst_clinic_nbr15
				&& WhereConst_clinic_nbr16 ==  _whereConst_clinic_nbr16
				&& WhereConst_clinic_nbr17 ==  _whereConst_clinic_nbr17
				&& WhereConst_clinic_nbr18 ==  _whereConst_clinic_nbr18
				&& WhereConst_clinic_nbr19 ==  _whereConst_clinic_nbr19
				&& WhereConst_clinic_nbr20 ==  _whereConst_clinic_nbr20
				&& WhereConst_clinic_nbr21 ==  _whereConst_clinic_nbr21
				&& WhereConst_clinic_nbr22 ==  _whereConst_clinic_nbr22
				&& WhereConst_clinic_nbr23 ==  _whereConst_clinic_nbr23
				&& WhereConst_clinic_nbr24 ==  _whereConst_clinic_nbr24
				&& WhereConst_clinic_nbr25 ==  _whereConst_clinic_nbr25
				&& WhereConst_clinic_nbr26 ==  _whereConst_clinic_nbr26
				&& WhereConst_clinic_nbr27 ==  _whereConst_clinic_nbr27
				&& WhereConst_clinic_nbr28 ==  _whereConst_clinic_nbr28
				&& WhereConst_clinic_nbr29 ==  _whereConst_clinic_nbr29
				&& WhereConst_clinic_nbr30 ==  _whereConst_clinic_nbr30
				&& WhereConst_clinic_nbr31 ==  _whereConst_clinic_nbr31
				&& WhereConst_clinic_nbr32 ==  _whereConst_clinic_nbr32
				&& WhereConst_clinic_nbr33 ==  _whereConst_clinic_nbr33
				&& WhereConst_clinic_nbr34 ==  _whereConst_clinic_nbr34
				&& WhereConst_clinic_nbr35 ==  _whereConst_clinic_nbr35
				&& WhereConst_clinic_nbr36 ==  _whereConst_clinic_nbr36
				&& WhereConst_clinic_nbr37 ==  _whereConst_clinic_nbr37
				&& WhereConst_clinic_nbr38 ==  _whereConst_clinic_nbr38
				&& WhereConst_clinic_nbr39 ==  _whereConst_clinic_nbr39
				&& WhereConst_clinic_nbr40 ==  _whereConst_clinic_nbr40
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_max_nbr_clinics = null; 
			WhereConst_clinic_nbr_1_21 = null; 
			WhereConst_clinic_nbr_1_22 = null; 
			WhereConst_clinic_nbr_1_23 = null; 
			WhereConst_clinic_nbr_1_24 = null; 
			WhereConst_clinic_nbr_1_25 = null; 
			WhereConst_clinic_nbr_1_26 = null; 
			WhereConst_clinic_nbr_1_27 = null; 
			WhereConst_clinic_nbr_1_28 = null; 
			WhereConst_clinic_nbr_1_29 = null; 
			WhereConst_clinic_nbr_1_210 = null; 
			WhereConst_clinic_nbr_1_211 = null; 
			WhereConst_clinic_nbr_1_212 = null; 
			WhereConst_clinic_nbr_1_213 = null; 
			WhereConst_clinic_nbr_1_214 = null; 
			WhereConst_clinic_nbr_1_215 = null; 
			WhereConst_clinic_nbr_1_216 = null; 
			WhereConst_clinic_nbr_1_217 = null; 
			WhereConst_clinic_nbr_1_218 = null; 
			WhereConst_clinic_nbr_1_219 = null; 
			WhereConst_clinic_nbr_1_220 = null; 
			WhereConst_clinic_nbr_1_221 = null; 
			WhereConst_clinic_nbr_1_222 = null; 
			WhereConst_clinic_nbr_1_223 = null; 
			WhereConst_clinic_nbr_1_224 = null; 
			WhereConst_clinic_nbr_1_225 = null; 
			WhereConst_clinic_nbr_1_226 = null; 
			WhereConst_clinic_nbr_1_227 = null; 
			WhereConst_clinic_nbr_1_228 = null; 
			WhereConst_clinic_nbr_1_229 = null; 
			WhereConst_clinic_nbr_1_230 = null; 
			WhereConst_clinic_nbr_1_231 = null; 
			WhereConst_clinic_nbr_1_232 = null; 
			WhereConst_clinic_nbr_1_233 = null; 
			WhereConst_clinic_nbr_1_234 = null; 
			WhereConst_clinic_nbr_1_235 = null; 
			WhereConst_clinic_nbr_1_236 = null; 
			WhereConst_clinic_nbr_1_237 = null; 
			WhereConst_clinic_nbr_1_238 = null; 
			WhereConst_clinic_nbr_1_239 = null; 
			WhereConst_clinic_nbr_1_240 = null; 
			WhereConst_clinic_nbr1 = null; 
			WhereConst_clinic_nbr2 = null; 
			WhereConst_clinic_nbr3 = null; 
			WhereConst_clinic_nbr4 = null; 
			WhereConst_clinic_nbr5 = null; 
			WhereConst_clinic_nbr6 = null; 
			WhereConst_clinic_nbr7 = null; 
			WhereConst_clinic_nbr8 = null; 
			WhereConst_clinic_nbr9 = null; 
			WhereConst_clinic_nbr10 = null; 
			WhereConst_clinic_nbr11 = null; 
			WhereConst_clinic_nbr12 = null; 
			WhereConst_clinic_nbr13 = null; 
			WhereConst_clinic_nbr14 = null; 
			WhereConst_clinic_nbr15 = null; 
			WhereConst_clinic_nbr16 = null; 
			WhereConst_clinic_nbr17 = null; 
			WhereConst_clinic_nbr18 = null; 
			WhereConst_clinic_nbr19 = null; 
			WhereConst_clinic_nbr20 = null; 
			WhereConst_clinic_nbr21 = null; 
			WhereConst_clinic_nbr22 = null; 
			WhereConst_clinic_nbr23 = null; 
			WhereConst_clinic_nbr24 = null; 
			WhereConst_clinic_nbr25 = null; 
			WhereConst_clinic_nbr26 = null; 
			WhereConst_clinic_nbr27 = null; 
			WhereConst_clinic_nbr28 = null; 
			WhereConst_clinic_nbr29 = null; 
			WhereConst_clinic_nbr30 = null; 
			WhereConst_clinic_nbr31 = null; 
			WhereConst_clinic_nbr32 = null; 
			WhereConst_clinic_nbr33 = null; 
			WhereConst_clinic_nbr34 = null; 
			WhereConst_clinic_nbr35 = null; 
			WhereConst_clinic_nbr36 = null; 
			WhereConst_clinic_nbr37 = null; 
			WhereConst_clinic_nbr38 = null; 
			WhereConst_clinic_nbr39 = null; 
			WhereConst_clinic_nbr40 = null; 
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
		private decimal? _CONST_MAX_NBR_CLINICS;
		private decimal? _CONST_CLINIC_NBR_1_21;
		private decimal? _CONST_CLINIC_NBR_1_22;
		private decimal? _CONST_CLINIC_NBR_1_23;
		private decimal? _CONST_CLINIC_NBR_1_24;
		private decimal? _CONST_CLINIC_NBR_1_25;
		private decimal? _CONST_CLINIC_NBR_1_26;
		private decimal? _CONST_CLINIC_NBR_1_27;
		private decimal? _CONST_CLINIC_NBR_1_28;
		private decimal? _CONST_CLINIC_NBR_1_29;
		private decimal? _CONST_CLINIC_NBR_1_210;
		private decimal? _CONST_CLINIC_NBR_1_211;
		private decimal? _CONST_CLINIC_NBR_1_212;
		private decimal? _CONST_CLINIC_NBR_1_213;
		private decimal? _CONST_CLINIC_NBR_1_214;
		private decimal? _CONST_CLINIC_NBR_1_215;
		private decimal? _CONST_CLINIC_NBR_1_216;
		private decimal? _CONST_CLINIC_NBR_1_217;
		private decimal? _CONST_CLINIC_NBR_1_218;
		private decimal? _CONST_CLINIC_NBR_1_219;
		private decimal? _CONST_CLINIC_NBR_1_220;
		private decimal? _CONST_CLINIC_NBR_1_221;
		private decimal? _CONST_CLINIC_NBR_1_222;
		private decimal? _CONST_CLINIC_NBR_1_223;
		private decimal? _CONST_CLINIC_NBR_1_224;
		private decimal? _CONST_CLINIC_NBR_1_225;
		private decimal? _CONST_CLINIC_NBR_1_226;
		private decimal? _CONST_CLINIC_NBR_1_227;
		private decimal? _CONST_CLINIC_NBR_1_228;
		private decimal? _CONST_CLINIC_NBR_1_229;
		private decimal? _CONST_CLINIC_NBR_1_230;
		private decimal? _CONST_CLINIC_NBR_1_231;
		private decimal? _CONST_CLINIC_NBR_1_232;
		private decimal? _CONST_CLINIC_NBR_1_233;
		private decimal? _CONST_CLINIC_NBR_1_234;
		private decimal? _CONST_CLINIC_NBR_1_235;
		private decimal? _CONST_CLINIC_NBR_1_236;
		private decimal? _CONST_CLINIC_NBR_1_237;
		private decimal? _CONST_CLINIC_NBR_1_238;
		private decimal? _CONST_CLINIC_NBR_1_239;
		private decimal? _CONST_CLINIC_NBR_1_240;
		private string _CONST_CLINIC_NBR1;
		private string _CONST_CLINIC_NBR2;
		private string _CONST_CLINIC_NBR3;
		private string _CONST_CLINIC_NBR4;
		private string _CONST_CLINIC_NBR5;
		private string _CONST_CLINIC_NBR6;
		private string _CONST_CLINIC_NBR7;
		private string _CONST_CLINIC_NBR8;
		private string _CONST_CLINIC_NBR9;
		private string _CONST_CLINIC_NBR10;
		private string _CONST_CLINIC_NBR11;
		private string _CONST_CLINIC_NBR12;
		private string _CONST_CLINIC_NBR13;
		private string _CONST_CLINIC_NBR14;
		private string _CONST_CLINIC_NBR15;
		private string _CONST_CLINIC_NBR16;
		private string _CONST_CLINIC_NBR17;
		private string _CONST_CLINIC_NBR18;
		private string _CONST_CLINIC_NBR19;
		private string _CONST_CLINIC_NBR20;
		private string _CONST_CLINIC_NBR21;
		private string _CONST_CLINIC_NBR22;
		private string _CONST_CLINIC_NBR23;
		private string _CONST_CLINIC_NBR24;
		private string _CONST_CLINIC_NBR25;
		private string _CONST_CLINIC_NBR26;
		private string _CONST_CLINIC_NBR27;
		private string _CONST_CLINIC_NBR28;
		private string _CONST_CLINIC_NBR29;
		private string _CONST_CLINIC_NBR30;
		private string _CONST_CLINIC_NBR31;
		private string _CONST_CLINIC_NBR32;
		private string _CONST_CLINIC_NBR33;
		private string _CONST_CLINIC_NBR34;
		private string _CONST_CLINIC_NBR35;
		private string _CONST_CLINIC_NBR36;
		private string _CONST_CLINIC_NBR37;
		private string _CONST_CLINIC_NBR38;
		private string _CONST_CLINIC_NBR39;
		private string _CONST_CLINIC_NBR40;
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
		public decimal? CONST_MAX_NBR_CLINICS
		{
			get { return _CONST_MAX_NBR_CLINICS; }
			set
			{
				if (_CONST_MAX_NBR_CLINICS != value)
				{
					_CONST_MAX_NBR_CLINICS = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_21
		{
			get { return _CONST_CLINIC_NBR_1_21; }
			set
			{
				if (_CONST_CLINIC_NBR_1_21 != value)
				{
					_CONST_CLINIC_NBR_1_21 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_22
		{
			get { return _CONST_CLINIC_NBR_1_22; }
			set
			{
				if (_CONST_CLINIC_NBR_1_22 != value)
				{
					_CONST_CLINIC_NBR_1_22 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_23
		{
			get { return _CONST_CLINIC_NBR_1_23; }
			set
			{
				if (_CONST_CLINIC_NBR_1_23 != value)
				{
					_CONST_CLINIC_NBR_1_23 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_24
		{
			get { return _CONST_CLINIC_NBR_1_24; }
			set
			{
				if (_CONST_CLINIC_NBR_1_24 != value)
				{
					_CONST_CLINIC_NBR_1_24 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_25
		{
			get { return _CONST_CLINIC_NBR_1_25; }
			set
			{
				if (_CONST_CLINIC_NBR_1_25 != value)
				{
					_CONST_CLINIC_NBR_1_25 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_26
		{
			get { return _CONST_CLINIC_NBR_1_26; }
			set
			{
				if (_CONST_CLINIC_NBR_1_26 != value)
				{
					_CONST_CLINIC_NBR_1_26 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_27
		{
			get { return _CONST_CLINIC_NBR_1_27; }
			set
			{
				if (_CONST_CLINIC_NBR_1_27 != value)
				{
					_CONST_CLINIC_NBR_1_27 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_28
		{
			get { return _CONST_CLINIC_NBR_1_28; }
			set
			{
				if (_CONST_CLINIC_NBR_1_28 != value)
				{
					_CONST_CLINIC_NBR_1_28 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_29
		{
			get { return _CONST_CLINIC_NBR_1_29; }
			set
			{
				if (_CONST_CLINIC_NBR_1_29 != value)
				{
					_CONST_CLINIC_NBR_1_29 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_210
		{
			get { return _CONST_CLINIC_NBR_1_210; }
			set
			{
				if (_CONST_CLINIC_NBR_1_210 != value)
				{
					_CONST_CLINIC_NBR_1_210 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_211
		{
			get { return _CONST_CLINIC_NBR_1_211; }
			set
			{
				if (_CONST_CLINIC_NBR_1_211 != value)
				{
					_CONST_CLINIC_NBR_1_211 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_212
		{
			get { return _CONST_CLINIC_NBR_1_212; }
			set
			{
				if (_CONST_CLINIC_NBR_1_212 != value)
				{
					_CONST_CLINIC_NBR_1_212 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_213
		{
			get { return _CONST_CLINIC_NBR_1_213; }
			set
			{
				if (_CONST_CLINIC_NBR_1_213 != value)
				{
					_CONST_CLINIC_NBR_1_213 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_214
		{
			get { return _CONST_CLINIC_NBR_1_214; }
			set
			{
				if (_CONST_CLINIC_NBR_1_214 != value)
				{
					_CONST_CLINIC_NBR_1_214 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_215
		{
			get { return _CONST_CLINIC_NBR_1_215; }
			set
			{
				if (_CONST_CLINIC_NBR_1_215 != value)
				{
					_CONST_CLINIC_NBR_1_215 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_216
		{
			get { return _CONST_CLINIC_NBR_1_216; }
			set
			{
				if (_CONST_CLINIC_NBR_1_216 != value)
				{
					_CONST_CLINIC_NBR_1_216 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_217
		{
			get { return _CONST_CLINIC_NBR_1_217; }
			set
			{
				if (_CONST_CLINIC_NBR_1_217 != value)
				{
					_CONST_CLINIC_NBR_1_217 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_218
		{
			get { return _CONST_CLINIC_NBR_1_218; }
			set
			{
				if (_CONST_CLINIC_NBR_1_218 != value)
				{
					_CONST_CLINIC_NBR_1_218 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_219
		{
			get { return _CONST_CLINIC_NBR_1_219; }
			set
			{
				if (_CONST_CLINIC_NBR_1_219 != value)
				{
					_CONST_CLINIC_NBR_1_219 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_220
		{
			get { return _CONST_CLINIC_NBR_1_220; }
			set
			{
				if (_CONST_CLINIC_NBR_1_220 != value)
				{
					_CONST_CLINIC_NBR_1_220 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_221
		{
			get { return _CONST_CLINIC_NBR_1_221; }
			set
			{
				if (_CONST_CLINIC_NBR_1_221 != value)
				{
					_CONST_CLINIC_NBR_1_221 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_222
		{
			get { return _CONST_CLINIC_NBR_1_222; }
			set
			{
				if (_CONST_CLINIC_NBR_1_222 != value)
				{
					_CONST_CLINIC_NBR_1_222 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_223
		{
			get { return _CONST_CLINIC_NBR_1_223; }
			set
			{
				if (_CONST_CLINIC_NBR_1_223 != value)
				{
					_CONST_CLINIC_NBR_1_223 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_224
		{
			get { return _CONST_CLINIC_NBR_1_224; }
			set
			{
				if (_CONST_CLINIC_NBR_1_224 != value)
				{
					_CONST_CLINIC_NBR_1_224 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_225
		{
			get { return _CONST_CLINIC_NBR_1_225; }
			set
			{
				if (_CONST_CLINIC_NBR_1_225 != value)
				{
					_CONST_CLINIC_NBR_1_225 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_226
		{
			get { return _CONST_CLINIC_NBR_1_226; }
			set
			{
				if (_CONST_CLINIC_NBR_1_226 != value)
				{
					_CONST_CLINIC_NBR_1_226 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_227
		{
			get { return _CONST_CLINIC_NBR_1_227; }
			set
			{
				if (_CONST_CLINIC_NBR_1_227 != value)
				{
					_CONST_CLINIC_NBR_1_227 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_228
		{
			get { return _CONST_CLINIC_NBR_1_228; }
			set
			{
				if (_CONST_CLINIC_NBR_1_228 != value)
				{
					_CONST_CLINIC_NBR_1_228 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_229
		{
			get { return _CONST_CLINIC_NBR_1_229; }
			set
			{
				if (_CONST_CLINIC_NBR_1_229 != value)
				{
					_CONST_CLINIC_NBR_1_229 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_230
		{
			get { return _CONST_CLINIC_NBR_1_230; }
			set
			{
				if (_CONST_CLINIC_NBR_1_230 != value)
				{
					_CONST_CLINIC_NBR_1_230 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_231
		{
			get { return _CONST_CLINIC_NBR_1_231; }
			set
			{
				if (_CONST_CLINIC_NBR_1_231 != value)
				{
					_CONST_CLINIC_NBR_1_231 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_232
		{
			get { return _CONST_CLINIC_NBR_1_232; }
			set
			{
				if (_CONST_CLINIC_NBR_1_232 != value)
				{
					_CONST_CLINIC_NBR_1_232 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_233
		{
			get { return _CONST_CLINIC_NBR_1_233; }
			set
			{
				if (_CONST_CLINIC_NBR_1_233 != value)
				{
					_CONST_CLINIC_NBR_1_233 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_234
		{
			get { return _CONST_CLINIC_NBR_1_234; }
			set
			{
				if (_CONST_CLINIC_NBR_1_234 != value)
				{
					_CONST_CLINIC_NBR_1_234 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_235
		{
			get { return _CONST_CLINIC_NBR_1_235; }
			set
			{
				if (_CONST_CLINIC_NBR_1_235 != value)
				{
					_CONST_CLINIC_NBR_1_235 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_236
		{
			get { return _CONST_CLINIC_NBR_1_236; }
			set
			{
				if (_CONST_CLINIC_NBR_1_236 != value)
				{
					_CONST_CLINIC_NBR_1_236 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_237
		{
			get { return _CONST_CLINIC_NBR_1_237; }
			set
			{
				if (_CONST_CLINIC_NBR_1_237 != value)
				{
					_CONST_CLINIC_NBR_1_237 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_238
		{
			get { return _CONST_CLINIC_NBR_1_238; }
			set
			{
				if (_CONST_CLINIC_NBR_1_238 != value)
				{
					_CONST_CLINIC_NBR_1_238 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_239
		{
			get { return _CONST_CLINIC_NBR_1_239; }
			set
			{
				if (_CONST_CLINIC_NBR_1_239 != value)
				{
					_CONST_CLINIC_NBR_1_239 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_CLINIC_NBR_1_240
		{
			get { return _CONST_CLINIC_NBR_1_240; }
			set
			{
				if (_CONST_CLINIC_NBR_1_240 != value)
				{
					_CONST_CLINIC_NBR_1_240 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR1
		{
			get { return _CONST_CLINIC_NBR1; }
			set
			{
				if (_CONST_CLINIC_NBR1 != value)
				{
					_CONST_CLINIC_NBR1 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR2
		{
			get { return _CONST_CLINIC_NBR2; }
			set
			{
				if (_CONST_CLINIC_NBR2 != value)
				{
					_CONST_CLINIC_NBR2 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR3
		{
			get { return _CONST_CLINIC_NBR3; }
			set
			{
				if (_CONST_CLINIC_NBR3 != value)
				{
					_CONST_CLINIC_NBR3 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR4
		{
			get { return _CONST_CLINIC_NBR4; }
			set
			{
				if (_CONST_CLINIC_NBR4 != value)
				{
					_CONST_CLINIC_NBR4 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR5
		{
			get { return _CONST_CLINIC_NBR5; }
			set
			{
				if (_CONST_CLINIC_NBR5 != value)
				{
					_CONST_CLINIC_NBR5 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR6
		{
			get { return _CONST_CLINIC_NBR6; }
			set
			{
				if (_CONST_CLINIC_NBR6 != value)
				{
					_CONST_CLINIC_NBR6 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR7
		{
			get { return _CONST_CLINIC_NBR7; }
			set
			{
				if (_CONST_CLINIC_NBR7 != value)
				{
					_CONST_CLINIC_NBR7 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR8
		{
			get { return _CONST_CLINIC_NBR8; }
			set
			{
				if (_CONST_CLINIC_NBR8 != value)
				{
					_CONST_CLINIC_NBR8 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR9
		{
			get { return _CONST_CLINIC_NBR9; }
			set
			{
				if (_CONST_CLINIC_NBR9 != value)
				{
					_CONST_CLINIC_NBR9 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR10
		{
			get { return _CONST_CLINIC_NBR10; }
			set
			{
				if (_CONST_CLINIC_NBR10 != value)
				{
					_CONST_CLINIC_NBR10 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR11
		{
			get { return _CONST_CLINIC_NBR11; }
			set
			{
				if (_CONST_CLINIC_NBR11 != value)
				{
					_CONST_CLINIC_NBR11 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR12
		{
			get { return _CONST_CLINIC_NBR12; }
			set
			{
				if (_CONST_CLINIC_NBR12 != value)
				{
					_CONST_CLINIC_NBR12 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR13
		{
			get { return _CONST_CLINIC_NBR13; }
			set
			{
				if (_CONST_CLINIC_NBR13 != value)
				{
					_CONST_CLINIC_NBR13 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR14
		{
			get { return _CONST_CLINIC_NBR14; }
			set
			{
				if (_CONST_CLINIC_NBR14 != value)
				{
					_CONST_CLINIC_NBR14 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR15
		{
			get { return _CONST_CLINIC_NBR15; }
			set
			{
				if (_CONST_CLINIC_NBR15 != value)
				{
					_CONST_CLINIC_NBR15 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR16
		{
			get { return _CONST_CLINIC_NBR16; }
			set
			{
				if (_CONST_CLINIC_NBR16 != value)
				{
					_CONST_CLINIC_NBR16 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR17
		{
			get { return _CONST_CLINIC_NBR17; }
			set
			{
				if (_CONST_CLINIC_NBR17 != value)
				{
					_CONST_CLINIC_NBR17 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR18
		{
			get { return _CONST_CLINIC_NBR18; }
			set
			{
				if (_CONST_CLINIC_NBR18 != value)
				{
					_CONST_CLINIC_NBR18 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR19
		{
			get { return _CONST_CLINIC_NBR19; }
			set
			{
				if (_CONST_CLINIC_NBR19 != value)
				{
					_CONST_CLINIC_NBR19 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR20
		{
			get { return _CONST_CLINIC_NBR20; }
			set
			{
				if (_CONST_CLINIC_NBR20 != value)
				{
					_CONST_CLINIC_NBR20 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR21
		{
			get { return _CONST_CLINIC_NBR21; }
			set
			{
				if (_CONST_CLINIC_NBR21 != value)
				{
					_CONST_CLINIC_NBR21 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR22
		{
			get { return _CONST_CLINIC_NBR22; }
			set
			{
				if (_CONST_CLINIC_NBR22 != value)
				{
					_CONST_CLINIC_NBR22 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR23
		{
			get { return _CONST_CLINIC_NBR23; }
			set
			{
				if (_CONST_CLINIC_NBR23 != value)
				{
					_CONST_CLINIC_NBR23 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR24
		{
			get { return _CONST_CLINIC_NBR24; }
			set
			{
				if (_CONST_CLINIC_NBR24 != value)
				{
					_CONST_CLINIC_NBR24 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR25
		{
			get { return _CONST_CLINIC_NBR25; }
			set
			{
				if (_CONST_CLINIC_NBR25 != value)
				{
					_CONST_CLINIC_NBR25 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR26
		{
			get { return _CONST_CLINIC_NBR26; }
			set
			{
				if (_CONST_CLINIC_NBR26 != value)
				{
					_CONST_CLINIC_NBR26 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR27
		{
			get { return _CONST_CLINIC_NBR27; }
			set
			{
				if (_CONST_CLINIC_NBR27 != value)
				{
					_CONST_CLINIC_NBR27 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR28
		{
			get { return _CONST_CLINIC_NBR28; }
			set
			{
				if (_CONST_CLINIC_NBR28 != value)
				{
					_CONST_CLINIC_NBR28 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR29
		{
			get { return _CONST_CLINIC_NBR29; }
			set
			{
				if (_CONST_CLINIC_NBR29 != value)
				{
					_CONST_CLINIC_NBR29 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR30
		{
			get { return _CONST_CLINIC_NBR30; }
			set
			{
				if (_CONST_CLINIC_NBR30 != value)
				{
					_CONST_CLINIC_NBR30 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR31
		{
			get { return _CONST_CLINIC_NBR31; }
			set
			{
				if (_CONST_CLINIC_NBR31 != value)
				{
					_CONST_CLINIC_NBR31 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR32
		{
			get { return _CONST_CLINIC_NBR32; }
			set
			{
				if (_CONST_CLINIC_NBR32 != value)
				{
					_CONST_CLINIC_NBR32 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR33
		{
			get { return _CONST_CLINIC_NBR33; }
			set
			{
				if (_CONST_CLINIC_NBR33 != value)
				{
					_CONST_CLINIC_NBR33 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR34
		{
			get { return _CONST_CLINIC_NBR34; }
			set
			{
				if (_CONST_CLINIC_NBR34 != value)
				{
					_CONST_CLINIC_NBR34 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR35
		{
			get { return _CONST_CLINIC_NBR35; }
			set
			{
				if (_CONST_CLINIC_NBR35 != value)
				{
					_CONST_CLINIC_NBR35 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR36
		{
			get { return _CONST_CLINIC_NBR36; }
			set
			{
				if (_CONST_CLINIC_NBR36 != value)
				{
					_CONST_CLINIC_NBR36 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR37
		{
			get { return _CONST_CLINIC_NBR37; }
			set
			{
				if (_CONST_CLINIC_NBR37 != value)
				{
					_CONST_CLINIC_NBR37 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR38
		{
			get { return _CONST_CLINIC_NBR38; }
			set
			{
				if (_CONST_CLINIC_NBR38 != value)
				{
					_CONST_CLINIC_NBR38 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR39
		{
			get { return _CONST_CLINIC_NBR39; }
			set
			{
				if (_CONST_CLINIC_NBR39 != value)
				{
					_CONST_CLINIC_NBR39 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLINIC_NBR40
		{
			get { return _CONST_CLINIC_NBR40; }
			set
			{
				if (_CONST_CLINIC_NBR40 != value)
				{
					_CONST_CLINIC_NBR40 = value;
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
		public decimal? WhereConst_max_nbr_clinics { get; set; }
		private decimal? _whereConst_max_nbr_clinics;
		public decimal? WhereConst_clinic_nbr_1_21 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_21;
		public decimal? WhereConst_clinic_nbr_1_22 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_22;
		public decimal? WhereConst_clinic_nbr_1_23 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_23;
		public decimal? WhereConst_clinic_nbr_1_24 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_24;
		public decimal? WhereConst_clinic_nbr_1_25 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_25;
		public decimal? WhereConst_clinic_nbr_1_26 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_26;
		public decimal? WhereConst_clinic_nbr_1_27 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_27;
		public decimal? WhereConst_clinic_nbr_1_28 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_28;
		public decimal? WhereConst_clinic_nbr_1_29 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_29;
		public decimal? WhereConst_clinic_nbr_1_210 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_210;
		public decimal? WhereConst_clinic_nbr_1_211 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_211;
		public decimal? WhereConst_clinic_nbr_1_212 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_212;
		public decimal? WhereConst_clinic_nbr_1_213 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_213;
		public decimal? WhereConst_clinic_nbr_1_214 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_214;
		public decimal? WhereConst_clinic_nbr_1_215 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_215;
		public decimal? WhereConst_clinic_nbr_1_216 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_216;
		public decimal? WhereConst_clinic_nbr_1_217 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_217;
		public decimal? WhereConst_clinic_nbr_1_218 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_218;
		public decimal? WhereConst_clinic_nbr_1_219 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_219;
		public decimal? WhereConst_clinic_nbr_1_220 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_220;
		public decimal? WhereConst_clinic_nbr_1_221 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_221;
		public decimal? WhereConst_clinic_nbr_1_222 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_222;
		public decimal? WhereConst_clinic_nbr_1_223 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_223;
		public decimal? WhereConst_clinic_nbr_1_224 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_224;
		public decimal? WhereConst_clinic_nbr_1_225 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_225;
		public decimal? WhereConst_clinic_nbr_1_226 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_226;
		public decimal? WhereConst_clinic_nbr_1_227 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_227;
		public decimal? WhereConst_clinic_nbr_1_228 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_228;
		public decimal? WhereConst_clinic_nbr_1_229 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_229;
		public decimal? WhereConst_clinic_nbr_1_230 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_230;
		public decimal? WhereConst_clinic_nbr_1_231 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_231;
		public decimal? WhereConst_clinic_nbr_1_232 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_232;
		public decimal? WhereConst_clinic_nbr_1_233 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_233;
		public decimal? WhereConst_clinic_nbr_1_234 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_234;
		public decimal? WhereConst_clinic_nbr_1_235 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_235;
		public decimal? WhereConst_clinic_nbr_1_236 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_236;
		public decimal? WhereConst_clinic_nbr_1_237 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_237;
		public decimal? WhereConst_clinic_nbr_1_238 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_238;
		public decimal? WhereConst_clinic_nbr_1_239 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_239;
		public decimal? WhereConst_clinic_nbr_1_240 { get; set; }
		private decimal? _whereConst_clinic_nbr_1_240;
		public string WhereConst_clinic_nbr1 { get; set; }
		private string _whereConst_clinic_nbr1;
		public string WhereConst_clinic_nbr2 { get; set; }
		private string _whereConst_clinic_nbr2;
		public string WhereConst_clinic_nbr3 { get; set; }
		private string _whereConst_clinic_nbr3;
		public string WhereConst_clinic_nbr4 { get; set; }
		private string _whereConst_clinic_nbr4;
		public string WhereConst_clinic_nbr5 { get; set; }
		private string _whereConst_clinic_nbr5;
		public string WhereConst_clinic_nbr6 { get; set; }
		private string _whereConst_clinic_nbr6;
		public string WhereConst_clinic_nbr7 { get; set; }
		private string _whereConst_clinic_nbr7;
		public string WhereConst_clinic_nbr8 { get; set; }
		private string _whereConst_clinic_nbr8;
		public string WhereConst_clinic_nbr9 { get; set; }
		private string _whereConst_clinic_nbr9;
		public string WhereConst_clinic_nbr10 { get; set; }
		private string _whereConst_clinic_nbr10;
		public string WhereConst_clinic_nbr11 { get; set; }
		private string _whereConst_clinic_nbr11;
		public string WhereConst_clinic_nbr12 { get; set; }
		private string _whereConst_clinic_nbr12;
		public string WhereConst_clinic_nbr13 { get; set; }
		private string _whereConst_clinic_nbr13;
		public string WhereConst_clinic_nbr14 { get; set; }
		private string _whereConst_clinic_nbr14;
		public string WhereConst_clinic_nbr15 { get; set; }
		private string _whereConst_clinic_nbr15;
		public string WhereConst_clinic_nbr16 { get; set; }
		private string _whereConst_clinic_nbr16;
		public string WhereConst_clinic_nbr17 { get; set; }
		private string _whereConst_clinic_nbr17;
		public string WhereConst_clinic_nbr18 { get; set; }
		private string _whereConst_clinic_nbr18;
		public string WhereConst_clinic_nbr19 { get; set; }
		private string _whereConst_clinic_nbr19;
		public string WhereConst_clinic_nbr20 { get; set; }
		private string _whereConst_clinic_nbr20;
		public string WhereConst_clinic_nbr21 { get; set; }
		private string _whereConst_clinic_nbr21;
		public string WhereConst_clinic_nbr22 { get; set; }
		private string _whereConst_clinic_nbr22;
		public string WhereConst_clinic_nbr23 { get; set; }
		private string _whereConst_clinic_nbr23;
		public string WhereConst_clinic_nbr24 { get; set; }
		private string _whereConst_clinic_nbr24;
		public string WhereConst_clinic_nbr25 { get; set; }
		private string _whereConst_clinic_nbr25;
		public string WhereConst_clinic_nbr26 { get; set; }
		private string _whereConst_clinic_nbr26;
		public string WhereConst_clinic_nbr27 { get; set; }
		private string _whereConst_clinic_nbr27;
		public string WhereConst_clinic_nbr28 { get; set; }
		private string _whereConst_clinic_nbr28;
		public string WhereConst_clinic_nbr29 { get; set; }
		private string _whereConst_clinic_nbr29;
		public string WhereConst_clinic_nbr30 { get; set; }
		private string _whereConst_clinic_nbr30;
		public string WhereConst_clinic_nbr31 { get; set; }
		private string _whereConst_clinic_nbr31;
		public string WhereConst_clinic_nbr32 { get; set; }
		private string _whereConst_clinic_nbr32;
		public string WhereConst_clinic_nbr33 { get; set; }
		private string _whereConst_clinic_nbr33;
		public string WhereConst_clinic_nbr34 { get; set; }
		private string _whereConst_clinic_nbr34;
		public string WhereConst_clinic_nbr35 { get; set; }
		private string _whereConst_clinic_nbr35;
		public string WhereConst_clinic_nbr36 { get; set; }
		private string _whereConst_clinic_nbr36;
		public string WhereConst_clinic_nbr37 { get; set; }
		private string _whereConst_clinic_nbr37;
		public string WhereConst_clinic_nbr38 { get; set; }
		private string _whereConst_clinic_nbr38;
		public string WhereConst_clinic_nbr39 { get; set; }
		private string _whereConst_clinic_nbr39;
		public string WhereConst_clinic_nbr40 { get; set; }
		private string _whereConst_clinic_nbr40;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_max_nbr_clinics;
		private decimal? _originalConst_clinic_nbr_1_21;
		private decimal? _originalConst_clinic_nbr_1_22;
		private decimal? _originalConst_clinic_nbr_1_23;
		private decimal? _originalConst_clinic_nbr_1_24;
		private decimal? _originalConst_clinic_nbr_1_25;
		private decimal? _originalConst_clinic_nbr_1_26;
		private decimal? _originalConst_clinic_nbr_1_27;
		private decimal? _originalConst_clinic_nbr_1_28;
		private decimal? _originalConst_clinic_nbr_1_29;
		private decimal? _originalConst_clinic_nbr_1_210;
		private decimal? _originalConst_clinic_nbr_1_211;
		private decimal? _originalConst_clinic_nbr_1_212;
		private decimal? _originalConst_clinic_nbr_1_213;
		private decimal? _originalConst_clinic_nbr_1_214;
		private decimal? _originalConst_clinic_nbr_1_215;
		private decimal? _originalConst_clinic_nbr_1_216;
		private decimal? _originalConst_clinic_nbr_1_217;
		private decimal? _originalConst_clinic_nbr_1_218;
		private decimal? _originalConst_clinic_nbr_1_219;
		private decimal? _originalConst_clinic_nbr_1_220;
		private decimal? _originalConst_clinic_nbr_1_221;
		private decimal? _originalConst_clinic_nbr_1_222;
		private decimal? _originalConst_clinic_nbr_1_223;
		private decimal? _originalConst_clinic_nbr_1_224;
		private decimal? _originalConst_clinic_nbr_1_225;
		private decimal? _originalConst_clinic_nbr_1_226;
		private decimal? _originalConst_clinic_nbr_1_227;
		private decimal? _originalConst_clinic_nbr_1_228;
		private decimal? _originalConst_clinic_nbr_1_229;
		private decimal? _originalConst_clinic_nbr_1_230;
		private decimal? _originalConst_clinic_nbr_1_231;
		private decimal? _originalConst_clinic_nbr_1_232;
		private decimal? _originalConst_clinic_nbr_1_233;
		private decimal? _originalConst_clinic_nbr_1_234;
		private decimal? _originalConst_clinic_nbr_1_235;
		private decimal? _originalConst_clinic_nbr_1_236;
		private decimal? _originalConst_clinic_nbr_1_237;
		private decimal? _originalConst_clinic_nbr_1_238;
		private decimal? _originalConst_clinic_nbr_1_239;
		private decimal? _originalConst_clinic_nbr_1_240;
		private string _originalConst_clinic_nbr1;
		private string _originalConst_clinic_nbr2;
		private string _originalConst_clinic_nbr3;
		private string _originalConst_clinic_nbr4;
		private string _originalConst_clinic_nbr5;
		private string _originalConst_clinic_nbr6;
		private string _originalConst_clinic_nbr7;
		private string _originalConst_clinic_nbr8;
		private string _originalConst_clinic_nbr9;
		private string _originalConst_clinic_nbr10;
		private string _originalConst_clinic_nbr11;
		private string _originalConst_clinic_nbr12;
		private string _originalConst_clinic_nbr13;
		private string _originalConst_clinic_nbr14;
		private string _originalConst_clinic_nbr15;
		private string _originalConst_clinic_nbr16;
		private string _originalConst_clinic_nbr17;
		private string _originalConst_clinic_nbr18;
		private string _originalConst_clinic_nbr19;
		private string _originalConst_clinic_nbr20;
		private string _originalConst_clinic_nbr21;
		private string _originalConst_clinic_nbr22;
		private string _originalConst_clinic_nbr23;
		private string _originalConst_clinic_nbr24;
		private string _originalConst_clinic_nbr25;
		private string _originalConst_clinic_nbr26;
		private string _originalConst_clinic_nbr27;
		private string _originalConst_clinic_nbr28;
		private string _originalConst_clinic_nbr29;
		private string _originalConst_clinic_nbr30;
		private string _originalConst_clinic_nbr31;
		private string _originalConst_clinic_nbr32;
		private string _originalConst_clinic_nbr33;
		private string _originalConst_clinic_nbr34;
		private string _originalConst_clinic_nbr35;
		private string _originalConst_clinic_nbr36;
		private string _originalConst_clinic_nbr37;
		private string _originalConst_clinic_nbr38;
		private string _originalConst_clinic_nbr39;
		private string _originalConst_clinic_nbr40;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_MAX_NBR_CLINICS = _originalConst_max_nbr_clinics;
			CONST_CLINIC_NBR_1_21 = _originalConst_clinic_nbr_1_21;
			CONST_CLINIC_NBR_1_22 = _originalConst_clinic_nbr_1_22;
			CONST_CLINIC_NBR_1_23 = _originalConst_clinic_nbr_1_23;
			CONST_CLINIC_NBR_1_24 = _originalConst_clinic_nbr_1_24;
			CONST_CLINIC_NBR_1_25 = _originalConst_clinic_nbr_1_25;
			CONST_CLINIC_NBR_1_26 = _originalConst_clinic_nbr_1_26;
			CONST_CLINIC_NBR_1_27 = _originalConst_clinic_nbr_1_27;
			CONST_CLINIC_NBR_1_28 = _originalConst_clinic_nbr_1_28;
			CONST_CLINIC_NBR_1_29 = _originalConst_clinic_nbr_1_29;
			CONST_CLINIC_NBR_1_210 = _originalConst_clinic_nbr_1_210;
			CONST_CLINIC_NBR_1_211 = _originalConst_clinic_nbr_1_211;
			CONST_CLINIC_NBR_1_212 = _originalConst_clinic_nbr_1_212;
			CONST_CLINIC_NBR_1_213 = _originalConst_clinic_nbr_1_213;
			CONST_CLINIC_NBR_1_214 = _originalConst_clinic_nbr_1_214;
			CONST_CLINIC_NBR_1_215 = _originalConst_clinic_nbr_1_215;
			CONST_CLINIC_NBR_1_216 = _originalConst_clinic_nbr_1_216;
			CONST_CLINIC_NBR_1_217 = _originalConst_clinic_nbr_1_217;
			CONST_CLINIC_NBR_1_218 = _originalConst_clinic_nbr_1_218;
			CONST_CLINIC_NBR_1_219 = _originalConst_clinic_nbr_1_219;
			CONST_CLINIC_NBR_1_220 = _originalConst_clinic_nbr_1_220;
			CONST_CLINIC_NBR_1_221 = _originalConst_clinic_nbr_1_221;
			CONST_CLINIC_NBR_1_222 = _originalConst_clinic_nbr_1_222;
			CONST_CLINIC_NBR_1_223 = _originalConst_clinic_nbr_1_223;
			CONST_CLINIC_NBR_1_224 = _originalConst_clinic_nbr_1_224;
			CONST_CLINIC_NBR_1_225 = _originalConst_clinic_nbr_1_225;
			CONST_CLINIC_NBR_1_226 = _originalConst_clinic_nbr_1_226;
			CONST_CLINIC_NBR_1_227 = _originalConst_clinic_nbr_1_227;
			CONST_CLINIC_NBR_1_228 = _originalConst_clinic_nbr_1_228;
			CONST_CLINIC_NBR_1_229 = _originalConst_clinic_nbr_1_229;
			CONST_CLINIC_NBR_1_230 = _originalConst_clinic_nbr_1_230;
			CONST_CLINIC_NBR_1_231 = _originalConst_clinic_nbr_1_231;
			CONST_CLINIC_NBR_1_232 = _originalConst_clinic_nbr_1_232;
			CONST_CLINIC_NBR_1_233 = _originalConst_clinic_nbr_1_233;
			CONST_CLINIC_NBR_1_234 = _originalConst_clinic_nbr_1_234;
			CONST_CLINIC_NBR_1_235 = _originalConst_clinic_nbr_1_235;
			CONST_CLINIC_NBR_1_236 = _originalConst_clinic_nbr_1_236;
			CONST_CLINIC_NBR_1_237 = _originalConst_clinic_nbr_1_237;
			CONST_CLINIC_NBR_1_238 = _originalConst_clinic_nbr_1_238;
			CONST_CLINIC_NBR_1_239 = _originalConst_clinic_nbr_1_239;
			CONST_CLINIC_NBR_1_240 = _originalConst_clinic_nbr_1_240;
			CONST_CLINIC_NBR1 = _originalConst_clinic_nbr1;
			CONST_CLINIC_NBR2 = _originalConst_clinic_nbr2;
			CONST_CLINIC_NBR3 = _originalConst_clinic_nbr3;
			CONST_CLINIC_NBR4 = _originalConst_clinic_nbr4;
			CONST_CLINIC_NBR5 = _originalConst_clinic_nbr5;
			CONST_CLINIC_NBR6 = _originalConst_clinic_nbr6;
			CONST_CLINIC_NBR7 = _originalConst_clinic_nbr7;
			CONST_CLINIC_NBR8 = _originalConst_clinic_nbr8;
			CONST_CLINIC_NBR9 = _originalConst_clinic_nbr9;
			CONST_CLINIC_NBR10 = _originalConst_clinic_nbr10;
			CONST_CLINIC_NBR11 = _originalConst_clinic_nbr11;
			CONST_CLINIC_NBR12 = _originalConst_clinic_nbr12;
			CONST_CLINIC_NBR13 = _originalConst_clinic_nbr13;
			CONST_CLINIC_NBR14 = _originalConst_clinic_nbr14;
			CONST_CLINIC_NBR15 = _originalConst_clinic_nbr15;
			CONST_CLINIC_NBR16 = _originalConst_clinic_nbr16;
			CONST_CLINIC_NBR17 = _originalConst_clinic_nbr17;
			CONST_CLINIC_NBR18 = _originalConst_clinic_nbr18;
			CONST_CLINIC_NBR19 = _originalConst_clinic_nbr19;
			CONST_CLINIC_NBR20 = _originalConst_clinic_nbr20;
			CONST_CLINIC_NBR21 = _originalConst_clinic_nbr21;
			CONST_CLINIC_NBR22 = _originalConst_clinic_nbr22;
			CONST_CLINIC_NBR23 = _originalConst_clinic_nbr23;
			CONST_CLINIC_NBR24 = _originalConst_clinic_nbr24;
			CONST_CLINIC_NBR25 = _originalConst_clinic_nbr25;
			CONST_CLINIC_NBR26 = _originalConst_clinic_nbr26;
			CONST_CLINIC_NBR27 = _originalConst_clinic_nbr27;
			CONST_CLINIC_NBR28 = _originalConst_clinic_nbr28;
			CONST_CLINIC_NBR29 = _originalConst_clinic_nbr29;
			CONST_CLINIC_NBR30 = _originalConst_clinic_nbr30;
			CONST_CLINIC_NBR31 = _originalConst_clinic_nbr31;
			CONST_CLINIC_NBR32 = _originalConst_clinic_nbr32;
			CONST_CLINIC_NBR33 = _originalConst_clinic_nbr33;
			CONST_CLINIC_NBR34 = _originalConst_clinic_nbr34;
			CONST_CLINIC_NBR35 = _originalConst_clinic_nbr35;
			CONST_CLINIC_NBR36 = _originalConst_clinic_nbr36;
			CONST_CLINIC_NBR37 = _originalConst_clinic_nbr37;
			CONST_CLINIC_NBR38 = _originalConst_clinic_nbr38;
			CONST_CLINIC_NBR39 = _originalConst_clinic_nbr39;
			CONST_CLINIC_NBR40 = _originalConst_clinic_nbr40;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_Purge]");
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
						new SqlParameter("CONST_MAX_NBR_CLINICS", SqlNull(CONST_MAX_NBR_CLINICS)),
						new SqlParameter("CONST_CLINIC_NBR_1_21", SqlNull(CONST_CLINIC_NBR_1_21)),
						new SqlParameter("CONST_CLINIC_NBR_1_22", SqlNull(CONST_CLINIC_NBR_1_22)),
						new SqlParameter("CONST_CLINIC_NBR_1_23", SqlNull(CONST_CLINIC_NBR_1_23)),
						new SqlParameter("CONST_CLINIC_NBR_1_24", SqlNull(CONST_CLINIC_NBR_1_24)),
						new SqlParameter("CONST_CLINIC_NBR_1_25", SqlNull(CONST_CLINIC_NBR_1_25)),
						new SqlParameter("CONST_CLINIC_NBR_1_26", SqlNull(CONST_CLINIC_NBR_1_26)),
						new SqlParameter("CONST_CLINIC_NBR_1_27", SqlNull(CONST_CLINIC_NBR_1_27)),
						new SqlParameter("CONST_CLINIC_NBR_1_28", SqlNull(CONST_CLINIC_NBR_1_28)),
						new SqlParameter("CONST_CLINIC_NBR_1_29", SqlNull(CONST_CLINIC_NBR_1_29)),
						new SqlParameter("CONST_CLINIC_NBR_1_210", SqlNull(CONST_CLINIC_NBR_1_210)),
						new SqlParameter("CONST_CLINIC_NBR_1_211", SqlNull(CONST_CLINIC_NBR_1_211)),
						new SqlParameter("CONST_CLINIC_NBR_1_212", SqlNull(CONST_CLINIC_NBR_1_212)),
						new SqlParameter("CONST_CLINIC_NBR_1_213", SqlNull(CONST_CLINIC_NBR_1_213)),
						new SqlParameter("CONST_CLINIC_NBR_1_214", SqlNull(CONST_CLINIC_NBR_1_214)),
						new SqlParameter("CONST_CLINIC_NBR_1_215", SqlNull(CONST_CLINIC_NBR_1_215)),
						new SqlParameter("CONST_CLINIC_NBR_1_216", SqlNull(CONST_CLINIC_NBR_1_216)),
						new SqlParameter("CONST_CLINIC_NBR_1_217", SqlNull(CONST_CLINIC_NBR_1_217)),
						new SqlParameter("CONST_CLINIC_NBR_1_218", SqlNull(CONST_CLINIC_NBR_1_218)),
						new SqlParameter("CONST_CLINIC_NBR_1_219", SqlNull(CONST_CLINIC_NBR_1_219)),
						new SqlParameter("CONST_CLINIC_NBR_1_220", SqlNull(CONST_CLINIC_NBR_1_220)),
						new SqlParameter("CONST_CLINIC_NBR_1_221", SqlNull(CONST_CLINIC_NBR_1_221)),
						new SqlParameter("CONST_CLINIC_NBR_1_222", SqlNull(CONST_CLINIC_NBR_1_222)),
						new SqlParameter("CONST_CLINIC_NBR_1_223", SqlNull(CONST_CLINIC_NBR_1_223)),
						new SqlParameter("CONST_CLINIC_NBR_1_224", SqlNull(CONST_CLINIC_NBR_1_224)),
						new SqlParameter("CONST_CLINIC_NBR_1_225", SqlNull(CONST_CLINIC_NBR_1_225)),
						new SqlParameter("CONST_CLINIC_NBR_1_226", SqlNull(CONST_CLINIC_NBR_1_226)),
						new SqlParameter("CONST_CLINIC_NBR_1_227", SqlNull(CONST_CLINIC_NBR_1_227)),
						new SqlParameter("CONST_CLINIC_NBR_1_228", SqlNull(CONST_CLINIC_NBR_1_228)),
						new SqlParameter("CONST_CLINIC_NBR_1_229", SqlNull(CONST_CLINIC_NBR_1_229)),
						new SqlParameter("CONST_CLINIC_NBR_1_230", SqlNull(CONST_CLINIC_NBR_1_230)),
						new SqlParameter("CONST_CLINIC_NBR_1_231", SqlNull(CONST_CLINIC_NBR_1_231)),
						new SqlParameter("CONST_CLINIC_NBR_1_232", SqlNull(CONST_CLINIC_NBR_1_232)),
						new SqlParameter("CONST_CLINIC_NBR_1_233", SqlNull(CONST_CLINIC_NBR_1_233)),
						new SqlParameter("CONST_CLINIC_NBR_1_234", SqlNull(CONST_CLINIC_NBR_1_234)),
						new SqlParameter("CONST_CLINIC_NBR_1_235", SqlNull(CONST_CLINIC_NBR_1_235)),
						new SqlParameter("CONST_CLINIC_NBR_1_236", SqlNull(CONST_CLINIC_NBR_1_236)),
						new SqlParameter("CONST_CLINIC_NBR_1_237", SqlNull(CONST_CLINIC_NBR_1_237)),
						new SqlParameter("CONST_CLINIC_NBR_1_238", SqlNull(CONST_CLINIC_NBR_1_238)),
						new SqlParameter("CONST_CLINIC_NBR_1_239", SqlNull(CONST_CLINIC_NBR_1_239)),
						new SqlParameter("CONST_CLINIC_NBR_1_240", SqlNull(CONST_CLINIC_NBR_1_240)),
						new SqlParameter("CONST_CLINIC_NBR1", SqlNull(CONST_CLINIC_NBR1)),
						new SqlParameter("CONST_CLINIC_NBR2", SqlNull(CONST_CLINIC_NBR2)),
						new SqlParameter("CONST_CLINIC_NBR3", SqlNull(CONST_CLINIC_NBR3)),
						new SqlParameter("CONST_CLINIC_NBR4", SqlNull(CONST_CLINIC_NBR4)),
						new SqlParameter("CONST_CLINIC_NBR5", SqlNull(CONST_CLINIC_NBR5)),
						new SqlParameter("CONST_CLINIC_NBR6", SqlNull(CONST_CLINIC_NBR6)),
						new SqlParameter("CONST_CLINIC_NBR7", SqlNull(CONST_CLINIC_NBR7)),
						new SqlParameter("CONST_CLINIC_NBR8", SqlNull(CONST_CLINIC_NBR8)),
						new SqlParameter("CONST_CLINIC_NBR9", SqlNull(CONST_CLINIC_NBR9)),
						new SqlParameter("CONST_CLINIC_NBR10", SqlNull(CONST_CLINIC_NBR10)),
						new SqlParameter("CONST_CLINIC_NBR11", SqlNull(CONST_CLINIC_NBR11)),
						new SqlParameter("CONST_CLINIC_NBR12", SqlNull(CONST_CLINIC_NBR12)),
						new SqlParameter("CONST_CLINIC_NBR13", SqlNull(CONST_CLINIC_NBR13)),
						new SqlParameter("CONST_CLINIC_NBR14", SqlNull(CONST_CLINIC_NBR14)),
						new SqlParameter("CONST_CLINIC_NBR15", SqlNull(CONST_CLINIC_NBR15)),
						new SqlParameter("CONST_CLINIC_NBR16", SqlNull(CONST_CLINIC_NBR16)),
						new SqlParameter("CONST_CLINIC_NBR17", SqlNull(CONST_CLINIC_NBR17)),
						new SqlParameter("CONST_CLINIC_NBR18", SqlNull(CONST_CLINIC_NBR18)),
						new SqlParameter("CONST_CLINIC_NBR19", SqlNull(CONST_CLINIC_NBR19)),
						new SqlParameter("CONST_CLINIC_NBR20", SqlNull(CONST_CLINIC_NBR20)),
						new SqlParameter("CONST_CLINIC_NBR21", SqlNull(CONST_CLINIC_NBR21)),
						new SqlParameter("CONST_CLINIC_NBR22", SqlNull(CONST_CLINIC_NBR22)),
						new SqlParameter("CONST_CLINIC_NBR23", SqlNull(CONST_CLINIC_NBR23)),
						new SqlParameter("CONST_CLINIC_NBR24", SqlNull(CONST_CLINIC_NBR24)),
						new SqlParameter("CONST_CLINIC_NBR25", SqlNull(CONST_CLINIC_NBR25)),
						new SqlParameter("CONST_CLINIC_NBR26", SqlNull(CONST_CLINIC_NBR26)),
						new SqlParameter("CONST_CLINIC_NBR27", SqlNull(CONST_CLINIC_NBR27)),
						new SqlParameter("CONST_CLINIC_NBR28", SqlNull(CONST_CLINIC_NBR28)),
						new SqlParameter("CONST_CLINIC_NBR29", SqlNull(CONST_CLINIC_NBR29)),
						new SqlParameter("CONST_CLINIC_NBR30", SqlNull(CONST_CLINIC_NBR30)),
						new SqlParameter("CONST_CLINIC_NBR31", SqlNull(CONST_CLINIC_NBR31)),
						new SqlParameter("CONST_CLINIC_NBR32", SqlNull(CONST_CLINIC_NBR32)),
						new SqlParameter("CONST_CLINIC_NBR33", SqlNull(CONST_CLINIC_NBR33)),
						new SqlParameter("CONST_CLINIC_NBR34", SqlNull(CONST_CLINIC_NBR34)),
						new SqlParameter("CONST_CLINIC_NBR35", SqlNull(CONST_CLINIC_NBR35)),
						new SqlParameter("CONST_CLINIC_NBR36", SqlNull(CONST_CLINIC_NBR36)),
						new SqlParameter("CONST_CLINIC_NBR37", SqlNull(CONST_CLINIC_NBR37)),
						new SqlParameter("CONST_CLINIC_NBR38", SqlNull(CONST_CLINIC_NBR38)),
						new SqlParameter("CONST_CLINIC_NBR39", SqlNull(CONST_CLINIC_NBR39)),
						new SqlParameter("CONST_CLINIC_NBR40", SqlNull(CONST_CLINIC_NBR40)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_MAX_NBR_CLINICS = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]);
						CONST_CLINIC_NBR_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]);
						CONST_CLINIC_NBR_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]);
						CONST_CLINIC_NBR_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]);
						CONST_CLINIC_NBR_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]);
						CONST_CLINIC_NBR_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]);
						CONST_CLINIC_NBR_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]);
						CONST_CLINIC_NBR_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]);
						CONST_CLINIC_NBR_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]);
						CONST_CLINIC_NBR_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]);
						CONST_CLINIC_NBR_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]);
						CONST_CLINIC_NBR_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]);
						CONST_CLINIC_NBR_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]);
						CONST_CLINIC_NBR_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]);
						CONST_CLINIC_NBR_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]);
						CONST_CLINIC_NBR_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]);
						CONST_CLINIC_NBR_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]);
						CONST_CLINIC_NBR_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]);
						CONST_CLINIC_NBR_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]);
						CONST_CLINIC_NBR_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]);
						CONST_CLINIC_NBR_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]);
						CONST_CLINIC_NBR_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]);
						CONST_CLINIC_NBR_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]);
						CONST_CLINIC_NBR_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]);
						CONST_CLINIC_NBR_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]);
						CONST_CLINIC_NBR_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]);
						CONST_CLINIC_NBR_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]);
						CONST_CLINIC_NBR_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]);
						CONST_CLINIC_NBR_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]);
						CONST_CLINIC_NBR_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]);
						CONST_CLINIC_NBR_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]);
						CONST_CLINIC_NBR_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]);
						CONST_CLINIC_NBR_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]);
						CONST_CLINIC_NBR_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]);
						CONST_CLINIC_NBR_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]);
						CONST_CLINIC_NBR_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]);
						CONST_CLINIC_NBR_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]);
						CONST_CLINIC_NBR_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]);
						CONST_CLINIC_NBR_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]);
						CONST_CLINIC_NBR_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]);
						CONST_CLINIC_NBR_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]);
						CONST_CLINIC_NBR1 = Reader["CONST_CLINIC_NBR1"].ToString();
						CONST_CLINIC_NBR2 = Reader["CONST_CLINIC_NBR2"].ToString();
						CONST_CLINIC_NBR3 = Reader["CONST_CLINIC_NBR3"].ToString();
						CONST_CLINIC_NBR4 = Reader["CONST_CLINIC_NBR4"].ToString();
						CONST_CLINIC_NBR5 = Reader["CONST_CLINIC_NBR5"].ToString();
						CONST_CLINIC_NBR6 = Reader["CONST_CLINIC_NBR6"].ToString();
						CONST_CLINIC_NBR7 = Reader["CONST_CLINIC_NBR7"].ToString();
						CONST_CLINIC_NBR8 = Reader["CONST_CLINIC_NBR8"].ToString();
						CONST_CLINIC_NBR9 = Reader["CONST_CLINIC_NBR9"].ToString();
						CONST_CLINIC_NBR10 = Reader["CONST_CLINIC_NBR10"].ToString();
						CONST_CLINIC_NBR11 = Reader["CONST_CLINIC_NBR11"].ToString();
						CONST_CLINIC_NBR12 = Reader["CONST_CLINIC_NBR12"].ToString();
						CONST_CLINIC_NBR13 = Reader["CONST_CLINIC_NBR13"].ToString();
						CONST_CLINIC_NBR14 = Reader["CONST_CLINIC_NBR14"].ToString();
						CONST_CLINIC_NBR15 = Reader["CONST_CLINIC_NBR15"].ToString();
						CONST_CLINIC_NBR16 = Reader["CONST_CLINIC_NBR16"].ToString();
						CONST_CLINIC_NBR17 = Reader["CONST_CLINIC_NBR17"].ToString();
						CONST_CLINIC_NBR18 = Reader["CONST_CLINIC_NBR18"].ToString();
						CONST_CLINIC_NBR19 = Reader["CONST_CLINIC_NBR19"].ToString();
						CONST_CLINIC_NBR20 = Reader["CONST_CLINIC_NBR20"].ToString();
						CONST_CLINIC_NBR21 = Reader["CONST_CLINIC_NBR21"].ToString();
						CONST_CLINIC_NBR22 = Reader["CONST_CLINIC_NBR22"].ToString();
						CONST_CLINIC_NBR23 = Reader["CONST_CLINIC_NBR23"].ToString();
						CONST_CLINIC_NBR24 = Reader["CONST_CLINIC_NBR24"].ToString();
						CONST_CLINIC_NBR25 = Reader["CONST_CLINIC_NBR25"].ToString();
						CONST_CLINIC_NBR26 = Reader["CONST_CLINIC_NBR26"].ToString();
						CONST_CLINIC_NBR27 = Reader["CONST_CLINIC_NBR27"].ToString();
						CONST_CLINIC_NBR28 = Reader["CONST_CLINIC_NBR28"].ToString();
						CONST_CLINIC_NBR29 = Reader["CONST_CLINIC_NBR29"].ToString();
						CONST_CLINIC_NBR30 = Reader["CONST_CLINIC_NBR30"].ToString();
						CONST_CLINIC_NBR31 = Reader["CONST_CLINIC_NBR31"].ToString();
						CONST_CLINIC_NBR32 = Reader["CONST_CLINIC_NBR32"].ToString();
						CONST_CLINIC_NBR33 = Reader["CONST_CLINIC_NBR33"].ToString();
						CONST_CLINIC_NBR34 = Reader["CONST_CLINIC_NBR34"].ToString();
						CONST_CLINIC_NBR35 = Reader["CONST_CLINIC_NBR35"].ToString();
						CONST_CLINIC_NBR36 = Reader["CONST_CLINIC_NBR36"].ToString();
						CONST_CLINIC_NBR37 = Reader["CONST_CLINIC_NBR37"].ToString();
						CONST_CLINIC_NBR38 = Reader["CONST_CLINIC_NBR38"].ToString();
						CONST_CLINIC_NBR39 = Reader["CONST_CLINIC_NBR39"].ToString();
						CONST_CLINIC_NBR40 = Reader["CONST_CLINIC_NBR40"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_max_nbr_clinics = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]);
						_originalConst_clinic_nbr_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]);
						_originalConst_clinic_nbr_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]);
						_originalConst_clinic_nbr_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]);
						_originalConst_clinic_nbr_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]);
						_originalConst_clinic_nbr_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]);
						_originalConst_clinic_nbr_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]);
						_originalConst_clinic_nbr_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]);
						_originalConst_clinic_nbr_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]);
						_originalConst_clinic_nbr_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]);
						_originalConst_clinic_nbr_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]);
						_originalConst_clinic_nbr_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]);
						_originalConst_clinic_nbr_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]);
						_originalConst_clinic_nbr_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]);
						_originalConst_clinic_nbr_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]);
						_originalConst_clinic_nbr_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]);
						_originalConst_clinic_nbr_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]);
						_originalConst_clinic_nbr_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]);
						_originalConst_clinic_nbr_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]);
						_originalConst_clinic_nbr_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]);
						_originalConst_clinic_nbr_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]);
						_originalConst_clinic_nbr_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]);
						_originalConst_clinic_nbr_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]);
						_originalConst_clinic_nbr_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]);
						_originalConst_clinic_nbr_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]);
						_originalConst_clinic_nbr_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]);
						_originalConst_clinic_nbr_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]);
						_originalConst_clinic_nbr_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]);
						_originalConst_clinic_nbr_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]);
						_originalConst_clinic_nbr_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]);
						_originalConst_clinic_nbr_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]);
						_originalConst_clinic_nbr_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]);
						_originalConst_clinic_nbr_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]);
						_originalConst_clinic_nbr_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]);
						_originalConst_clinic_nbr_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]);
						_originalConst_clinic_nbr_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]);
						_originalConst_clinic_nbr_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]);
						_originalConst_clinic_nbr_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]);
						_originalConst_clinic_nbr_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]);
						_originalConst_clinic_nbr_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]);
						_originalConst_clinic_nbr_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]);
						_originalConst_clinic_nbr1 = Reader["CONST_CLINIC_NBR1"].ToString();
						_originalConst_clinic_nbr2 = Reader["CONST_CLINIC_NBR2"].ToString();
						_originalConst_clinic_nbr3 = Reader["CONST_CLINIC_NBR3"].ToString();
						_originalConst_clinic_nbr4 = Reader["CONST_CLINIC_NBR4"].ToString();
						_originalConst_clinic_nbr5 = Reader["CONST_CLINIC_NBR5"].ToString();
						_originalConst_clinic_nbr6 = Reader["CONST_CLINIC_NBR6"].ToString();
						_originalConst_clinic_nbr7 = Reader["CONST_CLINIC_NBR7"].ToString();
						_originalConst_clinic_nbr8 = Reader["CONST_CLINIC_NBR8"].ToString();
						_originalConst_clinic_nbr9 = Reader["CONST_CLINIC_NBR9"].ToString();
						_originalConst_clinic_nbr10 = Reader["CONST_CLINIC_NBR10"].ToString();
						_originalConst_clinic_nbr11 = Reader["CONST_CLINIC_NBR11"].ToString();
						_originalConst_clinic_nbr12 = Reader["CONST_CLINIC_NBR12"].ToString();
						_originalConst_clinic_nbr13 = Reader["CONST_CLINIC_NBR13"].ToString();
						_originalConst_clinic_nbr14 = Reader["CONST_CLINIC_NBR14"].ToString();
						_originalConst_clinic_nbr15 = Reader["CONST_CLINIC_NBR15"].ToString();
						_originalConst_clinic_nbr16 = Reader["CONST_CLINIC_NBR16"].ToString();
						_originalConst_clinic_nbr17 = Reader["CONST_CLINIC_NBR17"].ToString();
						_originalConst_clinic_nbr18 = Reader["CONST_CLINIC_NBR18"].ToString();
						_originalConst_clinic_nbr19 = Reader["CONST_CLINIC_NBR19"].ToString();
						_originalConst_clinic_nbr20 = Reader["CONST_CLINIC_NBR20"].ToString();
						_originalConst_clinic_nbr21 = Reader["CONST_CLINIC_NBR21"].ToString();
						_originalConst_clinic_nbr22 = Reader["CONST_CLINIC_NBR22"].ToString();
						_originalConst_clinic_nbr23 = Reader["CONST_CLINIC_NBR23"].ToString();
						_originalConst_clinic_nbr24 = Reader["CONST_CLINIC_NBR24"].ToString();
						_originalConst_clinic_nbr25 = Reader["CONST_CLINIC_NBR25"].ToString();
						_originalConst_clinic_nbr26 = Reader["CONST_CLINIC_NBR26"].ToString();
						_originalConst_clinic_nbr27 = Reader["CONST_CLINIC_NBR27"].ToString();
						_originalConst_clinic_nbr28 = Reader["CONST_CLINIC_NBR28"].ToString();
						_originalConst_clinic_nbr29 = Reader["CONST_CLINIC_NBR29"].ToString();
						_originalConst_clinic_nbr30 = Reader["CONST_CLINIC_NBR30"].ToString();
						_originalConst_clinic_nbr31 = Reader["CONST_CLINIC_NBR31"].ToString();
						_originalConst_clinic_nbr32 = Reader["CONST_CLINIC_NBR32"].ToString();
						_originalConst_clinic_nbr33 = Reader["CONST_CLINIC_NBR33"].ToString();
						_originalConst_clinic_nbr34 = Reader["CONST_CLINIC_NBR34"].ToString();
						_originalConst_clinic_nbr35 = Reader["CONST_CLINIC_NBR35"].ToString();
						_originalConst_clinic_nbr36 = Reader["CONST_CLINIC_NBR36"].ToString();
						_originalConst_clinic_nbr37 = Reader["CONST_CLINIC_NBR37"].ToString();
						_originalConst_clinic_nbr38 = Reader["CONST_CLINIC_NBR38"].ToString();
						_originalConst_clinic_nbr39 = Reader["CONST_CLINIC_NBR39"].ToString();
						_originalConst_clinic_nbr40 = Reader["CONST_CLINIC_NBR40"].ToString();
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
						new SqlParameter("CONST_MAX_NBR_CLINICS", SqlNull(CONST_MAX_NBR_CLINICS)),
						new SqlParameter("CONST_CLINIC_NBR_1_21", SqlNull(CONST_CLINIC_NBR_1_21)),
						new SqlParameter("CONST_CLINIC_NBR_1_22", SqlNull(CONST_CLINIC_NBR_1_22)),
						new SqlParameter("CONST_CLINIC_NBR_1_23", SqlNull(CONST_CLINIC_NBR_1_23)),
						new SqlParameter("CONST_CLINIC_NBR_1_24", SqlNull(CONST_CLINIC_NBR_1_24)),
						new SqlParameter("CONST_CLINIC_NBR_1_25", SqlNull(CONST_CLINIC_NBR_1_25)),
						new SqlParameter("CONST_CLINIC_NBR_1_26", SqlNull(CONST_CLINIC_NBR_1_26)),
						new SqlParameter("CONST_CLINIC_NBR_1_27", SqlNull(CONST_CLINIC_NBR_1_27)),
						new SqlParameter("CONST_CLINIC_NBR_1_28", SqlNull(CONST_CLINIC_NBR_1_28)),
						new SqlParameter("CONST_CLINIC_NBR_1_29", SqlNull(CONST_CLINIC_NBR_1_29)),
						new SqlParameter("CONST_CLINIC_NBR_1_210", SqlNull(CONST_CLINIC_NBR_1_210)),
						new SqlParameter("CONST_CLINIC_NBR_1_211", SqlNull(CONST_CLINIC_NBR_1_211)),
						new SqlParameter("CONST_CLINIC_NBR_1_212", SqlNull(CONST_CLINIC_NBR_1_212)),
						new SqlParameter("CONST_CLINIC_NBR_1_213", SqlNull(CONST_CLINIC_NBR_1_213)),
						new SqlParameter("CONST_CLINIC_NBR_1_214", SqlNull(CONST_CLINIC_NBR_1_214)),
						new SqlParameter("CONST_CLINIC_NBR_1_215", SqlNull(CONST_CLINIC_NBR_1_215)),
						new SqlParameter("CONST_CLINIC_NBR_1_216", SqlNull(CONST_CLINIC_NBR_1_216)),
						new SqlParameter("CONST_CLINIC_NBR_1_217", SqlNull(CONST_CLINIC_NBR_1_217)),
						new SqlParameter("CONST_CLINIC_NBR_1_218", SqlNull(CONST_CLINIC_NBR_1_218)),
						new SqlParameter("CONST_CLINIC_NBR_1_219", SqlNull(CONST_CLINIC_NBR_1_219)),
						new SqlParameter("CONST_CLINIC_NBR_1_220", SqlNull(CONST_CLINIC_NBR_1_220)),
						new SqlParameter("CONST_CLINIC_NBR_1_221", SqlNull(CONST_CLINIC_NBR_1_221)),
						new SqlParameter("CONST_CLINIC_NBR_1_222", SqlNull(CONST_CLINIC_NBR_1_222)),
						new SqlParameter("CONST_CLINIC_NBR_1_223", SqlNull(CONST_CLINIC_NBR_1_223)),
						new SqlParameter("CONST_CLINIC_NBR_1_224", SqlNull(CONST_CLINIC_NBR_1_224)),
						new SqlParameter("CONST_CLINIC_NBR_1_225", SqlNull(CONST_CLINIC_NBR_1_225)),
						new SqlParameter("CONST_CLINIC_NBR_1_226", SqlNull(CONST_CLINIC_NBR_1_226)),
						new SqlParameter("CONST_CLINIC_NBR_1_227", SqlNull(CONST_CLINIC_NBR_1_227)),
						new SqlParameter("CONST_CLINIC_NBR_1_228", SqlNull(CONST_CLINIC_NBR_1_228)),
						new SqlParameter("CONST_CLINIC_NBR_1_229", SqlNull(CONST_CLINIC_NBR_1_229)),
						new SqlParameter("CONST_CLINIC_NBR_1_230", SqlNull(CONST_CLINIC_NBR_1_230)),
						new SqlParameter("CONST_CLINIC_NBR_1_231", SqlNull(CONST_CLINIC_NBR_1_231)),
						new SqlParameter("CONST_CLINIC_NBR_1_232", SqlNull(CONST_CLINIC_NBR_1_232)),
						new SqlParameter("CONST_CLINIC_NBR_1_233", SqlNull(CONST_CLINIC_NBR_1_233)),
						new SqlParameter("CONST_CLINIC_NBR_1_234", SqlNull(CONST_CLINIC_NBR_1_234)),
						new SqlParameter("CONST_CLINIC_NBR_1_235", SqlNull(CONST_CLINIC_NBR_1_235)),
						new SqlParameter("CONST_CLINIC_NBR_1_236", SqlNull(CONST_CLINIC_NBR_1_236)),
						new SqlParameter("CONST_CLINIC_NBR_1_237", SqlNull(CONST_CLINIC_NBR_1_237)),
						new SqlParameter("CONST_CLINIC_NBR_1_238", SqlNull(CONST_CLINIC_NBR_1_238)),
						new SqlParameter("CONST_CLINIC_NBR_1_239", SqlNull(CONST_CLINIC_NBR_1_239)),
						new SqlParameter("CONST_CLINIC_NBR_1_240", SqlNull(CONST_CLINIC_NBR_1_240)),
						new SqlParameter("CONST_CLINIC_NBR1", SqlNull(CONST_CLINIC_NBR1)),
						new SqlParameter("CONST_CLINIC_NBR2", SqlNull(CONST_CLINIC_NBR2)),
						new SqlParameter("CONST_CLINIC_NBR3", SqlNull(CONST_CLINIC_NBR3)),
						new SqlParameter("CONST_CLINIC_NBR4", SqlNull(CONST_CLINIC_NBR4)),
						new SqlParameter("CONST_CLINIC_NBR5", SqlNull(CONST_CLINIC_NBR5)),
						new SqlParameter("CONST_CLINIC_NBR6", SqlNull(CONST_CLINIC_NBR6)),
						new SqlParameter("CONST_CLINIC_NBR7", SqlNull(CONST_CLINIC_NBR7)),
						new SqlParameter("CONST_CLINIC_NBR8", SqlNull(CONST_CLINIC_NBR8)),
						new SqlParameter("CONST_CLINIC_NBR9", SqlNull(CONST_CLINIC_NBR9)),
						new SqlParameter("CONST_CLINIC_NBR10", SqlNull(CONST_CLINIC_NBR10)),
						new SqlParameter("CONST_CLINIC_NBR11", SqlNull(CONST_CLINIC_NBR11)),
						new SqlParameter("CONST_CLINIC_NBR12", SqlNull(CONST_CLINIC_NBR12)),
						new SqlParameter("CONST_CLINIC_NBR13", SqlNull(CONST_CLINIC_NBR13)),
						new SqlParameter("CONST_CLINIC_NBR14", SqlNull(CONST_CLINIC_NBR14)),
						new SqlParameter("CONST_CLINIC_NBR15", SqlNull(CONST_CLINIC_NBR15)),
						new SqlParameter("CONST_CLINIC_NBR16", SqlNull(CONST_CLINIC_NBR16)),
						new SqlParameter("CONST_CLINIC_NBR17", SqlNull(CONST_CLINIC_NBR17)),
						new SqlParameter("CONST_CLINIC_NBR18", SqlNull(CONST_CLINIC_NBR18)),
						new SqlParameter("CONST_CLINIC_NBR19", SqlNull(CONST_CLINIC_NBR19)),
						new SqlParameter("CONST_CLINIC_NBR20", SqlNull(CONST_CLINIC_NBR20)),
						new SqlParameter("CONST_CLINIC_NBR21", SqlNull(CONST_CLINIC_NBR21)),
						new SqlParameter("CONST_CLINIC_NBR22", SqlNull(CONST_CLINIC_NBR22)),
						new SqlParameter("CONST_CLINIC_NBR23", SqlNull(CONST_CLINIC_NBR23)),
						new SqlParameter("CONST_CLINIC_NBR24", SqlNull(CONST_CLINIC_NBR24)),
						new SqlParameter("CONST_CLINIC_NBR25", SqlNull(CONST_CLINIC_NBR25)),
						new SqlParameter("CONST_CLINIC_NBR26", SqlNull(CONST_CLINIC_NBR26)),
						new SqlParameter("CONST_CLINIC_NBR27", SqlNull(CONST_CLINIC_NBR27)),
						new SqlParameter("CONST_CLINIC_NBR28", SqlNull(CONST_CLINIC_NBR28)),
						new SqlParameter("CONST_CLINIC_NBR29", SqlNull(CONST_CLINIC_NBR29)),
						new SqlParameter("CONST_CLINIC_NBR30", SqlNull(CONST_CLINIC_NBR30)),
						new SqlParameter("CONST_CLINIC_NBR31", SqlNull(CONST_CLINIC_NBR31)),
						new SqlParameter("CONST_CLINIC_NBR32", SqlNull(CONST_CLINIC_NBR32)),
						new SqlParameter("CONST_CLINIC_NBR33", SqlNull(CONST_CLINIC_NBR33)),
						new SqlParameter("CONST_CLINIC_NBR34", SqlNull(CONST_CLINIC_NBR34)),
						new SqlParameter("CONST_CLINIC_NBR35", SqlNull(CONST_CLINIC_NBR35)),
						new SqlParameter("CONST_CLINIC_NBR36", SqlNull(CONST_CLINIC_NBR36)),
						new SqlParameter("CONST_CLINIC_NBR37", SqlNull(CONST_CLINIC_NBR37)),
						new SqlParameter("CONST_CLINIC_NBR38", SqlNull(CONST_CLINIC_NBR38)),
						new SqlParameter("CONST_CLINIC_NBR39", SqlNull(CONST_CLINIC_NBR39)),
						new SqlParameter("CONST_CLINIC_NBR40", SqlNull(CONST_CLINIC_NBR40)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_1_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_MAX_NBR_CLINICS = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]);
						CONST_CLINIC_NBR_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]);
						CONST_CLINIC_NBR_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]);
						CONST_CLINIC_NBR_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]);
						CONST_CLINIC_NBR_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]);
						CONST_CLINIC_NBR_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]);
						CONST_CLINIC_NBR_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]);
						CONST_CLINIC_NBR_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]);
						CONST_CLINIC_NBR_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]);
						CONST_CLINIC_NBR_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]);
						CONST_CLINIC_NBR_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]);
						CONST_CLINIC_NBR_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]);
						CONST_CLINIC_NBR_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]);
						CONST_CLINIC_NBR_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]);
						CONST_CLINIC_NBR_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]);
						CONST_CLINIC_NBR_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]);
						CONST_CLINIC_NBR_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]);
						CONST_CLINIC_NBR_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]);
						CONST_CLINIC_NBR_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]);
						CONST_CLINIC_NBR_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]);
						CONST_CLINIC_NBR_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]);
						CONST_CLINIC_NBR_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]);
						CONST_CLINIC_NBR_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]);
						CONST_CLINIC_NBR_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]);
						CONST_CLINIC_NBR_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]);
						CONST_CLINIC_NBR_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]);
						CONST_CLINIC_NBR_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]);
						CONST_CLINIC_NBR_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]);
						CONST_CLINIC_NBR_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]);
						CONST_CLINIC_NBR_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]);
						CONST_CLINIC_NBR_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]);
						CONST_CLINIC_NBR_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]);
						CONST_CLINIC_NBR_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]);
						CONST_CLINIC_NBR_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]);
						CONST_CLINIC_NBR_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]);
						CONST_CLINIC_NBR_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]);
						CONST_CLINIC_NBR_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]);
						CONST_CLINIC_NBR_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]);
						CONST_CLINIC_NBR_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]);
						CONST_CLINIC_NBR_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]);
						CONST_CLINIC_NBR_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]);
						CONST_CLINIC_NBR1 = Reader["CONST_CLINIC_NBR1"].ToString();
						CONST_CLINIC_NBR2 = Reader["CONST_CLINIC_NBR2"].ToString();
						CONST_CLINIC_NBR3 = Reader["CONST_CLINIC_NBR3"].ToString();
						CONST_CLINIC_NBR4 = Reader["CONST_CLINIC_NBR4"].ToString();
						CONST_CLINIC_NBR5 = Reader["CONST_CLINIC_NBR5"].ToString();
						CONST_CLINIC_NBR6 = Reader["CONST_CLINIC_NBR6"].ToString();
						CONST_CLINIC_NBR7 = Reader["CONST_CLINIC_NBR7"].ToString();
						CONST_CLINIC_NBR8 = Reader["CONST_CLINIC_NBR8"].ToString();
						CONST_CLINIC_NBR9 = Reader["CONST_CLINIC_NBR9"].ToString();
						CONST_CLINIC_NBR10 = Reader["CONST_CLINIC_NBR10"].ToString();
						CONST_CLINIC_NBR11 = Reader["CONST_CLINIC_NBR11"].ToString();
						CONST_CLINIC_NBR12 = Reader["CONST_CLINIC_NBR12"].ToString();
						CONST_CLINIC_NBR13 = Reader["CONST_CLINIC_NBR13"].ToString();
						CONST_CLINIC_NBR14 = Reader["CONST_CLINIC_NBR14"].ToString();
						CONST_CLINIC_NBR15 = Reader["CONST_CLINIC_NBR15"].ToString();
						CONST_CLINIC_NBR16 = Reader["CONST_CLINIC_NBR16"].ToString();
						CONST_CLINIC_NBR17 = Reader["CONST_CLINIC_NBR17"].ToString();
						CONST_CLINIC_NBR18 = Reader["CONST_CLINIC_NBR18"].ToString();
						CONST_CLINIC_NBR19 = Reader["CONST_CLINIC_NBR19"].ToString();
						CONST_CLINIC_NBR20 = Reader["CONST_CLINIC_NBR20"].ToString();
						CONST_CLINIC_NBR21 = Reader["CONST_CLINIC_NBR21"].ToString();
						CONST_CLINIC_NBR22 = Reader["CONST_CLINIC_NBR22"].ToString();
						CONST_CLINIC_NBR23 = Reader["CONST_CLINIC_NBR23"].ToString();
						CONST_CLINIC_NBR24 = Reader["CONST_CLINIC_NBR24"].ToString();
						CONST_CLINIC_NBR25 = Reader["CONST_CLINIC_NBR25"].ToString();
						CONST_CLINIC_NBR26 = Reader["CONST_CLINIC_NBR26"].ToString();
						CONST_CLINIC_NBR27 = Reader["CONST_CLINIC_NBR27"].ToString();
						CONST_CLINIC_NBR28 = Reader["CONST_CLINIC_NBR28"].ToString();
						CONST_CLINIC_NBR29 = Reader["CONST_CLINIC_NBR29"].ToString();
						CONST_CLINIC_NBR30 = Reader["CONST_CLINIC_NBR30"].ToString();
						CONST_CLINIC_NBR31 = Reader["CONST_CLINIC_NBR31"].ToString();
						CONST_CLINIC_NBR32 = Reader["CONST_CLINIC_NBR32"].ToString();
						CONST_CLINIC_NBR33 = Reader["CONST_CLINIC_NBR33"].ToString();
						CONST_CLINIC_NBR34 = Reader["CONST_CLINIC_NBR34"].ToString();
						CONST_CLINIC_NBR35 = Reader["CONST_CLINIC_NBR35"].ToString();
						CONST_CLINIC_NBR36 = Reader["CONST_CLINIC_NBR36"].ToString();
						CONST_CLINIC_NBR37 = Reader["CONST_CLINIC_NBR37"].ToString();
						CONST_CLINIC_NBR38 = Reader["CONST_CLINIC_NBR38"].ToString();
						CONST_CLINIC_NBR39 = Reader["CONST_CLINIC_NBR39"].ToString();
						CONST_CLINIC_NBR40 = Reader["CONST_CLINIC_NBR40"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_max_nbr_clinics = ConvertDEC(Reader["CONST_MAX_NBR_CLINICS"]);
						_originalConst_clinic_nbr_1_21 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_21"]);
						_originalConst_clinic_nbr_1_22 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_22"]);
						_originalConst_clinic_nbr_1_23 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_23"]);
						_originalConst_clinic_nbr_1_24 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_24"]);
						_originalConst_clinic_nbr_1_25 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_25"]);
						_originalConst_clinic_nbr_1_26 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_26"]);
						_originalConst_clinic_nbr_1_27 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_27"]);
						_originalConst_clinic_nbr_1_28 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_28"]);
						_originalConst_clinic_nbr_1_29 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_29"]);
						_originalConst_clinic_nbr_1_210 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_210"]);
						_originalConst_clinic_nbr_1_211 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_211"]);
						_originalConst_clinic_nbr_1_212 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_212"]);
						_originalConst_clinic_nbr_1_213 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_213"]);
						_originalConst_clinic_nbr_1_214 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_214"]);
						_originalConst_clinic_nbr_1_215 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_215"]);
						_originalConst_clinic_nbr_1_216 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_216"]);
						_originalConst_clinic_nbr_1_217 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_217"]);
						_originalConst_clinic_nbr_1_218 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_218"]);
						_originalConst_clinic_nbr_1_219 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_219"]);
						_originalConst_clinic_nbr_1_220 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_220"]);
						_originalConst_clinic_nbr_1_221 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_221"]);
						_originalConst_clinic_nbr_1_222 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_222"]);
						_originalConst_clinic_nbr_1_223 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_223"]);
						_originalConst_clinic_nbr_1_224 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_224"]);
						_originalConst_clinic_nbr_1_225 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_225"]);
						_originalConst_clinic_nbr_1_226 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_226"]);
						_originalConst_clinic_nbr_1_227 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_227"]);
						_originalConst_clinic_nbr_1_228 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_228"]);
						_originalConst_clinic_nbr_1_229 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_229"]);
						_originalConst_clinic_nbr_1_230 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_230"]);
						_originalConst_clinic_nbr_1_231 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_231"]);
						_originalConst_clinic_nbr_1_232 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_232"]);
						_originalConst_clinic_nbr_1_233 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_233"]);
						_originalConst_clinic_nbr_1_234 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_234"]);
						_originalConst_clinic_nbr_1_235 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_235"]);
						_originalConst_clinic_nbr_1_236 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_236"]);
						_originalConst_clinic_nbr_1_237 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_237"]);
						_originalConst_clinic_nbr_1_238 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_238"]);
						_originalConst_clinic_nbr_1_239 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_239"]);
						_originalConst_clinic_nbr_1_240 = ConvertDEC(Reader["CONST_CLINIC_NBR_1_240"]);
						_originalConst_clinic_nbr1 = Reader["CONST_CLINIC_NBR1"].ToString();
						_originalConst_clinic_nbr2 = Reader["CONST_CLINIC_NBR2"].ToString();
						_originalConst_clinic_nbr3 = Reader["CONST_CLINIC_NBR3"].ToString();
						_originalConst_clinic_nbr4 = Reader["CONST_CLINIC_NBR4"].ToString();
						_originalConst_clinic_nbr5 = Reader["CONST_CLINIC_NBR5"].ToString();
						_originalConst_clinic_nbr6 = Reader["CONST_CLINIC_NBR6"].ToString();
						_originalConst_clinic_nbr7 = Reader["CONST_CLINIC_NBR7"].ToString();
						_originalConst_clinic_nbr8 = Reader["CONST_CLINIC_NBR8"].ToString();
						_originalConst_clinic_nbr9 = Reader["CONST_CLINIC_NBR9"].ToString();
						_originalConst_clinic_nbr10 = Reader["CONST_CLINIC_NBR10"].ToString();
						_originalConst_clinic_nbr11 = Reader["CONST_CLINIC_NBR11"].ToString();
						_originalConst_clinic_nbr12 = Reader["CONST_CLINIC_NBR12"].ToString();
						_originalConst_clinic_nbr13 = Reader["CONST_CLINIC_NBR13"].ToString();
						_originalConst_clinic_nbr14 = Reader["CONST_CLINIC_NBR14"].ToString();
						_originalConst_clinic_nbr15 = Reader["CONST_CLINIC_NBR15"].ToString();
						_originalConst_clinic_nbr16 = Reader["CONST_CLINIC_NBR16"].ToString();
						_originalConst_clinic_nbr17 = Reader["CONST_CLINIC_NBR17"].ToString();
						_originalConst_clinic_nbr18 = Reader["CONST_CLINIC_NBR18"].ToString();
						_originalConst_clinic_nbr19 = Reader["CONST_CLINIC_NBR19"].ToString();
						_originalConst_clinic_nbr20 = Reader["CONST_CLINIC_NBR20"].ToString();
						_originalConst_clinic_nbr21 = Reader["CONST_CLINIC_NBR21"].ToString();
						_originalConst_clinic_nbr22 = Reader["CONST_CLINIC_NBR22"].ToString();
						_originalConst_clinic_nbr23 = Reader["CONST_CLINIC_NBR23"].ToString();
						_originalConst_clinic_nbr24 = Reader["CONST_CLINIC_NBR24"].ToString();
						_originalConst_clinic_nbr25 = Reader["CONST_CLINIC_NBR25"].ToString();
						_originalConst_clinic_nbr26 = Reader["CONST_CLINIC_NBR26"].ToString();
						_originalConst_clinic_nbr27 = Reader["CONST_CLINIC_NBR27"].ToString();
						_originalConst_clinic_nbr28 = Reader["CONST_CLINIC_NBR28"].ToString();
						_originalConst_clinic_nbr29 = Reader["CONST_CLINIC_NBR29"].ToString();
						_originalConst_clinic_nbr30 = Reader["CONST_CLINIC_NBR30"].ToString();
						_originalConst_clinic_nbr31 = Reader["CONST_CLINIC_NBR31"].ToString();
						_originalConst_clinic_nbr32 = Reader["CONST_CLINIC_NBR32"].ToString();
						_originalConst_clinic_nbr33 = Reader["CONST_CLINIC_NBR33"].ToString();
						_originalConst_clinic_nbr34 = Reader["CONST_CLINIC_NBR34"].ToString();
						_originalConst_clinic_nbr35 = Reader["CONST_CLINIC_NBR35"].ToString();
						_originalConst_clinic_nbr36 = Reader["CONST_CLINIC_NBR36"].ToString();
						_originalConst_clinic_nbr37 = Reader["CONST_CLINIC_NBR37"].ToString();
						_originalConst_clinic_nbr38 = Reader["CONST_CLINIC_NBR38"].ToString();
						_originalConst_clinic_nbr39 = Reader["CONST_CLINIC_NBR39"].ToString();
						_originalConst_clinic_nbr40 = Reader["CONST_CLINIC_NBR40"].ToString();
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