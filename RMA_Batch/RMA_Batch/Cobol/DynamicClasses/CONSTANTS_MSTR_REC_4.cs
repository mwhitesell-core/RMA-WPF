using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_4 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_4> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_nbr_classesmin,
															decimal? const_nbr_classesmax,
															string const_class_ltr1,
															string const_class_ltr2,
															string const_class_ltr3,
															string const_class_ltr4,
															string const_class_ltr5,
															string const_class_ltr6,
															string const_class_ltr7,
															string const_class_ltr8,
															string const_class_ltr9,
															string const_class_ltr10,
															string const_class_ltr11,
															string const_class_ltr12,
															string const_class_ltr13,
															string const_class_ltr14,
															string const_class_ltr15,
															string const_class_desc1,
															string const_class_desc2,
															string const_class_desc3,
															string const_class_desc4,
															string const_class_desc5,
															string const_class_desc6,
															string const_class_desc7,
															string const_class_desc8,
															string const_class_desc9,
															string const_class_desc10,
															string const_class_desc11,
															string const_class_desc12,
															string const_class_desc13,
															string const_class_desc14,
															string const_class_desc15,
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
					new SqlParameter("minCONST_NBR_CLASSES",const_nbr_classesmin),
					new SqlParameter("maxCONST_NBR_CLASSES",const_nbr_classesmax),
					new SqlParameter("CONST_CLASS_LTR1",const_class_ltr1),
					new SqlParameter("CONST_CLASS_LTR2",const_class_ltr2),
					new SqlParameter("CONST_CLASS_LTR3",const_class_ltr3),
					new SqlParameter("CONST_CLASS_LTR4",const_class_ltr4),
					new SqlParameter("CONST_CLASS_LTR5",const_class_ltr5),
					new SqlParameter("CONST_CLASS_LTR6",const_class_ltr6),
					new SqlParameter("CONST_CLASS_LTR7",const_class_ltr7),
					new SqlParameter("CONST_CLASS_LTR8",const_class_ltr8),
					new SqlParameter("CONST_CLASS_LTR9",const_class_ltr9),
					new SqlParameter("CONST_CLASS_LTR10",const_class_ltr10),
					new SqlParameter("CONST_CLASS_LTR11",const_class_ltr11),
					new SqlParameter("CONST_CLASS_LTR12",const_class_ltr12),
					new SqlParameter("CONST_CLASS_LTR13",const_class_ltr13),
					new SqlParameter("CONST_CLASS_LTR14",const_class_ltr14),
					new SqlParameter("CONST_CLASS_LTR15",const_class_ltr15),
					new SqlParameter("CONST_CLASS_DESC1",const_class_desc1),
					new SqlParameter("CONST_CLASS_DESC2",const_class_desc2),
					new SqlParameter("CONST_CLASS_DESC3",const_class_desc3),
					new SqlParameter("CONST_CLASS_DESC4",const_class_desc4),
					new SqlParameter("CONST_CLASS_DESC5",const_class_desc5),
					new SqlParameter("CONST_CLASS_DESC6",const_class_desc6),
					new SqlParameter("CONST_CLASS_DESC7",const_class_desc7),
					new SqlParameter("CONST_CLASS_DESC8",const_class_desc8),
					new SqlParameter("CONST_CLASS_DESC9",const_class_desc9),
					new SqlParameter("CONST_CLASS_DESC10",const_class_desc10),
					new SqlParameter("CONST_CLASS_DESC11",const_class_desc11),
					new SqlParameter("CONST_CLASS_DESC12",const_class_desc12),
					new SqlParameter("CONST_CLASS_DESC13",const_class_desc13),
					new SqlParameter("CONST_CLASS_DESC14",const_class_desc14),
					new SqlParameter("CONST_CLASS_DESC15",const_class_desc15),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_4>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_4>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_4
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_NBR_CLASSES = ConvertDEC(Reader["CONST_NBR_CLASSES"]),
					CONST_CLASS_LTR1 = Reader["CONST_CLASS_LTR1"].ToString(),
					CONST_CLASS_LTR2 = Reader["CONST_CLASS_LTR2"].ToString(),
					CONST_CLASS_LTR3 = Reader["CONST_CLASS_LTR3"].ToString(),
					CONST_CLASS_LTR4 = Reader["CONST_CLASS_LTR4"].ToString(),
					CONST_CLASS_LTR5 = Reader["CONST_CLASS_LTR5"].ToString(),
					CONST_CLASS_LTR6 = Reader["CONST_CLASS_LTR6"].ToString(),
					CONST_CLASS_LTR7 = Reader["CONST_CLASS_LTR7"].ToString(),
					CONST_CLASS_LTR8 = Reader["CONST_CLASS_LTR8"].ToString(),
					CONST_CLASS_LTR9 = Reader["CONST_CLASS_LTR9"].ToString(),
					CONST_CLASS_LTR10 = Reader["CONST_CLASS_LTR10"].ToString(),
					CONST_CLASS_LTR11 = Reader["CONST_CLASS_LTR11"].ToString(),
					CONST_CLASS_LTR12 = Reader["CONST_CLASS_LTR12"].ToString(),
					CONST_CLASS_LTR13 = Reader["CONST_CLASS_LTR13"].ToString(),
					CONST_CLASS_LTR14 = Reader["CONST_CLASS_LTR14"].ToString(),
					CONST_CLASS_LTR15 = Reader["CONST_CLASS_LTR15"].ToString(),
					CONST_CLASS_DESC1 = Reader["CONST_CLASS_DESC1"].ToString(),
					CONST_CLASS_DESC2 = Reader["CONST_CLASS_DESC2"].ToString(),
					CONST_CLASS_DESC3 = Reader["CONST_CLASS_DESC3"].ToString(),
					CONST_CLASS_DESC4 = Reader["CONST_CLASS_DESC4"].ToString(),
					CONST_CLASS_DESC5 = Reader["CONST_CLASS_DESC5"].ToString(),
					CONST_CLASS_DESC6 = Reader["CONST_CLASS_DESC6"].ToString(),
					CONST_CLASS_DESC7 = Reader["CONST_CLASS_DESC7"].ToString(),
					CONST_CLASS_DESC8 = Reader["CONST_CLASS_DESC8"].ToString(),
					CONST_CLASS_DESC9 = Reader["CONST_CLASS_DESC9"].ToString(),
					CONST_CLASS_DESC10 = Reader["CONST_CLASS_DESC10"].ToString(),
					CONST_CLASS_DESC11 = Reader["CONST_CLASS_DESC11"].ToString(),
					CONST_CLASS_DESC12 = Reader["CONST_CLASS_DESC12"].ToString(),
					CONST_CLASS_DESC13 = Reader["CONST_CLASS_DESC13"].ToString(),
					CONST_CLASS_DESC14 = Reader["CONST_CLASS_DESC14"].ToString(),
					CONST_CLASS_DESC15 = Reader["CONST_CLASS_DESC15"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_nbr_classes = ConvertDEC(Reader["CONST_NBR_CLASSES"]),
					_originalConst_class_ltr1 = Reader["CONST_CLASS_LTR1"].ToString(),
					_originalConst_class_ltr2 = Reader["CONST_CLASS_LTR2"].ToString(),
					_originalConst_class_ltr3 = Reader["CONST_CLASS_LTR3"].ToString(),
					_originalConst_class_ltr4 = Reader["CONST_CLASS_LTR4"].ToString(),
					_originalConst_class_ltr5 = Reader["CONST_CLASS_LTR5"].ToString(),
					_originalConst_class_ltr6 = Reader["CONST_CLASS_LTR6"].ToString(),
					_originalConst_class_ltr7 = Reader["CONST_CLASS_LTR7"].ToString(),
					_originalConst_class_ltr8 = Reader["CONST_CLASS_LTR8"].ToString(),
					_originalConst_class_ltr9 = Reader["CONST_CLASS_LTR9"].ToString(),
					_originalConst_class_ltr10 = Reader["CONST_CLASS_LTR10"].ToString(),
					_originalConst_class_ltr11 = Reader["CONST_CLASS_LTR11"].ToString(),
					_originalConst_class_ltr12 = Reader["CONST_CLASS_LTR12"].ToString(),
					_originalConst_class_ltr13 = Reader["CONST_CLASS_LTR13"].ToString(),
					_originalConst_class_ltr14 = Reader["CONST_CLASS_LTR14"].ToString(),
					_originalConst_class_ltr15 = Reader["CONST_CLASS_LTR15"].ToString(),
					_originalConst_class_desc1 = Reader["CONST_CLASS_DESC1"].ToString(),
					_originalConst_class_desc2 = Reader["CONST_CLASS_DESC2"].ToString(),
					_originalConst_class_desc3 = Reader["CONST_CLASS_DESC3"].ToString(),
					_originalConst_class_desc4 = Reader["CONST_CLASS_DESC4"].ToString(),
					_originalConst_class_desc5 = Reader["CONST_CLASS_DESC5"].ToString(),
					_originalConst_class_desc6 = Reader["CONST_CLASS_DESC6"].ToString(),
					_originalConst_class_desc7 = Reader["CONST_CLASS_DESC7"].ToString(),
					_originalConst_class_desc8 = Reader["CONST_CLASS_DESC8"].ToString(),
					_originalConst_class_desc9 = Reader["CONST_CLASS_DESC9"].ToString(),
					_originalConst_class_desc10 = Reader["CONST_CLASS_DESC10"].ToString(),
					_originalConst_class_desc11 = Reader["CONST_CLASS_DESC11"].ToString(),
					_originalConst_class_desc12 = Reader["CONST_CLASS_DESC12"].ToString(),
					_originalConst_class_desc13 = Reader["CONST_CLASS_DESC13"].ToString(),
					_originalConst_class_desc14 = Reader["CONST_CLASS_DESC14"].ToString(),
					_originalConst_class_desc15 = Reader["CONST_CLASS_DESC15"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_4 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_4> Collection(ObservableCollection<CONSTANTS_MSTR_REC_4>
                                                               constantsMstrRec4 = null)
        {
            if (IsSameSearch() && constantsMstrRec4 != null)
            {
                return constantsMstrRec4;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_4>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_NBR_CLASSES",WhereConst_nbr_classes),
					new SqlParameter("CONST_CLASS_LTR1",WhereConst_class_ltr1),
					new SqlParameter("CONST_CLASS_LTR2",WhereConst_class_ltr2),
					new SqlParameter("CONST_CLASS_LTR3",WhereConst_class_ltr3),
					new SqlParameter("CONST_CLASS_LTR4",WhereConst_class_ltr4),
					new SqlParameter("CONST_CLASS_LTR5",WhereConst_class_ltr5),
					new SqlParameter("CONST_CLASS_LTR6",WhereConst_class_ltr6),
					new SqlParameter("CONST_CLASS_LTR7",WhereConst_class_ltr7),
					new SqlParameter("CONST_CLASS_LTR8",WhereConst_class_ltr8),
					new SqlParameter("CONST_CLASS_LTR9",WhereConst_class_ltr9),
					new SqlParameter("CONST_CLASS_LTR10",WhereConst_class_ltr10),
					new SqlParameter("CONST_CLASS_LTR11",WhereConst_class_ltr11),
					new SqlParameter("CONST_CLASS_LTR12",WhereConst_class_ltr12),
					new SqlParameter("CONST_CLASS_LTR13",WhereConst_class_ltr13),
					new SqlParameter("CONST_CLASS_LTR14",WhereConst_class_ltr14),
					new SqlParameter("CONST_CLASS_LTR15",WhereConst_class_ltr15),
					new SqlParameter("CONST_CLASS_DESC1",WhereConst_class_desc1),
					new SqlParameter("CONST_CLASS_DESC2",WhereConst_class_desc2),
					new SqlParameter("CONST_CLASS_DESC3",WhereConst_class_desc3),
					new SqlParameter("CONST_CLASS_DESC4",WhereConst_class_desc4),
					new SqlParameter("CONST_CLASS_DESC5",WhereConst_class_desc5),
					new SqlParameter("CONST_CLASS_DESC6",WhereConst_class_desc6),
					new SqlParameter("CONST_CLASS_DESC7",WhereConst_class_desc7),
					new SqlParameter("CONST_CLASS_DESC8",WhereConst_class_desc8),
					new SqlParameter("CONST_CLASS_DESC9",WhereConst_class_desc9),
					new SqlParameter("CONST_CLASS_DESC10",WhereConst_class_desc10),
					new SqlParameter("CONST_CLASS_DESC11",WhereConst_class_desc11),
					new SqlParameter("CONST_CLASS_DESC12",WhereConst_class_desc12),
					new SqlParameter("CONST_CLASS_DESC13",WhereConst_class_desc13),
					new SqlParameter("CONST_CLASS_DESC14",WhereConst_class_desc14),
					new SqlParameter("CONST_CLASS_DESC15",WhereConst_class_desc15),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_4>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_4
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_NBR_CLASSES = ConvertDEC(Reader["CONST_NBR_CLASSES"]),
					CONST_CLASS_LTR1 = Reader["CONST_CLASS_LTR1"].ToString(),
					CONST_CLASS_LTR2 = Reader["CONST_CLASS_LTR2"].ToString(),
					CONST_CLASS_LTR3 = Reader["CONST_CLASS_LTR3"].ToString(),
					CONST_CLASS_LTR4 = Reader["CONST_CLASS_LTR4"].ToString(),
					CONST_CLASS_LTR5 = Reader["CONST_CLASS_LTR5"].ToString(),
					CONST_CLASS_LTR6 = Reader["CONST_CLASS_LTR6"].ToString(),
					CONST_CLASS_LTR7 = Reader["CONST_CLASS_LTR7"].ToString(),
					CONST_CLASS_LTR8 = Reader["CONST_CLASS_LTR8"].ToString(),
					CONST_CLASS_LTR9 = Reader["CONST_CLASS_LTR9"].ToString(),
					CONST_CLASS_LTR10 = Reader["CONST_CLASS_LTR10"].ToString(),
					CONST_CLASS_LTR11 = Reader["CONST_CLASS_LTR11"].ToString(),
					CONST_CLASS_LTR12 = Reader["CONST_CLASS_LTR12"].ToString(),
					CONST_CLASS_LTR13 = Reader["CONST_CLASS_LTR13"].ToString(),
					CONST_CLASS_LTR14 = Reader["CONST_CLASS_LTR14"].ToString(),
					CONST_CLASS_LTR15 = Reader["CONST_CLASS_LTR15"].ToString(),
					CONST_CLASS_DESC1 = Reader["CONST_CLASS_DESC1"].ToString(),
					CONST_CLASS_DESC2 = Reader["CONST_CLASS_DESC2"].ToString(),
					CONST_CLASS_DESC3 = Reader["CONST_CLASS_DESC3"].ToString(),
					CONST_CLASS_DESC4 = Reader["CONST_CLASS_DESC4"].ToString(),
					CONST_CLASS_DESC5 = Reader["CONST_CLASS_DESC5"].ToString(),
					CONST_CLASS_DESC6 = Reader["CONST_CLASS_DESC6"].ToString(),
					CONST_CLASS_DESC7 = Reader["CONST_CLASS_DESC7"].ToString(),
					CONST_CLASS_DESC8 = Reader["CONST_CLASS_DESC8"].ToString(),
					CONST_CLASS_DESC9 = Reader["CONST_CLASS_DESC9"].ToString(),
					CONST_CLASS_DESC10 = Reader["CONST_CLASS_DESC10"].ToString(),
					CONST_CLASS_DESC11 = Reader["CONST_CLASS_DESC11"].ToString(),
					CONST_CLASS_DESC12 = Reader["CONST_CLASS_DESC12"].ToString(),
					CONST_CLASS_DESC13 = Reader["CONST_CLASS_DESC13"].ToString(),
					CONST_CLASS_DESC14 = Reader["CONST_CLASS_DESC14"].ToString(),
					CONST_CLASS_DESC15 = Reader["CONST_CLASS_DESC15"].ToString(),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_nbr_classes = WhereConst_nbr_classes,
					_whereConst_class_ltr1 = WhereConst_class_ltr1,
					_whereConst_class_ltr2 = WhereConst_class_ltr2,
					_whereConst_class_ltr3 = WhereConst_class_ltr3,
					_whereConst_class_ltr4 = WhereConst_class_ltr4,
					_whereConst_class_ltr5 = WhereConst_class_ltr5,
					_whereConst_class_ltr6 = WhereConst_class_ltr6,
					_whereConst_class_ltr7 = WhereConst_class_ltr7,
					_whereConst_class_ltr8 = WhereConst_class_ltr8,
					_whereConst_class_ltr9 = WhereConst_class_ltr9,
					_whereConst_class_ltr10 = WhereConst_class_ltr10,
					_whereConst_class_ltr11 = WhereConst_class_ltr11,
					_whereConst_class_ltr12 = WhereConst_class_ltr12,
					_whereConst_class_ltr13 = WhereConst_class_ltr13,
					_whereConst_class_ltr14 = WhereConst_class_ltr14,
					_whereConst_class_ltr15 = WhereConst_class_ltr15,
					_whereConst_class_desc1 = WhereConst_class_desc1,
					_whereConst_class_desc2 = WhereConst_class_desc2,
					_whereConst_class_desc3 = WhereConst_class_desc3,
					_whereConst_class_desc4 = WhereConst_class_desc4,
					_whereConst_class_desc5 = WhereConst_class_desc5,
					_whereConst_class_desc6 = WhereConst_class_desc6,
					_whereConst_class_desc7 = WhereConst_class_desc7,
					_whereConst_class_desc8 = WhereConst_class_desc8,
					_whereConst_class_desc9 = WhereConst_class_desc9,
					_whereConst_class_desc10 = WhereConst_class_desc10,
					_whereConst_class_desc11 = WhereConst_class_desc11,
					_whereConst_class_desc12 = WhereConst_class_desc12,
					_whereConst_class_desc13 = WhereConst_class_desc13,
					_whereConst_class_desc14 = WhereConst_class_desc14,
					_whereConst_class_desc15 = WhereConst_class_desc15,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_nbr_classes = ConvertDEC(Reader["CONST_NBR_CLASSES"]),
					_originalConst_class_ltr1 = Reader["CONST_CLASS_LTR1"].ToString(),
					_originalConst_class_ltr2 = Reader["CONST_CLASS_LTR2"].ToString(),
					_originalConst_class_ltr3 = Reader["CONST_CLASS_LTR3"].ToString(),
					_originalConst_class_ltr4 = Reader["CONST_CLASS_LTR4"].ToString(),
					_originalConst_class_ltr5 = Reader["CONST_CLASS_LTR5"].ToString(),
					_originalConst_class_ltr6 = Reader["CONST_CLASS_LTR6"].ToString(),
					_originalConst_class_ltr7 = Reader["CONST_CLASS_LTR7"].ToString(),
					_originalConst_class_ltr8 = Reader["CONST_CLASS_LTR8"].ToString(),
					_originalConst_class_ltr9 = Reader["CONST_CLASS_LTR9"].ToString(),
					_originalConst_class_ltr10 = Reader["CONST_CLASS_LTR10"].ToString(),
					_originalConst_class_ltr11 = Reader["CONST_CLASS_LTR11"].ToString(),
					_originalConst_class_ltr12 = Reader["CONST_CLASS_LTR12"].ToString(),
					_originalConst_class_ltr13 = Reader["CONST_CLASS_LTR13"].ToString(),
					_originalConst_class_ltr14 = Reader["CONST_CLASS_LTR14"].ToString(),
					_originalConst_class_ltr15 = Reader["CONST_CLASS_LTR15"].ToString(),
					_originalConst_class_desc1 = Reader["CONST_CLASS_DESC1"].ToString(),
					_originalConst_class_desc2 = Reader["CONST_CLASS_DESC2"].ToString(),
					_originalConst_class_desc3 = Reader["CONST_CLASS_DESC3"].ToString(),
					_originalConst_class_desc4 = Reader["CONST_CLASS_DESC4"].ToString(),
					_originalConst_class_desc5 = Reader["CONST_CLASS_DESC5"].ToString(),
					_originalConst_class_desc6 = Reader["CONST_CLASS_DESC6"].ToString(),
					_originalConst_class_desc7 = Reader["CONST_CLASS_DESC7"].ToString(),
					_originalConst_class_desc8 = Reader["CONST_CLASS_DESC8"].ToString(),
					_originalConst_class_desc9 = Reader["CONST_CLASS_DESC9"].ToString(),
					_originalConst_class_desc10 = Reader["CONST_CLASS_DESC10"].ToString(),
					_originalConst_class_desc11 = Reader["CONST_CLASS_DESC11"].ToString(),
					_originalConst_class_desc12 = Reader["CONST_CLASS_DESC12"].ToString(),
					_originalConst_class_desc13 = Reader["CONST_CLASS_DESC13"].ToString(),
					_originalConst_class_desc14 = Reader["CONST_CLASS_DESC14"].ToString(),
					_originalConst_class_desc15 = Reader["CONST_CLASS_DESC15"].ToString(),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_nbr_classes = WhereConst_nbr_classes;
					_whereConst_class_ltr1 = WhereConst_class_ltr1;
					_whereConst_class_ltr2 = WhereConst_class_ltr2;
					_whereConst_class_ltr3 = WhereConst_class_ltr3;
					_whereConst_class_ltr4 = WhereConst_class_ltr4;
					_whereConst_class_ltr5 = WhereConst_class_ltr5;
					_whereConst_class_ltr6 = WhereConst_class_ltr6;
					_whereConst_class_ltr7 = WhereConst_class_ltr7;
					_whereConst_class_ltr8 = WhereConst_class_ltr8;
					_whereConst_class_ltr9 = WhereConst_class_ltr9;
					_whereConst_class_ltr10 = WhereConst_class_ltr10;
					_whereConst_class_ltr11 = WhereConst_class_ltr11;
					_whereConst_class_ltr12 = WhereConst_class_ltr12;
					_whereConst_class_ltr13 = WhereConst_class_ltr13;
					_whereConst_class_ltr14 = WhereConst_class_ltr14;
					_whereConst_class_ltr15 = WhereConst_class_ltr15;
					_whereConst_class_desc1 = WhereConst_class_desc1;
					_whereConst_class_desc2 = WhereConst_class_desc2;
					_whereConst_class_desc3 = WhereConst_class_desc3;
					_whereConst_class_desc4 = WhereConst_class_desc4;
					_whereConst_class_desc5 = WhereConst_class_desc5;
					_whereConst_class_desc6 = WhereConst_class_desc6;
					_whereConst_class_desc7 = WhereConst_class_desc7;
					_whereConst_class_desc8 = WhereConst_class_desc8;
					_whereConst_class_desc9 = WhereConst_class_desc9;
					_whereConst_class_desc10 = WhereConst_class_desc10;
					_whereConst_class_desc11 = WhereConst_class_desc11;
					_whereConst_class_desc12 = WhereConst_class_desc12;
					_whereConst_class_desc13 = WhereConst_class_desc13;
					_whereConst_class_desc14 = WhereConst_class_desc14;
					_whereConst_class_desc15 = WhereConst_class_desc15;
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
				&& WhereConst_nbr_classes == null 
				&& WhereConst_class_ltr1 == null 
				&& WhereConst_class_ltr2 == null 
				&& WhereConst_class_ltr3 == null 
				&& WhereConst_class_ltr4 == null 
				&& WhereConst_class_ltr5 == null 
				&& WhereConst_class_ltr6 == null 
				&& WhereConst_class_ltr7 == null 
				&& WhereConst_class_ltr8 == null 
				&& WhereConst_class_ltr9 == null 
				&& WhereConst_class_ltr10 == null 
				&& WhereConst_class_ltr11 == null 
				&& WhereConst_class_ltr12 == null 
				&& WhereConst_class_ltr13 == null 
				&& WhereConst_class_ltr14 == null 
				&& WhereConst_class_ltr15 == null 
				&& WhereConst_class_desc1 == null 
				&& WhereConst_class_desc2 == null 
				&& WhereConst_class_desc3 == null 
				&& WhereConst_class_desc4 == null 
				&& WhereConst_class_desc5 == null 
				&& WhereConst_class_desc6 == null 
				&& WhereConst_class_desc7 == null 
				&& WhereConst_class_desc8 == null 
				&& WhereConst_class_desc9 == null 
				&& WhereConst_class_desc10 == null 
				&& WhereConst_class_desc11 == null 
				&& WhereConst_class_desc12 == null 
				&& WhereConst_class_desc13 == null 
				&& WhereConst_class_desc14 == null 
				&& WhereConst_class_desc15 == null 
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
				&& WhereConst_nbr_classes ==  _whereConst_nbr_classes
				&& WhereConst_class_ltr1 ==  _whereConst_class_ltr1
				&& WhereConst_class_ltr2 ==  _whereConst_class_ltr2
				&& WhereConst_class_ltr3 ==  _whereConst_class_ltr3
				&& WhereConst_class_ltr4 ==  _whereConst_class_ltr4
				&& WhereConst_class_ltr5 ==  _whereConst_class_ltr5
				&& WhereConst_class_ltr6 ==  _whereConst_class_ltr6
				&& WhereConst_class_ltr7 ==  _whereConst_class_ltr7
				&& WhereConst_class_ltr8 ==  _whereConst_class_ltr8
				&& WhereConst_class_ltr9 ==  _whereConst_class_ltr9
				&& WhereConst_class_ltr10 ==  _whereConst_class_ltr10
				&& WhereConst_class_ltr11 ==  _whereConst_class_ltr11
				&& WhereConst_class_ltr12 ==  _whereConst_class_ltr12
				&& WhereConst_class_ltr13 ==  _whereConst_class_ltr13
				&& WhereConst_class_ltr14 ==  _whereConst_class_ltr14
				&& WhereConst_class_ltr15 ==  _whereConst_class_ltr15
				&& WhereConst_class_desc1 ==  _whereConst_class_desc1
				&& WhereConst_class_desc2 ==  _whereConst_class_desc2
				&& WhereConst_class_desc3 ==  _whereConst_class_desc3
				&& WhereConst_class_desc4 ==  _whereConst_class_desc4
				&& WhereConst_class_desc5 ==  _whereConst_class_desc5
				&& WhereConst_class_desc6 ==  _whereConst_class_desc6
				&& WhereConst_class_desc7 ==  _whereConst_class_desc7
				&& WhereConst_class_desc8 ==  _whereConst_class_desc8
				&& WhereConst_class_desc9 ==  _whereConst_class_desc9
				&& WhereConst_class_desc10 ==  _whereConst_class_desc10
				&& WhereConst_class_desc11 ==  _whereConst_class_desc11
				&& WhereConst_class_desc12 ==  _whereConst_class_desc12
				&& WhereConst_class_desc13 ==  _whereConst_class_desc13
				&& WhereConst_class_desc14 ==  _whereConst_class_desc14
				&& WhereConst_class_desc15 ==  _whereConst_class_desc15
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_nbr_classes = null; 
			WhereConst_class_ltr1 = null; 
			WhereConst_class_ltr2 = null; 
			WhereConst_class_ltr3 = null; 
			WhereConst_class_ltr4 = null; 
			WhereConst_class_ltr5 = null; 
			WhereConst_class_ltr6 = null; 
			WhereConst_class_ltr7 = null; 
			WhereConst_class_ltr8 = null; 
			WhereConst_class_ltr9 = null; 
			WhereConst_class_ltr10 = null; 
			WhereConst_class_ltr11 = null; 
			WhereConst_class_ltr12 = null; 
			WhereConst_class_ltr13 = null; 
			WhereConst_class_ltr14 = null; 
			WhereConst_class_ltr15 = null; 
			WhereConst_class_desc1 = null; 
			WhereConst_class_desc2 = null; 
			WhereConst_class_desc3 = null; 
			WhereConst_class_desc4 = null; 
			WhereConst_class_desc5 = null; 
			WhereConst_class_desc6 = null; 
			WhereConst_class_desc7 = null; 
			WhereConst_class_desc8 = null; 
			WhereConst_class_desc9 = null; 
			WhereConst_class_desc10 = null; 
			WhereConst_class_desc11 = null; 
			WhereConst_class_desc12 = null; 
			WhereConst_class_desc13 = null; 
			WhereConst_class_desc14 = null; 
			WhereConst_class_desc15 = null; 
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
		private decimal? _CONST_NBR_CLASSES;
		private string _CONST_CLASS_LTR1;
		private string _CONST_CLASS_LTR2;
		private string _CONST_CLASS_LTR3;
		private string _CONST_CLASS_LTR4;
		private string _CONST_CLASS_LTR5;
		private string _CONST_CLASS_LTR6;
		private string _CONST_CLASS_LTR7;
		private string _CONST_CLASS_LTR8;
		private string _CONST_CLASS_LTR9;
		private string _CONST_CLASS_LTR10;
		private string _CONST_CLASS_LTR11;
		private string _CONST_CLASS_LTR12;
		private string _CONST_CLASS_LTR13;
		private string _CONST_CLASS_LTR14;
		private string _CONST_CLASS_LTR15;
		private string _CONST_CLASS_DESC1;
		private string _CONST_CLASS_DESC2;
		private string _CONST_CLASS_DESC3;
		private string _CONST_CLASS_DESC4;
		private string _CONST_CLASS_DESC5;
		private string _CONST_CLASS_DESC6;
		private string _CONST_CLASS_DESC7;
		private string _CONST_CLASS_DESC8;
		private string _CONST_CLASS_DESC9;
		private string _CONST_CLASS_DESC10;
		private string _CONST_CLASS_DESC11;
		private string _CONST_CLASS_DESC12;
		private string _CONST_CLASS_DESC13;
		private string _CONST_CLASS_DESC14;
		private string _CONST_CLASS_DESC15;
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
		public decimal? CONST_NBR_CLASSES
		{
			get { return _CONST_NBR_CLASSES; }
			set
			{
				if (_CONST_NBR_CLASSES != value)
				{
					_CONST_NBR_CLASSES = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR1
		{
			get { return _CONST_CLASS_LTR1; }
			set
			{
				if (_CONST_CLASS_LTR1 != value)
				{
					_CONST_CLASS_LTR1 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR2
		{
			get { return _CONST_CLASS_LTR2; }
			set
			{
				if (_CONST_CLASS_LTR2 != value)
				{
					_CONST_CLASS_LTR2 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR3
		{
			get { return _CONST_CLASS_LTR3; }
			set
			{
				if (_CONST_CLASS_LTR3 != value)
				{
					_CONST_CLASS_LTR3 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR4
		{
			get { return _CONST_CLASS_LTR4; }
			set
			{
				if (_CONST_CLASS_LTR4 != value)
				{
					_CONST_CLASS_LTR4 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR5
		{
			get { return _CONST_CLASS_LTR5; }
			set
			{
				if (_CONST_CLASS_LTR5 != value)
				{
					_CONST_CLASS_LTR5 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR6
		{
			get { return _CONST_CLASS_LTR6; }
			set
			{
				if (_CONST_CLASS_LTR6 != value)
				{
					_CONST_CLASS_LTR6 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR7
		{
			get { return _CONST_CLASS_LTR7; }
			set
			{
				if (_CONST_CLASS_LTR7 != value)
				{
					_CONST_CLASS_LTR7 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR8
		{
			get { return _CONST_CLASS_LTR8; }
			set
			{
				if (_CONST_CLASS_LTR8 != value)
				{
					_CONST_CLASS_LTR8 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR9
		{
			get { return _CONST_CLASS_LTR9; }
			set
			{
				if (_CONST_CLASS_LTR9 != value)
				{
					_CONST_CLASS_LTR9 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR10
		{
			get { return _CONST_CLASS_LTR10; }
			set
			{
				if (_CONST_CLASS_LTR10 != value)
				{
					_CONST_CLASS_LTR10 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR11
		{
			get { return _CONST_CLASS_LTR11; }
			set
			{
				if (_CONST_CLASS_LTR11 != value)
				{
					_CONST_CLASS_LTR11 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR12
		{
			get { return _CONST_CLASS_LTR12; }
			set
			{
				if (_CONST_CLASS_LTR12 != value)
				{
					_CONST_CLASS_LTR12 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR13
		{
			get { return _CONST_CLASS_LTR13; }
			set
			{
				if (_CONST_CLASS_LTR13 != value)
				{
					_CONST_CLASS_LTR13 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR14
		{
			get { return _CONST_CLASS_LTR14; }
			set
			{
				if (_CONST_CLASS_LTR14 != value)
				{
					_CONST_CLASS_LTR14 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_LTR15
		{
			get { return _CONST_CLASS_LTR15; }
			set
			{
				if (_CONST_CLASS_LTR15 != value)
				{
					_CONST_CLASS_LTR15 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC1
		{
			get { return _CONST_CLASS_DESC1; }
			set
			{
				if (_CONST_CLASS_DESC1 != value)
				{
					_CONST_CLASS_DESC1 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC2
		{
			get { return _CONST_CLASS_DESC2; }
			set
			{
				if (_CONST_CLASS_DESC2 != value)
				{
					_CONST_CLASS_DESC2 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC3
		{
			get { return _CONST_CLASS_DESC3; }
			set
			{
				if (_CONST_CLASS_DESC3 != value)
				{
					_CONST_CLASS_DESC3 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC4
		{
			get { return _CONST_CLASS_DESC4; }
			set
			{
				if (_CONST_CLASS_DESC4 != value)
				{
					_CONST_CLASS_DESC4 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC5
		{
			get { return _CONST_CLASS_DESC5; }
			set
			{
				if (_CONST_CLASS_DESC5 != value)
				{
					_CONST_CLASS_DESC5 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC6
		{
			get { return _CONST_CLASS_DESC6; }
			set
			{
				if (_CONST_CLASS_DESC6 != value)
				{
					_CONST_CLASS_DESC6 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC7
		{
			get { return _CONST_CLASS_DESC7; }
			set
			{
				if (_CONST_CLASS_DESC7 != value)
				{
					_CONST_CLASS_DESC7 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC8
		{
			get { return _CONST_CLASS_DESC8; }
			set
			{
				if (_CONST_CLASS_DESC8 != value)
				{
					_CONST_CLASS_DESC8 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC9
		{
			get { return _CONST_CLASS_DESC9; }
			set
			{
				if (_CONST_CLASS_DESC9 != value)
				{
					_CONST_CLASS_DESC9 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC10
		{
			get { return _CONST_CLASS_DESC10; }
			set
			{
				if (_CONST_CLASS_DESC10 != value)
				{
					_CONST_CLASS_DESC10 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC11
		{
			get { return _CONST_CLASS_DESC11; }
			set
			{
				if (_CONST_CLASS_DESC11 != value)
				{
					_CONST_CLASS_DESC11 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC12
		{
			get { return _CONST_CLASS_DESC12; }
			set
			{
				if (_CONST_CLASS_DESC12 != value)
				{
					_CONST_CLASS_DESC12 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC13
		{
			get { return _CONST_CLASS_DESC13; }
			set
			{
				if (_CONST_CLASS_DESC13 != value)
				{
					_CONST_CLASS_DESC13 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC14
		{
			get { return _CONST_CLASS_DESC14; }
			set
			{
				if (_CONST_CLASS_DESC14 != value)
				{
					_CONST_CLASS_DESC14 = value;
					ChangeState();
				}
			}
		}
		public string CONST_CLASS_DESC15
		{
			get { return _CONST_CLASS_DESC15; }
			set
			{
				if (_CONST_CLASS_DESC15 != value)
				{
					_CONST_CLASS_DESC15 = value;
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
		public decimal? WhereConst_nbr_classes { get; set; }
		private decimal? _whereConst_nbr_classes;
		public string WhereConst_class_ltr1 { get; set; }
		private string _whereConst_class_ltr1;
		public string WhereConst_class_ltr2 { get; set; }
		private string _whereConst_class_ltr2;
		public string WhereConst_class_ltr3 { get; set; }
		private string _whereConst_class_ltr3;
		public string WhereConst_class_ltr4 { get; set; }
		private string _whereConst_class_ltr4;
		public string WhereConst_class_ltr5 { get; set; }
		private string _whereConst_class_ltr5;
		public string WhereConst_class_ltr6 { get; set; }
		private string _whereConst_class_ltr6;
		public string WhereConst_class_ltr7 { get; set; }
		private string _whereConst_class_ltr7;
		public string WhereConst_class_ltr8 { get; set; }
		private string _whereConst_class_ltr8;
		public string WhereConst_class_ltr9 { get; set; }
		private string _whereConst_class_ltr9;
		public string WhereConst_class_ltr10 { get; set; }
		private string _whereConst_class_ltr10;
		public string WhereConst_class_ltr11 { get; set; }
		private string _whereConst_class_ltr11;
		public string WhereConst_class_ltr12 { get; set; }
		private string _whereConst_class_ltr12;
		public string WhereConst_class_ltr13 { get; set; }
		private string _whereConst_class_ltr13;
		public string WhereConst_class_ltr14 { get; set; }
		private string _whereConst_class_ltr14;
		public string WhereConst_class_ltr15 { get; set; }
		private string _whereConst_class_ltr15;
		public string WhereConst_class_desc1 { get; set; }
		private string _whereConst_class_desc1;
		public string WhereConst_class_desc2 { get; set; }
		private string _whereConst_class_desc2;
		public string WhereConst_class_desc3 { get; set; }
		private string _whereConst_class_desc3;
		public string WhereConst_class_desc4 { get; set; }
		private string _whereConst_class_desc4;
		public string WhereConst_class_desc5 { get; set; }
		private string _whereConst_class_desc5;
		public string WhereConst_class_desc6 { get; set; }
		private string _whereConst_class_desc6;
		public string WhereConst_class_desc7 { get; set; }
		private string _whereConst_class_desc7;
		public string WhereConst_class_desc8 { get; set; }
		private string _whereConst_class_desc8;
		public string WhereConst_class_desc9 { get; set; }
		private string _whereConst_class_desc9;
		public string WhereConst_class_desc10 { get; set; }
		private string _whereConst_class_desc10;
		public string WhereConst_class_desc11 { get; set; }
		private string _whereConst_class_desc11;
		public string WhereConst_class_desc12 { get; set; }
		private string _whereConst_class_desc12;
		public string WhereConst_class_desc13 { get; set; }
		private string _whereConst_class_desc13;
		public string WhereConst_class_desc14 { get; set; }
		private string _whereConst_class_desc14;
		public string WhereConst_class_desc15 { get; set; }
		private string _whereConst_class_desc15;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_nbr_classes;
		private string _originalConst_class_ltr1;
		private string _originalConst_class_ltr2;
		private string _originalConst_class_ltr3;
		private string _originalConst_class_ltr4;
		private string _originalConst_class_ltr5;
		private string _originalConst_class_ltr6;
		private string _originalConst_class_ltr7;
		private string _originalConst_class_ltr8;
		private string _originalConst_class_ltr9;
		private string _originalConst_class_ltr10;
		private string _originalConst_class_ltr11;
		private string _originalConst_class_ltr12;
		private string _originalConst_class_ltr13;
		private string _originalConst_class_ltr14;
		private string _originalConst_class_ltr15;
		private string _originalConst_class_desc1;
		private string _originalConst_class_desc2;
		private string _originalConst_class_desc3;
		private string _originalConst_class_desc4;
		private string _originalConst_class_desc5;
		private string _originalConst_class_desc6;
		private string _originalConst_class_desc7;
		private string _originalConst_class_desc8;
		private string _originalConst_class_desc9;
		private string _originalConst_class_desc10;
		private string _originalConst_class_desc11;
		private string _originalConst_class_desc12;
		private string _originalConst_class_desc13;
		private string _originalConst_class_desc14;
		private string _originalConst_class_desc15;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_NBR_CLASSES = _originalConst_nbr_classes;
			CONST_CLASS_LTR1 = _originalConst_class_ltr1;
			CONST_CLASS_LTR2 = _originalConst_class_ltr2;
			CONST_CLASS_LTR3 = _originalConst_class_ltr3;
			CONST_CLASS_LTR4 = _originalConst_class_ltr4;
			CONST_CLASS_LTR5 = _originalConst_class_ltr5;
			CONST_CLASS_LTR6 = _originalConst_class_ltr6;
			CONST_CLASS_LTR7 = _originalConst_class_ltr7;
			CONST_CLASS_LTR8 = _originalConst_class_ltr8;
			CONST_CLASS_LTR9 = _originalConst_class_ltr9;
			CONST_CLASS_LTR10 = _originalConst_class_ltr10;
			CONST_CLASS_LTR11 = _originalConst_class_ltr11;
			CONST_CLASS_LTR12 = _originalConst_class_ltr12;
			CONST_CLASS_LTR13 = _originalConst_class_ltr13;
			CONST_CLASS_LTR14 = _originalConst_class_ltr14;
			CONST_CLASS_LTR15 = _originalConst_class_ltr15;
			CONST_CLASS_DESC1 = _originalConst_class_desc1;
			CONST_CLASS_DESC2 = _originalConst_class_desc2;
			CONST_CLASS_DESC3 = _originalConst_class_desc3;
			CONST_CLASS_DESC4 = _originalConst_class_desc4;
			CONST_CLASS_DESC5 = _originalConst_class_desc5;
			CONST_CLASS_DESC6 = _originalConst_class_desc6;
			CONST_CLASS_DESC7 = _originalConst_class_desc7;
			CONST_CLASS_DESC8 = _originalConst_class_desc8;
			CONST_CLASS_DESC9 = _originalConst_class_desc9;
			CONST_CLASS_DESC10 = _originalConst_class_desc10;
			CONST_CLASS_DESC11 = _originalConst_class_desc11;
			CONST_CLASS_DESC12 = _originalConst_class_desc12;
			CONST_CLASS_DESC13 = _originalConst_class_desc13;
			CONST_CLASS_DESC14 = _originalConst_class_desc14;
			CONST_CLASS_DESC15 = _originalConst_class_desc15;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_Purge]");
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
						new SqlParameter("CONST_NBR_CLASSES", SqlNull(CONST_NBR_CLASSES)),
						new SqlParameter("CONST_CLASS_LTR1", SqlNull(CONST_CLASS_LTR1)),
						new SqlParameter("CONST_CLASS_LTR2", SqlNull(CONST_CLASS_LTR2)),
						new SqlParameter("CONST_CLASS_LTR3", SqlNull(CONST_CLASS_LTR3)),
						new SqlParameter("CONST_CLASS_LTR4", SqlNull(CONST_CLASS_LTR4)),
						new SqlParameter("CONST_CLASS_LTR5", SqlNull(CONST_CLASS_LTR5)),
						new SqlParameter("CONST_CLASS_LTR6", SqlNull(CONST_CLASS_LTR6)),
						new SqlParameter("CONST_CLASS_LTR7", SqlNull(CONST_CLASS_LTR7)),
						new SqlParameter("CONST_CLASS_LTR8", SqlNull(CONST_CLASS_LTR8)),
						new SqlParameter("CONST_CLASS_LTR9", SqlNull(CONST_CLASS_LTR9)),
						new SqlParameter("CONST_CLASS_LTR10", SqlNull(CONST_CLASS_LTR10)),
						new SqlParameter("CONST_CLASS_LTR11", SqlNull(CONST_CLASS_LTR11)),
						new SqlParameter("CONST_CLASS_LTR12", SqlNull(CONST_CLASS_LTR12)),
						new SqlParameter("CONST_CLASS_LTR13", SqlNull(CONST_CLASS_LTR13)),
						new SqlParameter("CONST_CLASS_LTR14", SqlNull(CONST_CLASS_LTR14)),
						new SqlParameter("CONST_CLASS_LTR15", SqlNull(CONST_CLASS_LTR15)),
						new SqlParameter("CONST_CLASS_DESC1", SqlNull(CONST_CLASS_DESC1)),
						new SqlParameter("CONST_CLASS_DESC2", SqlNull(CONST_CLASS_DESC2)),
						new SqlParameter("CONST_CLASS_DESC3", SqlNull(CONST_CLASS_DESC3)),
						new SqlParameter("CONST_CLASS_DESC4", SqlNull(CONST_CLASS_DESC4)),
						new SqlParameter("CONST_CLASS_DESC5", SqlNull(CONST_CLASS_DESC5)),
						new SqlParameter("CONST_CLASS_DESC6", SqlNull(CONST_CLASS_DESC6)),
						new SqlParameter("CONST_CLASS_DESC7", SqlNull(CONST_CLASS_DESC7)),
						new SqlParameter("CONST_CLASS_DESC8", SqlNull(CONST_CLASS_DESC8)),
						new SqlParameter("CONST_CLASS_DESC9", SqlNull(CONST_CLASS_DESC9)),
						new SqlParameter("CONST_CLASS_DESC10", SqlNull(CONST_CLASS_DESC10)),
						new SqlParameter("CONST_CLASS_DESC11", SqlNull(CONST_CLASS_DESC11)),
						new SqlParameter("CONST_CLASS_DESC12", SqlNull(CONST_CLASS_DESC12)),
						new SqlParameter("CONST_CLASS_DESC13", SqlNull(CONST_CLASS_DESC13)),
						new SqlParameter("CONST_CLASS_DESC14", SqlNull(CONST_CLASS_DESC14)),
						new SqlParameter("CONST_CLASS_DESC15", SqlNull(CONST_CLASS_DESC15)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_NBR_CLASSES = ConvertDEC(Reader["CONST_NBR_CLASSES"]);
						CONST_CLASS_LTR1 = Reader["CONST_CLASS_LTR1"].ToString();
						CONST_CLASS_LTR2 = Reader["CONST_CLASS_LTR2"].ToString();
						CONST_CLASS_LTR3 = Reader["CONST_CLASS_LTR3"].ToString();
						CONST_CLASS_LTR4 = Reader["CONST_CLASS_LTR4"].ToString();
						CONST_CLASS_LTR5 = Reader["CONST_CLASS_LTR5"].ToString();
						CONST_CLASS_LTR6 = Reader["CONST_CLASS_LTR6"].ToString();
						CONST_CLASS_LTR7 = Reader["CONST_CLASS_LTR7"].ToString();
						CONST_CLASS_LTR8 = Reader["CONST_CLASS_LTR8"].ToString();
						CONST_CLASS_LTR9 = Reader["CONST_CLASS_LTR9"].ToString();
						CONST_CLASS_LTR10 = Reader["CONST_CLASS_LTR10"].ToString();
						CONST_CLASS_LTR11 = Reader["CONST_CLASS_LTR11"].ToString();
						CONST_CLASS_LTR12 = Reader["CONST_CLASS_LTR12"].ToString();
						CONST_CLASS_LTR13 = Reader["CONST_CLASS_LTR13"].ToString();
						CONST_CLASS_LTR14 = Reader["CONST_CLASS_LTR14"].ToString();
						CONST_CLASS_LTR15 = Reader["CONST_CLASS_LTR15"].ToString();
						CONST_CLASS_DESC1 = Reader["CONST_CLASS_DESC1"].ToString();
						CONST_CLASS_DESC2 = Reader["CONST_CLASS_DESC2"].ToString();
						CONST_CLASS_DESC3 = Reader["CONST_CLASS_DESC3"].ToString();
						CONST_CLASS_DESC4 = Reader["CONST_CLASS_DESC4"].ToString();
						CONST_CLASS_DESC5 = Reader["CONST_CLASS_DESC5"].ToString();
						CONST_CLASS_DESC6 = Reader["CONST_CLASS_DESC6"].ToString();
						CONST_CLASS_DESC7 = Reader["CONST_CLASS_DESC7"].ToString();
						CONST_CLASS_DESC8 = Reader["CONST_CLASS_DESC8"].ToString();
						CONST_CLASS_DESC9 = Reader["CONST_CLASS_DESC9"].ToString();
						CONST_CLASS_DESC10 = Reader["CONST_CLASS_DESC10"].ToString();
						CONST_CLASS_DESC11 = Reader["CONST_CLASS_DESC11"].ToString();
						CONST_CLASS_DESC12 = Reader["CONST_CLASS_DESC12"].ToString();
						CONST_CLASS_DESC13 = Reader["CONST_CLASS_DESC13"].ToString();
						CONST_CLASS_DESC14 = Reader["CONST_CLASS_DESC14"].ToString();
						CONST_CLASS_DESC15 = Reader["CONST_CLASS_DESC15"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_nbr_classes = ConvertDEC(Reader["CONST_NBR_CLASSES"]);
						_originalConst_class_ltr1 = Reader["CONST_CLASS_LTR1"].ToString();
						_originalConst_class_ltr2 = Reader["CONST_CLASS_LTR2"].ToString();
						_originalConst_class_ltr3 = Reader["CONST_CLASS_LTR3"].ToString();
						_originalConst_class_ltr4 = Reader["CONST_CLASS_LTR4"].ToString();
						_originalConst_class_ltr5 = Reader["CONST_CLASS_LTR5"].ToString();
						_originalConst_class_ltr6 = Reader["CONST_CLASS_LTR6"].ToString();
						_originalConst_class_ltr7 = Reader["CONST_CLASS_LTR7"].ToString();
						_originalConst_class_ltr8 = Reader["CONST_CLASS_LTR8"].ToString();
						_originalConst_class_ltr9 = Reader["CONST_CLASS_LTR9"].ToString();
						_originalConst_class_ltr10 = Reader["CONST_CLASS_LTR10"].ToString();
						_originalConst_class_ltr11 = Reader["CONST_CLASS_LTR11"].ToString();
						_originalConst_class_ltr12 = Reader["CONST_CLASS_LTR12"].ToString();
						_originalConst_class_ltr13 = Reader["CONST_CLASS_LTR13"].ToString();
						_originalConst_class_ltr14 = Reader["CONST_CLASS_LTR14"].ToString();
						_originalConst_class_ltr15 = Reader["CONST_CLASS_LTR15"].ToString();
						_originalConst_class_desc1 = Reader["CONST_CLASS_DESC1"].ToString();
						_originalConst_class_desc2 = Reader["CONST_CLASS_DESC2"].ToString();
						_originalConst_class_desc3 = Reader["CONST_CLASS_DESC3"].ToString();
						_originalConst_class_desc4 = Reader["CONST_CLASS_DESC4"].ToString();
						_originalConst_class_desc5 = Reader["CONST_CLASS_DESC5"].ToString();
						_originalConst_class_desc6 = Reader["CONST_CLASS_DESC6"].ToString();
						_originalConst_class_desc7 = Reader["CONST_CLASS_DESC7"].ToString();
						_originalConst_class_desc8 = Reader["CONST_CLASS_DESC8"].ToString();
						_originalConst_class_desc9 = Reader["CONST_CLASS_DESC9"].ToString();
						_originalConst_class_desc10 = Reader["CONST_CLASS_DESC10"].ToString();
						_originalConst_class_desc11 = Reader["CONST_CLASS_DESC11"].ToString();
						_originalConst_class_desc12 = Reader["CONST_CLASS_DESC12"].ToString();
						_originalConst_class_desc13 = Reader["CONST_CLASS_DESC13"].ToString();
						_originalConst_class_desc14 = Reader["CONST_CLASS_DESC14"].ToString();
						_originalConst_class_desc15 = Reader["CONST_CLASS_DESC15"].ToString();
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
						new SqlParameter("CONST_NBR_CLASSES", SqlNull(CONST_NBR_CLASSES)),
						new SqlParameter("CONST_CLASS_LTR1", SqlNull(CONST_CLASS_LTR1)),
						new SqlParameter("CONST_CLASS_LTR2", SqlNull(CONST_CLASS_LTR2)),
						new SqlParameter("CONST_CLASS_LTR3", SqlNull(CONST_CLASS_LTR3)),
						new SqlParameter("CONST_CLASS_LTR4", SqlNull(CONST_CLASS_LTR4)),
						new SqlParameter("CONST_CLASS_LTR5", SqlNull(CONST_CLASS_LTR5)),
						new SqlParameter("CONST_CLASS_LTR6", SqlNull(CONST_CLASS_LTR6)),
						new SqlParameter("CONST_CLASS_LTR7", SqlNull(CONST_CLASS_LTR7)),
						new SqlParameter("CONST_CLASS_LTR8", SqlNull(CONST_CLASS_LTR8)),
						new SqlParameter("CONST_CLASS_LTR9", SqlNull(CONST_CLASS_LTR9)),
						new SqlParameter("CONST_CLASS_LTR10", SqlNull(CONST_CLASS_LTR10)),
						new SqlParameter("CONST_CLASS_LTR11", SqlNull(CONST_CLASS_LTR11)),
						new SqlParameter("CONST_CLASS_LTR12", SqlNull(CONST_CLASS_LTR12)),
						new SqlParameter("CONST_CLASS_LTR13", SqlNull(CONST_CLASS_LTR13)),
						new SqlParameter("CONST_CLASS_LTR14", SqlNull(CONST_CLASS_LTR14)),
						new SqlParameter("CONST_CLASS_LTR15", SqlNull(CONST_CLASS_LTR15)),
						new SqlParameter("CONST_CLASS_DESC1", SqlNull(CONST_CLASS_DESC1)),
						new SqlParameter("CONST_CLASS_DESC2", SqlNull(CONST_CLASS_DESC2)),
						new SqlParameter("CONST_CLASS_DESC3", SqlNull(CONST_CLASS_DESC3)),
						new SqlParameter("CONST_CLASS_DESC4", SqlNull(CONST_CLASS_DESC4)),
						new SqlParameter("CONST_CLASS_DESC5", SqlNull(CONST_CLASS_DESC5)),
						new SqlParameter("CONST_CLASS_DESC6", SqlNull(CONST_CLASS_DESC6)),
						new SqlParameter("CONST_CLASS_DESC7", SqlNull(CONST_CLASS_DESC7)),
						new SqlParameter("CONST_CLASS_DESC8", SqlNull(CONST_CLASS_DESC8)),
						new SqlParameter("CONST_CLASS_DESC9", SqlNull(CONST_CLASS_DESC9)),
						new SqlParameter("CONST_CLASS_DESC10", SqlNull(CONST_CLASS_DESC10)),
						new SqlParameter("CONST_CLASS_DESC11", SqlNull(CONST_CLASS_DESC11)),
						new SqlParameter("CONST_CLASS_DESC12", SqlNull(CONST_CLASS_DESC12)),
						new SqlParameter("CONST_CLASS_DESC13", SqlNull(CONST_CLASS_DESC13)),
						new SqlParameter("CONST_CLASS_DESC14", SqlNull(CONST_CLASS_DESC14)),
						new SqlParameter("CONST_CLASS_DESC15", SqlNull(CONST_CLASS_DESC15)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_4_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_NBR_CLASSES = ConvertDEC(Reader["CONST_NBR_CLASSES"]);
						CONST_CLASS_LTR1 = Reader["CONST_CLASS_LTR1"].ToString();
						CONST_CLASS_LTR2 = Reader["CONST_CLASS_LTR2"].ToString();
						CONST_CLASS_LTR3 = Reader["CONST_CLASS_LTR3"].ToString();
						CONST_CLASS_LTR4 = Reader["CONST_CLASS_LTR4"].ToString();
						CONST_CLASS_LTR5 = Reader["CONST_CLASS_LTR5"].ToString();
						CONST_CLASS_LTR6 = Reader["CONST_CLASS_LTR6"].ToString();
						CONST_CLASS_LTR7 = Reader["CONST_CLASS_LTR7"].ToString();
						CONST_CLASS_LTR8 = Reader["CONST_CLASS_LTR8"].ToString();
						CONST_CLASS_LTR9 = Reader["CONST_CLASS_LTR9"].ToString();
						CONST_CLASS_LTR10 = Reader["CONST_CLASS_LTR10"].ToString();
						CONST_CLASS_LTR11 = Reader["CONST_CLASS_LTR11"].ToString();
						CONST_CLASS_LTR12 = Reader["CONST_CLASS_LTR12"].ToString();
						CONST_CLASS_LTR13 = Reader["CONST_CLASS_LTR13"].ToString();
						CONST_CLASS_LTR14 = Reader["CONST_CLASS_LTR14"].ToString();
						CONST_CLASS_LTR15 = Reader["CONST_CLASS_LTR15"].ToString();
						CONST_CLASS_DESC1 = Reader["CONST_CLASS_DESC1"].ToString();
						CONST_CLASS_DESC2 = Reader["CONST_CLASS_DESC2"].ToString();
						CONST_CLASS_DESC3 = Reader["CONST_CLASS_DESC3"].ToString();
						CONST_CLASS_DESC4 = Reader["CONST_CLASS_DESC4"].ToString();
						CONST_CLASS_DESC5 = Reader["CONST_CLASS_DESC5"].ToString();
						CONST_CLASS_DESC6 = Reader["CONST_CLASS_DESC6"].ToString();
						CONST_CLASS_DESC7 = Reader["CONST_CLASS_DESC7"].ToString();
						CONST_CLASS_DESC8 = Reader["CONST_CLASS_DESC8"].ToString();
						CONST_CLASS_DESC9 = Reader["CONST_CLASS_DESC9"].ToString();
						CONST_CLASS_DESC10 = Reader["CONST_CLASS_DESC10"].ToString();
						CONST_CLASS_DESC11 = Reader["CONST_CLASS_DESC11"].ToString();
						CONST_CLASS_DESC12 = Reader["CONST_CLASS_DESC12"].ToString();
						CONST_CLASS_DESC13 = Reader["CONST_CLASS_DESC13"].ToString();
						CONST_CLASS_DESC14 = Reader["CONST_CLASS_DESC14"].ToString();
						CONST_CLASS_DESC15 = Reader["CONST_CLASS_DESC15"].ToString();
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_nbr_classes = ConvertDEC(Reader["CONST_NBR_CLASSES"]);
						_originalConst_class_ltr1 = Reader["CONST_CLASS_LTR1"].ToString();
						_originalConst_class_ltr2 = Reader["CONST_CLASS_LTR2"].ToString();
						_originalConst_class_ltr3 = Reader["CONST_CLASS_LTR3"].ToString();
						_originalConst_class_ltr4 = Reader["CONST_CLASS_LTR4"].ToString();
						_originalConst_class_ltr5 = Reader["CONST_CLASS_LTR5"].ToString();
						_originalConst_class_ltr6 = Reader["CONST_CLASS_LTR6"].ToString();
						_originalConst_class_ltr7 = Reader["CONST_CLASS_LTR7"].ToString();
						_originalConst_class_ltr8 = Reader["CONST_CLASS_LTR8"].ToString();
						_originalConst_class_ltr9 = Reader["CONST_CLASS_LTR9"].ToString();
						_originalConst_class_ltr10 = Reader["CONST_CLASS_LTR10"].ToString();
						_originalConst_class_ltr11 = Reader["CONST_CLASS_LTR11"].ToString();
						_originalConst_class_ltr12 = Reader["CONST_CLASS_LTR12"].ToString();
						_originalConst_class_ltr13 = Reader["CONST_CLASS_LTR13"].ToString();
						_originalConst_class_ltr14 = Reader["CONST_CLASS_LTR14"].ToString();
						_originalConst_class_ltr15 = Reader["CONST_CLASS_LTR15"].ToString();
						_originalConst_class_desc1 = Reader["CONST_CLASS_DESC1"].ToString();
						_originalConst_class_desc2 = Reader["CONST_CLASS_DESC2"].ToString();
						_originalConst_class_desc3 = Reader["CONST_CLASS_DESC3"].ToString();
						_originalConst_class_desc4 = Reader["CONST_CLASS_DESC4"].ToString();
						_originalConst_class_desc5 = Reader["CONST_CLASS_DESC5"].ToString();
						_originalConst_class_desc6 = Reader["CONST_CLASS_DESC6"].ToString();
						_originalConst_class_desc7 = Reader["CONST_CLASS_DESC7"].ToString();
						_originalConst_class_desc8 = Reader["CONST_CLASS_DESC8"].ToString();
						_originalConst_class_desc9 = Reader["CONST_CLASS_DESC9"].ToString();
						_originalConst_class_desc10 = Reader["CONST_CLASS_DESC10"].ToString();
						_originalConst_class_desc11 = Reader["CONST_CLASS_DESC11"].ToString();
						_originalConst_class_desc12 = Reader["CONST_CLASS_DESC12"].ToString();
						_originalConst_class_desc13 = Reader["CONST_CLASS_DESC13"].ToString();
						_originalConst_class_desc14 = Reader["CONST_CLASS_DESC14"].ToString();
						_originalConst_class_desc15 = Reader["CONST_CLASS_DESC15"].ToString();
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