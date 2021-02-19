using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataAccess.SqlServer;
namespace RmaDAL
{
    public partial class TMP_COUNTERS : BaseTable
    {
        #region Retrieve

        public ObservableCollection<TMP_COUNTERS> Collection( Guid? rowid,
															long? tmp_counter_keymin,
															long? tmp_counter_keymax,
															double? tmp_counter_1min,
															double? tmp_counter_1max,
															double? tmp_counter_2min,
															double? tmp_counter_2max,
															double? tmp_counter_3min,
															double? tmp_counter_3max,
															double? tmp_counter_4min,
															double? tmp_counter_4max,
															double? tmp_counter_5min,
															double? tmp_counter_5max,
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
					new SqlParameter("minTMP_COUNTER_KEY",tmp_counter_keymin),
					new SqlParameter("maxTMP_COUNTER_KEY",tmp_counter_keymax),
					new SqlParameter("minTMP_COUNTER_1",tmp_counter_1min),
					new SqlParameter("maxTMP_COUNTER_1",tmp_counter_1max),
					new SqlParameter("minTMP_COUNTER_2",tmp_counter_2min),
					new SqlParameter("maxTMP_COUNTER_2",tmp_counter_2max),
					new SqlParameter("minTMP_COUNTER_3",tmp_counter_3min),
					new SqlParameter("maxTMP_COUNTER_3",tmp_counter_3max),
					new SqlParameter("minTMP_COUNTER_4",tmp_counter_4min),
					new SqlParameter("maxTMP_COUNTER_4",tmp_counter_4max),
					new SqlParameter("minTMP_COUNTER_5",tmp_counter_5min),
					new SqlParameter("maxTMP_COUNTER_5",tmp_counter_5max),
					new SqlParameter("minCHECKSUM_VALUE",checksum_valuemin),
					new SqlParameter("maxCHECKSUM_VALUE",checksum_valuemax),
					new SqlParameter("SortColumn",sortcolumn),
					new SqlParameter("SortDirection",sortdirection),
					new SqlParameter("Skip",skip),
					new SqlParameter("Take",skip + TakeAmount)
				};


            if (replaceSearch)
            {
                Reader = CoreReader("[INDEXED].[sp_TMP_COUNTERS_RecordCount]", parameters);
				if (Reader.Read())
					TotalItemCount = (int)Reader[0];
				if (TotalItemCount == 0)
				{
					return new ObservableCollection<TMP_COUNTERS>();
				}

            }

            Reader = CoreReader("[INDEXED].[sp_TMP_COUNTERS_Search]", parameters);
            var collection = new ObservableCollection<TMP_COUNTERS>();

            while (Reader.Read())
            {
                collection.Add(new TMP_COUNTERS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					TMP_COUNTER_KEY = Reader["TMP_COUNTER_KEY"].ToString(),
					TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalTmp_counter_key = Reader["TMP_COUNTER_KEY"].ToString(),
					_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

            CloseConnection();
            
            return collection;
        }

        public TMP_COUNTERS Class()
        {
           if (IsSameSearch() && !IsBlankSearch())
            {
                return this;
            }
            return Collection().FirstOrDefault();
        }

        public ObservableCollection<TMP_COUNTERS> Collection(ObservableCollection<TMP_COUNTERS>
                                                               tmpCounters = null)
        {
            if (IsSameSearch() && tmpCounters != null)
            {
                return tmpCounters;
            }

            if (IsBlankSearch())
            {
                ClearSearch();
                return new ObservableCollection<TMP_COUNTERS>();
            }

            	var parameters = new SqlParameter[]
				{
					new SqlParameter("ROWID",WhereRowid),
					new SqlParameter("TMP_COUNTER_KEY",WhereTmp_counter_key),
					new SqlParameter("TMP_COUNTER_1",WhereTmp_counter_1),
					new SqlParameter("TMP_COUNTER_2",WhereTmp_counter_2),
					new SqlParameter("TMP_COUNTER_3",WhereTmp_counter_3),
					new SqlParameter("TMP_COUNTER_4",WhereTmp_counter_4),
					new SqlParameter("TMP_COUNTER_5",WhereTmp_counter_5),
					new SqlParameter("CHECKSUM_VALUE",WhereChecksum_value),
				};

			Reader = CoreReader("[INDEXED].[sp_TMP_COUNTERS_Match]", parameters);
            var collection = new ObservableCollection<TMP_COUNTERS>();

            while (Reader.Read())
            {
                collection.Add(new TMP_COUNTERS
                {
					RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]),
					ROWID = (Guid)Reader["ROWID"],
					TMP_COUNTER_KEY = Reader["TMP_COUNTER_KEY"].ToString(),
					TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]),

					_whereRowid = WhereRowid,
					_whereTmp_counter_key = WhereTmp_counter_key,
					_whereTmp_counter_1 = WhereTmp_counter_1,
					_whereTmp_counter_2 = WhereTmp_counter_2,
					_whereTmp_counter_3 = WhereTmp_counter_3,
					_whereTmp_counter_4 = WhereTmp_counter_4,
					_whereTmp_counter_5 = WhereTmp_counter_5,
					_whereChecksum_value = WhereChecksum_value,

					_originalRowid =  (Guid)Reader["ROWID"],
					_originalTmp_counter_key = Reader["TMP_COUNTER_KEY"].ToString(),
					_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]),
					_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]),
					_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]),
					_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]),
					_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]),
					_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]),

                    RecordState = State.UnChanged
                });
            }

					_whereRowid = WhereRowid;
					_whereTmp_counter_key = WhereTmp_counter_key;
					_whereTmp_counter_1 = WhereTmp_counter_1;
					_whereTmp_counter_2 = WhereTmp_counter_2;
					_whereTmp_counter_3 = WhereTmp_counter_3;
					_whereTmp_counter_4 = WhereTmp_counter_4;
					_whereTmp_counter_5 = WhereTmp_counter_5;
					_whereChecksum_value = WhereChecksum_value;


            ClearSearch();
	    CloseConnection();
            return collection;
        }

        private bool IsBlankSearch()
        {
            if (WhereRowid == null 
				&& WhereTmp_counter_key == null 
				&& WhereTmp_counter_1 == null 
				&& WhereTmp_counter_2 == null 
				&& WhereTmp_counter_3 == null 
				&& WhereTmp_counter_4 == null 
				&& WhereTmp_counter_5 == null 
				&& WhereChecksum_value == null 
)
                return true;
            return false;
        }

        private bool IsSameSearch()
        {
           return WhereRowid ==  _whereRowid
				&& WhereTmp_counter_key ==  _whereTmp_counter_key
				&& WhereTmp_counter_1 ==  _whereTmp_counter_1
				&& WhereTmp_counter_2 ==  _whereTmp_counter_2
				&& WhereTmp_counter_3 ==  _whereTmp_counter_3
				&& WhereTmp_counter_4 ==  _whereTmp_counter_4
				&& WhereTmp_counter_5 ==  _whereTmp_counter_5
				&& WhereChecksum_value ==  _whereChecksum_value
;
        }

        private bool ClearSearch()
        {
			WhereRowid = null; 
			WhereTmp_counter_key = null; 
			WhereTmp_counter_1 = null; 
			WhereTmp_counter_2 = null; 
			WhereTmp_counter_3 = null; 
			WhereTmp_counter_4 = null; 
			WhereTmp_counter_5 = null; 
			WhereChecksum_value = null; 

            return true;
        }

        #endregion

        #region Properties

        #region Columns
        private int RowCheckSum;
		private Guid _ROWID;
		private string _TMP_COUNTER_KEY;
		private decimal? _TMP_COUNTER_1;
		private decimal? _TMP_COUNTER_2;
		private decimal? _TMP_COUNTER_3;
		private decimal? _TMP_COUNTER_4;
		private decimal? _TMP_COUNTER_5;
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
		public string TMP_COUNTER_KEY
		{
			get { return _TMP_COUNTER_KEY; }
			set
			{
				if (_TMP_COUNTER_KEY != value)
				{
					_TMP_COUNTER_KEY = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_1
		{
			get { return _TMP_COUNTER_1; }
			set
			{
				if (_TMP_COUNTER_1 != value)
				{
					_TMP_COUNTER_1 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_2
		{
			get { return _TMP_COUNTER_2; }
			set
			{
				if (_TMP_COUNTER_2 != value)
				{
					_TMP_COUNTER_2 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_3
		{
			get { return _TMP_COUNTER_3; }
			set
			{
				if (_TMP_COUNTER_3 != value)
				{
					_TMP_COUNTER_3 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_4
		{
			get { return _TMP_COUNTER_4; }
			set
			{
				if (_TMP_COUNTER_4 != value)
				{
					_TMP_COUNTER_4 = value;
					ChangeState();
				}
			}
		}
		public decimal? TMP_COUNTER_5
		{
			get { return _TMP_COUNTER_5; }
			set
			{
				if (_TMP_COUNTER_5 != value)
				{
					_TMP_COUNTER_5 = value;
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
		public string WhereTmp_counter_key { get; set; }
		private string _whereTmp_counter_key;
		public double? WhereTmp_counter_1 { get; set; }
		private double? _whereTmp_counter_1;
		public double? WhereTmp_counter_2 { get; set; }
		private double? _whereTmp_counter_2;
		public double? WhereTmp_counter_3 { get; set; }
		private double? _whereTmp_counter_3;
		public double? WhereTmp_counter_4 { get; set; }
		private double? _whereTmp_counter_4;
		public double? WhereTmp_counter_5 { get; set; }
		private double? _whereTmp_counter_5;
		public int? WhereChecksum_value { get; set; }
		private int? _whereChecksum_value;


        #endregion

        #region Original

		private Guid _originalRowid;
		private string _originalTmp_counter_key;
		private decimal? _originalTmp_counter_1;
		private decimal? _originalTmp_counter_2;
		private decimal? _originalTmp_counter_3;
		private decimal? _originalTmp_counter_4;
		private decimal? _originalTmp_counter_5;
		private int? _originalChecksum_value;


        #endregion

        #endregion

        #region Undo, Delete

        public bool Undo()
        {
			ROWID = _originalRowid;
			TMP_COUNTER_KEY = _originalTmp_counter_key;
			TMP_COUNTER_1 = _originalTmp_counter_1;
			TMP_COUNTER_2 = _originalTmp_counter_2;
			TMP_COUNTER_3 = _originalTmp_counter_3;
			TMP_COUNTER_4 = _originalTmp_counter_4;
			TMP_COUNTER_5 = _originalTmp_counter_5;
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
					new SqlParameter("TMP_COUNTER_KEY",TMP_COUNTER_KEY)
				};
			RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_COUNTERS_DeleteRow]", parameters);

	    CloseConnection();
            return true;
        }
        
		public bool Purge()
		{
		    int RowsAffected = 0;
		    RowsAffected = CoreExecuteNonQuery("[INDEXED].[sp_TMP_COUNTERS_Purge]");
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
						new SqlParameter("TMP_COUNTER_KEY", SqlNull(TMP_COUNTER_KEY)),
						new SqlParameter("TMP_COUNTER_1", SqlNull(TMP_COUNTER_1)),
						new SqlParameter("TMP_COUNTER_2", SqlNull(TMP_COUNTER_2)),
						new SqlParameter("TMP_COUNTER_3", SqlNull(TMP_COUNTER_3)),
						new SqlParameter("TMP_COUNTER_4", SqlNull(TMP_COUNTER_4)),
						new SqlParameter("TMP_COUNTER_5", SqlNull(TMP_COUNTER_5)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_COUNTERS_Insert]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						TMP_COUNTER_KEY = Reader["TMP_COUNTER_KEY"].ToString();
						TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalTmp_counter_key = Reader["TMP_COUNTER_KEY"].ToString();
						_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						_originalChecksum_value = ConvertINT(Reader["CHECKSUM_VALUE"]);
					}
                 
                    break;
                case State.Modified:
					parameters = new SqlParameter[]
					{
						new SqlParameter("RowCheckSum",RowCheckSum),
						new SqlParameter("ROWID", ROWID),
						new SqlParameter("TMP_COUNTER_KEY", SqlNull(TMP_COUNTER_KEY)),
						new SqlParameter("TMP_COUNTER_1", SqlNull(TMP_COUNTER_1)),
						new SqlParameter("TMP_COUNTER_2", SqlNull(TMP_COUNTER_2)),
						new SqlParameter("TMP_COUNTER_3", SqlNull(TMP_COUNTER_3)),
						new SqlParameter("TMP_COUNTER_4", SqlNull(TMP_COUNTER_4)),
						new SqlParameter("TMP_COUNTER_5", SqlNull(TMP_COUNTER_5)),
						new SqlParameter("CHECKSUM_VALUE", SqlNull(CHECKSUM_VALUE))
					};
					Reader = CoreReader("[INDEXED].[sp_TMP_COUNTERS_Update]", parameters);
					if (Reader.Read())
					{
						RowCheckSum = Convert.ToInt32(Reader["RowCheckSum"]);
						ROWID = (Guid) Reader["ROWID"];
						TMP_COUNTER_KEY = Reader["TMP_COUNTER_KEY"].ToString();
						TMP_COUNTER_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						TMP_COUNTER_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						TMP_COUNTER_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						TMP_COUNTER_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						TMP_COUNTER_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
						CHECKSUM_VALUE = ConvertINT(Reader["CHECKSUM_VALUE"]);
						_originalRowid = (Guid) Reader["ROWID"];
						_originalTmp_counter_key = Reader["TMP_COUNTER_KEY"].ToString();
						_originalTmp_counter_1 = ConvertDEC(Reader["TMP_COUNTER_1"]);
						_originalTmp_counter_2 = ConvertDEC(Reader["TMP_COUNTER_2"]);
						_originalTmp_counter_3 = ConvertDEC(Reader["TMP_COUNTER_3"]);
						_originalTmp_counter_4 = ConvertDEC(Reader["TMP_COUNTER_4"]);
						_originalTmp_counter_5 = ConvertDEC(Reader["TMP_COUNTER_5"]);
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