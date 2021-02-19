using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class CONSTANTS_MSTR_REC_3 : BaseTable
    {
        #region Retrieve

        public ObservableCollection<CONSTANTS_MSTR_REC_3> Collection( Guid? rowid,
															decimal? const_rec_nbrmin,
															decimal? const_rec_nbrmax,
															decimal? const_misc_curr1min,
															decimal? const_misc_curr1max,
															decimal? const_misc_curr2min,
															decimal? const_misc_curr2max,
															decimal? const_misc_curr3min,
															decimal? const_misc_curr3max,
															decimal? const_misc_curr4min,
															decimal? const_misc_curr4max,
															decimal? const_misc_curr5min,
															decimal? const_misc_curr5max,
															decimal? const_misc_curr6min,
															decimal? const_misc_curr6max,
															decimal? const_misc_curr7min,
															decimal? const_misc_curr7max,
															decimal? const_misc_curr8min,
															decimal? const_misc_curr8max,
															decimal? const_misc_curr9min,
															decimal? const_misc_curr9max,
															decimal? const_misc_prev1min,
															decimal? const_misc_prev1max,
															decimal? const_misc_prev2min,
															decimal? const_misc_prev2max,
															decimal? const_misc_prev3min,
															decimal? const_misc_prev3max,
															decimal? const_misc_prev4min,
															decimal? const_misc_prev4max,
															decimal? const_misc_prev5min,
															decimal? const_misc_prev5max,
															decimal? const_misc_prev6min,
															decimal? const_misc_prev6max,
															decimal? const_misc_prev7min,
															decimal? const_misc_prev7max,
															decimal? const_misc_prev8min,
															decimal? const_misc_prev8max,
															decimal? const_misc_prev9min,
															decimal? const_misc_prev9max,
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
					new SqlParameter("minCONST_MISC_CURR1",const_misc_curr1min),
					new SqlParameter("maxCONST_MISC_CURR1",const_misc_curr1max),
					new SqlParameter("minCONST_MISC_CURR2",const_misc_curr2min),
					new SqlParameter("maxCONST_MISC_CURR2",const_misc_curr2max),
					new SqlParameter("minCONST_MISC_CURR3",const_misc_curr3min),
					new SqlParameter("maxCONST_MISC_CURR3",const_misc_curr3max),
					new SqlParameter("minCONST_MISC_CURR4",const_misc_curr4min),
					new SqlParameter("maxCONST_MISC_CURR4",const_misc_curr4max),
					new SqlParameter("minCONST_MISC_CURR5",const_misc_curr5min),
					new SqlParameter("maxCONST_MISC_CURR5",const_misc_curr5max),
					new SqlParameter("minCONST_MISC_CURR6",const_misc_curr6min),
					new SqlParameter("maxCONST_MISC_CURR6",const_misc_curr6max),
					new SqlParameter("minCONST_MISC_CURR7",const_misc_curr7min),
					new SqlParameter("maxCONST_MISC_CURR7",const_misc_curr7max),
					new SqlParameter("minCONST_MISC_CURR8",const_misc_curr8min),
					new SqlParameter("maxCONST_MISC_CURR8",const_misc_curr8max),
					new SqlParameter("minCONST_MISC_CURR9",const_misc_curr9min),
					new SqlParameter("maxCONST_MISC_CURR9",const_misc_curr9max),
					new SqlParameter("minCONST_MISC_PREV1",const_misc_prev1min),
					new SqlParameter("maxCONST_MISC_PREV1",const_misc_prev1max),
					new SqlParameter("minCONST_MISC_PREV2",const_misc_prev2min),
					new SqlParameter("maxCONST_MISC_PREV2",const_misc_prev2max),
					new SqlParameter("minCONST_MISC_PREV3",const_misc_prev3min),
					new SqlParameter("maxCONST_MISC_PREV3",const_misc_prev3max),
					new SqlParameter("minCONST_MISC_PREV4",const_misc_prev4min),
					new SqlParameter("maxCONST_MISC_PREV4",const_misc_prev4max),
					new SqlParameter("minCONST_MISC_PREV5",const_misc_prev5min),
					new SqlParameter("maxCONST_MISC_PREV5",const_misc_prev5max),
					new SqlParameter("minCONST_MISC_PREV6",const_misc_prev6min),
					new SqlParameter("maxCONST_MISC_PREV6",const_misc_prev6max),
					new SqlParameter("minCONST_MISC_PREV7",const_misc_prev7min),
					new SqlParameter("maxCONST_MISC_PREV7",const_misc_prev7max),
					new SqlParameter("minCONST_MISC_PREV8",const_misc_prev8min),
					new SqlParameter("maxCONST_MISC_PREV8",const_misc_prev8max),
					new SqlParameter("minCONST_MISC_PREV9",const_misc_prev9min),
					new SqlParameter("maxCONST_MISC_PREV9",const_misc_prev9max),
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
                Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<CONSTANTS_MSTR_REC_3>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_Search]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_3>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_3
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_MISC_CURR1 = ConvertDEC(Reader["CONST_MISC_CURR1"]),
					CONST_MISC_CURR2 = ConvertDEC(Reader["CONST_MISC_CURR2"]),
					CONST_MISC_CURR3 = ConvertDEC(Reader["CONST_MISC_CURR3"]),
					CONST_MISC_CURR4 = ConvertDEC(Reader["CONST_MISC_CURR4"]),
					CONST_MISC_CURR5 = ConvertDEC(Reader["CONST_MISC_CURR5"]),
					CONST_MISC_CURR6 = ConvertDEC(Reader["CONST_MISC_CURR6"]),
					CONST_MISC_CURR7 = ConvertDEC(Reader["CONST_MISC_CURR7"]),
					CONST_MISC_CURR8 = ConvertDEC(Reader["CONST_MISC_CURR8"]),
					CONST_MISC_CURR9 = ConvertDEC(Reader["CONST_MISC_CURR9"]),
					CONST_MISC_PREV1 = ConvertDEC(Reader["CONST_MISC_PREV1"]),
					CONST_MISC_PREV2 = ConvertDEC(Reader["CONST_MISC_PREV2"]),
					CONST_MISC_PREV3 = ConvertDEC(Reader["CONST_MISC_PREV3"]),
					CONST_MISC_PREV4 = ConvertDEC(Reader["CONST_MISC_PREV4"]),
					CONST_MISC_PREV5 = ConvertDEC(Reader["CONST_MISC_PREV5"]),
					CONST_MISC_PREV6 = ConvertDEC(Reader["CONST_MISC_PREV6"]),
					CONST_MISC_PREV7 = ConvertDEC(Reader["CONST_MISC_PREV7"]),
					CONST_MISC_PREV8 = ConvertDEC(Reader["CONST_MISC_PREV8"]),
					CONST_MISC_PREV9 = ConvertDEC(Reader["CONST_MISC_PREV9"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_misc_curr1 = ConvertDEC(Reader["CONST_MISC_CURR1"]),
					_originalConst_misc_curr2 = ConvertDEC(Reader["CONST_MISC_CURR2"]),
					_originalConst_misc_curr3 = ConvertDEC(Reader["CONST_MISC_CURR3"]),
					_originalConst_misc_curr4 = ConvertDEC(Reader["CONST_MISC_CURR4"]),
					_originalConst_misc_curr5 = ConvertDEC(Reader["CONST_MISC_CURR5"]),
					_originalConst_misc_curr6 = ConvertDEC(Reader["CONST_MISC_CURR6"]),
					_originalConst_misc_curr7 = ConvertDEC(Reader["CONST_MISC_CURR7"]),
					_originalConst_misc_curr8 = ConvertDEC(Reader["CONST_MISC_CURR8"]),
					_originalConst_misc_curr9 = ConvertDEC(Reader["CONST_MISC_CURR9"]),
					_originalConst_misc_prev1 = ConvertDEC(Reader["CONST_MISC_PREV1"]),
					_originalConst_misc_prev2 = ConvertDEC(Reader["CONST_MISC_PREV2"]),
					_originalConst_misc_prev3 = ConvertDEC(Reader["CONST_MISC_PREV3"]),
					_originalConst_misc_prev4 = ConvertDEC(Reader["CONST_MISC_PREV4"]),
					_originalConst_misc_prev5 = ConvertDEC(Reader["CONST_MISC_PREV5"]),
					_originalConst_misc_prev6 = ConvertDEC(Reader["CONST_MISC_PREV6"]),
					_originalConst_misc_prev7 = ConvertDEC(Reader["CONST_MISC_PREV7"]),
					_originalConst_misc_prev8 = ConvertDEC(Reader["CONST_MISC_PREV8"]),
					_originalConst_misc_prev9 = ConvertDEC(Reader["CONST_MISC_PREV9"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public CONSTANTS_MSTR_REC_3 Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<CONSTANTS_MSTR_REC_3> Collection(ObservableCollection<CONSTANTS_MSTR_REC_3>
                                                               constantsMstrRec3 = null)
        {
            if (IsSameSearch() && constantsMstrRec3 != null)
            {
                return constantsMstrRec3;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<CONSTANTS_MSTR_REC_3>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("CONST_REC_NBR",WhereConst_rec_nbr),
					new SqlParameter("CONST_MISC_CURR1",WhereConst_misc_curr1),
					new SqlParameter("CONST_MISC_CURR2",WhereConst_misc_curr2),
					new SqlParameter("CONST_MISC_CURR3",WhereConst_misc_curr3),
					new SqlParameter("CONST_MISC_CURR4",WhereConst_misc_curr4),
					new SqlParameter("CONST_MISC_CURR5",WhereConst_misc_curr5),
					new SqlParameter("CONST_MISC_CURR6",WhereConst_misc_curr6),
					new SqlParameter("CONST_MISC_CURR7",WhereConst_misc_curr7),
					new SqlParameter("CONST_MISC_CURR8",WhereConst_misc_curr8),
					new SqlParameter("CONST_MISC_CURR9",WhereConst_misc_curr9),
					new SqlParameter("CONST_MISC_PREV1",WhereConst_misc_prev1),
					new SqlParameter("CONST_MISC_PREV2",WhereConst_misc_prev2),
					new SqlParameter("CONST_MISC_PREV3",WhereConst_misc_prev3),
					new SqlParameter("CONST_MISC_PREV4",WhereConst_misc_prev4),
					new SqlParameter("CONST_MISC_PREV5",WhereConst_misc_prev5),
					new SqlParameter("CONST_MISC_PREV6",WhereConst_misc_prev6),
					new SqlParameter("CONST_MISC_PREV7",WhereConst_misc_prev7),
					new SqlParameter("CONST_MISC_PREV8",WhereConst_misc_prev8),
					new SqlParameter("CONST_MISC_PREV9",WhereConst_misc_prev9),
					new SqlParameter("FILLER",WhereFiller),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_Match]", parameters);
            var collection = new ObservableCollection<CONSTANTS_MSTR_REC_3>();

            while (Reader.Read())
            {
                collection.Add(new CONSTANTS_MSTR_REC_3
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]),
					CONST_MISC_CURR1 = ConvertDEC(Reader["CONST_MISC_CURR1"]),
					CONST_MISC_CURR2 = ConvertDEC(Reader["CONST_MISC_CURR2"]),
					CONST_MISC_CURR3 = ConvertDEC(Reader["CONST_MISC_CURR3"]),
					CONST_MISC_CURR4 = ConvertDEC(Reader["CONST_MISC_CURR4"]),
					CONST_MISC_CURR5 = ConvertDEC(Reader["CONST_MISC_CURR5"]),
					CONST_MISC_CURR6 = ConvertDEC(Reader["CONST_MISC_CURR6"]),
					CONST_MISC_CURR7 = ConvertDEC(Reader["CONST_MISC_CURR7"]),
					CONST_MISC_CURR8 = ConvertDEC(Reader["CONST_MISC_CURR8"]),
					CONST_MISC_CURR9 = ConvertDEC(Reader["CONST_MISC_CURR9"]),
					CONST_MISC_PREV1 = ConvertDEC(Reader["CONST_MISC_PREV1"]),
					CONST_MISC_PREV2 = ConvertDEC(Reader["CONST_MISC_PREV2"]),
					CONST_MISC_PREV3 = ConvertDEC(Reader["CONST_MISC_PREV3"]),
					CONST_MISC_PREV4 = ConvertDEC(Reader["CONST_MISC_PREV4"]),
					CONST_MISC_PREV5 = ConvertDEC(Reader["CONST_MISC_PREV5"]),
					CONST_MISC_PREV6 = ConvertDEC(Reader["CONST_MISC_PREV6"]),
					CONST_MISC_PREV7 = ConvertDEC(Reader["CONST_MISC_PREV7"]),
					CONST_MISC_PREV8 = ConvertDEC(Reader["CONST_MISC_PREV8"]),
					CONST_MISC_PREV9 = ConvertDEC(Reader["CONST_MISC_PREV9"]),
					FILLER = Reader["FILLER"].ToString(),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereConst_rec_nbr = WhereConst_rec_nbr,
					_whereConst_misc_curr1 = WhereConst_misc_curr1,
					_whereConst_misc_curr2 = WhereConst_misc_curr2,
					_whereConst_misc_curr3 = WhereConst_misc_curr3,
					_whereConst_misc_curr4 = WhereConst_misc_curr4,
					_whereConst_misc_curr5 = WhereConst_misc_curr5,
					_whereConst_misc_curr6 = WhereConst_misc_curr6,
					_whereConst_misc_curr7 = WhereConst_misc_curr7,
					_whereConst_misc_curr8 = WhereConst_misc_curr8,
					_whereConst_misc_curr9 = WhereConst_misc_curr9,
					_whereConst_misc_prev1 = WhereConst_misc_prev1,
					_whereConst_misc_prev2 = WhereConst_misc_prev2,
					_whereConst_misc_prev3 = WhereConst_misc_prev3,
					_whereConst_misc_prev4 = WhereConst_misc_prev4,
					_whereConst_misc_prev5 = WhereConst_misc_prev5,
					_whereConst_misc_prev6 = WhereConst_misc_prev6,
					_whereConst_misc_prev7 = WhereConst_misc_prev7,
					_whereConst_misc_prev8 = WhereConst_misc_prev8,
					_whereConst_misc_prev9 = WhereConst_misc_prev9,
					_whereFiller = WhereFiller,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]),
					_originalConst_misc_curr1 = ConvertDEC(Reader["CONST_MISC_CURR1"]),
					_originalConst_misc_curr2 = ConvertDEC(Reader["CONST_MISC_CURR2"]),
					_originalConst_misc_curr3 = ConvertDEC(Reader["CONST_MISC_CURR3"]),
					_originalConst_misc_curr4 = ConvertDEC(Reader["CONST_MISC_CURR4"]),
					_originalConst_misc_curr5 = ConvertDEC(Reader["CONST_MISC_CURR5"]),
					_originalConst_misc_curr6 = ConvertDEC(Reader["CONST_MISC_CURR6"]),
					_originalConst_misc_curr7 = ConvertDEC(Reader["CONST_MISC_CURR7"]),
					_originalConst_misc_curr8 = ConvertDEC(Reader["CONST_MISC_CURR8"]),
					_originalConst_misc_curr9 = ConvertDEC(Reader["CONST_MISC_CURR9"]),
					_originalConst_misc_prev1 = ConvertDEC(Reader["CONST_MISC_PREV1"]),
					_originalConst_misc_prev2 = ConvertDEC(Reader["CONST_MISC_PREV2"]),
					_originalConst_misc_prev3 = ConvertDEC(Reader["CONST_MISC_PREV3"]),
					_originalConst_misc_prev4 = ConvertDEC(Reader["CONST_MISC_PREV4"]),
					_originalConst_misc_prev5 = ConvertDEC(Reader["CONST_MISC_PREV5"]),
					_originalConst_misc_prev6 = ConvertDEC(Reader["CONST_MISC_PREV6"]),
					_originalConst_misc_prev7 = ConvertDEC(Reader["CONST_MISC_PREV7"]),
					_originalConst_misc_prev8 = ConvertDEC(Reader["CONST_MISC_PREV8"]),
					_originalConst_misc_prev9 = ConvertDEC(Reader["CONST_MISC_PREV9"]),
					_originalFiller = Reader["FILLER"].ToString(),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereConst_rec_nbr = WhereConst_rec_nbr;
					_whereConst_misc_curr1 = WhereConst_misc_curr1;
					_whereConst_misc_curr2 = WhereConst_misc_curr2;
					_whereConst_misc_curr3 = WhereConst_misc_curr3;
					_whereConst_misc_curr4 = WhereConst_misc_curr4;
					_whereConst_misc_curr5 = WhereConst_misc_curr5;
					_whereConst_misc_curr6 = WhereConst_misc_curr6;
					_whereConst_misc_curr7 = WhereConst_misc_curr7;
					_whereConst_misc_curr8 = WhereConst_misc_curr8;
					_whereConst_misc_curr9 = WhereConst_misc_curr9;
					_whereConst_misc_prev1 = WhereConst_misc_prev1;
					_whereConst_misc_prev2 = WhereConst_misc_prev2;
					_whereConst_misc_prev3 = WhereConst_misc_prev3;
					_whereConst_misc_prev4 = WhereConst_misc_prev4;
					_whereConst_misc_prev5 = WhereConst_misc_prev5;
					_whereConst_misc_prev6 = WhereConst_misc_prev6;
					_whereConst_misc_prev7 = WhereConst_misc_prev7;
					_whereConst_misc_prev8 = WhereConst_misc_prev8;
					_whereConst_misc_prev9 = WhereConst_misc_prev9;
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
				&& WhereConst_misc_curr1 == null 
				&& WhereConst_misc_curr2 == null 
				&& WhereConst_misc_curr3 == null 
				&& WhereConst_misc_curr4 == null 
				&& WhereConst_misc_curr5 == null 
				&& WhereConst_misc_curr6 == null 
				&& WhereConst_misc_curr7 == null 
				&& WhereConst_misc_curr8 == null 
				&& WhereConst_misc_curr9 == null 
				&& WhereConst_misc_prev1 == null 
				&& WhereConst_misc_prev2 == null 
				&& WhereConst_misc_prev3 == null 
				&& WhereConst_misc_prev4 == null 
				&& WhereConst_misc_prev5 == null 
				&& WhereConst_misc_prev6 == null 
				&& WhereConst_misc_prev7 == null 
				&& WhereConst_misc_prev8 == null 
				&& WhereConst_misc_prev9 == null 
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
				&& WhereConst_misc_curr1 ==  _whereConst_misc_curr1
				&& WhereConst_misc_curr2 ==  _whereConst_misc_curr2
				&& WhereConst_misc_curr3 ==  _whereConst_misc_curr3
				&& WhereConst_misc_curr4 ==  _whereConst_misc_curr4
				&& WhereConst_misc_curr5 ==  _whereConst_misc_curr5
				&& WhereConst_misc_curr6 ==  _whereConst_misc_curr6
				&& WhereConst_misc_curr7 ==  _whereConst_misc_curr7
				&& WhereConst_misc_curr8 ==  _whereConst_misc_curr8
				&& WhereConst_misc_curr9 ==  _whereConst_misc_curr9
				&& WhereConst_misc_prev1 ==  _whereConst_misc_prev1
				&& WhereConst_misc_prev2 ==  _whereConst_misc_prev2
				&& WhereConst_misc_prev3 ==  _whereConst_misc_prev3
				&& WhereConst_misc_prev4 ==  _whereConst_misc_prev4
				&& WhereConst_misc_prev5 ==  _whereConst_misc_prev5
				&& WhereConst_misc_prev6 ==  _whereConst_misc_prev6
				&& WhereConst_misc_prev7 ==  _whereConst_misc_prev7
				&& WhereConst_misc_prev8 ==  _whereConst_misc_prev8
				&& WhereConst_misc_prev9 ==  _whereConst_misc_prev9
				&& WhereFiller ==  _whereFiller
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereConst_rec_nbr = null; 
			WhereConst_misc_curr1 = null; 
			WhereConst_misc_curr2 = null; 
			WhereConst_misc_curr3 = null; 
			WhereConst_misc_curr4 = null; 
			WhereConst_misc_curr5 = null; 
			WhereConst_misc_curr6 = null; 
			WhereConst_misc_curr7 = null; 
			WhereConst_misc_curr8 = null; 
			WhereConst_misc_curr9 = null; 
			WhereConst_misc_prev1 = null; 
			WhereConst_misc_prev2 = null; 
			WhereConst_misc_prev3 = null; 
			WhereConst_misc_prev4 = null; 
			WhereConst_misc_prev5 = null; 
			WhereConst_misc_prev6 = null; 
			WhereConst_misc_prev7 = null; 
			WhereConst_misc_prev8 = null; 
			WhereConst_misc_prev9 = null; 
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
		private decimal? _CONST_MISC_CURR1;
		private decimal? _CONST_MISC_CURR2;
		private decimal? _CONST_MISC_CURR3;
		private decimal? _CONST_MISC_CURR4;
		private decimal? _CONST_MISC_CURR5;
		private decimal? _CONST_MISC_CURR6;
		private decimal? _CONST_MISC_CURR7;
		private decimal? _CONST_MISC_CURR8;
		private decimal? _CONST_MISC_CURR9;
		private decimal? _CONST_MISC_PREV1;
		private decimal? _CONST_MISC_PREV2;
		private decimal? _CONST_MISC_PREV3;
		private decimal? _CONST_MISC_PREV4;
		private decimal? _CONST_MISC_PREV5;
		private decimal? _CONST_MISC_PREV6;
		private decimal? _CONST_MISC_PREV7;
		private decimal? _CONST_MISC_PREV8;
		private decimal? _CONST_MISC_PREV9;
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
		public decimal? CONST_MISC_CURR1
		{
			get { return _CONST_MISC_CURR1; }
			set
			{
				if (_CONST_MISC_CURR1 != value)
				{
					_CONST_MISC_CURR1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR2
		{
			get { return _CONST_MISC_CURR2; }
			set
			{
				if (_CONST_MISC_CURR2 != value)
				{
					_CONST_MISC_CURR2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR3
		{
			get { return _CONST_MISC_CURR3; }
			set
			{
				if (_CONST_MISC_CURR3 != value)
				{
					_CONST_MISC_CURR3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR4
		{
			get { return _CONST_MISC_CURR4; }
			set
			{
				if (_CONST_MISC_CURR4 != value)
				{
					_CONST_MISC_CURR4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR5
		{
			get { return _CONST_MISC_CURR5; }
			set
			{
				if (_CONST_MISC_CURR5 != value)
				{
					_CONST_MISC_CURR5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR6
		{
			get { return _CONST_MISC_CURR6; }
			set
			{
				if (_CONST_MISC_CURR6 != value)
				{
					_CONST_MISC_CURR6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR7
		{
			get { return _CONST_MISC_CURR7; }
			set
			{
				if (_CONST_MISC_CURR7 != value)
				{
					_CONST_MISC_CURR7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR8
		{
			get { return _CONST_MISC_CURR8; }
			set
			{
				if (_CONST_MISC_CURR8 != value)
				{
					_CONST_MISC_CURR8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_CURR9
		{
			get { return _CONST_MISC_CURR9; }
			set
			{
				if (_CONST_MISC_CURR9 != value)
				{
					_CONST_MISC_CURR9 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV1
		{
			get { return _CONST_MISC_PREV1; }
			set
			{
				if (_CONST_MISC_PREV1 != value)
				{
					_CONST_MISC_PREV1 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV2
		{
			get { return _CONST_MISC_PREV2; }
			set
			{
				if (_CONST_MISC_PREV2 != value)
				{
					_CONST_MISC_PREV2 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV3
		{
			get { return _CONST_MISC_PREV3; }
			set
			{
				if (_CONST_MISC_PREV3 != value)
				{
					_CONST_MISC_PREV3 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV4
		{
			get { return _CONST_MISC_PREV4; }
			set
			{
				if (_CONST_MISC_PREV4 != value)
				{
					_CONST_MISC_PREV4 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV5
		{
			get { return _CONST_MISC_PREV5; }
			set
			{
				if (_CONST_MISC_PREV5 != value)
				{
					_CONST_MISC_PREV5 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV6
		{
			get { return _CONST_MISC_PREV6; }
			set
			{
				if (_CONST_MISC_PREV6 != value)
				{
					_CONST_MISC_PREV6 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV7
		{
			get { return _CONST_MISC_PREV7; }
			set
			{
				if (_CONST_MISC_PREV7 != value)
				{
					_CONST_MISC_PREV7 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV8
		{
			get { return _CONST_MISC_PREV8; }
			set
			{
				if (_CONST_MISC_PREV8 != value)
				{
					_CONST_MISC_PREV8 = value;
					ChangeState();
				}
			}
		}
		public decimal? CONST_MISC_PREV9
		{
			get { return _CONST_MISC_PREV9; }
			set
			{
				if (_CONST_MISC_PREV9 != value)
				{
					_CONST_MISC_PREV9 = value;
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
		public decimal? WhereConst_misc_curr1 { get; set; }
		private decimal? _whereConst_misc_curr1;
		public decimal? WhereConst_misc_curr2 { get; set; }
		private decimal? _whereConst_misc_curr2;
		public decimal? WhereConst_misc_curr3 { get; set; }
		private decimal? _whereConst_misc_curr3;
		public decimal? WhereConst_misc_curr4 { get; set; }
		private decimal? _whereConst_misc_curr4;
		public decimal? WhereConst_misc_curr5 { get; set; }
		private decimal? _whereConst_misc_curr5;
		public decimal? WhereConst_misc_curr6 { get; set; }
		private decimal? _whereConst_misc_curr6;
		public decimal? WhereConst_misc_curr7 { get; set; }
		private decimal? _whereConst_misc_curr7;
		public decimal? WhereConst_misc_curr8 { get; set; }
		private decimal? _whereConst_misc_curr8;
		public decimal? WhereConst_misc_curr9 { get; set; }
		private decimal? _whereConst_misc_curr9;
		public decimal? WhereConst_misc_prev1 { get; set; }
		private decimal? _whereConst_misc_prev1;
		public decimal? WhereConst_misc_prev2 { get; set; }
		private decimal? _whereConst_misc_prev2;
		public decimal? WhereConst_misc_prev3 { get; set; }
		private decimal? _whereConst_misc_prev3;
		public decimal? WhereConst_misc_prev4 { get; set; }
		private decimal? _whereConst_misc_prev4;
		public decimal? WhereConst_misc_prev5 { get; set; }
		private decimal? _whereConst_misc_prev5;
		public decimal? WhereConst_misc_prev6 { get; set; }
		private decimal? _whereConst_misc_prev6;
		public decimal? WhereConst_misc_prev7 { get; set; }
		private decimal? _whereConst_misc_prev7;
		public decimal? WhereConst_misc_prev8 { get; set; }
		private decimal? _whereConst_misc_prev8;
		public decimal? WhereConst_misc_prev9 { get; set; }
		private decimal? _whereConst_misc_prev9;
		public string WhereFiller { get; set; }
		private string _whereFiller;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private decimal? _originalConst_rec_nbr;
		private decimal? _originalConst_misc_curr1;
		private decimal? _originalConst_misc_curr2;
		private decimal? _originalConst_misc_curr3;
		private decimal? _originalConst_misc_curr4;
		private decimal? _originalConst_misc_curr5;
		private decimal? _originalConst_misc_curr6;
		private decimal? _originalConst_misc_curr7;
		private decimal? _originalConst_misc_curr8;
		private decimal? _originalConst_misc_curr9;
		private decimal? _originalConst_misc_prev1;
		private decimal? _originalConst_misc_prev2;
		private decimal? _originalConst_misc_prev3;
		private decimal? _originalConst_misc_prev4;
		private decimal? _originalConst_misc_prev5;
		private decimal? _originalConst_misc_prev6;
		private decimal? _originalConst_misc_prev7;
		private decimal? _originalConst_misc_prev8;
		private decimal? _originalConst_misc_prev9;
		private string _originalFiller;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			CONST_REC_NBR = _originalConst_rec_nbr;
			CONST_MISC_CURR1 = _originalConst_misc_curr1;
			CONST_MISC_CURR2 = _originalConst_misc_curr2;
			CONST_MISC_CURR3 = _originalConst_misc_curr3;
			CONST_MISC_CURR4 = _originalConst_misc_curr4;
			CONST_MISC_CURR5 = _originalConst_misc_curr5;
			CONST_MISC_CURR6 = _originalConst_misc_curr6;
			CONST_MISC_CURR7 = _originalConst_misc_curr7;
			CONST_MISC_CURR8 = _originalConst_misc_curr8;
			CONST_MISC_CURR9 = _originalConst_misc_curr9;
			CONST_MISC_PREV1 = _originalConst_misc_prev1;
			CONST_MISC_PREV2 = _originalConst_misc_prev2;
			CONST_MISC_PREV3 = _originalConst_misc_prev3;
			CONST_MISC_PREV4 = _originalConst_misc_prev4;
			CONST_MISC_PREV5 = _originalConst_misc_prev5;
			CONST_MISC_PREV6 = _originalConst_misc_prev6;
			CONST_MISC_PREV7 = _originalConst_misc_prev7;
			CONST_MISC_PREV8 = _originalConst_misc_prev8;
			CONST_MISC_PREV9 = _originalConst_misc_prev9;
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
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_Purge]");
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
						new SqlParameter("CONST_MISC_CURR1", SqlNull(CONST_MISC_CURR1)),
						new SqlParameter("CONST_MISC_CURR2", SqlNull(CONST_MISC_CURR2)),
						new SqlParameter("CONST_MISC_CURR3", SqlNull(CONST_MISC_CURR3)),
						new SqlParameter("CONST_MISC_CURR4", SqlNull(CONST_MISC_CURR4)),
						new SqlParameter("CONST_MISC_CURR5", SqlNull(CONST_MISC_CURR5)),
						new SqlParameter("CONST_MISC_CURR6", SqlNull(CONST_MISC_CURR6)),
						new SqlParameter("CONST_MISC_CURR7", SqlNull(CONST_MISC_CURR7)),
						new SqlParameter("CONST_MISC_CURR8", SqlNull(CONST_MISC_CURR8)),
						new SqlParameter("CONST_MISC_CURR9", SqlNull(CONST_MISC_CURR9)),
						new SqlParameter("CONST_MISC_PREV1", SqlNull(CONST_MISC_PREV1)),
						new SqlParameter("CONST_MISC_PREV2", SqlNull(CONST_MISC_PREV2)),
						new SqlParameter("CONST_MISC_PREV3", SqlNull(CONST_MISC_PREV3)),
						new SqlParameter("CONST_MISC_PREV4", SqlNull(CONST_MISC_PREV4)),
						new SqlParameter("CONST_MISC_PREV5", SqlNull(CONST_MISC_PREV5)),
						new SqlParameter("CONST_MISC_PREV6", SqlNull(CONST_MISC_PREV6)),
						new SqlParameter("CONST_MISC_PREV7", SqlNull(CONST_MISC_PREV7)),
						new SqlParameter("CONST_MISC_PREV8", SqlNull(CONST_MISC_PREV8)),
						new SqlParameter("CONST_MISC_PREV9", SqlNull(CONST_MISC_PREV9)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_MISC_CURR1 = ConvertDEC(Reader["CONST_MISC_CURR1"]);
						CONST_MISC_CURR2 = ConvertDEC(Reader["CONST_MISC_CURR2"]);
						CONST_MISC_CURR3 = ConvertDEC(Reader["CONST_MISC_CURR3"]);
						CONST_MISC_CURR4 = ConvertDEC(Reader["CONST_MISC_CURR4"]);
						CONST_MISC_CURR5 = ConvertDEC(Reader["CONST_MISC_CURR5"]);
						CONST_MISC_CURR6 = ConvertDEC(Reader["CONST_MISC_CURR6"]);
						CONST_MISC_CURR7 = ConvertDEC(Reader["CONST_MISC_CURR7"]);
						CONST_MISC_CURR8 = ConvertDEC(Reader["CONST_MISC_CURR8"]);
						CONST_MISC_CURR9 = ConvertDEC(Reader["CONST_MISC_CURR9"]);
						CONST_MISC_PREV1 = ConvertDEC(Reader["CONST_MISC_PREV1"]);
						CONST_MISC_PREV2 = ConvertDEC(Reader["CONST_MISC_PREV2"]);
						CONST_MISC_PREV3 = ConvertDEC(Reader["CONST_MISC_PREV3"]);
						CONST_MISC_PREV4 = ConvertDEC(Reader["CONST_MISC_PREV4"]);
						CONST_MISC_PREV5 = ConvertDEC(Reader["CONST_MISC_PREV5"]);
						CONST_MISC_PREV6 = ConvertDEC(Reader["CONST_MISC_PREV6"]);
						CONST_MISC_PREV7 = ConvertDEC(Reader["CONST_MISC_PREV7"]);
						CONST_MISC_PREV8 = ConvertDEC(Reader["CONST_MISC_PREV8"]);
						CONST_MISC_PREV9 = ConvertDEC(Reader["CONST_MISC_PREV9"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_misc_curr1 = ConvertDEC(Reader["CONST_MISC_CURR1"]);
						_originalConst_misc_curr2 = ConvertDEC(Reader["CONST_MISC_CURR2"]);
						_originalConst_misc_curr3 = ConvertDEC(Reader["CONST_MISC_CURR3"]);
						_originalConst_misc_curr4 = ConvertDEC(Reader["CONST_MISC_CURR4"]);
						_originalConst_misc_curr5 = ConvertDEC(Reader["CONST_MISC_CURR5"]);
						_originalConst_misc_curr6 = ConvertDEC(Reader["CONST_MISC_CURR6"]);
						_originalConst_misc_curr7 = ConvertDEC(Reader["CONST_MISC_CURR7"]);
						_originalConst_misc_curr8 = ConvertDEC(Reader["CONST_MISC_CURR8"]);
						_originalConst_misc_curr9 = ConvertDEC(Reader["CONST_MISC_CURR9"]);
						_originalConst_misc_prev1 = ConvertDEC(Reader["CONST_MISC_PREV1"]);
						_originalConst_misc_prev2 = ConvertDEC(Reader["CONST_MISC_PREV2"]);
						_originalConst_misc_prev3 = ConvertDEC(Reader["CONST_MISC_PREV3"]);
						_originalConst_misc_prev4 = ConvertDEC(Reader["CONST_MISC_PREV4"]);
						_originalConst_misc_prev5 = ConvertDEC(Reader["CONST_MISC_PREV5"]);
						_originalConst_misc_prev6 = ConvertDEC(Reader["CONST_MISC_PREV6"]);
						_originalConst_misc_prev7 = ConvertDEC(Reader["CONST_MISC_PREV7"]);
						_originalConst_misc_prev8 = ConvertDEC(Reader["CONST_MISC_PREV8"]);
						_originalConst_misc_prev9 = ConvertDEC(Reader["CONST_MISC_PREV9"]);
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
						new SqlParameter("CONST_MISC_CURR1", SqlNull(CONST_MISC_CURR1)),
						new SqlParameter("CONST_MISC_CURR2", SqlNull(CONST_MISC_CURR2)),
						new SqlParameter("CONST_MISC_CURR3", SqlNull(CONST_MISC_CURR3)),
						new SqlParameter("CONST_MISC_CURR4", SqlNull(CONST_MISC_CURR4)),
						new SqlParameter("CONST_MISC_CURR5", SqlNull(CONST_MISC_CURR5)),
						new SqlParameter("CONST_MISC_CURR6", SqlNull(CONST_MISC_CURR6)),
						new SqlParameter("CONST_MISC_CURR7", SqlNull(CONST_MISC_CURR7)),
						new SqlParameter("CONST_MISC_CURR8", SqlNull(CONST_MISC_CURR8)),
						new SqlParameter("CONST_MISC_CURR9", SqlNull(CONST_MISC_CURR9)),
						new SqlParameter("CONST_MISC_PREV1", SqlNull(CONST_MISC_PREV1)),
						new SqlParameter("CONST_MISC_PREV2", SqlNull(CONST_MISC_PREV2)),
						new SqlParameter("CONST_MISC_PREV3", SqlNull(CONST_MISC_PREV3)),
						new SqlParameter("CONST_MISC_PREV4", SqlNull(CONST_MISC_PREV4)),
						new SqlParameter("CONST_MISC_PREV5", SqlNull(CONST_MISC_PREV5)),
						new SqlParameter("CONST_MISC_PREV6", SqlNull(CONST_MISC_PREV6)),
						new SqlParameter("CONST_MISC_PREV7", SqlNull(CONST_MISC_PREV7)),
						new SqlParameter("CONST_MISC_PREV8", SqlNull(CONST_MISC_PREV8)),
						new SqlParameter("CONST_MISC_PREV9", SqlNull(CONST_MISC_PREV9)),
						new SqlParameter("FILLER", SqlNull(FILLER)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_CONSTANTS_MSTR_REC_3_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						CONST_REC_NBR = ConvertDEC(Reader["CONST_REC_NBR"]);
						CONST_MISC_CURR1 = ConvertDEC(Reader["CONST_MISC_CURR1"]);
						CONST_MISC_CURR2 = ConvertDEC(Reader["CONST_MISC_CURR2"]);
						CONST_MISC_CURR3 = ConvertDEC(Reader["CONST_MISC_CURR3"]);
						CONST_MISC_CURR4 = ConvertDEC(Reader["CONST_MISC_CURR4"]);
						CONST_MISC_CURR5 = ConvertDEC(Reader["CONST_MISC_CURR5"]);
						CONST_MISC_CURR6 = ConvertDEC(Reader["CONST_MISC_CURR6"]);
						CONST_MISC_CURR7 = ConvertDEC(Reader["CONST_MISC_CURR7"]);
						CONST_MISC_CURR8 = ConvertDEC(Reader["CONST_MISC_CURR8"]);
						CONST_MISC_CURR9 = ConvertDEC(Reader["CONST_MISC_CURR9"]);
						CONST_MISC_PREV1 = ConvertDEC(Reader["CONST_MISC_PREV1"]);
						CONST_MISC_PREV2 = ConvertDEC(Reader["CONST_MISC_PREV2"]);
						CONST_MISC_PREV3 = ConvertDEC(Reader["CONST_MISC_PREV3"]);
						CONST_MISC_PREV4 = ConvertDEC(Reader["CONST_MISC_PREV4"]);
						CONST_MISC_PREV5 = ConvertDEC(Reader["CONST_MISC_PREV5"]);
						CONST_MISC_PREV6 = ConvertDEC(Reader["CONST_MISC_PREV6"]);
						CONST_MISC_PREV7 = ConvertDEC(Reader["CONST_MISC_PREV7"]);
						CONST_MISC_PREV8 = ConvertDEC(Reader["CONST_MISC_PREV8"]);
						CONST_MISC_PREV9 = ConvertDEC(Reader["CONST_MISC_PREV9"]);
						FILLER = Reader["FILLER"].ToString();
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalConst_rec_nbr = ConvertDEC(Reader["CONST_REC_NBR"]);
						_originalConst_misc_curr1 = ConvertDEC(Reader["CONST_MISC_CURR1"]);
						_originalConst_misc_curr2 = ConvertDEC(Reader["CONST_MISC_CURR2"]);
						_originalConst_misc_curr3 = ConvertDEC(Reader["CONST_MISC_CURR3"]);
						_originalConst_misc_curr4 = ConvertDEC(Reader["CONST_MISC_CURR4"]);
						_originalConst_misc_curr5 = ConvertDEC(Reader["CONST_MISC_CURR5"]);
						_originalConst_misc_curr6 = ConvertDEC(Reader["CONST_MISC_CURR6"]);
						_originalConst_misc_curr7 = ConvertDEC(Reader["CONST_MISC_CURR7"]);
						_originalConst_misc_curr8 = ConvertDEC(Reader["CONST_MISC_CURR8"]);
						_originalConst_misc_curr9 = ConvertDEC(Reader["CONST_MISC_CURR9"]);
						_originalConst_misc_prev1 = ConvertDEC(Reader["CONST_MISC_PREV1"]);
						_originalConst_misc_prev2 = ConvertDEC(Reader["CONST_MISC_PREV2"]);
						_originalConst_misc_prev3 = ConvertDEC(Reader["CONST_MISC_PREV3"]);
						_originalConst_misc_prev4 = ConvertDEC(Reader["CONST_MISC_PREV4"]);
						_originalConst_misc_prev5 = ConvertDEC(Reader["CONST_MISC_PREV5"]);
						_originalConst_misc_prev6 = ConvertDEC(Reader["CONST_MISC_PREV6"]);
						_originalConst_misc_prev7 = ConvertDEC(Reader["CONST_MISC_PREV7"]);
						_originalConst_misc_prev8 = ConvertDEC(Reader["CONST_MISC_PREV8"]);
						_originalConst_misc_prev9 = ConvertDEC(Reader["CONST_MISC_PREV9"]);
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